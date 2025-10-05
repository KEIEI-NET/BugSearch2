#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
codex_review_severity.py — 重要度順ソート版 (v3.7.0 Production Ready)
問題の重大度に応じてレポートを並び替え、重大な問題を上位に、問題なしを下位に配置

v3.7.0 新機能 (Production Ready):
  - 本番環境対応シグナルハンドラー（Ctrl+C対応）
  - ReDoS脆弱性修正（N+1検出の正規表現を制限）
  - デッドロック対策（ロック解放時のエラーハンドリング）
  - temp_fileクリーンアップ機能（リソースリーク防止）
  - スレッドセーフな中断処理
  - クロスプラットフォーム対応（Windows/Unix）
  - 多重Ctrl+C検出（3秒以内に2回で強制終了）
  - 進捗保存による安全な中断

重点カテゴリ（重要度順）:
  1) DB負荷（N+1/全件/未インデックス/多重JOIN）- 最重要
  2) 金額面の不整合（丸め/税/小数/通貨型）- 重要
  3) UI/UX（XSS/未検証入力/多重クリック）- 中程度
  4) 印刷系（途中停止/ページ欠け/レポート系）- 低程度

pip install chromadb openai scikit-learn joblib regex
環境変数: OPENAI_API_KEY（必須: AIモード）, OPENAI_MODEL（任意: 既定 'gpt-4o'）
"""
from __future__ import annotations
import argparse, hashlib, json, os, pathlib, re, signal, sys, threading, time
from collections import defaultdict
from concurrent.futures import ThreadPoolExecutor
from dataclasses import dataclass, asdict
from fnmatch import fnmatch
from typing import Any, Dict, List, Tuple, Optional

# .envファイルから環境変数を読み込む（dotenvなしで動作）
def load_env_file(env_path=".env"):
    """dotenvなしで.envファイルを読み込む"""
    if not os.path.exists(env_path):
        return
    try:
        with open(env_path, 'r', encoding='utf-8') as f:
            for line in f:
                line = line.strip()
                if line and not line.startswith('#') and '=' in line:
                    key, value = line.split('=', 1)
                    os.environ[key.strip()] = value.strip()
    except Exception as e:
        print(f"Warning: Failed to load .env file: {e}")

# .envファイルを読み込む
load_env_file()

# ===== Config =====
IGNORE_DIRS = {".git","node_modules","dist","build","out","bin","obj",".idea",".vscode",".next","coverage","target"}
DEFAULT_MAX_FILE_BYTES = 4_000_000  # デフォルト4MB
ENV_FILE = ".env"
INDEX_PATH = ".advice_index.jsonl"
VEC_PATH = ".advice_tfidf.pkl"
MATRIX_PATH = ".advice_matrix.pkl"
BATCH_SIZE = 5  # AIに一度に送るファイル数
MAX_PROMPT_SIZE = 8000  # プロンプトの最大文字数
AI_TIMEOUT = 240  # 240秒でタイムアウト
BATCH_SIZE_DEFAULT = 500

# 重要度定義
SEVERITY_SCORES = {
    # DB関連（最重要: 10点）
    "DB: ループ内SELECT (N+1) 疑い": 10,
    "DB: SELECT * →負荷増。列限定": 8,
    "DB: 多重JOIN→遅延の恐れ。計画/IDX確認": 7,
    "DB: 大OFFSET→遅延。IDカーソル推奨": 6,

    # 金額関連（重要: 8点）
    "金額: 浮動小数で金額→誤差。Decimal/通貨型へ": 9,
    "金額: 税込/税抜・端数処理の混在注意": 7,

    # UI/セキュリティ（中程度: 5点）
    "UI: XSS脆弱性の疑い（未サニタイズHTML）": 8,
    "UI: 入力検証が不十分": 5,
    "UI: 多重クリック防止なし": 3,

    # 印刷関連（低程度: 2点）
    "印刷: エラー処理なし→途中停止リスク": 4,
    "印刷: 改ページ判定が不十分": 2,

    # Go言語関連（重要: 6-9点）
    "Go: エラーチェック不足": 8,
    "Go: goroutineリークの可能性": 9,
    "Go: チャネルデッドロックの危険": 7,
    "Go: リソース解放漏れ（defer不足）": 6,
    "Go: panicリカバリ処理なし": 5,

    # C++関連（最重要: 7-10点）
    "C++: メモリリーク（delete/スマートポインタ不足）": 10,
    "C++: バッファオーバーフローリスク": 10,
    "C++: 未初期化ポインタの危険": 9,
    "C++: RAII違反（リソース管理）": 7,
    "C++: 例外安全性の欠如": 6,

    # PHP関連（重要: 5-10点）
    "PHP: SQLインジェクション脆弱性": 10,
    "PHP: XSS脆弱性（未エスケープ出力）": 9,
    "PHP: ファイルインクルード脆弱性": 9,
    "PHP: コマンドインジェクション": 10,
    "PHP: セッション固定化攻撃の危険": 8,
    "PHP: CSRF対策不足": 8,
    "PHP: ディレクトリトラバーサル": 9,
    "PHP: mysql_*関数は非推奨（PDO/mysqli使用推奨）": 7,
    "PHP: extract()の危険な使用": 6,
    "PHP: eval()の使用（セキュリティリスク）": 9,
    "PHP: エラー表示が有効（本番環境リスク）": 5,
    "PHP: 例外処理不足": 4,

    # SOLID原則違反（中程度: 3-6点）
    "SOLID(S): 巨大クラス（500行以上）→単一責任原則違反": 5,
    "SOLID(S): 巨大構造体（15フィールド以上）→単一責任原則違反": 5,
    "SOLID(S): 巨大クラス/オブジェクト（500行以上）→単一責任原則違反": 5,
    "SOLID(O): switch文の多用→開放閉鎖原則違反": 4,
    "SOLID(O): type switchの多用→開放閉鎖原則違反": 4,
    "SOLID(O): instanceofの濫用→開放閉鎖原則違反": 4,
    "SOLID(O): 型チェックの多用→開放閉鎖原則違反": 4,
    "SOLID(L): NotImplementedException→リスコフ置換原則違反": 6,
    "SOLID(L): UnsupportedOperationException→リスコフ置換原則違反": 6,
    "SOLID(L): インターフェース実装でpanic使用→リスコフ置換原則違反": 6,
    "SOLID(L): 継承クラスでException throw→リスコフ置換原則違反": 5,
    "SOLID(L): 継承クラスでthrow→リスコフ置換原則違反": 5,
    "SOLID(I): 巨大インターフェース（10メソッド以上）→インターフェース分離原則違反": 4,
    "SOLID(I): 巨大インターフェース（7メソッド以上）→インターフェース分離原則違反": 4,
    "SOLID(D): 具象クラス直接生成（DI推奨）→依存性逆転原則違反": 3,
    "SOLID(D): グローバル変数直接参照→依存性逆転原則違反": 5,
    "SOLID(D): グローバル変数使用→依存性逆転原則違反": 5,

    # Angular固有（中程度: 4-7点）
    "Angular: 大規模コンポーネントでChangeDetectionStrategy未指定": 4,
    "Angular: OnPush戦略なのに直接プロパティ変更（changeDetectorRef推奨）": 6,
    "Angular: サービスでprovidedIn未指定（ツリーシェイキング不可）": 3,
    "Angular: コンストラクタでビジネスロジック実行（ngOnInit推奨）": 5,
    "Angular: ngOnInit内の非同期処理が未処理（メモリリークの危険）": 7,
    "Angular: Subscription放置（ngOnDestroy未実装）": 7,
    "Angular: プライベートルートにガード未実装": 8,
    "Angular: 巨大SharedModule（20コンポーネント以上）": 4,
}

# グローバル状態（シグナルハンドラー用）
_interrupt_lock = threading.Lock()
_interrupt_requested = False
_interrupt_count = 0
_first_interrupt_time = None

# SOLID原則とAngularの閾値定数（マジックナンバー削減）
SOLID_THRESHOLDS = {
    'large_class_lines': 500,           # 巨大クラスの行数
    'switch_count': 3,                   # switchの多用判定
    'interface_methods_default': 10,     # インターフェースメソッド数（C#, Java, PHP, TS）
    'interface_methods_go': 7,           # Goのインターフェースメソッド数
    'struct_fields_go': 15,              # Go巨大構造体のフィールド数
    'instanceof_count': 3,               # instanceofの濫用判定
    'type_check_count': 5,               # 型チェックの多用判定
    'angular_large_component_lines': 200,  # Angular大規模コンポーネント
    'angular_shared_components': 20,     # SharedModule内コンポーネント数
    'constructor_check_chars': 200,      # constructorボディチェック文字数
    'ngOnInit_check_chars': 500,         # ngOnInitボディチェック文字数
    'interface_check_chars': 300,        # インターフェースボディチェック文字数
}

# ログとAI処理の定数
PROCESSING_CONSTANTS = {
    'error_msg_max_length': 100,         # エラーメッセージ表示の最大文字数
    'error_msg_max_length_extended': 150,  # 拡張エラーメッセージの最大文字数
    'error_msg_max_length_long': 200,    # 長いエラーメッセージの最大文字数
    'text_truncate_vectorize': 10000,    # ベクトル化時のテキスト切り詰め文字数
    'text_truncate_analysis': 20000,     # 分析時のテキスト切り詰め文字数
    'tfidf_max_features': 5000,          # TF-IDF最大特徴量数
    'ai_prompt_max_length': 5000,        # AIプロンプトの最大文字数
    'summary_max_lines': 10,             # サマリーの最大行数
    'summary_line_length': 80,           # サマリー各行の最大文字数
    'summary_total_length': 400,         # サマリー全体の最大文字数
    'text_preview_length': 3000,         # テキストプレビューの文字数
    'top_tags_count': 15,                # 上位タグの表示数
}

# プリコンパイル済み正規表現パターン（2-3倍高速化）
COMPILED_PATTERNS = {
    # 共通パターン
    'class_def': re.compile(r'\b(class|struct)\s+\w+'),
    'interface_def': re.compile(r'interface\s+(\w+)'),
    'switch_stmt': re.compile(r'\bswitch\s*\('),

    # C#パターン
    'csharp_not_implemented': re.compile(r'throw\s+new\s+NotImplementedException'),
    'csharp_concrete_new': re.compile(r'=\s*new\s+[A-Z]\w+(Repository|Service|Manager|Handler)\('),

    # Goパターン
    'go_struct_def': re.compile(r'type\s+\w+\s+struct\s*\{([^}]+)\}', re.DOTALL),
    'go_type_switch': re.compile(r'switch\s+\w+\s*:=\s*\w+\.\(type\)'),
    'go_interface_def': re.compile(r'type\s+\w+\s+interface'),
    'go_var_decl': re.compile(r'var\s+\w+\s+\*?\w+', re.MULTILINE),
    'go_global_ref': re.compile(r'func\s+\w+\([^)]*\)\s*[^{]{0,100}\{(.{0,1000})', re.DOTALL),  # ReDoS対策: 文字数制限
    'go_global_names': re.compile(r'\b([A-Z]\w*(?:DB|Config|Logger|Cache|Client)|global\w+)\b'),

    # Javaパターン
    'java_instanceof': re.compile(r'\binstanceof\b'),
    'java_unsupported': re.compile(r'@Override.*?\{.*?throw\s+new\s+UnsupportedOperationException', re.DOTALL),
    'java_concrete_new': re.compile(r'=\s*new\s+[A-Z]\w+(Repository|Service|Manager|Dao|Controller)\('),

    # PHPパターン
    'php_globals': re.compile(r'\$GLOBALS\['),
    'php_extends_throw': re.compile(r'class\s+\w+\s+extends.*\{.*throw\s+new\s+Exception', re.DOTALL),
    'php_file_ops': re.compile(r'(file_get_contents|fopen|include|require).*\$_(GET|POST|REQUEST)'),
    'php_realpath': re.compile(r'realpath\s*\('),
    'php_validation': re.compile(r'(str(?:pos|str|ipos)\s*\([^,]*,\s*[\'"]\.\.[\'"]\)|preg_match\s*\(\s*[\'"][^\'"]*\.\.[^\'"]*[\'"]\s*,)'),

    # JS/TSパターン
    'jsts_type_check': re.compile(r'\b(typeof|instanceof)\b'),
    'jsts_extends_throw': re.compile(r'class\s+\w+\s+extends.*\{.*throw\s+new\s+Error', re.DOTALL),
    'jsts_concrete_import': re.compile(r'(new|import).*\b[A-Z]\w+(Repository|Service|Manager|Controller)'),
    'jsts_di_keyword': re.compile(r'(inject|provide|container|DI)', re.IGNORECASE),

    # Angularパターン
    'angular_decorator': re.compile(r'@(Component|Injectable|NgModule|Directive|Pipe)'),
    'angular_component': re.compile(r'@Component\({'),
    'angular_change_detection': re.compile(r'changeDetection:'),
    'angular_on_push': re.compile(r'changeDetection:\s*ChangeDetectionStrategy\.OnPush'),
    'angular_property_assign': re.compile(r'this\.\w+\s*=\s*'),
    'angular_change_detector': re.compile(r'(changeDetectorRef|markForCheck|detectChanges)'),
    'angular_injectable': re.compile(r'@Injectable\({'),
    'angular_provided_in': re.compile(r'providedIn:'),
    'angular_constructor': re.compile(r'constructor\([^)]*\)\s*\{(.{1,200})', re.DOTALL),
    'angular_constructor_logic': re.compile(r'(this\.\w+\.\w+\(|subscribe|http\.|fetch)'),
    'angular_ng_on_init': re.compile(r'ngOnInit\(\)[^{]*\{(.{1,500})', re.DOTALL),
    'angular_subscribe': re.compile(r'\.(subscribe|then)'),
    'angular_takeuntil': re.compile(r'(takeUntil|\.unsubscribe\(\)|\.add\()'),
    'angular_ng_on_destroy': re.compile(r'ngOnDestroy\('),
    'angular_async_pipe': re.compile(r'async\s+pipe'),
    'angular_router': re.compile(r'RouterModule|Routes|@angular/router'),
    'angular_private_route': re.compile(r'path:\s*["\'](?:admin|dashboard|private)'),
    'angular_guard': re.compile(r'canActivate|canLoad|AuthGuard'),
    'angular_ng_module': re.compile(r'@NgModule\({'),
    'angular_shared': re.compile(r'SharedModule|CommonModule'),
    'angular_declarations': re.compile(r'declarations:\s*\[(.*?)\]', re.DOTALL),
    'angular_component_name': re.compile(r'\w+Component'),
}

# ===== Optional deps =====
SKLEARN_OK = False
try:
    from sklearn.feature_extraction.text import TfidfVectorizer
    import joblib
    SKLEARN_OK = True
except Exception:
    pass

OPENAI_OK = False
try:
    from openai import OpenAI
    OPENAI_OK = True
except Exception:
    pass

ANTHROPIC_OK = False
try:
    from anthropic import Anthropic
    ANTHROPIC_OK = True
except Exception:
    pass

# ===== Utils =====
if ENV_FILE and pathlib.Path(ENV_FILE).exists():
    # セキュア環境変数読み込み: コメント/空行スキップ、ホワイトリスト、既存保護
    allowed_keys = {'OPENAI_API_KEY', 'OPENAI_MODEL', 'ANTHROPIC_API_KEY'}
    with open(ENV_FILE, "r", encoding="utf-8") as f:
        for line in f:
            line = line.strip()
            # コメント・空行をスキップ
            if not line or line.startswith('#'):
                continue
            # 正しい形式のみ処理
            if "=" not in line:
                continue
            key, val = line.split("=", 1)
            key = key.strip()
            val = val.strip()
            # 安全なキーのみ許可（ホワイトリスト）
            if key in allowed_keys:
                # 既存環境変数を保護（システム設定を優先）
                if key not in os.environ:
                    os.environ[key] = val

@dataclass
class Doc:
    path: str; lang: str; size: int; sha1: str; tags: List[str]; summary: str; text: str


@dataclass
class IndexStats:
    enabled: bool
    total_start: float = 0.0
    counts: Dict[str, int] = None
    timings: Dict[str, float] = None

    def __post_init__(self) -> None:
        if self.enabled:
            self.total_start = time.perf_counter()
            self.counts = defaultdict(int)
            self.timings = defaultdict(float)
        else:
            self.counts = defaultdict(int)
            self.timings = defaultdict(float)

    def bump(self, key: str, delta: int = 1) -> None:
        if self.enabled:
            self.counts[key] += delta

    def add_time(self, key: str, duration: float) -> None:
        if self.enabled:
            self.timings[key] += duration

    def render_summary(self) -> Optional[str]:
        if not self.enabled:
            return None
        total_elapsed = time.perf_counter() - self.total_start
        indexed = self.counts.get("indexed", 0)
        seen = self.counts.get("seen", 0)
        skipped_large = self.counts.get("skipped_large", 0)
        skipped_binary = self.counts.get("skipped_binary", 0)
        skipped_errors = self.counts.get("skipped_errors", 0)
        skipped_filter = self.counts.get("skipped_filter", 0)
        limit_stop = self.counts.get("limit_stop", 0)
        timeout_stop = self.counts.get("timeout_stop", 0)
        reused = self.counts.get("reused", 0)
        avg_read = (self.timings.get("read", 0.0) / indexed) if indexed else 0.0
        return (
            f"[PROFILE] Indexed {indexed}/{seen} files in {total_elapsed:.2f}s\n"
            f"           read={self.timings.get('read', 0.0):.2f}s stat={self.timings.get('stat', 0.0):.2f}s write={self.timings.get('write', 0.0):.2f}s\n"
            f"           avg_read_per_file={avg_read*1000:.1f}ms reused={reused} large_skipped={skipped_large} binary_skipped={skipped_binary} filter_skipped={skipped_filter} errors={skipped_errors} limits={limit_stop} timeouts={timeout_stop}"
        )

    def to_rows(self) -> List[Dict[str, Any]]:
        if not self.enabled:
            return []
        return [{
            "total_seconds": time.perf_counter() - self.total_start,
            "indexed_files": self.counts.get("indexed", 0),
            "seen_files": self.counts.get("seen", 0),
            "skipped_large": self.counts.get("skipped_large", 0),
            "skipped_binary": self.counts.get("skipped_binary", 0),
            "skipped_errors": self.counts.get("skipped_errors", 0),
            "skipped_filter": self.counts.get("skipped_filter", 0),
            "limit_stop": self.counts.get("limit_stop", 0),
            "timeout_stop": self.counts.get("timeout_stop", 0),
            "reused_files": self.counts.get("reused", 0),
            "read_seconds": self.timings.get("read", 0.0),
            "stat_seconds": self.timings.get("stat", 0.0),
            "write_seconds": self.timings.get("write", 0.0)
        }]

    def export(self, path: pathlib.Path) -> None:
        if not self.enabled:
            return
        rows = self.to_rows()
        if not rows:
            return
        path.parent.mkdir(parents=True, exist_ok=True)
        if path.suffix.lower() == ".csv":
            import csv
            with path.open("w", encoding="utf-8", newline="") as fh:
                writer = csv.DictWriter(fh, fieldnames=list(rows[0].keys()))
                writer.writeheader()
                writer.writerows(rows)
        else:
            path.write_text("\n".join(json.dumps(r, ensure_ascii=False) for r in rows) + "\n", encoding="utf-8")

def sha1_bytes(data: bytes) -> str:
    return hashlib.sha1(data).hexdigest()[:10]

def detect_lang(p: pathlib.Path) -> str:
    ext = p.suffix.lower()
    if ext in (".py",): return "python"
    if ext in (".js",".mjs",".cjs",".jsx"): return "javascript"
    if ext in (".ts",".tsx"): return "typescript"
    if ext in (".cs",".csx"): return "csharp"
    if ext in (".java",): return "java"
    if ext in (".pas",".dfm",".dpr"): return "delphi"
    if ext in (".rb",): return "ruby"
    if ext in (".go",): return "go"
    if ext in (".rs",): return "rust"
    if ext in (".php",): return "php"
    if ext in (".c",".h"): return "c"
    if ext in (".cpp",".hpp",".cc",".hh",".cxx",".hxx"): return "cpp"
    return "other"

def is_text_file(p: pathlib.Path) -> bool:
    try:
        with open(p, "rb") as fh:
            return b"\x00" not in fh.read(4096)
    except Exception:
        return False

def make_summary(text: str) -> str:
    """テキストからサマリーを生成（先頭N行、各行M文字、全体K文字）"""
    max_lines = PROCESSING_CONSTANTS['summary_max_lines']
    line_len = PROCESSING_CONSTANTS['summary_line_length']
    total_len = PROCESSING_CONSTANTS['summary_total_length']
    lines = text.splitlines()[:max_lines]
    return " / ".join(l.strip()[:line_len] for l in lines if l.strip())[:total_len]


def normalize_rel_path(repo: pathlib.Path, path: pathlib.Path) -> str:
    try:
        rel = path.relative_to(repo)
    except ValueError:
        rel = path
    return str(rel).replace(os.sep, "/")


def match_patterns(rel_path: str, patterns: Optional[List[str]]) -> bool:
    if not patterns:
        return False
    return any(fnmatch(rel_path, pat) for pat in patterns)

def write_large_file_log(large_files: List[Tuple[str, int]], output_dir: pathlib.Path, max_file_bytes: int) -> pathlib.Path|None:
    if not large_files: return None
    reports_dir = output_dir / "reports"; reports_dir.mkdir(parents=True, exist_ok=True)
    log_path = reports_dir / "large_files_over_limit.log"
    with open(log_path, "w", encoding="utf-8") as f:
        f.write(f"Large files exceeding limit ({max_file_bytes:,} bytes):\n\n")
        for file_path, size in sorted(large_files, key=lambda x: x[1], reverse=True):
            f.write(f"{size:12,} bytes  {file_path}\n")
        f.write(f"\nTotal: {len(large_files)} files\n")
    return log_path

def iter_files(root: pathlib.Path):
    for dirpath, dirnames, filenames in os.walk(root):
        dirnames[:] = [d for d in dirnames if d not in IGNORE_DIRS and not d.startswith('.')]
        for fn in filenames:
            yield pathlib.Path(dirpath) / fn


def load_meta(meta_path: pathlib.Path) -> Dict[str, Dict[str, Any]]:
    if not meta_path.exists():
        return {}
    try:
        raw = meta_path.read_text(encoding="utf-8")
        data = json.loads(raw) if raw.strip() else {}
        if isinstance(data, dict):
            return {str(k): v for k, v in data.items() if isinstance(v, dict)}
    except Exception:
        pass
    return {}


def write_meta(meta_path: pathlib.Path, meta: Dict[str, Dict[str, Any]]) -> None:
    try:
        meta_path.parent.mkdir(parents=True, exist_ok=True)
        meta_path.write_text(json.dumps(meta, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")
    except Exception:
        pass


def load_previous_index(index_path: pathlib.Path) -> Dict[str, Dict[str, Any]]:
    if not index_path.exists():
        return {}
    out: Dict[str, Dict[str, Any]] = {}
    try:
        with index_path.open("r", encoding="utf-8") as fh:
            for line in fh:
                line = line.strip()
                if not line:
                    continue
                try:
                    doc = json.loads(line)
                    rel_path = doc.get("path")
                    if isinstance(rel_path, str):
                        out[rel_path] = doc
                except Exception:
                    continue
    except Exception:
        return {}
    return out

# ===== Rule engine =====
def scan_money(text: str) -> List[str]:
    m: List[str] = []
    if re.search(r"\b(float|double|real)\b.*\b(price|cost|money|amount|tax|total|sum|charge|fee|pay)", text, re.IGNORECASE):
        m.append("金額: 浮動小数で金額→誤差。Decimal/通貨型へ")
    if re.search(r"\b(total|sum|amount)\s*=.*\+.*tax", text, re.IGNORECASE) and re.search(r"(Math\.(floor|round)|parseInt|truncate)", text, re.IGNORECASE):
        m.append("金額: 税込/税抜・端数処理の混在注意")
    return m

def scan_print(text: str) -> List[str]:
    m: List[str] = []
    if re.search(r"(window\.print|PrintDocument|Printer|PrintPage|HasMorePages|NewPage|PrintPreview)", text, re.IGNORECASE) and not re.search(r"(try|catch|error|exception)", text, re.IGNORECASE):
        m.append("印刷: エラー処理なし→途中停止リスク")
    if re.search(r"\.HasMorePages\s*=\s*true", text, re.IGNORECASE) and not re.search(r"(yPos|currentY|pageHeight|margin)", text, re.IGNORECASE):
        m.append("印刷: 改ページ判定が不十分")
    return m

def scan_ui(text: str) -> List[str]:
    m: List[str] = []
    if re.search(r"(button|submit|click|tap|press)", text, re.IGNORECASE) and not re.search(r"(disabled|loading|spinner|prevent|debounce|throttle)", text, re.IGNORECASE):
        m.append("UI: 多重クリック防止なし")
    if re.search(r"(innerHTML\s*=|dangerouslySetInnerHTML|v-html)", text) and not re.search(r"(sanitize|escape|DOMPurify|textContent)", text, re.IGNORECASE):
        m.append("UI: XSS脆弱性の疑い（未サニタイズHTML）")
    if re.search(r"(input|textarea|select)", text, re.IGNORECASE) and not re.search(r"(validate|pattern|required|maxlength|regex|test|match)", text, re.IGNORECASE):
        m.append("UI: 入力検証が不十分")
    return m

def scan_db(text: str) -> List[str]:
    m: List[str] = []
    if re.search(r"SELECT\s+\*\s+FROM", text, re.IGNORECASE):
        m.append("DB: SELECT * →負荷増。列限定")
    if re.search(r"(for|while|foreach|map).{0,1000}\n.{0,1000}\n.{0,1000}\n.{0,1000}(SELECT|INSERT|UPDATE|DELETE)", text, re.IGNORECASE):
        m.append("DB: ループ内SELECT (N+1) 疑い")
    if re.search(r"(JOIN.*){3,}", text, re.IGNORECASE):
        m.append("DB: 多重JOIN→遅延の恐れ。計画/IDX確認")
    if re.search(r"(OFFSET|LIMIT)\s+\d{4,}", text, re.IGNORECASE):
        m.append("DB: 大OFFSET→遅延。IDカーソル推奨")
    return m

def scan_go(text: str) -> List[str]:
    """Go言語固有の問題を検出"""
    m: List[str] = []
    lines = text.split('\n')

    # エラーチェック不足 - _ でエラーを明示的に無視している
    if re.search(r",\s*_\s*:=.*\(", text) or re.search(r"_\s*,.*:=.*\(", text):
        m.append("Go: エラーチェック不足（エラー無視）")

    # 関数呼び出し後のエラーチェック不足
    for i, line in enumerate(lines):
        if re.search(r"err\s*:=.*\(", line) or re.search(r",\s*err\s*:=", line):
            # 次の数行内にエラーチェックがあるか確認
            has_err_check = False
            for j in range(i, min(i + 5, len(lines))):
                if re.search(r"if\s+err\s*!=\s*nil", lines[j]):
                    has_err_check = True
                    break
            if not has_err_check:
                m.append("Go: エラーチェック不足")
                break

    # goroutineリーク - 無限ループのgoroutine
    if re.search(r"go\s+func", text):
        # 無限ループで終了条件がない
        if re.search(r"for\s*\{", text) and not re.search(r"(select|return|break|<-.*Done|<-.*done|context\.Done)", text):
            m.append("Go: goroutineリークの可能性")

    # チャネルデッドロック - バッファなしチャネルへの同期送信
    if re.search(r"make\(chan\s+", text) and not re.search(r"make\(chan\s+\w+\s*,\s*\d+", text):
        # バッファなしチャネルで、goroutineなしの送信
        if re.search(r"ch\s*<-", text) and not re.search(r"go\s+", text):
            m.append("Go: チャネルデッドロックの危険")

    # defer忘れ - リソース管理
    if re.search(r"os\.Open\(", text) and not re.search(r"defer.*\.Close\(\)", text):
        m.append("Go: ファイルクローズ忘れ（defer不足）")
    if re.search(r"\.Lock\(\)", text) and not re.search(r"defer.*\.Unlock\(\)", text):
        m.append("Go: ロック解放忘れ（defer不足）")

    # ループ内のdefer
    if re.search(r"for\s+.*\{.*defer.*\}", text, re.DOTALL):
        m.append("Go: ループ内のdefer（メモリリーク）")

    # panicリカバリ不足
    if re.search(r"panic\(", text) and not re.search(r"defer.*recover\(\)", text):
        m.append("Go: panicリカバリ処理なし")

    return m

def scan_cpp(text: str) -> List[str]:
    """C++固有の問題を検出"""
    m: List[str] = []
    # メモリリーク
    if re.search(r"new\s+\w+", text) and not re.search(r"(delete|unique_ptr|shared_ptr|make_unique|make_shared)", text):
        m.append("C++: メモリリーク（delete/スマートポインタ不足）")
    # バッファオーバーフロー
    if re.search(r"(strcpy|strcat|sprintf|gets)\s*\(", text):
        m.append("C++: バッファオーバーフローリスク")
    # 未初期化ポインタ
    if re.search(r"\*\s*\w+\s*;", text) and not re.search(r"=\s*(nullptr|NULL|new|&)", text):
        m.append("C++: 未初期化ポインタの危険")
    # リソースRAII違反
    if re.search(r"(fopen|CreateFile|socket|open)\s*\(", text) and not re.search(r"(fclose|CloseHandle|close|RAII|unique_ptr|shared_ptr)", text):
        m.append("C++: RAII違反（リソース管理）")
    # 例外安全性
    if re.search(r"throw\s+", text) and not re.search(r"(try|catch|noexcept)", text):
        m.append("C++: 例外安全性の欠如")
    return m

def scan_php(text: str) -> List[str]:
    """PHP固有の問題を検出"""
    m: List[str] = []

    # SQLインジェクション
    if re.search(r'\$_(GET|POST|REQUEST)\[.*?\].*?(mysql_query|mysqli_query|query|exec|execute)', text, re.IGNORECASE):
        if not re.search(r'(prepare|bind_param|bindParam|quote|escape|real_escape)', text, re.IGNORECASE):
            m.append("PHP: SQLインジェクション脆弱性")

    # XSS脆弱性
    if re.search(r'echo\s+\$_(GET|POST|REQUEST|COOKIE)\[', text):
        if not re.search(r'(htmlspecialchars|htmlentities|strip_tags|filter_var)', text):
            m.append("PHP: XSS脆弱性（未エスケープ出力）")

    # ファイルインクルード
    if re.search(r'(include|require|include_once|require_once)\s*\(\s*\$_(GET|POST|REQUEST)', text):
        m.append("PHP: ファイルインクルード脆弱性")

    # コマンドインジェクション
    if re.search(r'(exec|system|shell_exec|passthru|`.*\$_(GET|POST|REQUEST).*`)', text):
        m.append("PHP: コマンドインジェクション")

    # セッション固定化
    if re.search(r'session_start\(\)', text) and not re.search(r'session_regenerate_id', text):
        m.append("PHP: セッション固定化攻撃の危険")

    # CSRF対策
    if re.search(r'<form.*method=["\']post["\']', text, re.IGNORECASE):
        if not re.search(r'(csrf|token|nonce)', text, re.IGNORECASE):
            m.append("PHP: CSRF対策不足")

    # ディレクトリトラバーサル（修正版）
    # Fix: より適切な保護パターンチェック + プリコンパイル済みパターン使用
    if COMPILED_PATTERNS['php_file_ops'].search(text):
        # realpath(), basename(), pathinfo(), またはホワイトリスト検証があるか確認
        has_realpath = COMPILED_PATTERNS['php_realpath'].search(text)
        has_validation = COMPILED_PATTERNS['php_validation'].search(text)
        has_basename = re.search(r'basename\s*\(', text)
        has_pathinfo = re.search(r'pathinfo\s*\(', text)
        has_whitelist = re.search(r'preg_match\s*\(["\'][^"\']*\^[^"\']*\$', text)  # 厳格なホワイトリスト

        if not (has_realpath or has_validation or has_basename or has_pathinfo or has_whitelist):
            m.append("PHP: ディレクトリトラバーサル")

    # 非推奨関数
    if re.search(r'mysql_(connect|query|fetch|close)', text):
        m.append("PHP: mysql_*関数は非推奨（PDO/mysqli使用推奨）")

    # extract()の危険な使用
    if re.search(r'extract\s*\(\s*\$_(GET|POST|REQUEST)', text):
        m.append("PHP: extract()の危険な使用")

    # eval()の使用
    if re.search(r'eval\s*\(', text):
        m.append("PHP: eval()の使用（セキュリティリスク）")

    # エラー表示
    if re.search(r'display_errors\s*=\s*["\']?(on|1)', text, re.IGNORECASE):
        m.append("PHP: エラー表示が有効（本番環境リスク）")

    # 例外処理
    if re.search(r'(mysql_query|mysqli_query|PDO|fopen|file_get_contents)', text):
        if not re.search(r'(try|catch|throw|Exception)', text):
            m.append("PHP: 例外処理不足")

    return m

def _check_large_interface(text: str, pattern: str, method_pattern: str, threshold: int) -> Optional[str]:
    """
    汎用インターフェース巨大性チェック（DRY原則適用）
    Fix: ネストブレース対応 - 簡略化されたパターンマッチング
    """
    # インターフェース宣言のみを検索（本体は簡略パターン）
    interface_sections = re.finditer(r'interface\s+(\w+)', text)
    for match in interface_sections:
        # インターフェース名の後N文字以内でメソッド数をカウント
        start_pos = match.end()
        check_len = SOLID_THRESHOLDS['interface_check_chars']
        section = text[start_pos:start_pos+check_len]
        method_count = len(re.findall(method_pattern, section))
        if method_count >= threshold:
            return f"SOLID(I): 巨大インターフェース（{threshold}メソッド以上）→インターフェース分離原則違反"
    return None

def scan_solid_csharp(text: str) -> List[str]:
    """C# SOLID原則違反を検出"""
    m: List[str] = []
    lines = text.split('\n')

    # Single Responsibility - 巨大クラス
    has_class = COMPILED_PATTERNS['class_def'].search(text)
    threshold = SOLID_THRESHOLDS['large_class_lines']
    if has_class and len(lines) > threshold:
        m.append(f"SOLID(S): 巨大クラス（{threshold}行以上）→単一責任原則違反")

    # Open/Closed - switch文の多用
    switch_count = len(COMPILED_PATTERNS['switch_stmt'].findall(text))
    switch_threshold = SOLID_THRESHOLDS['switch_count']
    if switch_count >= switch_threshold:
        m.append("SOLID(O): switch文の多用→開放閉鎖原則違反")

    # Liskov Substitution - NotImplementedException
    if COMPILED_PATTERNS['csharp_not_implemented'].search(text):
        m.append("SOLID(L): NotImplementedException→リスコフ置換原則違反")

    # Interface Segregation - 巨大インターフェース（共通関数使用）
    interface_threshold = SOLID_THRESHOLDS['interface_methods_default']
    interface_msg = _check_large_interface(text, r'interface\s+\w+', r'\w+\s+\w+\s*\(', interface_threshold)
    if interface_msg:
        m.append(interface_msg)

    # Dependency Inversion - new演算子での具象クラス生成
    if COMPILED_PATTERNS['csharp_concrete_new'].search(text):
        m.append("SOLID(D): 具象クラス直接生成（DI推奨）→依存性逆転原則違反")

    return m

def scan_solid_go(text: str) -> List[str]:
    """Go SOLID原則違反を検出"""
    m: List[str] = []

    # Single Responsibility - 巨大構造体
    struct_matches = COMPILED_PATTERNS['go_struct_def'].findall(text)
    struct_threshold = SOLID_THRESHOLDS['struct_fields_go']
    for struct_body in struct_matches:
        field_count = len(re.findall(r'\w+\s+\w+', struct_body))
        if field_count >= struct_threshold:
            m.append(f"SOLID(S): 巨大構造体（{struct_threshold}フィールド以上）→単一責任原則違反")
            break

    # Open/Closed - type switchの多用
    type_switch_count = len(COMPILED_PATTERNS['go_type_switch'].findall(text))
    if type_switch_count >= 2:
        m.append("SOLID(O): type switchの多用→開放閉鎖原則違反")

    # Liskov Substitution - インターフェース実装でのpanic
    if re.search(r'func\s+\([^)]+\)\s+\w+\([^)]*\).*\{.*panic\(', text, re.DOTALL):
        m.append("SOLID(L): インターフェース実装でpanic使用→リスコフ置換原則違反")

    # Interface Segregation - 巨大インターフェース（共通関数使用）
    interface_threshold = SOLID_THRESHOLDS['interface_methods_go']
    interface_msg = _check_large_interface(text, r'type\s+\w+\s+interface', r'\w+\s*\([^)]*\)', interface_threshold)
    if interface_msg:
        m.append(interface_msg)

    # Dependency Inversion - グローバル変数直接参照（修正版）
    # Fix: より広範なパターン検出（capitalized globals, common names) + ReDoS対策
    if COMPILED_PATTERNS['go_var_decl'].search(text):
        # 関数本体（最初の1000文字）でグローバル変数名を検出
        func_match = COMPILED_PATTERNS['go_global_ref'].search(text)
        if func_match:
            func_body = func_match.group(1)
            if COMPILED_PATTERNS['go_global_names'].search(func_body):
                m.append("SOLID(D): グローバル変数直接参照→依存性逆転原則違反")

    return m

def scan_solid_java(text: str) -> List[str]:
    """Java SOLID原則違反を検出"""
    m: List[str] = []
    lines = text.split('\n')

    # Single Responsibility - 巨大クラス
    threshold = SOLID_THRESHOLDS['large_class_lines']
    if len(lines) > threshold and COMPILED_PATTERNS['class_def'].search(text):
        m.append(f"SOLID(S): 巨大クラス（{threshold}行以上）→単一責任原則違反")

    # Open/Closed - instanceofの濫用
    instanceof_count = len(COMPILED_PATTERNS['java_instanceof'].findall(text))
    instanceof_threshold = SOLID_THRESHOLDS['instanceof_count']
    if instanceof_count >= instanceof_threshold:
        m.append("SOLID(O): instanceofの濫用→開放閉鎖原則違反")

    # Liskov Substitution - UnsupportedOperationException
    if COMPILED_PATTERNS['java_unsupported'].search(text):
        m.append("SOLID(L): UnsupportedOperationException→リスコフ置換原則違反")

    # Interface Segregation - 巨大インターフェース（共通関数使用）
    interface_threshold = SOLID_THRESHOLDS['interface_methods_default']
    interface_msg = _check_large_interface(text, r'interface\s+\w+', r'\w+\s+\w+\s*\(', interface_threshold)
    if interface_msg:
        m.append(interface_msg)

    # Dependency Inversion - new演算子での具象クラス生成
    if COMPILED_PATTERNS['java_concrete_new'].search(text):
        m.append("SOLID(D): 具象クラス直接生成（DI推奨）→依存性逆転原則違反")

    return m

def scan_solid_php(text: str) -> List[str]:
    """PHP SOLID原則違反を検出"""
    m: List[str] = []
    lines = text.split('\n')

    # Single Responsibility - 巨大クラス
    threshold = SOLID_THRESHOLDS['large_class_lines']
    if len(lines) > threshold and COMPILED_PATTERNS['class_def'].search(text):
        m.append(f"SOLID(S): 巨大クラス（{threshold}行以上）→単一責任原則違反")

    # Open/Closed - switch/caseの多用
    switch_count = len(COMPILED_PATTERNS['switch_stmt'].findall(text))
    switch_threshold = SOLID_THRESHOLDS['switch_count']
    if switch_count >= switch_threshold:
        m.append("SOLID(O): switch文の多用→開放閉鎖原則違反")

    # Liskov Substitution - 継承クラスでのException throw
    if COMPILED_PATTERNS['php_extends_throw'].search(text):
        m.append("SOLID(L): 継承クラスでException throw→リスコフ置換原則違反")

    # Interface Segregation - 巨大インターフェース（共通関数使用）
    interface_threshold = SOLID_THRESHOLDS['interface_methods_default']
    interface_msg = _check_large_interface(text, r'interface\s+\w+', r'public\s+function\s+\w+', interface_threshold)
    if interface_msg:
        m.append(interface_msg)

    # Dependency Inversion - グローバル変数使用
    if COMPILED_PATTERNS['php_globals'].search(text):
        m.append("SOLID(D): グローバル変数使用→依存性逆転原則違反")

    return m

def scan_solid_javascript_typescript(text: str) -> List[str]:
    """JavaScript/TypeScript SOLID原則違反を検出"""
    m: List[str] = []
    lines = text.split('\n')

    # Single Responsibility - 巨大クラス/オブジェクト
    threshold = SOLID_THRESHOLDS['large_class_lines']
    if len(lines) > threshold and re.search(r'\b(class|function|const\s+\w+\s*=\s*\{)', text):
        m.append(f"SOLID(S): 巨大クラス/オブジェクト（{threshold}行以上）→単一責任原則違反")

    # Open/Closed - typeof/instanceofチェックの多用
    type_check_count = len(COMPILED_PATTERNS['jsts_type_check'].findall(text))
    type_check_threshold = SOLID_THRESHOLDS['type_check_count']
    if type_check_count >= type_check_threshold:
        m.append("SOLID(O): 型チェックの多用→開放閉鎖原則違反")

    # Liskov Substitution - 継承クラスでのthrow
    if COMPILED_PATTERNS['jsts_extends_throw'].search(text):
        m.append("SOLID(L): 継承クラスでthrow→リスコフ置換原則違反")

    # Interface Segregation - 巨大インターフェース（共通関数使用）
    interface_threshold = SOLID_THRESHOLDS['interface_methods_default']
    interface_msg = _check_large_interface(text, r'interface\s+\w+', r'\w+\s*\([^)]*\)\s*:', interface_threshold)
    if interface_msg:
        m.append(interface_msg)

    # Dependency Inversion - require/importでの具象クラス直接生成
    if COMPILED_PATTERNS['jsts_concrete_import'].search(text):
        if not COMPILED_PATTERNS['jsts_di_keyword'].search(text):
            m.append("SOLID(D): 具象クラス直接生成（DI推奨）→依存性逆転原則違反")

    return m

def scan_angular(text: str) -> List[str]:
    """Angular固有の問題を検出"""
    m: List[str] = []

    # Angularファイルかチェック
    is_angular = COMPILED_PATTERNS['angular_decorator'].search(text)
    if not is_angular:
        return m

    # 1. 変更検出の問題
    if COMPILED_PATTERNS['angular_component'].search(text):
        # ChangeDetectionStrategy未指定の大規模コンポーネント
        component_threshold = SOLID_THRESHOLDS['angular_large_component_lines']
        if not COMPILED_PATTERNS['angular_change_detection'].search(text) and len(text.split('\n')) > component_threshold:
            m.append("Angular: 大規模コンポーネントでChangeDetectionStrategy未指定")

        # OnPushなのに直接プロパティ変更
        if COMPILED_PATTERNS['angular_on_push'].search(text):
            if COMPILED_PATTERNS['angular_property_assign'].search(text) and not COMPILED_PATTERNS['angular_change_detector'].search(text):
                m.append("Angular: OnPush戦略なのに直接プロパティ変更（changeDetectorRef推奨）")

    # 2. 依存性注入の問題
    if COMPILED_PATTERNS['angular_injectable'].search(text):
        # providedIn未指定
        if not COMPILED_PATTERNS['angular_provided_in'].search(text):
            m.append("Angular: サービスでprovidedIn未指定（ツリーシェイキング不可）")

    # コンストラクタでのビジネスロジック
    # Fix: ReDoS対策 - 最初の200文字のみチェック（ネストブレース対応）
    constructor_match = COMPILED_PATTERNS['angular_constructor'].search(text)
    if constructor_match:
        constructor_body = constructor_match.group(1)
        if COMPILED_PATTERNS['angular_constructor_logic'].search(constructor_body):
            m.append("Angular: コンストラクタでビジネスロジック実行（ngOnInit推奨）")

    # 3. ライフサイクルの問題
    if COMPILED_PATTERNS['angular_component'].search(text):
        # ngOnInit内での非同期処理の未処理
        # Fix: メソッド内スコープのみチェック（ファイル全体ではなく）
        ngOnInit_match = COMPILED_PATTERNS['angular_ng_on_init'].search(text)
        if ngOnInit_match:
            ngOnInit_body = ngOnInit_match.group(1)
            if COMPILED_PATTERNS['angular_subscribe'].search(ngOnInit_body):
                # ファイル全体で確認（takeUntilはクラスレベルの可能性があるため）
                if not COMPILED_PATTERNS['angular_takeuntil'].search(text):
                    m.append("Angular: ngOnInit内の非同期処理が未処理（メモリリークの危険）")

        # ngOnDestroy未実装でのSubscription
        if COMPILED_PATTERNS['angular_subscribe'].search(text) and not COMPILED_PATTERNS['angular_ng_on_destroy'].search(text):
            if not COMPILED_PATTERNS['angular_async_pipe'].search(text):
                m.append("Angular: Subscription放置（ngOnDestroy未実装）")

    # 4. ルーティング問題
    if COMPILED_PATTERNS['angular_router'].search(text):
        # ガード未実装のプライベートルート
        if COMPILED_PATTERNS['angular_private_route'].search(text):
            if not COMPILED_PATTERNS['angular_guard'].search(text):
                m.append("Angular: プライベートルートにガード未実装")

    # 5. モジュール構成
    if COMPILED_PATTERNS['angular_ng_module'].search(text):
        # 巨大なSharedModule
        if COMPILED_PATTERNS['angular_shared'].search(text):
            declarations_match = COMPILED_PATTERNS['angular_declarations'].search(text)
            if declarations_match:
                declarations = declarations_match.group(1)
                component_count = len(COMPILED_PATTERNS['angular_component_name'].findall(declarations))
                shared_threshold = SOLID_THRESHOLDS['angular_shared_components']
                if component_count >= shared_threshold:
                    m.append(f"Angular: 巨大SharedModule（{shared_threshold}コンポーネント以上）")

    return m

def make_tags(text: str) -> List[str]:
    t = []
    if re.search(r"\b(price|cost|money|amount|tax|total|sum|charge|fee|pay|invoice|billing|currency|decimal|round)", text, re.IGNORECASE): t.append("money")
    if re.search(r"\b(print|printer|page|paper|report|pdf|export|PrintDocument|PrintPage|HasMorePages)", text, re.IGNORECASE): t.append("print")
    if re.search(r"\b(button|click|submit|form|input|select|modal|dialog|toast|spinner|loading|disabled)", text, re.IGNORECASE): t.append("uiux")
    if re.search(r"\b(SELECT|INSERT|UPDATE|DELETE|JOIN|WHERE|FROM|query|sql|database|transaction|connection)", text, re.IGNORECASE): t.append("db")
    if re.search(r"\b(api|http|fetch|axios|request|response|endpoint|REST|webhook|curl)", text, re.IGNORECASE): t.append("net")
    if re.search(r"\b(file|fs|stream|read|write|upload|download|path|directory|folder)", text, re.IGNORECASE): t.append("io")

    # Go固有タグ
    if re.search(r"\b(goroutine|channel|defer|panic|recover|context|sync\.WaitGroup)", text, re.IGNORECASE):
        t.append("go-concurrent")

    # C++固有タグ
    if re.search(r"\b(new|delete|malloc|free|unique_ptr|shared_ptr|make_unique|make_shared)", text, re.IGNORECASE):
        t.append("cpp-memory")

    # PHP固有タグ
    if re.search(r"\b(\$_(GET|POST|REQUEST|SESSION|COOKIE)|session_start|mysql_|mysqli_|PDO|include|require)", text):
        t.append("php-web")

    return sorted(set(t))

# ===== Signal Handlers =====
def setup_signal_handlers() -> None:
    """シグナルハンドラーを設定（Ctrl+C対応・クロスプラットフォーム対応）"""
    global _interrupt_requested, _interrupt_count, _first_interrupt_time

    def signal_handler(signum, frame):
        global _interrupt_requested, _interrupt_count, _first_interrupt_time

        with _interrupt_lock:
            _interrupt_count += 1

            if _interrupt_count == 1:
                # 初回の中断リクエスト
                _interrupt_requested = True
                _first_interrupt_time = time.time()

                print("\n\n" + "="*80, file=sys.stderr)
                print("[INFO] 中断リクエストを受信しました (Ctrl+C)", file=sys.stderr)
                print("[INFO] 現在の処理が完了したら、安全に終了します...", file=sys.stderr)
                print("[INFO] もう一度Ctrl+Cで強制終了します", file=sys.stderr)
                print("="*80 + "\n", file=sys.stderr)

            elif _interrupt_count >= 2:
                # 2回目以降の中断リクエスト（強制終了）
                elapsed = time.time() - _first_interrupt_time
                if elapsed < 3.0:  # 3秒以内なら強制終了
                    print("\n[WARNING] 強制終了します！", file=sys.stderr)
                    # ロックを解放してから終了（ロック所有権を確認）
                    try:
                        _interrupt_lock.release()
                    except RuntimeError:
                        pass  # ロック未所有の場合は無視
                    sys.exit(130)  # SIGINT標準終了コード

    # SIGINT (Ctrl+C) は全プラットフォームで対応
    signal.signal(signal.SIGINT, signal_handler)

    # プラットフォーム固有のシグナル
    if sys.platform == "win32":
        if hasattr(signal, 'SIGBREAK'):
            signal.signal(signal.SIGBREAK, signal_handler)
    else:
        if hasattr(signal, 'SIGTERM'):
            signal.signal(signal.SIGTERM, signal_handler)
        if hasattr(signal, 'SIGHUP'):
            signal.signal(signal.SIGHUP, signal_handler)


def check_interrupt() -> bool:
    """中断リクエストがあるかチェック（スレッドセーフ）"""
    with _interrupt_lock:
        return _interrupt_requested


# ===== Indexer =====
def should_index(p: pathlib.Path, exclude_langs: set) -> bool:
    if p.is_dir(): return False
    if any(part.startswith(".") for part in p.parts): return False
    lang = detect_lang(p)
    # 指定された言語を除外
    if lang in exclude_langs:
        return False
    if lang == "other":
        important_ext = {".xml", ".json", ".yaml", ".yml", ".toml", ".ini", ".config", ".md", ".txt", ".html", ".htm", ".css"}
        if p.suffix.lower() in important_ext: return True
        if p.name in {"Dockerfile", "Makefile", "Rakefile", "Gemfile", ".env", ".env.example"}: return True
        return False
    return True

def cmd_index(
    repo: pathlib.Path,
    index_path: pathlib.Path,
    exclude_langs: set = None,
    max_file_bytes: int = None,
    *,
    profile: bool = False,
    profile_output: pathlib.Path | None = None,
    batch_size: int | None = None,
    max_files: int | None = None,
    max_seconds: float | None = None,
    include_patterns: Optional[List[str]] = None,
    exclude_patterns: Optional[List[str]] = None,
    worker_count: int | None = None,
):
    # シグナルハンドラーを設定（Ctrl+C対応）
    setup_signal_handlers()

    if exclude_langs is None:
        exclude_langs = set()
    if max_file_bytes is None:
        max_file_bytes = DEFAULT_MAX_FILE_BYTES

    repo = repo.resolve()
    count = 0
    reused_count = 0
    large_files: List[Tuple[str, int]] = []
    stats = IndexStats(enabled=profile)
    norm_include = include_patterns or []
    norm_exclude = exclude_patterns or []
    start_time = time.perf_counter()
    batch_size = batch_size if batch_size and batch_size > 0 else None
    reader_workers = max(0, worker_count or 0)

    meta_path = index_path.with_name(f"{index_path.stem}.meta.json")
    prev_meta = load_meta(meta_path)
    prev_docs = load_previous_index(index_path) if prev_meta else {}
    new_meta: Dict[str, Dict[str, Any]] = {}

    tasks: List[Tuple[pathlib.Path, str, Optional[Dict[str, Any]], int, int, str]] = []
    for p in iter_files(repo):
        stats.bump("seen")
        rel_norm = normalize_rel_path(repo, p)
        if norm_include and not match_patterns(rel_norm, norm_include):
            stats.bump("skipped_filter")
            continue
        if match_patterns(rel_norm, norm_exclude):
            stats.bump("skipped_filter")
            continue
        try:
            stat_start = time.perf_counter()
            stat = p.stat()
            file_size = stat.st_size
            mtime_ns = getattr(stat, "st_mtime_ns", int(stat.st_mtime * 1_000_000_000))
            stats.add_time("stat", time.perf_counter() - stat_start)
        except Exception:
            stats.bump("skipped_errors")
            continue
        if file_size > max_file_bytes:
            large_files.append((rel_norm, file_size))
            stats.bump("skipped_large")
            continue
        if not should_index(p, exclude_langs):
            continue
        lang = detect_lang(p)
        prev_info = prev_meta.get(rel_norm)
        if prev_info and prev_info.get("size") == file_size and prev_info.get("mtime_ns") == mtime_ns:
            prev_doc = prev_docs.get(rel_norm)
            if prev_doc:
                tasks.append((p, lang, prev_doc, file_size, mtime_ns, rel_norm))
                continue
        if not is_text_file(p):
            stats.bump("skipped_binary")
            continue
        tasks.append((p, lang, None, file_size, mtime_ns, rel_norm))

    def read_document(item: Tuple[pathlib.Path, str]):
        path, _ = item
        read_start = time.perf_counter()
        try:
            txt = path.read_text(encoding="utf-8", errors="ignore")
            duration = time.perf_counter() - read_start
            return path, txt, duration, None
        except Exception as exc:
            duration = time.perf_counter() - read_start
            return path, None, duration, exc

    read_targets = [(path, lang) for path, lang, doc, _, _, _ in tasks if doc is None]
    read_results: Dict[pathlib.Path, Tuple[Optional[str], Optional[Exception]]] = {}
    if read_targets:
        executor: ThreadPoolExecutor | None = None
        iterator: Any
        failed_reads = 0
        if reader_workers > 1:
            executor = ThreadPoolExecutor(max_workers=reader_workers)
            iterator = executor.map(read_document, read_targets)
        else:
            iterator = map(read_document, read_targets)
        try:
            for path, txt, duration, error in iterator:
                stats.add_time("read", duration)
                if error:
                    failed_reads += 1
                    # エラー詳細をログに記録（ただしパス情報のみ、機密情報はマスク）
                    error_msg = str(error)
                    sanitized_msg = re.sub(r'sk-[a-zA-Z0-9_-]{20,}', '***MASKED***', error_msg)
                    max_len = PROCESSING_CONSTANTS['error_msg_max_length']
                    print(f"[WARNING] Failed to read {path.name}: {sanitized_msg[:max_len]}", file=sys.stderr)
                read_results[path] = (txt, error)

            # 読み取りエラーのサマリー
            if failed_reads > 0:
                print(f"[INFO] {failed_reads}/{len(read_targets)} files failed to read", file=sys.stderr)
        except Exception as e:
            # ThreadPoolExecutor自体のエラー処理
            error_msg = str(e)
            sanitized_msg = re.sub(r'sk-[a-zA-Z0-9_-]{20,}', '***MASKED***', error_msg)
            max_len = PROCESSING_CONSTANTS['error_msg_max_length_extended']
            print(f"[ERROR] Parallel processing error: {sanitized_msg[:max_len]}", file=sys.stderr)
            raise
        finally:
            if executor:
                executor.shutdown(wait=True)  # wait=Trueで全タスク完了を待つ

    batch_buffer: List[str] = []
    interrupted = False
    try:
        with open(index_path, "w", encoding="utf-8") as w:
            for path, lang, reuse_doc, file_size, mtime_ns, rel_path in tasks:
                # 中断チェック
                if check_interrupt():
                    interrupted = True
                    print(f"\n[INFO] 中断が要求されました。現在の進捗を保存しています...", file=sys.stderr)
                    stats.bump("interrupt_stop")
                    break

                if reuse_doc is not None:
                    batch_buffer.append(json.dumps(reuse_doc, ensure_ascii=False) + "\n")
                    stats.bump("indexed")
                    stats.bump("reused")
                    reused_count += 1
                    count += 1
                    new_meta[rel_path] = {
                        "size": file_size,
                        "mtime_ns": mtime_ns,
                        "sha1": reuse_doc.get("sha1", "")
                    }
                else:
                    txt, error = read_results.get(path, (None, RuntimeError("read_failed")))
                    if error or txt is None:
                        stats.bump("skipped_errors")
                        continue
                    if not txt:
                        continue
                    tags = make_tags(txt)
                    encoded = txt.encode("utf-8", errors="ignore")
                    doc = Doc(path=rel_path, lang=lang, size=len(encoded), sha1=sha1_bytes(encoded), tags=tags, summary=make_summary(txt), text=txt)
                    batch_buffer.append(json.dumps(asdict(doc), ensure_ascii=False) + "\n")
                    stats.bump("indexed")
                    count += 1
                    new_meta[rel_path] = {
                        "size": file_size,
                        "mtime_ns": mtime_ns,
                        "sha1": doc.sha1
                    }
                if batch_size and len(batch_buffer) >= batch_size:
                    write_start = time.perf_counter()
                    w.writelines(batch_buffer)
                    stats.add_time("write", time.perf_counter() - write_start)
                    batch_buffer.clear()
                    print(f"[INFO] Indexed {count} files...")
                if max_files and count >= max_files:
                    stats.bump("limit_stop")
                    break
                if max_seconds and (time.perf_counter() - start_time) >= max_seconds:
                    stats.bump("timeout_stop")
                    break
            if batch_buffer:
                write_start = time.perf_counter()
                w.writelines(batch_buffer)
                stats.add_time("write", time.perf_counter() - write_start)
                batch_buffer.clear()
    finally:
        write_meta(meta_path, new_meta)

    # [SUMMARY]形式の出力
    seen_count = stats.counts.get("seen", 0)
    indexed_count = stats.counts.get("indexed", 0)
    reused_count = stats.counts.get("reused", 0)
    skipped_large = stats.counts.get("skipped_large", 0)
    skipped_binary = stats.counts.get("skipped_binary", 0)
    skipped_filter = stats.counts.get("skipped_filter", 0)
    skipped_errors = stats.counts.get("skipped_errors", 0)

    print(f"[SUMMARY] seen={seen_count} indexed={indexed_count} reused={reused_count} skipped_large={skipped_large} skipped_binary={skipped_binary} skipped_filter={skipped_filter} skipped_errors={skipped_errors}")

    # 詳細情報
    if large_files:
        print(f"[DETAIL] 大容量スキップ上位: ", end="")
        top_large = sorted(large_files, key=lambda x: x[1], reverse=True)[:3]
        details = [f"{name} ({size/1_000_000:.1f}MB)" for name, size in top_large]
        print(", ".join(details))

    print(f"[OK] Indexed {count} files -> {index_path}")
    if reused_count:
        print(f"[INFO] Reused {reused_count} files from previous index")

    log_path = write_large_file_log(large_files, index_path.parent.resolve(), max_file_bytes)
    if log_path:
        threshold_mb = max_file_bytes / 1_000_000
        try:
            rel_log = log_path.relative_to(index_path.parent.resolve())
        except ValueError:
            rel_log = log_path
        print(f"[WARNING] Skipped {len(large_files)} files exceeding ~{threshold_mb:.1f} MB. Details: {rel_log}")
    if stats.counts.get("limit_stop"):
        print("[INFO] Stopped due to --max-files limit")
    if stats.counts.get("timeout_stop"):
        print("[WARNING] Stopped due to --max-seconds timeout")
    if stats.counts.get("interrupt_stop") or interrupted:
        print("[WARNING] Stopped due to user interrupt (Ctrl+C)")
        print(f"[INFO] 部分的なインデックスが保存されました: {count}ファイル")
    summary = stats.render_summary()
    if summary:
        print(summary)
        if profile_output:
            stats.export(profile_output)

# ===== Retrieval =====
def load_index_stream(index_path: pathlib.Path):
    """
    メモリ効率的なインデックスローダー（ジェネレータ版）
    大規模プロジェクトでのOOM対策
    """
    with open(index_path, "r", encoding="utf-8") as f:
        for line in f:
            line = line.strip()
            if line:
                yield json.loads(line)

def load_index(index_path: pathlib.Path) -> List[Dict[str,Any]]:
    """
    従来互換のインデックスローダー（全件メモリ読み込み）
    注意: 大規模プロジェクトではOOMリスクあり
    """
    return list(load_index_stream(index_path))

def retrieve(query: str, index: List[Dict[str,Any]], topk: int = 10) -> List[Dict[str,Any]]:
    if SKLEARN_OK:
        vec_p = pathlib.Path(VEC_PATH); mat_p = pathlib.Path(MATRIX_PATH)
        if vec_p.exists() and mat_p.exists():
            return retrieve_tfidf(query, index, vec_p, mat_p, topk)
    return retrieve_naive(query, index, topk)

def retrieve_naive(query: str, index: List[Dict[str,Any]], topk: int) -> List[Dict[str,Any]]:
    """単純な単語マッチングによる検索（TF-IDF未使用時のフォールバック）"""
    preview_len = PROCESSING_CONSTANTS['text_preview_length']
    q_words = set(w.lower() for w in re.split(r"\W+", query) if w)
    for doc in index:
        txt_words = set(w.lower() for w in re.split(r"\W+", doc.get("text","")[:preview_len]) if w)
        doc["_score"] = len(q_words & txt_words) / (len(q_words) + 0.01)
    return sorted(index, key=lambda x: x.get("_score",0), reverse=True)[:topk]

def retrieve_tfidf(query: str, index: List[Dict[str,Any]], vec_path: pathlib.Path, mat_path: pathlib.Path, topk: int) -> List[Dict[str,Any]]:
    from sklearn.metrics.pairwise import cosine_similarity
    vec = joblib.load(vec_path); mat = joblib.load(mat_path)
    q_vec = vec.transform([query])
    scores = cosine_similarity(q_vec, mat).flatten()
    for i, doc in enumerate(index):
        if i < len(scores):
            doc["_score"] = float(scores[i])
    return sorted(index, key=lambda x: x.get("_score",0), reverse=True)[:topk]

def cmd_vectorize(index_path: pathlib.Path) -> None:
    """TF-IDFベクトル化を実行してベクトルファイルを生成"""
    if not SKLEARN_OK:
        print("scikit-learn未導入。pip install scikit-learn joblib")
        return
    index = load_index(index_path)
    max_text_len = PROCESSING_CONSTANTS['text_truncate_vectorize']
    texts = [d.get("text","")[:max_text_len] for d in index]
    max_features = PROCESSING_CONSTANTS['tfidf_max_features']
    vec = TfidfVectorizer(max_features=max_features, ngram_range=(1,2), stop_words=None)
    mat = vec.fit_transform(texts)
    joblib.dump(vec, VEC_PATH); joblib.dump(mat, MATRIX_PATH)
    print(f"[OK] Vectorized -> {VEC_PATH}, {MATRIX_PATH}")

# ===== Advice rules =====
def rule_advices(d: Dict[str,Any]) -> List[str]:
    max_text_len = PROCESSING_CONSTANTS['text_truncate_analysis']
    text = d.get("text", "")[:max_text_len]
    lang = d.get("lang", "")
    out: List[str] = []

    # 共通のスキャン
    out += scan_money(text)
    out += scan_print(text)
    out += scan_ui(text)
    out += scan_db(text)

    # 言語固有のスキャン
    if lang == "go":
        out += scan_go(text)
        out += scan_solid_go(text)
    elif lang in ("cpp", "c"):
        out += scan_cpp(text)
    elif lang == "php":
        out += scan_php(text)
        out += scan_solid_php(text)
    elif lang == "csharp":
        out += scan_solid_csharp(text)
    elif lang == "java":
        out += scan_solid_java(text)
    elif lang in ("javascript", "typescript"):
        out += scan_solid_javascript_typescript(text)
        out += scan_angular(text)  # Angular検査

    max_tags = PROCESSING_CONSTANTS['top_tags_count']
    return out[:max_tags]  # 上位N個のタグを返す（SOLID+Angular含む）

# ===== 重要度スコア計算 =====
def calculate_severity_score(suspicions: List[str]) -> int:
    """問題リストから重要度スコアを計算"""
    total_score = 0
    for suspicion in suspicions:
        # 完全一致またはデフォルトスコア
        total_score += SEVERITY_SCORES.get(suspicion, 1)
    return total_score

def make_advice_entry_with_severity(d: Dict[str,Any]) -> Dict[str,Any]:
    """重要度スコア付きのエントリを作成"""
    suspicions = rule_advices(d)
    severity_score = calculate_severity_score(suspicions)

    return {
        "path": d["path"],
        "lang": d["lang"],
        "score": round(d.get("_score",0.0),4),
        "tags": d.get("tags",[]),
        "suspicions": suspicions,
        "severity_score": severity_score,  # 重要度スコア追加
        "severity_level": get_severity_level(severity_score)  # 重要度レベル追加
    }

def get_severity_level(score: int) -> str:
    """スコアから重要度レベルを判定"""
    if score >= 15:
        return "[緊急]"  # エモジ除去
    elif score >= 10:
        return "[高]"
    elif score >= 5:
        return "[中]"
    elif score >= 1:
        return "[低]"
    else:
        return "[問題なし]"

# ===== GPT-5 =====
# ===== AI Provider Selection =====
def get_ai_provider() -> Optional[str]:
    """
    AIプロバイダーを決定 (openai/anthropic/None)
    環境変数 AI_PROVIDER に基づいて選択:
      - auto: Anthropic優先、OpenAIフォールバック
      - anthropic: Anthropic Claude only
      - openai: OpenAI only
    """
    provider = os.environ.get("AI_PROVIDER", "auto").lower().strip()

    if provider == "auto":
        # Anthropic優先
        if ANTHROPIC_OK and os.environ.get("ANTHROPIC_API_KEY"):
            return "anthropic"
        elif OPENAI_OK and os.environ.get("OPENAI_API_KEY"):
            return "openai"
    elif provider == "anthropic":
        if ANTHROPIC_OK and os.environ.get("ANTHROPIC_API_KEY"):
            return "anthropic"
        print("[WARNING] ANTHROPIC_API_KEY not set or anthropic package not installed")
    elif provider == "openai":
        if OPENAI_OK and os.environ.get("OPENAI_API_KEY"):
            return "openai"
        print("[WARNING] OPENAI_API_KEY not set or openai package not installed")

    return None

def get_claude_model_priority() -> List[str]:
    """
    Claude モデル優先順位を取得
    環境変数 ANTHROPIC_MODEL で指定されたモデルを最優先し、
    デフォルトの優先順位でフォールバック
    """
    custom_model = os.environ.get("ANTHROPIC_MODEL", "").strip()
    default_priority = ["claude-sonnet-4-5", "claude-opus-4-1", "claude-sonnet-4-1"]

    if custom_model:
        # カスタムモデルを最優先、次にデフォルト優先順位
        models = [custom_model]
        for m in default_priority:
            if m != custom_model:
                models.append(m)
        return models

    return default_priority

def call_claude_api(prompt: str, api_key: str, models: Optional[List[str]] = None) -> Optional[str]:
    """
    Anthropic Claude API呼び出し（フォールバック付き）

    Args:
        prompt: 分析プロンプト
        api_key: Anthropic APIキー
        models: モデル優先順位リスト（Noneの場合はget_claude_model_priority()を使用）

    Returns:
        AI分析結果テキスト、または失敗時はNone
    """
    if not ANTHROPIC_OK:
        print("[ERROR] anthropic package not installed. Run: pip install anthropic")
        return None

    from anthropic import Anthropic

    if models is None:
        models = get_claude_model_priority()

    client = Anthropic(api_key=api_key)

    for model in models:
        try:
            print(f"[INFO] Calling Claude API with model: {model}")

            response = client.messages.create(
                model=model,
                max_tokens=4096,
                temperature=0.3,
                messages=[
                    {"role": "user", "content": prompt}
                ]
            )

            # レスポンス構造確認
            if response.content and len(response.content) > 0:
                # Anthropic APIは content リストを返す
                text = response.content[0].text.strip()
                if text:
                    print(f"[SUCCESS] Got {len(text)} chars from {model}")
                    return text
                else:
                    print(f"[WARNING] {model} returned empty text")
            else:
                print(f"[WARNING] {model} returned no content")

        except Exception as e:
            error_msg = str(e)
            # セキュリティ: APIキーや機密情報を含む可能性のある文字列をマスク
            sanitized_msg = re.sub(r'sk-ant-[a-zA-Z0-9_-]+', '***MASKED***', error_msg)
            sanitized_msg = re.sub(r'Bearer [a-zA-Z0-9_.-]+', 'Bearer ***MASKED***', sanitized_msg)
            max_len = PROCESSING_CONSTANTS['error_msg_max_length_extended']
            print(f"[WARNING] {model} failed: {sanitized_msg[:max_len]}")

            # エラー内容に基づく診断
            if "401" in error_msg or "authentication" in error_msg.lower():
                print("[INFO] Error 401 - Check ANTHROPIC_API_KEY")
            elif "404" in error_msg or "not_found" in error_msg.lower():
                print(f"[INFO] Error 404 - Model {model} may not be available")
            elif "rate_limit" in error_msg.lower():
                print("[INFO] Rate limit - Waiting 60 seconds...")
                time.sleep(60)
                continue  # リトライ

            continue  # 次のモデルへフォールバック

    print("[ERROR] All Claude models failed")
    return None

def call_gpt5_codex_responses_api(prompt: str, api_key: str, model: str = "gpt-5-codex") -> str:
    """
    GPT-5-Codex Responses API (/v1/responses) を使用
    公式ドキュメントに基づく正しい実装
    """
    try:
        from openai import OpenAI

        # OpenAI公式クライアントを使用
        client = OpenAI(api_key=api_key)

        # inputパラメータは必須
        if not prompt or not prompt.strip():
            print("[WARNING] Input prompt is empty, using default prompt")
            prompt = "# Write a simple hello world function"

        print(f"[INFO] Calling GPT-5-Codex via Responses API with {len(prompt)} chars input")

        # 公式ドキュメントの形式に従う
        response = client.responses.create(
            model=model,
            input=prompt,
            reasoning={"effort": "high"}  # リファクタリングや複雑な解析向け
        )

        # レスポンス構造の解析（テスト結果から判明した実際の構造）
        # 1. まず直接output_textを確認（OpenAIクライアントの場合）
        if hasattr(response, 'output_text'):
            output = response.output_text
            if output and output.strip():
                print(f"[SUCCESS] Got response from output_text: {len(output)} chars")
                return output.strip()

        # 2. outputフィールドを確認（HTTP直接呼び出しの場合の構造）
        if hasattr(response, 'output') and response.output:
            for item in response.output:
                if item.get('type') == 'message' and 'content' in item:
                    for content in item['content']:
                        if content.get('type') == 'output_text':
                            text = content.get('text', '')
                            if text and text.strip():
                                print(f"[SUCCESS] Got response from nested structure: {len(text)} chars")
                                return text.strip()

        print(f"[WARNING] Could not extract text from response structure")

    except Exception as e:
        error_msg = str(e)
        # セキュリティ: OpenAI APIキーや機密情報をマスク
        sanitized_msg = re.sub(r'sk-[a-zA-Z0-9_-]{20,}', '***MASKED***', error_msg)
        sanitized_msg = re.sub(r'Bearer [a-zA-Z0-9_.-]+', 'Bearer ***MASKED***', sanitized_msg)
        max_len = PROCESSING_CONSTANTS['error_msg_max_length_long']
        print(f"[ERROR] Responses API call failed: {sanitized_msg[:max_len]}")

        # エラー内容に基づく詳細診断
        if "400" in error_msg or "invalid_request_error" in error_msg:
            print("[INFO] Error 400 - Check: input not empty, model name correct, valid JSON")
        elif "401" in error_msg:
            print("[INFO] Error 401 - Check API key authentication")
        elif "404" in error_msg:
            print("[INFO] Error 404 - Model may not be available yet")

    # フォールバック処理は呼び出し元で行う
    return None

def ai_review(query: str, snippets: List[str]) -> str:
    """
    マルチプロバイダー対応AI分析関数
    Anthropic Claude または OpenAI を使用してコードレビューを実行
    """
    # プロバイダー決定
    provider = get_ai_provider()

    if not provider:
        return "(AI未有効: APIキー未設定またはSDK未導入)"

    # プロンプト構築（共通）
    prompt = (
        "ユーザー報告: \n" +
        json.dumps(query, ensure_ascii=False) +
        "\n次のコード断片を根拠に、(1)金額 (2)印刷 (3)UI/UX (4)DB負荷 を重点に助言だけを出してください。\n" +
        "確度が低い指摘は『可能性』と明記。修正コードは出力しない。\n=== 候補コード ===\n" +
        json.dumps(snippets, ensure_ascii=False)[:PROCESSING_CONSTANTS['ai_prompt_max_length']]
    )

    print(f"[INFO] 使用AIプロバイダー: {provider}")

    # ===== Anthropic Claude 実行 =====
    if provider == "anthropic":
        api_key = os.environ.get("ANTHROPIC_API_KEY")
        models = get_claude_model_priority()

        result = call_claude_api(prompt, api_key, models)

        if result:
            return result

        # Claudeが失敗した場合、OpenAIへフォールバック
        if OPENAI_OK and os.environ.get("OPENAI_API_KEY"):
            print("[INFO] Claude failed, falling back to OpenAI")
            provider = "openai"
        else:
            return "(AI分析失敗: Claude APIエラー、OpenAIフォールバックなし)"

    # ===== OpenAI 実行 =====
    if provider == "openai":
        if not OPENAI_OK:
            return "(AI未有効: openai未導入)"
        api_key = os.environ.get("OPENAI_API_KEY")
        if not api_key:
            return "(AI未有効: OPENAI_API_KEY 未設定)"

        # 環境変数からモデルを取得（デフォルト: gpt-4o）
        # 利用可能: gpt-5-codex, gpt-5, gpt-5-mini, gpt-5-nano, gpt-4o（推奨）
        model = os.environ.get("OPENAI_MODEL", "gpt-4o")
        client = OpenAI(api_key=api_key)

        print(f"[INFO] 使用モデル: {model}")

        # GPT-5-Codex用のシステムメッセージ
        system_content = "You are a senior code reviewer specializing in identifying performance issues, security vulnerabilities, and code quality problems. Focus on practical, actionable advice."

        # GPT-5-CodexはResponses API使用
        if "gpt-5-codex" in model.lower():
            result = call_gpt5_codex_responses_api(prompt, api_key, model)
            if result:
                return result
            # Responses APIが失敗した場合はgpt-4oにフォールバック
            print("[INFO] Falling back to gpt-4o due to Responses API failure")
            model = "gpt-4o"

    try:
        # API呼び出しパラメータ準備
        messages = [
            {"role": "system", "content": system_content},
            {"role": "user", "content": prompt}
        ]

        params = {
            "model": model,
            "messages": messages,
            "timeout": AI_TIMEOUT
        }

        # モデル別パラメータ設定（空レスポンス対策強化）
        if False:  # gpt-5-codexは上で処理済み
            # GPT-5-Codex専用パラメータ
            params["temperature"] = 0.3  # やや高めに調整（0.2→0.3）
            params["max_output_tokens"] = 4000  # 十分な出力トークン数
            params["max_tokens"] = 4000  # フォールバック
            params["verbosity"] = "medium"  # lowだと空になりやすいため
            params["reasoning_effort"] = "medium"  # minimalは空レスポンスリスク
            params["presence_penalty"] = 0.1  # 控えめに
            params["response_format"] = {"type": "text"}  # 明示的にテキスト形式指定
            params["seed"] = 42
        elif "gpt-5" in model:
            # GPT-5系の共通設定（空レスポンス対策）
            params["temperature"] = 0.7  # 1.0は制限があるため調整
            params["max_completion_tokens"] = 4000  # 増量
            params["max_output_tokens"] = 4000  # 念のため両方設定
            params["verbosity"] = "medium"
            params["reasoning_effort"] = "medium"
            params["response_format"] = {"type": "text"}
        else:
            # GPT-4o等の従来モデル
            params["temperature"] = 0.5
            params["max_tokens"] = 3000  # 増量

        # 最大3回まで再試行（パラメータ調整含む）
        max_retries = 3
        retry_count = 0

        while retry_count < max_retries:
            try:
                resp = client.chat.completions.create(**params)

                # レスポンス内容確認
                if resp.choices and resp.choices[0].message.content:
                    content = resp.choices[0].message.content.strip()
                    if content:  # 空文字でないことを確認
                        return content

                # 空レスポンスの場合
                print(f"[WARNING] {model}から空のレスポンスを受信（試行{retry_count + 1}/{max_retries}）")

                # パラメータ調整して再試行
                retry_count += 1
                if retry_count < max_retries:
                    if "gpt-5" in model:
                        # GPT-5系の調整
                        params["max_output_tokens"] = params.get("max_output_tokens", 2000) * 2
                        params["max_completion_tokens"] = params.get("max_completion_tokens", 2000) * 2
                        params["verbosity"] = "high"  # より詳細な出力を要求
                        params["reasoning_effort"] = "maximal"
                        # プロンプトに明示的な指示を追加
                        messages[-1]["content"] = messages[-1]["content"] + "\n\n必ず具体的な助言を出力してください。"
                        print(f"[INFO] パラメータ調整: max_output_tokens={params.get('max_output_tokens')}, verbosity=high")
                    else:
                        # GPT-4o等の調整
                        params["max_tokens"] = params.get("max_tokens", 2000) * 1.5
                        params["temperature"] = min(params.get("temperature", 0.5) + 0.2, 1.0)
                        print(f"[INFO] パラメータ調整: max_tokens={params.get('max_tokens')}, temperature={params.get('temperature')}")

                    # 少し待機
                    time.sleep(1)

            except Exception as e:
                error_msg = str(e)
                # セキュリティ: APIキーをマスク
                sanitized_msg = re.sub(r'sk-[a-zA-Z0-9_-]{20,}', '***MASKED***', error_msg)
                sanitized_msg = re.sub(r'Bearer [a-zA-Z0-9_.-]+', 'Bearer ***MASKED***', sanitized_msg)
                max_len = PROCESSING_CONSTANTS['error_msg_max_length']
                print(f"[ERROR] API呼び出しエラー（試行{retry_count + 1}）: {sanitized_msg[:max_len]}")
                retry_count += 1
                if retry_count < max_retries:
                    time.sleep(2)  # エラー時は長めに待機

        # 全試行失敗後、フォールバックモデルで最終試行
        fallback_model = "gpt-4o" if model != "gpt-4o" else "gpt-3.5-turbo"
        print(f"[INFO] 最終フォールバック: {fallback_model} で再試行中...")

        fallback_params = {
            "model": fallback_model,
            "messages": messages,
            "temperature": 0.7,
            "max_tokens": 3000,
            "timeout": AI_TIMEOUT
        }

        try:
            resp = client.chat.completions.create(**fallback_params)
            if resp.choices and resp.choices[0].message.content:
                content = resp.choices[0].message.content.strip()
                if content:
                    return content
        except Exception as e:
            error_msg = str(e)
            # セキュリティ: APIキーをマスク
            sanitized_msg = re.sub(r'sk-[a-zA-Z0-9_-]{20,}', '***MASKED***', error_msg)
            sanitized_msg = re.sub(r'Bearer [a-zA-Z0-9_.-]+', 'Bearer ***MASKED***', sanitized_msg)
            max_len = PROCESSING_CONSTANTS['error_msg_max_length']
            print(f"[ERROR] フォールバックも失敗: {sanitized_msg[:max_len]}")

        return "(AI応答: 複数回の試行後も空のレスポンス。手動レビューを推奨)"

    except Exception as e:
        error_msg = str(e)
        # セキュリティ: APIキーをマスク
        sanitized_msg = re.sub(r'sk-[a-zA-Z0-9_-]{20,}', '***MASKED***', error_msg)
        sanitized_msg = re.sub(r'Bearer [a-zA-Z0-9_.-]+', 'Bearer ***MASKED***', sanitized_msg)
        max_len = PROCESSING_CONSTANTS['error_msg_max_length']
        print(f"[ERROR] AI呼び出しエラー: {sanitized_msg[:max_len]}")
        return f"(AIエラー: {error_msg})"

# ===== Report (重要度順) =====
def render_report_sorted(title: str, items: List[Dict[str,Any]], ai_summary: str|None) -> str:
    lines: List[str] = [
        f"# {title}",
        "",
        f"生成: {time.strftime('%Y-%m-%d %H:%M:%S')} (読取専用)",
        ""
    ]

    if ai_summary:
        lines += ["## AIレビュー要約 (GPT-5)", "", ai_summary, ""]

    # 重要度でソート（高い順）
    sorted_items = sorted(items, key=lambda x: x.get('severity_score', 0), reverse=True)

    # 重要度別にグループ化
    critical_items = [it for it in sorted_items if it.get('severity_score', 0) >= 10]
    high_items = [it for it in sorted_items if 7 <= it.get('severity_score', 0) < 10]
    medium_items = [it for it in sorted_items if 4 <= it.get('severity_score', 0) < 7]
    low_items = [it for it in sorted_items if 1 <= it.get('severity_score', 0) < 4]
    no_issue_items = [it for it in sorted_items if it.get('severity_score', 0) == 0]

    # 統計情報
    lines += [
        "## 問題の分布",
        f"- 緊急: {len(critical_items)}件",
        f"- 高: {len(high_items)}件",
        f"- 中: {len(medium_items)}件",
        f"- 低: {len(low_items)}件",
        f"- 問題なし: {len(no_issue_items)}件",
        f"- **合計**: {len(items)}件",
        ""
    ]

    # 重要度別に出力
    if critical_items:
        lines.append("## [緊急] 緊急対応が必要な問題\n")
        for i, it in enumerate(critical_items, 1):
            lines += format_item(i, it)

    if high_items:
        lines.append("## [高] 高優先度の問題\n")
        for i, it in enumerate(high_items, len(critical_items) + 1):
            lines += format_item(i, it)

    if medium_items:
        lines.append("## [中] 中優先度の問題\n")
        for i, it in enumerate(medium_items, len(critical_items) + len(high_items) + 1):
            lines += format_item(i, it)

    if low_items:
        lines.append("## [低] 低優先度の問題\n")
        for i, it in enumerate(low_items, len(critical_items) + len(high_items) + len(medium_items) + 1):
            lines += format_item(i, it)

    if no_issue_items:
        lines.append("## [問題なし] 問題が検出されなかったファイル\n")
        for i, it in enumerate(no_issue_items, len(items) - len(no_issue_items) + 1):
            lines += format_item_minimal(i, it)

    return "\n".join(lines)

def format_item(num: int, item: Dict[str,Any]) -> List[str]:
    """問題ありアイテムのフォーマット"""
    lines = [
        f"### {num}. {item['path']}",
        f"- **言語**: {item['lang']}",
        f"- **重要度**: {item.get('severity_level', '不明')} (スコア: {item.get('severity_score', 0)})",
        f"- **検索スコア**: {item.get('score', 0)}",
        f"- **タグ**: {', '.join(item.get('tags', [])) or '-'}",
        "- **検出された問題**:"
    ]

    susp = item.get("suspicions", [])
    if susp:
        for s in susp:
            severity = SEVERITY_SCORES.get(s, 1)
            priority = "[緊急]" if severity >= 8 else "[高]" if severity >= 5 else "[中]" if severity >= 3 else "[低]"
            lines.append(f"  - {priority} {s}")
    else:
        lines.append("  - (なし)")

    lines.append("")
    return lines

def format_item_minimal(num: int, item: Dict[str,Any]) -> List[str]:
    """問題なしアイテムの簡潔なフォーマット"""
    return [
        f"### {num}. {item['path']} ({item['lang']})",
        f"- タグ: {', '.join(item.get('tags', [])) or '-'}",
        ""
    ]

# ===== Commands =====
def read_source_file(file_path: str) -> tuple[str, bool]:
    """
    ソースファイルの内容を読み込む
    
    Returns:
        (content, success): ファイル内容と成功フラグ
    """
    path = pathlib.Path(file_path)
    
    if not path.exists():
        error_msg = f"# エラー: ファイルが見つかりません\n# パス: {file_path}"
        return error_msg, False
    
    if path.stat().st_size > 5 * 1024 * 1024:  # 5MB制限
        size_mb = path.stat().st_size / 1024 / 1024
        error_msg = f"# エラー: ファイルサイズが大きすぎます ({size_mb:.1f}MB)\n# パス: {file_path}"
        return error_msg, False
    
    # エンコーディング検出と読み込み
    try:
        with open(path, 'rb') as f:
            raw_data = f.read()
        
        # chardetがあればエンコーディング検出
        try:
            import chardet
            detected = chardet.detect(raw_data)
            encoding = detected.get('encoding', 'utf-8') or 'utf-8'
        except ImportError:
            # chardetがない場合は一般的なエンコーディングを試行
            encoding = 'utf-8'
        
        # エンコーディングで読み込み試行
        for enc in [encoding, 'utf-8', 'shift_jis', 'cp932', 'euc-jp']:
            try:
                content = raw_data.decode(enc)
                return content, True
            except (UnicodeDecodeError, LookupError):
                continue
        
        # 全部失敗したら ignore モードで UTF-8
        content = raw_data.decode('utf-8', errors='ignore')
        return content, True
    except Exception as e:
        error_msg = f"# エラー: ファイル読み込み失敗\n# パス: {file_path}\n# 理由: {str(e)[:200]}"
        return error_msg, False

def generate_improved_code(file_path: str, original_code: str, suspicions: List[str], lang: str) -> str:
    """
    AIを使って改善コードを生成
    
    Args:
        file_path: ファイルパス
        original_code: 元のソースコード
        suspicions: 検出された問題リスト
        lang: プログラミング言語
    
    Returns:
        改善されたコード（またはエラーメッセージ）
    """
    if not suspicions:
        return "# 問題が検出されていないため、改善コードは生成されません"
    
    # 問題のサマリー作成
    issues_summary = "\n".join(f"- {s}" for s in suspicions[:10])  # 最大10件
    
    prompt = f"""以下の{lang}コードに対して、検出された問題を修正した改善版コードを生成してください。

## ファイル: {file_path}

## 検出された問題:
{issues_summary}

## 元のコード:
```{lang}
{original_code[:PROCESSING_CONSTANTS['ai_prompt_max_length']]}
```

## 要件:
1. 検出された問題を修正してください
2. 既存の機能を壊さないでください
3. コメントで変更箇所を説明してください
4. コードのみを出力し、説明文は不要です
5. 完全なコードを生成してください（一部だけでなく）

## 改善コード:
"""
    
    result = ai_review("改善コード生成", [prompt])
    
    if not result or len(result.strip()) < 50:
        return "# エラー: AI改善コード生成に失敗しました\n# 元のコードを確認して手動で修正してください"
    
    return result

def format_complete_report_item(num: int, item: Dict[str, Any], include_source: bool = True, generate_fix: bool = True) -> List[str]:
    """
    完全レポート用のアイテムフォーマット（元コード + 改善コード付き）
    
    Args:
        num: アイテム番号
        item: レポートアイテム
        include_source: 元コードを含めるか
        generate_fix: 改善コードを生成するか
    
    Returns:
        フォーマット済み行のリスト
    """
    lines = [
        f"### {num}. {item['path']}",
        f"- **言語**: {item['lang']}",
        f"- **重要度**: {item.get('severity_level', '不明')} (スコア: {item.get('severity_score', 0)})",
        f"- **タグ**: {', '.join(item.get('tags', [])) or '-'}",
        ""
    ]
    
    # 問題リスト
    susp = item.get("suspicions", [])
    if susp:
        lines.append("#### 検出された問題:")
        for s in susp:
            severity = SEVERITY_SCORES.get(s, 1)
            priority = "[緊急]" if severity >= 8 else "[高]" if severity >= 5 else "[中]" if severity >= 3 else "[低]"
            lines.append(f"- {priority} {s}")
        lines.append("")
    
    # 元コード読み込み
    if include_source and item.get('severity_score', 0) > 0:
        file_path = item['path']
        source_code, success = read_source_file(file_path)
        
        if success:
            lines.append("#### 元のソースコード:")
            lines.append(f"```{item['lang']}")
            lines.append(source_code[:20000])  # 最大20KB
            if len(source_code) > 20000:
                lines.append("... (以下省略)")
            lines.append("```")
            lines.append("")
            
            # 改善コード生成
            if generate_fix and susp:
                print(f"[INFO] AI改善コード生成中: {file_path}")
                improved_code = generate_improved_code(file_path, source_code, susp, item['lang'])
                
                lines.append("#### 改善されたソースコード:")
                lines.append(f"```{item['lang']}")
                lines.append(improved_code)
                lines.append("```")
                lines.append("")
                
                lines.append("#### 変更内容の説明:")
                lines.append("上記の改善コードでは以下の変更が行われています：")
                for s in susp[:5]:  # 主要な問題のみ
                    lines.append(f"- {s} への対応")
                lines.append("")
        else:
            lines.append("#### ソースコード読み込みエラー:")
            lines.append(f"```")
            lines.append(source_code)  # エラーメッセージ
            lines.append("```")
            lines.append("")
    
    lines.append("---")
    lines.append("")
    return lines

def save_progress_info(progress_file: str, current: int, total: int, current_file: str, status: str):
    """
    進捗情報をJSONファイルに保存（シグナルセーフ・アトミック）

    Args:
        progress_file: 進捗情報ファイルパス
        current: 現在の処理番号
        total: 全体の処理数
        current_file: 現在処理中のファイル名
        status: 処理状態（processing/completed/error）
    """
    # シグナルをブロックして競合状態を防ぐ
    old_sigint = signal.signal(signal.SIGINT, signal.SIG_IGN)
    old_sigterm = None
    if hasattr(signal, 'SIGTERM'):
        old_sigterm = signal.signal(signal.SIGTERM, signal.SIG_IGN)

    try:
        progress_data = {
            "timestamp": time.strftime('%Y-%m-%d %H:%M:%S'),
            "current": current,
            "total": total,
            "percentage": round(current / total * 100, 2) if total > 0 else 0,
            "current_file": current_file,
            "status": status,
            "estimated_remaining": None
        }

        progress_path = pathlib.Path(progress_file)
        progress_path.parent.mkdir(parents=True, exist_ok=True)

        # 既存の進捗情報を読み込んで時間推定
        if progress_path.exists():
            try:
                with open(progress_path, 'r', encoding='utf-8') as f:
                    old_data = json.load(f)
                    if old_data.get('current', 0) > 0:
                        # 処理時間推定
                        start_time = old_data.get('start_time')
                        if start_time and current > 0:
                            elapsed = time.time() - start_time
                            avg_time = elapsed / current
                            remaining = (total - current) * avg_time
                            progress_data['estimated_remaining'] = int(remaining)
            except:
                pass

        # 開始時刻を保持
        if current == 1:
            progress_data['start_time'] = time.time()
        elif progress_path.exists():
            try:
                with open(progress_path, 'r', encoding='utf-8') as f:
                    old_data = json.load(f)
                    progress_data['start_time'] = old_data.get('start_time', time.time())
            except:
                progress_data['start_time'] = time.time()

        # アトミック書き込み（temp_file変数のスコープを拡張）
        temp_file = None
        try:
            temp_file = str(progress_path) + ".tmp"
            with open(temp_file, 'w', encoding='utf-8') as f:
                json.dump(progress_data, f, ensure_ascii=False, indent=2)

            # 置き換え成功 → temp_fileをクリア（finally節でクリーンアップ不要）
            if progress_path.exists():
                progress_path.unlink()
            pathlib.Path(temp_file).rename(progress_path)
            temp_file = None  # リネーム成功したのでクリーンアップ不要

        except Exception as e:
            print(f"[WARNING] 進捗情報書き込み失敗: {str(e)[:100]}")

    except Exception as e:
        print(f"[WARNING] 進捗情報保存失敗: {str(e)[:100]}")

    finally:
        # temp_fileのクリーンアップ（リネーム失敗時のみ）
        if temp_file is not None and os.path.exists(temp_file):
            try:
                os.remove(temp_file)
            except Exception:
                pass

        # シグナルハンドラーを復元
        signal.signal(signal.SIGINT, old_sigint)
        if old_sigterm is not None:
            signal.signal(signal.SIGTERM, old_sigterm)

def render_complete_report(title: str, items: List[Dict[str, Any]], ai_summary: str | None,
                          max_items: int = 100, include_source: bool = True,
                          generate_fix: bool = True, progress_file: str = None,
                          output_file: pathlib.Path = None) -> str:
    """
    完全レポート生成（元コード + 改善コード付き）

    Args:
        title: レポートタイトル
        items: レポートアイテムリスト
        ai_summary: AI要約
        max_items: 処理する最大アイテム数（大量ファイル対策）
        include_source: 元コードを含めるか
        generate_fix: 改善コードを生成するか

    Returns:
        完全なレポート文字列
    """
    print(f"\n{'='*80}")
    print(f"完全レポート生成開始")
    print(f"{'='*80}")
    print(f"[INFO] タイトル: {title}")
    print(f"[INFO] 総ファイル数: {len(items)}件")
    print(f"[INFO] 最大処理数: {max_items}件")
    print(f"[INFO] 元コード表示: {'有効' if include_source else '無効'}")
    print(f"[INFO] AI改善コード: {'有効' if generate_fix else '無効'}")
    print(f"{'='*80}\n")

    lines: List[str] = [
        f"# {title}",
        "",
        f"生成: {time.strftime('%Y-%m-%d %H:%M:%S')}",
        f"モード: 完全レポート（元コード + 改善コード付き）",
        ""
    ]
    
    if ai_summary:
        lines += ["## AIレビュー要約", "", ai_summary, ""]
    
    # 重要度でソート
    sorted_items = sorted(items, key=lambda x: x.get('severity_score', 0), reverse=True)
    
    # 重要度別にグループ化
    critical_items = [it for it in sorted_items if it.get('severity_score', 0) >= 10]
    high_items = [it for it in sorted_items if 7 <= it.get('severity_score', 0) < 10]
    medium_items = [it for it in sorted_items if 4 <= it.get('severity_score', 0) < 7]
    low_items = [it for it in sorted_items if 1 <= it.get('severity_score', 0) < 4]
    no_issue_items = [it for it in sorted_items if it.get('severity_score', 0) == 0]
    
    # 統計情報
    lines += [
        "## 問題の分布",
        f"- 緊急: {len(critical_items)}件",
        f"- 高: {len(high_items)}件",
        f"- 中: {len(medium_items)}件",
        f"- 低: {len(low_items)}件",
        f"- 問題なし: {len(no_issue_items)}件",
        f"- **合計**: {len(items)}件",
        "",
        f"## 処理制限",
        f"- 最大処理件数: {max_items}件（大量ファイル対策）",
        f"- 元コード表示: {'有効' if include_source else '無効'}",
        f"- 改善コード生成: {'有効' if generate_fix else '無効'}",
        ""
    ]
    
    # 重要度別に出力（上限あり）
    processed = 0
    
    if critical_items and processed < max_items:
        lines.append("## [緊急] 緊急対応が必要な問題")
        lines.append("")
        print(f"\n[INFO] ========================================")
        print(f"[INFO] 緊急対応が必要な問題: {len(critical_items)}件を処理中...")
        print(f"[INFO] ========================================")
        for i, it in enumerate(critical_items[:max_items - processed], 1):
            # 中断チェック
            if check_interrupt():
                print(f"\n[INFO] 中断が要求されました。現在の進捗を保存しています...", file=sys.stderr)
                lines.append("")
                lines.append(f"**注意: ユーザーによる中断 (Ctrl+C) - {processed}件処理済み**")
                lines.append("")
                break

            # 進捗保存（全体のカウンターを使用）
            if progress_file:
                save_progress_info(progress_file, processed + 1, max_items, it.get('path', 'unknown'), 'processing')

            print(f"[INFO] [{processed+1}/{max_items}] 処理中: {it.get('path', 'unknown')} (重要度: {it.get('severity_score', 0)})")
            lines += format_complete_report_item(i, it, include_source, generate_fix)
            processed += 1

            # インクリメンタル書き込み（10件ごと）- UTF-8 BOMなし
            if output_file and processed % 10 == 0:
                with open(output_file, 'w', encoding='utf-8', newline='\n') as f:
                    f.write("\n".join(lines))
            if processed >= max_items:
                lines.append(f"**注意: 処理制限({max_items}件)に達しました。残りの問題は基本レポートを参照してください。**")
                lines.append("")
                break

    if high_items and processed < max_items:
        lines.append("## [高] 高優先度の問題")
        lines.append("")
        print(f"\n[INFO] ========================================")
        print(f"[INFO] 高優先度の問題: {len(high_items)}件を処理中...")
        print(f"[INFO] ========================================")
        start_num = len(critical_items) + 1
        for i, it in enumerate(high_items[:max_items - processed], start_num):
            # 中断チェック
            if check_interrupt():
                print(f"\n[INFO] 中断が要求されました。現在の進捗を保存しています...", file=sys.stderr)
                lines.append("")
                lines.append(f"**注意: ユーザーによる中断 (Ctrl+C) - {processed}件処理済み**")
                lines.append("")
                break

            # 進捗保存
            if progress_file:
                save_progress_info(progress_file, processed + 1, max_items, it.get('path', 'unknown'), 'processing')

            print(f"[INFO] [{processed+1}/{max_items}] 処理中: {it.get('path', 'unknown')} (重要度: {it.get('severity_score', 0)})")
            lines += format_complete_report_item(i, it, include_source, generate_fix)
            processed += 1

            # インクリメンタル書き込み（10件ごと）- UTF-8 BOMなし
            if output_file and processed % 10 == 0:
                with open(output_file, 'w', encoding='utf-8', newline='\n') as f:
                    f.write("\n".join(lines))
            if processed >= max_items:
                lines.append(f"**注意: 処理制限({max_items}件)に達しました。残りの問題は基本レポートを参照してください。**")
                lines.append("")
                break

    if medium_items and processed < max_items:
        lines.append("## [中] 中優先度の問題（一部のみ表示）")
        lines.append("")
        print(f"\n[INFO] ========================================")
        print(f"[INFO] 中優先度の問題: {len(medium_items)}件中、{min(len(medium_items), max_items - processed)}件を処理中...")
        print(f"[INFO] ========================================")
        start_num = len(critical_items) + len(high_items) + 1
        for i, it in enumerate(medium_items[:max_items - processed], start_num):
            # 中断チェック
            if check_interrupt():
                print(f"\n[INFO] 中断が要求されました。現在の進捗を保存しています...", file=sys.stderr)
                lines.append("")
                lines.append(f"**注意: ユーザーによる中断 (Ctrl+C) - {processed}件処理済み**")
                lines.append("")
                break

            # 進捗保存
            if progress_file:
                save_progress_info(progress_file, processed + 1, max_items, it.get('path', 'unknown'), 'processing')

            print(f"[INFO] [{processed+1}/{max_items}] 処理中: {it.get('path', 'unknown')} (重要度: {it.get('severity_score', 0)})")
            lines += format_complete_report_item(i, it, include_source, generate_fix)
            processed += 1

            # インクリメンタル書き込み（10件ごと）- UTF-8 BOMなし
            if output_file and processed % 10 == 0:
                with open(output_file, 'w', encoding='utf-8', newline='\n') as f:
                    f.write("\n".join(lines))
            if processed >= max_items:
                lines.append(f"**注意: 処理制限({max_items}件)に達しました。残りの問題は基本レポートを参照してください。**")
                lines.append("")
                break
    
    # サマリーに残りの件数を表示
    if processed < len([it for it in sorted_items if it.get('severity_score', 0) > 0]):
        remaining = len([it for it in sorted_items if it.get('severity_score', 0) > 0]) - processed
        lines += [
            "",
            "## 処理されなかった問題",
            f"- 残り: {remaining}件",
            "- これらの問題は基本レポート（--complete-report を指定しない通常モード）で確認できます",
            ""
        ]

    # 完了時の進捗更新
    if progress_file:
        save_progress_info(progress_file, processed, max_items, "完了", 'completed')

    print(f"\n{'='*80}")
    print(f"完全レポート生成完了")
    print(f"{'='*80}")
    print(f"[INFO] 処理済みファイル数: {processed}件")
    print(f"[INFO] 緊急: {len(critical_items)}件")
    print(f"[INFO] 高: {len(high_items)}件")
    print(f"[INFO] 中: {len(medium_items)}件")
    if processed < len([it for it in sorted_items if it.get('severity_score', 0) > 0]):
        remaining = len([it for it in sorted_items if it.get('severity_score', 0) > 0]) - processed
        print(f"[INFO] 未処理: {remaining}件（基本レポートで確認可能）")
    print(f"{'='*80}\n")

    return "\n".join(lines)

def cmd_query(query: str, topk: int, mode: str, index_path: pathlib.Path, out: pathlib.Path|None):
    index = load_index(index_path)
    cands = retrieve(query, index, topk=topk)
    items = [make_advice_entry_with_severity(d) for d in cands]

    ai_summary = None
    if mode in ("ai","hybrid"):
        ai_summary = ai_review(query, [d["text"] for d in cands[:5]])

    rep = render_report_sorted(f"検索レポート: {query}", items, ai_summary)
    if out:
        out.parent.mkdir(parents=True, exist_ok=True)
        # UTF-8 BOMなしで書き込み（改行コードはLF）
        with open(out, 'w', encoding='utf-8', newline='\n') as f:
            f.write(rep)
        print(f"[OK] wrote {out}")
    else:
        print(rep)

def cmd_advise(topk: int, mode: str, index_path: pathlib.Path, out: pathlib.Path|None, use_all: bool = False,
               complete_report: bool = False, max_complete_items: int = 100, complete_all: bool = False):
    """
    全体助言コマンド

    Args:
        topk: 取得する上位ファイル数
        mode: 分析モード（static/ai/hybrid）
        index_path: インデックスファイルパス
        out: 出力先ファイルパス
        use_all: 全ファイル処理フラグ
        complete_report: 完全レポート生成フラグ（元コード+改善コード付き）
        max_complete_items: 完全レポート処理の最大件数
    """
    # シグナルハンドラーを設定（Ctrl+C対応）
    setup_signal_handlers()

    seed_query = "金額 不整合 税 小数 印刷 Print HasMorePages NewPage UI UX アクセシビリティ DB N+1 JOIN 遅い"
    index = load_index(index_path)

    # --all オプションが指定された場合は全ファイルを対象にする
    if use_all:
        topk = len(index)
        print(f"[INFO] --all オプション: 全{topk}ファイルを分析します")
    
    # --complete-all オプション: 問題のあるファイル全件を完全レポート
    if complete_all:
        complete_report = True
        use_all = True
        topk = len(index)  # ここで topk を設定
        # 問題のあるファイル数を取得して設定
        temp_items = [make_advice_entry_with_severity(d) for d in retrieve(seed_query, index, topk=topk)]
        problem_count = len([it for it in temp_items if it.get('severity_score', 0) > 0])
        max_complete_items = problem_count
        print(f"[INFO] --complete-all オプション: 問題のある全{problem_count}ファイルを完全レポート生成")
        print(f"[WARNING] 処理に数時間かかる可能性があります")
    elif complete_report:
        print(f"[INFO] 完全レポートモード: 最大{max_complete_items}件の元コード+改善コード生成")

    cands = retrieve(seed_query, index, topk=topk)
    items = [make_advice_entry_with_severity(d) for d in cands]

    ai_summary = None
    if mode in ("ai","hybrid"):
        ai_summary = ai_review("横断助言（金額/印刷/UI/DB）", [d["text"] for d in cands[:5]])

    # 完全レポートまたは通常レポートを生成
    if complete_report:
        # 進捗ファイルパス
        progress_file = "reports/.complete_progress.json" if out else None
        
        rep = render_complete_report(
            "全体助言（横断チェック） - 完全レポート", 
            items, 
            ai_summary,
            max_items=max_complete_items,
            include_source=True,
            generate_fix=True,
            progress_file=progress_file,
            output_file=out
        )
    else:
        rep = render_report_sorted("全体助言（横断チェック）", items, ai_summary)

    if out:
        out.parent.mkdir(parents=True, exist_ok=True)
        # UTF-8 BOMなしで書き込み（改行コードはLF）
        with open(out, 'w', encoding='utf-8', newline='\n') as f:
            f.write(rep)
        print(f"[OK] wrote {out}")
    else:
        print(rep)

def cmd_clean() -> None:
    """生成物をクリーンアップする"""
    files_to_remove = [
        ".advice_index.jsonl",
        ".advice_index.meta.json",
        ".advice_tfidf.pkl",
        ".advice_matrix.pkl"
    ]

    removed = []
    for file_name in files_to_remove:
        file_path = pathlib.Path(file_name)
        if file_path.exists():
            try:
                file_path.unlink()
                removed.append(file_name)
                print(f"[OK] 削除: {file_name}")
            except Exception as e:
                print(f"[ERROR] 削除失敗: {file_name} - {e}")

    # reportsディレクトリの確認
    reports_dir = pathlib.Path("reports")
    if reports_dir.exists() and reports_dir.is_dir():
        try:
            # ログファイルのみ削除（.mdファイルは保持）
            log_files = list(reports_dir.glob("*.log")) + list(reports_dir.glob("*.csv")) + list(reports_dir.glob("*.jsonl"))
            for log_file in log_files:
                try:
                    log_file.unlink()
                    removed.append(log_file.name)
                    print(f"[OK] 削除: {log_file.name}")
                except Exception as e:
                    print(f"[ERROR] 削除失敗: {log_file.name} - {e}")
        except Exception as e:
            print(f"[ERROR] reportsディレクトリのクリーンアップ失敗: {e}")

    if removed:
        print(f"\n[SUMMARY] {len(removed)}個のファイルを削除しました")
    else:
        print("[INFO] 削除するファイルがありませんでした")

# ===== CLI =====
if __name__ == "__main__":
    ap = argparse.ArgumentParser(
        description="読取専用レビュー（重要度順ソート版）",
        formatter_class=argparse.RawDescriptionHelpFormatter,
        epilog="""
使用例:
  # デフォルトディレクトリ ./src をインデックス化
  python codex_review_severity.py index

  # 特定ディレクトリをインデックス化
  python codex_review_severity.py index /path/to/source

  # --src-dirオプションを使用（repoと排他的）
  python codex_review_severity.py index --src-dir /path/to/source

  # AI分析を実行（全ファイル）
  python codex_review_severity.py advise --all --out reports/review.md
        """
    )
    sub = ap.add_subparsers(dest="cmd", required=True)

    ap_idx = sub.add_parser(
        "index",
        help="リポジトリをインデックス化（読取のみ）",
        description="ソースコードをスキャンしてインデックスを作成します"
    )
    ap_idx.add_argument(
        "repo",
        type=str,
        nargs="?",
        default="./src",
        help="リポジトリパス（デフォルト: ./src）。--src-dirと同時指定不可"
    )
    ap_idx.add_argument(
        "--src-dir",
        type=str,
        default=None,
        metavar="DIR",
        help="ソースディレクトリを明示的に指定（repoと排他的）"
    )
    ap_idx.add_argument("--exclude-langs", type=str, nargs="*", help="除外する言語 (例: delphi java)")
    ap_idx.add_argument("--max-file-mb", type=float, default=4.0, help="最大ファイルサイズ(MB) デフォルト4MB")
    ap_idx.add_argument("--profile-index", action="store_true", help="インデックス処理のプロファイル情報を出力")
    ap_idx.add_argument("--profile-output", type=str, default=None, help="プロファイル結果を書き出すファイル（.csv / .jsonl）")
    ap_idx.add_argument("--batch-size", type=int, default=BATCH_SIZE_DEFAULT, help="ファイル書き出しのバッチ件数（既定500、0で無効）")
    ap_idx.add_argument("--max-files", type=int, default=None, help="処理する最大ファイル数")
    ap_idx.add_argument("--max-seconds", type=float, default=None, help="処理を打ち切る最大秒数")
    ap_idx.add_argument("--include", nargs="*", help="インデックス対象とするパターン（glob）")
    ap_idx.add_argument("--exclude", nargs="*", help="インデックスから除外するパターン（glob）")
    ap_idx.add_argument("--worker-count", type=int, default=0, help="ファイル読み込みに使うワーカー数（0で無効）")

    ap_vec = sub.add_parser("vectorize", help="(任意) TF-IDFベクトル生成")
    ap_vec.add_argument("--index", type=str, default=INDEX_PATH)

    ap_q = sub.add_parser("query", help="自然言語で関連ソースを探索（重要度順）")
    ap_q.add_argument("query", type=str, help="検索クエリ")
    ap_q.add_argument("--topk", type=int, default=30, help="検索上位N件")
    ap_q.add_argument("--mode", choices=["rules","ai","hybrid"], default="hybrid")
    ap_q.add_argument("--index", type=str, default=INDEX_PATH)
    ap_q.add_argument("--out", type=str, help="出力ファイル (Markdown)")

    ap_adv = sub.add_parser("advise", help="全体助言（重要度順）")
    ap_adv.add_argument("--topk", type=int, default=80, help="助言対象上位N件（デフォルト: 80）")
    ap_adv.add_argument("--all", action="store_true", help="全インデックスファイルを分析（--topkを上書き）")
    ap_adv.add_argument("--mode", choices=["rules","ai","hybrid"], default="hybrid")
    ap_adv.add_argument("--index", type=str, default=INDEX_PATH)
    ap_adv.add_argument("--out", type=str, help="出力ファイル (Markdown)")
    ap_adv.add_argument("--complete-report", action="store_true", help="完全レポート生成（元コード+改善コード付き）")
    ap_adv.add_argument("--max-complete-items", type=int, default=100, help="完全レポート処理の最大件数（デフォルト: 100）")
    ap_adv.add_argument("--complete-all", action="store_true", help="問題のある全ファイルを完全レポート（--all + --complete-report + 全件処理）")

    ap_clean = sub.add_parser("clean", help="生成物をクリーンアップ")

    args = ap.parse_args()
    if args.cmd == "index":
        # --src-dirとrepoの排他的検証
        if args.src_dir and args.repo != "./src":
            print("エラー: repo と --src-dir を同時に指定できません", file=sys.stderr)
            sys.exit(1)

        # --src-dirが指定されていればそれを使用、なければrepoを使用
        repo_path = args.src_dir if args.src_dir else args.repo

        # セキュリティ: パストラバーサル対策（".."を含むパスを拒否）
        if ".." in repo_path or repo_path.startswith("../"):
            print(f"エラー: 安全でないパス（親ディレクトリへのアクセス不可）: {repo_path}", file=sys.stderr)
            sys.exit(1)

        # 警告: ルートディレクトリ全体をスキャンしようとしている場合
        if repo_path in (".", "./", ".\\"):
            print("\n⚠️  [WARNING] ルートディレクトリ全体をスキャンします", file=sys.stderr)
            print(f"    指定パス: {repo_path}", file=sys.stderr)
            cwd_preview = pathlib.Path.cwd().resolve()
            print(f"    対象: {cwd_preview}", file=sys.stderr)
            print(f"\n    ./src のみをスキャンする場合は、引数を省略してください:", file=sys.stderr)
            print(f"    py codex_review_severity.py index\n", file=sys.stderr)

            # 対話的確認（CI環境では自動でスキップ）
            if sys.stdin.isatty():
                try:
                    confirm = input("続行しますか？ (yes/NO): ")
                    if confirm.lower() not in ("yes", "y"):
                        print("キャンセルしました", file=sys.stderr)
                        sys.exit(0)
                except (EOFError, KeyboardInterrupt):
                    print("\nキャンセルしました", file=sys.stderr)
                    sys.exit(0)
            else:
                print("    [INFO] 非対話モード（CI環境）のため自動で続行します\n", file=sys.stderr)

        repo = pathlib.Path(repo_path).resolve()

        # セキュリティ: 絶対パス解決後にカレントディレクトリ外へのアクセスチェック
        cwd = pathlib.Path.cwd().resolve()
        try:
            repo.relative_to(cwd)
        except ValueError:
            # カレントディレクトリの外部へのアクセスは警告（絶対パス指定時）
            if not repo.is_absolute():
                print(f"エラー: カレントディレクトリ外へのアクセスは拒否されました: {repo}", file=sys.stderr)
                sys.exit(1)

        # ディレクトリ存在確認
        if not repo.exists():
            print(f"エラー: ディレクトリが存在しません: {repo}", file=sys.stderr)
            sys.exit(1)

        if not repo.is_dir():
            print(f"エラー: ディレクトリではありません: {repo}", file=sys.stderr)
            sys.exit(1)

        exclude_langs = set(args.exclude_langs) if args.exclude_langs else set()
        max_file_bytes = int(args.max_file_mb * 1_000_000)
        profile_output = pathlib.Path(args.profile_output) if args.profile_output else None
        cmd_index(
            repo,
            pathlib.Path(INDEX_PATH),
            exclude_langs,
            max_file_bytes,
            profile=args.profile_index,
            profile_output=profile_output,
            batch_size=args.batch_size,
            max_files=args.max_files,
            max_seconds=args.max_seconds,
            include_patterns=args.include,
            exclude_patterns=args.exclude,
            worker_count=args.worker_count,
        )
    elif args.cmd == "vectorize":
        cmd_vectorize(pathlib.Path(args.index))
    elif args.cmd == "query":
        out = pathlib.Path(args.out) if args.out else None
        # .md拡張子を確実にする
        if out and not out.suffix.lower() == '.md':
            out = out.with_suffix('.md')
        cmd_query(args.query, args.topk, args.mode, pathlib.Path(args.index), out)
    elif args.cmd == "advise":
        out = pathlib.Path(args.out) if args.out else None
        # .md拡張子を確実にする
        if out and not out.suffix.lower() == '.md':
            out = out.with_suffix('.md')
        cmd_advise(
            args.topk, 
            args.mode, 
            pathlib.Path(args.index), 
            out, 
            args.all,
            complete_report=args.complete_report,
            max_complete_items=args.max_complete_items,
            complete_all=args.complete_all
        )
    elif args.cmd == "clean":
        cmd_clean()

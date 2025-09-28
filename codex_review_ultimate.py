#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
codex_review_ultimate.py — 最終版：2段階解析システム

処理フロー:
  1) ルールベースで全ファイルを高速解析
  2) 重要度の高い問題を持つファイルをAIで詳細解析（1ファイルずつ）
  3) 2種類のレポート生成（ルールベース版 / AI改善案付き版）

主な特徴:
  - エンコーディング自動検出
  - 進捗表示（XX/YYファイル処理中）
  - タイムアウト対策（個別処理、リトライ機能）
  - 具体的な改善コード例の提示

pip install chromadb openai scikit-learn joblib regex chardet
"""
from __future__ import annotations
import argparse, hashlib, json, os, pathlib, re, sys, time
from collections import defaultdict
from dataclasses import dataclass, asdict, field
from fnmatch import fnmatch
from typing import Any, Dict, List, Tuple, Optional
import chardet
from datetime import datetime

# ===== Config =====
IGNORE_DIRS = {".git","node_modules","dist","build","out","bin","obj",".idea",".vscode",".next","coverage","target",".venv","venv","env","lib64","lib","__pycache__",".mypy_cache",".pytest_cache",".tox"}
DEFAULT_MAX_FILE_BYTES = 4_000_000
ENV_FILE = ".env"
INDEX_PATH = ".advice_index.jsonl"
VEC_PATH = ".advice_tfidf.pkl"
MATRIX_PATH = ".advice_matrix.pkl"
AI_TIMEOUT = 60  # 個別ファイルのタイムアウト
AI_MAX_RETRIES = 2  # AIリトライ回数
AI_MIN_SEVERITY = 7  # AI解析する最小重要度スコア
AI_MAX_FILES = 20  # AI解析する最大ファイル数
BATCH_SIZE_DEFAULT = 500

# 重要度スコア定義
SEVERITY_SCORES = {
    "DB: ループ内SELECT (N+1) 疑い": 10,
    "DB: SELECT * →負荷増。列限定": 8,
    "DB: 多重JOIN→遅延の恐れ。計画/IDX確認": 7,
    "DB: 大OFFSET→遅延。IDカーソル推奨": 6,
    "金額: 浮動小数で金額→誤差。Decimal/通貨型へ": 9,
    "金額: 税込/税抜・端数処理の混在注意": 7,
    "UI: XSS脆弱性の疑い（未サニタイズHTML）": 8,
    "UI: 入力検証が不十分": 5,
    "UI: 多重クリック防止なし": 3,
    "印刷: エラー処理なし→途中停止リスク": 4,
    "印刷: 改ページ判定が不十分": 2,
}

# ===== Optional deps =====
SKLEARN_OK = False
try:
    from sklearn.feature_extraction.text import TfidfVectorizer
    import joblib
    SKLEARN_OK = True
except:
    pass

OPENAI_OK = False
try:
    from openai import OpenAI
    OPENAI_OK = True
except:
    pass

# ===== Utils =====
if ENV_FILE and pathlib.Path(ENV_FILE).exists():
    with open(ENV_FILE, "r", encoding="utf-8") as f:
        for line in f:
            if "=" in line:
                key, val = line.strip().split("=", 1)
                os.environ[key] = val

@dataclass
class Doc:
    path: str
    lang: str
    size: int
    sha1: str
    tags: List[str]
    summary: str
    text: str
    encoding: str

@dataclass
class RuleResult:
    """ルールベース解析結果"""
    path: str
    full_path: str
    lang: str
    encoding: str
    severity_score: int
    severity_level: str
    issues: List[str]
    tags: List[str]
    sample_code: str = ""  # 問題箇所のコードサンプル
    suggested_fix: str = ""  # ルールベースの改善案

@dataclass
class AIResult:
    """AI解析結果"""
    path: str
    full_path: str
    analysis: str
    improvements: List[Dict[str, str]] = field(default_factory=list)
    error: Optional[str] = None


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
        skipped_errors = self.counts.get("skipped_errors", 0)
        skipped_filter = self.counts.get("skipped_filter", 0)
        limit_stop = self.counts.get("limit_stop", 0)
        timeout_stop = self.counts.get("timeout_stop", 0)
        avg_read = (self.timings.get("read", 0.0) / indexed) if indexed else 0.0
        return (
            f"[PROFILE] Indexed {indexed}/{seen} files in {total_elapsed:.2f}s\n"
            f"           read={self.timings.get('read', 0.0):.2f}s stat={self.timings.get('stat', 0.0):.2f}s write={self.timings.get('write', 0.0):.2f}s\n"
            f"           avg_read_per_file={avg_read*1000:.1f}ms large_skipped={skipped_large} filter_skipped={skipped_filter} errors={skipped_errors} limits={limit_stop} timeouts={timeout_stop}"
        )

    def to_rows(self) -> List[Dict[str, Any]]:
        if not self.enabled:
            return []
        return [{
            "total_seconds": time.perf_counter() - self.total_start,
            "indexed_files": self.counts.get("indexed", 0),
            "seen_files": self.counts.get("seen", 0),
            "skipped_large": self.counts.get("skipped_large", 0),
            "skipped_errors": self.counts.get("skipped_errors", 0),
            "skipped_filter": self.counts.get("skipped_filter", 0),
            "limit_stop": self.counts.get("limit_stop", 0),
            "timeout_stop": self.counts.get("timeout_stop", 0),
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

def detect_encoding(file_path: pathlib.Path) -> str:
    """ファイルのエンコーディングを自動検出"""
    try:
        with open(file_path, 'rb') as f:
            raw_data = f.read(10000)
            result = chardet.detect(raw_data)
            encoding = result['encoding']
            confidence = result.get('confidence', 0)

            if not encoding or confidence < 0.7:
                for enc in ['utf-8', 'shift_jis', 'cp932', 'euc-jp', 'iso-2022-jp']:
                    try:
                        with open(file_path, 'r', encoding=enc) as test_f:
                            test_f.read(1000)
                        return enc
                    except:
                        continue
                return 'utf-8'

            if encoding.lower() in ['cp932', 'shift_jis', 'shift-jis', 'sjis']:
                return 'cp932'

            return encoding.lower()
    except:
        return 'utf-8'

def read_file_with_encoding(file_path: pathlib.Path) -> Tuple[str, str]:
    """エンコーディングを自動検出してファイルを読み込み"""
    encoding = detect_encoding(file_path)

    try:
        with open(file_path, 'r', encoding=encoding, errors='ignore') as f:
            content = f.read()
        return content, encoding
    except:
        try:
            with open(file_path, 'rb') as f:
                raw_data = f.read()
            content = raw_data.decode(encoding, errors='ignore')
            return content, encoding
        except:
            return "", "unknown"

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
        with open(p, "rb") as f:
            return b"\x00" not in f.read(4096)
    except Exception:
        return False

def make_summary(text: str) -> str:
    lines = text.splitlines()[:10]
    return " / ".join(l.strip()[:80] for l in lines if l.strip())[:400]

# ===== Rule-based Analysis with Code Samples =====
def scan_money_with_sample(text: str) -> List[Tuple[str, str, str]]:
    """金額関連の問題を検出し、サンプルコードと改善案を返す"""
    results = []

    # 浮動小数点での金額計算
    pattern = r"(\b(?:float|double|real)\b.*\b(?:price|cost|money|amount|tax|total|sum|charge|fee|pay).*)"
    matches = re.finditer(pattern, text, re.IGNORECASE)
    for match in matches:
        sample = match.group(0)[:200]
        issue = "金額: 浮動小数で金額→誤差。Decimal/通貨型へ"
        fix = """
// Before:
float price = 100.0f;
float tax = price * 0.1f;  // 精度問題

// After:
decimal price = 100.0m;
decimal tax = price * 0.1m;  // 正確な計算"""
        results.append((issue, sample, fix))
        break  # 最初の1件のみ

    # 税計算の端数処理
    if re.search(r"\b(total|sum|amount)\s*=.*\+.*tax", text, re.IGNORECASE):
        pattern = r"(.*(?:total|sum|amount)\s*=.*\+.*tax.*)"
        match = re.search(pattern, text, re.IGNORECASE)
        if match:
            sample = match.group(0)[:200]
            issue = "金額: 税込/税抜・端数処理の混在注意"
            fix = """
// 統一した端数処理
decimal CalculateTotalWithTax(decimal price, decimal taxRate) {
    decimal tax = Math.Round(price * taxRate, 0, MidpointRounding.ToEven);
    return price + tax;
}"""
            results.append((issue, sample, fix))

    return results

def scan_db_with_sample(text: str) -> List[Tuple[str, str, str]]:
    """DB関連の問題を検出し、サンプルコードと改善案を返す"""
    results = []

    # SELECT * の使用
    pattern = r"(.*SELECT\s+\*\s+FROM.*)"
    matches = re.finditer(pattern, text, re.IGNORECASE)
    for match in matches:
        sample = match.group(0)[:200]
        issue = "DB: SELECT * →負荷増。列限定"
        fix = """
// Before:
SELECT * FROM Users WHERE id = @id

// After:
SELECT id, name, email FROM Users WHERE id = @id"""
        results.append((issue, sample, fix))
        break

    # N+1問題
    if re.search(r"(for|while|foreach).*\n.*\n.*\n.*(SELECT|INSERT|UPDATE|DELETE)", text, re.IGNORECASE):
        issue = "DB: ループ内SELECT (N+1) 疑い"
        sample = "ループ内でSQLクエリを実行している可能性"
        fix = """
// Before:
foreach(var userId in userIds) {
    var user = db.Query("SELECT * FROM Users WHERE id = " + userId);
}

// After:
var users = db.Query("SELECT * FROM Users WHERE id IN @userIds", new { userIds });"""
        results.append((issue, sample, fix))

    return results

def scan_ui_with_sample(text: str) -> List[Tuple[str, str, str]]:
    """UI関連の問題を検出し、サンプルコードと改善案を返す"""
    results = []

    # XSS脆弱性
    if re.search(r"(innerHTML\s*=|dangerouslySetInnerHTML)", text):
        issue = "UI: XSS脆弱性の疑い（未サニタイズHTML）"
        sample = "innerHTML または dangerouslySetInnerHTML の使用"
        fix = """
// Before:
element.innerHTML = userInput;

// After:
element.textContent = userInput;  // またはサニタイズ
element.innerHTML = DOMPurify.sanitize(userInput);"""
        results.append((issue, sample, fix))

    # 入力検証不足
    if re.search(r"(input|textarea|select)", text, re.IGNORECASE) and not re.search(r"(validate|pattern|required)", text, re.IGNORECASE):
        issue = "UI: 入力検証が不十分"
        sample = "入力フィールドに検証が見当たらない"
        fix = """
// 入力検証の追加
<input type="email" required pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,}$" />

// JSでの検証
if (!input.value.match(/^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,}$/i)) {
    showError("有効なメールアドレスを入力してください");
}"""
        results.append((issue, sample, fix))

    return results

def scan_print_with_sample(text: str) -> List[Tuple[str, str, str]]:
    """印刷関連の問題を検出し、サンプルコードと改善案を返す"""
    results = []

    if re.search(r"(PrintDocument|PrintPage)", text, re.IGNORECASE) and not re.search(r"(try|catch|error)", text, re.IGNORECASE):
        issue = "印刷: エラー処理なし→途中停止リスク"
        sample = "印刷処理にエラーハンドリングがない"
        fix = """
// Before:
printDocument.Print();

// After:
try {
    printDocument.Print();
} catch (Exception ex) {
    Logger.LogError($"印刷エラー: {ex.Message}");
    MessageBox.Show("印刷中にエラーが発生しました。");
}"""
        results.append((issue, sample, fix))

    return results

def analyze_with_rules(text: str) -> List[Tuple[str, str, str]]:
    """すべてのルールベース解析を実行"""
    all_results = []
    all_results.extend(scan_money_with_sample(text))
    all_results.extend(scan_db_with_sample(text))
    all_results.extend(scan_ui_with_sample(text))
    all_results.extend(scan_print_with_sample(text))
    return all_results

def make_tags(text: str) -> List[str]:
    t = []
    if re.search(r"\b(price|cost|money|amount|tax|total|sum|charge|fee|pay)", text, re.IGNORECASE):
        t.append("money")
    if re.search(r"\b(print|printer|page|paper|report|pdf|export|PrintDocument)", text, re.IGNORECASE):
        t.append("print")
    if re.search(r"\b(button|click|submit|form|input|select|modal|dialog)", text, re.IGNORECASE):
        t.append("uiux")
    if re.search(r"\b(SELECT|INSERT|UPDATE|DELETE|JOIN|WHERE|FROM|query|sql)", text, re.IGNORECASE):
        t.append("db")
    if re.search(r"\b(api|http|fetch|axios|request|response|endpoint|REST)", text, re.IGNORECASE):
        t.append("net")
    if re.search(r"\b(file|fs|stream|read|write|upload|download|path)", text, re.IGNORECASE):
        t.append("io")
    return sorted(set(t))

# ===== Indexer =====
def should_index(p: pathlib.Path, exclude_langs: set) -> bool:
    if p.is_dir(): return False
    if any(part.startswith(".") for part in p.parts): return False
    lang = detect_lang(p)
    if lang in exclude_langs:
        return False
    if lang == "other":
        important_ext = {".xml", ".json", ".yaml", ".yml", ".toml", ".ini", ".config", ".md", ".txt", ".html", ".htm", ".css"}
        if p.suffix.lower() in important_ext: return True
        if p.name in {"Dockerfile", "Makefile", "Rakefile", "Gemfile", ".env", ".env.example"}: return True
        return False
    return True

def normalize_rel_path(repo: pathlib.Path, path: pathlib.Path) -> str:
    """Normalize a file path relative to repo for pattern matching"""
    try:
        rel = path.relative_to(repo)
    except ValueError:
        rel = path
    return str(rel).replace(os.sep, "/")

def match_patterns(rel_path: str, patterns: Optional[List[str]]) -> bool:
    """Check if a relative path matches any of the glob patterns"""
    if not patterns:
        return False
    return any(fnmatch(rel_path, pat) for pat in patterns)

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
):
    if exclude_langs is None:
        exclude_langs = set()
    if max_file_bytes is None:
        max_file_bytes = DEFAULT_MAX_FILE_BYTES

    repo = repo.resolve()
    paths = []
    large_files = []
    stats = IndexStats(enabled=profile)
    norm_include = include_patterns or []
    norm_exclude = exclude_patterns or []
    start_time = time.perf_counter()
    batch_size = batch_size if batch_size and batch_size > 0 else None
    batch_buffer: List[str] = []
    count = 0

    for root, dirs, files in os.walk(repo):
        dirs[:] = [d for d in dirs if d not in IGNORE_DIRS]
        root_path = pathlib.Path(root)
        for file in files:
            p = root_path / file
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
                file_size = p.stat().st_size
                stats.add_time("stat", time.perf_counter() - stat_start)
            except (OSError, PermissionError):
                stats.bump("skipped_errors")
                continue
            if file_size > max_file_bytes:
                large_files.append((str(p.relative_to(repo)), file_size))
                stats.bump("skipped_large")
                continue
            if not should_index(p, exclude_langs):
                continue
            if not is_text_file(p):
                stats.bump("skipped_errors")
                continue
            paths.append(p)

    total_files = len(paths)
    print(f"インデックス化対象ファイル数: {total_files}")

    with open(index_path, "w", encoding="utf-8") as w:
        for idx, p in enumerate(sorted(paths)):
            if idx % 100 == 0:
                print(f"処理中... {idx}/{total_files} ファイル")
            lang = detect_lang(p)
            try:
                read_start = time.perf_counter()
                txt, encoding = read_file_with_encoding(p)
                stats.add_time("read", time.perf_counter() - read_start)
                if not txt:
                    continue
                tags = make_tags(txt)
                rel_path = str(p.relative_to(repo))
                encoded = txt.encode("utf-8", errors="ignore")
                doc = Doc(
                    path=rel_path,
                    lang=lang,
                    size=len(encoded),
                    sha1=sha1_bytes(encoded),
                    tags=tags,
                    summary=make_summary(txt),
                    text=txt,
                    encoding=encoding
                )
                batch_buffer.append(json.dumps(asdict(doc), ensure_ascii=False) + "\n")
                stats.bump("indexed")
                count += 1
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
            except Exception as e:
                print(f"[ERROR] Failed to process {p}: {e}")
                stats.bump("skipped_errors")
                continue
        if batch_buffer:
            write_start = time.perf_counter()
            w.writelines(batch_buffer)
            stats.add_time("write", time.perf_counter() - write_start)
            batch_buffer.clear()

    print(f"[OK] Indexed {count} files -> {index_path}")
    if large_files:
        reports_dir = index_path.parent / "reports"
        reports_dir.mkdir(parents=True, exist_ok=True)
        log_path = reports_dir / "large_files_over_limit.log"
        with open(log_path, "w", encoding="utf-8") as f:
            f.write(f"Large files exceeding limit ({max_file_bytes:,} bytes):\n\n")
            for file_path, size in sorted(large_files, key=lambda x: x[1], reverse=True):
                f.write(f"{size:12,} bytes  {file_path}\n")
            f.write(f"\nTotal: {len(large_files)} files\n")
        threshold_mb = max_file_bytes / 1_000_000
        print(f"[WARNING] Skipped {len(large_files)} files exceeding ~{threshold_mb:.1f} MB. Details: {log_path}")
    if stats.counts.get("limit_stop"):
        print("[INFO] Stopped due to --max-files limit")
    if stats.counts.get("timeout_stop"):
        print("[WARNING] Stopped due to --max-seconds timeout")

    summary = stats.render_summary()
    if summary:
        print(summary)
        if profile_output:
            stats.export(profile_output)

# ===== Retrieval =====
def load_index(index_path: pathlib.Path) -> List[Dict[str,Any]]:
    arr: List[Dict[str,Any]] = []
    with open(index_path, "r", encoding="utf-8") as f:
        for line in f:
            line = line.strip()
            if line:
                arr.append(json.loads(line))
    return arr

def retrieve(query: str, index: List[Dict[str,Any]], topk: int = 10) -> List[Dict[str,Any]]:
    if SKLEARN_OK:
        vec_p = pathlib.Path(VEC_PATH)
        mat_p = pathlib.Path(MATRIX_PATH)
        if vec_p.exists() and mat_p.exists():
            return retrieve_tfidf(query, index, vec_p, mat_p, topk)
    return retrieve_naive(query, index, topk)

def retrieve_naive(query: str, index: List[Dict[str,Any]], topk: int) -> List[Dict[str,Any]]:
    q_words = set(w.lower() for w in re.split(r"\W+", query) if w)
    for doc in index:
        txt_words = set(w.lower() for w in re.split(r"\W+", doc.get("text","")[:3000]) if w)
        doc["_score"] = len(q_words & txt_words) / (len(q_words) + 0.01)
    return sorted(index, key=lambda x: x.get("_score",0), reverse=True)[:topk]

def retrieve_tfidf(query: str, index: List[Dict[str,Any]], vec_path: pathlib.Path, mat_path: pathlib.Path, topk: int) -> List[Dict[str,Any]]:
    from sklearn.metrics.pairwise import cosine_similarity
    vec = joblib.load(vec_path)
    mat = joblib.load(mat_path)
    q_vec = vec.transform([query])
    scores = cosine_similarity(q_vec, mat).flatten()
    for i, doc in enumerate(index):
        if i < len(scores):
            doc["_score"] = float(scores[i])
    return sorted(index, key=lambda x: x.get("_score",0), reverse=True)[:topk]

# ===== Vectorization =====
def cmd_vectorize(index_path: pathlib.Path):
    if not SKLEARN_OK:
        print("scikit-learn未導入。pip install scikit-learn joblib")
        return
    index = load_index(index_path)
    texts = [d.get("text","")[:10000] for d in index]
    vec = TfidfVectorizer(max_features=5000, ngram_range=(1,2), stop_words=None)
    mat = vec.fit_transform(texts)
    joblib.dump(vec, VEC_PATH)
    joblib.dump(mat, MATRIX_PATH)
    print(f"[OK] Vectorized -> {VEC_PATH}, {MATRIX_PATH}")

# ===== AI Analysis (1 file at a time) =====
def analyze_single_file_with_ai(file_path: str, code_text: str, issues: List[str], retry_count: int = 0) -> AIResult:
    """単一ファイルをAIで詳細解析"""
    if not OPENAI_OK:
        return AIResult(path=file_path, full_path=file_path, analysis="", error="OpenAI未導入")

    api_key = os.environ.get("OPENAI_API_KEY")
    if not api_key:
        return AIResult(path=file_path, full_path=file_path, analysis="", error="API key未設定")

    # 進捗表示
    print(f"  解析中: {file_path}")
    print(f"  検出問題: {', '.join(issues[:3])}")

    client = OpenAI(api_key=api_key)
    model = "gpt-4o"  # GPT-5が空応答のためgpt-4o使用

    # コードの一部を抽出（最大5000文字）
    code_snippet = code_text[:5000]

    prompt = f"""
以下のコードファイルを詳細に分析し、具体的な改善案を提供してください。

ファイル: {file_path}
検出された問題: {json.dumps(issues, ensure_ascii=False)}

コード:
```
{code_snippet}
```

以下の形式で回答してください：

## 問題箇所の特定
- 行番号または関数名
- 問題の詳細説明

## 改善案
### 問題1: [問題名]
**Before:**
```
[現在のコード]
```

**After:**
```
[改善されたコード]
```

**説明:** なぜこの改善が必要か

重要: 実際に動作する具体的なコードを提供してください。
"""

    try:
        resp = client.chat.completions.create(
            model=model,
            messages=[
                {"role": "system", "content": "You are an expert code reviewer. Provide specific improvements in Japanese."},
                {"role": "user", "content": prompt}
            ],
            temperature=1,
            max_completion_tokens=2000,
            timeout=AI_TIMEOUT
        )

        result = resp.choices[0].message.content
        if not result or result.strip() == "":
            if retry_count < AI_MAX_RETRIES:
                print(f"  [RETRY] 空の応答のため再試行 ({retry_count + 1}/{AI_MAX_RETRIES})")
                time.sleep(2)
                return analyze_single_file_with_ai(file_path, code_text, issues, retry_count + 1)
            else:
                return AIResult(path=file_path, full_path=file_path, analysis="", error="空の応答")

        print(f"  [OK] AI解析完了 ({len(result)} 文字)")
        return AIResult(path=file_path, full_path=file_path, analysis=result)

    except Exception as e:
        error_msg = str(e)[:200]
        if retry_count < AI_MAX_RETRIES:
            print(f"  [RETRY] エラー: {error_msg} ({retry_count + 1}/{AI_MAX_RETRIES})")
            time.sleep(2)
            return analyze_single_file_with_ai(file_path, code_text, issues, retry_count + 1)
        else:
            print(f"  [ERROR] AI解析失敗: {error_msg}")
            return AIResult(path=file_path, full_path=file_path, analysis="", error=error_msg)

# ===== Two-Phase Analysis System =====
def analyze_all_files(index: List[Dict[str, Any]], query: str, topk: int) -> Tuple[List[RuleResult], List[AIResult]]:
    """全ファイルをルールベースで解析し、重要なものをAIで詳細解析"""

    print("\n" + "="*60)
    print("【Phase 1】 ルールベース解析開始")
    print("="*60)

    # Phase 1: ルールベース解析
    rule_results = []
    for i, doc in enumerate(index[:topk]):
        print(f"\r[{i+1}/{min(topk, len(index))}] {doc['path']}", end="")

        text = doc.get("text", "")
        issues_with_samples = analyze_with_rules(text)

        # 問題のみを抽出
        issues = [issue for issue, _, _ in issues_with_samples]
        severity_score = sum(SEVERITY_SCORES.get(issue, 1) for issue in issues)

        # サンプルコードと改善案をまとめる
        sample_codes = []
        suggested_fixes = []
        for issue, sample, fix in issues_with_samples[:3]:  # 上位3件
            sample_codes.append(f"【{issue}】\n{sample}")
            suggested_fixes.append(f"【{issue}】\n{fix}")

        result = RuleResult(
            path=doc["path"],
            full_path=doc["path"],
            lang=doc.get("lang", "unknown"),
            encoding=doc.get("encoding", "unknown"),
            severity_score=severity_score,
            severity_level=get_severity_level(severity_score),
            issues=issues,
            tags=doc.get("tags", []),
            sample_code="\n\n".join(sample_codes) if sample_codes else "",
            suggested_fix="\n\n".join(suggested_fixes) if suggested_fixes else ""
        )
        rule_results.append(result)

    print(f"\n[OK] ルールベース解析完了: {len(rule_results)}ファイル")

    # Phase 2: AI詳細解析（重要度の高いファイルのみ）
    print("\n" + "="*60)
    print("【Phase 2】 AI詳細解析開始")
    print("="*60)

    # 重要度でソートしてAI解析対象を選定
    high_severity_results = [r for r in rule_results if r.severity_score >= AI_MIN_SEVERITY]
    high_severity_results.sort(key=lambda x: x.severity_score, reverse=True)
    ai_targets = high_severity_results[:AI_MAX_FILES]

    print(f"AI解析対象: {len(ai_targets)}ファイル（重要度{AI_MIN_SEVERITY}以上）")

    ai_results = []
    for i, rule_result in enumerate(ai_targets):
        print(f"\n【{i+1}/{len(ai_targets)}】 AI解析")

        # 対応するドキュメントを見つける
        doc = next((d for d in index if d["path"] == rule_result.path), None)
        if doc:
            ai_result = analyze_single_file_with_ai(
                rule_result.full_path,
                doc.get("text", ""),
                rule_result.issues
            )
            ai_results.append(ai_result)
        else:
            print(f"  [SKIP] ドキュメントが見つかりません")

    print(f"\n[OK] AI解析完了: {len(ai_results)}ファイル")

    return rule_results, ai_results

def get_severity_level(score: int) -> str:
    """スコアから重要度レベルを判定"""
    if score >= 10:
        return "🔴 緊急"
    elif score >= 7:
        return "🟠 高"
    elif score >= 4:
        return "🟡 中"
    elif score >= 1:
        return "🔵 低"
    else:
        return "⚪ 問題なし"

# ===== Report Generation =====
def generate_rule_based_report(query: str, rule_results: List[RuleResult]) -> str:
    """ルールベースのレポート生成（改善案付き）"""
    lines = [
        f"# ルールベース解析レポート: {query}",
        "",
        f"生成: {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}",
        f"解析ファイル数: {len(rule_results)}",
        "",
        "## 📊 問題の分布",
    ]

    # 重要度別に集計
    severity_groups = {
        "🔴 緊急": [],
        "🟠 高": [],
        "🟡 中": [],
        "🔵 低": [],
        "⚪ 問題なし": []
    }

    for r in rule_results:
        severity_groups[r.severity_level].append(r)

    for level, items in severity_groups.items():
        lines.append(f"- {level}: {len(items)}件")

    lines.extend(["", "---", ""])

    # 重要度順に出力
    sorted_results = sorted(rule_results, key=lambda x: x.severity_score, reverse=True)

    for i, result in enumerate(sorted_results, 1):
        lines.extend([
            f"## {i}. {result.path}",
            f"- **言語**: {result.lang}",
            f"- **エンコーディング**: {result.encoding}",
            f"- **重要度**: {result.severity_level} (スコア: {result.severity_score})",
            f"- **タグ**: {', '.join(result.tags) if result.tags else 'なし'}",
            "",
            "### 検出された問題:",
        ])

        if result.issues:
            for issue in result.issues:
                severity = SEVERITY_SCORES.get(issue, 1)
                emoji = "🔴" if severity >= 8 else "🟠" if severity >= 5 else "🟡" if severity >= 3 else "🔵"
                lines.append(f"- {emoji} {issue}")
        else:
            lines.append("- なし")

        if result.sample_code:
            lines.extend([
                "",
                "### 問題箇所のコード例:",
                "```",
                result.sample_code,
                "```"
            ])

        if result.suggested_fix:
            lines.extend([
                "",
                "### ルールベース改善案:",
                "```",
                result.suggested_fix,
                "```"
            ])

        lines.extend(["", "---", ""])

    return "\n".join(lines)

def generate_ai_enhanced_report(query: str, rule_results: List[RuleResult], ai_results: List[AIResult]) -> str:
    """AI改善案付きレポート生成"""
    lines = [
        f"# AI改善案付き解析レポート: {query}",
        "",
        f"生成: {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}",
        f"ルールベース解析: {len(rule_results)}ファイル",
        f"AI詳細解析: {len(ai_results)}ファイル",
        "",
        "## 🤖 AI詳細解析結果",
        ""
    ]

    # AI解析結果を出力
    for i, ai_result in enumerate(ai_results, 1):
        lines.extend([
            f"### [{i}/{len(ai_results)}] {ai_result.path}",
            ""
        ])

        if ai_result.error:
            lines.append(f"⚠️ **エラー**: {ai_result.error}")
        elif ai_result.analysis:
            lines.append(ai_result.analysis)
        else:
            lines.append("*解析結果なし*")

        lines.extend(["", "---", ""])

    # ルールベース結果のサマリー
    lines.extend([
        "## 📋 ルールベース解析サマリー",
        ""
    ])

    # AI解析されたファイルをマーク
    ai_analyzed_paths = {ar.path for ar in ai_results}

    high_severity = [r for r in rule_results if r.severity_score >= AI_MIN_SEVERITY]
    other = [r for r in rule_results if r.severity_score < AI_MIN_SEVERITY]

    lines.append("### 🔥 高重要度（AI解析済み）")
    for r in high_severity[:AI_MAX_FILES]:
        mark = "✅" if r.path in ai_analyzed_paths else "❌"
        lines.append(f"- {mark} {r.path} ({r.severity_level}, スコア: {r.severity_score})")

    if other:
        lines.append("\n### 📝 その他のファイル")
        for r in other[:10]:  # 最大10件
            lines.append(f"- {r.path} ({r.severity_level}, スコア: {r.severity_score})")

    return "\n".join(lines)

# ===== Commands =====
def cmd_query(query: str, topk: int, mode: str, index_path: pathlib.Path, out_base: Optional[str]):
    """検索と解析を実行"""
    index = load_index(index_path)
    cands = retrieve(query, index, topk=topk)

    # 2段階解析を実行
    rule_results, ai_results = analyze_all_files(cands, query, topk)

    # レポート生成
    rule_report = generate_rule_based_report(query, rule_results)
    ai_report = generate_ai_enhanced_report(query, rule_results, ai_results)

    # レポート保存
    if out_base:
        base_path = pathlib.Path(out_base)
        base_path.parent.mkdir(parents=True, exist_ok=True)

        # ルールベースレポート
        rule_path = base_path.parent / f"{base_path.stem}_rules.md"
        rule_path.write_text(rule_report, encoding="utf-8")
        print(f"\n[OK] ルールベースレポート: {rule_path}")

        # AI改善案付きレポート
        ai_path = base_path.parent / f"{base_path.stem}_ai.md"
        ai_path.write_text(ai_report, encoding="utf-8")
        print(f"[OK] AI改善案付きレポート: {ai_path}")
    else:
        print("\n" + "="*60)
        print("ルールベースレポート")
        print("="*60)
        print(rule_report[:2000] + "...")
        print("\n" + "="*60)
        print("AI改善案付きレポート")
        print("="*60)
        print(ai_report[:2000] + "...")

def cmd_advise(topk: int, mode: str, index_path: pathlib.Path, out_base: Optional[str]):
    """全体助言を実行"""
    seed_query = "金額 不整合 税 小数 印刷 Print UI UX DB N+1 JOIN"
    cmd_query(seed_query, topk, mode, index_path, out_base)

# ===== CLI =====
if __name__ == "__main__":
    ap = argparse.ArgumentParser(description="究極版コードレビューツール（2段階解析）")
    sub = ap.add_subparsers(dest="cmd", required=True)

    ap_idx = sub.add_parser("index", help="リポジトリをインデックス化")
    ap_idx.add_argument("repo", type=str)
    ap_idx.add_argument("--exclude-langs", type=str, nargs="*", help="除外する言語")
    ap_idx.add_argument("--max-file-mb", type=float, default=4.0, help="最大ファイルサイズ(MB)")
    ap_idx.add_argument("--profile-index", action="store_true", help="インデックス処理のプロファイル情報を出力")
    ap_idx.add_argument("--profile-output", type=str, default=None, help="プロファイル結果を書き出すファイル（.csv / .jsonl）")

    ap_idx.add_argument("--batch-size", type=int, default=BATCH_SIZE_DEFAULT, help="ファイル書き出しのバッチ件数（既定500、0で無効）")
    ap_idx.add_argument("--max-files", type=int, default=None, help="処理する最大ファイル数")
    ap_idx.add_argument("--max-seconds", type=float, default=None, help="処理を打ち切る最大秒数")
    ap_idx.add_argument("--include", nargs="*", help="インデックス対象とするパターン（glob）")
    ap_idx.add_argument("--exclude", nargs="*", help="インデックスから除外するパターン（glob）")
    ap_vec = sub.add_parser("vectorize", help="TF-IDFベクトル生成")
    ap_vec.add_argument("--index", type=str, default=INDEX_PATH)

    ap_q = sub.add_parser("query", help="検索と2段階解析")
    ap_q.add_argument("query", type=str, help="検索クエリ")
    ap_q.add_argument("--topk", type=int, default=50, help="解析対象上位N件")
    ap_q.add_argument("--mode", choices=["rules","ai","hybrid"], default="hybrid")
    ap_q.add_argument("--index", type=str, default=INDEX_PATH)
    ap_q.add_argument("--out", type=str, help="出力ファイルベース名（_rules.md と _ai.md が生成される）")

    ap_adv = sub.add_parser("advise", help="全体助言（2段階解析）")
    ap_adv.add_argument("--topk", type=int, default=100, help="解析対象上位N件")
    ap_adv.add_argument("--mode", choices=["rules","ai","hybrid"], default="hybrid")
    ap_adv.add_argument("--index", type=str, default=INDEX_PATH)
    ap_adv.add_argument("--out", type=str, help="出力ファイルベース名")

    args = ap.parse_args()

    if args.cmd == "index":
        repo = pathlib.Path(args.repo)
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
        )

    elif args.cmd == "vectorize":
        cmd_vectorize(pathlib.Path(args.index))

    elif args.cmd == "query":
        cmd_query(args.query, args.topk, args.mode, pathlib.Path(args.index), args.out)

    elif args.cmd == "advise":
        cmd_advise(args.topk, args.mode, pathlib.Path(args.index), args.out)

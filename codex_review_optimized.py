#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
codex_review_optimized.py — 統合版（読取専用 / GPT-5 + ルール / PR対応）
全件処理対応版 - タイムアウト240秒、バッチ処理で最適化

重点カテゴリ:
  1) 金額面の不整合（丸め/税/小数/通貨型）
  2) 印刷系（途中停止/ページ欠け/レポート系）
  3) UI/UX（未検証入力/導線/アクセシビリティ）
  4) DB負荷（N+1/全件/未インデックス/多重JOIN）

pip install chromadb openai scikit-learn joblib regex
環境変数: OPENAI_API_KEY（必須: AIモード）, OPENAI_MODEL（任意: 既定 'gpt-5'）

例:
  python codex_review_optimized.py index /path/to/repo
  python codex_review_optimized.py query "印刷が途中で止まる" --mode hybrid --topk 30 --out reports/print.md
  python codex_review_optimized.py advise --mode hybrid --topk 80 --out reports/advise.md
"""
from __future__ import annotations
import argparse, hashlib, json, os, pathlib, re, sys, time
from collections import defaultdict
from concurrent.futures import ThreadPoolExecutor
from dataclasses import dataclass, asdict
from fnmatch import fnmatch
from typing import Any, Dict, List, Optional, Tuple

# ===== Config =====
IGNORE_DIRS = {".git","node_modules","dist","build","out","bin","obj",".idea",".vscode",".next","coverage","target"}
MAX_FILE_BYTES = 3_000_000
ENV_FILE = ".env"
INDEX_PATH = ".advice_index.jsonl"
VEC_PATH = ".advice_tfidf.pkl"
MATRIX_PATH = ".advice_matrix.pkl"
BATCH_SIZE = 10  # AIに一度に送るファイル数
MAX_PROMPT_SIZE = 10000  # プロンプトの最大文字数
AI_TIMEOUT = 240  # 240秒でタイムアウト
BATCH_SIZE_DEFAULT = 500

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

# ===== Utils =====
if ENV_FILE and pathlib.Path(ENV_FILE).exists():
    with open(ENV_FILE, "r", encoding="utf-8") as f:
        for line in f:
            if "=" in line: key, val = line.strip().split("=", 1); os.environ[key] = val

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
        avg_per_file = (self.timings.get("read", 0.0) / indexed) if indexed else 0.0
        return (
            f"[PROFILE] Indexed {indexed}/{seen} files in {total_elapsed:.2f}s\n"
            f"           read={self.timings.get('read', 0.0):.2f}s stat={self.timings.get('stat', 0.0):.2f}s write={self.timings.get('write', 0.0):.2f}s\n"
            f"           avg_read_per_file={avg_per_file*1000:.1f}ms large_skipped={skipped_large} binary_skipped={skipped_binary} filter_skipped={skipped_filter} errors={skipped_errors} limits={limit_stop} timeouts={timeout_stop}"
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
        with open(p, "rb") as f:
            return b"\x00" not in f.read(4096)
    except Exception:
        return False

def make_summary(text: str) -> str:
    lines = text.splitlines()[:10]; return " / ".join(l.strip()[:80] for l in lines if l.strip())[:400]

def write_large_file_log(large_files: List[Tuple[str, int]], output_dir: pathlib.Path) -> pathlib.Path|None:
    if not large_files: return None
    reports_dir = output_dir / "reports"; reports_dir.mkdir(parents=True, exist_ok=True)
    log_path = reports_dir / "large_files_over_limit.log"
    with open(log_path, "w", encoding="utf-8") as f:
        f.write(f"Large files exceeding limit ({MAX_FILE_BYTES} bytes):\n\n")
        for file_path, size in sorted(large_files, key=lambda x: x[1], reverse=True):
            f.write(f"{size:12,} bytes  {file_path}\n")
        f.write(f"\nTotal: {len(large_files)} files\n")
    return log_path


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
    if re.search(r"(for|while|foreach|map).*\n.*\n.*\n.*(SELECT|INSERT|UPDATE|DELETE)", text, re.IGNORECASE):
        m.append("DB: ループ内SELECT (N+1) 疑い")
    if re.search(r"(JOIN.*){3,}", text, re.IGNORECASE):
        m.append("DB: 多重JOIN→遅延の恐れ。計画/IDX確認")
    if re.search(r"(OFFSET|LIMIT)\s+\d{4,}", text, re.IGNORECASE):
        m.append("DB: 大OFFSET→遅延。IDカーソル推奨")
    return m

def make_tags(text: str) -> List[str]:
    t = []
    if re.search(r"\b(price|cost|money|amount|tax|total|sum|charge|fee|pay|invoice|billing|currency|decimal|round)", text, re.IGNORECASE): t.append("money")
    if re.search(r"\b(print|printer|page|paper|report|pdf|export|PrintDocument|PrintPage|HasMorePages)", text, re.IGNORECASE): t.append("print")
    if re.search(r"\b(button|click|submit|form|input|select|modal|dialog|toast|spinner|loading|disabled)", text, re.IGNORECASE): t.append("uiux")
    if re.search(r"\b(SELECT|INSERT|UPDATE|DELETE|JOIN|WHERE|FROM|query|sql|database|transaction|connection)", text, re.IGNORECASE): t.append("db")
    if re.search(r"\b(api|http|fetch|axios|request|response|endpoint|REST|webhook|curl)", text, re.IGNORECASE): t.append("net")
    if re.search(r"\b(file|fs|stream|read|write|upload|download|path|directory|folder)", text, re.IGNORECASE): t.append("io")
    return sorted(set(t))

# ===== Indexer =====
def should_index(p: pathlib.Path) -> bool:
    if p.is_dir(): return False
    if any(part.startswith(".") for part in p.parts): return False
    lang = detect_lang(p)
    if lang == "other":
        important_ext = {".xml", ".json", ".yaml", ".yml", ".toml", ".ini", ".config", ".md", ".txt", ".html", ".htm", ".css"}
        if p.suffix.lower() in important_ext: return True
        if p.name in {"Dockerfile", "Makefile", "Rakefile", "Gemfile", ".env", ".env.example"}: return True
        return False
    return True

def cmd_index(
    repo: pathlib.Path,
    index_path: pathlib.Path,
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
    repo = repo.resolve()
    large_files: List[Tuple[str, int]] = []
    stats = IndexStats(enabled=profile)
    norm_include = include_patterns or []
    norm_exclude = exclude_patterns or []
    start_time = time.perf_counter()
    batch_size = batch_size if batch_size and batch_size > 0 else None
    reader_workers = max(0, worker_count or 0)

    candidates: List[Tuple[pathlib.Path, str]] = []
    for p in repo.rglob("*"):
        if not (p.is_file() and not any(d in p.parts for d in IGNORE_DIRS)):
            continue
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
        except Exception:
            stats.bump("skipped_errors")
            continue
        if file_size > MAX_FILE_BYTES:
            large_files.append((str(p.relative_to(repo)), file_size))
            stats.bump("skipped_large")
            continue
        if not should_index(p):
            continue
        if not is_text_file(p):
            stats.bump("skipped_binary")
            continue
        candidates.append((p, detect_lang(p)))

    def read_document(item: Tuple[pathlib.Path, str]):
        path, lang = item
        read_start = time.perf_counter()
        try:
            txt = path.read_text(encoding="utf-8", errors="ignore")
            duration = time.perf_counter() - read_start
            return path, lang, txt, duration, None
        except Exception as exc:
            duration = time.perf_counter() - read_start
            return path, lang, None, duration, exc

    executor: ThreadPoolExecutor | None = None
    iterator: Any
    if reader_workers > 1:
        executor = ThreadPoolExecutor(max_workers=reader_workers)
        iterator = executor.map(read_document, candidates)
    else:
        iterator = map(read_document, candidates)

    batch_buffer: List[str] = []
    try:
        with open(index_path, "w", encoding="utf-8") as w:
            for path, lang, txt, read_duration, error in iterator:
                stats.add_time("read", read_duration)
                if error or txt is None:
                    stats.bump("skipped_errors")
                    continue
                if not txt:
                    continue
                tags = make_tags(txt)
                rel_path = str(path.relative_to(repo))
                encoded = txt.encode("utf-8", errors="ignore")
                doc = Doc(path=rel_path, lang=lang, size=len(encoded), sha1=sha1_bytes(encoded), tags=tags, summary=make_summary(txt), text=txt)
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
            if batch_buffer:
                write_start = time.perf_counter()
                w.writelines(batch_buffer)
                stats.add_time("write", time.perf_counter() - write_start)
                batch_buffer.clear()
    finally:
        if executor:
            executor.shutdown(wait=False)

    print(f"[OK] Indexed {count} files -> {index_path}")
    log_path = write_large_file_log(large_files, index_path.parent.resolve())
    if log_path:
        threshold_mb = MAX_FILE_BYTES / 1_000_000
        try:
            rel_log = log_path.relative_to(index_path.parent.resolve())
        except ValueError:
            rel_log = log_path
        print(f"[WARNING] Skipped {len(large_files)} files exceeding ~{threshold_mb:.1f} MB. Details: {rel_log}")
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
            if line: arr.append(json.loads(line))
    return arr

def retrieve(query: str, index: List[Dict[str,Any]], topk: int = 10) -> List[Dict[str,Any]]:
    if SKLEARN_OK:
        vec_p = pathlib.Path(VEC_PATH); mat_p = pathlib.Path(MATRIX_PATH)
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
    vec = joblib.load(vec_path); mat = joblib.load(mat_path)
    q_vec = vec.transform([query])
    scores = cosine_similarity(q_vec, mat).flatten()
    for i, doc in enumerate(index):
        doc["_score"] = float(scores[i])
    return sorted(index, key=lambda x: x.get("_score",0), reverse=True)[:topk]

def cmd_vectorize(index_path: pathlib.Path):
    if not SKLEARN_OK:
        print("scikit-learn未導入。pip install scikit-learn joblib")
        return
    index = load_index(index_path)
    texts = [d.get("text","")[:10000] for d in index]
    vec = TfidfVectorizer(max_features=5000, ngram_range=(1,2), stop_words=None)
    mat = vec.fit_transform(texts)
    joblib.dump(vec, VEC_PATH); joblib.dump(mat, MATRIX_PATH)
    print(f"[OK] Vectorized -> {VEC_PATH}, {MATRIX_PATH}")

# ===== Advice rules =====
def rule_advices(d: Dict[str,Any]) -> List[str]:
    text = d.get("text", "")[:20000]
    out: List[str] = []
    out += scan_money(text)
    out += scan_print(text)
    out += scan_ui(text)
    out += scan_db(text)
    return out[:8]

# ===== GPT-5 バッチ処理対応版 =====
def ai_review_batch(query: str, all_snippets: List[str]) -> str:
    """全ファイルをバッチ処理でAIレビュー"""
    if not OPENAI_OK: return "(AI未有効: openai未導入)"
    api_key = os.environ.get("OPENAI_API_KEY")
    if not api_key: return "(AI未有効: OPENAI_API_KEY 未設定)"
    model = os.environ.get("OPENAI_MODEL", "gpt-5")
    client = OpenAI(api_key=api_key)

    if not all_snippets:
        return "(レビュー対象ファイルなし)"

    reviews = []
    total_batches = (len(all_snippets) + BATCH_SIZE - 1) // BATCH_SIZE
    print(f"[INFO] Processing {len(all_snippets)} files in {total_batches} batches...")

    for i in range(0, len(all_snippets), BATCH_SIZE):
        batch_num = i // BATCH_SIZE + 1
        batch = all_snippets[i:i+BATCH_SIZE]
        batch_json = json.dumps(batch, ensure_ascii=False)

        # プロンプトサイズ制限
        if len(batch_json) > MAX_PROMPT_SIZE:
            batch_json = batch_json[:MAX_PROMPT_SIZE] + "...(truncated)"

        prompt = (
            "あなたはシニアコードレビュアーです。ユーザー報告: \n" +
            json.dumps(query, ensure_ascii=False) +
            "\n次のコード断片を根拠に、(1)金額 (2)印刷 (3)UI/UX (4)DB負荷 を重点に助言だけを出してください。\n" +
            "確度が低い指摘は『可能性』と明記。修正コードは出力しない。\n" +
            f"=== 候補コード (バッチ {batch_num}/{total_batches}) ===\n" +
            batch_json
        )

        try:
            print(f"[INFO] Calling GPT-5 for batch {batch_num}/{total_batches}...")
            resp = client.chat.completions.create(
                model=model,
                messages=[{"role":"user","content":prompt}],
                temperature=1,
                timeout=AI_TIMEOUT
            )
            review = resp.choices[0].message.content.strip()
            reviews.append(f"### バッチ {batch_num} ({len(batch)}ファイル)\n{review}")
            print(f"[OK] Batch {batch_num} completed")
        except Exception as e:
            error_msg = f"(バッチ{batch_num} AIエラー: {str(e)[:100]})"
            reviews.append(error_msg)
            print(f"[ERROR] {error_msg}")

    # 全バッチの結果を統合
    header = f"## AI統合レビュー (全{len(all_snippets)}ファイル / {total_batches}バッチ処理)\n"
    return header + "\n---\n".join(reviews)

# ===== Report =====
def render_report(title: str, items: List[Dict[str,Any]], ai_summary: str|None) -> str:
    lines: List[str] = [f"# {title}", "", f"生成: {time.strftime('%Y-%m-%d %H:%M:%S')} (読取専用)", ""]
    if ai_summary: lines += ["## AIレビュー要約 (GPT-5)", "", ai_summary, ""]

    # 全件のアドバイスを出力
    lines.append(f"## 検出ファイル一覧 (全{len(items)}件)\n")
    for i, it in enumerate(items, 1):
        lines += [f"### {i}. {it['path']}  ({it['lang']})  score={it.get('score',0)}",
                  f"- tags: {', '.join(it.get('tags', [])) or '-'}"]
        susp = it.get("suspicions")
        lines += (["- 重点指摘:"] + [f"  - {m}" for m in susp]) if susp else ["- 重点指摘: （特に強い兆候なし）"]
        lines += [""]
    return "\n".join(lines)

def make_advice_entry(d: Dict[str,Any]) -> Dict[str,Any]:
    return {"path": d["path"], "lang": d["lang"], "score": round(d.get("_score",0.0),4),
            "tags": d.get("tags",[]), "suspicions": rule_advices(d)}

# ===== Commands =====
def cmd_query(query: str, topk: int, mode: str, index_path: pathlib.Path, out: pathlib.Path|None):
    index = load_index(index_path)
    cands = retrieve(query, index, topk=topk)
    items = [make_advice_entry(d) for d in cands]

    ai_summary = None
    if mode in ("ai","hybrid"):
        print(f"[INFO] Starting AI review for {len(cands)} files...")
        ai_summary = ai_review_batch(query, [d["text"] for d in cands])  # 全件処理

    rep = render_report(f"検索レポート: {query}", items, ai_summary)
    if out:
        out.parent.mkdir(parents=True, exist_ok=True)
        out.write_text(rep, encoding="utf-8")
        print(f"[OK] wrote {out}")
    else:
        print(rep)

def cmd_advise(topk: int, mode: str, index_path: pathlib.Path, out: pathlib.Path|None):
    seed_query = "金額 不整合 税 小数 印刷 Print HasMorePages NewPage UI UX アクセシビリティ DB N+1 JOIN 遅い"
    index = load_index(index_path)
    cands = retrieve(seed_query, index, topk=topk)
    items = [make_advice_entry(d) for d in cands]

    ai_summary = None
    if mode in ("ai","hybrid"):
        print(f"[INFO] Starting AI review for {len(cands)} files...")
        ai_summary = ai_review_batch("横断助言（金額/印刷/UI/DB）", [d["text"] for d in cands])  # 全件処理

    rep = render_report("全体助言（横断チェック）", items, ai_summary)
    if out:
        out.parent.mkdir(parents=True, exist_ok=True)
        out.write_text(rep, encoding="utf-8")
        print(f"[OK] wrote {out}")
    else:
        print(rep)

# ===== CLI =====
if __name__ == "__main__":
    ap = argparse.ArgumentParser(description="読取専用 静的レビュー & 自然言語探索 CLI（GPT-5統合・全件処理対応）")
    sub = ap.add_subparsers(dest="cmd", required=True)

    ap_idx = sub.add_parser("index", help="リポジトリをインデックス化（読取のみ）")
    ap_idx.add_argument("repo", type=str)
    ap_idx.add_argument("--profile-index", action="store_true", help="インデックス処理のプロファイル情報を出力")
    ap_idx.add_argument("--profile-output", type=str, default=None, help="プロファイル結果を書き出すファイル（.csv / .jsonl）")
    ap_idx.add_argument("--batch-size", type=int, default=BATCH_SIZE_DEFAULT, help="ファイル書き出しのバッチ件数（既定500、0で無効）")
    ap_idx.add_argument("--max-files", type=int, default=None, help="処理する最大ファイル数")
    ap_idx.add_argument("--max-seconds", type=float, default=None, help="処理を打ち切る最大秒数")
    ap_idx.add_argument("--include", nargs="*", help="インデックス対象とするパターン（glob）")
    ap_idx.add_argument("--exclude", nargs="*", help="インデックスから除外するパターン（glob）")
    ap_idx.add_argument("--worker-count", type=int, default=0, help="ファイル読み込みに使用するワーカー数（既定0で無効）")

    ap_vec = sub.add_parser("vectorize", help="(任意) TF-IDFベクトル生成")
    ap_vec.add_argument("--index", type=str, default=INDEX_PATH)

    ap_q = sub.add_parser("query", help="自然言語で関連ソースを探索＋ルール/GPT-5で助言のみ出力")
    ap_q.add_argument("query", type=str, help="検索クエリ")
    ap_q.add_argument("--topk", type=int, default=30, help="検索上位N件")
    ap_q.add_argument("--mode", choices=["rules","ai","hybrid"], default="hybrid")
    ap_q.add_argument("--index", type=str, default=INDEX_PATH)
    ap_q.add_argument("--out", type=str, help="出力ファイル (Markdown)")

    ap_adv = sub.add_parser("advise", help="全体助言（横断チェック）")
    ap_adv.add_argument("--topk", type=int, default=80, help="助言対象上位N件")
    ap_adv.add_argument("--mode", choices=["rules","ai","hybrid"], default="hybrid")
    ap_adv.add_argument("--index", type=str, default=INDEX_PATH)
    ap_adv.add_argument("--out", type=str, help="出力ファイル (Markdown)")

    args = ap.parse_args()
    if args.cmd == "index":
        repo = pathlib.Path(args.repo)
        profile_output = pathlib.Path(args.profile_output) if args.profile_output else None
        cmd_index(
            repo,
            pathlib.Path(INDEX_PATH),
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
        cmd_query(args.query, args.topk, args.mode, pathlib.Path(args.index), out)
    elif args.cmd == "advise":
        out = pathlib.Path(args.out) if args.out else None
        cmd_advise(args.topk, args.mode, pathlib.Path(args.index), out)

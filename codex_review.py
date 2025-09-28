#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
codex_review.py — 統合版（読取専用 / GPT-5 + ルール / PR対応）

重点カテゴリ:
  1) 金額面の不整合（丸め/税/小数/通貨型）
  2) 印刷系（途中停止/ページ欠け/レポート系）
  3) UI/UX（未検証入力/導線/アクセシビリティ）
  4) DB負荷（N+1/全件/未インデックス/多重JOIN）

pip install chromadb openai scikit-learn joblib regex
環境変数: OPENAI_API_KEY（必須: AIモード）, OPENAI_MODEL（任意: 既定 'gpt-5'）

例:
  python codex_review.py index /path/to/repo
  python codex_review.py query "印刷が途中で止まる" --mode hybrid --topk 30 --out reports/print.md
  python codex_review.py advise --mode hybrid --topk 80 --out reports/advise.md
"""
from __future__ import annotations
import argparse, hashlib, json, os, pathlib, re, sys, time
from concurrent.futures import ThreadPoolExecutor
from fnmatch import fnmatch
from dataclasses import dataclass, asdict
from typing import Any, Dict, List, Tuple, Optional
from collections import defaultdict

# ===== Config =====
IGNORE_DIRS = {".git","node_modules","dist","build","out","bin","obj",".idea",".vscode",".next","coverage","target"}
MAX_FILE_BYTES = 3_000_000
ENV_FILE = ".env"
INDEX_PATH = ".advice_index.jsonl"
VEC_PATH = ".advice_tfidf.pkl"
MATRIX_PATH = ".advice_matrix.pkl"
HYBRID_TOPK_AI = 5  # GPT-5向けに削減
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
EXT_LANG: Dict[str,str] = {".cs":"csharp",".java":"java",".ts":"typescript",".js":"javascript",".tsx":"typescript",".jsx":"javascript",".html":"html",".css":"css",".pas":"delphi",".dpr":"delphi",".dfm":"delphi_dfm"}

def load_env_from_file(path: pathlib.Path = pathlib.Path(ENV_FILE)) -> None:
    if not path.exists():
        return
    try:
        for raw in path.read_text(encoding="utf-8").splitlines():
            line = raw.strip()
            if not line or line.startswith("#"):
                continue
            if "=" not in line:
                continue
            key, value = line.split("=", 1)
            key = key.strip()
            value = value.strip().strip('"').strip("'")
            if not key:
                continue
            os.environ.setdefault(key, value)
    except Exception as exc:
        print(f"⚠️ Failed to read environment file {path}: {exc}", file=sys.stderr)

load_env_from_file()

def is_text_file(p: pathlib.Path) -> bool:
    try:
        with open(p, "rb") as f: chunk = f.read(4096)
        return b"\x00" not in chunk
    except Exception:
        return False

def detect_lang(p: pathlib.Path) -> str:
    return EXT_LANG.get(p.suffix.lower(), "other")

def sha1_bytes(b: bytes) -> str:
    return hashlib.sha1(b).hexdigest()

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
        parts = [
            f"[PROFILE] Indexed {indexed}/{seen} files in {total_elapsed:.2f}s",
            f"           read={self.timings.get('read', 0.0):.2f}s stat={self.timings.get('stat', 0.0):.2f}s write={self.timings.get('write', 0.0):.2f}s",
            f"           avg_read_per_file={avg_per_file*1000:.1f}ms large_skipped={skipped_large} binary_skipped={skipped_binary} filter_skipped={skipped_filter} errors={skipped_errors} limits={limit_stop} timeouts={timeout_stop}"
        ]
        return "\n".join(parts)

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


TAG_RULES: List[Tuple[str, List[str]]] = [
    ("print", [r"print", r"Printer\b", r"PrintDocument", r"Printable", r"@media\s+print", r"\bPrinters\b", r"\bPrinter\.", r"\bBeginDoc\b", r"\bEndDoc\b", r"\bNewPage\b", r"\bStartDoc\b", r"\bStartPage\b", r"\bEndPage\b", r"\bQuickRep\b|\bTQuickRep\b|\bTfrxReport\b|\bFastReport\b|\bRLReport\b", r"object\s+TQuickRep", r"object\s+TfrxReport", r"object\s+RLReport" ]),
    ("money", [r"Amount|Total|Tax|合計|金額|小計|税込|税抜|消費税", r"round|Math\.Round|Truncate", r"double|float|Single|Decimal"]),
    ("db",    [r"SELECT\s", r"\bINSERT\b", r"\bUPDATE\b", r"\bDELETE\b", r"JOIN", r"EntityManager", r"DbContext", r"ADOQuery", r"FDQuery"]),
    ("io",    [r"File\.", r"fs\.", r"Files\.", r"Stream", r"BufferedReader", r"MemoryStream", r"TFileStream", r"TMemoryStream"]),
    ("net",   [r"http", r"HttpClient", r"WebClient", r"fetch\(", r"axios\(", r"TIdHTTP", r"NetHTTPClient"]),
    ("thread",[r"Thread", r"Task", r"async\s", r"await\s", r"CompletableFuture", r"Observable", r"TThread", r"TTask"]),
    ("uiux",  [r"MessageBox\.Show|alert\(", r"Accessibility|aria-|alt=", r"TODO|FIXME.*UI"]),
]

def make_tags(text: str) -> List[str]:
    tags: List[str] = []
    for name, pats in TAG_RULES:
        for pat in pats:
            if re.search(pat, text, flags=re.IGNORECASE): tags.append(name); break
    return sorted(set(tags))

def make_summary(text: str, max_chars: int = 400) -> str:
    import re as _re
    t = _re.sub(r"\s+", " ", text).strip()
    return t[:max_chars]

def write_large_file_log(entries: List[Tuple[str,int]], base_dir: pathlib.Path) -> pathlib.Path | None:
    log_path = base_dir / "reports" / "large_files_over_limit.log"
    if not entries:
        try:
            if log_path.exists(): log_path.unlink()
        except Exception:
            pass
        return None
    log_path.parent.mkdir(parents=True, exist_ok=True)
    threshold_mb = MAX_FILE_BYTES / 1_000_000
    lines = [
        "# Large file skip report",
        f"Generated: {time.strftime('%Y-%m-%d %H:%M:%S%z')}",
        f"Threshold: {MAX_FILE_BYTES} bytes (~{threshold_mb:.2f} MB)",
        "",
        "The following files exceeded the threshold and require manual review:",
        ""
    ]
    for rel, size in entries:
        size_mb = size / 1_000_000
        lines.append(f"- {rel} :: {size} bytes (~{size_mb:.2f} MB)")
    log_path.write_text("\n".join(lines) + "\n", encoding="utf-8")
    return log_path

def iter_files(root: pathlib.Path):
    for dirpath, dirnames, filenames in os.walk(root):
        dirnames[:] = [d for d in dirnames if d not in IGNORE_DIRS]
        for fn in filenames:
            yield pathlib.Path(dirpath) / fn


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

# ===== Indexer =====
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
    repo = repo.resolve(); count = 0
    stats = IndexStats(enabled=profile)
    large_files: List[Tuple[str,int]] = []
    norm_include = include_patterns or []
    norm_exclude = exclude_patterns or []
    start_time = time.perf_counter()
    batch_buffer: List[str] = []
    batch_size = batch_size if batch_size and batch_size > 0 else None
    reader_workers = max(0, worker_count or 0)

    candidates: List[Tuple[pathlib.Path, str]] = []
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
            size = p.stat().st_size
            stats.add_time("stat", time.perf_counter() - stat_start)
        except Exception:
            stats.bump("skipped_errors")
            continue
        if size > MAX_FILE_BYTES:
            try: rel = str(p.relative_to(repo))
            except ValueError: rel = str(p)
            large_files.append((rel, size)); stats.bump("skipped_large")
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
        for line in f: arr.append(json.loads(line))
    return arr

def build_vectorizer(index_path: pathlib.Path):
    if not SKLEARN_OK:
        print("ℹ️ TF-IDFスキップ（scikit-learn未導入）"); return
    docs: List[Dict[str,Any]] = []; corpus: List[str] = []
    with open(index_path, "r", encoding="utf-8") as f:
        for line in f:
            d = json.loads(line); docs.append(d)
            corpus.append(f"{d['path']} {d['lang']} {' '.join(d['tags'])}\n{d['text']}")
    vec = TfidfVectorizer(max_df=0.9, min_df=2, ngram_range=(1,2)); X = vec.fit_transform(corpus)
    joblib.dump(vec, VEC_PATH); joblib.dump(X, MATRIX_PATH)
    print(f"✅ TF-IDF built -> {VEC_PATH}, {MATRIX_PATH} (docs={len(docs)})")

def retrieve(query: str, index: List[Dict[str,Any]], topk: int=40) -> List[Dict[str,Any]]:
    if SKLEARN_OK and os.path.exists(VEC_PATH) and os.path.exists(MATRIX_PATH):
        import joblib, numpy as np
        vec = joblib.load(VEC_PATH); X = joblib.load(MATRIX_PATH); qv = vec.transform([query])
        scores = (qv @ X.T).toarray()[0]; order = np.argsort(scores)[::-1][:topk]
        return [index[i] | {"_score": float(scores[i])} for i in order]
    # fallback: naive
    q_words = [w for w in re.split(r"[^\wぁ-んァ-ン一-龥]+", query) if w]
    scored: List[Tuple[float,int]] = []
    for i, d in enumerate(index):
        text = d["text"]; s = 0.0
        for w in q_words: s += len(re.findall(re.escape(w), text, flags=re.IGNORECASE))
        for tag in ("print","money","db","uiux"):
            if tag in d.get("tags", []) and re.search(tag if tag!="money" else r"金額|Amount|Tax|合計", query, re.IGNORECASE): s += 2.0
        scored.append((s,i))
    scored.sort(key=lambda x: x[0], reverse=True)
    return [index[i] | {"_score": float(s)} for s,i in scored[:topk]]

# ===== Rule checks =====
def scan_print(text: str, lang: str) -> List[str]:
    adv: List[str] = []
    if lang == "csharp" and re.search(r"PrintDocument", text):
        if re.search(r"PrintPage\s*\(", text) and not re.search(r"HasMorePages", text): adv.append("C#: e.HasMorePages 設定漏れ")
        if re.search(r"HasMorePages\s*=\s*false", text) and not re.search(r"HasMorePages\s*=\s*true", text): adv.append("C#: HasMorePages 固定false")
    if lang == "java" and re.search(r"PrinterJob|Printable|javax\.print", text):
        if re.search(r"Printable", text) and not re.search(r"pageIndex", text): adv.append("Java: pageIndex/NO_SUCH_PAGE 分岐不十分")
    if lang in ("typescript","javascript") and re.search(r"window\.print\(|contentWindow\.print|printJS", text):
        if not re.search(r"setTimeout|await|onload", text): adv.append("TS/JS: ロード待ち無しでprint")
    if lang == "delphi" and re.search(r"\bPrinters\b|\bTPrinter\b|Printer\.", text, re.IGNORECASE):
        if re.search(r"\bBeginDoc\b|\bStartDoc\b", text) and not re.search(r"\bEndDoc\b|\bEndPage\b", text): adv.append("Delphi: BeginDocに対するEndDoc/EndPage不足")
    return adv

def scan_money(text: str) -> List[str]:
    adv: List[str] = []
    if re.search(r"\b(double|float|Single)\b", text, re.IGNORECASE): adv.append("金額: 浮動小数で金額→誤差。Decimal/通貨型へ")
    if re.search(r"round\s*\(|Math\.Round|Truncate", text, re.IGNORECASE): adv.append("金額: 丸め規則/税計算の整合確認")
    if re.search(r"Amount|Total|Tax|合計|金額|小計|税込|税抜", text): adv.append("金額: 税込/税抜・端数処理の混在注意")
    return adv

def scan_uiux(text: str) -> List[str]:
    adv: List[str] = []
    if re.search(r"MessageBox\.Show|alert\(", text): adv.append("UI/UX: ダイアログ多用で操作阻害")
    if re.search(r"TODO|FIXME.*UI", text): adv.append("UI/UX: UI改善TODO/FIXME残存")
    if re.search(r"<img[^>]*>", text) and not re.search(r"alt=", text): adv.append("UI/UX: imgにalt無し（アクセシビリティ）")
    return adv

def scan_db(text: str) -> List[str]:
    adv: List[str] = []
    if re.search(r"SELECT\s+\*\s+FROM", text, re.IGNORECASE): adv.append("DB: SELECT * →負荷増。列限定")
    if re.search(r"for\s*\([^)]*\)\s*\{[^}]*SELECT", text, re.IGNORECASE) or re.search(r"foreach.*SELECT", text, re.IGNORECASE): adv.append("DB: ループ内SELECT (N+1) 疑い")
    if re.search(r"JOIN[^;\n]+JOIN[^;\n]+JOIN", text, re.IGNORECASE): adv.append("DB: 多重JOIN→遅延の恐れ。計画/IDX確認")
    return adv

def rule_advices(d: Dict[str,Any]) -> List[str]:
    text, lang = d["text"], d["lang"]
    out: List[str] = []
    out += scan_money(text)
    out += scan_print(text, lang)
    out += scan_uiux(text)
    out += scan_db(text)
    return out[:8]

# ===== GPT-5 =====
def ai_review(query: str, snippets: List[str]) -> str:
    if not OPENAI_OK: return "(AI未有効: openai未導入)"
    api_key = os.environ.get("OPENAI_API_KEY")
    if not api_key: return "(AI未有効: OPENAI_API_KEY 未設定)"
    model = os.environ.get("OPENAI_MODEL", "gpt-5")
    client = OpenAI(api_key=api_key)
    prompt = (
        "あなたはシニアコードレビュアーです。ユーザー報告: \n" +
        json.dumps(query, ensure_ascii=False) +
        "\n次のコード断片を根拠に、(1)金額 (2)印刷 (3)UI/UX (4)DB負荷 を重点に助言だけを出してください。\n" +
        "確度が低い指摘は『可能性』と明記。修正コードは出力しない。\n=== 候補コード ===\n" +
        json.dumps(snippets, ensure_ascii=False)[:5000]  # データサイズを5000文字に制限
    )
    try:
        resp = client.chat.completions.create(
            model=model,
            messages=[{"role":"user","content":prompt}],
            temperature=1,
            timeout=60  # 60秒でタイムアウト
        )
        return resp.choices[0].message.content.strip()
    except Exception as e:
        return f"(AIエラー: {str(e)[:100]})"

# ===== Report =====
def render_report(title: str, items: List[Dict[str,Any]], ai_summary: str|None) -> str:
    lines: List[str] = [f"# {title}", "", f"生成: {time.strftime('%Y-%m-%d %H:%M:%S')} (読取専用)", ""]
    if ai_summary: lines += ["## AIレビュー要約 (GPT-5)", "", ai_summary, ""]
    for i, it in enumerate(items, 1):
        lines += [f"## {i}. {it['path']}  ({it['lang']})  score={it.get('score',0)}", f"- tags: {', '.join(it.get('tags', [])) or '-'}"]
        susp = it.get("suspicions")
        lines += (["- 重点指摘:"] + [f"  - {m}" for m in susp]) if susp else ["- 重点指摘: （特に強い兆候なし）"]
        lines += [""]
    return "\n".join(lines)

def make_advice_entry(d: Dict[str,Any]) -> Dict[str,Any]:
    return {"path": d["path"], "lang": d["lang"], "score": round(d.get("_score",0.0),4), "tags": d.get("tags",[]), "suspicions": rule_advices(d)}

# ===== Commands =====
def cmd_query(query: str, topk: int, mode: str, index_path: pathlib.Path, out: pathlib.Path|None):
    index = load_index(index_path); cands = retrieve(query, index, topk=topk)
    items = [make_advice_entry(d) for d in cands]
    ai_summary = None
    if mode in ("ai","hybrid"):
        ai_summary = ai_review(query, [d["text"] for d in cands[:HYBRID_TOPK_AI]])
    rep = render_report(f"検索レポート: {query}", items, ai_summary)
    if out: out.parent.mkdir(parents=True, exist_ok=True); out.write_text(rep, encoding="utf-8"); print(f"[OK] wrote {out}")
    else: print(rep)

def cmd_advise(topk: int, mode: str, index_path: pathlib.Path, out: pathlib.Path|None):
    seed_query = "金額 不整合 税 小数 印刷 Print HasMorePages NewPage UI UX アクセシビリティ DB N+1 JOIN 遅い"
    index = load_index(index_path); cands = retrieve(seed_query, index, topk=topk)
    items = [make_advice_entry(d) for d in cands]
    ai_summary = None
    if mode in ("ai","hybrid"):
        ai_summary = ai_review("横断助言（金額/印刷/UI/DB）", [d["text"] for d in cands[:HYBRID_TOPK_AI]])
    rep = render_report("全体助言（横断チェック）", items, ai_summary)
    if out: out.parent.mkdir(parents=True, exist_ok=True); out.write_text(rep, encoding="utf-8"); print(f"[OK] wrote {out}")
    else: print(rep)

# ===== CLI =====
if __name__ == "__main__":
    ap = argparse.ArgumentParser(description="読取専用 静的レビュー & 自然言語探索 CLI（GPT-5統合）")
    sub = ap.add_subparsers(dest="cmd", required=True)

    ap_idx = sub.add_parser("index", help="リポジトリをインデックス化（読取のみ）")
    ap_idx.add_argument("repo", type=str)
    ap_idx.add_argument("--profile-index", action="store_true", help="インデックス処理のプロファイル情報を出力")
    ap_idx.add_argument("--profile-output", type=str, default=None, help="プロファイル結果を保存するファイルパス（.csv または .jsonl）")
    ap_idx.add_argument("--batch-size", type=int, default=BATCH_SIZE_DEFAULT, help="ファイル書き出しのバッチ件数（既定500、0で無効）")
    ap_idx.add_argument("--max-files", type=int, default=None, help="処理する最大ファイル数")
    ap_idx.add_argument("--max-seconds", type=float, default=None, help="処理を打ち切る最大秒数")
    ap_idx.add_argument("--include", nargs="*", help="インデックス対象とするパターン（glob）")
    ap_idx.add_argument("--exclude", nargs="*", help="インデックスから除外するパターン（glob）")
    ap_idx.add_argument("--worker-count", type=int, default=0, help="ファイル読み込みに使用するワーカー数（既定0で無効）")

    ap_vec = sub.add_parser("vectorize", help="(任意) TF-IDFベクトルを作成")
    ap_vec.add_argument("--index", default=INDEX_PATH)

    ap_q = sub.add_parser("query", help="自然言語で関連ソースを探索→ルール/GPT-5で助言のみ出力")
    ap_q.add_argument("query", type=str)
    ap_q.add_argument("--topk", type=int, default=40)
    ap_q.add_argument("--mode", choices=["rules","ai","hybrid"], default="hybrid")
    ap_q.add_argument("--index", default=INDEX_PATH)
    ap_q.add_argument("--out", type=str, default=None)

    ap_adv = sub.add_parser("advise", help="全体助言（横断チェック）")
    ap_adv.add_argument("--topk", type=int, default=80)
    ap_adv.add_argument("--mode", choices=["rules","ai","hybrid"], default="hybrid")
    ap_adv.add_argument("--index", default=INDEX_PATH)
    ap_adv.add_argument("--out", type=str, default=None)

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
        try: build_vectorizer(pathlib.Path(INDEX_PATH))
        except Exception: pass
    elif args.cmd == "vectorize":
        build_vectorizer(pathlib.Path(args.index))
    elif args.cmd == "query":
        out = pathlib.Path(args.out) if args.out else None
        cmd_query(args.query, args.topk, args.mode, pathlib.Path(args.index), out)
    elif args.cmd == "advise":
        out = pathlib.Path(args.out) if args.out else None
        cmd_advise(args.topk, args.mode, pathlib.Path(args.index), out)

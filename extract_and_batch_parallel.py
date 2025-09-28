#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
並列処理版バッチ処理システム
GPT-5-Codex/GPT-4o対応 - 高速化実装
"""
import re
import os
import sys
import time
import json
import asyncio
import hashlib
from pathlib import Path
from typing import List, Dict, Any, Optional
from datetime import datetime
from concurrent.futures import ThreadPoolExecutor, as_completed
import threading

# .env読み込み
ENV_FILE = ".env"
if Path(ENV_FILE).exists():
    with open(ENV_FILE, "r", encoding="utf-8") as f:
        for line in f:
            line = line.strip()
            if "=" in line and not line.startswith("#"):
                key, val = line.split("=", 1)
                os.environ[key] = val

# 設定値（並列処理最適化版）
BATCH_SIZE = 50  # 1バッチあたりのファイル数（並列処理のため削減）
PARALLEL_WORKERS = 10  # 並列処理数（API制限に応じて調整）
MIN_SEVERITY = 5  # 分析対象の最小危険度スコア
API_DELAY = 0.1  # API呼び出し間隔（並列処理のため短縮）
MAX_RETRIES = 3  # 最大リトライ回数
TIMEOUT_PER_FILE = 60  # 1ファイルあたりのタイムアウト（秒）
CACHE_DIR = Path(".cache/analysis")  # キャッシュディレクトリ

# 進捗状態ファイル
PROGRESS_FILE = ".batch_progress_parallel.json"

# API呼び出し制限管理
class RateLimiter:
    def __init__(self, max_calls_per_minute=60):
        self.max_calls = max_calls_per_minute
        self.calls = []
        self.lock = threading.Lock()

    def wait_if_needed(self):
        with self.lock:
            now = time.time()
            # 1分以上前の呼び出し記録を削除
            self.calls = [t for t in self.calls if now - t < 60]

            if len(self.calls) >= self.max_calls:
                # 待機時間を計算
                wait_time = 60 - (now - self.calls[0]) + 0.1
                if wait_time > 0:
                    time.sleep(wait_time)
                    return self.wait_if_needed()

            self.calls.append(now)

# グローバルレート制限
rate_limiter = RateLimiter(max_calls_per_minute=100)

def load_progress():
    """進捗状態を読み込み"""
    if Path(PROGRESS_FILE).exists():
        with open(PROGRESS_FILE, "r", encoding="utf-8") as f:
            return json.load(f)
    return {"completed_files": {}, "last_batch": 0, "cache_hits": 0}

def save_progress(progress):
    """進捗状態を保存"""
    with open(PROGRESS_FILE, "w", encoding="utf-8") as f:
        json.dump(progress, f, ensure_ascii=False, indent=2)

def get_file_hash(file_path: str) -> str:
    """ファイルのハッシュ値を取得"""
    try:
        if Path(file_path).exists():
            with open(file_path, "rb") as f:
                content = f.read(10000)  # 最初の10KB
                return hashlib.md5(content).hexdigest()
    except:
        pass
    return ""

def get_cache_path(file_path: str, file_hash: str) -> Path:
    """キャッシュファイルのパスを取得"""
    CACHE_DIR.mkdir(parents=True, exist_ok=True)
    safe_name = re.sub(r'[^\w\-_]', '_', file_path)
    return CACHE_DIR / f"{safe_name}_{file_hash}.json"

def load_cache(file_path: str, file_hash: str) -> Optional[Dict]:
    """キャッシュから結果を読み込み"""
    cache_path = get_cache_path(file_path, file_hash)
    if cache_path.exists():
        try:
            with open(cache_path, "r", encoding="utf-8") as f:
                return json.load(f)
        except:
            pass
    return None

def save_cache(file_path: str, file_hash: str, result: Dict):
    """結果をキャッシュに保存"""
    cache_path = get_cache_path(file_path, file_hash)
    try:
        with open(cache_path, "w", encoding="utf-8") as f:
            json.dump(result, f, ensure_ascii=False, indent=2)
    except:
        pass

def extract_problem_files():
    """danger_analysis_ALLから問題ファイルを抽出"""
    report_file = "reports/danger_analysis_ALL"
    if not Path(report_file).exists():
        print(f"[ERROR] {report_file} が見つかりません")
        return []

    with open(report_file, "r", encoding="utf-8") as f:
        content = f.read()

    problem_files = []
    sections = content.split("###")

    for section in sections[1:]:
        lines = section.strip().split("\n")
        if not lines:
            continue

        header = lines[0].strip()
        match = re.match(r'\d+\.\s+(.+)', header)
        if not match:
            continue

        file_path = match.group(1)
        severity_score = 0
        problems = []

        for line in lines:
            if "スコア:" in line:
                score_match = re.search(r'スコア:\s*(\d+)', line)
                if score_match:
                    severity_score = int(score_match.group(1))

            if "検出された問題:" in line:
                idx = lines.index(line)
                for prob_line in lines[idx+1:]:
                    if prob_line.strip().startswith("-"):
                        problems.append(prob_line.strip()[1:].strip())
                    elif not prob_line.strip():
                        break

        if severity_score >= MIN_SEVERITY:
            problem_files.append({
                "path": file_path,
                "severity": severity_score,
                "problems": problems
            })

    problem_files.sort(key=lambda x: x["severity"], reverse=True)

    print(f"[INFO] 抽出された問題ファイル: {len(problem_files)}件")

    # 重要度別に集計
    critical = sum(1 for f in problem_files if f["severity"] >= 15)
    high = sum(1 for f in problem_files if 10 <= f["severity"] < 15)
    medium = sum(1 for f in problem_files if 5 <= f["severity"] < 10)

    print(f"  [緊急]（15以上）: {critical}件")
    print(f"  [高]（10-14）: {high}件")
    print(f"  [中]（5-9）: {medium}件")

    return problem_files

def select_model_for_severity(severity: int) -> tuple[str, str]:
    """重要度に応じて最適なモデルとeffortを選択"""
    if severity >= 15:
        return "gpt-5-codex", "high"
    elif severity >= 10:
        return "gpt-4o", None
    else:
        return "gpt-4o-mini", None

def analyze_file_async(client, file_info: Dict, progress: Dict) -> Dict:
    """非同期でファイルを分析（キャッシュ対応）"""
    file_path = file_info.get("path", "")
    severity = file_info.get("severity", 0)
    problems = file_info.get("problems", [])

    # キャッシュチェック
    file_hash = get_file_hash(file_path)
    if file_hash:
        cached_result = load_cache(file_path, file_hash)
        if cached_result:
            progress["cache_hits"] += 1
            return cached_result

    # レート制限
    rate_limiter.wait_if_needed()

    for attempt in range(MAX_RETRIES):
        try:
            # ファイル内容を読み込み
            content = ""
            if Path(file_path).exists():
                try:
                    with open(file_path, "r", encoding="utf-8", errors="ignore") as f:
                        file_size = Path(file_path).stat().st_size
                        if file_size > 10000:
                            content = f.read(5000)
                        else:
                            content = f.read()
                except Exception as e:
                    content = f"[読み込みエラー: {str(e)}]"
            else:
                content = "[ファイルが存在しません]"

            # プロンプト作成
            prompt = f"""
以下のコードファイルを詳細に分析し、問題点と具体的な改善コードを提示してください。

ファイル: {file_path}
危険度スコア: {severity}
検出された問題:
{chr(10).join(f'- {p}' for p in problems)}

コード:
```
{content}
```

必ず以下の形式で回答してください：

## 1. 問題の詳細分析
（各問題について、なぜ危険なのか、どんな影響があるのか説明）

## 2. 改善コード
### Before（問題のあるコード）
```
（現在の問題コード）
```

### After（改善後のコード）
```
（修正された安全なコード）
```

## 3. 追加の改善提案
（その他の改善点、ベストプラクティス）
"""

            # モデル選択
            model, effort = select_model_for_severity(severity)

            # API呼び出し
            if "gpt-5" in model and effort:
                response = client.responses.create(
                    model=model,
                    input=prompt,
                    reasoning={"effort": effort}
                )

                if hasattr(response, 'output_text'):
                    analysis = response.output_text
                else:
                    analysis = "[分析失敗: レスポンスエラー]"
            else:
                response = client.chat.completions.create(
                    model=model,
                    messages=[
                        {"role": "system", "content": "You are an expert code reviewer and security analyst."},
                        {"role": "user", "content": prompt}
                    ],
                    max_tokens=2000,
                    temperature=0.3,
                    timeout=TIMEOUT_PER_FILE
                )

                if response.choices and response.choices[0].message.content:
                    analysis = response.choices[0].message.content
                else:
                    analysis = "[分析失敗: 空レスポンス]"

            result = {
                "path": file_path,
                "severity": severity,
                "problems": problems,
                "original_code": content[:1000],
                "analysis": analysis,
                "model_used": model
            }

            # キャッシュに保存
            if file_hash:
                save_cache(file_path, file_hash, result)

            return result

        except Exception as e:
            if attempt < MAX_RETRIES - 1:
                time.sleep(1)
            else:
                return {
                    "path": file_path,
                    "severity": severity,
                    "problems": problems,
                    "original_code": content[:1000] if 'content' in locals() else "",
                    "analysis": f"[エラー: {str(e)[:200]}]",
                    "model_used": "error"
                }

def analyze_batch_parallel(batch_num: int, files: List[Dict], progress: Dict):
    """バッチを並列処理で分析"""
    try:
        from openai import OpenAI

        api_key = os.environ.get("OPENAI_API_KEY")
        if not api_key:
            print("[ERROR] OPENAI_API_KEY not set")
            return None

        client = OpenAI(api_key=api_key)

        print(f"\n[BATCH {batch_num}] {len(files)}ファイル分析開始（並列処理: {PARALLEL_WORKERS}ワーカー）")

        start_time = time.time()
        results = []
        completed = 0

        # ThreadPoolExecutorで並列処理
        with ThreadPoolExecutor(max_workers=PARALLEL_WORKERS) as executor:
            # 全タスクをサブミット
            future_to_file = {
                executor.submit(analyze_file_async, client, file_info, progress): file_info
                for file_info in files
                if file_info["path"] not in progress.get("completed_files", {})
            }

            # 完了したタスクから順次処理
            for future in as_completed(future_to_file):
                file_info = future_to_file[future]
                try:
                    result = future.result(timeout=TIMEOUT_PER_FILE * 2)
                    results.append(result)

                    # 進捗更新
                    completed += 1
                    progress["completed_files"][file_info["path"]] = True

                    # 進捗表示
                    if completed % 5 == 0:
                        elapsed = time.time() - start_time
                        rate = completed / elapsed if elapsed > 0 else 0
                        remaining = (len(files) - completed) / rate if rate > 0 else 0
                        print(f"  進捗: {completed}/{len(files)} | 速度: {rate:.1f}files/s | 残り: {remaining:.0f}秒")
                        save_progress(progress)

                except Exception as e:
                    print(f"  [ERROR] {file_info['path']}: {str(e)[:100]}")
                    results.append({
                        "path": file_info["path"],
                        "severity": file_info["severity"],
                        "problems": file_info["problems"],
                        "analysis": f"[処理エラー: {str(e)[:200]}]",
                        "model_used": "error"
                    })

        elapsed_time = time.time() - start_time
        print(f"\n[BATCH {batch_num}] 完了")
        print(f"  処理時間: {elapsed_time:.1f}秒")
        print(f"  速度: {len(results)/elapsed_time:.1f}files/s")
        print(f"  キャッシュヒット: {progress.get('cache_hits', 0)}件")

        # バッチ結果を保存
        output_file = f"reports/AI_batch{batch_num:03d}_parallel.md"
        save_detailed_batch_report(batch_num, results, output_file, elapsed_time)

        print(f"  -> レポート保存: {output_file}")
        return results

    except Exception as e:
        print(f"[ERROR] Batch {batch_num} failed: {str(e)}")
        return None

def save_detailed_batch_report(batch_num: int, results: List[Dict], output_file: str, elapsed_time: float):
    """詳細バッチレポートを保存（並列処理版）"""
    Path("reports").mkdir(exist_ok=True)

    with open(output_file, "w", encoding="utf-8") as f:
        f.write(f"# AI詳細分析レポート（並列処理版） - バッチ{batch_num:03d}\n\n")
        f.write(f"生成日時: {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}\n")
        f.write(f"処理時間: {elapsed_time:.1f}秒\n")
        f.write(f"処理速度: {len(results)/elapsed_time:.1f}files/s\n")
        f.write(f"並列ワーカー数: {PARALLEL_WORKERS}\n")
        f.write(f"分析ファイル数: {len(results)}\n\n")

        # モデル使用統計
        model_stats = {}
        for r in results:
            model = r.get("model_used", "unknown")
            model_stats[model] = model_stats.get(model, 0) + 1

        f.write("## モデル使用統計\n")
        for model, count in sorted(model_stats.items()):
            f.write(f"- {model}: {count}件\n")
        f.write("\n")

        # サマリーセクション
        f.write("## エグゼクティブサマリー\n\n")
        critical_count = sum(1 for r in results if r['severity'] >= 15)
        high_count = sum(1 for r in results if 10 <= r['severity'] < 15)
        medium_count = sum(1 for r in results if 5 <= r['severity'] < 10)

        f.write(f"- [緊急] 緊急対応必要: {critical_count}件\n")
        f.write(f"- [高] 高優先度: {high_count}件\n")
        f.write(f"- [中] 中優先度: {medium_count}件\n\n")

        f.write("---\n\n")

        # 各ファイルの詳細
        for idx, result in enumerate(results, 1):
            f.write(f"## {idx}. {result['path']}\n\n")

            if result['severity'] >= 15:
                badge = "[緊急]"
            elif result['severity'] >= 10:
                badge = "[高]"
            else:
                badge = "[中]"

            f.write(f"**危険度**: {badge} (スコア: {result['severity']})\n")
            f.write(f"**使用モデル**: {result.get('model_used', 'unknown')}\n\n")
            f.write(f"**検出問題**:\n")
            for problem in result['problems']:
                f.write(f"- {problem}\n")
            f.write("\n")

            f.write("### 元のコード（抜粋）\n\n")
            f.write("```\n")
            f.write(result['original_code'])
            f.write("\n```\n\n")

            f.write("### AI分析結果と改善案\n\n")
            f.write(result['analysis'])
            f.write("\n\n---\n\n")

def main():
    print("="*60)
    print("問題ファイル抽出・並列詳細分析システム")
    print("="*60)

    # 進捗状態をロード
    progress = load_progress()

    # 問題ファイルを抽出
    problem_files = extract_problem_files()

    if not problem_files:
        print("[INFO] 分析対象ファイルがありません")
        return

    # バッチ作成
    batches = []
    for i in range(0, len(problem_files), BATCH_SIZE):
        batch = problem_files[i:i + BATCH_SIZE]
        batches.append(batch)

    print(f"[INFO] {len(batches)}個のバッチを作成（{BATCH_SIZE}ファイル/バッチ）\n")

    # 推定処理時間
    total_files = len(problem_files)
    cached_files = len(progress.get("completed_files", {}))
    remaining_files = total_files - cached_files
    estimated_time = remaining_files / (PARALLEL_WORKERS * 2)  # 並列処理での推定

    print(f"[INFO] 詳細分析開始")
    print(f"  総ファイル数: {total_files}")
    print(f"  キャッシュ済み: {cached_files}")
    print(f"  処理対象: {remaining_files}")
    print(f"  推定時間: {estimated_time/60:.1f}分\n")

    # 各バッチを並列処理
    all_results = []
    total_start = time.time()

    for batch_num, batch in enumerate(batches, 1):
        results = analyze_batch_parallel(batch_num, batch, progress)
        if results:
            all_results.extend(results)

        # 進捗保存
        progress["last_batch"] = batch_num
        save_progress(progress)

    total_elapsed = time.time() - total_start

    # 最終レポート生成
    if all_results:
        print("\n[INFO] 最終レポート統合開始")

        final_report = "reports/AI_analysis_parallel_complete.md"
        with open(final_report, "w", encoding="utf-8") as f:
            f.write("# 完全コード分析レポート - 並列処理版\n\n")
            f.write(f"生成日時: {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}\n")
            f.write(f"総処理時間: {total_elapsed/60:.1f}分\n")
            f.write(f"平均速度: {len(all_results)/total_elapsed:.1f}files/s\n")
            f.write(f"総分析ファイル数: {len(all_results)}\n")
            f.write(f"キャッシュヒット数: {progress.get('cache_hits', 0)}\n\n")

            # 全バッチの内容を統合
            for batch_num in range(1, len(batches) + 1):
                batch_file = f"reports/AI_batch{batch_num:03d}_parallel.md"
                if Path(batch_file).exists():
                    with open(batch_file, "r", encoding="utf-8") as bf:
                        # ヘッダーをスキップして内容を追加
                        lines = bf.readlines()
                        for line in lines:
                            if not line.startswith("#"):
                                f.write(line)

        print(f"[OK] 最終レポート生成完了: {final_report}")

    print("\n" + "="*60)
    print("処理完了")
    print(f"総処理時間: {total_elapsed/60:.1f}分")
    print(f"平均処理速度: {len(all_results)/total_elapsed:.1f}files/s")
    print("="*60)

if __name__ == "__main__":
    main()
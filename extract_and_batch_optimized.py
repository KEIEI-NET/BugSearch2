#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
最適化版バッチ処理システム
GPT-5-Codex対応 - 200ファイル/バッチ
"""
import re
import os
import sys
import time
import json
from pathlib import Path
from typing import List, Dict, Any
from datetime import datetime

# .env読み込み
ENV_FILE = ".env"
if Path(ENV_FILE).exists():
    with open(ENV_FILE, "r", encoding="utf-8") as f:
        for line in f:
            line = line.strip()
            if "=" in line and not line.startswith("#"):
                key, val = line.split("=", 1)
                os.environ[key] = val

# 設定値（最適化版）
BATCH_SIZE = 200  # 1バッチあたりのファイル数（500→200に削減）
MIN_SEVERITY = 5  # 分析対象の最小危険度スコア
API_DELAY = 1.0  # API呼び出し間隔（0.5→1.0秒に延長）
BATCH_DELAY = 5  # バッチ間待機時間（3→5秒に延長）
MAX_RETRIES = 3  # 最大リトライ回数
TIMEOUT_PER_FILE = 10  # 1ファイルあたりのタイムアウト（秒）

# 進捗状態ファイル
PROGRESS_FILE = ".batch_progress.json"

def load_progress():
    """進捗状態を読み込み"""
    if Path(PROGRESS_FILE).exists():
        with open(PROGRESS_FILE, "r", encoding="utf-8") as f:
            return json.load(f)
    return {"completed_batches": [], "last_batch": 0}

def save_progress(progress):
    """進捗状態を保存"""
    with open(PROGRESS_FILE, "w", encoding="utf-8") as f:
        json.dump(progress, f)

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

    critical = sum(1 for f in problem_files if f["severity"] >= 15)
    high = sum(1 for f in problem_files if 10 <= f["severity"] < 15)
    medium = sum(1 for f in problem_files if 5 <= f["severity"] < 10)

    print(f"  [緊急]（15以上）: {critical}件")
    print(f"  [高]（10-14）: {high}件")
    print(f"  [中]（5-9）: {medium}件")

    return problem_files

def create_batches(files: List[Dict]) -> List[List[Dict]]:
    """ファイルをバッチに分割"""
    batches = []
    for i in range(0, len(files), BATCH_SIZE):
        batch = files[i:i + BATCH_SIZE]
        batches.append(batch)
    print(f"[INFO] {len(batches)}個のバッチを作成（{BATCH_SIZE}ファイル/バッチ）")
    return batches

def show_progress_bar(current, total, width=50):
    """プログレスバーを表示"""
    percent = current / total
    filled = int(width * percent)
    bar = '=' * filled + '-' * (width - filled)
    sys.stdout.write(f'\r[{bar}] {percent*100:.1f}% ({current}/{total})')
    sys.stdout.flush()

def analyze_file_with_retry(client, model, file_info, idx, total):
    """リトライ機構付きファイル分析"""
    for attempt in range(MAX_RETRIES):
        try:
            file_path = file_info.get("path", "")
            severity = file_info.get("severity", 0)
            problems = file_info.get("problems", [])

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

## 2. 影響範囲と緊急度
（ビジネスへの影響、セキュリティリスク、パフォーマンス影響）

## 3. 改善コード

### Before（問題のあるコード）
```
（現在の問題コード）
```

### After（改善後のコード）
```
（修正された安全なコード）
```

## 4. 追加の改善提案
（その他の改善点、ベストプラクティス、将来的な改善案）

## 5. テストケース案
（改善を検証するためのテストコード例）
"""

            # GPT-5-Codex呼び出し
            if "gpt-5-codex" in model.lower():
                response = client.responses.create(
                    model=model,
                    input=prompt,
                    reasoning={"effort": "high"}
                )

                if hasattr(response, 'output_text'):
                    analysis = response.output_text
                else:
                    analysis = "[分析失敗: レスポンスエラー]"
            else:
                response = client.chat.completions.create(
                    model="gpt-4o",
                    messages=[
                        {"role": "system", "content": "You are an expert code reviewer and security analyst."},
                        {"role": "user", "content": prompt}
                    ],
                    max_tokens=3000,
                    temperature=0.3
                )

                if response.choices and response.choices[0].message.content:
                    analysis = response.choices[0].message.content
                else:
                    analysis = "[分析失敗: 空レスポンス]"

            # プログレスバー更新
            show_progress_bar(idx, total)

            return {
                "path": file_path,
                "severity": severity,
                "problems": problems,
                "original_code": content[:1000],
                "analysis": analysis
            }

        except Exception as e:
            if attempt < MAX_RETRIES - 1:
                print(f"\n  [RETRY {attempt+1}/{MAX_RETRIES}] {file_path}: {str(e)[:50]}")
                time.sleep(2)
            else:
                print(f"\n  [ERROR] {file_path}: {str(e)[:100]}")
                return {
                    "path": file_path,
                    "severity": severity,
                    "problems": problems,
                    "original_code": content[:1000] if 'content' in locals() else "",
                    "analysis": f"[エラー: {str(e)[:200]}]"
                }

def analyze_batch_with_gpt5_codex(batch_num: int, files: List[Dict], progress: Dict):
    """GPT-5-Codexで詳細分析と改善コード生成（最適化版）"""

    # 既に処理済みのバッチはスキップ
    if batch_num in progress.get("completed_batches", []):
        print(f"\n[BATCH {batch_num}] スキップ（処理済み）")
        return None

    try:
        from openai import OpenAI

        api_key = os.environ.get("OPENAI_API_KEY")
        if not api_key:
            print("[ERROR] OPENAI_API_KEY not set")
            return None

        client = OpenAI(api_key=api_key)
        model = os.environ.get("OPENAI_MODEL", "gpt-5-codex")

        print(f"\n[BATCH {batch_num}] {len(files)}ファイル分析開始")
        print(f"  推定処理時間: {len(files) * (TIMEOUT_PER_FILE + API_DELAY) / 60:.1f}分")

        start_time = time.time()
        results = []

        for idx, file_info in enumerate(files, 1):
            result = analyze_file_with_retry(client, model, file_info, idx, len(files))
            results.append(result)

            # API制限対策
            time.sleep(API_DELAY)

        elapsed_time = time.time() - start_time
        print(f"\n[BATCH {batch_num}] 完了 - 処理時間: {elapsed_time/60:.1f}分")

        # バッチ結果を保存
        output_file = f"reports/AI_batch{batch_num:03d}_optimized.md"
        save_detailed_batch_report(batch_num, results, output_file)

        # 進捗を更新
        progress["completed_batches"].append(batch_num)
        progress["last_batch"] = batch_num
        save_progress(progress)

        print(f"  -> レポート保存: {output_file}")
        return results

    except Exception as e:
        print(f"[ERROR] Batch {batch_num} failed: {str(e)}")
        return None

def save_detailed_batch_report(batch_num: int, results: List[Dict], output_file: str):
    """詳細バッチレポートを保存"""
    with open(output_file, "w", encoding="utf-8") as f:
        f.write(f"# AI詳細分析レポート（改善コード付き） - バッチ{batch_num:03d}\n\n")
        f.write(f"生成日時: {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}\n")
        f.write(f"使用モデル: {os.environ.get('OPENAI_MODEL', 'gpt-4o')}\n")
        f.write(f"分析ファイル数: {len(results)}\n")
        f.write(f"バッチサイズ: {BATCH_SIZE}ファイル\n\n")

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

            f.write(f"**危険度**: {badge} (スコア: {result['severity']})\n\n")
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

def merge_all_reports(batch_count: int):
    """全バッチレポートを統合"""
    print("\n[INFO] 最終レポート統合開始")

    merged_content = []
    merged_content.append("# 完全コード分析レポート - 全問題箇所と改善コード（最適化版）\n\n")
    merged_content.append(f"生成日時: {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}\n")
    merged_content.append(f"使用モデル: {os.environ.get('OPENAI_MODEL', 'gpt-4o')}\n")
    merged_content.append(f"バッチ数: {batch_count}\n")
    merged_content.append(f"バッチサイズ: {BATCH_SIZE}ファイル\n\n")

    total_files = 0
    total_critical = 0
    total_high = 0
    total_medium = 0

    # 各バッチファイルを読み込み
    for batch_num in range(1, batch_count + 1):
        batch_file = f"reports/AI_batch{batch_num:03d}_optimized.md"
        if Path(batch_file).exists():
            with open(batch_file, "r", encoding="utf-8") as f:
                content = f.read()

                # サマリー統計を抽出
                critical_match = re.search(r'\[緊急\] 緊急対応必要: (\d+)件', content)
                high_match = re.search(r'\[高\] 高優先度: (\d+)件', content)
                medium_match = re.search(r'\[中\] 中優先度: (\d+)件', content)

                if critical_match:
                    total_critical += int(critical_match.group(1))
                if high_match:
                    total_high += int(high_match.group(1))
                if medium_match:
                    total_medium += int(medium_match.group(1))

                # コンテンツを追加
                lines = content.split("\n")
                for line in lines[10:]:
                    merged_content.append(line + "\n")

                total_files += min(BATCH_SIZE, len(re.findall(r'^## \d+\.', content, re.MULTILINE)))

    # 全体サマリー
    summary = []
    summary.append("## 全体統計\n\n")
    summary.append(f"- **総分析ファイル数**: {total_files}件\n")
    summary.append(f"- [緊急] **緊急対応必要**: {total_critical}件\n")
    summary.append(f"- [高] **高優先度**: {total_high}件\n")
    summary.append(f"- [中] **中優先度**: {total_medium}件\n")
    summary.append(f"- **合計問題ファイル**: {total_critical + total_high + total_medium}件\n\n")
    summary.append("---\n\n")

    merged_content[5:5] = summary

    # 統合ファイル保存
    output_file = "reports/COMPLETE_ANALYSIS_OPTIMIZED_GPT5.md"
    with open(output_file, "w", encoding="utf-8") as f:
        f.writelines(merged_content)

    print(f"[SUCCESS] 最終統合レポート生成: {output_file}")

    file_size_mb = Path(output_file).stat().st_size / 1024 / 1024
    print(f"[INFO] ファイルサイズ: {file_size_mb:.2f} MB")

    if file_size_mb > 25:
        print("[WARNING] ファイルサイズが25MBを超えています")

def main():
    """メイン処理"""
    print("=" * 60)
    print("問題ファイル詳細分析システム - 最適化版")
    print(f"GPT-5-Codex ({BATCH_SIZE}ファイル/バッチ)")
    print("=" * 60)

    # 進捗状態を読み込み
    progress = load_progress()

    if progress["last_batch"] > 0:
        print(f"[INFO] 前回の処理を継続します（完了バッチ: {len(progress['completed_batches'])}個）")

    # 1. 問題ファイルを抽出
    problem_files = extract_problem_files()

    if len(problem_files) == 0:
        print("[INFO] 危険度5以上のファイルが見つかりません")
        return

    # 2. バッチ作成
    batches = create_batches(problem_files)

    # 処理時間の見積もり
    total_time_est = len(problem_files) * (TIMEOUT_PER_FILE + API_DELAY) / 60
    print(f"[INFO] 推定総処理時間: {total_time_est:.1f}分 ({total_time_est/60:.1f}時間)")

    # 3. 各バッチを詳細分析
    print(f"\n[INFO] 詳細分析開始（{len(batches)}バッチ、{len(problem_files)}ファイル）")
    print("[INFO] 自動実行モードで処理を開始します...")

    overall_start = time.time()

    for batch_num, batch in enumerate(batches, 1):
        analyze_batch_with_gpt5_codex(batch_num, batch, progress)

        # 全体進捗表示
        completed = len(progress.get("completed_batches", []))
        print(f"\n[PROGRESS] 全体: {completed}/{len(batches)}バッチ完了 ({completed/len(batches)*100:.1f}%)")

        # 残り時間の推定
        if completed > 0:
            elapsed = time.time() - overall_start
            avg_per_batch = elapsed / completed
            remaining_batches = len(batches) - completed
            est_remaining = avg_per_batch * remaining_batches / 60
            print(f"[INFO] 推定残り時間: {est_remaining:.1f}分")

        # API制限対策（バッチ間で待機）
        if batch_num < len(batches):
            print(f"[INFO] 次のバッチまで{BATCH_DELAY}秒待機...")
            time.sleep(BATCH_DELAY)

    # 4. レポート統合
    merge_all_reports(len(batches))

    # 進捗ファイルをクリア
    if Path(PROGRESS_FILE).exists():
        os.remove(PROGRESS_FILE)

    overall_time = (time.time() - overall_start) / 60
    print("\n" + "=" * 60)
    print(f"[SUCCESS] 全処理完了！")
    print(f"[INFO] 総処理時間: {overall_time:.1f}分 ({overall_time/60:.1f}時間)")
    print("=" * 60)
    print("\n[INFO] 生成されたファイル:")
    print(f"  - 個別バッチ: reports/AI_batch*_optimized.md")
    print(f"  - 統合レポート: reports/COMPLETE_ANALYSIS_OPTIMIZED_GPT5.md")

if __name__ == "__main__":
    main()
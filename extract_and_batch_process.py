#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
danger_analysis_ALLから問題ファイルを抽出してバッチ処理
GPT-5-Codex対応版
"""
import re
import os
import sys
import time
import json
from pathlib import Path
from typing import List, Dict, Any

# .env読み込み
ENV_FILE = ".env"
if Path(ENV_FILE).exists():
    with open(ENV_FILE, "r", encoding="utf-8") as f:
        for line in f:
            line = line.strip()
            if "=" in line and not line.startswith("#"):
                key, val = line.split("=", 1)
                os.environ[key] = val

# 設定値
BATCH_SIZE = 500  # 1バッチあたりのファイル数
MIN_SEVERITY = 5  # 分析対象の最小危険度スコア

def extract_problem_files():
    """danger_analysis_ALLから問題ファイルを抽出"""
    report_file = "reports/danger_analysis_ALL"
    if not Path(report_file).exists():
        print(f"[ERROR] {report_file} が見つかりません")
        return []

    with open(report_file, "r", encoding="utf-8") as f:
        content = f.read()

    # 問題ファイルを抽出（スコア5以上）
    problem_files = []

    # 各セクションをパース
    sections = content.split("###")

    for section in sections[1:]:  # 最初の空セクションをスキップ
        lines = section.strip().split("\n")
        if not lines:
            continue

        # ファイル名を抽出
        header = lines[0].strip()
        match = re.match(r'\d+\.\s+(.+)', header)
        if not match:
            continue

        file_path = match.group(1)

        # 重要度とスコアを抽出
        severity_score = 0
        problems = []

        for line in lines:
            # スコア抽出
            if "スコア:" in line:
                score_match = re.search(r'スコア:\s*(\d+)', line)
                if score_match:
                    severity_score = int(score_match.group(1))

            # 問題抽出
            if "検出された問題:" in line:
                idx = lines.index(line)
                for prob_line in lines[idx+1:]:
                    if prob_line.strip().startswith("-"):
                        problems.append(prob_line.strip()[1:].strip())
                    elif not prob_line.strip():
                        break

        # 重要度が基準以上の場合のみ追加
        if severity_score >= MIN_SEVERITY:
            problem_files.append({
                "path": file_path,
                "severity": severity_score,
                "problems": problems
            })

    # 重要度でソート（高い順）
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

def create_batches(files: List[Dict]) -> List[List[Dict]]:
    """ファイルをバッチに分割"""
    batches = []
    for i in range(0, len(files), BATCH_SIZE):
        batch = files[i:i + BATCH_SIZE]
        batches.append(batch)
    print(f"[INFO] {len(batches)}個のバッチを作成")
    return batches

def analyze_batch_with_gpt5_codex(batch_num: int, files: List[Dict]):
    """GPT-5-Codexで詳細分析と改善コード生成"""
    try:
        from openai import OpenAI

        api_key = os.environ.get("OPENAI_API_KEY")
        if not api_key:
            print("[ERROR] OPENAI_API_KEY not set")
            return None

        client = OpenAI(api_key=api_key)
        model = os.environ.get("OPENAI_MODEL", "gpt-5-codex")

        print(f"\n[BATCH {batch_num}] {len(files)}ファイル分析開始")

        # 分析結果を格納
        results = []

        for idx, file_info in enumerate(files, 1):
            if idx % 10 == 0:
                print(f"  進捗: {idx}/{len(files)}")

            file_path = file_info.get("path", "")
            severity = file_info.get("severity", 0)
            problems = file_info.get("problems", [])

            # ファイル内容を読み込み
            content = ""
            if Path(file_path).exists():
                try:
                    with open(file_path, "r", encoding="utf-8", errors="ignore") as f:
                        # ファイルサイズに応じて読み込み量を調整
                        file_size = Path(file_path).stat().st_size
                        if file_size > 10000:
                            content = f.read(5000)  # 大きいファイルは最初の5000文字
                        else:
                            content = f.read()  # 小さいファイルは全体
                except Exception as e:
                    content = f"[読み込みエラー: {str(e)}]"
            else:
                content = "[ファイルが存在しません]"

            # プロンプト作成（改善コード生成を含む）
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
            try:
                if "gpt-5-codex" in model.lower():
                    # Responses API使用
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
                    # Chat Completions API使用（フォールバック）
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

                results.append({
                    "path": file_path,
                    "severity": severity,
                    "problems": problems,
                    "original_code": content[:1000],  # 最初の1000文字
                    "analysis": analysis
                })

                # API制限対策
                time.sleep(0.5)

            except Exception as e:
                print(f"  [ERROR] {file_path}: {str(e)[:100]}")
                results.append({
                    "path": file_path,
                    "severity": severity,
                    "problems": problems,
                    "original_code": content[:1000],
                    "analysis": f"[エラー: {str(e)[:200]}]"
                })

        # バッチ結果を保存
        output_file = f"reports/AI_detailed_batch{batch_num}_gpt5_with_fixes.md"
        save_detailed_batch_report(batch_num, results, output_file)

        print(f"[BATCH {batch_num}] 完了 -> {output_file}")
        return results

    except Exception as e:
        print(f"[ERROR] Batch {batch_num} failed: {str(e)}")
        return None

def save_detailed_batch_report(batch_num: int, results: List[Dict], output_file: str):
    """詳細バッチレポートを保存（改善コード含む）"""
    with open(output_file, "w", encoding="utf-8") as f:
        f.write(f"# AI詳細分析レポート（改善コード付き） - バッチ{batch_num}\n\n")
        f.write(f"生成日時: {time.strftime('%Y-%m-%d %H:%M:%S')}\n")
        f.write(f"使用モデル: {os.environ.get('OPENAI_MODEL', 'gpt-4o')}\n")
        f.write(f"分析ファイル数: {len(results)}\n\n")

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

            # 重要度バッジ
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
    merged_content.append("# 完全コード分析レポート - 全問題箇所と改善コード\n\n")
    merged_content.append(f"生成日時: {time.strftime('%Y-%m-%d %H:%M:%S')}\n")
    merged_content.append(f"使用モデル: {os.environ.get('OPENAI_MODEL', 'gpt-4o')}\n")
    merged_content.append(f"バッチ数: {batch_count}\n\n")

    total_files = 0
    total_critical = 0
    total_high = 0
    total_medium = 0

    # 各バッチファイルを読み込み
    for batch_num in range(1, batch_count + 1):
        batch_file = f"reports/AI_detailed_batch{batch_num}_gpt5_with_fixes.md"
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

                # コンテンツを追加（ヘッダーを除く）
                lines = content.split("\n")
                for line in lines[10:]:  # ヘッダーをスキップ
                    merged_content.append(line + "\n")

                total_files += min(BATCH_SIZE, len(re.findall(r'^## \d+\.', content, re.MULTILINE)))

    # 全体サマリーを先頭に挿入
    summary = []
    summary.append("## 全体統計\n\n")
    summary.append(f"- **総分析ファイル数**: {total_files}件\n")
    summary.append(f"- [緊急] **緊急対応必要**: {total_critical}件\n")
    summary.append(f"- [高] **高優先度**: {total_high}件\n")
    summary.append(f"- [中] **中優先度**: {total_medium}件\n")
    summary.append(f"- **合計問題ファイル**: {total_critical + total_high + total_medium}件\n\n")
    summary.append("---\n\n")

    # サマリーを先頭に挿入
    merged_content[4:4] = summary

    # 統合ファイル保存
    output_file = "reports/COMPLETE_CODE_ANALYSIS_WITH_FIXES_GPT5.md"
    with open(output_file, "w", encoding="utf-8") as f:
        f.writelines(merged_content)

    print(f"[SUCCESS] 最終統合レポート生成: {output_file}")

    # ファイルサイズ確認
    file_size_mb = Path(output_file).stat().st_size / 1024 / 1024
    print(f"[INFO] ファイルサイズ: {file_size_mb:.2f} MB")

    if file_size_mb > 25:
        print("[WARNING] ファイルサイズが25MBを超えています。閲覧時に注意してください。")

def main():
    """メイン処理"""
    print("=" * 60)
    print("問題ファイル抽出＆詳細分析システム (GPT-5-Codex)")
    print("=" * 60)

    # 1. 問題ファイルを抽出
    problem_files = extract_problem_files()

    if len(problem_files) == 0:
        print("[INFO] 危険度5以上のファイルが見つかりません")
        print("[INFO] danger_analysis_ALLレポートを確認してください")
        return

    # 2. バッチ作成
    batches = create_batches(problem_files)

    # 3. 各バッチを詳細分析
    print(f"\n[INFO] 詳細分析開始（{len(batches)}バッチ、{len(problem_files)}ファイル）")
    print("[INFO] 自動実行モードで処理を開始します...")

    for batch_num, batch in enumerate(batches, 1):
        analyze_batch_with_gpt5_codex(batch_num, batch)

        # 進捗表示
        progress = batch_num / len(batches) * 100
        print(f"[PROGRESS] {progress:.1f}% 完了 ({batch_num}/{len(batches)})")

        # API制限対策（バッチ間で少し待機）
        if batch_num < len(batches):
            print("[INFO] 次のバッチまで3秒待機...")
            time.sleep(3)

    # 4. レポート統合
    merge_all_reports(len(batches))

    print("\n" + "=" * 60)
    print("[SUCCESS] 全処理完了！")
    print("=" * 60)
    print("\n[INFO] 生成されたファイル:")
    print(f"  - 個別バッチ: reports/AI_detailed_batch*_gpt5_with_fixes.md")
    print(f"  - 統合レポート: reports/COMPLETE_CODE_ANALYSIS_WITH_FIXES_GPT5.md")

if __name__ == "__main__":
    main()
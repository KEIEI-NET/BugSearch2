#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
全危険ファイルの詳細AI分析とバッチ処理
GPT-5-Codex対応版
"""
import json
import os
import sys
import time
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

def load_index():
    """インデックスファイルを読み込み、危険度でフィルタリング"""
    index_file = ".advice_index.jsonl"
    if not Path(index_file).exists():
        print("[ERROR] インデックスファイルが見つかりません。先に index コマンドを実行してください。")
        sys.exit(1)

    dangerous_files = []
    total_files = 0

    with open(index_file, "r", encoding="utf-8") as f:
        for line in f:
            total_files += 1
            try:
                entry = json.loads(line)
                severity = entry.get("severity", 0)
                if severity >= MIN_SEVERITY:
                    dangerous_files.append(entry)
            except:
                continue

    print(f"[INFO] 総ファイル数: {total_files}")
    print(f"[INFO] 危険度{MIN_SEVERITY}以上: {len(dangerous_files)}ファイル")

    # 危険度でソート（高い順）
    dangerous_files.sort(key=lambda x: x.get("severity", 0), reverse=True)
    return dangerous_files

def create_batches(files: List[Dict]) -> List[List[Dict]]:
    """ファイルをバッチに分割"""
    batches = []
    for i in range(0, len(files), BATCH_SIZE):
        batch = files[i:i + BATCH_SIZE]
        batches.append(batch)
    print(f"[INFO] {len(batches)}個のバッチを作成")
    return batches

def analyze_batch_with_gpt5_codex(batch_num: int, files: List[Dict]):
    """GPT-5-Codexでバッチ分析"""
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

            # ファイル内容を読み込み（エラー処理付き）
            content = ""
            if Path(file_path).exists():
                try:
                    with open(file_path, "r", encoding="utf-8", errors="ignore") as f:
                        content = f.read()[:3000]  # 最初の3000文字
                except:
                    content = "[読み込みエラー]"

            # プロンプト作成
            prompt = f"""
以下のコードファイルの問題を分析し、具体的な改善案を提示してください。

ファイル: {file_path}
危険度スコア: {severity}
検出された問題: {json.dumps(problems, ensure_ascii=False)}

コード:
```
{content}
```

以下の形式で回答してください：
1. 問題の詳細説明
2. 影響範囲と重要度
3. 具体的な修正コード（Before/After形式）
4. 追加の改善提案
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
                            {"role": "system", "content": "You are a senior code reviewer."},
                            {"role": "user", "content": prompt}
                        ],
                        max_tokens=2000,
                        temperature=0.5
                    )

                    if response.choices and response.choices[0].message.content:
                        analysis = response.choices[0].message.content
                    else:
                        analysis = "[分析失敗: 空レスポンス]"

                results.append({
                    "path": file_path,
                    "severity": severity,
                    "problems": problems,
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
                    "analysis": f"[エラー: {str(e)[:200]}]"
                })

        # バッチ結果を保存
        output_file = f"reports/AI_analysis_batch{batch_num}_gpt5.md"
        save_batch_report(batch_num, results, output_file)

        print(f"[BATCH {batch_num}] 完了 -> {output_file}")
        return results

    except Exception as e:
        print(f"[ERROR] Batch {batch_num} failed: {str(e)}")
        return None

def save_batch_report(batch_num: int, results: List[Dict], output_file: str):
    """バッチレポートを保存"""
    with open(output_file, "w", encoding="utf-8") as f:
        f.write(f"# AI詳細分析レポート - バッチ{batch_num}\n\n")
        f.write(f"生成日時: {time.strftime('%Y-%m-%d %H:%M:%S')}\n")
        f.write(f"使用モデル: {os.environ.get('OPENAI_MODEL', 'gpt-4o')}\n")
        f.write(f"分析ファイル数: {len(results)}\n\n")

        for idx, result in enumerate(results, 1):
            f.write(f"## {idx}. {result['path']}\n\n")
            f.write(f"**危険度**: {result['severity']}\n")
            f.write(f"**検出問題**: {', '.join(result['problems'])}\n\n")
            f.write("### AI分析結果\n\n")
            f.write(result['analysis'])
            f.write("\n\n---\n\n")

def merge_all_reports(batch_count: int):
    """全バッチレポートを統合"""
    print("\n[INFO] レポート統合開始")

    merged_content = []
    merged_content.append("# 完全AI分析レポート - 全バッチ統合版\n\n")
    merged_content.append(f"生成日時: {time.strftime('%Y-%m-%d %H:%M:%S')}\n")
    merged_content.append(f"使用モデル: {os.environ.get('OPENAI_MODEL', 'gpt-4o')}\n\n")

    total_files = 0
    for batch_num in range(1, batch_count + 1):
        batch_file = f"reports/AI_analysis_batch{batch_num}_gpt5.md"
        if Path(batch_file).exists():
            with open(batch_file, "r", encoding="utf-8") as f:
                content = f.read()
                # ヘッダー部分を除去
                lines = content.split("\n")
                for line in lines[5:]:  # ヘッダーをスキップ
                    merged_content.append(line + "\n")
            total_files += 500  # BATCH_SIZE

    merged_content.insert(3, f"総分析ファイル数: {total_files}\n")

    # 統合ファイル保存
    output_file = "reports/AI_COMPLETE_ANALYSIS_GPT5.md"
    with open(output_file, "w", encoding="utf-8") as f:
        f.writelines(merged_content)

    print(f"[INFO] 統合レポート生成完了: {output_file}")
    print(f"[INFO] ファイルサイズ: {Path(output_file).stat().st_size / 1024 / 1024:.2f} MB")

def main():
    """メイン処理"""
    print("=" * 60)
    print("全危険ファイルAI分析システム (GPT-5-Codex)")
    print("=" * 60)

    # 1. インデックス読み込み
    dangerous_files = load_index()

    if len(dangerous_files) == 0:
        print("[INFO] 危険なファイルが見つかりません")
        return

    # 2. バッチ作成
    batches = create_batches(dangerous_files)

    # 3. 各バッチを分析
    print(f"\n[INFO] 分析開始（{len(batches)}バッチ）")

    for batch_num, batch in enumerate(batches, 1):
        analyze_batch_with_gpt5_codex(batch_num, batch)

        # 進捗表示
        progress = batch_num / len(batches) * 100
        print(f"[PROGRESS] {progress:.1f}% 完了 ({batch_num}/{len(batches)})")

        # API制限対策（バッチ間で少し待機）
        if batch_num < len(batches):
            time.sleep(2)

    # 4. レポート統合
    merge_all_reports(len(batches))

    print("\n" + "=" * 60)
    print("分析完了！")
    print("=" * 60)

if __name__ == "__main__":
    main()
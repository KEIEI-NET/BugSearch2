#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
全体テスト実行スクリプト - タイムアウト監視付き
"""
import subprocess
import sys
import time
import threading
import os

def run_with_monitoring(cmd, timeout=300, check_interval=10):
    """コマンドを実行して進捗を監視"""
    print(f"実行コマンド: {' '.join(cmd)}")
    print(f"タイムアウト: {timeout}秒")
    print("-" * 60)

    process = subprocess.Popen(
        cmd,
        stdout=subprocess.PIPE,
        stderr=subprocess.STDOUT,
        text=True,
        encoding='utf-8',
        errors='replace'
    )

    start_time = time.time()
    last_output_time = start_time
    output_lines = []

    def read_output():
        nonlocal last_output_time
        for line in process.stdout:
            current_time = time.time()
            elapsed = current_time - start_time
            output_lines.append(line.rstrip())
            print(f"[{elapsed:6.1f}s] {line.rstrip()}")
            last_output_time = current_time

            # メモリ節約のため、出力行数を制限
            if len(output_lines) > 1000:
                output_lines.pop(0)

    # 出力読み取りスレッド
    reader_thread = threading.Thread(target=read_output)
    reader_thread.daemon = True
    reader_thread.start()

    # タイムアウト監視
    while process.poll() is None:
        current_time = time.time()
        elapsed = current_time - start_time

        if elapsed > timeout:
            print(f"\n⚠️ タイムアウト ({timeout}秒) - プロセスを終了します")
            process.terminate()
            time.sleep(2)
            if process.poll() is None:
                process.kill()
            return False

        time.sleep(check_interval)

    reader_thread.join(timeout=5)

    elapsed_total = time.time() - start_time
    print(f"\n✅ 処理完了 (総時間: {elapsed_total:.1f}秒)")
    return process.returncode == 0

def main():
    print("=" * 60)
    print("コードレビューシステム 全体テスト")
    print("=" * 60)

    # Step 1: インデックス作成（C#ソースのみ、1MB制限）
    print("\n[Step 1] インデックス作成（C#ソース、1MB制限）")
    cmd1 = [sys.executable, "codex_review_ultimate.py", "index",
            "src/csharp", "--max-file-mb", "1"]
    if not run_with_monitoring(cmd1, timeout=120):
        print("インデックス作成失敗")
        return 1

    # インデックスファイルのサイズ確認
    if os.path.exists(".advice_index.jsonl"):
        size = os.path.getsize(".advice_index.jsonl") / (1024 * 1024)
        print(f"インデックスファイルサイズ: {size:.2f} MB")

    # Step 2: ベクトル化
    print("\n[Step 2] ベクトル化")
    cmd2 = [sys.executable, "codex_review_ultimate.py", "vectorize"]
    if not run_with_monitoring(cmd2, timeout=60):
        print("ベクトル化失敗")
        return 1

    # Step 3: 解析実行（上位30ファイル）
    print("\n[Step 3] コードレビュー実行（上位30ファイル）")
    cmd3 = [sys.executable, "codex_review_ultimate.py", "query",
            "データベース SELECT", "--topk", "30", "--out", "reports/test_full"]
    if not run_with_monitoring(cmd3, timeout=300):
        print("レビュー実行失敗")
        return 1

    # レポート確認
    print("\n[結果確認]")
    reports = [
        "reports/test_full_rules.md",
        "reports/test_full_ai.md"
    ]

    for report in reports:
        if os.path.exists(report):
            size = os.path.getsize(report) / 1024
            print(f"✅ {report}: {size:.1f} KB")
            # 最初の数行を表示
            with open(report, 'r', encoding='utf-8') as f:
                lines = f.readlines()[:5]
                print(f"  内容プレビュー:")
                for line in lines:
                    print(f"    {line.rstrip()[:80]}")
        else:
            print(f"❌ {report}: ファイルなし")

    print("\n=" * 60)
    print("テスト完了")
    print("=" * 60)
    return 0

if __name__ == "__main__":
    sys.exit(main())
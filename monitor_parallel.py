#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
並列処理の進捗監視・再開スクリプト
"""
import json
import time
import sys
import os
from pathlib import Path
from datetime import datetime, timedelta

# 設定
PROGRESS_FILE = ".batch_progress_parallel.json"
DANGER_FILE = "reports/danger_analysis_ALL"
LOG_FILE = "parallel_processing.log"
CHECK_INTERVAL = 5  # 監視間隔（秒）

def load_progress():
    """進捗状態を読み込み"""
    if Path(PROGRESS_FILE).exists():
        with open(PROGRESS_FILE, "r", encoding="utf-8") as f:
            return json.load(f)
    return {"completed_files": {}, "last_batch": 0, "cache_hits": 0}

def get_total_problem_files():
    """問題ファイル総数を取得"""
    import re
    if not Path(DANGER_FILE).exists():
        return 0

    with open(DANGER_FILE, 'r', encoding='utf-8') as f:
        content = f.read()

    sections = content.split('###')[1:]
    problem_count = 0

    for section in sections:
        lines = section.strip().split('\n')
        for line in lines:
            if 'スコア:' in line:
                score_match = re.search(r'スコア:\s*(\d+)', line)
                if score_match:
                    score = int(score_match.group(1))
                    if score >= 5:
                        problem_count += 1
                        break

    return problem_count

def format_time(seconds):
    """秒数を読みやすい形式に変換"""
    if seconds < 60:
        return f"{seconds:.0f}秒"
    elif seconds < 3600:
        return f"{seconds/60:.1f}分"
    else:
        hours = seconds / 3600
        return f"{hours:.1f}時間"

def write_log(message):
    """ログファイルに書き込み"""
    timestamp = datetime.now().strftime('%Y-%m-%d %H:%M:%S')
    with open(LOG_FILE, 'a', encoding='utf-8') as f:
        f.write(f"[{timestamp}] {message}\n")
    print(message)

def monitor_progress():
    """進捗を監視"""
    total_files = get_total_problem_files()
    if total_files == 0:
        print("[ERROR] 問題ファイルが見つかりません。先にインデックスと分析を実行してください。")
        return

    print("="*70)
    print("並列処理進捗モニター")
    print("="*70)
    print(f"問題ファイル総数: {total_files}")
    print(f"監視間隔: {CHECK_INTERVAL}秒")
    print("Ctrl+Cで監視を終了\n")

    start_time = time.time()
    last_completed = 0
    last_check_time = start_time
    stall_count = 0
    max_stall_count = 60  # 5分間進捗なし = 60回チェック

    write_log(f"監視開始 - 総ファイル数: {total_files}")

    try:
        while True:
            # 進捗読み込み
            progress = load_progress()
            completed = len(progress["completed_files"])
            batch_num = progress["last_batch"]
            cache_hits = progress["cache_hits"]

            # 進捗率計算
            progress_percent = (completed / total_files) * 100 if total_files > 0 else 0

            # 処理速度計算
            current_time = time.time()
            elapsed = current_time - start_time
            time_since_last = current_time - last_check_time
            files_since_last = completed - last_completed

            if files_since_last > 0:
                current_speed = files_since_last / time_since_last
                stall_count = 0  # 進捗があったのでリセット
            else:
                current_speed = 0
                stall_count += 1

            # 残り時間推定
            if completed > 0:
                avg_speed = completed / elapsed
                remaining = total_files - completed
                if avg_speed > 0:
                    eta = remaining / avg_speed
                else:
                    eta = 0
            else:
                eta = 0
                avg_speed = 0

            # 表示更新
            os.system('cls' if os.name == 'nt' else 'clear')
            print("="*70)
            print("並列処理進捗モニター")
            print("="*70)
            print(f"現在時刻: {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}")
            print(f"経過時間: {format_time(elapsed)}")
            print()

            # プログレスバー
            bar_length = 50
            filled_length = int(bar_length * completed / total_files)
            bar = '#' * filled_length + '-' * (bar_length - filled_length)

            print(f"進捗: [{bar}] {progress_percent:.1f}%")
            print(f"処理済み: {completed}/{total_files} ファイル")
            print()

            print(f"現在のバッチ: {batch_num}")
            print(f"キャッシュヒット: {cache_hits}件")
            print(f"現在の速度: {current_speed:.1f} files/s")
            print(f"平均速度: {avg_speed:.1f} files/s")

            if eta > 0:
                print(f"推定残り時間: {format_time(eta)}")
                completion_time = datetime.now() + timedelta(seconds=eta)
                print(f"完了予定: {completion_time.strftime('%H:%M:%S')}")

            # ステータス表示
            print()
            if stall_count > 0:
                print(f"[WARNING] 進捗なし: {stall_count * CHECK_INTERVAL}秒")
                if stall_count >= max_stall_count:
                    print("[ERROR] 5分以上進捗がありません。プロセスが停止している可能性があります。")
                    write_log(f"エラー検出: 5分以上進捗なし（処理済み: {completed}/{total_files}）")

                    # 再開を提案
                    print("\n対処法:")
                    print("1. プロセスが実行中か確認: ps aux | grep parallel")
                    print("2. 再開する場合: py extract_and_batch_parallel.py")
                    print("3. 最初からやり直す場合: rm .batch_progress_parallel.json")
                    break
            else:
                print("[STATUS] 正常に処理中...")

            # 完了チェック
            if completed >= total_files:
                print("\n" + "="*70)
                print("[SUCCESS] 全ファイルの処理が完了しました！")
                print(f"総処理時間: {format_time(elapsed)}")
                print(f"平均処理速度: {avg_speed:.1f} files/s")
                print(f"キャッシュヒット: {cache_hits}件")
                print("="*70)

                write_log(f"処理完了 - 総時間: {format_time(elapsed)}, 平均速度: {avg_speed:.1f} files/s")
                break

            # 次回チェックまで待機
            last_completed = completed
            last_check_time = current_time

            # 次回更新までのカウントダウン
            for i in range(CHECK_INTERVAL, 0, -1):
                print(f"\r次回更新まで: {i}秒  ", end='', flush=True)
                time.sleep(1)

    except KeyboardInterrupt:
        print("\n\n監視を終了しました。")
        write_log(f"監視終了 - 処理済み: {completed}/{total_files}")

def show_resume_info():
    """再開情報を表示"""
    progress = load_progress()
    total_files = get_total_problem_files()
    completed = len(progress["completed_files"])

    print("\n【再開情報】")
    print("-"*50)
    print(f"処理済み: {completed}/{total_files} ファイル")
    print(f"最終バッチ: {progress['last_batch']}")
    print(f"キャッシュヒット: {progress['cache_hits']}")

    if completed > 0:
        print("\n再開方法:")
        print("1. 続きから処理: py extract_and_batch_parallel.py")
        print("2. 最初からやり直し:")
        print("   - Windows: del .batch_progress_parallel.json")
        print("   - Mac/Linux: rm .batch_progress_parallel.json")
        print("   その後: py extract_and_batch_parallel.py")

    # 最近処理したファイルを表示
    if progress["completed_files"]:
        recent_files = list(progress["completed_files"].keys())[-5:]
        print("\n最近処理したファイル:")
        for f in recent_files:
            print(f"  - {f}")

def main():
    """メイン処理"""
    import argparse
    parser = argparse.ArgumentParser(description="並列処理の進捗監視")
    parser.add_argument('--interval', type=int, default=5, help='監視間隔（秒）')
    parser.add_argument('--resume', action='store_true', help='再開情報を表示')
    args = parser.parse_args()

    if args.resume:
        show_resume_info()
    else:
        global CHECK_INTERVAL
        CHECK_INTERVAL = args.interval
        monitor_progress()

if __name__ == "__main__":
    main()
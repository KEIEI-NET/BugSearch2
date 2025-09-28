#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
並列処理パフォーマンスベンチマーク
"""
import time
import threading
from concurrent.futures import ThreadPoolExecutor, as_completed
import statistics

def simulate_api_call(file_id: int, delay: float = 0.5) -> dict:
    """API呼び出しのシミュレーション"""
    time.sleep(delay)  # API処理時間のシミュレーション
    return {
        "file_id": file_id,
        "processed": True,
        "time": delay
    }

def test_sequential(num_files: int, delay: float) -> float:
    """シーケンシャル処理のテスト"""
    start = time.time()
    results = []

    for i in range(num_files):
        result = simulate_api_call(i, delay)
        results.append(result)

    elapsed = time.time() - start
    return elapsed

def test_parallel(num_files: int, delay: float, workers: int) -> float:
    """並列処理のテスト"""
    start = time.time()
    results = []

    with ThreadPoolExecutor(max_workers=workers) as executor:
        futures = {
            executor.submit(simulate_api_call, i, delay): i
            for i in range(num_files)
        }

        for future in as_completed(futures):
            try:
                result = future.result(timeout=10)
                results.append(result)
            except Exception as e:
                print(f"Error: {e}")

    elapsed = time.time() - start
    return elapsed

def run_benchmark():
    """ベンチマーク実行"""
    print("="*60)
    print("並列処理パフォーマンスベンチマーク")
    print("="*60)

    # テストパラメータ
    num_files = 30  # 処理するファイル数
    api_delay = 0.2  # API処理時間（秒）
    worker_counts = [1, 3, 5, 10]  # テストする並列数

    print(f"\nテスト条件:")
    print(f"  - ファイル数: {num_files}")
    print(f"  - API処理時間: {api_delay}秒/ファイル")
    print(f"  - 理論最小時間: {num_files * api_delay}秒")
    print()

    results = {}

    # シーケンシャル処理
    print("シーケンシャル処理テスト...")
    seq_time = test_sequential(num_files, api_delay)
    results["sequential"] = seq_time
    print(f"  処理時間: {seq_time:.1f}秒")
    print(f"  速度: {num_files/seq_time:.1f}files/s")

    # 並列処理テスト
    print("\n並列処理テスト:")
    for workers in worker_counts:
        print(f"  {workers}並列ワーカー...")
        par_time = test_parallel(num_files, api_delay, workers)
        results[f"parallel_{workers}"] = par_time
        speedup = seq_time / par_time
        print(f"    処理時間: {par_time:.1f}秒")
        print(f"    速度: {num_files/par_time:.1f}files/s")
        print(f"    高速化率: {speedup:.1f}x")

    # 結果サマリー
    print("\n" + "="*60)
    print("結果サマリー")
    print("="*60)
    print(f"{'処理方式':<20} {'処理時間':<10} {'速度':<15} {'高速化率'}")
    print("-"*60)

    for key, time_val in results.items():
        method = key.replace("_", " ").title()
        speed = num_files / time_val
        speedup = results["sequential"] / time_val
        print(f"{method:<20} {time_val:>8.1f}秒 {speed:>10.1f}f/s {speedup:>8.1f}x")

    # 推定改善効果
    print("\n実際のファイル処理での推定効果:")
    print("-"*40)
    real_files = 2753
    real_api_time = 2.0  # GPT-5-Codexの推定処理時間

    seq_estimate = real_files * real_api_time / 3600
    par_10_estimate = (real_files * real_api_time / 10) / 3600

    print(f"2753ファイル処理（GPT-5-Codex）:")
    print(f"  シーケンシャル: 約{seq_estimate:.1f}時間")
    print(f"  10並列: 約{par_10_estimate:.1f}時間")
    print(f"  改善率: {seq_estimate/par_10_estimate:.1f}倍高速")

if __name__ == "__main__":
    run_benchmark()
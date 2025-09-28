#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
並列処理テストスクリプト
"""
import sys
import os
import time
from pathlib import Path

# 親ディレクトリをパスに追加
sys.path.append(str(Path(__file__).parent))

# 環境変数を仮設定（テスト用）
os.environ["PARALLEL_WORKERS"] = "3"  # テスト用に少なく設定

def test_parallel_processing():
    """並列処理のテスト"""
    print("="*60)
    print("並列処理テスト開始")
    print("="*60)

    # インポートテスト
    try:
        from extract_and_batch_parallel import (
            extract_problem_files,
            RateLimiter,
            get_file_hash,
            select_model_for_severity
        )
        print("[OK] モジュールのインポート成功")
    except Exception as e:
        print(f"[ERROR] インポート失敗: {e}")
        return False

    # 問題ファイル抽出テスト
    try:
        problem_files = extract_problem_files()
        print(f"[OK] 問題ファイル抽出: {len(problem_files)}件")

        for file in problem_files:
            print(f"  - {file['path']}: スコア {file['severity']}")
    except Exception as e:
        print(f"[ERROR] ファイル抽出失敗: {e}")
        return False

    # レート制限テスト
    try:
        limiter = RateLimiter(max_calls_per_minute=10)
        print("\n[TEST] レート制限テスト（10 calls/min）")

        start = time.time()
        for i in range(5):
            limiter.wait_if_needed()
            print(f"  Call {i+1}: OK")
        elapsed = time.time() - start
        print(f"[OK] レート制限テスト完了 ({elapsed:.1f}秒)")
    except Exception as e:
        print(f"[ERROR] レート制限テスト失敗: {e}")

    # モデル選択テスト
    print("\n[TEST] モデル選択ロジックテスト")
    test_cases = [
        (20, "gpt-5-codex", "high"),
        (12, "gpt-4o", None),
        (7, "gpt-4o-mini", None)
    ]

    for severity, expected_model, expected_effort in test_cases:
        model, effort = select_model_for_severity(severity)
        if model == expected_model and effort == expected_effort:
            print(f"  スコア {severity}: {model} - OK")
        else:
            print(f"  スコア {severity}: 期待={expected_model}, 実際={model} - NG")

    # ファイルハッシュテスト
    print("\n[TEST] ファイルハッシュ機能テスト")
    test_files = ["test/sample1.py", "test/sample2.js", "test/sample3.go"]

    for file_path in test_files:
        hash_value = get_file_hash(file_path)
        if hash_value:
            print(f"  {file_path}: {hash_value[:16]}... - OK")
        else:
            print(f"  {file_path}: ハッシュ生成失敗 - NG")

    print("\n" + "="*60)
    print("テスト完了")
    print("="*60)
    return True

if __name__ == "__main__":
    # APIキーの確認（実際のAPI呼び出しはしない）
    if not os.environ.get("OPENAI_API_KEY"):
        print("[WARNING] OPENAI_API_KEYが設定されていません")
        print("         実際の実行時は.envファイルに設定してください")
        # テスト用のダミーキーを設定
        os.environ["OPENAI_API_KEY"] = "dummy-key-for-testing"

    success = test_parallel_processing()
    sys.exit(0 if success else 1)
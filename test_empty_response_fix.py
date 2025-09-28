#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
GPT-5空レスポンス対策テストスクリプト
パラメータ調整とリトライ機能の検証
"""
import os
import sys
import time
from pathlib import Path

# .envファイル読み込み
ENV_FILE = ".env"
if Path(ENV_FILE).exists():
    print(f"[INFO] {ENV_FILE}ファイルを読み込み中...")
    with open(ENV_FILE, "r", encoding="utf-8") as f:
        for line in f:
            line = line.strip()
            if "=" in line and not line.startswith("#"):
                key, val = line.split("=", 1)
                os.environ[key] = val

# OpenAI API テスト
try:
    from openai import OpenAI
    print("\n[TEST] 空レスポンス対策のテスト開始")

    api_key = os.environ.get("OPENAI_API_KEY")
    model = os.environ.get("OPENAI_MODEL", "gpt-5")

    if not api_key:
        print("[ERROR] OPENAI_API_KEY が設定されていません")
        sys.exit(1)

    print(f"[INFO] テストモデル: {model}")
    client = OpenAI(api_key=api_key)

    # テスト用プロンプト
    system_content = "You are a code reviewer."
    test_prompt = """
    以下のコードの問題点を指摘してください：
    for order in orders:
        items = db.query(f"SELECT * FROM items WHERE order_id = {order.id}")
    """

    messages = [
        {"role": "system", "content": system_content},
        {"role": "user", "content": test_prompt}
    ]

    # 段階的なパラメータテスト
    test_configs = [
        {
            "name": "最小設定（空レスポンス誘発）",
            "params": {
                "max_tokens": 50,
                "temperature": 0.1
            }
        },
        {
            "name": "標準設定",
            "params": {
                "max_tokens": 2000,
                "temperature": 0.5
            }
        },
        {
            "name": "強化設定（空レスポンス対策）",
            "params": {
                "max_output_tokens": 4000,
                "max_tokens": 4000,
                "temperature": 0.7,
                "response_format": {"type": "text"}
            }
        }
    ]

    for config in test_configs:
        print(f"\n[TEST] {config['name']}")
        print(f"  パラメータ: {config['params']}")

        params = {
            "model": model,
            "messages": messages,
            "timeout": 30
        }
        params.update(config['params'])

        # GPT-5系の特別パラメータ
        if "gpt-5" in model:
            params["verbosity"] = "medium"
            params["reasoning_effort"] = "medium"

        try:
            resp = client.chat.completions.create(**params)

            if resp.choices and resp.choices[0].message.content:
                content = resp.choices[0].message.content.strip()
                if content:
                    print(f"  結果: [OK] 正常レスポンス（{len(content)}文字）")
                    print(f"  内容冒頭: {content[:100]}...")
                else:
                    print(f"  結果: [WARNING] 空レスポンス（空文字列）")
            else:
                print(f"  結果: [WARNING] 空レスポンス（choices空）")

        except Exception as e:
            error_msg = str(e)
            if "max_output_tokens" in error_msg or "verbosity" in error_msg:
                print(f"  結果: [ERROR] パラメータ非対応")
            else:
                print(f"  結果: [ERROR] エラー: {error_msg[:100]}")

        time.sleep(1)  # API制限対策

    print("\n[TEST] リトライ機能テスト")
    print("空レスポンス時の自動リトライをシミュレート...")

    # リトライシミュレーション
    retry_count = 0
    max_retries = 3
    success = False

    initial_params = {
        "model": model,
        "messages": messages,
        "max_tokens": 100,  # 意図的に少なくして空レスポンスを誘発
        "temperature": 0.1,
        "timeout": 30
    }

    while retry_count < max_retries and not success:
        retry_count += 1
        print(f"\n  試行 {retry_count}/{max_retries}")

        if retry_count > 1:
            # パラメータ調整
            initial_params["max_tokens"] = initial_params.get("max_tokens", 100) * 2
            initial_params["temperature"] = min(initial_params.get("temperature", 0.1) + 0.3, 1.0)
            print(f"    パラメータ調整: max_tokens={initial_params['max_tokens']}, temp={initial_params['temperature']}")

        try:
            resp = client.chat.completions.create(**initial_params)
            if resp.choices and resp.choices[0].message.content:
                content = resp.choices[0].message.content.strip()
                if content:
                    print(f"    結果: [OK] 成功（{len(content)}文字）")
                    success = True
                else:
                    print(f"    結果: [WARNING] 空レスポンス、再試行...")
            else:
                print(f"    結果: [WARNING] 空レスポンス、再試行...")
        except Exception as e:
            print(f"    結果: [ERROR] エラー: {str(e)[:50]}")

        if not success and retry_count < max_retries:
            time.sleep(1)

    if not success:
        print(f"\n  最終結果: [FAIL] {max_retries}回試行後も失敗")
        print("  → フォールバックモデル（gpt-4o）への切り替えが推奨されます")
    else:
        print(f"\n  最終結果: [SUCCESS] {retry_count}回目で成功")

    print("\n[INFO] テスト完了")
    print("[INFO] codex_review_severity.pyにはこれらの対策がすべて実装済みです")

except ImportError:
    print("[ERROR] openaiライブラリがインストールされていません")
    print("実行: pip install openai")
    sys.exit(1)
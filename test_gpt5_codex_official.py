#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
GPT-5-Codex公式形式テスト
OpenAI公式ドキュメントに基づいた実装
"""
import os
import sys
from pathlib import Path

# .env読み込み
ENV_FILE = ".env"
if Path(ENV_FILE).exists():
    with open(ENV_FILE, "r", encoding="utf-8") as f:
        for line in f:
            line = line.strip()
            if "=" in line and not line.startswith("#"):
                key, val = line.split("=", 1)
                os.environ[key] = val

def test_basic_code_generation():
    """基本的なコード生成テスト"""
    try:
        from openai import OpenAI

        api_key = os.environ.get("OPENAI_API_KEY")
        if not api_key:
            print("[ERROR] OPENAI_API_KEY not set")
            return False

        print("[TEST] Basic code generation with GPT-5-Codex")
        client = OpenAI(api_key=api_key)

        # 公式ドキュメントの例に従う
        test_cases = [
            {
                "name": "FizzBuzz",
                "input": "PythonでFizzBuzz関数を作って"
            },
            {
                "name": "Bubble Sort",
                "input": "バブルソートのPythonコードを書いて"
            },
            {
                "name": "Code Review",
                "input": """
以下のコードをレビューして改善案を提示：
def calc(orders):
    total = 0
    for order in orders:
        items = db.query(f"SELECT * FROM items WHERE order_id = {order.id}")
        for item in items:
            total += item.price
    return total
"""
            }
        ]

        success_count = 0

        for test in test_cases:
            print(f"\n[TEST] {test['name']}")
            print(f"  Input: {test['input'][:50]}...")

            try:
                # 公式クライアントのresponses.create メソッド
                response = client.responses.create(
                    model="gpt-5-codex",
                    input=test['input'],
                    reasoning={"effort": "high"}
                )

                # output_text フィールドから結果取得
                if hasattr(response, 'output_text'):
                    output = response.output_text
                    if output and output.strip():
                        print(f"  [SUCCESS] Got {len(output)} chars response")
                        print(f"  Preview: {output[:100]}...")
                        success_count += 1
                    else:
                        print(f"  [WARNING] Empty output_text")
                else:
                    print(f"  [WARNING] No output_text field in response")
                    print(f"  Response: {response}")

            except Exception as e:
                error_msg = str(e)
                print(f"  [ERROR] {error_msg[:150]}")

                # エラー診断
                if "400" in error_msg:
                    print("  [DIAGNOSIS] Bad Request - Check input format")
                elif "404" in error_msg:
                    print("  [DIAGNOSIS] Model not found - GPT-5-Codex may not be available")
                elif "responses" not in dir(client):
                    print("  [DIAGNOSIS] OpenAI client doesn't have responses method")
                    print("  [INFO] This indicates the Responses API is not yet available")

        print(f"\n[SUMMARY] {success_count}/{len(test_cases)} tests succeeded")
        return success_count > 0

    except ImportError:
        print("[ERROR] OpenAI library not installed")
        print("Run: pip install openai")
        return False
    except Exception as e:
        print(f"[ERROR] Unexpected error: {str(e)}")
        return False

def test_alternative_approach():
    """代替アプローチ: 直接HTTPリクエスト"""
    import requests

    api_key = os.environ.get("OPENAI_API_KEY")
    if not api_key:
        print("[ERROR] OPENAI_API_KEY not set")
        return False

    print("\n[TEST] Direct HTTP request to Responses API")

    url = "https://api.openai.com/v1/responses"
    headers = {
        "Authorization": f"Bearer {api_key}",
        "Content-Type": "application/json"
    }

    data = {
        "model": "gpt-5-codex",
        "input": "# Write a hello world function in Python"
    }

    try:
        response = requests.post(url, headers=headers, json=data, timeout=30)

        print(f"  Status Code: {response.status_code}")

        if response.status_code == 200:
            result = response.json()
            output = result.get("output_text", "")
            if output:
                print(f"  [SUCCESS] Got response: {len(output)} chars")
                print(f"  Preview: {output[:100]}...")
                return True
            else:
                print(f"  [WARNING] Empty output_text")
                print(f"  Full response: {result}")
        else:
            print(f"  [ERROR] {response.status_code}: {response.text[:200]}")

    except Exception as e:
        print(f"  [ERROR] Request failed: {str(e)}")

    return False

if __name__ == "__main__":
    print("=" * 60)
    print("GPT-5-Codex Responses API Official Test")
    print("=" * 60)

    # OpenAIクライアントテスト
    client_success = test_basic_code_generation()

    # 直接HTTPテスト
    http_success = test_alternative_approach()

    print("\n" + "=" * 60)
    if client_success or http_success:
        print("[RESULT] At least one method succeeded")
    else:
        print("[RESULT] Both methods failed - GPT-5-Codex may not be available yet")
        print("[INFO] Falling back to gpt-4o is recommended")
    print("=" * 60)
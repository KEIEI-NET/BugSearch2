#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
GPT-5-Codex Responses API対応版
/v1/responses エンドポイントを使用
"""
import json
import os
import sys
import time
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

# 設定値
AI_TIMEOUT = 60
AI_MAX_RETRIES = 3
AI_MIN_SEVERITY = 7
AI_MAX_FILES = 20

def call_gpt5_codex(prompt, api_key, model="gpt-5-codex"):
    """
    GPT-5-Codex Responses API呼び出し
    """
    import requests

    headers = {
        "Authorization": f"Bearer {api_key}",
        "Content-Type": "application/json"
    }

    # Responses APIエンドポイント
    url = "https://api.openai.com/v1/responses"

    # パラメータ設定
    data = {
        "model": model,
        "input": prompt,
        "reasoning": {
            "effort": "high"  # コード解析には高精度推論を使用
        },
        "temperature": 0.3,  # コーディングタスクには低温度を推奨
        "max_tokens": 4000,
        "verbosity": "medium"
    }

    try:
        response = requests.post(
            url,
            headers=headers,
            json=data,
            timeout=AI_TIMEOUT
        )

        if response.status_code == 200:
            result = response.json()
            return result.get("output_text", "")
        else:
            print(f"[ERROR] API Error: {response.status_code}")
            print(f"Response: {response.text[:500]}")
            return None

    except requests.Timeout:
        print(f"[ERROR] Request timeout after {AI_TIMEOUT} seconds")
        return None
    except Exception as e:
        print(f"[ERROR] Unexpected error: {str(e)}")
        return None


def call_gpt5_codex_with_retry(prompt, api_key, model="gpt-5-codex"):
    """
    リトライ機能付きGPT-5-Codex呼び出し
    """
    for attempt in range(1, AI_MAX_RETRIES + 1):
        print(f"[INFO] Attempt {attempt}/{AI_MAX_RETRIES} with {model}")

        result = call_gpt5_codex(prompt, api_key, model)

        if result and result.strip():
            print(f"[SUCCESS] Got response ({len(result)} chars)")
            return result

        if attempt < AI_MAX_RETRIES:
            print(f"[WARNING] Empty response, retrying...")
            time.sleep(2)

    # フォールバック: 通常のChat Completions APIを使用
    print("[INFO] Falling back to gpt-4o with chat completions...")
    return call_gpt4_fallback(prompt, api_key)


def call_gpt4_fallback(prompt, api_key):
    """
    GPT-4oフォールバック（従来のChat Completions API）
    """
    from openai import OpenAI

    client = OpenAI(api_key=api_key)

    try:
        response = client.chat.completions.create(
            model="gpt-4o",
            messages=[
                {"role": "system", "content": "You are a code reviewer."},
                {"role": "user", "content": prompt}
            ],
            max_tokens=2000,
            temperature=0.5,
            timeout=AI_TIMEOUT
        )

        if response.choices and response.choices[0].message.content:
            return response.choices[0].message.content.strip()

    except Exception as e:
        print(f"[ERROR] Fallback failed: {str(e)}")

    return None


def analyze_code(file_path, content, api_key, model):
    """
    コードファイルを解析
    """
    prompt = f"""
    以下のコードをレビューしてください：

    ファイル: {file_path}

    ```
    {content[:3000]}  # 最初の3000文字のみ
    ```

    以下の観点で分析してください：
    1. セキュリティの問題
    2. パフォーマンスの問題
    3. コード品質の問題

    問題があれば、具体的な改善案を提示してください。
    """

    # GPT-5-Codexの場合はResponses API使用
    if "gpt-5" in model.lower() and "codex" in model.lower():
        return call_gpt5_codex_with_retry(prompt, api_key, model)
    else:
        # その他のモデルは従来のChat Completions API
        return call_gpt4_fallback(prompt, api_key)


def main():
    """
    メイン処理
    """
    print("[INFO] GPT-5-Codex Responses API Test")

    # API設定
    api_key = os.environ.get("OPENAI_API_KEY")
    model = os.environ.get("OPENAI_MODEL", "gpt-5-codex")

    if not api_key:
        print("[ERROR] OPENAI_API_KEY not set in .env")
        sys.exit(1)

    print(f"[INFO] Using model: {model}")

    # テストコード
    test_code = """
    def calculate_total(orders):
        total = 0
        for order in orders:
            # N+1問題の可能性
            items = db.query(f"SELECT * FROM items WHERE order_id = {order.id}")
            for item in items:
                total += item.price
        return total
    """

    print("\n[TEST] Analyzing sample code...")
    result = analyze_code("test.py", test_code, api_key, model)

    if result:
        print("\n[RESULT] Analysis complete:")
        print("-" * 50)
        print(result)
        print("-" * 50)
        print(f"\n[SUCCESS] Response length: {len(result)} chars")
    else:
        print("\n[FAIL] No response received")

    # インデックスファイルが存在する場合は実際のコード解析
    index_file = ".advice_index.jsonl"
    if Path(index_file).exists():
        print(f"\n[INFO] Found {index_file}, analyzing real files...")

        analyzed_count = 0
        with open(index_file, "r", encoding="utf-8") as f:
            for line in f:
                if analyzed_count >= 3:  # 最大3ファイルまで
                    break

                try:
                    entry = json.loads(line)
                    file_path = entry.get("path")
                    severity = entry.get("severity", 0)

                    if severity >= AI_MIN_SEVERITY:
                        print(f"\n[ANALYZING] {file_path} (severity: {severity})")

                        # ファイル読み込み
                        if Path(file_path).exists():
                            with open(file_path, "r", encoding="utf-8", errors="ignore") as code_file:
                                content = code_file.read()

                            result = analyze_code(file_path, content, api_key, model)
                            if result:
                                print(f"[OK] Analysis complete for {file_path}")
                                analyzed_count += 1
                            else:
                                print(f"[WARNING] No response for {file_path}")

                except Exception as e:
                    print(f"[ERROR] Failed to analyze: {str(e)}")
                    continue

        print(f"\n[SUMMARY] Analyzed {analyzed_count} files")

    print("\n[INFO] Test complete")


if __name__ == "__main__":
    main()
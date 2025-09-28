#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
GPT-5-Codexモデル対応テストスクリプト
新パラメータ（verbosity, reasoning_effort）を含む
"""
import os
import sys
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
                if key == "OPENAI_MODEL":
                    print(f"[OK] OPENAI_MODEL設定: {val}")
                elif key == "OPENAI_API_KEY":
                    print(f"[OK] OPENAI_API_KEY設定: ***{val[-4:]}")

# OpenAI API テスト
try:
    from openai import OpenAI
    print("\n[INFO] OpenAIライブラリのインポート成功")

    api_key = os.environ.get("OPENAI_API_KEY")
    model = os.environ.get("OPENAI_MODEL", "gpt-5-codex")

    if not api_key:
        print("[ERROR] OPENAI_API_KEY が設定されていません")
        sys.exit(1)

    print(f"\n[TEST] モデル '{model}' でテストリクエスト送信中...")

    client = OpenAI(api_key=api_key)

    # コーディングタスク用のプロンプト
    system_content = "You are a coding assistant."
    test_prompt = "Write a simple Python function to check if a number is prime."

    try:
        # メッセージ配列
        messages = [
            {"role": "system", "content": system_content},
            {"role": "user", "content": test_prompt}
        ]

        # 基本パラメータ
        params = {
            "model": model,
            "messages": messages
        }

        # モデル別パラメータ設定
        if "gpt-5-codex" in model:
            print("[INFO] GPT-5-Codexパラメータを適用中...")
            params["temperature"] = 0.2
            params["max_tokens"] = 600
            params["verbosity"] = "low"  # コード中心の簡潔な応答
            params["reasoning_effort"] = "minimal"  # 推論リソース節約
            params["presence_penalty"] = 0.2
            params["stop"] = ["\n\n"]
            params["seed"] = 42
        elif "gpt-5" in model:
            print("[INFO] GPT-5パラメータを適用中...")
            params["max_completion_tokens"] = 600
            params["verbosity"] = "low"
            params["reasoning_effort"] = "minimal"
        else:
            print("[INFO] 従来モデルパラメータを適用中...")
            params["temperature"] = 0.5
            params["max_tokens"] = 600

        # APIリクエスト
        print("[INFO] API呼び出し中...")
        resp = client.chat.completions.create(**params)

        if resp.choices and resp.choices[0].message.content:
            content = resp.choices[0].message.content
            print(f"\n[SUCCESS] レスポンス受信:")
            print("-" * 50)
            print(content)
            print("-" * 50)
            print(f"\n[SUCCESS] GPT-5-Codexモデル対応テスト成功！")

            # パラメータ効果の確認
            if "def" in content and "prime" in content.lower():
                print("[VERIFY] コード生成確認: OK")
            if len(content.split("\n")) < 20:
                print("[VERIFY] verbosity='low'の効果: 簡潔な応答")

        else:
            print(f"[WARNING] 空のレスポンスを受信")
            print("フォールバック機能が動作します")

    except Exception as e:
        error_msg = str(e)
        if "verbosity" in error_msg or "reasoning_effort" in error_msg:
            print(f"\n[ERROR] 新パラメータ関連エラー: {error_msg}")
            print("\nヒント:")
            print("  - verbosity/reasoning_effortはGPT-5系のみ対応")
            print("  - モデルがこれらのパラメータをサポートしているか確認")
        elif "model" in error_msg.lower():
            print(f"\n[ERROR] モデル関連エラー: {error_msg}")
            print("\nヒント:")
            print("  - モデル名を確認してください")
            print("  - gpt-5-codex, gpt-5, gpt-5-mini, gpt-5-nano, gpt-4o")
        else:
            print(f"\n[ERROR] API呼び出しエラー: {error_msg}")

except ImportError:
    print("[ERROR] openaiライブラリがインストールされていません")
    print("実行: pip install openai")
    sys.exit(1)

print("\n[INFO] codex_review_severity.pyでも同様にモデルが使用されます")
print("[INFO] verbosity='low' + reasoning_effort='minimal' でコード解析に最適化")
#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
GPT-5モデル対応テストスクリプト
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
    model = os.environ.get("OPENAI_MODEL", "gpt-5")

    if not api_key:
        print("[ERROR] OPENAI_API_KEY が設定されていません")
        sys.exit(1)

    print(f"\n[TEST] モデル '{model}' でテストリクエスト送信中...")

    client = OpenAI(api_key=api_key)

    # シンプルなテストプロンプト
    test_prompt = "簡単に答えてください: Pythonとは何ですか？（10文字以内）"

    try:
        # GPT-5では max_completion_tokens を使用
        params = {
            "model": model,
            "messages": [{"role": "user", "content": test_prompt}]
        }

        # GPT-5はtemperature=1のみサポート、それ以外は0.5使用可能
        if "gpt-5" not in model:
            params["temperature"] = 0.5

        # モデルに応じてパラメータを調整
        if "gpt-5" in model:
            params["max_completion_tokens"] = 50
        else:
            params["max_tokens"] = 50

        resp = client.chat.completions.create(**params)

        if resp.choices and resp.choices[0].message.content:
            print(f"[SUCCESS] レスポンス受信: {resp.choices[0].message.content}")
            print(f"\n[SUCCESS] GPT-5モデル対応テスト成功！")
        else:
            print(f"[WARNING] 空のレスポンスを受信")
            print("フォールバック機能が動作します")

    except Exception as e:
        error_msg = str(e)
        if "model" in error_msg.lower():
            print(f"\n[ERROR] モデル関連エラー: {error_msg}")
            print("\nヒント:")
            print("  - モデル名を確認してください（gpt-5, gpt-5-mini, gpt-5-nano, gpt-4o）")
            print("  - APIキーの権限を確認してください")
        else:
            print(f"\n[ERROR] API呼び出しエラー: {error_msg}")

except ImportError:
    print("[ERROR] openaiライブラリがインストールされていません")
    print("実行: pip install openai")
    sys.exit(1)

print("\n[INFO] codex_review_severity.pyでも同様にモデルが使用されます")
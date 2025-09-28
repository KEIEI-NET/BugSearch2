#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
小規模テスト用インデックス作成スクリプト
"""
import os
import sys
import pathlib
import time

# 小規模なサブセットでテスト
test_dir = pathlib.Path("src/csharp/OfferSource/ASP/Client")

if not test_dir.exists():
    print(f"テストディレクトリが見つかりません: {test_dir}")
    sys.exit(1)

# ファイル数をカウント
count = 0
for root, dirs, files in os.walk(test_dir):
    for file in files:
        if file.endswith(('.cs', '.java', '.py', '.ts', '.js')):
            count += 1

print(f"テスト対象ファイル数: {count}")

# インデックス作成を実行
import subprocess
start_time = time.time()

result = subprocess.run(
    [sys.executable, "codex_review_ultimate.py", "index", str(test_dir), "--max-file-mb", "2"],
    capture_output=True,
    text=True,
    timeout=60
)

elapsed = time.time() - start_time
print(f"実行時間: {elapsed:.2f}秒")
print(f"標準出力:\n{result.stdout}")
if result.stderr:
    print(f"エラー出力:\n{result.stderr}")
print(f"終了コード: {result.returncode}")
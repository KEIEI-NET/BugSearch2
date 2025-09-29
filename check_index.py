#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""インデックスファイルの内容確認"""
import json
from pathlib import Path

index_file = ".advice_index.jsonl"
if Path(index_file).exists():
    with open(index_file, "r", encoding="utf-8", errors="ignore") as f:
        lines = f.readlines()
        print(f"総行数: {len(lines)}")

        # 最初の5行を表示
        for i, line in enumerate(lines[:5]):
            try:
                data = json.loads(line)
                print(f"\n行{i+1}:")
                print(f"  path: {data.get('path', 'N/A')}")
                print(f"  severity: {data.get('severity', 'N/A')}")
                print(f"  severity_score: {data.get('severity_score', 'N/A')}")
                print(f"  problems: {data.get('problems', [])[:3]}")
                print(f"  tags: {data.get('tags', [])}")
            except Exception as e:
                print(f"行{i+1}: エラー - {str(e)[:50]}")

        # severity分布を確認
        severities = []
        for line in lines:
            try:
                data = json.loads(line)
                sev = data.get("severity_score", data.get("severity", 0))
                severities.append(sev)
            except:
                pass

        if severities:
            print(f"\n[統計]")
            print(f"  severity_score > 0: {sum(1 for s in severities if s > 0)}件")
            print(f"  severity_score >= 5: {sum(1 for s in severities if s >= 5)}件")
            print(f"  severity_score >= 10: {sum(1 for s in severities if s >= 10)}件")
            print(f"  最大severity_score: {max(severities)}")
else:
    print("インデックスファイルが存在しません")
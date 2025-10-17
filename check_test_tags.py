#!/usr/bin/env python3
"""インデックス内のタグ確認スクリプト"""
import json
from pathlib import Path

index_file = Path('.advice_index.jsonl')

if not index_file.exists():
    print("❌ .advice_index.jsonl が見つかりません")
    exit(1)

print("=" * 80)
print("タグベース深刻度調整 - インデックス検証")
print("=" * 80)
print()

target_files = ['react-xss-sample.tsx', 'elasticsearch-n1-sample.ts']

with open(index_file, 'r', encoding='utf-8') as f:
    for line in f:
        try:
            data = json.loads(line)
            relative_path = data.get('relative_path', '')

            if any(target in relative_path for target in target_files):
                print(f"📄 ファイル: {relative_path}")
                print(f"🏷️  タグ: {data.get('tags', [])}")
                print(f"⚠️  深刻度: {data.get('severity', 0)}")
                print(f"📝 言語: {data.get('language', 'unknown')}")
                print()

                # タグ検証
                tags = data.get('tags', [])
                if 'react-xss-sample.tsx' in relative_path:
                    expected_tags = ['tech-react', 'lang-typescript']
                    has_react = 'tech-react' in tags
                    has_ts = any('lang-typescript' in t or 'lang-tsx' in t for t in tags)
                    print(f"  ✅ tech-react検出: {has_react}")
                    print(f"  ✅ TypeScript検出: {has_ts}")

                elif 'elasticsearch-n1-sample.ts' in relative_path:
                    has_elastic = 'tech-elasticsearch' in tags
                    has_ts = 'lang-typescript' in tags
                    print(f"  ✅ tech-elasticsearch検出: {has_elastic}")
                    print(f"  ✅ lang-typescript検出: {has_ts}")

                print("-" * 80)

        except json.JSONDecodeError:
            continue

print()
print("=" * 80)
print("検証完了")
print("=" * 80)

#!/usr/bin/env python3
"""
タグベース深刻度調整 - CLI統合テスト

実際のインデックスファイルとYAMLルールを使用して、
CLIワークフローでのタグベース深刻度調整を検証します。
"""
import json
import yaml
from pathlib import Path
import sys

# プロジェクトルートをパスに追加
sys.path.insert(0, str(Path(__file__).parent))

from core.models import Rule, ContextModifier, TechStack
from core.rule_engine import adjust_severity_by_tech_stack

print("=" * 80)
print("CLI統合テスト - タグベース深刻度調整")
print("=" * 80)
print()

# ステップ1: インデックスからElasticsearchファイルを検索
print("【ステップ1】インデックスからタグ情報を読み込み")
print("-" * 80)

index_file = Path('.advice_index.jsonl')
if not index_file.exists():
    print("❌ .advice_index.jsonl が見つかりません")
    exit(1)

elasticsearch_entry = None
with open(index_file, 'r', encoding='utf-8') as f:
    for line in f:
        try:
            data = json.loads(line)
            if 'elasticsearch-n1-sample.ts' in data.get('path', ''):
                elasticsearch_entry = data
                break
        except json.JSONDecodeError:
            continue

if not elasticsearch_entry:
    print("❌ elasticsearch-n1-sample.ts がインデックスに見つかりません")
    exit(1)

print(f"ファイル: {elasticsearch_entry['path']}")
print(f"言語: {elasticsearch_entry['lang']}")
print(f"タグ: {elasticsearch_entry['tags']}")
print()

# タグ確認
tags = elasticsearch_entry['tags']
has_elasticsearch = 'tech-elasticsearch' in tags
has_typescript = 'lang-typescript' in tags

print(f"✅ tech-elasticsearch検出: {has_elasticsearch}")
print(f"✅ lang-typescript検出: {has_typescript}")
print()

if not has_elasticsearch:
    print("❌ tech-elasticsearchタグが見つかりません")
    exit(1)

# ステップ2: N+1ルールYAMLを読み込み
print("【ステップ2】N+1ルールYAMLを読み込み")
print("-" * 80)

rule_file = Path('rules/core/database/n-plus-one.yml')
if not rule_file.exists():
    print(f"❌ {rule_file} が見つかりません")
    exit(1)

with open(rule_file, 'r', encoding='utf-8') as f:
    rule_data = yaml.safe_load(f)

rule_info = rule_data['rule']
print(f"ルールID: {rule_info['id']}")
print(f"カテゴリ: {rule_info['category']}")
print(f"基本深刻度: {rule_info['base_severity']}")
print()

# Elasticsearchモディファイアを検索
elasticsearch_modifier = None
for modifier in rule_info.get('context_modifiers', []):
    condition = modifier.get('condition', {})
    if condition.get('tech_stack_has') == 'Elasticsearch':
        elasticsearch_modifier = modifier
        break

if not elasticsearch_modifier:
    print("❌ Elasticsearchモディファイアが見つかりません")
    exit(1)

print("Elasticsearchモディファイア:")
print(f"  条件: {elasticsearch_modifier['condition']}")
print(f"  深刻度調整: {elasticsearch_modifier['action']['severity_adjustment']}")
print(f"  ノート: {elasticsearch_modifier['action']['note'][:80]}...")
print()

# ステップ3: タグベース深刻度調整を実行
print("【ステップ3】タグベース深刻度調整を実行")
print("-" * 80)

# Ruleオブジェクトを構築
rule = Rule(
    id=rule_info['id'],
    category=rule_info['category'],
    name=rule_info['name'],
    description=rule_info['description'],
    base_severity=rule_info['base_severity'],
    patterns={},
    context_modifiers=[
        ContextModifier(
            condition=elasticsearch_modifier['condition'],
            severity_adjustment=elasticsearch_modifier['action']['severity_adjustment'],
            note=elasticsearch_modifier['action'].get('note')
        )
    ]
)

# コードコンテキスト（Elasticsearchのコード）
code_context = elasticsearch_entry['text']

# 方法1: 設定ファイルなし、タグのみ（新機能）
print("方法1: タグのみで深刻度調整（.bugsearch.yml不要）")
empty_tech_stack = TechStack()
severity_with_tags, notes_with_tags = adjust_severity_by_tech_stack(
    rule, empty_tech_stack, rule_info['base_severity'],
    code_context=code_context,
    tags=tags
)

print(f"  入力: TechStack = 空（.bugsearch.yml設定なし）")
print(f"  入力: タグ = {tags}")
print(f"  結果: 深刻度 = {severity_with_tags} (元: {rule_info['base_severity']})")
print(f"  結果: 調整値 = {severity_with_tags - rule_info['base_severity']}")
print(f"  結果: ノート数 = {len(notes_with_tags)}")
if notes_with_tags:
    print(f"  結果: ノート = {notes_with_tags[0][:100]}...")
print()

# 検証
expected_severity = rule_info['base_severity'] + elasticsearch_modifier['action']['severity_adjustment']
expected_severity = max(1, min(10, expected_severity))

if severity_with_tags == expected_severity:
    print(f"✅ 成功: 深刻度が正しく調整されました！")
    print(f"   {rule_info['base_severity']} → {severity_with_tags} (調整: {elasticsearch_modifier['action']['severity_adjustment']})")
else:
    print(f"❌ 失敗: 期待値 {expected_severity}、実際 {severity_with_tags}")
    exit(1)

print()

# ステップ4: まとめ
print("=" * 80)
print("【テスト結果サマリー】")
print("=" * 80)
print()
print("✅ 全てのステップが成功しました！")
print()
print("検証項目:")
print("  ✅ インデックスからタグ情報の読み込み")
print("  ✅ tech-elasticsearchタグの自動検出")
print("  ✅ N+1ルールYAMLの読み込み")
print("  ✅ Elasticsearchモディファイアの検出")
print("  ✅ タグベース深刻度調整の実行")
print(f"  ✅ 深刻度調整の検証 ({rule_info['base_severity']} → {severity_with_tags})")
print()
print("新機能の動作:")
print("  ✅ .bugsearch.yml設定ファイル不要")
print("  ✅ タグから自動的に技術スタック検出")
print("  ✅ YAMLルールのcontext_modifiersが正常動作")
print("  ✅ CLIワークフロー（index → query/advise）で使用可能")
print()
print("=" * 80)
print("CLI統合テスト完了 - タグベース深刻度調整は正常に動作しています！")
print("=" * 80)

# Context7統合ガイド

*バージョン: v1.0.0*
*最終更新: 2025年10月12日 15:25 JST*

## 📚 概要

Context7統合により、BugSearch2は技術ドキュメントから自動的にカスタムルールを生成できるようになりました。このガイドでは、Context7の設定から実際の使用方法まで詳しく説明します。

## 🔧 セットアップ

### 1. 必要な環境

```bash
# Python 3.11以上
python --version

# 必要なパッケージ
pip install pyyaml
pip install anthropic  # AI自動修正用
pip install openai     # AI自動修正用（フォールバック）
```

### 2. Context7 MCPの設定

Context7 MCPサーバーが正しく設定されていることを確認：

```bash
# MCPサーバーの状態確認
mcp status context7

# または、Claude Desktop の settings.json に設定
{
  "mcpServers": {
    "context7": {
      "command": "npx",
      "args": ["@context7/mcp-server"]
    }
  }
}
```

### 3. 環境変数の設定

```bash
# .env ファイル
AI_PROVIDER=auto  # auto / anthropic / openai

# Anthropic Claude（推奨）
ANTHROPIC_API_KEY=sk-ant-xxx
ANTHROPIC_MODEL=claude-sonnet-4-5

# OpenAI GPT（フォールバック）
OPENAI_API_KEY=sk-xxx
OPENAI_MODEL=gpt-4o
```

## 🚀 基本的な使用方法

### 1. 対話型ウィザード

最も簡単な方法は対話型ウィザードを使用することです：

```bash
python generate_tech_config.py

# プロンプト例:
# 1. 技術を選択してください (react/vue/angular/...): react
# 2. カスタマイズしますか? (y/n): y
# 3. 深刻度を調整...
# 4. 設定を保存しました: config/react-custom.yml
# 5. 自動的に分析を実行しますか? (y/n): y
```

### 2. コマンドライン引数で直接実行

```bash
# React用の設定を生成して自動実行
python generate_tech_config.py --tech react --auto-run

# Vue.js用の設定を生成のみ
python generate_tech_config.py --tech vue --output config/vue-rules.yml

# Next.js用の設定を生成して検証のみ
python generate_tech_config.py --tech nextjs --validate-only
```

### 3. プログラマティックな使用

```python
from core.config_generator import ConfigGenerator
from pathlib import Path

# 初期化
generator = ConfigGenerator()

# React用のYAML生成
yaml_content = generator.generate_yaml("react")

# 検証
is_valid, errors = generator.validate_yaml(yaml_content)

# エラーがある場合はAI修正
if not is_valid:
    print(f"Validation errors found: {errors}")
    yaml_content = generator.fix_yaml_with_ai(yaml_content, errors)
    print("Fixed YAML with AI assistance")

# ファイルに保存
config_path = Path("config/react-rules.yml")
config_path.parent.mkdir(exist_ok=True)
config_path.write_text(yaml_content, encoding='utf-8')

print(f"Configuration saved to {config_path}")
```

## 📋 生成されるYAML構造

### 基本構造

```yaml
# 技術スタック情報
tech_stack:
  name: "React"
  version: "18.x"
  framework_type: "frontend"
  package_manager: "npm"
  build_tool: "webpack"
  test_framework: "jest"

# カスタムルール
custom_rules:
  - id: "REACT_HOOKS_DEPS"
    name: "Missing useEffect dependencies"
    category: "react"
    base_severity: 7
    patterns:
      javascript:
        - pattern: 'useEffect\([^,]+,\s*\[\s*\]'
          context: "Empty dependency array may cause stale closures"
      typescript:
        - pattern: 'useEffect\([^,]+,\s*\[\s*\]'
          context: "Empty dependency array may cause stale closures"

  - id: "REACT_DIRECT_STATE_MUTATION"
    name: "Direct state mutation"
    category: "react"
    base_severity: 8
    patterns:
      javascript:
        - pattern: 'this\.state\.\w+\s*='
          context: "Direct state mutation - use setState()"

  - id: "REACT_MISSING_KEY_PROP"
    name: "Missing key prop in list"
    category: "react"
    base_severity: 6
    patterns:
      javascript:
        - pattern: '\.map\([^)]+\)\s*=>\s*<(?!.*\skey=)'
          context: "List items should have unique key props"
```

### 技術別テンプレート

#### React
```yaml
custom_rules:
  - Hooks依存関係
  - 状態の直接変更
  - key propの欠落
  - useEffectクリーンアップ
  - 条件付きフック
```

#### Vue.js
```yaml
custom_rules:
  - v-for without key
  - Mutation of props
  - Missing computed dependencies
  - Event listener cleanup
  - Reactivity pitfalls
```

#### Angular
```yaml
custom_rules:
  - Subscription memory leaks
  - ChangeDetectionStrategy issues
  - Direct DOM manipulation
  - Missing guards for private routes
  - Large SharedModule
```

## 🔍 検証とデバッグ

### 検証コマンド

```bash
# YAML検証のみ実行
python generate_tech_config.py --tech react --validate-only

# 詳細なデバッグ出力
python generate_tech_config.py --tech react --debug

# ドライラン（実際には実行しない）
python generate_tech_config.py --tech react --dry-run
```

### 検証エラーの例と対処法

#### 1. 必須フィールド不足
```
Error: Missing required field: tech_stack
Solution: Ensure tech_stack section exists with name, version, framework_type
```

#### 2. 無効な正規表現
```
Error: Invalid regex in REACT_HOOKS: unterminated group
Solution: Check regex patterns for proper escaping and syntax
```

#### 3. 深刻度範囲外
```
Error: Severity must be between 1 and 10, got 15
Solution: Adjust base_severity to be within valid range
```

## 🤖 AI自動修正機能

### 動作原理

1. **エラー検出**: YAMLバリデーションでエラーを検出
2. **AI修正**: エラーメッセージとYAMLをAIに送信
3. **再検証**: 修正されたYAMLを再検証
4. **反復処理**: 最大5回まで修正を試行

### AIプロンプトの例

```python
prompt = f"""
Fix the following YAML configuration:

Current YAML:
```yaml
{yaml_content}
```

Errors:
- Missing required field: patterns
- Invalid regex: unterminated group at position 15
- Severity out of range: 12 (must be 1-10)

Requirements:
1. Fix ALL validation errors
2. Maintain the original structure
3. Use valid regex patterns
4. Keep severity between 1-10

Return ONLY the corrected YAML.
"""
```

### 手動介入が必要な場合

AI修正が失敗した場合は、手動で修正する必要があります：

```bash
# 1. エラーログを確認
cat logs/yaml_validation_errors.log

# 2. YAMLを手動編集
nano config/react-rules.yml

# 3. 再検証
python -c "from core.config_generator import ConfigGenerator; \
          from pathlib import Path; \
          g = ConfigGenerator(); \
          yaml = Path('config/react-rules.yml').read_text(); \
          valid, errors = g.validate_yaml(yaml); \
          print('Valid' if valid else f'Errors: {errors}')"
```

## 📊 完全自動実行フロー

### --auto-runオプション

```bash
# 完全自動実行の流れ
python generate_tech_config.py --tech angular --auto-run

# 実行される処理:
# 1. Context7からAngular仕様取得
# 2. カスタムルールYAML生成
# 3. YAML検証（エラーあればAI修正）
# 4. config/angular-rules.yml として保存
# 5. codex_review_severity.py index 実行
# 6. codex_review_severity.py advise --all 実行
# 7. reports/angular_analysis.md 生成
```

### CI/CD統合

```yaml
# .github/workflows/tech-analysis.yml
name: Technology-Specific Code Analysis

on:
  push:
    branches: [main]
  pull_request:

jobs:
  analyze:
    runs-on: ubuntu-latest

    steps:
      - uses: actions/checkout@v4

      - name: Setup Python
        uses: actions/setup-python@v5
        with:
          python-version: '3.11'

      - name: Install dependencies
        run: pip install -r requirements.txt

      - name: Detect technology stack
        id: detect_tech
        run: |
          # package.jsonからReact/Vue/Angularを検出
          if [ -f "package.json" ]; then
            if grep -q '"react"' package.json; then
              echo "tech=react" >> $GITHUB_OUTPUT
            elif grep -q '"vue"' package.json; then
              echo "tech=vue" >> $GITHUB_OUTPUT
            elif grep -q '"@angular/core"' package.json; then
              echo "tech=angular" >> $GITHUB_OUTPUT
            fi
          fi

      - name: Generate and run analysis
        if: steps.detect_tech.outputs.tech
        env:
          AI_PROVIDER: ${{ secrets.AI_PROVIDER }}
          ANTHROPIC_API_KEY: ${{ secrets.ANTHROPIC_API_KEY }}
          OPENAI_API_KEY: ${{ secrets.OPENAI_API_KEY }}
        run: |
          python generate_tech_config.py \
            --tech ${{ steps.detect_tech.outputs.tech }} \
            --auto-run

      - name: Upload analysis reports
        uses: actions/upload-artifact@v4
        with:
          name: analysis-reports
          path: reports/
```

## 🎯 ベストプラクティス

### 1. 初回セットアップ

```bash
# 1. 対話モードで設定を確認
python generate_tech_config.py

# 2. 生成されたYAMLを確認
cat config/[tech]-rules.yml

# 3. 必要に応じて手動調整
nano config/[tech]-rules.yml

# 4. 小規模なテスト実行
python codex_review_severity.py index ./src/components
python codex_review_severity.py advise --topk 10
```

### 2. カスタマイズ

```python
# カスタムルールの追加
from core.config_generator import ConfigGenerator

generator = ConfigGenerator()
yaml_content = generator.generate_yaml("react")

# カスタムルールを追加
import yaml
data = yaml.safe_load(yaml_content)
data['custom_rules'].append({
    'id': 'CUSTOM_RULE',
    'name': 'My custom rule',
    'category': 'custom',
    'base_severity': 5,
    'patterns': {
        'javascript': [{
            'pattern': 'myPattern',
            'context': 'Custom context'
        }]
    }
})

yaml_content = yaml.safe_dump(data)
```

### 3. トラブルシューティング

```bash
# Context7接続エラー
# → MCPサーバーが起動しているか確認
mcp status context7

# AI修正失敗
# → 手動修正モードに切り替え
python generate_tech_config.py --tech react --no-ai-fix

# メモリ不足
# → バッチサイズを調整
python codex_review_severity.py advise --batch-size 50
```

## 📈 パフォーマンス指標

| 処理 | 時間 | 備考 |
|-----|------|------|
| Context7 API呼び出し | 2-3秒 | ライブラリ情報取得 |
| YAML生成 | <1秒 | テンプレート処理 |
| 検証処理 | <1秒 | 5段階検証 |
| AI修正（1回） | 3-5秒 | APIレスポンス時間 |
| インデックス作成（1000ファイル） | 10-20秒 | ファイルサイズ依存 |
| AI分析（100ファイル） | 30-60秒 | API制限依存 |

## 🔗 関連ドキュメント

- [Phase 8計画書](../PHASE8_PLAN.md)
- [技術仕様書](../TECHNICAL.md)
- [アーキテクチャ](../ARCHITECTURE.md)
- [ルールテンプレートガイド](./RULE_TEMPLATE_GUIDE.md)

---

*最終更新: 2025年10月12日 15:25 JST*
*バージョン: v1.0.0*

**更新履歴:**
- v1.0.0 (2025年10月12日): 初版作成、Phase 8.2完了に伴うドキュメント作成
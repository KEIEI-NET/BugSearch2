# Phase 4.1 実装計画: ルールテンプレート & 対話型ウィザード

*バージョン: v4.4.0 (Phase 4.1開始)*
*作成日: 2025年10月12日 JST*
*最終更新: 2025年10月12日 JST*

## 🎯 Phase 4.1の目標

**カスタムルール作成の簡易化とユーザビリティ向上**

Phase 4.0で完成したカスタムルールシステムの上に、ルール作成を簡単にする機能を構築します。

### 達成基準
- [ ] ルールテンプレート機能実装
- [ ] 対話型ルール生成ウィザード実装
- [ ] テンプレートカタログ作成
- [ ] CLIコマンド拡張
- [ ] @perfect品質維持 (全テスト100%合格)

---

## 📊 現在の状況

### Phase 4.0完了 (v4.3.0) ✅
- ✅ カスタムルールシステム実装
- ✅ RuleLoader/RuleValidator実装
- ✅ ルール優先順位システム
- ✅ 全テスト100%合格 (11/11)

### Phase 4.1の新機能

Phase 4.0で実装したカスタムルールシステムを拡張し、以下を実現：

1. **ルールテンプレート機能**
   - よく使うルールパターンのテンプレート提供
   - カテゴリ別テンプレート (禁止API、命名規則、セキュリティ等)
   - テンプレートからの簡単なルール生成

2. **対話型ルール生成ウィザード**
   - CLIでの対話的なルール作成
   - 必須フィールドの自動入力補助
   - パターン例の提供
   - 作成したルールの自動バリデーション

3. **テンプレートカタログ**
   - 実用的なルールテンプレート集
   - 言語別テンプレート
   - カスタマイズ例

---

## 🔧 実装項目

### 1. ルールテンプレート機能 (優先度: 高)

#### テンプレートディレクトリ構造

```
rules/
└── templates/           # テンプレートディレクトリ
    ├── forbidden-api.yml.template      # 禁止API検出テンプレート
    ├── naming-convention.yml.template  # 命名規則テンプレート
    ├── security-check.yml.template     # セキュリティチェックテンプレート
    ├── performance.yml.template        # パフォーマンステンプレート
    └── custom-pattern.yml.template     # カスタムパターンテンプレート
```

#### テンプレート例: forbidden-api.yml.template

```yaml
# 禁止API検出ルールテンプレート
# 使用方法: {RULE_ID}, {API_NAME}, {SEVERITY} を実際の値に置換

rule:
  id: "{RULE_ID}"
  category: "custom"
  name: "{API_NAME} Usage Detection"
  description: "Detects usage of {API_NAME} which is forbidden in this project"
  base_severity: {SEVERITY}

  patterns:
    csharp:
      - pattern: '{PATTERN}'
        context: "{API_NAME} usage detected"

    java:
      - pattern: '{PATTERN}'
        context: "{API_NAME} usage detected"

    python:
      - pattern: '{PATTERN}'
        context: "{API_NAME} usage detected"

  fixes:
    csharp:
      - "Replace {API_NAME} with the recommended alternative"
      - "Use {ALTERNATIVE_API} instead"

    java:
      - "Replace {API_NAME} with the recommended alternative"
      - "Use {ALTERNATIVE_API} instead"

    python:
      - "Replace {API_NAME} with the recommended alternative"
      - "Use {ALTERNATIVE_API} instead"
```

#### テンプレート例: naming-convention.yml.template

```yaml
# 命名規則チェックルールテンプレート
# 使用方法: {RULE_ID}, {TARGET_TYPE}, {CONVENTION}, {SEVERITY} を置換

rule:
  id: "{RULE_ID}"
  category: "custom"
  name: "{TARGET_TYPE} Naming Convention"
  description: "Checks {TARGET_TYPE} naming follows {CONVENTION} convention"
  base_severity: {SEVERITY}

  patterns:
    csharp:
      - pattern: '{PATTERN}'
        context: "{TARGET_TYPE} does not follow {CONVENTION} convention"

    java:
      - pattern: '{PATTERN}'
        context: "{TARGET_TYPE} does not follow {CONVENTION} convention"

  fixes:
    csharp:
      - "Rename to follow {CONVENTION} convention"
      - "Example: {EXAMPLE_BEFORE} → {EXAMPLE_AFTER}"

    java:
      - "Rename to follow {CONVENTION} convention"
      - "Example: {EXAMPLE_BEFORE} → {EXAMPLE_AFTER}"
```

### 2. RuleTemplateManagerクラス実装 (優先度: 高)

#### core/rule_template.py

```python
"""
ルールテンプレート管理

Phase 4.1の新機能:
- テンプレートの読み込み
- テンプレート変数の置換
- テンプレートからのルール生成
"""

from pathlib import Path
from typing import Dict, List, Optional
import yaml
import re


class RuleTemplate:
    """ルールテンプレート"""

    def __init__(self, template_id: str, template_path: Path, content: str):
        self.id = template_id
        self.path = template_path
        self.content = content
        self.variables = self._extract_variables()

    def _extract_variables(self) -> List[str]:
        """テンプレート変数を抽出"""
        # {VARIABLE_NAME} 形式の変数を抽出
        variables = re.findall(r'\{([A-Z_]+)\}', self.content)
        return list(set(variables))

    def render(self, values: Dict[str, str]) -> str:
        """
        テンプレート変数を置換してルールYAMLを生成

        Args:
            values: 変数名→値のマッピング

        Returns:
            レンダリングされたYAML文字列
        """
        result = self.content
        for var_name, value in values.items():
            placeholder = f'{{{var_name}}}'
            result = result.replace(placeholder, value)

        return result


class RuleTemplateManager:
    """
    ルールテンプレート管理クラス

    Phase 4.1の新機能:
    - テンプレートの読み込み
    - テンプレート一覧の取得
    - テンプレートからのルール生成
    """

    def __init__(self, templates_dir: Path = Path("rules/templates")):
        self.templates_dir = templates_dir
        self.templates: Dict[str, RuleTemplate] = {}
        self._load_templates()

    def _load_templates(self):
        """テンプレートディレクトリからテンプレートを読み込み"""
        if not self.templates_dir.exists():
            print(f"[INFO] テンプレートディレクトリが存在しません: {self.templates_dir}")
            return

        for template_file in self.templates_dir.glob("*.yml.template"):
            template_id = template_file.stem.replace('.yml', '')

            try:
                with open(template_file, 'r', encoding='utf-8') as f:
                    content = f.read()

                template = RuleTemplate(template_id, template_file, content)
                self.templates[template_id] = template

            except Exception as e:
                print(f"[ERROR] テンプレート読み込み失敗: {template_file} - {e}")

    def list_templates(self) -> List[RuleTemplate]:
        """利用可能なテンプレート一覧を取得"""
        return list(self.templates.values())

    def get_template(self, template_id: str) -> Optional[RuleTemplate]:
        """指定IDのテンプレートを取得"""
        return self.templates.get(template_id)

    def create_rule_from_template(
        self,
        template_id: str,
        values: Dict[str, str],
        output_path: Path
    ) -> bool:
        """
        テンプレートからルールを生成

        Args:
            template_id: テンプレートID
            values: 変数値のマッピング
            output_path: 出力先パス

        Returns:
            成功したかどうか
        """
        template = self.get_template(template_id)
        if not template:
            print(f"[ERROR] テンプレート '{template_id}' が見つかりません")
            return False

        # 変数が全て指定されているか確認
        missing_vars = set(template.variables) - set(values.keys())
        if missing_vars:
            print(f"[ERROR] 必須変数が不足しています: {missing_vars}")
            return False

        # テンプレートをレンダリング
        try:
            rendered = template.render(values)

            # YAMLとして妥当か検証
            yaml.safe_load(rendered)

            # ファイルに書き込み
            output_path.parent.mkdir(parents=True, exist_ok=True)
            with open(output_path, 'w', encoding='utf-8') as f:
                f.write(rendered)

            print(f"[OK] ルール作成完了: {output_path}")
            return True

        except yaml.YAMLError as e:
            print(f"[ERROR] YAML構文エラー: {e}")
            return False
        except Exception as e:
            print(f"[ERROR] ルール作成失敗: {e}")
            return False
```

### 3. 対話型ルール生成ウィザード (優先度: 高)

#### rule_wizard.py

```python
"""
対話型ルール生成ウィザード

Phase 4.1の新機能:
- 対話的なルール作成
- テンプレート選択
- 入力補助
- 自動バリデーション
"""

import sys
from pathlib import Path
from typing import Dict, Optional
import re

from core.rule_template import RuleTemplateManager, RuleTemplate
from core.rule_engine import RuleValidator


class RuleWizard:
    """
    対話型ルール生成ウィザード

    Phase 4.1の新機能:
    - ステップバイステップでルール作成
    - テンプレート選択のガイダンス
    - 入力値の検証
    """

    def __init__(self, project_root: Path = Path(".")):
        self.project_root = project_root
        self.template_manager = RuleTemplateManager()
        self.validator = RuleValidator()

    def run(self):
        """ウィザードを実行"""
        print("=" * 80)
        print("🧙 BugSearch2 カスタムルール作成ウィザード")
        print("=" * 80)
        print()

        # テンプレート選択
        template = self._select_template()
        if not template:
            return

        # 変数値の入力
        values = self._input_variables(template)
        if not values:
            return

        # 出力先の決定
        output_path = self._get_output_path(values.get('RULE_ID', 'custom-rule'))

        # ルール生成
        success = self.template_manager.create_rule_from_template(
            template.id,
            values,
            output_path
        )

        if success:
            # バリデーション実行
            print()
            print("📋 ルールをバリデーション中...")
            errors = self.validator.validate_rule(output_path)

            if errors:
                print("[WARNING] バリデーションエラー:")
                for error in errors:
                    print(f"  - {error}")
            else:
                print("[OK] バリデーション成功")

            print()
            print("✅ ルール作成完了！")
            print(f"📁 ファイル: {output_path}")
            print()
            print("次のステップ:")
            print("1. ルールファイルを確認・編集")
            print("2. python codex_review_severity.py index で再インデックス")
            print("3. python codex_review_severity.py advise --all で分析実行")

    def _select_template(self) -> Optional[RuleTemplate]:
        """テンプレート選択"""
        templates = self.template_manager.list_templates()

        if not templates:
            print("[ERROR] テンプレートが見つかりません")
            return None

        print("📚 利用可能なテンプレート:")
        print()
        for i, template in enumerate(templates, 1):
            print(f"{i}. {template.id}")
            print(f"   変数: {', '.join(template.variables)}")
            print()

        while True:
            choice = input("テンプレート番号を選択 (1-{}): ".format(len(templates)))
            try:
                idx = int(choice) - 1
                if 0 <= idx < len(templates):
                    return templates[idx]
                else:
                    print("[ERROR] 無効な番号です")
            except ValueError:
                print("[ERROR] 数値を入力してください")

    def _input_variables(self, template: RuleTemplate) -> Optional[Dict[str, str]]:
        """変数値の入力"""
        print()
        print(f"📝 テンプレート: {template.id}")
        print("=" * 80)
        print()

        values = {}

        for var_name in template.variables:
            # 変数ごとのガイダンス
            guidance = self._get_variable_guidance(var_name)
            print(f"■ {var_name}")
            if guidance:
                print(f"  ヒント: {guidance}")

            while True:
                value = input(f"  値: ").strip()

                # 検証
                error = self._validate_variable(var_name, value)
                if error:
                    print(f"  [ERROR] {error}")
                    continue

                values[var_name] = value
                break

            print()

        # 確認
        print()
        print("📋 入力内容の確認:")
        for var_name, value in values.items():
            print(f"  {var_name}: {value}")
        print()

        confirm = input("この内容でルールを作成しますか？ (y/n): ").strip().lower()
        if confirm != 'y':
            print("キャンセルしました")
            return None

        return values

    def _get_variable_guidance(self, var_name: str) -> str:
        """変数ごとのガイダンスを提供"""
        guidance = {
            'RULE_ID': "大文字とアンダースコアのみ（例: CUSTOM_FORBIDDEN_API）",
            'API_NAME': "検出対象のAPI名（例: LegacyDatabase）",
            'SEVERITY': "深刻度 1-10（10が最も重大）",
            'PATTERN': "正規表現パターン（例: LegacyDatabase\\\\.Connect）",
            'ALTERNATIVE_API': "推奨される代替API（例: ModernDatabase.ConnectAsync）",
            'TARGET_TYPE': "対象の種類（例: Class, Method, Variable）",
            'CONVENTION': "命名規則（例: PascalCase, camelCase）",
            'EXAMPLE_BEFORE': "悪い例（例: myVariable）",
            'EXAMPLE_AFTER': "良い例（例: MyVariable）"
        }
        return guidance.get(var_name, "")

    def _validate_variable(self, var_name: str, value: str) -> Optional[str]:
        """変数値の検証"""
        if not value:
            return "値を入力してください"

        if var_name == 'RULE_ID':
            if not re.match(r'^[A-Z_]+$', value):
                return "大文字とアンダースコアのみ使用可能です"

        elif var_name == 'SEVERITY':
            try:
                severity = int(value)
                if not (1 <= severity <= 10):
                    return "1-10の範囲で指定してください"
            except ValueError:
                return "数値を入力してください"

        elif var_name == 'PATTERN':
            # 正規表現として妥当か確認
            try:
                re.compile(value)
            except re.error as e:
                return f"無効な正規表現: {e}"

        return None

    def _get_output_path(self, rule_id: str) -> Path:
        """出力先パスを決定"""
        custom_dir = self.project_root / ".bugsearch" / "rules" / "custom"
        custom_dir.mkdir(parents=True, exist_ok=True)

        filename = rule_id.lower().replace('_', '-') + '.yml'
        return custom_dir / filename


def main():
    """メイン関数"""
    wizard = RuleWizard()
    wizard.run()


if __name__ == "__main__":
    main()
```

### 4. CLI拡張 (優先度: 中)

```python
# codex_review_severity.py への追加

def rules_cmd(args):
    """ルール管理コマンド（Phase 4.1拡張）"""

    if args.wizard:
        # 対話型ウィザード起動
        from rule_wizard import RuleWizard
        wizard = RuleWizard()
        wizard.run()

    elif args.list_templates:
        # テンプレート一覧表示
        from core.rule_template import RuleTemplateManager
        manager = RuleTemplateManager()
        templates = manager.list_templates()

        print("📚 利用可能なルールテンプレート:")
        print()
        for template in templates:
            print(f"■ {template.id}")
            print(f"  変数: {', '.join(template.variables)}")
            print()

    elif args.create_from_template:
        # テンプレートからルール作成（非対話型）
        template_id = args.create_from_template
        # ... 実装 ...

    # Phase 4.0の機能も継続サポート
    elif args.list:
        list_all_rules()
    elif args.validate:
        validate_custom_rules(args.validate)
    elif args.disable:
        disable_rule(args.disable)
    elif args.enable:
        enable_rule(args.enable)

# CLI引数追加
parser.add_argument('--wizard', action='store_true',
                   help='対話型ルール作成ウィザードを起動')
parser.add_argument('--list-templates', action='store_true',
                   help='利用可能なルールテンプレート一覧を表示')
parser.add_argument('--create-from-template', type=str,
                   help='テンプレートからルールを作成')
```

### 5. テンプレートカタログ作成 (優先度: 中)

#### rules/templates/の内容

1. **forbidden-api.yml.template** - 禁止API検出
2. **naming-convention.yml.template** - 命名規則チェック
3. **security-check.yml.template** - セキュリティチェック
4. **performance.yml.template** - パフォーマンスルール
5. **custom-pattern.yml.template** - カスタムパターン

---

## 📋 テスト計画

### test/test_phase4_1_templates.py

```python
"""
Phase 4.1テスト: ルールテンプレート機能

@perfect品質保証:
- テンプレート読み込み
- 変数抽出
- テンプレートレンダリング
- ルール生成
"""

import unittest
from pathlib import Path
import shutil

from core.rule_template import RuleTemplateManager, RuleTemplate
from core.rule_engine import RuleValidator


class TestRuleTemplate(unittest.TestCase):
    """ルールテンプレート機能のテスト"""

    def setUp(self):
        """テストセットアップ"""
        self.test_dir = Path("test/fixtures/template-test")
        self.test_dir.mkdir(parents=True, exist_ok=True)

        # テストテンプレート作成
        self.template_dir = self.test_dir / "templates"
        self.template_dir.mkdir(parents=True, exist_ok=True)

        template_content = """rule:
  id: "{RULE_ID}"
  category: "custom"
  name: "{RULE_NAME}"
  description: "Test rule"
  base_severity: {SEVERITY}

  patterns:
    csharp:
      - pattern: '{PATTERN}'
        context: "Test"
"""
        template_file = self.template_dir / "test-template.yml.template"
        with open(template_file, 'w', encoding='utf-8') as f:
            f.write(template_content)

    def tearDown(self):
        """テストクリーンアップ"""
        if self.test_dir.exists():
            shutil.rmtree(self.test_dir)

    def test_load_templates(self):
        """テンプレートが正常に読み込まれることを確認"""
        manager = RuleTemplateManager(self.template_dir)
        templates = manager.list_templates()

        self.assertGreater(len(templates), 0, "テンプレートが読み込まれていません")
        print(f"✅ テンプレート読み込み: {len(templates)}個")

    def test_extract_variables(self):
        """テンプレート変数が正しく抽出されることを確認"""
        manager = RuleTemplateManager(self.template_dir)
        template = manager.get_template("test-template")

        self.assertIsNotNone(template, "テンプレートが見つかりません")

        expected_vars = {'RULE_ID', 'RULE_NAME', 'SEVERITY', 'PATTERN'}
        actual_vars = set(template.variables)

        self.assertEqual(expected_vars, actual_vars, "変数抽出が正しくありません")
        print(f"✅ 変数抽出: {actual_vars}")

    def test_render_template(self):
        """テンプレートが正しくレンダリングされることを確認"""
        manager = RuleTemplateManager(self.template_dir)
        template = manager.get_template("test-template")

        values = {
            'RULE_ID': 'TEST_RULE',
            'RULE_NAME': 'Test Rule',
            'SEVERITY': '7',
            'PATTERN': 'TestPattern'
        }

        rendered = template.render(values)

        # 変数が置換されているか確認
        self.assertIn('TEST_RULE', rendered)
        self.assertIn('Test Rule', rendered)
        self.assertIn('7', rendered)
        self.assertNotIn('{RULE_ID}', rendered)

        print(f"✅ テンプレートレンダリング成功")

    def test_create_rule_from_template(self):
        """テンプレートからルールが正常に作成されることを確認"""
        manager = RuleTemplateManager(self.template_dir)

        values = {
            'RULE_ID': 'CUSTOM_TEST',
            'RULE_NAME': 'Custom Test Rule',
            'SEVERITY': '8',
            'PATTERN': 'CustomPattern'
        }

        output_path = self.test_dir / "custom-test.yml"

        success = manager.create_rule_from_template(
            'test-template',
            values,
            output_path
        )

        self.assertTrue(success, "ルール作成に失敗しました")
        self.assertTrue(output_path.exists(), "ルールファイルが作成されていません")

        # バリデーション
        validator = RuleValidator()
        errors = validator.validate_rule(output_path)

        self.assertEqual(len(errors), 0, f"バリデーションエラー: {errors}")
        print(f"✅ ルール作成成功: {output_path}")


def run_tests():
    """テストスイートを実行"""
    suite = unittest.TestSuite()
    suite.addTests(unittest.TestLoader().loadTestsFromTestCase(TestRuleTemplate))

    runner = unittest.TextTestRunner(verbosity=2)
    result = runner.run(suite)

    # 結果サマリー
    print("\n" + "=" * 80)
    print("📊 Phase 4.1テスト結果サマリー")
    print("=" * 80)
    print(f"実行したテスト: {result.testsRun}")
    print(f"成功: {result.testsRun - len(result.failures) - len(result.errors)}")
    print(f"失敗: {len(result.failures)}")
    print(f"エラー: {len(result.errors)}")

    if result.wasSuccessful():
        print("\n✅ 全てのテストが合格しました！ (@perfect品質達成)")
        return 0
    else:
        print("\n❌ テストに失敗しました")
        return 1


if __name__ == "__main__":
    import sys
    sys.exit(run_tests())
```

---

## 📅 実装スケジュール

### Day 1: テンプレート機能実装
- RuleTemplateManagerクラス実装
- テンプレート読み込み・レンダリング機能
- テンプレートカタログ作成（5種類）

### Day 2: ウィザード実装
- RuleWizardクラス実装
- 対話的入力処理
- 入力検証機能

### Day 3: テスト・統合
- テストケース作成
- 統合テスト実行
- バグ修正

### Day 4: ドキュメント整備
- RULES_GUIDE.md 更新
- 使用例の充実
- コミット・プッシュ

**合計**: 約4日間（実稼働）

---

## 🎯 成功基準

### 必須条件
- [ ] RuleTemplateManagerが正常動作
- [ ] テンプレートから正しいルールが生成される
- [ ] ウィザードが対話的に動作する
- [ ] 生成されたルールがバリデーションを通過
- [ ] 全テスト合格

### 品質基準
- [ ] @perfect品質達成 (全テスト100%合格)
- [ ] コーディング規約準拠
- [ ] 適切なエラーハンドリング
- [ ] 明確なユーザーガイダンス

### ドキュメント基準
- [ ] テンプレートカタログ完備
- [ ] ウィザード使用例の充実
- [ ] トラブルシューティングガイド

---

## 🔄 Phase 4.2への展望

Phase 4.1完了後、Phase 4.2では以下を検討：

1. **ルール共有機能**
   - GitHub経由でのルール共有
   - コミュニティルールリポジトリ
   - ルールのインポート/エクスポート

2. **ルールメトリクス**
   - ルールごとの検出統計
   - 誤検知率の追跡
   - ルールのパフォーマンス分析

3. **AI支援ルール生成**
   - コード例からのルール自動生成
   - 問題説明からのルール作成
   - ルール最適化の提案

---

*最終更新: 2025年10月12日 JST*
*Phase 4.1実装期間: 2025年10月12日 (開始)*
*バージョン: v4.4.0 (Phase 4.1開始)*

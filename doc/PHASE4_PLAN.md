# Phase 4 実装計画: カスタムルールシステムの実装

*バージョン: v4.3.0 (Phase 4.0開始)*
*作成日: 2025年10月12日 JST*
*最終更新: 2025年10月12日 JST*

## 🎯 Phase 4の目標

**プロジェクト固有のカスタムルールシステムの実装**

Phase 3で完成したYAMLルールシステムの上に、ユーザーが独自のルールを定義・管理できる柔軟なシステムを構築します。

### 達成基準
- [ ] プロジェクト固有のルール定義機能
- [ ] カスタムルールの自動読み込み
- [ ] ルール優先順位システム
- [ ] ルールの有効/無効切り替え
- [ ] カスタムルールのバリデーション
- [ ] @perfect品質維持 (全テスト100%合格)

---

## 📊 現在の状況

### Phase 3完了 (v4.2.2) ✅
- ✅ 10個のコアYAMLルール実装
- ✅ 4カテゴリ完全サポート
- ✅ 技術スタック対応型解析
- ✅ 全テスト100%合格

### Phase 4.0の新機能
Phase 3で実装したルールシステムを拡張し、以下を実現：

1. **プロジェクト固有ルールのサポート**
   - `.bugsearch/rules/` ディレクトリの自動検出
   - プロジェクト固有のYAMLルール定義
   - コアルールとカスタムルールの統合

2. **ルール優先順位システム**
   - カスタムルール > コアルール
   - 同名ルールの上書き機能
   - ルールの無効化機能

3. **ルール管理機能**
   - ルールの有効/無効切り替え
   - ルールバリデーション
   - ルール設定の保存

---

## 🔧 実装項目

### 1. カスタムルールディレクトリ構造 (優先度: 高)

```
project/
├── .bugsearch/
│   ├── config.yml                    # プロジェクト設定
│   └── rules/                        # カスタムルールディレクトリ
│       ├── custom/                   # カスタムカテゴリ
│       │   ├── my-rule-1.yml
│       │   └── my-rule-2.yml
│       ├── database/                 # コアカテゴリ拡張
│       │   └── custom-query.yml
│       └── disabled.yml              # 無効化するコアルール一覧
```

### 2. カスタムルール定義フォーマット (優先度: 高)

#### 基本的なカスタムルール
```yaml
# .bugsearch/rules/custom/forbidden-api.yml
rule:
  id: "CUSTOM_FORBIDDEN_API"
  category: "custom"
  name: "Forbidden API Usage"
  description: "社内で禁止されているAPIの使用を検出"
  base_severity: 8

  patterns:
    csharp:
      - pattern: 'LegacyDatabase\\.Connect'
        context: "Legacy database API usage (forbidden)"

      - pattern: 'OldAuthService\\.Authenticate'
        context: "Deprecated authentication service"

  context_modifiers:
    - condition:
        code_context: '// TEMPORARY'
      action:
        severity_adjustment: -3
        note: "一時的な使用としてマークされています"

  fixes:
    csharp:
      - "新しいAPI使用: ModernDatabase.ConnectAsync()"
      - "新しい認証: AuthServiceV2.AuthenticateAsync()"
```

#### ルール無効化設定
```yaml
# .bugsearch/rules/disabled.yml
disabled_rules:
  # コアルールの無効化
  - "DB_SELECT_STAR"           # SELECT * を許可
  - "SOLID_LARGE_CLASS"        # 大きなクラスを許可

  # カテゴリ全体の無効化
  - category: "performance"    # パフォーマンスルール全体を無効化

  # 特定ファイルでのみ無効化
  - rule: "SEC_SQL_INJECTION"
    paths:
      - "test/**/*.cs"         # テストファイルでは無効
      - "legacy/**/*.php"      # レガシーコードでは無効
```

### 3. ルールローダーの拡張 (優先度: 高)

#### core/rule_engine.py の拡張

```python
from pathlib import Path
from typing import List, Dict, Optional
from dataclasses import dataclass

@dataclass
class RuleConfig:
    """ルール設定"""
    enabled: bool = True
    priority: int = 0  # 高いほど優先
    override_severity: Optional[int] = None

class RuleLoader:
    """拡張ルールローダー"""

    def __init__(self, project_root: Path):
        self.project_root = project_root
        self.core_rules_dir = Path("rules")
        self.custom_rules_dir = project_root / ".bugsearch" / "rules"
        self.disabled_rules_file = self.custom_rules_dir / "disabled.yml"

    def load_all_rules(self) -> List[Rule]:
        """
        全ルールを読み込み（コア + カスタム）

        優先順位:
        1. カスタムルール（.bugsearch/rules/）
        2. コアルール（rules/）

        無効化:
        - disabled.yml に記載されたルールはスキップ
        """
        # 無効化設定を読み込み
        disabled = self._load_disabled_rules()

        # コアルール読み込み
        core_rules = self._load_from_directory(self.core_rules_dir, priority=0)

        # カスタムルール読み込み
        custom_rules = []
        if self.custom_rules_dir.exists():
            custom_rules = self._load_from_directory(
                self.custom_rules_dir,
                priority=100
            )

        # ルールをマージ（カスタムルールで上書き）
        all_rules = self._merge_rules(core_rules, custom_rules)

        # 無効化されたルールを除外
        active_rules = [r for r in all_rules if not self._is_disabled(r, disabled)]

        return active_rules

    def _load_disabled_rules(self) -> Dict:
        """無効化設定を読み込み"""
        if not self.disabled_rules_file.exists():
            return {}

        with open(self.disabled_rules_file, 'r', encoding='utf-8') as f:
            config = yaml.safe_load(f)
            return config.get('disabled_rules', [])

    def _merge_rules(self, core: List[Rule], custom: List[Rule]) -> List[Rule]:
        """
        ルールをマージ

        同じIDのルールがある場合、カスタムルールで上書き
        """
        rules_dict = {r.id: r for r in core}

        for custom_rule in custom:
            if custom_rule.id in rules_dict:
                print(f"⚠️  カスタムルール '{custom_rule.id}' がコアルールを上書きします")
            rules_dict[custom_rule.id] = custom_rule

        return list(rules_dict.values())

    def _is_disabled(self, rule: Rule, disabled_config: List) -> bool:
        """ルールが無効化されているか確認"""
        for item in disabled_config:
            if isinstance(item, str):
                # ルールID指定
                if rule.id == item:
                    return True
            elif isinstance(item, dict):
                # カテゴリ指定
                if item.get('category') == rule.category:
                    return True
                # パス指定の無効化
                if item.get('rule') == rule.id and 'paths' in item:
                    # TODO: ファイルパスマッチング実装
                    pass

        return False
```

### 4. ルールバリデーション (優先度: 中)

```python
class RuleValidator:
    """カスタムルールのバリデーション"""

    def validate_rule(self, rule_file: Path) -> List[str]:
        """
        ルールファイルをバリデーション

        Returns:
            エラーメッセージのリスト（空なら正常）
        """
        errors = []

        try:
            with open(rule_file, 'r', encoding='utf-8') as f:
                data = yaml.safe_load(f)

            # 必須フィールドチェック
            if 'rule' not in data:
                errors.append("'rule'キーが見つかりません")
                return errors

            rule = data['rule']

            # ID チェック
            if 'id' not in rule:
                errors.append("'id'フィールドが必須です")
            elif not rule['id'].isupper():
                errors.append(f"ID '{rule['id']}' は大文字で定義してください")

            # カテゴリ チェック
            valid_categories = ['database', 'security', 'solid', 'performance', 'custom']
            if 'category' not in rule:
                errors.append("'category'フィールドが必須です")
            elif rule['category'] not in valid_categories:
                errors.append(f"無効なカテゴリ: {rule['category']}")

            # パターン チェック
            if 'patterns' not in rule:
                errors.append("'patterns'フィールドが必須です")
            else:
                errors.extend(self._validate_patterns(rule['patterns']))

        except yaml.YAMLError as e:
            errors.append(f"YAML構文エラー: {e}")
        except Exception as e:
            errors.append(f"予期しないエラー: {e}")

        return errors

    def _validate_patterns(self, patterns: Dict) -> List[str]:
        """パターンのバリデーション"""
        errors = []

        valid_languages = ['csharp', 'java', 'php', 'javascript', 'typescript', 'python', 'go']

        for lang, pattern_list in patterns.items():
            if lang not in valid_languages:
                errors.append(f"未サポート言語: {lang}")

            if not isinstance(pattern_list, list):
                errors.append(f"{lang}: パターンはリスト形式で定義してください")
                continue

            for i, pattern in enumerate(pattern_list):
                if 'pattern' not in pattern:
                    errors.append(f"{lang}[{i}]: 'pattern'フィールドが必須です")

                # 正規表現の妥当性チェック
                try:
                    re.compile(pattern.get('pattern', ''))
                except re.error as e:
                    errors.append(f"{lang}[{i}]: 無効な正規表現: {e}")

        return errors
```

### 5. CLI拡張 (優先度: 中)

```python
# codex_review_severity.py への追加

def rules_cmd(args):
    """ルール管理コマンド"""

    if args.list:
        # ルール一覧表示
        list_all_rules()

    elif args.validate:
        # カスタムルールのバリデーション
        validate_custom_rules(args.validate)

    elif args.disable:
        # ルールを無効化
        disable_rule(args.disable)

    elif args.enable:
        # ルールを有効化
        enable_rule(args.enable)

# CLI引数追加
parser.add_argument('rules', nargs='?', help='ルール管理コマンド')
parser.add_argument('--list', action='store_true', help='全ルールを表示')
parser.add_argument('--validate', type=str, help='カスタムルールをバリデーション')
parser.add_argument('--disable', type=str, help='ルールを無効化')
parser.add_argument('--enable', type=str, help='ルールを有効化')
```

### 6. 使用例

```bash
# カスタムルールの作成
mkdir -p .bugsearch/rules/custom
cat > .bugsearch/rules/custom/my-rule.yml << 'EOF'
rule:
  id: "CUSTOM_FORBIDDEN_API"
  category: "custom"
  name: "Forbidden API"
  description: "禁止APIの検出"
  base_severity: 8
  patterns:
    csharp:
      - pattern: 'LegacyDatabase\\.Connect'
        context: "Legacy API usage"
EOF

# ルールのバリデーション
python codex_review_severity.py rules --validate .bugsearch/rules/custom/my-rule.yml

# 全ルールの表示（コア + カスタム）
python codex_review_severity.py rules --list

# ルールの無効化
python codex_review_severity.py rules --disable DB_SELECT_STAR

# 分析実行（カスタムルール込み）
python codex_review_severity.py index
python codex_review_severity.py advise --all --out reports/custom_analysis
```

---

## 📋 テスト計画

### test/test_phase4_custom_rules.py

```python
"""
Phase 4.0テスト: カスタムルール機能

@perfect品質保証:
- カスタムルールの読み込み
- ルール優先順位
- ルール無効化
- バリデーション
"""

import unittest
from pathlib import Path
from core.rule_engine import RuleLoader, RuleValidator

class TestCustomRules(unittest.TestCase):
    """カスタムルール機能のテスト"""

    def setUp(self):
        """テストセットアップ"""
        self.test_project = Path("test/fixtures/custom-rules-project")
        self.test_project.mkdir(parents=True, exist_ok=True)

        # カスタムルールディレクトリ作成
        custom_dir = self.test_project / ".bugsearch" / "rules" / "custom"
        custom_dir.mkdir(parents=True, exist_ok=True)

    def test_load_custom_rules(self):
        """カスタムルールが読み込まれることを確認"""
        loader = RuleLoader(self.test_project)
        rules = loader.load_all_rules()

        # コアルール + カスタムルールが含まれる
        self.assertGreater(len(rules), 10)

    def test_rule_priority(self):
        """カスタムルールがコアルールを上書きすることを確認"""
        # カスタムルールで既存ルールを上書き
        # ... テスト実装
        pass

    def test_rule_disable(self):
        """ルールの無効化が機能することを確認"""
        # disabled.yml でルールを無効化
        # ... テスト実装
        pass

    def test_rule_validation(self):
        """ルールバリデーションが機能することを確認"""
        validator = RuleValidator()

        # 正常なルール
        errors = validator.validate_rule(Path("test/fixtures/valid-rule.yml"))
        self.assertEqual(len(errors), 0)

        # 不正なルール
        errors = validator.validate_rule(Path("test/fixtures/invalid-rule.yml"))
        self.assertGreater(len(errors), 0)
```

---

## 📅 実装スケジュール

### Day 1: 基盤実装
- RuleLoader拡張
- カスタムルールディレクトリのサポート
- ルールマージ機能

### Day 2: 管理機能実装
- ルール無効化機能
- ルールバリデーション
- CLI拡張

### Day 3: テスト・デバッグ
- テストケース作成
- 統合テスト実行
- バグ修正

### Day 4: ドキュメント整備
- RULES_GUIDE.md 作成
- README.md 更新
- コミット・プッシュ

**合計**: 約4日間（実稼働）

---

## 🎯 成功基準

### 必須条件
- [ ] カスタムルールが正常に読み込まれる
- [ ] ルール優先順位が正しく機能する
- [ ] ルールの無効化が機能する
- [ ] バリデーションが正しく動作する
- [ ] 全テスト合格

### 品質基準
- [ ] @perfect品質達成 (全テスト100%合格)
- [ ] コーディング規約準拠
- [ ] 適切なエラーハンドリング
- [ ] 明確なエラーメッセージ

### ドキュメント基準
- [ ] RULES_GUIDE.md 作成完了
- [ ] 使用例の充実
- [ ] トラブルシューティングガイド

---

## 🔄 Phase 4.1への展望

Phase 4.0完了後、Phase 4.1では以下を検討：

1. **ルールテンプレート機能**
   - よく使うルールのテンプレート提供
   - 対話型ルール生成ウィザード

2. **ルール共有機能**
   - GitHub経由でのルール共有
   - コミュニティルールリポジトリ

3. **ルールメトリクス**
   - ルールごとの検出統計
   - 誤検知率の追跡

---

*最終更新: 2025年10月12日 JST*
*Phase 4実装期間: 2025年10月12日 (開始)*
*バージョン: v4.3.0 (Phase 4.0開始)*

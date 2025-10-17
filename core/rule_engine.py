"""
ルールエンジン

YAMLルールファイルを読み込み、コード解析を実行
"""

import re
import yaml
from pathlib import Path
from typing import List, Dict, Any, Optional
from collections import defaultdict

from .models import Rule, RulePattern, ContextModifier, TechStack, ProjectConfig


class RuleEngine:
    """ルールベースのコード解析エンジン"""

    def __init__(self, rules_dir: str = "rules", project_config: Optional[ProjectConfig] = None):
        """
        初期化

        Args:
            rules_dir: ルールディレクトリのパス
            project_config: プロジェクト設定（技術スタック情報を含む）
        """
        self.rules_dir = Path(rules_dir)
        self.project_config = project_config
        self.rules: List[Rule] = []
        self.rules_by_language: Dict[str, List[Rule]] = defaultdict(list)

        # ルールを読み込み
        if self.rules_dir.exists():
            self.load_rules()
        else:
            print(f"⚠️  ルールディレクトリが見つかりません: {rules_dir}")

    def load_rules(self):
        """全YAMLルールファイルを読み込み"""
        rule_files = list(self.rules_dir.rglob("*.yml")) + list(self.rules_dir.rglob("*.yaml"))

        loaded_count = 0
        for rule_file in rule_files:
            try:
                # 複数ルール対応: 1ファイルに複数のルール定義が含まれる場合に対応
                rules = self._load_rule_file(rule_file)
                if rules:
                    for rule in rules:
                        self.rules.append(rule)

                        # 言語ごとにインデックス化
                        for language in rule.patterns.keys():
                            self.rules_by_language[language].append(rule)

                        loaded_count += 1

            except Exception as e:
                print(f"[WARNING] ルール読み込みエラー: {rule_file}")
                print(f"          {e}")

        print(f"[OK] {loaded_count}個のルールを読み込みました")

    def _load_rule_file(self, rule_file: Path) -> List[Rule]:
        """
        YAMLルールファイルを読み込んでRuleオブジェクトのリストに変換

        複数ルール対応: YAMLファイルに複数のルール定義（`---`区切り）が
        含まれる場合にも対応します。
        """
        rules = []

        with open(rule_file, 'r', encoding='utf-8') as f:
            # yaml.safe_load_all()で複数ドキュメントに対応
            for data in yaml.safe_load_all(f):
                if not data or 'rule' not in data:
                    continue

                rule_data = data['rule']

                # パターンの変換
                patterns = {}
                if 'patterns' in rule_data:
                    for language, pattern_list in rule_data['patterns'].items():
                        patterns[language] = [
                            RulePattern(
                                pattern=p['pattern'],
                                context=p['context'],
                                language=language
                            )
                            for p in pattern_list
                        ]

                # コンテキスト修飾子の変換
                context_modifiers = []
                if 'context_modifiers' in rule_data:
                    for modifier_data in rule_data['context_modifiers']:
                        context_modifiers.append(ContextModifier(
                            condition=modifier_data['condition'],
                            severity_adjustment=modifier_data['action']['severity_adjustment'],
                            note=modifier_data['action'].get('note')
                        ))

                # 修正方法の取得
                fixes = rule_data.get('fixes', {})

                rule = Rule(
                    id=rule_data['id'],
                    category=rule_data['category'],
                    name=rule_data['name'],
                    description=rule_data['description'],
                    base_severity=rule_data['base_severity'],
                    patterns=patterns,
                    context_modifiers=context_modifiers,
                    fixes=fixes
                )

                rules.append(rule)

        return rules

    def analyze_code(
        self,
        code: str,
        file_path: str,
        language: str
    ) -> List[Dict[str, Any]]:
        """
        コードを解析して問題を検出

        Args:
            code: 解析対象のコード
            file_path: ファイルパス
            language: 言語 (csharp, java, php, etc.)

        Returns:
            検出された問題のリスト
        """
        issues = []

        # 該当言語のルールを取得
        applicable_rules = self.rules_by_language.get(language, [])

        # プロジェクト設定で除外されたルールをフィルタ
        if self.project_config and self.project_config.exclude_rules:
            applicable_rules = [
                rule for rule in applicable_rules
                if rule.id not in self.project_config.exclude_rules
            ]

        for rule in applicable_rules:
            rule_issues = self._apply_rule(rule, code, file_path, language)
            issues.extend(rule_issues)

        return issues

    def _apply_rule(
        self,
        rule: Rule,
        code: str,
        file_path: str,
        language: str
    ) -> List[Dict[str, Any]]:
        """
        1つのルールをコードに適用

        Args:
            rule: 適用するルール
            code: コード
            file_path: ファイルパス
            language: 言語

        Returns:
            検出された問題のリスト
        """
        issues = []
        patterns = rule.get_patterns_for_language(language)

        for pattern_info in patterns:
            try:
                # 正規表現パターンでマッチング
                matches = list(re.finditer(pattern_info.pattern, code, re.IGNORECASE | re.MULTILINE))

                for match in matches:
                    # マッチした位置の行番号を計算
                    line_num = code[:match.start()].count('\n') + 1

                    # 技術スタックに基づいて深刻度を調整
                    severity, notes = self._evaluate_severity(rule, code)

                    # 修正方法を取得
                    fixes = self._get_relevant_fixes(rule)

                    issue = {
                        'rule_id': rule.id,
                        'category': rule.category,
                        'name': rule.name,
                        'description': rule.description,
                        'severity': severity,
                        'base_severity': rule.base_severity,
                        'file_path': file_path,
                        'line': line_num,
                        'pattern_context': pattern_info.context,
                        'matched_text': match.group(0)[:100],  # 最初の100文字のみ
                        'notes': notes,
                        'fixes': fixes,
                    }

                    issues.append(issue)

            except re.error as e:
                print(f"[WARNING] 正規表現エラー (rule: {rule.id}): {e}")

        return issues

    def _evaluate_severity(
        self,
        rule: Rule,
        code_context: str,
        tags: Optional[List[str]] = None
    ) -> tuple[int, List[str]]:
        """
        技術スタックを考慮して深刻度を評価

        Args:
            rule: 解析ルール
            code_context: コードのコンテキスト
            tags: ファイルに付与されたタグリスト

        Returns:
            (調整後の深刻度, 追加ノートのリスト)
        """
        # プロジェクト設定がない、または調整が無効の場合
        if (not self.project_config or
            not self.project_config.severity_adjustments_enabled):
            return rule.base_severity, []

        # 技術スタックを使って評価（タグも渡す）
        tech_stack = self.project_config.tech_stack
        return rule.evaluate_severity(tech_stack, code_context, tags)

    def _get_relevant_fixes(self, rule: Rule) -> List[str]:
        """技術スタックに応じた修正方法を取得"""
        if not self.project_config:
            return rule.fixes.get('default', [])

        tech_stack = self.project_config.tech_stack
        return rule.get_relevant_fixes(tech_stack)

    def get_rule_by_id(self, rule_id: str) -> Optional[Rule]:
        """ルールIDからルールを取得"""
        for rule in self.rules:
            if rule.id == rule_id:
                return rule
        return None

    def get_rules_by_category(self, category: str) -> List[Rule]:
        """カテゴリからルールのリストを取得"""
        return [rule for rule in self.rules if rule.category == category]

    def get_severity_distribution(self, issues: List[Dict[str, Any]]) -> Dict[str, int]:
        """問題の深刻度分布を取得"""
        distribution = {
            'critical': 0,  # 9-10
            'high': 0,      # 7-8
            'medium': 0,    # 4-6
            'low': 0,       # 1-3
        }

        for issue in issues:
            severity = issue['severity']
            if severity >= 9:
                distribution['critical'] += 1
            elif severity >= 7:
                distribution['high'] += 1
            elif severity >= 4:
                distribution['medium'] += 1
            else:
                distribution['low'] += 1

        return distribution

    def format_issue_report(self, issues: List[Dict[str, Any]]) -> str:
        """問題のレポートを整形"""
        if not issues:
            return "[OK] 問題は検出されませんでした"

        # 深刻度でソート
        sorted_issues = sorted(issues, key=lambda x: x['severity'], reverse=True)

        lines = [
            "=" * 80,
            f"検出された問題: {len(issues)}件",
            "=" * 80,
            ""
        ]

        # 深刻度分布
        distribution = self.get_severity_distribution(issues)
        lines.append("深刻度分布:")
        lines.append(f"  [CRITICAL] (9-10): {distribution['critical']}件")
        lines.append(f"  [HIGH]     (7-8):  {distribution['high']}件")
        lines.append(f"  [MEDIUM]   (4-6):  {distribution['medium']}件")
        lines.append(f"  [LOW]      (1-3):  {distribution['low']}件")
        lines.append("")
        lines.append("-" * 80)
        lines.append("")

        # 各問題の詳細
        for i, issue in enumerate(sorted_issues, 1):
            severity = issue['severity']
            severity_icon = self._get_severity_icon(severity)

            lines.append(f"[{i}] {severity_icon} {issue['name']} (深刻度: {severity}/10)")
            lines.append(f"    ファイル: {issue['file_path']}:{issue['line']}")
            lines.append(f"    説明: {issue['description']}")

            # 技術スタックによる注釈
            if issue['notes']:
                lines.append(f"    [NOTE]:")
                for note in issue['notes']:
                    lines.append(f"      {note}")

            # 推奨修正方法
            if issue['fixes']:
                lines.append(f"    [FIX]:")
                for fix in issue['fixes'][:3]:  # 最大3つ
                    lines.append(f"      - {fix}")

            lines.append("")

        return "\n".join(lines)

    def _get_severity_icon(self, severity: int) -> str:
        """深刻度に応じたアイコンを返す"""
        if severity >= 9:
            return "[CRITICAL]"
        elif severity >= 7:
            return "[HIGH]"
        elif severity >= 4:
            return "[MEDIUM]"
        else:
            return "[LOW]"


# ========================================
# Phase 4.0: カスタムルールシステム
# ========================================

class RuleLoader:
    """
    カスタムルールをサポートする拡張ルールローダー

    Phase 4.0の新機能:
    - プロジェクト固有のカスタムルール (.bugsearch/rules/)
    - ルール優先順位 (カスタム > コア)
    - ルール無効化 (disabled.yml)
    """

    def __init__(self, project_root: Path = Path(".")):
        """
        初期化

        Args:
            project_root: プロジェクトのルートディレクトリ
        """
        self.project_root = project_root
        self.core_rules_dir = Path("rules")
        self.config_rules_dir = Path("config")  # 技術スタック別拡張ルール
        self.custom_rules_dir = project_root / ".bugsearch" / "rules"
        self.disabled_rules_file = self.custom_rules_dir / "disabled.yml"

    def load_all_rules(self, include_custom: bool = True, include_config: bool = True) -> List[Rule]:
        """
        全ルールを読み込み（コア + 拡張 + カスタム）

        Args:
            include_custom: カスタムルールを含めるか
            include_config: 技術スタック別拡張ルール (config/) を含めるか

        Returns:
            読み込まれたルールのリスト

        優先順位:
            1. カスタムルール (.bugsearch/rules/) - 最高優先
            2. 技術スタック別拡張ルール (config/) - 中優先
            3. コアルール (rules/) - 最低優先

        無効化:
            - disabled.yml に記載されたルールはスキップ
        """
        # 無効化設定を読み込み
        disabled = self._load_disabled_config()

        # コアルール読み込み
        core_engine = RuleEngine(rules_dir=str(self.core_rules_dir))
        core_rules = core_engine.rules
        print(f"[INFO] コアルール: {len(core_rules)}個読み込み")

        # 技術スタック別拡張ルール読み込み (config/)
        config_rules = []
        if include_config and self.config_rules_dir.exists():
            config_engine = RuleEngine(rules_dir=str(self.config_rules_dir))
            config_rules = config_engine.rules
            if config_rules:
                print(f"[INFO] 技術スタック別拡張ルール (config/): {len(config_rules)}個読み込み")

        # カスタムルール読み込み
        custom_rules = []
        if include_custom and self.custom_rules_dir.exists():
            custom_engine = RuleEngine(rules_dir=str(self.custom_rules_dir))
            custom_rules = [r for r in custom_engine.rules
                           if not str(r.id).endswith('disabled')]  # disabled.yml自体を除外
            if custom_rules:
                print(f"[INFO] カスタムルール: {len(custom_rules)}個読み込み")

        # ルールをマージ（優先度: カスタム > config > コア）
        # まずコアと拡張をマージ
        temp_rules = self._merge_rules(core_rules, config_rules)
        # 次にカスタムルールでさらに上書き
        all_rules = self._merge_rules(temp_rules, custom_rules)

        # 無効化されたルールを除外
        active_rules = [r for r in all_rules if not self._is_disabled(r, disabled)]

        disabled_count = len(all_rules) - len(active_rules)
        if disabled_count > 0:
            print(f"[INFO] {disabled_count}個のルールが無効化されています")

        print(f"[INFO] 有効なルール総数: {len(active_rules)}個")

        return active_rules

    def _load_disabled_config(self) -> Dict:
        """無効化設定を読み込み"""
        if not self.disabled_rules_file.exists():
            return {'disabled_rules': []}

        try:
            with open(self.disabled_rules_file, 'r', encoding='utf-8') as f:
                config = yaml.safe_load(f)
                return config if config else {'disabled_rules': []}
        except Exception as e:
            print(f"[WARNING] disabled.yml読み込みエラー: {e}")
            return {'disabled_rules': []}

    def _merge_rules(self, core: List[Rule], custom: List[Rule]) -> List[Rule]:
        """
        ルールをマージ

        同じIDのルールがある場合、カスタムルールで上書き
        """
        rules_dict = {r.id: r for r in core}

        for custom_rule in custom:
            if custom_rule.id in rules_dict:
                print(f"[INFO] カスタムルール '{custom_rule.id}' がコアルールを上書きします")
            rules_dict[custom_rule.id] = custom_rule

        return list(rules_dict.values())

    def _is_disabled(self, rule: Rule, disabled_config: Dict) -> bool:
        """ルールが無効化されているか確認"""
        disabled_list = disabled_config.get('disabled_rules', [])

        for item in disabled_list:
            if isinstance(item, str):
                # ルールID指定
                if rule.id == item:
                    return True
            elif isinstance(item, dict):
                # カテゴリ指定
                if item.get('category') == rule.category:
                    return True
                # 特定ルールの無効化
                if item.get('rule') == rule.id:
                    # TODO: パス指定の無効化は将来実装
                    return True

        return False

    def save_disabled_config(self, disabled_rules: List[str]):
        """無効化設定を保存"""
        self.custom_rules_dir.mkdir(parents=True, exist_ok=True)

        config = {'disabled_rules': disabled_rules}

        with open(self.disabled_rules_file, 'w', encoding='utf-8') as f:
            yaml.dump(config, f, allow_unicode=True, default_flow_style=False)

        print(f"[OK] 無効化設定を保存しました: {self.disabled_rules_file}")

    def disable_rule(self, rule_id: str):
        """ルールを無効化"""
        config = self._load_disabled_config()
        disabled_list = config.get('disabled_rules', [])

        if rule_id not in disabled_list:
            disabled_list.append(rule_id)
            self.save_disabled_config(disabled_list)
            print(f"[OK] ルール '{rule_id}' を無効化しました")
        else:
            print(f"[INFO] ルール '{rule_id}' は既に無効化されています")

    def enable_rule(self, rule_id: str):
        """ルールを有効化"""
        config = self._load_disabled_config()
        disabled_list = config.get('disabled_rules', [])

        if rule_id in disabled_list:
            disabled_list.remove(rule_id)
            self.save_disabled_config(disabled_list)
            print(f"[OK] ルール '{rule_id}' を有効化しました")
        else:
            print(f"[INFO] ルール '{rule_id}' は既に有効化されています")


class RuleValidator:
    """
    カスタムルールのバリデーション

    Phase 4.0の新機能:
    - ルールYAMLファイルの構文チェック
    - 必須フィールドの検証
    - 正規表現パターンの妥当性チェック
    """

    VALID_CATEGORIES = ['database', 'security', 'solid', 'performance', 'custom']
    VALID_LANGUAGES = ['csharp', 'java', 'php', 'javascript', 'typescript', 'python', 'go', 'cpp', 'c']

    def validate_rule(self, rule_file: Path) -> List[str]:
        """
        ルールファイルをバリデーション

        Args:
            rule_file: ルールファイルのパス

        Returns:
            エラーメッセージのリスト（空なら正常）
        """
        errors = []

        try:
            with open(rule_file, 'r', encoding='utf-8') as f:
                data = yaml.safe_load(f)

            # 基本構造チェック
            if not data:
                errors.append("YAMLファイルが空です")
                return errors

            if 'rule' not in data:
                errors.append("'rule'キーが見つかりません")
                return errors

            rule = data['rule']

            # 必須フィールドチェック
            errors.extend(self._validate_required_fields(rule))

            # IDフォーマットチェック
            if 'id' in rule:
                errors.extend(self._validate_id_format(rule['id']))

            # カテゴリチェック
            if 'category' in rule:
                errors.extend(self._validate_category(rule['category']))

            # 深刻度チェック
            if 'base_severity' in rule:
                errors.extend(self._validate_severity(rule['base_severity']))

            # パターンチェック
            if 'patterns' in rule:
                errors.extend(self._validate_patterns(rule['patterns']))

        except yaml.YAMLError as e:
            errors.append(f"YAML構文エラー: {e}")
        except Exception as e:
            errors.append(f"予期しないエラー: {e}")

        return errors

    def _validate_required_fields(self, rule: Dict) -> List[str]:
        """必須フィールドの検証"""
        errors = []
        required_fields = ['id', 'category', 'name', 'description', 'base_severity', 'patterns']

        for field in required_fields:
            if field not in rule:
                errors.append(f"必須フィールド '{field}' がありません")

        return errors

    def _validate_id_format(self, rule_id: str) -> List[str]:
        """IDフォーマットの検証"""
        errors = []

        # 数字も許可するように修正（例: CUSTOM_REACT_SECURITY_01）
        if not re.match(r'^[A-Z0-9_]+$', rule_id):
            errors.append(f"ルールID '{rule_id}' は大文字・数字・アンダースコアのみ使用可能です")

        return errors

    def _validate_category(self, category: str) -> List[str]:
        """カテゴリの検証"""
        errors = []

        if category not in self.VALID_CATEGORIES:
            errors.append(f"無効なカテゴリ: {category} (有効: {', '.join(self.VALID_CATEGORIES)})")

        return errors

    def _validate_severity(self, severity: Any) -> List[str]:
        """深刻度の検証"""
        errors = []

        if not isinstance(severity, int):
            errors.append(f"深刻度は整数で指定してください: {severity}")
        elif severity < 1 or severity > 10:
            errors.append(f"深刻度は1-10の範囲で指定してください: {severity}")

        return errors

    def _validate_patterns(self, patterns: Dict) -> List[str]:
        """パターンの検証"""
        errors = []

        if not isinstance(patterns, dict):
            errors.append("パターンは辞書形式で定義してください")
            return errors

        for language, pattern_list in patterns.items():
            # 言語チェック
            if language not in self.VALID_LANGUAGES:
                errors.append(f"未サポート言語: {language} (有効: {', '.join(self.VALID_LANGUAGES)})")

            # パターンリストチェック
            if not isinstance(pattern_list, list):
                errors.append(f"{language}: パターンはリスト形式で定義してください")
                continue

            for i, pattern in enumerate(pattern_list):
                if not isinstance(pattern, dict):
                    errors.append(f"{language}[{i}]: パターンは辞書形式で定義してください")
                    continue

                if 'pattern' not in pattern:
                    errors.append(f"{language}[{i}]: 'pattern'フィールドが必須です")

                # 正規表現の妥当性チェック
                if 'pattern' in pattern:
                    try:
                        re.compile(pattern['pattern'])
                    except re.error as e:
                        errors.append(f"{language}[{i}]: 無効な正規表現: {e}")

        return errors


# ========================================
# Phase 3.2: グローバル関数API
# ========================================

def load_all_rules(rules_dir: Path = Path("rules")) -> List[Rule]:
    """
    rules/配下の全YAMLファイルを再帰的に読み込み

    Args:
        rules_dir: ルールディレクトリのパス

    Returns:
        読み込まれたルールのリスト

    ディレクトリ構造例:
        rules/
        ├── core/
        │   ├── database/
        │   │   ├── n-plus-one.yml
        │   │   ├── select-star.yml
        │   │   └── multiple-join.yml
        │   ├── security/
        │   │   ├── sql-injection.yml
        │   │   ├── xss-vulnerability.yml
        │   │   └── float-money.yml
        │   ├── solid/
        │   │   ├── large-class.yml
        │   │   └── large-interface.yml
        │   └── performance/
        │       ├── memory-leak.yml
        │       └── goroutine-leak.yml
    """
    engine = RuleEngine(rules_dir=str(rules_dir))
    return engine.rules


def group_rules_by_category(rules: List[Rule]) -> Dict[str, 'RuleCategory']:
    """
    ルールをカテゴリ別にグループ化

    Args:
        rules: ルールのリスト

    Returns:
        カテゴリ名をキーとした辞書（値はRuleCategoryオブジェクト）
    """
    from .models import RuleCategory

    categories = {}

    for rule in rules:
        if rule.category not in categories:
            categories[rule.category] = RuleCategory(
                name=rule.category,
                rules=[]
            )

        categories[rule.category].rules.append(rule)

    return categories


def adjust_severity_by_tech_stack(
    rule: Rule,
    tech_stack: TechStack,
    base_severity: int,
    code_context: str = "",
    tags: Optional[List[str]] = None
) -> tuple[int, List[str]]:
    """
    技術スタックに応じて深刻度を調整

    Args:
        rule: 解析ルール
        tech_stack: プロジェクトの技術スタック
        base_severity: 基本深刻度
        code_context: コードのコンテキスト（オプション）
        tags: ファイルに付与されたタグリスト（新タグシステム）

    Returns:
        (調整後の深刻度, 追加ノートのリスト)

    例:
        Elasticsearch使用時はN+1問題の深刻度を10→7に軽減

        >>> rule = Rule(id="DB_N_PLUS_ONE", ...)
        >>> tech_stack = TechStack(databases=[DatabaseInfo(type="Elasticsearch")])
        >>> severity, notes = adjust_severity_by_tech_stack(rule, tech_stack, 10)
        >>> print(severity)  # 7

        タグベースの深刻度調整（新機能）:

        >>> rule = Rule(id="DB_N_PLUS_ONE", ...)
        >>> tech_stack = TechStack()  # 空の設定
        >>> tags = ["tech-elasticsearch", "lang-typescript"]
        >>> severity, notes = adjust_severity_by_tech_stack(rule, tech_stack, 10, tags=tags)
        >>> print(severity)  # 7（タグから自動検出）
    """
    return rule.evaluate_severity(tech_stack, code_context, tags)

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
                rule = self._load_rule_file(rule_file)
                if rule:
                    self.rules.append(rule)

                    # 言語ごとにインデックス化
                    for language in rule.patterns.keys():
                        self.rules_by_language[language].append(rule)

                    loaded_count += 1

            except Exception as e:
                print(f"[WARNING] ルール読み込みエラー: {rule_file}")
                print(f"          {e}")

        print(f"[OK] {loaded_count}個のルールを読み込みました")

    def _load_rule_file(self, rule_file: Path) -> Optional[Rule]:
        """YAMLルールファイルを読み込んでRuleオブジェクトに変換"""
        with open(rule_file, 'r', encoding='utf-8') as f:
            data = yaml.safe_load(f)

        if not data or 'rule' not in data:
            return None

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

        return Rule(
            id=rule_data['id'],
            category=rule_data['category'],
            name=rule_data['name'],
            description=rule_data['description'],
            base_severity=rule_data['base_severity'],
            patterns=patterns,
            context_modifiers=context_modifiers,
            fixes=fixes
        )

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
        code_context: str
    ) -> tuple[int, List[str]]:
        """
        技術スタックを考慮して深刻度を評価

        Returns:
            (調整後の深刻度, 追加ノートのリスト)
        """
        # プロジェクト設定がない、または調整が無効の場合
        if (not self.project_config or
            not self.project_config.severity_adjustments_enabled):
            return rule.base_severity, []

        # 技術スタックを使って評価
        tech_stack = self.project_config.tech_stack
        return rule.evaluate_severity(tech_stack, code_context)

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

"""
ルールテンプレート管理

Phase 4.1の新機能:
- テンプレートの読み込み
- テンプレート変数の置換
- テンプレートからのルール生成

バージョン: v4.4.0 (Phase 4.1)
作成日: 2025年10月12日 JST
"""

from pathlib import Path
from typing import Dict, List, Optional
import yaml
import re


class RuleTemplate:
    """
    ルールテンプレート

    テンプレート変数（{VARIABLE_NAME}形式）を含むYAMLファイルを管理し、
    変数を置換してルールYAMLを生成します。
    """

    def __init__(self, template_id: str, template_path: Path, content: str):
        """
        Args:
            template_id: テンプレートID
            template_path: テンプレートファイルパス
            content: テンプレート内容
        """
        self.id = template_id
        self.path = template_path
        self.content = content
        self.variables = self._extract_variables()

    def _extract_variables(self) -> List[str]:
        """
        テンプレート変数を抽出

        {VARIABLE_NAME} 形式の変数を抽出します。

        Returns:
            変数名のリスト（重複なし）
        """
        # {VARIABLE_NAME} 形式の変数を抽出
        variables = re.findall(r'\{([A-Z_]+)\}', self.content)
        return sorted(list(set(variables)))  # 重複削除&ソート

    def render(self, values: Dict[str, str]) -> str:
        """
        テンプレート変数を置換してルールYAMLを生成

        Args:
            values: 変数名→値のマッピング

        Returns:
            レンダリングされたYAML文字列

        Raises:
            ValueError: 必須変数が不足している場合
        """
        # 必須変数チェック
        missing_vars = set(self.variables) - set(values.keys())
        if missing_vars:
            raise ValueError(f"必須変数が不足しています: {missing_vars}")

        result = self.content
        for var_name, value in values.items():
            placeholder = f'{{{var_name}}}'
            result = result.replace(placeholder, str(value))

        return result

    def __repr__(self) -> str:
        return f"RuleTemplate(id='{self.id}', variables={self.variables})"


class RuleTemplateManager:
    """
    ルールテンプレート管理クラス

    Phase 4.1の新機能:
    - テンプレートの読み込み
    - テンプレート一覧の取得
    - テンプレートからのルール生成
    - 自動バリデーション
    """

    def __init__(self, templates_dir: Path = Path("rules/templates")):
        """
        Args:
            templates_dir: テンプレートディレクトリのパス
        """
        self.templates_dir = templates_dir
        self.templates: Dict[str, RuleTemplate] = {}
        self._load_templates()

    def _load_templates(self):
        """テンプレートディレクトリからテンプレートを読み込み"""
        if not self.templates_dir.exists():
            print(f"[INFO] テンプレートディレクトリが存在しません: {self.templates_dir}")
            print(f"[INFO] テンプレートを使用するには、{self.templates_dir} を作成してください")
            return

        template_files = list(self.templates_dir.glob("*.yml.template"))

        if not template_files:
            print(f"[INFO] テンプレートファイルが見つかりません: {self.templates_dir}")
            return

        for template_file in template_files:
            # ファイル名から.yml.templateを除去してIDを取得
            template_id = template_file.stem
            if template_id.endswith('.yml'):
                template_id = template_id[:-4]

            try:
                with open(template_file, 'r', encoding='utf-8') as f:
                    content = f.read()

                template = RuleTemplate(template_id, template_file, content)
                self.templates[template_id] = template

                print(f"[OK] テンプレート読み込み: {template_id} (変数: {len(template.variables)}個)")

            except Exception as e:
                print(f"[ERROR] テンプレート読み込み失敗: {template_file} - {e}")

        print(f"[INFO] {len(self.templates)}個のテンプレートを読み込みました")

    def list_templates(self) -> List[RuleTemplate]:
        """
        利用可能なテンプレート一覧を取得

        Returns:
            テンプレートのリスト
        """
        return list(self.templates.values())

    def get_template(self, template_id: str) -> Optional[RuleTemplate]:
        """
        指定IDのテンプレートを取得

        Args:
            template_id: テンプレートID

        Returns:
            テンプレート（見つからない場合はNone）
        """
        return self.templates.get(template_id)

    def create_rule_from_template(
        self,
        template_id: str,
        values: Dict[str, str],
        output_path: Path,
        validate: bool = True
    ) -> bool:
        """
        テンプレートからルールを生成

        Args:
            template_id: テンプレートID
            values: 変数値のマッピング
            output_path: 出力先パス
            validate: 作成後にバリデーションを実行するか

        Returns:
            成功したかどうか
        """
        # テンプレート取得
        template = self.get_template(template_id)
        if not template:
            print(f"[ERROR] テンプレート '{template_id}' が見つかりません")
            available = ', '.join(self.templates.keys())
            print(f"[INFO] 利用可能なテンプレート: {available}")
            return False

        try:
            # テンプレートをレンダリング
            rendered = template.render(values)

            # YAMLとして妥当か検証
            try:
                yaml.safe_load(rendered)
            except yaml.YAMLError as e:
                print(f"[ERROR] 生成されたYAMLが無効です: {e}")
                return False

            # ファイルに書き込み
            output_path.parent.mkdir(parents=True, exist_ok=True)
            with open(output_path, 'w', encoding='utf-8') as f:
                f.write(rendered)

            print(f"[OK] ルール作成完了: {output_path}")

            # バリデーション実行
            if validate:
                from core.rule_engine import RuleValidator
                validator = RuleValidator()
                errors = validator.validate_rule(output_path)

                if errors:
                    print(f"[WARNING] バリデーションで{len(errors)}件の警告:")
                    for error in errors:
                        print(f"  - {error}")
                else:
                    print(f"[OK] バリデーション成功")

            return True

        except ValueError as e:
            print(f"[ERROR] {e}")
            return False
        except Exception as e:
            print(f"[ERROR] ルール作成失敗: {e}")
            return False

    def __repr__(self) -> str:
        return f"RuleTemplateManager(templates={len(self.templates)})"

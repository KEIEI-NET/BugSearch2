"""
ルール共有機能

Phase 4.2の新機能:
- ルールのエクスポート
- ルールのインポート
- コミュニティルールリポジトリサポート

バージョン: v4.5.0 (Phase 4.2)
作成日: 2025年10月12日 JST

@perfect品質:
- 完全なエラーハンドリング
- バリデーション統合
- セキュアなファイル操作
"""

from pathlib import Path
from typing import List, Dict, Optional
import json
import yaml
from datetime import datetime

from .rule_engine import RuleValidator


class RuleExporter:
    """
    ルールのエクスポート機能

    Phase 4.2の新機能:
    - YAML/JSON形式でのエクスポート
    - メタデータ付加
    - ルールパッケージ作成
    """

    def export_rule(
        self,
        rule_file: Path,
        output_format: str = "yaml",
        include_metadata: bool = True
    ) -> str:
        """
        ルールをエクスポート形式に変換

        Args:
            rule_file: ルールファイルのパス
            output_format: 出力形式 (yaml/json)
            include_metadata: メタデータを含めるか

        Returns:
            エクスポートされたルール文字列

        Raises:
            FileNotFoundError: ルールファイルが存在しない
            ValueError: 無効な出力形式
        """
        if not rule_file.exists():
            raise FileNotFoundError(f"ルールファイルが見つかりません: {rule_file}")

        if output_format not in ('yaml', 'json'):
            raise ValueError(f"無効な出力形式: {output_format} (有効: yaml, json)")

        try:
            with open(rule_file, 'r', encoding='utf-8') as f:
                rule_data = yaml.safe_load(f)

            if not rule_data:
                raise ValueError("空のルールファイルです")

            # メタデータ追加
            if include_metadata:
                rule_data['metadata'] = {
                    'exported_at': datetime.now().isoformat(),
                    'exported_by': 'BugSearch2',
                    'version': 'v4.5.0',
                    'source_file': str(rule_file.name)
                }

            # 形式に応じて変換
            if output_format == 'json':
                return json.dumps(rule_data, indent=2, ensure_ascii=False)
            else:
                return yaml.dump(rule_data, allow_unicode=True, default_flow_style=False)

        except yaml.YAMLError as e:
            raise ValueError(f"YAML解析エラー: {e}")
        except Exception as e:
            raise RuntimeError(f"エクスポート失敗: {e}")

    def export_rule_package(
        self,
        rule_files: List[Path],
        package_name: str,
        output_dir: Path,
        package_version: str = "1.0.0"
    ) -> Path:
        """
        複数のルールをパッケージとしてエクスポート

        Args:
            rule_files: ルールファイルのリスト
            package_name: パッケージ名
            output_dir: 出力ディレクトリ
            package_version: パッケージバージョン

        Returns:
            作成されたパッケージファイルのパス

        Raises:
            ValueError: 無効な入力
            RuntimeError: パッケージ作成失敗
        """
        if not rule_files:
            raise ValueError("ルールファイルリストが空です")

        if not package_name:
            raise ValueError("パッケージ名が指定されていません")

        try:
            # パッケージデータ構築
            package_data = {
                'package': {
                    'name': package_name,
                    'version': package_version,
                    'created_at': datetime.now().isoformat(),
                    'created_by': 'BugSearch2 v4.5.0',
                    'rule_count': len(rule_files),
                    'rules': []
                }
            }

            # 各ルールを読み込み
            for rule_file in rule_files:
                if not rule_file.exists():
                    print(f"[WARNING] ルールファイルが見つかりません: {rule_file}")
                    continue

                with open(rule_file, 'r', encoding='utf-8') as f:
                    rule_data = yaml.safe_load(f)
                    if rule_data:
                        package_data['package']['rules'].append(rule_data)

            # パッケージファイル作成
            output_dir.mkdir(parents=True, exist_ok=True)
            package_file = output_dir / f"{package_name}.json"

            with open(package_file, 'w', encoding='utf-8') as f:
                json.dump(package_data, f, indent=2, ensure_ascii=False)

            print(f"[OK] パッケージ作成完了: {package_file}")
            print(f"[INFO] 含まれるルール数: {len(package_data['package']['rules'])}個")

            return package_file

        except Exception as e:
            raise RuntimeError(f"パッケージ作成失敗: {e}")


class RuleImporter:
    """
    ルールのインポート機能

    Phase 4.2の新機能:
    - YAML/JSON形式からのインポート
    - 自動バリデーション
    - ルールパッケージインストール
    """

    def __init__(self):
        self.validator = RuleValidator()

    def import_rule(
        self,
        rule_content: str,
        output_dir: Path,
        validate: bool = True
    ) -> Optional[Path]:
        """
        ルールをインポート

        Args:
            rule_content: ルール内容 (YAML/JSON)
            output_dir: 出力ディレクトリ
            validate: バリデーションを実行するか

        Returns:
            作成されたルールファイルのパス（失敗時はNone）
        """
        try:
            # YAML/JSON自動判定
            rule_content = rule_content.strip()
            if not rule_content:
                print("[ERROR] ルール内容が空です")
                return None

            if rule_content.startswith('{'):
                rule_data = json.loads(rule_content)
            else:
                rule_data = yaml.safe_load(rule_content)

            if not rule_data:
                print("[ERROR] 空のルールデータです")
                return None

            # ルールデータの抽出
            if 'rule' not in rule_data:
                print("[ERROR] 'rule'キーが見つかりません")
                return None

            rule = rule_data['rule']
            rule_id = rule.get('id', 'imported_rule')

            # 出力先パス
            output_dir.mkdir(parents=True, exist_ok=True)
            output_file = output_dir / f"{rule_id.lower().replace('_', '-')}.yml"

            # ファイルに書き込み
            with open(output_file, 'w', encoding='utf-8') as f:
                yaml.dump(rule_data, f, allow_unicode=True, default_flow_style=False)

            # バリデーション
            if validate:
                errors = self.validator.validate_rule(output_file)
                if errors:
                    print(f"[WARNING] バリデーションエラー:")
                    for error in errors:
                        print(f"  - {error}")
                    print(f"[INFO] ルールは作成されましたが、修正が必要です")
                else:
                    print(f"[OK] バリデーション成功")

            print(f"[OK] ルールインポート完了: {output_file}")
            return output_file

        except json.JSONDecodeError as e:
            print(f"[ERROR] JSON解析エラー: {e}")
            return None
        except yaml.YAMLError as e:
            print(f"[ERROR] YAML解析エラー: {e}")
            return None
        except Exception as e:
            print(f"[ERROR] インポート失敗: {e}")
            return None

    def import_rule_package(
        self,
        package_file: Path,
        output_dir: Path,
        validate: bool = True
    ) -> List[Path]:
        """
        ルールパッケージをインポート

        Args:
            package_file: パッケージファイルのパス
            output_dir: 出力ディレクトリ
            validate: バリデーションを実行するか

        Returns:
            インポートされたルールファイルのリスト
        """
        if not package_file.exists():
            print(f"[ERROR] パッケージファイルが見つかりません: {package_file}")
            return []

        try:
            with open(package_file, 'r', encoding='utf-8') as f:
                package_data = json.load(f)

            if 'package' not in package_data or 'rules' not in package_data['package']:
                print("[ERROR] 無効なパッケージ形式です")
                return []

            package = package_data['package']
            print(f"[INFO] パッケージ: {package.get('name', 'unknown')}")
            print(f"[INFO] バージョン: {package.get('version', 'unknown')}")

            imported_files = []
            rules = package['rules']

            for i, rule_data in enumerate(rules, 1):
                print(f"[INFO] ルール {i}/{len(rules)} をインポート中...")

                rule_yaml = yaml.dump(rule_data, allow_unicode=True, default_flow_style=False)
                rule_file = self.import_rule(rule_yaml, output_dir, validate=validate)

                if rule_file:
                    imported_files.append(rule_file)

            print()
            print(f"[OK] {len(imported_files)}/{len(rules)}個のルールをインポートしました")

            return imported_files

        except json.JSONDecodeError as e:
            print(f"[ERROR] パッケージファイル解析エラー: {e}")
            return []
        except Exception as e:
            print(f"[ERROR] パッケージインポート失敗: {e}")
            return []


class CommunityRuleRepository:
    """
    コミュニティルールリポジトリアクセス

    Phase 4.2の新機能:
    - GitHubリポジトリからのルールダウンロード
    - ローカルキャッシュ管理
    - バージョン管理
    """

    def __init__(self, repo_url: str = "https://github.com/bugsearch2/community-rules"):
        """
        初期化

        Args:
            repo_url: コミュニティルールリポジトリのURL
        """
        self.repo_url = repo_url
        self.cache_dir = Path.home() / ".bugsearch" / "community-rules"
        self.cache_dir.mkdir(parents=True, exist_ok=True)

    def list_available_packages(self) -> List[Dict]:
        """
        利用可能なルールパッケージ一覧を取得

        Returns:
            パッケージ情報のリスト

        Note:
            実装予定: GitHub APIでリリース一覧を取得
            現在はプレースホルダー実装
        """
        # TODO: GitHub API統合
        # 実装例:
        # - GitHub APIでリリース一覧を取得
        # - パッケージメタデータをパース
        # - キャッシュに保存

        print("[INFO] コミュニティリポジトリ機能は開発中です")
        print(f"[INFO] リポジトリURL: {self.repo_url}")

        return []

    def download_package(
        self,
        package_name: str,
        version: str = "latest"
    ) -> Optional[Path]:
        """
        コミュニティルールパッケージをダウンロード

        Args:
            package_name: パッケージ名
            version: バージョン (デフォルト: latest)

        Returns:
            ダウンロードされたパッケージファイルのパス

        Note:
            実装予定: GitHub Releasesからダウンロード
            現在はプレースホルダー実装
        """
        # TODO: GitHub API統合
        # 実装例:
        # - GitHub APIでリリースアセットを取得
        # - ファイルをダウンロード
        # - キャッシュディレクトリに保存
        # - バージョン管理

        print("[INFO] コミュニティパッケージダウンロード機能は開発中です")
        print(f"[INFO] パッケージ: {package_name}")
        print(f"[INFO] バージョン: {version}")

        return None

    def clear_cache(self):
        """キャッシュをクリア"""
        try:
            import shutil
            if self.cache_dir.exists():
                shutil.rmtree(self.cache_dir)
                self.cache_dir.mkdir(parents=True, exist_ok=True)
                print(f"[OK] キャッシュをクリアしました: {self.cache_dir}")
        except Exception as e:
            print(f"[ERROR] キャッシュクリア失敗: {e}")

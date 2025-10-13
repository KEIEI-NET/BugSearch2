"""
統合テストデフォルト設定管理モジュール
GUI/CUI両対応の統合テスト設定ロード・保存機能

Version: v4.11.5 (Phase 8.4)
"""

import os
from pathlib import Path
from typing import Dict, List, Any, Optional
import yaml


class IntegrationTestConfigManager:
    """
    統合テストデフォルト設定マネージャー

    機能:
    - YAMLマスター設定の読み込み
    - デフォルト値の取得
    - 設定の保存
    - バリデーション
    """

    DEFAULT_CONFIG_PATH = Path("config/integration_test_defaults.yml")

    def __init__(self, config_path: Optional[Path] = None):
        """
        初期化

        Args:
            config_path: 設定ファイルパス（省略時はデフォルトパス使用）
        """
        self.config_path = config_path or self.DEFAULT_CONFIG_PATH
        self.config: Dict[str, Any] = {}
        self._load_config()

    def _load_config(self) -> None:
        """設定ファイルをロード"""
        if not self.config_path.exists():
            # デフォルト設定を生成
            self._create_default_config()

        try:
            with open(self.config_path, 'r', encoding='utf-8') as f:
                self.config = yaml.safe_load(f) or {}
        except Exception as e:
            print(f"[WARN] Failed to load config: {e}")
            self.config = self._get_fallback_config()

    def _create_default_config(self) -> None:
        """デフォルト設定ファイルを作成"""
        default_config = self._get_fallback_config()

        # ディレクトリ作成
        self.config_path.parent.mkdir(parents=True, exist_ok=True)

        # YAML書き込み
        try:
            with open(self.config_path, 'w', encoding='utf-8') as f:
                yaml.dump(
                    default_config,
                    f,
                    default_flow_style=False,
                    allow_unicode=True,
                    sort_keys=False
                )
            print(f"[OK] Created default config: {self.config_path}")
        except Exception as e:
            print(f"[ERROR] Failed to create default config: {e}")

    def _get_fallback_config(self) -> Dict[str, Any]:
        """フォールバック設定（ハードコード）"""
        return {
            'version': '1.0.0',
            'context7': {
                'default_tech_stacks': ['react', 'angular'],
                'default_topics': ['security', 'performance', 'best-practices']
            },
            'integration_test': {
                'default_project_types': ['react', 'angular', 'vue'],
                'default_topics': [
                    'security', 'performance', 'best-practices',
                    'error-handling', 'testing'
                ],
                'default_max_file_mb': 4,
                'default_worker_count': 4
            },
            'index': {
                'default_max_file_mb': 4,
                'default_worker_count': 4,
                'default_exclude_langs': []
            },
            'advise': {
                'default_complete_report': False,
                'default_max_complete_items': 100
            },
            'database_integration_test': {
                'default_database_types': ['cassandra', 'elasticsearch', 'redis'],
                'default_topics': ['performance', 'security', 'best-practices']
            }
        }

    # Context7設定取得

    def get_context7_default_tech_stacks(self) -> List[str]:
        """Context7デフォルト技術スタック取得"""
        return self.config.get('context7', {}).get('default_tech_stacks', [])

    def get_context7_default_topics(self) -> List[str]:
        """Context7デフォルトトピック取得"""
        return self.config.get('context7', {}).get('default_topics', [])

    # 統合テスト設定取得

    def get_integration_test_default_project_types(self) -> List[str]:
        """統合テストデフォルトプロジェクトタイプ取得"""
        return self.config.get('integration_test', {}).get('default_project_types', [])

    def get_integration_test_default_topics(self) -> List[str]:
        """統合テストデフォルトトピック取得"""
        return self.config.get('integration_test', {}).get('default_topics', [])

    def get_integration_test_default_max_file_mb(self) -> int:
        """統合テストデフォルト最大ファイルサイズ取得"""
        return self.config.get('integration_test', {}).get('default_max_file_mb', 4)

    def get_integration_test_default_worker_count(self) -> int:
        """統合テストデフォルトワーカー数取得"""
        return self.config.get('integration_test', {}).get('default_worker_count', 4)

    # インデックス作成設定取得

    def get_index_default_max_file_mb(self) -> int:
        """インデックス作成デフォルト最大ファイルサイズ取得"""
        return self.config.get('index', {}).get('default_max_file_mb', 4)

    def get_index_default_worker_count(self) -> int:
        """インデックス作成デフォルトワーカー数取得"""
        return self.config.get('index', {}).get('default_worker_count', 4)

    def get_index_default_exclude_langs(self) -> List[str]:
        """インデックス作成デフォルト除外言語取得"""
        return self.config.get('index', {}).get('default_exclude_langs', [])

    # AI分析設定取得

    def get_advise_default_complete_report(self) -> bool:
        """AI分析デフォルト完全レポートフラグ取得"""
        return self.config.get('advise', {}).get('default_complete_report', False)

    def get_advise_default_max_complete_items(self) -> int:
        """AI分析デフォルト完全レポート最大件数取得"""
        return self.config.get('advise', {}).get('default_max_complete_items', 100)

    # データベース統合テスト設定取得

    def get_database_integration_test_default_database_types(self) -> List[str]:
        """データベース統合テストデフォルトDB種類取得"""
        return self.config.get('database_integration_test', {}).get('default_database_types', [])

    def get_database_integration_test_default_topics(self) -> List[str]:
        """データベース統合テストデフォルトトピック取得"""
        return self.config.get('database_integration_test', {}).get('default_topics', [])

    # 設定保存

    def save_context7_defaults(self, tech_stacks: List[str], topics: List[str]) -> bool:
        """Context7デフォルト設定保存"""
        if 'context7' not in self.config:
            self.config['context7'] = {}

        self.config['context7']['default_tech_stacks'] = tech_stacks
        self.config['context7']['default_topics'] = topics

        return self._save_config()

    def save_integration_test_defaults(
        self,
        project_types: List[str],
        topics: List[str],
        max_file_mb: int = 4,
        worker_count: int = 4
    ) -> bool:
        """統合テストデフォルト設定保存"""
        if 'integration_test' not in self.config:
            self.config['integration_test'] = {}

        self.config['integration_test']['default_project_types'] = project_types
        self.config['integration_test']['default_topics'] = topics
        self.config['integration_test']['default_max_file_mb'] = max_file_mb
        self.config['integration_test']['default_worker_count'] = worker_count

        return self._save_config()

    def save_index_defaults(
        self,
        max_file_mb: int = 4,
        worker_count: int = 4,
        exclude_langs: Optional[List[str]] = None
    ) -> bool:
        """インデックス作成デフォルト設定保存"""
        if 'index' not in self.config:
            self.config['index'] = {}

        self.config['index']['default_max_file_mb'] = max_file_mb
        self.config['index']['default_worker_count'] = worker_count
        self.config['index']['default_exclude_langs'] = exclude_langs or []

        return self._save_config()

    def save_advise_defaults(
        self,
        complete_report: bool = False,
        max_complete_items: int = 100
    ) -> bool:
        """AI分析デフォルト設定保存"""
        if 'advise' not in self.config:
            self.config['advise'] = {}

        self.config['advise']['default_complete_report'] = complete_report
        self.config['advise']['default_max_complete_items'] = max_complete_items

        return self._save_config()

    def _save_config(self) -> bool:
        """設定ファイル保存"""
        try:
            # ディレクトリ作成
            self.config_path.parent.mkdir(parents=True, exist_ok=True)

            # YAML書き込み
            with open(self.config_path, 'w', encoding='utf-8') as f:
                yaml.dump(
                    self.config,
                    f,
                    default_flow_style=False,
                    allow_unicode=True,
                    sort_keys=False
                )

            print(f"[OK] Saved config: {self.config_path}")
            return True

        except Exception as e:
            print(f"[ERROR] Failed to save config: {e}")
            return False

    # バリデーション

    def validate_config(self) -> tuple[bool, List[str]]:
        """
        設定ファイルのバリデーション

        Returns:
            (is_valid, error_messages)
        """
        errors = []

        # バージョンチェック
        if 'version' not in self.config:
            errors.append("Missing 'version' field")

        # 各セクションの必須フィールドチェック
        required_sections = {
            'context7': ['default_tech_stacks', 'default_topics'],
            'integration_test': [
                'default_project_types', 'default_topics',
                'default_max_file_mb', 'default_worker_count'
            ],
            'index': ['default_max_file_mb', 'default_worker_count'],
            'advise': ['default_complete_report', 'default_max_complete_items']
        }

        for section, fields in required_sections.items():
            if section not in self.config:
                errors.append(f"Missing section: {section}")
                continue

            for field in fields:
                if field not in self.config[section]:
                    errors.append(f"Missing field: {section}.{field}")

        return (len(errors) == 0, errors)

    # ユーティリティ

    def get_all_available_tech_stacks(self) -> List[tuple[str, str]]:
        """利用可能な全技術スタックリスト取得"""
        return [
            ("react", "React - JavaScriptライブラリ"),
            ("angular", "Angular - TypeScriptフレームワーク"),
            ("vue", "Vue.js - プログレッシブフレームワーク"),
            ("svelte", "Svelte - コンパイラフレームワーク"),
            ("express", "Express - Node.jsバックエンド"),
            ("nestjs", "NestJS - TypeScriptバックエンド"),
            ("fastapi", "FastAPI - Python高速API"),
            ("django", "Django - Pythonフレームワーク"),
            ("flask", "Flask - Python軽量フレームワーク"),
            ("spring-boot", "Spring Boot - Javaフレームワーク"),
            ("cassandra", "Cassandra - 分散NoSQLデータベース"),
            ("elasticsearch", "Elasticsearch - 検索エンジン"),
            ("redis", "Redis - インメモリKVS"),
            ("mysql", "MySQL - リレーショナルデータベース"),
            ("postgresql", "PostgreSQL - オープンソースデータベース"),
            ("sqlserver", "SQL Server - Microsoft データベース"),
            ("oracle", "Oracle Database - エンタープライズデータベース"),
            ("memcached", "Memcached - 分散メモリキャッシュ"),
        ]

    def get_all_available_topics(self) -> List[tuple[str, str]]:
        """利用可能な全トピックリスト取得"""
        return [
            ("security", "セキュリティ - 脆弱性・認証・XSS・SQLi・CSRF対策"),
            ("performance", "パフォーマンス - 速度最適化・メモリ管理・レンダリング"),
            ("best-practices", "ベストプラクティス - コーディング規約・設計パターン"),
            ("error-handling", "エラーハンドリング - 例外処理・リトライ・ロギング"),
            ("testing", "テスト - ユニットテスト・統合テスト・E2Eテスト"),
            ("accessibility", "アクセシビリティ - ARIA・キーボード対応・スクリーンリーダー"),
            ("optimization", "最適化 - バンドルサイズ・コード分割・遅延ロード"),
            ("architecture", "アーキテクチャ - 設計原則・モジュール分割・依存関係"),
            ("patterns", "デザインパターン - Factory・Observer・Singleton等"),
            ("styling", "スタイリング - CSS設計・レスポンシブ・テーマ"),
            ("state-management", "状態管理 - Redux・Vuex・NgRx・Context API"),
            ("routing", "ルーティング - ナビゲーション・ガード・遅延ロード"),
            ("deployment", "デプロイ - ビルド最適化・CI/CD・環境設定"),
            ("monitoring", "モニタリング - ログ・メトリクス・エラートラッキング"),
            ("api-integration", "API連携 - REST・GraphQL・WebSocket・認証"),
            ("data-validation", "データ検証 - バリデーション・型安全性・サニタイズ"),
        ]

    def reset_to_defaults(self) -> bool:
        """デフォルト設定にリセット"""
        self.config = self._get_fallback_config()
        return self._save_config()

    def reload_config(self) -> None:
        """設定ファイルを再読み込み"""
        self._load_config()


# グローバルシングルトンインスタンス
_config_manager: Optional[IntegrationTestConfigManager] = None


def get_config_manager() -> IntegrationTestConfigManager:
    """
    グローバル設定マネージャーインスタンス取得

    Returns:
        IntegrationTestConfigManager: シングルトンインスタンス
    """
    global _config_manager
    if _config_manager is None:
        _config_manager = IntegrationTestConfigManager()
    return _config_manager


# 便利関数（GUI/CUIから直接使用可能）

def get_context7_defaults() -> Dict[str, List[str]]:
    """Context7デフォルト設定取得（簡易版）"""
    manager = get_config_manager()
    return {
        'tech_stacks': manager.get_context7_default_tech_stacks(),
        'topics': manager.get_context7_default_topics()
    }


def get_integration_test_defaults() -> Dict[str, Any]:
    """統合テストデフォルト設定取得（簡易版）"""
    manager = get_config_manager()
    return {
        'project_types': manager.get_integration_test_default_project_types(),
        'topics': manager.get_integration_test_default_topics(),
        'max_file_mb': manager.get_integration_test_default_max_file_mb(),
        'worker_count': manager.get_integration_test_default_worker_count()
    }


def get_index_defaults() -> Dict[str, Any]:
    """インデックス作成デフォルト設定取得（簡易版）"""
    manager = get_config_manager()
    return {
        'max_file_mb': manager.get_index_default_max_file_mb(),
        'worker_count': manager.get_index_default_worker_count(),
        'exclude_langs': manager.get_index_default_exclude_langs()
    }


def get_advise_defaults() -> Dict[str, Any]:
    """AI分析デフォルト設定取得（簡易版）"""
    manager = get_config_manager()
    return {
        'complete_report': manager.get_advise_default_complete_report(),
        'max_complete_items': manager.get_advise_default_max_complete_items()
    }


if __name__ == '__main__':
    # テスト実行
    print("=== IntegrationTestConfigManager Test ===")

    manager = IntegrationTestConfigManager()

    # バリデーション
    is_valid, errors = manager.validate_config()
    print(f"\nValidation: {'OK' if is_valid else 'FAILED'}")
    if errors:
        for error in errors:
            print(f"  - {error}")

    # 設定取得テスト
    print("\n=== Context7 Defaults ===")
    print(f"Tech Stacks: {manager.get_context7_default_tech_stacks()}")
    print(f"Topics: {manager.get_context7_default_topics()}")

    print("\n=== Integration Test Defaults ===")
    print(f"Project Types: {manager.get_integration_test_default_project_types()}")
    print(f"Topics: {manager.get_integration_test_default_topics()}")
    print(f"Max File MB: {manager.get_integration_test_default_max_file_mb()}")
    print(f"Worker Count: {manager.get_integration_test_default_worker_count()}")

    print("\n=== Index Defaults ===")
    print(f"Max File MB: {manager.get_index_default_max_file_mb()}")
    print(f"Worker Count: {manager.get_index_default_worker_count()}")

    print("\n=== Advise Defaults ===")
    print(f"Complete Report: {manager.get_advise_default_complete_report()}")
    print(f"Max Complete Items: {manager.get_advise_default_max_complete_items()}")

    print("\n=== Test Complete ===")

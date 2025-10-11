"""
プロジェクト設定の読み込み

.bugsearch.yml ファイルの読み込みとバリデーション
"""

import yaml
from pathlib import Path
from typing import Optional
import sys

from .models import ProjectConfig, TechStack


def load_project_config(
    config_path: str = ".bugsearch.yml",
    use_default_if_missing: bool = True
) -> Optional[ProjectConfig]:
    """
    プロジェクト設定を読み込む

    Args:
        config_path: 設定ファイルのパス
        use_default_if_missing: ファイルがない場合デフォルト設定を使用するか

    Returns:
        ProjectConfig オブジェクト、または None（ファイルがなくuse_default_if_missing=Falseの場合）
    """
    config_file = Path(config_path)

    # ファイルが存在しない場合
    if not config_file.exists():
        if use_default_if_missing:
            print(f"[WARNING] {config_path} が見つかりません。デフォルト設定を使用します。")
            print(f"          'py stack_generator.py init' で設定ファイルを生成できます。")
            return _create_default_config()
        else:
            return None

    # YAMLファイルを読み込み
    try:
        with open(config_file, 'r', encoding='utf-8') as f:
            data = yaml.safe_load(f)

        if not data:
            print(f"[WARNING] {config_path} が空です。デフォルト設定を使用します。")
            return _create_default_config()

        # ProjectConfigオブジェクトに変換
        config = ProjectConfig.from_dict(data)

        print(f"[OK] プロジェクト設定を読み込みました: {config.name}")
        print(f"     技術スタック: {config.tech_stack}")

        return config

    except yaml.YAMLError as e:
        print(f"[ERROR] YAML読み込みエラー: {config_path}")
        print(f"        {e}")
        sys.exit(1)

    except Exception as e:
        print(f"[ERROR] 設定ファイル読み込みエラー: {config_path}")
        print(f"        {e}")
        sys.exit(1)


def _create_default_config() -> ProjectConfig:
    """デフォルト設定を生成"""
    return ProjectConfig(
        name="Unknown Project",
        version="1.0",
        tech_stack=TechStack(),
        practices=[],
        severity_adjustments_enabled=False,  # デフォルトでは調整なし
    )


def validate_config(config: ProjectConfig) -> bool:
    """
    設定の妥当性を検証

    Args:
        config: 検証するProjectConfig

    Returns:
        True if valid, False otherwise
    """
    errors = []

    # プロジェクト名のチェック
    if not config.name or config.name == "Unknown Project":
        errors.append("プロジェクト名が設定されていません")

    # AI context depthのチェック
    valid_depths = ['minimal', 'standard', 'detailed']
    if config.ai_context_depth not in valid_depths:
        errors.append(f"ai_context_depthは {valid_depths} のいずれかである必要があります")

    # カスタムルールファイルの存在チェック
    for rule_file in config.custom_rules:
        if not Path(rule_file).exists():
            errors.append(f"カスタムルールファイルが見つかりません: {rule_file}")

    if errors:
        print("[ERROR] 設定エラー:")
        for error in errors:
            print(f"        - {error}")
        return False

    return True


def save_project_config(config: ProjectConfig, output_path: str = ".bugsearch.yml"):
    """
    ProjectConfigをYAMLファイルに保存

    Args:
        config: 保存するProjectConfig
        output_path: 出力ファイルパス
    """
    data = _config_to_dict(config)

    try:
        with open(output_path, 'w', encoding='utf-8') as f:
            yaml.dump(data, f, default_flow_style=False, allow_unicode=True, sort_keys=False)

        print(f"[OK] 設定ファイルを保存しました: {output_path}")

    except Exception as e:
        print(f"[ERROR] 設定ファイル保存エラー: {output_path}")
        print(f"        {e}")
        sys.exit(1)


def _config_to_dict(config: ProjectConfig) -> dict:
    """ProjectConfigを辞書に変換"""
    data = {
        'project': {
            'name': config.name,
            'version': config.version,
        },
        'tech_stack': {},
        'practices': config.practices,
        'analysis': {
            'severity_adjustments': {
                'enabled': config.severity_adjustments_enabled,
            },
            'custom_rules': config.custom_rules,
            'exclude_rules': config.exclude_rules,
            'ai_analysis': {
                'include_tech_stack': config.ai_include_tech_stack,
                'context_depth': config.ai_context_depth,
            },
        },
    }

    # 技術スタックの変換
    tech_stack = config.tech_stack

    if tech_stack.frontend:
        data['tech_stack']['frontend'] = {
            'framework': tech_stack.frontend.framework,
            'version': tech_stack.frontend.version,
            'state_management': tech_stack.frontend.state_management,
            'routing': tech_stack.frontend.routing,
        }

    if tech_stack.backend:
        data['tech_stack']['backend'] = {
            'language': tech_stack.backend.language,
            'version': tech_stack.backend.version,
            'framework': tech_stack.backend.framework,
            'framework_version': tech_stack.backend.framework_version,
        }

    if tech_stack.databases:
        data['tech_stack']['databases'] = [
            {
                'type': db.type,
                'version': db.version,
                'purpose': db.purpose,
                'library': db.library,
            }
            for db in tech_stack.databases
        ]

    if tech_stack.cache:
        data['tech_stack']['cache'] = {
            'type': tech_stack.cache.type,
            'version': tech_stack.cache.version,
            'library': tech_stack.cache.library,
        }

    if tech_stack.messaging:
        data['tech_stack']['messaging'] = {
            'type': tech_stack.messaging.type,
            'version': tech_stack.messaging.version,
            'library': tech_stack.messaging.library,
        }

    if tech_stack.authentication:
        data['tech_stack']['authentication'] = tech_stack.authentication

    return data

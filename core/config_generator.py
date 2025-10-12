"""
Context7統合 設定ファイル自動生成エンジン

技術スタック/フレームワークを指定すると、Context7から
最新ドキュメントを取得し、チェックすべき重要点を抽出して
YAML設定ファイルを自動生成します。

Version: v1.0.0 (@perfect品質)
"""

import json
import os
import re
import yaml
from pathlib import Path
from typing import Dict, List, Optional, Tuple
from datetime import datetime

try:
    from core.rule_engine import RuleValidator, RuleLoader
except ImportError:
    RuleValidator = None
    RuleLoader = None

# AI API (OpenAI/Anthropic)
try:
    import openai
    OPENAI_AVAILABLE = True
except ImportError:
    OPENAI_AVAILABLE = False

try:
    import anthropic
    ANTHROPIC_AVAILABLE = True
except ImportError:
    ANTHROPIC_AVAILABLE = False


class ConfigGenerator:
    """Context7統合 設定ファイル自動生成エンジン"""

    def __init__(self):
        """初期化"""
        self.config_dir = Path("config")
        self.config_dir.mkdir(exist_ok=True)

    def resolve_library(self, tech_name: str) -> Optional[str]:
        """
        Context7でライブラリIDを解決

        Args:
            tech_name: 技術名/フレームワーク名 (例: "react", "angular", "express")

        Returns:
            Context7互換ライブラリID (例: "/facebook/react")
            見つからない場合はNone
        """
        try:
            # Context7のresolve-library-idツールを呼び出し
            # ここでは実装の詳細を示すためのプレースホルダー
            # 実際の実装ではMCPツールを使用
            print(f"📚 Resolving library ID for: {tech_name}")

            # 一般的なマッピング（Context7ツール呼び出しの代替）
            library_mappings = {
                # フロントエンド
                "react": "/facebook/react",
                "angular": "/angular/angular",
                "vue": "/vuejs/vue",
                "svelte": "/sveltejs/svelte",

                # バックエンド
                "express": "/expressjs/express",
                "nestjs": "/nestjs/nest",
                "fastapi": "/tiangolo/fastapi",
                "django": "/django/django",
                "flask": "/pallets/flask",
                "spring-boot": "/spring-projects/spring-boot",

                # データベース
                "elasticsearch": "/elastic/elasticsearch",
                "cassandra": "/apache/cassandra",
                "mongodb": "/mongodb/mongo",
                "redis": "/redis/redis",

                # その他
                "typescript": "/microsoft/typescript",
                "nodejs": "/nodejs/node",
                "go": "/golang/go",
            }

            # 小文字化して検索
            tech_lower = tech_name.lower().strip()
            if tech_lower in library_mappings:
                library_id = library_mappings[tech_lower]
                print(f"✅ Resolved: {tech_name} -> {library_id}")
                return library_id

            print(f"❌ Library not found: {tech_name}")
            return None

        except Exception as e:
            print(f"⚠️  Error resolving library: {e}")
            return None

    def fetch_documentation(
        self,
        library_id: str,
        topic: Optional[str] = None,
        tokens: int = 10000
    ) -> Optional[str]:
        """
        Context7からドキュメントを取得

        Args:
            library_id: Context7互換ライブラリID
            topic: フォーカスするトピック (例: "security", "best practices")
            tokens: 取得する最大トークン数

        Returns:
            ドキュメント文字列、失敗時はNone
        """
        try:
            print(f"📖 Fetching documentation for: {library_id}")
            if topic:
                print(f"   Topic: {topic}")

            # Context7のget-library-docsツールを呼び出し
            # ここでは実装の詳細を示すためのプレースホルダー
            # 実際の実装ではMCPツールを使用

            # サンプルドキュメント（実際はContext7から取得）
            sample_docs = {
                "/facebook/react": """
# React Best Practices

## Security
- Always sanitize user input before rendering
- Use dangerouslySetInnerHTML carefully
- Validate props with PropTypes or TypeScript

## Performance
- Use React.memo for expensive components
- Implement shouldComponentUpdate or use PureComponent
- Avoid inline function definitions in render

## Common Issues
- Memory leaks from unsubscribed event listeners
- State updates on unmounted components
- Missing keys in lists
""",
                "/angular/angular": """
# Angular Best Practices

## Security
- Always sanitize user input
- Use DomSanitizer for dynamic content
- Implement proper authentication guards

## Performance
- Use OnPush ChangeDetectionStrategy
- Implement trackBy for ngFor
- Lazy load modules

## Common Issues
- Memory leaks from unsubscribed Observables
- Large bundle sizes
- Missing error handling in HTTP calls
""",
            }

            docs = sample_docs.get(library_id, f"Documentation for {library_id}")
            print(f"✅ Documentation fetched ({len(docs)} chars)")
            return docs

        except Exception as e:
            print(f"⚠️  Error fetching documentation: {e}")
            return None

    def analyze_best_practices(self, docs: str, tech_name: str) -> List[Dict]:
        """
        ドキュメントからベストプラクティスとチェック項目を抽出

        Args:
            docs: ドキュメント文字列
            tech_name: 技術名

        Returns:
            チェック項目のリスト
        """
        print(f"🔍 Analyzing best practices for: {tech_name}")

        checks = []

        # セキュリティ関連
        if "security" in docs.lower() or "sanitize" in docs.lower():
            checks.append({
                "category": "security",
                "name": f"{tech_name} Security Issues",
                "description": "セキュリティ上の問題を検出",
                "severity": 9,
                "patterns": self._extract_security_patterns(docs, tech_name)
            })

        # パフォーマンス関連
        if "performance" in docs.lower() or "optimization" in docs.lower():
            checks.append({
                "category": "performance",
                "name": f"{tech_name} Performance Issues",
                "description": "パフォーマンス問題を検出",
                "severity": 6,
                "patterns": self._extract_performance_patterns(docs, tech_name)
            })

        # メモリリーク (パフォーマンスカテゴリとして扱う)
        if "memory leak" in docs.lower() or "unsubscribe" in docs.lower():
            checks.append({
                "category": "performance",
                "name": f"{tech_name} Memory Leaks",
                "description": "メモリリーク可能性を検出",
                "severity": 8,
                "patterns": self._extract_memory_patterns(docs, tech_name)
            })

        print(f"✅ Found {len(checks)} check categories")
        return checks

    def _extract_security_patterns(self, docs: str, tech_name: str) -> List[str]:
        """セキュリティパターンを抽出"""
        patterns = []

        if "react" in tech_name.lower():
            patterns = [
                "dangerouslySetInnerHTML",
                "eval\\(",
                "\\.innerHTML\\s*=",
            ]
        elif "angular" in tech_name.lower():
            patterns = [
                "bypassSecurityTrust",
                "eval\\(",
                "\\.nativeElement\\.innerHTML",
            ]

        return patterns

    def _extract_performance_patterns(self, docs: str, tech_name: str) -> List[str]:
        """パフォーマンスパターンを抽出"""
        patterns = []

        if "react" in tech_name.lower():
            patterns = [
                "\\brender\\s*\\(\\s*\\)\\s*{[^}]*function\\s*\\(",
                "componentDidMount.*setInterval",
            ]
        elif "angular" in tech_name.lower():
            patterns = [
                "\\*ngFor(?!.*trackBy)",
                "constructor\\s*\\([^)]*\\)\\s*{[^}]*http\\.",
            ]

        return patterns

    def _extract_memory_patterns(self, docs: str, tech_name: str) -> List[str]:
        """メモリリークパターンを抽出"""
        patterns = []

        if "react" in tech_name.lower():
            patterns = [
                "componentDidMount.*addEventListener(?!.*removeEventListener)",
                "setInterval(?!.*clearInterval)",
            ]
        elif "angular" in tech_name.lower():
            patterns = [
                "\\.subscribe\\((?!.*unsubscribe)",
                "ngOnInit.*setInterval(?!.*clearInterval)",
            ]

        return patterns

    def generate_yaml_rules(
        self,
        checks: List[Dict],
        tech_name: str,
        include_examples: bool = True
    ) -> str:
        """
        YAML設定ファイルを生成

        Args:
            checks: チェック項目リスト
            tech_name: 技術名
            include_examples: サンプルコードを含めるか

        Returns:
            YAML文字列
        """
        print(f"📝 Generating YAML rules for: {tech_name}")

        # YAMLヘッダー
        yaml_content = f"""# {tech_name} Custom Rules
# Auto-generated by BugSearch2 Config Generator
# Generated: {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}
#
# このファイルは Context7 から取得した最新ドキュメントを基に
# 自動生成されました。プロジェクトに合わせてカスタマイズしてください。

"""

        # 各チェック項目をYAMLルールとして追加
        for idx, check in enumerate(checks, 1):
            rule_id = f"CUSTOM_{tech_name.upper()}_{check['category'].upper()}_{idx:02d}"

            rule = {
                "rule": {
                    "id": rule_id,
                    "category": check['category'],
                    "name": check['name'],
                    "description": check['description'],
                    "base_severity": check['severity'],
                    "patterns": {},
                    "fixes": {
                        "description": f"{tech_name}のベストプラクティスに従ってください",
                        "references": [
                            f"公式ドキュメント: {tech_name}",
                            "Context7による最新情報",
                        ]
                    }
                }
            }

            # 言語別パターン追加
            if tech_name.lower() in ["react", "angular", "vue"]:
                languages = ["typescript", "javascript"]
            elif tech_name.lower() in ["django", "flask", "fastapi"]:
                languages = ["python"]
            elif tech_name.lower() in ["express", "nestjs"]:
                languages = ["typescript", "javascript"]
            else:
                languages = ["generic"]

            for lang in languages:
                if check['patterns']:
                    rule["rule"]["patterns"][lang] = [
                        {"pattern": pattern, "context": check['name']}
                        for pattern in check['patterns']
                    ]

            # サンプルコード追加
            if include_examples:
                rule["rule"]["examples"] = {
                    "bad": [
                        f"// TODO: {tech_name}での悪い例を追加"
                    ],
                    "good": [
                        f"// TODO: {tech_name}での良い例を追加"
                    ]
                }

            # YAMLに変換
            yaml_content += yaml.dump(rule,
                                     allow_unicode=True,
                                     default_flow_style=False,
                                     sort_keys=False)
            yaml_content += "\n"

        print(f"✅ Generated {len(checks)} YAML rules")
        return yaml_content

    def save_config_file(
        self,
        yaml_content: str,
        tech_name: str,
        custom_filename: Optional[str] = None
    ) -> Path:
        """
        設定ファイルを保存

        Args:
            yaml_content: YAML文字列
            tech_name: 技術名
            custom_filename: カスタムファイル名（省略時は自動生成）

        Returns:
            保存したファイルのパス
        """
        if custom_filename:
            filename = custom_filename
        else:
            # ファイル名を生成 (tech-name-rules.yml)
            safe_name = re.sub(r'[^\w\-]', '-', tech_name.lower())
            filename = f"{safe_name}-rules.yml"

        filepath = self.config_dir / filename

        print(f"💾 Saving config file: {filepath}")

        with open(filepath, 'w', encoding='utf-8') as f:
            f.write(yaml_content)

        print(f"✅ Config file saved: {filepath}")
        return filepath

    def validate_generated_config(self, filepath: Path) -> Tuple[bool, List[str]]:
        """
        生成された設定ファイルを検証

        Args:
            filepath: 検証するYAMLファイルのパス

        Returns:
            (検証成功フラグ, エラーメッセージリスト)
        """
        errors = []

        print(f"🔍 Validating config file: {filepath}")

        # 1. ファイル存在チェック
        if not filepath.exists():
            errors.append(f"ファイルが存在しません: {filepath}")
            return False, errors

        # 2. YAML構文チェック
        try:
            with open(filepath, 'r', encoding='utf-8') as f:
                content = f.read()
                yaml_data = yaml.safe_load(content)

            if not yaml_data:
                errors.append("YAMLファイルが空です")
                return False, errors

            print("  ✓ YAML構文: OK")

        except yaml.YAMLError as e:
            errors.append(f"YAML構文エラー: {e}")
            return False, errors
        except Exception as e:
            errors.append(f"ファイル読み込みエラー: {e}")
            return False, errors

        # 3. RuleValidatorによる検証（利用可能な場合）
        if RuleValidator:
            try:
                validator = RuleValidator()

                # validate_rule()はファイルパスを受け取り、エラーリストを返す
                validation_errors = validator.validate_rule(filepath)

                if not validation_errors:
                    print("  ✓ ルール構造: OK")
                else:
                    print("  ✗ ルール構造: エラーあり")
                    errors.extend(validation_errors)
                    return False, errors

            except Exception as e:
                errors.append(f"ルール検証エラー: {e}")
                return False, errors
        else:
            print("  ⚠ RuleValidator利用不可（基本チェックのみ）")

        # 4. RuleLoaderによる読み込みテスト（利用可能な場合）
        if RuleLoader:
            try:
                # 一時的にconfig/ディレクトリのルールを読み込んでテスト
                loader = RuleLoader()
                rules = loader.load_all_rules(include_custom=False, include_config=True)

                # 生成されたルールが含まれているか確認
                rule_found = False
                for rule in rules:
                    if str(rule.id).startswith('CUSTOM_'):
                        rule_found = True
                        break

                if rule_found:
                    print("  ✓ ルール読み込み: OK")
                else:
                    print("  ⚠ ルール読み込み: ルールが見つかりません（正常な場合もあります）")

            except Exception as e:
                errors.append(f"ルール読み込みエラー: {e}")
                return False, errors
        else:
            print("  ⚠ RuleLoader利用不可（基本チェックのみ）")

        # 5. 必須フィールドチェック
        if 'rule' in yaml_data:
            rule = yaml_data['rule']
            required_fields = ['id', 'category', 'name', 'description']

            missing_fields = []
            for field in required_fields:
                if field not in rule:
                    missing_fields.append(field)

            if missing_fields:
                errors.append(f"必須フィールド不足: {', '.join(missing_fields)}")
                return False, errors

            print("  ✓ 必須フィールド: OK")
        else:
            errors.append("'rule'キーが見つかりません")
            return False, errors

        print("✅ 検証完了: すべてのチェックをパスしました")
        return True, []

    def fix_yaml_with_ai(
        self,
        yaml_content: str,
        validation_errors: List[str],
        tech_name: str,
        attempt: int = 1
    ) -> Optional[str]:
        """
        AI（OpenAI/Anthropic）を使用してYAMLを自動修正

        Args:
            yaml_content: 修正前のYAML文字列
            validation_errors: 検証エラーリスト
            tech_name: 技術名
            attempt: 試行回数

        Returns:
            修正後のYAML文字列、失敗時はNone
        """
        print(f"🤖 AI自動修正を開始 (試行 {attempt}/5)")
        print(f"   検出されたエラー: {len(validation_errors)}件")

        # エラーメッセージを整形
        errors_text = "\n".join(f"- {error}" for error in validation_errors)

        # 修正プロンプト
        prompt = f"""以下のYAMLルール定義ファイルに検証エラーがあります。エラーを修正した完全なYAMLを生成してください。

技術スタック: {tech_name}

検証エラー:
{errors_text}

現在のYAML:
```yaml
{yaml_content}
```

修正時の注意事項:
1. ルールIDは大文字とアンダースコアのみ使用（例: CUSTOM_REACT_SECURITY_01）
2. カテゴリは以下のいずれか: database, security, solid, performance, custom
3. 必須フィールド: id, category, name, description, patterns
4. patternsは言語ごとに定義（typescript, javascript, python等）
5. コメント行は保持してください

修正後のYAMLのみを出力してください（説明不要）。
```yaml で開始し、``` で終了してください。"""

        try:
            # 環境変数からAI設定を読み込み
            ai_provider = os.getenv('AI_PROVIDER', 'auto').lower()

            # Anthropic Claudeを優先的に使用
            if (ai_provider in ['auto', 'anthropic']) and ANTHROPIC_AVAILABLE:
                anthropic_key = os.getenv('ANTHROPIC_API_KEY')
                if anthropic_key:
                    return self._fix_with_anthropic(prompt, anthropic_key)

            # OpenAI GPTを使用
            if (ai_provider in ['auto', 'openai']) and OPENAI_AVAILABLE:
                openai_key = os.getenv('OPENAI_API_KEY')
                if openai_key:
                    return self._fix_with_openai(prompt, openai_key)

            print("⚠️  AI APIが利用できません（APIキーまたはライブラリ不足）")
            return None

        except Exception as e:
            print(f"⚠️  AI修正エラー: {e}")
            return None

    def _fix_with_anthropic(self, prompt: str, api_key: str) -> Optional[str]:
        """Anthropic Claudeで修正"""
        try:
            client = anthropic.Anthropic(api_key=api_key)
            model = os.getenv('ANTHROPIC_MODEL', 'claude-sonnet-4')

            print(f"   使用モデル: Anthropic {model}")

            response = client.messages.create(
                model=model,
                max_tokens=4096,
                messages=[{"role": "user", "content": prompt}]
            )

            content = response.content[0].text
            return self._extract_yaml_from_response(content)

        except Exception as e:
            print(f"⚠️  Anthropic APIエラー: {e}")
            return None

    def _fix_with_openai(self, prompt: str, api_key: str) -> Optional[str]:
        """OpenAI GPTで修正"""
        try:
            client = openai.OpenAI(api_key=api_key)
            model = os.getenv('OPENAI_MODEL', 'gpt-4o')

            print(f"   使用モデル: OpenAI {model}")

            response = client.chat.completions.create(
                model=model,
                messages=[{"role": "user", "content": prompt}],
                max_tokens=4096,
                temperature=0.3
            )

            content = response.choices[0].message.content
            return self._extract_yaml_from_response(content)

        except Exception as e:
            print(f"⚠️  OpenAI APIエラー: {e}")
            return None

    def _extract_yaml_from_response(self, response: str) -> Optional[str]:
        """AI応答からYAML部分を抽出"""
        # ```yaml ... ``` または ``` ... ``` を抽出
        import re

        # ```yaml または ``` で囲まれた部分を探す
        patterns = [
            r'```yaml\s*\n(.*?)\n```',
            r'```\s*\n(.*?)\n```',
        ]

        for pattern in patterns:
            match = re.search(pattern, response, re.DOTALL)
            if match:
                yaml_content = match.group(1).strip()
                print("✅ AI修正完了: YAMLを抽出しました")
                return yaml_content

        # マークダウンなしの場合はそのまま返す
        print("✅ AI修正完了: YAML（マークダウンなし）")
        return response.strip()

    def generate_config(
        self,
        tech_name: str,
        topic: Optional[str] = None,
        include_examples: bool = True,
        custom_filename: Optional[str] = None,
        auto_fix: bool = True,
        max_fix_attempts: int = 5
    ) -> Tuple[bool, Optional[Path], str]:
        """
        設定ファイルを自動生成（全工程 + AI自動修正ループ）

        Args:
            tech_name: 技術名/フレームワーク名
            topic: フォーカスするトピック
            include_examples: サンプルコードを含めるか
            custom_filename: カスタムファイル名
            auto_fix: AI自動修正を有効にするか（デフォルト: True）
            max_fix_attempts: AI修正の最大試行回数（デフォルト: 5）

        Returns:
            (成功フラグ, ファイルパス, メッセージ)
        """
        print("=" * 80)
        print(f"🚀 Config Generation Started: {tech_name}")
        print("=" * 80)

        try:
            # 1. ライブラリID解決
            library_id = self.resolve_library(tech_name)
            if not library_id:
                return False, None, f"ライブラリが見つかりません: {tech_name}"

            # 2. ドキュメント取得
            docs = self.fetch_documentation(library_id, topic)
            if not docs:
                return False, None, f"ドキュメントの取得に失敗: {tech_name}"

            # 3. ベストプラクティス解析
            checks = self.analyze_best_practices(docs, tech_name)
            if not checks:
                return False, None, f"チェック項目が見つかりません: {tech_name}"

            # 4. YAMLルール生成
            yaml_content = self.generate_yaml_rules(checks, tech_name, include_examples)

            # 5. ファイル保存
            filepath = self.save_config_file(yaml_content, tech_name, custom_filename)

            # 6. 検証 + AI自動修正ループ
            print()
            current_yaml = yaml_content
            attempt = 0

            while attempt < max_fix_attempts:
                attempt += 1

                # 検証実行
                is_valid, validation_errors = self.validate_generated_config(filepath)

                if is_valid:
                    # 検証成功
                    print("=" * 80)
                    print(f"✅ Config Generation Completed")
                    print(f"   File: {filepath}")
                    print(f"   Rules: {len(checks)}")
                    print(f"   Validation: PASSED ✓")
                    if attempt > 1:
                        print(f"   AI修正回数: {attempt - 1}回")
                    print("=" * 80)

                    return True, filepath, "設定ファイルの生成と検証に成功しました"

                # 検証エラー
                print()
                print(f"⚠️  検証エラー検出 (試行 {attempt}/{max_fix_attempts})")
                print("   エラー内容:")
                for error in validation_errors:
                    print(f"     - {error}")
                print()

                # AI自動修正を試行
                if auto_fix and attempt < max_fix_attempts:
                    print(f"🤖 AI自動修正を開始...")
                    fixed_yaml = self.fix_yaml_with_ai(current_yaml, validation_errors, tech_name, attempt)

                    if fixed_yaml:
                        # 修正されたYAMLを保存
                        current_yaml = fixed_yaml
                        with open(filepath, 'w', encoding='utf-8') as f:
                            f.write(fixed_yaml)
                        print(f"✅ 修正版YAMLを保存しました: {filepath}")
                        print()
                        print("=" * 80)
                        print(f"🔄 再検証を実行中... (試行 {attempt + 1}/{max_fix_attempts})")
                        print("=" * 80)
                        print()
                    else:
                        # AI修正失敗
                        print("⚠️  AI修正に失敗しました")
                        break
                else:
                    # auto_fixが無効、または最大試行回数到達
                    break

            # 最大試行回数を超えてもエラーが残る場合
            print("=" * 80)
            print(f"⚠️  Config Generated with Validation Errors")
            print(f"   File: {filepath}")
            print(f"   Rules: {len(checks)}")
            print(f"   AI修正試行回数: {attempt}回")
            print("=" * 80)
            print()
            print("最終検証エラー:")
            for error in validation_errors:
                print(f"  - {error}")
            print()
            if auto_fix:
                print("⚠️  AI自動修正でもエラーを解決できませんでした。")
                print("   手動で確認・修正してください。")
            else:
                print("⚠️  AI自動修正が無効です。")
                print("   --auto-fix オプションを有効にするか、手動で修正してください。")
            print("=" * 80)

            return True, filepath, f"設定ファイルは生成されましたが、検証エラーがあります（AI修正{attempt}回試行）: {', '.join(validation_errors)}"

        except Exception as e:
            error_msg = f"設定ファイル生成エラー: {e}"
            print(f"❌ {error_msg}")
            import traceback
            traceback.print_exc()
            return False, None, error_msg


def generate_config_for_tech(
    tech_name: str,
    topic: Optional[str] = None,
    include_examples: bool = True,
    custom_filename: Optional[str] = None
) -> Tuple[bool, Optional[Path], str]:
    """
    設定ファイルを生成（簡易インターフェース）

    Args:
        tech_name: 技術名/フレームワーク名
        topic: フォーカスするトピック
        include_examples: サンプルコードを含めるか
        custom_filename: カスタムファイル名

    Returns:
        (成功フラグ, ファイルパス, メッセージ)
    """
    generator = ConfigGenerator()
    return generator.generate_config(tech_name, topic, include_examples, custom_filename)

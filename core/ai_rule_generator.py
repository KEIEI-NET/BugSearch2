"""
AI支援ルール生成

Phase 4.2の新機能:
- コード例からのルール自動生成
- 自然言語説明からのルール作成
- ルール最適化提案
- マルチAIプロバイダーサポート

バージョン: v4.5.0 (Phase 4.2)
作成日: 2025年10月12日 JST

@perfect品質:
- 複数AIプロバイダーサポート
- 自動フォールバック
- 詳細なエラーハンドリング
"""

from pathlib import Path
from typing import Optional, Dict, List
import os
import yaml


class AIRuleGenerator:
    """
    AI支援ルール生成

    Phase 4.2の新機能:
    - マルチAIプロバイダー (Anthropic/OpenAI)
    - コード→ルール変換
    - 説明→ルール変換
    - ルール最適化
    """

    def __init__(self):
        """
        初期化

        環境変数からAPI設定を読み込み
        """
        self.anthropic_key = os.getenv('ANTHROPIC_API_KEY')
        self.openai_key = os.getenv('OPENAI_API_KEY')
        self.ai_provider = os.getenv('AI_PROVIDER', 'auto')

        # AI API クライアント（遅延初期化）
        self._anthropic_client = None
        self._openai_client = None

    def generate_from_code(
        self,
        code_example: str,
        problem_description: str,
        language: str = "csharp"
    ) -> Optional[str]:
        """
        コード例からルールを生成

        Args:
            code_example: 問題のあるコード例
            problem_description: 問題の説明
            language: プログラミング言語

        Returns:
            生成されたルールYAML（失敗時はNone）
        """
        prompt = self._build_code_to_rule_prompt(code_example, problem_description, language)

        try:
            response = self._call_ai(prompt)
            if response:
                return self._extract_yaml(response)
            return None
        except Exception as e:
            print(f"[ERROR] AI生成失敗: {e}")
            return None

    def generate_from_description(
        self,
        description: str,
        target_language: str = "csharp",
        category: str = "custom"
    ) -> Optional[str]:
        """
        自然言語説明からルールを生成

        Args:
            description: ルールの説明
            target_language: 対象言語
            category: ルールカテゴリ

        Returns:
            生成されたルールYAML（失敗時はNone）
        """
        prompt = self._build_description_to_rule_prompt(description, target_language, category)

        try:
            response = self._call_ai(prompt)
            if response:
                return self._extract_yaml(response)
            return None
        except Exception as e:
            print(f"[ERROR] AI生成失敗: {e}")
            return None

    def optimize_rule(
        self,
        rule_yaml: str,
        optimization_goals: Optional[List[str]] = None
    ) -> Optional[str]:
        """
        既存ルールを最適化

        Args:
            rule_yaml: 最適化するルールYAML
            optimization_goals: 最適化目標のリスト

        Returns:
            最適化されたルールYAML（失敗時はNone）
        """
        if optimization_goals is None:
            optimization_goals = [
                "正規表現パターンの精度向上",
                "深刻度の適切な設定",
                "具体的な修正方法の提案",
                "誤検知の削減"
            ]

        prompt = self._build_optimization_prompt(rule_yaml, optimization_goals)

        try:
            response = self._call_ai(prompt)
            if response:
                return self._extract_yaml(response)
            return None
        except Exception as e:
            print(f"[ERROR] AI最適化失敗: {e}")
            return None

    def suggest_improvements(self, rule_yaml: str) -> Optional[str]:
        """
        ルールの改善提案を生成

        Args:
            rule_yaml: 対象ルールYAML

        Returns:
            改善提案（マークダウン形式）
        """
        prompt = f"""
以下のBugSearch2ルールを分析して、改善提案を生成してください。

ルール:
```yaml
{rule_yaml}
```

以下の観点から提案してください:
1. パターンの精度（誤検知を減らす方法）
2. 検出漏れのリスク
3. 深刻度の妥当性
4. より具体的な修正方法
5. パフォーマンスの改善

マークダウン形式で提案を返してください。
"""

        try:
            response = self._call_ai(prompt)
            return response
        except Exception as e:
            print(f"[ERROR] 提案生成失敗: {e}")
            return None

    def _build_code_to_rule_prompt(
        self,
        code_example: str,
        problem_description: str,
        language: str
    ) -> str:
        """コード→ルール変換のプロンプトを構築"""
        return f"""
以下のコード例から、BugSearch2用のルールYAMLを生成してください。

問題の説明: {problem_description}
言語: {language}

問題のあるコード例:
```{language}
{code_example}
```

生成するルールは以下の形式に従ってください:

```yaml
rule:
  id: "GENERATED_RULE_NAME"  # 大文字とアンダースコアのみ
  category: "custom"
  name: "Rule Name"
  description: "Rule description"
  base_severity: 7  # 1-10（10が最も重大）

  patterns:
    {language}:
      - pattern: '正規表現パターン'  # コード例に基づいて生成
        context: "コンテキスト説明"

  fixes:
    {language}:
      - "修正方法の提案1"
      - "修正方法の提案2"
```

重要な注意事項:
- 正規表現は具体的にしてください（広すぎる.*は避ける）
- 深刻度はコードの影響を考慮して設定
- 修正方法は実用的で具体的に
- ルールIDは内容を反映した名前に

YAMLのみを返してください。説明文は不要です。
"""

    def _build_description_to_rule_prompt(
        self,
        description: str,
        target_language: str,
        category: str
    ) -> str:
        """説明→ルール変換のプロンプトを構築"""
        return f"""
以下の説明から、BugSearch2用のルールYAMLを生成してください。

ルールの説明: {description}
対象言語: {target_language}
カテゴリ: {category}

生成するルールは以下の形式に従ってください:

```yaml
rule:
  id: "GENERATED_RULE_NAME"  # 大文字とアンダースコアのみ
  category: "{category}"
  name: "Rule Name"
  description: "{description}"
  base_severity: 7  # 1-10（10が最も重大）

  patterns:
    {target_language}:
      - pattern: '正規表現パターン'
        context: "コンテキスト説明"

  fixes:
    {target_language}:
      - "修正方法の提案1"
      - "修正方法の提案2"
```

重要な注意事項:
- 説明から適切なパターンを推測してください
- 深刻度は問題の重大性を考慮して設定
- ルールIDは説明から意味のある名前を生成

YAMLのみを返してください。説明文は不要です。
"""

    def _build_optimization_prompt(
        self,
        rule_yaml: str,
        optimization_goals: List[str]
    ) -> str:
        """最適化のプロンプトを構築"""
        goals_text = "\n".join(f"- {goal}" for goal in optimization_goals)

        return f"""
以下のBugSearch2ルールYAMLを最適化してください。

最適化の目標:
{goals_text}

現在のルール:
```yaml
{rule_yaml}
```

最適化されたYAMLのみを返してください。説明文は不要です。
"""

    def _call_ai(self, prompt: str) -> Optional[str]:
        """
        AIプロバイダーを呼び出し

        Args:
            prompt: プロンプト

        Returns:
            AI応答（失敗時はNone）
        """
        # Autoモード: Anthropic → OpenAI → エラー の順で試行
        if self.ai_provider == 'auto':
            if self.anthropic_key:
                try:
                    return self._call_anthropic(prompt)
                except Exception as e:
                    print(f"[WARNING] Anthropic API失敗: {e}")

            if self.openai_key:
                try:
                    return self._call_openai(prompt)
                except Exception as e:
                    print(f"[WARNING] OpenAI API失敗: {e}")

            raise ValueError("AI APIキーが設定されていないか、全てのプロバイダーでエラーが発生しました")

        # 明示的プロバイダー指定
        elif self.ai_provider == 'anthropic':
            return self._call_anthropic(prompt)
        elif self.ai_provider == 'openai':
            return self._call_openai(prompt)
        else:
            raise ValueError(f"未サポートのAIプロバイダー: {self.ai_provider}")

    def _call_anthropic(self, prompt: str) -> str:
        """
        Anthropic Claude API呼び出し

        Args:
            prompt: プロンプト

        Returns:
            AI応答

        Raises:
            ValueError: APIキー未設定
            Exception: API呼び出し失敗
        """
        if not self.anthropic_key:
            raise ValueError("ANTHROPIC_API_KEYが設定されていません")

        if self._anthropic_client is None:
            try:
                import anthropic
                self._anthropic_client = anthropic.Anthropic(api_key=self.anthropic_key)
            except ImportError:
                raise ImportError("anthropicパッケージがインストールされていません: pip install anthropic")

        message = self._anthropic_client.messages.create(
            model="claude-sonnet-4-5",
            max_tokens=2000,
            messages=[
                {"role": "user", "content": prompt}
            ]
        )

        return message.content[0].text

    def _call_openai(self, prompt: str) -> str:
        """
        OpenAI API呼び出し

        Args:
            prompt: プロンプト

        Returns:
            AI応答

        Raises:
            ValueError: APIキー未設定
            Exception: API呼び出し失敗
        """
        if not self.openai_key:
            raise ValueError("OPENAI_API_KEYが設定されていません")

        if self._openai_client is None:
            try:
                import openai
                self._openai_client = openai.OpenAI(api_key=self.openai_key)
            except ImportError:
                raise ImportError("openaiパッケージがインストールされていません: pip install openai")

        response = self._openai_client.chat.completions.create(
            model="gpt-4o",
            messages=[
                {"role": "user", "content": prompt}
            ]
        )

        return response.choices[0].message.content

    def _extract_yaml(self, response: str) -> Optional[str]:
        """
        AI応答からYAMLを抽出

        Args:
            response: AI応答

        Returns:
            抽出されたYAML（失敗時はNone）
        """
        try:
            # コードブロックから抽出
            if "```yaml" in response:
                start = response.index("```yaml") + 7
                end = response.index("```", start)
                yaml_text = response[start:end].strip()
            elif "```" in response:
                start = response.index("```") + 3
                end = response.index("```", start)
                yaml_text = response[start:end].strip()
            else:
                yaml_text = response.strip()

            # YAML妥当性チェック
            yaml.safe_load(yaml_text)

            return yaml_text

        except Exception as e:
            print(f"[ERROR] YAML抽出失敗: {e}")
            return None


class RuleGenerationWizard:
    """
    AI支援ルール生成ウィザード

    対話的なAIルール生成をサポート
    """

    def __init__(self):
        self.generator = AIRuleGenerator()

    def run_code_to_rule_wizard(self):
        """コード→ルール変換ウィザード"""
        print("=" * 80)
        print("🤖 AI支援ルール生成ウィザード: コードから生成")
        print("=" * 80)
        print()

        # 言語選択
        print("対象言語を選択してください:")
        print("1. C#")
        print("2. Java")
        print("3. Python")
        print("4. JavaScript/TypeScript")
        print("5. PHP")
        print("6. Go")

        language_map = {
            '1': 'csharp',
            '2': 'java',
            '3': 'python',
            '4': 'javascript',
            '5': 'php',
            '6': 'go'
        }

        lang_choice = input("\n選択 (1-6): ").strip()
        language = language_map.get(lang_choice, 'csharp')

        # コード例の入力
        print("\n問題のあるコード例を入力してください（終了: 空行を2回）:")
        code_lines = []
        empty_count = 0

        while True:
            line = input()
            if not line:
                empty_count += 1
                if empty_count >= 2:
                    break
            else:
                empty_count = 0
                code_lines.append(line)

        code_example = "\n".join(code_lines)

        # 問題の説明
        print("\n問題の説明を入力してください:")
        problem_description = input().strip()

        # AI生成実行
        print("\n🔄 AIでルールを生成中...")

        rule_yaml = self.generator.generate_from_code(
            code_example,
            problem_description,
            language
        )

        if rule_yaml:
            print("\n✅ ルール生成成功！")
            print("\n生成されたルール:")
            print("-" * 80)
            print(rule_yaml)
            print("-" * 80)

            # 保存確認
            save = input("\nこのルールを保存しますか？ (y/n): ").strip().lower()
            if save == 'y':
                self._save_generated_rule(rule_yaml)
        else:
            print("\n❌ ルール生成に失敗しました")

    def run_description_to_rule_wizard(self):
        """説明→ルール変換ウィザード"""
        print("=" * 80)
        print("🤖 AI支援ルール生成ウィザード: 説明から生成")
        print("=" * 80)
        print()

        # 説明入力
        print("検出したい問題を説明してください:")
        description = input().strip()

        # 言語選択
        print("\n対象言語を選択してください:")
        print("1. C#")
        print("2. Java")
        print("3. Python")
        print("4. JavaScript/TypeScript")
        print("5. その他")

        language_map = {
            '1': 'csharp',
            '2': 'java',
            '3': 'python',
            '4': 'javascript',
            '5': 'custom'
        }

        lang_choice = input("\n選択 (1-5): ").strip()
        language = language_map.get(lang_choice, 'csharp')

        # AI生成実行
        print("\n🔄 AIでルールを生成中...")

        rule_yaml = self.generator.generate_from_description(description, language)

        if rule_yaml:
            print("\n✅ ルール生成成功！")
            print("\n生成されたルール:")
            print("-" * 80)
            print(rule_yaml)
            print("-" * 80)

            # 保存確認
            save = input("\nこのルールを保存しますか？ (y/n): ").strip().lower()
            if save == 'y':
                self._save_generated_rule(rule_yaml)
        else:
            print("\n❌ ルール生成に失敗しました")

    def _save_generated_rule(self, rule_yaml: str):
        """生成されたルールを保存"""
        try:
            # ルールIDを抽出
            rule_data = yaml.safe_load(rule_yaml)
            rule_id = rule_data['rule']['id']

            # 保存先
            output_dir = Path(".bugsearch/rules/ai-generated")
            output_dir.mkdir(parents=True, exist_ok=True)

            output_file = output_dir / f"{rule_id.lower().replace('_', '-')}.yml"

            with open(output_file, 'w', encoding='utf-8') as f:
                f.write(rule_yaml)

            print(f"\n✅ ルール保存完了: {output_file}")
            print("\n次のステップ:")
            print("1. ルールファイルを確認・編集")
            print("2. python codex_review_severity.py index で再インデックス")
            print("3. python codex_review_severity.py advise --all で分析実行")

        except Exception as e:
            print(f"\n❌ 保存失敗: {e}")

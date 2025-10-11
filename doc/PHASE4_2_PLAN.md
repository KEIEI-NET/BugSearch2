# Phase 4.2 実装計画: ルール共有・メトリクス・AI支援

*バージョン: v4.5.0 (Phase 4.2開始)*
*作成日: 2025年10月12日 JST*
*最終更新: 2025年10月12日 JST*

## 🎯 Phase 4.2の目標

**ルール共有・メトリクス収集・AI支援による高度なルール管理**

Phase 4.1で完成したルールテンプレートシステムの上に、コミュニティ機能とインテリジェンス機能を構築します。

### 達成基準
- [ ] ルール共有機能実装 (インポート/エクスポート)
- [ ] ルールメトリクス収集システム実装
- [ ] AI支援ルール生成機能実装
- [ ] コミュニティルールリポジトリサポート
- [ ] @perfect品質維持 (全テスト100%合格)

---

## 📊 現在の状況

### Phase 4.1完了 (v4.4.0) ✅
- ✅ ルールテンプレート機能実装
- ✅ 対話型ルール生成ウィザード実装
- ✅ テンプレートカタログ作成（5種類）
- ✅ 全テスト100%合格 (7/7)

### Phase 4.2の新機能

Phase 4.1で実装したテンプレートシステムを拡張し、以下を実現：

1. **ルール共有機能**
   - ルールのエクスポート (JSON/YAML形式)
   - ルールのインポート (バリデーション付き)
   - コミュニティルールリポジトリからの取得
   - ルールパッケージのバージョン管理

2. **ルールメトリクス**
   - ルールごとの検出統計 (検出数、ファイル数)
   - 誤検知率の追跡
   - ルールのパフォーマンス分析 (実行時間、メモリ使用量)
   - メトリクスの可視化

3. **AI支援ルール生成**
   - コード例からのルール自動生成
   - 自然言語説明からのルール作成
   - 既存ルールの最適化提案
   - パターンの改善提案

---

## 🔧 実装項目

### 1. ルール共有機能 (優先度: 高)

#### ルールエクスポート機能

**core/rule_sharing.py**

```python
"""
ルール共有機能

Phase 4.2の新機能:
- ルールのエクスポート
- ルールのインポート
- コミュニティルールリポジトリサポート
"""

from pathlib import Path
from typing import List, Dict, Optional
import json
import yaml
from datetime import datetime
from core.rule_engine import Rule, RuleValidator


class RuleExporter:
    """ルールのエクスポート機能"""

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
        """
        with open(rule_file, 'r', encoding='utf-8') as f:
            rule_data = yaml.safe_load(f)

        if include_metadata:
            rule_data['metadata'] = {
                'exported_at': datetime.now().isoformat(),
                'exported_by': 'BugSearch2',
                'version': 'v4.5.0',
                'source_file': str(rule_file)
            }

        if output_format == 'json':
            return json.dumps(rule_data, indent=2, ensure_ascii=False)
        else:
            return yaml.dump(rule_data, allow_unicode=True, default_flow_style=False)

    def export_rule_package(
        self,
        rule_files: List[Path],
        package_name: str,
        output_dir: Path
    ) -> Path:
        """
        複数のルールをパッケージとしてエクスポート

        Args:
            rule_files: ルールファイルのリスト
            package_name: パッケージ名
            output_dir: 出力ディレクトリ

        Returns:
            作成されたパッケージファイルのパス
        """
        package_data = {
            'package': {
                'name': package_name,
                'version': '1.0.0',
                'created_at': datetime.now().isoformat(),
                'rules': []
            }
        }

        for rule_file in rule_files:
            with open(rule_file, 'r', encoding='utf-8') as f:
                rule_data = yaml.safe_load(f)
                package_data['package']['rules'].append(rule_data)

        output_dir.mkdir(parents=True, exist_ok=True)
        package_file = output_dir / f"{package_name}.json"

        with open(package_file, 'w', encoding='utf-8') as f:
            json.dump(package_data, f, indent=2, ensure_ascii=False)

        print(f"[OK] パッケージ作成完了: {package_file}")
        return package_file


class RuleImporter:
    """ルールのインポート機能"""

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
            作成されたルールファイルのパス
        """
        # YAML/JSON自動判定
        try:
            if rule_content.strip().startswith('{'):
                rule_data = json.loads(rule_content)
            else:
                rule_data = yaml.safe_load(rule_content)
        except Exception as e:
            print(f"[ERROR] ルールのパース失敗: {e}")
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
                # エラーがあってもファイルは作成済み
            else:
                print(f"[OK] バリデーション成功")

        print(f"[OK] ルールインポート完了: {output_file}")
        return output_file

    def import_rule_package(
        self,
        package_file: Path,
        output_dir: Path
    ) -> List[Path]:
        """
        ルールパッケージをインポート

        Args:
            package_file: パッケージファイルのパス
            output_dir: 出力ディレクトリ

        Returns:
            インポートされたルールファイルのリスト
        """
        with open(package_file, 'r', encoding='utf-8') as f:
            package_data = json.load(f)

        if 'package' not in package_data or 'rules' not in package_data['package']:
            print("[ERROR] 無効なパッケージ形式")
            return []

        imported_files = []
        rules = package_data['package']['rules']

        for rule_data in rules:
            rule_yaml = yaml.dump(rule_data, allow_unicode=True, default_flow_style=False)
            rule_file = self.import_rule(rule_yaml, output_dir, validate=True)
            if rule_file:
                imported_files.append(rule_file)

        print(f"[OK] {len(imported_files)}/{len(rules)}個のルールをインポートしました")
        return imported_files


class CommunityRuleRepository:
    """コミュニティルールリポジトリアクセス"""

    def __init__(self, repo_url: str = "https://github.com/bugsearch2/community-rules"):
        self.repo_url = repo_url
        self.cache_dir = Path.home() / ".bugsearch" / "community-rules"

    def list_available_packages(self) -> List[Dict]:
        """利用可能なルールパッケージ一覧を取得"""
        # TODO: GitHubリポジトリからパッケージリストを取得
        # 実装例:
        # - GitHub APIでリリース一覧を取得
        # - パッケージメタデータをパース
        return []

    def download_package(self, package_name: str, version: str = "latest") -> Optional[Path]:
        """
        コミュニティルールパッケージをダウンロード

        Args:
            package_name: パッケージ名
            version: バージョン (デフォルト: latest)

        Returns:
            ダウンロードされたパッケージファイルのパス
        """
        # TODO: GitHubリリースからパッケージをダウンロード
        # 実装例:
        # - GitHub APIでリリースアセットを取得
        # - ファイルをダウンロード
        # - キャッシュディレクトリに保存
        pass
```

#### CLIコマンド拡張

```python
# codex_review_severity.py への追加

def rules_share_cmd(args):
    """ルール共有コマンド"""
    from core.rule_sharing import RuleExporter, RuleImporter, CommunityRuleRepository

    if args.export:
        # ルールをエクスポート
        exporter = RuleExporter()
        rule_file = Path(args.export)

        output_format = args.format or 'yaml'
        result = exporter.export_rule(rule_file, output_format=output_format)

        if args.output:
            with open(args.output, 'w', encoding='utf-8') as f:
                f.write(result)
            print(f"[OK] エクスポート完了: {args.output}")
        else:
            print(result)

    elif args.import_rule:
        # ルールをインポート
        importer = RuleImporter()

        with open(args.import_rule, 'r', encoding='utf-8') as f:
            rule_content = f.read()

        output_dir = Path(args.output_dir or ".bugsearch/rules/imported")
        importer.import_rule(rule_content, output_dir)

    elif args.package_create:
        # パッケージ作成
        exporter = RuleExporter()
        rule_files = [Path(f) for f in args.rules]
        output_dir = Path(args.output_dir or ".")

        exporter.export_rule_package(rule_files, args.package_create, output_dir)

    elif args.package_install:
        # パッケージインストール
        importer = RuleImporter()
        package_file = Path(args.package_install)
        output_dir = Path(args.output_dir or ".bugsearch/rules/community")

        importer.import_rule_package(package_file, output_dir)

    elif args.community_list:
        # コミュニティパッケージ一覧
        repo = CommunityRuleRepository()
        packages = repo.list_available_packages()

        print("📦 利用可能なコミュニティルールパッケージ:")
        for pkg in packages:
            print(f"  - {pkg['name']} (v{pkg['version']})")

    elif args.community_install:
        # コミュニティパッケージインストール
        repo = CommunityRuleRepository()
        package_file = repo.download_package(args.community_install)

        if package_file:
            importer = RuleImporter()
            output_dir = Path(".bugsearch/rules/community")
            importer.import_rule_package(package_file, output_dir)

# CLI引数追加
parser.add_argument('--export', type=str, help='ルールをエクスポート')
parser.add_argument('--import-rule', type=str, help='ルールをインポート')
parser.add_argument('--package-create', type=str, help='ルールパッケージを作成')
parser.add_argument('--package-install', type=str, help='ルールパッケージをインストール')
parser.add_argument('--community-list', action='store_true', help='コミュニティルール一覧')
parser.add_argument('--community-install', type=str, help='コミュニティルールをインストール')
parser.add_argument('--format', type=str, choices=['yaml', 'json'], help='エクスポート形式')
parser.add_argument('--output-dir', type=str, help='出力ディレクトリ')
```

---

### 2. ルールメトリクス (優先度: 高)

**core/rule_metrics.py**

```python
"""
ルールメトリクス収集

Phase 4.2の新機能:
- ルールごとの検出統計
- 誤検知率の追跡
- パフォーマンス分析
"""

from pathlib import Path
from typing import Dict, List, Any
from datetime import datetime
from dataclasses import dataclass, asdict
import json
import time


@dataclass
class RuleMetric:
    """ルールメトリクス"""
    rule_id: str
    total_detections: int = 0
    total_files: int = 0
    false_positives: int = 0
    execution_time_ms: float = 0.0
    last_execution: str = ""


class RuleMetricsCollector:
    """ルールメトリクス収集"""

    def __init__(self, metrics_file: Path = Path(".bugsearch/metrics.json")):
        self.metrics_file = metrics_file
        self.metrics: Dict[str, RuleMetric] = {}
        self._load_metrics()

    def _load_metrics(self):
        """既存のメトリクスを読み込み"""
        if self.metrics_file.exists():
            try:
                with open(self.metrics_file, 'r', encoding='utf-8') as f:
                    data = json.load(f)
                    for rule_id, metric_data in data.items():
                        self.metrics[rule_id] = RuleMetric(**metric_data)
            except Exception as e:
                print(f"[WARNING] メトリクス読み込みエラー: {e}")

    def _save_metrics(self):
        """メトリクスを保存"""
        self.metrics_file.parent.mkdir(parents=True, exist_ok=True)

        data = {rule_id: asdict(metric) for rule_id, metric in self.metrics.items()}

        with open(self.metrics_file, 'w', encoding='utf-8') as f:
            json.dump(data, f, indent=2, ensure_ascii=False)

    def record_detection(
        self,
        rule_id: str,
        file_path: str,
        execution_time_ms: float
    ):
        """検出を記録"""
        if rule_id not in self.metrics:
            self.metrics[rule_id] = RuleMetric(rule_id=rule_id)

        metric = self.metrics[rule_id]
        metric.total_detections += 1
        metric.total_files += 1  # TODO: ファイル重複除外
        metric.execution_time_ms += execution_time_ms
        metric.last_execution = datetime.now().isoformat()

        self._save_metrics()

    def record_false_positive(self, rule_id: str):
        """誤検知を記録"""
        if rule_id in self.metrics:
            self.metrics[rule_id].false_positives += 1
            self._save_metrics()

    def get_metrics(self, rule_id: str) -> Optional[RuleMetric]:
        """特定ルールのメトリクスを取得"""
        return self.metrics.get(rule_id)

    def get_all_metrics(self) -> List[RuleMetric]:
        """全ルールのメトリクスを取得"""
        return list(self.metrics.values())

    def get_false_positive_rate(self, rule_id: str) -> float:
        """誤検知率を計算"""
        metric = self.metrics.get(rule_id)
        if not metric or metric.total_detections == 0:
            return 0.0

        return metric.false_positives / metric.total_detections

    def generate_report(self) -> str:
        """メトリクスレポートを生成"""
        lines = [
            "=" * 80,
            "📊 ルールメトリクスレポート",
            "=" * 80,
            ""
        ]

        # ルールごとのメトリクス
        for rule_id, metric in sorted(self.metrics.items()):
            fp_rate = self.get_false_positive_rate(rule_id)

            lines.append(f"■ {rule_id}")
            lines.append(f"  検出数: {metric.total_detections}件")
            lines.append(f"  対象ファイル数: {metric.total_files}件")
            lines.append(f"  誤検知率: {fp_rate * 100:.1f}%")
            lines.append(f"  平均実行時間: {metric.execution_time_ms / max(metric.total_detections, 1):.2f}ms")
            lines.append(f"  最終実行: {metric.last_execution}")
            lines.append("")

        return "\n".join(lines)
```

---

### 3. AI支援ルール生成 (優先度: 中)

**core/ai_rule_generator.py**

```python
"""
AI支援ルール生成

Phase 4.2の新機能:
- コード例からのルール自動生成
- 自然言語説明からのルール作成
- ルール最適化提案
"""

from pathlib import Path
from typing import Optional, Dict, List
import anthropic
import openai
import os


class AIRuleGenerator:
    """AI支援ルール生成"""

    def __init__(self):
        # API設定
        self.anthropic_key = os.getenv('ANTHROPIC_API_KEY')
        self.openai_key = os.getenv('OPENAI_API_KEY')
        self.ai_provider = os.getenv('AI_PROVIDER', 'auto')

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
            生成されたルールYAML
        """
        prompt = f"""
以下のコード例から、BugSearch2用のルールYAMLを生成してください。

問題の説明: {problem_description}
言語: {language}

コード例:
```{language}
{code_example}
```

生成するルールは以下の形式に従ってください:

```yaml
rule:
  id: "GENERATED_RULE_NAME"
  category: "custom"
  name: "Rule Name"
  description: "Rule description"
  base_severity: 7

  patterns:
    {language}:
      - pattern: '正規表現パターン'
        context: "コンテキスト説明"

  fixes:
    {language}:
      - "修正方法の提案"
```

YAMLのみを返してください。説明文は不要です。
"""

        try:
            response = self._call_ai(prompt)
            return self._extract_yaml(response)
        except Exception as e:
            print(f"[ERROR] AI生成失敗: {e}")
            return None

    def generate_from_description(
        self,
        description: str,
        target_language: str = "csharp"
    ) -> Optional[str]:
        """
        自然言語説明からルールを生成

        Args:
            description: ルールの説明
            target_language: 対象言語

        Returns:
            生成されたルールYAML
        """
        prompt = f"""
以下の説明から、BugSearch2用のルールYAMLを生成してください。

ルールの説明: {description}
対象言語: {target_language}

生成するルールは以下の形式に従ってください:

```yaml
rule:
  id: "GENERATED_RULE_NAME"
  category: "custom"
  name: "Rule Name"
  description: "Rule description"
  base_severity: 7

  patterns:
    {target_language}:
      - pattern: '正規表現パターン'
        context: "コンテキスト説明"

  fixes:
    {target_language}:
      - "修正方法の提案"
```

YAMLのみを返してください。説明文は不要です。
"""

        try:
            response = self._call_ai(prompt)
            return self._extract_yaml(response)
        except Exception as e:
            print(f"[ERROR] AI生成失敗: {e}")
            return None

    def optimize_rule(self, rule_yaml: str) -> Optional[str]:
        """
        既存ルールを最適化

        Args:
            rule_yaml: 最適化するルールYAML

        Returns:
            最適化されたルールYAML
        """
        prompt = f"""
以下のBugSearch2ルールYAMLを最適化してください。

最適化のポイント:
1. 正規表現パターンの精度向上
2. 深刻度の適切な設定
3. より具体的な修正方法の提案
4. コンテキスト説明の改善

現在のルール:
```yaml
{rule_yaml}
```

最適化されたYAMLのみを返してください。説明文は不要です。
"""

        try:
            response = self._call_ai(prompt)
            return self._extract_yaml(response)
        except Exception as e:
            print(f"[ERROR] AI最適化失敗: {e}")
            return None

    def _call_ai(self, prompt: str) -> str:
        """AIプロバイダーを呼び出し"""
        if self.ai_provider == 'anthropic' or (self.ai_provider == 'auto' and self.anthropic_key):
            return self._call_anthropic(prompt)
        elif self.ai_provider == 'openai' or (self.ai_provider == 'auto' and self.openai_key):
            return self._call_openai(prompt)
        else:
            raise ValueError("AI APIキーが設定されていません")

    def _call_anthropic(self, prompt: str) -> str:
        """Anthropic Claude API呼び出し"""
        client = anthropic.Anthropic(api_key=self.anthropic_key)

        message = client.messages.create(
            model="claude-sonnet-4-5",
            max_tokens=2000,
            messages=[
                {"role": "user", "content": prompt}
            ]
        )

        return message.content[0].text

    def _call_openai(self, prompt: str) -> str:
        """OpenAI API呼び出し"""
        client = openai.OpenAI(api_key=self.openai_key)

        response = client.chat.completions.create(
            model="gpt-4o",
            messages=[
                {"role": "user", "content": prompt}
            ]
        )

        return response.choices[0].message.content

    def _extract_yaml(self, response: str) -> str:
        """AI応答からYAMLを抽出"""
        # コードブロックから抽出
        if "```yaml" in response:
            start = response.index("```yaml") + 7
            end = response.index("```", start)
            return response[start:end].strip()
        elif "```" in response:
            start = response.index("```") + 3
            end = response.index("```", start)
            return response[start:end].strip()
        else:
            return response.strip()
```

---

## 📋 テスト計画

### test/test_phase4_2_sharing.py

```python
"""
Phase 4.2テスト: ルール共有機能

@perfect品質保証:
- ルールエクスポート
- ルールインポート
- パッケージ作成・インストール
"""

import unittest
from pathlib import Path
import shutil
import json
import yaml

from core.rule_sharing import RuleExporter, RuleImporter


class TestRuleSharing(unittest.TestCase):
    """ルール共有機能のテスト"""

    def setUp(self):
        """テストセットアップ"""
        self.test_dir = Path("test/fixtures/sharing-test")
        self.test_dir.mkdir(parents=True, exist_ok=True)

        # テストルール作成
        self.test_rule_file = self.test_dir / "test-rule.yml"
        rule_content = """
rule:
  id: "TEST_EXPORT"
  category: "custom"
  name: "Test Export Rule"
  description: "Test rule for export functionality"
  base_severity: 7

  patterns:
    csharp:
      - pattern: 'TestPattern'
        context: "Test context"
"""
        with open(self.test_rule_file, 'w', encoding='utf-8') as f:
            f.write(rule_content)

    def tearDown(self):
        """テストクリーンアップ"""
        if self.test_dir.exists():
            shutil.rmtree(self.test_dir)

    def test_export_yaml(self):
        """YAMLエクスポートテスト"""
        exporter = RuleExporter()
        result = exporter.export_rule(self.test_rule_file, output_format='yaml')

        self.assertIn('TEST_EXPORT', result)
        self.assertIn('Test Export Rule', result)
        print("✅ YAMLエクスポート成功")

    def test_export_json(self):
        """JSONエクスポートテスト"""
        exporter = RuleExporter()
        result = exporter.export_rule(self.test_rule_file, output_format='json')

        data = json.loads(result)
        self.assertEqual(data['rule']['id'], 'TEST_EXPORT')
        print("✅ JSONエクスポート成功")

    def test_import_rule(self):
        """ルールインポートテスト"""
        # まずエクスポート
        exporter = RuleExporter()
        exported = exporter.export_rule(self.test_rule_file, output_format='yaml')

        # インポート
        importer = RuleImporter()
        output_dir = self.test_dir / "imported"
        imported_file = importer.import_rule(exported, output_dir)

        self.assertIsNotNone(imported_file)
        self.assertTrue(imported_file.exists())
        print(f"✅ ルールインポート成功: {imported_file}")

    def test_package_creation(self):
        """パッケージ作成テスト"""
        exporter = RuleExporter()
        package_file = exporter.export_rule_package(
            [self.test_rule_file],
            "test-package",
            self.test_dir
        )

        self.assertTrue(package_file.exists())

        # パッケージ内容確認
        with open(package_file, 'r', encoding='utf-8') as f:
            data = json.load(f)
            self.assertEqual(data['package']['name'], 'test-package')
            self.assertEqual(len(data['package']['rules']), 1)

        print("✅ パッケージ作成成功")


class TestRuleMetrics(unittest.TestCase):
    """ルールメトリクステスト"""

    def setUp(self):
        """テストセットアップ"""
        self.test_dir = Path("test/fixtures/metrics-test")
        self.test_dir.mkdir(parents=True, exist_ok=True)
        self.metrics_file = self.test_dir / "metrics.json"

    def tearDown(self):
        """テストクリーンアップ"""
        if self.test_dir.exists():
            shutil.rmtree(self.test_dir)

    def test_metrics_collection(self):
        """メトリクス収集テスト"""
        from core.rule_metrics import RuleMetricsCollector

        collector = RuleMetricsCollector(self.metrics_file)

        # 検出を記録
        collector.record_detection("TEST_RULE", "test.cs", 10.5)
        collector.record_detection("TEST_RULE", "test2.cs", 12.3)

        # メトリクス確認
        metric = collector.get_metrics("TEST_RULE")
        self.assertIsNotNone(metric)
        self.assertEqual(metric.total_detections, 2)

        print("✅ メトリクス収集成功")

    def test_false_positive_tracking(self):
        """誤検知追跡テスト"""
        from core.rule_metrics import RuleMetricsCollector

        collector = RuleMetricsCollector(self.metrics_file)

        # 検出と誤検知を記録
        collector.record_detection("TEST_RULE", "test.cs", 10.0)
        collector.record_detection("TEST_RULE", "test2.cs", 10.0)
        collector.record_false_positive("TEST_RULE")

        # 誤検知率確認
        fp_rate = collector.get_false_positive_rate("TEST_RULE")
        self.assertAlmostEqual(fp_rate, 0.5, places=2)

        print("✅ 誤検知追跡成功")
```

---

## 📅 実装スケジュール

### Day 1-2: ルール共有機能実装
- RuleExporter実装
- RuleImporter実装
- パッケージ機能実装

### Day 3: メトリクス機能実装
- RuleMetricsCollector実装
- メトリクスレポート機能
- CLI統合

### Day 4-5: AI支援機能実装
- AIRuleGenerator実装
- AI API統合
- CLI統合

### Day 6: テスト・統合
- テストケース作成
- 統合テスト実行
- バグ修正

### Day 7: ドキュメント整備
- 使用ガイド作成
- README更新
- コミット・プッシュ

**合計**: 約7日間（実稼働）

---

## 🎯 成功基準

### 必須条件
- [ ] ルールのエクスポート/インポートが正常動作
- [ ] パッケージ作成・インストールが正常動作
- [ ] メトリクス収集が正確に動作
- [ ] AI生成が実用的なルールを生成
- [ ] 全テスト合格

### 品質基準
- [ ] @perfect品質達成 (全テスト100%合格)
- [ ] コーディング規約準拠
- [ ] 適切なエラーハンドリング
- [ ] セキュアなファイル操作

### ドキュメント基準
- [ ] 使用ガイド完備
- [ ] APIドキュメント整備
- [ ] トラブルシューティングガイド

---

## 🔄 Phase 4.3への展望

Phase 4.2完了後、Phase 4.3では以下を検討：

1. **ルールの視覚化**
   - ルール関係図の自動生成
   - メトリクスダッシュボード
   - インタラクティブなルールエディタ

2. **高度な分析機能**
   - 複数ルールの組み合わせ検出
   - コードクローン検出
   - アーキテクチャパターン検証

3. **CI/CD統合強化**
   - GitHub Actions統合
   - GitLab CI統合
   - 自動プルリクエスト生成

---

*最終更新: 2025年10月12日 JST*
*Phase 4.2実装期間: 2025年10月12日 (開始)*
*バージョン: v4.5.0 (Phase 4.2開始)*

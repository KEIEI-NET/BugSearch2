# テストコード作成ガイドライン

## 📁 テストコードの配置場所

**すべての新規テストコードは `test/` フォルダー内に作成すること**

```
test/
├── test_*.py                 # 単体テスト
├── benchmark_*.py            # パフォーマンステスト
├── monitor_*.py              # モニタリングツール
└── sample*.{py,js,go,php}   # テスト用サンプルファイル
```

## 📝 命名規則

### テストファイル
- **単体テスト**: `test_<機能名>.py`
  - 例: `test_encoding.py`, `test_severity_scoring.py`
- **統合テスト**: `test_<システム名>_integration.py`
  - 例: `test_ai_analysis_integration.py`
- **APIテスト**: `test_<API名>_api.py`
  - 例: `test_gpt5_api.py`, `test_openai_api.py`
- **パフォーマンステスト**: `benchmark_<機能名>.py`
  - 例: `benchmark_parallel.py`, `benchmark_indexing.py`
- **モニタリング**: `monitor_<対象>.py`
  - 例: `monitor_parallel.py`, `monitor_api_usage.py`

### サンプルファイル
- **テストデータ**: `sample<番号>.<拡張子>`
  - 例: `sample1.py`, `sample2.js`, `sample_vulnerable.php`

## 🧪 テストコードの構造

### 基本テンプレート
```python
#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
test_<機能名>.py - <機能名>のテストコード

テスト対象: <対象ファイル名>
作成日: YYYY-MM-DD
"""
import unittest
import sys
from pathlib import Path

# プロジェクトルートをパスに追加
sys.path.insert(0, str(Path(__file__).parent.parent))

# テスト対象のインポート
from <対象モジュール> import <対象関数/クラス>


class Test<機能名>(unittest.TestCase):
    """<機能名>のテストケース"""

    def setUp(self):
        """テスト前の準備"""
        pass

    def tearDown(self):
        """テスト後のクリーンアップ"""
        pass

    def test_<テストケース名>(self):
        """<テストの説明>"""
        # Arrange（準備）

        # Act（実行）

        # Assert（検証）
        pass


if __name__ == '__main__':
    unittest.main()
```

## 🎯 テストの種類と目的

### 1. 単体テスト (test_*.py)
- **目的**: 個別の関数/メソッドの動作確認
- **対象**:
  - エンコーディング検出機能
  - 重要度スコア計算
  - ファイルフィルタリング
  - 正規表現パターンマッチング
- **実行**: `python -m unittest test/<テストファイル名>.py`

### 2. 統合テスト (test_*_integration.py)
- **目的**: モジュール間の連携確認
- **対象**:
  - インデックス作成→ベクトル化→クエリ の一連の流れ
  - AI分析の全体フロー
  - 並列処理の動作確認
- **実行**: `python test/<テストファイル名>.py`

### 3. APIテスト (test_*_api.py)
- **目的**: 外部API（OpenAI等）との連携確認
- **対象**:
  - GPT-5-Codex API呼び出し
  - レスポンス解析
  - エラーハンドリング
  - リトライ機能
- **注意**: `.env`の`OPENAI_API_KEY`が必要
- **実行**: `python test/<テストファイル名>.py`

### 4. パフォーマンステスト (benchmark_*.py)
- **目的**: 処理速度、メモリ使用量の測定
- **対象**:
  - 並列処理のスループット
  - インデックス作成速度
  - キャッシュ効率
- **実行**: `python test/benchmark_<テストファイル名>.py`

### 5. モニタリングツール (monitor_*.py)
- **目的**: 長時間実行処理の監視
- **対象**:
  - 並列AI分析の進捗
  - API使用状況
  - エラー発生率
- **実行**: `python test/monitor_<テストファイル名>.py`

## 📊 既存テストファイル一覧

### APIテスト
- `test_gpt5.py` - GPT-5基本動作確認
- `test_gpt5_codex.py` - GPT-5-Codex動作確認
- `test_gpt5_codex_official.py` - GPT-5-Codex公式実装テスト
- `test_api_simple.py` - シンプルなAPI呼び出しテスト
- `test_empty_response_fix.py` - 空レスポンス対策テスト

### 機能テスト
- `test_language_patterns.py` - 言語パターン検出テスト
- `test_enhanced_format.py` - 拡張フォーマットテスト
- `test_parallel.py` - 並列処理テスト

### ツール
- `benchmark_parallel.py` - 並列処理ベンチマーク
- `monitor_parallel.py` - 並列処理モニタリング

### サンプルファイル
- `sample1.py` - Pythonテストサンプル
- `sample2.js` - JavaScriptテストサンプル
- `sample3.go` - Goテストサンプル

## ✅ テスト作成のベストプラクティス

### 1. テストは独立させる
```python
# ❌ 悪い例：前のテストに依存
def test_step1(self):
    self.data = create_data()

def test_step2(self):
    result = process(self.data)  # test_step1に依存

# ✅ 良い例：各テストで準備
def test_step1(self):
    data = create_data()
    # テスト実行

def test_step2(self):
    data = create_data()  # 自己完結
    result = process(data)
```

### 2. モックを活用する
```python
from unittest.mock import patch, MagicMock

class TestAIAnalysis(unittest.TestCase):
    @patch('openai.OpenAI')
    def test_ai_call(self, mock_openai):
        # OpenAI APIをモック化
        mock_client = MagicMock()
        mock_openai.return_value = mock_client

        # テスト実行（実際のAPI呼び出しなし）
```

### 3. エッジケースをテストする
```python
def test_edge_cases(self):
    # 空文字列
    self.assertEqual(process(""), expected_empty)

    # 巨大ファイル
    large_content = "x" * 10_000_000
    self.assertIsNotNone(process(large_content))

    # 特殊文字
    special = "日本語\n\t\\特殊文字"
    self.assertIsNotNone(process(special))
```

### 4. テストにドキュメントを含める
```python
def test_severity_calculation(self):
    """
    重要度スコア計算のテスト

    検証項目:
    - N+1問題: スコア10
    - SELECT *: スコア8
    - 問題なし: スコア0
    """
    # テスト実装
```

## 🚀 テスト実行方法

### すべてのテストを実行
```bash
python -m unittest discover test/
```

### 特定のテストファイルを実行
```bash
python -m unittest test.test_encoding
```

### 特定のテストケースを実行
```bash
python -m unittest test.test_encoding.TestEncodingDetection.test_shift_jis
```

### カバレッジ測定（推奨）
```bash
pip install coverage
coverage run -m unittest discover test/
coverage report
coverage html  # HTMLレポート生成
```

## 🔧 トラブルシューティング

### インポートエラー
```python
# プロジェクトルートをパスに追加
import sys
from pathlib import Path
sys.path.insert(0, str(Path(__file__).parent.parent))
```

### 環境変数が必要なテスト
```python
import os
from dotenv import load_dotenv

class TestAPIIntegration(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        load_dotenv()
        if not os.getenv('OPENAI_API_KEY'):
            raise unittest.SkipTest('OPENAI_API_KEY not set')
```

## 📌 チェックリスト

新規テストコード作成時:
- [ ] `test/` フォルダーに配置
- [ ] 適切な命名規則を使用
- [ ] docstringで目的を明記
- [ ] setUpとtearDownで準備・後処理
- [ ] 独立したテストケース
- [ ] エッジケースを含める
- [ ] モックで外部依存を削減
- [ ] 実行して成功を確認

## 最終更新
2025-10-01

# GUI Production v1.0.0 ユーザーガイド

*バージョン: v1.0.0 (本番環境推奨版)*  
*最終更新: 2025年10月21日*  
*作成者: KEIEI.NET INC.*

## 概要

BugSearch2 GUI Production v1.0.0は、34,125ファイルの処理成功実績を持つ、本番環境で動作保証されたGUIアプリケーションです。シンプルで信頼性の高い設計により、初心者でも簡単に高度なコード解析を実行できます。

## 🚀 クイックスタート

### 起動方法

#### Windows
```bash
# ダブルクリックで起動
start_gui.bat

# またはコマンドラインから
python gui_production.py
```

#### macOS/Linux
```bash
# 実行権限を付与（初回のみ）
chmod +x start_gui.sh

# 起動
./start_gui.sh

# またはコマンドラインから
python gui_production.py
```

### 初回セットアップ

1. **依存パッケージのインストール**
   ```bash
   pip install customtkinter
   ```

2. **環境変数の設定**
   ```bash
   cp .env.example .env
   # .envファイルを編集してAPIキーを設定
   ```

3. **起動確認**
   - GUIが起動し、3つのタブが表示されることを確認

## 📊 実績とパフォーマンス

### 動作保証環境
- **テスト済みファイル数**: 34,125ファイル
- **処理時間**: 5分52秒
- **平均速度**: 97 files/sec
- **エラー率**: 0%
- **メモリ使用**: 最大512MB

### 対応OS
- Windows 10/11
- macOS 12以降
- Ubuntu 20.04以降

## 🖥️ GUI機能詳細

### メインウィンドウ

```
┌─────────────────────────────────────────┐
│  BugSearch2 GUI Production v1.0.0       │
├─────────────────────────────────────────┤
│ [Index] [Advise] [Query]                │
├─────────────────────────────────────────┤
│                                         │
│  現在のタブの内容が表示されます         │
│                                         │
└─────────────────────────────────────────┘
```

### 1. Indexタブ - インデックス作成

#### 機能
ソースコードファイルを解析し、検索可能なインデックスを作成します。

#### 使い方
1. **ソースディレクトリ選択**
   - 「Browse」ボタンをクリック
   - 解析したいプロジェクトフォルダを選択

2. **オプション設定**
   - **Max file size (MB)**: 解析する最大ファイルサイズ（デフォルト: 4MB）
   - **Worker count**: 並列処理ワーカー数（デフォルト: 4）
   - **Exclude languages**: 除外する言語（カンマ区切り）

3. **実行**
   - 「Index作成」ボタンをクリック
   - プログレスバーで進捗を確認
   - ファイル数カウンター: `12,500 / 34,125 files`
   - 処理速度表示: `97 files/sec`
   - 残り時間表示: `残り 3分15秒`

#### 出力
- `.advice_index.jsonl` - インデックスファイル
- `.advice_index.meta.json` - メタデータ

### 2. Adviseタブ - AI分析実行

#### 機能
インデックス化されたファイルに対してAI分析を実行し、問題点と改善提案を生成します。

#### 使い方
1. **分析オプション設定**
   - **All files**: すべてのファイルを分析（推奨）
   - **Complete report**: AI改善コード付き完全レポート
   - **Max items**: 完全レポートの最大項目数（デフォルト: 100）

2. **出力設定**
   - **Output directory**: レポート出力先
   - デフォルト: `reports/`

3. **実行**
   - 「分析開始」ボタンをクリック
   - リアルタイムログで進捗確認
   - 準備中メッセージ表示
     - "プロジェクトを解析中..."
     - "ファイルをスキャン中..."
     - "分析エンジンを初期化中..."

#### 出力
- `reports/analysis_YYYYMMDD_HHMMSS.md` - 分析レポート
- 問題の深刻度スコア（1-10）
- AI生成の改善コード

### 3. Queryタブ - ファイル検索

#### 機能
インデックスから特定のファイルや内容を高速検索します。

#### 使い方
1. **検索条件入力**
   - **Search query**: 検索キーワード
   - **File pattern**: ファイル名パターン（例: `*.py`）
   - **Top K**: 表示する結果数（デフォルト: 20）

2. **実行**
   - 「検索」ボタンをクリック
   - 検索結果がリストで表示

3. **結果の活用**
   - ファイルパスをダブルクリックで開く
   - 関連度スコアで並び替え

## 📈 リアルタイム進捗表示

### 進捗情報の見方

```
処理中: 12,500 / 34,125 files
進捗: ████████░░░░░░░░ 36.6%
速度: 97 files/sec
残り時間: 3分45秒
```

### ログレベル

| レベル | 色 | 意味 |
|-------|-----|------|
| INFO | 白 | 通常情報 |
| SUCCESS | 緑 | 処理成功 |
| WARNING | オレンジ | 警告 |
| ERROR | 赤 | エラー |

## 🔧 トラブルシューティング

### よくある問題と解決方法

#### 1. GUIが起動しない

**原因**: CustomTkinterがインストールされていない

**解決**:
```bash
pip install customtkinter
```

#### 2. 進捗が更新されない

**原因**: unbuffered modeが無効

**解決**:
環境変数を設定
```bash
export PYTHONUNBUFFERED=1  # Linux/Mac
set PYTHONUNBUFFERED=1     # Windows
```

#### 3. メモリ不足エラー

**原因**: 大きなファイルの処理

**解決**:
- Max file sizeを小さく設定（例: 1MB）
- Worker countを減らす（例: 2）

#### 4. API応答タイムアウト

**原因**: AI APIの応答が遅い

**解決**:
- `batch_config.json`でタイムアウトを延長
  ```json
  {
    "timeout_per_file": 360
  }
  ```

### エラーメッセージ対処法

| エラー | 原因 | 対処法 |
|-------|------|--------|
| "Index not found" | インデックス未作成 | Indexタブで作成 |
| "API key not set" | APIキー未設定 | .envファイルを設定 |
| "File too large" | ファイルサイズ超過 | max-file-mb調整 |
| "Permission denied" | 権限不足 | 管理者権限で実行 |

## 💡 使用のコツ

### 効率的な使い方

1. **初回実行時**
   - まずIndexタブでインデックス作成
   - 次にAdviseタブで分析実行
   - 最後にQueryタブで結果確認

2. **大規模プロジェクト**
   - Worker countを増やす（CPU数-1推奨）
   - Complete reportは必要な範囲に限定

3. **定期実行**
   - 変更ファイルのみ再インデックス
   - 差分解析で時間短縮

### ベストプラクティス

1. **APIキー管理**
   - 複数のプロバイダーを設定
   - フォールバック機能を活用

2. **レポート管理**
   - 日付付きフォルダで整理
   - 重要な結果はバックアップ

3. **パフォーマンス最適化**
   - 不要な言語は除外
   - バイナリファイルは除外

## 📝 設定ファイル

### .env ファイル
```bash
# AI Provider設定
AI_PROVIDER=auto
OPENAI_API_KEY=your_openai_key
ANTHROPIC_API_KEY=your_anthropic_key

# モデル設定
OPENAI_MODEL=gpt-4o
ANTHROPIC_MODEL=claude-3-5-sonnet-20241022
```

### batch_config.json
```json
{
  "parallel_config": {
    "parallel_workers": 10,
    "batch_size": 50,
    "timeout_per_file": 360
  }
}
```

### .bugsearch.yml
```yaml
tech_stack:
  frontend:
    - react
    - angular
  backend:
    - express
    - fastapi
  database:
    - postgresql
    - redis
```

## 🆘 サポート

### ドキュメント
- [技術仕様書](../TECHNICAL.md)
- [アーキテクチャ](../ARCHITECTURE.md)
- [開発履歴](../DEVELOPMENT.md)

### コミュニティ
- GitHub Issues: バグ報告・機能要望
- GitHub Discussions: 質問・議論

### 商用サポート
- KEIEI.NET INC.
- support@keiei.net

## 🎯 今後の機能追加予定

### v1.1.0（計画中）
- ダークモード対応
- 多言語UI
- エクスポート機能強化

### v1.2.0（構想）
- Web API連携
- クラウドストレージ対応
- チーム共有機能

---

*作成者: KEIEI.NET INC.*  
*最終更新: 2025年10月21日*  
*バージョン: v1.0.0*

**更新履歴:**
- v1.0.0 (2025年10月21日): 初版リリース、本番環境動作保証
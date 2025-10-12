# Flask環境セットアップガイド

**バージョン**: v4.7.0
**最終更新**: 2025-10-12
**対象**: Phase 6 - チームダッシュボード機能

## 概要

Phase 6のチーム協業機能を使用するには、Flaskとその関連パッケージが必要です。このガイドでは、Flask環境のセットアップ手順を説明します。

## 必要なパッケージ

### Phase 5 + Phase 6の依存パッケージ

```txt
# Phase 5: Real-time Analysis (v4.6.0)
watchdog>=4.0.0  # File system monitoring for watch mode
tqdm>=4.66.0     # Progress bar for better UX

# Phase 6: Team Collaboration (v4.7.0)
flask>=3.0.0     # Web UI and REST API for team dashboard
flask-cors>=4.0.0  # CORS support for API access
```

## インストール手順

### 方法1: requirements.txtを使用（推奨）

```bash
# プロジェクトルートディレクトリで実行
pip install -r requirements.txt
```

### 方法2: 個別インストール

```bash
# Phase 5 + Phase 6のパッケージをインストール
pip install flask>=3.0.0 flask-cors>=4.0.0 watchdog>=4.0.0 tqdm>=4.66.0
```

### 方法3: 最小構成（Phase 6のみ）

```bash
# チームダッシュボードのみ使用する場合
pip install flask>=3.0.0
```

## インストール確認

### 1. パッケージバージョンの確認

```bash
pip list | findstr "flask watchdog tqdm"
```

**期待される出力:**
```
Flask              3.0.0
flask-cors         4.0.0
watchdog           4.0.0
tqdm               4.66.0
```

### 2. インポートテスト

```bash
python -c "import flask; print(f'Flask {flask.__version__} installed successfully')"
```

**期待される出力:**
```
Flask 3.0.0 installed successfully
```

### 3. Phase 6テストの実行

```bash
python test/test_phase6_team.py
```

**期待される出力:**
```
================================================================================
📊 Phase 6テスト結果サマリー
================================================================================
実行したテスト: 14
成功: 14
失敗: 0
エラー: 0
スキップ: 0

✅ 全てのテストが合格しました！ (@perfect品質達成)
```

## チームダッシュボードの起動

### 開発サーバーの起動

```bash
python dashboard/team_dashboard.py
```

**出力例:**
```
 * Serving Flask app 'team_dashboard'
 * Debug mode: on
WARNING: This is a development server. Do not use it in a production deployment.
 * Running on http://127.0.0.1:5000
```

### ブラウザでアクセス

```
http://localhost:5000
```

## トラブルシューティング

### エラー: ModuleNotFoundError: No module named 'flask'

**原因:** Flaskがインストールされていない

**解決策:**
```bash
pip install flask>=3.0.0
```

### エラー: ImportError: cannot import name 'Flask' from 'flask'

**原因:** Flaskのバージョンが古い

**解決策:**
```bash
pip install --upgrade flask>=3.0.0
```

### エラー: Address already in use (ポート5000が使用中)

**原因:** 別のプロセスがポート5000を使用している

**解決策1: 別のポートを使用**
```python
# dashboard/team_dashboard.py の最終行を変更
app.run(debug=True, port=5001)  # ポート5001を使用
```

**解決策2: 使用中のプロセスを終了**
```bash
# Windows
netstat -ano | findstr :5000
taskkill /PID <プロセスID> /F
```

### テストがスキップされる（Flask未インストール）

**症状:**
```
⚠️ Flask未インストール（スキップ）
   インストール: pip install flask
```

**解決策:**
```bash
pip install flask>=3.0.0
python test/test_phase6_team.py
```

## Python仮想環境の使用（推奨）

### 仮想環境の作成と有効化

```bash
# 仮想環境の作成
python -m venv venv

# 有効化（Windows）
venv\Scripts\activate

# 有効化（Mac/Linux）
source venv/bin/activate

# パッケージのインストール
pip install -r requirements.txt
```

### 仮想環境の無効化

```bash
deactivate
```

## 本番環境デプロイ（参考）

### 本番用WSGIサーバーの使用

Flaskの開発サーバーは本番環境では使用しないでください。代わりにGunicornやuWSGIを使用してください。

```bash
# Gunicornのインストール
pip install gunicorn

# 起動
gunicorn -w 4 -b 0.0.0.0:5000 dashboard.team_dashboard:app
```

### 環境変数の設定

```bash
# 本番環境では.envファイルまたは環境変数で設定
export FLASK_ENV=production
export FLASK_DEBUG=False
```

## Phase 6機能の概要

### REST APIエンドポイント

| エンドポイント | メソッド | 説明 |
|------------|--------|------|
| `/` | GET | メインダッシュボードページ |
| `/api/stats` | GET | 統計データ取得 |
| `/api/progress` | GET | 進捗データ取得（期間指定可能） |
| `/api/compare` | POST | レポート比較API |
| `/api/reports` | GET | レポート一覧取得 |
| `/health` | GET | ヘルスチェック |

### 使用例

```bash
# ヘルスチェック
curl http://localhost:5000/health

# 統計データ取得
curl http://localhost:5000/api/stats

# 進捗データ取得（30日間）
curl "http://localhost:5000/api/progress?days=30"
```

## よくある質問（FAQ）

### Q1: Flaskは必須ですか？

**A:** Phase 6のチームダッシュボード機能を使用する場合のみ必須です。Phase 5以前の機能（静的解析、AI分析、リアルタイム解析）は、Flask不要で動作します。

### Q2: flask-corsは何のために必要ですか？

**A:** 外部のフロントエンドアプリケーションからAPIにアクセスする場合に必要です。単体で使用する場合は不要です。

### Q3: Python 3.13でインストールできますか？

**A:** はい、Flask 3.0.0はPython 3.13に対応しています。ただし、scikit-learnのインストール時は以下のコマンドを使用してください：

```bash
pip install --only-binary :all: scikit-learn
```

### Q4: 既存の環境にFlaskを追加しても大丈夫ですか？

**A:** はい、Flaskは既存の依存パッケージと競合しません。安全に追加できます。

## 関連ドキュメント

- [TECHNICAL.md](../TECHNICAL.md) - 技術仕様書
- [DEVELOPMENT.md](../DEVELOPMENT.md) - 開発履歴
- [TEST_RESULTS.md](../TEST_RESULTS.md) - テスト結果
- [CLAUDE.md](../../CLAUDE.md) - プロジェクト概要

## サポート

問題が発生した場合は、以下を確認してください：

1. Python 3.11以上がインストールされているか
2. pipが最新版か（`pip install --upgrade pip`）
3. requirements.txtが最新版（v4.7.0）か
4. 仮想環境を使用しているか

---

**最終更新**: 2025-10-12
**バージョン**: v4.7.0 (Phase 6)
**ステータス**: @perfect品質達成

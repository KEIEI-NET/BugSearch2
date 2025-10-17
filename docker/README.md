# BugSearch2 Docker 実行ガイド

*バージョン: v1.0.0*
*最終更新: 2025年10月13日*

## 📚 概要

BugSearch2をDockerコンテナで実行するための完全ガイドです。全OS（Windows/Mac/Linux）で動作します。

**提供されるDockerイメージ:**
- **CLI版** (`Dockerfile`): コマンドライン版、軽量
- **GUI版** (`Dockerfile.gui`): GUI Control Center、X11フォワーディング対応

---

## 🚀 クイックスタート

### 前提条件

- Docker Desktop インストール済み（[公式サイト](https://www.docker.com/products/docker-desktop)）
- docker-compose インストール済み（Docker Desktop に含まれる）

### 1. 環境変数設定

```bash
# .envファイルを作成
cp .env.example .env

# .envファイルを編集してAPIキーを設定
# OPENAI_API_KEY=your_actual_key_here
# ANTHROPIC_API_KEY=your_actual_key_here
```

### 2. CLI版の起動（推奨）

```bash
# イメージビルド + コンテナ起動
docker-compose up -d bugsearch-cli

# コンテナ内でシェルを起動
docker-compose exec bugsearch-cli /bin/bash

# BugSearch2コマンド実行
python codex_review_severity.py index
python codex_review_severity.py advise --all --out reports/analysis
```

### 3. GUI版の起動（OS別手順が必要）

```bash
# イメージビルド + コンテナ起動
docker-compose up -d bugsearch-gui

# 注意: GUIを表示するにはOS別のX11設定が必要（後述）
```

---

## 🖥️ OS別セットアップ手順

### Linux

最もシンプルです。

```bash
# X11接続を許可
xhost +local:docker

# GUIコンテナ起動
docker-compose up -d bugsearch-gui

# ログ確認
docker-compose logs -f bugsearch-gui

# 終了時
xhost -local:docker
```

**トラブルシューティング（Linux）:**
```bash
# DISPLAYが設定されているか確認
echo $DISPLAY  # 通常は :0 または :1

# Xauthorityファイルのパス確認
echo $XAUTHORITY  # 通常は /home/username/.Xauthority
```

### macOS

X11サーバー（XQuartz）のインストールが必要です。

**1. XQuartzインストール:**
```bash
# Homebrewでインストール
brew install --cask xquartz

# または公式サイトからダウンロード
# https://www.xquartz.org/
```

**2. XQuartz設定:**
```bash
# XQuartzを起動（アプリケーション → ユーティリティ → XQuartz）

# XQuartz設定を開く（メニュー: XQuartz → Preferences）
# 「Security」タブで以下を有効化:
# ✓ "Allow connections from network clients"

# XQuartzを再起動
```

**3. X11接続許可:**
```bash
# IPアドレス取得
IP=$(ifconfig en0 | grep inet | awk '$1=="inet" {print $2}')

# Docker接続を許可
xhost + $IP

# .envファイル編集
# DISPLAY=host.docker.internal:0
```

**4. docker-compose.yml編集（macOS用）:**
```yaml
# bugsearch-gui サービスの network_mode をコメントアウト
services:
  bugsearch-gui:
    # network_mode: host  # ← コメントアウト
```

**5. GUIコンテナ起動:**
```bash
docker-compose up -d bugsearch-gui
docker-compose logs -f bugsearch-gui
```

### Windows

X11サーバー（Xming または VcXsrv）のインストールが必要です。

**Option 1: VcXsrv（推奨）**

**1. VcXsrvインストール:**
```powershell
# Chocolateyでインストール（推奨）
choco install vcxsrv

# または公式サイトからダウンロード
# https://sourceforge.net/projects/vcxsrv/
```

**2. VcXsrv起動:**
```
スタートメニュー → VcXsrv → XLaunch

設定:
1. "Multiple windows" を選択 → Next
2. "Start no client" を選択 → Next
3. ✓ "Disable access control" にチェック → Next
4. Finish
```

**3. .envファイル編集（Windows用）:**
```ini
# DISPLAY設定（Windows）
DISPLAY=host.docker.internal:0.0

# XAUTHORITYはコメントアウト
# XAUTHORITY=$HOME/.Xauthority
```

**4. docker-compose.yml編集（Windows用）:**
```yaml
services:
  bugsearch-gui:
    # network_mode: host  # ← コメントアウト

    # Windowsホストアクセス用
    extra_hosts:
      - "host.docker.internal:host-gateway"
```

**5. GUIコンテナ起動:**
```powershell
docker-compose up -d bugsearch-gui
docker-compose logs -f bugsearch-gui
```

**Option 2: Xming**

VcXsrvとほぼ同様の手順です。Xming起動時に「-ac」オプション（アクセス制御無効化）を指定してください。

---

## 📦 Docker Compose コマンド集

### ビルド

```bash
# すべてのサービスをビルド
docker-compose build

# 特定のサービスのみビルド
docker-compose build bugsearch-cli
docker-compose build bugsearch-gui

# キャッシュなしでビルド
docker-compose build --no-cache
```

### 起動・停止

```bash
# バックグラウンドで起動
docker-compose up -d bugsearch-cli

# フォアグラウンドで起動（ログを表示）
docker-compose up bugsearch-cli

# 停止
docker-compose stop bugsearch-cli

# 停止 + コンテナ削除
docker-compose down

# 停止 + コンテナ削除 + ボリューム削除（警告: データが消えます）
docker-compose down -v
```

### ログ確認

```bash
# すべてのサービスのログ
docker-compose logs -f

# 特定のサービスのログ
docker-compose logs -f bugsearch-cli
docker-compose logs -f bugsearch-gui

# 最新100行のみ表示
docker-compose logs --tail=100 bugsearch-cli
```

### コンテナ内でコマンド実行

```bash
# インタラクティブシェル起動
docker-compose exec bugsearch-cli /bin/bash

# 一回だけコマンド実行
docker-compose exec bugsearch-cli python codex_review_severity.py index

# ワンライナーで複数コマンド実行
docker-compose exec bugsearch-cli bash -c "cd /app && python codex_review_severity.py index && python codex_review_severity.py advise --all"
```

---

## 📁 ボリュームマウント

以下のディレクトリ/ファイルがホスト↔コンテナ間で共有されます。

| ホストパス | コンテナパス | 説明 |
|---------|-----------|------|
| `./src` | `/app/src` | 分析対象ソースコード（読み取り専用推奨） |
| `./reports` | `/app/reports` | 生成されたレポート |
| `./.cache` | `/app/.cache` | AI応答キャッシュ |
| `./backups` | `/app/backups` | バックアップファイル |
| `./.bugsearch.yml` | `/app/.bugsearch.yml` | プロジェクト設定 |
| `./.bugsearch/` | `/app/.bugsearch/` | カスタムルール |
| `./.advice_index.jsonl` | `/app/.advice_index.jsonl` | インデックスファイル |

**データ永続化:**
コンテナを削除しても、これらのファイル/ディレクトリはホスト側に残ります。

---

## 🔧 よくあるトラブルシューティング

### 1. GUIが表示されない

**原因と対処:**

```bash
# X11サーバーが起動しているか確認
# Linux: ps aux | grep X
# Mac: ps aux | grep XQuartz
# Windows: タスクマネージャーで VcXsrv.exe を確認

# ファイアウォールがX11ポート（6000番）をブロックしていないか確認

# コンテナ内でX11接続テスト
docker-compose exec bugsearch-gui xdpyinfo -display $DISPLAY

# エラーが出る場合は、DISPLAY変数を確認
docker-compose exec bugsearch-gui echo $DISPLAY
```

### 2. Permission Denied エラー

```bash
# ホスト側のディレクトリ権限確認
ls -la ./src ./reports ./.cache

# 必要に応じて権限変更
chmod -R 755 ./src
chmod -R 777 ./reports ./.cache ./backups
```

### 3. APIキーが認識されない

```bash
# .envファイルが存在するか確認
ls -la .env

# .envファイル内容確認（キーが設定されているか）
cat .env | grep API_KEY

# コンテナ再起動（環境変数を再読込）
docker-compose down
docker-compose up -d bugsearch-cli
```

### 4. ビルドエラー

```bash
# Dockerキャッシュクリア
docker-compose build --no-cache

# 古いイメージ削除
docker image prune -a

# Docker Desktopを再起動
```

---

## 🎯 実用例

### 例1: 新規プロジェクトの完全分析

```bash
# 1. 環境準備
cp .env.example .env
# .envを編集してAPIキー設定

# 2. コンテナ起動
docker-compose up -d bugsearch-cli

# 3. シェルに入る
docker-compose exec bugsearch-cli bash

# 4. 分析実行
python codex_review_severity.py index
python codex_review_severity.py advise --complete-all --out reports/full_analysis

# 5. レポート確認（ホスト側）
# exit コマンドでシェルを抜けて
cat reports/full_analysis.md
```

### 例2: GUI版で対話的に分析

```bash
# 1. X11サーバー起動（OS別手順参照）

# 2. GUIコンテナ起動
docker-compose up -d bugsearch-gui

# 3. ログでGUI起動確認
docker-compose logs -f bugsearch-gui

# 4. GUIウィンドウが表示される
# （表示されない場合はトラブルシューティング参照）
```

### 例3: CI/CDパイプラインでの使用

```yaml
# .gitlab-ci.yml または .github/workflows/analyze.yml
stages:
  - analyze

code_review:
  stage: analyze
  image: bugsearch2:cli-v4.11.2
  services:
    - docker:dind
  script:
    - python codex_review_severity.py index
    - python codex_review_severity.py advise --all --out reports/ci_analysis
  artifacts:
    paths:
      - reports/
    expire_in: 1 week
```

---

## 🔗 関連ドキュメント

- [BugSearch2 README](../README.md)
- [CLAUDE.md（開発者向け）](../CLAUDE.md)
- [GUI User Guide](../doc/guides/GUI_USER_GUIDE.md)
- [Technical Specifications](../doc/TECHNICAL.md)

---

## 🆘 サポート

問題が発生した場合:

1. このREADMEの「トラブルシューティング」セクションを確認
2. GitHubでissueを作成: `KEIEI-NET/BugSearch2`
3. 以下の情報を含めてください:
   - OS（Windows/Mac/Linux）とバージョン
   - Docker/docker-composeバージョン（`docker --version`, `docker-compose --version`）
   - エラーメッセージ全文
   - `docker-compose logs` の出力

---

*最終更新: 2025年10月13日*
*バージョン: v1.0.0*

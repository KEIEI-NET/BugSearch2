# BugSearch2 - CLI版 Dockerfile
# Version: v1.0.0
# Python 3.11+ 対応
# 全OS対応（Windows/Mac/Linux）

FROM python:3.11-slim

# メンテナ情報
LABEL maintainer="BugSearch2 Team"
LABEL description="BugSearch2 Static Code Analyzer & AI Review System (CLI)"
LABEL version="4.11.2"

# 環境変数
ENV PYTHONUNBUFFERED=1 \
    PYTHONDONTWRITEBYTECODE=1 \
    PIP_NO_CACHE_DIR=1 \
    PIP_DISABLE_PIP_VERSION_CHECK=1 \
    DEBIAN_FRONTEND=noninteractive

# 作業ディレクトリ作成
WORKDIR /app

# システム依存パッケージのインストール
# - git: 技術スタック検出とdiff解析に必要
# - gcc/g++: scikit-learnビルドに必要
# - libgomp1: scikit-learn実行時ライブラリ
RUN apt-get update && apt-get install -y --no-install-recommends \
    git \
    gcc \
    g++ \
    libgomp1 \
    && rm -rf /var/lib/apt/lists/*

# Python依存パッケージのインストール（レイヤーキャッシュ最適化）
COPY requirements.txt .
RUN pip install --no-cache-dir -r requirements.txt

# pyyamlの追加インストール（CLAUDE.md記載の依存関係）
RUN pip install --no-cache-dir pyyaml>=6.0.0

# アプリケーションコードのコピー
COPY . .

# 生成ファイル用ディレクトリの作成
RUN mkdir -p reports .cache backups .bugsearch/rules

# 実行権限付与（必要に応じて）
RUN chmod +x codex_review_severity.py apply_improvements_from_report.py

# ボリュームマウントポイント定義
VOLUME ["/app/src", "/app/reports", "/app/.cache", "/app/backups", "/app/.bugsearch"]

# ヘルスチェック（オプション）
HEALTHCHECK --interval=30s --timeout=10s --start-period=5s --retries=3 \
    CMD python -c "import sys; sys.exit(0)" || exit 1

# デフォルトコマンド（インタラクティブシェル）
CMD ["/bin/bash"]

@echo off
REM ========================================
REM BugSearch2 - 新PC セットアップスクリプト
REM Windows用
REM ========================================

echo.
echo ========================================
echo BugSearch2 新PC セットアップ
echo バージョン: v4.11.7
echo ========================================
echo.

REM 1. Git リポジトリの確認
echo [1/7] Git リポジトリの状態確認...
git status >nul 2>&1
if %errorlevel% neq 0 (
    echo エラー: Gitリポジトリが見つかりません
    echo このスクリプトをBugSearch2ディレクトリで実行してください
    pause
    exit /b 1
)

REM 最新状態に更新
echo [2/7] 最新状態に更新中...
git fetch KEIEI-NET
git checkout main
git pull KEIEI-NET main

REM コミットハッシュの確認
echo.
echo 現在のコミット:
git log --oneline -n 3
echo.

REM 2. Python バージョン確認
echo [3/7] Python バージョン確認...
python --version
if %errorlevel% neq 0 (
    echo エラー: Pythonが見つかりません
    echo Python 3.11以上をインストールしてください
    pause
    exit /b 1
)

REM 3. 仮想環境の作成
echo [4/7] 仮想環境の作成...
if exist venv (
    echo 仮想環境が既に存在します
) else (
    python -m venv venv
    echo 仮想環境を作成しました
)

REM 4. 仮想環境のアクティベート
echo [5/7] 仮想環境のアクティベート...
call venv\Scripts\activate.bat

REM 5. 依存パッケージのインストール
echo [6/7] 依存パッケージのインストール...
echo コアパッケージをインストール中...
pip install -r requirements.txt

echo.
echo GUIパッケージをインストール中...
pip install -r requirements_gui.txt

REM 6. .envファイルの確認
echo [7/7] .envファイルの確認...
if exist .env (
    echo .envファイルが存在します
) else (
    echo .envファイルが見つかりません
    echo .env.exampleから.envを作成します...
    copy .env.example .env
    echo.
    echo ========================================
    echo 重要: .envファイルを編集してAPIキーを設定してください
    echo ========================================
    echo.
    echo 必須設定:
    echo   OPENAI_API_KEY=sk-...
    echo   ANTHROPIC_API_KEY=sk-ant-...
    echo   AI_PROVIDER=auto
    echo.
    notepad .env
)

REM 7. 動作確認
echo.
echo ========================================
echo セットアップ完了！
echo ========================================
echo.
echo 次のステップ:
echo   1. .envファイルを編集してAPIキーを設定（まだの場合）
echo   2. 動作確認テストを実行
echo.
echo 動作確認コマンド:
echo   python codex_review_severity.py index --max-files 10
echo   python codex_review_severity.py advise --topk 3 --out reports/test
echo.
echo GUI起動:
echo   python gui_main.py
echo   または
echo   start_gui.bat
echo.
echo Phase 8.5 検証:
echo   python codex_review_severity.py advise --all --complete-report --max-complete-items 10 --out reports/phase8_5_verify
echo.
echo 詳細は HANDOFF.md を参照してください。
echo.

pause

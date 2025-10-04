# 複数PC環境 クイックスタートガイド

*v4.0.2 - Dropbox同期環境向け*

---

## 🚀 新しいPCで5分でセットアップ

**前提条件**: Claude Code CLI と Serena MCP が導入済み

### 1️⃣ Dropbox同期完了を確認（1分）

```bash
# Windows
cd "C:\Users\<ユーザー名>\Dropbox\AI開発\dev\Tools\サーチ"

# Mac/Linux
cd ~/Dropbox/AI開発/dev/Tools/サーチ
```

### 2️⃣ Pythonパッケージをインストール（2分）

```bash
pip install openai anthropic scikit-learn joblib chardet
```

### 3️⃣ Claude Code エイリアスをインストール（1分）

```bash
cd Install_PC

# Windows
install_windows.bat

# Mac/Linux
chmod +x install_unix.sh && ./install_unix.sh
```

### 4️⃣ 動作確認（1分）

```bash
# プロジェクトルートに戻る
cd ..

# ヘルプ表示
py codex_review_severity.py --help

# インデックスファイル確認（他のPCで作成済みの場合）
ls -lh .advice_index.jsonl
```

✅ これで完了！他のPCと同じ環境で作業開始できます。

---

## 📊 よくある作業パターン

### パターン1: 既存のインデックスを使って分析

```bash
# 他のPCで作成した .advice_index.jsonl が同期済みの場合
py codex_review_severity.py advise --topk 50 --out reports/my_analysis
```

### パターン2: このPCで新規インデックス作成

```bash
# 初めてこのPCで作業する場合
py codex_review_severity.py index --exclude-langs delphi --max-file-mb 4
py codex_review_severity.py advise --all --out reports/full_analysis
```

### パターン3: エイリアスを使った高品質開発

```bash
# Claude Code で以下のように指示
@perfect ユーザー認証機能を実装して
@validate apply_improvements_from_report.py
@tdd 決済処理ロジックを実装して
```

---

## 🔍 トラブルシューティング（1分チェック）

### ✓ インデックスファイルがない

```bash
# 再作成（数分かかります）
py codex_review_severity.py index --exclude-langs delphi
```

### ✓ APIキーエラー

```bash
# .env ファイルを確認
cat .env

# なければ作成
echo "OPENAI_API_KEY=sk-your-key-here" > .env
echo "ANTHROPIC_API_KEY=sk-ant-your-key-here" >> .env
```

### ✓ モジュールエラー

```bash
# 必須パッケージを再インストール
pip install openai anthropic scikit-learn joblib chardet
```

---

## 💡 Tips

### キャッシュを活用してAPI節約

`.cache/` ディレクトリがDropboxで同期されているため、他のPCで分析済みのファイルは即座に結果取得できます。

```bash
# キャッシュ状況確認
ls .cache/analysis/ | wc -l  # ファイル数
du -sh .cache/analysis/      # サイズ
```

### インデックスの共有

400MBの `.advice_index.jsonl` は1台で作成すれば、他のPCで再利用できます。

---

詳細は `SETUP_GUIDE_MULTI_PC.md` を参照してください。

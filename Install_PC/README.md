# Claude Code Aliases インストールガイド

*バージョン: v4.0.1*
*最終更新: 2025年01月04日*

このディレクトリには、Claude Code の品質ワークフローエイリアスを**グローバルに**インストールするためのファイルが含まれています。

---

## 📦 含まれるファイル

| ファイル | 説明 |
|---------|------|
| `aliases.md` | エイリアス定義ファイル（グローバル設定用） |
| `install_windows.bat` | Windowsインストーラー |
| `install_unix.sh` | Mac/Linuxインストーラー |
| `README.md` | このファイル |

---

## 🚀 インストール方法

### Windows

1. **管理者権限不要**で実行できます
2. `install_windows.bat` をダブルクリック
3. 完了メッセージを確認

```batch
cd Install_PC
install_windows.bat
```

**インストール先**:
```
%APPDATA%\claude-code\aliases.md
```

例: `C:\Users\YourName\AppData\Roaming\claude-code\aliases.md`

---

### Mac

1. ターミナルを開く
2. 以下を実行:

```bash
cd Install_PC
chmod +x install_unix.sh
./install_unix.sh
```

**インストール先**:
```
~/Library/Application Support/claude-code/aliases.md
```

---

### Linux

1. ターミナルを開く
2. 以下を実行:

```bash
cd Install_PC
chmod +x install_unix.sh
./install_unix.sh
```

**インストール先**:
```
~/.config/claude-code/aliases.md
```

---

## ✅ インストール後の確認

### Windows
```batch
type %APPDATA%\claude-code\aliases.md
```

### Mac/Linux
```bash
cat ~/Library/Application\ Support/claude-code/aliases.md  # Mac
cat ~/.config/claude-code/aliases.md  # Linux
```

---

## 🎯 使用方法

インストール後、Claude Code で以下のように使用できます:

```
@perfect ユーザー認証機能を実装して
```

### 利用可能なエイリアス

| エイリアス | 用途 | 品質レベル |
|-----------|------|-----------|
| `@perfect` | 完全品質保証（静的100点 + テスト100%） | ⭐⭐⭐⭐⭐ |
| `@tdd` | テスト駆動開発 | ⭐⭐⭐⭐⭐ |
| `@validate` | 既存コード検証 | ⭐⭐⭐⭐ |
| `@quick` | 高速プロトタイピング | ⭐ |

---

## 🔄 アップデート方法

新しいバージョンがリリースされた場合:

1. 最新の `Install_PC` ディレクトリを取得
2. インストーラーを再実行

**既存のaliases.mdは自動的にバックアップされます**:
- Windows: `aliases.md.backup_20250104_153045`
- Mac/Linux: `aliases.md.backup_20250104_153045`

---

## 🗑️ アンインストール方法

### Windows
```batch
del %APPDATA%\claude-code\aliases.md
```

### Mac
```bash
rm ~/Library/Application\ Support/claude-code/aliases.md
```

### Linux
```bash
rm ~/.config/claude-code/aliases.md
```

---

## 🔧 トラブルシューティング

### Q: インストーラーが失敗する

**Windows**:
```
[ERROR] インストールに失敗しました
エラーコード: 1
```

**解決策**:
1. `aliases.md` が存在するか確認
2. フォルダの権限を確認
3. 管理者権限で実行（通常は不要）

---

### Q: エイリアスが動作しない

**確認事項**:
1. Claude Code が最新版か確認
2. インストール先のパスが正しいか確認
3. Claude Code を再起動

**ファイル存在確認**:
```bash
# Windows
dir %APPDATA%\claude-code

# Mac/Linux
ls -la ~/.config/claude-code  # または ~/Library/Application\ Support/claude-code
```

---

### Q: 既存のカスタムエイリアスと競合する

**解決策**:
バックアップファイルから必要な部分を手動でマージ

```bash
# バックアップを確認
cat ~/.config/claude-code/aliases.md.backup_*

# 手動で編集
nano ~/.config/claude-code/aliases.md
```

---

## 📚 詳細ドキュメント

インストール後、各エイリアスの詳細は以下で確認できます:

```bash
# Windows
type %APPDATA%\claude-code\aliases.md

# Mac/Linux
cat ~/.config/claude-code/aliases.md
```

または、プロジェクトルートの `.claude/aliases.md` もご参照ください。

---

## 🎓 使用例

### 例1: 新機能開発
```
@perfect ユーザー登録APIエンドポイントを実装

要件:
- メールアドレス検証
- パスワード強度チェック
- 重複登録防止
```

**結果**:
- コード実装
- 静的解析100点
- テスト作成・実行（100%成功）
- コミット完了

---

### 例2: レガシーコード改善
```
@validate old_payment_system.py
```

**結果**:
- 品質スコア: 85/100 → 改善提案
- テスト作成（存在しない場合）
- テスト実行結果レポート

---

### 例3: プロトタイプ作成
```
@quick CSVから売上グラフを生成
```

**結果**:
- 素早く実装
- 品質チェックスキップ
- 動作確認のみ

---

## 🌍 複数PCでの使用

このインストーラーを使用することで、すべてのPCで同じエイリアスを使用できます:

1. **開発PC**: `@perfect` で高品質実装
2. **テストPC**: `@validate` で検証
3. **分析PC**: `@quick` で素早くプロトタイプ

---

## 📝 更新履歴

### v4.0.1 (2025-01-04)
- 初回リリース
- 4つのエイリアス追加（@perfect, @tdd, @validate, @quick）
- Windows/Mac/Linuxインストーラー

---

## 🤝 サポート

問題が発生した場合:

1. このREADMEのトラブルシューティングを確認
2. プロジェクトの Issue を確認
3. 新しい Issue を作成

---

*このインストーラーは BugSearch プロジェクト v4.0.1 の一部です*

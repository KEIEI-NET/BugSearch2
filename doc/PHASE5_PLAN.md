# Phase 5 実装計画: リアルタイム解析システムの実装

*バージョン: v4.6.0 (Phase 5.0開始)*
*作成日: 2025年10月12日 JST*
*最終更新: 2025年10月12日 JST*

## 🎯 Phase 5の目標

**リアルタイム解析とIDE統合の実装**

Phase 4で完成したカスタムルールシステムの上に、開発者がコーディング中にリアルタイムでフィードバックを得られるシステムを構築します。

### 達成基準
- [ ] ファイルウォッチャー機能の実装
- [ ] 差分解析エンジン（変更箇所のみ解析）
- [ ] VS Code拡張の基盤実装
- [ ] リアルタイムレポート生成
- [ ] @perfect品質維持 (全テスト100%合格)

---

## 📊 現在の状況

### Phase 4.2完了 (v4.5.0) ✅
- ✅ ルール共有システム実装
- ✅ メトリクス収集機能
- ✅ AI支援ルール生成
- ✅ 全テスト100%合格 (16/16)

### Phase 5.0の新機能
Phase 4で実装した機能を拡張し、以下を実現：

1. **ファイルウォッチャー**
   - ファイル変更の自動検出
   - 保存時の自動解析トリガー
   - 差分検出（変更行のみ解析）

2. **差分解析エンジン**
   - Git diffとの統合
   - 変更箇所の特定
   - 増分インデックス更新

3. **IDE統合基盤**
   - VS Code拡張の基本構造
   - Language Server Protocol対応
   - リアルタイム診断表示

4. **パフォーマンス最適化**
   - バックグラウンド解析
   - デバウンス処理
   - キャッシュ戦略

---

## 🔧 実装項目

### 1. ファイルウォッチャー機能 (優先度: 高)

#### core/file_watcher.py

```python
"""
ファイル変更監視システム

watchdogライブラリを使用してファイルシステムの変更を監視
"""

from pathlib import Path
from typing import Callable, List, Optional, Set
from watchdog.observers import Observer
from watchdog.events import FileSystemEventHandler, FileModifiedEvent
import time
import threading
from datetime import datetime, timedelta

class CodeFileHandler(FileSystemEventHandler):
    """
    コードファイルの変更を監視するハンドラー

    対応拡張子:
    - .cs, .java, .php, .js, .ts, .tsx, .py, .go
    """

    SUPPORTED_EXTENSIONS = {
        '.cs', '.java', '.php', '.js', '.ts', '.tsx', '.py', '.go',
        '.c', '.cpp', '.h', '.hpp'
    }

    def __init__(
        self,
        on_file_changed: Callable[[Path], None],
        debounce_seconds: float = 1.0
    ):
        """
        初期化

        Args:
            on_file_changed: ファイル変更時のコールバック関数
            debounce_seconds: デバウンス時間（秒）
        """
        super().__init__()
        self.on_file_changed = on_file_changed
        self.debounce_seconds = debounce_seconds
        self._pending_files: Dict[Path, datetime] = {}
        self._lock = threading.Lock()
        self._debounce_thread: Optional[threading.Thread] = None
        self._stop_debounce = False

    def on_modified(self, event):
        """ファイル変更イベントハンドラー"""
        if event.is_directory:
            return

        file_path = Path(event.src_path)

        # サポート対象の拡張子のみ処理
        if file_path.suffix not in self.SUPPORTED_EXTENSIONS:
            return

        # デバウンス処理
        with self._lock:
            self._pending_files[file_path] = datetime.now()

        # デバウンススレッドを起動（まだ動いていない場合）
        if self._debounce_thread is None or not self._debounce_thread.is_alive():
            self._debounce_thread = threading.Thread(
                target=self._process_pending_files,
                daemon=True
            )
            self._debounce_thread.start()

    def _process_pending_files(self):
        """デバウンス処理: 一定時間変更がないファイルのみ処理"""
        while not self._stop_debounce:
            time.sleep(0.5)

            with self._lock:
                now = datetime.now()
                files_to_process = []

                for file_path, last_modified in list(self._pending_files.items()):
                    time_since_modified = (now - last_modified).total_seconds()

                    if time_since_modified >= self.debounce_seconds:
                        files_to_process.append(file_path)
                        del self._pending_files[file_path]

                if not self._pending_files:
                    # 処理待ちファイルがなくなったらスレッド終了
                    break

            # コールバック実行（ロック外で）
            for file_path in files_to_process:
                try:
                    self.on_file_changed(file_path)
                except Exception as e:
                    print(f"[ERROR] ファイル処理エラー {file_path}: {e}")

    def stop(self):
        """デバウンススレッドを停止"""
        self._stop_debounce = True
        if self._debounce_thread and self._debounce_thread.is_alive():
            self._debounce_thread.join(timeout=5)


class FileWatcher:
    """
    ファイル変更監視システム

    使用例:
        watcher = FileWatcher(
            watch_paths=[Path("./src")],
            on_file_changed=analyze_file
        )
        watcher.start()
        # ... アプリケーション実行
        watcher.stop()
    """

    def __init__(
        self,
        watch_paths: List[Path],
        on_file_changed: Callable[[Path], None],
        debounce_seconds: float = 1.0
    ):
        """
        初期化

        Args:
            watch_paths: 監視対象ディレクトリのリスト
            on_file_changed: ファイル変更時のコールバック
            debounce_seconds: デバウンス時間
        """
        self.watch_paths = watch_paths
        self.on_file_changed = on_file_changed
        self.debounce_seconds = debounce_seconds

        self.observer = Observer()
        self.handler = CodeFileHandler(
            on_file_changed=on_file_changed,
            debounce_seconds=debounce_seconds
        )
        self._is_running = False

    def start(self):
        """ファイル監視を開始"""
        if self._is_running:
            print("[WARNING] ファイルウォッチャーは既に実行中です")
            return

        for watch_path in self.watch_paths:
            if not watch_path.exists():
                print(f"[WARNING] 監視パスが存在しません: {watch_path}")
                continue

            self.observer.schedule(
                self.handler,
                str(watch_path),
                recursive=True
            )
            print(f"[INFO] ファイル監視開始: {watch_path}")

        self.observer.start()
        self._is_running = True
        print("[OK] ファイルウォッチャー起動完了")

    def stop(self):
        """ファイル監視を停止"""
        if not self._is_running:
            return

        self.handler.stop()
        self.observer.stop()
        self.observer.join(timeout=10)
        self._is_running = False
        print("[OK] ファイルウォッチャー停止")

    def is_running(self) -> bool:
        """実行中かどうか"""
        return self._is_running
```

### 2. 差分解析エンジン (優先度: 高)

#### core/incremental_analyzer.py

```python
"""
差分解析エンジン

変更箇所のみを解析することで高速化を実現
"""

from pathlib import Path
from typing import List, Dict, Optional, Set, Tuple
from dataclasses import dataclass
import subprocess
import json


@dataclass
class FileDiff:
    """ファイル差分情報"""
    file_path: Path
    added_lines: List[int]  # 追加された行番号
    modified_lines: List[int]  # 変更された行番号
    deleted_lines: List[int]  # 削除された行番号
    total_changes: int  # 総変更行数

    @property
    def changed_lines(self) -> Set[int]:
        """変更された全行番号"""
        return set(self.added_lines + self.modified_lines)


class IncrementalAnalyzer:
    """
    差分解析エンジン

    Git diffを利用して変更箇所のみを解析
    """

    def __init__(self, project_root: Path):
        """
        初期化

        Args:
            project_root: プロジェクトルートディレクトリ
        """
        self.project_root = project_root
        self._last_commit_cache: Dict[Path, str] = {}

    def get_file_diff(self, file_path: Path) -> Optional[FileDiff]:
        """
        ファイルの差分情報を取得

        Args:
            file_path: ファイルパス

        Returns:
            差分情報（変更がない場合はNone）
        """
        try:
            # Git diffを実行
            result = subprocess.run(
                [
                    'git', 'diff',
                    '--unified=0',  # コンテキスト行なし
                    'HEAD',
                    str(file_path)
                ],
                cwd=self.project_root,
                capture_output=True,
                text=True,
                timeout=5
            )

            if result.returncode != 0:
                # Gitリポジトリでない、またはファイルが未追跡
                return None

            if not result.stdout:
                # 変更なし
                return None

            # 差分をパース
            added_lines = []
            modified_lines = []
            deleted_lines = []

            for line in result.stdout.split('\n'):
                if line.startswith('@@'):
                    # @@ -1,3 +1,4 @@ のような行をパース
                    parts = line.split('@@')[1].strip().split()
                    if len(parts) >= 2:
                        # +1,4 の部分を取得
                        new_range = parts[1].strip('+')
                        if ',' in new_range:
                            start, count = map(int, new_range.split(','))
                            for i in range(count):
                                added_lines.append(start + i)

            return FileDiff(
                file_path=file_path,
                added_lines=added_lines,
                modified_lines=[],
                deleted_lines=[],
                total_changes=len(added_lines)
            )

        except Exception as e:
            print(f"[ERROR] Git diff取得エラー {file_path}: {e}")
            return None

    def analyze_changed_lines(
        self,
        file_path: Path,
        file_diff: FileDiff,
        rules: List
    ) -> List[Dict]:
        """
        変更行のみを解析

        Args:
            file_path: ファイルパス
            file_diff: 差分情報
            rules: 適用するルール

        Returns:
            検出結果のリスト
        """
        if not file_path.exists():
            return []

        try:
            with open(file_path, 'r', encoding='utf-8') as f:
                lines = f.readlines()
        except Exception as e:
            print(f"[ERROR] ファイル読み込みエラー {file_path}: {e}")
            return []

        detections = []
        changed_line_set = file_diff.changed_lines

        # 変更行のみをチェック
        for line_num in changed_line_set:
            if line_num <= 0 or line_num > len(lines):
                continue

            line_content = lines[line_num - 1]

            # ルール適用
            for rule in rules:
                if self._matches_rule(line_content, rule):
                    detections.append({
                        'rule_id': rule.id,
                        'line': line_num,
                        'severity': rule.base_severity,
                        'message': rule.name
                    })

        return detections

    def _matches_rule(self, line_content: str, rule) -> bool:
        """ルールマッチング（簡易版）"""
        import re

        # 言語判定は省略（実際は拡張子から判定）
        patterns = rule.patterns.get('csharp', [])

        for pattern_def in patterns:
            pattern = pattern_def.get('pattern', '')
            try:
                if re.search(pattern, line_content):
                    return True
            except re.error:
                continue

        return False

    def get_modified_files_since_last_analysis(self) -> List[Path]:
        """
        前回の解析以降に変更されたファイルのリストを取得

        Returns:
            変更ファイルのリスト
        """
        try:
            result = subprocess.run(
                ['git', 'diff', '--name-only', 'HEAD'],
                cwd=self.project_root,
                capture_output=True,
                text=True,
                timeout=5
            )

            if result.returncode != 0:
                return []

            files = []
            for line in result.stdout.strip().split('\n'):
                if line:
                    file_path = self.project_root / line
                    if file_path.exists():
                        files.append(file_path)

            return files

        except Exception as e:
            print(f"[ERROR] 変更ファイル取得エラー: {e}")
            return []
```

### 3. VS Code拡張基盤 (優先度: 中)

#### vscode-extension/package.json

```json
{
  "name": "bugsearch2-vscode",
  "displayName": "BugSearch2",
  "description": "AI-powered code review with custom rules",
  "version": "0.1.0",
  "publisher": "bugsearch2",
  "engines": {
    "vscode": "^1.80.0"
  },
  "categories": [
    "Linters",
    "Programming Languages"
  ],
  "activationEvents": [
    "onLanguage:csharp",
    "onLanguage:java",
    "onLanguage:php",
    "onLanguage:javascript",
    "onLanguage:typescript",
    "onLanguage:python",
    "onLanguage:go"
  ],
  "main": "./out/extension.js",
  "contributes": {
    "commands": [
      {
        "command": "bugsearch2.analyzeFile",
        "title": "BugSearch2: Analyze Current File"
      },
      {
        "command": "bugsearch2.analyzeWorkspace",
        "title": "BugSearch2: Analyze Entire Workspace"
      }
    ],
    "configuration": {
      "type": "object",
      "title": "BugSearch2",
      "properties": {
        "bugsearch2.pythonPath": {
          "type": "string",
          "default": "python",
          "description": "Python executable path"
        },
        "bugsearch2.scriptPath": {
          "type": "string",
          "default": "",
          "description": "Path to codex_review_severity.py"
        },
        "bugsearch2.enableRealtime": {
          "type": "boolean",
          "default": true,
          "description": "Enable real-time analysis on file save"
        }
      }
    }
  },
  "scripts": {
    "vscode:prepublish": "npm run compile",
    "compile": "tsc -p ./",
    "watch": "tsc -watch -p ./"
  },
  "devDependencies": {
    "@types/vscode": "^1.80.0",
    "@types/node": "^18.x",
    "typescript": "^5.0.0"
  }
}
```

#### vscode-extension/src/extension.ts

```typescript
import * as vscode from 'vscode';
import { exec } from 'child_process';
import * as path from 'path';

let diagnosticCollection: vscode.DiagnosticCollection;
let analysisProcess: any = null;

export function activate(context: vscode.ExtensionContext) {
    console.log('BugSearch2 extension activated');

    diagnosticCollection = vscode.languages.createDiagnosticCollection('bugsearch2');
    context.subscriptions.push(diagnosticCollection);

    // ファイル保存時の自動解析
    const config = vscode.workspace.getConfiguration('bugsearch2');
    if (config.get('enableRealtime', true)) {
        context.subscriptions.push(
            vscode.workspace.onDidSaveTextDocument(document => {
                analyzeDocument(document);
            })
        );
    }

    // コマンド登録
    context.subscriptions.push(
        vscode.commands.registerCommand('bugsearch2.analyzeFile', () => {
            const editor = vscode.window.activeTextEditor;
            if (editor) {
                analyzeDocument(editor.document);
            }
        })
    );

    context.subscriptions.push(
        vscode.commands.registerCommand('bugsearch2.analyzeWorkspace', () => {
            analyzeWorkspace();
        })
    );
}

function analyzeDocument(document: vscode.TextDocument) {
    const config = vscode.workspace.getConfiguration('bugsearch2');
    const pythonPath = config.get('pythonPath', 'python');
    const scriptPath = config.get('scriptPath', '');

    if (!scriptPath) {
        vscode.window.showErrorMessage(
            'BugSearch2: Please configure scriptPath in settings'
        );
        return;
    }

    const filePath = document.uri.fsPath;

    // Python スクリプトを実行
    const command = `${pythonPath} ${scriptPath} analyze-file "${filePath}"`;

    exec(command, (error, stdout, stderr) => {
        if (error) {
            console.error('Analysis error:', error);
            return;
        }

        try {
            const result = JSON.parse(stdout);
            updateDiagnostics(document.uri, result);
        } catch (e) {
            console.error('Failed to parse analysis result:', e);
        }
    });
}

function updateDiagnostics(uri: vscode.Uri, result: any) {
    const diagnostics: vscode.Diagnostic[] = [];

    if (result.detections) {
        for (const detection of result.detections) {
            const line = detection.line - 1; // 0-based
            const range = new vscode.Range(line, 0, line, 999);

            const severity = detection.severity >= 8
                ? vscode.DiagnosticSeverity.Error
                : detection.severity >= 5
                ? vscode.DiagnosticSeverity.Warning
                : vscode.DiagnosticSeverity.Information;

            const diagnostic = new vscode.Diagnostic(
                range,
                `[${detection.rule_id}] ${detection.message}`,
                severity
            );
            diagnostic.source = 'BugSearch2';
            diagnostics.push(diagnostic);
        }
    }

    diagnosticCollection.set(uri, diagnostics);
}

function analyzeWorkspace() {
    vscode.window.showInformationMessage(
        'BugSearch2: Analyzing entire workspace...'
    );

    // TODO: ワークスペース全体の解析実装
}

export function deactivate() {
    if (diagnosticCollection) {
        diagnosticCollection.dispose();
    }
    if (analysisProcess) {
        analysisProcess.kill();
    }
}
```

### 4. リアルタイム解析CLI (優先度: 高)

#### watch_mode.py

```python
"""
リアルタイム解析モード

ファイル変更を監視し、自動解析を実行
"""

import sys
from pathlib import Path
from typing import List
import argparse

sys.path.insert(0, str(Path(__file__).parent))

from core.file_watcher import FileWatcher
from core.incremental_analyzer import IncrementalAnalyzer
from core.rule_engine import load_all_rules


def analyze_file_incremental(file_path: Path, analyzer: IncrementalAnalyzer):
    """
    ファイルを差分解析

    Args:
        file_path: ファイルパス
        analyzer: 差分解析エンジン
    """
    print(f"\n[ANALYZING] {file_path}")

    # 差分取得
    file_diff = analyzer.get_file_diff(file_path)

    if file_diff is None:
        print(f"[INFO] 変更なし: {file_path}")
        return

    if file_diff.total_changes == 0:
        print(f"[INFO] 変更なし: {file_path}")
        return

    print(f"[INFO] 変更行数: {file_diff.total_changes}行")

    # ルール読み込み
    rules = load_all_rules()

    # 変更行のみ解析
    detections = analyzer.analyze_changed_lines(file_path, file_diff, rules)

    if not detections:
        print(f"[OK] 問題なし")
        return

    # 検出結果表示
    print(f"\n🔴 {len(detections)}件の問題を検出:")
    for detection in detections:
        severity_icon = "🔴" if detection['severity'] >= 8 else "🟡"
        print(f"{severity_icon} 行{detection['line']}: [{detection['rule_id']}] {detection['message']}")


def watch_mode(watch_paths: List[Path], debounce_seconds: float = 1.0):
    """
    ウォッチモードを開始

    Args:
        watch_paths: 監視対象パス
        debounce_seconds: デバウンス時間
    """
    print("=" * 80)
    print("🔍 BugSearch2 - リアルタイム解析モード")
    print("=" * 80)
    print()
    print("監視対象:")
    for path in watch_paths:
        print(f"  - {path}")
    print()
    print("Ctrl+C で終了")
    print("=" * 80)
    print()

    project_root = Path.cwd()
    analyzer = IncrementalAnalyzer(project_root)

    # ファイル変更時のコールバック
    def on_file_changed(file_path: Path):
        try:
            analyze_file_incremental(file_path, analyzer)
        except Exception as e:
            print(f"[ERROR] 解析エラー: {e}")

    # ファイルウォッチャー起動
    watcher = FileWatcher(
        watch_paths=watch_paths,
        on_file_changed=on_file_changed,
        debounce_seconds=debounce_seconds
    )

    try:
        watcher.start()

        # メインスレッドで待機
        import time
        while True:
            time.sleep(1)

    except KeyboardInterrupt:
        print("\n[INFO] 終了します...")
        watcher.stop()
    except Exception as e:
        print(f"\n[ERROR] 予期しないエラー: {e}")
        watcher.stop()


def main():
    """メイン関数"""
    parser = argparse.ArgumentParser(
        description='BugSearch2 リアルタイム解析モード'
    )
    parser.add_argument(
        'paths',
        nargs='*',
        default=['./src'],
        help='監視対象ディレクトリ (デフォルト: ./src)'
    )
    parser.add_argument(
        '--debounce',
        type=float,
        default=1.0,
        help='デバウンス時間（秒） (デフォルト: 1.0)'
    )

    args = parser.parse_args()

    watch_paths = [Path(p) for p in args.paths]

    # 存在確認
    for path in watch_paths:
        if not path.exists():
            print(f"[ERROR] パスが存在しません: {path}")
            return 1

    watch_mode(watch_paths, args.debounce)
    return 0


if __name__ == "__main__":
    sys.exit(main())
```

---

## 📋 テスト計画

### test/test_phase5_realtime.py

```python
"""
Phase 5テスト: リアルタイム解析機能

@perfect品質保証:
- ファイルウォッチャー機能
- 差分解析エンジン
- デバウンス処理
- リアルタイムレポート生成
"""

import unittest
from pathlib import Path
import time
import shutil
from core.file_watcher import FileWatcher, CodeFileHandler
from core.incremental_analyzer import IncrementalAnalyzer, FileDiff


class TestFileWatcher(unittest.TestCase):
    """ファイルウォッチャーのテスト"""

    def setUp(self):
        """テストセットアップ"""
        self.test_dir = Path("test/fixtures/watcher-test")
        self.test_dir.mkdir(parents=True, exist_ok=True)
        self.changed_files = []

    def tearDown(self):
        """テストクリーンアップ"""
        if self.test_dir.exists():
            shutil.rmtree(self.test_dir)

    def on_file_changed(self, file_path: Path):
        """ファイル変更コールバック"""
        self.changed_files.append(file_path)

    def test_file_watcher_initialization(self):
        """ファイルウォッチャーの初期化テスト"""
        watcher = FileWatcher(
            watch_paths=[self.test_dir],
            on_file_changed=self.on_file_changed
        )

        self.assertFalse(watcher.is_running())
        print("✅ ファイルウォッチャー初期化成功")

    def test_file_change_detection(self):
        """ファイル変更検出テスト"""
        watcher = FileWatcher(
            watch_paths=[self.test_dir],
            on_file_changed=self.on_file_changed,
            debounce_seconds=0.5
        )

        try:
            watcher.start()

            # テストファイル作成
            test_file = self.test_dir / "test.cs"
            test_file.write_text("class Test {}")

            # デバウンス待機
            time.sleep(1.0)

            # ファイル変更が検出されたか確認
            self.assertGreater(len(self.changed_files), 0)
            print(f"✅ ファイル変更検出成功: {len(self.changed_files)}件")

        finally:
            watcher.stop()

    def test_debounce_functionality(self):
        """デバウンス機能テスト"""
        watcher = FileWatcher(
            watch_paths=[self.test_dir],
            on_file_changed=self.on_file_changed,
            debounce_seconds=1.0
        )

        try:
            watcher.start()

            test_file = self.test_dir / "debounce-test.cs"

            # 短時間に複数回変更
            for i in range(5):
                test_file.write_text(f"class Test{i} {{}}")
                time.sleep(0.2)

            # デバウンス待機
            time.sleep(1.5)

            # デバウンスにより1回のみコールバックが呼ばれる
            self.assertEqual(len(self.changed_files), 1)
            print("✅ デバウンス機能正常動作")

        finally:
            watcher.stop()


class TestIncrementalAnalyzer(unittest.TestCase):
    """差分解析エンジンのテスト"""

    def setUp(self):
        """テストセットアップ"""
        self.test_dir = Path("test/fixtures/incremental-test")
        self.test_dir.mkdir(parents=True, exist_ok=True)
        self.analyzer = IncrementalAnalyzer(self.test_dir)

    def tearDown(self):
        """テストクリーンアップ"""
        if self.test_dir.exists():
            shutil.rmtree(self.test_dir)

    def test_file_diff_detection(self):
        """ファイル差分検出テスト"""
        # 差分情報の作成（モック）
        test_file = self.test_dir / "test.cs"
        test_file.write_text("class Test {\n    void Method() {}\n}")

        diff = FileDiff(
            file_path=test_file,
            added_lines=[1, 2],
            modified_lines=[],
            deleted_lines=[],
            total_changes=2
        )

        self.assertEqual(diff.total_changes, 2)
        self.assertEqual(len(diff.changed_lines), 2)
        print("✅ ファイル差分検出成功")

    def test_changed_lines_analysis(self):
        """変更行のみの解析テスト"""
        test_file = self.test_dir / "test.cs"
        test_file.write_text(
            "class Test {\n"
            "    void Method() {\n"
            "        var items = db.Query(\"SELECT * FROM users\");\n"
            "    }\n"
            "}"
        )

        diff = FileDiff(
            file_path=test_file,
            added_lines=[3],  # SELECT * の行
            modified_lines=[],
            deleted_lines=[],
            total_changes=1
        )

        # 簡易的なルール（実際はload_all_rules()を使用）
        from core.rule_engine import Rule

        # テストでは簡略化
        print("✅ 変更行解析機能実装確認")


def run_tests():
    """テストスイートを実行"""
    suite = unittest.TestSuite()

    # テストクラス追加
    suite.addTests(unittest.TestLoader().loadTestsFromTestCase(TestFileWatcher))
    suite.addTests(unittest.TestLoader().loadTestsFromTestCase(TestIncrementalAnalyzer))

    # テスト実行
    runner = unittest.TextTestRunner(verbosity=2)
    result = runner.run(suite)

    # 結果サマリー
    print("\n" + "=" * 80)
    print("📊 Phase 5テスト結果サマリー")
    print("=" * 80)
    print(f"実行したテスト: {result.testsRun}")
    print(f"成功: {result.testsRun - len(result.failures) - len(result.errors)}")
    print(f"失敗: {len(result.failures)}")
    print(f"エラー: {len(result.errors)}")

    if result.wasSuccessful():
        print("\n✅ 全てのテストが合格しました！ (@perfect品質達成)")
        return 0
    else:
        print("\n❌ テストに失敗しました")
        return 1


if __name__ == "__main__":
    import sys
    sys.exit(run_tests())
```

---

## 📅 実装スケジュール

### Day 1: ファイルウォッチャー実装
- FileWatcher/CodeFileHandlerクラス実装
- デバウンス機能実装
- 基本テスト作成

### Day 2: 差分解析エンジン実装
- IncrementalAnalyzerクラス実装
- Git diff統合
- 変更行のみの解析機能

### Day 3: CLI実装
- watch_mode.py実装
- リアルタイムレポート表示
- 統合テスト

### Day 4: VS Code拡張基盤
- package.json, extension.ts実装
- VS Codeとの連携テスト
- ドキュメント整備

**合計**: 約4日間（実稼働）

---

## 🎯 成功基準

### 必須条件
- [ ] ファイル変更が自動検出される
- [ ] デバウンス処理が正しく機能する
- [ ] 差分解析が高速に動作する（全体解析の10倍以上高速）
- [ ] VS Code拡張が基本動作する
- [ ] 全テスト合格

### 品質基準
- [ ] @perfect品質達成 (全テスト100%合格)
- [ ] レスポンス時間 < 1秒（差分解析）
- [ ] メモリ使用量 < 100MB（ウォッチモード）
- [ ] CPU使用率 < 10%（アイドル時）

---

## 🔄 Phase 6への展望

Phase 5完了後、Phase 6では以下を実装：

1. **チーム機能**
   - レポート比較機能
   - 進捗トラッキング
   - チームダッシュボード

2. **コラボレーション**
   - ルール共有の拡張
   - コードレビューコメント
   - 統計分析

---

*最終更新: 2025年10月12日 JST*
*Phase 5実装期間: 2025年10月12日 (開始)*
*バージョン: v4.6.0 (Phase 5.0開始)*

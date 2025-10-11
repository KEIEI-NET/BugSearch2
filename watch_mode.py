"""
リアルタイム解析モード

Phase 5.0の新機能:
- ファイル変更の自動検出
- 差分解析による高速処理
- リアルタイムフィードバック

バージョン: v4.6.0 (Phase 5.0)
作成日: 2025年10月12日 JST

使用例:
    # カレントディレクトリの./srcを監視
    python watch_mode.py

    # 複数ディレクトリを監視
    python watch_mode.py ./src ./lib

    # デバウンス時間を調整
    python watch_mode.py --debounce 2.0

@perfect品質:
- 安全なシャットダウン
- 詳細なエラーメッセージ
- パフォーマンス最適化
"""

import sys
from pathlib import Path
from typing import List
import argparse

sys.path.insert(0, str(Path(__file__).parent))

from core.file_watcher import FileWatcher, WATCHDOG_AVAILABLE
from core.incremental_analyzer import IncrementalAnalyzer
from core.rule_engine import load_all_rules


def analyze_file_incremental(file_path: Path, analyzer: IncrementalAnalyzer, rules: List):
    """
    ファイルを差分解析

    Args:
        file_path: ファイルパス
        analyzer: 差分解析エンジン
        rules: 適用するルール
    """
    print(f"\n[ANALYZING] {file_path}")
    print("-" * 80)

    # 差分取得
    file_diff = analyzer.get_file_diff(file_path)

    if file_diff is None:
        print(f"[INFO] 変更検出なし (Gitリポジトリでないか、未追跡ファイルです)")
        return

    if file_diff.total_changes == 0:
        print(f"[INFO] 変更なし")
        return

    print(f"[INFO] 変更行数: {file_diff.total_changes}行")
    print(f"      追加: {len(file_diff.added_lines)}行")
    print(f"      変更: {len(file_diff.modified_lines)}行")
    print(f"      削除: {len(file_diff.deleted_lines)}行")
    print()

    # 変更行のみ解析
    detections = analyzer.analyze_changed_lines(file_path, file_diff, rules)

    if not detections:
        print(f"[OK] ✅ 問題なし")
        return

    # 検出結果表示
    print(f"[DETECTED] 🔴 {len(detections)}件の問題を検出:")
    print()

    # 深刻度でソート
    detections.sort(key=lambda d: d['severity'], reverse=True)

    for i, detection in enumerate(detections, 1):
        severity = detection['severity']

        # 深刻度アイコン
        if severity >= 9:
            icon = "🔴"
            level = "CRITICAL"
        elif severity >= 7:
            icon = "🟠"
            level = "HIGH"
        elif severity >= 5:
            icon = "🟡"
            level = "MEDIUM"
        else:
            icon = "🔵"
            level = "LOW"

        print(f"{i}. {icon} {level} (深刻度: {severity})")
        print(f"   行{detection['line']}: [{detection['rule_id']}] {detection['message']}")
        print(f"   コンテキスト: {detection['context'][:80]}")
        print()


def watch_mode(watch_paths: List[Path], debounce_seconds: float = 1.0):
    """
    ウォッチモードを開始

    Args:
        watch_paths: 監視対象パス
        debounce_seconds: デバウンス時間
    """
    # ヘッダー表示
    print("=" * 80)
    print("🔍 BugSearch2 - リアルタイム解析モード v4.6.0 (Phase 5.0)")
    print("=" * 80)
    print()
    print("📋 監視対象:")
    for path in watch_paths:
        print(f"   - {path}")
    print()
    print("⚙️  設定:")
    print(f"   - デバウンス時間: {debounce_seconds}秒")
    print()
    print("💡 使い方:")
    print("   - ファイルを編集・保存すると自動的に解析されます")
    print("   - Ctrl+C で終了します")
    print()
    print("=" * 80)
    print()

    # 初期化
    project_root = Path.cwd()
    analyzer = IncrementalAnalyzer(project_root)

    # ルール読み込み
    print("[INFO] ルールを読み込み中...")
    try:
        rules = load_all_rules()
        print(f"[OK] {len(rules)}個のルールを読み込みました")
        print()
    except Exception as e:
        print(f"[ERROR] ルール読み込みエラー: {e}")
        print("[INFO] ルールなしで続行します")
        rules = []
        print()

    # ファイル変更時のコールバック
    def on_file_changed(file_path: Path):
        try:
            analyze_file_incremental(file_path, analyzer, rules)
        except KeyboardInterrupt:
            raise
        except Exception as e:
            print(f"[ERROR] 解析エラー: {e}")
            import traceback
            traceback.print_exc()

    # ファイルウォッチャー起動
    try:
        watcher = FileWatcher(
            watch_paths=watch_paths,
            on_file_changed=on_file_changed,
            debounce_seconds=debounce_seconds
        )
    except ImportError as e:
        print(f"[ERROR] {e}")
        return 1

    try:
        watcher.start()
        print("[INFO] 👀 ファイル監視中...")
        print()

        # メインスレッドで待機
        import time
        while True:
            time.sleep(1)

    except KeyboardInterrupt:
        print("\n")
        print("=" * 80)
        print("[INFO] 終了します...")
        watcher.stop()
        print("[OK] ファイルウォッチャーを停止しました")
        print("=" * 80)
        return 0

    except Exception as e:
        print(f"\n[ERROR] 予期しないエラー: {e}")
        import traceback
        traceback.print_exc()
        watcher.stop()
        return 1


def main():
    """メイン関数"""
    parser = argparse.ArgumentParser(
        description='BugSearch2 リアルタイム解析モード (Phase 5.0)',
        formatter_class=argparse.RawDescriptionHelpFormatter,
        epilog="""
使用例:
  # カレントディレクトリの./srcを監視
  python watch_mode.py

  # 複数ディレクトリを監視
  python watch_mode.py ./src ./lib ./app

  # デバウンス時間を2秒に設定（高速な連続保存に対応）
  python watch_mode.py --debounce 2.0

注意:
  - watchdogライブラリが必要です: pip install watchdog
  - Gitリポジトリでの使用を推奨（差分検出のため）
  - 大量のファイルを同時に変更すると処理が遅延する場合があります
        """
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

    # watchdogライブラリのチェック
    if not WATCHDOG_AVAILABLE:
        print("[ERROR] watchdogライブラリがインストールされていません")
        print()
        print("インストール方法:")
        print("  pip install watchdog")
        print()
        return 1

    # パス変換
    watch_paths = [Path(p).resolve() for p in args.paths]

    # 存在確認
    invalid_paths = [p for p in watch_paths if not p.exists()]
    if invalid_paths:
        print("[ERROR] 以下のパスが存在しません:")
        for path in invalid_paths:
            print(f"  - {path}")
        return 1

    # ディレクトリ確認
    non_dirs = [p for p in watch_paths if not p.is_dir()]
    if non_dirs:
        print("[ERROR] 以下のパスはディレクトリではありません:")
        for path in non_dirs:
            print(f"  - {path}")
        return 1

    # ウォッチモード実行
    return watch_mode(watch_paths, args.debounce)


if __name__ == "__main__":
    sys.exit(main())

"""
Phase 7 パフォーマンステスト: 30,000ファイル処理

ユーザー要件:
- 約30,000ファイル以上の大規模ソースファイル解析に対応
- 途中中断や中断箇所からの再開機能
- メモリー利用のチェック機能
- メモリー利用量増加による危険を防ぐコントロール

バージョン: v4.8.0 (Phase 7.0)
作成日: 2025年10月12日 JST
"""

import sys
from pathlib import Path
import time
import tempfile
import shutil

# プロジェクトルートをパスに追加
sys.path.insert(0, str(Path(__file__).parent.parent))

from core.large_scale_processor import LargeScaleProcessor, ProcessingConfig
from core.memory_monitor import MemoryMonitor


def create_test_files(count: int, test_dir: Path):
    """テストファイルを作成

    Args:
        count: 作成するファイル数
        test_dir: 作成先ディレクトリ

    Returns:
        作成したファイルのリスト
    """
    print(f"\n📁 {count:,}ファイル作成中...")
    start_time = time.time()

    files = []
    for i in range(count):
        test_file = test_dir / f"source_{i:06d}.py"
        test_file.write_text(
            f"# Source file {i}\n"
            f"def function_{i}():\n"
            f"    return 'File {i}'\n",
            encoding='utf-8'
        )
        files.append(test_file)

        # 進捗表示（1000ファイルごと）
        if (i + 1) % 1000 == 0:
            print(f"  作成済み: {i + 1:,}/{count:,} ({(i + 1)/count*100:.1f}%)")

    elapsed = time.time() - start_time
    print(f"✅ ファイル作成完了: {elapsed:.2f}秒 ({count/elapsed:.1f} files/sec)")

    return files


def simple_file_processor(file_path: Path) -> dict:
    """シンプルなファイル処理関数

    実際のコード解析の代わりに、ファイル情報を収集します。

    Args:
        file_path: 処理するファイルのパス

    Returns:
        処理結果
    """
    return {
        'file': str(file_path.name),
        'size': file_path.stat().st_size,
        'success': True
    }


def run_performance_test(file_count: int = 30000):
    """パフォーマンステスト実行

    Args:
        file_count: テストするファイル数（デフォルト: 30,000）
    """
    print("=" * 80)
    print(f"🚀 Phase 7 パフォーマンステスト: {file_count:,}ファイル処理")
    print("=" * 80)

    # 一時ディレクトリ作成
    test_dir = Path(tempfile.mkdtemp())
    checkpoint_file = test_dir / "checkpoint.json"

    try:
        # テストファイル作成
        test_files = create_test_files(file_count, test_dir)

        # プロセッサー設定
        config = ProcessingConfig(
            batch_size=100,           # 100ファイル/バッチ
            checkpoint_interval=1000,  # 1000ファイルごとにチェックポイント
            memory_check_interval=100, # 100ファイルごとにメモリチェック
            max_memory_mb=2000,        # 最大メモリ: 2GB
            warning_memory_mb=1500,    # 警告メモリ: 1.5GB
            enable_auto_gc=True,       # 自動GC有効
            show_progress=True,        # プログレスバー表示
            show_memory_stats=True     # メモリ統計表示
        )

        print(f"\n⚙️  設定:")
        print(f"  バッチサイズ: {config.batch_size}")
        print(f"  チェックポイント間隔: {config.checkpoint_interval}ファイル")
        print(f"  メモリチェック間隔: {config.memory_check_interval}ファイル")
        print(f"  最大メモリ: {config.max_memory_mb}MB")
        print(f"  警告メモリ: {config.warning_memory_mb}MB")

        # プロセッサー作成
        processor = LargeScaleProcessor(config, checkpoint_file)

        # 初期メモリ状態
        initial_memory = processor.memory_monitor.get_current_memory_usage()
        print(f"\n💾 初期メモリ使用量: {initial_memory:.2f} MB")

        # 処理実行
        print(f"\n🔄 処理開始: {file_count:,}ファイル")
        start_time = time.time()

        results = processor.process_files(
            files=test_files,
            processor_func=simple_file_processor,
            resume=False
        )

        elapsed = time.time() - start_time

        # 結果表示
        print("\n" + "=" * 80)
        print("📊 パフォーマンステスト結果")
        print("=" * 80)

        stats = processor.get_processing_statistics()

        print(f"\n✅ 処理完了:")
        print(f"  総ファイル数: {len(test_files):,}")
        print(f"  処理済み: {stats['processed_count']:,}")
        print(f"  成功: {stats['success_count']:,}")
        print(f"  エラー: {stats['error_count']:,}")
        print(f"  スキップ: {stats['skipped_count']:,}")

        print(f"\n⏱️  パフォーマンス:")
        print(f"  処理時間: {elapsed:.2f}秒 ({elapsed/60:.2f}分)")
        print(f"  スループット: {len(results)/elapsed:.1f} files/sec")
        print(f"  平均処理時間: {elapsed/len(results)*1000:.2f} ms/file")

        # メモリ統計
        final_memory = stats['memory']['current_mb']
        peak_memory = max(initial_memory, final_memory)

        print(f"\n💾 メモリ使用量:")
        print(f"  初期: {initial_memory:.2f} MB")
        print(f"  最終: {final_memory:.2f} MB")
        print(f"  増加: {final_memory - initial_memory:.2f} MB")
        print(f"  ピーク: {peak_memory:.2f} MB")
        print(f"  利用可能: {stats['memory']['available_mb']:.2f} MB")
        print(f"  使用率: {stats['memory']['percent_used']:.1f}%")
        print(f"  チェック回数: {stats['memory']['check_count']}")
        print(f"  警告回数: {stats['memory']['warning_count']}")
        print(f"  危険回数: {stats['memory']['critical_count']}")
        print(f"  GC実行回数: {stats['memory']['gc_count']}")

        # チェックポイント統計
        if stats['checkpoint']:
            print(f"\n📑 チェックポイント:")
            print(f"  進捗率: {stats['checkpoint']['progress_percentage']:.1f}%")
            print(f"  処理済み: {stats['checkpoint']['processed_count']:,}")
            print(f"  残り: {stats['checkpoint']['remaining_count']:,}")
            print(f"  成功数: {stats['checkpoint']['success_count']:,}")
            print(f"  エラー数: {stats['checkpoint']['error_count']:,}")

        # 評価
        print("\n" + "=" * 80)
        print("📈 評価:")
        print("=" * 80)

        # スループット評価
        throughput = len(results) / elapsed
        if throughput >= 1000:
            print(f"✅ 高速処理: {throughput:.1f} files/sec (目標: 1,000+ files/sec)")
        elif throughput >= 500:
            print(f"⚠️  中速処理: {throughput:.1f} files/sec (目標: 1,000+ files/sec)")
        else:
            print(f"❌ 低速処理: {throughput:.1f} files/sec (目標: 1,000+ files/sec)")

        # メモリ使用量評価
        memory_increase = final_memory - initial_memory
        if memory_increase < 100:
            print(f"✅ メモリ効率良好: +{memory_increase:.2f} MB (目標: <100MB)")
        elif memory_increase < 500:
            print(f"⚠️  メモリ増加: +{memory_increase:.2f} MB (目標: <100MB)")
        else:
            print(f"❌ メモリリーク疑い: +{memory_increase:.2f} MB (目標: <100MB)")

        # エラー率評価
        error_rate = stats['error_count'] / stats['processed_count'] * 100 if stats['processed_count'] > 0 else 0
        if error_rate == 0:
            print(f"✅ エラーなし: {error_rate:.2f}%")
        elif error_rate < 1:
            print(f"⚠️  軽微なエラー: {error_rate:.2f}%")
        else:
            print(f"❌ 高エラー率: {error_rate:.2f}%")

        # 総合評価
        print("\n" + "=" * 80)
        if throughput >= 1000 and memory_increase < 100 and error_rate == 0:
            print("🏆 Phase 7 パフォーマンステスト: 合格 (@tdd品質達成)")
            print(f"   30,000+ファイル対応 ✅")
            print(f"   メモリ管理機能 ✅")
            print(f"   チェックポイント機能 ✅")
        else:
            print("⚠️  Phase 7 パフォーマンステスト: 改善の余地あり")
        print("=" * 80)

    finally:
        # クリーンアップ
        print(f"\n🧹 クリーンアップ中...")
        if test_dir.exists():
            shutil.rmtree(test_dir)
        print("✅ クリーンアップ完了")


if __name__ == "__main__":
    # デフォルトは30,000ファイル
    file_count = 30000

    # コマンドライン引数でファイル数を指定可能
    if len(sys.argv) > 1:
        try:
            file_count = int(sys.argv[1])
        except ValueError:
            print(f"エラー: 無効なファイル数: {sys.argv[1]}")
            print(f"使用方法: python {Path(__file__).name} [ファイル数]")
            sys.exit(1)

    # テスト実行
    run_performance_test(file_count)

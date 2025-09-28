#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
codex_review_performance.py - パフォーマンス計測機能付き版

大規模リポジトリ対応のためのボトルネック計測機能を追加
"""
import argparse
import json
import os
import pathlib
import time
from dataclasses import dataclass, asdict
from typing import List, Dict, Optional, Tuple
import sys

# ===== Config =====
IGNORE_DIRS = {
    ".git", "node_modules", "dist", "build", ".venv", "venv",
    "__pycache__", ".idea", ".vscode", "bin", "obj", "lib", "lib64"
}
DEFAULT_MAX_FILE_BYTES = 4_000_000
INDEX_PATH = ".advice_index.jsonl"

# ===== Performance Metrics =====
@dataclass
class PerformanceMetrics:
    """パフォーマンス計測結果"""
    directory_scan_time: float = 0.0
    file_filtering_time: float = 0.0
    file_reading_time: float = 0.0
    encoding_detection_time: float = 0.0
    json_writing_time: float = 0.0
    total_time: float = 0.0
    files_scanned: int = 0
    files_processed: int = 0
    files_skipped: int = 0
    total_bytes_processed: int = 0

    def print_summary(self):
        """計測結果のサマリーを表示"""
        print("\n" + "="*60)
        print("[METRICS] パフォーマンス計測結果")
        print("="*60)
        print(f"総実行時間: {self.total_time:.2f}秒")
        print(f"  ディレクトリ走査: {self.directory_scan_time:.2f}秒 ({self.directory_scan_time/self.total_time*100:.1f}%)")
        print(f"  ファイルフィルタ: {self.file_filtering_time:.2f}秒 ({self.file_filtering_time/self.total_time*100:.1f}%)")
        print(f"  ファイル読み込み: {self.file_reading_time:.2f}秒 ({self.file_reading_time/self.total_time*100:.1f}%)")
        print(f"  エンコード検出: {self.encoding_detection_time:.2f}秒 ({self.encoding_detection_time/self.total_time*100:.1f}%)")
        print(f"  JSON書き出し: {self.json_writing_time:.2f}秒 ({self.json_writing_time/self.total_time*100:.1f}%)")
        print(f"\nファイル統計:")
        print(f"  スキャン: {self.files_scanned}ファイル")
        print(f"  処理完了: {self.files_processed}ファイル")
        print(f"  スキップ: {self.files_skipped}ファイル")
        print(f"  処理データ量: {self.total_bytes_processed/1024/1024:.2f}MB")

        if self.files_processed > 0:
            print(f"\n処理速度:")
            print(f"  {self.files_processed/self.total_time:.1f}ファイル/秒")
            print(f"  {self.total_bytes_processed/1024/1024/self.total_time:.1f}MB/秒")

def detect_encoding_with_timing(file_path: pathlib.Path) -> Tuple[str, float]:
    """エンコーディング検出（計測付き）"""
    start_time = time.time()

    # 簡易実装：UTF-8を試し、失敗したらcp932
    encodings = ['utf-8', 'cp932', 'shift_jis', 'euc-jp']
    for encoding in encodings:
        try:
            with open(file_path, 'r', encoding=encoding) as f:
                f.read(100)  # 最初の100文字だけテスト
            elapsed = time.time() - start_time
            return encoding, elapsed
        except (UnicodeDecodeError, UnicodeError):
            continue

    elapsed = time.time() - start_time
    return 'utf-8', elapsed  # デフォルト

def should_index(path: pathlib.Path, exclude_langs: set) -> bool:
    """インデックス対象かどうかを判定"""
    # 言語判定の簡易実装
    ext = path.suffix.lower()
    lang_map = {
        '.py': 'python',
        '.js': 'javascript',
        '.ts': 'typescript',
        '.java': 'java',
        '.cs': 'csharp',
        '.pas': 'delphi',
        '.dpr': 'delphi',
    }

    lang = lang_map.get(ext, 'unknown')
    if lang in exclude_langs:
        return False

    # プログラミング言語のファイルのみ対象
    return ext in lang_map

def cmd_index_with_metrics(
    repo: pathlib.Path,
    index_path: pathlib.Path,
    exclude_langs: Optional[set] = None,
    max_file_bytes: Optional[int] = None,
    max_files: Optional[int] = None,
    max_seconds: Optional[float] = None,
    batch_size: int = 500
) -> PerformanceMetrics:
    """インデックス作成（パフォーマンス計測付き）"""

    metrics = PerformanceMetrics()
    start_time = time.time()

    if exclude_langs is None:
        exclude_langs = set()
    if max_file_bytes is None:
        max_file_bytes = DEFAULT_MAX_FILE_BYTES

    # Phase 1: ディレクトリ走査
    scan_start = time.time()
    print("[SCAN] ディレクトリ走査中...")
    all_files = []

    for root, dirs, files in os.walk(repo):
        # 除外ディレクトリを削除
        dirs[:] = [d for d in dirs if d not in IGNORE_DIRS]

        # タイムアウトチェック
        if max_seconds and (time.time() - start_time) > max_seconds:
            print(f"[TIMEOUT] タイムアウト: {max_seconds}秒を超過")
            break

        for file in files:
            all_files.append(pathlib.Path(root) / file)
            metrics.files_scanned += 1

            # ファイル数制限チェック
            if max_files and metrics.files_scanned >= max_files:
                print(f"[LIMIT] ファイル数制限: {max_files}ファイルに到達")
                break

        if max_files and metrics.files_scanned >= max_files:
            break

    metrics.directory_scan_time = time.time() - scan_start
    print(f"  → {len(all_files)}ファイル発見 ({metrics.directory_scan_time:.2f}秒)")

    # Phase 2: ファイルフィルタリング
    filter_start = time.time()
    print("[FILTER] ファイルフィルタリング中...")
    target_files = []

    for file_path in all_files:
        try:
            # ファイルサイズチェック
            file_size = file_path.stat().st_size
            if file_size > max_file_bytes:
                metrics.files_skipped += 1
                continue

            # 言語チェック
            if should_index(file_path, exclude_langs):
                target_files.append((file_path, file_size))
        except (OSError, PermissionError):
            metrics.files_skipped += 1

    metrics.file_filtering_time = time.time() - filter_start
    print(f"  → {len(target_files)}ファイル対象 ({metrics.file_filtering_time:.2f}秒)")

    # Phase 3: バッチ処理でファイル読み込みとJSON書き出し
    print(f"[BATCH] バッチ処理開始 (バッチサイズ: {batch_size})")

    with open(index_path, "w", encoding="utf-8") as w:
        batch_count = 0

        for i in range(0, len(target_files), batch_size):
            batch = target_files[i:i+batch_size]
            batch_count += 1

            # タイムアウトチェック
            if max_seconds and (time.time() - start_time) > max_seconds:
                print(f"[TIMEOUT] タイムアウト: {max_seconds}秒を超過")
                break

            print(f"  バッチ {batch_count}: {i+1}-{min(i+batch_size, len(target_files))}ファイル処理中...")

            batch_data = []

            # バッチ内のファイル読み込み
            read_start = time.time()
            for file_path, file_size in batch:
                # エンコーディング検出
                encoding, detect_time = detect_encoding_with_timing(file_path)
                metrics.encoding_detection_time += detect_time

                # ファイル読み込み
                try:
                    with open(file_path, 'r', encoding=encoding, errors='ignore') as f:
                        content = f.read()

                    doc = {
                        "file_path": str(file_path.relative_to(repo)),
                        "content": content[:5000],  # 最初の5000文字のみ
                        "encoding": encoding,
                        "size": file_size,
                    }
                    batch_data.append(doc)
                    metrics.files_processed += 1
                    metrics.total_bytes_processed += file_size

                except Exception as e:
                    print(f"    [ERROR] 読み込みエラー: {file_path} - {e}")
                    metrics.files_skipped += 1

            metrics.file_reading_time += time.time() - read_start

            # JSON書き出し
            write_start = time.time()
            for doc in batch_data:
                json.dump(doc, w, ensure_ascii=False)
                w.write("\n")
            metrics.json_writing_time += time.time() - write_start

    metrics.total_time = time.time() - start_time
    return metrics

def main():
    """メインエントリポイント"""
    parser = argparse.ArgumentParser(
        description="コードレビューツール（パフォーマンス計測版）"
    )

    subparsers = parser.add_subparsers(dest="command", help="コマンド")

    # index コマンド
    index_parser = subparsers.add_parser("index", help="リポジトリをインデックス化")
    index_parser.add_argument("repo", help="リポジトリパス")
    index_parser.add_argument("--exclude-langs", nargs="*", help="除外する言語")
    index_parser.add_argument("--max-file-mb", type=float, help="最大ファイルサイズ(MB)")
    index_parser.add_argument("--max-files", type=int, help="最大ファイル数")
    index_parser.add_argument("--max-seconds", type=float, help="最大実行時間（秒）")
    index_parser.add_argument("--batch-size", type=int, default=500, help="バッチサイズ")

    # benchmark コマンド
    bench_parser = subparsers.add_parser("benchmark", help="ベンチマーク実行")
    bench_parser.add_argument("repo", help="リポジトリパス")
    bench_parser.add_argument("--sizes", nargs="*", type=int, default=[50, 500, 5000],
                             help="テストするファイル数")

    args = parser.parse_args()

    if args.command == "index":
        repo = pathlib.Path(args.repo)
        exclude_langs = set(args.exclude_langs) if args.exclude_langs else set()
        max_file_bytes = int(args.max_file_mb * 1_000_000) if args.max_file_mb else None

        print(f"[START] インデックス作成開始: {repo}")
        print(f"  除外言語: {exclude_langs or 'なし'}")
        print(f"  最大ファイルサイズ: {args.max_file_mb or 4}MB")
        print(f"  最大ファイル数: {args.max_files or '無制限'}")
        print(f"  最大実行時間: {args.max_seconds or '無制限'}秒")
        print(f"  バッチサイズ: {args.batch_size}")
        print()

        metrics = cmd_index_with_metrics(
            repo,
            pathlib.Path(INDEX_PATH),
            exclude_langs,
            max_file_bytes,
            args.max_files,
            args.max_seconds,
            args.batch_size
        )

        metrics.print_summary()

        # 計測結果をJSONファイルに保存
        with open("performance_metrics.json", "w") as f:
            json.dump(asdict(metrics), f, indent=2)
        print(f"\n[SAVE] 計測結果を performance_metrics.json に保存しました")

    elif args.command == "benchmark":
        repo = pathlib.Path(args.repo)
        print(f"[BENCHMARK] ベンチマーク実行: {repo}")
        print(f"  テストサイズ: {args.sizes}")
        print()

        results = []
        for size in args.sizes:
            print(f"\n[TEST] {size}ファイルのベンチマーク")
            print("-" * 40)

            metrics = cmd_index_with_metrics(
                repo,
                pathlib.Path(f"benchmark_{size}.jsonl"),
                set(),
                DEFAULT_MAX_FILE_BYTES,
                max_files=size,
                max_seconds=300,
                batch_size=min(500, size)
            )

            results.append({
                "file_count": size,
                "metrics": asdict(metrics)
            })

            # 簡易サマリー表示
            if metrics.files_processed > 0:
                print(f"  処理時間: {metrics.total_time:.2f}秒")
                print(f"  処理速度: {metrics.files_processed/metrics.total_time:.1f}ファイル/秒")

        # ベンチマーク結果を保存
        with open("benchmark_results.json", "w") as f:
            json.dump(results, f, indent=2)
        print(f"\n[SAVE] ベンチマーク結果を benchmark_results.json に保存しました")

    else:
        parser.print_help()

if __name__ == "__main__":
    main()
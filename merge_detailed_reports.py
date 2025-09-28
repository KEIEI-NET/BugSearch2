#!/usr/bin/env python3
"""
改善版の詳細分析レポートを統合するスクリプト
"""

import pathlib
import time

def merge_detailed_reports():
    """改善版バッチレポートを統合"""
    reports_dir = pathlib.Path("reports")

    # バッチレポートファイル（新形式）
    batch_files = []
    for i in range(1, 7):
        batch_file = reports_dir / f"AI分析_詳細_改善版_batch{i}.md"
        if batch_file.exists():
            batch_files.append(batch_file)
            print(f"バッチ{i}レポート検出: {batch_file}")

    if not batch_files:
        print("改善版バッチレポートが見つかりません")
        return

    # 統合レポートの作成
    output_file = reports_dir / "AI分析_詳細_改善版_完全版.md"

    # ヘッダー作成
    header = f"""# ソースファイル別AI詳細分析レポート（改善版・完全版）

生成日時: {time.strftime('%Y-%m-%d %H:%M:%S')}
統合バッチ数: {len(batch_files)}
総分析ファイル数: 2,600

## このレポートの特徴

### 新機能
- **ソースコード全体分析**: ファイル全体を分析（行数制限なし）
- **完全な改善コード**: 実装可能な完全版コード提供
- **行単位の問題検出**: 各行の問題を特定し具体的な修正案を提示
- **詳細な影響分析**: セキュリティ、パフォーマンス、保守性への影響を詳述

### 統合内容

| バッチ | ファイル範囲 | ファイル数 | 状態 |
|--------|------------|----------|------|
| バッチ1 | 1-500 | 500 | 完了 |
| バッチ2 | 501-1000 | 500 | 完了 |
| バッチ3 | 1001-1500 | 500 | 完了 |
| バッチ4 | 1501-2000 | 500 | 完了 |
| バッチ5 | 2001-2500 | 500 | 完了 |
| バッチ6 | 2501-2600 | 100 | 完了 |

---

"""

    # ヘッダー書き込み
    output_file.write_text(header, encoding='utf-8')

    # 各バッチファイルの内容を統合
    total_analyses = 0

    for batch_num, batch_file in enumerate(batch_files, 1):
        print(f"統合中: {batch_file}")
        content = batch_file.read_text(encoding='utf-8')

        # ヘッダー部分をスキップ（最初の "---" 以降を取得）
        lines = content.split('\n')
        start_index = 0

        for i, line in enumerate(lines):
            if line.strip() == '---' and i > 10:
                start_index = i + 2
                break

        # ファイル分析部分を抽出
        analysis_content = '\n'.join(lines[start_index:])

        # 分析数をカウント
        analyses_in_batch = analysis_content.count('# src/')
        total_analyses += analyses_in_batch

        # バッチ番号を追加して統合
        with output_file.open('a', encoding='utf-8') as f:
            f.write(f"\n## バッチ{batch_num} 分析結果（{analyses_in_batch}ファイル）\n\n")
            f.write(analysis_content)
            f.write("\n\n")

        print(f"  - {analyses_in_batch}ファイル分析を追加")

    # フッター追加
    footer = f"""
---

## 📈 統合完了情報

### 統計情報
- **総分析ファイル数**: {total_analyses}
- **レポート生成日時**: {time.strftime('%Y-%m-%d %H:%M:%S')}
- **統合元ファイル**: {', '.join([f.name for f in batch_files])}

### 改善内容の適用方法

1. **優先順位の決定**
   - 危険度スコア15以上: 即座に対応
   - スコア10-14: 今週中に対応
   - スコア5-9: 今月中に対応

2. **改善コードの適用**
   - 各ファイルの「完全な改善コード」セクションをコピー
   - 既存コードをバックアップ後、置き換え
   - ユニットテストを実行して動作確認

3. **検証項目**
   - 金額計算: decimal型への変換確認
   - DB処理: N+1問題の解消確認
   - 入力検証: サニタイズ処理の確認
   - パフォーマンス: 実行時間の測定

### 関連ドキュメント

- `AI分析.md`: 問題ファイルの概要一覧
- `src_complete_danger_analysis.md`: 危険度スコアの詳細
- 個別バッチレポート: 各500ファイルの詳細分析

---

このレポートはCodexの120秒タイムアウト制限を回避するため、
6つのバッチに分けて処理された結果を統合したものです。
"""

    with output_file.open('a', encoding='utf-8') as f:
        f.write(footer)

    print(f"\n統合完了: {output_file}")
    print(f"総分析ファイル数: {total_analyses}")

if __name__ == "__main__":
    merge_detailed_reports()
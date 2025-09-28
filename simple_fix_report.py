#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
シンプルなレポート修正スクリプト
文字化けとエラーを修正して、クリーンなレポートを生成
"""
import re
from datetime import datetime
from pathlib import Path

def fix_text(text):
    """テキストの文字化けを修正"""
    # 順番が重要 - より長いパターンから置換
    replacements = [
        # 会社名（最初に処理）
        ('Broadleaf Co.,LBroadleaf Co.,LBroadleaf Co.,Ltd', 'Broadleaf Co.,Ltd'),
        ('Broadleaf Co.,LBroadleaf Co.,Ltd', 'Broadleaf Co.,Ltd'),
        ('td.', 'Broadleaf Co.,Ltd.'),
        ('td', 'Broadleaf Co.,Ltd'),

        # システム関連
        ('VXe', 'システム'),
        ('vO', 'プログラム'),
        ('NSV[Y', 'NSシリーズ'),
        ('Tv', 'サマリ'),

        # 管理番号関連（順番重要）
        ('Ǘԍ', '管理番号'),
        ('Ǘ', '管'),
        ('ԍ', '番号'),

        # 作成・修正関連
        ('쐬', '作成'),
        ('作成S', '作成SF'),
        ('修正e', 'Issue'),
        ('修正opyright', 'Copyright'),
        ('修正o', 'Co'),
        ('修正v', 'CSV'),
        ('修正', '修'),  # 最後に処理

        # その他の文字
        ('s', '実行'),
        ('R[h', 'コード'),
        ('F', '：'),
        ('ꗗ', '一覧'),
        ('\\', '表示'),
        ('oʂ', '画面に'),
        ('ɏ', 'に修正'),
        ('ɃR', 'にコ'),
        ('Ƀ', 'に'),
        ('z敪', '金額区分'),
        ('䂪', '誤りが'),
        ('悤', 'よう'),
        ('ɂ', 'にする'),
        ('^Cv', 'タイプ'),
        ('鎞', 'する時'),
        ('擾', '取得'),
        ('鏈', 'する処理'),
        ('ǉ', '追加'),
        ('o͋', '出力区'),
        ('̈', 'の'),
        ('ŏ', 'で'),
        ('̐', 'の'),
        ('Part実行manp', 'Partsman'),
        ('Manti実行y', 'Mantis#'),
    ]

    for old, new in replacements:
        text = text.replace(old, new)

    return text

def main():
    """メイン処理"""
    input_file = Path("reports/AI_analysis_parallel_complete.md")
    output_file = Path("reports/AI_analysis_parallel_clean.md")

    print("[INFO] レポートクリーンアップ開始")

    # ファイル読み込み
    content = input_file.read_text(encoding='utf-8', errors='ignore')
    print(f"[INFO] 元のファイルサイズ: {len(content):,} 文字")

    # エラー行を除去
    lines = content.split('\n')
    clean_lines = []
    skip_count = 0
    fix_count = 0

    for line in lines:
        # APIエラー行をスキップ
        if '[エラー: Error code: 429' in line:
            skip_count += 1
            continue

        # 文字化け修正
        original = line
        fixed = fix_text(line)
        if original != fixed:
            fix_count += 1

        clean_lines.append(fixed)

    # クリーンなコンテンツを生成
    clean_content = '\n'.join(clean_lines)

    # 保存
    output_file.write_text(clean_content, encoding='utf-8')

    print(f"[OK] クリーンレポート保存: {output_file}")
    print(f"[INFO] 修正後のファイルサイズ: {len(clean_content):,} 文字")
    print(f"[INFO] スキップしたエラー行: {skip_count}")
    print(f"[INFO] 文字化け修正行: {fix_count}")

if __name__ == "__main__":
    main()
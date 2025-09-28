#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
レポート文字化け修正スクリプト
"""
import re
import json
from pathlib import Path
import chardet

def detect_encoding(file_path):
    """ファイルのエンコーディングを検出"""
    with open(file_path, 'rb') as f:
        raw_data = f.read(10000)  # 最初の10KBで判定
        result = chardet.detect(raw_data)
        return result['encoding']

def fix_mojibake(text):
    """文字化けパターンを修正"""
    # よくある文字化けパターンの置換辞書
    replacements = {
        'VXe': 'システム',
        'vO': 'プログラム',
        'Ǘԍ': '管理番号',
        '쐬': '作成',
        'C': '修正',
        'Tut': '作成者',
        'NSV[Y': 'NSシリーズ',
        'Tv': 'サマリ',
        's': '実行',
        'R[h': 'コード',
        'ꗗ': '一覧',
        '\\': '表示',
        'o͋': '出力区',
        'z敪': '金額区分',
        '䂪': '誤りが',
        's': '発生',
        '悤': 'よう',
        'ɂ': 'にする',
        '^Cv': 'タイプ',
        '鎞': 'する時',
        'td': 'Broadleaf Co.,Ltd',
        '擾': '取得',
        '鏈': 'する処理',
        'ǉ': '追加',
        'oʂ': '画面に',
        'ɏ': 'に修正',
        'F': '：',
    }

    fixed_text = text
    for old, new in replacements.items():
        fixed_text = fixed_text.replace(old, new)

    return fixed_text

def process_report_file(input_file, output_file):
    """レポートファイルを処理して修正"""
    print(f"[INFO] レポート修正開始: {input_file}")

    # エンコーディング検出
    encoding = detect_encoding(input_file)
    print(f"[INFO] 検出されたエンコーディング: {encoding}")

    # ファイルを読み込み（UTF-8として）
    with open(input_file, 'r', encoding='utf-8', errors='replace') as f:
        content = f.read()

    # エラーエントリを検出して記録
    error_pattern = r'\[エラー: Error code: 429.*?\]'
    errors = re.findall(error_pattern, content)
    print(f"[INFO] 検出されたAPIエラー: {len(errors)}件")

    # ファイル名ヘッダーのパターンを探す
    header_pattern = r'^## \d+\. (.+?)$'

    # 文字化けを修正
    fixed_content = fix_mojibake(content)

    # エラーエントリを含むセクションを特定して修正
    sections = fixed_content.split('\n---\n')
    fixed_sections = []
    error_count = 0
    fixed_count = 0

    for section in sections:
        # エラーを含むセクションをスキップまたは修正
        if '[エラー: Error code: 429' in section:
            error_count += 1
            # ファイル名が欠落している場合、セクション全体をスキップ
            if not re.search(r'^## \d+\.', section, re.MULTILINE):
                continue  # このセクションをスキップ

        # 文字化けが修正されたセクションを記録
        if section != fix_mojibake(section):
            fixed_count += 1

        fixed_sections.append(section)

    # 修正されたコンテンツを結合
    fixed_content = '\n---\n'.join(fixed_sections)

    # 統計情報を更新
    stats_pattern = r'(総分析ファイル数: )(\d+)'
    actual_count = len([s for s in fixed_sections if s.strip() and not '[エラー: Error code: 429' in s])
    fixed_content = re.sub(stats_pattern, f'\\1{actual_count}', fixed_content)

    # 修正されたファイルを保存
    with open(output_file, 'w', encoding='utf-8') as f:
        f.write(fixed_content)

    print(f"[OK] レポート修正完了: {output_file}")
    print(f"  - エラーセクション除去: {error_count}件")
    print(f"  - 文字化け修正: {fixed_count}件")
    print(f"  - 最終セクション数: {len(fixed_sections)}件")

    return {
        'error_sections': error_count,
        'fixed_sections': fixed_count,
        'total_sections': len(fixed_sections),
        'errors': errors[:5] if errors else []  # 最初の5件のエラーサンプル
    }

def extract_failed_files():
    """処理に失敗したファイルのリストを抽出"""
    report_file = "reports/AI_analysis_parallel_complete.md"

    if not Path(report_file).exists():
        print(f"[ERROR] レポートファイルが見つかりません: {report_file}")
        return []

    with open(report_file, 'r', encoding='utf-8', errors='replace') as f:
        content = f.read()

    # エラーパターンを探す
    error_pattern = r'\[エラー: Error code: 429.*?\n\n---\n\n(.+?)\n'
    matches = re.findall(error_pattern, content, re.DOTALL)

    failed_files = []
    for match in matches:
        # ファイルパスを抽出する試み
        if 'src/' in match:
            path_match = re.search(r'(src/[^\s]+\.(?:cs|js|py|go|java|cpp|h))', match)
            if path_match:
                failed_files.append(path_match.group(1))

    return list(set(failed_files))

def main():
    """メイン処理"""
    # レポートファイルのパス
    input_file = "reports/AI_analysis_parallel_complete.md"
    output_file = "reports/AI_analysis_parallel_fixed.md"

    # バックアップ作成
    backup_file = "reports/AI_analysis_parallel_complete_backup.md"
    if Path(input_file).exists():
        print(f"[INFO] バックアップ作成: {backup_file}")
        with open(input_file, 'r', encoding='utf-8', errors='replace') as f:
            backup_content = f.read()
        with open(backup_file, 'w', encoding='utf-8') as f:
            f.write(backup_content)

    # レポート修正
    result = process_report_file(input_file, output_file)

    # 失敗したファイルリストを保存
    failed_files = extract_failed_files()
    if failed_files:
        failed_list_file = "failed_files.json"
        with open(failed_list_file, 'w', encoding='utf-8') as f:
            json.dump({
                'total': len(failed_files),
                'files': failed_files
            }, f, indent=2, ensure_ascii=False)
        print(f"\n[INFO] 失敗ファイルリスト保存: {failed_list_file}")
        print(f"  - 失敗ファイル数: {len(failed_files)}")

    # サマリー表示
    print("\n" + "="*60)
    print("修正結果サマリー")
    print("="*60)
    print(f"エラーセクション除去: {result['error_sections']}件")
    print(f"文字化け修正: {result['fixed_sections']}件")
    print(f"最終セクション数: {result['total_sections']}件")

    if result['errors']:
        print("\nエラーサンプル:")
        for i, error in enumerate(result['errors'], 1):
            print(f"  {i}. {error[:100]}...")

if __name__ == "__main__":
    main()
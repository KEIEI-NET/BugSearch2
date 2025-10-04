#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
apply_improvements_from_report.py - 完全レポートから改善コードを適用

完全レポート（Markdown形式）を解析し、「改善されたソースコード」セクションを抽出して、
実際のソースファイルに自動適用するツール。

使用例:
    # Dry-run（プレビューのみ）
    python apply_improvements_from_report.py reports/complete_analysis.md --dry-run

    # 実際に適用
    python apply_improvements_from_report.py reports/complete_analysis.md --apply

    # ロールバック
    python apply_improvements_from_report.py --rollback backups/file.py.20251004_153045.bak
"""
from __future__ import annotations
import argparse
import json
import pathlib
import re
import shutil
import sys
import time
from datetime import datetime
from typing import List, Dict, Any, Optional

# ===== 設定 =====
DEFAULT_BACKUP_DIR = "backups"
DEFAULT_OUTPUT_REPORT = "reports/apply_summary.md"
APPLY_LOG_FILE = ".apply_log.jsonl"

# ===== レポート解析 =====
def parse_complete_report(report_path: str) -> List[Dict[str, Any]]:
    """
    完全レポート（Markdown形式）を解析してファイルエントリのリストを返す

    Args:
        report_path: 完全レポートのパス

    Returns:
        [{
            'file_path': str,
            'lang': str,
            'severity': int,
            'problems': List[str],
            'original_code': Optional[str],
            'improved_code': Optional[str],
            'has_improvement': bool
        }, ...]
    """
    report_file = pathlib.Path(report_path)
    if not report_file.exists():
        raise FileNotFoundError(f"レポートファイルが見つかりません: {report_path}")

    content = report_file.read_text(encoding='utf-8')
    entries = []

    # ファイルエントリを検出（### N. ファイルパス）
    file_pattern = re.compile(r'^### (\d+)\. (.+)$', re.MULTILINE)
    matches = list(file_pattern.finditer(content))

    for i, match in enumerate(matches):
        entry_num = match.group(1)
        file_path = match.group(2).strip()

        # このエントリの開始位置と終了位置を特定
        start_pos = match.end()
        end_pos = matches[i + 1].start() if i + 1 < len(matches) else len(content)
        entry_content = content[start_pos:end_pos]

        # 言語を抽出
        lang_match = re.search(r'- \*\*言語\*\*: (.+)', entry_content)
        lang = lang_match.group(1).strip() if lang_match else 'unknown'

        # 重要度を抽出
        severity_match = re.search(r'\(スコア: (\d+)\)', entry_content)
        severity = int(severity_match.group(1)) if severity_match else 0

        # 検出された問題を抽出
        problems = []
        problems_section = re.search(r'#### 検出された問題:(.*?)(?:####|$)', entry_content, re.DOTALL)
        if problems_section:
            problem_lines = problems_section.group(1).strip().split('\n')
            for line in problem_lines:
                line = line.strip()
                if line.startswith('-'):
                    # "- [優先度] 問題文" から問題文を抽出
                    problem_text = re.sub(r'^- \[.+?\] ', '', line)
                    problems.append(problem_text)

        # 元のソースコードを抽出
        original_code = None
        original_section = re.search(r'#### 元のソースコード:\s*```[\w+]*\s*(.*?)\s*```', entry_content, re.DOTALL)
        if original_section:
            original_code = original_section.group(1).strip()

        # 改善されたソースコードを抽出
        improved_code = None
        has_improvement = False
        improved_section = re.search(r'#### 改善されたソースコード:\s*```[\w+]*\s*(.*?)\s*```', entry_content, re.DOTALL)
        if improved_section:
            improved_text = improved_section.group(1).strip()
            # 「コードレビュー助言（修正コード出力なし）」チェック
            if '# コードレビュー助言（修正コード出力なし）' not in improved_text and len(improved_text) >= 50:
                improved_code = improved_text
                has_improvement = True

        entries.append({
            'entry_num': entry_num,
            'file_path': file_path,
            'lang': lang,
            'severity': severity,
            'problems': problems,
            'original_code': original_code,
            'improved_code': improved_code,
            'has_improvement': has_improvement
        })

    print(f"[INFO] レポート解析完了: {len(entries)}件のファイルエントリを検出")
    print(f"[INFO] 改善コードあり: {sum(1 for e in entries if e['has_improvement'])}件")
    print(f"[INFO] 助言のみ: {sum(1 for e in entries if not e['has_improvement'])}件")

    return entries

# ===== 改善コード抽出 =====
def extract_improvement_code(entry: Dict[str, Any]) -> Optional[str]:
    """
    改善コードを抽出（助言のみの場合はNone）

    Args:
        entry: ファイルエントリ辞書

    Returns:
        改善されたコード文字列 or None
    """
    if not entry['has_improvement']:
        return None

    return entry['improved_code']

# ===== バックアップ作成 =====
def create_backup(file_path: str, backup_dir: str = DEFAULT_BACKUP_DIR) -> str:
    """
    ファイルのバックアップを作成

    Args:
        file_path: バックアップ対象ファイルパス
        backup_dir: バックアップディレクトリ

    Returns:
        バックアップファイルパス
    """
    source_path = pathlib.Path(file_path)
    if not source_path.exists():
        raise FileNotFoundError(f"ファイルが存在しません: {file_path}")

    backup_path_obj = pathlib.Path(backup_dir)
    backup_path_obj.mkdir(parents=True, exist_ok=True)

    # タイムスタンプ付きバックアップファイル名
    timestamp = datetime.now().strftime('%Y%m%d_%H%M%S')
    backup_file_name = f"{source_path.name}.{timestamp}.bak"
    backup_file_path = backup_path_obj / backup_file_name

    # バックアップコピー
    shutil.copy2(source_path, backup_file_path)

    return str(backup_file_path)

# ===== ファイル適用 =====
def apply_improvement(file_path: str, improved_code: str,
                     dry_run: bool = True,
                     backup_dir: str = DEFAULT_BACKUP_DIR,
                     skip_backup: bool = False) -> Dict[str, Any]:
    """
    改善コードをファイルに適用

    Args:
        file_path: 適用先ファイルパス
        improved_code: 改善されたコード
        dry_run: Dry-runモード（実際の変更なし）
        backup_dir: バックアップディレクトリ
        skip_backup: バックアップをスキップ

    Returns:
        {
            'status': 'success' | 'skipped' | 'error',
            'file_path': str,
            'backup_path': str or None,
            'message': str
        }
    """
    target_path = pathlib.Path(file_path)

    # ファイル存在チェック
    if not target_path.exists():
        return {
            'status': 'error',
            'file_path': file_path,
            'backup_path': None,
            'message': f'ファイルが存在しません: {file_path}'
        }

    # Dry-runモード
    if dry_run:
        return {
            'status': 'skipped',
            'file_path': file_path,
            'backup_path': None,
            'message': '[DRY-RUN] 適用をシミュレートしました'
        }

    # バックアップ作成
    backup_path = None
    if not skip_backup:
        try:
            backup_path = create_backup(file_path, backup_dir)
        except Exception as e:
            return {
                'status': 'error',
                'file_path': file_path,
                'backup_path': None,
                'message': f'バックアップ作成失敗: {e}'
            }

    # ファイルに書き込み
    try:
        with open(target_path, 'w', encoding='utf-8', newline='\n') as f:
            f.write(improved_code)

        return {
            'status': 'success',
            'file_path': file_path,
            'backup_path': backup_path,
            'message': '適用成功'
        }
    except Exception as e:
        return {
            'status': 'error',
            'file_path': file_path,
            'backup_path': backup_path,
            'message': f'ファイル書き込み失敗: {e}'
        }

# ===== ロールバック =====
def rollback_changes(backup_path: str, original_path: str = None) -> bool:
    """
    バックアップから復元

    Args:
        backup_path: バックアップファイルパス
        original_path: 復元先パス（Noneの場合はバックアップファイル名から推測）

    Returns:
        True: 成功, False: 失敗
    """
    backup_file = pathlib.Path(backup_path)
    if not backup_file.exists():
        print(f"[ERROR] バックアップファイルが存在しません: {backup_path}")
        return False

    # 復元先を特定
    if original_path is None:
        # バックアップファイル名から元のファイル名を推測
        # 例: codex_review_severity.py.20251004_153045.bak -> codex_review_severity.py
        name_parts = backup_file.name.split('.')
        if len(name_parts) >= 4 and name_parts[-1] == 'bak':
            # .{timestamp}.bak を除去
            original_name = '.'.join(name_parts[:-2])
            original_path = str(backup_file.parent.parent / original_name)
        else:
            print(f"[ERROR] バックアップファイル名から元のファイル名を推測できません: {backup_path}")
            return False

    try:
        shutil.copy2(backup_file, original_path)
        print(f"[OK] ロールバック成功: {original_path}")
        return True
    except Exception as e:
        print(f"[ERROR] ロールバック失敗: {e}")
        return False

# ===== レポート生成 =====
def generate_apply_report(entries: List[Dict], results: List[Dict],
                         report_path: str, output_path: str = DEFAULT_OUTPUT_REPORT) -> str:
    """
    適用サマリーレポートを生成

    Args:
        entries: 解析されたエントリリスト
        results: 適用結果リスト
        report_path: 元のレポートパス
        output_path: 出力レポートパス

    Returns:
        レポート文字列（Markdown形式）
    """
    # 統計情報
    total = len(results)
    success_count = sum(1 for r in results if r['status'] == 'success')
    skipped_count = sum(1 for r in results if r['status'] == 'skipped')
    error_count = sum(1 for r in results if r['status'] == 'error')

    lines = [
        "# 改善コード適用サマリー",
        "",
        f"**実行日時**: {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}",
        f"**元レポート**: {report_path}",
        "",
        "## 統計",
        f"- 適用成功: {success_count}件",
        f"- スキップ: {skipped_count}件",
        f"- エラー: {error_count}件",
        f"- **合計**: {total}件",
        ""
    ]

    # 適用成功ファイル
    if success_count > 0:
        lines.append("## ✅ 適用済みファイル")
        lines.append("")
        for i, result in enumerate(filter(lambda r: r['status'] == 'success', results), 1):
            entry = next((e for e in entries if e['file_path'] == result['file_path']), None)
            lines.append(f"### {i}. {result['file_path']}")
            lines.append(f"- **状態**: ✅ 成功")
            if result['backup_path']:
                lines.append(f"- **バックアップ**: {result['backup_path']}")
            if entry:
                lines.append(f"- **重要度**: {entry['severity']}")
                if entry['problems']:
                    lines.append(f"- **問題**: {entry['problems'][0]}")
            lines.append("")

    # スキップファイル
    if skipped_count > 0:
        lines.append("## ⏭️ スキップファイル")
        lines.append("")
        for i, result in enumerate(filter(lambda r: r['status'] == 'skipped', results), 1):
            entry = next((e for e in entries if e['file_path'] == result['file_path']), None)
            lines.append(f"### {i}. {result['file_path']}")
            lines.append(f"- **状態**: ⏭️ スキップ")
            lines.append(f"- **理由**: {result['message']}")
            if entry and not entry['has_improvement']:
                lines.append(f"- **詳細**: 改善コードが生成されていません（助言のみ）")
            lines.append("")

    # エラーファイル
    if error_count > 0:
        lines.append("## ❌ エラーファイル")
        lines.append("")
        for i, result in enumerate(filter(lambda r: r['status'] == 'error', results), 1):
            lines.append(f"### {i}. {result['file_path']}")
            lines.append(f"- **状態**: ❌ エラー")
            lines.append(f"- **エラー**: {result['message']}")
            lines.append("")

    # レポート生成
    report_content = "\n".join(lines)

    # ファイルに書き込み
    output_file = pathlib.Path(output_path)
    output_file.parent.mkdir(parents=True, exist_ok=True)
    with open(output_file, 'w', encoding='utf-8', newline='\n') as f:
        f.write(report_content)

    print(f"[OK] 適用サマリーレポート生成: {output_path}")

    return report_content

# ===== ログ記録 =====
def log_apply_result(result: Dict[str, Any], log_file: str = APPLY_LOG_FILE):
    """
    適用結果をJSONL形式でログに記録

    Args:
        result: 適用結果辞書
        log_file: ログファイルパス
    """
    log_entry = {
        'timestamp': datetime.now().isoformat(),
        **result
    }

    with open(log_file, 'a', encoding='utf-8') as f:
        f.write(json.dumps(log_entry, ensure_ascii=False) + '\n')

# ===== メイン処理 =====
def main(report_path: str, dry_run: bool = True, file_filter: Optional[str] = None,
         backup_dir: str = DEFAULT_BACKUP_DIR, output_report: str = DEFAULT_OUTPUT_REPORT,
         skip_backup: bool = False, verbose: bool = False):
    """
    メイン処理

    Args:
        report_path: 完全レポートのパス
        dry_run: Dry-runモード
        file_filter: ファイル名フィルタ（glob形式）
        backup_dir: バックアップディレクトリ
        output_report: 適用サマリーレポート出力先
        skip_backup: バックアップをスキップ
        verbose: 詳細ログ表示
    """
    print(f"\n{'='*80}")
    print(f"完全レポート改善コード適用ツール")
    print(f"{'='*80}")
    print(f"[INFO] モード: {'DRY-RUN（プレビューのみ）' if dry_run else '実際に適用'}")
    print(f"[INFO] レポート: {report_path}")
    if file_filter:
        print(f"[INFO] フィルタ: {file_filter}")
    print(f"{'='*80}\n")

    # レポート解析
    try:
        entries = parse_complete_report(report_path)
    except Exception as e:
        print(f"[ERROR] レポート解析失敗: {e}")
        sys.exit(1)

    # 改善コードありのエントリのみ処理
    apply_entries = [e for e in entries if e['has_improvement']]

    # ファイルフィルタ適用
    if file_filter:
        from fnmatch import fnmatch
        apply_entries = [e for e in apply_entries if fnmatch(e['file_path'], file_filter)]
        print(f"[INFO] フィルタ適用後: {len(apply_entries)}件")

    if not apply_entries:
        print("[WARNING] 適用可能なファイルがありません")
        return

    # 各ファイルに適用
    results = []
    for i, entry in enumerate(apply_entries, 1):
        file_path = entry['file_path']
        improved_code = extract_improvement_code(entry)

        if improved_code is None:
            continue

        print(f"[{i}/{len(apply_entries)}] 処理中: {file_path} (重要度: {entry['severity']})")

        result = apply_improvement(
            file_path,
            improved_code,
            dry_run=dry_run,
            backup_dir=backup_dir,
            skip_backup=skip_backup
        )

        results.append(result)

        # ログ記録
        if not dry_run:
            log_apply_result(result)

        if verbose:
            print(f"  → {result['status']}: {result['message']}")

    # 助言のみのエントリも結果に含める（スキップとして）
    for entry in entries:
        if not entry['has_improvement']:
            results.append({
                'status': 'skipped',
                'file_path': entry['file_path'],
                'backup_path': None,
                'message': '改善コードなし（助言のみ）'
            })

    # サマリーレポート生成
    generate_apply_report(entries, results, report_path, output_report)

    # サマリー表示
    print(f"\n{'='*80}")
    print(f"処理完了")
    print(f"{'='*80}")
    print(f"[INFO] 適用成功: {sum(1 for r in results if r['status'] == 'success')}件")
    print(f"[INFO] スキップ: {sum(1 for r in results if r['status'] == 'skipped')}件")
    print(f"[INFO] エラー: {sum(1 for r in results if r['status'] == 'error')}件")
    print(f"[INFO] 合計: {len(results)}件")
    print(f"{'='*80}\n")

# ===== CLI =====
if __name__ == "__main__":
    parser = argparse.ArgumentParser(
        description="完全レポートから改善コードを適用",
        formatter_class=argparse.RawDescriptionHelpFormatter,
        epilog="""
使用例:
  # Dry-run（プレビューのみ）
  python apply_improvements_from_report.py reports/complete.md --dry-run

  # 実際に適用
  python apply_improvements_from_report.py reports/complete.md --apply

  # 特定のファイルのみ適用
  python apply_improvements_from_report.py reports/complete.md --apply --filter "codex_*.py"

  # ロールバック
  python apply_improvements_from_report.py --rollback backups/file.py.20251004_153045.bak
        """
    )

    parser.add_argument("report_path", nargs='?', help="完全レポートのパス (.md)")
    parser.add_argument("--dry-run", action="store_true", default=False,
                       help="実際の変更なしでプレビュー")
    parser.add_argument("--apply", action="store_true",
                       help="実際にファイルに適用")
    parser.add_argument("--filter", type=str,
                       help="ファイル名フィルタ（glob形式、例: 'codex_*.py'）")
    parser.add_argument("--backup-dir", type=str, default=DEFAULT_BACKUP_DIR,
                       help=f"バックアップディレクトリ（デフォルト: {DEFAULT_BACKUP_DIR}）")
    parser.add_argument("--out", type=str, default=DEFAULT_OUTPUT_REPORT,
                       help=f"適用サマリーレポート出力先（デフォルト: {DEFAULT_OUTPUT_REPORT}）")
    parser.add_argument("--rollback", type=str,
                       help="バックアップから復元（バックアップファイルパスを指定）")
    parser.add_argument("--skip-backup", action="store_true",
                       help="バックアップを作成しない（非推奨）")
    parser.add_argument("--verbose", "-v", action="store_true",
                       help="詳細ログ表示")

    args = parser.parse_args()

    # ロールバックモード
    if args.rollback:
        success = rollback_changes(args.rollback)
        sys.exit(0 if success else 1)

    # レポートパス必須チェック
    if not args.report_path:
        parser.print_help()
        sys.exit(1)

    # Dry-run vs Apply モード
    dry_run = not args.apply
    if not args.apply and not args.dry_run:
        # どちらも指定されていない場合はdry-runをデフォルトに
        dry_run = True
        print("[INFO] モード未指定のため、Dry-runモードで実行します")
        print("[INFO] 実際に適用するには --apply オプションを使用してください\n")

    main(
        report_path=args.report_path,
        dry_run=dry_run,
        file_filter=args.filter,
        backup_dir=args.backup_dir,
        output_report=args.out,
        skip_backup=args.skip_backup,
        verbose=args.verbose
    )

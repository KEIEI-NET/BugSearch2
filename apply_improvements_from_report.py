#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
apply_improvements_from_report.py - 完全レポートから改善コードを適用

完全レポート（Markdown形式）を解析し、「改善されたソースコード」セクションを抽出して、
実際のソースファイルに自動適用するツール。

セキュリティ機能:
    - パストラバーサル攻撃防止（パス検証）
    - ReDoS対策（ファイルサイズ制限）
    - アトミックファイル書き込み（データ損失防止）
    - バックアップとロールバック機能

使用例:
    # Dry-run（プレビューのみ）
    python apply_improvements_from_report.py reports/complete_analysis.md --dry-run

    # 実際に適用
    python apply_improvements_from_report.py reports/complete_analysis.md --apply

    # ロールバック
    python apply_improvements_from_report.py --rollback backups/file.py.20251004_153045.bak

バージョン: 2.0.0 (セキュリティ強化版)
"""
from __future__ import annotations
import argparse
import json
import os
import pathlib
import re
import shutil
import stat
import sys
import tempfile
import time
from datetime import datetime
from typing import List, Dict, Any, Optional

# ===== 設定 =====
DEFAULT_BACKUP_DIR = "backups"
DEFAULT_OUTPUT_REPORT = "reports/apply_summary.md"
APPLY_LOG_FILE = ".apply_log.jsonl"
MIN_MEANINGFUL_CODE_LENGTH = 50  # 最小有効コード長
MAX_REPORT_SIZE_MB = 100  # 最大レポートサイズ (MB)

# 許可されたベースディレクトリ (セキュリティ)
ALLOWED_BASE_DIRS = ['.', './src', './test', './reports']

# コンパイル済み正規表現パターン（パフォーマンス最適化）
FILE_PATTERN = re.compile(r'^### (\d+)\. (.+)$', re.MULTILINE)
LANG_PATTERN = re.compile(r'- \*\*言語\*\*: (.+)')
SEVERITY_PATTERN = re.compile(r'\(スコア: (\d+)\)')
PROBLEMS_SECTION_PATTERN = re.compile(r'#### 検出された問題:(.*?)(?:####|$)', re.DOTALL)
PROBLEM_LINE_PATTERN = re.compile(r'^- \[.+?\] ')
ORIGINAL_CODE_PATTERN = re.compile(r'#### 元のソースコード:\s*```[\w+]*\s*(.*?)\s*```', re.DOTALL)
IMPROVED_CODE_PATTERN = re.compile(r'#### 改善されたソースコード:\s*```[\w+]*\s*(.*?)\s*```', re.DOTALL)
BACKUP_FILENAME_PATTERN = re.compile(r'^(.+)\.(\d{8}_\d{6})(?:_\d{3})?\.bak$')

# 改善コード検証設定
MAX_IMPROVED_CODE_SIZE_KB = 1024  # 最大1MBまで許可
MAX_IMPROVED_CODE_LINES = 10000  # 最大行数

# ===== セキュリティ関数 =====
def validate_improved_code(code: str, max_size_kb: int = MAX_IMPROVED_CODE_SIZE_KB) -> None:
    """
    改善コード内容を検証

    Args:
        code: コード内容
        max_size_kb: 最大サイズ（KB）

    Raises:
        ValueError: 検証失敗時
    """
    # NULL文字チェック
    if '\x00' in code:
        raise ValueError("不正な文字が含まれています: null byte (\\x00)")

    # サイズ制限チェック
    code_size_kb = len(code.encode('utf-8')) / 1024
    if code_size_kb > max_size_kb:
        raise ValueError(
            f"改善コードが大きすぎます: {code_size_kb:.1f}KB (最大: {max_size_kb}KB)"
        )

    # UTF-8エンコーディング検証
    try:
        code.encode('utf-8')
    except UnicodeEncodeError as e:
        raise ValueError(f"不正なエンコーディング: {e}")

    # 行数チェック（バイナリデータ検出）
    lines = code.split('\n')
    if len(lines) > MAX_IMPROVED_CODE_LINES:
        raise ValueError(f"行数が多すぎます: {len(lines)}行 (最大: {MAX_IMPROVED_CODE_LINES}行)")

    # 制御文字検出（ASCII + Unicode）
    for i, char in enumerate(code):
        # 許可された空白文字
        if char in ('\t', '\n', '\r', ' '):
            continue

        # ASCII制御文字検出
        if ord(char) < 0x20 or ord(char) == 0x7F:
            raise ValueError(f"不正な制御文字が含まれています: 位置{i}, U+{ord(char):04X}")

        # Unicode制御文字検出（C0/C1セット）
        if 0x80 <= ord(char) <= 0x9F:
            raise ValueError(f"不正なUnicode制御文字: 位置{i}, U+{ord(char):04X}")

def validate_safe_path(file_path: str, base_dirs: List[str] = None) -> pathlib.Path:
    """
    ファイルパスを検証し、パストラバーサル攻撃を防止

    Args:
        file_path: 検証するファイルパス
        base_dirs: 許可されたベースディレクトリのリスト

    Returns:
        検証済みの絶対パス

    Raises:
        ValueError: パスが許可されたディレクトリ外、またはシンボリックリンクの場合
    """
    if base_dirs is None:
        base_dirs = ALLOWED_BASE_DIRS

    try:
        # ファイルパスを正規化
        target = pathlib.Path(file_path)

        # 絶対パスの場合は拒否
        if target.is_absolute():
            raise ValueError(f"絶対パスは許可されていません: {file_path}")

        # 現在のディレクトリからの相対パスとして解決
        current_dir = pathlib.Path('.').resolve()
        resolved_target = (current_dir / target).resolve(strict=False)

        # lstat()を使用してシンボリックリンク検出（TOCTOUを回避）
        try:
            stat_result = resolved_target.lstat()
            if stat.S_ISLNK(stat_result.st_mode):
                raise ValueError(f"セキュリティエラー: シンボリックリンクは許可されていません: {file_path}")
        except FileNotFoundError:
            # ファイルが存在しない場合は許可（新規ファイル作成時）
            pass

        # 許可されたディレクトリ内かチェック
        for base_dir in base_dirs:
            base = (current_dir / base_dir).resolve()
            try:
                resolved_target.relative_to(base)
                return resolved_target
            except ValueError:
                continue

        # すべてのベースディレクトリで失敗
        raise ValueError(
            f"セキュリティエラー: パスが許可されたディレクトリ外です: {file_path}\n"
            f"許可ディレクトリ: {', '.join(base_dirs)}"
        )

    except Exception as e:
        if isinstance(e, ValueError):
            raise
        raise ValueError(f"パス検証エラー: {file_path} - {e}")

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

    # セキュリティ: ファイルサイズチェック (ReDoS対策)
    file_size_mb = report_file.stat().st_size / (1024 * 1024)
    if file_size_mb > MAX_REPORT_SIZE_MB:
        raise ValueError(
            f"レポートファイルが大きすぎます: {file_size_mb:.1f}MB (最大: {MAX_REPORT_SIZE_MB}MB)"
        )

    # セキュリティ: レポートパスを検証
    try:
        validate_safe_path(report_path, ['.', './reports'])
    except ValueError as e:
        print(f"[WARNING] {e}")
        print(f"[WARNING] 信頼できないレポートの可能性があります")

    content = report_file.read_text(encoding='utf-8')
    entries = []

    # ファイルエントリを検出（### N. ファイルパス）- コンパイル済みパターン使用
    matches = list(FILE_PATTERN.finditer(content))

    for i, match in enumerate(matches):
        entry_num = match.group(1)
        file_path = match.group(2).strip()

        # このエントリの開始位置と終了位置を特定
        start_pos = match.end()
        end_pos = matches[i + 1].start() if i + 1 < len(matches) else len(content)
        entry_content = content[start_pos:end_pos]

        # 言語を抽出 - コンパイル済みパターン使用
        lang_match = LANG_PATTERN.search(entry_content)
        lang = lang_match.group(1).strip() if lang_match else 'unknown'

        # 重要度を抽出 - コンパイル済みパターン使用
        severity_match = SEVERITY_PATTERN.search(entry_content)
        severity = int(severity_match.group(1)) if severity_match else 0

        # 検出された問題を抽出 - コンパイル済みパターン使用
        problems = []
        problems_section = PROBLEMS_SECTION_PATTERN.search(entry_content)
        if problems_section:
            problem_lines = problems_section.group(1).strip().split('\n')
            for line in problem_lines:
                line = line.strip()
                if line.startswith('-'):
                    # "- [優先度] 問題文" から問題文を抽出
                    problem_text = PROBLEM_LINE_PATTERN.sub('', line)
                    problems.append(problem_text)

        # 元のソースコードを抽出 - コンパイル済みパターン使用
        original_code = None
        original_section = ORIGINAL_CODE_PATTERN.search(entry_content)
        if original_section:
            original_code = original_section.group(1).strip()

        # 改善されたソースコードを抽出 - コンパイル済みパターン使用
        improved_code = None
        has_improvement = False
        improved_section = IMPROVED_CODE_PATTERN.search(entry_content)
        if improved_section:
            improved_text = improved_section.group(1).strip()
            # 「コードレビュー助言（修正コード出力なし）」チェック
            if ('# コードレビュー助言（修正コード出力なし）' not in improved_text
                and len(improved_text) >= MIN_MEANINGFUL_CODE_LENGTH):
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

# ===== アトミック書き込み =====
def atomic_write(file_path: pathlib.Path, content: str, encoding: str = 'utf-8') -> None:
    """
    アトミックなファイル書き込み（プロセスセーフ版）

    Args:
        file_path: 書き込み先ファイルパス
        content: 書き込む内容
        encoding: エンコーディング

    Raises:
        Exception: 書き込み失敗時
    """
    # tempfile.mkstemp()で一意な一時ファイル作成（プロセス間競合回避）
    fd = None
    temp_path = None

    try:
        fd, temp_name = tempfile.mkstemp(
            dir=file_path.parent,
            prefix=f'.{file_path.name}.',
            suffix='.tmp',
            text=False  # バイナリモード
        )
        temp_path = pathlib.Path(temp_name)

        # ファイルディスクリプタ経由で書き込み
        try:
            with os.fdopen(fd, 'w', encoding=encoding, newline='\n') as f:
                f.write(content)
                f.flush()
                os.fsync(f.fileno())  # ディスクに確実に書き込み
            fd = None  # fdopenのコンテキストマネージャーが閉じた
        except Exception:
            # fdopenは成功したがwrite失敗 - コンテキストマネージャーが既に閉じた
            fd = None
            raise

        # 権限設定（UNIX: 0o600、Windows: 現状維持）
        if os.name != 'nt':
            os.chmod(temp_path, 0o600)

        # アトミックリネーム（POSIXではアトミック、Windowsでも最善の努力）
        temp_path.replace(file_path)
        temp_path = None  # 成功したのでクリーンアップ不要

    except Exception:
        # 失敗時は一時ファイルをクリーンアップ
        if fd is not None:
            try:
                os.close(fd)
            except:
                pass
        if temp_path and temp_path.exists():
            try:
                temp_path.unlink()
            except:
                pass
        raise

# ===== バックアップ作成 =====
def create_backup(file_path: str, backup_dir: str = DEFAULT_BACKUP_DIR) -> str:
    """
    ファイルのバックアップを作成（アトミック保証＋メタデータ）

    Args:
        file_path: バックアップ対象ファイルパス
        backup_dir: バックアップディレクトリ

    Returns:
        バックアップファイルパス

    Raises:
        FileNotFoundError: ファイルが存在しない
        ValueError: シンボリックリンク
    """
    source_path = pathlib.Path(file_path)
    if not source_path.exists():
        raise FileNotFoundError(f"ファイルが存在しません: {file_path}")

    # シンボリックリンク拒否
    if source_path.is_symlink():
        raise ValueError(f"シンボリックリンクはバックアップできません: {file_path}")

    # バックアップディレクトリのパス検証
    backup_path_obj = pathlib.Path(backup_dir)

    # セキュリティ: バックアップディレクトリが許可されたパスか検証
    try:
        validated_backup_dir = validate_safe_path(backup_dir, ['.', './backups', './backup'])
        backup_path_obj = validated_backup_dir
    except ValueError:
        # デフォルトのbackupsディレクトリにフォールバック
        backup_path_obj = pathlib.Path(DEFAULT_BACKUP_DIR)
        print(f"[WARNING] バックアップディレクトリが無効です。デフォルトを使用: {DEFAULT_BACKUP_DIR}", file=sys.stderr)

    backup_path_obj.mkdir(parents=True, exist_ok=True)

    # タイムスタンプ付きバックアップファイル名
    timestamp = datetime.now().strftime('%Y%m%d_%H%M%S')
    backup_file_name = f"{source_path.name}.{timestamp}.bak"
    backup_file_path = backup_path_obj / backup_file_name

    # 重複防止（マイクロ秒追加）
    counter = 0
    while backup_file_path.exists():
        counter += 1
        backup_file_name = f"{source_path.name}.{timestamp}_{counter:03d}.bak"
        backup_file_path = backup_path_obj / backup_file_name

    # アトミックバックアップ（一時ファイル経由）
    temp_fd = None
    temp_backup = None
    try:
        # 一時ファイルにコピー
        temp_fd, temp_name = tempfile.mkstemp(
            dir=backup_path_obj,
            prefix=f'.{backup_file_name}.',
            suffix='.tmp'
        )
        os.close(temp_fd)  # fdは不要
        temp_fd = None
        temp_backup = pathlib.Path(temp_name)

        # コピー実行
        shutil.copy2(source_path, temp_backup)

        # アトミックリネーム
        temp_backup.replace(backup_file_path)
        temp_backup = None  # 成功

    except Exception:
        # 失敗時のクリーンアップ
        if temp_fd is not None:
            try:
                os.close(temp_fd)
            except:
                pass
        if temp_backup and temp_backup.exists():
            try:
                temp_backup.unlink()
            except:
                pass
        raise

    # メタデータJSON生成（復元用、アトミック書き込み）
    metadata_path = backup_file_path.with_suffix('.json')
    metadata_content = json.dumps({
        'original_path': str(source_path.resolve()),
        'backup_timestamp': timestamp,
        'file_size': source_path.stat().st_size
    }, indent=2, ensure_ascii=False)

    try:
        atomic_write(metadata_path, metadata_content)
    except Exception:
        # メタデータ失敗は致命的でない（警告のみ）
        print(f"[WARNING] メタデータ生成失敗: {backup_file_path}", file=sys.stderr)

    return str(backup_file_path)

# ===== ファイル適用 =====
def apply_improvement(file_path: str, improved_code: str,
                     dry_run: bool = True,
                     backup_dir: str = DEFAULT_BACKUP_DIR,
                     skip_backup: bool = False) -> Dict[str, Any]:
    """
    改善コードをファイルに適用（TOCTOU対策版）

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
    # パス検証を最初に実行（TOCTOU対策）
    try:
        validated_path = validate_safe_path(file_path)
    except ValueError as e:
        return {
            'status': 'error',
            'file_path': file_path,
            'backup_path': None,
            'message': f'セキュリティエラー: {e}'
        }

    # 存在チェック＋実ファイル検証
    if not validated_path.exists():
        return {
            'status': 'error',
            'file_path': file_path,
            'backup_path': None,
            'message': f'ファイルが存在しません: {file_path}'
        }

    # シンボリックリンク検出（validate_safe_pathで既にチェック済みだが念のため）
    if validated_path.is_symlink():
        return {
            'status': 'error',
            'file_path': file_path,
            'backup_path': None,
            'message': f'セキュリティエラー: シンボリックリンクは許可されていません: {file_path}'
        }

    # Dry-runモード
    if dry_run:
        return {
            'status': 'skipped',
            'file_path': file_path,
            'backup_path': None,
            'message': '[DRY-RUN] 適用をシミュレートしました'
        }

    # バックアップ作成（validated_pathを使用）
    backup_path = None
    if not skip_backup:
        try:
            backup_path = create_backup(str(validated_path), backup_dir)
        except Exception as e:
            return {
                'status': 'error',
                'file_path': file_path,
                'backup_path': None,
                'message': f'バックアップ作成失敗: {e}'
            }

    # 改善コード検証（セキュリティ）
    try:
        validate_improved_code(improved_code)
    except ValueError as e:
        return {
            'status': 'error',
            'file_path': file_path,
            'backup_path': None,
            'message': f'改善コード検証失敗: {e}'
        }

    # ファイルにアトミック書き込み（validated_pathを直接使用）
    try:
        atomic_write(validated_path, improved_code)

        return {
            'status': 'success',
            'file_path': file_path,
            'backup_path': backup_path,
            'message': '適用成功'
        }
    except Exception as e:
        # ロールバック試行（可能であれば）
        if backup_path:
            try:
                shutil.copy2(backup_path, validated_path)
                return {
                    'status': 'error',
                    'file_path': file_path,
                    'backup_path': backup_path,
                    'message': f'書き込み失敗、自動ロールバック成功: {e}'
                }
            except Exception as rollback_error:
                return {
                    'status': 'error',
                    'file_path': file_path,
                    'backup_path': backup_path,
                    'message': f'書き込み失敗、ロールバック失敗: {e} / {rollback_error}'
                }
        return {
            'status': 'error',
            'file_path': file_path,
            'backup_path': backup_path,
            'message': f'ファイル書き込み失敗: {e}'
        }

# ===== ロールバック =====
def rollback_changes(backup_path: str, original_path: str = None) -> bool:
    """
    バックアップから復元（メタデータ対応版）

    Args:
        backup_path: バックアップファイルパス
        original_path: 復元先パス（Noneの場合はメタデータまたはファイル名から推測）

    Returns:
        True: 成功, False: 失敗
    """
    backup_file = pathlib.Path(backup_path)
    if not backup_file.exists():
        print(f"[ERROR] バックアップファイルが存在しません: {backup_path}")
        return False

    # 復元先を特定
    if original_path is None:
        # ステップ1: メタデータJSONから復元先を取得
        metadata_path = backup_file.with_suffix('.json')
        if metadata_path.exists():
            try:
                with open(metadata_path, 'r', encoding='utf-8') as f:
                    metadata = json.load(f)
                    original_path = metadata.get('original_path')
                    if original_path:
                        print(f"[INFO] メタデータから復元先を検出: {original_path}")
            except Exception as e:
                print(f"[WARNING] メタデータ読み込み失敗: {e}")

        # ステップ2: ファイル名から推測（メタデータ失敗時）
        if original_path is None:
            match = BACKUP_FILENAME_PATTERN.match(backup_file.name)

            if match:
                original_name = match.group(1)
                # 複数候補パスを検索
                possible_paths = [
                    backup_file.parent.parent / original_name,  # ルート
                    backup_file.parent.parent / 'src' / original_name,  # src/
                    backup_file.parent.parent / 'test' / original_name,  # test/
                ]

                # 存在するパスを選択
                for candidate in possible_paths:
                    if candidate.exists():
                        original_path = str(candidate)
                        print(f"[INFO] 復元先を検出: {original_path}")
                        break

                if original_path is None:
                    # 存在しない場合はルートに復元
                    original_path = str(backup_file.parent.parent / original_name)
                    print(f"[WARNING] 元のファイルが見つかりません。ルートに復元します: {original_path}")
            else:
                print(f"[ERROR] バックアップファイル名から元のファイル名を推測できません: {backup_path}")
                return False

    # パス検証
    try:
        validated_path = validate_safe_path(original_path)
    except ValueError as e:
        print(f"[ERROR] セキュリティエラー: {e}")
        return False

    # アトミックコピーで復元
    temp_fd = None
    temp_path = None
    try:
        temp_fd, temp_name = tempfile.mkstemp(
            dir=validated_path.parent,
            prefix=f'.{validated_path.name}.',
            suffix='.tmp'
        )
        os.close(temp_fd)
        temp_fd = None
        temp_path = pathlib.Path(temp_name)

        # コピー実行
        with open(backup_file, 'rb') as src:
            with open(temp_path, 'wb') as dst:
                dst.write(src.read())
                dst.flush()
                os.fsync(dst.fileno())  # ディスクに確実に書き込み

        # メタデータコピー（タイムスタンプなど）
        shutil.copystat(backup_file, temp_path)

        # アトミックリネーム
        temp_path.replace(validated_path)

        print(f"[OK] ロールバック成功: {validated_path}")
        return True

    except Exception as e:
        # クリーンアップ
        if temp_fd is not None:
            try:
                os.close(temp_fd)
            except:
                pass
        if temp_path and temp_path.exists():
            try:
                temp_path.unlink()
            except:
                pass

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

    # ファイルにアトミック書き込み
    output_file = pathlib.Path(output_path)
    output_file.parent.mkdir(parents=True, exist_ok=True)

    # atomic_write()を使用
    atomic_write(output_file, report_content)

    print(f"[OK] 適用サマリーレポート生成: {output_path}")

    return report_content

# ===== ログ記録 =====
def log_apply_result(result: Dict[str, Any], log_file: str = APPLY_LOG_FILE):
    """
    適用結果をJSONL形式でログに記録（ファイルロック保証）

    Args:
        result: 適用結果辞書
        log_file: ログファイルパス
    """
    log_entry = {
        'timestamp': datetime.now().isoformat(),
        **result
    }

    log_line = json.dumps(log_entry, ensure_ascii=False) + '\n'

    # クロスプラットフォームファイルロック（Windows: msvcrt、UNIX: fcntl）
    max_retries = 5
    for attempt in range(max_retries):
        try:
            # 追記モードで開く
            with open(log_file, 'a', encoding='utf-8') as f:
                # プラットフォーム別ファイルロック
                if os.name == 'nt':
                    # Windows: msvcrt.locking
                    try:
                        import msvcrt
                        msvcrt.locking(f.fileno(), msvcrt.LK_NBLCK, len(log_line))
                        try:
                            f.write(log_line)
                            f.flush()
                            os.fsync(f.fileno())
                        finally:
                            msvcrt.locking(f.fileno(), msvcrt.LK_UNLCK, len(log_line))
                    except ImportError:
                        # msvcrt利用不可の場合は通常書き込み
                        f.write(log_line)
                        f.flush()
                        os.fsync(f.fileno())
                else:
                    # UNIX: fcntl.flock
                    try:
                        import fcntl
                        fcntl.flock(f.fileno(), fcntl.LOCK_EX)
                        try:
                            f.write(log_line)
                            f.flush()
                            os.fsync(f.fileno())
                        finally:
                            fcntl.flock(f.fileno(), fcntl.LOCK_UN)
                    except ImportError:
                        # fcntl利用不可の場合は通常書き込み
                        f.write(log_line)
                        f.flush()
                        os.fsync(f.fileno())

            break  # 成功

        except (IOError, OSError) as e:
            if attempt < max_retries - 1:
                time.sleep(0.1 * (attempt + 1))  # 指数バックオフ
            else:
                # 最終リトライ失敗：標準エラー出力に警告
                print(f"[WARNING] ログ記録失敗（{max_retries}回試行）: {e}", file=sys.stderr)

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
    except FileNotFoundError as e:
        print(f"[ERROR] ファイルが見つかりません: {e}")
        sys.exit(1)
    except ValueError as e:
        print(f"[ERROR] セキュリティまたは検証エラー: {e}")
        sys.exit(1)
    except Exception as e:
        print(f"[ERROR] レポート解析失敗: {type(e).__name__}: {e}")
        # 詳細スタックトレースはverboseモードのみ
        if verbose:
            import traceback
            traceback.print_exc()
        else:
            print(f"[INFO] 詳細情報は --verbose オプションで確認できます")
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
    try:
        generate_apply_report(entries, results, report_path, output_report)
    except Exception as e:
        print(f"[WARNING] レポート生成失敗: {e}")
        # レポート生成失敗は致命的でないため続行

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

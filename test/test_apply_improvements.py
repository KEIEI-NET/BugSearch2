#!/usr/bin/env python3
"""
apply_improvements_from_report.py の包括的テストスイート

テスト項目:
1. レポート解析機能
2. セキュリティ検証（パストラバーサル、TOCTOU、Unicode制御文字）
3. エンコーディング検出（BOM、chardet、フォールバック）
4. アトミックファイル操作
5. バックアップ＆ロールバック
"""

import os
import sys
import tempfile
import pathlib
import shutil
import json
from datetime import datetime

# プロジェクトルートをパスに追加
sys.path.insert(0, str(pathlib.Path(__file__).parent.parent))

# テスト対象モジュールをインポート
try:
    from apply_improvements_from_report import (
        parse_complete_report,
        validate_safe_path,
        validate_improved_code,
        detect_encoding,
        read_file_with_fallback,
        atomic_write,
        create_backup,
        rollback_from_backup,
    )
    IMPORT_SUCCESS = True
except ImportError as e:
    print(f"[ERROR] インポート失敗: {e}")
    IMPORT_SUCCESS = False


class TestApplyImprovements:
    """apply_improvements_from_report.py のテストクラス"""

    def __init__(self):
        self.test_dir = pathlib.Path(__file__).parent / "temp_test_apply"
        self.test_dir.mkdir(exist_ok=True)
        self.backup_dir = self.test_dir / "backups"
        self.backup_dir.mkdir(exist_ok=True)

        self.passed = 0
        self.failed = 0
        self.errors = []

    def cleanup(self):
        """テスト環境のクリーンアップ"""
        if self.test_dir.exists():
            try:
                shutil.rmtree(self.test_dir)
            except PermissionError:
                # Windows: ファイルハンドルが開いている可能性
                import time
                time.sleep(0.5)
                try:
                    shutil.rmtree(self.test_dir)
                except Exception:
                    print(f"[WARNING] クリーンアップ失敗: {self.test_dir}")
                    pass

    def assert_true(self, condition, test_name, message=""):
        """アサーション（True期待）"""
        if condition:
            print(f"[OK] PASS: {test_name}")
            self.passed += 1
        else:
            print(f"[FAIL] FAIL: {test_name} - {message}")
            self.failed += 1
            self.errors.append(f"{test_name}: {message}")

    def assert_false(self, condition, test_name, message=""):
        """アサーション（False期待）"""
        self.assert_true(not condition, test_name, message)

    def assert_raises(self, func, exception_type, test_name):
        """例外発生のアサーション"""
        try:
            func()
            print(f"[FAIL] FAIL: {test_name} - 例外が発生しませんでした")
            self.failed += 1
            self.errors.append(f"{test_name}: 例外未発生")
        except exception_type:
            print(f"[OK] PASS: {test_name}")
            self.passed += 1
        except Exception as e:
            print(f"[FAIL] FAIL: {test_name} - 想定外の例外: {type(e).__name__}")
            self.failed += 1
            self.errors.append(f"{test_name}: {type(e).__name__}")

    # ===========================================
    # テスト1: レポート解析機能
    # ===========================================
    def test_parse_complete_report(self):
        """完全レポートの解析テスト"""
        print("\n=== テスト1: レポート解析機能 ===")

        # サンプルレポートが存在するか確認
        sample_report = pathlib.Path(__file__).parent / "sample_complete_report.md"

        if not sample_report.exists():
            print(f"[WARN] SKIP: sample_complete_report.md が見つかりません")
            return

        try:
            entries = parse_complete_report(str(sample_report))

            self.assert_true(
                isinstance(entries, list),
                "レポート解析結果がリスト型",
                f"実際の型: {type(entries)}"
            )

            self.assert_true(
                len(entries) > 0,
                "レポートからエントリを抽出",
                f"エントリ数: {len(entries)}"
            )

            # 最初のエントリの構造確認
            if entries:
                entry = entries[0]
                required_keys = ['file_path', 'lang', 'severity', 'problems', 'has_improvement']
                for key in required_keys:
                    self.assert_true(
                        key in entry,
                        f"エントリに'{key}'キーが存在",
                        f"実際のキー: {entry.keys()}"
                    )

                print(f"   [INFO] 解析結果: {len(entries)}件のエントリを検出")

                # 改善コードありのエントリ数
                with_code = sum(1 for e in entries if e.get('has_improvement'))
                print(f"   [INFO] 改善コード付き: {with_code}件")

        except Exception as e:
            print(f"[FAIL] FAIL: レポート解析でエラー: {e}")
            self.failed += 1
            self.errors.append(f"レポート解析エラー: {e}")

    # ===========================================
    # テスト2: セキュリティ検証
    # ===========================================
    def test_path_traversal_prevention(self):
        """パストラバーサル攻撃の防止テスト"""
        print("\n=== テスト2: パストラバーサル防止 ===")

        # 安全なパス
        self.assert_raises(
            lambda: validate_safe_path("../../../etc/passwd"),
            ValueError,
            "絶対パス外への移動を拒否"
        )

        self.assert_raises(
            lambda: validate_safe_path("/etc/passwd"),
            ValueError,
            "絶対パスを拒否"
        )

        # 相対パスでもホワイトリスト外は拒否
        self.assert_raises(
            lambda: validate_safe_path("../../other_project/file.py"),
            ValueError,
            "ホワイトリスト外のパスを拒否"
        )

    def test_unicode_control_character_detection(self):
        """Unicode制御文字の検出テスト"""
        print("\n=== テスト3: Unicode制御文字検出 ===")

        # NULL文字
        self.assert_raises(
            lambda: validate_improved_code("def test():\x00pass"),
            ValueError,
            "NULL文字を検出"
        )

        # C0制御文字（\x01-\x1F、ただし\t\n\r除く）
        self.assert_raises(
            lambda: validate_improved_code("def test():\x01pass"),
            ValueError,
            "C0制御文字を検出"
        )

        # 正常なコード（タブ、改行は許可）
        try:
            validate_improved_code("def test():\n\tpass")
            print(f"[OK] PASS: 正常なコード（タブ・改行含む）を許可")
            self.passed += 1
        except Exception as e:
            print(f"[FAIL] FAIL: 正常なコードが拒否された: {e}")
            self.failed += 1

    def test_code_size_limit(self):
        """コードサイズ制限テスト"""
        print("\n=== テスト4: コードサイズ制限 ===")

        # 巨大コード（デフォルト1MB超）
        large_code = "# " + ("x" * 1100 * 1024)

        self.assert_raises(
            lambda: validate_improved_code(large_code),
            ValueError,
            "1MB超のコードを拒否"
        )

    # ===========================================
    # テスト3: エンコーディング検出
    # ===========================================
    def test_bom_detection(self):
        """BOM検出テスト"""
        print("\n=== テスト5: BOM検出 ===")

        # UTF-8 BOM
        utf8_bom_file = self.test_dir / "utf8_bom.txt"
        with open(utf8_bom_file, 'wb') as f:
            f.write(b'\xef\xbb\xbf')
            f.write("テストテキスト".encode('utf-8'))

        encoding = detect_encoding(utf8_bom_file)
        self.assert_true(
            encoding == 'utf-8-sig',
            "UTF-8 BOMを検出",
            f"検出: {encoding}"
        )

        # UTF-16 LE BOM
        utf16le_file = self.test_dir / "utf16le.txt"
        with open(utf16le_file, 'wb') as f:
            f.write(b'\xff\xfe')
            f.write("テスト".encode('utf-16-le')[2:])  # BOM除外

        encoding = detect_encoding(utf16le_file)
        self.assert_true(
            encoding in ['utf-16-le', 'utf-16'],
            "UTF-16 LE BOMを検出",
            f"検出: {encoding}"
        )

    def test_encoding_fallback(self):
        """エンコーディングフォールバックテスト"""
        print("\n=== テスト6: エンコーディングフォールバック ===")

        # Shift_JISファイル
        sjis_file = self.test_dir / "sjis.txt"
        with open(sjis_file, 'wb') as f:
            f.write("日本語テキスト".encode('shift_jis'))

        try:
            content = read_file_with_fallback(sjis_file)
            self.assert_true(
                "日本語" in content,
                "Shift_JISファイルの読み込み成功",
                f"内容: {content[:20]}"
            )
        except Exception as e:
            print(f"[FAIL] FAIL: Shift_JIS読み込みエラー: {e}")
            self.failed += 1

    # ===========================================
    # テスト4: アトミックファイル操作
    # ===========================================
    def test_atomic_write(self):
        """アトミック書き込みテスト"""
        print("\n=== テスト7: アトミック書き込み ===")

        target_file = self.test_dir / "atomic_test.txt"
        test_content = "アトミック書き込みテスト\n改行あり"

        try:
            atomic_write(target_file, test_content)

            # ファイルが存在するか
            self.assert_true(
                target_file.exists(),
                "アトミック書き込み後にファイル存在"
            )

            # 内容が正しいか
            with open(target_file, 'r', encoding='utf-8') as f:
                written_content = f.read()

            self.assert_true(
                written_content == test_content,
                "書き込み内容が一致",
                f"期待: {test_content}, 実際: {written_content}"
            )

        except Exception as e:
            print(f"[FAIL] FAIL: アトミック書き込みエラー: {e}")
            self.failed += 1

    # ===========================================
    # テスト5: バックアップ＆ロールバック
    # ===========================================
    def test_backup_and_rollback(self):
        """バックアップとロールバック機能のテスト"""
        print("\n=== テスト8: バックアップ＆ロールバック ===")

        # テストファイル作成
        original_file = self.test_dir / "original.py"
        original_content = "def original():\n    pass"

        with open(original_file, 'w', encoding='utf-8') as f:
            f.write(original_content)

        try:
            # バックアップ作成 (returns string)
            backup_path_str = create_backup(str(original_file), str(self.backup_dir))
            backup_path = pathlib.Path(backup_path_str)

            self.assert_true(
                backup_path.exists(),
                "バックアップファイル作成",
                f"バックアップパス: {backup_path}"
            )

            # メタデータJSON確認
            metadata_path = backup_path.with_suffix('.json')
            self.assert_true(
                metadata_path.exists(),
                "メタデータJSON作成"
            )

            # メタデータ内容確認
            with open(metadata_path, 'r', encoding='utf-8') as f:
                metadata = json.load(f)

            self.assert_true(
                'original_path' in metadata,
                "メタデータにoriginal_path存在"
            )

            # ファイル変更
            modified_content = "def modified():\n    print('changed')"
            with open(original_file, 'w', encoding='utf-8') as f:
                f.write(modified_content)

            # ロールバック (pass string with allowed directory)
            rollback_from_backup(str(backup_path), allowed_dirs=[str(self.test_dir)])

            # ロールバック後の内容確認
            with open(original_file, 'r', encoding='utf-8') as f:
                restored_content = f.read()

            self.assert_true(
                restored_content == original_content,
                "ロールバックで元の内容に復元",
                f"期待: {original_content}, 実際: {restored_content}"
            )

        except Exception as e:
            print(f"[FAIL] FAIL: バックアップ/ロールバックエラー: {e}")
            self.failed += 1

    # ===========================================
    # テスト実行
    # ===========================================
    def run_all_tests(self):
        """全テストを実行"""
        print("=" * 60)
        print("apply_improvements_from_report.py テストスイート")
        print("=" * 60)

        if not IMPORT_SUCCESS:
            print("\n[ERROR] モジュールのインポートに失敗したためテストをスキップします")
            return False

        try:
            # テスト実行
            self.test_parse_complete_report()
            self.test_path_traversal_prevention()
            self.test_unicode_control_character_detection()
            self.test_code_size_limit()
            self.test_bom_detection()
            self.test_encoding_fallback()
            self.test_atomic_write()
            self.test_backup_and_rollback()

            # 結果サマリ
            print("\n" + "=" * 60)
            print("テスト結果サマリ")
            print("=" * 60)
            print(f"[OK] 成功: {self.passed}件")
            print(f"[FAIL] 失敗: {self.failed}件")

            if self.errors:
                print("\n[FAIL] 失敗したテスト:")
                for error in self.errors:
                    print(f"  - {error}")

            total = self.passed + self.failed
            if total > 0:
                success_rate = (self.passed / total) * 100
                print(f"\n成功率: {success_rate:.1f}%")

            return self.failed == 0

        finally:
            # クリーンアップ
            self.cleanup()


if __name__ == "__main__":
    tester = TestApplyImprovements()
    success = tester.run_all_tests()
    sys.exit(0 if success else 1)

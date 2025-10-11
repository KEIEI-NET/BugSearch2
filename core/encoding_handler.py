"""
エンコーディングハンドラー

マルチエンコーディング対応のファイル読み込みとUTF-8出力
"""

import sys
import chardet
from pathlib import Path
from typing import Optional, Tuple


def setup_utf8_output():
    """
    標準出力をUTF-8に設定

    Windows環境でのcp932エラーを回避し、すべての出力をUTF-8で行う
    """
    try:
        # Python 3.7+
        if hasattr(sys.stdout, 'reconfigure'):
            sys.stdout.reconfigure(encoding='utf-8')
            sys.stderr.reconfigure(encoding='utf-8')
        else:
            # 古いバージョンの場合は環境変数で対応
            import os
            os.environ['PYTHONIOENCODING'] = 'utf-8'
    except Exception as e:
        # エラーが発生しても続行
        pass


def detect_file_encoding(file_path: str, sample_size: int = 100000) -> Optional[str]:
    """
    ファイルのエンコーディングを自動検出

    Args:
        file_path: ファイルパス
        sample_size: 検出に使用するバイト数

    Returns:
        検出されたエンコーディング名、または None
    """
    try:
        with open(file_path, 'rb') as f:
            raw_data = f.read(sample_size)

        # chardetで検出
        result = chardet.detect(raw_data)

        if result and result['confidence'] > 0.7:
            return result['encoding']

        return None

    except Exception:
        return None


def read_file_with_fallback(
    file_path: str,
    encodings: Optional[list] = None
) -> Tuple[Optional[str], Optional[str]]:
    """
    複数のエンコーディングを試行してファイルを読み込む

    Args:
        file_path: ファイルパス
        encodings: 試行するエンコーディングのリスト（Noneの場合はデフォルト）

    Returns:
        (ファイル内容, 使用したエンコーディング) のタプル
        読み込みに失敗した場合は (None, None)
    """
    # デフォルトのエンコーディング順序
    if encodings is None:
        encodings = [
            'utf-8',
            'utf-8-sig',  # BOM付きUTF-8
            'cp932',      # Windows日本語
            'shift_jis',  # Shift-JIS
            'euc-jp',     # EUC-JP
            'latin-1',    # フォールバック
        ]

    # まず自動検出を試みる
    detected_encoding = detect_file_encoding(file_path)
    if detected_encoding and detected_encoding not in encodings:
        encodings = [detected_encoding] + encodings

    # 各エンコーディングで試行
    for encoding in encodings:
        try:
            with open(file_path, 'r', encoding=encoding, errors='strict') as f:
                content = f.read()
            return content, encoding

        except (UnicodeDecodeError, LookupError):
            continue

        except Exception as e:
            # その他のエラー（ファイルが存在しない等）
            return None, None

    # すべて失敗
    return None, None


def write_file_utf8(file_path: str, content: str) -> bool:
    """
    ファイルをUTF-8で書き込む

    Args:
        file_path: ファイルパス
        content: 書き込む内容

    Returns:
        成功したかどうか
    """
    try:
        with open(file_path, 'w', encoding='utf-8', errors='strict') as f:
            f.write(content)
        return True

    except Exception as e:
        print(f"ERROR: Failed to write file: {file_path}")
        print(f"  {e}")
        return False


def safe_print(text: str, end: str = '\n', flush: bool = False):
    """
    UTF-8で安全に出力

    Args:
        text: 出力するテキスト
        end: 末尾文字
        flush: バッファをフラッシュするか
    """
    try:
        print(text, end=end, flush=flush)
    except UnicodeEncodeError:
        # フォールバック: ASCII文字のみ出力
        ascii_text = text.encode('ascii', errors='replace').decode('ascii')
        print(ascii_text, end=end, flush=flush)


def is_binary_file(file_path: str, sample_size: int = 8192) -> bool:
    """
    ファイルがバイナリかどうか判定

    Args:
        file_path: ファイルパス
        sample_size: 判定に使用するバイト数

    Returns:
        バイナリファイルの場合True
    """
    try:
        with open(file_path, 'rb') as f:
            chunk = f.read(sample_size)

        # NULL バイトが含まれていればバイナリ
        if b'\x00' in chunk:
            return True

        # テキストバイトの割合で判定
        text_chars = bytearray({7, 8, 9, 10, 12, 13, 27} | set(range(0x20, 0x100)) - {0x7f})
        non_text_count = sum(1 for byte in chunk if byte not in text_chars)

        # 30%以上が非テキスト文字ならバイナリ
        if len(chunk) > 0 and (non_text_count / len(chunk)) > 0.30:
            return True

        return False

    except Exception:
        return True  # エラーの場合はバイナリとして扱う


# モジュール初期化時にUTF-8出力を設定
setup_utf8_output()

#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
generate_ai_improved_code.py - AI改善コード生成ツール

完全レポートから問題・助言を抽出し、LLMで100点満点の改善コードを生成してレポート化。
実ファイルは変更せず、人間が後で修正するための詳細レポートを生成します。

処理フロー:
    1. 完全レポートからエントリを抽出
    2. 元のソースファイルを読み込み
    3. 問題箇所にコメントを追加した元ソースを表示
    4. LLM（Claude/OpenAI）で100点満点の改善コードを生成
    5. 詳細レポート（Markdown）に追加
    6. 進捗をJSONに記録
    7. 次のエントリに進む（ループ）

使用例:
    # TOP20のみ処理
    python generate_ai_improved_code.py reports/完全レポート.md --top 20 --out reports/ai_improved

    # すべて処理（進捗自動保存）
    python generate_ai_improved_code.py reports/完全レポート.md --all --out reports/ai_improved

    # 進捗から再開
    python generate_ai_improved_code.py reports/完全レポート.md --resume

バージョン: 1.1.0 (100点満点改善版)
"""
from __future__ import annotations
import argparse
import json
import logging
import os
import pathlib
import re
import sys
import time
from datetime import datetime
from typing import List, Dict, Any, Optional

# AI Provider imports
try:
    import openai
    OPENAI_AVAILABLE = True
except ImportError:
    OPENAI_AVAILABLE = False

try:
    import anthropic
    ANTHROPIC_AVAILABLE = True
except ImportError:
    ANTHROPIC_AVAILABLE = False

# エンコーディング検出
try:
    import chardet
    CHARDET_AVAILABLE = True
except ImportError:
    CHARDET_AVAILABLE = False

# ===== 設定 =====
PROGRESS_FILE = ".ai_improved_progress.json"
DEFAULT_TOP_K = 20
MAX_REPORT_SIZE_MB = 100
MAX_SOURCE_FILE_SIZE_MB = 10
MAX_LLM_TOKENS = 8192
MAX_RETRY_ATTEMPTS = 3
RATE_LIMIT_DELAY_SEC = 2

# LLM設定
AI_PROVIDER = os.getenv("AI_PROVIDER", "auto")  # auto, openai, anthropic
OPENAI_MODEL = os.getenv("OPENAI_MODEL", "gpt-4o")
ANTHROPIC_MODEL = os.getenv("ANTHROPIC_MODEL", "claude-sonnet-4-5")

# 正規表現パターン（コンパイル済み）
ENTRY_PATTERN = re.compile(
    r'^### (\d+)\. (.+?)$\n'
    r'- \*\*言語\*\*: (.+?)$\n'
    r'- \*\*重要度\*\*: \[(.+?)\] \(スコア: (\d+)\)',
    re.MULTILINE
)
PROBLEMS_PATTERN = re.compile(
    r'#### 検出された問題:(.*?)(?=####|\Z)',
    re.DOTALL
)
ORIGINAL_CODE_PATTERN = re.compile(
    r'#### 元のソースコード:\s*```[\w+]*\n(.*?)```',
    re.DOTALL
)
ADVICE_PATTERN = re.compile(
    r'#### 改善されたソースコード:\s*```[\w+]*\n(.*?)```',
    re.DOTALL
)

# ロガー設定
logger = logging.getLogger(__name__)


# ===== ユーティリティ関数 =====

def setup_logging(verbose: bool = False) -> None:
    """ロギング設定"""
    level = logging.DEBUG if verbose else logging.INFO

    # コンソールハンドラー（エンコーディング対応）
    handler = logging.StreamHandler(sys.stderr)
    handler.setLevel(level)

    # UTF-8対応フォーマッター
    formatter = logging.Formatter(
        '%(asctime)s [%(levelname)s] %(message)s',
        datefmt='%Y-%m-%d %H:%M:%S'
    )
    handler.setFormatter(formatter)

    logger.addHandler(handler)
    logger.setLevel(level)


def load_env_file(env_path: str = ".env") -> None:
    """環境変数を.envファイルから読み込み（セキュアに）"""
    if not os.path.exists(env_path):
        logger.debug(f".env file not found: {env_path}")
        return

    try:
        with open(env_path, 'r', encoding='utf-8') as f:
            for line_num, line in enumerate(f, 1):
                line = line.strip()

                # コメントと空行をスキップ
                if not line or line.startswith('#'):
                    continue

                # 不正な行をスキップ
                if '=' not in line:
                    logger.warning(f".env line {line_num}: Invalid format (missing '=')")
                    continue

                key, value = line.split('=', 1)
                key = key.strip()
                value = value.strip().strip('"').strip("'")

                # 検証
                if not key:
                    logger.warning(f".env line {line_num}: Empty key")
                    continue

                if not key.replace('_', '').isalnum():
                    logger.warning(f".env line {line_num}: Invalid key format: {key}")
                    continue

                # 環境変数に設定（既存の値を上書きしない）
                if key not in os.environ:
                    os.environ[key] = value
                    logger.debug(f"Loaded env var: {key}")

    except Exception as e:
        logger.error(f"Failed to load .env file: {e}")


def detect_encoding(file_path: pathlib.Path) -> str:
    """ファイルエンコーディングを検出（堅牢に）"""
    try:
        # BOM検出
        with open(file_path, 'rb') as f:
            first_bytes = f.read(4)

        if first_bytes[:3] == b'\xef\xbb\xbf':
            return 'utf-8-sig'
        if first_bytes[:2] == b'\xff\xfe':
            return 'utf-16-le'
        if first_bytes[:2] == b'\xfe\xff':
            return 'utf-16-be'

        # chardet使用
        if CHARDET_AVAILABLE:
            with open(file_path, 'rb') as f:
                raw_data = f.read()
            result = chardet.detect(raw_data)
            if result and result.get('confidence', 0) > 0.7:
                detected = result['encoding']
                logger.debug(f"chardet detected: {detected} (confidence: {result['confidence']:.2f})")
                return detected

        # フォールバック
        for encoding in ['utf-8', 'cp932', 'shift_jis', 'latin1']:
            try:
                with open(file_path, 'r', encoding=encoding) as f:
                    f.read()
                logger.debug(f"Fallback encoding: {encoding}")
                return encoding
            except (UnicodeDecodeError, LookupError):
                continue

    except Exception as e:
        logger.warning(f"Encoding detection error: {e}, defaulting to utf-8")

    return 'utf-8'


def read_source_file(file_path: str) -> Optional[str]:
    """ソースファイルを読み込み（安全に）"""
    try:
        path = pathlib.Path(file_path)

        # 存在チェック
        if not path.exists():
            logger.warning(f"File not found: {file_path}")
            return None

        if not path.is_file():
            logger.warning(f"Not a file: {file_path}")
            return None

        # ファイルサイズチェック
        size_mb = path.stat().st_size / (1024 * 1024)
        if size_mb > MAX_SOURCE_FILE_SIZE_MB:
            logger.warning(f"File too large: {size_mb:.1f}MB > {MAX_SOURCE_FILE_SIZE_MB}MB")
            return None

        # エンコーディング検出
        encoding = detect_encoding(path)

        # ファイル読み込み
        with open(path, 'r', encoding=encoding, errors='replace') as f:
            content = f.read()

        logger.debug(f"Read file: {file_path} ({len(content)} chars, {encoding})")
        return content

    except Exception as e:
        logger.error(f"File read error: {e}")
        return None


# ===== レポート解析 =====

def parse_complete_report(report_path: pathlib.Path) -> List[Dict[str, Any]]:
    """完全レポートを解析してエントリリストを返す（堅牢に）"""
    try:
        # ファイルサイズチェック
        size_mb = report_path.stat().st_size / (1024 * 1024)
        if size_mb > MAX_REPORT_SIZE_MB:
            raise ValueError(f"Report too large: {size_mb:.1f}MB > {MAX_REPORT_SIZE_MB}MB")

        logger.info(f"Parsing report: {report_path} ({size_mb:.1f}MB)")

        # エンコーディング検出
        encoding = detect_encoding(report_path)

        # ファイル読み込み
        with open(report_path, 'r', encoding=encoding, errors='replace') as f:
            content = f.read()

        entries = []

        # エントリごとに分割
        entry_matches = list(ENTRY_PATTERN.finditer(content))
        logger.info(f"Found {len(entry_matches)} entries")

        for i, match in enumerate(entry_matches):
            try:
                entry_num = int(match.group(1))
                file_path = match.group(2).strip()
                lang = match.group(3).strip()
                severity_level = match.group(4).strip()
                severity_score = int(match.group(5))

                # エントリの範囲を特定
                start_pos = match.start()
                end_pos = entry_matches[i + 1].start() if i + 1 < len(entry_matches) else len(content)
                entry_content = content[start_pos:end_pos]

                # 問題を抽出
                problems = []
                problems_match = PROBLEMS_PATTERN.search(entry_content)
                if problems_match:
                    problems_text = problems_match.group(1).strip()
                    for line in problems_text.split('\n'):
                        line = line.strip()
                        if line.startswith('- ['):
                            problems.append(line[2:].strip())  # "- " を削除

                # 元のコードを抽出（レポート内のコード、参考用）
                original_code = None
                original_match = ORIGINAL_CODE_PATTERN.search(entry_content)
                if original_match:
                    original_code = original_match.group(1).strip()

                # 助言を抽出
                advice = None
                advice_match = ADVICE_PATTERN.search(entry_content)
                if advice_match:
                    advice = advice_match.group(1).strip()

                entries.append({
                    'number': entry_num,
                    'file_path': file_path,
                    'lang': lang,
                    'severity_level': severity_level,
                    'severity_score': severity_score,
                    'problems': problems,
                    'original_code': original_code,  # レポート内のコード
                    'advice': advice
                })

            except Exception as e:
                logger.error(f"Error parsing entry {i+1}: {e}")
                continue

        logger.info(f"Successfully parsed {len(entries)} entries")
        return entries

    except Exception as e:
        logger.error(f"Report parsing error: {e}")
        raise


# ===== LLM連携 =====

def build_improvement_prompt(
    file_path: str,
    lang: str,
    problems: List[str],
    advice: str,
    source_code: str
) -> str:
    """改善プロンプトを構築（最適化）"""

    # 問題リストを整形
    problems_text = '\n'.join(f"{i+1}. {p}" for i, p in enumerate(problems))

    # トークン数削減のため、ソースコードが長すぎる場合は警告
    source_lines = source_code.count('\n')
    if source_lines > 1000:
        logger.warning(f"Source code is very long: {source_lines} lines")

    prompt = f"""あなたはコードレビューとリファクタリングの専門家です。

## タスク
以下のソースコードを、検出された問題と助言に基づいて改善してください。

## ファイル情報
- パス: {file_path}
- 言語: {lang}
- 行数: {source_lines}

## 検出された問題（{len(problems)}件）
{problems_text}

## 改善助言
{advice if advice else "（助言なし）"}

## 元のソースコード
```{lang}
{source_code}
```

## 指示
1. 上記の問題をすべて解決してください
2. 助言に従って実装してください
3. セキュリティ、パフォーマンス、保守性を100点満点レベルに引き上げてください
4. コメントは日本語で簡潔に記載してください
5. **改善されたコードのみ**を出力してください（説明や解説は不要）
6. 元のコード構造を尊重し、過度な変更は避けてください

改善されたコード:
"""

    return prompt


def call_llm_for_improvement(
    file_path: str,
    lang: str,
    problems: List[str],
    advice: str,
    source_code: str,
    retry: int = 0
) -> Optional[str]:
    """LLMで改善コードを生成（リトライ付き）"""

    # プロンプト構築
    prompt = build_improvement_prompt(file_path, lang, problems, advice, source_code)

    # AI Provider選択
    provider = AI_PROVIDER.lower()

    if provider == "auto":
        # Anthropic優先、フォールバック
        if ANTHROPIC_AVAILABLE and os.getenv("ANTHROPIC_API_KEY"):
            provider = "anthropic"
        elif OPENAI_AVAILABLE and os.getenv("OPENAI_API_KEY"):
            provider = "openai"
        else:
            logger.error("No AI Provider available (missing API key)")
            return None

    try:
        logger.debug(f"Calling {provider} API...")

        if provider == "anthropic":
            return call_anthropic(prompt)
        elif provider == "openai":
            return call_openai(prompt)
        else:
            logger.error(f"Unknown AI Provider: {provider}")
            return None

    except Exception as e:
        error_msg = str(e)
        logger.error(f"LLM API error: {error_msg}")

        # リトライ可能なエラーの場合
        if retry < MAX_RETRY_ATTEMPTS and ("timeout" in error_msg.lower() or "rate" in error_msg.lower()):
            logger.info(f"Retrying ({retry+1}/{MAX_RETRY_ATTEMPTS})...")
            time.sleep(RATE_LIMIT_DELAY_SEC * (retry + 1))
            return call_llm_for_improvement(file_path, lang, problems, advice, source_code, retry + 1)

        return None


def call_anthropic(prompt: str) -> Optional[str]:
    """Claude APIで改善コード生成（エラーハンドリング強化）"""
    api_key = os.getenv("ANTHROPIC_API_KEY")
    if not api_key:
        raise ValueError("ANTHROPIC_API_KEY not set")

    client = anthropic.Anthropic(api_key=api_key)

    try:
        response = client.messages.create(
            model=ANTHROPIC_MODEL,
            max_tokens=MAX_LLM_TOKENS,
            messages=[
                {"role": "user", "content": prompt}
            ],
            timeout=60.0  # タイムアウト設定
        )

        if response.content and len(response.content) > 0:
            content = response.content[0].text
            logger.debug(f"Claude response: {len(content)} chars")
            return content

        logger.warning("Claude returned empty response")
        return None

    except anthropic.APIError as e:
        logger.error(f"Claude API error: {e}")
        raise


def call_openai(prompt: str) -> Optional[str]:
    """OpenAI APIで改善コード生成（エラーハンドリング強化）"""
    api_key = os.getenv("OPENAI_API_KEY")
    if not api_key:
        raise ValueError("OPENAI_API_KEY not set")

    client = openai.OpenAI(api_key=api_key)

    try:
        response = client.chat.completions.create(
            model=OPENAI_MODEL,
            messages=[
                {"role": "system", "content": "あなたはコードレビューとリファクタリングの専門家です。指示に従って改善されたコードのみを出力してください。"},
                {"role": "user", "content": prompt}
            ],
            max_tokens=MAX_LLM_TOKENS,
            timeout=60.0  # タイムアウト設定
        )

        if response.choices and len(response.choices) > 0:
            content = response.choices[0].message.content
            logger.debug(f"OpenAI response: {len(content)} chars")
            return content

        logger.warning("OpenAI returned empty response")
        return None

    except openai.APIError as e:
        logger.error(f"OpenAI API error: {e}")
        raise


# ===== 進捗管理 =====

def load_progress() -> Dict[str, Any]:
    """進捗をJSONから読み込み（安全に）"""
    if not os.path.exists(PROGRESS_FILE):
        return {"processed": [], "last_index": -1, "timestamp": None}

    try:
        with open(PROGRESS_FILE, 'r', encoding='utf-8') as f:
            progress = json.load(f)

        # 検証
        if not isinstance(progress, dict):
            logger.warning("Invalid progress file format, resetting")
            return {"processed": [], "last_index": -1, "timestamp": None}

        logger.info(f"Loaded progress: {len(progress.get('processed', []))} processed")
        return progress

    except Exception as e:
        logger.error(f"Failed to load progress: {e}")
        return {"processed": [], "last_index": -1, "timestamp": None}


def save_progress(progress: Dict[str, Any]) -> None:
    """進捗をJSONに保存（安全に）"""
    try:
        progress['timestamp'] = datetime.now().isoformat()

        # アトミック書き込み
        temp_file = PROGRESS_FILE + ".tmp"
        with open(temp_file, 'w', encoding='utf-8') as f:
            json.dump(progress, f, ensure_ascii=False, indent=2)

        # 置き換え
        if os.path.exists(PROGRESS_FILE):
            os.remove(PROGRESS_FILE)
        os.rename(temp_file, PROGRESS_FILE)

        logger.debug(f"Progress saved: {len(progress.get('processed', []))} entries")

    except Exception as e:
        logger.error(f"Failed to save progress: {e}")


# ===== メイン処理 =====

def process_entry(
    entry: Dict[str, Any],
    output_md: pathlib.Path
) -> bool:
    """1エントリを処理（改善版）"""

    entry_num = entry['number']
    file_path = entry['file_path']

    logger.info(f"[{entry_num}] Processing: {file_path}")
    logger.info(f"  Lang: {entry['lang']}, Score: {entry['severity_score']}, Problems: {len(entry['problems'])}")

    # ソースファイル読み込み（実ファイルから）
    source_code = read_source_file(file_path)
    if source_code is None:
        logger.warning(f"[{entry_num}] Skipped: file read failed")
        return False

    # LLMで改善コード生成
    logger.info(f"[{entry_num}] Generating improved code with LLM...")
    improved_code = call_llm_for_improvement(
        file_path,
        entry['lang'],
        entry['problems'],
        entry['advice'] or "",
        source_code
    )

    if improved_code is None:
        logger.error(f"[{entry_num}] Failed: LLM generation failed")
        return False

    # レポートに追加
    try:
        with open(output_md, 'a', encoding='utf-8') as f:
            f.write(f"\n\n---\n\n")
            f.write(f"## {entry_num}. {file_path}\n\n")
            f.write(f"- **言語**: {entry['lang']}\n")
            f.write(f"- **重要度**: [{entry['severity_level']}] (スコア: {entry['severity_score']})\n")
            f.write(f"- **生成日時**: {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}\n")
            f.write(f"- **問題数**: {len(entry['problems'])}件\n\n")

            f.write(f"### 検出された問題\n\n")
            for i, problem in enumerate(entry['problems'], 1):
                f.write(f"{i}. {problem}\n")

            f.write(f"\n### 改善助言\n\n")
            if entry['advice']:
                f.write(f"```\n{entry['advice']}\n```\n\n")
            else:
                f.write("（助言なし）\n\n")

            f.write(f"### 元のソースコード\n\n")
            f.write(f"```{entry['lang']}\n{source_code}\n```\n\n")

            f.write(f"### AI生成改善コード（100点満点目標）\n\n")
            f.write(f"```{entry['lang']}\n{improved_code}\n```\n\n")

        logger.info(f"[{entry_num}] Success")
        return True

    except Exception as e:
        logger.error(f"[{entry_num}] Failed to write report: {e}")
        return False


def main():
    """メイン処理"""
    parser = argparse.ArgumentParser(
        description="完全レポートからAI改善コードを生成",
        formatter_class=argparse.RawDescriptionHelpFormatter,
        epilog=__doc__
    )
    parser.add_argument("report", type=str, help="完全レポートのパス")
    parser.add_argument("--top", type=int, default=DEFAULT_TOP_K, help=f"処理する件数（デフォルト: {DEFAULT_TOP_K}）")
    parser.add_argument("--all", action="store_true", help="すべて処理")
    parser.add_argument("--out", type=str, default="reports/ai_improved_report.md", help="出力レポートパス")
    parser.add_argument("--resume", action="store_true", help="進捗から再開")
    parser.add_argument("--verbose", "-v", action="store_true", help="詳細ログ出力")

    args = parser.parse_args()

    # ロギング設定
    setup_logging(args.verbose)

    # .env読み込み
    load_env_file()

    # AI Provider確認
    if not OPENAI_AVAILABLE and not ANTHROPIC_AVAILABLE:
        logger.error("No AI library available")
        print("[ERROR] openai または anthropic パッケージが必要です", file=sys.stderr)
        print("インストール: pip install openai anthropic", file=sys.stderr)
        sys.exit(1)

    # レポート読み込み
    report_path = pathlib.Path(args.report)
    if not report_path.exists():
        logger.error(f"Report not found: {args.report}")
        print(f"[ERROR] レポートが見つかりません: {args.report}", file=sys.stderr)
        sys.exit(1)

    print("="*80)
    print("AI改善コード生成ツール v1.1.0")
    print("="*80)
    print(f"入力: {report_path}")
    print(f"出力: {args.out}")
    print(f"AI Provider: {AI_PROVIDER}")
    print(f"詳細ログ: {'有効' if args.verbose else '無効'}")
    print("="*80)

    # エントリ抽出
    print("\n[1/3] レポート解析中...")
    try:
        entries = parse_complete_report(report_path)
    except Exception as e:
        logger.error(f"Failed to parse report: {e}")
        sys.exit(1)

    print(f"  総エントリ数: {len(entries)}")

    # 処理対象を決定
    if args.all:
        target_entries = entries
    else:
        target_entries = entries[:args.top]

    print(f"  処理対象: {len(target_entries)}件")

    # 進捗読み込み
    progress = load_progress() if args.resume else {"processed": [], "last_index": -1}

    # 出力ファイル準備
    output_path = pathlib.Path(args.out)
    output_path.parent.mkdir(parents=True, exist_ok=True)

    if not output_path.exists():
        with open(output_path, 'w', encoding='utf-8') as f:
            f.write(f"# AI改善コード生成レポート\n\n")
            f.write(f"生成日時: {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}\n")
            f.write(f"入力レポート: {report_path}\n")
            f.write(f"処理対象: {len(target_entries)}件\n")
            f.write(f"AI Provider: {AI_PROVIDER}\n\n")

    # 処理実行
    print("\n[2/3] AI改善コード生成中...")

    success_count = 0
    skip_count = 0
    start_time = time.time()

    for i, entry in enumerate(target_entries):
        # 進捗チェック
        if args.resume and i <= progress['last_index']:
            print(f"\n[{entry['number']}] スキップ（処理済み）")
            skip_count += 1
            continue

        # 処理実行
        success = process_entry(entry, output_path)

        if success:
            success_count += 1
        else:
            skip_count += 1

        # 進捗保存
        progress['last_index'] = i
        progress['processed'].append({
            'number': entry['number'],
            'file_path': entry['file_path'],
            'success': success,
            'timestamp': datetime.now().isoformat()
        })
        save_progress(progress)

        # レート制限対策
        if success:
            time.sleep(RATE_LIMIT_DELAY_SEC)

    # 完了
    elapsed_time = time.time() - start_time

    print("\n[3/3] 完了")
    print("="*80)
    print(f"成功: {success_count}件")
    print(f"スキップ: {skip_count}件")
    print(f"処理時間: {elapsed_time:.1f}秒")
    print(f"出力: {output_path}")
    print(f"進捗: {PROGRESS_FILE}")
    print("="*80)


if __name__ == "__main__":
    main()

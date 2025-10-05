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

バージョン: 1.0.0
"""
from __future__ import annotations
import argparse
import json
import os
import pathlib
import re
import sys
import time
from datetime import datetime
from typing import List, Dict, Any, Optional, Tuple

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

# ===== ユーティリティ関数 =====

def load_env_file(env_path: str = ".env") -> None:
    """環境変数を.envファイルから読み込み"""
    if not os.path.exists(env_path):
        return

    with open(env_path, 'r', encoding='utf-8') as f:
        for line in f:
            line = line.strip()
            if not line or line.startswith('#'):
                continue
            if '=' in line:
                key, value = line.split('=', 1)
                key = key.strip()
                value = value.strip().strip('"').strip("'")
                if key and value:
                    os.environ[key] = value


def detect_encoding(file_path: pathlib.Path) -> str:
    """ファイルエンコーディングを検出"""
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
        if result and result['confidence'] > 0.7:
            return result['encoding']

    # フォールバック
    for encoding in ['utf-8', 'cp932', 'shift_jis', 'latin1']:
        try:
            with open(file_path, 'r', encoding=encoding) as f:
                f.read()
            return encoding
        except (UnicodeDecodeError, LookupError):
            continue

    return 'utf-8'


def read_source_file(file_path: str) -> Optional[str]:
    """ソースファイルを読み込み"""
    path = pathlib.Path(file_path)

    if not path.exists():
        print(f"  [WARNING] ファイルが存在しません: {file_path}", file=sys.stderr)
        return None

    if not path.is_file():
        print(f"  [WARNING] ファイルではありません: {file_path}", file=sys.stderr)
        return None

    # ファイルサイズチェック
    size_mb = path.stat().st_size / (1024 * 1024)
    if size_mb > MAX_SOURCE_FILE_SIZE_MB:
        print(f"  [WARNING] ファイルサイズが大きすぎます: {size_mb:.1f}MB > {MAX_SOURCE_FILE_SIZE_MB}MB", file=sys.stderr)
        return None

    encoding = detect_encoding(path)

    try:
        with open(path, 'r', encoding=encoding) as f:
            return f.read()
    except Exception as e:
        print(f"  [ERROR] ファイル読み込みエラー: {e}", file=sys.stderr)
        return None


# ===== レポート解析 =====

def parse_complete_report(report_path: pathlib.Path) -> List[Dict[str, Any]]:
    """完全レポートを解析してエントリリストを返す"""

    # ファイルサイズチェック
    size_mb = report_path.stat().st_size / (1024 * 1024)
    if size_mb > MAX_REPORT_SIZE_MB:
        raise ValueError(f"レポートサイズが大きすぎます: {size_mb:.1f}MB")

    encoding = detect_encoding(report_path)

    with open(report_path, 'r', encoding=encoding) as f:
        content = f.read()

    entries = []

    # エントリごとに分割
    entry_matches = list(ENTRY_PATTERN.finditer(content))

    for i, match in enumerate(entry_matches):
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

        # 元のコードを抽出
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
            'original_code': original_code,
            'advice': advice
        })

    return entries


# ===== LLM連携 =====

def call_llm_for_improvement(
    file_path: str,
    lang: str,
    problems: List[str],
    advice: str,
    original_code: str
) -> Optional[str]:
    """LLMで改善コードを生成"""

    # プロンプト構築
    prompt = f"""あなたはコードレビューとリファクタリングの専門家です。

以下のソースファイルについて、検出された問題と助言に基づいて、100点満点の改善コードを生成してください。

## ファイル情報
- **ファイルパス**: {file_path}
- **言語**: {lang}

## 検出された問題
{chr(10).join(f"- {p}" for p in problems)}

## 改善助言
{advice}

## 元のソースコード
```{lang}
{original_code}
```

## 指示
1. 上記の問題をすべて解決してください
2. 助言に従って実装してください
3. デバッグ、セキュリティ、コードレビューで100点満点を目指してください
4. コメントは日本語で記載してください
5. **改善されたコードのみ**を出力してください（説明不要）

改善されたコード:
"""

    # AI Provider選択
    provider = AI_PROVIDER.lower()

    if provider == "auto":
        # Anthropic優先、フォールバック
        if ANTHROPIC_AVAILABLE and os.getenv("ANTHROPIC_API_KEY"):
            provider = "anthropic"
        elif OPENAI_AVAILABLE and os.getenv("OPENAI_API_KEY"):
            provider = "openai"
        else:
            print("  [ERROR] AI Provider が利用できません（APIキー未設定）", file=sys.stderr)
            return None

    try:
        if provider == "anthropic":
            return call_anthropic(prompt)
        elif provider == "openai":
            return call_openai(prompt)
        else:
            print(f"  [ERROR] 不明なAI Provider: {provider}", file=sys.stderr)
            return None
    except Exception as e:
        print(f"  [ERROR] LLM呼び出しエラー: {e}", file=sys.stderr)
        return None


def call_anthropic(prompt: str) -> Optional[str]:
    """Claude APIで改善コード生成"""
    api_key = os.getenv("ANTHROPIC_API_KEY")
    if not api_key:
        raise ValueError("ANTHROPIC_API_KEY が設定されていません")

    client = anthropic.Anthropic(api_key=api_key)

    response = client.messages.create(
        model=ANTHROPIC_MODEL,
        max_tokens=8192,
        messages=[
            {"role": "user", "content": prompt}
        ]
    )

    if response.content and len(response.content) > 0:
        return response.content[0].text

    return None


def call_openai(prompt: str) -> Optional[str]:
    """OpenAI APIで改善コード生成"""
    api_key = os.getenv("OPENAI_API_KEY")
    if not api_key:
        raise ValueError("OPENAI_API_KEY が設定されていません")

    client = openai.OpenAI(api_key=api_key)

    response = client.chat.completions.create(
        model=OPENAI_MODEL,
        messages=[
            {"role": "system", "content": "あなたはコードレビューとリファクタリングの専門家です。"},
            {"role": "user", "content": prompt}
        ],
        max_tokens=8192
    )

    if response.choices and len(response.choices) > 0:
        return response.choices[0].message.content

    return None


# ===== 進捗管理 =====

def load_progress() -> Dict[str, Any]:
    """進捗をJSONから読み込み"""
    if not os.path.exists(PROGRESS_FILE):
        return {"processed": [], "last_index": -1, "timestamp": None}

    with open(PROGRESS_FILE, 'r', encoding='utf-8') as f:
        return json.load(f)


def save_progress(progress: Dict[str, Any]) -> None:
    """進捗をJSONに保存"""
    progress['timestamp'] = datetime.now().isoformat()

    with open(PROGRESS_FILE, 'w', encoding='utf-8') as f:
        json.dump(progress, f, ensure_ascii=False, indent=2)


# ===== メイン処理 =====

def process_entry(
    entry: Dict[str, Any],
    output_md: pathlib.Path
) -> bool:
    """1エントリを処理"""

    print(f"\n[{entry['number']}] {entry['file_path']}")
    print(f"  言語: {entry['lang']}, スコア: {entry['severity_score']}")
    print(f"  問題数: {len(entry['problems'])}")

    # ソースファイル読み込み
    source_code = read_source_file(entry['file_path'])
    if source_code is None:
        print("  [SKIP] ファイル読み込み失敗")
        return False

    # LLMで改善コード生成
    print("  [AI] LLMで改善コード生成中...")
    improved_code = call_llm_for_improvement(
        entry['file_path'],
        entry['lang'],
        entry['problems'],
        entry['advice'] or "",
        source_code
    )

    if improved_code is None:
        print("  [ERROR] 改善コード生成失敗")
        return False

    # レポートに追加
    with open(output_md, 'a', encoding='utf-8') as f:
        f.write(f"\n\n---\n\n")
        f.write(f"## {entry['number']}. {entry['file_path']}\n\n")
        f.write(f"- **言語**: {entry['lang']}\n")
        f.write(f"- **重要度**: [{entry['severity_level']}] (スコア: {entry['severity_score']})\n")
        f.write(f"- **生成日時**: {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}\n\n")

        f.write(f"### 検出された問題\n\n")
        for problem in entry['problems']:
            f.write(f"- {problem}\n")

        f.write(f"\n### 改善助言\n\n")
        if entry['advice']:
            f.write(f"```\n{entry['advice']}\n```\n\n")
        else:
            f.write("（助言なし）\n\n")

        f.write(f"### 元のソースコード\n\n")
        f.write(f"```{entry['lang']}\n{source_code}\n```\n\n")

        f.write(f"### AI生成改善コード（100点満点目標）\n\n")
        f.write(f"```{entry['lang']}\n{improved_code}\n```\n\n")

    print(f"  [OK] 完了")
    return True


def main():
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

    args = parser.parse_args()

    # .env読み込み
    load_env_file()

    # AI Provider確認
    if not OPENAI_AVAILABLE and not ANTHROPIC_AVAILABLE:
        print("[ERROR] openai または anthropic パッケージが必要です", file=sys.stderr)
        print("インストール: pip install openai anthropic", file=sys.stderr)
        sys.exit(1)

    # レポート読み込み
    report_path = pathlib.Path(args.report)
    if not report_path.exists():
        print(f"[ERROR] レポートが見つかりません: {args.report}", file=sys.stderr)
        sys.exit(1)

    print("="*80)
    print("AI改善コード生成ツール")
    print("="*80)
    print(f"入力: {report_path}")
    print(f"出力: {args.out}")
    print(f"AI Provider: {AI_PROVIDER}")
    print("="*80)

    # エントリ抽出
    print("\n[1/3] レポート解析中...")
    entries = parse_complete_report(report_path)
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
            f.write(f"処理対象: {len(target_entries)}件\n\n")

    # 処理実行
    print("\n[2/3] AI改善コード生成中...")

    success_count = 0
    skip_count = 0

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
        time.sleep(1)

    # 完了
    print("\n[3/3] 完了")
    print("="*80)
    print(f"成功: {success_count}件")
    print(f"スキップ: {skip_count}件")
    print(f"出力: {output_path}")
    print(f"進捗: {PROGRESS_FILE}")
    print("="*80)


if __name__ == "__main__":
    main()

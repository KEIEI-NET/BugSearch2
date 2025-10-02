#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
並列処理による危険ファイルのAI詳細分析（改良版）
- 完全な修正前後のコード提供
- 詳細な問題説明と影響分析
- GPT-4oフォーマット準拠
"""

import os
import sys
import json
import time
import hashlib
from pathlib import Path
from datetime import datetime
from concurrent.futures import ThreadPoolExecutor, as_completed
import threading
from typing import List, Dict, Tuple, Optional
from dotenv import load_dotenv
import re

# 環境変数読み込み
load_dotenv()

# SDK チェック
OPENAI_OK = False
ANTHROPIC_OK = False

try:
    import openai
    openai.api_key = os.getenv("OPENAI_API_KEY")
    OPENAI_OK = True
except Exception:
    pass

try:
    from anthropic import Anthropic
    ANTHROPIC_OK = True
except Exception:
    pass

# 設定
BATCH_SIZE = 50  # 並列処理用に縮小
PARALLEL_WORKERS = 10
API_DELAY = 0.1  # レート制限対策
OUTPUT_DIR = "reports"
DANGER_FILE = "reports/danger_analysis_ALL"
PROGRESS_FILE = ".batch_progress_parallel_enhanced.json"
CACHE_DIR = ".cache"
CACHE_EXPIRY_DAYS = 7

# レート制限管理
class RateLimiter:
    def __init__(self, max_calls_per_minute=100):
        self.max_calls = max_calls_per_minute
        self.calls = []
        self.lock = threading.Lock()

    def wait_if_needed(self):
        with self.lock:
            now = time.time()
            # 1分以内の呼び出しをフィルタ
            self.calls = [t for t in self.calls if now - t < 60]

            if len(self.calls) >= self.max_calls:
                sleep_time = 60 - (now - self.calls[0]) + 1
                print(f"[RATE] レート制限: {sleep_time:.1f}秒待機")
                time.sleep(sleep_time)

            self.calls.append(time.time())

rate_limiter = RateLimiter(max_calls_per_minute=100)

def get_enhanced_ai_prompt(file_path: str, code_snippet: str, problems: str) -> str:
    """改良版AIプロンプト - 完全なコードと詳細説明を要求"""
    return f"""
# ソースファイル分析依頼

## ファイル情報
- **ファイルパス**: `{file_path}`
- **検出された問題**: {problems}

## 分析対象コード
```
{code_snippet[:5000] if len(code_snippet) > 5000 else code_snippet}
```

## 要求仕様

以下の形式で、**日本語で** 詳細な分析結果を提供してください：

### 1. 問題の詳細分析

各検出問題について：

#### 🚨 [問題名]

**問題の詳細**:
具体的にコードのどの部分に問題があるか、なぜ問題なのかを詳しく説明。

**影響**:
- セキュリティへの影響
- パフォーマンスへの影響
- 保守性への影響
- ビジネスへの影響

**完全な改善コード**:

```[言語]
// ===== 修正前のコード（問題あり）=====
[実際の問題のあるコード全体を記載]
// 問題箇所にコメントで説明を追加

// ===== 修正後のコード（改善版）=====
[完全に動作する改善版コード全体を記載]
// 改善ポイントにコメントで説明を追加
```

**追加の推奨事項**:
- テストコードの例
- 設定ファイルの例
- ベストプラクティス

### 2. 総合評価

- **緊急度**: 緊急/高/中/低
- **修正工数**: 時間の目安
- **影響範囲**: 他のモジュールへの影響

必ず実装可能な完全なコードを提供し、部分的な例示は避けてください。
"""

def get_ai_provider() -> Optional[str]:
    """AIプロバイダーを決定"""
    provider = os.getenv("AI_PROVIDER", "auto").lower().strip()

    if provider == "auto":
        # Anthropic優先
        if ANTHROPIC_OK and os.getenv("ANTHROPIC_API_KEY"):
            return "anthropic"
        elif OPENAI_OK and os.getenv("OPENAI_API_KEY"):
            return "openai"
    elif provider == "anthropic":
        if ANTHROPIC_OK and os.getenv("ANTHROPIC_API_KEY"):
            return "anthropic"
    elif provider == "openai":
        if OPENAI_OK and os.getenv("OPENAI_API_KEY"):
            return "openai"

    return None

def select_model_for_severity(severity: int, provider: str = "openai") -> Tuple[str, str, Optional[str]]:
    """
    危険度に基づくモデル選択（マルチプロバイダー対応）

    Returns:
        (provider, model, reasoning_effort)
    """
    if provider == "anthropic":
        # Claude モデル選択
        if severity >= 15:
            return "anthropic", "claude-opus-4-1", None  # 最高性能
        elif severity >= 10:
            return "anthropic", "claude-sonnet-4-5", None  # バランス型
        else:
            return "anthropic", "claude-sonnet-4-1", None  # 高速・低コスト
    else:
        # OpenAI モデル選択（既存ロジック）
        if severity >= 15:
            return "openai", "gpt-4o", None
        elif severity >= 10:
            return "openai", "gpt-4o", None
        else:
            return "openai", "gpt-4o-mini", None

def call_claude_api(prompt: str, model: str) -> Optional[str]:
    """Claude API呼び出し"""
    if not ANTHROPIC_OK:
        return None

    try:
        from anthropic import Anthropic

        client = Anthropic(api_key=os.getenv("ANTHROPIC_API_KEY"))

        response = client.messages.create(
            model=model,
            max_tokens=8000,  # 詳細な回答のため増加
            temperature=0.3,
            messages=[
                {"role": "user", "content": prompt}
            ]
        )

        if response.content and len(response.content) > 0:
            return response.content[0].text.strip()

        return None

    except Exception as e:
        print(f"[ERROR] Claude API failed: {str(e)[:150]}")
        return None

def get_cache_key(file_path: str, content: str) -> str:
    """キャッシュキー生成"""
    content_hash = hashlib.md5(content.encode()).hexdigest()
    return f"{file_path}_{content_hash}"

def get_cached_result(cache_key: str) -> Optional[str]:
    """キャッシュから結果取得"""
    cache_file = Path(CACHE_DIR) / f"{cache_key}.json"
    if cache_file.exists():
        # キャッシュ期限チェック
        age_days = (time.time() - cache_file.stat().st_mtime) / (24 * 3600)
        if age_days < CACHE_EXPIRY_DAYS:
            with open(cache_file, 'r', encoding='utf-8') as f:
                return json.load(f).get('result')
    return None

def save_to_cache(cache_key: str, result: str):
    """結果をキャッシュに保存"""
    Path(CACHE_DIR).mkdir(exist_ok=True)
    cache_file = Path(CACHE_DIR) / f"{cache_key}.json"
    with open(cache_file, 'w', encoding='utf-8') as f:
        json.dump({'result': result, 'timestamp': time.time()}, f, ensure_ascii=False)

def analyze_with_ai_enhanced(file_path: str, code_snippet: str, problems: str, severity: int) -> str:
    """改良版AI分析 - 完全なコードと詳細説明を生成（マルチプロバイダー対応）"""
    try:
        # キャッシュチェック
        cache_key = get_cache_key(file_path, code_snippet)
        cached = get_cached_result(cache_key)
        if cached:
            return cached

        # レート制限
        rate_limiter.wait_if_needed()

        # プロバイダー決定
        provider = get_ai_provider()
        if not provider:
            return "[エラー: APIキー未設定またはSDK未導入]"

        # モデル選択（マルチプロバイダー対応）
        provider, model, reasoning_effort = select_model_for_severity(severity, provider)

        # プロンプト生成（改良版）
        prompt = get_enhanced_ai_prompt(file_path, code_snippet, problems)

        result = None

        # ===== Anthropic Claude 実行 =====
        if provider == "anthropic":
            result = call_claude_api(prompt, model)

            if not result and OPENAI_OK and os.getenv("OPENAI_API_KEY"):
                # Claudeが失敗した場合、OpenAIへフォールバック
                print(f"[INFO] Claude failed for {file_path}, falling back to OpenAI")
                provider = "openai"
                _, model, _ = select_model_for_severity(severity, "openai")

        # ===== OpenAI 実行 =====
        if provider == "openai":
            if model == "gpt-5-codex" and reasoning_effort:
                # GPT-5-Codex用（Responses API）
                response = openai.ChatCompletion.create(
                    model="o1-preview",
                    messages=[{"role": "user", "content": prompt}],
                    max_completion_tokens=16000,  # 詳細な回答のため増加
                    temperature=0.3
                )
            else:
                # GPT-4o/GPT-4o-mini用
                response = openai.ChatCompletion.create(
                    model=model,
                    messages=[
                        {"role": "system", "content": "あなたは熟練したセキュリティエンジニアです。コードの問題を詳細に分析し、完全な改善コードを提供してください。"},
                        {"role": "user", "content": prompt}
                    ],
                    max_tokens=8000,  # 詳細な回答のため増加
                    temperature=0.3
                )

            result = response.choices[0].message.content

        if not result:
            return "[エラー: AI分析失敗]"

        # キャッシュ保存
        save_to_cache(cache_key, result)

        return result

    except Exception as e:
        return f"[エラー: {str(e)}]"

def process_file(file_data: Tuple[str, int]) -> Dict:
    """単一ファイル処理（改良版）"""
    file_path, severity = file_data

    try:
        # ファイル読み込み（エンコーディング対応）
        for encoding in ['utf-8', 'shift_jis', 'cp932', 'euc-jp']:
            try:
                with open(file_path, 'r', encoding=encoding) as f:
                    content = f.read()
                break
            except UnicodeDecodeError:
                continue
        else:
            content = "[ファイル読み込みエラー: エンコーディング不明]"

        # 問題の詳細取得
        problems = get_problems_for_file(file_path)

        # AI分析（改良版）
        ai_analysis = analyze_with_ai_enhanced(file_path, content[:5000], problems, severity)

        # フォーマット整形
        formatted_result = format_enhanced_result(file_path, severity, problems, ai_analysis)

        return {
            'file_path': file_path,
            'severity': severity,
            'analysis': formatted_result,
            'success': True
        }

    except Exception as e:
        return {
            'file_path': file_path,
            'severity': severity,
            'analysis': f"[処理エラー: {str(e)}]",
            'success': False
        }

def format_enhanced_result(file_path: str, severity: int, problems: str, ai_analysis: str) -> str:
    """改良版結果フォーマット"""
    danger_level = "緊急" if severity >= 15 else "高" if severity >= 10 else "中"

    return f"""
# {file_path}

## 📊 危険度分析
- **危険度スコア**: {severity}
- **危険度レベル**: [{danger_level}]
- **検出された問題**: {problems}

## 🔍 詳細分析と完全な改善提案

{ai_analysis}

---
"""

def get_problems_for_file(file_path: str) -> str:
    """ファイルの問題詳細を取得"""
    # danger_analysis_ALLファイルから問題を抽出
    if Path(DANGER_FILE).exists():
        with open(DANGER_FILE, 'r', encoding='utf-8') as f:
            content = f.read()

        # ファイルパスで検索
        file_name = os.path.basename(file_path)
        pattern = rf"{re.escape(file_name)}.*?スコア:\s*\d+.*?問題:(.*?)(?=\n|$)"
        match = re.search(pattern, content)

        if match:
            return match.group(1).strip()

    return "詳細分析中"

def extract_problem_files() -> List[Tuple[str, int]]:
    """問題ファイルの抽出"""
    if not Path(DANGER_FILE).exists():
        print(f"[ERROR] 危険ファイルリストが見つかりません: {DANGER_FILE}")
        return []

    problem_files = []
    with open(DANGER_FILE, 'r', encoding='utf-8') as f:
        content = f.read()

    sections = content.split('###')[1:]

    for section in sections:
        lines = section.strip().split('\n')
        for line in lines:
            if 'スコア:' in line:
                score_match = re.search(r'スコア:\s*(\d+)', line)
                path_match = re.search(r'(src/[^\s]+\.\w+)', line)

                if score_match and path_match:
                    score = int(score_match.group(1))
                    if score >= 5:  # スコア5以上を対象
                        file_path = path_match.group(1)
                        problem_files.append((file_path, score))

    return sorted(problem_files, key=lambda x: x[1], reverse=True)

def main():
    """メイン処理（改良版）"""
    print("="*60)
    print("危険ファイル詳細分析システム（並列処理・改良版）")
    print("="*60)

    # 進捗状態読み込み
    progress = {}
    if Path(PROGRESS_FILE).exists():
        with open(PROGRESS_FILE, 'r', encoding='utf-8') as f:
            progress = json.load(f)

    completed_files = progress.get('completed_files', {})
    last_batch = progress.get('last_batch', 0)

    # 問題ファイル抽出
    problem_files = extract_problem_files()
    if not problem_files:
        print("[ERROR] 分析対象ファイルが見つかりません")
        return

    print(f"[INFO] 検出された問題ファイル: {len(problem_files)}件")

    # 未処理ファイルのフィルタ
    remaining_files = [(f, s) for f, s in problem_files if f not in completed_files]
    print(f"[INFO] 未処理ファイル: {len(remaining_files)}件")

    if not remaining_files:
        print("[INFO] すべてのファイルが処理済みです")
        return

    # バッチ作成
    batches = [remaining_files[i:i+BATCH_SIZE] for i in range(0, len(remaining_files), BATCH_SIZE)]
    print(f"[INFO] {len(batches)}個のバッチを作成（{BATCH_SIZE}ファイル/バッチ）")

    # 処理開始
    start_time = time.time()
    all_results = []

    for batch_idx, batch_files in enumerate(batches, start=last_batch+1):
        batch_start = time.time()
        print(f"\n[BATCH {batch_idx}] {len(batch_files)}ファイルを並列処理開始")

        # 並列処理
        with ThreadPoolExecutor(max_workers=PARALLEL_WORKERS) as executor:
            futures = []
            for file_data in batch_files:
                future = executor.submit(process_file, file_data)
                futures.append(future)

            # 進捗表示付き結果収集
            completed = 0
            for future in as_completed(futures):
                try:
                    result = future.result(timeout=300)
                    all_results.append(result)
                    completed += 1

                    # 進捗更新
                    if result['success']:
                        completed_files[result['file_path']] = True

                    # 10件ごとに進捗表示
                    if completed % 10 == 0:
                        print(f"  進捗: {completed}/{len(batch_files)}")

                except Exception as e:
                    print(f"  [ERROR] 処理失敗: {e}")

        # バッチレポート保存
        batch_report = f"{OUTPUT_DIR}/AI_batch{batch_idx:03d}_parallel_enhanced.md"
        save_batch_report_enhanced(batch_report, all_results[-len(batch_files):], batch_idx)

        # 進捗保存
        progress['completed_files'] = completed_files
        progress['last_batch'] = batch_idx
        with open(PROGRESS_FILE, 'w', encoding='utf-8') as f:
            json.dump(progress, f, ensure_ascii=False, indent=2)

        batch_time = time.time() - batch_start
        print(f"[BATCH {batch_idx}] 完了 - 処理時間: {batch_time:.1f}秒")

    # 最終レポート生成
    total_time = time.time() - start_time
    generate_final_report_enhanced(all_results, total_time)

    print("\n" + "="*60)
    print("処理完了")
    print(f"総処理時間: {total_time/60:.1f}分")
    print("="*60)

def save_batch_report_enhanced(file_path: str, results: List[Dict], batch_num: int):
    """改良版バッチレポート保存"""
    with open(file_path, 'w', encoding='utf-8') as f:
        f.write(f"# AI詳細分析レポート（改良版） - バッチ{batch_num:03d}\n\n")
        f.write(f"生成日時: {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}\n")
        f.write(f"分析ファイル数: {len(results)}\n\n")

        # サマリー
        danger_levels = {"緊急": 0, "高": 0, "中": 0}
        for r in results:
            if r['severity'] >= 15:
                danger_levels["緊急"] += 1
            elif r['severity'] >= 10:
                danger_levels["高"] += 1
            else:
                danger_levels["中"] += 1

        f.write("## エグゼクティブサマリー\n\n")
        for level, count in danger_levels.items():
            if count > 0:
                f.write(f"- [{level}] {level}対応必要: {count}件\n")

        f.write("\n---\n\n")

        # 詳細結果
        for result in results:
            f.write(result['analysis'])
            f.write("\n")

def generate_final_report_enhanced(all_results: List[Dict], total_time: float):
    """改良版最終レポート生成"""
    final_report = f"{OUTPUT_DIR}/AI_analysis_parallel_enhanced_complete.md"

    with open(final_report, 'w', encoding='utf-8') as f:
        f.write("# 🚨 完全コード分析レポート - 並列処理改良版\n\n")
        f.write(f"生成日時: {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}\n")
        f.write(f"総処理時間: {total_time/60:.1f}分\n")
        f.write(f"総分析ファイル数: {len(all_results)}\n\n")

        f.write("## 📊 このレポートの特徴\n\n")
        f.write("### ✨ 新機能\n")
        f.write("- **完全な改善コード**: 実装可能な完全版コード提供\n")
        f.write("- **詳細な影響分析**: セキュリティ、パフォーマンス、保守性への影響を詳述\n")
        f.write("- **並列処理**: 10倍高速化による効率的な分析\n")
        f.write("- **キャッシュ機能**: 重複分析の削減\n\n")

        f.write("---\n\n")

        # 全結果を統合
        for result in all_results:
            if result['success']:
                f.write(result['analysis'])
                f.write("\n")

if __name__ == "__main__":
    main()
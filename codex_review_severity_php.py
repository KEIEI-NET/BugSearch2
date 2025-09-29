#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
codex_review_severity_php.py — PHP対応版
PHP固有の問題検出機能を追加した重要度順ソート版

追加されたPHP検出項目:
  1) SQLインジェクション脆弱性
  2) XSS脆弱性
  3) セッション固定化攻撃
  4) ファイルインクルード脆弱性
  5) 非推奨関数の使用
"""
from codex_review_severity import *
import re

# PHP固有の重要度定義を追加
PHP_SEVERITY_SCORES = {
    # セキュリティ関連（最重要: 8-10点）
    "PHP: SQLインジェクション脆弱性": 10,
    "PHP: XSS脆弱性（未エスケープ出力）": 9,
    "PHP: ファイルインクルード脆弱性": 9,
    "PHP: コマンドインジェクション": 10,
    "PHP: セッション固定化攻撃の危険": 8,
    "PHP: CSRF対策不足": 8,
    "PHP: ディレクトリトラバーサル": 9,

    # 非推奨/危険な関数（重要: 5-7点）
    "PHP: mysql_*関数は非推奨（PDO/mysqli使用推奨）": 7,
    "PHP: extract()の危険な使用": 6,
    "PHP: eval()の使用（セキュリティリスク）": 9,
    "PHP: register_globalsに依存": 7,

    # エラー処理（中程度: 3-5点）
    "PHP: エラー表示が有効（本番環境リスク）": 5,
    "PHP: 例外処理不足": 4,
    "PHP: エラーログ未設定": 3,

    # パフォーマンス（低程度: 2-4点）
    "PHP: 大量データの一括取得": 4,
    "PHP: 非効率なループ処理": 3,
    "PHP: セッション開始忘れ": 2,
}

# 既存のSEVERITY_SCORESに追加
SEVERITY_SCORES.update(PHP_SEVERITY_SCORES)

def scan_php_security(text: str) -> List[str]:
    """PHP固有のセキュリティ問題を検出"""
    m: List[str] = []

    # SQLインジェクション
    if re.search(r'\$_(GET|POST|REQUEST)\[.*?\].*?(mysql_query|mysqli_query|query|exec|execute)', text, re.IGNORECASE):
        if not re.search(r'(prepare|bind_param|bindParam|quote|escape|real_escape)', text, re.IGNORECASE):
            m.append("PHP: SQLインジェクション脆弱性")

    # XSS脆弱性
    if re.search(r'echo\s+\$_(GET|POST|REQUEST|COOKIE)\[', text):
        if not re.search(r'(htmlspecialchars|htmlentities|strip_tags|filter_var)', text):
            m.append("PHP: XSS脆弱性（未エスケープ出力）")

    # ファイルインクルード
    if re.search(r'(include|require|include_once|require_once)\s*\(\s*\$_(GET|POST|REQUEST)', text):
        m.append("PHP: ファイルインクルード脆弱性")

    # コマンドインジェクション
    if re.search(r'(exec|system|shell_exec|passthru|`.*\$_(GET|POST|REQUEST).*`)', text):
        m.append("PHP: コマンドインジェクション")

    # セッション固定化
    if re.search(r'session_start\(\)', text) and not re.search(r'session_regenerate_id', text):
        m.append("PHP: セッション固定化攻撃の危険")

    # CSRF対策
    if re.search(r'<form.*method=["\']post["\']', text, re.IGNORECASE):
        if not re.search(r'(csrf|token|nonce)', text, re.IGNORECASE):
            m.append("PHP: CSRF対策不足")

    # ディレクトリトラバーサル
    if re.search(r'(file_get_contents|fopen|include|require).*\$_(GET|POST|REQUEST)', text):
        if not re.search(r'(basename|realpath|preg_match.*\.\./)', text):
            m.append("PHP: ディレクトリトラバーサル")

    return m

def scan_php_deprecated(text: str) -> List[str]:
    """PHP非推奨関数の検出"""
    m: List[str] = []

    # mysql_*関数
    if re.search(r'mysql_(connect|query|fetch|close)', text):
        m.append("PHP: mysql_*関数は非推奨（PDO/mysqli使用推奨）")

    # extract()の危険な使用
    if re.search(r'extract\s*\(\s*\$_(GET|POST|REQUEST)', text):
        m.append("PHP: extract()の危険な使用")

    # eval()の使用
    if re.search(r'eval\s*\(', text):
        m.append("PHP: eval()の使用（セキュリティリスク）")

    # register_globals
    if re.search(r'\$HTTP_(GET|POST|COOKIE|SESSION)_VARS', text):
        m.append("PHP: register_globalsに依存")

    return m

def scan_php_error(text: str) -> List[str]:
    """PHPエラー処理の検出"""
    m: List[str] = []

    # エラー表示
    if re.search(r'display_errors\s*=\s*["\']?(on|1)', text, re.IGNORECASE):
        m.append("PHP: エラー表示が有効（本番環境リスク）")

    # 例外処理
    if re.search(r'(mysql_query|mysqli_query|PDO|fopen|file_get_contents)', text):
        if not re.search(r'(try|catch|throw|Exception)', text):
            m.append("PHP: 例外処理不足")

    # エラーログ
    if re.search(r'error_reporting\s*\(\s*0\s*\)', text):
        m.append("PHP: エラーログ未設定")

    return m

def scan_php_performance(text: str) -> List[str]:
    """PHPパフォーマンス問題の検出"""
    m: List[str] = []

    # 大量データ取得
    if re.search(r'SELECT\s+\*.*FROM.*LIMIT\s+(1000|[0-9]{4,})', text, re.IGNORECASE):
        m.append("PHP: 大量データの一括取得")

    # 非効率なループ
    if re.search(r'while.*fetch.*\{.*SELECT', text, re.IGNORECASE | re.DOTALL):
        m.append("PHP: 非効率なループ処理")

    # セッション開始
    if re.search(r'\$_SESSION\[', text) and not re.search(r'session_start\(\)', text):
        m.append("PHP: セッション開始忘れ")

    return m

def scan_php(text: str) -> List[str]:
    """PHP固有の問題をすべて検出"""
    problems = []
    problems.extend(scan_php_security(text))
    problems.extend(scan_php_deprecated(text))
    problems.extend(scan_php_error(text))
    problems.extend(scan_php_performance(text))
    return problems

# 既存のadvise_file関数を拡張
def advise_file_with_php(text: str, lang: str) -> List[str]:
    """言語に応じた問題検出（PHP対応版）"""
    problems: List[str] = []

    # 既存の検出
    problems.extend(scan_money(text))
    problems.extend(scan_print(text))
    problems.extend(scan_ui(text))
    problems.extend(scan_db(text))

    # 言語固有の検出
    if lang == "go":
        problems.extend(scan_go(text))
    elif lang == "cpp" or lang == "c":
        problems.extend(scan_cpp(text))
    elif lang == "php":
        problems.extend(scan_php(text))

    return sorted(set(problems))

# メイン実行部分
if __name__ == "__main__":
    # 既存のmain処理をそのまま利用
    import sys
    from codex_review_severity import main

    # advise_file関数を上書き
    import codex_review_severity
    codex_review_severity.advise_file = advise_file_with_php

    # 実行
    sys.exit(main())
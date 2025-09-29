#!/usr/bin/env python
# -*- coding: utf-8 -*-
"""言語固有パターンのテストスクリプト"""

import json
from codex_review_severity import scan_go, scan_cpp, rule_advices, calculate_severity_score

def test_go_patterns():
    """Go言語パターンのテスト"""
    print("=== Go言語パターンテスト ===")

    with open('test_go_patterns.go', 'r', encoding='utf-8') as f:
        go_code = f.read()

    # scan_go直接呼び出し
    go_issues = scan_go(go_code)
    print(f"\nscan_go()で検出された問題: {len(go_issues)}件")
    for issue in go_issues:
        print(f"  - {issue}")

    # rule_advices経由での呼び出し
    doc = {"text": go_code, "lang": "go", "path": "test_go_patterns.go"}
    all_issues = rule_advices(doc)
    print(f"\nrule_advices()で検出された問題: {len(all_issues)}件")
    for issue in all_issues:
        print(f"  - {issue}")

    # 重要度スコア計算
    score = calculate_severity_score(all_issues)
    print(f"\n重要度スコア: {score}")

    return len(go_issues) > 0

def test_cpp_patterns():
    """C++パターンのテスト（サンプルコード）"""
    print("\n=== C++言語パターンテスト ===")

    cpp_code = """
    #include <iostream>

    void memory_leak() {
        int* ptr = new int[100];
        // delete[] ptr; // メモリリーク
    }

    void buffer_overflow() {
        char buffer[10];
        strcpy(buffer, "This is a very long string that will overflow");
    }

    void uninitialized_pointer() {
        int* ptr;
        *ptr = 42;  // 未初期化ポインタ
    }
    """

    cpp_issues = scan_cpp(cpp_code)
    print(f"\nscan_cpp()で検出された問題: {len(cpp_issues)}件")
    for issue in cpp_issues:
        print(f"  - {issue}")

    doc = {"text": cpp_code, "lang": "cpp", "path": "test.cpp"}
    all_issues = rule_advices(doc)
    print(f"\nrule_advices()で検出された問題: {len(all_issues)}件")
    for issue in all_issues:
        print(f"  - {issue}")

    score = calculate_severity_score(all_issues)
    print(f"\n重要度スコア: {score}")

    return len(cpp_issues) > 0

def check_index_entry():
    """インデックス内のtest_go_patterns.goをチェック"""
    print("\n=== インデックス内のエントリ確認 ===")

    try:
        with open('.advice_index.jsonl', 'r', encoding='utf-8') as f:
            for line in f:
                doc = json.loads(line)
                if 'test_go_patterns.go' in doc.get('path', ''):
                    print(f"\ntest_go_patterns.goのインデックスエントリ:")
                    print(f"  言語: {doc.get('lang', 'unknown')}")
                    print(f"  タグ: {doc.get('tags', [])}")
                    print(f"  問題数: {len(doc.get('advices', []))}")
                    if doc.get('advices'):
                        print("  検出された問題:")
                        for advice in doc['advices']:
                            print(f"    - {advice}")
                    return True
    except Exception as e:
        print(f"インデックス読み込みエラー: {e}")

    print("test_go_patterns.goがインデックスに見つかりません")
    return False

if __name__ == "__main__":
    go_success = test_go_patterns()
    cpp_success = test_cpp_patterns()
    index_success = check_index_entry()

    print("\n=== テスト結果サマリ ===")
    print(f"Go言語パターン検出: {'OK' if go_success else 'NG'}")
    print(f"C++言語パターン検出: {'OK' if cpp_success else 'NG'}")
    print(f"インデックス確認: {'OK' if index_success else 'NG'}")
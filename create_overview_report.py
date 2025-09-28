#!/usr/bin/env python3
"""
問題のあるファイルの概要レポートを作成するスクリプト
"""

import pathlib
import re
import time

def extract_problematic_files(report_path: pathlib.Path):
    """危険度レポートから問題のあるファイルを抽出"""
    files = []

    if not report_path.exists():
        print(f"レポートファイルが見つかりません: {report_path}")
        return files

    content = report_path.read_text(encoding='utf-8')
    sections = content.split('\n###')

    for section in sections:
        if 'csharp/' in section:
            # 「問題なし」のファイルはスキップ
            if '問題なし' in section:
                continue

            lines = section.strip().split('\n')
            if lines:
                first_line = lines[0].strip()
                path_match = re.search(r'csharp/[^\s]+\.(cs|py|java|js|ts|aspx)', first_line)

                if path_match:
                    file_path = 'src/' + path_match.group()

                    # スコアを抽出
                    score = 0
                    for line in lines:
                        score_match = re.search(r'スコア:\s*(\d+)', line)
                        if score_match:
                            score = int(score_match.group(1))
                            break

                    # 言語を抽出
                    language = 'unknown'
                    for line in lines:
                        lang_match = re.search(r'言語[^:]*:\s*(\w+)', line)
                        if lang_match:
                            language = lang_match.group(1)
                            break

                    # 問題を抽出
                    problems = []
                    for line in lines:
                        if '入力検証' in line and '入力検証が不十分' not in problems:
                            problems.append('入力検証が不十分')
                        if ('N+1' in line or 'ループ内SELECT' in line) and 'N+1問題' not in problems:
                            problems.append('N+1問題')
                        if 'SELECT *' in line and 'SELECT * 使用' not in problems:
                            problems.append('SELECT * 使用')
                        if ('浮動小数' in line or 'float' in line) and '金額計算に浮動小数' not in problems:
                            problems.append('金額計算に浮動小数')
                        if 'ダイアログ' in line and 'UIダイアログ多用' not in problems:
                            problems.append('UIダイアログ多用')

                    if score >= 1 and problems:
                        files.append({
                            'path': file_path,
                            'score': score,
                            'language': language,
                            'problems': problems
                        })

    files.sort(key=lambda x: x['score'], reverse=True)
    return files

def create_overview_report():
    """問題ファイルの概要レポート作成"""
    report_path = pathlib.Path("reports/src_complete_danger_analysis.md")
    problematic_files = extract_problematic_files(report_path)

    if not problematic_files:
        print("問題のあるファイルが見つかりませんでした")
        return

    output_path = pathlib.Path("reports/AI分析.md")

    # グループ化
    critical_files = [f for f in problematic_files if f['score'] >= 15]
    high_files = [f for f in problematic_files if 10 <= f['score'] < 15]
    medium_files = [f for f in problematic_files if 5 <= f['score'] < 10]
    low_files = [f for f in problematic_files if 1 <= f['score'] < 5]

    content = f"""# 問題のあるファイル一覧（問題なし以外）

生成日時: {time.strftime('%Y-%m-%d %H:%M:%S')}
総問題ファイル数: {len(problematic_files)}

## 危険度別サマリー

| 危険度 | スコア範囲 | ファイル数 | 割合 |
|--------|-----------|-----------|------|
| 緊急 | 15以上 | {len(critical_files)} | {len(critical_files)*100//len(problematic_files)}% |
| 高 | 10-14 | {len(high_files)} | {len(high_files)*100//len(problematic_files)}% |
| 中 | 5-9 | {len(medium_files)} | {len(medium_files)*100//len(problematic_files)}% |
| 低 | 1-4 | {len(low_files)} | {len(low_files)*100//len(problematic_files)}% |

## 緊急対応が必要なファイル（スコア15以上）

| ファイルパス | スコア | 主な問題 |
|-------------|--------|----------|
"""

    for f in critical_files[:50]:  # 最初の50件
        problems_str = ', '.join(f['problems'][:3])
        content += f"| {f['path']} | {f['score']} | {problems_str} |\n"

    if len(critical_files) > 50:
        content += f"| ... 他{len(critical_files)-50}ファイル | ... | ... |\n"

    content += f"""

## 高優先度ファイル（スコア10-14）

| ファイルパス | スコア | 主な問題 |
|-------------|--------|----------|
"""

    for f in high_files[:30]:
        problems_str = ', '.join(f['problems'][:3])
        content += f"| {f['path']} | {f['score']} | {problems_str} |\n"

    if len(high_files) > 30:
        content += f"| ... 他{len(high_files)-30}ファイル | ... | ... |\n"

    content += f"""

## 中優先度ファイル（スコア5-9）

総数: {len(medium_files)}ファイル

### 主な問題パターン
"""

    # 問題パターンの集計
    problem_counts = {}
    for f in medium_files:
        for problem in f['problems']:
            problem_counts[problem] = problem_counts.get(problem, 0) + 1

    for problem, count in sorted(problem_counts.items(), key=lambda x: x[1], reverse=True):
        content += f"- {problem}: {count}件\n"

    content += f"""

## 低優先度ファイル（スコア1-4）

総数: {len(low_files)}ファイル

### ファイルリスト（最初の100件）

"""

    for i, f in enumerate(low_files[:100], 1):
        content += f"{i}. {f['path']} (スコア: {f['score']})\n"

    if len(low_files) > 100:
        content += f"\n... 他{len(low_files)-100}ファイル\n"

    content += f"""

---

## 詳細分析について

各ファイルの詳細な改善提案は以下のレポートをご確認ください：

- `AI分析_詳細_完全版.md` - 全2,600ファイルの詳細分析と具体的な改善コード
- `AI分析_詳細_batch1.md`〜`batch6.md` - バッチごとの詳細分析

詳細レポートには以下が含まれています：
- 問題の詳細説明
- 影響範囲の分析
- 具体的な改善コード例（完全版）
- ソースコード全体の分析と変更提案

"""

    output_path.write_text(content, encoding='utf-8')
    print(f"概要レポート作成完了: {output_path}")
    print(f"総問題ファイル数: {len(problematic_files)}")

if __name__ == "__main__":
    create_overview_report()
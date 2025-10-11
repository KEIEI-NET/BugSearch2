"""
レポート比較エンジン

Phase 6.0の新機能:
- 複数レポートの差分比較
- 時系列での問題追跡
- 改善・悪化の自動検出

バージョン: v4.7.0 (Phase 6.0)
作成日: 2025年10月12日 JST

@perfect品質:
- 型ヒント完備
- エラーハンドリング
- データ検証
"""

from pathlib import Path
from typing import List, Dict, Optional, Set
from dataclasses import dataclass
from datetime import datetime
import json


@dataclass
class ReportDiff:
    """レポート差分情報"""
    new_issues: List[Dict]  # 新規問題
    fixed_issues: List[Dict]  # 修正された問題
    unchanged_issues: List[Dict]  # 未修正の問題
    worsened_issues: List[Dict]  # 悪化した問題
    total_changes: int

    @property
    def improvement_rate(self) -> float:
        """改善率を計算（0.0-1.0）"""
        total = len(self.new_issues) + len(self.fixed_issues)
        if total == 0:
            return 0.0
        return len(self.fixed_issues) / total

    @property
    def summary(self) -> str:
        """差分サマリーを生成"""
        return (
            f"新規: {len(self.new_issues)}件 | "
            f"修正: {len(self.fixed_issues)}件 | "
            f"未修正: {len(self.unchanged_issues)}件 | "
            f"悪化: {len(self.worsened_issues)}件 | "
            f"改善率: {self.improvement_rate:.1%}"
        )


class ReportComparator:
    """
    レポート比較エンジン

    複数のレポートを比較して差分を抽出します。

    使用例:
        comparator = ReportComparator()

        # 2つのレポートを比較
        diff = comparator.compare_reports(
            old_report=Path("reports/2025-01-01.json"),
            new_report=Path("reports/2025-01-15.json")
        )

        print(f"新規問題: {len(diff.new_issues)}件")
        print(f"修正済み: {len(diff.fixed_issues)}件")
        print(f"改善率: {diff.improvement_rate:.1%}")
    """

    def __init__(self):
        """初期化"""
        pass

    def compare_reports(
        self,
        old_report: Path,
        new_report: Path
    ) -> ReportDiff:
        """
        2つのレポートを比較

        Args:
            old_report: 旧レポートファイル
            new_report: 新レポートファイル

        Returns:
            差分情報

        Raises:
            FileNotFoundError: レポートファイルが見つからない
            ValueError: レポートフォーマットが不正
        """
        # レポートファイル存在確認
        if not old_report.exists():
            raise FileNotFoundError(f"旧レポートが見つかりません: {old_report}")
        if not new_report.exists():
            raise FileNotFoundError(f"新レポートが見つかりません: {new_report}")

        # レポートファイル読み込み
        old_data = self._load_report(old_report)
        new_data = self._load_report(new_report)

        # 問題IDでマッピング
        old_issues = {self._issue_key(i): i for i in old_data.get('issues', [])}
        new_issues = {self._issue_key(i): i for i in new_data.get('issues', [])}

        # 差分計算
        new_keys = set(new_issues.keys()) - set(old_issues.keys())
        fixed_keys = set(old_issues.keys()) - set(new_issues.keys())
        unchanged_keys = set(old_issues.keys()) & set(new_issues.keys())

        new = [new_issues[k] for k in new_keys]
        fixed = [old_issues[k] for k in fixed_keys]
        unchanged = [new_issues[k] for k in unchanged_keys]

        # 悪化した問題の検出（深刻度が上がった）
        worsened = []
        for key in unchanged_keys:
            old_severity = old_issues[key].get('severity', 0)
            new_severity = new_issues[key].get('severity', 0)
            if new_severity > old_severity:
                worsened.append(new_issues[key])

        return ReportDiff(
            new_issues=new,
            fixed_issues=fixed,
            unchanged_issues=unchanged,
            worsened_issues=worsened,
            total_changes=len(new) + len(fixed) + len(worsened)
        )

    def compare_multiple_reports(
        self,
        report_files: List[Path]
    ) -> List[ReportDiff]:
        """
        複数レポートを時系列で比較

        Args:
            report_files: レポートファイルのリスト（時系列順）

        Returns:
            差分情報のリスト

        Raises:
            ValueError: レポート数が2未満
        """
        if len(report_files) < 2:
            raise ValueError("比較には2つ以上のレポートが必要です")

        diffs = []
        for i in range(len(report_files) - 1):
            diff = self.compare_reports(report_files[i], report_files[i + 1])
            diffs.append(diff)

        return diffs

    def generate_comparison_report(
        self,
        old_report: Path,
        new_report: Path,
        output_file: Optional[Path] = None
    ) -> str:
        """
        比較レポートを生成

        Args:
            old_report: 旧レポートファイル
            new_report: 新レポートファイル
            output_file: 出力ファイル（オプション）

        Returns:
            レポート内容（Markdown形式）
        """
        diff = self.compare_reports(old_report, new_report)

        # Markdownレポート生成
        report_lines = [
            "# レポート比較分析",
            "",
            f"**旧レポート**: `{old_report.name}`",
            f"**新レポート**: `{new_report.name}`",
            f"**生成日時**: {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}",
            "",
            "## サマリー",
            "",
            diff.summary,
            "",
            "## 詳細",
            "",
            f"### 新規問題 ({len(diff.new_issues)}件)",
            ""
        ]

        # 新規問題
        if diff.new_issues:
            for issue in diff.new_issues[:10]:  # 上位10件
                report_lines.extend([
                    f"- **{issue.get('file', 'unknown')}:{issue.get('line', '?')}**",
                    f"  - ルールID: `{issue.get('rule_id', 'unknown')}`",
                    f"  - 深刻度: {issue.get('severity', 0)}",
                    f"  - メッセージ: {issue.get('message', '')}",
                    ""
                ])
            if len(diff.new_issues) > 10:
                report_lines.append(f"*(他 {len(diff.new_issues) - 10}件)*")
                report_lines.append("")
        else:
            report_lines.extend(["なし", ""])

        # 修正済み問題
        report_lines.extend([
            f"### 修正済み問題 ({len(diff.fixed_issues)}件)",
            ""
        ])

        if diff.fixed_issues:
            for issue in diff.fixed_issues[:10]:
                report_lines.extend([
                    f"- **{issue.get('file', 'unknown')}:{issue.get('line', '?')}**",
                    f"  - ルールID: `{issue.get('rule_id', 'unknown')}`",
                    f"  - 深刻度: {issue.get('severity', 0)}",
                    ""
                ])
            if len(diff.fixed_issues) > 10:
                report_lines.append(f"*(他 {len(diff.fixed_issues) - 10}件)*")
                report_lines.append("")
        else:
            report_lines.extend(["なし", ""])

        # 悪化した問題
        if diff.worsened_issues:
            report_lines.extend([
                f"### ⚠️ 悪化した問題 ({len(diff.worsened_issues)}件)",
                ""
            ])
            for issue in diff.worsened_issues:
                report_lines.extend([
                    f"- **{issue.get('file', 'unknown')}:{issue.get('line', '?')}**",
                    f"  - ルールID: `{issue.get('rule_id', 'unknown')}`",
                    f"  - 深刻度: {issue.get('severity', 0)}",
                    ""
                ])

        report = "\n".join(report_lines)

        # ファイル出力
        if output_file:
            output_file.parent.mkdir(parents=True, exist_ok=True)
            output_file.write_text(report, encoding='utf-8')
            print(f"[INFO] 比較レポート生成: {output_file}")

        return report

    def _load_report(self, report_file: Path) -> Dict:
        """
        レポートファイルを読み込み

        Args:
            report_file: レポートファイル

        Returns:
            レポートデータ

        Raises:
            ValueError: JSONフォーマットが不正
        """
        try:
            with open(report_file, 'r', encoding='utf-8') as f:
                data = json.load(f)

            # 基本的な構造チェック
            if not isinstance(data, dict):
                raise ValueError("レポートフォーマットが不正: ルートはオブジェクトでなければなりません")

            if 'issues' in data and not isinstance(data['issues'], list):
                raise ValueError("レポートフォーマットが不正: issuesはリストでなければなりません")

            return data

        except json.JSONDecodeError as e:
            raise ValueError(f"JSONパースエラー: {e}")

    def _issue_key(self, issue: Dict) -> str:
        """
        問題の一意キーを生成

        同じファイル、行、ルールIDの組み合わせを同一問題として扱う

        Args:
            issue: 問題情報

        Returns:
            一意キー
        """
        file_path = issue.get('file', 'unknown')
        line = issue.get('line', 0)
        rule_id = issue.get('rule_id', 'unknown')

        return f"{file_path}:{line}:{rule_id}"


if __name__ == "__main__":
    # 簡易テスト
    print("ReportComparator簡易テスト")
    print("-" * 80)

    comparator = ReportComparator()

    # テスト用ダミーレポート作成
    test_old = {
        'timestamp': '2025-01-01T00:00:00',
        'issues': [
            {'file': 'src/test.py', 'line': 10, 'rule_id': 'TEST_1', 'severity': 5, 'message': 'Issue 1'},
            {'file': 'src/test.py', 'line': 20, 'rule_id': 'TEST_2', 'severity': 8, 'message': 'Issue 2'},
            {'file': 'src/test.py', 'line': 30, 'rule_id': 'TEST_3', 'severity': 3, 'message': 'Issue 3'},
        ]
    }

    test_new = {
        'timestamp': '2025-01-15T00:00:00',
        'issues': [
            {'file': 'src/test.py', 'line': 20, 'rule_id': 'TEST_2', 'severity': 9, 'message': 'Issue 2 (worse)'},
            {'file': 'src/test.py', 'line': 30, 'rule_id': 'TEST_3', 'severity': 3, 'message': 'Issue 3'},
            {'file': 'src/test.py', 'line': 40, 'rule_id': 'TEST_4', 'severity': 7, 'message': 'Issue 4 (new)'},
        ]
    }

    # ダミーファイル作成
    import tempfile
    with tempfile.NamedTemporaryFile(mode='w', suffix='.json', delete=False, encoding='utf-8') as f_old:
        json.dump(test_old, f_old, indent=2, ensure_ascii=False)
        old_path = Path(f_old.name)

    with tempfile.NamedTemporaryFile(mode='w', suffix='.json', delete=False, encoding='utf-8') as f_new:
        json.dump(test_new, f_new, indent=2, ensure_ascii=False)
        new_path = Path(f_new.name)

    try:
        # 比較実行
        diff = comparator.compare_reports(old_path, new_path)

        print("結果:")
        print(diff.summary)
        print()
        print(f"新規問題: {len(diff.new_issues)}件")
        for issue in diff.new_issues:
            print(f"  - {issue['file']}:{issue['line']} [{issue['rule_id']}]")

        print()
        print(f"修正済み: {len(diff.fixed_issues)}件")
        for issue in diff.fixed_issues:
            print(f"  - {issue['file']}:{issue['line']} [{issue['rule_id']}]")

        print()
        print(f"悪化した問題: {len(diff.worsened_issues)}件")
        for issue in diff.worsened_issues:
            print(f"  - {issue['file']}:{issue['line']} [{issue['rule_id']}]")

    finally:
        # クリーンアップ
        old_path.unlink()
        new_path.unlink()

    print()
    try:
        print("✅ 簡易テスト完了")
    except UnicodeEncodeError:
        print("[OK] 簡易テスト完了")

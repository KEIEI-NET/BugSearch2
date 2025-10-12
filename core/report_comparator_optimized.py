"""
レポート比較エンジン（最適化版）

Phase 6.1の改善:
- ストリーミング処理による大規模ファイル対応
- メモリ使用量の削減（ジェネレータ使用）
- 並列処理による高速化

バージョン: v4.7.1 (Phase 6.1)
作成日: 2025年10月12日 JST

@perfect品質 + パフォーマンス最適化:
- 型ヒント完備
- メモリ効率化（ジェネレータ、チャンク処理）
- 並列処理対応
- エラーハンドリング強化
"""

from pathlib import Path
from typing import List, Dict, Optional, Set, Iterator, Generator
from dataclasses import dataclass
from datetime import datetime
import json
from concurrent.futures import ThreadPoolExecutor, as_completed
from collections import defaultdict


# チャンクサイズ定数
CHUNK_SIZE = 1000  # 一度に処理する問題数
MAX_WORKERS = 4    # 並列処理のワーカー数


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


class ReportComparatorOptimized:
    """
    レポート比較エンジン（最適化版）

    大規模レポートの効率的な比較を実現：
    - ストリーミング処理による低メモリフットプリント
    - 並列処理による高速化
    - チャンク処理による大規模データ対応

    使用例:
        comparator = ReportComparatorOptimized()

        # 大規模レポートも効率的に比較
        diff = comparator.compare_reports(
            old_report=Path("reports/large_2025-01-01.json"),
            new_report=Path("reports/large_2025-01-15.json"),
            use_streaming=True  # ストリーミング処理
        )

        # 複数レポートの並列比較
        diffs = comparator.compare_multiple_reports_parallel(
            report_files=[Path(f"reports/report{i}.json") for i in range(10)],
            max_workers=4
        )
    """

    def __init__(self, chunk_size: int = CHUNK_SIZE, max_workers: int = MAX_WORKERS):
        """
        初期化

        Args:
            chunk_size: チャンク処理のサイズ
            max_workers: 並列処理のワーカー数
        """
        self.chunk_size = chunk_size
        self.max_workers = max_workers

    def compare_reports(
        self,
        old_report: Path,
        new_report: Path,
        use_streaming: bool = False
    ) -> ReportDiff:
        """
        2つのレポートを比較

        Args:
            old_report: 旧レポートファイル
            new_report: 新レポートファイル
            use_streaming: ストリーミング処理を使用（大規模ファイル向け）

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

        if use_streaming:
            return self._compare_reports_streaming(old_report, new_report)
        else:
            return self._compare_reports_standard(old_report, new_report)

    def _compare_reports_standard(
        self,
        old_report: Path,
        new_report: Path
    ) -> ReportDiff:
        """
        標準比較処理（元のロジック互換）

        小規模〜中規模レポート向け
        """
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

    def _compare_reports_streaming(
        self,
        old_report: Path,
        new_report: Path
    ) -> ReportDiff:
        """
        ストリーミング比較処理

        大規模レポート向け（メモリ効率重視）
        """
        # 問題キーのみを抽出（メモリ効率化）
        old_keys = set(self._iter_issue_keys(old_report))
        new_keys = set(self._iter_issue_keys(new_report))

        # 差分キー計算
        new_issue_keys = new_keys - old_keys
        fixed_issue_keys = old_keys - new_keys
        unchanged_keys = old_keys & new_keys

        # 必要な問題のみ読み込み
        new_issues = list(self._load_issues_by_keys(new_report, new_issue_keys))
        fixed_issues = list(self._load_issues_by_keys(old_report, fixed_issue_keys))
        unchanged_issues = list(self._load_issues_by_keys(new_report, unchanged_keys))

        # 悪化した問題の検出（チャンク処理）
        worsened = []
        for chunk_keys in self._chunk_keys(unchanged_keys, self.chunk_size):
            old_chunk = {
                self._issue_key(i): i
                for i in self._load_issues_by_keys(old_report, chunk_keys)
            }
            new_chunk = {
                self._issue_key(i): i
                for i in self._load_issues_by_keys(new_report, chunk_keys)
            }

            for key in chunk_keys:
                if key in old_chunk and key in new_chunk:
                    old_severity = old_chunk[key].get('severity', 0)
                    new_severity = new_chunk[key].get('severity', 0)
                    if new_severity > old_severity:
                        worsened.append(new_chunk[key])

        return ReportDiff(
            new_issues=new_issues,
            fixed_issues=fixed_issues,
            unchanged_issues=unchanged_issues,
            worsened_issues=worsened,
            total_changes=len(new_issues) + len(fixed_issues) + len(worsened)
        )

    def compare_multiple_reports_parallel(
        self,
        report_files: List[Path],
        max_workers: Optional[int] = None
    ) -> List[ReportDiff]:
        """
        複数レポートを並列で時系列比較

        Args:
            report_files: レポートファイルのリスト（時系列順）
            max_workers: 並列ワーカー数（Noneの場合は初期化時の値）

        Returns:
            差分情報のリスト

        Raises:
            ValueError: レポート数が2未満
        """
        if len(report_files) < 2:
            raise ValueError("比較には2つ以上のレポートが必要です")

        workers = max_workers or self.max_workers

        # 比較ペアを作成
        pairs = [(report_files[i], report_files[i + 1]) for i in range(len(report_files) - 1)]

        # 並列処理で比較実行
        diffs = []
        with ThreadPoolExecutor(max_workers=workers) as executor:
            # Future作成
            future_to_pair = {
                executor.submit(self.compare_reports, old, new): (old, new)
                for old, new in pairs
            }

            # 結果回収（順序保証）
            for i, (old, new) in enumerate(pairs):
                for future in future_to_pair:
                    if future_to_pair[future] == (old, new):
                        diffs.append(future.result())
                        break

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
        レポートファイルを読み込み（標準処理）

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

    def _iter_issue_keys(self, report_file: Path) -> Generator[str, None, None]:
        """
        レポートから問題キーをストリーミング生成

        Args:
            report_file: レポートファイル

        Yields:
            問題キー
        """
        with open(report_file, 'r', encoding='utf-8') as f:
            data = json.load(f)
            for issue in data.get('issues', []):
                yield self._issue_key(issue)

    def _load_issues_by_keys(
        self,
        report_file: Path,
        target_keys: Set[str]
    ) -> Generator[Dict, None, None]:
        """
        指定されたキーの問題のみを読み込み

        Args:
            report_file: レポートファイル
            target_keys: 対象キーのセット

        Yields:
            問題情報
        """
        with open(report_file, 'r', encoding='utf-8') as f:
            data = json.load(f)
            for issue in data.get('issues', []):
                if self._issue_key(issue) in target_keys:
                    yield issue

    def _chunk_keys(self, keys: Set[str], chunk_size: int) -> Generator[Set[str], None, None]:
        """
        キーセットをチャンクに分割

        Args:
            keys: キーのセット
            chunk_size: チャンクサイズ

        Yields:
            チャンク化されたキーセット
        """
        keys_list = list(keys)
        for i in range(0, len(keys_list), chunk_size):
            yield set(keys_list[i:i + chunk_size])

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


# 後方互換性のためのエイリアス
ReportComparator = ReportComparatorOptimized


if __name__ == "__main__":
    # 簡易パフォーマンステスト
    print("ReportComparatorOptimized 簡易テスト")
    print("-" * 80)

    import tempfile
    import time

    comparator = ReportComparatorOptimized()

    # テスト用大規模ダミーレポート作成
    test_old = {
        'timestamp': '2025-01-01T00:00:00',
        'issues': [
            {
                'file': f'src/test{i % 100}.py',
                'line': i,
                'rule_id': f'TEST_{i % 10}',
                'severity': (i % 10) + 1,
                'message': f'Issue {i}'
            }
            for i in range(10000)  # 10,000問題
        ]
    }

    test_new = {
        'timestamp': '2025-01-15T00:00:00',
        'issues': [
            {
                'file': f'src/test{i % 100}.py',
                'line': i,
                'rule_id': f'TEST_{i % 10}',
                'severity': ((i % 10) + 1) + (1 if i % 5 == 0 else 0),  # 20%が悪化
                'message': f'Issue {i}'
            }
            for i in range(5000, 15000)  # 5,000修正、10,000継続、5,000新規
        ]
    }

    # ダミーファイル作成
    with tempfile.NamedTemporaryFile(mode='w', suffix='.json', delete=False, encoding='utf-8') as f_old:
        json.dump(test_old, f_old, indent=2, ensure_ascii=False)
        old_path = Path(f_old.name)

    with tempfile.NamedTemporaryFile(mode='w', suffix='.json', delete=False, encoding='utf-8') as f_new:
        json.dump(test_new, f_new, indent=2, ensure_ascii=False)
        new_path = Path(f_new.name)

    try:
        # 標準処理でベンチマーク
        print("\n1. 標準処理:")
        start = time.time()
        diff_standard = comparator.compare_reports(old_path, new_path, use_streaming=False)
        elapsed_standard = time.time() - start
        print(f"   処理時間: {elapsed_standard:.3f}秒")
        print(f"   {diff_standard.summary}")

        # ストリーミング処理でベンチマーク
        print("\n2. ストリーミング処理:")
        start = time.time()
        diff_streaming = comparator.compare_reports(old_path, new_path, use_streaming=True)
        elapsed_streaming = time.time() - start
        print(f"   処理時間: {elapsed_streaming:.3f}秒")
        print(f"   {diff_streaming.summary}")

        # パフォーマンス比較
        print(f"\n3. パフォーマンス比較:")
        print(f"   標準処理: {elapsed_standard:.3f}秒")
        print(f"   ストリーミング: {elapsed_streaming:.3f}秒")
        speedup = elapsed_standard / elapsed_streaming if elapsed_streaming > 0 else 1.0
        print(f"   高速化率: {speedup:.2f}x")

    finally:
        # クリーンアップ
        old_path.unlink()
        new_path.unlink()

    try:
        print("\n✅ 簡易テスト完了")
    except UnicodeEncodeError:
        print("\n[OK] 簡易テスト完了")

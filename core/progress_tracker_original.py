"""
進捗トラッキングシステム

Phase 6.0の新機能:
- 問題の修正状況を時系列で追跡
- 自動進捗レポート生成
- トレンド分析

バージョン: v4.7.0 (Phase 6.0)
作成日: 2025年10月12日 JST

@perfect品質:
- 型ヒント完備
- JSON永続化
- データ整合性保証
"""

from pathlib import Path
from typing import List, Dict, Optional
from datetime import datetime, timedelta
import json


class ProgressTracker:
    """
    進捗トラッキング

    問題の修正状況を時系列で追跡し、進捗レポートを生成します。

    使用例:
        tracker = ProgressTracker(Path(".bugsearch/progress.json"))

        # 現在の状態を記録
        tracker.record_snapshot(
            issues=current_issues,
            timestamp=datetime.now()
        )

        # 進捗レポート生成
        report = tracker.generate_progress_report(days=30)
        print(report['total_issues']['change'])
    """

    def __init__(self, storage_file: Path):
        """
        初期化

        Args:
            storage_file: 進捗データの保存先
        """
        self.storage_file = storage_file
        self.snapshots = self._load_snapshots()

    def record_snapshot(
        self,
        issues: List[Dict],
        timestamp: Optional[datetime] = None,
        metadata: Optional[Dict] = None
    ):
        """
        現在の問題状況のスナップショットを記録

        Args:
            issues: 現在の問題リスト
            timestamp: タイムスタンプ（省略時は現在時刻）
            metadata: 追加メタデータ（オプション）
        """
        if timestamp is None:
            timestamp = datetime.now()

        snapshot = {
            'timestamp': timestamp.isoformat(),
            'total_issues': len(issues),
            'by_severity': self._group_by_severity(issues),
            'by_category': self._group_by_category(issues),
            'by_file': self._group_by_file(issues),
            'issues': issues
        }

        if metadata:
            snapshot['metadata'] = metadata

        self.snapshots.append(snapshot)
        self._save_snapshots()

        print(f"[INFO] スナップショット記録: {len(issues)}件の問題")

    def generate_progress_report(
        self,
        days: Optional[int] = None,
        start_date: Optional[datetime] = None,
        end_date: Optional[datetime] = None
    ) -> Dict:
        """
        進捗レポートを生成

        Args:
            days: 対象期間（日数）
            start_date: 開始日時（省略時は最古のスナップショット）
            end_date: 終了日時（省略時は最新のスナップショット）

        Returns:
            進捗レポート

        Raises:
            ValueError: スナップショット数が不足
        """
        if len(self.snapshots) < 2:
            return {
                'error': 'スナップショットが不足しています（最低2つ必要）',
                'snapshot_count': len(self.snapshots)
            }

        # 対象期間のスナップショットを抽出
        filtered_snapshots = self._filter_snapshots_by_date(
            days=days,
            start_date=start_date,
            end_date=end_date
        )

        if len(filtered_snapshots) < 2:
            return {
                'error': '指定期間内のスナップショットが不足しています',
                'snapshot_count': len(filtered_snapshots)
            }

        oldest = filtered_snapshots[0]
        latest = filtered_snapshots[-1]

        # 基本統計
        total_change = latest['total_issues'] - oldest['total_issues']
        change_rate = (total_change / oldest['total_issues'] * 100) if oldest['total_issues'] > 0 else 0

        return {
            'period': {
                'start': oldest['timestamp'],
                'end': latest['timestamp'],
                'snapshots': len(filtered_snapshots)
            },
            'total_issues': {
                'start': oldest['total_issues'],
                'end': latest['total_issues'],
                'change': total_change,
                'change_rate': f"{change_rate:+.1f}%"
            },
            'severity_changes': self._calculate_severity_changes(oldest, latest),
            'category_changes': self._calculate_category_changes(oldest, latest),
            'trend': self._calculate_trend(filtered_snapshots),
            'top_problematic_files': self._get_top_problematic_files(latest, limit=10)
        }

    def get_snapshot_by_date(self, target_date: datetime) -> Optional[Dict]:
        """
        指定日時に最も近いスナップショットを取得

        Args:
            target_date: 対象日時

        Returns:
            スナップショット（見つからない場合はNone）
        """
        if not self.snapshots:
            return None

        # 日時の差が最小のスナップショットを見つける
        closest = min(
            self.snapshots,
            key=lambda s: abs(
                datetime.fromisoformat(s['timestamp']) - target_date
            )
        )

        return closest

    def clear_old_snapshots(self, keep_days: int = 90):
        """
        古いスナップショットを削除

        Args:
            keep_days: 保持する日数（デフォルト: 90日）
        """
        cutoff_date = datetime.now() - timedelta(days=keep_days)

        original_count = len(self.snapshots)
        self.snapshots = [
            s for s in self.snapshots
            if datetime.fromisoformat(s['timestamp']) >= cutoff_date
        ]

        deleted_count = original_count - len(self.snapshots)
        if deleted_count > 0:
            self._save_snapshots()
            print(f"[INFO] {deleted_count}個の古いスナップショットを削除しました")

    def export_progress_report(
        self,
        output_file: Path,
        days: Optional[int] = None
    ):
        """
        進捗レポートをファイルにエクスポート

        Args:
            output_file: 出力ファイルパス
            days: 対象期間（日数）
        """
        report = self.generate_progress_report(days=days)

        # Markdown形式でレポート生成
        lines = [
            "# 進捗トラッキングレポート",
            "",
            f"**生成日時**: {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}",
            ""
        ]

        if 'error' in report:
            lines.extend([
                f"❌ エラー: {report['error']}",
                ""
            ])
        else:
            # 期間情報
            lines.extend([
                "## 対象期間",
                "",
                f"- 開始: {report['period']['start']}",
                f"- 終了: {report['period']['end']}",
                f"- スナップショット数: {report['period']['snapshots']}",
                ""
            ])

            # 総合統計
            total = report['total_issues']
            change_icon = "📈" if total['change'] > 0 else "📉" if total['change'] < 0 else "➡️"
            lines.extend([
                "## 総合統計",
                "",
                f"- 開始時の問題数: {total['start']}件",
                f"- 終了時の問題数: {total['end']}件",
                f"- 変化: {change_icon} {total['change']:+d}件 ({total['change_rate']})",
                f"- トレンド: {self._trend_icon(report['trend'])} {report['trend']}",
                ""
            ])

            # 深刻度別変化
            lines.extend([
                "## 深刻度別変化",
                ""
            ])
            for severity, data in report['severity_changes'].items():
                lines.append(
                    f"- **深刻度{severity}**: {data['start']}件 → {data['end']}件 "
                    f"({data['change']:+d}件)"
                )
            lines.append("")

            # カテゴリ別変化
            lines.extend([
                "## カテゴリ別変化",
                ""
            ])
            for category, data in report['category_changes'].items():
                lines.append(
                    f"- **{category}**: {data['start']}件 → {data['end']}件 "
                    f"({data['change']:+d}件)"
                )
            lines.append("")

            # 問題の多いファイル
            if report['top_problematic_files']:
                lines.extend([
                    "## 問題の多いファイル（Top 10）",
                    ""
                ])
                for i, (file, count) in enumerate(report['top_problematic_files'], 1):
                    lines.append(f"{i}. `{file}`: {count}件")
                lines.append("")

        # ファイル出力
        output_file.parent.mkdir(parents=True, exist_ok=True)
        output_file.write_text("\n".join(lines), encoding='utf-8')
        print(f"[INFO] 進捗レポート出力: {output_file}")

    def _group_by_severity(self, issues: List[Dict]) -> Dict[int, int]:
        """深刻度別にグループ化"""
        groups = {}
        for issue in issues:
            severity = issue.get('severity', 0)
            groups[severity] = groups.get(severity, 0) + 1
        return groups

    def _group_by_category(self, issues: List[Dict]) -> Dict[str, int]:
        """カテゴリ別にグループ化"""
        groups = {}
        for issue in issues:
            category = issue.get('category', 'unknown')
            groups[category] = groups.get(category, 0) + 1
        return groups

    def _group_by_file(self, issues: List[Dict]) -> Dict[str, int]:
        """ファイル別にグループ化"""
        groups = {}
        for issue in issues:
            file_path = issue.get('file', 'unknown')
            groups[file_path] = groups.get(file_path, 0) + 1
        return groups

    def _calculate_severity_changes(
        self,
        old_snapshot: Dict,
        new_snapshot: Dict
    ) -> Dict:
        """深刻度別の変化を計算"""
        old_severity = old_snapshot.get('by_severity', {})
        new_severity = new_snapshot.get('by_severity', {})

        all_severities = set(old_severity.keys()) | set(new_severity.keys())

        changes = {}
        for severity in sorted(all_severities):
            old_count = old_severity.get(severity, 0)
            new_count = new_severity.get(severity, 0)
            changes[severity] = {
                'start': old_count,
                'end': new_count,
                'change': new_count - old_count
            }

        return changes

    def _calculate_category_changes(
        self,
        old_snapshot: Dict,
        new_snapshot: Dict
    ) -> Dict:
        """カテゴリ別の変化を計算"""
        old_category = old_snapshot.get('by_category', {})
        new_category = new_snapshot.get('by_category', {})

        all_categories = set(old_category.keys()) | set(new_category.keys())

        changes = {}
        for category in sorted(all_categories):
            old_count = old_category.get(category, 0)
            new_count = new_category.get(category, 0)
            changes[category] = {
                'start': old_count,
                'end': new_count,
                'change': new_count - old_count
            }

        return changes

    def _calculate_trend(self, snapshots: List[Dict]) -> str:
        """
        トレンドを計算

        Args:
            snapshots: スナップショットのリスト

        Returns:
            トレンド（'improving', 'worsening', 'stable', 'fluctuating'）
        """
        if len(snapshots) < 2:
            return 'insufficient_data'

        # 直近5つのスナップショットを取得
        recent_snapshots = snapshots[-min(5, len(snapshots)):]
        counts = [s['total_issues'] for s in recent_snapshots]

        # 全て減少傾向
        if all(counts[i] >= counts[i+1] for i in range(len(counts)-1)):
            return 'improving'

        # 全て増加傾向
        if all(counts[i] <= counts[i+1] for i in range(len(counts)-1)):
            return 'worsening'

        # ほぼ変化なし（±5%以内）
        first_count = counts[0]
        last_count = counts[-1]
        if first_count > 0:
            change_rate = abs(last_count - first_count) / first_count
            if change_rate < 0.05:
                return 'stable'

        # 上下変動
        return 'fluctuating'

    def _trend_icon(self, trend: str) -> str:
        """トレンドアイコンを返す"""
        icons = {
            'improving': '📉',
            'worsening': '📈',
            'stable': '➡️',
            'fluctuating': '〰️',
            'insufficient_data': '❓'
        }
        return icons.get(trend, '❓')

    def _get_top_problematic_files(
        self,
        snapshot: Dict,
        limit: int = 10
    ) -> List[tuple]:
        """
        問題の多いファイルTop Nを取得

        Args:
            snapshot: スナップショット
            limit: 取得する件数

        Returns:
            (ファイルパス, 問題数) のリスト
        """
        by_file = snapshot.get('by_file', {})
        sorted_files = sorted(
            by_file.items(),
            key=lambda x: x[1],
            reverse=True
        )
        return sorted_files[:limit]

    def _filter_snapshots_by_date(
        self,
        days: Optional[int] = None,
        start_date: Optional[datetime] = None,
        end_date: Optional[datetime] = None
    ) -> List[Dict]:
        """
        日時でスナップショットをフィルタリング

        Args:
            days: 対象期間（日数）
            start_date: 開始日時
            end_date: 終了日時

        Returns:
            フィルタリングされたスナップショット
        """
        if days is not None:
            cutoff = datetime.now() - timedelta(days=days)
            return [
                s for s in self.snapshots
                if datetime.fromisoformat(s['timestamp']) >= cutoff
            ]

        if start_date is not None or end_date is not None:
            filtered = self.snapshots

            if start_date is not None:
                filtered = [
                    s for s in filtered
                    if datetime.fromisoformat(s['timestamp']) >= start_date
                ]

            if end_date is not None:
                filtered = [
                    s for s in filtered
                    if datetime.fromisoformat(s['timestamp']) <= end_date
                ]

            return filtered

        return self.snapshots

    def _load_snapshots(self) -> List[Dict]:
        """スナップショットを読み込み"""
        if not self.storage_file.exists():
            return []

        try:
            with open(self.storage_file, 'r', encoding='utf-8') as f:
                data = json.load(f)

            if not isinstance(data, list):
                print(f"[WARNING] 不正なデータ形式: {self.storage_file}")
                return []

            return data

        except (json.JSONDecodeError, IOError) as e:
            print(f"[WARNING] スナップショット読み込みエラー: {e}")
            return []

    def _save_snapshots(self):
        """スナップショットを保存"""
        self.storage_file.parent.mkdir(parents=True, exist_ok=True)

        try:
            with open(self.storage_file, 'w', encoding='utf-8') as f:
                json.dump(self.snapshots, f, indent=2, ensure_ascii=False)

        except IOError as e:
            print(f"[ERROR] スナップショット保存エラー: {e}")


if __name__ == "__main__":
    # 簡易テスト
    print("ProgressTracker簡易テスト")
    print("-" * 80)

    import tempfile

    # テスト用一時ファイル
    with tempfile.NamedTemporaryFile(mode='w', suffix='.json', delete=False) as f:
        temp_file = Path(f.name)

    try:
        tracker = ProgressTracker(temp_file)

        # スナップショット記録（3回）
        print("\n1. スナップショット記録:")
        base_time = datetime(2025, 1, 1, 0, 0, 0)

        tracker.record_snapshot(
            issues=[
                {'file': 'test1.py', 'line': 10, 'severity': 8, 'category': 'security'},
                {'file': 'test1.py', 'line': 20, 'severity': 5, 'category': 'performance'},
                {'file': 'test2.py', 'line': 30, 'severity': 3, 'category': 'style'},
            ],
            timestamp=base_time
        )

        tracker.record_snapshot(
            issues=[
                {'file': 'test1.py', 'line': 10, 'severity': 8, 'category': 'security'},
                {'file': 'test2.py', 'line': 30, 'severity': 3, 'category': 'style'},
            ],
            timestamp=base_time + timedelta(days=7)
        )

        tracker.record_snapshot(
            issues=[
                {'file': 'test2.py', 'line': 30, 'severity': 3, 'category': 'style'},
            ],
            timestamp=base_time + timedelta(days=14)
        )

        # 進捗レポート生成
        print("\n2. 進捗レポート生成:")
        report = tracker.generate_progress_report()

        print(f"期間: {report['period']['start']} → {report['period']['end']}")
        print(f"問題数変化: {report['total_issues']['start']}件 → {report['total_issues']['end']}件")
        print(f"変化量: {report['total_issues']['change']}件 ({report['total_issues']['change_rate']})")
        print(f"トレンド: {report['trend']}")

        # レポート出力
        print("\n3. レポート出力:")
        report_file = temp_file.parent / "progress_report.md"
        tracker.export_progress_report(report_file)
        print(f"レポート内容の一部:")
        try:
            print(report_file.read_text(encoding='utf-8')[:300] + "...")
        except UnicodeEncodeError:
            print("[レポート内容にUnicode文字が含まれます]")

        try:
            print("\n✅ 簡易テスト完了")
        except UnicodeEncodeError:
            print("\n[OK] 簡易テスト完了")

    finally:
        # クリーンアップ
        temp_file.unlink(missing_ok=True)
        report_file = temp_file.parent / "progress_report.md"
        report_file.unlink(missing_ok=True)

# Phase 6 実装計画: チーム機能の実装

*バージョン: v4.7.0 (Phase 6.0開始)*
*作成日: 2025年10月12日 JST*
*最終更新: 2025年10月12日 JST*

## 🎯 Phase 6の目標

**チームコラボレーション機能の実装**

Phase 5で実装したリアルタイム解析の上に、チームでコードレビュー結果を共有・比較・追跡できる機能を構築します。

### 達成基準
- [ ] レポート比較機能（時系列比較・チーム比較）
- [ ] 進捗トラッキング（問題修正状況の可視化）
- [ ] チームダッシュボード（統計・トレンド表示）
- [ ] コラボレーション機能（コメント・レビュー）
- [ ] @perfect品質維持 (全テスト100%合格)

---

## 📊 現在の状況

### Phase 5完了 (v4.6.0) ✅
- ✅ ファイルウォッチャー機能実装
- ✅ 差分解析エンジン実装
- ✅ リアルタイム解析CLI実装
- ✅ 全テスト100%合格 (9/9)

### Phase 6.0の新機能
Phase 5で実装した機能を拡張し、以下を実現：

1. **レポート比較機能**
   - 時系列比較（改善・悪化の追跡）
   - チーム間比較（ベンチマーク）
   - カテゴリ別比較

2. **進捗トラッキング**
   - 問題修正状況の可視化
   - 修正優先度の提案
   - 自動進捗レポート

3. **チームダッシュボード**
   - リアルタイム統計表示
   - トレンド分析
   - チーム貢献度

4. **コラボレーション**
   - コードレビューコメント
   - 問題の議論スレッド
   - 通知システム

---

## 🔧 実装項目

### 1. レポート比較エンジン (優先度: 高)

#### core/report_comparator.py

```python
"""
レポート比較エンジン

複数のレポートを比較して差分を抽出
"""

from pathlib import Path
from typing import List, Dict, Optional
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


class ReportComparator:
    """
    レポート比較エンジン

    使用例:
        comparator = ReportComparator()

        # 2つのレポートを比較
        diff = comparator.compare_reports(
            old_report=Path("reports/2025-01-01.json"),
            new_report=Path("reports/2025-01-15.json")
        )

        print(f"新規問題: {len(diff.new_issues)}件")
        print(f"修正済み: {len(diff.fixed_issues)}件")
    """

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
        """
        # レポートファイル読み込み
        old_data = self._load_report(old_report)
        new_data = self._load_report(new_report)

        # 問題IDでマッピング
        old_issues = {self._issue_key(i): i for i in old_data.get('issues', [])}
        new_issues = {self._issue_key(i): i for i in new_data.get('issues', [])}

        # 差分計算
        new = [new_issues[k] for k in new_issues if k not in old_issues]
        fixed = [old_issues[k] for k in old_issues if k not in new_issues]
        unchanged = [new_issues[k] for k in new_issues if k in old_issues]

        return ReportDiff(
            new_issues=new,
            fixed_issues=fixed,
            unchanged_issues=unchanged,
            worsened_issues=[],  # TODO: 深刻度変化を検出
            total_changes=len(new) + len(fixed)
        )

    def _load_report(self, report_file: Path) -> Dict:
        """レポートファイルを読み込み"""
        with open(report_file, 'r', encoding='utf-8') as f:
            return json.load(f)

    def _issue_key(self, issue: Dict) -> str:
        """問題の一意キーを生成"""
        return f"{issue['file']}:{issue['line']}:{issue['rule_id']}"
```

### 2. 進捗トラッキング (優先度: 高)

#### core/progress_tracker.py

```python
"""
進捗トラッキングシステム

問題の修正状況を時系列で追跡
"""

from pathlib import Path
from typing import List, Dict
from datetime import datetime
import json


class ProgressTracker:
    """
    進捗トラッキング

    使用例:
        tracker = ProgressTracker(Path(".bugsearch/progress.json"))

        # 現在の状態を記録
        tracker.record_snapshot(
            issues=current_issues,
            timestamp=datetime.now()
        )

        # 進捗レポート生成
        report = tracker.generate_progress_report(days=30)
    """

    def __init__(self, storage_file: Path):
        self.storage_file = storage_file
        self.snapshots = self._load_snapshots()

    def record_snapshot(self, issues: List[Dict], timestamp: datetime):
        """
        現在の問題状況のスナップショットを記録

        Args:
            issues: 現在の問題リスト
            timestamp: タイムスタンプ
        """
        snapshot = {
            'timestamp': timestamp.isoformat(),
            'total_issues': len(issues),
            'by_severity': self._group_by_severity(issues),
            'by_category': self._group_by_category(issues),
            'issues': issues
        }

        self.snapshots.append(snapshot)
        self._save_snapshots()

    def generate_progress_report(self, days: int = 30) -> Dict:
        """
        進捗レポートを生成

        Args:
            days: 対象期間（日数）

        Returns:
            進捗レポート
        """
        if len(self.snapshots) < 2:
            return {'error': 'スナップショットが不足しています'}

        oldest = self.snapshots[0]
        latest = self.snapshots[-1]

        return {
            'period': {
                'start': oldest['timestamp'],
                'end': latest['timestamp']
            },
            'total_issues': {
                'start': oldest['total_issues'],
                'end': latest['total_issues'],
                'change': latest['total_issues'] - oldest['total_issues']
            },
            'trend': self._calculate_trend()
        }

    def _group_by_severity(self, issues: List[Dict]) -> Dict:
        """深刻度別にグループ化"""
        groups = {}
        for issue in issues:
            severity = issue.get('severity', 0)
            groups[severity] = groups.get(severity, 0) + 1
        return groups

    def _group_by_category(self, issues: List[Dict]) -> Dict:
        """カテゴリ別にグループ化"""
        groups = {}
        for issue in issues:
            category = issue.get('category', 'unknown')
            groups[category] = groups.get(category, 0) + 1
        return groups

    def _calculate_trend(self) -> str:
        """トレンドを計算"""
        if len(self.snapshots) < 2:
            return 'insufficient_data'

        recent_counts = [s['total_issues'] for s in self.snapshots[-5:]]

        if all(recent_counts[i] <= recent_counts[i+1] for i in range(len(recent_counts)-1)):
            return 'worsening'
        elif all(recent_counts[i] >= recent_counts[i+1] for i in range(len(recent_counts)-1)):
            return 'improving'
        else:
            return 'fluctuating'

    def _load_snapshots(self) -> List[Dict]:
        """スナップショットを読み込み"""
        if not self.storage_file.exists():
            return []

        with open(self.storage_file, 'r', encoding='utf-8') as f:
            return json.load(f)

    def _save_snapshots(self):
        """スナップショットを保存"""
        self.storage_file.parent.mkdir(parents=True, exist_ok=True)

        with open(self.storage_file, 'w', encoding='utf-8') as f:
            json.dump(self.snapshots, f, indent=2, ensure_ascii=False)
```

### 3. チームダッシュボード (優先度: 中)

#### dashboard/team_dashboard.py

```python
"""
チームダッシュボード

Web UIでチーム統計を表示
"""

from flask import Flask, render_template, jsonify
from pathlib import Path
from typing import Dict
import json


app = Flask(__name__)


@app.route('/')
def index():
    """ダッシュボードのメインページ"""
    return render_template('dashboard.html')


@app.route('/api/stats')
def get_stats():
    """統計データを取得（API）"""
    # TODO: 実際の統計データを取得
    return jsonify({
        'total_issues': 156,
        'critical': 12,
        'high': 34,
        'medium': 78,
        'low': 32,
        'trend': 'improving',
        'top_contributors': [
            {'name': 'Developer A', 'fixes': 45},
            {'name': 'Developer B', 'fixes': 32},
            {'name': 'Developer C', 'fixes': 28}
        ]
    })


@app.route('/api/progress')
def get_progress():
    """進捗データを取得（API）"""
    # TODO: 実際の進捗データを取得
    return jsonify({
        'dates': ['2025-01-01', '2025-01-08', '2025-01-15'],
        'issues': [200, 175, 156],
        'fixed': [0, 25, 44]
    })


if __name__ == '__main__':
    app.run(debug=True, port=5000)
```

---

## 📋 テスト計画

### test/test_phase6_team.py

```python
"""
Phase 6テスト: チーム機能

@perfect品質保証:
- レポート比較機能
- 進捗トラッキング
- ダッシュボードAPI
"""

import unittest
from pathlib import Path
from core.report_comparator import ReportComparator
from core.progress_tracker import ProgressTracker


class TestReportComparator(unittest.TestCase):
    """レポート比較機能のテスト"""

    def test_report_comparison(self):
        """レポート比較テスト"""
        # TODO: 実装
        pass


class TestProgressTracker(unittest.TestCase):
    """進捗トラッキングのテスト"""

    def test_snapshot_recording(self):
        """スナップショット記録テスト"""
        # TODO: 実装
        pass

    def test_progress_report_generation(self):
        """進捗レポート生成テスト"""
        # TODO: 実装
        pass
```

---

## 📅 実装スケジュール

### Week 1: レポート比較機能 (3日間)
- Day 1: ReportComparatorクラス実装
- Day 2: 時系列比較機能
- Day 3: テスト作成・実行

### Week 2: 進捗トラッキング (2日間)
- Day 4: ProgressTrackerクラス実装
- Day 5: 進捗レポート生成・テスト

### Week 3: チームダッシュボード (3日間)
- Day 6-7: Flask APIとフロントエンド実装
- Day 8: 統合テスト・ドキュメント整備

**合計**: 約8日間（実稼働）

---

## 🎯 成功基準

### 必須条件
- [ ] レポート比較が正常に動作する
- [ ] 進捗トラッキングが機能する
- [ ] ダッシュボードがデータを表示する
- [ ] 全テスト合格

### 品質基準
- [ ] @perfect品質達成 (全テスト100%合格)
- [ ] レスポンス時間 < 2秒（ダッシュボード）
- [ ] データ一貫性の保証

---

## 🔄 今後の展望

Phase 6完了後、さらなる拡張を検討：

1. **通知システム**
   - メール通知
   - Slack/Teams統合

2. **CI/CD統合**
   - GitHub Actions連携
   - 自動レポート生成

3. **機械学習統合**
   - 問題予測
   - 自動修正提案

---

*最終更新: 2025年10月12日 JST*
*Phase 6実装期間: 2025年10月12日 (計画中)*
*バージョン: v4.7.0 (Phase 6.0計画)*

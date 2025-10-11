"""
ルールメトリクス収集

Phase 4.2の新機能:
- ルールごとの検出統計
- 誤検知率の追跡
- パフォーマンス分析
- メトリクスの永続化

バージョン: v4.5.0 (Phase 4.2)
作成日: 2025年10月12日 JST

@perfect品質:
- スレッドセーフな実装
- 効率的なデータ構造
- 詳細なレポート生成
"""

from pathlib import Path
from typing import Dict, List, Optional, Set
from datetime import datetime
from dataclasses import dataclass, asdict, field
import json
import threading


@dataclass
class RuleMetric:
    """
    ルールメトリクス

    検出統計とパフォーマンス情報を保持
    """
    rule_id: str
    total_detections: int = 0
    unique_files: Set[str] = field(default_factory=set)
    false_positives: int = 0
    execution_time_ms: float = 0.0
    execution_count: int = 0
    last_execution: str = ""

    def to_dict(self) -> Dict:
        """辞書形式に変換（JSON化のため）"""
        return {
            'rule_id': self.rule_id,
            'total_detections': self.total_detections,
            'unique_files': list(self.unique_files),
            'unique_file_count': len(self.unique_files),
            'false_positives': self.false_positives,
            'execution_time_ms': self.execution_time_ms,
            'execution_count': self.execution_count,
            'average_execution_time_ms': (
                self.execution_time_ms / self.execution_count
                if self.execution_count > 0 else 0.0
            ),
            'last_execution': self.last_execution
        }

    @classmethod
    def from_dict(cls, data: Dict) -> 'RuleMetric':
        """辞書から復元"""
        return cls(
            rule_id=data['rule_id'],
            total_detections=data.get('total_detections', 0),
            unique_files=set(data.get('unique_files', [])),
            false_positives=data.get('false_positives', 0),
            execution_time_ms=data.get('execution_time_ms', 0.0),
            execution_count=data.get('execution_count', 0),
            last_execution=data.get('last_execution', '')
        )


class RuleMetricsCollector:
    """
    ルールメトリクス収集

    Phase 4.2の新機能:
    - スレッドセーフなメトリクス収集
    - 永続化機能
    - リアルタイム統計
    """

    def __init__(self, metrics_file: Path = Path(".bugsearch/metrics.json")):
        """
        初期化

        Args:
            metrics_file: メトリクスファイルのパス
        """
        self.metrics_file = metrics_file
        self.metrics: Dict[str, RuleMetric] = {}
        self._lock = threading.Lock()
        self._auto_save = True
        self._load_metrics()

    def _load_metrics(self):
        """既存のメトリクスを読み込み"""
        if not self.metrics_file.exists():
            return

        try:
            with open(self.metrics_file, 'r', encoding='utf-8') as f:
                data = json.load(f)

            for rule_id, metric_data in data.items():
                self.metrics[rule_id] = RuleMetric.from_dict(metric_data)

            print(f"[OK] メトリクス読み込み完了: {len(self.metrics)}個のルール")

        except Exception as e:
            print(f"[WARNING] メトリクス読み込みエラー: {e}")

    def _save_metrics(self):
        """メトリクスを保存"""
        try:
            self.metrics_file.parent.mkdir(parents=True, exist_ok=True)

            data = {rule_id: metric.to_dict() for rule_id, metric in self.metrics.items()}

            with open(self.metrics_file, 'w', encoding='utf-8') as f:
                json.dump(data, f, indent=2, ensure_ascii=False)

        except Exception as e:
            print(f"[ERROR] メトリクス保存失敗: {e}")

    def record_detection(
        self,
        rule_id: str,
        file_path: str,
        execution_time_ms: float = 0.0
    ):
        """
        検出を記録

        Args:
            rule_id: ルールID
            file_path: ファイルパス
            execution_time_ms: 実行時間（ミリ秒）
        """
        with self._lock:
            if rule_id not in self.metrics:
                self.metrics[rule_id] = RuleMetric(rule_id=rule_id)

            metric = self.metrics[rule_id]
            metric.total_detections += 1
            metric.unique_files.add(file_path)
            metric.execution_time_ms += execution_time_ms
            metric.execution_count += 1
            metric.last_execution = datetime.now().isoformat()

            if self._auto_save:
                self._save_metrics()

    def record_false_positive(self, rule_id: str):
        """
        誤検知を記録

        Args:
            rule_id: ルールID
        """
        with self._lock:
            if rule_id in self.metrics:
                self.metrics[rule_id].false_positives += 1

                if self._auto_save:
                    self._save_metrics()
            else:
                print(f"[WARNING] ルール '{rule_id}' のメトリクスが存在しません")

    def get_metrics(self, rule_id: str) -> Optional[RuleMetric]:
        """
        特定ルールのメトリクスを取得

        Args:
            rule_id: ルールID

        Returns:
            ルールメトリクス（存在しない場合はNone）
        """
        return self.metrics.get(rule_id)

    def get_all_metrics(self) -> List[RuleMetric]:
        """
        全ルールのメトリクスを取得

        Returns:
            ルールメトリクスのリスト
        """
        return list(self.metrics.values())

    def get_false_positive_rate(self, rule_id: str) -> float:
        """
        誤検知率を計算

        Args:
            rule_id: ルールID

        Returns:
            誤検知率（0.0-1.0）
        """
        metric = self.metrics.get(rule_id)
        if not metric or metric.total_detections == 0:
            return 0.0

        return metric.false_positives / metric.total_detections

    def get_average_execution_time(self, rule_id: str) -> float:
        """
        平均実行時間を取得

        Args:
            rule_id: ルールID

        Returns:
            平均実行時間（ミリ秒）
        """
        metric = self.metrics.get(rule_id)
        if not metric or metric.execution_count == 0:
            return 0.0

        return metric.execution_time_ms / metric.execution_count

    def get_top_rules_by_detections(self, limit: int = 10) -> List[RuleMetric]:
        """
        検出数が多いルールを取得

        Args:
            limit: 取得数

        Returns:
            ルールメトリクスのリスト（検出数降順）
        """
        return sorted(
            self.metrics.values(),
            key=lambda m: m.total_detections,
            reverse=True
        )[:limit]

    def get_top_rules_by_false_positives(self, limit: int = 10) -> List[RuleMetric]:
        """
        誤検知率が高いルールを取得

        Args:
            limit: 取得数

        Returns:
            ルールメトリクスのリスト（誤検知率降順）
        """
        rules_with_fp = [
            m for m in self.metrics.values()
            if m.total_detections > 0
        ]

        return sorted(
            rules_with_fp,
            key=lambda m: m.false_positives / m.total_detections,
            reverse=True
        )[:limit]

    def get_slowest_rules(self, limit: int = 10) -> List[RuleMetric]:
        """
        実行が遅いルールを取得

        Args:
            limit: 取得数

        Returns:
            ルールメトリクスのリスト（平均実行時間降順）
        """
        rules_with_execution = [
            m for m in self.metrics.values()
            if m.execution_count > 0
        ]

        return sorted(
            rules_with_execution,
            key=lambda m: m.execution_time_ms / m.execution_count,
            reverse=True
        )[:limit]

    def reset_metrics(self, rule_id: Optional[str] = None):
        """
        メトリクスをリセット

        Args:
            rule_id: ルールID（Noneの場合は全ルール）
        """
        with self._lock:
            if rule_id:
                if rule_id in self.metrics:
                    del self.metrics[rule_id]
                    print(f"[OK] ルール '{rule_id}' のメトリクスをリセットしました")
                else:
                    print(f"[WARNING] ルール '{rule_id}' のメトリクスが存在しません")
            else:
                self.metrics.clear()
                print("[OK] 全ルールのメトリクスをリセットしました")

            self._save_metrics()

    def generate_report(self, detailed: bool = True) -> str:
        """
        メトリクスレポートを生成

        Args:
            detailed: 詳細レポートを生成するか

        Returns:
            レポート文字列
        """
        lines = [
            "=" * 80,
            "📊 ルールメトリクスレポート",
            "=" * 80,
            "",
            f"レポート生成日時: {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}",
            f"追跡中のルール数: {len(self.metrics)}個",
            ""
        ]

        if not self.metrics:
            lines.append("[INFO] メトリクスデータがありません")
            return "\n".join(lines)

        # サマリー統計
        total_detections = sum(m.total_detections for m in self.metrics.values())
        total_files = len(set().union(*(m.unique_files for m in self.metrics.values())))
        total_fps = sum(m.false_positives for m in self.metrics.values())

        lines.extend([
            "📈 サマリー統計:",
            f"  総検出数: {total_detections}件",
            f"  対象ファイル数: {total_files}件",
            f"  総誤検知数: {total_fps}件",
            ""
        ])

        # Top 5 検出数
        top_detections = self.get_top_rules_by_detections(limit=5)
        if top_detections:
            lines.extend([
                "🔝 Top 5 検出数が多いルール:",
                ""
            ])
            for i, metric in enumerate(top_detections, 1):
                lines.append(f"  {i}. {metric.rule_id}: {metric.total_detections}件")
            lines.append("")

        # Top 5 誤検知率
        top_fp_rules = self.get_top_rules_by_false_positives(limit=5)
        if top_fp_rules:
            lines.extend([
                "⚠️  Top 5 誤検知率が高いルール:",
                ""
            ])
            for i, metric in enumerate(top_fp_rules, 1):
                fp_rate = self.get_false_positive_rate(metric.rule_id)
                lines.append(
                    f"  {i}. {metric.rule_id}: {fp_rate * 100:.1f}% "
                    f"({metric.false_positives}/{metric.total_detections})"
                )
            lines.append("")

        # Top 5 実行時間
        slowest_rules = self.get_slowest_rules(limit=5)
        if slowest_rules:
            lines.extend([
                "🐌 Top 5 実行が遅いルール:",
                ""
            ])
            for i, metric in enumerate(slowest_rules, 1):
                avg_time = self.get_average_execution_time(metric.rule_id)
                lines.append(f"  {i}. {metric.rule_id}: {avg_time:.2f}ms")
            lines.append("")

        # 詳細レポート
        if detailed:
            lines.extend([
                "-" * 80,
                "📋 詳細レポート:",
                "-" * 80,
                ""
            ])

            for rule_id, metric in sorted(self.metrics.items()):
                fp_rate = self.get_false_positive_rate(rule_id)
                avg_time = self.get_average_execution_time(rule_id)

                lines.append(f"■ {rule_id}")
                lines.append(f"  検出数: {metric.total_detections}件")
                lines.append(f"  対象ファイル数: {len(metric.unique_files)}件")
                lines.append(f"  誤検知: {metric.false_positives}件 ({fp_rate * 100:.1f}%)")
                lines.append(f"  実行回数: {metric.execution_count}回")
                lines.append(f"  平均実行時間: {avg_time:.2f}ms")
                lines.append(f"  最終実行: {metric.last_execution}")
                lines.append("")

        lines.append("=" * 80)

        return "\n".join(lines)

    def export_to_json(self, output_file: Path):
        """
        メトリクスをJSON形式でエクスポート

        Args:
            output_file: 出力ファイルパス
        """
        try:
            data = {
                'metadata': {
                    'exported_at': datetime.now().isoformat(),
                    'total_rules': len(self.metrics)
                },
                'metrics': {rule_id: metric.to_dict() for rule_id, metric in self.metrics.items()}
            }

            output_file.parent.mkdir(parents=True, exist_ok=True)

            with open(output_file, 'w', encoding='utf-8') as f:
                json.dump(data, f, indent=2, ensure_ascii=False)

            print(f"[OK] メトリクスエクスポート完了: {output_file}")

        except Exception as e:
            print(f"[ERROR] エクスポート失敗: {e}")

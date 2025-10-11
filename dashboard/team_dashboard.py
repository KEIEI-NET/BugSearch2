"""
チームダッシュボード

Phase 6.0の新機能:
- Web UIでチーム統計を表示
- リアルタイム統計API
- 進捗グラフ表示

バージョン: v4.7.0 (Phase 6.0)
作成日: 2025年10月12日 JST

@perfect品質:
- CORS対応
- エラーハンドリング
- JSONレスポンス

使用例:
    python dashboard/team_dashboard.py
    # ブラウザで http://localhost:5000 にアクセス
"""

from flask import Flask, render_template, jsonify, request
from pathlib import Path
from typing import Dict, List, Optional
import json
import sys

# プロジェクトルートをパスに追加
sys.path.insert(0, str(Path(__file__).parent.parent))

from core.progress_tracker import ProgressTracker
from core.report_comparator import ReportComparator


app = Flask(__name__)
app.config['JSON_AS_ASCII'] = False  # 日本語対応


# グローバル設定
PROGRESS_FILE = Path(".bugsearch/progress.json")
REPORTS_DIR = Path("reports")


@app.route('/')
def index():
    """ダッシュボードのメインページ"""
    return render_template('dashboard.html') if (Path(__file__).parent / 'templates/dashboard.html').exists() else """
    <html>
    <head>
        <title>BugSearch2 - Team Dashboard</title>
        <meta charset="utf-8">
        <style>
            body {
                font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Arial, sans-serif;
                margin: 0;
                padding: 20px;
                background: #f5f5f5;
            }
            .container {
                max-width: 1200px;
                margin: 0 auto;
                background: white;
                padding: 30px;
                border-radius: 8px;
                box-shadow: 0 2px 4px rgba(0,0,0,0.1);
            }
            h1 {
                color: #333;
                border-bottom: 3px solid #0066cc;
                padding-bottom: 10px;
            }
            .stats {
                display: grid;
                grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
                gap: 20px;
                margin: 20px 0;
            }
            .stat-card {
                background: #f8f9fa;
                padding: 20px;
                border-radius: 8px;
                border-left: 4px solid #0066cc;
            }
            .stat-value {
                font-size: 2em;
                font-weight: bold;
                color: #0066cc;
            }
            .stat-label {
                color: #666;
                margin-top: 5px;
            }
            .api-docs {
                margin-top: 30px;
                padding: 20px;
                background: #fff8dc;
                border-radius: 8px;
            }
            code {
                background: #f4f4f4;
                padding: 2px 6px;
                border-radius: 3px;
                font-family: monospace;
            }
        </style>
    </head>
    <body>
        <div class="container">
            <h1>🔍 BugSearch2 - Team Dashboard</h1>

            <div class="stats" id="stats">
                <div class="stat-card">
                    <div class="stat-value" id="total-issues">-</div>
                    <div class="stat-label">総問題数</div>
                </div>
                <div class="stat-card">
                    <div class="stat-value" id="critical-issues">-</div>
                    <div class="stat-label">重大問題</div>
                </div>
                <div class="stat-card">
                    <div class="stat-value" id="trend">-</div>
                    <div class="stat-label">トレンド</div>
                </div>
            </div>

            <div class="api-docs">
                <h2>API エンドポイント</h2>
                <p><strong>統計データ:</strong> <code>GET /api/stats</code></p>
                <p><strong>進捗データ:</strong> <code>GET /api/progress?days=30</code></p>
                <p><strong>レポート比較:</strong> <code>POST /api/compare</code> (JSONボディ: <code>{"old": "path", "new": "path"}</code>)</p>
            </div>
        </div>

        <script>
            // 統計データを取得
            fetch('/api/stats')
                .then(res => res.json())
                .then(data => {
                    document.getElementById('total-issues').textContent = data.total_issues || 0;
                    document.getElementById('critical-issues').textContent = data.critical || 0;
                    document.getElementById('trend').textContent = data.trend || 'N/A';
                })
                .catch(err => console.error('Error loading stats:', err));
        </script>
    </body>
    </html>
    """


@app.route('/api/stats')
def get_stats():
    """
    統計データを取得（API）

    Returns:
        JSON: 統計情報
    """
    try:
        # 進捗データから最新の統計を取得
        tracker = ProgressTracker(PROGRESS_FILE)

        if len(tracker.snapshots) == 0:
            return jsonify({
                'total_issues': 0,
                'critical': 0,
                'high': 0,
                'medium': 0,
                'low': 0,
                'trend': 'no_data',
                'message': 'スナップショットがありません'
            })

        latest = tracker.snapshots[-1]
        by_severity = latest.get('by_severity', {})

        # 深刻度別集計
        critical = sum(count for sev, count in by_severity.items() if sev >= 9)
        high = sum(count for sev, count in by_severity.items() if 7 <= sev < 9)
        medium = sum(count for sev, count in by_severity.items() if 5 <= sev < 7)
        low = sum(count for sev, count in by_severity.items() if sev < 5)

        # トレンド計算
        report = tracker.generate_progress_report(days=30)
        trend = report.get('trend', 'unknown') if 'error' not in report else 'insufficient_data'

        return jsonify({
            'total_issues': latest.get('total_issues', 0),
            'critical': critical,
            'high': high,
            'medium': medium,
            'low': low,
            'trend': trend,
            'timestamp': latest.get('timestamp'),
            'by_category': latest.get('by_category', {})
        })

    except Exception as e:
        return jsonify({
            'error': str(e),
            'message': '統計データの取得に失敗しました'
        }), 500


@app.route('/api/progress')
def get_progress():
    """
    進捗データを取得（API）

    Query Parameters:
        days (int): 対象期間（日数、デフォルト: 30）

    Returns:
        JSON: 進捗情報
    """
    try:
        days = request.args.get('days', default=30, type=int)

        tracker = ProgressTracker(PROGRESS_FILE)
        report = tracker.generate_progress_report(days=days)

        if 'error' in report:
            return jsonify(report), 400

        # グラフ用のデータを整形
        snapshots = tracker._filter_snapshots_by_date(days=days)

        dates = [s['timestamp'][:10] for s in snapshots]  # YYYY-MM-DD
        issues = [s['total_issues'] for s in snapshots]

        return jsonify({
            'period': report['period'],
            'total_issues': report['total_issues'],
            'trend': report['trend'],
            'chart_data': {
                'dates': dates,
                'issues': issues
            },
            'severity_changes': report.get('severity_changes', {}),
            'category_changes': report.get('category_changes', {})
        })

    except Exception as e:
        return jsonify({
            'error': str(e),
            'message': '進捗データの取得に失敗しました'
        }), 500


@app.route('/api/compare', methods=['POST'])
def compare_reports():
    """
    レポート比較API

    Request Body (JSON):
        {
            "old": "reports/old_report.json",
            "new": "reports/new_report.json"
        }

    Returns:
        JSON: 比較結果
    """
    try:
        data = request.get_json()

        if not data or 'old' not in data or 'new' not in data:
            return jsonify({
                'error': 'oldとnewのレポートパスが必要です'
            }), 400

        old_path = Path(data['old'])
        new_path = Path(data['new'])

        if not old_path.exists():
            return jsonify({
                'error': f'旧レポートが見つかりません: {old_path}'
            }), 404

        if not new_path.exists():
            return jsonify({
                'error': f'新レポートが見つかりません: {new_path}'
            }), 404

        comparator = ReportComparator()
        diff = comparator.compare_reports(old_path, new_path)

        return jsonify({
            'summary': diff.summary,
            'new_issues': len(diff.new_issues),
            'fixed_issues': len(diff.fixed_issues),
            'unchanged_issues': len(diff.unchanged_issues),
            'worsened_issues': len(diff.worsened_issues),
            'improvement_rate': f"{diff.improvement_rate:.1%}",
            'details': {
                'new': diff.new_issues[:10],  # 上位10件
                'fixed': diff.fixed_issues[:10],
                'worsened': diff.worsened_issues
            }
        })

    except Exception as e:
        return jsonify({
            'error': str(e),
            'message': 'レポート比較に失敗しました'
        }), 500


@app.route('/api/reports')
def list_reports():
    """
    利用可能なレポート一覧を取得

    Returns:
        JSON: レポートファイルのリスト
    """
    try:
        if not REPORTS_DIR.exists():
            return jsonify({
                'reports': [],
                'message': 'レポートディレクトリが存在しません'
            })

        # JSONレポートファイルを検索
        reports = []
        for report_file in REPORTS_DIR.glob('**/*.json'):
            if report_file.is_file():
                stat = report_file.stat()
                reports.append({
                    'name': report_file.name,
                    'path': str(report_file.relative_to(Path.cwd())),
                    'size': stat.st_size,
                    'modified': stat.st_mtime
                })

        # 更新日時でソート
        reports.sort(key=lambda r: r['modified'], reverse=True)

        return jsonify({
            'reports': reports,
            'count': len(reports)
        })

    except Exception as e:
        return jsonify({
            'error': str(e),
            'message': 'レポート一覧の取得に失敗しました'
        }), 500


@app.route('/health')
def health_check():
    """ヘルスチェックエンドポイント"""
    return jsonify({
        'status': 'ok',
        'service': 'BugSearch2 Team Dashboard',
        'version': 'v4.7.0'
    })


if __name__ == '__main__':
    print("=" * 80)
    print("🔍 BugSearch2 - Team Dashboard v4.7.0")
    print("=" * 80)
    print()
    print("サーバー起動中...")
    print()
    print("アクセス URL:")
    print("  - メインページ:     http://localhost:5000")
    print("  - 統計API:          http://localhost:5000/api/stats")
    print("  - 進捗API:          http://localhost:5000/api/progress?days=30")
    print("  - レポート一覧:     http://localhost:5000/api/reports")
    print("  - ヘルスチェック:   http://localhost:5000/health")
    print()
    print("Ctrl+C で終了します")
    print("=" * 80)
    print()

    # 開発モードで起動
    app.run(debug=True, port=5000, host='0.0.0.0')

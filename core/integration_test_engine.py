#!/usr/bin/env python
# -*- coding: utf-8 -*-
"""
統合テストエンジン - フル実行一貫性テスト

BugSearch2の全工程を自動実行・検証します：
1. テストプロジェクトセットアップ
2. Context7統合分析（YAML生成、複数トピック対応）
3. インデックス作成
4. AI分析実行
5. 改善コード適用
6. 結果検証・レポート生成

Version: v1.0.0
Author: BugSearch2 Team
"""

import os
import sys
import time
import json
import subprocess
import shutil
from pathlib import Path
from typing import Dict, List, Optional, Tuple, Any
from datetime import datetime
from dataclasses import dataclass, asdict


@dataclass
class IntegrationTestConfig:
    """統合テスト設定"""
    project_type: str  # react, angular, express, django等
    topics: List[str]  # 分析トピック（複数可）
    include_examples: bool = True
    test_dir: Path = Path("test_integration")
    timeout_seconds: int = 1800  # 30分
    max_file_mb: int = 4  # 最大ファイルサイズ (MB)
    worker_count: int = 4  # ワーカー数


@dataclass
class StepResult:
    """各ステップの実行結果"""
    step_name: str
    success: bool
    duration_seconds: float
    output: str = ""
    error: str = ""
    metrics: Dict[str, Any] = None

    def __post_init__(self):
        if self.metrics is None:
            self.metrics = {}


@dataclass
class IntegrationTestResult:
    """統合テスト全体の結果"""
    config: IntegrationTestConfig
    start_time: str
    end_time: str
    total_duration_seconds: float
    overall_success: bool
    steps: List[StepResult]
    summary: Dict[str, Any]


class IntegrationTestEngine:
    """統合テストエンジン"""

    # テストプロジェクトテンプレート（意図的なバグ含む）
    SAMPLE_CODE_TEMPLATES = {
        "react": {
            "src/App.tsx": """
import React, { useState, useEffect } from 'react';

// 意図的な問題コード（テスト用）
function App() {
  const [data, setData] = useState<any[]>([]); // any使用（型安全性問題）

  useEffect(() => {
    // メモリリーク: cleanupなし
    const interval = setInterval(() => {
      console.log('Polling...');
    }, 1000);
  }, []);

  // XSS脆弱性
  const renderHTML = (html: string) => {
    return <div dangerouslySetInnerHTML={{ __html: html }} />;
  };

  // パフォーマンス問題: useCallbackなし
  const handleClick = () => {
    console.log('Clicked');
  };

  return (
    <div>
      <h1>Test App</h1>
      <button onClick={handleClick}>Click Me</button>
      {data.map((item, index) => (
        <div key={index}>{item.name}</div>
      ))}
    </div>
  );
}

export default App;
""",
            "src/api.ts": """
// セキュリティ問題: エラーハンドリング不足
export async function fetchData(url: string) {
  const response = await fetch(url);
  return response.json(); // エラーチェックなし
}

// パフォーマンス問題: キャッシュなし
export async function loadUserData(userId: string) {
  const data = await fetchData(`/api/users/${userId}`);
  return data;
}
""",
            "package.json": """{
  "name": "test-react-app",
  "version": "1.0.0",
  "dependencies": {
    "react": "^18.0.0",
    "react-dom": "^18.0.0"
  },
  "devDependencies": {
    "typescript": "^4.9.0"
  }
}
"""
        },
        "angular": {
            "src/app/app.component.ts": """
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

// 意図的な問題コード（テスト用）
@Component({
  selector: 'app-root',
  template: '<div [innerHTML]="content"></div>' // XSS脆弱性
})
export class AppComponent implements OnInit {
  content: any; // any使用

  constructor(private http: HttpClient) {}

  ngOnInit() {
    // Subscriptionリーク: unsubscribeなし
    this.http.get('/api/data').subscribe(data => {
      this.content = data;
    });

    // メモリリーク: setInterval cleanupなし
    setInterval(() => {
      console.log('Polling...');
    }, 1000);
  }

  // パフォーマンス問題: ChangeDetectionStrategy未指定
  loadData() {
    this.http.get('/api/data').subscribe();
  }
}
""",
            "package.json": """{
  "name": "test-angular-app",
  "version": "1.0.0",
  "dependencies": {
    "@angular/core": "^15.0.0",
    "@angular/common": "^15.0.0"
  }
}
"""
        }
    }

    def __init__(self, config: IntegrationTestConfig):
        """
        統合テストエンジンの初期化

        Args:
            config: テスト設定
        """
        self.config = config
        self.test_dir = config.test_dir.resolve()
        self.steps: List[StepResult] = []
        self.start_time = None
        self.end_time = None

    def run(self) -> IntegrationTestResult:
        """
        統合テスト全体を実行

        Returns:
            IntegrationTestResult: テスト結果
        """
        self.start_time = datetime.now()
        print("=" * 80)
        print("🚀 BugSearch2 統合テスト開始")
        print("=" * 80)
        print(f"プロジェクトタイプ: {self.config.project_type}")
        print(f"分析トピック: {', '.join(self.config.topics)}")
        print(f"テストディレクトリ: {self.test_dir}")
        print()

        overall_success = True

        try:
            # ステップ1: テストプロジェクトセットアップ
            result = self._run_step("テストプロジェクトセットアップ", self._setup_test_project)
            self.steps.append(result)
            if not result.success:
                overall_success = False
                raise Exception(f"ステップ失敗: {result.step_name}")

            # ステップ2: Context7統合分析（YAML生成）
            result = self._run_step("Context7統合分析", self._run_context7_analysis)
            self.steps.append(result)
            if not result.success:
                overall_success = False
                raise Exception(f"ステップ失敗: {result.step_name}")

            # ステップ3: インデックス作成
            result = self._run_step("インデックス作成", self._run_index_creation)
            self.steps.append(result)
            if not result.success:
                overall_success = False
                raise Exception(f"ステップ失敗: {result.step_name}")

            # ステップ4: AI分析実行
            result = self._run_step("AI分析実行", self._run_ai_analysis)
            self.steps.append(result)
            if not result.success:
                overall_success = False
                raise Exception(f"ステップ失敗: {result.step_name}")

            # ステップ5: 改善コード適用
            result = self._run_step("改善コード適用", self._run_code_improvement)
            self.steps.append(result)
            if not result.success:
                print(f"⚠️  警告: {result.step_name}でエラーが発生しましたが、テストは継続します")

            # ステップ6: 結果検証
            result = self._run_step("結果検証", self._verify_results)
            self.steps.append(result)
            if not result.success:
                overall_success = False

        except Exception as e:
            print(f"\n❌ テスト実行エラー: {e}")
            overall_success = False

        self.end_time = datetime.now()
        total_duration = (self.end_time - self.start_time).total_seconds()

        # サマリー生成
        summary = self._generate_summary()

        result = IntegrationTestResult(
            config=self.config,
            start_time=self.start_time.isoformat(),
            end_time=self.end_time.isoformat(),
            total_duration_seconds=total_duration,
            overall_success=overall_success,
            steps=self.steps,
            summary=summary
        )

        # レポート出力
        self._print_report(result)
        self._save_report(result)

        return result

    def _run_step(self, step_name: str, func) -> StepResult:
        """
        個別ステップの実行

        Args:
            step_name: ステップ名
            func: 実行する関数

        Returns:
            StepResult: ステップ結果
        """
        print(f"\n{'='*80}")
        print(f"📋 ステップ: {step_name}")
        print(f"{'='*80}")

        start = time.time()
        try:
            output, metrics = func()
            duration = time.time() - start

            result = StepResult(
                step_name=step_name,
                success=True,
                duration_seconds=duration,
                output=output,
                metrics=metrics
            )

            print(f"✅ {step_name} 完了 ({duration:.2f}秒)")
            return result

        except Exception as e:
            duration = time.time() - start
            error_msg = str(e)

            result = StepResult(
                step_name=step_name,
                success=False,
                duration_seconds=duration,
                error=error_msg
            )

            print(f"❌ {step_name} 失敗 ({duration:.2f}秒)")
            print(f"   エラー: {error_msg}")
            return result

    def _setup_test_project(self) -> Tuple[str, Dict]:
        """テストプロジェクトのセットアップ"""
        # 既存のテストディレクトリをクリーンアップ
        if self.test_dir.exists():
            shutil.rmtree(self.test_dir)

        self.test_dir.mkdir(parents=True)

        # プロジェクトタイプに応じたサンプルコード生成
        if self.config.project_type not in self.SAMPLE_CODE_TEMPLATES:
            raise ValueError(f"未対応のプロジェクトタイプ: {self.config.project_type}")

        templates = self.SAMPLE_CODE_TEMPLATES[self.config.project_type]
        files_created = []

        for file_path, content in templates.items():
            full_path = self.test_dir / file_path
            full_path.parent.mkdir(parents=True, exist_ok=True)
            full_path.write_text(content, encoding='utf-8')
            files_created.append(str(file_path))

        # .bugsearch.yml生成
        bugsearch_config = f"""
tech_stack:
  frontend:
    - {self.config.project_type}
  language:
    - typescript
    - javascript

analysis:
  topics: {self.config.topics}
  include_examples: {self.config.include_examples}
"""
        (self.test_dir / ".bugsearch.yml").write_text(bugsearch_config, encoding='utf-8')
        files_created.append(".bugsearch.yml")

        output = f"テストプロジェクト作成完了\n作成ファイル: {len(files_created)}個"
        metrics = {
            "files_created": len(files_created),
            "project_type": self.config.project_type
        }

        return output, metrics

    def _run_context7_analysis(self) -> Tuple[str, Dict]:
        """Context7統合分析実行"""
        # generate_tech_config.pyを実行
        cmd = [
            sys.executable,
            "generate_tech_config.py",
            "--tech", self.config.project_type,
            "--no-examples" if not self.config.include_examples else ""
        ]

        # 複数トピック対応（Phase 3）
        for topic in self.config.topics:
            cmd.extend(["--topic", topic])

        # 空文字列を除去
        cmd = [c for c in cmd if c]

        result = subprocess.run(
            cmd,
            capture_output=True,
            text=True,
            timeout=300,
            cwd=Path.cwd()
        )

        if result.returncode != 0:
            raise Exception(f"Context7分析失敗: {result.stderr}")

        # 生成されたYAMLファイルを確認
        yaml_file = Path(f"config/{self.config.project_type}-rules.yml")
        if not yaml_file.exists():
            raise Exception(f"YAMLファイルが生成されませんでした: {yaml_file}")

        output = f"YAML設定ファイル生成: {yaml_file}"
        metrics = {
            "yaml_file": str(yaml_file),
            "topics_analyzed": len(self.config.topics)
        }

        return output, metrics

    def _run_index_creation(self) -> Tuple[str, Dict]:
        """インデックス作成実行"""
        cmd = [
            sys.executable,
            "codex_review_severity.py",
            "index",
            "--src-dir", str(self.test_dir),
            "--max-file-mb", str(self.config.max_file_mb),
            "--worker-count", str(self.config.worker_count)
        ]

        result = subprocess.run(
            cmd,
            capture_output=True,
            text=True,
            timeout=300
        )

        if result.returncode != 0:
            raise Exception(f"インデックス作成失敗: {result.stderr}")

        # インデックスファイルを確認
        index_file = Path(".advice_index.jsonl")
        if not index_file.exists():
            raise Exception("インデックスファイルが生成されませんでした")

        # インデックスファイルの行数をカウント
        with open(index_file, 'r', encoding='utf-8') as f:
            file_count = sum(1 for _ in f)

        output = f"インデックス作成完了: {file_count}ファイル"
        metrics = {
            "indexed_files": file_count
        }

        return output, metrics

    def _run_ai_analysis(self) -> Tuple[str, Dict]:
        """AI分析実行"""
        report_path = self.test_dir / "integration_test_report"

        cmd = [
            sys.executable,
            "codex_review_severity.py",
            "advise",
            "--all",
            "--complete-report",
            "--max-complete-items", "50",
            "--out", str(report_path)
        ]

        result = subprocess.run(
            cmd,
            capture_output=True,
            text=True,
            timeout=600  # 10分
        )

        if result.returncode != 0:
            raise Exception(f"AI分析失敗: {result.stderr}")

        # レポートファイルを確認
        report_file = Path(f"{report_path}.md")
        if not report_file.exists():
            raise Exception("分析レポートが生成されませんでした")

        # レポート内容を解析
        content = report_file.read_text(encoding='utf-8')
        issues_count = content.count("##")  # 問題セクションをカウント

        output = f"AI分析完了: {issues_count}個の問題を検出"
        metrics = {
            "issues_detected": issues_count,
            "report_file": str(report_file)
        }

        return output, metrics

    def _run_code_improvement(self) -> Tuple[str, Dict]:
        """改善コード適用"""
        report_file = self.test_dir / "integration_test_report.md"

        if not report_file.exists():
            raise Exception("分析レポートが見つかりません")

        cmd = [
            sys.executable,
            "apply_improvements_from_report.py",
            str(report_file),
            "--dry-run"  # テストなのでdry-runのみ
        ]

        result = subprocess.run(
            cmd,
            capture_output=True,
            text=True,
            timeout=300
        )

        if result.returncode != 0:
            # 改善コードがない場合もあるのでwarningとして扱う
            output = "改善コード適用スキップ（改善提案なし）"
            metrics = {"improvements_applied": 0}
            return output, metrics

        # 適用予定の改善数をカウント
        improvements = result.stdout.count("Would apply")

        output = f"改善コード確認完了: {improvements}個の改善を検出"
        metrics = {
            "improvements_available": improvements
        }

        return output, metrics

    def _verify_results(self) -> Tuple[str, Dict]:
        """結果検証"""
        checks = []

        # 1. YAMLファイル生成確認
        yaml_file = Path(f"config/{self.config.project_type}-rules.yml")
        yaml_exists = yaml_file.exists()
        checks.append(("YAML生成", yaml_exists))

        # 2. インデックスファイル確認
        index_exists = Path(".advice_index.jsonl").exists()
        checks.append(("インデックス作成", index_exists))

        # 3. レポートファイル確認
        report_exists = (self.test_dir / "integration_test_report.md").exists()
        checks.append(("分析レポート生成", report_exists))

        # 4. テストディレクトリ確認
        test_dir_exists = self.test_dir.exists()
        checks.append(("テストプロジェクト", test_dir_exists))

        success_count = sum(1 for _, result in checks if result)
        total_count = len(checks)
        all_passed = success_count == total_count

        output = f"検証結果: {success_count}/{total_count} 合格"
        for check_name, result in checks:
            status = "✅" if result else "❌"
            output += f"\n  {status} {check_name}"

        metrics = {
            "checks_passed": success_count,
            "checks_total": total_count,
            "all_passed": all_passed
        }

        if not all_passed:
            raise Exception("一部の検証に失敗しました")

        return output, metrics

    def _generate_summary(self) -> Dict[str, Any]:
        """サマリー生成"""
        total_steps = len(self.steps)
        successful_steps = sum(1 for step in self.steps if step.success)

        # 各ステップのメトリクスを集約
        files_created = 0
        indexed_files = 0
        issues_detected = 0
        improvements_available = 0

        for step in self.steps:
            if step.metrics:
                files_created += step.metrics.get("files_created", 0)
                indexed_files += step.metrics.get("indexed_files", 0)
                issues_detected += step.metrics.get("issues_detected", 0)
                improvements_available += step.metrics.get("improvements_available", 0)

        return {
            "total_steps": total_steps,
            "successful_steps": successful_steps,
            "success_rate": (successful_steps / total_steps * 100) if total_steps > 0 else 0,
            "files_created": files_created,
            "indexed_files": indexed_files,
            "issues_detected": issues_detected,
            "improvements_available": improvements_available,
            "project_type": self.config.project_type,
            "topics_analyzed": self.config.topics
        }

    def _print_report(self, result: IntegrationTestResult):
        """レポート出力（コンソール）"""
        print("\n")
        print("=" * 80)
        print("📊 統合テスト結果レポート")
        print("=" * 80)
        print()

        # 全体結果
        status_emoji = "✅" if result.overall_success else "❌"
        print(f"{status_emoji} 全体結果: {'成功' if result.overall_success else '失敗'}")
        print(f"⏱️  実行時間: {result.total_duration_seconds:.2f}秒")
        print()

        # ステップ別結果
        print("📋 ステップ別実行結果:")
        for i, step in enumerate(result.steps, 1):
            status = "✅" if step.success else "❌"
            print(f"  {status} {i}. {step.step_name} ({step.duration_seconds:.2f}秒)")
            if step.error:
                print(f"      エラー: {step.error}")
        print()

        # サマリー
        summary = result.summary
        print("📈 統計情報:")
        print(f"  プロジェクトタイプ: {summary['project_type']}")
        print(f"  分析トピック: {', '.join(summary['topics_analyzed'])}")
        print(f"  作成ファイル数: {summary['files_created']}")
        print(f"  インデックスファイル数: {summary['indexed_files']}")
        print(f"  検出問題数: {summary['issues_detected']}")
        print(f"  改善提案数: {summary['improvements_available']}")
        print(f"  成功率: {summary['success_rate']:.1f}%")
        print()

        print("=" * 80)
        if result.overall_success:
            print("🎉 統合テスト完了: 全ステップ成功")
        else:
            print("⚠️  統合テスト完了: 一部ステップで問題が発生")
        print("=" * 80)

    def _save_report(self, result: IntegrationTestResult):
        """レポート保存（JSON）"""
        report_dir = Path("reports")
        report_dir.mkdir(exist_ok=True)

        timestamp = datetime.now().strftime("%Y%m%d_%H%M%S")
        report_file = report_dir / f"integration_test_{timestamp}.json"

        # データクラスをdictに変換
        report_data = {
            "config": asdict(result.config),
            "start_time": result.start_time,
            "end_time": result.end_time,
            "total_duration_seconds": result.total_duration_seconds,
            "overall_success": result.overall_success,
            "steps": [asdict(step) for step in result.steps],
            "summary": result.summary
        }

        # Path objectsをstrに変換
        def convert_paths(obj):
            if isinstance(obj, dict):
                return {k: convert_paths(v) for k, v in obj.items()}
            elif isinstance(obj, list):
                return [convert_paths(item) for item in obj]
            elif isinstance(obj, Path):
                return str(obj)
            return obj

        report_data = convert_paths(report_data)

        with open(report_file, 'w', encoding='utf-8') as f:
            json.dump(report_data, f, indent=2, ensure_ascii=False)

        print(f"\n💾 レポート保存: {report_file}")


def main():
    """メイン関数（CLI実行用） - Phase 8.4: デフォルト設定統合"""
    import argparse

    # デフォルト設定マネージャーをインポート (Phase 8.4)
    try:
        from core.integration_test_config import get_config_manager
        config_manager = get_config_manager()
        use_defaults = True
    except ImportError:
        # フォールバック: インポートできない場合はハードコード
        config_manager = None
        use_defaults = False

    parser = argparse.ArgumentParser(
        description="BugSearch2 統合テスト - 全工程一貫性テスト"
    )
    parser.add_argument(
        "--project-type",
        required=False,  # Phase 8.4: オプショナルに変更（デフォルト設定使用可）
        choices=["react", "angular", "vue", "express", "django", "spring-boot", "flask", "nestjs", "mysql", "postgresql", "sqlserver", "oracle", "memcached"],
        help="テストプロジェクトタイプ（省略時はデフォルト設定から取得）"
    )
    parser.add_argument(
        "--topics",
        nargs="+",
        help="分析トピック（複数指定可、省略時はデフォルト設定から取得）"
    )
    parser.add_argument(
        "--no-examples",
        action="store_true",
        help="サンプルコードを含めない"
    )
    parser.add_argument(
        "--test-dir",
        type=Path,
        default=Path("test_integration"),
        help="テストディレクトリ"
    )
    parser.add_argument(
        "--max-file-mb",
        type=int,
        help="最大ファイルサイズ (MB、省略時はデフォルト設定から取得)"
    )
    parser.add_argument(
        "--worker-count",
        type=int,
        help="並列ワーカー数（省略時はデフォルト設定から取得）"
    )

    args = parser.parse_args()

    # デフォルト設定の適用 (Phase 8.4)
    if use_defaults and config_manager:
        # project-type
        if not args.project_type:
            default_projects = config_manager.get_integration_test_default_project_types()
            if default_projects:
                args.project_type = default_projects[0]  # 最初のプロジェクトタイプを使用
                print(f"[INFO] デフォルト設定からproject-type取得: {args.project_type}")
            else:
                print("[ERROR] project-typeが指定されておらず、デフォルト設定も空です")
                sys.exit(1)

        # topics
        if not args.topics:
            args.topics = config_manager.get_integration_test_default_topics()
            if args.topics:
                print(f"[INFO] デフォルト設定からtopics取得: {', '.join(args.topics)}")
            else:
                args.topics = ["security", "performance"]  # 最終フォールバック

        # max-file-mb
        if args.max_file_mb is None:
            args.max_file_mb = config_manager.get_integration_test_default_max_file_mb()
            print(f"[INFO] デフォルト設定からmax-file-mb取得: {args.max_file_mb}")

        # worker-count
        if args.worker_count is None:
            args.worker_count = config_manager.get_integration_test_default_worker_count()
            print(f"[INFO] デフォルト設定からworker-count取得: {args.worker_count}")
    else:
        # デフォルト設定マネージャーが使えない場合のフォールバック
        if not args.project_type:
            print("[ERROR] --project-type は必須です（デフォルト設定が利用できません）")
            sys.exit(1)
        if not args.topics:
            args.topics = ["security", "performance"]
        if args.max_file_mb is None:
            args.max_file_mb = 4
        if args.worker_count is None:
            args.worker_count = 4

    config = IntegrationTestConfig(
        project_type=args.project_type,
        topics=args.topics,
        include_examples=not args.no_examples,
        test_dir=args.test_dir,
        max_file_mb=args.max_file_mb,
        worker_count=args.worker_count
    )

    engine = IntegrationTestEngine(config)
    result = engine.run()

    # 終了コード
    sys.exit(0 if result.overall_success else 1)


if __name__ == "__main__":
    main()

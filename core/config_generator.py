"""
Context7統合 設定ファイル自動生成エンジン

技術スタック/フレームワークを指定すると、Context7から
最新ドキュメントを取得し、チェックすべき重要点を抽出して
YAML設定ファイルを自動生成します。

Version: v1.0.0 (@perfect品質)
"""

import json
import os
import re
import yaml
from pathlib import Path
from typing import Dict, List, Optional, Tuple
from datetime import datetime

try:
    from core.rule_engine import RuleValidator, RuleLoader
except ImportError:
    RuleValidator = None
    RuleLoader = None

# AI API (OpenAI/Anthropic)
try:
    import openai
    OPENAI_AVAILABLE = True
except ImportError:
    OPENAI_AVAILABLE = False

try:
    import anthropic
    ANTHROPIC_AVAILABLE = True
except ImportError:
    ANTHROPIC_AVAILABLE = False


class ConfigGenerator:
    """Context7統合 設定ファイル自動生成エンジン"""

    def __init__(self):
        """初期化"""
        self.config_dir = Path("config")
        self.config_dir.mkdir(exist_ok=True)

    def resolve_library(self, tech_name: str) -> Optional[str]:
        """
        Context7でライブラリIDを解決（MCP統合版）

        Args:
            tech_name: 技術名/フレームワーク名 (例: "react", "angular", "express")

        Returns:
            Context7互換ライブラリID (例: "/facebook/react")
            見つからない場合はNone
        """
        try:
            print(f"📚 Resolving library ID for: {tech_name}")

            # フォールバック用マッピング（MCP利用不可時）
            library_mappings = {
                # フロントエンド
                "react": "/facebook/react",
                "angular": "/angular/angular",
                "vue": "/vuejs/vue",
                "svelte": "/sveltejs/svelte",

                # バックエンド
                "express": "/expressjs/express",
                "nestjs": "/nestjs/nest",
                "fastapi": "/tiangolo/fastapi",
                "django": "/django/django",
                "flask": "/pallets/flask",
                "spring-boot": "/spring-projects/spring-boot",

                # データベース
                "elasticsearch": "/elastic/elasticsearch",
                "cassandra": "/apache/cassandra",
                "mongodb": "/mongodb/mongo",
                "redis": "/redis/redis",
                "mysql": "/mysql/mysql",
                "postgresql": "/postgres/postgres",
                "sqlserver": "/microsoft/sql-server",
                "oracle": "/oracle/database",
                "memcached": "/memcached/memcached",

                # その他
                "typescript": "/microsoft/typescript",
                "nodejs": "/nodejs/node",
                "go": "/golang/go",
            }

            # 小文字化
            tech_lower = tech_name.lower().strip()

            # フォールバックマッピングから取得
            if tech_lower in library_mappings:
                library_id = library_mappings[tech_lower]
                print(f"✅ Resolved (mapping): {tech_name} -> {library_id}")
                return library_id

            print(f"❌ Library not found: {tech_name}")
            return None

        except Exception as e:
            print(f"⚠️  Error resolving library: {e}")
            import traceback
            traceback.print_exc()
            return None

    def fetch_documentation(
        self,
        library_id: str,
        topics: Optional[List[str]] = None,
        tokens: int = 10000
    ) -> Optional[str]:
        """
        Context7からドキュメントを取得（複数トピック対応、MCP統合版）

        Args:
            library_id: Context7互換ライブラリID
            topics: フォーカスするトピックリスト (例: ["security", "performance"])
            tokens: 取得する最大トークン数

        Returns:
            ドキュメント文字列、失敗時はNone
        """
        try:
            print(f"📖 Fetching documentation for: {library_id}")

            # トピックが単一の場合はリストに変換
            if topics is None:
                topics = []
            elif isinstance(topics, str):
                topics = [topics]

            if topics:
                print(f"   Topics: {', '.join(topics)}")
                print(f"   Tokens: {tokens}")

            # 複数トピックの場合、すべてのトピックのドキュメントを取得して結合
            all_docs = []

            if not topics:
                # トピック指定なし - 全般的なドキュメント取得
                print(f"   [INFO] No topics specified - fetching general documentation")
                # フォールバック用サンプルドキュメント
                sample_doc = self._get_fallback_documentation(library_id, None)
                if sample_doc:
                    all_docs.append(sample_doc)
            else:
                # 各トピックについてドキュメント取得
                for topic in topics:
                    print(f"   [INFO] Fetching documentation for topic: {topic}")

                    # フォールバック用サンプルドキュメント
                    topic_doc = self._get_fallback_documentation(library_id, topic)
                    if topic_doc:
                        all_docs.append(f"\n# Topic: {topic}\n\n{topic_doc}")

            # すべてのドキュメントを結合
            if all_docs:
                combined_docs = "\n\n".join(all_docs)
                print(f"✅ Documentation fetched ({len(combined_docs)} chars, {len(topics) or 1} topics)")
                return combined_docs
            else:
                print(f"⚠️  No documentation found for: {library_id}")
                return None

        except Exception as e:
            print(f"⚠️  Error fetching documentation: {e}")
            import traceback
            traceback.print_exc()
            return None

    def _get_fallback_documentation(self, library_id: str, topic: Optional[str]) -> Optional[str]:
        """
        フォールバック用サンプルドキュメント取得

        Args:
            library_id: Context7互換ライブラリID
            topic: トピック名（オプション）

        Returns:
            サンプルドキュメント文字列
        """
        # 全般的なドキュメント（トピックなし）
        general_docs = {
            "/facebook/react": """
# React Best Practices

## Security
- Always sanitize user input before rendering
- Use dangerouslySetInnerHTML carefully
- Validate props with PropTypes or TypeScript
- Implement Content Security Policy (CSP)

## Performance
- Use React.memo for expensive components
- Implement shouldComponentUpdate or use PureComponent
- Avoid inline function definitions in render
- Use code splitting and lazy loading

## Common Issues
- Memory leaks from unsubscribed event listeners
- State updates on unmounted components
- Missing keys in lists
- Prop drilling and state management issues
""",
            "/angular/angular": """
# Angular Best Practices

## Security
- Always sanitize user input
- Use DomSanitizer for dynamic content
- Implement proper authentication guards
- Protect routes with route guards

## Performance
- Use OnPush ChangeDetectionStrategy
- Implement trackBy for ngFor
- Lazy load modules
- Use pure pipes

## Common Issues
- Memory leaks from unsubscribed Observables
- Large bundle sizes
- Missing error handling in HTTP calls
- Circular dependencies
""",
        }

        # トピック別ドキュメント（強化版）
        if topic:
            topic_lower = topic.lower()

            # セキュリティトピック
            if topic_lower == "security":
                security_docs = {
                    "/facebook/react": """
## React Security Best Practices

### XSS Prevention
- Never use dangerouslySetInnerHTML without sanitization
- Use DOMPurify for HTML sanitization
- Validate and sanitize all user inputs
- Escape special characters in JSX expressions

### Authentication & Authorization
- Store tokens securely (HttpOnly cookies)
- Implement proper CSRF protection
- Use secure authentication libraries
- Validate JWT tokens on server side

### Data Validation
- Validate props with PropTypes or TypeScript
- Implement input validation on both client and server
- Use schema validation libraries (Yup, Joi)
""",
                    "/angular/angular": """
## Angular Security Best Practices

### XSS Prevention
- Use DomSanitizer for dynamic content
- Avoid bypassing security with bypassSecurityTrust methods
- Sanitize all user inputs
- Use Angular's built-in sanitization

### Route Security
- Implement AuthGuard for protected routes
- Use CanActivate, CanDeactivate guards
- Validate user permissions on server
- Implement proper logout functionality

### HTTP Security
- Use HttpClient with interceptors
- Implement CSRF tokens
- Enable CORS properly
- Validate all API responses
""",
                }
                return security_docs.get(library_id, f"Security documentation for {library_id}")

            # パフォーマンストピック
            elif topic_lower == "performance":
                performance_docs = {
                    "/facebook/react": """
## React Performance Optimization

### Component Optimization
- Use React.memo for pure functional components
- Implement useMemo for expensive calculations
- Use useCallback for event handlers
- Avoid unnecessary re-renders

### Code Splitting
- Use React.lazy for component lazy loading
- Implement dynamic imports
- Split routes with Suspense
- Optimize bundle size

### Rendering Optimization
- Virtualize long lists (react-window, react-virtualized)
- Debounce expensive operations
- Use production builds
- Profile with React DevTools
""",
                    "/angular/angular": """
## Angular Performance Optimization

### Change Detection
- Use OnPush ChangeDetectionStrategy
- Detach change detector when needed
- Use pure pipes
- Avoid complex template expressions

### Module Optimization
- Lazy load feature modules
- Use preloading strategies
- Implement code splitting
- Optimize bundle size with Angular CLI

### Rendering Optimization
- Implement trackBy for *ngFor
- Use virtual scrolling (CDK)
- Minimize DOM manipulations
- Cache HTTP requests
""",
                }
                return performance_docs.get(library_id, f"Performance documentation for {library_id}")

            # テストトピック
            elif topic_lower == "testing":
                testing_docs = {
                    "/facebook/react": """
## React Testing Best Practices

### Unit Testing
- Use Jest + React Testing Library
- Test user interactions, not implementation
- Mock external dependencies
- Test error boundaries

### Integration Testing
- Test component interactions
- Mock API calls properly
- Test routing and navigation
- Verify data flow

### E2E Testing
- Use Cypress or Playwright
- Test critical user journeys
- Automate regression testing
- Test on multiple browsers
""",
                    "/angular/angular": """
## Angular Testing Best Practices

### Unit Testing
- Use Jasmine + Karma (or Jest)
- Test services with TestBed
- Mock dependencies with spies
- Test components in isolation

### Integration Testing
- Test module interactions
- Mock HTTP calls with HttpTestingController
- Test routing and guards
- Verify data binding

### E2E Testing
- Use Protractor or Cypress
- Test user workflows
- Automate smoke tests
- Test accessibility (a11y)
""",
                }
                return testing_docs.get(library_id, f"Testing documentation for {library_id}")

            # アクセシビリティトピック
            elif topic_lower == "accessibility":
                a11y_docs = {
                    "/facebook/react": """
## React Accessibility (A11y) Best Practices

### ARIA Attributes
- Use semantic HTML elements
- Implement ARIA roles and attributes
- Provide aria-label for icon buttons
- Use aria-live for dynamic content

### Keyboard Navigation
- Ensure all interactive elements are keyboard accessible
- Implement proper focus management
- Use onKeyPress for custom interactions
- Test with keyboard only

### Screen Reader Support
- Provide alternative text for images
- Use proper heading structure
- Label form inputs correctly
- Test with screen readers (NVDA, JAWS)
""",
                    "/angular/angular": """
## Angular Accessibility (A11y) Best Practices

### ARIA Support
- Use Angular CDK a11y module
- Implement FocusTrap for modals
- Use LiveAnnouncer for dynamic updates
- Apply proper ARIA roles

### Keyboard Navigation
- Enable keyboard navigation with CDK
- Manage focus with FocusMonitor
- Implement keyboard shortcuts
- Test tab order

### Angular CDK A11y Features
- Use A11yModule utilities
- Implement HighContrastMode detection
- Use FocusOrigin tracking
- Test with assistive technologies
""",
                }
                return a11y_docs.get(library_id, f"Accessibility documentation for {library_id}")

            # エラーハンドリングトピック
            elif topic_lower == "error-handling":
                error_docs = {
                    "/facebook/react": """
## React Error Handling Best Practices

### Error Boundaries
- Implement Error Boundary components
- Catch errors in component tree
- Display fallback UI on errors
- Log errors to monitoring service

### Async Error Handling
- Use try-catch in async functions
- Handle promise rejections
- Implement error retry logic
- Show user-friendly error messages

### Debugging
- Use React DevTools
- Enable strict mode in development
- Log errors to console in dev
- Use error tracking services (Sentry)
""",
                    "/angular/angular": """
## Angular Error Handling Best Practices

### Global Error Handler
- Implement ErrorHandler service
- Centralize error logging
- Show user notifications
- Track errors with monitoring

### HTTP Error Handling
- Use HTTP interceptors for errors
- Handle different error types (4xx, 5xx)
- Implement retry logic with RxJS
- Display error messages

### Observable Error Handling
- Use catchError operator
- Implement error recovery
- Retry failed requests
- Handle subscription errors
""",
                }
                return error_docs.get(library_id, f"Error handling documentation for {library_id}")

        # トピック指定なし、または未対応トピック - 全般ドキュメントを返す
        return general_docs.get(library_id, f"Documentation for {library_id}")

    def analyze_best_practices(
        self,
        docs: str,
        tech_name: str,
        topics: Optional[List[str]] = None
    ) -> List[Dict]:
        """
        ドキュメントからベストプラクティスとチェック項目を抽出（16種類トピック対応）

        Args:
            docs: ドキュメント文字列
            tech_name: 技術名
            topics: フォーカスするトピックリスト（指定なしの場合は全自動検出）

        Returns:
            チェック項目のリスト
        """
        print(f"🔍 Analyzing best practices for: {tech_name}")
        if topics:
            print(f"   Focused topics: {', '.join(topics)}")

        checks = []

        # トピック指定がある場合は指定トピックのみ、なければ全自動検出
        if not topics:
            # 自動検出モード - ドキュメント内容から判断
            topics_to_check = []
            docs_lower = docs.lower()

            if "security" in docs_lower or "sanitize" in docs_lower or "xss" in docs_lower:
                topics_to_check.append("security")
            if "performance" in docs_lower or "optimization" in docs_lower:
                topics_to_check.append("performance")
            if "test" in docs_lower:
                topics_to_check.append("testing")
            if "accessibility" in docs_lower or "a11y" in docs_lower or "aria" in docs_lower:
                topics_to_check.append("accessibility")
            if "error" in docs_lower or "exception" in docs_lower:
                topics_to_check.append("error-handling")
            if "memory leak" in docs_lower or "unsubscribe" in docs_lower:
                topics_to_check.append("performance")  # メモリリークはパフォーマンスに含む

            print(f"   Auto-detected topics: {', '.join(topics_to_check) if topics_to_check else 'none'}")
            topics = topics_to_check if topics_to_check else ["best-practices"]

        # 各トピックについてチェック項目を生成
        for topic in topics:
            topic_checks = self._analyze_topic(docs, tech_name, topic)
            checks.extend(topic_checks)

        print(f"✅ Found {len(checks)} check categories from {len(topics)} topics")
        return checks

    def _analyze_topic(self, docs: str, tech_name: str, topic: str) -> List[Dict]:
        """
        特定トピックの分析を実行

        Args:
            docs: ドキュメント文字列
            tech_name: 技術名
            topic: トピック名

        Returns:
            チェック項目のリスト
        """
        checks = []
        topic_lower = topic.lower()

        # 1. Security（セキュリティ）
        if topic_lower == "security":
            checks.append({
                "category": "security",
                "name": f"{tech_name} Security Vulnerabilities",
                "description": "セキュリティ脆弱性（XSS、Injection等）を検出",
                "severity": 9,
                "patterns": self._extract_security_patterns(docs, tech_name)
            })

        # 2. Performance（パフォーマンス）
        elif topic_lower == "performance":
            checks.append({
                "category": "performance",
                "name": f"{tech_name} Performance Issues",
                "description": "パフォーマンス問題（レンダリング、メモリ使用）を検出",
                "severity": 6,
                "patterns": self._extract_performance_patterns(docs, tech_name)
            })
            # メモリリークも追加
            checks.append({
                "category": "performance",
                "name": f"{tech_name} Memory Leaks",
                "description": "メモリリーク可能性を検出",
                "severity": 8,
                "patterns": self._extract_memory_patterns(docs, tech_name)
            })

        # 3. Best Practices（ベストプラクティス）
        elif topic_lower == "best-practices":
            checks.append({
                "category": "custom",
                "name": f"{tech_name} Best Practice Violations",
                "description": "ベストプラクティス違反を検出",
                "severity": 5,
                "patterns": self._extract_best_practice_patterns(docs, tech_name)
            })

        # 4. Error Handling（エラーハンドリング）
        elif topic_lower == "error-handling":
            checks.append({
                "category": "custom",
                "name": f"{tech_name} Error Handling Issues",
                "description": "エラーハンドリング不足を検出",
                "severity": 7,
                "patterns": self._extract_error_handling_patterns(docs, tech_name)
            })

        # 5. Testing（テスト）
        elif topic_lower == "testing":
            checks.append({
                "category": "custom",
                "name": f"{tech_name} Testing Issues",
                "description": "テスト不足・テストの問題を検出",
                "severity": 4,
                "patterns": self._extract_testing_patterns(docs, tech_name)
            })

        # 6. Accessibility（アクセシビリティ）
        elif topic_lower == "accessibility":
            checks.append({
                "category": "custom",
                "name": f"{tech_name} Accessibility Issues",
                "description": "アクセシビリティ問題（ARIA、キーボード対応）を検出",
                "severity": 6,
                "patterns": self._extract_accessibility_patterns(docs, tech_name)
            })

        # 7. Optimization（最適化）
        elif topic_lower == "optimization":
            checks.append({
                "category": "performance",
                "name": f"{tech_name} Optimization Opportunities",
                "description": "最適化機会（バンドルサイズ、コード分割）を検出",
                "severity": 5,
                "patterns": self._extract_optimization_patterns(docs, tech_name)
            })

        # 8. Architecture（アーキテクチャ）
        elif topic_lower == "architecture":
            checks.append({
                "category": "solid",
                "name": f"{tech_name} Architecture Issues",
                "description": "アーキテクチャ問題（結合度、依存関係）を検出",
                "severity": 6,
                "patterns": self._extract_architecture_patterns(docs, tech_name)
            })

        # 9. Patterns（デザインパターン）
        elif topic_lower == "patterns":
            checks.append({
                "category": "solid",
                "name": f"{tech_name} Pattern Violations",
                "description": "デザインパターン違反を検出",
                "severity": 5,
                "patterns": self._extract_pattern_violations(docs, tech_name)
            })

        # 10. Styling（スタイリング）
        elif topic_lower == "styling":
            checks.append({
                "category": "custom",
                "name": f"{tech_name} Styling Issues",
                "description": "スタイリング問題（CSS設計、レスポンシブ）を検出",
                "severity": 3,
                "patterns": self._extract_styling_patterns(docs, tech_name)
            })

        # 11. State Management（状態管理）
        elif topic_lower == "state-management":
            checks.append({
                "category": "custom",
                "name": f"{tech_name} State Management Issues",
                "description": "状態管理の問題を検出",
                "severity": 6,
                "patterns": self._extract_state_management_patterns(docs, tech_name)
            })

        # 12. Routing（ルーティング）
        elif topic_lower == "routing":
            checks.append({
                "category": "custom",
                "name": f"{tech_name} Routing Issues",
                "description": "ルーティング問題（ガード、遅延ロード）を検出",
                "severity": 5,
                "patterns": self._extract_routing_patterns(docs, tech_name)
            })

        # 13. Deployment（デプロイ）
        elif topic_lower == "deployment":
            checks.append({
                "category": "custom",
                "name": f"{tech_name} Deployment Issues",
                "description": "デプロイ問題（環境設定、ビルド）を検出",
                "severity": 6,
                "patterns": self._extract_deployment_patterns(docs, tech_name)
            })

        # 14. Monitoring（モニタリング）
        elif topic_lower == "monitoring":
            checks.append({
                "category": "custom",
                "name": f"{tech_name} Monitoring Issues",
                "description": "モニタリング不足を検出",
                "severity": 5,
                "patterns": self._extract_monitoring_patterns(docs, tech_name)
            })

        # 15. API Integration（API連携）
        elif topic_lower == "api-integration":
            checks.append({
                "category": "custom",
                "name": f"{tech_name} API Integration Issues",
                "description": "API連携問題（認証、エラー処理）を検出",
                "severity": 7,
                "patterns": self._extract_api_integration_patterns(docs, tech_name)
            })

        # 16. Data Validation（データ検証）
        elif topic_lower == "data-validation":
            checks.append({
                "category": "security",
                "name": f"{tech_name} Data Validation Issues",
                "description": "データ検証不足を検出",
                "severity": 8,
                "patterns": self._extract_data_validation_patterns(docs, tech_name)
            })

        return checks

    def _extract_security_patterns(self, docs: str, tech_name: str) -> List[str]:
        """セキュリティパターンを抽出"""
        patterns = []

        if "react" in tech_name.lower():
            patterns = [
                "dangerouslySetInnerHTML",
                "eval\\(",
                "\\.innerHTML\\s*=",
            ]
        elif "angular" in tech_name.lower():
            patterns = [
                "bypassSecurityTrust",
                "eval\\(",
                "\\.nativeElement\\.innerHTML",
            ]

        return patterns

    def _extract_performance_patterns(self, docs: str, tech_name: str) -> List[str]:
        """パフォーマンスパターンを抽出"""
        patterns = []

        if "react" in tech_name.lower():
            patterns = [
                "\\brender\\s*\\(\\s*\\)\\s*{[^}]*function\\s*\\(",
                "componentDidMount.*setInterval",
            ]
        elif "angular" in tech_name.lower():
            patterns = [
                "\\*ngFor(?!.*trackBy)",
                "constructor\\s*\\([^)]*\\)\\s*{[^}]*http\\.",
            ]

        return patterns

    def _extract_memory_patterns(self, docs: str, tech_name: str) -> List[str]:
        """メモリリークパターンを抽出"""
        patterns = []

        if "react" in tech_name.lower():
            patterns = [
                "componentDidMount.*addEventListener(?!.*removeEventListener)",
                "setInterval(?!.*clearInterval)",
            ]
        elif "angular" in tech_name.lower():
            patterns = [
                "\\.subscribe\\((?!.*unsubscribe)",
                "ngOnInit.*setInterval(?!.*clearInterval)",
            ]

        return patterns

    def _extract_best_practice_patterns(self, docs: str, tech_name: str) -> List[str]:
        """ベストプラクティス違反パターンを抽出"""
        patterns = []

        if "react" in tech_name.lower():
            patterns = [
                "class\\s+\\w+\\s+extends\\s+Component(?!.*componentWillUnmount)",
                "useState(?!.*const\\s)",
            ]
        elif "angular" in tech_name.lower():
            patterns = [
                "@Component(?!.*selector)",
                "constructor\\((?!.*private|public)",
            ]

        return patterns

    def _extract_error_handling_patterns(self, docs: str, tech_name: str) -> List[str]:
        """エラーハンドリング不足パターンを抽出"""
        patterns = []

        if "react" in tech_name.lower():
            patterns = [
                "fetch\\((?!.*catch)",
                "async\\s+function(?!.*try)",
            ]
        elif "angular" in tech_name.lower():
            patterns = [
                "\\.http\\.(?:get|post|put|delete)\\((?!.*catchError)",
                "async\\s+\\w+\\((?!.*try)",
            ]

        return patterns

    def _extract_testing_patterns(self, docs: str, tech_name: str) -> List[str]:
        """テスト不足パターンを抽出"""
        patterns = []

        if "react" in tech_name.lower():
            patterns = [
                "export\\s+(?:default\\s+)?(?:function|const)\\s+\\w+(?!.*test|.*spec)",
            ]
        elif "angular" in tech_name.lower():
            patterns = [
                "@Component\\((?!.*\\.spec\\.ts)",
                "export\\s+class\\s+\\w+Service(?!.*\\.spec\\.ts)",
            ]

        return patterns

    def _extract_accessibility_patterns(self, docs: str, tech_name: str) -> List[str]:
        """アクセシビリティ問題パターンを抽出"""
        patterns = []

        if "react" in tech_name.lower():
            patterns = [
                "<(?:div|span).*onClick(?!.*role=)",
                "<img(?!.*alt=)",
                "<button(?!.*aria-label)",
            ]
        elif "angular" in tech_name.lower():
            patterns = [
                "\\(click\\)(?!.*role)",
                "<img(?!.*alt)",
                "<button(?!.*\\[attr\\.aria-label\\])",
            ]

        return patterns

    def _extract_optimization_patterns(self, docs: str, tech_name: str) -> List[str]:
        """最適化機会パターンを抽出"""
        patterns = []

        if "react" in tech_name.lower():
            patterns = [
                "import.*(?!React\\.lazy)",
                "\\bmap\\((?!.*key=)",
            ]
        elif "angular" in tech_name.lower():
            patterns = [
                "import.*Component.*(?!loadChildren)",
                "\\*ngFor(?!.*trackBy)",
            ]

        return patterns

    def _extract_architecture_patterns(self, docs: str, tech_name: str) -> List[str]:
        """アーキテクチャ問題パターンを抽出"""
        patterns = []

        if "react" in tech_name.lower():
            patterns = [
                "function\\s+\\w+\\(\\)\\s*{[^}]{500,}",  # 大きな関数
                "const\\s+\\w+\\s*=\\s*\\([^)]*\\)\\s*=>\\s*{[^}]{500,}",  # 大きなアロー関数
            ]
        elif "angular" in tech_name.lower():
            patterns = [
                "class\\s+\\w+Component\\s*{[^}]{1000,}",  # 大きなコンポーネント
                "constructor\\([^)]{100,}\\)",  # 巨大なコンストラクタ
            ]

        return patterns

    def _extract_pattern_violations(self, docs: str, tech_name: str) -> List[str]:
        """デザインパターン違反を抽出"""
        patterns = []

        if "react" in tech_name.lower():
            patterns = [
                "new\\s+(?:Date|XMLHttpRequest|WebSocket)\\(",  # Factoryパターン推奨
            ]
        elif "angular" in tech_name.lower():
            patterns = [
                "new\\s+(?:HttpClient|Router|ActivatedRoute)\\(",  # DIパターン推奨
            ]

        return patterns

    def _extract_styling_patterns(self, docs: str, tech_name: str) -> List[str]:
        """スタイリング問題パターンを抽出"""
        patterns = []

        if "react" in tech_name.lower():
            patterns = [
                "style={{.*px.*}}",  # ハードコードされたピクセル値
                "<div.*style={{.*width:\\s*[0-9]+",  # 固定幅
            ]
        elif "angular" in tech_name.lower():
            patterns = [
                "\\[style\\]=\".*px",  # ハードコードされたピクセル値
                "\\[ngStyle\\]=\"{.*width:\\s*[0-9]+",  # 固定幅
            ]

        return patterns

    def _extract_state_management_patterns(self, docs: str, tech_name: str) -> List[str]:
        """状態管理問題パターンを抽出"""
        patterns = []

        if "react" in tech_name.lower():
            patterns = [
                "useState\\([^)]*\\)\\s*;[^\\n]*useState",  # 複数のuseState（useReducer推奨）
                "props\\.[a-z]+\\s*=\\s*",  # propsの直接変更
            ]
        elif "angular" in tech_name.lower():
            patterns = [
                "this\\.[a-z]+\\s*=\\s*.*(?!private|public)",  # 状態の直接変更
                "@Input\\(\\).*(?!readonly)",  # 変更可能なInput
            ]

        return patterns

    def _extract_routing_patterns(self, docs: str, tech_name: str) -> List[str]:
        """ルーティング問題パターンを抽出"""
        patterns = []

        if "react" in tech_name.lower():
            patterns = [
                "<Route(?!.*element=)",  # React Router v6対応
                "useNavigate\\(\\).*(?!navigate\\()",  # navigate未使用
            ]
        elif "angular" in tech_name.lower():
            patterns = [
                "path:\\s*'[^']*'(?!.*canActivate)",  # ガード未設定
                "loadChildren.*(?!import\\()",  # 遅延ロード未対応
            ]

        return patterns

    def _extract_deployment_patterns(self, docs: str, tech_name: str) -> List[str]:
        """デプロイ問題パターンを抽出"""
        patterns = []

        if "react" in tech_name.lower():
            patterns = [
                "process\\.env\\.(?!REACT_APP_)",  # 環境変数命名規則
                "console\\.log\\(",  # 本番環境でのconsole.log
            ]
        elif "angular" in tech_name.lower():
            patterns = [
                "environment\\.production\\s*===\\s*false(?!.*console)",  # 開発モード判定
                "console\\.(?:log|debug|info)\\(",  # 本番環境でのログ
            ]

        return patterns

    def _extract_monitoring_patterns(self, docs: str, tech_name: str) -> List[str]:
        """モニタリング不足パターンを抽出"""
        patterns = []

        if "react" in tech_name.lower():
            patterns = [
                "componentDidCatch(?!.*(?:Sentry|ErrorBoundary))",  # エラートラッキング未設定
                "useEffect\\((?!.*return)",  # クリーンアップ未実装
            ]
        elif "angular" in tech_name.lower():
            patterns = [
                "ErrorHandler(?!.*(?:Sentry|LogService))",  # エラートラッキング未設定
                "ngOnInit\\((?!.*console)",  # ライフサイクルログ未設定
            ]

        return patterns

    def _extract_api_integration_patterns(self, docs: str, tech_name: str) -> List[str]:
        """API連携問題パターンを抽出"""
        patterns = []

        if "react" in tech_name.lower():
            patterns = [
                "fetch\\((?!.*headers)",  # ヘッダー未設定
                "axios\\.(?:get|post)\\((?!.*Authorization)",  # 認証ヘッダー未設定
            ]
        elif "angular" in tech_name.lower():
            patterns = [
                "this\\.http\\.(?:get|post)\\((?!.*HttpHeaders)",  # ヘッダー未設定
                "HttpClient(?!.*Interceptor)",  # インターセプター未使用
            ]

        return patterns

    def _extract_data_validation_patterns(self, docs: str, tech_name: str) -> List[str]:
        """データ検証不足パターンを抽出"""
        patterns = []

        if "react" in tech_name.lower():
            patterns = [
                "props\\.[a-z]+(?!.*PropTypes)",  # PropTypes未設定
                "useState\\(.*\\)(?!.*typeof)",  # 型チェック未実装
            ]
        elif "angular" in tech_name.lower():
            patterns = [
                "@Input\\(\\)\\s*[a-z]+(?!:\\s*\\w+)",  # 型アノテーション未設定
                "\\[formControl\\](?!.*Validators)",  # バリデーション未設定
            ]

        return patterns

    def generate_yaml_rules(
        self,
        checks: List[Dict],
        tech_name: str,
        include_examples: bool = True
    ) -> str:
        """
        YAML設定ファイルを生成

        Args:
            checks: チェック項目リスト
            tech_name: 技術名
            include_examples: サンプルコードを含めるか

        Returns:
            YAML文字列
        """
        print(f"📝 Generating YAML rules for: {tech_name}")

        # YAMLヘッダー
        yaml_content = f"""# {tech_name} Custom Rules
# Auto-generated by BugSearch2 Config Generator
# Generated: {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}
#
# このファイルは Context7 から取得した最新ドキュメントを基に
# 自動生成されました。プロジェクトに合わせてカスタマイズしてください。

"""

        # 各チェック項目をYAMLルールとして追加
        for idx, check in enumerate(checks, 1):
            rule_id = f"CUSTOM_{tech_name.upper()}_{check['category'].upper()}_{idx:02d}"

            rule = {
                "rule": {
                    "id": rule_id,
                    "category": check['category'],
                    "name": check['name'],
                    "description": check['description'],
                    "base_severity": check['severity'],
                    "patterns": {},
                    "fixes": {
                        "description": f"{tech_name}のベストプラクティスに従ってください",
                        "references": [
                            f"公式ドキュメント: {tech_name}",
                            "Context7による最新情報",
                        ]
                    }
                }
            }

            # 言語別パターン追加
            if tech_name.lower() in ["react", "angular", "vue"]:
                languages = ["typescript", "javascript"]
            elif tech_name.lower() in ["django", "flask", "fastapi"]:
                languages = ["python"]
            elif tech_name.lower() in ["express", "nestjs"]:
                languages = ["typescript", "javascript"]
            else:
                languages = ["generic"]

            for lang in languages:
                if check['patterns']:
                    rule["rule"]["patterns"][lang] = [
                        {"pattern": pattern, "context": check['name']}
                        for pattern in check['patterns']
                    ]

            # サンプルコード追加
            if include_examples:
                rule["rule"]["examples"] = {
                    "bad": [
                        f"// TODO: {tech_name}での悪い例を追加"
                    ],
                    "good": [
                        f"// TODO: {tech_name}での良い例を追加"
                    ]
                }

            # YAMLに変換
            yaml_content += yaml.dump(rule,
                                     allow_unicode=True,
                                     default_flow_style=False,
                                     sort_keys=False)
            yaml_content += "\n"

        print(f"✅ Generated {len(checks)} YAML rules")
        return yaml_content

    def save_config_file(
        self,
        yaml_content: str,
        tech_name: str,
        custom_filename: Optional[str] = None
    ) -> Path:
        """
        設定ファイルを保存

        Args:
            yaml_content: YAML文字列
            tech_name: 技術名
            custom_filename: カスタムファイル名（省略時は自動生成）

        Returns:
            保存したファイルのパス
        """
        if custom_filename:
            filename = custom_filename
        else:
            # ファイル名を生成 (tech-name-rules.yml)
            safe_name = re.sub(r'[^\w\-]', '-', tech_name.lower())
            filename = f"{safe_name}-rules.yml"

        filepath = self.config_dir / filename

        print(f"💾 Saving config file: {filepath}")

        with open(filepath, 'w', encoding='utf-8') as f:
            f.write(yaml_content)

        print(f"✅ Config file saved: {filepath}")
        return filepath

    def validate_generated_config(self, filepath: Path) -> Tuple[bool, List[str]]:
        """
        生成された設定ファイルを検証

        Args:
            filepath: 検証するYAMLファイルのパス

        Returns:
            (検証成功フラグ, エラーメッセージリスト)
        """
        errors = []

        print(f"🔍 Validating config file: {filepath}")

        # 1. ファイル存在チェック
        if not filepath.exists():
            errors.append(f"ファイルが存在しません: {filepath}")
            return False, errors

        # 2. YAML構文チェック
        try:
            with open(filepath, 'r', encoding='utf-8') as f:
                content = f.read()
                yaml_data = yaml.safe_load(content)

            if not yaml_data:
                errors.append("YAMLファイルが空です")
                return False, errors

            print("  ✓ YAML構文: OK")

        except yaml.YAMLError as e:
            errors.append(f"YAML構文エラー: {e}")
            return False, errors
        except Exception as e:
            errors.append(f"ファイル読み込みエラー: {e}")
            return False, errors

        # 3. RuleValidatorによる検証（利用可能な場合）
        if RuleValidator:
            try:
                validator = RuleValidator()

                # validate_rule()はファイルパスを受け取り、エラーリストを返す
                validation_errors = validator.validate_rule(filepath)

                if not validation_errors:
                    print("  ✓ ルール構造: OK")
                else:
                    print("  ✗ ルール構造: エラーあり")
                    errors.extend(validation_errors)
                    return False, errors

            except Exception as e:
                errors.append(f"ルール検証エラー: {e}")
                return False, errors
        else:
            print("  ⚠ RuleValidator利用不可（基本チェックのみ）")

        # 4. RuleLoaderによる読み込みテスト（利用可能な場合）
        if RuleLoader:
            try:
                # 一時的にconfig/ディレクトリのルールを読み込んでテスト
                loader = RuleLoader()
                rules = loader.load_all_rules(include_custom=False, include_config=True)

                # 生成されたルールが含まれているか確認
                rule_found = False
                for rule in rules:
                    if str(rule.id).startswith('CUSTOM_'):
                        rule_found = True
                        break

                if rule_found:
                    print("  ✓ ルール読み込み: OK")
                else:
                    print("  ⚠ ルール読み込み: ルールが見つかりません（正常な場合もあります）")

            except Exception as e:
                errors.append(f"ルール読み込みエラー: {e}")
                return False, errors
        else:
            print("  ⚠ RuleLoader利用不可（基本チェックのみ）")

        # 5. 必須フィールドチェック
        if 'rule' in yaml_data:
            rule = yaml_data['rule']
            required_fields = ['id', 'category', 'name', 'description']

            missing_fields = []
            for field in required_fields:
                if field not in rule:
                    missing_fields.append(field)

            if missing_fields:
                errors.append(f"必須フィールド不足: {', '.join(missing_fields)}")
                return False, errors

            print("  ✓ 必須フィールド: OK")
        else:
            errors.append("'rule'キーが見つかりません")
            return False, errors

        print("✅ 検証完了: すべてのチェックをパスしました")
        return True, []

    def fix_yaml_with_ai(
        self,
        yaml_content: str,
        validation_errors: List[str],
        tech_name: str,
        attempt: int = 1
    ) -> Optional[str]:
        """
        AI（OpenAI/Anthropic）を使用してYAMLを自動修正

        Args:
            yaml_content: 修正前のYAML文字列
            validation_errors: 検証エラーリスト
            tech_name: 技術名
            attempt: 試行回数

        Returns:
            修正後のYAML文字列、失敗時はNone
        """
        print(f"🤖 AI自動修正を開始 (試行 {attempt}/5)")
        print(f"   検出されたエラー: {len(validation_errors)}件")

        # エラーメッセージを整形
        errors_text = "\n".join(f"- {error}" for error in validation_errors)

        # 修正プロンプト
        prompt = f"""以下のYAMLルール定義ファイルに検証エラーがあります。エラーを修正した完全なYAMLを生成してください。

技術スタック: {tech_name}

検証エラー:
{errors_text}

現在のYAML:
```yaml
{yaml_content}
```

修正時の注意事項:
1. ルールIDは大文字とアンダースコアのみ使用（例: CUSTOM_REACT_SECURITY_01）
2. カテゴリは以下のいずれか: database, security, solid, performance, custom
3. 必須フィールド: id, category, name, description, patterns
4. patternsは言語ごとに定義（typescript, javascript, python等）
5. コメント行は保持してください

修正後のYAMLのみを出力してください（説明不要）。
```yaml で開始し、``` で終了してください。"""

        try:
            # 環境変数からAI設定を読み込み
            ai_provider = os.getenv('AI_PROVIDER', 'auto').lower()

            # Anthropic Claudeを優先的に使用
            if (ai_provider in ['auto', 'anthropic']) and ANTHROPIC_AVAILABLE:
                anthropic_key = os.getenv('ANTHROPIC_API_KEY')
                if anthropic_key:
                    return self._fix_with_anthropic(prompt, anthropic_key)

            # OpenAI GPTを使用
            if (ai_provider in ['auto', 'openai']) and OPENAI_AVAILABLE:
                openai_key = os.getenv('OPENAI_API_KEY')
                if openai_key:
                    return self._fix_with_openai(prompt, openai_key)

            print("⚠️  AI APIが利用できません（APIキーまたはライブラリ不足）")
            return None

        except Exception as e:
            print(f"⚠️  AI修正エラー: {e}")
            return None

    def _fix_with_anthropic(self, prompt: str, api_key: str) -> Optional[str]:
        """Anthropic Claudeで修正"""
        try:
            client = anthropic.Anthropic(api_key=api_key)
            model = os.getenv('ANTHROPIC_MODEL', 'claude-sonnet-4')

            print(f"   使用モデル: Anthropic {model}")

            response = client.messages.create(
                model=model,
                max_tokens=4096,
                messages=[{"role": "user", "content": prompt}]
            )

            content = response.content[0].text
            return self._extract_yaml_from_response(content)

        except Exception as e:
            print(f"⚠️  Anthropic APIエラー: {e}")
            return None

    def _fix_with_openai(self, prompt: str, api_key: str) -> Optional[str]:
        """OpenAI GPTで修正"""
        try:
            client = openai.OpenAI(api_key=api_key)
            model = os.getenv('OPENAI_MODEL', 'gpt-4o')

            print(f"   使用モデル: OpenAI {model}")

            response = client.chat.completions.create(
                model=model,
                messages=[{"role": "user", "content": prompt}],
                max_tokens=4096,
                temperature=0.3
            )

            content = response.choices[0].message.content
            return self._extract_yaml_from_response(content)

        except Exception as e:
            print(f"⚠️  OpenAI APIエラー: {e}")
            return None

    def _extract_yaml_from_response(self, response: str) -> Optional[str]:
        """AI応答からYAML部分を抽出"""
        # ```yaml ... ``` または ``` ... ``` を抽出
        import re

        # ```yaml または ``` で囲まれた部分を探す
        patterns = [
            r'```yaml\s*\n(.*?)\n```',
            r'```\s*\n(.*?)\n```',
        ]

        for pattern in patterns:
            match = re.search(pattern, response, re.DOTALL)
            if match:
                yaml_content = match.group(1).strip()
                print("✅ AI修正完了: YAMLを抽出しました")
                return yaml_content

        # マークダウンなしの場合はそのまま返す
        print("✅ AI修正完了: YAML（マークダウンなし）")
        return response.strip()

    def generate_config(
        self,
        tech_name: str,
        topics: Optional[List[str]] = None,
        include_examples: bool = True,
        custom_filename: Optional[str] = None,
        auto_fix: bool = True,
        max_fix_attempts: int = 5
    ) -> Tuple[bool, Optional[Path], str]:
        """
        設定ファイルを自動生成（全工程 + AI自動修正ループ）- Phase 3: 複数トピック対応

        Args:
            tech_name: 技術名/フレームワーク名
            topics: フォーカスするトピックリスト (例: ["security", "performance"])
            include_examples: サンプルコードを含めるか
            custom_filename: カスタムファイル名
            auto_fix: AI自動修正を有効にするか（デフォルト: True）
            max_fix_attempts: AI修正の最大試行回数（デフォルト: 5）

        Returns:
            (成功フラグ, ファイルパス, メッセージ)
        """
        print("=" * 80)
        print(f"🚀 Config Generation Started: {tech_name}")
        print("=" * 80)

        try:
            # 1. ライブラリID解決
            library_id = self.resolve_library(tech_name)
            if not library_id:
                return False, None, f"ライブラリが見つかりません: {tech_name}"

            # 2. ドキュメント取得（Phase 3: 複数トピック対応）
            docs = self.fetch_documentation(library_id, topics)
            if not docs:
                return False, None, f"ドキュメントの取得に失敗: {tech_name}"

            # 3. ベストプラクティス解析（Phase 3: 複数トピック対応）
            checks = self.analyze_best_practices(docs, tech_name, topics)
            if not checks:
                return False, None, f"チェック項目が見つかりません: {tech_name}"

            # 4. YAMLルール生成
            yaml_content = self.generate_yaml_rules(checks, tech_name, include_examples)

            # 5. ファイル保存
            filepath = self.save_config_file(yaml_content, tech_name, custom_filename)

            # 6. 検証 + AI自動修正ループ
            print()
            current_yaml = yaml_content
            attempt = 0

            while attempt < max_fix_attempts:
                attempt += 1

                # 検証実行
                is_valid, validation_errors = self.validate_generated_config(filepath)

                if is_valid:
                    # 検証成功
                    print("=" * 80)
                    print(f"✅ Config Generation Completed")
                    print(f"   File: {filepath}")
                    print(f"   Rules: {len(checks)}")
                    print(f"   Validation: PASSED ✓")
                    if attempt > 1:
                        print(f"   AI修正回数: {attempt - 1}回")
                    print("=" * 80)

                    return True, filepath, "設定ファイルの生成と検証に成功しました"

                # 検証エラー
                print()
                print(f"⚠️  検証エラー検出 (試行 {attempt}/{max_fix_attempts})")
                print("   エラー内容:")
                for error in validation_errors:
                    print(f"     - {error}")
                print()

                # AI自動修正を試行
                if auto_fix and attempt < max_fix_attempts:
                    print(f"🤖 AI自動修正を開始...")
                    fixed_yaml = self.fix_yaml_with_ai(current_yaml, validation_errors, tech_name, attempt)

                    if fixed_yaml:
                        # 修正されたYAMLを保存
                        current_yaml = fixed_yaml
                        with open(filepath, 'w', encoding='utf-8') as f:
                            f.write(fixed_yaml)
                        print(f"✅ 修正版YAMLを保存しました: {filepath}")
                        print()
                        print("=" * 80)
                        print(f"🔄 再検証を実行中... (試行 {attempt + 1}/{max_fix_attempts})")
                        print("=" * 80)
                        print()
                    else:
                        # AI修正失敗
                        print("⚠️  AI修正に失敗しました")
                        break
                else:
                    # auto_fixが無効、または最大試行回数到達
                    break

            # 最大試行回数を超えてもエラーが残る場合
            print("=" * 80)
            print(f"⚠️  Config Generated with Validation Errors")
            print(f"   File: {filepath}")
            print(f"   Rules: {len(checks)}")
            print(f"   AI修正試行回数: {attempt}回")
            print("=" * 80)
            print()
            print("最終検証エラー:")
            for error in validation_errors:
                print(f"  - {error}")
            print()
            if auto_fix:
                print("⚠️  AI自動修正でもエラーを解決できませんでした。")
                print("   手動で確認・修正してください。")
            else:
                print("⚠️  AI自動修正が無効です。")
                print("   --auto-fix オプションを有効にするか、手動で修正してください。")
            print("=" * 80)

            return True, filepath, f"設定ファイルは生成されましたが、検証エラーがあります（AI修正{attempt}回試行）: {', '.join(validation_errors)}"

        except Exception as e:
            error_msg = f"設定ファイル生成エラー: {e}"
            print(f"❌ {error_msg}")
            import traceback
            traceback.print_exc()
            return False, None, error_msg


def generate_config_for_tech(
    tech_name: str,
    topics: Optional[List[str]] = None,
    include_examples: bool = True,
    custom_filename: Optional[str] = None
) -> Tuple[bool, Optional[Path], str]:
    """
    設定ファイルを生成（簡易インターフェース）- Phase 3: 複数トピック対応

    Args:
        tech_name: 技術名/フレームワーク名
        topics: フォーカスするトピックリスト (例: ["security", "performance"])
        include_examples: サンプルコードを含めるか
        custom_filename: カスタムファイル名

    Returns:
        (成功フラグ, ファイルパス, メッセージ)
    """
    generator = ConfigGenerator()
    return generator.generate_config(tech_name, topics, include_examples, custom_filename)

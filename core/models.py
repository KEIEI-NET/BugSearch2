"""
データモデル定義

技術スタック、プロジェクト設定、ルールなどの型定義
"""

from dataclasses import dataclass, field
from typing import List, Dict, Optional, Any
from pathlib import Path


@dataclass
class FrontendStack:
    """フロントエンド技術スタック"""
    framework: str  # Angular, React, Vue.js, etc.
    version: Optional[str] = None
    state_management: Optional[str] = None  # NgRx, Redux, Vuex, etc.
    routing: Optional[str] = None

    def __str__(self) -> str:
        parts = [self.framework]
        if self.version:
            parts.append(self.version)
        return " ".join(parts)


@dataclass
class BackendStack:
    """バックエンド技術スタック"""
    language: str  # Java, C#, Python, PHP, etc.
    version: Optional[str] = None
    framework: Optional[str] = None  # Spring Boot, ASP.NET Core, Laravel, etc.
    framework_version: Optional[str] = None

    def __str__(self) -> str:
        parts = [self.language]
        if self.framework:
            parts.append(f"({self.framework}")
            if self.framework_version:
                parts.append(self.framework_version)
            parts[-1] += ")"
        return " ".join(parts)


@dataclass
class DatabaseInfo:
    """データベース情報"""
    type: str  # PostgreSQL, MySQL, Cassandra, Elasticsearch, etc.
    version: Optional[str] = None
    purpose: str = "primary"  # primary, cache, search, etc.
    library: Optional[str] = None  # Spring Data JPA, Entity Framework, etc.

    def __str__(self) -> str:
        parts = [self.type]
        if self.purpose != "primary":
            parts.append(f"({self.purpose})")
        return " ".join(parts)


@dataclass
class InfrastructureInfo:
    """インフラ・ミドルウェア情報"""
    type: str  # Redis, RabbitMQ, Kafka, etc.
    category: str  # cache, messaging, etc.
    version: Optional[str] = None
    library: Optional[str] = None


@dataclass
class TechStack:
    """技術スタック全体"""
    frontend: Optional[FrontendStack] = None
    backend: Optional[BackendStack] = None
    databases: List[DatabaseInfo] = field(default_factory=list)
    cache: Optional[InfrastructureInfo] = None
    messaging: Optional[InfrastructureInfo] = None
    authentication: Optional[Dict[str, str]] = None
    practices: List[str] = field(default_factory=list)

    def all_technologies(self) -> List[str]:
        """使用している全技術のリストを返す"""
        techs = []

        if self.frontend:
            techs.append(self.frontend.framework)

        if self.backend:
            techs.append(self.backend.language)
            if self.backend.framework:
                techs.append(self.backend.framework)

        for db in self.databases:
            techs.append(db.type)

        if self.cache:
            techs.append(self.cache.type)

        if self.messaging:
            techs.append(self.messaging.type)

        return techs

    def has_technology(self, tech_name: str) -> bool:
        """特定の技術を使用しているか判定（大文字小文字無視）"""
        tech_lower = tech_name.lower()
        return any(t.lower() == tech_lower for t in self.all_technologies())

    def get_database_by_purpose(self, purpose: str) -> Optional[DatabaseInfo]:
        """用途からデータベースを取得"""
        for db in self.databases:
            if db.purpose == purpose:
                return db
        return None

    def __str__(self) -> str:
        parts = []
        if self.frontend:
            parts.append(f"Frontend: {self.frontend}")
        if self.backend:
            parts.append(f"Backend: {self.backend}")
        if self.databases:
            db_str = ", ".join(str(db) for db in self.databases)
            parts.append(f"Database: {db_str}")
        return " | ".join(parts)


@dataclass
class ProjectConfig:
    """プロジェクト設定"""
    name: str
    version: str = "1.0"
    tech_stack: TechStack = field(default_factory=TechStack)
    practices: List[str] = field(default_factory=list)

    # 解析設定
    severity_adjustments_enabled: bool = True
    custom_rules: List[str] = field(default_factory=list)
    exclude_rules: List[str] = field(default_factory=list)

    # AI分析設定
    ai_include_tech_stack: bool = True
    ai_context_depth: str = "standard"  # minimal, standard, detailed

    @classmethod
    def from_dict(cls, data: dict) -> 'ProjectConfig':
        """辞書からProjectConfigを生成"""
        project_data = data.get('project', {})
        tech_stack_data = data.get('tech_stack', {})
        analysis_data = data.get('analysis', {})

        # TechStackの構築
        tech_stack = cls._build_tech_stack(tech_stack_data)

        # ProjectConfigの生成
        return cls(
            name=project_data.get('name', 'Unknown Project'),
            version=project_data.get('version', '1.0'),
            tech_stack=tech_stack,
            practices=data.get('practices', []),
            severity_adjustments_enabled=analysis_data.get('severity_adjustments', {}).get('enabled', True),
            custom_rules=analysis_data.get('custom_rules', []),
            exclude_rules=analysis_data.get('exclude_rules', []),
            ai_include_tech_stack=analysis_data.get('ai_analysis', {}).get('include_tech_stack', True),
            ai_context_depth=analysis_data.get('ai_analysis', {}).get('context_depth', 'standard'),
        )

    @staticmethod
    def _build_tech_stack(data: dict) -> TechStack:
        """辞書からTechStackを構築"""
        # Frontend
        frontend = None
        if 'frontend' in data and data['frontend']:
            frontend_data = data['frontend']
            frontend = FrontendStack(
                framework=frontend_data.get('framework', ''),
                version=frontend_data.get('version'),
                state_management=frontend_data.get('state_management'),
                routing=frontend_data.get('routing'),
            )

        # Backend
        backend = None
        if 'backend' in data and data['backend']:
            backend_data = data['backend']
            backend = BackendStack(
                language=backend_data.get('language', ''),
                version=backend_data.get('version'),
                framework=backend_data.get('framework'),
                framework_version=backend_data.get('framework_version'),
            )

        # Databases
        databases = []
        if 'databases' in data:
            for db_data in data['databases']:
                databases.append(DatabaseInfo(
                    type=db_data.get('type', ''),
                    version=db_data.get('version'),
                    purpose=db_data.get('purpose', 'primary'),
                    library=db_data.get('library'),
                ))

        # Cache
        cache = None
        if 'cache' in data and data['cache']:
            cache_data = data['cache']
            cache = InfrastructureInfo(
                type=cache_data.get('type', ''),
                category='cache',
                version=cache_data.get('version'),
                library=cache_data.get('library'),
            )

        # Messaging
        messaging = None
        if 'messaging' in data and data['messaging']:
            msg_data = data['messaging']
            messaging = InfrastructureInfo(
                type=msg_data.get('type', ''),
                category='messaging',
                version=msg_data.get('version'),
                library=msg_data.get('library'),
            )

        return TechStack(
            frontend=frontend,
            backend=backend,
            databases=databases,
            cache=cache,
            messaging=messaging,
            authentication=data.get('authentication'),
            practices=data.get('practices', []),
        )


@dataclass
class RulePattern:
    """ルールの検出パターン"""
    pattern: str  # 正規表現パターン
    context: str  # パターンの説明
    language: str  # 対象言語


@dataclass
class ContextModifier:
    """技術スタックに基づく深刻度修飾子"""
    condition: Dict[str, Any]  # マッチング条件
    severity_adjustment: int  # 深刻度の調整値（-10 ~ +10）
    note: Optional[str] = None  # 追加メッセージ


@dataclass
class RuleCategory:
    """ルールカテゴリ（複数ルールの集合）"""
    name: str  # database, security, solid, performance
    rules: List['Rule'] = field(default_factory=list)
    total_detections: int = 0

    def add_detection(self, count: int = 1):
        """検出数を追加"""
        self.total_detections += count

    def get_highest_severity(self) -> int:
        """カテゴリ内の最高深刻度を取得"""
        if not self.rules:
            return 0
        return max(rule.base_severity for rule in self.rules)

    def __str__(self) -> str:
        return f"{self.name} ({len(self.rules)} rules)"


@dataclass
class Rule:
    """解析ルール"""
    id: str
    category: str  # database, security, performance, etc.
    name: str
    description: str
    base_severity: int  # 基本深刻度（1-10）
    patterns: Dict[str, List[RulePattern]] = field(default_factory=dict)
    context_modifiers: List[ContextModifier] = field(default_factory=list)
    fixes: Dict[str, List[str]] = field(default_factory=dict)

    def get_patterns_for_language(self, language: str) -> List[RulePattern]:
        """指定言語のパターンを取得"""
        return self.patterns.get(language, [])

    def evaluate_severity(
        self,
        tech_stack: TechStack,
        code_context: str = ""
    ) -> tuple[int, List[str]]:
        """
        技術スタックとコードコンテキストに基づいて深刻度を評価

        Returns:
            (調整後の深刻度, 追加ノートのリスト)
        """
        severity = self.base_severity
        notes = []

        for modifier in self.context_modifiers:
            if self._matches_condition(modifier.condition, tech_stack, code_context):
                severity += modifier.severity_adjustment
                if modifier.note:
                    notes.append(modifier.note)

        # 深刻度を1-10の範囲に制限
        severity = max(1, min(10, severity))

        return severity, notes

    def _matches_condition(
        self,
        condition: Dict[str, Any],
        tech_stack: TechStack,
        code_context: str
    ) -> bool:
        """条件がマッチするか判定"""
        import re

        # 技術スタックの条件
        if 'tech_stack_has' in condition:
            tech_condition = condition['tech_stack_has']

            # 簡単な文字列マッチング
            # 例: "Elasticsearch" が技術スタックに含まれるか
            if not tech_stack.has_technology(tech_condition):
                return False

        # コードコンテキストの条件
        if 'code_context' in condition:
            pattern = condition['code_context']
            if not re.search(pattern, code_context, re.IGNORECASE):
                return False

        return True

    def get_relevant_fixes(self, tech_stack: TechStack) -> List[str]:
        """技術スタックに応じた修正方法を返す"""
        # フレームワーク固有の修正方法
        if tech_stack.backend and tech_stack.backend.framework:
            framework = tech_stack.backend.framework.lower().replace(' ', '_')
            if framework in self.fixes:
                return self.fixes[framework]

        # ORMライブラリ固有の修正方法
        for db in tech_stack.databases:
            if db.library:
                library_key = db.library.lower().replace(' ', '_')
                if library_key in self.fixes:
                    return self.fixes[library_key]

        # デフォルトの修正方法
        return self.fixes.get('default', [])

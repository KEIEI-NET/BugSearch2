"""
技術スタック自動検出エンジン

プロジェクトディレクトリをスキャンして技術スタックを自動検出
"""

import json
import re
import xml.etree.ElementTree as ET
import yaml
from pathlib import Path
from typing import Optional, Dict, List, Tuple
from dataclasses import dataclass

from .models import (
    TechStack,
    FrontendStack,
    BackendStack,
    DatabaseInfo,
    InfrastructureInfo
)


@dataclass
class DetectionResult:
    """検出結果"""
    tech_stack: TechStack
    confidence: float  # 0.0-1.0
    detected_files: List[str]
    warnings: List[str]


class TechStackDetector:
    """技術スタック自動検出エンジン"""

    def __init__(self, project_dir: str = "."):
        """
        初期化

        Args:
            project_dir: プロジェクトルートディレクトリ
        """
        self.project_dir = Path(project_dir)
        self.detected_files = []
        self.warnings = []

    def detect(self) -> DetectionResult:
        """
        技術スタックを自動検出

        Returns:
            DetectionResult: 検出結果
        """
        tech_stack = TechStack()

        # フロントエンド検出
        frontend = self._detect_frontend()
        if frontend:
            tech_stack.frontend = frontend

        # バックエンド検出
        backend = self._detect_backend()
        if backend:
            tech_stack.backend = backend

        # データベース検出
        databases = self._detect_databases()
        if databases:
            tech_stack.databases = databases

        # キャッシュ検出
        cache = self._detect_cache()
        if cache:
            tech_stack.cache = cache

        # メッセージング検出
        messaging = self._detect_messaging()
        if messaging:
            tech_stack.messaging = messaging

        # プラクティス検出
        practices = self._detect_practices()
        if practices:
            tech_stack.practices = practices

        # 信頼度計算
        confidence = self._calculate_confidence()

        return DetectionResult(
            tech_stack=tech_stack,
            confidence=confidence,
            detected_files=self.detected_files,
            warnings=self.warnings
        )

    def _detect_frontend(self) -> Optional[FrontendStack]:
        """フロントエンド技術を検出"""
        # package.jsonから検出
        package_json = self.project_dir / "package.json"
        if package_json.exists():
            try:
                with open(package_json, 'r', encoding='utf-8') as f:
                    data = json.load(f)
                    self.detected_files.append(str(package_json))

                dependencies = {**data.get('dependencies', {}), **data.get('devDependencies', {})}

                # Angular検出
                if '@angular/core' in dependencies:
                    version = dependencies.get('@angular/core', '').replace('^', '').replace('~', '')
                    state_mgmt = self._detect_angular_state_management(dependencies)
                    return FrontendStack(
                        framework="Angular",
                        version=version,
                        state_management=state_mgmt
                    )

                # React検出
                if 'react' in dependencies:
                    version = dependencies.get('react', '').replace('^', '').replace('~', '')
                    state_mgmt = self._detect_react_state_management(dependencies)
                    return FrontendStack(
                        framework="React",
                        version=version,
                        state_management=state_mgmt
                    )

                # Vue.js検出
                if 'vue' in dependencies:
                    version = dependencies.get('vue', '').replace('^', '').replace('~', '')
                    state_mgmt = self._detect_vue_state_management(dependencies)
                    return FrontendStack(
                        framework="Vue.js",
                        version=version,
                        state_management=state_mgmt
                    )

                # Svelte検出
                if 'svelte' in dependencies:
                    version = dependencies.get('svelte', '').replace('^', '').replace('~', '')
                    return FrontendStack(
                        framework="Svelte",
                        version=version
                    )

            except Exception as e:
                self.warnings.append(f"package.json解析エラー: {e}")

        # angular.jsonから検出
        angular_json = self.project_dir / "angular.json"
        if angular_json.exists():
            self.detected_files.append(str(angular_json))
            return FrontendStack(framework="Angular")

        return None

    def _detect_angular_state_management(self, dependencies: Dict) -> Optional[str]:
        """Angular状態管理ライブラリを検出"""
        if '@ngrx/store' in dependencies:
            return "NgRx"
        if '@datorama/akita' in dependencies:
            return "Akita"
        return None

    def _detect_react_state_management(self, dependencies: Dict) -> Optional[str]:
        """React状態管理ライブラリを検出"""
        if 'redux' in dependencies or 'react-redux' in dependencies:
            return "Redux"
        if 'mobx' in dependencies or 'mobx-react' in dependencies:
            return "MobX"
        if 'zustand' in dependencies:
            return "Zustand"
        return None

    def _detect_vue_state_management(self, dependencies: Dict) -> Optional[str]:
        """Vue状態管理ライブラリを検出"""
        if 'vuex' in dependencies:
            return "Vuex"
        if 'pinia' in dependencies:
            return "Pinia"
        return None

    def _detect_backend(self) -> Optional[BackendStack]:
        """バックエンド技術を検出"""
        # .NET検出 (*.csproj)
        csproj_files = list(self.project_dir.rglob("*.csproj"))
        if csproj_files:
            backend = self._detect_dotnet_backend(csproj_files[0])
            if backend:
                return backend

        # Java検出 (pom.xml)
        pom_xml = self.project_dir / "pom.xml"
        if pom_xml.exists():
            backend = self._detect_java_backend(pom_xml)
            if backend:
                return backend

        # Python検出 (requirements.txt)
        requirements_txt = self.project_dir / "requirements.txt"
        if requirements_txt.exists():
            backend = self._detect_python_backend(requirements_txt)
            if backend:
                return backend

        # PHP検出 (composer.json)
        composer_json = self.project_dir / "composer.json"
        if composer_json.exists():
            backend = self._detect_php_backend(composer_json)
            if backend:
                return backend

        # Go検出 (go.mod)
        go_mod = self.project_dir / "go.mod"
        if go_mod.exists():
            backend = self._detect_go_backend(go_mod)
            if backend:
                return backend

        # Node.js検出 (package.json)
        package_json = self.project_dir / "package.json"
        if package_json.exists():
            backend = self._detect_nodejs_backend(package_json)
            if backend:
                return backend

        return None

    def _detect_dotnet_backend(self, csproj_file: Path) -> Optional[BackendStack]:
        """.NETバックエンドを検出"""
        try:
            self.detected_files.append(str(csproj_file))
            tree = ET.parse(csproj_file)
            root = tree.getroot()

            # TargetFrameworkから.NETバージョンを取得
            target_framework = root.find(".//TargetFramework")
            version = None
            framework = None

            if target_framework is not None:
                tf_text = target_framework.text
                if tf_text:
                    # net8.0 → .NET 8.0
                    if tf_text.startswith('net') and '.' in tf_text:
                        version = tf_text.replace('net', '').replace('.0', '')
                        framework = "ASP.NET Core"
                    # netcoreapp3.1 → .NET Core 3.1
                    elif tf_text.startswith('netcoreapp'):
                        version = tf_text.replace('netcoreapp', '')
                        framework = "ASP.NET Core"
                    # net48 → .NET Framework 4.8
                    elif tf_text.startswith('net4'):
                        version = tf_text.replace('net', '').replace('4', '4.')
                        framework = "ASP.NET Framework"

            # PackageReferenceからフレームワーク検出
            for package_ref in root.findall(".//PackageReference"):
                package_name = package_ref.get('Include', '')
                if 'Microsoft.AspNetCore' in package_name:
                    framework = "ASP.NET Core"
                    break

            return BackendStack(
                language="C#",
                version=version,
                framework=framework,
                framework_version=version if framework else None
            )

        except Exception as e:
            self.warnings.append(f".csproj解析エラー: {e}")
            return BackendStack(language="C#")

    def _detect_java_backend(self, pom_xml: Path) -> Optional[BackendStack]:
        """Javaバックエンドを検出"""
        try:
            self.detected_files.append(str(pom_xml))
            tree = ET.parse(pom_xml)
            root = tree.getroot()

            # 名前空間を考慮
            ns = {'maven': 'http://maven.apache.org/POM/4.0.0'}

            # Javaバージョン検出
            java_version = None
            for version_tag in ['maven.compiler.source', 'java.version']:
                version_elem = root.find(f".//maven:properties/maven:{version_tag}", ns)
                if version_elem is not None and version_elem.text:
                    java_version = version_elem.text
                    break

            # フレームワーク検出
            framework = None
            framework_version = None

            for dependency in root.findall(".//maven:dependency", ns):
                artifact_id = dependency.find("maven:artifactId", ns)
                version = dependency.find("maven:version", ns)

                if artifact_id is not None:
                    artifact_text = artifact_id.text or ""

                    if "spring-boot" in artifact_text:
                        framework = "Spring Boot"
                        if version is not None:
                            framework_version = version.text
                        break
                    elif "quarkus" in artifact_text:
                        framework = "Quarkus"
                        if version is not None:
                            framework_version = version.text
                        break
                    elif "micronaut" in artifact_text:
                        framework = "Micronaut"
                        if version is not None:
                            framework_version = version.text
                        break

            return BackendStack(
                language="Java",
                version=java_version,
                framework=framework,
                framework_version=framework_version
            )

        except Exception as e:
            self.warnings.append(f"pom.xml解析エラー: {e}")
            return BackendStack(language="Java")

    def _detect_python_backend(self, requirements_txt: Path) -> Optional[BackendStack]:
        """Pythonバックエンドを検出"""
        try:
            self.detected_files.append(str(requirements_txt))
            with open(requirements_txt, 'r', encoding='utf-8') as f:
                content = f.read()

            framework = None
            framework_version = None

            # Djangoを検出
            django_match = re.search(r'Django([=><]+)([\d.]+)', content, re.IGNORECASE)
            if django_match:
                framework = "Django"
                framework_version = django_match.group(2)
            # FastAPIを検出
            elif re.search(r'fastapi', content, re.IGNORECASE):
                fastapi_match = re.search(r'fastapi([=><]+)([\d.]+)', content, re.IGNORECASE)
                framework = "FastAPI"
                if fastapi_match:
                    framework_version = fastapi_match.group(2)
            # Flaskを検出
            elif re.search(r'flask', content, re.IGNORECASE):
                flask_match = re.search(r'flask([=><]+)([\d.]+)', content, re.IGNORECASE)
                framework = "Flask"
                if flask_match:
                    framework_version = flask_match.group(2)

            return BackendStack(
                language="Python",
                framework=framework,
                framework_version=framework_version
            )

        except Exception as e:
            self.warnings.append(f"requirements.txt解析エラー: {e}")
            return BackendStack(language="Python")

    def _detect_php_backend(self, composer_json: Path) -> Optional[BackendStack]:
        """PHPバックエンドを検出"""
        try:
            self.detected_files.append(str(composer_json))
            with open(composer_json, 'r', encoding='utf-8') as f:
                data = json.load(f)

            require = data.get('require', {})
            php_version = require.get('php', '').replace('^', '').replace('~', '')

            framework = None
            framework_version = None

            if 'laravel/framework' in require:
                framework = "Laravel"
                framework_version = require.get('laravel/framework', '').replace('^', '').replace('~', '')
            elif 'symfony/symfony' in require or 'symfony/framework-bundle' in require:
                framework = "Symfony"
                framework_version = require.get('symfony/symfony', require.get('symfony/framework-bundle', '')).replace('^', '').replace('~', '')

            return BackendStack(
                language="PHP",
                version=php_version,
                framework=framework,
                framework_version=framework_version
            )

        except Exception as e:
            self.warnings.append(f"composer.json解析エラー: {e}")
            return BackendStack(language="PHP")

    def _detect_go_backend(self, go_mod: Path) -> Optional[BackendStack]:
        """Goバックエンドを検出"""
        try:
            self.detected_files.append(str(go_mod))
            with open(go_mod, 'r', encoding='utf-8') as f:
                content = f.read()

            # Goバージョン検出
            go_version_match = re.search(r'go\s+([\d.]+)', content)
            go_version = go_version_match.group(1) if go_version_match else None

            framework = None
            # Ginを検出
            if 'github.com/gin-gonic/gin' in content:
                framework = "Gin"
            # Echoを検出
            elif 'github.com/labstack/echo' in content:
                framework = "Echo"

            return BackendStack(
                language="Go",
                version=go_version,
                framework=framework
            )

        except Exception as e:
            self.warnings.append(f"go.mod解析エラー: {e}")
            return BackendStack(language="Go")

    def _detect_nodejs_backend(self, package_json: Path) -> Optional[BackendStack]:
        """Node.jsバックエンドを検出"""
        try:
            with open(package_json, 'r', encoding='utf-8') as f:
                data = json.load(f)

            dependencies = {**data.get('dependencies', {}), **data.get('devDependencies', {})}

            # Node.jsバージョン
            node_version = data.get('engines', {}).get('node', '').replace('^', '').replace('~', '')

            framework = None
            framework_version = None

            # フレームワーク検出
            if 'express' in dependencies:
                framework = "Express"
                framework_version = dependencies.get('express', '').replace('^', '').replace('~', '')
            elif '@nestjs/core' in dependencies:
                framework = "NestJS"
                framework_version = dependencies.get('@nestjs/core', '').replace('^', '').replace('~', '')
            elif 'fastify' in dependencies:
                framework = "Fastify"
                framework_version = dependencies.get('fastify', '').replace('^', '').replace('~', '')

            # バックエンドフレームワークが検出された場合のみNode.jsバックエンドとして返す
            if framework:
                return BackendStack(
                    language="Node.js",
                    version=node_version,
                    framework=framework,
                    framework_version=framework_version
                )

        except Exception as e:
            self.warnings.append(f"package.json(Node.js)解析エラー: {e}")

        return None

    def _detect_databases(self) -> List[DatabaseInfo]:
        """データベースを検出"""
        databases = []

        # docker-compose.ymlから検出
        docker_compose = self.project_dir / "docker-compose.yml"
        if docker_compose.exists():
            dbs_from_docker = self._detect_databases_from_docker(docker_compose)
            databases.extend(dbs_from_docker)

        # 設定ファイルから検出
        dbs_from_config = self._detect_databases_from_config()
        databases.extend(dbs_from_config)

        # 重複削除
        unique_dbs = []
        seen_types = set()
        for db in databases:
            if db.type not in seen_types:
                unique_dbs.append(db)
                seen_types.add(db.type)

        return unique_dbs

    def _detect_databases_from_docker(self, docker_compose: Path) -> List[DatabaseInfo]:
        """docker-compose.ymlからデータベースを検出"""
        databases = []
        try:
            self.detected_files.append(str(docker_compose))
            with open(docker_compose, 'r', encoding='utf-8') as f:
                data = yaml.safe_load(f)

            services = data.get('services', {})
            purpose_counter = 0

            for service_name, service_config in services.items():
                image = service_config.get('image', '')

                db_type = None
                if 'postgres' in image.lower():
                    db_type = "PostgreSQL"
                elif 'mysql' in image.lower():
                    db_type = "MySQL"
                elif 'sqlserver' in image.lower() or 'mssql' in image.lower():
                    db_type = "SQL Server"
                elif 'mongo' in image.lower():
                    db_type = "MongoDB"
                elif 'cassandra' in image.lower():
                    db_type = "Cassandra"
                elif 'elasticsearch' in image.lower():
                    db_type = "Elasticsearch"

                if db_type:
                    purpose = "primary" if purpose_counter == 0 else "secondary"
                    if db_type == "Elasticsearch":
                        purpose = "search"

                    databases.append(DatabaseInfo(
                        type=db_type,
                        purpose=purpose
                    ))
                    purpose_counter += 1

        except Exception as e:
            self.warnings.append(f"docker-compose.yml解析エラー: {e}")

        return databases

    def _detect_databases_from_config(self) -> List[DatabaseInfo]:
        """設定ファイルからデータベースを検出"""
        databases = []

        # Elasticsearch設定ファイル検出
        es_detected = self._detect_elasticsearch_config()
        if es_detected:
            databases.append(es_detected)

        # Cassandra設定ファイル検出
        cassandra_detected = self._detect_cassandra_config()
        if cassandra_detected:
            databases.append(cassandra_detected)

        # appsettings.json (.NET)
        appsettings = self.project_dir / "appsettings.json"
        if appsettings.exists():
            try:
                self.detected_files.append(str(appsettings))
                with open(appsettings, 'r', encoding='utf-8') as f:
                    data = json.load(f)

                conn_strings = data.get('ConnectionStrings', {})
                for conn_name, conn_string in conn_strings.items():
                    if 'Server=' in conn_string or 'Data Source=' in conn_string:
                        if 'sqlserver' in conn_string.lower() or '1433' in conn_string:
                            databases.append(DatabaseInfo(type="SQL Server", purpose="primary"))
                        elif 'postgres' in conn_string.lower() or '5432' in conn_string:
                            databases.append(DatabaseInfo(type="PostgreSQL", purpose="primary"))
                        elif 'mysql' in conn_string.lower() or '3306' in conn_string:
                            databases.append(DatabaseInfo(type="MySQL", purpose="primary"))

            except Exception as e:
                self.warnings.append(f"appsettings.json解析エラー: {e}")

        return databases

    def _detect_elasticsearch_config(self) -> Optional[DatabaseInfo]:
        """Elasticsearch設定ファイルを検出

        検索パス:
        - config/elasticsearch.yml
        - config/elasticsearch/elasticsearch.yml
        - elasticsearch.yml
        - .elasticsearch/elasticsearch.yml
        """
        es_config_paths = [
            self.project_dir / "config" / "elasticsearch.yml",
            self.project_dir / "config" / "elasticsearch" / "elasticsearch.yml",
            self.project_dir / "elasticsearch.yml",
            self.project_dir / ".elasticsearch" / "elasticsearch.yml",
        ]

        for config_path in es_config_paths:
            if config_path.exists():
                try:
                    self.detected_files.append(str(config_path))
                    with open(config_path, 'r', encoding='utf-8') as f:
                        content = f.read()

                    # Elasticsearch設定ファイルの特徴的なキーワードで検証
                    if any(keyword in content for keyword in [
                        'cluster.name',
                        'node.name',
                        'path.data',
                        'path.logs',
                        'network.host',
                        'http.port',
                        'discovery.seed_hosts'
                    ]):
                        return DatabaseInfo(type="Elasticsearch", purpose="search")

                except Exception as e:
                    self.warnings.append(f"elasticsearch.yml解析エラー: {e}")

        return None

    def _detect_cassandra_config(self) -> Optional[DatabaseInfo]:
        """Cassandra設定ファイルを検出

        検索パス:
        - config/cassandra.yaml
        - config/cassandra/cassandra.yaml
        - cassandra.yaml
        - .cassandra/cassandra.yaml
        """
        cassandra_config_paths = [
            self.project_dir / "config" / "cassandra.yaml",
            self.project_dir / "config" / "cassandra" / "cassandra.yaml",
            self.project_dir / "cassandra.yaml",
            self.project_dir / ".cassandra" / "cassandra.yaml",
        ]

        for config_path in cassandra_config_paths:
            if config_path.exists():
                try:
                    self.detected_files.append(str(config_path))
                    with open(config_path, 'r', encoding='utf-8') as f:
                        content = f.read()

                    # Cassandra設定ファイルの特徴的なキーワードで検証
                    if any(keyword in content for keyword in [
                        'cluster_name',
                        'seed_provider',
                        'listen_address',
                        'rpc_address',
                        'commitlog_directory',
                        'data_file_directories',
                        'saved_caches_directory'
                    ]):
                        return DatabaseInfo(type="Cassandra", purpose="primary")

                except Exception as e:
                    self.warnings.append(f"cassandra.yaml解析エラー: {e}")

        return None

    def _detect_cache(self) -> Optional[InfrastructureInfo]:
        """キャッシュシステムを検出"""
        # docker-compose.ymlから検出
        docker_compose = self.project_dir / "docker-compose.yml"
        if docker_compose.exists():
            try:
                with open(docker_compose, 'r', encoding='utf-8') as f:
                    data = yaml.safe_load(f)

                services = data.get('services', {})
                for service_name, service_config in services.items():
                    image = service_config.get('image', '')

                    if 'redis' in image.lower():
                        return InfrastructureInfo(type="Redis", category="cache")
                    elif 'memcached' in image.lower():
                        return InfrastructureInfo(type="Memcached", category="cache")

            except Exception as e:
                self.warnings.append(f"docker-compose.yml(cache)解析エラー: {e}")

        return None

    def _detect_messaging(self) -> Optional[InfrastructureInfo]:
        """メッセージングシステムを検出"""
        # docker-compose.ymlから検出
        docker_compose = self.project_dir / "docker-compose.yml"
        if docker_compose.exists():
            try:
                with open(docker_compose, 'r', encoding='utf-8') as f:
                    data = yaml.safe_load(f)

                services = data.get('services', {})
                for service_name, service_config in services.items():
                    image = service_config.get('image', '')

                    if 'rabbitmq' in image.lower():
                        return InfrastructureInfo(type="RabbitMQ", category="messaging")
                    elif 'kafka' in image.lower():
                        return InfrastructureInfo(type="Kafka", category="messaging")

            except Exception as e:
                self.warnings.append(f"docker-compose.yml(messaging)解析エラー: {e}")

        return None

    def _detect_practices(self) -> List[str]:
        """開発プラクティスを検出"""
        practices = []

        # ディレクトリ構造から推測
        if (self.project_dir / "src" / "repositories").exists():
            practices.append("Repository Pattern")

        if (self.project_dir / "src" / "commands").exists() and (self.project_dir / "src" / "queries").exists():
            practices.append("CQRS")

        if (self.project_dir / "src" / "domain").exists():
            practices.append("Domain-Driven Design")

        # docker-composeで複数サービスがある場合
        docker_compose = self.project_dir / "docker-compose.yml"
        if docker_compose.exists():
            try:
                with open(docker_compose, 'r', encoding='utf-8') as f:
                    data = yaml.safe_load(f)
                    services = data.get('services', {})
                    if len(services) > 3:  # 複数のサービスがある
                        practices.append("Microservices")
            except:
                pass

        return practices

    def _calculate_confidence(self) -> float:
        """検出結果の信頼度を計算"""
        if not self.detected_files:
            return 0.0

        # 検出ファイル数に基づく信頼度
        confidence = min(len(self.detected_files) * 0.2, 1.0)

        # 警告がある場合は信頼度を下げる
        if self.warnings:
            confidence *= 0.8

        return confidence


def auto_detect_tech_stack(project_dir: str = ".") -> DetectionResult:
    """
    技術スタックを自動検出（簡易インターフェース）

    Args:
        project_dir: プロジェクトディレクトリ

    Returns:
        DetectionResult: 検出結果
    """
    detector = TechStackDetector(project_dir)
    return detector.detect()

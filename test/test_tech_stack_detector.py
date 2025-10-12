"""
技術スタック自動検出エンジンのテスト

Phase 2で実装した自動検出機能のテスト
"""

import sys
import json
from pathlib import Path

# プロジェクトルートをパスに追加
sys.path.insert(0, str(Path(__file__).parent.parent))

from core.tech_stack_detector import TechStackDetector, auto_detect_tech_stack


def test_nodejs_detection():
    """Node.js/Angularプロジェクトの検出テスト"""
    print("=" * 80)
    print("テスト1: Node.js/Angular検出")
    print("=" * 80)

    # テスト用package.jsonを作成
    test_dir = Path("test/samples/nodejs_project")
    test_dir.mkdir(parents=True, exist_ok=True)

    package_json = test_dir / "package.json"
    package_data = {
        "name": "test-angular-app",
        "version": "1.0.0",
        "dependencies": {
            "@angular/core": "^17.0.0",
            "@angular/common": "^17.0.0",
            "@ngrx/store": "^17.0.0",
            "express": "^4.18.0"
        },
        "engines": {
            "node": ">=18.0.0"
        }
    }

    with open(package_json, 'w', encoding='utf-8') as f:
        json.dump(package_data, f, indent=2)

    # 検出実行
    result = auto_detect_tech_stack(str(test_dir))

    print(f"信頼度: {result.confidence * 100:.0f}%")
    print(f"検出ファイル数: {len(result.detected_files)}")
    print()

    # フロントエンド検証
    if result.tech_stack.frontend:
        print(f"[OK] フロントエンド検出: {result.tech_stack.frontend.framework}")
        print(f"     バージョン: {result.tech_stack.frontend.version}")
        print(f"     状態管理: {result.tech_stack.frontend.state_management}")
    else:
        print("[ERROR] フロントエンドが検出されませんでした")

    # バックエンド検証
    if result.tech_stack.backend:
        print(f"[OK] バックエンド検出: {result.tech_stack.backend.language}")
        print(f"     フレームワーク: {result.tech_stack.backend.framework}")
    else:
        print("[WARNING] バックエンドが検出されませんでした")

    # クリーンアップ
    package_json.unlink()

    return result.tech_stack.frontend is not None


def test_dotnet_detection():
    """.NETプロジェクトの検出テスト"""
    print()
    print("=" * 80)
    print("テスト2: .NET検出")
    print("=" * 80)

    # テスト用.csprojファイルを作成
    test_dir = Path("test/samples/dotnet_project")
    test_dir.mkdir(parents=True, exist_ok=True)

    csproj_file = test_dir / "TestApp.csproj"
    csproj_content = """<Project Sdk="Microsoft.NET.Sdk.Web">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.Mvc" Version="8.0.0" />
  </ItemGroup>
</Project>"""

    with open(csproj_file, 'w', encoding='utf-8') as f:
        f.write(csproj_content)

    # 検出実行
    result = auto_detect_tech_stack(str(test_dir))

    print(f"信頼度: {result.confidence * 100:.0f}%")
    print(f"検出ファイル数: {len(result.detected_files)}")
    print()

    # バックエンド検証
    if result.tech_stack.backend:
        print(f"[OK] バックエンド検出: {result.tech_stack.backend.language}")
        print(f"     バージョン: {result.tech_stack.backend.version}")
        print(f"     フレームワーク: {result.tech_stack.backend.framework}")
    else:
        print("[ERROR] バックエンドが検出されませんでした")

    # クリーンアップ
    csproj_file.unlink()

    return result.tech_stack.backend is not None


def test_java_detection():
    """Javaプロジェクトの検出テスト"""
    print()
    print("=" * 80)
    print("テスト3: Java/Spring Boot検出")
    print("=" * 80)

    # テスト用pom.xmlを作成
    test_dir = Path("test/samples/java_project")
    test_dir.mkdir(parents=True, exist_ok=True)

    pom_xml = test_dir / "pom.xml"
    pom_content = """<?xml version="1.0" encoding="UTF-8"?>
<project xmlns="http://maven.apache.org/POM/4.0.0">
  <modelVersion>4.0.0</modelVersion>
  <groupId>com.example</groupId>
  <artifactId>test-app</artifactId>
  <version>1.0.0</version>
  <properties>
    <java.version>17</java.version>
  </properties>
  <dependencies>
    <dependency>
      <groupId>org.springframework.boot</groupId>
      <artifactId>spring-boot-starter-web</artifactId>
      <version>3.2.0</version>
    </dependency>
  </dependencies>
</project>"""

    with open(pom_xml, 'w', encoding='utf-8') as f:
        f.write(pom_content)

    # 検出実行
    result = auto_detect_tech_stack(str(test_dir))

    print(f"信頼度: {result.confidence * 100:.0f}%")
    print(f"検出ファイル数: {len(result.detected_files)}")
    print()

    # バックエンド検証
    if result.tech_stack.backend:
        print(f"[OK] バックエンド検出: {result.tech_stack.backend.language}")
        print(f"     Javaバージョン: {result.tech_stack.backend.version}")
        print(f"     フレームワーク: {result.tech_stack.backend.framework}")
        print(f"     フレームワークバージョン: {result.tech_stack.backend.framework_version}")
    else:
        print("[ERROR] バックエンドが検出されませんでした")

    # クリーンアップ
    pom_xml.unlink()

    return result.tech_stack.backend is not None


def test_docker_compose_detection():
    """docker-composeからのDB/インフラ検出テスト"""
    print()
    print("=" * 80)
    print("テスト4: docker-compose.yml からDB/インフラ検出")
    print("=" * 80)

    # テスト用docker-compose.ymlを作成
    test_dir = Path("test/samples/docker_project")
    test_dir.mkdir(parents=True, exist_ok=True)

    docker_compose = test_dir / "docker-compose.yml"
    docker_content = """version: '3.8'
services:
  db:
    image: postgres:15
    environment:
      POSTGRES_PASSWORD: secret

  cache:
    image: redis:7-alpine

  search:
    image: elasticsearch:8.11.0

  messaging:
    image: rabbitmq:3-management
"""

    with open(docker_compose, 'w', encoding='utf-8') as f:
        f.write(docker_content)

    # 検出実行
    result = auto_detect_tech_stack(str(test_dir))

    print(f"信頼度: {result.confidence * 100:.0f}%")
    print(f"検出ファイル数: {len(result.detected_files)}")
    print()

    # データベース検証
    if result.tech_stack.databases:
        print(f"[OK] データベース検出: {len(result.tech_stack.databases)}件")
        for db in result.tech_stack.databases:
            print(f"     - {db.type} ({db.purpose})")
    else:
        print("[ERROR] データベースが検出されませんでした")

    # キャッシュ検証
    if result.tech_stack.cache:
        print(f"[OK] キャッシュ検出: {result.tech_stack.cache.type}")
    else:
        print("[WARNING] キャッシュが検出されませんでした")

    # メッセージング検証
    if result.tech_stack.messaging:
        print(f"[OK] メッセージング検出: {result.tech_stack.messaging.type}")
    else:
        print("[WARNING] メッセージングが検出されませんでした")

    # クリーンアップ
    docker_compose.unlink()

    return len(result.tech_stack.databases) > 0


def test_elasticsearch_config_detection():
    """elasticsearch.yml検出テスト"""
    print()
    print("=" * 80)
    print("テスト5: elasticsearch.yml からElasticsearch検出")
    print("=" * 80)

    # テスト用elasticsearch.ymlを作成
    test_dir = Path("test/samples/elasticsearch_project")
    config_dir = test_dir / "config"
    config_dir.mkdir(parents=True, exist_ok=True)

    es_config = config_dir / "elasticsearch.yml"
    es_content = """# Elasticsearch Configuration
cluster.name: my-application
node.name: node-1
path.data: /var/lib/elasticsearch
path.logs: /var/log/elasticsearch
network.host: 0.0.0.0
http.port: 9200
discovery.seed_hosts: ["host1", "host2"]
cluster.initial_master_nodes: ["node-1"]
"""

    with open(es_config, 'w', encoding='utf-8') as f:
        f.write(es_content)

    # 検出実行
    result = auto_detect_tech_stack(str(test_dir))

    print(f"信頼度: {result.confidence * 100:.0f}%")
    print(f"検出ファイル数: {len(result.detected_files)}")
    print()

    # Elasticsearch検証
    es_found = False
    if result.tech_stack.databases:
        for db in result.tech_stack.databases:
            if db.type == "Elasticsearch":
                print(f"[OK] Elasticsearch検出: {db.type} ({db.purpose})")
                print(f"     検出ファイル: {es_config}")
                es_found = True
                break

    if not es_found:
        print("[ERROR] Elasticsearchが検出されませんでした")

    # クリーンアップ
    es_config.unlink()
    config_dir.rmdir()
    test_dir.rmdir()

    return es_found


def test_cassandra_config_detection():
    """cassandra.yaml検出テスト"""
    print()
    print("=" * 80)
    print("テスト6: cassandra.yaml からCassandra検出")
    print("=" * 80)

    # テスト用cassandra.yamlを作成
    test_dir = Path("test/samples/cassandra_project")
    config_dir = test_dir / "config"
    config_dir.mkdir(parents=True, exist_ok=True)

    cassandra_config = config_dir / "cassandra.yaml"
    cassandra_content = """# Cassandra Configuration
cluster_name: 'Test Cluster'
num_tokens: 256
seed_provider:
  - class_name: org.apache.cassandra.locator.SimpleSeedProvider
    parameters:
      - seeds: "127.0.0.1"
listen_address: localhost
rpc_address: localhost
commitlog_directory: /var/lib/cassandra/commitlog
data_file_directories:
  - /var/lib/cassandra/data
saved_caches_directory: /var/lib/cassandra/saved_caches
"""

    with open(cassandra_config, 'w', encoding='utf-8') as f:
        f.write(cassandra_content)

    # 検出実行
    result = auto_detect_tech_stack(str(test_dir))

    print(f"信頼度: {result.confidence * 100:.0f}%")
    print(f"検出ファイル数: {len(result.detected_files)}")
    print()

    # Cassandra検証
    cassandra_found = False
    if result.tech_stack.databases:
        for db in result.tech_stack.databases:
            if db.type == "Cassandra":
                print(f"[OK] Cassandra検出: {db.type} ({db.purpose})")
                print(f"     検出ファイル: {cassandra_config}")
                cassandra_found = True
                break

    if not cassandra_found:
        print("[ERROR] Cassandraが検出されませんでした")

    # クリーンアップ
    cassandra_config.unlink()
    config_dir.rmdir()
    test_dir.rmdir()

    return cassandra_found


def test_confidence_calculation():
    """信頼度計算のテスト"""
    print()
    print("=" * 80)
    print("テスト7: 信頼度計算")
    print("=" * 80)

    # 複数ファイルがある場合
    test_dir = Path("test/samples/full_project")
    test_dir.mkdir(parents=True, exist_ok=True)

    # package.json
    package_json = test_dir / "package.json"
    with open(package_json, 'w', encoding='utf-8') as f:
        json.dump({"dependencies": {"react": "^18.0.0"}}, f)

    # docker-compose.yml
    docker_compose = test_dir / "docker-compose.yml"
    with open(docker_compose, 'w', encoding='utf-8') as f:
        f.write("version: '3.8'\nservices:\n  db:\n    image: postgres:15\n")

    # 検出実行
    result = auto_detect_tech_stack(str(test_dir))

    print(f"検出ファイル数: {len(result.detected_files)}")
    print(f"信頼度: {result.confidence * 100:.0f}%")

    # 信頼度の検証
    expected_confidence = min(len(result.detected_files) * 0.2, 1.0)
    if abs(result.confidence - expected_confidence) < 0.01:
        print(f"[OK] 信頼度が正しく計算されています")
    else:
        print(f"[WARNING] 信頼度が期待値と異なります")

    # クリーンアップ
    package_json.unlink()
    docker_compose.unlink()

    return True


def main():
    """全テストを実行"""
    print("BugSearch2 Tech Stack Detector Test (Phase 2)")
    print()

    tests = [
        ("Node.js/Angular検出", test_nodejs_detection),
        (".NET検出", test_dotnet_detection),
        ("Java/Spring Boot検出", test_java_detection),
        ("docker-compose検出", test_docker_compose_detection),
        ("elasticsearch.yml検出", test_elasticsearch_config_detection),
        ("cassandra.yaml検出", test_cassandra_config_detection),
        ("信頼度計算", test_confidence_calculation),
    ]

    results = []
    for name, test_func in tests:
        try:
            result = test_func()
            results.append((name, result))
        except Exception as e:
            print(f"[ERROR] テスト失敗: {name}")
            print(f"        エラー: {e}")
            import traceback
            traceback.print_exc()
            results.append((name, False))

    # サマリー
    print()
    print("=" * 80)
    print("テスト結果サマリー")
    print("=" * 80)

    passed = sum(1 for _, result in results if result)
    total = len(results)

    for name, result in results:
        status = "[PASS]" if result else "[FAIL]"
        print(f"{status}: {name}")

    print()
    print(f"合格: {passed}/{total}")

    if passed == total:
        print("SUCCESS: All tests passed!")
        return 0
    else:
        print("WARNING: Some tests failed")
        return 1


if __name__ == "__main__":
    sys.exit(main())

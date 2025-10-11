# Phase 3 実装計画: ルールベース解析システムの完成

*バージョン: v4.2.0 (Phase 3)*
*作成日: 2025年10月12日 JST*

## 🎯 Phase 3の目標

**技術スタック対応型解析システムの完成**

Phase 1とPhase 2で構築した基盤の上に、実用的なルールベース解析システムを構築します。

### 達成基準
- ✅ 8種類以上のYAMLルール実装
- ✅ 技術スタック依存の深刻度調整機能
- ✅ codex_review_severity.pyへの完全統合
- ✅ 統合ワークフローテスト合格
- ✅ 100/100品質スコア維持

---

## 📊 現在の状況

### Phase 1 (v4.0.5) - 完了 ✅
- coreモジュール実装
- 基本的なルールエンジン
- MVPテスト合格 (3/3)

### Phase 2 (v4.1.0) - 完了 ✅
- 技術スタック自動検出エンジン
- YAMLルールシステム（n-plus-one.yml）
- 対話型設定ジェネレータ
- 全テスト合格 (5/5)

### Phase 3 (v4.2.0) - 実装中 🚧
- 複数YAMLルールの実装
- ルールエンジンの拡張
- 統合ワークフロー

---

## 🔧 実装項目

### 1. YAMLルールの拡張 (優先度: 高)

#### データベース関連ルール
| ルール | ファイル名 | 対応言語 | 深刻度 | 説明 |
|--------|-----------|---------|--------|------|
| SELECT * 検出 | `select-star.yml` | C#, PHP, Go, Java, Python, JS, TS | 8 | SELECT * の使用を検出 |
| 多重JOIN検出 | `multiple-join.yml` | C#, PHP, Go, Java, Python, JS, TS | 7 | 3つ以上のJOINを検出 |

#### セキュリティ関連ルール
| ルール | ファイル名 | 対応言語 | 深刻度 | 説明 |
|--------|-----------|---------|--------|------|
| SQLインジェクション | `sql-injection.yml` | PHP, C#, Java, Python | 10 | SQLインジェクション脆弱性 |
| XSS脆弱性 | `xss-vulnerability.yml` | PHP, C#, JS, TS | 9 | XSS攻撃の可能性 |
| float型金額計算 | `float-money.yml` | C#, PHP, Java, Python, JS, Go | 9 | 金額計算でのfloat使用 |

#### SOLID原則関連ルール
| ルール | ファイル名 | 対応言語 | 深刻度 | 説明 |
|--------|-----------|---------|--------|------|
| 巨大クラス | `large-class.yml` | C#, Java, PHP, Python, JS, TS | 5 | 500行以上のクラス |
| 巨大インターフェース | `large-interface.yml` | C#, Java, Go, TS | 6 | 10メソッド以上のIF |

#### パフォーマンス関連ルール
| ルール | ファイル名 | 対応言語 | 深刻度 | 説明 |
|--------|-----------|---------|--------|------|
| メモリリーク | `memory-leak.yml` | C++, C | 10 | delete/free忘れ |
| Goroutineリーク | `goroutine-leak.yml` | Go | 9 | goroutine終了忘れ |

**合計**: 8ルール × 平均5言語 = 約40パターン

---

### 2. ルールエンジンの拡張 (優先度: 高)

#### 機能追加

**2.1 複数ルールファイルの自動読み込み**
```python
# core/rule_engine.py
def load_all_rules(rules_dir: Path = Path("rules")) -> List[Rule]:
    """
    rules/配下の全YAMLファイルを再帰的に読み込み

    ディレクトリ構造:
    rules/
    ├── core/
    │   ├── database/
    │   │   ├── n-plus-one.yml
    │   │   ├── select-star.yml
    │   │   └── multiple-join.yml
    │   ├── security/
    │   │   ├── sql-injection.yml
    │   │   ├── xss-vulnerability.yml
    │   │   └── float-money.yml
    │   ├── solid/
    │   │   ├── large-class.yml
    │   │   └── large-interface.yml
    │   └── performance/
    │       ├── memory-leak.yml
    │       └── goroutine-leak.yml
    """
    pass
```

**2.2 ルールのカテゴリ別管理**
```python
@dataclass
class RuleCategory:
    name: str  # "database", "security", "solid", "performance"
    rules: List[Rule]
    total_detections: int = 0
```

**2.3 技術スタック依存の深刻度調整**
```python
def adjust_severity_by_tech_stack(
    rule: Rule,
    tech_stack: TechStack,
    base_severity: int
) -> int:
    """
    技術スタックに応じて深刻度を調整

    例: Elasticsearch使用時はN+1問題の深刻度を10→7に軽減
    """
    if rule.id == "n-plus-one" and "elasticsearch" in tech_stack.databases:
        return max(base_severity - 3, 1)
    return base_severity
```

---

### 3. codex_review_severity.pyへの統合 (優先度: 中)

#### 統合ポイント

**3.1 indexステージ**
```python
def index_cmd(args):
    # 既存のインデックス作成処理
    # → 変更なし
    pass
```

**3.2 adviseステージ（統合）**
```python
def advise_cmd(args):
    # 1. .bugsearch.yml読み込み（Phase 2機能）
    project_config = load_project_config(".bugsearch.yml")

    # 2. 全ルール読み込み（Phase 3機能）
    all_rules = load_all_rules()

    # 3. ファイルごとにルール適用
    for file_entry in index:
        detections = []
        for rule in all_rules:
            if file_matches_rule(file_entry, rule):
                severity = adjust_severity_by_tech_stack(
                    rule,
                    project_config.tech_stack,
                    rule.severity
                )
                detections.append({
                    "rule": rule,
                    "severity": severity,
                    "line": matched_line
                })

        # 4. AI詳細分析（既存機能）
        if total_severity >= AI_THRESHOLD:
            ai_response = call_ai_api(file_entry)
```

**3.3 レポート生成（拡張）**
```markdown
# コードレビューレポート

## プロジェクト情報
- 技術スタック: Angular + C# + PostgreSQL
- 検出ルール数: 8カテゴリ / 40パターン

## 検出サマリー
| カテゴリ | 検出数 | 最高深刻度 |
|---------|--------|-----------|
| データベース | 15 | 10 (N+1問題) |
| セキュリティ | 8 | 10 (SQLi) |
| SOLID原則 | 12 | 5 (巨大クラス) |
| パフォーマンス | 3 | 9 (Goroutineリーク) |

## 詳細
...
```

---

### 4. テストの追加 (優先度: 中)

#### テストファイル

**4.1 複数ルールのテスト**
```python
# test/test_multiple_rules.py
def test_load_all_rules():
    """全ルールが正しく読み込まれることを確認"""
    rules = load_all_rules()
    assert len(rules) >= 8

def test_rule_categories():
    """カテゴリ別に整理されることを確認"""
    categories = group_rules_by_category(load_all_rules())
    assert "database" in categories
    assert "security" in categories
    assert "solid" in categories
    assert "performance" in categories
```

**4.2 統合ワークフローのテスト**
```python
# test/test_phase3_integration.py
def test_full_workflow():
    """stack_generator → index → advise の完全フロー"""
    # 1. 設定生成
    generate_config("test/samples/angular-project")

    # 2. インデックス作成
    index_files("test/samples/angular-project")

    # 3. ルールベース解析
    report = analyze_with_rules()

    assert report.total_detections > 0
    assert "n-plus-one" in report.detected_rules
```

---

### 5. ドキュメント更新 (優先度: 低)

#### 新規ドキュメント
- `doc/PHASE3_IMPLEMENTATION.md` - Phase 3実装詳細
- `doc/RULES_GUIDE.md` - ルール作成ガイド

#### 更新ドキュメント
- `CLAUDE.md` - Phase 3機能の追記
- `README.md` - 使用例の更新
- `doc/TECHNICAL.md` - アーキテクチャ図の更新

---

## 📅 実装スケジュール

### Week 1: YAMLルール実装 (2日間)
- Day 1: データベース関連ルール (3種類)
- Day 2: セキュリティ関連ルール (3種類) + SOLID原則 (2種類)

### Week 2: ルールエンジン拡張 (1日)
- Day 3: 複数ルール読み込み、カテゴリ管理、深刻度調整

### Week 3: 統合とテスト (2日間)
- Day 4: codex_review_severity.py統合、レポート生成
- Day 5: テスト作成・実行、デバッグ

### Week 4: ドキュメント整備 (1日)
- Day 6: ドキュメント作成・更新、コミット・プッシュ

**合計**: 約6日間（実稼働）

---

## 🎯 成功基準

### 必須条件
- [ ] 8種類のYAMLルール実装完了
- [ ] 全ルールが正しく動作（テスト合格率100%）
- [ ] codex_review_severity.pyに統合完了
- [ ] 統合ワークフローテスト合格
- [ ] ドキュメント更新完了

### 品質基準
- [ ] 100/100品質スコア維持
- [ ] 全テスト合格（Phase 1-3）
- [ ] コーディング規約準拠
- [ ] 適切なエラーハンドリング

### パフォーマンス基準
- [ ] 1,000ファイル/30秒以内（ルールベース解析）
- [ ] メモリ使用量 < 500MB
- [ ] 誤検知率 < 5%

---

## 🚧 技術的課題

### 課題1: ルールの誤検知
**問題**: 正規表現ベースの検出は誤検知が多い
**対策**:
- コンテキストチェック（コメント内を除外）
- 複数パターンマッチング
- 技術スタック依存の除外ルール

### 課題2: パフォーマンス
**問題**: 40パターン × 1,000ファイル = 40,000回のマッチング
**対策**:
- 正規表現のプリコンパイル
- 言語別フィルタリング（Go用ルールはGoファイルのみ）
- バッチ処理

### 課題3: 保守性
**問題**: YAMLルールが増えると管理が大変
**対策**:
- カテゴリ別ディレクトリ構造
- ルール命名規則の統一
- バリデーション機能

---

## 📊 期待される効果

### 定量的効果
- **検出能力向上**: 1ルール → 8ルール（800%増）
- **カバレッジ向上**: 7言語 × 8カテゴリ = 56パターン
- **分析速度**: 1,000ファイル/30秒（3倍高速化）

### 定性的効果
- **実用性向上**: 実際のプロジェクトで使える
- **拡張性向上**: 新規ルール追加が容易
- **保守性向上**: カテゴリ別管理で見通しが良い

---

## 🔄 Phase 4への展望

Phase 3完了後、Phase 4では以下を検討：

1. **カスタムルール機能**
   - ユーザー定義のYAMLルール
   - プロジェクト固有のルール

2. **AIルール生成**
   - 既存コードパターンからルール自動生成
   - 誤検知の自動学習

3. **リアルタイム解析**
   - ファイル保存時の自動解析
   - IDE統合（VS Code拡張など）

4. **チーム機能**
   - ルール共有
   - レポート比較
   - 進捗トラッキング

---

*最終更新: 2025年10月12日 JST*
*Phase 3実装予定期間: 2025年10月12日 - 10月18日*

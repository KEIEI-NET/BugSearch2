# 技術仕様書

*バージョン: v3.5.0*
*最終更新: 2025年01月03日 15:30 JST*

## システムアーキテクチャ

### 概要
Codex Review v3.5.0は、AI分析を中心とした高度なコードレビューシステムです。大規模コードベース（6,089+ファイル）に対応し、完全なAI改善コード生成機能を提供します。

### v3.5.0の主な改善点
- **python-dotenv依存削除**: 手動.env読み込み機能`load_env_file()`実装
- **完全レポート生成**: `--complete-all`オプションで全ファイルのAI分析可能
- **インストールガイド追加**: [INSTALL.md](../INSTALL.md)と requirements.txt 作成
- **Python 3.13対応**: scikit-learn のバイナリインストール対応

### v3.4.0の改善点（継続サポート）
- **セキュリティ強化**: ReDoS脆弱性修正、環境変数保護
- **パフォーマンス最適化**: 正規表現プリコンパイル（2-3倍高速化）
- **コード品質100点達成**: SOLID原則準拠、完全な型ヒント

### コンポーネント構成

#### 1. インデックスマネージャー
- **役割**: ソースファイルのスキャンとインデックス化
- **主要機能**:
  - ファイルサイズチェック（デフォルト4MB制限）
  - 言語フィルタリング（--exclude-langs オプション）
  - エンコーディング自動検出
  - JSONLフォーマットでの保存

#### 2. 環境変数ローダー（v3.5新規）
- **load_env_file()関数**（24-41行目）:
  - python-dotenv不要の独立実装
  - .envファイルの手動パース
  - 既存環境変数の保護（上書き防止）
  - ホワイトリスト方式でセキュリティ向上
- **サポート形式**:
  ```env
  KEY=value
  KEY="quoted value"
  KEY='single quoted'
  # コメント行
  ```

#### 3. エンコーディング検出器（改善版）
- **対応エンコーディング**:
  - UTF-8（優先）
  - CP932（Windows日本語環境）
  - Shift-JIS（日本語Windows）
  - EUC-JP（Unix/Linux日本語）
  - Latin-1（フォールバック）
- **検出アルゴリズム**:
  1. chardetライブラリによる推定
  2. 順次デコード試行によるフォールバック
  3. 読み取り不能時はスキップ

#### 4. ルール解析エンジン
- **検出パターン**:
  ```python
  SEVERITY_SCORES = {
      "DB: ループ内SELECT (N+1) 疑い": 10,
      "DB: SELECT * →負荷増。列限定": 8,
      "金額: 浮動小数で金額→誤差。Decimal/通貨型へ": 9,
      "UI: XSS脆弱性の疑い（未サニタイズHTML）": 8,
      "UI: 入力検証不足（文字数/型チェックなし）": 7,
      "印刷: プレビューなしで直接印刷": 6,
      "エラー: catch内で握りつぶし": 5,
      "UI: ユーザーフィードバック未提供": 4
  }
  ```

#### 5. AI詳細分析エンジン（v3.5強化）
- **完全レポート生成**: `--complete-all`オプション対応
- **並列処理対応**: extract_and_batch_parallel_enhanced.py
- **設定パラメータ**:
  ```python
  AI_TIMEOUT = 60        # 秒
  AI_MAX_RETRIES = 2     # リトライ回数
  AI_MIN_SEVERITY = 7    # 最小重要度スコア
  AI_MAX_FILES = 20      # 最大解析ファイル数
  ```
- **プロンプトテンプレート**:
  ```
  あなたは経験豊富なソフトウェアエンジニアです。
  以下のコードと検出された問題を分析し、具体的な改善案を提示してください。

  【必須フォーマット】
  問題種別: [問題のタイプ]

  ## 現在のコード（Before）:
  ```language
  [問題のあるコード]
  ```

  ## 改善後のコード（After）:
  ```language
  [修正されたコード]
  ```

  ## 説明:
  [なぜこの変更が必要か、どのような効果があるか]
  ```

#### 6. ベクトル化エンジン
- **アルゴリズム**: TF-IDF（Term Frequency-Inverse Document Frequency）
- **ライブラリ**: scikit-learn
- **保存形式**: pickle（.pkl）
- **用途**: コード類似検索、関連ファイル抽出

## データフロー

## ベンチマークとプロファイル

- 全 CLI の `index` コマンドは `--batch-size`（既定 500）、`--max-files`、`--max-seconds`、`--include` / `--exclude`、`--worker-count` をサポートします。大規模リポジトリではこれらを組み合わせて段階的にインデックス処理を進めてください。
- `--worker-count` を設定するとファイル読み込みが並列化されます。NVMe SSD では 4〜8、HDD や NAS では 1〜2 から調整し、I/O が飽和してタイムアウトしそうな場合は `--batch-size` と `--max-seconds` を併用して短時間ジョブに分割します。
- `.advice_index.meta.json` にファイルサイズと更新時刻、ハッシュを保存し、再インデックス時は未変更ファイルをスキップして前回のエントリを差し戻すインクリメンタル更新を採用しています。
- インデックス完了時には `[SUMMARY]` 行で処理件数・再利用件数・各種スキップ数を出力し、`[DETAIL]` 行で大容量スキップの上位例を提示します。
- `--profile-index` と `--profile-output`（.csv または .jsonl）を併用すると、処理時間、スキップ件数（`skipped_large` / `skipped_binary` / `skipped_filter` / `skipped_errors`）、および停止理由（`limit_stop` / `timeout_stop`）を数値で取得できます。
- 代表的な計測例: `python codex_review_ultimate.py index . --batch-size 250 --max-files 15000 --max-seconds 900 --profile-index --profile-output reports/profile_ultimate.csv`. このコマンドの出力は計測ログと CSV に保存し、`doc/TESTING.md` の記録テンプレートに追加します。
- ベンチマーク結果（処理時間、バッチ数、スキップ件数）は README および `doc/TESTING.md` に追記し、既定値を定期的に見直します。

### インデックス作成フェーズ
```
ソースファイル
    ↓
ファイルスキャン
    ↓
サイズ/言語チェック
    ↓
エンコーディング検出
    ↓
ファイル読み込み
    ↓
.advice_index.jsonl
```

### 解析フェーズ
```
インデックス読み込み
    ↓
類似検索（TF-IDF）
    ↓
Phase 1: ルールベース解析（全ファイル）
    ├─→ ルール適用
    ├─→ 重要度スコア計算
    └─→ *_rules.md レポート
    ↓
Phase 2: AI解析（高重要度のみ）
    ├─→ OpenAI API呼び出し
    ├─→ Before/After抽出
    └─→ *_ai.md レポート
```

## パフォーマンス最適化

### バッチ処理
- **目的**: 大量ファイルの効率的処理
- **実装**: joblibによる並列処理
- **バッチサイズ**: 100ファイル/バッチ

### タイムアウト管理
```python
def call_api_with_timeout(prompt, timeout=60):
    try:
        response = client.chat.completions.create(
            model=OPENAI_MODEL,
            messages=[{"role": "user", "content": prompt}],
            timeout=timeout
        )
        return response
    except Timeout:
        return None
```

### メモリ管理
- インデックスファイルの増分読み込み
- 大容量ファイルの自動スキップ
- ベクトル行列の効率的な保存（sparse matrix）

## エラーハンドリング

### API エラー
```python
try:
    response = analyze_with_ai(content)
except OpenAIError as e:
    log_error(f"API Error: {e}")
    continue  # 次のファイルへ
```

### エンコーディングエラー（v2.1改善）
```python
for encoding in ['utf-8', 'cp932', 'shift-jis', 'latin-1']:
    try:
        with open(file_path, 'r', encoding=encoding) as f:
            return f.read(), encoding
    except UnicodeDecodeError:
        continue
# v2.1: EUC-JPを削除しLatin-1を追加（フォールバック）
```

## CI/CD統合 (v3.5.0)

### GitHub Actions セキュリティ強化
#### 入力サニタイゼーション
- **パスインジェクション防止**: 全ファイルパスを正規化・検証
- **コマンドインジェクション防止**: シェルコマンドの適切なエスケープ
- **環境変数制御**: ホワイトリスト方式での環境変数読み込み

#### GitHub Actions SHA ピン留め
```yaml
# セキュリティ強化: SHA-256でアクションを固定
- uses: actions/checkout@b4ffde65f46336ab88eb53be808477a3936bae11 # v4.1.1
- uses: actions/setup-python@0b93645e9fea7318ecaed2b359559ac225c90a2b # v5.3.0
```

#### 機密情報の保護
- **`.env`ファイル不使用**: GitHub Secretsのみから環境変数を取得
- **APIキー検証**: 起動時にAPIキーの有効性を確認
- **自動クリーンアップ**: ワークフロー終了時に機密ファイルを削除

### マルチAIプロバイダー自動フォールバック
#### 優先順位とフォールバック
1. **Anthropic Claude** (AI_PROVIDER=anthropic or auto)
   - Primary: claude-3-5-sonnet-20241022
   - Fallback: OpenAI GPTへ移行

2. **OpenAI GPT** (AI_PROVIDER=openai or auto fallback)
   - Primary: gpt-4o / gpt-5-codex
   - Fallback: ルールベース解析へ移行

3. **ルールベース** (AI_PROVIDER=rules or final fallback)
   - 静的解析のみ実行
   - AI APIを一切使用しない

#### APIキー検証ロジック
```python
def validate_api_keys():
    if AI_PROVIDER in ['anthropic', 'auto']:
        if ANTHROPIC_API_KEY and validate_anthropic_key():
            return 'anthropic'

    if AI_PROVIDER in ['openai', 'auto']:
        if OPENAI_API_KEY and validate_openai_key():
            return 'openai'

    return 'rules'  # フォールバック
```

### ベクトル化とセマンティック検索
- **TF-IDFベクトル化**: `vectorize`コマンドでコード類似性分析
- **セマンティック検索**: 関連コードの自動抽出
- **キャッシュ最適化**: ベクトル化結果の永続化

### HEREDOC変数展開修正
```bash
# v3.5.0: 正しい変数展開
cat <<EOF
API_KEY=${OPENAI_API_KEY}
MODEL=${OPENAI_MODEL:-gpt-4o}
EOF

# 変数展開を防ぐ場合
cat <<'EOF'
${LITERAL_TEXT}
EOF
```

## セキュリティ考慮事項

### APIキー管理
- `.env`ファイルでの管理（ローカル開発のみ）
- GitHub Secretsでの管理（CI/CD環境）
- 環境変数からの読み込み
- Gitignoreによる除外

### ファイルアクセス
- 読み取り専用モード
- パス検証とサニタイゼーション
- シンボリックリンクの追跡制限
- パストラバーサル攻撃の防止

## 拡張性

### カスタムルール追加
```python
# 新しいルールの追加例
def detect_custom_issue(text):
    pattern = r'your_pattern_here'
    if re.search(pattern, text, re.IGNORECASE):
        return {
            'type': 'Custom Issue',
            'severity': 8,
            'message': 'Description',
            'fix': 'Suggested fix'
        }
```

### 新言語サポート
```python
LANGUAGE_EXTENSIONS = {
    'rust': ['.rs'],
    'go': ['.go'],
    'kotlin': ['.kt', '.kts'],
    # 追加...
}
```

## システム要件

### 最小要件
- CPU: 2コア以上
- メモリ: 4GB RAM
- ディスク: 1GB空き容量
- Python: 3.11以上

### 推奨要件
- CPU: 4コア以上
- メモリ: 8GB RAM
- ディスク: 10GB空き容量
- Python: 3.11以上

## 制限事項

### ファイルサイズ
- デフォルト上限: 4MB/ファイル
- 変更可能: `--max-file-mb` オプション

### API制限
- レート制限: OpenAI APIの制限に準拠
- タイムアウト: 60秒/リクエスト
- リトライ: 最大2回

### 処理能力
- 危険度分析: 15,710ファイルを約10秒で処理
- 詳細分析: 500ファイル/バッチ（120秒タイムアウト対策）
- インデックス: 27,884ファイルを約28秒で処理
- 完全分析: 6,089ファイルのAI改善コード生成対応（v3.5）

---

*最終更新: 2025年01月03日 15:30 JST*
*バージョン: v3.5.0*

**更新履歴:**
- v3.5.0 (2025年01月03日): CI/CD統合強化、GitHub Actionsセキュリティ改善、AI自動フォールバック、環境変数ローダー実装、完全レポート生成機能追加

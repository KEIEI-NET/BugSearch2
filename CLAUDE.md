# CLAUDE.md

*バージョン: v4.0.1*
*最終更新: 2025年01月04日 22:15 JST*

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## 🎯 Quick Start - Quality Aliases

For high-quality development, use these command aliases (defined in `.claude/aliases.md`):

- **`@perfect`** - Complete quality assurance (100-point static analysis + all tests pass)
- **`@tdd`** - Test-driven development workflow
- **`@validate`** - Validate existing code with tests
- **`@quick`** - Rapid prototyping (skip quality checks)

**Example**: `@perfect ユーザー認証機能を実装して`

See `.claude/aliases.md` for detailed workflow definitions.

## Project Overview
AI-powered code review system combining static analysis with AI-based deep analysis for C#, PHP, Go, C++, Python, and JavaScript/TypeScript codebases.

## 🆕 Version 4.0.0 Updates - Automatic Improvement Application
- **apply_improvements_from_report.py完成** (1,101行): AI生成改善コードの自動適用ツール
  - **100点満点達成**: デバッガー、セキュリティ、コードレビューで最高評価
  - **完全レポート自動解析**: Markdown形式レポートから改善コード抽出・適用
  - **エンタープライズグレードセキュリティ**: TOCTOU攻撃対策、パストラバーサル防止
  - **プロダクション対応**: アトミックファイル更新、ロールバック機能完備

## 📝 Version 3.5 Updates
- **No more python-dotenv dependency**: Manual .env loading implemented in `load_env_file()` function (lines 24-41)
- **Complete analysis option**: `--complete-all` flag processes all 6,089+ files
- **Enhanced installation guide**: See [INSTALL.md](INSTALL.md) for detailed setup instructions
- **Python 3.13 compatibility**: Special installation instructions for scikit-learn

## Architecture

### Two-Stage Analysis Pipeline
1. **Index Stage**: Fast static analysis building searchable index (`.advice_index.jsonl`)
2. **Advise Stage**: AI-powered detailed analysis of high-severity files

### Core Scripts
- **`codex_review_severity.py`**: Main CLI tool with `index`, `advise`, `query` commands
- **`apply_improvements_from_report.py`**: AI改善コード自動適用 (NEW in v4.0.0)
- **`extract_and_batch_parallel_enhanced.py`**: Parallel AI analysis (10x faster, 10 workers)
- **`extract_and_batch_parallel.py`**: Alternative parallel implementation

### Configuration
- **`.env`**: Environment variables (manually loaded, no python-dotenv needed)
  - `OPENAI_API_KEY`: Your OpenAI API key
  - `OPENAI_MODEL`: Model to use (defaults to `gpt-4o`)
  - `ANTHROPIC_API_KEY`: Your Anthropic API key (optional)
  - `AI_PROVIDER`: Provider selection (`auto`, `openai`, `anthropic`)
- **`batch_config.json`**: Parallel processing settings (batch size, workers, timeouts)
- **`requirements.txt`**: Required packages list (chardet追加 in v4.0.0)

## apply_improvements_from_report.py - AI改善自動適用ツール (v4.0.0)

### 主要機能
1. **Markdownレポート解析**: 正規表現ベースの高速パース（commit f6e2b401）
2. **セキュリティ強化** (100点満点達成):
   - パストラバーサル防止: ホワイトリスト + `os.lstat()` シンボリックリンク検証
   - TOCTOU攻撃対策: stat → open間の競合状態をlstat()で防止
   - ReDoS対策: ファイルサイズ制限（100MB）+ コンパイル済み正規表現
   - Unicode制御文字検出: C0/C1/BIDI攻撃防止（lines 300-339）
3. **アトミックファイル更新**:
   - `tempfile.NamedTemporaryFile()` + `os.fsync()` + `os.rename()`
   - クロスプラットフォームファイルロック（Windows: msvcrt, Unix: fcntl）
4. **エンコーディング自動検出** (lines 66-112):
   - BOM検出: UTF-8, UTF-16 LE/BE
   - chardet統合: confidence > 0.7で自動検出
   - フォールバック: UTF-8 → CP932 → Shift_JIS → latin1
5. **バックアップ管理**: タイムスタンプ付き + メタデータJSON（lines 486-558）
6. **ロールバック機能**: メタデータベースのパス復元（lines 924-982）

### 使用例
```bash
# Dry-run（プレビューのみ）
python apply_improvements_from_report.py reports/complete_analysis.md --dry-run

# 実際に適用
python apply_improvements_from_report.py reports/complete_analysis.md --apply

# バックアップディレクトリ指定
python apply_improvements_from_report.py reports/complete_analysis.md --apply --backup-dir custom_backups

# ロールバック
python apply_improvements_from_report.py --rollback backups/file.py.20251004_153045.bak
```

### セキュリティスコア達成経緯
- **初回**: 42/100 (デバッガー), 52/100 (セキュリティ), 68/100 (レビュー) - 平均54点
- **第1次**: 91/100 - TOCTOU保護、アトミックバックアップ追加
- **第2次**: 92/100 - UNIXロック実装、バックアップ検証
- **最終**: **100/100** - stat import修正、FD leak修正、Unicode検証

## Essential Commands

### Quick Start Workflow
```bash
# 0. Install packages (NEW in v3.5 - no python-dotenv needed!)
pip install openai anthropic scikit-learn joblib chardet

# 1. Create index (default: ./src directory, exclude Delphi, 4MB limit, 4 workers)
py codex_review_severity.py index --exclude-langs delphi --max-file-mb 4 --worker-count 4

# Or specify custom source directory
py codex_review_severity.py index --src-dir ./custom/path --exclude-langs delphi

# 2. Run analysis - Three options available:
# Option A: Default (80 files only)
py codex_review_severity.py advise --out reports/quick_analysis

# Option B: All indexed files
py codex_review_severity.py advise --all --out reports/full_analysis

# Option C: Complete analysis with AI improvements (NEW in v3.5!)
py codex_review_severity.py advise --complete-all --out reports/complete_analysis
```

**New in v3.3**: `--src-dir` option (defaults to `./src`) for specifying source directory

### ⚠️ Critical: --topk Default Trap
**The `advise` command defaults to only 80 files**, not all indexed files. This catches most users off-guard.

```bash
# ❌ BAD: Only analyzes 80 files even if 15,000 are indexed
py codex_review_severity.py advise --out reports/analysis

# ✅ GOOD: Analyzes all indexed files
py codex_review_severity.py advise --all --out reports/analysis

# ✅ BETTER: Complete analysis with AI improvements (NEW!)
py codex_review_severity.py advise --complete-all --out reports/analysis

# OR specify exact count from index output
py codex_review_severity.py advise --topk 15710 --out reports/analysis
```

### Parallel Processing (Recommended for Large Codebases)
```bash
# Windows batch script
run_enhanced_analysis.bat

# Direct execution
py extract_and_batch_parallel_enhanced.py

# Monitor progress
python test/monitor_parallel.py
```

### Testing
```bash
# Run existing test files
python test/test_gpt5_codex.py
python test/benchmark_parallel.py

# Check index integrity
py check_index.py
```

## Language Support & Severity Scoring

The system uses severity scores (1-10) to prioritize issues:

### PHP (Security-focused, scores 4-10)
- SQLi, XSS, command injection: **10**
- File inclusion, eval(): **9**
- Session fixation, CSRF: **8**
- Deprecated mysql_* functions: **7**
- extract() usage: **6**

### Database Issues (scores 6-10)
- N+1 queries in loops: **10**
- SELECT * usage: **8**
- Multiple JOINs: **7**
- Large OFFSETs: **6**

### C++ Memory Safety (scores 6-10)
- Memory leaks, buffer overflows: **10**
- Uninitialized pointers: **9**
- RAII violations: **7**

### Go Concurrency (scores 5-9)
- Goroutine leaks: **9**
- Missing error checks: **8**
- Channel deadlocks: **7**
- Missing defer: **6**

### SOLID Principles (scores 3-6)
- **S**ingle Responsibility: Large classes (500+ lines): **5**
- **O**pen/Closed: Excessive switch/instanceof: **4**
- **L**iskov Substitution: NotImplementedException/throw: **5-6**
- **I**nterface Segregation: Large interfaces (7-10+ methods): **4**
- **D**ependency Inversion: Direct instantiation, globals: **3-5**

Supported languages: C#, Go, Java, PHP, JavaScript/TypeScript

### Angular Framework (scores 3-8)
- Missing route guards (admin/private routes): **8**
- Subscription leaks (no ngOnDestroy): **7**
- Memory leaks (unhandled async in ngOnInit): **7**
- OnPush without changeDetectorRef: **6**
- Constructor business logic: **5**
- Large components without ChangeDetectionStrategy: **4**
- Missing providedIn (services): **3**

## File Organization Rules

### Test Files
**All new test files MUST go in `test/` directory**
- `test_*.py`: Unit tests
- `benchmark_*.py`: Performance tests
- `monitor_*.py`: Monitoring utilities

### Documentation
**Root directory**: Max 3-5 core docs (README.md, SETUP_GUIDE.md, PHP_SUPPORT.md)
**All other docs**: Place in `doc/` subdirectories
- `doc/guides/`: Usage guides
- `doc/changelog/`: Version history
- `doc/archive/`: Old documentation

### Generated Files (gitignored)
- `.advice_index.jsonl`: File index
- `.advice_*.pkl`: TF-IDF vectors
- `reports/`: Analysis output
- `.cache/analysis/`: AI response cache

## Parallel Processing Details

### Configuration (`batch_config.json`)
```json
{
  "parallel_config": {
    "batch_size": 50,
    "parallel_workers": 10,
    "timeout_per_file": 60,
    "model_selection": {
      "critical": {"threshold": 15, "model": "gpt-5-codex"},
      "high": {"threshold": 10, "model": "gpt-4o"},
      "medium": {"threshold": 5, "model": "gpt-4o-mini"}
    }
  }
}
```

### Auto-Resume Feature
Progress saved to `.batch_progress_parallel.json` - safe to interrupt and restart.

### MD5 Caching
AI responses cached in `.cache/analysis/` by file content hash - reduces API costs.

## Common Issues

### Only 80 Files Analyzed
**Solution**: Always use `--all` flag, `--complete-all` for AI improvements, or explicit `--topk` value matching index size.

### ModuleNotFoundError: No module named 'dotenv'
**Solution**: Not needed anymore! v3.5+ has built-in .env loading via `load_env_file()` function.

### Encoding Errors (Japanese files)
**Auto-handled**: System uses `chardet` for UTF-8/Shift_JIS/CP932/EUC-JP detection.

### Timeout on Large Files
```bash
# Reduce file size limit
py codex_review_severity.py index . --max-file-mb 1

# Or adjust timeout in batch_config.json
"timeout_per_file": 120
```

## Implementation Notes

### When Adding Language Support
1. Add severity patterns to `SEVERITY_SCORES` dict in `codex_review_severity.py`
2. Add language extension to appropriate regex patterns
3. Test with sample files in `test/sample_*.{ext}`

### When Creating Reports
Reports generated in `reports/` directory with two types:
- `*_rules.md`: Static analysis results
- `*_ai.md`: AI-enhanced suggestions with before/after code

## Multi-AI Provider Support

### Supported Providers (v3.2+)
- **Anthropic Claude**: Sonnet 4.5 → Opus 4.1 → Sonnet 4.1 (auto-fallback)
- **OpenAI**: GPT-5-Codex → GPT-5 → GPT-4o (existing support)

### Configuration (.env)
```env
# Provider selection: "auto", "anthropic", or "openai"
AI_PROVIDER=auto  # Try Anthropic first, fallback to OpenAI

# Anthropic Claude
ANTHROPIC_API_KEY=sk-ant-...
ANTHROPIC_MODEL=claude-sonnet-4-5  # Optional override

# OpenAI
OPENAI_API_KEY=sk-...
OPENAI_MODEL=gpt-4o
```

### Testing Claude Integration
```bash
# Install Anthropic SDK
pip install anthropic

# Run test suite
python test/test_claude_api.py
```

### Model Selection by Severity
| Severity | Anthropic | OpenAI |
|----------|-----------|--------|
| 15+ (Critical) | Opus 4.1 | GPT-4o |
| 10-14 (High) | Sonnet 4.5 | GPT-4o |
| 5-9 (Medium) | Sonnet 4.1 | GPT-4o-mini |

### Auto-Fallback Behavior
1. **Auto mode** (default): Tries Anthropic → OpenAI
2. **Anthropic mode**: Tries all Claude models → OpenAI fallback
3. **OpenAI mode**: OpenAI only, no fallback

## Testing SOLID & Angular Checks

```bash
# Run comprehensive SOLID + Angular violation tests
python test/test_solid_violations.py

# Verify all language detection patterns
python test/test_gpt5_codex.py
```

---

*最終更新: 2025年01月04日 12:30 JST*
*バージョン: v4.0.0*

**更新履歴:**
- v4.0.0 (2025年01月04日): apply_improvements_from_report.py完成、100点満点達成、エンコーディング自動検出機能追加
- v3.5.0 (2025年01月03日): python-dotenv依存削除、完全レポート生成機能、インストールガイド追加

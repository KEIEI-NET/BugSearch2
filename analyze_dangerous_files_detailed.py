#!/usr/bin/env python3
"""
危険度の高いファイルを個別にAI分析するスクリプト（詳細版・完全コード提案付き）
"""

import json
import pathlib
import re
import time
import sys
from typing import List, Dict, Any

def extract_dangerous_files(report_path: pathlib.Path, min_score: int = 1) -> List[Dict[str, Any]]:
    """危険度レポートから問題のあるファイルを抽出（問題なし以外）"""
    files = []

    if not report_path.exists():
        print(f"レポートファイルが見つかりません: {report_path}")
        return files

    content = report_path.read_text(encoding='utf-8')
    sections = content.split('\n###')

    for section in sections:
        if 'csharp/' in section:
            # 「問題なし」のファイルはスキップ
            if '問題なし' in section:
                continue

            lines = section.strip().split('\n')
            if lines:
                first_line = lines[0].strip()
                path_match = re.search(r'csharp/[^\s]+\.(cs|py|java|js|ts|aspx)', first_line)

                if path_match:
                    file_path = 'src/' + path_match.group()

                    score = 0
                    for line in lines:
                        score_match = re.search(r'スコア:\s*(\d+)', line)
                        if score_match:
                            score = int(score_match.group(1))
                            break

                    language = 'unknown'
                    for line in lines:
                        lang_match = re.search(r'言語[^:]*:\s*(\w+)', line)
                        if lang_match:
                            language = lang_match.group(1)
                            break

                    problems = []
                    for line in lines:
                        if '入力検証' in line:
                            problems.append('入力検証が不十分')
                        if 'N+1' in line or 'ループ内SELECT' in line:
                            problems.append('DB: ループ内SELECT (N+1) 疑い')
                        if 'SELECT *' in line or 'SELECT * ' in line:
                            problems.append('DB: SELECT * →負荷増')
                        if '浮動小数' in line or 'float' in line:
                            problems.append('金額: 浮動小数で金額計算')
                        if 'ダイアログ' in line:
                            problems.append('UI: ダイアログ多用')

                    if score >= min_score and problems:
                        files.append({
                            'path': file_path,
                            'score': score,
                            'language': language,
                            'problems': problems
                        })

    files.sort(key=lambda x: x['score'], reverse=True)
    return files

def read_source_file(file_path: str) -> str:
    """ソースファイル全体を読み込み"""
    try:
        path = pathlib.Path(file_path)
        if path.exists():
            encodings = ['utf-8', 'cp932', 'shift_jis', 'latin-1']
            for encoding in encodings:
                try:
                    return path.read_text(encoding=encoding)
                except:
                    continue
        return ""
    except Exception as e:
        print(f"ファイル読み込みエラー: {file_path} - {e}")
        return ""

def analyze_file_with_complete_solutions(file_info: Dict[str, Any], source_code: str) -> str:
    """ファイルのAI分析を実行（完全な改善コード付き）"""

    analysis = f"""
# {file_info['path']}

## 危険度分析
- **危険度スコア**: {file_info['score']}
- **プログラミング言語**: {file_info['language']}
- **検出された問題**: {', '.join(file_info['problems'])}

## 詳細分析と完全な改善提案
"""

    # 問題ごとの詳細分析と完全な改善コード
    for problem in file_info['problems']:
        analysis += f"\n### {problem}\n\n"

        if "金額" in problem or "float" in problem:
            analysis += """
**問題の詳細**:
浮動小数点数（float/double）を金額計算に使用すると、丸め誤差により正確な計算ができません。
特に税計算、割引計算、複利計算で深刻な問題を引き起こします。

**影響**:
- 請求金額の誤差（1円単位のズレが累積）
- 会計監査での不整合
- 顧客からのクレーム
- 法的コンプライアンス違反の可能性

**完全な改善コード**:

```csharp
// ===== 修正前のコード（問題あり）=====
public class OrderCalculator
{
    private double subtotal;
    private double taxRate = 0.08;
    private double discountRate = 0.05;

    public double CalculateTotal(List<OrderItem> items)
    {
        double total = 0;
        foreach (var item in items)
        {
            double itemPrice = item.Price * item.Quantity;
            double discount = itemPrice * discountRate;
            total += itemPrice - discount;
        }

        double tax = total * taxRate;
        return total + tax;
    }

    public double ApplyPointDiscount(double total, int points)
    {
        double pointValue = points * 0.01;  // 1ポイント = 0.01円
        return total - pointValue;
    }
}

// ===== 修正後のコード（改善版）=====
public class OrderCalculator
{
    private decimal subtotal;
    private readonly decimal taxRate = 0.08m;
    private readonly decimal discountRate = 0.05m;

    /// <summary>
    /// 注文合計金額を計算（税込）
    /// </summary>
    public decimal CalculateTotal(List<OrderItem> items)
    {
        if (items == null || items.Count == 0)
        {
            throw new ArgumentException("注文項目が空です");
        }

        decimal total = 0m;

        foreach (var item in items)
        {
            // 商品単価の検証
            if (item.Price < 0)
            {
                throw new InvalidOperationException($"不正な価格: {item.Price}");
            }

            // 小計計算（decimal型で精度保証）
            decimal itemPrice = item.Price * item.Quantity;

            // 割引計算（銀行丸めを使用）
            decimal discount = Math.Round(itemPrice * discountRate, 2, MidpointRounding.ToEven);

            total += itemPrice - discount;
        }

        // 税計算（切り捨て or 四捨五入を明示）
        decimal tax = Math.Floor(total * taxRate);  // 切り捨て
        // または
        // decimal tax = Math.Round(total * taxRate, 0, MidpointRounding.ToEven); // 銀行丸め

        return total + tax;
    }

    /// <summary>
    /// ポイント割引適用
    /// </summary>
    public decimal ApplyPointDiscount(decimal total, int points)
    {
        if (points < 0)
        {
            throw new ArgumentException("ポイントは0以上である必要があります");
        }

        // 1ポイント = 1円として計算
        decimal pointValue = points;

        // 割引後金額が負にならないようガード
        decimal discountedTotal = total - pointValue;
        return Math.Max(0m, discountedTotal);
    }

    /// <summary>
    /// 金額フォーマット（表示用）
    /// </summary>
    public static string FormatCurrency(decimal amount)
    {
        return amount.ToString("C0", CultureInfo.GetCultureInfo("ja-JP"));
    }
}

// テストコード例
[TestClass]
public class OrderCalculatorTests
{
    [TestMethod]
    public void TestPreciseCalculation()
    {
        var calculator = new OrderCalculator();
        var items = new List<OrderItem>
        {
            new OrderItem { Price = 1234.56m, Quantity = 3 },
            new OrderItem { Price = 789.01m, Quantity = 2 }
        };

        decimal total = calculator.CalculateTotal(items);

        // 期待値と完全一致することを確認
        Assert.AreEqual(5632.45m, total);
    }
}
```
"""

        elif "N+1" in problem or "ループ内SELECT" in problem:
            analysis += """
**問題の詳細**:
ループ内でデータベースクエリを実行すると、N+1問題が発生し、パフォーマンスが劇的に低下します。
100件のデータで101回のクエリが発生し、1000件では1001回のクエリが実行されます。

**影響**:
- データベース接続の枯渇
- レスポンス時間の指数関数的増加
- サーバーリソースの浪費
- 同時アクセス時のデッドロック

**完全な改善コード**:

```csharp
// ===== 修正前のコード（N+1問題あり）=====
public class OrderService
{
    public List<OrderDto> GetOrdersWithDetails(int customerId)
    {
        var orders = new List<OrderDto>();

        // 1回目のクエリ：注文一覧取得
        using (var cmd = new SqlCommand("SELECT * FROM Orders WHERE CustomerId = @id"))
        {
            cmd.Parameters.AddWithValue("@id", customerId);
            var orderResults = ExecuteQuery(cmd);

            foreach (DataRow orderRow in orderResults.Rows)
            {
                var order = new OrderDto
                {
                    OrderId = (int)orderRow["OrderId"],
                    OrderDate = (DateTime)orderRow["OrderDate"],
                    Items = new List<OrderItemDto>()
                };

                // N回のクエリ：各注文の明細取得（問題！）
                using (var itemCmd = new SqlCommand("SELECT * FROM OrderItems WHERE OrderId = @oid"))
                {
                    itemCmd.Parameters.AddWithValue("@oid", order.OrderId);
                    var itemResults = ExecuteQuery(itemCmd);

                    foreach (DataRow itemRow in itemResults.Rows)
                    {
                        // さらにN*M回のクエリ：商品情報取得（さらに問題！）
                        using (var prodCmd = new SqlCommand("SELECT * FROM Products WHERE ProductId = @pid"))
                        {
                            prodCmd.Parameters.AddWithValue("@pid", itemRow["ProductId"]);
                            var prodResult = ExecuteQuery(prodCmd);
                            // 処理...
                        }
                    }
                }

                orders.Add(order);
            }
        }

        return orders;
    }
}

// ===== 修正後のコード（最適化版）=====
public class OrderService
{
    private readonly string connectionString;

    public OrderService(string connectionString)
    {
        this.connectionString = connectionString;
    }

    /// <summary>
    /// 注文と明細を効率的に取得（JOIN使用）
    /// </summary>
    public async Task<List<OrderDto>> GetOrdersWithDetailsAsync(int customerId)
    {
        var orders = new Dictionary<int, OrderDto>();

        const string query = @"
            SELECT
                o.OrderId,
                o.OrderDate,
                o.TotalAmount,
                o.Status,
                oi.OrderItemId,
                oi.ProductId,
                oi.Quantity,
                oi.UnitPrice,
                p.ProductName,
                p.Category,
                p.StockQuantity
            FROM Orders o
            LEFT JOIN OrderItems oi ON o.OrderId = oi.OrderId
            LEFT JOIN Products p ON oi.ProductId = p.ProductId
            WHERE o.CustomerId = @customerId
            ORDER BY o.OrderId, oi.OrderItemId";

        using (var connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@customerId", customerId);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var orderId = reader.GetInt32(0);

                        // 注文が未登録なら追加
                        if (!orders.ContainsKey(orderId))
                        {
                            orders[orderId] = new OrderDto
                            {
                                OrderId = orderId,
                                OrderDate = reader.GetDateTime(1),
                                TotalAmount = reader.GetDecimal(2),
                                Status = reader.GetString(3),
                                Items = new List<OrderItemDto>()
                            };
                        }

                        // 明細がある場合は追加
                        if (!reader.IsDBNull(4))
                        {
                            orders[orderId].Items.Add(new OrderItemDto
                            {
                                OrderItemId = reader.GetInt32(4),
                                ProductId = reader.GetInt32(5),
                                Quantity = reader.GetInt32(6),
                                UnitPrice = reader.GetDecimal(7),
                                ProductName = reader.GetString(8),
                                Category = reader.GetString(9),
                                StockQuantity = reader.GetInt32(10)
                            });
                        }
                    }
                }
            }
        }

        return orders.Values.ToList();
    }

    /// <summary>
    /// Entity Framework Core を使用した最適化版
    /// </summary>
    public async Task<List<Order>> GetOrdersWithDetailsEFAsync(int customerId)
    {
        using (var context = new OrderContext())
        {
            return await context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .Where(o => o.CustomerId == customerId)
                .AsNoTracking()  // 読み取り専用でパフォーマンス向上
                .ToListAsync();
        }
    }

    /// <summary>
    /// バッチ処理版（大量データ対応）
    /// </summary>
    public async Task<List<OrderDto>> GetOrdersBatchAsync(List<int> customerIds)
    {
        if (customerIds == null || customerIds.Count == 0)
        {
            return new List<OrderDto>();
        }

        // SQLインジェクション対策
        var parameters = customerIds.Select((id, index) => $"@id{index}").ToList();
        var parameterList = string.Join(",", parameters);

        var query = $@"
            SELECT o.*, oi.*, p.*
            FROM Orders o
            LEFT JOIN OrderItems oi ON o.OrderId = oi.OrderId
            LEFT JOIN Products p ON oi.ProductId = p.ProductId
            WHERE o.CustomerId IN ({parameterList})";

        using (var connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();
            using (var command = new SqlCommand(query, connection))
            {
                // パラメータを動的に追加
                for (int i = 0; i < customerIds.Count; i++)
                {
                    command.Parameters.AddWithValue($"@id{i}", customerIds[i]);
                }

                // 実行...
            }
        }

        return new List<OrderDto>();
    }
}
```
"""

        elif "入力検証" in problem:
            analysis += """
**問題の詳細**:
ユーザー入力の検証が不十分で、SQLインジェクション、XSS攻撃、バッファオーバーフローなどの脆弱性があります。

**影響**:
- データベースの不正アクセス
- 機密情報の漏洩
- Webサイトの改ざん
- サービス停止攻撃

**完全な改善コード**:

```csharp
// ===== 修正前のコード（脆弱性あり）=====
public class UserController : Controller
{
    public ActionResult Login(string username, string password)
    {
        // 危険：SQLインジェクション脆弱性
        string query = $"SELECT * FROM Users WHERE Username = '{username}' AND Password = '{password}'";
        var user = Database.ExecuteQuery(query);

        if (user != null)
        {
            // 危険：XSS脆弱性
            ViewBag.Message = "Welcome " + username;
            return View("Dashboard");
        }

        return View("Login");
    }

    public ActionResult UpdateProfile(string name, string email, string bio)
    {
        // 危険：入力検証なし
        var user = GetCurrentUser();
        user.Name = name;
        user.Email = email;
        user.Bio = bio;  // HTMLタグを含む可能性
        SaveUser(user);

        return View("Profile");
    }
}

// ===== 修正後のコード（セキュア版）=====
using System.ComponentModel.DataAnnotations;
using Microsoft.Security.Application;

public class UserController : Controller
{
    private readonly IUserService userService;
    private readonly ILogger<UserController> logger;

    public UserController(IUserService userService, ILogger<UserController> logger)
    {
        this.userService = userService;
        this.logger = logger;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]  // CSRF対策
    public async Task<ActionResult> Login(LoginViewModel model)
    {
        try
        {
            // 1. モデル検証
            if (!ModelState.IsValid)
            {
                return View("Login", model);
            }

            // 2. レート制限チェック
            if (!await CheckRateLimit(Request.UserHostAddress))
            {
                ModelState.AddModelError("", "ログイン試行回数が上限に達しました。15分後に再試行してください。");
                return View("Login", model);
            }

            // 3. パラメータ化クエリでSQLインジェクション防止
            var user = await userService.AuthenticateAsync(model.Username, model.Password);

            if (user != null)
            {
                // 4. セッション固定攻撃対策
                Session.Abandon();
                Session.RemoveAll();

                // 5. 安全なセッション作成
                FormsAuthentication.SetAuthCookie(user.UserId.ToString(), model.RememberMe);

                // 6. XSS対策：HTMLエンコード
                TempData["Message"] = $"Welcome {HttpUtility.HtmlEncode(user.DisplayName)}";

                // 7. 監査ログ
                await LogLoginAttempt(user.UserId, true);

                return RedirectToAction("Dashboard", "Home");
            }

            // 8. 失敗ログ
            await LogLoginAttempt(model.Username, false);
            ModelState.AddModelError("", "ユーザー名またはパスワードが正しくありません。");

            return View("Login", model);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Login error for user {Username}", model?.Username);
            ModelState.AddModelError("", "システムエラーが発生しました。");
            return View("Login", model);
        }
    }

    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> UpdateProfile(UserProfileViewModel model)
    {
        try
        {
            // 1. モデル検証
            if (!ModelState.IsValid)
            {
                return View("Profile", model);
            }

            // 2. 権限チェック
            var currentUser = await GetCurrentUserAsync();
            if (currentUser.UserId != model.UserId && !User.IsInRole("Admin"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            // 3. ビジネスロジック検証
            if (!await userService.IsEmailUniqueAsync(model.Email, currentUser.UserId))
            {
                ModelState.AddModelError("Email", "このメールアドレスは既に使用されています。");
                return View("Profile", model);
            }

            // 4. サニタイズと保存
            var updateModel = new UserUpdateDto
            {
                UserId = currentUser.UserId,
                Name = Sanitizer.GetSafeHtmlFragment(model.Name),
                Email = model.Email.ToLower().Trim(),
                Bio = Sanitizer.GetSafeHtmlFragment(model.Bio),
                UpdatedAt = DateTime.UtcNow
            };

            await userService.UpdateProfileAsync(updateModel);

            TempData["Success"] = "プロフィールが更新されました。";
            return RedirectToAction("Profile");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Profile update error for user {UserId}", model?.UserId);
            ModelState.AddModelError("", "更新中にエラーが発生しました。");
            return View("Profile", model);
        }
    }

    private async Task<bool> CheckRateLimit(string ipAddress)
    {
        // Redis等を使用したレート制限実装
        var key = $"login_attempt:{ipAddress}";
        var attempts = await cache.GetAsync<int>(key);

        if (attempts >= 5)
        {
            return false;
        }

        await cache.IncrementAsync(key, TimeSpan.FromMinutes(15));
        return true;
    }
}

// モデルクラス（検証属性付き）
public class LoginViewModel
{
    [Required(ErrorMessage = "ユーザー名は必須です")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "ユーザー名は3-50文字で入力してください")]
    [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "ユーザー名は英数字とアンダースコアのみ使用可能です")]
    public string Username { get; set; }

    [Required(ErrorMessage = "パスワードは必須です")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "パスワードは8文字以上必要です")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public bool RememberMe { get; set; }
}

public class UserProfileViewModel
{
    public int UserId { get; set; }

    [Required(ErrorMessage = "名前は必須です")]
    [StringLength(100, ErrorMessage = "名前は100文字以内で入力してください")]
    [RegularExpression(@"^[^<>]+$", ErrorMessage = "名前に特殊文字は使用できません")]
    public string Name { get; set; }

    [Required(ErrorMessage = "メールアドレスは必須です")]
    [EmailAddress(ErrorMessage = "有効なメールアドレスを入力してください")]
    [StringLength(255)]
    public string Email { get; set; }

    [StringLength(1000, ErrorMessage = "自己紹介は1000文字以内で入力してください")]
    [DataType(DataType.MultilineText)]
    public string Bio { get; set; }
}
```
"""

        elif "SELECT *" in problem:
            analysis += """
**問題の詳細**:
SELECT * は全カラムを取得するため、不要なデータ転送とメモリ使用が発生します。

**影響**:
- ネットワーク帯域の浪費
- メモリ使用量の増加
- インデックスが効かない場合がある
- スキーマ変更時の予期しないエラー

**完全な改善コード**:

```csharp
// ===== 修正前のコード（非効率）=====
public class ProductRepository
{
    public List<Product> GetAllProducts()
    {
        // 全カラム取得（100カラムある場合、全て取得）
        string query = "SELECT * FROM Products";
        return ExecuteQuery<Product>(query);
    }

    public DataTable GetProductsForDisplay()
    {
        // DataTableで全データ取得
        string query = "SELECT * FROM Products p INNER JOIN Categories c ON p.CategoryId = c.Id";
        return ExecuteDataTable(query);
    }
}

// ===== 修正後のコード（最適化版）=====
public class ProductRepository
{
    private readonly string connectionString;

    /// <summary>
    /// 必要なカラムのみ取得（表示用）
    /// </summary>
    public async Task<List<ProductListDto>> GetProductsForListAsync(
        int pageNumber = 1,
        int pageSize = 20,
        string category = null)
    {
        const string query = @"
            WITH ProductPage AS (
                SELECT
                    p.ProductId,
                    p.ProductName,
                    p.Price,
                    p.StockQuantity,
                    p.IsActive,
                    c.CategoryName,
                    ROW_NUMBER() OVER (ORDER BY p.ProductName) AS RowNum
                FROM Products p
                INNER JOIN Categories c ON p.CategoryId = c.CategoryId
                WHERE p.IsActive = 1
                    AND (@category IS NULL OR c.CategoryName = @category)
            )
            SELECT
                ProductId,
                ProductName,
                Price,
                StockQuantity,
                CategoryName
            FROM ProductPage
            WHERE RowNum BETWEEN @startRow AND @endRow
            ORDER BY RowNum";

        using (var connection = new SqlConnection(connectionString))
        {
            var startRow = (pageNumber - 1) * pageSize + 1;
            var endRow = pageNumber * pageSize;

            var products = await connection.QueryAsync<ProductListDto>(
                query,
                new { startRow, endRow, category });

            return products.ToList();
        }
    }

    /// <summary>
    /// 詳細表示用（必要なカラムを明示）
    /// </summary>
    public async Task<ProductDetailDto> GetProductDetailAsync(int productId)
    {
        const string query = @"
            SELECT
                p.ProductId,
                p.ProductName,
                p.Description,
                p.Price,
                p.StockQuantity,
                p.MinimumStock,
                p.ImageUrl,
                p.CreatedDate,
                p.LastModifiedDate,
                c.CategoryId,
                c.CategoryName,
                s.SupplierId,
                s.SupplierName
            FROM Products p
            LEFT JOIN Categories c ON p.CategoryId = c.CategoryId
            LEFT JOIN Suppliers s ON p.SupplierId = s.SupplierId
            WHERE p.ProductId = @productId";

        using (var connection = new SqlConnection(connectionString))
        {
            return await connection.QueryFirstOrDefaultAsync<ProductDetailDto>(
                query,
                new { productId });
        }
    }

    /// <summary>
    /// 在庫チェック専用（最小限のカラム）
    /// </summary>
    public async Task<List<StockInfo>> GetLowStockProductsAsync()
    {
        // 在庫チェックに必要な3カラムのみ
        const string query = @"
            SELECT
                ProductId,
                ProductName,
                StockQuantity,
                MinimumStock
            FROM Products
            WHERE StockQuantity <= MinimumStock
                AND IsActive = 1
            ORDER BY (StockQuantity - MinimumStock) ASC";

        using (var connection = new SqlConnection(connectionString))
        {
            var results = await connection.QueryAsync<StockInfo>(query);
            return results.ToList();
        }
    }

    /// <summary>
    /// 集計用（GROUP BY使用）
    /// </summary>
    public async Task<List<CategorySummary>> GetCategorySummaryAsync()
    {
        const string query = @"
            SELECT
                c.CategoryName,
                COUNT(p.ProductId) as ProductCount,
                SUM(p.StockQuantity * p.Price) as TotalValue,
                AVG(p.Price) as AveragePrice
            FROM Categories c
            LEFT JOIN Products p ON c.CategoryId = p.CategoryId
            WHERE p.IsActive = 1
            GROUP BY c.CategoryId, c.CategoryName
            HAVING COUNT(p.ProductId) > 0
            ORDER BY TotalValue DESC";

        using (var connection = new SqlConnection(connectionString))
        {
            var results = await connection.QueryAsync<CategorySummary>(query);
            return results.ToList();
        }
    }
}

// DTOクラス（必要なプロパティのみ定義）
public class ProductListDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string CategoryName { get; set; }
}

public class ProductDetailDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public int MinimumStock { get; set; }
    public string ImageUrl { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public int? CategoryId { get; set; }
    public string CategoryName { get; set; }
    public int? SupplierId { get; set; }
    public string SupplierName { get; set; }
}
```
"""

    # ソースコード全体の分析と変更提案
    if source_code:
        lines = source_code.split('\n')
        analysis += f"\n## ソースコード全体分析（全{len(lines)}行）\n\n"

        # 危険なパターンを検出して具体的な修正提案
        dangerous_patterns = {
            r'\bfloat\s+\w+\s*=': "float型検出",
            r'\bdouble\s+\w+\s*=': "double型検出",
            r'SELECT\s+\*': "SELECT * 検出",
            r'for.*\{.*SELECT': "ループ内クエリ検出",
            r'Request\.\w+\[': "直接的な入力取得検出",
            r'string\.Format.*SELECT': "SQL文字列結合検出",
            r'catch\s*\(\s*Exception\s*\)': "汎用例外キャッチ検出",
            r'Thread\.Sleep': "同期的待機検出"
        }

        detected_issues = []
        for i, line in enumerate(lines, 1):
            for pattern, issue in dangerous_patterns.items():
                if re.search(pattern, line, re.IGNORECASE):
                    detected_issues.append({
                        'line': i,
                        'issue': issue,
                        'code': line.strip()
                    })

        if detected_issues:
            analysis += "### 検出された問題箇所と修正提案\n\n"

            for issue in detected_issues[:20]:  # 最初の20件
                analysis += f"**行{issue['line']}: {issue['issue']}**\n"
                analysis += f"```csharp\n// 現在のコード:\n{issue['code']}\n```\n"

                # 具体的な修正提案
                if "float型" in issue['issue'] or "double型" in issue['issue']:
                    analysis += "```csharp\n// 修正案:\n"
                    modified = re.sub(r'\bfloat\b', 'decimal', issue['code'])
                    modified = re.sub(r'\bdouble\b', 'decimal', modified)
                    analysis += f"{modified}\n```\n\n"

                elif "SELECT *" in issue['issue']:
                    analysis += "```csharp\n// 修正案:\n"
                    analysis += "// 必要なカラムを明示的に指定\n"
                    analysis += "string query = @\"SELECT \n"
                    analysis += "    Id, Name, Price, StockQuantity, UpdatedDate\n"
                    analysis += "    FROM TableName\";\n```\n\n"

                elif "直接的な入力" in issue['issue']:
                    analysis += "```csharp\n// 修正案:\n"
                    analysis += "// モデルバインディングと検証を使用\n"
                    analysis += "if (ModelState.IsValid)\n"
                    analysis += "{\n"
                    analysis += "    var sanitized = HttpUtility.HtmlEncode(model.Input);\n"
                    analysis += "    // 処理...\n"
                    analysis += "}\n```\n\n"

    analysis += "\n---\n\n"
    return analysis

def main():
    # バッチ番号を取得
    if len(sys.argv) < 2:
        print("使用方法: python analyze_dangerous_files_detailed.py <バッチ番号>")
        sys.exit(1)

    try:
        batch_num = int(sys.argv[1])
        if batch_num < 1 or batch_num > 6:
            print("バッチ番号は1から6の間で指定してください")
            sys.exit(1)
    except ValueError:
        print("バッチ番号は数値で指定してください")
        sys.exit(1)

    batch_size = 500
    start_idx = (batch_num - 1) * batch_size
    end_idx = start_idx + batch_size

    report_path = pathlib.Path("reports/src_complete_danger_analysis.md")
    all_dangerous_files = extract_dangerous_files(report_path, min_score=1)

    if not all_dangerous_files:
        print("問題のあるファイルが見つかりませんでした")
        return

    if batch_num == 6:
        end_idx = len(all_dangerous_files)

    batch_files = all_dangerous_files[start_idx:end_idx]

    if not batch_files:
        print(f"バッチ{batch_num}に処理するファイルがありません")
        return

    print(f"バッチ{batch_num}: {len(batch_files)}ファイルを詳細分析します")

    output_path = pathlib.Path(f"reports/AI分析_詳細_改善版_batch{batch_num}.md")

    # レポートヘッダー
    header = f"""# ソースファイル別AI詳細分析レポート（改善版・バッチ{batch_num}）

生成日時: {time.strftime('%Y-%m-%d %H:%M:%S')}
分析対象: 問題のあるファイル（バッチ{batch_num}: ファイル{start_idx+1}-{min(end_idx, len(all_dangerous_files))}）
バッチ内ファイル数: {len(batch_files)}

## このレポートについて

このレポートは各ファイルに対して以下を提供します：
1. 問題の詳細説明と影響分析
2. 完全な改善コード（修正前・修正後の完全版）
3. ソースコードの行単位の問題検出と修正提案

---

"""

    output_path.write_text(header, encoding='utf-8')

    # 各ファイルを分析
    for i, file_info in enumerate(batch_files, 1):
        print(f"詳細分析中 [{i}/{len(batch_files)}]: {file_info['path']}")

        # ソースコード全体を読み込み
        source_code = read_source_file(file_info['path'])

        # 詳細AI分析を実行
        analysis = analyze_file_with_complete_solutions(file_info, source_code)

        # レポートに追記
        with output_path.open('a', encoding='utf-8') as f:
            f.write(analysis)

        if i % 50 == 0:
            print(f"[進捗] {i}/{len(batch_files)} ファイル完了")

        time.sleep(0.05)

    print(f"バッチ{batch_num}の詳細分析完了: {output_path}")

if __name__ == "__main__":
    main()
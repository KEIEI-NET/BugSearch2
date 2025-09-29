#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
改良版フォーマットのテスト
"""

def generate_sample_report():
    """サンプルレポート生成"""

    sample = """
# src/test/sample_code.cs

## 📊 危険度分析
- **危険度スコア**: 25
- **危険度レベル**: [緊急]
- **検出された問題**: 金額計算に浮動小数点使用, SQLインジェクション脆弱性, N+1問題

## 🔍 詳細分析と完全な改善提案

### 🚨 金額計算に浮動小数点使用

**問題の詳細**:
OrderCalculator.cs の 45行目から68行目で、金額計算に double型を使用しています。
浮動小数点数は2進数表現の制約により、10進数の金額を正確に表現できません。
特に税計算（8%）や割引計算で累積誤差が発生します。

**影響**:
- 請求金額に1円単位の誤差が発生（月間数千件で数千円の誤差）
- 会計監査での不整合（法的リスク）
- 顧客クレームの原因
- 消費税申告の誤り

**完全な改善コード**:

```csharp
// ===== 修正前のコード（問題あり）=====
public class OrderCalculator
{
    private double subtotal;          // 危険: double型使用
    private double taxRate = 0.08;    // 危険: 浮動小数点での税率

    public double CalculateTotal(List<OrderItem> items)
    {
        double total = 0;
        foreach (var item in items)
        {
            // 危険: 浮動小数点での金額計算
            double itemPrice = item.Price * item.Quantity;
            total += itemPrice;
        }

        // 危険: 税計算で誤差発生
        double tax = total * taxRate;
        return total + tax;
    }
}

// ===== 修正後のコード（改善版）=====
using System;
using System.Collections.Generic;
using System.Globalization;

public class OrderCalculator
{
    private decimal subtotal;                      // 改善: decimal型使用
    private readonly decimal taxRate = 0.08m;      // 改善: decimal型で正確な税率

    /// <summary>
    /// 注文の合計金額を計算（税込）
    /// </summary>
    /// <param name="items">注文項目リスト</param>
    /// <returns>税込合計金額</returns>
    public decimal CalculateTotal(List<OrderItem> items)
    {
        // 入力検証
        if (items == null || items.Count == 0)
        {
            throw new ArgumentException("注文項目が空です", nameof(items));
        }

        decimal total = 0m;

        foreach (var item in items)
        {
            // 各項目の検証
            ValidateOrderItem(item);

            // 正確な金額計算（decimal型）
            decimal itemPrice = item.Price * item.Quantity;

            // 丸め処理（銀行丸め）
            itemPrice = Math.Round(itemPrice, 2, MidpointRounding.ToEven);

            total += itemPrice;
        }

        // 税計算（切り捨て）
        decimal tax = Math.Floor(total * taxRate);

        return total + tax;
    }

    /// <summary>
    /// 注文項目の検証
    /// </summary>
    private void ValidateOrderItem(OrderItem item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        if (item.Price < 0)
        {
            throw new ArgumentException($"不正な価格: {item.Price}", nameof(item.Price));
        }

        if (item.Quantity <= 0)
        {
            throw new ArgumentException($"不正な数量: {item.Quantity}", nameof(item.Quantity));
        }
    }

    /// <summary>
    /// 金額を日本円形式でフォーマット
    /// </summary>
    public static string FormatCurrency(decimal amount)
    {
        return amount.ToString("C0", CultureInfo.GetCultureInfo("ja-JP"));
    }
}

// 注文項目クラス
public class OrderItem
{
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string ProductName { get; set; }
}
```

**追加の推奨事項**:

1. **単体テストの実装**:
```csharp
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

    // 期待値と完全一致を確認
    Assert.AreEqual(5828.91m, total);
}
```

2. **設定ファイルでの税率管理**:
```json
{
  "TaxSettings": {
    "StandardRate": 0.10,
    "ReducedRate": 0.08,
    "EffectiveDate": "2019-10-01"
  }
}
```

### 🚨 SQLインジェクション脆弱性

**問題の詳細**:
UserController.cs の 102行目で、ユーザー入力を直接SQL文字列に結合しています。

**影響**:
- データベース全体へのアクセス
- 機密情報の漏洩
- データの改ざん・削除
- サーバーの乗っ取り

**完全な改善コード**:

```csharp
// ===== 修正前のコード（脆弱性あり）=====
public User GetUser(string username)
{
    // 危険: SQLインジェクション脆弱性
    string query = $"SELECT * FROM Users WHERE Username = '{username}'";
    return Database.ExecuteQuery<User>(query);
}

// ===== 修正後のコード（セキュア版）=====
using System.Data.SqlClient;
using System.Data;

public User GetUser(string username)
{
    // 入力検証
    if (string.IsNullOrWhiteSpace(username))
    {
        throw new ArgumentException("ユーザー名が無効です");
    }

    // パラメータ化クエリで安全に実行
    using (var connection = new SqlConnection(connectionString))
    using (var command = new SqlCommand())
    {
        command.Connection = connection;
        command.CommandText = @"
            SELECT UserId, Username, Email, CreatedAt
            FROM Users
            WHERE Username = @Username
            AND IsActive = 1";

        // パラメータバインディング（SQLインジェクション対策）
        command.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username;

        connection.Open();

        using (var reader = command.ExecuteReader())
        {
            if (reader.Read())
            {
                return new User
                {
                    UserId = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    Email = reader.GetString(2),
                    CreatedAt = reader.GetDateTime(3)
                };
            }
        }
    }

    return null;
}
```

## 総合評価

- **緊急度**: 緊急（24時間以内の対応推奨）
- **修正工数**: 8-12時間（テスト含む）
- **影響範囲**: 決済システム全体、ユーザー認証モジュール

---
"""

    return sample

# テスト実行
if __name__ == "__main__":
    sample_report = generate_sample_report()

    # reports/sample_enhanced_format.md として保存
    with open("reports/sample_enhanced_format.md", "w", encoding="utf-8") as f:
        f.write("# 改良版フォーマットサンプル\n\n")
        f.write("生成日時: 2025-09-29\n\n")
        f.write(sample_report)

    print("サンプルレポートを生成しました: reports/sample_enhanced_format.md")
    print("\nプレビュー:")
    print(sample_report[:1000])
    print("...")
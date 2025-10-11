// N+1 Query Problem サンプル (C#)
// このファイルはテスト用です

using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BugSearchTest
{
    public class OrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        // ❌ 悪い例: N+1問題が発生
        public void ProcessOrders_Bad()
        {
            var orders = _context.Orders.ToList();

            foreach (var order in orders)
            {
                // ループ内でクエリ実行 → N+1問題
                var customer = _context.Customers
                    .Where(c => c.Id == order.CustomerId)
                    .FirstOrDefault();

                var items = _context.OrderItems
                    .Where(i => i.OrderId == order.Id)
                    .ToList();

                // 処理...
            }
        }

        // ✅ 良い例: Include()でeager loading
        public void ProcessOrders_Good()
        {
            var orders = _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .ToList();

            foreach (var order in orders)
            {
                // もうクエリは実行されない
                var customer = order.Customer;
                var items = order.OrderItems;

                // 処理...
            }
        }
    }
}

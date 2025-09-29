<?php
// ECサイトのショッピングカート（問題のあるコード）

session_start();

// 非推奨のmysql関数を使用
$db = mysql_connect('localhost', 'shop_user', 'password123');
mysql_select_db('shop_db', $db);

class ShoppingCart {
    private $items = [];
    private $total = 0.0; // 危険: float型で金額管理

    public function addItem($product_id, $quantity) {
        // SQLインジェクション脆弱性
        $query = "SELECT * FROM products WHERE id = " . $product_id;
        $result = mysql_query($query);

        if ($product = mysql_fetch_assoc($result)) {
            // 金額計算に浮動小数点使用（精度問題）
            $price = (float)$product['price'];
            $subtotal = $price * $quantity;

            // 税金計算（端数処理が不適切）
            $tax_rate = 0.08;
            $tax = $subtotal * $tax_rate;
            $total_with_tax = $subtotal + $tax;

            $this->items[] = [
                'product_id' => $product_id,
                'name' => $product['name'],
                'price' => $price,
                'quantity' => $quantity,
                'subtotal' => $subtotal,
                'tax' => $tax,
                'total' => $total_with_tax
            ];

            // 合計金額の更新（浮動小数点の累積誤差）
            $this->total += $total_with_tax;
        }
    }

    public function displayCart() {
        // XSS脆弱性（商品名をエスケープしない）
        foreach ($this->items as $item) {
            echo "<div class='cart-item'>";
            echo "商品名: " . $item['name'] . "<br>";
            echo "価格: ￥" . $item['price'] . "<br>";
            echo "数量: " . $item['quantity'] . "<br>";
            echo "小計: ￥" . $item['subtotal'] . "<br>";
            echo "税額: ￥" . $item['tax'] . "<br>";
            echo "合計: ￥" . $item['total'] . "<br>";
            echo "</div>";
        }

        // 総合計（精度問題）
        echo "<div class='total'>総合計: ￥" . $this->total . "</div>";
    }

    // N+1問題を引き起こすメソッド
    public function getRecommendations() {
        $recommendations = [];

        // ループ内でSQL実行（N+1問題）
        foreach ($this->items as $item) {
            $query = "SELECT * FROM products WHERE category = (
                        SELECT category FROM products WHERE id = " . $item['product_id'] . "
                      ) LIMIT 5";
            $result = mysql_query($query);

            while ($row = mysql_fetch_assoc($result)) {
                $recommendations[] = $row;
            }
        }

        return $recommendations;
    }

    // 大量データ取得
    public function getAllOrders($user_id) {
        // SELECT * と大きなLIMIT
        $query = "SELECT * FROM orders WHERE user_id = $user_id LIMIT 10000";
        return mysql_query($query);
    }

    // 複雑なJOIN
    public function getOrderHistory($user_id) {
        // 多重JOIN（パフォーマンス問題）
        $query = "SELECT * FROM orders o
                  JOIN order_items oi ON o.id = oi.order_id
                  JOIN products p ON oi.product_id = p.id
                  JOIN categories c ON p.category_id = c.id
                  JOIN suppliers s ON p.supplier_id = s.id
                  JOIN warehouses w ON s.warehouse_id = w.id
                  WHERE o.user_id = $user_id";
        return mysql_query($query);
    }
}

// カート処理
$cart = new ShoppingCart();

// ユーザー入力を直接使用（危険）
if (isset($_POST['add_to_cart'])) {
    $product_id = $_POST['product_id'];
    $quantity = $_POST['quantity'];

    // 入力検証なし
    $cart->addItem($product_id, $quantity);
}

// ファイル処理（ディレクトリトラバーサル脆弱性）
if (isset($_GET['export'])) {
    $filename = $_GET['export'];
    include("exports/" . $filename);
}

// セッション処理（固定化攻撃の脆弱性）
$_SESSION['cart'] = serialize($cart);

// エラー表示（本番環境で危険）
ini_set('display_errors', 1);

?>

<!DOCTYPE html>
<html>
<head>
    <title>ショッピングカート</title>
</head>
<body>
    <h1>ショッピングカート</h1>

    <!-- CSRF対策なしのフォーム -->
    <form method="post">
        <input type="hidden" name="product_id" value="<?= $_GET['pid'] ?>">
        <input type="number" name="quantity" value="1">
        <button type="submit" name="add_to_cart">カートに追加</button>
    </form>

    <?php $cart->displayCart(); ?>

    <!-- 多重クリック防止なし -->
    <button onclick="checkout()">購入手続きへ</button>

    <script>
        // 多重送信対策なし
        function checkout() {
            window.location.href = 'checkout.php';
        }
    </script>
</body>
</html>
<?php
// 脆弱なログイン処理のサンプル（テスト用）

// エラー表示を有効化（本番環境では危険）
ini_set('display_errors', 1);
error_reporting(E_ALL);

// セッション開始
session_start();

// データベース接続（非推奨のmysql_*関数を使用）
$connection = mysql_connect('localhost', 'root', 'password');
mysql_select_db('users_db', $connection);

// ログイン処理
if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    $username = $_POST['username'];
    $password = $_POST['password'];

    // SQLインジェクション脆弱性
    $query = "SELECT * FROM users WHERE username = '$username' AND password = '$password'";
    $result = mysql_query($query);

    if (mysql_num_rows($result) > 0) {
        $user = mysql_fetch_array($result);

        // セッション固定化攻撃の脆弱性（session_regenerate_idなし）
        $_SESSION['user_id'] = $user['id'];
        $_SESSION['username'] = $user['username'];

        // XSS脆弱性（未エスケープ出力）
        echo "ようこそ、" . $_GET['name'] . "さん！";

        // ファイルインクルード脆弱性
        $page = $_GET['page'];
        include($page . '.php');

    } else {
        echo "ログイン失敗";
    }
}

// コマンドインジェクション
if (isset($_GET['cmd'])) {
    $command = $_GET['cmd'];
    system($command);
}

// extract()の危険な使用
extract($_POST);

// eval()の使用（危険）
if (isset($_GET['code'])) {
    eval($_GET['code']);
}

// ディレクトリトラバーサル脆弱性
if (isset($_GET['file'])) {
    $file = $_GET['file'];
    $content = file_get_contents($file);
    echo $content;
}

?>

<!DOCTYPE html>
<html>
<head>
    <title>ログインフォーム</title>
</head>
<body>
    <!-- CSRF対策なしのフォーム -->
    <form method="post" action="login.php">
        <input type="text" name="username" placeholder="ユーザー名">
        <input type="password" name="password" placeholder="パスワード">
        <button type="submit">ログイン</button>
    </form>
</body>
</html>
<?php
// セキュアなログイン処理のサンプル

// エラー表示は無効化（ログファイルに記録）
ini_set('display_errors', 0);
ini_set('log_errors', 1);
ini_set('error_log', '/var/log/php_errors.log');

// セッション設定
ini_set('session.cookie_httponly', 1);
ini_set('session.cookie_secure', 1);
ini_set('session.use_only_cookies', 1);

session_start();

// セッション固定化攻撃対策
if (!isset($_SESSION['initiated'])) {
    session_regenerate_id(true);
    $_SESSION['initiated'] = true;
}

// データベース接続（PDO使用）
try {
    $pdo = new PDO('mysql:host=localhost;dbname=users_db;charset=utf8mb4',
                   'username',
                   'password',
                   [PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION]);
} catch (PDOException $e) {
    error_log('Database connection failed: ' . $e->getMessage());
    die('システムエラーが発生しました。');
}

// CSRF対策トークンの生成
if (empty($_SESSION['csrf_token'])) {
    $_SESSION['csrf_token'] = bin2hex(random_bytes(32));
}

// ログイン処理
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    // CSRF対策チェック
    if (!isset($_POST['csrf_token']) || $_POST['csrf_token'] !== $_SESSION['csrf_token']) {
        die('不正なリクエストです。');
    }

    // 入力検証
    $username = filter_input(INPUT_POST, 'username', FILTER_SANITIZE_STRING);
    $password = filter_input(INPUT_POST, 'password', FILTER_SANITIZE_STRING);

    if (!$username || !$password) {
        $error = 'ユーザー名とパスワードを入力してください。';
    } else {
        try {
            // SQLインジェクション対策（プリペアドステートメント）
            $stmt = $pdo->prepare('SELECT id, username, password_hash FROM users WHERE username = :username');
            $stmt->bindParam(':username', $username, PDO::PARAM_STR);
            $stmt->execute();

            if ($user = $stmt->fetch(PDO::FETCH_ASSOC)) {
                // パスワード検証
                if (password_verify($password, $user['password_hash'])) {
                    // セッション再生成
                    session_regenerate_id(true);

                    $_SESSION['user_id'] = $user['id'];
                    $_SESSION['username'] = $user['username'];
                    $_SESSION['login_time'] = time();

                    // XSS対策（HTMLエスケープ）
                    $safe_username = htmlspecialchars($user['username'], ENT_QUOTES, 'UTF-8');
                    $success_message = "ようこそ、{$safe_username}さん！";

                    // 安全なリダイレクト
                    header('Location: /dashboard.php');
                    exit;
                } else {
                    $error = 'ログイン情報が正しくありません。';
                }
            } else {
                $error = 'ログイン情報が正しくありません。';
            }
        } catch (PDOException $e) {
            error_log('Login query failed: ' . $e->getMessage());
            $error = 'システムエラーが発生しました。';
        }
    }
}

// ファイルアクセスの安全な処理
if (isset($_GET['page'])) {
    $allowed_pages = ['home', 'profile', 'settings'];
    $page = basename($_GET['page']); // ディレクトリトラバーサル対策

    if (in_array($page, $allowed_pages, true)) {
        $file_path = __DIR__ . '/pages/' . $page . '.php';
        if (file_exists($file_path)) {
            include $file_path;
        }
    }
}

?>

<!DOCTYPE html>
<html lang="ja">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>セキュアログインフォーム</title>
    <meta http-equiv="Content-Security-Policy" content="default-src 'self'">
</head>
<body>
    <h1>ログイン</h1>

    <?php if (isset($error)): ?>
        <div class="error"><?= htmlspecialchars($error, ENT_QUOTES, 'UTF-8') ?></div>
    <?php endif; ?>

    <?php if (isset($success_message)): ?>
        <div class="success"><?= htmlspecialchars($success_message, ENT_QUOTES, 'UTF-8') ?></div>
    <?php endif; ?>

    <form method="post" action="">
        <!-- CSRF対策トークン -->
        <input type="hidden" name="csrf_token" value="<?= htmlspecialchars($_SESSION['csrf_token'], ENT_QUOTES, 'UTF-8') ?>">

        <div>
            <label for="username">ユーザー名:</label>
            <input type="text" id="username" name="username" required maxlength="50"
                   pattern="[a-zA-Z0-9_]{3,50}" title="英数字とアンダースコアで3-50文字">
        </div>

        <div>
            <label for="password">パスワード:</label>
            <input type="password" id="password" name="password" required
                   minlength="8" maxlength="100">
        </div>

        <button type="submit">ログイン</button>
    </form>
</body>
</html>
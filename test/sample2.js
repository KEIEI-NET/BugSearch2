// テスト用の危険なJavaScriptコード
function displayUserInput() {
    // XSS脆弱性
    const userInput = document.getElementById('input').value;
    document.getElementById('output').innerHTML = userInput; // 危険: XSS

    // 認証バイパスの可能性
    if (userInput == "admin") {  // 危険: == 使用
        grantAdminAccess();
    }
}

function checkAuth(token) {
    // 脆弱な認証チェック
    if (token) {  // 危険: 単純なチェックのみ
        return true;
    }
    return false;
}
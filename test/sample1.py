# テスト用の危険なコード例
import mysql.connector

def get_user_data(user_id):
    # SQLインジェクション脆弱性
    query = f"SELECT * FROM users WHERE id = {user_id}"

    # ハードコードされたパスワード
    password = "admin123"

    conn = mysql.connector.connect(
        host="localhost",
        user="root",
        password=password  # 危険: ハードコード
    )

    cursor = conn.cursor()
    cursor.execute(query)  # 危険: SQLインジェクション

    return cursor.fetchall()

def process_payment(amount):
    # 金額処理でfloat使用（危険）
    total = float(amount) * 1.08
    return total
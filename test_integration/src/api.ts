
// セキュリティ問題: エラーハンドリング不足
export async function fetchData(url: string) {
  const response = await fetch(url);
  return response.json(); // エラーチェックなし
}

// パフォーマンス問題: キャッシュなし
export async function loadUserData(userId: string) {
  const data = await fetchData(`/api/users/${userId}`);
  return data;
}

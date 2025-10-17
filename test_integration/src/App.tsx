
import React, { useState, useEffect } from 'react';

// 意図的な問題コード（テスト用）
function App() {
  const [data, setData] = useState<any[]>([]); // any使用（型安全性問題）

  useEffect(() => {
    // メモリリーク: cleanupなし
    const interval = setInterval(() => {
      console.log('Polling...');
    }, 1000);
  }, []);

  // XSS脆弱性
  const renderHTML = (html: string) => {
    return <div dangerouslySetInnerHTML={{ __html: html }} />;
  };

  // パフォーマンス問題: useCallbackなし
  const handleClick = () => {
    console.log('Clicked');
  };

  return (
    <div>
      <h1>Test App</h1>
      <button onClick={handleClick}>Click Me</button>
      {data.map((item, index) => (
        <div key={index}>{item.name}</div>
      ))}
    </div>
  );
}

export default App;

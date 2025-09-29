package main

import (
    "fmt"
    "os"
)

// テスト用の危険なGoコード
func readFile(path string) {
    // エラーチェック不足
    file, _ := os.Open(path)  // 危険: エラー無視
    defer file.Close()
}

func leakyGoroutine() {
    // Goroutineリーク
    go func() {
        for {
            fmt.Println("running...")
            // 終了条件なし - リーク
        }
    }()
}
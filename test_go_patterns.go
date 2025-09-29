package main

import (
    "fmt"
    "os"
    "time"
)

// Test 1: Error checking issues
func readFile(path string) {
    file, _ := os.Open(path)  // GO言語: エラーチェック不足
    defer file.Close()
}

// Test 2: Goroutine leak
func leakyGoroutine() {
    go func() {
        for {
            time.Sleep(1 * time.Second)
            // No exit condition - goroutine leak
        }
    }()
}

// Test 3: Channel deadlock potential
func deadlockExample() {
    ch := make(chan int)  // Unbuffered channel
    ch <- 42  // Will deadlock - no receiver
}

// Test 4: Defer in loop
func deferInLoop() {
    for i := 0; i < 1000; i++ {
        file, _ := os.Open("test.txt")
        defer file.Close()  // GO言語: ループ内のdefer
    }
}

// Test 5: No panic recovery
func noPanicRecovery() {
    // No defer recover() - unhandled panic
    panic("something went wrong")
}

// Test 6: Proper error handling (good example)
func properErrorHandling() error {
    file, err := os.Open("test.txt")
    if err != nil {
        return fmt.Errorf("failed to open file: %w", err)
    }
    defer file.Close()
    return nil
}

// Test 7: Proper goroutine with done channel (good example)
func properGoroutine(done <-chan bool) {
    go func() {
        for {
            select {
            case <-done:
                return
            case <-time.After(1 * time.Second):
                fmt.Println("working...")
            }
        }
    }()
}

func main() {
    fmt.Println("Go pattern test file")
}
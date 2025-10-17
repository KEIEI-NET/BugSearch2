#!/usr/bin/env python3
"""
新しいタグシステムのテスト

9言語・22技術スタック・18トピックに対応したタグ生成を検証します。
"""

import sys
import re
from pathlib import Path

# codex_review_severity.py から make_tags 関数をインポート
sys.path.insert(0, str(Path(__file__).parent))
from codex_review_severity import make_tags

def test_tag_system():
    """タグシステムの動作確認"""
    print("="*80)
    print("新しいタグシステムのテスト")
    print("="*80)
    print()

    # テストケース1: TypeScript + Angular
    print("【テスト1】TypeScript + Angular コンポーネント")
    typescript_angular_code = """
    import { Component, OnInit } from '@angular/core';

    @Component({
      selector: 'app-test',
      templateUrl: './test.component.html'
    })
    export class TestComponent implements OnInit {
      private apiUrl = 'https://api.example.com';

      ngOnInit(): void {
        // データベースクエリ
        const query = 'SELECT * FROM users WHERE id = ?';

        // 金額計算
        const total = price * (1 + tax);

        // UIボタン
        const button = document.querySelector('button');
      }
    }
    """
    tags = make_tags(typescript_angular_code, "typescript")
    print(f"生成されたタグ: {tags}")
    print(f"タグ数: {len(tags)}")
    print()

    # テストケース2: Go + 並行処理
    print("【テスト2】Go + 並行処理")
    go_code = """
    package main

    import (
        "context"
        "fmt"
        "sync"
    )

    func main() {
        var wg sync.WaitGroup
        ch := make(chan int)

        go func() {
            defer wg.Done()
            // goroutine処理
        }()

        // エラーハンドリング
        if err != nil {
            panic(err)
        }
    }
    """
    tags = make_tags(go_code, "go")
    print(f"生成されたタグ: {tags}")
    print(f"タグ数: {len(tags)}")
    print()

    # テストケース3: Python + Django + PostgreSQL
    print("【テスト3】Python + Django + PostgreSQL")
    python_django_code = """
    from django.db import models
    from django.http import HttpResponse
    import psycopg2

    class Product(models.Model):
        name = models.CharField(max_length=100)
        price = models.DecimalField(max_digits=10, decimal_places=2)

        def calculate_total(self):
            # 金額計算
            tax = 0.10
            return self.price * (1 + tax)

    def product_list(request):
        # データベースクエリ
        products = Product.objects.all()
        return HttpResponse("Product List")
    """
    tags = make_tags(python_django_code, "python")
    print(f"生成されたタグ: {tags}")
    print(f"タグ数: {len(tags)}")
    print()

    # テストケース4: React + TypeScript + API統合
    print("【テスト4】React + TypeScript + API統合")
    react_typescript_code = """
    import React, { useState, useEffect } from 'react';
    import axios from 'axios';

    interface User {
        id: number;
        name: string;
    }

    const UserList: React.FC = () => {
        const [users, setUsers] = useState<User[]>([]);

        useEffect(() => {
            // API統合
            axios.get<User[]>('/api/users')
                .then(response => setUsers(response.data))
                .catch(error => console.error(error));
        }, []);

        return (
            <div>
                {users.map(user => (
                    <button key={user.id} onClick={() => handleClick(user)}>
                        {user.name}
                    </button>
                ))}
            </div>
        );
    };
    """
    tags = make_tags(react_typescript_code, "typescript")
    print(f"生成されたタグ: {tags}")
    print(f"タグ数: {len(tags)}")
    print()

    # テストケース5: C# + Entity Framework + SQL Server
    print("【テスト5】C# + Entity Framework + SQL Server")
    csharp_code = """
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Data.SqlClient;

    public class OrderService
    {
        private readonly AppDbContext _context;

        public void ProcessOrders()
        {
            // データベースクエリ (N+1問題)
            var orders = _context.Orders.ToList();

            foreach (var order in orders)
            {
                // ループ内でクエリ実行
                var customer = _context.Customers
                    .Where(c => c.Id == order.CustomerId)
                    .FirstOrDefault();

                // 金額計算
                decimal total = order.Amount * 1.1m;
            }
        }
    }
    """
    tags = make_tags(csharp_code, "csharp")
    print(f"生成されたタグ: {tags}")
    print(f"タグ数: {len(tags)}")
    print()

    # テストケース6: Delphi + メモリ管理
    print("【テスト6】Delphi + メモリ管理")
    delphi_code = """
    unit OrderUnit;

    interface

    uses
      System.SysUtils, Data.DB, FireDAC.Comp.Client;

    type
      TOrderService = class(TObject)
      private
        FQuery: TFDQuery;
      public
        constructor Create;
        destructor Destroy; override;
        procedure LoadOrders;
      end;

    implementation

    constructor TOrderService.Create;
    begin
      inherited Create;
      FQuery := TFDQuery.Create(nil);
      // メモリ管理
      GetMem(Buffer, 1024);
    end;

    procedure TOrderService.LoadOrders;
    var
      OrderList: TStringList;
    begin
      OrderList := TStringList.Create;
      try
        // データベースクエリ
        FQuery.SQL.Text := 'SELECT * FROM Orders';
        FQuery.Open;
      finally
        OrderList.Free;
      end;
    end;

    end.
    """
    tags = make_tags(delphi_code, "delphi")
    print(f"生成されたタグ: {tags}")
    print(f"タグ数: {len(tags)}")
    print()

    # サマリー
    print("="*80)
    print("【サマリー】")
    print("新しいタグシステムの分類:")
    print("- 言語タグ (9種類): lang-{language}")
    print("- 技術スタックタグ (22種類): tech-{stack}")
    print("- トピックタグ (18種類): topic-{topic}")
    print("- レガシータグ (6種類): money, print, uiux, db, net, io")
    print("- 言語固有タグ (4種類): go-concurrent, cpp-memory, php-web, delphi-memory")
    print("="*80)

if __name__ == "__main__":
    test_tag_system()

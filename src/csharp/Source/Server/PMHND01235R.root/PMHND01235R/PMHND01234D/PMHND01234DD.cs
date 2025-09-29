//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫一括削除データ条件ワーク
// プログラム概要   : 在庫一括削除データ条件ワークです
//----------------------------------------------------------------------------//
//                (c)Copyright 2020 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// 管理番号  11570249-00   作成担当 : 陳艶丹
// 作 成 日  2020/03/09    修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   HandyDeleteStockCondWork
    /// <summary>
    ///                      在庫一括削除データ条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫一括削除データ条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2020/03/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class HandyDeleteStockCondWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

         /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>在庫区分</summary>
        /// <remarks>0:指定なし 1:在庫数＝0</remarks>
        private Int32 _stockDiv;

        /// <summary>倉庫棚番</summary>
        private string _warehouseShelfNo = "";

        /// <summary>最終売上日</summary>
        private Int64 _lastSalesDate;

        /// <summary>使用回数</summary>
        /// <remarks>メーカー、バーコード、検索品番、登録品番毎の使用回数</remarks>
        private Int32 _useCount;

        /// <summary>検索日付開始</summary>
        private Int32 _searchDateSt;

        /// <summary>検索日付終了</summary>
        private Int32 _searchDateEd;


        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分プロパティ</summary>
        /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  StockDiv
        /// <summary>最終売上日プロパティ</summary>
        /// <value>0:指定なし 1:在庫数＝0</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最終売上日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockDiv
        {
            get { return _stockDiv; }
            set { _stockDiv = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>倉庫棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  LastSalesDate
        /// <summary>最終売上日プロパティ</summary>
        /// <value>在庫検索を実行した日付</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最終売上日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 LastSalesDate
        {
            get { return _lastSalesDate; }
            set { _lastSalesDate = value; }
        }

        /// public propaty name  :  UseCount
        /// <summary>使用回数プロパティ</summary>
        /// <value>メーカー、バーコード、検索品番、登録品番毎の使用回数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   使用回数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UseCount
        {
            get { return _useCount; }
            set { _useCount = value; }
        }

        /// public propaty name  :  SearchDateSt
        /// <summary>検索日付開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索日付開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchDateSt
        {
            get { return _searchDateSt; }
            set { _searchDateSt = value; }
        }

        /// public propaty name  :  SearchDateEd
        /// <summary>検索日付終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索日付終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchDateEd
        {
            get { return _searchDateEd; }
            set { _searchDateEd = value; }
        }

        /// <summary>
        /// メーカー品番パターン検索履歴結果ワークコンストラクタ
        /// </summary>
        /// <returns>HandyDeleteStockCondWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyDeleteStockCondWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public HandyDeleteStockCondWork()
        {
        }

    }

}

//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫マスタ（インポート）
// プログラム概要   : 在庫マスタ（インポート）抽出条件クラス。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : zhangy3
// 修 正 日  2012/07/20  修正内容 : 大陽案件、Redmine#30387 在庫マスタインボート仕様変更の対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;

namespace Broadleaf.Application.UIData
{
    /// public class name:   ExtrInfo_StockImportWorkTbl
    /// <summary>
    ///                      在庫マスタ（インポート）抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫マスタ（インポート）抽出条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/05/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2012/07/20 zhangy3</br>
    /// <br>                 :   10801804-00、大陽案件、Redmine#30387 在庫マスタインボート仕様変更の対応</br>
    /// </remarks>
    public class ExtrInfo_StockImportWorkTbl
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>処理区分</summary>
        private Int32 _processKbn;

        /// <summary>CSVデータ情報リスト</summary>
        private List<string[]> _csvDataInfoList;
        // ------------ADD zhangy3 2012/07/20 FOR Redmine#30387--------->>>>
        /// <summary>チェック区分</summary>
        private Int32 _dataCheckKbn;
        // ------------ADD zhangy3 2012/07/20 FOR Redmine#30387---------<<<<

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

        /// public propaty name  :  ProcessKbn
        /// <summary>処理区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ProcessKbn
        {
            get { return _processKbn; }
            set { _processKbn = value; }
        }

        /// public propaty name  :  CsvDataInfoList
        /// <summary>CSVデータ情報リスト</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   CSVデータ情報リスト</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<string[]> CsvDataInfoList
        {
            get { return _csvDataInfoList; }
            set { _csvDataInfoList = value; }
        }

        // ------------ADD zhangy3 2012/07/20 FOR Redmine#30387--------->>>>
        /// public propaty name  :  DataCheckKbn
        /// <summary>チェック区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   チェック区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DataCheckKbn
        {
            get { return _dataCheckKbn; }
            set { _dataCheckKbn = value; }
        }
        // ------------ADD zhangy3 2012/07/20 FOR Redmine#30387---------<<<<
        /// <summary>
        /// 在庫マスタ（インポート）抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>ExtrInfo_StockImportWorkTblクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ExtrInfo_StockImportWorkTblクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ExtrInfo_StockImportWorkTbl()
        {
        }
    }
}

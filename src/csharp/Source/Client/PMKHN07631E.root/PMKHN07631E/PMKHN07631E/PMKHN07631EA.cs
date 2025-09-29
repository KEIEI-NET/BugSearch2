//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品マスタ（インポート）
// プログラム概要   : 商品マスタ（インポート）抽出条件クラス。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 修 正 日  2010/03/31  修正内容 : Mantis.15256 商品マスタインポートの対象項目設定対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/06/12  修正内容 : 大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/07/20  修正内容 : 大陽案件、Redmine#30387 商品マスタインボート仕様変更の対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

namespace Broadleaf.Application.UIData
{
    /// public class name:   ExtrInfo_GoodsUImportWorkTbl
    /// <summary>
    ///                      商品マスタ（インポート）抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品マスタ（インポート）抽出条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/05/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br>Update Note      :   2012/06/12 wangf </br>
    /// <br>                 :   10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
    /// </remarks>
    public class ExtrInfo_GoodsUImportWorkTbl
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>処理区分</summary>
        private Int32 _processKbn;

        /// <summary>CSVデータ情報リスト</summary>
        private List<string[]> _csvDataInfoList;

        // 2010/03/31 Add >>>
        /// <summary>インポート対象設定リスト</summary>
        private List<int[]> _setUpInfoList;
        // 2010/03/31 Add <<<
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
        /// <summary>エラーログファイル名</summary>
        private string _errorLogFileName;
        /// <summary>価格開始年月日</summary>
        private DateTime _priceStartDate;
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
        // ------------ADD wangf 2012/07/20 FOR Redmine#30387--------->>>>
        /// <summary>チェック区分</summary>
        private Int32 _dataCheckKbn;
        // ------------ADD wangf 2012/07/20 FOR Redmine#30387---------<<<<

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

        // 2010/03/31 Add >>>
        /// public propaty name  :  SetUpInfoList
        /// <summary>インポート対象設定リスト</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   インポート対象設定リスト</br>
        /// <br>Programer        :   30517 夏野 駿希</br>
        /// </remarks>
        public List<int[]> SetUpInfoList
        {
            get { return _setUpInfoList; }
            set { _setUpInfoList = value; }
        }
        // 2010/03/31 Add <<<
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
        /// public propaty name  :  ErrorLogFileName
        /// <summary>エラーログファイル名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラーログファイル名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ErrorLogFileName
        {
            get { return _errorLogFileName; }
            set { _errorLogFileName = value; }
        }
        /// public propaty name  :  PriceStartDate
        /// <summary>価格開始年月日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格開始年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
        }
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
        // ------------ADD wangf 2012/07/20 FOR Redmine#30387--------->>>>
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
        // ------------ADD wangf 2012/07/20 FOR Redmine#30387---------<<<<
    }
}

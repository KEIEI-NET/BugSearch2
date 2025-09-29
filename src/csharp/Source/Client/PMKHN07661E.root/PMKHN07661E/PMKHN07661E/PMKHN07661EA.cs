//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品マスタ（インポート）
// プログラム概要   : 商品マスタ（インポート）抽出条件クラス。
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 張曼
// 作 成 日  2012/06/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 姚学剛
// 修 正 日  2012/07/19  修正内容 : 障害一覧の指摘NO.110の対応
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
    /// <br>Genarated Date   :   2012/06/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br>Update Note : 2012/07/19 姚学剛 </br>
    /// <br>            : 10801804-00、Redmine#30388 障害一覧の指摘NO.110の対応</br>
    /// </remarks>
    public class ExtrInfo_GoodsMngImportWorkTbl
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>処理区分</summary>
        private Int32 _processKbn;

        // ------------ADD 姚学剛 2012/07/19 FOR Redmine#30388-------->>>>>
        ///<summary>チェック区分</summary>
        private Int32 _checkKbn;
        // ------------ADD 姚学剛 2012/07/19 FOR Redmine#30388---------<<<<<

        /// <summary>CSVデータ情報リスト</summary>
        private List<string[]> _csvDataInfoList;

        /// <summary>エラーログファイル名</summary>
        private string _errorLogFileName;
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

        // ------------ADD 姚学剛 2012/07/19 FOR Redmine#30388-------->>>>>
        /// public propaty name  :  CheckKbn
        /// <summary>処理区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CheckKbn
        {
            get { return _checkKbn; }
            set { _checkKbn = value; }
        }
        // ------------ADD 姚学剛 2012/07/19 FOR Redmine#30388---------<<<<<

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

        /// <summary>
        /// 商品マスタ（インポート）抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>ExtrInfo_GoodsUImportWorkTblクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ExtrInfo_GoodsUImportWorkTblクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ExtrInfo_GoodsMngImportWorkTbl()
        {
        }
    }
}

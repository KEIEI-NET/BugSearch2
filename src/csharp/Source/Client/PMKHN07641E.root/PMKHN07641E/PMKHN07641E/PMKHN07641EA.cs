//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 得意先マスタ（インポート）
// プログラム概要   : 得意先マスタ（インポート）抽出条件クラス。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 :李亜博
// 修 正 日  2012/06/12  修正内容 :10801804-00 大陽案件、Redmine#30393 
//                                 得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 :李亜博
// 修 正 日  2012/07/20  修正内容 :大陽案件、Redmine#30387 
//                                 障害一覧の指摘NO.108の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;

namespace Broadleaf.Application.UIData
{
    /// public class name:   ExtrInfo_CustomerImportWorkTbl
    /// <summary>
    ///                      得意先マスタ（インポート）抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   得意先マスタ（インポート）抽出条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/05/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2012/06/12 李亜博</br>
    /// <br>管理番号         :   10801804-00 大陽案件</br>
    /// <br>                     Redmine#30393   得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加</br>
    /// <br>Update Note      :   2012/07/20 李亜博</br>
    /// <br>管理番号         :   10801804-00 大陽案件</br>
    /// <br>                     Redmine#30387  障害一覧の指摘NO.108の対応</br>
    /// </remarks>
    public class ExtrInfo_CustomerImportWorkTbl
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>処理区分</summary>
        private Int32 _processKbn;

        // ------ ADD START 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.108の対応-------->>>>
        /// <summary>チェック区分</summary>
        private Int32 _checkKbn;
        // ------ ADD END 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.108の対応--------<<<<

        /// <summary>CSVデータ情報リスト</summary>
        private List<string[]> _csvDataInfoList;

        // --------------- ADD START 2012/06/12 Redmine#30393 李亜博-------->>>>
        /// <summary>エラーログファイル名</summary>
        private string _errorLogFileName;
        // --------------- ADD END 2012/06/12 Redmine#30393 李亜博--------<<<<

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

        // ------ ADD START 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.108の対応-------->>>>
        /// public propaty name  :  CheckKbn
        /// <summary>チェックプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   チェックプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CheckKbn
        {
            get { return _checkKbn; }
            set { _checkKbn = value; }
        }
        // ------ ADD END 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.108の対応--------<<<<

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

        /// <summary>
        /// 得意先マスタ（インポート）抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>ExtrInfo_CustomerImportWorkTblクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ExtrInfo_CustomerImportWorkTblクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ExtrInfo_CustomerImportWorkTbl()
        {
        }
        // --------------- ADD START 2012/06/12 Redmine#30393 李亜博-------->>>>
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
        // --------------- ADD END 2012/06/12 Redmine#30393 李亜博--------<<<<
    }
}

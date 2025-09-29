//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上データテキスト出力条件ワーク
// プログラム概要   : 売上データテキスト出力条件ワークです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 管理番号  11370098-00  作成担当 : 陳艶丹
// 作 成 日  2017/11/20   修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   EDISalesCndtnWork
    /// <summary>
    ///                      売上データテキストリモート抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上データテキストリモート抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2017/11/20</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class EDISalesCndtnWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>選択拠点コード</summary>
        private string[] _sectionCodeList;

        /// <summary>計上日(開始)</summary>
        private Int32 _addUpADateSt;

        /// <summary>計上日(終了)</summary>
        private Int32 _addUpADateEd;

        /// <summary>得意先(開始)</summary>
        private Int32 _customerCodeSt;

        /// <summary>得意先(終了)</summary>
        private Int32 _customerCodeEd;

        /// <summary>確認リスト</summary>
        private Int32 _conFirmDiv;

        /// <summary>出力指定</summary>
        private Int32 _pdfOutDiv;

        /// <summary>ファイル名</summary>
        private string _fileName = "";

        /// <summary>画面モード</summary>
        private Int32 _mode;

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

        /// public propaty name  :  SectionCodeList
        /// <summary>選択拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   選択拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] SectionCodeList
        {
            get { return _sectionCodeList; }
            set { _sectionCodeList = value; }
        }

        /// public propaty name  :  AddUpADateSt
        /// <summary>計上日(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddUpADateSt
        {
            get { return _addUpADateSt; }
            set { _addUpADateSt = value; }
        }

        /// public propaty name  :  AddUpADateEd
        /// <summary>計上日(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddUpADateEd
        {
            get { return _addUpADateEd; }
            set { _addUpADateEd = value; }
        }

        /// public propaty name  :  CustomerCodeSt
        /// <summary>得意先(開始)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先(開始)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCodeSt
        {
            get { return _customerCodeSt; }
            set { _customerCodeSt = value; }
        }

        /// public propaty name  :  CustomerCodeEd
        /// <summary>得意先(終了)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先(終了)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCodeEd
        {
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
        }

        /// public propaty name  :  ConFirmDiv
        /// <summary>確認リストプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   確認リストプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ConFirmDiv
        {
            get { return _conFirmDiv; }
            set { _conFirmDiv = value; }
        }

        /// public propaty name  :  PdfOutDiv
        /// <summary>出力指定プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力指定プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PdfOutDiv
        {
            get { return _pdfOutDiv; }
            set { _pdfOutDiv = value; }
        }

        /// public propaty name  :  FileName
        /// <summary>ファイル名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ファイル名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// public propaty name  :  Mode
        /// <summary>画面モード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力指定プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        /// <summary>
        /// 売上データテキストデータコンストラクタ
        /// </summary>
        /// <returns>EDISalesCndtnWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EDISalesCndtnWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public EDISalesCndtnWork()
        {
        }
    }
}

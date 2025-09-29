//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : S&E売上データテキスト出力クラス
// プログラム概要   : S&E売上データテキスト出力クラス帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/08/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhuhh
// 作 成 日  2013/03/06  修正内容 : Ｓ＆Ｅ(AB) テキスト出力自動送信の追加
//----------------------------------------------------------------------------//
// 管理番号 10901034-00  作成担当 : 田建委
// 作 成 日  2013/06/26  修正内容 : Ｓ＆Ｅ(AB) テキスト出力自動送信の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SalesHistoryCndtn
    /// <summary>
    ///                      売上履歴データ
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上履歴データヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/28</br>
    /// <br>Genarated Date   :   2009/08/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/9  杉村</br>
    /// <br>                 :   ○スペルミス修正</br>
    /// <br>                 :   売上値引非課税対象額合計</br>
    /// <br>                 :   売上正価金額</br>
    /// <br>                 :   売上金額消費税額（外税）</br>
    /// <br>Update Note      :   2008/7/29  長内</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   得意先伝票番号</br>
    /// <br>UpdateNote       :   2013/02/25 zhuhh</br>
    /// <br>                 :   Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更</br>
    /// <br>UpdateNote       :   2013/06/26 田建委</br>
    /// <br>                 :   自動送信処理の追加及び送信ログの登録</br>
    /// </remarks>
    public class SalesHistoryCndtn
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

        // ----- ADD zhuhh 2013/03/06 for Redmine#35011----->>>>>
        /// <summary>自動送信区分</summary>
        private Int32 _autoDataSendDiv;
        // ----- ADD zhuhh 2013/03/06 for Redmine#35011-----<<<<<

        //----- ADD 田建委 2013/06/26 ----->>>>>
        /// <summary>送信区分(0:手動;1:自動)</summary>
        private Int32 _sendDataDiv;
        //----- ADD 田建委 2013/06/26 -----<<<<<

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

        // ----- ADD zhuhh 2013/03/06 for Redmine#A35011----->>>>>
        /// public propaty name  :  AutoDataSendDiv
        /// <summary>自動送信区分</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動送信区分（0：送信する　1：送信しない）</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AutoDataSendDiv
        {
            get { return _autoDataSendDiv; }
            set { _autoDataSendDiv = value; }
        }
        // ----- ADD zhuhh 2013/03/06 for Redmine#35011-----<<<<<

        //----- ADD 田建委 2013/06/26 ----->>>>>
        /// public propaty name  :  SendDataDiv
        /// <summary>送信区分(0:手動;1:自動)</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信区分(0:手動;1:自動)</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SendDataDiv
        {
            get { return _sendDataDiv; }
            set { _sendDataDiv = value; }
        }
        //----- ADD 田建委 2013/06/26 -----<<<<<

        /// <summary>
        /// 売上履歴データコンストラクタ
        /// </summary>
        /// <returns>SalesHistoryCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesHistoryCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesHistoryCndtn()
        {
        }

        /// <summary>
        /// 売上履歴データコンストラクタ
        /// </summary>
        /// <param name="addUpADateSt">計上日(開始)</param>
        /// <param name="addUpADateEd">計上日(終了)</param>
        /// <param name="customerCodeSt">得意先(開始)</param>
        /// <param name="customerCodeEd">得意先(終了)</param>
        /// <param name="conFirmDiv">確認リスト</param>
        /// <param name="pdfOutDiv">出力指定</param>
        /// <param name="fileName">ファイル名</param>
        /// <param name="mode">画面モード</param>
        /// <returns>SalesHistoryCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesHistoryCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        //public SalesHistoryCndtn(Int32 addUpADateSt, Int32 addUpADateEd, Int32 customerCodeSt, Int32 customerCodeEd, Int32 conFirmDiv, Int32 pdfOutDiv, string fileName, Int32 mode) // DEL 田建委 2013/06/26
        public SalesHistoryCndtn(Int32 addUpADateSt, Int32 addUpADateEd, Int32 customerCodeSt, Int32 customerCodeEd, Int32 conFirmDiv, Int32 pdfOutDiv, string fileName, Int32 mode, Int32 autoDataSendDiv, Int32 sendDataDiv) // ADD 田建委 2013/06/26
        {
            this._addUpADateSt = addUpADateSt;
            this._addUpADateEd = addUpADateEd;
            this._customerCodeSt = customerCodeSt;
            this._customerCodeEd = customerCodeEd;
            this._conFirmDiv = conFirmDiv;
            this._pdfOutDiv = pdfOutDiv;
            this._fileName = fileName;
            this._mode = mode;
            this._autoDataSendDiv = autoDataSendDiv; // ADD 田建委 2013/06/26
            this._sendDataDiv = sendDataDiv; // ADD 田建委 2013/06/26

        }

        /// <summary>
        /// 売上履歴データ複製処理
        /// </summary>
        /// <returns>SalesHistoryCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSalesHistoryCndtnクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesHistoryCndtn Clone()
        {
            //return new SalesHistoryCndtn(this._addUpADateSt, this._addUpADateEd, this._customerCodeSt, this._customerCodeEd, this._conFirmDiv, this._pdfOutDiv, this._fileName,this._mode); // DEL 田建委 2013/06/26
            return new SalesHistoryCndtn(this._addUpADateSt, this._addUpADateEd, this._customerCodeSt, this._customerCodeEd, this._conFirmDiv, this._pdfOutDiv, this._fileName, this._mode, this._autoDataSendDiv, this._sendDataDiv); // ADD 田建委 2013/06/26
        }

        /// <summary>
        /// 売上履歴データ比較処理
        /// </summary>
        /// <param name="target">比較対象のSalesHistoryCndtnクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesHistoryCndtnクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SalesHistoryCndtn target)
        {
            return ((this.AddUpADateSt == target.AddUpADateSt)
                 && (this.AddUpADateEd == target.AddUpADateEd)
                 && (this.CustomerCodeSt == target.CustomerCodeSt)
                 && (this.CustomerCodeEd == target.CustomerCodeEd)
                 && (this.ConFirmDiv == target.ConFirmDiv)
                 && (this.PdfOutDiv == target.PdfOutDiv)
                 && (this.FileName == target.FileName)
                //&& (this.Mode == target.Mode)); // DEL 田建委 2013/06/26
                //----- ADD 田建委 2013/06/26 ----->>>>>
                && (this.Mode == target.Mode)
                && (this.AutoDataSendDiv == target.AutoDataSendDiv)
                && (this.SendDataDiv == target.SendDataDiv));
                //----- ADD 田建委 2013/06/26 -----<<<<<
        }

        /// <summary>
        /// 売上履歴データ比較処理
        /// </summary>
        /// <param name="salesHistoryCndtn1">
        ///                    比較するSalesHistoryCndtnクラスのインスタンス
        /// </param>
        /// <param name="salesHistoryCndtn2">比較するSalesHistoryCndtnクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesHistoryCndtnクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SalesHistoryCndtn salesHistoryCndtn1, SalesHistoryCndtn salesHistoryCndtn2)
        {
            return ((salesHistoryCndtn1.AddUpADateSt == salesHistoryCndtn2.AddUpADateSt)
                 && (salesHistoryCndtn1.AddUpADateEd == salesHistoryCndtn2.AddUpADateEd)
                 && (salesHistoryCndtn1.CustomerCodeSt == salesHistoryCndtn2.CustomerCodeSt)
                 && (salesHistoryCndtn1.CustomerCodeEd == salesHistoryCndtn2.CustomerCodeEd)
                 && (salesHistoryCndtn1.ConFirmDiv == salesHistoryCndtn2.ConFirmDiv)
                 && (salesHistoryCndtn1.PdfOutDiv == salesHistoryCndtn2.PdfOutDiv)
                 && (salesHistoryCndtn1.FileName == salesHistoryCndtn2.FileName)
                //&& (salesHistoryCndtn1.Mode == salesHistoryCndtn2.Mode)); // DEL 田建委 2013/06/26
                //----- ADD 田建委 2013/06/26 ----->>>>>
                && (salesHistoryCndtn1.Mode == salesHistoryCndtn2.Mode)
                && (salesHistoryCndtn1.AutoDataSendDiv == salesHistoryCndtn2.AutoDataSendDiv)
                && (salesHistoryCndtn1.SendDataDiv == salesHistoryCndtn2.SendDataDiv));
                //----- ADD 田建委 2013/06/26 -----<<<<<
        }
        /// <summary>
        /// 売上履歴データ比較処理
        /// </summary>
        /// <param name="target">比較対象のSalesHistoryCndtnクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesHistoryCndtnクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SalesHistoryCndtn target)
        {
            ArrayList resList = new ArrayList();
            if (this.AddUpADateSt != target.AddUpADateSt) resList.Add("AddUpADateSt");
            if (this.AddUpADateEd != target.AddUpADateEd) resList.Add("AddUpADateEd");
            if (this.CustomerCodeSt != target.CustomerCodeSt) resList.Add("CustomerCodeSt");
            if (this.CustomerCodeEd != target.CustomerCodeEd) resList.Add("CustomerCodeEd");
            if (this.ConFirmDiv != target.ConFirmDiv) resList.Add("ConFirmDiv");
            if (this.PdfOutDiv != target.PdfOutDiv) resList.Add("PdfOutDiv");
            if (this.FileName != target.FileName) resList.Add("FileName");
            if (this.Mode != target.Mode) resList.Add("Mode");
            //----- ADD 田建委 2013/06/26 ----->>>>>
            if (this.AutoDataSendDiv != target.AutoDataSendDiv) resList.Add("AutoDataSendDiv");
            if (this.SendDataDiv != target.SendDataDiv) resList.Add("SendDataDiv");
            //----- ADD 田建委 2013/06/26 -----<<<<<

            return resList;
        }

        /// <summary>
        /// 売上履歴データ比較処理
        /// </summary>
        /// <param name="salesHistoryCndtn1">比較するSalesHistoryCndtnクラスのインスタンス</param>
        /// <param name="salesHistoryCndtn2">比較するSalesHistoryCndtnクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesHistoryCndtnクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SalesHistoryCndtn salesHistoryCndtn1, SalesHistoryCndtn salesHistoryCndtn2)
        {
            ArrayList resList = new ArrayList();
            if (salesHistoryCndtn1.AddUpADateSt != salesHistoryCndtn2.AddUpADateSt) resList.Add("AddUpADateSt");
            if (salesHistoryCndtn1.AddUpADateEd != salesHistoryCndtn2.AddUpADateEd) resList.Add("AddUpADateEd");
            if (salesHistoryCndtn1.CustomerCodeSt != salesHistoryCndtn2.CustomerCodeSt) resList.Add("CustomerCodeSt");
            if (salesHistoryCndtn1.CustomerCodeEd != salesHistoryCndtn2.CustomerCodeEd) resList.Add("CustomerCodeEd");
            if (salesHistoryCndtn1.ConFirmDiv != salesHistoryCndtn2.ConFirmDiv) resList.Add("ConFirmDiv");
            if (salesHistoryCndtn1.PdfOutDiv != salesHistoryCndtn2.PdfOutDiv) resList.Add("PdfOutDiv");
            if (salesHistoryCndtn1.FileName != salesHistoryCndtn2.FileName) resList.Add("FileName");
            if (salesHistoryCndtn1.Mode != salesHistoryCndtn2.Mode) resList.Add("Mode");
            //----- ADD 田建委 2013/06/26 ----->>>>>
            if (salesHistoryCndtn1.AutoDataSendDiv != salesHistoryCndtn2.AutoDataSendDiv) resList.Add("AutoDataSendDiv");
            if (salesHistoryCndtn1.SendDataDiv != salesHistoryCndtn2.SendDataDiv) resList.Add("SendDataDiv");
            //----- ADD 田建委 2013/06/26 -----<<<<<

            return resList;
        }
    }
}

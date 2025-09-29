//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   手形取引先別表 抽出クラス
//                  :   PMTEG02504E.DLL
// Name Space       :   Broadleaf.Application.UIData
// Programmer       :   王開強
// Date             :   2010.04.21
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
	/// <summary>
    /// 手形取引先別表抽出条件クラス
	/// </summary>
	/// <remarks>
    /// <br>note             :   手形取引先別表抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2010/03/27  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
    public class TegataTorihikisakiListReport
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = string.Empty;

        /// <summary>拠点コード</summary>
        /// <remarks>文字型　※配列項目</remarks>
        private string[] _sectionCodes;

        /// <summary>
        /// 拠点オプション区分
        /// </summary>
        private bool _isOptSection = false;

        /// <summary>
        /// 全拠点選択区分
        /// </summary>
        private bool _isSelectAllSection = false;

        /// <summary>手形区分</summary>
        /// <remarks>0:自振 1:他振　※旧自他振区分</remarks>
        private Int32 _draftDivide;

        /// <summary>印刷範囲年月</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _salesDate;

        /// <summary>改頁</summary>
        private Int32 _changePageDiv;

        /// <summary>印刷タイプ</summary>
        private Int32 _printType;

        /// <summary>開始取引先コード</summary>
        private string  _customerCodeSt;

        /// <summary>終了取引先コード</summary>
        private string _customerCodeEd;

        /// <summary>月分タイトル</summary>
        /// <remarks>文字型　※配列項目</remarks>
        private string[] _monthTitles;

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

        /// public propaty name  :  SectionCodes
        /// <summary>拠点コードプロパティ</summary>
        /// <value>文字型　※配列項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
        }

        /// public propaty name  :  DraftDivide
        /// <summary>手形区分プロパティ</summary>
        /// <value>0:自振 1:他振　※旧自他振区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DraftDivide
        {
            get { return _draftDivide; }
            set { _draftDivide = value; }
        }

        /// public propaty name  :  SalesDate
        /// <summary>印刷範囲年月</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷範囲年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// public propaty name  :  ChangePageDiv
        /// <summary>改頁</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改頁プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ChangePageDiv
        {
            get { return _changePageDiv; }
            set { _changePageDiv = value; }
        }

        /// public propaty name  :  PrintType
        /// <summary>印刷タイプ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発行タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintType
        {
            get { return _printType; }
            set { _printType = value; }
        }

        /// public propaty name  :  CustomerCodeSt
        /// <summary>開始取引先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始取引先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerCodeSt
        {
            get { return _customerCodeSt; }
            set { _customerCodeSt = value; }
        }

        /// public propaty name  :  CustomerCodeEd
        /// <summary>終了取引先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了取引先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerCodeEd
        {
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
        }

        /// <summary>
        /// 拠点オプション区分プロパティ
        /// </summary>
        public bool IsOptSection
        {
            get { return this._isOptSection; }
            set { this._isOptSection = value; }
        }
        /// <summary>
        /// 全拠点選択区分プロパティ
        /// </summary>
        public bool IsSelectAllSection
        {
            get { return this._isSelectAllSection; }
            set { this._isSelectAllSection = value; }
        }

        /// public propaty name  :  MonthTitles
        /// <summary>月分タイトルプロパティ</summary>
        /// <value>文字型　※配列項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] MonthTitles
        {
            get { return _monthTitles; }
            set { _monthTitles = value; }
        }

    }
}

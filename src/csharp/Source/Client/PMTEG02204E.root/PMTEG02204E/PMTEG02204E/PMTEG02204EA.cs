//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   手形決済一覧表 条件クラス
//                  :   PMTEG02204E.DLL
// Name Space       :   Broadleaf.Application.UIData
// Programmer       :   葛軍
// Date             :   2010.05.05
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
	/// <summary>
    /// 手形決済一覧表 条件クラス
	/// </summary>
	/// <remarks>
    /// <br>note             :   手形決済一覧表抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2010/03/27  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
    public class TegataKessaiReport
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = string.Empty;

        /// <summary>手形区分</summary>
        /// <remarks>0:自振 1:他振　※旧自他振区分</remarks>
        private Int32 _draftDivide;

        /// <summary>印刷範囲年月</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _salesDate;

        /// <summary>開始銀行・支店コード</summary>
        private string _bankAndBranchCdSt;

        /// <summary>終了銀行・支店コード</summary>
        private string _bankAndBranchCdEd;

        /// <summary>開始入金/支払日</summary>
        private DateTime _dateSt;

        /// <summary>終了入金/支払日</summary>
        private DateTime _dateEd;

        /// <summary>開始満期日</summary>
        private DateTime _maturityDateSt;

        /// <summary>終了満期日</summary>
        private DateTime _maturityDateEd;

        /// <summary>出力順</summary>
        private Int32 _sortOrder;

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

        /// public propaty name  :  SortOrder
        /// <summary>出力順</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力順プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SortOrder
        {
            get { return _sortOrder; }
            set { _sortOrder = value; }
        }

        /// public propaty name  :  BankAndBranchCdSt
        /// <summary>開始銀行・支店コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始銀行・支店コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BankAndBranchCdSt
        {
            get { return _bankAndBranchCdSt; }
            set { _bankAndBranchCdSt = value; }
        }

        /// public propaty name  :  BankAndBranchCdEd
        /// <summary>終了銀行・支店コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了銀行・支店コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BankAndBranchCdEd
        {
            get { return _bankAndBranchCdEd; }
            set { _bankAndBranchCdEd = value; }
        }

        /// public propaty name  :  DateSt
        /// <summary>開始入金/支払日</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始入金/支払日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime DateSt
        {
            get { return _dateSt; }
            set { _dateSt = value; }
        }

        /// public propaty name  :  DateEd
        /// <summary>開始入金/支払日</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始入金/支払日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime DateEd
        {
            get { return _dateEd; }
            set { _dateEd = value; }
        }

        /// public propaty name  :  MaturityDateSt
        /// <summary>開始満期日</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始満期日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime MaturityDateSt
        {
            get { return _maturityDateSt; }
            set { _maturityDateSt = value; }
        }

        /// public propaty name  :  MaturityDateEd
        /// <summary>終了満期日</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了満期日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime MaturityDateEd
        {
            get { return _maturityDateEd; }
            set { _maturityDateEd = value; }
        }

    }
}

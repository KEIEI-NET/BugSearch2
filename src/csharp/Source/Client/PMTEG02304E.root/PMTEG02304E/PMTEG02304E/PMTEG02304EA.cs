//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   手形期日別表 抽出クラス
//                  :   PMTEG02304E.DLL
// Name Space       :   Broadleaf.Application.UIData
// Programmer       :   王開強
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
    /// 手形期日別表抽出条件クラス
	/// </summary>
	/// <remarks>
    /// <br>note             :   手形期日別表抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2010/03/27  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
    public class TegataKibiListReport
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

        /// <summary>月分タイトル</summary>
        /// <remarks>文字型　※配列項目</remarks>
        private string[] _monthTitles;

        /// <summary>手形種別</summary>
        /// <remarks>文字型　※配列項目</remarks>
        private string[] _draftKindCds;

        /// <summary>手形種別名称</summary>
        private Hashtable _draftKindCdsHt;

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

        /// public propaty name  :  DraftKindCds
        /// <summary>手形種別プロパティ</summary>
        /// <value>文字型　※配列項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] DraftKindCds
        {
            get { return _draftKindCds; }
            set { _draftKindCds = value; }
        }

        /// public propaty name  :  DraftKindCdsHt
        /// <summary>手形種別名称プロパティ</summary>
        /// <value>文字型　※配列項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手形種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Hashtable DraftKindCdsHt
        {
            get { return _draftKindCdsHt; }
            set { _draftKindCdsHt = value; }
        }

    }
}

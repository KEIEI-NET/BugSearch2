//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形決済一覧表抽出条件クラスワーク
// プログラム概要   : 手形決済一覧表抽出条件クラスワークヘッダファイル
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 葛軍
// 作 成 日  2010/05/06  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   TegataKessaiReportParaWork
    /// <summary>
    ///                      手形決済一覧表抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   手形決済一覧表抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/18</br>
    /// <br>Genarated Date   :   2010/05/06  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TegataKessaiReportParaWork
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

        /// <summary>改頁</summary>
        private Int32 _changePageDiv;

        /// <summary>開始銀行・支店コード</summary>
        private string _bankAndBranchCdSt;

        /// <summary>終了銀行・支店コード</summary>
        private string _bankAndBranchCdEd;

        /// <summary>開始入金日</summary>
        private DateTime _depositDateSt;

        /// <summary>終了入金日</summary>
        private DateTime _depositDateEd;

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

        /// public propaty name  :  DepositDateSt
        /// <summary>開始入金日</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始入金日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime DepositDateSt
        {
            get { return _depositDateSt; }
            set { _depositDateSt = value; }
        }

        /// public propaty name  :  DepositDateEd
        /// <summary>開始入金日</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始入金日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime DepositDateEd
        {
            get { return _depositDateEd; }
            set { _depositDateEd = value; }
        }

        /// public propaty name  :  MaturityDateSt
        /// <summary>開始入金日</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始入金日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime MaturityDateSt
        {
            get { return _maturityDateSt; }
            set { _maturityDateSt = value; }
        }

        /// public propaty name  :  MaturityDateEd
        /// <summary>開始入金日</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始入金日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime MaturityDateEd
        {
            get { return _maturityDateEd; }
            set { _maturityDateEd = value; }
        }

        /// <summary>
        /// 手形決済一覧表抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>TegataKessaiReportParaWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TegataKessaiReportParaWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TegataKessaiReportParaWork()
        {
        }
    }
}

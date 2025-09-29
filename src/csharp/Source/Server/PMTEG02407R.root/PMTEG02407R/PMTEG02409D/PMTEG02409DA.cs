//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形月別予定表抽出条件クラスワーク
// プログラム概要   : 手形月別予定表抽出条件クラスワークヘッダファイル
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 姜凱
// 作 成 日  2010/05/05  修正内容 : 新規作成
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
    /// public class name:   TegataTsukibetsuYoteListReportParaWork
    /// <summary>
    ///                      手形月別予定表抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   手形月別予定表抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/18</br>
    /// <br>Genarated Date   :   2010/04/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TegataTsukibetsuYoteListReportParaWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = string.Empty;

		/// <summary>手形種別</summary>
		/// <remarks>文字型　※配列項目</remarks>
		private string[] _draftKindCds;

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

		/// <summary>出力順</summary>
		private Int32 _sortOrder;

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

        /// <summary>
        /// 手形月別予定表抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>TegataTsukibetsuYoteListReportParaWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TegataTsukibetsuYoteListReportParaWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TegataTsukibetsuYoteListReportParaWork()
        {
        }
    }
}

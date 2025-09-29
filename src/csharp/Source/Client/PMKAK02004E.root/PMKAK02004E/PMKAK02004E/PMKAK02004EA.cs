//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 支払一覧表（総括）
// プログラム概要   : 支払一覧表（総括）の印字を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI東　隆史
// 作 成 日  2012/09/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 支払一覧表（総括）抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   </br>
	/// <br>Programmer       :   FSI東 隆史</br>
	/// <br>Date             :   2012.9.04</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class SumSuplierPayMainCndtn
	{
		#region ■ Private Member
		/// <summary>企業コード</summary>
		private string _enterpriseCode = string.Empty;

		/// <summary>拠点オプション導入区分</summary>
		private bool _isOptSection;

		/// <summary>本社機能プロパティ</summary>
		private bool _isMainOfficeFunc;

		/// <summary>選択支払計上拠点コード</summary>
		private string[] _paymentAddupSecCodeList;

        /// <summary>締日</summary>
        private DateTime _cAddUpUpdExecDate;

		/// <summary>帳票タイプ区分</summary>
		/// <remarks>設定コードと同じ</remarks>
		private int _printDiv;

		/// <summary>帳票タイプ区分名称</summary>
		private string _printDivName = string.Empty;

        /// <summary>開始支払先コード</summary>
		private Int32 _st_PayeeCode;

		/// <summary>終了支払先コード</summary>
        private Int32 _ed_PayeeCode;

        /// <summary>出力金額区分</summary>
        private Int32 _outputMoneyDiv;

        /// <summary>総括支払先内訳</summary>
        private Int32 _sumPayeeDetail;

        /// <summary>残高支払内訳</summary>
        private Int32 _balancePayeeDetail;

        ///// <summary>親支払先内訳</summary>
        //private Int32 _prPayeeDtl;

        /// <summary>改頁</summary>
        private Int32 _newPageDiv;

		#endregion ■ Private Member

		#region ■ Private Const
		/// <summary>共通 日付フォーマット</summary>
		public const string ct_DateFomat = "YYYY/MM/DD";

		/// <summary>共通 全て コード</summary>
		public const int ct_All_Code = -1;
		/// <summary>共通 全て 名称</summary>
		public const string ct_All_Name	= "全て";

		// 帳票タイプ区分 ------------------------------------------------------------------
		/// <summary>帳票タイプ区分 支払一覧表（総括）(明細タイプ)</summary>
        public const string ct_PrintDiv_DetailTyp = "明細タイプ";

		#endregion

		#region ■ Public Property
		/// public propaty name  :  EnterpriseCode
		/// <summary>企業コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterpriseCode
		{
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  IsOptSection
		/// <summary>拠点オプション導入区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点オプション導入区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool IsOptSection
		{
			get{return _isOptSection;}
			set{_isOptSection = value;}
		}

		/// public propaty name  :  IsMainOfficeFunc
		/// <summary>本社機能プロパティプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   本社機能プロパティプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool IsMainOfficeFunc
		{
			get{return _isMainOfficeFunc;}
			set{_isMainOfficeFunc = value;}
		}

		/// public propaty name  :  PaymentAddupSecCodeList
		/// <summary>選択支払計上拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   選択支払計上拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] PaymentAddupSecCodeList
		{
			get{return _paymentAddupSecCodeList;}
			set{_paymentAddupSecCodeList = value;}
		}

		/// public propaty name  :  IsSelectAllSection
		/// <summary>全社選択プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   全社選択プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool IsSelectAllSection
		{
			get
			{
				bool isSelAlSec = false;
				if ( ( this._paymentAddupSecCodeList.Length == 1 ) && ( this._paymentAddupSecCodeList[0].CompareTo( "0" ) == 0 ) )
				{
					isSelAlSec = true;
				}
				return isSelAlSec;
			}
		}

        /// public propaty name  :  CAddUpUpdExecDate
        /// <summary>締日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CAddUpUpdExecDate
        {
            get { return _cAddUpUpdExecDate; }
            set { _cAddUpUpdExecDate = value; }
        }

		/// public propaty name  :  PrintDiv
		/// <summary>帳票タイプ区分プロパティ</summary>
		/// <value>設定の用途コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   帳票タイプ区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public int PrintDiv
		{
			get{return _printDiv;}
			set{_printDiv = value;}
		}

		/// public propaty name  :  PrintDivName
		/// <summary>帳票タイプ区分プロパティ名称(読み取り専用)</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   帳票タイプ区分プロパティ名称</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PrintDivName
		{
			get{return _printDivName;}
			set{_printDivName = value;}
		}

		/// public propaty name  :  St_PayeeCode
		/// <summary>開始支払先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始支払先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_PayeeCode
		{
			get{return _st_PayeeCode;}
			set{_st_PayeeCode = value;}
		}

		/// public propaty name  :  Ed_PayeeCode
		/// <summary>終了支払先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
        /// <br>note             :   終了支払先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_PayeeCode
		{
            get { return _ed_PayeeCode; }
            set { _ed_PayeeCode = value; }
		}

        /// public propaty name  :  OutputMoneyDiv
        /// <summary>出力金額区分コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力金額区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OutputMoneyDiv
        {
            get { return _outputMoneyDiv; }
            set { _outputMoneyDiv = value; }
        }

        /// public propaty name  :  SumPayeeDetail
        /// <summary>総括支払先内訳コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総括支払先内訳コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SumPayeeDetail
        {
            get { return _sumPayeeDetail; }
            set { _sumPayeeDetail = value; }
        }

        /// public propaty name  :  BalancePayeeDetail
        /// <summary>残高支払内訳コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   残高支払内訳コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BalancePayeeDetail
        {
            get { return _balancePayeeDetail; }
            set { _balancePayeeDetail = value; }
        }

        /// public propaty name  :  NewPageDiv
        /// <summary>改頁プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改頁プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NewPageDiv
        {
            get { return _newPageDiv; }
            set { _newPageDiv = value; }
        }
		#endregion ■ Public Property

		#region ■ Public Enum
		#region ◆ 帳票タイプ区分列挙体
		/// <summary> 帳票タイプ区分列挙体 </summary>
		public enum PrintDivState
		{
			/// <summary> 明細 </summary>
            DetailTyp = 1
		}
		#endregion

		#endregion ■ Public Enum

		#region ■ Constructor
		/// <summary>
		/// ワークコンストラクタ
		/// </summary>
        /// <returns>PaymentMainCndtnクラスのインスタンス</returns>
		/// <remarks>
        /// <br>Note             :   PaymentMainCndtnクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SumSuplierPayMainCndtn()
		{
			this._paymentAddupSecCodeList	= new string[0];	// 計上拠点コードリスト 
		}
		#endregion ■ Constructor

	}
}

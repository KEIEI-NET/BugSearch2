//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 売掛残高一覧表(総括)
// プログラム概要   : 売掛残高一覧表(総括)の印字を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/06/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11570208-00 作成担当 : 3H 劉星光
// 作 成 日  2020/04/10  修正内容 : 軽減税率対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SumExtrInfo_BillBalance
	/// <summary>
	///                      売掛残高一覧表(総括)抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   売掛残高一覧表(総括)抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2009/06/19  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
    /// <br>UpdateNote       :   11570208-00 軽減税率対応</br>
    /// <br>Programmer       :   3H 劉星光</br>
    /// <br>Date	         :   2020/04/10</br>
	/// </remarks>
	public class SumExtrInfo_BillBalance
	{
		#region ■ Private Member
		/// <summary>企業コード</summary>
		private string _enterpriseCode = string.Empty;

		/// <summary>拠点オプション導入区分</summary>
		private bool _isOptSection;

		/// <summary>本社機能プロパティ</summary>
		private bool _isMainOfficeFunc;

		/// <summary>選択計上拠点コード</summary>
		private string[] _collectAddupSecCodeList;

        /// <summary>計上年月日</summary>
        private DateTime _addUpDate;

        /// <summary>対象年月</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _addUpYearMonth;

        /// <summary>出力順</summary>
		/// <remarks>0:得意先順 1:担当者順 2:地区順</remarks>
		private Int32 _sortOrderDiv;

        /// <summary>担当者区分</summary>
		/// <remarks>0:得意先担当 1:集金担当</remarks>
		private Int32 _employeeKindDiv;

		/// <summary>開始担当者コード</summary>
		private string _st_EmployeeCode = "";

		/// <summary>終了担当者コード</summary>
		private string _ed_EmployeeCode = "";

		/// <summary>開始販売エリアコード</summary>
		private Int32 _st_SalesAreaCode;

		/// <summary>終了販売エリアコード</summary>
		private Int32 _ed_SalesAreaCode;

		/// <summary>開始請求先コード</summary>
		private Int32 _st_ClaimCode;

		/// <summary>終了請求先コード</summary>
		private Int32 _ed_ClaimCode;

		/// <summary>出力金額区分</summary>
		/// <remarks>0:全て 1:0とﾌﾟﾗｽ 2:ﾌﾟﾗｽのみ 3:0のみ 4:0以外 5:0とﾏｲﾅｽ 6:ﾏｲﾅｽのみ</remarks>
		private Int32 _outMoneyDiv;

		/// <summary>入金内訳区分</summary>
		/// <remarks>0:印字する 1:印字しない</remarks>
		private Int32 _depoDtlDiv;

        /// <summary>帳票タイプ区分</summary>
        /// <remarks>設定コードと同じ</remarks>
        private int _printDiv;

        /// <summary>帳票タイプ区分名称</summary>
        private string _printDivName = string.Empty;

        /// <summary>改頁</summary>
        private Int32 _newPageType;

        /// <summary>月次更新未処理フラグ</summary>
        private bool _monAddUpNonProcFlg;

        // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
        /// <summary>消費税別の内訳区分</summary>
        /// <remarks>0:印字する 1:印字しない</remarks>
        private Int32 _taxPrintDiv;

        /// <summary>税率1</summary>
        private Double _taxRate1;

        /// <summary>税率2</summary>
        private Double _taxRate2;
        // --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<
		#endregion ■ Private Member

		#region ■ Private Const
		/// <summary>共通 日付フォーマット</summary>
		public const string ct_DateFomat = "YYYY/MM/DD";
        /// <summary>共通 日付フォーマット</summary>
        public const string ct_MonthFomat = "YYYY/MM";

		/// <summary>共通 全て コード</summary>
		public const int ct_All_Code = -1;
		/// <summary>共通 全て 名称</summary>
		public const string ct_All_Name	= "全て";

		// 帳票タイプ区分 ------------------------------------------------------------------
        /// <summary>帳票タイプ区分 売掛残高一覧表(総括)</summary>
        public const string ct_PrintDiv_SumBillBalanceTyp = "売掛残高一覧表(総括)";

        // 出力順区分 ----------------------------------------------------------------
        /// <summary>出力順区分 得意先順</summary>
        public const string ct_SortOrderDiv_CustomerCode = "得意先順";
        /// <summary>出力順区分 担当者順</summary>
        public const string ct_SortOrderDiv_Employee = "担当者順";
        /// <summary>出力順区分 地区順</summary>
        public const string ct_SortOrderDiv_SalesAreaCode = "地区順";

        // 担当者区分 ----------------------------------------------------------------
        /// <summary>担当者区分 集金担当</summary>
        public const string ct_EmployeeKindDiv_BillCollecter = "集金担当";
        /// <summary>担当者区分 得意先担当</summary>
        public const string ct_EmployeeKindDiv_Customer = "得意先担当";

        // 出力金額区分 --------------------------------------------------------------------
        /// <summary>全て</summary>
        public const string ct_OutMoneyDiv_All = "全て出力";
        /// <summary>0+プラス金額</summary>
        public const string ct_OutMoneyDiv_ZeroPlus = "0とプラス金額を出力";
        /// <summary>プラス金額</summary>
        public const string ct_OutMoneyDiv_Plus = "プラス金額のみ出力";
        /// <summary>0出力</summary>
        public const string ct_OutMoneyDiv_Zero = "0のみ出力";
        /// <summary>プラス金額+マイナス金額</summary>
        public const string ct_OutMoneyDiv_PlusMinus = "プラス金額とマイナス金額";
        /// <summary>0+マイナス金額</summary>
        public const string ct_OutMoneyDiv_ZeroMinus = "0とマイナス金額を出力";
        /// <summary>マイナス金額</summary>
        public const string ct_OutMoneyDiv_Minus = "マイナス金額のみ出力";
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

		/// public propaty name  :  CollectAddupSecCodeList
		/// <summary>選択計上拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   選択計上拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] CollectAddupSecCodeList
		{
			get{return _collectAddupSecCodeList;}
			set{_collectAddupSecCodeList = value;}
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
				if ( ( this._collectAddupSecCodeList.Length == 1 ) && ( this._collectAddupSecCodeList[0].CompareTo( "0" ) == 0 ) )
				{
					isSelAlSec = true;
				}
				return isSelAlSec;
			}
		}

        /// public propaty name  :  AddUpDate
        /// <summary>計上年月日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpDate
        {
            get { return _addUpDate; }
            set { _addUpDate = value; }
        }

        /// public propaty name  :  AddUpYearMonth
		/// <summary>対象年月プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   対象年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AddUpYearMonth
		{
			get{return _addUpYearMonth;}
			set{_addUpYearMonth = value;}
		}

        /// public propaty name  :  SortOrderDiv
		/// <summary>出力順プロパティ</summary>
		/// <value>0:得意先順 1:担当者順 2:地区順</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力順プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SortOrderDiv
		{
			get{return _sortOrderDiv;}
			set{_sortOrderDiv = value;}
		}

        /// public propaty name  :  SortOrderDivName
        /// <summary>出力順名称プロパティ(読み取り専用)</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力順名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SortOrderDivName
        {
            get
            {
                string sortOrderDivName = string.Empty;
                // 出力順から名称を判断
                switch ((SortOrderDivState)this._sortOrderDiv)
                {
                    case SortOrderDivState.CustomerCode:		    // 得意先順
                        sortOrderDivName = ct_SortOrderDiv_CustomerCode;
                        break;
                    case SortOrderDivState.EmployeeCode:            // 担当者順
                        sortOrderDivName = ct_SortOrderDiv_Employee;
                        break;
                    case SortOrderDivState.SalesAreaCode:	        // 地区順
                        sortOrderDivName = ct_SortOrderDiv_SalesAreaCode;
                        break;
                    default:
                        sortOrderDivName = string.Empty;
                        break;
                }
                return sortOrderDivName;
            }
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
            get { return _printDiv; }
            set { _printDiv = value; }
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
            get { return _printDivName; }
            set { _printDivName = value; }
        }

        /// public propaty name  :  St_ClaimCode
        /// <summary>開始請求先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始請求先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_ClaimCode
        {
            get { return _st_ClaimCode; }
            set { _st_ClaimCode = value; }
        }

        /// public propaty name  :  Ed_ClaimCode
        /// <summary>終了請求先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了請求先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_ClaimCode
        {
            get { return _ed_ClaimCode; }
            set { _ed_ClaimCode = value; }
        }

        /// public propaty name  :   St_SalesAreaCode
        /// <summary>開始販売エリアコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始販売エリアコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_SalesAreaCode
        {
            get { return _st_SalesAreaCode; }
            set { _st_SalesAreaCode = value; }
        }

        /// public propaty name  :   Ed_SalesAreaCode
        /// <summary>終了販売エリアコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了販売エリアコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_SalesAreaCode
        {
            get { return _ed_SalesAreaCode; }
            set { _ed_SalesAreaCode = value; }
        }

        /// public propaty name  :  EmployeeKindDiv
		/// <summary>担当者区分プロパティ</summary>
		/// <value>0:得意先担当 1:集金担当</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   担当者区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EmployeeKindDiv
		{
			get{return _employeeKindDiv;}
			set{_employeeKindDiv = value;}
		}

        /// public propaty name  :  EmployeeKindDivName
        /// <summary>担当者区分名称プロパティ(読み取り専用)</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   担当者区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeKindDivName
        {
            get
            {
                string employeeKindDivName = string.Empty;
                // 担当者区分から名称を判断
                switch ((EmployeeKindDivState)this._employeeKindDiv)
                {
                    case EmployeeKindDivState.BillCollecter:	  // 集金担当
                        employeeKindDivName = ct_EmployeeKindDiv_BillCollecter;
                        break;
                    case EmployeeKindDivState.Customer:		      // 顧客担当
                        employeeKindDivName = ct_EmployeeKindDiv_Customer;
                        break;
                    default:
                        employeeKindDivName = string.Empty;
                        break;
                }
                return employeeKindDivName;
            }
        }

        /// public propaty name  :  St_EmployeeCode
        /// <summary>開始担当者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_EmployeeCode
        {
            get { return _st_EmployeeCode; }
            set { _st_EmployeeCode = value; }
        }

        /// public propaty name  :  Ed_EmployeeCode
        /// <summary>終了担当者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_EmployeeCode
        {
            get { return _ed_EmployeeCode; }
            set { _ed_EmployeeCode = value; }
        }

        /// public propaty name  :  OutMoneyDiv
        /// <summary>出力金額区分プロパティ</summary>
        /// <value>0:全て 1:0とﾌﾟﾗｽ 2:ﾌﾟﾗｽのみ 3:0のみ 4:0以外 5:0とﾏｲﾅｽ 6:ﾏｲﾅｽのみ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力金額区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OutMoneyDiv
        {
            get { return _outMoneyDiv; }
            set { _outMoneyDiv = value; }
        }

        /// public propaty name  :  OutMoneyDivName
        /// <summary>出力金額区分名称プロパティ(読み取り専用)</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力金額区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OutMoneyDivName
        {
            get
            {
                string outMoneyDivName = string.Empty;
                // 出力金額区分から名称を判断
                switch ((OutMoneyDivState)this._outMoneyDiv)
                {
                    case OutMoneyDivState.All:		    // 全て
                        outMoneyDivName = ct_OutMoneyDiv_All;
                        break;
                    case OutMoneyDivState.ZeroPlus:	   // 0+プラス金額
                        outMoneyDivName = ct_OutMoneyDiv_ZeroPlus;
                        break;
                    case OutMoneyDivState.Plus:	       // プラス金額
                        outMoneyDivName = ct_OutMoneyDiv_Plus;
                        break;
                    case OutMoneyDivState.Zero:	       // 0出力
                        outMoneyDivName = ct_OutMoneyDiv_Zero;
                        break;
                    case OutMoneyDivState.PlusMinus:   // プラス金額+マイナス金額
                        outMoneyDivName = ct_OutMoneyDiv_PlusMinus;
                        break;
                    case OutMoneyDivState.ZeroMinus:   // 0+マイナス金額
                        outMoneyDivName = ct_OutMoneyDiv_ZeroMinus;
                        break;
                    case OutMoneyDivState.Minus:       // マイナス金額
                        outMoneyDivName = ct_OutMoneyDiv_Minus;
                        break;
                    default:
                        outMoneyDivName = string.Empty;
                        break;
                }
                return outMoneyDivName;
            }
        }

        /// public propaty name  :  NewPageType
        /// <summary>改頁プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改頁プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NewPageType
        {
            get { return _newPageType; }
            set { _newPageType = value; }
        }

        /// public propaty name  :  DepoDtlDiv
        /// <summary>入金内訳区分プロパティ</summary>
        /// <value>0:印字する 1:印字しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金内訳区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepoDtlDiv
        {
            get { return _depoDtlDiv; }
            set { _depoDtlDiv = value; }
        }

        /// public propaty name  :  MonAddUpNonProcFlg
        /// <summary>月次更新未処理フラグプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   月次更新未処理フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool MonAddUpNonProcFlg
        {
            get { return _monAddUpNonProcFlg; }
            set { _monAddUpNonProcFlg = value; }
        }

        // --- ADD START 3H 劉星光 2020/04/10 ---------->>>>>
        /// public propaty name  :  TaxPrintDiv
        /// <summary>税別内訳印字区分</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税別内訳印字区分</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TaxPrintDiv
        {
            get { return _taxPrintDiv; }
            set { _taxPrintDiv = value; }
        }

        /// public propaty name  :  TaxRate1
        /// <summary>税率1</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率1</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TaxRate1
        {
            get { return _taxRate1; }
            set { _taxRate1 = value; }
        }

        /// public propaty name  :  TaxRate2
        /// <summary>税率2</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   税率2</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TaxRate2
        {
            get { return _taxRate2; }
            set { _taxRate2 = value; }
        }
        // --- ADD END 3H 劉星光 2020/04/10 ----------<<<<<
		#endregion ■ Public Property

		#region ■ Public Enum
		#region ◆ 帳票タイプ区分列挙体
		/// <summary> 帳票タイプ区分列挙体 </summary>
		public enum PrintDivState
		{
			/// <summary> 売掛残高一覧表(総括) </summary>
            SumBillBalanceTyp = 1
		}

        #region ◆ 出力順列挙体
        /// <summary> 出力順列挙体 </summary>
        public enum SortOrderDivState
        {
            /// <summary> 得意先順 </summary>
            CustomerCode = 1,
            /// <summary> 担当者 </summary>
            EmployeeCode = 2,
            /// <summary> 販売エリアコード順 </summary>
            SalesAreaCode = 3
        }
        #endregion ◆

        #region ◆ 担当者区分列挙体
        /// <summary> 担当者区分列挙体 </summary>
        public enum EmployeeKindDivState
        {
            /// <summary> 得意先担当 </summary>
            Customer = 0,
            /// <summary> 集金担当 </summary>
            BillCollecter = 1
        }
        #endregion ◆

        #region ◆ 出力金額区分列挙体
        /// <summary> 出力金額区分列挙体 </summary>
        public enum OutMoneyDivState
        {
            /// <summary>全て</summary>
            All = 0,
            /// <summary>0+プラス金額</summary>
            ZeroPlus = 1,
            /// <summary>プラス金額</summary>
            Plus = 2,
            /// <summary>0出力</summary>
            Zero = 3,
            /// <summary>プラス金額+マイナス金額</summary>
            PlusMinus = 4,
            /// <summary>0+マイナス金額</summary>
            ZeroMinus = 5,
            /// <summary>マイナス金額</summary>
            Minus = 6
        }
        #endregion ◆

		#endregion

		#endregion ■ Public Enum

		#region ■ Constructor
        /// <summary>
        /// 売掛残高一覧表(総括)抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>SumExtrInfo_BillBalanceクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SumExtrInfo_BillBalanceクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SumExtrInfo_BillBalance()
		{
			this._collectAddupSecCodeList	= new string[0];	// 計上拠点コードリスト 
		}
		#endregion ■ Constructor

	}
}

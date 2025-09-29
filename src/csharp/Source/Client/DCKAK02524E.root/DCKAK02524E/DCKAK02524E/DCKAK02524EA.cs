using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 支払確認表抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   </br>
	/// <br>Programmer       :   20081 疋田 勇人</br>
	/// <br>Date             :   2007.9.10</br>
    /// <br>UpdateNote       :   2008/08/05 30415 柴田 倫幸</br>
    /// <br>        	          PM.NS対応</br>   	
    /// <br>Update Note      :   2012/10/03 FSI今野 利裕</br>
    /// <br>                     仕入先総括対応</br>
    /// <br>Update Note      :   2014/09/15 zhangll</br>
    /// <br>                     ㈱陸整自動車用品 罫線印字区分、改頁区分の追加</br>
    /// </remarks>
	public class PaymentMainCndtn　　
	{
		#region ■ Private Member
		/// <summary>企業コード</summary>
		private string _enterpriseCode = string.Empty;

		/// <summary>拠点オプション導入区分</summary>
		private bool _isOptSection;

        // --- DEL 2008/08/05 -------------------------------->>>>>
        ///// <summary>本社機能プロパティ</summary>
		//private bool _isMainOfficeFunc;
        // --- DEL 2008/08/05 --------------------------------<<<<< 

		/// <summary>選択支払計上拠点コード</summary>
		private string[] _paymentAddupSecCodeList;

		/// <summary>開始支払計上日</summary>
		private DateTime _st_AddUpADate;

		/// <summary>終了支払計上日</summary>
		private DateTime _ed_AddUpADate;

        /// <summary>開始支払入力日</summary>
        private DateTime _st_InputDate;           

        /// <summary>終了支払入力日</summary>
        private DateTime _ed_InputDate;           

		/// <summary>帳票タイプ区分</summary>
		/// <remarks>設定コードと同じ</remarks>
		private int _printDiv;

        // --- DEL 2008/08/05 -------------------------------->>>>>
        ///// <summary>帳票タイプ区分名称</summary>
        //private string _printDivName = string.Empty;

        ///// <summary>小計区分</summary>
        ///// <remarks>0:日計,1:支払先計,2:金種計,3:支払番号</remarks>
		//private SumDivState _sumDiv;

        ///// <summary>小計区分毎改ページ区分</summary>
		//private bool _isChangePageDiv;
        // --- DEL 2008/08/05 --------------------------------<<<<< 

        /// <summary>出力順</summary>
        private SortOrderDivState _sortOrderDiv;

		/// <summary>開始支払先コード</summary>
		private Int32 _st_PayeeCode;

		/// <summary>終了支払先コード</summary>
        private Int32 _ed_PayeeCode;

		/// <summary>開始支払先カナ</summary>
        private string _st_PayeeKana = string.Empty;

		/// <summary>終了支払先カナ</summary>
        private string _ed_PayeeKana = string.Empty;

        // --- DEL 2008/08/05 -------------------------------->>>>>
        ///// <summary>担当者区分</summary>
        ///// <remarks>0:支払担当 1:入力担当</remarks>
        //private EmployeeKindDivState _employeeKindDiv;

        ///// <summary>開始担当者コード</summary>
        //private string _st_EmployeeCode = string.Empty;

        ///// <summary>終了担当者コード</summary>
        //private string _ed_EmployeeCode = string.Empty;
        // --- DEL 2008/08/05 --------------------------------<<<<< 

		/// <summary>開始支払番号</summary>
		private Int32 _st_PaymentSlipNo;

		/// <summary>終了支払番号</summary>
		private Int32 _ed_PaymentSlipNo;

		/// <summary>支払金種</summary>
		/// <remarks>Key:金種コード,Value:金種名称</remarks>
		private SortedList _paymentKind;

        // ----- ADD zhangll 2014/09/15 for ㈱陸整自動車用品 罫線印字区分、改頁区分の追加 ----->>>>>
        /// <summary>罫線印字区分</summary>
        private int _lineMaSqOfChDiv;

        /// <summary>改頁区分</summary>
        private Int32 _newPageType;
        // ----- ADD zhangll 2014/09/15 for ㈱陸整自動車用品 罫線印字区分、改頁区分の追加 -----<<<<<

		#endregion ■ Private Member

		#region ■ Private Const
		/// <summary>共通 日付フォーマット</summary>
		public const string ct_DateFomat						= "YYYY/MM/DD";

		/// <summary>共通 全て コード</summary>
		public const int ct_All_Code							= -1;
		/// <summary>共通 全て 名称</summary>
		public const string ct_All_Name							= "全て";

		// 帳票タイプ区分 ------------------------------------------------------------------
		/// <summary>帳票タイプ区分 総合計</summary>
		public const string ct_PrintDiv_GrandTotal				= "総合計";
		/// <summary>帳票タイプ区分 詳細</summary>
		public const string ct_PrintDiv_Details		            = "詳細";
		/// <summary>帳票タイプ区分 簡易 - 日計</summary>
		public const string ct_PrintDiv_Simple_Day				= "簡易";
        /// <summary>帳票タイプ区分 金種別集計</summary>
        public const string ct_PrintDiv_KindTotal              = "金種別集計";

		// 小計区分 ------------------------------------------------------------------
		/// <summary>小計区分 日計</summary>
		public const string ct_SumDiv_Day						= "日付";
		/// <summary>小計区分 支払先計</summary>
        public const string ct_SumDiv_Payee                     = "支払先";
		/// <summary>小計区分 金種計</summary>
		public const string ct_SumDiv_PaymentKind				= "金種";
		/// <summary>小計区分 支払番号</summary>
        public const string ct_SumDiv_PaymentSlipNo             = "支払番号";

		// 印刷用小計区分 ------------------------------------------------------------------
		/// <summary>印刷用小計区分 日計</summary>
		public const string ct_SumDivPrint_Day					= "日計";
		/// <summary>印刷用小計区分 支払先計</summary>
		public const string ct_SumDivPrint_Payee				= "支払先計";
		/// <summary>印刷用小計区分 金種計</summary>
		public const string ct_SumDivPrint_PaymentKind			= "金種計";
		/// <summary>印刷用小計区分 支払番号順</summary>
		public const string ct_SumDivPrint_PaymentSlipNo		= "支払番号";

		// 出力順区分 ----------------------------------------------------------------
        // --- DEL 2008/08/05 -------------------------------->>>>>
        ///// <summary>出力順区分 支払先コード順</summary>
        //public const string ct_SortOrderDiv_PayeeCode		    = "支払先コード順";
        ///// <summary>出力順区分 支払先カナ順</summary>
        //public const string ct_SortOrderDiv_PayeeKana		    = "支払先カナ順";
        ///// <summary>出力順区分 担当者コード順</summary>
        //public const string ct_SortOrderDiv_EmployeeCode		= "担当者コード順";
        // --- DEL 2008/08/05 --------------------------------<<<<< 

        // --- ADD 2008/08/05 -------------------------------->>>>>
        /// <summary>出力順区分 支払日順</summary>
        public const string ct_SortOrderDiv_PayeeDate = "支払日順";
        /// <summary>出力順区分 入力日順</summary>
        public const string ct_SortOrderDiv_InputDate = "入力日順";
        /// <summary>出力順区分 伝票番号順</summary>
        public const string ct_SortOrderDiv_SlipNo = "伝票番号順";
        // --- ADD 2008/08/05 --------------------------------<<<<< 
        // --- ADD 2012/10/03 ---------------------------->>>>>
        /// <summary>出力順区分 仕入先-拠点順</summary>
        public const string ct_SortOrderDiv_SupplSec = "仕入先-拠点順";
        // --- ADD 2012/10/03 ----------------------------<<<<<

		// 担当者区分 ----------------------------------------------------------------
		/// <summary>担当者区分 支払先担当</summary>
		public const string ct_EmployeeKindDiv_Payee			= "支払先担当";
		/// <summary>担当者区分 支払担当</summary>
		public const string ct_EmployeeKindDiv_Payment			= "入力担当";

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

        // --- DEL 2008/08/05 -------------------------------->>>>>
        ///// public propaty name  :  IsMainOfficeFunc
        ///// <summary>本社機能プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   本社機能プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public bool IsMainOfficeFunc
        //{
        //    get{return _isMainOfficeFunc;}
        //    set{_isMainOfficeFunc = value;}
        //}
        // --- DEL 2008/08/05 --------------------------------<<<<< 

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

		/// public propaty name  :  St_AddUpADate
		/// <summary>開始支払計上日プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始支払計上日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime St_AddUpADate
		{
			get{return _st_AddUpADate;}
			set{_st_AddUpADate = value;}
		}

		/// public propaty name  :  Ed_AddupADate
		/// <summary>終了支払計上日プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了支払計上日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime Ed_AddupADate
		{
			get{return _ed_AddUpADate;}
			set{_ed_AddUpADate = value;}
		}

        /// public propaty name  :  St_AddUpADate
        /// <summary>開始支払入力日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始支払入力日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_InputDate
        {
            get { return _st_InputDate; }
            set { _st_InputDate = value; }
        }

        /// public propaty name  :  Ed_AddupADate
        /// <summary>終了支払入力日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了支払入力日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_InputDate
        {
            get { return _ed_InputDate; }
            set { _ed_InputDate = value; }
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

        // --- DEL 2008/08/05 -------------------------------->>>>>
        ///// public propaty name  :  PrintDivName
        ///// <summary>帳票タイプ区分プロパティ名称(読み取り専用)</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   帳票タイプ区分プロパティ名称</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string PrintDivName
        //{
        //    get{return _printDivName;}
        //    set{_printDivName = value;}
        //}

        ///// public propaty name  :  SumDiv
        ///// <summary>小計区分プロパティ</summary>
        ///// <value>0:日計,1:支払先計,2:金種計,3:支払番号</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   小計区分プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public SumDivState SumDiv
        //{
        //    get{return _sumDiv;}
        //    set{_sumDiv = value;}
        //}

        ///// public propaty name  :  SumDivName
        ///// <summary>小計区分名称プロパティ(読み取り専用)</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   小計区分名称プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string SumDivName
        //{
        //    get
        //    {
        //        string sumDivName = string.Empty;
        //        // 小計区分から名称を判断
        //        switch ( this._sumDiv )
        //        {
        //            case SumDivState.Day:					// 日計
        //                sumDivName = ct_SumDiv_Day;
        //                break;
        //            case SumDivState.Payee: 				// 支払先計
        //                sumDivName = ct_SumDiv_Payee;
        //                break;
        //            case SumDivState.PaymentKind:			// 金種計
        //                sumDivName = ct_SumDiv_PaymentKind;
        //                break;
        //            case SumDivState.PaymentSlipNo:			// 支払番号
        //                sumDivName = ct_SumDiv_PaymentSlipNo;
        //                break;
        //            default:
        //                sumDivName = string.Empty;
        //                break;
        //        }
        //        return sumDivName;
        //    }
        //}

        ///// public propaty name  :  SumDivName
        ///// <summary>小計区分名称プロパティ(読み取り専用)</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   小計区分名称プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string SumDivPrintName
        //{
        //    get
        //    {
        //        string sumDivName = string.Empty;
        //        // 小計区分から名称を判断
        //        switch ( this._sumDiv )
        //        {
        //            case SumDivState.Day:					// 日計
        //                sumDivName = ct_SumDivPrint_Day;
        //                break;
        //            case SumDivState.Payee:				    // 支払先計
        //                sumDivName = ct_SumDivPrint_Payee;
        //                break;
        //            case SumDivState.PaymentKind:			// 金種計
        //                sumDivName = ct_SumDivPrint_PaymentKind;
        //                break;
        //            case SumDivState.PaymentSlipNo:			// 支払番号
        //                sumDivName = ct_SumDivPrint_PaymentSlipNo;
        //                break;
        //            default:
        //                sumDivName = string.Empty;
        //                break;
        //        }
        //        return sumDivName;
        //    }
        //}

        ///// public propaty name  :  IsChangePageDiv
        ///// <summary>小計区分毎改ページ区分プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   小計区分毎改ページ区分プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public bool IsChangePageDiv
        //{
        //    get{return _isChangePageDiv;}
        //    set{_isChangePageDiv = value;}
        //}
        // --- DEL 2008/08/05 --------------------------------<<<<< 

        /// public propaty name  :  SortOrderDiv
        /// <summary>出力順プロパティ</summary>
        /// <value>0:支払日順,1:入力日順,2:伝票番号順</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力順プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SortOrderDivState SortOrderDiv
        {
            get { return _sortOrderDiv; }
            set { _sortOrderDiv = value; }
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
                switch (this._sortOrderDiv)
                {
                    // --- DEL 2008/08/05 -------------------------------->>>>>
                    //case SortOrderDivState.PayeeCode:		// 支払先コード順
                    //    sortOrderDivName = ct_SortOrderDiv_PayeeCode;
                    //    break;
                    //case SortOrderDivState.PayeeKana:		// 支払先カナ順
                    //    sortOrderDivName = ct_SortOrderDiv_PayeeKana;
                    //    break;
                    //case SortOrderDivState.EmployeeCode:	// 担当者コード順
                    //    sortOrderDivName = ct_SortOrderDiv_EmployeeCode;
                    //    break;
                    // --- DEL 2008/08/05 --------------------------------<<<<< 

                    // --- ADD 2008/08/05 -------------------------------->>>>>
                    case SortOrderDivState.PayeeDate:  // 支払日順
                        sortOrderDivName = ct_SortOrderDiv_PayeeDate;
                        break;
                    case SortOrderDivState.InputDate:  // 入力日順
                        sortOrderDivName = ct_SortOrderDiv_InputDate;
                        break;
                    case SortOrderDivState.SlipNo:	   // 伝票番号順
                        sortOrderDivName = ct_SortOrderDiv_SlipNo;
                        break;
                    // --- ADD 2008/08/05 --------------------------------<<<<< 
                    // --- ADD 2012/10/03 ---------------------------->>>>>
                    case SortOrderDivState.SupplSec:	// 仕入先-拠点順
                        sortOrderDivName = ct_SortOrderDiv_SupplSec;
                        break;
                    // --- ADD 2012/10/03 ----------------------------<<<<<
                    default:
                        sortOrderDivName = string.Empty;
                        break;
                }
                return sortOrderDivName;
            }
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

		/// public propaty name  :  St_PayeeKana
		/// <summary>開始支払先カナプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始支払先カナプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_PayeeKana
		{
            get { return _st_PayeeKana; }
            set { _st_PayeeKana = value; }
		}

		/// public propaty name  :  Ed_PayeeKana
		/// <summary>終了支払先カナプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了支払先カナプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_PayeeKana
		{
            get { return _ed_PayeeKana; }
            set { _ed_PayeeKana = value; }
		}

        // --- DEL 2008/08/05 -------------------------------->>>>>
        ///// public propaty name  :  EmployeeKindDiv
        ///// <summary>担当者区分プロパティ</summary>
        ///// <value>0:支払担当 1:入力担当 </value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   担当者区分プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public EmployeeKindDivState EmployeeKindDiv
        //{
        //    get{return _employeeKindDiv;}
        //    set{_employeeKindDiv = value;}
        //}

        ///// public propaty name  :  EmployeeKindDivName
        ///// <summary>担当者区分名称プロパティ(読み取り専用)</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   担当者区分名称プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string EmployeeKindDivName
        //{
        //    get
        //    {
        //        string employeeKindDivName = string.Empty;
        //        // 担当者区分から名称を判断
        //        switch ( this._employeeKindDiv )
        //        {
        //            case EmployeeKindDivState.Payee:		// 支払先担当
        //                employeeKindDivName = ct_EmployeeKindDiv_Payee;
        //                break;
        //            case EmployeeKindDivState.InPayment:	// 入力担当
        //                employeeKindDivName = ct_EmployeeKindDiv_Payment;
        //                break;
        //            default:
        //                employeeKindDivName = string.Empty;
        //                break;
        //        }
        //        return employeeKindDivName;
        //    }
        //}

        ///// public propaty name  :  St_EmployeeCode
        ///// <summary>開始担当者コードプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   開始担当者コードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string St_EmployeeCode
        //{
        //    get{return _st_EmployeeCode;}
        //    set{_st_EmployeeCode = value;}
        //}

        ///// public propaty name  :  Ed_EmployeeCode
        ///// <summary>終了担当者コードプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   終了担当者コードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string Ed_EmployeeCode
        //{
        //    get{return _ed_EmployeeCode;}
        //    set{_ed_EmployeeCode = value;}
        //}
        // --- DEL 2008/08/05 --------------------------------<<<<< 

		/// public propaty name  :  St_PaymentSlipNo
		/// <summary>開始支払番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始支払番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_PaymentSlipNo
		{
			get{return _st_PaymentSlipNo;}
			set{_st_PaymentSlipNo = value;}
		}

		/// public propaty name  :  Ed_PaymentSlipNo
		/// <summary>終了支払番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了支払番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_PaymentSlipNo
		{
			get{return _ed_PaymentSlipNo;}
			set{_ed_PaymentSlipNo = value;}
		}

		/// public propaty name  :  PaymentKind
		/// <summary>支払金種プロパティ</summary>
		/// <value>Key:金種コード,Value:金種名称</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払金種プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SortedList PaymentKind
		{
			get{return _paymentKind;}
			set{_paymentKind = value;}
		}

        // ----- ADD zhangll 2014/09/15 for ㈱陸整自動車用品 罫線印字区分、改頁区分の追加 ----->>>>>
        /// public propaty name  :  LineMaSqOfChDiv
        /// <summary>罫線印字区分プロパティ名称</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   罫線印字区分プロパティ名称</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int LineMaSqOfChDiv
        {
            get { return _lineMaSqOfChDiv; }
            set { _lineMaSqOfChDiv = value; }
        }

        /// public propaty name  :  NewPageType
        /// <summary>改頁区分プロパティ名称</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改頁区分プロパティ名称</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NewPageType
        {
            get { return _newPageType; }
            set { _newPageType = value; }
        }
        // ----- ADD zhangll 2014/09/15 for ㈱陸整自動車用品 罫線印字区分、改頁区分の追加 -----<<<<<

		#endregion ■ Public Property

		#region ■ Public Enum
		#region ◆ 帳票タイプ区分列挙体
		/// <summary> 帳票タイプ区分列挙体 </summary>
		public enum PrintDivState
		{
			/// <summary> 総合計 </summary>
			GrandTotal = 1,
			/// <summary> 詳細 </summary>
			Details = 2,
			/// <summary> 簡易</summary>
			Simple = 3,
			/// <summary> 金種別集計 </summary>
            KindTotal = 4,
            // --- ADD 2012/10/03 ---------------------------->>>>>
            /// <summary> 簡易(仕入先-拠点順) </summary>
            Simple_SupplSec = 5,
            /// <summary> 金種別集計(仕入先-拠点順) </summary>
            KindTotal_SupplSec = 6,
            // --- ADD 2012/10/03 ----------------------------<<<<<
        }
		#endregion

		#region ◆ 小計区分列挙体
		/// <summary> 小計区分列挙体 </summary>
		public enum SumDivState
		{
			/// <summary> 日計 </summary>
			Day = 0,
			/// <summary> 支払先計 </summary>
			Payee = 1,
			/// <summary> 金種計 </summary>
			PaymentKind = 2,
			/// <summary> 支払番号 </summary>
			PaymentSlipNo = 3
		}
		#endregion ◆

		#region ◆ 出力順列挙体
		/// <summary> 出力順列挙体 </summary>
		public enum SortOrderDivState
		{
            // --- DEL 2008/08/05 -------------------------------->>>>>
            ///// <summary> 支払先コード順 </summary>
            //PayeeCode = 0,
            ///// <summary> 支払先カナ順 </summary>
            //PayeeKana = 1,
            ///// <summary> 担当者コード順 </summary>
            //EmployeeCode = 2
            // --- DEL 2008/08/05 --------------------------------<<<<< 

            // --- ADD 2008/08/05 -------------------------------->>>>>
            /// <summary> 支払日順 </summary>
            PayeeDate = 0,
            /// <summary> 入力日順 </summary>
            InputDate = 1,
            /// <summary> 伝票番号順 </summary>
            SlipNo = 2,
            // --- ADD 2008/08/05 --------------------------------<<<<< 
            // --- ADD 2012/10/03 ---------------------------->>>>>
            /// <summary> 仕入先-拠点順 </summary>
            SupplSec = 3,
            // --- ADD 2012/10/03 ----------------------------<<<<<
        }
		#endregion ◆

		#region ◆ 担当者区分列挙体
		/// <summary> 担当者区分列挙体 </summary>
		public enum EmployeeKindDivState
		{
			/// <summary> 支払先担当 </summary>
			Payee = 0,
			/// <summary> 入力担当 </summary>
            InPayment = 1
		}
		#endregion ◆

		#endregion ■ Public Enum

		#region ■ Constructor
		/// <summary>
		/// ワークコンストラクタ
		/// </summary>
        /// <returns>PaymentMainCndtnクラスのインスタンス</returns>
		/// <remarks>
        /// <br>Note　　　　　　 :   PaymentMainCndtnクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public PaymentMainCndtn()
		{
			this._paymentAddupSecCodeList	= new string[0];	// 計上拠点コードリスト 
			this._st_AddUpADate				= DateTime.Now;		// 開始支払計上日
			this._ed_AddUpADate				= DateTime.Now;		// 終了支払計上日
            this._st_InputDate              = DateTime.Now;     // 開始支払入力日
            this._ed_InputDate              = DateTime.Now;     // 終了支払入力日  
            this._paymentKind				= new SortedList();	// 支払金種
		}
		#endregion ■ Constructor

	}
}

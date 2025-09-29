using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name: DepositMainCndtn
	/// <summary>
	/// 入金一覧表抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2007.3.5</br>
	/// <br>Genarated Date   :   2007/03/05  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2012/11/14 李亜博</br>
    ///	<br>			         Redmine#33271 印字制御の区分の追加</br> 
    /// <br>UpdateNote       :   2013/01/05 zhuhh</br>
    /// <br>管理番号         :   10806793-00 2013/03/13配信分</br>
    /// <br>                 :   redmine #33796 改頁制御を追加する</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class DepositMainCndtn
	{
		#region ■ Private Member
		/// <summary>企業コード</summary>
		private string _enterpriseCode = string.Empty;

		/// <summary>拠点オプション導入区分</summary>
		private bool _isOptSection;

		/// <summary>本社機能プロパティ</summary>
		private bool _isMainOfficeFunc;

		/// <summary>選択入金計上拠点コード</summary>
		private string[] _depositAddupSecCodeList;

		/// <summary>開始入金計上日</summary>
		private DateTime _st_AddUpADate;

		/// <summary>終了入金計上日</summary>
		private DateTime _ed_AddUpADate;

        // 2007.11.14 追加 >>>>>>>>>>>>>>>>>>>>
		/// <summary>開始入力日</summary>
		private DateTime _st_CreateDate;

        /// <summary>終了入力日</summary>
		private DateTime _ed_CreateDate;
        // 2007.11.14 追加 <<<<<<<<<<<<<<<<<<<<

        /// <summary>帳票タイプ区分</summary>
		/// <remarks>設定コードと同じ</remarks>
		private int _printDiv;

        /// <summary>帳票タイプ区分名称</summary>
		private string _printDivName = string.Empty;

        // 2008.07.23 30413 犬飼 項目削除 >>>>>>START
        ///// <summary>小計区分</summary>
        ///// <remarks>0:日計,1:得意先計,2:金種計,3:入金番号</remarks>
        //private SumDivState _sumDiv;
        
        ///// <summary>小計区分毎改ページ区分</summary>
        //private bool _isChangePageDiv;
        // 2008.07.23 30413 犬飼 項目削除 <<<<<<END
        
		/// <summary>出力順</summary>
		/// <remarks>0:得意先コード順,1:得意先カナ順,2:入金担当コード順</remarks>
		private SortOrderDivState _sortOrderDiv;

		/// <summary>開始得意先コード</summary>
		private Int32 _st_CustomerCode;

		/// <summary>終了得意先コード</summary>
		private Int32 _ed_CustomerCode;

        // 2008.07.23 30413 犬飼 項目削除 >>>>>>START
        ///// <summary>開始得意先カナ</summary>
        //private string _st_CustomerKana = string.Empty;

        ///// <summary>終了得意先カナ</summary>
        //private string _ed_CustomerKana = string.Empty;

        ///// <summary>担当者区分</summary>
        ///// <remarks>0:得意先担当 1:集金担当 2:入金担当</remarks>
        //private EmployeeKindDivState _employeeKindDiv;

        ///// <summary>開始担当者コード</summary>
        //private string _st_EmployeeCode = string.Empty;

        ///// <summary>終了担当者コード</summary>
        //private string _ed_EmployeeCode = string.Empty;
        // 2008.07.23 30413 犬飼 項目削除 <<<<<<END
        
        // 2008.07.14 30413 犬飼 項目削除 >>>>>>START
        ///// <summary>個人法人区分</summary>
        //private SortedList _corporateDivCode;
        // 2008.07.14 30413 犬飼 項目削除 <<<<<<END
        
		/// <summary>開始入金番号</summary>
		private Int32 _st_DepositSlipNo;

		/// <summary>終了入金番号</summary>
		private Int32 _ed_DepositSlipNo;

		/// <summary>入金金種</summary>
		/// <remarks>Key:金種コード,Value:金種名称</remarks>
		private SortedList _depositKind;

        // 2007.11.14 追加 >>>>>>>>>>>>>>>>>>>>
        /// <summary>入金金種（選択判定）</summary>
        private ArrayList _depositKindCode;
        
        /// <summary>入金金種（名称用）</summary>
        /// <remarks>Key:金種コード,Value:金種名称</remarks>
        private SortedList _depositKindName;
        // 2007.11.14 追加 <<<<<<<<<<<<<<<<<<<<

        // 2008.07.14 30413 犬飼 項目削除 >>>>>>START
        ///// <summary>クレジットローン区分</summary>
        ///// <remarks>-1:全て,1:クレジット,2:ローン</remarks>
        //private CreditOrLoanCdState _creditOrLoanCd;
        // 2008.07.14 30413 犬飼 項目削除 <<<<<<END
        
		/// <summary>引当区分</summary>
		/// <remarks>-1:全て,0:引当済,1:一部引当,2:未引当</remarks>
		private AllowanceDivState _allowanceDiv;

		/// <summary>入金区分</summary>
		/// <remarks>-1:全て,0:通常入金,1:預り金入金</remarks>
		private DepositCdState _depositCd;

        // --- ADD 李亜博 2012/11/14 for Redmine#33271---------->>>>>
        /// <summary>罫線印字区分</summary>
        private int _lineMaSqOfChDiv;
        // --- ADD 李亜博 2012/11/14 for Redmine#33271----------<<<<<

        // ----- ADD zhuhh 2013/01/05 for Redmine #33796 ----->>>>>
        /// <summary>改頁区分</summary>
        private Int32 _newPageType;
        // ----- ADD zhuhh 2013/01/05 for Redmine #33796 -----<<<<<
		#endregion ■ Private Member

		#region ■ Private Const
		/// <summary>共通 日付フォーマット</summary>
		public const string ct_DateFomat						= "YYYY/MM/DD";

		/// <summary>共通 全て コード</summary>
		public const int ct_All_Code							= -1;
		/// <summary>共通 全て 名称</summary>
		public const string ct_All_Name							= "全て";

		// 帳票タイプ区分 ------------------------------------------------------------------
        // 2008.07.09 30413 犬飼 帳票タイプの変更 >>>>>>START
        ///// <summary>帳票タイプ区分 総合計</summary>
        //public const string ct_PrintDiv_GrandTotal				= "総合計";
        ///// <summary>帳票タイプ区分 詳細 - 引当有</summary>
        //public const string ct_PrintDiv_Details_HaveDraw		= "詳細-引当有";
        ///// <summary>帳票タイプ区分 詳細 - 引当無</summary>
        //public const string ct_PrintDiv_Details_NotDraw			= "詳細-引当無";
        ///// <summary>帳票タイプ区分 簡易 - 日計</summary>
        //public const string ct_PrintDiv_Simple_Day				= "簡易";
        //// 2007.11.14 追加 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>帳票タイプ区分 金種別集計</summary>
        //public const string ct_PrintDiv_DepositKind             = "金種別集計";
        //// 2007.11.14 追加 <<<<<<<<<<<<<<<<<<<<
        /// <summary>帳票タイプ区分 入金確認表</summary>
        public const string ct_PrintDiv_DepsitMainList = "入金確認表";
        /// <summary>帳票タイプ区分 入金確認表（集計表）</summary>
        public const string ct_PrintDiv_DepositMainList_Sum = "入金確認表（集計表）";
        // 2008.07.09 30413 犬飼 帳票タイプの変更 <<<<<<END

        // 2008.07.23 30413 犬飼 項目削除 >>>>>>START
        //// 小計区分 ------------------------------------------------------------------
        ///// <summary>小計区分 日計</summary>
        //public const string ct_SumDiv_Day						= "日付";
        ///// <summary>小計区分 得意先計</summary>
        //public const string ct_SumDiv_Customer					= "得意先";
        ///// <summary>小計区分 金種計</summary>
        //public const string ct_SumDiv_DepositKind = "金種";
        ///// <summary>小計区分 入金番号</summary>
        //public const string ct_SumDiv_DepositSlipNo				= "入金番号";

        //// 印刷用小計区分 ------------------------------------------------------------------
        ///// <summary>印刷用小計区分 日計</summary>
        //public const string ct_SumDivPrint_Day					= "日計";
        ///// <summary>印刷用小計区分 得意先計</summary>
        //public const string ct_SumDivPrint_Customer				= "得意先計";
        ///// <summary>印刷用小計区分 金種計</summary>
        //public const string ct_SumDivPrint_DepositKind = "金種計";
        ///// <summary>印刷用小計区分 入金番号順</summary>
        //public const string ct_SumDivPrint_DepositSlipNo		= "入金番号";
        // 2008.07.23 30413 犬飼 項目削除 <<<<<<END
        
		// 出力順区分 ----------------------------------------------------------------
        // 2008.07.23 30413 犬飼 既存の出力順を削除 >>>>>>START
        ///// <summary>出力順区分 得意先コード順</summary>
        //public const string ct_SortOrderDiv_CustomerCode		= "得意先コード順";
        ///// <summary>出力順区分 得意先カナ順</summary>
        //public const string ct_SortOrderDiv_CustomerKane		= "得意先カナ順";
        ///// <summary>出力順区分 担当者コード順</summary>
        //public const string ct_SortOrderDiv_EmployeeCode		= "担当者コード順";
        // 2008.07.23 30413 犬飼 既存の出力順を削除 <<<<<<END
        // 2008.07.09 30413 犬飼 出力順の項目追加 >>>>>>START
        /// <summary>出力順区分 入金日順</summary>
        public const string ct_SortOrderDiv_AddUpDate = "入金日順";
        /// <summary>出力順区分 入力日順</summary>
        public const string ct_SortOrderDiv_CreateDate = "入力日順";
        /// <summary>出力順区分 伝票番号順</summary>
        public const string ct_SortOrderDiv_DepositSlipNo = "伝票番号順";
        // 2008.07.09 30413 犬飼 出力順の項目追加 <<<<<<END

        // 2008.07.23 30413 犬飼 項目削除 >>>>>>START
        //// 担当者区分 ----------------------------------------------------------------
        //// 2008.01.30 修正 >>>>>>>>>>>>>>>>>>>>
        /////// <summary>担当者区分 得意先担当</summary>
        ////public const string ct_EmployeeKindDiv_Customer			= "得意先担当";
        /////// <summary>担当者区分 集金担当</summary>
        ////public const string ct_EmployeeKindDiv_CollectMoney		= "集金担当";
        /////// <summary>担当者区分 入金担当</summary>
        ////public const string ct_EmployeeKindDiv_Deposit			= "入金担当";
        ///// <summary>担当者区分 得意先担当</summary>
        //public const string ct_EmployeeKindDiv_Customer			= "得意先担当者";
        ///// <summary>担当者区分 集金担当者</summary>
        //public const string ct_EmployeeKindDiv_CollectMoney		= "集金担当者";
        ///// <summary>担当者区分 入金担当者</summary>
        //public const string ct_EmployeeKindDiv_Deposit			= "入金担当者";
        ///// <summary>担当者区分 入金入力担当者</summary>
        //public const string ct_EmployeeKindDiv_DepositInput		= "入金入力担当者";
        //// 2008.01.30 修正 <<<<<<<<<<<<<<<<<<<<
        // 2008.07.23 30413 犬飼 項目削除 <<<<<<END
        
		// 入金区分 -----------------------------------------------------------------
		/// <summary>入金区分 通常入金</summary>
		public const string ct_DepositCd_Nomal					= "通常入金";
        // 2008.07.09 30413 犬飼 預り金入金の削除 >>>>>>START
        ///// <summary>入金区分 預かり金</summary>
        //public const string ct_DepositCd_Keep					= "預り金入金";
        // 2008.07.09 30413 犬飼 預り金入金の削除 <<<<<<END
        /// <summary>入金区分 自動入金</summary>
		public const string ct_DepositCd_Auto					= "自動入金";

        // 2008.07.14 30413 犬飼 項目削除 >>>>>>START
        //// クレジットローン区分 ------------------------------------------------------
        ///// <summary>クレジットローン区分 クレジット</summary>
        //public const string ct_CreditOrLoanCd_Credit			= "クレジット";
        ///// <summary>クレジットローン区分 ローン</summary>
        //public const string ct_CreditOrLoanCd_Loan				= "ローン";
        // 2008.07.14 30413 犬飼 項目削除 <<<<<<END
        
		// 引当区分 -----------------------------------------------------------------
		/// <summary>引当区分 引当済</summary>
		public const string ct_Allowance_Ending					= "引当済";
		/// <summary>引当区分 一部引当</summary>
		public const string ct_Allowance_Part					= "一部引当";
		/// <summary>引当区分 未引当</summary>
		public const string ct_Allowance_Still					= "未引当";
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

		/// public propaty name  :  DepositAddupSecCodeList
		/// <summary>選択入金計上拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   選択入金計上拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] DepositAddupSecCodeList
		{
			get{return _depositAddupSecCodeList;}
			set{_depositAddupSecCodeList = value;}
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
				if ( ( this._depositAddupSecCodeList.Length == 1 ) && ( this._depositAddupSecCodeList[0].CompareTo( "0" ) == 0 ) )
				{
					isSelAlSec = true;
				}
				return isSelAlSec;
			}
		}

		/// public propaty name  :  St_AddUpADate
		/// <summary>開始入金計上日プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始入金計上日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime St_AddUpADate
		{
			get{return _st_AddUpADate;}
			set{_st_AddUpADate = value;}
		}

		/// public propaty name  :  Ed_AddupADate
		/// <summary>終了入金計上日プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了入金計上日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime Ed_AddupADate
		{
			get{return _ed_AddUpADate;}
			set{_ed_AddUpADate = value;}
		}

        // 2007.11.14 追加 >>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  St_CreateDate
        /// <summary>開始入力日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始入力日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_CreateDate
        {
            get { return _st_CreateDate; }
            set { _st_CreateDate = value; }
        }

        /// public propaty name  :  Ed_CreateDate
        /// <summary>終了入力日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了入力日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_CreateDate
        {
            get { return _ed_CreateDate; }
            set { _ed_CreateDate = value; }
        }
        // 2007.11.14 追加 <<<<<<<<<<<<<<<<<<<<

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

        // 2008.07.23 30413 犬飼 項目削除 >>>>>>START
        ///// public propaty name  :  SumDiv
        ///// <summary>小計区分プロパティ</summary>
        ///// <value>0:日計,1:顧客計,2:金種計,3:入金番号</value>
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
        //            case SumDivState.Customer:				// 得意先計
        //                sumDivName = ct_SumDiv_Customer;
        //                break;
        //            case SumDivState.DepositKind:			// 金種計
        //                sumDivName = ct_SumDiv_DepositKind;
        //                break;
        //            case SumDivState.DepositSlipNo:			// 入金番号
        //                sumDivName = ct_SumDiv_DepositSlipNo;
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
        //            case SumDivState.Customer:				// 得意先計
        //                sumDivName = ct_SumDivPrint_Customer;
        //                break;
        //            case SumDivState.DepositKind:			// 金種計
        //                sumDivName = ct_SumDivPrint_DepositKind;
        //                break;
        //            case SumDivState.DepositSlipNo:			// 入金番号
        //                sumDivName = ct_SumDivPrint_DepositSlipNo;
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
        // 2008.07.23 30413 犬飼 項目削除 <<<<<<END
        
		/// public propaty name  :  SortOrderDiv
		/// <summary>出力順プロパティ</summary>
		/// <value>0:得意先コード順,1:得意先カナ順,2:入金担当コード順</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力順プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SortOrderDivState SortOrderDiv
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
				switch ( this._sortOrderDiv )
				{
                    case SortOrderDivState.AddUpDate:           // 入金日
                        sortOrderDivName = ct_SortOrderDiv_AddUpDate;
                        break;
                    case SortOrderDivState.CreateDate:          // 入力日
                        sortOrderDivName = ct_SortOrderDiv_CreateDate;
                        break;
                    case SortOrderDivState.DepositSlipNo:       // 伝票番号
                        sortOrderDivName = ct_SortOrderDiv_DepositSlipNo;
                        break;
                    // 2008.07.23 30413 犬飼 既存の出力順を削除 >>>>>>START
                    //case SortOrderDivState.CustomerCode:		// 得意先コード順
                    //    sortOrderDivName = ct_SortOrderDiv_CustomerCode;
                    //    break;
                    //case SortOrderDivState.CustomerKane:		// 得意先カナ順
                    //    sortOrderDivName = ct_SortOrderDiv_CustomerKane;
                    //    break;
                    //case SortOrderDivState.EmployeeCode:		// 担当者コード順
                    //    sortOrderDivName = ct_SortOrderDiv_EmployeeCode;
                    //    break;
                    // 2008.07.23 30413 犬飼 既存の出力順を削除 <<<<<<END
                    default:
						sortOrderDivName = string.Empty;
						break;
				}
				return sortOrderDivName;
			}
		}

		/// public propaty name  :  St_CustomerCode
		/// <summary>開始得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_CustomerCode
		{
			get{return _st_CustomerCode;}
			set{_st_CustomerCode = value;}
		}

		/// public propaty name  :  Ed_CustomerCode
		/// <summary>終了得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_CustomerCode
		{
			get{return _ed_CustomerCode;}
			set{_ed_CustomerCode = value;}
		}

        // 2008.07.23 30413 犬飼 項目削除 >>>>>>START
        ///// public propaty name  :  St_CustomerKana
        ///// <summary>開始得意先カナプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   開始得意先カナプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string St_CustomerKana
        //{
        //    get{return _st_CustomerKana;}
        //    set{_st_CustomerKana = value;}
        //}

        ///// public propaty name  :  Ed_CustomerKana
        ///// <summary>終了得意先カナプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   終了得意先カナプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string Ed_CustomerKana
        //{
        //    get{return _ed_CustomerKana;}
        //    set{_ed_CustomerKana = value;}
        //}

        ///// public propaty name  :  EmployeeKindDiv
        ///// <summary>担当者区分プロパティ</summary>
        ///// <value>0:得意先担当 1:集金担当 2:入金担当</value>
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
        //            case EmployeeKindDivState.Customer:		// 得意先担当
        //                employeeKindDivName = ct_EmployeeKindDiv_Customer;
        //                break;
        //            case EmployeeKindDivState.CollectMoney:	// 集金担当
        //                employeeKindDivName = ct_EmployeeKindDiv_CollectMoney;
        //                break;
        //            case EmployeeKindDivState.Deposit:		// 入金担当
        //                employeeKindDivName = ct_EmployeeKindDiv_Deposit;
        //                break;
        //            // 2008.01.30 追加 >>>>>>>>>>>>>>>>>>>>
        //            case EmployeeKindDivState.DepositInput:	// 入金入力担当
        //                employeeKindDivName = ct_EmployeeKindDiv_DepositInput;
        //                break;
        //            // 2008.01.30 追加 <<<<<<<<<<<<<<<<<<<<
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
        // 2008.07.23 30413 犬飼 項目削除 <<<<<<END

        // 2008.07.14 30413 犬飼 項目削除 >>>>>>START
        ///// public propaty name  :  CorporateDivCode
        ///// <summary>個人法人区分プロパティ</summary>
        ///// <value>Key:個人法人区分,Value:個人法人区分名称</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   個人法人区分プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public SortedList CorporateDivCode
        //{
        //    get{return _corporateDivCode;}
        //    set{_corporateDivCode = value;}
        //}
        // 2008.07.14 30413 犬飼 項目削除 <<<<<<END
        
		/// public propaty name  :  St_DepositSlipNo
		/// <summary>開始入金番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始入金番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_DepositSlipNo
		{
			get{return _st_DepositSlipNo;}
			set{_st_DepositSlipNo = value;}
		}

		/// public propaty name  :  Ed_DepositSlipNo
		/// <summary>終了入金番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了入金番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_DepositSlipNo
		{
			get{return _ed_DepositSlipNo;}
			set{_ed_DepositSlipNo = value;}
		}

		/// public propaty name  :  DepositKind
		/// <summary>入金金種プロパティ</summary>
		/// <value>Key:金種コード,Value:金種名称</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金金種プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SortedList DepositKind
		{
			get{return _depositKind;}
			set{_depositKind = value;}
		}

        // 2007.11.14 追加 >>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  DepositKind
        /// <summary>入金金種プロパティ（選択判定）</summary>
        /// <value>Key:金種コード,Value:金種名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金種プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList DepositKindCode
        {
            get { return _depositKindCode; }
            set { _depositKindCode = value; }
        }

        /// public propaty name  :  DepositKind
        /// <summary>入金金種プロパティ（名称用）</summary>
        /// <value>Key:金種コード,Value:金種名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金金種プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SortedList DepositKindName
        {
            get { return _depositKindName; }
            set { _depositKindName = value; }
        }

        // 2007.11.14 追加 <<<<<<<<<<<<<<<<<<<<

        // 2008.07.14 30413 犬飼 項目削除 >>>>>>START
        ///// public propaty name  :  CreditOrLoanCd
        ///// <summary>クレジットローン区分プロパティ</summary>
        ///// <value>-1:全て,1:クレジット,2:ローン</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   クレジットローン区分プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public CreditOrLoanCdState CreditOrLoanCd
        //{
        //    get{return _creditOrLoanCd;}
        //    set{_creditOrLoanCd = value;}
        //}
        // 2008.07.14 30413 犬飼 項目削除 <<<<<<END

        // 2008.07.14 30413 犬飼 項目削除 >>>>>>START
        ///// public propaty name  :  CreditOrLoanNm
        ///// <summary>クレジットローン区分名称プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   クレジットローン区分名称プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string CreditOrLoanNm
        //{
        //    get
        //    {
        //        string creditOrLoanNm = string.Empty;
        //        // クレジットローン区分区分から名称を判断
        //        switch ( this._creditOrLoanCd )
        //        {
        //            case CreditOrLoanCdState.All:		// 全て
        //                creditOrLoanNm = ct_All_Name;
        //                break;
        //            case CreditOrLoanCdState.Credit:	// クレジット
        //                creditOrLoanNm = ct_CreditOrLoanCd_Credit;
        //                break;
        //            case CreditOrLoanCdState.Loan:		// ローン
        //                creditOrLoanNm = ct_CreditOrLoanCd_Loan;
        //                break;
        //            default:
        //                creditOrLoanNm = string.Empty;
        //                break;
        //        }
        //        return creditOrLoanNm;
        //    }
        //}
        // 2008.07.14 30413 犬飼 項目削除 <<<<<<END
        
		/// public propaty name  :  AllowanceDiv
		/// <summary>引当状態プロパティ</summary>
		/// <value>-1:全て,0:引当済,1:一部引当,2:未引当</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   引当状態プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public AllowanceDivState AllowanceDiv
		{
			get{return _allowanceDiv;}
			set{_allowanceDiv = value;}
		}

		/// public propaty name  :  AllowanceDivName
		/// <summary>引当状態名称プロパティ(読み取り専用)</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   引当状態名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AllowanceDivName
		{
			get
			{
				string allowanceDivName = string.Empty;
				// 引当状態から名称を判断
				switch ( this._allowanceDiv )
				{
					case AllowanceDivState.All:			// 全て
						allowanceDivName = ct_All_Name;
						break;
					case AllowanceDivState.Ending:		// 引当済
						allowanceDivName = ct_Allowance_Ending;
						break;
					case AllowanceDivState.Part:		// 一部引当
						allowanceDivName = ct_Allowance_Part;
						break;
					case AllowanceDivState.Still:		// 未引当
						allowanceDivName = ct_Allowance_Still;
						break;
					default:
						allowanceDivName = string.Empty;
						break;
				}

				return allowanceDivName;
			}
		}

		/// public propaty name  :  DepositDiv
		/// <summary>入金区分プロパティ</summary>
		/// <value>0:通常入金,1:預り金入金</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DepositCdState DepositCd
		{
			get{return _depositCd;}
			set{_depositCd = value;}
		}

		/// public propaty name  :  DepositNm
		/// <summary>入金区分名称プロパティ(読み取り専用)</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金区分名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DepositNm
		{
			get
			{
				string depositCd = string.Empty;
                // 入金区分から名称を判断
				switch ( this._depositCd )
				{
					case DepositCdState.All:		// 全て
						depositCd = ct_All_Name;
						break;
					case DepositCdState.Nomal:		// 通常入金
						depositCd = ct_DepositCd_Nomal;
						break;
                    // 2008.07.09 30413 犬飼 預り金入金の削除 >>>>>>START
                    //case DepositCdState.Keep:		// 預り金入金
                    //    depositCd = ct_DepositCd_Keep;
                    //    break;
                    // 2008.07.09 30413 犬飼 預り金入金の削除 <<<<<<END
                    // 2008.01.30 追加 >>>>>>>>>>>>>>>>>>>>
                    case DepositCdState.Auto:		// 自動入金
                        depositCd = ct_DepositCd_Auto;
                        break;
                    // 2008.01.30 追加 <<<<<<<<<<<<<<<<<<<<
                    default:
						depositCd = string.Empty;
						break;
				}
				return depositCd;
			}
		}
        // --- ADD 李亜博 2012/11/14 for Redmine#33271---------->>>>>
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
        // --- ADD 李亜博 2012/11/14 for Redmine#33271----------<<<<<

        // ----- ADD zhuhh 2013/01/05 for Redmine #33796 ----->>>>>
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
        // ----- ADD zhuhh 2013/01/05 for Redmine #33796 -----<<<<<
		#endregion ■ Public Property

		#region ■ Public Enum
		#region ◆ 帳票タイプ区分列挙体
		/// <summary> 帳票タイプ区分列挙体 </summary>
		public enum PrintDivState
		{
            // 2008.07.09 30413 犬飼 帳票タイプの変更 >>>>>>START
            ///// <summary> 総合計 </summary>
            //GrandTotal = 1,
            //// 2007.11.14 修正 >>>>>>>>>>>>>>>>>>>>
            /////// <summary> 詳細 - 引当有 </summary>
            ////Details_HaveDraw = 2,
            /////// <summary> 詳細 - 引当無 </summary>
            ////Details_NotDraw = 3,
            /////// <summary> 簡易</summary>
            ////Simple = 4,
            ///// <summary> 詳細 - 引当無 </summary>
            //Details_NotDraw = 2,
            ///// <summary> 簡易</summary>
            //Simple = 3,
            ///// <summary> 金種別集計 </summary>
            //DepositKind = 4
            //// 2007.11.14 修正 <<<<<<<<<<<<<<<<<<<<
            /// <summary>帳票タイプ区分 入金確認表</summary>
            DepsitMainList = 3,
            /// <summary>帳票タイプ区分 入金確認表（集計表）</summary>
            DepositMainList_Sum = 4
            // 2008.07.09 30413 犬飼 帳票タイプの変更 <<<<<<END
		}
		#endregion

        // 2008.07.23 30413 犬飼 小計区分列挙体の削除 >>>>>>START
        #region ◆ 小計区分列挙体
        ///// <summary> 小計区分列挙体 </summary>
        //public enum SumDivState
        //{
        //    /// <summary> 日計 </summary>
        //    Day = 0,
        //    /// <summary> 得意先計 </summary>
        //    Customer = 1,
        //    // 2008.07.09 30413 犬飼 金種の削除 >>>>>>START
        //    ///// <summary> 金種計 </summary>
        //    //DepositKind = 2,
        //    // 2008.07.09 30413 犬飼 金種の削除 <<<<<<END
        //    /// <summary> 入金番号 </summary>
        //    DepositSlipNo = 3
        //}
		#endregion ◆
        // 2008.07.23 30413 犬飼 小計区分列挙体の削除 <<<<<<END
        
		#region ◆ 出力順列挙体
		/// <summary> 出力順列挙体 </summary>
		public enum SortOrderDivState
		{
			// 2008.07.09 30413 犬飼 出力順の変更 >>>>>>START
            ///// <summary> 得意先コード順 </summary>
            //CustomerCode = 0,
            ///// <summary> 得意先カナ順 </summary>
            //CustomerKane = 1,
            ///// <summary> 担当者コード順 </summary>
            //EmployeeCode = 2
            /// <summary> 入金日順 </summary>
            AddUpDate = 0,
            /// <summary> 入力日順 </summary>
            CreateDate = 1,
            /// <summary> 伝票番号順 </summary>
            DepositSlipNo = 2
            // 2008.07.09 30413 犬飼 出力順の変更 <<<<<<END
		}
		#endregion ◆

        // 2008.07.23 30413 犬飼 担当者区分列挙体の削除 >>>>>>START
        #region ◆ 担当者区分列挙体
        ///// <summary> 担当者区分列挙体 </summary>
        //public enum EmployeeKindDivState
        //{
        //    /// <summary> 得意先担当 </summary>
        //    Customer = 0,
        //    /// <summary> 集金担当 </summary>
        //    CollectMoney = 1,
        //    /// <summary> 入金担当 </summary>
        //    Deposit = 2,
        //    // 2008.01.30 追加 >>>>>>>>>>>>>>>>>>>>
        //    /// <summary> 入金入力担当 </summary>
        //    DepositInput = 3
        //    // 2008.01.30 追加 <<<<<<<<<<<<<<<<<<<<
        //}
		#endregion ◆
        // 2008.07.23 30413 犬飼 担当者区分列挙体の削除 <<<<<<END
        
        // 2008.07.14 30413 犬飼 項目削除 >>>>>>START
        #region ◆ クレジットローン区分列挙体
        ///// <summary> クレジットローン区分列挙体 </summary>
        //public enum CreditOrLoanCdState
        //{
        //    /// <summary> 全て </summary>
        //    All = ct_All_Code,
        //    /// <summary> クレジット </summary>
        //    Credit = 1,
        //    /// <summary> ローン </summary>
        //    Loan = 2
        //}
		#endregion ◆
        // 2008.07.14 30413 犬飼 項目削除 <<<<<<END
        
		#region ◆ 入金区分列挙体
		/// <summary> 入金区分列挙体 </summary>
		public enum DepositCdState
		{
            // 2008.07.23 30413 犬飼 入金区分の値を変更 >>>>>>START
            /// <summary> 全て </summary>
			//All = ct_All_Code,
            All = 0,
			/// <summary> 通常入金 </summary>
            //Nomal = 0,
            Nomal = 1,
            // 2008.07.09 30413 犬飼 預り金入金の削除 >>>>>>START
            ///// <summary> 預り金入金 </summary>
            //Keep = 1,
            // 2008.07.09 30413 犬飼 預り金入金の削除 <<<<<<END
            /// <summary> 自動入金 </summary>
			Auto = 2
            // 2008.07.23 30413 犬飼 入金区分の値を変更 <<<<<<END
        }
		#endregion ◆

        // 2008.07.11 30413 犬飼 引当区分列挙体の値を変更 >>>>>>START
        #region ◆ 引当区分列挙体
		/// <summary> 引当区分列挙体 </summary>
		public enum AllowanceDivState
		{
			/// <summary> 全て </summary>
            //All = ct_All_Code,
            All = 0,
            /// <summary> 引当済 </summary>
            //Ending = 0,
            Ending = 1,
            /// <summary> 一部引当 </summary>
            //Part = 1,
            Part = 2,
            /// <summary> 未引当 </summary>
            //Still = 2
			Still = 3
		}
		#endregion ◆
        // 2008.07.11 30413 犬飼 預り金入金の削除 <<<<<<END

        // 2008.07.14 30413 犬飼 項目削除 >>>>>>START
        #region ◆ 個人法人区分列挙体
        ///// <summary> 個人法人区分列挙体 </summary>
        //public enum CorporateDivCodeState
        //{
        //    /// <summary> 個人 </summary>
        //    Personal = 0,
        //    /// <summary> 法人 </summary>
        //    Juridical = 1,
        //    /// <summary> 大口法人 </summary>
        //    BigJuridical = 2,
        //    /// <summary> 業者 </summary>
        //    Supplier = 3,
        //    /// <summary> 社員 </summary>
        //    Employee = 4
        //}
		#endregion ◆
        // 2008.07.14 30413 犬飼 項目削除 <<<<<<END
        
		#endregion ■ Public Enum

		#region ■ Constructor
		/// <summary>
		/// ワークコンストラクタ
		/// </summary>
		/// <returns>DepositMainCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   DepositMainCndtnクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DepositMainCndtn()
		{
			this._depositAddupSecCodeList	= new string[0];	// 計上拠点コードリスト 
			this._st_AddUpADate				= DateTime.Now;		// 開始入金計上日
			this._ed_AddUpADate				= DateTime.Now;		// 終了入金計上日
            // 2008.07.14 30413 犬飼 項目削除 >>>>>>START
            //this._corporateDivCode = new SortedList();	// 個人法人区分
            // 2008.07.14 30413 犬飼 項目削除 <<<<<<END
            this._depositKind = new SortedList();	// 入金金種
		}
		#endregion ■ Constructor

	}
}

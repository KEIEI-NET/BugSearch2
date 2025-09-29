using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// 回収予定表抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   </br>
	/// <br>Programmer       :   20081 疋田 勇人</br>
	/// <br>Date             :   2007.10.23</br>
	/// <br>Update Note      :   </br>
    /// <br>UpdateNote       : 空白行印字制御・罫線印字制御の追加</br>
    /// <br>Programmer       : 鄧潘ハン</br>
    /// <br>Date	         : 2011/03/14</br>
    /// <br>Update Note      : 2012/06/27配信分 Redmine#29880 得意先名称印字の追加</br>
    /// <br>Programmer       : gezh</br>
    /// <br>Date	         : 2012/05/22</br>
    /// </remarks>
	public class RsltInfo_CollectPlan　　
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

		/// <summary>処理日付</summary>
        private DateTime _addUpADate;

        /// <summary>出力順</summary>
        /// <remarks>1:得意先順,2:担当者順,3:地区順,4:担当者別回収日順,5:地区別回収日順,6:集金日順,7:集金日別回収条件順</remarks>
        private SortOrderDivState _sortOrderDiv;

        /// <summary>帳票タイプ区分</summary>
        /// <remarks>設定コードと同じ</remarks>
        private int _printDiv;

        /// <summary>帳票タイプ区分名称</summary>
        private string _printDivName = string.Empty;

        /// <summary>締日</summary>
        private Int32 _totalDay;

		/// <summary>開始請求先コード</summary>
		private Int32 _st_ClaimCode;

        /// <summary>終了請求先コード</summary>
        private Int32 _ed_ClaimCode;

        /// <summary>開始販売エリアコード</summary>
        private Int32 _st_SalesAreaCode;

        /// <summary>終了販売エリアコード</summary>
        private Int32 _ed_SalesAreaCode;

		/// <summary>担当者区分</summary>
		/// <remarks>0:得意先担当 1:集金担当</remarks>
		private EmployeeKindDivState _employeeKindDiv;

		/// <summary>開始担当者コード</summary>
		private string _st_EmployeeCode = string.Empty;

		/// <summary>終了担当者コード</summary>
		private string _ed_EmployeeCode = string.Empty;

        /// <summary>回収日</summary>
        private Int32 _collectSchedule;

        /// <summary>回収条件</summary>
        /// <remarks>回収条件コード</remarks>
        private SortedList _collectCond;

        /// <summary>締日末日指定</summary>
        /// <remarks>true:28～31全て false:指定締日のみ</remarks>
        private Boolean _isLastDayTotalDay;

        /// <summary>回収予定日末日指定</summary>
        /// <remarks>true:28～31全て false:指定締日のみ</remarks>
        private Boolean _isLastDayCollectSchedule;

        // --- ADD 2009/02/24 障害ID:10843対応------------------------------------------------------>>>>>
        /// <summary>印刷区分</summary>
        /// <remarks>0:予定額＜0でも印字　1:予定額＜0は印字しない</remarks>
        private Int32 _printExpctDiv;
        // --- ADD 2009/02/24 障害ID:10843対応------------------------------------------------------<<<<<

        /// <summary>改頁</summary>
        private Int32 _newPageDiv;

        //---ADD 2011/03/14------------->>>>>
        /// <summary>
        /// 空白行印字
        /// </summary>
        private Int32 _printBlLiDiv;

        /// <summary>
        /// 罫線印字
        /// </summary>
        private Int32 _lineMaSqOfChDiv;
        //---ADD 2011/03/14-------------<<<<<
       
        // ADD 2012/05/22 gezh Redmine#29880 --------------------------------->>>>>
        /// <summary>得意先名称印字</summary>
        /// <remarks>0:得意先略称を印字する　1:得意先名を印字する</remarks>
        private Int32 _customerNamePrint;
        // ADD 2012/05/22 gezh Redmine#29880 ---------------------------------<<<<<

        #endregion ■ Private Member

		#region ■ Private Const
		/// <summary>共通 日付フォーマット</summary>
		public const string ct_DateFomat						= "YYYY/MM/DD";
        /// <summary>共通 年月フォーマット</summary>
        public const string ct_MonthFomat                       = "YYYY/MM";
		
        /// <summary>共通 全て コード</summary>
		public const int ct_All_Code							= -1;
		/// <summary>共通 全て 名称</summary>
		public const string ct_All_Name							= "全て";

		// 出力順区分 ----------------------------------------------------------------
        /// <remarks>1:得意先順,2:担当者順,3:地区順,4:担当者別回収日順,5:地区別回収日順,6:集金日順,7:集金日別回収条件順</remarks>
        /// <summary>出力順区分 得意先順</summary>
        public const string ct_SortOrderDiv_CustomerCode        = "得意先順";
		/// <summary>出力順区分 担当者順</summary>
		public const string ct_SortOrderDiv_EmployeeCode		= "担当者順";
        /// <summary>出力順区分 地区順</summary>
        public const string ct_SortOrderDiv_SalesAreaCode       = "地区順";
        /// <summary>出力順区分 担当者別回収日順</summary>
        public const string ct_SortOrderDiv_EmployeeCollect     = "担当者別回収日順";
        /// <summary>出力順区分 地区別回収日順</summary>
        public const string ct_SortOrderDiv_SalesAreaCollect    = "地区別回収日順";
        /// <summary>出力順区分 集金日順</summary>
        public const string ct_SortOrderDiv_CollectMoneyDay     = "集金日順";
        /// <summary>出力順区分 集金日別回収条件順</summary>
        public const string ct_SortOrderDiv_CollectMoneyDayCond = "集金日別回収条件順";
        
        // 帳票タイプ区分 ------------------------------------------------------------------
        /// <summary>帳票タイプ区分 回収予定表</summary>
        public const string ct_PrintDiv_CollectExpct = "回収予定表";
        /// <summary>帳票タイプ区分 回収予定表＋記入表</summary>
        public const string ct_PrintDiv_FillOut = "回収予定表＋記入表";
        /// <summary>帳票タイプ区分 回収実績表</summary>
        public const string ct_PrintDiv_Results  = "回収実績表";

        // 担当者区分 ----------------------------------------------------------------
		/// <summary>担当者区分 得意先担当</summary>
        public const string ct_EmployeeKindDiv_Customer      = "得意先担当";
		/// <summary>担当者区分 集金担当</summary>
        public const string ct_EmployeeKindDiv_BillCollecter = "集金担当";

        // 2009.02.24 30413 犬飼 回収条件の値を金種コードに合わせて修正 >>>>>>START
        // 回収条件 ---------------------------------------------------------------- 
        /// <summary>現金</summary>
        public const string ct_CollectCondDiv_Cash = "現金";
        /// <summary>振込</summary>
        public const string ct_CollectCondDiv_Remittance = "振込";
        /// <summary>小切手</summary>
        public const string ct_CollectCondDiv_Check = "小切手";
        /// <summary>手形</summary>
        public const string ct_CollectCondDiv_Bill = "手形";
        ///// <summary>手数料</summary>
        //public const string ct_CollectCondDiv_Fee = "手数料";
        /// <summary>相殺</summary>
        public const string ct_CollectCondDiv_Offset = "相殺";
        ///// <summary>値引</summary>
        //public const string ct_CollectCondDiv_Discount = "値引";
        /// <summary>その他</summary>
        public const string ct_CollectCondDiv_Others = "その他";
        /// <summary>口座振替</summary>
        public const string ct_CollectCondDiv_FundTransfer = "口座振替";
        /// <summary>ファクタリング</summary>
        public const string ct_CollectCondDiv_Factoring = "ファクタリング";
        // 2009.02.24 30413 犬飼 回収条件の値を金種コードに合わせて修正 <<<<<<END
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
		/// <summary>本社機能プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   本社機能プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool IsMainOfficeFunc
		{
			get{return _isMainOfficeFunc;}
			set{_isMainOfficeFunc = value;}
		}

		/// public propaty name  :  CollectAddupSecCodeList
		/// <summary>選択支払計上拠点コードプロパティ</summary>
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

		/// public propaty name  :  AddUpADate
        /// <summary>処理日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   処理日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime AddUpDate
		{
			get{return _addUpADate;}
			set{_addUpADate = value;}
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

		/// public propaty name  :  SortOrderDiv
		/// <summary>出力順プロパティ</summary>
        /// <value>1:1:得意先順,2:担当者順,3:地区順,4:担当者別回収日順,5:地区別回収日順,6:集金日順,7:集金日別回収条件順</value>
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
					case SortOrderDivState.CustomerCode:		   // 得意先順
						sortOrderDivName = ct_SortOrderDiv_CustomerCode;
						break;
					case SortOrderDivState.EmployeeCode:           // 担当者順
						sortOrderDivName = ct_SortOrderDiv_EmployeeCode;
						break;
					case SortOrderDivState.SalesAreaCode:	       // 地区順
						sortOrderDivName = ct_SortOrderDiv_SalesAreaCode;
						break;
                    case SortOrderDivState.EmployeeCollect:        // 担当者別回収日順
                        sortOrderDivName = ct_SortOrderDiv_EmployeeCollect;
                        break;
                    case SortOrderDivState.SalesAreaCollect:       // 地区別回収日順
                        sortOrderDivName = ct_SortOrderDiv_SalesAreaCollect;
                        break;
                    case SortOrderDivState.CollectMoneyDay:        // 集金日順
                        sortOrderDivName = ct_SortOrderDiv_CollectMoneyDay;
                        break;
                    case SortOrderDivState.CollectMoneyDayCond:    // 集金日別回収条件順
                        sortOrderDivName = ct_SortOrderDiv_CollectMoneyDayCond;
                        break;
					default:
						sortOrderDivName = string.Empty;
						break;
				}
				return sortOrderDivName;
			}
		}

        /// public propaty name  :  PrintDiv
        /// <summary>締日プロパティ</summary>
        /// <value>設定の用途コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int TotalDay
        {
            get { return _totalDay; }
            set { _totalDay = value; }
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
			get{return _st_ClaimCode;}
			set{_st_ClaimCode = value;}
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
        /// <value>0:得意先担当 1:回収担当 </value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   担当者区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public EmployeeKindDivState EmployeeKindDiv
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
				switch ( this._employeeKindDiv )
				{
					case EmployeeKindDivState.Customer:		      // 得意先担当
                        employeeKindDivName = ct_EmployeeKindDiv_Customer;
						break;
					case EmployeeKindDivState.BillCollecter:	  // 集金担当
						employeeKindDivName = ct_EmployeeKindDiv_BillCollecter;
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
			get{return _st_EmployeeCode;}
			set{_st_EmployeeCode = value;}
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
			get{return _ed_EmployeeCode;}
			set{_ed_EmployeeCode = value;}
		}

        /// public propaty name  :  ExpectedDepositDate
        /// <summary>回収予定日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回収予定日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ExpectedDepositDate
        {
            get { return _collectSchedule; }
            set { _collectSchedule = value; }
        }

        /// public propaty name  :  CollectCondDivState
        /// <summary>回収条件プロパティ</summary>
        /// <value>10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回収条件プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SortedList CollectCond
        {
            get { return _collectCond; }
            set { _collectCond = value; }
        }

        /// public propaty name  :  IsLastDayTotalDay
        /// <summary>締日末日指定プロパティ</summary>
        /// <value>true:28～31全て false:指定締日のみ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締日末日指定プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Boolean IsLastDayTotalDay
        {
            get { return _isLastDayTotalDay; }
            set { _isLastDayTotalDay = value; }
        }

        /// public propaty name  :  IsLastDayCollectSchedule
        /// <summary>回収予定日末日指定プロパティ</summary>
        /// <value>true:28～31全て false:指定締日のみ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回収予定日末日指定プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Boolean IsLastDayCollectSchedule
        {
            get { return _isLastDayCollectSchedule; }
            set { _isLastDayCollectSchedule = value; }
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

        /// public propaty name  :  PrintExpctDiv
        /// <summary>印刷区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintExpctDiv
        {
            get { return _printExpctDiv; }
            set { _printExpctDiv = value; }
        }

        //---ADD 2011/03/14------------->>>>>
        /// public propaty name  :  PrintBlLiDiv
        /// <summary>空白行印字</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   空白行印字制御・罫線印字制御の追加</br>
        /// <br>Programer        :   鄧潘ハン 2011/03/14 </br>
        /// </remarks>
        public Int32 PrintBlLiDiv
        {
            get { return _printBlLiDiv; }
            set { _printBlLiDiv = value; }
        }

       
        /// public propaty name  :  LineMaSqOfChDiv
        /// <summary>罫線印字</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   空白行印字制御・罫線印字制御の追加</br>
        /// <br>Programer        :   鄧潘ハン 2011/03/14</br>
        /// </remarks>
        public Int32 LineMaSqOfChDiv
        {
            get { return _lineMaSqOfChDiv; }
            set { _lineMaSqOfChDiv = value; }
        }
        //---ADD 2011/03/14-------------<<<<<

        // ADD 2012/05/22 gezh Redmine#29880 --------------------------------->>>>>
        /// public propaty name  :  CustomerNamePrint
        /// <summary>得意先名称印字</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名称印字制御の追加</br>
        /// <br>Programer        :   gezh 2012/05/22 </br>
        /// </remarks>
        public Int32 CustomerNamePrint
        {
            get { return _customerNamePrint; }
            set { _customerNamePrint = value; }
        }
        // ADD 2012/05/22 gezh Redmine#29880 ---------------------------------<<<<<

		#endregion ■ Public Property

		#region ■ Public Enum
		#region ◆ 帳票タイプ区分列挙体
		/// <summary> 帳票タイプ区分列挙体 </summary>
		public enum PrintDivState
		{
            /// <summary> 回収予定表 </summary>
            CollectExpct = 1,
            /// <summary> 回収予定表＋記入表 </summary>
            FillOut = 2,
            /// <summary> 回収実績表</summary>
            Results = 3
		}
		#endregion

		#region ◆ 出力順列挙体
		/// <summary> 出力順列挙体 </summary>
		public enum SortOrderDivState
		{
			/// <summary> 得意先順 </summary>
			CustomerCode = 1,
			/// <summary> 担当者順 </summary>
			EmployeeCode = 2,
			/// <summary> 地区順 </summary>
			SalesAreaCode = 3,
            /// <summary> 担当者別回収日順 </summary>
            EmployeeCollect = 4,
            /// <summary> 地区別回収日順 </summary>
            SalesAreaCollect = 5,
            /// <summary> 集金日順 </summary>
            CollectMoneyDay = 6,
            /// <summary> 集金日別回収条件順 </summary>
            CollectMoneyDayCond = 7
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

        #region ◆ 回収条件列挙体
        /// <summary> 回収条件列挙体 </summary>
        public enum CollectCondDivState
        {
            // 2009.02.24 30413 犬飼 回収条件の値を金種コードに合わせて修正 >>>>>>START
            ///// <summary> 現金 </summary>
            //Cash = 10,
            ///// <summary> 振込 </summary>
            //Remittance = 20,
            ///// <summary> 小切手 </summary>
            //Check = 30,
            ///// <summary> 手形 </summary>
            //Bill = 40,
            ///// <summary> 手数料 </summary>
            //Fee = 50,
            ///// <summary> 相殺 </summary>
            //Offset = 60,
            ///// <summary> 値引 </summary>
            //Discount = 70,
            ///// <summary> その他 </summary>
            //Others = 80
            /// <summary> 現金 </summary>
            Cash = 51,
            /// <summary> 振込 </summary>
            Remittance = 52,
            /// <summary> 小切手 </summary>
            Check = 53,
            /// <summary> 手形 </summary>
            Bill = 54,
            /// <summary> 相殺 </summary>
            Offset = 56,
            /// <summary> その他 </summary>
            Others = 58,
            /// <summary> 口座振替 </summary>
            FundTransfer = 59,
            /// <summary> ファクタリング </summary>
            Factoring = 60
            // 2009.02.24 30413 犬飼 回収条件の値を金種コードに合わせて修正 <<<<<<END
        }
        #endregion ◆

		#endregion ■ Public Enum

		#region ■ Constructor
		/// <summary>
		/// ワークコンストラクタ
		/// </summary>
        /// <returns>RsltInfo_CollectPlanクラスのインスタンス</returns>
		/// <remarks>
        /// <br>Note　　　　　　 :   RsltInfo_CollectPlanクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public RsltInfo_CollectPlan()
		{
			this._collectAddupSecCodeList	= new string[0];	// 計上拠点コードリスト 
			this._addUpADate				= DateTime.Now;		// 処理日
            this._collectCond            = new SortedList(); // 回収条件
		}
		#endregion ■ Constructor

	}
}

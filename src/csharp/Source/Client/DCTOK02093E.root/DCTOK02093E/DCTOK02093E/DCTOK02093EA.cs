using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ExtrInfo_DCTOK02093E
	/// <summary>
	///                      前年対比表抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   前年対比表抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008.11.25  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class ExtrInfo_DCTOK02093E
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>出力対象拠点</summary>
		/// <remarks>nullの場合は全拠点</remarks>
		private String[] _secCodeList;

		/// <summary>集計方法</summary>
		/// <remarks>0:全社集計 1:拠点別集計</remarks>
        private Int32 _totalWay;

		/// <summary>帳票タイプ</summary>
		/// <remarks>0:得意先別 1:担当者別 2:受注者別 3:地区別 4:業種別 5:グループコード別 6:BLコード別</remarks>
		private Int32 _listType;

		/// <summary>金額単位</summary>
		/// <remarks>0:一円単位 1:千円単位</remarks>
		private Int32 _moneyUnit;

		/// <summary>開始対象年月</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _st_AddUpYearMonth;

		/// <summary>終了対象年月</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _ed_AddUpYearMonth;

		/// <summary>前年比(開始当月純売上)</summary>
		/// <remarks>%指定</remarks>
		private Double _st_MonthSalesRatio;

		/// <summary>前年比(終了当月純売上)</summary>
		/// <remarks>%指定</remarks>
		private Double _ed_MonthSalesRatio;

		/// <summary>前年比(開始当年純売上)</summary>
		/// <remarks>%指定</remarks>
		private Double _st_YearSalesRatio;

		/// <summary>前年比(終了当年純売上)</summary>
		/// <remarks>%指定</remarks>
		private Double _ed_YearSalesRatio;

		/// <summary>前年比(開始当月粗利)</summary>
		/// <remarks>%指定</remarks>
		private Double _st_MonthGrossRatio;

		/// <summary>前年比(終了当月粗利)</summary>
		/// <remarks>%指定</remarks>
		private Double _ed_MonthGrossRatio;

		/// <summary>前年比(開始当年粗利)</summary>
		/// <remarks>%指定</remarks>
		private Double _st_YearGrossRatio;

		/// <summary>前年比(終了当年粗利)</summary>
		/// <remarks>%指定</remarks>
		private Double _ed_YearGrossRatio;

		/// <summary>開始従業員コード(受注者コードを兼ねる)</summary>
		/// <remarks>担当者別で使用</remarks>
		private string _st_EmployeeCode = "";

        /// <summary>終了従業員コード(受注者コードを兼ねる)</summary>
		/// <remarks>担当者別で使用</remarks>
		private string _ed_EmployeeCode = "";

		/// <summary>開始得意先コード</summary>
		/// <remarks>得意先別・地区別・業種別で使用</remarks>
		private Int32 _st_CustomerCode;

		/// <summary>終了得意先コード</summary>
		/// <remarks>得意先別・地区別・業種別で使用</remarks>
		private Int32 _ed_CustomerCode;

		/// <summary>開始販売エリアコード</summary>
		/// <remarks>地区別で使用</remarks>
		private Int32 _st_SalesAreaCode;

		/// <summary>終了販売エリアコード</summary>
		/// <remarks>地区別で使用</remarks>
		private Int32 _ed_SalesAreaCode;

		/// <summary>開始業種コード</summary>
		/// <remarks>業種別で使用</remarks>
		private Int32 _st_BusinessTypeCode;

		/// <summary>終了業種コード</summary>
		/// <remarks>業種別で使用</remarks>
		private Int32 _ed_BusinessTypeCode;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>出力順</summary>
		private Int32 _sortOrder;

		/// <summary>印刷タイプ</summary>
		/// <remarks>0:売上 1:粗利 2:売上＆粗利 </remarks>
		private Int32 _printType;

		/// <summary>改頁</summary>
		/// <remarks>True:する False:しない</remarks>
		private Boolean _newPage;

        /// <summary>改頁2</summary>
        /// <remarks>True:する False:しない</remarks>
        private Boolean _newPage2;

        /// <summary>発行タイプ</summary>
        /// <remarks>
        /// 得意先別： 0:得意先別 1:拠点別 2:得意先別拠点別 3:管理拠点別 4:請求先別 
        /// 担当者別： 0:担当者別 1:得意先別 2:担当者別拠点別 3:管理拠点別
        /// 受注者別： 0:受注者別 1:得意先別 2:受注者別拠点別 3:管理拠点別
        /// 地区別：   0:地区別 1:得意先別 2:地区別拠点別 3:管理拠点別
        /// 業種別：　 0:業種別 1:得意先別 2:業種別拠点別 3:管理拠点別
        /// グループコード別： 0:グループコード別 1:商品中分類別 2:商品大分類別
        /// BLコード別 0:BLコード別 1:BLコード得意先別 2:BLコート担当者別
        /// </remarks>
        private Int32 _issueType;

        /// <summary>BLコード開始</summary>
        private Int32 _st_BLGoodsCode;

        /// <summary>BLコード終了</summary>
        private Int32 _ed_BLGoodsCode;

        /// <summary>商品大分類コード開始</summary>
        private Int32 _st_GoodsLGroup;

        /// <summary>商品大分類コード終了</summary>
        private Int32 _ed_GoodsLGroup;

        /// <summary>商品中分類コード開始</summary>
        private Int32 _st_GoodsMGroup;

        /// <summary>商品中分類コード終了</summary>
        private Int32 _ed_GoodsMGroup;

        /// <summary>グループコード開始</summary>
        private Int32 _st_BLGroupCode;

        /// <summary>グループコード終了</summary>
        private Int32 _ed_BLGroupCode;
        
        /// <summary>前年比(開始当月純売上)入力判定</summary>
        /// <remarks>%指定</remarks>
        private Boolean _st_MonthSalesRatio_ck;

        /// <summary>前年比(終了当月純売上)入力判定</summary>
        /// <remarks>%指定</remarks>
        private Boolean _ed_MonthSalesRatio_ck;

        /// <summary>前年比(開始当年純売上)入力判定</summary>
        /// <remarks>%指定</remarks>
        private Boolean _st_YearSalesRatio_ck;

        /// <summary>前年比(終了当年純売上)入力判定</summary>
        /// <remarks>%指定</remarks>
        private Boolean _ed_YearSalesRatio_ck;

        /// <summary>前年比(開始当月粗利)入力判定</summary>
        /// <remarks>%指定</remarks>
        private Boolean _st_MonthGrossRatio_ck;

        /// <summary>前年比(終了当月粗利)入力判定</summary>
        /// <remarks>%指定</remarks>
        private Boolean _ed_MonthGrossRatio_ck;

        /// <summary>前年比(開始当年粗利)入力判定</summary>
        /// <remarks>%指定</remarks>
        private Boolean _st_YearGrossRatio_ck;

        /// <summary>前年比(終了当年粗利)入力判定</summary>
        /// <remarks>%指定</remarks>
        private Boolean _ed_YearGrossRatio_ck;

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

		/// public propaty name  :  SecCodeList
		/// <summary>出力対象拠点プロパティ</summary>
		/// <value>nullの場合は全拠点</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力対象拠点プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public String[] SecCodeList
		{
			get { return _secCodeList; }
			set { _secCodeList = value; }
		}

		/// public propaty name  :  TotalWay
		/// <summary>集計方法プロパティ</summary>
		/// <value>True:全社集計 False:拠点別集計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   集計方法プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32 TotalWay
		{
			get { return _totalWay; }
			set { _totalWay = value; }
		}

		/// public propaty name  :  ListType
		/// <summary>帳票タイププロパティ</summary>
		/// <value>0:拠点別 1:得意先別 2:担当者別 3:地区別 4:業種別 5:部署別(部署管理設定依存)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   帳票タイププロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ListType
		{
			get { return _listType; }
			set { _listType = value; }
		}

		/// public propaty name  :  MoneyUnit
		/// <summary>金額単位プロパティ</summary>
		/// <value>True:円 False:千円</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   金額単位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MoneyUnit
		{
			get { return _moneyUnit; }
			set { _moneyUnit = value; }
		}

		/// public propaty name  :  St_AddUpYearMonth
		/// <summary>開始対象年月プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始対象年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_AddUpYearMonth
		{
			get { return _st_AddUpYearMonth; }
			set { _st_AddUpYearMonth = value; }
		}

		/// public propaty name  :  Ed_AddUpYearMonth
		/// <summary>終了対象年月プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了対象年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_AddUpYearMonth
		{
			get { return _ed_AddUpYearMonth; }
			set { _ed_AddUpYearMonth = value; }
		}

		/// public propaty name  :  St_MonthSalesRatio
		/// <summary>前年比(開始当月純売上)プロパティ</summary>
		/// <value>%指定</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前年比(開始当月純売上)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double St_MonthSalesRatio
		{
			get { return _st_MonthSalesRatio; }
			set { _st_MonthSalesRatio = value; }
		}

		/// public propaty name  :  Ed_MonthSalesRatio
		/// <summary>前年比(終了当月純売上)プロパティ</summary>
		/// <value>%指定</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前年比(終了当月純売上)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double Ed_MonthSalesRatio
		{
			get { return _ed_MonthSalesRatio; }
			set { _ed_MonthSalesRatio = value; }
		}

		/// public propaty name  :  St_YearSalesRatio
		/// <summary>前年比(開始当年純売上)プロパティ</summary>
		/// <value>%指定</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前年比(開始当年純売上)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double St_YearSalesRatio
		{
			get { return _st_YearSalesRatio; }
			set { _st_YearSalesRatio = value; }
		}

		/// public propaty name  :  Ed_YearSalesRatio
		/// <summary>前年比(終了当年純売上)プロパティ</summary>
		/// <value>%指定</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前年比(終了当年純売上)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double Ed_YearSalesRatio
		{
			get { return _ed_YearSalesRatio; }
			set { _ed_YearSalesRatio = value; }
		}

		/// public propaty name  :  St_MonthGrossRatio
		/// <summary>前年比(開始当月粗利)プロパティ</summary>
		/// <value>%指定</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前年比(開始当月粗利)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double St_MonthGrossRatio
		{
			get { return _st_MonthGrossRatio; }
			set { _st_MonthGrossRatio = value; }
		}

		/// public propaty name  :  Ed_MonthGrossRatio
		/// <summary>前年比(終了当月粗利)プロパティ</summary>
		/// <value>%指定</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前年比(終了当月粗利)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double Ed_MonthGrossRatio
		{
			get { return _ed_MonthGrossRatio; }
			set { _ed_MonthGrossRatio = value; }
		}

		/// public propaty name  :  St_YearGrossRatio
		/// <summary>前年比(開始当年粗利)プロパティ</summary>
		/// <value>%指定</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前年比(開始当年粗利)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double St_YearGrossRatio
		{
			get { return _st_YearGrossRatio; }
			set { _st_YearGrossRatio = value; }
		}

		/// public propaty name  :  Ed_YearGrossRatio
		/// <summary>前年比(終了当年粗利)プロパティ</summary>
		/// <value>%指定</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   前年比(終了当年粗利)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double Ed_YearGrossRatio
		{
			get { return _ed_YearGrossRatio; }
			set { _ed_YearGrossRatio = value; }
		}

		/// public propaty name  :  St_EmployeeCode
		/// <summary>開始従業員コードプロパティ</summary>
		/// <value>担当者別で使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_EmployeeCode
		{
			get { return _st_EmployeeCode; }
			set { _st_EmployeeCode = value; }
		}

		/// public propaty name  :  Ed_EmployeeCode
		/// <summary>終了従業員コードプロパティ</summary>
		/// <value>担当者別で使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_EmployeeCode
		{
			get { return _ed_EmployeeCode; }
			set { _ed_EmployeeCode = value; }
		}

		/// public propaty name  :  St_CustomerCode
		/// <summary>開始得意先コードプロパティ</summary>
		/// <value>得意先別・地区別・業種別で使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_CustomerCode
		{
			get { return _st_CustomerCode; }
			set { _st_CustomerCode = value; }
		}

		/// public propaty name  :  Ed_CustomerCode
		/// <summary>終了得意先コードプロパティ</summary>
		/// <value>得意先別・地区別・業種別で使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_CustomerCode
		{
			get { return _ed_CustomerCode; }
			set { _ed_CustomerCode = value; }
		}

		/// public propaty name  :  St_SalesAreaCode
		/// <summary>開始販売エリアコードプロパティ</summary>
		/// <value>地区別で使用</value>
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

		/// public propaty name  :  Ed_SalesAreaCode
		/// <summary>終了販売エリアコードプロパティ</summary>
		/// <value>地区別で使用</value>
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

		/// public propaty name  :  St_BusinessTypeCode
		/// <summary>開始業種コードプロパティ</summary>
		/// <value>業種別で使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始業種コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_BusinessTypeCode
		{
			get { return _st_BusinessTypeCode; }
			set { _st_BusinessTypeCode = value; }
		}

		/// public propaty name  :  Ed_BusinessTypeCode
		/// <summary>終了業種コードプロパティ</summary>
		/// <value>業種別で使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了業種コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_BusinessTypeCode
		{
			get { return _ed_BusinessTypeCode; }
			set { _ed_BusinessTypeCode = value; }
		}

		/// public propaty name  :  EnterpriseName
		/// <summary>企業名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   企業名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterpriseName
		{
			get { return _enterpriseName; }
			set { _enterpriseName = value; }
		}

		/// public propaty name  :  SortOrder
		/// <summary>出力順プロパティ</summary>
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

		/// public propaty name  :  PrintType
		/// <summary>印刷タイププロパティ</summary>
		/// <value>0:売上 1:粗利 2:売上＆粗利</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印刷タイププロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrintType
		{
			get { return _printType; }
			set { _printType = value; }
		}

		/// public propaty name  :  NewPage
		/// <summary>改頁プロパティ</summary>
		/// <value>True:する False:しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   改頁プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Boolean NewPage
		{
			get { return _newPage; }
			set { _newPage = value; }
		}

        /// public propaty name  :  NewPage2
        /// <summary>改頁2プロパティ</summary>
        /// <value>True:する False:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改頁プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Boolean NewPage2
        {
            get { return _newPage2; }
            set { _newPage2 = value; }
        }
        
        /// public propaty name  :  IssueType
		/// <summary>発行タイププロパティ</summary>
        /// <value>
        /// 得意先別： 0:得意先別 1:拠点別 2:得意先別拠点別 3:管理拠点別 4:請求先別 
        /// 担当者別： 0:担当者別 1:得意先別 2:担当者別拠点別 3:管理拠点別
        /// 受注者別： 0:受注者別 1:得意先別 2:受注者別拠点別 3:管理拠点別
        /// 地区別：   0:地区別 1:得意先別 2:地区別拠点別 3:管理拠点別
        /// 業種別：　 0:業種別 1:得意先別 2:業種別拠点別 3:管理拠点別
        /// グループコード別： 0:グループコード別 1:商品中分類別 2:商品大分類別
        /// BLコード別 0:BLコード別 1:BLコード得意先別 2:BLコート担当者別
        /// </value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印刷タイププロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32 IssueType
		{
            get { return _issueType; }
            set { _issueType = value; }
		}

        /// public propaty name  :  St_BLGoodsCode
        /// <summary>BLコード開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_BLGoodsCode
        {
            get { return _st_BLGoodsCode; }
            set { _st_BLGoodsCode = value; }
        }

        /// public propaty name  :  Ed_BLGoodsCode
        /// <summary>BLコード終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_BLGoodsCode
        {
            get { return _ed_BLGoodsCode; }
            set { _ed_BLGoodsCode = value; }
        }

        /// public propaty name  :  St_GoodsLGroup
        /// <summary>商品大分類コード開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品大分類コード開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_GoodsLGroup
        {
            get { return _st_GoodsLGroup; }
            set { _st_GoodsLGroup = value; }
        }

        /// public propaty name  :  Ed_GoodsLGroup
        /// <summary>商品大分類コード終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品大分類コード終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_GoodsLGroup
        {
            get { return _ed_GoodsLGroup; }
            set { _ed_GoodsLGroup = value; }
        }

        /// public propaty name  :  St_GoodsMGroup
        /// <summary>商品中分類コード開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コード開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_GoodsMGroup
        {
            get { return _st_GoodsMGroup; }
            set { _st_GoodsMGroup = value; }
        }

        /// public propaty name  :  Ed_GoodsMGroup
        /// <summary>商品中分類コード終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コード終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_GoodsMGroup
        {
            get { return _ed_GoodsMGroup; }
            set { _ed_GoodsMGroup = value; }
        }

        /// public propaty name  :  St_BLGroupCode
        /// <summary>グループコード開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   グループコード開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_BLGroupCode
        {
            get { return _st_BLGroupCode; }
            set { _st_BLGroupCode = value; }
        }

        /// public propaty name  :  Ed_BLGroupCode
        /// <summary>グループコード終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   グループコード終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_BLGroupCode
        {
            get { return _ed_BLGroupCode; }
            set { _ed_BLGroupCode = value; }
        }

        /// public propaty name  :  St_MonthSalesRatio_ck
        /// <summary>前年比(開始当月純売上)プロパティ</summary>
        /// <value>%指定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前年比(開始当月純売上)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Boolean St_MonthSalesRatio_ck
        {
            get { return _st_MonthSalesRatio_ck; }
            set { _st_MonthSalesRatio_ck = value; }
        }

        /// public propaty name  :  Ed_MonthSalesRatio_ck
        /// <summary>前年比(終了当月純売上)プロパティ</summary>
        /// <value>%指定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前年比(終了当月純売上)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Boolean Ed_MonthSalesRatio_ck
        {
            get { return _ed_MonthSalesRatio_ck; }
            set { _ed_MonthSalesRatio_ck = value; }
        }

        /// public propaty name  :  St_YearSalesRatio_ck
        /// <summary>前年比(開始当年純売上)プロパティ</summary>
        /// <value>%指定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前年比(開始当年純売上)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Boolean St_YearSalesRatio_ck
        {
            get { return _st_YearSalesRatio_ck; }
            set { _st_YearSalesRatio_ck = value; }
        }

        /// public propaty name  :  Ed_YearSalesRatio_ck
        /// <summary>前年比(終了当年純売上)プロパティ</summary>
        /// <value>%指定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前年比(終了当年純売上)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Boolean Ed_YearSalesRatio_ck
        {
            get { return _ed_YearSalesRatio_ck; }
            set { _ed_YearSalesRatio_ck = value; }
        }

        /// public propaty name  :  St_MonthGrossRatio_ck
        /// <summary>前年比(開始当月粗利)プロパティ</summary>
        /// <value>%指定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前年比(開始当月粗利)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Boolean St_MonthGrossRatio_ck
        {
            get { return _st_MonthGrossRatio_ck; }
            set { _st_MonthGrossRatio_ck = value; }
        }

        /// public propaty name  :  Ed_MonthGrossRatio_ck
        /// <summary>前年比(終了当月粗利)プロパティ</summary>
        /// <value>%指定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前年比(終了当月粗利)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Boolean Ed_MonthGrossRatio_ck
        {
            get { return _ed_MonthGrossRatio_ck; }
            set { _ed_MonthGrossRatio_ck = value; }
        }

        /// public propaty name  :  St_YearGrossRatio_ck
        /// <summary>前年比(開始当年粗利)プロパティ</summary>
        /// <value>%指定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前年比(開始当年粗利)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Boolean St_YearGrossRatio_ck
        {
            get { return _st_YearGrossRatio_ck; }
            set { _st_YearGrossRatio_ck = value; }
        }

        /// public propaty name  :  Ed_YearGrossRatio_ck
        /// <summary>前年比(終了当年粗利)プロパティ</summary>
        /// <value>%指定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前年比(終了当年粗利)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Boolean Ed_YearGrossRatio_ck
        {
            get { return _ed_YearGrossRatio_ck; }
            set { _ed_YearGrossRatio_ck = value; }
        }

		/// <summary>
		/// 前年対比表抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>ExtrInfo_DCTOK02093Eクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DCTOK02093Eクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_DCTOK02093E()
		{
		}

		/// <summary>
		/// 前年対比表抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="secCodeList">出力対象拠点(nullの場合は全拠点)</param>
		/// <param name="totalWay">集計方法(True:全社集計 False:拠点別集計)</param>
		/// <param name="listType">帳票タイプ(0:拠点別 1:得意先別 2:担当者別 3:地区別 4:業種別 5:部署別(部署管理設定依存))</param>
		/// <param name="moneyUnit">金額単位(True:円 False:千円)</param>
		/// <param name="st_AddUpYearMonth">開始対象年月(YYYYMM)</param>
		/// <param name="ed_AddUpYearMonth">終了対象年月(YYYYMM)</param>
		/// <param name="st_MonthSalesRatio">前年比(開始当月純売上)(%指定)</param>
		/// <param name="ed_MonthSalesRatio">前年比(終了当月純売上)(%指定)</param>
		/// <param name="st_YearSalesRatio">前年比(開始当年純売上)(%指定)</param>
		/// <param name="ed_YearSalesRatio">前年比(終了当年純売上)(%指定)</param>
		/// <param name="st_MonthGrossRatio">前年比(開始当月粗利)(%指定)</param>
		/// <param name="ed_MonthGrossRatio">前年比(終了当月粗利)(%指定)</param>
		/// <param name="st_YearGrossRatio">前年比(開始当年粗利)(%指定)</param>
		/// <param name="ed_YearGrossRatio">前年比(終了当年粗利)(%指定)</param>		
		/// <param name="st_EmployeeCode">開始従業員コード(担当者別で使用)</param>
		/// <param name="ed_EmployeeCode">終了従業員コード(担当者別で使用)</param>
		/// <param name="st_CustomerCode">開始得意先コード(得意先別・地区別・業種別で使用)</param>
		/// <param name="ed_CustomerCode">終了得意先コード(得意先別・地区別・業種別で使用)</param>
		/// <param name="st_SalesAreaCode">開始販売エリアコード(地区別で使用)</param>
		/// <param name="ed_SalesAreaCode">終了販売エリアコード(地区別で使用)</param>
		/// <param name="st_BusinessTypeCode">開始業種コード(業種別で使用)</param>
		/// <param name="ed_BusinessTypeCode">終了業種コード(業種別で使用)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="sortOrder">出力順</param>
		/// <param name="printType">印刷タイプ(0:売上 1:粗利 2:売上＆粗利)</param>
		/// <param name="newPage">改頁(True:する False:しない)</param>
        /// <param name="newPage2">改頁2(True:する False:しない)</param>
        /// <param name="IssueType">発行タイプ</param>
        /// <param name="St_BLGoodsCode">開始BLコード</param>
        /// <param name="Ed_BLGoodsCode">終了BLコード</param>
        /// <param name="St_GoodsLGroup">開始商品大分類</param>
        /// <param name="Ed_GoodsLGroup">終了商品大分類</param>
        /// <param name="St_GoodsMGroup">開始商品中分類</param>
        /// <param name="Ed_GoodsMGroup">終了商品中分類</param>
        /// <param name="St_BLGroupCode">開始グループコード</param>
        /// <param name="Ed_BLGroupCode">終了グループコード</param>
        /// <param name="st_MonthSalesRatio_ck">前年比(開始当月純売上)(入力判定)</param>
        /// <param name="ed_MonthSalesRatio_ck">前年比(終了当月純売上)(入力判定)</param>
        /// <param name="st_YearSalesRatio_ck">前年比(開始当年純売上)(入力判定)</param>
        /// <param name="ed_YearSalesRatio_ck">前年比(終了当年純売上)(入力判定)</param>
        /// <param name="st_MonthGrossRatio_ck">前年比(開始当月粗利)(入力判定)</param>
        /// <param name="ed_MonthGrossRatio_ck">前年比(終了当月粗利)(入力判定)</param>
        /// <param name="st_YearGrossRatio_ck">前年比(開始当年粗利)(入力判定)</param>
        /// <param name="ed_YearGrossRatio_ck">前年比(終了当年粗利)(入力判定)</param>		
		/// <returns>ExtrInfo_DCTOK02093Eクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DCTOK02093Eクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public ExtrInfo_DCTOK02093E(string enterpriseCode, String[] secCodeList, Int32 totalWay, Int32 listType, Int32 moneyUnit, Int32 st_AddUpYearMonth, Int32 ed_AddUpYearMonth, Double st_MonthSalesRatio, Double ed_MonthSalesRatio, Double st_YearSalesRatio, Double ed_YearSalesRatio, Double st_MonthGrossRatio, Double ed_MonthGrossRatio, Double st_YearGrossRatio, Double ed_YearGrossRatio, string st_EmployeeCode, string ed_EmployeeCode, Int32 st_CustomerCode, Int32 ed_CustomerCode, Int32 st_SalesAreaCode, Int32 ed_SalesAreaCode, Int32 st_BusinessTypeCode, Int32 ed_BusinessTypeCode, string enterpriseName, Int32 sortOrder, Int32 printType, Boolean newPage, Boolean newPage2, Int32 IssueType, Int32 St_BLGoodsCode, Int32 Ed_BLGoodsCode, Int32 St_GoodsLGroup, Int32 Ed_GoodsLGroup, Int32 St_GoodsMGroup, Int32 Ed_GoodsMGroup, Int32 St_BLGroupCode, Int32 Ed_BLGroupCode,Boolean st_MonthSalesRatio_ck, Boolean ed_MonthSalesRatio_ck, Boolean st_YearSalesRatio_ck, Boolean ed_YearSalesRatio_ck, Boolean st_MonthGrossRatio_ck, Boolean ed_MonthGrossRatio_ck, Boolean st_YearGrossRatio_ck, Boolean ed_YearGrossRatio_ck)
		{
			this._enterpriseCode = enterpriseCode;
			this._secCodeList = secCodeList;
			this._totalWay = totalWay;
			this._listType = listType;
			this._moneyUnit = moneyUnit;
			this._st_AddUpYearMonth = st_AddUpYearMonth;
			this._ed_AddUpYearMonth = ed_AddUpYearMonth;
			this._st_MonthSalesRatio = st_MonthSalesRatio;
			this._ed_MonthSalesRatio = ed_MonthSalesRatio;
			this._st_YearSalesRatio = st_YearSalesRatio;
			this._ed_YearSalesRatio = ed_YearSalesRatio;
			this._st_MonthGrossRatio = st_MonthGrossRatio;
			this._ed_MonthGrossRatio = ed_MonthGrossRatio;
			this._st_YearGrossRatio = st_YearGrossRatio;
			this._ed_YearGrossRatio = ed_YearGrossRatio;
			this._st_EmployeeCode = st_EmployeeCode;
			this._ed_EmployeeCode = ed_EmployeeCode;
			this._st_CustomerCode = st_CustomerCode;
			this._ed_CustomerCode = ed_CustomerCode;
			this._st_SalesAreaCode = st_SalesAreaCode;
			this._ed_SalesAreaCode = ed_SalesAreaCode;
			this._st_BusinessTypeCode = st_BusinessTypeCode;
			this._ed_BusinessTypeCode = ed_BusinessTypeCode;
			this._enterpriseName = enterpriseName;
			this._sortOrder = sortOrder;
			this._printType = printType;
			this._newPage = newPage;
            this._newPage2 = newPage2;
            this._issueType = IssueType;
            this._st_BLGoodsCode = St_BLGoodsCode;
            this._ed_BLGoodsCode = Ed_BLGoodsCode;
            this._st_GoodsLGroup = St_GoodsLGroup;
            this._ed_GoodsLGroup = Ed_GoodsLGroup;
            this._st_GoodsMGroup = St_GoodsMGroup;
            this._ed_GoodsMGroup = Ed_GoodsMGroup;
            this._st_BLGroupCode = St_BLGroupCode;
            this._ed_BLGroupCode = Ed_BLGroupCode;
            this._st_MonthSalesRatio_ck = st_MonthSalesRatio_ck;
            this._ed_MonthSalesRatio_ck = ed_MonthSalesRatio_ck;
            this._st_YearSalesRatio_ck = st_YearSalesRatio_ck;
            this._ed_YearSalesRatio_ck = ed_YearSalesRatio_ck;
            this._st_MonthGrossRatio_ck = st_MonthGrossRatio_ck;
            this._ed_MonthGrossRatio_ck = ed_MonthGrossRatio_ck;
            this._st_YearGrossRatio_ck = st_YearGrossRatio_ck;
            this._ed_YearGrossRatio_ck = ed_YearGrossRatio_ck;

		}

		/// <summary>
		/// 前年対比表抽出条件クラス複製処理
		/// </summary>
		/// <returns>ExtrInfo_DCTOK02093Eクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいExtrInfo_DCTOK02093Eクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public ExtrInfo_DCTOK02093E Clone()
        {
            return new ExtrInfo_DCTOK02093E(this._enterpriseCode, this._secCodeList, this._totalWay, this._listType, this._moneyUnit, this._st_AddUpYearMonth, this._ed_AddUpYearMonth, this._st_MonthSalesRatio, this._ed_MonthSalesRatio, this._st_YearSalesRatio, this._ed_YearSalesRatio, this._st_MonthGrossRatio, this._ed_MonthGrossRatio, this._st_YearGrossRatio, this._ed_YearGrossRatio, this._st_EmployeeCode, this._ed_EmployeeCode, this._st_CustomerCode, this._ed_CustomerCode, this._st_SalesAreaCode, this._ed_SalesAreaCode, this._st_BusinessTypeCode, this._ed_BusinessTypeCode, this._enterpriseName, this._sortOrder, this._printType, this._newPage, this._newPage2, this._issueType, this._st_BLGoodsCode, this._ed_BLGoodsCode, this._st_GoodsLGroup, this._ed_GoodsLGroup, this._st_GoodsMGroup, this._ed_GoodsMGroup, this._st_BLGroupCode, this._ed_BLGroupCode, this._st_MonthSalesRatio_ck, this._ed_MonthSalesRatio_ck, this._st_YearSalesRatio_ck, this._ed_YearSalesRatio_ck, this._st_MonthGrossRatio_ck, this._ed_MonthGrossRatio_ck, this._st_YearGrossRatio_ck, this._ed_YearGrossRatio_ck);

        }

		/// <summary>
		/// 前年対比表抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のExtrInfo_DCTOK02093Eクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DCTOK02093Eクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public bool Equals(ExtrInfo_DCTOK02093E target)
        {
            return (
                (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SecCodeList == target.SecCodeList)
                 && (this.TotalWay == target.TotalWay)
                 && (this.ListType == target.ListType)
                 && (this.MoneyUnit == target.MoneyUnit)
                 && (this.St_AddUpYearMonth == target.St_AddUpYearMonth)
                 && (this.Ed_AddUpYearMonth == target.Ed_AddUpYearMonth)
                 && (this.St_MonthSalesRatio == target.St_MonthSalesRatio)
                 && (this.Ed_MonthSalesRatio == target.Ed_MonthSalesRatio)
                 && (this.St_YearSalesRatio == target.St_YearSalesRatio)
                 && (this.Ed_YearSalesRatio == target.Ed_YearSalesRatio)
                 && (this.St_MonthGrossRatio == target.St_MonthGrossRatio)
                 && (this.Ed_MonthGrossRatio == target.Ed_MonthGrossRatio)
                 && (this.St_YearGrossRatio == target.St_YearGrossRatio)
                 && (this.Ed_YearGrossRatio == target.Ed_YearGrossRatio)
                 && (this.St_EmployeeCode == target.St_EmployeeCode)
                 && (this.Ed_EmployeeCode == target.Ed_EmployeeCode)
                 && (this.St_CustomerCode == target.St_CustomerCode)
                 && (this.Ed_CustomerCode == target.Ed_CustomerCode)
                 && (this.St_SalesAreaCode == target.St_SalesAreaCode)
                 && (this.Ed_SalesAreaCode == target.Ed_SalesAreaCode)
                 && (this.St_BusinessTypeCode == target.St_BusinessTypeCode)
                 && (this.Ed_BusinessTypeCode == target.Ed_BusinessTypeCode)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.SortOrder == target.SortOrder)
                 && (this.PrintType == target.PrintType)
                 && (this.NewPage == target.NewPage)
                 && (this.NewPage2 == target.NewPage2)
                 && (this.IssueType == target.IssueType)
                 && (this.St_BLGoodsCode == target.St_BLGoodsCode)
                 && (this.Ed_BLGoodsCode == target.Ed_BLGoodsCode)
                 && (this.St_GoodsLGroup == target.St_GoodsLGroup)
                 && (this.Ed_GoodsLGroup == target.Ed_GoodsLGroup)
                 && (this.St_GoodsMGroup == target.St_GoodsMGroup)
                 && (this.Ed_GoodsMGroup == target.Ed_GoodsMGroup)
                 && (this.St_BLGroupCode == target.St_BLGroupCode)
                 && (this.Ed_BLGroupCode == target.Ed_BLGroupCode)
                 && (this.St_MonthSalesRatio_ck == target.St_MonthSalesRatio_ck)
                 && (this.Ed_MonthSalesRatio_ck == target.Ed_MonthSalesRatio_ck)
                 && (this.St_YearSalesRatio_ck == target.St_YearSalesRatio_ck)
                 && (this.Ed_YearSalesRatio_ck == target.Ed_YearSalesRatio_ck)
                 && (this.St_MonthGrossRatio_ck == target.St_MonthGrossRatio_ck)
                 && (this.Ed_MonthGrossRatio_ck == target.Ed_MonthGrossRatio_ck)
                 && (this.St_YearGrossRatio_ck == target.St_YearGrossRatio_ck)
                 && (this.Ed_YearGrossRatio_ck == target.Ed_YearGrossRatio_ck)
                 );
        }

		/// <summary>
		/// 前年対比表抽出条件クラス比較処理
		/// </summary>
		/// <param name="extrInfo_DCTOK02093E1">
		///                    比較するExtrInfo_DCTOK02093Eクラスのインスタンス
		/// </param>
		/// <param name="extrInfo_DCTOK02093E2">比較するExtrInfo_DCTOK02093Eクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DCTOK02093Eクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public static bool Equals(ExtrInfo_DCTOK02093E extrInfo_DCTOK02093E1, ExtrInfo_DCTOK02093E extrInfo_DCTOK02093E2)
        {
            return (
                (extrInfo_DCTOK02093E1.EnterpriseCode == extrInfo_DCTOK02093E2.EnterpriseCode)
                 && (extrInfo_DCTOK02093E1.SecCodeList == extrInfo_DCTOK02093E2.SecCodeList)
                 && (extrInfo_DCTOK02093E1.TotalWay == extrInfo_DCTOK02093E2.TotalWay)
                 && (extrInfo_DCTOK02093E1.ListType == extrInfo_DCTOK02093E2.ListType)
                 && (extrInfo_DCTOK02093E1.MoneyUnit == extrInfo_DCTOK02093E2.MoneyUnit)
                 && (extrInfo_DCTOK02093E1.St_AddUpYearMonth == extrInfo_DCTOK02093E2.St_AddUpYearMonth)
                 && (extrInfo_DCTOK02093E1.Ed_AddUpYearMonth == extrInfo_DCTOK02093E2.Ed_AddUpYearMonth)
                 && (extrInfo_DCTOK02093E1.St_MonthSalesRatio == extrInfo_DCTOK02093E2.St_MonthSalesRatio)
                 && (extrInfo_DCTOK02093E1.Ed_MonthSalesRatio == extrInfo_DCTOK02093E2.Ed_MonthSalesRatio)
                 && (extrInfo_DCTOK02093E1.St_YearSalesRatio == extrInfo_DCTOK02093E2.St_YearSalesRatio)
                 && (extrInfo_DCTOK02093E1.Ed_YearSalesRatio == extrInfo_DCTOK02093E2.Ed_YearSalesRatio)
                 && (extrInfo_DCTOK02093E1.St_MonthGrossRatio == extrInfo_DCTOK02093E2.St_MonthGrossRatio)
                 && (extrInfo_DCTOK02093E1.Ed_MonthGrossRatio == extrInfo_DCTOK02093E2.Ed_MonthGrossRatio)
                 && (extrInfo_DCTOK02093E1.St_YearGrossRatio == extrInfo_DCTOK02093E2.St_YearGrossRatio)
                 && (extrInfo_DCTOK02093E1.Ed_YearGrossRatio == extrInfo_DCTOK02093E2.Ed_YearGrossRatio)
                 && (extrInfo_DCTOK02093E1.St_EmployeeCode == extrInfo_DCTOK02093E2.St_EmployeeCode)
                 && (extrInfo_DCTOK02093E1.Ed_EmployeeCode == extrInfo_DCTOK02093E2.Ed_EmployeeCode)
                 && (extrInfo_DCTOK02093E1.St_CustomerCode == extrInfo_DCTOK02093E2.St_CustomerCode)
                 && (extrInfo_DCTOK02093E1.Ed_CustomerCode == extrInfo_DCTOK02093E2.Ed_CustomerCode)
                 && (extrInfo_DCTOK02093E1.St_SalesAreaCode == extrInfo_DCTOK02093E2.St_SalesAreaCode)
                 && (extrInfo_DCTOK02093E1.Ed_SalesAreaCode == extrInfo_DCTOK02093E2.Ed_SalesAreaCode)
                 && (extrInfo_DCTOK02093E1.St_BusinessTypeCode == extrInfo_DCTOK02093E2.St_BusinessTypeCode)
                 && (extrInfo_DCTOK02093E1.Ed_BusinessTypeCode == extrInfo_DCTOK02093E2.Ed_BusinessTypeCode)
                 && (extrInfo_DCTOK02093E1.EnterpriseName == extrInfo_DCTOK02093E2.EnterpriseName)
                 && (extrInfo_DCTOK02093E1.SortOrder == extrInfo_DCTOK02093E2.SortOrder)
                 && (extrInfo_DCTOK02093E1.PrintType == extrInfo_DCTOK02093E2.PrintType)
                 && (extrInfo_DCTOK02093E1.NewPage == extrInfo_DCTOK02093E2.NewPage)
                 && (extrInfo_DCTOK02093E1.NewPage2 == extrInfo_DCTOK02093E2.NewPage2)
                 && (extrInfo_DCTOK02093E1.IssueType == extrInfo_DCTOK02093E2.IssueType)
                 && (extrInfo_DCTOK02093E1.St_BLGoodsCode == extrInfo_DCTOK02093E2.St_BLGoodsCode)
                 && (extrInfo_DCTOK02093E1.Ed_BLGoodsCode == extrInfo_DCTOK02093E2.Ed_BLGoodsCode)
                 && (extrInfo_DCTOK02093E1.St_GoodsLGroup == extrInfo_DCTOK02093E2.St_GoodsLGroup)
                 && (extrInfo_DCTOK02093E1.Ed_GoodsLGroup == extrInfo_DCTOK02093E2.Ed_GoodsLGroup)
                 && (extrInfo_DCTOK02093E1.St_GoodsMGroup == extrInfo_DCTOK02093E2.St_GoodsMGroup)
                 && (extrInfo_DCTOK02093E1.Ed_GoodsMGroup == extrInfo_DCTOK02093E2.Ed_GoodsMGroup)
                 && (extrInfo_DCTOK02093E1.St_BLGroupCode == extrInfo_DCTOK02093E2.St_BLGroupCode)
                 && (extrInfo_DCTOK02093E1.Ed_BLGroupCode == extrInfo_DCTOK02093E2.Ed_BLGroupCode)
                 && (extrInfo_DCTOK02093E1.St_MonthSalesRatio_ck == extrInfo_DCTOK02093E2.St_MonthSalesRatio_ck)
                 && (extrInfo_DCTOK02093E1.Ed_MonthSalesRatio_ck == extrInfo_DCTOK02093E2.Ed_MonthSalesRatio_ck)
                 && (extrInfo_DCTOK02093E1.St_YearSalesRatio_ck == extrInfo_DCTOK02093E2.St_YearSalesRatio_ck)
                 && (extrInfo_DCTOK02093E1.Ed_YearSalesRatio_ck == extrInfo_DCTOK02093E2.Ed_YearSalesRatio_ck)
                 && (extrInfo_DCTOK02093E1.St_MonthGrossRatio_ck == extrInfo_DCTOK02093E2.St_MonthGrossRatio_ck)
                 && (extrInfo_DCTOK02093E1.Ed_MonthGrossRatio_ck == extrInfo_DCTOK02093E2.Ed_MonthGrossRatio_ck)
                 && (extrInfo_DCTOK02093E1.St_YearGrossRatio_ck == extrInfo_DCTOK02093E2.St_YearGrossRatio_ck)
                 && (extrInfo_DCTOK02093E1.Ed_YearGrossRatio_ck == extrInfo_DCTOK02093E2.Ed_YearGrossRatio_ck)
                 );
        }
		/// <summary>
		/// 前年対比表抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のExtrInfo_DCTOK02093Eクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DCTOK02093Eクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public ArrayList Compare(ExtrInfo_DCTOK02093E target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SecCodeList != target.SecCodeList) resList.Add("SecCodeList");
            if (this.TotalWay != target.TotalWay) resList.Add("TotalWay");
            if (this.ListType != target.ListType) resList.Add("ListType");
            if (this.MoneyUnit != target.MoneyUnit) resList.Add("MoneyUnit");
            if (this.St_AddUpYearMonth != target.St_AddUpYearMonth) resList.Add("St_AddUpYearMonth");
            if (this.Ed_AddUpYearMonth != target.Ed_AddUpYearMonth) resList.Add("Ed_AddUpYearMonth");
            if (this.St_MonthSalesRatio != target.St_MonthSalesRatio) resList.Add("St_MonthSalesRatio");
            if (this.Ed_MonthSalesRatio != target.Ed_MonthSalesRatio) resList.Add("Ed_MonthSalesRatio");
            if (this.St_YearSalesRatio != target.St_YearSalesRatio) resList.Add("St_YearSalesRatio");
            if (this.Ed_YearSalesRatio != target.Ed_YearSalesRatio) resList.Add("Ed_YearSalesRatio");
            if (this.St_MonthGrossRatio != target.St_MonthGrossRatio) resList.Add("St_MonthGrossRatio");
            if (this.Ed_MonthGrossRatio != target.Ed_MonthGrossRatio) resList.Add("Ed_MonthGrossRatio");
            if (this.St_YearGrossRatio != target.St_YearGrossRatio) resList.Add("St_YearGrossRatio");
            if (this.Ed_YearGrossRatio != target.Ed_YearGrossRatio) resList.Add("Ed_YearGrossRatio");
            if (this.St_EmployeeCode != target.St_EmployeeCode) resList.Add("St_EmployeeCode");
            if (this.Ed_EmployeeCode != target.Ed_EmployeeCode) resList.Add("Ed_EmployeeCode");
            if (this.St_CustomerCode != target.St_CustomerCode) resList.Add("St_CustomerCode");
            if (this.Ed_CustomerCode != target.Ed_CustomerCode) resList.Add("Ed_CustomerCode");
            if (this.St_SalesAreaCode != target.St_SalesAreaCode) resList.Add("St_SalesAreaCode");
            if (this.Ed_SalesAreaCode != target.Ed_SalesAreaCode) resList.Add("Ed_SalesAreaCode");
            if (this.St_BusinessTypeCode != target.St_BusinessTypeCode) resList.Add("St_BusinessTypeCode");
            if (this.Ed_BusinessTypeCode != target.Ed_BusinessTypeCode) resList.Add("Ed_BusinessTypeCode");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.SortOrder != target.SortOrder) resList.Add("SortOrder");
            if (this.PrintType != target.PrintType) resList.Add("PrintType");
            if (this.NewPage != target.NewPage) resList.Add("NewPage");
            if (this.NewPage2 != target.NewPage2) resList.Add("NewPage2");
            if (this.IssueType != target.IssueType) resList.Add("IssueType");
            if (this.St_BLGoodsCode != target.St_BLGoodsCode) resList.Add("St_BLGoodsCode");
            if (this.Ed_BLGoodsCode != target.Ed_BLGoodsCode) resList.Add("Ed_BLGoodsCode");
            if (this.St_GoodsLGroup != target.St_GoodsLGroup) resList.Add("St_GoodsLGroup");
            if (this.Ed_GoodsLGroup != target.Ed_GoodsLGroup) resList.Add("Ed_GoodsLGroup");
            if (this.St_GoodsMGroup != target.St_GoodsMGroup) resList.Add("St_GoodsMGroup");
            if (this.Ed_GoodsMGroup != target.Ed_GoodsMGroup) resList.Add("Ed_GoodsMGroup");
            if (this.St_BLGroupCode != target.St_BLGroupCode) resList.Add("St_BLGroupCode");
            if (this.Ed_BLGroupCode != target.Ed_BLGroupCode) resList.Add("Ed_BLGroupCode");
            if (this.St_MonthSalesRatio_ck != target.St_MonthSalesRatio_ck) resList.Add("St_MonthSalesRatio_ck");
            if (this.Ed_MonthSalesRatio_ck != target.Ed_MonthSalesRatio_ck) resList.Add("Ed_MonthSalesRatio_ck");
            if (this.St_YearSalesRatio_ck != target.St_YearSalesRatio_ck) resList.Add("St_YearSalesRatio_ck");
            if (this.Ed_YearSalesRatio_ck != target.Ed_YearSalesRatio_ck) resList.Add("Ed_YearSalesRatio_ck");
            if (this.St_MonthGrossRatio_ck != target.St_MonthGrossRatio_ck) resList.Add("St_MonthGrossRatio_ck");
            if (this.Ed_MonthGrossRatio_ck != target.Ed_MonthGrossRatio_ck) resList.Add("Ed_MonthGrossRatio_ck");
            if (this.St_YearGrossRatio_ck != target.St_YearGrossRatio_ck) resList.Add("St_YearGrossRatio_ck");
            if (this.Ed_YearGrossRatio_ck != target.Ed_YearGrossRatio_ck) resList.Add("Ed_YearGrossRatio_ck");
            return resList;
        }

		/// <summary>
		/// 前年対比表抽出条件クラス比較処理
		/// </summary>
		/// <param name="extrInfo_DCTOK02093E1">比較するExtrInfo_DCTOK02093Eクラスのインスタンス</param>
		/// <param name="extrInfo_DCTOK02093E2">比較するExtrInfo_DCTOK02093Eクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ExtrInfo_DCTOK02093Eクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public static ArrayList Compare(ExtrInfo_DCTOK02093E extrInfo_DCTOK02093E1, ExtrInfo_DCTOK02093E extrInfo_DCTOK02093E2)
        {
            ArrayList resList = new ArrayList();
            if (extrInfo_DCTOK02093E1.EnterpriseCode != extrInfo_DCTOK02093E2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (extrInfo_DCTOK02093E1.SecCodeList != extrInfo_DCTOK02093E2.SecCodeList) resList.Add("SecCodeList");
            if (extrInfo_DCTOK02093E1.TotalWay != extrInfo_DCTOK02093E2.TotalWay) resList.Add("TotalWay");
            if (extrInfo_DCTOK02093E1.ListType != extrInfo_DCTOK02093E2.ListType) resList.Add("ListType");
            if (extrInfo_DCTOK02093E1.MoneyUnit != extrInfo_DCTOK02093E2.MoneyUnit) resList.Add("MoneyUnit");
            if (extrInfo_DCTOK02093E1.St_AddUpYearMonth != extrInfo_DCTOK02093E2.St_AddUpYearMonth) resList.Add("St_AddUpYearMonth");
            if (extrInfo_DCTOK02093E1.Ed_AddUpYearMonth != extrInfo_DCTOK02093E2.Ed_AddUpYearMonth) resList.Add("Ed_AddUpYearMonth");
            if (extrInfo_DCTOK02093E1.St_MonthSalesRatio != extrInfo_DCTOK02093E2.St_MonthSalesRatio) resList.Add("St_MonthSalesRatio");
            if (extrInfo_DCTOK02093E1.Ed_MonthSalesRatio != extrInfo_DCTOK02093E2.Ed_MonthSalesRatio) resList.Add("Ed_MonthSalesRatio");
            if (extrInfo_DCTOK02093E1.St_YearSalesRatio != extrInfo_DCTOK02093E2.St_YearSalesRatio) resList.Add("St_YearSalesRatio");
            if (extrInfo_DCTOK02093E1.Ed_YearSalesRatio != extrInfo_DCTOK02093E2.Ed_YearSalesRatio) resList.Add("Ed_YearSalesRatio");
            if (extrInfo_DCTOK02093E1.St_MonthGrossRatio != extrInfo_DCTOK02093E2.St_MonthGrossRatio) resList.Add("St_MonthGrossRatio");
            if (extrInfo_DCTOK02093E1.Ed_MonthGrossRatio != extrInfo_DCTOK02093E2.Ed_MonthGrossRatio) resList.Add("Ed_MonthGrossRatio");
            if (extrInfo_DCTOK02093E1.St_YearGrossRatio != extrInfo_DCTOK02093E2.St_YearGrossRatio) resList.Add("St_YearGrossRatio");
            if (extrInfo_DCTOK02093E1.Ed_YearGrossRatio != extrInfo_DCTOK02093E2.Ed_YearGrossRatio) resList.Add("Ed_YearGrossRatio");
            if (extrInfo_DCTOK02093E1.St_EmployeeCode != extrInfo_DCTOK02093E2.St_EmployeeCode) resList.Add("St_EmployeeCode");
            if (extrInfo_DCTOK02093E1.Ed_EmployeeCode != extrInfo_DCTOK02093E2.Ed_EmployeeCode) resList.Add("Ed_EmployeeCode");
            if (extrInfo_DCTOK02093E1.St_CustomerCode != extrInfo_DCTOK02093E2.St_CustomerCode) resList.Add("St_CustomerCode");
            if (extrInfo_DCTOK02093E1.Ed_CustomerCode != extrInfo_DCTOK02093E2.Ed_CustomerCode) resList.Add("Ed_CustomerCode");
            if (extrInfo_DCTOK02093E1.St_SalesAreaCode != extrInfo_DCTOK02093E2.St_SalesAreaCode) resList.Add("St_SalesAreaCode");
            if (extrInfo_DCTOK02093E1.Ed_SalesAreaCode != extrInfo_DCTOK02093E2.Ed_SalesAreaCode) resList.Add("Ed_SalesAreaCode");
            if (extrInfo_DCTOK02093E1.St_BusinessTypeCode != extrInfo_DCTOK02093E2.St_BusinessTypeCode) resList.Add("St_BusinessTypeCode");
            if (extrInfo_DCTOK02093E1.Ed_BusinessTypeCode != extrInfo_DCTOK02093E2.Ed_BusinessTypeCode) resList.Add("Ed_BusinessTypeCode");
            if (extrInfo_DCTOK02093E1.EnterpriseName != extrInfo_DCTOK02093E2.EnterpriseName) resList.Add("EnterpriseName");
            if (extrInfo_DCTOK02093E1.SortOrder != extrInfo_DCTOK02093E2.SortOrder) resList.Add("SortOrder");
            if (extrInfo_DCTOK02093E1.PrintType != extrInfo_DCTOK02093E2.PrintType) resList.Add("PrintType");
            if (extrInfo_DCTOK02093E1.NewPage != extrInfo_DCTOK02093E2.NewPage) resList.Add("NewPage");
            if (extrInfo_DCTOK02093E1.NewPage2 != extrInfo_DCTOK02093E2.NewPage2) resList.Add("NewPage2");
            if (extrInfo_DCTOK02093E1.IssueType != extrInfo_DCTOK02093E2.IssueType) resList.Add("IssueType");
            if (extrInfo_DCTOK02093E1.St_BLGoodsCode != extrInfo_DCTOK02093E2.St_BLGoodsCode) resList.Add("St_BLGoodsCode");
            if (extrInfo_DCTOK02093E1.Ed_BLGoodsCode != extrInfo_DCTOK02093E2.Ed_BLGoodsCode) resList.Add("Ed_BLGoodsCode");
            if (extrInfo_DCTOK02093E1.St_GoodsLGroup != extrInfo_DCTOK02093E2.St_GoodsLGroup) resList.Add("St_GoodsLGroup");
            if (extrInfo_DCTOK02093E1.Ed_GoodsLGroup != extrInfo_DCTOK02093E2.Ed_GoodsLGroup) resList.Add("Ed_GoodsLGroup");
            if (extrInfo_DCTOK02093E1.St_GoodsMGroup != extrInfo_DCTOK02093E2.St_GoodsMGroup) resList.Add("St_GoodsMGroup");
            if (extrInfo_DCTOK02093E1.Ed_GoodsMGroup != extrInfo_DCTOK02093E2.Ed_GoodsMGroup) resList.Add("Ed_GoodsMGroup");
            if (extrInfo_DCTOK02093E1.St_BLGroupCode != extrInfo_DCTOK02093E2.St_BLGroupCode) resList.Add("St_BLGroupCode");
            if (extrInfo_DCTOK02093E1.Ed_BLGroupCode != extrInfo_DCTOK02093E2.Ed_BLGroupCode) resList.Add("Ed_BLGroupCode");
            if (extrInfo_DCTOK02093E1.St_MonthSalesRatio_ck != extrInfo_DCTOK02093E2.St_MonthSalesRatio_ck) resList.Add("St_MonthSalesRatio_ck");
            if (extrInfo_DCTOK02093E1.Ed_MonthSalesRatio_ck != extrInfo_DCTOK02093E2.Ed_MonthSalesRatio_ck) resList.Add("Ed_MonthSalesRatio_ck");
            if (extrInfo_DCTOK02093E1.St_YearSalesRatio_ck != extrInfo_DCTOK02093E2.St_YearSalesRatio_ck) resList.Add("St_YearSalesRatio_ck");
            if (extrInfo_DCTOK02093E1.Ed_YearSalesRatio_ck != extrInfo_DCTOK02093E2.Ed_YearSalesRatio_ck) resList.Add("Ed_YearSalesRatio_ck");
            if (extrInfo_DCTOK02093E1.St_MonthGrossRatio_ck != extrInfo_DCTOK02093E2.St_MonthGrossRatio_ck) resList.Add("St_MonthGrossRatio_ck");
            if (extrInfo_DCTOK02093E1.Ed_MonthGrossRatio_ck != extrInfo_DCTOK02093E2.Ed_MonthGrossRatio_ck) resList.Add("Ed_MonthGrossRatio_ck");
            if (extrInfo_DCTOK02093E1.St_YearGrossRatio_ck != extrInfo_DCTOK02093E2.St_YearGrossRatio_ck) resList.Add("St_YearGrossRatio_ck");
            if (extrInfo_DCTOK02093E1.Ed_YearGrossRatio_ck != extrInfo_DCTOK02093E2.Ed_YearGrossRatio_ck) resList.Add("Ed_YearGrossRatio_ck");

            return resList;
        }
	}
}

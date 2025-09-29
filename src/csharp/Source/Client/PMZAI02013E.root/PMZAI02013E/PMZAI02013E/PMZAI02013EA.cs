using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   StockNoShipmentListCndtn
	/// <summary>
	///                      在庫月報年報抽出条件クラス
	/// </summary>
	/// <remarks>
    /// <br>note             :   在庫月報年報抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/08/06  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class StockMonthYearReportCndtn
	{
        # region ■ private field ■

		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>開始年月度</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _st_AddUpYearMonth;

		/// <summary>終了年月度</summary>
		/// <remarks>YYYYMM</remarks>
        private DateTime _ed_AddUpYearMonth;

		/// <summary>拠点コード</summary>
		/// <remarks>（配列）</remarks>
		private string[] _sectionCodes = new string[0];

		/// <summary>開始倉庫コード</summary>
		private string _st_WarehouseCode = "";

		/// <summary>終了倉庫コード</summary>
		private string _ed_WarehouseCode = "";

		/// <summary>開始仕入先コード</summary>
        private Int32 _st_SupplierCd;

		/// <summary>終了仕入先コード</summary>
        private Int32 _ed_SupplierCd;

		/// <summary>開始商品メーカーコード</summary>
		private Int32 _st_GoodsMakerCd;

		/// <summary>終了商品メーカーコード</summary>
		private Int32 _ed_GoodsMakerCd;

		/// <summary>開始商品区分グループコード</summary>
		private string _st_LargeGoodsGanreCode = "";

		/// <summary>終了商品区分グループコード</summary>
		private string _ed_LargeGoodsGanreCode = "";

		/// <summary>開始商品区分コード</summary>
		private string _st_MediumGoodsGanreCode = "";

		/// <summary>終了商品区分コード</summary>
		private string _ed_MediumGoodsGanreCode = "";

		/// <summary>開始商品区分詳細コード</summary>
		private string _st_DetailGoodsGanreCode = "";

		/// <summary>終了商品区分詳細コード</summary>
		private string _ed_DetailGoodsGanreCode = "";

		/// <summary>開始商品番号</summary>
		private string _st_GoodsNo = "";

		/// <summary>終了商品番号</summary>
		private string _ed_GoodsNo = "";

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

        /// <summary>部品管理区分１</summary>
        private string[] _partsManagementDivide1;

        /// <summary>部品管理区分２</summary>
        private string[] _partsManagementDivide2;

        # endregion  ■ private field ■

        # region ■ public propaty ■

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
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  St_AddUpYearMonth
		/// <summary>開始年月度プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始年月度プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime St_AddUpYearMonth
		{
			get{return _st_AddUpYearMonth;}
			set{_st_AddUpYearMonth = value;}
		}

		/// public propaty name  :  Ed_AddUpYearMonth
		/// <summary>終了年月度プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了年月度プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime Ed_AddUpYearMonth
		{
			get{return _ed_AddUpYearMonth;}
			set{_ed_AddUpYearMonth = value;}
		}

		/// public propaty name  :  SectionCodes
		/// <summary>拠点コードプロパティ</summary>
		/// <value>（配列）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
		}

		/// public propaty name  :  St_WarehouseCode
		/// <summary>開始倉庫コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_WarehouseCode
		{
			get{return _st_WarehouseCode;}
			set{_st_WarehouseCode = value;}
		}

		/// public propaty name  :  Ed_WarehouseCode
		/// <summary>終了倉庫コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_WarehouseCode
		{
			get{return _ed_WarehouseCode;}
			set{_ed_WarehouseCode = value;}
		}

        /// public propaty name  :  St_SupplierCd
		/// <summary>開始仕入先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32 St_SupplierCd
		{
            get { return _st_SupplierCd; }
            set { _st_SupplierCd = value; }
		}

        /// public propaty name  :  Ed_SupplierCd
		/// <summary>終了仕入先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32 Ed_SupplierCd
		{
            get { return _ed_SupplierCd; }
            set { _ed_SupplierCd = value; }
		}

		/// public propaty name  :  St_GoodsMakerCd
		/// <summary>開始商品メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_GoodsMakerCd
		{
			get{return _st_GoodsMakerCd;}
			set{_st_GoodsMakerCd = value;}
		}

		/// public propaty name  :  Ed_GoodsMakerCd
		/// <summary>終了商品メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_GoodsMakerCd
		{
			get{return _ed_GoodsMakerCd;}
			set{_ed_GoodsMakerCd = value;}
		}

		/// public propaty name  :  St_LargeGoodsGanreCode
		/// <summary>開始商品区分グループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品区分グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_LargeGoodsGanreCode
		{
			get{return _st_LargeGoodsGanreCode;}
			set{_st_LargeGoodsGanreCode = value;}
		}

		/// public propaty name  :  Ed_LargeGoodsGanreCode
		/// <summary>終了商品区分グループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品区分グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_LargeGoodsGanreCode
		{
			get{return _ed_LargeGoodsGanreCode;}
			set{_ed_LargeGoodsGanreCode = value;}
		}

		/// public propaty name  :  St_MediumGoodsGanreCode
		/// <summary>開始商品区分コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品区分コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_MediumGoodsGanreCode
		{
			get{return _st_MediumGoodsGanreCode;}
			set{_st_MediumGoodsGanreCode = value;}
		}

		/// public propaty name  :  Ed_MediumGoodsGanreCode
		/// <summary>終了商品区分コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品区分コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_MediumGoodsGanreCode
		{
			get{return _ed_MediumGoodsGanreCode;}
			set{_ed_MediumGoodsGanreCode = value;}
		}

		/// public propaty name  :  St_DetailGoodsGanreCode
		/// <summary>開始商品区分詳細コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品区分詳細コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_DetailGoodsGanreCode
		{
			get{return _st_DetailGoodsGanreCode;}
			set{_st_DetailGoodsGanreCode = value;}
		}

		/// public propaty name  :  Ed_DetailGoodsGanreCode
		/// <summary>終了商品区分詳細コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品区分詳細コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_DetailGoodsGanreCode
		{
			get{return _ed_DetailGoodsGanreCode;}
			set{_ed_DetailGoodsGanreCode = value;}
		}

		/// public propaty name  :  St_GoodsNo
		/// <summary>開始商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_GoodsNo
		{
			get{return _st_GoodsNo;}
			set{_st_GoodsNo = value;}
		}

		/// public propaty name  :  Ed_GoodsNo
		/// <summary>終了商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_GoodsNo
		{
			get{return _ed_GoodsNo;}
			set{_ed_GoodsNo = value;}
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
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
		}

        //--- ADD 2008/07/16 ---------->>>>>
        /// public propaty name  :  PartsManagementDivide1
        /// <summary>部品管理区分１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品管理区分１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] PartsManagementDivide1
        {
            get { return _partsManagementDivide1; }
            set { _partsManagementDivide1 = value; }
        }

        /// public propaty name  :  PartsManagementDivide1
        /// <summary>部品管理区分２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品管理区分２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] PartsManagementDivide2
        {
            get { return _partsManagementDivide2; }
            set { _partsManagementDivide2 = value; }
        }
        //--- ADD 2008/07/16 ----------<<<<<

        # endregion ■ public propaty ■

        # region ■ private field (自動生成以外) ■
        /// <summary>
        /// 拠点オプション区分
        /// </summary>
        private bool _isOptSection = false;
        /// <summary>
        /// 全拠点選択区分
        /// </summary>
        private bool _isSelectAllSection = false;
        /// <summary>
        /// 発行タイプ
        /// </summary>
        private PrintTypeState _printTypeDiv = PrintTypeState.ThisMonth;
        /// <summary>
        /// 金額単位
        /// </summary>
        private MoneyUnitState _moneyUnit = MoneyUnitState.One;

        /// <summary>
        /// 粗利チェック適正
        /// </summary>
        private double _grsProfitCheckBest  = 0;
        /// <summary>
        /// 粗利チェック下限
        /// </summary>
        private double _grsProfitCheckLower = 0;
        /// <summary>
        /// 粗利チェック上限
        /// </summary>
        private double _grsProfitCheckUpper = 0;

        /// <summary>
        /// 粗利チェック適正記号
        /// </summary>
        private string _grsProfitChkBestSign;
        /// <summary>
        /// 粗利チェック下限記号
        /// </summary>
        private string _grsProfitChkLowSign;
        /// <summary>
        /// 粗利チェック上限記号
        /// </summary>
        private string _grsProfitChkUprSign;
        /// <summary>
        /// 粗利チェック最大記号
        /// </summary>
        private string _grsProfitChkMaxSign;

        /// <summary>
        /// 印刷有無　倉庫計
        /// </summary>
        private SummaryPrintDivState _warehouseSummaryPrintDiv = SummaryPrintDivState.Print;
        /// <summary>
        /// 印刷有無　仕入先計
        /// </summary>
        private SummaryPrintDivState _supplierSummaryPrintDiv = SummaryPrintDivState.Print;
        /// <summary>
        /// 印刷有無　メーカー計
        /// </summary>
        private SummaryPrintDivState _goodsMakerSummaryPrintDiv = SummaryPrintDivState.Print;
        /// <summary>
        /// 印刷有無　商品区分グループ計
        /// </summary>
        private SummaryPrintDivState _largeGoodsGanreSummaryPrintDiv = SummaryPrintDivState.Print;
        /// <summary>
        /// 印刷有無　商品区分計
        /// </summary>
        private SummaryPrintDivState _mediumGoodsGanreSummaryPrintDiv = SummaryPrintDivState.Print;
        /// <summary>
        /// 印刷有無　商品区分詳細計
        /// </summary>
        private SummaryPrintDivState _detailGoodsGanreSummaryPrintDiv = SummaryPrintDivState.Print;
        /// <summary>
        /// 改ページ区分
        /// </summary>
        private NewPageDivState _newPageDiv;
        # endregion ■ private field (自動生成以外) ■

        # region ■ public propaty (自動生成以外) ■
        /// <summary>
        /// 拠点オプション区分プロパティ
        /// </summary>
        public bool IsOptSection
        {
            get { return this._isOptSection; }
            set { this._isOptSection = value; }
        }
        /// <summary>
        /// 全拠点選択区分プロパティ
        /// </summary>
        public bool IsSelectAllSection
        {
            get { return this._isSelectAllSection; }
            set { this._isSelectAllSection = value; }
        }
        /// <summary>
        /// 発行タイプロパティ
        /// </summary>
        public PrintTypeState PrintType
        {
            get { return this._printTypeDiv; }
            set { this._printTypeDiv = value; }
        }
        /// <summary>
        /// 金額単位　プロパティ
        /// </summary>
        public MoneyUnitState MoneyUnit
        {
            get { return this._moneyUnit; }
            set { this._moneyUnit = value; }
        }

        /// <summary>
        /// 粗利チェック適正　プロパティ
        /// </summary>
        public double GrsProfitCheckBest
        {
            get { return this._grsProfitCheckBest; }
            set { this._grsProfitCheckBest = value; }
        }
        /// <summary>
        /// 粗利チェック下限　プロパティ
        /// </summary>
        public double GrsProfitCheckLower
        {
            get { return this._grsProfitCheckLower; }
            set { this._grsProfitCheckLower = value; }
        }
        /// <summary>
        /// 粗利チェック上限　プロパティ
        /// </summary>
        public double GrsProfitCheckUpper
        {
            get { return this._grsProfitCheckUpper; }
            set { this._grsProfitCheckUpper = value; }
        }
        /// <summary>
        /// 粗利チェック適正記号　プロパティ
        /// </summary>
        public string GrsProfitChkBestSign
        {
            get { return this._grsProfitChkBestSign; }
            set { this._grsProfitChkBestSign = value; }
        }
        /// <summary>
        /// 粗利チェック下限記号　プロパティ
        /// </summary>
        public string GrsProfitChkLowSign
        {
            get { return this._grsProfitChkLowSign; }
            set { this._grsProfitChkLowSign = value; }
        }
        /// <summary>
        /// 粗利チェック上限記号　プロパティ
        /// </summary>
        public string GrsProfitChkUprSign
        {
            get { return this._grsProfitChkUprSign; }
            set { this._grsProfitChkUprSign = value; }
        }
        /// <summary>
        /// 粗利チェック最大記号　プロパティ
        /// </summary>
        public string GrsProfitChkMaxSign
        {
            get { return this._grsProfitChkMaxSign; }
            set { this._grsProfitChkMaxSign = value; }
        }

        /// <summary>
        /// 印刷有無　倉庫計
        /// </summary>
        public SummaryPrintDivState WarehouseSummaryPrintDiv
        {
            get { return this._warehouseSummaryPrintDiv; }
            set { this._warehouseSummaryPrintDiv = value; }
        }
        /// <summary>
        /// 印刷有無　仕入先計
        /// </summary>
        public SummaryPrintDivState SupplierSummaryPrintDiv
        {
            get { return this._supplierSummaryPrintDiv; }
            set { this._supplierSummaryPrintDiv = value; }
        }
        /// <summary>
        /// 印刷有無　メーカー計
        /// </summary>
        public SummaryPrintDivState GoodsMakerSummaryPrintDiv
        {
            get { return this._goodsMakerSummaryPrintDiv; }
            set { this._goodsMakerSummaryPrintDiv = value; }
        }
        /// <summary>
        /// 印刷有無　商品区分グループ計
        /// </summary>
        public SummaryPrintDivState LargeGoodsGanreSummaryPrintDiv
        {
            get { return this._largeGoodsGanreSummaryPrintDiv; }
            set { this._largeGoodsGanreSummaryPrintDiv = value; }
        }
        /// <summary>
        /// 印刷有無　商品区分計
        /// </summary>
        public SummaryPrintDivState MediumGoodsGanreSummaryPrintDiv
        {
            get { return this._mediumGoodsGanreSummaryPrintDiv; }
            set { this._mediumGoodsGanreSummaryPrintDiv = value; }
        }
        /// <summary>
        /// 印刷有無　商品区分詳細計
        /// </summary>
        public SummaryPrintDivState DetailGoodsGanreSummaryPrintDiv
        {
            get { return this._detailGoodsGanreSummaryPrintDiv; }
            set { this._detailGoodsGanreSummaryPrintDiv = value; }
        }
        /// <summary>
        /// 改ページ区分　プロパティ
        /// </summary>
        public NewPageDivState NewPageDiv
        {
            get { return this._newPageDiv; }
            set { this._newPageDiv = value; }
        }
        /// <summary>
        /// 改ページ区分　名称取得プロパティ
        /// </summary>
        public string NewPageDivStateTitle
        {
            get {
                switch (this._newPageDiv) {
                    case NewPageDivState.EachSummaly : return ct_NewPageDivState_EachSummaly;
                    case NewPageDivState.None : return ct_NewPageDivState_None;
                    default : return string.Empty;
                }
            }
        }
        # endregion ■ public propaty (自動生成以外) ■

        # region ■ public Enum (自動生成以外) ■
        /// <summary>
        /// 棚番ブレイク区分　列挙体
        /// </summary>
        public enum WarehouseShelfNoBreakDivState
        {
            /// <summary>１桁</summary>
            Length1 = 0,
            /// <summary>２桁</summary>
            Length2 = 1,
            /// <summary>３桁</summary>
            Length3 = 2,
            /// <summary>４桁</summary>
            Length4 = 3,
            /// <summary>５桁</summary>
            Length5 = 4,
            /// <summary>６桁</summary>
            Length6 = 5,
            /// <summary>７桁</summary>
            Length7 = 6,
            /// <summary>８桁</summary>
            Length8 = 7,
        }
        /// <summary>
        /// 小計印刷区分　列挙体
        /// </summary>
        public enum SummalyPrintDivState
        {
            /// <summary>印刷する</summary>
            Print = 0,
            /// <summary>印刷しない</summary>
            None = 1,
        }
        /// <summary>
        /// 発行タイプ　列挙体
        /// </summary>
        public enum PrintTypeState
        {
            /// <summary>当月</summary>
            ThisMonth = 0,
            /// <summary>当期</summary>
            ThisPeriod = 1,
        }
        /// <summary>
        /// 金額単位　列挙体
        /// </summary>
        public enum MoneyUnitState
        {
            /// <summary>円</summary>
            One = 0,
            /// <summary>千円</summary>
            Thousand = 1,
        }
        /// <summary>
        /// 改ページ区分　列挙体
        /// </summary>
        public enum NewPageDivState
        {
            /// <summary>小計毎</summary>
            EachSummaly = 0,
            /// <summary>しない</summary>
            None = 1,
        }
        /// <summary>
        /// 在庫登録日指定区分　列挙体
        /// </summary>
        public enum StockCreateDateDivState
        {
            /// <summary>以前</summary>
            Before = 0,
            /// <summary>以後</summary>
            After = 1,
        }
        /// <summary>
        /// 印刷順区分
        /// </summary>
        public enum PrintSortDivState
        {
            /// <summary>仕入先順</summary>
            ByCustomer = 0,
            /// <summary>倉庫棚番順</summary>
            ByWarehouseShelfNo = 1,
        }
        /// <summary>
        /// 合計印字区分　列挙体
        /// </summary>
        public enum SummaryPrintDivState
        {
            /// <summary>印字しない</summary>
            None = 0,
            /// <summary>印字する</summary>
            Print = 1,
        }
        # endregion ■ public Enum (自動生成以外) ■

        #region ■ public const (自動生成以外) ■
        /// <summary>共通 日付フォーマット</summary>
        public const string ct_DateFomat = "YYYY/MM/DD";

        /// <summary>共通 全て コード</summary>
        public const int ct_All_Code = -1;
        /// <summary>共通 全て 名称</summary>
        public const string ct_All_Name = "全て";

        /// <summary>小計印刷区分　印刷する</summary>
        public const string ct_SummalyPrintDivState_Print = "印刷する";
        /// <summary>小計印刷区分　印刷しない</summary>
        public const string ct_SummalyPrintDivState_None = "印刷しない";
        
        /// <summary>改ページ区分　小計毎</summary>
        public const string ct_NewPageDivState_EachSummaly = "小計毎";
        /// <summary>改ページ区分　印刷しない</summary>
        public const string ct_NewPageDivState_None = "印刷しない";

        /// <summary>印刷順区分　仕入先順</summary>
        public const string ct_PrintSortDivState_ByCustomer = "仕入先";
        /// <summary>印刷順区分　棚番順</summary>
        public const string ct_PrintSortDivState_ByWarehouseShelfNo = "棚番";

        #endregion

        # region ■ Constructor ■
        /// <summary>
        /// 在庫月報年報抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>StockGetuNenCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockGetuNenCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockMonthYearReportCndtn()
        {
        }
        # endregion ■ Constructor ■
    }
}

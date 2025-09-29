using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   StockNoShipmentListCndtn
	/// <summary>
	///                      在庫未出荷一覧表抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   在庫未出荷一覧表抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/10/01  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class StockNoShipmentListCndtn
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
		private Int32 _st_CustomerCode;

		/// <summary>終了仕入先コード</summary>
		private Int32 _ed_CustomerCode;

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

		/// <summary>開始自社分類コード</summary>
		private Int32 _st_EnterpriseGanreCode;

		/// <summary>終了自社分類コード</summary>
		private Int32 _ed_EnterpriseGanreCode;

		/// <summary>開始ＢＬ商品コード</summary>
		private Int32 _st_BLGoodsCode;

		/// <summary>終了ＢＬ商品コード</summary>
		private Int32 _ed_BLGoodsCode;

		/// <summary>開始商品番号</summary>
		private string _st_GoodsNo = "";

		/// <summary>終了商品番号</summary>
		private string _ed_GoodsNo = "";

		/// <summary>開始倉庫棚番</summary>
		private string _st_WarehouseShelfNo = "";

		/// <summary>終了倉庫棚番</summary>
		private string _ed_WarehouseShelfNo = "";

		/// <summary>在庫登録日</summary>
		/// <remarks>YYYYMMDD</remarks>
        private DateTime _stockCreateDate;

		/// <summary>在庫登録日指定区分</summary>
		/// <remarks>0:以前, 1:以後</remarks>
        private StockCreateDateDivState _stockCreateDateDiv;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

        //--- ADD 2008/07/17 ---------->>>>>
        /// <summary>部品管理区分１</summary>
        private string[] _partsManagementDivide1;

        /// <summary>部品管理区分２</summary>
        private string[] _partsManagementDivide2;
        //--- ADD 2008/07/17 ---------->>>>>

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

		/// public propaty name  :  St_CustomerCode
		/// <summary>開始仕入先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_CustomerCode
		{
			get{return _st_CustomerCode;}
			set{_st_CustomerCode = value;}
		}

		/// public propaty name  :  Ed_CustomerCode
		/// <summary>終了仕入先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_CustomerCode
		{
			get{return _ed_CustomerCode;}
			set{_ed_CustomerCode = value;}
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

		/// public propaty name  :  St_EnterpriseGanreCode
		/// <summary>開始自社分類コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始自社分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_EnterpriseGanreCode
		{
			get{return _st_EnterpriseGanreCode;}
			set{_st_EnterpriseGanreCode = value;}
		}

		/// public propaty name  :  Ed_EnterpriseGanreCode
		/// <summary>終了自社分類コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了自社分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_EnterpriseGanreCode
		{
			get{return _ed_EnterpriseGanreCode;}
			set{_ed_EnterpriseGanreCode = value;}
		}

		/// public propaty name  :  St_BLGoodsCode
		/// <summary>開始ＢＬ商品コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始ＢＬ商品コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_BLGoodsCode
		{
			get{return _st_BLGoodsCode;}
			set{_st_BLGoodsCode = value;}
		}

		/// public propaty name  :  Ed_BLGoodsCode
		/// <summary>終了ＢＬ商品コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了ＢＬ商品コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_BLGoodsCode
		{
			get{return _ed_BLGoodsCode;}
			set{_ed_BLGoodsCode = value;}
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

		/// public propaty name  :  St_WarehouseShelfNo
		/// <summary>開始倉庫棚番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始倉庫棚番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_WarehouseShelfNo
		{
			get{return _st_WarehouseShelfNo;}
			set{_st_WarehouseShelfNo = value;}
		}

		/// public propaty name  :  Ed_WarehouseShelfNo
		/// <summary>終了倉庫棚番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了倉庫棚番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_WarehouseShelfNo
		{
			get{return _ed_WarehouseShelfNo;}
			set{_ed_WarehouseShelfNo = value;}
		}

		/// public propaty name  :  StockCreateDate
		/// <summary>在庫登録日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫登録日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime StockCreateDate
		{
			get{return _stockCreateDate;}
			set{_stockCreateDate = value;}
		}

		/// public propaty name  :  StockCreateDateDiv
		/// <summary>在庫登録日指定区分プロパティ</summary>
		/// <value>0:以前, 1:以降 ()</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫登録日指定区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public StockCreateDateDivState StockCreateDateDiv
		{
			get{return _stockCreateDateDiv;}
			set{_stockCreateDateDiv = value;}
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

        //--- ADD 2008/07/17 ---------->>>>>
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
        //--- ADD 2008/07/17 ----------<<<<<

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
        /// 棚番ブレイク区分
        /// </summary>
        private WarehouseShelfNoBreakDivState _warehouseShelfNoBreakDiv;
        /// <summary>
        /// 小計印刷区分
        /// </summary>
        private SummalyPrintDivState _summalyPrintDiv;
        /// <summary>
        /// 改ページ区分
        /// </summary>
        private NewPageDivState _newPageDiv;
        /// <summary>
        /// 印刷順区分
        /// </summary>
        private PrintSortDivState _printSortDiv;
        
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
        /// 棚番ブレイク区分プロパティ
        /// </summary>
        public WarehouseShelfNoBreakDivState WarehouseShelfNoBreakDiv
        {
            get { return this._warehouseShelfNoBreakDiv; }
            set { this._warehouseShelfNoBreakDiv = value; }
        }
        /// <summary>
        /// 棚番ブレイク桁数
        /// </summary>
        public Int32 WarehouseShelfNoBreakLength
        {
            // ReadOnly
            get { 
                return ((int)this._warehouseShelfNoBreakDiv + 1);
            }
        }
        /// <summary>
        /// 小計印刷区分　プロパティ
        /// </summary>
        public SummalyPrintDivState SummalyPrintDiv
        {
            get { return this._summalyPrintDiv; }
            set { this._summalyPrintDiv = value; }
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
        /// 印刷順区分　プロパティ
        /// </summary>
        public PrintSortDivState PrintSortDiv
        {
            get { return this._printSortDiv; }
            set { this._printSortDiv = value; }
        }

        /// <summary>
        /// 棚番ブレイク区分　名称取得プロパティ
        /// </summary>
        public string WarehouseShelfNoBreakDivStateTitle
        {
            get {
                switch (this._warehouseShelfNoBreakDiv) {
                    case WarehouseShelfNoBreakDivState.Length1: return ct_WarehouseShelfNoBreakDivState_Length1;
                    case WarehouseShelfNoBreakDivState.Length2: return ct_WarehouseShelfNoBreakDivState_Length2;
                    case WarehouseShelfNoBreakDivState.Length3: return ct_WarehouseShelfNoBreakDivState_Length3;
                    case WarehouseShelfNoBreakDivState.Length4: return ct_WarehouseShelfNoBreakDivState_Length4;
                    case WarehouseShelfNoBreakDivState.Length5: return ct_WarehouseShelfNoBreakDivState_Length5;
                    case WarehouseShelfNoBreakDivState.Length6: return ct_WarehouseShelfNoBreakDivState_Length6;
                    case WarehouseShelfNoBreakDivState.Length7: return ct_WarehouseShelfNoBreakDivState_Length7;
                    case WarehouseShelfNoBreakDivState.Length8: return ct_WarehouseShelfNoBreakDivState_Length8;
                    default : return string.Empty;
                }
            }
        }
        /// <summary>
        /// 小計印刷区分　名称取得プロパティ
        /// </summary>
        public string SummalyPrintDivStateTitle
        {
            get {
                switch (this._summalyPrintDiv) {
                    case SummalyPrintDivState.Print : return ct_SummalyPrintDivState_Print;
                    case SummalyPrintDivState.None  : return ct_SummalyPrintDivState_None;
                    default : return string.Empty;
                }
            }
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
        /// <summary>
        /// 在庫登録日指定区分　名称取得プロパティ
        /// </summary>
        public string StockCreateDateDivStateTitle
        {
            get {
                switch (this._stockCreateDateDiv) {
                    case StockCreateDateDivState.Before : return ct_StockCreateDateDivState_Before;
                    case StockCreateDateDivState.After: return ct_StockCreateDateDivState_After;
                    default : return string.Empty;
                }
            }
        }
        /// <summary>
        /// 印刷順区分　名称取得プロパティ
        /// </summary>
        public string PrintSortDivStateTitle
        {
            get {
                switch (this._printSortDiv) {
                    case PrintSortDivState.ByCustomer : return ct_PrintSortDivState_ByCustomer;
                    case PrintSortDivState.ByWarehouseShelfNo : return ct_PrintSortDivState_ByWarehouseShelfNo;
                    default : return string.Empty;
                }
            }
        }
        /// <summary>
        /// 帳票サブタイトル　取得プロパティ
        /// </summary>
        public string ReportSubTitle
        {
            get {
                switch ( this._printSortDiv ) {
                    case PrintSortDivState.ByCustomer: return ct_ReportSubTitle_SortByCustomer;
                    case PrintSortDivState.ByWarehouseShelfNo: return ct_ReportSubTitle_SortByWarehouseShelfNo;
                    default: return string.Empty;
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
        # endregion ■ public Enum (自動生成以外) ■

        #region ■ public const (自動生成以外) ■
        /// <summary>共通 日付フォーマット</summary>
        public const string ct_DateFomat = "YYYY/MM/DD";

        /// <summary>共通 全て コード</summary>
        public const int ct_All_Code = -1;
        /// <summary>共通 全て 名称</summary>
        public const string ct_All_Name = "全て";

        /// <summary>棚番ブレイク区分　１桁</summary>
        public const string ct_WarehouseShelfNoBreakDivState_Length1 = "１桁";
        /// <summary>棚番ブレイク区分　２桁</summary>
        public const string ct_WarehouseShelfNoBreakDivState_Length2 = "２桁";
        /// <summary>棚番ブレイク区分　３桁</summary>
        public const string ct_WarehouseShelfNoBreakDivState_Length3 = "３桁";
        /// <summary>棚番ブレイク区分　４桁</summary>
        public const string ct_WarehouseShelfNoBreakDivState_Length4 = "４桁";
        /// <summary>棚番ブレイク区分　５桁</summary>
        public const string ct_WarehouseShelfNoBreakDivState_Length5 = "５桁";
        /// <summary>棚番ブレイク区分　６桁</summary>
        public const string ct_WarehouseShelfNoBreakDivState_Length6 = "６桁";
        /// <summary>棚番ブレイク区分　７桁</summary>
        public const string ct_WarehouseShelfNoBreakDivState_Length7 = "７桁";
        /// <summary>棚番ブレイク区分　８桁</summary>
        public const string ct_WarehouseShelfNoBreakDivState_Length8 = "８桁";

        /// <summary>小計印刷区分　印刷する</summary>
        public const string ct_SummalyPrintDivState_Print = "印刷する";
        /// <summary>小計印刷区分　印刷しない</summary>
        public const string ct_SummalyPrintDivState_None = "印刷しない";
        
        /// <summary>改ページ区分　小計毎</summary>
        public const string ct_NewPageDivState_EachSummaly = "小計毎";
        /// <summary>改ページ区分　印刷しない</summary>
        public const string ct_NewPageDivState_None = "印刷しない";

        /// <summary>在庫登録日指定区分　以前</summary>
        public const string ct_StockCreateDateDivState_Before = "以前";
        /// <summary>在庫登録日指定区分　以後</summary>
        public const string ct_StockCreateDateDivState_After = "以後";

        /// <summary>印刷順区分　仕入先順</summary>
        public const string ct_PrintSortDivState_ByCustomer = "仕入先";
        /// <summary>印刷順区分　棚番順</summary>
        public const string ct_PrintSortDivState_ByWarehouseShelfNo = "棚番";

        /// <summary>印刷順区分　仕入先順</summary>
        public const string ct_ReportSubTitle_SortByCustomer = "仕入先別";
        /// <summary>印刷順区分　棚番順</summary>
        public const string ct_ReportSubTitle_SortByWarehouseShelfNo = "棚番別";

        #endregion

        # region ■ Constructor ■
        /// <summary>
        /// 在庫未出荷一覧表抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>StockNoShipmentListCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockNoShipmentListCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockNoShipmentListCndtn ()
        {
        }
        # endregion ■ Constructor ■
    }
}

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ExtrInfo_ShipGoodsAnalyze
	/// <summary>
	///                      出荷商品分析表抽出条件
	/// </summary>
	/// <remarks>
	/// <br>note             :   出荷商品分析表抽出条件ヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/11/30  (CSharp File Generated Date)</br>
    /// <br></br>
    /// <br>UpdateNote       : 出力順の表記を変更。</br>
    /// <br>Programmer       : 980081 山田 明友</br>
    /// <br>Date             : 2008.04.03</br>
    /// <br>Update Note      : 2008.10.20 30452 上野 俊治</br>
    /// <br>                   ・PM.NS対応</br>
    /// <br>Update Note      :   2014/12/22 尹晶晶</br>
    /// <br>管理番号         :   11070263-00</br>
    /// <br>                 :  ・明治産業様Seiken品番変更</br>
    /// </remarks>
	public class ExtrInfo_ShipGoodsAnalyze
    {
        # region ■ private field ■
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>出力対象拠点</summary>
		/// <remarks>nullの場合は全拠点</remarks>
		private string[] _secCodeList = new string[0];

        /// <summary>集計方法</summary>
        //private Boolean _totalWay = false; // DEL 2008/10/20
        private TtlTypeState _ttlType; // ADD 2008/10/20
        
		/// <summary>開始対象年月</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _st_AddUpYearMonth;

		/// <summary>終了対象年月</summary>
		/// <remarks>YYYYMM</remarks>
        private DateTime _ed_AddUpYearMonth;

		/// <summary>在庫登録日</summary>
		/// <remarks>YYYYMMDD</remarks>
        private DateTime _ex_StockCreateDate;

        /// <summary>在庫登録日指定区分</summary>
        /// <remarks>0:以前, 1:以降</remarks>
        private BeforeAfterDivState _beforeAfterDiv = BeforeAfterDivState.Before;
        
        /// <summary>在取指定</summary>
        /// <remarks>0:合計 1:在庫 2:取寄</remarks>
        private RsltTtlDivState _rsltTtlDiv = RsltTtlDivState.Total;

        //------ ADD START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>>
        /// <summary>品番集計区分</summary>
        /// <remarks>0:別々 1:合算</remarks>
        private GoodsNoTtlDivState _goodsNoTtlDiv;

        /// <summary>品番表示区分</summary>
        /// /// <remarks>0:新品番 1:旧品番</remarks>
        private GoodsNoShowDivState _goodsNoShowDiv;
        //------ ADD END 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------<<<<<

        // --- ADD 2008/10/20 -------------------------------->>>>>
        /// <summary>開始仕入先コード</summary>
        private Int32 _st_SupplierCd;

        /// <summary>終了仕入先コード</summary>
        private Int32 _ed_SupplierCd;
        // --- ADD 2008/10/20 --------------------------------<<<<<

		/// <summary>開始メーカーコード</summary>
		private Int32 _st_GoodsMakerCd;

		/// <summary>終了メーカーコード</summary>
		private Int32 _ed_GoodsMakerCd;

		/// <summary>開始商品大分類コード</summary>
        private Int32 _st_GoodsLGroup;

		/// <summary>終了商品大分類コード</summary>
        private Int32 _ed_GoodsLGroup;

		/// <summary>開始商品中分類コード</summary>
        private Int32 _st_GoodsMGroup;

		/// <summary>終了商品中分類コード</summary>
        private Int32 _ed_GoodsMGroup;

		/// <summary>開始グループコード</summary>
        private Int32 _st_BLGroupCode;

		/// <summary>終了グループコード</summary>
        private Int32 _ed_BLGroupCode;

		/// <summary>開始BLコード</summary>
		private Int32 _st_BLGoodsCode;

		/// <summary>終了BLコード</summary>
		private Int32 _ed_BLGoodsCode;

		/// <summary>開始品番</summary>
		private string _st_GoodsNo = "";

		/// <summary>終了品番</summary>
		private string _ed_GoodsNo = "";

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";
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

		/// public propaty name  :  SectionCodes
		/// <summary>拠点コードプロパティ</summary>
		/// <value>（配列）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public string[] SecCodeList
		{
            get { return _secCodeList; }
            set { _secCodeList = value; }
		}

        // --- ADD 2008/10/20 -------------------------------->>>>>
        /// public propaty name  :  TtlType
        /// <summary>拠点別集計区分プロパティ</summary>
        /// <value>0:全社集計／1:拠点別集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点別集計区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TtlTypeState TtlType
        {
            get { return _ttlType; }
            set { _ttlType = value; }
        }
        // --- ADD 2008/10/20 --------------------------------<<<<<

		/// public propaty name  :  St_AddUpYearMonth
		/// <summary>開始対象年月プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始対象年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime St_AddUpYearMonth
		{
			get{return _st_AddUpYearMonth;}
			set{_st_AddUpYearMonth = value;}
		}

		/// public propaty name  :  Ed_AddUpYearMonth
		/// <summary>終了対象年月プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了対象年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime Ed_AddUpYearMonth
		{
			get{return _ed_AddUpYearMonth;}
			set{_ed_AddUpYearMonth = value;}
		}

		/// public propaty name  :  Ex_StockCreateDate
		/// <summary>在庫登録日プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫登録日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime Ex_StockCreateDate
		{
			get{return _ex_StockCreateDate;}
			set{_ex_StockCreateDate = value;}
		}

        /// <summary>
        /// 在庫登録日指定区分　プロパティ
        /// </summary>
        public BeforeAfterDivState BeforeAfterDiv
        {
            get { return this._beforeAfterDiv; }
            set { this._beforeAfterDiv = value; }
        }
        /// <summary>
        /// 在取指定区分　プロパティ
        /// </summary>
        public RsltTtlDivState RsltTtlDiv
        {
            get { return this._rsltTtlDiv; }
            set { this._rsltTtlDiv = value; }
        }

        //------ ADD START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>>
        /// <summary>
        /// 品番集計区分　プロパティ
        /// </summary>
        public GoodsNoTtlDivState GoodsNoTtlDiv
        {
            get { return _goodsNoTtlDiv; }
            set { _goodsNoTtlDiv = value; }
        }

        /// <summary>
        /// 品番表示区分　プロパティ
        /// </summary>
        public GoodsNoShowDivState GoodsNoShowDiv
        {
            get { return _goodsNoShowDiv; }
            set { _goodsNoShowDiv = value; }
        }
        //------ ADD END 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------<<<<<

        // --- ADD 2008/10/20 -------------------------------->>>>>
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
        // --- ADD 2008/10/20 --------------------------------<<<<< 

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

		/// public propaty name  :  St_GoodsLGroup
		/// <summary>開始商品大分類コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品大分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32 St_GoodsLGroup
		{
			get{return _st_GoodsLGroup;}
			set{_st_GoodsLGroup = value;}
		}

		/// public propaty name  :  Ed_GoodsLGroup
		/// <summary>終了商品大分類コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品大分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32 Ed_GoodsLGroup
		{
			get{return _ed_GoodsLGroup;}
			set{_ed_GoodsLGroup = value;}
		}

		/// public propaty name  :  St_GoodsMGroup
		/// <summary>開始商品中分類コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品中分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32 St_GoodsMGroup
		{
			get{return _st_GoodsMGroup;}
			set{_st_GoodsMGroup = value;}
		}

		/// public propaty name  :  Ed_GoodsMGroup
		/// <summary>終了商品中分類コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品中分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32 Ed_GoodsMGroup
		{
			get{return _ed_GoodsMGroup;}
			set{_ed_GoodsMGroup = value;}
		}

		/// public propaty name  :  St_BLGroupCode
		/// <summary>開始グループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32 St_BLGroupCode
		{
			get{return _st_BLGroupCode;}
			set{_st_BLGroupCode = value;}
		}

		/// public propaty name  :  Ed_BLGroupCode
		/// <summary>終了グループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32 Ed_BLGroupCode
		{
			get{return _ed_BLGroupCode;}
			set{_ed_BLGroupCode = value;}
		}

		/// public propaty name  :  St_BLGoodsCode
		/// <summary>開始BL商品コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始BL商品コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_BLGoodsCode
		{
			get{return _st_BLGoodsCode;}
			set{_st_BLGoodsCode = value;}
		}

		/// public propaty name  :  Ed_BLGoodsCode
		/// <summary>終了BL商品コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了BL商品コードプロパティ</br>
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
        # endregion ■ public propaty ■

        # region ■ private field (自動生成以外) ■
        /// <summary>拠点オプション区分</summary>
        private bool _isOptSection = false;
        /// <summary>全拠点選択区分</summary>
        private bool _isSelectAllSection = false;
		
        /// <summary>金額単位</summary>
        /// <remarks>0:円 1:千円</remarks>
        private MoneyUnitState _moneyUnit = MoneyUnitState.One;
        /// <summary>順位設定(拠点集計)</summary>
        /// <remarks>0:全体 1:拠点毎</remarks>
        private RankSectionState _rankSection = RankSectionState.All; 
   		/// <summary>順位設定(上位・下位)</summary>
		/// <remarks>0:上位 1:下位</remarks>
        private RankHighLowState _rankHighLow = RankHighLowState.High;
        /// <summary>順位設定(指定順位)</summary>
        private int _rankOrderMax;
        // --- DEL 2008/10/20 -------------------------------->>>>>
        ///// <summary>拠点計印刷区分</summary>
        ///// <remarks>0:する 1:しない</remarks>
        //private SubttlPrintDivState _subttlPrintDiv = SubttlPrintDivState.Do;
        // --- DEL 2008/10/20 --------------------------------<<<<<
        // --- ADD 2008/10/20 -------------------------------->>>>>
        /// <summary>拠点コード計印字区分</summary>
        /// <remarks>（ＵＩ制御項目）0:印字しない／1:する</remarks>
        private SubttlPrintDivState _sectionSumPrintDiv;

        /// <summary>仕入先計印字区分</summary>
        /// <remarks>（ＵＩ制御項目）0:印字しない／1:する</remarks>
        private SubttlPrintDivState _suplierSumPrintDiv;

        /// <summary>メーカー計印字区分</summary>
        /// <remarks>（ＵＩ制御項目）0:印字しない／1:する</remarks>
        private SubttlPrintDivState _makerSumPrintDiv;
        // --- ADD 2008/10/20 --------------------------------<<<<<
        /// <summary>改頁区分</summary>
        /// <remarks>0:拠点毎 1:仕入先毎 2:しない</remarks>
        private NewPageDivState _newPageDiv;
        /// <summary>印刷順</summary>
        /// <remarks>0:出荷数 1:売上金額 2:粗利金額</remarks>
        private OrderPrintDivState _orderPrintDiv = OrderPrintDivState.ShipmentCntOrder;
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
        // --- DEL 2008/10/20 -------------------------------->>>>>
        ///// <summary>
        ///// 集計方法　プロパティ
        ///// </summary>
        //public Boolean TotalWay
        //{
        //    get{ return this._totalWay; }
        //    set{ this._totalWay = value; }
        //}
        // --- DEL 2008/10/20 --------------------------------<<<<<
        
        /// <summary>
        /// 金額単位　プロパティ
        /// </summary>
        public MoneyUnitState MoneyUnit
        {
            get { return this._moneyUnit; }
            set { this._moneyUnit = value; }
        }
        /// <summary>
        /// 順位設定(拠点集計)　プロパティ
        /// </summary>
        public RankSectionState RankSection
        {
            get { return this._rankSection; }
            set { this._rankSection = value; }
        }
        /// <summary>
        /// 順位設定(上位・下位)　プロパティ
        /// </summary>
        public RankHighLowState RankHighLow
        {
            get { return this._rankHighLow; }
            set { this._rankHighLow = value; }
        }
        /// <summary>
        /// 順位設定(指定順位)　プロパティ
        /// </summary>
        public int RankOrderMax
        {
            get { return this._rankOrderMax; }
            set { this._rankOrderMax = value; }
        }
        // --- DEL 2008/10/20 -------------------------------->>>>>
        ///// <summary>
        ///// 小計印刷区分　プロパティ
        ///// </summary>
        //public SubttlPrintDivState SubttlPrintDiv
        //{
        //    get { return this._subttlPrintDiv; }
        //    set { this._subttlPrintDiv = value; }
        //}
        // --- DEL 2008/10/20 --------------------------------<<<<<
        // --- ADD 2008/10/20 -------------------------------->>>>>
        /// <summary>
        /// 小計印刷　拠点　プロパティ
        /// </summary>
        public SubttlPrintDivState SectionSumPrintDiv
        {
            get { return this._sectionSumPrintDiv; }
            set { this._sectionSumPrintDiv = value; }
        }
        /// <summary>
        /// 小計印刷　仕入先　プロパティ
        /// </summary>
        public SubttlPrintDivState SuplierSumPrintDiv
        {
            get { return this._suplierSumPrintDiv; }
            set { this._suplierSumPrintDiv = value; }
        }
        /// <summary>
        /// 小計印刷　メーカー　プロパティ
        /// </summary>
        public SubttlPrintDivState MakerSumPrintDiv
        {
            get { return this._makerSumPrintDiv; }
            set { this._makerSumPrintDiv = value; }
        }
        // --- ADD 2008/10/20 --------------------------------<<<<<
        /// <summary>
        /// 改ページ区分　プロパティ
        /// </summary>
        public NewPageDivState NewPageDiv
        {
            get { return this._newPageDiv; }
            set { this._newPageDiv = value; }
        }
        /// <summary>
        /// 印刷順　プロパティ
        /// </summary>
        public OrderPrintDivState OrderPrintDiv
        {
            get { return this._orderPrintDiv; }
            set { this._orderPrintDiv = value; }
        }
        /// <summary>
        /// 在庫登録日指定区分タイトル　プロパティ
        /// </summary>
        public string StockCreateDateDivTitle
        {
            get {
                switch (this._beforeAfterDiv){
                    case BeforeAfterDivState.Before : return ct_BeforeAfterDivState_Before;
                    case BeforeAfterDivState.After : return ct_BeforeAfterDivState_After;
                    default : return "";
                }
            }
        }
        /// <summary>
        /// 在取指定タイトル　プロパティ
        /// </summary>
        public string RsltTtlDivTitle
        {
            get
            {
                switch (this._rsltTtlDiv)
                {
                    case RsltTtlDivState.Total: return ct_RsltTtlDivState_Total;
                    case RsltTtlDivState.Stock: return ct_RsltTtlDivState_Stock;
                    case RsltTtlDivState.Acquire: return ct_RsltTtlDivState_Acquire;
                    default: return "";
                }
            }
        }
        //------ ADD START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>>
        /// <summary>
        /// 品番集計区分　プロパティ
        /// </summary>
        public string GoodsNoTtlDivTitle
        {
            get
            {
                switch (this._goodsNoTtlDiv)
                {
                    case GoodsNoTtlDivState.Total:
                        return ct_GoodsNoTtlDivState_Total;
                    case GoodsNoTtlDivState.Separate:
                        return ct_GoodsNoTtlDivState_Separate;
                    default:
                        return "";
                }
            }
        }
        /// <summary>
        /// 品番表示区分　プロパティ
        /// </summary>
        public string GoodsNoShowDivTitle
        {
            get
            {
                switch (this._goodsNoShowDiv)
                {
                    case GoodsNoShowDivState.New:
                        return ct_GoodsNoShowDivState_New;
                    case GoodsNoShowDivState.Old:
                        return ct_GoodsNoShowDivState_Old;
                    default:
                        return "";
                }
            }
        }
        //------ ADD END 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------<<<<<
        // --- ADD 2008/10/20 -------------------------------->>>>>
        /// <summary>
        /// 拠点別集計区分　名称取得
        /// </summary>
        public string TtlTypeName
        {
            get
            {
                switch (this._ttlType)
                {
                    case TtlTypeState.All:
                        return ct_TtlTypeState_All;
                    case TtlTypeState.BySection:
                        return ct_TtlTypeState_BySection;
                    default:
                        return string.Empty;
                }
            }
        }
        // --- ADD 2008/10/20 --------------------------------<<<<<
        /// <summary>
        /// 金額単位タイトル　プロパティ
        /// </summary>
        public string MoneyUnitStateTitle
        {
            get {
                switch (this._moneyUnit) {
                    case MoneyUnitState.One : return ct_MoneyUnitState_One;
                    case MoneyUnitState.Thousand : return ct_MoneyUnitState_Thousand;
                    default : return "";
                }
            }
        }
        /// <summary>
        /// 順位設定(拠点集計)タイトル　プロパティ
        /// </summary>
        public string RankSectionStateTitle
        {
            get {
                switch (this._rankSection) {
                    case RankSectionState.All : return ct_RankSectionState_All;
                    case RankSectionState.Section : return ct_RankSectionState_Section;
                    default : return "";
                }
            }
        }
        /// <summary>
        /// 順位設定(上位・下位)タイトル　プロパティ
        /// </summary>
        public string RankHighLowStateTitle
        {
            get {
                switch (this._rankHighLow) {
                    case RankHighLowState.High : return ct_RankHighLowState_High;
                    case RankHighLowState.Low : return ct_RankHighLowState_Low;
                    default : return "";
                }
            }
        }
        // --- DEL 2008/10/20 -------------------------------->>>>>
        ///// <summary>
        ///// 小計印刷区分タイトル　プロパティ
        ///// </summary>
        //public string SubttlPrintDivStateTitle
        //{
        //    get {
        //        switch (this._subttlPrintDiv) {
        //            case SubttlPrintDivState.Do : return ct_SubttlPrintDivState_Do;
        //            case SubttlPrintDivState.None : return ct_SubttlPrintDivState_None;
        //            default : return "";
        //        }
        //    }
        //}
        // --- DEL 2008/10/20 --------------------------------<<<<<
        /// <summary>
        /// 改ページ区分タイトル　プロパティ
        /// </summary>
        public string NewPageDivStateTitle
        {
            get {
                switch (this._newPageDiv) {
                    case NewPageDivState.BySection : return ct_NewPageDivState_Section;
                    case NewPageDivState.BySupplier: return ct_NewPageDivState_Suplier;
                    case NewPageDivState.None : return ct_NewPageDivState_None;
                    default : return "";
                }
            }
        }
        /// <summary>
        /// 印刷順タイトル　プロパティ
        /// </summary>
        public string OrderPrintDivStateTitle
        {
            get {
                switch (this._orderPrintDiv) {
                    case OrderPrintDivState.GrossProfitOrder : return ct_OrderPrintDivState_GrossProfitOrder;
                    case OrderPrintDivState.SalesMoneyTaxExcOrder : return ct_OrderPrintDivState_SalesMoneyTaxExcOrder;
                    case OrderPrintDivState.ShipmentCntOrder : return ct_OrderPrintDivState_ShipmentCntOrder;
                    default : return "";
                }
            }
        }
        # endregion ■ public propaty (自動生成以外) ■

        # region ■ public Enum (自動生成以外) ■
        /// <summary>
        /// 在庫登録日指定区分　列挙体
        /// </summary>
        public enum BeforeAfterDivState
        {
            /// <summary>指定日 以前</summary>
            Before = 0,
            /// <summary>指定日 以後</summary>
            After = 1
        }
        /// <summary>
        /// 在取指定  列挙体
        /// </summary>
        public enum RsltTtlDivState
        {
            /// <summary>0:合計</summary>
            Total = 0,
            /// <summary>1:在庫</summary>
            Stock = 1,
            /// <summary>2:取寄</summary>
            Acquire = 2
        }
        /// <summary>
        /// 金額単位　列挙体
        /// </summary>
        public enum MoneyUnitState
        {
            /// <summary>円</summary>
            One = 0,
            /// <summary>千円</summary>
            Thousand = 1
        }
        /// <summary>
        /// 順位設定(拠点集計)  列挙体
        /// </summary>
        public enum RankSectionState
        {
            /// <summary>全体</summary>
            All = 0,
            /// <summary>拠点毎</summary>
            Section = 1
        }
        /// <summary>
        /// 順位設定(上位・下位)　列挙体
        /// </summary>
        public enum RankHighLowState
        {
            /// <summary>上位</summary>
            High = 0,
            /// <summary>下位</summary>
            Low = 1
        }
        /// <summary>
        /// 小計印刷区分　列挙体
        /// </summary>
        public enum SubttlPrintDivState
        {
            /// <summary>する</summary>
            Do = 0,
            /// <summary>しない</summary>
            None = 1
        }
        /// <summary>
        /// 改ページ区分　列挙体
        /// </summary>
        public enum NewPageDivState
        {
            /// <summary>拠点毎</summary>
            BySection = 0,
            /// <summary>仕入先毎</summary>
            BySupplier = 1,
            /// <summary>しない</summary>
            None = 2,
        }
        /// <summary>
        /// 印刷順　列挙体
        /// </summary>
        public enum OrderPrintDivState
        {
            /// <summary>出荷数順</summary>
            ShipmentCntOrder = 0,
            /// <summary>売上金額順</summary>
            SalesMoneyTaxExcOrder = 1,
            /// <summary>粗利額順</summary>
            GrossProfitOrder = 2,
        }

        /// <summary>
        /// 拠点別集計区分　列挙型
        /// </summary>
        public enum TtlTypeState
        {
            /// <summary>全社</summary>
            All = 0,
            /// <summary>拠点毎</summary>
            BySection = 1,
        }

        //------ ADD START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>>
        /// <summary>
        /// 品番集計区分　列挙型
        /// </summary>
        public enum GoodsNoTtlDivState
        {
            /// <summary>別々</summary>
            Separate = 0,
            /// <summary>合算</summary>
            Total = 1,
        }

        /// <summary>
        /// 品番表示区分　列挙型
        /// </summary>
        public enum GoodsNoShowDivState
        {
            /// <summary>新品番</summary>
            New = 0,
            /// <summary>旧品番</summary>
            Old = 1,
        }
        //------ ADD END 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------<<<<<
        # endregion ■ public Enum (自動生成以外) ■

        #region ■ public const (自動生成以外) ■
        /// <summary>共通 日付フォーマット</summary>
        public const string ct_DateFomat = "YYYY/MM/DD";

        /// <summary>共通 全て コード</summary>
        public const int ct_All_Code = -1;
        /// <summary>共通 全て 名称</summary>
        public const string ct_All_Name = "全て";

        /// <summary>集計方法　全社集計</summary>
        public const string ct_TtlTypeState_All = "全社";
        /// <summary>集計方法　拠点別</summary>
        public const string ct_TtlTypeState_BySection = "拠点別";

        /// <summary>在庫登録日指定区分　以前</summary>
        public const string ct_BeforeAfterDivState_Before = "以前";
        /// <summary>在庫登録日指定区分　以後</summary>
        public const string ct_BeforeAfterDivState_After = "以後";

        /// <summary>在取指定　合計</summary>
        public const string ct_RsltTtlDivState_Total = "合計";
        /// <summary>在取指定　在庫</summary>
        public const string ct_RsltTtlDivState_Stock = "在庫";
        /// <summary>在取指定　在庫</summary>
        public const string ct_RsltTtlDivState_Acquire = "取寄";
        
        /// <summary>金額単位　円</summary>
        public const string ct_MoneyUnitState_One = "円";
        /// <summary>金額単位　千円</summary>
        public const string ct_MoneyUnitState_Thousand = "千円";

        /// <summary>順位設定(拠点集計)　全体</summary>
        public const string ct_RankSectionState_All = "全体";
        /// <summary>順位設定(拠点集計)　拠点毎</summary>
        public const string ct_RankSectionState_Section = "拠点毎";

        /// <summary>順位設定(上位・下位)　上位</summary>
        public const string ct_RankHighLowState_High = "上位";
        /// <summary>順位設定(上位・下位)　下位</summary>
        public const string ct_RankHighLowState_Low = "下位";

        /// <summary>小計印刷区分 する</summary>
        public const string ct_SubttlPrintDivState_Do = "する";
        /// <summary>小計印刷区分 しない</summary>
        public const string ct_SubttlPrintDivState_None = "しない";

        /// <summary>改ページ区分 拠点毎</summary>
        public const string ct_NewPageDivState_Section = "拠点単位";
        /// <summary>改ページ区分 仕入先毎</summary>
        public const string ct_NewPageDivState_Suplier = "仕入先単位"; // ADD 2008/10/20
        /// <summary>改ページ区分 しない</summary>
        public const string ct_NewPageDivState_None = "しない";

        //------ ADD START 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------>>>>>
        /// <summary>品番集計区分 合算</summary>
        public const string ct_GoodsNoTtlDivState_Total = "合算"; 
        /// <summary>品番集計区分 別々</summary>
        public const string ct_GoodsNoTtlDivState_Separate = "別々";

        /// <summary>品番表示区分 新品番</summary>
        public const string ct_GoodsNoShowDivState_New = "新品番";
        /// <summary>品番表示区分 旧品番</summary>
        public const string ct_GoodsNoShowDivState_Old = "旧品番";
        //------ ADD END 2014/12/22 尹晶晶 FOR Redmine#44209改良 ------<<<<<

        // ↓ 2008.04.03 980081 c
        ///// <summary>印刷順　出荷数順</summary>
        //public const string ct_OrderPrintDivState_ShipmentCntOrder = "数量";
        ///// <summary>印刷順　売上金額順</summary>
        //public const string ct_OrderPrintDivState_SalesMoneyTaxExcOrder = "売上金額";
        ///// <summary>印刷順　粗利額順</summary>
        //public const string ct_OrderPrintDivState_GrossProfitOrder = "粗利額";
        /// <summary>印刷順　出荷数順</summary>
        public const string ct_OrderPrintDivState_ShipmentCntOrder = "[数量順]";
        /// <summary>印刷順　売上金額順</summary>
        public const string ct_OrderPrintDivState_SalesMoneyTaxExcOrder = "[売上金額順]";
        ///// <summary>印刷順　粗利額順</summary>
        //public const string ct_OrderPrintDivState_GrossProfitOrder = "[粗利額順]"; // DEL 2008/10/20
        // ↑ 2008.04.03 980081 c
        /// <summary>印刷順　粗利金額順</summary>
        public const string ct_OrderPrintDivState_GrossProfitOrder = "[粗利金額順]"; // ADD 2008/10/20
        #endregion

        # region ■ Constructor ■
        /// <summary>
        /// 出荷商品分析表抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>StockAnalysisOrderListCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockAnalysisOrderListCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ExtrInfo_ShipGoodsAnalyze()
        {
        }
        # endregion ■ Constructor ■
    }
}

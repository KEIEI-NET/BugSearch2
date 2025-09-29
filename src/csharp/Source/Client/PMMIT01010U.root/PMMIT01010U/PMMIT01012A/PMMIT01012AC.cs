using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.IO;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
//using Broadleaf.Application.LocalAccess;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 検索見積用初期値取得アクセスクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 検索見積の初期値取得データ制御を行います。</br>
	/// <br>Programmer : 21024　佐々木 健</br>
	/// <br>Date       : 2008.05.21</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.21 men 新規作成</br>
    /// <br>2009.07.16 22018 鈴木 正臣 MANTIS[0013802] ＢＬコードガイドの初期表示モードを設定可能に変更。</br>
    /// <br></br>
    /// <br>Update Note: 2009/10/22 呉元嘯</br>
    /// <br>             PM.NS-3-A・PM.NS保守依頼②</br>
    /// <br>             保守依頼②の追加</br>
    /// <br>Update Note: 2010/05/17 工藤</br>
    /// <br>             品名表示対応</br>
    /// <br>Update Note: 2010/06/08　李占川　障害改良対応（７月リリース分）の対応</br>
    /// <br>             ①見積書印刷時のエラー対応</br>
    /// /// <br>UpdateNote : 2011/02/14 liyp</br>
    /// <br>            該当の部品情報が無くてもＴＢＯ検索を表示するように変更（MANTIS : 16624）</br>
    /// </remarks>
	public partial class EstimateInputInitDataAcs
	{
		# region ■コンストラクタ
		/// <summary>
		/// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
		/// </summary>
		private EstimateInputInitDataAcs()
		{
            // 品番必須モード
            this._inputMode = ctINPUTMODE_GoodsNoNecessary;
        }

		/// <summary>
        /// 検索見積用初期値取得アクセスクラス インスタンス取得処理
		/// </summary>
        /// <returns>検索見積用初期値取得アクセスクラス インスタンス</returns>
		public static EstimateInputInitDataAcs GetInstance()
		{
			if (_stockSlipInputInitDataAcs == null)
			{
				_stockSlipInputInitDataAcs = new EstimateInputInitDataAcs();
			}

			return _stockSlipInputInitDataAcs;
		}
		# endregion

		# region ■プライベート変数
		private static EstimateInputInitDataAcs _stockSlipInputInitDataAcs;

		private List<StockProcMoney> _stockProcMoneyList;
		private List<SalesProcMoney> _salesProcMoneyList;
        private List<SlipPrtSet> _slipPrtSetList;
        private List<CustSlipMng> _custSlipMngList;
        private List<Employee> _employeeList;
        private List<EmployeeDtl> _employeeDtlList;
        private List<Warehouse> _warehouseList;
        private List<MakerUMnt> _makerUMntList;
        private List<BLGoodsCdUMnt> _blGoodsCdUMntList;
        private List<SubSection> _subSectionList;
        private List<UOEGuideName> _uoeEGuideNameList;
        private SalesTtlSt _salesTtlSt;

		private GoodsAcs _goodsAcs;
		private TaxRateSet _taxRateSet;
		private AllDefSet _allDefSet;
		//private AcptAnOdrTtlSt _acptAnOdrTtlSt;
		//private StockTtlSt _stockTtlSt;
		private EstimateDefSet _estimateDefSet;
        private PosTerminalMg _posTerminalMg;
        private CompanyInf _companyInf;
        private UOESetting _uoeSetting;

        /// <summary>オプション情報</summary>
        private bool _opt_CarMng;
        private bool _opt_FreeSearch;
        private bool _opt_UOE;

        /// <summary>プログラムID</summary>
		private static string ctPGID = "PMMIT01012A";

        /// <summary> 入力モード</summary>
        private int _inputMode;

        private bool _readInitialData = false;
        private bool _readInitialData2 = false;

        //------------ADD 2009/10/22-------->>>>>
        private ArrayList _custRateGrpCodeList;
        private List<PriceSelectSet> _displayDivList;
        //------------ADD 2009/10/22--------<<<<<
		# endregion

		#region ■定数

        /// <summary>端数処理対象金額区分（金額）</summary>
        public const int ctFracProcMoneyDiv_Price = 0;
        /// <summary>端数処理対象金額区分（消費税）</summary>
        public const int ctFracProcMoneyDiv_Tax = 1;
        /// <summary>端数処理対象金額区分（単価）</summary>
        public const int ctFracProcMoneyDiv_UnitPrice = 2;

        /// <summary>UOEガイド区分（ＢＯ）</summary>
        public const int ctUOEGuideDivCd_BoCode = 1;
        /// <summary>UOEガイド区分（納品区分）</summary>
        public const int ctUOEGuideDivCd_DeliveredGoodsDiv = 2;
        /// <summary>UOEガイド区分（指定拠点）</summary>
        public const int ctUOEGuideDivCd_UOEResvdSection = 3;


		/// <summary>拠点コード(全社共通)</summary>
		private const string ctSectionCode_Common = "00";

		#endregion 

		#region ■デリゲート

		/// <summary>仕入金額処理区分設定キャッシュデリゲート</summary>
		public delegate void CacheStockProcMoneyListEventHandler( List<StockProcMoney> stockProcMoneyList );

		/// <summary>売上金額処理区分設定キャッシュデリゲート</summary>
		public delegate void CacheSalesProcMoneyListEventHandler( List<SalesProcMoney> salesProcMoneyList );

		#endregion

		#region ■イベント
		/// <summary>仕入金額処理区分設定セットイベント</summary>
		public event CacheStockProcMoneyListEventHandler CacheStockProcMoneyList;
		/// <summary>売上金額処理区分設定キャッシュイベント</summary>
		public event CacheSalesProcMoneyListEventHandler CacheSalesProcMoneyList;
		#endregion

		# region ■パブリック変数
		/// <summary>ユーザーガイド区分コード（返品理由）</summary>
		public static readonly int ctDIVCODE_UserGuideDivCd_RetGoodsReason = 91;

        /// <summary>備考ガイド区分コード（備考１）</summary>
        public static readonly int ctDIVCODE_NoteGuid_StockSlipNote1 = 103;
        /// <summary>備考ガイド区分コード（備考２）</summary>
        public static readonly int ctDIVCODE_NoteGuid_StockSlipNote2 = 104;

        /// <summary>品番必須モード</summary>
        public static readonly int ctINPUTMODE_GoodsNoNecessary = 1;

		# endregion

		#region ■プロパティ

		/// <summary>
		/// 入力モード
		/// </summary>
		public int InputMode
		{
			get { return this._inputMode; }
		}

		/// <summary>仕入金額処理区分設定リスト</summary>
		public List<StockProcMoney> StockProcMoneyList
		{
			get { return this._stockProcMoneyList; }
		}

		/// <summary>売上金額処理区分設定リスト</summary>
		public List<SalesProcMoney> SalesProcMoneyList
		{
			get { return this._salesProcMoneyList; }

		}

        /// <summary>伝票印刷設定マスタリスト</summary>
        public List<SlipPrtSet> SlipPrintSetList
        {
            get { return _slipPrtSetList; }
            set { _slipPrtSetList = value; }
        }

        /// <summary>得意先マスタ（伝票管理）リスト</summary>
        public List<CustSlipMng> CustSlipMngList
        {
            get { return _custSlipMngList; }
            set { _custSlipMngList = value; }
        }

        /// <summary>車両管理オプション</summary>
        public bool Opt_CarMng
        {
            get { return this._opt_CarMng; }
            set { this._opt_CarMng = value; }
        }

        /// <summary>自由検索オプション</summary>
        public bool Opt_FreeSearch
        {
            get { return this._opt_FreeSearch; }
            set { this._opt_FreeSearch = value; }
        }
        /// <summary>ＵＯＥオプション</summary>
        public bool Opt_UOE
        {
            get { return this._opt_UOE; }
            set { this._opt_UOE = value; }
        }

		#endregion

        #region ■列挙体
       
        #endregion


		# region ■パブリックメソッド

		/// <summary>
        /// 検索見積で使用する初期データをＤＢより取得します。
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <returns>STATUS</returns>
		public int ReadInitData(string enterpriseCode, string sectionCode)
		{
            //if (this._readInitialData) return 0;

            LogWrite("EstimateInputInitDataAcs", "ReadInitData", "開始");
            // 変数初期化
            this._employeeList = new List<Employee>();
            this._employeeDtlList = new List<EmployeeDtl>();
            this._warehouseList = new List<Warehouse>();
            this._uoeEGuideNameList = new List<UOEGuideName>();
            this._stockProcMoneyList = new List<StockProcMoney>();
            this._salesProcMoneyList = new List<SalesProcMoney>();
            //------------ADD 2009/10/22-------->>>>>
            this._custRateGrpCodeList = new ArrayList();
            this._displayDivList = new List<PriceSelectSet>();
            //------------ADD 2009/10/22--------<<<<<
            try
			{
				int status;

                #region ●従業員、従業員詳細マスタ取得
                //-----------------------------------------------------------
				// 従業員、従業員詳細マスタ取得
				//-----------------------------------------------------------
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "全従業員情報を取得");
				EmployeeAcs employeeAcs = new EmployeeAcs();
			
				EmployeeWork paraEmployee = new EmployeeWork();
				paraEmployee.EnterpriseCode = enterpriseCode;

				ArrayList employeeList;
				ArrayList employeeDtlList;
				status = employeeAcs.Search(out employeeList, out employeeDtlList, enterpriseCode);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    this._employeeList = new List<Employee>((Employee[])employeeList.ToArray(typeof(Employee)));
                    this._employeeDtlList = new List<EmployeeDtl>((EmployeeDtl[])employeeDtlList.ToArray(typeof(EmployeeDtl)));
                }
                #endregion

                #region ●倉庫マスタ取得
                //-----------------------------------------------------------
				// 倉庫マスタ取得
				//-----------------------------------------------------------
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "倉庫を取得");
				ArrayList returnWarehouse;
				WarehouseAcs warehouseAcs = new WarehouseAcs();

				WarehouseWork paraWarehouse = new WarehouseWork();
				paraWarehouse.EnterpriseCode = enterpriseCode;

				status = warehouseAcs.Search(out returnWarehouse, enterpriseCode);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    this._warehouseList = new List<Warehouse>((Warehouse[])returnWarehouse.ToArray(typeof(Warehouse)));
                }
                #endregion

                #region ●仕入金額処理区分設定マスタ
                //-----------------------------------------------------------
				// 仕入金額処理区分設定マスタ
				//-----------------------------------------------------------
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "仕入金額処理区分設定を取得");
				StockProcMoneyAcs stockProcMoneyAcs = new StockProcMoneyAcs();

				ArrayList retStockProcMoney;
                StockProcMoneyWork paraStockProcMoneyWork = new StockProcMoneyWork();
                paraStockProcMoneyWork.EnterpriseCode = enterpriseCode;
                paraStockProcMoneyWork.FracProcMoneyDiv = -1;

				status = stockProcMoneyAcs.Search(out retStockProcMoney, enterpriseCode);

				this._stockProcMoneyList = new List<StockProcMoney>();
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    this._stockProcMoneyList = new List<StockProcMoney>((StockProcMoney[])retStockProcMoney.ToArray(typeof(StockProcMoney)));
                    this._stockProcMoneyList.Sort(new StockProcMoneyComparer());
                }
                #endregion

                #region ●売上金額処理区分設定マスタ
                //-----------------------------------------------------------
				// 売上金額処理区分設定マスタ
				//-----------------------------------------------------------
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "売上金額処理区分設定を取得");
				SalesProcMoneyAcs salesProcMoneyAcs = new SalesProcMoneyAcs();
				ArrayList retSalesProcMoney;
				status = salesProcMoneyAcs.Search(out retSalesProcMoney, enterpriseCode);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    this._salesProcMoneyList = new List<SalesProcMoney>((SalesProcMoney[])retSalesProcMoney.ToArray(typeof(SalesProcMoney)));
                    this._salesProcMoneyList.Sort(new SalesProcMoneyComparer());
                }
                #endregion

                #region ●全体初期値設定マスタ
                //-----------------------------------------------------------
				// 全体初期値設定マスタ
				//-----------------------------------------------------------
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "全体初期値設定を取得");
				AllDefSetAcs allDefSetAcs = new AllDefSetAcs();
				AllDefSetAcs.SearchMode allDefSetSearchMode = AllDefSetAcs.SearchMode.Remote;
				ArrayList retAllDefSetList;
				status = allDefSetAcs.Search(out retAllDefSetList, enterpriseCode, allDefSetSearchMode);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// ログイン担当者の所属拠点もしくは全社設定を取得
					this._allDefSet = this.GetAllDefSetFromList(LoginInfoAcquisition.Employee.BelongSectionCode, retAllDefSetList);

					if (this._allDefSet != null)
					{
						//this._inputMode = this._allDefSet.GoodsNoInpDiv;
					}
				}
				else
				{
					this._allDefSet = null;
                }
                #endregion

                #region ●税率設定マスタ
                //-----------------------------------------------------------
				// 税率設定マスタ
				//-----------------------------------------------------------
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "消費税を取得");
				ArrayList returnTaxRateSet;

				TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();

				TaxRateSetAcs.SearchMode taxRateSetSearchMode = TaxRateSetAcs.SearchMode.Remote;
				status = taxRateSetAcs.Search(out returnTaxRateSet, enterpriseCode, taxRateSetSearchMode);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					this.CacheTaxRateSet((TaxRateSet)returnTaxRateSet[0]);
				}
				else
				{
					this._taxRateSet = null;
                }
                #endregion

                #region ●売上全体設定マスタ
                //-----------------------------------------------------------
				// 売上全体設定マスタ
				//-----------------------------------------------------------
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "売上全体設定を取得");
				ArrayList retSalesTtlSt;
				SalesTtlStAcs salesTtlStAcs = new SalesTtlStAcs();

				status = salesTtlStAcs.Search(out retSalesTtlSt, enterpriseCode);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    this._salesTtlSt = this.GetSalesTtlStFromList(sectionCode, retSalesTtlSt);
                }
                #endregion

                #region ●見積初期値設定マスタ
                //-----------------------------------------------------------
				// 見積初期値設定マスタ
				//-----------------------------------------------------------
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "見積初期値設定を取得");
				ArrayList retEstimateDefSet;
				EstimateDefSetAcs estimateDefSetAcs = new EstimateDefSetAcs();

				status = estimateDefSetAcs.Search(out retEstimateDefSet, enterpriseCode);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    this._estimateDefSet = this.GetEstimateDefSetFromList(sectionCode, retEstimateDefSet);
                }
                #endregion

                #region ●伝票印刷設定マスタ
                //-----------------------------------------------------------
                // 伝票印刷設定マスタ
                //-----------------------------------------------------------
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "伝票印刷設定マスタリストを取得");
                SlipPrtSetAcs slipPrtSetAcs = new SlipPrtSetAcs();
                ArrayList retSlipPrtSet;
                status = slipPrtSetAcs.SearchSlipPrtSet(out retSlipPrtSet, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._slipPrtSetList = new List<SlipPrtSet>((SlipPrtSet[])retSlipPrtSet.ToArray(typeof(SlipPrtSet)));
                }
                #endregion

                #region ●ＵＯＥガイド名称マスタ
                //-----------------------------------------------------------
                // ＵＯＥガイド名称マスタ
                //-----------------------------------------------------------
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "ＵＯＥガイド名称マスタリストを取得");
                UOEGuideName uOEGuideName = new UOEGuideName();
                uOEGuideName.EnterpriseCode = enterpriseCode;
                uOEGuideName.SectionCode = sectionCode;

                UOEGuideNameAcs uOEGuideNameAcs = new UOEGuideNameAcs();
                ArrayList retUOEGuideNameList;
                status = uOEGuideNameAcs.Search(out retUOEGuideNameList, uOEGuideName);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._uoeEGuideNameList = new List<UOEGuideName>((UOEGuideName[])retUOEGuideNameList.ToArray(typeof(UOEGuideName)));

                    this._uoeEGuideNameList.Sort(new UOEGuideNameComparer());
                }
                #endregion

                #region ●自社情報設定設定マスタ
                //-----------------------------------------------------------
                // 自社情報設定設定マスタ
                //-----------------------------------------------------------
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "自社情報設定設定を取得");
                CompanyInfAcs companyInfAcs = new CompanyInfAcs();
                companyInfAcs.Read(out this._companyInf, enterpriseCode);
                #endregion


                #region ●得意先マスタ（伝票管理）
                //-----------------------------------------------------------
                // 得意先マスタ（伝票管理）
                //-----------------------------------------------------------
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "得意先マスタ（伝票管理）リストを取得");
                int count = 0;
                CustSlipMngAcs custSlipMngAcs = new CustSlipMngAcs();
                status = custSlipMngAcs.SearchOnlyCustSlipMng(out count, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._custSlipMngList = new List<CustSlipMng>((CustSlipMng[])custSlipMngAcs.CustSlipMngList.ToArray(typeof(CustSlipMng)));
                }
                #endregion

                #region ●オプション情報
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "オプション情報を取得");
                this.CacheOptionInfo();
                #endregion

                #region ●ＵＯＥ自社マスタ
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "UOE自社マスタを取得");
                UOESettingAcs uOESettingAcs = new UOESettingAcs();
                uOESettingAcs.Read(out this._uoeSetting, enterpriseCode, sectionCode);
                #endregion

                //-----------ADD 2009/10/22--------->>>>>
                #region ●得意先掛率グループコードマスタ取得
                //-----------------------------------------------------------
                // 得意先掛率グループコードマスタ取得
                //-----------------------------------------------------------
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "得意先掛率グループコードマスタ情報を取得");
                CustRateGroupAcs custRateGroupAcs = new CustRateGroupAcs();
                status = custRateGroupAcs.Search(out this._custRateGrpCodeList, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
                #endregion

                #region ●標準価格選択設定マスタ取得
                //-----------------------------------------------------------
                // 標準価格選択設定マスタ取得
                //-----------------------------------------------------------
                LogWrite("EstimateInputInitDataAcs", "ReadInitData", "標準価格選択設定マスタ情報を取得");
                PriceSelectSetAcs priceSelectSetAcs = new PriceSelectSetAcs();
                ArrayList displayDivList;
                status = priceSelectSetAcs.Search(out displayDivList, enterpriseCode);
                this._displayDivList = new List<PriceSelectSet>((PriceSelectSet[])displayDivList.ToArray(typeof(PriceSelectSet)));

#endregion
                //-----------ADD 2009/10/22---------<<<<<
            }
			finally
			{
			}
            LogWrite("EstimateInputInitDataAcs", "ReadInitData", "終了");

            this._readInitialData = true;

			return 0;
		}

        /// <summary>
        /// 売上入力で使用する初期データをＤＢより取得します。
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public int ReadInitData2(string enterpriseCode, string sectionCode)
        {
            //if (_readInitialData2) return 0;

            this._goodsAcs = new GoodsAcs();

            // 変数初期化
            this._makerUMntList = new List<MakerUMnt>();
            this._blGoodsCdUMntList = new List<BLGoodsCdUMnt>();
            this._subSectionList = new List<SubSection>();

            ArrayList al = new ArrayList();

            //-----------------------------------------------------------
            // 商品アクセスクラス初期処理
            //-----------------------------------------------------------
            LogWrite("EstimateInputInitDataAcs", "ReadInitData2", "商品アクセスクラス初期処理");
            string retMessage;
            this._goodsAcs.SearchInitial(enterpriseCode, sectionCode, out retMessage);

            //-----------------------------------------------------------
            // メーカーマスタ
            //-----------------------------------------------------------
            LogWrite("EstimateInputInitDataAcs", "ReadInitData2", "メーカーリストを取得");
            int status = this._goodsAcs.GetAllMaker(enterpriseCode, out this._makerUMntList);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || this._makerUMntList == null)
            {
                this._makerUMntList = new List<MakerUMnt>();
            }

            //-----------------------------------------------------------
            // BLコードマスタ
            //-----------------------------------------------------------
            LogWrite("EstimateInputInitDataAcs", "ReadInitData2", "BLコードリストを取得");
            status = this._goodsAcs.GetAllBLGoodsCd(enterpriseCode, out this._blGoodsCdUMntList);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || this._blGoodsCdUMntList == null)
            {
                this._blGoodsCdUMntList = new List<BLGoodsCdUMnt>();
            }

            #region ●部門マスタ取得
            //-----------------------------------------------------------
            // 部門マスタ取得
            //-----------------------------------------------------------
            LogWrite("EstimateInputInitDataAcs", "ReadInitData", "部門を取得");
            SubSectionAcs subSectionAcs = new SubSectionAcs();
            ArrayList returnSubSection;
            status = subSectionAcs.Search(out returnSubSection, enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._subSectionList = new List<SubSection>((SubSection[])returnSubSection.ToArray(typeof(SubSection)));
            }

            #endregion

            #region ●端末管理マスタ
            //-----------------------------------------------------------
            // 端末管理マスタ
            //-----------------------------------------------------------
            LogWrite("EstimateInputInitDataAcs", "ReadInitData", "端末管理マスタを取得");
            PosTerminalMgAcs posTerminalMgAcs = new PosTerminalMgAcs();
            posTerminalMgAcs.Search(out this._posTerminalMg, enterpriseCode);
            #endregion


            _readInitialData2 = true;
            return 0;
        }

        /// <summary>
        /// キャッシュイベントコール
        /// </summary>
        public void CacheEventCall()
        {
            this.CacheStockProcMoneyListCall();
            this.CacheSalesProcMoneyListCall();
        }

		/// <summary>
		/// 初期検索データのチェック
		/// </summary>
		/// <param name="msg"></param>
		/// <returns></returns>
		public bool InitialReadDataCheck( out string msg )
		{
			msg = "";

			if (this.GetTaxRateSet() == null)
			{
				msg = "税率設定マスタの登録を行ってください。";
			}
			else if (this.GetAllDefSet() == null)
			{
				msg = "全体初期値設定マスタの登録を行ってください。";
			}
            //else if (this.GetAcptAnOdrTtlSt() == null)
            //{
            //    msg = "受発注管理全体設定マスタの登録を行ってください。";
            //}
			//else if (this.GetStockMngTtlSt() == null)
			//{
			//    msg = "在庫管理全体設定マスタの登録を行ってください。";
			//}
            //else if (this.GetStockTtlSt() == null)
            //{
            //    msg = "仕入在庫全体設定マスタの登録を行ってください。";
            //}
			else if (this.GetSalesTtlSt() == null)
			{
				msg = "売上全体設定マスタの登録を行ってください。";
			}
			else if (this.GetEstimateDefSet() == null)
			{
				msg = "見積初期値設定マスタの登録を行ってください。";
			}
            else if (this._posTerminalMg == null)
            {
                msg = "端末管理設定マスタの登録を行ってください。";
            }

			return msg == "";
		}

		# endregion

		# region ■従業員マスタキャッシュ制御処理

		/// <summary>
		/// 従業員名称取得処理
		/// </summary>
		/// <param name="employeeCode">従業員コード</param>
		/// <returns>従業員名称</returns>
        public string GetName_FromEmployee(string employeeCode)
        {
            Employee employee = this.GetEmployeeFromCache(employeeCode);
            return ( employee == null ) ? string.Empty : employee.Name;
        }

		/// <summary>
		/// 従業員所属情報取得
		/// </summary>
		/// <param name="employeeCode">従業員コード</param>
		/// <param name="belongSectionCode">所属拠点コード</param>
		/// <param name="belongSubSectionCode">所属部門コード</param>
        public void GetBelongInfo_FromEmployee(string employeeCode, out string belongSectionCode, out int belongSubSectionCode)
        {
            Employee employee = this.GetEmployeeFromCache(employeeCode);
            EmployeeDtl employeeDtl = this.GetEmployeeDtlFromCache(employeeCode);

            belongSectionCode = ( employee == null ) ? string.Empty : employee.BelongSectionCode;
            belongSubSectionCode = ( employeeDtl == null ) ? 0 : employeeDtl.BelongSubSectionCode;
        }

        /// <summary>
        /// 従業員情報取得
        /// </summary>
        /// <param name="employeeCode">従業員コード</param>
        /// <returns></returns>
        private Employee GetEmployeeFromCache(string employeeCode)
        {
            return this._employeeList.Find(
                        delegate(Employee employee)
                        {
                            if (employee.EmployeeCode.Trim() == employeeCode.Trim())
                            {
                                return true;
                            }

                            return false;
                        });

        }
		# endregion

		#region ■従業員詳細マスタキャッシュ制御処理

        /// <summary>
        /// 所属部門取得処理
        /// </summary>
        /// <param name="employeeCode">従業員コード</param>
        /// <param name="subSectionCode">部門コード</param>
        public void GetSubSection_FromEmployeeDtl(string employeeCode, out int subSectionCode)
        {
            EmployeeDtl employeeDtl = this.GetEmployeeDtlFromCache(employeeCode);

            subSectionCode = ( employeeDtl == null ) ? 0 : employeeDtl.BelongSubSectionCode;
        }

        /// <summary>
        /// 従業員詳細情報取得
        /// </summary>
        /// <param name="employeeCode">従業員コード</param>
        /// <returns></returns>
        private EmployeeDtl GetEmployeeDtlFromCache(string employeeCode)
        {
            return this._employeeDtlList.Find(
                        delegate(EmployeeDtl employeeDtl)
                        {
                            if (employeeDtl.EmployeeCode.Trim() == employeeCode.Trim())
                            {
                                return true;
                            }

                            return false;
                        });

        }
        #endregion

		# region ■倉庫マスタキャッシュ制御処理
		
		/// <summary>
		/// 倉庫名称取得処理
		/// </summary>
		/// <param name="warehouseCode">倉庫コード</param>
		/// <returns>倉庫名称</returns>
		public string GetName_FromWarehouse(string warehouseCode)
		{
            Warehouse warehouse = this.GetWarehouseFromCache(warehouseCode);

            return ( warehouse == null ) ? string.Empty : warehouse.WarehouseName;
		}

        /// <summary>
        /// 倉庫情報取得
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <returns></returns>
        private Warehouse GetWarehouseFromCache(string warehouseCode)
        {
            return this._warehouseList.Find(
                        delegate(Warehouse warehouse)
                        {
                            if (warehouse.WarehouseCode.Trim() == warehouseCode.Trim())
                            {
                                return true;
                            }

                            return false;
                        });

        }
		# endregion

		# region ■部門マスタキャッシュ制御処理

		/// <summary>
		/// 部門名称取得処理
		/// </summary>
		/// <param name="subSectionCode">部門コード</param>
		/// <returns>部門名称</returns>
		public string GetName_FromSubSection( int subSectionCode)
		{
            SubSection subSection = this.GetSubSectionFromCache(subSectionCode);

            return ( subSection == null ) ? string.Empty : subSection.SubSectionName;
		}
        
        /// <summary>
        /// 部門情報取得
        /// </summary>
        /// <param name="subSectionCode">部門コード</param>
        /// <returns></returns>
        private SubSection GetSubSectionFromCache(int subSectionCode)
        {
            return this._subSectionList.Find(
                        delegate(SubSection subSection)
                        {
                            if (subSection.SubSectionCode == subSectionCode)
                            {
                                return true;
                            }

                            return false;
                        });

        }		
        # endregion

		# region ■仕入在庫全体設定マスタキャッシュ制御処理
#if false
		/// <summary>
		/// 仕入全体設定マスタのリスト中から、指定した拠点の設定を取得します。
		/// </summary>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="stockTtlStArrayList">仕入全体設定マスタオブジェクトリスト</param>
		/// <returns>仕入全体設定マスタオブジェクト</returns>
		private StockTtlSt GetStockTtlStFromList( string sectionCode, ArrayList stockTtlStArrayList )
		{
			StockTtlSt allSecStockTtlSt = null;

			foreach (StockTtlSt stockTtlSt in stockTtlStArrayList)
			{
				if (stockTtlSt.SectionCode.Trim() == sectionCode.Trim())
				{
					return stockTtlSt;
				}
				else if (stockTtlSt.SectionCode.Trim() == ctSectionCode_Common.Trim())
				{
					allSecStockTtlSt = stockTtlSt;
				}
			}

			return allSecStockTtlSt;
		}

		/// <summary>
		/// 仕入在庫全体設定マスタ取得処理
		/// </summary>
		/// <returns>仕入在庫全体設定マスタオブジェクト</returns>
		public StockTtlSt GetStockTtlSt()
		{
			return this._stockTtlSt;
		}
#endif		
		# endregion

		#region ■受発注管理全体設定マスタキャッシュ制御関連（コメントアウト）
#if false
		/// <summary>
		/// 受発注管理全体設定マスタのリスト中から、指定した拠点で使用する設定を取得します。(拠点コードが無ければ全社設定）
		/// </summary>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="acptAnOdrTtlStArrayList">受発注管理全体設定マスタオブジェクトリスト</param>
		/// <returns>受発注管理全体設定マスタオブジェクト</returns>
		internal AcptAnOdrTtlSt GetAcptAnOdrTtlStFromList( string sectionCode, ArrayList acptAnOdrTtlStArrayList )
		{
			AcptAnOdrTtlSt allSecAcptAnOdrTtlSt = null;

			foreach (AcptAnOdrTtlSt acptAnOdrTtlSt in acptAnOdrTtlStArrayList)
			{
				if (acptAnOdrTtlSt.SectionCode.Trim() == sectionCode.Trim())
				{
					return acptAnOdrTtlSt;
				}
				else if (acptAnOdrTtlSt.SectionCode.Trim() == ctSectionCode_Common.Trim())
				{
					allSecAcptAnOdrTtlSt = acptAnOdrTtlSt;
				}
			}

			return allSecAcptAnOdrTtlSt;
		}

		/// <summary>
		/// 受発注管理全体設定マスタ取得処理
		/// </summary>
		/// <returns>受発注管理全体設定マスタオブジェクト</returns>
		public AcptAnOdrTtlSt GetAcptAnOdrTtlSt()
		{
			return this._acptAnOdrTtlSt;
		}
#endif
		#endregion

		# region ■全体初期値設定マスタキャッシュ制御処理

		/// <summary>
		/// 全体初期値設定マスタ検索処理
		/// </summary>
		/// <returns>全体初期値設定マスタオブジェクト</returns>
		public AllDefSet GetAllDefSet()
		{
			return this._allDefSet;
		}

		/// <summary>
		/// 全体初期値設定マスタのリスト中から、指定した拠点で使用する設定を取得します。(拠点コードが無ければ全社設定）
		/// </summary>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="allDefSetArrayList">全体初期値設定マスタオブジェクトリスト</param>
		/// <returns>全体初期値設定マスタオブジェクト</returns>
		private AllDefSet GetAllDefSetFromList( string sectionCode, ArrayList allDefSetArrayList )
		{
			AllDefSet allSecAllDefSet = null;

			foreach (AllDefSet allDefSet in allDefSetArrayList)
			{
				if (allDefSet.SectionCode.Trim() == sectionCode.Trim())
				{
					return allDefSet;
				}
				else if (allDefSet.SectionCode.Trim() == ctSectionCode_Common.Trim())
				{
					allSecAllDefSet = allDefSet;
				}
			}

			return allSecAllDefSet;
		}

		# endregion

        #region ■自社情報設定マスタキャッシュ制御関連

        /// <summary>
        /// 自社情報設定マスタ取得処理
        /// </summary>
        /// <returns>自社情報設定マスタオブジェクト</returns>
        public CompanyInf GetCompanyInf()
        {
            return this._companyInf;
        }

        #endregion

		#region ■売上全体設定マスタキャッシュ制御関連

		/// <summary>
		/// 売上全体設定マスタのリスト中から、指定した拠点の設定を取得します。
		/// </summary>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="salesTtlStStArrayList">売上全体設定マスタオブジェクトリスト</param>
		/// <returns>売上全体設定マスタオブジェクト</returns>
		private SalesTtlSt GetSalesTtlStFromList( string sectionCode, ArrayList salesTtlStStArrayList )
		{
			SalesTtlSt allSecSalesTtlSt = null;

			foreach (SalesTtlSt salesTtlSt in salesTtlStStArrayList)
			{
				if (salesTtlSt.SectionCode.Trim() == sectionCode.Trim())
				{
					return salesTtlSt;
				}
				else if (salesTtlSt.SectionCode.Trim() == ctSectionCode_Common.Trim())
				{
					allSecSalesTtlSt = salesTtlSt;
				}
			}

			return allSecSalesTtlSt;
		}

		/// <summary>
		/// 売上全体設定マスタ検索処理
		/// </summary>
		/// <returns>売上全体設定マスタオブジェクト</returns>
		public SalesTtlSt GetSalesTtlSt()
		{
			return this._salesTtlSt;
		}

		#endregion

		# region ■税率設定マスタキャッシュ制御
		/// <summary>
		/// 税率設定マスタキャッシュ処理
		/// </summary>
		/// <param name="taxRateSet">税率設定マスタオブジェクト</param>
		internal void CacheTaxRateSet( TaxRateSet taxRateSet )
		{
			this._taxRateSet = taxRateSet;
		}

		/// <summary>
		/// 税率設定マスタオブジェクト取得
		/// </summary>
		/// <returns>税率設定マスタオブジェクト</returns>
		public TaxRateSet GetTaxRateSet()
		{
			return this._taxRateSet;
		}

		/// <summary>
		/// 税率設定マスタで登録されている消費税率を取得します。
		/// </summary>
		/// <param name="addUpDate">計上日</param>
		/// <returns>消費税率</returns>
		public double GetTaxRate( DateTime addUpDate )
		{
            return TaxRateSetAcs.GetTaxRate(this.GetTaxRateSet(), addUpDate);
		}

		/// <summary>
		/// 税率設定マスタに設定されている消費税名称を取得します。
		/// </summary>
		/// <returns>消費税表示名称</returns>
		public string GetTaxRateName()
		{
			string result = "";
			TaxRateSet taxRateSet = this.GetTaxRateSet();

			if (taxRateSet == null) return result;

			return taxRateSet.TaxRateName;
		}
		# endregion

        #region ■端末管理マスタ

        /// <summary>
        /// 端末管理マスタを取得します。
        /// </summary>
        /// <returns></returns>
        public PosTerminalMg GetPosTerminalMg()
        {
            return this._posTerminalMg;
        }

        #endregion

		# region ■見積初期値設定マスタキャッシュ制御処理

		/// <summary>
		/// 見積初期値設定マスタのリスト中から、指定した拠点の設定を取得します。
		/// </summary>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="estimateDefSetArrayList">見積初期値設定マスタオブジェクトリスト</param>
		/// <returns>見積初期値設定マスタオブジェクト</returns>
		private EstimateDefSet GetEstimateDefSetFromList( string sectionCode, ArrayList estimateDefSetArrayList )
		{
			EstimateDefSet allEstimateDefSet = null;

			foreach (EstimateDefSet estimateDefSet in estimateDefSetArrayList)
			{
				if (estimateDefSet.SectionCode.Trim() == sectionCode.Trim())
				{
					return estimateDefSet;
				}
				else if (estimateDefSet.SectionCode.Trim() == ctSectionCode_Common.Trim())
				{
					allEstimateDefSet = estimateDefSet;
				}
			}

			return allEstimateDefSet;
		}


		/// <summary>
		/// 見積初期値設定マスタ検索処理
		/// </summary>
		/// <returns>見積初期値設定マスタオブジェクト</returns>
		public EstimateDefSet GetEstimateDefSet()
		{
			return this._estimateDefSet;
		}
		# endregion

		# region ■メーカーマスタキャッシュ制御処理

        /// <summary>
        /// メーカー名称取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="makerName">メーカー名称</param>
        /// <param name="makerKanaName">メーカー名称カナ</param>
        public bool GetName_FromMaker( int makerCode, out string makerName, out string makerKanaName )
        {
            MakerUMnt makerUMnt = this.GetMakerUMntFromCache(makerCode);

            if (makerUMnt == null)
            {
                makerName = string.Empty;
                makerKanaName = string.Empty;
                return false;
            }
            else
            {
                makerName = makerUMnt.MakerName;
                makerKanaName = makerUMnt.MakerKanaName;
                return true;
            }
        }

        /// <summary>
        /// メーカー情報取得
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns></returns>
        private MakerUMnt GetMakerUMntFromCache(int makerCode)
        {
            return this._makerUMntList.Find(
                        delegate(MakerUMnt makerUMnt)
                        {
                            if (makerUMnt.GoodsMakerCd == makerCode)
                            {
                                return true;
                            }

                            return false;
                        });

        }
        # endregion

		# region ■BLコードマスタキャッシュ制御処理
		
        /// <summary>
        /// BLコード名称取得処理
        /// </summary>
        /// <param name="blGoodsCode">BLコード</param>
        /// <param name="blGoodsFullName">BLコード名称</param>
        /// <param name="bLGoodsHalfName">BLコード名称(カナ)</param>
        public void GetName_FromBLGoods( int blGoodsCode, out string blGoodsFullName, out string bLGoodsHalfName )
        {
            BLGoodsCdUMnt blGoodsCdUMnt = this.GetBLGoodsCdUMntFromCache(blGoodsCode);
            blGoodsFullName = ( blGoodsCdUMnt == null ) ? string.Empty : blGoodsCdUMnt.BLGoodsFullName;
            bLGoodsHalfName = ( blGoodsCdUMnt == null ) ? string.Empty : blGoodsCdUMnt.BLGoodsHalfName;
        }

        /// <summary>
        /// BLコード情報取得
        /// </summary>
        /// <param name="blGoodsCode">BLコード</param>
        /// <returns></returns>
        // DEL 2010/05/17 品名表示対応 ---------->>>>>
        //private BLGoodsCdUMnt GetBLGoodsCdUMntFromCache(int blGoodsCode)
        // DEL 2010/05/17 品名表示対応 ----------<<<<<
        // ADD 2010/05/17 品名表示対応 ---------->>>>>
        internal BLGoodsCdUMnt GetBLGoodsCdUMntFromCache(int blGoodsCode)
        // ADD 2010/05/17 品名表示対応 ----------<<<<<
        {
            return this._blGoodsCdUMntList.Find(
                        delegate(BLGoodsCdUMnt blGoodsCdUMnt)
                        {
                            if (blGoodsCdUMnt.BLGoodsCode == blGoodsCode)
                            {
                                return true;
                            }

                            return false;
                        });
        }

        # endregion

        #region ■UOE自社マスタキャッシュ制御関連

        /// <summary>
        /// UOE自社マスタ取得処理
        /// </summary>
        /// <returns>自社情報設定マスタオブジェクト</returns>
        public UOESetting GetUOESetting()
        {
            return this._uoeSetting;
        }

        #endregion

        # region ■ＵＯＥガイド名称マスタキャッシュ制御処理

        /// <summary>
		/// ＵＯＥガイド名称取得処理
		/// </summary>
        /// <param name="uoeGuideDivCd">ＵＯＥガイド区分</param>
        /// <param name="uoeSupplierCd">ＵＯＥ発注先コード</param>
        /// <param name="uoeGuideCode">ＵＯＥガイドコード</param>
        public string GetName_FromUOEGuideName(int uoeGuideDivCd, int uoeSupplierCd, string uoeGuideCode)
		{
            UOEGuideName uoeGuideName = this.GetUOEGuideNameFromCache(uoeGuideDivCd, uoeSupplierCd, uoeGuideCode);

            return ( uoeGuideName == null ) ? string.Empty : uoeGuideName.UOEGuideNm;
		}

        /// <summary>
        /// ＵＯＥガイド名称最小コード取得処理
        /// </summary>
        /// <param name="uoeGuideDivCd">ＵＯＥガイド区分</param>
        /// <param name="uoeSupplierCd">ＵＯＥ発注先コード</param>
        /// <param name="uoeGuideCode">ＵＯＥガイドコード</param>
        /// <param name="uoeGuideName">ＵＯＥガイド名称</param>
        public void GetMinElementFromUOEGuideName(int uoeGuideDivCd, int uoeSupplierCd, out string uoeGuideCode, out string uoeGuideName)
        {
            UOEGuideName findUOEGuideName = this.GetUOEGuideNameFromCache(uoeGuideDivCd, uoeSupplierCd);

            if (findUOEGuideName == null)
            {
                uoeGuideCode = string.Empty;
                uoeGuideName = string.Empty;
            }
            else
            {
                uoeGuideCode = findUOEGuideName.UOEGuideCode;
                uoeGuideName = findUOEGuideName.UOEGuideNm;
            }
        }

        /// <summary>
        /// ＵＯＥガイド名称最小コード取得処理
        /// </summary>
        /// <param name="uoeGuideDivCd">ＵＯＥガイド区分</param>
        /// <param name="uoeSupplierCd">ＵＯＥ発注先コード</param>
        public List<UOEGuideName> GetUOEGuideNameListFromCache(int uoeGuideDivCd, int uoeSupplierCd)
        {
            return this._uoeEGuideNameList.FindAll(
                        delegate(UOEGuideName uoeGuideName)
                        {
                            if (( uoeGuideName.UOEGuideDivCd == uoeGuideDivCd ) &&
                                ( uoeGuideName.UOESupplierCd == uoeSupplierCd ))
                            {
                                return true;
                            }

                            return false;
                        });
        }


        /// <summary>
        /// ＵＯＥガイド名称情報取得
        /// </summary>
        /// <param name="uoeGuideDivCd">ＵＯＥガイド区分</param>
        /// <param name="uoeSupplierCd">ＵＯＥ発注先コード</param>
        /// <returns></returns>
        private UOEGuideName GetUOEGuideNameFromCache(int uoeGuideDivCd, int uoeSupplierCd)
        {
            return this._uoeEGuideNameList.Find(
                        delegate(UOEGuideName uoeGuideName)
                        {
                            if (( uoeGuideName.UOEGuideDivCd == uoeGuideDivCd ) &&
                                ( uoeGuideName.UOESupplierCd == uoeSupplierCd ))
                            {
                                return true;
                            }

                            return false;
                        });
        }

        /// <summary>
        /// ＵＯＥガイド名称情報取得
        /// </summary>
        /// <param name="uoeGuideDivCd">ＵＯＥ発注先コード</param>
        /// <param name="uoeSupplierCd">ＵＯＥガイドコード</param>
        /// <param name="uoeGuideCode">ＵＯＥガイド区分</param>
        /// <returns></returns>
        private UOEGuideName GetUOEGuideNameFromCache(int uoeGuideDivCd, int uoeSupplierCd, string uoeGuideCode)
        {
            return this._uoeEGuideNameList.Find(
                        delegate(UOEGuideName uoeGuideName)
                        {
                            if (( uoeGuideName.UOEGuideDivCd == uoeGuideDivCd ) &&
                                ( uoeGuideName.UOESupplierCd == uoeSupplierCd ) &&
                                ( uoeGuideName.UOEGuideCode == uoeGuideCode ))
                            {
                                return true;
                            }

                            return false;
                        });
        }
        # endregion

        # region ■仕入金額処理区分設定マスタキャッシュ制御処理
        
        /// <summary>
        /// 仕入金額処理区分設定キャッシュデリゲート コール処理
        /// </summary>
        private void CacheStockProcMoneyListCall()
        {
            if (this.CacheStockProcMoneyList != null)
            {
                this.CacheStockProcMoneyList(this._stockProcMoneyList);
            }
        }

        # endregion

        #region ■仕入金額処理区分設定マスタ データ取得処理関連
        /// <summary>
        /// 仕入金額処理区分設定マスタより、対象金額に該当する端数処理単位、端数処理コードを取得します。
        /// </summary>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="price">対象金額</param>
        /// <param name="fractionProcUnit">端数処理単位</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        public void GetStockFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double price, out double fractionProcUnit, out int fractionProcCd)
        {
            //デフォルト
            switch (fracProcMoneyDiv)
            {
                case ctFracProcMoneyDiv_UnitPrice: // 単価は0.01円単位
                    fractionProcUnit = 0.01;
                    break;
                default:
                    fractionProcUnit = 1;               // 単価以外は1円単位
                    break;
            }
            fractionProcCd = 1;     // 切捨て

            if (_stockProcMoneyList == null || _stockProcMoneyList.Count == 0) return;

            List<StockProcMoney> stockProcMoneyList = _stockProcMoneyList.FindAll(
                                        delegate(StockProcMoney stockProcMoney)
                                        {
                                            if (( stockProcMoney.FracProcMoneyDiv == fracProcMoneyDiv ) &&
                                                ( stockProcMoney.FractionProcCode == fractionProcCode ) &&
                                                ( stockProcMoney.UpperLimitPrice >= price ))
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        });
            if (stockProcMoneyList != null && stockProcMoneyList.Count > 0)
            {
                fractionProcUnit = stockProcMoneyList[0].FractionProcUnit;
                fractionProcCd = stockProcMoneyList[0].FractionProcCd;
            }
        }
        #endregion

        # region ■売上金額処理区分設定マスタキャッシュ制御処理
        
        /// <summary>
        /// 売上金額処理区分設定キャッシュデリゲート コール処理
        /// </summary>
        private void CacheSalesProcMoneyListCall()
        {
            if (this.CacheSalesProcMoneyList != null)
            {
                this.CacheSalesProcMoneyList(this._salesProcMoneyList);
            }
        }


        # endregion

        #region ■売上金額処理区分設定マスタ データ取得処理関連

        /// <summary>
        /// 売上金額処理区分設定マスタより、対象金額に該当する端数処理単位、端数処理コードを取得します。
        /// </summary>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="price">対象金額</param>
        /// <param name="fractionProcUnit">端数処理単位</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        public void GetSalesFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double price, out double fractionProcUnit, out int fractionProcCd)
        {
            //デフォルト
            switch (fracProcMoneyDiv)
            {
                case ctFracProcMoneyDiv_UnitPrice:	// 単価
                    fractionProcUnit = 0.01;
                    break;
                default:
                    fractionProcUnit = 1;			// 単価以外は1円単位
                    break;
            }
            fractionProcCd = 1;     // 切捨て

            if (_salesProcMoneyList == null || _salesProcMoneyList.Count == 0) return;

            List<SalesProcMoney> salesProcMoneyList = _salesProcMoneyList.FindAll(
                                        delegate(SalesProcMoney salesProcMoney)
                                        {
                                            if (( salesProcMoney.FracProcMoneyDiv == fracProcMoneyDiv ) &&
                                                ( salesProcMoney.FractionProcCode == fractionProcCode ) &&
                                                ( salesProcMoney.UpperLimitPrice >= price ))
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        });
            if (salesProcMoneyList != null && salesProcMoneyList.Count > 0)
            {
                fractionProcUnit = salesProcMoneyList[0].FractionProcUnit;
                fractionProcCd = salesProcMoneyList[0].FractionProcCd;
            }
        }
        #endregion

        # region ■商品関連処理
        /// <summary>
        /// 商品データリスト生成処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="makerCodeList">メーカーコードリスト</param>
        /// <param name="goodsCodeList">商品コードリスト</param>
        /// <returns>商品データリスト</returns>
        public List<GoodsUnitData> CreateGoodsUnitDataList(string enterpriseCode, string sectionCode, List<int> makerCodeList, List<string> goodsCodeList)
        {
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();

            for (int i = 0; i < makerCodeList.Count; i++)
            {
                GoodsUnitData goodsUnitData;
                int status = this._goodsAcs.Read(enterpriseCode, sectionCode, makerCodeList[i], goodsCodeList[i], out goodsUnitData);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    goodsUnitDataList.Add(goodsUnitData);
                }
            }

            return goodsUnitDataList;
        }

        /// <summary>
        /// 検索タイプ取得処理
        /// </summary>
        /// <param name="inputCode">入力されたコード</param>
        /// <param name="searchCode">検索用コード（*を除く）</param>
        /// <returns>0:完全一致検索 1:前方一致検索 2:後方一致検索 3:曖昧検索</returns>
        public static int GetSearchType(string inputCode, out string searchCode)
        {
            searchCode = inputCode;
            if (String.IsNullOrEmpty(inputCode)) return 0;

            if (inputCode.Contains("*"))
            {
                searchCode = inputCode.Replace("*", "");
                string firstString = inputCode.Substring(0, 1);
                string lastString = inputCode.Substring(inputCode.Length - 1, 1);

                if (( firstString == "*" ) && ( lastString == "*" ))
                {
                    return 3;
                }
                else if (firstString == "*")
                {
                    return 2;
                }
                else if (lastString == "*")
                {
                    return 1;
                }
                else
                {
                    return 3;
                }
            }
            // *無し、-有りは完全一致検索
            else if (inputCode.Contains("-"))
            {
                return 0;
            }
            // *無し、-無しはハイフン無し品番検索
            else
            {

                return 4;
            }
        }

        /// <summary>
        /// 指定した商品コードを元に商品情報を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="goodsCode">商品コード</param>
        /// <param name="goodsUnitData">商品情報オブジェクト（out）</param>
        /// <returns>STATUS</returns>
        public int GetGoodsUnitData(string enterpriseCode, string sectionCode, int makerCode, string goodsCode, out GoodsUnitData goodsUnitData)
        {
            return this._goodsAcs.Read(enterpriseCode, sectionCode, makerCode, goodsCode, out goodsUnitData);
        }

        /// <summary>
        /// 指定した商品コードを元に商品情報を取得します。（オーバーロード）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="goodsCode">商品コード</param>
        /// <param name="goodsUnitDataList">商品情報オブジェクトリスト</param>
        /// <returns>STATUS</returns>
        public int GetGoodsUnitData(string enterpriseCode, string sectionCode, string goodsCode, out List<GoodsUnitData> goodsUnitDataList)
        {
            return this._goodsAcs.Read(enterpriseCode, sectionCode, goodsCode, out goodsUnitDataList);
        }

        /// <summary>
        /// 品番検索
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="goodsCndtn"></param>
        /// <param name="partsInfoDataSet"></param>
        /// <param name="goodsUnitDataList"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int SearchParts(IWin32Window owner, GoodsCndtn goodsCndtn, out PartsInfoDataSet partsInfoDataSet, out List<GoodsUnitData> goodsUnitDataList, out string msg)
        {
            this._goodsAcs.Owner = owner;
            return this._goodsAcs.SearchPartsFromGoodsNo(goodsCndtn, out partsInfoDataSet, out goodsUnitDataList, out msg);
        }

        /// <summary>
        /// BLコード部品検索
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="goodsCndtn">検索条件</param>
        /// <param name="partsInfoDataSet">部品検索データセット</param>
        /// <param name="goodsUnitDataList">商品情報オブジェクトリスト</param>
        /// <param name="msg"></param>
        /// <returns>STATUS</returns>
        public int BLPartsSearch(IWin32Window owner, GoodsCndtn goodsCndtn, out PartsInfoDataSet partsInfoDataSet, out List<GoodsUnitData> goodsUnitDataList, out string msg)
        {
            this._goodsAcs.Owner = owner;
            return this._goodsAcs.SearchPartsFromBLCode(goodsCndtn, out partsInfoDataSet, out goodsUnitDataList, out msg);
        }

        /// <summary>
        /// 商品連結データ不足情報設定
        /// </summary>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <param name="isSettingSupplier">True:仕入先セットする</param>
        /// <returns></returns>
        public void SettingGoodsUnitDataListFromVariousMst(ref List<GoodsUnitData> goodsUnitDataList, bool isSettingSupplier)
        {
            List<GoodsUnitData> retGoodsUnitDataList = new List<GoodsUnitData>();
            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                GoodsUnitData retGoodsUnitData = goodsUnitData.Clone();
                this.SettingGoodsUnitDataListFromVariousMst(ref retGoodsUnitData, isSettingSupplier);
                retGoodsUnitDataList.Add(retGoodsUnitData);
            }
            goodsUnitDataList = retGoodsUnitDataList;
        }

        /// <summary>
        /// 商品連結データ不足情報設定
        /// </summary>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <param name="isSettingSupplier">仕入先取得有無</param>
        /// <returns></returns>
        public void SettingGoodsUnitDataListFromVariousMst(ref GoodsUnitData goodsUnitData, bool isSettingSupplier)
        {
            this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData, ( isSettingSupplier ) ? 0 : 1);
        }

        /// <summary>
        /// TBO検索
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="cndtn">商品検索抽出条件クラス</param>
        /// <param name="partsInfoDataSet">部品検索データセット</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <br>UpdateNote : 2011/02/11 liyp</br>
        /// <br>            該当の部品情報が無くてもＴＢＯ検索を表示するように変更（MANTIS : 16624）</br>
        /// <returns></returns>           
        public int SearchTBO(IWin32Window owner, GoodsCndtn cndtn, out PartsInfoDataSet partsInfoDataSet, out List<GoodsUnitData> goodsUnitDataList, out string msg)
        {
            this._goodsAcs.Owner = owner;
            // return this._goodsAcs.SearchTBO(cndtn, out partsInfoDataSet, out  goodsUnitDataList, out msg); // DEL 2011/02/14
            return this._goodsAcs.SearchTBOForButton(cndtn, out partsInfoDataSet, out  goodsUnitDataList, out msg); // ADD 2011/02/14
        }

        /// <summary>
        /// BLコードガイド起動
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="bLGoodsCdUMntList"></param>
        /// <param name="searchCarInfo"></param>
        /// <returns></returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 DEL
        //public int ExecuteBLGoodsCd(IWin32Window owner, out List<BLGoodsCdUMnt> bLGoodsCdUMntList, PMKEN01010E searchCarInfo)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
        public int ExecuteBLGoodsCd(IWin32Window owner, out List<BLGoodsCdUMnt> bLGoodsCdUMntList, PMKEN01010E searchCarInfo, string sectionCode, int customerCode, GoodsAcs.BLGuideMode blGuideMode )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD
        {
            this._goodsAcs.Owner = owner;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 DEL
            //return this._goodsAcs.ExecuteBLGoodsCd(out bLGoodsCdUMntList, searchCarInfo, LoginInfoAcquisition.Employee.BelongSectionCode);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.16 ADD
            return this._goodsAcs.ExecuteBLGoodsCd( out bLGoodsCdUMntList, searchCarInfo, sectionCode, customerCode, blGuideMode );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.16 ADD
        }

        /// <summary>
        /// 品番検索(商品情報一括取得)
        /// </summary>
        /// <param name="goodsCndtnList">商品検索条件オブジェクトリスト</param>
        /// <param name="goodsUnitDataListList">商品連結データオブジェクトリストリスト</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>検索戻り値</returns>
        /// <remarks>
        /// <br>Update Note: 2010/06/08　李占川　見積書印刷時のエラー対応</br>
        /// </remarks>
        public int SearchPartsFromGoodsNoNonVariousSearchWholeWord(List<GoodsCndtn> goodsCndtnList, out List<List<GoodsUnitData>> goodsUnitDataListList, out String msg)
        {
            // --- ADD 2010/06/08 ---------->>>>>
            if (goodsCndtnList == null || goodsCndtnList.Count == 0)
            {
                goodsUnitDataListList = new List<List<GoodsUnitData>>();
                msg = string.Empty;
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }
            else
            {
                return this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out goodsUnitDataListList, out msg);
            }
            //return this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out goodsUnitDataListList, out msg);
            // --- ADD 2010/06/08 ----------<<<<<
        }

        /// <summary>
        /// 品番検索(商品情報一括取得)※結合検索有り
        /// </summary>
        /// <param name="goodsCndtnList">商品検索条件オブジェクトリスト</param>
        /// <param name="partsInfoDataSetList">部品検索データセットリスト</param>
        /// <param name="goodsUnitDataListList">商品連結データオブジェクトリストリスト</param>
        /// <param name="msg">メッセージ</param>
        /// <returns></returns>
        public int SearchPartsFromGoodsNoWholeWord(List<GoodsCndtn> goodsCndtnList, out List<PartsInfoDataSet> partsInfoDataSetList, out List<List<GoodsUnitData>> goodsUnitDataListList, out String msg)
        {
            return this._goodsAcs.SearchPartsFromGoodsNoWholeWord(goodsCndtnList, out partsInfoDataSetList, out goodsUnitDataListList, out msg);
        }

        /// <summary>
        /// 商品連結データの商品価格リストから、対象日の商品価格情報を取得します。
        /// </summary>
        /// <param name="targetDate">対象日付</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>商品価格データ</returns>
        internal GoodsPrice GetGoodsPrice(DateTime targetDate, GoodsUnitData goodsUnitData)
        {
            return this._goodsAcs.GetGoodsPriceFromGoodsPriceList(targetDate, goodsUnitData.GoodsPriceList);
        }

        /// <summary>
        /// 商品情報から指定倉庫の在庫情報を取得します。
        /// </summary>
        /// <param name="goodsUnitData">商品情報オブジェクト</param>
        /// <param name="warehouseCdArray">倉庫配列</param>
        /// <returns>在庫オブジェクト</returns>
        public Stock GetStockFromGoodsUnitData(GoodsUnitData goodsUnitData, string[] warehouseCdArray)
        {
            Stock retStock = null;

            if (( goodsUnitData != null ) && ( goodsUnitData.StockList != null ))
            {
                foreach (string warehouseCode in warehouseCdArray)
                {
                    if (!string.IsNullOrEmpty(warehouseCode.Trim()))
                    {
                        retStock = this._goodsAcs.GetStockFromStockList(warehouseCode, goodsUnitData.GoodsMakerCd, goodsUnitData.GoodsNo, goodsUnitData.StockList);

                        if (retStock != null)
                        {
                            break;
                        }
                    }
                }
            }

            return retStock;
        }

        /// <summary>
        /// BLコードに連結するBLコードマスタ情報、BLグループコード情報、商品中分類情報、商品大分類情報を取得します。
        /// </summary>
        /// <param name="bLGoodsCode">BLコード</param>
        /// <param name="bLGoodsCdUMnt">BLコードマスタ</param>
        /// <param name="bLGroupU">グループコードマスタ</param>
        /// <param name="goodsGroupU">商品中分類マスタ</param>
        /// <param name="userGdBdU">商品大分類マスタ（ユーザーガイド）</param>
        /// <returns>True:取得成功</returns>
        public bool GetBLGoodsRelation(int bLGoodsCode, out BLGoodsCdUMnt bLGoodsCdUMnt, out BLGroupU bLGroupU, out GoodsGroupU goodsGroupU, out UserGdBdU userGdBdU)
        {
            this._goodsAcs.GetBLGoodsRelation(bLGoodsCode, out bLGoodsCdUMnt, out bLGroupU, out goodsGroupU, out userGdBdU);

            return !( ( bLGoodsCdUMnt.BLGoodsCode == 0 ) && ( string.IsNullOrEmpty(bLGoodsCdUMnt.BLGoodsName) ) );
        }

        # endregion


        #region Sort用クラス

        /// <summary>
        /// UOEガイド名称マスタ比較クラス(UOEガイド区分(昇順)、UOE発注先コード(昇順)、UOEガイドコード(昇順))
        /// </summary>
        /// <remarks></remarks>
        public class UOEGuideNameComparer : Comparer<UOEGuideName>
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public override int Compare(UOEGuideName x, UOEGuideName y)
            {
                int result = x.UOEGuideDivCd.CompareTo(y.UOEGuideDivCd);
                if (result != 0) return result;

                result = x.UOESupplierCd.CompareTo(y.UOESupplierCd);
                if (result != 0) return result;

                result = x.UOEGuideCode.CompareTo(y.UOEGuideCode);
                return result;
            }
        }

        /// <summary>
        /// 仕入金額処理区分マスタデータ比較クラス(端数処理対象金額(昇順)、端数処理コード(昇順)、上限金額(昇順))
        /// </summary>
        /// <remarks></remarks>
        internal class StockProcMoneyComparer : Comparer<StockProcMoney>
        {

            public override int Compare(StockProcMoney x, StockProcMoney y)
            {
                int result = x.FracProcMoneyDiv.CompareTo(y.FracProcMoneyDiv);
                if (result != 0) return result;

                result = x.FractionProcCode.CompareTo(y.FractionProcCode);
                if (result != 0) return result;

                result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }

        /// <summary>
        /// 売上金額処理区分マスタデータ比較クラス(端数処理対象金額(昇順)、端数処理コード(昇順)、上限金額(昇順))
        /// </summary>
        /// <remarks></remarks>
        internal class SalesProcMoneyComparer : Comparer<SalesProcMoney>
        {

            public override int Compare(SalesProcMoney x, SalesProcMoney y)
            {
                int result = x.FracProcMoneyDiv.CompareTo(y.FracProcMoneyDiv);
                if (result != 0) return result;

                result = x.FractionProcCode.CompareTo(y.FractionProcCode);
                if (result != 0) return result;

                result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }


        #endregion


        #region ■オプション情報制御処理
        /// <summary>
        /// オプション情報キャッシュ
        /// </summary>
        private void CacheOptionInfo()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;

            #region ●車両管理オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_CarMng);
            this._opt_CarMng = ( ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract );
            #endregion

            #region ●自由検索オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_FreeSearch);
            this._opt_FreeSearch = ( ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract );
            #endregion

            #region ●ＵＯＥオプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_UOE);
            this._opt_UOE = ( ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract );
            #endregion
        }
        #endregion

        #region ■デバッグ用ログ出力
        /// <summary>
		/// ログ出力(DEBUG)処理
		/// </summary>
		/// <param name="pMsg">メッセージ</param>
		public static void LogWrite(string pMsg)
		{
			#if DEBUG
			System.IO.FileStream _fs;										// ファイルストリーム
			System.IO.StreamWriter _sw;										// ストリームwriter
				_fs = new FileStream("PMMIT01010.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
			_sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
			DateTime edt = DateTime.Now;
			//yyyy/MM/dd hh:mm:ss
			_sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2}", edt, edt.Millisecond, pMsg));
			if (_sw != null)
				_sw.Close();
			if (_fs != null)
				_fs.Close();
			#endif
		}
        
        /// <summary>
        /// ログ出力(DEBUG)処理
        /// </summary>
        /// <param name="className"></param>
        /// <param name="methodName"></param>
        /// <param name="pMsg">メッセージ</param>
        public static void LogWrite(string className, string methodName, string pMsg)
        {
#if DEBUG
            try
            {
                System.IO.FileStream _fs;										// ファイルストリーム
                System.IO.StreamWriter _sw;										// ストリームwriter
                _fs = new FileStream("PMMIT01010.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
                _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
                DateTime edt = DateTime.Now;
                //yyyy/MM/dd hh:mm:ss
                _sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2,-40} {3}", edt, edt.Millisecond, className + "." + methodName, pMsg));
                if (_sw != null)
                    _sw.Close();
                if (_fs != null)
                    _fs.Close();
            }
            catch (Exception ex)
            {
            }

#endif
        }
        #endregion

    }
}

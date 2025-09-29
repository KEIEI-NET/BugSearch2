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
//using Broadleaf.Application.LocalAccess;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 仕入入力用初期値取得アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 仕入入力の初期値取得データ制御を行います。</br>
	/// <br>Programmer : 21024　佐々木 健</br>
	/// <br>Date       : 2008.05.21</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.21 men 新規作成</br>
    /// <br>UpdateNote  : 2017/08/11 譚洪  </br>
    /// <br>管理番号    : 11370074-00</br>
    /// <br>              ハンディターミナル在庫仕入登録の対応</br> 
    /// <br>Update Note : 2020/02/24 田建委</br>
    /// <br>管理番号    : 11570208-00</br>
    /// <br>            : PMKOBETSU-2912消費税税率機能追加対応</br>
    /// <br>Update Note: 2021/10/26 譚洪</br>
    /// <br>管理番号   : 11601223-00</br>
    /// <br>           : BLINCIDENT-3114 小文字品番の在庫情報取得不具合の対応</br> 
	/// </remarks>
	public partial class StockSlipInputInitDataAcs
	{
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructor
		/// <summary>
		/// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
		/// </summary>
        private StockSlipInputInitDataAcs()
        {
            _stockProcMoneyList = new List<StockProcMoney>();
            _salesProcMoneyList = new List<SalesProcMoney>();
            _employeeList = new List<Employee>();
            _employeeDtlList = new List<EmployeeDtl>();
            _warehouseList = new List<Warehouse>();
            _makerUMntList = new List<MakerUMnt>();
            _subSectionList = new List<SubSection>();
        }

		/// <summary>
		/// 仕入入力用初期値取得アクセスクラス インスタンス取得処理
		/// </summary>
		/// <returns>仕入入力用初期値取得アクセスクラス インスタンス</returns>
		public static StockSlipInputInitDataAcs GetInstance()
		{
            if (_stockSlipInputInitDataAcs == null)
            {
                _stockSlipInputInitDataAcs = new StockSlipInputInitDataAcs();
            }

			return _stockSlipInputInitDataAcs;
		}
		# endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■Private Members

		private static StockSlipInputInitDataAcs _stockSlipInputInitDataAcs;


		private List<StockProcMoney> _stockProcMoneyList;
        private List<SalesProcMoney> _salesProcMoneyList = null;
        private List<Employee> _employeeList;
        private List<EmployeeDtl> _employeeDtlList;
        private List<Warehouse> _warehouseList;
        private List<MakerUMnt> _makerUMntList;
        private List<SubSection> _subSectionList;
        private SalesTtlSt _salesTtlSt = null;

        private GoodsAcs _goodsAcs;
		private TaxRateSet _taxRateSet;
		private AllDefSet _allDefSet;
		private StockTtlSt _stockTtlSt;
		private StockMngTtlSt _stockMngTtlSt;
        private CompanyInf _companyInf;
        private IWin32Window _owner = null;
        private double _taxRateValue = 0;// ADD 田建委 2020/02/24 PMKOBETSU-2912の対応
        private List<NoteGuidBd> _noteGuidList = null;              // 備考ガイド全件リスト   // ADD 2011/11/30 gezh redmine#8383


		/// <summary>拠点コード(全社共通)</summary>
		private const string ctSectionCode_Common = "00";

        /// <summary> 入力モード</summary>
        private int _inputMode = ctINPUTMODE_GoodsNoNecessary;      // 品番必須モード

		# endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region ■定数

		/// <summary>端数処理対象金額区分（金額）</summary>
        public const int ctFracProcMoneyDiv_Price = 0;
        /// <summary>端数処理対象金額区分（消費税）</summary>
        public const int ctFracProcMoneyDiv_Tax = 1;
        /// <summary>端数処理対象金額区分（単価）</summary>
        public const int ctFracProcMoneyDiv_UnitPrice = 2;
		/// <summary>端数処理対象金額区分（原価単価）</summary>
		public const int ctFracProcMoneyDiv_UnitCost = 3;
		/// <summary>端数処理対象金額区分（原価）</summary>
		public const int ctFracProcMoneyDiv_Cost = 4;

		#endregion 

        // ===================================================================================== //
        // デリゲート
        // ===================================================================================== //
        #region ■delegate

		/// <summary>仕入金額処理区分設定キャッシュデリゲート</summary>
		public delegate void CacheStockProcMoneyListEventHandler( List<StockProcMoney> stockProcMoneyList );

		/// <summary>売上金額処理区分設定キャッシュデリゲート</summary>
		public delegate void CacheSalesProcMoneyListEventHandler( List<SalesProcMoney> salesProcMoneyList );

		#endregion

        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        #region ■Events
		/// <summary>仕入金額処理区分設定セットイベント</summary>
		public event CacheStockProcMoneyListEventHandler CacheStockProcMoneyList;
		/// <summary>売上金額処理区分設定キャッシュイベント</summary>
		public event CacheSalesProcMoneyListEventHandler CacheSalesProcMoneyList;
		#endregion

        // ===================================================================================== //
        // パブリック変数
        // ===================================================================================== //
        # region ■Public Members
		/// <summary>ユーザーガイド区分コード（返品理由）</summary>
		public static readonly int ctDIVCODE_UserGuideDivCd_RetGoodsReason = 91;

        /// <summary>備考ガイド区分コード（備考１）</summary>
        public static readonly int ctDIVCODE_NoteGuid_StockSlipNote1 = 103;
        /// <summary>備考ガイド区分コード（備考２）</summary>
        public static readonly int ctDIVCODE_NoteGuid_StockSlipNote2 = 104;

        /// <summary>品番必須モード</summary>
        public static readonly int ctINPUTMODE_GoodsNoNecessary = 1;

#if DEBUG
		/// <summary>ローカルDB読み込みモード</summary>
		public static readonly bool ctIsLocalDBRead = false;
#else
		/// <summary>ローカルDB読み込みモード</summary>
		public static readonly bool ctIsLocalDBRead = false;
#endif

		# endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        #region ■Properties

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

        /// <summary>オーナーフォーム</summary>
        public IWin32Window Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        // ----- ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 ----->>>>>
        /// <summary>税率設定値</summary>
        public double TaxRateValue
        {
            get { return _taxRateValue; }
            set { _taxRateValue = value; }
        }
        // ----- ADD 田建委 2020/02/24 PMKOBETSU-2912の対応 -----<<<<<

		#endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        # region ■Public Methods

		/// <summary>
		/// 仕入入力で使用する初期データをＤＢより取得します。
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <returns>STATUS</returns>
		public int ReadInitData(string enterpriseCode, string sectionCode)
		{
            LogWrite("StockSlipInputInitDataAcs", "ReadInitData", "開始");

            try
            {
                int status;
                ArrayList aList;  //ADD 2011/11/30 gezh redmine#8383

                #region ●従業員、従業員詳細マスタ
                //-----------------------------------------------------------
                // 従業員、従業員詳細マスタ
                //-----------------------------------------------------------
                LogWrite("StockSlipInputInitDataAcs", "ReadInitData", "全従業員情報を取得");

                EmployeeAcs employeeAcs = new EmployeeAcs();

                ArrayList employeeList;
                ArrayList employeeDtlList;
                status = employeeAcs.Search(out employeeList, out employeeDtlList, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._employeeList = new List<Employee>((Employee[])employeeList.ToArray(typeof(Employee)));
                    this._employeeDtlList = new List<EmployeeDtl>((EmployeeDtl[])employeeDtlList.ToArray(typeof(EmployeeDtl)));
                }
                else
                {
                    this._employeeList = new List<Employee>();
                    this._employeeDtlList = new List<EmployeeDtl>();
                }
                #endregion

   
                #region ●倉庫マスタ
                //-----------------------------------------------------------
                // 倉庫マスタ
                //-----------------------------------------------------------
                LogWrite("StockSlipInputInitDataAcs", "ReadInitData", "倉庫を取得");

                ArrayList returnWarehouse;
                WarehouseAcs warehouseAcs = new WarehouseAcs();

                WarehouseWork paraWarehouse = new WarehouseWork();
                paraWarehouse.EnterpriseCode = enterpriseCode;

                status = warehouseAcs.Search(out returnWarehouse, enterpriseCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._warehouseList = new List<Warehouse>((Warehouse[])returnWarehouse.ToArray(typeof(Warehouse)));
                }
                else
                {
                    this._warehouseList = new List<Warehouse>();
                }
                #endregion

                #region ●仕入全体設定マスタ
                //-----------------------------------------------------------
                // 仕入全体設定マスタ
                //-----------------------------------------------------------
                LogWrite("StockSlipInputInitDataAcs", "ReadInitData", "仕入全体設定を取得");

                StockTtlStAcs stockTtlStAcs = new StockTtlStAcs();
                ArrayList retStockTtlStArrayList;
                status = stockTtlStAcs.Search(out retStockTtlStArrayList, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._stockTtlSt = this.GetStockTtlStFromList(LoginInfoAcquisition.Employee.BelongSectionCode, retStockTtlStArrayList);
                }
                else
                {
                    this._stockTtlSt = null;
                }
                #endregion

                #region ●仕入全体設定マスタ
                //-----------------------------------------------------------
                // 在庫管理全体設定マスタ
                //-----------------------------------------------------------
                LogWrite("StockSlipInputInitDataAcs", "ReadInitData", "在庫管理全体を取得");

                ArrayList retStockMngTtlSt;
                StockMngTtlStAcs stockMngTtlStAcs = new StockMngTtlStAcs();
                status = stockMngTtlStAcs.Search(out retStockMngTtlSt, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._stockMngTtlSt = this.GetStockMngTtlStFromList(LoginInfoAcquisition.Employee.BelongSectionCode, retStockMngTtlSt);
                }
                else
                {
                    this._stockMngTtlSt = null;
                }
                #endregion

                #region ●仕入金額処理区分設定マスタ
                //-----------------------------------------------------------
                // 仕入金額処理区分設定マスタ
                //-----------------------------------------------------------
                LogWrite("StockSlipInputInitDataAcs", "ReadInitData", "仕入金額処理区分設定を取得");

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
                else
                {
                    this._stockProcMoneyList = new List<StockProcMoney>();
                }

                #endregion

                #region ●売上金額処理区分設定マスタ（読み込み無し)
                ////-----------------------------------------------------------
                //// 売上金額処理区分設定マスタ
                ////-----------------------------------------------------------
                //LogWrite("売上金額処理区分設定を取得");
                //SalesProcMoneyAcs salesProcMoneyAcs = new SalesProcMoneyAcs();
                //salesProcMoneyAcs.IsLocalDBRead = StockSlipInputInitDataAcs.ctIsLocalDBRead;

                //ArrayList returnSalesProcMoney;
                //status = salesProcMoneyAcs.Search(out returnSalesProcMoney, enterpriseCode);

                //this._salesProcMoneyList = new List<SalesProcMoney>();

                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    foreach(SalesProcMoney salesProcMoney in returnSalesProcMoney)
                //    {
                //        this._salesProcMoneyList.Add(salesProcMoney);
                //        this.CacheSalesProcMoney(salesProcMoney);
                //    }
                //}
                //this.CacheSalesProcMoneyListCall();
                #endregion

                #region ●全体初期値設定マスタ
                //-----------------------------------------------------------
                // 全体初期値設定マスタ
                //-----------------------------------------------------------
                LogWrite("StockSlipInputInitDataAcs", "ReadInitData", "全体初期値設定を取得");
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
                        this._inputMode = this._allDefSet.GoodsNoInpDiv;
                    }
                }
                else
                {
                    this._allDefSet = null;
                }
                #endregion

                #region ●自社情報設定設定マスタ
                //-----------------------------------------------------------
                // 自社情報設定設定マスタ
                //-----------------------------------------------------------
                LogWrite("StockSlipInputInitDataAcs", "ReadInitData", "自社情報設定設定を取得");
                CompanyInfAcs companyInfAcs = new CompanyInfAcs();
                companyInfAcs.Read(out this._companyInf, enterpriseCode);
                #endregion

                #region ●税率設定マスタ
                //-----------------------------------------------------------
                // 税率設定マスタ
                //-----------------------------------------------------------
                LogWrite("StockSlipInputInitDataAcs", "ReadInitData", "消費税を取得");
                ArrayList returnTaxRateSet;

                TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();

                TaxRateSetAcs.SearchMode taxRateSetSearchMode = ( StockSlipInputInitDataAcs.ctIsLocalDBRead ) ? TaxRateSetAcs.SearchMode.Local : TaxRateSetAcs.SearchMode.Remote;
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

                #region ●部門マスタ
                //-----------------------------------------------------------
                // 部門マスタ
                //-----------------------------------------------------------
                LogWrite("StockSlipInputInitDataAcs", "ReadInitData", "部門を取得");
                SubSectionAcs subSectionAcs = new SubSectionAcs();
                ArrayList returnSubSection;
                status = subSectionAcs.Search(out returnSubSection, enterpriseCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._subSectionList = new List<SubSection>((SubSection[])returnSubSection.ToArray(typeof(SubSection)));
                }
                else
                {
                    this._subSectionList = new List<SubSection>();
                }

                #endregion

                #region ●商品関連

                this._goodsAcs = new GoodsAcs();
                // 読み込みモードの設定
                this._goodsAcs.IsLocalDBRead = StockSlipInputInitDataAcs.ctIsLocalDBRead;

                //-----------------------------------------------------------
                // 商品アクセスクラス初期処理
                //-----------------------------------------------------------
                LogWrite("StockSlipInputInitDataAcs", "ReadInitData2", "商品アクセスクラス初期処理");
                string retMessage;
                this._goodsAcs.SearchInitial(enterpriseCode, sectionCode, out retMessage);

                //-----------------------------------------------------------
                // メーカーマスタ
                //-----------------------------------------------------------
                LogWrite("StockSlipInputInitDataAcs", "ReadInitData2", "メーカーリストを取得");
                status = this._goodsAcs.GetAllMaker(enterpriseCode, out this._makerUMntList);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || this._makerUMntList == null)
                {
                    this._makerUMntList = new List<MakerUMnt>();
                }
                #endregion
                // ADD 2011/11/30 gezh redmine#8383 ---------->>>>>
                #region ●備考ガイドマスタアクセスクラス SFTOK09402A
                LogWrite("備考ガイド全件を取得");
                NoteGuidAcs noteGuidAcs = new NoteGuidAcs();
                noteGuidAcs.IsLocalDBRead = ctIsLocalDBRead;
                status = noteGuidAcs.SearchBody(out aList, enterpriseCode);
                this._noteGuidList = new List<NoteGuidBd>();
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (aList != null) this._noteGuidList = new List<NoteGuidBd>((NoteGuidBd[])aList.ToArray(typeof(NoteGuidBd)));
                }
                #endregion

                // ADD 2011/11/30 gezh redmine#8383 ----------<<<<<
#if false
				//-----------------------------------------------------------
				// 売上全体設定マスタ
				//-----------------------------------------------------------
				LogWrite("売上全体設定を取得");

				ArrayList retSalesTtlSt;
				SalesTtlStAcs salesTtlStAcs = new SalesTtlStAcs();

				status = salesTtlStAcs.SearchAll(out retSalesTtlSt, enterpriseCode);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					this._salesTtlSt = this.GetSalesTtlStFromList(LoginInfoAcquisition.Employee.BelongSectionCode, retSalesTtlSt);
				}

#endif
            }
            finally
            {
            }

            LogWrite("StockSlipInputInitDataAcs", "ReadInitData", "終了");
            return 0;
		}

#if false
        /// <summary>
        /// 初期データをＤＢより取得します。
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public int ReadInitData2(string enterpriseCode, string sectionCode)
        {
            try
            {
                #region ●部門マスタ
                //-----------------------------------------------------------
                // 部門マスタ
                //-----------------------------------------------------------
                LogWrite("StockSlipInputInitDataAcs", "ReadInitData", "部門を取得");
                SubSectionAcs subSectionAcs = new SubSectionAcs();
                ArrayList returnSubSection;
                int status = subSectionAcs.Search(out returnSubSection, enterpriseCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._subSectionList = new List<SubSection>((SubSection[])returnSubSection.ToArray(typeof(SubSection)));
                }
                else
                {
                    this._subSectionList = new List<SubSection>();
                }

                #endregion

                #region ●商品関連

                this._goodsAcs = new GoodsAcs();
                // 読み込みモードの設定
                this._goodsAcs.IsLocalDBRead = StockSlipInputInitDataAcs.ctIsLocalDBRead;

                //-----------------------------------------------------------
                // 商品アクセスクラス初期処理
                //-----------------------------------------------------------
                LogWrite("StockSlipInputInitDataAcs", "ReadInitData2", "商品アクセスクラス初期処理");
                string retMessage;
                this._goodsAcs.SearchInitial(enterpriseCode, sectionCode, out retMessage);

                //-----------------------------------------------------------
                // メーカーマスタ
                //-----------------------------------------------------------
                LogWrite("StockSlipInputInitDataAcs", "ReadInitData2", "メーカーリストを取得");
                status = this._goodsAcs.GetAllMaker(enterpriseCode, out this._makerUMntList);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || this._makerUMntList == null)
                {
                    this._makerUMntList = new List<MakerUMnt>();
                }
                #endregion
            }
            finally
            {
            }

            return 0;
        }
#endif

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
                msg = "税率設定マスタの登録を行って下さい。";
			}
			else if (this.GetAllDefSet() == null)
			{
                msg = "全体初期値設定マスタの登録を行って下さい。";
			}
			else if (this.GetStockMngTtlSt() == null)
			{
                msg = "在庫管理全体設定マスタの登録を行って下さい。";
			}
			else if (this.GetStockMngTtlSt() == null)
			{
                msg = "仕入在庫全体設定マスタの登録を行って下さい。";
			}
#if false
			else if (this.GetSalesTtlSt() == null)
			{
				msg = "売上全体設定マスタの登録を行って下さい。";
			}
#endif

            return msg == "";
		}

		# endregion

        // ===================================================================================== //
        // 各種マスタ制御
        // ===================================================================================== //
        #region ■各種マスタ制御

        # region ■従業員マスタキャッシュ制御処理
        
		/// <summary>
		/// 従業員コードマスタ存在チェック
		/// </summary>
		/// <param name="employeeCode"></param>
		/// <returns></returns>
		public bool CodeExist_Employee( string employeeCode )
		{
            return ( this.GetEmployeeFromCache(employeeCode) != null );
		}

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

        //ADD 2011/11/30 gezh redmine#8383 ---------->>>>>
        # region ■指定備考情報制御処理
        /// <summary>
        /// 備考ガイド名称取得処理
        /// </summary>
        /// <param name="noteGuideDivCode">備考ガイド区分</param>
        /// <param name="noteGuideCode">備考ガイドコード</param>
        /// <param name="noteGuideName">備考ガイド名称</param>
        /// <returns>status</returns>
        /// <remarks>
        /// </remarks>
        public int GetName_NoteGuidBd(int noteGuideDivCode, int noteGuideCode, out string noteGuideName)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            noteGuideName = string.Empty;

            NoteGuidBd noteGuidBd = this._noteGuidList.Find(
                delegate(NoteGuidBd noteGuid)
                {
                    return (noteGuid.NoteGuideDivCode == noteGuideDivCode && noteGuid.NoteGuideCode == noteGuideCode) ? true : false;
                }
            );

            if (noteGuidBd != null)
            {
                noteGuideName = noteGuidBd.NoteGuideName;
            }
            else
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return status;
        }

        # endregion
        //ADD 2011/11/30 gezh redmine#8383 ----------<<<<<
		# region ■部門マスタキャッシュ制御処理
        /// <summary>
        /// 部門名称取得処理
        /// </summary>
        /// <param name="subSectionCode">部門コード</param>
        /// <returns>部門名称</returns>
        public string GetName_FromSubSection(int subSectionCode)
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

		# region ■仕入在庫全体設定マスタキャッシュ制御処理

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
		
		# endregion

		# region ■全体初期値設定マスタキャッシュ制御処理

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


		/// <summary>
		/// 全体初期値設定マスタ検索処理
		/// </summary>
		/// <returns>全体初期値設定マスタオブジェクト</returns>
		public AllDefSet GetAllDefSet()
		{
			return this._allDefSet;
		}

		# endregion

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

		# region ■在庫管理全体設定マスタキャッシュ制御処理

		/// <summary>
		/// 在庫管理全体設定マスタのリスト中から、指定した拠点の設定を取得します。
		/// </summary>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="stockMngTtlStArrayList">在庫管理全体設定マスタオブジェクトリスト</param>
		/// <returns>在庫管理全体設定マスタオブジェクト</returns>
		private StockMngTtlSt GetStockMngTtlStFromList( string sectionCode, ArrayList stockMngTtlStArrayList )
		{
			StockMngTtlSt allSecStockMngTtlSt = null;

			foreach (StockMngTtlSt stockMngTtlSt in stockMngTtlStArrayList)
			{
				if (stockMngTtlSt.SectionCode.Trim() == sectionCode.Trim())
				{
					return stockMngTtlSt;
				}
				else if (stockMngTtlSt.SectionCode.Trim() == ctSectionCode_Common.Trim())
				{
                    allSecStockMngTtlSt = stockMngTtlSt;
				}
			}

			return allSecStockMngTtlSt;
		}

		/// <summary>
		/// 在庫管理全体設定マスタキャッシュ処理
		/// </summary>
		/// <param name="stockMngTtlSt">在庫管理全体設定マスタオブジェクト</param>
		internal void CacheStockMngTtlSt(StockMngTtlSt stockMngTtlSt)
		{
			this._stockMngTtlSt = stockMngTtlSt;
		}

		/// <summary>
		/// 在庫管理全体設定マスタ検索処理
		/// </summary>
		/// <returns>在庫管理全体設定マスタオブジェクト</returns>
		public StockMngTtlSt GetStockMngTtlSt()
		{
			return this._stockMngTtlSt;
		}
		# endregion

		# region ■商品関連処理
		/// <summary>
		/// 商品データリスト生成処理
		/// </summary>
        /// <param name="goodsCndtnList">商品検索条件リスト</param>
        /// <param name="goodsUnitDataList">商品リスト</param>
        /// <param name="message">拠点コード</param>
        /// <returns>検索ステータス(ConstantManagement.MethodResult)</returns>
        public int GetGoodsUnitDataList( List<GoodsCndtn> goodsCndtnList, out List<GoodsUnitData> goodsUnitDataList, out string message )
        {
            message = string.Empty;

            goodsUnitDataList = new List<GoodsUnitData>();

            List<List<GoodsUnitData>> goodsUnitDataListRet;

            int status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out goodsUnitDataListRet, out message);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {

                foreach (GoodsCndtn goodsCndtn in goodsCndtnList)
                {
                    foreach (List<GoodsUnitData> goodsUnitDataListWk in goodsUnitDataListRet)
                    {
                        bool findGoods = false;
                        foreach (GoodsUnitData goodsUnitData in goodsUnitDataListWk)
                        {
                            if (( goodsCndtn.GoodsNo == goodsUnitData.GoodsNo ) &&
                                ( goodsCndtn.GoodsMakerCd == goodsUnitData.GoodsMakerCd ))
                            {
                                goodsUnitDataList.Add(goodsUnitData);
                                findGoods = true;
                                break;
                            }
                        }
                        if (findGoods) break;
                    }
                }
            }
            return status;
        }

		/// <summary>
		/// 指定した商品コードを元に商品情報を取得します。
		/// </summary>
        /// <param name="goodsCndtn">商品検索条件</param>
        /// <param name="goodsUnitData">商品情報オブジェクト（out）</param>
        /// <param name="message">メッセージ(out)</param>
        /// <returns>STATUS</returns>
        public int GetGoodsUnitData(GoodsCndtn goodsCndtn, out GoodsUnitData goodsUnitData, out string message)
        {

            List<GoodsUnitData> goodsUnitDataList;

            this._goodsAcs.Owner = this._owner;

            int status = _goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out message);

            if (( goodsUnitDataList != null ) && ( goodsUnitDataList.Count > 0 ))
            {
                goodsUnitData = goodsUnitDataList[0];
            }
            else
            {
                goodsUnitData = null;
            }
            return status;
        }

        //--- ADD 譚洪 2021/10/26 BLINCIDENT-3114 小文字品番の在庫情報取得不具合の対応 ----->>>>>
        /// <summary>
        /// 指定した商品コード+メーカーコードを元にユーザー分商品情報を取得します。
        /// </summary>
        /// <param name="goodsCndtn">商品検索条件</param>
        /// <param name="goodsUnitData">商品情報オブジェクト</param>
        /// <param name="goodsUnitDataCk">商品情報オブジェクト(out)</param>
        /// <returns>STATUS</returns>        /// 
        /// <remarks>
        /// <br>Note       : 2021/10/26 譚洪</br>
        /// <br>管理番号   : 11601223-00</br>
        /// <br>           : BLINCIDENT-3114 小文字品番の在庫情報取得不具合の対応</br> 
        /// </remarks>
        public int ReadGoodsUnitData(GoodsCndtn goodsCndtn, GoodsUnitData goodsUnitData, out GoodsUnitData goodsUnitDataCk)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            status = _goodsAcs.Read(goodsCndtn.EnterpriseCode, goodsCndtn.SectionCode, goodsUnitData.GoodsMakerCd, goodsUnitData.GoodsNo, out goodsUnitDataCk);

            return status;
        }
        //--- ADD 譚洪 2021/10/26 BLINCIDENT-3114 小文字品番の在庫情報取得不具合の対応 -----<<<<<

        /// <summary>
        /// 商品連結データの商品価格リストから、対象日の商品価格情報を取得します。
        /// </summary>
        /// <param name="targetDate">対象日付</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>商品価格データ</returns>
        internal GoodsPrice GetGoodsPrice( DateTime targetDate, GoodsUnitData goodsUnitData )
        {
            return this._goodsAcs.GetGoodsPriceFromGoodsPriceList(targetDate, goodsUnitData.GoodsPriceList);
        }

        /// <summary>
        /// 商品情報から指定倉庫の在庫情報を取得します。
        /// </summary>
        /// <param name="goodsUnitData">商品情報オブジェクト</param>
        /// <param name="warehouseCdArray">倉庫配列</param>
        /// <returns>在庫オブジェクト</returns>
        public Stock GetStockFromGoodsUnitData( GoodsUnitData goodsUnitData, string[] warehouseCdArray )
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

        // 2009.04.03 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 在庫リストより在庫情報取得
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <returns></returns>
        public Stock GetStock(GoodsUnitData goodsUnitData, string warehouseCode)
        {
            if ((goodsUnitData != null) &&
                (goodsUnitData.StockList != null))
            {
                Stock retStock = new Stock();
                retStock = this._goodsAcs.GetStockFromStockList(warehouseCode, goodsUnitData.GoodsMakerCd, goodsUnitData.GoodsNo, goodsUnitData.StockList);
                if (retStock != null) return retStock;
            }
            return null;
        }
        // 2009.04.03 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		/// <summary>
		/// JANコードにて商品情報を取得します。
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="jan">JANコード</param>
        /// <param name="goodsUnitData">商品情報クラス</param>
		/// <returns>STATUS</returns>
		public int ReadGoodsFromJan( string enterpriseCode, string sectionCode, string jan, out GoodsUnitData goodsUnitData )
		{
			return this._goodsAcs.ReadJan(enterpriseCode, sectionCode, jan, out goodsUnitData);
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
        public bool GetBLGoodsRelation( int bLGoodsCode, out BLGoodsCdUMnt bLGoodsCdUMnt, out BLGroupU bLGroupU, out GoodsGroupU goodsGroupU, out UserGdBdU userGdBdU )
        {
            this._goodsAcs.GetBLGoodsRelation(bLGoodsCode, out bLGoodsCdUMnt, out bLGroupU, out goodsGroupU, out userGdBdU);

            return !( ( bLGoodsCdUMnt.BLGoodsCode == 0 ) && ( string.IsNullOrEmpty(bLGoodsCdUMnt.BLGoodsName) ) );
        }

		# endregion

		# region ■メーカーマスタキャッシュ制御処理
        /// <summary>
        /// メーカー名称取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="makerName">メーカー名称</param>
        /// <param name="makerKanaName">メーカー名称カナ</param>
        public bool GetName_FromMaker(int makerCode, out string makerName, out string makerKanaName)
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

        /// <summary>
        /// キャッシュイベントのコール
        /// </summary>
        public void CacheEventCall()
        {
            this.CacheStockProcMoneyListCall();
            this.CacheSalesProcMoneyListCall();
        }

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

        #region ソート用のクラス

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


        #endregion

        #endregion

        /// <summary>
		/// ログ出力(DEBUG)処理
		/// </summary>
		/// <param name="pMsg">メッセージ</param>
		public static void LogWrite(string pMsg)
		{
#if DEBUG
            try
            {
                System.IO.FileStream _fs;										// ファイルストリーム
                System.IO.StreamWriter _sw;										// ストリームwriter
                _fs = new FileStream("MAKON01101.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
                _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
                DateTime edt = DateTime.Now;
                //yyyy/MM/dd hh:mm:ss
                _sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2}", edt, edt.Millisecond, pMsg));
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
                _fs = new FileStream("MAKON01101.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
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

        // ------ ADD 2017/08/11 譚洪 ハンディターミナル二次開発 --------- >>>>
        #region ▼ハンディターミナル在庫仕入登録の対応
        // ===================================================================================== //
        // コンストラクタ（ハンディターミナル用）
        // ===================================================================================== //
        # region ■Constracter
        /// <summary>
        /// コンストラクタ（ハンディターミナル用）
        /// </summary>
        /// <param name="status">初期化ステータス「0：成功  0以外：失敗」</param>
        /// <remarks>
        /// <br>Note       : クラスの新しいインスタンスを初期化します。（ハンディターミナル用）</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public StockSlipInputInitDataAcs(out int status)
        {
            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                _stockProcMoneyList = new List<StockProcMoney>();
                _salesProcMoneyList = new List<SalesProcMoney>();
                _employeeList = new List<Employee>();
                _employeeDtlList = new List<EmployeeDtl>();
                _warehouseList = new List<Warehouse>();
                _makerUMntList = new List<MakerUMnt>();
                _subSectionList = new List<SubSection>();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
        }
        #endregion

        /// <summary>
        /// 仕入入力で使用する初期データをＤＢより取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>STATUS</returns>
        public int ReadInitDataForHandy(string enterpriseCode, string sectionCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList aList;

                #region ●従業員、従業員詳細マスタ
                //-----------------------------------------------------------
                // 従業員、従業員詳細マスタ
                //-----------------------------------------------------------
                EmployeeAcs employeeAcs = new EmployeeAcs();

                ArrayList employeeList;
                ArrayList employeeDtlList;
                status = employeeAcs.Search(out employeeList, out employeeDtlList, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._employeeList = new List<Employee>((Employee[])employeeList.ToArray(typeof(Employee)));
                    this._employeeDtlList = new List<EmployeeDtl>((EmployeeDtl[])employeeDtlList.ToArray(typeof(EmployeeDtl)));
                }
                else
                {
                    this._employeeList = new List<Employee>();
                    this._employeeDtlList = new List<EmployeeDtl>();
                }
                #endregion


                #region ●倉庫マスタ
                //-----------------------------------------------------------
                // 倉庫マスタ
                //-----------------------------------------------------------
                ArrayList returnWarehouse;
                WarehouseAcs warehouseAcs = new WarehouseAcs();

                WarehouseWork paraWarehouse = new WarehouseWork();
                paraWarehouse.EnterpriseCode = enterpriseCode;

                status = warehouseAcs.Search(out returnWarehouse, enterpriseCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._warehouseList = new List<Warehouse>((Warehouse[])returnWarehouse.ToArray(typeof(Warehouse)));
                }
                else
                {
                    this._warehouseList = new List<Warehouse>();
                }
                #endregion

                #region ●仕入全体設定マスタ
                //-----------------------------------------------------------
                // 仕入全体設定マスタ
                //-----------------------------------------------------------
                StockTtlStAcs stockTtlStAcs = new StockTtlStAcs();
                ArrayList retStockTtlStArrayList;
                status = stockTtlStAcs.Search(out retStockTtlStArrayList, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._stockTtlSt = this.GetStockTtlStFromList(sectionCode, retStockTtlStArrayList);
                }
                else
                {
                    this._stockTtlSt = null;
                }
                #endregion

                #region ●仕入全体設定マスタ
                //-----------------------------------------------------------
                // 在庫管理全体設定マスタ
                //-----------------------------------------------------------
                ArrayList retStockMngTtlSt;
                StockMngTtlStAcs stockMngTtlStAcs = new StockMngTtlStAcs();
                status = stockMngTtlStAcs.Search(out retStockMngTtlSt, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._stockMngTtlSt = this.GetStockMngTtlStFromList(sectionCode, retStockMngTtlSt);
                }
                else
                {
                    this._stockMngTtlSt = null;
                }
                #endregion

                #region ●仕入金額処理区分設定マスタ
                //-----------------------------------------------------------
                // 仕入金額処理区分設定マスタ
                //-----------------------------------------------------------
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
                else
                {
                    this._stockProcMoneyList = new List<StockProcMoney>();
                }

                #endregion

                #region ●全体初期値設定マスタ
                //-----------------------------------------------------------
                // 全体初期値設定マスタ
                //-----------------------------------------------------------
                AllDefSetAcs allDefSetAcs = new AllDefSetAcs();
                AllDefSetAcs.SearchMode allDefSetSearchMode = AllDefSetAcs.SearchMode.Remote;
                ArrayList retAllDefSetList;
                status = allDefSetAcs.Search(out retAllDefSetList, enterpriseCode, allDefSetSearchMode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ログイン担当者の所属拠点もしくは全社設定を取得
                    this._allDefSet = this.GetAllDefSetFromList(sectionCode, retAllDefSetList);

                    if (this._allDefSet != null)
                    {
                        this._inputMode = this._allDefSet.GoodsNoInpDiv;
                    }
                }
                else
                {
                    this._allDefSet = null;
                }
                #endregion

                #region ●自社情報設定設定マスタ
                //-----------------------------------------------------------
                // 自社情報設定設定マスタ
                //-----------------------------------------------------------
                CompanyInfAcs companyInfAcs = new CompanyInfAcs();
                companyInfAcs.Read(out this._companyInf, enterpriseCode);
                #endregion

                #region ●税率設定マスタ
                //-----------------------------------------------------------
                // 税率設定マスタ
                //-----------------------------------------------------------
                ArrayList returnTaxRateSet;

                TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();

                TaxRateSetAcs.SearchMode taxRateSetSearchMode = (StockSlipInputInitDataAcs.ctIsLocalDBRead) ? TaxRateSetAcs.SearchMode.Local : TaxRateSetAcs.SearchMode.Remote;
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

                #region ●部門マスタ
                //-----------------------------------------------------------
                // 部門マスタ
                //-----------------------------------------------------------
                SubSectionAcs subSectionAcs = new SubSectionAcs();
                ArrayList returnSubSection;
                status = subSectionAcs.Search(out returnSubSection, enterpriseCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._subSectionList = new List<SubSection>((SubSection[])returnSubSection.ToArray(typeof(SubSection)));
                }
                else
                {
                    this._subSectionList = new List<SubSection>();
                }

                #endregion

                #region ●商品関連

                this._goodsAcs = new GoodsAcs();
                // 読み込みモードの設定
                this._goodsAcs.IsLocalDBRead = StockSlipInputInitDataAcs.ctIsLocalDBRead;

                //-----------------------------------------------------------
                // 商品アクセスクラス初期処理
                //-----------------------------------------------------------
                string retMessage;
                this._goodsAcs.SearchInitial(enterpriseCode, sectionCode, out retMessage);

                //-----------------------------------------------------------
                // メーカーマスタ
                //-----------------------------------------------------------
                status = this._goodsAcs.GetAllMaker(enterpriseCode, out this._makerUMntList);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || this._makerUMntList == null)
                {
                    this._makerUMntList = new List<MakerUMnt>();
                }
                #endregion

                #region ●備考ガイドマスタアクセスクラス SFTOK09402A
                NoteGuidAcs noteGuidAcs = new NoteGuidAcs();
                noteGuidAcs.IsLocalDBRead = ctIsLocalDBRead;
                status = noteGuidAcs.SearchBody(out aList, enterpriseCode);
                this._noteGuidList = new List<NoteGuidBd>();
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (aList != null) this._noteGuidList = new List<NoteGuidBd>((NoteGuidBd[])aList.ToArray(typeof(NoteGuidBd)));
                }
                #endregion

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion
        // ------ ADD 2017/08/11 譚洪 ハンディターミナル二次開発 --------- <<<<
	}
}

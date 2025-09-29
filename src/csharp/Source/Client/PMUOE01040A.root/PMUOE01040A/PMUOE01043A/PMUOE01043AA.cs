//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送受信ＪＮＬアクセスクラス
// プログラム概要   : ＵＯＥ送受信ＪＮＬアクセスを行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
//           2009/05/25  修正内容 : 96186 立花 裕輔 ホンダ UOE WEB対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI佐々木 貴英
// 作 成 日  2012/10/03  修正内容 : 仕入先が優良の場合の受信エラーが
//                                  送信エラーとして処理される不具合対応
//----------------------------------------------------------------------------//
// 管理番号  10902931-00 作成担当 : 譚洪
// 作 成 日  2013/08/15  修正内容 : 発注処理(自動)処理の追加
//----------------------------------------------------------------------------//
// 管理番号  10902931-00 作成担当 : 譚洪
// 作 成 日  2014/03/24  修正内容 : 複数拠点の発注情報再取得の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.Threading;
using Broadleaf.Application.Remoting.ParamData;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ＵＯＥ送受信ＪＮＬアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ送信編集アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
    /// <br>Update Note  : 2009/05/25 96186 立花 裕輔</br>
    /// <br>              ・ホンダ UOE WEB対応</br>
    /// <br></br>
    /// <br>Update Note  : 2012/10/03 FSI佐々木 貴英</br>
    /// <br>              ・仕入先が優良の場合の受信エラーが</br>
    /// <br>                送信エラーとして処理される不具合対応</br>
    /// </remarks>
	public partial class UoeSndRcvJnlAcs
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructors
		public UoeSndRcvJnlAcs()
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			//企業コードを取得する
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ---- ADD 2013/08/15 譚洪 ---- >>>>>
            //OPT-CPM0110：フタバUOEオプション（個別）
            fuTaBaPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaUOECtl);
            if (fuTaBaPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_FuTaBa = (int)Option.ON;
            }
            else
            {
                this._opt_FuTaBa = (int)Option.OFF;
            }

             //フタバUSB専用
            if (this._opt_FuTaBa == (int)Option.ON)
            {
                sectionSolt = Thread.GetNamedDataSlot(SECTIONSOLT);
                //Threadで、拠点がある場合、Threadの拠点を使用
                if (Thread.GetData(sectionSolt) != null)
                {
                    this._sectionCode = ((string)Thread.GetData(Thread.GetNamedDataSlot(SECTIONSOLT))).Trim();
                }
                else
                {
                    this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
                }
            }
            else
            {
			    this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            }
            // ---- ADD 2013/08/15 譚洪 ---- <<<<<

            //this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;// DEL 2013/08/15 譚洪

			//売上全体設定マスタを取得
			this._salesTtlStAcs = new SalesTtlStAcs();
			_salesTtlSt = new SalesTtlSt();
			SalesTtlSt returnSalesTtlSt = new SalesTtlSt();

            status = this._salesTtlStAcs.Read(out returnSalesTtlSt, _enterpriseCode, _sectionCode);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				_salesTtlSt = returnSalesTtlSt;
			}
            // 全社読み込み
            else
            {
                status = this._salesTtlStAcs.Read(out returnSalesTtlSt, _enterpriseCode, "00");
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    _salesTtlSt = returnSalesTtlSt;
                }
            }

			//発注先マスタの取得
			GetUOESupplier();

			//UOE自社設定マスタを取得
			this._uOESettingAcs = new UOESettingAcs();
			_uOESetting = new UOESetting();
			UOESetting returnUOESetting = new UOESetting();
            status = this._uOESettingAcs.Read(out returnUOESetting, _enterpriseCode, _sectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                _uOESetting = returnUOESetting;
            }

			//端末管理設定の取得
			this._posTerminalMgAcs = new PosTerminalMgAcs();
			status = this._posTerminalMgAcs.GetCashRegisterNo(out _cashRegisterNo, _enterpriseCode);
			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				_cashRegisterNo = 0;
			}

            // 2009/05/25 START >>>>>>
            //-----------------------------------------------------------
            //拠点情報取得
            //-----------------------------------------------------------
            this._secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet returnSecInfoSet = new SecInfoSet();
            status = this._secInfoSetAcs.Read(out returnSecInfoSet, _enterpriseCode, _sectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                _secInfoSet = returnSecInfoSet;
            }
            // 2009/05/25 END   <<<<<<


			//商品マスタ アクセスクラス＜初期値データ取得＞
			this._goodsAcs = new GoodsAcs();
			string msg = "";
			_goodsAcs.SearchInitial(_enterpriseCode, _sectionCode, out msg);

			//DataSet初期化
			_uoeJnlDataSet = new DataSet();

			//データーテーブルの初期化
			SchemaClear();
		}

        // ------------- ADD 譚洪 2014/03/24 -------- >>>>>>>>
        /// <summary>
        /// たくさん拠点の場合、新拠点の場合、キャッシュー情報を再取得する
        /// </summary>
        /// <returns></returns>
        public void UoeSndRcvJnlAcsForMoreSection()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            //企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ---- ADD 2013/08/15 譚洪 ---- >>>>>
            //OPT-CPM0110：フタバUOEオプション（個別）
            fuTaBaPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaUOECtl);
            if (fuTaBaPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_FuTaBa = (int)Option.ON;
            }
            else
            {
                this._opt_FuTaBa = (int)Option.OFF;
            }

            //フタバUSB専用
            if (this._opt_FuTaBa == (int)Option.ON)
            {
                sectionSolt = Thread.GetNamedDataSlot(SECTIONSOLT);
                //Threadで、拠点がある場合、Threadの拠点を使用
                if (Thread.GetData(sectionSolt) != null)
                {
                    this._sectionCode = ((string)Thread.GetData(Thread.GetNamedDataSlot(SECTIONSOLT))).Trim();
                }
                else
                {
                    this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
                }
            }
            else
            {
                this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            }
            // ---- ADD 2013/08/15 譚洪 ---- <<<<<

            //this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;// DEL 2013/08/15 譚洪

            //売上全体設定マスタを取得
            this._salesTtlStAcs = new SalesTtlStAcs();
            _salesTtlSt = new SalesTtlSt();
            SalesTtlSt returnSalesTtlSt = new SalesTtlSt();

            status = this._salesTtlStAcs.Read(out returnSalesTtlSt, _enterpriseCode, _sectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                _salesTtlSt = returnSalesTtlSt;
            }
            // 全社読み込み
            else
            {
                status = this._salesTtlStAcs.Read(out returnSalesTtlSt, _enterpriseCode, "00");
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    _salesTtlSt = returnSalesTtlSt;
                }
            }

            //発注先マスタの取得
            GetUOESupplierForMoreSection();

            //UOE自社設定マスタを取得
            this._uOESettingAcs = new UOESettingAcs();
            _uOESetting = new UOESetting();
            UOESetting returnUOESetting = new UOESetting();
            status = this._uOESettingAcs.Read(out returnUOESetting, _enterpriseCode, _sectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                _uOESetting = returnUOESetting;
            }

            //端末管理設定の取得
            this._posTerminalMgAcs = new PosTerminalMgAcs();
            status = this._posTerminalMgAcs.GetCashRegisterNo(out _cashRegisterNo, _enterpriseCode);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                _cashRegisterNo = 0;
            }

            // 2009/05/25 START >>>>>>
            //-----------------------------------------------------------
            //拠点情報取得
            //-----------------------------------------------------------
            this._secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet returnSecInfoSet = new SecInfoSet();
            status = this._secInfoSetAcs.Read(out returnSecInfoSet, _enterpriseCode, _sectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                _secInfoSet = returnSecInfoSet;
            }
            // 2009/05/25 END   <<<<<<


            //商品マスタ アクセスクラス＜初期値データ取得＞
            this._goodsAcs = new GoodsAcs();
            string msg = "";
            _goodsAcs.SearchInitial(_enterpriseCode, _sectionCode, out msg);

            //DataSet初期化
            _uoeJnlDataSet = new DataSet();

            //データーテーブルの初期化
            SchemaClear();
        }
        // ------------- ADD 譚洪 2014/03/24 -------- <<<<<<<<<<

		/// <summary>
		/// アクセスクラス インスタンス取得処理
		/// </summary>
		/// <returns></returns>
		public static UoeSndRcvJnlAcs GetInstance()
		{
			if (_uoeSndRcvJnlAcs == null)
			{
				_uoeSndRcvJnlAcs = new UoeSndRcvJnlAcs();
			}
			return _uoeSndRcvJnlAcs;
		}
		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members

        // ---- ADD 2013/08/15 譚洪 ---- >>>>>
        //拠点コード
        private const string SECTIONSOLT = "SECTIONSOLT";
        private LocalDataStoreSlot sectionSolt = null;

        #region ■列挙体
        /// <summary>
        /// オプション有効有無
        /// </summary>
        public enum Option : int
        {
            /// <summary>無効ユーザ</summary>
            OFF = 0,
            /// <summary>有効ユーザ</summary>
            ON = 1,
        }
        #endregion

        /// <summary>テキスト出力オプション情報</summary>
        private int _opt_FuTaBa;//OPT-CPM0110：フタバUOEオプション（個別）

        //専用USB用
        Broadleaf.Application.Remoting.ParamData.PurchaseStatus fuTaBaPs;
        // ---- ADD 2013/08/15 譚洪 ---- <<<<<

		//企業コード
		private string _enterpriseCode = "";

		//拠点コード
		public string _sectionCode = "";
		
		//アクセスクラス インスタンス
		private static UoeSndRcvJnlAcs _uoeSndRcvJnlAcs = null;

		//発注先マスタアクセスクラス
        private UOESupplierAcs _uOESupplierAcs = new UOESupplierAcs();

		// UOE自社設定マスタ アクセスクラス
		private UOESettingAcs _uOESettingAcs = null;

		//売上全体設定マスタ アクセスクラス
		private SalesTtlStAcs _salesTtlStAcs = null;

		// 端末管理設定 アクセスクラス
		private PosTerminalMgAcs _posTerminalMgAcs = null;

		// 商品マスタ アクセスクラス
		private GoodsAcs _goodsAcs = null;

		//発注先Dictionary＜検索用＞
		private static Dictionary<Int32, UOESupplier> _uoeOrderSearchDictionary;

        //発注先可能メーカーDictionary＜検索用＞
        private static Dictionary<String, String> _uoeOrderMakerSearchDictionary;

		//操作履歴ログデータリスト
		private List<OprtnHisLog> _oprtnHisLogList = new List<OprtnHisLog>();

		//UOE自社設定マスタ
		private UOESetting _uOESetting = null;

		//売上全体設定マスタ
		private SalesTtlSt _salesTtlSt = null;

		//自端末コード
		private int _cashRegisterNo = 0;

		//ＵＯＥＪＮＬデータセット
		private DataSet _uoeJnlDataSet = new DataSet();

        // 2009/05/25 START >>>>>>
        // 拠点設定 アクセスクラス
        private SecInfoSetAcs _secInfoSetAcs = null;
        //拠点設定マスタ
        private SecInfoSet _secInfoSet = null;
        // 2009/05/25 END   <<<<<<
		# endregion

		// ===================================================================================== //
		// 定数
		// ===================================================================================== //
		# region Const Members
		# endregion

		// ===================================================================================== //
		// デリゲート
		// ===================================================================================== //
		# region Delegate
		# endregion

		// ===================================================================================== //
		// イベント
		// ===================================================================================== //
		# region Event
		# endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Properties
        # region UOE発注先マスタアクセスクラス
        /// <summary>
        /// UOE発注先マスタアクセスクラス
        /// </summary>
        public UOESupplierAcs uOESupplierAcs
        {
            get { return _uOESupplierAcs; }
        }
		# endregion

		# region UOE自社設定マスタ
		/// <summary>
		/// UOE自社設定マスタ
		/// </summary>
		public UOESetting uOESetting
		{
			get { return _uOESetting; }
			set { _uOESetting = value; }
		}
		# endregion

		# region 売上全体設定マスタ
		/// <summary>
		/// 売上全体設定マスタ
		/// </summary>
		public SalesTtlSt salesTtlSt
		{
			get { return _salesTtlSt; }
			set { _salesTtlSt = value; }
		}
		# endregion

		# region 商品マスタ アクセスクラス
		/// <summary>
		/// 商品マスタ アクセスクラス
		/// </summary>
		public GoodsAcs goodsAcs
		{
			get { return this._goodsAcs; }
			set { this._goodsAcs = value; }
		}
		# endregion

		# region 自端末コード
		/// <summary>
		/// 自端末コード
		/// </summary>
		public int cashRegisterNo
		{
			get { return _cashRegisterNo; }
			set { _cashRegisterNo = value; }
		}
		# endregion

		# region 発注先マスタ
		/// <summary>
		/// 発注先マスタ
		/// </summary>
		public Dictionary<Int32, UOESupplier> uoeOrderSearchDictionary
		{
			get { return _uoeOrderSearchDictionary; }
			set { _uoeOrderSearchDictionary = value; }
		}
		# endregion

        # region 発注先可能メーカー
        /// <summary>
        /// 発注先可能メーカー
        /// </summary>
        public Dictionary<String, String> uoeOrderMakerSearchDictionary
        {
            get { return _uoeOrderMakerSearchDictionary; }
            set { _uoeOrderMakerSearchDictionary = value; }
        }
        # endregion

		# region ＜DataSet＞
		/// <summary>
		/// ＜DataSet＞
		/// </summary>
		public DataSet UoeJnlDataSet
		{
			get { return this._uoeJnlDataSet; }
		}
		# endregion

		# region ＜DataTable＞
		# region 発注＜DataTable＞
		/// <summary>
		/// 発注＜DataTable＞
		/// </summary>
		public DataTable OrderTable
		{
			get { return this._uoeJnlDataSet.Tables[OrderSndRcvJnlSchema.CT_OrderSndRcvJnlDataTable]; }
		}
		# endregion

		# region 見積＜DataTable＞
		/// <summary>
		/// 見積＜DataTable＞
		/// </summary>
		public DataTable EstmtTable
		{
			get { return this._uoeJnlDataSet.Tables[EstmtSndRcvJnlSchema.CT_EstmtSndRcvJnlDataTable]; }
		}
		# endregion

		# region 在庫＜DataTable＞
		/// <summary>
		/// 在庫＜DataTable＞
		/// </summary>
		public DataTable StockTable
		{
			get { return this._uoeJnlDataSet.Tables[StockSndRcvJnlSchema.CT_StockSndRcvJnlDataTable]; }
		}
		# endregion

        # region UOE発注＜DataTable＞
        /// <summary>
        /// UOE発注＜DataTable＞
        /// </summary>
        public DataTable UOEOrderDtlTable
        {
            get { return this._uoeJnlDataSet.Tables[UOEOrderDtlSchema.CT_UOEOrderDtlDataTable]; }
        }
        # endregion

        # region 仕入データ＜DataTable＞
        /// <summary>
        /// 仕入データ＜DataTable＞
        /// </summary>
        public DataTable StockSlipTable
        {
            get { return this._uoeJnlDataSet.Tables[StockSlipSchema.CT_StockSlipDataTable]; }
        }
        # endregion

        # region 仕入明細＜DataTable＞
        /// <summary>
        /// 仕入明細＜DataTable＞
        /// </summary>
        public DataTable StockDetailTable
        {
            get { return this._uoeJnlDataSet.Tables[StockDetailSchema.CT_StockDetailDataTable]; }
        }
        # endregion

        # region 売上データ＜DataTable＞
        /// <summary>
        /// 売上データ＜DataTable＞
        /// </summary>
        public DataTable SalesSlipTable
        {
            get { return this._uoeJnlDataSet.Tables[SalesSlipSchema.CT_SalesSlipDataTable]; }
        }
        # endregion

        # region 売上明細＜DataTable＞
        /// <summary>
        /// 売上明細＜DataTable＞
        /// </summary>
        public DataTable SalesDetailTable
        {
            get { return this._uoeJnlDataSet.Tables[SalesDetailSchema.CT_SalesDetailDataTable]; }
        }
        # endregion



        # region Uoe仕入データ＜DataTable＞
        /// <summary>
        /// Uoe仕入データ＜DataTable＞
        /// </summary>
        public DataTable UoeStockSlipTable
        {
            get { return this._uoeJnlDataSet.Tables[StockSlipSchema.CT_UoeStockSlipDataTable]; }
        }
        # endregion

        # region Uoe仕入明細＜DataTable＞
        /// <summary>
        /// Uoe仕入明細＜DataTable＞
        /// </summary>
        public DataTable UoeStockDetailTable
        {
            get { return this._uoeJnlDataSet.Tables[StockDetailSchema.CT_UoeStockDetailDataTable]; }
        }
        # endregion

        # region 受注データ＜DataTable＞
        /// <summary>
        /// 受注データ＜DataTable＞
        /// </summary>
        public DataTable AcptSlipTable
        {
            get { return this._uoeJnlDataSet.Tables[SalesSlipSchema.CT_AcptSlipDataTable]; }
        }
        # endregion

        # region 受注明細＜DataTable＞
        /// <summary>
        /// 受注明細＜DataTable＞
        /// </summary>
        public DataTable AcptDetailTable
        {
            get { return this._uoeJnlDataSet.Tables[SalesDetailSchema.CT_AcptDetailDataTable]; }
        }
        # endregion

        // 2009/05/25 START >>>>>>
        # region 注文一覧明細(手入力)＜DataTable＞
        /// <summary>
        /// 注文一覧明細(手入力)＜DataTable＞
        /// </summary>
        public DataTable OrderLstInputDtlTable
        {
            get { return this._uoeJnlDataSet.Tables[OrderLstInputDtlSchema.CT_OrderLstInputDtlDataTable]; }
        }
        # endregion

        # region 買上一覧明細＜DataTable＞
        /// <summary>
        /// 買上一覧明細＜DataTable＞
        /// </summary>
        public DataTable BuyOutLstDtlTable
        {
            get { return this._uoeJnlDataSet.Tables[BuyOutLstDtlSchema.CT_BuyOutLstDtlDataTable]; }
        }
        # endregion

        # region 拠点設定マスタ
        /// <summary>
        /// 拠点設定マスタ
        /// </summary>
        public SecInfoSet secInfoSet
        {
            get { return this._secInfoSet; }
        }
        # endregion
        // 2009/05/25 END   <<<<<<

        # endregion

		# endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		# region Public Methods
		# region 送受信ＪＮＬ＜発注＞→ＵＯＥ発注データ更新クラス作成
		/// <summary>
		/// 送受信ＪＮＬ＜発注＞→ＵＯＥ発注データ更新クラス作成
		/// </summary>
		/// <param name="para">送受信ＪＮＬ＜発注＞</param>
		/// <returns>ＵＯＥ発注データ</returns>
		public List<UOEOrderDtlWork> GetToOrderDtlFromOrder(List<OrderSndRcvJnl> para)
		{
			List<UOEOrderDtlWork> list = new List<UOEOrderDtlWork>();

			try
			{
				foreach (OrderSndRcvJnl orderSndRcvJnl in para)
				{
					UOEOrderDtlWork dtl = new UOEOrderDtlWork();


					list.Add(dtl);
				}
			}
			catch (Exception)
			{
				list.Clear();
			}
			return list;
		}
		# endregion

		# region ■データテーブルの初期化
		/// <summary>
		/// データテーブルの初期化
		/// </summary>
		public void SchemaClear()
		{
			OrderSndRcvJnlSchema.SettingDataSet(ref _uoeJnlDataSet);    //送受信JNL（発注）
            EstmtSndRcvJnlSchema.SettingDataSet(ref _uoeJnlDataSet);    //送受信JNL（見積）
            StockSndRcvJnlSchema.SettingDataSet(ref _uoeJnlDataSet);    //送受信JNL（在庫）
            UOEOrderDtlSchema.SettingDataSet(ref _uoeJnlDataSet);       //UOE発注データ

            StockSlipSchema.SettingDataSet(ref _uoeJnlDataSet, StockSlipSchema.CT_StockSlipDataTable);      //仕入データ
            StockSlipSchema.SettingDataSet(ref _uoeJnlDataSet, StockSlipSchema.CT_UoeStockSlipDataTable);   //仕入データ(売上仕入更新用)

            StockDetailSchema.SettingDataSet(ref _uoeJnlDataSet, StockDetailSchema.CT_StockDetailDataTable);    //仕入明細
            StockDetailSchema.SettingDataSet(ref _uoeJnlDataSet, StockDetailSchema.CT_UoeStockDetailDataTable); //仕入明細(売上仕入更新用)

            SalesSlipSchema.SettingDataSet(ref _uoeJnlDataSet, SalesSlipSchema.CT_SalesSlipDataTable);  //売上データ
            SalesSlipSchema.SettingDataSet(ref _uoeJnlDataSet, SalesSlipSchema.CT_AcptSlipDataTable);   //受注データ

            SalesDetailSchema.SettingDataSet(ref _uoeJnlDataSet, SalesDetailSchema.CT_SalesDetailDataTable);    //売上明細
            SalesDetailSchema.SettingDataSet(ref _uoeJnlDataSet, SalesDetailSchema.CT_AcptDetailDataTable);     //受注明細

            // 2009/05/25 START >>>>>>
            OrderLstInputDtlSchema.SettingDataSet(ref _uoeJnlDataSet, OrderLstInputDtlSchema.CT_OrderLstInputDtlDataTable);  //注文一覧明細(手入力)
            BuyOutLstDtlSchema.SettingDataSet(ref _uoeJnlDataSet, BuyOutLstDtlSchema.CT_BuyOutLstDtlDataTable);  //買上一覧明細
            // 2009/05/25 END   <<<<<<
        
        }
		# endregion

        # region ■ＵＯＥ送受信データテーブルの読込
		# region ＵＯＥ送受信データテーブル＜発注＞の読込
		/// <summary>
		/// ＵＯＥ送受信データテーブル＜発注＞の読込
		/// </summary>
		/// <param name="uOESupplierCd">発注先</param>
		/// <param name="uOESalesOrderNo">発注番号</param>
		/// <param name="uOESalesOrderRowNo">発注行番号</param>
		/// <returns></returns>
		public DataRow JnlOrderTblRead(int uOESupplierCd, int uOESalesOrderNo, int uOESalesOrderRowNo)
		{
			//変数の初期化
			DataRow row = null;
			
			try
			{
				object[] objFind = new object[4];
				objFind[0] = (object)_enterpriseCode;
				objFind[1] = (object)uOESupplierCd;
				objFind[2] = (object)uOESalesOrderNo;
				objFind[3] = (object)uOESalesOrderRowNo;
				row = this.OrderTable.Rows.Find(objFind);
			}
			catch
			{
				row = null;
			}
			return (row);
		}
		# endregion

		# region ＵＯＥ送受信データテーブル＜見積＞の読込
		/// <summary>
		/// ＵＯＥ送受信データテーブル＜見積＞の読込
		/// </summary>
		/// <param name="uOESupplierCd">発注先</param>
		/// <param name="uOESalesOrderNo">発注番号</param>
		/// <param name="uOESalesOrderRowNo">発注行番号</param>
		/// <returns></returns>
		public DataRow JnlEstmtTblRead(int uOESupplierCd, int uOESalesOrderNo, int uOESalesOrderRowNo)
		{
			//変数の初期化
			DataRow row = null;

			try
			{
				object[] objFind = new object[4];
				objFind[0] = (object)_enterpriseCode;
				objFind[1] = (object)uOESupplierCd;
				objFind[2] = (object)uOESalesOrderNo;
				objFind[3] = (object)uOESalesOrderRowNo;
				row = this.EstmtTable.Rows.Find(objFind);
			}
			catch
			{
				row = null;
			}
			return (row);
		}
		# endregion

		# region ＵＯＥ送受信データテーブル＜在庫＞の読込
		/// <summary>
		///	ＵＯＥ送受信データテーブル＜在庫＞の読込
		/// </summary>
		/// <param name="uOESupplierCd">発注先</param>
		/// <param name="uOESalesOrderNo">発注番号</param>
		/// <param name="uOESalesOrderRowNo">発注行番号</param>
		/// <returns></returns>
		public DataRow JnlStockTblRead(int uOESupplierCd, int uOESalesOrderNo, int uOESalesOrderRowNo)
		{
			//変数の初期化
			DataRow row = null;

			try
			{
				object[] objFind = new object[4];
				objFind[0] = (object)_enterpriseCode;
				objFind[1] = (object)uOESupplierCd;
				objFind[2] = (object)uOESalesOrderNo;
				objFind[3] = (object)uOESalesOrderRowNo;
				row = this.StockTable.Rows.Find(objFind);
			}
			catch
			{
				row = null;
			}
			return (row);
		}
		# endregion

		# region ＜発注先単位＞ＵＯＥ送受信データテーブル＜発注＞の読込
        /// <summary>
        /// 送受信ＪＮＬ＜発注＞の読込
        /// </summary>
        /// <param name="uOESupplierCdList">UOE発注先</param>
        /// <param name="dataRecoverDiv">復旧フラグ</param>
        /// <returns>送受信ＪＮＬ＜発注＞オブジェクト</returns>
        public List<OrderSndRcvJnl> GetOrderSndRcvJnlList(List<int> uOESupplierCdList, int dataRecoverDiv)
        {
            List<int> dataRecoverDivList = new List<int>();
            dataRecoverDivList.Add(dataRecoverDiv);
            return (GetOrderSndRcvJnlList(uOESupplierCdList, dataRecoverDivList));
        }

        /// <summary>
        /// 送受信ＪＮＬ＜発注＞の読込
        /// </summary>
        /// <param name="uOESupplierCdList">UOE発注先</param>
        /// <returns>送受信ＪＮＬ＜発注＞オブジェクト</returns>
        public List<OrderSndRcvJnl> GetOrderSndRcvJnlList(List<int> uOESupplierCdList)
        {
            List<int> dataRecoverDivList = new List<int>();
            dataRecoverDivList.Add((int)EnumUoeConst.ctDataRecoverDiv.ct_YES);
            dataRecoverDivList.Add((int)EnumUoeConst.ctDataRecoverDiv.ct_NO);
            dataRecoverDivList.Add((int)EnumUoeConst.ctDataRecoverDiv.ct_NonProcess);
            return (GetOrderSndRcvJnlList(uOESupplierCdList, dataRecoverDivList));
        }

        /// <summary>
        /// 送受信ＪＮＬ＜発注＞の読込
        /// </summary>
        /// <param name="uOESupplierCdList">UOE発注先</param>
        /// <param name="dataRecoverDivList">復旧フラグ</param>
        /// <returns>送受信ＪＮＬ＜発注＞オブジェクト</returns>
        public List<OrderSndRcvJnl> GetOrderSndRcvJnlList(List<int> uOESupplierCdList, List<int> dataRecoverDivList)
        {
            //変数の初期化
            List<OrderSndRcvJnl> returnList = new List<OrderSndRcvJnl>();

            try
            {
                DataView dv = new DataView(OrderTable);

                //-----------------------------------------------------------
                // RowFilter条件の設定
                //-----------------------------------------------------------
                //復旧フラグ
                string filinf = "";
                string linkString = "( {0} = ";
                foreach (int dataRecoverDiv in dataRecoverDivList)
                {
                    filinf = filinf + linkString + dataRecoverDiv;
                    linkString = " OR {0} = ";
                }
                
                //UOE発注先
                linkString = " ) AND ( {1} = ";
                foreach (int uOESupplierCd in uOESupplierCdList)
                {
                    filinf = filinf + linkString + uOESupplierCd;
                    linkString = " OR {1} = ";
                }
                filinf = filinf + " )";

                dv.RowFilter = String.Format(filinf,
                                                OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv,
                                                OrderSndRcvJnlSchema.ct_Col_UOESupplierCd);

                //-----------------------------------------------------------
                // Sort条件の設定
                //-----------------------------------------------------------
                dv.Sort = OrderSndRcvJnlSchema.ct_Col_SupplierCd + ", "
                        + OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo + ", "
                        + OrderSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo;

                //送受信ＪＮＬ（発注）＜DataRow → クラス＞格納処理
                if (dv.Count > 0)
                {
                    for (int i = 0; i < dv.Count; i++)
                    {
                        DataRow dr = dv[i].Row;
                        OrderSndRcvJnl jnl = CreateOrderJnlFromSchema(dr);
                        returnList.Add(jnl);
                    }
                }
            }
            catch (Exception)
            {
                returnList = new List<OrderSndRcvJnl>();
            }
            return (returnList);
        }

		# endregion

		# region ＜発注先単位＞ＵＯＥ送受信データテーブル＜見積＞の読込
        /// <summary>
        /// 送受信ＪＮＬ＜見積＞の読込
        /// </summary>
        /// <param name="uOESupplierCdList">UOE発注先</param>
        /// <param name="dataRecoverDiv">復旧フラグ</param>
        /// <returns>送受信ＪＮＬ＜見積＞オブジェクト</returns>
        public List<EstmtSndRcvJnl> GetEstmtSndRcvJnlList(List<int> uOESupplierCdList, int dataRecoverDiv)
        {
            List<int> dataRecoverDivList = new List<int>();
            dataRecoverDivList.Add(dataRecoverDiv);
            return (GetEstmtSndRcvJnlList(uOESupplierCdList, dataRecoverDivList));
        }

        /// <summary>
        /// 送受信ＪＮＬ＜見積＞の読込
        /// </summary>
        /// <param name="uOESupplierCdList">UOE発注先</param>
        /// <returns>送受信ＪＮＬ＜見積＞オブジェクト</returns>
        public List<EstmtSndRcvJnl> GetEstmtSndRcvJnlList(List<int> uOESupplierCdList)
        {
            List<int> dataRecoverDivList = new List<int>();
            dataRecoverDivList.Add((int)EnumUoeConst.ctDataRecoverDiv.ct_YES);
            dataRecoverDivList.Add((int)EnumUoeConst.ctDataRecoverDiv.ct_NO);
            dataRecoverDivList.Add((int)EnumUoeConst.ctDataRecoverDiv.ct_NonProcess);
            return (GetEstmtSndRcvJnlList(uOESupplierCdList, dataRecoverDivList));
        }

        /// <summary>
        /// 送受信ＪＮＬ＜見積＞の読込
        /// </summary>
        /// <param name="uOESupplierCdList">UOE発注先</param>
        /// <param name="dataRecoverDivList">復旧フラグ</param>
        /// <returns>送受信ＪＮＬ＜見積＞オブジェクト</returns>
        public List<EstmtSndRcvJnl> GetEstmtSndRcvJnlList(List<int> uOESupplierCdList, List<int> dataRecoverDivList)
        {
            //変数の初期化
            List<EstmtSndRcvJnl> returnList = new List<EstmtSndRcvJnl>();

            try
            {
                DataView dv = new DataView(EstmtTable);

                //-----------------------------------------------------------
                // RowFilter条件の設定
                //-----------------------------------------------------------
                //復旧フラグ
                string filinf = "";
                string linkString = "( {0} = ";
                foreach (int dataRecoverDiv in dataRecoverDivList)
                {
                    filinf = filinf + linkString + dataRecoverDiv;
                    linkString = " OR {0} = ";
                }

                //UOE発注先
                linkString = " ) AND ( {1} = ";
                foreach (int uOESupplierCd in uOESupplierCdList)
                {
                    filinf = filinf + linkString + uOESupplierCd;
                    linkString = " OR {1} = ";
                }
                filinf = filinf + " )";

                dv.RowFilter = String.Format(filinf,
                                                EstmtSndRcvJnlSchema.ct_Col_DataRecoverDiv,
                                                EstmtSndRcvJnlSchema.ct_Col_UOESupplierCd);

                //-----------------------------------------------------------
                // Sort条件の設定
                //-----------------------------------------------------------
                dv.Sort = EstmtSndRcvJnlSchema.ct_Col_SupplierCd + ", "
                        + EstmtSndRcvJnlSchema.ct_Col_UOESalesOrderNo + ", "
                        + EstmtSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo;

                //送受信ＪＮＬ（見積）＜DataRow → クラス＞格納処理
                if (dv.Count > 0)
                {
                    for (int i = 0; i < dv.Count; i++)
                    {
                        DataRow dr = dv[i].Row;
                        EstmtSndRcvJnl jnl = CreateEstmtJnlFromSchema(ref dr);
                        returnList.Add(jnl);
                    }
                }
            }
            catch (Exception)
            {
                returnList = new List<EstmtSndRcvJnl>();
            }
            return (returnList);
        }

		# endregion

		# region ＜発注先単位＞ＵＯＥ送受信データテーブル＜在庫＞の読込
        /// <summary>
        /// 送受信ＪＮＬ＜在庫＞の読込
        /// </summary>
        /// <param name="uOESupplierCdList">UOE発注先</param>
        /// <param name="dataRecoverDiv">復旧フラグ</param>
        /// <returns>送受信ＪＮＬ＜在庫＞オブジェクト</returns>
        public List<StockSndRcvJnl> GetStockSndRcvJnlList(List<int> uOESupplierCdList, int dataRecoverDiv)
        {
            List<int> dataRecoverDivList = new List<int>();
            dataRecoverDivList.Add(dataRecoverDiv);
            return (GetStockSndRcvJnlList(uOESupplierCdList, dataRecoverDivList));
        }

        /// <summary>
        /// 送受信ＪＮＬ＜在庫＞の読込
        /// </summary>
        /// <param name="uOESupplierCdList">UOE発注先</param>
        /// <returns>送受信ＪＮＬ＜在庫＞オブジェクト</returns>
        public List<StockSndRcvJnl> GetStockSndRcvJnlList(List<int> uOESupplierCdList)
        {
            List<int> dataRecoverDivList = new List<int>();
            dataRecoverDivList.Add((int)EnumUoeConst.ctDataRecoverDiv.ct_YES);
            dataRecoverDivList.Add((int)EnumUoeConst.ctDataRecoverDiv.ct_NO);
            dataRecoverDivList.Add((int)EnumUoeConst.ctDataRecoverDiv.ct_NonProcess);
            return (GetStockSndRcvJnlList(uOESupplierCdList, dataRecoverDivList));
        }

        /// <summary>
        /// 送受信ＪＮＬ＜在庫＞の読込
        /// </summary>
        /// <param name="uOESupplierCdList">UOE発注先</param>
        /// <param name="dataRecoverDivList">復旧フラグ</param>
        /// <returns>送受信ＪＮＬ＜在庫＞オブジェクト</returns>
        public List<StockSndRcvJnl> GetStockSndRcvJnlList(List<int> uOESupplierCdList, List<int> dataRecoverDivList)
        {
            //変数の初期化
            List<StockSndRcvJnl> returnList = new List<StockSndRcvJnl>();

            try
            {
                DataView dv = new DataView(StockTable);

                //-----------------------------------------------------------
                // RowFilter条件の設定
                //-----------------------------------------------------------
                //復旧フラグ
                string filinf = "";
                string linkString = "( {0} = ";
                foreach (int dataRecoverDiv in dataRecoverDivList)
                {
                    filinf = filinf + linkString + dataRecoverDiv;
                    linkString = " OR {0} = ";
                }

                //UOE発注先
                linkString = " ) AND ( {1} = ";
                foreach (int uOESupplierCd in uOESupplierCdList)
                {
                    filinf = filinf + linkString + uOESupplierCd;
                    linkString = " OR {1} = ";
                }
                filinf = filinf + " )";

                dv.RowFilter = String.Format(filinf,
                                                StockSndRcvJnlSchema.ct_Col_DataRecoverDiv,
                                                StockSndRcvJnlSchema.ct_Col_UOESupplierCd);

                //-----------------------------------------------------------
                // Sort条件の設定
                //-----------------------------------------------------------
                dv.Sort = StockSndRcvJnlSchema.ct_Col_SupplierCd + ", "
                        + StockSndRcvJnlSchema.ct_Col_UOESalesOrderNo + ", "
                        + StockSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo;

                //送受信ＪＮＬ（在庫）＜DataRow → クラス＞格納処理
                if (dv.Count > 0)
                {
                    for (int i = 0; i < dv.Count; i++)
                    {
                        DataRow dr = dv[i].Row;
                        StockSndRcvJnl jnl = CreateStockJnlFromSchema(ref dr);
                        returnList.Add(jnl);
                    }
                }
            }
            catch (Exception)
            {
                returnList = new List<StockSndRcvJnl>();
            }
            return (returnList);
        }

		# endregion
		# endregion

        # region ■送信フラグ・復旧フラグの更新
        # region ＜発注＞ＵＯＥ送受信データテーブル＜送信フラグ・復旧フラグ＞の更新
        /// <summary>
		/// ＜発注＞ＵＯＥ送受信データテーブル＜送信フラグ・復旧フラグ＞の更新
		/// </summary>
		/// <param name="uOESupplierCd">発注先コード</param>
		/// <param name="SrcDataSendCode">送信フラグ(抽出対象)</param>
		/// <param name="SrcDataRecoverDiv">復旧フラグ(抽出対象)</param>
		/// <param name="DstDataSendCode">送信フラグ(変更内容)</param>
		/// <param name="DstDataRecoverDiv">復旧フラグ(変更内容)</param>
		public void JnlOrderTblFlgUpdt(int uOESupplierCd, int SrcDataSendCode, int SrcDataRecoverDiv, int DstDataSendCode, int DstDataRecoverDiv)
		{
			DataView dv = new DataView(OrderTable);
			string filinf = "{0} = '" + _enterpriseCode + "'"
					 + " AND {1} = " + uOESupplierCd
					 + " AND {2} = " + SrcDataSendCode
					 + " AND {3} = " + SrcDataRecoverDiv;
			dv.RowFilter = String.Format(filinf,
											OrderSndRcvJnlSchema.ct_Col_EnterpriseCode,
											OrderSndRcvJnlSchema.ct_Col_UOESupplierCd,
											OrderSndRcvJnlSchema.ct_Col_DataSendCode,
											OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv);
			dv.Sort = "";

			//該当データなし
            int dvMax = dv.Count;
            if (dvMax == 0)
			{
				return;
			}

			//送受信ＪＮＬ（発注）＜DataRow → クラス＞格納処理
            foreach (DataRowView rowDv in dv)
            {
                rowDv[OrderSndRcvJnlSchema.ct_Col_DataSendCode] = DstDataSendCode;
                rowDv[OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv] = DstDataRecoverDiv;
            }
        }

        // --- ADD 2012/10/03 ----------->>>>>
        /// <summary>
        /// ＜発注＞ＵＯＥ送受信データテーブル＜送信フラグ・復旧フラグ＞の更新(優良)
        /// </summary>
        /// <param name="uOESupplierCd">発注先コード</param>
        /// <param name="srcDataSendCode">送信フラグ(抽出対象)</param>
        /// <param name="srcDataRecoverDiv">復旧フラグ(抽出対象)</param>
        /// <param name="dstDataSendCode">送信フラグ(変更内容)</param>
        /// <param name="dstDataRecoverDiv">復旧フラグ(変更内容)</param>
        /// <remarks>
        /// <br></br>
        /// <br>Note       : ＵＯＥ送受信データの送信フラグ・復旧フラグを更新します(優良)</br>
        /// <br>Programmer : FSI佐々木 貴英</br>
        /// <br>Date       : 2012/10/03</br>
        /// </remarks>
        public void JnlOrderTblFlgUpdt1001(int uOESupplierCd, int srcDataSendCode, int srcDataRecoverDiv, int dstDataSendCode, int dstDataRecoverDiv)
        {
            DataView dv = new DataView(OrderTable);
            string filinf = "{0} = '" + _enterpriseCode + "'"
                     + " AND {1} = " + uOESupplierCd
                     + " AND {2} = " + dstDataSendCode
                     + " AND {3} = " + dstDataRecoverDiv;

            // 既に送信フラグが受信エラーとなっている明細が存在するか否か
            dv.RowFilter = String.Format(filinf,
                OrderSndRcvJnlSchema.ct_Col_EnterpriseCode,
                OrderSndRcvJnlSchema.ct_Col_UOESupplierCd,
                OrderSndRcvJnlSchema.ct_Col_DataSendCode,
                OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv);
            if (dv.Count > 0)
            {
                // 既に送信フラグが受信エラーとなっている明細が存在する場合、処理を中断する
                return;
            }

            // 送信フラグが処理中である明細を取得する
            filinf = "{0} = '" + _enterpriseCode + "'"
                     + " AND {1} = " + uOESupplierCd
                     + " AND {2} = " + srcDataSendCode
                     + " AND {3} = " + srcDataRecoverDiv;
            dv.RowFilter = String.Format(filinf,
                                            OrderSndRcvJnlSchema.ct_Col_EnterpriseCode,
                                            OrderSndRcvJnlSchema.ct_Col_UOESupplierCd,
                                            OrderSndRcvJnlSchema.ct_Col_DataSendCode,
                                            OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv);
            dv.Sort = String.Format("{0}", OrderSndRcvJnlSchema.ct_Col_OnlineRowNo);

            //該当データなし
            int dvMax = dv.Count;
            if (dvMax == 0)
            {
                return;
            }

            // 送信フラグが処理中で、明細番号が一番小さな明細と同じUOE発注番号を持つ明細を取得する
            dv.RowFilter = dv.RowFilter
                + string.Format(" AND {0} = {1}", OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo, dv[0][OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo]);

            //送受信ＪＮＬ（発注）＜DataRow → クラス＞格納処理
            foreach( DataRowView rowDv in dv )
            {
                rowDv[OrderSndRcvJnlSchema.ct_Col_DataSendCode] = dstDataSendCode;
                rowDv[OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv] = dstDataRecoverDiv;
            }
        }
        // --- ADD 2012/10/03 -----------<<<<<
        # endregion

        # region ＜見積＞ＵＯＥ送受信データテーブル＜送信フラグ・復旧フラグ＞の更新
		/// <summary>
		/// ＜見積＞ＵＯＥ送受信データテーブル＜送信フラグ・復旧フラグ＞の更新
		/// </summary>
		/// <param name="uOESupplierCd">発注先コード</param>
		/// <param name="SrcDataSendCode">送信フラグ(抽出対象)</param>
		/// <param name="SrcDataRecoverDiv">復旧フラグ(抽出対象)</param>
		/// <param name="DstDataSendCode">送信フラグ(変更内容)</param>
		/// <param name="DstDataRecoverDiv">復旧フラグ(変更内容)</param>
		public void JnlEstmtTblFlgUpdt(int uOESupplierCd, int SrcDataSendCode, int SrcDataRecoverDiv, int DstDataSendCode, int DstDataRecoverDiv)
		{
			DataView dv = new DataView(EstmtTable);
			string filinf = "{0} = '" + _enterpriseCode + "'"
					 + " AND {1} = " + uOESupplierCd
					 + " AND {2} = " + SrcDataSendCode
					 + " AND {3} = " + SrcDataRecoverDiv;
			dv.RowFilter = String.Format(filinf,
											EstmtSndRcvJnlSchema.ct_Col_EnterpriseCode,
											EstmtSndRcvJnlSchema.ct_Col_UOESupplierCd,
											EstmtSndRcvJnlSchema.ct_Col_DataSendCode,
											EstmtSndRcvJnlSchema.ct_Col_DataRecoverDiv);
			dv.Sort = "";

            //該当データなし
            int dvMax = dv.Count;
            if (dvMax == 0)
            {
                return;
            }

            //送受信ＪＮＬ（見積）＜DataRow → クラス＞格納処理
            foreach (DataRowView rowDv in dv)
            {
                rowDv[EstmtSndRcvJnlSchema.ct_Col_DataSendCode] = DstDataSendCode;
                rowDv[EstmtSndRcvJnlSchema.ct_Col_DataRecoverDiv] = DstDataRecoverDiv;
            }
		}


        # endregion

        # region ＜在庫＞ＵＯＥ送受信データテーブル＜送信フラグ・復旧フラグ＞の更新
		/// <summary>
		/// ＜在庫＞ＵＯＥ送受信データテーブル＜送信フラグ・復旧フラグ＞の更新
		/// </summary>
		/// <param name="uOESupplierCd">発注先コード</param>
		/// <param name="SrcDataSendCode">送信フラグ(抽出対象)</param>
		/// <param name="SrcDataRecoverDiv">復旧フラグ(抽出対象)</param>
		/// <param name="DstDataSendCode">送信フラグ(変更内容)</param>
		/// <param name="DstDataRecoverDiv">復旧フラグ(変更内容)</param>
		public void JnlStockTblFlgUpdt(int uOESupplierCd, int SrcDataSendCode, int SrcDataRecoverDiv, int DstDataSendCode, int DstDataRecoverDiv)
		{
			DataView dv = new DataView(StockTable);
			string filinf = "{0} = '" + _enterpriseCode + "'"
					 + " AND {1} = " + uOESupplierCd
					 + " AND {2} = " + SrcDataSendCode
					 + " AND {3} = " + SrcDataRecoverDiv;
			dv.RowFilter = String.Format(filinf,
											StockSndRcvJnlSchema.ct_Col_EnterpriseCode,
											StockSndRcvJnlSchema.ct_Col_UOESupplierCd,
											StockSndRcvJnlSchema.ct_Col_DataSendCode,
											StockSndRcvJnlSchema.ct_Col_DataRecoverDiv);
			dv.Sort = "";

			//該当データなし
            //該当データなし
            int dvMax = dv.Count;
            if (dvMax == 0)
            {
                return;
            }

            //送受信ＪＮＬ（在庫）＜DataRow → クラス＞格納処理
            foreach (DataRowView rowDv in dv)
            {
                rowDv[StockSndRcvJnlSchema.ct_Col_DataSendCode] = DstDataSendCode;
                rowDv[StockSndRcvJnlSchema.ct_Col_DataRecoverDiv] = DstDataRecoverDiv;
            }
		}
        # endregion
        # endregion
        # endregion

        // ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods
		# region ■ＵＯＥ発注データ→送受信ＪＮＬ更新クラス作成
        # region ＵＯＥ発注データ→送受信ＪＮＬ＜見積＞更新クラス作成
		/// <summary>
		/// ＵＯＥ発注データ→送受信ＪＮＬ＜見積＞更新クラス作成
		/// </summary>
		/// <param name="para">ＵＯＥ発注データクラス List<UOEOrderDtlWork></param>
		/// <returns>送受信ＪＮＬ＜見積＞クラス List<EstmtSndRcvJnl></returns>
		private List<EstmtSndRcvJnl> GetToEstmtFromOrderDtl(List<UOEOrderDtlWork> para)
		{
			List<EstmtSndRcvJnl> list = new List<EstmtSndRcvJnl>();

			try
			{
				foreach (UOEOrderDtlWork uOEOrderDtlRet in para)
				{
					EstmtSndRcvJnl jnl = new EstmtSndRcvJnl();

					//jnl.CreateDateTime = uOEOrderDtlRet.CreateDateTime; // 作成日時
					//jnl.UpdateDateTime = uOEOrderDtlRet.UpdateDateTime; // 更新日時
					jnl.EnterpriseCode = uOEOrderDtlRet.EnterpriseCode; // 企業コード
					//jnl.FileHeaderGuid = uOEOrderDtlRet.FileHeaderGuid; // GUID
					//jnl.UpdEmployeeCode = uOEOrderDtlRet.UpdEmployeeCode; // 更新従業員コード
					//jnl.UpdAssemblyId1 = uOEOrderDtlRet.UpdAssemblyId1; // 更新アセンブリID1
					//jnl.UpdAssemblyId2 = uOEOrderDtlRet.UpdAssemblyId2; // 更新アセンブリID2
					//jnl.LogicalDeleteCode = uOEOrderDtlRet.LogicalDeleteCode; // 論理削除区分
					jnl.SystemDivCd = uOEOrderDtlRet.SystemDivCd; // システム区分
					jnl.UOESalesOrderNo = uOEOrderDtlRet.UOESalesOrderNo; // UOE発注番号
					jnl.UOESalesOrderRowNo = uOEOrderDtlRet.UOESalesOrderRowNo; // UOE発注行番号
					jnl.SendTerminalNo = uOEOrderDtlRet.SendTerminalNo; // 送信端末番号
					jnl.UOESupplierCd = uOEOrderDtlRet.UOESupplierCd; // UOE発注先コード
					jnl.UOESupplierName = uOEOrderDtlRet.UOESupplierName; // UOE発注先名称
					jnl.OnlineNo = uOEOrderDtlRet.OnlineNo; // オンライン番号
					jnl.OnlineRowNo = uOEOrderDtlRet.OnlineRowNo; // オンライン行番号
					jnl.SalesDate = uOEOrderDtlRet.SalesDate; // 売上日付
					//jnl.SalesTime = uOEOrderDtlRet.SalesTime; // 売上時刻
					jnl.SalesSlipNum = uOEOrderDtlRet.SalesSlipNum; // 売上伝票番号
					//jnl.DetailRowCount = uOEOrderDtlRet.DetailRowCount; // 明細行数
					jnl.CustomerCode = uOEOrderDtlRet.CustomerCode; // 得意先コード
					//jnl.CustomerName = uOEOrderDtlRet.CustomerName; // 得意先名称
					jnl.CashRegisterNo = uOEOrderDtlRet.CashRegisterNo; // レジ番号
					jnl.CommonSeqNo = uOEOrderDtlRet.CommonSeqNo; // 共通通番
					//jnl.SlipDtlNum = uOEOrderDtlRet.SlipDtlNum; // 明細通番
					//jnl.SlipDtlNumDerivNo = uOEOrderDtlRet.SlipDtlNumDerivNo; // 明細通番枝番
					jnl.BoCode = uOEOrderDtlRet.BoCode; // BO区分
                    jnl.UOEDeliGoodsDiv = uOEOrderDtlRet.UOEDeliGoodsDiv; // 納品区分
					jnl.DeliveredGoodsDivNm = uOEOrderDtlRet.DeliveredGoodsDivNm; // 納品区分名称
					jnl.FollowDeliGoodsDiv = uOEOrderDtlRet.FollowDeliGoodsDiv; // フォロー納品区分
					jnl.FollowDeliGoodsDivNm = uOEOrderDtlRet.FollowDeliGoodsDivNm; // フォロー納品区分名称
					jnl.UOEResvdSection = uOEOrderDtlRet.UOEResvdSection; // UOE指定拠点
					jnl.UOEResvdSectionNm = uOEOrderDtlRet.UOEResvdSectionNm; // UOE指定拠点名称
					jnl.EmployeeCode = uOEOrderDtlRet.EmployeeCode; // 従業員コード
					jnl.EmployeeName = uOEOrderDtlRet.EmployeeName; // 従業員名称
					jnl.GoodsMakerCd = uOEOrderDtlRet.GoodsMakerCd; // 商品メーカーコード
					jnl.MakerName = uOEOrderDtlRet.MakerName; // メーカー名称
					jnl.GoodsNo = uOEOrderDtlRet.GoodsNo; // 商品番号
					jnl.GoodsNoNoneHyphen = uOEOrderDtlRet.GoodsNoNoneHyphen; // ハイフン無商品番号
					jnl.GoodsName = uOEOrderDtlRet.GoodsName; // 商品名称
					jnl.AcceptAnOrderCnt = uOEOrderDtlRet.AcceptAnOrderCnt; // 受注数量
					jnl.SupplierCd = uOEOrderDtlRet.SupplierCd; // 仕入先コード
					jnl.SupplierSnm = uOEOrderDtlRet.SupplierSnm; // 仕入先略称
					jnl.UoeRemark1 = uOEOrderDtlRet.UoeRemark1; // ＵＯＥリマーク１
					jnl.UoeRemark2 = uOEOrderDtlRet.UoeRemark2; // ＵＯＥリマーク２
					//jnl.EstimateRate = uOEOrderDtlRet.EstimateRate; // 見積レート
					//jnl.SelectCode = uOEOrderDtlRet.SelectCode; // 選択コード
					jnl.ReceiveDate = uOEOrderDtlRet.ReceiveDate; // 受信日付
					jnl.ReceiveTime = uOEOrderDtlRet.ReceiveTime; // 受信時刻
					jnl.AnswerMakerCd = uOEOrderDtlRet.AnswerMakerCd; // 回答メーカーコード
					jnl.AnswerPartsNo = uOEOrderDtlRet.AnswerPartsNo; // 回答品番
					jnl.AnswerPartsName = uOEOrderDtlRet.AnswerPartsName; // 回答品名
					jnl.SubstPartsNo = uOEOrderDtlRet.SubstPartsNo; // 代替品番
					jnl.ListPrice = uOEOrderDtlRet.ListPrice; // 定価
					//jnl.SalesUnPrcTaxExcFl = uOEOrderDtlRet.SalesUnPrcTaxExcFl; // 売上単価（税抜，浮動）
					//jnl.HeadQtrsStock = uOEOrderDtlRet.HeadQtrsStock; // 本部在庫
					//jnl.BranchStock = uOEOrderDtlRet.BranchStock; // 拠点在庫
					//jnl.SectionStock = uOEOrderDtlRet.SectionStock; // 支店在庫
					//jnl.UOESectionCode1 = uOEOrderDtlRet.UOESectionCode1; // UOE拠点コード１
					//jnl.UOESectionCode2 = uOEOrderDtlRet.UOESectionCode2; // UOE拠点コード２
					//jnl.UOESectionCode3 = uOEOrderDtlRet.UOESectionCode3; // UOE拠点コード３
					//jnl.UOESectionStock1 = uOEOrderDtlRet.UOESectionStock1; // UOE拠点在庫数１
					//jnl.UOESectionStock2 = uOEOrderDtlRet.UOESectionStock2; // UOE拠点在庫数２
					//jnl.UOESectionStock3 = uOEOrderDtlRet.UOESectionStock3; // UOE拠点在庫数３
					//jnl.UOEDelivDateCd = uOEOrderDtlRet.UOEDelivDateCd; // UOE納期コード
					//jnl.UOESubstCode = uOEOrderDtlRet.UOESubstCode; // UOE代替コード
					//jnl.UOEPriceCode = uOEOrderDtlRet.UOEPriceCode; // UOE価格コード
					jnl.SalesUnitCost = uOEOrderDtlRet.SalesUnitCost; // 原価単価
					jnl.PartsLayerCd = uOEOrderDtlRet.PartsLayerCd; // 層別コード
					jnl.HeadErrorMassage = uOEOrderDtlRet.HeadErrorMassage; // ヘッドエラーメッセージ
					jnl.LineErrorMassage = uOEOrderDtlRet.LineErrorMassage; // ラインエラーメッセージ
					jnl.DataSendCode = uOEOrderDtlRet.DataSendCode; // データ送信区分
					jnl.DataRecoverDiv = uOEOrderDtlRet.DataRecoverDiv; // データ復旧区分

					list.Add(jnl);
				}
			}
			catch (Exception)
			{
				list.Clear();
			}
			return list;
		}
		# endregion

		# region ＵＯＥ発注データ→送受信ＪＮＬ＜在庫＞更新クラス作成
		/// <summary>
		/// ＵＯＥ発注データ→送受信ＪＮＬ＜在庫＞更新クラス作成
		/// </summary>
		/// <param name="para">ＵＯＥ発注データクラス List<UOEOrderDtlWork></param>
		/// <returns>送受信ＪＮＬ＜見積＞クラス List<StockSndRcvJnl></returns>
		private List<StockSndRcvJnl> GetToStockFromOrderDtl(List<UOEOrderDtlWork> para)
		{
			List<StockSndRcvJnl> list = new List<StockSndRcvJnl>();

			try
			{
				foreach (UOEOrderDtlWork uOEOrderDtlRet in para)
				{
					StockSndRcvJnl jnl = new StockSndRcvJnl();

					//jnl.CreateDateTime = uOEOrderDtlRet.CreateDateTime; // 作成日時
					//jnl.UpdateDateTime = uOEOrderDtlRet.UpdateDateTime; // 更新日時
					jnl.EnterpriseCode = uOEOrderDtlRet.EnterpriseCode; // 企業コード
					//jnl.FileHeaderGuid = uOEOrderDtlRet.FileHeaderGuid; // GUID
					//jnl.UpdEmployeeCode = uOEOrderDtlRet.UpdEmployeeCode; // 更新従業員コード
					//jnl.UpdAssemblyId1 = uOEOrderDtlRet.UpdAssemblyId1; // 更新アセンブリID1
					//jnl.UpdAssemblyId2 = uOEOrderDtlRet.UpdAssemblyId2; // 更新アセンブリID2
					//jnl.LogicalDeleteCode = uOEOrderDtlRet.LogicalDeleteCode; // 論理削除区分

					jnl.SystemDivCd = uOEOrderDtlRet.SystemDivCd; // システム区分
					jnl.UOESalesOrderNo = uOEOrderDtlRet.UOESalesOrderNo; // UOE発注番号
					jnl.UOESalesOrderRowNo = uOEOrderDtlRet.UOESalesOrderRowNo; // UOE発注行番号
					jnl.SendTerminalNo = uOEOrderDtlRet.SendTerminalNo; // 送信端末番号
					jnl.UOESupplierCd = uOEOrderDtlRet.UOESupplierCd; // UOE発注先コード
					jnl.UOESupplierName = uOEOrderDtlRet.UOESupplierName; // UOE発注先名称
					jnl.OnlineNo = uOEOrderDtlRet.OnlineNo; // オンライン番号
					jnl.OnlineRowNo = uOEOrderDtlRet.OnlineRowNo; // オンライン行番号
					jnl.SalesSlipNum = uOEOrderDtlRet.SalesSlipNum; // 売上伝票番号
					//jnl.DetailRowCount = uOEOrderDtlRet.DetailRowCount; // 明細行数
					jnl.SalesDate = uOEOrderDtlRet.SalesDate; // 売上日付
					//jnl.SalesTime = uOEOrderDtlRet.SalesTime; // 売上時刻
					jnl.CustomerCode = uOEOrderDtlRet.CustomerCode; // 得意先コード
					//jnl.CustomerName = uOEOrderDtlRet.CustomerName; // 得意先名称
					jnl.CashRegisterNo = uOEOrderDtlRet.CashRegisterNo; // レジ番号
					jnl.CommonSeqNo = uOEOrderDtlRet.CommonSeqNo; // 共通通番
					//jnl.SlipDtlNum = uOEOrderDtlRet.SlipDtlNum; // 明細通番
					//jnl.SlipDtlNumDerivNo = uOEOrderDtlRet.SlipDtlNumDerivNo; // 明細通番枝番
					jnl.BoCode = uOEOrderDtlRet.BoCode; // BO区分
                    jnl.UOEDeliGoodsDiv = uOEOrderDtlRet.UOEDeliGoodsDiv; // 納品区分
					jnl.DeliveredGoodsDivNm = uOEOrderDtlRet.DeliveredGoodsDivNm; // 納品区分名称
					jnl.FollowDeliGoodsDiv = uOEOrderDtlRet.FollowDeliGoodsDiv; // フォロー納品区分
					jnl.FollowDeliGoodsDivNm = uOEOrderDtlRet.FollowDeliGoodsDivNm; // フォロー納品区分名称
					jnl.UOEResvdSection = uOEOrderDtlRet.UOEResvdSection; // UOE指定拠点
					jnl.UOEResvdSectionNm = uOEOrderDtlRet.UOEResvdSectionNm; // UOE指定拠点名称
					jnl.EmployeeCode = uOEOrderDtlRet.EmployeeCode; // 従業員コード
					jnl.EmployeeName = uOEOrderDtlRet.EmployeeName; // 従業員名称
					jnl.GoodsMakerCd = uOEOrderDtlRet.GoodsMakerCd; // 商品メーカーコード
					jnl.MakerName = uOEOrderDtlRet.MakerName; // メーカー名称
					jnl.GoodsNo = uOEOrderDtlRet.GoodsNo; // 商品番号
					jnl.GoodsNoNoneHyphen = uOEOrderDtlRet.GoodsNoNoneHyphen; // ハイフン無商品番号
					jnl.GoodsName = uOEOrderDtlRet.GoodsName; // 商品名称
					jnl.AcceptAnOrderCnt = uOEOrderDtlRet.AcceptAnOrderCnt; // 受注数量
					jnl.SupplierCd = uOEOrderDtlRet.SupplierCd; // 仕入先コード
					jnl.SupplierSnm = uOEOrderDtlRet.SupplierSnm; // 仕入先略称
					jnl.UoeRemark1 = uOEOrderDtlRet.UoeRemark1; // ＵＯＥリマーク１
					jnl.UoeRemark2 = uOEOrderDtlRet.UoeRemark2; // ＵＯＥリマーク２
					jnl.ReceiveDate = uOEOrderDtlRet.ReceiveDate; // 受信日付
					jnl.ReceiveTime = uOEOrderDtlRet.ReceiveTime; // 受信時刻
					jnl.AnswerMakerCd = uOEOrderDtlRet.AnswerMakerCd; // 回答メーカーコード
					jnl.AnswerPartsNo = uOEOrderDtlRet.AnswerPartsNo; // 回答品番
					jnl.AnswerPartsName = uOEOrderDtlRet.AnswerPartsName; // 回答品名
					jnl.SubstPartsNo = uOEOrderDtlRet.SubstPartsNo; // 代替品番
					//jnl.CenterSubstPartsNo = uOEOrderDtlRet.CenterSubstPartsNo; // 代替品番（センター）
					jnl.ListPrice = uOEOrderDtlRet.ListPrice; // 定価
					jnl.SalesUnitCost = uOEOrderDtlRet.SalesUnitCost; // 原価単価
					//jnl.GoodsAPrice = uOEOrderDtlRet.GoodsAPrice; // 商品Ａ価格
					//jnl.UOEStopCd = uOEOrderDtlRet.UOEStopCd; // UOE中止コード
					//jnl.UOESubstCode = uOEOrderDtlRet.UOESubstCode; // UOE代替コード
					//jnl.UOEDelivDateCd = uOEOrderDtlRet.UOEDelivDateCd; // UOE納期コード
					jnl.PartsLayerCd = uOEOrderDtlRet.PartsLayerCd; // 層別コード
					//jnl.ShopStUnitPrice = uOEOrderDtlRet.ShopStUnitPrice; // 販売店仕入単価
					//jnl.UOESectionCode1 = uOEOrderDtlRet.UOESectionCode1; // UOE拠点コード１
					//jnl.UOESectionCode2 = uOEOrderDtlRet.UOESectionCode2; // UOE拠点コード２
					//jnl.UOESectionCode3 = uOEOrderDtlRet.UOESectionCode3; // UOE拠点コード３
					//jnl.UOESectionCode4 = uOEOrderDtlRet.UOESectionCode4; // UOE拠点コード４
					//jnl.UOESectionCode5 = uOEOrderDtlRet.UOESectionCode5; // UOE拠点コード５
					//jnl.UOESectionCode6 = uOEOrderDtlRet.UOESectionCode6; // UOE拠点コード６
					//jnl.UOESectionCode7 = uOEOrderDtlRet.UOESectionCode7; // UOE拠点コード７
					//jnl.UOESectionCode8 = uOEOrderDtlRet.UOESectionCode8; // UOE拠点コード８
					//jnl.UOESectionStock1 = uOEOrderDtlRet.UOESectionStock1; // UOE拠点在庫数１
					//jnl.UOESectionStock2 = uOEOrderDtlRet.UOESectionStock2; // UOE拠点在庫数２
					//jnl.UOESectionStock3 = uOEOrderDtlRet.UOESectionStock3; // UOE拠点在庫数３
					//jnl.UOESectionStock4 = uOEOrderDtlRet.UOESectionStock4; // UOE拠点在庫数４
					//jnl.UOESectionStock5 = uOEOrderDtlRet.UOESectionStock5; // UOE拠点在庫数５
					//jnl.UOESectionStock6 = uOEOrderDtlRet.UOESectionStock6; // UOE拠点在庫数６
					//jnl.UOESectionStock7 = uOEOrderDtlRet.UOESectionStock7; // UOE拠点在庫数７
					//jnl.UOESectionStock8 = uOEOrderDtlRet.UOESectionStock8; // UOE拠点在庫数８
					//jnl.UOESectionStock9 = uOEOrderDtlRet.UOESectionStock9; // UOE拠点在庫数９
					//jnl.UOESectionStock10 = uOEOrderDtlRet.UOESectionStock10; // UOE拠点在庫数１０
					//jnl.UOESectionStock11 = uOEOrderDtlRet.UOESectionStock11; // UOE拠点在庫数１１
					//jnl.UOESectionStock12 = uOEOrderDtlRet.UOESectionStock12; // UOE拠点在庫数１２
					//jnl.UOESectionStock13 = uOEOrderDtlRet.UOESectionStock13; // UOE拠点在庫数１３
					//jnl.UOESectionStock14 = uOEOrderDtlRet.UOESectionStock14; // UOE拠点在庫数１４
					//jnl.UOESectionStock15 = uOEOrderDtlRet.UOESectionStock15; // UOE拠点在庫数１５
					//jnl.UOESectionStock16 = uOEOrderDtlRet.UOESectionStock16; // UOE拠点在庫数１６
					//jnl.UOESectionStock17 = uOEOrderDtlRet.UOESectionStock17; // UOE拠点在庫数１７
					////jnl.UOESectionStock18 = uOEOrderDtlRet.UOESectionStock18; // UOE拠点在庫数１８
					//jnl.UOESectionStock19 = uOEOrderDtlRet.UOESectionStock19; // UOE拠点在庫数１９
					//jnl.UOESectionStock20 = uOEOrderDtlRet.UOESectionStock20; // UOE拠点在庫数２０
					//jnl.UOESectionStock21 = uOEOrderDtlRet.UOESectionStock21; // UOE拠点在庫数２１
					//jnl.UOESectionStock22 = uOEOrderDtlRet.UOESectionStock22; // UOE拠点在庫数２２
					//jnl.UOESectionStock23 = uOEOrderDtlRet.UOESectionStock23; // UOE拠点在庫数２３
					//jnl.UOESectionStock24 = uOEOrderDtlRet.UOESectionStock24; // UOE拠点在庫数２４
					//jnl.UOESectionStock25 = uOEOrderDtlRet.UOESectionStock25; // UOE拠点在庫数２５
					//jnl.UOESectionStock26 = uOEOrderDtlRet.UOESectionStock26; // UOE拠点在庫数２６
					//jnl.UOESectionStock27 = uOEOrderDtlRet.UOESectionStock27; // UOE拠点在庫数２７
					//jnl.UOESectionStock28 = uOEOrderDtlRet.UOESectionStock28; // UOE拠点在庫数２８
					//jnl.UOESectionStock29 = uOEOrderDtlRet.UOESectionStock29; // UOE拠点在庫数２９
					//jnl.UOESectionStock30 = uOEOrderDtlRet.UOESectionStock30; // UOE拠点在庫数３０
					//jnl.UOESectionStock31 = uOEOrderDtlRet.UOESectionStock31; // UOE拠点在庫数３１
					//jnl.UOESectionStock32 = uOEOrderDtlRet.UOESectionStock32; // UOE拠点在庫数３２
					//jnl.UOESectionStock33 = uOEOrderDtlRet.UOESectionStock33; // UOE拠点在庫数３３
					//jnl.UOESectionStock34 = uOEOrderDtlRet.UOESectionStock34; // UOE拠点在庫数３４
					//jnl.UOESectionStock35 = uOEOrderDtlRet.UOESectionStock35; // UOE拠点在庫数３５
					jnl.HeadErrorMassage = uOEOrderDtlRet.HeadErrorMassage; // ヘッドエラーメッセージ
					jnl.LineErrorMassage = uOEOrderDtlRet.LineErrorMassage; // ラインエラーメッセージ
					jnl.DataSendCode = uOEOrderDtlRet.DataSendCode; // データ送信区分
					jnl.DataRecoverDiv = uOEOrderDtlRet.DataRecoverDiv; // データ復旧区分

					list.Add(jnl);
				}
			}
			catch (Exception)
			{
				list.Clear();
			}
			return list;
		}
		# endregion

		# region ＵＯＥ発注データ→送受信ＪＮＬ＜発注＞更新クラス作成
		/// <summary>
		/// ＵＯＥ発注データ→送受信ＪＮＬ＜発注＞更新クラス作成
		/// </summary>
		/// <param name="para">ＵＯＥ発注データクラス List<UOEOrderDtlWork></param>
		/// <returns>送受信ＪＮＬ＜見積＞クラス List<OrderSndRcvJnl></returns>
		private List<OrderSndRcvJnl> GetToOrderFromOrderDtl(List<UOEOrderDtlWork> para)
		{
			List<OrderSndRcvJnl> list = new List<OrderSndRcvJnl>();

			try
			{
                foreach (UOEOrderDtlWork rst in para)
				{
					OrderSndRcvJnl jnl = new OrderSndRcvJnl();

                    jnl.CreateDateTime = rst.CreateDateTime;	// 作成日時
                    jnl.UpdateDateTime = rst.UpdateDateTime;	// 更新日時
                    jnl.EnterpriseCode = rst.EnterpriseCode;	// 企業コード
                    jnl.FileHeaderGuid = rst.FileHeaderGuid;	// GUID
                    jnl.UpdEmployeeCode = rst.UpdEmployeeCode;	// 更新従業員コード
                    jnl.UpdAssemblyId1 = rst.UpdAssemblyId1;	// 更新アセンブリID1
                    jnl.UpdAssemblyId2 = rst.UpdAssemblyId2;	// 更新アセンブリID2
                    jnl.LogicalDeleteCode = rst.LogicalDeleteCode;	// 論理削除区分
                    jnl.SystemDivCd = rst.SystemDivCd;	// システム区分
                    jnl.UOESalesOrderNo = rst.UOESalesOrderNo;	// UOE発注番号
                    jnl.UOESalesOrderRowNo = rst.UOESalesOrderRowNo;	// UOE発注行番号
                    jnl.SendTerminalNo = rst.SendTerminalNo;	// 送信端末番号
                    jnl.UOESupplierCd = rst.UOESupplierCd;	// UOE発注先コード
                    jnl.UOESupplierName = rst.UOESupplierName;	// UOE発注先名称
                    jnl.CommAssemblyId = rst.CommAssemblyId;	// 通信アセンブリID
                    jnl.OnlineNo = rst.OnlineNo;	// オンライン番号
                    jnl.OnlineRowNo = rst.OnlineRowNo;	// オンライン行番号
                    jnl.SalesDate = rst.SalesDate;	// 売上日付
                    jnl.InputDay = rst.InputDay;	// 入力日
                    jnl.DataUpdateDateTime = rst.DataUpdateDateTime;	// データ更新日時
                    jnl.UOEKind = rst.UOEKind;	// UOE種別
                    jnl.SalesSlipNum = rst.SalesSlipNum;	// 売上伝票番号
                    jnl.AcptAnOdrStatus = rst.AcptAnOdrStatus;	// 受注ステータス
                    jnl.SalesSlipDtlNum = rst.SalesSlipDtlNum;	// 売上明細通番
                    jnl.SectionCode = rst.SectionCode;	// 拠点コード
                    jnl.SubSectionCode = rst.SubSectionCode;	// 部門コード
                    jnl.CustomerCode = rst.CustomerCode;	// 得意先コード
                    jnl.CustomerSnm = rst.CustomerSnm;	// 得意先略称
                    jnl.CashRegisterNo = rst.CashRegisterNo;	// レジ番号
                    jnl.CommonSeqNo = rst.CommonSeqNo;	// 共通通番
                    jnl.SupplierFormal = rst.SupplierFormal;	// 仕入形式
                    jnl.SupplierSlipNo = rst.SupplierSlipNo;	// 仕入伝票番号
                    jnl.StockSlipDtlNum = rst.StockSlipDtlNum;	// 仕入明細通番
                    jnl.BoCode = rst.BoCode;	// BO区分
                    jnl.UOEDeliGoodsDiv = rst.UOEDeliGoodsDiv;	// 納品区分
                    jnl.DeliveredGoodsDivNm = rst.DeliveredGoodsDivNm;	// 納品区分名称
                    jnl.FollowDeliGoodsDiv = rst.FollowDeliGoodsDiv;	// フォロー納品区分
                    jnl.FollowDeliGoodsDivNm = rst.FollowDeliGoodsDivNm;	// フォロー納品区分名称
                    jnl.UOEResvdSection = rst.UOEResvdSection;	// UOE指定拠点
                    jnl.UOEResvdSectionNm = rst.UOEResvdSectionNm;	// UOE指定拠点名称
                    jnl.EmployeeCode = rst.EmployeeCode;	// 従業員コード
                    jnl.EmployeeName = rst.EmployeeName;	// 従業員名称
                    jnl.GoodsMakerCd = rst.GoodsMakerCd;	// 商品メーカーコード
                    jnl.MakerName = rst.MakerName;	// メーカー名称
                    jnl.GoodsNo = rst.GoodsNo;	// 商品番号
                    jnl.GoodsNoNoneHyphen = rst.GoodsNoNoneHyphen;	// ハイフン無商品番号
                    jnl.GoodsName = rst.GoodsName;	// 商品名称
                    jnl.WarehouseCode = rst.WarehouseCode;	// 倉庫コード
                    jnl.WarehouseName = rst.WarehouseName;	// 倉庫名称
                    jnl.WarehouseShelfNo = rst.WarehouseShelfNo;	// 倉庫棚番
                    jnl.AcceptAnOrderCnt = rst.AcceptAnOrderCnt;	// 受注数量
                    jnl.ListPrice = rst.ListPrice;	// 定価（浮動）
                    jnl.SalesUnitCost = rst.SalesUnitCost;	// 原価単価
                    jnl.SupplierCd = rst.SupplierCd;	// 仕入先コード
                    jnl.SupplierSnm = rst.SupplierSnm;	// 仕入先略称
                    jnl.UoeRemark1 = rst.UoeRemark1;	// ＵＯＥリマーク１
                    jnl.UoeRemark2 = rst.UoeRemark2;	// ＵＯＥリマーク２
                    jnl.ReceiveDate = rst.ReceiveDate;	// 受信日付
                    jnl.ReceiveTime = rst.ReceiveTime;	// 受信時刻
                    jnl.AnswerMakerCd = rst.AnswerMakerCd;	// 回答メーカーコード
                    jnl.AnswerPartsNo = rst.AnswerPartsNo;	// 回答品番
                    jnl.AnswerPartsName = rst.AnswerPartsName;	// 回答品名
                    jnl.SubstPartsNo = rst.SubstPartsNo;	// 代替品番
                    jnl.UOESectOutGoodsCnt = rst.UOESectOutGoodsCnt;	// UOE拠点出庫数
                    jnl.BOShipmentCnt1 = rst.BOShipmentCnt1;	// BO出庫数1
                    jnl.BOShipmentCnt2 = rst.BOShipmentCnt2;	// BO出庫数2
                    jnl.BOShipmentCnt3 = rst.BOShipmentCnt3;	// BO出庫数3
                    jnl.MakerFollowCnt = rst.MakerFollowCnt;	// メーカーフォロー数
                    jnl.NonShipmentCnt = rst.NonShipmentCnt;	// 未出庫数
                    jnl.UOESectStockCnt = rst.UOESectStockCnt;	// UOE拠点在庫数
                    jnl.BOStockCount1 = rst.BOStockCount1;	// BO在庫数1
                    jnl.BOStockCount2 = rst.BOStockCount2;	// BO在庫数2
                    jnl.BOStockCount3 = rst.BOStockCount3;	// BO在庫数3
                    jnl.UOESectionSlipNo = rst.UOESectionSlipNo;	// UOE拠点伝票番号
                    jnl.BOSlipNo1 = rst.BOSlipNo1;	// BO伝票番号１
                    jnl.BOSlipNo2 = rst.BOSlipNo2;	// BO伝票番号２
                    jnl.BOSlipNo3 = rst.BOSlipNo3;	// BO伝票番号３
                    jnl.EOAlwcCount = rst.EOAlwcCount;	// EO引当数
                    jnl.BOManagementNo = rst.BOManagementNo;	// BO管理番号
                    jnl.AnswerListPrice = rst.AnswerListPrice;	// 回答定価
                    jnl.AnswerSalesUnitCost = rst.AnswerSalesUnitCost;	// 回答原価単価
                    jnl.UOESubstMark = rst.UOESubstMark;	// UOE代替マーク
                    jnl.UOEStockMark = rst.UOEStockMark;	// UOE在庫マーク
                    jnl.PartsLayerCd = rst.PartsLayerCd;	// 層別コード
                    jnl.MazdaUOEShipSectCd1 = rst.MazdaUOEShipSectCd1;	// UOE出荷拠点コード１（マツダ）
                    jnl.MazdaUOEShipSectCd2 = rst.MazdaUOEShipSectCd2;	// UOE出荷拠点コード２（マツダ）
                    jnl.MazdaUOEShipSectCd3 = rst.MazdaUOEShipSectCd3;	// UOE出荷拠点コード３（マツダ）
                    jnl.MazdaUOESectCd1 = rst.MazdaUOESectCd1;	// UOE拠点コード１（マツダ）
                    jnl.MazdaUOESectCd2 = rst.MazdaUOESectCd2;	// UOE拠点コード２（マツダ）
                    jnl.MazdaUOESectCd3 = rst.MazdaUOESectCd3;	// UOE拠点コード３（マツダ）
                    jnl.MazdaUOESectCd4 = rst.MazdaUOESectCd4;	// UOE拠点コード４（マツダ）
                    jnl.MazdaUOESectCd5 = rst.MazdaUOESectCd5;	// UOE拠点コード５（マツダ）
                    jnl.MazdaUOESectCd6 = rst.MazdaUOESectCd6;	// UOE拠点コード６（マツダ）
                    jnl.MazdaUOESectCd7 = rst.MazdaUOESectCd7;	// UOE拠点コード７（マツダ）
                    jnl.MazdaUOEStockCnt1 = rst.MazdaUOEStockCnt1;	// UOE在庫数１（マツダ）
                    jnl.MazdaUOEStockCnt2 = rst.MazdaUOEStockCnt2;	// UOE在庫数２（マツダ）
                    jnl.MazdaUOEStockCnt3 = rst.MazdaUOEStockCnt3;	// UOE在庫数３（マツダ）
                    jnl.MazdaUOEStockCnt4 = rst.MazdaUOEStockCnt4;	// UOE在庫数４（マツダ）
                    jnl.MazdaUOEStockCnt5 = rst.MazdaUOEStockCnt5;	// UOE在庫数５（マツダ）
                    jnl.MazdaUOEStockCnt6 = rst.MazdaUOEStockCnt6;	// UOE在庫数６（マツダ）
                    jnl.MazdaUOEStockCnt7 = rst.MazdaUOEStockCnt7;	// UOE在庫数７（マツダ）
                    jnl.UOEDistributionCd = rst.UOEDistributionCd;	// UOE卸コード
                    jnl.UOEOtherCd = rst.UOEOtherCd;	// UOE他コード
                    jnl.UOEHMCd = rst.UOEHMCd;	// UOEＨＭコード
                    jnl.BOCount = rst.BOCount;	// ＢＯ数
                    jnl.UOEMarkCode = rst.UOEMarkCode;	// UOEマークコード
                    jnl.SourceShipment = rst.SourceShipment;	// 出荷元
                    jnl.ItemCode = rst.ItemCode;	// アイテムコード
                    jnl.UOECheckCode = rst.UOECheckCode;	// UOEチェックコード
                    jnl.HeadErrorMassage = rst.HeadErrorMassage;	// ヘッドエラーメッセージ
                    jnl.LineErrorMassage = rst.LineErrorMassage;	// ラインエラーメッセージ
                    jnl.DataSendCode = rst.DataSendCode;	// データ送信区分
                    jnl.DataRecoverDiv = rst.DataRecoverDiv;	// データ復旧区分
                    jnl.EnterUpdDivSec = rst.EnterUpdDivSec;	// 入庫更新区分（拠点）
                    jnl.EnterUpdDivBO1 = rst.EnterUpdDivBO1;	// 入庫更新区分（BO1）
                    jnl.EnterUpdDivBO2 = rst.EnterUpdDivBO2;	// 入庫更新区分（BO2）
                    jnl.EnterUpdDivBO3 = rst.EnterUpdDivBO3;	// 入庫更新区分（BO3）
                    jnl.EnterUpdDivMaker = rst.EnterUpdDivMaker;	// 入庫更新区分（ﾒｰｶｰ）
                    jnl.EnterUpdDivEO = rst.EnterUpdDivEO;	// 入庫更新区分（EO）
                    jnl.DtlRelationGuid = rst.DtlRelationGuid;	// 明細関連付けGUID

					list.Add(jnl);
				}
			}
			catch (Exception)
			{
				list.Clear();
			}
			return list;
		}
		# endregion
		# endregion
		# endregion
	}
}

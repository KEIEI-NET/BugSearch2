using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Collections;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// スーパースライダークラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : スライダーにて得意先や仕入伝票の検索・選択や他PG起動等を行います。</br>
	/// <br>Programmer : 980076　妻鳥　謙一郎</br>
	/// <br>Date       : 2006.03.07</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// <br>2006.03.28 men サンプル対応</br>
	/// <br>2006.04.05 men 伝票番号自動採番部品組み込み対応(SFCMN00221UI)</br>
	/// <br>2006.04.18 men Visual Studio 2005 対応</br>
	/// <br>2006.11.17 men ご提案シート起動 対応</br>
	/// <br>2007.10.12 21024 携帯版をDC.NS版に変更</br>
    /// <br></br>
    /// <br>Update Note: 2008.04.24 20056 對馬 大輔</br>
    ///	<br>		   : PM.NS 共通修正 得意先・仕入先分離対応</br>
	/// <br></br>
	/// <br>Update Note: 2008.05.22 21024 佐々木 健</br>
	///	<br>		   : 得意先・仕入先分離対応</br>
    /// <br></br>
    /// <br>Update Note: 2008.09.18 21024 佐々木 健</br>
    ///	<br>		   : 仕入伝票新規作成処理の追加</br>
    /// <br></br>
    /// <br>Update Note: 2008.11.06 21024 佐々木 健</br>
    ///	<br>		   : PM.NS用に画面を変更（コメント無し）</br>
    /// <br></br>
    /// <br>Update Note: 2014/11/01 譚洪</br>
    /// <br>管理番号   : 11070149-00</br>
    /// <br>           : 仕掛一覧№2200 redmine #43864 追加対応</br>
    /// <br>           : ハンドルエラーが出る障害の修正</br>
    /// <br>Update Note: 2015/02/04 譚洪</br>
    /// <br>管理番号   : 11070149-00</br>
    /// <br>           : 仕掛一覧№2200 redmine #43864 追加対応</br>
    /// <br>           : ハンドルエラーが出る障害の再修正</br>
    /// <br></br>
    /// <br>Update Note: 2015/02/06 30757 佐々木 貴英</br>
    /// <br>管理番号   : 11070149-00</br>
    /// <br>           : 仕掛一覧№2200 redmine #43864 追加対応</br>
    /// <br>           : 受入テスト障害対応①：新規ボタン押下時に最近使った仕入先がクリアされる不具合対応</br>
    /// <br>           : 受入テスト障害対応②：タスクメニューペインの戻る/進むボタン遷移不正対応</br>
    /// <br></br>
    /// <br>Update Note: 2015/02/26 30940 河原林 一生</br>
    /// <br>管理番号   : 11070149-00</br>
    /// <br>           : 仕掛一覧№2200 タスクメニュー表示不正対応</br>
    /// <br></br>
    /// </remarks>
	public partial class SFCMN00221UA : System.Windows.Forms.Form
	{
		// ===================================================================================== //
		// スーパースライダークラスのデフォルトコンストラクタ
		// ===================================================================================== //
		# region Constructor
		/// <summary>
		/// スーパースライダークラスコンストラクタ
		/// </summary>
		public SFCMN00221UA()
		{
			// Windows フォーム デザイナ サポートに必要です。
			InitializeComponent();

			// 変数初期化(SFCMN00221UFとSFCMN00221UIのみコンストラクタ内で初期化する）
			this._customerSearchRet = new CustomerSearchRet();							// 得意先検索結果クラス
			this._searchRetStockSlip = new SearchRetStockSlip();						// 仕入伝票検索結果クラス
			this._param = new SFCMN00221UAParam();
			this._controlScreenSkin = new ControlScreenSkin();
			this._controlScreenSkin.LoadSkin();

			this._topMenuForm = new SFCMN00221UF(this._controlScreenSkin);
			this._stockSlipSearchForm = new SFCMN00221UI(this._controlScreenSkin);
			_commonLib = new SliderCommonLib(Encoding.GetEncoding("Shift_JIS"));

			this._controlScreenSkin.SettingScreenSkin(this);
			//this._controlScreenSkin.SettingScreenSkin(this._topMenuForm);
			//this._controlScreenSkin.SettingScreenSkin(this._stockSlipSearchForm);
		}

		/// <summary>
		/// スーパースライダーコンストラクタ
		/// </summary>
		/// <param name="param">起動パラメータ</param>
		public SFCMN00221UA(SFCMN00221UAParam param) : this()
		{
			// 変数初期化
			this._param = param;
		}

        // --- ADD 譚洪 2015/02/04 ------ >>>
        /// <summary>
        /// 初期化メッソド（コンポ－ネント除く）
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕掛一覧№2200 redmine #43864 追加対応</br>
        /// <br>             コンポーネントハンドル生成エラー対応（再）</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2015/02/04 </br>
        /// <br></br>
        /// <br>Update Note: 2015/02/06 30757 佐々木 貴英</br>
        /// <br>管理番号   : 11070149-00</br>
        /// <br>           : 仕掛一覧№2200 redmine #43864 追加対応</br>
        /// <br>           : 受入テスト障害対応①：新規ボタン押下時に最近使った仕入先がクリアされる不具合対応</br>
        /// <br>           : 受入テスト障害対応②：タスクメニューペインの戻る/進むボタン遷移不正対応</br>
        /// <br></br>
        /// </remarks>
        public void InitForNoComponent()
        {
            this._topMenuForm.InitForNoComponent();
            this._stockSlipSearchForm.InitForNoComponent();

            // --- DEL 30757 佐々木 貴英 2015/02/06 受入テスト障害対応①：新規ボタン押下時に最近使った仕入先がクリアされる不具合対応------ >>>
            //this._customerSearchRetRecordList = new List<CustomerSearchRet>();
            //this._supplierSearchRetRecordList = new List<Supplier>();							// 2008.05.22 Add
            //this._stockSlipRecordList = new List<SearchRetStockSlip>();
            // --- DEL 30757 佐々木 貴英 2015/02/06 受入テスト障害対応①：新規ボタン押下時に最近使った仕入先がクリアされる不具合対応------ <<<
            // --- ADD 30757 佐々木 貴英 2015/02/06 受入テスト障害対応①：新規ボタン押下時に最近使った仕入先がクリアされる不具合対応------ >>>
            if (null == this._customerSearchRetRecordList)
            {
                this._customerSearchRetRecordList = new List<CustomerSearchRet>();
            }
            if (null == this._supplierSearchRetRecordList)
            {
                this._supplierSearchRetRecordList = new List<Supplier>();
            }
            if (null == this._stockSlipRecordList)
            {
                this._stockSlipRecordList = new List<SearchRetStockSlip>();
            }
            // --- ADD 30757 佐々木 貴英 2015/02/06 受入テスト障害対応①：新規ボタン押下時に最近使った仕入先がクリアされる不具合対応------ <<<
            // --- DEL 30757 佐々木 貴英 2015/02/06 受入テスト障害対応②：タスクメニューペインの戻る/進むボタン遷移不正対応------ >>>
            //this._panelChangeRecordList = new List<PanelChangeRecord>();
            //this._panelChangeRecordListIndex = 0;
            // --- DEL 30757 佐々木 貴英 2015/02/06 受入テスト障害対応②：タスクメニューペインの戻る/進むボタン遷移不正対応------ <<<
            // --- ADD 30757 佐々木 貴英 2015/02/06 受入テスト障害対応②：タスクメニューペインの戻る/進むボタン遷移不正対応------ >>>
            if (null == this._panelChangeRecordList)
            {
                this._panelChangeRecordList = new List<PanelChangeRecord>();
                this._panelChangeRecordListIndex = 0;
            }
            // --- ADD 30757 佐々木 貴英 2015/02/06 受入テスト障害対応②：タスクメニューペインの戻る/進むボタン遷移不正対応------ <<<
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;							// 企業コードを取得

            // --- DEL 30940 河原林 一生 2015/02/26 タスクメニューの表示不正対応 -----------------------------<<<<<<<
            // 初期処理(初期値設定XML読み込み等)
            //this.LoadInitialData();
            // --- DEL 30940 河原林 一生 2015/02/26 タスクメニューの表示不正対応 ----------------------------->>>>>>>

            this._topMenuForm.CustomerSearchRetRecordList = this._customerSearchRetRecordList;					// 最近選択した得意先車両情報
            this._topMenuForm.SupplierSearchRetRecordList = this._supplierSearchRetRecordList;					// 最近選択した仕入先車両情報
            this._topMenuForm.StockSlipRecordList = this._stockSlipRecordList;									// 最近選択した仕入伝票情報
            this._topMenuForm.LuncherTopMenuInfoArray = this._luncherTopMenuInfoArray;							// ランチャートップメニュー情報
            this._customerMenuForm.LuncherStartAssemblyInfoArray = this._luncherStartAssemblyInfoArray;			// ランチャー表示アセンブリ情報(得意先車両検索)
            this._stockSlipMenuForm.OdrLuncherStartAssemblyInfoArray = this._odrLuncherStartAssemblyInfoArray;	// ランチャー表示アセンブリ情報(仕入伝票検索)
        }
        // --- ADD 譚洪 2015/02/04 ------ <<<
		# endregion

		// ===================================================================================== //
		// インナークラス
		// ===================================================================================== //
		# region Inner Class
		/// <summary>
		/// パネル表示履歴クラス
		/// </summary>
		private class PanelChangeRecord
		{
			private int _dispNo;

			/// <summary>
			/// パネル表示履歴クラスコンストラクタ
			/// </summary>
			/// <param name="dispNo">パネル表示番号</param>
			public PanelChangeRecord(int dispNo)
			{
				this._dispNo = dispNo;
			}

			/// <summaryパネル表示番号</summary>
			public int DispNo
			{
				get
				{
					return this._dispNo;
				}
				set
				{
					this._dispNo = value;
				}
			}
		}
		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		private string _xmlNoString = "";
		private int _xmlNo = 0;
		private List<CustomerSearchRet> _customerSearchRetRecordList;					// 最近選択した得意先情報
		// 2008.05.22 Update >>>
		//private List<CustomerSearchRet> _supplierSearchRetRecordList;					// 最近選択した仕入先情報
		private List<Supplier> _supplierSearchRetRecordList;							// 最近選択した仕入先情報
		// 2008.05.22 Update <<<
		private List<SearchRetStockSlip> _stockSlipRecordList;							// 最近選択した仕入伝票情報
		private LuncherTopMenuInfo[] _luncherTopMenuInfoArray;							// ランチャートップメニュー情報
		private LuncherStartAssemblyInfo[] _luncherStartAssemblyInfoArray;				// ランチャー表示アセンブリ情報(得意先検索)
		private LuncherStartAssemblyInfo[] _odrLuncherStartAssemblyInfoArray;			// ランチャー表示アセンブリ情報(仕入伝票検索)
		private SFCMN00221UF _topMenuForm;												// トップメニューフォーム
		private SFCMN00221UI _stockSlipSearchForm;										// 仕入伝票検索フォーム
		private SFCMN00221UJ _customerMenuForm;											// 得意先情報表示フォーム
		private SFCMN00221UK _stockSlipMenuForm;										// 仕入伝票情報表示フォーム
		private SFCMN00221UM _customerSearchForm;										// 得意先検索フォーム
		private SFCMN00221UQ _supplierSearchForm;										// 仕入先検索フォーム 2008.05.22 Add
		private List<PanelChangeRecord> _panelChangeRecordList;							// 画面表示履歴クラスリスト
		private int _panelChangeRecordListIndex;										// 画面表示履歴クラスリスト位置
		private Panel _displayPanel;													// 表示中パネル
		private string _enterpriseCode = "";											// 企業コード
		private CustomerSearchRet _customerSearchRet;									// 得意先検索結果クラス
		private Supplier _supplierSearchRet;											// 仕入先マスタクラス 2008.05.22 Add
		private SearchRetStockSlip _searchRetStockSlip;									// 仕入伝票検索結果クラス
		private static AlItmDspNm _alItmDspNm;											// 全体項目表示設定クラス
		private SFCMN00221UAParam _param;												// スーパースライダー起動パラメータ
		private string _customerInitialDataFilePath = Path.Combine(ConstantManagement_ClientDirectory.Temp_UserTemp, DATFILE_INITIALDATA_CUSTOMER);
		private string _supplierInitialDataFilePath = Path.Combine(ConstantManagement_ClientDirectory.Temp_UserTemp, DATFILE_INITIALDATA_SUPPLIER);
		private string _stockSlipInitialDataFilePath = Path.Combine(ConstantManagement_ClientDirectory.Temp_UserTemp, DATFILE_INITIALDATA_STOCKSLIP);
		private static SliderCommonLib _commonLib;
		private ControlScreenSkin _controlScreenSkin;
		# endregion

		// ===================================================================================== //
		// 内部で使用する定数郡
		// ===================================================================================== //
		# region const
		private const string RECORD_KEY_CUSTOMERCAR = "CustomerRecord";
		private const string RECORD_KEY_ACCEPTORDER = "AcceptOrderRecord";
		private const string DATFILE_INITIALDATA_CUSTOMER = "SFCMN00221U_CustomerData.DAT";
		private const string DATFILE_INITIALDATA_SUPPLIER = "SFCMN00221U_SupplierData.DAT";
		private const string DATFILE_INITIALDATA_STOCKSLIP = "SFCMN00221U_StockSlipData.DAT";
		private const string XML_FILE_TOPMENU_INFO = "SFCMN00221U_TopMenuInfo";
		private const string XML_FILE_EXTENSION = ".XML";
		private const string XML_FILE_ASSEMBLY_INFO = "SFCMN00221U_StartAssemblyInfo";
		private const string XML_FILE_STOCKSLIP_LUNCHER_INFO = "SFCMN00221U_StockSlipLuncherInfo";

		internal const int FORM_STATUS_Top = 0;								// TOPメニュー
		internal const int FORM_STATUS_FindCustomer = 1;					// 得意先検索画面
		internal const int FORM_STATUS_CustomerLuncher = 2;					// 得意先ランチャー画面
		internal const int FORM_STATUS_StockSlipLuncher = 3;				// 仕入伝票ランチャー画面
		internal const int FORM_STATUS_FindSupplier = 4;					// 仕入先検索画面
		internal const int FORM_STATUS_FindStockSlip = 5;					// 仕入伝票検索画面
		internal const int FORM_STATUS_FindReceiptSlip = 6;					// 入荷伝票検索画面

		// ランチャーモード定数定義
		internal const int LuncherMode_CustomerChange = 1;
		internal const int LuncherMode_SupplierChange = 2;					// 仕入先の修正 2008.05.22 Add
		internal const int LuncherMode_SlipSetCustomer = 4;					// 得意先を伝票に反映する
		internal const int LuncherMode_StockSlipSearch = 5;
		internal const int LuncherMode_CustomerView = 6;
		internal const int LuncherMode_CustomerNew = 8;
		internal const int LuncherMode_ModifyStockSlip = 10;
		internal const int LuncherMode_SlipAbuild = 11;						// 赤作成
		internal const int LuncherMode_TrustAppropriate = 12;				// 入荷計上
		internal const int LuncherMode_SlipCopy = 25;						// 伝票コピー
		internal const int LuncherMode_NewSlipSetSupplier = 41;				// 選択中の仕入先で伝票を新規作成する
		internal const int LuncherMode_SlipSetSupplier = 42;				// 選択中の仕入先を伝票に反映する
		internal const int LuncherMode_Blank = 98;							// 空白行
		internal const int LuncherMode_Separator = 99;						// セパレータ

		public const int TOP_MODE_CustomerSearch = 1;			// 得意先検索
		public const int TOP_MODE_SupplierSearch = 2;			// 仕入先検索
		public const int TOP_MODE_NewSlip = 3;					// 新規伝票作成
		public const int TOP_MODE_SelectCustomer = 4;			// 得意先の選択
		public const int TOP_MODE_SelectStockSlip = 5;			// 仕入伝票の選択		
		public const int TOP_MODE_NewCustomer = 6;				// 得意先の新規作成
		public const int TOP_MODE_StockSlipSearch = 7;			// 仕入伝票検索
        public const int TOP_MODE_NewStockSlip = 8;             // 仕入伝票新規作成　   // 2008.09.18 Add
	

		internal const string MESSAGE_CONDITION_CLEAR = "右クリックでクリアすることが出来ます";
		# endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Priperties
		/// <summary>
		/// 最近参照した得意先表示プロパティ
		/// </summary>
		public bool CustomerListShow
		{
			get
			{
				return this._topMenuForm.CustomerListShow;
			}
			set
			{
				this._topMenuForm.CustomerListShow = value;
			}
		}

		/// <summary>
		/// 最近参照した仕入伝票表示プロパティ
		/// </summary>
		public bool StockSlipListShow
		{
			get
			{
				return this._topMenuForm.StockSlipListShow;
			}
			set
			{
				this._topMenuForm.StockSlipListShow = value;
			}
		}

		/// <summary>
		/// スライダー用共通ライブラリクラスプロパティ
		/// </summary>
		internal static SliderCommonLib CommonLib
		{
			get { return SFCMN00221UA._commonLib; }
		}
		# endregion

		// ===================================================================================== //
		// イベント
		// ===================================================================================== //
		# region Event
		public event CreateNewSlipHandler CreateNewSlip;
		public event CreateNewSlipUsedSupplierHandler CreateNewSlipUsedSupplier;	// 2008.05.22 Add
		public event ModifyStockSlipHandler ModifyStockSlip;
		public event SelectedCustomerHandler SelectedCustomer;
		public event SelectedSupplierHandler SelectedSupplier;						// 2008.05.22 Add
		public event ModifyStockSlipHandler RedWriteStockSlip;
		public event ModifyStockSlipHandler TrustAppropriateStockSlip;
		// 2007.10.12 sasaki >>
		public event ModifyStockSlipHandler SlipCopy;
		// 2007.10.12 sasaki <<
		# endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		# region Public Methods
		/// <summary>
		/// メインパネル取得処理(初期値XML指定タイプ)
		/// </summary>
		/// <param name="dataInputSystem">起動モード： 0:全システム 1:整備のみ 2:鈑金のみ 3:車販のみ</param>
		/// <param name="xmlno">初期値XMLの番号： 指定した番号のXMLを初期値用XMLとして使用します</param>
		/// <returns>表示パネル：このパネルをドッキングエリアのパネルに設定してください</returns>
		/// <remarks>
		/// <br>Note       : 描画メインパネルを取得します。初期処理中に１回のみ行ってください。</br>
		/// <br>           : 第２パラメータを指定することで初期値XMLを指定することが可能です。</br>
		/// <br>Programmer : 980076　妻鳥　謙一郎</br>
		/// <br>Date       : 2006.03.07</br>
		/// </remarks>
		public Panel GetMainPanel(int dataInputSystem)
		{
			return this.GetMainPanel(dataInputSystem, 0);
		}

		/// <summary>
		/// メインパネル取得処理(初期値XML指定タイプ)
		/// </summary>
		/// <param name="mode">起動モード： 現在未使用</param>
		/// <param name="xmlno">初期値XMLの番号： 指定した番号のXMLを初期値用XMLとして使用します</param>
		/// <returns>表示パネル：このパネルをドッキングエリアのパネルに設定してください</returns>
		/// <remarks>
		/// <br>Note       : 描画メインパネルを取得します。初期処理中に１回のみ行ってください。</br>
		/// <br>           : 第２パラメータを指定することで初期値XMLを指定することが可能です。</br>
		/// <br>Programmer : 980076　妻鳥　謙一郎</br>
		/// <br>Date       : 2006.03.07</br>
		/// </remarks>
		public Panel GetMainPanel(int mode, int xmlNo)
		{
			this._param.XmlNo = xmlNo;
			return this.GetMainPanel();
		}

		/// <summary>
		/// メインパネル取得処理
		/// </summary>
		public Panel GetMainPanel()
		{
			// XMLファイル番号設定
			if (this._param.XmlNo == 0)
			{
				this._xmlNoString = "";
			}
			else
			{
				this._xmlNoString = this._param.XmlNo.ToString();
			}

			// XML番号を退避
			this._xmlNo = this._param.XmlNo;

			this.timer_Initial.Enabled = true;

			this.panel_Main.Enabled = true;

			return this.panel_Main;
		}

		/// <summary>
		/// 検索画面終了処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 検索画面終了時に呼び出してください。データの保存等を行います</br>
		/// <br>Programmer : 980076　妻鳥　謙一郎</br>
		/// <br>Date       : 2006.03.07</br>
		/// </remarks>
		public void ClosePanel()
		{
			// 初期値情報を保存する
			this.SaveInitialData();
		}

        // --- DEL 譚洪 2015/02/04 ------ >>>
        // --- ADD 譚洪 2014/11/01 ------ >>>
        /// <summary>
        /// リリース処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : リリース処理を行います</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2014/11/01</br>
        /// </remarks>
        //public void DisposeForm()
        //{
        //    this._topMenuForm.Dispose();
        //    this._topMenuForm = null;

        //    this._stockSlipSearchForm.DisposeForm();
        //    this._stockSlipSearchForm.Dispose();
        //    this._stockSlipSearchForm = null;
        //}
        // --- ADD 譚洪 2014/11/01 ------ <<<
        // --- DEL 譚洪 2015/02/04 ------ <<<
		# endregion

		// ===================================================================================== //
		// インターナルメソッド
		// ===================================================================================== //
		# region Internal Methods
		/// <summary>
		/// 全体項目表示名称マスタ取得処理
		/// </summary>
		/// <param name="alItmDspNm">全体項目表示名称マスタ</param>
		/// <returns>ステータス</returns>
		internal static int GetAlItmDspNm(out AlItmDspNm alItmDspNm)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			if (_alItmDspNm != null)
			{
				alItmDspNm = _alItmDspNm;
				return status;
			}

			//alItmDspNm = EntryCommonInitDataAcs.AlItmDspNm;	// 仮
			alItmDspNm = null;									// 仮

			if (alItmDspNm == null)
			{
				// 表示名称設定
				AlItmDspNmAcs alItmDspNmAcs = new AlItmDspNmAcs();
				status = alItmDspNmAcs.ReadStatic(out alItmDspNm, LoginInfoAcquisition.EnterpriseCode);

				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					status = alItmDspNmAcs.Read(out alItmDspNm, LoginInfoAcquisition.EnterpriseCode);
				}
			}

			if (alItmDspNm == null) status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			_alItmDspNm = alItmDspNm;

			return status;
		}

		/// <summary>
		/// 追加情報表示名称取得処理
		/// </summary>
		/// <param name="no">№</param>
		/// <returns>追加情報表示名称</returns>
		internal static string GetAddInfoDspName(int no)
		{
			string addInfoDspName = "";

			AlItmDspNm alItmDspNm;
			if (GetAlItmDspNm(out alItmDspNm) == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				switch (no)
				{
					case 1:
					{
						addInfoDspName = alItmDspNm.AddInfo1DspName;
						break;
					}
					case 2:
					{
						addInfoDspName = alItmDspNm.AddInfo2DspName;
						break;
					}
					case 3:
					{
						addInfoDspName = alItmDspNm.AddInfo3DspName;
						break;
					}
				}
			}

			return addInfoDspName;
		}

		/// <summary>
		/// 電話番号表示名称取得処理
		/// </summary>
		/// <param name="no">№</param>
		/// <returns>電話番号表示名称</returns>
		internal static string GetTelNoDspName(int no)
		{
			string telNoDspName = "";

			AlItmDspNm alItmDspNm;
			if (GetAlItmDspNm(out alItmDspNm) == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				switch (no)
				{
					case 0:
					{
						telNoDspName = alItmDspNm.HomeTelNoDspName;
						break;
					}
					case 1:
					{
						telNoDspName = alItmDspNm.OfficeTelNoDspName;
						break;
					}
					case 2:
					{
						telNoDspName = alItmDspNm.MobileTelNoDspName;
						break;
					}
					case 3:
					{
						telNoDspName = alItmDspNm.HomeFaxNoDspName;
						break;
					}
					case 4:
					{
						telNoDspName = alItmDspNm.OfficeFaxNoDspName;
						break;
					}
					case 5:
					{
						telNoDspName = alItmDspNm.OtherTelNoDspName;
						break;
					}
				}
			}

			return telNoDspName;
		}

		/// <summary>
		/// オプション導入チェック処理
		/// </summary>
		/// <param name="softwareCode">オプションコード</param>
		/// <returns>true:導入済み false:未導入</returns>
		internal static bool OptionCheckForUSB(string softwareCode)
		{
			if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(softwareCode) > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		# endregion

		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods
		/// <summary>
		/// 変数初期化処理
		/// </summary>
		private void InitializeMembers()
		{
			this._customerMenuForm = new SFCMN00221UJ(this._controlScreenSkin);
			this._stockSlipMenuForm = new SFCMN00221UK(this._controlScreenSkin);
			this._customerSearchForm = new SFCMN00221UM(this._controlScreenSkin);
			this._supplierSearchForm = new SFCMN00221UQ(this._controlScreenSkin);				// 2008.05.22 Add
			this._customerSearchRetRecordList = new List<CustomerSearchRet>();
			this._supplierSearchRetRecordList = new List<Supplier>();							// 2008.05.22 Add
			this._stockSlipRecordList = new List<SearchRetStockSlip>();
			this._panelChangeRecordList = new List<PanelChangeRecord>();
			this._panelChangeRecordListIndex = 0;
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;							// 企業コードを取得

			this._topMenuForm.PanelChange += new PanelChangeEventHandler(this.ChildForm_PanelChange);
			this._topMenuForm.TopMenuSelect += new TopMenuSelectEventHandler(this.TopMenuForm_TopMenuSelect);
			this._topMenuForm.CustomerSelected += new CustomerSelectedHandler(this.CustomerSearchForm_CustomerSelected);
			this._topMenuForm.SupplierSelected += new SupplierSelectedHandler(this.SupplierSearchForm_SupplierSelected);	// 2008.05.22 Add
			this._topMenuForm.StockSlipSelected += new SearchRetStockSlipSelectedHandler(this.StockSlipSearchForm_searchRetStockSlipSelected);

			this._customerSearchForm.PanelChange += new PanelChangeEventHandler(this.ChildForm_PanelChange);
			this._customerSearchForm.CustomerSelected += new CustomerSelectedHandler(this.CustomerSearchForm_CustomerSelected);

			// 2008.05.22 Add >>>
			this._supplierSearchForm.PanelChange += new PanelChangeEventHandler(this.ChildForm_PanelChange);
			this._supplierSearchForm.SupplierSelected += new SupplierSelectedHandler(this.SupplierSearchForm_SupplierSelected);
			// 2008.05.22 Add <<<

			this._stockSlipSearchForm.PanelChange += new PanelChangeEventHandler(this.ChildForm_PanelChange);
			this._stockSlipSearchForm.SearchRetStockSlipSelected += new SearchRetStockSlipSelectedHandler(this.StockSlipSearchForm_searchRetStockSlipSelected);

			this._customerMenuForm.LuncherStart += new LuncherStartEventHandler(this.MenuForm_LuncherStart);
			this._stockSlipMenuForm.LuncherStart += new LuncherStartEventHandler(this.MenuForm_LuncherStart);

			//this._controlScreenSkin.SettingScreenSkin(this._customerMenuForm);
			//this._controlScreenSkin.SettingScreenSkin(this._stockSlipMenuForm);
			//this._controlScreenSkin.SettingScreenSkin(this._customerSearchForm);
		}

		/// <summary>
		/// 初期処理(初期値設定XML読み込み等)
		/// </summary>
		private void LoadInitialData()
		{
			// 最近参照した得意先ファイルの読込み(XML)
			try
			{
				CustomerSearchRet[] customerSearchRetArray = new CustomerSearchRet[0];

				if (UserSettingController.ExistUserSetting(this._customerInitialDataFilePath))
				{
					customerSearchRetArray = UserSettingController.DecryptionDeserializeUserSetting<CustomerSearchRet[]>(this._customerInitialDataFilePath, new string[] { this.GetType().FullName, DATFILE_INITIALDATA_CUSTOMER });
				}

				this._customerSearchRetRecordList.AddRange(customerSearchRetArray);
			}
			catch
			{
				try
				{
					UserSettingController.DeleteUserSetting(this._customerInitialDataFilePath);
				}
				catch { }
			}

			// 最近参照した仕入先ファイルの読込み(XML)
			try
			{
				// 2008.05.22 Update >>>
				//CustomerSearchRet[] supplierSearchRetArray = new CustomerSearchRet[0];

				//if (UserSettingController.ExistUserSetting(this._supplierInitialDataFilePath))
				//{
				//    supplierSearchRetArray = UserSettingController.DecryptionDeserializeUserSetting<CustomerSearchRet[]>(this._supplierInitialDataFilePath, new string[] { this.GetType().FullName, DATFILE_INITIALDATA_SUPPLIER });
				//}

				//this._supplierSearchRetRecordList.AddRange(supplierSearchRetArray);

				Supplier[] supplierSearchRetArray = new Supplier[0];

				if (UserSettingController.ExistUserSetting(this._supplierInitialDataFilePath))
				{
					supplierSearchRetArray = UserSettingController.DecryptionDeserializeUserSetting<Supplier[]>(this._supplierInitialDataFilePath, new string[] { this.GetType().FullName, DATFILE_INITIALDATA_SUPPLIER });
				}

				this._supplierSearchRetRecordList.AddRange(supplierSearchRetArray);

				// 2008.05.22 Update <<<
			}
			catch
			{
				try
				{
					UserSettingController.DeleteUserSetting(this._supplierInitialDataFilePath);
				}
				catch { }
			}

			// 最近参照した仕入伝票ファイルの読込み(XML)
			try
			{
				SearchRetStockSlip[] stockSlipArray = new SearchRetStockSlip[0];

				if (UserSettingController.ExistUserSetting(this._stockSlipInitialDataFilePath))
				{
					stockSlipArray = UserSettingController.DecryptionDeserializeUserSetting<SearchRetStockSlip[]>(this._stockSlipInitialDataFilePath, new string[] { this.GetType().FullName, DATFILE_INITIALDATA_STOCKSLIP });
				}

				this._stockSlipRecordList.AddRange(stockSlipArray);
			}
			catch
			{
				try
				{
					UserSettingController.DeleteUserSetting(this._stockSlipInitialDataFilePath);
				}
				catch { }
			}

			// TOPメニュー情報をXMLより読み出す
			// タブ追加アセンブリ定義ファイルの読込み(XML)
			try
			{
				System.IO.FileStream fs = new System.IO.FileStream(XML_FILE_TOPMENU_INFO + this._xmlNoString + XML_FILE_EXTENSION, System.IO.FileMode.Open, System.IO.FileAccess.Read);
				System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(LuncherTopMenuInfo[]));
				this._luncherTopMenuInfoArray = (LuncherTopMenuInfo[])serializer.Deserialize(fs);
				fs.Close();
			}
			catch (Exception e)
			{
				TMsgDisp.Show(
					Form.ActiveForm,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					e.Message,
					-1,
					MessageBoxButtons.OK);
			}

			// ランチャーメニュー情報をXMLより読み出す
			// タブ追加アセンブリ定義ファイルの読込み(XML)
			try
			{
				System.IO.FileStream fs = new System.IO.FileStream(XML_FILE_ASSEMBLY_INFO + this._xmlNoString + XML_FILE_EXTENSION, System.IO.FileMode.Open, System.IO.FileAccess.Read);
				System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(LuncherStartAssemblyInfo[]));
				this._luncherStartAssemblyInfoArray = (LuncherStartAssemblyInfo[])serializer.Deserialize(fs);
				fs.Close();
			}
			catch(Exception e)
			{
				TMsgDisp.Show(
					Form.ActiveForm,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					e.Message,
					-1,
					MessageBoxButtons.OK);
			}

			// ランチャーメニュー情報をXMLより読み出す
			// タブ追加アセンブリ定義ファイルの読込み(XML)
			try
			{
				System.IO.FileStream fs = new System.IO.FileStream(XML_FILE_STOCKSLIP_LUNCHER_INFO + this._xmlNoString + XML_FILE_EXTENSION, System.IO.FileMode.Open, System.IO.FileAccess.Read);
				System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(LuncherStartAssemblyInfo[]));
				this._odrLuncherStartAssemblyInfoArray = (LuncherStartAssemblyInfo[])serializer.Deserialize(fs);
				fs.Close();
			}
			catch(Exception)
			{
				/*
				TMsgDisp.Show(
					Form.ActiveForm,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					e.Message,
					-1,
					MessageBoxButtons.OK);
				*/
			}
		}

		/// <summary>
		/// 初期表示用XML（最新の得意先情報）保存処理
		/// </summary>
		private void SaveInitialData()
		{
			// 起動初期データXML書き込み
			try
			{
				// 最近参照した得意先ファイルの書き込み(XML)
				if (this._customerSearchRetRecordList != null)
				{
					CustomerSearchRet[] customerSearchRetArray = this._customerSearchRetRecordList.ToArray();
					UserSettingController.EncryptionSerializeUserSetting(customerSearchRetArray, this._customerInitialDataFilePath, new string[] { this.GetType().FullName, DATFILE_INITIALDATA_CUSTOMER });
				}

				// 最近参照した仕入先ファイルの書き込み(XML)
				if (this._supplierSearchRetRecordList != null)
				{
					// 2008.05.22 Update >>>
					//CustomerSearchRet[] supplierSearchRetArray = this._supplierSearchRetRecordList.ToArray();
					Supplier[] supplierSearchRetArray = this._supplierSearchRetRecordList.ToArray();
					// 2008.05.22 Update <<<
					UserSettingController.EncryptionSerializeUserSetting(supplierSearchRetArray, this._supplierInitialDataFilePath, new string[] { this.GetType().FullName, DATFILE_INITIALDATA_SUPPLIER });
				}

				// 最近参照した仕入伝票ファイルの書き込み(XML)
				if (this._stockSlipRecordList != null)
				{
					SearchRetStockSlip[] searchRetStockSlipArray = this._stockSlipRecordList.ToArray();
					UserSettingController.EncryptionSerializeUserSetting(searchRetStockSlipArray, this._stockSlipInitialDataFilePath, new string[] { this.GetType().FullName, DATFILE_INITIALDATA_STOCKSLIP });
				}

				// 仕入伝票検索の列表示状態クラス保存処理
                if (this._stockSlipSearchForm != null)
                {
                    this._stockSlipSearchForm.SaveColDisplayStatus();
                }

				// 得意先検索の列表示状態クラス保存処理
                if (this._customerSearchForm != null)
                {
                    this._customerSearchForm.SaveColDisplayStatus();
                }

				// 2008.05.22 Add >>>
				// 仕入先検索の列表示状態クラス保存処理
                if (this._supplierSearchForm != null)
                {
                    this._supplierSearchForm.SaveColDisplayStatus();
                }
				// 2008.05.22 Add <<<
			}
			catch(Exception ex)
			{
				TMsgDisp.Show(
					Form.ActiveForm,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					ex.Message,
					-1,
					MessageBoxButtons.OK);
			}
		}

		/// <summary>
		/// 画面初期表示設定処理
		/// </summary>
		private void DisplayInitialSetting()
		{
			// イメージアイコン設定処理
			ImageList imglist = IconResourceManagement.ImageList16;
			this.uButton_Before.Appearance.Image = imglist.Images[(int)Size16_Index.BEFORE];		// 前へボタン
			this.uButton_Next.Appearance.Image	= imglist.Images[(int)Size16_Index.NEXT];			// 次へボタン
			this.uButton_Home.Appearance.Image	= imglist.Images[(int)Size16_Index.MAIN];			// ホームボタン

			this._topMenuForm.CustomerListShow = this._param.ShowCustomerList;
			this._topMenuForm.StockSlipListShow = this._param.ShowStockSlipList;
		}

		/// <summary>
		/// 最近選択した得意先情報リスト追加処理
		/// </summary>
		/// <param name="customerSearchRet">得意先検索結果クラス</param>
		private void CustomerSearchRetRecordListAdd(CustomerSearchRet settingInfo)
		{
			if (settingInfo.CustomerCode == 0) return;

			if (this._param.SupplierDiv == 1)
			{
				for (int i = 0; i < this._supplierSearchRetRecordList.Count; i++)
				{
					CustomerSearchRet customerSearchRet = this._customerSearchRetRecordList[i];

					if (settingInfo.CustomerCode == customerSearchRet.CustomerCode)
					{
						this._supplierSearchRetRecordList.RemoveAt(i);
						break;
					}
				}

				this._customerSearchRetRecordList.Add(settingInfo.Clone());

				// 最近の５件のみ残す
				if (this._supplierSearchRetRecordList.Count > 5)
				{
					this._supplierSearchRetRecordList.RemoveAt(0);
				}
			}
			else
			{
				for (int i = 0; i < this._customerSearchRetRecordList.Count; i++)
				{
					CustomerSearchRet customerSearchRet = this._customerSearchRetRecordList[i];

					if (settingInfo.CustomerCode == customerSearchRet.CustomerCode)
					{
						this._customerSearchRetRecordList.RemoveAt(i);
						break;
					}
				}

				this._customerSearchRetRecordList.Add(settingInfo.Clone());

				// 最近の５件のみ残す
				if (this._customerSearchRetRecordList.Count > 5)
				{
					this._customerSearchRetRecordList.RemoveAt(0);
				}
			}
		}

		// 2008.05.22 Add >>>
		/// <summary>
		/// 最近選択した仕入先情報リスト追加処理
		/// </summary>
		/// <param name="customerSearchRet">仕入先検索結果クラス</param>
		private void SupplierSearchRetRecordListAdd( Supplier settingInfo )
		{
			if (settingInfo.SupplierCd == 0) return;

			if (this._param.SupplierDiv == 1)
			{
				for (int i = 0; i < this._supplierSearchRetRecordList.Count; i++)
				{
					Supplier supplierSearchRet = this._supplierSearchRetRecordList[i];

					if (settingInfo.SupplierCd == supplierSearchRet.SupplierCd)
					{
						this._supplierSearchRetRecordList.RemoveAt(i);
						break;
					}
				}

				this._supplierSearchRetRecordList.Add(settingInfo.Clone());

				// 最近の５件のみ残す
				if (this._supplierSearchRetRecordList.Count > 5)
				{
					this._supplierSearchRetRecordList.RemoveAt(0);
				}
			}
			else
			{
				for (int i = 0; i < this._supplierSearchRetRecordList.Count; i++)
				{
					Supplier supplierSearchRet = this._supplierSearchRetRecordList[i];

					if (settingInfo.SupplierCd == supplierSearchRet.SupplierCd)
					{
						this._supplierSearchRetRecordList.RemoveAt(i);
						break;
					}
				}

				this._supplierSearchRetRecordList.Add(settingInfo.Clone());

				// 最近の５件のみ残す
				if (this._supplierSearchRetRecordList.Count > 5)
				{
					this._supplierSearchRetRecordList.RemoveAt(0);
				}
			}
		}		
		// 2008.05.22 Add <<<

		/// <summary>
		/// 最近選択した仕入伝票情報リスト追加処理
		/// </summary>
		/// <param name="stockSlip">仕入伝票結果クラス</param>
		private void StockSlipRecordListAdd(SearchRetStockSlip settingInfo)
		{
			if (settingInfo.SupplierSlipNo == 0) return;

			for (int i = 0; i < this._stockSlipRecordList.Count; i++)
			{
				SearchRetStockSlip searchRetStockSlip = this._stockSlipRecordList[i];

				if (settingInfo.SupplierSlipNo == searchRetStockSlip.SupplierSlipNo)
				{
					this._stockSlipRecordList.RemoveAt(i);
					break;
				}
			}

			this._stockSlipRecordList.Add(settingInfo);

			// 各システム単位に最大５件残す
			List<int> indexList = new List<int>();
			for (int i = 0; i < this._stockSlipRecordList.Count; i++)
			{
				indexList.Add(i);
			}

			if (indexList.Count > 5)
			{
				this._stockSlipRecordList.RemoveAt(indexList[0]);
			}
		}

		/// <summary>
		/// 子フォームパネル変更イベント用メソッド
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void ChildForm_PanelChange(object sender, PanelChangeEventArgs e)
		{
			if ((e.DispNo == FORM_STATUS_FindCustomer) ||
				(e.DispNo == FORM_STATUS_FindSupplier)) 
			{
				if (!LoginInfoAcquisition.OnlineFlag)
				{
					TMsgDisp.Show(
						Form.ActiveForm,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"オフラインモードの為、処理を行えません。",
						0,
						MessageBoxButtons.OK);

					return;
				}
			}

			// 画面表示履歴の更新処理
			if (e.RecodeUpdateMode == PanelChangeEventArgs.MODE_UPDATE)
			{
				if (this._panelChangeRecordList.Count > 0 && this._panelChangeRecordListIndex < this._panelChangeRecordList.Count)
				{
					this._panelChangeRecordList.RemoveRange(this._panelChangeRecordListIndex, this._panelChangeRecordList.Count - this._panelChangeRecordListIndex);
				}

				PanelChangeRecord panelChangeRecord = new PanelChangeRecord(e.DispNo);
				this._panelChangeRecordList.Add(panelChangeRecord);
				this._panelChangeRecordListIndex++;
			}

			// 次へボタンと前へボタンの表示・非表示
			if (this._panelChangeRecordListIndex > 1)
			{
				this.uButton_Before.Enabled = true;
			}
			else
			{
				this.uButton_Before.Enabled = false;
			}

			if (this._panelChangeRecordList.Count > this._panelChangeRecordListIndex)
			{
				this.uButton_Next.Enabled = true;
			}
			else
			{
				this.uButton_Next.Enabled = false;
			}

			if (this._displayPanel != null)
			{
				this.panel_Frame.Controls.Remove(this._displayPanel);
			}

			if (e.DispNo == FORM_STATUS_FindCustomer)
			{
				// 得意先検索画面へ
				this._displayPanel = this._customerSearchForm.panel_Main;

				// 仕入先指定のプロパティを初期化
				SFCMN00221UAParam param = this._param.Clone();
				param.SupplierDiv = 0;

				this._customerSearchForm.InitialSetting(param);
				this._customerSearchForm.PanelActivated();
			}
			else if (e.DispNo == FORM_STATUS_FindSupplier)
			{
				// 2008.05.22 Update >>>
				//// 得意先検索画面（仕入先指定）へ
				//this._displayPanel = this._customerSearchForm.panel_Main;

				//// 仕入先指定のプロパティを設定
				//SFCMN00221UAParam param = this._param.Clone();
				//param.SupplierDiv = 1;
				//this._customerSearchForm.InitialSetting(param);

				//this._customerSearchForm.PanelActivated();

				// 仕入先検索画面へ
				this._displayPanel = this._supplierSearchForm.panel_Main;

				// 仕入先指定のプロパティを設定
				SFCMN00221UAParam param = this._param.Clone();
				param.SupplierDiv = 1;
				this._supplierSearchForm.InitialSetting(param);

				this._supplierSearchForm.PanelActivated();
				// 2008.05.22 Update <<<

			}
			else if (e.DispNo == FORM_STATUS_FindStockSlip)
			{
				// 仕入伝票検索画面へ
				this._displayPanel = this._stockSlipSearchForm.panel_Main;
				this._stockSlipSearchForm.PanelActivated();
			}
			else if (e.DispNo == FORM_STATUS_CustomerLuncher)
			{
				// 2008.05.22 Update >>>
				// 選択得意先表示画面へ
				this._displayPanel = this._customerMenuForm.panel_Main;

				// 2008.05.22 Update >>>
				//// 最近選択した得意先情報リスト追加処理
				//this.CustomerSearchRetRecordListAdd(this._customerSearchRet);

				//this._customerMenuForm.CustomerSearchRet_Data = this._customerSearchRet;

				if (this._param.SupplierDiv == 1)
				{
					// 最近選択した仕入先情報リスト追加処理
					this.SupplierSearchRetRecordListAdd(this._supplierSearchRet);

					this._customerMenuForm.SupplierSearchRet_Data = this._supplierSearchRet;
				}
				else
				{
					// 最近選択した得意先情報リスト追加処理
					this.CustomerSearchRetRecordListAdd(this._customerSearchRet);

					this._customerMenuForm.CustomerSearchRet_Data = this._customerSearchRet;
				}
				// 2008.05.22 Update <<<

				this._customerMenuForm.InitialSetting(this._param);
			}
			else if (e.DispNo == FORM_STATUS_StockSlipLuncher)
			{
				// 選択仕入伝票表示画面へ
				this._displayPanel = this._stockSlipMenuForm.panel_Main;

				// 最近選択した仕入伝票情報リスト追加処理
				this.StockSlipRecordListAdd(this._searchRetStockSlip);

				this._stockSlipMenuForm.SearchRetStockSlip_Data = this._searchRetStockSlip;
				this._stockSlipMenuForm.InitialSetting(this._param);
			}
			else
			{
				// TOP画面へ
				this._displayPanel = this._topMenuForm.panel_Main;

				// 初期処理
				this._topMenuForm.InitialSetting(this._param);
			}

			this._displayPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_Frame.Controls.Add(this._displayPanel);
		}

		/// <summary>
		/// 得意先選択イベント用メソッド
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="customerSearchRet">得意先検索結果クラス</param>
		private void CustomerSearchForm_CustomerSelected(object sender, CustomerSearchRet customerSearchRet)
		{
			this._customerSearchRet = customerSearchRet.Clone();
		}

		// 2008.05.22 Add >>>
		/// <summary>
		/// 仕入先選択イベント用メソッド
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="customerSearchRet">仕入先マスタクラス</param>
		private void SupplierSearchForm_SupplierSelected( object sender, Supplier supplierSearchRet )
		{
			this._supplierSearchRet = supplierSearchRet.Clone();
		}
		// 2008.05.22 Add <<<

		/// <summary>
		/// 仕入伝票選択イベント用メソッド
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="searchRetStockSlip">得意先検索結果クラス</param>
		private void StockSlipSearchForm_searchRetStockSlipSelected(object sender, SearchRetStockSlip searchRetStockSlip)
		{
			this._searchRetStockSlip = searchRetStockSlip;
		}

		/// <summary>
		/// メニューフォームランチャー起動イベント用メソッド
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void MenuForm_LuncherStart(object sender, LuncherStartEventArgs e)
		{
			int customerCode = 0;
			int supplierSlipNo = 0;

			switch (e.DispNo)
			{
				case FORM_STATUS_CustomerLuncher:
				{
					// 2008.05.22 Update >>>
					//customerCode = this._customerSearchRet.CustomerCode;
					customerCode = ( this._param.SupplierDiv == 1 ) ? this._supplierSearchRet.SupplierCd : this._customerSearchRet.CustomerCode;
					// 2008.05.22 Update <<<

					break;
				}
				case FORM_STATUS_StockSlipLuncher:
				{
                    // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //customerCode = this._searchRetStockSlip.CustomerCode;
                    customerCode = this._searchRetStockSlip.SupplierCd;
                    // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
					supplierSlipNo = this._searchRetStockSlip.SupplierSlipNo;

					break;
				}
			}

			switch (e.LuncherStartAssemblyInfoData.Mode)
			{
				// 得意先変更:1
				case LuncherMode_CustomerChange:
				{
					if (LoginInfoAcquisition.OnlineFlag)
					{
						if (customerCode == 0)
						{
							TMsgDisp.Show(
								Form.ActiveForm,
								emErrorLevel.ERR_LEVEL_INFO,
								this.Name,
								"得意先情報が存在しない為、処理を行えません。",
								0,
								MessageBoxButtons.OK);
						}
						else
						{
							// 得意先コード指定起動
							object objForm = this.LoadAssemblyFrom(
								e.LuncherStartAssemblyInfoData.AssemblyName,
								e.LuncherStartAssemblyInfoData.ClassName,
								typeof(Form),
								e.LuncherStartAssemblyInfoData.Mode,
								customerCode,
								0);

							if ((objForm != null) && (objForm is Form))
							{
								((Form)objForm).Show();
							}
						}
					}
					else
					{
						TMsgDisp.Show(
							Form.ActiveForm,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"オフラインモードの為、処理を行えません。",
							0,
							MessageBoxButtons.OK);
					}

					break;
				}
				// 2008.05.22 Add >>>
				case LuncherMode_SupplierChange:
				{
					if (customerCode == 0)
						{
							TMsgDisp.Show(
								Form.ActiveForm,
								emErrorLevel.ERR_LEVEL_INFO,
								this.Name,
								"仕入先情報が存在しない為、処理を行えません。",
								0,
								MessageBoxButtons.OK);
						}
						else
						{
							// 得意先コード指定起動
							object objForm = this.LoadAssemblyFrom(
								e.LuncherStartAssemblyInfoData.AssemblyName,
								e.LuncherStartAssemblyInfoData.ClassName,
								typeof(Form),
								e.LuncherStartAssemblyInfoData.Mode,
								customerCode,
								0);

							if ((objForm != null) && (objForm is Form))
							{
								((Form)objForm).Show();
							}
						}
					break;
				}
				// 2008.05.22 Add <<<
				// 得意先参照:6
				case LuncherMode_CustomerView:
				{
					if (customerCode == 0)
					{
						TMsgDisp.Show(
							Form.ActiveForm,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"得意先情報が存在しない為、処理を行えません。",
							0,
							MessageBoxButtons.OK);
					}
					else
					{
						// 仕入先コード指定起動
						object objForm = this.LoadAssemblyFrom(
							e.LuncherStartAssemblyInfoData.AssemblyName,
							e.LuncherStartAssemblyInfoData.ClassName,
							typeof(Form),
							e.LuncherStartAssemblyInfoData.Mode,
							customerCode,
							0);

						if ((objForm != null) && (objForm is Form))
						{
							((Form)objForm).Show();
						}
					}

					break;
				}
				// 得意先新規:8
				case LuncherMode_CustomerNew:
				{
					if (LoginInfoAcquisition.OnlineFlag)
					{
						object objForm = this.LoadAssemblyFrom(
							e.LuncherStartAssemblyInfoData.AssemblyName,
							e.LuncherStartAssemblyInfoData.ClassName,
							typeof(Form),
							e.LuncherStartAssemblyInfoData.Mode,
							0,
							0);

						if ((objForm != null) && (objForm is Form))
						{
							((Form)objForm).Show();
						}
					}
					else
					{
						TMsgDisp.Show(
							Form.ActiveForm,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"オフラインモードの為、処理を行えません。",
							0,
							MessageBoxButtons.OK);
					}

					break;
				}
				// 得意先を伝票に反映する
				case LuncherMode_SlipSetCustomer:
				{
					if (LoginInfoAcquisition.OnlineFlag)
					{
						if (this.SelectedCustomer != null)
						{
							//this._customerSearchRet.SearchMode = e.LuncherStartAssemblyInfoData.Mode;
							this.SelectedCustomer(this._customerSearchRet);		// 親に「得意先選択」指示
						}
					}
					else
					{
						TMsgDisp.Show(
							Form.ActiveForm,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"オフラインモードの為、処理を行えません。",
							0,
							MessageBoxButtons.OK);
					}

					break;
				}
				// 仕入先を使用しての伝票新規:41
				case LuncherMode_NewSlipSetSupplier:
				{
					// 2008.05.22 Del >>>
					//if (this._customerSearchRet.SupplierDiv == 0)
					//{
					//    TMsgDisp.Show(
					//        Form.ActiveForm,
					//        emErrorLevel.ERR_LEVEL_INFO,
					//        this.Name,
					//        "選択中の得意先は仕入先ではない為、処理を行えません。",
					//        0,
					//        MessageBoxButtons.OK);

					//    return;
					//}
					// 2008.05.22 Del <<<

					if (LoginInfoAcquisition.OnlineFlag)
					{
						// 2008.05.22 Update >>>
						//if (this.CreateNewSlip != null)
						//{
						//    CustomerSearchRet setData = this._customerSearchRet.Clone();
						//    this.CreateNewSlip(setData);			// 親に「新規伝票作成」指示
						//}

						if (this.CreateNewSlipUsedSupplier != null)
						{
							Supplier setData = this._supplierSearchRet.Clone();
							this.CreateNewSlipUsedSupplier(setData);			// 親に「新規伝票作成」指示
						}

						// 2008.05.22 Update <<<
					}
					else
					{
						TMsgDisp.Show(
							Form.ActiveForm,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"オフラインモードの為、処理を行えません。",
							0,
							MessageBoxButtons.OK);
					}

					break;
				}
				// 選択中の仕入先を伝票に反映する:42
				case LuncherMode_SlipSetSupplier:
				{
					// 2008.05.22 Del >>>
					//if (this._customerSearchRet.SupplierDiv == 0)
					//{
					//    TMsgDisp.Show(
					//        Form.ActiveForm,
					//        emErrorLevel.ERR_LEVEL_INFO,
					//        this.Name,
					//        "選択中の得意先は仕入先ではない為、処理を行えません。",
					//        0,
					//        MessageBoxButtons.OK);

					//    return;
					//}
					// 2008.05.22 Del <<<

					if (LoginInfoAcquisition.OnlineFlag)
					{
						// 2008.05.22 Update >>>
						//if (this.SelectedCustomer != null)
						//{
						//    //this._customerSearchRet.SearchMode = e.LuncherStartAssemblyInfoData.Mode;
						//    this.Selectedsupp(this._customerSearchRet);		// 親に「得意先選択」指示
						//}

						if (this.SelectedSupplier != null)
						{
							this.SelectedSupplier(this._supplierSearchRet);		// 親に「仕入先選択」指示
						}
						// 2008.05.22 Update <<<
					}
					else
					{
						TMsgDisp.Show(
							Form.ActiveForm,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"オフラインモードの為、処理を行えません。",
							0,
							MessageBoxButtons.OK);
					}

					break;
				}
				// 仕入伝票検索:5
				case LuncherMode_StockSlipSearch:
				{
					// 仕入伝票画面に遷移し、得意先コードを自動セット・伝票検索を自動実行する
					PanelChangeEventArgs ea = new PanelChangeEventArgs(PanelChangeEventArgs.MODE_UPDATE, FORM_STATUS_FindStockSlip);
					this.ChildForm_PanelChange(this, ea);

                    // 2008.09.05 Update >>>
					//this._stockSlipSearchForm.AutoSearch(this._customerSearchRet.CustomerCode);
                    this._stockSlipSearchForm.AutoSearch(this._supplierSearchRet.SupplierCd, this._supplierSearchRet.SupplierNm1 + " " + this._supplierSearchRet.SupplierNm2);
                    // 2008.09.05 Update <<<

					break;
				}
				// 伝票修正:10
				case LuncherMode_ModifyStockSlip:
				{
					if (this.ModifyStockSlip != null)
					{
						this.ModifyStockSlip(this._searchRetStockSlip);				// 親に「伝票呼び出し作成」指示
					}

					break;
				}
				// 赤伝作成:11
				case LuncherMode_SlipAbuild:
				{
					if (this.RedWriteStockSlip != null)
					{
						this.RedWriteStockSlip(this._searchRetStockSlip);			// 親に「赤伝作成」指示
					}
					break;
				}
				// 入荷計上:12
				case LuncherMode_TrustAppropriate:
				{
					if (this.TrustAppropriateStockSlip != null)
					{
						this.TrustAppropriateStockSlip(this._searchRetStockSlip);	// 親に「入荷計上」指示
					}
					break;
				}
				// 伝票コピー:25
				case LuncherMode_SlipCopy:
				{
					// 2007.10.12 sasaki >>
					if (this.SlipCopy != null)
					{
						this.SlipCopy(this._searchRetStockSlip);					// 親に「伝票コピー」指示
					}
					// 2007.10.12 sasaki <<

					/*
					if ((LoginInfoAcquisition.OnlineFlag) && (!this._stockSlip.OfflineDataFlg))
					{
						SFMIT01235U sfmit01235u = new SFMIT01235U();
						CustomSerializeArrayList blackWorkList = new CustomSerializeArrayList();
						int nStatus = sfmit01235u.CopyAcceptOdr(this, 0, _stockSlip, out blackWorkList);
						switch (nStatus)
						{
							case 1:	// 編集
							if (this.ModifyOrderWithData != null) this.ModifyOrderWithData(blackWorkList);
							break;
						}
					}
					else if (this._stockSlip.OfflineDataFlg)
					{
						TMsgDisp.Show(
							Form.ActiveForm,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"ローカル保存データの為、処理を行えません。",
							0,
							MessageBoxButtons.OK);
					}
					else
					{
						TMsgDisp.Show(
							Form.ActiveForm,
							emErrorLevel.ERR_LEVEL_INFO,
							this.Name,
							"オフラインモードの為、処理を行えません。",
							0,
							MessageBoxButtons.OK);
					}
					*/
					break;
				}
			}
		}

		/// <summary>
		/// トップメニュー選択イベントメソッド
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="luncherTopMenuInfo">トップメニューランチャー情報クラス</param>
		private void TopMenuForm_TopMenuSelect(object sender, LuncherTopMenuInfo luncherTopMenuInfo)
		{
			switch (luncherTopMenuInfo.Mode)
			{
				// 得意先検索:1
				case TOP_MODE_CustomerSearch:
				{
					break;
				}
				// 仕入伝票検索:2
				case TOP_MODE_StockSlipSearch:
				{
					break;
				}
				// 新規伝票作成:3
				case TOP_MODE_NewSlip:
				{
					// 顧客情報をクリア
					CustomerSearchRet customerSearchRet = new CustomerSearchRet();

					if (this.CreateNewSlip != null)
					{
						this.CreateNewSlip(customerSearchRet);		// 親に「新規伝票作成」指示
					}

					break;
				}
                // 2008.09.18 Add >>>
                // 新規仕入伝票作成:8
                case TOP_MODE_NewStockSlip:
                {
                    // 顧客情報をクリア
                    Supplier supplier = new Supplier();

                    if (this.CreateNewSlipUsedSupplier != null)
                    {
                        this.CreateNewSlipUsedSupplier(supplier);		// 親に「新規伝票作成」指示
                    }

                    break;
                }
                // 2008.09.18 Add <<<

				// 得意先の新規作成:6
				case TOP_MODE_NewCustomer:
				{
					LuncherStartAssemblyInfo luncherStartAssemblyInfo  = new LuncherStartAssemblyInfo();
					luncherStartAssemblyInfo.AssemblyName = luncherTopMenuInfo.AssemblyName;
					luncherStartAssemblyInfo.ClassName = luncherTopMenuInfo.ClassName;
					luncherStartAssemblyInfo.DispName = luncherTopMenuInfo.DispName;
					luncherStartAssemblyInfo.ImageNo = luncherTopMenuInfo.ImageNo;
					luncherStartAssemblyInfo.Mode = LuncherMode_CustomerNew;

					LuncherStartEventArgs e = new LuncherStartEventArgs(luncherStartAssemblyInfo, FORM_STATUS_Top);
					this.MenuForm_LuncherStart(this, e);
					break;
				}
			}
		}

		/// <summary>
		/// アセンブリロード・インスタンス化処理
		/// </summary>
		/// <param name="asmname">アセンブリ名称</param>
		/// <param name="classname">クラス名称</param>
		/// <param name="type">実装するクラス型</param>
		/// <param name="mode">起動パターン</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="supplierSlipNo">仕入伝票伝票番号</param>
		/// <returns>インスタンス化されたクラス</returns>
		private object LoadAssemblyFrom(string asmname, string classname, Type type, int mode, int customerCode, int supplierSlipNo)
		{
			object	obj	= null;
			try
			{
				System.Reflection.Assembly	asm	= System.Reflection.Assembly.Load(asmname);
				Type	objType	= asm.GetType(classname);
				if (objType != null)
				{
					if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
					{
						// パラメータを渡す
						if (mode == LuncherMode_CustomerChange)												// 得意先修正
						{
							// 得意先コード指定起動
							object [] args = {1, this._enterpriseCode, customerCode};
							obj = Activator.CreateInstance(objType, args);
						}
						// 2008.05.22 Add >>>
						else if (mode == LuncherMode_SupplierChange)										// 仕入先修正
						{
							// 仕入先コード指定起動
							object[] args = { 1, this._enterpriseCode, customerCode };
							obj = Activator.CreateInstance(objType, args);
						}
						// 2008.05.22 Add <<<
						else if (mode == LuncherMode_CustomerView)											// 得意先参照時
						{
							// 得意先コード指定起動
							object[] args = { 2, this._enterpriseCode, customerCode };
							obj = Activator.CreateInstance(objType, args);
						}
						else
						{
							// パラメータなし起動
							obj = Activator.CreateInstance(objType);
						}
					}
				}
			}
			catch(System.Exception er)
			{
				TMsgDisp.Show(
					Form.ActiveForm,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					er.Message,
					-1,
					MessageBoxButtons.OK);

			}

			return obj;
		}

		/// <summary>
		/// アセンブリロード・インスタンス化処理（オーバーロード）
		/// </summary>
		/// <param name="asmname">アセンブリ名称</param>
		/// <param name="classname">クラス名称</param>
		/// <param name="type">実装するクラス型</param>
		/// <returns>インスタンス化されたクラス</returns>
		private	object LoadAssemblyFrom(string asmname, string classname, Type type)
		{
			object	obj	= null;
			try
			{

				System.Reflection.Assembly	asm	= System.Reflection.Assembly.Load(asmname);
				Type	objType	= asm.GetType(classname);
				if (objType != null)
				{
					if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
					{
						// パラメータなし起動
						obj = Activator.CreateInstance(objType);
					}
				}
			}
			catch(System.Exception er)
			{
				TMsgDisp.Show(
					Form.ActiveForm,
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.Name,
					er.Message,
					-1,
					MessageBoxButtons.OK);
			}

			return obj;
		}

		/// <summary>
		/// 選択得意先･仕入伝票情報クラス→得意先検索結果クラス移項処理
		/// </summary>
		/// <param name="selectCustomerStockSlip">選択得意先･仕入伝票情報クラス</param>
		/// <returns>得意先車両検索結果クラス</returns>
		internal static CustomerSearchRet CopyToCustomerSearchRet(SliderSelectedData sliderSelectedData)
		{
			CustomerSearchRet customerSearchRet = new CustomerSearchRet();

			customerSearchRet.EnterpriseCode = sliderSelectedData.EnterpriseCode;
			customerSearchRet.CustomerCode = sliderSelectedData.CustomerCode;
			customerSearchRet.CustomerSubCode = sliderSelectedData.CustomerSubCode;
			customerSearchRet.Name = sliderSelectedData.Name;
			customerSearchRet.Name2 = sliderSelectedData.Name2;

			return customerSearchRet;
		}

		/// <summary>
		/// 選択得意先･仕入伝票情報クラス→仕入伝票検索結果クラス移項処理
		/// </summary>
		/// <param name="selectCustomerStockSlip">選択得意先仕入伝票情報クラス</param>
		/// <returns>仕入伝票検索結果クラス</returns>
		internal static SearchRetStockSlip searchRetStockSlipFromSelectCustomerOrder(SliderSelectedData sliderSelectedData)
		{
			SearchRetStockSlip searchRetStockSlip = new SearchRetStockSlip();

			searchRetStockSlip.EnterpriseCode = sliderSelectedData.EnterpriseCode;
			searchRetStockSlip.SupplierSlipNo = sliderSelectedData.SupplierSlipNo;
			searchRetStockSlip.SupplierFormal = sliderSelectedData.SupplierFormal;

			return searchRetStockSlip;
		}

		/// <summary>
		/// プロセススタート処理
		/// </summary>
		/// <param name="programPath">プログラムパス</param>
		/// <param name="arguments">引数</param>
		private void ProcessStart(string programPath, string arguments)
		{
			System.Diagnostics.Process extProcess = new System.Diagnostics.Process();
			extProcess.StartInfo.FileName = programPath;
			extProcess.StartInfo.Arguments = arguments;
			extProcess.Start();
		}

		/// <summary>
		/// ログインパラメータ取得処理
		/// </summary>
		/// <returns></returns>
		private string GerLoginArguments()
		{
			System.Text.StringBuilder arguments = new System.Text.StringBuilder();
			// ログインパラメータ情報を設定
			ApplicationStartControl applicationStartControl = new ApplicationStartControl();
			string[] loginArguments = applicationStartControl.Parameters;
			foreach (string argument in loginArguments)
			{
				if (argument.Trim() != "")
				{
					arguments.Append(argument + " ");
				}
			}

			return arguments.ToString();
		}

		# endregion

		// ===================================================================================== //
		// 各コントロールイベント処理
		// ===================================================================================== //
		# region Event Methods
		/// <summary>
		/// フォームロードイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void SFCMN00221UA_Load(object sender, System.EventArgs e)
		{
		}

		/// <summary>
		/// 初期処理タイマー起動イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void timer_Initial_Tick(object sender, System.EventArgs e)
		{
			this.timer_Initial.Enabled = false;

			// 変数初期化
			this.InitializeMembers();

			// 画面初期表示設定処理
			this.DisplayInitialSetting();

			// 初期処理(初期値設定XML読み込み等)
			this.LoadInitialData();

			this._topMenuForm.CustomerSearchRetRecordList = this._customerSearchRetRecordList;					// 最近選択した得意先車両情報
			this._topMenuForm.SupplierSearchRetRecordList = this._supplierSearchRetRecordList;					// 最近選択した仕入先車両情報
			this._topMenuForm.StockSlipRecordList = this._stockSlipRecordList;									// 最近選択した仕入伝票情報
			this._topMenuForm.LuncherTopMenuInfoArray = this._luncherTopMenuInfoArray;							// ランチャートップメニュー情報
			this._customerMenuForm.LuncherStartAssemblyInfoArray = this._luncherStartAssemblyInfoArray;			// ランチャー表示アセンブリ情報(得意先車両検索)
			this._stockSlipMenuForm.OdrLuncherStartAssemblyInfoArray = this._odrLuncherStartAssemblyInfoArray;	// ランチャー表示アセンブリ情報(仕入伝票検索)

			// トップメニューフォーム／初期設定処理
			PanelChangeEventArgs pe = new PanelChangeEventArgs(PanelChangeEventArgs.MODE_UPDATE, FORM_STATUS_Top);
			this.ChildForm_PanelChange(this, pe);

			// 得意先検索フォーム／初期設定処理
			this._customerSearchForm.InitialSetting(this._param);

			// 2008.05.22 Add >>>
			// 仕入先検索フォーム／初期設定処理
			this._supplierSearchForm.InitialSetting(this._param);
			// 2008.05.22 Add <<<

			// 仕入伝票検索フォーム／初期設定処理
			this._stockSlipSearchForm.InitialSetting(this._param);
		}

		/// <summary>
		/// ホームボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_Home_Click(object sender, System.EventArgs e)
		{
			this._panelChangeRecordListIndex = 1;

			PanelChangeEventArgs ea = new PanelChangeEventArgs(1, FORM_STATUS_Top);
			this.ChildForm_PanelChange(sender, ea);
		}

		/// <summary>
		/// 戻るボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_Before_Click(object sender, System.EventArgs e)
		{
			this.uButton_Home.Focus();

			if (this._panelChangeRecordListIndex > 1)
			{
				this._panelChangeRecordListIndex--;

				PanelChangeRecord panelChangeRecord = this._panelChangeRecordList[this._panelChangeRecordListIndex - 1];
				
				PanelChangeEventArgs ea = new PanelChangeEventArgs(1, panelChangeRecord.DispNo);
				this.ChildForm_PanelChange(sender, ea);
			}
		}

		/// <summary>
		/// 次へボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_Next_Click(object sender, System.EventArgs e)
		{
			this.uButton_Home.Focus();

			if (this._panelChangeRecordList.Count > this._panelChangeRecordListIndex)
			{
				this._panelChangeRecordListIndex++;

				PanelChangeRecord panelChangeRecord = this._panelChangeRecordList[this._panelChangeRecordListIndex - 1];
				
				PanelChangeEventArgs ea = new PanelChangeEventArgs(1, panelChangeRecord.DispNo);
				this.ChildForm_PanelChange(sender, ea);
			}

		}
		# endregion
	}

	# region Internal Delegate
	/// <summary>得意先選択後デリゲート</summary>
	internal delegate void CustomerSelectedHandler(object sender, CustomerSearchRet customerSearchRet);

	// 2008.05.22 Add >>>
	/// <summary>仕入先選択後デリゲート</summary>
	internal delegate void SupplierSelectedHandler( object sender, Supplier supplierSearchRet );
	// 2008.05.22 Add <<<

	/// <summary>仕入伝票選択後デリゲート</summary>
	internal delegate void SearchRetStockSlipSelectedHandler(object sender, SearchRetStockSlip searchRetStockSlip);
	# endregion

	# region Public Delegate
	/// <summary>得意先選択デリゲート</summary>
	/// <remarks>検索得意先を選択時に発生するデリゲートです。受信者はパラメータから関連情報を取得してください。</remarks>
	public delegate void SelectedCustomerHandler(CustomerSearchRet seldata);

	// 2008.05.22 Add >>>
	/// <summary>仕入先選択デリゲート</summary>
	/// <remarks>検索仕入先を選択時に発生するデリゲートです。受信者はパラメータから関連情報を取得してください。</remarks>
	public delegate void SelectedSupplierHandler( Supplier seldata );
	// 2008.05.22 Add <<<

	/// <summary>新規伝票作成指示デリゲート</summary>
	/// <remarks>新規伝票作成選択時に発生するデリゲートです。受信者はパラメータから関連情報を取得してください。</remarks>
	public delegate void CreateNewSlipHandler(CustomerSearchRet seldata);

	// 2008.05.22 Add >>>
	/// <summary>新規伝票作成指示デリゲート</summary>
	/// <remarks>仕入先を使用して新規伝票作成選択時に発生するデリゲートです。受信者はパラメータから関連情報を取得してください。</remarks>
	public delegate void CreateNewSlipUsedSupplierHandler( Supplier seldata );
	// 2008.05.22 Add <<<
	
	/// <summary>伝票呼び出し指示デリゲート</summary>
	/// <remarks>伝票呼び出し選択時に発生するデリゲートです。受信者はパラメータから関連情報を取得してください。</remarks>
	public delegate void ModifyStockSlipHandler(SearchRetStockSlip seldata);

	// 2007.10.12 sasaki >>
	/// <summary>伝票コピー指示デリゲート</summary>
	/// <remarks>伝票コピー選択時に発生するデリゲートです。受信者はパラメータから関連情報を取得してください。</remarks>
	public delegate void ModifySlipCopyHandler( CustomerSearchRet seldata );
	// 2007.10.12 sasaki <<
	# endregion
}

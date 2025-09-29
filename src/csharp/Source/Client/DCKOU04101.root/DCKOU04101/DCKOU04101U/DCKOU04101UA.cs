//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 仕入履歴照会
// プログラム概要   : 仕入履歴照会を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2009/04/07  修正内容 : 障害対応13077
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/04/09  修正内容 : 障害対応13014
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434 工藤
// 作 成 日  2009/12/04  修正内容 : 障害対応14745
//----------------------------------------------------------------------------//
// 管理番号　11175161-00 作成担当 : 周洋
// 修 正 日　2015/05/06  修正内容 : 仕入先入力不可の対応
//----------------------------------------------------------------------------//
// 管理番号　11175161-00 作成担当 : イン晶晶
// 修 正 日　2015/06/12  修正内容 : 仕入先入力不可の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
    using GridSettingsType = SlipGridSettings;  // ADD 2009/12/04 MANTIS対応[14745]：伝票および明細グリッド列の列設定の変更

	public partial class DCKOU04101UA : Form
	{
        // ADD 2009/12/04 MANTIS対応[14745]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
        #region グリッドの設定情報

        /// <summary>FIXME:グリッド情報XMLファイル名</summary>
        private const string XML_FILE_NAME = "DCKOU04100U_Construction.XML";

        /// <summary>グリッドの設定情報</summary>
        private GridSettingsType _gridSettings;
        /// <summary>グリッドの設定情報を取得します。</summary>
        public GridSettingsType GridSettings
        {
            get
            {
                if (_gridSettings == null)
                {
                    _gridSettings = SlipGridUtil.ReadGridSettings(XML_FILE_NAME);
                }
                return _gridSettings;
            }
        }

        #endregion // グリッドの設定情報
        // ADD 2009/12/04 MANTIS対応[14745]：伝票および明細グリッド列の列設定の変更 ----------<<<<<

		#region ■Constructor
		public DCKOU04101UA()
		{
			InitializeComponent();

			// 変数初期化
            this._searchSlipAcs = DCKOU04102AA.GetInstance();
            this._dataSet = _searchSlipAcs.DataSet;
            this._inputDetails = new DCKOU04101UB();
            this._imageList16 = IconResourceManagement.ImageList16;
			this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
			this._decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"];
			this._undoButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Undo"];
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];
            this._controlScreenSkin = new ControlScreenSkin();

            this._paraStockSlipCache_Display = new StcHisRefExtraParamWork();
#if False
			if (this._searchSlipAcs.GetParaStockSlipCache() != null)
            {
                this._paraStockSlipCache_Display = this._searchSlipAcs.GetParaStockSlipCache();
            }
#endif

            this._inputDetails.StatusBarMessageSetting += new DCKOU04101UB.SettingStatusBarMessageEventHandler(this.SetStatusBarMessage);
            this._searchSlipAcs.StatusBarMessageSetting += new DCKOU04102AA.SettingStatusBarMessageEventHandler(this.SetStatusBarMessage);
            this._inputDetails.CloseMain += new DCKOU04101UB.CloseMainEventHandler(this.CloseForm);
            this._inputDetails.SetMainDialogResult += new DCKOU04101UB.SetDialogResEventHandler(this.SetDialogRes);
            this._inputDetails.DecisionButtonEnableSet += new DCKOU04101UB.SettingDecisionButtonEnableEventHandler(this.ChangeDecisionButtonEnable);
            this._searchSlipAcs.GetNameList += new DCKOU04102AA.GetNameListEventHandler(this.GetDisplayNameList);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
            this._searchSlipAcs.SelectedDataChange += new DCKOU04102AA.SelectedDataChangeEventHandler( this._inputDetails.SearchSlipAcs_SelectedDataChange );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD

			//　企業コードを取得する
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			// 自拠点コードを取得する
			this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
			// 拠点オプション有無を取得する
			this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);
			// 本社/拠点情報を取得する
			this._mainOfficeFunc = this._searchSlipAcs.IsMainOfficeFunc();

			// 元に戻す処理
			this.ClearDisplayHeader();
			this._searchSlipAcs.ClearStockSlipDataTable();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            // 日付取得部品
            _dateGet = DateGetAcs.GetInstance();

            // 締日算出モジュール
            _ttlDayCalc = TotalDayCalculator.GetInstance();

            // フォーカス制御
            _irregularFocusControl = new IrregularFocusControl();
            # region [focus]
            _irregularFocusControl.AddFocusDictionary( tComboEditor_ReconcileFlag, false, Keys.Down, 0, tNedit_GoodsMakerCd );
            _irregularFocusControl.AddFocusDictionary( tComboEditor_SupplierFormal, false, Keys.Down, 0, tComboEditor_ReconcileFlag );
            _irregularFocusControl.AddFocusDictionary( tComboEditor_SupplierFormal, false, Keys.Down, 1, tNedit_GoodsMakerCd );
            _irregularFocusControl.AddFocusDictionary( tComboEditor_SupplierFormal, false, Keys.Down, 2, _inputDetails );
            _irregularFocusControl.AddFocusDictionary( tComboEditor_SupplierSlipCd, false, Keys.Down, 0, tComboEditor_ReconcileFlag );
            _irregularFocusControl.AddFocusDictionary( tComboEditor_SupplierSlipCd, false, Keys.Down, 1, tNedit_GoodsMakerCd );
            _irregularFocusControl.AddFocusDictionary( tDateEdit_InputDayEd, false, Keys.Down, 0, tNedit_SupplierSlipNo_Ed );
            _irregularFocusControl.AddFocusDictionary( tEdit_GoodsName, false, Keys.Down, 0, tEdit_GoodsName );
            _irregularFocusControl.AddFocusDictionary( tEdit_GoodsName, false, Keys.Up, 0, tEdit_WarehouseCode );
            _irregularFocusControl.AddFocusDictionary( uButton_EmployeeGuide, false, Keys.Right, 0, uButton_EmployeeGuide );
            _irregularFocusControl.AddFocusDictionary( uButton_EmployeeGuide, false, Keys.Up, 0, tEdit_PartySalesSlipNum );
            _irregularFocusControl.AddFocusDictionary( uButton_SectionGuide, false, Keys.Down, 0, uButton_SupplierGuide );
            _irregularFocusControl.AddFocusDictionary( uButton_SectionGuide, false, Keys.Right, 0, tDateEdit_Date1Start );
            _irregularFocusControl.AddFocusDictionary( uButton_SupplierGuide, false, Keys.Up, 0, uButton_SectionGuide );
            _irregularFocusControl.AddFocusDictionary( uButton_WarehouseGuide, false, Keys.Right, 0, uButton_WarehouseGuide );
            # endregion

            if ( this.MaxSelectCount <= 0 )
            {
                this.MaxSelectCount = 1;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD

            this._companyAcs = new CompanyInfAcs();     // ADD 2009/04/09
		}

		public DCKOU04101UA(int startMovment)	: this()
		{
			this._inputDetails.StartMovment = startMovment;
            if ( startMovment == 1 )
            {
                ChangeDecisionButtonEnable( false );
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                _autoSearch = false;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
            }
		}

		#endregion

		#region ■Private Members
		private DCKOU04102AA _searchSlipAcs;
        private StockDataSet _dataSet;
        private DCKOU04101UB _inputDetails;
        private StcHisRefExtraParamWork _paraStockSlipCache_Display;
        private SecInfoSetAcs _secInfoSetAcs = new SecInfoSetAcs();
		//private CarrierEpAcs _carrierEpAcs = new CarrierEpAcs();
		private WarehouseAcs _warehouseAcs = new WarehouseAcs();

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.29 TOKUNAGA ADD START
        // 仕入先ガイド
        private SupplierAcs _supplierAcs = new SupplierAcs();
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.29 TOKUNAGA ADD END


        private string _enterpriseCode;             // 企業コード
        private string _loginSectionCode;           // 自拠点コード
        private bool _optSection;                   // 拠点オプション有無フラグ
        private bool _mainOfficeFunc;               // 本社/拠点判断フラグ
        private ImageList _imageList16 = null;									// イメージリスト
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;		// 終了ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _decisionButton;	// 確定ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _undoButton;		// 取消ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;		// 検索ボタン
        private ControlScreenSkin _controlScreenSkin;
        private DialogResult _dialogRes = DialogResult.Cancel;

		//画面項目初期値
		private int _SupplierFormal = 0;
		private int _ReconcileFlag = 0;
		private int _SupplierSlipCd = 0;
		private string _SectionCode = "";
		private string _SectionName = "";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
        //private int _CustomerCode = 0;
        //private string _CustomerName = "";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
		private string _GoodsNo = "";
		private string _GoodsName = "";
		private int _GoodsMakerCode = 0;
		private string _GoodsMakerName = "";
		
		private bool _isMultiSelect = true;										//TRUE:単一選択 FALSE:複数選択

        private const string MESSAGE_StartEndError = "開始≦終了となるよう設定してください。";
        private const string MESSAGE_NoInput = "必須入力項目です。";
        private const string MESSAGE_InvalidDate = "有効な日付ではありません。";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
        // 変則フォーカス制御
        private IrregularFocusControl _irregularFocusControl;
        // 日付取得部品
        private DateGetAcs _dateGet;
        // 締日算出モジュール
        private TotalDayCalculator _ttlDayCalc;
        // 自動検索モードフラグ
        private bool _autoSearch = true;

        // 検索条件 仕入先コード
        private int _paraSupplierCd;
        // 検索条件 仕入先名称
        private string _paraSupplierName;
        // 検索条件 支払先コード
        private int _paraPayeeCode;
        // 検索条件 支払先名称
        private string _payeeName;

        // 検索条件 仕入担当者コード
        private string _paraStockAgentCode;
        // 検索条件 仕入担当者名称
        private string _paraStockAgentName;
        // 検索条件 仕入日付
        private DateTime _paraStockDate;

        // 全拠点名称
        private const string ct_AllSection = "全社";

        // エラーメッセージ
        const string ct_InputError = "の入力が不正です";
        const string ct_NoInput = "を入力して下さい";
        const string ct_RangeError = "の範囲指定に誤りがあります";
        const string ct_RangeOverError = "は３ヶ月の範囲内で入力して下さい";

        // 2008.11.10 add start [7578]
        /// <summary>表示：初期フォントサイズ : 11pts</summary>
        private const int CT_DEF_FONT_SIZE = 11;

        /// <summary>表示：フォントサイズ一覧</summary>
        private readonly int[] _fontpitchSize = new int[] { 6, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24 };
        // 2008.11.10 add end [7578]

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD

        // ADD 2009/04/09 ------>>>
        private CompanyInfAcs _companyAcs;
        int _secMngDiv;
        // ADD 2009/04/09 ------<<<
        
		#endregion

		#region ■Public Methods
		/// <summary>
        /// 呼出制御処理
        /// </summary>
        /// <param name="owner">呼出元オブジェクト</param>
        /// <param name="carrierCode">キャリアコード</param>
        /// <remarks>
        /// <br>UpdateNote: 2015/05/06　周洋</br>
        /// <br>管理番号  : 11175161-00 仕入先入力不可の対応</br>
        /// </remarks>
        public DialogResult ShowDialog(IWin32Window owner, int supplierFormal)
        {
			//仕入
			if (supplierFormal == 0)
			{
				SupplierFormal = 0;
				ReconcileFlag = -1;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                //this.Text = "仕入履歴照会";
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
			}
			//入荷
			else if (supplierFormal == 1)
			{
				SupplierFormal = 1;
				ReconcileFlag = 2;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                //this.Text = "入荷履歴照会";
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
			}

			tComboEditor_SupplierFormal.Enabled = false;
            //------------------------ ADD by 周洋 2015/05/06 for Redmine#45801 仕入先入力不可の対応 -------------->>>>>
            tNedit_SupplierCd.Enabled = false;
            uButton_SupplierGuide.Enabled = false;
            //------------------------ ADD by 周洋 2015/05/06 for Redmine#45801 仕入先入力不可の対応 --------------<<<<<
			
			return this.ShowDialog(owner);
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
        ///// <summary>
        ///// 呼出制御処理(仕入先指定)
        ///// </summary>
        ///// <param name="owner">呼出元オブジェクト</param>
        ///// <param name="carrierCode">キャリアコード</param>
        //public DialogResult ShowDialog(IWin32Window owner, int supplierFormal, int supplierCd )
        //{
        //    //仕入
        //    if (supplierFormal == 0)
        //    {
        //        SupplierFormal = 0;
        //        ReconcileFlag =  0;
        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
        //        //this.Text = "仕入履歴照会";
        //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
        //    }
        //    //入荷
        //    else if (supplierFormal == 1)
        //    {
        //        SupplierFormal = 1;
        //        ReconcileFlag = 2;
        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
        //        //this.Text = "入荷履歴照会";
        //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
        //    }

        //    tComboEditor_SupplierFormal.Enabled = false;

        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
        //    //this.CustomerCode = customerCode;
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
        //    return this.ShowDialog(owner);
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL

		/// <summary>
		/// データ検索処理
		/// </summary>
		/// <returns>読み込みステータス</returns>
		public bool SearchData(int supplierFormal)
		{
			//仕入
			if (supplierFormal == 0)
			{
				SupplierFormal = 0;
				ReconcileFlag = 0;
			}
			//入荷
			else if (supplierFormal == 1)
			{
				SupplierFormal = 1;
				ReconcileFlag = 2;
			}

			// ヘッダ情報クリア処理
			this.ClearDisplayHeader();
			this._searchSlipAcs.ClearStockSlipDataTable();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            // 検索条件セット
            SetCondition();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

			// 入力項目チェック処理
			StcHisRefExtraParamWork stcHisRefExtraParamWork = new StcHisRefExtraParamWork();
			bool setEnable = false;

			// 読込条件パラメータクラス設定処理
			this.SetReadPara(out stcHisRefExtraParamWork);

			// 伝票情報読込・データセット格納処理
			this._searchSlipAcs.SetSearchData(stcHisRefExtraParamWork);

			setEnable = this._inputDetails.SetGridEnable();
			if (setEnable == true)
			{
				this._inputDetails.uGrid_Details.Focus();
				this._inputDetails.timer_GridSetFocus.Enabled = true;
			}
			else
			{
				//this._inputDetails.uButton_StockSearch.Enabled = false;
			}

			return setEnable;
		}
		#endregion

#if true
		public bool Standard_UGroupBox_Expand
		{
			get { return this.Standard_UGroupBox.Expanded; }
			set { this.Standard_UGroupBox.Expanded = value; }
		}
		public bool Detail_UGroupBox_Expand
		{
			get { return this.Detail_UGroupBox.Expanded; }
			set { this.Detail_UGroupBox.Expanded = value; }
		}

		#region ■Properties
		/// <summary>
        /// 選択伝票データ取得プロパティ
        /// </summary>
		public List<StcHisRefDataWork> stcHisRefDataWork
        {
            get { return this._inputDetails._stcHisRefDataWork; }
        }

		/// <summary>伝票種別プロパティ</summary>
		public int SupplierFormal
		{
			get { return this._SupplierFormal; }
			set { this._SupplierFormal = value; }
		}

		/// <summary>入荷状況プロパティ</summary>
		public int ReconcileFlag
		{
			get { return this._ReconcileFlag; }
			set { this._ReconcileFlag = value; }
		}

		/// <summary>伝票区分プロパティ</summary>
		public int SupplierSlipCd
		{
			get { return this._SupplierSlipCd; }
			set { this._SupplierSlipCd = value; }
		}

		/// <summary>拠点コードプロパティ</summary>
		public string SectionCode
		{
			get { return this._SectionCode; }
			set { this._SectionCode = value; }
		}
		/// <summary>拠点名称プロパティ</summary>
		public string SectionName
		{
			get { return this._SectionName; }
			set { this._SectionName = value; }
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
        ///// <summary>仕入先コードプロパティ</summary>
        //public int CustomerCode
        //{
        //    get { return this._CustomerCode; }
        //    set { this._CustomerCode = value; }
        //}
        ///// <summary>仕入先名称プロパティ</summary>
        //public string CustomerName
        //{
        //    get { return this._CustomerName; }
        //    set { this._CustomerName = value; }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL

		/// <summary>商品コードプロパティ</summary>
		public string GoodsNo
		{
			get { return this._GoodsNo; }
			set { this._GoodsNo = value; }
		}

		/// <summary>商品名称プロパティ</summary>
		public string GoodsName
		{
			get { return this._GoodsName; }
			set { this._GoodsName = value; }
		}

		/// <summary>メーカーコードプロパティ</summary>
		public int GoodsMakerCode
		{
			get { return this._GoodsMakerCode; }
			set { this._GoodsMakerCode = value; }
		}
		/// <summary>メーカー名称プロパティ</summary>
		public string GoodsMakerName
		{
			get { return this._GoodsMakerName; }
			set { this._GoodsMakerName = value; }
		}

		/// <summary>複数選択プロパティ</summary>
		public bool IsMultiSelect
		{
			get { return this._isMultiSelect; }
			set { this._isMultiSelect = value; }
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/16 ADD
        /// <summary>選択可能件数</summary>
        public int MaxSelectCount
        {
            get { return this._inputDetails.MaxSelectCount; }
            set 
            { 
                this._inputDetails.MaxSelectCount = value;
                this._searchSlipAcs.MaxSelectCount = value;
            }
        }
        /// <summary>自動抽出開始</summary>
        public bool AutoSearch
        {
            get { return _autoSearch; }
            set { _autoSearch = value; }
        }
        /// <summary>
        /// 仕入先コード
        /// </summary>
        public int SupplierCd
        {
            get { return _paraSupplierCd; }
            set { _paraSupplierCd = value; }
        }
        /// <summary>
        /// 仕入先名称
        /// </summary>
        public string SupplierName
        {
            get { return _paraSupplierName; }
            set { _paraSupplierName = value; }
        }
        /// <summary>
        /// 支払先コード
        /// </summary>
        public int PayeeCode
        {
            get { return _paraPayeeCode; }
            set { _paraPayeeCode = value; }
        }
        /// <summary>
        /// 支払先名称
        /// </summary>
        public string PayeeName
        {
            get { return _payeeName; }
            set { _payeeName = value; }
        }
        /// <summary>
        /// 仕入担当者コード
        /// </summary>
        public string StockAgentCode
        {
            get { return _paraStockAgentCode; }
            set { _paraStockAgentCode = value; }
        }
        /// <summary>
        /// 仕入担当者名称
        /// </summary>
        public string StockAgentName
        {
            get { return _paraStockAgentName; }
            set { _paraStockAgentName = value; }
        }
        /// <summary>
        /// 仕入日付
        /// </summary>
        public DateTime StockDate
        {
            get { return _paraStockDate; }
            set { _paraStockDate = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/16 ADD
		#endregion

#else
		#region ■Properties
		/// <summary>
		/// 選択伝票データ取得プロパティ
		/// </summary>
		public List<StcHisRefDataWork> stcHisRefDataWork
		{
			get { return this._inputDetails._stcHisRefDataWork; }
		}

		/// <summary>伝票種別プロパティ</summary>
		public int SupplierFormal
		{
			get { return this.tComboEditor_SupplierFormal.SelectedIndex; }
			set { this.tComboEditor_SupplierFormal.SelectedIndex = value; }
		}

		/// <summary>入荷状況プロパティ</summary>
		public int ReconcileFlag
		{
			get { return this.tComboEditor_ReconcileFlag.SelectedIndex; }
			set { this.tComboEditor_ReconcileFlag.SelectedIndex = value; }
		}

		/// <summary>伝票区分プロパティ</summary>
		public int SupplierSlipCd
		{
			get { return this.tComboEditor_SupplierSlipCd.SelectedIndex; }
			set { this.tComboEditor_SupplierSlipCd.SelectedIndex = value; }
		}

		/// <summary>拠点コードプロパティ</summary>
		public string SectionCode
		{
			get { return this.tEdit_SectionCd.Text; }
			set { this.tEdit_SectionCd.Text = value; }
		}
		/// <summary>拠点名称プロパティ</summary>
		public string SectionName
		{
			get { return this.uLabel_SectionNm.Text; }
			set { this.uLabel_SectionNm.Text = value; }
		}
		/// <summary>仕入先コードプロパティ</summary>
		public int CustomerCode
		{
			get { return this.tNedit_CustomerCode.GetInt(); }
			set { this.tNedit_CustomerCode.SetInt(value); }
		}
		/// <summary>仕入先名称プロパティ</summary>
		public string CustomerName
		{
			get { return this.uLabel_CustomerName.Text; }
			set { this.uLabel_CustomerName.Text = value; }
		}

		/// <summary>商品コードプロパティ</summary>
		public string GoodsNo
		{
			get { return this.tEdit_GoodsCode.Text; }
			set { this.tEdit_GoodsCode.Text = value; }
		}

		/// <summary>商品名称プロパティ</summary>
		public string GoodsName
		{
			get { return this.uLabel_GoodsName.Text; }
			set { this.uLabel_GoodsName.Text = value; }
		}

		/// <summary>メーカーコードプロパティ</summary>
		public int GoodsMakerCode
		{
			get { return this.tNedit_GoodsMakerCd.GetInt(); }
			set { this.tNedit_GoodsMakerCd.SetInt(value); }
		}
		/// <summary>メーカー名称プロパティ</summary>
		public string GoodsMakerName
		{
			get { return this.uLabel_MakerName.Text; }
			set { this.uLabel_MakerName.Text = value; }
		}

		/// <summary>複数選択プロパティ</summary>
		public bool IsMultiSelect
		{
			get { return this._isMultiSelect; }
			set { this._isMultiSelect = value; }
		}
		#endregion
#endif

        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void Form1_Load(object sender, EventArgs e)
		{
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // スキン変更除外設定
            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add(this.Standard_UGroupBox.Name);
            excCtrlNm.Add(this.Detail_UGroupBox.Name);
            this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.29 TOKUNAGA ADD START
            // デザイナ用の数値をクリア
            this.tEdit_SectionCodeAllowZero.Clear();
            this.tNedit_SupplierCd.Clear();
            this.tNedit_PayeeCode.Clear();
            this.tNedit_SupplierSlipNo_St.Clear();
            this.tNedit_SupplierSlipNo_Ed.Clear();
            this.tEdit_PartySalesSlipNum.Clear();
            this.tEdit_StockAgentCode.Clear();
            this.tEdit_WarehouseCode.Clear();

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.29 TOKUNAGA ADD END

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);
            this._controlScreenSkin.SettingScreenSkin(this._inputDetails);

			// DCKOU04101UB を、panel_Detailを親としたコントロールにする
			this._inputDetails.IsMultiSelect = this._isMultiSelect;
			this._inputDetails.DisplayModeSetting();
			this.panel_Detail.Controls.Add(this._inputDetails);
			this._inputDetails.Dock = DockStyle.Fill;

            // 2008.11.11 add start [7578]
            // 文字サイズ設定
            for (int i = 0; i < this._fontpitchSize.Length; i++)
            {
                this.tComboEditor_GridFontSize.Items.Add(this._fontpitchSize[i], this._fontpitchSize[i].ToString());
            }
            this.tComboEditor_GridFontSize.Text = CT_DEF_FONT_SIZE.ToString();
            // 2008.11.11 add end [7578]

            // ボタン初期設定処理
			this.ButtonInitialSetting();

            // 画面初期情報設定処理
            this.SetInitialInput();

            // ADD 2009/12/04 MANTIS対応[14745]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
            // FIXME:列移動と列固定を可能とする
            SlipGridUtil.EnableAllowColSwappingAndFixedHeaderIndicator(this._inputDetails.DetailGrid);
            // FIXME:グリッド列の設定を取込
            SlipGridUtil.LoadColumnInfo(this._inputDetails.DetailGrid, GridSettings.DetailColumnsList);
            // 固定列用にもう一度
            SlipGridUtil.LoadColumnInfo(this._inputDetails.DetailGrid, GridSettings.DetailColumnsList);
            // ADD 2009/12/04 MANTIS対応[14745]：伝票および明細グリッド列の列設定の変更 ----------<<<<<
		}

        /// <summary>
        /// 画面初期情報設定処理
        /// </summary>
        private void SetInitialInput()
        {
            StockDataSet.StockSlipDataTable stockDatail = this._searchSlipAcs.GetStockSlipTableCache();

            // 拠点情報表示切替
            if (this._optSection == false)
            {
                // 拠点オプション無し
                ChangeSectionDisplay(false,false);
            }
            else
            {
                if (this._mainOfficeFunc == false)
                {
                    // 拠点設定
                    ChangeSectionDisplay(true, false);
                }
                else
                {
                    // 本社設定
                    ChangeSectionDisplay(true, true);
                }
            }

            // 前回検索情報有無判断
            if ((stockDatail == null) || (stockDatail.Count == 0)
				//||(_paraStockSlipCache_Display.SupplierFormal != this._defaultsupplierFormal)
				) 
            {
                // グリッド情報クリア
                this._searchSlipAcs.ClearStockSlipDataTable();

                // ヘッダ情報クリア処理
                this.ClearDisplayHeader();

                // ヘッダ初期表示処理
                this.SetDisplayHeaderInfo();
            }
            else
            {
                // 前回起動ヘッダ情報設定処理
                this.SetPrevHeader();

                // グリッドに初期フォーカスを設定
				this._inputDetails.uGrid_Details.Focus();
				this._inputDetails.timer_GridSetFocus.Enabled = true;
            }

            // ADD 2009/04/09 ------>>>
            // 自社設定を取得
            CompanyInf companyInf;
            this._companyAcs.Read(out companyInf, this._enterpriseCode);
            if (companyInf != null)
            {
                this._secMngDiv = companyInf.SecMngDiv;

                // 部門管理区分が拠点であれば部門名を非表示
                // 0:拠点　1:拠点＋部　2:拠点＋部＋課（ソースより）
                if (this._secMngDiv == 0)
                {
                    this.uLabel_SubSection.Visible = false;
                    this.tNedit_SubSectionCode.Visible = false;
                    this.uLabel_SubSectionName.Visible = false;
                    this.uButton_SubSectionGuide.Visible = false;
                }
            }
            this._inputDetails.SecMngDiv = this._secMngDiv;
            // ADD 2009/04/09 ------<<<
        }

        /// <summary>
        /// 画面ヘッダクリア処理
        /// </summary>
        private void ClearDisplayHeader()
        {
			this.tComboEditor_SupplierFormal.SelectedIndex = SupplierFormal;    // 伝票種別
			
			// 入荷状況			
			//0:仕入
			if (tComboEditor_SupplierFormal.SelectedIndex == 0)
			{
                foreach (Infragistics.Win.ValueListItem item in tComboEditor_ReconcileFlag.Items)
                {
                    if ((Int32)item.DataValue == ReconcileFlag)
                    {
                        tComboEditor_ReconcileFlag.SelectedIndex = (Int32)item.Tag - 1; // 1から始まるので
                        break;
                    }
                }
//				tComboEditor_ReconcileFlag.SelectedIndex = ReconcileFlag;
				tComboEditor_ReconcileFlag.Enabled = false;
				uLabel_Date1Title.Text = "仕入日";
			}
			//1:入荷
			else
			{
                foreach (Infragistics.Win.ValueListItem item in tComboEditor_ReconcileFlag.Items)
                {
                    if ((Int32)item.DataValue == ReconcileFlag)
                    {
                        tComboEditor_ReconcileFlag.SelectedIndex = (Int32)item.Tag - 1; // 1から始まるので
                        break;
                    }
                }
				tComboEditor_ReconcileFlag.Enabled = true;
				//tComboEditor_ReconcileFlag.SelectedIndex = ReconcileFlag;
				uLabel_Date1Title.Text = "入荷日";
			}

            foreach (Infragistics.Win.ValueListItem item in tComboEditor_SupplierSlipCd.Items)
            {
                if ((Int32)item.DataValue == SupplierSlipCd)
                {
                    switch ((Int32)item.DataValue)
                    {
                        case -1:     // 全て
                            tComboEditor_SupplierSlipCd.SelectedIndex = 0;
                            break;
                        case 0:		// 仕入
                            tComboEditor_SupplierSlipCd.SelectedIndex = 1;
                            break;
                        case 1:		// 返品
                            tComboEditor_SupplierSlipCd.SelectedIndex = 2;
                            break;
                        // --- DEL 2009/01/23 -------------------------------->>>>>
                        //case 100:	//現金仕入
                        //    tComboEditor_SupplierSlipCd.SelectedIndex = 3;
                        //    break;
                        //case 101:	//現金返品
                        //    tComboEditor_SupplierSlipCd.SelectedIndex = 4;
                        //    break;
                        // --- DEL 2009/01/23 --------------------------------<<<<<
                    }
                    //tComboEditor_SupplierSlipCd.SelectedIndex = (Int32)item.Tag; // 0から始まるので
                    break;
                }
            }
			//this.tComboEditor_SupplierSlipCd.SelectedIndex = SupplierSlipCd;	// 伝票区分
			this.tEdit_SectionCodeAllowZero.Text = SectionCode; // 拠点

			this.uLabel_SectionNm.Text = SectionName;		    // 拠点名

            // ADD 2009/04/09 ------>>>
            this.tNedit_SubSectionCode.Clear();                 // 部門コード
            this.uLabel_SubSectionName.Text = "";               // 部門名
            // ADD 2009/04/09 ------<<<
            
			this.tEdit_StockAgentCode.Clear();                  // 仕入担当
			this.uLabel_StockAgentName.Text = "";               // 仕入担当名

			this.tNedit_GoodsMakerCd.SetInt(GoodsMakerCode);	// メーカーコード
			this.uLabel_MakerName.Text = GoodsMakerName;	    // メーカー名

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //this.tNedit_SupplierCd.SetInt(CustomerCode);      // 得意先コード
            //this.uLabel_SupplierSnm.Text = CustomerName;      // 得意先名
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            this.tNedit_SupplierCd.SetInt( SupplierCd );        // 仕入先コード
            this.uLabel_SupplierSnm.Text = SupplierName;        // 仕入先名
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

            this.tEdit_WarehouseCode.Clear();                   // 倉庫コード
            this.uLabel_WarehouseName.Text = "";                // 倉庫名

            this.tDateEdit_Date1Start.Clear();                  // 仕入日(開始)
			this.tDateEdit_Date1End.Clear();                    // 仕入日(終了)

            this.tNedit_SupplierSlipNo_St.Clear();	            // 仕入SEQ番号(開始)
            // 2008.11.11 add start [7581]
            this.tNedit_SupplierSlipNo_Ed.Clear();	            // 仕入SEQ番号(終了)
            this.tEdit_PartySalesSlipNum.Clear();               // 伝票番号
            this.tDateEdit_InputDaySt.Clear();                  // 入力日(開始)
            this.tDateEdit_InputDayEd.Clear();                  // 入力日(終了)
            // 2008.11.11 add end [7581]


			this.tEdit_GoodsNo.Text = GoodsNo;                  // 商品コード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //this.uLabel_GoodsName.Text = GoodsName;           // 商品名
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
			this.tEdit_GoodsName.Clear();					    // 商品名検索

			this.tNedit_PayeeCode.Clear();					    // 支払先コード
			this.uLabel_PayeeSnm.Text = "";					    // 支払先名

			//this.tEdit_OrderNumber.Clear();					// 発注番号

            this.ChangeDecisionButtonEnable(false);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //this.timer_InitialSetFocus.Enabled = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL

			SetParaDisplayHeader();
        }

        /// <summary>
        /// ヘッダ情報をパラメータに格納
        /// </summary>
		private void SetParaDisplayHeader()
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.30 TOKUNAGA ADD START
            // メモリ内からピックアップ
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.30 TOKUNAGA ADD END
			//企業コード
            _paraStockSlipCache_Display.EnterpriseCode = this._enterpriseCode;


            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.30 TOKUNAGA ADD START
            // 画面上からピックアップ
            // 左上→右下へ向かって順に取得
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.30 TOKUNAGA ADD END
            // 拠点コード
            _paraStockSlipCache_Display.SectionCode = this.tEdit_SectionCodeAllowZero.Text;

            // 仕入先コード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.30 TOKUNAGA MODIFY START
            //_paraStockSlipCache_Display.CustomerCode = this.tNedit_SupplierCd.GetInt();
            _paraStockSlipCache_Display.SupplierCd = this.tNedit_SupplierCd.GetInt();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.30 TOKUNAGA MODIFY END

            // 支払先
            _paraStockSlipCache_Display.PayeeCode = this.tNedit_PayeeCode.GetInt();

			// 伝票種別(仕入形式)
            _paraStockSlipCache_Display.SupplierFormal = this.ValueToInt(this.tComboEditor_SupplierFormal.Value);

			// 伝票区分
			int supplierSlipCd = this.ValueToInt(this.tComboEditor_SupplierSlipCd.Value);
			switch (supplierSlipCd)
			{
                case -1: // 全て
                    _paraStockSlipCache_Display.SupplierSlipCd = -1;
                    _paraStockSlipCache_Display.AccPayDivCd = -1;
                    break;
				case 0:		//掛仕入
					_paraStockSlipCache_Display.SupplierSlipCd = 10;
					_paraStockSlipCache_Display.AccPayDivCd = 1;
					break;
				case 1:		//掛返品
					_paraStockSlipCache_Display.SupplierSlipCd = 20;
					_paraStockSlipCache_Display.AccPayDivCd = 1;
					break;
                // --- DEL 2009/01/23 -------------------------------->>>>>
                //case 100:	//現金仕入
                //    _paraStockSlipCache_Display.SupplierSlipCd = 10;
                //    _paraStockSlipCache_Display.AccPayDivCd = 0;
                //    break;
                //case 101:	//現金返品
                //    _paraStockSlipCache_Display.SupplierSlipCd = 20;
                //    _paraStockSlipCache_Display.AccPayDivCd = 0;
                //    break;
                // --- DEL 2009/01/23 --------------------------------<<<<<
			}

            // 入荷状況
            if (this.tComboEditor_ReconcileFlag.Enabled)
            {
                _paraStockSlipCache_Display.ReconcileFlag = this.ValueToInt(this.tComboEditor_ReconcileFlag.Value);
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.30 TOKUNAGA ADD START
            // 入力日
            _paraStockSlipCache_Display.InputDaySt = this.tDateEdit_InputDaySt.GetLongDate();
            _paraStockSlipCache_Display.InputDayEd = this.tDateEdit_InputDayEd.GetLongDate();

            // 仕入日
            //_paraStockSlipCache_Display.StockDateSt = this.tDateEdit_Date1Start.GetLongDate();
            //_paraStockSlipCache_Display.StockDateEd = this.tDateEdit_Date1End.GetLongDate();
            //仕入時：日付設定
            if (_paraStockSlipCache_Display.SupplierFormal == 0)
            {
                _paraStockSlipCache_Display.StockDateSt = this.tDateEdit_Date1Start.GetLongDate();
                _paraStockSlipCache_Display.StockDateEd = this.tDateEdit_Date1End.GetLongDate();
                _paraStockSlipCache_Display.ArrivalGoodsDaySt = 0;
                _paraStockSlipCache_Display.ArrivalGoodsDayEd = 0;
            }
            //入荷時：日付設定
            else
            {
                _paraStockSlipCache_Display.StockDateSt = 0;
                _paraStockSlipCache_Display.StockDateEd = 0;
                _paraStockSlipCache_Display.ArrivalGoodsDaySt = this.tDateEdit_Date1Start.GetLongDate();
                _paraStockSlipCache_Display.ArrivalGoodsDayEd = this.tDateEdit_Date1End.GetLongDate();
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.30 TOKUNAGA ADD END

            // 仕入SEQ番号
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.30 TOKUNAGA MODIFY START
            //_paraStockSlipCache_Display.SupplierSlipNo = this.ValueToInt(this.tNedit_SupplierSlipNo_St.Text);
            _paraStockSlipCache_Display.SupplierSlipNoSt = this.ValueToInt(this.tNedit_SupplierSlipNo_St.Text);
            _paraStockSlipCache_Display.SupplierSlipNoEd = this.ValueToInt(this.tNedit_SupplierSlipNo_Ed.Text);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.30 TOKUNAGA MODIFY END

            // 伝票番号
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.30 TOKUNAGA ADD START
            _paraStockSlipCache_Display.PartySaleSlipNum = this.tEdit_PartySalesSlipNum.Text.Trim();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.30 TOKUNAGA ADD END

            // 担当者コード
            _paraStockSlipCache_Display.StockAgentCode = this.tEdit_StockAgentCode.Text;

            // 倉庫コード
            _paraStockSlipCache_Display.WarehouseCode = this.tEdit_WarehouseCode.Text;


			// メーカーコード
			_paraStockSlipCache_Display.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();

            //// 曖昧検索フラグ
            //_paraStockSlipCache_Display.GoodsNmVagueSrch = this.CheckEditor_GoodsName.Checked;

			// 発注番号
			//_paraStockSlipCache_Display.OrderNumber = this.tEdit_OrderNumber.Text;

			// 商品コード
			_paraStockSlipCache_Display.GoodsNo = this.tEdit_GoodsNo.Text;

			// 検索商品
			//_paraStockSlipCache_Display.GoodsNmVagueSrch = CheckEditor_GoodsName.Checked;
			_paraStockSlipCache_Display.GoodsName = tEdit_GoodsName.Text;
		}

        /// <summary>
        /// 画面ヘッダ表示処理
        /// </summary>
        private void SetDisplayHeaderInfo()
        {
            // コンボボックス項目初期表示
			// 仕入形式
            //this.tComboEditor_SupplierFormal.SelectedIndex = this._defaultsupplierFormal;

            int status = 0;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            ////仕入先
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            ////if ( CustomerCode == 0 )
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            //if ( SupplierCd == 0 )
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
            //{
            //    this.tNedit_SupplierCd.Clear();
            //    this.uLabel_SupplierSnm.Text = "";
            //}
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            ////else if((CustomerCode != 0) && (CustomerName.Trim() == ""))
            ////{
            ////    int code = CustomerCode;
            ////    Supplier supplier;
            ////    status = this._supplierAcs.Read(out supplier, this._enterpriseCode, code);
            ////    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            ////    {
            ////        this.tNedit_SupplierCd.SetInt(code);
            ////        this.uLabel_SupplierSnm.Text = supplier.SupplierSnm;// Nm1;
            ////    }
            ////}
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            //else
            //{
            //    this.tNedit_SupplierCd.SetInt( SupplierCd );
            //    this.uLabel_SupplierSnm.Text = SupplierName;
            //}
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL

            // 拠点設定
			//this._paraStockSlipCache_Display.SectionCd = this._loginSectionCode;
            this._paraStockSlipCache_Display.SectionCode = this._loginSectionCode.Trim();
			this.tEdit_SectionCodeAllowZero.Text = this._loginSectionCode.Trim();

			SecInfoSet secInfoSet;
            status = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, this._loginSectionCode.Trim());
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                this.uLabel_SectionNm.Text = secInfoSet.SectionGuideNm.Trim();
			}

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
            // 売上日初期値
            tDateEdit_Date1Start.SetDateTime( GetPrevTotalDayNextDay( _loginSectionCode.Trim() ) );
            tDateEdit_Date1End.SetDateTime( DateTime.Today );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
        }

        /// <summary>
        /// 拠点 表示切替処理
        /// </summary>
        private void ChangeSectionDisplay(bool visible,bool enabled)
        {
#if False
			this.uLabel_SectionTitle.Visible = visible;
            this.tEdit_SectionCd.Visible = visible;
            this.uLabel_SectionNm.Visible = visible;
            this.uButton_SectionGuide.Visible = visible;

            this.uLabel_SectionTitle.Enabled = enabled;
            this.tEdit_SectionCd.Enabled = enabled;
            this.uLabel_SectionNm.Enabled = enabled;
            this.uButton_SectionGuide.Enabled = enabled;
#endif
		}

        /// <summary>
        /// 前回起動ヘッダ情報設定処理
        /// </summary>
        private void SetPrevHeader()
        {
#if False
#if False
			StcHisRefExtraParamWork stcHisRefExtraParamWork = this._searchSlipAcs.GetParaStockSlipCache();
            if(stcHisRefExtraParamWork == null)
            {
                return;
            }
#endif

			SortedList nameList = this._searchSlipAcs.GetCacheNmaeList();

			if (nameList == null)
			{
				return;
			}

			// 仕入形式
			this.tComboEditor_SupplierFormal.SelectedIndex = stcHisRefExtraParamWork.SupplierFormal;

#if False
			// 拠点
			this.tEdit_SectionCd.Text = stcHisRefExtraParamWork.SectionCd;
			if (nameList.Contains("SectionNm")) this.uLabel_SectionNm.Text = nameList["SectionNm"].ToString();
#endif

			// 仕入先コード
			this.tNedit_CustomerCode.SetInt(stcHisRefExtraParamWork.CustomerCode);
			if (nameList.Contains("CustomerName")) this.uLabel_CustomerName.Text = nameList["CustomerName"].ToString();

			// メーカーコード
			//this.tNedit_GoodsMakerCd.SetInt(stcHisRefExtraParamWork.GoodsMakerCd);
			if (nameList.Contains("MakerName")) this.uLabel_MakerName.Text = nameList["MakerName"].ToString();

			// 仕入日(開始)-(終了)
			//this.tDateEdit_Date1Start.LongDate = TDateTime.DateTimeToLongDate(stcHisRefExtraParamWork.StockDateSt);          // 仕入日(開始)
			//this.tDateEdit_Date1End.LongDate = TDateTime.DateTimeToLongDate(stcHisRefExtraParamWork.StockDateEd);            // 仕入日(終了)

			//支払先
			//this.tNedit_CustomerCode.SetInt(stcHisRefExtraParamWork.PayeeCode);
			if (nameList.Contains("PayeeSnm")) this.uLabel_PayeeSnm.Text = nameList["PayeeSnm"].ToString();                    // 得意先名

			// 仕入担当者コード
			this.tEdit_StockAgentCode.Text = stcHisRefExtraParamWork.StockAgentCode;                    // 仕入担当
			if (nameList.Contains("StockAgentName")) this.uLabel_StockAgentName.Text = nameList["StockAgentName"].ToString();                // 仕入担当名

			// 倉庫コード	
			this.tEdit_WarehouseCode.Text = stcHisRefExtraParamWork.WarehouseCode;                      // 倉庫コード
			if (nameList.Contains("WarehouseName")) this.uLabel_WarehouseName.Text = nameList["WarehouseName"].ToString();                  // 倉庫名

			// 伝票番号
			this.tEdit_SupplierSlipNo.Text = stcHisRefExtraParamWork.SupplierSlipNo.ToString();

			// 発注番号
			//this.tEdit_OrderNumber.Text = stcHisRefExtraParamWork.OrderNumber.ToString();

#if False
			// 商品コード
			this.tEdit_GoodsCode.Text = stcHisRefExtraParamWork.GoodsCode;                              // 商品コード
			this.uLabel_GoodsName.Text = nameList["GoodsName"].ToString();                          // 商品名
#endif

			// 商品名検索
			//tEdit_GoodsName.Text = stcHisRefExtraParamWork.SearchGoodsName;

			// 買掛区分(1、2のIndexが逆)
            int selectIndex = ConvertComboEditorIndex(stcHisRefExtraParamWork.AccPayDivCd);
            switch(selectIndex)
            {
                case 1:
                    {
                        selectIndex = 2;
                        break;
                    }
                case 2:
                    {
                        selectIndex = 1;
                        break;
                    }
            }
            this.tComboEditor_AccPayDivCd.SelectedIndex = selectIndex;
#endif
		}

        /// <summary>
        /// コンボエディタIndex制御処理
        /// </summary>
        /// <param name="targetValue">コンボエディタ値</param>
        /// <param name="">通常値順序逆順判定</param>
        private int ConvertComboEditorIndex(int targetValue)
        {
            int retIndex = 0;

            switch (targetValue)
            {
                case 10:      // 伝票区分 "仕入"
                    {
                        retIndex = 1;
                        break;
                    }
                case 20:      // 伝票区分 "返品"
                    {
                        retIndex = 2;
                        break;
                    }
                // --- DEL 2009/01/23 -------------------------------->>>>>
                //case 30:      // 伝票区分 "現金仕入"
                //    {
                //        retIndex = 3;
                //        break;
                //    }
                //case 40:      // 伝票区分 "現金返品"
                //    {
                //        retIndex = 4;
                //        break;
                //    }
                // --- DEL 2009/01/23 --------------------------------<<<<<
				case 99:      // "全て"
                    {
                        retIndex = 0;
                        break;
                    }
                default:      
                    {
                        // "全て"が先頭なのでそれ以降は + 1
                        retIndex = targetValue + 1;
                        break;
                    }
            }

            return retIndex;
        }

		/// <summary>
		/// ボタン初期設定処理
		/// </summary>
		private void ButtonInitialSetting()
		{
			this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
			this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
			this._decisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
			this._undoButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;

			//imageList16
			this.uButton_EmployeeGuide.ImageList = this._imageList16;
			this.uButton_GoodsMakerGuide.ImageList = this._imageList16;
			this.uButton_SupplierGuide.ImageList = this._imageList16;
			this.uButton_WarehouseGuide.ImageList = this._imageList16;
            this.uButton_SectionGuide.ImageList = this._imageList16;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //this.uButton_GoodsGuide.ImageList = this._imageList16;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
			this.uButton_PayeeGuide.ImageList = this._imageList16;

			//STAR1
            this.uButton_EmployeeGuide.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_GoodsMakerGuide.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_SupplierGuide.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_WarehouseGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //this.uButton_GoodsGuide.Appearance.Image = (int)Size16_Index.STAR1;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
			this.uButton_PayeeGuide.Appearance.Image = (int)Size16_Index.STAR1;

            // ADD 2009/04/09 ------>>>
            this.uButton_SubSectionGuide.ImageList = this._imageList16;
            this.uButton_SubSectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
            // ADD 2009/04/09 ------<<<
        }

        /// <summary>
        /// 終了項目値自動設定処理(TDateEdit)
        /// </summary>
        /// <param name="startDate">開始日付項目TDateEdit</param>
        /// <param name="endDate">終了日付項目TDateEdit</param>
        private void AutoSetEndValue(TDateEdit startDate, TDateEdit endDate)
        {
            if (endDate.LongDate == 0)
            {
                endDate.SetLongDate(startDate.LongDate);
            }
        }

        /// <summary>
        /// 終了項目値自動設定処理(TEdit)
        /// </summary>
        /// <param name="startDate">開始日付項目TEdit</param>
        /// <param name="endDate">終了日付項目TEdit</param>
        private void AutoSetEndValue(TEdit startEdit, TEdit endEdit)
        {
            if (endEdit.Text == "")
            {
                endEdit.Text = startEdit.Text;
            }
        }

        /// <summary>
        /// 読込条件パラメータ設定処理
        /// </summary>
        public void SetReadPara(out StcHisRefExtraParamWork stcHisRefExtraParamWork)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            // *曖昧検索用作業項目
            string searchText;
            int searchType;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD

            stcHisRefExtraParamWork = new StcHisRefExtraParamWork();

			//企業コード
            stcHisRefExtraParamWork.EnterpriseCode = this._enterpriseCode;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.30 TOKUNAGA ADD START
            // 画面上からピックアップ
            // 左上→右下へ向かって順に取得
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.30 TOKUNAGA ADD END
            //拠点コード
            //stcHisRefExtraParamWork.SectionCd = this.tEdit_SectionCodeAllowZero.Text;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //stcHisRefExtraParamWork.SectionCode = this.tEdit_SectionCodeAllowZero.Text;
            //if ( stcHisRefExtraParamWork.SectionCode == "000000" )
            //{
            //    stcHisRefExtraParamWork.SectionCode = "";
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            // 拠点コード
            stcHisRefExtraParamWork.SectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim();

            // 拠点コードゼロ
            UiSet uiset;
            uiSetControl1.ReadUISet( out uiset, tEdit_SectionCodeAllowZero.Name );

            // 00:全社ならstring.Emptyで上書き
            string sectionZero = new string( '0', uiset.Column );
            if ( stcHisRefExtraParamWork.SectionCode == sectionZero )
            {
                stcHisRefExtraParamWork.SectionCode = string.Empty;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD

            // 部門コード
            stcHisRefExtraParamWork.SubSectionCode = this.tNedit_SubSectionCode.GetInt();   // ADD 2009/04/09

            // 仕入先コード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.30 TOKUNAGA MODIFY START
            //stcHisRefExtraParamWork.CustomerCode = this.tNedit_SupplierCd.GetInt();
            stcHisRefExtraParamWork.SupplierCd = this.tNedit_SupplierCd.GetInt();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.30 TOKUNAGA MODIFY END

            // 支払先
            stcHisRefExtraParamWork.PayeeCode = this.tNedit_PayeeCode.GetInt();

            // 伝票種別(仕入形式)
            stcHisRefExtraParamWork.SupplierFormal = this.ValueToInt(this.tComboEditor_SupplierFormal.Value);

            // 伝票区分
            int supplierSlipCd = this.ValueToInt(this.tComboEditor_SupplierSlipCd.Value);
            switch (supplierSlipCd)
            {
                // 2008.11.20 add start [7948]
                case -1:     // 全て
                    stcHisRefExtraParamWork.SupplierSlipCd = -1;
                    stcHisRefExtraParamWork.AccPayDivCd = -1;
                    break;
                // 2008.11.20 add end [7948]
                case 0:		// 仕入
                    stcHisRefExtraParamWork.SupplierSlipCd = 10;
                    stcHisRefExtraParamWork.AccPayDivCd = 1;
                    break;
                case 1:		// 返品
                    stcHisRefExtraParamWork.SupplierSlipCd = 20;
                    stcHisRefExtraParamWork.AccPayDivCd = 1;
                    break;
                // --- DEL 2009/01/23 -------------------------------->>>>>
                //case 100:	//現金仕入
                //    stcHisRefExtraParamWork.SupplierSlipCd = 10;
                //    stcHisRefExtraParamWork.AccPayDivCd = 0;
                //    break;
                //case 101:	//現金返品
                //    stcHisRefExtraParamWork.SupplierSlipCd = 20;
                //    stcHisRefExtraParamWork.AccPayDivCd = 0;
                //    break;
                // --- DEL 2009/01/23 --------------------------------<<<<<
            }

            // 入荷状況
            if (this.tComboEditor_ReconcileFlag.Enabled)
            {
                stcHisRefExtraParamWork.ReconcileFlag = this.ValueToInt(this.tComboEditor_ReconcileFlag.Value);
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.30 TOKUNAGA ADD START
            // 入力日
            // 2008.11.13 modify start [7774]
            stcHisRefExtraParamWork.InputDaySt = this.tDateEdit_InputDaySt.GetLongDate();

            // --- DEL 2009/04/03 -------------------------------->>>>>
            //// 入力日のみの入力されていた場合は、開始日が[入力日]で終了日が[今日]
            //if (this.tDateEdit_InputDayEd.GetLongDate() != 0)
            //{
            //    stcHisRefExtraParamWork.InputDayEd = TDateTime.DateTimeToLongDate(DateTime.Today);
            //}
            //else
            //{
            //    stcHisRefExtraParamWork.InputDayEd = this.tDateEdit_InputDayEd.GetLongDate();
            //}
            // --- DEL 2009/04/03 --------------------------------<<<<<
            stcHisRefExtraParamWork.InputDayEd = this.tDateEdit_InputDayEd.GetLongDate(); // ADD 2009/04/03

            // 2008.11.13 modify end [7774]

            //// 仕入日
            //stcHisRefExtraParamWork.StockDateSt = this.tDateEdit_Date1Start.GetLongDate();
            //stcHisRefExtraParamWork.StockDateEd = this.tDateEdit_Date1End.GetLongDate();

            //仕入時：日付設定
            if (stcHisRefExtraParamWork.SupplierFormal == 0)
            {
                stcHisRefExtraParamWork.StockDateSt = this.tDateEdit_Date1Start.GetLongDate();
                stcHisRefExtraParamWork.StockDateEd = this.tDateEdit_Date1End.GetLongDate();
                stcHisRefExtraParamWork.ArrivalGoodsDaySt = 0;
                stcHisRefExtraParamWork.ArrivalGoodsDayEd = 0;
            }
            //入荷時：日付設定
            else if (stcHisRefExtraParamWork.SupplierFormal == 1)
            {
                stcHisRefExtraParamWork.StockDateSt = 0;
                stcHisRefExtraParamWork.StockDateEd = 0;
                stcHisRefExtraParamWork.ArrivalGoodsDaySt = this.tDateEdit_Date1Start.GetLongDate();
                stcHisRefExtraParamWork.ArrivalGoodsDayEd = this.tDateEdit_Date1End.GetLongDate();
            }
            // 2008.11.11 add start [7588]
            else // -1のとき
            {
                //stcHisRefExtraParamWork.StockDateSt = 0;
                //stcHisRefExtraParamWork.StockDateEd = 0;
                // 伝票種別が[全て]のときは、両方に設定が必要
                stcHisRefExtraParamWork.StockDateSt = this.tDateEdit_Date1Start.GetLongDate();
                stcHisRefExtraParamWork.StockDateEd = this.tDateEdit_Date1End.GetLongDate();
                stcHisRefExtraParamWork.ArrivalGoodsDaySt = this.tDateEdit_Date1Start.GetLongDate();
                stcHisRefExtraParamWork.ArrivalGoodsDayEd = this.tDateEdit_Date1End.GetLongDate();
            }
            // 2008.11.11 add end [7588]
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.30 TOKUNAGA ADD END

            // 仕入SEQ番号
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.30 TOKUNAGA MODIFY START
            //stcHisRefExtraParamWork.SupplierSlipNo = this.ValueToInt(this.tNedit_SupplierSlipNo_St.Text);
            stcHisRefExtraParamWork.SupplierSlipNoSt = this.ValueToInt(this.tNedit_SupplierSlipNo_St.Text);
            stcHisRefExtraParamWork.SupplierSlipNoEd = this.ValueToInt(this.tNedit_SupplierSlipNo_Ed.Text);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.30 TOKUNAGA MODIFY END

            // 伝票番号
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.30 TOKUNAGA ADD START
            //stcHisRefExtraParamWork.PartySaleSlipNum = this.tEdit_PartySalesSlipNum.Text.Trim();
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.30 TOKUNAGA ADD END
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            // 2008.11.11 modify start [7589]
            if (!this.tEdit_PartySalesSlipNum.Text.Trim().Equals("*"))
            {
                GetSearchType(this.tEdit_PartySalesSlipNum.Text.Trim(), out searchText, out searchType);
                stcHisRefExtraParamWork.PartySaleSlipNum = searchText;
                stcHisRefExtraParamWork.PartySaleSlipNumSrchTyp = searchType;
            }
            // 2008.11.11 modify end [7589]
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD

            // 担当者コード
            stcHisRefExtraParamWork.StockAgentCode = this.tEdit_StockAgentCode.Text;

            // 倉庫コード
            stcHisRefExtraParamWork.WarehouseCode = this.tEdit_WarehouseCode.Text;


            // メーカーコード
            stcHisRefExtraParamWork.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();

            //// 曖昧検索フラグ
            //stcHisRefExtraParamWork.GoodsNmVagueSrch = this.CheckEditor_GoodsName.Checked;

            // 発注番号
            //stcHisRefExtraParamWork.OrderNumber = this.tEdit_OrderNumber.Text;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //// 商品コード
            //stcHisRefExtraParamWork.GoodsNo = this.tEdit_GoodsNo.Text;

            //// 検索商品
            //stcHisRefExtraParamWork.GoodsName = tEdit_GoodsName.Text;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            // 品番
            // 2008.11.11 modify start [7592]
            if (!this.tEdit_GoodsNo.Text.Trim().Equals("*"))
            {
                GetSearchType(this.tEdit_GoodsNo.Text.Trim(), out searchText, out searchType);
                stcHisRefExtraParamWork.GoodsNo = searchText;
                stcHisRefExtraParamWork.GoodsNoSrchTyp = searchType;
            }
            // 2008.11.11 modify end [7592]

            // 品名
            // 2008.11.11 modify start [7591]
            if (!this.tEdit_GoodsName.Text.Trim().Equals("*"))
            {
                GetSearchType(this.tEdit_GoodsName.Text.Trim(), out searchText, out searchType);
                stcHisRefExtraParamWork.GoodsName = searchText;
                stcHisRefExtraParamWork.GoodsNameSrchTyp = searchType;
            }
            // 2008.11.11 modify end [7591]
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD

            this._inputDetails._stcHisRefExtraParamWork = stcHisRefExtraParamWork;
			this._inputDetails.DisplayModeSetting();
		}

        /// <summary>
        /// Valueチェック処理（int）
        /// </summary>
        /// <param name="sorce">tComboのValue</param>
        /// <returns>チェック後の値</returns>
        /// <remarks>
        /// <br>Note		: tComboの値をClassに入れる時のNULLチェックを行います。</br>
        /// <br>Programmer	: 980023 飯谷 耕平</br>
        /// <br>Date		: 2007.01.29</br>
        /// </remarks>
        private int ValueToInt(object sorce)
        {
            int dest = 0;
            try
            {
                dest = Convert.ToInt32(sorce);
            }
            catch
            {
                return dest;
            }
            return dest;
        }

        /// <summary>
        /// 画面名称リスト取得処理
        /// </summary>
        /// <returns>画面名称値リスト</returns>
        private SortedList GetDisplayNameList()
        {
            SortedList nameList = new SortedList();

            nameList.Add("CustomerName", this.uLabel_SupplierSnm.Text);
            nameList.Add("StockAgentName", this.uLabel_StockAgentName.Text);
            nameList.Add("WarehouseName", this.uLabel_WarehouseName.Text);
            nameList.Add("SectionNm", this.uLabel_SectionNm.Text);
			nameList.Add("MakerName", this.uLabel_MakerName.Text);
			nameList.Add("PayeeSnm", this.uLabel_PayeeSnm.Text);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //nameList.Add("GoodsName", this.uLabel_GoodsName.Text);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
            return nameList;
        }

        /// <summary>
        /// 初期フォーカス設定処理
        /// </summary>
        public Control SetInitFocus(object sender)
        {
			Control _control;

			if (this._inputDetails.uGrid_Details.Rows.Count > 0)
			{
	            this._inputDetails.uGrid_Details.Enabled = true;
				_control = this._inputDetails.uGrid_Details;
			}
			else
			{
				this._inputDetails.uGrid_Details.Enabled = false;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.29 TOKUNAGA MODIFY START
                //if (tComboEditor_SupplierFormal.Enabled == true)
                //{
                //    _control = this.tComboEditor_SupplierFormal;
                //}
                //else
                //{
                //    _control = this.tComboEditor_SupplierSlipCd;
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.29 TOKUNAGA MODIFY END
                _control = this.tEdit_SectionCodeAllowZero;
			}

			_control.Focus();
            return _control;
		}
       
        /// <summary>
        /// 画面終了処理
        /// </summary>
        public void CloseForm()
        {
            this.Close();
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/16 ADD
        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_OrderDataCreateDate"></param>
        /// <param name="tde_Ed_OrderDataCreateDate"></param>
        /// <returns></returns>
        private bool CallCheckDateRange( out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_st, ref TDateEdit tde_ed, bool mode, int ym )
        {
            cdrResult = _dateGet.CheckDateRange( DateGetAcs.YmdType.YearMonth, ym, ref tde_st, ref tde_ed, mode );
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/16 ADD        
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/16 ADD
        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage"></param>
        /// <returns></returns>
        private Control CheckInputPara( out string errMessage )
        {
            Control errComponent = null;
            DateGetAcs.CheckDateRangeResult cdrResult;
            errMessage = string.Empty;

            // 仕入日（開始～終了）
            string kbnNm = uLabel_Date1Title.Text;
            //if ( CallCheckDateRange( out cdrResult, ref tDateEdit_Date1Start, ref tDateEdit_Date1End, false, 3 ) == false ) // DEL 2009/04/03
            if (CallCheckDateRange(out cdrResult, ref tDateEdit_Date1Start, ref tDateEdit_Date1End, true, 0) == false) // ADD 2009/04/03
            {
                switch ( cdrResult )
                {
                    // --- DEL 2009/04/03 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                    //    {
                    //        errMessage = string.Format( "開始" + kbnNm + "{0}", ct_NoInput );
                    //        errComponent = this.tDateEdit_Date1Start;
                    //    }
                    //    break;
                    // --- DEL 2009/04/03 --------------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format( "開始" + kbnNm + "{0}", ct_InputError );
                            errComponent = this.tDateEdit_Date1Start;
                        }
                        break;
                    // --- DEL 2009/04/03 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                    //    {
                    //        errMessage = string.Format( "終了" + kbnNm + "{0}", ct_NoInput );
                    //        errComponent = this.tDateEdit_Date1End;
                    //    }
                    //    break;
                    // --- DEL 2009/04/03 --------------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format( "終了" + kbnNm + "{0}", ct_InputError );
                            errComponent = this.tDateEdit_Date1End;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        // --- ADD 2009/04/03 -------------------------------->>>>>
                        {
                            errMessage = string.Format(kbnNm + "{0}", ct_RangeError);
                            errComponent = this.tDateEdit_Date1Start;
                        }
                        break;
                    // --- ADD 2009/04/03 -------------------------------->>>>>
                    // --- DEL 2009/04/03 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnMonth:
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                    //    {
                    //        // 2008.11.17 modify start [7913]
                    //        errMessage = string.Format(kbnNm + "{0}", ct_RangeOverError);
                    //        //errMessage = string.Format(kbnNm + "{0}", ct_RangeError);
                    //        // 2008.11.17 modify end [7913]
                    //        errComponent = this.tDateEdit_Date1Start;
                    //    }
                    //    break;
                    // --- DEL 2009/04/03 --------------------------------<<<<<
                }

                if (errComponent != null) // ADD 2009/04/07
                {
                    return errComponent;
                }
            }
            // 入力日（開始～終了）
            if ( CallCheckDateRange( out cdrResult, ref tDateEdit_InputDaySt, ref tDateEdit_InputDayEd, true, 0 ) == false )
            {
                switch ( cdrResult )
                {
                    // 2008.11.11 del start [7599]
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                    //    {
                    //        errMessage = string.Format( "開始入力日{0}", ct_NoInput );
                    //        errComponent = this.tDateEdit_InputDaySt;
                    //    }
                    //    break;
                    // 2008.11.11 del end [7599]
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("開始入力日{0}", ct_InputError);
                            errComponent = this.tDateEdit_InputDaySt;
                        }
                        break;
                    // 2008.11.11 del start [7599]
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                    //    {
                    //        errMessage = string.Format( "終了入力日{0}", ct_NoInput );
                    //        errComponent = this.tDateEdit_InputDayEd;
                    //    }
                    //    break;
                    // 2008.11.11 del end [7599]
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("終了入力日{0}", ct_InputError);
                            errComponent = this.tDateEdit_InputDayEd;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("入力日{0}", ct_RangeError);
                            errComponent = this.tDateEdit_InputDaySt;
                        }
                        break;
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnMonth:
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                    //    {
                    //        errMessage = string.Format( "入力日{0}", ct_RangeOverError );
                    //        errComponent = this.tDateEdit_InputDaySt;
                    //    }
                    //    break;
                }

                if (errComponent != null) // ADD 2009/04/07
                {
                    return errComponent;
                }
            }

            // 伝票番号
            long start = 0;
            long end = 0;
            if (!String.IsNullOrEmpty(this.tNedit_SupplierSlipNo_St.Text.Trim()))
            {
                try
                {
                    start = long.Parse(this.tNedit_SupplierSlipNo_St.Text.Trim());
                }
                catch
                {
                    errMessage = "仕入SEQ番号は数字で入力してください。";
                    errComponent = this.tNedit_SupplierSlipNo_St;
                    return errComponent;
                }
            }

            if (!String.IsNullOrEmpty(this.tNedit_SupplierSlipNo_Ed.Text.Trim()))
            {
                try
                {
                    end = long.Parse(this.tNedit_SupplierSlipNo_Ed.Text.Trim());
                }
                catch
                {
                    errMessage = "仕入SEQ番号は数字で入力してください。";
                    errComponent = this.tNedit_SupplierSlipNo_Ed;
                    return errComponent;
                }
            }

            if (start > 0 && end > 0 && start - end > 0)
            {
                errMessage = "仕入SEQ番号（開始）は仕入SEQ番号（終了）より小さい値を入力してください。";
                errComponent = this.tNedit_SupplierSlipNo_St;
                return errComponent;
            }

            return errComponent;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/16 ADD

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/16 DEL
        ///// <summary>
        ///// 入力項目チェック処理
        ///// </summary>
        //private Control CheckInputPara()
        //{
        //    // 大小チェック
        //    // 仕入日
        //    if ( this.tDateEdit_Date1Start.LongDate > this.tDateEdit_Date1End.LongDate )
        //    {
        //        this.tDateEdit_Date1Start.Focus();
        //        SetStatusBarMessage( this, MESSAGE_StartEndError );
        //        return tDateEdit_Date1Start;
        //    }

        //    // 有効チェック
        //    DateTime retDateTime = new DateTime();

        //    // 開始仕入日
        //    if ( this.tDateEdit_Date1Start.LongDate == 0 )
        //    {
        //        //    // 仕入形式が受託の場合は入力必須
        //        //    this.tDateEdit_Date1Start.Focus();
        //        //    SetStatusBarMessage(this, MESSAGE_NoInput);
        //        //	return tDateEdit_Date1Start;
        //    }
        //    else
        //    {
        //        if ( DateTime.TryParse( this.tDateEdit_Date1Start.GetDateTimeString( "yyyy.MM.DD" ), out retDateTime ) == false )
        //        {
        //            this.tDateEdit_Date1Start.Focus();
        //            SetStatusBarMessage( this, MESSAGE_InvalidDate );
        //            return tDateEdit_Date1Start;
        //        }
        //    }

        //    // 終了仕入日
        //    if ( this.tDateEdit_Date1End.LongDate == 0 )
        //    {
        //        //    // 仕入形式が受託の場合は入力必須
        //        //    this.tDateEdit_Date1End.Focus();
        //        //    SetStatusBarMessage(this, MESSAGE_NoInput);
        //        //	return tDateEdit_Date1End;
        //    }
        //    else
        //    {
        //        if ( DateTime.TryParse( this.tDateEdit_Date1End.GetDateTimeString( "yyyy.MM.DD" ), out retDateTime ) == false )
        //        {
        //            this.tDateEdit_Date1End.Focus();
        //            SetStatusBarMessage( this, MESSAGE_InvalidDate );
        //            return tDateEdit_Date1End;
        //        }
        //    }

        //    // 入力支援
        //    // 仕入日
        //    AutoSetEndValue( this.tDateEdit_Date1Start, this.tDateEdit_Date1End );

        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.29 TOKUNAGA DEL START
        //    //// 拠点
        //    //if(this.tEdit_SectionCodeAllowZero.Text.Trim() == "")
        //    //{
        //    //    this.tEdit_SectionCodeAllowZero.Focus();
        //    //    SetStatusBarMessage(this, MESSAGE_NoInput);
        //    //    return tEdit_SectionCodeAllowZero;
        //    //}

        //    //// 仕入先
        //    //if (this.tNedit_SupplierCd.GetInt() == 0)
        //    //{
        //    //    this.tNedit_SupplierCd.Focus();
        //    //    SetStatusBarMessage(this, MESSAGE_NoInput);
        //    //    return tNedit_SupplierCd;
        //    //}
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.29 TOKUNAGA DEL END

        //    return null;
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/16 DEL

        /// <summary>
        /// 伝票検索実行処理
        /// </summary>
        private Control SearchSlip()
        {
            // ADD 2009/12/04 MANTIS対応[14745]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
            // FIXME:検索前にグリッド列の表示設定を保存
            GridSettings.DetailColumnsList = SlipGridUtil.CreateColumnInfoList(this._inputDetails.DetailGrid);
            SlipGridUtil.StoreGridSettings(GridSettings, XML_FILE_NAME);
            // ADD 2009/12/04 MANTIS対応[14745]：伝票および明細グリッド列の列設定の変更 ----------<<<<<

            // 入力項目チェック処理
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/16 DEL
            //Control control = this.CheckInputPara();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/16 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/16 ADD
            string errMsg;
            Control control = this.CheckInputPara( out errMsg );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/16 ADD
			if (control != null)
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/16 ADD
                // エラーメッセージ表示
                // 2008.12.03 modify start [7913]
                //SetStatusBarMessage( this, errMsg );
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                        errMsg, 0, MessageBoxButtons.OK);
                // 2008.12.03 modify end [7913]
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/16 ADD
                return control;
            }

            StcHisRefExtraParamWork stcHisRefExtraParamWork = new StcHisRefExtraParamWork();
            bool setEnable = false;

            // 読込条件パラメータクラス設定処理
            this.SetReadPara(out stcHisRefExtraParamWork);

			// 伝票情報読込・データセット格納処理
			this._searchSlipAcs.SetSearchData(stcHisRefExtraParamWork);
			
			setEnable = this._inputDetails.SetGridEnable();
            if (setEnable == true)
            {
                this._inputDetails.uGrid_Details.Focus();
                this._inputDetails.timer_GridSetFocus.Enabled = true;
            }
            else
            {
                //this._inputDetails.uButton_StockSearch.Enabled = false;
            }

            // ADD 2009/12/04 MANTIS対応[14745]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
            // FIXME:検索後も列移動と列固定を可能とする
            SlipGridUtil.EnableAllowColSwappingAndFixedHeaderIndicator(this._inputDetails.DetailGrid);
            // FIXME:検索後もグリッド列の設定を取込
            SlipGridUtil.LoadColumnInfo(this._inputDetails.DetailGrid, GridSettings.DetailColumnsList);
            // ADD 2009/12/04 MANTIS対応[14745]：伝票および明細グリッド列の列設定の変更 ----------<<<<<

			return null;
        }

        /// <summary>
        /// ダイアログリザルト設定処理
        /// </summary>
        /// <param name="dialogRes">ダイアログリザルト</param>
        public void SetDialogRes(DialogResult dialogRes)
        {
            _dialogRes = dialogRes;
        }

#if False
        /// <summary>
        /// 検索条件クラス(変更判断用) クリア処理
        /// </summary>
        private void ClearParaStockSlip_Display()
        {
            // 検索条件値
            if (_paraStockSlipCache_Display == null)
            {
                return;
            }
            _paraStockSlipCache_Display.CustomerCode = 0;      // 仕入先
            //_paraStockSlipCache_Display.CarrierEpCode = 0;     // 事業者
            _paraStockSlipCache_Display.StockAgentCode = "";   // 担当者
            _paraStockSlipCache_Display.WarehouseCode = "";    // 倉庫
            _paraStockSlipCache_Display.SectionCd = "";   // 拠点
            _paraStockSlipCache_Display.GoodsNo = "";        // 商品
        }
#endif

#if False
        /// <summary>
        /// 前回/今回検索条件比較処理
        /// </summary>
        /// <param name="">検索条件クラス(今回条件)</param>
        /// <returns>true:一致、false:不一致</returns>
        private bool CheckSearchParam(StcHisRefExtraParamWork stcHisRefExtraParamWork)
        {
            // 前回検索条件の取得
            StcHisRefExtraParamWork prevSearchParaStockSlip = this._searchSlipAcs.GetParaStockSlipCache();
            if (prevSearchParaStockSlip == null)
            {
                return false;
            }

            // 仕入形式
            if (stcHisRefExtraParamWork.SupplierFormal != prevSearchParaStockSlip.SupplierFormal)
            {
                return false;
            }

            // 伝票区分
            if (stcHisRefExtraParamWork.SupplierSlipCd != prevSearchParaStockSlip.SupplierSlipCd)
            {
                return false;
            }

            // 赤伝区分
            if (stcHisRefExtraParamWork.DebitNoteDiv != prevSearchParaStockSlip.DebitNoteDiv)
            {
                return false;
            }

            // 商品区分
            if (stcHisRefExtraParamWork.StockGoodsCd != prevSearchParaStockSlip.StockGoodsCd)
            {
                return false;
            }

            // 買掛区分
            if (stcHisRefExtraParamWork.AccPayDivCd != prevSearchParaStockSlip.AccPayDivCd)
            {
                return false;
            }

            // 拠点
            if (stcHisRefExtraParamWork.SectionCd != prevSearchParaStockSlip.StockSectionCd)
            {
                return false;
            }

            // 入荷日
            if ((stcHisRefExtraParamWork.ArrivalGoodsDayStart != prevSearchParaStockSlip.ArrivalGoodsDayStart) ||
                (stcHisRefExtraParamWork.ArrivalGoodsDayEnd != prevSearchParaStockSlip.ArrivalGoodsDayEnd))
            {
                return false;
            }

            // 計上日
            if ((stcHisRefExtraParamWork.StockAddUpADateStart != prevSearchParaStockSlip.StockAddUpADateStart) ||
                (stcHisRefExtraParamWork.StockAddUpADateEnd != prevSearchParaStockSlip.StockAddUpADateEnd))
            {
                return false;
            }

            // 仕入先
            if (stcHisRefExtraParamWork.CustomerCode != prevSearchParaStockSlip.CustomerCode)
            {
                return false;
            }

            // 事業者
            //if (stcHisRefExtraParamWork.CarrierEpCode != prevSearchParaStockSlip.CarrierEpCode)
            //{
            //    return false;
            //}

            // 仕入先担当
            if (stcHisRefExtraParamWork.StockAgentCode != prevSearchParaStockSlip.StockAgentCode)
            {
                return false;
            }

            // 倉庫
            if (stcHisRefExtraParamWork.WarehouseCode != prevSearchParaStockSlip.WarehouseCode)
            {
                return false;
            }

            // 相手先伝番
            if (stcHisRefExtraParamWork.PartySaleSlipNum != prevSearchParaStockSlip.PartySaleSlipNum)
            {
                return false;
            }

			// 伝票番号
			if (stcHisRefExtraParamWork.SupplierSlipNo != prevSearchParaStockSlip.SupplierSlipNo)
			{
				return false;
			}


            // 商品
            if (stcHisRefExtraParamWork.GoodsNo!= prevSearchParaStockSlip.GoodsCode)
            {
                return false;
            }

            return true;
        }
#endif

        /// <summary>
        /// 「確定」ボタン表示変更処理
        /// </summary>
        /// <param name="enable">表示設定(true:表示、false:非表示)</param>
        private void ChangeDecisionButtonEnable(bool enableSet)
        {
			if (this._inputDetails.StartMovment == 1) enableSet = false;
			this._decisionButton.SharedProps.Visible = enableSet; //[9060]
            //this._decisionButton.SharedProps.Enabled = enableSet;
        }



        # region 各コントロールイベント処理

        /// <summary>
        /// ツールバーボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        this.SetDialogRes(DialogResult.Cancel);
                        // 終了処理
                        this.CloseForm();
                        break;
                    }
                case "ButtonTool_Decision":
                    {
                        // 確定処理
                        if (_inputDetails.ReturnSelectData())
                        {
                            this.SetDialogRes(DialogResult.OK);
                            this.CloseForm();
                        }
                        break;
                    }
                case "ButtonTool_Undo":
                    {
                        // 元に戻す処理
                        this.ClearDisplayHeader();
                        this.SetDisplayHeaderInfo();
                        this._searchSlipAcs.ClearStockSlipDataTable();

                        break;
                    }
                case "ButtonTool_Search":
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 DEL
                        //// 検索処理
                        //SearchSlip();
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
                        // 検索処理
                        Control errCtrl = SearchSlip();
                        
                        // エラーの場合、対象コントロールへフォーカス移動
                        if ( errCtrl != null )
                        {
                            errCtrl.Focus();
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD
                        break;
                    }
            }
        }

        /// <summary>
        /// 検索ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void Search_Button_Click(object sender, EventArgs e)
        {
            SearchSlip();
        }

        /// <summary>
        /// ステータスバーメッセージ表示イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="message">メッセージ</param>
        private void SetStatusBarMessage(object sender, string message)
        {
            // 2008.11.12 modify start [7578]
            //this.uStatusBar_Main.Panels[0].Text = message;
            this.uStatusBar_Main.Panels["StatusBarPanel_Text"].Text = message;
            // 2008.11.12 modify end [7578]
        }

        /// <summary>
        /// Enterキーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            // MAKON01320UBのグリッドでのEnterキー押下処理で、MAKON01320UAのtRetKeyControlに制御を奪われるため
            // イベントが発生しなくなる現象の回避策
            if (e.PrevCtrl == this._inputDetails.uGrid_Details)
            {
                // グリッド上でのEnterキー押下では、他コントロールにフォーカスを移さない
                e.NextCtrl = e.PrevCtrl;
                // グリッド行選択処理タイマー発動
                this._inputDetails.timer_SelectRow.Enabled = true;
            }

			//if (e.PrevCtrl == this.tEdit_PartySalesSlipNum || e.PrevCtrl == this.tEdit_SupplierSlipNo)
			if (e.PrevCtrl == this.tNedit_SupplierSlipNo_St)
			{
                e.NextCtrl = this.tEdit_GoodsNo;
            }
            else if (e.NextCtrl.Parent == this.panel_Detail)
            {
                Control control = SearchSlip();

                if ((this._inputDetails.uGrid_Details.Rows.Count > 0) &&
                   (this._inputDetails.uGrid_Details.Enabled == true))
                {
                    e.NextCtrl = this._inputDetails.uGrid_Details;
                }
                else
                {
					if (control == null)
					{
						e.NextCtrl = e.PrevCtrl;
					}
					else
					{
						e.NextCtrl = control;
					}
                }
            }
        }

        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>UpdateNote: 2015/05/06　周洋</br>
        /// <br>管理番号  : 11175161-00 仕入先入力不可の対応</br>
        /// <br>UpdateNote: 2015/06/12　イン晶晶</br>
        /// <br>管理番号  : 11175161-00 仕入先入力不可の対応</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            SetStatusBarMessage(this, "");

            // フォーカス制御 ============================================ //
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //if (
            //    //(e.PrevCtrl == this.tEdit_OrderNumber) ||
            //    (e.PrevCtrl == this.tNedit_SupplierSlipNo_St) ||
            //    (e.PrevCtrl == this.tNedit_SupplierCd) ||
            //    (e.PrevCtrl == this.uButton_SupplierGuide))
            //{
            //    if (e.Key == Keys.Down)
            //    {
            //        if (Detail_UGroupBox.Expanded == true)
            //        {
            //            e.NextCtrl = this.tNedit_GoodsMakerCd;
            //        }
            //        else
            //        {
            //            e.NextCtrl = this._inputDetails.uGrid_Details;
            //        }
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL

            if (((e.PrevCtrl.Parent.Parent == this.Standard_UGroupBox) ||
                (e.PrevCtrl.Parent.Parent == this.Detail_UGroupBox)
				//|| (e.PrevCtrl.Parent.Parent == this.Select_UGroupBox)
				) &&
                ((e.NextCtrl.Parent == this.panel_Detail) ||
                 (e.NextCtrl == this._inputDetails.uGrid_Details)))
            {
                //Control control = SearchSlip();
                if ( (this._inputDetails.uGrid_Details.Rows.Count > 0) &&
                   (this._inputDetails.uGrid_Details.Enabled == true) )
                {
                    e.NextCtrl = this._inputDetails.uGrid_Details;
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
                //else if ( this.tComboEditor_SupplierFormal.Enabled == true )
                //{
                //    e.NextCtrl = this.tComboEditor_SupplierFormal;
                //}
                //else if (this.tComboEditor_ReconcileFlag.Enabled == true)
                //{
                //    e.NextCtrl = this.tComboEditor_ReconcileFlag;
                //}
                //else
                //{
                //    //e.NextCtrl = this.tComboEditor_SupplierSlipCd;
                //    e.NextCtrl = this.tEdit_SectionCodeAllowZero;

                //    //e.NextCtrl = e.PrevCtrl;
                //    //if (control == null)
                //    //{
                //    //	e.NextCtrl = e.PrevCtrl;
                //    //}
                //    //else
                //    //{
                //    //	e.NextCtrl = control;
                //    //}
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
                else
                {
                    e.NextCtrl = e.PrevCtrl;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
            }
#if False
			else if (e.PrevCtrl == this._inputDetails.uButton_StockSearch)
            {
                switch (e.Key)
                {
                    case Keys.Up:
                        {
                            if (this.Detail_UGroupBox.Expanded == true)
                            {
                                e.NextCtrl = this.tEdit_GoodsCode;
                            }
                            else
                            {
                                e.NextCtrl = this.SetInitFocus(this);
                            }

                            break;
                        }
                    case Keys.Left:
                        {
                            e.NextCtrl = e.PrevCtrl;

                            break;
                        }
                    case Keys.Right:
                    case Keys.Return:
                    case Keys.Tab:
                        {
                            e.NextCtrl = this._inputDetails.uGrid_Details;
                            break;
                        }
                }
            }
#endif

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 DEL
            //// 入力支援 ============================================ //
            //// 仕入日
            //if ((e.PrevCtrl == this.tDateEdit_Date1Start) ||
            //    (e.PrevCtrl == this.tDateEdit_Date1End))
            //{
            //    AutoSetEndValue(this.tDateEdit_Date1Start,this.tDateEdit_Date1End);
            //}

            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.29 TOKUNAGA ADD START
            //// 入力支援 ============================================ //
            //// 入力日
            //if ((e.PrevCtrl == this.tDateEdit_InputDaySt) ||
            //    (e.PrevCtrl == this.tDateEdit_InputDayEd))
            //{
            //    AutoSetEndValue(this.tDateEdit_InputDaySt, this.tDateEdit_InputDayEd);
            //}
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.29 TOKUNAGA ADD END
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 DEL

			// 名称取得 ============================================ //
            switch (e.PrevCtrl.Name)
            {
                // 拠点
                case "tEdit_SectionCodeAllowZero":
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
                        // 拠点コードゼロ取得
                        UiSet uiset;
                        uiSetControl1.ReadUISet( out uiset, tEdit_SectionCodeAllowZero.Name );
                        string sectionCodeZero = new string( '0', uiset.Column );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD

                        bool canChangeFocus = true;
                        string code = this.tEdit_SectionCodeAllowZero.Text.Trim();
						string name = this.uLabel_SectionNm.Text.Trim();

                        if (this._paraStockSlipCache_Display.SectionCode.Trim() != code)
                        {
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
                            //if (code == "")
                            //{
                            //    this._paraStockSlipCache_Display.SectionCode = code;
                            //    name = "";
                            //}
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
                            if ( code == sectionCodeZero )
                            {
                                // 全社表示
                                this._paraStockSlipCache_Display.SectionCode = code;
                                name = ct_AllSection;
                            }
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
                            else
                            {
                                SecInfoSet secInfoSet = new SecInfoSet();
                                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                                int status = secInfoSetAcs.Read( out secInfoSet, this._enterpriseCode, code );
                                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                {
                                    name = secInfoSet.SectionGuideNm;
                                    this._paraStockSlipCache_Display.SectionCode = code;
                                }
                                else if ( status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND )
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "拠点が存在しません。",
                                        -1,
                                        MessageBoxButtons.OK );

                                    canChangeFocus = false;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "拠点の取得に失敗しました。",
                                        status,
                                        MessageBoxButtons.OK );

                                    canChangeFocus = false;
                                }
                            }
							this.tEdit_SectionCodeAllowZero.Text = this._paraStockSlipCache_Display.SectionCode;
							this.uLabel_SectionNm.Text = name;
                        }

                        // NextCtrl制御
                        if (canChangeFocus)
                        {
							if (!e.ShiftKey)
							{
								switch (e.Key)
								{
									case Keys.Return:
									case Keys.Tab:
										{
											if (this.tEdit_SectionCodeAllowZero.Text.Trim() == "")
											{
												e.NextCtrl = this.uButton_SectionGuide;
											}
											else
											{
                                                //e.NextCtrl = this.tNedit_SupplierCd;      // DEL 2009/04/09
                                                // ADD 2009/04/09 ------>>>
                                                if (this._secMngDiv == 0)
                                                {
                                                    //e.NextCtrl = this.tNedit_SupplierCd; // DEL by イン晶晶 2015/06/12 for Redmine#45801 仕入先入力不可の対応
                                                    //------------------------ ADD by イン晶晶 2015/06/12 for Redmine#45801 仕入先入力不可の対応 -------------->>>>>
                                                    if(this.tNedit_SupplierCd.Enabled == true)
                                                    {
                                                        e.NextCtrl = this.tNedit_SupplierCd;
                                                    }
                                                    else
                                                    {
                                                        e.NextCtrl = this.tNedit_PayeeCode;
                                                    }
                                                    //------------------------ ADD by イン晶晶 2015/06/12 for Redmine#45801 仕入先入力不可の対応 --------------<<<<<
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.tNedit_SubSectionCode;
                                                }
                                                // ADD 2009/04/09 ------<<<
                                            }
											break;
										}
								}
							}
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
                            tEdit_SectionCodeAllowZero.SelectAll();
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
                        }

                        break;
                    }
                // ADD 2009/04/09 ------>>>
                #region 拠点ガイド [uButton_SectionGuide]
                case "uButton_SectionGuide":
                    {
                        // NextCtrl制御
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this._secMngDiv == 0)
                                        {
                                            //e.NextCtrl = this.tNedit_SupplierCd; //DEL by イン晶晶 2015/06/12 for Redmine#45801 仕入先入力不可の対応
                                            //------------------------ ADD by イン晶晶 2015/06/12 for Redmine#45801 仕入先入力不可の対応 -------------->>>>>
                                            if (this.tNedit_SupplierCd.Enabled == false)
                                            {
                                                e.NextCtrl = this.tNedit_PayeeCode;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tNedit_SupplierCd;
                                            }
                                            //------------------------ ADD by イン晶晶 2015/06/12 for Redmine#45801 仕入先入力不可の対応 --------------<<<<<
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_SubSectionCode;
                                        }
                                        break;
                                    }
                                case Keys.Down:
                                    {
                                        if (this._secMngDiv == 0)
                                        {
                                            //e.NextCtrl = this.tNedit_SupplierCd; //DEL by イン晶晶 2015/06/12 for Redmine#45801 仕入先入力不可の対応
                                            //------------------------ ADD by イン晶晶 2015/06/12 for Redmine#45801 仕入先入力不可の対応 -------------->>>>>
                                            if (this.tNedit_SupplierCd.Enabled == false)
                                            {
                                                e.NextCtrl = this.tNedit_PayeeCode;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tNedit_SupplierCd;
                                            }
                                            //------------------------ ADD by イン晶晶 2015/06/12 for Redmine#45801 仕入先入力不可の対応 --------------<<<<<
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.uButton_SubSectionGuide;
                                        }
                                        break;
                                    }
                                case Keys.Up:
                                    {
                                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion 拠点ガイド [uButton_SectionGuide]

                #region 部門 [tNedit_SubSectionCode]
                case "tNedit_SubSectionCode":
                    {
                        if (this.tNedit_SubSectionCode.GetInt() == 0)
                        {
                            this.uLabel_SubSectionName.Text = "";
                        }
                        else
                        {
                            int subSectionCode = this.tNedit_SubSectionCode.GetInt();
                            this.uLabel_SubSectionName.Text = this._searchSlipAcs.GetSubSectionName(subSectionCode);
                        }

                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.uLabel_SubSectionName.Text != "")
                                        {
                                            //e.NextCtrl = this.tNedit_SupplierCd; // DEL by イン晶晶 2015/06/12 for Redmine#45801 仕入先入力不可の対応
                                            //------------------------ ADD by イン晶晶 2015/06/12 for Redmine#45801 仕入先入力不可の対応 -------------->>>>>
                                            if (this.tNedit_SupplierCd.Enabled == true)
                                            {
                                                e.NextCtrl = this.tNedit_SupplierCd;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tNedit_PayeeCode;
                                            }
                                            //------------------------ ADD by イン晶晶 2015/06/12 for Redmine#45801 仕入先入力不可の対応 --------------<<<<<
                                        }
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
                            {
                                if (this.uLabel_SectionNm.Text != "")
                                {
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                }
                                else
                                {
                                    e.NextCtrl = uButton_SectionGuide;
                                }
                            }
                        }

                        break;
                    }
                #endregion 部門 [tNedit_SubSectionCode]

                #region 部門ガイド [uButton_SubSectionGuide]
                case "uButton_SubSectionGuide":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        //------------------------ DEL by 周洋 2015/05/06 for Redmine#45801 仕入先入力不可の対応 -------------->>>>>
                                        //e.NextCtrl = this.tNedit_SupplierCd;
                                        //------------------------ DEL by 周洋 2015/05/06 for Redmine#45801 仕入先入力不可の対応 --------------<<<<<

                                        //------------------------ ADD by 周洋 2015/05/06 for Redmine#45801 仕入先入力不可の対応 -------------->>>>>
                                        if (this.tNedit_SupplierCd.Enabled == false)
                                        {
                                            e.NextCtrl = this.tNedit_PayeeCode;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_SupplierCd;
                                        }
                                        //------------------------ ADD by 周洋 2015/05/06 for Redmine#45801 仕入先入力不可の対応 --------------<<<<<
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion 部門ガイド [uButton_SubSectionGuide]
                // ADD 2009/04/09 ------<<<                
				// 仕入先
                case "tNedit_SupplierCd":
					{
						bool canChangeFocus = true;
						int code = this.tNedit_SupplierCd.GetInt();
						string name = this.uLabel_SupplierSnm.Text.Trim();

						//if (this._paraStockSlipCache_Display.CustomerCode != code)
                        if (this._paraStockSlipCache_Display.SupplierCd != code)
						{
							if (code == 0)
							{
								//this._paraStockSlipCache_Display.CustomerCode = code;
                                this._paraStockSlipCache_Display.SupplierCd = code;
								name = "";
							}
							else
							{
                                Supplier supplier;
                                int status = this._supplierAcs.Read(out supplier, this._enterpriseCode, code);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    this._paraStockSlipCache_Display.SupplierCd = code;
                                    name = supplier.SupplierSnm;// Nm1;
                                }
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "仕入先が存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "仕入先の取得に失敗しました。",
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }

							}
                            this.tNedit_SupplierCd.SetInt(this._paraStockSlipCache_Display.SupplierCd);
							this.uLabel_SupplierSnm.Text = name;
						}

						// NextCtrl制御
						if (canChangeFocus)
						{
							if (!e.ShiftKey)
							{
								switch (e.Key)
								{
									case Keys.Return:
									case Keys.Tab:
										{
											if (this.tNedit_SupplierCd.GetInt() == 0)
											{
												e.NextCtrl = this.uButton_SupplierGuide;
											}
											else
											{
                                                e.NextCtrl = this.tNedit_PayeeCode;
											}
											break;
										}
								}
							}
                            // ADD 2009/04/09 ------>>>
                            else
                            {
                                if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
                                {
                                    if (this._secMngDiv == 0)
                                    {
                                        if (this.uLabel_SectionNm.Text != "")
                                        {
                                            e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                        }
                                        else
                                        {
                                            e.NextCtrl = uButton_SectionGuide;
                                        }
                                    }
                                    else
                                    {
                                        if (this.uLabel_SubSectionName.Text != "")
                                        {
                                            e.NextCtrl = this.tNedit_SubSectionCode;
                                        }
                                        else
                                        {
                                            e.NextCtrl = uButton_SubSectionGuide;
                                        }
                                    }
                                }
                            }
                            // ADD 2009/04/09 ------<<<
                        }
						else
						{
							e.NextCtrl = e.PrevCtrl;
						}

						break;
					}
				// 支払先
				case "tNedit_PayeeCode":
					{
						bool canChangeFocus = true;
						int code = this.tNedit_PayeeCode.GetInt();
						string name = uLabel_PayeeSnm.Text.Trim();

						if (this._paraStockSlipCache_Display.PayeeCode != code)
						{
							if (code == 0)
							{
								this._paraStockSlipCache_Display.PayeeCode = code;
								name = "";
							}
							else
							{
                                Supplier supplier;
                                int status = this._supplierAcs.Read(out supplier, this._enterpriseCode, code);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    this._paraStockSlipCache_Display.PayeeCode = code;
                                    name = supplier.SupplierSnm;// Nm1;
                                }
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "仕入先が存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "仕入先の取得に失敗しました。",
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
							}
							this.tNedit_PayeeCode.SetInt(this._paraStockSlipCache_Display.PayeeCode);
							this.uLabel_PayeeSnm.Text = name;
						}

						// NextCtrl制御
						if (canChangeFocus)
						{
							if (!e.ShiftKey)
							{
								switch (e.Key)
								{
									case Keys.Return:
									case Keys.Tab:
										{
											if (this.tNedit_PayeeCode.GetInt() == 0)
											{
												e.NextCtrl = this.uButton_PayeeGuide;
											}
											else
											{
                                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
                                                //e.NextCtrl = this.tEdit_StockAgentCode;
                                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
                                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
                                                //e.NextCtrl = this.tComboEditor_SupplierFormal; // DEL by イン晶晶 2015/06/12 for Redmine#45801 仕入先入力不可の対応
                                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
                                                //------------------------ ADD by イン晶晶 2015/06/12 for Redmine#45801 仕入先入力不可の対応 -------------->>>>>
                                                if (this.tComboEditor_SupplierFormal.Enabled == false)
                                                {
                                                    e.NextCtrl = this.tComboEditor_SupplierSlipCd;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.tComboEditor_SupplierFormal;
                                                }
                                                //------------------------ ADD by イン晶晶 2015/06/12 for Redmine#45801 仕入先入力不可の対応 --------------<<<<<
											}
											break;
										}
								}
							}
                            //------------------------ ADD by 周洋 2015/05/06 for Redmine#45801 仕入先入力不可の対応 -------------->>>>>
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (this.tNedit_SupplierCd.Enabled == false)
                                            {
                                                //e.NextCtrl = this.uButton_SubSectionGuide; //DEL by イン晶晶 2015/06/12 for Redmine#45801 仕入先入力不可の対応
                                                //------------------------ ADD by イン晶晶 2015/06/12 for Redmine#45801 仕入先入力不可の対応 -------------->>>>>
                                                if (this.tNedit_SubSectionCode.Visible == false)
                                                {
                                                    e.NextCtrl = this.uButton_SectionGuide;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.uButton_SubSectionGuide;
                                                }
                                                //------------------------ ADD by イン晶晶 2015/06/12 for Redmine#45801 仕入先入力不可の対応 --------------<<<<<
                                            }
                                            break;
                                        }
                                }
                            }
                            //------------------------ ADD by 周洋 2015/05/06 for Redmine#45801 仕入先入力不可の対応 --------------<<<<<
						}
						else
						{
							e.NextCtrl = e.PrevCtrl;
						}

						break;
					}

				// 仕入担当者
				case "tEdit_StockAgentCode":
					{
						bool canChangeFocus = true;
						string code = this.tEdit_StockAgentCode.Text.Trim();
						string name = this.uLabel_StockAgentName.Text.Trim();

						if (this._paraStockSlipCache_Display.StockAgentCode.Trim() != code)
						{
							if (code == "")
							{
								this._paraStockSlipCache_Display.StockAgentCode = code;
								name = "";
							}
							else
							{
								string nameTmp = this._searchSlipAcs.GetName_FromEmployee(code);

								if (nameTmp.Trim() == "")
								{
									TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_INFO,
										this.Name,
										"仕入担当が存在しません。",
										-1,
										MessageBoxButtons.OK);

									canChangeFocus = false;
								}
								else
								{
									this._paraStockSlipCache_Display.StockAgentCode = code;
									name = nameTmp;
								}
							}
							// 従業員コード・名称セット
							this.tEdit_StockAgentCode.Text = this._paraStockSlipCache_Display.StockAgentCode;
							this.uLabel_StockAgentName.Text = name;
						}

						// NextCtrl制御
						if (canChangeFocus)
						{
							if (!e.ShiftKey)
							{
								switch (e.Key)
								{
									case Keys.Return:
									case Keys.Tab:
										{
											if (this.tEdit_StockAgentCode.Text.Trim() == "")
											{
												e.NextCtrl = this.uButton_EmployeeGuide;
											}
											else
											{
												e.NextCtrl = this.tEdit_WarehouseCode;
											}
											break;
										}
								}
							}
						}
						else
						{
							e.NextCtrl = e.PrevCtrl;
						}

						break;
					}
					// 倉庫
					case "tEdit_WarehouseCode":
					{
						bool canChangeFocus = true;
						string code = this.tEdit_WarehouseCode.Text.Trim();
						string name = this.uLabel_WarehouseName.Text.Trim();

						if (this._paraStockSlipCache_Display.WarehouseCode.Trim() != code)
						{
							if (code == "")
							{
								this._paraStockSlipCache_Display.WarehouseCode = code;
								name = "";
							}
							else
							{
								if (this.tEdit_SectionCodeAllowZero.Text == "")
								{
									TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_EXCLAMATION,
										this.Name,
										"拠点が選択されていません。",
										0,
										MessageBoxButtons.OK);

									canChangeFocus = false;
								}
								else
								{
									Warehouse warehouse;
									int status = this._warehouseAcs.Read(out warehouse, this._enterpriseCode, this.tEdit_SectionCodeAllowZero.Text, code);

									if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
									{
										TMsgDisp.Show(
											this,
											emErrorLevel.ERR_LEVEL_INFO,
											this.Name,
											"倉庫が存在しません。",
											-1,
											MessageBoxButtons.OK);

										canChangeFocus = false;
									}
									else
									{
										this._paraStockSlipCache_Display.WarehouseCode = code;
										name = warehouse.WarehouseName;
									}
								}
							}
							// 従業員コード・名称セット
							this.tEdit_WarehouseCode.Text = this._paraStockSlipCache_Display.WarehouseCode;
							this.uLabel_WarehouseName.Text = name;
						}

						// NextCtrl制御
						if (canChangeFocus)
						{
							if (!e.ShiftKey)
							{
								switch (e.Key)
								{
									case Keys.Return:
									case Keys.Tab:
										{
											if (this.tEdit_WarehouseCode.Text.Trim() == "")
											{
												e.NextCtrl = this.uButton_WarehouseGuide;
											}
											else
											{
                                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
                                                //e.NextCtrl = this.tNedit_SupplierSlipNo_St;
                                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
                                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
                                                if ( Detail_UGroupBox.Expanded )
                                                {
                                                    e.NextCtrl = tNedit_GoodsMakerCd;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = panel_Detail;
                                                }
                                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
											}

											break;
										}
								}
							}
						}
						else
						{
							e.NextCtrl = e.PrevCtrl;
						}

						break;
					}
				// メーカー
				case "tNedit_GoodsMakerCd":
					{
						bool canChangeFocus = true;
						int code = this.tNedit_GoodsMakerCd.GetInt();
						string name = uLabel_MakerName.Text.Trim();

						if (this._paraStockSlipCache_Display.GoodsMakerCd != code)
						{
							if (code == 0)
							{
								this._paraStockSlipCache_Display.GoodsMakerCd = code;
								name = "";
							}
							else
							{
								string nameTmp = this._searchSlipAcs.GetName_FromGoodsMaker(code);

								if (nameTmp.Trim() == "")
								{
									TMsgDisp.Show(
										this,
										emErrorLevel.ERR_LEVEL_INFO,
										this.Name,
										"メーカーが存在しません。",
										-1,
										MessageBoxButtons.OK);

									canChangeFocus = false;
								}
								else
								{
									this._paraStockSlipCache_Display.GoodsMakerCd = code;
									name = nameTmp;

									// 商品コード・名称のクリア
									this._paraStockSlipCache_Display.GoodsNo = "";
									this.tEdit_GoodsNo.Text = this._paraStockSlipCache_Display.GoodsNo;
									// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
                                    //this.uLabel_GoodsName.Text = "";
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
								}
							}
							// メーカーコード・名称セット
							this.tNedit_GoodsMakerCd.SetInt(this._paraStockSlipCache_Display.GoodsMakerCd);
							this.uLabel_MakerName.Text = name;
						}

						// NextCtrl制御
						if (canChangeFocus)
						{
							if (!e.ShiftKey)
							{
								switch (e.Key)
								{
									case Keys.Return:
									case Keys.Tab:
										{
											if (this.tNedit_GoodsMakerCd.GetInt() == 0)
											{
												e.NextCtrl = this.uButton_GoodsMakerGuide;
											}
											else
											{
												e.NextCtrl = this.tEdit_GoodsNo;
											}
											break;
										}
								}
							}
						}
						else
						{
							e.NextCtrl = e.PrevCtrl;
						}

						break;
					}
                // 商品
                case "tEdit_GoodsNo":
                    {
                        bool canChangeFocus = true;
                        string code = this.tEdit_GoodsNo.Text.Trim();
						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
                        //string name = this.uLabel_GoodsName.Text.Trim();
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
                        //int goodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
                        //string makerName = this.uLabel_MakerName.Text;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL

                        if (this._paraStockSlipCache_Display.GoodsNo.Trim() != code)
                        {
                            if (code == "")
                            {
                                this._paraStockSlipCache_Display.GoodsNo = code;
								// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
                                //name = "";
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
                            }
                            else
                            {
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
                                //string nameTmp = "";
                                //int existFlg = this._searchSlipAcs.CheckGoodsExist(this, ref code, ref nameTmp, ref goodsMakerCd, ref makerName);

                                //if (existFlg == 4)
                                //{
                                //    TMsgDisp.Show(
                                //        this,
                                //        emErrorLevel.ERR_LEVEL_INFO,
                                //        this.Name,
                                //        "商品が存在しません。",
                                //        -1,
                                //        MessageBoxButtons.OK);

                                //    canChangeFocus = false;
                                //}
                                //else if (existFlg == 0)
                                //{
                                //    this._paraStockSlipCache_Display.GoodsNo = code;
                                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
                                //    //name = nameTmp;
                                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL

                                //    this._paraStockSlipCache_Display.GoodsMakerCd = goodsMakerCd;
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
                                this._paraStockSlipCache_Display.GoodsNo = code;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
                            }
                            // 商品コード・名称セット
							this.tEdit_GoodsNo.Text = this._paraStockSlipCache_Display.GoodsNo;
							// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
                            //this.uLabel_GoodsName.Text = name;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
                            //// メーカーコード・名称セット
                            //this.tNedit_GoodsMakerCd.SetInt(this._paraStockSlipCache_Display.GoodsMakerCd);
                            //this.uLabel_MakerName.Text = makerName;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
                        }

                        // NextCtrl制御
                        if (canChangeFocus)
                        {
							if (!e.ShiftKey)
							{
								switch (e.Key)
								{
									case Keys.Return:
									case Keys.Tab:
										{
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
                                            //if (this.tEdit_GoodsNo.Text.Trim() == "")
                                            //{
                                            //    e.NextCtrl = this.uButton_GoodsGuide;
                                            //}
                                            //else
                                            //{
                                            //    e.NextCtrl = this.tEdit_GoodsName;
                                            //}
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
                                            e.NextCtrl = this.tEdit_GoodsName;
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
                                            break;
                                        }
								}
							}
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            // 特殊フォーカス対応
            _irregularFocusControl.ReflectIrregularNextControl( e );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD

            // RetKeyControl用処理
            if ((e.Key == Keys.Return) ||
                (e.Key == Keys.Tab))
            {
                // MAKON01320UBのグリッドでのEnterキー押下処理で、MAKON01320UAのtRetKeyControlに制御を奪われるため
                // イベントが発生しなくなる現象の回避策
                if (e.PrevCtrl == this._inputDetails.uGrid_Details)
                {
                    // グリッド上でのEnterキー押下では、他コントロールにフォーカスを移さない
                    e.NextCtrl = e.PrevCtrl;
                    // グリッド行選択処理タイマー発動
                    this._inputDetails.timer_SelectRow.Enabled = true;
                }

				//if (e.PrevCtrl == this.tEdit_PartySalesSlipNum || e.PrevCtrl == this.tEdit_SupplierSlipNo)
				//if (e.PrevCtrl == this.tEdit_SupplierSlipNo)
                //{
                //    e.NextCtrl = this.tEdit_GoodsNo;
                //}
                if (e.NextCtrl.Parent == this.panel_Detail)
                {
                    //Control control = SearchSlip();
                    
					if ((this._inputDetails.uGrid_Details.Rows.Count > 0) &&
                       (this._inputDetails.uGrid_Details.Enabled == true))
                    {
                        e.NextCtrl = this._inputDetails.uGrid_Details;
                    }
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
                    //else if (this.tComboEditor_SupplierFormal.Enabled == true)
                    //{
                    //    e.NextCtrl = this.tComboEditor_SupplierFormal;
                    //}
                    //else if (this.tComboEditor_ReconcileFlag.Enabled == true)
                    //{
                    //    e.NextCtrl = this.tComboEditor_ReconcileFlag;
                    //}
                    //else
                    //{
                    //    e.NextCtrl = this.tComboEditor_SupplierSlipCd;
                    //    //if (control == null)
                    //    //{
                    //    //	e.NextCtrl = e.PrevCtrl;
                    //    //}
                    //    //else
                    //    //{
                    //    //	e.NextCtrl = control;
                    //    //}
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
                }
            }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
        ///// <summary>
        ///// 初期フォーカス設定タイマー起動イベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータクラス</param>
        //private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
        //{
        //    this.timer_InitialSetFocus.Enabled = false;

        //    this.SetInitFocus(this);
        //    //this._inputDetails.uGrid_Details.Enabled = false;
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL

        /// <summary>
        /// フォーム終了イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void MAKON01320UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = _dialogRes;
        }

        /// <summary>
        /// 拠点ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>UpdateNote: 2015/06/12　イン晶晶</br>
        /// <br>管理番号  : 11175161-00 仕入先入力不可の対応</br>
        /// </remarks>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            SecInfoSet sectionInfo;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out sectionInfo);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            int status = this._secInfoSetAcs.ExecuteGuid( this._enterpriseCode, true, out sectionInfo );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                this.tEdit_SectionCodeAllowZero.Text = sectionInfo.SectionCode.TrimEnd();
                this.uLabel_SectionNm.Text = sectionInfo.SectionGuideNm.TrimEnd();
                this._paraStockSlipCache_Display.SectionCode = sectionInfo.SectionCode.TrimEnd();
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
                // 次フォーカス
                //tNedit_SupplierCd.Focus();    // DEL 2009/04/09
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD

                // ADD 2009/04/09 ------>>>
                if (this._secMngDiv == 0)
                {
                    //this.tNedit_SupplierCd.Focus();//DEL by イン晶晶 2015/06/12 for Redmine#45801 仕入先入力不可の対応
                    //------------------------ ADD by イン晶晶 2015/06/12 for Redmine#45801 仕入先入力不可の対応 -------------->>>>>
                    if (this.tNedit_SupplierCd.Enabled == true)
                    {
                        this.tNedit_SupplierCd.Focus();
                    }
                    else
                    {
                        this.tNedit_PayeeCode.Focus();
                    }
                    //------------------------ ADD by イン晶晶 2015/06/12 for Redmine#45801 仕入先入力不可の対応 --------------<<<<<
                }
                else
                {
                    this.tNedit_SubSectionCode.Focus();
                }
                // ADD 2009/04/09 ------<<<
            }
            else
            {
                // 2008.11.11 del start [7586]
                //this.tEdit_SectionCodeAllowZero.Clear();
                //this.uLabel_SectionNm.Text = "";
                // 2008.11.11 del end [7586]
            }
        }

        // ADD 2009/04/09 ------>>>
        /// <summary>
        /// 部門ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>UpdateNote: 2015/06/12　イン晶晶</br>
        /// <br>管理番号  : 11175161-00 仕入先入力不可の対応</br>
        /// </remarks>
        private void uButton_SubSectionGuide_Click(object sender, EventArgs e)
        {
            SubSection subSection;

            int status = this._searchSlipAcs.ExecuteSubSectionGuide(out subSection);
            if (status == 0)
            {
                this.tNedit_SubSectionCode.SetInt(subSection.SubSectionCode);
                this.uLabel_SubSectionName.Text = subSection.SubSectionName.Trim();

                //this.tNedit_SupplierCd.Focus(); //DEL by イン晶晶 2015/06/12 for Redmine#45801 仕入先入力不可の対応
                //------------------------ ADD by イン晶晶 2015/06/12 for Redmine#45801 仕入先入力不可の対応 -------------->>>>>
                if (this.tNedit_SupplierCd.Enabled == true)
                {
                    this.tNedit_SupplierCd.Focus();
                }
                else
                {
                    this.tNedit_PayeeCode.Focus();
                }
                //------------------------ ADD by イン晶晶 2015/06/12 for Redmine#45801 仕入先入力不可の対応 --------------<<<<<
            }
        }
        // ADD 2009/04/09 ------<<<
                
        /// <summary>
        /// 従業員ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_EmployeeGuide_Click(object sender, EventArgs e)
        {
            EmployeeAcs employeeAcs = new EmployeeAcs();
            Employee employee;
            int status = employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tEdit_StockAgentCode.Text = employee.EmployeeCode.Trim();
                uLabel_StockAgentName.Text = employee.Name.Trim();

                // パラメータ(仕入担当者コード)に保存
                this._paraStockSlipCache_Display.StockAgentCode = employee.EmployeeCode.Trim();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
                // 次フォーカス
                tEdit_WarehouseCode.Focus();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
            }
        }

        /// <summary>
        /// 仕入先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_SupplierGuide_Click(object sender, EventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.29 TOKUNAGA MODIFY START
            // 得意先→仕入先に変更

            Supplier supplierInfo;
            // notice : 仕入先ガイドの引数「拠点コード」は不要
            int status = this._supplierAcs.ExecuteGuid(out supplierInfo, this._enterpriseCode, string.Empty);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // データをセット
                this.tNedit_SupplierCd.SetInt(supplierInfo.SupplierCd);
                this.uLabel_SupplierSnm.Text = supplierInfo.SupplierSnm.TrimEnd();

                // データにセット
                this._paraStockSlipCache_Display.SupplierCd = supplierInfo.SupplierCd;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
                // 次フォーカス
                tNedit_PayeeCode.Focus();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.29 TOKUNAGA MODIFY END
        }

		/// <summary>
		/// 支払先ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>UpdateNote: 2015/06/12　イン晶晶</br>
        /// <br>管理番号  : 11175161-00 仕入先入力不可の対応</br>
        /// </remarks>
		private void uButton_PayeeGuide_Click(object sender, EventArgs e)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.29 TOKUNAGA MODIFY START
            //// 請求先ガイド表示(支払先)
            //PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_RECEIVER, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            //customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.PayeeSearchForm_CustomerSelect);
            //customerSearchForm.ShowDialog( this );
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.29 TOKUNAGA MODIFY END
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            Supplier supplierInfo;
            int status = this._supplierAcs.ExecuteGuid( out supplierInfo, this._enterpriseCode, string.Empty );
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                // データをセット
                this.tNedit_PayeeCode.SetInt( supplierInfo.SupplierCd );
                this.uLabel_PayeeSnm.Text = supplierInfo.SupplierSnm.TrimEnd();
                this._paraStockSlipCache_Display.PayeeCode = supplierInfo.SupplierCd;
                // 次フォーカス
                //tComboEditor_SupplierFormal.Focus(); //DEL by イン晶晶 2015/06/12 for Redmine#45801 仕入先入力不可の対応
                //------------------------ ADD by イン晶晶 2015/06/12 for Redmine#45801 仕入先入力不可の対応 -------------->>>>>
                if (this.tComboEditor_SupplierFormal.Enabled == false)
                {
                    tComboEditor_SupplierSlipCd.Focus();
                }
                else
                {
                    tComboEditor_SupplierFormal.Focus();
                }
                //------------------------ ADD by イン晶晶 2015/06/12 for Redmine#45801 仕入先入力不可の対応 --------------<<<<<
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
        ///// <summary>
        ///// 支払先選択時発生イベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        //private void PayeeSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.29 TOKUNAGA MODIFY START
        //    if (customerSearchRet == null) return;

        //    CustomerInfo customerInfo;
        //    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

        //    int status = customerInfoAcs.ReadDBData(this._enterpriseCode, customerSearchRet.CustomerCode, out customerInfo);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        if (((customerInfo.IsCustomer == true) || (customerInfo.IsReceiver == true)))
        //        {
        //        }
        //        else
        //        {
        //            TMsgDisp.Show(
        //                this,
        //                emErrorLevel.ERR_LEVEL_INFO,
        //                this.Name,
        //                "仕入先は入力できません。",
        //                -1,
        //                MessageBoxButtons.OK);
        //            return;
        //        }
        //    }
        //    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
        //    {
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //            this.Name,
        //            "選択した支払先は既に削除されています。",
        //            status,
        //            MessageBoxButtons.OK);

        //        return;
        //    }
        //    this.tNedit_PayeeCode.SetInt(customerSearchRet.CustomerCode);
        //    this.uLabel_PayeeSnm.Text = customerSearchRet.Name;
        //    this._paraStockSlipCache_Display.PayeeCode = customerSearchRet.CustomerCode;
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.29 TOKUNAGA MODIFY END
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL

		/// <summary>
		/// メーカーガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_GoodsMakerGuide_Click(object sender, EventArgs e)
		{
			MakerAcs makerAcs = new MakerAcs();
			MakerUMnt makerUMnt;
			int status = makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
                //tNedit_GoodsMakerCd.Text = makerUMnt.GoodsMakerCd.ToString();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
                tNedit_GoodsMakerCd.SetInt( makerUMnt.GoodsMakerCd );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
				uLabel_MakerName.Text = makerUMnt.MakerName.Trim();
				this._paraStockSlipCache_Display.GoodsMakerCd = makerUMnt.GoodsMakerCd;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
                // 次フォーカス
                tEdit_GoodsNo.Focus();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
			}
		}

        /// <summary>
        /// 倉庫ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_WarehouseGuide_Click(object sender, EventArgs e)
        {
			string selectedSectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim();

			if (selectedSectionCode == "")
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"拠点が選択されていません。",
					0,
					MessageBoxButtons.OK);

				return;
			}
			Warehouse warehouse;

			int status = this._warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode, selectedSectionCode);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				this.tEdit_WarehouseCode.Text = warehouse.WarehouseCode.Trim();
				this.uLabel_WarehouseName.Text = warehouse.WarehouseName;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.29 TOKUNAGA ADD START
                this._paraStockSlipCache_Display.WarehouseCode = warehouse.WarehouseCode.Trim();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.29 TOKUNAGA ADD END

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
                // 次フォーカス
                if ( Detail_UGroupBox.Expanded )
                {
                    tNedit_GoodsMakerCd.Focus();
                }
                else
                {
                    panel_Detail.Focus();
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
			}
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
        ///// <summary>
        ///// 商品ガイドボタンクリックイベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="message">メッセージ</param>
        //private void uButton_GoodsGuide_Click(object sender, EventArgs e)
        //{
        //    MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();
        //    GoodsUnitData goodsUnitData;
        //    GoodsCndtn condtn = new GoodsCndtn();

        //    condtn.EnterpriseCode = this._enterpriseCode;
        //    condtn.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
        //    condtn.MakerName = this.uLabel_MakerName.Text;

        //    //DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, this._enterpriseCode, out goodsUnitData);
        //    DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, false, condtn, out goodsUnitData);

        //    if ((dialogResult == DialogResult.OK) && (goodsUnitData != null))
        //    {
        //        // メーカーコード設定処理
        //        this._paraStockSlipCache_Display.GoodsMakerCd = goodsUnitData.GoodsMakerCd;
        //        this.tNedit_GoodsMakerCd.SetInt(this._paraStockSlipCache_Display.GoodsMakerCd);
        //        this.uLabel_MakerName.Text = goodsUnitData.MakerName;

        //        // 商品コード設定処理
        //        this._paraStockSlipCache_Display.GoodsNo = goodsUnitData.GoodsNo;
        //        this.tEdit_GoodsNo.Text = this._paraStockSlipCache_Display.GoodsNo;
        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
        //        //this.uLabel_GoodsName.Text = goodsUnitData.GoodsName;
        //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
        //    }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL

        ///// <summary>
        ///// 得意先選択時発生イベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        //private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    CustomerInfo customerInfo;
        //    CustSuppli custSuppli;
        //    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

        //    int status = customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo, out custSuppli);
        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        if (custSuppli == null)
        //        {
        //            TMsgDisp.Show(
        //                this,
        //                emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //                this.Name,
        //                "選択した仕入先は仕入先情報入力が行われていない為、使用出来ません。",
        //                status,
        //                MessageBoxButtons.OK);

        //            return;
        //        }
        //    }
        //    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
        //    {
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //            this.Name,
        //            "選択した仕入先は既に削除されています。",
        //            status,
        //            MessageBoxButtons.OK);

        //        return;
        //    }
        //    this.tNedit_SupplierCd.SetInt(customerSearchRet.CustomerCode);
        //    this.uLabel_SupplierSnm.Text = customerSearchRet.Name;
        //    this._paraStockSlipCache_Display.CustomerCode = customerSearchRet.CustomerCode;
        //}



#if False
        /// <summary>
        /// 仕入形式選択地変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="message">メッセージ</param>
        private void tComboEditor_SupplierFormal_SelectionChanged(object sender, EventArgs e)
        {
            switch (this.tComboEditor_SupplierFormal.SelectedIndex)
            {
                case 0:  // 仕入
				case 2:  // 入荷
					{
#if False
						// 計上日の入力を有効にする
						this.tDateEdit_Date2Start.Enabled = true;
                        this.tDateEdit_Date2End.Enabled = true;
						this.tDateEdit_Date2Start.SetDateTime(DateTime.Today.AddMonths(-1));
						this.tDateEdit_Date2End.SetDateTime(DateTime.Today);
#endif
						break;
                    }
                case 1:  // 受託
                    {
                        // 計上日の入力を不可にする
                        if ((this.tDateEdit_Date1Start.LongDate == 0) &&
                           (this.tDateEdit_Date1End.LongDate == 0))
                        {
							this.tDateEdit_Date1Start.SetDateTime(DateTime.Today.AddMonths(-1));
							this.tDateEdit_Date1End.SetDateTime(DateTime.Today);
                        }
#if False
                        this.tDateEdit_Date2Start.Clear();
                        this.tDateEdit_Date2End.Clear();
                        this.tDateEdit_Date2Start.Enabled = false;
                        this.tDateEdit_Date2End.Enabled = false;
#endif
                        break;
                    }
            }
        }
#endif


		# endregion

		//private void ultraExpandableGroupBoxPanel1_Paint(object sender, PaintEventArgs e)
		//{

		//}

		//private void tComboEditor2_ValueChanged(object sender, EventArgs e)
		//{

		//}

		//private void tNedit_PayeeCode_ValueChanged(object sender, EventArgs e)
		//{

		//}

        /// <summary>
        /// 伝票区分コンボボックスValueChangedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void tComboEditor_SupplierFormal_ValueChanged(object sender, EventArgs e)
		{

			//伝票区分を設定
			int code = Convert.ToInt32(this.tComboEditor_SupplierFormal.Value);
            //this.SetSupplierSlipCdComboEditor(ref tComboEditor_SupplierSlipCd, code); // DEL 2009/01/23

			//0:仕入
			//if (tComboEditor_SupplierFormal.SelectedIndex == 0)
            // 2008.11.11 modify start [7587]
            if (code == 0)
			{
				tComboEditor_ReconcileFlag.SelectedIndex = 0;
				tComboEditor_ReconcileFlag.Enabled = false;
				uLabel_Date1Title.Text = "仕入日";
			}
			//1:入荷
            else if (code == 1)
            {
                tComboEditor_ReconcileFlag.Enabled = true;
                tComboEditor_ReconcileFlag.SelectedIndex = 0;
                uLabel_Date1Title.Text = "入荷日";
            }
            else
            {
                tComboEditor_ReconcileFlag.Enabled = true;
                tComboEditor_ReconcileFlag.SelectedIndex = 0;
                uLabel_Date1Title.Text = "日付";
            }
            // 2008.11.11 modify end [7587]



		}

        // --- DEL 2009/01/23 -------------------------------->>>>>
        ///// <summary>
        ///// 伝票区分コンボエディタリスト設定処理
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="salesFormalCode"></param>
        //private void SetSupplierSlipCdComboEditor(ref TComboEditor sender, int salesFormalCode)
        //{

        //    Infragistics.Win.ValueList valueList = new Infragistics.Win.ValueList();
        //    // 2008.11.20 add start [7948]
        //    Infragistics.Win.ValueListItem secInfoItemM1 = new Infragistics.Win.ValueListItem();
        //    // 2008.11.20 add end [7948]
        //    Infragistics.Win.ValueListItem secInfoItem0 = new Infragistics.Win.ValueListItem();
        //    Infragistics.Win.ValueListItem secInfoItem1 = new Infragistics.Win.ValueListItem();
        //    Infragistics.Win.ValueListItem secInfoItem100 = new Infragistics.Win.ValueListItem();
        //    Infragistics.Win.ValueListItem secInfoItem101 = new Infragistics.Win.ValueListItem();

        //    switch (salesFormalCode)
        //    {
        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.30 TOKUNAGA MODIFY START
        //        //0:仕入,1:入荷,-1:全て
        //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.30 TOKUNAGA MODIFY END
        //        case 0:
        //            // 2008.11.20 add start [7948]
        //            //掛売上
        //            secInfoItemM1.DataValue = -1;
        //            secInfoItemM1.DisplayText = "全て";
        //            valueList.ValueListItems.Add(secInfoItemM1);
        //            // 2008.11.20 add end [7948]
        //            //掛売上
        //            secInfoItem0.DataValue = 0;
        //            secInfoItem0.DisplayText = "掛仕入";
        //            valueList.ValueListItems.Add(secInfoItem0);
        //            //掛返品
        //            secInfoItem1.DataValue = 1;
        //            secInfoItem1.DisplayText = "掛返品";
        //            valueList.ValueListItems.Add(secInfoItem1);
        //            //現金売上
        //            secInfoItem100.DataValue = 100;
        //            secInfoItem100.DisplayText = "現金仕入";
        //            valueList.ValueListItems.Add(secInfoItem100);
        //            //現金返品
        //            secInfoItem101.DataValue = 101;
        //            secInfoItem101.DisplayText = "現金返品";
        //            valueList.ValueListItems.Add(secInfoItem101);
        //            break;
        //        case 1:
        //            // 2008.11.20 add start [7948]
        //            //掛売上
        //            secInfoItemM1.DataValue = -1;
        //            secInfoItemM1.DisplayText = "全て";
        //            valueList.ValueListItems.Add(secInfoItemM1);
        //            // 2008.11.20 add end [7948]
        //            //掛売上
        //            secInfoItem0.DataValue = 0;
        //            secInfoItem0.DisplayText = "掛仕入";
        //            valueList.ValueListItems.Add(secInfoItem0);
        //            //掛返品
        //            secInfoItem1.DataValue = 1;
        //            secInfoItem1.DisplayText = "掛返品";
        //            valueList.ValueListItems.Add(secInfoItem1);
        //            break;
        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.30 TOKUNAGA ADD START
        //        case -1:
        //            // 2008.11.20 add start [7948]
        //            //掛売上
        //            secInfoItemM1.DataValue = -1;
        //            secInfoItemM1.DisplayText = "全て";
        //            valueList.ValueListItems.Add(secInfoItemM1);
        //            // 2008.11.20 add end [7948]
        //            //掛売上
        //            secInfoItem0.DataValue = 0;
        //            secInfoItem0.DisplayText = "掛仕入";
        //            valueList.ValueListItems.Add(secInfoItem0);
        //            //掛返品
        //            secInfoItem1.DataValue = 1;
        //            secInfoItem1.DisplayText = "掛返品";
        //            valueList.ValueListItems.Add(secInfoItem1);
        //            //現金売上
        //            secInfoItem100.DataValue = 100;
        //            secInfoItem100.DisplayText = "現金仕入";
        //            valueList.ValueListItems.Add(secInfoItem100);
        //            //現金返品
        //            secInfoItem101.DataValue = 101;
        //            secInfoItem101.DisplayText = "現金返品";
        //            valueList.ValueListItems.Add(secInfoItem101);
        //            break;
        //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.30 TOKUNAGA ADD END
        //    }

        //    if (valueList != null)
        //    {
        //        sender.Items.Clear();

        //        for (int i = 0; i < valueList.ValueListItems.Count; i++)
        //        {
        //            //sender.Items.Add(valueList.ValueListItems[i]);

        //            Infragistics.Win.ValueListItem vlltem = new Infragistics.Win.ValueListItem();
        //            vlltem.Tag = valueList.ValueListItems[i].Tag;
        //            vlltem.DataValue = valueList.ValueListItems[i].DataValue;
        //            vlltem.DisplayText = valueList.ValueListItems[i].DisplayText;
        //            sender.Items.Add(vlltem);
        //        }

        //        sender.MaxDropDownItems = valueList.ValueListItems.Count;

        //        sender.Value = 0;
        //    }
        //}
        // --- DEL 2009/01/23 --------------------------------<<<<<

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.29 TOKUNAGA ADD START
        ///// <summary>
        ///// 拠点コード入力フィールドLeaveイベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void tEdit_SectionCd_Leave(object sender, EventArgs e)
        //{
        //    // 拠点コードが入力されているときのみ実行
        //    string sectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim();

        //    if (!String.IsNullOrEmpty(sectionCode))
        //    {
        //        SecInfoSet sectionInfo;
        //        int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);
        //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            this.uLabel_SectionNm.Text = sectionInfo.SectionGuideNm.TrimEnd();

        //            // パラメータ(拠点コード)へ保存
        //            this._paraStockSlipCache_Display.SectionCode = sectionCode;
        //        }
        //    }
        //    else
        //    {
        //        this.uLabel_SectionNm.Text = "";
        //    }
        //}

        ///// <summary>
        ///// 仕入担当入力フィールドLeaveイベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void tEdit_StockAgentCode_Leave(object sender, EventArgs e)
        //{
        //    // 仕入担当者コードが入力されている時のみ実行
        //    string employeeCd = this.tEdit_StockAgentCode.Text.Trim();

        //    if (!string.IsNullOrEmpty(employeeCd))
        //    {
        //        EmployeeAcs employeeAcs = new EmployeeAcs();
        //        Employee employee;
        //        int status = employeeAcs.Read(out employee, this._enterpriseCode, employeeCd);

        //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            uLabel_StockAgentName.Text = employee.Name.Trim();

        //            // パラメータ(仕入担当者コード)へ保存
        //            this._paraStockSlipCache_Display.StockAgentCode = employee.EmployeeCode.Trim();
        //        }
        //    }

        //}

        ///// <summary>
        ///// 倉庫コード入力フィールドLeaveイベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void tEdit_WarehouseCode_Leave(object sender, EventArgs e)
        //{
        //    // 倉庫コードが入力されている場合のみ実行
        //    string warehouseCode = this.tEdit_WarehouseCode.Text.Trim();

        //    if (!string.IsNullOrEmpty(warehouseCode))
        //    {
        //        // 拠点コードが入力されている必要がある
        //        string selectedSectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim();
        //        if (string.IsNullOrEmpty(selectedSectionCode))
        //        {
        //            TMsgDisp.Show(
        //                this,
        //                emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //                this.Name,
        //                "拠点が選択されていません。",
        //                0,
        //                MessageBoxButtons.OK);

        //            return;
        //        }

        //        Warehouse warehouseInfo;
        //        int status = this._warehouseAcs.Read(out warehouseInfo, this._enterpriseCode, selectedSectionCode, warehouseCode);
        //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            this.tEdit_WarehouseCode.Text = warehouseInfo.WarehouseCode.Trim();
        //            this.uLabel_WarehouseName.Text = warehouseInfo.WarehouseName;

        //            // パラメータ(倉庫コード)にセット
        //            this._paraStockSlipCache_Display.WarehouseCode = warehouseInfo.WarehouseCode.Trim();
        //        }
        //    }
        //}

        ///// <summary>
        ///// メーカーコード入力フィールドLeaveイベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void tNedit_GoodsMakerCd_Leave(object sender, EventArgs e)
        //{
        //    // メーカーコードが入力されている場合のみ実行
        //    string makerCode = this.tNedit_GoodsMakerCd.Text.Trim();

        //    if (!string.IsNullOrEmpty(makerCode))
        //    {
        //        MakerUMnt makerUMnt;
        //        MakerAcs makerAcs = new MakerAcs();
        //        int status = makerAcs.Read(out makerUMnt, this._enterpriseCode, int.Parse(makerCode));

        //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            uLabel_MakerName.Text = makerUMnt.MakerName.Trim();

        //            // パラメータ(メーカー名)へセット
        //            this._paraStockSlipCache_Display.GoodsMakerCd = makerUMnt.GoodsMakerCd;
        //        }
        //    }
        //}

        ///// <summary>
        ///// 仕入先コード入力フィールドLeaveイベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void tNedit_SupplierCd_Leave(object sender, EventArgs e)
        //{
        //    // 仕入
        //}

        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.29 TOKUNAGA ADD END
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
        /// <summary>
        /// 前回月次締処理日取得
        /// </summary>
        /// <returns></returns>
        private DateTime GetPrevTotalDayNextDay( string sectionCode )
        {
            DateTime prevTotalDay;
            int status = _ttlDayCalc.GetHisTotalDayMonthlyAccPay( sectionCode.Trim(), out prevTotalDay );

            // 取得日が不正な場合は３ヶ月前をセット
            if ( status != 0 || prevTotalDay == DateTime.MinValue || prevTotalDay > DateTime.Today )
            {
                prevTotalDay = DateTime.Today.AddMonths( -3 );
            }
            // 翌日取得
            prevTotalDay = prevTotalDay.AddDays( 1 );

            return prevTotalDay;
        }
        /// <summary>
        /// 文字列あいまい検索情報取得
        /// </summary>
        /// <param name="originText">元の入力文字列</param>
        /// <param name="searchText">リモートアセンブリに渡す検索文字列</param>
        /// <param name="searchType">リモートアセンブリに渡す検索タイプ</param>
        /// <returns></returns>
        private static void GetSearchType( string originText, out string searchText, out int searchType )
        {
            searchText = originText;
            bool stLike = originText.StartsWith( "*" );
            bool edLike = originText.EndsWith( "*" );

            if ( stLike )
            {
                // 先頭の * を取り除く
                searchText = searchText.Substring( 1 );
            }
            if ( edLike )
            {
                // 末尾の * を取り除く
                searchText = searchText.Substring( 0, searchText.Length - 1 );
            }

            // 先頭＆末尾の*を取り除いてもまだ*がある場合→3:あいまい
            if ( searchText.Contains( "*" ) )
            {
                searchText = searchText.Replace( "*", "" );
                searchType = 3;
                return;
            }


            // 検索タイプの判定
            if ( stLike )
            {
                if ( edLike )
                {
                    // 3:あいまい
                    searchType = 3;
                }
                else
                {
                    // 2:後方一致
                    searchType = 2;
                }
            }
            else
            {
                if ( edLike )
                {
                    // 1:前方一致
                    searchType = 1;
                }
                else
                {
                    // 0:完全一致
                    searchType = 0;
                }
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
        # region [変則フォーカス制御]
        /// <summary>
        /// 変則フォーカス制御クラス
        /// </summary>
        internal class IrregularFocusControl
        {
            /// <summary>
            /// 変則フォーカス制御ディクショナリ　 
            /// </summary>
            private Dictionary<IrregularFocusControlKey, Control> _irregularFocusControlDic;

            /// <summary>
            /// コンストラクタ
            /// </summary>
            public IrregularFocusControl()
            {
                _irregularFocusControlDic = new Dictionary<IrregularFocusControlKey, Control>();
            }

            # region [public メソッド]
            /// <summary>
            /// 変則フォーカス制御ディクショナリ追加
            /// </summary>
            /// <param name="prevCtrl"></param>
            /// <param name="shiftKey"></param>
            /// <param name="key"></param>
            /// <param name="priority"></param>
            /// <param name="nextControl"></param>
            public void AddFocusDictionary( Control prevCtrl, bool shiftKey, Keys key, int priority, Control nextControl )
            {
                _irregularFocusControlDic.Add( new IrregularFocusControlKey( prevCtrl.Name, shiftKey, key, priority ), nextControl );
            }
            /// <summary>
            /// 変則フォーカス制御ディクショナリクリア
            /// </summary>
            public void ClearFocusDictionary()
            {
                _irregularFocusControlDic.Clear();
            }
            /// <summary>
            /// 変則的次フォーカス項目取得処理
            /// </summary>
            /// <param name="e"></param>
            /// <returns></returns>
            public bool ReflectIrregularNextControl( Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e )
            {
                if ( e == null || e.PrevCtrl == null ) return false;
                if ( e.NextCtrl == e.PrevCtrl ) return false;

                bool result = false;

                Control wkControl = GetIrregularNextControl( e.PrevCtrl.Name, e.Key, e.ShiftKey );
                if ( wkControl != null )
                {
                    e.NextCtrl = wkControl;
                    result = true;
                }

                return result;
            }
            # endregion

            # region [private メソッド]
            /// <summary>
            /// 変則的次フォーカス項目取得処理
            /// </summary>
            /// <param name="prevCtrlName"></param>
            /// <param name="key"></param>
            /// <param name="shiftKey"></param>
            /// <returns></returns>
            private Control GetIrregularNextControl( string prevCtrlName, Keys key, bool shiftKey )
            {
                Control irregularNextCtrl = null;

                if ( _irregularFocusControlDic == null )
                {
                    return null;
                }

                int priority = 0;
                IrregularFocusControlKey dicKey = new IrregularFocusControlKey( prevCtrlName, shiftKey, key, priority );
                while ( _irregularFocusControlDic.ContainsKey( dicKey ) )
                {
                    Control wkNextCtrl = _irregularFocusControlDic[dicKey];
                    if ( wkNextCtrl.Enabled == true && wkNextCtrl.Visible == true )
                    {
                        // Enabled=trueならば確定
                        irregularNextCtrl = wkNextCtrl;
                        break;
                    }
                    else
                    {
                        // Enabled=falseならば次の候補へ
                        priority++;
                        dicKey = new IrregularFocusControlKey( prevCtrlName, shiftKey, key, priority );
                    }
                }

                return irregularNextCtrl;
            }
            # endregion

            # region [フォーカス制御キー]
            /// <summary>
            /// フォーカス制御キー
            /// </summary>
            private struct IrregularFocusControlKey
            {
                /// <summary>前コントロール名</summary>
                private string _prevCtrlName;
                /// <summary>押下キーシフト</summary>
                private bool _shiftKey;
                /// <summary>押下キー</summary>
                private Keys _key;
                /// <summary>優先順</summary>
                private int _priority;
                /// <summary>
                /// 前コントロール名
                /// </summary>
                public string PrevCtrlName
                {
                    get { return _prevCtrlName; }
                    set { _prevCtrlName = value; }
                }
                /// <summary>
                /// 押下キーシフト
                /// </summary>
                /// <remarks>True:Shift押下</remarks>
                public bool ShiftKey
                {
                    get { return _shiftKey; }
                    set { _shiftKey = value; }
                }
                /// <summary>
                /// 押下キー
                /// </summary>
                public Keys Key
                {
                    get { return _key; }
                    set { _key = value; }
                }
                /// <summary>
                /// 優先順
                /// </summary>
                /// <remarks>通常は0を指定。フォーカス移動先がEnabled=falseなら1,2,3…と順番に参照する。</remarks>
                public int Priority
                {
                    get { return _priority; }
                    set { _priority = value; }
                }
                /// <summary>
                /// コンストラクタ
                /// </summary>
                /// <param name="prevCtrlName">前コントロール名</param>
                /// <param name="shiftKey">押下キーシフト</param>
                /// <param name="key">押下キー</param>
                /// <param name="priority">優先順</param>
                public IrregularFocusControlKey( string prevCtrlName, bool shiftKey, Keys key, int priority )
                {
                    _prevCtrlName = prevCtrlName;
                    _shiftKey = shiftKey;
                    _key = key;
                    _priority = priority;
                }
            }
            # endregion
        }
        # endregion

        /// <summary>
        /// フォーム描画イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DCKOU04101UA_Shown( object sender, EventArgs e )
        {
            if ( _autoSearch )
            {
                // 検索処理
                SearchDataForInitialSearch();
                _inputDetails.Focus();

                ChangeDecisionButtonEnable( _inputDetails.uGrid_Details.Rows.Count > 0 );
            }
            else
            {
                this.SetInitFocus( this );
            }
        }
        /// <summary>
        /// 初期自動検索処理
        /// </summary>
        private void SearchDataForInitialSearch()
        {
            // クリア
            this.ClearDisplayHeader();
            this.SetDisplayHeaderInfo();
            this._searchSlipAcs.ClearStockSlipDataTable();

            // 条件セット
            SetCondition();

            // 検索実行
            SearchSlip();
        }
        /// <summary>
        /// 
        /// </summary>
        private void SetCondition()
        {
            // 検索条件セット
            # region [条件]
            // 拠点
            if ( this.SectionCode != null && this.SectionCode.Trim() != string.Empty )
            {
                tEdit_SectionCodeAllowZero.Text = this.SectionCode;
                uLabel_SectionNm.Text = this.SectionName;
            }
            else
            {
                string sectionZero;

                UiSet uiset;
                uiSetControl1.ReadUISet( out uiset, this.tEdit_SectionCodeAllowZero.Name );
                if ( uiset != null )
                {
                    sectionZero = new string( '0', uiset.Column );
                }
                else
                {
                    sectionZero = string.Empty;
                }
                tEdit_SectionCodeAllowZero.Text = sectionZero;
                uLabel_SectionNm.Text = ct_AllSection;
            }
            // 仕入先
            tNedit_SupplierCd.SetInt( this.SupplierCd );
            uLabel_SupplierSnm.Text = this.SupplierName;
            // 支払先
            tNedit_PayeeCode.SetInt( this.PayeeCode );
            uLabel_PayeeSnm.Text = this.PayeeName;
            // 伝票種別
            tComboEditor_SupplierFormal.Value = this.SupplierFormal;
            // 伝票区分
            tComboEditor_SupplierSlipCd.Value = this.SupplierSlipCd;
            // 仕入日付
            if ( StockDate != DateTime.MinValue )
            {
                tDateEdit_Date1Start.SetDateTime( StockDate );
                tDateEdit_Date1End.SetDateTime( StockDate );
            }
            // 仕入担当者
            tEdit_StockAgentCode.Text = this.StockAgentCode;
            uLabel_StockAgentName.Text = this.StockAgentName;
            # endregion

            // 自動検索フラグ
            _autoSearch = true;
        }

        /// <summary>
        /// 拠点コードフォーカス進入時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_SectionCodeAllowZero_Enter( object sender, EventArgs e )
        {
            // "tEdit_SectionCode"を指定してゼロ詰め解除する
            tEdit_SectionCodeAllowZero.Text = this.uiSetControl1.GetZeroPadCanceledText( "tEdit_SectionCode", tEdit_SectionCodeAllowZero.Text );
        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD

        // 2008.11.11 add start [7578]

        /// <summary>
        /// 文字サイズ変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_GridFontSize_ValueChanged(object sender, EventArgs e)
        {
            int a = this.StrToIntDefOfValue(this.tComboEditor_GridFontSize.Value, CT_DEF_FONT_SIZE);
            float fontPoint = (float)a;

            this._inputDetails.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = fontPoint;
            this._inputDetails.uGrid_Details.Refresh();

            this.uCheckEditor_AutoFillToColumn_CheckedChanged(null, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultNo"></param>
        /// <returns></returns>
        private int StrToIntDefOfValue(object obj, int defaultNo)
        {
            try
            {
                return (int)obj;
            }
            catch
            {
                return defaultNo;
            }
        }

        /// <summary>
        /// 列の自動調整
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_AutoFillToColumn_CheckedChanged(object sender, EventArgs e)
        {
            // 自動調整プロパティを調整
            if (this.uCheckEditor_AutoFillToColumn.Checked)
            {
                this._inputDetails.uGrid_Details.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                this._inputDetails.uGrid_Details.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
            }

            // 全ての列でサイズ調整
            for (int i = 0; i < this._inputDetails.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
            {
                this._inputDetails.uGrid_Details.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
            }
        }
        // 2008.11.11 add start [7578]
        // ADD 2009/12/04 MANTIS対応[14745]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
        /// <summary>
        /// 仕入履歴照会フォームのFormClosingイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void DCKOU04101UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_disposed) return;

            // FIXME:グリッド列の表示設定を保存
            GridSettings.DetailColumnsList = SlipGridUtil.CreateColumnInfoList(this._inputDetails.DetailGrid);
            SlipGridUtil.StoreGridSettings(GridSettings, XML_FILE_NAME);
        }
        // ADD 2009/12/04 MANTIS対応[14745]：伝票および明細グリッド列の列設定の変更 ----------<<<<<
    }
}
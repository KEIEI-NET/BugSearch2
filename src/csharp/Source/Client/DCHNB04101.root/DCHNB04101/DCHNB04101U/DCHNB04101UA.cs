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
    using GridSettingsType = SlipGridSettings;  // ADD 2009/12/04 MANTIS対応[14743]：伝票および明細グリッド列の列設定の変更

    /// <summary>
    /// 売上履歴照会フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上履歴照会の画面表示クラスです。</br>
    /// <br>             （※過去コメント記載が無い為追加）</br>
    /// <br>Programmer : 22018 鈴木正臣</br>
    /// <br>Date       : 2006.10.21</br>
    /// <br>Update Note: 2009/03/12 30414 忍 幸史 障害ID:12306対応</br>
    /// <br>Update Note: 2009/04/03 30452 上野 俊治 障害ID:13084対応</br>
    /// <br>Update Note: 2009/12/04 30434 工藤 恵優 障害ID:14743対応</br>
    /// <br>Update Note: 2010/06/08 楊明俊 障害・改良 7月分</br>
    /// <br>Update Note: 2011/11/11 鄧潘ハン Redmine 26539対応</br>
    /// <br>Update Note: 2015/05/08 gaocheng</br>
    /// <br>管理番号   : 11175085-00 </br>
    /// <br>           : Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正</br> 
    /// </remarks>
	public partial class DCHNB04101UA : Form
    {
        // ADD 2009/12/04 MANTIS対応[14743]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
        #region グリッドの設定情報

        /// <summary>FIXME:グリッド情報XMLファイル名</summary>
        private const string XML_FILE_NAME = "DCHNB04100U_Construction.XML";

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
        // ADD 2009/12/04 MANTIS対応[14743]：伝票および明細グリッド列の列設定の変更 ----------<<<<<

        public DCHNB04101UA()
		{
			InitializeComponent();

			// 変数初期化
            this._searchSlipAcs = DCHNB04102AA.GetInstance();
            this._dataSet = _searchSlipAcs.DataSet;
            this._inputDetails = new DCHNB04101UB();
            this._imageList16 = IconResourceManagement.ImageList16;
			this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
			this._decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"];
			this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Undo"];
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];
            this._controlScreenSkin = new ControlScreenSkin();

            this._paraStockSlipCache_Display = new SalHisRefExtraParamWork();
#if False
			if (this._searchSlipAcs.GetParaStockSlipCache() != null)
            {
                this._paraStockSlipCache_Display = this._searchSlipAcs.GetParaStockSlipCache();
            }
#endif
            this._inputDetails.StatusBarMessageSetting += new DCHNB04101UB.SettingStatusBarMessageEventHandler(this.SetStatusBarMessage);
            this._searchSlipAcs.StatusBarMessageSetting += new DCHNB04102AA.SettingStatusBarMessageEventHandler(this.SetStatusBarMessage);
            this._inputDetails.CloseMain += new DCHNB04101UB.CloseMainEventHandler(this.CloseForm);
            this._inputDetails.SetMainDialogResult += new DCHNB04101UB.SetDialogResEventHandler(this.SetDialogRes);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
            //this._inputDetails.DecisionButtonEnableSet += new DCHNB04101UB.SettingDecisionButtonEnableEventHandler( this.ChangeDecisionButtonEnable );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
            this._searchSlipAcs.GetNameList += new DCHNB04102AA.GetNameListEventHandler(this.GetDisplayNameList);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
            this._searchSlipAcs.SelectedDataChange += new DCHNB04102AA.SelectedDataChangeEventHandler( this._inputDetails.SearchSlipAcs_SelectedDataChange );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
            // 日付取得部品
            _dateGet = DateGetAcs.GetInstance();
            // 締日算出モジュール
            _totalDayCalculator = TotalDayCalculator.GetInstance();

            // 特殊フォーカス制御
            _irrFocusCtrl = new IrregularFocusControl();
            # region [Focus]
            _irrFocusCtrl.AddFocusDictionary( SectionCodeGuide_ultraButton, false, Keys.Right, 0, tDateEdit_SalesDateSt );
            _irrFocusCtrl.AddFocusDictionary( tComboEditor_SalesSlipCd, false, Keys.Down, 0, tComboEditor_AddUpRemDiv );
            _irrFocusCtrl.AddFocusDictionary( tComboEditor_SalesSlipCd, false, Keys.Down, 1, tEdit_FullModel );
            _irrFocusCtrl.AddFocusDictionary( tDateEdit_SearchSlipDateEd, false, Keys.Down, 0, tEdit_SalesSlipNum_Ed );
            _irrFocusCtrl.AddFocusDictionary( tDateEdit_SearchSlipDateSt, false, Keys.Down, 0, tEdit_SalesSlipNum_St );
            _irrFocusCtrl.AddFocusDictionary( tEdit_FullModel, false, Keys.Down, 0, tNedit_GoodsMakerCd );
            _irrFocusCtrl.AddFocusDictionary( tEdit_FullModel, false, Keys.Down, 1, _inputDetails );
            _irrFocusCtrl.AddFocusDictionary( tEdit_FullModel, false, Keys.Right, 0, tEdit_FrontEmployeeCd );
            _irrFocusCtrl.AddFocusDictionary( tEdit_FullModel, false, Keys.Up, 0, tComboEditor_AddUpRemDiv );
            _irrFocusCtrl.AddFocusDictionary( tEdit_FullModel, false, Keys.Up, 1, tComboEditor_SalesFormalCode );
            _irrFocusCtrl.AddFocusDictionary( tEdit_GoodsName, false, Keys.Down, 0, _inputDetails );
            _irrFocusCtrl.AddFocusDictionary( tEdit_GoodsName, false, Keys.Up, 0, tEdit_FrontEmployeeCd );
            _irrFocusCtrl.AddFocusDictionary( tEdit_SalesSlipNum_Ed, false, Keys.Up, 0, tDateEdit_SearchSlipDateEd );
            _irrFocusCtrl.AddFocusDictionary( uButton_SalesEmployeeGuide, false, Keys.Up, 0, tEdit_SalesSlipNum_Ed );
            _irrFocusCtrl.AddFocusDictionary( ultraButton_SubSectionGuide, false, Keys.Down, 0, uButton_StockCustomerGuide );
            _irrFocusCtrl.AddFocusDictionary( ultraButton_SubSectionGuide, false, Keys.Right, 0, tDateEdit_SearchSlipDateSt );
            # endregion

            // 自動検索パラメータ初期化
            this.SectionCode = string.Empty;
            this.SectionName = string.Empty;
            this.CustomerName = string.Empty;
            this.ClaimName = string.Empty;
            this.SalesEmployeeCd = string.Empty;
            this.SalesEmployeeName = string.Empty;
            this.SalesInputCode = string.Empty;
            this.SalesInputName = string.Empty;
            this.FrontEmployeeCd = string.Empty;
            this.FrontEmployeeName = string.Empty;

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();

            _completeInitialSearch = false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
		}
		public DCHNB04101UA(int startMovment): this()
		{
			this._inputDetails.SetStartMovment(startMovment);
			if(startMovment == 1)
			{
				ChangeDecisionButtonEnable(false);
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                _autoSearch = false;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
			}
		}

        
        private DCHNB04102AA _searchSlipAcs;
        private StockDataSet _dataSet;
        private DCHNB04101UB _inputDetails;
		private SalHisRefExtraParamWork _paraStockSlipCache_Display;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.17 TOKUNAGA DEL START
        //private SecInfoSetAcs _secInfoSetAcs = new SecInfoSetAcs();
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.17 TOKUNAGA DEL END

		//private CarrierEpAcs _carrierEpAcs = new CarrierEpAcs();
		private WarehouseAcs _warehouseAcs = new WarehouseAcs();

		private string _enterpriseCode;             // 企業コード
        private string _loginSectionCode;           // 自拠点コード
        private bool _optSection;                   // 拠点オプション有無フラグ
        private bool _mainOfficeFunc;               // 本社/拠点判断フラグ
        private ImageList _imageList16 = null;									// イメージリスト
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;		// 終了ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _decisionButton;	// 確定ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;		// クリアボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;		// 検索ボタン
        private ControlScreenSkin _controlScreenSkin;
        private DialogResult _dialogRes = DialogResult.Cancel;
        private int _defaultsupplierFormal = 0;
		private int _defaultcustomerCode = 0;

        private const string MESSAGE_StartEndError = "開始日が終了日の前になるよう設定してください。";
        // 2008.11.10 add start [7528]
        private const string MESSAGE_StartEndErrorSlipCd = "開始が終了の前になるよう設定してください。";
        // 2008.11.10 add end [7528]
        private const string MESSAGE_NoInput = "必須入力項目です。";
        private const string MESSAGE_InvalidDate = "有効な日付ではありません。";
		private const string MESSAGE_NoSelectInput = "得意先、伝票番号、商品コードのいずれかを入力してください。";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.17 TOKUNAGA ADD START

        private const string MSG_SALESFORMALCODE_EMPTY   = "伝票種別が選択されていません。";
        private const string MSG_SALESSLIPCD_EMPTY       = "伝票区分が選択されていません。";
        private const string MSG_SALESDATE_EMPTY         = "売上日が選択されていません。";
        
        // アクセスクラス
        SecInfoSetAcs _secInfoSetAcs;           // 拠点アクセスクラス
        SubSectionAcs _subSectionAcs;           // 部門アクセスクラス
        CompanyInfAcs _companyAcs;              // 自社設定アクセスクラス
        CustomerInfoAcs _customerInfoAcs;       // 得意先検索アクセスクラス
        //CompanyInf _conpamyInf;               // 自社設定データクラス
        SalesTtlStAcs _salesTtlStAcs;           // 売上全体設定アクセスクラス
        //SalesTtlSt _salesTtlSt;               // 売上全体設定データクラス

        // 自拠点コード(ログイン時の拠点コード)
        // 画面上の拠点コードとは何も関係ない
        private string _sectionCode;

        // 画面の拠点コード・部門コード
        private string _dspSectionCode;
        private int _dspSubSectionCode;

        // 得意先コード
        // 請求先コード
        private int _customerCode;
        private int _claimCode;

        // 発行者表示区分(DCKHN09211Eの区分と合わせる必要あり)
        private const int INP_AGT_DISP = 0;         // 0:する
        private const int INP_AGT_NODISP = 1;       // 1:しない
        private const int INP_AGT_NESSESALY = 2;    // 2:必須

        // 設定値保存用：売上全体設定．発行者表示区分
        private int _inpAgentDispDiv;

        // 部署管理区分(SFULN09001Eの区分と合わせる必要あり)
        private const int DIV_MNG_SECTION = 0;      // 0:拠点
        private const int DIV_MNG_SUBSECTION = 1;   // 1:拠点＋部
        private const int DIV_MNG_DIVITION = 2;     // 2:拠点＋部＋課

        // 設定値保存用：自社設定．部署管理区分
        private int _secMngDiv;

        // 2008.11.10 add start [7533]
        /// <summary>表示：初期フォントサイズ</summary>
        private const int CT_DEF_FONT_SIZE = 11;
        // 2008.11.10 add end [7533]

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.17 TOKUNAGA ADD END

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
        private bool _autoSearch = true;        // 自動検索フラグ
        private bool _completeInitialSearch;    // 初期検索済みフラグ

        private DateGetAcs _dateGet;                    // 日付取得部品
        private TotalDayCalculator _totalDayCalculator; // 締日算出モジュール
        private IrregularFocusControl _irrFocusCtrl;    // 特殊フォーカス制御

        // 検索条件 拠点コード
        private string _paraSectionCode;
        // 検索条件 拠点名称
        private string _paraSectionName;
        // 検索条件 得意先コード
        private int _paraCustomerCode;
        // 検索条件 得意先名称
        private string _paraCustomerName;
        // 検索条件 売上日
        private DateTime _paraSalesDate;
        // 検索条件 受注ステータス
        private int _paraAcptAnOdrStatus;
        // 検索条件 請求先コード
        private int _paraClaimCode;
        // 検索条件 請求先名称
        private string _paraClaimName;

        // 検索条件 伝票区分
        private int _paraSalesSlipCd;
        // 検索条件 担当者コード
        private string _paraSalesEmployeeCd;
        // 検索条件 発行者コード
        private string _paraSalesInputCode;
        // 検索条件 受注者コード
        private string _paraFrontEmployeeCd;
        // 検索条件 担当者名称
        private string _paraSalesEmployeeName;
        // 検索条件 発行者名称
        private string _paraSalesInputName;
        // 検索条件 受注者名称
        private string _paraFrontEmployeeName;

        // 検索条件 得意先固定
        private bool _customerCodeFix;
        // 検索条件 受注ステータス固定
        private bool _acptAnOdrStatusFix;
        // 検索条件 伝票区分固定
        private bool _salesSlipCdFix;
        // 検索条件 出荷状況固定
        private bool _addUpRemDivFix;

        // 検索条件 出荷状況
        private int _paraAddUpRemDiv;
        // 検索条件 部門コード
        private int _paraSubSectionCode;
        // 検索条件 部門名称
        private string _paraSubSectionName;

        // 2008.11.27 add start [8286]
        // 検索条件 品番
        private string _paraGoodsNo;
        // 検索条件 メーカー
        private int _paraGoodsMakerCd;
        // 検索条件 メーカー名
        private string _paraGoodsMakeName;
        // 2008.11.27 add end [8286]

        private static string ct_AllSectionName = "全社";
        //エラー条件メッセージ
        const string ct_InputError = "の入力が不正です";
        const string ct_NoInput = "を入力して下さい";
        const string ct_RangeError = "の範囲指定に誤りがあります";
        const string ct_RangeOverError = "は３ヶ月の範囲内で入力して下さい。";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD

        // 2008.11.10 add start [7533]
        private readonly int[] _fontpitchSize = new int[] { 6, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24 };
        // 2008.11.10 add end [7533]

        /// <summary>
        /// 呼出制御処理
        /// </summary>
        /// <param name="owner">呼出元オブジェクト</param>
        /// <param name="carrierCode">キャリアコード</param>
        public DialogResult ShowDialog(IWin32Window owner, int supplierFormal)
        {
            this._defaultsupplierFormal = supplierFormal;
			this._inputDetails._supplierFormal = this._defaultsupplierFormal;

            return this.ShowDialog(owner);
        }

		/// <summary>
		/// 呼出制御処理(得意先指定)
		/// </summary>
		/// <param name="owner">呼出元オブジェクト</param>
		/// <param name="carrierCode">キャリアコード</param>
		public DialogResult ShowDialog(IWin32Window owner, int supplierFormal, int customerCode)
		{
			this._defaultsupplierFormal = supplierFormal;
			this._defaultcustomerCode = customerCode;
			this._inputDetails._supplierFormal = this._defaultsupplierFormal;
			return this.ShowDialog(owner);
		}

        /// <summary>
        /// 選択伝票データ取得プロパティ
        /// </summary>
		public List<SalHisRefResultParamWork> StcHisRefDataWork
        {
            get { return this._inputDetails._salHisRefResultParamWork; }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
        /// <summary>
        /// 選択可能件数
        /// </summary>
        public int MaxSelectCount
        {
            get { return this._inputDetails.MaxSelectCount; }
            set
            {
                this._inputDetails.MaxSelectCount = value;
                this._searchSlipAcs.MaxSelectCount = value;
            }
        }
        /// <summary>
        /// 自動抽出開始
        /// </summary>
        public bool AutoSearch
        {
            get { return _autoSearch; }
            set { _autoSearch = value; }
        }
        /// <summary>
        /// 拠点コード
        /// </summary>
        public string SectionCode
        {
            get { return _paraSectionCode; }
            set { _paraSectionCode = value; }
        }
        /// <summary>
        /// 拠点名称
        /// </summary>
        public string SectionName
        {
            get { return _paraSectionName; }
            set { _paraSectionName = value; }
        }
        /// <summary>
        /// 得意先コード
        /// </summary>
        public int CustomerCode
        {
            get { return _paraCustomerCode; }
            set { _paraCustomerCode = value; }
        }
        /// <summary>
        /// 得意先名称
        /// </summary>
        public string CustomerName
        {
            get { return _paraCustomerName; }
            set { _paraCustomerName = value; }
        }
        /// <summary>
        /// 請求先コード
        /// </summary>
        public int ClaimCode
        {
            get { return _paraClaimCode; }
            set { _paraClaimCode = value; }
        }
        /// <summary>
        /// 検索条件 請求先名称
        /// </summary>
        public string ClaimName
        {
            get { return _paraClaimName; }
            set { _paraClaimName = value; }
        }
        /// <summary>
        /// 売上日
        /// </summary>
        public DateTime SalesDate
        {
            get { return _paraSalesDate; }
            set { _paraSalesDate = value; }
        }
        /// <summary>
        /// 伝票種別
        /// </summary>
        public int AcptAnOdrStatus
        {
            get { return _paraAcptAnOdrStatus; }
            set { _paraAcptAnOdrStatus = value; }
        }
        /// <summary>
        /// 伝票区分
        /// </summary>
        public int SalesSlipCd
        {
            get { return _paraSalesSlipCd; }
            set { _paraSalesSlipCd = value; }
        }
        /// <summary>
        /// 担当者コード
        /// </summary>
        public string SalesEmployeeCd
        {
            get { return _paraSalesEmployeeCd; }
            set { _paraSalesEmployeeCd = value; }
        }
        /// <summary>
        /// 発行者コード
        /// </summary>
        public string SalesInputCode
        {
            get { return _paraSalesInputCode; }
            set { _paraSalesInputCode = value; }
        }
        /// <summary>
        /// 受注者コード
        /// </summary>
        public string FrontEmployeeCd
        {
            get { return _paraFrontEmployeeCd; }
            set { _paraFrontEmployeeCd = value; }
        }
        /// <summary>
        /// 担当者名称
        /// </summary>
        public string SalesEmployeeName
        {
            get { return _paraSalesEmployeeName; }
            set { _paraSalesEmployeeName = value; }
        }
        /// <summary>
        /// 発行者名称
        /// </summary>
        public string SalesInputName
        {
            get { return _paraSalesInputName; }
            set { _paraSalesInputName = value; }
        }
        /// <summary>
        /// 受注者名称
        /// </summary>
        public string FrontEmployeeName
        {
            get { return _paraFrontEmployeeName; }
            set { _paraFrontEmployeeName = value; }
        }
        /// <summary>
        /// 得意先コード固定
        /// </summary>
        public bool CustomerCodeFix
        {
            get { return _customerCodeFix; }
            set { _customerCodeFix = value; }
        }
        /// <summary>
        /// 出荷区分
        /// </summary>
        public int AddUpRemDiv
        {
            get { return _paraAddUpRemDiv; }
            set { _paraAddUpRemDiv = value; }
        }
        /// <summary>
        /// 部門コード
        /// </summary>
        public int SubSectionCode
        {
            get { return _paraSubSectionCode; }
            set { _paraSubSectionCode = value; }
        }
        /// <summary>
        /// 部門名称
        /// </summary>
        public string SubSectionName
        {
            get { return _paraSubSectionName; }
            set { _paraSubSectionName = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
        /// <summary>
        /// 伝票種別固定
        /// </summary>
        public bool AcptAnOdrStatusFix
        {
            get { return _acptAnOdrStatusFix; }
            set { _acptAnOdrStatusFix = value; }
        }
        /// <summary>
        /// 伝票区分固定
        /// </summary>
        public bool SalesSlipCdFix
        {
            get { return _salesSlipCdFix; }
            set { _salesSlipCdFix = value; }
        }
        /// <summary>
        /// 出荷状況固定
        /// </summary>
        public bool AddUpRemDivFix
        {
            get { return _addUpRemDivFix; }
            set { _addUpRemDivFix = value; }
        }
        /// <summary>
        /// 抽出条件グループ展開状態
        /// </summary>
        public bool Standard_UGroupBox_Expand
        {
            get { return this.Standard_UGroupBox.Expanded; }
            set { this.Standard_UGroupBox.Expanded = value; }
        }
        /// <summary>
        /// 詳細条件グループ展開状態
        /// </summary>
        public bool Detail_UGroupBox_Expand
        {
            get { return this.Detail_UGroupBox.Expanded; }
            set { this.Detail_UGroupBox.Expanded = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

        // 2008.11.10 add start [7526]

        public int SecMngDiv
        {
            get { return this._secMngDiv; }
            set { this._secMngDiv = value; }
        }

        public int InpAgentDispDiv
        {
            get { return this._inpAgentDispDiv; }
            set { this._inpAgentDispDiv = value; }
        }

        // 2008.11.10 add end [7526]

        // 2008.11.27 add start [8286]

        public string GoodsNo
        {
            get { return this._paraGoodsNo; }
            set { this._paraGoodsNo = value; }
        }

        public int GoodsMakerCd
        {
            get { return this._paraGoodsMakerCd; }
            set { this._paraGoodsMakerCd = value; }
        }

        public string GoodsMakerName
        {
            get { return this._paraGoodsMakeName; }
            set { this._paraGoodsMakeName = value; }
        }

        // 2008.11.27 add end [8286]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note: 2011/11/11 鄧潘ハン BLﾊﾟｰﾂｵｰﾀﾞｰ在庫確認時の見積伝票対応</br>
        private void DCHNB04101UA_Load( object sender, EventArgs e )
        {
            try
            {
                this.SuspendLayout();

                // 画面スキンファイルの読込(デフォルトスキン指定)
                this._controlScreenSkin.LoadSkin();

                // スキン変更除外設定
                List<string> excCtrlNm = new List<string>();
                excCtrlNm.Add( this.Standard_UGroupBox.Name );
                excCtrlNm.Add( this.Detail_UGroupBox.Name );
                this._controlScreenSkin.SetExceptionCtrl( excCtrlNm );

                // 画面スキン変更
                this._controlScreenSkin.SettingScreenSkin( this );
                this._controlScreenSkin.SettingScreenSkin( this._inputDetails );

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.17 TOKUNAGA MODIFY START
                // DCHNB04102UB を、panel_Detailを親としたコントロールにする
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.17 TOKUNAGA MODIFY END
                this.panel_Detail.Controls.Add( this._inputDetails );
                this._inputDetails.Dock = DockStyle.Fill;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                ////　企業コードを取得する
                //this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                //// 自拠点コードを取得する
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 DEL
                ////this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 DEL
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
                //this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL

                // 拠点オプション有無を取得する
                this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany( ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION ) > 0);
                // 本社/拠点情報を取得する
                this._mainOfficeFunc = this._searchSlipAcs.IsMainOfficeFunc();

                //this._searchSlipAcs.SetSectionComboEditor(ref this.tComboEditor_SalesInpSecCd, true);

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.17 TOKUNAGA ADD START
                // 拠点・部門アクセスクラスを作成
                this._secInfoSetAcs = new SecInfoSetAcs();
                this._subSectionAcs = new SubSectionAcs();

                // アクセスクラスを作成
                this._customerInfoAcs = new CustomerInfoAcs();
                this._companyAcs = new CompanyInfAcs();
                CompanyInf companyInf;

                // 自社設定を取得
                this._companyAcs.Read( out companyInf, this._enterpriseCode );
                if ( companyInf != null )
                {
                    this._secMngDiv = companyInf.SecMngDiv;

                    // 部門管理区分が拠点であれば部門名を非表示
                    // 0:拠点　1:拠点＋部　2:拠点＋部＋課（ソースより）
                    if ( this._secMngDiv == 0 )
                    {
                        this.tNedit_SubSectionCode.Visible = false;
                        this.tEdit_SubSectionName.Visible = false;
                        this.ultraLabel14.Visible = false;
                        this.ultraButton_SubSectionGuide.Visible = false;
                    }

                    // 明細に渡す
                    this._inputDetails.SecMngDiv = this._secMngDiv;
                }


                //// 自拠点コードを取得
                //SecInfoSet secInfoSet;
                //SecInfoAcs secInfoAcs = new SecInfoAcs();
                //secInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);
                //this._sectionCode = secInfoSet.SectionCode.TrimEnd();
                ////this._dspSectionCode = secInfoSet.SectionCode.TrimEnd();

                // 2008.11.10 modify start [7526]

                // 売上全体設定を取得
                // TODO このSearchAllは将来的にSearchメソッドに変わる可能性あり。
                ArrayList retSalesTtlSt;
                this._salesTtlStAcs = new SalesTtlStAcs();
                int status = _salesTtlStAcs.SearchAll(out retSalesTtlSt, this._enterpriseCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //if (retSalesTtlSt.Count > 0)
                {
                    foreach (SalesTtlSt salesTtlSt in retSalesTtlSt)
                    {
                        if (salesTtlSt.SectionCode.Trim() == this._loginSectionCode.Trim())
                        {
                            // 0:する　1:しない　 2:必須
                            this._inpAgentDispDiv = salesTtlSt.InpAgentDispDiv;

                            // 明細に渡す
                            this._inputDetails.InpAgentDispDiv = this._inpAgentDispDiv;
                            break;
                        }
                    }
                }

                // 列を再設定
                this._inputDetails.refreshGridLayout();

                // 発行者欄を消去
                if (this._inpAgentDispDiv == INP_AGT_NODISP)
                {
                    this.ultraLabel11.Visible = false;
                    this.tEdit_SalesInputCode.Visible = false;
                    this.uLabel_SalesInputName.Visible = false;
                    this.uButton_SalesInputGuide.Visible = false;
                }

                // 2008.11.10 modify end [7526]

                // ボタンイメージを設定
                this.SectionCodeGuide_ultraButton.ImageList = this._imageList16;
                this.SectionCodeGuide_ultraButton.Appearance.Image = (int)Size16_Index.STAR1;

                this.ultraButton_SubSectionGuide.ImageList = this._imageList16;
                this.ultraButton_SubSectionGuide.Appearance.Image = (int)Size16_Index.STAR1;

                this.uButton_FrontEmployeeGuide.ImageList = this._imageList16;
                this.uButton_FrontEmployeeGuide.Appearance.Image = (int)Size16_Index.STAR1;

                // デフォルト値をクリア(デザイナで桁数調整のために入っている文字列をクリアする)
                this.tEdit_SectionCodeAllowZero.Clear();            // 拠点コード
                this.tNedit_SubSectionCode.Clear();         // 部署コード   
                this.tNedit_CustomerCode.Clear();           // 得意先コード
                this.tEdit_SalesSlipNum_St.Clear();        // 伝票番号開始
                this.tEdit_FullModel.Clear();               // 絞込型式
                this.tEdit_SalesEmployeeCd.Clear();         // 担当者コード
                this.tEdit_SalesInputCode.Clear();          // 発行者コード
                this.tEdit_FrontEmployeeCd.Clear();         // 受注者コード

                // 伝票種別のデフォルト選択は"売上"
                this.tComboEditor_SalesFormalCode.SelectedIndex = 0;

                //---ADD 2011/11/11 ----------------------------->>>>>
                //連携伝票出力区分のデフォルト選択は"連携伝票を含まない"
                this.tComboEditor_AutoAnswerDivSCM.SelectedIndex = 0;
                //連携伝票対象区分
                this.uCheckEditor_PccForNS.Enabled = false;
                this.uCheckEditor_BlPaCOrder.Enabled = false;
                //---ADD 2011/11/11 -----------------------------<<<<<

                // デフォルトを"売上"以外に設定した場合はValueChangedを呼んで伝票区分を再設定する
                //this.tComboEditor_SalesFormalCode_ValueChanged();

                // 2008.11.10 add start [7533]
                // 文字サイズ設定
                for (int i = 0; i < this._fontpitchSize.Length; i++)
                {
                    this.tComboEditor_GridFontSize.Items.Add(this._fontpitchSize[i], this._fontpitchSize[i].ToString());
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/09 DEL
                //this.tComboEditor_GridFontSize.Text = CT_DEF_FONT_SIZE.ToString();
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/09 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/09 ADD
                this.tComboEditor_GridFontSize.ValueChanged -= tComboEditor_GridFontSize_ValueChanged;
                this.tComboEditor_GridFontSize.Text = CT_DEF_FONT_SIZE.ToString();
                this.tComboEditor_GridFontSize.ValueChanged += tComboEditor_GridFontSize_ValueChanged;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/09 ADD

                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/09 ADD
                // 2008.11.10 add end [7533]

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 DEL
                //this.tEdit_SectionCodeAllowZero.Text = this._loginSectionCode;
                //this.tEdit_SectionCodeAllowZero_Leave(null, null);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 DEL

                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.17 TOKUNAGA ADD END

                // ボタン初期設定処理
                this.ButtonInitialSetting();

                // 画面初期情報設定処理
                this.SetInitialInput();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                //// 元に戻す処理
                //this.ClearDisplayHeader();
                //this.SetDisplayHeaderInfo();
                //this._searchSlipAcs.ClearStockSlipDataTable();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                if ( !_completeInitialSearch )
                {
                    // 元に戻す処理
                    this.ClearDisplayHeader();
                    this.SetDisplayHeaderInfo();
                    this._searchSlipAcs.ClearStockSlipDataTable();
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

                // ADD 2009/12/04 MANTIS対応[14743]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
                // FIXME:列移動と列固定を可能とする
                SlipGridUtil.EnableAllowColSwappingAndFixedHeaderIndicator(this._inputDetails.DetailGrid);
                // FIXME:グリッド列の設定を取込
                SlipGridUtil.LoadColumnInfo(this._inputDetails.DetailGrid, GridSettings.DetailColumnsList);
                // 固定列用にもう一度
                SlipGridUtil.LoadColumnInfo(this._inputDetails.DetailGrid, GridSettings.DetailColumnsList);
                // ADD 2009/12/04 MANTIS対応[14743]：伝票および明細グリッド列の列設定の変更 ----------<<<<<
            }
            finally
            {
                this.ResumeLayout();
            }
        }

        /// <summary>
        /// 画面初期情報設定処理
        /// </summary>
        private void SetInitialInput()
        {
            //StockDataSet.StockSlipDataTable stockDatail = this._searchSlipAcs.GetStockSlipTableCache();
			StockDataSet.SalesDetailDataTable stockDatail = this._searchSlipAcs.GetStockSlipTableCache();

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

#if False
			// 前回検索情報有無判断
            if ((stockDatail == null) ||
                (stockDatail.Count == 0)||
                (_paraStockSlipCache_Display.SupplierFormal != this._defaultsupplierFormal)) 
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
                this._inputDetails.timer_GridSetFocus.Enabled = true;
            }
#endif
        }

        /// <summary>
        /// 画面ヘッダクリア処理
        /// </summary>
        private void ClearDisplayHeader()
        {

			this.tComboEditor_SalesSlipCd.Value = 0;		    //伝票区分

			this.tEdit_SalesEmployeeCd.Clear();                 // 担当者コード
			this.uLabel_SalesEmployeeName.Text = "";            // 担当者名

			this.tEdit_SalesInputCode.Clear();				    // 入力者コード
			this.uLabel_SalesInputName.Text = "";			    // 入力者名

			this.tNedit_CustomerCode.Clear();                   // 得意先コード
            this.uLabel_CustomerName.Text = "";                 // 得意先名

			this.tNedit_ClaimCode.Clear();					    // 請求先コード
			this.uLabel_ClaimSnm.Text = "";					    // 請求先名

            this.tDateEdit_SalesDateSt.Clear();                 // 売上日(開始)
			this.tDateEdit_SalesDateEd.Clear();                 // 売上日(終了)

			this.tDateEdit_SearchSlipDateSt.Clear();		    // 入力日(開始)
			this.tDateEdit_SearchSlipDateEd.Clear();		    // 入力日(終了)

			this.tEdit_SalesSlipNum_St.Clear();	                // 伝票番号(開始)
			this.tEdit_SalesSlipNum_Ed.Clear();	                // 伝票番号(終了)
            //this.tEdit_OrderNumber.Clear();					// 得意先注番

			this.tNedit_GoodsMakerCd.Clear();				    // メーカーコード
			this.uLabel_MakerName.Text = "";				    // メーカー名

            this.tEdit_GoodsNo.Clear();                         // 商品コード
            //this.uLabel_GoodsName.Text = "";                  // 商品名
			this.tEdit_GoodsName.Clear();					    // 商品名検索

            // 2008.11.10 add start [0007524]
            this.tNedit_SubSectionCode.Clear();                 // 部門コード
            this.tEdit_SubSectionName.Clear();                  // 部門名

            this.tComboEditor_SalesFormalCode.SelectedIndex = 0;    // 伝票種別

            this.tEdit_FullModel.Clear();                       // 型式

            this.tEdit_FrontEmployeeCd.Clear();                 // 受注者コード
            this.uLabel_FrontEmployeeName.Text = string.Empty;  // 受注者名
            // 2008.11.10 add end [0007524]

            this.ChangeDecisionButtonEnable(false);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
            //this.timer_InitialSetFocus.Enabled = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/24 ADD
            _paraStockSlipCache_Display = new SalHisRefExtraParamWork();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/24 ADD
        }

        /// <summary>
        /// 画面ヘッダ表示処理
        /// </summary>
        private void SetDisplayHeaderInfo()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
            // 拠点コード
            this.tEdit_SectionCodeAllowZero.Text = this._loginSectionCode;

            // 拠点名称
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.Read( out sectionInfo, this._enterpriseCode, _loginSectionCode.Trim() );
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo != null )
            {
                SectionName_tEdit.Text = sectionInfo.SectionGuideNm.Trim();
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD

            // コンボボックス項目初期表示

			//仕入先
			if (_defaultcustomerCode == 0)
			{
				this.tNedit_CustomerCode.Clear();
				this.uLabel_CustomerName.Text = "";
			}
			else
			{
				int code = _defaultcustomerCode;
                CustomerInfo customerInfo;
                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
				int st = customerInfoAcs.ReadDBData(this._enterpriseCode, code, out customerInfo);

				if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// 仕入先コード・名称セット
					this.tNedit_CustomerCode.SetInt(code);
					this.uLabel_CustomerName.Text = customerInfo.Name;
				}
			}

			//売上日
			//this.tDateEdit_SalesDateSt.SetDateTime(DateTime.Today.AddMonths(-1));
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
            //this.tDateEdit_SalesDateSt.SetDateTime(DateTime.MinValue);
            //this.tDateEdit_SalesDateEd.SetDateTime(DateTime.MinValue);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
            this.tDateEdit_SalesDateSt.SetDateTime( GetPrevTotalDayNextDay( _loginSectionCode ) );
            this.tDateEdit_SalesDateEd.SetDateTime( DateTime.Today );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD

			//入力日
			this.tDateEdit_SearchSlipDateSt.SetDateTime(DateTime.MinValue);
			this.tDateEdit_SearchSlipDateSt.SetDateTime(DateTime.MinValue);


            // 拠点設定
			//this._searchSlipAcs.SetSectionComboEditorValue(this.tComboEditor_SalesInpSecCd, this._loginSectionCode);						
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
			SalHisRefExtraParamWork salHisRefExtraParamWork = this._searchSlipAcs.GetParaStockSlipCache();
            if(salHisRefExtraParamWork == null)
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
			this.tComboEditor_SupplierFormal.SelectedIndex = salHisRefExtraParamWork.SupplierFormal;

#if False
			// 拠点
			this.tEdit_SectionCd.Text = salHisRefExtraParamWork.SectionCd;
			if (nameList.Contains("SectionNm")) this.uLabel_SectionNm.Text = nameList["SectionNm"].ToString();
#endif

			// 仕入先コード
			this.tNedit_CustomerCode.SetInt(salHisRefExtraParamWork.CustomerCode);
			if (nameList.Contains("CustomerName")) this.uLabel_CustomerName.Text = nameList["CustomerName"].ToString();

			// メーカーコード
			//this.tNedit_GoodsMakerCd.SetInt(salHisRefExtraParamWork.GoodsMakerCd);
			if (nameList.Contains("MakerName")) this.uLabel_MakerName.Text = nameList["MakerName"].ToString();

			// 仕入日(開始)-(終了)
			//this.tDateEdit_Date1Start.LongDate = TDateTime.DateTimeToLongDate(salHisRefExtraParamWork.StockDateSt);          // 仕入日(開始)
			//this.tDateEdit_Date1End.LongDate = TDateTime.DateTimeToLongDate(salHisRefExtraParamWork.StockDateEd);            // 仕入日(終了)

			//支払先
			//this.tNedit_CustomerCode.SetInt(salHisRefExtraParamWork.PayeeCode);
			if (nameList.Contains("PayeeSnm")) this.uLabel_PayeeSnm.Text = nameList["PayeeSnm"].ToString();                    // 得意先名

			// 仕入担当者コード
			this.tEdit_StockAgentCode.Text = salHisRefExtraParamWork.StockAgentCode;                    // 仕入担当
			if (nameList.Contains("StockAgentName")) this.uLabel_StockAgentName.Text = nameList["StockAgentName"].ToString();                // 仕入担当名

			// 倉庫コード	
			this.tEdit_WarehouseCode.Text = salHisRefExtraParamWork.WarehouseCode;                      // 倉庫コード
			if (nameList.Contains("WarehouseName")) this.uLabel_WarehouseName.Text = nameList["WarehouseName"].ToString();                  // 倉庫名

			// 伝票番号
			this.tEdit_SupplierSlipNo.Text = salHisRefExtraParamWork.SupplierSlipNo.ToString();

			// 発注番号
			//this.tEdit_OrderNumber.Text = salHisRefExtraParamWork.OrderNumber.ToString();

#if False
			// 商品コード
			this.tEdit_GoodsCode.Text = salHisRefExtraParamWork.GoodsCode;                              // 商品コード
			this.uLabel_GoodsName.Text = nameList["GoodsName"].ToString();                          // 商品名
#endif

			// 商品名検索
			//tEdit_GoodsName.Text = salHisRefExtraParamWork.SearchGoodsName;

			// 買掛区分(1、2のIndexが逆)
            int selectIndex = ConvertComboEditorIndex(salHisRefExtraParamWork.AccPayDivCd);
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

#if False
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
				case 30:      // 伝票区分 "現金仕入"
					{
						retIndex = 3;
						break;
					}
				case 40:      // 伝票区分 "現金返品"
					{
						retIndex = 4;
						break;
					}
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
#endif

		/// <summary>
		/// ボタン初期設定処理
		/// </summary>
		private void ButtonInitialSetting()
		{
			this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
			this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
			this._decisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.17 TOKUNAGA MODIFY START
            //this._undoButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;
			this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.17 TOKUNAGA MODIFY END
            this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;

			//imageList16
			this.uButton_SalesEmployeeGuide.ImageList = this._imageList16;
			this.uButton_GoodsMakerGuide.ImageList = this._imageList16;
			this.uButton_StockCustomerGuide.ImageList = this._imageList16;
            //this.uButton_GoodsGuide.ImageList = this._imageList16;
			this.uButton_ClaimGuide.ImageList = this._imageList16;
			this.uButton_SalesInputGuide.ImageList = this._imageList16;

			//STAR1
            this.uButton_SalesEmployeeGuide.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_GoodsMakerGuide.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_StockCustomerGuide.Appearance.Image = (int)Size16_Index.STAR1;
            //this.uButton_GoodsGuide.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_ClaimGuide.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_SalesInputGuide.Appearance.Image = (int)Size16_Index.STAR1;
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
        /// <return>読込条件パラメータクラス</return>
        /// <br>Update Note: 2011/11/11 鄧潘ハン BLﾊﾟｰﾂｵｰﾀﾞｰ在庫確認時の見積伝票対応</br>
        public void SetReadPara(out SalHisRefExtraParamWork salHisRefExtraParamWork)
        {
            // 検索条件を格納するパラメータクラスのインスタンスを作成
            salHisRefExtraParamWork = new SalHisRefExtraParamWork();

			//企業コード
            salHisRefExtraParamWork.EnterpriseCode = this._enterpriseCode;

            //拠点コード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.17 TOKUNAGA DEL START
            //salHisRefExtraParamWork.SectionCode = this.tComboEditor_SalesInpSecCd.Value.ToString().Trim();
            //if (salHisRefExtraParamWork.SectionCode == "000000")
            //{
            //    salHisRefExtraParamWork.SectionCode = "";
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.17 TOKUNAGA DEL END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.17 TOKUNAGA ADD START
            string strPicker;

            strPicker = this.tEdit_SectionCodeAllowZero.Text;
            if (string.IsNullOrEmpty(strPicker) || strPicker == "00")
            {
                salHisRefExtraParamWork.SectionCode = "";
            }
            else
            {
                salHisRefExtraParamWork.SectionCode = strPicker.Trim();
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.17 TOKUNAGA ADD END


			//部門コード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.17 TOKUNAGA DEL START
            //salHisRefExtraParamWork.SubSectionCode = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.17 TOKUNAGA DEL END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.17 TOKUNAGA ADD START
            // 部署管理区分が拠点の場合は部署は使用されない
            if (this._secMngDiv == DIV_MNG_DIVITION)
            {
                salHisRefExtraParamWork.SubSectionCode = 0;
            }
            else
            {
                strPicker = this.tNedit_SubSectionCode.Text;
                if (string.IsNullOrEmpty(strPicker) || strPicker == "00")
                {
                    salHisRefExtraParamWork.SubSectionCode = 0;
                }
                else
                {
                    salHisRefExtraParamWork.SubSectionCode = this.tNedit_SubSectionCode.GetInt();
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.17 TOKUNAGA ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.17 TOKUNAGA DEL START
			//課コード
			//salHisRefExtraParamWork.MinSectionCode = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.17 TOKUNAGA DEL END

			//得意先コード
			salHisRefExtraParamWork.CustomerCode = this.tNedit_CustomerCode.GetInt();

            //請求先
            salHisRefExtraParamWork.ClaimCode = this.tNedit_ClaimCode.GetInt();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.17 TOKUNAGA ADD START
            // 伝票種別
            salHisRefExtraParamWork.AcptAnOdrStatus = (int)this.tComboEditor_SalesFormalCode.SelectedItem.DataValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.17 TOKUNAGA ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/24 ADD
            // 出荷状況(貸出だけの場合のみ)
            if ( salHisRefExtraParamWork.AcptAnOdrStatus == 40 )
            {
                salHisRefExtraParamWork.AddUpRemDiv = (int)this.tComboEditor_AddUpRemDiv.Value;
            }
            else
            {
                salHisRefExtraParamWork.AddUpRemDiv = 0;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/24 ADD

            //売上伝票区分(-1:全て,0:売上,1:返品,2:値引)
            //売掛区分(-1:全て,0:売掛なし,1:売掛)
            int code = Convert.ToInt32(tComboEditor_SalesSlipCd.Value);
            if (code == -1)
            {
                salHisRefExtraParamWork.SalesSlipCd = -1;
                salHisRefExtraParamWork.AccRecDivCd = -1;
            }
            else if (code == 0)
            {
                salHisRefExtraParamWork.SalesSlipCd = 0;
                salHisRefExtraParamWork.AccRecDivCd = 1;
            }
            else if (code == 1)
            {
                salHisRefExtraParamWork.SalesSlipCd = 1;
                salHisRefExtraParamWork.AccRecDivCd = 1;
            }
            else if (code == 100)
            {
                salHisRefExtraParamWork.SalesSlipCd = 0;
                salHisRefExtraParamWork.AccRecDivCd = 0;
            }
            else if (code == 101)
            {
                salHisRefExtraParamWork.SalesSlipCd = 1;
                salHisRefExtraParamWork.AccRecDivCd = 0;
            }
            else
            {
                salHisRefExtraParamWork.SalesSlipCd = 0;
                salHisRefExtraParamWork.AccRecDivCd = 1;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.17 TOKUNAGA ADD START
            // 絞込型式
            salHisRefExtraParamWork.FullModel = this.tEdit_FullModel.Text.Trim();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.17 TOKUNAGA ADD END

			// 売上日(開始)-(終了)
			//salHisRefExtraParamWork.StockDateSt = TDateTime.LongDateToDateTime(this.tDateEdit_Date1Start.GetLongDate());
			//salHisRefExtraParamWork.StockDateEd = TDateTime.LongDateToDateTime(this.tDateEdit_Date1End.GetLongDate());
			salHisRefExtraParamWork.SalesDateSt = this.tDateEdit_SalesDateSt.GetLongDate();
			salHisRefExtraParamWork.SalesDateEd = this.tDateEdit_SalesDateEd.GetLongDate();

            //入力日(開始)-(終了)
            salHisRefExtraParamWork.SearchSlipDateSt = this.tDateEdit_SearchSlipDateSt.GetLongDate();
            salHisRefExtraParamWork.SearchSlipDateEd = this.tDateEdit_SearchSlipDateEd.GetLongDate();

            //伝票番号(開始)-(終了)
            //salHisRefExtraParamWork.SalesSlipNum = this.ValueToInt(this.tEdit_SupplierSlipNo.Text);
            salHisRefExtraParamWork.SalesSlipNumSt = this.tEdit_SalesSlipNum_St.Text.Trim();
            salHisRefExtraParamWork.SalesSlipNumEd = this.tEdit_SalesSlipNum_Ed.Text.Trim();

            //担当者コード(販売従業員コード)
            salHisRefExtraParamWork.SalesEmployeeCd = this.tEdit_SalesEmployeeCd.Text;

            //発行者コード
            salHisRefExtraParamWork.SalesInputCode = this.tEdit_SalesInputCode.Text;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.17 TOKUNAGA MODIFY START
            //受付従業員コード
            salHisRefExtraParamWork.FrontEmployeeCd = this.tEdit_FrontEmployeeCd.Text;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.17 TOKUNAGA MODIFY END


            //詳細条件

            //メーカーコード
            salHisRefExtraParamWork.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
            ////検索商品
            ////salHisRefExtraParamWork.GoodsNmVagueSrch = this.CheckEditor_GoodsName.Checked;
            //string strExtract = this.tEdit_GoodsName.Text.Trim();
            //salHisRefExtraParamWork.GoodsName = strExtract; // this.tEdit_GoodsName.Text.Trim();

            //// 入力された文字列から曖昧検索条件を割り出す
            //if (strExtract.Trim().Length > 0)
            //{
            //    int targetIndex = strExtract.IndexOf("*");
            //    if (targetIndex == -1)
            //    {
            //        // 完全一致
            //        salHisRefExtraParamWork.GoodsNameSrchTyp = 0;
            //        salHisRefExtraParamWork.GoodsName = strExtract;
            //    }
            //    else if (strExtract.StartsWith("*") && strExtract.EndsWith("*"))
            //    {
            //        // 曖昧検索
            //        salHisRefExtraParamWork.GoodsNameSrchTyp = 3;
            //        salHisRefExtraParamWork.GoodsName = strExtract.Replace("*", "");
            //    }
            //    else if (strExtract.EndsWith("*"))
            //    {
            //        // 前方一致
            //        salHisRefExtraParamWork.GoodsNameSrchTyp = 1;
            //        salHisRefExtraParamWork.GoodsName = strExtract.Replace("*", "");
            //    }
            //    else if (strExtract.StartsWith("*"))
            //    {
            //        // 後方一致
            //        salHisRefExtraParamWork.GoodsNameSrchTyp = 2;
            //        salHisRefExtraParamWork.GoodsName = strExtract.Replace("*", "");
            //    }
            //}
            //else
            //{
            //    salHisRefExtraParamWork.GoodsNameSrchTyp = 0;
            //    salHisRefExtraParamWork.GoodsName = string.Empty;
            //}

            ////品番
            //salHisRefExtraParamWork.GoodsNo = this.tEdit_GoodsNo.Text;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
            string searchText;
            int searchType;

            // 型式*
            // 2008.11.10 modify start [7543]
            if (!tEdit_FullModel.Text.Trim().Equals("*"))
            {
                GetSearchType(tEdit_FullModel.Text.Trim(), out searchText, out searchType);
                salHisRefExtraParamWork.FullModel = searchText;
                salHisRefExtraParamWork.FullModelSrchTyp = searchType;
            }

            // 品番*
            if (!tEdit_GoodsNo.Text.Trim().Equals("*"))
            {
                GetSearchType(tEdit_GoodsNo.Text.Trim(), out searchText, out searchType);
                salHisRefExtraParamWork.GoodsNo = searchText;
                salHisRefExtraParamWork.GoodsNoSrchTyp = searchType;
            }

            // 品名*
            if (!tEdit_GoodsName.Text.Trim().Equals("*"))
            {
                GetSearchType(tEdit_GoodsName.Text.Trim(), out searchText, out searchType);
                salHisRefExtraParamWork.GoodsName = searchText;
                salHisRefExtraParamWork.GoodsNameSrchTyp = searchType;
            }
            // 2008.11.10 modify end [7543]
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD

			//相手先注文番号
			//salHisRefExtraParamWork.OrderNumber = this.tEdit_OrderNumber.Text;

            //---ADD 2011/11/11 ---------------------------------------->>>>>
            if (this.tComboEditor_AutoAnswerDivSCM.SelectedIndex == 0)
            {
                //連携伝票出力区分
                salHisRefExtraParamWork.AutoAnswerDivSCM = 0;
                salHisRefExtraParamWork.AcceptOrOrderKind = -1;
            }
            else 
            {
                //連携伝票出力区分
                if (this.tComboEditor_AutoAnswerDivSCM.SelectedIndex == 1)
                {
                    salHisRefExtraParamWork.AutoAnswerDivSCM = 1;
                }
                else
                {
                    salHisRefExtraParamWork.AutoAnswerDivSCM = 2;
                }
                //連携伝票対象区分
                if (this.uCheckEditor_PccForNS.Checked == true && this.uCheckEditor_BlPaCOrder.Checked == false)
                {
                    salHisRefExtraParamWork.AcceptOrOrderKind = 0;
                }
                else if (this.uCheckEditor_PccForNS.Checked == false && this.uCheckEditor_BlPaCOrder.Checked == true)
                {
                    salHisRefExtraParamWork.AcceptOrOrderKind = 1;
                }
                else if (this.uCheckEditor_PccForNS.Checked == true && this.uCheckEditor_BlPaCOrder.Checked == true)
                {
                    salHisRefExtraParamWork.AcceptOrOrderKind = 2;
                }
                else
                {
                    salHisRefExtraParamWork.AcceptOrOrderKind = -1;
                }
            }
            //---ADD 2011/11/11 ----------------------------------------<<<<<

			this._inputDetails._salHisRefExtraParamWork = salHisRefExtraParamWork;
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

            nameList.Add("CustomerName", this.uLabel_CustomerName.Text);
            nameList.Add("StockAgentName", this.uLabel_SalesEmployeeName.Text);
            nameList.Add("SectionNm", this.uLabel_SectionNm.Text);
			nameList.Add("MakerName", this.uLabel_MakerName.Text);
			nameList.Add("PayeeSnm", this.uLabel_ClaimSnm.Text);
            //nameList.Add("GoodsName", this.uLabel_GoodsName.Text);
            return nameList;
        }

        /// <summary>
        /// 初期フォーカス設定処理
        /// </summary>
        public Control SetInitFocus(object sender)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/22 DEL
            //this.tComboEditor_SalesSlipCd.Focus();
            //return this.tComboEditor_SalesSlipCd;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/22 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/22 ADD
            tEdit_SectionCodeAllowZero.Focus();
            return tEdit_SectionCodeAllowZero;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/22 ADD
        }
       
        /// <summary>
        /// 画面終了処理
        /// </summary>
        public void CloseForm()
        {
            this.Close();
        }

        /// <summary>
        /// 入力項目チェック処理
        /// </summary>
        private Control CheckInputPara()
        {

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.17 TOKUNAGA DEL START
			//必須入力のチェック
			//伝票番号(開始-終了)
			//得意先
			//商品コード
            //if((tEdit_SalesSlipNum_St.DataText.Trim() == "")
            //&& (tEdit_SalesSlipNum_Ed.DataText.Trim() == "")
            //&& (tNedit_CustomerCode.GetInt() == 0)
            //&& (tEdit_GoodsCode.DataText.Trim() == ""))
            //{
            //    this.tEdit_SalesSlipNum_St.Focus();
            //    SetStatusBarMessage(this, MESSAGE_NoSelectInput);
            //    return tEdit_SalesSlipNum_St;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.17 TOKUNAGA DEL END

            // 必須入力のチェック
            // 伝票種別、伝票区分、売上日
            if (this.tComboEditor_SalesFormalCode.SelectedItem.DataValue.ToString() == "")
            {
                this.tComboEditor_SalesFormalCode.Focus();
                SetStatusBarMessage(this, MSG_SALESFORMALCODE_EMPTY);
                return tComboEditor_SalesFormalCode;
            }

            if (this.tComboEditor_SalesSlipCd.SelectedItem.DataValue.ToString() == "")
            {
                this.tComboEditor_SalesSlipCd.Focus();
                SetStatusBarMessage(this, MSG_SALESSLIPCD_EMPTY);
                return tComboEditor_SalesSlipCd;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
            //if (this.tDateEdit_SalesDateSt.LongDate == 0)
            //{
            //    this.tDateEdit_SalesDateSt.Focus();
            //    SetStatusBarMessage(this, MSG_SALESDATE_EMPTY);
            //    return tDateEdit_SalesDateSt;
            //}

            //if (this.tDateEdit_SalesDateEd.LongDate == 0)
            //{
            //    this.tDateEdit_SalesDateEd.Focus();
            //    SetStatusBarMessage(this, MSG_SALESDATE_EMPTY);
            //    return tDateEdit_SalesDateEd;
            //}
            
            //// 大小チェック
            //// 売上日
            //if (this.tDateEdit_SalesDateSt.LongDate > this.tDateEdit_SalesDateEd.LongDate)
            //{
            //    this.tDateEdit_SalesDateSt.Focus();
            //    SetStatusBarMessage(this, MESSAGE_StartEndError);
            //    return tDateEdit_SalesDateSt;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
#if False
            // 有効チェック
            DateTime retDateTime = new DateTime();

			// 開始売上日
            if (this.tDateEdit_SalesDateSt.LongDate == 0)
            {
                // 仕入形式が受託の場合は入力必須
                this.tDateEdit_SalesDateSt.Focus();
                SetStatusBarMessage(this, MESSAGE_NoInput);
				return tDateEdit_SalesDateSt;
            }
            else
            {
                if (DateTime.TryParse(this.tDateEdit_SalesDateSt.GetDateTimeString("yyyy.MM.DD"), out retDateTime) == false)
                {
                    this.tDateEdit_SalesDateSt.Focus();
                    SetStatusBarMessage(this, MESSAGE_InvalidDate);
					return tDateEdit_SalesDateSt;
                }
            }

			// 終了仕入日
            if (this.tDateEdit_SalesDateEd.LongDate == 0)
            {
                // 仕入形式が受託の場合は入力必須
                this.tDateEdit_SalesDateEd.Focus();
                SetStatusBarMessage(this, MESSAGE_NoInput);
				return tDateEdit_SalesDateEd;
            }
            else
            {
                if (DateTime.TryParse(this.tDateEdit_SalesDateEd.GetDateTimeString("yyyy.MM.DD"), out retDateTime) == false)
                {
                    this.tDateEdit_SalesDateEd.Focus();
                    SetStatusBarMessage(this, MESSAGE_InvalidDate);
					return tDateEdit_SalesDateEd;
                }
			}

			//入力日
			// 開始日のチェック(未入力許可)
			if ((this.tDateEdit_SearchSlipDateSt.CheckInputData() != null) || (!this.DateEditInputCheck(this.tDateEdit_SearchSlipDateSt, true)))
			{
				this.tDateEdit_SearchSlipDateSt.Focus();
				SetStatusBarMessage(this, MESSAGE_InvalidDate);
				return tDateEdit_SearchSlipDateSt;
			}
			// 終了日のチェック(未入力不可)
			else if (!this.DateEditInputCheck(this.tDateEdit_SearchSlipDateEd, false))
			{
				this.tDateEdit_SearchSlipDateEd.Focus();
				SetStatusBarMessage(this, MESSAGE_InvalidDate);
				return tDateEdit_SearchSlipDateEd;
			}
#endif
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
            //// 入力日：日付の範囲をチェック(開始日 > 終了日 → NG)
            //if (this.tDateEdit_SearchSlipDateSt.GetLongDate() > this.tDateEdit_SearchSlipDateEd.GetLongDate())
            //{
            //    this.tDateEdit_SearchSlipDateEd.Focus();
            //    SetStatusBarMessage(this, MESSAGE_StartEndError);
            //    return tDateEdit_SearchSlipDateEd;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
            string kbnNm = uLabel_Date1Title.Text;
            string errMessage = string.Empty;
            Control errComponent = null;
            DateGetAcs.CheckDateRangeResult cdrResult;

            // 売上日付（開始～終了）
            //if ( CallCheckDateRange( out cdrResult, ref tDateEdit_SalesDateSt, ref tDateEdit_SalesDateEd, false, 3 ) == false ) // DEL 2009/04/03
            if (CallCheckDateRangeAllowNoInput(out cdrResult, ref tDateEdit_SalesDateSt, ref tDateEdit_SalesDateEd) == false) // ADD 2009/04/03
            {
                switch (cdrResult)
                {
                    // --- DEL 2009/04/03 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                    //    {
                    //        errMessage = string.Format( "開始" + kbnNm + "{0}", ct_NoInput );
                    //        errComponent = this.tDateEdit_SalesDateSt;
                    //    }
                    //    break;
                    // --- DEL 2009/04/03 --------------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("開始" + kbnNm + "{0}", ct_InputError);
                            errComponent = this.tDateEdit_SalesDateSt;
                        }
                        break;
                    // --- DEL 2009/04/03 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                    //    {
                    //        errMessage = string.Format( "終了" + kbnNm + "{0}", ct_NoInput );
                    //        errComponent = this.tDateEdit_SalesDateEd;
                    //    }
                    //    break;
                    // --- DEL 2009/04/03 --------------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("終了" + kbnNm + "{0}", ct_InputError);
                            errComponent = this.tDateEdit_SalesDateEd;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        // --- ADD 2009/04/03 -------------------------------->>>>>
                        {
                            errMessage = string.Format(kbnNm + "{0}", ct_RangeError);
                            errComponent = this.tDateEdit_SalesDateSt;
                        }
                        break;
                    // --- ADD 2009/04/03 --------------------------------<<<<<
                    // --- DEL 2009/04/03 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnMonth:
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                    //    {

                    //        // 2008.11.18 modify start [7918]
                    //        //errMessage = string.Format( kbnNm + "{0}", ct_RangeError );
                    //        errMessage = string.Format(kbnNm + "{0}", ct_RangeOverError);
                    //        // 2008.11.18 modify end [7918]
                    //        errComponent = this.tDateEdit_SalesDateSt;
                    //    }
                    //    break;
                    // --- DEL 2009/04/03 --------------------------------<<<<<
                }

                errComponent.Focus();
                // 2008.12.03 modify start [7918]
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    errMessage, 0, MessageBoxButtons.OK);
                //SetStatusBarMessage( this, errMessage );
                // 2008.12.03 modify end [7918]
                return errComponent;

            }
            // 入力日付（開始～終了）,
            if ( CallCheckDateRangeAllowNoInput( out cdrResult, ref tDateEdit_SearchSlipDateSt, ref tDateEdit_SearchSlipDateEd ) == false )
            {
                switch ( cdrResult )
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format( "開始入力日{0}", ct_InputError );
                            errComponent = this.tDateEdit_SearchSlipDateSt;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format( "終了入力日{0}", ct_InputError );
                            errComponent = this.tDateEdit_SearchSlipDateEd;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format( "入力日{0}", ct_RangeError );
                            errComponent = this.tDateEdit_SearchSlipDateSt;
                        }
                        break;
                }
                errComponent.Focus();
                //SetStatusBarMessage( this, errMessage ); // DEL 2009/04/03
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    errMessage, 0, MessageBoxButtons.OK); // ADD 2009/04/03
                return errComponent;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD

            //伝票番号（開始-終了）
            if (
              (this.tEdit_SalesSlipNum_St.DataText.TrimEnd() != string.Empty) &&
              (this.tEdit_SalesSlipNum_Ed.DataText.TrimEnd() != string.Empty) &&
              (this.tEdit_SalesSlipNum_St.DataText.TrimEnd().CompareTo(this.tEdit_SalesSlipNum_Ed.DataText.TrimEnd()) > 0))
            {
                this.tEdit_SalesSlipNum_Ed.Focus();
                // 2008.11.10 modify start [7528]
                //SetStatusBarMessage(this, MESSAGE_StartEndError);
                // 2008.12.03 modify start [7918]
                //SetStatusBarMessage(this, MESSAGE_StartEndErrorSlipCd);
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    MESSAGE_StartEndErrorSlipCd, 0, MessageBoxButtons.OK);
                // 2008.12.03 modify end [7918]
                // 2008.11.10 modify end [7528]
                return tEdit_SalesSlipNum_Ed;

            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
            //// 入力支援
            //// 仕入日
            //AutoSetEndValue(this.tDateEdit_SalesDateSt,this.tDateEdit_SalesDateEd);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL

#if False
			// 拠点
			if(this.tEdit_SectionCd.Text.Trim() == "")
			{
                this.tEdit_SectionCd.Focus();
                SetStatusBarMessage(this, MESSAGE_NoInput);
				return tEdit_SectionCd;
			}
#endif
            
			// 仕入先
            //if (this.tNedit_CustomerCode.GetInt() == 0)
            //{
            //    this.tNedit_CustomerCode.Focus();
            //    SetStatusBarMessage(this, MESSAGE_NoInput);
            //    return tNedit_CustomerCode;
            //}
			return null;
        }

		#region ◎ 日付入力チェック処理
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
        ///// <summary>
        ///// 日付入力チェック処理
        ///// </summary>
        ///// <param name="targetDateEdit">チェック対象コントロール</param>
        ///// <param name="allowEmpty">未入力許可[true:許可, false:不許可]</param>
        ///// <returns>チェック結果(true/false)</returns>
        ///// <remarks>
        ///// <br>Note		: 日付入力のチェックを行う。</br>
        ///// <br>Programmer	: 96186 立花 裕輔</br>
        ///// <br>Date		: 2007.09.03</br>
        ///// </remarks>
        //private bool DateEditInputCheck(TDateEdit targetDateEdit, bool allowEmpty)
        //{
        //    bool status = true;

        //    // 入力日付を数値型で取得
        //    int date = targetDateEdit.GetLongDate();
        //    int yy = date / 10000;
        //    int mm = (date / 100) % 100;
        //    int dd = date % 100;

        //    // 日付未入力チェック
        //    if (targetDateEdit.GetDateTime() == DateTime.MinValue)
        //    {
        //        if (allowEmpty == true)
        //        {
        //            return status;
        //        }
        //        else
        //        {
        //            status = false;
        //        }
        //    }
        //    // システムサポートチェック
        //    else if (yy < 1900)
        //    {
        //        status = false;
        //    }
        //    // 年月日別入力チェック
        //    else if ((yy == 0) || (mm == 0) || (dd == 0))
        //    {
        //        status = false;
        //    }
        //    // 単純日付妥当性チェック
        //    else if (TDateTime.IsAvailableDate(targetDateEdit.GetDateTime()) == false)
        //    {
        //        status = false;
        //    }

        //    return status;
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_OrderDataCreateDate"></param>
        /// <param name="tde_Ed_OrderDataCreateDate"></param>
        /// <returns></returns>
        private bool CallCheckDateRange( out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St, ref TDateEdit tde_Ed, bool mode, int ym )
        {
            cdrResult = _dateGet.CheckDateRange( DateGetAcs.YmdType.YearMonth, ym, ref tde_St, ref tde_Ed, mode );
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        /// <summary>
        /// 日付チェック(未入力可能)
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St"></param>
        /// <param name="tde_Ed"></param>
        /// <param name="mode"></param>
        /// <param name="ym"></param>
        /// <returns></returns>
        private bool CallCheckDateRangeAllowNoInput( out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St, ref TDateEdit tde_Ed )
        {
            cdrResult = DateGetAcs.CheckDateRangeResult.OK;

            // 開始日
            if ( _dateGet.CheckDate( ref tde_St, true ) == DateGetAcs.CheckDateResult.ErrorOfInvalid )
            {
                cdrResult = DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid;
                return false;
            }
            // 終了日
            if ( _dateGet.CheckDate( ref tde_Ed, true ) == DateGetAcs.CheckDateResult.ErrorOfInvalid )
            {
                cdrResult = DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid;
                return false;
            }
            // 大小チェック
            if ( tde_St.GetLongDate() > 0 &&
                 tde_Ed.GetLongDate() > 0 &&
                 tde_St.GetDateTime() > tde_Ed.GetDateTime() )
            {
                cdrResult = DateGetAcs.CheckDateRangeResult.ErrorOfReverse;
                return false;
            }

            return true;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
		#endregion

        /// <summary>
        /// 伝票検索実行処理
        /// </summary>
        private Control SearchSlip()
        {
            // 入力項目チェック処理
            Control control = this.CheckInputPara();
            
			if (control != null)
			{
                return control;
            }

            SalHisRefExtraParamWork salHisRefExtraParamWork = new SalHisRefExtraParamWork();
            bool setEnable = false;

            // 読込条件パラメータクラス設定処理
            this.SetReadPara(out salHisRefExtraParamWork);

			// 伝票情報読込・データセット格納処理
			this._searchSlipAcs.SetSearchData(salHisRefExtraParamWork);
			
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

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
            this.ChangeDecisionButtonEnable( setEnable );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD

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
        private bool CheckSearchParam(SalHisRefExtraParamWork salHisRefExtraParamWork)
        {
            // 前回検索条件の取得
            SalHisRefExtraParamWork prevSearchParaStockSlip = this._searchSlipAcs.GetParaStockSlipCache();
            if (prevSearchParaStockSlip == null)
            {
                return false;
            }

            // 仕入形式
            if (salHisRefExtraParamWork.SupplierFormal != prevSearchParaStockSlip.SupplierFormal)
            {
                return false;
            }

            // 伝票区分
            if (salHisRefExtraParamWork.SupplierSlipCd != prevSearchParaStockSlip.SupplierSlipCd)
            {
                return false;
            }

            // 赤伝区分
            if (salHisRefExtraParamWork.DebitNoteDiv != prevSearchParaStockSlip.DebitNoteDiv)
            {
                return false;
            }

            // 商品区分
            if (salHisRefExtraParamWork.StockGoodsCd != prevSearchParaStockSlip.StockGoodsCd)
            {
                return false;
            }

            // 買掛区分
            if (salHisRefExtraParamWork.AccPayDivCd != prevSearchParaStockSlip.AccPayDivCd)
            {
                return false;
            }

            // 拠点
            if (salHisRefExtraParamWork.SectionCd != prevSearchParaStockSlip.StockSectionCd)
            {
                return false;
            }

            // 入荷日
            if ((salHisRefExtraParamWork.ArrivalGoodsDayStart != prevSearchParaStockSlip.ArrivalGoodsDayStart) ||
                (salHisRefExtraParamWork.ArrivalGoodsDayEnd != prevSearchParaStockSlip.ArrivalGoodsDayEnd))
            {
                return false;
            }

            // 計上日
            if ((salHisRefExtraParamWork.StockAddUpADateStart != prevSearchParaStockSlip.StockAddUpADateStart) ||
                (salHisRefExtraParamWork.StockAddUpADateEnd != prevSearchParaStockSlip.StockAddUpADateEnd))
            {
                return false;
            }

            // 仕入先
            if (salHisRefExtraParamWork.CustomerCode != prevSearchParaStockSlip.CustomerCode)
            {
                return false;
            }

            // 事業者
            //if (salHisRefExtraParamWork.CarrierEpCode != prevSearchParaStockSlip.CarrierEpCode)
            //{
            //    return false;
            //}

            // 仕入先担当
            if (salHisRefExtraParamWork.StockAgentCode != prevSearchParaStockSlip.StockAgentCode)
            {
                return false;
            }

            // 倉庫
            if (salHisRefExtraParamWork.WarehouseCode != prevSearchParaStockSlip.WarehouseCode)
            {
                return false;
            }

            // 相手先伝番
            if (salHisRefExtraParamWork.PartySaleSlipNum != prevSearchParaStockSlip.PartySaleSlipNum)
            {
                return false;
            }

			// 伝票番号
			if (salHisRefExtraParamWork.SupplierSlipNo != prevSearchParaStockSlip.SupplierSlipNo)
			{
				return false;
			}


            // 商品
            if (salHisRefExtraParamWork.GoodsNo!= prevSearchParaStockSlip.GoodsCode)
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
			this._decisionButton.SharedProps.Enabled = enableSet;
            // 2008.11.18 add start [7542]
            this._decisionButton.SharedProps.Visible = enableSet;
            // 2008.11.18 add end [7542]
			this._inputDetails.SetSelectBtn(enableSet);
        }

        # region 各コントロールイベント処理

        /// <summary>
        /// ツールバーボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note: 2010/06/08 楊明俊 障害・改良 </br>
        /// <br>            「クリア」ボタンを押したときのフォーカス位置を変更する。</br>
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
                        // キーはUndoだがボタン名はクリア(C)
                        this.ClearDisplayHeader();
                        this.SetDisplayHeaderInfo();
                        this._searchSlipAcs.ClearStockSlipDataTable();

                        // --- ADD 2010/06/08 ---------->>>>>
                        tEdit_SectionCodeAllowZero.Focus();
                        // --- ADD 2010/06/08 ----------<<<<<
                        break;
                    }
                case "ButtonTool_Search":
                    {
                        // 検索処理
                        SearchSlip();

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
            // 2008.11.12 modify start [7528]
            //this.uStatusBar_Main.Panels[0].Text = message;
            this.uStatusBar_Main.Panels["StatusBarPanel_Text"].Text = message;
            // 2008.11.12 modify end [7528]
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

			//if (e.PrevCtrl == this.tEdit_PartySaleSlipNum || e.PrevCtrl == this.tEdit_SupplierSlipNo)
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
            //if (e.PrevCtrl == this.tEdit_SalesSlipNum_St)
            //{
            //    e.NextCtrl = this.tEdit_GoodsNo;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
            //else if (e.NextCtrl.Parent == this.panel_Detail)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
            if (e.NextCtrl.Parent == this.panel_Detail)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
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
        /// <br>Update Note : 2015/05/08 gaocheng</br>
        /// <br>管理番号    : 11175085-00</br>
        /// <br>            : Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正</br>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            SetStatusBarMessage(this, "");

            // フォーカス制御 ============================================ //
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
            //if (
            //    //(e.PrevCtrl == this.tEdit_PartySaleSlipNum) ||
            //    (e.PrevCtrl == this.tEdit_SalesSlipNum_St)
            //    //||
            //    //(e.PrevCtrl == this.tEdit_SectionCd) ||
            //    //(e.PrevCtrl == this.uButton_SectionGuide)
            //    )
            //{
            //    if (e.Key == Keys.Down)
            //    {
            //        if (Detail_UGroupBox.Expanded == true)
            //        {
            //            e.NextCtrl = this.tEdit_GoodsNo;
            //        }
            //        else
            //        {
            //            e.NextCtrl = this._inputDetails.uGrid_Details; ;
            //        }
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL

            if (((e.PrevCtrl.Parent.Parent == this.Standard_UGroupBox) ||
                (e.PrevCtrl.Parent.Parent == this.Detail_UGroupBox)
				//|| (e.PrevCtrl.Parent.Parent == this.Select_UGroupBox)
				) &&
                ((e.NextCtrl.Parent == this.panel_Detail) ||
                 (e.NextCtrl == this._inputDetails.uGrid_Details)))
            {
                Control control = SearchSlip();
                if ((this._inputDetails.uGrid_Details.Rows.Count > 0) &&
                   (this._inputDetails.uGrid_Details.Enabled == true))
                {
                    e.NextCtrl = this._inputDetails.uGrid_Details;
                    // 2008.11.10 add start [7539]
                    this._inputDetails.uGrid_Details.ActiveRow = this._inputDetails.uGrid_Details.Rows[0];
                    // 2008.11.10 add end [7539]
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
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 DEL
            //// 入力支援 ============================================ //
            //// 売上日
            //if ((e.PrevCtrl == this.tDateEdit_SalesDateSt) ||
            //    (e.PrevCtrl == this.tDateEdit_SalesDateEd))
            //{
            //    AutoSetEndValue(this.tDateEdit_SalesDateSt,this.tDateEdit_SalesDateEd);
            //}

            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
            //// 入力日
            //if ((e.PrevCtrl == this.tDateEdit_SearchSlipDateSt) ||
            //    (e.PrevCtrl == this.tDateEdit_SearchSlipDateEd))
            //{
            //    AutoSetEndValue(this.tDateEdit_SearchSlipDateSt, this.tDateEdit_SearchSlipDateEd);
            //}
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 DEL

			// 名称取得 ============================================ //
            switch (e.PrevCtrl.Name)
			{
                #region 拠点
                //case "tComboEditor_SalesInpSecCd":
                case "tEdit_SectionCodeAllowZero":
					{
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
                        string sectionCodeZero = string.Empty;
                        UiSet uiset;
                        uiSetControl1.ReadUISet( out uiset, tEdit_SectionCodeAllowZero.Name );
                        if ( uiset != null )
                        {
                            sectionCodeZero = new string( '0', uiset.Column );
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA MODIFY START
                        // コンボエディタ－から通常の入力域＋文字列表示へ変更
                        bool canChangeFocus = true;
                        string code = this.tEdit_SectionCodeAllowZero.Text.Trim();
                        string name = this.SectionName_tEdit.Text.Trim();

                        // パラメータオブジェクトに保存されている拠点コードと現在の入力値を比較
                        if (this._paraStockSlipCache_Display.SectionCode.Trim() != code)
                        {
                            // 入力値が削除された場合はパラメータの中身を消去
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 DEL
                            //if (code == "")
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
                            if ( code == sectionCodeZero )
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD
                            {
                                this._paraStockSlipCache_Display.SectionCode = code;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 DEL
                                //name = "";
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
                                name = ct_AllSectionName;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD
                            }
                            else
                            {
                                // 拠点の名前を取得
                                SecInfoSet sectionInfo;
                                int status = this._secInfoSetAcs.Read( out sectionInfo, this._enterpriseCode, code );
                                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                {
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
                                    this._paraStockSlipCache_Display.SectionCode = code;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD
                                    name = sectionInfo.SectionGuideNm.TrimEnd();
                                }
                                else
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
                            }

                            // 拠点コード、名称をセット
                            this.tEdit_SectionCodeAllowZero.Text = this._paraStockSlipCache_Display.SectionCode;
                            this.SectionName_tEdit.Text = name;
                        }

                        //string code = this.tComboEditor_SalesInpSecCd.Value.ToString();

                        //if (code.Trim() != this._paraStockSlipCache_Display.SectionCode.Trim())
                        //{
                        //    this._paraStockSlipCache_Display.SectionCode = code;
							//para.SectionName = this._salesSlipSearchAcs.GetName_FromSecInfoSet(code);

							// 抽出条件の各種コントロールに値を設定する。
							//this.SetDisplayConditionInfo(para);
                        //}
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA MODIFY END

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
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
                                            if ( this.tEdit_SectionCodeAllowZero.Text.Trim().Length == 0 )
                                            {
                                                // 入力されていなければガイドボタンへ
                                                e.NextCtrl = this.SectionCodeGuide_ultraButton;
                                            }
                                            else
                                            {
                                                // 入力されており、かつ部署管理区分が「拠点」の場合は得意先へ
                                                if (this._secMngDiv == DIV_MNG_SECTION) // 2008.12.11 modify [8911]
                                                {
                                                    e.NextCtrl = this.tNedit_CustomerCode;
                                                }
                                                else
                                                {
                                                    // 部署管理区分が「拠点」以外の場合は部署入力欄へ
                                                    e.NextCtrl = this.tNedit_SubSectionCode;
                                                }
                                            }

                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
                            tEdit_SectionCodeAllowZero.SelectAll();
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END

						break;
                    }
                #endregion // 拠点

                #region 部署
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                case "tNedit_SubSectionCode":
                    {
                        bool canChangeFocus = true;
                        int code = this.tNedit_SubSectionCode.GetInt();
                        string name = this.tEdit_SubSectionName.Text.Trim();

                        // パラメータオブジェクトに保存されている部署コードと現在の入力値を比較
                        if (this._paraStockSlipCache_Display.SubSectionCode != code)
                        {
                            // 入力値が削除された場合はパラメータの中身を消去
                            if (code == 0)
                            {
                                this._paraStockSlipCache_Display.SubSectionCode = code;
                                name = "";
                            }
                            else
                            {
                                // 部署名を取得
                                SubSection subSection;
                                int status = this._subSectionAcs.Read(out subSection, this._enterpriseCode, this._dspSectionCode, code);
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
                                    this._paraStockSlipCache_Display.SubSectionCode = code;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD
                                    name = subSection.SubSectionName.TrimEnd();
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                          this,
                                          emErrorLevel.ERR_LEVEL_INFO,
                                          this.Name,
                                          "部署が存在しません。",
                                          -1,
                                          MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                            }

                            // 部署コード、名称をセット
                            this.tNedit_SubSectionCode.SetInt(this._paraStockSlipCache_Display.SubSectionCode);
                            this.tEdit_SubSectionName.Text = name;
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
                                            if (this.tNedit_SubSectionCode.Text.Trim().Length == 0)
                                            {
                                                // 入力されていなければガイドボタンへ
                                                e.NextCtrl = this.ultraButton_SubSectionGuide;
                                            }
                                            // else // DEL gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正
                                            else if (this.tNedit_CustomerCode.Enabled) // ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動
                                            {
                                                // 入力されていれば得意先へ
                                                e.NextCtrl = this.tNedit_CustomerCode;
                                            }
                                            //---- ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正 ---->>>>>
                                            else if (this.tNedit_ClaimCode.Enabled)
                                            {
                                                e.NextCtrl = this.tNedit_ClaimCode;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tComboEditor_SalesSlipCd;
                                            }
                                            //---- ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正 ----<<<<<
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
                            tNedit_SubSectionCode.SelectAll();
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END

                        break;
                    }
                #endregion // 部署

                #region 得意先
                case "tNedit_CustomerCode":
                    {
                        bool canChangeFocus = true;
                        int code = this.tNedit_CustomerCode.GetInt();
                        string name = this.uLabel_CustomerName.Text;

                        if (this._paraStockSlipCache_Display.CustomerCode != code)
                        {
                            if (code == 0)
                            {
                                this._paraStockSlipCache_Display.CustomerCode = code;
                                name = "";
                            }
                            else
                            {
                                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                                CustomerInfo customerInfo;
                                int status = customerInfoAcs.ReadDBData(this._enterpriseCode, code, out customerInfo);
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    if (((customerInfo.IsCustomer == true) || (customerInfo.IsReceiver == true)))
                                    {
                                        this._paraStockSlipCache_Display.CustomerCode = customerInfo.CustomerCode;
                                        name = customerInfo.Name;
                                    }
                                    else
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "仕入先は入力できません。",
                                            -1,
                                            MessageBoxButtons.OK);
                                        canChangeFocus = false;
                                    }
                                }
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当する得意先が存在しません。",
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
                                        "得意先の取得に失敗しました。",
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                            }

                            this.tNedit_CustomerCode.SetInt(this._paraStockSlipCache_Display.CustomerCode);
                            this.uLabel_CustomerName.Text = name;
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
                                            if (this.tNedit_CustomerCode.GetInt() == 0)
                                            {
                                                e.NextCtrl = this.uButton_StockCustomerGuide;
                                            }
                                            // else // DEL gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正
                                            else if (tNedit_ClaimCode.Enabled) // ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正
                                            {
                                                e.NextCtrl = this.tNedit_ClaimCode;
                                            }
                                            //---- ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正 ---->>>>>
                                            else
                                            {
                                                e.NextCtrl = tComboEditor_SalesFormalCode;
                                            }
                                            //---- ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正 ----<<<<<
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
                #endregion //得意先

                #region 請求先
                case "tNedit_ClaimCode":
                    {
                        bool canChangeFocus = true;
                        int code = this.tNedit_ClaimCode.GetInt();
                        string name = this.uLabel_ClaimSnm.Text;

                        if (this._paraStockSlipCache_Display.ClaimCode != code)
                        {
                            if (code == 0)
                            {
                                this._paraStockSlipCache_Display.ClaimCode = code;
                                name = "";
                            }
                            else
                            {
                                CustomerInfo customerInfo;
                                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                                int status = customerInfoAcs.ReadDBData(this._enterpriseCode, code, out customerInfo);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    if (((customerInfo.IsCustomer == true) || (customerInfo.IsReceiver == true)))
                                    {
                                        this._paraStockSlipCache_Display.ClaimCode = code;
                                        // 請求先コード・名称セット
                                        name = customerInfo.Name;
                                    }
                                    else
                                    {
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "仕入先は入力できません。",
                                            -1,
                                            MessageBoxButtons.OK);
                                        canChangeFocus = false;
                                    }

                                }
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "請求先が存在しません。",
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
                                        "請求先の取得に失敗しました。",
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                            }
                            this.tNedit_ClaimCode.SetInt(this._paraStockSlipCache_Display.ClaimCode);
                            this.uLabel_ClaimSnm.Text = name;
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
                                            if (this.tNedit_ClaimCode.GetInt() == 0)
                                            {
                                                e.NextCtrl = this.uButton_ClaimGuide;
                                            }
                                            else
                                            {
                                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA MODIFY START
                                                // 伝票種別へ
                                                //e.NextCtrl = this.tNedit_GoodsMakerCd;
                                                // e.NextCtrl = this.tComboEditor_SalesFormalCode; // DEL gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正
                                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA MODIFY END
                                                //---- ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正 ---->>>>>
                                                if (tComboEditor_SalesFormalCode.Enabled)
                                                {
                                                    e.NextCtrl = tComboEditor_SalesFormalCode;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = tComboEditor_SalesSlipCd;
                                                }
                                                //---- ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正 ----<<<<<
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
                #endregion //請求先

                #region 担当者
                case "tEdit_SalesEmployeeCd":
                    {
                        bool canChangeFocus = true;
                        string code = this.tEdit_SalesEmployeeCd.Text.Trim();
						string name = this.uLabel_SalesEmployeeName.Text;

                        if (this._paraStockSlipCache_Display.SalesEmployeeCd.Trim() != code)
                        {
                            if (code == "")
                            {
								this._paraStockSlipCache_Display.SalesEmployeeCd = code;
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
                                        "担当者が存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                                else
                                {
									this._paraStockSlipCache_Display.SalesEmployeeCd = code;
									name = nameTmp;
                                }
                            }
                            // 従業員コード・名称セット
							this.tEdit_SalesEmployeeCd.Text = this._paraStockSlipCache_Display.SalesEmployeeCd;
                            this.uLabel_SalesEmployeeName.Text = name;
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
											if (this.tEdit_SalesEmployeeCd.Text.Trim() == "")
											{
												e.NextCtrl = this.uButton_SalesEmployeeGuide;
											}
											else
											{
												e.NextCtrl = this.tEdit_SalesInputCode;
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
                #endregion // 担当者

                #region 発行者
                case "tEdit_SalesInputCode":
					{
						bool canChangeFocus = true;
						string code = this.tEdit_SalesInputCode.Text.Trim();
						string name = this.uLabel_SalesInputName.Text;

						if (this._paraStockSlipCache_Display.SalesInputCode.Trim() != code)
						{
							if (code == "")
							{
								this._paraStockSlipCache_Display.SalesInputCode = code;
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
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA MODIFY START
										//"入力者が存在しません。",
                                        "発行者が存在しません。",
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA MODIFY END
										-1,
										MessageBoxButtons.OK);

									canChangeFocus = false;
								}
								else
								{
									this._paraStockSlipCache_Display.SalesInputCode = code;
									name = nameTmp;
								}
							}
							// 従業員コード・名称セット
							this.tEdit_SalesInputCode.Text = this._paraStockSlipCache_Display.SalesInputCode;
							this.uLabel_SalesInputName.Text = name;
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
											if (this.tEdit_SalesInputCode.Text.Trim() == "")
											{
												e.NextCtrl = this.uButton_SalesInputGuide;
											}
											else
											{
                                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
                                                //e.NextCtrl = this.tNedit_CustomerCode;
                                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
                                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
                                                e.NextCtrl = tEdit_FrontEmployeeCd;
                                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
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
                #endregion // 発行者

                #region 受注者
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
                case "tEdit_FrontEmployeeCd":
                    {
                        bool canChangeFocus = true;
                        string code = this.tEdit_FrontEmployeeCd.Text.Trim();
                        string name = this.uLabel_FrontEmployeeName.Text;

                        if (this._paraStockSlipCache_Display.FrontEmployeeCd.Trim() != code)
                        {
                            if (code == "")
                            {
                                this._paraStockSlipCache_Display.FrontEmployeeCd = code;
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
                                        "受注者が存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                                else
                                {
                                    this._paraStockSlipCache_Display.FrontEmployeeCd = code;
                                    name = nameTmp;
                                }
                            }
                            // 従業員コード・名称セット
                            this.tEdit_FrontEmployeeCd.Text = this._paraStockSlipCache_Display.FrontEmployeeCd; // 既にセットしてあるものをもう一度セットする？
                            this.uLabel_FrontEmployeeName.Text = name;
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
                                            if (this.tEdit_FrontEmployeeCd.Text.Trim() == "")
                                            {
                                                // コードが入力されていなければガイドボタンへ
                                                e.NextCtrl = this.uButton_FrontEmployeeGuide;
                                            }
                                            else
                                            {
                                                // 入力されていればメーカーコード入力欄へ
                                                e.NextCtrl = this.tNedit_GoodsMakerCd;
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
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
                #endregion // 受注者

                #region メーカー
                case "tNedit_GoodsMakerCd":
					{
						bool canChangeFocus = true;
						int code = this.tNedit_GoodsMakerCd.GetInt();
						string name = this.uLabel_MakerName.Text;

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
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 DEL
                                    //this.uLabel_GoodsName.Text = "";
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 DEL
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
                                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
                                                //e.NextCtrl = this.tEdit_GoodsName;
                                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
                                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
                                                e.NextCtrl = this.tEdit_GoodsNo;
                                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
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
                #endregion //メーカー

                #region 品番
                case "tEdit_GoodsCode":
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 DEL
                        //bool canChangeFocus = true;
                        //string code = this.tEdit_GoodsNo.Text.Trim();
                        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 DEL
                        ////string name = this.uLabel_GoodsName.Text.Trim();
                        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 DEL
                        //int goodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
                        //string makerName = this.uLabel_MakerName.Text;

                        //if (this._paraStockSlipCache_Display.GoodsNo.Trim() != code)
                        //{
                        //    if (code == "")
                        //    {
                        //        this._paraStockSlipCache_Display.GoodsNo = code;
                        //        name = "";
                        //    }
                        //    else
                        //    {
                        //        string nameTmp = "";
                        //        int existFlg = this._searchSlipAcs.CheckGoodsExist(this, ref code, ref nameTmp, ref goodsMakerCd, ref makerName);

                        //        if (existFlg == 4)
                        //        {
                        //            TMsgDisp.Show(
                        //                this,
                        //                emErrorLevel.ERR_LEVEL_INFO,
                        //                this.Name,
                        //                "品名が存在しません。",
                        //                -1,
                        //                MessageBoxButtons.OK);

                        //            canChangeFocus = false;
                        //        }
                        //        else if (existFlg == 0)
                        //        {
                        //            this._paraStockSlipCache_Display.GoodsNo = code;
                        //            name = nameTmp;

                        //            this._paraStockSlipCache_Display.GoodsMakerCd = goodsMakerCd;
                        //        }
                        //    }
                        //    // 商品コード・名称セット
                        //    this.tEdit_GoodsNo.Text = this._paraStockSlipCache_Display.GoodsNo;
                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 DEL
                        //    //this.uLabel_GoodsName.Text = name;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 DEL

                        //    // メーカーコード・名称セット
                        //    this.tNedit_GoodsMakerCd.SetInt(this._paraStockSlipCache_Display.GoodsMakerCd);
                        //    this.uLabel_MakerName.Text = makerName;
                        //}

                        //// NextCtrl制御
                        //if (canChangeFocus)
                        //{
                        //    if (!e.ShiftKey)
                        //    {
                        //        switch (e.Key)
                        //        {
                        //            case Keys.Return:
                        //            case Keys.Tab:
                        //                {
                        //                    if (this.tEdit_GoodsNo.Text.Trim() == "")
                        //                    {
                        //                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 DEL
                        //                        //e.NextCtrl = this.uButton_GoodsGuide;
                        //                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 DEL
                        //                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD

                        //                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD
                        //                    }
                        //                    else
                        //                    {
                        //                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA MODIFY START
                        //                        // 拠点コードへ
                        //                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                        //                        //e.NextCtrl = this.tComboEditor_SalesSlipCd;
                        //                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA MODIFY END
                        //                    }
                        //                    break;
                        //                }
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    e.NextCtrl = e.PrevCtrl;
                        //}
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 DEL
                        break;
                    }
                #endregion // 品番
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
            // 特殊フォーカス制御
            _irrFocusCtrl.ReflectIrregularNextControl( e );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD

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

				//if (e.PrevCtrl == this.tEdit_PartySaleSlipNum || e.PrevCtrl == this.tEdit_SupplierSlipNo)
				if (e.PrevCtrl == this.tEdit_SalesSlipNum_St)
                {
                    //e.NextCtrl = this.tEdit_GoodsCode;
                }
                else if (e.NextCtrl.Parent == this.panel_Detail)
                {
                    Control control = SearchSlip();
                    
					if ((this._inputDetails.uGrid_Details.Rows.Count > 0) &&
                       (this._inputDetails.uGrid_Details.Enabled == true))
                    {
                        e.NextCtrl = this._inputDetails.uGrid_Details;
                        // 2008.11.10 add start [7539]
                        this._inputDetails.uGrid_Details.ActiveRow = this._inputDetails.uGrid_Details.Rows[0];
                        // 2008.11.10 add end [7539]
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
            // 2008.11.11 add start [7560]
            else if ((e.Key == Keys.Down) && (e.PrevCtrl == this.tEdit_GoodsName))
            {
                Control control = SearchSlip();

                if ((this._inputDetails.uGrid_Details.Rows.Count > 0) &&
                   (this._inputDetails.uGrid_Details.Enabled == true))
                {
                    e.NextCtrl = this._inputDetails.uGrid_Details;
                    // 2008.11.10 add start [7539]
                    this._inputDetails.uGrid_Details.ActiveRow = this._inputDetails.uGrid_Details.Rows[0];
                    // 2008.11.10 add end [7539]
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
            // 2008.11.11 add end [7560]
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
        ///// <summary>
        ///// 初期フォーカス設定タイマー起動イベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータクラス</param>
        //private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
        //{
        //    this.timer_InitialSetFocus.Enabled = false;

        //    this.SetInitFocus(this);
        //    this._inputDetails.uGrid_Details.Enabled = false;
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL

        /// <summary>
        /// フォーム終了イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void DCHNB04101UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = _dialogRes;
        }

#if False
        /// <summary>
        /// 拠点ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet;
            int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, this._mainOfficeFunc, out secInfoSet);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tEdit_SectionCd.Text = secInfoSet.SectionCode.Trim();
                uLabel_SectionNm.Text = secInfoSet.SectionGuideNm.Trim();
                this._paraStockSlipCache_Display.SectionCd = secInfoSet.SectionCode.Trim();
            }
        }
#endif

        /// <summary>
        /// 担当者ガイドボタンクリックイベント
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
                tEdit_SalesEmployeeCd.Text = employee.EmployeeCode.Trim();
                uLabel_SalesEmployeeName.Text = employee.Name.Trim();
				this._paraStockSlipCache_Display.SalesEmployeeCd = employee.EmployeeCode.Trim();
            }
        }

		/// <summary>
		/// 入力者ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_SalesInputGuide_Click(object sender, EventArgs e)
		{
			EmployeeAcs employeeAcs = new EmployeeAcs();
			Employee employee;
			int status = employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				tEdit_SalesInputCode.Text = employee.EmployeeCode.Trim();
				uLabel_SalesInputName.Text = employee.Name.Trim();
				this._paraStockSlipCache_Display.SalesInputCode = employee.EmployeeCode.Trim();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
                // 次フォーカス
                tEdit_FrontEmployeeCd.Focus();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD
			}
		}

        /// <summary>
        /// 得意先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note: 2015/05/08 gaocheng</br>
        /// <br>管理番号   : 11175085-00 </br>
        /// <br>           : Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正</br>  
        private void uButton_StockCustomerGuide_Click(object sender, EventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.15 TOKUNAGA MODIFY START
            // 得意先ガイド用ライブラリ名変更
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);	// 得意先検索アクセスクラス
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 DEL
            //customerSearchForm.ShowDialog(this);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
            DialogResult dialogResult = customerSearchForm.ShowDialog( this );
            if ( dialogResult == DialogResult.OK )
            {
                // 次フォーカス
                // tNedit_ClaimCode.Focus(); // DEL gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正
                //---- ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正 ---->>>>>
                if (tNedit_ClaimCode.Enabled)
                {
                    tNedit_ClaimCode.Focus();
                }
                else
                {
                    tComboEditor_SalesFormalCode.Focus();
                }
                //---- ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正 ----<<<<<
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.15 TOKUNAGA MODIFY END

            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_AND_EDIT);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            //customerSearchForm.ShowDialog(this);
		}

        ///// <summary>
        ///// 得意先ガイドボタンクリックイベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータクラス</param>
        //private void uButton_PayeeGuide_Click(object sender, EventArgs e)
        //{
        //    SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_AND_EDIT);
        //    customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.PayeeSearchForm_CustomerSelect);
        //    customerSearchForm.ShowDialog(this);
        //}

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
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
                //tNedit_GoodsMakerCd.Text = makerUMnt.GoodsMakerCd.ToString();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
                tNedit_GoodsMakerCd.SetInt( makerUMnt.GoodsMakerCd );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
				uLabel_MakerName.Text = makerUMnt.MakerName.Trim();
				this._paraStockSlipCache_Display.GoodsMakerCd = makerUMnt.GoodsMakerCd;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
                // 次フォーカス
                tEdit_GoodsNo.Focus();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD
			}
		}
#if False
        /// <summary>
        /// 倉庫ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_WarehouseGuide_Click(object sender, EventArgs e)
        {
			string selectedSectionCode = this.tEdit_SectionCd.Text;

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
			}
		}
#endif
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 DEL
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
        //        this.tEdit_GoodsCode.Text = this._paraStockSlipCache_Display.GoodsNo;
        //        this.uLabel_GoodsName.Text = goodsUnitData.GoodsName;
        //    }

        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 DEL

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 DEL
            //CustomerInfo customerInfo;
            ////CustSuppli custSuppli;
            //CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            ////int status = customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo, out custSuppli);
            //int status = customerInfoAcs.ReadDBData(this._enterpriseCode, customerSearchRet.CustomerCode, out customerInfo);

            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    if (((customerInfo.IsCustomer == true) || (customerInfo.IsReceiver == true)))
            //    {
            //    }
            //    else
            //    {
            //        TMsgDisp.Show(
            //            this,
            //            emErrorLevel.ERR_LEVEL_INFO,
            //            this.Name,
            //            "仕入先は入力できません。",
            //            -1,
            //            MessageBoxButtons.OK);
            //        return;
            //    }
            //}
            //else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            //{
            //    TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //        this.Name,
            //        "選択した得意先は既に削除されています。",
            //        status,
            //        MessageBoxButtons.OK);

            //    return;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 DEL

            this.tNedit_CustomerCode.SetInt(customerSearchRet.CustomerCode);
            this.uLabel_CustomerName.Text = customerSearchRet.Name;
            this._paraStockSlipCache_Display.CustomerCode = customerSearchRet.CustomerCode;
        }

		/// <summary>
		/// 請求先選択時発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
		private void PayeeSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
		{
			if (customerSearchRet == null) return;

			CustomerInfo customerInfo;
			//CustSuppli custSuppli;
			CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

			//int status = customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo, out custSuppli);
			int status = customerInfoAcs.ReadDBData(this._enterpriseCode, customerSearchRet.CustomerCode, out customerInfo);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				if (((customerInfo.IsCustomer == true) || (customerInfo.IsReceiver == true)))
				{
				}
				else
				{
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_INFO,
						this.Name,
						"仕入先は入力できません。",
						-1,
						MessageBoxButtons.OK);
					return;
				}
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"選択した支払先は既に削除されています。",
					status,
					MessageBoxButtons.OK);

				return;
			}
			this.tNedit_ClaimCode.SetInt(customerSearchRet.CustomerCode);
			this.uLabel_ClaimSnm.Text = customerSearchRet.Name;
			this._paraStockSlipCache_Display.ClaimCode = customerSearchRet.CustomerCode;
		}

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

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.17 TOKUNAGA ADD START

        #region ■伝票種別コンボエディタ

        /// <summary>
        /// 伝票種別コンボエディタ ValueChangedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>伝票種別の選択を変更時に、伝票区分の選択肢を変更する</remarks>
        private void tComboEditor_SalesFormalCode_ValueChanged(object sender, EventArgs e)
        {
            int code = Convert.ToInt32(this.tComboEditor_SalesFormalCode.Value);

            //伝票区分を設定
            SetSalesSlipCdComboEditor(ref tComboEditor_SalesSlipCd, code);

            SetLabalNameSearchCondDate((int)tComboEditor_SalesFormalCode.Value);
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/10 ADD
        /// <summary>
        /// 伝票種別コンボエディタ SelectionChangeCommittedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_SalesFormalCode_SelectionChangeCommitted( object sender, EventArgs e )
        {
            int code = Convert.ToInt32( this.tComboEditor_SalesFormalCode.Value );

            //伝票区分を設定
            SetSalesSlipCdComboEditor( ref tComboEditor_SalesSlipCd, code );

            SetLabalNameSearchCondDate( (int)tComboEditor_SalesFormalCode.Value );
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/10 ADD

        //---ADD 2011/11/11 ----------------------------------->>>>>
        /// <summary>
        /// 連携伝票出力区分コンボエディタ ValueChangedイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void tComboEditor_AutoAnswerDivSCM_ValueChanged(object sender, EventArgs e)
        {
            if (this.tComboEditor_AutoAnswerDivSCM.SelectedIndex != 0)
            {
                this.uCheckEditor_PccForNS.Enabled = true;
                this.uCheckEditor_BlPaCOrder.Enabled = true;
            }
            else
            {
                this.uCheckEditor_PccForNS.Enabled = false;
                this.uCheckEditor_BlPaCOrder.Enabled = false;
                this.uCheckEditor_PccForNS.Checked = false;
                this.uCheckEditor_BlPaCOrder.Checked = false;
            }
        }
        //---ADD 2011/11/11 -----------------------------------<<<<<

        /// <summary>
        /// 伝票区分コンボエディタリスト設定処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="salesFormalCode"></param>
        public void SetSalesSlipCdComboEditor(ref TComboEditor sender, int salesFormalCode)
        {
            Infragistics.Win.ValueList valueList = new Infragistics.Win.ValueList();

            Infragistics.Win.ValueListItem secInfoItemM1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem secInfoItem0 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem secInfoItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem secInfoItem100 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem secInfoItem101 = new Infragistics.Win.ValueListItem();

            switch (salesFormalCode)
            {
                //10,15:見積,30:売上,40:出荷,90:全て
                case 10:
                case 15:
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
                //case 16:
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                    //全て
                    secInfoItemM1.DataValue = -1;
                    secInfoItemM1.DisplayText = "全て";
                    valueList.ValueListItems.Add(secInfoItemM1);
                　　//掛売上
                    secInfoItem0.DataValue = 0;
                    secInfoItem0.DisplayText = "掛売上";
                    valueList.ValueListItems.Add(secInfoItem0);
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/10 ADD
                    //現金売上
                    secInfoItem100.DataValue = 100;
                    secInfoItem100.DisplayText = "現金売上";
                    valueList.ValueListItems.Add( secInfoItem100 );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/10 ADD
                    break;
                //case 20:
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
                case 20:
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
                case 30:
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/10 ADD
                case 40:
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/10 ADD
                case -1:
                    //全て
                    secInfoItemM1.DataValue = -1;
                    secInfoItemM1.DisplayText = "全て";
                    valueList.ValueListItems.Add(secInfoItemM1);
                    //掛売上
                    secInfoItem0.DataValue = 0;
                    secInfoItem0.DisplayText = "掛売上";
                    valueList.ValueListItems.Add(secInfoItem0);
                    //掛返品
                    secInfoItem1.DataValue = 1;
                    secInfoItem1.DisplayText = "掛返品";
                    valueList.ValueListItems.Add(secInfoItem1);
                    //現金売上
                    secInfoItem100.DataValue = 100;
                    secInfoItem100.DisplayText = "現金売上";
                    valueList.ValueListItems.Add(secInfoItem100);
                    //現金返品
                    secInfoItem101.DataValue = 101;
                    secInfoItem101.DisplayText = "現金返品";
                    valueList.ValueListItems.Add(secInfoItem101);
                    break;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/10 DEL
                //case 40:
                //    //掛売上
                //    secInfoItem0.DataValue = 0;
                //    secInfoItem0.DisplayText = "掛売上";
                //    valueList.ValueListItems.Add(secInfoItem0);
                //    //掛返品
                //    secInfoItem1.DataValue = 1;
                //    secInfoItem1.DisplayText = "掛返品";
                //    valueList.ValueListItems.Add(secInfoItem1);
                //    break;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/10 DEL
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/24 ADD
            if ( salesFormalCode == 40 )
            {
                tComboEditor_AddUpRemDiv.Enabled = true;
            }
            else
            {
                tComboEditor_AddUpRemDiv.Enabled = false;
                tComboEditor_AddUpRemDiv.SelectedIndex = 0;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/24 ADD

            if (valueList != null)
            {
                sender.Items.Clear();

                for (int i = 0; i < valueList.ValueListItems.Count; i++)
                {
                    //sender.Items.Add(valueList.ValueListItems[i]);

                    Infragistics.Win.ValueListItem vlltem = new Infragistics.Win.ValueListItem();
                    vlltem.Tag = valueList.ValueListItems[i].Tag;
                    vlltem.DataValue = valueList.ValueListItems[i].DataValue;
                    vlltem.DisplayText = valueList.ValueListItems[i].DisplayText;
                    sender.Items.Add(vlltem);
                }

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
                //sender.MaxDropDownItems = valueList.ValueListItems.Count;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL

                sender.Value = 0;
            }
        }

        /// <summary>
        /// 日付検索のラベル名称を設定
        /// </summary>
        /// <param name="cd"></param>
        private void SetLabalNameSearchCondDate(int cd)
        {
            switch (cd)
            {
                //10,15:見積,30:売上,40:出荷,90:全て
                case 10:
                case 15:
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
                //case 16:
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                    uLabel_Date1Title.Text = "見積日";
                    // 請求先を使用不能に
                    tNedit_ClaimCode.Enabled = false;
                    uButton_ClaimGuide.Enabled = false;
                    tNedit_ClaimCode.Clear();
                    uLabel_ClaimSnm.Text = "";
                    break;

                //case 20:
                //    uLabel_Date1Title.Text = "受注日";
                //    // 請求先を使用可能に
                //    tNedit_ClaimCode.Enabled = true;
                //    uButton_ClaimGuide.Enabled = true;
                //    break;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
                case 20:
                    uLabel_Date1Title.Text = "受注日";
                    // 請求先を使用可能に
                    tNedit_ClaimCode.Enabled = true;
                    uButton_ClaimGuide.Enabled = true;
                    break;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
                case 30:
                    uLabel_Date1Title.Text = "売上日";
                    // 請求先を使用可能に
                    tNedit_ClaimCode.Enabled = true;
                    uButton_ClaimGuide.Enabled = true;
                    break;

                case 40:
                    uLabel_Date1Title.Text = "貸出日";//出荷日";
                    // 請求先を使用可能に
                    tNedit_ClaimCode.Enabled = true;
                    uButton_ClaimGuide.Enabled = true;
                    break;
                case -1:
                    uLabel_Date1Title.Text = "日付";
                    // 請求先を使用可能に
                    tNedit_ClaimCode.Enabled = true;
                    uButton_ClaimGuide.Enabled = true;
                    break;
            }
        }

        #endregion // ■伝票種別コンボエディタ

        /// <summary>
        /// 請求先選択ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note : 2015/05/08 gaocheng</br>
        /// <br>管理番号    : 11175085-00</br>
        /// <br>            : Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正</br>
        private void uButton_ClaimGuide_Click(object sender, EventArgs e)
        {
            // 請求先ガイド表示
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/22 DEL
            //PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_RECEIVER, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/22 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/22 ADD
            PMKHN04005UA customerSearchForm = new PMKHN04005UA( PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/22 ADD
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.PayeeSearchForm_CustomerSelect);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 DEL
            //customerSearchForm.ShowDialog(this);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
            DialogResult dialogResult = customerSearchForm.ShowDialog( this );
            if ( dialogResult == DialogResult.OK )
            {
                // 次フォーカス
                // tComboEditor_SalesFormalCode.Focus(); // DEL gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正
                //---- ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正 ---->>>>>
                if (tComboEditor_SalesFormalCode.Enabled)
                {
                    tComboEditor_SalesFormalCode.Focus();
                }
                else
                {
                    tComboEditor_SalesSlipCd.Focus();
                }
                //---- ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正 ----<<<<<
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD
        }

        /// <summary>
        /// 拠点ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SectionCodeGuide_ultraButton_Click(object sender, EventArgs e)
        {
            SecInfoSet sectionInfo;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 DEL
            //int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out sectionInfo);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
            int status = this._secInfoSetAcs.ExecuteGuid( this._enterpriseCode, true, out sectionInfo );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_SectionCodeAllowZero.Text = sectionInfo.SectionCode.TrimEnd();
                this._paraStockSlipCache_Display.SectionCode = sectionInfo.SectionCode.TrimEnd();
                this.SectionName_tEdit.Text = sectionInfo.SectionGuideNm.TrimEnd();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
                // 次フォーカス
                if ( tNedit_SubSectionCode.Enabled && tNedit_SubSectionCode.Visible )
                {
                    tNedit_SubSectionCode.Focus();
                }
                else
                {
                    tNedit_CustomerCode.Focus();
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD
            }
            else
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 DEL
                //this.tEdit_SectionCodeAllowZero.Clear();
                //this.SectionName_tEdit.Clear();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 DEL
            }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 DEL
        ///// <summary>
        ///// 拠点入力欄Leaveイベント処理
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void tEdit_SectionCodeAllowZero_Leave(object sender, EventArgs e)
        //{
        //    string sectionCode = this.tEdit_SectionCodeAllowZero.Text;

        //    if (!String.IsNullOrEmpty(sectionCode))
        //    {
        //        SecInfoSet sectionInfo;
        //        int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);
        //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            this.SectionName_tEdit.Text = sectionInfo.SectionGuideNm.TrimEnd();
        //            this._paraStockSlipCache_Display.SectionCode = sectionCode;
        //        }
        //    }
        //    else
        //    {
        //        this.tEdit_SectionCodeAllowZero.Clear();
        //    }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 DEL

        /// <summary>
        /// 部署ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note: 2015/05/08 gaocheng</br>
        /// <br>管理番号   : 11175085-00 </br>
        /// <br>           : Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正</br>  
        private void ultraButton_SubSectionGuide_Click(object sender, EventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 DEL
            //// 拠点コードが選択されている必要がある
            //if ( this.tEdit_SectionCodeAllowZero.Text.Trim().Length == 0 ) return;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 DEL

            SubSection subSection;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 DEL
            //int status = this._subSectionAcs.ExecuteGuid( out subSection, this._enterpriseCode, this.tEdit_SectionCodeAllowZero.Text.Trim() );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
            // 2008.11.11 del start [7530]
            //string sectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim();
            //try
            //{
            //    int sectionCodeInt = Int32.Parse( sectionCode );
            //    if ( sectionCodeInt == 0 )
            //    {
            //        sectionCode = string.Empty;
            //    }
            //}
            //catch
            //{
            //    sectionCode = string.Empty;
            //}
            // 2008.11.11 del end [7530]

            // 2008.11.11 modify start [7530]
            //int status = this._subSectionAcs.ExecuteGuid( out subSection, this._enterpriseCode, sectionCode );
            int status = this._subSectionAcs.ExecuteGuid(out subSection, this._enterpriseCode);
            // 2008.11.11 modify end [7530]

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SubSectionCode.SetInt(subSection.SubSectionCode);
                this._paraStockSlipCache_Display.SubSectionCode = subSection.SubSectionCode;
                this.tEdit_SubSectionName.Text = subSection.SubSectionName.TrimEnd();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
                // 次フォーカス
                // tNedit_CustomerCode.Focus(); // DEL gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動
                //---- ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正 ---->>>>>
                if (tNedit_CustomerCode.Enabled) // ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動
                {
                    tNedit_CustomerCode.Focus();
                }
                else if (tNedit_ClaimCode.Enabled)
                {
                    tNedit_ClaimCode.Focus();
                }
                else
                {
                    tComboEditor_SalesSlipCd.Focus();
                }
                //---- ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正 ----<<<<<
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD
            }
            else
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 DEL
                //this.tNedit_SubSectionCode.Clear();
                //this.tEdit_SubSectionName.Clear();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 DEL
            }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 DEL
        ///// <summary>
        ///// 部署コード入力欄Leaveイベント処理
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void tNedit_SubSectionCode_Leave(object sender, EventArgs e)
        //{
        //    // 拠点コードが選択されている必要がある
        //    if ( this.tEdit_SectionCodeAllowZero.Text.Trim().Length == 0 ) return;

        //    string subSectionCode = this.tNedit_SubSectionCode.Text;

        //    if (!String.IsNullOrEmpty(subSectionCode))
        //    {
        //        SubSection subSection;
        //        int status = this._subSectionAcs.Read(out subSection, this._enterpriseCode, this._dspSectionCode, int.Parse(subSectionCode));
        //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            this.tNedit_SubSectionCode.Text = subSection.SubSectionName.TrimEnd();
        //            this._paraStockSlipCache_Display.SubSectionCode = int.Parse(subSectionCode);
        //        }
        //    }
        //    else
        //    {
        //        this.tNedit_SubSectionCode.Clear();
        //        this.tEdit_SubSectionName.Clear();
        //    }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 DEL

        /// <summary>
        /// 担当者ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SalesEmployeeGuide_Click(object sender, EventArgs e)
        {
            EmployeeAcs employeeAcs = new EmployeeAcs();
            Employee employee;
            int status = employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tEdit_SalesEmployeeCd.Text = employee.EmployeeCode.Trim();
                uLabel_SalesEmployeeName.Text = employee.Name.Trim();
                this._paraStockSlipCache_Display.SalesEmployeeCd = employee.EmployeeCode.Trim();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
                // 次フォーカス
                tEdit_SalesInputCode.Focus();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD
            }
        }

        /// <summary>
        /// 受注者ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_FrontEmployeeGuide_Click(object sender, EventArgs e)
        {
            EmployeeAcs employeeAcs = new EmployeeAcs();
            Employee employee;
            int status = employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tEdit_FrontEmployeeCd.Text = employee.EmployeeCode.Trim();
                uLabel_FrontEmployeeName.Text = employee.Name.Trim();
                this._paraStockSlipCache_Display.FrontEmployeeCd = employee.EmployeeCode.Trim();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
                if ( Detail_UGroupBox.Expanded == true )
                {
                    tNedit_GoodsMakerCd.Focus();
                }
                else
                {
                    _inputDetails.Focus();
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD
            }
        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.17 TOKUNAGA ADD END
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
        /// <summary>
        /// 前回月次締処理日取得
        /// </summary>
        /// <returns></returns>
        private DateTime GetPrevTotalDayNextDay( string sectionCode )
        {
            DateTime prevTotalDay;
            int status = _totalDayCalculator.GetHisTotalDayMonthlyAccRec( sectionCode.Trim(), out prevTotalDay );

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
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
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
        /// フォーム表示イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DCHNB04101UA_Shown( object sender, EventArgs e )
        {
            try
            {
                // 描画停止　＞＞＞
                this.SuspendLayout();

                if ( _autoSearch )
                {
                    // 検索処理
                    SearchDataForInitialSearch();
                    //_inputDetails.Focus();
                }
                else
                {
                    this._inputDetails.uGrid_Details.Enabled = false;
                    tEdit_SectionCodeAllowZero.Focus();
                }
            }
            finally
            {
                // 描画再開　＜＜＜
                this.ResumeLayout();
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

            // 条件セット(UI入力項目にセットして表示処理を兼ねる)
            # region [DisplayCondition]

            // 拠点
            if ( this.SectionCode != null && this.SectionCode.Trim() != string.Empty )
            {
                tEdit_SectionCodeAllowZero.Text = this.SectionCode;
                SectionName_tEdit.Text = this.SectionName;
            }
            tNedit_SubSectionCode.SetInt( this.SubSectionCode );
            tEdit_SubSectionName.Text = this.SubSectionName;

            // 得意先
            tNedit_CustomerCode.SetInt( this.CustomerCode );
            uLabel_CustomerName.Text = this.CustomerName;
            if ( this.CustomerCodeFix )
            {
                tNedit_CustomerCode.Enabled = false;
                uButton_StockCustomerGuide.Enabled = false;
            }

            // 請求先
            tNedit_ClaimCode.SetInt( this.ClaimCode );
            uLabel_ClaimSnm.Text = this.ClaimName;
            // 売上日
            if ( this.SalesDate != DateTime.MinValue )
            {
                tDateEdit_SalesDateSt.SetDateTime( this.SalesDate );
                tDateEdit_SalesDateEd.SetDateTime( this.SalesDate );
            }
            // 担当者
            tEdit_SalesEmployeeCd.Text = this.SalesEmployeeCd;
            uLabel_SalesEmployeeName.Text = this.SalesEmployeeName;
            // 発行者
            tEdit_SalesInputCode.Text = this.SalesInputCode;
            uLabel_SalesInputName.Text = this.SalesInputName;
            // 受注者
            tEdit_FrontEmployeeCd.Text = this.FrontEmployeeCd;
            uLabel_FrontEmployeeName.Text = this.FrontEmployeeName;

            // 2008.11.27 add start [8286]

            // 品番
            this.tEdit_GoodsNo.Text = this.GoodsNo;

            // メーカー
            this.tNedit_GoodsMakerCd.SetInt(this.GoodsMakerCd);
            this.uLabel_MakerName.Text = this.GoodsMakerName;

            // 2008.11.27 add end [8286]

            // 受注ステータス
            try
            {
                tComboEditor_SalesFormalCode.Value = this.AcptAnOdrStatus;
                SetSalesSlipCdComboEditor( ref tComboEditor_SalesSlipCd, (int)tComboEditor_SalesFormalCode.Value );
            }
            catch
            {
                tComboEditor_SalesFormalCode.SelectedIndex = 0;
            }
            if ( this.AcptAnOdrStatusFix )
            {
                tComboEditor_SalesFormalCode.Enabled = false;
            }

            // 伝票区分
            try
            {
                tComboEditor_SalesSlipCd.Value = this.SalesSlipCd;
            }
            catch
            {
                tComboEditor_SalesSlipCd.SelectedIndex = 0;
            }
            if ( this.SalesSlipCdFix )
            {
                tComboEditor_SalesSlipCd.Enabled = false;
            }

            // 出荷区分
            try
            {
                tComboEditor_AddUpRemDiv.Value = this.AddUpRemDiv;
            }
            catch
            {
                tComboEditor_AddUpRemDiv.SelectedIndex = 0;
            }
            if ( this.AddUpRemDivFix )
            {
                tComboEditor_AddUpRemDiv.Enabled = false;
            }

            # endregion

            if ( !_completeInitialSearch )
            {
                //------------------------------------------------
                // SearchDataせずにAutoSearchモードで起動された場合
                // (実際は未使用)
                //------------------------------------------------
                this._searchSlipAcs.ClearStockSlipDataTable();

                // 検索実行
                SearchSlip();
            }
            else
            {
                //------------------------------------------------
                // SearchDataの後でAutoSearchモードで起動された場合
                //------------------------------------------------
                bool setEnable = this._inputDetails.SetGridEnable();
                if ( setEnable == true )
                {
                    this._inputDetails.uGrid_Details.Focus();
                    this._inputDetails.timer_GridSetFocus.Enabled = true;
                }
                else
                {
                }
                this.ChangeDecisionButtonEnable( setEnable );
            }
        }

        /// <summary>
        /// 他ＰＧからの検索実行処理
        /// </summary>
        /// <returns></returns>
        public bool SearchData()
        {
            // クリア
            this._searchSlipAcs.ClearStockSlipDataTable();

            SalHisRefExtraParamWork paraWork = new SalHisRefExtraParamWork();
            # region [paraWork]
            // 企業コード
            paraWork.EnterpriseCode = _enterpriseCode;

            // 拠点
            if ( this.SectionCode != null && this.SectionCode.Trim() != string.Empty )
            {
                paraWork.SectionCode = this.SectionCode;
            }
            else
            {
                paraWork.SectionCode = this._loginSectionCode;
            }

            // 部門
            paraWork.SubSectionCode = this.SubSectionCode;
            // 得意先
            paraWork.CustomerCode = this.CustomerCode;
            // 請求先
            paraWork.ClaimCode = this.ClaimCode;
            // 売上日
            if ( this.SalesDate != DateTime.MinValue )
            {
                int longDate = GetLongDate( this.SalesDate );
                paraWork.SalesDateSt = longDate;
                paraWork.SalesDateEd = longDate;
            }
            else
            {
                paraWork.SalesDateSt = GetLongDate( GetPrevTotalDayNextDay( _loginSectionCode ) );
                paraWork.SalesDateEd = GetLongDate( DateTime.Today );
            }
            // 担当者
            paraWork.SalesEmployeeCd = this.SalesEmployeeCd;
            // 発行者
            paraWork.SalesInputCode = this.SalesInputCode;
            // 受注者
            paraWork.FrontEmployeeCd = this.FrontEmployeeCd;

            // 受注ステータス
            if ( this.AcptAnOdrStatus != 0 )
            {
                paraWork.AcptAnOdrStatus = this.AcptAnOdrStatus;
            }
            else
            {
                paraWork.AcptAnOdrStatus = 30; // 30:売上
            }

            // 伝票区分
            switch(this.SalesSlipCd)
            {
                case 0:
                    paraWork.SalesSlipCd = 0;
                    paraWork.AccRecDivCd = 1;
                    break;
                case 1:
                    paraWork.SalesSlipCd = 1;
                    paraWork.AccRecDivCd = 1;
                    break;
                case 100:
                    paraWork.SalesSlipCd = 0;
                    paraWork.AccRecDivCd = 0;
                    break;
                case 101:
                    paraWork.SalesSlipCd = 1;
                    paraWork.AccRecDivCd = 0;
                    break;
                default:
                    paraWork.SalesSlipCd = 0;
                    paraWork.AccRecDivCd = 1;
                    break;
            }
            // 出荷区分
            paraWork.AddUpRemDiv = this.AddUpRemDiv;

            // 2008.11.27 add start [8286]

            // 品番
            paraWork.GoodsNo = this.GoodsNo;

            // メーカーコード
            paraWork.GoodsMakerCd = this.GoodsMakerCd;

            // 2008.11.27 add end [8286]

            # endregion

            // 伝票情報読込・データセット格納処理
            this._searchSlipAcs.SetSearchData( paraWork );

            // Shownの自動検索解除
            _completeInitialSearch = true;

            // データ有無判断
            return this._inputDetails.SetGridEnable();

        }
        /// <summary>
        /// 日付数値取得
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static int GetLongDate( DateTime date )
        {
            if ( date == DateTime.MinValue )
            {
                return 0;
            }
            else
            {
                return ((date.Year * 10000) + (date.Month * 100) + date.Day);
            }
        }

        /// <summary>
        /// 拠点コードフォーカス進入イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_SectionCodeAllowZero_Enter( object sender, EventArgs e )
        {
            // "tEdit_SectionCode"を指定してゼロ詰め解除する
            tEdit_SectionCodeAllowZero.Text = this.uiSetControl1.GetZeroPadCanceledText( "tEdit_SectionCode", tEdit_SectionCodeAllowZero.Text );
        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD

        // 2008.11.10 add start [7533]

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
        // 2008.11.10 add start [7533]
        // ADD 2009/12/04 MANTIS対応[14743]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
        /// <summary>
        /// 売上履歴照会フォームのFormClosingイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void DCHNB04101UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_disposed) return;

            // FIXME:グリッド列の表示設定を保存
            GridSettings.DetailColumnsList = SlipGridUtil.CreateColumnInfoList(this._inputDetails.DetailGrid);
            SlipGridUtil.StoreGridSettings(GridSettings, XML_FILE_NAME);
        }
       // ADD 2009/12/04 MANTIS対応[14743]：伝票および明細グリッド列の列設定の変更 ----------<<<<<
    }
}
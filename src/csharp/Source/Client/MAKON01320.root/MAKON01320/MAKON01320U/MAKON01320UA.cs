//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 仕入伝票照会
// プログラム概要   : 仕入伝票照会を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/04/09  修正内容 : 障害対応13014
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434 工藤
// 作 成 日  2009/12/04  修正内容 : 障害対応14744
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
    using GridSettingsType = SlipGridSettings;  // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更

	public partial class MAKON01320UA : Form
    {
        // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
        #region グリッドの設定情報

        /// <summary>FIXME:グリッド情報XMLファイル名</summary>
        private const string XML_FILE_NAME = "DCKOU04000U_Construction.XML";

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
        // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ----------<<<<<

        #region コンストラクタ

        public MAKON01320UA()
		{
			InitializeComponent();

			// 変数初期化
			this._searchSlipAcs = SearchSlipAcs.GetInstance();
            this._supplierAcs = new SupplierAcs(); // ADD 2008.04.24
			this._dataSet = _searchSlipAcs.DataSet;
			this._imageList16 = IconResourceManagement.ImageList16;
			this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
			this._decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"];
			this._undoButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Undo"];
			this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];
			this._controlScreenSkin = new ControlScreenSkin();

			this._paraStockSlipCache_Display = new SearchParaStockSlip();
			if (this._searchSlipAcs.GetParaStockSlipCache() != null)
			{
				this._paraStockSlipCache_Display = this._searchSlipAcs.GetParaStockSlipCache();
			}

            // DEL 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
            //this._inputDetails = new MAKON01320UB();
            // DEL 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ----------<<<<<
            // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
			this._inputDetails = new MAKON01320UB(GridSettings);
            // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ----------<<<<<
			this._inputDetails.StatusBarMessageSetting += new MAKON01320UB.SettingStatusBarMessageEventHandler(this.SetStatusBarMessage);
			this._searchSlipAcs.StatusBarMessageSetting += new SearchSlipAcs.SettingStatusBarMessageEventHandler(this.SetStatusBarMessage);
			this._inputDetails.CloseMain += new MAKON01320UB.CloseMainEventHandler(this.CloseForm);
			this._inputDetails.SetMainDialogResult += new MAKON01320UB.SetDialogResEventHandler(this.SetDialogRes);
			this._inputDetails.DecisionButtonEnableSet += new MAKON01320UB.SettingDecisionButtonEnableEventHandler(this.ChangeDecisionButtonEnable);
			this._searchSlipAcs.GetNameList += new SearchSlipAcs.GetNameListEventHandler(this.GetDisplayNameList);

            // 2008.11.10 add start [5382]
            if (!string.IsNullOrEmpty(this._sectionCode))
            {
                this.tEdit_SectionCd.Text = this._sectionCode.Trim().PadLeft(2, '0');

                if (!string.IsNullOrEmpty(this._sectionName))
                {
                    this.uLabel_SectionNm.Text = this._sectionName;
                }
            }
            // 2008.11.10 add end [5382]

            this._companyAcs = new CompanyInfAcs();
		}

		public MAKON01320UA(int startMovment) : this()
		{
			this._inputDetails.StartMovment = startMovment;
			if(startMovment == 1)
			{
				ChangeDecisionButtonEnable(false);
			}
        }

        public MAKON01320UA(string defaultSectionCd) : this()
        {
            this.tEdit_SectionCd.Text = defaultSectionCd.PadLeft(2, '0');


            // 2008.11.07 add start [7285]
            _extractSlipCdType = 0;

            // --- DEL 2009/01/23 -------------------------------->>>>>
            //Infragistics.Win.ValueListItem item;

            //this.tComboEditor_SupplierSlipCd.Items.Clear();

            //// 全て
            //item = new Infragistics.Win.ValueListItem(99, "全て");
            //item.Tag = 1;
            //this.tComboEditor_SupplierSlipCd.Items.Add(item);

            //// 掛仕入
            //item = new Infragistics.Win.ValueListItem(10, "掛仕入");
            //item.Tag = 2;
            //this.tComboEditor_SupplierSlipCd.Items.Add(item);

            //// 掛返品
            //item = new Infragistics.Win.ValueListItem(20, "掛返品");
            //item.Tag = 3;
            //this.tComboEditor_SupplierSlipCd.Items.Add(item);

            //// 現金仕入
            //item = new Infragistics.Win.ValueListItem(30, "現金仕入");
            //item.Tag = 4;
            //this.tComboEditor_SupplierSlipCd.Items.Add(item);

            //// 現金返品
            //item = new Infragistics.Win.ValueListItem(40, "現金返品");
            //item.Tag = 5;
            //this.tComboEditor_SupplierSlipCd.Items.Add(item);
            // --- DEL 2009/01/23 --------------------------------<<<<<

            // 2008.11.07 add end [7285]
        }

        // 2008.11.07 add start [7285]

        /// <summary>
        /// 伝票区分コンボエディタの調整機能付きコンストラクタ
        /// </summary>
        /// <param name="defaultSectionCd"></param>
        /// <param name="extractSlipCdType"></param>
        public MAKON01320UA(ExtractSlipCdType extractSlipCdType)
            : this()
        {
            // 環境変数に保存
            this._extractSlipCdType = (int)extractSlipCdType;

            // --- DEL 2009/01/23 -------------------------------->>>>>
            //Infragistics.Win.ValueListItem item;

            //// 伝票区分の抽出条件により、伝票区分コンボの内容を調整
            //switch (_extractSlipCdType)
            //{
            //    // 全て
            //    case 0:
            //        {
            //            this.tComboEditor_SupplierSlipCd.Items.Clear();

            //            // 全て
            //            item = new Infragistics.Win.ValueListItem(99, "全て");
            //            item.Tag = 1;
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item);

            //            // 掛仕入
            //            item = new Infragistics.Win.ValueListItem(10, "掛仕入");
            //            item.Tag = 2;
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item);

            //            // 掛返品
            //            item = new Infragistics.Win.ValueListItem(20, "掛返品");
            //            item.Tag = 3;
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item);

            //            // 現金仕入
            //            item = new Infragistics.Win.ValueListItem(30, "現金仕入");
            //            item.Tag = 4;
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item);

            //            // 現金返品
            //            item = new Infragistics.Win.ValueListItem(40, "現金返品");
            //            item.Tag = 5;
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item);
            //        }
            //        break;
            //    // 仕入
            //    case 1:
            //        {
            //            this.tComboEditor_SupplierSlipCd.Items.Clear();

            //            // 全て
            //            item = new Infragistics.Win.ValueListItem(99, "全て");
            //            item.Tag = 1;
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item);

            //            // 掛仕入
            //            item = new Infragistics.Win.ValueListItem(10, "掛仕入");
            //            item.Tag = 2;
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item);

            //            // 現金仕入
            //            item = new Infragistics.Win.ValueListItem(30, "現金仕入");
            //            item.Tag = 4;
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item);
            //        }
            //        break;
            //    // 返品
            //    case 2:
            //        {
            //            this.tComboEditor_SupplierSlipCd.Items.Clear();

            //            // 全て
            //            item = new Infragistics.Win.ValueListItem(99, "全て");
            //            item.Tag = 1;
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item);

            //            // 掛返品
            //            item = new Infragistics.Win.ValueListItem(20, "掛返品");
            //            item.Tag = 3;
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item);

            //            // 現金返品
            //            item = new Infragistics.Win.ValueListItem(40, "現金返品");
            //            item.Tag = 5;
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item);
            //        }
            //        break;
            //    // それ以外は何もしない
            //    default: break;
            //}
            // --- DEL 2009/01/23 --------------------------------<<<<<
        }

        /// <summary>
        /// 伝票区分コンボエディタの調整機能付きコンストラクタ
        /// </summary>
        /// <param name="defaultSectionCd"></param>
        /// <param name="extractSlipCdType"></param>
        public MAKON01320UA(string defaultSectionCd, ExtractSlipCdType extractSlipCdType) : this()
        {
            this.tEdit_SectionCd.Text = defaultSectionCd.PadLeft(2, '0');

            // 環境変数に保存
            this._extractSlipCdType = (int)extractSlipCdType;

            // --- DEL 2009/01/23 -------------------------------->>>>>
            //Infragistics.Win.ValueListItem item;
            
            //// 伝票区分の抽出条件により、伝票区分コンボの内容を調整
            //switch (_extractSlipCdType)
            //{
            //    // 全て
            //    case 0:
            //        {
            //            this.tComboEditor_SupplierSlipCd.Items.Clear();

            //            // 全て
            //            item = new Infragistics.Win.ValueListItem(99, "全て");
            //            item.Tag = 1;
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item);

            //            // 掛仕入
            //            item = new Infragistics.Win.ValueListItem(10, "掛仕入");
            //            item.Tag = 2;
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item);

            //            // 掛返品
            //            item = new Infragistics.Win.ValueListItem(20, "掛返品");
            //            item.Tag = 3;
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item);

            //            // 現金仕入
            //            item = new Infragistics.Win.ValueListItem(30, "現金仕入");
            //            item.Tag = 4;
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item);

            //            // 現金返品
            //            item = new Infragistics.Win.ValueListItem(40, "現金返品");
            //            item.Tag = 5;
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item);
            //        }
            //        break;
            //    // 仕入
            //    case 1:
            //        {
            //            this.tComboEditor_SupplierSlipCd.Items.Clear();
                        
            //            // 全て
            //            item = new Infragistics.Win.ValueListItem(99, "全て");
            //            item.Tag = 1;
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item);

            //            // 掛仕入
            //            item = new Infragistics.Win.ValueListItem(10, "掛仕入");
            //            item.Tag = 2;
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item);

            //            // 現金仕入
            //            item = new Infragistics.Win.ValueListItem(30, "現金仕入");
            //            item.Tag = 4;
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item);
            //        }
            //        break;
            //    // 返品
            //    case 2:
            //        {
            //            this.tComboEditor_SupplierSlipCd.Items.Clear();

            //            // 全て
            //            item = new Infragistics.Win.ValueListItem(99, "全て");
            //            item.Tag = 1;
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item);

            //            // 掛返品
            //            item = new Infragistics.Win.ValueListItem(20, "掛返品");
            //            item.Tag = 3;
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item);

            //            // 現金返品
            //            item = new Infragistics.Win.ValueListItem(40, "現金返品");
            //            item.Tag = 5;
            //            this.tComboEditor_SupplierSlipCd.Items.Add(item);
            //        }
            //        break;
            //    // それ以外は何もしない
            //    default: break;
            //}
            // --- DEL 2009/01/23 --------------------------------<<<<<
        }

        // 2008.11.07 add end [7285]

        #endregion // コンストラクタ

        #region プライベート変数

        // アクセスクラス
        private SearchSlipAcs _searchSlipAcs;                                   // 伝票呼び出し
        private SecInfoSetAcs _secInfoSetAcs = new SecInfoSetAcs();
        private WarehouseAcs _warehouseAcs = new WarehouseAcs();
        private SupplierAcs _supplierAcs = new SupplierAcs();                   // ADD 2008.04.24
        private DateGetAcs _dateGetAcs = DateGetAcs.GetInstance();              // ADD 2009/04/03

        // 検索条件クラス
        private SearchParaStockSlip _paraStockSlipCache_Display;

        // 明細データセット
        private StockDataSet _dataSet;
        private MAKON01320UB _inputDetails;

        private string _enterpriseCode;                                         // 企業コード
        private string _loginSectionCode;                                       // 自拠点コード
        private bool _optSection;                                               // 拠点オプション有無フラグ
        private bool _mainOfficeFunc;                                           // 本社/拠点判断フラグ
        private ImageList _imageList16 = null;									// イメージリスト

        // メニューボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;		// 終了ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _decisionButton;	// 確定ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _undoButton;		// 取消ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;		// 検索ボタン
        
        private ControlScreenSkin _controlScreenSkin;
        private DialogResult _dialogRes = DialogResult.Cancel;
        private int _defaultsupplierFormal = 0;

        // メッセージ定数
        private const string MESSAGE_StartEndError = "開始≦終了となるよう設定してください。";
        private const string MESSAGE_NoInput = "必須入力項目です。";
        private const string MESSAGE_InvalidDate = "有効な日付ではありません。";

        // 2008.11.17 add start [7912]
        //private const string MESSAGE_RangeOverError = "は３ヶ月の範囲内で入力して下さい"; // DEL 2009/04/03
        // 2008.11.17 add end [7912]
        // 締め日設定
        private DateTime _prevTotalDay;
        private DateTime _currentTotalDay;
        private DateTime _prevTotalMonth;
        private DateTime _currentTotalMonth;

        /// <summary>伝票区分抽出形式 0:全て 1:仕入 2:返品</summary>
        private int _extractSlipCdType = 0;

        /// <summary>外部からの受取用拠点コード</summary>
        private string _sectionCode = string.Empty;

        /// <summary>外部からの受取用拠点名称</summary>
        private string _sectionName = string.Empty;

        private CompanyInfAcs _companyAcs;
        int _secMngDiv;

        #endregion // プライベート変数

        #region パブリックメソッド

        /// <summary>
        /// 呼出制御処理
        /// </summary>
        /// <param name="owner">呼出元オブジェクト</param>
        /// <param name="carrierCode">キャリアコード</param>
        public DialogResult ShowDialog(IWin32Window owner, int supplierFormal)
        {
            this._defaultsupplierFormal = supplierFormal;
            return this.ShowDialog(owner);
        }

        /// <summary>
        /// 選択伝票データ取得プロパティ
        /// </summary>
        public SearchRetStockSlip searchRetStockSlip
        {
            get { return this._inputDetails._searchRetStockSlip; }
        }

		/// <summary>
		/// プロパティ
		/// </summary>
		public bool TComboEditor_SupplierFormal
		{
			get {return this.tComboEditor_SupplierFormal.Enabled; }
			set {this.tComboEditor_SupplierFormal.Enabled = value;}

        }

        // 2008.11.10 add start [5382]

        /// <summary>
        /// 拠点コード受け取り用プロパティ
        /// </summary>
        public string SectionCode
        {
            get { return this._sectionCode; }
            set { this._sectionCode = value; }
        }

        /// <summary>
        /// 拠点名称受け取り用プロパティ
        /// </summary>
        public string SectionName
        {
            get { return this._sectionName; }
            set { this._sectionName = value; }
        }

        // 2008.11.10 add end [5382]


        #endregion // パブリックメソッド

        #region プライベートメソッド

        /// <summary>
        /// フォームロード処理
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
            //excCtrlNm.Add(this.Detail_UGroupBox.Name);
            this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);
            this._controlScreenSkin.SettingScreenSkin(this._inputDetails);

            // MAKON01320UB を、panel_Detailを親としたコントロールにする
            this.panel_Detail.Controls.Add(this._inputDetails);
			this._inputDetails.Dock = DockStyle.Fill;

            //　企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 自拠点コードを取得する
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            // 拠点オプション有無を取得する
            this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);
            // 本社/拠点情報を取得する
            // 2008.12.25 [9571]
            //this._mainOfficeFunc = this._searchSlipAcs.IsMainOfficeFunc();
            this._mainOfficeFunc = true;    // 本社機能限定
            // 2008.12.25 [9571]

            // ボタン初期設定処理
			this.ButtonInitialSetting();

            // 画面初期情報設定処理
            this.SetInitialInput();

			// 元に戻す処理（初期値設定など）
			this.ClearDisplayHeader();
			this.SetDisplayHeaderInfo();
			this._searchSlipAcs.ClearStockSlipDataTable();

            // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
            // FIXME:列移動と列固定を可能とする
            SlipGridUtil.EnableAllowColSwappingAndFixedHeaderIndicator(this._inputDetails.SlipGrid);
            // FIXME:グリッド列の設定を取込
            SlipGridUtil.LoadColumnInfo(this._inputDetails.SlipGrid, GridSettings.SlipColumnsList);
            // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ----------<<<<<

            this.tEdit_SectionCd.Focus();
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

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.10.27 TOKUNAGA ADD START
            // 締め日取得処理

            // 自拠点の前回締め日情報を取得
            TotalDayCalculator tCalcAcs = TotalDayCalculator.GetInstance();
            // 締日取得前初期処理
            int status = tCalcAcs.InitializeHisMonthlyAccRec();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 今回および前回の締め日/月を取得(月と日は異なる場合がある)
                status = tCalcAcs.GetHisTotalDayMonthlyAccRec(this._loginSectionCode, out _prevTotalDay, out _currentTotalDay, out _prevTotalMonth, out _currentTotalMonth);
            }

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.10.27 TOKUNAGA ADD END

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
        }
		
        /// <summary>
        /// 画面ヘッダクリア処理
        /// </summary>
        private void ClearDisplayHeader()
        {

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.21 TOKUNAGA ADD START
            this.tEdit_SectionCd.Clear();                   // 拠点コード
            this.uLabel_SectionNm.Text = "";                // 拠点名

            this.tNedit_SubSectionCode.Clear();
            this.uLabel_SubSectionName.Text = "";

			this.tNedit_SupplierCd.Clear();               // 仕入先コード
            this.uLabel_CustomerName.Text = "";             // 仕入先名

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.21 TOKUNAGA ADD START
            this.tNedit_PayeeCode.Clear();                  // 支払先コード
            this.uLabel_PayeeName.Text = "";                // 支払先名
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.21 TOKUNAGA ADD END

            this.tComboEditor_SupplierFormal.SelectedIndex = 0;       // 伝票種別
            this.tComboEditor_SupplierSlipCd.SelectedIndex = -1;      // 伝票区分
            //this.tComboEditor_DebitNoteDiv.SelectedIndex = -1;        // 赤伝区分
            //this.tComboEditor_StockGoodsCd.SelectedIndex = -1;        // 商品区分

            this.tDateEdit_Date2Start.Clear();              // 仕入日(開始)
            this.tDateEdit_Date2End.Clear();                // 仕入日(終了)
            this.tDateEdit_Date1Start.Clear();              // 入力日(開始)
            this.tDateEdit_Date1End.Clear();                // 入力日(終了)

            this.tEdit_SupplierSlipNoStart.Clear();	        // 仕入SEQ番号(開始)
            this.tEdit_SupplierSlipNoEnd.Clear();	        // 仕入SEQ番号(終了)
            this.tEdit_PartySaleSlipNum.Clear();            // 伝票番号（相手先）

            this.tEdit_StockAgentCode.Clear();              // 担当者名
            this.uLabel_StockAgentName.Text = "";           // 担当者名
			
            //this.tEdit_GoodsCode.Clear();                   // 商品コード
			//uLabel_Date1Set();								// 表示名称設定（仕入日・入荷日）

            this.ChangeDecisionButtonEnable(false);

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.21 TOKUNAGA ADD END

            this.timer_InitialSetFocus.Enabled = true;

        }

        /// <summary>
        /// 画面ヘッダ表示処理
        /// </summary>
        private void SetDisplayHeaderInfo()
        {
            // コンボボックス項目初期表示
            this.tComboEditor_SupplierFormal.SelectedIndex = this._defaultsupplierFormal;
			this.tComboEditor_SupplierSlipCd.SelectedIndex = 0;
            //this.tComboEditor_DebitNoteDiv.SelectedIndex = 0;
            //this.tComboEditor_StockGoodsCd.SelectedIndex = 0;

            // 日付項目初期表示
            if (this._prevTotalDay == DateTime.MinValue)
            {
                // 2008.11.07 modify start [7284]
                // 締め日が設定されていない（初期値：空白～当日）
                //     ↓
                // 締め日が設定されていない（初期値：当日より３か月前+1日～当日）
                this.tDateEdit_Date1Start.SetDateTime(DateTime.Today.AddMonths(-3).AddDays(1));
                this.tDateEdit_Date1End.SetDateTime(DateTime.Today);
                // 2008.11.07 modify end [7284]

                //this.tDateEdit_Date1Start.SetDateTime(DateTime.Today.AddMonths(-1));
                //this.tDateEdit_Date1End.SetDateTime(DateTime.Today);

                // 入力日（初期値：空白）
                //this.tDateEdit_Date2Start.SetDateTime(DateTime.Today.AddMonths(-1));
                //this.tDateEdit_Date2End.SetDateTime(DateTime.Today);

                //this.tDateEdit_Date1Start.SetDateTime(DateTime.MinValue);
                
            }
            else
            {
                // 但し、（前回月次処理日＋１日）＞（当日）の時、終了売上日＝（前回月次処理日＋１日）とします。
                if (this._prevTotalDay.AddDays(1).CompareTo(DateTime.Now) > 0)
                {
                    this.tDateEdit_Date1Start.SetDateTime(this._prevTotalDay.AddDays(1)); // 前回締処理日 + 1
                    this.tDateEdit_Date1End.SetDateTime(this._prevTotalDay.AddDays(1)); // 前回締処理日 + 1
                }
                else
                {
                    this.tDateEdit_Date1Start.SetDateTime(this._prevTotalDay.AddDays(1)); // 前回締処理日 + 1
                    this.tDateEdit_Date1End.SetDateTime(DateTime.Now); // 当日
                }
            }

            // 拠点設定
            // 2008.11.10 modify start [5382]
            if (string.IsNullOrEmpty(this._sectionCode))
            {
                // 2008.11.17 modify start [7912]
                this.tEdit_SectionCd.Text = this._loginSectionCode.Trim();
                //this.tEdit_SectionCd.Text = this._loginSectionCode;
                // 2008.11.17 modify end [7912]

                SecInfoSet secInfoSet;
                int status = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, this._loginSectionCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.uLabel_SectionNm.Text = secInfoSet.SectionGuideNm;
                }
            }
            else
            {
                this.tEdit_SectionCd.Text = this._sectionCode.Trim().PadLeft(2, '0');
                this.uLabel_SectionNm.Text = this._sectionName;
            }
            // 2008.11.10 modify end [5382]
        }

        /// <summary>
        /// 拠点 表示切替処理
        /// </summary>
        private void ChangeSectionDisplay(bool visible,bool enabled)
        {
            this.uLabel_SectionTitle.Visible = visible;
            this.tEdit_SectionCd.Visible = visible;
            this.uLabel_SectionNm.Visible = visible;
            this.uButton_SectionGuide.Visible = visible;

            this.uLabel_SectionTitle.Enabled = enabled;
            this.tEdit_SectionCd.Enabled = enabled;
            this.uLabel_SectionNm.Enabled = enabled;
            this.uButton_SectionGuide.Enabled = enabled;
        }

        /// <summary>
        /// 前回起動ヘッダ情報設定処理
        /// </summary>
        private void SetPrevHeader()
        {
            SearchParaStockSlip searchParaStockSlip = this._searchSlipAcs.GetParaStockSlipCache();

            if(searchParaStockSlip == null)
            {
                return;
            }

            SortedList nameList = this._searchSlipAcs.GetCacheNmaeList();

			if (nameList == null)
			{
				return;
			}

			this.tComboEditor_SupplierFormal.SelectedIndex = searchParaStockSlip.SupplierFormal;            // 伝票種別
            this.tComboEditor_SupplierSlipCd.SelectedIndex = ConvertComboEditorIndex(searchParaStockSlip.SupplierSlipCd);    // 伝票区分
            //this.tComboEditor_DebitNoteDiv.SelectedIndex = ConvertComboEditorIndex(searchParaStockSlip.DebitNoteDiv);        // 赤伝区分
            //this.tComboEditor_StockGoodsCd.SelectedIndex = ConvertComboEditorIndex(searchParaStockSlip.StockGoodsCd);        // 商品区分

			// UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //this.tNedit_SupplierCd.SetInt(searchParaStockSlip.CustomerCode);                            // 仕入先コード
            this.tNedit_SupplierCd.SetInt(searchParaStockSlip.SupplierCd);
            // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            if (nameList.Contains("CustomerName"))
            {
                this.uLabel_CustomerName.Text = nameList["CustomerName"].ToString();                        // 仕入先名
            }

			this.tDateEdit_Date1Start.SetLongDate(searchParaStockSlip.StockDateSt);                         // 仕入日(開始)
            this.tDateEdit_Date1End.SetLongDate(searchParaStockSlip.StockDateEd);                           // 仕入日(終了)
			this.tDateEdit_Date2Start.SetLongDate(searchParaStockSlip.InputDaySt);                          // 入力日(開始)
            this.tDateEdit_Date2End.SetLongDate(searchParaStockSlip.InputDayEd);                            // 入力日(終了)

            this.tEdit_StockAgentCode.Text = searchParaStockSlip.StockAgentCode;                            // 担当者コード
            if (nameList.Contains("StockAgentName"))
            {
                this.uLabel_StockAgentName.Text = nameList["StockAgentName"].ToString();                    // 担当者名
            }
            this.tEdit_PartySaleSlipNum.Text = searchParaStockSlip.PartySaleSlipNum;                        // 伝票番号
            this.tEdit_SupplierSlipNoStart.Text = searchParaStockSlip.SupplierSlipNoSt.ToString();          // 仕入SEQ番号(開始)
            this.tEdit_SupplierSlipNoEnd.Text = searchParaStockSlip.SupplierSlipNoEd.ToString();            // 仕入SEQ番号(終了)

			this.tEdit_SectionCd.Text = searchParaStockSlip.StockSectionCd;                                 // 拠点コード

			SecInfoSet secInfoSet = new SecInfoSet();
			int status = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, this._loginSectionCode);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				this.uLabel_SectionNm.Text = secInfoSet.SectionGuideNm;                                     // 拠点名
			}

            //this.tEdit_GoodsCode.Text = searchParaStockSlip.GoodsCode;                              // 商品コード
            //this.uLabel_GoodsName.Text = nameList["GoodsName"].ToString();                          // 商品名
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
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.21 TOKUNAGA MODIFY START
			this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
			this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
			this._decisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
			this._undoButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;

			this.uButton_EmployeeGuide.ImageList = this._imageList16;
			this.uButton_StockCustomerGuide.ImageList = this._imageList16;
            this.uButton_PayeeCodeGuide.ImageList = this._imageList16;
            this.uButton_SectionGuide.ImageList = this._imageList16;
            //this.uButton_GoodsGuide.ImageList = this._imageList16;
			//this.uButton_GoodsMakerGuide.ImageList = this._imageList16;

            this.uButton_EmployeeGuide.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_StockCustomerGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_PayeeCodeGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
            //this.uButton_GoodsGuide.Appearance.Image = (int)Size16_Index.STAR1;
			//this.uButton_GoodsMakerGuide.Appearance.Image = (int)Size16_Index.STAR1;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.21 TOKUNAGA MODIFY END
            this.uButton_SubSectionGuide.ImageList = this._imageList16;
            this.uButton_SubSectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
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

        #endregion // プライベートメソッド

        /// <summary>
        /// 読込条件パラメータ設定処理
        /// </summary>
        /// </return> 読込条件パラメータクラス
        public bool SetReadPara(out SearchParaStockSlip searchParaStockSlip)
        {
            searchParaStockSlip = new SearchParaStockSlip();

			// 企業コード
            searchParaStockSlip.EnterpriseCode = this._enterpriseCode;

			// 伝票種別
            searchParaStockSlip.SupplierFormal = this.ValueToInt(this.tComboEditor_SupplierFormal.Value);

			// 赤伝区分
            //searchParaStockSlip.DebitNoteDiv = this.ValueToInt(this.tComboEditor_DebitNoteDiv.Value);
            //項目が画面から削除されたため99をセット
            searchParaStockSlip.DebitNoteDiv = 99;

			// 仕入商品区分
            //searchParaStockSlip.StockGoodsCd = this.ValueToInt(this.tComboEditor_StockGoodsCd.Value);
            //項目が画面から削除されたため99をセット
            searchParaStockSlip.StockGoodsCd = 99;

			// 仕入伝票区分
			// 買掛区分
			int _supplierSlipCd = this.ValueToInt(this.tComboEditor_SupplierSlipCd.Value);
			switch (_supplierSlipCd)
			{
				case 10:
					searchParaStockSlip.SupplierSlipCd = 10;
					searchParaStockSlip.AccPayDivCd = 1;
					break;
				case 20:
					searchParaStockSlip.SupplierSlipCd = 20;
					searchParaStockSlip.AccPayDivCd = 1;
					break;
				case 30:
					searchParaStockSlip.SupplierSlipCd = 10;
					searchParaStockSlip.AccPayDivCd = 0;
					break;
				case 40:
					searchParaStockSlip.SupplierSlipCd = 20;
					searchParaStockSlip.AccPayDivCd = 0;
					break;
				default:
                    // 2008.11.07 modify start [7285]
                    // 全てが選択されたとき、伝票区分抽出形式により渡す値が異なる
                    switch (_extractSlipCdType)
                    {
                        // 全て
                        case 0:
                            searchParaStockSlip.SupplierSlipCd = 99;
                            break;
                        // 仕入
                        case 1:
                            searchParaStockSlip.SupplierSlipCd = 10;
                            break;
                        // 入荷
                        case 2:
                            searchParaStockSlip.SupplierSlipCd = 20;
                            break;
                        default: break;
                    }
                    // 2008.11.07 modify end [7285]
                    searchParaStockSlip.AccPayDivCd = 99;

					break;
			}

			// 仕入担当者コード
            searchParaStockSlip.StockAgentCode = this.tEdit_StockAgentCode.Text;

			// 伝票番号
            //searchParaStockSlip.PartySaleSlipNum = this.tEdit_PartySaleSlipNum.Text;
            string salesSlipCd = this.tEdit_PartySaleSlipNum.Text.Trim();
            if (salesSlipCd.Trim().Length > 0)
            {
                int targetIndex = salesSlipCd.IndexOf("*");
                if (targetIndex == -1)
                {
                    // 完全一致
                    searchParaStockSlip.PartySaleSlipNumSrchTyp = 0;
                    searchParaStockSlip.PartySaleSlipNum = salesSlipCd;
                }
                else if (salesSlipCd.StartsWith("*") && salesSlipCd.EndsWith("*"))
                {
                    // 曖昧検索
                    searchParaStockSlip.PartySaleSlipNumSrchTyp = 3;
                    searchParaStockSlip.PartySaleSlipNum = salesSlipCd.Replace("*", "");
                }
                else if (salesSlipCd.EndsWith("*"))
                {
                    // 前方一致
                    searchParaStockSlip.PartySaleSlipNumSrchTyp = 1;
                    searchParaStockSlip.PartySaleSlipNum = salesSlipCd.Replace("*", "");
                }
                else if (salesSlipCd.StartsWith("*"))
                {
                    // 後方一致
                    searchParaStockSlip.PartySaleSlipNumSrchTyp = 2;
                    searchParaStockSlip.PartySaleSlipNum = salesSlipCd.Replace("*", "");
                }
            }
            else
            {
                searchParaStockSlip.PartySaleSlipNumSrchTyp = 0;
                searchParaStockSlip.PartySaleSlipNum = string.Empty;
            }

			// 仕入SEQ番号（開始・終了）
			searchParaStockSlip.SupplierSlipNoSt = this.ValueToInt(this.tEdit_SupplierSlipNoStart.Text);
            searchParaStockSlip.SupplierSlipNoEd = this.ValueToInt(this.tEdit_SupplierSlipNoEnd.Text);

			// 仕入拠点コード
            if (this.tEdit_SectionCd.Text.Trim() == "00")
            {
                searchParaStockSlip.StockSectionCd = string.Empty;
            }
            else
            {
                searchParaStockSlip.StockSectionCd = this.tEdit_SectionCd.Text;
            }

            // ADD 2009/04/09 ------>>>
            // 部門コード
            if (this.tNedit_SubSectionCode.Visible)
            {
                searchParaStockSlip.SubSectionCode = this.tNedit_SubSectionCode.GetInt();
            }
            // ADD 2009/04/09 ------<<<
            
            // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// 得意先コード
            //searchParaStockSlip.CustomerCode = this.tNedit_SupplierCd.GetInt();
            // 仕入先コード
            searchParaStockSlip.SupplierCd = this.tNedit_SupplierCd.GetInt();
            // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			// 仕入時：日付設定
			if (searchParaStockSlip.SupplierFormal == 0)
			{
                //DateTime result;

                //DateTime.TryParse(this.tDateEdit_Date1Start.GetDateTime().ToString(), out result);
                //if (this.tDateEdit_Date1Start.GetLongDate() != 0 && result == DateTime.MinValue)
                //{
                //    // エラー
                //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                //        "入力された日付が不正です。正しく日付を選択または入力してください。", 0, MessageBoxButtons.OK);
                //    this.tDateEdit_Date1Start.Focus();
                //    return false;
                //}
                //else
                //{
                searchParaStockSlip.StockDateSt = this.tDateEdit_Date1Start.GetLongDate();
                //}

                //DateTime.TryParse(this.tDateEdit_Date1End.GetDateTime().ToString(), out result);
                //if (this.tDateEdit_Date1End.GetLongDate() != 0 && result == DateTime.MinValue)
                //{
                //    // エラー
                //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                //        "入力された日付が不正です。正しく日付を選択または入力してください。", 0, MessageBoxButtons.OK);
                //    this.tDateEdit_Date1End.Focus();
                //    return false;
                //}
                //else
                //{
                searchParaStockSlip.StockDateEd = this.tDateEdit_Date1End.GetLongDate();
                //}

                //DateTime.TryParse(this.tDateEdit_Date2Start.GetDateTime().ToString(), out result);
                //if (this.tDateEdit_Date2Start.GetLongDate() != 0 && result == DateTime.MinValue)
                //{
                //    // エラー
                //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                //        "入力された日付が不正です。正しく日付を選択または入力してください。", 0, MessageBoxButtons.OK);
                //    this.tDateEdit_Date2Start.Focus();
                //    return false;
                //}
                //else
                //{
                searchParaStockSlip.InputDaySt = this.tDateEdit_Date2Start.GetLongDate();
                //}

                //DateTime.TryParse(this.tDateEdit_Date2End.GetDateTime().ToString(), out result);
                //if (this.tDateEdit_Date2End.GetLongDate() != 0 && result == DateTime.MinValue)
                //{
                //    // エラー
                //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                //        "入力された日付が不正です。正しく日付を選択または入力してください。", 0, MessageBoxButtons.OK);
                //    this.tDateEdit_Date2End.Focus();
                //    return false;
                //}
                //else
                //{
                    searchParaStockSlip.InputDayEd = this.tDateEdit_Date2End.GetLongDate();
                //}
				searchParaStockSlip.ArrivalGoodsDaySt = 0;
				searchParaStockSlip.ArrivalGoodsDayEd = 0;
				searchParaStockSlip.StockAddUpADateSt = 0;
				searchParaStockSlip.StockAddUpADateEd = 0;
			}
			// 入荷時：日付設定
			else
			{
                //DateTime result;

                //DateTime.TryParse(this.tDateEdit_Date1Start.GetDateTime().ToString(), out result);
                //if (this.tDateEdit_Date1Start.GetLongDate() != 0 && result == DateTime.MinValue)
                //{
                //    // エラー
                //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                //        "入力された日付が不正です。正しく日付を選択または入力してください。", 0, MessageBoxButtons.OK);
                //    this.tDateEdit_Date1Start.Focus();
                //    return false;
                //}
                //else
                //{
                searchParaStockSlip.ArrivalGoodsDaySt = this.tDateEdit_Date1Start.GetLongDate();
                //}

                //DateTime.TryParse(this.tDateEdit_Date1End.GetDateTime().ToString(), out result);
                //if (this.tDateEdit_Date1End.GetLongDate() != 0 && result == DateTime.MinValue)
                //{
                //    // エラー
                //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                //        "入力された日付が不正です。正しく日付を選択または入力してください。", 0, MessageBoxButtons.OK);
                //    this.tDateEdit_Date1End.Focus();
                //    return false;
                //}
                //else
                //{
                searchParaStockSlip.ArrivalGoodsDayEd = this.tDateEdit_Date1End.GetLongDate();
                //}

                //DateTime.TryParse(this.tDateEdit_Date2Start.GetDateTime().ToString(), out result);
                //if (this.tDateEdit_Date2Start.GetLongDate() != 0 && result == DateTime.MinValue)
                //{
                //    // エラー
                //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                //        "入力された日付が不正です。正しく日付を選択または入力してください。", 0, MessageBoxButtons.OK);
                //    this.tDateEdit_Date2Start.Focus();
                //    return false;
                //}
                //else
                //{
                searchParaStockSlip.InputDaySt = this.tDateEdit_Date2Start.GetLongDate();
                //}

                //DateTime.TryParse(this.tDateEdit_Date2End.GetDateTime().ToString(), out result);
                //if (this.tDateEdit_Date2End.GetLongDate() != 0 && result == DateTime.MinValue)
                //{
                //    // エラー
                //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                //        "入力された日付が不正です。正しく日付を選択または入力してください。", 0, MessageBoxButtons.OK);
                //    this.tDateEdit_Date2End.Focus();
                //    return false;
                //}
                //else
                //{
                    searchParaStockSlip.InputDayEd = this.tDateEdit_Date2End.GetLongDate();
                //}
				
				searchParaStockSlip.StockDateSt = 0;
				searchParaStockSlip.StockDateEd = 0;
				searchParaStockSlip.StockAddUpADateSt = 0;
				searchParaStockSlip.StockAddUpADateEd = 0;
			}

			//商品コード
            //searchParaStockSlip.GoodsCode = this.tEdit_GoodsCode.Text;
            //項目が画面から削除されたため空白をセット
            searchParaStockSlip.GoodsNo = string.Empty;

			//商品メーカーコード
			//searchParaStockSlip.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            //項目が画面から削除されたため-1をセット
            searchParaStockSlip.GoodsMakerCd = -1;

			//検索商品
			//searchParaStockSlip.GoodsNmVagueSrch = CheckEditor_GoodsName.Checked;
			//searchParaStockSlip.GoodsName = tEdit_GoodsName.Text;
            //項目が画面から削除されたため空白をセット
            searchParaStockSlip.GoodsName = string.Empty;

			this._inputDetails._searchParaStockSlip = searchParaStockSlip;
			this._inputDetails.DisplayModeSetting();

            return true;
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
            nameList.Add("StockAgentName", this.uLabel_StockAgentName.Text);
            nameList.Add("SectionNm", this.uLabel_SectionNm.Text);

            return nameList;
        }

        /// <summary>
        /// 初期フォーカス設定処理
        /// </summary>
        public Control SetInitFocus(object sender)
        {
        //    this.tDateEdit_Date1Start.Focus();
        //    return this.tDateEdit_Date1Start;
            this.tEdit_SectionCd.Focus();
            return this.tEdit_SectionCd;
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
            // --- DEL 2009/04/03 -------------------------------->>>>>
            //DateTime result;
                        
            //DateTime.TryParse(this.tDateEdit_Date1Start.GetDateTime().ToString(), out result);
            //if (this.tDateEdit_Date1Start.GetLongDate() != 0 && result == DateTime.MinValue)
            //{
            //    // エラー
            //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
            //        "入力された日付が不正です。正しく日付を選択または入力してください。", 0, MessageBoxButtons.OK);
            //    this.tDateEdit_Date1Start.Focus();
            //    return tDateEdit_Date1Start;
            //}

            //DateTime.TryParse(this.tDateEdit_Date1End.GetDateTime().ToString(), out result);
            //if (this.tDateEdit_Date1End.GetLongDate() != 0 && result == DateTime.MinValue)
            //{
            //    // エラー
            //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
            //        "入力された日付が不正です。正しく日付を選択または入力してください。", 0, MessageBoxButtons.OK);
            //    this.tDateEdit_Date1End.Focus();
            //    return tDateEdit_Date1End;
            //}

            //DateTime.TryParse(this.tDateEdit_Date2Start.GetDateTime().ToString(), out result);
            //if (this.tDateEdit_Date2Start.GetLongDate() != 0 && result == DateTime.MinValue)
            //{
            //    // エラー
            //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
            //        "入力された日付が不正です。正しく日付を選択または入力してください。", 0, MessageBoxButtons.OK);
            //    this.tDateEdit_Date2Start.Focus();
            //    return tDateEdit_Date2Start;
            //}

            //DateTime.TryParse(this.tDateEdit_Date2End.GetDateTime().ToString(), out result);
            //if (this.tDateEdit_Date2End.GetLongDate() != 0 && result == DateTime.MinValue)
            //{
            //    // エラー
            //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
            //        "入力された日付が不正です。正しく日付を選択または入力してください。", 0, MessageBoxButtons.OK);
            //    this.tDateEdit_Date2End.Focus();
            //    return tDateEdit_Date2End;
            //}

            //// 大小チェック
            //// 仕入日
            //if (this.tDateEdit_Date1Start.LongDate > this.tDateEdit_Date1End.LongDate)
            //{
            //    this.tDateEdit_Date1Start.Focus();
            //    SetStatusBarMessage(this, MESSAGE_StartEndError);
            //    return tDateEdit_Date1Start;
            //}
            //if (this.tDateEdit_Date1Start.LongDate == 0)
            //{
            //    this.tDateEdit_Date1Start.Focus();
            //    SetStatusBarMessage(this, MESSAGE_NoInput);
            //    return tDateEdit_Date1Start;
            //}

            //if (this.tDateEdit_Date1End.LongDate == 0)
            //{
            //    this.tDateEdit_Date1End.Focus();
            //    SetStatusBarMessage(this, MESSAGE_NoInput);
            //    return tDateEdit_Date1End;
            //}
            // --- DEL 2009/04/03 --------------------------------<<<<<

            // --- ADD 2009/04/03 -------------------------------->>>>>
            DateGetAcs.CheckDateResult cdr;

            // 仕入日
            cdr = this._dateGetAcs.CheckDate(ref this.tDateEdit_Date1Start, true);
            if (cdr == DateGetAcs.CheckDateResult.ErrorOfInvalid)
            {
                // エラー
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "入力された日付が不正です。正しく日付を選択または入力してください。", 0, MessageBoxButtons.OK);
                this.tDateEdit_Date1Start.Focus();
                return tDateEdit_Date1Start;
            }

            cdr = this._dateGetAcs.CheckDate(ref this.tDateEdit_Date1End, true);
            if (cdr == DateGetAcs.CheckDateResult.ErrorOfInvalid)
            {
                // エラー
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "入力された日付が不正です。正しく日付を選択または入力してください。", 0, MessageBoxButtons.OK);
                this.tDateEdit_Date1End.Focus();
                return tDateEdit_Date1End;
            }

            // 範囲チェック
            if (this.tDateEdit_Date1Start.GetDateTime() != DateTime.MinValue
                && this.tDateEdit_Date1End.GetDateTime() != DateTime.MinValue)
            {
                if (this.tDateEdit_Date1Start.GetLongDate() > this.tDateEdit_Date1End.GetLongDate())
                {
                    this.tDateEdit_Date1Start.Focus();
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    MESSAGE_StartEndError, 0, MessageBoxButtons.OK);
                    return tDateEdit_Date1Start;
                }
            }

            // 入力日
            cdr = this._dateGetAcs.CheckDate(ref this.tDateEdit_Date2Start, true);
            if (cdr == DateGetAcs.CheckDateResult.ErrorOfInvalid)
            {
                // エラー
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "入力された日付が不正です。正しく日付を選択または入力してください。", 0, MessageBoxButtons.OK);
                this.tDateEdit_Date2Start.Focus();
                return tDateEdit_Date2Start;
            }

            cdr = this._dateGetAcs.CheckDate(ref this.tDateEdit_Date2End, true);
            if (cdr == DateGetAcs.CheckDateResult.ErrorOfInvalid)
            {
                // エラー
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "入力された日付が不正です。正しく日付を選択または入力してください。", 0, MessageBoxButtons.OK);
                this.tDateEdit_Date2End.Focus();
                return tDateEdit_Date2End;
            }

            // 範囲チェック
            if (this.tDateEdit_Date2Start.GetDateTime() != DateTime.MinValue
                && this.tDateEdit_Date2End.GetDateTime() != DateTime.MinValue)
            {
                if (this.tDateEdit_Date2Start.GetLongDate() > this.tDateEdit_Date2End.GetLongDate())
                {
                    this.tDateEdit_Date2Start.Focus();
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    MESSAGE_StartEndError, 0, MessageBoxButtons.OK);
                    return tDateEdit_Date2Start;
                }
            }
            // --- ADD 2009/04/03 --------------------------------<<<<<

            // 仕入SEQ番号
            // [9227] start
            long start = 0;
            long end = 0;
            if (!String.IsNullOrEmpty(this.tEdit_SupplierSlipNoStart.Text.Trim()))
            {
                try
                {
                    start = long.Parse(this.tEdit_SupplierSlipNoStart.Text.Trim());
                }
                catch
                {
                    SetStatusBarMessage(this, "仕入SEQ番号は数字で入力してください。");
                    return this.tEdit_SupplierSlipNoStart;
                }
            }

            if (!String.IsNullOrEmpty(this.tEdit_SupplierSlipNoEnd.Text.Trim()))
            {
                try
                {
                    end = long.Parse(this.tEdit_SupplierSlipNoEnd.Text.Trim());
                }
                catch
                {
                    SetStatusBarMessage(this, "仕入SEQ番号は数字で入力してください。");
                    return this.tEdit_SupplierSlipNoEnd;
                }
            }

            if (start > 0 && end > 0 && start - end > 0)
            {
                SetStatusBarMessage(this, "仕入SEQ番号（開始）は仕入SEQ番号（終了）より小さい値を入力してください。");
                return this.tEdit_SupplierSlipNoStart;
            }
            // [9227]end

            // --- DEL 2009/04/03 -------------------------------->>>>>
            //// 2008.11.17 add start [7912]
            //if (this.tDateEdit_Date1Start.GetDateTime().AddMonths(3) < this.tDateEdit_Date1End.GetDateTime())
            //{
            //    this.tDateEdit_Date1Start.Focus();
            //    string message = string.Empty;
            //    if ((int)this.tComboEditor_SupplierFormal.SelectedItem.DataValue == 1)
            //    {
            //        message = "入荷日" + MESSAGE_RangeOverError;
            //    }
            //    else
            //    {
            //        message = "仕入日" + MESSAGE_RangeOverError;
            //    }

            //    // エラー
            //    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
            //        message, 0, MessageBoxButtons.OK);
            //    return tDateEdit_Date1Start;
            //}
            //// 2008.11.17 add end [7912]
            // --- DEL 2009/04/03 --------------------------------<<<<<

            // --- DEL 2009/02/25 障害ID:7882対応------------------------------------------------------>>>>>
            //// 入力日
            //if (this.tDateEdit_Date2Start.LongDate > this.tDateEdit_Date2End.LongDate)
            //{
            //    this.tDateEdit_Date2Start.Focus();
            //    SetStatusBarMessage(this, MESSAGE_StartEndError);
            //    return tDateEdit_Date2Start;
            //}
            // --- DEL 2009/02/25 障害ID:7882対応------------------------------------------------------<<<<<
#if False
			// 有効チェック
            DateTime retDateTime = new DateTime();

            // 開始入荷日
            if (this.tDateEdit_Date1Start.LongDate == 0)
            {
                if (this.tComboEditor_SupplierFormal.SelectedIndex == 1)
                {
                    // 仕入形式が受託の場合は入力必須
                    this.tDateEdit_Date1Start.Focus();
                    SetStatusBarMessage(this, MESSAGE_NoInput);
					return tDateEdit_Date1Start;
                }
            }
            else
            {
                if (DateTime.TryParse(this.tDateEdit_Date1Start.GetDateTimeString("yyyy.MM.DD"), out retDateTime) == false)
                {
                    this.tDateEdit_Date1Start.Focus();
                    SetStatusBarMessage(this, MESSAGE_InvalidDate);
					return tDateEdit_Date1Start;
                }
            }

            // 終了入荷日
            if (this.tDateEdit_Date1End.LongDate == 0)
            {
                if (this.tComboEditor_SupplierFormal.SelectedIndex == 1)
                {
                    // 仕入形式が受託の場合は入力必須
                    this.tDateEdit_Date1End.Focus();
                    SetStatusBarMessage(this, MESSAGE_NoInput);
					return tDateEdit_Date1End;
                }
            }
            else
            {
                if (DateTime.TryParse(this.tDateEdit_Date1End.GetDateTimeString("yyyy.MM.DD"), out retDateTime) == false)
                {
                    this.tDateEdit_Date1End.Focus();
                    SetStatusBarMessage(this, MESSAGE_InvalidDate);
					return tDateEdit_Date1End;
                }
            }

            // 仕入形式が仕入の場合のみ計上日のチェック
            if (this.tComboEditor_SupplierFormal.SelectedIndex == 0)
            {
                // 開始計上日
                if (this.tDateEdit_Date2Start.LongDate == 0)
                {
                    this.tDateEdit_Date2Start.Focus();
                    SetStatusBarMessage(this, MESSAGE_NoInput);
					return tDateEdit_Date2Start;
                }
                else if (DateTime.TryParse(this.tDateEdit_Date2Start.GetDateTimeString("yyyy.MM.DD"), out retDateTime) == false)
                {
                    this.tDateEdit_Date2Start.Focus();
                    SetStatusBarMessage(this, MESSAGE_InvalidDate);
					return tDateEdit_Date2Start;
                }

                // 終了計上日
                if (this.tDateEdit_Date2End.LongDate == 0)
                {
                    this.tDateEdit_Date2End.Focus();
                    SetStatusBarMessage(this, MESSAGE_NoInput);
					return tDateEdit_Date2End;
                }
                else if (DateTime.TryParse(this.tDateEdit_Date2End.GetDateTimeString("yyyy.MM.DD"), out retDateTime) == false)
                {
                    this.tDateEdit_Date2End.Focus();
                    SetStatusBarMessage(this, MESSAGE_InvalidDate);
					return tDateEdit_Date2End;
                }
            }
#endif

			// 入力支援
            // 仕入日
            //AutoSetEndValue(this.tDateEdit_Date1Start, this.tDateEdit_Date1End); // DEL 2009/04/03

            // --- DEL 2009/02/25 障害ID:7882対応------------------------------------------------------>>>>>
            //// 仕入日
            //AutoSetEndValue(this.tDateEdit_Date2Start, this.tDateEdit_Date2End);
            // --- DEL 2009/02/25 障害ID:7882対応------------------------------------------------------<<<<<

            return null;
        }

        /// <summary>
        /// 伝票検索実行処理
        /// </summary>
        private Control SearchSlip()
        {
            // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
            // FIXME:検索前にもグリッド列の表示設定を保存
            GridSettings.SlipColumnsList = SlipGridUtil.CreateColumnInfoList(this._inputDetails.SlipGrid);
            SlipGridUtil.StoreGridSettings(GridSettings, XML_FILE_NAME);
            // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ----------<<<<<

            this._inputDetails.uGrid_Details.SuspendLayout();

            // 入力項目チェック処理
            Control control = this.CheckInputPara();
            
			if (control != null)
			{
                return control;
            }

            SearchParaStockSlip searchParaStockSlip = new SearchParaStockSlip();
            bool setEnable = false;

            // 読込条件パラメータクラス設定処理
            if (!this.SetReadPara(out searchParaStockSlip)) return null;

			/*
            // 前回検索条件との比較処理
            if (CheckSearchParam(searchParaStockSlip) == false)
            {
                // 伝票情報読込・データセット格納処理
                this._searchSlipAcs.SetSearchData(searchParaStockSlip);
            }
			*/

			// 伝票情報読込・データセット格納処理
			this._searchSlipAcs.SetSearchData(searchParaStockSlip);
			
			setEnable = this._inputDetails.SetGridEnable();
            if (setEnable == true)
            {
                this._inputDetails.uGrid_Details.Focus();
                this._inputDetails.timer_GridSetFocus.Enabled = true;
            }
            else
            {
                this._inputDetails.uButton_StockSearch.Enabled = false;
            }

            //伝票区分を設定
            int code = Convert.ToInt32(this.tComboEditor_SupplierFormal.Value);
            if (code == 0)
            {
                this._inputDetails.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockDateStringColumn.ColumnName].Hidden = false;
                this._inputDetails.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.ArrivalGoodsDayStringColumn.ColumnName].Hidden = true;
            }
            else
            {
                this._inputDetails.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.ArrivalGoodsDayStringColumn.ColumnName].Hidden = false;
                this._inputDetails.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockDateStringColumn.ColumnName].Hidden = true;
            }

            // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
            // FIXME:検索後も列移動と列固定を可能とする
            SlipGridUtil.EnableAllowColSwappingAndFixedHeaderIndicator(this._inputDetails.SlipGrid);
            // FIXME:検索後もグリッド列の設定を取込
            SlipGridUtil.LoadColumnInfo(this._inputDetails.SlipGrid, GridSettings.SlipColumnsList);
            // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ----------<<<<<

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
            // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //_paraStockSlipCache_Display.CustomerCode = 0;      // 仕入先
            _paraStockSlipCache_Display.SupplierCd = 0;      // 仕入先
            // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            _paraStockSlipCache_Display.StockAgentCode = "";   // 担当者
            _paraStockSlipCache_Display.StockSectionCd = "";   // 拠点
            //_paraStockSlipCache_Display.GoodsCode = "";        // 商品
        }

        /// <summary>
        /// 前回/今回検索条件比較処理
        /// </summary>
        /// <param name="">検索条件クラス(今回条件)</param>
        /// <returns>true:一致、false:不一致</returns>
        private bool CheckSearchParam(SearchParaStockSlip searchParaStockSlip)
        {
            // 実質使用されない項目は比較対象としない

            // 前回検索条件の取得
            SearchParaStockSlip prevSearchParaStockSlip = this._searchSlipAcs.GetParaStockSlipCache();
            if (prevSearchParaStockSlip == null)
            {
                return false;
            }

            // 仕入形式
            if (searchParaStockSlip.SupplierFormal != prevSearchParaStockSlip.SupplierFormal)
            {
                return false;
            }

            // 伝票区分
            if (searchParaStockSlip.SupplierSlipCd != prevSearchParaStockSlip.SupplierSlipCd)
            {
                return false;
            }

            //// 赤伝区分
            //if (searchParaStockSlip.DebitNoteDiv != prevSearchParaStockSlip.DebitNoteDiv)
            //{
            //    return false;
            //}

            //// 商品区分
            //if (searchParaStockSlip.StockGoodsCd != prevSearchParaStockSlip.StockGoodsCd)
            //{
            //    return false;
            //}

            // 買掛区分
            if (searchParaStockSlip.AccPayDivCd != prevSearchParaStockSlip.AccPayDivCd)
            {
                return false;
            }

            // 拠点
            if (searchParaStockSlip.StockSectionCd != prevSearchParaStockSlip.StockSectionCd)
            {
                return false;
            }

			// 仕入日(開始-終了)
            if ((searchParaStockSlip.StockDateSt != prevSearchParaStockSlip.StockDateSt) ||
                (searchParaStockSlip.StockDateEd != prevSearchParaStockSlip.StockDateEd))
            {
                return false;
            }

            // 計上日
            if ((searchParaStockSlip.InputDaySt != prevSearchParaStockSlip.InputDaySt) ||
                (searchParaStockSlip.InputDayEd != prevSearchParaStockSlip.InputDayEd))
            {
                return false;
            }

            // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// 仕入先
            //if (searchParaStockSlip.CustomerCode != prevSearchParaStockSlip.CustomerCode)
            //{
            //    return false;
            //}
            // 仕入先
            if (searchParaStockSlip.SupplierCd != prevSearchParaStockSlip.SupplierCd)
            {
                return false;
            }
            // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // 担当者コード
            if (searchParaStockSlip.StockAgentCode != prevSearchParaStockSlip.StockAgentCode)
            {
                return false;
            }

            // 伝票番号
            if (searchParaStockSlip.PartySaleSlipNum != prevSearchParaStockSlip.PartySaleSlipNum)
            {
                return false;
            }

			// 仕入SEQ番号(開始)
			if (searchParaStockSlip.SupplierSlipNoSt != prevSearchParaStockSlip.SupplierSlipNoSt)
			{
				return false;
			}

            // 仕入SEQ番号(終了)
            if (searchParaStockSlip.SupplierSlipNoEd != prevSearchParaStockSlip.SupplierSlipNoEd)
            {
                return false;
            }

            //// 商品
            //if (searchParaStockSlip.GoodsCode != prevSearchParaStockSlip.GoodsCode)
            //{
            //    return false;
            //}

            return true;
        }

        /// <summary>
        /// 「確定」ボタン表示変更処理
        /// </summary>
        /// <param name="enable">表示設定(true:表示、false:非表示)</param>
        private void ChangeDecisionButtonEnable(bool enableSet)
        {
            // 2008.12.10 modify [9016]
			if (this._inputDetails.StartMovment == 1) enableSet = false;
            //this._decisionButton.SharedProps.Enabled = enableSet;
            this._decisionButton.SharedProps.Visible = enableSet;
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
            this.uStatusBar_Main.Panels[0].Text = message;
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

			if (e.PrevCtrl == this.tEdit_PartySaleSlipNum || e.PrevCtrl == this.tEdit_SupplierSlipNoStart)
            {
                e.NextCtrl = this.tEdit_SectionCd;//.tEdit_GoodsCode;
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
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            SetStatusBarMessage(this, "");

            // フォーカス制御 ============================================ //
            // 詳細条件タブは削除された
            //if ((e.PrevCtrl == this.tEdit_StockAgentCode) ||
            //    //(e.PrevCtrl == this.tComboEditor_StockGoodsCd) ||
            //    //(e.PrevCtrl == this.tEdit_SectionCd) ||
            //    (e.PrevCtrl == this.uButton_EmployeeGuide))
            //{
            //    if (e.Key == Keys.Down)
            //    {
            //        if (Detail_UGroupBox.Expanded == true)
            //        {
            //            e.NextCtrl = this.tNedit_GoodsMakerCd;
            //        }
            //        else
            //        {
            //            e.NextCtrl = this._inputDetails.uGrid_Details; ;
            //        }
            //    }
            //}

            // この部分を残しておくと、日付からフォーカスを動かそうとすると
            // 検索が走り、また日付に戻ってしまうため削除する
            //if (((e.PrevCtrl.Parent.Parent == this.Standard_UGroupBox) ||
            //    //(e.PrevCtrl.Parent.Parent == this.Detail_UGroupBox) ||
            //    //(e.PrevCtrl.Parent.Parent == this.Select_UGroupBox)) &&
            //    (e.NextCtrl.Parent == this.panel_Detail) ||
            //     (e.NextCtrl == this._inputDetails.uGrid_Details)))
            //{
            //    Control control = SearchSlip();
            //    if ((this._inputDetails.uGrid_Details.Rows.Count > 0) &&
            //       (this._inputDetails.uGrid_Details.Enabled == true))
            //    {
            //        e.NextCtrl = this._inputDetails.uGrid_Details;
            //    }
            //    else
            //    {
            //        if (control == null)
            //        {
            //            e.NextCtrl = e.PrevCtrl;
            //        }
            //        else
            //        {
            //            e.NextCtrl = control;
            //        }
            //    }
            //}
            //else 
            if (e.PrevCtrl == this._inputDetails.uButton_StockSearch)
            {
                switch (e.Key)
                {
                    case Keys.Up:
                        {
                            //if (this.Detail_UGroupBox.Expanded == true)
                            //{
                            //    e.NextCtrl = this.tEdit_GoodsCode;
                            //}
                            //else
                            //{
                                e.NextCtrl = this.SetInitFocus(this);
                            //e.NextCtrl = this.tEdit_SectionCd;
                            //}

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

            // --- DEL 2009/04/03 -------------------------------->>>>>
            //// 入力支援 ============================================ //
            //// 入荷日
            //if ((e.PrevCtrl == this.tDateEdit_Date1Start) ||
            //    (e.PrevCtrl == this.tDateEdit_Date1End))
            //{
            //    AutoSetEndValue(this.tDateEdit_Date1Start, this.tDateEdit_Date1End);
            //}
            // --- DEL 2009/04/03 --------------------------------<<<<<

            // --- DEL 2009/02/25 障害ID:7882対応------------------------------------------------------>>>>>
            //// 計上日
            //if ((e.PrevCtrl == this.tDateEdit_Date2Start) ||
            //    (e.PrevCtrl == this.tDateEdit_Date2End))
            //{
            //    AutoSetEndValue(this.tDateEdit_Date2Start, this.tDateEdit_Date2End);
            //}
            // --- DEL 2009/02/25 障害ID:7882対応------------------------------------------------------<<<<<

			// 名称取得 ============================================ //
            switch (e.PrevCtrl.Name)
            {
                #region 拠点 [tEdit_SectionCd]
                // 拠点
                case "tEdit_SectionCd":
                    {
                        bool canChangeFocus = true;
                        string code = this.tEdit_SectionCd.Text.Trim().PadLeft(2, '0');
                        string name = this.uLabel_SectionNm.Text.Trim();

                        if (this._paraStockSlipCache_Display.StockSectionCd.Trim() != code)
                        {
                            if (code == "")
                            {
                                this._paraStockSlipCache_Display.StockSectionCd = code;
                                // 拠点コード・名称セット
                                this.tEdit_SectionCd.Text = string.Empty;
                                this.uLabel_SectionNm.Text = string.Empty;
                            }
                            else if (code == "00")
                            {
                                this._paraStockSlipCache_Display.StockSectionCd = string.Empty;
                                // 拠点コード・名称セット
                                this.tEdit_SectionCd.Text = "00";
                                this.uLabel_SectionNm.Text = "全社";
                            }
                            else
                            {
                                SecInfoSet secInfoSet = new SecInfoSet();
                                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                                int status = secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, code);
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    name = secInfoSet.SectionGuideNm;
                                    this._paraStockSlipCache_Display.StockSectionCd = code;
                                    // 拠点コード・名称セット
                                    this.tEdit_SectionCd.Text = this._paraStockSlipCache_Display.StockSectionCd.PadLeft(2, '0');
                                    this.uLabel_SectionNm.Text = name;
                                }
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "拠点が存在しません。",
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
                                        "拠点の取得に失敗しました。",
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                            }
                        }
                        else
                        {
                            this.tEdit_SectionCd.Text = code;
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
                                            if (this.tEdit_SectionCd.Text.Trim() == "")
                                            {
                                                e.NextCtrl = this.uButton_SectionGuide;
                                            }
                                            else
                                            {
                                                //e.NextCtrl = this.tEdit_SupplierSlipNoStart;
                                                if (this._secMngDiv == 0)
                                                {
                                                    e.NextCtrl = this.tNedit_SupplierCd;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.tNedit_SubSectionCode;
                                                }
                                            }
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    // Shift+Tabで従業員コードへ
                                    case Keys.Tab:
                                        {
                                            if (String.IsNullOrEmpty(this.tEdit_StockAgentCode.Text))
                                            {
                                                e.NextCtrl = this.uButton_EmployeeGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_StockAgentCode;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }
                #endregion // 拠点

                #region 拠点ガイド[uButton_SectionGuide]

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
                                        // ADD 2009/04/09 ------>>>
                                        if (this._secMngDiv == 0)
                                        {
                                            e.NextCtrl = this.tNedit_SupplierCd;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_SubSectionCode;
                                        }
                                        break;
                                        // ADD 2009/04/09 ------<<<
                                    }
                                case Keys.Down:
                                    {
                                        if (this._secMngDiv == 0)
                                        {
                                            e.NextCtrl = this.tNedit_SupplierCd;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.uButton_SubSectionGuide;
                                        }
                                        break;
                                    }
                                case Keys.Up:
                                    {
                                        e.NextCtrl = this.tEdit_SectionCd;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // 拠点ガイド[uButton_SectionGuide]

                #region 仕入先 [tNedit_SupplierCd]
                // 仕入先
				case "tNedit_SupplierCd":
					{
						bool canChangeFocus = true;
						int code = this.tNedit_SupplierCd.GetInt();
						string name = this.uLabel_CustomerName.Text.Trim();

                        #region 仕入先へ変更
                        // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        //if (this._paraStockSlipCache_Display.CustomerCode != code)
                        //{
                        //    if (code == 0)
                        //    {
                        //        this._paraStockSlipCache_Display.CustomerCode = code;
                        //        name = "";
                        //    }
                        //    else
                        //    {
                        //        CustomerInfo customerInfo;
                        //        CustSuppli custSuppli;
                        //        CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                        //        int status = customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, code, true, out customerInfo, out custSuppli);

                        //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //        {
                        //            //if (custSuppli == null)
                        //            //{
                        //            //	TMsgDisp.Show(
                        //            //		this,
                        //            //		emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        //            //		this.Name,
                        //            //		"選択した仕入先は仕入先情報入力が行われていない為、使用出来ません。",
                        //            //		status,
                        //            //		MessageBoxButtons.OK);
                        //            //}
                        //            //else
                        //            //{
                        //            this._paraStockSlipCache_Display.CustomerCode = code;
                        //            name = customerInfo.Name;

                        //            //}

                        //        }
                        //        else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        //        {
                        //            TMsgDisp.Show(
                        //                this,
                        //                emErrorLevel.ERR_LEVEL_INFO,
                        //                this.Name,
                        //                "仕入先が存在しません。",
                        //                -1,
                        //                MessageBoxButtons.OK);

                        //            canChangeFocus = false;
                        //        }
                        //        else
                        //        {
                        //            TMsgDisp.Show(
                        //                this,
                        //                emErrorLevel.ERR_LEVEL_STOPDISP,
                        //                this.Name,
                        //                "仕入先の取得に失敗しました。",
                        //                status,
                        //                MessageBoxButtons.OK);

                        //            canChangeFocus = false;
                        //        }
                        //    }
                        //    // 仕入先コード・名称セット
                        //    this.tNedit_SupplierCd.SetInt(this._paraStockSlipCache_Display.CustomerCode);
                        //    this.uLabel_CustomerName.Text = name;
                        //}
                        #endregion // 仕入先へ変更

                        if (this._paraStockSlipCache_Display.SupplierCd != code)
						{
                            if (code == 0)
                            {
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
                            // 仕入先コード・名称セット
                            this.tNedit_SupplierCd.SetInt(this._paraStockSlipCache_Display.SupplierCd);
                            this.uLabel_CustomerName.Text = name;
                        }
                        // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

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
                                                e.NextCtrl = this.uButton_StockCustomerGuide;
                                            }
                                            else
                                            {
                                                //e.NextCtrl = this.tEdit_StockAgentCode;
                                                e.NextCtrl = this.tNedit_PayeeCode;

                                            }
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
                                {
                                    if (this._secMngDiv == 0)
                                    {
                                        if (this.uLabel_SectionNm.Text != "")
                                        {
                                            e.NextCtrl = this.tEdit_SectionCd;
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
						}
						else
						{
							e.NextCtrl = e.PrevCtrl;
						}

						break;
                    }
                #endregion //仕入先

                #region 仕入先ガイド[uButton_StockCustomerGuide]

                case "uButton_StockCustomerGuide":
                    {
                        // NextCtrl制御
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this.tNedit_PayeeCode;
                                        break;
                                    }
                                case Keys.Up:
                                    {
                                        e.NextCtrl = this.tNedit_SupplierCd;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // 仕入先ガイド[uButton_StockCustomerGuide]

                #region 支払先 [tNedit_PayeeCode]
                // 支払先
                case "tNedit_PayeeCode":
                    {
                        bool canChangeFocus = true;
                        int code = this.tNedit_PayeeCode.GetInt();
                        string name = this.uLabel_PayeeName.Text.Trim();

                        if (this._paraStockSlipCache_Display.PayeeCode != code)
                        {
                            if (code == 0)
                            {
                                this._paraStockSlipCache_Display.PayeeCode = code;
                                name = "";
                            }
                            else
                            {
                                //CustomerInfo customerInfo;
                                //CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                                //int status = customerInfoAcs.ReadDBData(this._enterpriseCode, code, out customerInfo);

                                Supplier supplier;
                                int status = this._supplierAcs.Read(out supplier, this._enterpriseCode, code);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    this._paraStockSlipCache_Display.PayeeCode = code;
                                    name = supplier.SupplierSnm;
                                    //name = customerInfo.CustomerSnm;
                                }
                                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "支払先が存在しません。",
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
                                        "支払先の取得に失敗しました。",
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                            }
                            // 支払先コード・名称セット
                            this.tNedit_PayeeCode.SetInt(this._paraStockSlipCache_Display.PayeeCode);
                            this.uLabel_PayeeName.Text = name;
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
                                                e.NextCtrl = this.uButton_PayeeCodeGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tComboEditor_SupplierFormal;

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
                #endregion //支払先

                #region 支払先ガイド[uButton_PayeeCodeGuide]

                case "uButton_PayeeCodeGuide":
                    {
                        // NextCtrl制御
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this.tComboEditor_SupplierFormal;
                                        break;
                                    }
                                case Keys.Up:
                                    {
                                        e.NextCtrl = this.tNedit_PayeeCode;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // 支払先ガイド[uButton_PayeeCodeGuide]

                #region 伝票種別 [tComboEditor_SupplierFormal]

                case "tComboEditor_SupplierFormal":
                    {
                        // NextCtrl制御
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this.tComboEditor_SupplierSlipCd;
                                        break;
                                    }
                                case Keys.Up:
                                    {
                                        e.NextCtrl = this.tNedit_PayeeCode;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // 伝票区分 [tComboEditor_SupplierFormal]

                #region 伝票区分 [tComboEditor_SupplierSlipCd]

                case "tComboEditor_SupplierSlipCd":
                    {
                        // NextCtrl制御
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this.tDateEdit_Date1Start;
                                        break;
                                    }
                                case Keys.Up:
                                    {
                                        e.NextCtrl = this.tComboEditor_SupplierFormal;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // 伝票区分[tComboEditor_SupplierSlipCd]

                #region 仕入日 [tDateEdit_Date1Start]

                case "tDateEdit_Date1Start":
                    {
                        // NextCtrl制御
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this.tDateEdit_Date1End;
                                        break;
                                    }
                                case Keys.Up:
                                    {
                                        e.NextCtrl = this.tDateEdit_Date2End;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // 仕入日[tDateEdit_Date1Start]

                #region 仕入日 [tDateEdit_Date1End]

                case "tDateEdit_Date1End":
                    {
                        // NextCtrl制御
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this.tDateEdit_Date2Start;
                                        break;
                                    }
                                case Keys.Up:
                                    {
                                        e.NextCtrl = this.tDateEdit_Date1Start;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // 仕入日[tDateEdit_Date1End]

                #region 入力日 [tDateEdit_Date2Start]

                case "tDateEdit_Date2Start":
                    {
                        // NextCtrl制御
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this.tDateEdit_Date2End;
                                        break;
                                    }
                                case Keys.Up:
                                    {
                                        e.NextCtrl = this.tDateEdit_Date1End;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // 入力日[tDateEdit_Date2Start]

                #region 入力日 [tDateEdit_Date2End]

                case "tDateEdit_Date2End":
                    {
                        // NextCtrl制御
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this.tEdit_SupplierSlipNoStart;
                                        break;
                                    }
                                case Keys.Up:
                                    {
                                        e.NextCtrl = this.tDateEdit_Date2Start;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // 入力日[tDateEdit_Date2End]

                #region 仕入SEQ番号 [tEdit_SupplierSlipNoStart]

                case "tEdit_SupplierSlipNoStart":
                    {
                        // NextCtrl制御
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this.tEdit_SupplierSlipNoEnd;
                                        break;
                                    }
                                case Keys.Up:
                                    {
                                        e.NextCtrl = this.tDateEdit_Date1End;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // 仕入SEQ番号[tEdit_SupplierSlipNoStart]

                #region 仕入SEQ番号 [tEdit_SupplierSlipNoEnd]

                case "tEdit_SupplierSlipNoEnd":
                    {
                        // NextCtrl制御
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this.tEdit_PartySaleSlipNum;
                                        break;
                                    }
                                case Keys.Up:
                                    {
                                        e.NextCtrl = this.tEdit_SupplierSlipNoStart;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // 仕入SEQ番号[tEdit_SupplierSlipNoEnd]

                #region 伝票番号[tEdit_PartySaleSlipNum]

                case "tEdit_PartySaleSlipNum":
                    {
                        // NextCtrl制御
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this.tEdit_StockAgentCode;
                                        break;
                                    }
                                case Keys.Up:
                                    {
                                        e.NextCtrl = this.tEdit_SupplierSlipNoEnd;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // 伝票番号[tEdit_PartySaleSlipNum]

                #region 仕入担当 [tEdit_StockAgentCode]
                // 仕入担当
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
                            // NextCtrl制御
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                    case Keys.Down:
                                        {
                                            code = this.tEdit_StockAgentCode.Text.Trim();
                                            if (String.IsNullOrEmpty(code))
                                            {
                                                e.NextCtrl = this.uButton_EmployeeGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_SectionCd;
                                            }
                                            break;
                                        }
                                    case Keys.Up:
                                        {
                                            e.NextCtrl = this.tEdit_PartySaleSlipNum;
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
                #endregion // 仕入担当

                #region 担当者ガイド [uButton_EmployeeGuide]
                case "uButton_EmployeeGuide":
                    {
                        // NextCtrl制御
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this.tEdit_SectionCd;
                                        break;
                                    }
                                case Keys.Up:
                                    {
                                        e.NextCtrl = this.tEdit_StockAgentCode;
                                        break;
                                    }
                            }
                        }
                        break;
                    }

                #endregion // 担当者ガイド [uButton_EmployeeGuide]

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
                                            e.NextCtrl = this.tNedit_SupplierCd;
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
                                    e.NextCtrl = this.tEdit_SectionCd;
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
                                        e.NextCtrl = this.tNedit_SupplierCd;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion 部門ガイド [uButton_SubSectionGuide]

                #region del
                //// メーカー
                //case "tNedit_GoodsMakerCd":
                //    {
                //        bool canChangeFocus = true;
                //        int code = this.tNedit_GoodsMakerCd.GetInt();
                //        string name = uLabel_MakerName.Text.Trim();

                //        if (this._paraStockSlipCache_Display.GoodsMakerCd != code)
                //        {
                //            if (code == 0)
                //            {
                //                this._paraStockSlipCache_Display.GoodsMakerCd = code;
                //                name = "";
                //            }
                //            else
                //            {
                //                string nameTmp = this._searchSlipAcs.GetName_FromGoodsMaker(code);

                //                if (nameTmp.Trim() == "")
                //                {
                //                    TMsgDisp.Show(
                //                        this,
                //                        emErrorLevel.ERR_LEVEL_INFO,
                //                        this.Name,
                //                        "メーカーが存在しません。",
                //                        -1,
                //                        MessageBoxButtons.OK);

                //                    canChangeFocus = false;
                //                }
                //                else
                //                {
                //                    // メーカーコード・名称セット
                //                    this._paraStockSlipCache_Display.GoodsMakerCd = code;
                //                    name = nameTmp;

                //                    // 商品コード・名称のクリア
                //                    this._paraStockSlipCache_Display.GoodsCode = "";
                //                    this.tEdit_GoodsCode.Text = this._paraStockSlipCache_Display.GoodsCode;
                //                    this.uLabel_GoodsName.Text = "";
                //                }
                //            }
                //            // メーカーコード・名称セット
                //            this.tNedit_GoodsMakerCd.SetInt(this._paraStockSlipCache_Display.GoodsMakerCd);
                //            this.uLabel_MakerName.Text = name;

                //        }
                //        // NextCtrl制御
                //        if (canChangeFocus)
                //        {
                //            if (!e.ShiftKey)
                //            {
                //                switch (e.Key)
                //                {
                //                    case Keys.Return:
                //                    case Keys.Tab:
                //                        {
                //                            if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                //                            {
                //                                e.NextCtrl = this.uButton_GoodsMakerGuide;
                //                            }
                //                            else
                //                            {
                //                                e.NextCtrl = this.tEdit_GoodsCode;
                //                            }
                //                            break;
                //                        }
                //                }
                //            }
                //        }
                //        else
                //        {
                //            e.NextCtrl = e.PrevCtrl;
                //        }

                //        break;
                //    }
                //// 商品
                //case "tEdit_GoodsCode":
                //    {
                //        bool canChangeFocus = true;
                //        string code = this.tEdit_GoodsCode.Text.Trim();
                //        string name = this.uLabel_GoodsName.Text.Trim();

                //        int goodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
                //        string makerName = this.uLabel_MakerName.Text;

                //        if (this._paraStockSlipCache_Display.GoodsCode.Trim() != code)
                //        {
                //            if (code == "")
                //            {
                //                this._paraStockSlipCache_Display.GoodsCode = code;
                //                name = "";
                //            }
                //            else
                //            {
                //                string nameTmp = "";

                //                int existFlg = this._searchSlipAcs.CheckGoodsExist(this, ref code, ref nameTmp, ref goodsMakerCd, ref makerName);

                //                if (existFlg == 4)
                //                {
                //                    TMsgDisp.Show(
                //                        this,
                //                        emErrorLevel.ERR_LEVEL_INFO,
                //                        this.Name,
                //                        "商品が存在しません。",
                //                        -1,
                //                        MessageBoxButtons.OK);

                //                    canChangeFocus = false;
                //                }
                //                else if (existFlg == 0)
                //                {
                //                    this._paraStockSlipCache_Display.GoodsCode = code;
                //                    name = nameTmp;

                //                    this._paraStockSlipCache_Display.GoodsMakerCd = goodsMakerCd;

                //                }
                //            }
                //            // 商品コード・名称セット
                //            this.tEdit_GoodsCode.Text = this._paraStockSlipCache_Display.GoodsCode;
                //            this.uLabel_GoodsName.Text = name;

                //            // メーカーコード・名称セット
                //            this.tNedit_GoodsMakerCd.SetInt(this._paraStockSlipCache_Display.GoodsMakerCd);
                //            this.uLabel_MakerName.Text = makerName;
                //        }

                //        // NextCtrl制御
                //        if (canChangeFocus)
                //        {
                //            if (!e.ShiftKey)
                //            {
                //                switch (e.Key)
                //                {
                //                    case Keys.Return:
                //                    case Keys.Tab:
                //                        {
                //                            e.NextCtrl = this.uButton_GoodsGuide;

                //                            break;
                //                        }
                //                }
                //            }
                //        }
                //        else
                //        {
                //            e.NextCtrl = e.PrevCtrl;
                //        }

                //        break;
                //    }
                #endregion // del

            }

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
                    //this._inputDetails.timer_SelectRow.Enabled = true;
                }

				//if (e.PrevCtrl == this.tEdit_PartySaleSlipNum)
                //{
                //    e.NextCtrl = this.tEdit_GoodsCode;
                //}
                else 
				if (e.NextCtrl.Parent == this.panel_Detail)
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
        }

        /// <summary>
        /// 初期フォーカス設定タイマー起動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
        {
            this.timer_InitialSetFocus.Enabled = false;

            this.SetInitFocus(this);

            // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
            // FIXME:列移動と列固定を可能とする
            SlipGridUtil.EnableAllowColSwappingAndFixedHeaderIndicator(this._inputDetails.SlipGrid);
            // FIXME:グリッド列の設定を取込
            SlipGridUtil.LoadColumnInfo(this._inputDetails.SlipGrid, GridSettings.SlipColumnsList);
            // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ----------<<<<<

            this._inputDetails.uGrid_Details.Enabled = false;
        }

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
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet;
            int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, this._mainOfficeFunc, out secInfoSet);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tEdit_SectionCd.Text = secInfoSet.SectionCode.Trim();
                uLabel_SectionNm.Text = secInfoSet.SectionGuideNm.Trim();
                this._paraStockSlipCache_Display.StockSectionCd = secInfoSet.SectionCode.Trim();

                // 2008.12.10 add [9024]
                if (this._secMngDiv == 0)
                {
                    this.tNedit_SupplierCd.Focus();
                }
                else
                {
                    this.tNedit_SubSectionCode.Focus();
                }
            }
        }

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
                this._paraStockSlipCache_Display.StockAgentCode = employee.EmployeeCode.Trim();

                // 2008.12.10 add [9024]
                this.tEdit_SectionCd.Focus();
            }
        }

        /// <summary>
        /// 仕入先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_StockCustomerGuide_Click(object sender, EventArgs e)
        {
            // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_AND_EDIT);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            //customerSearchForm.ShowDialog(this);

            Supplier supplier;
            int status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, string.Empty);
            if (status == (int)(int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.SupplierSearchForm_SupplierSelect(supplier);
            }
            // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// 支払先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_PayeeCodeGuide_Click(object sender, EventArgs e)
        {
            Supplier supplier;
            int status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, string.Empty);
            if (status == (int)(int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.PayeeSearchForm_PayeeSelect(supplier);
            }

            //PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);	// 得意先検索アクセスクラス
            //customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            //DialogResult ret = customerSearchForm.ShowDialog(this);
        }

        /// <summary>
        /// 商品ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="message">メッセージ</param>
        private void uButton_GoodsGuide_Click(object sender, EventArgs e)
        {
            //MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();
            //GoodsUnitData goodsUnitData;
            //GoodsCndtn condtn = new GoodsCndtn();

            //condtn.EnterpriseCode = this._enterpriseCode;
            //condtn.GoodsMakerCd = tNedit_GoodsMakerCd.GetInt();
            //condtn.MakerName = this.uLabel_MakerName.Text;

            ////DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, this._enterpriseCode, out goodsUnitData);
            //DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, false, condtn, out goodsUnitData);

            //if ((dialogResult == DialogResult.OK) && (goodsUnitData != null))
            //{
            //    // メーカーコード設定処理
            //    this._paraStockSlipCache_Display.GoodsMakerCd = goodsUnitData.GoodsMakerCd;

            //    this.tNedit_GoodsMakerCd.SetInt(this._paraStockSlipCache_Display.GoodsMakerCd);
            //    this.uLabel_MakerName.Text = goodsUnitData.MakerName;

            //    // 商品コード設定処理
            //    this._paraStockSlipCache_Display.GoodsCode = goodsUnitData.GoodsNo;
            //    this.tEdit_GoodsCode.Text = this._paraStockSlipCache_Display.GoodsCode;
            //    this.uLabel_GoodsName.Text = goodsUnitData.GoodsName;
            //}
        }

        /// <summary>
        /// 支払先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">支払先検索戻り値クラス</param>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            if (this._paraStockSlipCache_Display.PayeeCode != customerSearchRet.CustomerCode)
            {
                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                CustomerInfo customerInfo = new CustomerInfo();

                int status = customerInfoAcs.ReadDBData(_enterpriseCode, customerSearchRet.CustomerCode, out customerInfo);
                if ((status == 0) && ((customerInfo.IsCustomer == true) || (customerInfo.IsReceiver == true)))
                {
                    // パラメータに設定
                    this._paraStockSlipCache_Display.PayeeCode = customerSearchRet.CustomerCode;

                    // UIに設定
                    this.tNedit_PayeeCode.SetInt(customerSearchRet.CustomerCode);
                    this.uLabel_PayeeName.Text = customerSearchRet.Snm;
                    
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
                }
            }
        }

        // DEL 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
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
        //        //if (custSuppli == null)
        //        //{
        //        //    TMsgDisp.Show(
        //        //        this,
        //        //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //        //        this.Name,
        //        //        "選択した仕入先は仕入先情報入力が行われていない為、使用出来ません。",
        //        //        status,
        //        //        MessageBoxButtons.OK);
        //        //
        //        //    return;
        //        //}
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
        //    this.uLabel_CustomerName.Text = customerSearchRet.Name;
        //    this._paraStockSlipCache_Display.CustomerCode = customerSearchRet.CustomerCode;
        //}
        // DEL 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 仕入先情報設定処理
        /// </summary>
        /// <param name="supplier">仕入先情報データクラス</param>
        private void SupplierSearchForm_SupplierSelect(Supplier supplier)
        {
            if (supplier == null) return;

            Supplier tempSupplier;
            SupplierAcs supplierAcs = new SupplierAcs();

            int status = supplierAcs.Read(out tempSupplier, this._enterpriseCode, supplier.SupplierCd);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "選択した仕入先は既に削除されています。",
                    status,
                    MessageBoxButtons.OK);

                return;
            }
            this.tNedit_SupplierCd.Text = tempSupplier.SupplierCd.ToString().PadLeft(6, '0');//.SetInt(tempSupplier.SupplierCd);
            this.uLabel_CustomerName.Text = tempSupplier.SupplierSnm;// SupplierNm1;
            this._paraStockSlipCache_Display.SupplierCd = tempSupplier.SupplierCd;
            // 2008.12.10 add [9024]
            this.tNedit_PayeeCode.Focus();
        }

        /// <summary>
        /// 支払先情報設定処理
        /// </summary>
        /// <param name="supplier">支払先情報データクラス</param>
        private void PayeeSearchForm_PayeeSelect(Supplier supplier)
        {
            if (supplier == null) return;

            Supplier tempSupplier;
            SupplierAcs supplierAcs = new SupplierAcs();

            int status = supplierAcs.Read(out tempSupplier, this._enterpriseCode, supplier.SupplierCd);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
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
            this.tNedit_PayeeCode.Text = tempSupplier.SupplierCd.ToString().PadLeft(6, '0');//.SetInt(tempSupplier.SupplierCd);
            this.uLabel_PayeeName.Text = tempSupplier.SupplierSnm;//.SupplierNm1;
            this._paraStockSlipCache_Display.PayeeCode = tempSupplier.SupplierCd;

            // 2008.12.10 add [9024]
            this.tComboEditor_SupplierFormal.Focus();
        }
        // ADD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 仕入形式選択地変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="message">メッセージ</param>
        private void tComboEditor_SupplierFormal_SelectionChanged(object sender, EventArgs e)
        {

			//伝票区分を設定
			int code = Convert.ToInt32(this.tComboEditor_SupplierFormal.Value);
            //this.SetSupplierSlipCdComboEditor(ref tComboEditor_SupplierSlipCd, code); // DEL 2009/01/23

//            this._inputDetails.uGrid_Details.SuspendLayout();
            if (code == 0)
            {
                //this._inputDetails.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockDateStringColumn.ColumnName].Header.Caption = "仕入日";
                this._inputDetails.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockDateStringColumn.ColumnName].Hidden = false;
                this._inputDetails.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.ArrivalGoodsDayStringColumn.ColumnName].Hidden = true;
                //uLabel_Date1Title.Text = "仕入日";
            }
            else
            {
                //this._inputDetails.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.ArrivalGoodsDayStringColumn.ColumnName].Header.Caption = "入荷日";
                this._inputDetails.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.ArrivalGoodsDayStringColumn.ColumnName].Hidden = false;
                this._inputDetails.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockDateStringColumn.ColumnName].Hidden = true;
                //uLabel_Date1Title.Text = "入荷日";
            }
            this._inputDetails.uGrid_Details.PerformLayout();//.Refresh();


			//商品区分を設定
			//this.SetStockGoodsCdComboEditor(ref tComboEditor_StockGoodsCd, code);

			uLabel_Date1Set();
        }

		private void uLabel_Date1Set()
		{
			if (tComboEditor_SupplierFormal.SelectedIndex == 0)
			{
				uLabel_Date1Title.Text = "仕入日";
				uLabel_Date2Title.Text = "入力日";
			}
			else
			{
				uLabel_Date1Title.Text = "入荷日";
				uLabel_Date2Title.Text = "入力日";
			}
		}

        # endregion


		# region 伝票区分コンボエディタリスト設定処理
        ///// <summary>
        ///// 伝票区分コンボエディタリスト設定処理
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="salesFormalCode"></param>
        //private void SetSupplierSlipCdComboEditor(ref TComboEditor sender, int salesFormalCode)
        //{

        //    Infragistics.Win.ValueList valueList = new Infragistics.Win.ValueList();

        //    Infragistics.Win.ValueListItem secInfoItem99 = new Infragistics.Win.ValueListItem();
        //    Infragistics.Win.ValueListItem secInfoItem10 = new Infragistics.Win.ValueListItem();
        //    Infragistics.Win.ValueListItem secInfoItem20 = new Infragistics.Win.ValueListItem();
        //    Infragistics.Win.ValueListItem secInfoItem30 = new Infragistics.Win.ValueListItem();
        //    Infragistics.Win.ValueListItem secInfoItem40 = new Infragistics.Win.ValueListItem();

        //    switch (salesFormalCode)
        //    {
        //        //0:仕入,1:入荷
        //        case 0:
        //            //全て
        //            secInfoItem99.DataValue = 99;
        //            secInfoItem99.DisplayText = "全て";
        //            valueList.ValueListItems.Add(secInfoItem99);
        //            // 返品のみは追加しない
        //            if (this._extractSlipCdType != 2)
        //            {
        //                //掛仕入
        //                secInfoItem10.DataValue = 10;
        //                secInfoItem10.DisplayText = "掛仕入";
        //                valueList.ValueListItems.Add(secInfoItem10);
        //                //現金仕入
        //                secInfoItem30.DataValue = 30;
        //                secInfoItem30.DisplayText = "現金仕入";
        //                valueList.ValueListItems.Add(secInfoItem30);
        //            }
        //            // 仕入のみは追加しない
        //            if (this._extractSlipCdType != 1)
        //            {
        //                //掛返品
        //                secInfoItem20.DataValue = 20;
        //                secInfoItem20.DisplayText = "掛返品";
        //                valueList.ValueListItems.Add(secInfoItem20);
        //                //現金返品
        //                secInfoItem40.DataValue = 40;
        //                secInfoItem40.DisplayText = "現金返品";
        //                valueList.ValueListItems.Add(secInfoItem40);
        //            }
        //            break;
        //        case 1:
        //            //全て
        //            secInfoItem99.DataValue = 99;
        //            secInfoItem99.DisplayText = "全て";
        //            valueList.ValueListItems.Add(secInfoItem99);
        //            // 返品のみは追加しない
        //            if (this._extractSlipCdType != 2)
        //            {
        //                //掛仕入
        //                secInfoItem10.DataValue = 10;
        //                secInfoItem10.DisplayText = "掛仕入";
        //                valueList.ValueListItems.Add(secInfoItem10);
        //            }
        //            // 仕入のみは追加しない
        //            if (this._extractSlipCdType != 1)
        //            {
        //                //掛返品
        //                secInfoItem20.DataValue = 20;
        //                secInfoItem20.DisplayText = "掛返品";
        //                valueList.ValueListItems.Add(secInfoItem20);
        //            }
        //            break;
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

        //        sender.Value = 99;
        //    }
        //}
        # endregion

		# region 商品区分コンボエディタリスト設定処理
		/// <summary>
		/// 商品区分コンボエディタリスト設定処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="salesFormalCode"></param>
		private void SetStockGoodsCdComboEditor(ref TComboEditor sender, int salesFormalCode)
		{

			Infragistics.Win.ValueList valueList = new Infragistics.Win.ValueList();

			Infragistics.Win.ValueListItem secInfoItem99 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem secInfoItem0 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem secInfoItem1 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem secInfoItem2 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem secInfoItem3 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem secInfoItem4 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem secInfoItem5 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem secInfoItem6 = new Infragistics.Win.ValueListItem();

			switch (salesFormalCode)
			{
				//0:仕入,1:入荷
				case 0:
					//全て
					secInfoItem99.DataValue = 99;
					secInfoItem99.DisplayText = "全て";
					valueList.ValueListItems.Add(secInfoItem99);
					//商品
					secInfoItem0.DataValue = 0;
					secInfoItem0.DisplayText = "商品";
					valueList.ValueListItems.Add(secInfoItem0);
					//商品外
					secInfoItem1.DataValue = 1;
					secInfoItem1.DisplayText = "商品外";
					valueList.ValueListItems.Add(secInfoItem1);
					//消費税調整
					secInfoItem2.DataValue = 2;
					secInfoItem2.DisplayText = "消費税調整";
					valueList.ValueListItems.Add(secInfoItem2);
					//残高調整
					secInfoItem3.DataValue = 3;
					secInfoItem3.DisplayText = "残高調整";
					valueList.ValueListItems.Add(secInfoItem3);
					//消費税調整(買掛)
					secInfoItem4.DataValue = 4;
					secInfoItem4.DisplayText = "消費税調整(買掛)";
					valueList.ValueListItems.Add(secInfoItem4);
					//残高調整(買掛)
					secInfoItem5.DataValue = 5;
					secInfoItem5.DisplayText = "残高調整(買掛)";
					valueList.ValueListItems.Add(secInfoItem5);
					//合計入力
					secInfoItem6.DataValue = 6;
					secInfoItem6.DisplayText = "合計入力";
					valueList.ValueListItems.Add(secInfoItem6);
					break;
				case 1:
					//商品
					secInfoItem0.DataValue = 0;
					secInfoItem0.DisplayText = "商品";
					valueList.ValueListItems.Add(secInfoItem0);
					break;
			}

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

				sender.MaxDropDownItems = valueList.ValueListItems.Count;

				switch (salesFormalCode)
				{
					//0:仕入,1:入荷
					case 0:
						sender.Value = 99;
						break;
					case 1:
						sender.Value = 0;
						break;
				}

			}
		}
		# endregion

		/// <summary>
		/// メーカーガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void uButton_GoodsMakerGuide_Click(object sender, EventArgs e)
		{
            //MakerAcs makerAcs = new MakerAcs();
            //MakerUMnt makerUMnt;
            //int status = makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    tNedit_GoodsMakerCd.Text = makerUMnt.GoodsMakerCd.ToString();
            //    uLabel_MakerName.Text = makerUMnt.MakerName.Trim();
            //    this._paraStockSlipCache_Display.GoodsMakerCd = makerUMnt.GoodsMakerCd;
            //}

        }

        #region 伝票区分の抽出(ENUM ExtractSlipCdType)

        // 2008.11.07 add start [7285]

        /// <summary>
        /// 伝票区分の抽出
        /// </summary>
        public enum ExtractSlipCdType:int
        {
            /// <summary>全て (0)</summary>
            All = 0,
            /// <summary>仕入</summary>
            Purchase = 1,
            /// <summary>返品</summary>
            Return = 2,
        }

        private void tEdit_SupplierSlipNoStart_Leave(object sender, EventArgs e)
        {
            string value = this.tEdit_SupplierSlipNoStart.Text.Trim();
            if (!String.IsNullOrEmpty(value))
            {
                this.tEdit_SupplierSlipNoStart.Text = value.PadLeft(9, '0');
            }
        }

        private void tEdit_SupplierSlipNoEnd_Leave(object sender, EventArgs e)
        {
            string value = this.tEdit_SupplierSlipNoEnd.Text.Trim();
            if (!String.IsNullOrEmpty(value))
            {
                this.tEdit_SupplierSlipNoEnd.Text = value.PadLeft(9, '0');
            }
        }

        private void uButton_SubSectionGuide_Click(object sender, EventArgs e)
        {
            SubSection subSection;

            int status = this._searchSlipAcs.ExecuteSubSectionGuide(out subSection);
            if (status == 0)
            {
                this.tNedit_SubSectionCode.SetInt(subSection.SubSectionCode);
                this.uLabel_SubSectionName.Text = subSection.SubSectionName.Trim();

                this.tNedit_SupplierCd.Focus();
            }
        }
        // 2008.11.07 add end [7285]

        #endregion // 伝票区分の抽出(ENUM ExtractSlipCdType)

        // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
        /// <summary>
        /// 仕入伝票照会フォームのFormClosingイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void MAKON01320UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_disposed) return;

            // FIXME:グリッド列の表示設定を保存
            GridSettings.SlipColumnsList = SlipGridUtil.CreateColumnInfoList(this._inputDetails.SlipGrid);
            SlipGridUtil.StoreGridSettings(GridSettings, XML_FILE_NAME);
        }
        // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ----------<<<<<
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    using GridSettingsType = SlipGridSettings;  // ADD 2009/12/03 MANTIS対応[14742]：伝票および明細グリッド列の列設定の変更

    /// <summary>
    /// 売上伝票選択ガイドフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上伝票選択ガイドのフォームクラスです。</br>
    /// <br>Programmer : 980076 妻鳥　謙一郎</br>
    /// <br>Date       : 2007.06.13</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.06.13 men 新規作成</br>
    /// <br>					 改修（抽出条件・表示項目変更）</br>
    /// <br>Programmer       :   30418 徳永 俊詞</br>
    /// <br>Date             :   2008/07/11</br>
    /// <br>Update Note      : 2008.10.09 鈴木 正臣</br>
    /// <br>                      ①フォーカス制御修正、ＰＧタイトル修正、画面配置修正</br>
    /// <br>Update Note      : 2009.01.29 忍 幸史</br>
    /// <br>                      ①障害ID:7552,10621対応</br>
    /// <br>Update Note      : 2009.02.25 忍 幸史</br>
    /// <br>                      ①障害ID:7882対応</br>
    /// <br>Update Note      : 2009/03/06 上野 俊治</br>
    /// <br>                      ①障害ID:12181対応</br>
    /// <br>Update Note      : 2009/04/03 上野 俊治</br>
    /// <br>                      ①障害ID:13082対応</br>
    /// <br>Update Note      : 2009/12/03 工藤 恵優</br>
    /// <br>                      ①障害ID:14742対応</br>
    /// <br>Update Note      : 2010/07/27 20056 對馬 大輔</br>
    /// <br>                      表示速度改善</br>
    /// <br>Update Note      : 2010/12/21 鄧潘ハン</br>
    /// <br>                      ①クリア処理後のフォーカス制御変更</br>
    /// <br>Update Note      : 2011/03/02 22008 長内 数馬</br>
    /// <br>                      成果物統合ミス 2010/07/27修正分を統合</br>
    /// <br>Update Note      : 2011/07/18 朱宝軍</br>
    /// <br>                      回答区分追加対応</br>
    /// <br>Update Note      : 鄧潘ハン Redmine 26538対応</br>
    /// <br>Date             : 2011/11/11</br>
    /// <br>Update Note      : 2011/12/14 yangmj</br>
    /// <br>管理番号         : 10707327-00 2012/01/25配信分</br>
    /// <br>                   redmine#27359 伝票検索の画面表示の対応</br>
    /// <br>Update Note      : 2015/05/08 gaocheng</br>
    /// <br>管理番号         : 11175085-00</br>
    /// <br>                 : Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正</br>
    /// <br> </br>
    /// </remarks>
    public partial class MAHNB04110UA : Form
    {
        # region コンストラクタ
        /// <summary>
        /// 売上伝票選択ガイドのコンストラクタです。
        /// </summary>
        public MAHNB04110UA()
        {
            InitializeComponent();

            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            this._loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools["LabelTool_LoginName"];
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            this._selectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Select"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"];
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];
            this._setupButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setup"];
            this._controlScreenSkin = new ControlScreenSkin();
            this._para = new SalesSlipSearch();
            this._salesSlipSearchAcs = new SalesSlipSearchAcs();
            this._dataSet = this._salesSlipSearchAcs.DataSet;
            this._salesSearchConstructionAcs = SalesSearchConstructionAcs.GetInstance();
            this._salesSearchConstructionAcs.DataChanged += new EventHandler(this.SalesSearchConstructionAcs_DataChanged);

            //日付取得部品
            this._dateGet = DateGetAcs.GetInstance();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            // 締日算出モジュール
            _totalDayCalculator = TotalDayCalculator.GetInstance();

            // 変則フォーカス制御
            _irrFocusCtrl = new IrregularFocusControl();
            # region [focus]
            _irrFocusCtrl.AddFocusDictionary( SectionCodeGuide_ultraButton, false, Keys.Down, 0, ultraButton_SubSectionGuide );
            _irrFocusCtrl.AddFocusDictionary( SectionCodeGuide_ultraButton, false, Keys.Down, 1, uButton_CustomerGuide );
            _irrFocusCtrl.AddFocusDictionary( SectionCodeGuide_ultraButton, false, Keys.Right, 0, tDateEdit_SalesDateSt );
            _irrFocusCtrl.AddFocusDictionary( tDateEdit_SearchSlipDateEd, false, Keys.Down, 0, tEdit_SalesSlipNum_Ed );
            _irrFocusCtrl.AddFocusDictionary( tEdit_SalesSlipNum_Ed, false, Keys.Up, 0, tDateEdit_SearchSlipDateEd );
            _irrFocusCtrl.AddFocusDictionary( uButton_SalesEmployeeGuide, false, Keys.Up, 0, tEdit_SalesSlipNum_Ed );
            _irrFocusCtrl.AddFocusDictionary( ultraButton_SubSectionGuide, false, Keys.Down, 0, uButton_CustomerGuide );
            _irrFocusCtrl.AddFocusDictionary( ultraButton_SubSectionGuide, false, Keys.Right, 0, tDateEdit_SearchSlipDateSt );
            # endregion

            // 外部からの自動検索条件
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
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD

            // ADD 2008/11/05 不具合対応[7070] 売上全体設定マスタの発行者区分を参照 ---------->>>>>
            // 発行者UIを隠す
            // 2008.11.18 modify start [7070]
            SetInpAgentDispDivFromSalesTtlSt(LoginInfoAcquisition.Employee.BelongSectionCode);
            // 2008.11.18 modify end [7070]
            HideSalesInputUI(!this._inpAgentDispDiv.Equals(INP_AGT_DISP));
            // ADD 2008/11/05 不具合対応[7070] 売上全体設定マスタの発行者区分を参照 ----------<<<<<

            // --- ADD 2009/02/12 障害ID:11416対応------------------------------------------------------>>>>>
            this._secInfoAcs = new SecInfoAcs();
            // --- ADD 2009/02/12 障害ID:11416対応------------------------------------------------------<<<<<

        }

        public MAHNB04110UA(int startMovment)
            : this()
        {
            this.StartMovment = startMovment;
            if (startMovment == 1)
            {
                ChangeDecisionButtonEnable(false);
            }
        }

        // 2008.11.11 add start [7552]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="extractSlipCdType"></param>
        public MAHNB04110UA(ExtractSlipCdType extractSlipCdType)
            : this()
        {
            // 環境変数に保存
            this._extractSlipCdType = (int)extractSlipCdType;

            Infragistics.Win.ValueListItem item;

            // 伝票区分の抽出条件により、伝票区分コンボの内容を調整
            switch (_extractSlipCdType)
            {
                // 全て
                case 0:
                    {
                        this.tComboEditor_SalesSlipCd.Items.Clear();

                        // 全て
                        item = new Infragistics.Win.ValueListItem(-1, "全て");
                        this.tComboEditor_SalesSlipCd.Items.Add(item);

                        // 掛売上
                        item = new Infragistics.Win.ValueListItem(0, "掛売上");
                        this.tComboEditor_SalesSlipCd.Items.Add(item);

                        // 掛返品
                        item = new Infragistics.Win.ValueListItem(1, "掛返品");
                        this.tComboEditor_SalesSlipCd.Items.Add(item);

                        // 現金売上
                        item = new Infragistics.Win.ValueListItem(100, "現金売上");
                        this.tComboEditor_SalesSlipCd.Items.Add(item);

                        // 現金返品
                        item = new Infragistics.Win.ValueListItem(101, "現金返品");
                        this.tComboEditor_SalesSlipCd.Items.Add(item);
                    }
                    break;
                // 売上
                case 1:
                    {
                        this.tComboEditor_SalesSlipCd.Items.Clear();

                        // 全て
                        item = new Infragistics.Win.ValueListItem(-1, "全て");
                        item.Tag = 1;
                        this.tComboEditor_SalesSlipCd.Items.Add(item);

                        // 掛売上
                        item = new Infragistics.Win.ValueListItem(0, "掛売上");
                        item.Tag = 2;
                        this.tComboEditor_SalesSlipCd.Items.Add(item);

                        // 現金売上
                        item = new Infragistics.Win.ValueListItem(100, "現金売上");
                        item.Tag = 4;
                        this.tComboEditor_SalesSlipCd.Items.Add(item);
                    }
                    break;
                // 返品
                case 2:
                    {
                        this.tComboEditor_SalesSlipCd.Items.Clear();

                        // 全て
                        item = new Infragistics.Win.ValueListItem(-1, "全て");
                        item.Tag = 1;
                        this.tComboEditor_SalesSlipCd.Items.Add(item);

                        // 掛返品
                        item = new Infragistics.Win.ValueListItem(1, "掛返品");
                        item.Tag = 3;
                        this.tComboEditor_SalesSlipCd.Items.Add(item);

                        // 現金返品
                        item = new Infragistics.Win.ValueListItem(101, "現金返品");
                        item.Tag = 5;
                        this.tComboEditor_SalesSlipCd.Items.Add(item);
                    }
                    break;
                // それ以外は何もしない
                default:
                    {
                        this.tComboEditor_SalesSlipCd.Items.Clear();

                        // 全て
                        item = new Infragistics.Win.ValueListItem(-1, "全て");
                        this.tComboEditor_SalesSlipCd.Items.Add(item);

                        // 掛売上
                        item = new Infragistics.Win.ValueListItem(0, "掛売上");
                        this.tComboEditor_SalesSlipCd.Items.Add(item);

                        // 掛返品
                        item = new Infragistics.Win.ValueListItem(1, "掛返品");
                        this.tComboEditor_SalesSlipCd.Items.Add(item);

                        // 現金売上
                        item = new Infragistics.Win.ValueListItem(100, "現金売上");
                        this.tComboEditor_SalesSlipCd.Items.Add(item);

                        // 現金返品
                        item = new Infragistics.Win.ValueListItem(101, "現金返品");
                        this.tComboEditor_SalesSlipCd.Items.Add(item);
                    }
                    break; 
            }
        }
        // 2008.11.11 add end [7552]

        # endregion

        # region プライベート変数
        private SalesSlipSearchAcs _salesSlipSearchAcs;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private DateTime _baseDate = DateTime.MinValue;
        private ImageList _imageList16 = null;
        private ControlScreenSkin _controlScreenSkin;
        private DialogResult _dialogResult = DialogResult.Cancel;
        private SalesSlipSearch _para;
        private SalesSlipDataSet _dataSet;
        private SalesSlipSearchResult _selectedData = null;
        private SalesSearchConstructionAcs _salesSearchConstructionAcs;
        private ColDisplayStatusList _colDisplayStatusList = null;				// 列表示状態コレクションクラス
        private int _defaultAcceptAcptAnOdrStatus = 30;							//売上
        private bool _defaultAcceptAcptAnOdrStatusEnable = true;
        private int _startMovment = 0;											// 起動モード 0:エントリー 1:メニュー

        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;					// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _selectButton;					// 確定ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;					// 選択解除ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;					// 検索ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _setupButton;					// 設定ボタン
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginEmployeeLabel;			// ログイン担当者タイトル
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;				// ログイン担当者名称
        private int _startMode = 0;											// 起動モード 1:売上// ADD 2011/12/14 yangmj redmine#27359
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.09 TOKUNAGA ADD START
        // 拠点アクセスクラス
        SecInfoSetAcs _secInfoSetAcs;

        // 部門アクセスクラス
        SubSectionAcs _subSectionAcs;

        // 自社設定アクセスクラス
        CompanyInfAcs _companyAcs;

        // 得意先検索アクセスクラス
        CustomerInfoAcs _customerInfoAcs;

        // 自社設定データクラス
        //CompanyInf _conpamyInf;

        // 売上全体設定アクセスクラス
        SalesTtlStAcs _salesTtlStAcs;

        // 売上全体設定データクラス
        //SalesTtlSt _salesTtlSt;

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

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.09 TOKUNAGA ADD END

        // 2008.11.11 add start [7552]
        /// <summary>伝票区分抽出形式 0:全て 1:売上 2:返品</summary>
        private int _extractSlipCdType = 0;
        // 2008.11.11 add end [7552]

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
        // 全拠点名称
        private const string ct_AllSection = "全社";
        // 締日算出モジュール
        private TotalDayCalculator _totalDayCalculator;
        // 自動検索フラグ
        private bool _autoSearch;

        // ロード処理済みフラグ
        private bool _loaded;

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

        // 変則フォーカス制御
        private IrregularFocusControl _irrFocusCtrl;

        // 自動検索時初回フラグ
        private bool isFirstOfAutoSearch;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD

        private DateGetAcs _dateGet;

        // --- ADD 2009/01/29 障害ID:10621対応------------------------------------------------------>>>>>
        private bool _showEstimateInput = true;
        // --- ADD 2009/01/29 障害ID:10621対応------------------------------------------------------<<<<<

        // --- ADD 2009/02/12 障害ID:11416対応------------------------------------------------------>>>>>
        private SecInfoAcs _secInfoAcs;
        // --- ADD 2009/02/12 障害ID:11416対応------------------------------------------------------<<<<<

        # endregion

        #region ■ Private Const
        private const string ctFILENAME_COLDISPLAYSTATUS = "MAHNB04110U_ColSetting.DAT";	// 列表示状態セッティングXMLファイル名

        //エラー条件メッセージ
        const string ct_InputError = "の入力が不正です";
        const string ct_NoInput = "を入力して下さい";
        const string ct_RangeError = "の範囲指定に誤りがあります";
        const string ct_RangeOverError = "は３ヶ月の範囲内で入力して下さい";
        # endregion

        #region ■Properties
        /// <summary>
        /// 起動動作モード
        /// </summary>
        public int StartMovment
        {
            get { return this._startMovment; }
            set { this._startMovment = value; }
        }
        //-----ADD 2011/12/14 yangmj redmine#27359 ----->>>>>
        /// <summary>
        /// 起動モード
        /// </summary>
        public int StartMode
        {
            get { return this._startMode; }
            set { this._startMode = value; }
        }
        //-----ADD 2011/12/14 yangmj redmine#27359 -----<<<<<
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
        /// <summary>
        /// 自動検索フラグ
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
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD

        // --- ADD 2009/01/29 障害ID:7552,10621対応------------------------------------------------------>>>>>
        /// <summary>
        /// 伝票区分抽出形式
        /// </summary>
        public ExtractSlipCdType ExtractSlipCdType
        {
            get { return (ExtractSlipCdType)_extractSlipCdType; }
            set { _extractSlipCdType = (int)value; }
        }

        /// <summary>
        /// 検索見積表示区分
        /// </summary>
        public bool ShowEstimateInput
        {
            get { return _showEstimateInput; }
            set { _showEstimateInput = value; }
        }
        // --- ADD 2009/01/29 障害ID:7552,10621対応------------------------------------------------------<<<<<

        # endregion

        # region パブリックメソッド
        /// <summary>
        /// プロパティ
        /// </summary>
        public bool TComboEditor_SalesFormalCode
        {
            get { return this.tComboEditor_SalesFormalCode.Enabled; }
            set { this.tComboEditor_SalesFormalCode.Enabled = value; }

        }

        /// <summary>
        /// 売上伝票検索ガイドを起動します。
        /// </summary>
        /// <param name="owner">トップレベルウィンドウ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="data">売上データ検索結果オブジェクト</param>
        /// <returns>ダイアログボックスの戻り値</returns>
        public DialogResult ShowGuide(IWin32Window owner, string enterpriseCode, out SalesSlipSearchResult data)
        {
            this._enterpriseCode = enterpriseCode;
            this._defaultAcceptAcptAnOdrStatus = 30;
            this._defaultAcceptAcptAnOdrStatusEnable = true;
            data = null;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
            // 自動起動paraにセット
            this.AcptAnOdrStatus = _defaultAcceptAcptAnOdrStatus;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD

            DialogResult dialogResult = this.ShowDialog(owner);

            if (dialogResult == DialogResult.OK)
            {
                data = this._selectedData;
            }

            return dialogResult;
        }

        /// <summary>
        /// 売上伝票検索ガイドを起動します。
        /// </summary>
        /// <param name="owner">トップレベルウィンドウ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="acceptAcptAnOdrStatus">受注ステータス</param>
        /// <param name="data">売上データ検索結果オブジェクト</param>
        /// <returns>ダイアログボックスの戻り値</returns>
        public DialogResult ShowGuide(IWin32Window owner, string enterpriseCode, int acceptAcptAnOdrStatus, int estimateDivide, out SalesSlipSearchResult data)
        {
            this._enterpriseCode = enterpriseCode;

            //単価見積
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 DEL
            //if ((acceptAcptAnOdrStatus == 10) && (estimateDivide == 2))
            //{
            //    acceptAcptAnOdrStatus = 15;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
            if (acceptAcptAnOdrStatus == 10)
            {
                switch ( estimateDivide )
                {
                    case 2:
                        // 単価見積
                        acceptAcptAnOdrStatus = 15;
                        break;
                    case 3:
                        // 検索見積
                        acceptAcptAnOdrStatus = 16;
                        break;
                    case 1:
                    default:
                        // 見積
                        acceptAcptAnOdrStatus = 10;
                        break;
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD

            if ((acceptAcptAnOdrStatus == 10)
            || (acceptAcptAnOdrStatus == 15)
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
            || (acceptAcptAnOdrStatus == 16)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD
            || (acceptAcptAnOdrStatus == 20)
            || (acceptAcptAnOdrStatus == 30)
            || (acceptAcptAnOdrStatus == 40))
            {
                this._defaultAcceptAcptAnOdrStatus = acceptAcptAnOdrStatus;
                this._defaultAcceptAcptAnOdrStatusEnable = false;
            }
            else
            {
                this._defaultAcceptAcptAnOdrStatus = 30;
                this._defaultAcceptAcptAnOdrStatusEnable = true;
            }

            data = null;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
            // 自動起動paraにセット
            this.AcptAnOdrStatus = _defaultAcceptAcptAnOdrStatus;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD

            DialogResult dialogResult = this.ShowDialog(owner);

            if (dialogResult == DialogResult.OK)
            {
                data = this._selectedData;
            }

            return dialogResult;
        }
        # endregion

        # region プライベートメソッド
        /// <summary>
        /// 抽出条件の各種コントロールに値を設定します。
        /// </summary>
        /// <param name="para">売上データ検索条件パラメータオブジェクト</param>
        private void SetDisplayConditionInfo(SalesSlipSearch para)
        {
            // 売上伝票区分
            //0:売掛なし
            if (para.AccRecDivCd == 0)
            {
                switch (para.SalesSlipCd)
                {
                    // 2008.12.05 add start [8776]
                    case -1:
                        this.tComboEditor_SalesSlipCd.Value = -1;
                        break;
                    // 2008.12.05 add start [8776]
                    case 0:
                        this.tComboEditor_SalesSlipCd.Value = 100;
                        break;
                    case 1:
                        this.tComboEditor_SalesSlipCd.Value = 101;
                        break;
                    case 2:
                        this.tComboEditor_SalesSlipCd.Value = 102;
                        break;
                }
            }
            //1:売掛
            else
            {
                this.tComboEditor_SalesSlipCd.Value = para.SalesSlipCd;
            }

            // 伝票種別
            this.tComboEditor_SalesFormalCode.Value = para.AcptAnOdrStatus;
            //this.tComboEditor_SalesFormalCode.Enabled = this._defaultAcceptAcptAnOdrStatusEnable;
            Lb_SearchSlipDate_SetName((int)tComboEditor_SalesFormalCode.Value);

            // 売上伝票番号
            this.tEdit_SalesSlipNum_St.Text = para.SalesSlipNumSt.Trim();
            this.tEdit_SalesSlipNum_Ed.Text = para.SalesSlipNumEd.Trim();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.11 TOKUNAGA MODIFY START
            // 拠点コード
            //this._salesSlipSearchAcs.SetSectionComboEditorValue(this.tComboEditor_SalesInpSecCd, para.SectionCode);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
            //this.tEdit_SectionCodeAllowZero.Text = para.SectionCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
            this.tEdit_SectionCodeAllowZero.Text = para.SectionCode.TrimEnd();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            // --- CHG 2009/02/12 障害ID:11416対応------------------------------------------------------>>>>>
            //this.uLabel_SectionName.Text = para.SectionName;
            this.uLabel_SectionName.Text = "";

            // --- ADD 2009/03/06 -------------------------------->>>>>
            if (string.IsNullOrEmpty(para.SectionCode.Trim())
                || para.SectionCode.Trim().PadLeft(2, '0') == "00")
            {
                this.uLabel_SectionName.Text = "全社";
            }
            // --- ADD 2009/03/06 --------------------------------<<<<<
            else
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == para.SectionCode.Trim())
                    {
                        this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm.Trim();
                        break;
                    }
                }
            }
            // --- CHG 2009/02/12 障害ID:11416対応------------------------------------------------------<<<<<
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.11 TOKUNAGA MODIFY END			

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.11 TOKUNAGA ADD START
            //// 拠点コードから名称を取得する
            //SecInfoSet secInfoset;
            //int status = _secInfoSetAcs.Read(out secInfoset, this._enterpriseCode, para.SectionCode);
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    this.uLabel_SectionName.Text = secInfoset.SectionGuideNm.TrimEnd();
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.11 TOKUNAGA ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.11 TOKUNAGA MODIFY START
            this.tDateEdit_SalesDateSt.SetDateTime(para.SalesDateSt);			// 売上日(開始)
            this.tDateEdit_SalesDateEd.SetDateTime(para.SalesDateEd);			// 売上日(終了)
            this.tDateEdit_SearchSlipDateSt.SetDateTime(para.SearchSlipDateSt);	// 入力日(開始)
            this.tDateEdit_SearchSlipDateEd.SetDateTime(para.SearchSlipDateEd);	// 入力日(終了)

            this.tEdit_SalesEmployeeCd.Text = para.SalesEmployeeCd.Trim();				// 担当者コード
            this.uLabel_SalesEmployeeName.Text = para.SalesEmployeeName;				// 担当者名

            this.tEdit_SalesInputCode.Text = para.SalesInputCode.Trim();				// 発行者コード
            this.uLabel_SalesInputName.Text = para.SalesInputName;						// 発行者名

            this.tNedit_ClaimCode.SetInt(para.ClaimCode);								// 請求先コード
            this.uLabel_ClaimName.Text = para.ClaimName;								// 請求先名称

            this.tNedit_CustomerCode.SetInt(para.CustomerCode);							// 得意先コード
            this.uLabel_CustomerName.Text = para.CustomerName;							// 得意先名称
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.11 TOKUNAGA MODIFY END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.11 TOKUNAGA ADD START
            this.tEdit_FullModel.Text = para.FullModel;                                 // 絞込形式

            // 部署管理区分が拠点の時は部門コードは使用されない
            if (this._secMngDiv != DIV_MNG_SECTION)
            {
                this.tNedit_SubSectionCode.SetInt(para.SubSectionCode);                 // 部署コード
                this.uLabel_SubSectionName.Text = para.SubSectionName;                   // 部署名
                //SubSection subSection;
                //// 部門コードから名称を検索(paraオブジェクトに格納されていない)
                //status = _subSectionAcs.Read(out subSection, this._enterpriseCode, para.SectionCode, para.SubSectionCode);
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    this.uLabel_SectionName.Text = subSection.SubSectionName.TrimEnd();
                //}
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
            //// 受注者コード
            //this.tEdit_FrontEmployeeCd.Text = para.FrontEmployeeCd;
            // 
            //EmployeeAcs employeeAcs = new EmployeeAcs();
            //// 受注者コードから名称を検索(paraオブジェクトに格納されていない)
            //Employee employee;
            //status = employeeAcs.Read(out employee, this._enterpriseCode, para.FrontEmployeeCd);
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    this.uLabel_FrontEmployeeName.Text = employee.Name.TrimEnd();
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
            // 受注者コード
            this.tEdit_FrontEmployeeCd.Text = para.FrontEmployeeCd.Trim();
            // 受注者名
            this.uLabel_FrontEmployeeName.Text = para.FrontEmployeeName.Trim();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.11 TOKUNAGA ADD END
        }

        private DateTime ConvertInt2DateTime(Int32 SourceInt)
        {
            // 変換失敗
            if (SourceInt == 0 || SourceInt < 0)
            {
                return DateTime.Now;
            }


            string strConvertSrc;

            // 変換
            if (SourceInt.ToString().Length == 5)
            {
                strConvertSrc = "0" + SourceInt.ToString();
            }
            else
            {
                strConvertSrc = SourceInt.ToString();
            }

            return new DateTime(int.Parse(strConvertSrc.Substring(0, 2)), int.Parse(strConvertSrc.Substring(3, 2)), int.Parse(strConvertSrc.Substring(5, 2)));

        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            if (this._para.CustomerCode != customerSearchRet.CustomerCode)
            {
                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                CustomerInfo customerInfo = new CustomerInfo();

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
                //int status = customerInfoAcs.ReadDBData(_enterpriseCode, customerSearchRet.CustomerCode, out customerInfo);
                //if ((status == 0) && ((customerInfo.IsCustomer == true) || (customerInfo.IsReceiver == true)))
                //{
                //    this._para.CustomerCode = customerSearchRet.CustomerCode;
                //    this._para.CustomerName = customerSearchRet.Name + " " + customerSearchRet.Name2;

                //    // 抽出条件の各種コントロールに値を設定する。
                //    this.SetDisplayConditionInfo(this._para);
                //}
                //else
                //{
                //    TMsgDisp.Show(
                //        this,
                //        emErrorLevel.ERR_LEVEL_INFO,
                //        this.Name,
                //        "仕入先は入力できません。",
                //        -1,
                //        MessageBoxButtons.OK);
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
                this._para.CustomerCode = customerSearchRet.CustomerCode;
                this._para.CustomerName = customerSearchRet.Name + " " + customerSearchRet.Name2;

                // 抽出条件の各種コントロールに値を設定する。
                this.SetDisplayConditionInfo( this._para );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            }
        }

        /// <summary>
        /// 請求先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        private void CustomerSearchForm_ClaimSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            if (this._para.ClaimCode != customerSearchRet.CustomerCode)
            {
                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                CustomerInfo customerInfo = new CustomerInfo();

                int status = customerInfoAcs.ReadDBData(_enterpriseCode, customerSearchRet.CustomerCode, out customerInfo);
                if ((status == 0) && ((customerInfo.IsCustomer == true) || (customerInfo.IsReceiver == true)))
                {
                    this._para.ClaimCode = customerSearchRet.CustomerCode;
                    this._para.ClaimName = customerSearchRet.Name + " " + customerSearchRet.Name2;
                    // 抽出条件の各種コントロールに値を設定する。
                    this.SetDisplayConditionInfo(this._para);
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

        /// <summary>
        /// 最上位の親フォームオブジェクトを取得します。
        /// </summary>
        /// <returns>最上位の親フォームオブジェクト</returns>
        private Form GetTopLevelOwnerForm()
        {
            bool exists = true;
            Form ownerForm = this.Owner;

            while (exists)
            {
                if (ownerForm == null)
                {
                    break;
                }
                if ((ownerForm.Owner != null) && (ownerForm.Owner is Form))
                {
                    ownerForm = ownerForm.Owner;
                }
                else
                {
                    break;
                }
            }

            return ownerForm;
        }

        /// <summary>
        /// 売上データの検索を行います。
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Update Note      :   鄧潘ハン BLﾊﾟｰﾂｵｰﾀﾞｰ在庫確認時の見積伝票対応</br>
        /// <br>Date             :   2011/11/11</br>
        private int Search(SalesSlipSearch para)
        {

            //---ADD 2011/11/11 ---------------------------------------->>>>>
            if (this.tComboEditor_AutoAnswerDivSCM.SelectedIndex == 0)
            {
                //連携伝票出力区分
                para.AutoAnswerDivSCM = 0;
                para.AcceptOrOrderKind = -1;
            }
            else
            {
                //連携伝票出力区分
                if (this.tComboEditor_AutoAnswerDivSCM.SelectedIndex == 1)
                {
                    para.AutoAnswerDivSCM = 1;
                }
                else
                {
                    para.AutoAnswerDivSCM = 2;
                }
                //連携伝票対象区分
                if (this.uCheckEditor_PccForNS.Checked == true && this.uCheckEditor_BlPaCOrder.Checked == false)
                {
                    para.AcceptOrOrderKind = 0;
                }
                else if (this.uCheckEditor_PccForNS.Checked == false && this.uCheckEditor_BlPaCOrder.Checked == true)
                {
                    para.AcceptOrOrderKind = 1;
                }
                else if (this.uCheckEditor_PccForNS.Checked == true && this.uCheckEditor_BlPaCOrder.Checked == true)
                {
                    para.AcceptOrOrderKind = 2;
                }
                else
                {
                    para.AcceptOrOrderKind = -1;
                }
            }
            //---ADD 2011/11/11 ----------------------------------------<<<<<
            
            // --- CHG 2009/01/29 障害ID:7552,10621対応------------------------------------------------------>>>>>
            //int status = this._salesSlipSearchAcs.Search(para);
            int status = this._salesSlipSearchAcs.Search(para, this._extractSlipCdType, this._showEstimateInput);
            // --- CHG 2009/01/29 障害ID:7552,10621対応------------------------------------------------------<<<<<

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //セル毎の設定
                this.uGrid_Result_InitializeLayout(this, null);
                // 売上データグリッドの行、セル毎の設定を行います。
                this.SettingGridRow();

                if (this.uGrid_Result.Rows.Count > 0)
                {
                    this.uGrid_Result.ActiveRow = this.uGrid_Result.Rows[0];
                    this.uGrid_Result.ActiveRow.Selected = true;
                }

                // 2008.11.07 add start [7071]
                string sSort;
                // 2008.11.07 add start [8722]
                //sSort = "SlipDateString Desc, SearchSlipNum Desc";
                sSort = "RowNo Asc";
                // 2008.11.07 add end [8722]
                DataView dv = (DataView)this.uGrid_Result.DataSource;
                dv.Sort = sSort;

                // 2008.11.07 add end [7071]
            }
            else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                if ( !isFirstOfAutoSearch )
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "該当データが存在しません。",
                        -1,
                        MessageBoxButtons.OK );
                }
                isFirstOfAutoSearch = false;
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "売上データの取得に失敗しました。",
                    status,
                    MessageBoxButtons.OK);
            }

            return status;
        }

        /// <summary>
        /// 画面を初期化します。
        /// <br>Update Note      : 2010/12/21 鄧潘ハン</br>
        /// <br>                   ①クリア処理後のフォーカス制御変更</br>
        /// </summary>
        private void Clear()
        {
            this._para = new SalesSlipSearch();
            this._para.EnterpriseCode = this._enterpriseCode;
            // modify 2008.11.07 start
            if (String.IsNullOrEmpty(this.SectionCode))
            {
                this._para.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            }
            else
            {
                this._para.SectionCode = this.SectionCode;
            }
            //this._para.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            // modify 2008.11.07 end

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
            this._para.SectionName = this.GetSectionName( this._para.SectionCode );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            this._para.AccRecDivCd = 1;

            this._para.AcptAnOdrStatus = _defaultAcceptAcptAnOdrStatus;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //this._para.SearchSlipDateSt = DateTime.Today;
            //this._para.SearchSlipDateEd = DateTime.Today;
            //this._para.SalesDateSt = DateTime.MinValue;
            //this._para.SalesDateEd = DateTime.MinValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            this._para.SalesDateSt = this.GetPrevTotalDayNextDay( _para.SectionCode );
            this._para.SalesDateEd = DateTime.Today;
            this._para.SearchSlipDateSt = DateTime.MinValue;
            this._para.SearchSlipDateEd = DateTime.MinValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL

            //伝票区分を設定
            // --- CHG 2009/01/29 障害ID:7552対応------------------------------------------------------>>>>>
            //this._salesSlipSearchAcs.SetSalesSlipCdComboEditor(ref tComboEditor_SalesSlipCd, this._para.AcptAnOdrStatus);
            this._salesSlipSearchAcs.SetSalesSlipCdComboEditor(ref tComboEditor_SalesSlipCd, this._para.AcptAnOdrStatus, (SalesSlipSearchAcs.ExtractSlipCdType)this._extractSlipCdType);
            // --- CHG 2009/01/29 障害ID:7552対応------------------------------------------------------<<<<<
            _para.SalesSlipCd = 0;

            this.SetDisplayConditionInfo(this._para);

            this._salesSlipSearchAcs.Clear();
            this.tEdit_SectionCodeAllowZero.Focus();// ADD 2010/12/21
            this.tEdit_SectionCodeAllowZero.SelectAll();// ADD 2010/12/21
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
        /// <summary>
        /// 前回月次締処理日取得
        /// </summary>
        /// <returns></returns>
        private DateTime GetPrevTotalDayNextDay(string sectionCode)
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
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        private string GetSectionName( string sectionCode )
        {
            if ( _secInfoSetAcs == null )
            {
                _secInfoSetAcs = new SecInfoSetAcs();
            }
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.Read( out sectionInfo, this._enterpriseCode, sectionCode );
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                return sectionInfo.SectionGuideNm;
            }
            else
            {
                return string.Empty;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD

        /// <summary>
        /// 売上データグリッドの行、セル毎の設定を行います。
        /// </summary>
        private void SettingGridRow()
        {
            try
            {
                // 描画を一時停止
                this.uGrid_Result.BeginUpdate();

                // 描画が必要な明細件数を取得する。
                int cnt = this.uGrid_Result.Rows.Count;

                // 各行ごとの設定
                for (int i = 0; i < cnt; i++)
                {
                    this.SettingGridRow(i);
                }
            }
            finally
            {
                // 描画を開始
                this.uGrid_Result.EndUpdate();
            }
        }

        /// <summary>
        /// 明細グリッド・行単位でのセル設定
        /// </summary>
        /// <param name="rowIndex">対象行インデックス</param>
        private void SettingGridRow(int rowIndex)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Result.DisplayLayout.Bands[0];
            if (editBand == null) return;

            // 赤伝区分を取得
            int debitNoteDiv = Convert.ToInt32(this._salesSlipSearchAcs.DataView[rowIndex][this._dataSet.SalesSlip.DebitNoteDivColumn.ColumnName]);

            //>>>2010/07/27
            // 指定行の全ての列に対して設定を行う。
            //foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            //{
            //    // セル情報を取得
            //    Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Result.Rows[rowIndex].Cells[col];
            //    if (cell == null) continue;

            //    switch (debitNoteDiv)
            //    {
            //        case 0:			// 黒伝
            //            {
            //                cell.Appearance.ForeColor = Color.Black;
            //                break;
            //            }
            //        case 1:			// 赤伝
            //            {
            //                cell.Appearance.ForeColor = Color.Red;
            //                break;
            //            }
            //        case 2:			// 元黒
            //            {
            //                cell.Appearance.ForeColor = Color.Gray;
            //                break;
            //            }
            //    }
            //}

            Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Result.DisplayLayout.Rows[rowIndex];
            switch (debitNoteDiv)
            {
                case 0:			// 黒伝
                    {
                        row.Appearance.ForeColor = Color.Black;
                        break;
                    }
                case 1:			// 赤伝
                    {
                        row.Appearance.ForeColor = Color.Red;
                        break;
                    }
                case 2:			// 元黒
                    {
                        row.Appearance.ForeColor = Color.Gray;
                        break;
                    }
            }
            //<<<2010/07/27
        }

        /// <summary>
        /// 選択済みデータを取得します。
        /// </summary>
        /// <returns>選択済みデータ</returns>
        private SalesSlipSearchResult GetSelectedData()
        {
            // 選択行のインデックスを取得
            CurrencyManager cm = (CurrencyManager)BindingContext[this.uGrid_Result.DataSource];
            int index = cm.Position;

            DataView dataView = (DataView)this.uGrid_Result.DataSource;

            if (index >= 0)
            {
                SalesSlipSearchResult data = SalesSlipSearchAcs.CreateUIDataFromParamData(
                    (SalesSlipSearchResultWork)dataView[index][this._dataSet.SalesSlip.SalesSlipSearchResultWorkColumn.ColumnName]);

                return data;
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// ユーザー設定値変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void SalesSearchConstructionAcs_DataChanged(object sender, EventArgs e)
        {
            //
        }

        /// <summary>
        /// 列表示状態クラスリストを構築します。
        /// </summary>
        /// <param name="columns">グリッドのカラムコレクション</param>
        /// <returns>列表示状態クラスリスト</returns>
        private List<ColDisplayStatus> ColDisplayStatusListConstruction(Infragistics.Win.UltraWinGrid.ColumnsCollection columns)
        {
            List<ColDisplayStatus> colDisplayStatusList = new List<ColDisplayStatus>();

            // グリッドから列表示状態クラスリストを構築
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in columns)
            {
                ColDisplayStatus colDisplayStatus = new ColDisplayStatus();

                colDisplayStatus.Key = column.Key;
                colDisplayStatus.VisiblePosition = column.Header.VisiblePosition;
                colDisplayStatus.HeaderFixed = column.Header.Fixed;
                colDisplayStatus.Width = column.Width;

                colDisplayStatusList.Add(colDisplayStatus);
            }

            return colDisplayStatusList;
        }

        // ADD 2008/11/05 不具合対応[7070] 売上全体設定マスタの発行者区分を参照 ※メソッドとして抽出 ---------->>>>>
        /// <summary>
        /// 売上全体設定マスタより発行者表示区分を取得し、保持します。
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        private void SetInpAgentDispDivFromSalesTtlSt(string sectionCode)
        {
            #region <Guard Phrase/>

            if (string.IsNullOrEmpty(sectionCode.Trim()))
            {
                this._inpAgentDispDiv = INP_AGT_DISP;
                return;
            }

            #endregion  // <Guard Phrase/>

            // 売上全体設定を取得
            // TODO このSearchAllは将来的にSearchメソッドに変わる可能性あり。
            ArrayList retSalesTtlSt;
            if (this._salesTtlStAcs == null) this._salesTtlStAcs = new SalesTtlStAcs();

            int status = _salesTtlStAcs.SearchAll(out retSalesTtlSt, this._enterpriseCode);

            if (status.Equals((int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                foreach (SalesTtlSt salesTtlSt in retSalesTtlSt)
                {
                    if (salesTtlSt.SectionCode.Trim().Equals(sectionCode.Trim()))
                    {
                        // 0:する　1:しない　 2:必須
                        this._inpAgentDispDiv = salesTtlSt.InpAgentDispDiv;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 発行者UIを隠します。
        /// </summary>
        /// <param name="hidden">隠すフラグ</param>
        /// <br>Update Note      :   鄧潘ハン BLﾊﾟｰﾂｵｰﾀﾞｰ在庫確認時の見積伝票対応</br>
        /// <br>Date             :   2011/11/11</br>
        private void HideSalesInputUI(bool hidden)
        {
            // 発行者ラベル
            this.ultraLabel12.Enabled = !hidden;
            this.ultraLabel12.Visible = !hidden;

            // 発行者コード
            this.tEdit_SalesInputCode.Enabled = !hidden;
            this.tEdit_SalesInputCode.Visible = !hidden;

            // 発行者名
            this.uLabel_SalesInputName.Enabled = !hidden;
            this.uLabel_SalesInputName.Visible = !hidden;

            // 発行者コードのガイド
            this.uButton_SalesInputGuide.Enabled = !hidden;
            this.uButton_SalesInputGuide.Visible = !hidden;
        }
        // ADD 2008/11/05 不具合対応[7070] 売上全体設定マスタの発行者区分を参照 ※メソッドとして抽出 ----------<<<<<

        # endregion

        # region 各種コントロールイベント処理
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
        /// <summary>
        /// ロード処理
        /// </summary>
        private void Loading()
        {
            if ( _loaded ) return;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.09 TOKUNAGA ADD START
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
                    this.ultraLabel14.Visible = false;
                    this.tNedit_SubSectionCode.Visible = false;
                    this.ultraButton_SubSectionGuide.Visible = false;
                    this.uLabel_SubSectionName.Visible = false;
                }
            }

            //---ADD 2011/11/11 ----------------------------->>>>>
            //連携伝票出力区分のデフォルト選択は"連携伝票を含まない"
            this.tComboEditor_AutoAnswerDivSCM.SelectedIndex = 0;
            //連携伝票対象区分
            this.uCheckEditor_PccForNS.Enabled = false;
            this.uCheckEditor_BlPaCOrder.Enabled = false;
            //---ADD 2011/11/11 -----------------------------<<<<<

            // 自拠点コードを取得
            //SecInfoSet secInfoSet;
            //SecInfoSetAcs secInfoAcs = new SecInfoSetAcs();
            //secInfoAcs.GetSecInfo(SecInfoSetAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);
            //this._sectionCode = secInfoSet.SectionCode.TrimEnd();
            //if (String.IsNullOrEmpty(this.SectionCode))
            //{
                this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            //}
            //else
            //{
            //    this._sectionCode = this.SectionCode.Trim();
            //}
            //this._dspSectionCode = secInfoSet.SectionCode.TrimEnd();


            // 売上全体設定を取得
            // DEL 2008/11/05 不具合対応[7070] 売上全体設定マスタの発行者区分を参照 ※メソッドとして抽出 ---------->>>>>
            #region 削除コード
            //// TODO このSearchAllは将来的にSearchメソッドに変わる可能性あり。
            //ArrayList retSalesTtlSt;
            //this._salesTtlStAcs = new SalesTtlStAcs();
            //int status = _salesTtlStAcs.SearchAll( out retSalesTtlSt, this._enterpriseCode );

            //if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            //{
            //    foreach ( SalesTtlSt salesTtlSt in retSalesTtlSt )
            //    {
            //        if ( salesTtlSt.SectionCode.Trim() == this._sectionCode.Trim() )
            //        {
            //            // 0:する　1:しない　 2:必須
            //            this._inpAgentDispDiv = salesTtlSt.InpAgentDispDiv;
            //            break;
            //        }
            //    }
            //}
            #endregion  // 削除コード
            // DEL 2008/11/05 不具合対応[7070] 売上全体設定マスタの発行者区分を参照 ※メソッドとして抽出 ----------<<<<<
            // ADD 2008/11/05 不具合対応[7070]↓ 売上全体設定マスタの発行者区分を参照 ※メソッドとして抽出
            SetInpAgentDispDivFromSalesTtlSt(this._sectionCode);

            // ボタンイメージを設定
            this.SectionCodeGuide_ultraButton.ImageList = this._imageList16;
            this.SectionCodeGuide_ultraButton.Appearance.Image = (int)Size16_Index.STAR1;

            this.ultraButton_SubSectionGuide.ImageList = this._imageList16;
            this.ultraButton_SubSectionGuide.Appearance.Image = (int)Size16_Index.STAR1;

            this.uButton_FrontEmployeeCd.ImageList = this._imageList16;
            this.uButton_FrontEmployeeCd.Appearance.Image = (int)Size16_Index.STAR1;

            // デフォルト値をクリア
            this.tEdit_FullModel.Clear();


            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.09 TOKUNAGA ADD END

            this.uButton_SalesEmployeeGuide.ImageList = this._imageList16;
            this.uButton_SalesInputGuide.ImageList = this._imageList16;
            this.uButton_CustomerGuide.ImageList = this._imageList16;
            this.uButton_ClaimGuide.ImageList = this._imageList16;

            this.uButton_SalesEmployeeGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_SalesInputGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_CustomerGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_ClaimGuide.Appearance.Image = (int)Size16_Index.STAR1;

            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._selectButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            this._setupButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;
            this._loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;

            this._salesSlipSearchAcs.ReadInitData( this._enterpriseCode );

            // スキンロード
            List<string> controlNameList = new List<string>();
            //controlNameList.Add( this.groupBox_ExtractCondition1.Name );
            //controlNameList.Add( this.groupBox_ExtractCondition2.Name );
            controlNameList.Add(this.ultraExpandableGroupBox1.Name);
            //controlNameList.Add(this.groupBox_ExtractCondition3.Name);
            //controlNameList.Add(this.groupBox_ExtractCondition4.Name);
            //controlNameList.Add(this.groupBox_ExtractCondition5.Name);
            //controlNameList.Add(this.groupBox_ExtractCondition6.Name);
            this._controlScreenSkin.SetExceptionCtrl( controlNameList );
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin( this );

            // スキンクラスで対応できないコントロールのカラーを設定する
            try
            {
                CustomUltraGridAppearance gridAppearance = this._controlScreenSkin.GetGridAppearance().Clone();
                //this.uLabel_ExtractConditionTitle.Appearance.BackColor = gridAppearance.GridHeaderAppearance.BackColor;
                //this.uLabel_ExtractConditionTitle.Appearance.BackColor2 = gridAppearance.GridHeaderAppearance.BackColor2;
                //this.uLabel_ExtractConditionTitle.Appearance.BackGradientStyle = gridAppearance.GridHeaderAppearance.BackGradientStyle;
                //this.uLabel_ExtractConditionTitle.Appearance.ForeColor = gridAppearance.GridHeaderAppearance.ForeColor;
                //this.panel_ExtractConditionTitleTitle.BackColor = gridAppearance.GridHeaderAppearance.BackColor2;
            }
            catch ( NullReferenceException ) { }

            // 最上位の親フォームオブジェクトを取得します。
            Form ownerForm = this.GetTopLevelOwnerForm();

            if ( ownerForm != null )
            {
                //if ((ownerForm.Height < this.Height) && (ownerForm.Width < this.Width)) return;

                //int afterHeight = Convert.ToInt32(ownerForm.Height * 0.95);
                //int afterWidth = Convert.ToInt32(ownerForm.Width * 0.95);
                int afterHeight = Convert.ToInt32( ownerForm.Height );
                int afterWidth = Convert.ToInt32( ownerForm.Width );

                int afterTop = Convert.ToInt32( ownerForm.Top + ((ownerForm.Height - afterHeight) * 0.5) );
                int afterLeft = Convert.ToInt32( ownerForm.Left + ((ownerForm.Width - afterWidth) * 0.5) );

                this.Size = new Size( afterWidth, afterHeight );
                this.Location = new Point( afterLeft, afterTop );
            }

            //this._salesSlipSearchAcs.SetSectionComboEditor(ref this.tComboEditor_SalesInpSecCd, true);


            this._salesSlipSearchAcs.DataView.Sort = "EnterpriseCode, SearchSlipNum DESC";
            this.uGrid_Result.DataSource = this._salesSlipSearchAcs.DataView;   // MEMO:グリッドにバインド

            /// 画面を初期化する。
            this.Clear();

            // グリッド設定
            this.uGrid_Result_InitializeLayout(this, null);

            this.timer_InitFocusSetting.Enabled = true;

            if ( (this._defaultAcceptAcptAnOdrStatus == 20)
            || (this._defaultAcceptAcptAnOdrStatus == 30)
            || (this._defaultAcceptAcptAnOdrStatus == 10)
            || (this._defaultAcceptAcptAnOdrStatus == 15)
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
            || (this._defaultAcceptAcptAnOdrStatus == 16)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD
            || (this._defaultAcceptAcptAnOdrStatus == 40) )
            {
                this._para.AcptAnOdrStatus = this._defaultAcceptAcptAnOdrStatus;

                // 抽出条件の各種コントロールに値を設定する。
                this.SetDisplayConditionInfo( this._para );
            }

            // 動作設定の設定を反映する
            if ( this._salesSearchConstructionAcs.ExecAutoSearchValue == SalesSearchConstructionAcs.ExecAutoSearch_ON )
            {
                this.timer_Search.Enabled = true;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //this.tEdit_SectionCodeAllowZero.Focus();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            // 確定ボタンEnable設定
            ChangeDecisionButtonEnable( StartMovment == 0 );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD

            _loaded = true;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD

        /// <summary>
        /// 売上データ検索ガイドロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void MAHNB04110UA_Load(object sender, EventArgs e)
        {
            // --- ADD 2009/01/29 障害ID:10621対応------------------------------------------------------>>>>>
            // 伝票種別設定
            this.tComboEditor_SalesFormalCode.Items.Clear();
            if (this._showEstimateInput)
            {
                this.tComboEditor_SalesFormalCode.Items.Add(30, "売上");
                this.tComboEditor_SalesFormalCode.Items.Add(40, "貸出");
                this.tComboEditor_SalesFormalCode.Items.Add(20, "受注");
                this.tComboEditor_SalesFormalCode.Items.Add(10, "通常見積");
                this.tComboEditor_SalesFormalCode.Items.Add(15, "単価見積");
                this.tComboEditor_SalesFormalCode.Items.Add(16, "検索見積");
                this.tComboEditor_SalesFormalCode.Items.Add(-1, "全て");
            }
            else
            {
                this.tComboEditor_SalesFormalCode.Items.Add(30, "売上");
                this.tComboEditor_SalesFormalCode.Items.Add(40, "貸出");
                this.tComboEditor_SalesFormalCode.Items.Add(20, "受注");
                this.tComboEditor_SalesFormalCode.Items.Add(10, "通常見積");
                this.tComboEditor_SalesFormalCode.Items.Add(15, "単価見積");
                this.tComboEditor_SalesFormalCode.Items.Add(-1, "全て");
            }
            // --- ADD 2009/01/29 障害ID:10621対応------------------------------------------------------<<<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Loading();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
        }

        /// <summary>
        /// 担当者ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_SalesEmployeeGuide_Click(object sender, EventArgs e)
        {
            EmployeeAcs employeeAcs = new EmployeeAcs();
            Employee employee;
            int status = employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (this._para.SalesEmployeeCd.Trim() != employee.EmployeeCode.Trim()))
            {
                this._para.SalesEmployeeCd = employee.EmployeeCode.Trim();
                this._para.SalesEmployeeName = employee.Name;

                // 抽出条件の各種コントロールに値を設定します。
                this.SetDisplayConditionInfo(this._para);

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                // 次フォーカス
                if ( tEdit_SalesInputCode.Enabled )
                {
                    tEdit_SalesInputCode.Focus();
                }
                else if ( tEdit_FrontEmployeeCd.Enabled )
                {
                    tEdit_FrontEmployeeCd.Focus();
                }
                else
                {
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            }
        }

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
                this._para.GoodsMakerCd = makerUMnt.GoodsMakerCd;
                this._para.MakerName = makerUMnt.MakerName.Trim();

                // 抽出条件の各種コントロールに値を設定します。
                this.SetDisplayConditionInfo(this._para);
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

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (this._para.SalesInputCode.Trim() != employee.EmployeeCode.Trim()))
            {
                this._para.SalesInputCode = employee.EmployeeCode.Trim();
                this._para.SalesInputName = employee.Name;

                // 抽出条件の各種コントロールに値を設定する。
                this.SetDisplayConditionInfo(this._para);

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                // 次フォーカス
                if ( tEdit_FrontEmployeeCd.Enabled )
                {
                    tEdit_FrontEmployeeCd.Focus();
                }
                else
                {
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            }
        }

        /// <summary>
        /// 得意先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note      :   2015/05/08 gaocheng</br>
        /// <br>管理番号         :   11175085-00</br>
        /// <br>                 :   Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正</br> 
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.15 TOKUNAGA MODIFY START
            // 得意先ガイド用ライブラリ名変更
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);	// 得意先検索アクセスクラス
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            DialogResult ret = customerSearchForm.ShowDialog(this);
            if (ret == DialogResult.OK)
            {
                this.SetDisplayConditionInfo(this._para);
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                // 次フォーカス
                if ( tNedit_ClaimCode.Enabled )
                {
                    tNedit_ClaimCode.Focus();
                }
                // else // DEL gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正 
                else if (tComboEditor_SalesFormalCode.Enabled) // ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合
                {
                    tComboEditor_SalesFormalCode.Focus();
                }
                //---- ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正 ---->>>>>
                else
                {
                    tComboEditor_SalesSlipCd.Focus();
                }
                //---- ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正 ----<<<<<
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.15 TOKUNAGA MODIFY END

            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_AND_EDIT);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            //customerSearchForm.ShowDialog(this);
        }

        /// <summary>
        /// 請求先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note : 2015/05/08 gaocheng</br>
        /// <br>管理番号    : 11175085-00</br>
        /// <br>            : Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正</br>
        private void uButton_ClaimGuide_Click(object sender, EventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.15 TOKUNAGA MODIFY START
            // 請求先ガイド用ライブラリ名変更
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);	// 請求先検索アクセスクラス
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_ClaimSelect);
            DialogResult ret = customerSearchForm.ShowDialog(this);
            if (ret == DialogResult.OK)
            {
                this.SetDisplayConditionInfo(this._para);
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
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
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.15 TOKUNAGA MODIFY END

            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_AND_EDIT);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_ClaimSelect);
            //customerSearchForm.ShowDialog(this);
        }


        /// <summary>
        /// 商品ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_GoodsGuide_Click(object sender, EventArgs e)
        {
            MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

            GoodsUnitData goodsUnitData;
            GoodsCndtn para = new GoodsCndtn();
            para.EnterpriseCode = this._enterpriseCode;

            DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, true, para, out goodsUnitData);

            if ((dialogResult == DialogResult.OK) && (goodsUnitData != null) && (this._para.GoodsNo.Trim() != goodsUnitData.GoodsNo.Trim()))
            {
                this._para.GoodsNo = goodsUnitData.GoodsNo;
                this._para.GoodsName = goodsUnitData.GoodsName;

                // 抽出条件の各種コントロールに値を設定する。
                this.SetDisplayConditionInfo(this._para);
            }
        }

        /// <summary>
        /// フォーカスコントロールイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note      :   鄧潘ハン BLﾊﾟｰﾂｵｰﾀﾞｰ在庫確認時の見積伝票対応</br>
        /// <br>Date             :   2011/11/11</br>
        /// <br>Update Note      :   2015/05/08 gaocheng</br>
        /// <br>管理番号         :   11175085-00</br>
        /// <br>                 :   Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正</br>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            SalesSlipSearch para = this._para.Clone();

            switch (e.PrevCtrl.Name)
            {
                // 伝票区分
                case "tComboEditor_SalesSlipCd":
                    {
                        int code = Convert.ToInt32(this.tComboEditor_SalesSlipCd.Value);

                        if (para.SalesSlipCd != code)
                        {
                            para.SalesSlipCd = Convert.ToInt32(this.tComboEditor_SalesSlipCd.Value);

                            //掛あり
                            if ((para.SalesSlipCd == 0) || (para.SalesSlipCd == 1))
                            {
                                para.AccRecDivCd = 1;
                            }
                            //現金
                            else
                            {
                                para.AccRecDivCd = 0;
                            }

                            // 抽出条件の各種コントロールに値を設定する。
                            this.SetDisplayConditionInfo(para);
                        }

                        break;
                    }
                // 伝票種別
                case "tComboEditor_SalesFormalCode":
                    {
                        int code = Convert.ToInt32(this.tComboEditor_SalesFormalCode.Value);

                        if (para.AcptAnOdrStatus != code)
                        {
                            //伝票区分を設定
                            //this._salesSlipSearchAcs.SetSalesSlipCdComboEditor(ref tComboEditor_SalesSlipCd, code);
                            // 2008.12.05 modify start [8776]
                            int acptStatus = Convert.ToInt32(this.tComboEditor_SalesFormalCode.Value);
                            if (acptStatus == 16)
                            {
                                // 検索見積の時のみ「全て」以外は選択不能
                                para.SalesSlipCd = -1;
                            }
                            else
                            {
                                para.SalesSlipCd = 0;
                            }
                            para.AccRecDivCd = 1;

                            para.AcptAnOdrStatus = acptStatus;// Convert.ToInt32(this.tComboEditor_SalesFormalCode.Value);
                            // 2008.12.05 modify end [8776]

                            // 抽出条件の各種コントロールに値を設定する。
                            this.SetDisplayConditionInfo(para);
                        }

                        break;
                    }
                // 伝票番号（開始）
                case "tEdit_SalesSlipNum_St":
                    {
                        string code = this.tEdit_SalesSlipNum_St.Text.Trim();

                        if (para.SalesSlipNumSt.Trim() != code)
                        {
                            para.SalesSlipNumSt = this.tEdit_SalesSlipNum_St.Text;

                            // 抽出条件の各種コントロールに値を設定する。
                            this.SetDisplayConditionInfo(para);
                        }

                        break;
                    }
                // 伝票番号（終了）
                case "tEdit_SalesSlipNum_Ed":
                    {
                        string code = this.tEdit_SalesSlipNum_Ed.Text.Trim();

                        if (para.SalesSlipNumEd.Trim() != code)
                        {
                            para.SalesSlipNumEd = this.tEdit_SalesSlipNum_Ed.Text;

                            // 抽出条件の各種コントロールに値を設定する。
                            this.SetDisplayConditionInfo(para);
                        }

                        break;
                    }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
                //// 得意先注番
                //case "tEdit_PartySaleSlipNum":
                //    {
                //        string code = this.tEdit_PartySaleSlipNum.Text.Trim();

                //        if (para.PartySaleSlipNum.Trim() != code)
                //        {
                //            para.PartySaleSlipNum = this.tEdit_PartySaleSlipNum.Text;

                //            // 抽出条件の各種コントロールに値を設定する。
                //            this.SetDisplayConditionInfo(para);
                //        }

                //        break;
                //    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL

                // 伝票日付（開始）
                case "tDateEdit_SalesDateSt":
                    {
                        DateTime date = this.tDateEdit_SalesDateSt.GetDateTime();
                        if (para.SalesDateSt != date)
                        {
                            para.SalesDateSt = date;

                            // 抽出条件の各種コントロールに値を設定する。
                            this.SetDisplayConditionInfo(para);
                        }

                        break;
                    }
                // 伝票日付（終了）
                case "tDateEdit_SalesDateEd":
                    {
                        DateTime date = this.tDateEdit_SalesDateEd.GetDateTime();
                        if (para.SalesDateEd != date)
                        {
                            para.SalesDateEd = date;

                            // 抽出条件の各種コントロールに値を設定する。
                            this.SetDisplayConditionInfo(para);
                        }

                        break;
                    }
                // 入力日（開始）
                case "tDateEdit_SearchSlipDateSt":
                    {
                        DateTime date = this.tDateEdit_SearchSlipDateSt.GetDateTime();
                        if (para.SearchSlipDateSt != date)
                        {
                            para.SearchSlipDateSt = date;

                            // 抽出条件の各種コントロールに値を設定する。
                            this.SetDisplayConditionInfo(para);
                        }

                        break;
                    }
                // 入力日（終了）
                case "tDateEdit_SearchSlipDateEd":
                    {
                        DateTime date = this.tDateEdit_SearchSlipDateEd.GetDateTime();
                        if (para.SearchSlipDateEd != date)
                        {
                        para.SearchSlipDateEd = date;

                            // 抽出条件の各種コントロールに値を設定する。
                            this.SetDisplayConditionInfo(para);
                        }

                        break;
                    }
                // 担当者コード
                case "tEdit_SalesEmployeeCd":
                    {
                        bool canChangeFocus = true;
                        string code = this.tEdit_SalesEmployeeCd.Text.Trim();

                        if (para.SalesEmployeeCd.Trim() != code)
                        {
                            if (code == "")
                            {
                                para.SalesEmployeeCd = "";
                                para.SalesEmployeeName = "";
                            }
                            else
                            {
                                Employee data;
                                int status = this._salesSlipSearchAcs.GetEmployee(this._enterpriseCode, code, out data);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    para.SalesEmployeeCd = data.EmployeeCode;
                                    para.SalesEmployeeName = data.Name;
                                }
                                else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当する従業員が存在しません。",
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "従業員名称の取得に失敗しました。",
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                            }

                            // 抽出条件の各種コントロールに値を設定する。
                            this.SetDisplayConditionInfo(para);

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
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
                            //                    if (this.tEdit_SalesEmployeeCd.Text == "")
                            //                    {
                            //                        e.NextCtrl = this.uButton_SalesEmployeeGuide;
                            //                    }
                            //                    else
                            //                    {
                            //                        e.NextCtrl = this.tEdit_SalesInputCode;
                            //                    }
                            //                    break;
                            //                }
                            //        }
                            //    }
                            //}
                            //else
                            //{
                            //    this.tEdit_SalesEmployeeCd.SelectAll();
                            //    e.NextCtrl = e.PrevCtrl;
                            //}
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
                        }
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                        // NextCtrl制御
                        if ( canChangeFocus )
                        {
                            if ( !e.ShiftKey )
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if ( this.tEdit_SalesEmployeeCd.Text == "" )
                                            {
                                                e.NextCtrl = this.uButton_SalesEmployeeGuide;
                                            }
                                            else
                                            {
                                                // 2008.11.20 add start [8042]
                                                if (this.tEdit_SalesInputCode.Visible)
                                                {
                                                    e.NextCtrl = this.tEdit_SalesInputCode;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.tEdit_FrontEmployeeCd;
                                                }
                                                // 2008.11.20 add end [8042]
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            this.tEdit_SalesEmployeeCd.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD

                        break;
                    }
                // 2008.11.20 add start [8042]
                // 担当者ボタン
                case "uButton_SalesEmployeeGuide":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Up:
                                    {
                                        e.NextCtrl = this.tEdit_SalesSlipNum_Ed;
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (this.tEdit_SalesInputCode.Visible)
                                        {
                                            e.NextCtrl = this.tEdit_SalesInputCode;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tEdit_FrontEmployeeCd;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                    // 2008.11.20 add end [8042]

                // TODO:発行者コード
                case "tEdit_SalesInputCode":
                    {
                        bool canChangeFocus = true;
                        string code = this.tEdit_SalesInputCode.Text.Trim();

                        if (para.SalesInputCode.Trim() != code)
                        {
                            if (code == "")
                            {
                                para.SalesInputCode = "";
                                para.SalesInputName = "";
                            }
                            else
                            {
                                Employee data;
                                int status = this._salesSlipSearchAcs.GetEmployee(this._enterpriseCode, code, out data);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    para.SalesInputCode = data.EmployeeCode;
                                    para.SalesInputName = data.Name;
                                }
                                else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当する従業員が存在しません。",
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "従業員名称の取得に失敗しました。",
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                            }

                            // 抽出条件の各種コントロールに値を設定する。
                            this.SetDisplayConditionInfo(para);

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
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
                            //                    if (this.tEdit_SalesInputCode.Text == "")
                            //                    {
                            //                        e.NextCtrl = this.uButton_SalesInputGuide;
                            //                    }
                            //                    else
                            //                    {
                            //                        e.NextCtrl = this.tNedit_CustomerCode;
                            //                    }
                            //                    break;
                            //                }
                            //        }
                            //    }
                            //}
                            //else
                            //{
                            //    this.tEdit_SalesInputCode.SelectAll();
                            //    e.NextCtrl = e.PrevCtrl;
                            //}
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
                        }
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
                        //else
                        //{
                        //    // NextCtrl制御
                        //    switch (e.Key)
                        //    {
                        //        case Keys.Down:
                        //            {
                        //                if (this.uGrid_Result.Rows.Count > 0)
                        //                {
                        //                    e.NextCtrl = this.uGrid_Result;
                        //                }
                        //                break;
                        //            }
                        //    }
                        //}
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                        // NextCtrl制御
                        if ( canChangeFocus )
                        {
                            if ( !e.ShiftKey )
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if ( this.tEdit_SalesInputCode.Text == "" )
                                            {
                                                e.NextCtrl = this.uButton_SalesInputGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_FrontEmployeeCd;
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            this.tEdit_SalesInputCode.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD

                        break;
                    }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                // 受注者
                case "tEdit_FrontEmployeeCd":
                    {
                        bool canChangeFocus = true;
                        string code = this.tEdit_FrontEmployeeCd.Text.Trim();

                        if ( para.FrontEmployeeCd.Trim() != code )
                        {
                            if ( code == string.Empty )
                            {
                                para.FrontEmployeeCd = string.Empty;
                                para.FrontEmployeeName = string.Empty;
                            }
                            else
                            {
                                Employee data;
                                int status = this._salesSlipSearchAcs.GetEmployee( this._enterpriseCode, code, out data );

                                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                {
                                    para.FrontEmployeeCd = data.EmployeeCode;
                                    para.FrontEmployeeName = data.Name;
                                }
                                else if ( (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF) )
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当する従業員が存在しません。",
                                        status,
                                        MessageBoxButtons.OK );

                                    canChangeFocus = false;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "従業員名称の取得に失敗しました。",
                                        status,
                                        MessageBoxButtons.OK );

                                    canChangeFocus = false;
                                }
                            }

                            // 抽出条件の各種コントロールに値を設定する。
                            this.SetDisplayConditionInfo( para );
                        }

                        // NextCtrl制御
                        if ( canChangeFocus )
                        {
                            if ( !e.ShiftKey )
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            // DEL 2008/11/05 不具合対応[7078]↓ガイドのフォーカス制御
                                            //if ( tEdit_SalesInputCode.Text == string.Empty )
                                            if (tEdit_FrontEmployeeCd.Text == string.Empty) // ADD 2008/11/05 不具合対応[7078] ガイドのフォーカス制御
                                            {
                                                e.NextCtrl = this.uButton_FrontEmployeeCd;
                                            }
                                            else
                                            {
                                                // 2008.12.09 modify start [8879]
                                                //e.NextCtrl = this.uGrid_Result;
                                                e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                                // 2008.12.09 modify end [8879]
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            this.tEdit_FrontEmployeeCd.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
                // 得意先コード
                case "tNedit_CustomerCode":
                    {
                        bool canChangeFocus = true;
                        int code = this.tNedit_CustomerCode.GetInt();

                        if (para.CustomerCode != code)
                        {
                            if (code == 0)
                            {
                                para.CustomerCode = 0;
                                para.CustomerName = "";
                            }
                            else
                            {
                                CustomerInfo data;
                                int status = this._salesSlipSearchAcs.GetCustomer(this._enterpriseCode, code, out data);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
                                    //CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                                    //CustomerInfo customerInfo = new CustomerInfo();

                                    //int st = customerInfoAcs.ReadDBData(_enterpriseCode, data.CustomerCode, out customerInfo);
                                    //if ((st == 0) && ((customerInfo.IsCustomer == true) || (customerInfo.IsReceiver == true)))
                                    //{
                                    //    para.CustomerCode = data.CustomerCode;
                                    //    para.CustomerName = data.Name + " " + data.Name2;
                                    //}
                                    //else
                                    //{
                                    //    TMsgDisp.Show(
                                    //        this,
                                    //        emErrorLevel.ERR_LEVEL_INFO,
                                    //        this.Name,
                                    //        "仕入先は入力できません。",
                                    //        -1,
                                    //        MessageBoxButtons.OK);
                                    //}
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                                    para.CustomerCode = data.CustomerCode;
                                    para.CustomerName = data.Name + " " + data.Name2;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
                                }
                                else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当する得意先が存在しません。",
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "得意先名称の取得に失敗しました。",
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                            }

                            // 抽出条件の各種コントロールに値を設定する。
                            this.SetDisplayConditionInfo( para );

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
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
                            //                    if (this.tNedit_CustomerCode.GetInt() == 0)
                            //                    {
                            //                        e.NextCtrl = this.uButton_CustomerGuide;
                            //                    }
                            //                    else
                            //                    {
                            //                        e.NextCtrl = this.tNedit_ClaimCode;
                            //                    }
                            //                    break;
                            //                }
                            //        }
                            //    }
                            //}
                            //else
                            //{
                            //    this.tNedit_CustomerCode.SelectAll();
                            //    e.NextCtrl = e.PrevCtrl;
                            //}
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
                        }
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                        // NextCtrl制御
                        if ( canChangeFocus )
                        {
                            if ( !e.ShiftKey )
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if ( this.tNedit_CustomerCode.GetInt() == 0 )
                                            {
                                                e.NextCtrl = this.uButton_CustomerGuide;
                                            }
                                            else if ( tNedit_ClaimCode.Enabled )
                                            {
                                                e.NextCtrl = this.tNedit_ClaimCode;
                                            }
                                            // else // DEL gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正
                                            else if (this.tComboEditor_SalesFormalCode.Enabled) // ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正
                                            {
                                                e.NextCtrl = this.tComboEditor_SalesFormalCode;
                                            }
                                            //---- ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正 ---->>>>>
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
                            this.tNedit_CustomerCode.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD

                        break;
                    }
                // 請求先コード
                case "tNedit_ClaimCode":
                    {
                        bool canChangeFocus = true;
                        int code = this.tNedit_ClaimCode.GetInt();

                        if (para.ClaimCode != code)
                        {
                            if (code == 0)
                            {
                                para.ClaimCode = 0;
                                para.ClaimName = "";
                            }
                            else
                            {
                                CustomerInfo data;
                                int status = this._salesSlipSearchAcs.GetCustomer(this._enterpriseCode, code, out data);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
                                    //CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                                    //CustomerInfo customerInfo = new CustomerInfo();

                                    //int st = customerInfoAcs.ReadDBData( _enterpriseCode, data.CustomerCode, out customerInfo );
                                    //if ((st == 0) && ((customerInfo.IsCustomer == true) || (customerInfo.IsReceiver == true)))
                                    //{
                                    //    para.ClaimCode = data.CustomerCode;
                                    //    para.ClaimName = data.Name + " " + data.Name2;
                                    //}
                                    //else
                                    //{
                                    //    TMsgDisp.Show(
                                    //        this,
                                    //        emErrorLevel.ERR_LEVEL_INFO,
                                    //        this.Name,
                                    //        "仕入先は入力できません。",
                                    //        -1,
                                    //        MessageBoxButtons.OK);
                                    //}
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                                    para.ClaimCode = data.CustomerCode;
                                    para.ClaimName = data.Name + " " + data.Name2;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
                                }
                                else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当する得意先が存在しません。",
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "得意先名称の取得に失敗しました。",
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                            }

                            // 抽出条件の各種コントロールに値を設定する。
                            this.SetDisplayConditionInfo( para );

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
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
                            //                    if (this.tNedit_ClaimCode.GetInt() == 0)
                            //                    {
                            //                        e.NextCtrl = this.uButton_ClaimGuide;
                            //                    }
                            //                    else
                            //                    {
                            //                        e.NextCtrl = this.tComboEditor_SalesInpSecCd;
                            //                    }
                            //                    break;
                            //                }
                            //            case Keys.Down:
                            //                {
                            //                    break;
                            //                }
                            //        }
                            //    }
                            //}
                            //else
                            //{
                            //    this.tNedit_ClaimCode.SelectAll();
                            //    e.NextCtrl = e.PrevCtrl;
                            //}
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
                        }
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                        // NextCtrl制御
                        if ( canChangeFocus )
                        {
                            if ( !e.ShiftKey )
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if ( this.tNedit_ClaimCode.GetInt() == 0 )
                                            {
                                                e.NextCtrl = this.uButton_ClaimGuide;
                                            }
                                            // else // DEL gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正
                                            else if (tComboEditor_SalesFormalCode.Enabled) // ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正
                                            {
                                                e.NextCtrl = tComboEditor_SalesFormalCode;
                                            }
                                            //---- ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正 ---->>>>>
                                            else
                                            {
                                                e.NextCtrl = tComboEditor_SalesSlipCd;
                                            }
                                            //---- ADD gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正 ----<<<<<
                                            break;
                                        }
                                    case Keys.Down:
                                        {
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            this.tNedit_ClaimCode.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD

                        break;
                    }
                // 請求先ガイドボタン
                case "uButton_ClaimGuide":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.uGrid_Result.Rows.Count > 0)
                                        {
                                            e.NextCtrl = this.uGrid_Result;
                                        }
                                        else
                                        {
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
                                            //e.NextCtrl = this.tComboEditor_SalesInpSecCd;
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                                            // e.NextCtrl = tComboEditor_SalesFormalCode; // DEL gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正
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
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
                                        }
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
                //// 売上入力拠点
                //case "tComboEditor_SalesInpSecCd":
                //    {
                //        string code = this.tComboEditor_SalesInpSecCd.Value.ToString();

                //        if (code.Trim() != para.SectionCode.Trim())
                //        {
                //            para.SectionCode = code;
                //            para.SectionName = this._salesSlipSearchAcs.GetName_FromSecInfoSet(code);

                //            // 抽出条件の各種コントロールに値を設定する。
                //            this.SetDisplayConditionInfo(para);
                //        }

                //        if (!e.ShiftKey)
                //        {
                //            switch (e.Key)
                //            {
                //                case Keys.Return:
                //                case Keys.Tab:
                //                    {
                //                        if (this.uGrid_Result.Rows.Count > 0)
                //                        {
                //                            e.NextCtrl = this.uGrid_Result;
                //                        }
                //                        else
                //                        {
                //                            e.NextCtrl = this.tComboEditor_SalesFormalCode;
                //                        }
                //                        break;
                //                    }
                //            }
                //        }
                //        break;
                //    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                // 拠点コード
                case "tEdit_SectionCodeAllowZero":
                    {
                        bool canChangeFocus = true;

                        //------------------------------------
                        // 拠点ゼロコード取得
                        //------------------------------------
                        UiSet uiset;
                        uiSetControl1.ReadUISet( out uiset, tEdit_SectionCodeAllowZero.Name );
                        string sectionCodeZero = new string( '0', uiset.Column );

                        //------------------------------------
                        // 拠点コード取得
                        //------------------------------------
                        string sectionCode = this.tEdit_SectionCodeAllowZero.Text.TrimEnd();
                        //bool inputFlag = (sectionCode != sectionCodeZero);
                        bool inputFlag = true;

                        if ( sectionCode != para.SectionCode )
                        {

                            //------------------------------------
                            // 検索
                            //------------------------------------
                            if ( sectionCode != string.Empty && sectionCode != sectionCodeZero )
                            {
                                if ( _secInfoSetAcs == null )
                                {
                                    _secInfoSetAcs = new SecInfoSetAcs();
                                }
                                SecInfoSet sectionInfo;
                                int status = this._secInfoSetAcs.Read( out sectionInfo, this._enterpriseCode, sectionCode );
                                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                {
                                    // 共通変数に保存
                                    this._dspSectionCode = sectionInfo.SectionCode.TrimEnd();

                                    // パラメータに保存
                                    para.SectionCode = sectionInfo.SectionCode.TrimEnd();
                                    para.SectionName = sectionInfo.SectionGuideNm.TrimEnd();
                                }
                                else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当する拠点が存在しません。",
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "拠点名の取得に失敗しました。",
                                        status,
                                        MessageBoxButtons.OK);

                                    canChangeFocus = false;
                                }
                            }
                            else
                            {
                                // クリアする
                                // 共通変数に保存
                                this._dspSectionCode = sectionCodeZero;
                                // パラメータに保存
                                para.SectionCode = sectionCodeZero;
                                para.SectionName = ct_AllSection;
                            }

                            // 抽出条件の各種コントロールに値を設定する。
                            this.SetDisplayConditionInfo( para );

                        }
                        else
                        {
                        }

                        // フォーカス制御
                        if ( canChangeFocus )
                        {
                            if ( !e.ShiftKey )
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if ( inputFlag )
                                            {
                                                // 2008.12.09 modify start[8879]
                                                //if ( tNedit_SubSectionCode.Enabled )
                                                if (tNedit_SubSectionCode.Visible)
                                                // 2008.12.09 modify end[8879]
                                                {
                                                    e.NextCtrl = this.tNedit_SubSectionCode;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.tNedit_CustomerCode;
                                                }
                                            }
                                            else
                                            {
                                                e.NextCtrl = SectionCodeGuide_ultraButton;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            tEdit_SectionCodeAllowZero.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                // 部門コード
                case "tNedit_SubSectionCode":
                    {
                        bool canChangeFocus = true;

                        string sectionCode = this.tEdit_SectionCodeAllowZero.Text.TrimEnd();
                        int subSectionCode = this.tNedit_SubSectionCode.GetInt();
                        bool inputFlag = (subSectionCode != 0);

                        if ( subSectionCode != para.SubSectionCode )
                        {
                            if ( subSectionCode != 0 )
                            {
                                if ( _subSectionAcs == null )
                                {
                                    _subSectionAcs = new SubSectionAcs();
                                }
                                SubSection subSection;
                                int status = this._subSectionAcs.Read( out subSection, this._enterpriseCode, sectionCode, subSectionCode );
                                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                {
                                    //this.tNedit_SubSectionCode.Text = subSection.SubSectionName.TrimEnd();

                                    // 共通変数に保存
                                    this._dspSubSectionCode = subSection.SubSectionCode;

                                    // パラメータに保存
                                    para.SubSectionCode = subSection.SubSectionCode;
                                    para.SubSectionName = subSection.SubSectionName;
                                }
                                else if ( (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF) )
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "該当する部門が存在しません。",
                                        status,
                                        MessageBoxButtons.OK );

                                    canChangeFocus = false;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "部門名の取得に失敗しました。",
                                        status,
                                        MessageBoxButtons.OK );

                                    canChangeFocus = false;
                                }
                            }
                            else
                            {
                                this._dspSubSectionCode = 0;

                                // パラメータから削除
                                para.SubSectionCode = 0;
                                para.SubSectionName = string.Empty;
                            }

                            // 抽出条件の各種コントロールに値を設定する。
                            this.SetDisplayConditionInfo( para );
                        }

                        // フォーカス制御
                        if ( canChangeFocus )
                        {
                            if ( !e.ShiftKey )
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if ( inputFlag )
                                            {
                                                e.NextCtrl = this.tNedit_CustomerCode;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.ultraButton_SubSectionGuide;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            tNedit_SubSectionCode.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                // 型式
                case "tEdit_FullModel":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Up:
                                    {
                                        // e.NextCtrl = tComboEditor_SalesFormalCode; // DEL gaocheng 2015/05/08 for Redmine#45800 計上伝票呼出検索時のカーソル移動の不具合の修正
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
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        //e.NextCtrl = tDateEdit_SalesDateSt;//DEL 2011/11/11
                                        e.NextCtrl = tComboEditor_AutoAnswerDivSCM;//ADD 2011/11/11
                                    }
                                    break;
                            }
                        }
                    }
                    break;

                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
                //---ADD 2011/11/11 ------------------------------->>>>>
                // 連携伝票出力区分
                case "tComboEditor_AutoAnswerDivSCM":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Up:
                                    {
                                        e.NextCtrl = tEdit_FullModel;
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = tDateEdit_SalesDateSt;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                //---ADD 2011/11/11 -------------------------------<<<<<
                // 検索結果グリッド
                case "uGrid_Result":
                    {
                        if (e.Key == Keys.Return)
                        {
                            this._selectedData = this.GetSelectedData();
                            if (StartMovment == 1)
                            {
                                break;
                            }

                            if (this._selectedData != null)
                            {
                                this._dialogResult = DialogResult.OK;
                                this.Close();
                            }
                        }

                        break;
                    }
            }

            // メモリ上の内容と比較する
            ArrayList arRetList = para.Compare(this._para);

            if (arRetList.Count > 0)
            {
                this._para = para.Clone();

                // 抽出条件の各種コントロールに値を設定する。
                this.SetDisplayConditionInfo(this._para);

                this.timer_Search.Enabled = true;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
            // 変則フォーカス制御
            _irrFocusCtrl.ReflectIrregularNextControl( e );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD
        }

        /// <summary>
        /// 検索結果グリッドレイアウト初期化イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Result_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            string codeFormat = "#0;-#0;''";
            string moneyFormat = "#,##0;-#,##0;''";
            string dateFormat = "yyyy/MM/dd";

            int visiblePosition = 1;
            string acptAnOdrStatusTiTle = "";

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Result.DisplayLayout.Bands[0].Columns;

            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //非表示設定
                column.Hidden = true;
                column.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            }

            switch (_para.AcptAnOdrStatus)
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
                //case 10: acptAnOdrStatusTiTle = "見積"; break;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
                case 10:
                case 15:
                case 16:
                    acptAnOdrStatusTiTle = "見積"; 
                    break;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD
                case 20: acptAnOdrStatusTiTle = "受注"; break;
                case 30: acptAnOdrStatusTiTle = "売上"; break;
                case 40: acptAnOdrStatusTiTle = "貸出"; break;
                default: acptAnOdrStatusTiTle = "売上"; break;
            }

            //--------------------------------------------------------------------------------
            //  表示するカラム情報
            //--------------------------------------------------------------------------------

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
            ////出荷日＜出荷時のみ表示＞
            //if (_para.AcptAnOdrStatus == 40)
            //{
            //    Columns[this._dataSet.SalesSlip.ShipmentDayStringColumn.ColumnName].Hidden = false;
            //    Columns[this._dataSet.SalesSlip.ShipmentDayStringColumn.ColumnName].Header.Caption = "貸出日";
            //    //Columns[this._dataSet.SalesSlip.ShipmentDayStringColumn.ColumnName].Width = 100;
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //    //Columns[this._dataSet.SalesSlip.ShipmentDayStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            //    Columns[this._dataSet.SalesSlip.ShipmentDayStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            //    Columns[this._dataSet.SalesSlip.ShipmentDayStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //}
            //else
            //{
            //    //売上日
            //    Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].Hidden = false;
            //    Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].Header.Caption = acptAnOdrStatusTiTle + "日";
            //    Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].Width = 100;
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //    //Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            //    Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            //    Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL

            // 2008.11.07 add start [7071]
            //売上日
            Columns[this._dataSet.SalesSlip.RowNoColumn.ColumnName].Header.Fixed = true;
            Columns[this._dataSet.SalesSlip.RowNoColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.RowNoColumn.ColumnName].Header.Caption = "No";
            Columns[this._dataSet.SalesSlip.RowNoColumn.ColumnName].Width = 60;
            Columns[this._dataSet.SalesSlip.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // 2008.11.07 add end [7071]

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
            //売上日
            Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].Header.Caption = acptAnOdrStatusTiTle + "日";
            Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.SlipDateStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD

            //伝票番号
            Columns[this._dataSet.SalesSlip.SearchSlipNumColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SearchSlipNumColumn.ColumnName].Header.Caption = "伝票番号";
            //Columns[this._dataSet.SalesSlip.SearchSlipNumColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //Columns[this._dataSet.SalesSlip.SearchSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.SearchSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.SearchSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesSlip.SearchSlipNumColumn.ColumnName].Format = codeFormat;

            //伝票種別
            Columns[this._dataSet.SalesSlip.AcptAnOdrStatusNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.AcptAnOdrStatusNameColumn.ColumnName].Header.Caption = "伝票種別";
            //Columns[this._dataSet.SalesSlip.AcptAnOdrStatusNameColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //Columns[this._dataSet.SalesSlip.AcptAnOdrStatusNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.AcptAnOdrStatusNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.AcptAnOdrStatusNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //伝票区分
            Columns[this._dataSet.SalesSlip.SlipDivNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SlipDivNameColumn.ColumnName].Header.Caption = "伝票区分";
            //Columns[this._dataSet.SalesSlip.SlipDivNameColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //Columns[this._dataSet.SalesSlip.SlipDivNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.SlipDivNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.SlipDivNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //得意先コード
            Columns[this._dataSet.SalesSlip.CustomerCodeColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.CustomerCodeColumn.ColumnName].Header.Caption = "得意先コード";
            //Columns[this._dataSet.SalesSlip.CustomerCodeColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //Columns[this._dataSet.SalesSlip.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.CustomerCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki  2008/00/00 DEL
            //Columns[this._dataSet.SalesSlip.CustomerCodeColumn.ColumnName].Format = codeFormat;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.CustomerCodeColumn.ColumnName].Format = GetCustomerCodeFormat();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD

            //得意先名
            Columns[this._dataSet.SalesSlip.CustomerNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.CustomerNameColumn.ColumnName].Header.Caption = "得意先名";
            //Columns[this._dataSet.SalesSlip.CustomerNameColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesSlip.CustomerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.CustomerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
            // 担当者名
            Columns[this._dataSet.SalesSlip.SalesEmployeeNmColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SalesEmployeeNmColumn.ColumnName].Header.Caption = "担当者名";
            Columns[this._dataSet.SalesSlip.SalesEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.SalesEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 発行者
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.11 TOKUNAGA MODIFY START
            //if (this._inpAgentDispDiv == INP_AGT_NODISP)
            //{
            //    Columns[this._dataSet.SalesSlip.SalesEmployeeNmColumn.ColumnName].Hidden = true;
            //}
            //else
            //{
            //    Columns[this._dataSet.SalesSlip.SalesEmployeeNmColumn.ColumnName].Hidden = false;
            //    Columns[this._dataSet.SalesSlip.SalesEmployeeNmColumn.ColumnName].Header.Caption = "発行者名";
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.11 TOKUNAGA MODIFY END
            //    Columns[this._dataSet.SalesSlip.SalesEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //    Columns[this._dataSet.SalesSlip.SalesEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //}
            SetInpAgentDispDivFromSalesTtlSt(this._para.SectionCode);   // ADD 2008/11/05 不具合対応[7070] 売上全体設定マスタの発行者区分を参照
            if (this._inpAgentDispDiv == INP_AGT_NODISP)
            {
                Columns[this._dataSet.SalesSlip.SalesInputNameColumn.ColumnName].Hidden = true;
            }
            else
            {
                Columns[this._dataSet.SalesSlip.SalesInputNameColumn.ColumnName].Hidden = false;
                Columns[this._dataSet.SalesSlip.SalesInputNameColumn.ColumnName].Header.Caption = "発行者名";
                Columns[this._dataSet.SalesSlip.SalesInputNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                Columns[this._dataSet.SalesSlip.SalesInputNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.11 TOKUNAGA MODIFY END

            // 受注者名
            Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].Header.Caption = "受注者名";
            Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD

            //売上金額（税抜）
            Columns[this._dataSet.SalesSlip.SalesTotalTaxExcColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SalesTotalTaxExcColumn.ColumnName].Header.Caption = acptAnOdrStatusTiTle + "金額";
            //Columns[this._dataSet.SalesSlip.SalesTotalTaxExcColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesSlip.SalesTotalTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesSlip.SalesTotalTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesSlip.SalesTotalTaxExcColumn.ColumnName].Format = moneyFormat;

            //消費税
            Columns[this._dataSet.SalesSlip.SalesSubtotalTaxColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SalesSubtotalTaxColumn.ColumnName].Header.Caption = "消費税";
            //Columns[this._dataSet.SalesSlip.SalesSubtotalTaxColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesSlip.SalesSubtotalTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesSlip.SalesSubtotalTaxColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesSlip.SalesSubtotalTaxColumn.ColumnName].Format = moneyFormat;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.14 TOKUNAGA ADD START
            //管理番号
            Columns[this._dataSet.SalesSlip.CarMngCodeColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.CarMngCodeColumn.ColumnName].Header.Caption = "管理番号";
            Columns[this._dataSet.SalesSlip.CarMngCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.CarMngCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //類別型式
            Columns[this._dataSet.SalesSlip.CategoryModelColumn.ColumnName].Hidden = false;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
            //Columns[this._dataSet.SalesSlip.CategoryModelColumn.ColumnName].Header.Caption = "類別形式";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
            Columns[this._dataSet.SalesSlip.CategoryModelColumn.ColumnName].Header.Caption = "類別型式";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD
            Columns[this._dataSet.SalesSlip.CategoryModelColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.CategoryModelColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //車種
            Columns[this._dataSet.SalesSlip.ModelFullNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.ModelFullNameColumn.ColumnName].Header.Caption = "車種";
            Columns[this._dataSet.SalesSlip.ModelFullNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.ModelFullNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
            // 型式
            Columns[this._dataSet.SalesSlip.FullModelColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.FullModelColumn.ColumnName].Header.Caption = "型式";
            Columns[this._dataSet.SalesSlip.FullModelColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.FullModelColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
            ////型式
            //Columns[this._dataSet.SalesSlip.CategoryModelColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesSlip.CategoryModelColumn.ColumnName].Header.Caption = "類別形式";
            //Columns[this._dataSet.SalesSlip.CategoryModelColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._dataSet.SalesSlip.CategoryModelColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.14 TOKUNAGA ADD START

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.14 TOKUNAGA DEL START
            ////明細行数
            //Columns[this._dataSet.SalesSlip.DetailRowCountColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesSlip.DetailRowCountColumn.ColumnName].Header.Caption = "明細行数";
            ////Columns[this._dataSet.SalesSlip.DetailRowCountColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesSlip.DetailRowCountColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //Columns[this._dataSet.SalesSlip.DetailRowCountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.14 TOKUNAGA DEL END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.14 TOKUNAGA DEL START
            //訂正可・訂正不可
            //Columns[this._dataSet.SalesSlip.SalesSlipUpdatableNameColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesSlip.SalesSlipUpdatableNameColumn.ColumnName].Header.Caption = "訂正";
            ////Columns[this._dataSet.SalesSlip.SalesSlipUpdatableNameColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesSlip.SalesSlipUpdatableNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //Columns[this._dataSet.SalesSlip.SalesSlipUpdatableNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.14 TOKUNAGA DEL END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
            ////受付担当者名
            //Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].Hidden = false;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.11 TOKUNAGA MODIFY START
            //Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].Header.Caption = "受注名";
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.11 TOKUNAGA MODIFY END
            ////Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._dataSet.SalesSlip.FrontEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL

            //赤黒
            Columns[this._dataSet.SalesSlip.DebitNoteDivNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.DebitNoteDivNameColumn.ColumnName].Header.Caption = "赤黒";
            //Columns[this._dataSet.SalesSlip.DebitNoteDivNameColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //Columns[this._dataSet.SalesSlip.DebitNoteDivNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.DebitNoteDivNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.DebitNoteDivNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.14 TOKUNAGA DEL START
            //総額表示
            //Columns[this._dataSet.SalesSlip.TotalAmountDispWayNameColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesSlip.TotalAmountDispWayNameColumn.ColumnName].Header.Caption = "総額表示";
            ////Columns[this._dataSet.SalesSlip.TotalAmountDispWayNameColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesSlip.TotalAmountDispWayNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //Columns[this._dataSet.SalesSlip.TotalAmountDispWayNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.14 TOKUNAGA DEL END

            //売上金額（税込）
            //Columns[this._dataSet.SalesSlip.SalesTotalTaxIncColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesSlip.SalesTotalTaxIncColumn.ColumnName].Header.Caption = acptAnOdrStatusTiTle + "金額（税込）";
            ////Columns[this._dataSet.SalesSlip.SalesTotalTaxIncColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesSlip.SalesTotalTaxIncColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //Columns[this._dataSet.SalesSlip.SalesTotalTaxIncColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //Columns[this._dataSet.SalesSlip.SalesTotalTaxIncColumn.ColumnName].Format = moneyFormat;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.14 TOKUNAGA DEL START
            //原価金額
            //Columns[this._dataSet.SalesSlip.TotalCostColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesSlip.TotalCostColumn.ColumnName].Header.Caption = "原価金額";
            ////Columns[this._dataSet.SalesSlip.TotalCostColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesSlip.TotalCostColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //Columns[this._dataSet.SalesSlip.TotalCostColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //Columns[this._dataSet.SalesSlip.TotalCostColumn.ColumnName].Format = moneyFormat;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.14 TOKUNAGA DEL END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.11 TOKUNAGA MODIFY START
            //商品区分名
            Columns[this._dataSet.SalesSlip.SalesGoodsCdNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SalesGoodsCdNameColumn.ColumnName].Header.Caption = "商品区分名";
            //Columns[this._dataSet.SalesSlip.SalesGoodsCdNameColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //Columns[this._dataSet.SalesSlip.SalesGoodsCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.SalesGoodsCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.SalesGoodsCdNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.11 TOKUNAGA MODIFY END

            //入力日
            Columns[this._dataSet.SalesSlip.SearchSlipDateColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SearchSlipDateColumn.ColumnName].Header.Caption = "入力日";
            //Columns[this._dataSet.SalesSlip.SearchSlipDateColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //Columns[this._dataSet.SalesSlip.SearchSlipDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.SearchSlipDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.SearchSlipDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesSlip.SearchSlipDateColumn.ColumnName].Format = dateFormat;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
            ////出荷日＜売上時のみ表示＞
            //if (_para.AcptAnOdrStatus == 30)
            //{
            //    Columns[this._dataSet.SalesSlip.ShipmentDayStringColumn.ColumnName].Hidden = false;
            //    Columns[this._dataSet.SalesSlip.ShipmentDayStringColumn.ColumnName].Header.Caption = "貸出日";
            //    //Columns[this._dataSet.SalesSlip.ShipmentDayStringColumn.ColumnName].Width = 100;
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //    //Columns[this._dataSet.SalesSlip.ShipmentDayStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            //    Columns[this._dataSet.SalesSlip.ShipmentDayStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            //    Columns[this._dataSet.SalesSlip.ShipmentDayStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.14 TOKUNAGA ADD START
            //計上日
            Columns[this._dataSet.SalesSlip.AddUpADateStringColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.AddUpADateStringColumn.ColumnName].Header.Caption = "計上日";
            Columns[this._dataSet.SalesSlip.AddUpADateStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.AddUpADateStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.14 TOKUNAGA ADD END

            //伝票備考
            Columns[this._dataSet.SalesSlip.SlipNoteColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SlipNoteColumn.ColumnName].Header.Caption = "伝票備考";
            //Columns[this._dataSet.SalesSlip.SlipNoteColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesSlip.SlipNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.SlipNoteColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //伝票備考２
            Columns[this._dataSet.SalesSlip.SlipNote2Column.ColumnName].Hidden = true;  // MOD 2008/11/05 不具合対応[7063] グリッドの表示項目が仕様書と異なる false→true
            Columns[this._dataSet.SalesSlip.SlipNote2Column.ColumnName].Header.Caption = "伝票備考２";
            //Columns[this._dataSet.SalesSlip.SlipNote2Column.ColumnName].Width = 100;
            Columns[this._dataSet.SalesSlip.SlipNote2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.SlipNote2Column.ColumnName].Header.VisiblePosition = visiblePosition++;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.14 TOKUNAGA ADD START
            //リマーク1
            Columns[this._dataSet.SalesSlip.UoeRemark1Column.ColumnName].Hidden = false;
            // 2008.11.07 modify start [7071]
            Columns[this._dataSet.SalesSlip.UoeRemark1Column.ColumnName].Header.Caption = "リマーク１";
            // 2008.11.07 modify end [7071]
            Columns[this._dataSet.SalesSlip.UoeRemark1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.UoeRemark1Column.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.14 TOKUNAGA ADD END

            //拠点名
            Columns[this._dataSet.SalesSlip.SectionNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.SectionNameColumn.ColumnName].Header.Caption = "拠点名";
            //Columns[this._dataSet.SalesSlip.SectionNameColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesSlip.SectionNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.SectionNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;


            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.15 TOKUNAGA MODIFY START
            //部門名
            // --- CHG 2009/03/31 障害ID:8859対応------------------------------------------------------>>>>>
            //if (this._secMngDiv != DIV_MNG_DIVITION) // 部門名を表示できるのは部署管理区分が拠点以外のときのみ
            if (this._secMngDiv != DIV_MNG_SECTION) // 部門名を表示できるのは部署管理区分が拠点以外のときのみ
            // --- CHG 2009/03/31 障害ID:8859対応------------------------------------------------------<<<<<
            {
                Columns[this._dataSet.SalesSlip.SubSectionNameColumn.ColumnName].Hidden = false;
                Columns[this._dataSet.SalesSlip.SubSectionNameColumn.ColumnName].Header.Caption = "部門名";
                //Columns[this._dataSet.SalesSlip.SubSectionNameColumn.ColumnName].Width = 100;
                Columns[this._dataSet.SalesSlip.SubSectionNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                Columns[this._dataSet.SalesSlip.SubSectionNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            }
            else
            {
                Columns[this._dataSet.SalesSlip.SubSectionNameColumn.ColumnName].Hidden = true;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.15 TOKUNAGA MODIFY END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.14 TOKUNAGA ADD START
            //請求先コード
            Columns[this._dataSet.SalesSlip.ClaimCodeColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.ClaimCodeColumn.ColumnName].Header.Caption = "請求先コード";
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //Columns[this._dataSet.SalesSlip.ClaimCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.ClaimCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.ClaimCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            Columns[this._dataSet.SalesSlip.ClaimCodeColumn.ColumnName].Format = GetCustomerCodeFormat();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD

            //請求先名
            Columns[this._dataSet.SalesSlip.ClaimNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesSlip.ClaimNameColumn.ColumnName].Header.Caption = "請求先名";
            Columns[this._dataSet.SalesSlip.ClaimNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesSlip.ClaimNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.14 TOKUNAGA ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.14 TOKUNAGA DEL START
            //課名
            //Columns[this._dataSet.SalesSlip.MinSectionNameColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesSlip.MinSectionNameColumn.ColumnName].Header.Caption = "課名";
            ////Columns[this._dataSet.SalesSlip.MinSectionNameColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesSlip.MinSectionNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._dataSet.SalesSlip.MinSectionNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.14 TOKUNAGA DEL END

            // 列表示状態クラスリストXMLファイルをデシリアライズ
            List<ColDisplayStatus> colDisplayStatusList = ColDisplayStatusList.Deserialize(ctFILENAME_COLDISPLAYSTATUS);

            // 列表示状態コレクションクラスをインスタンス化
            this._colDisplayStatusList = new ColDisplayStatusList(colDisplayStatusList, this._dataSet.SalesSlip);

            // ADD 2009/12/03 MANTIS対応[14742]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
            // FIXME:列移動と列固定を可能とする
            SlipGridUtil.EnableAllowColSwappingAndFixedHeaderIndicator(this.uGrid_Result);
            // FIXME:グリッド列の設定を取込
            SlipGridUtil.LoadColumnInfo(this.uGrid_Result, GridSettings.SlipColumnsList);
            // ADD 2009/12/03 MANTIS対応[14742]：伝票および明細グリッド列の列設定の変更 ----------<<<<<
        }

        /// <summary>
        /// 「確定」ボタン表示変更処理
        /// </summary>
        /// <param name="enable">表示設定(true:表示、false:非表示)</param>
        private void ChangeDecisionButtonEnable(bool enableSet)
        {
            if (this.StartMovment == 1) enableSet = false;
            this._selectButton.SharedProps.Enabled = enableSet;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            this._selectButton.SharedProps.Visible = enableSet;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
        }

        /// <summary>
        /// ツールバーツールクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        this._dialogResult = DialogResult.Cancel;
                        this.Close();
                        break;
                    }
                case "ButtonTool_Select":
                    {
                        this._selectedData = this.GetSelectedData();

                        if (this._selectedData != null)
                        {
                            this._dialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "選択されているデータが存在しません。",
                                0,
                                MessageBoxButtons.OK);
                        }
                        break;
                    }
                case "ButtonTool_Clear":
                    {
                        this.Clear();
                        this.timer_InitFocusSetting.Enabled = true;
                        break;
                    }
                case "ButtonTool_Search":   // MEMO:検索
                    {
                        if (SeachBeforeCheck())
                        {
                            this.Search(this._para);
                        }
                        break;
                    }
                case "ButtonTool_Setup":
                    {
                        SalesSearchSetup salesSearchSetup = new SalesSearchSetup();
                        DialogResult dialogResult = salesSearchSetup.ShowDialog(this);

                        if (dialogResult == DialogResult.OK)
                        {
                            if (this.uGrid_Result.Rows.Count == 0)
                            {
                                this.Clear();
                            }
                        }

                        break;
                    }
            }
        }

        #region ◎ 検索前確認処理
        /// <summary>
        /// 検索前確認処理
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: 印刷前確認処理を行う。(入力チェックなど)</br>
        /// <br>Programmer	: 96186 立花 裕輔</br>
        /// <br>Date		: 2007.09.03</br>
        /// </remarks>
        public bool SeachBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // メッセージを表示
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    errMessage,
                    0,
                    MessageBoxButtons.OK);

                // コントロールにフォーカスをセット
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                status = false;
            }

            return status;
        }
        #endregion


        #region ◎ 入力チェック処理
        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_OrderDataCreateDate"></param>
        /// <param name="tde_Ed_OrderDataCreateDate"></param>
        /// <returns></returns>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_OrderDataCreateDate, ref TDateEdit tde_Ed_OrderDataCreateDate, bool mode, int ym)
        {
            cdrResult = _dateGet.CheckDateRange( DateGetAcs.YmdType.YearMonth, ym, ref tde_St_OrderDataCreateDate, ref tde_Ed_OrderDataCreateDate, mode );
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 96186 立花 裕輔</br>
        /// <br>Date		: 2007.09.03</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;
            string kbnNm = Lb_SearchSlipDate.Text;

            DateGetAcs.CheckDateRangeResult cdrResult;

            // 売上日付（開始～終了）
            //if ( CallCheckDateRange( out cdrResult, ref tDateEdit_SalesDateSt, ref tDateEdit_SalesDateEd, false, 3 ) == false ) // DEL 2009/04/03
            if (CallCheckDateRange(out cdrResult, ref tDateEdit_SalesDateSt, ref tDateEdit_SalesDateEd, true, 0) == false) // ADD 2009/04/03
            {
                switch (cdrResult)
                {
                    // --- DEL 2009/04/03 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                    //    {
                    //        errMessage = string.Format("開始" + kbnNm + "{0}", ct_NoInput);
                    //        errComponent = this.tDateEdit_SalesDateSt;
                    //    }
                    //    break;
                    // --- DEL 2009/04/03 --------------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("開始" + kbnNm + "{0}", ct_InputError);
                            errComponent = this.tDateEdit_SalesDateSt;
                            return false; // ADD 2009/04/03
                        }
                    //break; // DEL 2009/04/03
                    // --- DEL 2009/04/03 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                    //    {
                    //        errMessage = string.Format("終了" + kbnNm + "{0}", ct_NoInput);
                    //        errComponent = this.tDateEdit_SalesDateEd;
                    //    }
                    //    break;
                    // --- DEL 2009/04/03 --------------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("終了" + kbnNm + "{0}", ct_InputError);
                            errComponent = this.tDateEdit_SalesDateEd;
                            return false; // ADD 2009/04/03
                        }
                        //break; // DEL 2009/04/03
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                    // --- ADD 2009/04/03 -------------------------------->>>>>
                        {
                            errMessage = string.Format(kbnNm + "{0}", ct_RangeError);
                            errComponent = this.tDateEdit_SalesDateSt;
                            return false; // ADD 2009/04/03
                        }
                        //break; // DEL 2009/04/03
                    // --- ADD 2009/04/03 --------------------------------<<<<<
                    // --- DEL 2009/04/03 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnMonth:
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                    //    {
                    //        // 2008.11.18 modify start [7871]
                    //        //errMessage = string.Format(kbnNm + "{0}", ct_RangeError);
                    //        errMessage = string.Format(kbnNm + "{0}", ct_RangeOverError);
                    //        // 2008.11.18 modify end [7871]
                    //        errComponent = this.tDateEdit_SalesDateSt;
                    //    }
                    //    break;
                    // --- DEL 2009/04/03 --------------------------------<<<<<
                }
                //status = false;
                //return false; // DEL 2009/04/03
            }
            // 入力日付（開始～終了）
            // --- CHG 2009/02/19 障害ID:7882対応------------------------------------------------------>>>>>
            //if ( CallCheckDateRange( out cdrResult, ref tDateEdit_SearchSlipDateSt, ref tDateEdit_SearchSlipDateEd, true, 0 ) == false )
            //{
            //    switch ( cdrResult )
            //    {
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
            //            {
            //                errMessage = string.Format( "開始入力日{0}", ct_NoInput );
            //                errComponent = this.tDateEdit_SearchSlipDateSt;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
            //            {
            //                errMessage = string.Format( "開始入力日{0}", ct_InputError );
            //                errComponent = this.tDateEdit_SearchSlipDateSt;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
            //            {
            //                errMessage = string.Format( "終了入力日{0}", ct_NoInput );
            //                errComponent = this.tDateEdit_SearchSlipDateEd;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
            //            {
            //                errMessage = string.Format( "終了入力日{0}", ct_InputError );
            //                errComponent = this.tDateEdit_SearchSlipDateEd;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
            //            {
            //                errMessage = string.Format( "入力日{0}", ct_RangeError );
            //                errComponent = this.tDateEdit_SearchSlipDateSt;
            //            }
            //            break;
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnMonth:
            //        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
            //            {
            //                errMessage = string.Format( "入力日{0}", ct_RangeOverError );
            //                errComponent = this.tDateEdit_SearchSlipDateSt;
            //            }
            //            break;
            //    }
            //    //status = false;
            //    return false;
            //}
            DateGetAcs.CheckDateResult cdResult;

            if (tDateEdit_SearchSlipDateSt.GetLongDate() != 0)
            {
                cdResult = _dateGet.CheckDate(ref tDateEdit_SearchSlipDateSt, true);
                if (cdResult == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                {
                    errMessage = string.Format("開始入力日{0}", ct_InputError);
                    errComponent = this.tDateEdit_SearchSlipDateSt;
                    return (false);
                }
            }

            if (tDateEdit_SearchSlipDateEd.GetLongDate() != 0)
            {
                cdResult = _dateGet.CheckDate(ref tDateEdit_SearchSlipDateEd, true);
                if (cdResult == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                {
                    errMessage = string.Format("終了入力日{0}", ct_InputError);
                    errComponent = this.tDateEdit_SearchSlipDateEd;
                    return (false);
                }
            }

            if ((tDateEdit_SearchSlipDateSt.GetLongDate() != 0) && (tDateEdit_SearchSlipDateEd.GetLongDate() != 0))
            {
                if (CallCheckDateRange(out cdrResult, ref tDateEdit_SearchSlipDateSt, ref tDateEdit_SearchSlipDateEd, true, 0) == false)
                {
                    switch (cdrResult)
                    {
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                            {
                                errMessage = string.Format("開始入力日{0}", ct_NoInput);
                                errComponent = this.tDateEdit_SearchSlipDateSt;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                            {
                                errMessage = string.Format("開始入力日{0}", ct_InputError);
                                errComponent = this.tDateEdit_SearchSlipDateSt;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                            {
                                errMessage = string.Format("終了入力日{0}", ct_NoInput);
                                errComponent = this.tDateEdit_SearchSlipDateEd;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                            {
                                errMessage = string.Format("終了入力日{0}", ct_InputError);
                                errComponent = this.tDateEdit_SearchSlipDateEd;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                            {
                                errMessage = string.Format("入力日{0}", ct_RangeError);
                                errComponent = this.tDateEdit_SearchSlipDateSt;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfNotOnMonth:
                        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                            {
                                errMessage = string.Format("入力日{0}", ct_RangeOverError);
                                errComponent = this.tDateEdit_SearchSlipDateSt;
                            }
                            break;
                    }
                    return false;
                }
            }

            // --- CHG 2009/02/19 障害ID:7882対応------------------------------------------------------<<<<<

            // 伝票番号
            long start = 0;
            long end = 0;
            if (!String.IsNullOrEmpty(this.tEdit_SalesSlipNum_St.Text.Trim()))
            {
                try
                {
                    start = long.Parse(this.tEdit_SalesSlipNum_St.Text.Trim());
                }
                catch
                {
                    errMessage = "伝票番号は数字で入力してください。";
                    errComponent = this.tEdit_SalesSlipNum_St;
                    return false;
                }
            }

            if (!String.IsNullOrEmpty(this.tEdit_SalesSlipNum_Ed.Text.Trim()))
            {
                try
                {
                    end = long.Parse(this.tEdit_SalesSlipNum_Ed.Text.Trim());
                }
                catch
                {
                    errMessage = "伝票番号は数字で入力してください。";
                    errComponent = this.tEdit_SalesSlipNum_Ed;
                    return false;
                }
            }

            if (start > 0 && end > 0 && start - end > 0)
            {
                errMessage = "伝票番号（開始）は伝票番号（終了）より小さい値を入力してください。";
                errComponent = this.tEdit_SalesSlipNum_St;
                return false;
            }
            return status;
        }
        #endregion



        /// <summary>
        /// 初期フォーカス設定タイマー起動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note      : 2011/12/14 yangmj</br>
        /// <br>管理番号         : 10707327-00 2012/01/25配信分</br>
        /// <br>                   redmine#27359 伝票検索の画面表示の対応</br>
        private void timer_InitFocusSetting_Tick(object sender, EventArgs e)
        {
            this.timer_InitFocusSetting.Enabled = false;
            //this.tComboEditor_SalesFormalCode.Focus();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //this.tEdit_SectionCodeAllowZero.Focus();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            //-----ADD 2011/12/14 yangmj redmine#27359 ----->>>>>
            if (_startMode == 1)
            {
                this.tNedit_CustomerCode.Focus();
            }
            //-----ADD 2011/12/14 yangmj redmine#27359 -----<<<<<
        }

        /// <summary>
        /// 売上データグリッドセルアクティブ後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Result_AfterCellActivate(object sender, EventArgs e)
        {
            if (this.uGrid_Result.ActiveCell != null)
            {
                this.uGrid_Result.Selected.Rows.Clear();
                this.uGrid_Result.ActiveRow = this.uGrid_Result.ActiveCell.Row;
                this.uGrid_Result.ActiveRow.Selected = true;
            }
        }

        /// <summary>
        /// 売上データグリッドエンターイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Result_Enter(object sender, EventArgs e)
        {
            if (this.uGrid_Result.ActiveCell != null)
            {
                this.uGrid_Result.Selected.Rows.Clear();
                this.uGrid_Result.ActiveRow = this.uGrid_Result.ActiveCell.Row;
                this.uGrid_Result.ActiveRow.Selected = true;
            }
            else
            {
                if (this.uGrid_Result.Rows.Count > 0)
                {
                    this.uGrid_Result.ActiveRow = this.uGrid_Result.Rows[0];
                    this.uGrid_Result.ActiveCell = this.uGrid_Result.ActiveRow.Cells[0];
                    this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInRow);
                    this.uGrid_Result.ActiveRow.Selected = true;
                }
            }

            this.uStatusBar_Main.Text = "マウスのドラッグ＆ドロップにて、列の表示位置や列幅の変更を行うことが出来ます。";
        }

        /// <summary>
        /// 売上データグリッドリーブイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Result_Leave(object sender, EventArgs e)
        {
            this.uStatusBar_Main.Text = "";
        }

        /// <summary>
        /// フォーム終了前イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void MAHNB04110UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ADD 2009/12/03 MANTIS対応[14742]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
            if (_disposed) return;
            // ADD 2009/12/03 MANTIS対応[14742]：伝票および明細グリッド列の列設定の変更 ----------<<<<<

            // 列表示状態クラスリスト構築処理
            List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.uGrid_Result.DisplayLayout.Bands[0].Columns);
            this._colDisplayStatusList.SetColDisplayStatusList(colDisplayStatusList);

            // 列表示状態クラスリストをXMLにシリアライズする
            ColDisplayStatusList.Serialize(this._colDisplayStatusList.GetColDisplayStatusList(), ctFILENAME_COLDISPLAYSTATUS);

            // ADD 2009/12/03 MANTIS対応[14742]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
            // FIXME:グリッド列の表示設定を保存
            GridSettings.SlipColumnsList = SlipGridUtil.CreateColumnInfoList(this.uGrid_Result);
            SlipGridUtil.StoreGridSettings(GridSettings, XML_FILE_NAME);
            // ADD 2009/12/03 MANTIS対応[14742]：伝票および明細グリッド列の列設定の変更 ----------<<<<<

            DialogResult = this._dialogResult;
        }

        // 2008.11.11 add start [7610]
        ///// <summary>
        ///// クリック
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void uGrid_Result_Click(object sender, EventArgs e)
        //{
        //    Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

        //    // マウスポインタがグリッドのどの位置にあるかを判定する
        //    Point point = System.Windows.Forms.Cursor.Position;
        //    point = targetGrid.PointToClient(point);
        //    Infragistics.Win.UIElement objElement = null;
        //    Infragistics.Win.UltraWinGrid.RowCellAreaUIElement objRowCellAreaUIElement = null;
        //    objElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);

        //    if (objElement != null)
        //    {
        //        objRowCellAreaUIElement = (Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)objElement.GetAncestor(
        //            (typeof(Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)));

        //        // ヘッダ部の場合は以下の処理をキャンセルする
        //        if (objRowCellAreaUIElement == null)
        //        {
        //            return;
        //        }
        //    }

        //    this._selectedData = this.GetSelectedData();

        //    if (StartMovment == 1)
        //    {
        //        return;
        //    }

        //    if (this._selectedData != null)
        //    {
        //        this._dialogResult = DialogResult.OK;
        //        this.Close();
        //    }
        //}
        // 2008.11.11 add end [7610]

        /// <summary>
        /// 売上データグリッドダブルクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Result_DoubleClick(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // マウスポインタがグリッドのどの位置にあるかを判定する
            Point point = System.Windows.Forms.Cursor.Position;
            point = targetGrid.PointToClient(point);
            Infragistics.Win.UIElement objElement = null;
            Infragistics.Win.UltraWinGrid.RowCellAreaUIElement objRowCellAreaUIElement = null;
            objElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);

            if (objElement != null)
            {
                objRowCellAreaUIElement = (Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)objElement.GetAncestor(
                    (typeof(Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)));

                // ヘッダ部の場合は以下の処理をキャンセルする
                if (objRowCellAreaUIElement == null)
                {
                    return;
                }
            }

            this._selectedData = this.GetSelectedData();

            if (StartMovment == 1)
            {
                return;
            }

            if (this._selectedData != null)
            {
                this._dialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// 売上データグリッドキーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Result_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        if (this.uGrid_Result.ActiveCell != null)
                        {
                            if (this.uGrid_Result.ActiveCell.Row.Index == 0)
                            {
                                this.tEdit_SalesInputCode.Focus();
                            }
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// 検索タイマー起動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void timer_Search_Tick(object sender, EventArgs e)
        {
            timer_Search.Enabled = false;

#if False
			this.Search(this._para);
#endif
        }
        # endregion

        /// <summary>
        /// 明細ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_StockSearch_Click(object sender, EventArgs e)  // UNDONE:明細ボタンクリック
        {
            if (this.uGrid_Result.ActiveRow == null)
            {
                return;
            }

            // 現在選択行の売上伝票情報取得
            SalesSlipSearchResult salesSlipSearchResult = this.GetSelectedData();

            // 明細参照画面を起動
            MAHNB04110UC searchDetail = new MAHNB04110UC(_salesSlipSearchAcs, salesSlipSearchResult);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            searchDetail.SetDecisionButtonEnabled( this._selectButton.SharedProps.Enabled );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD

            // ADD 2009/12/03 MANTIS対応[14742]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
            // FIXME:明細表示画面のグリッド列情報をロード時に設定
            searchDetail.Load += new EventHandler(this.LoadDetailGridSettings);
            // FIXME:明細表示画面のグリッド列情報をクローズ時に取得
            searchDetail.FormClosing += new FormClosingEventHandler(this.SetDetailGridSettings);
            // ADD 2009/12/03 MANTIS対応[14742]：伝票および明細グリッド列の列設定の変更 ----------<<<<<

            DialogResult dialogResult = searchDetail.ShowDialog(this);

            if (dialogResult == DialogResult.OK)
            {
                this._selectedData = this.GetSelectedData();
                this._dialogResult = DialogResult.OK;	//this.SetMainDialogResult(DialogResult.OK);
                this.Close();	//this.CloseMain();
            }
        }

        private void tComboEditor_SalesFormalCode_ValueChanged(object sender, EventArgs e)
        {
            int code = Convert.ToInt32(this.tComboEditor_SalesFormalCode.Value);

            if (_para.AcptAnOdrStatus != code)
            {
                //伝票区分を設定
                // --- CHG 2009/01/29 障害ID:7552対応------------------------------------------------------>>>>>
                //this._salesSlipSearchAcs.SetSalesSlipCdComboEditor(ref tComboEditor_SalesSlipCd, code);
                this._salesSlipSearchAcs.SetSalesSlipCdComboEditor(ref tComboEditor_SalesSlipCd, code, (SalesSlipSearchAcs.ExtractSlipCdType)this._extractSlipCdType);
                // --- CHG 2009/01/29 障害ID:7552対応------------------------------------------------------<<<<<

                Lb_SearchSlipDate_SetName((int)tComboEditor_SalesFormalCode.Value);
            }
        }

        /// <summary>
        /// 日付検索のラベル名称を設定
        /// </summary>
        /// <param name="cd"></param>
        private void Lb_SearchSlipDate_SetName(int cd)
        {
            switch (cd)
            {
                //10,15:見積,20:受注,30:売上,40:出荷
                case 10:
                case 15:
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
                case 16:
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD
                    //日付
                    Lb_SearchSlipDate.Text = "見積日";
                    //tEdit_PartySaleSlipNum.Enabled = false;
                    tNedit_ClaimCode.Enabled = false;
                    uButton_ClaimGuide.Enabled = false;

                    //tEdit_PartySaleSlipNum.Clear();
                    tNedit_ClaimCode.Clear();
                    uLabel_ClaimName.Text = "";

                    break;
                case 20:
                    //日付
                    Lb_SearchSlipDate.Text = "受注日";
                    //tEdit_PartySaleSlipNum.Enabled = true;
                    tNedit_ClaimCode.Enabled = true;
                    uButton_ClaimGuide.Enabled = true;
                    break;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 DEL
                //case 30:
                //    //日付
                //    Lb_SearchSlipDate.Text = "売上日";
                //    //tEdit_PartySaleSlipNum.Enabled = true;
                //    tNedit_ClaimCode.Enabled = true;
                //    uButton_ClaimGuide.Enabled = true;
                //    break;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 DEL
                case 40:
                    //日付
                    Lb_SearchSlipDate.Text = "貸出日";
                    //tEdit_PartySaleSlipNum.Enabled = true;
                    tNedit_ClaimCode.Enabled = true;
                    uButton_ClaimGuide.Enabled = true;
                    break;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
                case 30:
                default:
                    //日付
                    Lb_SearchSlipDate.Text = "売上日";
                    //tEdit_PartySaleSlipNum.Enabled = true;
                    tNedit_ClaimCode.Enabled = true;
                    uButton_ClaimGuide.Enabled = true;
                    break;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            if ( tNedit_ClaimCode.Enabled == false )
            {
                _para.ClaimCode = 0;
                _para.ClaimName = string.Empty;
                tNedit_ClaimCode.SetInt( 0 );
                uLabel_ClaimName.Text = string.Empty;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.15 TOKUNAGA ADD START

        /// <summary>
        /// 拠点ガイドボタンクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: 拠点ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: 徳永 俊詞</br>
        /// <br>Date		: 2008.07.15</br>
        /// </remarks>
        private void SectionCodeGuide_ultraButton_Click(object sender, EventArgs e)
        {
            SecInfoSet sectionInfo;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 DEL
            //int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out sectionInfo);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
            int status = this._secInfoSetAcs.ExecuteGuid( this._enterpriseCode, true, out sectionInfo );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                //this.tEdit_SectionCodeAllowZero.Text = sectionInfo.SectionCode.TrimEnd();
                //this.uLabel_SectionName.Text = sectionInfo.SectionGuideNm.TrimEnd();

                // 共通変数に保存
                this._dspSectionCode = sectionInfo.SectionCode.TrimEnd();

                // パラメータに保存
                this._para.SectionCode = sectionInfo.SectionCode.TrimEnd();
                this._para.SectionName = sectionInfo.SectionGuideNm.TrimEnd();

                // 抽出条件の各種コントロールに値を設定します。
                this.SetDisplayConditionInfo(this._para);

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                // 次フォーカス
                if ( tNedit_SubSectionCode.Enabled )
                {
                    this.tNedit_SubSectionCode.Focus();
                }
                else
                {
                    this.tNedit_CustomerCode.Focus();
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
        ///// <summary>
        ///// 拠点コード入力欄Leave処理
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        ///// <remarks>
        ///// <br>Note		: 拠点コード入力欄をLeaveした時に発生します。</br>
        ///// <br>Programmer	: 徳永 俊詞</br>
        ///// <br>Date		: 2008.07.15</br>
        ///// </remarks>
        //private void tEdit_SectionCodeAllowZero_Leave(object sender, EventArgs e)
        //{
        //    string sectionCode = this.tEdit_SectionCodeAllowZero.Text;

        //    if (!String.IsNullOrEmpty(sectionCode))
        //    {
        //        SecInfoSet sectionInfo;
        //        int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);
        //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            //this.uLabel_SectionName.Text = sectionInfo.SectionGuideNm.TrimEnd();

        //            // 共通変数に保存
        //            this._dspSectionCode = sectionInfo.SectionCode.TrimEnd();

        //            // パラメータに保存
        //            this._para.SectionCode = sectionInfo.SectionCode.TrimEnd();
        //            this._para.SectionName = sectionInfo.SectionGuideNm.TrimEnd();
        //        }
        //    }
        //    else
        //    {
        //        this._para.SectionCode = "000000";
        //        this._para.SectionName = string.Empty;
        //    }
        //    // 抽出条件の各種コントロールに値を設定します。
        //    this.SetDisplayConditionInfo(this._para);
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
        ///// <summary>
        ///// 部門コード入力欄Leave処理
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        ///// <remarks>
        ///// <br>Note		: 部門コード入力欄をLeaveした時に発生します。拠点コードが入力・選択されている必要があります。</br>
        ///// <br>Programmer	: 徳永 俊詞</br>
        ///// <br>Date		: 2008.07.15</br>
        ///// </remarks>
        //private void tNedit_SubSectionCode_Leave(object sender, EventArgs e)
        //{
        //    // 拠点コードが選択されている必要がある
        //    if (this._dspSectionCode == null) return;

        //    string subSectionCode = this.tNedit_SubSectionCode.Text;

        //    if (!String.IsNullOrEmpty(subSectionCode))
        //    {
        //        SubSection subSection;
        //        int status = this._subSectionAcs.Read(out subSection, this._enterpriseCode, this._dspSectionCode, int.Parse(subSectionCode));
        //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            //this.tNedit_SubSectionCode.Text = subSection.SubSectionName.TrimEnd();

        //            // 共通変数に保存
        //            this._dspSubSectionCode = subSection.SubSectionCode;

        //            // パラメータに保存
        //            this._para.SubSectionCode = subSection.SubSectionCode;
        //            this._para.SubSectionName = subSection.SubSectionName;
        //        }
        //    }
        //    else
        //    {
        //        this._dspSubSectionCode = 0;

        //        // パラメータから削除
        //        this._para.SubSectionCode = 0;
        //        this._para.SubSectionName = string.Empty;
        //    }

        //    // 抽出条件の各種コントロールに値を設定します。
        //    this.SetDisplayConditionInfo(this._para);
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL

        /// <summary>
        /// 部門ガイドボタンクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: 部門ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: 徳永 俊詞</br>
        /// <br>Date		: 2008.07.15</br>
        /// </remarks>
        private void ultraButton_SubSectionGuide_Click(object sender, EventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
            //// 拠点コードが選択されている必要がある
            //if (this._dspSectionCode == null) return;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL

            SubSection subSection;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
            //int status = this._subSectionAcs.ExecuteGuid(out subSection, this._enterpriseCode, this._dspSectionCode);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
            string sectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim();
            int status = this._subSectionAcs.ExecuteGuid( out subSection, this._enterpriseCode, sectionCode );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //this.tNedit_SubSectionCode.Text = subSection.SubSectionCode.ToString();
                //this.uLabel_SubSectionName.Text = subSection.SubSectionName.TrimEnd();

                // 共通変数に保存
                this._dspSubSectionCode = subSection.SubSectionCode;

                // パラメータに保存
                this._para.SubSectionCode = subSection.SubSectionCode;
                this._para.SubSectionName = subSection.SubSectionName;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                // 抽出条件の各種コントロールに値を設定します。
                this.SetDisplayConditionInfo( this._para );
                // 次フォーカス
                tNedit_CustomerCode.Focus();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
            //// 抽出条件の各種コントロールに値を設定します。
            //this.SetDisplayConditionInfo(this._para);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
        }

        /// <summary>
        /// 得意先入力フィールドLeave処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: 得意先入力フィールドから移動する時に発生します。</br>
        /// <br>Programmer	: 徳永 俊詞</br>
        /// <br>Date		: 2008.07.15</br>
        /// </remarks>
        private void tNedit_CustomerCode_Leave(object sender, EventArgs e)
        {
            int customerCode;

            customerCode = this.tNedit_CustomerCode.GetInt();
            if (customerCode > 0)
            {
                CustomerInfo customerInfo;
                int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._enterpriseCode, customerCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.uLabel_CustomerName.Text = customerInfo.CustomerSnm.TrimEnd();

                    // 共通変数に保存
                    this._customerCode = customerInfo.CustomerCode;

                    // 抽出条件の各種コントロールに値を設定します。
                    this.SetDisplayConditionInfo(this._para);
                }
            }
            else
            {
                // 名称をクリア
                this.uLabel_CustomerName.Text = string.Empty;

                // 共通変数、パラメータより削除
                this._customerCode = 0;
                this._para.CustomerCode = 0;
                this._para.CustomerName = string.Empty;
            }
        }

        /// <summary>
        /// 請求先ガイドボタンクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: 部門ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: 徳永 俊詞</br>
        /// <br>Date		: 2008.07.15</br>
        /// </remarks>
        private void tNedit_ClaimCode_Leave(object sender, EventArgs e)
        {
            int claimCode;

            claimCode = this.tNedit_ClaimCode.GetInt();
            if (claimCode > 0)
            {
                CustomerInfo customerInfo;
                int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._enterpriseCode, claimCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.uLabel_ClaimName.Text = customerInfo.ClaimName.TrimEnd();

                    // 共通変数に保存
                    this._claimCode = customerInfo.ClaimCode;

                    // 抽出条件の各種コントロールに値を設定します。
                    this.SetDisplayConditionInfo(this._para);
                }
            }
        }

        /// <summary>
        /// 入力者ガイドボタンクリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: 部門ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: 徳永 俊詞</br>
        /// <br>Date		: 2008.07.15</br>
        /// </remarks>
        private void uButton_FrontEmployeeCd_Click(object sender, EventArgs e)
        {
            EmployeeAcs employeeAcs = new EmployeeAcs();
            Employee employee;
            int status = employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (this._para.SalesInputCode.Trim() != employee.EmployeeCode.Trim()))
            {
                this._para.FrontEmployeeCd = employee.EmployeeCode.Trim();
                this._para.FrontEmployeeName = employee.Name;

                // 抽出条件の各種コントロールに値を設定する。
                this.SetDisplayConditionInfo(this._para);

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
                // 次フォーカス
                this.uGrid_Result.Focus();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD
            }
        }

        private void tEdit_FullModel_ValueChanged(object sender, EventArgs e)
        {
            string fullModelValue = this.tEdit_FullModel.Text;

            if (fullModelValue.Trim().Length > 0)
            {
                this._para.FullModel = fullModelValue.Trim();
            }
            else
            {
                this._para.FullModel = string.Empty;
            }
        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.15 TOKUNAGA ADD END

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/09 ADD
        /// <summary>
        /// ＵＩ設定ＸＭＬからのコードフォーマット取得(00,000,0000… etc.)
        /// </summary>
        /// <param name="editName"></param>
        /// <returns></returns>
        private string GetCodeFormat( string editName )
        {
            UiSet uiset;
            int status = uiSetControl1.ReadUISet( out uiset, editName );
            if ( status == 0 )
            {
                return string.Format( "{0};-{0};''", new string( '0', uiset.Column ) );
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 得意先コードフォーマット取得
        /// </summary>
        /// <returns></returns>
        private string GetCustomerCodeFormat()
        {
            return GetCodeFormat( "tNedit_CustomerCode" );
        }
        /// <summary>
        /// ＢＬコードフォーマット取得
        /// </summary>
        /// <returns></returns>
        private string GetBLGoodsCodeFormat()
        {
            return GetCodeFormat( "tNedit_BLGoodsCode" );
        }

        /// <summary>
        /// フォーム表示イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAHNB04110UA_Shown( object sender, EventArgs e )
        {
            if ( _autoSearch )
            {
                // 検索処理
                SearchDataForInitialSearch();
                this.uGrid_Result.Focus();
            }
            else
            {
                this.tEdit_SectionCodeAllowZero.Focus();
            }
        }
        /// <summary>
        /// 起動時自動実行用初期検索処理
        /// </summary>
        private void SearchDataForInitialSearch()
        {
            isFirstOfAutoSearch = true;

            // 
            Clear();

            // パラメータ生成
            CreateSearchParameterForInitialSearch( ref _para );

            // 抽出条件の各種コントロールに値を設定する。
            this.SetDisplayConditionInfo( _para );

            // 検索実行
            Search( _para );
        }

        /// <summary>
        /// パラメータ生成
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        private void CreateSearchParameterForInitialSearch( ref SalesSlipSearch para )
        {
            if ( para == null )
            {
                para = new SalesSlipSearch();
            }

            para.SectionCode = this.SectionCode.Trim();
            para.SectionName = this.SectionName.Trim();
            para.CustomerCode = this.CustomerCode;
            para.CustomerName = this.CustomerName.Trim();
            para.ClaimCode = this.ClaimCode;
            para.ClaimName = this.ClaimName.Trim();
            para.SalesDateSt = this.SalesDate;
            para.SalesDateEd = this.SalesDate;
            para.AcptAnOdrStatus = this.AcptAnOdrStatus;
            para.SalesSlipCd = this.SalesSlipCd;
            para.SalesEmployeeCd = this.SalesEmployeeCd;
            para.SalesInputCode = this.SalesInputCode;
            para.FrontEmployeeCd = this.FrontEmployeeCd;
            para.SalesEmployeeName = this.SalesEmployeeName;
            para.SalesInputName = this.SalesInputName;
            para.FrontEmployeeName = this.FrontEmployeeName;

            // 外部からのセット内容の補正
            if ( this.SectionCode.Trim() == string.Empty )
            {
                UiSet uiset;
                uiSetControl1.ReadUISet( out uiset, tEdit_SectionCodeAllowZero.Name );
                para.SectionCode = new string( '0', uiset.Column );
                para.SectionName = ct_AllSection;
            }
            if ( this.AcptAnOdrStatus == 0 )
            {
                para.AcptAnOdrStatus = -1; // -1:全て
            }
            if ( this.SalesDate == DateTime.MinValue )
            {
                if ( this.SectionCode.Trim() == string.Empty )
                {
                    para.SalesDateSt = GetPrevTotalDayNextDay( LoginInfoAcquisition.Employee.BelongSectionCode );
                    para.SalesDateEd = DateTime.Today;
                }
                else
                {
                    para.SalesDateSt = GetPrevTotalDayNextDay( this.SectionCode.Trim() );
                    para.SalesDateEd = DateTime.Today;
                }
            }
            if (this.AcptAnOdrStatus == 16)
            {
                para.SalesSlipCd = -1;
            }
        }

        private void tEdit_SectionCodeAllowZero_Enter( object sender, EventArgs e )
        {
            // ゼロサプレス
            tEdit_SectionCodeAllowZero.Text = this.uiSetControl1.GetZeroPadCanceledText( "tEdit_SectionCode", tEdit_SectionCodeAllowZero.Text );
        }


        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/09 ADD

        // ADD 2009/12/03 MANTIS対応[14742]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
        #region グリッドの設定情報

        /// <summary>FIXME:グリッド情報XMLファイル名</summary>
        private const string XML_FILE_NAME = "DCHNB04120U_Construction.XML";

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

        /// <summary>
        /// 明細情報グリッドにグリッド設定情報を展開します。
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void LoadDetailGridSettings(
            object sender,
            EventArgs e
        )
        {
            MAHNB04110UC detailForm = sender as MAHNB04110UC;
            if (detailForm == null) return;

            // 列移動と列固定を可能とする
            SlipGridUtil.EnableAllowColSwappingAndFixedHeaderIndicator(detailForm.DetailGrid);
            // グリッド列の設定を取込
            SlipGridUtil.LoadColumnInfo(detailForm.DetailGrid, GridSettings.DetailColumnsList);
            // ---------------------- ADD START 2011/07/18 朱宝軍 ----------------->>>>>
            // PCCオプション情報再設定
            if (detailForm.Opt_Pcc == 1)
            {
                detailForm.DetailGrid.DisplayLayout.Bands[0].Columns[this._dataSet.SalesDetail.AutoAnswerDivSCMColumn.ColumnName].Hidden = false;
            }
            else
            {
                detailForm.DetailGrid.DisplayLayout.Bands[0].Columns[this._dataSet.SalesDetail.AutoAnswerDivSCMColumn.ColumnName].Hidden = true;
            }
            // ---------------------- ADD END   2011/07/18 朱宝軍 -----------------<<<<<
        }

        /// <summary>
        /// 明細情報グリッドのグリッド設定情報を設定します。
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void SetDetailGridSettings(
            object sender,
            FormClosingEventArgs e
        )
        {
            MAHNB04110UC detailForm = sender as MAHNB04110UC;
            if (detailForm == null) return;

            // 明細情報画面のグリッド列情報を生成
            GridSettings.DetailColumnsList = SlipGridUtil.CreateColumnInfoList(detailForm.DetailGrid);
        }

        #endregion // グリッドの設定情報

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

        // ADD 2009/12/03 MANTIS対応[14742]：伝票および明細グリッド列の列設定の変更 ----------<<<<<
    }
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
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
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD

    // 2008.11.11 add start [7552]
    public enum ExtractSlipCdType : int
    {
        /// <summary>全て</summary>
        All = 0,
        /// <summary>売上</summary>
        Sales = 1,
        /// <summary>返品</summary>
        Return = 2,
    }
    // 2008.11.11 add end [7552]

    // ADD 2009/12/03 MANTIS対応[14742]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
    #region 伝票グリッド

    /// <summary>
    /// 伝票グリッドユーティリティ
    /// </summary>
    /// <remarks>
    /// 以下の機能で参照しています。<br/>
    /// ・売上履歴照会<br/>
    /// ・仕入伝票照会<br/>
    /// ・仕入履歴照会
    /// </remarks>
    public static class SlipGridUtil
    {
        #region 列を設定

        /// <summary>
        /// 列交換と列固定を可能とします。
        /// </summary>
        /// <param name="grid">対象グリッド</param>
        public static void EnableAllowColSwappingAndFixedHeaderIndicator(UltraGrid grid)
        {
            #region Guard Phrase

            if (grid == null) return;

            #endregion // Guard Phrase

            // 列交換を可能にする
            grid.DisplayLayout.Override.AllowColSwapping = AllowColSwapping.WithinGroup;
            // 列固定を可能にする
            grid.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.Button;
        }

        #endregion // 列を設定

        #region 設定の展開

        /// <summary>
        /// グリッドの表示設定を読み込みます。
        /// </summary>
        /// <remarks>
        /// 【参考】得意先電子元帳：PMKAU04004UA.Deserialize()
        /// </remarks>
        /// <param name="xmlFileName">設定XMLファイル名</param>
        public static GridSettingsType ReadGridSettings(string xmlFileName)
        {
            string filePath = Path.Combine(ConstantManagement_ClientDirectory.UISettings, xmlFileName);
            if (!UserSettingController.ExistUserSetting(filePath)) return new GridSettingsType();

            GridSettingsType gridSettings = null;
            try
            {
                gridSettings = UserSettingController.DeserializeUserSetting<GridSettingsType>(filePath);
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.ToString());
                return new GridSettingsType();
            }
            return gridSettings;
        }

        /// <summary>
        /// 列情報を取り込みます。
        /// </summary>
        /// <remarks>
        /// 【参考】得意先電子元帳：PMKAU04001UA.LoadGridColumnsSetting()
        /// </remarks>
        /// <param name="grid">対象グリッド</param>
        /// <param name="columnInfoList">列情報</param>
        public static void LoadColumnInfo(
            UltraGrid grid,
            List<ColumnInfo> columnInfoList
        )
        {
            #region Guard Phrase

            if (columnInfoList == null || columnInfoList.Count.Equals(0)) return;

            #endregion // Guard Phrase

            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
            foreach (ColumnInfo columnInfo in columnInfoList)
            {
                try
                {
                    UltraGridColumn ultraGridColumn = grid.DisplayLayout.Bands[0].Columns[columnInfo.ColumnName];
                    {
                        ultraGridColumn.Header.VisiblePosition = columnInfo.VisiblePosition;
                        ultraGridColumn.Hidden = columnInfo.Hidden;
                        ultraGridColumn.Header.Fixed = columnInfo.ColumnFixed;
                        ultraGridColumn.Width = columnInfo.Width;
                    }
                }
                catch (Exception ex)
                {
                    Debug.Assert(false, ex.ToString());
                }
            }
        }

        #endregion // 設定の展開

        #region 設定の保存

        /// <summary>
        /// グリッドの表示設定を保存します。
        /// </summary>
        /// <remarks>
        /// 【参考】得意先電子元帳：PMKAU04004UA.Serialize()
        /// </remarks>
        /// <param name="gridSettings">グリッドの設定情報</param>
        /// <param name="xmlFileName">設定XMLファイル名</param>
        public static void StoreGridSettings(
            GridSettingsType gridSettings,
            string xmlFileName
        )
        {
            try
            {
                string fileName = Path.Combine(ConstantManagement_ClientDirectory.UISettings, xmlFileName);

                UserSettingController.SerializeUserSetting(gridSettings, fileName);

                #region 実験コード
                //CustPtrSalesUserConst test = new CustPtrSalesUserConst();
                //test.OutputPattern = new string[0];
                //test.SlipColumnsList = new List<ColumnInfo>();
                //test.DetailColumnsList = columnInfoList; 
                //test.RedSlipColumnsList = new List<ColumnInfo>();
                //test.EnabledConditionList = new List<string>();
                //UserSettingController.SerializeUserSetting(test, fileName);
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// 列情報リストを生成します。
        /// </summary>
        /// <remarks>
        /// 【参考】得意先電子元帳：PMKAU04001UA.SaveGridColumnsSetting()
        /// </remarks>
        /// <param name="grid">対象グリッド</param>
        /// <returns>対象グリッドより列情報を抽出し、リストで返します。</returns>
        public static List<ColumnInfo> CreateColumnInfoList(UltraGrid grid)
        {
            #region Guard Phrase

            if (grid == null) return new List<ColumnInfo>();

            #endregion // Guard Phrase

            List<ColumnInfo> columnInfoList = new List<ColumnInfo>();
            {
                foreach (UltraGridColumn ultraGridColumn in grid.DisplayLayout.Bands[0].Columns)
                {
                    columnInfoList.Add(new ColumnInfo(
                        ultraGridColumn.Key,
                        ultraGridColumn.Header.VisiblePosition,
                        ultraGridColumn.Hidden,
                        ultraGridColumn.Width,
                        ultraGridColumn.Header.Fixed
                    ));
                }
            }
            return columnInfoList;
        }

        #endregion // 設定の保存
    }

    #region 伝票グリッド設定情報

    /// <summary>
    /// 伝票グリッド設定情報クラス
    /// </summary>
    [Serializable]
    public class SlipGridSettings : CustPtrSalesUserConst
    {
        #region Constructor

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SlipGridSettings() : base()
        {
            base.OutputPattern          = new string[0];
            base.SlipColumnsList        = new List<ColumnInfo>();
            base.DetailColumnsList      = new List<ColumnInfo>();
            base.RedSlipColumnsList     = new List<ColumnInfo>();
            base.EnabledConditionList   = new List<string>();
        }

        #endregion // Constructor
    }

    #endregion // 伝票グリッド設定情報

    #endregion // 伝票グリッド
    // ADD 2009/12/03 MANTIS対応[14742]：伝票および明細グリッド列の列設定の変更 ----------<<<<<
}

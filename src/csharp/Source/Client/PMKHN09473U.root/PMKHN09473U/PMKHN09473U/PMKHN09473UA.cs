//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率設定マスタメン（掛率優先管理パターン）（単独指定）
// プログラム概要   : 掛率設定マスタメン（掛率優先管理パターン）（単独指定）の処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 楊明俊
// 作 成 日  2010/08/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 修 正 日  2010/08/31  修正内容 : Redmine#14030対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 修 正 日  2010/09/10  修正内容 : 障害・改良対応8月ﾘﾘｰｽ
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 修 正 日  2010/09/30  修正内容 : Redmine#15703対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 許培珠
// 修 正 日  2011/11/21  修正内容 : Redmine#7867対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Infragistics.Win.Misc;
using System.Collections;
using Infragistics.Win;
using Broadleaf.Library.Resources;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using System.Net.NetworkInformation;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 掛率設定マスタメンフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 掛率設定マスタメンのフォームクラスです。</br>
    /// <br>Programmer	: 楊明俊</br>
    /// <br>Date		: 2010/08/12</br>
    /// <br>Update Note : 2010/08/31 呉元嘯</br>
    /// <br>            : Redmine#14030対応</br>
    /// <br>Update Note: 2010/09/10 高峰 障害・改良対応8月ﾘﾘｰｽ</br>
    /// <br>Update Note : 2010/09/25 朱 猛</br>
    /// <br>            : Redmine#14492対応</br>
    /// <br>Update Note : 2011/11/21 許培珠</br>
    /// <br>            : Redmine#7867対応</br>
    /// </remarks>
    public partial class PMKHN09473UA : Form
    {

        #region Private Members
        private bool _cusotmerGuideSelected;                // 得意先ガイド選択フラグ

        // 前回値保持用変数
        private int _prevCustomerCode;
        private int _prevSupplierCode;
        private int _prevMakerCode;
        private int _prevCustRateGrpCode;
        private int _prevBLGoodsCode;
        private int _prevBLGroupCode;
        private int _prevGoodsRateGrpCode;

        // 企業コード取得用
        private string _enterpriseCode;
        // ログイン拠点(自拠点)
        private string _loginSectionCode;

        private CustomerInfoAcs _customerInfoAcs = null;    // 得意先アクセスクラス
        private SupplierAcs _supplierAcs = null;            // 仕入先アクセスクラス
        private MakerAcs _makerAcs = null;					// メーカーアクセスクラス
        private UserGuideAcs _userGuideAcs = null;			// ユーザーガイドアクセスクラス
        private SecInfoAcs _secInfoAcs; // 拠点アクセスクラス
        private BLGoodsCdAcs _blGoodsCdAcs = null;			// BLアクセスクラス
        private GoodsGroupUAcs _goodsGroupUAcs = null;      // 商品掛率Ｇアクセスクラス
        private BLGroupUAcs _blGroupUAcs = null;            // BLグループアクセスクラス

        private RateProtyMngConstructionAcs _rateProtyMngConstructionAcs;
        private Dictionary<int, string> _custRateGrpDic;

        private RateProtyMng _rateProtyMng;// 掛率優先管理マスタ
        private RateProtyMngPatternAcs _rateProtyMngPatternAcs;// 掛率設定マスタメン（掛率優先管理パターン）アクセス
        private RateProtyMngPatternDataSet _rateProtyMngPatternDataSet;// 掛率マスタデータセット

        /// <summary>グリッド最上位行キーダウンイベント</summary>
        internal event EventHandler GridKeyDownTopRow;

        private ControlScreenSkin _controlScreenSkin;

        private Dictionary<int, Supplier> _supplierDic;
        private Dictionary<int, MakerUMnt> _makerUMntDic;
        private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdUMntDic;
        private Dictionary<int, GoodsGroupU> _goodsGroupUDic;
        private Dictionary<int, BLGroupU> _blGroupUDic;

        private RateProtyMngPatternWork _rateProtyMngPatternWorkClone;// 画面抽出条件部Compare用

        private object _initFocus;
        private object _endFocus;
        private object _endButtonFocus;
        private int _cellMove;
        // ---ADD 2010/09/09---------------------->>>
        private bool _closeFlg = false;
        private bool _errorFlg = false;
        private bool _guideToolClick = false;
        private bool _initFocusFlag = false;
        private bool _checkEmptyFlg = false;
        private UltraGridCell _preUnPrcFracProcDivNmCell = null;
        private bool _checkInputScreenErr = false;
        private bool _noValueFlg = false;
        private bool _searchAfterSaveFlg = false;
        private bool _deleteButtonFlag = false;
        private bool _gridGuideFlag = false; // ADD 2010/09/25
        private int _searchStatus = 0; // 1:NO,2:CANCEL, ADD 20010/09/26
        private int _prevIndexRow = -1;
        private int _prevIndexColumn = -1;
        // ---ADD 2010/09/09----------------------<<<

        // ---ADD 2010/09/09---------------------->>>
        private const string TOOLBAR_GUIDEBUTTON_KEY = "ButtonTool_Guide";		                // ガイド
        private const string TOOLBAR_ALLROWDELETE_KEY = "ButtonTool_DelALLRow";                 // 全削除
        private const string UnitPriceKindNM_1 = "売価設定";
        private const string UnitPriceKindNM_2 = "原価設定";
        private const string UnitPriceKindNM_3 = "価格設定";
        // ---ADD 2010/09/09----------------------<<<
        private string masterCode = string.Empty; // ADD 2010/09/25

        #endregion Private Members

        #region Const
        // 編集モード
        private const string INSERT_MODE = "新規";
        private const string UPDATE_MODE = "更新";

        // ---UPD 2010/09/09---------------------->>>
        //private const string UNPRCFRACPROCDIV_1 = "切捨て";
        //private const string UNPRCFRACPROCDIV_2 = "四捨五入";
        //private const string UNPRCFRACPROCDIV_3 = "切上げ";
        private const string UNPRCFRACPROCDIV_1 = "1:切捨て";
        private const string UNPRCFRACPROCDIV_2 = "2:四捨五入";
        private const string UNPRCFRACPROCDIV_3 = "3:切上げ";
        // ---UPD 2010/09/09----------------------<<<
        // アセンブリID
        private const string CT_PGID = "PMKHN09473U";
        private const string CT_PGNM = "掛率設定マスタメン";

        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";						// 終了
        private const string TOOLBAR_CLEARBUTTON_KEY = "ButtonTool_Clear";						// クリア
        private const string TOOLBAR_SETBUTTON_KEY = "ButtonTool_Set";						    // 設定
        private const string TOOLBAR_SEARCHBUTTON_KEY = "ButtonTool_Search";					// 検索
        private const string TOOLBAR_SAVEBUTTON_KEY = "ButtonTool_Save";						// 保存
        private const string TOOLBAR_SECTIONTITLELABEL_KEY = "LabelTool_SectionTitle";			// ログイン拠点
        private const string TOOLBAR_SECTIONNAMELABEL_KEY = "LabelTool_SectionName";			// ログイン拠点名称
        private const string TOOLBAR_ROWDELETE_KEY = "ButtonTool_DelRow";                       // 行削除
        private const string TOOLBAR_LOGINTITLELABEL_KEY = "LabelTool_LoginTitle";				// ログイン担当者タイトル
        private const string TOOLBAR_LOGINNAMELABEL_KEY = "LabelTool_LoginName";		     // ログイン担当者名称
        // 表示形式のある列で使用
        private const string FORMAT_FRACTION = "#,##0.00;-#,##0.00;''";
        private const string FORMAT_CODE = "#0;-#0;''"; // ADD 2010/09/25

        // --------ADD 2010/09/09-------->>>>>
        private const string TOOLBAR_GUIDE_KEY = "ButtonTool_Guide";		     // ガイド
        // --------ADD 2010/09/09--------<<<<<
        #endregion Const

        #region Constructor
        /// <summary>
        /// 掛率設定マスタメン（掛率優先管理パターン）（単独指定）フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 掛率設定マスタメン（掛率優先管理パターン）（単独指定）フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 楊明俊</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        public PMKHN09473UA(RateProtyMng rateProtyMng)
        {
            InitializeComponent();
            this._controlScreenSkin = new ControlScreenSkin();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            this._customerInfoAcs = new CustomerInfoAcs();
            this._supplierAcs = new SupplierAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._makerAcs = new MakerAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._blGroupUAcs = new BLGroupUAcs();
            this._goodsGroupUAcs = new GoodsGroupUAcs();
            this._rateProtyMngConstructionAcs = new RateProtyMngConstructionAcs();
            this._rateProtyMng = rateProtyMng;
            this._rateProtyMngPatternAcs = RateProtyMngPatternAcs.GetInstance();
            this._rateProtyMngPatternDataSet = this._rateProtyMngPatternAcs.RateProtyMngPatternDataSet;
            this.Detail_uGrid.DataSource = this._rateProtyMngPatternDataSet.RateProtyMngPattern;
            this._rateProtyMngPatternWorkClone = new RateProtyMngPatternWork();
            GridKeyDownTopRow += new EventHandler(this.Detail_uGrid_GridKeyDownTopRow);

        }

        #endregion Constructor

        #region Event
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: フォームが読み込まれた時に発生します。</br>
        /// <br>Programmer	: 楊明俊</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        private void PMKHN09473UA_Load(object sender, EventArgs e)
        {
            // アイコン設定
            SetIcon();

            // 画面入力許可制御
            ScreenInputEnable();

            // 画面クリア
            ScreenClear();
            this._cellMove = this._rateProtyMngConstructionAcs.CellMove;
            this.Detail_uGrid.DataSource = this._rateProtyMngPatternAcs.RateProtyMngPatternDataSet;

            // ----------ADD 2010/09/09----------->>>>>
            // スキン変更除外設定
            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add(this.ultraExpandableGroupBox_Condition.Name);
            this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);
            // ----------ADD 2010/09/09-----------<<<<<

            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // ----------ADD 2010/09/09----------->>>>>
            #region ■ガイド有効無効の設定
            string rateSettingDivide = this._rateProtyMng.RateMngCustCd.Trim() + this._rateProtyMng.RateMngGoodsCd.Trim();
            switch (rateSettingDivide)
            {
                case "1L":
                case "3L": // 掛率設定区分=1L,3L　仕入先の場合
                    {
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                        break;
                    }
                default:
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
                    break;
            }
            #endregion

            this.Delete_Button.Enabled = false; // ADD 2010/09/09
            this.DeleteAll_Button.Enabled = false; // ADD 2010/09/09

            #region 検索
            if (!"1L".Equals(rateSettingDivide) && !"3L".Equals(rateSettingDivide))
            {
                this.Search();

                timer1.Enabled = true;

                return;
            }
            #endregion
            // ----------ADD 2010/09/09-----------<<<<<
        }

        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: ツールバー上のツールがクリックされた時に発生します。</br>
        /// <br>Programmer	: 楊明俊</br>
        /// <br>Date		: 2010/08/12</br>
        /// <br>Update Note : 2010/09/25 朱 猛</br>
        /// <br>            : Redmine#14492対応</br>
        /// <br>Update Note : 2010/09/30 朱 猛</br>
        /// <br>            : Redmine#15703対応</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // -------------------------------------------------------------------------------
                // 終了
                // -------------------------------------------------------------------------------
                case TOOLBAR_CLOSEBUTTON_KEY:
                    {
                        #region 終了
                        if (this.CloseCheck())
                        {
                            this.Close();
                        }
                        else
                        {
                            DialogResult dr = TMsgDisp.Show(
                                emErrorLevel.ERR_LEVEL_QUESTION,
                                CT_PGID,
                                "現在、編集中のデータが存在します\n\n" + "登録してもよろしいですか？",
                                0,
                                MessageBoxButtons.YesNoCancel);

                            switch (dr)
                            {
                                case DialogResult.No:
                                    _closeFlg = true;
                                    this.Close();
                                    break;
                                case DialogResult.Yes:
                                    if (this.SaveProc())
                                    {
                                        this.Close();
                                    }
                                    break;
                                case DialogResult.Ignore:
                                    break;
                                // ---ADD 2010/09/09---------------------->>>
                                case DialogResult.Cancel:
                                    if (this.Detail_uGrid.ActiveCell != null)
                                    {
                                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode); // ADD 2010/09/09
                                    }
                                    break;
                                // ---ADD 2010/09/09----------------------<<<
                            }
                        }
                        #endregion
                        break;
                    }
                // -------------------------------------------------------------------------------
                // 保存
                // -------------------------------------------------------------------------------
                case TOOLBAR_SAVEBUTTON_KEY:
                    {
                        #region 保存
                        //this.SaveProc(); // DEL 2010/09/09
                        // ---ADD 2010/09/09---------------------->>>
                        if ((this.SaveProc() || this._checkEmptyFlg) && (this.Detail_uGrid.Rows.Count != 0))
                        {
                            this._checkEmptyFlg = false;
                            if (this.Mode_Label.Text == INSERT_MODE)
                            {
                                if (!this._initFocusFlag)
                                {
                                    this.Detail_uGrid.Focus();
                                    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                    //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                    this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                    this.InitGridFocus(0, 0);
                                }
                                else
                                {
                                    this._initFocusFlag = false;
                                }
                            }
                            else
                            {
                                this.Detail_uGrid.Focus();
                                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                                this.SetGridTabFocus(ref evt);
                            }
                        }
                        else
                        {
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            //this.Delete_Button.Enabled = false; // DEL 2010/09/25
                            //this.DeleteAll_Button.Enabled = false; // DEL 2010/09/25
                            return;
                        }
                        // ---ADD 2010/09/09----------------------<<<
                        #endregion
                        break;
                    }
                // -------------------------------------------------------------------------------
                // クリア
                // -------------------------------------------------------------------------------
                case TOOLBAR_CLEARBUTTON_KEY:
                    {
                        #region クリア
                        if (this.CloseCheck())
                        {
                            this.ScreenClear();
                        }
                        else
                        {
                            DialogResult dr = TMsgDisp.Show(
                                            emErrorLevel.ERR_LEVEL_QUESTION,
                                            CT_PGID,
                                            "現在、編集中のデータが存在します\n\n" + "登録してもよろしいですか？",
                                            0,
                                            MessageBoxButtons.YesNoCancel);

                            switch (dr)
                            {
                                case DialogResult.No:
                                    this.ScreenClear();
                                    // ---ADD 2010/09/25---------------------->>>
                                    #region ■ガイド有効無効の設定
                                    if (this.Detail_uGrid.Rows.Count == 0 && this.tNedit_CustomerCode.Enabled == false && this.tNedit_CustRateGrpCodeZero.Enabled == false && this.tNedit_SupplierCd.Enabled == false
                                       && this.tNedit_BLGloupCode.Enabled ==false && this.tNedit_BLGoodsCode.Enabled == false && this.tNedit_GoodsMakerCd.Enabled == false && this.tNedit_GoodsMGroup.Enabled == false)
                                    {
                                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
                                    }
                                    #endregion
                                    // ---ADD 2010/09/25----------------------<<<
                                    break;
                                case DialogResult.Yes:
                                    if (this.SaveProc())
                                    {
                                        this.ScreenClear();
                                    }
                                    // ---ADD 2010/09/25---------------------->>>
                                    #region ■ガイド有効無効の設定
                                    if (this.Detail_uGrid.Rows.Count == 0 && this.tNedit_CustomerCode.Enabled == false && this.tNedit_CustRateGrpCodeZero.Enabled == false && this.tNedit_SupplierCd.Enabled == false
                                       && this.tNedit_BLGloupCode.Enabled == false && this.tNedit_BLGoodsCode.Enabled == false && this.tNedit_GoodsMakerCd.Enabled == false && this.tNedit_GoodsMGroup.Enabled == false)
                                    {
                                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
                                    }
                                    #endregion
                                    // ---ADD 2010/09/25----------------------<<<
                                    break;
                                case DialogResult.Ignore:
                                    // ---ADD 2010/09/25---------------------->>>
                                    #region ■ガイド有効無効の設定
                                    if (this.Detail_uGrid.Rows.Count == 0 && this.tNedit_CustomerCode.Enabled == false && this.tNedit_CustRateGrpCodeZero.Enabled == false && this.tNedit_SupplierCd.Enabled == false
                                       && this.tNedit_BLGloupCode.Enabled == false && this.tNedit_BLGoodsCode.Enabled == false && this.tNedit_GoodsMakerCd.Enabled == false && this.tNedit_GoodsMGroup.Enabled == false)
                                    {
                                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
                                    }
                                    #endregion
                                    // ---ADD 2010/09/25----------------------<<<
                                    break;
                                // ---ADD 2010/09/09---------------------->>>
                                case DialogResult.Cancel:
                                    if (this.Detail_uGrid.ActiveCell != null)
                                    {
                                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode); // ADD 2010/09/09
                                    }
                                    // ---ADD 2010/09/25---------------------->>>
                                    #region ■ガイド有効無効の設定
                                    if (this.Detail_uGrid.Rows.Count == 0 && this.tNedit_CustomerCode.Enabled == false && this.tNedit_CustRateGrpCodeZero.Enabled == false && this.tNedit_SupplierCd.Enabled == false
                                       && this.tNedit_BLGloupCode.Enabled == false && this.tNedit_BLGoodsCode.Enabled == false && this.tNedit_GoodsMakerCd.Enabled == false && this.tNedit_GoodsMGroup.Enabled == false)
                                    {
                                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
                                    }
                                    #endregion
                                    // ---ADD 2010/09/25----------------------<<<
                                    break;
                                // ---ADD 2010/09/09----------------------<<<
                            }
                        }
                        #endregion
                        // ---ADD 2010/09/25---------------------->>>
                        #region ■ガイド有効無効の設定
                        if (this.Detail_uGrid.Rows.Count == 0 && this.tNedit_CustomerCode.Enabled == false && this.tNedit_CustRateGrpCodeZero.Enabled == false && this.tNedit_SupplierCd.Enabled == false
                           && this.tNedit_BLGloupCode.Enabled == false && this.tNedit_BLGoodsCode.Enabled == false && this.tNedit_GoodsMakerCd.Enabled == false && this.tNedit_GoodsMGroup.Enabled == false)
                        {
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
                        }
                        #endregion
                        // ---ADD 2010/09/25----------------------<<<
                        break;
                    }
                // -------------------------------------------------------------------------------
                // 検索
                // -------------------------------------------------------------------------------
                case TOOLBAR_SEARCHBUTTON_KEY:
                    {
                        // ---ADD 2010/09/09---------------------->>>
                        #region 検索処理前、フォーカスを取る
                        if (this.Detail_uGrid.ActiveCell != null)
                        {
                            this._prevIndexRow = this.Detail_uGrid.ActiveCell.Row.Index;
                            this._prevIndexColumn = this.Detail_uGrid.ActiveCell.Column.Index;
                        }
                        #endregion
                        // ---ADD 2010/09/09----------------------<<<

                        #region 検索
                        // ---ADD 2010/09/09---------------------->>>
                        TNedit ctrlName = new TNedit();
                        object preCodeValue = null; // ADD 2010/09/25
                        if (this.tNedit_CustomerCode.Focused)
                        {
                            ctrlName = this.tNedit_CustomerCode;
                            if (this._prevCustomerCode != -1) preCodeValue = this._prevCustomerCode; // ADD 2010/09/25
                        }
                        else if (this.tNedit_CustRateGrpCodeZero.Focused)
                        {
                            ctrlName = this.tNedit_CustRateGrpCodeZero;
                            if (this._prevCustRateGrpCode != -1) preCodeValue = this._prevCustRateGrpCode; // ADD 2010/09/25
                        }
                        else if (this.tNedit_SupplierCd.Focused)
                        {
                            ctrlName = this.tNedit_SupplierCd;
                            if (this._prevSupplierCode != -1) preCodeValue = this._prevSupplierCode; // ADD 2010/09/25
                        }
                        else if (this.tNedit_GoodsMakerCd.Focused)
                        {
                            ctrlName = this.tNedit_GoodsMakerCd;
                            if (this._prevMakerCode != -1) preCodeValue = this._prevMakerCode; // ADD 2010/09/25
                        }
                        else if (this.tNedit_BLGoodsCode.Focused)
                        {
                            ctrlName = this.tNedit_BLGoodsCode;
                            if (this._prevBLGoodsCode != -1) preCodeValue = this._prevBLGoodsCode; // ADD 2010/09/25
                        }
                        else if (this.tNedit_GoodsMGroup.Focused)
                        {
                            ctrlName = this.tNedit_GoodsMGroup;
                            if (this._prevGoodsRateGrpCode != -1) preCodeValue = this._prevGoodsRateGrpCode; // ADD 2010/09/25
                        }
                        else if (this.tNedit_BLGloupCode.Focused)
                        {
                            ctrlName = this.tNedit_BLGloupCode;
                            if (this._prevBLGroupCode != -1) preCodeValue = this._prevBLGroupCode; // ADD 2010/09/25
                        }

                        this.tArrowKeyControl1_ChangeFocus(ctrlName, new ChangeFocusEventArgs(false, false, false, Keys.Space, ctrlName, ctrlName));
                        // ---ADD 2010/09/09----------------------<<<
                        //SearchRateData();
                        this.Search(); // ADD 2010/09/10
                        // ---ADD 2010/09/09---------------------->>>
                        // ---ADD 2010/09/25---------------------->>>
                        // 検索処理がキャンセルされた場合
                        if (this._searchStatus == 2)
                        {
                            if (preCodeValue != null)
                            {
                                if ((int)preCodeValue != -1)
                                {
                                    ctrlName.Value = preCodeValue;
                                }
                                else
                                {
                                    ctrlName.Value = "";
                                }
                                this.tArrowKeyControl1_ChangeFocus(ctrlName, new ChangeFocusEventArgs(false, false, false, Keys.Space, ctrlName, ctrlName));
                                ctrlName.Value = "";
                            }
                        }
                        else
                        // ---ADD 2010/09/25----------------------<<<
                        if (this.Detail_uGrid.Rows.Count != 0 && this._checkInputScreenErr == false && this._errorFlg == false)
                        {
                            if (this.Mode_Label.Text == INSERT_MODE)
                            {
                                if (!this._initFocusFlag)
                                {
                                    this.Detail_uGrid.Focus();
                                    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                    //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                    this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                    this.InitGridFocus(0, 0);
                                }
                                else
                                {
                                    this._initFocusFlag = false;
                                }
                            }
                            else
                            {
                                this.Detail_uGrid.Focus();
                                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                                this.SetGridTabFocus(ref evt);
                            }
                        }
                        this._searchStatus = 0; // ADD 2010/09/25
                        this._errorFlg = false;
                        this._checkInputScreenErr = false;
                        // ---ADD 2010/09/09----------------------<<<
                        #endregion
                        break;
                    }
                // -------------------------------------------------------------------------------
                // 設定
                // -------------------------------------------------------------------------------
                case TOOLBAR_SETBUTTON_KEY:
                    {
                        #region 設定
                        this.SetUp();
                        #endregion 設定
                        break;
                    }

                // -------------------------------------------------------------------------------
                // 行削除
                // -------------------------------------------------------------------------------
                case TOOLBAR_ROWDELETE_KEY:
                    {
                        // ---ADD 2010/09/10---------------------->>>
                        int rowIndex = 0;
                        if (this.Detail_uGrid.ActiveCell != null)
                        {
                            rowIndex = this.Detail_uGrid.ActiveCell.Row.Index;
                        }
                        else
                        {
                            if (this.Detail_uGrid.Rows.Count > 0)
                            {
                                //RowDelete(); // DEL 2010/09/30
                                if (!this.AllDeleteCheck())
                                {
                                    this.Delete_Button.Focus();
                                    return;
                                }
                            }
                            else
                            {
                                return;
                            }     
                        }
                        // ---ADD 2010/09/10----------------------<<<
                        this._deleteButtonFlag = true;// ADD 2010/09/10
                        //RowDelete(); // DEL 2010/09/25
                        //this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);  // DEL 2010/09/30
                        //RowDelete(); // DEL 2010/09/30
                        // ---ADD 2010/09/10---------------------->>>
                        if (this._errorFlg)
                        {
                            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = string.Empty;
                            this._errorFlg = false;
                        }
                        RowDelete(); // ADD 2010/09/30
                        if (!this.AllDeleteCheck())
                        {
                            this.Delete_Button.Focus();
                            break;
                        }

                        // ------DEL 2010/09/30---------------------->>>
                        //if (!CatchSelectedRow(rowIndex))
                        //{
                        //    ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                        //    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[SelectedRow()];
                        //    //this.Detail_uGrid.Rows[SelectedRow()].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                        //    this.Detail_uGrid.Rows[SelectedRow()].Cells[this.masterCode].Activate(); // ADD 2010/09/25
                        //    //this.SetGridTabFocus(ref evt);
                        //    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        //}
                        //else
                        //{
                        //    //this.Detail_uGrid_KeyDown(this.Detail_uGrid, new KeyEventArgs(Keys.Right));// DEL 2010/09/28
                        //}
                        // ------DEL 2010/09/30----------------------<<<

                        // ---ADD 2010/09/10----------------------<<<
                        this._deleteButtonFlag = false;// ADD 2010/09/10
                        break;
                    }

                // ---ADD 2010/09/10---------------------->>>
                // -------------------------------------------------------------------------------
                // 全削除
                // -------------------------------------------------------------------------------
                case TOOLBAR_ALLROWDELETE_KEY:
                    {
                        int rowIndex = 0;
                        if (this.Detail_uGrid.ActiveCell != null)
                        {
                            rowIndex = this.Detail_uGrid.ActiveCell.Row.Index;
                        }
                        this._deleteButtonFlag = true;
                        this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode); 
                        this._deleteButtonFlag = false;
                        if (this.AllDeleteEnabledCheck())
                        {
                            if (this._errorFlg)
                            {
                                ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = string.Empty;
                            }
                            AllRowDelete();
                            if (!this._errorFlg)
                            {
                                //this.Detail_uGrid_KeyDown(this.Detail_uGrid, new KeyEventArgs(Keys.Right));
                                ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[SelectedRow()];
                                //this.Detail_uGrid.Rows[SelectedRow()].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                this.Detail_uGrid.Rows[SelectedRow()].Cells[this.masterCode].Activate(); // ADD 2010/09/25
                                //this.SetGridTabFocus(ref evt);
                                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                break;
                            }
                            else
                            {
                                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            this._errorFlg = false;
                            if (!CatchSelectedRow(rowIndex))
                            {
                                ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[SelectedRow()];
                                //this.Detail_uGrid.Rows[SelectedRow()].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                this.Detail_uGrid.Rows[SelectedRow()].Cells[this.masterCode].Activate(); // ADD 2010/09/25
                                this.SetGridTabFocus(ref evt);
                            }
                        }
                        else
                        {
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode); 
                            return;
                        }
                        break;
                    }
                // -------------------------------------------------------------------------------
                // ガイド
                // -------------------------------------------------------------------------------
                case TOOLBAR_GUIDEBUTTON_KEY:
                    {
                        if (this.tNedit_CustomerCode.Focused)
                        {
                            this.CustomerGuide_Button_Click(this.tNedit_CustomerCode, new EventArgs()); 
                        }
                        else if (this.tNedit_CustRateGrpCodeZero.Focused)
                        {
                            this.CustRateGrpGuide_Button_Click(this.tNedit_CustRateGrpCodeZero, new EventArgs());
                        }
                        else if (this.tNedit_SupplierCd.Focused)
                        {
                            this.SupplierGuide_Button_Click(this.tNedit_SupplierCd, new EventArgs());
                        }
                        else if (this.tNedit_GoodsMakerCd.Focused)
                        {
                            this.MakerGuide_Button_Click(this.tNedit_GoodsMakerCd, new EventArgs());
                        }
                        else if (this.tNedit_BLGoodsCode.Focused)
                        {
                            this.BLGoodsGuide_Button_Click(this.tNedit_BLGoodsCode, new EventArgs());
                        }
                        else if (this.tNedit_GoodsMGroup.Focused)
                        {
                            this.GoodsRateGrpGuide_Button_Click(this.tNedit_GoodsMGroup, new EventArgs());
                        }
                        else if (this.tNedit_BLGloupCode.Focused)
                        {
                            this.BLGroupGuide_Button_Click(this.tNedit_BLGloupCode, new EventArgs());
                        }
                        //else if ((this.Detail_uGrid.ActiveCell != null) && this.Detail_uGrid.ActiveCell.Column.Key.Equals("MasterNm")) // DEL 2010/09/25
                        else if ((this.Detail_uGrid.ActiveCell != null) && this.Detail_uGrid.ActiveCell.Column.Key.Equals(masterCode)) // ADD 2010/09/25
                        {
                            this._guideToolClick = true;
                            ExcuteGuide();
                        }

                        break;
                    }
                // ---ADD 2010/09/10----------------------<<<
            }
            // ---ADD 2010/09/09---------------------->>>
            //#region ■行削除ボタン有効無効の設定
            //if (this.Detail_uGrid.ActiveCell != null)
            //{
            //    this.Delete_Button.Enabled = true;
            //}
            //else
            //{
            //    this.Delete_Button.Enabled = false;
            //}
            //#endregion

            //#region ■全削除ボタン有効無効の設定
            //if (this.AllDeleteEnabledCheck())
            //{
            //    this.DeleteAll_Button.Enabled = true;
            //}
            //else
            //{
            //    this.DeleteAll_Button.Enabled = false;
            //}
            //#endregion
            #region ■行削除/全削除ボタン有効無効の設定
            if (this.Detail_uGrid.Rows.Count != 0)
            {
                this.Delete_Button.Enabled = true;
                this.DeleteAll_Button.Enabled = true;
            }
            else
            {
                this.Delete_Button.Enabled = false;
                this.DeleteAll_Button.Enabled = false;
            }
            #endregion
            // ---ADD 2010/09/09----------------------<<<
        }

        /// <summary>
        /// ChangeFocus イベント(tArrowKeyControl1)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 各コントロールからフォーカスが離れたときに発生します。</br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date        : 2010/08/12</br>
        /// <br>Update Note : 2010/09/25 朱 猛</br>
        /// <br>            : Redmine#14492対応</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            switch (e.PrevCtrl.Name)
            {
                //-----------------------------------------------------
                // 得意先
                //-----------------------------------------------------
                case "tNedit_CustomerCode":
                    {
                        # region [得意先]
                        int inputValue = this.tNedit_CustomerCode.GetInt();

                        // 前回値と一致しない場合
                        if (_prevCustomerCode != inputValue)
                        {
                            // 入力無し
                            if (this.tNedit_CustomerCode.GetInt() == 0)
                            {
                                this.CustomerCodeNm_tEdit.Clear();
                                this.tNedit_CustomerCode.Clear();
                                //this._prevCustomerCode = 0; // DEL 2010/09/25
                                this._prevCustomerCode = -1; // ADD 2010/09/25
                            }
                            else
                            {
                                string name = string.Empty;
                                bool check = GetCustomerName(inputValue, out name);
                                if (check)
                                {
                                    this.CustomerCodeNm_tEdit.Text = name;
                                    this._prevCustomerCode = inputValue;
                                }
                                else
                                {
                                    // エラー時
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "得意先が存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                    // コード戻す
                                    // UPD 2010/09/28 --- >>>
                                    if (this._prevCustomerCode == -1)
                                    {
                                        this.tNedit_CustomerCode.SetInt(0);
                                    }
                                    else
                                    {
                                        this.tNedit_CustomerCode.SetInt(this._prevCustomerCode);
                                    }
                                    // UPD 2010/09/28 --- <<<
                                    this.tNedit_CustomerCode.SelectAll();
                                    e.NextCtrl = e.PrevCtrl;
                                    return;
                                }
                            }
                        }
                        # endregion [得意先]

                        #region [フォーカス制御]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    // ---DEL 2010/09/09---------------------->>>
                                    //{
                                    //    if (this.tNedit_CustomerCode.GetInt() == 0)
                                    //    {
                                    //        e.NextCtrl = this.CustomerGuide_Button;
                                    //    }
                                    //    else
                                    //    {
                                    //        e.NextCtrl = null;
                                    //        bool status = SetFocus(3);
                                    //        if (status == false)
                                    //        {
                                    //            if (this.Detail_uGrid.Rows.Count > 0)
                                    //            {
                                    //                // グリッドタブ移動制御
                                    //                this.Detail_uGrid.Focus();
                                    //                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                    //                this.InitGridFocus(0, 0);
                                    //            }
                                    //        }
                                    //    }
                                    //}
                                    //break;
                                    // ---DEL 2010/09/09----------------------<<<
                                case Keys.Return:
                                    {
                                        if (this.tNedit_CustomerCode.GetInt() == 0)
                                        {
                                            e.NextCtrl = this.CustomerGuide_Button;
                                        }
                                        else
                                        {
                                            e.NextCtrl = null;
                                            bool status = SetFocus(3);
                                            if (status == false)
                                            {
                                                //SearchRateData();
                                                this.Search(); // ADD 2010/09/10
                                                e.NextCtrl = null;
                                                // ---ADD 2010/09/25---------------------->>>
                                                // 検索処理がキャンセルされた場合
                                                if (this._searchStatus == 2)
                                                {
                                                    // なし
                                                }
                                                else
                                                // ---ADD 2010/09/25----------------------<<<
                                                // ---ADD 2010/09/09---------------------->>>
                                                if (this.Detail_uGrid.Rows.Count != 0 && this._checkInputScreenErr == false && this._errorFlg == false)
                                                {
                                                    if (this.Mode_Label.Text == INSERT_MODE)
                                                    {
                                                        if (!this._initFocusFlag)
                                                        {
                                                            this.Detail_uGrid.Focus();
                                                            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                            //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                            this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                            this.InitGridFocus(0, 0);
                                                        }
                                                        else
                                                        {
                                                            this._initFocusFlag = false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        this.Detail_uGrid.Focus();
                                                        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                        this.SetGridTabFocus(ref e);
                                                    }
                                                }
                                                this._searchStatus = 0; // ADD 2010/09/25
                                                this._errorFlg = false;
                                                this._checkInputScreenErr = false;
                                                // ---ADD 2010/09/09----------------------<<<
                                            }
                                        }
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        if (!this.tNedit_SupplierCd.Enabled)
                                        {
                                            e.NextCtrl = null;
                                            if (this.Detail_uGrid.Rows.Count > 0)
                                            {
                                                // グリッドタブ移動制御
                                                // ---UPD 2010/09/25---------------------->>>
                                                ////this.Detail_uGrid.Focus(); // DEL 2010/09/09
                                                ////this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0]; // DEL 2010/09/09
                                                ////this.InitGridFocus(0, 0); // DEL 2010/09/09
                                                //// ---ADD 2010/09/09---------------------->>>
                                                //if (this.Mode_Label.Text == INSERT_MODE)
                                                //{
                                                //    if (!this._initFocusFlag)
                                                //    {
                                                //        this.Detail_uGrid.Focus();
                                                //        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                //        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                //        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                //        this.InitGridFocus(0, 0);
                                                //    }
                                                //    else
                                                //    {
                                                //        this._initFocusFlag = false;
                                                //    }
                                                //}
                                                //else
                                                //{
                                                //    this.Detail_uGrid.Focus();
                                                //    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                //    //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                //    this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                //    this.SetGridTabFocus(ref e);
                                                //}
                                                //// ---ADD 2010/09/09----------------------<<<
                                                this.Detail_uGrid.Focus();
                                                this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                                                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                // ---UPD 2010/09/25----------------------<<<
                                            }
                                            else
                                            {
                                                e.NextCtrl = e.PrevCtrl;
                                            }
                                        }
                                    }
                                    break;
                                // ---ADD 2010/09/25---------------------->>>
                                case Keys.Left:
                                    e.NextCtrl = null;
                                    break;
                                // ---ADD 2010/09/25----------------------<<<
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = null;
                                    }
                                    break;
                            }
                        }
                        #endregion [フォーカス制御]
                        break;
                    }
                //-----------------------------------------------------
                // 得意先掛率ｸﾞﾙｰﾌﾟ
                //-----------------------------------------------------
                case "tNedit_CustRateGrpCodeZero":
                    {
                        # region [得意先掛率ｸﾞﾙｰﾌﾟ]
                        int inputValue = this.tNedit_CustRateGrpCodeZero.GetInt();

                        // 入力無し
                        if (this.tNedit_CustRateGrpCodeZero.DataText.Trim() == "")
                        {
                            this.tEdit_CustRateGrpNm.Clear();
                            this.tNedit_CustRateGrpCodeZero.Clear();
                            this._prevCustRateGrpCode = -1;
                            //this.CustRateGrpGuide_Button.Focus(); // ADD 2010/09/10 // DEL 2010/09/25
                            //this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false; // ADD 2010/09/10 // DEL 2010/09/25
                            // ---ADD 2010/09/25----------------------<<<
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Up:
                                        {
                                            if (!this.tNedit_CustomerCode.Enabled)
                                            {
                                                e.NextCtrl = null;
                                            }
                                            else
                                            {
                                                this.tNedit_CustomerCode.Focus();
                                            }
                                            break;
                                        }
                                    case Keys.Down:
                                        {
                                            if (!this.tNedit_SupplierCd.Enabled)
                                            {
                                                e.NextCtrl = null;
                                                if (this.Detail_uGrid.Rows.Count != 0)
                                                {
                                                    this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                                                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                }
                                            }
                                            else
                                            {
                                                this.tNedit_SupplierCd.Focus();
                                            }
                                            break;
                                        }
                                    case Keys.Right:
                                        {
                                            this.CustRateGrpGuide_Button.Focus();
                                            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                                            break;
                                        }
                                    case Keys.Left:
                                        {
                                            e.NextCtrl = null;
                                            break;
                                        }
                                }
                            }
                            if (e.NextCtrl != null)
                            {
                                switch (e.NextCtrl.Name)
                                {
                                    case "tNedit_CustomerCode":
                                    case "tNedit_CustRateGrpCodeZero":
                                    case "tNedit_SupplierCd":
                                    case "tNedit_GoodsMakerCd":
                                    case "tNedit_BLGoodsCode":
                                    case "tNedit_GoodsMGroup":
                                    case "tNedit_BLGloupCode":
                                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                                        break;
                                    case "Detail_uGrid":
                                        {
                                            if ((this.Detail_uGrid.ActiveCell != null) && (this.Detail_uGrid.ActiveCell.Column.Key.Equals(masterCode)))
                                            {
                                                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                                            }
                                            break;
                                        }
                                    default:
                                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
                                        break;
                                }
                            }
                            // ---ADD 2010/09/25----------------------<<<
                            return;
                        }
                        else
                        {
                            // ---UPD 2010/09/25---------------------->>>
                            //this.tNedit_CustRateGrpCodeZero.DataText = inputValue.ToString("D4");
                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Left:
                                        {
                                            break;
                                        }
                                    default:
                                        {
                                            this.tNedit_CustRateGrpCodeZero.DataText = inputValue.ToString("D4");
                                            break;
                                        }
                                }
                            }
                            // ---UPD 2010/09/25----------------------<<<
                        }
                        // 前回値と一致しない場合
                        if (inputValue != this._prevCustRateGrpCode)
                        {
                            string name = string.Empty;
                            bool check = GetCustRateGrpName(inputValue, out name);
                            if (check)
                            {
                                this.tEdit_CustRateGrpNm.Text = name;
                                this._prevCustRateGrpCode = inputValue;
                                this.tNedit_CustRateGrpCodeZero.DataText = inputValue.ToString("D4");
                            }
                            else
                            {
                                // エラー時
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "得意先掛率ｸﾞﾙｰﾌﾟが存在しません。",
                                    -1,
                                    MessageBoxButtons.OK);

                                // コード戻す
                                if (this._prevCustRateGrpCode == -1)
                                {
                                    this.tNedit_CustRateGrpCodeZero.Clear();
                                }
                                else
                                {
                                    this.tNedit_CustRateGrpCodeZero.SetInt(this._prevCustRateGrpCode);
                                }
                                this.tNedit_CustRateGrpCodeZero.SelectAll();
                                e.NextCtrl = e.PrevCtrl;
                                return;
                            }

                        }
                        # endregion [得意先掛率ｸﾞﾙｰﾌﾟ]

                        #region [フォーカス制御]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                // -------ADD 2010/09/25--------->>>>>
                                case Keys.Left:
                                    {
                                        e.NextCtrl = null;
                                        break;
                                    }
                                // -------ADD 2010/09/25---------<<<<<
                                case Keys.Tab:
                                    // ---DEL 2010/09/09---------------------->>>
                                    //{
                                    //    if (this.tNedit_CustRateGrpCodeZero.DataText.Trim() == "")
                                    //    {
                                    //        e.NextCtrl = this.CustRateGrpGuide_Button;
                                    //    }
                                    //    else
                                    //    {
                                    //        e.NextCtrl = null;
                                    //        bool status = SetFocus(3);
                                    //        if (status == false)
                                    //        {
                                    //            if (this.Detail_uGrid.Rows.Count > 0)
                                    //            {
                                    //                // グリッドタブ移動制御
                                    //                this.Detail_uGrid.Focus();
                                    //                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                    //                this.InitGridFocus(0, 0);
                                    //            }
                                    //        }
                                    //    }
                                    //}
                                    //break;
                                    // ---DEL 2010/09/09----------------------<<<
                                case Keys.Return:
                                    {
                                        if (this.tNedit_CustRateGrpCodeZero.DataText.Trim() == "")
                                        {
                                            e.NextCtrl = this.CustRateGrpGuide_Button;
                                        }
                                        else
                                        {
                                            e.NextCtrl = null;
                                            bool status = SetFocus(3);
                                            if (status == false)
                                            {
                                                //SearchRateData();
                                                this.Search(); // ADD 2010/09/10
                                                e.NextCtrl = null;
                                                // ---ADD 2010/09/25---------------------->>>
                                                // 検索処理がキャンセルされた場合
                                                if (this._searchStatus == 2)
                                                {
                                                    // なし
                                                }
                                                else
                                                // ---ADD 2010/09/25----------------------<<<
                                                // ---ADD 2010/09/09---------------------->>>
                                                if (this.Detail_uGrid.Rows.Count != 0 && this._checkInputScreenErr == false && this._errorFlg == false)
                                                {
                                                    if (this.Mode_Label.Text == INSERT_MODE)
                                                    {
                                                        if (!this._initFocusFlag)
                                                        {
                                                            this.Detail_uGrid.Focus();
                                                            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                            //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                            this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                            this.InitGridFocus(0, 0);
                                                        }
                                                        else
                                                        {
                                                            this._initFocusFlag = false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        this.Detail_uGrid.Focus();
                                                        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                        this.SetGridTabFocus(ref e);
                                                    }
                                                }
                                                this._searchStatus = 0; // ADD 2010/009/25
                                                this._errorFlg = false;
                                                this._checkInputScreenErr = false;
                                                // ---ADD 2010/09/09----------------------<<<
                                            }
                                        }
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        if (!this.tNedit_SupplierCd.Enabled)
                                        {
                                            e.NextCtrl = null;
                                            if (this.Detail_uGrid.Rows.Count > 0)
                                            {
                                                // グリッドタブ移動制御
                                                // ---UPD 2010/09/25---------------------->>>
                                                ////this.Detail_uGrid.Focus(); // DEL 2010/09/09
                                                ////this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0]; // DEL 2010/09/09
                                                ////this.InitGridFocus(0, 0); // DEL 2010/09/09
                                                //// ---ADD 2010/09/09---------------------->>>
                                                //if (this.Mode_Label.Text == INSERT_MODE)
                                                //{
                                                //    if (!this._initFocusFlag)
                                                //    {
                                                //        this.Detail_uGrid.Focus();
                                                //        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[SelectedRow()];
                                                //        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                //        this.Detail_uGrid.Rows[SelectedRow()].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                //        this.InitGridFocus(0, 0);
                                                //    }
                                                //    else
                                                //    {
                                                //        this._initFocusFlag = false;
                                                //    }
                                                //}
                                                //else
                                                //{
                                                //    //this.Detail_uGrid.Focus();
                                                //    //this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                //    //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate();
                                                //    //this.SetGridTabFocus(ref e);
                                                //    this.Detail_uGrid.Focus();
                                                //    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[SelectedRow()];
                                                //        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                //    this.Detail_uGrid.Rows[SelectedRow()].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                //    //this.SetGridTabFocus(ref e);
                                                //    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                //}
                                                //// ---ADD 2010/09/09----------------------<<<
                                                this.Detail_uGrid.Focus();
                                                this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                                                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                // ---UPD 2010/09/25----------------------<<<
                                            }
                                            else
                                            {
                                                e.NextCtrl = e.PrevCtrl;
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        SetFocus(4);
                                        e.NextCtrl = null;
                                    }
                                    break;
                            }
                        }
                        #endregion [フォーカス制御]
                        break;
                    }
                //-----------------------------------------------------
                // 仕入先コード
                //-----------------------------------------------------
                case "tNedit_SupplierCd":
                    {
                        # region [仕入先コード]
                        int inputValue = this.tNedit_SupplierCd.GetInt();

                        // 前回値と一致しない場合
                        if (_prevSupplierCode != inputValue)
                        {
                            // 入力無し
                            if (this.tNedit_SupplierCd.GetInt() == 0)
                            {
                                this.tNedit_SupplierCd.Clear();
                                this.SupplierCdNm_tEdit.Clear();
                                //this._prevSupplierCode = 0; // DEL 2010/09/25
                                this._prevSupplierCode = -1; // ADD 2010/09/25
                            }
                            else
                            {
                                string name = GetSupplierName(inputValue);
                                //if (CheckSupplier(inputValue)) // DEL 2010/09/09
                                if (!this._noValueFlg) // ADD 2010/09/09
                                {
                                    this.SupplierCdNm_tEdit.Text = name;
                                    this._prevSupplierCode = inputValue;
                                }
                                else
                                {
                                    // エラー時
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "仕入先が存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                    // コード戻す
                                    this.tNedit_SupplierCd.SetInt(this._prevSupplierCode);
                                    this.tNedit_SupplierCd.SelectAll();
                                    e.NextCtrl = e.PrevCtrl;
                                    this._noValueFlg = false;
                                    return;
                                }

                            }
                        }
                        # endregion [仕入先コード]

                        #region [フォーカス制御]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    // ---DEL 2010/09/09---------------------->>>
                                    //{
                                    //    if (this.tNedit_SupplierCd.GetInt() == 0)
                                    //    {
                                    //        e.NextCtrl = this.SupplierGuide_Button;
                                    //    }
                                    //    else
                                    //    {
                                    //        e.NextCtrl = null;
                                    //        bool status = SetFocus(3);
                                    //        if (status == false)
                                    //        {
                                    //            if (this.Detail_uGrid.Rows.Count > 0)
                                    //            {
                                    //                // グリッドタブ移動制御
                                    //                this.Detail_uGrid.Focus();
                                    //                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                    //                this.InitGridFocus(0, 0);
                                    //            }
                                    //        }
                                    //    }
                                    //}
                                    //break;
                                    // ---DEL 2010/09/09----------------------<<<
                                case Keys.Return:
                                    {
                                        if (this.tNedit_SupplierCd.GetInt() == 0)
                                        {
                                            e.NextCtrl = this.SupplierGuide_Button;
                                        }
                                        else
                                        {
                                            e.NextCtrl = null;
                                            bool status = SetFocus(3);
                                            if (status == false)
                                            {
                                                //SearchRateData();
                                                this.Search(); // ADD 2010/09/10
                                                e.NextCtrl = null;
                                                // ---ADD 2010/09/25---------------------->>>
                                                // 検索処理がキャンセルされた場合
                                                if (this._searchStatus == 2)
                                                {
                                                    // なし
                                                }
                                                else
                                                // ---ADD 2010/09/25----------------------<<<
                                                // ---ADD 2010/09/09---------------------->>>
                                                if (this.Detail_uGrid.Rows.Count != 0 && this._checkInputScreenErr == false && this._errorFlg == false)
                                                {
                                                    if (this.Mode_Label.Text == INSERT_MODE)
                                                    {
                                                        if (!this._initFocusFlag)
                                                        {
                                                            this.Detail_uGrid.Focus();
                                                            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                            //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                            this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                            this.InitGridFocus(0, 0);
                                                        }
                                                        else
                                                        {
                                                            this._initFocusFlag = false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        this.Detail_uGrid.Focus();
                                                        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                        this.SetGridTabFocus(ref e);
                                                    }
                                                }
                                                this._searchStatus = 0; // ADD 2010/09/25
                                                this._errorFlg = false;
                                                this._checkInputScreenErr = false;
                                                // ---ADD 2010/09/09----------------------<<<
                                            }
                                        }
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        e.NextCtrl = null;
                                        if (this.Detail_uGrid.Rows.Count > 0)
                                        {
                                            // グリッドタブ移動制御
                                            // ---UPD 2010/09/25---------------------->>>
                                            ////this.Detail_uGrid.Focus(); // DEL 2010/09/09
                                            ////this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0]; // DEL 2010/09/09
                                            ////this.InitGridFocus(0, 0); // DEL 2010/09/09
                                            //// ---ADD 2010/09/09---------------------->>>
                                            //if (this.Mode_Label.Text == INSERT_MODE)
                                            //{
                                            //    if (!this._initFocusFlag)
                                            //    {
                                            //        this.Detail_uGrid.Focus();
                                            //        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[SelectedRow()];
                                            //        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //        this.Detail_uGrid.Rows[SelectedRow()].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //        this.InitGridFocus(0, 0);
                                            //    }
                                            //    else
                                            //    {
                                            //        this._initFocusFlag = false;
                                            //    }
                                            //}
                                            //else
                                            //{
                                            //    this.Detail_uGrid.Focus();
                                            //    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[SelectedRow()];
                                            //    //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //    this.Detail_uGrid.Rows[SelectedRow()].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //    //this.SetGridTabFocus(ref e);
                                            //    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            //}
                                            //// ---ADD 2010/09/09----------------------<<<
                                            this.Detail_uGrid.Focus();
                                            this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            // ---UPD 2010/09/25----------------------<<<
                                        }
                                        else
                                        {
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        SetFocus(4);
                                        e.NextCtrl = null;
                                    }
                                    break;
                            }
                        }
                        #endregion [フォーカス制御]
                        break;
                    }
                //-----------------------------------------------------
                // メーカー
                //-----------------------------------------------------
                case "tNedit_GoodsMakerCd":
                    {
                        # region [メーカー]
                        int inputValue = this.tNedit_GoodsMakerCd.GetInt();

                        // 前回値と一致しない場合
                        if (_prevMakerCode != inputValue)
                        {
                            // 入力無し
                            if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                            {
                                this.tNedit_GoodsMakerCd.Clear();
                                this.MakerName_tEdit.Clear();
                                //this._prevMakerCode = 0; // DEL 2010/09/25
                                this._prevMakerCode = -1; // ADD 2010/09/25
                            }
                            else
                            {
                                string name = string.Empty;
                                bool check = GetMakerName(inputValue, out name);
                                if (check)
                                {
                                    this.MakerName_tEdit.Text = name;
                                    this._prevMakerCode = inputValue;
                                }
                                else
                                {
                                    // エラー時
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "メーカーマスタが未登録です。",
                                        -1,
                                        MessageBoxButtons.OK);

                                    // コード戻す
                                    this.tNedit_GoodsMakerCd.SetInt(this._prevMakerCode);
                                    this.tNedit_GoodsMakerCd.SelectAll();
                                    e.NextCtrl = e.PrevCtrl;
                                    return;
                                }
                            }

                        }
                        # endregion [メーカー]

                        #region [フォーカス制御]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    // ---DEL 2010/09/09---------------------->>>
                                    //{
                                    //    if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                                    //    {
                                    //        e.NextCtrl = this.MakerGuide_Button;
                                    //    }
                                    //    else
                                    //    {
                                    //        e.NextCtrl = null;
                                    //        bool status = SetFocus(3);
                                    //        if (status == false)
                                    //        {
                                    //            if (this.Detail_uGrid.Rows.Count > 0)
                                    //            {
                                    //                // グリッドタブ移動制御
                                    //                this.Detail_uGrid.Focus();
                                    //                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                    //                this.InitGridFocus(0, 0);
                                    //            }
                                    //        }
                                    //    }
                                    //}
                                    //break;
                                    // ---DEL 2010/09/09----------------------<<<
                                case Keys.Return:
                                    {
                                        if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                                        {
                                            e.NextCtrl = this.MakerGuide_Button;
                                        }
                                        else
                                        {
                                            e.NextCtrl = null;
                                            bool status = SetFocus(3);
                                            if (status == false)
                                            {
                                                //SearchRateData();
                                                this.Search(); // ADD 2010/09/10
                                                e.NextCtrl = null;
                                                // ---ADD 2010/09/25---------------------->>>
                                                // 検索処理がキャンセルされた場合
                                                if (this._searchStatus == 2)
                                                {
                                                    // なし
                                                }
                                                else
                                                // ---ADD 2010/09/25----------------------<<<
                                                // ---ADD 2010/09/09---------------------->>>
                                                if (this.Detail_uGrid.Rows.Count != 0 && this._checkInputScreenErr == false && this._errorFlg == false)
                                                {
                                                    if (this.Mode_Label.Text == INSERT_MODE)
                                                    {
                                                        if (!this._initFocusFlag)
                                                        {
                                                            this.Detail_uGrid.Focus();
                                                            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                            //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                            this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                            this.InitGridFocus(0, 0);
                                                        }
                                                        else
                                                        {
                                                            this._initFocusFlag = false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        this.Detail_uGrid.Focus();
                                                        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                        this.SetGridTabFocus(ref e);
                                                    }
                                                }
                                                this._searchStatus = 0; // ADD 2010/09/25
                                                this._errorFlg = false;
                                                this._checkInputScreenErr = false;
                                                // ---ADD 2010/09/09----------------------<<<
                                            }
                                        }
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        e.NextCtrl = null;
                                        if (this.Detail_uGrid.Rows.Count > 0)
                                        {
                                            // グリッドタブ移動制御
                                            // ---UPD 2010/09/25---------------------->>>
                                            ////this.Detail_uGrid.Focus(); // DEL 2010/09/09
                                            ////this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0]; // DEL 2010/09/09
                                            ////this.InitGridFocus(0, 0); // DEL 2010/09/09
                                            //// ---ADD 2010/09/09---------------------->>>
                                            //if (this.Mode_Label.Text == INSERT_MODE)
                                            //{
                                            //    if (!this._initFocusFlag)
                                            //    {
                                            //        this.Detail_uGrid.Focus();
                                            //        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //        this.InitGridFocus(0, 0);
                                            //    }
                                            //    else
                                            //    {
                                            //        this._initFocusFlag = false;
                                            //    }
                                            //}
                                            //else
                                            //{
                                            //    this.Detail_uGrid.Focus();
                                            //    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //    //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //    this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //    this.SetGridTabFocus(ref e);
                                            //}
                                            //// ---ADD 2010/09/09----------------------<<<
                                            this.Detail_uGrid.Focus();
                                            this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            // ---UPD 2010/09/25----------------------<<<
                                        }
                                        else
                                        {
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        SetFocus(4);
                                        e.NextCtrl = null;
                                    }
                                    break;
                            }
                        }
                        #endregion [フォーカス制御]
                        break;
                    }
                //-----------------------------------------------------
                // BLコード
                //-----------------------------------------------------
                case "tNedit_BLGoodsCode":
                    {
                        # region [BLコード]
                        int inputValue = this.tNedit_BLGoodsCode.GetInt();

                        // 前回値と一致しない場合
                        if (_prevBLGoodsCode != inputValue)
                        {
                            // 入力無し
                            if (this.tNedit_BLGoodsCode.GetInt() == 0)
                            {
                                this.tNedit_BLGoodsCode.Clear();
                                this.BLGoodsName_tEdit.Clear();
                                //this._prevBLGoodsCode = 0; // DEL 2010/09/25
                                this._prevBLGoodsCode = -1; // ADD 2010/09/25
                            }
                            else
                            {
                                string name = GetBLGoodsName(inputValue);
                                if (!string.IsNullOrEmpty(name))
                                {
                                    this.BLGoodsName_tEdit.Text = name;
                                    this._prevBLGoodsCode = inputValue;
                                }
                                else
                                {
                                    // エラー時
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "BLコードマスタが未登録です。",
                                        -1,
                                        MessageBoxButtons.OK);

                                    // コード戻す
                                    this.tNedit_BLGoodsCode.SetInt(this._prevBLGoodsCode);
                                    this.tNedit_BLGoodsCode.SelectAll();
                                    e.NextCtrl = e.PrevCtrl;
                                    return;
                                }
                            }

                        }
                        # endregion [BLコード]

                        #region [TODOフォーカス制御]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    // ---DEL 2010/09/09---------------------->>>
                                    //{
                                    //    if (this.tNedit_BLGoodsCode.GetInt() == 0)
                                    //    {
                                    //        e.NextCtrl = this.BLGoodsGuide_Button;
                                    //    }
                                    //    else
                                    //    {
                                    //        e.NextCtrl = null;
                                    //        bool status = SetFocus(3);
                                    //        if (status == false)
                                    //        {
                                    //            if (this.Detail_uGrid.Rows.Count > 0)
                                    //            {
                                    //                // グリッドタブ移動制御
                                    //                this.Detail_uGrid.Focus();
                                    //                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                    //                this.InitGridFocus(0, 0);
                                    //            }
                                    //        }
                                    //    }
                                    //}
                                    //break;
                                    // ---DEL 2010/09/09----------------------<<<
                                case Keys.Return:
                                    {
                                        if (this.tNedit_BLGoodsCode.GetInt() == 0)
                                        {
                                            e.NextCtrl = this.BLGoodsGuide_Button;
                                        }
                                        else
                                        {
                                            e.NextCtrl = null;
                                            bool status = SetFocus(3);
                                            if (status == false)
                                            {
                                                //SearchRateData();
                                                this.Search(); // ADD 2010/09/10
                                                e.NextCtrl = null;
                                                // ---ADD 2010/09/25---------------------->>>
                                                // 検索処理がキャンセルされた場合
                                                if (this._searchStatus == 2)
                                                {
                                                    // なし
                                                }
                                                else
                                                // ---ADD 2010/09/25----------------------<<<
                                                // ---ADD 2010/09/09---------------------->>>
                                                if (this.Detail_uGrid.Rows.Count != 0 && this._checkInputScreenErr == false && this._errorFlg ==false)
                                                {
                                                    if (this.Mode_Label.Text == INSERT_MODE)
                                                    {
                                                        if (!this._initFocusFlag)
                                                        {
                                                            this.Detail_uGrid.Focus();
                                                            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                            //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                            this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                            this.InitGridFocus(0, 0);
                                                        }
                                                        else
                                                        {
                                                            this._initFocusFlag = false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        this.Detail_uGrid.Focus();
                                                        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                        this.SetGridTabFocus(ref e);
                                                    }
                                                }
                                                this._searchStatus = 0; // ADD 2010/09/25
                                                this._errorFlg = false;
                                                this._checkInputScreenErr = false;
                                                // ---ADD 2010/09/09----------------------<<<
                                            }
                                        }
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        e.NextCtrl = null;
                                        if (this.Detail_uGrid.Rows.Count > 0)
                                        {
                                            // グリッドタブ移動制御
                                            // ---UPD 2010/09/25---------------------->>>
                                            ////this.Detail_uGrid.Focus(); // DEL 2010/09/09
                                            ////this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0]; // DEL 2010/09/09
                                            ////this.InitGridFocus(0, 0); // DEL 2010/09/09
                                            //// ---ADD 2010/09/09---------------------->>>
                                            //if (this.Mode_Label.Text == INSERT_MODE)
                                            //{
                                            //    if (!this._initFocusFlag)
                                            //    {
                                            //        this.Detail_uGrid.Focus();
                                            //        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //        this.InitGridFocus(0, 0);
                                            //    }
                                            //    else
                                            //    {
                                            //        this._initFocusFlag = false;
                                            //    }
                                            //}
                                            //else
                                            //{
                                            //    this.Detail_uGrid.Focus();
                                            //    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //    //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //    this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //    this.SetGridTabFocus(ref e);
                                            //}
                                            //// ---ADD 2010/09/09----------------------<<<
                                            this.Detail_uGrid.Focus();
                                            this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            // ---UPD 2010/09/25----------------------<<<
                                        }
                                        else
                                        {
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        SetFocus(4);
                                        e.NextCtrl = null;
                                    }
                                    break;
                            }
                        }
                        #endregion [フォーカス制御]
                        break;
                    }
                //-----------------------------------------------------
                // 商品掛率Ｇ
                //-----------------------------------------------------
                case "tNedit_GoodsMGroup":
                    {
                        # region [商品掛率Ｇ]
                        int inputValue = this.tNedit_GoodsMGroup.GetInt();

                        // 前回値と一致しない場合
                        if (_prevGoodsRateGrpCode != inputValue)
                        {
                            // 入力無し
                            if (this.tNedit_GoodsMGroup.GetInt() == 0)
                            {
                                this.tNedit_GoodsMGroup.Clear();
                                this.GoodsRateGrpName_tEdit.Clear();
                                //this._prevGoodsRateGrpCode = 0; // DEL 2010/09/25
                                this._prevGoodsRateGrpCode = -1; // ADD 2010/09/25
                            }
                            else
                            {
                                string name = GetGoodsMGroupName(inputValue);
                                if (!string.IsNullOrEmpty(name))
                                {
                                    this.GoodsRateGrpName_tEdit.Text = name;
                                    this._prevGoodsRateGrpCode = inputValue;
                                }
                                else
                                {
                                    // エラー時
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "商品掛率Ｇマスタが未登録です。",
                                        -1,
                                        MessageBoxButtons.OK);

                                    // コード戻す
                                    this.tNedit_GoodsMGroup.SetInt(this._prevGoodsRateGrpCode);
                                    this.tNedit_GoodsMGroup.SelectAll();
                                    e.NextCtrl = e.PrevCtrl;
                                    return;
                                }
                            }

                        }
                        # endregion [商品掛率Ｇ]

                        #region [TODO:フォーカス制御]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    // ---DEL 2010/09/09---------------------->>>
                                    //{
                                    //    if (this.tNedit_GoodsMGroup.GetInt() == 0)
                                    //    {
                                    //        e.NextCtrl = this.GoodsRateGrpGuide_Button;
                                    //    }
                                    //    else
                                    //    {
                                    //        e.NextCtrl = null;
                                    //        bool status = SetFocus(3);
                                    //        if (status == false)
                                    //        {
                                    //            if (this.Detail_uGrid.Rows.Count > 0)
                                    //            {
                                    //                // グリッドタブ移動制御
                                    //                this.Detail_uGrid.Focus();
                                    //                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                    //                this.InitGridFocus(0, 0);
                                    //            }
                                    //        }
                                    //    }
                                    //}
                                    //break;
                                    // ---DEL 2010/09/09----------------------<<<
                                case Keys.Return:
                                    {
                                        if (this.tNedit_GoodsMGroup.GetInt() == 0)
                                        {
                                            e.NextCtrl = this.GoodsRateGrpGuide_Button;
                                        }
                                        else
                                        {
                                            e.NextCtrl = null;
                                            bool status = SetFocus(3);
                                            if (status == false)
                                            {
                                                //SearchRateData();
                                                this.Search(); // ADD 2010/09/10
                                                e.NextCtrl = null;
                                                // ---ADD 2010/09/25---------------------->>>
                                                // 検索処理がキャンセルされた場合
                                                if (this._searchStatus == 2)
                                                {
                                                    // なし
                                                }
                                                else
                                                // ---ADD 2010/09/25----------------------<<<
                                                // ---ADD 2010/09/09---------------------->>>
                                                if (this.Detail_uGrid.Rows.Count != 0 && this._checkInputScreenErr == false && this._errorFlg == false)
                                                {
                                                    if (this.Mode_Label.Text == INSERT_MODE)
                                                    {
                                                        if (!this._initFocusFlag)
                                                        {
                                                            this.Detail_uGrid.Focus();
                                                            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                            //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                            this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                            this.InitGridFocus(0, 0);
                                                        }
                                                        else
                                                        {
                                                            this._initFocusFlag = false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        this.Detail_uGrid.Focus();
                                                        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                        this.SetGridTabFocus(ref e);
                                                    }
                                                }
                                                this._searchStatus = 0; // ADD 2010/09/25
                                                this._errorFlg = false;
                                                this._checkInputScreenErr = false;
                                                // ---ADD 2010/09/09----------------------<<<
                                            }
                                        }
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        e.NextCtrl = null;
                                        if (this.Detail_uGrid.Rows.Count > 0)
                                        {
                                            // グリッドタブ移動制御
                                            // ---UPD 2010/09/25---------------------->>>
                                            ////this.Detail_uGrid.Focus(); // DEL 2010/09/09
                                            ////this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0]; // DEL 2010/09/09
                                            ////this.InitGridFocus(0, 0); // DEL 2010/09/09
                                            //// ---ADD 2010/09/09---------------------->>>
                                            //if (this.Mode_Label.Text == INSERT_MODE)
                                            //{
                                            //    if (!this._initFocusFlag)
                                            //    {
                                            //        this.Detail_uGrid.Focus();
                                            //        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //        this.InitGridFocus(0, 0);
                                            //    }
                                            //    else
                                            //    {
                                            //        this._initFocusFlag = false;
                                            //    }
                                            //}
                                            //else
                                            //{
                                            //    this.Detail_uGrid.Focus();
                                            //    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //    //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //    this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //    this.SetGridTabFocus(ref e);
                                            //}
                                            //// ---ADD 2010/09/09----------------------<<<
                                            this.Detail_uGrid.Focus();
                                            this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            // ---UPD 2010/09/25----------------------<<<
                                        }
                                        else
                                        {
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                    }
                                    break;

                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        SetFocus(4);
                                        e.NextCtrl = null;
                                    }
                                    break;
                            }
                        }
                        #endregion [フォーカス制御]
                        break;
                    }
                //-----------------------------------------------------
                // グループコード
                //-----------------------------------------------------
                case "tNedit_BLGloupCode":
                    {
                        # region [グループコード]
                        int inputValue = this.tNedit_BLGloupCode.GetInt();

                        // 前回値と一致しない場合
                        if (_prevBLGroupCode != inputValue)
                        {
                            // 入力無し
                            if (this.tNedit_BLGloupCode.GetInt() == 0)
                            {
                                this.tNedit_BLGloupCode.Clear();
                                this.BLGroupName_tEdit.Clear();
                                //this._prevBLGroupCode = 0; // DEL 2010/09/25
                                this._prevBLGroupCode = -1; // ADD 2010/09/25
                            }
                            else
                            {
                                string name = GetBLGroupName(inputValue);
                                if (!string.IsNullOrEmpty(name))
                                {
                                    this.BLGroupName_tEdit.Text = name;
                                    this._prevBLGroupCode = inputValue;
                                }
                                else
                                {
                                    // エラー時
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "グループコードマスタが未登録です。",
                                        -1,
                                        MessageBoxButtons.OK);

                                    // コード戻す
                                    this.tNedit_BLGloupCode.SetInt(this._prevBLGroupCode);
                                    this.tNedit_BLGloupCode.SelectAll();
                                    e.NextCtrl = e.PrevCtrl;
                                    return;
                                }
                            }

                        }
                        # endregion [グループコード]

                        #region [TODO:フォーカス制御]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    // ---DEL 2010/09/09---------------------->>>
                                    //{
                                    //    if (this.tNedit_BLGloupCode.GetInt() == 0)
                                    //    {
                                    //        e.NextCtrl = this.BLGroupGuide_Button;
                                    //    }
                                    //    else
                                    //    {
                                    //        e.NextCtrl = null;
                                    //        bool status = SetFocus(3);
                                    //        if (status == false)
                                    //        {
                                    //            if (this.Detail_uGrid.Rows.Count > 0)
                                    //            {
                                    //                // グリッドタブ移動制御
                                    //                this.Detail_uGrid.Focus();
                                    //                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                    //                this.InitGridFocus(0, 0);
                                    //            }
                                    //        }
                                    //    }
                                    //}
                                    //break;
                                    // ---DEL 2010/09/09----------------------<<<
                                case Keys.Return:
                                    {
                                        if (this.tNedit_BLGloupCode.GetInt() == 0)
                                        {
                                            e.NextCtrl = this.BLGroupGuide_Button;
                                        }
                                        else
                                        {
                                            e.NextCtrl = null;
                                            bool status = SetFocus(3);
                                            if (status == false)
                                            {
                                                //SearchRateData();
                                                this.Search(); // ADD 2010/09/10
                                                e.NextCtrl = null;
                                                // ---ADD 2010/09/25---------------------->>>
                                                // 検索処理がキャンセルされた場合
                                                if (this._searchStatus == 2)
                                                {
                                                    // なし
                                                }
                                                else
                                                // ---ADD 2010/09/25----------------------<<<
                                                // ---ADD 2010/09/09---------------------->>>
                                                if (this.Detail_uGrid.Rows.Count != 0 && this._checkInputScreenErr == false && this._errorFlg == false)
                                                {
                                                    if (this.Mode_Label.Text == INSERT_MODE)
                                                    {
                                                        if (!this._initFocusFlag)
                                                        {
                                                            this.Detail_uGrid.Focus();
                                                            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                            //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                            this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                            this.InitGridFocus(0, 0);
                                                        }
                                                        else
                                                        {
                                                            this._initFocusFlag = false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        this.Detail_uGrid.Focus();
                                                        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                        this.SetGridTabFocus(ref e);
                                                    }
                                                }
                                                this._searchStatus = 0; // ADD 2010/09/25
                                                this._errorFlg = false;
                                                this._checkInputScreenErr = false;
                                                // ---ADD 2010/09/09----------------------<<<
                                            }
                                        }
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        e.NextCtrl = null;
                                        if (this.Detail_uGrid.Rows.Count > 0)
                                        {
                                            // グリッドタブ移動制御
                                            // ---UPD 2010/09/25---------------------->>>
                                            ////this.Detail_uGrid.Focus(); // DEL 2010/09/09
                                            ////this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0]; // DEL 2010/09/09
                                            ////this.InitGridFocus(0, 0); // DEL 2010/09/09
                                            //// ---ADD 2010/09/09---------------------->>>
                                            //if (this.Mode_Label.Text == INSERT_MODE)
                                            //{
                                            //    if (!this._initFocusFlag)
                                            //    {
                                            //        this.Detail_uGrid.Focus();
                                            //        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //        this.InitGridFocus(0, 0);
                                            //    }
                                            //    else
                                            //    {
                                            //        this._initFocusFlag = false;
                                            //    }
                                            //}
                                            //else
                                            //{
                                            //    this.Detail_uGrid.Focus();
                                            //    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //    //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //    this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //    this.SetGridTabFocus(ref e);
                                            //}
                                            //// ---ADD 2010/09/09----------------------<<<
                                            this.Detail_uGrid.Focus();
                                            this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            // ---UPD 2010/09/25----------------------<<<
                                        }
                                        else
                                        {
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                    }
                                    break;

                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                    {
                                        SetFocus(4);
                                        e.NextCtrl = null;
                                    }
                                    break;
                            }
                        }
                        #endregion [フォーカス制御]
                        break;
                    }
                //-----------------------------------------------------
                // 明細
                //-----------------------------------------------------
                case "Detail_uGrid":
                    {
                        // ---ADD 2010/09/09---------------------->>>
                        #region ■端数処理区分チェック
                        if ((this.Detail_uGrid.ActiveCell != null) && this.Detail_uGrid.ActiveCell.Column.Key.Equals("UnPrcFracProcDivNm"))
                        {
                            switch (this.Detail_uGrid.ActiveCell.Text)
                            {
                                case "1":
                                case "1:切捨て":
                                case "2":
                                case "2:四捨五入":
                                case "3":
                                case "3:切上げ":
                                    break;
                                default:
                                    this.Detail_uGrid.ActiveCell.Value = 2;
                                    break;
                            }
                        }
                        #endregion
                        //---ADD 2010/09/09----------------------<<<

                        # region [フォーカス制御]
                        if (this.Detail_uGrid.Rows.Count == 0)
                        {
                            //---ADD 2010/09/09---------------------->>>
                            #region ■ガイド有効無効の設定
                            if (e.NextCtrl == this.tNedit_CustomerCode || e.NextCtrl == this.tNedit_CustRateGrpCodeZero || e.NextCtrl == this.tNedit_SupplierCd
                                || e.NextCtrl == this.tNedit_BLGloupCode || e.NextCtrl == this.tNedit_BLGoodsCode || e.NextCtrl == this.tNedit_GoodsMakerCd || e.NextCtrl == this.tNedit_GoodsMGroup)
                            {
                                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                            }
                            #endregion
                            //---ADD 2010/09/09----------------------<<<
                            return;
                        }
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                // --- ADD 2010/09/10 ---------->>>>>
                                this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);
                                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                if (_errorFlg)
                                {
                                    e.NextCtrl = null;
                                    this._errorFlg = false;
                                    break;
                                }
                                // --- ADD 2010/09/10 ----------<<<<<
                                // グリッドタブ移動制御
                                SetGridTabFocus(ref e);
                            }
                        }
                        else
                        {
                            //if (e.Key == Keys.Tab) // DEL 2010/09/09
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter) // ADD 2010/09/09
                            {
                                // グリッドシフトタブ移動制御
                                SetGridShiftTabFocus(ref e);
                            }
                        }
                        // --- ADD 2010/09/09 ---------->>>
                        if (e.NextCtrl != null)
                        {
                            if (e.NextCtrl.CanSelect && !e.NextCtrl.Name.Equals("Delete_Button") && !e.NextCtrl.Name.Equals("DeleteAll_Button"))
                            {
                                this.Detail_uGrid.ActiveCell = null;
                                this.Detail_uGrid.ActiveRow = null;
                            }
                        }
                        // --- ADD 2010/09/09 ----------<<<
                        #endregion
                        break;
                    }
                case "BLGoodsGuide_Button":
                case "BLGroupGuide_Button":
                case "GoodsRateGrpGuide_Button":
                case "MakerGuide_Button":
                case "SupplierGuide_Button":
                    {
                        # region [フォーカス制御]
                        if (e.ShiftKey == false)
                        {
                            //if (e.Key == Keys.Enter) // DEL 2010/09/10
                            if (e.Key == Keys.Enter || e.Key == Keys.Tab) // ADD 2010/09/10
                            {
                                //SearchRateData();
                                this.Search(); // ADD 2010/09/10
                                e.NextCtrl = null;
                                // ---ADD 2010/09/25---------------------->>>
                                // 検索処理がキャンセルされた場合
                                if (this._searchStatus == 2)
                                {
                                    // なし
                                }
                                else
                                // ---ADD 2010/09/25----------------------<<<
                                // ---ADD 2010/09/09---------------------->>>
                                if (this.Detail_uGrid.Rows.Count != 0 && this._checkInputScreenErr == false && this._errorFlg == false)
                                {
                                    if (this.Mode_Label.Text == INSERT_MODE)
                                    {
                                        if (!this._initFocusFlag)
                                        {
                                            this.Detail_uGrid.Focus();
                                            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            this.InitGridFocus(0, 0);
                                        }
                                        else
                                        {
                                            this._initFocusFlag = false;
                                        }
                                    }
                                    else
                                    {
                                        this.Detail_uGrid.Focus();
                                        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                        this.SetGridTabFocus(ref e);
                                    }
                                }
                                this._searchStatus = 0; // ADD 2010/09/25
                                this._errorFlg = false;
                                this._checkInputScreenErr = false;
                                // ---ADD 2010/09/09----------------------<<<
                            }
                            // ---DEL 2010/09/09---------------------->>>
                            //if (e.Key == Keys.Tab)
                            //{
                            //    if (this.Detail_uGrid.Rows.Count > 0 )
                            //    {
                            //        // グリッドタブ移動制御
                            //        this.Detail_uGrid.Focus();
                            //        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                            //        this.InitGridFocus(0, 0);
                            //    }
                            //    else
                            //    {
                            //        e.NextCtrl = e.PrevCtrl;
                            //    }
                            //}
                            // ---DEL 2010/09/09----------------------<<<
                            if (e.Key == Keys.Down)
                            {
                                e.NextCtrl = null;
                                if (this.Detail_uGrid.Rows.Count > 0)
                                {
                                    // グリッドタブ移動制御
                                    // ---UPD 2010/09/25---------------------->>>
                                    ////this.Detail_uGrid.Focus(); // DEL 2010/09/09
                                    ////this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0]; // DEL 2010/09/09
                                    ////this.InitGridFocus(0, 0); // DEL 2010/09/09
                                    //// ---ADD 2010/09/09---------------------->>>
                                    //if (this.Mode_Label.Text == INSERT_MODE)
                                    //{
                                    //    if (!this._initFocusFlag)
                                    //    {
                                    //        this.Detail_uGrid.Focus();
                                    //        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                    //        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                    //        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                    //        this.InitGridFocus(0, 0);
                                    //    }
                                    //    else
                                    //    {
                                    //        this._initFocusFlag = false;
                                    //    }
                                    //}
                                    //else
                                    //{
                                    //    this.Detail_uGrid.Focus();
                                    //    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                    //    //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                    //    this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                    //    this.SetGridTabFocus(ref e);
                                    //}
                                    //// ---ADD 2010/09/09----------------------<<<
                                    this.Detail_uGrid.Focus();
                                    this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    // ---UPD 2010/09/25----------------------<<<
                                }
                                else
                                {
                                    e.NextCtrl = e.PrevCtrl;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                // フォーカス移動
                                SetFocus(0);
                            }
                        }
                        #endregion

                        break;
                    }
                case "CustomerGuide_Button":
                case "CustRateGrpGuide_Button":
                    {
                        # region [フォーカス制御]
                        if (!this.SupplierGuide_Button.Enabled)
                        {
                            if (e.ShiftKey == false)
                            {
                                //if (e.Key == Keys.Enter) // DEL 2010/09/10
                                if (e.Key == Keys.Enter || e.Key == Keys.Tab) // ADD 2010/09/10
                                {
                                    //SearchRateData();
                                    this.Search(); // ADD 2010/09/10
                                    e.NextCtrl = null;
                                    // ---ADD 2010/09/25---------------------->>>
                                    // 検索処理がキャンセルされた場合
                                    if (this._searchStatus == 2)
                                    {
                                        // なし
                                    }
                                    else
                                    // ---ADD 2010/09/25----------------------<<<
                                    // ---ADD 2010/09/09---------------------->>>
                                    if (this.Detail_uGrid.Rows.Count != 0 && this._checkInputScreenErr == false && this._errorFlg == false)
                                    {
                                        if (this.Mode_Label.Text == INSERT_MODE)
                                        {
                                            if (!this._initFocusFlag)
                                            {
                                                this.Detail_uGrid.Focus();
                                                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                                //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                                this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                                this.InitGridFocus(0, 0);
                                            }
                                            else
                                            {
                                                this._initFocusFlag = false;
                                            }
                                        }
                                        else
                                        {
                                            this.Detail_uGrid.Focus();
                                            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            this.SetGridTabFocus(ref e);
                                        }
                                    }
                                    this._searchStatus = 0; // ADD 2010/09/25
                                    this._errorFlg = false;
                                    this._checkInputScreenErr = false;
                                    // ---ADD 2010/09/09----------------------<<<
                                }

                                // ---DEL 2010/09/09---------------------->>>
                                //if (e.Key == Keys.Tab)
                                //{
                                //    if (this.Detail_uGrid.Rows.Count > 0 )
                                //    {
                                //        // グリッドタブ移動制御
                                //        this.Detail_uGrid.Focus();
                                //        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                //        this.InitGridFocus(0, 0);
                                //    }
                                //    else
                                //    {
                                //        e.NextCtrl = e.PrevCtrl;
                                //    }
                                //}
                                // ---DEL 2010/09/09----------------------<<<
                                if (e.Key == Keys.Down)
                                {
                                    e.NextCtrl = null;
                                    if (this.Detail_uGrid.Rows.Count > 0)
                                    {
                                        // グリッドタブ移動制御
                                        // ---UPD 2010/09/25---------------------->>>
                                        ////this.Detail_uGrid.Focus(); // DEL 2010/09/09
                                        ////this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0]; // DEL 2010/09/09
                                        ////this.InitGridFocus(0, 0); // DEL 2010/09/09
                                        //// ---ADD 2010/09/09---------------------->>>
                                        //if (this.Mode_Label.Text == INSERT_MODE)
                                        //{
                                        //    if (!this._initFocusFlag)
                                        //    {
                                        //        this.Detail_uGrid.Focus();
                                        //        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                        //        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                        //        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                        //        this.InitGridFocus(0, 0);
                                        //    }
                                        //    else
                                        //    {
                                        //        this._initFocusFlag = false;
                                        //    }
                                        //}
                                        //else
                                        //{
                                        //    this.Detail_uGrid.Focus();
                                        //    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                        //    //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                        //    this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                        //    this.SetGridTabFocus(ref e);
                                        //}
                                        //// ---ADD 2010/09/09----------------------<<<
                                        this.Detail_uGrid.Focus();
                                        this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                        // ---UPD 2010/09/25----------------------<<<
                                    }
                                    else
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    // フォーカス移動
                                    SetFocus(0);
                                }
                            }
                        }
                        #endregion
                        break;
                    }
                // ---ADD 2010/09/09---------------------->>>
                //-----------------------------------------------------
                // 全削除ボタン
                //-----------------------------------------------------
                case "DeleteAll_Button":
                    {
                        // ---UPD 2010/09/25---------------------->>>
                        //e.NextCtrl = this.Detail_uGrid;
                        //if (this.Mode_Label.Text == INSERT_MODE)
                        //{
                        //    this.InitGridFocus(0, 0);
                        //    this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);
                        //    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        //    this.Detail_uGrid.ActiveCell.SelectAll();
                        //}
                        //else
                        //{
                        //    ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                        //    this.SetGridTabFocus(ref evt);
                        //    this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);
                        //    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        //    this.Detail_uGrid.ActiveCell.SelectAll();
                        //}
                        e.NextCtrl = null;
                        if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                        {
                            this.Detail_uGrid.Focus();
                            this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        // ---UPD 2010/09/25----------------------<<<
                        break;
                    }
                // ---ADD 2010/09/09----------------------<<<
            }
            // ---ADD 2010/09/09---------------------->>>
            #region ■抽出条件+からのフォーカス制御
            if (e.Key == Keys.Enter || e.Key == Keys.Tab)
            {
                if (this.ultraExpandableGroupBox_Condition.Focused && this.ultraExpandableGroupBox_Condition.Expanded == false)
                {
                    // 抽出条件+から全削除ボタンへ
                    if (this.DeleteAll_Button.Enabled)
                    {
                        e.NextCtrl = this.DeleteAll_Button;
                        this.DeleteAll_Button.Focus();
                    }
                    // 抽出条件+からグリッドへ
                    else if (this.Detail_uGrid.Rows.Count != 0)
                    {
                        e.NextCtrl = this.Detail_uGrid;
                        if (this.Mode_Label.Text == INSERT_MODE)
                        {
                            this.InitGridFocus(0, 0);
                            this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            this.Detail_uGrid.ActiveCell.SelectAll();
                        }
                        else
                        {
                            ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                            this.SetGridTabFocus(ref evt);
                            this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            this.Detail_uGrid.ActiveCell.SelectAll();
                        }
                    }
                }
            }
            #endregion
            #region ■ガイド有効無効の設定
            if (this.Detail_uGrid.ActiveCell != null)
            {
                string columnKey = this.Detail_uGrid.ActiveCell.Column.Key;
                int columnIndex = 0;
                if (e.ShiftKey && e.Key == Keys.Tab)
                {
                    columnIndex = GetNextColumnIndexByTab(1, this.Detail_uGrid.Rows.Count - 1, columnKey);
                }
                //if (this.Detail_uGrid.ActiveCell.Column.Key.Equals("MasterNm")) // DEL 2010/09/25
                if (this.Detail_uGrid.ActiveCell.Column.Key.Equals(masterCode)) // ADD 2010/09/25
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                }
                else
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
                }
            }
            else
            {
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
            }

            if (e.NextCtrl != null)
            {
                switch (e.NextCtrl.Name)
                {
                    case "tNedit_CustomerCode":
                    case "tNedit_CustRateGrpCodeZero":
                    case "tNedit_SupplierCd":
                    case "tNedit_GoodsMakerCd":
                    case "tNedit_BLGoodsCode":
                    case "tNedit_GoodsMGroup":
                    case "tNedit_BLGloupCode":
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                        break;
                    case "Detail_uGrid":
                        {
                            //if ((this.Detail_uGrid.ActiveCell != null) && (this.Detail_uGrid.ActiveCell.Column.Key.Equals("MasterNm"))) // DEL 2010/09/25
                            if ((this.Detail_uGrid.ActiveCell != null) && (this.Detail_uGrid.ActiveCell.Column.Key.Equals(masterCode))) // ADD 2010/09/25
                            {
                                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                            }
                            break;
                        }
                    default:
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
                        break;
                }

                switch (e.PrevCtrl.Name)
                {
                    case "Detail_uGrid":
                        {
                            //if ((this.Detail_uGrid.ActiveCell != null) && (this.Detail_uGrid.ActiveCell.Column.Key.Equals("MasterNm")) && (e.NextCtrl.Name.Equals("_PMKHN09477UA_Toolbars_Dock_Area_Top"))) // DEL 2010/09/25
                            if ((this.Detail_uGrid.ActiveCell != null) && (this.Detail_uGrid.ActiveCell.Column.Key.Equals(masterCode)) && (e.NextCtrl.Name.Equals("_PMKHN09477UA_Toolbars_Dock_Area_Top"))) // ADD 2010/09/25
                            {
                                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                            }
                            //else if ((this.Detail_uGrid.ActiveCell != null) && (this.Detail_uGrid.ActiveCell.Column.Key.Equals("MasterNm")) && (e.NextCtrl.CanFocus == false || e.NextCtrl.CanSelect == false)) // DEL 2010/09/25
                            else if ((this.Detail_uGrid.ActiveCell != null) && (this.Detail_uGrid.ActiveCell.Column.Key.Equals(masterCode)) && (e.NextCtrl.CanFocus == false || e.NextCtrl.CanSelect == false)) // ADD 2010/09/25
                            {
                                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                            }
                            break;
                        }
                    case "tNedit_CustomerCode":
                    case "tNedit_CustRateGrpCodeZero":
                    case "tNedit_SupplierCd":
                    case "tNedit_GoodsMakerCd":
                    case "tNedit_BLGoodsCode":
                    case "tNedit_GoodsMGroup":
                    case "tNedit_BLGloupCode":
                        if (e.NextCtrl.Name.Equals("_PMKHN09473UA_Toolbars_Dock_Area_Top") || e.NextCtrl.CanFocus == false || e.NextCtrl.CanSelect == false)
                        {
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                        }
                        break;
                }
            }
            else
            {
                if (this.tNedit_CustomerCode.Focused || this.tNedit_CustRateGrpCodeZero.Focused || this.tNedit_SupplierCd.Focused
                    || this.tNedit_BLGloupCode.Focused || this.tNedit_BLGoodsCode.Focused || this.tNedit_GoodsMakerCd.Focused || this.tNedit_GoodsMGroup.Focused)
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                }
            }
            #endregion

            //#region ■行削除ボタン有効無効の設定
            //if (this.Detail_uGrid.ActiveCell != null)
            //{
            //    this.Delete_Button.Enabled = true;
            //}
            //else
            //{
            //    this.Delete_Button.Enabled = false;
            //}
            //#endregion

            //#region ■全削除ボタン有効無効の設定
            //if (this.AllDeleteEnabledCheck())
            //{
            //    this.DeleteAll_Button.Enabled = true;
            //}
            //else
            //{
            //    this.DeleteAll_Button.Enabled = false;
            //}
            //#endregion
            #region ■行削除/全削除ボタン有効無効の設定
            if (this.Detail_uGrid.Rows.Count != 0)
            {
                this.Delete_Button.Enabled = true;
                this.DeleteAll_Button.Enabled = true;
            }
            else
            {
                this.Delete_Button.Enabled = false;
                this.DeleteAll_Button.Enabled = false;
            }
            #endregion
            // ---ADD 2010/09/09----------------------<<<
        }

        /// <summary>
        /// グリッド初期レイアウト設定イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 画面初期化時、グリッド初期レイアウト設定を行います。</br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date        : 2010/08/12</br>
        /// <br>Update Note : 2010/08/31 呉元嘯</br>
        /// <br>            : Redmine#14030対応</br>
        /// <br>Update Note : 2010/09/25 朱 猛</br>
        /// <br>            : Redmine#14492対応</br>
        /// </remarks>
        private void Detail_uGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.Detail_uGrid.DisplayLayout.Bands[0];
            if (band == null) return;

            int visiblePosition = 0;
            this.Detail_uGrid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Default;
            this.Detail_uGrid.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in band.Columns)
            {
                //非表示設定
                column.Hidden = true;
            }

            // No.
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].Header.Caption = "No.";
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].Width = 35;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].Hidden = false;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.Detail_uGrid.DisplayLayout.Override.HeaderAppearance.ForeColor;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.Detail_uGrid.DisplayLayout.Override.HeaderAppearance.ForeColor;

            // 掛率設定区分=2L　得意先の場合：得意先の表示
            if ("2".Equals(this._rateProtyMng.RateMngCustCd.Trim()) && "L".Equals(this._rateProtyMng.RateMngGoodsCd.Trim()))
            {
                // 得意先
                this.masterCode = "CustomerCode";
                band.Columns[masterCode].Header.Caption = "得意先";
                band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Header.Caption = "得意先名"; // ADD 2010/09/25
            }
            // 掛率設定区分=4L　得意先掛率グループの場合：得意先掛率グループの表示
            else if ("4".Equals(this._rateProtyMng.RateMngCustCd.Trim()) && "L".Equals(this._rateProtyMng.RateMngGoodsCd.Trim()))
            {
                //得意先掛率グループ
                this.masterCode = "CustRateGrpCode";
                band.Columns[masterCode].Header.Caption = "得意先掛率G";
                band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Header.Caption = "得意先掛率G名"; // ADD 2010/09/25
            }
            // 掛率設定区分=5L　仕入先の場合：仕入先の表示
            else if ("5".Equals(this._rateProtyMng.RateMngCustCd.Trim()) && "L".Equals(this._rateProtyMng.RateMngGoodsCd.Trim()))
            {
                //仕入先
                this.masterCode = "SupplierCd";
                band.Columns[masterCode].Header.Caption = "仕入先";
                band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Header.Caption = "仕入先名"; // ADD 2010/09/25
            }
            // 掛率設定区分=6H　BLｺｰﾄﾞの場合：BLｺｰﾄﾞの表示
            else if ("6".Equals(this._rateProtyMng.RateMngCustCd.Trim()) && "H".Equals(this._rateProtyMng.RateMngGoodsCd.Trim()))
            {
                // BLコード
                this.masterCode = "BLGoodsCode";
                band.Columns[masterCode].Header.Caption = "BLコード";
                band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Header.Caption = "BLコード名"; // ADD 2010/09/25
            }
            // 掛率設定区分=6I　ｸﾞﾙｰﾌﾟｺｰﾄﾞの場合：ｸﾞﾙｰﾌﾟｺｰﾄﾞの表示
            else if ("6".Equals(this._rateProtyMng.RateMngCustCd.Trim()) && "I".Equals(this._rateProtyMng.RateMngGoodsCd.Trim()))
            {
                //グループコード
                this.masterCode = "BLGroupCode";
                band.Columns[masterCode].Header.Caption = "グループコード";
                band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Header.Caption = "グループコード名"; // ADD 2010/09/25
            }
            // 掛率設定区分=6J　中分類の場合：中分類の表示
            else if ("6".Equals(this._rateProtyMng.RateMngCustCd.Trim()) && "J".Equals(this._rateProtyMng.RateMngGoodsCd.Trim()))
            {
                //中分類
                this.masterCode = "GoodsRateGrpCode";
                band.Columns[masterCode].Header.Caption = "中分類";
                band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Header.Caption = "商品中分類名"; // ADD 2010/09/25
            }
            // 掛率設定区分=6K　メーカーの場合：メーカーの表示
            else if ("6".Equals(this._rateProtyMng.RateMngCustCd.Trim()) && "K".Equals(this._rateProtyMng.RateMngGoodsCd.Trim()))
            {
                //メーカー
                this.masterCode = "GoodsMakerCd";
                band.Columns[masterCode].Header.Caption = "メーカー";
                band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Header.Caption = "メーカー名"; // ADD 2010/09/25
            }
            // 掛率設定区分=1L　得意先＋仕入先の場合：仕入先の表示
            else if ("1".Equals(this._rateProtyMng.RateMngCustCd.Trim()) && "L".Equals(this._rateProtyMng.RateMngGoodsCd.Trim()))
            {
                //仕入先
                this.masterCode = "SupplierCd";
                band.Columns[masterCode].Header.Caption = "仕入先";
                band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Header.Caption = "仕入先名"; // ADD 2010/09/25
            }
            // 掛率設定区分=3L　得意先掛率グループ＋仕入先の場合：仕入先の表示
            else if ("3".Equals(this._rateProtyMng.RateMngCustCd.Trim()) && "L".Equals(this._rateProtyMng.RateMngGoodsCd.Trim()))
            {
                //仕入先
                this.masterCode = "SupplierCd";
                band.Columns[masterCode].Header.Caption = "仕入先";
                band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Header.Caption = "仕入先名"; // ADD 2010/09/25
            }
            // ----------ADD 2010/09/25----------->>>
            band.Columns[masterCode].Header.VisiblePosition = visiblePosition++;
            band.Columns[masterCode].Header.Fixed = true;
            band.Columns[masterCode].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[masterCode].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            band.Columns[masterCode].Width = 90;
            band.Columns[masterCode].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            band.Columns[masterCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[masterCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            band.Columns[masterCode].Hidden = false;
            band.Columns[masterCode].Format = FORMAT_CODE;
            // ----------ADD 2010/09/25-----------<<<

            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;  // DEL 2010/09/10
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; // ADD 2010/09/10
            //band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Width = 250;// DEL 2010/08/31
            //band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Width = 240;// ADD 2010/08/31
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Width = 200;// ADD 2010/09/25
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Hidden = false;          

            switch (this._rateProtyMng.UnitPriceKind)
            {
                // 売価の場合
                case 1:
                    {
                        // 売価率
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Header.Fixed = true;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Header.Caption = "売価率";
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Width = 80;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Hidden = false;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Format = FORMAT_FRACTION;

                        // 売価額
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.Fixed = true;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.Caption = "売価額";
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Width = 100;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Hidden = false;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Format = FORMAT_FRACTION;

                        // 原価UP率
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Header.Fixed = true;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Header.Caption = "原価UP率";
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Width = 80;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Hidden = false;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Format = FORMAT_FRACTION;

                        // 粗利確保率
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName].Header.Fixed = true;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName].Header.Caption = "粗利確保率";
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName].Width = 100;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName].Hidden = false;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName].Format = FORMAT_FRACTION;

                        break;
                    }
                // 原価の場合
                case 2:
                    {
                        // 仕入率
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Header.Fixed = true;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Header.Caption = "仕入率";
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Width = 80;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Hidden = false;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Format = FORMAT_FRACTION;

                        // 仕入原価
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.Fixed = true;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.Caption = "仕入原価";
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Width = 80;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Hidden = false;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Format = FORMAT_FRACTION;

                        break;
                    }
                // 価格の場合
                case 3:
                    {
                        // ユーザー価格
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.Fixed = true;
                        //band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.Caption = "ﾕｰｻﾞｰ価格";// DEL 2010/08/31
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.Caption = "ユーザー価格";// ADD 2010/08/31
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        //band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Width = 80;// DEL 2010/08/31
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Width = 90;// ADD 2010/08/31
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Hidden = false;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Format = FORMAT_FRACTION;

                        // 定価UP率
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Header.Fixed = true;
                        //band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Header.Caption = "定価UP率";// DEL 2010/08/31
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Header.Caption = "価格UP率";// ADD 2010/08/31
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Width = 80;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Hidden = false;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Format = FORMAT_FRACTION;

                        // 端数処理単位
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].Header.Fixed = true;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].Header.Caption = "端数処理単位";
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].Width = 100;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].Hidden = false;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].Format = FORMAT_FRACTION;

                        // 端数処理区分
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Header.Fixed = true;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Header.Caption = "端数処理区分";
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Width = 100;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Hidden = false;
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].MaxLength = 1;// ADD 2010/09/09
                        // コンボボックス設定
                        ValueList valueList = new ValueList();
                        valueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);
                        valueList.ValueListItems.Clear();
                        valueList.ValueListItems.Add("1", UNPRCFRACPROCDIV_1);
                        valueList.ValueListItems.Add("2", UNPRCFRACPROCDIV_2);
                        valueList.ValueListItems.Add("3", UNPRCFRACPROCDIV_3);
                        //band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;// DEL 2010/09/09
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;// ADD 2010/09/09
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].ValueList = valueList.Clone();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date        : 2010/08/12</br>
        /// <br>Update Note : 2010/09/30 朱 猛</br>
        /// <br>            : Redmine#15703対応</br>
        /// </remarks>
        private void Detail_uGrid_KeyDown(object sender, KeyEventArgs e)
        {
            int rowIndex;
            int columnIndex;

            if (this.Detail_uGrid.ActiveCell == null)
            {
                if (this.Detail_uGrid.ActiveRow == null)
                {
                    rowIndex = 0;
                }
                else
                {
                    rowIndex = this.Detail_uGrid.ActiveRow.Index;
                }
                //原価の場合
                if (this._rateProtyMng.UnitPriceKind == 2)
                {
                    columnIndex = 3;
                }
                else
                {
                    columnIndex = 2;
                }
            }
            else
            {
                rowIndex = this.Detail_uGrid.ActiveCell.Row.Index;
                columnIndex = this.Detail_uGrid.ActiveCell.Column.Index;
            }

            // ---ADD 2010/09/09---------------------->>>
            #region ■端数処理区分チェック
            if ((this.Detail_uGrid.ActiveCell != null) && this.Detail_uGrid.ActiveCell.Column.Key.Equals("UnPrcFracProcDivNm"))
            {
                switch (this.Detail_uGrid.ActiveCell.Text)
                {
                    case "1":
                    case "1:切捨て":
                    case "2":
                    case "2:四捨五入":
                    case "3":
                    case "3:切上げ":
                        break;
                    default:
                        this.Detail_uGrid.ActiveCell.Value = 2;
                        break;
                }
            }
            #endregion
            // ---ADD 2010/09/09----------------------<<<

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        if (this.Detail_uGrid.DisplayLayout.Bands[0].Columns[columnIndex].Style == Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList)
                        {
                            if (this.Detail_uGrid.ActiveCell.ValueListResolved.IsDroppedDown == true)
                            {
                                return;
                            }
                        }

                        if (rowIndex == 0)
                        {
                            e.Handled = true;
                            SetFocus(1);
                            // ---ADD 2010/09/25---------------------->>>
                            this.Detail_uGrid.ActiveCell = null;
                            this.Detail_uGrid.ActiveRow = null;
                            // ---ADD 2010/09/25----------------------<<<
                        }
                        else
                        {
                            e.Handled = true;
                            for (int index = rowIndex - 1; index >= 0; index--)
                            {
                                if (this.Detail_uGrid.Rows[index].Cells[columnIndex].Activation == Activation.AllowEdit)
                                {
                                    this.Detail_uGrid.Rows[index].Cells[columnIndex].Activate();
                                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                                // ---ADD 2010/09/25---------------------->>>
                                // 上矢印↑押下すると、上の明細の入力項目へ移動する。
                                if (this.Detail_uGrid.ActiveCell.Column.Key.Equals(this.masterCode))
                                {
                                    for (int rowNo = rowIndex - 1; rowNo >= 0; rowNo--)
                                    {
                                        //if ((int)this.Detail_uGrid.Rows[rowNo].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName].Value == 0)     // DEL 2010/09/30
                                        //{                                                                                                                                                     // DEL 2010/09/30
                                            int targetColumnIndex = GetNextColumnIndexByTab(0, rowIndex, this.masterCode);
                                            if (targetColumnIndex >= 0)
                                            {
                                                this.Detail_uGrid.Rows[rowNo].Cells[targetColumnIndex].Activate();
                                                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                return;
                                            }
                                        //}     // DEL 2010/09/30
                                    }

                                    SetFocus(1);
                                    this.Detail_uGrid.ActiveCell = null;
                                    this.Detail_uGrid.ActiveRow = null;
                                    return;
                                }
                                // ---ADD 2010/09/25----------------------<<<
                            }
                            SetFocus(1); // ADD 2010/09/09
                            // ---ADD 2010/09/25---------------------->>>
                            this.Detail_uGrid.ActiveCell = null;
                            this.Detail_uGrid.ActiveRow = null;
                            // ---ADD 2010/09/25----------------------<<<
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if (this.Detail_uGrid.DisplayLayout.Bands[0].Columns[columnIndex].Style == Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList)
                        {
                            if (this.Detail_uGrid.ActiveCell.ValueListResolved.IsDroppedDown == true)
                            {
                                return;
                            }
                        }

                        if (rowIndex == this.Detail_uGrid.Rows.Count - 1)
                        {
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = true;
                            for (int index = rowIndex + 1; index < this.Detail_uGrid.Rows.Count; index++)
                            {
                                if (this.Detail_uGrid.Rows[index].Cells[columnIndex].Activation == Activation.AllowEdit)
                                {
                                    this.Detail_uGrid.Rows[index].Cells[columnIndex].Activate();
                                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                            }
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        // UPD 2010/09/19 -- >>>>
                        //if (this.Detail_uGrid.ActiveCell == null)
                        //{
                        //    this.InitGridFocus(0, 0);
                        //    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        //    return;
                        //}

                        //if (this.Detail_uGrid.ActiveCell.IsInEditMode)
                        //{
                        //    if ((this.Detail_uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Default) ||
                        //        (this.Detail_uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit) ||
                        //        (this.Detail_uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Date))
                        //    {
                        //        if (this.Detail_uGrid.ActiveCell.SelStart == 0)
                        //        {
                        //            e.Handled = true;
                        //            this.Detail_uGrid.PerformAction(UltraGridAction.PrevCellByTab);
                        //        }
                        //    }
                        //    else
                        //    {
                        //        e.Handled = true;
                        //        this.Detail_uGrid.PerformAction(UltraGridAction.PrevCellByTab);
                        //    }
                        //}
                        //else
                        //{
                        //    e.Handled = true;
                        //    this.Detail_uGrid.PerformAction(UltraGridAction.PrevCellByTab);
                        //}

                        if (!MoveNextAllowEditCell(false, 0))
                        {
                            if (rowIndex == 0)
                            {
                                this.Detail_uGrid.Rows[0].Cells[columnIndex].Activate();
                                this.Detail_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                this.Detail_uGrid.ActiveCell.SelectAll();
                            }
                        }
                        // UPD 2010/09/19 -- <<<<
                        break;
                    }
                case Keys.Right:
                    {
                        if (this.Detail_uGrid.ActiveCell == null)
                        {
                            this.InitGridFocus(0, 0);
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }

                        // UPD 2010/09/19 -- >>>>
                        //if (Detail_uGrid.ActiveCell.IsInEditMode)
                        //{
                        //    if ((this.Detail_uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Default) ||
                        //        (this.Detail_uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit) ||
                        //        (this.Detail_uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Date))
                        //    {
                        //        if (this.Detail_uGrid.ActiveCell.SelStart >= Detail_uGrid.ActiveCell.Text.Length)
                        //        {
                        //            e.Handled = true;
                        //            this.Detail_uGrid.PerformAction(UltraGridAction.NextCellByTab);
                        //        }
                        //    }
                        //    else
                        //    {
                        //        e.Handled = true;
                        //        this.Detail_uGrid.PerformAction(UltraGridAction.NextCellByTab);
                        //    }
                        //}
                        //else
                        //{
                        //    e.Handled = true;
                        //    this.Detail_uGrid.PerformAction(UltraGridAction.NextCellByTab);
                        //}
                        if (!MoveNextAllowEditCell(false, 1))
                        {
                            if (rowIndex == 998)
                            {
                                this.Detail_uGrid.Rows[998].Cells[columnIndex].Activate();
                                this.Detail_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                this.Detail_uGrid.ActiveCell.SelectAll();
                            }
                        }
                        // UPD 2010/09/19 -- <<<<
                        break;
                    }
            }

        }

        /// <summary>
        /// KeyPress イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date        : 2010/08/12</br>
        /// <br>Update Note : 2010/09/25 朱 猛</br>
        /// <br>            : Redmine#14492対応</br>
        /// </remarks>
        private void Detail_uGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.Detail_uGrid.ActiveCell == null)
            {
                return;
            }

            UltraGridCell cell = this.Detail_uGrid.ActiveCell;

            // ActiveCellが売価額/仕入原価の場合
            if (cell.Column.Key == this._rateProtyMngPatternDataSet.RateProtyMngPattern.SalesUnitCostColumn.ColumnName ||
                cell.Column.Key == this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName ||
                cell.Column.Key == this._rateProtyMngPatternDataSet.RateProtyMngPattern.ListPriceColumn.ColumnName)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    // ZZ9.99
                    if (!KeyPressNumCheck(11, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            // 売価率/仕入率、原価UP率/定価UP率
            else if (cell.Column.Key == this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName ||
                     cell.Column.Key == this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    // ZZ9.99
                    if (!KeyPressNumCheck(6, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            // 端数処理単位
            else if (cell.Column.Key == this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    // ZZ9.99
                    if (!KeyPressNumCheck(10, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            // 粗利確保率
            else if (cell.Column.Key == this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    // ZZ9.99
                    if (!KeyPressNumCheck(5, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            // --- ADD 2010/09/10 ---------->>>>>
            //else if (cell.Column.Key == this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName) // DEL 2010/09/25
            else if (cell.Column.Key == this.masterCode) // ADD 2010/09/25
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    string rateSettingDivide = this._rateProtyMng.RateMngCustCd.Trim() + this._rateProtyMng.RateMngGoodsCd.Trim();
                    switch (rateSettingDivide)
                    {
                        case "2L": // 得意先の場合
                            {
                                if (!KeyPressNumCheck(8, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                                {
                                    e.Handled = true;
                                }
                                break;
                            }
                        case "4L": // 得意先掛率グループの場合
                            {
                                if (!KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                                {
                                    e.Handled = true;
                                }

                                break;
                            }
                        case "1L":
                        case "3L":
                        case "5L": // 仕入先の場合
                            {
                                if (!KeyPressNumCheck(6, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                                {
                                    e.Handled = true;
                                }

                                break;
                            }
                        case "6H": // BLｺｰﾄﾞの場合
                            {
                                if (!KeyPressNumCheck(5, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                                {
                                    e.Handled = true;
                                }
                                break;
                            }
                        case "6I": // ｸﾞﾙｰﾌﾟｺｰﾄﾞの場合
                            {
                                if (!KeyPressNumCheck(5, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                                {
                                    e.Handled = true;
                                }
                                break;
                            }
                        case "6J": // 中分類の場合
                            {
                                if (!KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                                {
                                    e.Handled = true;
                                }

                                break;
                            }
                        case "6K": // ﾒｰｶｰの場合
                            {
                                if (!KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                                {
                                    e.Handled = true;
                                }

                                break;
                            }
                    }
                }
            }
            // --- ADD 2010/09/10 ----------<<<<<
        }

        /// <summary>
        /// Leave イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
        private void Detail_uGrid_Leave(object sender, EventArgs e)
        {
            //this.Detail_uGrid.ActiveCell = null; // DEL 2010/09/09
            //this.Detail_uGrid.ActiveRow = null; // DEL 2010/09/09
        }

        /// <summary>
        /// AfterEnterEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : セルが編集モードになった時に発生します。</br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date        : 2010/08/12</br>
        /// <br>Update Note : 2010/09/25 朱 猛</br>
        /// <br>            : Redmine#14492対応</br>
        /// </remarks>
        private void Detail_uGrid_AfterEnterEditMode(object sender, EventArgs e)
        {
            // ---ADD 2010/09/09---------------------->>>
            if (this.Detail_uGrid.ActiveCell != null)
            {
                //if (this.Detail_uGrid.ActiveCell.Column.Key.Equals("MasterNm")) // DEL 2010/09/25
                if (this.Detail_uGrid.ActiveCell.Column.Key.Equals(masterCode)) // ADD 2010/09/25
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                }
                else
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
                }
            }
            else
            {
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
            }
            // ---ADD 2010/09/09----------------------<<<
        }

        /// <summary>
        /// AfterExitEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 編集モードが終了した時に発生します。</br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
        private void Detail_uGrid_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.Detail_uGrid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.Detail_uGrid.ActiveCell;

            if (cell == null) return;
            int rowIndex = cell.Row.Index;

            if (cell.Value is DBNull)
            {
                if ((cell.Column.DataType == typeof(Int32)) ||
                    (cell.Column.DataType == typeof(Int64)))
                {
                    cell.Value = 0;
                }
                else if (cell.Column.DataType == typeof(double))
                {
                    cell.Value = 0.0;
                }
                else if (cell.Column.DataType == typeof(string))
                {
                    cell.Value = "";
                }
            }
        }

        /// <summary>
        /// uGrid_Details_AfterCellUpdateイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : uGrid_Details_AfterCellUpdateを行います。</br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date        : 2010/08/12</br>
        /// <br>Update Note : 2010/09/25 朱 猛</br>
        /// <br>            : Redmine#14492対応</br>
        /// </remarks>
        private void Detail_uGrid_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (this._gridGuideFlag) return; // ADD 2010/09/25
            int rowIndex = e.Cell.Row.Index;
            int saveFlg = 0;
            DataRow originalDr = this._rateProtyMngPatternAcs.OriginalRateProtyMngDataTable
                .Select(this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName + " = '"
                + this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].Value.ToString() + "'")[0];

            for (int i = 0; i < this._rateProtyMngPatternDataSet.RateProtyMngPattern.Columns.Count; i++)
            {
                if (this.Detail_uGrid.Rows[rowIndex].Cells[i].Value.ToString() != originalDr[i].ToString())
                {
                    if (this.Detail_uGrid.Rows[rowIndex].Cells[i].Column.Key != this._rateProtyMngPatternDataSet.RateProtyMngPattern.SaveFlgColumn.ColumnName)
                    {
                        saveFlg = 1;
                    }
                }
            }
            this.Detail_uGrid.BeginUpdate();
            this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.SaveFlgColumn.ColumnName].Value = saveFlg;
            this.Detail_uGrid.EndUpdate();

            // --- ADD 2010/09/10 ---------->>>>>
            #region
            //if (e.Cell.Column.Key.Equals(this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName)) // DEL 2010/09/25
            if (e.Cell.Column.Key.Equals(this.masterCode)) // ADD 2010/09/25
            {
                string rateSettingDivide = this._rateProtyMng.RateMngCustCd.Trim() + this._rateProtyMng.RateMngGoodsCd.Trim();
                switch (rateSettingDivide)
                {
                    case "2L": // 掛率設定区分=2L　得意先の場合
                        {
                            if (e.Cell.Value != null && !string.IsNullOrEmpty(e.Cell.Value.ToString()))
                            {
                                int inputValue = Convert.ToInt32(e.Cell.Value);

                                // 入力無し
                                // --- UPD 2010/09/10 ---------->>>>>
                                //if (inputValue == 0)
                                //{
                                //    e.Cell.Value = 0;
                                //}
                                if (string.Empty.Equals(e.Cell.Value.ToString()))
                                {
                                    e.Cell.Value = string.Empty;
                                }
                                // --- UPD 2010/09/10 ----------<<<<<
                                else
                                {
                                    string name = string.Empty;
                                    bool check = GetCustomerName(inputValue, out name);
                                    if (check)
                                    {
                                        e.Cell.Activation = Activation.NoEdit;
                                        ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = name;
                                        //((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).CustomerCode = inputValue;
                                        ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).CustomerCode = inputValue.ToString("D8");
                                    }
                                    else
                                    {
                                        // --- ADD 2010/09/10 ---------->>>>>
                                        if (this._deleteButtonFlag)
                                        {
                                            this._errorFlg = true;
                                            return;
                                        }
                                        // --- ADD 2010/09/10 ----------<<<<<
                                        // エラー時
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "得意先が存在しません。",
                                            -1,
                                            MessageBoxButtons.OK);
                                        // --- ADD 2010/09/10 ---------->>>>>
                                        ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = string.Empty;
                                        this._errorFlg = true;
                                        //e.Cell.SelectAll(); // DEL 2010/09/25
                                        ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).CustomerCode = string.Empty; // ADD 2010/09/25
                                        // --- ADD 2010/09/10 ----------<<<<<
                                    }
                                }
                            }
                            break;
                        }
                    case "4L": // 掛率設定区分=4L　得意先掛率グループの場合
                        {
                            if (e.Cell.Value != null && !string.IsNullOrEmpty(e.Cell.Value.ToString()))
                            {
                                int inputValue = Convert.ToInt32(e.Cell.Value);

                                // 入力無し
                                if (string.Empty.Equals(e.Cell.Value.ToString()))
                                {
                                    e.Cell.Value = string.Empty;
                                }
                                else
                                {
                                    string name = string.Empty;
                                    bool check = GetCustRateGrpName(inputValue, out name);
                                    if (check)
                                    {
                                        e.Cell.Activation = Activation.NoEdit;
                                        ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = name;
                                        //((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).CustRateGrpCode = inputValue;
                                        ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).CustRateGrpCode = inputValue.ToString("D4");
                                    }
                                    else
                                    {
                                        // --- ADD 2010/09/10 ---------->>>>>
                                        if (this._deleteButtonFlag)
                                        {
                                            this._errorFlg = true;
                                            return;
                                        }
                                        // --- ADD 2010/09/10 ----------<<<<<
                                        // エラー時
                                        TMsgDisp.Show(
                                            this,
                                            emErrorLevel.ERR_LEVEL_INFO,
                                            this.Name,
                                            "得意先掛率ｸﾞﾙｰﾌﾟが存在しません。",
                                            -1,
                                            MessageBoxButtons.OK);
                                        // --- ADD 2010/09/10 ---------->>>>>
                                        ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = string.Empty;
                                        this._errorFlg = true;
                                        //e.Cell.SelectAll(); // DEL 2010/09/25
                                        ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).CustRateGrpCode = string.Empty; // ADD 2010/09/25
                                        // --- ADD 2010/09/10 ----------<<<<<
                                    }
                                }
                            }

                            break;
                        }
                    case "1L":
                    case "3L":
                    case "5L": // 掛率設定区分=5L　仕入先の場合
                        {
                            if (e.Cell.Value != null && !string.IsNullOrEmpty(e.Cell.Value.ToString()))
                            {
                                int inputValue = Convert.ToInt32(e.Cell.Value);

                                // 前回値と一致しない場合
                                if (_prevSupplierCode != inputValue)
                                {
                                    // 入力無し
                                    // --- UPD 2010/09/10 ---------->>>>>
                                    //if (inputValue == 0)
                                    //{
                                    //    e.Cell.Value = 0;
                                    //}
                                    if (string.Empty.Equals(e.Cell.Value.ToString()))
                                    {
                                        e.Cell.Value = string.Empty;
                                    }
                                    // --- UPD 2010/09/10 ----------<<<<<
                                    else
                                    {
                                        string name = GetSupplierName(inputValue);
                                        if (CheckSupplier(inputValue))
                                        {
                                            e.Cell.Activation = Activation.NoEdit;
                                            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = name;
                                            //((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).SupplierCd = inputValue;
                                            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).SupplierCd = inputValue.ToString("D6");
                                        }
                                        else
                                        {
                                            // --- ADD 2010/09/10 ---------->>>>>
                                            if (this._deleteButtonFlag)
                                            {
                                                this._errorFlg = true;
                                                return;
                                            }
                                            // --- ADD 2010/09/10 ----------<<<<<
                                            // エラー時
                                            TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                "仕入先が存在しません。",
                                                -1,
                                                MessageBoxButtons.OK);
                                            // --- ADD 2010/09/10 ---------->>>>>
                                            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = string.Empty;
                                            this._errorFlg = true;
                                            //e.Cell.SelectAll(); // DEL 2010/09/25
                                            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).SupplierCd = string.Empty; // ADD 2010/09/25
                                            // --- ADD 2010/09/10 ----------<<<<<
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    case "6H": // 掛率設定区分=6H　BLｺｰﾄﾞの場合
                        {
                            if (e.Cell.Value != null && !string.IsNullOrEmpty(e.Cell.Value.ToString()))
                            {
                                int inputValue = Convert.ToInt32(e.Cell.Value);

                                // 前回値と一致しない場合
                                if (_prevBLGoodsCode != inputValue)
                                {
                                    // 入力無し
                                    // --- UPD 2010/09/10 ---------->>>>>
                                    //if (inputValue == 0)
                                    //{
                                    //    e.Cell.Value = 0;
                                    //}
                                    if (string.Empty.Equals(e.Cell.Value.ToString()))
                                    {
                                        e.Cell.Value = string.Empty;
                                    }
                                    // --- UPD 2010/09/10 ----------<<<<<
                                    else
                                    {
                                        string name = GetBLGoodsName(inputValue);
                                        if (!string.IsNullOrEmpty(name))
                                        {
                                            e.Cell.Activation = Activation.NoEdit;
                                            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = name;
                                            //((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).BLGoodsCode = inputValue;
                                            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).BLGoodsCode = inputValue.ToString("D5");
                                        }
                                        else
                                        {
                                            // --- ADD 2010/09/10 ---------->>>>>
                                            if (this._deleteButtonFlag)
                                            {
                                                this._errorFlg = true;
                                                return;
                                            }
                                            // --- ADD 2010/09/10 ----------<<<<<
                                            // エラー時
                                            TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                "BLコードマスタが未登録です。",
                                                -1,
                                                MessageBoxButtons.OK);
                                            // --- ADD 2010/09/10 ---------->>>>>
                                            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = string.Empty;
                                            this._errorFlg = true;
                                            //e.Cell.SelectAll(); // DEL 2010/09/25
                                            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).BLGoodsCode = string.Empty; // ADD 2010/09/25
                                            // --- ADD 2010/09/10 ----------<<<<<
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    case "6I": // 掛率設定区分=6I　ｸﾞﾙｰﾌﾟｺｰﾄﾞの場合
                        {
                            if (e.Cell.Value != null && !string.IsNullOrEmpty(e.Cell.Value.ToString()))
                            {
                                int inputValue = Convert.ToInt32(e.Cell.Value);

                                // 前回値と一致しない場合
                                if (_prevBLGroupCode != inputValue)
                                {
                                    // 入力無し
                                    // --- UPD 2010/09/10 ---------->>>>>
                                    //if (inputValue == 0)
                                    //{
                                    //    e.Cell.Value = 0;
                                    //}
                                    if (string.Empty.Equals(e.Cell.Value.ToString()))
                                    {
                                        e.Cell.Value = string.Empty;
                                    }
                                    // --- UPD 2010/09/10 ----------<<<<<
                                    else
                                    {
                                        string name = GetBLGroupName(inputValue);
                                        if (!string.IsNullOrEmpty(name))
                                        {
                                            e.Cell.Activation = Activation.NoEdit;
                                            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = name;
                                            //((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).BLGroupCode = inputValue;
                                            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).BLGroupCode = inputValue.ToString("D5");
                                        }
                                        else
                                        {
                                            // --- ADD 2010/09/10 ---------->>>>>
                                            if (this._deleteButtonFlag)
                                            {
                                                this._errorFlg = true;
                                                return;
                                            }
                                            // --- ADD 2010/09/10 ----------<<<<<
                                            // エラー時
                                            TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                //"グループコードマスタが未登録です。",// DEL 2010/09/10
                                                "グループコードが存在しません。",// ADD 2010/09/10
                                                -1,
                                                MessageBoxButtons.OK);
                                            // --- ADD 2010/09/10 ---------->>>>>
                                            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = string.Empty;
                                            this._errorFlg = true;
                                            //e.Cell.SelectAll(); // DEL 2010/09/25
                                            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).BLGroupCode = string.Empty; // ADD 2010/09/25
                                            // --- ADD 2010/09/10 ----------<<<<<
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    case "6J": // 掛率設定区分=6J　中分類の場合
                        {
                            if (e.Cell.Value != null && !string.IsNullOrEmpty(e.Cell.Value.ToString()))
                            {
                                int inputValue = Convert.ToInt32(e.Cell.Value);

                                // 前回値と一致しない場合
                                if (_prevGoodsRateGrpCode != inputValue)
                                {
                                    // 入力無し
                                    // --- UPD 2010/09/10 ---------->>>>>
                                    //if (inputValue == 0)
                                    //{
                                    //    e.Cell.Value = 0;
                                    //}
                                    if (string.Empty.Equals(e.Cell.Value.ToString()))
                                    {
                                        e.Cell.Value = string.Empty;
                                    }
                                    // --- UPD 2010/09/10 ----------<<<<<
                                    else
                                    {
                                        string name = GetGoodsMGroupName(inputValue);
                                        if (!string.IsNullOrEmpty(name))
                                        {
                                            e.Cell.Activation = Activation.NoEdit;
                                            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = name;
                                           // ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).GoodsRateGrpCode = inputValue;
                                             ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).GoodsRateGrpCode = inputValue.ToString("D4");
                                        }
                                        else
                                        {
                                            // --- ADD 2010/09/10 ---------->>>>>
                                            if (this._deleteButtonFlag)
                                            {
                                                this._errorFlg = true;
                                                return;
                                            }
                                            // --- ADD 2010/09/10 ----------<<<<<
                                            // エラー時
                                            TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                //"商品掛率Ｇマスタが未登録です。",// DEL 2010/09/10
                                                "中分類が存在しません。", // ADD 2010/09/10
                                                -1,
                                                MessageBoxButtons.OK);
                                            // --- ADD 2010/09/10 ---------->>>>>
                                            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = string.Empty;
                                            this._errorFlg = true;
                                            //e.Cell.SelectAll(); // DEL 2010/09/25
                                            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).GoodsRateGrpCode = string.Empty; // ADD 2010/09/25
                                            // --- ADD 2010/09/10 ----------<<<<<
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    case "6K": // 掛率設定区分=6K　メーカーの場合
                        {
                            if (e.Cell.Value != null && !string.IsNullOrEmpty(e.Cell.Value.ToString()))
                            {
                                int inputValue = Convert.ToInt32(e.Cell.Value);

                                // 前回値と一致しない場合
                                if (_prevMakerCode != inputValue)
                                {
                                    // 入力無し
                                    // --- UPD 2010/09/10 ---------->>>>>
                                    //if (inputValue == 0)
                                    //{
                                    //    e.Cell.Value = 0;
                                    //}
                                    if (string.Empty.Equals(e.Cell.Value.ToString()))
                                    {
                                        e.Cell.Value = string.Empty;
                                    }
                                    // --- UPD 2010/09/10 ----------<<<<<
                                    else
                                    {
                                        string name = string.Empty;
                                        bool check = GetMakerName(inputValue, out name);
                                        if (check)
                                        {
                                            e.Cell.Activation = Activation.NoEdit;
                                            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = name;
                                            //((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).GoodsMakerCd = inputValue;
                                            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).GoodsMakerCd = inputValue.ToString("D4");
                                        }
                                        else
                                        {
                                            // --- ADD 2010/09/10 ---------->>>>>
                                            if (this._deleteButtonFlag)
                                            {
                                                this._errorFlg = true;
                                                return;
                                            }
                                            // --- ADD 2010/09/10 ----------<<<<<
                                            // エラー時
                                            TMsgDisp.Show(
                                                this,
                                                emErrorLevel.ERR_LEVEL_INFO,
                                                this.Name,
                                                "メーカーマスタが未登録です。",
                                                -1,
                                                MessageBoxButtons.OK);
                                            // --- ADD 2010/09/10 ---------->>>>>
                                            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = string.Empty;
                                            this._errorFlg = true;
                                            //e.Cell.SelectAll(); // DEL 2010/09/25
                                            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).GoodsMakerCd = string.Empty; // ADD 2010/09/25
                                            // --- ADD 2010/09/10 ----------<<<<<
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    }
            }
            #endregion
            // --- ADD 2010/09/10 ----------<<<<<
        }

        /// <summary>
        /// Button_Click イベント(CustomerGuide_Button)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 得意先ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: 楊明俊</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        private void CustomerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this._cusotmerGuideSelected = false;

                // 得意先ガイド
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                // フォーカス設定
                if (this._cusotmerGuideSelected == true)
                {
                    bool focusCheck = SetFocus(3);
                    if (focusCheck == false)
                    {
                        //SearchRateData();
                        this.Search(); // ADD 2010/09/10
                        // ---ADD 2010/09/09---------------------->>>
                        if (this.Detail_uGrid.Rows.Count != 0 && this._checkInputScreenErr == false && this._errorFlg == false)
                        {
                            //this.tArrowKeyControl1_ChangeFocus(this.CustomerGuide_Button, new ChangeFocusEventArgs(false, false, false, Keys.Down, this.CustomerGuide_Button, this.Detail_uGrid)); // DEL 2010/09/25
                            // ---ADD 2010/09/25---------------------->>>
                            // 検索処理をキャンセルする。
                            if (this._searchStatus == 2)
                            {
                                // なし
                            }
                            else
                            {
                                if (this.Mode_Label.Text == INSERT_MODE)
                                {
                                    if (!this._initFocusFlag)
                                    {
                                        this.Detail_uGrid.Focus();
                                        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                        this.Detail_uGrid.Rows[0].Cells[this.masterCode].Activate();
                                        this.InitGridFocus(0, 0);
                                    }
                                    else
                                    {
                                        this._initFocusFlag = false;
                                    }
                                }
                                else
                                {
                                    this.Detail_uGrid.Focus();
                                    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                    this.Detail_uGrid.Rows[0].Cells[this.masterCode].Activate();
                                    ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Space, this.Detail_uGrid, this.Detail_uGrid);
                                    this.SetGridTabFocus(ref evt);
                                }
                            }
                            this._searchStatus = 0;
                            // ---ADD 2010/09/25----------------------<<<
                        }
                        this._errorFlg = false;
                        this._checkInputScreenErr = false;
                        // ---ADD 2010/09/09----------------------<<<
                    }
                }
                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);// ADD 2010/09/10

                // --------ADD 2010/09/09-------->>>
                #region ■ガイド有効無効の設定
                if (this.tNedit_CustomerCode.Focused || this.tNedit_CustRateGrpCodeZero.Focused || this.tNedit_SupplierCd.Focused || this.tNedit_GoodsMakerCd.Focused
                    || this.tNedit_BLGoodsCode.Focused || this.tNedit_GoodsMGroup.Focused || this.tNedit_BLGloupCode.Focused)
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                }
                #endregion
                // --------ADD 2010/09/09--------<<<
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note        : 得意先選択時に発生します。</br>
        /// <br>Programmer	: 楊明俊</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }
            // ---ADD 2010/09/09---------------------->>>
            if (this._guideToolClick)
            {
                int rowIndex = this.Detail_uGrid.ActiveCell.Row.Index;
                string name;

                //((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).CustomerCode = customerSearchRet.CustomerCode;
                ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).CustomerCode = customerSearchRet.CustomerCode.ToString("D8");
                bool check = GetCustomerName(customerSearchRet.CustomerCode, out name);
                if (check)
                {
                    this.Detail_uGrid.ActiveCell.Activation = Activation.NoEdit;
                    ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = name;
                    ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                    SetGridTabFocus(ref evt);
                }
                return;
            }
            // ---ADD 2010/09/09----------------------<<<
            if (customerSearchRet.CustomerCode != this._prevCustomerCode)
            {
                this._prevCustomerCode = customerSearchRet.CustomerCode;

                // 得意先コード
                this.tNedit_CustomerCode.SetInt(customerSearchRet.CustomerCode);

                // 得意先名称
                this.CustomerCodeNm_tEdit.DataText = customerSearchRet.Snm.Trim();
            }

            this._cusotmerGuideSelected = true;
        }

        /// <summary>
        /// Button_Click イベント(SupplierGuide_Button)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 仕入先ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: 楊明俊</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        private void SupplierGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                Supplier supplier = new Supplier();

                // 仕入先ガイド表示
                status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, _loginSectionCode);
                if (status == 0)
                {
                    // ---ADD 2010/09/09---------------------->>>
                    if (this._guideToolClick)
                    {
                        int rowIndex = this.Detail_uGrid.ActiveCell.Row.Index;

                        //((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).SupplierCd = supplier.SupplierCd;
                        ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).SupplierCd = supplier.SupplierCd.ToString("D6");
                        ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = supplier.SupplierSnm.Trim();
                        this.Detail_uGrid.ActiveCell.Activation = Activation.NoEdit;
                        ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                        SetGridTabFocus(ref evt);
                        return;
                    }
                    // ---ADD 2010/09/09----------------------<<<

                    if (supplier.SupplierCd != this._prevSupplierCode)
                    {
                        this._prevSupplierCode = supplier.SupplierCd;

                        // 仕入先コード
                        this.tNedit_SupplierCd.SetInt(supplier.SupplierCd);

                        // 仕入先名称
                        this.SupplierCdNm_tEdit.DataText = supplier.SupplierSnm.Trim();
                    }

                    // フォーカス設定
                    bool focusCheck = SetFocus(3);
                    if (focusCheck == false)
                    {
                        //SearchRateData();
                        this.Search(); // ADD 2010/09/10
                        // ---ADD 2010/09/09---------------------->>>
                        if (this.Detail_uGrid.Rows.Count != 0 && this._checkInputScreenErr == false && this._errorFlg == false)
                        {
                            //this.tArrowKeyControl1_ChangeFocus(this.SupplierGuide_Button, new ChangeFocusEventArgs(false, false, false, Keys.Down, this.SupplierGuide_Button, this.Detail_uGrid)); // DEL 2010/09/25
                            // ---ADD 2010/09/25---------------------->>>
                            // 検索処理をキャンセルする。
                            if (this._searchStatus == 2)
                            {
                                // なし
                            }
                            else
                            {
                                if (this.Mode_Label.Text == INSERT_MODE)
                                {
                                    if (!this._initFocusFlag)
                                    {
                                        this.Detail_uGrid.Focus();
                                        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                        this.Detail_uGrid.Rows[0].Cells[this.masterCode].Activate();
                                        this.InitGridFocus(0, 0);
                                    }
                                    else
                                    {
                                        this._initFocusFlag = false;
                                    }
                                }
                                else
                                {
                                    this.Detail_uGrid.Focus();
                                    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                    this.Detail_uGrid.Rows[0].Cells[this.masterCode].Activate();
                                    ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Space, this.Detail_uGrid, this.Detail_uGrid);
                                    this.SetGridTabFocus(ref evt);
                                }
                            }
                            this._searchStatus = 0;
                            // ---ADD 2010/09/25----------------------<<<
                        }
                        this._errorFlg = false;
                        this._checkInputScreenErr = false;
                        // ---ADD 2010/09/09----------------------<<<
                    }
                }
                // --------ADD 2010/09/09-------->>>
                #region ■ガイド有効無効の設定
                if (this.tNedit_CustomerCode.Focused || this.tNedit_CustRateGrpCodeZero.Focused || this.tNedit_SupplierCd.Focused || this.tNedit_GoodsMakerCd.Focused
                    || this.tNedit_BLGoodsCode.Focused || this.tNedit_GoodsMGroup.Focused || this.tNedit_BLGloupCode.Focused)
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                }
                #endregion
                // --------ADD 2010/09/09--------<<<
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント(MakerGuide_Button)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: メーカーガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: 楊明俊</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        private void MakerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                MakerUMnt makerUMnt = new MakerUMnt();

                // メーカーガイド表示
                status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
                if (status == 0)
                {
                    // ---ADD 2010/09/09---------------------->>>
                    if (this._guideToolClick)
                    {
                        int rowIndex = this.Detail_uGrid.ActiveCell.Row.Index;

                        //((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).GoodsMakerCd = makerUMnt.GoodsMakerCd;
                        ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).GoodsMakerCd = makerUMnt.GoodsMakerCd.ToString("D4");
                        ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = makerUMnt.MakerName.Trim();
                        this.Detail_uGrid.ActiveCell.Activation = Activation.NoEdit;
                        ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                        SetGridTabFocus(ref evt);
                        return;
                    }
                    // ---ADD 2010/09/09----------------------<<<

                    if (makerUMnt.GoodsMakerCd != this._prevMakerCode)
                    {
                        this._prevMakerCode = makerUMnt.GoodsMakerCd;

                        // メーカーコード
                        this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);

                        // メーカー名称
                        this.MakerName_tEdit.DataText = makerUMnt.MakerName.Trim();
                    }

                    // フォーカス設定
                    bool focusCheck = SetFocus(3);
                    if (focusCheck == false)
                    {
                        //SearchRateData();
                        this.Search(); // ADD 2010/09/10
                        // ---ADD 2010/09/09---------------------->>>
                        if (this.Detail_uGrid.Rows.Count != 0 && this._checkInputScreenErr == false && this._errorFlg == false)
                        {
                            //this.tArrowKeyControl1_ChangeFocus(this.MakerGuide_Button, new ChangeFocusEventArgs(false, false, false, Keys.Down, this.MakerGuide_Button, this.Detail_uGrid)); // DEL 2010/09/25
                            // ---ADD 2010/09/25---------------------->>>
                            // 検索処理をキャンセルする。
                            if (this._searchStatus == 2)
                            {
                                // なし
                            }
                            else
                            {
                                if (this.Mode_Label.Text == INSERT_MODE)
                                {
                                    if (!this._initFocusFlag)
                                    {
                                        this.Detail_uGrid.Focus();
                                        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                        this.Detail_uGrid.Rows[0].Cells[this.masterCode].Activate();
                                        this.InitGridFocus(0, 0);
                                    }
                                    else
                                    {
                                        this._initFocusFlag = false;
                                    }
                                }
                                else
                                {
                                    this.Detail_uGrid.Focus();
                                    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                    this.Detail_uGrid.Rows[0].Cells[this.masterCode].Activate();
                                    ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Space, this.Detail_uGrid, this.Detail_uGrid);
                                    this.SetGridTabFocus(ref evt);
                                }
                            }
                            this._searchStatus = 0;
                            // ---ADD 2010/09/25----------------------<<<
                        }
                        this._errorFlg = false;
                        this._checkInputScreenErr = false;
                        // ---ADD 2010/09/09----------------------<<<
                    }
                }
                // --------ADD 2010/09/09-------->>>
                #region ■ガイド有効無効の設定
                if (this.tNedit_CustomerCode.Focused || this.tNedit_CustRateGrpCodeZero.Focused || this.tNedit_SupplierCd.Focused || this.tNedit_GoodsMakerCd.Focused
                    || this.tNedit_BLGoodsCode.Focused || this.tNedit_GoodsMGroup.Focused || this.tNedit_BLGloupCode.Focused)
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                }
                #endregion
                // --------ADD 2010/09/09--------<<<
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント(CustRateGrpGuide_Button)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 得意先掛率グループガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: 楊明俊</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        private void CustRateGrpGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int status;

                UserGdHd userGdHd;
                UserGdBd userGdBd;

                status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 43);
                if (status == 0)
                {
                    // ---ADD 2010/09/09---------------------->>>
                    if (this._guideToolClick)
                    {
                        int rowIndex = this.Detail_uGrid.ActiveCell.Row.Index;

                        //((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).CustRateGrpCode = userGdBd.GuideCode;
                        ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).CustRateGrpCode = userGdBd.GuideCode.ToString("D4");
                        ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = userGdBd.GuideName;
                        this.Detail_uGrid.ActiveCell.Activation = Activation.NoEdit;
                        ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                        SetGridTabFocus(ref evt);
                        return;
                    }
                    // ---ADD 2010/09/09----------------------<<<

                    this.tNedit_CustRateGrpCodeZero.DataText = userGdBd.GuideCode.ToString("D4");
                    this.tEdit_CustRateGrpNm.DataText = userGdBd.GuideName;
                    this._prevCustRateGrpCode = userGdBd.GuideCode;
                    // フォーカス設定
                    bool focusCheck = SetFocus(3);
                    if (focusCheck == false)
                    {
                        //SearchRateData();
                        this.Search(); // ADD 2010/09/10
                        // ---ADD 2010/09/09---------------------->>>
                        if (this.Detail_uGrid.Rows.Count != 0 && this._checkInputScreenErr == false && this._errorFlg == false)
                        {
                            //this.tArrowKeyControl1_ChangeFocus(this.CustRateGrpGuide_Button, new ChangeFocusEventArgs(false, false, false, Keys.Down, this.CustRateGrpGuide_Button, this.Detail_uGrid)); // DEL 2010/09/25
                            // ---ADD 2010/09/25---------------------->>>
                            // 検索処理をキャンセルする。
                            if (this._searchStatus == 2)
                            {
                                // なし
                            }
                            else
                            {
                                if (this.Mode_Label.Text == INSERT_MODE)
                                {
                                    if (!this._initFocusFlag)
                                    {
                                        this.Detail_uGrid.Focus();
                                        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                        this.Detail_uGrid.Rows[0].Cells[this.masterCode].Activate();
                                        this.InitGridFocus(0, 0);
                                    }
                                    else
                                    {
                                        this._initFocusFlag = false;
                                    }
                                }
                                else
                                {
                                    this.Detail_uGrid.Focus();
                                    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                    this.Detail_uGrid.Rows[0].Cells[this.masterCode].Activate();
                                    ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Space, this.Detail_uGrid, this.Detail_uGrid);
                                    this.SetGridTabFocus(ref evt);
                                }
                            }
                            this._searchStatus = 0;
                            // ---ADD 2010/09/25----------------------<<<
                        }
                        this._errorFlg = false;
                        this._checkInputScreenErr = false;
                        // ---ADD 2010/09/09----------------------<<<
                    }
                }
                // --------ADD 2010/09/09-------->>>
                #region ■ガイド有効無効の設定
                if (this.tNedit_CustomerCode.Focused || this.tNedit_CustRateGrpCodeZero.Focused || this.tNedit_SupplierCd.Focused || this.tNedit_GoodsMakerCd.Focused
                    || this.tNedit_BLGoodsCode.Focused || this.tNedit_GoodsMGroup.Focused || this.tNedit_BLGloupCode.Focused)
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                }
                #endregion
                // --------ADD 2010/09/09--------<<<
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント(CellDataError)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 得意先掛率グループガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: 楊明俊</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        private void Detail_uGrid_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            if (this.Detail_uGrid.ActiveCell != null)
            {
                if ((this.Detail_uGrid.ActiveCell.Column.DataType == typeof(Double)))
                {

                    Infragistics.Win.EmbeddableEditorBase editorBase = this.Detail_uGrid.ActiveCell.EditorResolved;

                    editorBase.Value = 0;
                    this.Detail_uGrid.ActiveCell.Value = 0;
                }

                e.RaiseErrorEvent = false;
            }

        }

        /// <summary>
        /// グリッドマウスクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : グリッドマウスクリックする時に発生します。</br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date		: 2010/08/12</br>
        /// <br>Update Note : 2010/09/25 朱 猛</br>
        /// <br>            : Redmine#14492対応</br>
        /// </remarks>
        private void Detail_uGrid_MouseClick(object sender, MouseEventArgs e)
        {
            // ---ADD 2010/09/09---------------------->>>
            #region ■ガイド有効無効の設定
            if (this.Detail_uGrid.ActiveCell != null)
            {
                //if (this.Detail_uGrid.ActiveCell.Column.Key.Equals("MasterNm") && (this.Detail_uGrid.ActiveCell.Activation == Activation.AllowEdit)) // DEL 2010/09/25
                if (this.Detail_uGrid.ActiveCell.Column.Key.Equals(masterCode) && (this.Detail_uGrid.ActiveCell.Activation == Activation.AllowEdit)) // ADD 2010/09/25
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                }
                else
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
                }
            }
            else
            {
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
            }
            #endregion
            // ---ADD 2010/09/09----------------------<<<

            #region ■端数処理区分チェック
            if (this._preUnPrcFracProcDivNmCell != null)
            {
                switch (this._preUnPrcFracProcDivNmCell.Text)
                {
                    case "1":
                    case "1:切捨て":
                    case "2":
                    case "2:四捨五入":
                    case "3":
                    case "3:切上げ":
                        break;
                    default:
                        this._preUnPrcFracProcDivNmCell.Value = 2;
                        break;
                }
            }
            #endregion
            // ---ADD 2010/09/09----------------------<<<

            // 右クリック以外の場合
            //if (e.Button != MouseButtons.Right) return; // DEL 2010/09/09

            if (this.Detail_uGrid.ActiveRow == null) return;

            this.Delete_Button.Enabled = true; // ADD 2010/09/10

            System.Drawing.Point nowPos = new Point(e.X, e.Y);

            Infragistics.Win.UIElement objElement = this.Detail_uGrid.DisplayLayout.UIElement.ElementFromPoint(nowPos);

            // ---ADD 2010/09/09---------------------->>>
            if (objElement.SelectableItem is Infragistics.Win.UltraWinGrid.UltraGridCell)
            {
                UltraGridCell nextCell = (UltraGridCell)objElement.SelectableItem;
                nextCell.Activate();
                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
            }
            if (e.Button != MouseButtons.Right) return;
            // ---ADD 2010/09/09----------------------<<<

            // クリック位置が列ヘッダーか判定
            bool isColumnHeader = false;

            if (objElement != null)
            {
                if ((objElement.SelectableItem is Infragistics.Win.UltraWinGrid.ColumnHeader) ||
                    (objElement is Infragistics.Win.UltraWinGrid.HeaderUIElement))
                {
                    isColumnHeader = true;
                }
            }

            if (isColumnHeader)
            {
                // 列ヘッダー右クリック時は何もしない
            }
            else
            {
                // それ以外で右クリックされた場合は、編集のポップアップを表示する
                ((Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.tToolbarsManager_MainMenu.Tools["PopupMenuTool_grid"]).ShowPopup(System.Windows.Forms.Cursor.Position, this.Detail_uGrid);

                if ((this.Detail_uGrid.ActiveCell == null) && (this.Detail_uGrid.ActiveRow != null))
                {
                    if (this.Detail_uGrid.ActiveRow.Selected)
                    {
                        //
                    }
                    else
                    {
                        this.Detail_uGrid.Selected.Rows.Clear();
                        this.Detail_uGrid.ActiveRow.Selected = true;
                    }
                }
            }
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/09/09</br>
        /// </remarks>
        private void ultraExpandableGroupBox_Condition_ExpandedStateChanging(object sender, CancelEventArgs e)
        {
            Size topSize = new Size();
            Size gridSize = new Size();

            topSize.Width = this.Head_panel_Top.Size.Width;
            gridSize.Width = this.Detail_uGrid.Size.Width;
            topSize.Height = 213;
            gridSize.Height = 380;

            if (this.ultraExpandableGroupBox_Condition.Expanded == false)
            {
                topSize.Height = 213;
                gridSize.Height = 380;
            }
            else
            {
                topSize.Height = 68;
                gridSize.Height = 525;
            }

            this.Head_panel_Top.Size = topSize;
            this.Detail_uGrid.Size = gridSize;
        }

        /// <summary>
        /// AfterCellActivateイベント
        /// </summary>
        /// <remarks>
        /// <br>Note        : セルがアクティブになった後に発生します。</br>
        /// <br>Programmer  : 朱 猛</br>
        /// <br>Date        : 2010/09/09</br>
        /// <br>Update Note : 2010/09/25 朱 猛</br>
        /// <br>            : Redmine#14492対応</br>
        /// </remarks>
        private void Detail_uGrid_AfterCellActivate(object sender, EventArgs e)
        {
            #region ■ガイド有効無効の設定
            if (this.Detail_uGrid.ActiveCell != null)
            {
                //if (this.Detail_uGrid.ActiveCell.Column.Key.Equals("MasterNm") && (this.Detail_uGrid.ActiveCell.Activation == Activation.AllowEdit)) // DEL 2010/09/25
                if (this.Detail_uGrid.ActiveCell.Column.Key.Equals(masterCode) && (this.Detail_uGrid.ActiveCell.Activation == Activation.AllowEdit)) // ADD 2010/09/25
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                }
                else
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
                }
            }
            else
            {
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = false;
            }
            #endregion

            if ((this.Detail_uGrid.ActiveCell != null) && this.Detail_uGrid.ActiveCell.Column.Key.Equals("UnPrcFracProcDivNm"))
            {
                this._preUnPrcFracProcDivNmCell = this.Detail_uGrid.ActiveCell;
            }
            #region ■端数処理区分チェック
            if (this._preUnPrcFracProcDivNmCell != null)
            {
                switch (this._preUnPrcFracProcDivNmCell.Text)
                {
                    case "1":
                    case "1:切捨て":
                    case "2":
                    case "2:四捨五入":
                    case "3":
                    case "3:切上げ":
                        break;
                    default:
                        if (!this._preUnPrcFracProcDivNmCell.Disposed)
                        {
                            this._preUnPrcFracProcDivNmCell.Value = 2;
                            this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);
                        }
                        break;
                }
            }
            #endregion

            #region ■行削除ボタン有効無効の設定
            //if (this.Detail_uGrid.ActiveCell != null)
            //{
            //    this.Delete_Button.Enabled = true;
            //}
            //else
            //{
            //    this.Delete_Button.Enabled = false;
            //}
            //#endregion

            //#region ■全削除ボタン有効無効の設定
            //if (this.AllDeleteEnabledCheck())
            //{
            //    this.DeleteAll_Button.Enabled = true;
            //}
            //else
            //{
            //    this.DeleteAll_Button.Enabled = false;
            //}
            #region ■行削除/全削除ボタン有効無効の設定
            if (this.Detail_uGrid.Rows.Count != 0)
            {
                this.Delete_Button.Enabled = true;
                this.DeleteAll_Button.Enabled = true;
            }
            else
            {
                this.Delete_Button.Enabled = false;
                this.DeleteAll_Button.Enabled = false;
            }
            #endregion
            #endregion
        }

        /// <summary>
        /// 行削除ボタンクリックイベント
        /// </summary>
        /// <remarks>
        /// <br>Note        : 行削除処理を行います。</br>
        /// <br>Programmer  : 朱 猛</br>
        /// <br>Date        : 2010/09/10</br>
        /// <br>Update Note : 2010/09/30 朱 猛</br>
        /// <br>            : Redmine#15703対応</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            
            //this.RowDelete();
            int rowIndex = 0;
            if (this.Detail_uGrid.ActiveCell != null)
            {
                rowIndex = this.Detail_uGrid.ActiveCell.Row.Index;
            }
            else
            {
                if (this.Detail_uGrid.Rows.Count > 0)
                {
                    //RowDelete(); // DEL 2010/09/30
                    if (!this.AllDeleteCheck())
                    {
                        this.Delete_Button.Focus();
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);
            this._deleteButtonFlag = true;
            RowDelete();
            if (this._errorFlg)
            {
                ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = string.Empty;
                this._errorFlg = false;
            }
            if (!this.AllDeleteCheck())
            {
                this.Delete_Button.Focus();
                return;
            }

            // ------DEL 2010/09/30---------------------->>>
            //if (!CatchSelectedRow(rowIndex))
            //{
            //    ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
            //    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[SelectedRow()];
            //    this.Detail_uGrid.Rows[SelectedRow()].Cells[this.masterCode].Activate();
            //    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
            //}
            // ------DEL 2010/09/30----------------------<<<
            this._deleteButtonFlag = false;
            // ------UPD 2010/09/28----------------------<<<
        }

        /// <summary>
        /// 全削除ボタンクリックイベント
        /// </summary>
        /// <remarks>
        /// <br>Note        : 全削除処理を行います。</br>
        /// <br>Programmer  : 朱 猛</br>
        /// <br>Date        : 2010/09/10</br>
        /// </remarks>
        private void DeleteAll_Button_Click(object sender, EventArgs e)
        {
            // ------UPD 2010/09/28---------------------->>>
            //this.AllRowDelete();
            int rowIndex = 0;
            if (this.Detail_uGrid.ActiveCell != null)
            {
                rowIndex = this.Detail_uGrid.ActiveCell.Row.Index;
            }
            this._deleteButtonFlag = true;
            this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);
            this._deleteButtonFlag = false;
            if (this.AllDeleteEnabledCheck())
            {
                if (this._errorFlg)
                {
                    ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = string.Empty;
                }
                AllRowDelete();
                if (!this._errorFlg)
                {
                    ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[SelectedRow()];
                    this.Detail_uGrid.Rows[SelectedRow()].Cells[this.masterCode].Activate();
                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    return;
                }
                else
                {
                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                }
                this._errorFlg = false;
                if (!CatchSelectedRow(rowIndex))
                {
                    ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[SelectedRow()];
                    this.Detail_uGrid.Rows[SelectedRow()].Cells[this.masterCode].Activate();
                    this.SetGridTabFocus(ref evt);
                }
            }
            else
            {
                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }
            // ------UPD 2010/09/28----------------------<<<
        }

        /// <summary>
        /// PMKHN09478UA_FormClosing
        /// </summary>
        /// <remarks>
        /// <br>Note        : フォームが閉じる処理を行います。</br>
        /// <br>Programmer  : 朱 猛</br>
        /// <br>Date        : 2010/09/10</br>
        /// </remarks>
        private void PMKHN09478UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            #region 終了
            if (_closeFlg == false)
            {
                if (!this.CloseCheck())
                {
                    DialogResult dr = TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        CT_PGID,
                        "現在、編集中のデータが存在します\n\n" + "登録してもよろしいですか？",
                        0,
                        MessageBoxButtons.YesNoCancel);

                    switch (dr)
                    {
                        case DialogResult.No:
                            break;
                        case DialogResult.Yes:
                            if (!this.SaveProc())
                            {
                                e.Cancel = true;
                            }

                            break;
                        case DialogResult.Cancel:
                            e.Cancel = true;
                            if (this.Detail_uGrid.ActiveCell != null)
                            {
                                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode); // ADD 2010/09/09
                            }
                            break;
                    }
                }
            }
            #endregion
        }
        #endregion Event

        #region Private Method

        /// <summary>
        /// アイコン設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : ツールバーとボタンのアイコンを設定します。</br>
        /// <br>Programmer	: 楊明俊</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        private void SetIcon()
        {
            ImageList imageList16 = IconResourceManagement.ImageList16;

            // -----------------------------
            // ツールバーアイコン設定
            // -----------------------------
            // イメージリスト設定
            this.tToolbarsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;
            // 終了
            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_CLOSEBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // クリア
            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_CLEARBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            // 保存
            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_SAVEBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            // 検索
            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_SEARCHBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            // 設定
            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_SETBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;
            // 行削除
            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_ROWDELETE_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWDELETE;
            // ---------ADD 2010/09/09---------->>>>>
            // ガイド
            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_GUIDE_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            // ---------ADD 2010/09/09----------<<<<<
            // ログイン拠点
            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_SECTIONTITLELABEL_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
            // ログイン拠点名
            ToolBase loginName = tToolbarsManager_MainMenu.Tools[TOOLBAR_SECTIONNAMELABEL_KEY];
            if (loginName != null && LoginInfoAcquisition.Employee != null)
            {
                SecInfoSet secInfoSet = new SecInfoSet();
                this._secInfoAcs.GetSecInfo(this._loginSectionCode, out secInfoSet);
                if (secInfoSet != null)
                {
                    loginName.SharedProps.Caption = secInfoSet.SectionGuideNm;
                }
            }
            // ログイン担当者
            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINTITLELABEL_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            // 担当者表示
            if (LoginInfoAcquisition.Employee != null)
            {
                this.tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINNAMELABEL_KEY].SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            }

            // -----------------------------
            // ボタンアイコン設定
            // -----------------------------
            this.CustomerGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.CustRateGrpGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SupplierGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.MakerGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.BLGoodsGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.BLGroupGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.GoodsRateGrpGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
        }

        /// <summary>
        /// フォーカス設定処理
        /// </summary>
        /// <param name="mode">モード</param>
        /// <returns>status:(mode = 3時有効)</returns>
        /// <remarks>
        /// <br>Note        : ガイドボタン押下後のフォーカス設定を行います。</br>
        /// <br>Programmer	: 楊明俊</br>
        /// <br>Date		: 2010/08/12</br>
        /// <br>Update Note : 2010/09/25 朱 猛</br>
        /// <br>            : Redmine#14492対応</br>
        /// </remarks>
        private bool SetFocus(int mode)
        {
            bool status = true;
            switch (mode)
            {
                #region 画面初期フォーカス取得(グリッド除く)
                case 0:
                    {
                        if (_initFocus != null)
                        {
                            if (_initFocus is TNedit)
                            {
                                ((TNedit)_initFocus).Focus();
                            }
                            else if (_initFocus is TEdit)
                            {
                                ((TEdit)_initFocus).Focus();
                            }
                            
                        }
                        else
                        {

                            if (_endFocus is TNedit)
                            {
                                ((TNedit)_endFocus).Focus();
                            }
                            else if (_endFocus is TEdit)
                            {
                                ((TEdit)_endFocus).Focus();
                            }
                        }
                        
                        break;
                    }
                #endregion

                #region Grid->抽出条件部(key.Up)
                case 1:
                    {
                        if (_endFocus != null)
                        {

                            if (_endFocus is TNedit)
                            {
                                ((TNedit)_endFocus).Focus();
                            }
                            else if (_endFocus is TEdit)
                            {
                                ((TEdit)_endFocus).Focus();
                            }
                        }
                        
                        break;
                    }
                #endregion Grid->抽出条件部(key.Up)

                #region Grid->抽出条件部(shift + Tab)
                case 2:
                    {
                        if (_endFocus != null)
                        {
                            if (_endFocus is TNedit)
                            {
                                TNedit tNedit = (TNedit)_endFocus;
                                ((UltraButton)_endButtonFocus).Focus();
                            }
                            else if (_endFocus is TEdit)
                            {
                                TEdit tEdit = (TEdit)_endFocus;
                                ((UltraButton)_endButtonFocus).Focus();
                            }
                        }
                        break;
                    }
                #endregion Grid->抽出条件部(Alt + Tab)

                #region Nextフォーカス設定
                case 3:
                    {
                        // 得意先
                        if (this.tNedit_CustomerCode.Focused || this.CustomerGuide_Button.Focused)
                        {
                            if (this.tNedit_SupplierCd.Enabled)
                            {
                                this.tNedit_SupplierCd.Focus();
                            }
                            else
                            {
                                status = false;
                            }
                        }
                        // 得意先掛率グループ
                        else if (this.tNedit_CustRateGrpCodeZero.Focused || this.CustRateGrpGuide_Button.Focused)
                        {
                            if (this.tNedit_SupplierCd.Enabled)
                            {
                                this.tNedit_SupplierCd.Focus();
                            }
                            else
                            {
                                status = false;
                            }
                        }
                        // 仕入先
                        else
                        {
                           status = false;
                        }
                        break;
                    }
                #endregion Nextフォーカス設定

                #region 抽出条件部(shift + Tab)
                case 4:
                    {
                        if (this.tNedit_SupplierCd.Focused || this.SupplierGuide_Button.Focused)
                        {
                            if (this.tNedit_CustRateGrpCodeZero.Enabled)
                            {
                                this.CustRateGrpGuide_Button.Focus();
                            }
                            else if (this.tNedit_CustomerCode.Enabled)
                            {
                                this.CustomerGuide_Button.Focus();
                            }
                        }
                        break;
                    }
                #endregion 抽出条件部(shift + Tab)
            }
            // --------ADD 2010/09/09-------->>>
            #region ■↑キーでGridから抽出条件部への場合のガイド有効無効の設定
            if (this.tNedit_CustomerCode.Focused || this.tNedit_CustRateGrpCodeZero.Focused || this.tNedit_SupplierCd.Focused || this.tNedit_GoodsMakerCd.Focused
                || this.tNedit_BLGoodsCode.Focused || this.tNedit_GoodsMGroup.Focused || this.tNedit_BLGloupCode.Focused)
            {
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
            }
            else
            {
                if (this.Detail_uGrid.ActiveCell != null)
                {
                    if (this.Detail_uGrid.ActiveCell.Activation == Activation.AllowEdit)
                    {
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    //if (this.Detail_uGrid.ActiveCell.Column.Key.Equals("MasterNm")) // DEL 2010/09/25
                    if (this.Detail_uGrid.ActiveCell.Column.Key.Equals(masterCode)) // ADD 2010/09/25
                    {
                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                    }
                }
            }
            #endregion
            // --------ADD 2010/09/09--------<<<

            return status;
        }

        /// <summary>
        /// 得意先掛率グループ名称取得処理
        /// </summary>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        /// <returns>得意先掛率グループ名称</returns>
        /// <remarks>
        /// <br>Note        : なし</br>
        /// <br>Programmer	: 楊明俊</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        private bool GetCustRateGrpName(int custRateGrpCode, out string custRateGrpName)
        {
            custRateGrpName = "";
            bool check = false;
            // --------UPD 2010/09/09-------->>>>>
            //if (_custRateGrpDic == null)
            //{
            //    LoadCustRateGrp();
            //}

            //if (this._custRateGrpDic.ContainsKey(custRateGrpCode))
            //{
            //    custRateGrpName = (string)this._custRateGrpDic[custRateGrpCode];
            //    check = true;
            //}

            UserGdBd userGdBd = null;
            UserGuideAcsData acsDataType = UserGuideAcsData.UserBodyData;
            int status = this._userGuideAcs.ReadBody(out userGdBd, this._enterpriseCode, 43, custRateGrpCode, ref acsDataType);

            if (userGdBd != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && userGdBd.LogicalDeleteCode == 0)
            {
                custRateGrpName = userGdBd.GuideName;
                check = true;
            }
            // --------UPD 2010/09/09-------->>>>>

            return check;
        }

        /// <summary>
        /// 得意先掛率グループ情報取得処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : なし</br>
        /// <br>Programmer	: 楊明俊</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        private int LoadCustRateGrp()
        {
            this._custRateGrpDic = new Dictionary<int, string>();

            int status;
            ArrayList retList = new ArrayList();

            // ユーザーガイドデータ取得(得意先掛率グループ)
            status = GetUserGuideBd(out retList, 43);
            if (status == 0)
            {
                foreach (UserGdBd userGdBd in retList)
                {
                    this._custRateGrpDic.Add(userGdBd.GuideCode, userGdBd.GuideName.Trim());
                }
            }

            return status;
        }

        /// <summary>
        /// ユーザーガイドデータ取得処理
        /// </summary>
        /// <param name="retList">ユーザーガイドボディデータリスト</param>
        /// <param name="userGuideDivCd">ガイド区分</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : なし</br>
        /// <br>Programmer	: 楊明俊</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        private int GetUserGuideBd(out ArrayList retList, int userGuideDivCd)
        {
            int status;
            retList = new ArrayList();

            status = this._userGuideAcs.SearchAllDivCodeBody(out retList, this._enterpriseCode,
                                                             userGuideDivCd, UserGuideAcsData.UserBodyData);

            return status;
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報をクリアします。</br>
        /// <br>Programmer	: 楊明俊</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.Mode_Label.Text = INSERT_MODE;
            // ----------UPD 2010/09/09----------->>>>>
            //if ("指定なし".Equals(this._rateProtyMng.RateMngCustNm.Trim()))
            //{
            //    this.ultraLabel_RateMngGoodsNm.Text = this._rateProtyMng.RateMngGoodsNm.Trim();
            //    this.ultraLabel_RateMngCustNm.Text = "";
            //}
            //else
            //{
            //    this.ultraLabel_RateMngCustNm.Text = this._rateProtyMng.RateMngCustNm.Trim();
            //    this.ultraLabel_RateMngGoodsNm.Text = "";
            //}
            this.ultraLabel_RateMngCustNm.Text = this._rateProtyMng.RateSettingDivide.Trim();
            this.ultraLabel_RateMngGoodsNm.Text = this._rateProtyMng.RateMngCustNm.Trim() + "+" + this._rateProtyMng.RateMngGoodsNm.Trim();
            if (this._rateProtyMng.UnitPriceKind == 1)
            {
                this.Setting_Label.Text = UnitPriceKindNM_1;
            }
            else if (this._rateProtyMng.UnitPriceKind == 2)
            {
                this.Setting_Label.Text = UnitPriceKindNM_2;
            }
            else if (this._rateProtyMng.UnitPriceKind == 3)
            {
                this.Setting_Label.Text = UnitPriceKindNM_3;
            }
            // ----------UPD 2010/09/09-----------<<<<<
            this.tNedit_GoodsMakerCd.Clear();
            this.MakerName_tEdit.Clear();
            this.tNedit_CustRateGrpCodeZero.Clear();
            this.tEdit_CustRateGrpNm.Clear();
            this.tNedit_CustomerCode.Clear();
            this.CustomerCodeNm_tEdit.Clear();
            this.tNedit_SupplierCd.Clear();
            this.SupplierCdNm_tEdit.Clear();
            this.tNedit_GoodsMakerCd.Clear();
            this.MakerName_tEdit.Clear();
            this.tNedit_BLGoodsCode.Clear();
            this.BLGoodsName_tEdit.Clear();
            this.tNedit_CustRateGrpCodeZero.Clear();
            this.GoodsRateGrpName_tEdit.Clear();
            this.tNedit_BLGloupCode.Clear();
            this.BLGroupName_tEdit.Clear();

            ScreenToRateProtyMngPattern(ref this._rateProtyMngPatternWorkClone);
            // ----------UPD 2010/09/09----------->>>
            //this._prevMakerCode = 0;
            //this._prevCustRateGrpCode = -1;
            //this._prevCustomerCode = 0;
            //this._prevSupplierCode = 0;
            //this._prevBLGoodsCode = 0;
            //this._prevBLGroupCode = 0;
            //this._prevGoodsRateGrpCode = 0;
            if (!this._searchAfterSaveFlg)
            {
                this._prevMakerCode = -1;
                this._prevCustRateGrpCode = -1;
                this._prevCustomerCode = -1;
                this._prevSupplierCode = -1;
                this._prevBLGoodsCode = -1;
                this._prevBLGroupCode = -1;
                this._prevGoodsRateGrpCode = -1;
            }
            // ----------UPD 2010/09/09-----------<<<

            this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows.Clear();
            this._preUnPrcFracProcDivNmCell = null; // ADD 2010/09/10

            // フォーカス設定
            this.SetFocus(0);
        }

        /// <summary>
        /// 掛率設定区分により、得意先、得意先掛率グループ、仕入先の項目を入力可否の変更。
        /// </summary>
        /// <remarks>
        /// <br>Note        : 掛率設定区分により、得意先、得意先掛率グループ、仕入先の項目を入力可否を変更する。</br>
        /// <br>Programmer	: 楊明俊</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        private void ScreenInputEnable()
        {
            #region [掛率設定区分（得意先）]
            switch (this._rateProtyMng.RateMngCustCd.Trim())
            {
                case "1":// 得意先 + 仕入先
                    {
                        // 得意先
                        this.tNedit_CustomerCode.Enabled = true;
                        this.CustomerCode_Label.Enabled = true;
                        this.CustomerCodeNm_tEdit.Enabled = false;
                        this.CustomerGuide_Button.Enabled = true;
                        this.tNedit_CustomerCode.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
                        //得意先掛率ｸﾞﾙｰﾌﾟ
                        this.tNedit_CustRateGrpCodeZero.Enabled = false;
                        this.tEdit_CustRateGrpNm.Enabled = false;
                        this.CustRateGrpCode_Label.Enabled = false;
                        this.CustRateGrpGuide_Button.Enabled = false;
                        //仕入先
                        this.tNedit_SupplierCd.Enabled = true;
                        this.SupplierCd_Label.Enabled = true;
                        this.SupplierCdNm_tEdit.Enabled = false;
                        this.SupplierGuide_Button.Enabled = true;

                        this._initFocus = this.tNedit_CustomerCode;
                        // UPD 2010/09/19 -- >>>
                        //this._endFocus = this.tNedit_SupplierCd;
                        this._endFocus = this.tNedit_CustomerCode;
                        //this._endButtonFocus = this.SupplierGuide_Button;
                        this._endButtonFocus = this.CustomerGuide_Button;
                        // UPD 2010/09/19 -- <<<
                        break;
                    }
                case "2":// 得意先
                    {
                        // 得意先
                        this.tNedit_CustomerCode.Enabled = true;
                        this.CustomerCode_Label.Enabled = true;
                        this.CustomerCodeNm_tEdit.Enabled = false;
                        this.CustomerGuide_Button.Enabled = true;
                        //得意先掛率ｸﾞﾙｰﾌﾟ
                        this.tNedit_CustRateGrpCodeZero.Enabled = false;
                        this.tEdit_CustRateGrpNm.Enabled = false;
                        this.CustRateGrpCode_Label.Enabled = false;
                        this.CustRateGrpGuide_Button.Enabled = false;
                        //仕入先
                        this.tNedit_SupplierCd.Enabled = false;
                        this.SupplierCd_Label.Enabled = false;
                        this.SupplierCdNm_tEdit.Enabled = false;
                        this.SupplierGuide_Button.Enabled = false;

                        this._initFocus = this.tNedit_CustomerCode;
                        this._endFocus = this.tNedit_CustomerCode;
                        this._endButtonFocus = this.CustomerGuide_Button;

                        break;
                    }
                case "3":// 得意先掛率G + 仕入先
                    {
                        // 得意先
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerCode_Label.Enabled = false;
                        this.CustomerCodeNm_tEdit.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;
                        //得意先掛率ｸﾞﾙｰﾌﾟ
                        this.tNedit_CustRateGrpCodeZero.Enabled = true;
                        this.tEdit_CustRateGrpNm.Enabled = false;
                        this.CustRateGrpCode_Label.Enabled = true;
                        this.CustRateGrpGuide_Button.Enabled = true;
                        this.tNedit_CustRateGrpCodeZero.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));

                        //仕入先
                        this.tNedit_SupplierCd.Enabled = true;
                        this.SupplierCd_Label.Enabled = true;
                        this.SupplierCdNm_tEdit.Enabled = false;
                        this.SupplierGuide_Button.Enabled = true;

                        this._initFocus = this.tNedit_CustRateGrpCodeZero;
                        // UPD 2010/09/19 -- >>>
                        //this._endFocus = this.tNedit_SupplierCd;
                        this._endFocus = this.tNedit_CustRateGrpCodeZero;
                        //this._endButtonFocus = this.SupplierGuide_Button;
                        this._endButtonFocus = this.CustRateGrpGuide_Button;
                        // UPD 2010/09/19 -- <<<
                        break;
                    }
                case "4":// 得意先掛率G
                    {
                        // 得意先
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerCode_Label.Enabled = false;
                        this.CustomerCodeNm_tEdit.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;
                        //得意先掛率ｸﾞﾙｰﾌﾟ
                        this.tNedit_CustRateGrpCodeZero.Enabled = true;
                        this.tEdit_CustRateGrpNm.Enabled = false;
                        this.CustRateGrpCode_Label.Enabled = true;
                        this.CustRateGrpGuide_Button.Enabled = true;
                        //仕入先
                        this.tNedit_SupplierCd.Enabled = false;
                        this.SupplierCd_Label.Enabled = false;
                        this.SupplierCdNm_tEdit.Enabled = false;
                        this.SupplierGuide_Button.Enabled = false;

                        this._initFocus = this.tNedit_CustRateGrpCodeZero;
                        this._endFocus = this.tNedit_CustRateGrpCodeZero;
                        this._endButtonFocus = this.CustRateGrpGuide_Button;

                        break;
                    }
                case "5":// 仕入先
                    {
                        // 得意先
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerCode_Label.Enabled = false;
                        this.CustomerCodeNm_tEdit.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;
                        //得意先掛率ｸﾞﾙｰﾌﾟ
                        this.tNedit_CustRateGrpCodeZero.Enabled = false;
                        this.tEdit_CustRateGrpNm.Enabled = false;
                        this.CustRateGrpCode_Label.Enabled = false;
                        this.CustRateGrpGuide_Button.Enabled = false;
                        //仕入先
                        this.tNedit_SupplierCd.Enabled = true;
                        this.SupplierCd_Label.Enabled = true;
                        this.SupplierCdNm_tEdit.Enabled = false;
                        this.SupplierGuide_Button.Enabled = true;

                        this._initFocus = this.tNedit_SupplierCd;
                        this._endFocus = this.tNedit_SupplierCd;
                        this._endButtonFocus = this.SupplierGuide_Button;

                        break;
                    }
                case "6":// 指定なし
                    {
                        // 得意先
                        this.tNedit_CustomerCode.Enabled = false;
                        this.CustomerCode_Label.Enabled = false;
                        this.CustomerCodeNm_tEdit.Enabled = false;
                        this.CustomerGuide_Button.Enabled = false;
                        //得意先掛率ｸﾞﾙｰﾌﾟ
                        this.tNedit_CustRateGrpCodeZero.Enabled = false;
                        this.tEdit_CustRateGrpNm.Enabled = false;
                        this.CustRateGrpCode_Label.Enabled = false;
                        this.CustRateGrpGuide_Button.Enabled = false;
                        //仕入先
                        this.tNedit_SupplierCd.Enabled = false;
                        this.SupplierCd_Label.Enabled = false;
                        this.SupplierCdNm_tEdit.Enabled = false;
                        this.SupplierGuide_Button.Enabled = false;
                        break;
                    }
            }
            #endregion [掛率設定区分（得意先）]

            #region [掛率設定区分（商品）]
            switch (this._rateProtyMng.RateMngGoodsCd.Trim())
            {
                case "H":// BLコード
                    {
                        // メーカー
                        this.tNedit_GoodsMakerCd.Enabled = false;
                        this.GoodsMakerCd_Grp_Label.Enabled = false;
                        this.MakerName_tEdit.Enabled = false;
                        this.MakerGuide_Button.Enabled = false;

                        //ＢＬコード
                        this.tNedit_BLGoodsCode.Enabled = true;
                        this.BLGoods_Label.Enabled = true;
                        this.BLGoodsName_tEdit.Enabled = false;
                        this.BLGoodsGuide_Button.Enabled = true;

                        //商品掛率Ｇ
                        this.tNedit_GoodsMGroup.Enabled = false;
                        this.GoodsRateGrp_Label.Enabled = false;
                        this.GoodsRateGrpName_tEdit.Enabled = false;
                        this.GoodsRateGrpGuide_Button.Enabled = false;

                        //グループコード
                        this.tNedit_BLGloupCode.Enabled = false;
                        this.BLGroup_Label.Enabled = false;
                        this.BLGroupName_tEdit.Enabled = false;
                        this.BLGroupGuide_Button.Enabled = false;

                        this._initFocus = this.tNedit_BLGoodsCode;
                        this._endFocus = this.tNedit_BLGoodsCode;
                        this._endButtonFocus = this.BLGoodsGuide_Button;
                        break;
                    }
                case "I":// グループコード
                    {
                        // メーカー
                        this.tNedit_GoodsMakerCd.Enabled = false;
                        this.GoodsMakerCd_Grp_Label.Enabled = false;
                        this.MakerName_tEdit.Enabled = false;
                        this.MakerGuide_Button.Enabled = false;

                        //ＢＬコード
                        this.tNedit_BLGoodsCode.Enabled = false;
                        this.BLGoods_Label.Enabled = false;
                        this.BLGoodsName_tEdit.Enabled = false;
                        this.BLGoodsGuide_Button.Enabled = false;

                        //商品掛率Ｇ
                        this.tNedit_GoodsMGroup.Enabled = false;
                        this.GoodsRateGrp_Label.Enabled = false;
                        this.GoodsRateGrpName_tEdit.Enabled = false;
                        this.GoodsRateGrpGuide_Button.Enabled = false;

                        //グループコード
                        this.tNedit_BLGloupCode.Enabled = true;
                        this.BLGroup_Label.Enabled = true;
                        this.BLGroupName_tEdit.Enabled = false;
                        this.BLGroupGuide_Button.Enabled = true;

                        this._initFocus = this.tNedit_BLGloupCode;
                        this._endFocus = this.tNedit_BLGloupCode;
                        this._endButtonFocus = this.BLGroupGuide_Button;
                        break;
                    }
                case "J":// 中分類
                    {
                        // メーカー
                        this.tNedit_GoodsMakerCd.Enabled = false;
                        this.GoodsMakerCd_Grp_Label.Enabled = false;
                        this.MakerName_tEdit.Enabled = false;
                        this.MakerGuide_Button.Enabled = false;

                        //ＢＬコード
                        this.tNedit_BLGoodsCode.Enabled = false;
                        this.BLGoods_Label.Enabled = false;
                        this.BLGoodsName_tEdit.Enabled = false;
                        this.BLGoodsGuide_Button.Enabled = false;

                        //商品掛率Ｇ
                        this.tNedit_GoodsMGroup.Enabled = true;
                        this.GoodsRateGrp_Label.Enabled = true;
                        this.GoodsRateGrpName_tEdit.Enabled = false;
                        this.GoodsRateGrpGuide_Button.Enabled = true;

                        //グループコード
                        this.tNedit_BLGloupCode.Enabled = false;
                        this.BLGroup_Label.Enabled = false;
                        this.BLGroupName_tEdit.Enabled = false;
                        this.BLGroupGuide_Button.Enabled = false;

                        this._initFocus = this.tNedit_GoodsMGroup;
                        this._endFocus = this.tNedit_GoodsMGroup;
                        this._endButtonFocus = this.GoodsRateGrpGuide_Button;
                        break;
                    }
                case "K":// メーカー
                    {
                        // メーカー
                        this.tNedit_GoodsMakerCd.Enabled = true;
                        this.GoodsMakerCd_Grp_Label.Enabled = true;
                        this.MakerName_tEdit.Enabled = false;
                        this.MakerGuide_Button.Enabled = true;

                        //ＢＬコード
                        this.tNedit_BLGoodsCode.Enabled = false;
                        this.BLGoods_Label.Enabled = false;
                        this.BLGoodsName_tEdit.Enabled = false;
                        this.BLGoodsGuide_Button.Enabled = false;

                        //商品掛率Ｇ
                        this.tNedit_GoodsMGroup.Enabled = false;
                        this.GoodsRateGrp_Label.Enabled = false;
                        this.GoodsRateGrpName_tEdit.Enabled = false;
                        this.GoodsRateGrpGuide_Button.Enabled = false;

                        //グループコード
                        this.tNedit_BLGloupCode.Enabled = false;
                        this.BLGroup_Label.Enabled = false;
                        this.BLGroupName_tEdit.Enabled = false;
                        this.BLGroupGuide_Button.Enabled = false;

                        this._initFocus = this.tNedit_GoodsMakerCd;
                        this._endFocus = this.tNedit_GoodsMakerCd;
                        this._endButtonFocus = this.MakerGuide_Button;
                        break;
                    }
                case "L":// 指定なし
                    {
                        // メーカー
                        this.tNedit_GoodsMakerCd.Enabled = false;
                        this.GoodsMakerCd_Grp_Label.Enabled = false;
                        this.MakerName_tEdit.Enabled = false;
                        this.MakerGuide_Button.Enabled = false;

                        //ＢＬコード
                        this.tNedit_BLGoodsCode.Enabled = false;
                        this.BLGoods_Label.Enabled = false;
                        this.BLGoodsName_tEdit.Enabled = false;
                        this.BLGoodsGuide_Button.Enabled = false;

                        //商品掛率Ｇ
                        this.tNedit_GoodsMGroup.Enabled = false;
                        this.GoodsRateGrp_Label.Enabled = false;
                        this.GoodsRateGrpName_tEdit.Enabled = false;
                        this.GoodsRateGrpGuide_Button.Enabled = false;

                        //グループコード
                        this.tNedit_BLGloupCode.Enabled = false;
                        this.BLGroup_Label.Enabled = false;
                        this.BLGroupName_tEdit.Enabled = false;
                        this.BLGroupGuide_Button.Enabled = false;
                        break;
                    }
                }

                // --- ADD 2010/09/10 ---------->>>>>
                string rateSettingDivide = this._rateProtyMng.RateMngCustCd.Trim() + this._rateProtyMng.RateMngGoodsCd.Trim();
                switch (rateSettingDivide)
                {
                    case "2L":
                        {
                            // 得意先
                            this.tNedit_CustomerCode.Enabled = false;
                            this.CustomerCode_Label.Enabled = false;
                            this.CustomerCodeNm_tEdit.Enabled = false;
                            this.CustomerGuide_Button.Enabled = false;

                            break;
                        }
                    case "4L":
                        {
                            //得意先掛率ｸﾞﾙｰﾌﾟ
                            this.tNedit_CustRateGrpCodeZero.Enabled = false;
                            this.tEdit_CustRateGrpNm.Enabled = false;
                            this.CustRateGrpCode_Label.Enabled = false;
                            this.CustRateGrpGuide_Button.Enabled = false;

                            break;
                        }
                    case "1L":
                    case "3L":
                    case "5L":
                        {
                            //仕入先
                            this.tNedit_SupplierCd.Enabled = false;
                            this.SupplierCd_Label.Enabled = false;
                            this.SupplierCdNm_tEdit.Enabled = false;
                            this.SupplierGuide_Button.Enabled = false;

                            break;
                        }
                    case "6H":
                        {
                            //ＢＬコード
                            this.tNedit_BLGoodsCode.Enabled = false;
                            this.BLGoods_Label.Enabled = false;
                            this.BLGoodsName_tEdit.Enabled = false;
                            this.BLGoodsGuide_Button.Enabled = false;

                            break;
                        }
                    case "6I":
                        {
                            //グループコード
                            this.tNedit_BLGloupCode.Enabled = false;
                            this.BLGroup_Label.Enabled = false;
                            this.BLGroupName_tEdit.Enabled = false;
                            this.BLGroupGuide_Button.Enabled = false;

                            break;
                        }
                    case "6J":
                        {
                            //商品掛率Ｇ
                            this.tNedit_GoodsMGroup.Enabled = false;
                            this.GoodsRateGrp_Label.Enabled = false;
                            this.GoodsRateGrpName_tEdit.Enabled = false;
                            this.GoodsRateGrpGuide_Button.Enabled = false;

                            break;
                        }
                    case "6K":
                        {
                            // メーカー
                            this.tNedit_GoodsMakerCd.Enabled = false;
                            this.GoodsMakerCd_Grp_Label.Enabled = false;
                            this.MakerName_tEdit.Enabled = false;
                            this.MakerGuide_Button.Enabled = false;

                            break;
                        }
                    // --- ADD 2010/09/10 ----------<<<<<

            }
            #endregion [掛率設定区分（商品）]
        }

        /// <summary>
        /// グリッド最上位行キーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 画面ヘッダクリア処理を行う。 </br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/08/12</br>
        /// </remarks>
        private void Detail_uGrid_GridKeyDownTopRow(object sender, EventArgs e)
        {
            //this.tComboEditor_UnitPriceKind.Focus();
        }

        /// <summary>
        /// ユーザー設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : ユーザー設定画面を表示します。</br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
        private void SetUp()
        {
            PMKHN09473UB PMKHN09473UB = new PMKHN09473UB();
            PMKHN09473UB.ShowDialog();

            this._cellMove = PMKHN09473UB.CellMove;
        }

        /// <summary>
        /// グリッドフォーカス設定処理
        /// </summary>
        /// <param name="mode">モード</param>
        /// <param name="rowIndex">グリッド行</param>
        /// <remarks>
        /// <br>Note        : グリッドフォーカス設定を行います。</br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date        : 2010/08/12</br>
        /// <br>Update Note : 2010/09/25 朱 猛</br>
        /// <br>            : Redmine#14492対応</br>
        /// </remarks>
        private void InitGridFocus(int rowIndex, int mode)
        {
            switch (mode)
            {
                // グリッド初期化フォーカス設定
                case 0:
                    {
                        // ---UPD 2010/09/09---------------------->>>
                        //// 売価場合
                        //if (this._rateProtyMng.UnitPriceKind == 1)
                        //{
                        //    // 売価率
                        //    this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Activate();
                        //}
                        //// 原価場合
                        //else if (this._rateProtyMng.UnitPriceKind == 2)
                        //{
                        //    // 仕入率
                        //    this.Detail_uGrid.Rows[0].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Activate();
                        //}
                        //// 価格場合
                        //else if (this._rateProtyMng.UnitPriceKind == 3)
                        //{
                        //    // 定価UP率
                        //    this.Detail_uGrid.Rows[0].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Activate();
                        //}

                        //if (this.Detail_uGrid.Rows[0].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Activation == Activation.AllowEdit)
                        //{
                        //    this.Detail_uGrid.Rows[0].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Activate();
                        //}
                        //if (this.Detail_uGrid.Rows[0].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Activation == Activation.AllowEdit) // DEL 2010/09/25
                        if (this.Detail_uGrid.Rows[0].Cells[this.masterCode].Activation == Activation.AllowEdit) // ADD 2010/09/25
                        {
                            //this.Detail_uGrid.Rows[0].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Activate(); // DEL 2010/09/25
                            this.Detail_uGrid.Rows[0].Cells[this.masterCode].Activate(); // ADD 2010/09/25
                        }
                        else
                        {
                            // 売価場合
                            if (this._rateProtyMng.UnitPriceKind == 1)
                            {
                                // 売価率
                                this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Activate();
                            }
                            // 原価場合
                            else if (this._rateProtyMng.UnitPriceKind == 2)
                            {
                                // 仕入率
                                this.Detail_uGrid.Rows[0].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Activate();
                            }
                            // 価格場合
                            else if (this._rateProtyMng.UnitPriceKind == 3)
                            {
                                // 定価UP率
                                this.Detail_uGrid.Rows[0].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Activate();
                            }
                        }
                        // ---UPD 2010/09/09----------------------<<<
                        
                        break;
                    }
                // グリッド最終可入力列フォーカス設定
                case 1:
                    {
                        // 売価場合
                        if (this._rateProtyMng.UnitPriceKind == 1)
                        {
                            // 粗利確保率
                            this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName].Activate();
                        }
                        // 原価場合
                        else if (this._rateProtyMng.UnitPriceKind == 2)
                        {
                            // 仕入率
                            this.Detail_uGrid.Rows[0].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Activate();
                        }
                        // 価格場合
                        else if (this._rateProtyMng.UnitPriceKind == 3)
                        {
                            // 端数処理区分
                            this.Detail_uGrid.Rows[0].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Activate();
                        }
                        break;
                    }
            }
            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
            
        }

        #region タブ移動
        /// <summary>
        /// グリッドタブ移動制御
        /// </summary>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドにフォーカスがある場合のタブ移動を制御します。</br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
        private void SetGridTabFocus(ref ChangeFocusEventArgs e)
        {
            if (this.Detail_uGrid.ActiveCell == null || this.Detail_uGrid.ActiveRow == null)
            {
                e.NextCtrl = null;
                this.Detail_uGrid.Focus();
                this.InitGridFocus(0, 0);
                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }

            int rowIndex = this.Detail_uGrid.ActiveCell.Row.Index;
            int columnIndex = this.Detail_uGrid.ActiveCell.Column.Index;
            string columnKey = this.Detail_uGrid.ActiveCell.Column.Key;

            e.NextCtrl = null;

            this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);

            // セル移動：右
            if (this._cellMove == 0)
            {
                if ((rowIndex == this.Detail_uGrid.Rows.Count - 1) &&
                    (columnKey == GetGridLastColumKey()))
                {
                    // ---------DEL 2010/09/09---------->>>>>
                    //SetFocus(0);
                    this.Detail_uGrid.Rows[rowIndex].Cells[columnKey].Activate();
                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    // ---------DEL 2010/09/09----------<<<<<
                     e.NextCtrl = null;
                }
                else
                {
                    this.Detail_uGrid.Focus();

                    string columnName = columnKey;
                    // 次セル取得
                    int targetColumnIndex = GetNextColumnIndexByTab(0, rowIndex, columnName);
                    if (targetColumnIndex != -1)
                    {
                        this.Detail_uGrid.Rows[rowIndex].Cells[targetColumnIndex].Activate();
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }
                    else
                    {
                        // 改行
                        //columnName = this.GetGridInitColumKey();
                        // ---------UPD 2010/09/09---------->>>>>
                        //for (int targetRowIndex = rowIndex + 1; targetRowIndex < this.Detail_uGrid.Rows.Count; targetRowIndex++)
                        //{
                        //    columnName = this.GetGridInitColumKey();

                        //    if (this.Detail_uGrid.Rows[targetRowIndex].Cells[columnName].Activation == Activation.AllowEdit)
                        //    {
                        //        this.Detail_uGrid.Rows[targetRowIndex].Cells[columnName].Activate();
                        //        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        //        return;
                        //    }
                        //}
                        //SetFocus(0);
                        //if (this.Detail_uGrid.Rows[rowIndex + 1].Cells[columnName].Activation == Activation.AllowEdit)
                        //{
                        //    this.Detail_uGrid.Rows[rowIndex + 1].Cells[columnName].Activate();
                        //    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        //    return;
                        //}
                        //else
                        //{
                        //    int nextColumnIndex = GetNextColumnIndexByTab(0, rowIndex + 1, columnName);
                        //    this.Detail_uGrid.Rows[rowIndex + 1].Cells[nextColumnIndex].Activate();
                        //    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        //}

                        if (this.Detail_uGrid.ActiveCell == null)
                        {
                            this.InitGridFocus(0, 0);
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }

                        if (!MoveNextAllowEditCell(false, 1))
                        {
                            // なし。
                        }

                        this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        // ---------UPD 2010/09/09----------<<<<<
                        e.NextCtrl = null;
                    }
                }
            }
            // セル移動：下
            else
            {
                if ((rowIndex == this.Detail_uGrid.Rows.Count - 1) &&
                    (columnKey == GetGridLastColumKey()))
                {
                    // ---------ADD 2010/09/09---------->>>>>
                    this.Detail_uGrid.Rows[rowIndex].Cells[columnKey].Activate();
                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    // ---------ADD 2010/09/09----------<<<<<
                    e.NextCtrl = null;
                }
                else
                {
                    this.Detail_uGrid.Focus();

                    for (int targetRowIndex = rowIndex + 1; targetRowIndex < this.Detail_uGrid.Rows.Count; targetRowIndex++)
                    {
                        if (this.Detail_uGrid.Rows[targetRowIndex].Cells[columnIndex].Activation == Activation.AllowEdit)
                        {
                            this.Detail_uGrid.Rows[targetRowIndex].Cells[columnIndex].Activate();
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }
                    }

                    // ---------ADD 2010/09/09---------->>>>>
                    int targetColumnIndex = GetNextColumnIndexByTab(0, this.Detail_uGrid.Rows.Count - 1, columnKey);
                    if (targetColumnIndex > 0)
                    {
                        for (int index = columnIndex + 1; index < this._rateProtyMngPatternDataSet.Tables[0].Columns.Count; index++)
                        {
                            for (int targetRowIndex = 0; targetRowIndex < this.Detail_uGrid.Rows.Count; targetRowIndex++)
                            {
                                if (this.Detail_uGrid.Rows[targetRowIndex].Cells[targetColumnIndex].Activation == Activation.AllowEdit)
                                {
                                    this.Detail_uGrid.Rows[targetRowIndex].Cells[targetColumnIndex].Activate();
                                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                            }
                        }
                    }
                    // ---------ADD 2010/09/09----------<<<<<
                    e.NextCtrl = null;
                }
            }
        }

        /// <summary>
        /// グリッドシフトタブ制御
        /// </summary>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドにフォーカスがある場合のシフトタブ移動を制御します。</br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
        private void SetGridShiftTabFocus(ref ChangeFocusEventArgs e)
        {
            if (this.Detail_uGrid.ActiveCell == null)
            {
                e.NextCtrl = null;
                this.Detail_uGrid.Focus();
                if (this.Detail_uGrid.ActiveRow == null)
                {
                    this.InitGridFocus(0, 1);
                }
                else
                {
                    this.InitGridFocus(0, 0);
                }
                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }

            int rowIndex = this.Detail_uGrid.ActiveCell.Row.Index;
            int columnIndex = this.Detail_uGrid.ActiveCell.Column.Index;
            string columnKey = this.Detail_uGrid.ActiveCell.Column.Key;

            e.NextCtrl = null;
            string rateSettingDivide = this._rateProtyMng.RateMngCustCd.Trim() + this._rateProtyMng.RateMngGoodsCd.Trim();// ADD 2010/09/09
            // セル移動：右
            if (this._cellMove == 0)
            {
                if ((rowIndex == 0) &&
                    (columnKey == GetGridInitColumKey()))
                {
                    // ---------UPD 2010/09/09---------->>>>>
                    //SetFocus(2);
                    //e.NextCtrl = null;
                    if ("1L".Equals(rateSettingDivide) || "3L".Equals(rateSettingDivide))
                    {
                        this.Detail_uGrid.ActiveCell = null;
                        this.Detail_uGrid.ActiveRow = null;
                        SetFocus(2);
                        e.NextCtrl = null;
                    }
                    else
                    {
                        this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);
                        this.Detail_uGrid.Rows[rowIndex].Cells[columnKey].Activate();
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        e.NextCtrl = null;
                    }
                    // ---------UPD 2010/09/09----------<<<<<
                }
                else
                {
                    this.Detail_uGrid.Focus();

                    // 次セル取得
                    string columnName = columnKey;
                    // 次セル取得
                    int targetColumnIndex = GetNextColumnIndexByTab(1, rowIndex, columnName);
                    if (targetColumnIndex != -1)
                    {
                        this.Detail_uGrid.Rows[rowIndex].Cells[targetColumnIndex].Activate();
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return;
                    }
                    else
                    {
                        // 改行
                        columnName = this.GetGridLastColumKey();
                        for (int targetRowIndex = rowIndex - 1; targetRowIndex >= 0; targetRowIndex--)
                        {
                            //if (this.Detail_uGrid.Rows[targetRowIndex].Cells[columnIndex].Activation == Activation.AllowEdit) // DEL 2010/09/09
                            if (this.Detail_uGrid.Rows[targetRowIndex].Cells[columnName].Activation == Activation.AllowEdit) // ADD 2010/09/09
                            {
                                this.Detail_uGrid.Rows[targetRowIndex].Cells[columnName].Activate();
                                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                        }
                        // ---------UPD 2010/09/09---------->>>>>
                        //SetFocus(2);
                        //e.NextCtrl = null;
                        if ("1L".Equals(rateSettingDivide) || "3L".Equals(rateSettingDivide))
                        {
                            this.Detail_uGrid.ActiveCell = null;
                            this.Detail_uGrid.ActiveRow = null;
                            SetFocus(2);
                            e.NextCtrl = null;
                        }
                        else
                        {
                            this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);
                            this.Detail_uGrid.Rows[rowIndex].Cells[columnKey].Activate();
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            e.NextCtrl = null;
                        }
                        // ---------UPD 2010/09/09----------<<<<<
                    }
                }
            }
            // セル移動：下
            else
            {
                if ((rowIndex == 0) &&
                    (columnKey == GetGridInitColumKey()))
                {
                    // ---------UPD 2010/09/09---------->>>>>
                    //SetFocus(2);
                    if ("1L".Equals(rateSettingDivide) || "3L".Equals(rateSettingDivide))
                    {
                        this.Detail_uGrid.ActiveCell = null;
                        this.Detail_uGrid.ActiveRow = null;
                        SetFocus(2);
                    }
                    else
                    {
                        this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);
                        this.Detail_uGrid.Rows[rowIndex].Cells[columnKey].Activate();
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        e.NextCtrl = null;
                    }
                    // ---------UPD 2010/09/09----------<<<<<
                }
                else
                {
                    this.Detail_uGrid.Focus();

                    for (int targetRowIndex = rowIndex - 1; targetRowIndex >= 0; targetRowIndex--)
                    {
                        if (this.Detail_uGrid.Rows[targetRowIndex].Cells[columnIndex].Activation == Activation.AllowEdit)
                        {
                            this.Detail_uGrid.Rows[targetRowIndex].Cells[columnIndex].Activate();
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }
                    }

                    int targetColumnIndex = GetNextColumnIndexByTab(1, this.Detail_uGrid.Rows.Count - 1, columnKey);

                    // ---------ADD 2010/09/09---------->>>>>
                    if (targetColumnIndex < 0)
                    {
                        // ---------UPD 2010/09/09---------->>>>>
                        //SetFocus(2);
                        if ("1L".Equals(rateSettingDivide) || "3L".Equals(rateSettingDivide))
                        {
                            this.Detail_uGrid.ActiveCell = null;
                            this.Detail_uGrid.ActiveRow = null;
                            SetFocus(2);
                        }
                        else
                        {
                            this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);
                            this.Detail_uGrid.Rows[rowIndex].Cells[columnKey].Activate();
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            e.NextCtrl = null;
                        }
                        // ---------UPD 2010/09/09----------<<<<<

                        return;
                    }
                    // ---------ADD 2010/09/09----------<<<<<

                    for (int index = columnIndex - 1; index > 0; index--)
                    {
                        for (int targetRowIndex = this.Detail_uGrid.Rows.Count - 1; targetRowIndex >= 0; targetRowIndex--)
                        {
                            if (this.Detail_uGrid.Rows[targetRowIndex].Cells[targetColumnIndex].Activation == Activation.AllowEdit)
                            {
                                this.Detail_uGrid.Rows[targetRowIndex].Cells[targetColumnIndex].Activate();
                                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// グリッド最終可編集列を取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : グリッド最終可編集取得を行います。</br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
        private string GetGridLastColumKey()
        {
            string lastColumKey = string.Empty;
            // 売価場合
            if (this._rateProtyMng.UnitPriceKind == 1)
            {
                // 粗利確保率
                lastColumKey = this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName;
            }
            // 原価場合
            else if (this._rateProtyMng.UnitPriceKind == 2)
            {
                // 仕入率
                lastColumKey = this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName;
            }
            // 価格場合
            else if (this._rateProtyMng.UnitPriceKind == 3)
            {
                // 端数処理区分
                lastColumKey = this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName;
            }
            return lastColumKey;
        }

        /// <summary>
        /// グリッド初期可編集列を取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : グリッド初期可編集列取得を行います。</br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date        : 2010/08/12</br>
        /// <br>Update Note : 2010/09/25 朱 猛</br>
        /// <br>            : Redmine#14492対応</br>
        /// </remarks>
        private string GetGridInitColumKey()
        {
            string initColumKey = string.Empty;
            // ---UPD 2010/09/09---------------------->>>
            //// 売価場合
            //if (this._rateProtyMng.UnitPriceKind == 1)
            //{
            //    // 売価率
            //    initColumKey = this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName;
            //}
            //// 原価場合
            //else if (this._rateProtyMng.UnitPriceKind == 2)
            //{
            //    // 仕入率
            //    initColumKey = this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName;
            //}
            //// 価格場合
            //else if (this._rateProtyMng.UnitPriceKind == 3)
            //{
            //    // 定価UP率
            //    initColumKey = this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName;
            //}
            // 単独指定
            //initColumKey = this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName; // DEL 2010/09/25
            initColumKey = this.masterCode; // ADD 2010/09/25
            // ---UPD 2010/09/09----------------------<<<
            return initColumKey;
        }

        /// <summary>
        /// グリッドNextフォーカス取得処理
        /// </summary>
        /// <param name="mode">モード(0:Tab;1;Shift + Tab)</param>
        /// <param name="rowIndex">rowIndex</param>
        /// <param name="columnKey">columnKey</param>
        /// <returns>columnIndex</returns>
        /// <remarks>
        /// <br>Note        : グリッドNextフォーカス取得を行います。</br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date        : 2010/08/12</br>
        /// <br>Update Note : 2010/09/25 朱 猛</br>
        /// <br>            : Redmine#14492対応</br>
        /// </remarks>
        private int GetNextColumnIndexByTab(int mode, int rowIndex, string columnKey)
        {
            int columnIndex = -1;
            switch (mode)
            {
                case 0:
                    #region Tab
                    // 売価場合
                    if (this._rateProtyMng.UnitPriceKind == 1)
                    {
                        // 売価率
                        if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName)
                        {
                            // 原価UP率
                            columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Column.Index;
                        }
                        // 原価UP率
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName)
                        {
                            // 粗利確保率
                            columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName].Column.Index;
                        }
                        // 粗利確保率
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName)
                        {
                            columnIndex = -1;
                        }
                        // ---ADD 2010/09/09---------------------->>>
                        // 単独指定
                        //else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName) // DEL 2010/09/25
                        else if (columnKey == this.masterCode) // ADD 2010/09/25
                        {
                            // 売価率
                            columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Column.Index;
                        }
                        // ---ADD 2010/09/09----------------------<<<
                    }
                    // 原価場合
                    else if (this._rateProtyMng.UnitPriceKind == 2)
                    {
                        // 仕入率
                        if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName)
                        {
                            columnIndex = -1;
                        }
                        // ---ADD 2010/09/09---------------------->>>
                        // 単独指定
                        //else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName)
                        else if (columnKey == this.masterCode)
                        {
                            // 仕入率
                            columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Column.Index;
                        }
                        // ---ADD 2010/09/09----------------------<<<
                    }
                    // 価格場合
                    else if (this._rateProtyMng.UnitPriceKind == 3)
                    {
                        // 定価UP率
                        if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName)
                        {
                            // 端数処理単位
                            columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].Column.Index;
                        }
                        // 端数処理単位
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName)
                        {
                            // 端数処理区分
                            columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Column.Index;
                        }
                        // 端数処理区分
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName)
                        {
                            columnIndex = -1;
                        }
                        // ---ADD 2010/09/09---------------------->>>
                        // 単独指定
                        //else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName) // DEL 2010/09/25
                        else if (columnKey == this.masterCode) // ADD 2010/09/25
                        {
                            // 定価UP率
                            columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Column.Index;
                        }
                        // ---ADD 2010/09/09----------------------<<<
                    }
                    break;
                    #endregion Tab
                case 1:
                    #region Shift + Tab
                    // 売価場合
                    if (this._rateProtyMng.UnitPriceKind == 1)
                    {
                        // ---UPD 2010/09/09---------------------->>>
                        //// 売価率
                        //if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName)
                        //{
                        //    columnIndex = -1;
                        //}
                        // 単独指定
                        //if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName)
                        if (columnKey == this.masterCode)
                        {
                            columnIndex = -1;
                        }
                        // 売価率
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName)
                        {
                            // 単独指定
                            // ---UPD 2010/09/25---------------------->>>
                            //if (this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Activation == Activation.AllowEdit)
                            //{
                            //    columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Column.Index;
                            //}
                            if (this.Detail_uGrid.Rows[rowIndex].Cells[this.masterCode].Activation == Activation.AllowEdit)
                            {
                                columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this.masterCode].Column.Index;
                            }
                            // ---UPD 2010/09/25----------------------<<<
                            else
                            {
                                columnIndex = -1;
                            }
                        }
                        // ---UPD 2010/09/09----------------------<<<
                        // 原価UP率
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName)
                        {
                            // 売価率
                            columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].Column.Index;
                        }
                        // 粗利確保率
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName)
                        {
                            // 原価UP率
                            columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Column.Index;
                        }
                    }
                    // 原価場合
                    else if (this._rateProtyMng.UnitPriceKind == 2)
                    {
                        // ---UPD 2010/09/09---------------------->>>
                        //// 仕入率
                        //if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName)
                        //{
                        //    columnIndex = -1;
                        //}
                        // 単独指定
                        //if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName) // DEL 2010/09/25
                        if (columnKey == this.masterCode) // ADD 2010/09/25
                        {
                            columnIndex = -1;
                        }
                        // 仕入率
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName)
                        {
                            // 単独指定
                            // ---UPD 2010/09/25---------------------->>>
                            //if (this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Activation == Activation.AllowEdit)
                            //{
                            //    columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Column.Index;
                            //}
                            if (this.Detail_uGrid.Rows[rowIndex].Cells[this.masterCode].Activation == Activation.AllowEdit)
                            {
                                columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this.masterCode].Column.Index;
                            }
                            // ---UPD 2010/09/25----------------------<<<
                            else
                            {
                                columnIndex = -1;
                            }
                        }
                        // ---UPD 2010/09/09----------------------<<<
                    }
                    // 価格場合
                    else if (this._rateProtyMng.UnitPriceKind == 3)
                    {
                        // ---UPD 2010/09/09---------------------->>>
                        //// 定価UP率
                        //if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName)
                        //{
                        //    columnIndex = -1;
                        //}
                        // 単独指定
                        //if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName) // DEL 2010/09/25
                        if (columnKey == this.masterCode) // ADD 2010/09/25
                        {
                            columnIndex = -1;
                        }
                        // 定価UP率
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName)
                        {
                            // 単独指定
                            // ---UPD 2010/09/25---------------------->>>
                            //if (this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Activation == Activation.AllowEdit)
                            //{
                            //    columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Column.Index;
                            //}
                            if (this.Detail_uGrid.Rows[rowIndex].Cells[this.masterCode].Activation == Activation.AllowEdit)
                            {
                                columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this.masterCode].Column.Index;
                            }
                            // ---UPD 2010/09/25----------------------<<<
                            else
                            {
                                columnIndex = -1;
                            }
                        }
                        // ---UPD 2010/09/09----------------------<<<
                        // 端数処理単位
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName)
                        {
                            // 定価UP率
                            columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Column.Index;
                        }
                        // 端数処理区分
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName)
                        {
                            // 端数処理単位
                            columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].Column.Index;
                        }
                    }
                    break;
                    #endregion Shift + Tab
            }

            return columnIndex;
        }
        #endregion タブ移動

        /// <summary>
        /// 得意先名称取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note        : 得意先名称を取得します。</br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
        private bool GetCustomerName(int customerCode, out string customerName)
        {
            customerName = "";
            bool check = false;
            try
            {
                CustomerInfo customerInfo;

                int status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
                //if (status == 0) //DEL 2010/09/09
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInfo.LogicalDeleteCode == 0) // ADD 2010/09/09
                {
                    customerName = customerInfo.CustomerSnm.Trim();
                    check = true;
                }
            }
            catch
            {
                customerName = "";
            }

            return check;
        }

        /// <summary>
        /// 仕入先名称取得処理
        /// </summary>
        /// <param name="supplierCode">仕入先コード</param>
        /// <returns>仕入先名称</returns>
        /// <remarks>
        /// <br>Note       : 仕入先名称を取得します。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/08/12</br>
        /// </remarks>
        private string GetSupplierName(int supplierCode)
        {
            string supplierName = "";

            // ----------UPD 2010/09/09----------->>>>>
            //try
            //{
            //    if (this._supplierDic == null)
            //    {
            //        // 仕入先マスタ読込処理
            //        LoadSupplier();
            //    }

            //    if (this._supplierDic.ContainsKey(supplierCode))
            //    {
            //        supplierName = this._supplierDic[supplierCode].SupplierSnm.Trim();
            //    }
            //}
            //catch
            //{
            //    supplierName = "";
            //}

            try
            {
                if (this._supplierDic == null)
                {
                    // 仕入先マスタ読込処理
                    LoadSupplier();
                }

                if (this._supplierDic.ContainsKey(supplierCode))
                {
                    supplierName = this._supplierDic[supplierCode].SupplierSnm.Trim();
                }
            }
            catch
            {
                this._noValueFlg = true;
            }
            // ----------UPD 2010/09/09-----------<<<<<

            return supplierName;
        }

        /// <summary>
        /// 画面新規処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面新規処理します。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/08/12</br>
        /// </remarks>
        /// <returns></returns>
        private bool SaveProc()
        {
            bool saveFlg = true;
            int status = 0;
            // セル編集後に直接ボタンクリックを行なうとセルの編集が発生しないため
            if (this.Detail_uGrid.ActiveCell != null)
            {
                this.Detail_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                if (this._errorFlg)
                {
                    this._errorFlg = true;
                    return false;
                }
            }


            // 保存前チェック
            saveFlg = this.CheckSaveData();

            if (!saveFlg)
            {
                return saveFlg;
            }


            // 保存処理
            string retMessage = string.Empty;
            int mode = 0;
            if (this.Mode_Label.Text == UPDATE_MODE)
            {
                mode = 1;
            }
            status = this._rateProtyMngPatternAcs.WriteRateRelationData(this._rateProtyMng, mode, 0, out retMessage);

            #region < 登録後処理 >
            switch (status)
            {
                #region -- 通常終了 --
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                    // 登録完了ダイアログ表示
                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                    dialog.ShowDialog(2);
                    // 画面を初期化する
                    this.ScreenClear();
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:

                    // コード重複
                    TMsgDisp.Show(
                        this, 									// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO, 			// エラーレベル
                        CT_PGID,				        		// アセンブリＩＤまたはクラスＩＤ
                        //"更新データありません。",  	        // 表示するメッセージ // DEL 2010/09/09
                        "更新対象のデータが存在しません。",     // ADD 2010/09/09
                        0, 										// ステータス値
                        MessageBoxButtons.OK);					// 表示するボタン
                    saveFlg = false;
                    this._checkEmptyFlg = true; // ADD 2010/09/09
                    break;
                // 重複エラー
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    // コード重複
                    TMsgDisp.Show(
                        this, 									// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO, 			// エラーレベル
                        CT_PGID,				        		// アセンブリＩＤまたはクラスＩＤ
                        "このコードは既に使用されています。",  	// 表示するメッセージ
                        0, 										// ステータス値
                        MessageBoxButtons.OK);					// 表示するボタン
                    saveFlg = false;
                    break;
                #endregion

                #region -- 排他制御 --
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    ExclusiveTransaction(status, true);
                    saveFlg = false;
                    break;
                #endregion

                #region -- 登録失敗 --
                default:
                    TMsgDisp.Show(
                        this,                                 // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_STOP,          // エラーレベル
                        CT_PGID,                                // アセンブリＩＤまたはクラスＩＤ
                        CT_PGNM,                                // プログラム名称
                        "SaveProc",                           // 処理名称
                        TMsgDisp.OPE_UPDATE,                  // オペレーション
                        "登録に失敗しました。",               // 表示するメッセージ
                        status,                               // ステータス値
                        this._rateProtyMngPatternAcs,         // エラーが発生したオブジェクト
                        MessageBoxButtons.OK,                 // 表示するボタン
                        MessageBoxDefaultButton.Button1);     // 初期表示ボタン
                    saveFlg = false;
                    break;
                #endregion
            }
            #endregion

            return saveFlg;
        }

        /// <summary>
        /// メーカー名称取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>メーカー名称</returns>
        /// <remarks>
        /// <br>Note       : メーカー名称を取得します。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/08/12</br>
        /// </remarks>
        private bool GetMakerName(int makerCode, out string makerName)
        {
            makerName = "";
            bool check = false;
            // ----------UPD 2010/09/09----------->>>>>
            //try
            //{
            //    if (this._makerUMntDic == null)
            //    {
            //        LoadMakerUMnt();
            //    }

            //    if (this._makerUMntDic.ContainsKey(makerCode))
            //    {
            //        makerName = this._makerUMntDic[makerCode].MakerName.Trim();
            //        check = true;
            //    }
            //}
            //catch
            //{
            //    makerName = "";
            //}

            MakerUMnt makerUMnt;
            int status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, makerCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && makerUMnt != null && makerUMnt.LogicalDeleteCode == 0)
            {
                makerName = makerUMnt.MakerName;
                check = true;
            }
            // ----------UPD 2010/09/09-----------<<<<<

            return check;
        }

        /// <summary>
        /// 仕入先マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入先マスタ読込処理を行います。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/08/12</br>
        /// </remarks>
        private void LoadSupplier()
        {
            this._supplierDic = new Dictionary<int, Supplier>();

            try
            {
                ArrayList retList;

                int status = this._supplierAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (Supplier supplier in retList)
                    {
                        // ----------UPD 2010/09/09----------->>>>>
                        //this._supplierDic.Add(supplier.SupplierCd, supplier);
                        if (supplier.LogicalDeleteCode != 1)
                        {
                            this._supplierDic.Add(supplier.SupplierCd, supplier);
                        }
                        // ----------UPD 2010/09/09-----------<<<<<
                    }
                }
            }
            catch
            {
                this._supplierDic = new Dictionary<int, Supplier>();
            }
        }

        /// <summary>
        /// メーカーマスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : メーカーマスタ読込処理を行います。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/08/12</br>
        /// </remarks>
        private void LoadMakerUMnt()
        {
            this._makerUMntDic = new Dictionary<int, MakerUMnt>();

            try
            {
                ArrayList retList;

                int status = this._makerAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        this._makerUMntDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                    }
                }
            }
            catch
            {
                this._makerUMntDic = new Dictionary<int, MakerUMnt>();
            }
        }

        /// <summary>
		/// 画面閉じる前のチェック
		/// </summary>
        /// <remarks>
        /// <br>Note       : 画面閉じる前のチェック処理します。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/08/12</br>
        /// </remarks>
        /// <returns></returns>
        private bool CloseCheck()
        {
            bool inputStatus = true;
            // セル編集後に直接ボタンクリックを行なうとセルの編集が発生しないため
            if (this.Detail_uGrid.ActiveCell != null)
            {
                this.Detail_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            }

            // グリッドデータありません
            if (this.Detail_uGrid.Rows.Count > 0)
            {
                // グリッドデータが変動する場合
                foreach (UltraGridRow ultraRow in this.Detail_uGrid.Rows)
                {
                    if ((int)ultraRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.SaveFlgColumn.ColumnName].Value == 1)
                    {
                        inputStatus = false;
                        break;
                    }
                }
            }
            return inputStatus;
        }

        /// <summary>
        /// 数値入力チェック処理
        /// </summary>
        /// <param name="keta">桁数(マイナス符号を含まず)</param>
        /// <param name="priod">小数点以下桁数</param>
        /// <param name="prevVal">現在の文字列</param>
        /// <param name="key">入力されたキー値</param>
        /// <param name="selstart">カーソル位置</param>
        /// <param name="sellength">選択文字長</param>
        /// <param name="minusFlg">マイナス入力可？</param>
        /// <returns>true=入力可,false=入力不可</returns>
        /// <remarks>
        /// <br>Note        : 数値の入力チェックを行います。</br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }
            // 数値以外は、ＮＧ
            if (!Char.IsDigit(key))
            {
                // 小数点または、マイナス以外
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }

            // ----------ADD 2010/09/19------->>>
            // 全角数値は、ＮＧ
            if (2 * key.ToString().Length == Encoding.Default.GetByteCount(key.ToString()))
            {
                return false;
            }
            // --------ADD 2010/09/09---------<<<

            // キーが押されたと仮定した場合の文字列を生成する。
            string strResult = "";
            if (sellength > 0)
            {
                strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                strResult = prevVal;
            }

            // マイナスのチェック
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // 小数点のチェック
            if (key == '.')
            {
                if ((priod <= 0) || (strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // キーが押された結果の文字列を生成する。
            strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // 桁数チェック！
            if (strResult.Length > keta)
            {
                if (strResult[0] == '-')
                {
                    if (strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // 小数点以下のチェック
            if (priod > 0)
            {
                // 小数点の位置決定
                int _pointPos = strResult.IndexOf('.');

                // 整数部に入力可能な桁数を決定！
                int _Rketa = (strResult[0] == '-') ? keta - priod : keta - priod - 1;
                // 整数部の桁数をチェック
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // 小数部の桁数をチェック
                if (_pointPos != -1)
                {
                    // 小数部の桁数を計算
                    int _priketa = strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 抽出条件によって、掛率マスタの読み込み処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 抽出条件によって、掛率マスタの読み込みを行います。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/08/12</br>
        /// <br>Update Note : 2010/09/25 朱 猛</br>
        /// <br>            : Redmine#14492対応</br>
        /// </remarks>
        /// <returns></returns>
        private void SearchRateData()
        {
            // オフライン状態チェック
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "画面検索処理に失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            // 入力内容をチェックする
            if (!this.CheckInputScreen())
            {
                return;
            }

            int status = 0;

     // --- DEL 2010/09/10 ---------->>>>>
            //#region 抽出条件取得とCompare
            //if (CompareScreenData() && this.Detail_uGrid.Rows.Count > 0)
            //{
            //    this.Detail_uGrid.Focus();
            //    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
            //    this.InitGridFocus(0, 0);
            //    return;
            //}
     // --- DEL 2010/09/10 ---------->>>>>
            this.ScreenToRateProtyMngPattern(ref this._rateProtyMngPatternWorkClone);
            //#endregion 抽出条件取得とCompare // DEL 2010/09/10

            this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows.Clear();

            // 掛率マスタ込み読み
            ArrayList goodsList = new ArrayList();
            ArrayList rateList = new ArrayList();
            string errMess = string.Empty;
            status = this._rateProtyMngPatternAcs.SearchRateRelationData(_rateProtyMngPatternWorkClone, out goodsList, out rateList, 2, out errMess);

            #region 検索結果
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                if (rateList.Count > 0)
                {
                    // --- UPD 2010/09/10 ---------->>>>>
                    //DialogResult dr = TMsgDisp.Show(
                    //            emErrorLevel.ERR_LEVEL_QUESTION,
                    //            CT_PGID,
                    //            "現在、登録済のデータが存在します\n\n" + "更新してもよいですか？",
                    //            0,
                    //            MessageBoxButtons.YesNo);
                    //switch (dr)
                    //{
                    //    //"いいえ(N)"を押下した場合、新規モードとして、ＢＬコードマスタよりコード、名称を表示
                    //    case DialogResult.No:
                    //        this.Mode_Label.Text = INSERT_MODE;
                    //        this._rateProtyMngPatternAcs.CopyToRateRelationDataSet(goodsList);
                    //        break;
                    //    //"はい(Y)"を押下した場合、更新モードとして登録分データを表示
                    //    case DialogResult.Yes:
                    //if ("1".Equals(_rateProtyMngPatternWorkClone.UnitPriceKind))
                    //{
                    //    rateList.Sort(new RateRlationWork.RateRlationWorkComparer());

                    //    int rateCnt = rateList.Count;

                    //    for (int i = rateList.Count - 1; i > 0; i--)
                    //    {
                    //        rateList.RemoveAt(i);
                    //    }
                    //}
                    this.Mode_Label.Text = UPDATE_MODE;
                    this._rateProtyMngPatternAcs.CopyToRateRelationDataSet(rateList);
                    //break;

                    for (int i = 0; i < rateList.Count; i++)
                    {
                        if (((RateRlationWork)rateList[i]).UpdateLineFlg)
                        {
                            //this.Detail_uGrid.Rows[i].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; // DEL 2010/09/25
                            this.Detail_uGrid.Rows[i].Cells[this.masterCode].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; // ADD 2010/09/25
                        }
                    }
                    //}
                    // --- UPD 2010/09/10 ----------<<<<<
                }
                else
                {
                    this.Mode_Label.Text = INSERT_MODE;
                    this._rateProtyMngPatternAcs.CopyToRateRelationDataSet(goodsList);
                }
                this.Detail_uGrid.Focus();
                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                this.InitGridFocus(0, 0);
                this._initFocusFlag = true; // ADD 2010/09/09
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;// ADD 2010/09/09
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "該当データが存在しません。",
                            0,
                            MessageBoxButtons.OK);
            }
            else
            {
                // エラー時
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Name,
                    errMess,
                    status,
                    MessageBoxButtons.OK);
            }
            #endregion 検索結果
        }

        /// <summary>
        /// 画面抽出条件部データチェック
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面抽出条件部データチェック処理します。</br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
        /// <returns></returns>
        private bool CompareScreenData()
        {
            int custRateGrpCodeZero = this.tNedit_CustRateGrpCodeZero.GetInt();

            if (this.tNedit_CustRateGrpCodeZero.DataText == "")
            {
                custRateGrpCodeZero = -1;
            }
            return ((this.tNedit_CustomerCode.GetInt() == this._rateProtyMngPatternWorkClone.CustomerCode)
                 && (custRateGrpCodeZero == this._rateProtyMngPatternWorkClone.CustRateGrpCode)
                 && (this.tNedit_SupplierCd.GetInt() == this._rateProtyMngPatternWorkClone.SupplierCd)
                 && (this.tNedit_GoodsMakerCd.GetInt() == this._rateProtyMngPatternWorkClone.GoodsMakerCd)
                 && (this.tNedit_BLGloupCode.GetInt() == this._rateProtyMngPatternWorkClone.BlGroupCode)
                 && (this.tNedit_BLGoodsCode.GetInt() == this._rateProtyMngPatternWorkClone.BlGoodsCode)
                 && (this.tNedit_GoodsMGroup.GetInt() == this._rateProtyMngPatternWorkClone.GoodsRateGrpCode));
        }

        /// <summary>
		/// 画面入力チェック
		/// </summary>
        /// <remarks>
        /// <br>Note       : 画面入力チェック処理します。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/08/12</br>
        /// </remarks>
        /// <returns></returns>
        private bool CheckInputScreen()
        {
            bool checkStatus = true;

            if ("1".Equals(this._rateProtyMng.RateMngCustCd.Trim()))
            {
                // 得意先
                if (this.tNedit_CustomerCode.Enabled && this.tNedit_CustomerCode.GetInt() == 0)
                {
                    TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    //"得意先を入力して下さい。", // DEL 2010/09/09
                    "得意先コードを入力して下さい。", // ADD 2010/09/09
                    0,
                    MessageBoxButtons.OK);
                    this.tNedit_CustomerCode.Focus();
                    checkStatus = false;
                    this._checkInputScreenErr = true; // ADD 2010/09/09
                    return checkStatus;
                }
                // ----------ADD 2010/09/09----------->>
                else if (this.tNedit_CustomerCode.Enabled && this.tNedit_CustomerCode.GetInt() != 0 && "".Equals(this.CustomerCodeNm_tEdit.Text))
                {
                    int inputValue = this.tNedit_CustomerCode.GetInt();

                    string name = string.Empty;
                    bool check = GetCustomerName(inputValue, out name);
                    if (check)
                    {
                        this.CustomerCodeNm_tEdit.Text = name;
                        this._prevCustomerCode = inputValue;
                    }
                    else
                    {
                        // エラー時
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "得意先が存在しません。",
                            -1,
                            MessageBoxButtons.OK);

                        // コード戻す
                        this.tNedit_CustomerCode.SetInt(this._prevCustomerCode);
                        this.tNedit_CustomerCode.SelectAll();
                        this._checkInputScreenErr = true;
                        return false;
                    }
                }
                // ----------ADD 2010/09/09-----------<<<

            }
            else if ("3".Equals(this._rateProtyMng.RateMngCustCd.Trim()))
            {  
                // 得意先掛率ｸﾞﾙｰﾌﾟ
                if (this.tNedit_CustRateGrpCodeZero.Enabled && this.tNedit_CustRateGrpCodeZero.DataText.Trim() == "")
                {
                    TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    //"得意先掛率ｸﾞﾙｰﾌﾟを入力して下さい。", // DEL 2010/09/10
                    "得意先掛率グループを入力して下さい。", // ADD 2010/09/10
                    0,
                    MessageBoxButtons.OK);
                    this.tNedit_CustRateGrpCodeZero.Focus();
                    checkStatus = false;
                    this._checkInputScreenErr = true; // ADD 2010/09/09
                    return checkStatus;
                }
                // ----------ADD 2010/09/09----------->>>
                else if (this.tNedit_CustRateGrpCodeZero.Enabled && !"".Equals(this.tNedit_CustRateGrpCodeZero.DataText.Trim()) && "".Equals(this.tEdit_CustRateGrpNm.Text))
                {
                    string name = string.Empty;
                    int inputValue = this.tNedit_CustRateGrpCodeZero.GetInt();
                    bool check = GetCustRateGrpName(inputValue, out name);
                    if (check)
                    {
                        this.tNedit_CustRateGrpCodeZero.DataText = inputValue.ToString("D4");
                        this.tEdit_CustRateGrpNm.Text = name;
                        this._prevCustRateGrpCode = inputValue;
                    }
                    else
                    {
                        // エラー時
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "得意先掛率ｸﾞﾙｰﾌﾟが存在しません。",
                            -1,
                            MessageBoxButtons.OK);

                        // コード戻す
                        if (this._prevCustRateGrpCode == -1)
                        {
                            this.tNedit_CustRateGrpCodeZero.Clear();
                        }
                        else
                        {
                            this.tNedit_CustRateGrpCodeZero.SetInt(this._prevCustRateGrpCode);
                        }
                        this.tNedit_CustRateGrpCodeZero.SelectAll();
                        this._checkInputScreenErr = true;
                        return false;
                    }
                }
                // ----------ADD 2010/09/09-----------<<<
            }
            // ----------ADD 2010/09/09----------->>>
            // 仕入先
            if (this.tNedit_SupplierCd.Enabled && this.tNedit_SupplierCd.GetInt() == 0)
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "仕入先を入力して下さい。",
                0,
                MessageBoxButtons.OK);
                this.tNedit_SupplierCd.Focus();
                checkStatus = false;
                this._checkInputScreenErr = true;
                return checkStatus;
            }
            else if (this.tNedit_SupplierCd.Enabled && this.tNedit_SupplierCd.GetInt() != 0 && "".Equals(this.SupplierCdNm_tEdit.Text))
            {
                int inputValue = this.tNedit_SupplierCd.GetInt();
                string supplierName = GetSupplierName(inputValue);

                if (!this._noValueFlg)
                {
                    this.SupplierCdNm_tEdit.Text = supplierName;
                    this._prevSupplierCode = inputValue;
                }
                else
                {
                    // エラー時
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "仕入先が存在しません。",
                        -1,
                        MessageBoxButtons.OK);

                    // コード戻す
                    this.tNedit_SupplierCd.SetInt(this._prevSupplierCode);
                    this.tNedit_SupplierCd.SelectAll();
                    this._checkInputScreenErr = true;
                    this._noValueFlg = false;
                    return false;
                }
            }
            // ----------ADD 2010/09/09-----------<<<
            return checkStatus;
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
        /// <remarks>
        /// <br>Note       : 画面を排他処理します。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/08/12</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, bool hide)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            CT_PGID, 						        // アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より更新されています。", // 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            CT_PGID, 						        // アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より削除されています。", // 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        break;
                    }
            }
        }

        /// <summary>
        /// 保存前チェック
        /// </summary>
        /// <returns>フラグ</returns>
        /// <remarks>
        /// <br>Note       : 保存前チェック処理を行います。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/08/12</br>
        /// <br>Update Note: 2010/08/31 呉元嘯</br>
        /// <br>           : Redmine#14030対応</br>
        /// </remarks>
        private bool CheckSaveData()
        {
            if (this._rateProtyMngPatternDataSet.RateProtyMngPattern.Count == 0)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "保存対象データが存在しません。",
                    -1,
                    MessageBoxButtons.OK);

                return false;
            }
            // --------ADD 2010/08/31-------->>>>>
            // 価格設定場合
            if (this._rateProtyMng.UnitPriceKind == 3)
            {
                foreach (UltraGridRow ultraRow in this.Detail_uGrid.Rows)
                {
                    bool checkFlg = true;
                    string rowIndexName = string.Empty;
                    // ----------ADD 2010/09/25----------->>>
                    if (ultraRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Value is System.DBNull)
                    {
                        ultraRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Value = 0;
                    }
                    if (ultraRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Value is System.DBNull)
                    {
                        ultraRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Value = 0;
                    }
                    if (ultraRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].Value is System.DBNull)
                    {
                        ultraRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].Value = 1;
                    }
                    // ----------ADD 2010/09/25-----------<<<
                    // ユーザー定価もしくは価格UP率が入力された明細に対して
                    if ((double)ultraRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.PriceFlColumn.ColumnName].Value != 0 ||
                        (double)ultraRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].Value != 0)
                    {
                        // 端数処理単位及び端数処理区分は必須入力チェック
                        if ((double)ultraRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].Value == 0)
                        {
                            checkFlg = false;
                            rowIndexName = "UnPrcFracProcUnit";
                        }
                        //else if ((string)ultraRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Value == string.Empty) // DEL 2010/09/09
                        else if (string.IsNullOrEmpty(ultraRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Value.ToString())) // ADD 2010/09/09
                        {
                            checkFlg = false;
                            rowIndexName = "UnPrcFracProcDivNm";
                            ultraRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Value = "2";
                        }
                    }
                    // --------ADD 2010/09/09-------->>>>>
                    else if (string.IsNullOrEmpty(ultraRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Value.ToString()))
                    {
                        ultraRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Value = "2";
                    }
                    // --------ADD 2010/09/09--------<<<<<
                    if (checkFlg == false)
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           this.Name,
                           "未入力の項目が存在するため、登録できません。",
                           -1,
                           MessageBoxButtons.OK);
                        ultraRow.Cells[rowIndexName].Activate();
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }

                    // --------ADD 2010/09/19--------<<<<<
                    if (this._rateProtyMng.UnitPriceKind == 1 || this._rateProtyMng.UnitPriceKind == 2)
                    {
                        ultraRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName].Value = 0.0;
                        ultraRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Value = "0";
                    }
                    // --------ADD 2010/09/19-------->>>>>
                }
            }
            // --------ADD 2010/08/31--------<<<<<

            // --------ADD 2010/09/09-------->>>>>
            // 明細が入力済みで且つ、未入力項目が有る場合、エラーとする。
            if (!CheckAllZero())
            {
                return false;
            }

            // 明細が入力済みで且つ、同一コードが存在する場合、エラーとする。
            if (!CheckEqual())
            {
                return false;
            }

            // 明細が全て未入力の場合、エラーとする。
            if (!CheckEmpty())
            {
                return false;
            }
            // --------ADD 2010/09/09--------<<<<<
            return true;
        }

        /// <summary>
        /// 行削除処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 行削除処理を行います。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/08/12</br>
        /// <br>Update Note: 2010/09/30 朱 猛</br>
        /// <br>           : Redmine#15703対応</br>
        /// </remarks>
        private void RowDelete()
        {
            int rowIndex = this.GetActiveRowIndex();

            if (rowIndex == -1)
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.Detail_uGrid.BeginUpdate();
                // UPD 2010/09/30  --- >>>
                if ((int)(this.Detail_uGrid.ActiveRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName].Value) == 1)
                {
                    // 行削除時BackColorの設定(通常色)
                    foreach (UltraGridCell cell in this.Detail_uGrid.ActiveRow.Cells)
                    {
                        cell.Appearance.BackColor = Color.Empty;
                        cell.Appearance.BackColor2 = Color.Empty;
                        cell.Appearance.BackColorDisabled = Color.Empty;
                        cell.Appearance.BackColorDisabled2 = Color.Empty;
                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                    }
                    // 行削除フラグ
                    this.Detail_uGrid.ActiveRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName].Value = 0;
                    #region Saveフラグ
                    // 新規場合、行削除データが対象外
                    if (this.Mode_Label.Text == INSERT_MODE)
                    {
                        this.Detail_uGrid.ActiveRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.SaveFlgColumn.ColumnName].Value = 1;
                    }
                    // 更新場合、行削除データが対象
                    else if (this.Mode_Label.Text == UPDATE_MODE)
                    {
                        this.Detail_uGrid.ActiveRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.SaveFlgColumn.ColumnName].Value = 1;
                    }
                    #endregion
                }
                else
                {
                    // 行削除時BackColorの設定(赤色)
                    foreach (UltraGridCell cell in this.Detail_uGrid.ActiveRow.Cells)
                    {
                        cell.Appearance.BackColor = Color.Red;
                        cell.Appearance.BackColor2 = Color.Red;
                        cell.Appearance.BackColorDisabled = Color.Red;
                        cell.Appearance.BackColorDisabled2 = Color.Red;
                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                    }
                    // 行削除フラグ
                    this.Detail_uGrid.ActiveRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName].Value = 1;
                    #region Saveフラグ
                    // 新規場合、行削除データが対象外
                    if (this.Mode_Label.Text == INSERT_MODE)
                    {
                        this.Detail_uGrid.ActiveRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.SaveFlgColumn.ColumnName].Value = 0;
                    }
                    // 更新場合、行削除データが対象
                    else if (this.Mode_Label.Text == UPDATE_MODE)
                    {
                        this.Detail_uGrid.ActiveRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.SaveFlgColumn.ColumnName].Value = 1;
                    }
                    #endregion
                }
                // UPD 2010/09/30  --- <<<

                // セルActivation設定
                //this.SetCellActivation(this.Detail_uGrid.Rows[rowIndex]);  // DEL 2010/09/30
                this.Detail_uGrid.EndUpdate();
            }
            finally
            {
                // UPD 2010/09/30  --- >>>
                this.Cursor = Cursors.Default;
                //DataRow[] dr = this._rateProtyMngPatternDataSet.RateProtyMngPattern.Select("LogicalDeleteCode <> 1");
                //if (dr.Length == 0)
                //{
                //    this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);
                //    Delete_Button.Focus();
                //}
                //else
                //{
                //    if (!MoveNextAllowEditCell(false, 1))
                //    {
                //        //this.InitGridFocus(0, 0);

                //        for (int targetRowIndex = 0; targetRowIndex < this.Detail_uGrid.Rows.Count; targetRowIndex++)
                //        {
                //            //if (this.Detail_uGrid.Rows[targetRowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateRankColumn.ColumnName].Activation == Activation.AllowEdit)
                //            if (this.Detail_uGrid.Rows[targetRowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsNoColumn.ColumnName].Activation == Activation.AllowEdit)
                //            {
                //                //this.Detail_uGrid.Rows[targetRowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateRankColumn.ColumnName].Activate();
                //                this.Detail_uGrid.Rows[targetRowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsNoColumn.ColumnName].Activate();
                //                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                //                break;
                //            }
                //        }
                //    }

                //    this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);
                //    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                //}
                // UPD 2010/09/30  --- <<<
            }
        }

        /// <summary>
        /// ActiveRowインデックス取得処理
        /// </summary>
        /// <returns>ActiveRowインデックス</returns>
        /// <remarks>
        /// <br>Note       : ActiveRowインデックス取得を行います。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/08/12</br>
        /// </remarks>
        private int GetActiveRowIndex()
        {
            if (this.Detail_uGrid.ActiveCell != null)
            {
                return this.Detail_uGrid.ActiveCell.Row.Index;
            }
            else if (this.Detail_uGrid.ActiveRow != null)
            {
                return this.Detail_uGrid.ActiveRow.Index;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// セルActivation設定
        /// </summary>
        /// <remarks>
        /// <br>Note        : 検索時、セル単位の入力許可設定を行う</br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
        private void SetCellActivation(UltraGridRow ultraRow)
        {
            if ((int)ultraRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName].Value == 1)
            {
                foreach (UltraGridCell ultraCell in ultraRow.Cells)
                {
                    ultraCell.Activation = Activation.Disabled;
                }
            }
        }

        #region ◎ オフライン状態チェック処理
        /// <summary>
        /// ログオン時オンライン状態チェック処理
        /// </summary>
        /// <returns>チェック処理結果</returns>
        /// <remarks>
        /// <br>Note       : ログオン時オンライン状態チェック処理を行う。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/08/12</br>
        /// </remarks>
        public static bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ローカルエリア接続状態によるオンライン判定				
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// リモート接続可能判定
        /// </summary>
        /// <returns>判定結果</returns>
        /// <remarks>
        /// <br>Note       : リモート接続可能判定を行う。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/08/12</br>
        /// </remarks>
        private static bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // インターネット接続不能状態
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        /// <summary>
        /// Button_Click イベント(BLGroupGuide_Button)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note	   : BLグループガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/08/12</br>
        /// </remarks>
        private void BLGroupGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                BLGroupU blGroupU = new BLGroupU();

                // BLグループガイド表示
                status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);
                if (status == 0)
                {
                    // ---ADD 2010/09/09---------------------->>>
                    if (this._guideToolClick)
                    {
                        int rowIndex = this.Detail_uGrid.ActiveCell.Row.Index;

                        //((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).BLGroupCode = blGroupU.BLGroupCode;
                        ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).BLGroupCode = blGroupU.BLGroupCode.ToString("D5");
                        ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = blGroupU.BLGroupName.Trim();
                        this.Detail_uGrid.ActiveCell.Activation = Activation.NoEdit;
                        ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                        SetGridTabFocus(ref evt);
                        return;
                    }
                    // ---ADD 2010/09/09----------------------<<<

                    if (blGroupU.BLGroupCode != this._prevBLGroupCode ||
                        this.BLGroupName_tEdit.DataText.Trim() == string.Empty)
                    {
                        this._prevBLGroupCode = blGroupU.BLGroupCode;

                        // BLグループコード
                        this.tNedit_BLGloupCode.SetInt(blGroupU.BLGroupCode);

                        // BLグループ名称
                        this.BLGroupName_tEdit.DataText = blGroupU.BLGroupName.Trim();
                    }

                    // フォーカス設定
                    bool focusCheck = SetFocus(3);
                    if (focusCheck == false)
                    {
                        //SearchRateData();
                        this.Search(); // ADD 2010/09/10
                        // ---ADD 2010/09/09---------------------->>>
                        if (this.Detail_uGrid.Rows.Count != 0 && this._checkInputScreenErr == false && this._errorFlg == false)
                        {
                            //this.tArrowKeyControl1_ChangeFocus(this.BLGroupGuide_Button, new ChangeFocusEventArgs(false, false, false, Keys.Down, this.BLGroupGuide_Button, this.Detail_uGrid)); // DEL 2010/09/25
                            // ---ADD 2010/09/25---------------------->>>
                            // 検索処理をキャンセルする。
                            if (this._searchStatus == 2)
                            {
                                // なし
                            }
                            else
                            {
                                if (this.Mode_Label.Text == INSERT_MODE)
                                {
                                    if (!this._initFocusFlag)
                                    {
                                        this.Detail_uGrid.Focus();
                                        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                        this.Detail_uGrid.Rows[0].Cells[this.masterCode].Activate();
                                        this.InitGridFocus(0, 0);
                                    }
                                    else
                                    {
                                        this._initFocusFlag = false;
                                    }
                                }
                                else
                                {
                                    this.Detail_uGrid.Focus();
                                    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                    this.Detail_uGrid.Rows[0].Cells[this.masterCode].Activate();
                                    ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Space, this.Detail_uGrid, this.Detail_uGrid);
                                    this.SetGridTabFocus(ref evt);
                                }
                            }
                            this._searchStatus = 0;
                            // ---ADD 2010/09/25----------------------<<<
                        }
                        this._errorFlg = false;
                        this._checkInputScreenErr = false;
                        // ---ADD 2010/09/09----------------------<<<
                    }
                }
                // --------ADD 2010/09/09-------->>>
                #region ■ガイド有効無効の設定
                if (this.tNedit_CustomerCode.Focused || this.tNedit_CustRateGrpCodeZero.Focused || this.tNedit_SupplierCd.Focused || this.tNedit_GoodsMakerCd.Focused
                    || this.tNedit_BLGoodsCode.Focused || this.tNedit_GoodsMGroup.Focused || this.tNedit_BLGloupCode.Focused)
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                }
                #endregion
                // --------ADD 2010/09/09--------<<<
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント(GoodsRateGrpGuide_Button)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note	   : 商品掛率Ｇガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/08/12</br>
        /// </remarks>
        private void GoodsRateGrpGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                GoodsGroupU goodsGroupU = new GoodsGroupU();

                // 商品掛率Ｇガイド表示
                status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU, false);
                if (status == 0)
                {
                    // ---ADD 2010/09/09---------------------->>>
                    if (this._guideToolClick)
                    {
                        int rowIndex = this.Detail_uGrid.ActiveCell.Row.Index;

                        //((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).GoodsRateGrpCode = goodsGroupU.GoodsMGroup;
                        ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).GoodsRateGrpCode = goodsGroupU.GoodsMGroup.ToString("D4");
                        ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = goodsGroupU.GoodsMGroupName.Trim();
                        this.Detail_uGrid.ActiveCell.Activation = Activation.NoEdit;
                        ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                        SetGridTabFocus(ref evt);
                        return;
                    }
                    // ---ADD 2010/09/09----------------------<<<

                    if (goodsGroupU.GoodsMGroup != this._prevGoodsRateGrpCode ||
                        this.GoodsRateGrpName_tEdit.DataText.Trim() == string.Empty)
                    {
                        this._prevGoodsRateGrpCode = goodsGroupU.GoodsMGroup;

                        // 商品掛率Ｇコード
                        this.tNedit_GoodsMGroup.SetInt(goodsGroupU.GoodsMGroup);

                        // 商品掛率Ｇ名称
                        this.GoodsRateGrpName_tEdit.DataText = goodsGroupU.GoodsMGroupName.Trim();
                    }

                    // フォーカス設定
                    bool focusCheck = SetFocus(3);
                    if (focusCheck == false)
                    {
                        //SearchRateData();
                        this.Search(); // ADD 2010/09/10
                        // ---ADD 2010/09/09---------------------->>>
                        if (this.Detail_uGrid.Rows.Count != 0 && this._checkInputScreenErr == false && this._errorFlg == false)
                        {
                            //this.tArrowKeyControl1_ChangeFocus(this.GoodsRateGrpGuide_Button, new ChangeFocusEventArgs(false, false, false, Keys.Down, this.GoodsRateGrpGuide_Button, this.Detail_uGrid)); // DEL 2010/09/25
                            // ---ADD 2010/09/25---------------------->>>
                            // 検索処理をキャンセルする。
                            if (this._searchStatus == 2)
                            {
                                // なし
                            }
                            else
                            {
                                if (this.Mode_Label.Text == INSERT_MODE)
                                {
                                    if (!this._initFocusFlag)
                                    {
                                        this.Detail_uGrid.Focus();
                                        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                        this.Detail_uGrid.Rows[0].Cells[this.masterCode].Activate();
                                        this.InitGridFocus(0, 0);
                                    }
                                    else
                                    {
                                        this._initFocusFlag = false;
                                    }
                                }
                                else
                                {
                                    this.Detail_uGrid.Focus();
                                    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                    this.Detail_uGrid.Rows[0].Cells[this.masterCode].Activate();
                                    ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Space, this.Detail_uGrid, this.Detail_uGrid);
                                    this.SetGridTabFocus(ref evt);
                                }
                            }
                            this._searchStatus = 0;
                            // ---ADD 2010/09/25----------------------<<<
                        }
                        this._errorFlg = false;
                        this._checkInputScreenErr = false;
                        // ---ADD 2010/09/09----------------------<<<
                    }
                }
                // --------ADD 2010/09/09-------->>>
                #region ■ガイド有効無効の設定
                if (this.tNedit_CustomerCode.Focused || this.tNedit_CustRateGrpCodeZero.Focused || this.tNedit_SupplierCd.Focused || this.tNedit_GoodsMakerCd.Focused
                    || this.tNedit_BLGoodsCode.Focused || this.tNedit_GoodsMGroup.Focused || this.tNedit_BLGloupCode.Focused)
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                }
                #endregion
                // --------ADD 2010/09/09--------<<<
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント(BLGoodsGuide_Button)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note	   : BLコードガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/08/12</br>
        /// </remarks>
        private void BLGoodsGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                BLGoodsCdUMnt blGoodsCdUMnt = new BLGoodsCdUMnt();

                // BLコードガイド表示
                status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);
                if (status == 0)
                {
                    // ---ADD 2010/09/09---------------------->>>
                    if (this._guideToolClick)
                    {
                        int rowIndex = this.Detail_uGrid.ActiveCell.Row.Index;

                        //((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).BLGoodsCode = blGoodsCdUMnt.BLGoodsCode;
                        ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).BLGoodsCode = blGoodsCdUMnt.BLGoodsCode.ToString("D5");
                        ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = blGoodsCdUMnt.BLGoodsHalfName.Trim();
                        this.Detail_uGrid.ActiveCell.Activation = Activation.NoEdit;
                        ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                        SetGridTabFocus(ref evt);
                        return;
                    }
                    // ---ADD 2010/09/09----------------------<<<

                    if (blGoodsCdUMnt.BLGoodsCode != this._prevBLGoodsCode ||
                        this.BLGoodsName_tEdit.DataText.Trim() == string.Empty)
                    {
                        this._prevBLGoodsCode = blGoodsCdUMnt.BLGoodsCode;

                        // BLコード
                        this.tNedit_BLGoodsCode.SetInt(blGoodsCdUMnt.BLGoodsCode);

                        // BLコード名称
                        this.BLGoodsName_tEdit.DataText = blGoodsCdUMnt.BLGoodsHalfName.Trim();
                    }

                    // フォーカス設定
                    bool focusCheck = SetFocus(3);
                    if (focusCheck == false)
                    {
                        //SearchRateData();
                        this.Search(); // ADD 2010/09/10
                        // ---ADD 2010/09/09---------------------->>>
                        if (this.Detail_uGrid.Rows.Count != 0 && this._checkInputScreenErr == false && this._errorFlg == false)
                        {
                            //this.tArrowKeyControl1_ChangeFocus(this.BLGoodsGuide_Button, new ChangeFocusEventArgs(false, false, false, Keys.Down, this.BLGoodsGuide_Button, this.Detail_uGrid)); // DEL 2010/09/25
                            // ---ADD 2010/09/25---------------------->>>
                            // 検索処理をキャンセルする。
                            if (this._searchStatus == 2)
                            {
                                // なし
                            }
                            else
                            {
                                if (this.Mode_Label.Text == INSERT_MODE)
                                {
                                    if (!this._initFocusFlag)
                                    {
                                        this.Detail_uGrid.Focus();
                                        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                        this.Detail_uGrid.Rows[0].Cells[this.masterCode].Activate();
                                        this.InitGridFocus(0, 0);
                                    }
                                    else
                                    {
                                        this._initFocusFlag = false;
                                    }
                                }
                                else
                                {
                                    this.Detail_uGrid.Focus();
                                    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                    this.Detail_uGrid.Rows[0].Cells[this.masterCode].Activate();
                                    ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Space, this.Detail_uGrid, this.Detail_uGrid);
                                    this.SetGridTabFocus(ref evt);
                                }
                            }
                            this._searchStatus = 0;
                            // ---ADD 2010/09/25----------------------<<<
                        }
                        this._errorFlg = false;
                        this._checkInputScreenErr = false;
                        // ---ADD 2010/09/09----------------------<<<
                    }
                }
                // --------ADD 2010/09/09-------->>>
                #region ■ガイド有効無効の設定
                if (this.tNedit_CustomerCode.Focused || this.tNedit_CustRateGrpCodeZero.Focused || this.tNedit_SupplierCd.Focused || this.tNedit_GoodsMakerCd.Focused
                    || this.tNedit_BLGoodsCode.Focused || this.tNedit_GoodsMGroup.Focused || this.tNedit_BLGloupCode.Focused)
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                }
                #endregion
                // --------ADD 2010/09/09--------<<<
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// BLコードマスタ読込処理
        /// </summary>
        private void LoadBLGoodsCdUMnt()
        {
            this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();

            try
            {
                ArrayList retList;

                int status = this._blGoodsCdAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGoodsCdUMnt blGoodsCdUMnt in retList)
                    {
                        if (blGoodsCdUMnt.LogicalDeleteCode == 0)
                        {
                            this._blGoodsCdUMntDic.Add(blGoodsCdUMnt.BLGoodsCode, blGoodsCdUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();
            }
        }

        /// <summary>
        /// BLコード名称取得処理
        /// </summary>
        /// <param name="blGoodsCode">BLコード</param>
        /// <returns>BLコード名称</returns>
        /// <remarks>
        /// <br>Note       : BLコード名称を取得します。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/08/12</br>
        /// </remarks>
        private string GetBLGoodsName(int blGoodsCode)
        {
            string blGoodsName = "";

            try
            {
                if (_blGoodsCdUMntDic == null)
                {
                    LoadBLGoodsCdUMnt();
                }

                if (this._blGoodsCdUMntDic.ContainsKey(blGoodsCode))
                {
                    blGoodsName = this._blGoodsCdUMntDic[blGoodsCode].BLGoodsHalfName.Trim();
                }
            }
            catch
            {
                blGoodsName = "";
            }

            return blGoodsName;
        }

        /// <summary>
        /// 商品掛率Ｇマスタ読込処理
        /// </summary>
        private void LoadGoodsGroupU()
        {
            this._goodsGroupUDic = new Dictionary<int, GoodsGroupU>();

            try
            {
                ArrayList retList;

                int status = this._goodsGroupUAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (GoodsGroupU goodsGroupU in retList)
                    {
                        if (goodsGroupU.LogicalDeleteCode == 0)
                        {
                            this._goodsGroupUDic.Add(goodsGroupU.GoodsMGroup, goodsGroupU);
                        }
                    }
                }
            }
            catch
            {
                this._goodsGroupUDic = new Dictionary<int, GoodsGroupU>();
            }
        }
        /// <summary>
        /// 商品掛率Ｇ名称取得処理
        /// </summary>
        /// <param name="goodsMGroupCode">商品掛率Ｇコード</param>
        /// <returns>商品掛率Ｇ名称</returns>
        /// <remarks>
        /// <br>Note       : 商品掛率Ｇ名称を取得します。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/08/12</br>
        /// </remarks>
        private string GetGoodsMGroupName(int goodsMGroupCode)
        {
            string goodsMGroupName = "";

            try
            {
                if (_goodsGroupUDic == null)
                {
                    LoadGoodsGroupU();
                }

                if (this._goodsGroupUDic.ContainsKey(goodsMGroupCode))
                {
                    goodsMGroupName = this._goodsGroupUDic[goodsMGroupCode].GoodsMGroupName.Trim();
                }
            }
            catch
            {
                goodsMGroupName = "";
            }

            return goodsMGroupName;
        }

        /// <summary>
        /// グループコードマスタ読込処理
        /// </summary>
        private void LoadBLGroupU()
        {
            this._blGroupUDic = new Dictionary<int, BLGroupU>();

            try
            {
                ArrayList retList;

                int status = this._blGroupUAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGroupU blGroupU in retList)
                    {
                        if (blGroupU.LogicalDeleteCode == 0)
                        {
                            this._blGroupUDic.Add(blGroupU.BLGroupCode, blGroupU);
                        }
                    }
                }
            }
            catch
            {
                this._blGroupUDic = new Dictionary<int, BLGroupU>();
            }
        }

        /// <summary>
        /// BLグループ名称取得処理
        /// </summary>
        /// <param name="blGroupCode">BLグループコード</param>
        /// <returns>BLグループ名称</returns>
        /// <remarks>
        /// <br>Note       : BLグループ名称を取得します。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/08/12</br>
        /// </remarks>
        private string GetBLGroupName(int blGroupCode)
        {
            string blGroupName = "";

            try
            {
                if (_goodsGroupUDic == null)
                {
                    LoadBLGroupU();
                }

                if (this._blGroupUDic.ContainsKey(blGroupCode))
                {
                    blGroupName = this._blGroupUDic[blGroupCode].BLGroupName.Trim();
                }
            }
            catch
            {
                blGroupName = "";
            }

            return blGroupName;
        }

        /// <summary>
        /// Enter イベント(tNedit_CustRateGrpCode)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: テキストボックスがアクティブになったときに発生します。</br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date        : 2010/08/12</br>
        /// </remarks>
        private void tNedit_CustRateGrpCodeAllowZero_Enter(object sender, EventArgs e)
        {
            if (this.tNedit_CustRateGrpCodeZero.DataText.Trim() == "")
            {
                return;
            }

            int custRateGrpCode = this.tNedit_CustRateGrpCodeZero.GetInt();

            this.tNedit_CustRateGrpCodeZero.SetInt(custRateGrpCode);
            this.tNedit_CustRateGrpCodeZero.SelectAll();
        }

        /// <summary>
        /// 画面情報データを格納処理
        /// </summary>
        /// <param name="rateProtyMngPatternWork">抽出条件</param>
        /// <remarks>
        /// <br>Note        : 画面情報データを格納します。</br>
        /// <br>Programmer  : 楊明俊</br>
        /// <br>Date        : 2010/08/23</br>
        /// </remarks>
        private void ScreenToRateProtyMngPattern(ref RateProtyMngPatternWork rateProtyMngPatternWork)
        {
            rateProtyMngPatternWork.CustomerCode = this.tNedit_CustomerCode.GetInt();

            if (this.tNedit_CustRateGrpCodeZero.DataText == "")
            {
                rateProtyMngPatternWork.CustRateGrpCode = -1;
            }
            else
            {
                rateProtyMngPatternWork.CustRateGrpCode = this.tNedit_CustRateGrpCodeZero.GetInt();
            }
            rateProtyMngPatternWork.SupplierCd = this.tNedit_SupplierCd.GetInt();
            rateProtyMngPatternWork.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            rateProtyMngPatternWork.SectionCode = this._rateProtyMng.SectionCode.Trim();
            rateProtyMngPatternWork.UnitPriceKind = this._rateProtyMng.UnitPriceKind.ToString();
            rateProtyMngPatternWork.RateSettingDivide = this._rateProtyMng.RateSettingDivide.Trim();
            rateProtyMngPatternWork.EnterpriseCode = this._enterpriseCode;
            rateProtyMngPatternWork.BlGoodsCode = this.tNedit_BLGoodsCode.GetInt();
            rateProtyMngPatternWork.BlGroupCode = this.tNedit_BLGloupCode.GetInt();
            rateProtyMngPatternWork.GoodsRateGrpCode = this.tNedit_GoodsMGroup.GetInt();
        }

        /// <summary>
        /// 仕入先存在チェック処理
        /// </summary>
        /// <param name="supplierCode">仕入先コード</param>
        /// <returns>true：OK、false：NG</returns>
        /// <remarks>
        /// <br>Note       : 仕入先が存在するかチェックします。</br>
        /// <br></br>
        /// </remarks>
        private bool CheckSupplier(int supplierCode)
        {
            bool check = false;

            try
            {
                if (this._supplierDic.ContainsKey(supplierCode))
                {
                    check = true;
                }
            }
            catch
            {
                check = false;
            }

            return check;
        }

        // --- ADD 2010/09/10 ---------->>>>>
        /// <summary>
        /// 抽出条件によって、掛率マスタの読み込み処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 抽出条件によって、掛率マスタの読み込みを行います。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/09/10</br>
        /// </remarks>
        /// <returns></returns>
        private void Search()
        {
            bool inputStatus = true;

            if (this.Detail_uGrid.ActiveCell != null)
            {
                this.Detail_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                if (this._errorFlg)
                {
                    return;
                }
            }

            // グリッドデータありません
            if (this.Detail_uGrid.Rows.Count > 0)
            {
                // グリッドデータが変動する場合
                foreach (UltraGridRow ultraRow in this.Detail_uGrid.Rows)
                {
                    if ((int)ultraRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.SaveFlgColumn.ColumnName].Value == 1)
                    {
                        inputStatus = false;
                        break;
                    }
                }
            }

            if (!inputStatus)
            {
                DialogResult dr = TMsgDisp.Show(
                                emErrorLevel.ERR_LEVEL_QUESTION,
                                CT_PGID,
                                "現在、編集中のデータが存在します\n\n" + "登録してもよろしいですか？",
                                0,
                                MessageBoxButtons.YesNoCancel);

                switch (dr)
                {
                    case DialogResult.Yes:
                        {
                            this._searchAfterSaveFlg = true;
                            if (this.SaveProc())
                            {
                                this.InsertCondition();
                                this.SearchRateData();
                                this._searchAfterSaveFlg = false;
                            }
                            break;
                        }
                    case DialogResult.No:
                        {
                            this._searchStatus = 1; // ADD 2010/09/25
                            this.SearchRateData();
                            break;
                        }
                    case DialogResult.Cancel:
                        {
                            this._searchStatus = 2; // ADD 2010/09/25
                            if (_prevIndexRow >= 0 && _prevIndexColumn >= 0)
                            {
                                this.Detail_uGrid.Rows[_prevIndexRow].Cells[_prevIndexColumn].Activate();
                                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                if (this.Detail_uGrid.Rows[_prevIndexRow].Cells[_prevIndexColumn].CanEnterEditMode)
                                {
                                    this.Detail_uGrid.Rows[_prevIndexRow].Cells[_prevIndexColumn].SelectAll();
                                }
                            }
                            break;
                        }
                    case DialogResult.Ignore:
                        {
                            break;
                        }
                }
            }
            else
            {
                this.SearchRateData();
            }
        }

        /// <summary>
        /// 全削除ボタンクリックイベント
        /// </summary>
        /// <remarks>
        /// <br>Note        : 全削除処理を行います。</br>
        /// <br>Programmer  : 朱 猛</br>
        /// <br>Date        : 2010/09/10</br>
        /// <br>Update Note : 2010/09/25 朱 猛</br>
        /// <br>            : Redmine#14492対応</br>
        /// <br>Update Note : 2010/09/30 朱 猛</br>
        /// <br>            : Redmine#15703対応</br>
        /// </remarks>
        private void AllRowDelete()
        {
            // 削除対象かどうかチェック用変数
            // メーカーコード
            //string goodsMakerCdColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName; // DEL 2010/09/25
            string goodsMakerCdColumn = this.masterCode; // ADD 2010/09/25
            // 売価率
            string rateValColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName;
            // 原価UP率
            string upRateColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName;
            // 粗利確保率
            string grsProfitSecureRateColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName;
            // 端数処理単位
            string unPrcFracProcUnitColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName;
            // 端数処理区分
            string unPrcFracProcDivNmColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName;


            if (this.Detail_uGrid.Rows.Count == 0)
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.Detail_uGrid.BeginUpdate();
                foreach (UltraGridRow row in this.Detail_uGrid.Rows)
                {
                    // 削除対象かどうかチェック
                    if (this._rateProtyMng.UnitPriceKind == 1)
                    {
                        if ((row.Cells[goodsMakerCdColumn].Activation == Activation.AllowEdit) &&
                            (double)row.Cells[rateValColumn].Value == 0 &&
                            (double)row.Cells[upRateColumn].Value == 0 &&
                            (double)row.Cells[grsProfitSecureRateColumn].Value == 0)
                        {
                            continue;
                        }
                    }
                    else if (this._rateProtyMng.UnitPriceKind == 2)
                    {
                        if ((row.Cells[goodsMakerCdColumn].Activation == Activation.AllowEdit) &&
                            (double)row.Cells[rateValColumn].Value == 0)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if ((row.Cells[goodsMakerCdColumn].Activation == Activation.AllowEdit) &&
                            (double)row.Cells[upRateColumn].Value == 0 &&
                            (double)row.Cells[unPrcFracProcUnitColumn].Value == 1 &&
                            "2".Equals(row.Cells[unPrcFracProcDivNmColumn].Value.ToString()))
                        {
                            continue;
                        }
                    }
                    // 行削除フラグ
                    row.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName].Value = 1;

                    // 全削除時BackColorの設定(赤色)
                    foreach (UltraGridCell cell in row.Cells)
                    {
                        cell.Appearance.BackColor = Color.Red;
                        cell.Appearance.BackColor2 = Color.Red;
                        cell.Appearance.BackColorDisabled = Color.Red;
                        cell.Appearance.BackColorDisabled2 = Color.Red;
                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                    }

                    #region Saveフラグ
                    // 新規場合、行削除データが対象外
                    if (this.Mode_Label.Text == INSERT_MODE)
                    {
                        row.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.SaveFlgColumn.ColumnName].Value = 0;
                    }
                    // 更新場合、行削除データが対象
                    else if (this.Mode_Label.Text == UPDATE_MODE)
                    {
                        row.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.SaveFlgColumn.ColumnName].Value = 1;
                    }
                    #endregion

                    // セルActivation設定
                    //this.SetCellActivation(row);  // DEL 2010/09/30
                }

                this.Detail_uGrid.EndUpdate();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ガイド処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : ガイド処理を行います。</br>
        /// <br>Programmer  : 朱 猛</br>
        /// <br>Date        : 2010/09/10</br>
        /// </remarks>
        private void ExcuteGuide()
        {
            #region
            this._gridGuideFlag = true; // ADD 2010/09/25
            if (this.Detail_uGrid.ActiveCell.Activation == Activation.AllowEdit) this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode); // ADD 2010/09/25
            this._gridGuideFlag = false; // ADD 2010/09/25
            string rateSettingDivide = this._rateProtyMng.RateMngCustCd.Trim() + this._rateProtyMng.RateMngGoodsCd.Trim();
            switch (rateSettingDivide)
            {
                case "2L": // 掛率設定区分=2L　得意先の場合
                    {
                        this.CustomerGuide_Button_Click(this.CustomerGuide_Button, new EventArgs());
                        break;
                    }
                case "4L": // 掛率設定区分=4L　得意先掛率グループの場合
                    {
                        this.CustRateGrpGuide_Button_Click(this.CustRateGrpGuide_Button, new EventArgs());
                        break;
                    }
                case "1L":
                case "3L":
                case "5L": // 掛率設定区分=1L,3L,5L　仕入先の場合
                    {
                        this.SupplierGuide_Button_Click(this.SupplierGuide_Button, new EventArgs());
                        break;
                    }
                case "6H": // 掛率設定区分=6H　BLｺｰﾄﾞの場合
                    {
                        this.BLGoodsGuide_Button_Click(this.BLGoodsGuide_Button, new EventArgs());
                        break;
                    }
                case "6I": // 掛率設定区分=6I　ｸﾞﾙｰﾌﾟｺｰﾄﾞの場合
                    {
                        this.BLGroupGuide_Button_Click(this.BLGroupGuide_Button, new EventArgs());
                        break;
                    }
                case "6J": // 掛率設定区分=6J　中分類の場合
                    {
                        this.GoodsRateGrpGuide_Button_Click(this.GoodsRateGrpGuide_Button, new EventArgs());
                        break;
                    }
                case "6K": // 掛率設定区分=6K　メーカーの場合
                    {
                        this.MakerGuide_Button_Click(this.MakerGuide_Button, new EventArgs());
                        break;
                    }
            }
            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode); // ADD 2010/09/25
            this._guideToolClick = false;
            #endregion
        }

        /// <summary>
        /// 明細が入力済みで且つ、未入力項目が有る場合
        /// </summary>
        /// <param name=""></param>
        /// <remarks>
        /// <br>Note        : 明細が入力済みで且つ、未入力項目が有る場合</br>
        /// <br>Programmer  :朱 猛</br>
        /// <br>Date        : 2010/09/09</br>
        /// <br>Update Note : 2010/09/25 朱 猛</br>
        /// <br>            : Redmine#14492対応</br>
        /// </remarks>
        private bool CheckAllZero()
        {
            bool checkFlg = true;
            string rowIndexName = string.Empty;
            // 単独指定
            //string masterNmColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName; // DEL 2010/09/25
            string masterNmColumn = this.masterCode; // ADD 2010/09/25
            // 売価率
            string rateValColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName;
            // 原価UP率
            string upRateColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName;
            // 粗利確保率
            string grsProfitSecureRateColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName;
            // 端数処理単位
            string unPrcFracProcUnitColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName;
            // 端数処理区分
            string unPrcFracProcDivNmColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName;
            // 行削除フラグ
            string logicalDeleteCodeColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName;

            if (this._rateProtyMng.UnitPriceKind == 1)
            {
                foreach (UltraGridRow ultraRow in this.Detail_uGrid.Rows)
                {
                    //if (!string.IsNullOrEmpty(ultraRow.Cells[masterNmColumn].Value.ToString()) && (int)ultraRow.Cells[logicalDeleteCodeColumn].Value == 0) // DEL 2010/09/25
                    if (!string.IsNullOrEmpty(ultraRow.Cells[masterNmColumn].Text) && (int)ultraRow.Cells[logicalDeleteCodeColumn].Value == 0) // ADD 2010/09/25
                    {
                        // ----------ADD 2010/09/25----------->>>
                        if (ultraRow.Cells[rateValColumn].Value is System.DBNull)
                        {
                            ultraRow.Cells[rateValColumn].Value = 0;
                        }
                        if (ultraRow.Cells[upRateColumn].Value is System.DBNull)
                        {
                            ultraRow.Cells[upRateColumn].Value = 0;
                        }
                        if (ultraRow.Cells[grsProfitSecureRateColumn].Value is System.DBNull)
                        {
                            ultraRow.Cells[grsProfitSecureRateColumn].Value = 0;
                        }
                        // ----------ADD 2010/09/25-----------<<<
                        if ((double)ultraRow.Cells[rateValColumn].Value == 0 &&
                            (double)ultraRow.Cells[upRateColumn].Value == 0 &&
                            (double)ultraRow.Cells[grsProfitSecureRateColumn].Value == 0)
                        {
                            rowIndexName = rateValColumn;
                            checkFlg = false;
                        }
                    }
                    //else if (string.IsNullOrEmpty(ultraRow.Cells[masterNmColumn].Value.ToString()) && (int)ultraRow.Cells[logicalDeleteCodeColumn].Value == 0) // DEL 2010/09/25
                    else if (string.IsNullOrEmpty(ultraRow.Cells[masterNmColumn].Text) && (int)ultraRow.Cells[logicalDeleteCodeColumn].Value == 0) // ADD 2010/09/25
                    {
                        // ----------ADD 2010/09/25----------->>>
                        if (ultraRow.Cells[rateValColumn].Value is System.DBNull)
                        {
                            ultraRow.Cells[rateValColumn].Value = 0;
                        }
                        if (ultraRow.Cells[upRateColumn].Value is System.DBNull)
                        {
                            ultraRow.Cells[upRateColumn].Value = 0;
                        }
                        if (ultraRow.Cells[grsProfitSecureRateColumn].Value is System.DBNull)
                        {
                            ultraRow.Cells[grsProfitSecureRateColumn].Value = 0;
                        }
                        // ----------ADD 2010/09/25-----------<<<
                        if (((double)ultraRow.Cells[rateValColumn].Value != 0) ||
                        ((double)ultraRow.Cells[upRateColumn].Value != 0) ||
                        ((double)ultraRow.Cells[grsProfitSecureRateColumn].Value != 0))
                        {
                            rowIndexName = masterNmColumn;
                            checkFlg = false;
                        }
                    }
                    if (checkFlg == false)
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           this.Name,
                           "未入力の項目が存在するため、登録できません。",
                           -1,
                           MessageBoxButtons.OK);
                        ultraRow.Cells[rowIndexName].Activate();
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }
                }
            }
            else if (this._rateProtyMng.UnitPriceKind == 2)
            {
                foreach (UltraGridRow ultraRow in this.Detail_uGrid.Rows)
                {
                    // ----------ADD 2010/09/25----------->>>
                    if (ultraRow.Cells[rateValColumn].Value is System.DBNull)
                    {
                        ultraRow.Cells[rateValColumn].Value = 0;
                    }
                    // ----------ADD 2010/09/25-----------<<<
                    //if (!string.IsNullOrEmpty(ultraRow.Cells[masterNmColumn].Value.ToString()) && (int)ultraRow.Cells[logicalDeleteCodeColumn].Value == 0) // DEL 2010/09/25
                    if (!string.IsNullOrEmpty(ultraRow.Cells[masterNmColumn].Text) && (int)ultraRow.Cells[logicalDeleteCodeColumn].Value == 0) // ADD 2010/09/25
                    {
                        if ((double)ultraRow.Cells[rateValColumn].Value == 0)
                        {
                            rowIndexName = rateValColumn;
                            checkFlg = false;
                        }
                    }
                    //else if (string.IsNullOrEmpty(ultraRow.Cells[masterNmColumn].Value.ToString()) && (int)ultraRow.Cells[logicalDeleteCodeColumn].Value == 0) // DEL 2010/09/25
                    else if (string.IsNullOrEmpty(ultraRow.Cells[masterNmColumn].Text) && (int)ultraRow.Cells[logicalDeleteCodeColumn].Value == 0) // ADD 2010/09/25
                    {
                        if ((double)ultraRow.Cells[rateValColumn].Value != 0)
                        {
                            rowIndexName = masterNmColumn;
                            checkFlg = false;
                        }
                    }
                    if (checkFlg == false)
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           this.Name,
                           "未入力の項目が存在するため、登録できません。",
                           -1,
                           MessageBoxButtons.OK);
                        ultraRow.Cells[rowIndexName].Activate();
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }
                }
            }
            else
            {
                foreach (UltraGridRow ultraRow in this.Detail_uGrid.Rows)
                {
                    // ----------ADD 2010/09/25----------->>>
                    if (ultraRow.Cells[upRateColumn].Value is System.DBNull)
                    {
                        ultraRow.Cells[upRateColumn].Value = 0;
                    }
                    // ----------ADD 2010/09/25-----------<<<
                    //if (!string.IsNullOrEmpty(ultraRow.Cells[masterNmColumn].Value.ToString()) && (int)ultraRow.Cells[logicalDeleteCodeColumn].Value == 0) // DEL 2010/09/25
                    if (!string.IsNullOrEmpty(ultraRow.Cells[masterNmColumn].Text) && (int)ultraRow.Cells[logicalDeleteCodeColumn].Value == 0) // ADD 2010/09/25
                    {
                        if ((double)ultraRow.Cells[upRateColumn].Value == 0)
                        {
                            rowIndexName = upRateColumn;
                            checkFlg = false;
                        }
                    }
                    //else if (string.IsNullOrEmpty(ultraRow.Cells[masterNmColumn].Value.ToString()) && (int)ultraRow.Cells[logicalDeleteCodeColumn].Value == 0) // DEL 2010/09/25
                    else if (string.IsNullOrEmpty(ultraRow.Cells[masterNmColumn].Text) && (int)ultraRow.Cells[logicalDeleteCodeColumn].Value == 0) // ADD 2010/09/25
                    {
                        if ((double)ultraRow.Cells[upRateColumn].Value != 0)
                        {
                            rowIndexName = masterNmColumn;
                            checkFlg = false;
                        }
                    }
                    if (checkFlg == false)
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           this.Name,
                           "未入力の項目が存在するため、登録できません。",
                           -1,
                           MessageBoxButtons.OK);
                        ultraRow.Cells[rowIndexName].Activate();
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 明細が入力済みで且つ、同一コードが存在する場合
        /// </summary>
        /// <param name=""></param>
        /// <remarks>
        /// <br>Note        : 明細が入力済みで且つ、同一コードが存在する場合</br>
        /// <br>Programmer  :朱 猛</br>
        /// <br>Date        : 2010/09/09</br>
        /// <br>Update Note : 2010/09/25 朱 猛</br>
        /// <br>            : Redmine#14492対応</br>
        /// </remarks>
        private bool CheckEqual()
        {
            // 明細が入力済みで且つ、同一コードが存在する場合、エラー項目へフォーカスを移動し、エラーとする。
            //string rowName = this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName; // DEL 2010/09/25
            string rowName = this.masterCode; // ADD 2010/09/25
            // 行削除フラグ
            string logicalDeleteCodeColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName;

            for (int i = 0; i < this.Detail_uGrid.Rows.Count; i++)
            {
                //if (!string.IsNullOrEmpty(this.Detail_uGrid.Rows[i].Cells[rowName].Value.ToString()) && (int)this.Detail_uGrid.Rows[i].Cells[logicalDeleteCodeColumn].Value == 0) // DEL 2010/09/25
                if (!string.IsNullOrEmpty(this.Detail_uGrid.Rows[i].Cells[rowName].Text) && (int)this.Detail_uGrid.Rows[i].Cells[logicalDeleteCodeColumn].Value == 0) // ADD 2010/09/25
                {
                    this.Detail_uGrid.Rows[i].Cells[rowName].Activate();
                    //DataRow[] dr = this._rateProtyMngPatternDataSet.RateProtyMngPattern.Select("MasterNm = '" + this.Detail_uGrid.Rows[i].Cells[rowName].Value.ToString() + "' AND LogicalDeleteCode = 0"); // DEL 2010/09/25
                    DataRow[] dr = this._rateProtyMngPatternDataSet.RateProtyMngPattern.Select(rowName + " = '" + this.Detail_uGrid.Rows[i].Cells[rowName].Value.ToString() + "' AND LogicalDeleteCode = 0"); // ADD 2010/09/25
                    if (dr.Length > 1)
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           this.Name,
                           "同一コードが存在するため、登録できません。",
                           -1,
                           MessageBoxButtons.OK);
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 明細が全て未入力の場合、エラーとする。
        /// </summary>
        /// <param name=""></param>
        /// <remarks>
        /// <br>Note        : 明細が全て未入力の場合、エラーとする。</br>
        /// <br>Programmer  :朱 猛</br>
        /// <br>Date        : 2010/09/09</br>
        /// <br>Update Note : 2010/09/25 朱 猛</br>
        /// <br>            : Redmine#14492対応</br>
        /// </remarks>
        private bool CheckEmpty()
        {
            string rowIndexName = string.Empty;
            // 単独指定
            //string goodsMakerCdColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName; // DEL 2010/09/25
            string goodsMakerCdColumn = this.masterCode; // ADD 2010/09/25
            // 売価率
            string rateValColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName;
            // 原価UP率
            string upRateColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName;
            // 粗利確保率
            string grsProfitSecureRateColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName;
            // 端数処理単位
            string unPrcFracProcUnitColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName;
            // 端数処理区分
            string unPrcFracProcDivNmColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName;

            if (this._rateProtyMng.UnitPriceKind == 1)
            {
                int count = 0;
                foreach (UltraGridRow ultraRow in this.Detail_uGrid.Rows)
                {
                    //if (string.IsNullOrEmpty(ultraRow.Cells[goodsMakerCdColumn].Value.ToString()) && // DEL 2010/09/25
                    if (string.IsNullOrEmpty(ultraRow.Cells[goodsMakerCdColumn].Text) && // ADD 2010/09/25
                        (double)ultraRow.Cells[rateValColumn].Value == 0 &&
                        (double)ultraRow.Cells[upRateColumn].Value == 0 &&
                        (double)ultraRow.Cells[grsProfitSecureRateColumn].Value == 0)
                    {
                        count++;
                    }
                    if (count == this.Detail_uGrid.Rows.Count)
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           this.Name,
                           "更新対象のデータが存在しません。",
                           -1,
                           MessageBoxButtons.OK);
                        this.Detail_uGrid.Rows[0].Cells[goodsMakerCdColumn].Activate();
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }
                }
            }
            else if (this._rateProtyMng.UnitPriceKind == 2)
            {
                int count = 0;
                foreach (UltraGridRow ultraRow in this.Detail_uGrid.Rows)
                {
                    //if (string.IsNullOrEmpty(ultraRow.Cells[goodsMakerCdColumn].Value.ToString()) && // DEL 2010/09/25
                    if (string.IsNullOrEmpty(ultraRow.Cells[goodsMakerCdColumn].Text) && // ADD 2010/09/25
                        (double)ultraRow.Cells[rateValColumn].Value == 0)
                    {
                        count++;
                    }
                    if (count == this.Detail_uGrid.Rows.Count)
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           this.Name,
                           "更新対象のデータが存在しません。",
                           -1,
                           MessageBoxButtons.OK);
                        this.Detail_uGrid.Rows[0].Cells[goodsMakerCdColumn].Activate();
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }
                }
            }
            else
            {
                int count = 0;
                foreach (UltraGridRow ultraRow in this.Detail_uGrid.Rows)
                {
                    //if (string.IsNullOrEmpty(ultraRow.Cells[goodsMakerCdColumn].Value.ToString()) && // DEL 2010/09/25
                    if (string.IsNullOrEmpty(ultraRow.Cells[goodsMakerCdColumn].Text) && // ADD 2010/09/25
                        (double)ultraRow.Cells[rateValColumn].Value == 0 &&
                        (double)ultraRow.Cells[unPrcFracProcUnitColumn].Value == 0 &&
                        string.IsNullOrEmpty(ultraRow.Cells[unPrcFracProcDivNmColumn].Value.ToString()))
                    {
                        count++;
                    }
                    if (count == this.Detail_uGrid.Rows.Count)
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           this.Name,
                           "更新対象のデータが存在しません。",
                           -1,
                           MessageBoxButtons.OK);
                        this.Detail_uGrid.Rows[0].Cells[goodsMakerCdColumn].Activate();
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 保存の処理を行った後、検索処理を行う時、抽出条件を設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 保存の処理を行った後、検索処理を行う時、抽出条件を設定します。</br>
        /// <br>Programmer : 朱 猛</br>
        /// <br>Date       : 2010/09/09</br>
        /// </remarks>
        /// <returns></returns>
        private void InsertCondition()
        {
            // 得意先ｺｰﾄﾞ
            if (this.tNedit_CustomerCode.Enabled)
            {
                this.tNedit_CustomerCode.Text = this._prevCustomerCode.ToString();
            }
            // 得意先掛率ｸﾞﾙｰﾌﾟ
            if (this.tNedit_CustRateGrpCodeZero.Enabled)
            {
                this.tNedit_CustRateGrpCodeZero.Text = this._prevCustRateGrpCode.ToString();
            }
            // 仕入先コード
            if (this.tNedit_SupplierCd.Enabled)
            {
                this.tNedit_SupplierCd.Text = this._prevSupplierCode.ToString("000000");
            }
            // メーカーコード
            if (this.tNedit_GoodsMakerCd.Focused)
            {
                this.tNedit_GoodsMakerCd.Text = this._prevMakerCode.ToString();
            }
            // BLコード
            if (this.tNedit_BLGoodsCode.Focused)
            {
                this.tNedit_BLGoodsCode.Text = this._prevBLGoodsCode.ToString();
            }
            // 商品掛率G
            if (this.tNedit_GoodsMGroup.Focused)
            {
                this.tNedit_GoodsMGroup.Text = this._prevGoodsRateGrpCode.ToString();
            }
            // グループコード
            if (this.tNedit_BLGloupCode.Focused)
            {
                this.tNedit_BLGloupCode.Text = this._prevBLGroupCode.ToString();
            }
        }

        /// <summary>
        /// 全削除ボタン有効かをチェック
        /// </summary>
        /// <remarks>
        /// <br>Note       : 全削除ボタン有効かをチェックします。</br>
        /// <br>Programmer : 朱 猛</br>
        /// <br>Date       : 2010/09/09</br>
        /// <br>Update Note : 2010/09/25 朱 猛</br>
        /// <br>            : Redmine#14492対応</br>
        /// </remarks>
        /// <returns></returns>
        private bool AllDeleteEnabledCheck()
        {
            // メーカーコード
            //string goodsMakerCdColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName; // DEL 2010/09/25
            string goodsMakerCdColumn = this.masterCode; // ADD 2010/09/25
            // 売価率
            string rateValColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName;
            // 原価UP率
            string upRateColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName;
            // 粗利確保率
            string grsProfitSecureRateColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName;
            // 端数処理単位
            string unPrcFracProcUnitColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcUnitColumn.ColumnName;
            // 端数処理区分
            string unPrcFracProcDivNmColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName;
            // ロジック削除区分
            string logicalDeleteCodeColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName;
            // チェックフラグ
            bool checkFlg = false;

            if (this.Detail_uGrid.Rows.Count == 0)
            {
                return checkFlg;
            }

            foreach (UltraGridRow row in this.Detail_uGrid.Rows)
            {
                if (this._rateProtyMng.UnitPriceKind == 1)
                {
                    if ((!"1".Equals(row.Cells[logicalDeleteCodeColumn].Text.Trim())) && ((row.Cells[goodsMakerCdColumn].Activation == Activation.NoEdit) ||
                        (double)row.Cells[rateValColumn].Value != 0 ||
                        (double)row.Cells[upRateColumn].Value != 0 ||
                        (double)row.Cells[grsProfitSecureRateColumn].Value != 0))
                    {
                        checkFlg = true;
                        return checkFlg;
                    }
                }
                else if (this._rateProtyMng.UnitPriceKind == 2)
                {
                    if ((!"1".Equals(row.Cells[logicalDeleteCodeColumn].Text.Trim())) && ((row.Cells[goodsMakerCdColumn].Activation == Activation.NoEdit) ||
                        (double)row.Cells[rateValColumn].Value != 0))
                    {
                        checkFlg = true;
                        return checkFlg;
                    }
                }
                else
                {
                    if ((!"1".Equals(row.Cells[logicalDeleteCodeColumn].Text.Trim())) && ((row.Cells[goodsMakerCdColumn].Activation == Activation.NoEdit) ||
                        (double)row.Cells[upRateColumn].Value != 0 ||
                        (double)row.Cells[unPrcFracProcUnitColumn].Value != 1 ||
                        !"2".Equals(row.Cells[unPrcFracProcDivNmColumn].Value.ToString())))
                    {
                        checkFlg = true;
                        return checkFlg;
                    }
                }
            }

            return checkFlg;
        }
        // --- ADD 2010/09/10 ----------<<<<<

        // ADD 2010/09/19 --- >>>>
        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// <br>Note       : 次入力可能セル移動を処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/09/19</br>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck, int leftRightFlg)
        {
            this.Detail_uGrid.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.Detail_uGrid.ActiveCell != null))
            {
                if ((!this.Detail_uGrid.ActiveCell.Column.Hidden) &&
                    (this.Detail_uGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.Detail_uGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }

            while (!moved)
            {
                if (leftRightFlg == 0)
                {
                    performActionResult = this.Detail_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);
                }
                else if (leftRightFlg == 1)
                {
                    performActionResult = this.Detail_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                }

                if (performActionResult)
                {
                    if ((this.Detail_uGrid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.Detail_uGrid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                    else
                    {
                        moved = false;
                    }
                }
                else
                {
                    break;
                }
            }

            if (moved)
            {
                this.Detail_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                this.Detail_uGrid.ActiveCell.SelectAll();
            }

            this.Detail_uGrid.ResumeLayout();
            return performActionResult;
        }
        // ADD 2010/09/19 --- >>>>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
            //if (!string.IsNullOrEmpty(this.Detail_uGrid.Rows[0].Cells["MasterNm"].Text.ToString().Trim())) // DEL 2010/09/25
            this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
            if (!string.IsNullOrEmpty(this.Detail_uGrid.Rows[0].Cells[masterCode].Text.ToString().Trim())) // ADD 2010/09/25
            {
                // ---------UPD 2010/09/25---------->>>
                //MoveNextAllowEditCell(false, 1);
                // セル移動：右
                if (this._cellMove == 0)
                {
                    MoveNextAllowEditCell(false, 1);
                }
                else
                {
                    this.Detail_uGrid_KeyDown(this, new KeyEventArgs(Keys.Down));
                }
                // ---------UPD 2010/09/25----------<<<
                
            }
            else
            {
                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
            }
        }
        /// <summary>
        /// 全部行の削除判断
        /// </summary>
        /// <returns>true:全部行の削除 false:非全部行削除</returns>
        /// <remarks>
        /// <br>Note       : 全部行の削除を判断します。</br>
        /// <br>Programmer : wangc</br>
        /// <br>Date       : 2010/09/21</br>
        /// </remarks>
        private bool AllDeleteCheck()
        {
            bool allDeltete = false;
            string logicalDeleteCodeColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName;
            foreach (UltraGridRow row in this.Detail_uGrid.Rows)
            {

                if ((int)row.Cells[logicalDeleteCodeColumn].Value != 1)
                {
                    allDeltete = true;
                }
            }

            return allDeltete;
        }

        /// <summary>
        /// 行の選択
        /// </summary>
        /// <returns>選択行の番号</returns>
        /// <remarks>
        /// <br>Note       : 行の選択</br>
        /// <br>Programmer : wangc</br>
        /// <br>Date       : 2010/09/21</br>
        /// </remarks>
        private int SelectedRow()
        {
            int selectRow;
            bool findedFlag = false; //ADD 2011/11/21 xupz
            //string logicalDeleteCodeColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName;
            for (selectRow = 0; selectRow < this.Detail_uGrid.Rows.Count; selectRow++)
            {
                // if (this.Detail_uGrid.Rows[selectRow].Cells[0].Activation == Activation.AllowEdit) // DEL 2010/09/30
                if (this.Detail_uGrid.Rows[selectRow].Cells[this.masterCode].Activation == Activation.AllowEdit) // ADD 2010/09/30
                {
                    //this.Detail_uGrid.Rows[targetRowIndex].Cells[columnIndex].Activate();
                    //this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    findedFlag = true; //ADD 2011/11/21 xupz
                    break;
                }
            }
            //foreach (UltraGridRow row in this.Detail_uGrid.Rows)
            //{
            //    selectRow++;
            //    if ((int)row.Cells[logicalDeleteCodeColumn].Value != 1)
            //    {
            //        break;
            //    }
            //}

            //return selectRow; // DEL 2011/11/21 xupz
            // ----- ADD 2011/11/21 xupz---------->>>>>
            if (findedFlag)
            {
                return selectRow;
            }
            else
            {
                return 0;
            }
            // ----- ADD 2011/11/21 xupz----------<<<<<
        }

        /// <summary>
        /// 行の選択
        /// </summary>
        /// <returns>選択行の番号</returns>
        /// <remarks>
        /// <br>Note       : 行の選択</br>
        /// <br>Programmer : wangc</br>
        /// <br>Date       : 2010/09/21</br>
        /// </remarks>
        private bool CatchSelectedRow(int rowIndex)
        {
            bool selectedRow = false;
            string logicalDeleteCodeColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName;

            for (int i = rowIndex; i < 999; i++)
            {
                if ((int)this.Detail_uGrid.Rows[i].Cells[logicalDeleteCodeColumn].Value != 1)
                {
                    selectedRow = true;
                }
            }

            return selectedRow;
        }
        // ADD 2010/09/19 --- <<<<

        /// <summary>
        /// グリッド初期可編集行を取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : グリッド初期可編集行取得を行います。</br>
        /// <br>Programmer  : 朱 猛</br>
        /// <br>Date        : 2010/09/25</br>
        /// </remarks>
        private int GetGridInitRowNo()
        {
            int rowIndex;
            for (rowIndex = 0; rowIndex < this.Detail_uGrid.Rows.Count; rowIndex++)
            {
                if (this.Detail_uGrid.Rows[rowIndex].Cells[this.masterCode].Activation == Activation.AllowEdit)
                {
                    break;
                }
            }
            return rowIndex;
        }
        #endregion Private Method
    }
}

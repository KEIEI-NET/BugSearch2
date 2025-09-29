//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率設定マスタメン（掛率優先管理パターン）（商品掛率ｸﾞﾙｰﾌﾟ指定）
// プログラム概要   : 掛率設定マスタメン（掛率優先管理パターン）（商品掛率ｸﾞﾙｰﾌﾟ指定）の処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2010/08/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 修 正 日  2010/08/31  修正内容 : Redmine#14030対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : hanby
// 修 正 日  2010/09/09  修正内容 : Redmine#14492対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 修 正 日  2010/09/26  修正内容 : Redmine#14492対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
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
    /// <br>Programmer	: 高峰</br>
    /// <br>Date		: 2010/08/19</br>
    /// <br>Update Note : 2010/08/31 呉元嘯</br>
    /// <br>            : Redmine#14030対応</br>
    /// <br>Update Note : 2010/09/09 hanby</br>
    /// <br>            : Redmine#14492対応</br>
    /// <br>Update Note : 2010/09/26 呉元嘯</br>
    /// <br>            : Redmine#14492対応</br>
    /// <br>Update Note : 2010/09/30 高峰</br>
    /// <br>            : Redmine#15703対応</br>
    /// <br>Update Note : 2011/11/21 許培珠</br>
    /// <br>            : Redmine#7867対応</br>
    /// </remarks>
    public partial class PMKHN09475UA : Form
    {

        #region Private Members
        private bool _cusotmerGuideSelected;                // 得意先ガイド選択フラグ

        // 前回値保持用変数
        private int _prevCustomerCode;
        private int _prevSupplierCode;
        private int _prevMakerCode;
        private int _prevCustRateGrpCode;

        // 企業コード取得用
        private string _enterpriseCode;
        // ログイン拠点(自拠点)
        private string _loginSectionCode;

        private CustomerInfoAcs _customerInfoAcs = null;    // 得意先アクセスクラス
        private SupplierAcs _supplierAcs = null;            // 仕入先アクセスクラス
        private MakerAcs _makerAcs = null;					// メーカーアクセスクラス
        private UserGuideAcs _userGuideAcs = null;			// ユーザーガイドアクセスクラス
        private SecInfoAcs _secInfoAcs; // 拠点アクセスクラス
        private RateProtyMngBlCdConstructionAcs _rateProtyMngBlCdConstructionAcs;
        private Dictionary<int, string> _custRateGrpDic;

        private RateProtyMng _rateProtyMng;// 掛率優先管理マスタ
        private RateProtyMngPatternAcs _rateProtyMngPatternAcs;// 掛率設定マスタメン（掛率優先管理パターン）アクセス
        private RateProtyMngPatternDataSet _rateProtyMngPatternDataSet;// 掛率マスタデータセット

        /// <summary>グリッド最上位行キーダウンイベント</summary>
        internal event EventHandler GridKeyDownTopRow;

        private ControlScreenSkin _controlScreenSkin;

        private Dictionary<int, Supplier> _supplierDic;
        private Dictionary<int, MakerUMnt> _makerUMntDic;

        private RateProtyMngPatternWork _rateProtyMngPatternWorkClone;// 画面抽出条件部Compare用

        private object _initFocus;
        private object _endFocus;
        private object _endButtonFocus;
        private int _cellMove;

        // ---ADD 2010/09/09---------------------->>>
        private GoodsGroupUAcs _goodsGroupUAcs = null;      // 商品掛率Ｇアクセスクラス

        private int _preRowIndex;
        private int _preColumnIndex;
        private string _preMakerCd;
        private string masterCode = "GoodsRateGrpCode"; // ADD 2010/09/25
        private bool _gridGuideFlg = false; // ADD 2010/09/25
        // ---ADD 2010/09/09----------------------<<<

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
        private const string CT_PGID = "PMKHN09475U";
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
        //private const string FORMAT_CURRENCY = "#,##0.00";
        private const string FORMAT_FRACTION = "#,##0.00;-#,##0.00;''";
        private const string FORMAT_CODE = "#0;-#0;''"; // ADD 2010/09/25

        // 指定なし
        private const string RATEMNGCUSTCD_NONE = "6";
        // --------ADD 2010/09/09-------->>>>>
        private const string TOOLBAR_GUIDEBUTTON_KEY = "ButtonTool_Guide";		                // ガイド
        private const string TOOLBAR_ALLROWDELETE_KEY = "ButtonTool_DelAllRow";                 // 全削除
        private const string UnitPriceKindNM_1 = "売価設定";
        private const string UnitPriceKindNM_2 = "原価設定";
        private const string UnitPriceKindNM_3 = "価格設定";
        private bool _errorFlg = false;
        private bool _searchFlg = false;
        private int _prevGoodsRateGrpCode;
        private UltraGridCell _preUnPrcFracProcDivNmCell = null;
        private Dictionary<int, GoodsGroupU> _goodsGroupUDic;
        private bool _guidFlg = false;
        private int _guidCd = 0;

        private bool _delBu = false;
        private bool _deleteButtonFlag = false;
        private bool _initFocusFlag = false;
        private bool _checkEmptyFlg = false;
        private bool _checkInputScreenErr = false;

        // 前回値保持用変数(保存の処理を行った後、検索処理用)
        private int _prevCustomerCd;
        private int _prevSupplierCd;
        private int _prevMakerCd;
        private int _prevCustRateGrpCd;

        // 検索処理前、フォーカスを取る
        private int _prevIndexRow = -1;
        private int _prevIndexColumn = -1;

        private bool _closeFlg = false;
        private bool _checkScreanInput = false;
        private bool _isCancelFlg = false;
        private bool _isError = false;

        private int _prevIndexRow2 = -1;
        private int _prevIndexColumn2 = -1;
        private bool _errorFlg2 = false;
        // --------ADD 2010/09/09--------<<<<<
        #endregion Const

        #region Constructor
        /// <summary>
        /// 掛率設定マスタメン（掛率優先管理パターン）（商品掛率ｸﾞﾙｰﾌﾟ指定）フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 掛率設定マスタメン（掛率優先管理パターン）（商品掛率ｸﾞﾙｰﾌﾟ指定）フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 高峰</br>
        /// <br>Date		: 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492対応</br>
        /// </remarks>
        public PMKHN09475UA(RateProtyMng rateProtyMng)
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
            this._goodsGroupUAcs = new GoodsGroupUAcs(); // ADD 2010/09/09
            this._rateProtyMngBlCdConstructionAcs = new RateProtyMngBlCdConstructionAcs();
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
        /// <br>Programmer	: 高峰</br>
        /// <br>Date		: 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492対応</br>
        /// </remarks>
        private void PMKHN09475UA_Load(object sender, EventArgs e)
        {
            // アイコン設定
            SetIcon();

            // 画面入力許可制御
            ScreenInputEnable();

            // 画面クリア
            ScreenClear();
            this._cellMove = this._rateProtyMngBlCdConstructionAcs.CellMove;
            this.Detail_uGrid.DataSource = this._rateProtyMngPatternAcs.RateProtyMngPatternDataSet;
            // ----------ADD 2010/09/09----------->>>>>
            // スキン変更除外設定
            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add(this.ultraExpandableGroupBox_Condition.Name);
            this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);
            // ----------ADD 2010/09/09-----------<<<<<
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            this.Delete_Button.Enabled = false; // ADD 2010/09/09
            this.DeleteAll_Button.Enabled = false; // ADD 2010/09/09
        }

        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: ツールバー上のツールがクリックされた時に発生します。</br>
        /// <br>Programmer	: 高峰</br>
        /// <br>Date		: 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492対応</br>
        /// <br>Update Note : 2010/09/30</br>
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
                        // ---ADD 2010/09/09---------------------->>>
                        if (this._isError == true)
                        {
                            this._isError = false;
                            return;
                        }
                        // ---ADD 2010/09/09----------------------<<<

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
                                    break;
                                case DialogResult.Yes:
                                    if (this.SaveProc())
                                    {
                                        this.ScreenClear();
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

                        // 検索処理前、検索条件をチェック
                        CheckBeforeSearch();

                        if (this._isError == true)
                        {
                            this._isError = false;
                            return;
                        }
                        // ---ADD 2010/09/09----------------------<<<
                        #region 検索
                        //SearchRateData(); // DEL 2010/09/09
                        this.Search(); // ADD 2010/09/09
                        // ---ADD 2010/09/26---------------------->>>
                        // 検索処理がキャンセルされた場合
                        if (this._isCancelFlg)
                        {
                            // なし
                        }
                        else if (this.Detail_uGrid.Rows.Count != 0 && this._checkInputScreenErr == false)
                        {
                            if (this.Mode_Label.Text == INSERT_MODE)
                            {
                                if (!this._initFocusFlag)
                                {
                                    this.Detail_uGrid.Focus();
                                    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                    this.Detail_uGrid.Rows[0].Cells[masterCode].Activate();
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
                                this.Detail_uGrid.Rows[0].Cells[masterCode].Activate();
                                ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                                this.SetGridTabFocus(ref evt);
                            }
                        }
                        this._isCancelFlg = false;
                        this._checkInputScreenErr = false;
                        // ---ADD 2010/09/26----------------------<<<
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
                        // ---UPD 2010/09/25---------------------->>>
                        // ---ADD 2010/09/10---------------------->>>
                        int rowIndex = 0;
                        //if (this.Detail_uGrid.ActiveCell != null) // DEL 2010/09/30 仕様連絡 #15703
                        if (this.Detail_uGrid.ActiveRow != null) // ADD 2010/09/30 仕様連絡 #15703
                        {
                            //rowIndex = this.Detail_uGrid.ActiveCell.Row.Index; // DEL 2010/09/30 仕様連絡 #15703
                            rowIndex = this.Detail_uGrid.ActiveRow.Index; // ADD 2010/09/30 仕様連絡 #15703
                        }
                        else
                        {
                            if (this.Detail_uGrid.Rows.Count > 0)
                            {
                                RowDelete();
                                if (!this.AllDeleteCheck())
                                {
                                    this.Delete_Button.Focus();
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                        // ---ADD 2010/09/10----------------------<<<
                        this._deleteButtonFlag = true;// ADD 2010/09/10
                        //this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);  // ADD 2010/09/10 // DEL 2010/09/30 仕様連絡 #15703
                        // ---ADD 2010/09/10---------------------->>>
                        if (this._errorFlg)
                        {
                            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = string.Empty;
                            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).GoodsRateGrpCode = string.Empty; // ADD 2010/09/25
                            this._errorFlg = false;
                        }
                        RowDelete();
                        if (!this.AllDeleteCheck())
                        {
                            this.Delete_Button.Focus();
                            break;
                        }

                        // --- DEL 2010/09/30 仕様連絡 #15703 ---------->>>>>
                        //if (!CatchSelectedRow(rowIndex))
                        //{
                        //    ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                        //    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[SelectedRow()];
                        //    //this.Detail_uGrid.Rows[SelectedRow()].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                        //    this.Detail_uGrid.Rows[SelectedRow()].Cells[masterCode].Activate(); // ADD 2010/09/25
                        //    //this.SetGridTabFocus(ref evt);
                        //    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        //}
                        //else
                        //{
                        //    //this.Detail_uGrid_KeyDown(this.Detail_uGrid, new KeyEventArgs(Keys.Right)); // ADD 2010/09/25
                        //}
                        // --- DEL 2010/09/30 仕様連絡 #15703 ----------<<<<<

                        // ---ADD 2010/09/10----------------------<<<
                        this._deleteButtonFlag = false;// ADD 2010/09/10
                        break;
                        //// ---ADD 2010/09/10----------------------<<<
                        //this._deleteButtonFlag = false;// ADD 2010/09/10
                        //break;

                        //RowDelete();
                        //break;
                        // ---UPD 2010/09/25----------------------<<<
                    }

                // ---ADD 2010/09/09---------------------->>>
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
                                ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).GoodsRateGrpCode = string.Empty; // ADD 2010/09/25
                            }
                            AllRowDelete();

                            if (!this._errorFlg)
                            {
                                ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                                this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[SelectedRow()];
                                //this.Detail_uGrid.Rows[SelectedRow()].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                this.Detail_uGrid.Rows[SelectedRow()].Cells[masterCode].Activate(); // ADD 2010/09/25
                                //this.SetGridTabFocus(ref evt);
                                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                //this.Detail_uGrid_KeyDown(this.Detail_uGrid, new KeyEventArgs(Keys.Right));
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
                                //this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[SelectedRow()]; // DEL 2010/09/25
                                //this.Detail_uGrid.Rows[SelectedRow()].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                //this.SetGridTabFocus(ref evt); // DEL 2010/09/25
                                this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate(); // ADD 2010/09/25
                                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode); // ADD 2010/09/25
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
                        // 得意先コードガイドを起動
                        if (this.tNedit_CustomerCode.Focused)
                        {
                            this.CustomerGuide_Button_Click(this.tNedit_CustomerCode, new EventArgs());
                        }
                        // 得意先掛率Gガイドを起動
                        else if (this.tNedit_CustRateGrpCodeZero.Focused)
                        {
                            this.CustRateGrpGuide_Button_Click(this.tNedit_CustRateGrpCodeZero, new EventArgs());
                        }
                        // 仕入先コードガイドを起動
                        else if (this.tNedit_SupplierCd.Focused)
                        {
                            this.SupplierGuide_Button_Click(this.tNedit_SupplierCd, new EventArgs());
                        }
                        // メーカーコードガイドを起動
                        // --------ADD 2010/09/09-------->>>>>
                        else if (this.tNedit_GoodsMakerCd.Focused)
                        {
                            this.MakerGuide_Button_Click(this.tNedit_GoodsMakerCd, new EventArgs());
                        }
                        // --------ADD 2010/09/09--------<<<<<
                        else
                        {
                            //if ((this.Detail_uGrid.ActiveCell != null) && this.Detail_uGrid.ActiveCell.Column.Key.Equals("MasterNm")) // DEL 2010/09/25
                            if ((this.Detail_uGrid.ActiveCell != null) && this.Detail_uGrid.ActiveCell.Column.Key.Equals(masterCode)) // ADD 2010/09/25
                            {
                                if (ExcuteGuide())
                                {
                                    // フォーカス制御
                                    ChangeFocusEventArgs ent = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                                    SetGridTabFocus(ref ent);
                                }
                            }
                        }

                        break;
                    }
                // ---ADD 2010/09/09----------------------<<<
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
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492対応</br>
        /// <br>Update Note : 2010/09/26 呉元嘯</br>
        /// <br>            : Redmine#14492対応</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            switch (e.PrevCtrl.Name)
            {
                case "Delete_Button":
                    {
                        if (e.NextCtrl != Detail_uGrid)
                        {
                            this.Detail_uGrid.ActiveCell = null;
                            this.Detail_uGrid.ActiveRow = null;
                        }
                        break;
                    }
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
                                this._prevCustomerCode = 0;
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
                                    this.tNedit_CustomerCode.SetInt(this._prevCustomerCode);
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
                                // ---ADD 2010/09/25---------------------->>>
                                case Keys.Left:
                                    {
                                        e.NextCtrl = null;
                                        break;
                                    }
                                // ---ADD 2010/09/25----------------------<<<
                                case Keys.LButton:
                                    {
                                        if (e.NextCtrl == this.Detail_uGrid)
                                        {
                                            this._delBu = true;
                                        }
                                        break;
                                    }
                                case Keys.Tab:
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
                                                //SearchRateData(); // DEL 2010/09/09
                                                this.Search(); // ADD 2010/09/09
                                                e.NextCtrl = null;
                                                // ---ADD 2010/09/26---------------------->>>
                                                // 検索処理がキャンセルされた場合
                                                if (this._isCancelFlg)
                                                {
                                                    // なし
                                                }
                                                else
                                                // ---ADD 2010/09/26----------------------<<<
                                                // ---ADD 2010/09/09---------------------->>>
                                                if (this.Detail_uGrid.Rows.Count != 0 && this._checkInputScreenErr == false)
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
                                                this._isCancelFlg = false; // ADD 2010/09/26
                                                this._checkInputScreenErr = false; // ADD 2010/09/26
                                                // ---ADD 2010/09/09----------------------<<<
                                            }
                                        }
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        if (!this.tNedit_CustRateGrpCodeZero.Enabled && !this.tNedit_SupplierCd.Enabled && this.Detail_uGrid.Rows.Count != 0)
                                        {
                                            // ---UPD 2010/09/25---------------------->>>
                                            //this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate();
                                            //this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            e.NextCtrl = null;
                                            // ---ADD 2010/09/09---------------------->>>
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
                                            // ---ADD 2010/09/09----------------------<<<

                                            this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            // ---UPD 2010/09/25----------------------<<<
                                        }
                                        else if (!this.tNedit_CustRateGrpCodeZero.Enabled && !this.tNedit_SupplierCd.Enabled && this.Detail_uGrid.Rows.Count == 0)
                                        {
                                            e.NextCtrl = null;
                                        }
                                    }
                                    break;
                                // ---ADD 2010/09/09---------------------->>>
                                case Keys.Up:
                                    {
                                        e.NextCtrl = null;
                                    }
                                    break;
                                // ---ADD 2010/09/09----------------------<<<
                            }
                        }
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter: // ADD 2010/09/09
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
                // 得意先ボタン
                //-----------------------------------------------------
                case "CustomerGuide_Button":
                    {
                        #region [フォーカス制御]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                // ---ADD 2010/09/25---------------------->>>
                                case Keys.Right:
                                    {
                                        if (!this.tNedit_GoodsMakerCd.Enabled)
                                        {
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    }
                                // ---ADD 2010/09/25----------------------<<<
                                case Keys.LButton:
                                    {
                                        if (e.NextCtrl == this.Detail_uGrid)
                                        {
                                            this._delBu = true;

                                        }
                                        break;
                                    }
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = null;
                                        bool status = SetFocus(3);
                                        if (status == false)
                                        {
                                            if (e.Key == Keys.Return)
                                            {
                                                //SearchRateData();
                                                this.Search(); // ADD 2010/09/09
                                                e.NextCtrl = null;
                                                // ---ADD 2010/09/26---------------------->>>
                                                // 検索処理がキャンセルされた場合
                                                if (this._isCancelFlg)
                                                {
                                                    // なし
                                                }
                                                else
                                                // ---ADD 2010/09/26----------------------<<<
                                                // ---ADD 2010/09/09---------------------->>>
                                                //if (this.Detail_uGrid.Rows.Count > 0) // DEL 2010/09/26
                                                if (this.Detail_uGrid.Rows.Count > 0 && this._checkInputScreenErr == false) // ADD 2010/09/26
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
                                                this._isCancelFlg = false; // ADD 2010/09/26
                                                this._checkInputScreenErr = false; // ADD 2010/09/26
                                                // ---ADD 2010/09/09----------------------<<<
                                            }
                                            else
                                            {
                                                if (this.Detail_uGrid.Rows.Count != 0)
                                                {
                                                    this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate();
                                                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                    e.NextCtrl = null;
                                                    // ---ADD 2010/09/09---------------------->>>
                                                    if (this.Detail_uGrid.Rows.Count > 0)
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
                                                    // ---ADD 2010/09/09----------------------<<<
                                                }
                                                else
                                                {
                                                    e.NextCtrl = null;
                                                }
                                            }
                                        }
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        if (!this.CustRateGrpGuide_Button.Enabled && !this.SupplierGuide_Button.Enabled && this.Detail_uGrid.Rows.Count != 0)
                                        {
                                            // ---UPD 2010/09/25---------------------->>>
                                            //this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate();
                                            //this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            e.NextCtrl = null;
                                            // ---ADD 2010/09/09---------------------->>>
                                            //if (this.Detail_uGrid.Rows.Count > 0)
                                            //{
                                            //    if (this.Mode_Label.Text == INSERT_MODE)
                                            //    {
                                            //        if (!this._initFocusFlag)
                                            //        {
                                            //            this.Detail_uGrid.Focus();
                                            //            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //            //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //            this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //            this.InitGridFocus(0, 0);
                                            //        }
                                            //        else
                                            //        {
                                            //            this._initFocusFlag = false;
                                            //        }
                                            //    }
                                            //    else
                                            //    {
                                            //        this.Detail_uGrid.Focus();
                                            //        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //        this.SetGridTabFocus(ref e);
                                            //    }
                                            //}
                                            // ---ADD 2010/09/09----------------------<<<

                                            this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);

                                            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                                            // ---UPD 2010/09/25----------------------<<<
                                        }
                                        else if (!this.CustRateGrpGuide_Button.Enabled && !this.SupplierGuide_Button.Enabled && this.Detail_uGrid.Rows.Count == 0)
                                        {
                                            e.NextCtrl = null;
                                        }
                                    }
                                    break;
                                // ---ADD 2010/09/09---------------------->>>
                                case Keys.Up:
                                    {
                                        e.NextCtrl = null;
                                    }
                                    break;
                                // ---ADD 2010/09/09----------------------<<<
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
                                // -------UPD 2010/09/26--------->>>>>
                                //this.tNedit_CustRateGrpCodeZero.SetInt(this._prevCustRateGrpCode);
                                //this.tNedit_CustRateGrpCodeZero.Text=""; // UPD 2010/09/09
                                if (this._prevCustRateGrpCode == -1)
                                {
                                    this.tNedit_CustRateGrpCodeZero.Clear();
                                }
                                else
                                {
                                    this.tNedit_CustRateGrpCodeZero.SetInt(this._prevCustRateGrpCode);
                                }
                                // -------UPD 2010/09/26---------<<<<<
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
                                // -------ADD 2010/09/26--------->>>>>
                                case Keys.Up:
                                    {
                                        if (!this.tNedit_CustomerCode.Enabled)
                                        {
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    }
                                // -------ADD 2010/09/26---------<<<<<
                                case Keys.LButton: 
                                    {
                                        if(e.NextCtrl==this.Detail_uGrid)
                                        {
                                            this._delBu = true;
                                            
                                        }
                                        break;
                                    }
                                case Keys.Tab:
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
                                                if (e.Key == Keys.Return)
                                                {
                                                    //SearchRateData();
                                                    this.Search(); // ADD 2010/09/09
                                                    e.NextCtrl = null;
                                                    // ---ADD 2010/09/26---------------------->>>
                                                    // 検索処理がキャンセルされた場合
                                                    if (this._isCancelFlg)
                                                    {
                                                        // なし
                                                    }
                                                    else
                                                    // ---ADD 2010/09/26----------------------<<<
                                                    // ---ADD 2010/09/09---------------------->>>
                                                    //if (this.Detail_uGrid.Rows.Count > 0) // DEL 2010/09/26
                                                    if (this.Detail_uGrid.Rows.Count > 0 && this._checkInputScreenErr == false) // ADD 2010/09/26
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
                                                    this._isCancelFlg = false; // ADD 2010/09/26
                                                    this._checkInputScreenErr = false; // ADD 2010/09/26
                                                    // ---ADD 2010/09/09----------------------<<<
                                                }
                                                else
                                                {
                                                    if (this.Detail_uGrid.Rows.Count != 0)
                                                    {
                                                        this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate();
                                                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                        e.NextCtrl = null;
                                                        // ---ADD 2010/09/09---------------------->>>
                                                        if (this.Detail_uGrid.Rows.Count > 0)
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
                                                        // ---ADD 2010/09/09----------------------<<<
                                                    }
                                                    else
                                                    {
                                                        e.NextCtrl = null;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        if (!this.tNedit_SupplierCd.Enabled && this.Detail_uGrid.Rows.Count != 0)
                                        {
                                            // ---UPD 2010/09/25---------------------->>>
                                            //this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate();
                                            //this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            e.NextCtrl = null;
                                            // ---ADD 2010/09/09---------------------->>>
                                            //if (this.Detail_uGrid.Rows.Count > 0)
                                            //{
                                            //    if (this.Mode_Label.Text == INSERT_MODE)
                                            //    {
                                            //        if (!this._initFocusFlag)
                                            //        {
                                            //            this.Detail_uGrid.Focus();
                                            //            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //            //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //            this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //            this.InitGridFocus(0, 0);
                                            //        }
                                            //        else
                                            //        {
                                            //            this._initFocusFlag = false;
                                            //        }
                                            //    }
                                            //    else
                                            //    {
                                            //        this.Detail_uGrid.Focus();
                                            //        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //        this.SetGridTabFocus(ref e);
                                            //    }
                                            //}
                                            // ---ADD 2010/09/09----------------------<<<

                                            this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            // ---UPD 2010/09/25----------------------<<<
                                        }
                                        else if (!this.tNedit_SupplierCd.Enabled && this.Detail_uGrid.Rows.Count == 0)
                                        {
                                            e.NextCtrl = null;
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            if (this._initFocus == this.tNedit_CustRateGrpCodeZero)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            e.NextCtrl = null;
                                        }
                                        break;
                                }
                            }
                        }
                        #endregion [フォーカス制御]
                        break;
                    }
                //-----------------------------------------------------
                // 得意先掛率ｸﾞﾙｰﾌﾟボタン
                //-----------------------------------------------------
                case "CustRateGrpGuide_Button":
                    {
                        #region [フォーカス制御]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                // -------ADD 2010/09/26--------->>>>>
                                case Keys.Up:
                                    {
                                        if (!this.tNedit_CustomerCode.Enabled)
                                        {
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    }
                                // -------ADD 2010/09/26---------<<<<<
                                case Keys.LButton:
                                    {
                                        if (e.NextCtrl == this.Detail_uGrid)
                                        {
                                            this._delBu = true;

                                        }
                                        break;
                                    }
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = null;
                                        bool status = SetFocus(3);
                                        if (status == false)
                                        {
                                            if (e.Key == Keys.Return)
                                            {
                                                //SearchRateData();
                                                //this.Search(); // ADD 2010/09/09 // DEL 2010/09/25
                                                bool searchFlg = this.Search(); // ADD 2010/09/09
                                                e.NextCtrl = null;
                                                if (searchFlg == false) return; // ADD 2010/09/25
                                                // ---ADD 2010/09/26---------------------->>>
                                                // 検索処理がキャンセルされた場合
                                                if (this._isCancelFlg)
                                                {
                                                    // なし
                                                }
                                                else
                                                // ---ADD 2010/09/26----------------------<<<
                                                // ---ADD 2010/09/09---------------------->>>
                                                //if (this.Detail_uGrid.Rows.Count > 0) // DEL 2010/09/26
                                                if (this.Detail_uGrid.Rows.Count > 0 && this._checkInputScreenErr == false) // ADD 2010/09/26
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
                                                this._isCancelFlg = false; // ADD 2010/09/26
                                                this._checkInputScreenErr = false; // ADD 2010/09/26
                                                // ---ADD 2010/09/09----------------------<<<
                                            }
                                            else
                                            {
                                                if (this.Detail_uGrid.Rows.Count != 0)
                                                {
                                                    this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate();
                                                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                    e.NextCtrl = null;
                                                    // ---ADD 2010/09/09---------------------->>>
                                                    if (this.Detail_uGrid.Rows.Count > 0)
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
                                                    // ---ADD 2010/09/09----------------------<<<
                                                }
                                                else
                                                {
                                                    e.NextCtrl = null;
                                                }
                                            }
                                        }
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        if (!this.SupplierGuide_Button.Enabled && this.Detail_uGrid.Rows.Count != 0)
                                        {
                                            // ---UPD 2010/09/25---------------------->>>
                                            //this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate();
                                            //this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            e.NextCtrl = null;
                                            // ---ADD 2010/09/09---------------------->>>
                                            //if (this.Detail_uGrid.Rows.Count > 0)
                                            //{
                                            //    if (this.Mode_Label.Text == INSERT_MODE)
                                            //    {
                                            //        if (!this._initFocusFlag)
                                            //        {
                                            //            this.Detail_uGrid.Focus();
                                            //            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //            //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //            this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //            this.InitGridFocus(0, 0);
                                            //        }
                                            //        else
                                            //        {
                                            //            this._initFocusFlag = false;
                                            //        }
                                            //    }
                                            //    else
                                            //    {
                                            //        this.Detail_uGrid.Focus();
                                            //        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //        this.SetGridTabFocus(ref e);
                                            //    }
                                            //}
                                            // ---ADD 2010/09/09----------------------<<<

                                            this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);

                                            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                                            // ---UPD 2010/09/25----------------------<<<
                                        }
                                        else if (!this.SupplierGuide_Button.Enabled && this.Detail_uGrid.Rows.Count == 0)
                                        {
                                            e.NextCtrl = null;
                                        }
                                    }
                                    break;
                                // ---ADD 2010/09/25---------------------->>>
                                case Keys.Right:
                                    {
                                        e.NextCtrl = null;
                                        break;
                                    }
                                // ---ADD 2010/09/25----------------------<<<
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
                                this._prevSupplierCode = 0;
                            }
                            else
                            {
                                string name = string.Empty;
                                bool check = GetSupplierName(inputValue, out name);
                                if (check)
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
                                // ---ADD 2010/09/25---------------------->>>
                                case Keys.Left:
                                    {
                                        e.NextCtrl = null;
                                        break;
                                    }
                                // ---ADD 2010/09/25----------------------<<<
                                case Keys.LButton:
                                    {
                                        if (e.NextCtrl == this.Detail_uGrid)
                                        {
                                            this._delBu = true;

                                        }
                                        break;
                                    }
                                case Keys.Tab:
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
                                                if (e.Key == Keys.Return)
                                                {
                                                    //SearchRateData();
                                                    this.Search(); // ADD 2010/09/09
                                                    e.NextCtrl = null;
                                                    // ---ADD 2010/09/26---------------------->>>
                                                    // 検索処理がキャンセルされた場合
                                                    if (this._isCancelFlg)
                                                    {
                                                        // なし
                                                    }
                                                    else
                                                    // ---ADD 2010/09/26----------------------<<<
                                                    // ---ADD 2010/09/09---------------------->>>
                                                    //if (this.Detail_uGrid.Rows.Count > 0) // DEL 2010/09/26
                                                    if (this.Detail_uGrid.Rows.Count > 0 && this._checkInputScreenErr == false) // ADD 2010/09/26
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
                                                    this._isCancelFlg = false; // ADD 2010/09/26
                                                    this._checkInputScreenErr = false; // ADD 2010/09/26
                                                    // ---ADD 2010/09/09----------------------<<<
                                                }
                                                else
                                                {
                                                    if (this.Detail_uGrid.Rows.Count != 0)
                                                    {
                                                        this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate();
                                                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                        e.NextCtrl = null;
                                                        // ---ADD 2010/09/09---------------------->>>
                                                        if (this.Detail_uGrid.Rows.Count > 0)
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
                                                        // ---ADD 2010/09/09----------------------<<<
                                                    }
                                                    else
                                                    {
                                                        e.NextCtrl = null;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        if (this.Detail_uGrid.Rows.Count != 0)
                                        {
                                            // ---UPD 2010/09/25---------------------->>>
                                            //this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate();
                                            //this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            e.NextCtrl = null;
                                            // ---ADD 2010/09/09---------------------->>>
                                            //if (this.Detail_uGrid.Rows.Count > 0)
                                            //{
                                            //    if (this.Mode_Label.Text == INSERT_MODE)
                                            //    {
                                            //        if (!this._initFocusFlag)
                                            //        {
                                            //            this.Detail_uGrid.Focus();
                                            //            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[SelectedRow()];
                                            //            //this.Detail_uGrid.Rows[SelectedRow()].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //            this.Detail_uGrid.Rows[SelectedRow()].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //            this.InitGridFocus(0, 0);
                                            //        }
                                            //        else
                                            //        {
                                            //            this._initFocusFlag = false;
                                            //        }
                                            //    }
                                            //    else
                                            //    {
                                            //        this.Detail_uGrid.Focus();
                                            //        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[SelectedRow()];
                                            //        //this.Detail_uGrid.Rows[SelectedRow()].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //        this.Detail_uGrid.Rows[SelectedRow()].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            //    }
                                            //}
                                            // ---ADD 2010/09/09----------------------<<<

                                            this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            // ---UPD 2010/09/25----------------------<<<
                                        }
                                        else
                                        {
                                            e.NextCtrl = null;
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            if (this._initFocus == this.tNedit_SupplierCd)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            e.NextCtrl = null;
                                        }
                                        break;
                                }
                            }
                        }
                        #endregion [フォーカス制御]
                        break;
                    }
                //-----------------------------------------------------
                // 仕入先ボタン
                //-----------------------------------------------------
                case "SupplierGuide_Button":
                    {
                        #region [フォーカス制御]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                // ---ADD 2010/09/25---------------------->>>
                                case Keys.Right:
                                    {
                                        e.NextCtrl = null;
                                        break;
                                    }
                                // ---ADD 2010/09/25----------------------<<<
                                case Keys.LButton:
                                    {
                                        if (e.NextCtrl == this.Detail_uGrid)
                                        {
                                            this._delBu = true;

                                        }
                                        break;
                                    }
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        e.NextCtrl = null;
                                        bool status = SetFocus(3);
                                        if (status == false)
                                        {
                                            if (e.Key == Keys.Return)
                                            {
                                                //SearchRateData();
                                                this.Search(); // ADD 2010/09/09
                                                e.NextCtrl = null;
                                                // ---ADD 2010/09/26---------------------->>>
                                                // 検索処理がキャンセルされた場合
                                                if (this._isCancelFlg)
                                                {
                                                    // なし
                                                }
                                                else
                                                // ---ADD 2010/09/26----------------------<<<
                                                // ---ADD 2010/09/09---------------------->>>
                                                //if (this.Detail_uGrid.Rows.Count > 0) // DEL 2010/09/26
                                                if (this.Detail_uGrid.Rows.Count > 0 && this._checkInputScreenErr == false) // ADD 2010/09/26
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
                                                this._isCancelFlg = false; // ADD 2010/09/26
                                                this._checkInputScreenErr = false; // ADD 2010/09/26
                                                // ---ADD 2010/09/09----------------------<<<
                                            }
                                            else
                                            {
                                                if (this.Detail_uGrid.Rows.Count != 0)
                                                {
                                                    this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate();
                                                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                    e.NextCtrl = null;
                                                    // ---ADD 2010/09/09---------------------->>>
                                                    if (this.Detail_uGrid.Rows.Count > 0)
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
                                                    // ---ADD 2010/09/09----------------------<<<
                                                }
                                                else
                                                {
                                                    e.NextCtrl = null;
                                                }
                                            }
                                        }
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        if (this.Detail_uGrid.Rows.Count != 0)
                                        {
                                            // ---UPD 2010/09/25---------------------->>>
                                            //this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate();
                                            //this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            e.NextCtrl = null;
                                            // ---ADD 2010/09/09---------------------->>>
                                            //if (this.Detail_uGrid.Rows.Count > 0)
                                            //{
                                            //    if (this.Mode_Label.Text == INSERT_MODE)
                                            //    {
                                            //        if (!this._initFocusFlag)
                                            //        {
                                            //            this.Detail_uGrid.Focus();
                                            //            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[SelectedRow()];
                                            //            //this.Detail_uGrid.Rows[SelectedRow()].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //            this.Detail_uGrid.Rows[SelectedRow()].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //            this.InitGridFocus(0, 0);
                                            //        }
                                            //        else
                                            //        {
                                            //            this._initFocusFlag = false;
                                            //        }
                                            //    }
                                            //    else
                                            //    {
                                            //        //this.Detail_uGrid.Focus();
                                            //        //this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate();
                                            //        //this.SetGridTabFocus(ref e);
                                            //        this.Detail_uGrid.Focus();
                                            //        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[SelectedRow()];
                                            //        //this.Detail_uGrid.Rows[SelectedRow()].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //        this.Detail_uGrid.Rows[SelectedRow()].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //        //this.SetGridTabFocus(ref e);
                                            //        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            //    }
                                            //}
                                            // ---ADD 2010/09/09----------------------<<<

                                            this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);

                                            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                                            // ---UPD 2010/09/25----------------------<<<
                                        }
                                        else
                                        {
                                            e.NextCtrl = null;
                                        }
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
                                this._prevMakerCode = 0;
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
                                case Keys.LButton:
                                    {
                                        if (e.NextCtrl == this.Detail_uGrid)
                                        {
                                            this._delBu = true;

                                        }
                                        break;
                                    }
                                case Keys.Tab:
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
                                                if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                                {
                                                    //SearchRateData();
                                                    this.Search(); // ADD 2010/09/09
                                                    e.NextCtrl = null;
                                                    // ---ADD 2010/09/26---------------------->>>
                                                    // 検索処理がキャンセルされた場合
                                                    if (this._isCancelFlg)
                                                    {
                                                        // なし
                                                    }
                                                    else
                                                    // ---ADD 2010/09/26----------------------<<<
                                                    // ---ADD 2010/09/09---------------------->>>
                                                    //if (this.Detail_uGrid.Rows.Count > 0) // DEL 2010/09/26
                                                    if (this.Detail_uGrid.Rows.Count > 0 && this._checkInputScreenErr == false) // ADD 2010/09/26
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
                                                    this._isCancelFlg = false; // ADD 2010/09/26
                                                    this._checkInputScreenErr = false; // ADD 2010/09/26
                                                    // ---ADD 2010/09/09----------------------<<<
                                                }
                                                else
                                                {
                                                    if (this.Detail_uGrid.Rows.Count != 0)
                                                    {
                                                        this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate();
                                                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                        e.NextCtrl = null;
                                                        // ---ADD 2010/09/09---------------------->>>
                                                        if (this.Detail_uGrid.Rows.Count > 0)
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
                                                        // ---ADD 2010/09/09----------------------<<<
                                                    }
                                                    else
                                                    {
                                                        e.NextCtrl = null;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        if (!this.tNedit_CustRateGrpCodeZero.Enabled && !this.tNedit_SupplierCd.Enabled && this.Detail_uGrid.Rows.Count != 0)
                                        {
                                            // ---UPD 2010/09/25---------------------->>>
                                            //this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate();
                                            //this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            e.NextCtrl = null;
                                            // ---ADD 2010/09/09---------------------->>>
                                            //if (this.Detail_uGrid.Rows.Count > 0)
                                            //{
                                            //    if (this.Mode_Label.Text == INSERT_MODE)
                                            //    {
                                            //        if (!this._initFocusFlag)
                                            //        {
                                            //            this.Detail_uGrid.Focus();
                                            //            this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //            //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //            this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //            this.InitGridFocus(0, 0);
                                            //        }
                                            //        else
                                            //        {
                                            //            this._initFocusFlag = false;
                                            //        }
                                            //    }
                                            //    else
                                            //    {
                                            //        this.Detail_uGrid.Focus();
                                            //        this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                            //        //this.Detail_uGrid.Rows[0].Cells["MasterNm"].Activate(); // DEL 2010/09/25
                                            //        this.Detail_uGrid.Rows[0].Cells[masterCode].Activate(); // ADD 2010/09/25
                                            //        this.SetGridTabFocus(ref e);
                                            //    }
                                            //}
                                            // ---ADD 2010/09/09----------------------<<<

                                            this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            // ---UPD 2010/09/25----------------------<<<
                                        }
                                        else if (!this.CustRateGrpGuide_Button.Enabled && !this.SupplierGuide_Button.Enabled && this.Detail_uGrid.Rows.Count == 0)
                                        {
                                            e.NextCtrl = null;
                                        }
                                    }
                                    break;
                                // ---ADD 2010/09/25---------------------->>>
                                case Keys.Up:
                                    {
                                        e.NextCtrl = null;
                                        this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                                    }
                                    break;
                                case Keys.Left:
                                    {
                                        if (!this.tNedit_CustomerCode.Enabled)
                                        {
                                            e.NextCtrl = null;
                                        }
                                    }
                                    break;
                                // ---ADD 2010/09/25----------------------<<<
                            }
                        }
                        else
                        {
                            if (this._initFocus == this.tNedit_GoodsMakerCd)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    // ---ADD 2010/09/09---------------------->>>
                                    case Keys.Up:
                                        {
                                            e.NextCtrl = null;
                                        }
                                        break;
                                    // ---ADD 2010/09/09----------------------<<<
                                }
                            }
                        }
                        #endregion [フォーカス制御]
                        break;
                    }
                //-----------------------------------------------------
                // メーカーボタン
                //-----------------------------------------------------
                case "MakerGuide_Button":
                    {
                        #region [フォーカス制御]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.LButton:
                                    {
                                        if (e.NextCtrl == this.Detail_uGrid)
                                        {
                                            this._delBu = true;

                                        }
                                        break;
                                    }
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (e.Key == Keys.Return || e.Key == Keys.Tab)
                                        {
                                            //SearchRateData();
                                            this.Search(); // ADD 2010/09/09
                                            e.NextCtrl = null;
                                            // ---ADD 2010/09/26---------------------->>>
                                            // 検索処理がキャンセルされた場合
                                            if (this._isCancelFlg)
                                            {
                                                // なし
                                            }
                                            else
                                            // ---ADD 2010/09/26----------------------<<<
                                            // ---ADD 2010/09/09---------------------->>>
                                            //if (this.Detail_uGrid.Rows.Count > 0) // DEL 2010/09/26
                                            if (this.Detail_uGrid.Rows.Count > 0 && this._checkInputScreenErr == false) // ADD 2010/09/26
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
                                            this._isCancelFlg = false; // ADD 2010/09/26
                                            this._checkInputScreenErr = false; // ADD 2010/09/26
                                            // ---ADD 2010/09/09----------------------<<<
                                        }
                                        else
                                        {
                                            if (this.Detail_uGrid.Rows.Count != 0)
                                            {
                                                this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate();
                                                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                e.NextCtrl = null;
                                                // ---ADD 2010/09/09---------------------->>>
                                                if (this.Detail_uGrid.Rows.Count > 0)
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
                                                // ---ADD 2010/09/09----------------------<<<
                                            }
                                            else
                                            {
                                                e.NextCtrl = null;
                                            }
                                        }
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        //if (!this.tNedit_CustRateGrpCodeZero.Enabled && !this.tNedit_SupplierCd.Enabled && this.Detail_uGrid.Rows.Count != 0) // DEL 2010/09/21
                                        //if (this.Detail_uGrid.Rows.Count != 0) // ADD 2010/09/21 // DEL 2010/09/25
                                        if (!this.tNedit_CustRateGrpCodeZero.Enabled && !this.tNedit_SupplierCd.Enabled && this.Detail_uGrid.Rows.Count != 0) // ADD 2010/09/21
                                        {
                                            //this.Detail_uGrid.Rows[0].Cells[GetGridInitColumKey()].Activate(); // DEL 2010/09/25
                                            //this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode); // DEL 2010/09/25
                                            e.NextCtrl = null;
                                            //	---UPD 2010/09/21----------------------------->>>
                                            // ---UPD 2010/09/25---------------------->>>
                                            // ---ADD 2010/09/09---------------------->>>
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
                                            // ---ADD 2010/09/09----------------------<<<

                                            this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);

                                            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = false;
                                            // ---UPD 2010/09/25----------------------<<<
                                        }
                                        // ---UPD 2010/09/25----------------------<<<
                                        //else
                                        //{
                                        //    e.NextCtrl = null;
                                        //}
                                        else if (!this.CustRateGrpGuide_Button.Enabled && !this.SupplierGuide_Button.Enabled && this.Detail_uGrid.Rows.Count == 0)
                                        {
                                            e.NextCtrl = null;
                                        }
                                        // ---UPD 2010/09/25----------------------<<<
										//	---UPD 2010/09/21----------------------------->>>
                                    }
                                    break;
                                // ---ADD 2010/09/09---------------------->>>
                                case Keys.Up:
                                    {
                                        e.NextCtrl = null;
                                    }
                                    break;
                                case Keys.Right:
                                    {
                                        e.NextCtrl = null;
                                    }
                                    break;
                                // ---ADD 2010/09/09----------------------<<<
                            }
                        }
						// ---ADD 2010/09/21---------------------->>>
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
						// ---ADD 2010/09/21----------------------<<<
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
                            if (e.NextCtrl == this.tNedit_CustomerCode || e.NextCtrl == this.tNedit_CustRateGrpCodeZero || e.NextCtrl == this.tNedit_SupplierCd || e.NextCtrl == tNedit_GoodsMakerCd)
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
                                // --- ADD 2010/09/09 ---------->>>>>
                                this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);
                                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                if (_errorFlg)
                                {
                                    e.NextCtrl = null;
                                    this._errorFlg = false;
                                    break;
                                }
                                // --- ADD 2010/09/09 ----------<<<<<

                                // --- ADD 2010/09/25 ---------->>>>>
                                if (_errorFlg2)
                                {
                                    e.NextCtrl = null;
                                    this._errorFlg2 = false;
                                    break;
                                }
                                // --- ADD 2010/09/25 ----------<<<<<
                                // グリッドタブ移動制御
                                SetGridTabFocus(ref e);
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Return) 
                            {
                                // グリッドシフトタブ移動制御
                                SetGridShiftTabFocus(ref e);

                            }
                        }
                        // --- ADD 2010/09/10 ---------->>>>>
                        if (e.NextCtrl != null)
                        {
                            if (e.NextCtrl.CanSelect)
                            {
                                if (e.NextCtrl != Delete_Button && e.NextCtrl != DeleteAll_Button)
                                {
                                    this.Detail_uGrid.ActiveCell = null;
                                    this.Detail_uGrid.ActiveRow = null;
                                }
                                
                            }
                        }
                        // --- ADD 2010/09/10 ----------<<<<<
                        #endregion
                        break;
                    }
            }
            // ---ADD 2010/09/09---------------------->>>
            #region ■ガイド有効無効の設定
            if (this.Detail_uGrid.ActiveCell != null)
            {
                string columnKey = this.Detail_uGrid.ActiveCell.Column.Key;
                int columnIndex = 0;
                if (e.ShiftKey && e.Key == Keys.Tab)
                {
                    columnIndex = GetNextColumnIndexByTab(1, this.Detail_uGrid.Rows.Count - 1, columnKey);
                }
                //if (this.Detail_uGrid.ActiveCell.Column.Key.Equals("MasterNm") && columnIndex >= 0) // DEL 2010/09/25
                if (this.Detail_uGrid.ActiveCell.Column.Key.Equals(masterCode) && columnIndex >= 0) // ADD 2010/09/25
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
                    case "tNedit_GoodsMakerCd": // ADD 2010/09/09
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
                    case "tNedit_GoodsMakerCd": // ADD 2010/09/09
                        if (e.NextCtrl.Name.Equals("_PMKHN09477UA_Toolbars_Dock_Area_Top") || e.NextCtrl.CanFocus == false || e.NextCtrl.CanSelect == false)
                        {
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                        }
                        break;
                }
            }
            else
            {
                if (this.tNedit_CustomerCode.Focused || this.tNedit_CustRateGrpCodeZero.Focused || this.tNedit_SupplierCd.Focused || this.tNedit_GoodsMakerCd.Focused )
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
            //if (this._delBu && this.Detail_uGrid.Rows.Count > 0) 
            //{
            //    this._delBu = false;
            //    this.Delete_Button.Enabled = true;
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
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/08/31 呉元嘯</br>
        /// <br>            : Redmine#14030対応</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492対応</br>
        /// </remarks>
        private void Detail_uGrid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.Detail_uGrid.DisplayLayout.Bands[0];
            if (band == null) return;

            int visiblePosition = 0;
            this.Detail_uGrid.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Detail_uGrid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Default;
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
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].Width = 35; //UPD 2010/09/09
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].Hidden = false;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.Detail_uGrid.DisplayLayout.Override.HeaderAppearance.ForeColor;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.Detail_uGrid.DisplayLayout.Override.HeaderAppearance.ForeColor;
            // ----------ADD 2010/09/25----------->>>
            // 商品掛率ｸﾞﾙｰﾌﾟコード
            band.Columns[masterCode].Header.VisiblePosition = visiblePosition++;
            band.Columns[masterCode].Header.Fixed = true;
            band.Columns[masterCode].Header.Caption = "商品掛率Ｇ";
            band.Columns[masterCode].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[masterCode].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            band.Columns[masterCode].Width = 80;
            band.Columns[masterCode].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            band.Columns[masterCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[masterCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            band.Columns[masterCode].Hidden = false;
            band.Columns[masterCode].Format = FORMAT_CODE;
            // ----------ADD 2010/09/25-----------<<<
            // 商品掛率ｸﾞﾙｰﾌﾟ
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Header.Fixed = true;
            //band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Header.Caption = "商品掛率ｸﾞﾙｰﾌﾟ"; // DEL 2010/09/25
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Header.Caption = "商品掛率Ｇ名"; // ADD 2010/09/25
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;// DEL 2010/09/09
            //band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;// ADD 2010/09/09
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;// ADD 2010/09/25
            //band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Width = 250;// DEL 2010/08/31
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Width = 160;// ADD 2010/08/31
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Hidden = false;
            band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].MaxLength = 4; // ADD 2010/09/09

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
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName].MaxLength = 3; // ADD 2010/09/09

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
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName].MaxLength = 3; // ADD 2010/09/09

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
                        band.Columns[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GrsProfitSecureRateColumn.ColumnName].MaxLength = 2; // ADD 2010/09/09

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
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492対応</br>
        /// </remarks>
        //private void Detail_uGrid_KeyDown(object sender, KeyEventArgs e)
        //{

        //    if ((this.Detail_uGrid.Rows.Count == 0) ||
        //        ((this.Detail_uGrid.ActiveCell == null) && (this.Detail_uGrid.ActiveRow == null)))
        //    {
        //        switch (e.KeyCode)
        //        {
        //            case Keys.Up:
        //                {
        //                    SetFocus(1);
        //                    break;
        //                }
        //            case Keys.Down:
        //            case Keys.Right:
        //                {
        //                    break;
        //                }
        //            case Keys.Left:
        //                {
        //                    //
        //                    break;
        //                }
        //        }
        //        return;
        //    }

        //    int rowIndex;
        //    int columnIndex;
        //    string columnKey;

        //    if (Detail_uGrid.ActiveCell != null)
        //    {
        //        rowIndex = Detail_uGrid.ActiveCell.Row.Index;
        //        columnIndex = Detail_uGrid.ActiveCell.Column.Index;
        //        columnKey = Detail_uGrid.ActiveCell.Column.Key;
        //    }
        //    else
        //    {
        //        rowIndex = Detail_uGrid.ActiveRow.Index;
        //        // 原価の場合
        //        if (_rateProtyMng.UnitPriceKind == 2)
        //        {
        //            columnIndex = 3;
        //        }
        //        else
        //        {
        //            columnIndex = 4;
        //        }
        //        columnKey = Detail_uGrid.ActiveRow.Cells[columnIndex].Column.Key;
        //    }

        //    // ---ADD 2010/09/09---------------------->>>
        //    #region ■端数処理区分チェック
        //    if ((this.Detail_uGrid.ActiveCell != null) && this.Detail_uGrid.ActiveCell.Column.Key.Equals("UnPrcFracProcDivNm"))
        //    {
        //        switch (this.Detail_uGrid.ActiveCell.Text)
        //        {
        //            case "1":
        //            case "1:切捨て":
        //            case "2":
        //            case "2:四捨五入":
        //            case "3":
        //            case "3:切上げ":
        //                break;
        //            default:
        //                this.Detail_uGrid.ActiveCell.Value = 2;
        //                break;
        //        }
        //    }
        //    #endregion
        //    // ---ADD 2010/09/09----------------------<<<

        //    switch (e.KeyCode)
        //    {
        //        case Keys.Up:
        //            {
        //                if (this.Detail_uGrid.DisplayLayout.Bands[0].Columns[columnIndex].Style == Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList)
        //                {
        //                    if (this.Detail_uGrid.ActiveCell.ValueListResolved.IsDroppedDown == true)
        //                    {
        //                        return;
        //                    }
        //                }

        //                if (rowIndex == 0)
        //                {
        //                    e.Handled = true;
        //                    SetFocus(1);
        //                    // ---ADD 2010/09/09---------------------->>>
        //                    this.Detail_uGrid.ActiveCell = null;
        //                    this.Detail_uGrid.ActiveRow = null;
        //                    // ---ADD 2010/09/09----------------------<<<
        //                }
        //                else
        //                {
        //                    e.Handled = true;
        //                    for (int index = rowIndex - 1; index >= 0; index--)
        //                    {
        //                        if (this.Detail_uGrid.Rows[index].Cells[columnIndex].Activation == Activation.AllowEdit)
        //                        {
        //                            this.Detail_uGrid.Rows[index].Cells[columnIndex].Activate();
        //                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
        //                            return;
        //                        }
        //                    }
        //                }
        //                break;
        //            }
        //        case Keys.Down:
        //            {
        //                if (this.Detail_uGrid.DisplayLayout.Bands[0].Columns[columnIndex].Style == Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList)
        //                {
        //                    if (this.Detail_uGrid.ActiveCell.ValueListResolved.IsDroppedDown == true)
        //                    {
        //                        return;
        //                    }
        //                }

        //                if (rowIndex == this.Detail_uGrid.Rows.Count - 1)
        //                {
        //                    e.Handled = true;
        //                }
        //                else
        //                {
        //                    e.Handled = true;
        //                    for (int index = rowIndex + 1; index < this.Detail_uGrid.Rows.Count; index++)
        //                    {
        //                        if (this.Detail_uGrid.Rows[index].Cells[columnIndex].Activation == Activation.AllowEdit)
        //                        {
        //                            this.Detail_uGrid.Rows[index].Cells[columnIndex].Activate();
        //                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
        //                            return;
        //                        }
        //                    }
        //                }
        //                break;
        //            }
        //        case Keys.Left:
        //            {
        //                if (this.Detail_uGrid.ActiveCell == null)
        //                {
        //                    this.InitGridFocus(0, 0);
        //                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
        //                    return;
        //                }

        //                if (this.Detail_uGrid.ActiveCell.IsInEditMode)
        //                {
        //                    if ((this.Detail_uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Default) ||
        //                        (this.Detail_uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit) ||
        //                        (this.Detail_uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Date))
        //                    {
        //                        if (this.Detail_uGrid.ActiveCell.SelStart == 0)
        //                        {
        //                            e.Handled = true;
        //                            this.Detail_uGrid.PerformAction(UltraGridAction.PrevCellByTab);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        e.Handled = true;
        //                        this.Detail_uGrid.PerformAction(UltraGridAction.PrevCellByTab);
        //                    }
        //                }
        //                else
        //                {
        //                    e.Handled = true;
        //                    this.Detail_uGrid.PerformAction(UltraGridAction.PrevCellByTab);
        //                }
        //                break;
        //            }
        //        case Keys.Right:
        //            {
        //                if (this.Detail_uGrid.ActiveCell == null)
        //                {
        //                    this.InitGridFocus(0, 0);
        //                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
        //                    return;
        //                }

        //                if (Detail_uGrid.ActiveCell.IsInEditMode)
        //                {
        //                    if ((this.Detail_uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Default) ||
        //                        (this.Detail_uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit) ||
        //                        (this.Detail_uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Date))
        //                    {
        //                        if (this.Detail_uGrid.ActiveCell.SelStart >= Detail_uGrid.ActiveCell.Text.Length)
        //                        {
        //                            e.Handled = true;
        //                            this.Detail_uGrid.PerformAction(UltraGridAction.NextCellByTab);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        e.Handled = true;
        //                        this.Detail_uGrid.PerformAction(UltraGridAction.NextCellByTab);
        //                    }
        //                }
        //                else
        //                {
        //                    e.Handled = true;
        //                    this.Detail_uGrid.PerformAction(UltraGridAction.NextCellByTab);
        //                }
        //                break;
        //            }
        //    }

        //}
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
                            // ---ADD 2010/09/09---------------------->>>
                            this.Detail_uGrid.ActiveCell = null;
                            this.Detail_uGrid.ActiveRow = null;
                            // ---ADD 2010/09/09----------------------<<<
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
                                        //if ((int)this.Detail_uGrid.Rows[rowNo].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName].Value == 0) // DEL 2010/09/30 仕様連絡 #15703
                                        //{ // DEL 2010/09/30 仕様連絡 #15703
                                            int targetColumnIndex = GetNextColumnIndexByTab(0, rowIndex, this.masterCode);
                                            if (targetColumnIndex >= 0)
                                            {
                                                this.Detail_uGrid.Rows[rowNo].Cells[targetColumnIndex].Activate();
                                                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                return;
                                            }
                                        }
                                    //} // DEL 2010/09/30 仕様連絡 #15703

                                    SetFocus(1);
                                    this.Detail_uGrid.ActiveCell = null;
                                    this.Detail_uGrid.ActiveRow = null;
                                    return;
                                }
                                // ---ADD 2010/09/25----------------------<<<
                            }
                            SetFocus(1); // ADD 2010/09/09
                            // ---ADD 2010/09/09---------------------->>>
                            this.Detail_uGrid.ActiveCell = null;
                            this.Detail_uGrid.ActiveRow = null;
                            // ---ADD 2010/09/09----------------------<<<
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
                        if (this.Detail_uGrid.ActiveCell == null)
                        {
                            this.InitGridFocus(0, 0);
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }

                        // UPD 2010/09/19 -- >>>>
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
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
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
            // --- ADD 2010/09/09 ---------->>>
            // メーカーコード
            //else if (cell.Column.Key == this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName) // DEL 2010/09/25
            else if (cell.Column.Key == this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName) // ADD 2010/09/25
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                    }
                }
            }
            // 端数処理区分
            else if (cell.Column.Key == this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!KeyPressNumCheck(1, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                    }
                }
            }
            // --- ADD 2010/09/09 ----------<<<
        }

        /// <summary>
        /// Leave イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492対応</br>
        /// </remarks>
        private void Detail_uGrid_Leave(object sender, EventArgs e)
        {
            // ---DEL 2010/09/09---------------------->>>
            //this.Detail_uGrid.ActiveCell = null;
            //this.Detail_uGrid.ActiveRow = null;
            // ---DEL 2010/09/09----------------------<<<
        }

        // ---ADD 2010/09/09---------------------->>>

        /// <summary>
        /// Enter イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にEnterを押された時に発生します。</br>
        /// <br>Programmer  : hanby</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492対応</br>
        /// </remarks>
        private void Detail_uGrid_AfterEnterEditMode(object sender, EventArgs e)
        {
            
            if (this.Detail_uGrid.ActiveCell != null)
            {
                //if (this.Detail_uGrid.ActiveCell.Column.Key.Equals("MasterNm")) // DEL 2010/09/25
                if (this.Detail_uGrid.ActiveCell.Column.Key.Equals(masterCode)) // ADD 2010/09/25
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                    if (this.Detail_uGrid.ActiveCell.Text.Length > 4)
                    {
                        this._preMakerCd = this.Detail_uGrid.ActiveCell.Text.Trim();
                    }
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
            this._prevIndexRow2 = this.Detail_uGrid.ActiveCell.Row.Index;
            this._prevIndexColumn2 = this.Detail_uGrid.ActiveCell.Column.Index;
            
        }
        // ---ADD 2010/09/09----------------------<<<

        /// <summary>
        /// AfterExitEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 編集モードが終了した時に発生します。</br>
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
        /// </remarks>
        private void Detail_uGrid_AfterExitEditMode(object sender, EventArgs e)
        {
            this._errorFlg = false; // ADD 2010/09/25
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
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492対応</br>
        /// <br>Update Note : 2010/09/30</br>
        /// <br>            : Redmine#15703対応</br>
        /// </remarks>
        private void Detail_uGrid_AfterCellUpdate(object sender, CellEventArgs e)
        {
            // ---ADD 2010/09/25---------------------->>>
            if (this._gridGuideFlg == true)
            {
                this._gridGuideFlg = false;
                return;
            }
            // ---ADD 2010/09/25----------------------<<<

            // ---ADD 2010/09/09----------------------<<<
            #region ■端数処理区分チェック
            if (e.Cell.Column.Key == this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName)
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

            int rowIndex = e.Cell.Row.Index;
            int saveFlg = 0;
            // --- ADD 2010/09/09 ---------->>>>>
            if(null==this.Detail_uGrid.ActiveRow)
            {
                return;
            }
            // ---DEL 2010/09/26---------------------->>>
            //if (int.Parse(this.Detail_uGrid.ActiveRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName].Value.ToString()) == 1)
            //{
            //    return;
            //}
            // ---DEL 2010/09/26----------------------<<<
            if (this._errorFlg)
            {
                return;
            }
            // --- ADD 2010/09/09 ----------<<<<<
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
            // ---ADD 2010/09/09---------------------->>>
            if ((this._prevIndexRow2 >= 0) && (this._prevIndexColumn2 >= 0) && (this.Detail_uGrid.ActiveCell == this.Detail_uGrid.Rows[this._prevIndexRow2].Cells[this._prevIndexColumn2]))
            {
                if (this._errorFlg)
                {
                    this._errorFlg = false;
                }
            }
            // ---ADD 2010/09/09----------------------<<<
            
            this.Detail_uGrid.BeginUpdate();
            this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.SaveFlgColumn.ColumnName].Value = saveFlg;
            this.Detail_uGrid.EndUpdate();
            // --- DEL 2010/09/30 仕様連絡 #15703 ---------->>>>>
            // --- ADD 2010/09/26 ---------->>>>>
            //if (int.Parse(this.Detail_uGrid.ActiveRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName].Value.ToString()) == 1)
            //{
            //    return;
            //}
            // --- ADD 2010/09/26 ----------<<<<<
            // --- DEL 2010/09/30 仕様連絡 #15703 ----------<<<<<
            // --- ADD 2010/09/09 ---------->>>>>
            #region
            if (this._searchFlg)
            {
                this._searchFlg = false;
                return;
            }
            //if (this.Detail_uGrid.ActiveCell.Column.Key.Equals(this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName)) // DEL 2010/09/25
            //if (this.Detail_uGrid.ActiveCell.Column.Key.Equals(this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName)) // ADD 2010/09/25 // DEL 2010/09/30 仕様連絡 #15703
            if (this.Detail_uGrid.ActiveCell != null && this.Detail_uGrid.ActiveCell.Column.Key.Equals(this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName)) // ADD 2010/09/30 仕様連絡 #15703
            {
                if (this.Detail_uGrid.ActiveCell.Value != null && !string.IsNullOrEmpty(this.Detail_uGrid.ActiveCell.Value.ToString()))
                {
                    int inputValue;
                    if (this._guidFlg)
                    {
                        inputValue = this._guidCd;
                        this._guidFlg = false;
                    }
                    else 
                    {
                        if (!int.TryParse(this.Detail_uGrid.ActiveCell.Value.ToString(), out inputValue))
                        {
                            // エラー時
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "商品掛率Ｇマスタが未登録です。",
                                -1,
                                MessageBoxButtons.OK);
                            // --- ADD 2010/09/09 ---------->>>>>
                            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = string.Empty;
                            this._errorFlg = true;
                            this._isError = true;
                            this._errorFlg2 = true; // ADD 2010/09/25
                            //this.Detail_uGrid.ActiveCell.SelectAll(); // DEL 2010/09/25
                            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).GoodsRateGrpCode = string.Empty; // ADD 2010/09/25
                            return; // ADD 2010/09/25
                            // --- ADD 2010/09/09 ----------<<<<<
                        }
                        //inputValue = Convert.ToInt32(this.Detail_uGrid.ActiveCell.Value); // ADD 2010/09/09
                    }
                    int rowIndex2 = this.Detail_uGrid.ActiveCell.Row.Index;

                    if (this._errorFlg)
                    {
                        this._errorFlg = false;
                        return;
                    }
                    // 前回値と一致しない場合
                    //if (_prevGoodsRateGrpCode != inputValue) // DEL 2010/09/25
                    //if(inputValue != 0) // ADD 2010/09/25
                    //{ // DEL 2010/09/25
                        // --- DEL 2010/09/25 ---------->>>>>
                        //// 入力無し
                        //if (inputValue == 0)
                        //{
                        //    this.Detail_uGrid.ActiveCell.Value = 0;
                        //}
                        //else
                        // --- DEL 2010/09/25 ----------<<<<<
                        //{ // DEL 2010/09/25
                            string name = GetGoodsMGroupName(inputValue);
                            if (!string.IsNullOrEmpty(name))
                            {
                                this.Detail_uGrid.ActiveCell.Activation = Activation.NoEdit;
                                ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex2]).MasterNm = name;
                                //((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex2]).GoodsRateGrpCode = inputValue;// DEL 2010/09/25
                                ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex2]).GoodsRateGrpCode = inputValue.ToString("D4");// ADD 2010/09/25
                                this._prevGoodsRateGrpCode = inputValue;
                                this._searchFlg = true;
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
                                // --- ADD 2010/09/09 ---------->>>>>
                                ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = string.Empty;
                                ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).GoodsRateGrpCode = string.Empty; // ADD 2010/09/25
                                //this._errorFlg = true;
                                //this.Detail_uGrid.ActiveCell.SelectAll(); // DEL 2010/09/25
                                this._errorFlg = true; // ADD 2010/09/25
                                this._errorFlg2 = true; // ADD 2010/09/25
                                // --- ADD 2010/09/09 ----------<<<<<
                            }
                        //} // DEL 2010/09/25
                    //} // DEL 2010/09/25
                    // --- DEL 2010/09/25 ---------->>>>>
                    //else 
                    //{
                    //    if (inputValue != 0 && !this._errorFlg) 
                    //    {
                    //        this.Detail_uGrid.ActiveCell.Activation = Activation.NoEdit;
                    //        ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex2]).MasterNm = GetGoodsMGroupName(inputValue);
                    //        ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex2]).GoodsRateGrpCode = inputValue;
                    //        this._prevGoodsRateGrpCode = inputValue;
                    //        this._searchFlg = true;
                    //    }
                    //    if (inputValue == 0)
                    //    {
                    //        if (this._searchFlg)
                    //        {
                    //            this._searchFlg = false;
                    //            return;
                    //        }
                    //        else
                    //        {
                    //            // エラー時
                    //            TMsgDisp.Show(
                    //                this,
                    //                emErrorLevel.ERR_LEVEL_INFO,
                    //                this.Name,
                    //                "商品掛率Ｇマスタが未登録です。",
                    //                -1,
                    //                MessageBoxButtons.OK);
                    //            // --- ADD 2010/09/09 ---------->>>>>
                    //            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = string.Empty;
                    //            ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).GoodsRateGrpCode = 0; // ADD 2010/09/25

                    //            this.Detail_uGrid.ActiveCell.SelectAll();
                    //            // --- ADD 2010/09/09 ----------<<<<<
                    //        }
                    //    }
                    //}
                    // --- DEL 2010/09/25 ----------<<<<<
                }
            }
            #endregion
            // --- ADD 2010/09/09 ----------<<<<<

        }

        /// <summary>
        /// Button_Click イベント(CustomerGuide_Button)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 得意先ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: 高峰</br>
        /// <br>Date		: 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492対応</br>
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
                        this.Search(); // ADD 2010/09/09
                        // -------ADD 2010/09/28----------->>>>>
                        if (this._isCancelFlg)
                        {
                            this._isCancelFlg = false;
                            return;
                        }
                        else if (this.Detail_uGrid.Rows.Count != 0 && this._checkInputScreenErr == false)
                        {
                            if (this.Mode_Label.Text == INSERT_MODE)
                            {
                                if (!this._initFocusFlag)
                                {
                                    this.Detail_uGrid.Focus();
                                    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                    this.Detail_uGrid.Rows[0].Cells[masterCode].Activate();
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
                                this.Detail_uGrid.Rows[0].Cells[masterCode].Activate();
                                ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                                this.SetGridTabFocus(ref evt);
                            }
                        }
                        this._isCancelFlg = false;
                        this._checkInputScreenErr = false;
                        // -------ADD 2010/09/28-----------<<<<<
                    }
                }
                // ---ADD 2010/09/09---------------------->>>
                #region　■ガイド有効無効の設定
                if (this.tNedit_CustomerCode.Focused || this.tNedit_CustRateGrpCodeZero.Focused || this.tNedit_SupplierCd.Focused || tNedit_GoodsMakerCd.Focused)
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                }
                #endregion
                // ---ADD 2010/09/09----------------------<<<
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
        /// <br>Programmer	: 高峰</br>
        /// <br>Date		: 2010/08/19</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }

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
        /// <br>Programmer	: 高峰</br>
        /// <br>Date		: 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492対応</br>
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
                        this.Search(); // ADD 2010/09/09
                        // -------ADD 2010/09/28----------->>>>>
                        if (this._isCancelFlg)
                        {
                            this._isCancelFlg = false;
                            return;
                        }
                        else if (this.Detail_uGrid.Rows.Count != 0 && this._checkInputScreenErr == false)
                        {
                            if (this.Mode_Label.Text == INSERT_MODE)
                            {
                                if (!this._initFocusFlag)
                                {
                                    this.Detail_uGrid.Focus();
                                    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                    this.Detail_uGrid.Rows[0].Cells[masterCode].Activate();
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
                                this.Detail_uGrid.Rows[0].Cells[masterCode].Activate();
                                ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                                this.SetGridTabFocus(ref evt);
                            }
                        }
                        this._isCancelFlg = false;
                        this._checkInputScreenErr = false;
                        // -------ADD 2010/09/28-----------<<<<<
                    }
                }
                // ---ADD 2010/09/09---------------------->>>
                #region　■ガイド有効無効の設定
                if (this.tNedit_CustomerCode.Focused || this.tNedit_CustRateGrpCodeZero.Focused || this.tNedit_SupplierCd.Focused || tNedit_GoodsMakerCd.Focused)
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                }
                #endregion
                // ---ADD 2010/09/09----------------------<<<
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
        /// <br>Programmer	: 高峰</br>
        /// <br>Date		: 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492対応</br>
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
                        this.Search(); // ADD 2010/09/09
                        // -------ADD 2010/09/28----------->>>>>
                        if (this._isCancelFlg)
                        {
                            this._isCancelFlg = false;
                            return;
                        }
                        else if (this.Detail_uGrid.Rows.Count != 0 && this._checkInputScreenErr == false)
                        {
                            if (this.Mode_Label.Text == INSERT_MODE)
                            {
                                if (!this._initFocusFlag)
                                {
                                    this.Detail_uGrid.Focus();
                                    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                    this.Detail_uGrid.Rows[0].Cells[masterCode].Activate();
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
                                this.Detail_uGrid.Rows[0].Cells[masterCode].Activate();
                                ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                                this.SetGridTabFocus(ref evt);
                            }
                        }
                        this._isCancelFlg = false;
                        this._checkInputScreenErr = false;
                        // -------ADD 2010/09/28-----------<<<<<
                    }
                }

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
        /// <br>Programmer	: 高峰</br>
        /// <br>Date		: 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492対応</br>
        /// <br>Update Note : 2010/09/26 呉元嘯</br>
        /// <br>            : Redmine#14492対応</br>
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
                    // ---------UPD 2010/09/26--------->>>>>
                    //if (userGdBd.GuideCode == 0)
                    //{
                    //    this.tNedit_CustomerCode.Clear();
                    //    this.tEdit_CustRateGrpNm.Clear();
                    //}
                    //else
                    //{
                    //    this.tNedit_CustRateGrpCodeZero.DataText = userGdBd.GuideCode.ToString("D4");
                    //    this.tEdit_CustRateGrpNm.DataText = userGdBd.GuideName;
                    //}
                    this.tNedit_CustRateGrpCodeZero.DataText = userGdBd.GuideCode.ToString("D4");
                    this.tEdit_CustRateGrpNm.DataText = userGdBd.GuideName;
                    // ---------UPD 2010/09/26---------<<<<<
                    this._prevCustRateGrpCode = userGdBd.GuideCode;
                    // フォーカス設定
                    bool focusCheck = SetFocus(3);
                    if (focusCheck == false)
                    {
                        //SearchRateData();
                        this.Search(); // ADD 2010/09/09
                        // -------ADD 2010/09/28----------->>>>>
                        if (this._isCancelFlg)
                        {
                            this._isCancelFlg = false;
                            return;
                        }
                        else if (this.Detail_uGrid.Rows.Count != 0 && this._checkInputScreenErr == false)
                        {
                            if (this.Mode_Label.Text == INSERT_MODE)
                            {
                                if (!this._initFocusFlag)
                                {
                                    this.Detail_uGrid.Focus();
                                    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
                                    this.Detail_uGrid.Rows[0].Cells[masterCode].Activate();
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
                                this.Detail_uGrid.Rows[0].Cells[masterCode].Activate();
                                ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                                this.SetGridTabFocus(ref evt);
                            }
                        }
                        this._isCancelFlg = false;
                        this._checkInputScreenErr = false;
                        // -------ADD 2010/09/28-----------<<<<<
                    }
                }
                // ---ADD 2010/09/09---------------------->>>
                #region　■ガイド有効無効の設定
                if (this.tNedit_CustomerCode.Focused || this.tNedit_CustRateGrpCodeZero.Focused || this.tNedit_SupplierCd.Focused || tNedit_GoodsMakerCd.Focused)
                {
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
                }
                #endregion
                // ---ADD 2010/09/09----------------------<<<
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
        /// <br>Programmer	: 高峰</br>
        /// <br>Date		: 2010/08/19</br>
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
        /// <br>Programmer  : 高峰</br>
        /// <br>Date		: 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
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

        #endregion Event

        #region Private Method

        /// <summary>
        /// アイコン設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : ツールバーとボタンのアイコンを設定します。</br>
        /// <br>Programmer	: 高峰</br>
        /// <br>Date		: 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492対応</br>
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
            // 全削除
            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_ALLROWDELETE_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ROWDELETE;
            // ガイド
            this.tToolbarsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
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
        }

        /// <summary>
        /// フォーカス設定処理
        /// </summary>
        /// <param name="mode">モード</param>
        /// <returns>status:(mode = 3時有効)</returns>
        /// <remarks>
        /// <br>Note        : ガイドボタン押下後のフォーカス設定を行います。</br>
        /// <br>Programmer	: 高峰</br>
        /// <br>Date		: 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
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
                //case 2:
                //    {
                //        if (_endButtonFocus != null)
                //        {
                //            ((UltraButton)_endButtonFocus).Focus();
                //        }
                //        break;
                //    }
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
                #endregion Grid->抽出条件部(shift + Tab)

                #region Nextフォーカス設定
                case 3:
                    {
                        // 得意先
                        if (this.tNedit_CustomerCode.Focused || this.CustomerGuide_Button.Focused)
                        {
                            if (this.tNedit_CustRateGrpCodeZero.Enabled)
                            {
                                this.tNedit_CustRateGrpCodeZero.Focus();
                            }
                            else if (this.tNedit_SupplierCd.Enabled)
                            {
                                this.tNedit_SupplierCd.Focus();
                            }
                            else if (this.tNedit_GoodsMakerCd.Enabled)
                            {
                                this.tNedit_GoodsMakerCd.Focus();
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
                            else if (this.tNedit_GoodsMakerCd.Enabled)
                            {
                                this.tNedit_GoodsMakerCd.Focus();
                            }
                            else
                            {
                                status = false;
                            }
                        }
                        // 仕入先
                        else if (this.tNedit_SupplierCd.Focused || this.SupplierGuide_Button.Focused)
                        {
                            if (this.tNedit_GoodsMakerCd.Enabled)
                            {
                                this.tNedit_GoodsMakerCd.Focus();
                            }
                            else
                            {
                                status = false;
                            }
                        }
                        // メーカー
                        else if (this.tNedit_GoodsMakerCd.Focused || this.MakerGuide_Button.Focused)
                        {
                            status = false;
                        }
                        break;
                    }
                #endregion Nextフォーカス設定

                #region 抽出条件部(shift + Tab)
                case 4:
                    {
                        // 得意先掛率グループ
                        if (this.tNedit_CustRateGrpCodeZero.Focused || this.CustRateGrpGuide_Button.Focused)
                        {
                            if (this.tNedit_CustomerCode.Enabled)
                            {
                                this.CustomerGuide_Button.Focus();
                            }
                        }
                        // 仕入先
                        else if (this.tNedit_SupplierCd.Focused || this.SupplierGuide_Button.Focused)
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
            if (this.tNedit_CustomerCode.Focused || this.tNedit_CustRateGrpCodeZero.Focused || this.tNedit_SupplierCd.Focused || tNedit_GoodsMakerCd.Focused)
            {
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"].SharedProps.Enabled = true;
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
            }
            #endregion
            // --------ADD 2010/09/09--------<<<

            return status;
        }

        /// <summary>
        /// 得意先掛率グループ名称取得処理
        /// </summary>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        /// <param name="custRateGrpName">得意先掛率グループ名称</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note        : なし</br>
        /// <br>Programmer	: 高峰</br>
        /// <br>Date		: 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492対応</br>
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
            // --------UPD 2010/09/09--------<<<<<<

            return check;
        }

        /// <summary>
        /// 得意先掛率グループ情報取得処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : なし</br>
        /// <br>Programmer	: 高峰</br>
        /// <br>Date		: 2010/08/19</br>
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
        /// <br>Programmer	: 高峰</br>
        /// <br>Date		: 2010/08/19</br>
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
        /// <br>Programmer	: 高峰</br>
        /// <br>Date		: 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492対応</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.Mode_Label.Text = INSERT_MODE;
            // ----------UPD 2010/09/09----------->>>>>
            this.ultraLabel_RateMngGoodsNm.Text = this._rateProtyMng.RateMngGoodsNm.Trim();
            // 指定なし非表示
            //if (this._rateProtyMng.RateMngCustCd.Trim() == RATEMNGCUSTCD_NONE)
            //{
            //    this.ultraLabel_RateMngCustNm.Text = string.Empty;
            //}
            //else
            //{
            //    this.ultraLabel_RateMngCustNm.Text = this._rateProtyMng.RateMngCustNm.Trim();
            //}
            //this.ultraLabel_RateMngGoodsNm.Text = this._rateProtyMng.RateMngGoodsNm.Trim();
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

            ScreenToRateProtyMngPattern(ref this._rateProtyMngPatternWorkClone);
            this._prevMakerCode = 0;
            this._prevCustRateGrpCode = -1;
            this._prevCustomerCode = 0;
            this._prevSupplierCode = 0;

            this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows.Clear();

            this._prevGoodsRateGrpCode = 0; // ADD 2010/09/09
            this._preUnPrcFracProcDivNmCell = null; // ADD 2010/09/09

            // フォーカス設定
            this.SetFocus(0);
        }

        /// <summary>
        /// 掛率設定区分により、得意先、得意先掛率グループ、仕入先の項目を入力可否の変更。
        /// </summary>
        /// <remarks>
        /// <br>Note        : 掛率設定区分により、得意先、得意先掛率グループ、仕入先の項目を入力可否を変更する。</br>
        /// <br>Programmer	: 高峰</br>
        /// <br>Date		: 2010/08/19</br>
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
                        this.CustomerCodeNm_tEdit.Enabled = true;
                        this.CustomerGuide_Button.Enabled = true;
                        //得意先掛率ｸﾞﾙｰﾌﾟ
                        this.tNedit_CustRateGrpCodeZero.Enabled = false;
                        this.tEdit_CustRateGrpNm.Enabled = false;
                        this.CustRateGrpCode_Label.Enabled = false;
                        this.CustRateGrpGuide_Button.Enabled = false;
                        //仕入先
                        this.tNedit_SupplierCd.Enabled = true;
                        this.SupplierCd_Label.Enabled = true;
                        this.SupplierCdNm_tEdit.Enabled = true;
                        this.SupplierGuide_Button.Enabled = true;

                        this._initFocus = this.tNedit_CustomerCode;
                        this._endFocus = this.tNedit_SupplierCd;
                        this._endButtonFocus = this.SupplierGuide_Button;
                        break;
                    }
                case "2":// 得意先
                    {
                        // 得意先
                        this.tNedit_CustomerCode.Enabled = true;
                        this.CustomerCode_Label.Enabled = true;
                        this.CustomerCodeNm_tEdit.Enabled = true;
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
                        this.tEdit_CustRateGrpNm.Enabled = true;
                        this.CustRateGrpCode_Label.Enabled = true;
                        this.CustRateGrpGuide_Button.Enabled = true;
                        //仕入先
                        this.tNedit_SupplierCd.Enabled = true;
                        this.SupplierCd_Label.Enabled = true;
                        this.SupplierCdNm_tEdit.Enabled = true;
                        this.SupplierGuide_Button.Enabled = true;

                        this._initFocus = this.tNedit_CustRateGrpCodeZero;
                        this._endFocus = this.tNedit_SupplierCd;
                        this._endButtonFocus = this.SupplierGuide_Button;

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
                        this.tEdit_CustRateGrpNm.Enabled = true;
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
                        this.SupplierCdNm_tEdit.Enabled = true;
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

                        this._initFocus = this.tNedit_GoodsMakerCd;
                        this._endFocus = this.tNedit_GoodsMakerCd;
                        this._endButtonFocus = this.MakerGuide_Button;
                        break;
                    }
            }
            #endregion [掛率設定区分（得意先）]

            #region [掛率設定区分（商品）]
            switch (this._rateProtyMng.RateMngGoodsCd.Trim())
            {
                case "F": // ﾒｰｶｰ + 商品掛率G
                    {
                        // メーカー
                        this.tNedit_GoodsMakerCd.Enabled = true;
                        this.GoodsMakerCd_Grp_Label.Enabled = true;
                        this.MakerName_tEdit.Enabled = true;
                        this.MakerGuide_Button.Enabled = true;

                        this._endFocus = this.tNedit_GoodsMakerCd;
                        this._endButtonFocus = this.MakerGuide_Button;

                        break;
                    }
                case "J": // 入力可
                    {
                        // メーカー
                        this.tNedit_GoodsMakerCd.Enabled = false;
                        this.GoodsMakerCd_Grp_Label.Enabled = false;
                        this.MakerName_tEdit.Enabled = false;
                        this.MakerGuide_Button.Enabled = false;

                        break;
                    }
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
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/08/19</br>
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
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
        /// </remarks>
        private void SetUp()
        {
            PMKHN09475UB pMKHN09477UB = new PMKHN09475UB();
            pMKHN09477UB.ShowDialog();

            this._cellMove = pMKHN09477UB.CellMove;
        }

        /// <summary>
        /// グリッドフォーカス設定処理
        /// </summary>
        /// <param name="mode">モード</param>
        /// <param name="rowIndex">グリッド行</param>
        /// <remarks>
        /// <br>Note        : グリッドフォーカス設定を行います。</br>
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
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
                        // 売価場合
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

                        // メーカーコード
                        //this.Detail_uGrid.Rows[0].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Activate(); // DEL 2010/09/25
                        this.Detail_uGrid.Rows[0].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName].Activate(); // ADD 2010/09/25
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
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492対応</br>
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
                        columnName = this.GetGridInitColumKey();
                        //for (int targetRowIndex = rowIndex + 1; targetRowIndex < this.Detail_uGrid.Rows.Count; targetRowIndex++)
                        //{
                        //    if (this.Detail_uGrid.Rows[targetRowIndex].Cells[columnName].Activation == Activation.AllowEdit)
                        //    {
                        //        this.Detail_uGrid.Rows[targetRowIndex].Cells[columnName].Activate();
                        //        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        //        return;
                        //    }
                        //}
                        // ---------DEL 2010/09/09---------->>>>>
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
                        // ---------DEL 2010/09/09----------<<<<<
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
                    else
                    {
                        this.Detail_uGrid.Rows[rowIndex].Cells[columnKey].Activate();
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
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
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492対応</br>
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

            // セル移動：右
            if (this._cellMove == 0)
            {
                if ((rowIndex == 0) &&
                    (columnKey == GetGridInitColumKey()))
                {
                    //SetFocus(2); // DEL 2010/09/09
                    // ---------ADD 2010/09/09---------->>>>>
                    this.Detail_uGrid.ActiveCell = null;
                    this.Detail_uGrid.ActiveRow = null;
                    this.MakerGuide_Button.Focus();
                    // ---------ADD 2010/09/09----------<<<<<
                    e.NextCtrl = null;
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
                        //SetFocus(2); // DEL 2010/09/09
                        // ---------ADD 2010/09/09---------->>>>>
                        this.Detail_uGrid.ActiveCell = null;
                        this.Detail_uGrid.ActiveRow = null;
                        this.MakerGuide_Button.Focus();
                        // ---------ADD 2010/09/09----------<<<<<
                        e.NextCtrl = null;
                    }
                }
            }
            // セル移動：下
            else
            {
                if ((rowIndex == 0) &&
                    (columnKey == GetGridInitColumKey()))
                {
                    //SetFocus(2); // DEL 2010/09/09
                    // ---------ADD 2010/09/09---------->>>>>
                    this.Detail_uGrid.ActiveCell = null;
                    this.Detail_uGrid.ActiveRow = null;
                    this.MakerGuide_Button.Focus();
                    // ---------ADD 2010/09/09----------<<<<<
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
                        SetFocus(2); // DEL 2010/09/09
                        // ---------ADD 2010/09/09---------->>>>>
                        this.Detail_uGrid.ActiveCell = null;
                        this.Detail_uGrid.ActiveRow = null;
                        //this.MakerGuide_Button.Focus();
                        // ---------ADD 2010/09/09----------<<<<<
                        return;
                    } 
                    if (columnIndex == 1)
                    {
                        this.Detail_uGrid.Rows[this.Detail_uGrid.Rows.Count - 1].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsNoColumn.ColumnName].Activate();
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
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
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
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
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492対応</br>
        /// </remarks>
        private string GetGridInitColumKey()
        {
            string initColumKey = string.Empty;

            // ---UPD 2010/09/09---------------------->>>
            // 売価場合
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
            // メーカーコード
            //initColumKey = this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName; // DEL 2010/09/25
            initColumKey = this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName; // ADD 2010/09/25
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
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
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
                        // メーカーコード
                        //else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName) // DEL 2010/09/25
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName) // ADD 2010/09/25
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
                        // メーカーコード
                        //else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName) // DEL 2010/09/25
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName) // ADD 2010/09/25
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
                        // メーカーコード
                        //else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName) // DEL 2010/09/25
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName) // ADD 2010/09/25
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
                        // 売価率
                        //if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName)
                        //{
                        //    columnIndex = -1;
                        //}
                        // メーカーコード
                        //if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName) // DEL 2010/09/25
                        if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName) // ADD 2010/09/25
                        {
                            columnIndex = -1;
                        }
                        // 売価率
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName)
                        {
                            // メーカーコード
                            //columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Column.Index; // DEL 2010/09/25
                            columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName].Column.Index; // ADD 2010/09/25
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
                        // 仕入率
                        //if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName)
                        //{
                        //    columnIndex = -1;
                        //}
                        // メーカーコード
                        //if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName) // DEL 2010/09/25
                        if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName) // ADD 2010/09/25
                        {
                            columnIndex = -1;
                        }
                        // 仕入率
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.RateValColumn.ColumnName)
                        {
                            // メーカーコード
                            //columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Column.Index; // DEL 2010/09/25
                            columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName].Column.Index; // ADD 2010/09/25
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
                        // メーカーコード
                        //if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName) // DEL 2010/09/25
                        if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName) // ADD 2010/09/25
                        {
                            columnIndex = -1;
                        }
                        // 定価UP率
                        else if (columnKey == this._rateProtyMngPatternDataSet.RateProtyMngPattern.UpRateColumn.ColumnName)
                        {
                            // メーカーコード
                            //columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Column.Index; // DEL 2010/09/25
                            columnIndex = this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName].Column.Index; // ADD 2010/09/25
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
        /// <param name="customerName">得意先名称</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note        : 得意先名称を取得します。</br>
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
        /// </remarks>
        private bool GetCustomerName(int customerCode, out string customerName)
        {
            customerName = "";
            bool check = false;

            try
            {
                CustomerInfo customerInfo;

                int status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
                if (status == 0)
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
        /// <param name="supplierName">仕入先名称</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note        : 仕入先名称を取得します。</br>
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492対応</br>
        /// </remarks>
        private bool GetSupplierName(int supplierCode, out string supplierName)
        {
            supplierName = "";
            bool check = false;

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
            //        check = true;
            //    }
            //}
            //catch
            //{
            //    supplierName = "";
            //}

            Supplier supplier;
            int status = this._supplierAcs.Read(out supplier, this._enterpriseCode, supplierCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && supplier != null && supplier.LogicalDeleteCode == 0)
            {
                supplierName = supplier.SupplierSnm;
                check = true;
            }
            // ----------UPD 2010/09/09-----------<<<<<

            return check;
        }

        /// <summary>
        /// 画面新規処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面新規処理します。</br>
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
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
                        //"更新データありません。",  	            // 表示するメッセージ // DEL 2010/09/09
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
        /// <param name="makerName">メーカー名称</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note        : メーカー名称を取得します。</br>
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
        /// </remarks>
        private bool GetMakerName(int makerCode, out string makerName)
        {
            makerName = "";
            bool check = false;

            try
            {
                if (this._makerUMntDic == null)
                {
                    LoadMakerUMnt();
                }

                if (this._makerUMntDic.ContainsKey(makerCode))
                {
                    makerName = this._makerUMntDic[makerCode].MakerName.Trim();
                    check = true;
                }
            }
            catch
            {
                makerName = "";
            }

            return check;
        }

        /// <summary>
        /// 仕入先マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 仕入先マスタ読込処理を行います。</br>
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
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
                        this._supplierDic.Add(supplier.SupplierCd, supplier);
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
        /// <br>Note        : メーカーマスタ読込処理を行います。</br>
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
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
        /// <br>Note        : 画面閉じる前のチェック処理します。</br>
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
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
                foreach (UltraGridRow ultraRow in this.Detail_uGrid.Rows) {
                    if ((int)ultraRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.SaveFlgColumn.ColumnName].Value == 1)
                    {
                        inputStatus = false;
                        break;
                    }
                }
            }
            return inputStatus;
        }

        ///// <summary>
        ///// 数値入力チェック処理
        ///// </summary>
        ///// <param name="keta">桁数(マイナス符号を含まず)</param>
        ///// <param name="priod">小数点以下桁数</param>
        ///// <param name="prevVal">現在の文字列</param>
        ///// <param name="key">入力されたキー値</param>
        ///// <param name="selstart">カーソル位置</param>
        ///// <param name="sellength">選択文字長</param>
        ///// <param name="minusFlg">マイナス入力可？</param>
        ///// <returns>true=入力可,false=入力不可</returns>
        ///// <remarks>
        ///// <br>Note        : 数値の入力チェックを行います。</br>
        ///// <br>Programmer  : 高峰</br>
        ///// <br>Date        : 2010/08/19</br>
        ///// </remarks>
        //private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        //{
        //    // 制御キーが押された？
        //    if (Char.IsControl(key))
        //    {
        //        return true;
        //    }
        //    // 数値以外は、ＮＧ
        //    if (!Char.IsDigit(key))
        //    {
        //        // 小数点または、マイナス以外
        //        if ((key != '.') && (key != '-'))
        //        {
        //            return false;
        //        }
        //    }

        //    // キーが押されたと仮定した場合の文字列を生成する。
        //    string strResult = "";
        //    if (sellength > 0)
        //    {
        //        strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
        //    }
        //    else
        //    {
        //        strResult = prevVal;
        //    }

        //    // マイナスのチェック
        //    if (key == '-')
        //    {
        //        if ((minusFlg == false) || (selstart > 0) || (strResult.IndexOf('-') != -1))
        //        {
        //            return false;
        //        }
        //    }

        //    // 小数点のチェック
        //    if (key == '.')
        //    {
        //        if ((priod <= 0) || (strResult.IndexOf('.') != -1))
        //        {
        //            return false;
        //        }
        //    }
        //    // キーが押された結果の文字列を生成する。
        //    strResult = prevVal.Substring(0, selstart)
        //        + key
        //        + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

        //    // 桁数チェック！
        //    if (strResult.Length > keta)
        //    {
        //        if (strResult[0] == '-')
        //        {
        //            if (strResult.Length > (keta + 1))
        //            {
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }

        //    // 小数点以下のチェック
        //    if (priod > 0)
        //    {
        //        // 小数点の位置決定
        //        int _pointPos = strResult.IndexOf('.');

        //        // 整数部に入力可能な桁数を決定！
        //        int _Rketa = (strResult[0] == '-') ? keta - priod : keta - priod - 1;
        //        // 整数部の桁数をチェック
        //        if (_pointPos != -1)
        //        {
        //            if (_pointPos > _Rketa)
        //            {
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            if (strResult.Length > _Rketa)
        //            {
        //                return false;
        //            }
        //        }

        //        // 小数部の桁数をチェック
        //        if (_pointPos != -1)
        //        {
        //            // 小数部の桁数を計算
        //            int _priketa = strResult.Length - _pointPos - 1;
        //            if (priod < _priketa)
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    return true;
        //}

        /// <summary>
        /// 抽出条件によって、掛率マスタの読み込み処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 抽出条件によって、掛率マスタの読み込みを行います。</br>
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492対応</br>
        /// </remarks>
        /// <returns></returns>
        //private void SearchRateData() // DEL 2010/09/25
        private int SearchRateData() // ADD 2010/09/25
        {
            // オフライン状態チェック
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "画面検索処理に失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                //return; // DEL 2010/09/25
                return -1; // ADD 2010/09/25
            }

            // 入力内容をチェックする
            if (!this.CheckInputScreen())
            {
                //return; // DEL 2010/09/25
                return -1; // ADD 2010/09/25
            }
            int status = 0;

            // --- DEL 2010/09/09 ---------->>>>>
            //#region 抽出条件取得とCompare
            //if (CompareScreenData() && this.Detail_uGrid.Rows.Count > 0)
            //{
            //    this.Detail_uGrid.Focus();
            //    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[0];
            //    this.InitGridFocus(0, 0);
            //    return;
            //}
            // --- DEL 2010/09/09 ----------<<<<<
            this.ScreenToRateProtyMngPattern(ref this._rateProtyMngPatternWorkClone);
            //#endregion 抽出条件取得とCompare// DEL 2010/09/09

            this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows.Clear();

            // 掛率マスタ込み読み
            ArrayList goodsList = new ArrayList();
            ArrayList rateList = new ArrayList();
            string errMess = string.Empty;
            status = this._rateProtyMngPatternAcs.SearchRateRelationData(this._rateProtyMngPatternWorkClone, out goodsList, out rateList, 4, out errMess);

            #region 検索結果
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                if (rateList.Count > 0)
                {
                    // --- UPD 2010/09/09 ---------->>>>>
                //    DialogResult dr = TMsgDisp.Show(
                //                emErrorLevel.ERR_LEVEL_QUESTION,
                //                CT_PGID,
                //                "現在、登録済のデータが存在します\n\n" + "更新してもよいですか？",
                //                0,
                //                MessageBoxButtons.YesNo);
                //    switch (dr)
                //    {
                //        //"いいえ(N)"を押下した場合、新規モードとして、ＢＬコードマスタよりコード、名称を表示
                //        case DialogResult.No:
                //            this.Mode_Label.Text = INSERT_MODE;
                //            this._rateProtyMngPatternAcs.CopyToRateRelationDataSet(goodsList);
                //            break;
                //        //"はい(Y)"を押下した場合、更新モードとして登録分データを表示
                //        case DialogResult.Yes:
                //            this.Mode_Label.Text = UPDATE_MODE;
                //            this._rateProtyMngPatternAcs.CopyToRateRelationDataSet(rateList);
                //            break;
                    //    }
                    // --- UPD 2010/09/09 ----------<<<<<
                    this.Mode_Label.Text = UPDATE_MODE;
                    this._rateProtyMngPatternAcs.CopyToRateRelationDataSet(rateList);
                    // --- ADD 2010/09/09 ---------->>>>>
                    foreach (RateProtyMngPatternDataSet.RateProtyMngPatternRow row in this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows)
                    {
                        if ("".Equals(row.MasterNm))
                        {
                            break;
                        }
                        row.MasterNm = row.MasterNm.Substring(5, row.MasterNm.Length - 5);
                    }
                    for (int i = 0; i < rateList.Count; i++)
                    {
                        if (((RateRlationWork)rateList[i]).UpdateLineFlg)
                        {
                            //this.Detail_uGrid.Rows[i].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; // DEL 2010/09/25
                            this.Detail_uGrid.Rows[i].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; // ADD 2010/09/25
                        }
                    }
                    // --- ADD 2010/09/09 ----------<<<<<

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
            return status; // ADD 2010/09/25
            #endregion 検索結果
        }

        /// <summary>
		/// 画面入力チェック
		/// </summary>
        /// <remarks>
        /// <br>Note        : 画面入力チェック処理します。</br>
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
        /// </remarks>
        /// <returns></returns>
        private bool CheckInputScreen()
        {
            bool checkStatus = true;

            // 得意先
            if (this.tNedit_CustomerCode.Enabled && this.tNedit_CustomerCode.GetInt() == 0)
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "得意先を入力して下さい。",
                0,
                MessageBoxButtons.OK);
                this.tNedit_CustomerCode.Focus();
                checkStatus = false;
                this._checkInputScreenErr = true; // ADD 2010/09/09
                // --- ADD 2010/09/09 ---------->>>>>
                this._checkScreanInput = checkStatus;
                // --- ADD 2010/09/09 ----------<<<<<
                return checkStatus;
            }

            // 得意先掛率ｸﾞﾙｰﾌﾟ
            if (this.tNedit_CustRateGrpCodeZero.Enabled && this.tNedit_CustRateGrpCodeZero.DataText.Trim() == "")
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "得意先掛率ｸﾞﾙｰﾌﾟを入力して下さい。",
                0,
                MessageBoxButtons.OK);
                this.tNedit_CustRateGrpCodeZero.Focus();
                checkStatus = false;
                this._checkInputScreenErr = true; // ADD 2010/09/09
                return checkStatus;
            }

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
                this._checkInputScreenErr = true; // ADD 2010/09/09
                return checkStatus;
            }

            // メーカー
            if (this.tNedit_GoodsMakerCd.Enabled && this.tNedit_GoodsMakerCd.GetInt() == 0)
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "メーカーを入力して下さい。",
                0,
                MessageBoxButtons.OK);
                this.tNedit_GoodsMakerCd.Focus();
                checkStatus = false;
                this._checkInputScreenErr = true; // ADD 2010/09/09
                return checkStatus;
            }

            return checkStatus;
        }

        /// <summary>
        /// 画面抽出条件部データチェック
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面抽出条件部データチェック処理します。</br>
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
        /// </remarks>
        /// <returns></returns>
        private bool CompareScreenData()
        {
            return ((this.tNedit_CustomerCode.GetInt() == this._rateProtyMngPatternWorkClone.CustomerCode)
                 && (this.tNedit_CustRateGrpCodeZero.GetInt() == this._rateProtyMngPatternWorkClone.CustRateGrpCode)
                 && (this.tNedit_SupplierCd.GetInt() == this._rateProtyMngPatternWorkClone.SupplierCd)
                 && (this.tNedit_GoodsMakerCd.GetInt() == this._rateProtyMngPatternWorkClone.GoodsMakerCd));
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
        /// <remarks>
        /// <br>Note        : 画面を排他処理します。</br>
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
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
        /// <br>Note        : 保存前チェック処理を行います。</br>
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/08/31 呉元嘯</br>
        /// <br>            : Redmine#14030対応</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492対応</br>
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
                        else if ((string)ultraRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.UnPrcFracProcDivNmColumn.ColumnName].Value == string.Empty)
                        {
                            checkFlg = false;
                            rowIndexName = "UnPrcFracProcDivNm";
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
        /// <br>Note        : 行削除処理を行います。</br>
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Update Note : 2010/09/09 hanby</br>
        /// <br>            : Redmine#14492対応</br>
        /// <br>Update Note : 2010/09/30</br>
        /// <br>            : Redmine#15703対応</br>
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

                if ((Int32)this.Detail_uGrid.ActiveRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName].Value == 0) // ADD 2010/09/30 仕様連絡 #15703
                { // ADD 2010/09/30 仕様連絡 #15703
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
                // --- ADD 2010/09/30 仕様連絡 #15703 ---------->>>>>
                }
                else
                {
                    // 行削除解除時BackColorの設定
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
                    // 行削除解除データが対象
                    this.Detail_uGrid.ActiveRow.Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.SaveFlgColumn.ColumnName].Value = 0;
                }
                // --- ADD 2010/09/30 仕様連絡 #15703 ----------<<<<<
                // セルActivation設定
                //this.SetCellActivation(this.Detail_uGrid.Rows[rowIndex]); // DEL 2010/09/30 仕様連絡 #15703
                this.Detail_uGrid.EndUpdate();

            }
            finally
            {
                // ---UPD 2010/09/25--------->>>>>
                this.Cursor = Cursors.Default;
                // --- ADD 2010/09/30 仕様連絡 #15703 ---------->>>>>
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
                //        for (int targetRowIndex = 0; targetRowIndex < this.Detail_uGrid.Rows.Count; targetRowIndex++)
                //        {
                //            if (this.Detail_uGrid.Rows[targetRowIndex].Cells[masterCode].Activation == Activation.AllowEdit)
                //            {
                //                this.Detail_uGrid.Rows[targetRowIndex].Cells[masterCode].Activate();
                //                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                //                break;
                //            }
                //        }
                //    }

                //    this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);
                //    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                //}
                // --- ADD 2010/09/30 仕様連絡 #15703 ----------<<<<<
                // ---UPD 2010/09/25---------<<<<<
            }
        }

        /// <summary>
        /// ActiveRowインデックス取得処理
        /// </summary>
        /// <returns>ActiveRowインデックス</returns>
        /// <remarks>
        /// <br>Note        : ActiveRowインデックス取得を行います。</br>
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
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

        #region ◎ オフライン状態チェック処理
        /// <summary>
        /// ログオン時オンライン状態チェック処理
        /// </summary>
        /// <returns>チェック処理結果</returns>
        /// <remarks>
        /// <br>Note       : ログオン時オンライン状態チェック処理を行う。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/08/19</br>
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
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/08/19</br>
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
        /// セルActivation設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 検索時、セル単位の入力許可設定を行う</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/08/19</br>
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

        /// <summary>
        /// 画面情報データを格納処理
        /// </summary>
        /// <param name="rateProtyMngPatternWork">抽出条件</param>
        /// <remarks>
        /// <br>Note        : 画面情報データを格納します。</br>
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
        /// </remarks>
        private void ScreenToRateProtyMngPattern(ref RateProtyMngPatternWork rateProtyMngPatternWork)
        {
            rateProtyMngPatternWork.CustomerCode = this.tNedit_CustomerCode.GetInt();
            rateProtyMngPatternWork.CustRateGrpCode = this.tNedit_CustRateGrpCodeZero.GetInt();
            rateProtyMngPatternWork.SupplierCd = this.tNedit_SupplierCd.GetInt();
            rateProtyMngPatternWork.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            rateProtyMngPatternWork.SectionCode = this._rateProtyMng.SectionCode.Trim();
            rateProtyMngPatternWork.UnitPriceKind = this._rateProtyMng.UnitPriceKind.ToString();
            rateProtyMngPatternWork.RateSettingDivide = this._rateProtyMng.RateSettingDivide.Trim();
            rateProtyMngPatternWork.EnterpriseCode = this._enterpriseCode;
        }

        // ---ADD 2010/09/09---------------------->>>

        /// <summary>
        /// ガイド処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : ガイド処理を行います。</br>
        /// <br>Programmer  : hanby</br>
        /// <br>Date        : 2010/09/09</br>
        /// </remarks>
        private bool ExcuteGuide()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                GoodsGroupU goodsGroupU = new GoodsGroupU();

                // ---ADD 2010/09/25---------------------->>>
                this._gridGuideFlg = true;
                if (this.Detail_uGrid.ActiveCell.Activation == Activation.AllowEdit)
                {
                    this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);
                }
                // ---ADD 2010/09/25----------------------<<<

                // 商品掛率Ｇガイド表示
                status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU, false);
                if (status == 0)
                {
                    // メーカーコード + メーカー名称
                    this.Detail_uGrid.BeginUpdate();
                    this.Detail_uGrid.ActiveCell.Activation = Activation.NoEdit;
                    this._guidFlg = true;
                    this._guidCd = goodsGroupU.GoodsMGroup;
                    //this.Detail_uGrid.ActiveCell.Value = goodsGroupU.GoodsMGroupName.Trim(); // DEL 2010/09/25
                    this.Detail_uGrid.Rows[this.Detail_uGrid.ActiveCell.Row.Index].Cells["MasterNm"].Value = goodsGroupU.GoodsMGroupName.Trim(); // ADD 2010/09/25
                    this.Detail_uGrid.Rows[this.Detail_uGrid.ActiveCell.Row.Index].Cells[masterCode].Value = goodsGroupU.GoodsMGroup.ToString("D4"); // ADD 2010/09/25
                    this._prevGoodsRateGrpCode = goodsGroupU.GoodsMGroup;
                    this.Detail_uGrid.EndUpdate();
                    return true;
                }
                else
                {
                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode); // ADD 2010/09/25
                    this.Detail_uGrid.ActiveCell.SelectAll();
                    return false;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        /// <summary>
        /// メーカーマスタチェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 入力されたメーカーがメーカーマスタに存在するかのチェックを行います。</br>
        /// <br>Programmer  : hanby</br>
        /// <br>Date        : 2010/09/09</br>
        /// </remarks>
        private bool SearchMakerUMnt()
        {
            ArrayList retList;
            bool flag = false;

            int status = this._makerAcs.SearchAll(out retList, this._enterpriseCode);
            if (status == 0)
            {
                string inputValue;
                if (this.Detail_uGrid.ActiveCell.Text.Length < 4)
                {
                    inputValue = this.Detail_uGrid.ActiveCell.Text.PadLeft(4, '0');
                }
                else
                {
                    inputValue = this.Detail_uGrid.ActiveCell.Text.Substring(0, 4);
                }
                foreach (MakerUMnt makerUMnt in retList)
                {
                    if (inputValue.Equals(makerUMnt.GoodsMakerCd.ToString("0000")))
                    {
                        if (makerUMnt.LogicalDeleteCode == 1)
                        {
                            flag = false;
                        }
                        else
                        {
                            flag = true;
                            this._preRowIndex = this.Detail_uGrid.ActiveCell.Row.Index;
                            this._preColumnIndex = this.Detail_uGrid.ActiveCell.Column.Index;
                            this.Detail_uGrid.ActiveCell.Value = makerUMnt.GoodsMakerCd.ToString("0000") + " " + makerUMnt.MakerName.Trim();
                        }
                        break;
                    }
                }
                if (!flag)
                {
                    // エラー時
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "メーカーコードが存在しません。",
                        -1,
                        MessageBoxButtons.OK);
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 行削除ボタンクリックイベント
        /// </summary>
        /// <remarks>
        /// <br>Note        : 行削除処理を行います。</br>
        /// <br>Programmer  : hanby</br>
        /// <br>Date        : 2010/09/09</br>
        /// <br>Update Note : 2010/09/30</br>
        /// <br>            : Redmine#15703対応</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            //this.RowDelete(); // DEL 2010/09/25
            // --------UPD 2010/09/28 -------------<<<<<
            //if (!this.AllDeleteCheck())
            //{
            //    this.Delete_Button.Focus();
            //}
            // ---UPD 2010/09/25---------------------->>>
            // ---ADD 2010/09/10---------------------->>>
            int rowIndex = 0;
            //if (this.Detail_uGrid.ActiveCell != null) // DEL 2010/09/30 仕様連絡 #15703
            if (this.Detail_uGrid.ActiveRow != null) // ADD 2010/09/30 仕様連絡 #15703
            {
                //rowIndex = this.Detail_uGrid.ActiveCell.Row.Index; // DEL 2010/09/30 仕様連絡 #15703
                rowIndex = this.Detail_uGrid.ActiveRow.Index; // ADD 2010/09/30 仕様連絡 #15703
            }
            else
            {
                if (this.Detail_uGrid.Rows.Count > 0)
                {
                    RowDelete();
                    if (!this.AllDeleteCheck())
                    {
                        this.Delete_Button.Focus();
                    }
                }
                else
                {
                    return;
                }
            }
            // ---ADD 2010/09/10----------------------<<<
            this._deleteButtonFlag = true;// ADD 2010/09/10
            //this.Detail_uGrid.PerformAction(UltraGridAction.ExitEditMode);  // ADD 2010/09/10 // DEL 2010/09/30 仕様連絡 #15703
            // ---ADD 2010/09/10---------------------->>>
            if (this._errorFlg)
            {
                ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).MasterNm = string.Empty;
                ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).GoodsRateGrpCode = string.Empty; // ADD 2010/09/25
                this._errorFlg = false;
            }
            RowDelete();
            if (!this.AllDeleteCheck())
            {
                this.Delete_Button.Focus();
                return;
            }

            // --- DEL 2010/09/30 仕様連絡 #15703 ---------->>>>>
            //if (!CatchSelectedRow(rowIndex))
            //{
            //    ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
            //    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[SelectedRow()];
            //    //this.Detail_uGrid.Rows[SelectedRow()].Cells["MasterNm"].Activate(); // DEL 2010/09/25
            //    this.Detail_uGrid.Rows[SelectedRow()].Cells[masterCode].Activate(); // ADD 2010/09/25
            //    //this.SetGridTabFocus(ref evt);
            //    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
            //}
            //else
            //{
            //    //this.Detail_uGrid_KeyDown(this.Detail_uGrid, new KeyEventArgs(Keys.Right)); // ADD 2010/09/25
            //}
            // --- DEL 2010/09/30 仕様連絡 #15703 ----------<<<<<

            // ---ADD 2010/09/10----------------------<<<
            this._deleteButtonFlag = false;// ADD 2010/09/10
            // --------UPD 2010/09/28 ------------->>>>>
        }

        /// <summary>
        /// 全削除ボタンクリックイベント
        /// </summary>
        /// <remarks>
        /// <br>Note        : 全削除処理を行います。</br>
        /// <br>Programmer  : hanby</br>
        /// <br>Date        : 2010/09/09</br>
        /// </remarks>
        private void DeleteAll_Button_Click(object sender, EventArgs e)
        {
            // --------UPD 2010/09/28 ------------->>>>>
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
                    ((RateProtyMngPatternDataSet.RateProtyMngPatternRow)this._rateProtyMngPatternDataSet.RateProtyMngPattern.Rows[rowIndex]).GoodsRateGrpCode = string.Empty; // ADD 2010/09/25
                }
                AllRowDelete();

                if (!this._errorFlg)
                {
                    ChangeFocusEventArgs evt = new ChangeFocusEventArgs(false, false, false, Keys.Tab, this.Detail_uGrid, this.Detail_uGrid);
                    this.Detail_uGrid.ActiveRow = this.Detail_uGrid.Rows[SelectedRow()];
                    this.Detail_uGrid.Rows[SelectedRow()].Cells[masterCode].Activate();
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
                    this.Detail_uGrid.Rows[GetGridInitRowNo()].Cells[GetGridInitColumKey()].Activate();
                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            else
            {
                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                return;
            }
            // --------UPD 2010/09/28 -------------<<<<<
        }

        /// <summary>
        /// 全削除ボタンクリックイベント
        /// </summary>
        /// <remarks>
        /// <br>Note        : 全削除処理を行います。</br>
        /// <br>Programmer  : hanby</br>
        /// <br>Date        : 2010/09/09</br>
        /// <br>Update Note : 2010/09/30</br>
        /// <br>            : Redmine#15703対応</br>
        /// </remarks>
        private void AllRowDelete()
        {
            // 削除対象かどうかチェック用変数
            // メーカーコード
            //string goodsMakerCdColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName; // DEL 2010/09/25
            string goodsMakerCdColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName; // ADD 2010/09/25
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
                    //this.SetCellActivation(row); // DEL 2010/09/30 仕様連絡 #15703
                }
                this.Detail_uGrid.EndUpdate();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// AfterCellActivateイベント
        /// </summary>
        /// <remarks>
        /// <br>Note        : セルがアクティブになった後に発生します。</br>
        /// <br>Programmer  : hanby</br>
        /// <br>Date        : 2010/09/09</br>
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
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Programmer : hanby</br>
        /// <br>Date       : 2010/09/09</br>
        /// </remarks>
        private void ultraExpandableGroupBox_Condition_ExpandedStateChanging(object sender, CancelEventArgs e)
        {
            Size topSize = new Size();
            Size gridSize = new Size();

            topSize.Width = this.Head_panel_Top.Size.Width;
            gridSize.Width = this.Detail_uGrid.Size.Width;
            topSize.Height = 166;
            gridSize.Height = 410;

            if (this.ultraExpandableGroupBox_Condition.Expanded == false)
            {
                topSize.Height = 166;
                gridSize.Height = 410;
            }
            else
            {
                topSize.Height = 60;
                gridSize.Height = 517;
            }

            this.Head_panel_Top.Size = topSize;
            this.Detail_uGrid.Size = gridSize;
        }

        /// <summary>
        /// 明細が入力済みで且つ、未入力項目が有る場合
        /// </summary>
        /// <remarks>
        /// <br>Note        : 明細が入力済みで且つ、未入力項目が有る場合</br>
        /// <br>Programmer  :hanby</br>
        /// <br>Date        : 2010/09/09</br>
        /// </remarks>
        private bool CheckAllZero()
        {
            bool checkFlg = true;
            string rowIndexName = string.Empty;
            // メーカーコード
            //string masterNmColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName; // DEL 2010/09/25
            string masterNmColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName; // ADD 2010/09/25
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
        /// <remarks>
        /// <br>Note        : 明細が入力済みで且つ、同一コードが存在する場合</br>
        /// <br>Programmer  :hanby</br>
        /// <br>Date        : 2010/09/09</br>
        /// </remarks>
        private bool CheckEqual()
        {
            // 明細が入力済みで且つ、同一コードが存在する場合、エラー項目へフォーカスを移動し、エラーとする。
            //string rowName = this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName; // DEL 2010/09/25
            string rowName = this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName; // ADD 2010/09/25
            // 行削除フラグ
            string logicalDeleteCodeColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.LogicalDeleteCodeColumn.ColumnName;

            for (int i = 0; i < this.Detail_uGrid.Rows.Count; i++)
            {
                //if (!string.IsNullOrEmpty(this.Detail_uGrid.Rows[i].Cells[rowName].Value.ToString()) && (int)this.Detail_uGrid.Rows[i].Cells[logicalDeleteCodeColumn].Value == 0) // DEL 2010/09/25
                if (!string.IsNullOrEmpty(this.Detail_uGrid.Rows[i].Cells[rowName].Text) && (int)this.Detail_uGrid.Rows[i].Cells[logicalDeleteCodeColumn].Value == 0) // ADD 2010/09/25
                {
                    this.Detail_uGrid.Rows[i].Cells[rowName].Activate();
                    //DataRow[] dr = this._rateProtyMngPatternDataSet.RateProtyMngPattern.Select("MasterNm = '" + this.Detail_uGrid.Rows[i].Cells[rowName].Value.ToString() + "' AND LogicalDeleteCode = 0"); // DEL 2010/09/25
                    DataRow[] dr = this._rateProtyMngPatternDataSet.RateProtyMngPattern.Select("GoodsRateGrpCode = '" + this.Detail_uGrid.Rows[i].Cells[rowName].Text + "' AND LogicalDeleteCode = 0"); // ADD 2010/09/25
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
        /// <remarks>
        /// <br>Note        : 明細が全て未入力の場合、エラーとする。</br>
        /// <br>Programmer  :hanby</br>
        /// <br>Date        : 2010/09/09</br>
        /// </remarks>
        private bool CheckEmpty()
        {
            string rowIndexName = string.Empty;
            // 層別
            //string goodsRateRankColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName; // DEL 2010/09/25
            string goodsRateRankColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName; // ADD 2010/09/25
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
                    //if (string.IsNullOrEmpty(ultraRow.Cells[goodsRateRankColumn].Value.ToString()) && // DEL 2010/09/25
                    if (string.IsNullOrEmpty(ultraRow.Cells[goodsRateRankColumn].Text) && // ADD 2010/09/25
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
                        this.Detail_uGrid.Rows[0].Cells[goodsRateRankColumn].Activate();
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        this._checkEmptyFlg = true; // ADD 2010/09/09
                        return false;
                    }
                }
            }
            else if (this._rateProtyMng.UnitPriceKind == 2)
            {
                int count = 0;
                foreach (UltraGridRow ultraRow in this.Detail_uGrid.Rows)
                {
                    //if (string.IsNullOrEmpty(ultraRow.Cells[goodsRateRankColumn].Value.ToString()) && // DEL 2010/09/25
                    if (string.IsNullOrEmpty(ultraRow.Cells[goodsRateRankColumn].Text) && // ADD 2010/09/25
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
                        this.Detail_uGrid.Rows[0].Cells[goodsRateRankColumn].Activate();
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
                    //if (string.IsNullOrEmpty(ultraRow.Cells[goodsRateRankColumn].Value.ToString()) && // DEL 2010/09/25
                    if (string.IsNullOrEmpty(ultraRow.Cells[goodsRateRankColumn].Text) && // ADD 2010/09/25
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
                        this.Detail_uGrid.Rows[0].Cells[goodsRateRankColumn].Activate();
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
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
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/09/09</br>
        /// </remarks>
        /// <returns></returns>
        private bool Search()
        {
            bool searchStatus = false;
            int status = 0; // ADD 2010/09/25
            bool inputStatus = true;

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
                            #region 前回値保持用変数(保存の処理を行った後、検索処理用)
                            this._prevCustomerCd = this.tNedit_CustomerCode.GetInt();
                            this._prevCustRateGrpCd = this.tNedit_CustRateGrpCodeZero.GetInt();
                            this._prevSupplierCd = this.tNedit_SupplierCd.GetInt();
                            this._prevMakerCd = this.tNedit_GoodsMakerCd.GetInt();
                            #endregion

                            if (this.SaveProc())
                            {
                                if (this.InsertCondition())
                                {
                                    this.SearchRateData();
                                }
                            }
                            break;
                        }
                    case DialogResult.No:
                        {
                            if (this.CheckCodeExit())
                            {
                                this.SearchRateData();
                            }
                            break;
                        }
                    case DialogResult.Cancel:
                        {
                            this._isCancelFlg = true;
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
                status = this.SearchRateData();
            }
            // ---ADD 2010/09/25----------->>>>
            if (status == 0)
            {
                this._prevCustomerCode = this.tNedit_CustomerCode.GetInt();
                this._prevCustRateGrpCode = this.tNedit_CustRateGrpCodeZero.GetInt();
                this._prevSupplierCode = this.tNedit_SupplierCd.GetInt();
                this._prevMakerCode = this.tNedit_GoodsMakerCd.GetInt();
                searchStatus = true;
            }
            // ---ADD 2010/09/25-----------<<<<

            return searchStatus;
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
        /// 検索処理前、検索条件をチェック
        /// </summary>
        /// <remarks>
        /// <br>Note       : 検索処理前、検索条件をチェックする。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2010/09/09</br>
        /// </remarks>
        /// <returns></returns>
        private void CheckBeforeSearch()
        {
            #region 検索処理前、検索条件をチェック
            if (this.tNedit_CustomerCode.GetInt() != 0 && this.tNedit_CustomerCode.Enabled)
            {
                string name = string.Empty;
                if (!GetCustomerName(this.tNedit_CustomerCode.GetInt(), out name))
                {
                    this.CustomerCodeNm_tEdit.Clear();
                }
                else
                {
                    this.CustomerCodeNm_tEdit.Text = name;
                }
            }
            if (this.tNedit_CustRateGrpCodeZero.GetInt() != 0 && this.tNedit_CustRateGrpCodeZero.Enabled)
            {
                string name = string.Empty;
                if (!GetCustRateGrpName(this.tNedit_CustRateGrpCodeZero.GetInt(), out name))
                {
                    this.tEdit_CustRateGrpNm.Clear();
                }
                else
                {
                    this.tEdit_CustRateGrpNm.Text = name;
                }
            }
            if (this.tNedit_SupplierCd.GetInt() != 0 && this.tNedit_SupplierCd.Enabled)
            {
                string name = string.Empty;
                if (!GetSupplierName(this.tNedit_SupplierCd.GetInt(), out name))
                {
                    this.SupplierCdNm_tEdit.Clear();
                }
                else
                {
                    this.SupplierCdNm_tEdit.Text = name;
                }
            }
            if (this.tNedit_GoodsMakerCd.GetInt() != 0 && this.tNedit_GoodsMakerCd.Enabled)
            {
                string name = string.Empty;
                if (!GetMakerName(this.tNedit_GoodsMakerCd.GetInt(), out name))
                {
                    this.MakerName_tEdit.Clear();
                }
                else
                {
                    this.MakerName_tEdit.Text = name;
                }
            }
            #endregion
        }

        /// <summary>
        /// 保存の処理を行った後、検索処理を行う時、抽出条件を設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 保存の処理を行った後、検索処理を行う時、抽出条件を設定します。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2010/09/09</br>
        /// </remarks>
        /// <returns></returns>
        private bool InsertCondition()
        {
            bool customerFlg = false;
            bool custRateGrpFlg = false;
            bool supplierFlg = false;
            bool makerFlg = false;

            // 得意先
            if (this.tNedit_CustomerCode.Enabled)
            {
                this.tNedit_CustomerCode.DataText = this._prevCustomerCd.ToString("D8");
                string name = string.Empty;
                if (GetCustomerName(this._prevCustomerCd, out name))
                {
                    this.CustomerCodeNm_tEdit.Text = name;
                }
                else
                {
                    this.tNedit_CustomerCode.Clear();
                    customerFlg = true;
                }
            }
            // 得意先掛率
            if (this.tNedit_CustRateGrpCodeZero.Enabled)
            {
                this.tNedit_CustRateGrpCodeZero.DataText = this._prevCustRateGrpCd.ToString("D4");
                string name = string.Empty;
                if (GetCustRateGrpName(this._prevCustRateGrpCd, out name))
                {
                    this.tEdit_CustRateGrpNm.Text = name;
                }
                else
                {
                    this.tNedit_CustRateGrpCodeZero.Clear();
                    custRateGrpFlg = true;
                }
            }
            // 仕入先
            if (this.tNedit_SupplierCd.Enabled)
            {
                this.tNedit_SupplierCd.DataText = this._prevSupplierCd.ToString("D6");
                string name = string.Empty;
                if (GetSupplierName(this._prevSupplierCd, out name))
                {
                    this.SupplierCdNm_tEdit.Text = name;
                }
                else
                {
                    this.tNedit_SupplierCd.Clear();
                    supplierFlg = true;
                }
            }
            // ﾒｰｶｰ
            if (this.tNedit_GoodsMakerCd.Enabled)
            {
                this.tNedit_GoodsMakerCd.DataText = this._prevMakerCd.ToString("D4");
                string name = string.Empty;
                if (GetMakerName(this._prevMakerCd, out name))
                {
                    this.MakerName_tEdit.Text = name;
                }
                else
                {
                    this.tNedit_GoodsMakerCd.Clear();
                    makerFlg = true;
                }
            }

            if (customerFlg == true)
            {
                // エラー時
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "得意先が存在しません。",
                    -1,
                    MessageBoxButtons.OK);

                this.tNedit_CustomerCode.Focus();
                this.tToolbarsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = true;
                return false;
            }
            else if (custRateGrpFlg == true)
            {
                // エラー時
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "得意先掛率ｸﾞﾙｰﾌﾟが存在しません。",
                    -1,
                    MessageBoxButtons.OK);

                this.tNedit_CustRateGrpCodeZero.Focus();
                this.tToolbarsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = true;
                return false;
            }
            else if (supplierFlg == true)
            {
                // エラー時
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "仕入先が存在しません。",
                    -1,
                    MessageBoxButtons.OK);

                this.tNedit_SupplierCd.Focus();
                this.tToolbarsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = true;
                return false;
            }
            else if (makerFlg == true)
            {
                // エラー時
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "メーカーマスタが未登録です。",
                    -1,
                    MessageBoxButtons.OK);

                this.tNedit_GoodsMakerCd.Focus();
                this.tToolbarsManager_MainMenu.Tools[TOOLBAR_GUIDEBUTTON_KEY].SharedProps.Enabled = true;
                return false;
            }

            return true;
        }

        /// <summary>
        /// 抽出条件チェック
        /// </summary>
        /// <remarks>
        /// <br>Note       : 抽出条件チェックする。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2010/09/09</br>
        /// </remarks>
        /// <returns></returns>
        private bool CheckCodeExit()
        {
            if (this.tNedit_CustomerCode.Focused)
            {
                int inputValue = this.tNedit_CustomerCode.GetInt();
                string name = string.Empty;
                //if (!GetCustomerName(inputValue, out name)) // DEL 2010/09/26
                if (inputValue != 0 && !GetCustomerName(inputValue, out name)) // ADD 2010/09/26
                {
                    this._checkInputScreenErr = true;  // ADD 2010/09/26
                    // エラー時
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "得意先が存在しません。",
                        -1,
                        MessageBoxButtons.OK);

                    this.CustomerCodeNm_tEdit.Clear();
                    this.tNedit_CustomerCode.SelectAll();
                    return false;
                }
            }
            else if (this.tNedit_CustRateGrpCodeZero.Focused)
            {
                int inputValue = this.tNedit_CustRateGrpCodeZero.GetInt();
                string name = string.Empty;
                //if (!GetCustRateGrpName(inputValue, out name)) // DEL 2010/09/26
                if (inputValue != 0 && !GetCustRateGrpName(inputValue, out name)) // ADD 2010/09/26
                {
                    this._checkInputScreenErr = true;  // ADD 2010/09/26
                    // エラー時
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "得意先掛率ｸﾞﾙｰﾌﾟが存在しません。",
                        -1,
                        MessageBoxButtons.OK);

                    this.tEdit_CustRateGrpNm.Clear();
                    this.tNedit_CustRateGrpCodeZero.SelectAll();
                    return false;
                }
            }
            else if (this.tNedit_SupplierCd.Focused)
            {
                int inputValue = this.tNedit_SupplierCd.GetInt();
                string name = string.Empty;
                //if (!GetSupplierName(inputValue, out name)) // DEL 2010/09/26
                if (inputValue != 0 && !GetSupplierName(inputValue, out name)) // ADD 2010/09/26
                {
                    this._checkInputScreenErr = true;  // ADD 2010/09/26
                    // エラー時
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "仕入先が存在しません。",
                        -1,
                        MessageBoxButtons.OK);

                    this.SupplierCdNm_tEdit.Clear();
                    this.tNedit_SupplierCd.SelectAll();
                    return false;
                }
            }
            else if (this.tNedit_GoodsMakerCd.Focused)
            {
                int inputValue = this.tNedit_GoodsMakerCd.GetInt();
                string name = string.Empty;
                //if (!GetMakerName(inputValue, out name)) // DEL 2010/09/26
                if (inputValue != 0 && !GetMakerName(inputValue, out name)) // ADD 2010/09/26
                {
                    this._checkInputScreenErr = true;  // ADD 2010/09/26
                    // エラー時
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "メーカーマスタが未登録です。",
                        -1,
                        MessageBoxButtons.OK);

                    this.MakerName_tEdit.Clear();
                    this.tNedit_GoodsMakerCd.SelectAll();
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 画面を閉める
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面を閉める</br>
        /// <br>Programmer  : wangc</br>
        /// <br>Date        : 2010/09/13</br>
        /// </remarks>
        /// <returns></returns>
        private void PMKHN09476UA_FormClosing(object sender, FormClosingEventArgs e)
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
                            if (this.Detail_uGrid.ActiveCell != null && this.Detail_uGrid.ActiveCell.Activation == Activation.AllowEdit)
                            {
                                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            break;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// 全削除ボタン有効かをチェック
        /// </summary>
        /// <remarks>
        /// <br>Note       : 全削除ボタン有効かをチェックします。</br>
        /// <br>Programmer : 朱 猛</br>
        /// <br>Date       : 2010/09/09</br>
        /// </remarks>
        /// <returns></returns>
        private bool AllDeleteEnabledCheck()
        {
            // メーカーコード
            //string goodsMakerCdColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.MasterNmColumn.ColumnName; // DEL 2010/09/25
            string goodsMakerCdColumn = this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName; // ADD 2010/09/25
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
        /// <br>Programmer  : caowj</br>
        /// <br>Date        : 2010/08/19</br>
        /// <br>Programmer  : wangc</br>
        /// <br>Date        : 2010/09/19</br>
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
            // ----------ADD 2010/09/19----------->>
            // 全角数値は、ＮＧ
            if (2 * key.ToString().Length == Encoding.Default.GetByteCount(key.ToString()))
            {
                return false;
            }
            // --------ADD UPD 2010/09/09---------<<<

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
                if (this.Detail_uGrid.Rows[selectRow].Cells[masterCode].Activation == Activation.AllowEdit) // ADD 2010/09/30
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

        // ---ADD 2010/09/09----------------------<<<
        #endregion Private Method

        /// <summary>
        /// Enter イベント(tNedit_CustRateGrpCode)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: テキストボックスがアクティブになったときに発生します。</br>
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/19</br>
        /// </remarks>
        private void tNedit_CustRateGrpCodeZero_Enter(object sender, EventArgs e)
        {
            if (this.tNedit_CustRateGrpCodeZero.DataText.Trim() == "")
            {
                return;
            }

            int custRateGrpCode = this.tNedit_CustRateGrpCodeZero.GetInt();

            this.tNedit_CustRateGrpCodeZero.SetInt(custRateGrpCode);
            this.tNedit_CustRateGrpCodeZero.SelectAll();
        }


        // ---DEL 2010/09/25---------------------->>>
        //private void ultraExpandableGroupBoxPanel1_Paint(object sender, PaintEventArgs e)
        //{

        //}
        // ---DEL 2010/09/25----------------------<<<

        // ---UPD 2010/09/25---------------------->>>
        /// <summary>
        /// グリッド初期可編集行を取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : グリッド初期可編集行取得を行います。</br>
        /// <br>Programmer  : 曹文傑</br>
        /// <br>Date        : 2010/09/25</br>
        /// </remarks>
        private int GetGridInitRowNo()
        {
            int rowIndex;
            for (rowIndex = 0; rowIndex < this.Detail_uGrid.Rows.Count; rowIndex++)
            {
                if (this.Detail_uGrid.Rows[rowIndex].Cells[this._rateProtyMngPatternDataSet.RateProtyMngPattern.GoodsRateGrpCodeColumn.ColumnName].Activation == Activation.AllowEdit)
                {
                    break;
                }
            }
            return rowIndex;
        }
        // ---UPD 2010/09/25----------------------<<<
    }
}
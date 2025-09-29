//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車輌管理マスタ(一括入力)
// プログラム概要   : 車輌管理マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/09/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2009/10/10  修正内容 : 障害報告Redmine#537,703の修正
//----------------------------------------------------------------------------//
// 管理番号  11570163-00 作成担当 : 譚洪
// 修 正 日  2019/08/19  修正内容 : テキスト出力操作ログおよび出力時アラートメッセージ追加対応
//----------------------------------------------------------------------------//
// 管理番号  11770175-00 作成担当 : 佐々木亘
// 修 正 日  2021/11/02  修正内容 : OUT OF MEMORY対応(4GB対応) 車輌管理マスタ保守
//                                  抽出対象件数を最大件数20001件まで（20000件まで画面表示）
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Infragistics.Win.Misc;
using Broadleaf.Library.Windows.Forms;
using System.IO;
using Broadleaf.Library.Text;
using Broadleaf.Application.Resources;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.Remoting.ParamData;// ADD 2019/08/19 譚洪 テキスト出力操作ログおよび出力時アラートメッセージ追加対応

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 車輌管理マスタ一括登録修正フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 車輌管理マスタ一括登録修正関連の一覧表示を行うフォームクラスです。</br>
    /// <br>Programmer  : 李占川</br>
    /// <br>Date        : 2009.09.07</br>
    /// <br>Update Note : 張莉莉 2009.10.10</br>
    /// <br>            : 障害報告Redmine#537の修正</br>
    /// <br>Update Note : 譚洪 2019/08/19</br>
    /// <br>            : テキスト出力操作ログおよび出力時アラートメッセージ追加対応</br>
    /// <br>Update Note : 2021/11/02 佐々木亘</br>
    /// <br>管理番号    : 11770175-00</br>
    /// <br>              OUT OF MEMORY対応(4GB対応) 車輌管理マスタ保守</br>
    /// <br>              抽出対象件数を最大件数20001件まで（20000件まで画面表示）</br>
    /// </remarks>
    public partial class PMSYA09021UA : Form
    {
        #region ■ コンストラクタ ■
        /// <summary>
        /// 車輌管理マスタ一括登録修正UIクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 車輌管理マスタ一括登録修正UIフォームクラスのインスタンスを生成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// <br>Note        : テキスト出力操作ログおよび出力時アラートメッセージ追加対応</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2019/08/19</br>
        /// </remarks>
        public PMSYA09021UA()
        {
            InitializeComponent();

            this._controlScreenSkin = new ControlScreenSkin();

            // ログイン情報取得
            this.GetLoginInfo();

            // グリッド
            this._detailGrid = new PMSYA09021UB();
            this._gridStateController = new GridStateController();

            this._secInfoAcs = new SecInfoAcs();
            this._carMngListInputAcs = CarMngListInputAcs.GetInstance();
            this._carMngInputAcs = CarMngInputAcs.GetInstance();

            // フォーカス設定イベント
            this._detailGrid.SetFocus += new PMSYA09021UB.SettingFocusEventHandler(this.DetailGrid_SetFocus);

            // 編集ボタン押下可否設定イベント
            this._detailGrid.SetEditButton += new PMSYA09021UB.SetEditButtonEnableHandler(this.SetEditButtonEnable);

            // データ入力画面を起動イベント
            this._detailGrid.StartInPut += new PMSYA09021UB.StartInPutHandler(this.StartInPut);

            this.TextOutPutOprtnHisLogAcsObj = new TextOutPutOprtnHisLogAcs(); // ADD 2019/08/19 譚洪 テキスト出力操作ログおよび出力時アラートメッセージ追加対応
        }
        #endregion

        #region ■ private定数 ■
        // ツールバーツールキー設定
        private const string TOOLBAR_CLOSEBUTTON_KEY = "ButtonTool_Close";
        private const string TOOLBAR_SEARCHBUTTON_KEY = "ButtonTool_Search";
        private const string TOOLBAR_CLEARBUTTON_KEY = "ButtonTool_Clear";
        private const string TOOLBAR_NEWBUTTON_KEY = "ButtonTool_New";
        private const string TOOLBAR_EDITBUTTON_KEY = "ButtonTool_Edit";
        private const string TOOLBAR_SAVEBUTTON_KEY = "ButtonTool_Save";
        private const string TOOLBAR_TEXTOUTPUTBUTTON_KEY = "ButtonTool_TextOutPut";
        private const string TOOLBAR_NEWINFOBUTTON_KEY = "ButtonTool_NewInfo";

        private const string TOOLBAR_SECTIONLABEL_TITLE = "LableTool_SectionTitle";
        private const string TOOLBAR_LOGINLABEL_TITLE = "LableTool_LoginTitle";

        private const string TOOLBAR_SECTIONNAMELABLE_KEY = "LableTool_SectionName";
        private const string TOOLBAR_LOGINNAMELABLE_KEY = "LableTool_LoginName";
        private const string TOOLBAR_ROWDELETE_KEY = "ButtonTool_delRow";

        // --- UPD 2009/10/10 ----->>>>>
        //private const string SEARCH_DIV1 = "完全";
        //private const string SEARCH_DIV2 = "前方";
        //private const string SEARCH_DIV3 = "曖昧";
        private const string SEARCH_DIV1 = "と一致";
        private const string SEARCH_DIV2 = "で始る";
        private const string SEARCH_DIV3 = "を含む";
        private const string SEARCH_DIV4 = "で終る";
        // --- UPD 2009/10/10 -----<<<<<

        private const string INIT_MODE = "init";
        private const string SEARCH_MODE = "search";

        // クラス名
        private string ct_PRINTNAME = "車輌管理マスタ";
        // プログラムID
        private const string ct_PGID = "PMSYA09020U";

        // 画面状態保存用ファイル名
        private const string XML_FILE_INITIAL_DATA = "PMSYA09020U.dat";

        //----- ADD 2019/08/19 譚洪 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 ----->>>>>
        // 最初から
        private const string StartStr = "最初から";
        // 最後まで
        private const string EndStr = "最後まで";
        // メソッド名
        private const string MethodNm = "TextOutput";
        // 追加する
        private const string AddWrite = "追加する";
        // 上書きする
        private const string OverWrite = "上書きする";
        // 画面条件
        private const string MenuCon = "得意先:{0} ～ {1},管理番号:{2}{3},出力パターン:{4},出力先:{5}";
        // プログラムID
        private const string PgId = "PMSYA09021U";
        // 出力件数
        private const string CountNumStr = "データ出力件数:{0},";
        //----- ADD 2019/08/19 譚洪 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 -----<<<<<

        // --- ADD 佐々木亘 2021/11/02 ------>>>>> 
        // 最大抽出件数
        private const int MAX_MST_RECORD_COUNT = 20000;
        // 最大件数を超えた時のメッセージ
        private const string INFO_MAX_RECORD = "データ件数が{0:#,##0}件を超えました。";
        // --- ADD 佐々木亘 2021/11/02 ------<<<<<

        #endregion

        #region ■ private変数 ■
        // 画面イメージコントロール部品
        private ControlScreenSkin _controlScreenSkin;

        // 企業コード
        private string _enterpriseCode;
        // 自拠点コード
        private string _sectionCode;
        // 明細グリッドコントロールクラス
        private PMSYA09021UB _detailGrid;

        // グリッド設定制御クラス
        private GridStateController _gridStateController;
        // ----- ADD 2019/08/19 譚洪 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 ------>>>>>
        // ログ出力共通部品
        private TextOutPutOprtnHisLogAcs TextOutPutOprtnHisLogAcsObj = null;
        // 登録・更新用操作履歴ワーク
        private TextOutPutOprtnHisLogWork TextOutPutOprtnHisLogWorkObj = null;
        // ----- ADD 2019/08/19 譚洪 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 ------<<<<<

        private ImageList _imageList16 = null;											// イメージリスト
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;				// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;				// 検索ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;				// クリアボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;				// 保存ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _newButton;				// 新規ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _editButton;				// 編集ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _textOutPutButton;			// ﾃｷｽﾄ出力ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _newInfotButton;			// 最新情報ボタン

        private Infragistics.Win.UltraWinToolbars.LabelTool _sectionTitleLabel;	        // ログイン拠点名称
        private Infragistics.Win.UltraWinToolbars.LabelTool _sectionNameLabel;			// ログイン拠点名称
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;		    // ログイン担当者名称
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;		    // ログイン担当者名称

        private SecInfoAcs _secInfoAcs = null;              // 拠点情報アクセスクラス
        private CarMngListInputAcs _carMngListInputAcs;
        private CarMngInputAcs _carMngInputAcs;

        private CustomerSearchRet _customerSearchRet;
        private bool _cusotmerGuideSelected;

        // 検索時の抽出条件
        CarManagementExtractInfo _oldExtractInfo;
        #endregion

        #region ■ privateメソッド
        #region ■ 初期表示関連
        /// <summary>
        /// ログイン情報取得
        /// </summary>
        /// <remarks>
        /// <br>Note        : ログイン情報取得</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks> 
        private void GetLoginInfo()
        {
            // 企業コード
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 自拠点コード
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        }

        /// <summary>
        /// 初期画面設定
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面初期化時に発生します。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks> 
        private void InitialScreenSetting()
        {
            // ツールバー初期設定処理
            this.ToolBarInitilSetting();

            //// ボタンアイコン設定
            this.SetGuidButtonIcon();

            //// ツールボタンEnable設定処理
            this.SetControlEnabled(INIT_MODE);

            //// 初期画面データ設定
            this.InitialScreenData();
        }

        /// <summary>
        /// ツールバー初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面初期化時、ツールバー初期設定処理を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks> 
        private void ToolBarInitilSetting()
        {
            this._imageList16 = IconResourceManagement.ImageList16;
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;

            // 終了のアイコン設定
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_CLOSEBUTTON_KEY];
            if (this._closeButton != null)
            {
                this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.CLOSE];
            }

            // 検索のアイコン設定
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_SEARCHBUTTON_KEY];
            if (this._searchButton != null)
            {
                this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.SEARCH];
            }

            // クリアのアイコン設定
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_CLEARBUTTON_KEY];
            if (this._clearButton != null)
            {
                this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.ALLCANCEL];
            }

            // 新規のアイコン設定
            this._newButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_NEWBUTTON_KEY];
            if (this._newButton != null)
            {
                this._newButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.NEW];
            }

            // 編集のアイコン設定
            this._editButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_EDITBUTTON_KEY];
            if (this._editButton != null)
            {
                this._editButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.MODIFY];
            }

            // 保存のアイコン設定
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_SAVEBUTTON_KEY];
            if (this._saveButton != null)
            {
                this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.SAVE];
            }

            // ﾃｷｽﾄ出力のアイコン設定
            this._textOutPutButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_TEXTOUTPUTBUTTON_KEY];
            if (this._textOutPutButton != null)
            {
                this._textOutPutButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.CSVOUTPUT];
            }

            // 最新情報のアイコン設定
            this._newInfotButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools[TOOLBAR_NEWINFOBUTTON_KEY];
            if (this._newInfotButton != null)
            {
                this._newInfotButton.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.RENEWAL];
            }

            // ログイン拠点のアイコン設定
            this._sectionTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_SECTIONLABEL_TITLE];
            if (this._sectionTitleLabel != null)
            {
                this._sectionTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.BASE]; ;
            }

            // ログイン担当者のアイコン設定
            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINLABEL_TITLE];
            if (this._loginTitleLabel != null)
            {
                this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = this._imageList16.Images[(int)Size16_Index.EMPLOYEE];
            }

            // ログイン拠点名
            this._sectionNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_SECTIONNAMELABLE_KEY];
            if (this._sectionNameLabel != null && LoginInfoAcquisition.Employee != null)
            {
                SecInfoSet secInfoSet = new SecInfoSet();
                this._secInfoAcs.GetSecInfo(this._sectionCode, out secInfoSet);
                if (secInfoSet != null)
                {
                    this._sectionNameLabel.SharedProps.Caption = secInfoSet.SectionGuideNm;
                }
            }

            // ログイン担当者名
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools[TOOLBAR_LOGINNAMELABLE_KEY];
            if (this._loginNameLabel != null && LoginInfoAcquisition.Employee != null)
            {
                Employee employee = new Employee();
                employee = LoginInfoAcquisition.Employee;
                this._loginNameLabel.SharedProps.Caption = employee.Name;
            }
        }

        /// <summary>
        /// ガイドボタンのアイコン設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : ガイドボタンのアイコンを設定します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void SetGuidButtonIcon()
        {
            // -----------------------------
            // ボタンアイコン設定
            // -----------------------------
            this.CustomerGuideSt_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.CustomerGuideEd_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.CarMngCode_Button.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
        }

        /// <summary>
        /// コントロールEnabled制御処理
        /// </summary>
        /// <param name="editMode">編集モード</param>
        /// <remarks>
        /// <br>Note        : コントロールのEnabled制御を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void SetControlEnabled(string editMode)
        {
            switch (editMode)
            {
                // 初期表示
                case INIT_MODE:
                    this._textOutPutButton.SharedProps.Enabled = false;
                    this._editButton.SharedProps.Enabled = false;

                    break;
                // 検索
                case SEARCH_MODE:
                    CarMngInputDataSet.CarInfoRow[] logicRows = (CarMngInputDataSet.CarInfoRow[])this._carMngListInputAcs.CarInfoDataTable.Select(
                        this._carMngListInputAcs.CarInfoDataTable.DeleteDateColumn.ColumnName + " is null " );

                    if (logicRows.Length > 0)
                    {
                        this._textOutPutButton.SharedProps.Enabled = true;
                    }
                    else
                    {
                        this._textOutPutButton.SharedProps.Enabled = false;
                    }
                    break;
            }
        }

        /// <summary>
        /// 明細からのフォーカス設定イベント
        /// </summary>
        /// <param name="ctrlKey">コントロール名</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : 明細からのフォーカス設定イベントを行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void DetailGrid_SetFocus(string ctrlKey)
        {
            switch (ctrlKey)
            {
                case "tNedit_CustomerCode_St":
                    {
                        this.tNedit_CustomerCode_St.Focus();
                        break;
                    }
                case "tEdit_CarMngCode":
                    {
                        this.tEdit_CarMngCode.Focus();
                        break;
                    }
                case "uCheckEditor_AutoFillToColumn":
                    {
                        this.uCheckEditor_AutoFillToColumn.Focus();
                        break;
                    }
                case "Before_Grid":
                    {
                        // グリッドの前のコントロールにフォーカス
                        // 対象区分により異なる
                        this.tComboEditor_SearchDiv.Focus();

                        break;
                    }
            }
        }

        /// <summary>
        /// 編集ボタンの押下可否を設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 編集ボタンの押下可否を設定を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void SetEditButtonEnable(bool flag)
        {
            this._editButton.SharedProps.Enabled = flag;
        }

        /// <summary>
        /// 初期画面データ設定
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面初期化時に発生します。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks> 
        private void InitialScreenData()
        {
            // 抽出条件
            this.tNedit_CustomerCode_St.Clear();
            this.tNedit_CustomerCode_Ed.Clear();
            this.tEdit_CarMngCode.Clear();

            // 検索区分
            this.tComboEditor_SearchDiv.Items.Clear();
            this.tComboEditor_SearchDiv.Items.Add("1", SEARCH_DIV1);
            this.tComboEditor_SearchDiv.Items.Add("2", SEARCH_DIV2);
            this.tComboEditor_SearchDiv.Items.Add("3", SEARCH_DIV3);
            this.tComboEditor_SearchDiv.Items.Add("4", SEARCH_DIV4);
            this.tComboEditor_SearchDiv.SelectedIndex = 0;

            this.uCheckEditor_AutoFillToColumn.Checked = false;
            this.tComboEditor_GridFontSize.Text = "11";
            this.DeleteIndication_CheckEditor.Checked = false;

            this.tNedit_CustomerCode_St.Focus();
        }
        # endregion

        # region ■ 終了処理 ■
        /// <summary>
        /// 終了処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面の終了処理</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks> 
        private void CloseWindow()
        {
            // 変更有無チェック
            bool isChanged = this.CompareGridDataWithOriginal();

            if (isChanged)
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    this.Name,
                    "現在、編集中のデータが存在します" + "\r\n" + "\r\n" +
                    "登録してもよろしいですか？",
                    0,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.Yes)
                {
                    int status = this.Save();
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this.Close();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.Close();
                }
                else
                {
                    return;
                }
            }
            else
            {
                this.Close();
            }
        }
        # endregion ■ 終了処理 ■

        #region ■ 検索処理 ■
        /// <summary>
        ///　検索処理(SearchProc())
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 検索処理を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// <br>Update Note : 2021/11/02 佐々木亘</br>
        /// <br>管理番号    : 11770175-00</br>
        /// <br>              OUT OF MEMORY対応(4GB対応) 車輌管理マスタ保守</br>
        /// <br>              抽出対象件数を最大件数20001件まで（20000件まで画面表示）</br>
        /// </remarks>
        private void Search()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // 変更有無チェック
            bool isChanged = this.CompareGridDataWithOriginal();

            if (isChanged)
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    this.Name,
                    "現在、編集中のデータが存在します" + "\r\n" + "\r\n" +
                    "登録してもよろしいですか？",
                    0,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.Yes)
                {
                    status = this.Save();
                    if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        return;
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    // NoThing
                }
                else
                {
                    return;
                }
            }

            string errMsg;
            Control errCtl;

            // 入力条件チェック
            if (!this.SearchBeforeCheck(out errMsg, out errCtl))
            {
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, errMsg, 0);

                // コントロールにフォーカスをセット
                if (errCtl != null)
                {
                    errCtl.Focus();
                }

                return;
            }

            // 抽出中画面部品のインスタンスを作成
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "抽出中";
            msgForm.Message = "車輌管理マスタの抽出中です。";
            try
            {
                msgForm.Show();

                CarManagementExtractInfo extractInfo;
                this.SetExtrInfo(out extractInfo);

                // 検索
                string errMessge;
                status = this._carMngListInputAcs.Search(extractInfo, out errMessge);

                switch (status)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                        this._detailGrid.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.Clear();
                        this._detailGrid.uGrid_Details.DisplayLayout.Bands[0].SortedColumns.RefreshSort(true);
                        this._detailGrid.uGrid_Details.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();

                        this._oldExtractInfo = extractInfo;

                        // グリッド表示の更新
                        this._detailGrid.SettingGrid();

                        // 削除済みデータ表示・非表示の反映
                        this._detailGrid.DeleteIndicationSetting(this.DeleteIndication_CheckEditor.Checked);

                        this.SetControlEnabled(SEARCH_MODE);

                        int activationColIndex;
                        int activationRowIndex;

                        // フォーカス設定
                        string nextFocusColKey = this._detailGrid.GetNextFocusColumnKey(0, 0, false, out activationColIndex, out activationRowIndex);

                        if (nextFocusColKey != string.Empty)
                        {
                            this._detailGrid.uGrid_Details.Rows[activationRowIndex].Cells[nextFocusColKey].Activate();

                            if (!this._detailGrid.uGrid_Details.Rows[activationRowIndex].IsFilteredOut)
                            {
                                this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                if (this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.BelowCell))
                                {
                                    this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    this._detailGrid.uGrid_Details.ActiveCell = null;
                                    this._detailGrid.uGrid_Details.ActiveRow = null;
                                }
                            }
                        }

                        // --- ADD 佐々木亘 2021/11/02 ------>>>>>
                        if (this._carMngListInputAcs.CarInfoDataTable.Count > MAX_MST_RECORD_COUNT)
                        {
                            // ダイアログを閉じる
                            msgForm.Close();

                            // 最大件数を超えた時のメッセージ
                            MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, string.Format(INFO_MAX_RECORD, MAX_MST_RECORD_COUNT), 0);
                        }
                        // --- ADD 佐々木亘 2021/11/02 ------<<<<<
                        break;

                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                        // 保存中ダイアログを閉じる
                        msgForm.Close();

                        // 0件エラー
                        MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "検索条件に該当するデータが存在しません。", 0);
                        this.SetControlEnabled(INIT_MODE);
                        break;

                    default:
                        // 保存中ダイアログを閉じる
                        msgForm.Close();

                        MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "車輌管理マスタの検索に失敗しました。" + "[" + errMessge + "]", 0);
                        this.SetControlEnabled(INIT_MODE);
                        break;
                }
            }
            finally
            {
                // 保存中ダイアログを閉じる
                msgForm.Close();

                // ボタン操作有効処理
                this._detailGrid.SetButtonEnable();
            }

        }

        /// <summary>
        /// 検索条件格納処理
        /// </summary>
        /// <param name="extrInfo">検索条件(明示的にoutパラメータで渡します)</param>
        /// <remarks>
        /// <br>Note        : 検索条件を格納します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void SetExtrInfo(out CarManagementExtractInfo extrInfo)
        {
            extrInfo = new CarManagementExtractInfo();

            // 企業コード
            extrInfo.EnterpriseCode = this._enterpriseCode;

            // 得意先コード(開始)
            if (this.tNedit_CustomerCode_St.GetInt() == 0)
            {
                extrInfo.CustomerCodeSt = 1;
            }
            else
            {
                extrInfo.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
            }
            // 得意先コード(終了)
            if (this.tNedit_CustomerCode_Ed.GetInt() == 0)
            {
                extrInfo.CustomerCodeEd = 99999999;
            }
            else
            {
                extrInfo.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
            }

            // 管理番号
            extrInfo.CarMngCode = this.tEdit_CarMngCode.Text;

            // 検索区分
            extrInfo.SearchDiv = this.tComboEditor_SearchDiv.SelectedIndex;
        }

        /// <summary>
        /// 画面情報入力チェック処理
        /// </summary>
        /// <param name="errMsg">message</param>
        /// <param name="errCtl">Control</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 画面情報の入力チェックを行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private bool SearchBeforeCheck(out string errMsg, out Control errCtl)
        {
            bool status = true;
            errMsg = string.Empty;
            errCtl = null;

            if ((this.tNedit_CustomerCode_St.GetInt() != 0) && (this.tNedit_CustomerCode_Ed.GetInt() != 0))
            {
                if (this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt())
                {
                    status = false;
                    errMsg = "得意先の範囲指定に誤りがあります。";
                    errCtl = this.tNedit_CustomerCode_Ed;
                }
            }

            return status;
        }
        # endregion ■ 検索処理 ■

        # region ■ クリア処理 ■
        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : クリアをクリック時に発生します。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks> 
        private void Clear()
        {
            // 変更有無チェック
            bool isChanged = this.CompareGridDataWithOriginal();

            if (isChanged)
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    this.Name,
                    "現在、編集中のデータが存在します" + "\r\n" + "\r\n" +
                    "登録してもよろしいですか？",
                    0,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.Yes)
                {
                    int status = this.Save();
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this.ClearProc();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.ClearProc();
                }
                else
                {
                    return;
                }
            }
            else
            {
                this.ClearProc();
            }
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : クリアをクリック時に発生します。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks> 
        private void ClearProc()
        {
            // 画面初期化
            this.SetControlEnabled(INIT_MODE);

            // グリッド部の初期化
            this._detailGrid.Initialize();

            // 初期画面データ設定
            this.InitialScreenData();
        }
        #endregion

        # region ■ 最新情報処理 ■
        /// <summary>
        /// 画面最新情報処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 最新情報をクリック時に発生します。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks> 
        private void Renewal()
        {
            // 変更有無チェック
            bool isChanged = this.CompareGridDataWithOriginal();
            // -----UPD 2009/10/10 ------>>>>> 
            //最新情報取得時に、変更データがある場合は、確認メッセージを出さないように修正。
            //if (isChanged)
            //{
            //    DialogResult dialogResult = TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_QUESTION,
            //        this.Name,
            //        "現在、編集中のデータが存在します" + "\r\n" + "\r\n" +
            //        "登録してもよろしいですか？",
            //        0,
            //        MessageBoxButtons.YesNoCancel,
            //        MessageBoxDefaultButton.Button1);

            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        int status = this.Save();
            //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //        {
            //            this.RenewalProc();
            //        }
            //    }
            //    else if (dialogResult == DialogResult.No)
            //    {
            //        this.RenewalProc();
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            //else
            //{
                this.RenewalProc();
            //}
            // -----UPD 2009/10/10 ------<<<<<
        }

        /// <summary>
        /// 画面最新情報処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 最新情報をクリック時に発生します。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks> 
        private void RenewalProc()
        {
            // 得意先検索マスタ
            this._carMngListInputAcs.LoadCustomerSearchRet();
            // 陸運事務所番号読込処理
            this._carMngListInputAcs.LoadNumberPlate1Code();

            string msg = "最新情報を取得しました。";
            // メッセージを表示
            this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, msg, 0);
        }
        #endregion

        # region ■ 保存処理 ■
        /// <summary>
        /// 画面保存処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 保存をクリック時に発生します。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private int Save()
        {
            if (this._detailGrid.uGrid_Details.ActiveCell != null
                && this._detailGrid.uGrid_Details.ActiveCell.IsInEditMode)
            {
                // 編集モードを解除する
                this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
            }
            // --- ADD 2009/10/26 ----->>>>>
            if (!this._detailGrid.ChooseFlg)
            {
                this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                this._detailGrid.ChooseFlg = true;
                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                
            }
            // --- ADD 2009/10/26 -----<<<<<
            this._carMngListInputAcs.CarInfoDataTable.AcceptChanges();

            // データ存在チェック
            if (this._carMngListInputAcs.CarInfoDataTable.Rows.Count == 0)
            {
                string message = "更新対象のデータが存在しません。";
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, message, 0);

                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            bool isChanged = this.CompareGridDataWithOriginal();

            if (!isChanged)
            {
                string message = "更新対象のデータが存在しません。";
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, message, 0);

                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            string errMsg;
            // 入力チェック（グリッド内）
            if (!this.SaveBeforeGridCheck(out errMsg))
            {
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, errMsg, 0);

                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string msg = string.Empty;

            Cursor _localCursor = this.Cursor;

            this.Cursor = Cursors.WaitCursor;

            // 保存中ダイアログ表示
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "保存中";
            msgForm.Message = "車輌管理マスタの保存中です。";

            try
            {
                // 保存処理
                status = this._carMngListInputAcs.Write(out msg);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // 登録完了
                            SaveCompletionDialog dialog = new SaveCompletionDialog();
                            dialog.ShowDialog(2);

                            //this.ClearProc();
                            // グリッド部の初期化
                            this._detailGrid.Initialize();

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            // 排他処理
                            ExclusiveTransaction(status);
                            this.SetControlEnabled(SEARCH_MODE);

                            break;
                        }
                    default:
                        {
                            // 保存中ダイアログを閉じる
                            msgForm.Close();

                            MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "車輌管理マスタの保存に失敗しました。", status);
                            this.SetControlEnabled(SEARCH_MODE);
                            break;
                        }
                }
            }
            finally
            {
                // 保存中ダイアログを閉じる
                msgForm.Close();

                // カーソルを元に戻す
                this.Cursor = _localCursor;
            }

            return status;
        }

        /// <summary>
        /// グリッド項目チェック
        /// </summary>
        /// <param name="errMsg"></param>
        /// <returns>True:OK Flase:NG</returns>
        /// <remarks>
        /// <br>Note        : 保存をクリック時に発生します。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private bool SaveBeforeGridCheck(out string errMsg)
        {
            errMsg = string.Empty;

            // キー項目の入力が無い場合エラー
            foreach (UltraGridRow ultraRow in this._detailGrid.uGrid_Details.Rows)
            {
                // 管理番号未入力チェック
                if (ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.CustomerCodeColumn.ColumnName].Value == null
                    || ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.CustomerCodeColumn.ColumnName].Value == DBNull.Value
                    || ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.CustomerCodeColumn.ColumnName].Value.ToString() == string.Empty)
                {
                    errMsg = "得意先を入力して下さい。";

                    // フォーカス
                    ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.CustomerCodeColumn.ColumnName].Activate();
                    this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                    return false;
                }

                // 管理番号未入力チェック
                if (ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.CarMngCodeColumn.ColumnName].Value == null
                    || ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.CarMngCodeColumn.ColumnName].Value == DBNull.Value
                    || ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.CarMngCodeColumn.ColumnName].Value.ToString() == string.Empty)
                {
                    errMsg = "管理番号を入力して下さい。";

                    // フォーカス
                    ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.CarMngCodeColumn.ColumnName].Activate();
                    this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                    return false;
                }
                // ---- ADD 2009/10/10 ------>>>>>
                // 前回車検日入力ありの場合、期間の未入力チェックを行う
                if (ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.LTimeCiMatDateColumn.ColumnName].Value != null
                    && !ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.LTimeCiMatDateColumn.ColumnName].Value.ToString().Equals("　")   // ADD 2009/10/10
                    && ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.LTimeCiMatDateColumn.ColumnName].Value != DBNull.Value
                    && (Int32)ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.CarInspectYearColumn.ColumnName].Value == 0)
                {
                    errMsg = "車検期間 を入力して下さい。";
                    // フォーカス
                    ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.CarInspectYearColumn.ColumnName].Activate();
                    this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    return false;
                }


                // ---- ADD 2009/10/10 ------<<<<<

                // 大小チェック(前回車検日≧登録年月日か)
                if (
                    //ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.LTimeCiMatDateColumn.ColumnName].Value != null
                    //&& !ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.LTimeCiMatDateColumn.ColumnName].Value.ToString().Equals("　")   // ADD 2009/10/10
                    //&& ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.LTimeCiMatDateColumn.ColumnName].Value != DBNull.Value
                    //&& 
                    ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.EntryDateColumn.ColumnName].Value != null
                    && !ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.EntryDateColumn.ColumnName].Value.ToString().Equals("　")   // ADD 2009/10/10
                    && ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.EntryDateColumn.ColumnName].Value != DBNull.Value
                    )
                {
                    // ----UPD 2009/10/10 ------>>>>>
                    //if ((DateTime)ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.LTimeCiMatDateColumn.ColumnName].Value
                    //    < (DateTime)ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.EntryDateColumn.ColumnName].Value)
                    if (ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.LTimeCiMatDateColumn.ColumnName].Value.ToString().CompareTo(
                         ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.EntryDateColumn.ColumnName].Value.ToString()) < 0)
                    // ----UPD 2009/10/10 ------>>>>>
                    {
                        errMsg = "登録年月日以降の日付を入力して下さい。";

                        // フォーカス
                        ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.LTimeCiMatDateColumn.ColumnName].Activate();
                        this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                        return false;
                    }
                }

                // 大小チェック(次回車検日≧登録年月日か)
                if (
                    //ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.InspectMaturityDateColumn.ColumnName].Value != null
                    //&& !ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.InspectMaturityDateColumn.ColumnName].Value.ToString().Equals("　")   // ADD 2009/10/10
                    //&& ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.InspectMaturityDateColumn.ColumnName].Value != DBNull.Value
                    //&& 
                    ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.EntryDateColumn.ColumnName].Value != null
                    && !ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.EntryDateColumn.ColumnName].Value.ToString().Equals("　")   // ADD 2009/10/10
                    && ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.EntryDateColumn.ColumnName].Value != DBNull.Value)
                {
                    // ----UPD 2009/10/10 ------>>>>>
                    //if ((DateTime)ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.InspectMaturityDateColumn.ColumnName].Value
                    //    < (DateTime)ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.EntryDateColumn.ColumnName].Value)
                    if (ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.InspectMaturityDateColumn.ColumnName].Value.ToString().CompareTo(
                        ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.EntryDateColumn.ColumnName].Value.ToString())<0)
                    // ----UPD 2009/10/10 ------>>>>>
                    {
                        errMsg = "登録年月日以降の日付を入力して下さい。";

                        // フォーカス
                        ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.InspectMaturityDateColumn.ColumnName].Activate();
                        this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                        return false;
                    }
                }

                // 大小チェック(次回車検日≧前回車検日か)
                if (
                    //ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.InspectMaturityDateColumn.ColumnName].Value != null
                    //&& !ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.InspectMaturityDateColumn.ColumnName].Value.ToString().Equals("　")   // ADD 2009/10/10
                    //&& ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.InspectMaturityDateColumn.ColumnName].Value != DBNull.Value
                    //&& 
                    ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.LTimeCiMatDateColumn.ColumnName].Value != null
                    && !ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.LTimeCiMatDateColumn.ColumnName].Value.ToString().Equals("　")   // ADD 2009/10/10
                    && ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.LTimeCiMatDateColumn.ColumnName].Value != DBNull.Value)
                {
                    // ----UPD 2009/10/10 ------>>>>>
                    //if ((DateTime)ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.InspectMaturityDateColumn.ColumnName].Value
                    //    < (DateTime)ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.LTimeCiMatDateColumn.ColumnName].Value)
                    if (ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.InspectMaturityDateColumn.ColumnName].Value.ToString().CompareTo(
                        ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.LTimeCiMatDateColumn.ColumnName].Value.ToString())<0)
                    // ----UPD 2009/10/10 ------>>>>>
                    {
                        errMsg = "前回車検日以降の日付を入力して下さい。";

                        // フォーカス
                        ultraRow.Cells[this._carMngListInputAcs.CarInfoDataTable.InspectMaturityDateColumn.ColumnName].Activate();
                        this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);

                        return false;
                    }
                }
            }

            return true;
        }
        #endregion

        # region ■ ﾃｷｽﾄ出力処理 ■
        /// <summary>
        /// 画面ﾃｷｽﾄ出力処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : ﾃｷｽﾄ出力をクリック時に発生します。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// <br>Note        : テキスト出力操作ログおよび出力時アラートメッセージ追加対応</br>
        /// <br>Programmer  : 譚洪</br>
        /// <br>Date        : 2019/08/19</br>
        /// </remarks>
        private int TextOutput()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            //----- ADD 2019/08/19 譚洪 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 ----->>>>>
            // エラーメッセージ
            string errMsg = string.Empty;
            // アラート表示
            status = TextOutPutOprtnHisLogAcsObj.ShowTextOutPut(this, out errMsg);
            // アラートでOKボタンが押されない場合、テキスト出力が実行できない
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (!string.IsNullOrEmpty(errMsg))
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                                errMsg, status, MessageBoxButtons.OK);
                }
                // 中止
                return status;
            }
            //----- ADD 2019/08/19 譚洪 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 -----<<<<<

            // テキスト出力用ダイアログに必要な情報をセットする
            SFCMN06002C printInfo;
            status = this.GetPrintInfo(out printInfo);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return -1;
            }

            CustomTextProviderInfo customTextProviderInfo = CustomTextProviderInfo.GetDefaultInfo();
            CustomTextWriter customTextWriter = new CustomTextWriter();
            customTextProviderInfo.OutPutFileName = printInfo.outPutFilePathName;
            // 上書き／追加フラグをセット(true:追加する、false:上書きする)
            customTextProviderInfo.AppendMode = printInfo.overWriteFlag;
            // スキーマ取得
            customTextProviderInfo.SchemaFileName = System.IO.Path.Combine(ConstantManagement_ClientDirectory.TextOutSchema, printInfo.prpid);

            DataTable outDataTable = new DataTable();
            this._carMngListInputAcs.GetTextOutData(out outDataTable);

            // CSV出力
            status = customTextWriter.WriteText(outDataTable, customTextProviderInfo.SchemaFileName, customTextProviderInfo.OutPutFileName, customTextProviderInfo);
            int count = outDataTable.Rows.Count;// ADD 2019/08/19 譚洪 テキスト出力操作ログおよび出力時アラートメッセージ追加対応
            outDataTable.Clear();
            string resultMessage = "";

            switch (status)
            {
                case 0:    // 処理成功
                    resultMessage = "CSV出力が完了しました。";
                    break;
                case -9:    // 出力対象外のデータが指定された
                    resultMessage = "出力対象外のデータが指定されました。";
                    break;
                default:    // その他エラー
                    resultMessage = "その他のエラーが発生しました。ステータス(" + status.ToString() + ")";
                    break;
            }

            if (!string.IsNullOrEmpty(resultMessage))
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO
                            , resultMessage
                            , status);
            }
            //----- ADD 2019/08/19 譚洪 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 ----->>>>>
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // エラーメッセージ
                errMsg = string.Empty;
                // 操作履歴登録
                TextOutPutOprtnHisLogWorkObj.LogOperationData = string.Format(CountNumStr, count.ToString()) + TextOutPutOprtnHisLogWorkObj.LogOperationData;
                status = TextOutPutOprtnHisLogAcsObj.Write(this, ref TextOutPutOprtnHisLogWorkObj, out errMsg);
                // ログ登録異常の場合、テキスト出力が実行できない
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (!string.IsNullOrEmpty(errMsg))
                    {
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                                    errMsg, status, MessageBoxButtons.OK);
                    }
                }
            }
            //----- ADD 2019/08/19 譚洪 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 -----<<<<<

            return status;
        }

        #region ◎ 印刷情報取得処理
        /// <summary>
        /// 印刷情報取得処理
        /// </summary>
        /// <param name="printInfo">印刷情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 印刷情報を取得します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private int GetPrintInfo(out SFCMN06002C printInfo)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // 印刷情報パラメータ
            printInfo = new SFCMN06002C();
            // 帳票選択ガイド
            SFCMN00391U printDialog = new SFCMN00391U();

            printInfo.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 起動ＰＧＩＤ
            printInfo.kidopgid = ct_PGID;
            printInfo.selectInfoCode = 1;
            //printInfo.PrintPaperSetCd = this._outPutMode;
            // 帳票選択ガイド
            printDialog.PrintMode = 1;
            printDialog.PrintInfo = printInfo;
            DialogResult dialogResult = printDialog.ShowDialog();
            switch (dialogResult)
            {
                case DialogResult.OK:
                    //----- ADD 2019/08/19 譚洪 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 ----->>>>>
                    // エラーメッセージ
                    string errMsg = string.Empty;
                    // テキスト出力操作ログ登録処理
                    status = TextOutPutWrite(printInfo.outPutFilePathName, printInfo.prpnm, printInfo.overWriteFlag, out errMsg);

                    // ログ登録異常の場合、テキスト出力が実行できない
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (!string.IsNullOrEmpty(errMsg))
                        {
                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                                        errMsg, status, MessageBoxButtons.OK);
                        }
                        // 中止
                        return status;
                    }
                    //----- ADD 2019/08/19 譚洪 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 -----<<<<<
                    if (File.Exists(printInfo.outPutFilePathName) == false)
                    {
                        // ファイルなし
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                    else
                    {
                        // ファイルが存在する場合は、オープンチェック
                        try
                        {
                            // 仮に名称を変更
                            string tempFileName = printInfo.outPutFilePathName
                                                + DateTime.Now.Ticks.ToString();
                            FileInfo fi = new FileInfo(printInfo.outPutFilePathName);
                            fi.MoveTo(tempFileName);
                            // 名称の変更が正しく行えたので、名称を元に戻す
                            fi.MoveTo(printInfo.outPutFilePathName);

                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        catch (Exception)
                        {
                            // 名称変更失敗 -> 他のアプリケーションが排他で使用中
                            MsgDispProc(emErrorLevel.ERR_LEVEL_INFO
                                        , "指定されたファイルは使用できません。\r\n"
                                        + "Excel等が使用していないか確認して、\r\n"
                                        + "使用しているときはファイルを閉じて下さい。"
                                        , 0);

                            status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        }
                    }
                    break;
                case DialogResult.Cancel:
                    status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    break;
                default:
                    // 例外が発生
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    break;
            }

            return status;
        }

        //----- ADD 2019/08/19 譚洪 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 ----->>>>>
        /// <summary>
        /// テキスト出力操作ログ登録処理
        /// </summary>
        /// <param name="outPutFilePathName">出力ファイルパス</param>
        /// <param name="prpnm">出力パターン</param>
        /// <param name="overWriteFlag">上書き／追加フラグ</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : テキスト出力操作ログ登録処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2019/08/19</br>
        /// </remarks>
        private int TextOutPutWrite(string outPutFilePathName, string prpnm, bool overWriteFlag, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                TextOutPutOprtnHisLogWorkObj = new TextOutPutOprtnHisLogWork();
                // ログデータ対象アセンブリID
                TextOutPutOprtnHisLogWorkObj.LogDataObjAssemblyID = PgId;
                // ログデータ対象アセンブリ名称
                TextOutPutOprtnHisLogWorkObj.LogDataObjAssemblyNm = ct_PRINTNAME;
                // ログデータ対象起動プログラム名称
                TextOutPutOprtnHisLogWorkObj.LogDataObjBootProgramNm = ct_PRINTNAME;
                // ログデータ対象処理名
                TextOutPutOprtnHisLogWorkObj.LogDataObjProcNm = MethodNm;
                // ログオペレーションデータ
                string customerCdSt = this.tNedit_CustomerCode_St.Text.Trim();
                customerCdSt = string.IsNullOrEmpty(customerCdSt) ? StartStr : customerCdSt;
                string customerCdEd = this.tNedit_CustomerCode_Ed.Text.Trim();
                customerCdEd = string.IsNullOrEmpty(customerCdEd) ? EndStr : customerCdEd;
                string carMngCode = this.tEdit_CarMngCode.Text;
                string selectedNm = string.Empty;
                if (!carMngCode.Equals(string.Empty))
                {
                    if (this.tComboEditor_SearchDiv.SelectedIndex == 0)
                    {
                        selectedNm = SEARCH_DIV1;
                    }
                    else if (this.tComboEditor_SearchDiv.SelectedIndex == 1)
                    {
                        selectedNm = SEARCH_DIV2;
                    }
                    else if (this.tComboEditor_SearchDiv.SelectedIndex == 2)
                    {
                        selectedNm = SEARCH_DIV3;
                    }
                    else
                    {
                        selectedNm = SEARCH_DIV4;
                    }
                }
                string overWrite = string.Empty;
                if (File.Exists(outPutFilePathName))
                {
                    overWrite = string.Format(",上書き／追加:{0}", overWriteFlag.Equals(true) ? AddWrite : OverWrite);
                }

                string logOperationData = string.Format(MenuCon, customerCdSt, customerCdEd, carMngCode, selectedNm, prpnm, outPutFilePathName) + overWrite;
                // ログオペレーションデータ
                TextOutPutOprtnHisLogWorkObj.LogOperationData = logOperationData;

                // エラーメッセージ
                errMsg = string.Empty;
                // 操作履歴登録
                status = TextOutPutOprtnHisLogAcsObj.Write(this, ref TextOutPutOprtnHisLogWorkObj, out errMsg);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }

            return status;
        }
        //----- ADD 2019/08/19 譚洪 テキスト出力操作ログおよび出力時アラートメッセージ追加対応 -----<<<<<
        #endregion
        # endregion

        # region ■ 排他処理 ■
        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : 排他制御を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            string errMsg = "";

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        errMsg = "既に他端末より更新されています。";
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        errMsg = "既に他端末より削除されています。";
                        break;
                    }
            }

            MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, status);

        }
        # endregion ■ 排他処理

        #region ■ その他処理 ■
        /// <summary>
        /// データ入力画面を起動する
        /// </summary>
        /// <remarks>
        /// <br>Note        : データ入力画面を起動を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void StartInPut(object key)
        {
            PMSYA09021UC form;
            // 新規場合
            if (key == null)
            {
                form = new PMSYA09021UC();
            }
            // 編集場合
            else
            {
                Guid newKey = (Guid)key;
                form = new PMSYA09021UC(newKey);
            }

            // データ入力画面を起動イベント
            form.RefreshParent += new PMSYA09021UC.RefreshParentHandler(this.RefreshParent);

            form.ShowDialog();
        }

        /// <summary>
        /// 画面の状態更新する
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面の状態を更新します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void RefreshParent(bool flag)
        {
            // 更新場合
            if (flag)
            {
                // グリット項目を更新
                this._detailGrid.SettingGrid();
                // ボタン操作有効処理
                this._detailGrid.SetButtonEnable();
            }
        }

        /// <summary>
        /// 得意先ガイド表示処理
        /// </summary>
        /// <param name="customerSearchRet">得意先マスタ</param>
        /// <param name="searchMode">検索モード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 得意先ガイドを表示します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private int ShowCustomerGuide(out CustomerSearchRet customerSearchRet, int searchMode)
        {
            customerSearchRet = new CustomerSearchRet();

            this._cusotmerGuideSelected = false;

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(searchMode, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (this._cusotmerGuideSelected == true)
            {
                customerSearchRet = this._customerSearchRet;
                return 0;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note        : 得意先ガイドで得意先を選択した時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }

            // 選択した得意先マスタをバッファに保持
            this._customerSearchRet = customerSearchRet.Clone();

            this._cusotmerGuideSelected = true;
        }

        /// <summary>
        /// 明細グリッド変更有無チェック
        /// </summary>
        /// <returns>True:変更有; False:変更無</returns>
        /// <remarks>
        /// <br>Note        : 明細グリッド変更有無チェックを行い</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private bool CompareGridDataWithOriginal()
        {
            if (this._detailGrid.uGrid_Details.ActiveCell != null
                && this._detailGrid.uGrid_Details.ActiveCell.IsInEditMode)
            {
                // 編集モードを解除する
                this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
            }

            if (this._carMngListInputAcs.CarInfoDataTable.Rows.Count
                != this._carMngListInputAcs.OriginalCarInfoDataTable.Rows.Count)
            {
                // 行数が変わっているか
                return true;
            }

            // 値が変更されたセルがあるか
            for (int rowIndex = 0; rowIndex < this._carMngListInputAcs.CarInfoDataTable.Rows.Count; rowIndex++)
            {
                for (int colIndex = 0; colIndex < this._carMngListInputAcs.CarInfoDataTable.Columns.Count; colIndex++)
                {

                    if (this._carMngListInputAcs.CarInfoDataTable.Rows[rowIndex][colIndex].ToString()
                        != this._carMngListInputAcs.OriginalCarInfoDataTable.Rows[rowIndex][colIndex].ToString())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note        : エラーメッセージ表示処理</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                "PMSYA09021UA",						// アセンブリＩＤまたはクラスＩＤ
                ct_PRINTNAME,				// プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
        # endregion
        #endregion

        #region ■ コントロールイベント ■
        /// <summary>
        /// ロードイベント                                            
        /// </summary>
        /// <param name="sender">イベントソース</param>                            
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : 画面がロード時に発生します。</br>      
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void PMSYA09020UA_Load(object sender, EventArgs e)
        {
            // 画面初期化
            InitialScreenSetting();

            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add(this.uGroupBox_ExtractInfo.Name);
            this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);

            // 画面イメージ統一
            this._controlScreenSkin.LoadSkin();						// 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.SettingScreenSkin(this);		// 画面スキン変更

            // 明細部
            this.Panel_Detail.Controls.Add(this._detailGrid);
            this._detailGrid.Dock = DockStyle.Fill;

            // フォーカス設定タイマー
            this.InitialFocusTimer.Enabled = true;
        }

        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : ツールバークリック時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 終了
                case TOOLBAR_CLOSEBUTTON_KEY:
                    {
                        this.CloseWindow();
                        break;
                    }
                // 検索
                case TOOLBAR_SEARCHBUTTON_KEY:
                    {
                        // 検索
                        this.Search();
                        break;
                    }
                // クリア
                case TOOLBAR_CLEARBUTTON_KEY:
                    {
                        this.Clear();
                        break;
                    }
                // 新規
                case TOOLBAR_NEWBUTTON_KEY:
                    {
                        this.StartInPut(null);
                        break;
                    }
                // 編集
                case TOOLBAR_EDITBUTTON_KEY:
                    {
                        List<Guid> list = this._detailGrid.GetSelectedRowNoList();

                        this.StartInPut(list[0]);
                        break;
                    }
                // 保存
                case TOOLBAR_SAVEBUTTON_KEY:
                    {
                        this.Save();
                        break;
                    }
                // ﾃｷｽﾄ出力
                case TOOLBAR_TEXTOUTPUTBUTTON_KEY:
                    {
                        this.TextOutput();
                        break;
                    }
                // 最新情報
                case TOOLBAR_NEWINFOBUTTON_KEY:
                    {
                        this.Renewal();
                        break;
                    }
            }
        }

        /// <summary>
        /// ChangeFocus イベント(tRetKeyControl1)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 各コントロールからフォーカスが離れたときに発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                // 得意先コード開始
                case "tNedit_CustomerCode_St":
                    {
                        if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                        {
                            if (e.ShiftKey)
                            {
                                e.NextCtrl = DeleteIndication_CheckEditor;
                            }
                            else
                            {
                                if (this.tNedit_CustomerCode_St.GetInt() == 0)
                                {
                                    e.NextCtrl = this.CustomerGuideSt_Button;
                                }
                                else
                                {
                                    e.NextCtrl = this.tNedit_CustomerCode_Ed;
                                }
                            }
                        }
                        break;
                    }
                // 得意先コード終了
                case "tNedit_CustomerCode_Ed":
                    {
                        if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                        {
                            if (e.ShiftKey)
                            {
                                e.NextCtrl = this.tNedit_CustomerCode_St;
                            }
                            else
                            {
                                if (this.tNedit_CustomerCode_Ed.GetInt() == 0)
                                {
                                    e.NextCtrl = this.CustomerGuideEd_Button;
                                }
                                else
                                {
                                    e.NextCtrl = this.tEdit_CarMngCode;
                                }
                            }
                        }
                        break;
                    }
                // 管理番号
                case "tEdit_CarMngCode":
                    {
                        if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                        {
                            if (e.ShiftKey)
                            {
                                e.NextCtrl = this.tNedit_CustomerCode_Ed;
                            }
                            else
                            {
                                if (this.tEdit_CarMngCode.Text == string.Empty)
                                {
                                    e.NextCtrl = this.CarMngCode_Button;
                                }
                                else
                                {
                                    e.NextCtrl = this.tComboEditor_SearchDiv;
                                }
                            }
                        }

                        if (e.Key == Keys.Down)
                        {
                            e.NextCtrl = this._detailGrid.uGrid_Details;
                        }
                        break;
                    }
                // 検索区分
                case "tComboEditor_SearchDiv":
                    {
                        if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                        {
                            if (e.ShiftKey)
                            {
                                e.NextCtrl = this.tEdit_CarMngCode;
                            }
                            else
                            {

                                e.NextCtrl = this._detailGrid.uGrid_Details;
                            }
                        }
                        break;
                    }
                // グリッド
                case "uGrid_Details":
                    {
                        if (this._detailGrid.uGrid_Details.Rows.Count == 0)
                        {
                            return;
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                // グリッドタブ移動制御
                                this._detailGrid.SetGridTabFocus(ref e);
                            }
                            else
                            {
                                this._detailGrid.SetGridTabFocus(ref e);
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (e.NextCtrl.Name == "PMSYA09021UB")
                                {
                                    e.NextCtrl = this.tComboEditor_SearchDiv;
                                }
                                // グリッドシフトタブ移動制御
                                this._detailGrid.SetGridShiftTabFocus(ref e);
                            }
                        }

                        break;
                    }
                // 列サイズ自動調整チェックボックス
                case "uCheckEditor_AutoFillToColumn":
                    {
                        if (e.ShiftKey == true)
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this._detailGrid.uGrid_Details.Rows.Count == 0)
                                {
                                    e.NextCtrl = this.tComboEditor_SearchDiv;
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this._detailGrid.uGrid_Details.Focus();

                                    this._detailGrid.uGrid_Details.Rows[this._detailGrid.uGrid_Details.Rows.Count - 1].Cells["CarNoteGuide"].Activate();
                                    this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = this.tComboEditor_GridFontSize;
                        }
                        break;
                    }
                // 文字サイズコンボボックス
                case "tComboEditor_GridFontSize":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                e.NextCtrl = this.DeleteIndication_CheckEditor;
                            }
                        }
                        break;
                    }
                // 削除済データの表示
                case "DeleteIndication_CheckEditor":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                e.NextCtrl = this.tNedit_CustomerCode_St;
                            }
                        }
                        break;
                    }
            }

            if (e.NextCtrl == null)
            {
                return;
            }

            switch (e.NextCtrl.Name)
            {
                case "PMSYA09021UB":
                case "uGrid_Details":
                    {
                        if (this._detailGrid.uGrid_Details.Rows.Count == 0)
                        {
                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || (e.Key == Keys.Down))
                                {
                                    e.NextCtrl = this.uCheckEditor_AutoFillToColumn;
                                }
                                else if (e.Key == Keys.Up)
                                {
                                    e.NextCtrl = this.tEdit_CarMngCode;
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = this.tComboEditor_SearchDiv;
                                }
                            }
                        }
                        else
                        {
                            string nextFocusColumn;

                            if (e.ShiftKey == false)
                            {
                                if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || (e.Key == Keys.Down))
                                {
                                    e.NextCtrl = null;
                                    this._detailGrid.uGrid_Details.Focus();

                                    int activationColIndex;
                                    int activationRowIndex;

                                    nextFocusColumn = this._detailGrid.GetNextFocusColumnKey(0, 0, false, out activationColIndex, out activationRowIndex);

                                    if (nextFocusColumn != string.Empty)
                                    {
                                        this._detailGrid.uGrid_Details.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();

                                        this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.uCheckEditor_AutoFillToColumn;
                                    }
                                }
                                else if (e.Key == Keys.Up)
                                {
                                    // 最終行にフォーカス
                                    e.NextCtrl = null;
                                    this._detailGrid.uGrid_Details.Focus();

                                    int activationColIndex;
                                    int activationRowIndex;

                                    nextFocusColumn = this._detailGrid.GetNextFocusColumnKey(0, this._detailGrid.uGrid_Details.Rows.Count - 1, false, out activationColIndex, out activationRowIndex);

                                    if (nextFocusColumn != string.Empty)
                                    {
                                        this._detailGrid.uGrid_Details.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();

                                        this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tEdit_CarMngCode;
                                    }
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    e.NextCtrl = null;
                                    this._detailGrid.uGrid_Details.Focus();

                                    int activationColIndex;
                                    int activationRowIndex;

                                    nextFocusColumn = this._detailGrid.GetNextFocusColumnKey(this._detailGrid.uGrid_Details.DisplayLayout.Bands[0].Columns.Count - 1, this._detailGrid.uGrid_Details.Rows.Count - 1, true, out activationColIndex, out activationRowIndex);

                                    if (nextFocusColumn != string.Empty)
                                    {
                                        this._detailGrid.uGrid_Details.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();

                                        this._detailGrid.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tComboEditor_SearchDiv;
                                    }
                                }
                            }
                        }
                    }

                    break;
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 得意先ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void CustomerGuide_Button_Click(object sender, EventArgs e)
        {
            UltraButton uButton = (UltraButton)sender;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                CustomerSearchRet customerSearchRet;

                int status = ShowCustomerGuide(out customerSearchRet, PMKHN04005UA.SEARCHMODE_NORMAL);
                if (status == 0)
                {
                    // フォーカス設定
                    if (uButton.Name == "CustomerGuideSt_Button")
                    {
                        // 開始
                        this.tNedit_CustomerCode_St.SetInt(customerSearchRet.CustomerCode);
                        this.tNedit_CustomerCode_Ed.Focus();
                    }
                    else
                    {
                        // 終了
                        this.tNedit_CustomerCode_Ed.SetInt(customerSearchRet.CustomerCode);
                        this.tEdit_CarMngCode.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 管理番号ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void CarMngCode_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CarMangInputExtraInfo selectedInfo = new CarMangInputExtraInfo();
                CarMngGuideParamInfo paramInfo = new CarMngGuideParamInfo();
                paramInfo.EnterpriseCode = this._enterpriseCode;
                // 「新規登録」行表示なし
                paramInfo.IsDispNewRow = false;
                // 得意先表示あり
                paramInfo.IsDispCustomerInfo = true;
                // 得意先コード絞り込み無し
                paramInfo.IsCheckCustomerCode = false;
                // 管理番号絞り込み無し
                paramInfo.IsCheckCarMngCode = false;
                // 車輌管理区分チェック無し
                paramInfo.IsCheckCarMngDivCd = false;
                paramInfo.IsGuideClick = true;

                int status = this._carMngInputAcs.ExecuteGuid(paramInfo, out selectedInfo);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    if (selectedInfo.CarMngCode != "新規登録")
                    {
                        this.tEdit_CarMngCode.Text = selectedInfo.CarMngCode;
                        this.tComboEditor_SearchDiv.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// CheckedChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 列サイズの自動調整チェックボックスのチェックが変更された時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void uCheckEditor_AutoFillToColumn_CheckedChanged(object sender, EventArgs e)
        {
            this._detailGrid.AutoFillToColumnSetting(this.uCheckEditor_AutoFillToColumn.Checked);
        }

        /// <summary>
        /// ValueChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : フォントサイズコンボボックスの値が変更された時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void tComboEditor_GridFontSize_ValueChanged(object sender, EventArgs e)
        {
            if (this.tComboEditor_GridFontSize.Value == null)
            {
                this._detailGrid.GridFontSizeSetting(11);
            }
            else
            {
                this._detailGrid.GridFontSizeSetting((int)this.tComboEditor_GridFontSize.Value);
            }
        }

        /// <summary>
        /// 削除済みデータ表示ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 削除済みデータ表示ボタンクの値が変更された時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void DeleteIndication_CheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            this._detailGrid.DeleteIndicationSetting(this.DeleteIndication_CheckEditor.Checked);
        }

        /// <summary>
        /// 初期フォーカス設定タイマ
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 初期フォーカス設定タイマ</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>  
        private void InitialFocusTimer_Tick(object sender, EventArgs e)
        {
            // フォーカス設定
            this.tNedit_CustomerCode_St.Focus();

            // 削除済みデータ表示の制御
            this._detailGrid.DeleteIndicationSetting(this.DeleteIndication_CheckEditor.Checked);

            this.InitialFocusTimer.Enabled = false;
        }
        #endregion
    }
}
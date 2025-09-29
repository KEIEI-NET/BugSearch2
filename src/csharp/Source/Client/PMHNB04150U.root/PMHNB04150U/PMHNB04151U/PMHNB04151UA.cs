using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 売上速報表示
    /// </summary>
    ///<remarks>
    /// <br>Note        : 売上速報表示UIフォームクラス</br>
    /// <br>Programmer  : 30418 徳永</br>
    /// <br>Date        : 2008/11/21</br>
    /// </remarks>
    public partial class PMHNB04151UA : Form
    {

        #region プライベート変数

        #region ローカルクラス

        /// <summary>売上速報表示抽出条件クラス</summary>
        SalesReportOrderCndtn _salesReportOrderCndtn = null;

        /// <summary>売上速報表示アクセスクラス</summary>
        SalesReportAcs _salesReportAcs = null;

        /// <summary>売上速報設定表示アクセスクラス</summary>
        SalesReportSettingAcs _salesReportSettingAcs = null;

        #endregion // ローカルクラス

        #region クラス

        /// <summary>拠点アクセスクラス</summary>
        private SecInfoAcs _secInfoAcs;

        /// <summary>拠点アクセスクラス</summary>
        private SecInfoSetAcs _secInfoSetAcs;

        /// <summary>拠点情報データクラス</summary>
        private SecInfoSet _sectionInfo;

        /// <summary>自社情報アクセスクラス</summary>
        private DateGetAcs _dateGetAcs = null;

        /// <summary>UIスキン設定コントロール</summary>
        private ControlScreenSkin _controlScreenSkin = null;

        #endregion // クラス

        #region データセット

        /// <summary>売上速報表示情報データセット</summary>
        SalesReportDataSet _dataSet = null;

        #endregion // データセット

        #region コード類

        /// <summary>企業コード</summary>
        private string _enterpriseCode = string.Empty;

        /// <summary>自拠点コード</summary>
        private string _loginSectionCode = string.Empty;

        /// <summary>ログインユーザーコード</summary>
        private string _loginUserCd = string.Empty;

        /// <summary>ログインユーザー名</summary>
        private string _loginUserName = string.Empty;

        /// <summary>拠点コード</summary>
        private string _sectionCode = string.Empty;

        /// <summary>ボタン用イメージリスト</summary>
        private ImageList _imageList16 = null;

        /// <summary>設定実行フラグ</summary>
        private bool _alreadySetup = false;

        /// <summary>起動時の抽出</summary>
        private int _startupSearch = 0;

        /// <summary>自動更新</summary>
        private int _autoUpdate = 0;

        /// <summary>拠点の初期値</summary>
        private int _initialSectionCode = 0;

        /// <summary>フォント設定値</summary>
        private readonly int[] _fontpitchSize = new int[] { 6, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24 };

        #endregion // コード類

        #endregion // プライベート変数

        #region 定数

        /// <summary>全社コード名称：初期値「全社」</summary>
        private const string CT_NAME_ALLSECCODE = "全社";

        /// <summary>全社コード：初期値「00」</summary>
        private const string CT_CODE_ALLSECCODE = "00";

        /// <summary>表示：初期フォントサイズ</summary>
        private const int CT_DEF_FONT_SIZE = 11;

        /// <summary>起動時検索：する</summary>
        private const int CT_STARTUP_SEARCH_ON = 0;

        /// <summary>起動時検索：しない</summary>
        private const int CT_STARTUP_SEARCH_OFF = 1;

        /// <summary>拠点コード初期値：自拠点</summary>
        private const int CT_DEFSECTIONCODE_BELONG = 0;

        /// <summary>拠点コード初期値：全社</summary>
        private const int CT_DEFSECTIONCODE_WHOLE = 1;

        /// <summary>XMLファイル名称：初期値「PMKHN04150U_Construction.XML」</summary>
        private const string CT_XML_FILE_NAME = "PMKHN04150U_Construction.XML";

        #region メッセージ定数

        /// <summary>エラーメッセージ：「売上日は必須入力項目です。」</summary>
        private const string CT_DATE_NOT_INPUT = "売上日は必須入力項目です。";

        // 2008.12.01 add start [8486]
        /// <summary>エラーメッセージ：「に正しい日付を入力してください。」</summary>
        private const string CT_DATE_INVALID = "に正しい日付を入力してください。";

        /// <summary>エラーメッセージ：「売上日の開始日は、終了日よりも前の日付を選択してください。」</summary>
        private const string CT_DATE_RANGE_INVALID = "売上日の開始日は、終了日よりも前の日付を選択してください。";
        // 2008.12.01 add end [8486]

        /// <summary>エラーメッセージ：「入力された拠点コードが使用できません。」</summary>
        private const string CT_INVALID_SECTION = "入力された拠点コードが使用できません。";

        /// <summary>エラーメッセージ：「選択された売上日は同一月内ではありません。」</summary>
        private const string CT_DATE_NOT_IN_TERM = "選択された売上日は同一月内ではありません。";

        /// <summary>エラーメッセージ：「企業コードが取得されていません。」</summary>
        private const string CT_ENTERPRISE_CODE_NOT_QUALIFIED = "企業コードが取得されていません。";

        /// <summary>エラーメッセージ：「該当するデータが見つかりませんでした。」</summary>
        private const string CT_NOT_FOUND = "該当するデータが見つかりませんでした。";

        /// <summary>メッセージ：「 件のデータが見つかりました。」</summary>
        private const string CT_FOUND_RECORD = " 件のデータが見つかりました。";

        /// <summary>メッセージ：「自動更新の間隔を{0}分に設定しました。」</summary>
        private const string CT_AUTOUPDATE_SET_FOR = "自動更新の間隔を{0}分に設定しました。";

        /// <summary>メッセージ：「最終更新日時：{0}」</summary>
        private const string CT_LASTTIMEUPDATE = "最終更新日時：{0}";

        #endregion // メッセージ定数

        #region グリッド配色

        /// <summary>グリッド カラー1</summary>
        private readonly Color _rowFiscalColBackColor1 = Color.FromArgb(89, 135, 214);
        /// <summary>グリッド カラー2</summary>
        private readonly Color _rowFiscalColBackColor2 = Color.FromArgb(7, 59, 150);
        /// <summary>グリッド 文字色1</summary>
        private readonly Color _rowFiscalColForeColor1 = Color.FromArgb(255, 255, 255);

        /// <summary>グリッド ヘッダーカラー1</summary>
        private readonly Color _headerBackColor1 = Color.FromArgb(89, 135, 214);
        /// <summary>グリッド ヘッダーカラー2</summary>
        private readonly Color _headerBackColor2 = Color.FromArgb(7, 59, 150);
        /// <summary>グリッド 文字色1</summary>
        private readonly Color _headerForeColor1 = Color.FromArgb(255, 255, 255);

        #endregion // グリッド配色

        #endregion // 定数

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMHNB04151UA()
        {
            InitializeComponent();
            
            // 初期設定
            InitializeVariable();

        }

        /// <summary>
        /// フォーム表示後イベント（初期フォーカス関連）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMHNB04121UA_Shown(object sender, System.EventArgs e)
        {
            // 初期フォーカス（拠点）
            this.tEdit_SectionCodeAllowZero.Focus();
        }

        #endregion // コンストラクタ

        #region プライベート関数

        #region 初期配置

        /// <summary>
        /// コントロール類初期配置
        /// </summary>
        private void InitializeVariable()
        {

            // UIスキン設定コントロール初期化
            this._controlScreenSkin = new ControlScreenSkin();

            #region 設定の取得

            this._salesReportSettingAcs = new SalesReportSettingAcs();

            // 設定を取得
            this._salesReportSettingAcs.Deserialize();

            // 設定内容を取得
            this._alreadySetup = this._salesReportSettingAcs.AlreadySetup;
            this._startupSearch = this._salesReportSettingAcs.StartupSearch;
            this._autoUpdate = this._salesReportSettingAcs.AutoUpdateTime;
            this._initialSectionCode = this._salesReportSettingAcs.InitialSectionCode;

            // タイマーセット
            if (this._autoUpdate > 0)
            {
                // タイマーの起動時間をセット(分単位なので*60(秒),*1000(ミリ秒))
                this.timer_AutoUpdate.Interval = this._autoUpdate * 60 * 1000;
                this.timer_AutoUpdate.Enabled = true;

                this.uStatusBar_Main.Panels["Panel_Message"].Text = string.Format(CT_AUTOUPDATE_SET_FOR, this._autoUpdate.ToString());
            }
            else
            {
                this.timer_AutoUpdate.Enabled = false;
            }

            #endregion // 設定の取得

            #region アクセスクラス初期化

            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();          // 拠点
            this._dateGetAcs = DateGetAcs.GetInstance();        // 自社設定取得

            #endregion // アクセスクラス初期化

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;                 // 企業コード
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;   // 自拠点コード
            this._loginUserCd = LoginInfoAcquisition.Employee.EmployeeCode;             // ログインユーザーコード
            this._loginUserName = LoginInfoAcquisition.Employee.Name;                   // ログインユーザー名

            #region ボタンイメージ設定

            // イメージリストを指定(16x16)
            this._imageList16 = IconResourceManagement.ImageList16;

            // ボタンイメージを設定
            this.uButton_SectionGuide.ImageList = this._imageList16;
            this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;

            // ツールバーアイコン
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.CLOSE;
            // --- CHG 2009/03/12 障害ID:12293対応------------------------------------------------------>>>>>
            //this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.DECISION;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.SEARCH;
            // --- CHG 2009/03/12 障害ID:12293対応------------------------------------------------------<<<<<
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.ALLCANCEL;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setting"].SharedProps.AppearancesSmall.Appearance.Image = (int)Size16_Index.SETUP1;

            #endregion // ボタンイメージ設定

            #region 検索条件クラス作成

            this._salesReportOrderCndtn = new SalesReportOrderCndtn();
                        
            #endregion // 検索条件クラス作成

            #region コントロールスキン対応

            List<string> controlNameList = new List<string>();
            controlNameList.Add(this.uExpandableGroupBox_Condition.Name);
            this._controlScreenSkin.SetExceptionCtrl(controlNameList);
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            #endregion // コントロールスキン対応

            #region グリッド設定

            //// アクセスクラスを初期化し、データセットを取得
            this._salesReportAcs = new SalesReportAcs();
            this._dataSet = this._salesReportAcs.DataSet;

            //// グリッドで表示に使用するデータビューを作成
            DataView dView = new DataView(this._dataSet.SalesReportResult);

            //// データソースとしてデータビューを指定
            this.uGrid_Details.DataSource = dView;

            //// グリッド列を設定
            InitializeGridColumns(this.uGrid_Details.DisplayLayout.Bands[0].Columns);

            #endregion // グリッド設定

            // 画面クリア
            InitializeScreen();

            // グリッドを調整しておく
            this.uGrid_Details.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.uCheckEditor_StatusBar_AutoFillToGridColumn.Checked = true;
            for (int i = 0; i < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
            {
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
            }

            // 起動時検索であれば検索
            if (this._startupSearch == CT_STARTUP_SEARCH_ON)
            {
                this.Search();
            }
        }

        #endregion // 初期配置

        #region 拠点名称取得

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCd">検索する拠点コード</param>
        /// <returns>拠点名</returns>
        private string GetSectionName(string sectionCd)
        {
            int status = this._secInfoSetAcs.Read(out _sectionInfo, this._enterpriseCode, sectionCd);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 2008.12.01 add start [8495]
                if (_sectionInfo.LogicalDeleteCode == 0)
                {
                    return _sectionInfo.SectionGuideNm;
                }
                else
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                        CT_INVALID_SECTION, 0, MessageBoxButtons.OK);
                    this.tEdit_SectionCodeAllowZero.Clear();
                    return string.Empty;
                }
            }
            else
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                    CT_INVALID_SECTION, 0, MessageBoxButtons.OK);
                this.tEdit_SectionCodeAllowZero.Clear();
                // 2008.12.01 add end [8495]
                return string.Empty;
            }
        }

        #endregion // 拠点名称取得

        #region 画面の初期化

        /// <summary>
        /// 画面の初期化
        /// </summary>
        private void InitializeScreen()
        {
            this.tEdit_SectionCodeAllowZero.Clear();
            this.tEdit_SectionName.Clear();

            // データセットもクリア
            this._dataSet.SalesReportResult.Clear();

            // 初期値を設定値に従って表示
            if (this._initialSectionCode == CT_DEFSECTIONCODE_BELONG) // 自拠点
            {
                this.tEdit_SectionCodeAllowZero.Text = this._loginSectionCode.Trim().PadLeft(2, '0');
                this.tEdit_SectionName.Text = GetSectionName(this._loginSectionCode);
            }
            else
            {
                this.tEdit_SectionCodeAllowZero.Text = CT_CODE_ALLSECCODE;
                this.tEdit_SectionName.Text = CT_NAME_ALLSECCODE;
            }

            // 売上日（どちらも今日）
            this.tDateEdit_SalesDateSt.SetDateTime(DateTime.Today);
            this.tDateEdit_SalesDateEd.SetDateTime(DateTime.Today);

            // ログインユーザー名表示
            this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginChargeName"].SharedProps.Caption = this._loginUserName;

            // 文字サイズ設定
            for (int i = 0; i < this._fontpitchSize.Length; i++)
            {
                this.tComboEditor_StatusBar_FontSize.Items.Add(this._fontpitchSize[i], this._fontpitchSize[i].ToString());
            }

            // 文字サイズ初期値
            this.tComboEditor_StatusBar_FontSize.Text = CT_DEF_FONT_SIZE.ToString();

            // 2008.12.01 add start [8507]
            // ステータスバーもクリア
            this.uStatusBar_Main.Panels["Panel_Message"].Text = string.Empty;
            // 2008.12.01 add end [8507]

            // フォーカスを拠点に
            this.tEdit_SectionCodeAllowZero.Focus();
        }

        #endregion // 画面の初期化

        #region グリッド列初期化

        /// <summary>
        /// グリッド列の初期化
        /// </summary>
        /// <param name="Columns"></param>
        private void InitializeGridColumns(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns)
        {
            // 表示形式のある列で使用
            string formatCurrency = "#,##0;-#,##0;";
            string formatPercentage = "##0.00;";

            // 表示位置初期値
            int visiblePosition = 1;

            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //非表示設定
                column.Hidden = true;
                column.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;

                column.AutoEdit = false;
                column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }

            //--------------------------------------------------------------------------------
            //  表示するカラム情報
            //--------------------------------------------------------------------------------

            // 拠点（拠点ガイド名称）
            Columns[this._dataSet.SalesReportResult.SectionGuideSnmColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesReportResult.SectionGuideSnmColumn.ColumnName].Width = 130;
            Columns[this._dataSet.SalesReportResult.SectionGuideSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesReportResult.SectionGuideSnmColumn.ColumnName].Header.Caption = "拠点";
            Columns[this._dataSet.SalesReportResult.SectionGuideSnmColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
            Columns[this._dataSet.SalesReportResult.SectionGuideSnmColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
            Columns[this._dataSet.SalesReportResult.SectionGuideSnmColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
            Columns[this._dataSet.SalesReportResult.SectionGuideSnmColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            Columns[this._dataSet.SalesReportResult.SectionGuideSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._dataSet.SalesReportResult.SectionGuideSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 純売上
            Columns[this._dataSet.SalesReportResult.SalesTotalTaxExcColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesReportResult.SalesTotalTaxExcColumn.ColumnName].Width = 120;
            Columns[this._dataSet.SalesReportResult.SalesTotalTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesReportResult.SalesTotalTaxExcColumn.ColumnName].Header.Caption = "純売上";
            Columns[this._dataSet.SalesReportResult.SalesTotalTaxExcColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
            Columns[this._dataSet.SalesReportResult.SalesTotalTaxExcColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
            Columns[this._dataSet.SalesReportResult.SalesTotalTaxExcColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
            Columns[this._dataSet.SalesReportResult.SalesTotalTaxExcColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            Columns[this._dataSet.SalesReportResult.SalesTotalTaxExcColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._dataSet.SalesReportResult.SalesTotalTaxExcColumn.ColumnName].Format = formatCurrency;
            Columns[this._dataSet.SalesReportResult.SalesTotalTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 売上目標
            Columns[this._dataSet.SalesReportResult.SalesTargetMoneyColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesReportResult.SalesTargetMoneyColumn.ColumnName].Width = 120;
            Columns[this._dataSet.SalesReportResult.SalesTargetMoneyColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesReportResult.SalesTargetMoneyColumn.ColumnName].Header.Caption = "売上目標";
            Columns[this._dataSet.SalesReportResult.SalesTargetMoneyColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
            Columns[this._dataSet.SalesReportResult.SalesTargetMoneyColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
            Columns[this._dataSet.SalesReportResult.SalesTargetMoneyColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
            Columns[this._dataSet.SalesReportResult.SalesTargetMoneyColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            Columns[this._dataSet.SalesReportResult.SalesTargetMoneyColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._dataSet.SalesReportResult.SalesTargetMoneyColumn.ColumnName].Format = formatCurrency;
            Columns[this._dataSet.SalesReportResult.SalesTargetMoneyColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 達成率
            Columns[this._dataSet.SalesReportResult.AchievementRateNetColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesReportResult.AchievementRateNetColumn.ColumnName].Width = 80;
            Columns[this._dataSet.SalesReportResult.AchievementRateNetColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesReportResult.AchievementRateNetColumn.ColumnName].Header.Caption = "達成率";
            Columns[this._dataSet.SalesReportResult.AchievementRateNetColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
            Columns[this._dataSet.SalesReportResult.AchievementRateNetColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
            Columns[this._dataSet.SalesReportResult.AchievementRateNetColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
            Columns[this._dataSet.SalesReportResult.AchievementRateNetColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            Columns[this._dataSet.SalesReportResult.AchievementRateNetColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._dataSet.SalesReportResult.AchievementRateNetColumn.ColumnName].Format = formatPercentage;
            Columns[this._dataSet.SalesReportResult.AchievementRateNetColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 粗利
            Columns[this._dataSet.SalesReportResult.GrossMarginColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesReportResult.GrossMarginColumn.ColumnName].Width = 120;
            Columns[this._dataSet.SalesReportResult.GrossMarginColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesReportResult.GrossMarginColumn.ColumnName].Header.Caption = "粗利";
            Columns[this._dataSet.SalesReportResult.GrossMarginColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
            Columns[this._dataSet.SalesReportResult.GrossMarginColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
            Columns[this._dataSet.SalesReportResult.GrossMarginColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
            Columns[this._dataSet.SalesReportResult.GrossMarginColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            Columns[this._dataSet.SalesReportResult.GrossMarginColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._dataSet.SalesReportResult.GrossMarginColumn.ColumnName].Format = formatCurrency;
            Columns[this._dataSet.SalesReportResult.GrossMarginColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 粗利目標
            Columns[this._dataSet.SalesReportResult.SalesTargetProfitColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesReportResult.SalesTargetProfitColumn.ColumnName].Width = 120;
            Columns[this._dataSet.SalesReportResult.SalesTargetProfitColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesReportResult.SalesTargetProfitColumn.ColumnName].Header.Caption = "粗利目標";
            Columns[this._dataSet.SalesReportResult.SalesTargetProfitColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
            Columns[this._dataSet.SalesReportResult.SalesTargetProfitColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
            Columns[this._dataSet.SalesReportResult.SalesTargetProfitColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
            Columns[this._dataSet.SalesReportResult.SalesTargetProfitColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            Columns[this._dataSet.SalesReportResult.SalesTargetProfitColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._dataSet.SalesReportResult.SalesTargetProfitColumn.ColumnName].Format = formatCurrency;
            Columns[this._dataSet.SalesReportResult.SalesTargetProfitColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 達成率
            Columns[this._dataSet.SalesReportResult.AchievementRateGrossColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesReportResult.AchievementRateGrossColumn.ColumnName].Width = 80;
            Columns[this._dataSet.SalesReportResult.AchievementRateGrossColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesReportResult.AchievementRateGrossColumn.ColumnName].Header.Caption = "達成率";
            Columns[this._dataSet.SalesReportResult.AchievementRateGrossColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
            Columns[this._dataSet.SalesReportResult.AchievementRateGrossColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
            Columns[this._dataSet.SalesReportResult.AchievementRateGrossColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
            Columns[this._dataSet.SalesReportResult.AchievementRateGrossColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            Columns[this._dataSet.SalesReportResult.AchievementRateGrossColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._dataSet.SalesReportResult.AchievementRateGrossColumn.ColumnName].Format = formatPercentage;
            Columns[this._dataSet.SalesReportResult.AchievementRateGrossColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 稼働日
            Columns[this._dataSet.SalesReportResult.OperationDayStringColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesReportResult.OperationDayStringColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesReportResult.OperationDayStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.SalesReportResult.OperationDayStringColumn.ColumnName].Header.Caption = "稼働日";
            Columns[this._dataSet.SalesReportResult.OperationDayStringColumn.ColumnName].Header.Appearance.BackColor = _headerBackColor1;
            Columns[this._dataSet.SalesReportResult.OperationDayStringColumn.ColumnName].Header.Appearance.BackColor2 = _headerBackColor2;
            Columns[this._dataSet.SalesReportResult.OperationDayStringColumn.ColumnName].Header.Appearance.ForeColor = _headerForeColor1;
            Columns[this._dataSet.SalesReportResult.OperationDayStringColumn.ColumnName].Header.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            Columns[this._dataSet.SalesReportResult.OperationDayStringColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Default;
            Columns[this._dataSet.SalesReportResult.OperationDayStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
        }

        #endregion // グリッド列初期化

        #region 検索

        /// <summary>
        /// 検索
        /// </summary>
        private void Search()
        {
            // メッセージをクリア
            this.uStatusBar_Main.Panels["Panel_Message"].Text = string.Empty;


            // 画面から検索条件クラスを作成

            // 企業コードをセット
            this._salesReportOrderCndtn.EnterpriseCode = this._enterpriseCode;

            // 拠点コードをセット
            if (this.tEdit_SectionCodeAllowZero.Text.Trim().Equals("0") ||
                this.tEdit_SectionCodeAllowZero.Text.Trim().Equals("00"))
            {
                this._salesReportOrderCndtn.SectionCode = string.Empty;
            }
            else if (String.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim()))
            {
                this._salesReportOrderCndtn.SectionCode = string.Empty;
            }
            else
            {
                this._salesReportOrderCndtn.SectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim();
            }

            // 売上日開始をセット
            this._salesReportOrderCndtn.St_SalesDate = this.tDateEdit_SalesDateSt.GetLongDate();

            // 売上日終了をセット
            this._salesReportOrderCndtn.Ed_SalesDate = this.tDateEdit_SalesDateEd.GetLongDate();

            // パラメータチェック
            string errorMsg = string.Empty;
            Control checkControl = null;
            checkControl = CheckParameter(out errorMsg);
            if (checkControl != null)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, "PMHNB04120U",
                               errorMsg, 0, MessageBoxButtons.OK);
                checkControl.Focus();
                return;
            }
            else
            {
                int recordCount = 0;

                // データセットをクリア
                this._dataSet.SalesReportResult.Clear();

                // 検索実行
                this._salesReportAcs.Search(this._salesReportOrderCndtn, out recordCount);

                if (recordCount > 0)
                {
                    // ソート順を作成
                    DataView dView = (DataView)this.uGrid_Details.DataSource;
                    dView.Sort = "RowNo Asc";

                    // 自動更新ONの場合は最終更新日時を表示
                    if (this._autoUpdate > 0)
                    {
                        this.uStatusBar_Main.Panels["Panel_Message"].Text = recordCount.ToString() + CT_FOUND_RECORD + "　" + string.Format(CT_LASTTIMEUPDATE, DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));
                    }
                    else
                    {
                        this.uStatusBar_Main.Panels["Panel_Message"].Text = recordCount.ToString() + CT_FOUND_RECORD;
                    }
                }
                else
                {
                    // 自動更新ONの場合は最終更新日時を表示
                    if (this._autoUpdate > 0)
                    {
                        this.uStatusBar_Main.Panels["Panel_Message"].Text = CT_NOT_FOUND + "　" + string.Format(CT_LASTTIMEUPDATE, DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));
                    }
                    else
                    {
                        this.uStatusBar_Main.Panels["Panel_Message"].Text = CT_NOT_FOUND;
                    }
                }

                // 全てのグリッドの背景色を調整
                //RowColorChangeAll(false, 0);

            }
        }

        #endregion // 検索

        #region パラメータチェック

        /// <summary>
        /// パラメータチェック関数
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        private Control CheckParameter(out string errorMsg)
        {
            errorMsg = string.Empty;

            // パラメータが必須のものをチェック

            // 売上日(開始)
            if (this._salesReportOrderCndtn.St_SalesDate == 0)
            {
                errorMsg = CT_DATE_NOT_INPUT;
                return this.tDateEdit_SalesDateSt;
            }
            // 2008.12.01 add start [8486]
            if (!TDateTime.IsAvailableDate(this.tDateEdit_SalesDateSt.GetDateTime()))
            {
                errorMsg = "売上日(開始)" + CT_DATE_INVALID;
                return this.tDateEdit_SalesDateSt;
            }
            // 2008.12.01 add end [8486]

            // 売上日(終了)
            if (this._salesReportOrderCndtn.Ed_SalesDate == 0)
            {
                errorMsg = CT_DATE_NOT_INPUT;
                return this.tDateEdit_SalesDateEd;
            }
            // 2008.12.01 add start [8486]
            if (!TDateTime.IsAvailableDate(this.tDateEdit_SalesDateEd.GetDateTime()))
            {
                errorMsg = "売上日(終了)" + CT_DATE_INVALID;
                return this.tDateEdit_SalesDateEd;
            }
            // 2008.12.01 add end [8486]

            if (this._salesReportOrderCndtn.St_SalesDate - this._salesReportOrderCndtn.Ed_SalesDate > 0)
            {
                errorMsg = CT_DATE_RANGE_INVALID;
                return this.tDateEdit_SalesDateEd;
            }

            //// 企業コード
            //if (String.IsNullOrEmpty(this._salesReportOrderCndtn.EnterpriseCode))
            //{
            //    errorMsg = CT_ENTERPRISE_CODE_NOT_QUALIFIED;
            //    return null;
            //}

            // 開始日から月の終了日を取得
            DateTime dYearMonth;
            int iYear = 0;
            DateTime dStartDate;
            DateTime dEndDate;

            this._dateGetAcs.GetYearMonth(TDateTime.LongDateToDateTime(this._salesReportOrderCndtn.St_SalesDate), out dYearMonth, out iYear, out dStartDate, out dEndDate);
            if (TDateTime.LongDateToDateTime(this._salesReportOrderCndtn.Ed_SalesDate) > dEndDate)
            {
                errorMsg = CT_DATE_NOT_IN_TERM;
                return this.tDateEdit_SalesDateEd;
            }

            return null;
        }

        #endregion // パラメータチェック

        #region グリッドの背景色を変更

        /// <summary>
        /// 行の背景色変更処理
        /// </summary>
        /// <param name="isSelected">bool 選択されている</param>
        /// <param name="gridRow">行オブジェクト</param>
        private void RowColorChangeAll(bool isSelected, Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            if (gridRow == null) return;

            //// 対象行が選択されているかそうでないかで配色が異なる
            //if (isSelected)
            ////{
            //    // グリッドの背景色を設定
            //    gridRow.Appearance.BackColor = _rowBackColor1;
            //    gridRow.Appearance.BackColor2 = _rowBackColor2;
            //    // グラデーションを設定
            //    gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            //}
            //else
            //{
            // 背景色を標準の配色に戻す
            if (gridRow.Index % 2 == 1)
            {
                gridRow.Appearance.BackColor = Color.Lavender;
            }
            else
            {
                gridRow.Appearance.BackColor = Color.White;
            }
            // グラデーションを設定
            gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            //}
        }

        #endregion // グリッドの背景色を変更

        #region 設定画面

        /// <summary>
        /// 設定画面
        /// </summary>
        private void OptionSetup()
        {
            // メッセージクリア
            this.uStatusBar_Main.Panels["Panel_Message"].Text = string.Empty;

            PMHNB04151UB OptionSetupForm = new PMHNB04151UB();
            OptionSetupForm.AlreadySetup = this._alreadySetup;
            OptionSetupForm.XmlFileName = CT_XML_FILE_NAME;
            OptionSetupForm.AutoUpdate = this._autoUpdate;
            OptionSetupForm.StartupSearch = this._startupSearch;
            OptionSetupForm.InitialSectionCode = this._initialSectionCode;

            DialogResult result = OptionSetupForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                this._alreadySetup = OptionSetupForm.AlreadySetup;
                this._autoUpdate = OptionSetupForm.AutoUpdate;
                this._startupSearch = OptionSetupForm.StartupSearch;
                this._initialSectionCode = OptionSetupForm.InitialSectionCode;

                // 設定を保存
                this._salesReportSettingAcs.AlreadySetup = this._alreadySetup;
                this._salesReportSettingAcs.AutoUpdateTime = this._autoUpdate;
                this._salesReportSettingAcs.StartupSearch = this._startupSearch;
                this._salesReportSettingAcs.InitialSectionCode = this._initialSectionCode;

                this._salesReportSettingAcs.Serialize();

                // 自動更新が設定された場合は適用する
                if (this._autoUpdate > 0)
                {
                    this.timer_AutoUpdate.Interval = this._autoUpdate * 60 * 1000;
                    this.timer_AutoUpdate.Enabled = true;

                    this.uStatusBar_Main.Panels["Panel_Message"].Text = string.Format(CT_AUTOUPDATE_SET_FOR, this._autoUpdate.ToString());
                }
            }
        }

        #endregion // 設定画面

        #endregion // プライベート関数

        #region コントロールメソッド

        #region ガイドボタン

        /// <summary>
        /// 拠点ガイドボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            // 拠点ガイド表示
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out _sectionInfo);

            // ステータスが正常時のみ情報をUIにセット
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_SectionCodeAllowZero.Text = _sectionInfo.SectionCode.Trim();
                this.tEdit_SectionName.Text = _sectionInfo.SectionGuideNm.Trim();
                // 2008.12.10 add start [9003]
                this.tDateEdit_SalesDateSt.Focus();
                // 2008.12.10 add start [9003]
            }
            else
            {
                // 2008.12.01 del start [8482]
                //this.tEdit_SectionCodeAllowZero.Clear();
                //this.tEdit_SectionName.Text = "";
                // 2008.12.01 del end [8482]
            }
        }
        
        #endregion // ガイドボタン

        #region ツールバー

        /// <summary>
        /// ツールバー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                #region 終了ボタン
                case "ButtonTool_Close":
                    {
                        this.Close();
                        break;
                    }
                #endregion // 終了ボタン

                #region 確定ボタン
                case "ButtonTool_Decision":
                    {
                        Search();
                        break;
                    }
                #endregion // 確定ボタン

                #region クリアボタン
                case "ButtonTool_Clear":
                    {
                        InitializeScreen();
                        break;
                    }
                #endregion // クリアボタン


                #region 設定ボタン
                case "ButtonTool_Setting":
                    {
                        OptionSetup();
                        break;
                    }
                #endregion // 設定ボタン

                default: break;
            }
        }

        #endregion // ツールバー

        #region 名称変換(Leaveイベント)

        /// <summary>
        /// 拠点コード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_SectionCodeAllowZero_Leave(object sender, EventArgs e)
        {
            // 名称変換
            this._sectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');
            string sectionName = string.Empty;

            // 全社対応処理
            if (this._sectionCode.Equals("0") || this._sectionCode.Equals("00"))
            {
                // コードは規定の全体コードへ（検索時には規定の全体コードのとき空白にする）
                this._sectionCode = CT_CODE_ALLSECCODE;
                sectionName = CT_NAME_ALLSECCODE;
                this.tEdit_SectionName.Text = sectionName;
                // 2008.12.10 add start [9003]
                this.tDateEdit_SalesDateSt.Focus();
                // 2008.12.10 add end [9003]
            }
            else if (!String.IsNullOrEmpty(this._sectionCode))
            {
                sectionName = this.GetSectionName(this._sectionCode);
                if (!String.IsNullOrEmpty(sectionName))
                {
                    this.tEdit_SectionName.Text = sectionName;
                }
                else
                {
                    this.tEdit_SectionName.Clear();
                    this.tEdit_SectionCodeAllowZero.Focus();
                }
            }
        }

        #endregion // 名称変換(Leaveイベント)

        #region アローキーコントロール

        /// <summary>
        /// アローキーコントロール
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // 名前により分岐
            switch (e.PrevCtrl.Name)
            {
                //---------------------------------------------------------------
                // フィールド間移動
                //---------------------------------------------------------------

                #region 拠点コード
                case "tEdit_SectionCodeAllowZero":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    if (String.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim()))
                                    {
                                        e.NextCtrl = this.uButton_SectionGuide;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tDateEdit_SalesDateSt;
                                    }
                                    break;
                                }
                            // 2008.12.01 del start [8489]
                            //case Keys.Down:
                            //    {
                            //        e.NextCtrl = this.;
                            //        break;
                            //    }
                            //case Keys.Up:
                            //    {
                            //        e.NextCtrl = this.tNedit_CustomerCode;
                            //        break;
                            //    }
                            // 2008.12.01 del end [8489]
                        }
                        break;
                    }
                #endregion // 拠点コード

                #region 拠点ガイド
                case "uButton_SectionGuide":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                            //case Keys.Up:
                            //case Keys.Down:
                                {
                                    e.NextCtrl = this.tDateEdit_SalesDateSt;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // 拠点ガイド

                #region 売上日（開始）
                case "tDateEdit_SalesDateSt":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.tDateEdit_SalesDateEd;
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // 売上日（開始）

                #region 売上日（終了）
                case "tDateEdit_SalesDateEd":
                    {
                        switch (e.Key)
                        {
                            case Keys.Enter:
                            case Keys.Tab:
                                {
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero; //2008.12.10 modify [9003]
                                    break;
                                }
                        }
                        break;
                    }
                #endregion // 売上日（終了）

                default: break;

            }
        }

        #endregion // アローキーコントロール

        #region 列サイズの自動調整

        /// <summary>
        /// 列サイズの自動調整
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_StatusBar_AutoFillToGridColumn_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_StatusBar_AutoFillToGridColumn.Checked)
            {
                this.uGrid_Details.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                this.uGrid_Details.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
            }

            // 全ての列でサイズ調整
            for (int i = 0; i < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
            {
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
            }
        }

        #endregion // 列サイズの自動調整

        #region フォントサイズの自動調整

        /// <summary>
        /// フォントサイズの自動調整
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_StatusBar_FontSize_ValueChanged(object sender, EventArgs e)
        {
            int a = this.StrToIntDefOfValue(this.tComboEditor_StatusBar_FontSize.Value, CT_DEF_FONT_SIZE);
            float fontPoint = (float)a;

            this.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = fontPoint;
            this.uGrid_Details.Refresh();
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

        #endregion // フォントサイズの自動調整

        #region 自動更新タイマー

        /// <summary>
        /// 自動更新タイマー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_AutoUpdate_Tick(object sender, EventArgs e)
        {
            this.Search();
        }

        #endregion // 自動更新タイマー

        #endregion // コントロールメソッド

    }
}
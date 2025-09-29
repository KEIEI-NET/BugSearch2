//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ送信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 修 正 日  2009/04/22  修正内容 : 在庫系データの処理と集計機対応の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/07/28  修正内容 : SCM対応‐拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/08/19  修正内容 : Redmine #23807,#23817ソースレビュー結果の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/08/19  修正内容 : Redmine #23808ソースレビュー結果の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/08/25  修正内容 : Redmine #23980送信結果件数不正についての対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 梁森東
// 修 正 日  2011/09/05  修正内容 : Redmine #23936送受信関連の拠点ガイドについての対応
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 孫東響
// 修 正 日  2011/09/14  修正内容 : #24542 拠点選択について
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : yangmj
// 修 正 日  2011/10/10  修正内容 : #25776 送信先拠点入力に自拠点コードも指定可能の変更の対応
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : dingjx
// 修 正 日  2011/11/01  修正内容 : #26228 拠点管理改良／伝票日付による抽出対応
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : xupz
// 修 正 日  2011/11/01  修正内容 : #26228 拠点管理改良／伝票日付による抽出対応
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : xupz
// 修 正 日  2011/11/10  修正内容 : #26228 拠点管理改良／伝票日付による抽出対応
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : xupz
// 修 正 日  2011/11/11  修正内容 : #26228 拠点管理改良／伝票日付による抽出対応
//----------------------------------------------------------------------------//
// 管理番号  10900690-00 作成担当 : zhlj
// 修 正 日  2013/02/07  修正内容 : 10900690-00 2013/3/13配信分の緊急対応
//                                  Redmine#34588 拠点管理改良／送信確認画面の追加仕様の変更対応
//----------------------------------------------------------------------------//
// 管理番号  11600006-00 作成担当 : 譚洪
// 修 正 日  2020/09/25  修正内容 : PMKOBETSU-3877の対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller;
using Infragistics.Win.UltraWinGrid;
using System.IO;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// データ送信処理
    /// </summary>
    /// <remarks>
    /// Note       : データ送信処理です。<br />
    /// Programmer : 譚洪<br />
    /// Date       : 2009.04.02<br />
    /// Update Note: 2020/09/25 譚洪<br />
    /// 管理番号   : 11600006-00<br />
    ///            : PMKOBETSU-3877の対応<br />
    /// </remarks>
    public partial class PMKYO01001UA : Form
    {
        #region ■ Const Memebers ■
        private const string ct_ClassID = "PMKYO01001UA";
        private const string ERROR_BATU = "×";
        private const string UI_XML_NAME = "PMKYO01001UA_SectionSetting.xml";//ADD 2011/09/14 sundx #24542 拠点選択について
        #endregion ■ Const Memebers ■

        # region ■ private field ■

        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _updateButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _getButton;//ADD 2013/02/07 zhlj For Redmine#34588
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        private ControlScreenSkin _controlScreenSkin;
        // 更新結果データテーブル
        private UpdateResultDataSet.UpdateResultDataTable _updateResultDataTable;
        // 抽出条件データテーブル
        private ExtractionConditionDataSet.ExtractionConditionDataTable _extractionConditionDataTable;
        private UpdateCountInputAcs _updateCountInputAcs;
        private static readonly Color DISABLE_COLOR = Color.Gainsboro;
        private static readonly Color DISABLE_FONT_COLOR = Color.Black;
        private string _loginName = LoginInfoAcquisition.Employee.Name;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginEmplooyCode = LoginInfoAcquisition.Employee.EmployeeCode;
        private DateTime _startTime = new DateTime();
        private string _baseCode = string.Empty;
        /// <summary>デフォルト行の外観設定</summary>
        Infragistics.Win.Appearance _defRowAppearance = new Infragistics.Win.Appearance();
        /// <summary>選択時の行外観設定</summary>
        private readonly Color _selBackColor = Color.FromArgb(251, 230, 148);
        private readonly Color _selBackColor2 = Color.FromArgb(238, 149, 21);
        private int _connectPointDiv = 0;
        // ADD 2009/05/20 --->>>
        private Control _prevControl = null;
        private DateTime _preDataTime = DateTime.MinValue;
        // ADD 2009/05/20 ---<<<
        private ArrayList _sendDataList = null;

		//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
        /// <summary>拠点</summary>
        private SecInfoSetAcs _secInfoSetAcs;
		private string _preSectionCode;
		private ArrayList sendDestSecList = new ArrayList();
		private ArrayList _searchSecMngList = null;
		private const string ALL_SECTIONCODE = "00"; 
		private ArrayList _allConditionDataList =new ArrayList();
		private ArrayList selectSendInfoList = new ArrayList();
		private ExtractionConditionDataSet.ExtractionConditionDataTable _allConditionDataTable;
		private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
		private ArrayList _compareSecmngList = new ArrayList();
		//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
        private DataSet _uiDataSet;//ADD 2011/09/14 sundx #24542 拠点選択について
        private string _initSecCode = "00";//ADD 2011/09/14 sundx #24542 拠点選択について
        private DateGetAcs _dateGetAcs; // ADD 2011/11/11 xupz
        private const string MESSAGE_InvalidDate = "有効な日付ではありません。"; // ADD 2011/11/11 xupz
        // ----- ADD 2013/02/07 zhlj For Redmine#34588 ---------->>>>>
        /// <summary>抽出結果あるかどうか区分</summary>
        private bool _isEmpty = true;
        // ----- ADD 2013/02/07 zhlj For Redmine#34588 ----------<<<<<
        # endregion ■ private field ■

        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PMKYO01001UA()
        {
	        InitializeComponent();
            // 変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._updateButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Update"];
            this._getButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Get"];//ADD 2013/02/07 zhlj For Redmine#34588
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Clear"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();
            this._updateCountInputAcs = UpdateCountInputAcs.GetInstance();
            this._updateResultDataTable = this._updateCountInputAcs.UpdateResultDataTable;
            this._extractionConditionDataTable = this._updateCountInputAcs.ExtractionConditionDataTable;

			this._secInfoSetAcs = new SecInfoSetAcs();//ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）
            // ----- ADD 2011/11/11 xupz---------->>>>>
            this._dateGetAcs = DateGetAcs.GetInstance();
            this.tDateEditSt.SetDateTime(System.DateTime.Now);
            this.tDateEditEd.SetDateTime(System.DateTime.Now);
            // ----- ADD 2011/11/11 xupz----------<<<<<
        }
        # endregion ■ コンストラクタ ■

        #region  ■ ボタン初期設定処理 ■
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._updateButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            this._getButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;//ADD 2013/02/07 zhlj For Redmine#34588
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
			this.uButton_SectionGuide.Appearance.Image = _imageList16.Images[(int)Size16_Index.STAR1];//ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）

        }
        # endregion ■ ボタン初期設定処理 ■

        # region ■ フォームロード ■
        /// <summary>
        /// 画面の処理化処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>   
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: 画面の処理化を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.03.26</br>
        /// <br>Update      : dingjx</br>
        /// <br>Note        : Redmine #26228</br>
        /// </remarks>
        private void PMKYO01001UA_Load(object sender, EventArgs e)
        {
            _initSecCode = GetSection();//ADD 2011/09/14 sundx #24542
			//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
			// 送信先初期化処理
			GuidInitProc();
			this.timer_InitialSetFocus.Enabled = true;
			//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<

            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            this.ButtonInitialSetting();

            this.Acc_Grid.DataSource = this._updateResultDataTable;
            this.Condition_Grid.DataSource = this._extractionConditionDataTable;

            // ログイン担当者の設定
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;

            if (0 != this.Condition_Grid.Rows.Count) 
			{
				//this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells["BeginningDate"];// DEL 2011/07/25
				this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.SendDestCondColumn.ColumnName];// ADD 2011/07/25
            }
            InitSecCode();//ADD 2011/09/14 sundx #24542

            //  ADD dingjx  2011/11/01  --------------------------->>>>>>
            //抽出条件区分
            this.tce_ExtractCondDiv.SelectedIndex = Convert.ToInt32(this.GetExtractCondDiv());
            this.ChangeConditionGrid();
            //  ADD dingjx  2011/11/01  ---------------------------<<<<<<
        }
        # endregion ■ フォームロード ■

        # region ■ 画面設定ファイル処理 ADD sundx #24542 拠点選択について ■
        /// <summary>
        /// 前次選択の拠点コードを取得
        /// </summary>
        /// <returns>拠点コード</returns>
        public string GetSection()
        {
            string secCode = string.Empty;
            try
            {
                string fileName = Path.Combine(ConstantManagement_ClientDirectory.UISettings, UI_XML_NAME);

                if (UserSettingController.ExistUserSetting(fileName))
                {
                    if (_uiDataSet == null)
                    {
                        _uiDataSet = new DataSet();
                    }

                    _uiDataSet.ReadXml(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, fileName));
                    //secCode = _uiDataSet.Tables[0].Rows[0][0].ToString(); //  DEL dingjx  2011/11/01
                    secCode = _uiDataSet.Tables["Section"].Rows[0][0].ToString(); //  ADD dingjx  2011/11/01
                }
            }
            catch { }
            return secCode;
        }
        /// <summary>
        /// 選択した拠点コードをXMLファイルに保存
        /// </summary>
        /// <param name="secCode">拠点コード</param>
        /// <returns>ステータス</returns>
        public int SetSecCode(string secCode)
        {
            int status = 0;
            try
            {
                if (!string.IsNullOrEmpty(secCode))
                {
                    string fileName = Path.Combine(ConstantManagement_ClientDirectory.UISettings, UI_XML_NAME);
                    fileName = Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, fileName);
                    if (_uiDataSet == null)
                    {
                        _uiDataSet = new DataSet();
                    }
                    //if (_uiDataSet.Tables.Count == 0) //  DEL dingjx  2011/11/01
                    if (_uiDataSet.Tables["Section"] == null)   //  ADD dingjx  2011/11/01
                    {
                        DataTable dt = new DataTable("Section");
                        DataColumn col = new DataColumn("SecCode", typeof(string));
                        dt.Columns.Add(col);
                        _uiDataSet.Tables.Add(dt);
                    }
                    //  DEL dingjx  2011/11/01  ------------------>>>>>>
                    //_uiDataSet.Tables[0].Clear();
                    //DataRow row = _uiDataSet.Tables[0].NewRow();
                    //row[0] = secCode;
                    //_uiDataSet.Tables[0].Rows.Add(row);
                    //  DEL dingjx  2011/11/01  ------------------<<<<<<
                    //  ADD dingjx  2011/11/01  ------------------>>>>>>
                    _uiDataSet.Tables["Section"].Clear();
                    DataRow row = _uiDataSet.Tables["Section"].NewRow();
                    row[0] = secCode;
                    _uiDataSet.Tables["Section"].Rows.Add(row);
                    //  ADD dingjx  2011/11/01  ------------------>>>>>>
                    _uiDataSet.WriteXml(fileName);
                }
            }
            catch
            {
                status = 1000;
            }
            return status;
        }
        private void InitSecCode()
        {
            try
            {
                string secCode = GetSection();
                if (string.IsNullOrEmpty(secCode) || "".Equals(secCode.Trim()))
                {
                    return;
                }
                if (string.Empty.Equals(GetSectionName(secCode.Trim())))
                {
                    this.tEdit_SectionCodeAllowZero.DataText = this._preSectionCode;
                }
                else
                {
                    this.tEdit_SectionCodeAllowZero.Text = secCode.Trim();
                    this.uLabel_SectionNm.Text = GetSectionName(secCode.Trim());
                    this._preSectionCode = secCode.Trim();
                    ResetGridCol();
                }

            }
            finally
            { }
        }
        # endregion ■ 画面設定ファイル処理 ■

        # region ■ グリッド初期設定関連 ■
        /// <summary>
        /// グリッド列初期設定処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: グリッド初期設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
		private void InitialAccSettingGridCol(ArrayList sendDtList)
        {
            this.Acc_Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.Acc_Grid.DisplayLayout.Bands[0];
            if (editBand == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                //「No列」以外の全てのセルのDiabledColorを設定する。
                if (col.Key != this._updateResultDataTable.RowNoColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
                }
            }

            this.Acc_Grid.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Acc_Grid.DisplayLayout.Appearance.FontData.SizeInPoints = 11F;

            // Filter設定
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.RowNoColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionDataColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionCountColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;


            // 表示幅設定
			//this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.RowNoColumn.ColumnName].Width = 15;//DEL 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）
			this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.RowNoColumn.ColumnName].Width = 30;//ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionDataColumn.ColumnName].Width = 300;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionCountColumn.ColumnName].Width = 100;


            // 固定列設定
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionDataColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionCountColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;

            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.RowNoColumn.ColumnName].Header.Fixed = false;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionDataColumn.ColumnName].Header.Fixed = false;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionCountColumn.ColumnName].Header.Fixed = false;

            // CellAppearance設定
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionDataColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionCountColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // 入力許可設定
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionDataColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionCountColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

			// Style設定
			this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
			this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionDataColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
			this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionCountColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

			//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
			//Hidden列設定
			this.Acc_Grid.DisplayLayout.Bands[0].Columns[this._updateResultDataTable.ExtractionCountColumn.ColumnName].Hidden = true;
			//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<

        }

        /// <summary>
        /// グリッド列初期設定処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: グリッド初期設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void InitialConSettingGridCol()
        {

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.Condition_Grid.DisplayLayout.Bands[0];
            if (editBand == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                //「No列」以外の全てのセルのDiabledColorを設定する。
                if (col.Key != this._extractionConditionDataTable.BaseCodeColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
                }
            }

            // Filter設定
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

			// 表示幅設定
			# region [DEL 2011/07/28]
			//-----DEL 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
			//this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].Width = 50;
			//this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].Width = 130;
			//this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Width = 60;
			//this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Width = 50;
			//this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].Width = 60;
			//this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Width = 50;
			//-----DEL 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
			# endregion
			//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Width = 40;
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendCodeColumn.ColumnName].Width = 50;
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendNameColumn.ColumnName].Width = 200;
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].Width = 50;
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].Width = 200;
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Width = 120;
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Width = 100;
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].Width = 120;
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Width = 100;
			//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
			
            // 固定列設定
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;

            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].Header.Fixed = false;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].Header.Fixed = false;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Header.Fixed = false;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Header.Fixed = false;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].Header.Fixed = false;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Header.Fixed = false;

            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			
			//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
           
			// CellAppearance設定
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

            // 入力許可設定

			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			//this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].CellClickAction = CellClickAction.CellSelect;  //ADD 2011/07/28
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

            // Style設定
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

			//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
			//Hidden列設定
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].Hidden = true;
			this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendCodeColumn.ColumnName].Hidden = true;
			//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
		}

        /// <summary>
        /// グリッド初期設定の設定
        /// </summary>
        /// <remarks>		
        /// <br>Note		: グリッド初期設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void InitialConDataGridCol()
        {
            this.LoadBaseData();

			_allConditionDataTable = new ExtractionConditionDataSet.ExtractionConditionDataTable();
			for (int i = 0; i < this._extractionConditionDataTable.Rows.Count; i++)
			{
				ExtractionConditionDataSet.ExtractionConditionRow newRow = _allConditionDataTable.NewExtractionConditionRow();
				ExtractionConditionDataSet.ExtractionConditionRow row = (ExtractionConditionDataSet.ExtractionConditionRow)_extractionConditionDataTable.Rows[i];
				newRow.SendDestCond = row.SendDestCond;
				newRow.SendCode = row.SendCode;
				newRow.SendName = row.SendName;
				newRow.BaseCode = row.BaseCode;
				newRow.BaseName = row.BaseName;
				newRow.BeginningDate = row.BeginningDate;
				newRow.BeginningTime = row.BeginningTime;
				newRow.EndDate = row.EndDate;
				newRow.EndTime = row.EndTime;
				_allConditionDataTable.Rows.Add(newRow);
			}

		}

        /// <summary>
        /// 画面初期の設定
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 画面初期の設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void LoadBaseData()
        {
            if (!_updateCountInputAcs.CheckOnline())
            {
                TMsgDisp.Show(
                emErrorLevel.ERR_LEVEL_STOP,
                this.Text,
                this.Text + "画面初期化処理に失敗しました。",
                (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }
			ArrayList secMngSetWorkList = new ArrayList();
			_startTime = _updateCountInputAcs.LoadProc(_enterpriseCode, out _baseCode, out secMngSetWorkList);
			_compareSecmngList = secMngSetWorkList; // ADD 2011.08.25
        }

        /// <summary>
        /// 更新時間の設定
        /// </summary>
		/// <param name="baseCd"></param>
		/// <param name="sendCd"></param>
        /// <remarks>		
        /// <br>Note		: 更新時間処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
		//private bool UpdateOverData()
		private bool UpdateOverData(string baseCd, string sendCd)
        {
            bool isUpdate = true;
            DateTime startTimeBak = new DateTime(); 
			//isUpdate = _updateCountInputAcs.UpdateOverProc(_enterpriseCode, _baseCode, out startTimeBak);
			isUpdate = _updateCountInputAcs.UpdateOverProc(_enterpriseCode, baseCd, sendCd, out startTimeBak);
            if (isUpdate) 
            {
                _startTime = startTimeBak;
            } 
            else
            {
                isUpdate = false;
            }
            return isUpdate;
        }
        /// <summary>
        /// グリッド列スタイル設定
        /// </summary>
        /// <remarks>		
        /// <br>Note		: グリッド列スタイル設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void InitialAccDataGridCol()
        {
            // 送信対象データをグリッドへ設定する
            for (int i = 0; i < this._sendDataList.Count; i++)
			{
				# region [DEL 2011/07/28]
				//-----DEL 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
				//SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[i];
				//UpdateResultDataSet.UpdateResultRow row = _updateResultDataTable.NewUpdateResultRow();
				//row.RowNo = i + 1;
				//row.ExtractionData = secMngSndRcv.MasterName;
				//row.ExtractionCount = string.Empty;
				//_updateResultDataTable.Rows.Add(row);
				//-----DEL 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
				# endregion

				//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
				//送信先拠点リストを作成する
				if (ALL_SECTIONCODE.Equals(this.tEdit_SectionCodeAllowZero.DataText))
				{
					this.sendDestSecList = _searchSecMngList;
				}
				else if (string.Empty.Equals(this.tEdit_SectionCodeAllowZero.DataText))
				{
					this.sendDestSecList = new ArrayList();
				}
				else
				{
					this.sendDestSecList = new ArrayList();
					foreach (SecMngSet secMngSet0 in _searchSecMngList)
					{
						if (secMngSet0.SendDestSecCode.Trim().Equals(this.tEdit_SectionCodeAllowZero.DataText)
							&& secMngSet0.LogicalDeleteCode == 0
							&& secMngSet0.Kind == 0)
						{
							this.sendDestSecList.Add(secMngSet0);
						}
					}
				}
				//拠点管理設定マスタに登録した送信先拠点を送信情報グリッドに追加
				int colCnt = _updateResultDataTable.Columns.Count;
				for (int j = colCnt - 1; j > this.Acc_Grid.DisplayLayout.Bands[0].Columns[_updateResultDataTable.ExtractionCountColumn.ColumnName].Index; j--)
				{
					_updateResultDataTable.Columns.RemoveAt(j);
				}

				foreach (SecMngSet secMngSet2 in sendDestSecList)
				{
					if (!_updateResultDataTable.Columns.Contains(secMngSet2.SectionCode.Trim() + secMngSet2.SendDestSecCode.Trim() ))
					{
						_updateResultDataTable.Columns.Add(secMngSet2.SectionCode.Trim() + secMngSet2.SendDestSecCode.Trim());
						this.Acc_Grid.DisplayLayout.Bands[0].Columns[secMngSet2.SectionCode.Trim() + secMngSet2.SendDestSecCode.Trim()].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
						//_updateResultDataTable.Columns[ secMngSet2.SectionCode.Trim() + secMngSet2.SendDestSecCode.Trim()].Caption = GetSectionName(secMngSet2.SendDestSecCode.Trim());
						_updateResultDataTable.Columns[secMngSet2.SectionCode.Trim() + secMngSet2.SendDestSecCode.Trim()].Caption = GetSectionName(secMngSet2.SendDestSecCode.Trim()) + "(" + GetSectionName(secMngSet2.SectionCode.Trim())+")";
					}
				}

				SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[i];
				UpdateResultDataSet.UpdateResultRow row = _updateResultDataTable.NewUpdateResultRow();
				row.RowNo = i + 1;
				row.ExtractionData = secMngSndRcv.MasterName;
				row.ExtractionCount = string.Empty;

				foreach (SecMngSet secMngSet3 in sendDestSecList)
				{
					row[secMngSet3.SectionCode.Trim() + secMngSet3.SendDestSecCode.Trim()] = string.Empty;
				}

				_updateResultDataTable.Rows.Add(row);
				//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
            }
        }

        /// <summary>
        /// 送信情報グリッド初期設定
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>   
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: 送信情報グリッド初期設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void Acc_Grid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // 送信情報の取得
            this._updateCountInputAcs.GetSecMngSendData(this._enterpriseCode, out this._sendDataList);

			string secCd = this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2,'0');
			ArrayList sendDtList = new ArrayList();
			if (!secCd.Equals("00") && _searchSecMngList.Count > 0)
			{
				foreach (SecMngSet tmpSecMngSet in _searchSecMngList)
				{
					if (tmpSecMngSet.SendDestSecCode.Equals(secCd))
					{
						sendDtList.Add(tmpSecMngSet);
					}

				}
			}
			else
			{
				sendDtList = _searchSecMngList;
			}

			this.InitialAccSettingGridCol(sendDtList);
            this.InitialAccDataGridCol();
        }

        /// <summary>
        /// 条件グリッド初期設定
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>   
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: 条件グリッド初期設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void Condition_Grid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.InitialConSettingGridCol();
            // ゼロ選択方法設定
            e.Layout.Override.SelectTypeCell = SelectType.SingleAutoDrag;
            e.Layout.Override.SelectTypeRow = SelectType.ExtendedAutoDrag;
            e.Layout.Override.SelectTypeCol = SelectType.SingleAutoDrag;
            this.InitialConDataGridCol();
        }

        # endregion ■ グリッド初期設定関連 ■

        #region  ■ データ抽出送信処理 ■
        // ----- ADD 2013/02/07 zhlj For Redmine#34588 ---------->>>>>
        /// <summary>
        /// データ抽出送信処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: データ抽出送信処理を行う。</br>
        /// <br>            : 10900690-00 2013/3/13配信分の緊急対応</br>
        /// <br>            : Redmine#34588 拠点管理改良／送信確認画面の追加仕様の変更対応</br>
        /// <br>Programmer	: zhlj</br>	
        /// <br>Date		: 2013/02/07</br>
        /// <br>Update Note : 2020/09/25 譚洪</br>
        /// <br>管理番号    : 11600006-00</br>
        /// <br>            : PMKOBETSU-3877の対応</br>
        /// </remarks>
        private void GetProcess()
        {
            // 抽出中画面部品のインスタンスを作成
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();

            // 表示文字を設定
            form.Title = "抽出処理中";
            form.Message = "抽出処理中です";

			int errStatus = 0;
			this.Cursor = Cursors.WaitCursor;
			// ダイアログ表示
            ToolbarOff();
			form.Show();
			Dictionary<string, SearchCountWork> searchCntDic = new Dictionary<string, SearchCountWork>();
			String beginningDate;
			String beginningTime;
			String endingDate;
			String endingTime;
			String baseCode;
			String sendCode;
			DateTime beginDateTime;
			DateTime endDateTime;

			bool isEmpty = true;
			ArrayList errSectionCodeList = new ArrayList();
			ArrayList sendDestEpCodeList = new ArrayList();
			EnterpriseSetAcs _enterpriseSetAcs = new EnterpriseSetAcs();

            // 送信拠点一覧を取得する
			_enterpriseSetAcs.SearchAll(out sendDestEpCodeList, this._enterpriseCode);

            for (int i = 0; i < this.Condition_Grid.Rows.Count; i++)
            {
                //チェックオンされた送信条件レコードはチェックを行う。
                if (((bool)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Value) == true)
                {
                    beginningDate = this.Condition_Grid.Rows[i].Cells["BeginningDate"].Value.ToString();
                    beginningTime = this.Condition_Grid.Rows[i].Cells["BeginningTime"].Value.ToString();
                    DateTime tmpStDate = (DateTime)this.Condition_Grid.Rows[i].Cells["BeginningDate"].Value;

                    endingDate = this.Condition_Grid.Rows[i].Cells["EndDate"].Value.ToString();
                    endingTime = this.Condition_Grid.Rows[i].Cells["EndTime"].Value.ToString();
                    DateTime tmpEdDate = (DateTime)this.Condition_Grid.Rows[i].Cells["EndDate"].Value;

                    baseCode = this.Condition_Grid.Rows[i].Cells["BaseCode"].Value.ToString();
                    sendCode = this.Condition_Grid.Rows[i].Cells["SendCode"].Value.ToString();

                    _startTime = DateTime.MinValue;
                    for (int n = 0; n < _compareSecmngList.Count; n++)
                    {
                        APSecMngSetWork secMngSetWork = (APSecMngSetWork)_compareSecmngList[n];
                        if (baseCode.Trim().Equals(secMngSetWork.SectionCode.Trim())
                        && sendCode.Trim().Equals(secMngSetWork.SendDestSecCode.Trim()))
                        {
                            _startTime = secMngSetWork.SyncExecDate;
                        }
                    }

                    // 開始日付
                    beginDateTime = new DateTime(tmpStDate.Year, tmpStDate.Month, tmpStDate.Day, int.Parse(beginningTime.Substring(0, 2)), int.Parse(beginningTime.Substring(3, 2)),
                        int.Parse(beginningTime.Substring(6, 2)));

                    // 終了日付
                    endDateTime = new DateTime(tmpEdDate.Year, tmpEdDate.Month, tmpEdDate.Day, int.Parse(endingTime.Substring(0, 2)), int.Parse(endingTime.Substring(3, 2)),
                        int.Parse(endingTime.Substring(6, 2)));

                    if (beginDateTime.Year == _startTime.Year && beginDateTime.Month == _startTime.Month && beginDateTime.Day == _startTime.Day
                        && beginDateTime.Hour == _startTime.Hour && beginDateTime.Minute == _startTime.Minute && beginDateTime.Second == _startTime.Second)
                    {
                        beginDateTime = _startTime;
                    }

                    long beginDtLong = 0;
                    long endDtLong = 0;
                    if (this.tce_ExtractCondDiv.SelectedIndex == 0)
                    {
                        beginDtLong = beginDateTime.Ticks;
                        endDtLong = endDateTime.Ticks;
                    }
                    else if (this.tce_ExtractCondDiv.SelectedIndex == 1)
                    {
                        beginDtLong = Convert.ToInt32(this.tDateEditSt.GetDateTime().ToString("yyyyMMdd"));
                        endDtLong = Convert.ToInt32(this.tDateEditEd.GetDateTime().ToString("yyyyMMdd"));
                    }
                    bool b_Empty = true;
                    baseCode = baseCode.Trim();
                    sendCode = sendCode.Trim();
                    // ファイルID配列
                    string[] fileIds = new string[this._sendDataList.Count];
                    string[] fileNms = new string[this._sendDataList.Count];
                    // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
                    int acptAnOdrSendDiv = 0;
                    int shipmentSendDiv = 0;
                    int estimateSendDiv = 0;
                    // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------<<<<<
                    for (int j = 0; j < this._sendDataList.Count; j++)
                    {
                        SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[j];
                        fileIds[j] = secMngSndRcv.FileId;
                        fileNms[j] = secMngSndRcv.FileNm;
                        // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
                        if (secMngSndRcv.FileNm.Equals("売上データ"))
                        {
                            //受注データ送信区分
                            acptAnOdrSendDiv = secMngSndRcv.AcptAnOdrSendDiv;
                            //貸出データ送信区分
                            shipmentSendDiv = secMngSndRcv.ShipmentSendDiv;
                            //見積データ送信区分
                            estimateSendDiv = secMngSndRcv.EstimateSendDiv;
                        }
                        // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------<<<<<
                    }

                    // 送信データの結果件数ワーク
                    SearchCountWork searchCountWork = new SearchCountWork();
                    if (((bool)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Value) == false)
                    {
                        //チェックされない送信先拠点へ送信しない
                        continue;
                    }

                    // 抽出対象データ結果件数を取得する
                    searchCountWork = _updateCountInputAcs.SearchDataProc(
                        this.tce_ExtractCondDiv.SelectedIndex, beginDtLong, endDtLong,
                        _startTime, _enterpriseCode, _loginSectionCode, _loginEmplooyCode,
                        // --- UPD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
                        //baseCode, sendCode, out b_Empty, this._connectPointDiv, fileIds, fileNms, sendDestEpCodeList);
                        baseCode, sendCode, out b_Empty, this._connectPointDiv, fileIds, fileNms, sendDestEpCodeList, acptAnOdrSendDiv, shipmentSendDiv, estimateSendDiv);
                    // --- UPD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------<<<<<
                     
                    this.Cursor = Cursors.Default;

                    // 検索正常の場合
                    if (searchCountWork.Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        searchCntDic.Add(baseCode + sendCode.Trim(), searchCountWork);
                    }
                }
            }

            // ダイアログを閉じる
            form.Close();
            ToolbarOn();
            // 送信情報テーブルクリア処理
            this._updateResultDataTable.Clear();
            this._isEmpty = true;
            // 送信情報テーブル設定処理(0:送信前)
            this.SearchResultDataGridCol(searchCntDic, errSectionCodeList, 0);
            this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];

            if (this._isEmpty)
            {
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "抽出対象のデータが存在しません。", 0);
                // 送信情報テーブルクリア処理
                this._updateResultDataTable.Clear();
                // 送信情報テーブル設定処理
                this.SearchResultDataGridCol(searchCntDic, errSectionCodeList);
                return;
            }

            // 送信処理確認画面
            DialogResult dialogResult = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_QUESTION,
                this.Name,
                "送信処理を開始しますか？",
                0,
                MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button1);

            // 「はい」の場合
            if (dialogResult == DialogResult.Yes)
            {
                searchCntDic.Clear();
                // 表示文字を設定
                form.Title = "送信処理中";
                form.Message = "送信処理中です";
                this.Cursor = Cursors.WaitCursor;
                // ダイアログ表示
                this.Update();
                ToolbarOff();
                form.Show();

			    for (int i = 0; i < this.Condition_Grid.Rows.Count; i++)
			    {
				    //チェックオンされた送信条件レコードはチェックを行う。
				    if (((bool)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Value) == true)
				    {

					    beginningDate = this.Condition_Grid.Rows[i].Cells["BeginningDate"].Value.ToString();
					    beginningTime = this.Condition_Grid.Rows[i].Cells["BeginningTime"].Value.ToString();
					    DateTime tmpStDate = (DateTime)this.Condition_Grid.Rows[i].Cells["BeginningDate"].Value;

					    endingDate = this.Condition_Grid.Rows[i].Cells["EndDate"].Value.ToString();
					    endingTime = this.Condition_Grid.Rows[i].Cells["EndTime"].Value.ToString();
					    DateTime tmpEdDate = (DateTime)this.Condition_Grid.Rows[i].Cells["EndDate"].Value;


					    baseCode = this.Condition_Grid.Rows[i].Cells["BaseCode"].Value.ToString();
					    sendCode = this.Condition_Grid.Rows[i].Cells["SendCode"].Value.ToString();

					    _startTime = DateTime.MinValue;
					    for (int n = 0; n < _compareSecmngList.Count; n++)
					    {
						    APSecMngSetWork secMngSetWork = (APSecMngSetWork)_compareSecmngList[n];
						    if (baseCode.Trim().Equals(secMngSetWork.SectionCode.Trim())
						    && sendCode.Trim().Equals(secMngSetWork.SendDestSecCode.Trim()))
						    {
							    _startTime = secMngSetWork.SyncExecDate;
						    }
					    }

					    // 開始日付
					    beginDateTime = new DateTime(tmpStDate.Year, tmpStDate.Month,tmpStDate.Day, int.Parse(beginningTime.Substring(0, 2)), int.Parse(beginningTime.Substring(3, 2)),
						    int.Parse(beginningTime.Substring(6, 2)));

					    // 終了日付
					    endDateTime = new DateTime(tmpEdDate.Year, tmpEdDate.Month, tmpEdDate.Day, int.Parse(endingTime.Substring(0, 2)), int.Parse(endingTime.Substring(3, 2)),
						    int.Parse(endingTime.Substring(6, 2)));

					    if (beginDateTime.Year == _startTime.Year && beginDateTime.Month == _startTime.Month && beginDateTime.Day == _startTime.Day
						    && beginDateTime.Hour == _startTime.Hour && beginDateTime.Minute == _startTime.Minute && beginDateTime.Second == _startTime.Second)
					    {
						    beginDateTime = _startTime;
					    }

                        long beginDtLong = 0;
                        long endDtLong = 0;
                        if (this.tce_ExtractCondDiv.SelectedIndex == 0)
                        {
                            beginDtLong = beginDateTime.Ticks;
                            endDtLong = endDateTime.Ticks;
                        }
                        else if(this.tce_ExtractCondDiv.SelectedIndex == 1)
                        {
                            beginDtLong = Convert.ToInt32(this.tDateEditSt.GetDateTime().ToString("yyyyMMdd"));
                            endDtLong = Convert.ToInt32(this.tDateEditEd.GetDateTime().ToString("yyyyMMdd"));
                        }

					    bool b_Empty = true;
					    baseCode = baseCode.Trim();
					    sendCode = sendCode.Trim();
					    // ファイルID配列
					    string[] fileIds = new string[this._sendDataList.Count];
					    string[] fileNms = new string[this._sendDataList.Count];
                        // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
                        int acptAnOdrSendDiv = 0;
                        int shipmentSendDiv = 0;
                        int estimateSendDiv = 0;
                        // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------<<<<<
					    for (int j = 0; j < this._sendDataList.Count; j++)
					    {
						    SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[j];
						    fileIds[j] = secMngSndRcv.FileId;
						    fileNms[j] = secMngSndRcv.FileNm;
                            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
                            if (secMngSndRcv.FileNm.Equals("売上データ"))
                            {
                                //受注データ送信区分
                                acptAnOdrSendDiv = secMngSndRcv.AcptAnOdrSendDiv;
                                //貸出データ送信区分
                                shipmentSendDiv = secMngSndRcv.ShipmentSendDiv;
                                //見積データ送信区分
                                estimateSendDiv = secMngSndRcv.EstimateSendDiv;
                            }
                            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------<<<<<
					    }
					    
					    SearchCountWork searchCountWork = new SearchCountWork();
					    if (((bool)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Value) == false)
					    {
						    //チェックされない送信先拠点へ送信しない
						    continue;
					    }
                        // データ送信処理
                        // --- UPD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
                        //searchCountWork = _updateCountInputAcs.UpdateProc(this.tce_ExtractCondDiv.SelectedIndex, beginDtLong, endDtLong, _startTime, _enterpriseCode, _loginSectionCode, _loginEmplooyCode, baseCode, sendCode, out b_Empty, this._connectPointDiv, fileIds, fileNms, sendDestEpCodeList); 
                        searchCountWork = _updateCountInputAcs.UpdateProc(this.tce_ExtractCondDiv.SelectedIndex, beginDtLong, endDtLong, _startTime, _enterpriseCode, _loginSectionCode, _loginEmplooyCode, baseCode, sendCode, out b_Empty, this._connectPointDiv, fileIds, fileNms, sendDestEpCodeList, acptAnOdrSendDiv, shipmentSendDiv, estimateSendDiv);
                        // --- UPD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------<<<<<
					    // 検索0件以外の場合
					    if (!b_Empty)
					    {
						    isEmpty = false;
					    }

					    if ((int)ConstantManagement.DB_Status.ctDB_NORMAL != searchCountWork.Status)
					    {
						    errStatus = searchCountWork.Status;
						    errSectionCodeList.Add(baseCode + sendCode.Trim());
					    }
					    else
					    {

						    if (!b_Empty)
						    {
							    searchCntDic.Add(baseCode + sendCode.Trim(), searchCountWork);
						    }
						    else
						    {
							    searchCntDic.Add(baseCode + sendCode.Trim(), searchCountWork);
						    }
					    }
				    }
			    }
            }
            // 「いいえ」の場合
            else
            {
                // 送信情報テーブルクリア処理
                this._updateResultDataTable.Clear();
                // 送信情報テーブル設定処理(2:未送信)
                this.SearchResultDataGridCol(searchCntDic, errSectionCodeList, 2);
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];

                return;
            }
			
			this.Cursor = Cursors.Default;
            // ダイアログを閉じる
            form.Close();
            ToolbarOn();

			// 更新後画面再設定
            // 送信データ0件の場合
			if (isEmpty)
			{
				// 送信情報テーブルクリア処理
				this._updateResultDataTable.Clear();
                // 送信情報テーブル設定処理
				this.SearchResultDataGridCol(searchCntDic, errSectionCodeList);
				this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];

				// 送信条件テーブルクリア
				this._extractionConditionDataTable.Clear();
                // 更新した後で送信条件タブを再設定する
				this.SearchCondtionGridCol();

				// メッセージを表示
				this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "抽出対象のデータが存在しません。", 0);
			}
			else
			{

				// 送信情報テーブルクリア処理
				this._updateResultDataTable.Clear();
                // 送信情報テーブル設定処理(1:送信完了)
                this.SearchResultDataGridCol(searchCntDic, errSectionCodeList, 1);
				this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];

				// 送信条件テーブルクリア
				this._extractionConditionDataTable.Clear();
                // 更新した後で送信条件タブを再設定する
				this.SearchCondtionGridCol();

				if (0 == errStatus)
				{
					// 更新正常の場合
                    // 送信完了メッセージ
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                         ct_ClassID,
                                         "送信処理が完了しました。",
                                         0,
                                         MessageBoxButtons.OK);
				}
				else if (-1 == errStatus)
				{
					// 検索エラーの場合、 
					this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "検索処理に失敗しました。", errStatus);
				}
				else if (-2 == errStatus)
				{
					// APロックのタイムアウトの場合
					this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "処理が込み合っているためタイムアウトしました。\n再試行するか、しばらく待ってから再度処理を行ってください。", 0);
				}
				else if (-3 == errStatus)
				{
					// DBのSQLエラーの場合、
					this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "SQLエラーが発生しました。", errStatus);
				}
				else if (5 == errStatus)
				{
					// 一意制約エラーの場合、
					this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "更新処理に失敗しました。", errStatus);
				}
				else
				{
					// システムとその他エラーの場合、
					this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "排他処理に失敗しました。", (int)ConstantManagement.DB_Status.ctDB_ERROR);
				}
			}

            if (this.tce_ExtractCondDiv.SelectedIndex == 1)
            {
                this.ChangeConditionGrid();
            }
		}
        // ----- ADD 2013/02/07 zhlj For Redmine#34588 ----------<<<<<

        /// <summary>
        /// データ送信処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: データ送信処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// <br>Update Note : 2020/09/25 譚洪</br>
        /// <br>管理番号    : 11600006-00</br>
        /// <br>            : PMKOBETSU-3877の対応</br>
        /// </remarks>
        private void UpdateProcess()
        {
            // ADD 2009/05/20 --->>>
            // 抽出中画面部品のインスタンスを作成
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // 表示文字を設定
            form.Title = "送信処理中";
            form.Message = "送信処理中です";
            // ADD 2009/05/20 ---<<<

            # region [DEL 2011/07/28]
            //-----DEL 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
            //String beginningDate = this.Condition_Grid.Rows[0].Cells["BeginningDate"].Value.ToString();
            //String beginningTime = this.Condition_Grid.Rows[0].Cells["BeginningTime"].Value.ToString();

            //String endingDate = this.Condition_Grid.Rows[0].Cells["EndDate"].Value.ToString();
            //String endingTime = this.Condition_Grid.Rows[0].Cells["EndTime"].Value.ToString();

            //String baseCode = this.Condition_Grid.Rows[0].Cells["BaseCode"].Value.ToString();
            //// 開始日付
            //DateTime beginDateTime = new DateTime(int.Parse(beginningDate.Substring(0, 4)), int.Parse(beginningDate.Substring(5, 2)),
            //    int.Parse(beginningDate.Substring(8, 2)), int.Parse(beginningTime.Substring(0, 2)), int.Parse(beginningTime.Substring(3, 2)),
            //    int.Parse(beginningTime.Substring(6, 2)));
            //// 終了日付
            //DateTime endDateTime = new DateTime(int.Parse(endingDate.Substring(0, 4)), int.Parse(endingDate.Substring(5, 2)),
            //    int.Parse(endingDate.Substring(8, 2)), int.Parse(endingTime.Substring(0, 2)), int.Parse(endingTime.Substring(3, 2)),
            //    int.Parse(endingTime.Substring(6, 2)));

            //if (beginDateTime.Year == _startTime.Year && beginDateTime.Month == _startTime.Month && beginDateTime.Day == _startTime.Day
            //    && beginDateTime.Hour == _startTime.Hour && beginDateTime.Minute == _startTime.Minute && beginDateTime.Second == _startTime.Second) 
            //{
            //    beginDateTime = _startTime;
            //}

            //long beginDtLong = beginDateTime.Ticks;
            //long endDtLong = endDateTime.Ticks;
            //bool isEmpty = false;
            //baseCode = baseCode.Trim();

            //this.Cursor = Cursors.WaitCursor;

            //// ダイアログ表示
            //form.Show();    // ADD 2009/05/20

            //// ファイルID配列
            //string[] fileIds = new string[this._sendDataList.Count];
            //// ADD 2009/06/23 ---->>>
            //string[] fileNms = new string[this._sendDataList.Count];
            //// ADD 2009/06/23 ----<<<
            //for (int i = 0; i < this._sendDataList.Count; i++)
            //{
            //    SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[i];
            //    fileIds[i] = secMngSndRcv.FileId;
            //    // ADD 2009/06/23 ---->>>
            //    fileNms[i] = secMngSndRcv.FileNm;
            //    // ADD 2009/06/23 ----<<<
            //}
            //// データ送信処理
            //// MOD 2009/06/23 ---->>>
            ////SearchCountWork searchCountWork = _updateCountInputAcs.UpdateProc(beginDtLong, endDtLong, _startTime, _enterpriseCode, _loginEmplooyCode, baseCode, out isEmpty, this._connectPointDiv, fileIds);
            //SearchCountWork searchCountWork = _updateCountInputAcs.UpdateProc(beginDtLong, endDtLong, _startTime, _enterpriseCode, _loginEmplooyCode, baseCode, out isEmpty, this._connectPointDiv, fileIds, fileNms);
            //// MOD 2009/06/23 ----<<<
            //-----DEL 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
            # endregion

            //-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
            int errStatus = 0;
            this.Cursor = Cursors.WaitCursor;
            // ダイアログ表示
            ToolbarOff();//ADD 2013/02/07 zhlj For Redmine#34588
            form.Show();
            Dictionary<string, SearchCountWork> searchCntDic = new Dictionary<string, SearchCountWork>();
            String beginningDate;
            String beginningTime;
            String endingDate;
            String endingTime;
            String baseCode;
            String sendCode;
            DateTime beginDateTime;
            DateTime endDateTime;
            //bool isEmpty = false;
            bool isEmpty = true;
            ArrayList errSectionCodeList = new ArrayList();

            ArrayList sendDestEpCodeList = new ArrayList();
            EnterpriseSetAcs _enterpriseSetAcs = new EnterpriseSetAcs();
            _enterpriseSetAcs.SearchAll(out sendDestEpCodeList, this._enterpriseCode);

            for (int i = 0; i < this.Condition_Grid.Rows.Count; i++)
            {
                //チェックオンされた送信条件レコードはチェックを行う。
                if (((bool)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Value) == true)
                {

                    beginningDate = this.Condition_Grid.Rows[i].Cells["BeginningDate"].Value.ToString();
                    beginningTime = this.Condition_Grid.Rows[i].Cells["BeginningTime"].Value.ToString();
                    DateTime tmpStDate = (DateTime)this.Condition_Grid.Rows[i].Cells["BeginningDate"].Value;// ADD 2011.08.19

                    endingDate = this.Condition_Grid.Rows[i].Cells["EndDate"].Value.ToString();
                    endingTime = this.Condition_Grid.Rows[i].Cells["EndTime"].Value.ToString();
                    DateTime tmpEdDate = (DateTime)this.Condition_Grid.Rows[i].Cells["EndDate"].Value;// ADD 2011.08.19


                    baseCode = this.Condition_Grid.Rows[i].Cells["BaseCode"].Value.ToString();
                    sendCode = this.Condition_Grid.Rows[i].Cells["SendCode"].Value.ToString();

                    // ADD 2011.08.25---------->>>>>
                    _startTime = DateTime.MinValue;
                    for (int n = 0; n < _compareSecmngList.Count; n++)
                    {
                        APSecMngSetWork secMngSetWork = (APSecMngSetWork)_compareSecmngList[n];
                        if (baseCode.Trim().Equals(secMngSetWork.SectionCode.Trim())
                        && sendCode.Trim().Equals(secMngSetWork.SendDestSecCode.Trim()))
                        {
                            _startTime = secMngSetWork.SyncExecDate;
                        }
                    }
                    // ADD 2011.08.25----------<<<<<

                    // 開始日付
                    // DEL 2011.08.19
                    //beginDateTime = new DateTime(int.Parse(beginningDate.Substring(0, 4)), int.Parse(beginningDate.Substring(5, 2)),
                    //    int.Parse(beginningDate.Substring(8, 2)), int.Parse(beginningTime.Substring(0, 2)), int.Parse(beginningTime.Substring(3, 2)),
                    //    int.Parse(beginningTime.Substring(6, 2)));
                    // ADD 2011.08.19
                    beginDateTime = new DateTime(tmpStDate.Year, tmpStDate.Month, tmpStDate.Day, int.Parse(beginningTime.Substring(0, 2)), int.Parse(beginningTime.Substring(3, 2)),
                        int.Parse(beginningTime.Substring(6, 2)));

                    // 終了日付
                    // DEL 2011.08.19
                    //endDateTime = new DateTime(int.Parse(endingDate.Substring(0, 4)), int.Parse(endingDate.Substring(5, 2)),
                    //    int.Parse(endingDate.Substring(8, 2)), int.Parse(endingTime.Substring(0, 2)), int.Parse(endingTime.Substring(3, 2)),
                    //    int.Parse(endingTime.Substring(6, 2)));
                    // ADD 2011.08.19
                    endDateTime = new DateTime(tmpEdDate.Year, tmpEdDate.Month, tmpEdDate.Day, int.Parse(endingTime.Substring(0, 2)), int.Parse(endingTime.Substring(3, 2)),
                        int.Parse(endingTime.Substring(6, 2)));

                    if (beginDateTime.Year == _startTime.Year && beginDateTime.Month == _startTime.Month && beginDateTime.Day == _startTime.Day
                        && beginDateTime.Hour == _startTime.Hour && beginDateTime.Minute == _startTime.Minute && beginDateTime.Second == _startTime.Second)
                    {
                        beginDateTime = _startTime;
                    }

                    // ----- DEL xupz 2011/11/01 ---------->>>>>
                    //long beginDtLong = beginDateTime.Ticks;
                    //long endDtLong = endDateTime.Ticks;
                    // ----- DEL xupz 2011/11/01 ----------<<<<<
                    // ----- ADD xupz 2011/11/01 ---------->>>>>
                    long beginDtLong = 0;
                    long endDtLong = 0;
                    if (this.tce_ExtractCondDiv.SelectedIndex == 0)
                    {
                        beginDtLong = beginDateTime.Ticks;
                        endDtLong = endDateTime.Ticks;
                    }
                    else if (this.tce_ExtractCondDiv.SelectedIndex == 1)
                    {
                        // ----- DEL 2011/11/11 xupz---------->>>>>
                        //beginDtLong = Convert.ToInt32(beginDateTime.ToString("yyyyMMdd"));
                        //endDtLong = Convert.ToInt32(endDateTime.ToString("yyyyMMdd"));
                        // ----- DEL 2011/11/11 xupz----------<<<<<
                        // ----- ADD 2011/11/11 xupz---------->>>>>
                        beginDtLong = Convert.ToInt32(this.tDateEditSt.GetDateTime().ToString("yyyyMMdd"));
                        endDtLong = Convert.ToInt32(this.tDateEditEd.GetDateTime().ToString("yyyyMMdd"));
                        // ----- ADD 2011/11/11 xupz----------<<<<<
                    }
                    // ----- ADD xupz 2011/11/01 ----------<<<<<
                    bool b_Empty = true;
                    baseCode = baseCode.Trim();
                    sendCode = sendCode.Trim();
                    // ファイルID配列
                    string[] fileIds = new string[this._sendDataList.Count];
                    string[] fileNms = new string[this._sendDataList.Count];
                    // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
                    int acptAnOdrSendDiv = 0;
                    int shipmentSendDiv = 0;
                    int estimateSendDiv = 0;
                    // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------<<<<<
                    for (int j = 0; j < this._sendDataList.Count; j++)
                    {
                        SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[j];
                        fileIds[j] = secMngSndRcv.FileId;
                        fileNms[j] = secMngSndRcv.FileNm;
                        // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
                        if (secMngSndRcv.FileNm.Equals("売上データ"))
                        {
                            //受注データ送信区分
                            acptAnOdrSendDiv = secMngSndRcv.AcptAnOdrSendDiv;
                            //貸出データ送信区分
                            shipmentSendDiv = secMngSndRcv.ShipmentSendDiv;
                            //見積データ送信区分
                            estimateSendDiv = secMngSndRcv.EstimateSendDiv;
                        }
                        // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------<<<<<
                    }
                    // データ送信処理
                    SearchCountWork searchCountWork = new SearchCountWork();
                    if (((bool)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Value) == false)
                    {
                        //チェックされない送信先拠点へ送信しない
                        //searchCntDic.Add(baseCode + sendCode.Trim(), searchCountWork);
                        continue;
                    }
                    //searchCountWork = _updateCountInputAcs.UpdateProc(beginDtLong, endDtLong, _startTime, _enterpriseCode, _loginSectionCode, _loginEmplooyCode, baseCode, sendCode, out b_Empty, this._connectPointDiv, fileIds, fileNms, sendDestEpCodeList);   //  DEL dingjx  2011/11/01
                    // --- UPD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
                    //searchCountWork = _updateCountInputAcs.UpdateProc(this.tce_ExtractCondDiv.SelectedIndex, beginDtLong, endDtLong, _startTime, _enterpriseCode, _loginSectionCode, _loginEmplooyCode, baseCode, sendCode, out b_Empty, this._connectPointDiv, fileIds, fileNms, sendDestEpCodeList); //  ADD dingjx  2011/11/01
                    searchCountWork = _updateCountInputAcs.UpdateProc(this.tce_ExtractCondDiv.SelectedIndex, beginDtLong, endDtLong, _startTime, _enterpriseCode, _loginSectionCode, _loginEmplooyCode, baseCode, sendCode, out b_Empty, this._connectPointDiv, fileIds, fileNms, sendDestEpCodeList, acptAnOdrSendDiv, shipmentSendDiv, estimateSendDiv);
                    // --- UPD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------<<<<<
                    // 検索0件以外の場合、
                    if (!b_Empty)
                    {
                        isEmpty = false;
                    }

                    // ADD 2011.09.05 ------>>>>>
                    if ((int)ConstantManagement.DB_Status.ctDB_NORMAL != searchCountWork.Status)
                    {
                        errStatus = searchCountWork.Status;
                        errSectionCodeList.Add(baseCode + sendCode.Trim());
                    }
                    else
                    {
                        // ADD 2011.09.05 ------<<<<<

                        if (!b_Empty)
                        {
                            searchCntDic.Add(baseCode + sendCode.Trim(), searchCountWork);
                        }
                        else
                        {
                            searchCntDic.Add(baseCode + sendCode.Trim(), searchCountWork);
                        }
                    }
                }
            }

            this.Cursor = Cursors.Default;
            // ダイアログを閉じる
            form.Close();
            ToolbarOn();//ADD 2013/02/07 zhlj For Redmine#34588
            //更新後画面再設定
            if (isEmpty)
            {
                // 送信情報テーブルクリア処理
                this._updateResultDataTable.Clear();
                this.SearchResultDataGridCol(searchCntDic, errSectionCodeList);
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];

                //送信条件テーブルクリア
                this._extractionConditionDataTable.Clear();
                this.SearchCondtionGridCol();

                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "抽出対象のデータが存在しません。", 0);
            }
            else
            {
                // 送信情報テーブルクリア処理
                this._updateResultDataTable.Clear();
                //this.SearchResultDataGridCol(searchCntDic, errSectionCodeList);//DEL 2013/02/07 zhlj For Redmine#34588
                // ----- ADD 2013/02/07 zhlj For Redmine#34588 ---------->>>>>
                // グリッド列スタイル設定処理(1:送信完了)
                this.SearchResultDataGridCol(searchCntDic, errSectionCodeList, 1);
                // ----- ADD 2013/02/07 zhlj For Redmine#34588 ----------<<<<<
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];

                //送信条件テーブルクリア
                this._extractionConditionDataTable.Clear();
                this.SearchCondtionGridCol();

                // ADD 2011.09.05 エラー処理---------->>>>>
                if (0 == errStatus)
                {
                    // 更新正常の場合
                    // ----- ADD 2013/02/07 zhlj For Redmine#34588 ---------->>>>>
                    // 送信完了メッセージ
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                         ct_ClassID,
                                         "送信処理が完了しました。",
                                         0,
                                         MessageBoxButtons.OK);
                    // ----- ADD 2013/02/07 zhlj For Redmine#34588 ----------<<<<<
                }
                else if (-1 == errStatus)
                {
                    // 検索エラーの場合、 
                    this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "検索処理に失敗しました。", errStatus);
                }
                else if (-2 == errStatus)
                {
                    // APロックのタイムアウトの場合
                    this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "処理が込み合っているためタイムアウトしました。\n再試行するか、しばらく待ってから再度処理を行ってください。", 0);
                }
                else if (-3 == errStatus)
                {
                    // DBのSQLエラーの場合、
                    this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "SQLエラーが発生しました。", errStatus);
                }
                else if (5 == errStatus)
                {
                    // 一意制約エラーの場合、
                    this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "更新処理に失敗しました。", errStatus);
                }
                else
                {
                    // システムとその他エラーの場合、
                    this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "排他処理に失敗しました。", (int)ConstantManagement.DB_Status.ctDB_ERROR);
                }
                // ADD 2011.09.05 エラー処理----------<<<<<
            }

            //-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
            //  ADD dingjx  2011/11/01  --------------------------------->>>>>>
            // Update records of ConditionGrid
            if (this.tce_ExtractCondDiv.SelectedIndex == 1)
            {
                this.ChangeConditionGrid();
            }
            //  ADD dingjx  2011/11/01  ---------------------------------<<<<<<

            # region [DEL 2011/07/28]
            //-----DEL 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
            //this.Cursor = Cursors.Default;
            //// ダイアログを閉じる
            //form.Close();   // ADD 2009/05/20
            //// 検索0件の場合、
            //if (isEmpty)
            //{

            //    // 送信情報テーブルクリア処理
            //    this._updateResultDataTable.Clear();

            //    this.SearchResultDataGridCol(searchCountWork);

            //    this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];

            //    // メッセージを表示
            //    this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "抽出対象のデータが存在しません。", 0);

            //}
            //else
            //{
            //    // 更新正常の場合、 
            //    if (0 == searchCountWork.Status)
            //    {
            //        // 送信情報テーブルクリア処理
            //        this._updateResultDataTable.Clear();

            //        this.SearchResultDataGridCol(searchCountWork);

            //        this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];
            //    }
            //    // 検索エラーの場合、 
            //    else if (-1 == searchCountWork.Status)
            //    {
            //        // 送信情報テーブルクリア処理
            //        this._updateResultDataTable.Clear();

            //        this.SearchResultErrGridCol(searchCountWork);

            //        this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];
            //    }
            //    // APロックのタイムアウトの場合、
            //    else if (-2 == searchCountWork.Status)
            //    {
            //        // 送信情報テーブルクリア処理
            //        this._updateResultDataTable.Clear();

            //        this.SearchResultErrGridCol(searchCountWork);

            //        this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];

            //        // メッセージを表示
            //        this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "処理が込み合っているためタイムアウトしました。\n再試行するか、しばらく待ってから再度処理を行ってください。", 0);
            //    }
            //    // DBのSQLエラーの場合、
            //    else if (-3 == searchCountWork.Status)
            //    {
            //        // 送信情報テーブルクリア処理
            //        this._updateResultDataTable.Clear();

            //        this.SearchResultErrGridCol(searchCountWork);

            //        this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];
            //    }
            //    // システムとその他エラーの場合、
            //    else
            //    {
            //        // 送信情報テーブルクリア処理
            //        this._updateResultDataTable.Clear();

            //        // 送信情報初期化処理
            //        this.InitialAccDataGridCol();

            //        this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];

            //        // メッセージを表示
            //        this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOP, "排他処理に失敗しました。", (int)ConstantManagement.DB_Status.ctDB_ERROR);
            //    }
            //}
            //-----DEL 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
            # endregion
        }

        /// <summary>
        /// 検索件数フォーマット設定
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 検索件数フォーマット設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private String IntConvert(Int32 searchCount)
        {
            String searchCountStr = Convert.ToString(searchCount);
            Int32 searchCountLen = searchCountStr.Length;
            if (searchCountLen <= 3)
            {
                searchCountStr = searchCountStr + " 件";
            }
            else if (3 < searchCountLen && searchCountLen <= 6) 
            {
                searchCountStr = searchCountStr.Substring(0, searchCountLen - 3) + "," + searchCountStr.Substring(searchCountLen - 3) + " 件";
            }
            else if (6 < searchCountLen && searchCountLen <= 9)
            {
                searchCountStr = searchCountStr.Substring(0, searchCountLen - 6) + "," 
                    + searchCountStr.Substring(searchCountLen - 6, 3) + ","
                    + searchCountStr.Substring(searchCountLen - 3) + " 件";
            }
            return searchCountStr;
		}

		# region [DEL 2011/07/28]
		//-----DEL 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
		///// <summary>
		///// グリッド列スタイル設定
		///// </summary>
		///// <remarks>		
		///// <br>Note		: グリッド列スタイル設定処理を行う。</br>
		///// <br>Programmer	: 譚洪</br>	
		///// <br>Date		: 2009.04.02</br>
		///// </remarks>
		//private void SearchResultDataGridCol(SearchCountWork searchCountWork)
		//{
		//    // 送信対象データをグリッドへ設定する
		//    for (int i = 0; i < this._sendDataList.Count; i++)
		//    {
		//        SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[i];
		//        UpdateResultDataSet.UpdateResultRow row = _updateResultDataTable.NewUpdateResultRow();
		//        row.RowNo = i + 1;
		//        row.ExtractionData = secMngSndRcv.MasterName;
		//        switch (secMngSndRcv.FileId)
		//        {
		//            // 売上データ
		//            case "SalesSlipRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.SalesSlipCount);
		//                break;
		//            // 売上明細データ
		//            case "SalesDetailRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.SalesDetailCount);
		//                break;
		//            // 売上履歴データ
		//            case "SalesHistoryRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.SalesHistoryCount);
		//                break;
		//            // 売上履歴明細データ
		//            case "SalesHistDtlRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.SalesHistDtlCount);
		//                break;
		//            // 入金データ
		//            case "DepsitMainRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.DepsitMainCount);
		//                break;
		//            // 入金明細データ
		//            case "DepsitDtlRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.DepsitDtlCount);
		//                break;
		//            // 仕入データ
		//            case "StockSlipRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.StockSlipCount);
		//                break;
		//            // 仕入明細データ
		//            case "StockDetailRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.StockDetailCount);
		//                break;
		//            // 仕入履歴データ
		//            case "StockSlipHistRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.StockSlipHistCount);
		//                break;
		//            // 仕入履歴明細データ
		//            case "StockSlHistDtlRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.StockSlHistDtlCount);
		//                break;
		//            // 支払伝票マスタ
		//            case "PaymentSlpRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.PaymentSlpCount);
		//                break;
		//            // 支払明細データ
		//            case "PaymentDtlRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.PaymentDtlCount);
		//                break;
		//            // 受注マスタ
		//            case "AcceptOdrRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.AcceptOdrCount);
		//                break;
		//            // 受注マスタ（車両）
		//            case "AcceptOdrCarRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.AcceptOdrCarCount);
		//                break;
		//            // 売上月次集計データ
		//            case "MTtlSalesSlipRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.MTtlSalesSlipCount);
		//                break;
		//            // 商品別売上月次集計データ
		//            case "GoodsMTtlSaSlipRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.GoodsMTtlSaSlipCount);
		//                break;
		//            // 仕入月次集計データ
		//            case "MTtlStockSlipRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.MTtlStockSlipCount);
		//                break;
		//            // 在庫調整データ
		//            case "StockAdjustRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.StockAdjustCount);
		//                break;
		//            // 在庫調整明細データ
		//            case "StockAdjustDtlRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.StockAdjustDtlCount);
		//                break;
		//            // 在庫移動データ
		//            case "StockMoveRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.StockMoveCount);
		//                break;
		//            // 在庫受払履歴データ
		//            case "StockAcPayHistRF":
		//                row.ExtractionCount = this.IntConvert(searchCountWork.StockAcPayHistCount);
		//                break;
		//        }
		//        _updateResultDataTable.Rows.Add(row);
		//    }
		//}
		//-----DEL 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
		# endregion

		//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
		/// <summary>
		/// グリッド列スタイル設定
		/// </summary>
		/// <remarks>		
		/// <br>Note		: グリッド列スタイル設定処理を行う。</br>
		/// <br>Programmer	: 張莉莉</br>	
		/// <br>Date		: 2011.07.28</br>
		/// </remarks>
		private void SearchResultDataGridCol(Dictionary<string, SearchCountWork> searchCntDic, ArrayList errSectionCodeList)
		{
			UpdateResultDataSet.UpdateResultRow row = null;
			// 送信対象データをグリッドへ設定する
			for (int i = 0; i < this._sendDataList.Count; i++)
			{
				SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[i];
				row = _updateResultDataTable.NewUpdateResultRow();
				row.RowNo = i + 1;
				row.ExtractionData = secMngSndRcv.MasterName;
				row.ExtractionCount = string.Empty;
				foreach (string sectionCode in searchCntDic.Keys)
				{
					SearchCountWork searchCountWork = searchCntDic[sectionCode];
					switch (secMngSndRcv.FileId)
					{
						// 売上データ
						case "SalesSlipRF":
							row[sectionCode] = this.IntConvert(searchCountWork.SalesSlipCount);
							break;
						// 売上明細データ
						case "SalesDetailRF":
							row[sectionCode] = this.IntConvert(searchCountWork.SalesDetailCount);
							break;
						// 売上履歴データ
						case "SalesHistoryRF":
							row[sectionCode] = this.IntConvert(searchCountWork.SalesHistoryCount);
							break;
						// 売上履歴明細データ
						case "SalesHistDtlRF":
							row[sectionCode] = this.IntConvert(searchCountWork.SalesHistDtlCount);
							break;
						// 入金データ
						case "DepsitMainRF":
							row[sectionCode] = this.IntConvert(searchCountWork.DepsitMainCount);
							break;
						// 入金明細データ
						case "DepsitDtlRF":
							row[sectionCode] = this.IntConvert(searchCountWork.DepsitDtlCount);
							break;
						// 仕入データ
						case "StockSlipRF":
							row[sectionCode] = this.IntConvert(searchCountWork.StockSlipCount);
							break;
						// 仕入明細データ
						case "StockDetailRF":
							row[sectionCode] = this.IntConvert(searchCountWork.StockDetailCount);
							break;
						// 仕入履歴データ
						case "StockSlipHistRF":
							row[sectionCode] = this.IntConvert(searchCountWork.StockSlipHistCount);
							break;
						// 仕入履歴明細データ
						case "StockSlHistDtlRF":
							row[sectionCode] = this.IntConvert(searchCountWork.StockSlHistDtlCount);
							break;
						// 支払伝票マスタ
						case "PaymentSlpRF":
							row[sectionCode] = this.IntConvert(searchCountWork.PaymentSlpCount);
							break;
						// 支払明細データ
						case "PaymentDtlRF":
							row[sectionCode] = this.IntConvert(searchCountWork.PaymentDtlCount);
							break;
						// 受注マスタ
						case "AcceptOdrRF":
							row[sectionCode] = this.IntConvert(searchCountWork.AcceptOdrCount);
							break;
						// 受注マスタ（車両）
						case "AcceptOdrCarRF":
							row[sectionCode] = this.IntConvert(searchCountWork.AcceptOdrCarCount);
							break;
						// DEL 2011.08.19 ------->>>>>
						//// 売上月次集計データ
						//case "MTtlSalesSlipRF":
						//    row[sectionCode] = this.IntConvert(searchCountWork.MTtlSalesSlipCount);
						//    break;
						//// 商品別売上月次集計データ
						//case "GoodsMTtlSaSlipRF":
						//    row[sectionCode] = this.IntConvert(searchCountWork.GoodsMTtlSaSlipCount);
						//    break;
						//// 仕入月次集計データ
						//case "MTtlStockSlipRF":
						//    row[sectionCode] = this.IntConvert(searchCountWork.MTtlStockSlipCount);
						//    break;
						// DEL 2011.08.19 -------<<<<<
						// 在庫調整データ
						case "StockAdjustRF":
							row[sectionCode] = this.IntConvert(searchCountWork.StockAdjustCount);
							break;
						// 在庫調整明細データ
						case "StockAdjustDtlRF":
							row[sectionCode] = this.IntConvert(searchCountWork.StockAdjustDtlCount);
							break;
						// 在庫移動データ
						case "StockMoveRF":
							row[sectionCode] = this.IntConvert(searchCountWork.StockMoveCount);
							break;
						// DEL 2011.08.19 ------->>>>>
						//// 在庫受払履歴データ
						//case "StockAcPayHistRF":
						//    row[sectionCode] = this.IntConvert(searchCountWork.StockAcPayHistCount);
						//    break;
						// DEL 2011.08.19 -------<<<<<
						// 入金引当マスタ
						case "DepositAlwRF":
							row[sectionCode] = this.IntConvert(searchCountWork.DepositAlwCount);
							break;
						// 受取手形データ
						case "RcvDraftDataRF":
							row[sectionCode] = this.IntConvert(searchCountWork.RcvDraftDataCount);
							break;
						// 支払手形データ
						case "PayDraftDataRF":
							row[sectionCode] = this.IntConvert(searchCountWork.PayDraftDataCount);
							break;
					}
				}

				foreach (string errSectionCode in errSectionCodeList)
				{
					row[errSectionCode] = ERROR_BATU;
				}
				_updateResultDataTable.Rows.Add(row);
			}
		}
		//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<

        /// <summary>
        /// グリッド列検索エラー設定
        /// </summary>
        /// <remarks>		
        /// <br>Note		: グリッド列検索エラー設定「×」を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void SearchResultErrGridCol(SearchCountWork searchCountWork)
        {
            // 送信対象データをグリッドへ設定する
            for (int i = 0; i < this._sendDataList.Count; i++)
            {
                SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[i];
                UpdateResultDataSet.UpdateResultRow row = _updateResultDataTable.NewUpdateResultRow();
                row.RowNo = i + 1;
                row.ExtractionData = secMngSndRcv.MasterName;
                row.ExtractionCount = ERROR_BATU;
                _updateResultDataTable.Rows.Add(row);
            }
        }

        # endregion ■ データ送信処理 ■

        #region  ■ Private Method ■

        /// <summary>
        /// ツールバーボタンクリックイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: なし。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // 終了処理
                        this.Close();
                        break;
                    }
                case "ButtonTool_Update":
                    {
                        if (0 == this.Condition_Grid.Rows.Count)
                        {
                            // メッセージを表示
                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "送信対象拠点が設定されていません。", 0);
                            return;
                        }

                        // セル編集後に直接ボタンクリックを行なうとセルの編集が発生しないため
                        if (this.Condition_Grid.ActiveCell != null)
                        {
                            this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        }

                        // 更新処理
                        bool inputCheck = this.UpdateBeforeCheck();
                        if (inputCheck)
                        {
                            this.UpdateProcess();
                        }
                        break;
                    }
                // ----- ADD 2013/02/07 zhlj For Redmine#34588 ---------->>>>>
                case "ButtonTool_Get":
                    {
                        if (0 == this.Condition_Grid.Rows.Count)
                        {
                            // メッセージを表示
                            this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "抽出対象拠点が設定されていません。", 0);
                            return;
                        }

                        // セル編集後に直接ボタンクリックを行なうとセルの編集が発生しないため
                        if (this.Condition_Grid.ActiveCell != null)
                        {
                            this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                        }

                        // 更新処理
                        bool inputCheck = this.UpdateBeforeCheck();
                        if (inputCheck)
                        {
                            this.GetProcess();
                        }
                        break;
                    }
                // ----- ADD 2013/02/07 zhlj For Redmine#34588 ----------<<<<<
                case "ButtonTool_Clear":
                    {
                        // 元に戻す処理
                        this.Retry();

                        break;
                    }
            }
        }

        /// <summary>
        /// 元に戻す処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: なし。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2008.11.26</br>
        /// </remarks>
        private void Retry()
        {
            this.Clear();
        }

        #region ■ データ送信クリア処理 ■
        /// <summary>
        /// データ送信クリア処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note	   : なし。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// <br></br>
        /// </remarks>
        private void Clear()
        {
            // 画面初期化処理
            this.InitializeScreen();
            ResetGridCol();//ADD 2011/09/14 sundx #24542 拠点選択について
        }

        /// <summary>
        /// データ送信クリア初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: データ送信クリアを行う</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void InitializeScreen()
        {
			GuidInitProc();
            // 送信情報テーブルクリア処理
            this._updateResultDataTable.Clear();
            // 抽出条件テーブルクリア処理
            this._extractionConditionDataTable.Clear();
            // 送信情報の取得
            this._updateCountInputAcs.GetSecMngSendData(this._enterpriseCode, out this._sendDataList);
            // 送信情報初期化処理
            this.InitialAccDataGridCol();
            // 抽出条件初期化処理
            this.InitialConDataGridCol();

            if (this.Condition_Grid.Rows.Count > 0)
            {
				//this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells["BeginningDate"];// DEL 2011/07/25
				this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells[this._extractionConditionDataTable.SendDestCondColumn.ColumnName];// ADD 2011/07/25
                this.ultraTabControl1.SelectedTab = this.ultraTabControl1.Tabs["updateTab"];
            }

            // ----- ADD 2011/11/11 xupz---------->>>>>
            this.tDateEditSt.SetDateTime(DateTime.Now);
            this.tDateEditEd.SetDateTime(DateTime.Now);
            // ----- ADD 2011/11/11 xupz----------<<<<<
        }
        #endregion ■ データ送信クリア処理 ■

        #region ■ 入力チェック処理 ■
        /// <summary>
        /// データ送信処理の入力チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: データ送信処理の入力チェック処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009.04.03</br>
        /// </remarks>
        private bool UpdateBeforeCheck()
        {
            bool status = true;

            string errMessage = "";

            if (!this.ScreenInputCheck(ref errMessage))
            {

                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                status = false;
            }

            return status;
        }

        /// <summary>
        /// 更新チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の更新チェックを行う。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009.04.03</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage)
        {
            bool status = true;

            const string ct_NoInput = "が未入力です。";
            const string ct_RangeError = "抽出日付の範囲が不正です。";
            const string ct_BeginTimeError = "の変更時は同一月内のみ設定が可能です。";

            DateTime begDateTime = new DateTime();
            DateTime endDateTime = new DateTime();

            // 送信対象データの存在チェック
            if (this._sendDataList.Count == 0)
            {
                errMessage = "送受信対象設定マスタが設定されていません。";
                return false;
			}

			# region [DEL 2011/07/28]
			//-----DEL 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
			//// 日付の範囲チェック用(開始日 > 終了日 → NG)
			//foreach (ExtractionConditionDataSet.ExtractionConditionRow row in this._updateCountInputAcs.ExtractionConditionDataTable)
			//{
			//    if (row.IsNull("BeginningTime") || row.IsNull("BeginningDate") || row.IsNull("EndDate") || row.IsNull("EndTime"))
			//    {
			//        break;
			//    }
			//    String beginningTimeStr = row.BeginningTime;
			//    String endDateTimeStr = row.EndTime;

			//    if (string.IsNullOrEmpty(beginningTimeStr) || string.IsNullOrEmpty(endDateTimeStr))
			//    {
			//        break;
			//    }
			//    int beginningTimeHours = int.Parse(beginningTimeStr.Substring(0, 2));
			//    int beginningTimeMinutes = int.Parse(beginningTimeStr.Substring(3, 2));
			//    int beginningTimeSeconds = int.Parse(beginningTimeStr.Substring(6, 2));
                
			//    int endDateHours = int.Parse(endDateTimeStr.Substring(0, 2));
			//    int endDateMinutes = int.Parse(endDateTimeStr.Substring(3, 2));
			//    int endDateSeconds = int.Parse(endDateTimeStr.Substring(6, 2));
			//    // 開始日
			//    begDateTime = new DateTime(row.BeginningDate.Year, row.BeginningDate.Month, row.BeginningDate.Day,
			//        beginningTimeHours, beginningTimeMinutes, beginningTimeSeconds);
			//    // 終了日
			//    endDateTime = new DateTime(row.EndDate.Year, row.EndDate.Month, row.EndDate.Day,
			//        endDateHours, endDateMinutes, endDateSeconds);
			//}

			//String beginningDate = this.Condition_Grid.Rows[0].Cells["BeginningDate"].Value.ToString().Trim();
			//String beginningTime = this.Condition_Grid.Rows[0].Cells["BeginningTime"].Value.ToString().Trim();
			//String endDate = this.Condition_Grid.Rows[0].Cells["EndDate"].Value.ToString().Trim();
			//String endTime = this.Condition_Grid.Rows[0].Cells["EndTime"].Value.ToString().Trim();

			//// 開始日付
			//if (beginningDate == string.Empty)
			//{
			//    errMessage = string.Format("抽出開始日付{0}", ct_NoInput);
			//    this.Condition_Grid.ActiveCell =  this.Condition_Grid.Rows[0].Cells["BeginningDate"];

			//    status = false;

			//    return status;
			//}
			//// 開始時間
			//if (this.Condition_Grid.Rows[0].Cells["BeginningTime"].Value.ToString().Trim() == string.Empty)
			//{
			//    errMessage = string.Format("抽出開始時間{0}", ct_NoInput);
			//    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells["BeginningTime"];
			//    status = false;

			//    return status;
			//}
			//// 終了日付
			//if (this.Condition_Grid.Rows[0].Cells["EndDate"].Value.ToString().Trim() == string.Empty)
			//{
			//    errMessage = string.Format("抽出終了日付{0}", ct_NoInput);
			//    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells["EndDate"];
			//    status = false;

			//    return status;
			//}
			//// 終了時間
			//if (this.Condition_Grid.Rows[0].Cells["EndTime"].Value.ToString().Trim() == string.Empty)
			//{
			//    errMessage = string.Format("抽出終了時間{0}", ct_NoInput);
			//    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells["EndTime"];
			//    status = false;

			//    return status;
			//}

			//// 日付の範囲をチェック(開始日 > 終了日 → NG)
			//if (begDateTime > endDateTime)
			//{
			//    errMessage = ct_RangeError;
			//    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells["BeginningDate"];
			//    status = false;
			//    return status;
			//}

			//// 更新画面の開始日付チェック
			//if (!this.UpdateOverData())
			//{
			//    errMessage = "送信対象拠点が設定されていません。";
			//    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells["BeginningDate"];
			//    status = false;
			//    return status;
			//}

			//if (_startTime.Year == begDateTime.Year && _startTime.Month == begDateTime.Month && _startTime.Day == begDateTime.Day
			//     && _startTime.Hour == begDateTime.Hour && _startTime.Minute == begDateTime.Minute && _startTime.Second == begDateTime.Second)
			//{ 
			//    status = true;
			//}
			//else
			//{
			//    // シック時間チェック
			//    if (begDateTime < _startTime)
			//    {
			//        if (begDateTime.Year != endDateTime.Year || begDateTime.Month != endDateTime.Month)
			//        {
			//            errMessage = string.Format("開始日付{0}", ct_BeginTimeError);
			//            this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[0].Cells["BeginningDate"];
			//            status = false;
			//            return status;
			//        }
			//    }
			//}

			//-----DEL 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
			# endregion

			//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
			if (string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.DataText))
			{
				errMessage = string.Format("送信先{0}", ct_NoInput);
				tEdit_SectionCodeAllowZero.Focus();
				status = false;

				return status;
			}
			bool checkCountFlg = false;
			selectSendInfoList = new ArrayList();

			ArrayList newSndDestCodeList = new ArrayList();
			_updateCountInputAcs.ReloadSecMngSetInfo(_enterpriseCode, out newSndDestCodeList);

			for (int i = 0; i < this.Condition_Grid.Rows.Count; i++)
			{
				//チェックオンされた送信条件レコードはチェックを行う。
				if (((bool)this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Value) == true)
				{
					checkCountFlg = true;
					// 日付の範囲チェック用(開始日 > 終了日 → NG)
					ExtractionConditionDataSet.ExtractionConditionRow row = (ExtractionConditionDataSet.ExtractionConditionRow)this._updateCountInputAcs.ExtractionConditionDataTable.Rows[i];
					selectSendInfoList.Add(this.sendDestSecList[i]);

					//選択している送信先コードが削除されたかどうかチェック
					if (!newSndDestCodeList.Contains(((SecMngSet)this.sendDestSecList[i]).SendDestSecCode.Trim()))
					{
						errMessage = string.Format("削除された送信先が存在します。");
						status = false;
						return status;
					}

                    
                    if ((int)this.tce_ExtractCondDiv.Value == 0) //ADD 2011/11/11 xupz
                    {     //ADD 2011/11/11 xupz
                        String beginningDate = this.Condition_Grid.Rows[i].Cells["BeginningDate"].Value.ToString().Trim();
                        String beginningTime = this.Condition_Grid.Rows[i].Cells["BeginningTime"].Value.ToString().Trim();
                        String endDate = this.Condition_Grid.Rows[i].Cells["EndDate"].Value.ToString().Trim();
                        String endTime = this.Condition_Grid.Rows[i].Cells["EndTime"].Value.ToString().Trim();

                        // 開始日付
                        if (beginningDate == string.Empty)
                        {
                            errMessage = string.Format("抽出開始日付{0}", ct_NoInput);
                            this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells["BeginningDate"];
                            status = false;
                            return status;
                        }
                        // 開始時間
                        if (beginningTime == string.Empty)
                        {
                            errMessage = string.Format("抽出開始時間{0}", ct_NoInput);
                            this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells["BeginningTime"];
                            status = false;
                            return status;
                        }
                        // 終了日付
                        if (endDate == string.Empty)
                        {
                            errMessage = string.Format("抽出終了日付{0}", ct_NoInput);
                            this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells["EndDate"];
                            status = false;
                            return status;
                        }
                        // 終了時間
                        if (endTime == string.Empty)
                        {
                            errMessage = string.Format("抽出終了時間{0}", ct_NoInput);
                            this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells["EndTime"];
                            status = false;
                            return status;
                        }

                        String beginningTimeStr = row.BeginningTime;
                        String endDateTimeStr = row.EndTime;

                        int beginningTimeHours = int.Parse(beginningTimeStr.Substring(0, 2));
                        int beginningTimeMinutes = int.Parse(beginningTimeStr.Substring(3, 2));
                        int beginningTimeSeconds = int.Parse(beginningTimeStr.Substring(6, 2));

                        int endDateHours = int.Parse(endDateTimeStr.Substring(0, 2));
                        int endDateMinutes = int.Parse(endDateTimeStr.Substring(3, 2));
                        int endDateSeconds = int.Parse(endDateTimeStr.Substring(6, 2));
                        // 開始日
                        begDateTime = new DateTime(row.BeginningDate.Year, row.BeginningDate.Month, row.BeginningDate.Day,
                            beginningTimeHours, beginningTimeMinutes, beginningTimeSeconds);
                        // 終了日
                        endDateTime = new DateTime(row.EndDate.Year, row.EndDate.Month, row.EndDate.Day,
                            endDateHours, endDateMinutes, endDateSeconds);

                        // 日付の範囲をチェック(開始日 > 終了日 → NG)
                        if (begDateTime > endDateTime)
                        {
                            errMessage = ct_RangeError;
                            this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells["BeginningDate"];
                            status = false;
                            return status;
                        }
                    } //ADD 2011/11/11 xupz

					string tmpBaseCode = this.Condition_Grid.Rows[i].Cells["BaseCode"].Value.ToString();// ADD 2011.08.25
					string tmpSendCode = this.Condition_Grid.Rows[i].Cells["SendCode"].Value.ToString();// ADD 2011.08.25
					// 更新画面の開始日付チェック
					//if (!this.UpdateOverData()) // DEL 2011.08.25
					if (!this.UpdateOverData(tmpBaseCode, tmpSendCode)) // ADD 2011.08.25
					{
						errMessage = "送信対象拠点が設定されていません。";
						this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells["BeginningDate"];
						status = false;
						return status;
					}

                    if ((int)this.tce_ExtractCondDiv.Value == 0) //ADD 2011/11/11 xupz
                    {     //ADD 2011/11/11 xupz
                        if (_startTime.Year == begDateTime.Year && _startTime.Month == begDateTime.Month && _startTime.Day == begDateTime.Day
                             && _startTime.Hour == begDateTime.Hour && _startTime.Minute == begDateTime.Minute && _startTime.Second == begDateTime.Second)
                        {
                            status = true;
                        }
                        else
                        {
                            // シック時間チェック
                            if (begDateTime < _startTime)
                            {
                                if (begDateTime.Year != endDateTime.Year || begDateTime.Month != endDateTime.Month)
                                {
                                    errMessage = string.Format("開始日付{0}", ct_BeginTimeError);
                                    this.Condition_Grid.ActiveCell = this.Condition_Grid.Rows[i].Cells["BeginningDate"];
                                    status = false;
                                    return status;
                                }
                            }
                        }
                    } //ADD 2011/11/11 xupz
				}
			}
            // ----- ADD 2011/11/11 xupz---------->>>>>
            if ((int)this.tce_ExtractCondDiv.Value == 1)
            {
                DateTime dateSt = this.tDateEditSt.GetDateTime();
                DateTime dateEd = this.tDateEditEd.GetDateTime();

                DateGetAcs.CheckDateResult cdr;
                // 開始日付
                cdr = this._dateGetAcs.CheckDate(ref this.tDateEditSt, false);
                if (cdr == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                {
                    this.tDateEditSt.Focus();
                    errMessage = string.Format(MESSAGE_InvalidDate);
                    status = false;
                    return status;
                }
                else if (cdr == DateGetAcs.CheckDateResult.ErrorOfNoInput)
                {
                    errMessage = string.Format("抽出開始日付{0}", ct_NoInput);
                    this.tDateEditSt.Focus();
                    status = false;
                    return status; 
                }
                // 終了日付
                cdr = this._dateGetAcs.CheckDate(ref this.tDateEditEd, false);
                if (cdr == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                {
                    this.tDateEditEd.Focus();
                    errMessage = string.Format(MESSAGE_InvalidDate);
                    status = false;
                    return status;
                }
                else if (cdr == DateGetAcs.CheckDateResult.ErrorOfNoInput)
                {
                    errMessage = string.Format("抽出終了日付{0}", ct_NoInput);
                    this.tDateEditEd.Focus();
                    status = false;
                    return status; 
                }

                // 伝票日付の日付範囲をチェック(開始日 > 終了日 → NG)
                if (dateSt > dateEd)
                {
                    errMessage = ct_RangeError;
                    this.tDateEditSt.Focus();
                    status = false;
                    return status;
                }

                if (_startTime.Year == dateSt.Year && _startTime.Month == dateSt.Month && _startTime.Day == dateSt.Day
                     && _startTime.Hour == dateSt.Hour && _startTime.Minute == dateSt.Minute && _startTime.Second == dateSt.Second)
                {
                    status = true;
                }
                else
                {
                    // シック時間チェック
                    if (dateSt < _startTime)
                    {
                        if (dateSt.Year != dateEd.Year || dateSt.Month != dateEd.Month)
                        {
                            errMessage = string.Format("開始日付{0}", ct_BeginTimeError);
                            this.tDateEditSt.Focus();
                            status = false;
                            return status;
                        }
                    }
                }
            }
            // ----- ADD 2011/11/11 xupz----------<<<<<

			//送信先が1つでもチェックオンされない場合
			if (!checkCountFlg && this.Condition_Grid.Rows.Count>0)
			{
				errMessage = "送信先拠点が選択されていません。";
				status = false;
				return status;
			}
			
			//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<

            // 接続先チェック
            if (!_updateCountInputAcs.CheckConnect(_enterpriseCode, false, out _connectPointDiv, out errMessage))
            {
                status = false;
                return status;
            }

            return status;
        }

        /// <summary>
        /// エラーメッセージ処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="status">STATUS</param>
        /// <returns>true:出荷取消完了 false:出荷取消未完了</returns>
        /// <remarks>
        /// <br>Note		: エラーメッセージを行う。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel,
                ct_ClassID,
                "",
                "",
                "",
                message,
                status,
                null,
                MessageBoxButtons.OK,
                MessageBoxDefaultButton.Button1);
        }

        #endregion  ■ 入力チェック処理 ■


        /// <summary>
        /// グリッドキープレスイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void Condition_Grid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.Condition_Grid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.Condition_Grid.ActiveCell;

            // ActiveCellが数量の場合
            if (cell.Column.Key == this._extractionConditionDataTable.BeginningTimeColumn.ColumnName
                || cell.Column.Key == this._extractionConditionDataTable.EndTimeColumn.ColumnName)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(e.KeyChar, cell.Text, cell.SelStart, cell.SelLength))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 数値入力チェック処理
        /// </summary>
        /// <param name="key">入力されたキー値</param>
        /// <param name="prevVal">入力値</param>
        /// <param name="selstart">開始位置</param>
        /// <param name="sellength">長さ</param>
        /// <returns>true=入力可,false=入力不可</returns>
        private bool KeyPressNumCheck(char key, string prevVal, int selstart, int sellength)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }
            // 数値以外は、ＮＧ
            if (!Char.IsDigit(key))
            {
                return false;
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string _strResult = "";
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // キーが押された結果の文字列を生成する。
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // 桁数チェック！
            if (_strResult.Length > 6)
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// Enterキーの処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: Enterキーをクッリクする時、処理を行います。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void Condition_Grid_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.Condition_Grid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.Condition_Grid.ActiveCell;
            int rowIndex = cell.Row.Index;


            // ActiveCellが開始時間の場合
            if (cell.Column.Key == this._extractionConditionDataTable.BeginningTimeColumn.ColumnName)
            {
                string value = cell.Value.ToString().Trim();
                // 開始時間変換
                if (value.Length == 6)
                {
                    this._extractionConditionDataTable[rowIndex].BeginningTime = value.Substring(0, 2) + ":" +
                       value.Substring(2, 2) + ":" + value.Substring(4, 2);
                }
            }
            // ActiveCellが終了時間の場合
            else if (cell.Column.Key == this._extractionConditionDataTable.EndTimeColumn.ColumnName)
            {
                string value = cell.Value.ToString().Trim();
                // 終了時間変換
                if (value.Length == 6)
                {
                    this._extractionConditionDataTable[rowIndex].EndTime = value.Substring(0, 2) + ":" +
                       value.Substring(2, 2) + ":" + value.Substring(4, 2);
                }
            }
        }

        /// <summary>
        /// Enterキーの処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: Enterキーをクッリクする時、処理を行います。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009.04.01</br>
        /// </remarks>
        private void Condition_Grid_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            if (this.Condition_Grid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.Condition_Grid.ActiveCell;
            int rowIndex = cell.Row.Index;
            String value = cell.Value.ToString().Trim();

            // ActiveCellが開始時間の場合
            if (cell.Column.Key == this._extractionConditionDataTable.BeginningTimeColumn.ColumnName)
            {
                // 開始時間変換
                if (value.Length == 8)
                {
                    this._extractionConditionDataTable[rowIndex].BeginningTime = value.Substring(0, 2) + value.Substring(3, 2) + value.Substring(6, 2);
                    cell.Value = value.Substring(0, 2) + value.Substring(3, 2) + value.Substring(6, 2);
                }
            }
            // ActiveCellが終了時間の場合
            else if (cell.Column.Key == this._extractionConditionDataTable.EndTimeColumn.ColumnName)
            {
                // 終了時間変換
                if (value.Length == 8)
                {
                    this._extractionConditionDataTable[rowIndex].EndTime = value.Substring(0, 2) + value.Substring(3, 2) + value.Substring(6, 2);
                    cell.Value = value.Substring(0, 2) + value.Substring(3, 2) + value.Substring(6, 2);
                }
            }
            // ADD 2009/05/20 --->>>
            else if (cell.Column.Key == this._extractionConditionDataTable.BeginningDateColumn.ColumnName
               || cell.Column.Key == this._extractionConditionDataTable.EndDateColumn.ColumnName)
            {
                if (cell.Value is DBNull)
                {
                    this._preDataTime = DateTime.MinValue;
                }
                else
                {
                    this._preDataTime = Convert.ToDateTime(cell.Value);
                }
            }
            // ADD 2009/05/20 ---<<<
        }

        /// <summary>
        /// グリッドセルアップデート後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: グリッドセルアップデート後イベント処理発生します。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private void Condition_Grid_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell == null) return;
            int rowIndex = e.Cell.Row.Index;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;

            // ADD 2009/05/20 --->>>
            string errMsg = string.Empty;
            if (cell.Column.Key == this._extractionConditionDataTable.BeginningTimeColumn.ColumnName)
            {
                errMsg = "開始時間は時間6桁で入力して下さい。";
            }
            else if (cell.Column.Key == this._extractionConditionDataTable.EndTimeColumn.ColumnName)
            {
                errMsg = "終了時間は時間6桁で入力して下さい。";
            }
            // ADD 2009/05/20 ---<<<

            // ActiveCellが開始時間の場合
            if (cell.Column.Key == this._extractionConditionDataTable.BeginningTimeColumn.ColumnName
                || cell.Column.Key == this._extractionConditionDataTable.EndTimeColumn.ColumnName)
            {
                string startTime = cell.Value.ToString().Trim();
                // チェック処理
                if (!string.IsNullOrEmpty(startTime))
                {
                    bool inputFlg = true;
                    for (int i = 0; i < startTime.Length; i++)
                    {
                        if (!char.IsNumber(startTime, i))
                        {
                            inputFlg = false;
                            break;
                        }
                    }

                    if (!inputFlg)
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           // UPD 2009/05/20 --->>>
                           // "データ値を更新できません:エディタの値は無効です。",
                           errMsg,
                            // UPD 2009/05/20 ---<<<
                           -1,
                           MessageBoxButtons.OK);
                        cell.Value = string.Empty;
                    }
                    else
                    {
                        // 桁チェック
                        if (startTime.Length != 6)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                // UPD 2009/05/20 --->>>
                                // "データ値を更新できません:エディタの値は無効です。",
                                errMsg,
                                // UPD 2009/05/20 ---<<<
                                -1,
                                MessageBoxButtons.OK);
                            cell.Value = string.Empty;
                        }
                        else
                        {
                            // 時間有効性チェック
                            int hour = Convert.ToInt32(startTime.Substring(0, 2));
                            int minute = Convert.ToInt32(startTime.Substring(2, 2));
                            int second = Convert.ToInt32(startTime.Substring(4, 2));
                            if (hour >= 24 || minute >= 60 || second >= 60)
                            {
                                TMsgDisp.Show(
                                   this,
                                   emErrorLevel.ERR_LEVEL_INFO,
                                   this.Name,
                                    // UPD 2009/05/20 --->>>
                                    // "データ値を更新できません:エディタの値は無効です。",
                                    errMsg,
                                    // UPD 2009/05/20 ---<<<
                                   -1,
                                   MessageBoxButtons.OK);
                                cell.Value = string.Empty;
                            }
                            else
                            {
                                if (cell.Column.Key == this._extractionConditionDataTable.BeginningTimeColumn.ColumnName)
                                {
                                    this._extractionConditionDataTable[rowIndex].BeginningTime = startTime.Substring(0, 2) + ":" 
                                        + startTime.Substring(2, 2) + ":" + startTime.Substring(4, 2);
                                }
                                else if (cell.Column.Key == this._extractionConditionDataTable.EndTimeColumn.ColumnName) 
                                {
                                    this._extractionConditionDataTable[rowIndex].EndTime = startTime.Substring(0, 2) + ":"
                                        + startTime.Substring(2, 2) + ":" + startTime.Substring(4, 2);
                                }

                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void Condition_Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.Condition_Grid.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.Condition_Grid.ActiveCell;
                // Shiftキーの場合
                if (e.Shift)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                            {
                                this.Condition_Grid.ActiveCell = null;
                                this.Condition_Grid.ActiveRow = cell.Row;
                                this.Condition_Grid.Selected.Rows.Clear();
                                this.Condition_Grid.Selected.Rows.Add(cell.Row);
                                break;
                            }
                        case Keys.Up:
                            {
                                this.Condition_Grid.ActiveCell = null;
                                this.Condition_Grid.ActiveRow = cell.Row;
                                this.Condition_Grid.Selected.Rows.Clear();
                                this.Condition_Grid.Selected.Rows.Add(cell.Row);
                                break;
                            }
                        case Keys.Home:
                            {
                                if ((this.Condition_Grid.ActiveCell != null) && (this.Condition_Grid.ActiveCell.IsInEditMode))
                                {
                                    // 編集モードの場合はなにもしない
                                }
                                else
                                {
                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid);
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                if ((this.Condition_Grid.ActiveCell != null) && (this.Condition_Grid.ActiveCell.IsInEditMode))
                                {
                                    // 編集モードの場合はなにもしない
                                }
                                else
                                {
                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInGrid);
                                }
                                break;
                            }
                        case Keys.Enter:
                            {
								 //EnterNextEditableCellDetail(cell, -1);
                                break;
                            }
                    }
                }
                // Altキーの場合
                else if (e.Alt)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                            {
                                // s
                                break;
                            }
                    }
                }
                else
                {
                    // 編集中であった場合
					if (cell.IsInEditMode)
                    {
                        // セルのスタイルにて判定
                        switch (this.Condition_Grid.ActiveCell.StyleResolved)
                        {
                            // テキストボックス・テキストボックス(ボタン付)
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ←キー
                                        case Keys.Left:
                                            if (this.Condition_Grid.ActiveCell.SelStart == 0)
                                            {
                                                this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                                // ADD 張莉莉 2011/07/28 ----------------------------->>>>>>
                                                while (!(this.Condition_Grid.ActiveCell.IsInEditMode ||
                                                    "SendDestCond".Equals(this.Condition_Grid.ActiveCell.Column.ToString())))
                                                {
                                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                    e.Handled = true;
                                                }
                                                // ADD 張莉莉 2011/07/28 -----------------------------<<<<<<
                                            }
                                            break;
                                        // →キー
                                        case Keys.Right:
                                            if (this.Condition_Grid.ActiveCell.SelStart >= this.Condition_Grid.ActiveCell.Text.Length)
                                            {
                                                this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                                // ADD 張莉莉 2011/07/28 ----------------------------->>>>>>
                                                while (!this.Condition_Grid.ActiveCell.IsInEditMode )
                                                {
                                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                    e.Handled = true;
                                                }
                                                // ADD 張莉莉 2011/07/28 -----------------------------<<<<<<
                                            }
                                            break;
                                        // ADD 張莉莉 2011/07/28 ----------------------------->>>>>>
                                        // ↓キー
                                        case Keys.Down:
                                            {
                                                this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);
                                                if (this.Condition_Grid.ActiveCell.CanEnterEditMode)
                                                {
                                                    this.Condition_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                                }
                                                e.Handled = true;
                                            }
                                            break;
                                        // ↑キー
                                        case Keys.Up:
                                            {
                                                this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell);
                                                if (this.Condition_Grid.ActiveCell.CanEnterEditMode)
                                                {
                                                    this.Condition_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                                }
                                                e.Handled = true;
                                            }
                                            break;
                                        // ADD 張莉莉 2011/07/28 -----------------------------<<<<<<
                                    }
                                }
                                break;
                            // 上記以外のスタイル
                            default:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ←キー
                                        case Keys.Left:
                                            {
                                                this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                                // ADD 張莉莉 2011/07/28 ----------------------------->>>>>>
                                                while (!(this.Condition_Grid.ActiveCell.IsInEditMode ||
                                                    "SendDestCond".Equals(this.Condition_Grid.ActiveCell.Column.ToString())))
                                                {
                                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                    e.Handled = true;
                                                }
                                                // ADD 張莉莉 2011/07/28 -----------------------------<<<<<<
                                            }
                                            break;
                                        // →キー
                                        case Keys.Right:
                                            {
                                                this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                                // ADD 張莉莉 2011/07/28 ----------------------------->>>>>>
                                                while (!this.Condition_Grid.ActiveCell.IsInEditMode)
                                                {
                                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                    e.Handled = true;
                                                }
                                                // ADD 張莉莉 2011/07/28 -----------------------------<<<<<<
                                            }
                                            break;
                                        // ADD 張莉莉 2011/07/28 ----------------------------->>>>>>
                                        // ↓キー
                                        case Keys.Down:
                                            {
                                                this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);
                                                if (this.Condition_Grid.ActiveCell.CanEnterEditMode)
                                                {
                                                    this.Condition_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                                }
                                                e.Handled = true;
                                            }
                                            break;
                                        // ↑キー
                                        case Keys.Up:
                                            {
                                                this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell);
                                                if (this.Condition_Grid.ActiveCell.CanEnterEditMode)
                                                {
                                                    this.Condition_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                                }
                                                e.Handled = true;
                                            }
                                            break;
                                        // ADD 張莉莉 2011/07/28 -----------------------------<<<<<<
                                    }
                                    break;
                                }
                        }
                    }
                    // ADD 張莉莉 2011/07/28 ----------------------------->>>>>>
                    else
                    {
                        switch (e.KeyCode)
                        {
                            case Keys.Left:
                                {
                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                    e.Handled = true;
                                    while (!(this.Condition_Grid.ActiveCell.IsInEditMode || 
                                        "SendDestCond".Equals(this.Condition_Grid.ActiveCell.Column.ToString())))
                                    {
                                        this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                        e.Handled = true;
                                    }
                                    e.Handled = true;
                                    break;
                                }
                            case Keys.Right:
                                {
                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                    e.Handled = true;
                                    while (!(this.Condition_Grid.ActiveCell.IsInEditMode ||
                                        "BeginningDate".Equals(this.Condition_Grid.ActiveCell.Column.ToString())))
                                    {
                                        this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                        e.Handled = true;
                                    }
                                    e.Handled = true;
                                    break;
                                }
                            // ↓キー
                            case Keys.Down:
                                {
                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);
                                    if (this.Condition_Grid.ActiveCell.CanEnterEditMode)
                                    {
                                        this.Condition_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                    e.Handled = true;
                                }
                                break;
                            // ↑キー
                            case Keys.Up:
                                {
                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell);
                                    if (this.Condition_Grid.ActiveCell.CanEnterEditMode)
                                    {
                                        this.Condition_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                    e.Handled = true;
                                }
                                break;
                        }
                    }
                    // ADD 張莉莉 2011/07/28 -----------------------------<<<<<<

                    switch (e.KeyCode)
                    {
                        case Keys.Home:
                            {
                                if ((this.Condition_Grid.ActiveCell != null) && (this.Condition_Grid.ActiveCell.IsInEditMode))
                                {
                                    // 編集モードの場合はなにもしない
                                }
                                else
                                {
                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInRow);
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                // 編集モードの場合はなにもしない
                                if ((this.Condition_Grid.ActiveCell != null) && (this.Condition_Grid.ActiveCell.IsInEditMode))
                                {
                                    //
                                }
                                else
                                {
                                    this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInRow);
                                }
                                break;
                            }
                        case Keys.Enter:
                            {
                                break;
                            }
                    }
                }
            }

            else if (this.Condition_Grid.ActiveRow != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow row = this.Condition_Grid.ActiveRow;

                switch (e.KeyCode)
                {
                    case Keys.Delete:
                        {
                            // Delキーの操作
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// 画面初期化後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: 画面初期化後イベント処理発生します。</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.04.30</br>
        /// </remarks>
        private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
        {
            this.timer_InitialSetFocus.Enabled = false;
            // 接続先チェック処理
            string errMsg = null;
            if (!_updateCountInputAcs.CheckConnect(_enterpriseCode, false, out _connectPointDiv, out errMsg))
            {
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, 0);
                return;
            }
        }

        // ADD 2009/05/20 --->>>
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: フォームロードイベント処理発生します。</br>
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.05.20</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            this._prevControl = e.NextCtrl;

            switch (e.PrevCtrl.Name)
            {
				//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
				case "tEdit_SectionCodeAllowZero":
					{
						// 拠点コード取得
						string sectionCode = this.tEdit_SectionCodeAllowZero.DataText;
						if (sectionCode.Trim().Equals(""))
						{
							// 元に戻す処理
							this.Retry();
							return;
						}

						if (this._preSectionCode !=null && sectionCode.Trim().Equals(this._preSectionCode.PadLeft(2, '0')))
						{
							return;
						}
                        // DEL 2011/10/10------------>>>>>
                        //// ADD 2011.08.19--------->>>>>>
                        //if (sectionCode.Trim().Equals(_loginSectionCode.Trim()))
                        //{
                        //    TMsgDisp.Show(this,                     // 親ウィンドウフォーム
                        //                emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                        //                ct_ClassID,							// アセンブリID
                        //                "自拠点は選択できません。",	    // 表示するメッセージ
                        //                0,									    // ステータス値
                        //                MessageBoxButtons.OK);					// 表示するボタン

                        //    this.tEdit_SectionCodeAllowZero.DataText = this._preSectionCode.PadLeft(2, '0');
                        //    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                        //    return;
                        //}
                        //// ADD 2011.08.19---------<<<<<<
                        // DEL 2011/10/10------------<<<<<
						// 拠点名称取得
						string sectionName = GetSectionName(sectionCode);

						if (sectionName.Trim() != string.Empty)
						{
							//拠点管理設定マスタにチェック
							if (!sectionCode.PadLeft(2, '0').Equals("00"))
							{
								if (_searchSecMngList.Count > 0)
								{

									bool sameFlg = false;
									for (int i = 0; i < _searchSecMngList.Count; i++)
									{
										SecMngSet tSecMngSet = _searchSecMngList[i] as SecMngSet;
										if (tSecMngSet.SendDestSecCode.Trim().PadLeft(2, '0').Equals(sectionCode.PadLeft(2, '0')))
										{
											sameFlg = true;
										}
									}

									if (!sameFlg)
									{
										TMsgDisp.Show(this,                     // 親ウィンドウフォーム
										emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
										ct_ClassID,							// アセンブリID
										//"送信先拠点コードが存在しない。",	    // 表示するメッセージ // DEL 2011.08.19 Redmine#23807
										"送信先拠点コードが存在しません。",	    // 表示するメッセージ// ADD 2011.08.19 Redmine#23807
										0,									    // ステータス値
										MessageBoxButtons.OK);					// 表示するボタン

										this.tEdit_SectionCodeAllowZero.DataText = this._preSectionCode.PadLeft(2, '0');
										e.NextCtrl = this.tEdit_SectionCodeAllowZero;
										return;
									}
								}

								else
								{
									TMsgDisp.Show(this,                     // 親ウィンドウフォーム
										   emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
										   ct_ClassID,							// アセンブリID
										   //"送信先拠点コードが存在しない。",	    // 表示するメッセージ // DEL 2011.08.19 Redmine#23807
										   "送信先拠点コードが存在しません。",	    // 表示するメッセージ// ADD 2011.08.19 Redmine#23807
										   0,									    // ステータス値
										   MessageBoxButtons.OK);					// 表示するボタン

									this.tEdit_SectionCodeAllowZero.DataText = string.Empty;
									e.NextCtrl = this.tEdit_SectionCodeAllowZero;
									return;

								}
							}
							this._preSectionCode = sectionCode;
							this.uLabel_SectionNm.Text = sectionName;
							this.tEdit_SectionCodeAllowZero.Text = sectionCode.Trim().PadLeft(2, '0');

							ResetGridCol();
                            SetSecCode(this.tEdit_SectionCodeAllowZero.Text);//ADD 2011/09/14 sundx #24542
						}
						else
						{
							TMsgDisp.Show(this,                     // 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
							ct_ClassID,							// アセンブリID
							"指定した拠点コードは存在しません。",	                // 表示するメッセージ
							0,									    // ステータス値
							MessageBoxButtons.OK);					// 表示するボタン

							this.tEdit_SectionCodeAllowZero.DataText = this._preSectionCode.PadLeft(2, '0');
							e.NextCtrl = this.tEdit_SectionCodeAllowZero;
						}

                        ChangeConditionGrid();  //  ADD dingjx  2011/11/01
						break;
					}
				//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>

                case "Condition_Grid":
                    {
						switch (e.Key)
						{
							case Keys.Return:
								{
									if (this.Condition_Grid.ActiveCell != null)
									{
										//if (MoveNextAllowEditCell(false) // DEl 2011/07/28
										if (MoveNextAllowEditCell(false, e.ShiftKey)) // ADD 2011/07/28
										{
											e.NextCtrl = null;
										}
										else if (this.Condition_Grid.Rows[this._updateCountInputAcs.ExtractionConditionDataTable.Rows.Count - 1].Cells[5].Activated)
										{
											e.NextCtrl = null;
											this.Condition_Grid.Rows[0].Cells[2].Activate();
											this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
										}
										else
										{
											e.NextCtrl = e.PrevCtrl;
										}
									}

									break;
								}
							case Keys.Tab:
								{
									//if (MoveNextAllowEditCell(false) // DEl 2011/07/28
									if (MoveNextAllowEditCell(false, e.ShiftKey))// ADD 2011/07/28
									{
										e.NextCtrl = null;
									}
									else if (this.Condition_Grid.Rows[this._updateCountInputAcs.ExtractionConditionDataTable.Rows.Count - 1].Cells[5].Activated)
									{
										e.NextCtrl = null;
										this.Condition_Grid.Rows[0].Cells[2].Activate();
										this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
									}
									else
									{
										e.NextCtrl = e.PrevCtrl;
									}

									break;
								}
						}
						break;
						
                    }
            }
        }

        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.20</br>
        /// </remarks>
		//private bool MoveNextAllowEditCell(bool activeCellCheck)// DEl 2011/07/28
		private bool MoveNextAllowEditCell(bool activeCellCheck, bool shiftFlg)// ADD 2011/07/28
        {
            this.Condition_Grid.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.Condition_Grid.ActiveCell != null))
            {
                if ((!this.Condition_Grid.ActiveCell.Column.Hidden) &&
                    (this.Condition_Grid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.Condition_Grid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }

            while (!moved)
            {
				//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
                if (shiftFlg)
                {
                    performActionResult = this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                }
				//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
                else
                {
                    performActionResult = this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                }

                if (performActionResult)
                {
                    if ((this.Condition_Grid.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.Condition_Grid.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
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
                this.Condition_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            this.Condition_Grid.ResumeLayout();
            return performActionResult;
        }


        /// <summary>
        /// セルのデータチェック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <returns/>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.20</br>
        /// </remarks>
        private void Condition_Grid_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            if (this.Condition_Grid.ActiveCell != null)
            {
                // 数値項目の場合
                if ((this.Condition_Grid.ActiveCell.Column.DataType == typeof(Int32)) ||
                    (this.Condition_Grid.ActiveCell.Column.DataType == typeof(Int64)) ||
                    (this.Condition_Grid.ActiveCell.Column.DataType == typeof(double)))
                {
                    Infragistics.Win.EmbeddableEditorBase editorBase = this.Condition_Grid.ActiveCell.EditorResolved;

                    // 未入力は0にする				
                    if (editorBase.CurrentEditText.Trim() == "")
                    {
                        editorBase.Value = 0;				// 0をセット
                        this.Condition_Grid.ActiveCell.Value = 0;
                    }
                    // 数値項目に「-」or「.」だけしか入ってなかったら駄目です				
                    else if ((editorBase.CurrentEditText.Trim() == "-") ||
                        (editorBase.CurrentEditText.Trim() == ".") ||
                        (editorBase.CurrentEditText.Trim() == "-."))
                    {
                        editorBase.Value = 0;				// 0をセット
                        this.Condition_Grid.ActiveCell.Value = 0;
                    }
                    // 通常入力				
                    else
                    {
                        try
                        {
                            editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.Condition_Grid.ActiveCell.Column.DataType);
                            this.Condition_Grid.ActiveCell.Value = editorBase.Value;
                        }
                        catch
                        {
                            editorBase.Value = 0;
                            this.Condition_Grid.ActiveCell.Value = 0;
                        }
                    }
                    e.RaiseErrorEvent = false;			// エラーイベントは発生させない
                    e.RestoreOriginalValue = false;		// セルの値を元に戻さない	
                    e.StayInEditMode = false;			// 編集モードは抜ける
                }
                else if (this.Condition_Grid.ActiveCell.Column.DataType == typeof(TimeSpan))
                {
                    try
                    {
                        Infragistics.Win.EmbeddableEditorBase editorBase = this.Condition_Grid.ActiveCell.EditorResolved;

                        if (editorBase.TextLength == 6)
                        {
                            string value = editorBase.CurrentEditText;

                            editorBase.Value = new System.TimeSpan(Convert.ToInt32(value.Substring(0, 2)),
                                Convert.ToInt32(value.Substring(2, 2)), Convert.ToInt32(value.Substring(4, 2)));
                            this.Condition_Grid.ActiveCell.Value = new System.TimeSpan(Convert.ToInt32(value.Substring(0, 2)),
                                Convert.ToInt32(value.Substring(2, 2)), Convert.ToInt32(value.Substring(4, 2)));
                        }
                        else
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "データ値を更新できません:エディタの値は無効です。",
                                -1,
                                MessageBoxButtons.OK);

                            editorBase.Value = null;
                            this.Condition_Grid.ActiveCell.Value = null;
                        }
                    }
                    catch
                    {

                    }
                }
                else if (this.Condition_Grid.ActiveCell.Column.DataType == typeof(DateTime))
                {
                    try
                    {
                        Infragistics.Win.EmbeddableEditorBase editorBase = this.Condition_Grid.ActiveCell.EditorResolved;
                        Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.Condition_Grid.ActiveCell;

                        if (cell.Column.Key == this._extractionConditionDataTable.BeginningDateColumn.ColumnName)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "開始日付は日付8桁で入力して下さい。",
                                -1,
                                MessageBoxButtons.OK);

                            if (this._preDataTime == DateTime.MinValue)
                            {
                                editorBase.Value = null;
                                this.Condition_Grid.ActiveCell.Value = null;
                            }
                            else
                            {
                                editorBase.Value = this._preDataTime;
                                this.Condition_Grid.ActiveCell.Value = this._preDataTime;
                            }
                        }
                        else if (cell.Column.Key == this._extractionConditionDataTable.EndDateColumn.ColumnName)
                        {
                            TMsgDisp.Show(
                               this,
                               emErrorLevel.ERR_LEVEL_INFO,
                               this.Name,
                               "終了日付は日付8桁で入力して下さい。",
                               -1,
                               MessageBoxButtons.OK);

                            if (this._preDataTime == DateTime.MinValue)
                            {
                                editorBase.Value = null;
                                this.Condition_Grid.ActiveCell.Value = null;
                            }
                            else
                            {
                                editorBase.Value = this._preDataTime;
                                this.Condition_Grid.ActiveCell.Value = this._preDataTime;
                            }
                        }
                    }
                    catch
                    {

                    }

                    e.RaiseErrorEvent = false;			// エラーイベントは発生させない
                    e.RestoreOriginalValue = false;		// セルの値を元に戻さない	
                }
            }
        }
        // ADD 2009/05/20 ---<<<


		//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
        /// <summary>
        /// 送信先
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SectionGuide_Click_1(object sender, EventArgs e)
        {
            // 拠点ガイド表示
            SecInfoSet sectionInfo;

            // 全社表示ガイド→全社非表示ガイドへ変更
            //int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out sectionInfo); //DEL by Liangsd 2011/09/05
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out sectionInfo);     //ADD by Liangsd 2011/09/05
            // DEL 2011/10/10------------>>>>>
            //// ADD 2011.08.19------------>>>>>
            //if (sectionInfo.SectionCode.Trim().Equals(_loginSectionCode.Trim()))
            //{
            //    TMsgDisp.Show(this,                     // 親ウィンドウフォーム
            //                emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
            //                ct_ClassID,							// アセンブリID
            //                "自拠点は選択できません。",	    // 表示するメッセージ
            //                0,									    // ステータス値
            //                MessageBoxButtons.OK);					// 表示するボタン

            //    this.tEdit_SectionCodeAllowZero.DataText = this._preSectionCode.PadLeft(2, '0');
            //    return;
            //}
            //// ADD 2011.08.19------------<<<<<
            // DEL 2011/10/10------------<<<<<
            // ステータスが正常時のみ情報をUIにセット
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
				//拠点管理設定マスタにチェック
                //if (_searchSecMngList.Count > 0 && !sectionInfo.SectionCode.Trim().Equals("00")) //DEL by Liangsd 2011/09/05
                if (_searchSecMngList.Count >= 0 && !sectionInfo.SectionCode.Trim().Equals("00"))//ADD by Liangsd 2011/09/05
				{
					bool sameFlg = false;
					for (int i = 0; i < _searchSecMngList.Count; i++)
					{
						SecMngSet tSecMngSet = _searchSecMngList[i] as SecMngSet;
						if (tSecMngSet.SendDestSecCode.Trim().Equals(sectionInfo.SectionCode.Trim()))
						{
							sameFlg = true;
						}
					}

                    if (!sameFlg)
                    {
                        TMsgDisp.Show(this,                     // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                        ct_ClassID,							// アセンブリID
                            //"送信先拠点コードが存在しない。",	    // 表示するメッセージ // DEL 2011.08.19 Redmine#23807
                        "送信先拠点コードが存在しません。",	    // 表示するメッセージ// ADD 2011.08.19 Redmine#23807
                        0,									    // ステータス値
                        MessageBoxButtons.OK);					// 表示するボタン

                        this.tEdit_SectionCodeAllowZero.DataText = this._preSectionCode.PadLeft(2, '0');
                        return;
                    }                    
				}
				this.tEdit_SectionCodeAllowZero.Text = sectionInfo.SectionCode.Trim();
                this.uLabel_SectionNm.Text = sectionInfo.SectionGuideNm.Trim();
				this._preSectionCode = sectionInfo.SectionCode.Trim();
				ResetGridCol();
                SetSecCode(this.tEdit_SectionCodeAllowZero.Text);//ADD 2011/09/14 sundx #24542
                // 次フォーカス
                this.ultraTabControl1.Focus();
            }
            ChangeConditionGrid();  //  ADD dingjx  2011/11/01
        }

        /// <summary>
        ///	送信先初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note	    : 画面の入力チェックをします。</br>
        /// <br>Programmer  : 芦珊</br>
        /// <br>Date        : 2011/07/28</br>
        private void GuidInitProc()
        {
            string secCode = CheckSecMng();
            // 画面の初期値をセット
			if (string.Empty.Equals(secCode))
			{
				this.tEdit_SectionCodeAllowZero.Text = string.Empty;
				this.uLabel_SectionNm.Text = string.Empty;
			}
			else
			{
				this.tEdit_SectionCodeAllowZero.Text = secCode.Trim().PadLeft(2, '0');
				this._preSectionCode = secCode.Trim().PadLeft(2, '0');
				this.uLabel_SectionNm.Text = GetSectionName(secCode);
			}
            // フォカスの設定
            this.tEdit_SectionCodeAllowZero.Focus();
        }

        /// <summary>				
        /// 拠点管理設定マスタチェック処理				
        /// </summary>				
        /// <returns>チェック処理結果</returns>				
        private string CheckSecMng()
        {
            // 拠点管理設定マスタのデータを検索する
            SecMngSetAcs secMngSetAcs = new SecMngSetAcs();
            ArrayList secMngSetList = new ArrayList();
			_searchSecMngList = new ArrayList();
			string secCd = "";
			Hashtable sendSecCdHt = new Hashtable();

            int status = secMngSetAcs.SearchAll(out secMngSetList, this._enterpriseCode);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && secMngSetList.Count > 0)
			{
				foreach (SecMngSet tmpSecMngSet in secMngSetList)
				{
					if (tmpSecMngSet.Kind.Equals(0) &&
						tmpSecMngSet.ReceiveCondition.Equals(0) &&
						tmpSecMngSet.LogicalDeleteCode.Equals(0))
					{
						_searchSecMngList.Add(tmpSecMngSet);
						if (!sendSecCdHt.Contains(tmpSecMngSet.SendDestSecCode.Trim()))
						{
							sendSecCdHt.Add(tmpSecMngSet.SendDestSecCode.Trim(), tmpSecMngSet);
						}
					}
				}
				if (1 == sendSecCdHt.Count)
				{
					//拠点管理設定マスタには単一データがある場合
					SecMngSet tSecMngSet = _searchSecMngList[0] as SecMngSet;
					secCd = tSecMngSet.SendDestSecCode;
				}
				else if (sendSecCdHt.Count > 1)
				{
					//拠点管理設定マスタには複数データがある場合
					secCd = "00";
                    //ADD 2011/09/14 sundx #24542 ---------------------------------->>>>>
                    if (_initSecCode == secCd || sendSecCdHt.Contains(_initSecCode))
                    {
                        secCd = _initSecCode;
                        SetSecCode(_initSecCode);
                    }
                    //ADD 2011/09/14 sundx #24542 ----------------------------------<<<<<
				}
			}
			else
			{
				secCd = string.Empty;
			}
            return secCd;
        }

		/// <summary>
		/// 拠点名称取得処理
		/// </summary>
		/// <param name="sectionCode">拠点コード</param>
		/// <returns>拠点名称</returns>
		/// <remarks>
		/// </remarks>
		private string GetSectionName(string sectionCode)
		{
			string sectionName = string.Empty;

			if (sectionCode.Trim().PadLeft(2, '0') == "00")
			{
				sectionName = "全社";
				return sectionName;
			}

			ArrayList retList = new ArrayList();
			SecInfoAcs secInfoAcs = new SecInfoAcs();

			try
			{
				foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
				{
					if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
					{
						sectionName = secInfoSet.SectionGuideNm.Trim();
						return sectionName;
					}
				}
			}
			catch
			{
				sectionName = string.Empty;
			}

			return sectionName;
		}

		/// <summary>
		/// グリッド情報を再設定
		/// </summary>
		/// <remarks>
		/// <br>Note　　　  :グリッド情報を再設定。</br>
		/// <br>Programmer  : 張莉莉</br>
		/// <br>Date        : 2011/07/28</br>
		/// </remarks>
		private void ResetGridCol()
		{
			this.LoadBaseData();
			this.CheckSecMng();

			this._extractionConditionDataTable.Clear();
			this._updateResultDataTable.Clear();

			// 送信情報データ設定
			this.Acc_Grid.DataSource = this._updateResultDataTable;
			// 送信条件データ設定
			this.Condition_Grid.DataSource = this._extractionConditionDataTable;
			// 送受信対象グリッド初期設定
			this.InitialAccDataGridCol();
			// グリッド初期設定の設定
			this.InitialConDataGridCol();
			// 送信条件グリッド再設定
			this.ResetConSettingGridCol();
		}

		/// <summary>
		/// 送信条件グリッド再設定
		/// </summary>
		/// <remarks>
		/// <br>Note　　　  :送信条件グリッド再設定。</br>
		/// <br>Programmer  : 張莉莉</br>
		/// <br>Date        : 2011/07/28</br>
		/// </remarks>
		private void ResetConSettingGridCol()
		{
			this._extractionConditionDataTable.Clear();
			//「00:全社」ではない場合、入力した送信先拠点だけを保留
			for (int i = 0; i < this._allConditionDataTable.Rows.Count; i++)
			{
				ExtractionConditionDataSet.ExtractionConditionRow newRow = _extractionConditionDataTable.NewExtractionConditionRow();
				ExtractionConditionDataSet.ExtractionConditionRow row = (ExtractionConditionDataSet.ExtractionConditionRow)_allConditionDataTable.Rows[i];
				newRow.SendDestCond = row.SendDestCond;
				newRow.SendCode = row.SendCode;
				newRow.SendName = row.SendName;
				newRow.BaseCode = row.BaseCode;
				newRow.BaseName = row.BaseName;

                // ----- DEL 2011/11/10 xupz---------->>>>>
                //newRow.BeginningDate = row.BeginningDate;
                //newRow.BeginningTime = row.BeginningTime;
                //newRow.EndDate = row.EndDate;
                //newRow.EndTime = row.EndTime;
                // ----- DEL 2011/11/10 xupz----------<<<<<

                // ----- ADD 2011/11/10 xupz---------->>>>>
                //データ送信抽出条件区分が「差分」の場合
                if(tce_ExtractCondDiv.SelectedIndex == 0)
                {
                    newRow.BeginningDate = row.BeginningDate;
                    newRow.BeginningTime = row.BeginningTime;
                    newRow.EndDate = row.EndDate;
                    newRow.EndTime = row.EndTime;
                }
                //データ送信抽出条件区分が「伝票日付」の場合
                else if (tce_ExtractCondDiv.SelectedIndex == 1)
                {
                    string StartTime = DateTime.MinValue.ToLongTimeString().ToString();
                    newRow.BeginningDate = DateTime.Now.Date;
                    newRow.BeginningTime = StartTime.PadLeft(8,'0');
                    newRow.EndDate = DateTime.Now.Date ;
                    newRow.EndTime = DateTime.Now.ToLongTimeString().ToString();
                }
                // ----- ADD 2011/11/10 xupz----------<<<<<

                if (ALL_SECTIONCODE.Equals(tEdit_SectionCodeAllowZero.DataText))
				{
					_extractionConditionDataTable.Rows.Add(newRow);
				}
				else
				{
					if (row.SendCode.Trim().Equals(tEdit_SectionCodeAllowZero.DataText.Trim()))
					{
						_extractionConditionDataTable.Rows.Add(newRow);
					}
				}
			}
		}

		/// <summary>
		/// 更新した後で送信条件タブを再設定する
		/// </summary>
		/// <remarks>		
		/// <br>Note		: 送信条件の時間設定処理を行う。</br>
		/// <br>Programmer	: 張莉莉</br>	
		/// <br>Date		: 2011/07/28</br>
		/// </remarks>
		private void SearchCondtionGridCol()
		{
			this.LoadBaseData();
			if (!ALL_SECTIONCODE.Equals(this.tEdit_SectionCodeAllowZero.DataText))
			{
				//「00:全社」ではない場合、入力した送信先拠点だけを保留
				ArrayList indexList = new ArrayList();
				for (int i = 0; i < this._extractionConditionDataTable.Rows.Count; i++)
				{
					ExtractionConditionDataSet.ExtractionConditionRow row = (ExtractionConditionDataSet.ExtractionConditionRow)_extractionConditionDataTable.Rows[i];
					if (!row.SendCode.Trim().Equals(tEdit_SectionCodeAllowZero.DataText.Trim()))
					{
						indexList.Add(i);
					}
				}

				for (int j = indexList.Count - 1; j >= 0; j--)
				{
					_extractionConditionDataTable.Rows.RemoveAt((int)indexList[j]);
				}
			}
			for (int i = 0; i < this._extractionConditionDataTable.Rows.Count; i++)
			{
				ExtractionConditionDataSet.ExtractionConditionRow row = (ExtractionConditionDataSet.ExtractionConditionRow)_extractionConditionDataTable.Rows[i];
				row.SendDestCond = false;
				for (int j = 0; j < selectSendInfoList.Count; j++)
				{
					SecMngSet secMngSetWork = (SecMngSet)selectSendInfoList[j];
					if (row.BaseCode.Trim().Equals(secMngSetWork.SectionCode.Trim())
						&& row.SendCode.Trim().Equals(secMngSetWork.SendDestSecCode.Trim()))
					{
						row.SendDestCond = true;
						break;
					}
				}
			}

		}
		//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<

		// ADD 2011.08.23------->>>>>
		/// <summary>
		/// SelectedTabChanged
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ultraTabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
		{
			if (e.Tab.Key.Equals("updateTab"))
			{
				ultraLabel1.Visible = true;
			}
			else
			{
				ultraLabel1.Visible = false;
			}
		}
		// ADD 2011.08.23-------<<<<<
		
        //  ADD dingjx  2011/11/01  ------------------------>>>>>>
        /// <summary>
        /// tce_ExtractCondDiv value changed event.
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">event param</param>
        /// <remarks>
        /// <br>Programmer  : dingjx</br>
        /// <br>Note        : Redmine #26228</br>
        /// </remarks>
        private void tce_ExtractCondDiv_ValueChanged(object sender, EventArgs e)
        {
            this.ChangeConditionGrid();
        }

        /// <summary>
        /// Change ConditionGrid's value
        /// </summary>
        /// <remarks>
        /// <br>Programmer  : dingjx</br>
        /// <br>Note        : Redmine #26228</br>
        /// </remarks>
        private void ChangeConditionGrid()
        {
            string MINVALUE = "000000"; // The time minvalue.
            string[] time = (DateTime.Now.ToString()).Split(' ');   // Get now time and split it.

            // 差分
            if (tce_ExtractCondDiv.SelectedIndex == 0)
            {
                this.SetExtractCondDiv(this.tce_ExtractCondDiv.SelectedIndex.ToString());    // Save selected index into local.

                this._extractionConditionDataTable.Clear();
                this.SearchCondtionGridCol();
                // ----- ADD 2011/11/11 xupz---------->>>>>
                this.tDateEditSt.Visible = false;
                this.ultraLabel2.Visible = false;
                this.tDateEditEd.Visible = false;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns["BeginningDate"].Hidden = false;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns["BeginningTime"].Hidden = false;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns["EndDate"].Hidden = false;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns["EndTime"].Hidden = false;
                // 表示幅設定
                this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Width = 40;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendCodeColumn.ColumnName].Width = 50;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.SendNameColumn.ColumnName].Width = 200;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseCodeColumn.ColumnName].Width = 50;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BaseNameColumn.ColumnName].Width = 200;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningDateColumn.ColumnName].Width = 120;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.BeginningTimeColumn.ColumnName].Width = 100;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndDateColumn.ColumnName].Width = 120;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns[this._extractionConditionDataTable.EndTimeColumn.ColumnName].Width = 100;
                // ----- ADD 2011/11/11 xupz----------<<<<<
            }
            // 伝票日付
            else
            {
                this.SetExtractCondDiv(this.tce_ExtractCondDiv.SelectedIndex.ToString());    // Save selected index into local.

                for (int i = 0; i < Condition_Grid.Rows.Count; i++)
                {
                    this.Condition_Grid.Rows[i].Cells["BeginningDate"].Value = time[0];
                    this.Condition_Grid.Rows[i].Cells["BeginningTime"].Value = MINVALUE;
                    this.Condition_Grid.Rows[i].Cells["EndDate"].Value = time[0];

                    // If geted time format is 0:00:00, then change it to 00:00:00
                    if (time[1].ToString().Length < 8)
                        time[1] = time[1].PadLeft(8, '0');
                    this.Condition_Grid.Rows[i].Cells["EndTime"].Value = time[1].ToString().Replace(":", "");   // Replace format from 00:00:00 to 000000.
                }
                // ----- ADD 2011/11/11 xupz---------->>>>>
                this.tDateEditSt.Visible = true;
                this.ultraLabel2.Visible = true;
                this.tDateEditEd.Visible = true;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns["BeginningDate"].Hidden = true;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns["BeginningDate"].Hidden = true;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns["BeginningTime"].Hidden = true;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns["EndDate"].Hidden = true;
                this.Condition_Grid.DisplayLayout.Bands[0].Columns["EndTime"].Hidden = true;
                // ----- ADD 2011/11/11 xupz----------<<<<<
            }
            //  Check the checkbox and quit edit mode.
            for (int i = 0; i < Condition_Grid.Rows.Count; i++)
            {
                this.Condition_Grid.Rows[i].Cells[this._extractionConditionDataTable.SendDestCondColumn.ColumnName].Value = true;   //  Check the checkbox
                //  quit edit mode.
                this.Condition_Grid.Rows[i].Activated = true;
            }
            this.Condition_Grid.Rows[0].Activated = true;   //  quit edit mode.
        }

        # region ■ 抽出条件区分保存 ADD dingjx #26228 抽出条件区分について ■
        /// <summary>
        /// 前次選択の抽出条件区分を取得
        /// </summary>
        /// <returns>抽出条件区分</returns>
        public string GetExtractCondDiv()
        {
            string div = "0";
            try
            {
                string fileName = Path.Combine(ConstantManagement_ClientDirectory.UISettings, UI_XML_NAME);

                if (UserSettingController.ExistUserSetting(fileName))
                {
                    if (_uiDataSet == null)
                    {
                        _uiDataSet = new DataSet();
                    }

                    _uiDataSet.ReadXml(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, fileName));
                    div = _uiDataSet.Tables["Div"].Rows[0][0].ToString();
                }
            }
            catch { }
            return div;
        }
        /// <summary>
        /// 選択した抽出条件区分をXMLファイルに保存
        /// </summary>
        /// <param name="selectedIndex">抽出条件区分</param>
        /// <returns>ステータス</returns>
        public int SetExtractCondDiv(string selectedIndex)
        {
            int status = 0;
            try
            {
                if (!string.IsNullOrEmpty(selectedIndex))
                {
                    string fileName = Path.Combine(ConstantManagement_ClientDirectory.UISettings, UI_XML_NAME);
                    fileName = Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, fileName);
                    if (_uiDataSet == null)
                    {
                        _uiDataSet = new DataSet();
                    }
                    if (_uiDataSet.Tables["Div"] == null)
                    {
                        DataTable dt = new DataTable("Div");
                        DataColumn col = new DataColumn("SelectedIndex", typeof(string));
                        dt.Columns.Add(col);
                        _uiDataSet.Tables.Add(dt);
                    }
                    _uiDataSet.Tables["Div"].Clear();
                    DataRow row = _uiDataSet.Tables["Div"].NewRow();
                    row[0] = selectedIndex;
                    _uiDataSet.Tables["Div"].Rows.Add(row);
                    _uiDataSet.WriteXml(fileName);
                }
            }
            catch
            {
                status = 1000;
            }
            return status;
        }

        # endregion ■ 抽出条件区分保存 ■
        //  ADD dingjx  2011/11/01  ------------------------<<<<<<

        // ----- ADD 2013/02/07 zhlj For Redmine#34588 ---------->>>>>
        # region ■ グリッド列スタイル設定処理 ■
        /// <summary>
        /// グリッド列スタイル設定処理
        /// </summary>
        /// <param name="searchCntDic">送信データDic</param>
        /// <param name="errSectionCodeList">送信失敗拠点一覧</param>
        /// <param name="mode">送信状態モード</param>
        /// <remarks>		
        /// <br>Note		: グリッド列スタイル設定処理を行う。</br>
        /// <br>            : 10900690-00 2013/3/13配信分の緊急対応</br>
        /// <br>            : Redmine#34588 拠点管理改良／送信確認画面の追加仕様の変更対応</br>
        /// <br>Programmer	: zhlj</br>	
        /// <br>Date		: 2013/02/07</br>
        /// </remarks>
        private void SearchResultDataGridCol(Dictionary<string, SearchCountWork> searchCntDic, ArrayList errSectionCodeList, int mode)
        {
            // 送信状態
            string strplus = string.Empty;
            if (mode == 1)
            {
                strplus = " 送信完了";
            }
            else if (mode == 2)
            {
                strplus = " 未送信";
            }
            UpdateResultDataSet.UpdateResultRow row = null;
            // 送信対象データをグリッドへ設定する
            for (int i = 0; i < this._sendDataList.Count; i++)
            {
                SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[i];
                row = _updateResultDataTable.NewUpdateResultRow();
                row.RowNo = i + 1;
                row.ExtractionData = secMngSndRcv.MasterName;
                row.ExtractionCount = string.Empty;
                foreach (string sectionCode in searchCntDic.Keys)
                {
                    SearchCountWork searchCountWork = searchCntDic[sectionCode];
                    switch (secMngSndRcv.FileId)
                    {
                        // 売上データ
                        case "SalesSlipRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.SalesSlipCount) + strplus;
                            if (searchCountWork.SalesSlipCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // 売上明細データ
                        case "SalesDetailRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.SalesDetailCount) + strplus;
                            if (searchCountWork.SalesDetailCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // 売上履歴データ
                        case "SalesHistoryRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.SalesHistoryCount) + strplus;
                            if (searchCountWork.SalesHistoryCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // 売上履歴明細データ
                        case "SalesHistDtlRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.SalesHistDtlCount) + strplus;
                            if (searchCountWork.SalesHistDtlCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // 入金データ
                        case "DepsitMainRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.DepsitMainCount) + strplus;
                            if (searchCountWork.DepsitMainCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // 入金明細データ
                        case "DepsitDtlRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.DepsitDtlCount) + strplus;
                            if (searchCountWork.DepsitDtlCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // 仕入データ
                        case "StockSlipRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.StockSlipCount) + strplus;
                            if (searchCountWork.StockSlipCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // 仕入明細データ
                        case "StockDetailRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.StockDetailCount) + strplus;
                            if (searchCountWork.StockDetailCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // 仕入履歴データ
                        case "StockSlipHistRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.StockSlipHistCount) + strplus;
                            if (searchCountWork.StockSlipHistCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // 仕入履歴明細データ
                        case "StockSlHistDtlRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.StockSlHistDtlCount) + strplus;
                            if (searchCountWork.StockSlHistDtlCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // 支払伝票マスタ
                        case "PaymentSlpRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.PaymentSlpCount) + strplus;
                            if (searchCountWork.PaymentSlpCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // 支払明細データ
                        case "PaymentDtlRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.PaymentDtlCount) + strplus;
                            if (searchCountWork.PaymentDtlCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // 受注マスタ
                        case "AcceptOdrRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.AcceptOdrCount) + strplus;
                            if (searchCountWork.AcceptOdrCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // 受注マスタ（車両）
                        case "AcceptOdrCarRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.AcceptOdrCarCount) + strplus;
                            if (searchCountWork.AcceptOdrCarCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // 在庫調整データ
                        case "StockAdjustRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.StockAdjustCount) + strplus;
                            if (searchCountWork.StockAdjustCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // 在庫調整明細データ
                        case "StockAdjustDtlRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.StockAdjustDtlCount) + strplus;
                            if (searchCountWork.StockAdjustDtlCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // 在庫移動データ
                        case "StockMoveRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.StockMoveCount) + strplus;
                            if (searchCountWork.StockMoveCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // 入金引当マスタ
                        case "DepositAlwRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.DepositAlwCount) + strplus;
                            if (searchCountWork.DepositAlwCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // 受取手形データ
                        case "RcvDraftDataRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.RcvDraftDataCount) + strplus;
                            if (searchCountWork.RcvDraftDataCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                        // 支払手形データ
                        case "PayDraftDataRF":
                            row[sectionCode] = this.IntConvert(searchCountWork.PayDraftDataCount) + strplus;
                            if (searchCountWork.PayDraftDataCount > 0)
                            {
                                this._isEmpty = false;
                            }
                            break;
                    }
                }

                foreach (string errSectionCode in errSectionCodeList)
                {
                    row[errSectionCode] = ERROR_BATU;
                }
                _updateResultDataTable.Rows.Add(row);
            }
        }
        # endregion ■ グリッド列スタイル設定処理 ■

        # region ■ ツールバー起動用フラグ ■
        /// <summary>
        /// ツールバー起動用フラグ
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ツールバー起動用処理を行う。</br>
        /// <br>            : 10900690-00 2013/3/13配信分の緊急対応</br>
        /// <br>            : Redmine#34588 拠点管理改良／送信確認画面の追加仕様の変更対応</br>
        /// <br>Programmer	: zhlj</br>	
        /// <br>Date		: 2013/02/07</br>
        /// </remarks>
        private void ToolbarOn()
        {
            this.tToolsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = true;
            this.tToolsManager_MainMenu.Tools["ButtonTool_Update"].SharedProps.Enabled = true;
            this.tToolsManager_MainMenu.Tools["ButtonTool_Get"].SharedProps.Enabled = true;
            this.tToolsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.Enabled = true;
        }
        # endregion ■ ツールバー起動用フラグ ■

        # region ■ ツールバー閉める用フラグ ■
        /// <summary>
        /// ツールバー閉める用フラグ
        /// </summary>
        /// <remarks>		
        /// <br>Note		: ツールバー閉める用処理を行う。</br>
        /// <br>            : 10900690-00 2013/3/13配信分の緊急対応</br>
        /// <br>            : Redmine#34588 拠点管理改良／送信確認画面の追加仕様の変更対応</br>
        /// <br>Programmer	: zhlj</br>	
        /// <br>Date		: 2013/02/07</br>
        /// </remarks>
        private void ToolbarOff()
        {
            this.tToolsManager_MainMenu.Tools["ButtonTool_Close"].SharedProps.Enabled = false;
            this.tToolsManager_MainMenu.Tools["ButtonTool_Update"].SharedProps.Enabled = false;
            this.tToolsManager_MainMenu.Tools["ButtonTool_Get"].SharedProps.Enabled = false;
            this.tToolsManager_MainMenu.Tools["ButtonTool_Clear"].SharedProps.Enabled = false;
        }
        # endregion ■ ツールバー閉める用フラグ ■
        // ----- ADD 2013/02/07 zhlj For Redmine#34588 ----------<<<<<

        #endregion  ■ Private Method ■
    }
}
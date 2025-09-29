//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 提供マスタ削除処理
// プログラム概要   : 提供データ重複するユーザー結合、セットマスタのレコードを削除する。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/06/18  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2009/07/10  修正内容 : ダイアログの追加
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 提供マスタ削除処理
    /// </summary>
    /// <remarks>
    /// Note       : 提供マスタ削除処理です。<br />
    /// Programmer : 譚洪<br />
    /// Date       : 2009.06.18<br />
    /// </remarks>
    public partial class PMKHN01200UA : Form
    {
        #region ■ Const Memebers ■
        // テーブル名称
        private const string DETAILS_TABLE = "OfferMstDelTable";
        private const string PROGRAM_ID = "PMKHN01200U";
        private const string MARK_MARU = "●";
        private const string MARK_EMPTY = "";
        // FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        private const string NUMBER_TITLE = "NO.";
        private const string OBJECT_GROUP_TITLE = "対象";
        private const string OBJECT_TITLE = "対象タイトル";
        private const string PROC_OBJECT_TITLE = "処理対象";
        private const string DEL_COUNT_TITLE = "削除件数";
        private const string PROC_RESULT_TITLE = "処理結果";
        private const string JOINPARTS_MST = "結合マスタ";
        private const string SETPARTS_MST = "セットマスタ";
        #endregion

        # region ■ private field ■
        private static readonly Color DISABLE_COLOR = Color.Gainsboro;
        private static readonly Color DISABLE_FONT_COLOR = Color.Black;
        private ControlScreenSkin _controlScreenSkin;
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _executeButton;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private OfferMstDelInputAcs _offerMstDelInputAcs;
        private DataTable detailsTable;
        #endregion

        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : コンストラクタ</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.06.18</br>
        /// </remarks>
        public PMKHN01200UA()
        {
            InitializeComponent();
            // 変数初期化
            this.detailsTable = new DataTable(DETAILS_TABLE);
            this._controlScreenSkin = new ControlScreenSkin();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._executeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Execute"];
            this._offerMstDelInputAcs = OfferMstDelInputAcs.GetInstance();
        }
        #endregion

        # region ■ 画面初期化後イベント ■
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ボタン初期設定処理です</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.20</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._executeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
        }

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセット列情報構築処理です</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.06.18</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            this.detailsTable.Columns.Add(NUMBER_TITLE, typeof(int));
            this.detailsTable.Columns.Add(OBJECT_TITLE, typeof(string));
            this.detailsTable.Columns.Add(PROC_OBJECT_TITLE, typeof(string));
            this.detailsTable.Columns.Add(DEL_COUNT_TITLE, typeof(int));
            this.detailsTable.Columns.Add(PROC_RESULT_TITLE, typeof(string));

            this.uGrid_Details.DataSource = detailsTable;
        }
        #endregion

        # region ■ フォームロード ■
        /// <summary>
        /// 画面の処理化処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>   
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: 画面の処理化を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.06.18</br>
        /// </remarks>
        private void PMKHN01200UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            // ボタン初期設定処理
            this.ButtonInitialSetting();
            // データセット列情報構築処理
            DataSetColumnConstruction();
            // グリッド初期設定処理
            this.InitialSettingGridCol();
            // グリッドデータ設定処理
            this.InitialDataGridCol();

            this.uGrid_Details.Rows[0].Cells[1].Activated = true;
        }
        #endregion

        #region ■ グリッドメッソド関連 ■
        /// <summary>
        /// 提供マスタ削除処理のグリッド設定処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 提供マスタ削除処理のグリッド設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.06.18</br>
        /// </remarks>
        private void InitialDataGridCol()
        {
            // 結合マスタ
            DataRow dataRow = this.detailsTable.NewRow();
            dataRow[NUMBER_TITLE] = 1;
            dataRow[OBJECT_TITLE] = MARK_MARU;
            dataRow[PROC_OBJECT_TITLE] = JOINPARTS_MST;
            dataRow[DEL_COUNT_TITLE] = 0;
            dataRow[PROC_RESULT_TITLE] = string.Empty;
            this.detailsTable.Rows.Add(dataRow);
            // セットマスタ
            dataRow = this.detailsTable.NewRow();
            dataRow[NUMBER_TITLE] = 2;
            dataRow[OBJECT_TITLE] = MARK_MARU;
            dataRow[PROC_OBJECT_TITLE] = SETPARTS_MST;
            dataRow[DEL_COUNT_TITLE] = 0;
            dataRow[PROC_RESULT_TITLE] = string.Empty;
            this.detailsTable.Rows.Add(dataRow);
        }

        /// <summary>
        /// 提供マスタ削除処理のグリッド初期設定処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 提供マスタ削除処理のグリッド初期設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.06.18</br>
        /// </remarks>
        private void InitialSettingGridCol()
        {
            this.uGrid_Details.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if (editBand == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                //「No列」以外の全てのセルのDiabledColorを設定する。
                if (!OBJECT_TITLE.Equals(col.Key))
                {
                    col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
                }
            }

            this.uGrid_Details.DisplayLayout.Bands[0].ColHeadersVisible = false;

            // Filter設定
            editBand.Columns[NUMBER_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            editBand.Columns[OBJECT_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            editBand.Columns[PROC_OBJECT_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            editBand.Columns[DEL_COUNT_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            editBand.Columns[PROC_RESULT_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            // 表示幅設定
            editBand.Columns[NUMBER_TITLE].Width = 15;
            editBand.Columns[OBJECT_TITLE].Width = 18;
            editBand.Columns[PROC_OBJECT_TITLE].Width = 120;
            editBand.Columns[DEL_COUNT_TITLE].Width = 50;
            editBand.Columns[PROC_RESULT_TITLE].Width = 100;

            // 固定列設定
            editBand.Columns[NUMBER_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            editBand.Columns[NUMBER_TITLE].Header.Fixed = false;
            editBand.Columns[OBJECT_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            editBand.Columns[OBJECT_TITLE].Header.Fixed = false;
            editBand.Columns[PROC_OBJECT_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            editBand.Columns[PROC_OBJECT_TITLE].Header.Fixed = false;
            editBand.Columns[DEL_COUNT_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            editBand.Columns[DEL_COUNT_TITLE].Header.Fixed = false;
            editBand.Columns[PROC_RESULT_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            editBand.Columns[PROC_RESULT_TITLE].Header.Fixed = false;
            // CellAppearance設定
            editBand.Columns[NUMBER_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[OBJECT_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[PROC_OBJECT_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[DEL_COUNT_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[PROC_RESULT_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // 入力許可設定
            editBand.Columns[NUMBER_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            editBand.Columns[OBJECT_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            editBand.Columns[PROC_OBJECT_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            editBand.Columns[DEL_COUNT_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            editBand.Columns[PROC_RESULT_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            // フォーマット
            string format = "#,##0;-#,##0;'0'";
            editBand.Columns[DEL_COUNT_TITLE].Format = format;

            // Style設定
            editBand.Columns[NUMBER_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            editBand.Columns[OBJECT_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            editBand.Columns[PROC_OBJECT_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            editBand.Columns[DEL_COUNT_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            editBand.Columns[PROC_RESULT_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            editBand.Columns[NUMBER_TITLE].TabStop = false;
            editBand.Columns[PROC_OBJECT_TITLE].TabStop = false;
            editBand.Columns[DEL_COUNT_TITLE].TabStop = false;
            editBand.Columns[PROC_RESULT_TITLE].TabStop = false;

            editBand.Columns[NUMBER_TITLE].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            editBand.Columns[NUMBER_TITLE].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            editBand.Columns[NUMBER_TITLE].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            editBand.Columns[NUMBER_TITLE].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            editBand.Columns[NUMBER_TITLE].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            editBand.Columns[NUMBER_TITLE].CellAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
        }

        /// <summary>
        /// 提供マスタ削除処理のグリッド列初期head設定処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 提供マスタ削除処理のグリッド列初期head設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.06.18</br>
        /// </remarks>
        private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // グリッド列初期head設定処理
            this.SetGridHead();
        }

        /// <summary>
        /// グリッド列初期head設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面初期化の時、グリッド列初期設定を行います。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.06.18</br>
        /// </remarks>
        private void SetGridHead()
        {
            // 対象
            Infragistics.Win.UltraWinGrid.UltraGridGroup ugg = null;
            ugg = this.uGrid_Details.DisplayLayout.Bands[0].Groups.Add(OBJECT_GROUP_TITLE, OBJECT_GROUP_TITLE);
            ugg.Columns.Add(this.uGrid_Details.DisplayLayout.Bands[0].Columns[NUMBER_TITLE]);
            ugg.Columns.Add(this.uGrid_Details.DisplayLayout.Bands[0].Columns[OBJECT_TITLE]);
            this.uGrid_Details.DisplayLayout.Bands[0].Groups[OBJECT_GROUP_TITLE].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

            // 処理対象
            ugg = this.uGrid_Details.DisplayLayout.Bands[0].Groups.Add(PROC_OBJECT_TITLE, PROC_OBJECT_TITLE);
            ugg.Columns.Add(this.uGrid_Details.DisplayLayout.Bands[0].Columns[PROC_OBJECT_TITLE]);
            this.uGrid_Details.DisplayLayout.Bands[0].Groups[PROC_OBJECT_TITLE].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            // 削除件数
            ugg = this.uGrid_Details.DisplayLayout.Bands[0].Groups.Add(DEL_COUNT_TITLE, DEL_COUNT_TITLE);
            ugg.Columns.Add(this.uGrid_Details.DisplayLayout.Bands[0].Columns[DEL_COUNT_TITLE]);
            this.uGrid_Details.DisplayLayout.Bands[0].Groups[DEL_COUNT_TITLE].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            // 処理結果
            ugg = this.uGrid_Details.DisplayLayout.Bands[0].Groups.Add(PROC_RESULT_TITLE, PROC_RESULT_TITLE);
            ugg.Columns.Add(this.uGrid_Details.DisplayLayout.Bands[0].Columns[PROC_RESULT_TITLE]);
            this.uGrid_Details.DisplayLayout.Bands[0].Groups[PROC_RESULT_TITLE].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
        }


        /// <summary>
        /// 提供マスタ削除グリッドキードンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		:提供マスタ削除グリッドキードンイベントを行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.06.18</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null && this.uGrid_Details.ActiveCell == this.uGrid_Details.ActiveRow.Cells[OBJECT_TITLE])
            {
                if (e.KeyCode == Keys.Enter)
                {
                    UltraGridCell cell = this.uGrid_Details.ActiveRow.Cells[OBJECT_TITLE];

                    string val = string.Empty;

                    if (MARK_MARU.Equals(cell.Value))
                    {
                        val = MARK_EMPTY;
                    }
                    else
                    {
                        val = MARK_MARU;
                    }

                    cell.Value = val;
                }
            }

            // Shiftキーの場合
            if (e.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.Tab:
                        {
                            if (this.uGrid_Details.ActiveRow.Index == 0)
                            {
                                this.uGrid_Details.ActiveCell.Selected = false;
                                this.uGrid_Details.ActiveCell.Activated = false;

                                this.timer_SetFocus2.Enabled = true;
                            }
                            break;
                        }
                    //default:
                    //    break;
                }
            } else if (e.KeyCode == Keys.Tab)
            {
                if (this.uGrid_Details.ActiveRow.Index == 1)
                {
                    this.uGrid_Details.ActiveCell.Selected = false;
                    this.uGrid_Details.ActiveCell.Activated = false;

                    this.timer_SetFocus.Enabled = true;

                }
            }
        }

        /// <summary>
        /// マウスダブルクリック判断セルイベント
        /// </summary>
        /// <param name="element">対象オブジェクト</param>
        /// <remarks>		
        /// <br>Note		: マウスダブルクリック判断セルイベントを行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.06.18</br>
        /// </remarks>
        UltraGridCell PrepareCell(UIElement element)
        {
            CellUIElement cellElement = element as CellUIElement;
            if (cellElement == null) return null;
            UltraGridCell cell = cellElement.GetContext(typeof(UltraGridCell)) as UltraGridCell;
            return cell;
        }

        /// <summary>
        /// 提供マスタ削除グリッドセルイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		:提供マスタ削除グリッドセルイベントを行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.06.18</br>
        /// </remarks>
        private void uGrid_Details_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if (NUMBER_TITLE.Equals(e.Cell.Column.Key))
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 提供マスタ削除グリッドマウスダブルクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		:提供マスタ削除グリッドマウスダブルクリックイベントを行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.06.18</br>
        /// </remarks>
        private void uGrid_Details_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            UIElement mainElement = ((IUltraControlElement)uGrid_Details).MainUIElement;
            UltraGridCell cell = null;

            UIElement element = mainElement.ElementFromPoint(new Point(e.X, e.Y));
            while (element != null && cell == null)
            {
                cell = PrepareCell(element);

                if (cell == null)
                    element = element.Parent;
            }
            if (cell == null)
                return;


            if (this.uGrid_Details.ActiveCell != null)
            {
                if (this.uGrid_Details.ActiveCell == this.uGrid_Details.ActiveRow.Cells[OBJECT_TITLE])
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        UltraGridCell ultraGridCell = this.uGrid_Details.ActiveRow.Cells[OBJECT_TITLE];

                        string val = string.Empty;

                        if (MARK_MARU.Equals(ultraGridCell.Value))
                        {
                            val = MARK_EMPTY;
                        }
                        else
                        {
                            val = MARK_MARU;
                        }

                        ultraGridCell.Value = val;
                    }
                }
            }
        }
        /// <summary>
        /// セルのフォーカスイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: セルのフォーカスイベント処理発生します。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009.06.20</br>
        /// </remarks>
        private void timer_SetFocus_Tick(object sender, EventArgs e)
        {
            this.uGrid_Details.Rows[0].Activated = true;
            this.uGrid_Details.Rows[0].Cells[1].Activated = true;
            this.timer_SetFocus.Enabled = false;
        }

        /// <summary>
        /// セルのフォーカスイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note		: セルのフォーカスイベント処理発生します。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009.06.20</br>
        /// </remarks>
        private void timer_SetFocus2_Tick(object sender, EventArgs e)
        {
            this.uGrid_Details.Rows[1].Activated = true;
            this.uGrid_Details.Rows[1].Cells[1].Activated = true;
            this.timer_SetFocus2.Enabled = false;
        }
        #endregion

        #region ■ 提供マスタ削除処理メッソド関連 ■
        /// <summary>
        /// ツールバーボタンクリックイベント処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>		
        /// <br>Note		: なし。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.06.18</br>
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
                case "ButtonTool_Execute":
                    {
                        // 実行処理
                        bool inputCheck = false;

                        inputCheck = this.ExecuteBeforeCheck();

                        if (inputCheck)
                        {
                            this.ExecuteProcess();
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// 提供マスタ削除処理の入力チェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 提供マスタ削除処理の入力チェック処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009.06.18</br>
        /// </remarks>
        /// <returns>ステータス</returns>
        private bool ExecuteBeforeCheck()
        {
            bool status = true;

            string errMessage = "";

            // 画面データチェック処理
            if (!this.ScreenInputCheck(ref errMessage))
            {

                DialogResult dialogResult = TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    PROGRAM_ID,
                    "",
                    "",
                    "",
                    errMessage,
                    0,
                    null,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.OK)
                {
                    this.detailsTable.Clear();
                    DataRow dataRow;
                    dataRow = this.detailsTable.NewRow();
                    dataRow[NUMBER_TITLE] = 1;
                    dataRow[OBJECT_TITLE] = string.Empty;
                    dataRow[PROC_OBJECT_TITLE] = JOINPARTS_MST;
                    dataRow[DEL_COUNT_TITLE] = 0;
                    dataRow[PROC_RESULT_TITLE] = string.Empty;
                    this.detailsTable.Rows.Add(dataRow);

                    dataRow = this.detailsTable.NewRow();
                    dataRow[NUMBER_TITLE] = 2;
                    dataRow[OBJECT_TITLE] = string.Empty;
                    dataRow[PROC_OBJECT_TITLE] = SETPARTS_MST;
                    dataRow[DEL_COUNT_TITLE] = 0;
                    dataRow[PROC_RESULT_TITLE] = string.Empty;
                    this.detailsTable.Rows.Add(dataRow);

                    //this.uGrid_Details.ActiveCell.Selected = false;
                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[0].Cells[OBJECT_TITLE];
                }

                status = false;
                return status;
            }
            return status;
        }

        /// <summary>
        /// 提供マスタ削除のチェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note		: 提供マスタ削除のチェック処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>
        /// <br>Date		: 2009.06.18</br>
        /// </remarks>
        /// <returns>True:OK, False:NG</returns>
        private bool ScreenInputCheck(ref string errMessage)
        {
            bool status = true;

            const string ct_NoInput = "削除対象が選択されていません。";

            if (this.uGrid_Details.Rows[0].Cells[OBJECT_TITLE].Value.ToString().Trim() == string.Empty
                && this.uGrid_Details.Rows[1].Cells[OBJECT_TITLE].Value.ToString().Trim() == string.Empty)
            {
                errMessage = ct_NoInput;
                status = false;

                return status;
            }
            return status;
        }

        /// <summary>
        /// 提供マスタ削除処理
        /// </summary>
        /// <remarks>		
        /// <br>Note		:提供マスタ削除処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.06.18</br>
        /// </remarks>
        private void ExecuteProcess()
        {
            
            DataRow dataRow;
            // 結合マスタ削除件数
            int joinCount = 0;
            // セットマスタ削除件数
            int setCount = 0;
            int joinStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            int setStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // 表示文字を設定
            form.Title = "提供マスタ削除処理";
            form.Message = "現在、削除処理中です。";

            this.Cursor = Cursors.WaitCursor;
            // ダイアログ表示
            form.Show(); 

            string joinFlag = this.uGrid_Details.Rows[0].Cells[OBJECT_TITLE].Value.ToString();
            string setFlag = this.uGrid_Details.Rows[1].Cells[OBJECT_TITLE].Value.ToString();

            this.detailsTable.Clear();
            if (MARK_MARU.Equals(joinFlag) && MARK_EMPTY.Equals(setFlag))
            {
                dataRow = this.detailsTable.NewRow();
                dataRow[NUMBER_TITLE] = 1;
                dataRow[OBJECT_TITLE] = MARK_MARU;
                dataRow[PROC_OBJECT_TITLE] = JOINPARTS_MST;
                dataRow[DEL_COUNT_TITLE] = 0;
                dataRow[PROC_RESULT_TITLE] = "只今、処理中です．．．";
                this.detailsTable.Rows.Add(dataRow);

                dataRow = this.detailsTable.NewRow();
                dataRow[NUMBER_TITLE] = 2;
                dataRow[OBJECT_TITLE] = string.Empty;
                dataRow[PROC_OBJECT_TITLE] = SETPARTS_MST;
                dataRow[DEL_COUNT_TITLE] = 0;
                dataRow[PROC_RESULT_TITLE] = string.Empty;
                this.detailsTable.Rows.Add(dataRow);

                this.uGrid_Details.Refresh();

                // 結合マスタ削除処理
                joinStatus = _offerMstDelInputAcs.DeleteJoinProc(_enterpriseCode, out joinCount);

                this.detailsTable.Clear();

                dataRow = this.detailsTable.NewRow();
                dataRow[NUMBER_TITLE] = 1;
                dataRow[OBJECT_TITLE] = MARK_MARU;
                dataRow[PROC_OBJECT_TITLE] = JOINPARTS_MST;

                if (joinStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    || joinStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    dataRow[DEL_COUNT_TITLE] = joinCount;
                    dataRow[PROC_RESULT_TITLE] = "正常終了";
                }
                else
                {
                    dataRow[DEL_COUNT_TITLE] = joinCount;
                    dataRow[PROC_RESULT_TITLE] = "更新処理に失敗しました。";
                }

                this.detailsTable.Rows.Add(dataRow);

                dataRow = this.detailsTable.NewRow();
                dataRow[NUMBER_TITLE] = 2;
                dataRow[OBJECT_TITLE] = string.Empty;
                dataRow[PROC_OBJECT_TITLE] = SETPARTS_MST;
                dataRow[DEL_COUNT_TITLE] = 0;
                dataRow[PROC_RESULT_TITLE] = string.Empty;
                this.detailsTable.Rows.Add(dataRow);
            }
            else if (MARK_EMPTY.Equals(joinFlag) && MARK_MARU.Equals(setFlag))
            {
                dataRow = this.detailsTable.NewRow();
                dataRow[NUMBER_TITLE] = 1;
                dataRow[OBJECT_TITLE] = string.Empty;
                dataRow[PROC_OBJECT_TITLE] = JOINPARTS_MST;
                dataRow[DEL_COUNT_TITLE] = 0;
                dataRow[PROC_RESULT_TITLE] = string.Empty;
                this.detailsTable.Rows.Add(dataRow);

                dataRow = this.detailsTable.NewRow();
                dataRow[NUMBER_TITLE] = 2;
                dataRow[OBJECT_TITLE] = MARK_MARU;
                dataRow[PROC_OBJECT_TITLE] = SETPARTS_MST;
                dataRow[DEL_COUNT_TITLE] = 0;
                dataRow[PROC_RESULT_TITLE] = "只今、処理中です．．．";
                this.detailsTable.Rows.Add(dataRow);

                this.uGrid_Details.Refresh();

                // セットマスタ削除処理
                setStatus = _offerMstDelInputAcs.DeleteSetProc(_enterpriseCode, out setCount);

                this.detailsTable.Clear();

                dataRow = this.detailsTable.NewRow();
                dataRow[NUMBER_TITLE] = 1;
                dataRow[OBJECT_TITLE] = string.Empty;
                dataRow[PROC_OBJECT_TITLE] = JOINPARTS_MST;
                dataRow[DEL_COUNT_TITLE] = 0;
                dataRow[PROC_RESULT_TITLE] = string.Empty;
                this.detailsTable.Rows.Add(dataRow);


                dataRow = this.detailsTable.NewRow();
                dataRow[NUMBER_TITLE] = 2;
                dataRow[OBJECT_TITLE] = MARK_MARU;
                dataRow[PROC_OBJECT_TITLE] = SETPARTS_MST;

                if (setStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    || setStatus == (int)ConstantManagement.DB_Status.ctDB_EOF
                    || setStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    dataRow[DEL_COUNT_TITLE] = setCount;
                    dataRow[PROC_RESULT_TITLE] = "正常終了";
                }
                else
                {
                    dataRow[DEL_COUNT_TITLE] = setCount;
                    dataRow[PROC_RESULT_TITLE] = "更新処理に失敗しました。";
                }
                this.detailsTable.Rows.Add(dataRow);
            }
            else
            {
                dataRow = this.detailsTable.NewRow();
                dataRow[NUMBER_TITLE] = 1;
                dataRow[OBJECT_TITLE] = MARK_MARU;
                dataRow[PROC_OBJECT_TITLE] = JOINPARTS_MST;
                dataRow[DEL_COUNT_TITLE] = 0;
                dataRow[PROC_RESULT_TITLE] = "只今、処理中です．．．";
                this.detailsTable.Rows.Add(dataRow);

                dataRow = this.detailsTable.NewRow();
                dataRow[NUMBER_TITLE] = 2;
                dataRow[OBJECT_TITLE] = MARK_MARU;
                dataRow[PROC_OBJECT_TITLE] = SETPARTS_MST;
                dataRow[DEL_COUNT_TITLE] = 0;
                dataRow[PROC_RESULT_TITLE] = "只今、処理中です．．．";
                this.detailsTable.Rows.Add(dataRow);

                this.uGrid_Details.Refresh();

                // 結合マスタ削除処理
                joinStatus = _offerMstDelInputAcs.DeleteJoinProc(_enterpriseCode, out joinCount);
                // セットマスタ削除処理
                setStatus = _offerMstDelInputAcs.DeleteSetProc(_enterpriseCode, out setCount);


                this.detailsTable.Clear();

                dataRow = this.detailsTable.NewRow();
                dataRow[NUMBER_TITLE] = 1;
                dataRow[OBJECT_TITLE] = MARK_MARU;
                dataRow[PROC_OBJECT_TITLE] = JOINPARTS_MST;

                if (joinStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    || joinStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    dataRow[DEL_COUNT_TITLE] = joinCount;
                    dataRow[PROC_RESULT_TITLE] = "正常終了";
                }
                else
                {
                    dataRow[DEL_COUNT_TITLE] = joinCount;
                    dataRow[PROC_RESULT_TITLE] = "更新処理に失敗しました。";
                }

                this.detailsTable.Rows.Add(dataRow);

                dataRow = this.detailsTable.NewRow();
                dataRow[NUMBER_TITLE] = 2;
                dataRow[OBJECT_TITLE] = MARK_MARU;
                dataRow[PROC_OBJECT_TITLE] = SETPARTS_MST;

                if (setStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    || setStatus == (int)ConstantManagement.DB_Status.ctDB_EOF
                    || setStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    dataRow[DEL_COUNT_TITLE] = setCount;
                    dataRow[PROC_RESULT_TITLE] = "正常終了";
                }
                else
                {
                    dataRow[DEL_COUNT_TITLE] = setCount;
                    dataRow[PROC_RESULT_TITLE] = "更新処理に失敗しました。";
                }
                this.detailsTable.Rows.Add(dataRow);
            }
            // ダイアログを閉じる
            form.Close();

            this.uGrid_Details.Rows[0].Cells[1].Activated = true;
            this.Cursor = Cursors.Default;
        }
        #endregion
    }
}
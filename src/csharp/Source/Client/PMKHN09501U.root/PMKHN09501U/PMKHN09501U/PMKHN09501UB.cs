//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 返品不可設定
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 返品不可設定明細コントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 返品不可設定明細を行うコントロールクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.04.20</br>
    /// </remarks>
    public partial class PMKHN09501UB : UserControl
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constroctors
        /// <summary>
        /// 返品不可設定明細入力コントロールクラス デフォルトコンストラクタ
        /// </summary>
        public PMKHN09501UB(PMKHN09501UA parentForm)
        {
            InitializeComponent();
            this._dataSet = new GoodsNotReturnDataSet();
            this._goodsNotReturnAcs = GoodsNotReturnAcs.GetInstance();
            this._goodsNotReturnDetailDataTable = this._goodsNotReturnAcs.GoodsNotReturnDetailDataTable;
        }
        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region ■Private Members

        private delegate void settingHandler(int row);

        /// <summary>デフォルト行の外観設定</summary>
        Infragistics.Win.Appearance _defRowAppearance = new Infragistics.Win.Appearance();

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        private GoodsNotReturnDataSet _dataSet;
        private GoodsNotReturnDataSet.GoodsNotReturnDetailDataTable _goodsNotReturnDetailDataTable;
        private GoodsNotReturnAcs _goodsNotReturnAcs;
        private static readonly Color DISABLE_COLOR = Color.Gainsboro;
        private static readonly Color DISABLE_FONT_COLOR = Color.Black;
        private static readonly Color READONLY_COLOR = Color.WhiteSmoke;
        private static readonly Color ROWSTATUS_COPY_COLOR = Color.Pink;
        private static readonly Color ROWSTATUS_CUT_COLOR = Color.Gray;
        private static readonly Color REDUCTION_FONT_COLOR = Color.Green;
        private static readonly Color READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
        private static readonly Color ALLWAYS_CELL_COLOR = Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
        // 選択グリッド行BackColor
        private static readonly Color SELECTED_BACKCOLOR = Color.FromArgb(216, 235, 253);
        private static readonly Color SELECTED_BACKCOLOR2 = Color.FromArgb(101, 144, 218);

        double limitReturnNo = 0;
        double shipmentNo = 0;
        double returnNo = 0;
        #endregion

        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        # region ■Event

        /// <summary>
        /// フォーカスの変化
        /// </summary>
        /// <remarks>
        /// <br>Note       : Gridの焦点が移動する時、フォーカスの変化を行います。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.01</br> 
        /// </remarks>
        internal event EventHandler GridKeyUpTopRow;

        # endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■Private Methods
        /// <summary>
        /// ロードイベント                                            
        /// </summary>
        /// <param name="sender">イベントソース</param>                            
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 画面がロード時に発生します。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.20</br> 
        /// </remarks>
        private void PMKHN09501UB_Load(object sender, EventArgs e)
        {
            this.uGrid_Details.DataSource = this._goodsNotReturnDetailDataTable;
            // グリッドキーマッピング設定処理
            this.MakeKeyMappingForGrid(this.uGrid_Details);
        }

        /// <summary>
        /// 数値入力チェック処理
        /// </summary>
        /// <param name="key">入力されたキー値</param>
        /// <param name="prevVal">入力値</param>
        /// <param name="selstart">入力始値</param>
        /// <param name="sellength">入力値長度</param>
        /// <returns>true=入力可,false=入力不可</returns>
        /// <remarks>						
        /// <br>Note		: 数値入力チェック処理を行います。</br>				
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.26</br>
        /// </remarks>
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
            if (_strResult.Length > 8)
            {
                return false;
            }

            return true;
        }

        /// <summary>		
        /// Enterキーの処理		
        /// </summary>		
        /// <param name="activeCell">選択セル</param>		
        /// <param name="mode">モード</param>		
        /// <remarks>		
        /// <br>Note		: Enterキーをクッリクする時、処理を行います。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2008.11.26</br>
        /// </remarks>		
        private void EnterNextEditableCell(Infragistics.Win.UltraWinGrid.UltraGridCell activeCell, int mode)
        {
            int curRowIndex = activeCell.Row.Index;
            int curColIndex = activeCell.Column.Index;
            int rowCount = this.uGrid_Details.Rows.Count;
            int colCount = this.uGrid_Details.Rows[curRowIndex].Cells.Count;
            switch (mode)
            {
                case -1:
                    {
                        bool found = false;
                        for (int i = curRowIndex; i >= 0; i--)
                        {
                            int j = colCount - 1;
                            if (i == curRowIndex && curColIndex > 0)
                            {
                                j = curColIndex - 1;
                            }
                            Infragistics.Win.UltraWinGrid.UltraGridCell cell;
                            for (; j >= 0; j--)
                            {
                                cell = this.uGrid_Details.Rows[i].Cells[j];
                                if (cell.Activation == Activation.AllowEdit && cell.Column.CellActivation == Activation.AllowEdit
                                    && cell.CanEnterEditMode && !cell.Hidden && !cell.Column.Hidden)
                                {
                                    cell.Activated = true;
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    found = true;
                                    break;
                                }
                            }
                            if (found)
                            {
                                break;
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        bool found = false;
                        for (int i = curRowIndex; i < rowCount; i++)
                        {
                            int j = 0;
                            if (i == curRowIndex)
                            {
                                j = curColIndex + 1;
                            }
                            Infragistics.Win.UltraWinGrid.UltraGridCell cell;
                            for (; j < colCount; j++)
                            {
                                cell = this.uGrid_Details.Rows[i].Cells[j];
                                if (cell.Activation == Activation.AllowEdit && cell.Column.CellActivation == Activation.AllowEdit
                                    && cell.CanEnterEditMode && !cell.Hidden && !cell.Column.Hidden)
                                {
                                    cell.Activated = true;
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    found = true;
                                    break;
                                }
                            }
                            if (found)
                            {
                                break;
                            }
                        }
                        break;
                    }
            }
        }


        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>						
        /// <br>Note		: フォームロードイベントを行います。</br>				
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.26</br>
        /// </remarks>	
        private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.InitialSettingGridCol();
        }

        /// <summary>
        /// 返品不可設定明細クリア処理
        /// </summary>
        internal void Clear()
        {
            // 返品不可設定明細クリア処理
            this._goodsNotReturnDetailDataTable.Rows.Clear();
        }

        /// <summary>
        /// グリッドセロイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>						
        /// <br>Note		: グリッドセロイベントを行います。</br>				
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.26</br>
        /// </remarks>	
        private void uGrid_Details_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (e.Cell == null) return;
            int rowIndex = e.Cell.Row.Index;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;

            // ActiveCellが開始時間の場合
            if (cell.Column.Key == this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName)
            {
                string limitNo = cell.Value.ToString().Trim();
                // チェック処理
                if (!string.IsNullOrEmpty(limitNo))
                {
                    bool inputFlg = true;
                    for (int i = 0; i < limitNo.Length; i++)
                    {
                        if (!char.IsNumber(limitNo, i))
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
                           "返品上限数が数字を入力して下さい。",
                           -1,
                           MessageBoxButtons.OK);

                           return;
                    }
                }
            }
        }

        /// <summary>						
        /// グリッドキー設定処理						
        /// </summary>						
        /// <param name="sender">設定対象のグリッド</param>		
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>						
        /// <br>Note		: グリッドキー設定処理を行います。</br>				
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.26</br>
        /// </remarks>	
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
            int rowIndex = cell.Row.Index;

            // ActiveCellが数量の場合
            if (cell.Column.Key == this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName)
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

        # endregion

        // ===================================================================================== //
        // 各コントロールイベント処理
        // ===================================================================================== //
        # region ◆ Control Event Methods
        /// <summary>						
        /// グリッドキーマッピング設定処理						
        /// </summary>						
        /// <param name="grid">設定対象のグリッド</param>						
        /// <remarks>						
        /// <br>Note		: グリッドキーにより、マッピング設定処理を行います。</br>				
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.26</br>
        /// </remarks>		
        private void MakeKeyMappingForGrid(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            Infragistics.Win.UltraWinGrid.GridKeyActionMapping enterMap;
            //----- ↑キー		
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ↑キー (最上段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ↓キー (最下段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowLast | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ↓キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- 前頁キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Prior,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- 次頁キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Next,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);
        }

        /// <summary>
        /// グリッド列初期設定処理
        /// </summary>
        /// <remarks>						
        /// <br>Note		: グリッド列初期設定処理を行います。</br>				
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.26</br>
        /// </remarks>
        private void InitialSettingGridCol()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if (editBand == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // 全ての列をいったん非表示にする。
                if (col.Key == this._goodsNotReturnDetailDataTable.UpdateTimeColumn.ColumnName
                    || col.Key == this._goodsNotReturnDetailDataTable.AcptAnOdrStatusColumn.ColumnName
                    || col.Key == this._goodsNotReturnDetailDataTable.SalesSlipDtlNumColumn.ColumnName)
                {
                    col.Hidden = true;
                }

                //「No列」以外の全てのセルのDiabledColorを設定する。
                if (col.Key != this._goodsNotReturnDetailDataTable.RowNoColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
                }
            }

            // 表示幅設定
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.RowNoColumn.ColumnName].Width = 40;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ProductNoColumn.ColumnName].Width = 100;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.GoodsNameColumn.ColumnName].Width = 100;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ManufacturerColumn.ColumnName].Width = 100;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ShipmentNoColumn.ColumnName].Width = 100;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ReturnNoColumn.ColumnName].Width = 100;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName].Width = 100;

            // 固定列設定
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.RowNoColumn.ColumnName].Header.Fixed = true;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ProductNoColumn.ColumnName].Header.Fixed = true;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.GoodsNameColumn.ColumnName].Header.Fixed = true;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ManufacturerColumn.ColumnName].Header.Fixed = true;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ShipmentNoColumn.ColumnName].Header.Fixed = true;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ReturnNoColumn.ColumnName].Header.Fixed = true;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName].Header.Fixed = true;

            // CellAppearance設定
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ProductNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ManufacturerColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ShipmentNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ReturnNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // 入力許可設定
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ProductNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.GoodsNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ManufacturerColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ShipmentNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ReturnNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

            // フォーマット
            string format = "#,##0;-#,##0;'0'";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName].Format = format;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ReturnNoColumn.ColumnName].Format = format;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ShipmentNoColumn.ColumnName].Format = format;
            // Style設定
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ProductNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.GoodsNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ManufacturerColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ShipmentNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ReturnNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
        }

        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// <br>Note       : 次入力可能セル移動を処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.05.20</br>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            this.uGrid_Details.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_Details.ActiveCell != null))
            {
                if ((!this.uGrid_Details.ActiveCell.Column.Hidden) &&
                    (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }

            while (!moved)
            {
                performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

                if (performActionResult)
                {
                    if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
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
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            this.uGrid_Details.ResumeLayout();
            return performActionResult;
        }

        /// <summary>										
        /// グリッドキーダウンイベント										
        /// </summary>										
        /// <param name="sender">対象オブジェクト</param>										
        /// <param name="e">イベントパラメータクラス</param>										
        /// <remarks>										
        /// <br>Note		: グリッドキーダウン時、処理を行います。</br>								
        /// <br>Programmer	: 譚洪</br>									
        /// <br>Date		: 2009.05.26</br>								
        /// </remarks>										
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {										
            if (this.uGrid_Details.ActiveCell != null)										
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
                // Shiftキーの場合
                if (e.Shift)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                            {
                                this.uGrid_Details.ActiveCell = null;
                                this.uGrid_Details.ActiveRow = cell.Row;
                                this.uGrid_Details.Selected.Rows.Clear();
                                this.uGrid_Details.Selected.Rows.Add(cell.Row);
                                break;
                            }
                        case Keys.Up:
                            {
                                this.uGrid_Details.ActiveCell = null;
                                this.uGrid_Details.ActiveRow = cell.Row;
                                this.uGrid_Details.Selected.Rows.Clear();
                                this.uGrid_Details.Selected.Rows.Add(cell.Row);
                                break;
                            }
                        case Keys.Home:
                            {
                                if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.IsInEditMode))
                                {
                                    // 編集モードの場合はなにもしない
                                }
                                else
                                {
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid);
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.IsInEditMode))
                                {
                                    // 編集モードの場合はなにもしない
                                }
                                else
                                {
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInGrid);
                                }
                                break;
                            }
                        case Keys.Enter:
                            {
                                bool isMove = MoveNextAllowEditCell(false);
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
                                // ポップアップメニューツールをポップアップ処理。
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
                        switch (this.uGrid_Details.ActiveCell.StyleResolved)
                        {
                            // テキストボックス・テキストボックス(ボタン付)
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ←キー
                                        case Keys.Left:
                                            if (this.uGrid_Details.ActiveCell.SelStart == 0)
                                            {
                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // →キー
                                        case Keys.Right:
                                            if (this.uGrid_Details.ActiveCell.SelStart >= this.uGrid_Details.ActiveCell.Text.Length)
                                            {
                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        case Keys.Up:
                                            // 売上伝票番号グリッド
                                            //if (MoveNextAllowEditCell(true))
                                            //{
                                            //    //e.Handled = true;
                                            //}
                                            //else
                                            //{
                                            //    //e.NextCtrl = this.tce_SendAndReceKubun;
                                            //    this.uGrid_Details.Rows[0].Cells[6].Activate();
                                            //    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                            //}
                                            break;
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
                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // →キー
                                        case Keys.Right:
                                            {
                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                    }
                                    break;
                                }
                        }
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Home:
                            {
                                if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.IsInEditMode))
                                {
                                    // 編集モードの場合はなにもしない
                                }
                                else
                                {
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInRow);
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                // 編集モードの場合はなにもしない
                                if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.IsInEditMode))
                                {
                                    //
                                }
                                else
                                {
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInRow);
                                }
                                break;
                            }
                        case Keys.Enter:
                            {
                                EnterNextEditableCell(cell, 0);
                                break;
                            }
                        case Keys.Up:
                            {
                                if ((this.uGrid_Details.ActiveCell != null) && (!this.uGrid_Details.ActiveCell.DroppedDown))
                                {
                                    if (this.uGrid_Details.ActiveCell.Row.Index == 0)
                                    {
                                        if (this.GridKeyUpTopRow != null)
                                        {
                                            this.GridKeyUpTopRow(this, new EventArgs());
                                            e.Handled = true;
                                        }
                                    }
                                }
                                break;
                            }
                    }
                }
            }
            else if (this.uGrid_Details.ActiveRow != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Details.ActiveRow;

                switch (e.KeyCode)
                {
                    case Keys.Up:
                        {
                            if ((this.uGrid_Details.ActiveRow != null))
                            {
                                if (this.uGrid_Details.ActiveRow.Index == 0)
                                {
                                    if (this.GridKeyUpTopRow != null)
                                    {
                                        this.GridKeyUpTopRow(this, new EventArgs());
                                        e.Handled = true;
                                    }
                                }
                            }
                            break;
                        }

                    case Keys.Delete:
                        {
                            // Delキーの操作
                            break;
                        }
                }
            }
        }

        /// <summary>										
        /// グリッドキーダウンイベント										
        /// </summary>										
        /// <param name="sender">対象オブジェクト</param>										
        /// <param name="e">イベントパラメータクラス</param>										
        /// <remarks>										
        /// <br>Note		: グリッドキーダウン時、処理を行います。</br>								
        /// <br>Programmer	: 譚洪</br>									
        /// <br>Date		: 2009.05.26</br>								
        /// </remarks>	
        private void uGrid_Details_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
            int rowIndex = cell.Row.Index;

            // ActiveCellが開始時間の場合
            if (cell.Column.Key == this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName)
            {
                if (string.IsNullOrEmpty(Convert.ToString(cell.Value)))
                {
                    TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       "返品上限数は0以上の値を入力して下さい。",
                       -1,
                       MessageBoxButtons.OK);
                    this._goodsNotReturnDetailDataTable[rowIndex].LimitReturnNo = limitReturnNo;
                    return;
                }
                double value = Convert.ToDouble(cell.Value);

                this._goodsNotReturnDetailDataTable[rowIndex].LimitReturnNo = value;

                // 入力返品上限数＞出荷数の場合、「返品上限数が出荷数を超えています。」というメッセージダイアログ（OKのみ）が表示される。
                if (value > shipmentNo)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       "返品上限数が出荷数を超えています。",
                       -1,
                       MessageBoxButtons.OK);
                    //this.uGrid_Details.Rows[rowIndex].Cells[6].Activated = true;
                    //this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    this._goodsNotReturnDetailDataTable[rowIndex].LimitReturnNo = limitReturnNo;
                    return;
                }
                // 入力返品上限数＜返品済数の場合、「返品上限数は返品済数以上の値を入力して下さい。」というメッセージダイアログ（OKのみ）が表示される。
                if (value < returnNo)
                {
                    TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       "返品上限数は返品済数以上の値を入力して下さい。",
                       -1,
                       MessageBoxButtons.OK);
                    this._goodsNotReturnDetailDataTable[rowIndex].LimitReturnNo = limitReturnNo;
                    return;
                }
                // 入力返品上限数＜0の場合、「返品上限数は0以上の値を入力して下さい。」というメッセージダイアログ（OKのみ）が表示される。
                if (value < 0)
                {
                    TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       "返品上限数は0以上の値を入力して下さい。",
                       -1,
                       MessageBoxButtons.OK);
                    this._goodsNotReturnDetailDataTable[rowIndex].LimitReturnNo = limitReturnNo;
                    return;
                }
            }
        }
        /// <summary>
        /// セルのデータチェック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <returns/>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.05.20</br>
        /// </remarks>
        private void uGrid_Details_CellDataError(object sender, CellDataErrorEventArgs e)
        {

            if (this.uGrid_Details.ActiveCell != null)
            {
                // 数値項目の場合
                if (this.uGrid_Details.ActiveCell.Column.DataType == typeof(double))
                {
                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Details.ActiveCell.EditorResolved;

                    // 未入力は0にする				
                    if (editorBase.CurrentEditText.Trim() == "")
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "返品上限数が数字を入力して下さい。",
                           -1,
                           MessageBoxButtons.OK);
                        //editorBase.Value = 0;				// 0をセット
                        //this.uGrid_Details.ActiveCell.Value = 0;
                    }
                    // 通常入力				
                    else
                    {
                        try
                        {
                            editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.uGrid_Details.ActiveCell.Column.DataType);
                            this.uGrid_Details.ActiveCell.Value = editorBase.Value;
                        }
                        catch
                        {
                            TMsgDisp.Show(
                               this,
                               emErrorLevel.ERR_LEVEL_INFO,
                               this.Name,
                               "返品上限数が数字を入力して下さい。",
                               -1,
                               MessageBoxButtons.OK);
                            //editorBase.Value = 0;
                            //this.uGrid_Details.ActiveCell.Value = 0;


                        }
                    }
                    e.RaiseErrorEvent = false;			// エラーイベントは発生させない
                    e.RestoreOriginalValue = false;		// セルの値を元に戻さない	
                    e.StayInEditMode = false;			// 編集モードは抜ける

                    return;
                }
            }
        }

        /// <summary>										
        /// グリッドキーダウンイベント										
        /// </summary>										
        /// <param name="sender">対象オブジェクト</param>										
        /// <param name="e">イベントパラメータクラス</param>										
        /// <remarks>										
        /// <br>Note		: グリッドキーダウン時、処理を行います。</br>								
        /// <br>Programmer	: 譚洪</br>									
        /// <br>Date		: 2009.05.26</br>								
        /// </remarks>	
        private void uGrid_Details_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
            int rowIndex = cell.Row.Index;


            // ActiveCellが開始時間の場合
            if (cell.Column.Key == this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName)
            {
                limitReturnNo = Convert.ToDouble(cell.Value);
                shipmentNo = Convert.ToDouble(this.uGrid_Details.Rows[rowIndex].Cells[4].Value);
                returnNo = Convert.ToDouble(this.uGrid_Details.Rows[rowIndex].Cells[5].Value);
            }
        }
        # endregion
    }
}

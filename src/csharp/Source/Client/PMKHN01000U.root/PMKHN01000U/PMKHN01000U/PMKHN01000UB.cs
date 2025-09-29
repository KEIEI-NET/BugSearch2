//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データクリア処理
// プログラム概要   : データクリア処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/06/16  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// データクリア処理コントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : データクリア処理表示を行うコントロールクラスです。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.06.16</br>
    /// </remarks>
    public partial class PMKHN01000UB : UserControl
    {
        #region ■ private field ■

        private static readonly Color DISABLE_COLOR = Color.Gainsboro;
        private static readonly Color DISABLE_FONT_COLOR = Color.Black;

        #endregion ■ private field ■

        #region ■ Private Members

        /// <summary>データクリア処理データセット</summary>
        /// <remarks></remarks>
        private DataClearDataSet.DataClearDataTable _dataClearDataTable;

        /// <summary>データクリア処理アクセス</summary>
        /// <remarks></remarks>
        private DataClearAcs _dataClearAcs;

        #endregion

        #region ■ Constroctors
        /// <summary>
        /// データクリア処理クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : データクリア処理クラスコンストラクタです。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.16</br>
        /// </remarks>
        public PMKHN01000UB()
        {
            InitializeComponent();
            this._dataClearAcs = DataClearAcs.GetInstance();
            this._dataClearDataTable = this._dataClearAcs.DataClearDataTable;
            this.uGrid_Details.DataSource = this._dataClearDataTable;
        }
        #endregion

        #region ■ Control Event
        /// <summary>
        /// コントロールロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : コントロールロードイベントを行う</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.16</br>
        /// </remarks>
        private void PMKHN01000UB_Load(object sender, EventArgs e)
        {
            // グリッド列初期設定処理
            this.InitialSettingGridCol();

            // グリッド行初期設定処理
            this.GridRowInitialSetting();

            // 初期フォーカス位置
            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid);
        }

        /// <summary>
        /// グリッド行初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : コントロールロードイベントを行う</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.16</br>
        /// </remarks>
        private void GridRowInitialSetting()
        {
            this._dataClearDataTable.Rows.Clear();
        }

        /// <summary>
        /// グリッドの初期化イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッドの初期化イベントを行う</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.16</br>
        /// </remarks>
        private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // グリッド列初期設定処理
            this.InitialSettingGridCol();
        }

        /// <summary>
        /// グリッドセルアップデート後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッドセルアップデート後イベント処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009/06/17</br>
        /// </remarks>
        private void uGrid_Details_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            this._dataClearDataTable.AcceptChanges();
            if (e.Cell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;
            bool check;
            string checkStringDel = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._dataClearDataTable.IsCheckedColumn.ColumnName].Text;
            if ("True".Equals(checkStringDel))
            {
                check = true;
            }
            else
            {
                check = false;
            }
            //-----------------------------------------------------------
            // 処理
            //-----------------------------------------------------------
            if (cell.Column.Key == this._dataClearDataTable.IsCheckedColumn.ColumnName)
            {
                this._dataClearAcs.SelectCheckbox(this._dataClearDataTable[cell.Row.Index].TableId, check);
            }
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 劉学智</br>
        /// <br>Date        : 2009/06/26</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid uGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            int rowIndex = uGrid.ActiveCell.Row.Index;
            int colIndex = uGrid.ActiveCell.Column.Index;
            string colKey = uGrid.ActiveCell.Column.Key;

            switch (e.KeyCode)
            {
                case Keys.Space:
                    //-----------------------------------------------------------
                    // 処理
                    //-----------------------------------------------------------
                    if (colKey == this._dataClearDataTable.IsCheckedColumn.ColumnName)
                    {
                        bool check = !Convert.ToBoolean(this.uGrid_Details.Rows[rowIndex].Cells[colIndex].Value);
                        this._dataClearAcs.SelectCheckbox(this._dataClearDataTable[rowIndex].TableId, check);
                    }
                    break;
            }
        }

        /// <summary>
        /// Leave イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyをLeave時に発生します。</br>
        /// <br>Programmer  : 劉学智</br>
        /// <br>Date        : 2009/06/26</br>
        /// </remarks>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {
            this.ChangedGridCellUnSelect();
        }
        #endregion ■ Control Event

        #region ■ Public Methods
        /// <summary>
        /// グリッド列初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッド列初期設定処理を行う</br>
        /// <br>Programer  : 劉学智</br>
        /// <br>Date       : 2009.06.16</br>
        /// </remarks>
        public void InitialSettingGridCol()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.uGrid_Details.DisplayLayout.Bands[0];
            if (band == null) return;

            int visiblePosition = 0;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in band.Columns)
            {
                //「No列」以外の全てのセルのDiabledColorを設定する。
                if (col.Key != this._dataClearDataTable.RowNoColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
                }
            }

            this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = 11F;

            // 表示順位
            band.Columns[this._dataClearDataTable.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataClearDataTable.TableIdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataClearDataTable.TableNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataClearDataTable.IsCheckedColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataClearDataTable.ClearCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataClearDataTable.FileIdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataClearDataTable.ClearResultColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // Fix設定
            band.Columns[this._dataClearDataTable.RowNoColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._dataClearDataTable.TableIdColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._dataClearDataTable.TableNmColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._dataClearDataTable.IsCheckedColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._dataClearDataTable.ClearCodeColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._dataClearDataTable.FileIdColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._dataClearDataTable.ClearResultColumn.ColumnName].Header.Fixed = true;

            // タイトル設定
            band.Columns[this._dataClearDataTable.RowNoColumn.ColumnName].Header.Caption = "No.";
            band.Columns[this._dataClearDataTable.TableIdColumn.ColumnName].Header.Caption = "TableId";
            band.Columns[this._dataClearDataTable.TableNmColumn.ColumnName].Header.Caption = "処理対象";
            band.Columns[this._dataClearDataTable.IsCheckedColumn.ColumnName].Header.Caption = "処理";
            band.Columns[this._dataClearDataTable.ClearCodeColumn.ColumnName].Header.Caption = "処理コード";
            band.Columns[this._dataClearDataTable.FileIdColumn.ColumnName].Header.Caption = "処理フィールド";
            band.Columns[this._dataClearDataTable.ClearResultColumn.ColumnName].Header.Caption = "処理結果";

            // タイトルの詰め方
            band.Columns[this._dataClearDataTable.RowNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataClearDataTable.TableIdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataClearDataTable.TableNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataClearDataTable.IsCheckedColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataClearDataTable.ClearCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataClearDataTable.FileIdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataClearDataTable.ClearResultColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;

            // 入力許可設定
            band.Columns[this._dataClearDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            band.Columns[this._dataClearDataTable.TableIdColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            band.Columns[this._dataClearDataTable.TableNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            band.Columns[this._dataClearDataTable.IsCheckedColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            band.Columns[this._dataClearDataTable.ClearCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            band.Columns[this._dataClearDataTable.FileIdColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            band.Columns[this._dataClearDataTable.ClearResultColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // 表示幅設定
            band.Columns[this._dataClearDataTable.RowNoColumn.ColumnName].Width = 40;
            band.Columns[this._dataClearDataTable.TableIdColumn.ColumnName].Width = 80;
            band.Columns[this._dataClearDataTable.TableNmColumn.ColumnName].Width = 300;
            band.Columns[this._dataClearDataTable.IsCheckedColumn.ColumnName].Width = 50;
            band.Columns[this._dataClearDataTable.ClearCodeColumn.ColumnName].Width = 100;
            band.Columns[this._dataClearDataTable.FileIdColumn.ColumnName].Width = 100;
            band.Columns[this._dataClearDataTable.ClearResultColumn.ColumnName].Width = 587;

            // 固定列設定
            band.Columns[this._dataClearDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            band.Columns[this._dataClearDataTable.TableIdColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            band.Columns[this._dataClearDataTable.TableNmColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            band.Columns[this._dataClearDataTable.IsCheckedColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            band.Columns[this._dataClearDataTable.ClearCodeColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            band.Columns[this._dataClearDataTable.FileIdColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            band.Columns[this._dataClearDataTable.ClearResultColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;

            // 詰め方設定
            band.Columns[this._dataClearDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataClearDataTable.TableIdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataClearDataTable.TableNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataClearDataTable.IsCheckedColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[this._dataClearDataTable.ClearCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataClearDataTable.FileIdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataClearDataTable.ClearResultColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

            // Style設定
            band.Columns[this._dataClearDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            band.Columns[this._dataClearDataTable.TableIdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            band.Columns[this._dataClearDataTable.TableNmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            band.Columns[this._dataClearDataTable.IsCheckedColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            band.Columns[this._dataClearDataTable.ClearCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            band.Columns[this._dataClearDataTable.FileIdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            band.Columns[this._dataClearDataTable.ClearResultColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // 非表示設定
            band.Columns[this._dataClearDataTable.RowNoColumn.ColumnName].Hidden = false;
            band.Columns[this._dataClearDataTable.TableIdColumn.ColumnName].Hidden = true;
            band.Columns[this._dataClearDataTable.TableNmColumn.ColumnName].Hidden = false;
            band.Columns[this._dataClearDataTable.IsCheckedColumn.ColumnName].Hidden = false;
            band.Columns[this._dataClearDataTable.ClearCodeColumn.ColumnName].Hidden = true;
            band.Columns[this._dataClearDataTable.FileIdColumn.ColumnName].Hidden = true;
            band.Columns[this._dataClearDataTable.ClearResultColumn.ColumnName].Hidden = false;

            // 自動更新
            band.Columns[this._dataClearDataTable.IsCheckedColumn.ColumnName].AutoEdit = true;
        }

        /// <summary>
        /// グリッドのチェックボックスのフォーカス処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : グリッドのチェックボックスのフォーカス処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.17</br>
        /// </remarks>
        public void ActivateCheckBox(Int32 rowNo)
        {
            // 全ての行のアンセレクト処理
            this.ChangedGridCellUnSelect();

            this.uGrid_Details.Focus();

            // 一行目を選択状態にする
            this.uGrid_Details.Rows[rowNo].Cells[this._dataClearDataTable.IsCheckedColumn.ColumnName].Activate();

            return;
        }

        /// <summary>
        /// 全ての行のアンセレクト処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 全ての行のアンセレクト処理を行います。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.17</br>
        /// </remarks>
        public void ChangedGridCellUnSelect()
        {
            this.uGrid_Details.BeginUpdate();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_Details.Rows)
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridCell cell in gridRow.Cells)
                {
                    cell.Activated = false;
                    cell.Selected = false;
                }
            }
            this.uGrid_Details.EndUpdate();
        }
        #endregion ■ Public Methods

        #region ■ Private Methods
        /// <summary>
        /// Returnキーダウン処理
        /// </summary>
        /// <param name="isPrevOrNext">true:前セル false:次セル</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// <br>Note       : Returnキーダウン処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        internal bool ReturnKeyDown(bool isPrevOrNext)
        {
            if (this.uGrid_Details.ActiveCell == null) return false;

            return this.MovePrevNextAllowEditCell(false, isPrevOrNext);
        }

        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <param name="isPrevOrNext">true:前セル false:次セル</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// <br>Note       : 次入力可能セル移動処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private bool MovePrevNextAllowEditCell(bool activeCellCheck, bool isPrevOrNext)
        {
            bool moved = false;
            bool performActionResult = false;

            try
            {
                // 更新開始（描画ストップ）
                this.uGrid_Details.BeginUpdate();

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
                    if (isPrevOrNext)
                    {
                        performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);
                    }
                    else
                    {
                        performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                    }
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
            }
            finally
            {
                // 更新終了（描画再開）
                this.uGrid_Details.EndUpdate();
            }

            return performActionResult;
        }
        #endregion ■ Private Methods

    }
}

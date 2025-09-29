using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Application.Common;

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// 車種選択ガイド
    /// </summary>
    /// <remarks>
    /// <br>Note       : 車種選択ガイドです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    internal partial class SelectionForm : Form
    {
        #region [ メンバー変数宣言 ]
        private readonly string colCarKindCd = "CarKindCd";
        private PMKEN01010E.CarKindInfoDataTable srcTable = null;
        private string rowNoInput = string.Empty;
        #endregion

        #region [ フォーム関連処理 ]
        /// <summary>
        /// 選択画面コンストラクタ
        /// </summary>
        /// <param name="dtSource">グリッドに表示するデータを指定します。</param>
        public SelectionForm(PMKEN01010E.CarKindInfoDataTable dtSource)
        {
            InitializeComponent();

            // DataTable の設定
            srcTable = dtSource;
            InitializaDataTable();

            gridCarKindInfo.DataSource = srcTable;

            // ステータスバーの初期化
            StatusBar.Panels[0].Text = "";

            // ツールバーのイメージ(16x16)やメッセージを設定する
            ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;

            ToolbarsManager.Tools["Button_Select"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            ToolbarsManager.Tools["Button_Back"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            ToolbarsManager.Tools["Button_ShowCode"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.COL;

            // 先頭行を選択状態にする
            gridCarKindInfo.Rows[0].Selected = true;
            RefreshCount();

        }

        private void RefreshCount()
        {
            if (gridCarKindInfo.Selected.Rows.Count > 0)
                ToolbarsManager.Toolbars[1].Tools["TotalCount"].SharedProps.Caption = string.Format("{0}／{1}",
                    gridCarKindInfo.Selected.Rows[0].VisibleIndex + 1,
                    gridCarKindInfo.Rows.VisibleRowCount);
        }

        /// <summary>
        /// FormClosing イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>不測の事態を避けるため、サブスレッドの実行中は終了できないようにする</br>
        /// </remarks>
        private void SelectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            srcTable.Columns.Remove(colCarKindCd);
        }

        /// <summary>
        /// FormClosed イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>DialogResultがOKの場合にのみ、グリッド上で選択されている行に関連するDataRowオブジェクトを取得し、</br>
        /// <br>"選択状態"に相当する処理を行います。</br>
        /// </remarks>
        private void SelectionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                for (int Index = 0; Index <= this.gridCarKindInfo.Selected.Rows.Count - 1; Index++)
                {
                    this.gridCarKindInfo.Selected.Rows[Index].Cells["SelectionState"].Value = true;
                }
            }

            gridCarKindInfo.BeginUpdate();
            try
            {
                gridCarKindInfo.DataSource = null;
            }
            finally
            {
                gridCarKindInfo.EndUpdate();
            }
        }

        /// <summary>
        /// ESCキー押下による終了処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;
                case Keys.Back:
                    int rowNo;
                    if (rowNoInput.Length > 1)
                    {
                        rowNoInput = rowNoInput.Remove(rowNoInput.Length - 1);
                        rowNo = int.Parse(rowNoInput);
                    }
                    else
                    {
                        rowNoInput = string.Empty;
                        rowNo = 1;
                    }
                    gridCarKindInfo.Rows[rowNo - 1].Activate();
                    gridCarKindInfo.Rows[rowNo - 1].Selected = true;
                    break;
                case Keys.Delete:
                    rowNoInput = string.Empty;
                    gridCarKindInfo.Rows[0].Activate();
                    gridCarKindInfo.Rows[0].Selected = true;
                    break;
            }
        }

        private void SelectionForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                string strRowNo = rowNoInput + e.KeyChar.ToString();

                int rowNo = int.Parse(strRowNo);
                if (rowNo > 0 && rowNo <= gridCarKindInfo.Rows.VisibleRowCount)
                {
                    rowNoInput = strRowNo;
                }
                else
                {
                    if (e.KeyChar.Equals('0') == false)
                    {
                        rowNoInput = e.KeyChar.ToString();
                        rowNo = int.Parse(rowNoInput);
                        if (rowNo > gridCarKindInfo.Rows.VisibleRowCount)
                        {
                            rowNoInput = string.Empty;
                            rowNo = 1;
                        }
                    }
                    else
                    {
                        rowNo = 1;
                    }
                }
                if (gridCarKindInfo.Focused == false)
                    gridCarKindInfo.Select();
                gridCarKindInfo.Rows[rowNo - 1].Activate();
                gridCarKindInfo.Rows[rowNo - 1].Selected = true;
            }
        }
        #endregion

        #region [ イベント処理 ]
        /// <summary>
        /// ツールボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Button_Select":
                    // 選択されている行を確定する
                    DialogResult = DialogResult.OK;
                    break;

                #region 全選択はないため、コメントアウトする。
                //case "Button_SelectAll":
                //    // 全ての行を選択して確定する。
                //    this.gridCarKindInfo.BeginUpdate();
                //    try
                //    {
                //        this.gridCarKindInfo.Selected.Rows.Clear();

                //        UltraGridRow[] SelectRows = new UltraGridRow[gridCarKindInfo.Rows.FilteredInRowCount];

                //        int i = 0;
                //        foreach (UltraGridRow ulRow in gridCarKindInfo.Rows)
                //        {
                //            if (!ulRow.IsFilteredOut)
                //            {
                //                SelectRows[i] = ulRow;
                //                i += 1;
                //            }
                //        }

                //        gridCarKindInfo.Selected.Rows.AddRange(SelectRows);
                //    }
                //    finally
                //    {
                //        this.gridCarKindInfo.EndUpdate();
                //    }
                //    DialogResult = DialogResult.OK;
                //    break;
                #endregion

                case "Button_Back":
                    // 前の画面に戻る
                    DialogResult = DialogResult.Cancel;
                    break;
                case "Button_ShowCode":
                    if (ToolbarsManager.Tools["Button_ShowCode"].SharedProps.Caption == "コード表示(F9)")
                    {
                        ToolbarsManager.Tools["Button_ShowCode"].SharedProps.Caption = "コード非表示(F9)";
                        gridCarKindInfo.DisplayLayout.Bands[0].Columns[colCarKindCd].Hidden = false;
                    }
                    else
                    {
                        ToolbarsManager.Tools["Button_ShowCode"].SharedProps.Caption = "コード表示(F9)";
                        gridCarKindInfo.DisplayLayout.Bands[0].Columns[colCarKindCd].Hidden = true;
                    }
                    break;
            }
        }

        #endregion

        #region [ グリッド処理 ]
        private void InitializaDataTable()
        {
            srcTable.Columns.Add(colCarKindCd, typeof(string));
            srcTable.Columns[colCarKindCd].Caption = "車種コード";
            for (int i = 0; i < srcTable.Count; i++)
            {
                srcTable[i][colCarKindCd] = string.Format("{0:d3}-{1:d3}-{2:d3}", srcTable[i].MakerCode, srcTable[i].ModelCode, srcTable[i].ModelSubCode);
            }
        }

        /// <summary>
        /// InitializeLayout イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>グリッドのレイアウト初期化処理</br>
        /// </remarks>
        private void gridCarKindInfo_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            // 列幅の自動調整方法
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.SelectTypeRow = SelectType.Single;
            e.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.SeparateElement;

            // バンドの取得
            UltraGridBand band = e.Layout.Bands[0];
            band.Columns[srcTable.SelectionStateColumn.ColumnName].Hidden = true;
            band.Columns[srcTable.MakerCodeColumn.ColumnName].Hidden = true;
            band.Columns[srcTable.ModelCodeColumn.ColumnName].Hidden = true;
            band.Columns[srcTable.ModelSubCodeColumn.ColumnName].Hidden = true;
            band.Columns[srcTable.MakerHalfNameColumn.ColumnName].Hidden = true;
            band.Columns[srcTable.ModelHalfNameColumn.ColumnName].Hidden = true;
            if (srcTable[0].EngineModelNm != string.Empty)
            {
                band.Columns[srcTable.EngineModelNmColumn.ColumnName].Hidden = false;
                band.Columns[colCarKindCd].Hidden = true;
                ToolbarsManager.Tools["Button_ShowCode"].SharedProps.Visible = false;
            }
            else
            {
                band.Columns[srcTable.EngineModelNmColumn.ColumnName].Hidden = true;
                band.Columns[colCarKindCd].Hidden = false;
            }

            band.UseRowLayout = true;

            band.Columns[srcTable.MakerFullNameColumn.ColumnName].Width = 150;
            band.Columns[srcTable.ModelFullNameColumn.ColumnName].Width = 300;
            band.Columns[srcTable.EngineModelNmColumn.ColumnName].Width = 120;
            band.Columns[colCarKindCd].Width = 120;

            if (band.Columns[srcTable.EngineModelNmColumn.ColumnName].Hidden)
            {
                band.SortedColumns.Add(srcTable.MakerCodeColumn.ColumnName, false);
                band.SortedColumns.Add(srcTable.MakerFullNameColumn.ColumnName, false);
                band.Columns[srcTable.MakerFullNameColumn.ColumnName].MergedCellStyle = MergedCellStyle.OnlyWhenSorted;

                band.Columns[srcTable.MakerFullNameColumn.ColumnName].RowLayoutColumnInfo.OriginX = 0;
                band.Columns[srcTable.ModelFullNameColumn.ColumnName].RowLayoutColumnInfo.OriginX = 150;
                band.Columns[colCarKindCd].RowLayoutColumnInfo.OriginX = 450;
            }
            else
            {
                band.SortedColumns.Add(srcTable.EngineModelNmColumn.ColumnName, false);
                band.Columns[srcTable.EngineModelNmColumn.ColumnName].MergedCellStyle = MergedCellStyle.OnlyWhenSorted;

                band.Columns[srcTable.EngineModelNmColumn.ColumnName].RowLayoutColumnInfo.OriginX = 0;
                band.Columns[srcTable.ModelFullNameColumn.ColumnName].RowLayoutColumnInfo.OriginX = 120;
                band.Columns[srcTable.MakerFullNameColumn.ColumnName].RowLayoutColumnInfo.OriginX = 420;
            }
            gridCarKindInfo.Rows[0].Activate();
        }

        /// <summary>
        /// グリッド上でEnterキーが押された場合は、その行を選択する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridCarKindInfo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    DialogResult = DialogResult.OK;
                    break;
            }
        }

        /// <summary>
        /// 行をダブルクリックされた場合は、その行を選択する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// データが表示されていない行をダブルクリックしても本イベントは発生しない。
        /// </remarks>
        private void gridCarKindInfo_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void gridCarKindInfo_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            RefreshCount();
        }
        #endregion
    }
}
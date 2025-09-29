//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : お買得商品設定マスタ
// プログラム概要   : 拠点・得意先選択を行う
//----------------------------------------------------------------------------//
//                (c)Copyright 2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 作 成 日  2015/02/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// 選択ガイド
    /// </summary>
    /// <remarks>
    /// <br>本クラスはinternalで宣言されている為、外部アセンブリからは直接参照できない。</br>
    /// <br>外部アセンブリから本クラスにアクセスする場合は、操作クラスにインターフェース</br>
    /// <br>となるメソッドやプロパティを作成する事</br>
    /// </remarks>
    public partial class PMREC09021UC : Form
    {

        # region 変数定義

        /// <summary>SecCusSet DataTable</summary>
        private RecBgnGdsDataSet.SecCusSetDataTable _secCusSetDataTable;

        /// <summary>SecCusSet DataTable プロパティ</summary>
        public RecBgnGdsDataSet.SecCusSetDataTable SecCusSetDataTable
        {
            get { return this._secCusSetDataTable; }
            set { this._secCusSetDataTable = value; }
        }

        private bool flipflopFlg = false;

        # endregion

        #region [ コンストラクタ ]

        /// <summary>
        /// 選択画面コンストラクタ
        /// </summary>
        /// <param name="secCusSetDataTable">グリッド表示用 データテーブル</param>
        public PMREC09021UC(RecBgnGdsDataSet.SecCusSetDataTable secCusSetDataTable)
        {
            this._secCusSetDataTable = secCusSetDataTable;

            InitializeComponent();
            InitializeTable();
            InitializeForm();

        }

        #endregion

        #region [ 初期処理 ]
        private void InitializeForm()
        {
            // ステータスバーの初期化
            StatusBar.Panels[0].Text = "";

            // ツールバーのイメージ(16x16)やメッセージを設定する
            ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
            ToolbarsManager.Tools["Button_Select"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            ToolbarsManager.Tools["Button_Back"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
        }

        /// <summary>
        /// データソースの初期化
        /// </summary>
        private void InitializeTable()
        {
            this.gridSecCusSetInfo.BeginUpdate();
            this.gridSecCusSetInfo.DataSource = this._secCusSetDataTable.DefaultView;
            this.gridSecCusSetInfo.EndUpdate();
        }

        #endregion

        #region ColInfo　インターナル

        internal static class ColInfo
        {
            public static void SetColInfo(UltraGridBand Band, string colname, int originX, int originY, int width)
            {
                System.Drawing.Size sizeHeader = new Size();
                System.Drawing.Size sizeCell = new Size();

                Band.RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
                Band.RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;

                Band.Columns[colname].RowLayoutColumnInfo.OriginX = originX;
                Band.Columns[colname].RowLayoutColumnInfo.OriginY = originY;

                sizeCell.Height = 24;
                sizeCell.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                sizeHeader.Height = 24;
                sizeHeader.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            }
            public static void SetColInfo(UltraGridBand Band, string colname, int originX, int originY, int spanX, int spanY, int width)
            {
                System.Drawing.Size sizeHeader = new Size();
                System.Drawing.Size sizeCell = new Size();

                Band.RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
                Band.RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;

                Band.Columns[colname].RowLayoutColumnInfo.LabelSpan = 2;
                Band.Columns[colname].RowLayoutColumnInfo.OriginX = originX;
                Band.Columns[colname].RowLayoutColumnInfo.OriginY = originY;
                Band.Columns[colname].RowLayoutColumnInfo.SpanX = spanX;
                Band.Columns[colname].RowLayoutColumnInfo.SpanY = spanY;

                sizeCell.Height = 24;
                sizeCell.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                sizeHeader.Height = 24;
                sizeHeader.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            }
        }
        #endregion

        #region [ フォームイベント処理 ]
        /// <summary>
        /// FormClosed イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>DialogResultがOKの場合にのみ、グリッド上で選択されている行に関連するDataRowオブジェクトを取得し、</br>
        /// <br>"選択状態"に相当する処理を行います。</br>
        /// </remarks>
        private void PMREC09021UC_FormClosed(object sender, FormClosedEventArgs e)
        {
            gridSecCusSetInfo.BeginUpdate();
            try
            {
                gridSecCusSetInfo.DataSource = null;
            }
            finally
            {
                gridSecCusSetInfo.EndUpdate();
            }
        }

        /// <summary>
        /// ESCキー押下による終了処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMREC09021UC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            gridSecCusSetInfo.Select();
        }

        private void PMREC09021UC_Shown(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;

            this.gridSecCusSetInfo.Focus();

            // 先頭行を選択状態にする
            if (this.gridSecCusSetInfo.Rows.Count > 0)
            {
                if (this.gridSecCusSetInfo.ActiveRow != null)
                {
                    if (!this.gridSecCusSetInfo.ActiveRow.Selected)
                    {
                        this.gridSecCusSetInfo.ActiveRow.Selected = true;
                    }
                }
                else
                {
                    this.gridSecCusSetInfo.Rows[0].Activate();
                    this.gridSecCusSetInfo.Rows[0].Selected = true;
                }
                return;
            }
        }
        /// <summary>
        /// ShowDialog
        /// </summary>
        /// <returns>DialogResult</returns>
        internal new DialogResult ShowDialog()
        {
            DialogResult ret = base.ShowDialog();
            if (ret == DialogResult.OK || ret == DialogResult.Cancel)
            {
                // DataTableから未選択行を抽出し削除する
                DataRow[] rows = this._secCusSetDataTable.Select("SelectionState = false");
                for (int i = 0; i < rows.Length; i++)
                {
                    if (rows[i].RowState != DataRowState.Deleted)
                    {
                        rows[i].Delete();
                    }
                }
                this._secCusSetDataTable.AcceptChanges();
            }
            return ret;
        }

        #endregion

        #region [ ツールバーイベント処理 ]
        /// <summary>
        /// ツールボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            if (flipflopFlg)
                return;
            bool chk = ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked;
            switch (e.Tool.Key)
            {
                case "Button_Select": // 選択されている行を確定する
                    DialogResult = DialogResult.OK;
                    break;

                case "Button_Back": // 前の画面に戻る
                    DialogResult = DialogResult.Cancel;
                    break;
            }
        }

        #endregion

        #region [ グリッドイベント処理 ]

        /// <summary>
        /// グリッド　InitializeLayout イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>グリッドレイアウトの初期化処理</br>
        /// </remarks>
        private void gridSecCusSetInfo_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            #region グリッドのレイアウト初期化

            // 列幅の自動調整方法
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.SelectTypeRow = SelectType.Single;

            // バンドの取得
            UltraGridBand Band = e.Layout.Bands[0];
            Band.UseRowLayout = true;

            for (int Index = 0; Index < Band.Columns.Count; Index++)
            {
                // フィルタを無効
                Band.Columns[Index].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                
                // 水平表示位置
                if (Band.Columns[Index].DataType == typeof(int) || Band.Columns[Index].DataType == typeof(double))
                {
                    Band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else
                {
                    Band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                Band.Columns[Index].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;

                // 垂直表示位置
                Band.Columns[Index].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }
            Band.Columns[_secCusSetDataTable.SelImageColumn.ColumnName].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;

            Band.Columns[_secCusSetDataTable.SelImageColumn.ColumnName].Hidden = false;
            Band.Columns[_secCusSetDataTable.SelectionStateColumn.ColumnName].Hidden = true;
            Band.Columns[_secCusSetDataTable.SectionCodeColumn.ColumnName].Hidden = true;
            Band.Columns[_secCusSetDataTable.SectionNameColumn.ColumnName].Hidden = true;
            Band.Columns[_secCusSetDataTable.CustomerCodeColumn.ColumnName].Hidden = false;
            Band.Columns[_secCusSetDataTable.CustomerNameColumn.ColumnName].Hidden = false;
            Band.Columns[_secCusSetDataTable.MngSectionCodeColumn.ColumnName].Hidden = true;
            Band.Columns[_secCusSetDataTable.CnectOriginalEpCdColumn.ColumnName].Hidden = true;
            Band.Columns[_secCusSetDataTable.CnectOriginalSecCdColumn.ColumnName].Hidden = true;

            Band.Columns[_secCusSetDataTable.SelectionStateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;

            Band.Columns[_secCusSetDataTable.SelImageColumn.ColumnName].Width = 40;
            //Band.Columns[_secCusSetDataTable.SectionCodeColumn.ColumnName].Width = 40;
            //Band.Columns[_secCusSetDataTable.SectionNameColumn.ColumnName].Width = 120;
            Band.Columns[_secCusSetDataTable.CustomerCodeColumn.ColumnName].Width = 60;
            Band.Columns[_secCusSetDataTable.CustomerNameColumn.ColumnName].Width = 120;

            #endregion
        }

        /// <summary>
        /// グリッド　アクティブ行変更後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridSecCusSetInfo_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            if (gridSecCusSetInfo.Selected.Rows.Count > 0)
            {
                gridSecCusSetInfo.Selected.Rows[0].Activate();
            }
        }

        /// <summary>
        /// グリッド　KeyDownイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Enterキーが押された場合は、その行を選択する。
        /// </remarks>
        private void gridSecCusSetInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (gridSecCusSetInfo.ActiveRow != null)
                {
                    if (gridSecCusSetInfo.ActiveRow.Cells[_secCusSetDataTable.SelImageColumn.ColumnName].Value != DBNull.Value)
                    {
                        // 選択解除
                        gridSecCusSetInfo.ActiveRow.Cells[_secCusSetDataTable.SelImageColumn.ColumnName].Value = DBNull.Value; // 選択イメージ
                        gridSecCusSetInfo.ActiveRow.Cells[_secCusSetDataTable.SelectionStateColumn.ColumnName].Value = false;  // 選択状況
                    }
                    else
                    {
                        // 選択
                        gridSecCusSetInfo.ActiveRow.Cells[_secCusSetDataTable.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                        gridSecCusSetInfo.ActiveRow.Cells[_secCusSetDataTable.SelectionStateColumn.ColumnName].Value = true;
                    }

                    UltraGridRow ugr = this.gridSecCusSetInfo.ActiveRow.GetSibling(SiblingRow.Next);
                    if (ugr != null)
                    {
                        ugr.Activate();
                        ugr.Selected = true;
                    }

                    // 変更データのコミット
                    gridSecCusSetInfo.UpdateData();
                }
            }
        }

        /// <summary>
        /// グリッド　行ダブルクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// ダブルクリック行を選択する
        /// データが表示されていない行をダブルクリックしても本イベントは発生しない。
        /// </remarks>
        private void gridSecCusSetInfo_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            if (gridSecCusSetInfo.ActiveRow != null)
            {
                if (gridSecCusSetInfo.ActiveRow.Cells[_secCusSetDataTable.SelImageColumn.ColumnName].Value != DBNull.Value)
                {
                    // 選択解除
                    gridSecCusSetInfo.ActiveRow.Cells[_secCusSetDataTable.SelImageColumn.ColumnName].Value = DBNull.Value;
                    gridSecCusSetInfo.ActiveRow.Cells[_secCusSetDataTable.SelectionStateColumn.ColumnName].Value = false;
                }
                else
                {
                    // 選択
                    gridSecCusSetInfo.ActiveRow.Cells[_secCusSetDataTable.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                    gridSecCusSetInfo.ActiveRow.Cells[_secCusSetDataTable.SelectionStateColumn.ColumnName].Value = true;
                }
                gridSecCusSetInfo.UpdateData();
            }
        }
        #endregion
    }
}
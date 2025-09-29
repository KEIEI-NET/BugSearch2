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
    /// 選択ガイド
    /// </summary>
    /// <remarks>
    /// <br>本クラスはinternalで宣言されている為、外部アセンブリからは直接参照できない。</br>
    /// <br>外部アセンブリから本クラスにアクセスする場合は、操作クラスにインターフェース</br>
    /// <br>となるメソッドやプロパティを作成する事</br>
    /// </remarks>
    internal partial class SelectionForm : Form
    {
        # region 各種変数、定数宣言
        private const string COL_RW = "OrgRow";  // ← 固定名称とする。
        private const string COL_CTGRYMODEL = "CategoryModel";  // ← 固定名称とする。

        //private CategoryDataDataTable DataDestTable = null;
        private CategoryDataDataTable DataSourceTable = null;

        # endregion

        /// <summary>
        /// 選択画面コンストラクタ
        /// </summary>
        /// <param name="dtSource">グリッドに表示するデータを指定します。</param>
        public SelectionForm(CategoryDataDataTable dtSource)
        {
            InitializeComponent();

            // DataTable の設定
            DataSourceTable = dtSource;

            InitializeData();

            // ステータスバーの初期化
            StatusBar.Panels[0].Text = "";
            // ツールバーのイメージ(16x16)やメッセージを設定する
            ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
            ToolbarsManager.Tools["Button_Back"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            // 先頭行を選択状態にする
            this.DataGrid.Rows[0].Selected = true;
            this.DataGrid.Rows[0].Activate();

        }

        /// <summary>
        /// データテーブルの列を作成する
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <param name="type">型</param>
        /// <param name="caption">キャプション</param>
        /// <returns></returns>
        private DataColumn CreateColumn(string columnName, Type type, string caption)
        {
            #region カラム作成
            DataColumn dc = new DataColumn();

            dc.ColumnName = columnName;
            dc.DataType = type;
            dc.Caption = caption;

            return dc;
            #endregion
        }

        /// <summary>
        /// InitializeLayout イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>グリッドのレイアウト初期化処理</br>
        /// </remarks>
        private void DataGrid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            // 列幅の自動調整方法
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.SelectTypeRow = SelectType.Single;
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            e.Layout.Override.RowSelectorWidth = 24;
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex;

            // バンドの取得
            UltraGridBand Band = e.Layout.Bands[0];
            Band.Override.RowSizing = RowSizing.Fixed;
            Band.Override.AllowColSizing = AllowColSizing.None;
            Band.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            // 水平表示位置
            Band.Columns[0].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // 垂直表示位置
            Band.Columns[0].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            Band.Columns[0].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
          
        }

        /// <summary>
        /// 表示用データをDataTableに登録
        /// </summary>
        private void InitializeData()
        {
            //DataDestTable = new DsCategoryData.CategoryDataDataTable();            

            //for (int i = 0; i < DataSourceTable.Rows.Count; i++)
            //{
            //    PMKEN01010E.CtgyMdlLnkInfoRow wkRow = DataSourceTable[i];
            //    string categoryModel = String.Format("{0,5}-{1,4}", wkRow[0], wkRow[1]);
            //    DataDestTable.AddCategoryDataRow(categoryModel);
            //}

            DataGrid.DataSource = DataSourceTable;
            
        }


        /// <summary>
        /// ツールボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {

                case "Button_Back":
                    // 前の画面に戻る
                    DialogResult = DialogResult.Cancel;
                    break;
          
            }
        }

        /// <summary>
        /// ツールバー上でのキー押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolbarsManager_ToolKeyDown(object sender, ToolKeyEventArgs e)
        {

        }

        /// <summary>
        /// アクティブ行変更後イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {

        }

        /// <summary>
        /// グリッド上でEnterキーが押された場合は、その行を選択する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.Cancel;
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
        private void DataGrid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            
        }

        /// <summary>
        /// ESCキー押下による終了処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

    }
}
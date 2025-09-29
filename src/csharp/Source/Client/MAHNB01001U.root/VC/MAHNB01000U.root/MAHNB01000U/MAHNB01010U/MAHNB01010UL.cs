using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 商品自動登録フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品自動登録のフォームクラスです。</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2008.05.23</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2008.05.23 20056 對馬 大輔 新規作成</br>
    /// </remarks>
    public partial class MAHNB01010UL : Form
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private SalesSlipInputAcs _salesSlipInputAcs;
        private SalesSlipInputInitDataAcs _salesSlipInputInitDataAcs;
        private SalesInputDataSet.AutoEntryGoodsDataTable _autoEntryGoodsDataTable;
        private DataView _autoEntryGoodsView = null;
        private ImageList _imageList16 = null;									// イメージリスト
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;		// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _decisionButton;	// 確定ボタン
        private DialogResult _dialogRes = DialogResult.Cancel;                  // ダイアログリザルト

        private readonly Color _selectedBackColor = Color.FromArgb(216, 235, 253);
        private readonly Color _selectedBackColor2 = Color.FromArgb(101, 144, 218);
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructor
        public MAHNB01010UL()
        {
            InitializeComponent();

            this._salesSlipInputAcs = SalesSlipInputAcs.GetInstance();
            this._salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs.GetInstance();

            this._autoEntryGoodsDataTable = new SalesInputDataSet.AutoEntryGoodsDataTable();

            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Close"];
            this._decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Decision"];
        }
        # endregion

        // ===================================================================================== //
        // 各種コンポーネントイベント処理郡
        // ===================================================================================== //
        # region Event Methods
        /// <summary>
        /// フォームLoadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAHNB01010UI_Load(object sender, EventArgs e)
        {
            //---------------------------------------------------------
            // ツールバーボタン初期設定
            //---------------------------------------------------------
            this.ButtonInitialSetting();

            //---------------------------------------------------------
            // 初期設定タイマー起動
            //---------------------------------------------------------
            this.Initial_Timer.Enabled = true;

            //---------------------------------------------------------
            // 商品自動登録データテーブル
            //---------------------------------------------------------
            this._autoEntryGoodsDataTable = this._salesSlipInputAcs.AutoEntryGoodsDataTable;

            //---------------------------------------------------------
            // グリッド情報設定
            //---------------------------------------------------------
            this._autoEntryGoodsView = this._autoEntryGoodsDataTable.DefaultView;
            this.uGrid_AutoEntryGoods.DataSource = this._autoEntryGoodsView;
        }

        /// <summary>
        /// Timer.Tick イベント イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 指定された間隔の時間が経過したときに発生します。
        ///	                 この処理は、システムが提供するスレッド プール
        ///	                 スレッドで実行されます。</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // 初期設定タイマー解除
            this.Initial_Timer.Enabled = false;

            // 初期フォーカス位置指定
            this.uGrid_AutoEntryGoods.Focus();
            this.uGrid_AutoEntryGoods.Rows[0].Selected = true;
        }

        /// <summary>
        /// フォーカスコントロールイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                //---------------------------------------------------------------
                // 明細部
                //---------------------------------------------------------------
                case "uGrid_AutoEntryGoods":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    // アクティブ行選択タイマー起動
                                    this.timer_SelectRow.Enabled = true;
                                    e.NextCtrl = e.PrevCtrl;
                                    break;
                                }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// ツールバーボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                //--------------------------------------------
                // 終了
                //--------------------------------------------
                case "ButtonTool_Close":
                    {
                        this.SetDialogRes(DialogResult.Cancel);
                        this.CloseForm();
                        break;
                    }
                //--------------------------------------------
                // 全選択
                //--------------------------------------------
                case "ButtonTool_AllSelect":
                    {
                        this.SetRowSelectedAll(true);
                        this.ChangedSelectColorAll(true);
                        break;
                    }
                //--------------------------------------------
                // 全解除
                //--------------------------------------------
                case "ButtonTool_AllCancel":
                    {
                        this.SetRowSelectedAll(false);
                        this.ChangedSelectColorAll(false);
                        break;
                    }
                //--------------------------------------------
                // 確定
                //--------------------------------------------
                case "ButtonTool_Decision":
                    {
                        this._salesSlipInputAcs.AutoEntryGoodsDataTable = this._autoEntryGoodsDataTable;
                        this.SetDialogRes(DialogResult.OK);
                        this.CloseForm();
                        break;
                    }
            }
        }

        /// <summary>
        /// フォームクローズイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAHNB01010UI_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = _dialogRes;
        }

        /// <summary>
        /// InitializeLayout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_CompleteInfo_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_AutoEntryGoods.DisplayLayout.Bands[0].Columns;

            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //非表示設定
                column.Hidden = true;
            }

            int visiblePosition = 0;

            //--------------------------------------------------------------------------------
            //  表示するカラム情報
            //--------------------------------------------------------------------------------
            this.uGrid_AutoEntryGoods.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;
            this.uGrid_AutoEntryGoods.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            this.uGrid_AutoEntryGoods.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_AutoEntryGoods.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_AutoEntryGoods.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.uGrid_AutoEntryGoods.DisplayLayout.Bands[0].Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;// None;
            this.uGrid_AutoEntryGoods.DisplayLayout.Bands[0].Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // №
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].Header.Fixed = true;				// 固定項目
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_AutoEntryGoods.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_AutoEntryGoods.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_AutoEntryGoods.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_AutoEntryGoods.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_AutoEntryGoods.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].Width = 25;
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_AutoEntryGoods.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 選択フラグ
            Columns[this._autoEntryGoodsDataTable.CheckedColumn.ColumnName].Header.Fixed = true;		    // 固定項目
            Columns[this._autoEntryGoodsDataTable.CheckedColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryGoodsDataTable.CheckedColumn.ColumnName].Width = 30;
            Columns[this._autoEntryGoodsDataTable.CheckedColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[this._autoEntryGoodsDataTable.CheckedColumn.ColumnName].AutoEdit = true;
            Columns[this._autoEntryGoodsDataTable.CheckedColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._autoEntryGoodsDataTable.CheckedColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // ＢＬコード
            Columns[this._autoEntryGoodsDataTable.BLGoodsCodeColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._autoEntryGoodsDataTable.BLGoodsCodeColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryGoodsDataTable.BLGoodsCodeColumn.ColumnName].Width = 40;
            Columns[this._autoEntryGoodsDataTable.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._autoEntryGoodsDataTable.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // 品名
            Columns[this._autoEntryGoodsDataTable.GoodsNameColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._autoEntryGoodsDataTable.GoodsNameColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryGoodsDataTable.GoodsNameColumn.ColumnName].Width = 150;
            Columns[this._autoEntryGoodsDataTable.GoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._autoEntryGoodsDataTable.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // 品番
            Columns[this._autoEntryGoodsDataTable.GoodsNoColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._autoEntryGoodsDataTable.GoodsNoColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryGoodsDataTable.GoodsNoColumn.ColumnName].Width = 120;
            Columns[this._autoEntryGoodsDataTable.GoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._autoEntryGoodsDataTable.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // メーカー
            Columns[this._autoEntryGoodsDataTable.GoodsMakerCdColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._autoEntryGoodsDataTable.GoodsMakerCdColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryGoodsDataTable.GoodsMakerCdColumn.ColumnName].Width = 50;
            Columns[this._autoEntryGoodsDataTable.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._autoEntryGoodsDataTable.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // 仕入先
            Columns[this._autoEntryGoodsDataTable.SupplierCdColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._autoEntryGoodsDataTable.SupplierCdColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryGoodsDataTable.SupplierCdColumn.ColumnName].Width = 60;
            Columns[this._autoEntryGoodsDataTable.SupplierCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._autoEntryGoodsDataTable.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // 定価
            Columns[this._autoEntryGoodsDataTable.ListPriceColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._autoEntryGoodsDataTable.ListPriceColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryGoodsDataTable.ListPriceColumn.ColumnName].Width = 70;
            Columns[this._autoEntryGoodsDataTable.ListPriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._autoEntryGoodsDataTable.ListPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // 原価率
            Columns[this._autoEntryGoodsDataTable.CostRateColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._autoEntryGoodsDataTable.CostRateColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryGoodsDataTable.CostRateColumn.ColumnName].Width = 60;
            Columns[this._autoEntryGoodsDataTable.CostRateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._autoEntryGoodsDataTable.CostRateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // 原価単価
            Columns[this._autoEntryGoodsDataTable.SalesUnitCostColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._autoEntryGoodsDataTable.SalesUnitCostColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryGoodsDataTable.SalesUnitCostColumn.ColumnName].Width = 70;
            Columns[this._autoEntryGoodsDataTable.SalesUnitCostColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._autoEntryGoodsDataTable.SalesUnitCostColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // 固定列区切り線設定
            this.uGrid_AutoEntryGoods.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_AutoEntryGoods.DisplayLayout.Override.HeaderAppearance.BackColor2;

        }

        /// <summary>
        /// グリッドクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_AutoEntryGoods_Click(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // マウスポインタがグリッドのどの位置にあるかを判定する
            Point point = System.Windows.Forms.Cursor.Position;
            point = targetGrid.PointToClient(point);

            // UIElementを取得する。
            Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
            if (objUIElement == null)
                return;

            // マウスポインターが列のヘッダ上にあるかチェック。
            Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
              (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

            if (objHeader != null) return;

            // マウスポインターが行の上にあるかチェック。
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
              (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

            if (objRow == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
              (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

            // 選択チェック
            if (objCell == objRow.Cells[this._autoEntryGoodsDataTable.CheckedColumn.ColumnName])
            {
                this.ChangedSelect(objRow);
            }
        }

        /// <summary>
        /// グリッドダブルクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_AutoEntryGoods_DoubleClick(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // マウスポインタがグリッドのどの位置にあるかを判定する
            Point point = System.Windows.Forms.Cursor.Position;
            point = targetGrid.PointToClient(point);

            // UIElementを取得する。
            Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
            if (objUIElement == null)
                return;

            // マウスポインターが列のヘッダ上にあるかチェック。
            Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
              (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

            if (objHeader != null) return;

            // マウスポインターが行の上にあるかチェック。
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
              (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

            if (objRow == null) return;

            // チェック反転
            this.ChangedSelect(objRow);
        }

        /// <summary>
        /// 選択行情報取得タイマー起動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void timer_SelectRow_Tick(object sender, EventArgs e)
        {
            this.timer_SelectRow.Enabled = false;
            if (this.uGrid_AutoEntryGoods.ActiveRow != null)
            {
                // 選択 or 解除
                this.ChangedSelect(this.uGrid_AutoEntryGoods.ActiveRow);
            }
        }

        /// <summary>
        /// グリッドキーダウンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_AutoEntryGoods_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    // アクティブ行選択タイマー起動
                    this.timer_SelectRow.Enabled = true;
                    break;
            }
        }
        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        # region Private Methods
        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager1.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._decisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        private void CloseForm()
        {
            //---------------------------------------------------------
            // 商品自動登録データテーブル
            //---------------------------------------------------------
            this._salesSlipInputAcs.AutoEntryGoodsDataTable = this._autoEntryGoodsDataTable;

            this.Close();
        }

        /// <summary>
        /// ダイアログリザルト設定処理
        /// </summary>
        /// <param name="dialogRes">ダイアログリザルト</param>
        private void SetDialogRes(DialogResult dialogRes)
        {
            _dialogRes = dialogRes;
        }

        #region 選択・非選択変更処理
        /// <summary>
        /// 選択・日選択変更処理（反転）
        /// </summary>
        /// <param name="gridRow"></param>
        private void ChangedSelect(Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            bool newSelectedValue = !(bool)gridRow.Cells[this._autoEntryGoodsDataTable.CheckedColumn.ColumnName].Value;

            // テーブル更新
            gridRow.Cells[this._autoEntryGoodsDataTable.CheckedColumn.ColumnName].Value = newSelectedValue;

            // 背景色を変更
            ChangedSelectColor(newSelectedValue, gridRow);
        }
        /// <summary>
        /// 選択・非選択変更処理（背景色のみ）
        /// </summary>
        /// <param name="isSelected"></param>
        /// <param name="gridRow"></param>
        private void ChangedSelectColor(bool isSelected, Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            if (gridRow == null) return;

            // 対象行の選択色を設定する
            if (isSelected)
            {
                gridRow.Appearance.BackColor = _selectedBackColor;
                gridRow.Appearance.BackColor2 = _selectedBackColor2;
                gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            }
            else
            {
                if (gridRow.Index % 2 == 1)
                {
                    gridRow.Appearance.BackColor = Color.Lavender;
                }
                else
                {
                    gridRow.Appearance.BackColor = Color.White;
                }
                gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            }
        }
        /// <summary>
        /// 全ての行の背景色変更
        /// </summary>
        /// <param name="isSelected"></param>
        private void ChangedSelectColorAll(bool isSelected)
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in this.uGrid_AutoEntryGoods.Rows)
            {
                ChangedSelectColor(isSelected, row);
            }
        }
        /// <summary>
        /// 全ての行の選択チェックをセット
        /// </summary>
        public void SetRowSelectedAll(bool rowSelected)
        {
            // 全ての行の選択チェックを設定
            foreach (DataRow row in this._autoEntryGoodsDataTable.Rows)
            {
                row[this._salesSlipInputAcs.AutoEntryGoodsDataTable.CheckedColumn] = rowSelected;
            }
        }
        # endregion

        /// <summary>
        /// uButton_Close_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Close_Click(object sender, EventArgs e)
        {

            this.SetDialogRes(DialogResult.Cancel);
            this.CloseForm();
        }
        # endregion
    }
}
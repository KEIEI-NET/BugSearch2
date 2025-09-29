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
    /// BLコード変換選択フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : BLコード変換選択のフォームクラスです。</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2009.07.30</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2009.07.30 20056 對馬 大輔 新規作成</br>
    /// </remarks>
    public partial class MAHNB01010UN : Form
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private SalesSlipInputAcs _salesSlipInputAcs;
        private SalesInputDataSet.BLCodeChgDataTable _blCodeChgDataTable;
        private DataView _blCodeChgView = null;
        private DialogResult _dialogRes = DialogResult.Cancel;                  // ダイアログリザルト

        private readonly Color _selectedBackColor = Color.FromArgb(216, 235, 253);
        private readonly Color _selectedBackColor2 = Color.FromArgb(101, 144, 218);
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// MAHNB01010UN
        /// </summary>
        public MAHNB01010UN()
        {
            InitializeComponent();

            this._salesSlipInputAcs = SalesSlipInputAcs.GetInstance();
            this._blCodeChgDataTable = new SalesInputDataSet.BLCodeChgDataTable();
        }
        # endregion

        // ===================================================================================== //
        // 各種コンポーネントイベント処理郡
        // ===================================================================================== //
        # region Event Methods
        /// <summary>
        /// MAHNB01010UN_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAHNB01010UN_Load(object sender, EventArgs e)
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
            // BLコード枝番データテーブル
            //---------------------------------------------------------
            this._blCodeChgDataTable = this._salesSlipInputAcs.BLCodeChgDataTable;

            //---------------------------------------------------------
            // グリッド情報設定
            //---------------------------------------------------------
            this._blCodeChgView = this._blCodeChgDataTable.DefaultView;
            this.uGrid_SelectBLCodeChg.DataSource = this._blCodeChgView;
        }

        /// <summary>
        /// tArrowKeyControl1_ChangeFocus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                //---------------------------------------------------------------
                // 明細部
                //---------------------------------------------------------------
                case "uGrid_SelectBLCodeChg":
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
        /// Initial_Timer_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // 初期設定タイマー解除
            this.Initial_Timer.Enabled = false;

            // 初期フォーカス位置指定
            this.uGrid_SelectBLCodeChg.Focus();
            this.uGrid_SelectBLCodeChg.Rows[0].Selected = true;
        }

        /// <summary>
        /// uButton_Close_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>ESCで画面終了を行うときに使用</remarks>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            // ボタンは隠れてます
            this.SetDialogRes(DialogResult.Cancel);
            this.CloseForm();
        }

        /// <summary>
        /// tToolbarsManager1_ToolClick
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
                // 確定
                //--------------------------------------------
                case "ButtonTool_Decision":
                    {
                        this.SetDialogRes(DialogResult.OK);
                        this.CloseForm();
                        break;
                    }
            }
        }

        /// <summary>
        /// ultraGrid1_InitializeLayout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_SelectBLCodeChg.DisplayLayout.Bands[0].Columns;

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
            this.uGrid_SelectBLCodeChg.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;
            this.uGrid_SelectBLCodeChg.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            this.uGrid_SelectBLCodeChg.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_SelectBLCodeChg.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_SelectBLCodeChg.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.uGrid_SelectBLCodeChg.DisplayLayout.Bands[0].Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;// None;
            this.uGrid_SelectBLCodeChg.DisplayLayout.Bands[0].Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // №
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].Header.Fixed = true;				// 固定項目
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_SelectBLCodeChg.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_SelectBLCodeChg.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_SelectBLCodeChg.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_SelectBLCodeChg.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_SelectBLCodeChg.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].Hidden = false;
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].Width = 25;
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_SelectBLCodeChg.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 選択フラグ
            Columns[this._blCodeChgDataTable.CheckedColumn.ColumnName].Header.Fixed = true;		    // 固定項目
            Columns[this._blCodeChgDataTable.CheckedColumn.ColumnName].Hidden = true;
            Columns[this._blCodeChgDataTable.CheckedColumn.ColumnName].Width = 30;
            Columns[this._blCodeChgDataTable.CheckedColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[this._blCodeChgDataTable.CheckedColumn.ColumnName].AutoEdit = true;
            Columns[this._blCodeChgDataTable.CheckedColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._blCodeChgDataTable.CheckedColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // ＢＬコード
            Columns[this._blCodeChgDataTable.ChgTbsPartsCodeColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._blCodeChgDataTable.ChgTbsPartsCodeColumn.ColumnName].Hidden = false;
            Columns[this._blCodeChgDataTable.ChgTbsPartsCodeColumn.ColumnName].Width = 40;
            Columns[this._blCodeChgDataTable.ChgTbsPartsCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._blCodeChgDataTable.ChgTbsPartsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // ＢＬコード枝番
            Columns[this._blCodeChgDataTable.ChgTbsPartsCdDerivedNoColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._blCodeChgDataTable.ChgTbsPartsCdDerivedNoColumn.ColumnName].Hidden = true;
            Columns[this._blCodeChgDataTable.ChgTbsPartsCdDerivedNoColumn.ColumnName].Width = 40;
            Columns[this._blCodeChgDataTable.ChgTbsPartsCdDerivedNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._blCodeChgDataTable.ChgTbsPartsCdDerivedNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // 品名
            Columns[this._blCodeChgDataTable.TbsPartsFullNameColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._blCodeChgDataTable.TbsPartsFullNameColumn.ColumnName].Hidden = false;
            Columns[this._blCodeChgDataTable.TbsPartsFullNameColumn.ColumnName].Width = 150;
            Columns[this._blCodeChgDataTable.TbsPartsFullNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._blCodeChgDataTable.TbsPartsFullNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

            // 固定列区切り線設定
            this.uGrid_SelectBLCodeChg.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_SelectBLCodeChg.DisplayLayout.Override.HeaderAppearance.BackColor2;

        }

        /// <summary>
        /// uGrid_SelectBLGoodsDr_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_SelectSelectBLCodeChg_Click(object sender, EventArgs e)
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
            if (objCell == objRow.Cells[this._blCodeChgDataTable.CheckedColumn.ColumnName])
            {
                this.ChangedSelect(objRow);
            }
        }

        /// <summary>
        /// uGrid_SelectBLGoodsDr_DoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_SelectSelectBLCodeChg_DoubleClick(object sender, EventArgs e)
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

            if (this.SelectedCheck(objRow))
            {
                this.SetDialogRes(DialogResult.OK);
                this.CloseForm();
            }
        }

        /// <summary>
        /// timer_SelectRow_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_SelectRow_Tick(object sender, EventArgs e)
        {
            this.timer_SelectRow.Enabled = false;
            if (this.uGrid_SelectBLCodeChg.ActiveRow != null)
            {
                // 選択 or 解除
                this.ChangedSelect(this.uGrid_SelectBLCodeChg.ActiveRow);

                if (this.SelectedCheck(this.uGrid_SelectBLCodeChg.ActiveRow))
                {
                    this.SetDialogRes(DialogResult.OK);
                    this.CloseForm();
                }
            }
        }

        /// <summary>
        /// uGrid_SelectBLGoodsDr_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_SelectSelectBLCodeChg_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Return:
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
        }

        /// <summary>
        /// 画面終了処理
        /// </summary>
        private void CloseForm()
        {
            this._salesSlipInputAcs.BLCodeChgDataTable = this._blCodeChgDataTable;
            this.DialogResult = this._dialogRes;
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
        /// 選択・非選択変更処理（反転）
        /// </summary>
        /// <param name="gridRow"></param>
        private void ChangedSelect(Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            bool newSelectedValue = !(bool)gridRow.Cells[this._blCodeChgDataTable.CheckedColumn.ColumnName].Value;

            // テーブル更新
            gridRow.Cells[this._blCodeChgDataTable.CheckedColumn.ColumnName].Value = newSelectedValue;

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
        # endregion

        /// <summary>
        /// 選択チェック処理
        /// </summary>
        /// <param name="gridRow"></param>
        /// <returns></returns>
        private bool SelectedCheck(Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            bool selectedValue = (bool)gridRow.Cells[this._blCodeChgDataTable.CheckedColumn.ColumnName].Value;
            return selectedValue;
        }
        # endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        #region Public Methods
        /// <summary>
        /// 変換前情報設定処理
        /// </summary>
        /// <param name="blCode"></param>
        /// <param name="name"></param>
        public void SettingOrgInfo(int blCode, string name)
        {
            if (blCode != 0)
            {
                this.uLabel_beforeBLCodeInfo.Text = blCode.ToString() + "：" + name;
            }
            else
            {
                this.uLabel_beforeBLCodeInfo.Text = string.Empty;
            }
        }

        #endregion
    }
}
//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ユーザー価格・原価一括設定
// プログラム概要   : ユーザー価格・原価を複数件一括で修正・登録する。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/04/08  修正内容 : 新規作成
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
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ユーザー価格・原価一括設定フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ユーザー価格・原価一括設定のフォームクラスです。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.03.27</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2008.05.21 men 新規作成(DC.NSから流用)</br>
    /// </remarks>
    public partial class PMKHN09421UB : UserControl
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructors
        /// <summary>
        /// 受信データフォームクラス デフォルトコンストラクタ
        /// </summary>
        public PMKHN09421UB()
        {
            InitializeComponent();

            _userPriceInputAcs = UserPriceInputAcs.GetInstance();
            _userPriceDataTable = this._userPriceInputAcs.UserPriceDataTable;
        }

        #endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private readonly Color DISABLE_COLOR = Color.Gainsboro;
        private readonly Color DISABLE_FONT_COLOR = Color.Black;
        private UserPriceInputAcs _userPriceInputAcs;
        private UserPriceDataSet.UserPriceDataTable _userPriceDataTable;

        // ↓ 2009.06.18 劉洋 add PVCS.209
        /// <summary>
        /// フォーカス設定デリゲート
        /// </summary>
        /// <param name="itemName">項目名称</param>
        internal delegate void SettingFocusEventHandler(string itemName);

        /// <summary>フォーカス設定イベント</summary>
        internal event SettingFocusEventHandler SetFocus;
        // ↑ 2009.06.18 劉洋 add

        # endregion




        // ===================================================================================== //
        // プライベート・インターナルメソッド
        // ===================================================================================== //
        # region Private Methods and Internal Methods
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Result_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Result.DisplayLayout.Bands[0];
            if (editBand == null) return;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // 「No列」以外の全てのセルのDiabledColorを設定する。
                if (col.Key != this._userPriceDataTable.RowNoColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
                }
            }

            this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Result.DisplayLayout.Appearance.FontData.SizeInPoints = 11F;

            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.RowNoColumn.ColumnName].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.RowNoColumn.ColumnName].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = Color.White;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.White;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.RowNoColumn.ColumnName].CellActivation = Activation.Disabled;

            // 表示幅設定
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.RowNoColumn.ColumnName].Width = 60;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.BLGoodsCdColumn.ColumnName].Width = 100;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.BLGoodsNmColumn.ColumnName].Width = 254;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.BLGoodsNoColumn.ColumnName].Width = 240;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.UserPriceColumn.ColumnName].Width = 100;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.PriceColumn.ColumnName].Width = 100;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.StockPriceColumn.ColumnName].Width = 110;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.StarFlgColumn.ColumnName].Width = 30;

            // CellAppearance設定
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.BLGoodsCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.BLGoodsNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.BLGoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.UserPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.PriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.StockPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.StarFlgColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

            string FORMAT = "#,###,##0.00;-#,###,##0.00;''";
            string FORMAT1 = "00000";
            string FORMAT2 = "###,###,##0;-###,###,##0;''";
            string FORMAT3 = "#,###,##0;-#,###,##0;''";
            // 入力許可設定
            // this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;// No
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.BLGoodsCdColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.BLGoodsNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.BLGoodsNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.UserPriceColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.PriceColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.StockPriceColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.StarFlgColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // フォーマット
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.BLGoodsCdColumn.ColumnName].Format = FORMAT1;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.UserPriceColumn.ColumnName].Format = FORMAT2;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.PriceColumn.ColumnName].Format = FORMAT3;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.StockPriceColumn.ColumnName].Format = FORMAT;
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void PMKHN09421UB_Load(object sender, EventArgs e)
        {
            this.uGrid_Result.DataSource = this._userPriceDataTable;
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Result_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Result.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Result.ActiveCell;

            // ActiveCellが単価の場合
            if (cell.Column.Key == this._userPriceInputAcs.UserPriceDataTable.UserPriceColumn.ColumnName)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(9, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, true))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            else if (cell.Column.Key == this._userPriceInputAcs.UserPriceDataTable.StockPriceColumn.ColumnName)
            {
                 // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(10, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, true))
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
        /// <param name="keta">桁数(マイナス符号を含まず)</param>
        /// <param name="priod">小数点以下桁数</param>
        /// <param name="prevVal">現在の文字列</param>
        /// <param name="key">入力されたキー値</param>
        /// <param name="selstart">カーソル位置</param>
        /// <param name="sellength">選択文字長</param>
        /// <param name="minusFlg">マイナス入力可？</param>
        /// <returns>true=入力可,false=入力不可</returns>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }
            // 数値以外は、ＮＧ
            if (!Char.IsDigit(key))
            {
                // 小数点または、マイナス以外
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
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

            // マイナスのチェック
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // 小数点のチェック
            if (key == '.')
            {
                if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // キーが押された結果の文字列を生成する。
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // 桁数チェック！
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // 小数点以下のチェック
            if (priod > 0)
            {
                // 小数点の位置決定
                int _pointPos = _strResult.IndexOf('.');

                // 整数部に入力可能な桁数を決定！
                int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
                // 整数部の桁数をチェック
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (_strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // 小数部の桁数をチェック
                if (_pointPos != -1)
                {
                    // 小数部の桁数を計算
                    int _priketa = _strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Result_KeyDown(object sender, KeyEventArgs e)
        {
            // ↓ 2009.06.18 劉洋 add PVCS.209

            UltraGrid uGrid = (UltraGrid)sender;

            if ((uGrid.Rows.Count == 0) ||
                ((uGrid.ActiveCell == null) && (uGrid.ActiveRow == null)))
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        {
                            this.SetFocus("tNedit_BLGoodsCode");
                            break;
                        }
                    case Keys.Down:
                    case Keys.Right:
                        {
                            this.SetFocus("tNedit_BLGoodsCode");
                            break;
                        }
                    case Keys.Left:
                        {
                            this.SetFocus("tNedit_BLGoodsCode");
                            break;
                        }
                }
                return;
            }

            int rowIndex;
            int columnIndex;
            string columnKey;

            if (uGrid.ActiveCell != null)
            {
                // アクティブセル
                rowIndex = uGrid.ActiveCell.Row.Index;
                columnIndex = uGrid.ActiveCell.Column.Index;
                columnKey = uGrid.ActiveCell.Column.Key;
            }
            else
            {
                // アクティブ行
                rowIndex = uGrid.ActiveRow.Index;
                columnIndex = 0;
                columnKey = uGrid.ActiveRow.Cells[columnIndex].Column.Key;
            }

            string nextFocusColumn;
            bool doActivate = false;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        if (rowIndex == 0)
                        {
                            e.Handled = true;
                            this.SetFocus("tNedit_BLGoodsCode");
                            if (this.uGrid_Result.ActiveCell != null)
                            {
                                this.uGrid_Result.ActiveCell.Activated = false;
                            }
                        }
                        else
                        {
                            if (uGrid.ActiveCell != null)
                            {
                                // セルアクティブ＆DDL
                                if (uGrid.DisplayLayout.Bands[0].Columns[columnIndex].Style == Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList)
                                {
                                    e.Handled = true;
                                    if (uGrid.ActiveCell.ValueListResolved.SelectedItemIndex != 0)
                                    {
                                        // 選択中のValueListが最小でなければキー遷移しない
                                        uGrid.ActiveCell.ValueListResolved.SelectedItemIndex = uGrid.ActiveCell.ValueListResolved.SelectedItemIndex - 1;
                                        break;
                                    }
                                    else
                                    {
                                        for (int i = rowIndex - 1; i >= 0; i--)
                                        {
                                            if (uGrid.Rows[i].Cells[columnIndex].Activation == Activation.AllowEdit)
                                            {
                                                uGrid.Rows[i].Cells[columnIndex].Activate();
                                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                doActivate = true;
                                                break;
                                            }
                                        }

                                        if (!doActivate)
                                        {
                                            this.SetFocus("tNedit_BLGoodsCode");
                                            if (this.uGrid_Result.ActiveCell != null)
                                            {
                                                this.uGrid_Result.ActiveCell.Activated = false;
                                            }
                                        }

                                        break;
                                    }
                                }
                            }

                            if (uGrid.ActiveCell != null)
                            {
                                e.Handled = true;

                                for (int i = rowIndex; i >= 1; i--)
                                {
                                    // 表示行探し
                                    if (!uGrid.Rows[i - 1].IsFilteredOut)
                                    {
                                        if (uGrid.Rows[i - 1].Cells[columnIndex].Activation == Activation.AllowEdit)
                                        {
                                            uGrid.Rows[i - 1].Cells[columnIndex].Activate();
                                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            doActivate = true;
                                            break;
                                        }
                                        else
                                        {

                                            // 行アクティブ
                                            uGrid.Rows[i - 1].Activate();
                                            uGrid.Rows[i - 1].Selected = true;
                                            doActivate = true;
                                            break;

                                        }
                                    }
                                }

                                if (!doActivate)
                                {
                                    this.SetFocus("tNedit_BLGoodsCode");
                                    if (this.uGrid_Result.ActiveCell != null)
                                    {
                                        this.uGrid_Result.ActiveCell.Activated = false;
                                    }
                                }
                            }
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if (rowIndex == uGrid.Rows.Count - 1)
                        {
                            e.Handled = true;
                            this.SetFocus("tEdit_SectionCodeAllowZero");
                            if (this.uGrid_Result.ActiveCell != null)
                            {
                                this.uGrid_Result.ActiveCell.Activated = false;
                            }
                        }
                        else
                        {
                            if (uGrid.ActiveCell != null)
                            {
                                if (uGrid.DisplayLayout.Bands[0].Columns[columnIndex].Style == Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList)
                                {
                                    e.Handled = true;
                                    if (uGrid.ActiveCell.ValueListResolved.SelectedItemIndex != uGrid.ActiveCell.ValueListResolved.ItemCount - 1)
                                    {
                                        // 選択中のValueListが最大でなければキー遷移しない
                                        uGrid.ActiveCell.ValueListResolved.SelectedItemIndex = uGrid.ActiveCell.ValueListResolved.SelectedItemIndex + 1;
                                        break;
                                    }
                                    else
                                    {
                                        for (int i = rowIndex + 1; i < uGrid.Rows.Count; i++)
                                        {
                                            if (uGrid.Rows[i].Cells[columnIndex].Activation == Activation.AllowEdit)
                                            {
                                                uGrid.Rows[i].Cells[columnIndex].Activate();
                                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                doActivate = true;
                                                break;
                                            }
                                        }

                                        if (!doActivate)
                                        {
                                            this.SetFocus("tEdit_SectionCodeAllowZero");
                                            if (this.uGrid_Result.ActiveCell != null)
                                            {
                                                this.uGrid_Result.ActiveCell.Activated = false;
                                            }
                                        }

                                        break;
                                    }
                                }
                            }

                            if (uGrid.ActiveCell != null)
                            {
                                e.Handled = true;

                                for (int i = rowIndex; i < uGrid.Rows.Count - 1; i++)
                                {
                                    // 表示行探し
                                    if (!uGrid.Rows[i + 1].IsFilteredOut)
                                    {
                                        if (uGrid.Rows[i + 1].Cells[columnIndex].Activation == Activation.AllowEdit)
                                        {
                                            uGrid.Rows[i + 1].Cells[columnIndex].Activate();
                                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            doActivate = true;
                                            break;
                                        }
                                        else
                                        {

                                            // 行アクティブ
                                            uGrid.Rows[i + 1].Activate();
                                            uGrid.Rows[i + 1].Selected = true;
                                            doActivate = true;
                                            break;

                                        }
                                    }
                                }

                                if (!doActivate)
                                {
                                    this.SetFocus("tEdit_SectionCodeAllowZero");
                                    if (this.uGrid_Result.ActiveCell != null)
                                    {
                                        this.uGrid_Result.ActiveCell.Activated = false;
                                    }
                                }
                            }
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        if (uGrid.ActiveCell == null)
                        {
                            // 行アクティブ
                            int activationColIndex;
                            int activationRowIndex;

                            // 左はShift+Tabと同じ
                            nextFocusColumn = this.GetNextFocusColumnKey(columnIndex, rowIndex, true, out activationColIndex, out activationRowIndex);

                            if (nextFocusColumn != string.Empty)
                            {
                                uGrid.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                this.SetFocus("tNedit_BLGoodsCode");
                                if (this.uGrid_Result.ActiveCell != null)
                                {
                                    this.uGrid_Result.ActiveCell.Activated = false;
                                }
                            }

                            break;
                        }

                        if (
                            (uGrid.ActiveCell.IsInEditMode)
                            &&
                            ((uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Default) ||
                                (uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit) ||
                                (uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Date))
                            &&
                            (uGrid.ActiveCell.SelStart != 0)
                            )
                        {
                            break;
                        }
                        else
                        {
                            e.Handled = true;

                            int activationColIndex;
                            int activationRowIndex;

                            // 左はShift+Tabと同じ
                            nextFocusColumn = this.GetNextFocusColumnKey(columnIndex, rowIndex, true, out activationColIndex, out activationRowIndex);

                            if (nextFocusColumn != string.Empty)
                            {
                                uGrid.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                this.SetFocus("tNedit_BLGoodsCode");
                                if (this.uGrid_Result.ActiveCell != null)
                                {
                                    this.uGrid_Result.ActiveCell.Activated = false;
                                }
                            }
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        if (uGrid.ActiveCell == null)
                        {
                            // 行アクティブ
                            int activationColIndex;
                            int activationRowIndex;

                            // 右はTabと同じ
                            nextFocusColumn = this.GetNextFocusColumnKey(columnIndex, rowIndex, false, out activationColIndex, out activationRowIndex);

                            if (nextFocusColumn != string.Empty)
                            {
                                uGrid.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                this.SetFocus("tEdit_SectionCodeAllowZero");
                                if (this.uGrid_Result.ActiveCell != null)
                                {
                                    this.uGrid_Result.ActiveCell.Activated = false;
                                }
                            }
                            break;
                        }

                        if (
                            (uGrid.ActiveCell.IsInEditMode)
                            &&
                            ((uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Default) ||
                                (uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit) ||
                                (uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Date))
                            &&
                            (uGrid.ActiveCell.SelStart < uGrid.ActiveCell.Text.Length)
                            )
                        {
                            break;
                        }
                        else
                        {
                            e.Handled = true;

                            int activationColIndex;
                            int activationRowIndex;

                            // 右はTabと同じ
                            nextFocusColumn = this.GetNextFocusColumnKey(columnIndex, rowIndex, false, out activationColIndex, out activationRowIndex);

                            if (nextFocusColumn != string.Empty)
                            {
                                uGrid.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                this.SetFocus("tEdit_SectionCodeAllowZero");
                                if (this.uGrid_Result.ActiveCell != null)
                                {
                                    this.uGrid_Result.ActiveCell.Activated = false;
                                }
                            }
                        }

                        break;
                    }
            }

            // ↑ 2009.06.18 劉洋 add
        }

        /// <summary>
        /// 次の入力可能列のKeyを取得する
        /// </summary>
        /// <param name="colIndex">チェック開始列index、Activation可能列を返す</param>
        /// <param name="rowIndex">チェック開始行index、Activation可能行を返す</param>
        /// <param name="isShift">true:シフトあり false:シフトなし</param>
        /// <param name="ActivationColIndex">行番号</param>
        /// <param name="ActivationRowIndex">番号</param>
        /// <returns>Activation可能列のキー。ない場合はstring.Empty</returns>
        internal string GetNextFocusColumnKey(int colIndex, int rowIndex, bool isShift, out int ActivationColIndex, out int ActivationRowIndex)
        {
            ActivationColIndex = 0;
            ActivationRowIndex = 0;

            // 指定列の次の入力可能列を検索
            if (!isShift)
            {
                // シフト無
                for (int j = rowIndex; j < this.uGrid_Result.Rows.Count; j++)
                {
                    if (!this.uGrid_Result.Rows[j].IsFilteredOut) // ADD 2009/03/06
                    {
                        if (j == rowIndex)
                        {
                            // 指定行は指定カラムから先をチェック
                            for (int i = colIndex + 1; i < this.uGrid_Result.DisplayLayout.Bands[0].Columns.Count; i++)
                            {
                                if (this.uGrid_Result.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                    && this.uGrid_Result.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                    && this.uGrid_Result.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                {
                                    // 入力可能行のColumnKeyを取得
                                    ActivationColIndex = i;
                                    ActivationRowIndex = j;
                                    return this.uGrid_Result.DisplayLayout.Bands[0].Columns[i].Key;
                                }
                            }
                        }
                        else
                        {
                            // 次行以降はカラムを順にチェック
                            for (int i = 0; i < this.uGrid_Result.DisplayLayout.Bands[0].Columns.Count; i++)
                            {
                                if (this.uGrid_Result.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                    && this.uGrid_Result.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                    && this.uGrid_Result.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                {
                                    // 入力可能行のColumnKeyを取得
                                    ActivationColIndex = i;
                                    ActivationRowIndex = j;
                                    return this.uGrid_Result.DisplayLayout.Bands[0].Columns[i].Key;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                // シフトあり
                for (int j = rowIndex; j >= 0; j--)
                {
                    if (!this.uGrid_Result.Rows[j].IsFilteredOut) // ADD 2009/03/06
                    {
                        if (j == rowIndex)
                        {
                            for (int i = colIndex - 1; i >= 0; i--)
                            {
                                if (this.uGrid_Result.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                    && this.uGrid_Result.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                    && this.uGrid_Result.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                {
                                    // 入力可能行のColumnKeyを取得
                                    ActivationColIndex = i;
                                    ActivationRowIndex = j;
                                    return this.uGrid_Result.DisplayLayout.Bands[0].Columns[i].Key;
                                }
                            }
                        }
                        else
                        {
                            for (int i = this.uGrid_Result.DisplayLayout.Bands[0].Columns.Count - 1; i >= 0; i--)
                            {

                                if (this.uGrid_Result.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                    && this.uGrid_Result.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                    && this.uGrid_Result.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                {
                                    // 入力可能行のColumnKeyを取得
                                    ActivationColIndex = i;
                                    ActivationRowIndex = j;
                                    return this.uGrid_Result.DisplayLayout.Bands[0].Columns[i].Key;
                                }
                            }
                        }
                    }
                }
            }


            return string.Empty;
        }


        /// <summary>
        /// グリッドシフトタブ制御
        /// </summary>
        /// <param name="e">イベントハンドラ</param>
        internal void SetGridShiftTabFocus(ref ChangeFocusEventArgs e)
        {
            // 次フォーカス先カラム名
            string nextFocusColumn;
            int activationColIndex;
            int activationRowIndex;

            if (this.uGrid_Result.ActiveCell == null)
            {
                // アクティブなし または 行アクティブ
                e.NextCtrl = null;
                this.uGrid_Result.Focus();

                int colIndex = this.uGrid_Result.DisplayLayout.Bands[0].Columns.Count - 1;
                int rowIndex = this.uGrid_Result.Rows.Count - 1;

                if (this.uGrid_Result.ActiveRow != null)
                {
                    colIndex = 0;
                    rowIndex = uGrid_Result.ActiveRow.Index;
                }

                // 1行目の最後の入力可能行にフォーカス
                nextFocusColumn = this.GetNextFocusColumnKey(colIndex, rowIndex, true, out activationColIndex, out activationRowIndex);

                if (nextFocusColumn != string.Empty)
                {
                    this.uGrid_Result.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                    this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    this.SetFocus("tNedit_BLGoodsCode");
                    this.uGrid_Result.ActiveCell.Activated = false;
                }

                return;
            }
            else
            {
                // セルアクティブ
                int rowIndex = this.uGrid_Result.ActiveCell.Row.Index;
                int columnIndex = this.uGrid_Result.ActiveCell.Column.Index;

                // グリッド脱出時用のコントロールを保持
                e.NextCtrl = null;
                this.uGrid_Result.PerformAction(UltraGridAction.ExitEditMode);

                this.uGrid_Result.Focus();

                // 次セル取得
                nextFocusColumn = GetNextFocusColumnKey(columnIndex, rowIndex, true, out activationColIndex, out activationRowIndex);

                if (nextFocusColumn != string.Empty)
                {
                    this.uGrid_Result.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                    this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    if (this._userPriceInputAcs.UserPriceData.BLGoodsCode != 0)
                    {
                        this.SetFocus("tNedit_BLGoodsCode");
                    }
                    else
                    {
                        this.SetFocus("BLGoodsGuide_Button");
                    }
                    if (this.uGrid_Result.ActiveCell != null)
                    {
                        this.uGrid_Result.ActiveCell.Activated = false;
                    }
                }
            }
        }

        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        public bool ReturnKeyDown()
        {
            return MoveNextAllowEditCell(false);
        }

        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {

            this.uGrid_Result.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_Result.ActiveCell != null))
            {
                if ((!this.uGrid_Result.ActiveCell.Column.Hidden) &&
                    (this.uGrid_Result.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_Result.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }

            while (!moved)
            {

                performActionResult = this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                //performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);

                if (performActionResult)
                {
                    if ((this.uGrid_Result.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Result.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
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
                this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            this.uGrid_Result.ResumeLayout();
            return performActionResult;
        }

        /// <summary>
        /// グリッド設定
        /// </summary>
        public void SettingGrid()
        {
            UltraGridRow dr;

            for (int i = 0; i < this.uGrid_Result.Rows.Count; i++)
            {
                dr = this.uGrid_Result.Rows[i];

                this.SetGridColorRow(dr);
            }
        }


        /// <summary>
        /// BeforeCellDeactivate イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 編集モードが終了した時に発生します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private void uGrid_Result_BeforeCellDeactivate(object sender, CancelEventArgs e)
        {
            UltraGridRow dr;

            for (int i = 0; i < this.uGrid_Result.Rows.Count; i++)
            {
                dr = this.uGrid_Result.Rows[i];

                this.SetGridColorRow(dr);
            }
        }

        /// <summary>
        /// 各データの状態に応じた背景色を設定
        /// </summary>
        /// <remarks>
        /// <br>更新行：赤</br>
        /// <br>在庫登録されている商品：ピンク</br>
        /// </remarks>
        private void SetGridColorRow(UltraGridRow dr)
        {
            DataRow originalDr = this._userPriceInputAcs.UserPriceCopyDataTable.Select(
                this._userPriceInputAcs.UserPriceCopyDataTable.RowNoColumn.ColumnName + " ='"
                + dr.Cells[0].Value.ToString() + "'")[0];

            if (originalDr != null)
            {
                // ユーザー価格
                if (dr.Cells[4].Value.ToString() != originalDr[4].ToString())
                {
                    dr.Cells[4].Appearance.BackColor = Color.Red;
                    dr.Cells[4].Appearance.BackColor2 = Color.Red;
                    dr.Cells[4].Appearance.BackColorDisabled = Color.Red;
                    dr.Cells[4].Appearance.BackColorDisabled2 = Color.Red;
                }
                else
                {
                    dr.Cells[4].Appearance.BackColor = Color.Empty;
                    dr.Cells[4].Appearance.BackColor2 = Color.Empty;
                    dr.Cells[4].Appearance.BackColorDisabled = Color.Empty;
                    dr.Cells[4].Appearance.BackColorDisabled2 = Color.Empty;
                }

                // 仕入原価
                if (dr.Cells[6].Value.ToString() != originalDr[6].ToString())
                {
                    dr.Cells[6].Appearance.BackColor = Color.Red;
                    dr.Cells[6].Appearance.BackColor2 = Color.Red;
                    dr.Cells[6].Appearance.BackColorDisabled = Color.Red;
                    dr.Cells[6].Appearance.BackColorDisabled2 = Color.Red;
                }
                else
                {
                    if ("＊".Equals(dr.Cells[7].Value.ToString()))
                    {
                        dr.Cells[6].Appearance.BackColor = Color.Empty;
                        dr.Cells[6].Appearance.BackColor2 = Color.Empty;
                        dr.Cells[6].Appearance.BackColorDisabled = Color.Empty;
                        dr.Cells[6].Appearance.BackColorDisabled2 = Color.Empty;
                    }
                    else
                    {
                        dr.Cells[6].Appearance.BackColor = Color.Lime;
                        dr.Cells[6].Appearance.BackColor2 = Color.Lime;
                        dr.Cells[6].Appearance.BackColorDisabled = Color.Lime;
                        dr.Cells[6].Appearance.BackColorDisabled2 = Color.Lime;
                    }
                }
            }
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Result_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            if (this.uGrid_Result.ActiveCell != null)
            {
                if ((this.uGrid_Result.ActiveCell.Column.DataType == typeof(Double)))
                {

                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Result.ActiveCell.EditorResolved;

                    editorBase.Value = 0;
                    this.uGrid_Result.ActiveCell.Value = 0;
                }

                e.RaiseErrorEvent = false;	
            }
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Result_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Result.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Result.ActiveCell;

            if (cell == null) return;
            int rowIndex = cell.Row.Index;

            if (cell.Value is DBNull)
            {
                if ((cell.Column.DataType == typeof(Int32)) ||
                    (cell.Column.DataType == typeof(Int64)))
                {
                    cell.Value = 0;
                }
                else if (cell.Column.DataType == typeof(double))
                {
                    cell.Value = 0.0;
                }
                else if (cell.Column.DataType == typeof(string))
                {
                    cell.Value = "";
                }
            }
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void PMKHN09421UB_Leave(object sender, EventArgs e)
        {
            this.uGrid_Result.ActiveCell = null;
            this.uGrid_Result.ActiveRow = null;
            this.uGrid_Result.Selected.Rows.Clear();
        }
        #endregion
    }
}

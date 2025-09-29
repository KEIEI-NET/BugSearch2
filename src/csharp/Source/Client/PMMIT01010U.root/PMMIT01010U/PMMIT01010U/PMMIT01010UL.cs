using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Text;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 検索見積 発注選択明細入力コントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 検索見積のUOE発注での明細入力を行うコントロールクラスです。</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2008.10.17</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2008.10.17 men 新規作成</br>
    /// </remarks>
    public partial class PMMIT01010UL : UserControl
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region ■Constructor

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="estimateInputOrderSelectAcs">検索見積発注選択アクセスクラス</param>
        public PMMIT01010UL(EstimateInputOrderSelectAcs estimateInputOrderSelectAcs)
        {
            InitializeComponent();
            this._estimateInputInitDataAcs = EstimateInputInitDataAcs.GetInstance();
            this._estimateInputOrderSelectAcs = estimateInputOrderSelectAcs;
            this._imageList16 = IconResourceManagement.ImageList16;

            this._orderCancelButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_OrderCancel"];
        }

        #endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region ■Private Members

        private ImageList _imageList16 = null;									// イメージリスト
        //private DataTable _dataTable;
        //private DataView _detailView;
        private int _supplierCd;
        private UOESupplier _uOESupplier;

        private Int32 _beforeInt32Value = 0;
        private string _beforeStringValue = "";

        private bool _afterCellUpdateCancel;
        private bool _beforeCellUpdateCancel;

        private EstimateInputInitDataAcs _estimateInputInitDataAcs;
        private EstimateInputOrderSelectAcs _estimateInputOrderSelectAcs;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _orderCancelButton;

        #endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        #region ■Properties

        /// <summary>仕入先コード</summary>
        public int SupplierCd
        {
            set 
            {                 
                _supplierCd = value;
                //this.SettingFilter();
            }
        }

        /// <summary>発注先マスタオブジェクト</summary>
        public UOESupplier UOESupplier
        {
            set
            {
                _uOESupplier = value;
            }
        }

        #endregion

        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        #region ■Delegate

        /// <summary>
        /// 明細データ変更デリゲート
        /// </summary>
        /// <param name="supplierCd">仕入先コード</param>
        internal delegate void DetailDataChangedEventHandler(int supplierCd);

        #endregion


        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        #region ■Events
        /// <summary>グリッド最上位行キーダウンイベント</summary>
        internal event EventHandler GridKeyDownTopRow;

        /// <summary>明細情報変更イベント</summary>
        internal DetailDataChangedEventHandler DetailDataChanged; 
        #endregion


        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■Private Methods

        /// <summary>
        /// 明細データ変更イベントコール処理
        /// </summary>
        private void DetailDataChangedCall()
        {
            if (this.DetailDataChanged != null)
            {
                this.DetailDataChanged(this._supplierCd);
            }
        }

        /// <summary>
        /// Returnキーダウン処理
        /// </summary>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        internal bool ReturnKeyDown()
        {
            if (this.uGrid_Details.ActiveCell == null) return false;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
            int rowIndex = cell.Row.Index;

            try
            {
                this.uGrid_Details.SuspendLayout();
                this.uGrid_Details.BeginUpdate();

                bool canMove = true;

                // セル編集モードの場合
                if (cell.IsInEditMode)
                {
                    string beforeCellKey = cell.Column.Key;

                    // セルを更新する
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                    // ActiveCellが変更していない場合はNextCellを取得する
                    if (this.uGrid_Details.ActiveCell.Column.Key == beforeCellKey)
                    {
                        // BeforeCellUpdateでキャンセルフラグがたっている場合はセル移動無し
                        if (this._beforeCellUpdateCancel)
                        {
                            this._beforeCellUpdateCancel = false;
                        }
                        // AfterCellUpdateでキャンセルフラグがたっている場合はセル移動無し
                        else if (this._afterCellUpdateCancel)
                        {
                            this._afterCellUpdateCancel = false;
                        }
                        else
                        {
                            canMove = this.MoveReturnCell();
                        }
                    }
                }
                else
                {
                    // 次入力可能セル移動処理
                    canMove = this.MoveReturnCell();
                }

                if (!canMove)
                {
                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex].Cells[cell.Column.Key];
                    this.uGrid_Details.Rows[rowIndex].Cells[cell.Column.Key].Selected = true; // 編集不可項目のフォーカスカラー対応
                    this.uGrid_Details.ActiveRow = this.uGrid_Details.Rows[rowIndex];
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
                return canMove;
            }
            finally
            {
                this.uGrid_Details.EndUpdate();
                this.uGrid_Details.ResumeLayout();
            }
        }

        /// <summary>
        /// Returnキーセル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:次移動先算出を行わない</param>
        /// <returns></returns>
        internal bool MoveReturnCell()
        {
            return MoveNextAllowEditCell(false);
        }


        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            this.uGrid_Details.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

            if (( activeCellCheck ) && ( this.uGrid_Details.ActiveCell != null ))
            {
                if (( !this.uGrid_Details.ActiveCell.Column.Hidden ) &&
                    ( this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ) &&
                    ( this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ))
                {
                    moved = true;
                }
            }

            while (!moved)
            {
                //if (this.uGrid_Details.ActiveCell != null)
                //{
                //    int editMode = (int)this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Cells[this._stockDetailDataTable.EditStatusColumn.ColumnName].Value;

                //    if (( editMode == StockSlipInputAcs.ctEDITSTATUS_AllDisable ) || ( editMode == StockSlipInputAcs.ctEDITSTATUS_AllReadOnly ))
                //    {
                //        performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextRow);

                //        if (( performActionResult ) && ( this.uGrid_Details.ActiveRow != null ))
                //        {
                //            int index = this.uGrid_Details.ActiveRow.Index;

                //            if (!( this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.GoodsCodeColumn.ColumnName].Hidden ))
                //            {
                //                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[index].Cells[this._stockDetailDataTable.GoodsCodeColumn.ColumnName];
                //            }
                //            else
                //            {
                //                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[index].Cells[this._stockDetailDataTable.GoodsNameColumn.ColumnName];
                //            }

                //            // 再帰処理
                //            this.MoveNextAllowEditCell(true);

                //            return true;
                //        }
                //    }
                //}

                performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                //performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);

                if (performActionResult)
                {
                    if (( this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ) &&
                        ( this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ))
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
                if (( key != '.' ) && ( key != '-' ))
                {
                    return false;
                }
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string _strResult = string.Empty;
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - ( selstart + sellength ));
            }
            else
            {
                _strResult = prevVal;
            }

            // マイナスのチェック
            if (key == '-')
            {
                if (( minusFlg == false ) || ( selstart > 0 ) || ( _strResult.IndexOf('-') != -1 ))
                {
                    return false;
                }
            }

            // 小数点のチェック
            if (key == '.')
            {
                if (( priod <= 0 ) || ( _strResult.IndexOf('.') != -1 ))
                {
                    return false;
                }
            }
            // キーが押された結果の文字列を生成する。
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - ( selstart + sellength ));

            // 桁数チェック！
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > ( keta + 1 ))
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
                int _Rketa = ( _strResult[0] == '-' ) ? keta - priod : keta - priod - 1;
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
        /// グリッドキーマッピング設定処理
        /// </summary>
        /// <param name="ultraGrid">設定対象のグリッド</param>
        private void MakeKeyMappingForGrid(Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid)
        {
            Infragistics.Win.UltraWinGrid.GridKeyActionMapping enterMap;

            //----- Enterキー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- Shift + Enterキー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.AltCtrl,
                Infragistics.Win.SpecialKeys.Shift,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

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
        /// 明細グリッド設定処理
        /// </summary>
        internal void SettingGrid()
        {
            try
            {
                // 描画を一時停止
                this.uGrid_Details.BeginUpdate();

                // 描画が必要な明細件数を取得する。
                int cnt = this.uGrid_Details.Rows.Count;

                // 各行ごとの設定
                for (int i = 0; i < cnt; i++)
                {
                    this.SettingGridRow(i);
                }

                if (this.uGrid_Details.ActiveCell != null)
                {
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                // 描画を開始
                this.uGrid_Details.EndUpdate();
            }
        }

        /// <summary>
        /// 明細グリッド・行単位でのセル設定
        /// </summary>
        /// <param name="rowIndex">対象行インデックス</param>
        /// <param name="stockSlip">仕入データクラスオブジェクト</param>
        private void SettingGridRow(int rowIndex)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if (editBand == null) return;

            // 指定行の全ての列に対して設定を行う。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // セル情報を取得
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.Rows[rowIndex].Cells[col];
                if (cell == null) continue;

                cell.Row.Hidden = false;

                // アンダーラインを全てのセルに対して非表示とする
                cell.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.False;

                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                // BOコードを取得
                string boCode = (string)this.uGrid_Details.Rows[rowIndex].Cells[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode].Value;

                // 倉庫コードを取得
                string warehouseCode = (string)this.uGrid_Details.Rows[rowIndex].Cells[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_WarehouseCode].Value;

                #region セル背景色変更

                if (cell.Column.Key == EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode)
                {
                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }
                else if (cell.Column.Key == EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt)
                {
                    cell.Activation = ( boCode == "*" ) ? Infragistics.Win.UltraWinGrid.Activation.NoEdit : Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

                    if (cell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
                    {
                    }
                }
                else if (cell.Column.Key == EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_ShipmentPosCnt)
                {
                    if (string.IsNullOrEmpty(warehouseCode))
                    {
                        cell.Appearance.ForeColor = Color.Transparent;
                    }
                    else
                    {
                        cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.CellAppearance.ForeColor;
                    }
                }
                #endregion
            }
        }

        #region Control Events

        /// <summary>
        /// ユーザーコントロール Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMMIT01010UL_Load(object sender, EventArgs e)
        {
            //this.uGrid_Details.DataSource = this._detailView;
            this.uGrid_Details.DataSource = this._estimateInputOrderSelectAcs.DetailView;
            this.tToolbarsManager_Main.ImageListSmall = this._imageList16;
            //this._orderCancelButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.can;

            // グリッドキーマッピング設定処理
            this.MakeKeyMappingForGrid(this.uGrid_Details);

            this.SettingGrid();
        }

        #region グリッド関連
        /// <summary>
        /// グリッド InitializeLayoutイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            string moneyFormat = "#,##0;-#,##0;''";
            string decimalFormat_Zero = "#,##0.00;-#,##0.00;'0'";

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //非表示設定
                column.Hidden = true;
                column.Header.Fixed = false;
                //入力許可設定
                //column.AutoEdit = false;
            }

            int visiblePosition = 1;
            //--------------------------------------------------------------------------------
            //  表示するカラム情報
            //--------------------------------------------------------------------------------
            #region カラム情報の設定

            // BO
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].Hidden = false;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].CellAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;

            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].TabStop = false;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].Header.VisiblePosition = visiblePosition++;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].MaxLength = 4;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].Header.Caption = "№";
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].Width = 40;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].Header.Fixed = true;

            // BO
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode].Hidden = false;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode].Header.VisiblePosition = visiblePosition++;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode].MaxLength = 4;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode].Header.Caption = "BO";
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode].Width = 40;

            // 発注数
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt].Hidden = false;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt].Header.VisiblePosition = visiblePosition++;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt].Format = moneyFormat;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt].Header.Caption = "発注数";
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt].Width = 70;

            // 品名

            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_GoodsName].Hidden = false;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_GoodsName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_GoodsName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_GoodsName].Header.VisiblePosition = visiblePosition++;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_GoodsName].Header.Caption = "品名";
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_GoodsName].Width = 200;

            // 品番
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_GoodsNo].Hidden = false;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_GoodsNo].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_GoodsNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_GoodsNo].Header.VisiblePosition = visiblePosition++;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_GoodsNo].Header.Caption = "品番";
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_GoodsNo].Width = 200;

            // 倉庫
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_WarehouseCode].Hidden = false;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_WarehouseCode].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_WarehouseCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_WarehouseCode].Header.VisiblePosition = visiblePosition++;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_WarehouseCode].Header.Caption = "倉庫";
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_WarehouseCode].Width = 60;

            // 現在庫数
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_ShipmentPosCnt].Hidden = false;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_ShipmentPosCnt].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_ShipmentPosCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_ShipmentPosCnt].Header.VisiblePosition = visiblePosition++;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_ShipmentPosCnt].Format = decimalFormat_Zero;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_ShipmentPosCnt].Header.Caption = "現在庫数";
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_ShipmentPosCnt].Width = 80;


            #endregion

            // 固定列区切り線設定
            this.uGrid_Details.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;

            this.uGrid_Details.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
        }

        /// <summary>
        /// グリッドセルアクティブ後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_AfterCellActivate(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            //// セルアクティブ時ボタン有効無効コントロール処理
            //this.ActiveCellButtonEnabledControl(cell.Row.Index, cell.Column.Key);

            this._beforeCellUpdateCancel = false;
            this._afterCellUpdateCancel = false;
        }

        /// <summary>
        /// グリッドセルアップデート後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>        
        private void uGrid_Details_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (e.Cell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;

            int rowIndex = e.Cell.Row.Index;

            if (e.Cell.Value is DBNull)
            {
                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                this.uGrid_Details.BeforeCellUpdate -= this.uGrid_Details_BeforeCellUpdate;
                if (( e.Cell.Column.DataType == typeof(Int32) ) ||
                    ( e.Cell.Column.DataType == typeof(Int64) ) ||
                    ( e.Cell.Column.DataType == typeof(double) ))
                {
                    e.Cell.Value = 0;
                }
                else if (e.Cell.Column.DataType == typeof(string))
                {
                    e.Cell.Value = string.Empty;
                }
                this.uGrid_Details.BeforeCellUpdate += this.uGrid_Details_BeforeCellUpdate;
                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
            }

            Guid dtlRelationGuid = (Guid)this.uGrid_Details.Rows[cell.Row.Index].Cells[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_DtlRelationGuid].Value;

            // 発注数
            if (cell.Column.Key == EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt)
			{
                int orderCnt = TStrConv.StrToIntDef(e.Cell.Value.ToString(), 0);

                if (orderCnt == 0)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "発注数が入力されていません。",
                        -1,
                        MessageBoxButtons.OK);

                    this.uGrid_Details.Rows[rowIndex].Cells[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt].Value = this._beforeInt32Value;

                    this._afterCellUpdateCancel = true;
                }
                else
                {
                    this.DetailDataChangedCall();
                }
			}
            // BOコード
            else if (cell.Column.Key == EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode)
            {
                string boCode = cell.Value.ToString();
                string boCodeName = this._estimateInputInitDataAcs.GetName_FromUOEGuideName(EstimateInputInitDataAcs.ctUOEGuideDivCd_BoCode, this._uOESupplier.UOESupplierCd, boCode);

                if (boCode == "*")
                {
                    this._estimateInputOrderSelectAcs.DetailOrderCancel(dtlRelationGuid);
                    this.DetailDataChanged(this._supplierCd);
                }
                else if (!this._estimateInputOrderSelectAcs.ChackCanOrder(dtlRelationGuid))
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "発注できないメーカーの部品です。",
                        -1,
                        MessageBoxButtons.OK);
                    this.uGrid_Details.Rows[rowIndex].Cells[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode].Value = this._beforeStringValue;

                    this._afterCellUpdateCancel = true;
                }

                else if (string.IsNullOrEmpty(boCodeName))
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "該当するＢＯコードが存在しません。",
                        -1,
                        MessageBoxButtons.OK);
                    this._afterCellUpdateCancel = true;

                    this.uGrid_Details.Rows[rowIndex].Cells[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode].Value = this._beforeStringValue;
                }
                else
                {
                    // "*"から変更された場合は発注数の初期値を表示
                    if (this._beforeStringValue == "*")
                    {
                        this._estimateInputOrderSelectAcs.DetailSettingDefaultOrderCnt(dtlRelationGuid);
                    }
                }
                this.SettingGridRow(rowIndex);
                this.DetailDataChangedCall();
            }
        }

        /// <summary>
        /// Gridアクション処理後イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_AfterPerformAction(object sender, Infragistics.Win.UltraWinGrid.AfterUltraGridPerformActionEventArgs e)
        {
            switch (e.UltraGridAction)
            {
                case Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell:

                    // アクティブなセルがあるか？または編集可能セルか？
                    if (( this.uGrid_Details.ActiveCell != null ) && ( this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ) && ( this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ))
                    {
                        // アクティブセルのスタイルを取得
                        switch (this.uGrid_Details.ActiveCell.StyleResolved)
                        {
                            // エディット系スタイル
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    // 編集モードにある？
                                    if (this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode))
                                    {
                                        if (!( this.uGrid_Details.ActiveCell.Value is System.DBNull ))
                                        {
                                            // 全選択状態にする。
                                            this.uGrid_Details.ActiveCell.SelStart = 0;
                                            this.uGrid_Details.ActiveCell.SelLength = this.uGrid_Details.ActiveCell.Text.Length;
                                        }
                                    }
                                    break;
                                }
                            default:
                                {
                                    // エディット系以外のスタイルであれば、編集状態にする。
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    break;
                                }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// グリッド行アクティブ後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveRow == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Details.ActiveRow;
        }

        /// <summary>
        /// グリッドセルアクティブ化前イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            // IMEを起動しない
            this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Disable;
        }

        /// <summary>
        /// グリッドセル非アクティブ化前発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_BeforeCellDeactivate(object sender, CancelEventArgs e)
        {
        }

        /// <summary>
        /// グリッドセルアップデート前イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_BeforeCellUpdate(object sender, Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs e)
        {
            if (e.Cell == null) return;

            if (( this._uOESupplier == null ) || ( this._uOESupplier.SupplierCd == 0 ))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "発注先が入力されていません",
                    -1,
                    MessageBoxButtons.OK);
                this._beforeCellUpdateCancel = true;
                e.Cancel = true;
                return;
            }

            this._beforeCellUpdateCancel = false;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;

            this._beforeStringValue = string.Empty;
            this._beforeInt32Value = 0;

            if (this._estimateInputOrderSelectAcs.DetailTable.Columns.Contains(cell.Column.Key))
            {
                if (this._estimateInputOrderSelectAcs.DetailTable.Columns[cell.Column.Key].DataType == typeof(System.String))
                {
                    this._beforeStringValue = ( e.Cell.Value is DBNull ) ? string.Empty : e.Cell.Value.ToString();
                }
                else if (this._estimateInputOrderSelectAcs.DetailTable.Columns[cell.Column.Key].DataType == typeof(System.Int32))
                {
                    this._beforeInt32Value = ( e.Cell.Value is DBNull ) ? 0 : Convert.ToInt32(e.Cell.Value);
                }
            }
        }


        /// <summary>
        /// グリッドデータエラー発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_CellDataError(object sender, Infragistics.Win.UltraWinGrid.CellDataErrorEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                // 数値項目の場合
                if (( this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int32) ) ||
                    ( this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int64) ) ||
                    ( this.uGrid_Details.ActiveCell.Column.DataType == typeof(double) ))
                {
                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Details.ActiveCell.EditorResolved;

                    // 未入力は0にする
                    if (string.IsNullOrEmpty(editorBase.CurrentEditText.Trim()))
                    {
                        editorBase.Value = 0;				// 0をセット
                        this.uGrid_Details.ActiveCell.Value = 0;
                    }
                    // 数値項目に「-」or「.」だけしか入ってなかったら駄目です
                    else if (( editorBase.CurrentEditText.Trim() == "-" ) ||
                        ( editorBase.CurrentEditText.Trim() == "." ) ||
                        ( editorBase.CurrentEditText.Trim() == "-." ))
                    {
                        editorBase.Value = 0;				// 0をセット
                        this.uGrid_Details.ActiveCell.Value = 0;
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
                            editorBase.Value = 0;
                            this.uGrid_Details.ActiveCell.Value = 0;
                        }
                    }
                    e.RaiseErrorEvent = false;			// エラーイベントは発生させない
                    e.RestoreOriginalValue = false;		// セルの値を元に戻さない
                    e.StayInEditMode = false;			// 編集モードは抜ける
                }
            }
        }

        /// <summary>
        /// グリッドキーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

                if (e.KeyCode == Keys.Escape)
                {

                    // 明細グリッドセル設定処理
                    this.SettingGrid();
                }

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
                                if (( this.uGrid_Details.ActiveCell != null ) && ( this.uGrid_Details.ActiveCell.IsInEditMode ))
                                {
                                    // 編集モードの場合はなにもしない
                                }
                                else
                                {
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid);
                                    this.MoveNextAllowEditCell(true);
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                if (( this.uGrid_Details.ActiveCell != null ) && ( this.uGrid_Details.ActiveCell.IsInEditMode ))
                                {
                                    // 編集モードの場合はなにもしない
                                }
                                else
                                {
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInGrid);
                                }
                                break;
                            }
                    }
                }
                else if (e.Alt)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                            {
                                if (( cell.Column.Style != Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown ) &&
                                    ( cell.Column.Style != Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList ) &&
                                    ( cell.Column.Style != Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate ))
                                {
                                    ( (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.tToolbarsManager_Main.Tools["PopupMenuTool_Edit"] ).ShowPopup(System.Windows.Forms.Cursor.Position, this.uGrid_Details);
                                }

                                break;
                            }
                    }
                }
                else if (e.Control)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Home:
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid);
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                e.Handled = true;
                                break;
                            }
                        case Keys.End:
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInGrid);
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                e.Handled = true;
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
                                    }
                                    break;
                                }
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
                                if (( this.uGrid_Details.ActiveCell != null ) && ( this.uGrid_Details.ActiveCell.IsInEditMode ))
                                {
                                    // 編集モードの場合はなにもしない
                                }
                                else
                                {
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInRow);
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    e.Handled = true;
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                // 編集モードの場合はなにもしない
                                if (( this.uGrid_Details.ActiveCell != null ) && ( this.uGrid_Details.ActiveCell.IsInEditMode ))
                                {
                                    //
                                }
                                else
                                {
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInRow);
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    e.Handled = true;
                                }
                                break;
                            }
                        case Keys.Up:
                            {
                                if (( this.uGrid_Details.ActiveCell != null ) && ( !this.uGrid_Details.ActiveCell.DroppedDown ))
                                {
                                    if (this.uGrid_Details.ActiveCell.Row.Index == 0)
                                    {
                                        if (this.GridKeyDownTopRow != null)
                                        {
                                            this.GridKeyDownTopRow(this, new EventArgs());
                                            e.Handled = true;
                                        }
                                    }
                                }

                                break;
                            }
                        case Keys.Down:
                            {
                                if (this.uGrid_Details.ActiveCell.Row.Index == this.uGrid_Details.Rows.Count - 1)
                                {
                                    if (e.KeyCode == Keys.Down)
                                    {
                                        //if (this.GridKeyDownButtomRow != null)
                                        //{
                                        //    this.GridKeyDownButtomRow(this, new EventArgs());
                                        //    e.Handled = true;
                                        //}
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
                    case Keys.Delete:
                        {
                            //this.uButton_RowDelete_Click(this.uButton_RowDelete, new EventArgs());
                            break;
                        }
                }

                if (this.uGrid_Details.ActiveRow.Index == 0)
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        if (this.GridKeyDownTopRow != null)
                        {
                            this.GridKeyDownTopRow(this, new EventArgs());
                            e.Handled = true;
                        }
                    }
                }
                else if (this.uGrid_Details.ActiveRow.Index == this.uGrid_Details.Rows.Count - 1)
                {
                    //if (e.KeyCode == Keys.Down)
                    //{
                    //    if (this.GridKeyDownButtomRow != null)
                    //    {
                    //        this.GridKeyDownButtomRow(this, new EventArgs());
                    //        e.Handled = true;
                    //    }
                    //}
                }
            }
        }


        /// <summary>
        /// グリッドキープレスイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            if (cell.Column.Key == EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(3, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// グリッドキーアップイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
        }

        /// <summary>
        /// グリッドエンターイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_Enter(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                if (!this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell) || ( this.uGrid_Details.ActiveCell == null ))
                {
                    if (this.uGrid_Details.Rows.Count > 0)
                    {
                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[0].Cells[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode];
                    }
                }
            }
            if (this.uGrid_Details.ActiveCell != null)
            {
                if (( !this.uGrid_Details.ActiveCell.IsInEditMode ) &&
                    ( this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ) &&
                    ( this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ))
                {
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
                else
                {
                    // 次入力可能セル移動処理
                    this.MoveNextAllowEditCell(true);
                }
            }
            // グリッドセルアクティブ後発生イベント
            this.uGrid_Details_AfterCellActivate(this.uGrid_Details, new EventArgs());
        }

        /// <summary>
        /// 明細グリッドリーヴイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {

        }

        #endregion

        /// <summary>
        /// 取消ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_OrderCancel_Click(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
            Infragistics.Win.UltraWinGrid.SelectedRowsCollection rows = this.uGrid_Details.Selected.Rows;

            if (( cell == null ) && ( rows == null )) return;

            if (cell != null)
            {
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);
                this._estimateInputOrderSelectAcs.OrderCancel((Guid)this.uGrid_Details.Rows[cell.Row.Index].Cells[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_DtlRelationGuid].Value);
                this.SettingGridRow(cell.Row.Index);
                this.DetailDataChangedCall();
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }
            else if (rows != null)
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in rows)
                {
                    this._estimateInputOrderSelectAcs.OrderCancel((Guid)row.Cells[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_DtlRelationGuid].Value);
                }
                this.SettingGrid();
                this.DetailDataChangedCall();
            }
        }

        #endregion

        /// <summary>
        /// 明細グリッド　MouseClickイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_MouseClick(object sender, MouseEventArgs e)
        {
            // 右クリック以外の場合
			if (e.Button != MouseButtons.Right) return;

            System.Drawing.Point nowPos = new Point(e.X, e.Y);

            Infragistics.Win.UIElement objElement = this.uGrid_Details.DisplayLayout.UIElement.ElementFromPoint(nowPos);

            // クリック位置が列ヘッダーか判定
            bool isColumnHeader = false;

            if (objElement != null)
            {
                if (( objElement.SelectableItem is Infragistics.Win.UltraWinGrid.ColumnHeader ) ||
                    ( objElement is Infragistics.Win.UltraWinGrid.HeaderUIElement ))
                {
                    isColumnHeader = true;
                    // string columnName = ((Infragistics.Win.UltraWinGrid.ColumnHeader)objElement.SelectableItem).Column.Key;
                }
            }

            if (isColumnHeader)
            {
                // 列ヘッダー右クリック時は何もしない
            }
            else
            {
                // それ以外で右クリックされた場合は、編集のポップアップを表示する
                ( (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.tToolbarsManager_Main.Tools["PopupMenuTool_Edit"] ).ShowPopup(System.Windows.Forms.Cursor.Position, this.uGrid_Details);

                if (( this.uGrid_Details.ActiveCell == null ) && ( this.uGrid_Details.ActiveRow != null ))
                {
                    if (this.uGrid_Details.ActiveRow.Selected)
                    {
                        //
                    }
                    else
                    {
                        this.uGrid_Details.Selected.Rows.Clear();
                        this.uGrid_Details.ActiveRow.Selected = true;
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// ツールクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tToolbarsManager_Main_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_OrderCancel":
                    this.uButton_OrderCancel_Click(this.uGrid_Details, new EventArgs());
                    break;
                default:
                    break;
            }
        }

    }
}

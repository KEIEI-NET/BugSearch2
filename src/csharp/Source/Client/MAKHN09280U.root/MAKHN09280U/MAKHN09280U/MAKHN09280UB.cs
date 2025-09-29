using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources; // ADD K2013/05/13 王君 Redmine#35663

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 価格情報入力コントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品マスメンの価格情報入力を行うコントロールクラスです。</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2008.6.18</br>
    /// <br>Update Note: 2009.02.03 30414 忍 幸史 障害ID:10848対応</br>
    /// <br>Update Note: 2009.02.10 30414 忍 幸史 障害ID:11234対応</br>
    /// <br>Update Note: 2010.01.05 30434 工藤    障害ID:14816対応</br>
    /// <br>Update Note: K2013/05/13 王君</br>
    /// <br>管理番号   : 10901273-00 2013/06/18配信分</br>
    /// <br>             Redmine#35663 商品在庫マスタ・山形部品様個別組み込み</br>
    /// </remarks>
    public partial class MAKHN09280UB : UserControl
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        private GoodsAcs _goodsAcs;                                         // 商品マスタアクセスクラス
        //private GoodsInputDataSet.GoodsPriceDataTable _goodsPriceDataTable; // 商品価格データテーブル // DEL 2010/08/09
        internal GoodsInputDataSet.GoodsPriceDataTable _goodsPriceDataTable; // 商品価格データテーブル // ADD 2010/08/09
        private GoodsUnitData _goodsUnitData;                               // 商品連結データクラス
        private DateTime _beforePriceStartDate = DateTime.MinValue;
        private double _beforeListPrice = 0;
        private double _beforeStockRate = 0;
        private double _beforeSalesUnitCost = 0;
        private DateTime _beforeOfferDate = DateTime.MinValue;
        private bool _beforeCellUpdateCancel = false;
        // --- ADD K2013/05/13 王君 Redmine#35663 ---------->>>>>
        /// <summary> 山形部品オプションフラグ</summary>
        private int _opt_YamagataCtrl;
        /// <summary> 仕入率/原単価修正可否フラグ</summary>
        private bool _cstChangeEnable = false;
        /// <summary> 在庫数修正可否フラグ</summary>
        private bool _stcChangeEnable = false;
        // --- ADD ADD K2013/05/13 王君 Redmine#35663 ----------<<<<<

        private bool _parentEnabled = true;

        private object _beforeOpenPriceDiv; // ADD 2010/08/09

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/18 DEL
        //public MAKHN09280UB()
        //{
        //    InitializeComponent();

        //    this._goodsAcs = new GoodsAcs();
        //    this._goodsPriceDataTable = this._goodsAcs.GoodsPriceDataTable;
        //    this._goodsUnitData = new GoodsUnitData();
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/18 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/18 ADD
        /// <remarks>
        /// <br>Update Note: K2013/05/13 王君</br>
        /// <br>管理番号   : 10901273-00 2013/06/18配信分</br>
        /// <br>             Redmine#35663 商品在庫マスタ・山形部品様個別組み込み</br>
        /// </remarks>
        public MAKHN09280UB( GoodsAcs goodsAcs, GoodsUnitData goodsUnitData )
        {
            InitializeComponent();

            this._goodsAcs = goodsAcs;
            this._goodsPriceDataTable = this._goodsAcs.GoodsPriceDataTable;
            this._goodsUnitData = goodsUnitData;
            // --- ADD K2013/05/13 王君 Redmine#35663 ---------->>>>>
            // オプション情報キャッシュ
            CacheOptionInfo();
            if (this._opt_YamagataCtrl == (int)MAKHN09280UA.Option.ON)
            {
                this._goodsAcs.GetYmgtMngChangeEnable(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode, out this._cstChangeEnable, out this._stcChangeEnable); // 仕入率/原単価修正可否フラグ
            }
            // --- ADD K2013/05/13 王君 Redmine#35663 ----------<<<<<
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/18 ADD

        //----- ADD K2013/05/13 王君 Redmine#35663 ----->>>>>
        /// <summary>
        /// オプション情報キャッシュ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オプション情報制御処理。</br>
        /// <br>Programmer : 王君</br>
        /// <br>Date       : K2013/05/13</br>
        /// </remarks>
        private void CacheOptionInfo()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;

            #region ●山形部品オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_YamagataCustomControl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_YamagataCtrl = (int)Broadleaf.Windows.Forms.MAKHN09280UA.Option.ON;
            }
            else
            {
                this._opt_YamagataCtrl = (int)Broadleaf.Windows.Forms.MAKHN09280UA.Option.OFF;
            }
            #endregion
        }
        //-----  ADD K2013/05/13 王君 Redmine#35663 -----<<<<<

        // ===================================================================================== //
        // 定数
        // ===================================================================================== //

        // ===================================================================================== //
        // デリゲート
        // ===================================================================================== //
        /// <summary>
        /// 価格情報設定デリゲート
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="rowNo"></param>
        internal delegate void SettingGoodsPriceEventHandler(object sender, int rowNo);
        
        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        /// <summary>グリッド最上位行キーダウンイベント</summary>
        internal event EventHandler GridKeyDownTopRow;

        /// <summary>グリッド最下層行キーダウンイベント</summary>
        internal event EventHandler GridKeyDownButtomRow;

        /// <summary>価格情報設定イベント</summary>
        internal event SettingGoodsPriceEventHandler SettingGoodsPrice;
        
        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        /// <summary>
        /// 商品連結データクラス
        /// </summary>
        public GoodsUnitData GoodsUnitData
        {
            get { return this._goodsUnitData; }
            set { this._goodsUnitData = value; }
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
        /// <summary>
        /// 商品アクセスクラス
        /// </summary>
        public GoodsAcs GoodsAcs
        {
            get { return this._goodsAcs; }
            set 
            { 
                this._goodsAcs = value;
                this._goodsPriceDataTable = this._goodsAcs.GoodsPriceDataTable;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        /// <summary>
        /// グリッドキーマッピング設定処理
        /// </summary>
        /// <param name="grid">設定対象のグリッド</param>
        private void MakeKeyMappingForGrid(Infragistics.Win.UltraWinGrid.UltraGrid grid)
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
            this.uGrid_GoodsPriceInfo.KeyActionMappings.Add(enterMap);

            //----- Shift + Enterキー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.AltCtrl,
                Infragistics.Win.SpecialKeys.Shift,
                true);
            this.uGrid_GoodsPriceInfo.KeyActionMappings.Add(enterMap);

            //----- ↑キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_GoodsPriceInfo.KeyActionMappings.Add(enterMap);

            //----- ↑キー (最上段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_GoodsPriceInfo.KeyActionMappings.Add(enterMap);

            //----- ↓キー (最下段のドロップダウンリストでは何もしない。これが無いとリスト項目が変わってしまうので...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowLast | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_GoodsPriceInfo.KeyActionMappings.Add(enterMap);

            //----- ↓キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_GoodsPriceInfo.KeyActionMappings.Add(enterMap);

            //----- 前頁キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Prior,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_GoodsPriceInfo.KeyActionMappings.Add(enterMap);

            //----- 次頁キー
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Next,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_GoodsPriceInfo.KeyActionMappings.Add(enterMap);
        }

        /// <summary>
        /// Returnキーダウン処理
        /// </summary>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        internal bool ReturnKeyDown()
        {
            if (this.uGrid_GoodsPriceInfo.ActiveCell == null) return false;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_GoodsPriceInfo.ActiveCell;
            int rowIndex = cell.Row.Index;

            this.uGrid_GoodsPriceInfo.BeginUpdate();

            this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

            // グリッドセル設定処理
            this.SettingGridRow(rowIndex);

            try
            {
                bool canMove = true;

                //------------------------------------------------------------
                // 価格開始日
                //------------------------------------------------------------
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 DEL
                //if (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateColumn.ColumnName)
                //{
                //    if (this._beforeCellUpdateCancel)
                //    {
                //        this._beforeCellUpdateCancel = false;
                //    }
                //    else
                //    {
                //        // 次入力可能セル移動処理
                //        canMove = this.MoveNextAllowEditCell(false);
                //    }
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
                // 価格開始日(年)
                if ( cell.Column.Key == this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName )
                {
                    if ( this._beforeCellUpdateCancel )
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // 次入力可能セル移動処理
                        canMove = this.MoveNextAllowEditCell( false );
                    }
                }
                // 価格開始日(月)
                else if ( cell.Column.Key == this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName )
                {
                    if ( this._beforeCellUpdateCancel )
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // 次入力可能セル移動処理
                        canMove = this.MoveNextAllowEditCell( false );
                    }
                }
                // 価格開始日(日)
                else if ( cell.Column.Key == this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName )
                {
                    if ( this._beforeCellUpdateCancel )
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // 次入力可能セル移動処理
                        canMove = this.MoveNextAllowEditCell( false );
                    }
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD
                //------------------------------------------------------------
                // 標準価格
                //------------------------------------------------------------
                else if (cell.Column.Key == this._goodsPriceDataTable.ListPriceColumn.ColumnName)
                {
                    if (this._beforeCellUpdateCancel)
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // 次入力可能セル移動処理
                        canMove = this.MoveNextAllowEditCell(false);
                    }
                }
                //------------------------------------------------------------
                // 仕入率
                //------------------------------------------------------------
                else if (cell.Column.Key == this._goodsPriceDataTable.StockRateColumn.ColumnName)
                {
                    if (this._beforeCellUpdateCancel)
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // 次入力可能セル移動処理
                        canMove = this.MoveNextAllowEditCell(false);
                    }
                }
                //------------------------------------------------------------
                // 原単価
                //------------------------------------------------------------
                else if (cell.Column.Key == this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName)
                {
                    if (this._beforeCellUpdateCancel)
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // 次入力可能セル移動処理
                        canMove = this.MoveNextAllowEditCell(false);
                    }
                }
                else
                {
                    // 次入力可能セル移動処理
                    canMove = this.MoveNextAllowEditCell(false);
                }
                return canMove;
            }
            finally
            {
                this.uGrid_GoodsPriceInfo.EndUpdate();
            }
        }

        // ADD 2008/12/15 不具合対応[8733] ---------->>>>>
        internal bool ShiftReturnKeyDown()
        {
            if (this.uGrid_GoodsPriceInfo.ActiveCell == null) return false;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_GoodsPriceInfo.ActiveCell;
            int rowIndex = cell.Row.Index;

            this.uGrid_GoodsPriceInfo.BeginUpdate();

            this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

            // グリッドセル設定処理
            this.SettingGridRow(rowIndex);

            try
            {
                bool canMove = true;

                
                // 価格開始日(年)
                if (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName)
                {
                    if (this._beforeCellUpdateCancel)
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // 次入力可能セル移動処理
                        canMove = this.MovePrevAllowEditCell(false);
                    }
                }
                // 価格開始日(月)
                else if (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName)
                {
                    if (this._beforeCellUpdateCancel)
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // 次入力可能セル移動処理
                        canMove = this.MovePrevAllowEditCell(false);
                    }
                }
                // 価格開始日(日)
                else if (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName)
                {
                    if (this._beforeCellUpdateCancel)
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // 次入力可能セル移動処理
                        canMove = this.MovePrevAllowEditCell(false);
                    }
                }
                //------------------------------------------------------------
                // 標準価格
                //------------------------------------------------------------
                else if (cell.Column.Key == this._goodsPriceDataTable.ListPriceColumn.ColumnName)
                {
                    if (this._beforeCellUpdateCancel)
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // 次入力可能セル移動処理
                        canMove = this.MovePrevAllowEditCell(false);
                    }
                }
                //------------------------------------------------------------
                // 仕入率
                //------------------------------------------------------------
                else if (cell.Column.Key == this._goodsPriceDataTable.StockRateColumn.ColumnName)
                {
                    if (this._beforeCellUpdateCancel)
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // 次入力可能セル移動処理
                        canMove = this.MovePrevAllowEditCell(false);
                    }
                }
                //------------------------------------------------------------
                // 原単価
                //------------------------------------------------------------
                else if (cell.Column.Key == this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName)
                {
                    if (this._beforeCellUpdateCancel)
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // 次入力可能セル移動処理
                        canMove = this.MovePrevAllowEditCell(false);
                    }
                }
                else
                {
                    // 次入力可能セル移動処理
                    canMove = this.MovePrevAllowEditCell(false);
                }
                return canMove;
            }
            finally
            {
                this.uGrid_GoodsPriceInfo.EndUpdate();
            }
        }

        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="currentCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        private bool MovePrevAllowEditCell(bool activeCellCheck)
        {
            this.uGrid_GoodsPriceInfo.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_GoodsPriceInfo.ActiveCell != null))
            {
                if ((!this.uGrid_GoodsPriceInfo.ActiveCell.Column.Hidden) &&
                    (this.uGrid_GoodsPriceInfo.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_GoodsPriceInfo.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }

            while (!moved)
            {

                performActionResult = this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);

                if (performActionResult)
                {
                    if ((this.uGrid_GoodsPriceInfo.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_GoodsPriceInfo.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
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
                this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            this.uGrid_GoodsPriceInfo.ResumeLayout();
            return performActionResult;
        }
        // ADD 2008/12/15 不具合対応[8733] ----------<<<<<

        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="currentCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            this.uGrid_GoodsPriceInfo.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_GoodsPriceInfo.ActiveCell != null))
            {
                if ((!this.uGrid_GoodsPriceInfo.ActiveCell.Column.Hidden) &&
                    (this.uGrid_GoodsPriceInfo.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_GoodsPriceInfo.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }

            while (!moved)
            {
                //if (this.uGrid_GoodsPriceInfo.ActiveCell != null)
                //{
                //    int editMode = (int)this.uGrid_GoodsPriceInfo.Rows[this.uGrid_GoodsPriceInfo.ActiveCell.Row.Index].Cells[this._salesDetailDataTable.EditStatusColumn.ColumnName].Value;

                //    if ((editMode == StockSlipInputAcs.ctEDITSTATUS_AllDisable) || (editMode == StockSlipInputAcs.ctEDITSTATUS_AllReadOnly))
                //    {
                //        performActionResult = this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextRow);

                //        if ((performActionResult) && (this.uGrid_GoodsPriceInfo.ActiveRow != null))
                //        {
                //            int index = this.uGrid_GoodsPriceInfo.ActiveRow.Index;

                //            if (!(this.uGrid_GoodsPriceInfo.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.GoodsNoColumn.ColumnName].Hidden))
                //            {
                //                this.uGrid_GoodsPriceInfo.ActiveCell = this.uGrid_GoodsPriceInfo.Rows[index].Cells[this._salesDetailDataTable.GoodsNoColumn.ColumnName];
                //            }
                //            else
                //            {
                //                this.uGrid_GoodsPriceInfo.ActiveCell = this.uGrid_GoodsPriceInfo.Rows[index].Cells[this._salesDetailDataTable.GoodsNameColumn.ColumnName];
                //            }

                //            // 再帰処理
                //            this.MoveNextAllowEditCell(true);

                //            return true;
                //        }
                //    }
                //}

                performActionResult = this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                //performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);

                if (performActionResult)
                {
                    if ((this.uGrid_GoodsPriceInfo.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_GoodsPriceInfo.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
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
                this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            this.uGrid_GoodsPriceInfo.ResumeLayout();
            return performActionResult;
        }

        /// <summary>
        /// FIXME:価格情報設定イベントコール処理
        /// </summary>
        /// <param name="rowNo"></param>
        private void SettingGoodsPriceEventCall(int rowNo)
        {
            if ((this.SettingGoodsPrice != null) && (rowNo != 0))
            {
                this.SettingGoodsPrice(this, rowNo);
            }
        }

        /// <summary>
        /// ActiveRowインデックス取得処理
        /// </summary>
        /// <returns>ActiveRowインデックス</returns>
        private int GetActiveRowIndex()
        {
            if (this.uGrid_GoodsPriceInfo.ActiveCell != null)
            {
                return this.uGrid_GoodsPriceInfo.ActiveCell.Row.Index;
            }
            else if (this.uGrid_GoodsPriceInfo.ActiveRow != null)
            {
                return this.uGrid_GoodsPriceInfo.ActiveRow.Index;
            }
            else
            {
                // DEL 2010/01/05 MANTIS対応[14816]：価格情報の再計算処理の修正 ---------->>>>>
                // return -1;
                // DEL 2010/01/05 MANTIS対応[14816]：価格情報の再計算処理の修正 ----------<<<<<
                // ADD 2010/01/05 MANTIS対応[14816]：価格情報の再計算処理の修正 ---------->>>>>
                // MEMO:価格情報の再計算用…アクティブ行が存在しない場合、保持しておいたインデックスを返す
                return CurrentRowIndex;
                // ADD 2010/01/05 MANTIS対応[14816]：価格情報の再計算処理の修正 ----------<<<<<
            }
        }

        /// <summary>
        /// ActiveRowの行番号取得処理
        /// </summary>
        /// <returns></returns>
        internal int GetActiveRowRowNo()
        {
            int rowIndex = this.GetActiveRowIndex();
            if (rowIndex < 0) return -1;

            return this._goodsPriceDataTable[rowIndex].RowNo;
        }

        /// <summary>
        /// FIXME:明細グリッド・行単位でのセル設定
        /// </summary>
        /// <param name="rowIndex">対象行インデックス</param>
        /// <param name="salesSlip">仕入データクラスオブジェクト</param>
        /// <remarks>
        /// <br>Update Note: K2013/05/13 王君</br>
        /// <br>管理番号   : 10901273-00 2013/06/18配信分</br>
        /// <br>             Redmine#35663 商品在庫マスタ・山形部品様個別組み込み</br>
        /// </remarks>
        internal void SettingGridRow(int rowIndex)
        {
            if (this._goodsPriceDataTable.Count == 0) return;

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_GoodsPriceInfo.DisplayLayout.Bands[0];
            if (editBand == null) return;

            // 価格開始日
            DateTime priceStartDate = this._goodsPriceDataTable[rowIndex].PriceStartDate;
            // 提供日付
            DateTime offerDate = this._goodsPriceDataTable[rowIndex].OfferDate;

            // 指定行の全ての列に対して設定を行う。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // セル情報を取得
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_GoodsPriceInfo.Rows[rowIndex].Cells[col];
                if (cell == null) continue;

                // --- ADD 2009/02/03 障害ID:10848対応------------------------------------------------------>>>>>
                int yy = 0;
                int mm = 0;
                int dd = 0;

                if (cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Value != DBNull.Value)
                {
                    yy = (Int32)cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Value;
                }
                if (cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Value != DBNull.Value)
                {
                    mm = (Int32)cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Value;
                }
                if (cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Value != DBNull.Value)
                {
                    dd = (Int32)cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Value;
                }
                // --- ADD 2009/02/03 障害ID:10848対応------------------------------------------------------<<<<<

                //------------------------------------------------
                // セル状態設定
                //------------------------------------------------
                if ((col.Key == this._goodsPriceDataTable.ListPriceColumn.ColumnName) ||
                    (col.Key == this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName) ||
                    (col.Key == this._goodsPriceDataTable.StockRateColumn.ColumnName) ||
                    (col.Key == this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName))
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/04 DEL
                    //(col.Key == this._goodsPriceDataTable.OfferDateColumn.ColumnName)
                　　// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/04 DEL
                {
                    //----- ADD K2013/05/13 王君 Redmine#35663 ----->>>>>
                    if ((this._opt_YamagataCtrl == (int)MAKHN09280UA.Option.ON) &&
                        ((col.Key == this._goodsPriceDataTable.StockRateColumn.ColumnName) ||
                        (col.Key == this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName)))
                    {
                        if (this._cstChangeEnable == false)
                        {
                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled; // 使用不可
                            continue;
                        }
                    }
                    //----- ADD K2013/05/13 王君 Redmine#35663 -----<<<<<
                    // --- CHG 2009/02/03 障害ID:10848対応------------------------------------------------------>>>>>
                    //if (priceStartDate == DateTime.MinValue)
                    if ((yy == 0) && (mm == 0) && (dd == 0))
                    // --- CHG 2009/02/03 障害ID:10848対応------------------------------------------------------<<<<<
                    {
                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled; // 使用不可
                    }
                    else
                    {
                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // 編集可能
                    }
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/04 ADD
                if ( col.Key == this._goodsPriceDataTable.OfferDateColumn.ColumnName )
                {
                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled; // 使用不可
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/04 ADD

                //------------------------------------------------
                // 無効要素のテキストカラー設定
                //------------------------------------------------
                // 価格開始日
                if (col.Key == this._goodsPriceDataTable.PriceStartDateColumn.ColumnName)
                {
                    // --- CHG 2009/02/03 障害ID:10848対応------------------------------------------------------>>>>>
                    //if (priceStartDate == DateTime.MinValue)
                    if ((yy == 0) && (mm == 0) && (dd == 0))
                    // --- CHG 2009/02/03 障害ID:10848対応------------------------------------------------------<<<<<
                    {
                        cell.Appearance.ForeColor = Color.Transparent;
                    }
                    else
                    {
                        cell.Appearance.ForeColor = this.uGrid_GoodsPriceInfo.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                    }
                }
                // オープン価格区分
                if (col.Key == this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName)
                {
                    // --- CHG 2009/02/03 障害ID:10848対応------------------------------------------------------>>>>>
                    //if (priceStartDate == DateTime.MinValue)
                    if ((yy == 0) && (mm == 0) && (dd == 0))
                    // --- CHG 2009/02/03 障害ID:10848対応------------------------------------------------------<<<<<
                    {
                        cell.Appearance.ForeColor = Color.Transparent;
                        cell.Appearance.ForeColorDisabled = Color.Transparent;
                    }
                    else
                    {
                        cell.Appearance.ForeColor = this.uGrid_GoodsPriceInfo.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                        cell.Appearance.ForeColorDisabled = this.uGrid_GoodsPriceInfo.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                    }
                }
                // 提供日付
                if ( col.Key == this._goodsPriceDataTable.OfferDateColumn.ColumnName )
                {
                    if ( offerDate == DateTime.MinValue )
                    {
                        cell.Appearance.ForeColor = Color.Transparent;
                        cell.Appearance.ForeColorDisabled = Color.Transparent;
                    }
                    else
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/04 DEL
                        //cell.Appearance.ForeColor = this.uGrid_GoodsPriceInfo.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                        //cell.Appearance.ForeColorDisabled = this.uGrid_GoodsPriceInfo.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/04 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/04 ADD
                        cell.Appearance.ForeColor = Color.Black;
                        cell.Appearance.ForeColorDisabled = Color.Black;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/04 ADD
                    }
                }
            }
        }

        // ===================================================================================== //
        // 各コントロールイベント処理
        // ===================================================================================== //
        /// <summary>
        /// Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAKHN09280UB_Load(object sender, EventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 DEL
            //if ((this._goodsUnitData.GoodsNo == string.Empty))
            //{
            //    this._goodsPriceDataTable.Clear();

            //    this.uGrid_GoodsPriceInfo.DataSource = this._goodsPriceDataTable;

            //    this._goodsAcs.ClearGoodsPriceDataTable();
            //}
            //else
            //{
            //    this.uGrid_GoodsPriceInfo.DataSource = this._goodsPriceDataTable;
            //}


            //// キーマッピング設定
            //this.MakeKeyMappingForGrid(this.uGrid_GoodsPriceInfo);

            //// 描画が必要な明細件数を取得する。
            //int cnt = this._goodsPriceDataTable.Count;

            //// 各行ごとの設定
            //for (int i = 0; i < cnt; i++)
            //{
            //    this.SettingGridRow(i);
            //}

            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/24 ADD
            //// 入力可否設定
            //this.SettingEnabled( _goodsUnitData.LogicalDeleteCode == 0 );
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/24 ADD
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 DEL
        }
        /// <summary>
        /// ロード処理
        /// </summary>
        public void Loading()
        {
            if ( (this._goodsUnitData.GoodsNo == string.Empty) )
            {
                this._goodsPriceDataTable.Clear();

                this.uGrid_GoodsPriceInfo.DataSource = this._goodsPriceDataTable;

                this._goodsAcs.ClearGoodsPriceDataTable();
            }
            else
            {
                this.uGrid_GoodsPriceInfo.DataSource = this._goodsPriceDataTable;
            }

            // キーマッピング設定
            this.MakeKeyMappingForGrid( this.uGrid_GoodsPriceInfo );

            // 描画が必要な明細件数を取得する。
            int cnt = this._goodsPriceDataTable.Count;

            // 各行ごとの設定
            for ( int i = 0; i < cnt; i++ )
            {
                this.SettingGridRow( i );
            }

            // 入力可否設定
            this.SettingEnabled( _goodsUnitData.LogicalDeleteCode == 0 );
        }

        /// <summary>
        /// InitializeLayoutイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_GoodsPriceInfo_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_GoodsPriceInfo.DisplayLayout.Bands[0].Columns;

            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //非表示設定
                column.Hidden = true;
            }

            string moneyFormat = "#,##0;-#,##0;''";
            string moneyFormatFl = "#,##0.00;-#,##0.00;''";
            string rateFormatFl = "###0.00;-###0.00;''";

            int visiblePosition = 0;

            // 列幅の自動調整方法
            this.uGrid_GoodsPriceInfo.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 DEL
            //this.uGrid_GoodsPriceInfo.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 DEL
            this.uGrid_GoodsPriceInfo.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_GoodsPriceInfo.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_GoodsPriceInfo.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.uGrid_GoodsPriceInfo.DisplayLayout.Bands[0].Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;// None;
            this.uGrid_GoodsPriceInfo.DisplayLayout.Bands[0].Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            //--------------------------------------------------------------------------------
            //  表示するカラム情報
            //--------------------------------------------------------------------------------
            this.uGrid_GoodsPriceInfo.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;

            // №
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].Header.Fixed = true;				// 固定項目
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_GoodsPriceInfo.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_GoodsPriceInfo.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_GoodsPriceInfo.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_GoodsPriceInfo.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_GoodsPriceInfo.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].Hidden = false;
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].Width = 25;
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_GoodsPriceInfo.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 DEL
            //// 価格開始日
            //Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].Header.Fixed = true;				// 固定項目
            //Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].Hidden = false;
            //Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].Width = 100;
            //Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            //Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            //Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
            // 価格開始日（非表示）
            Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].Header.Fixed = false;				// 固定項目
            Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].Hidden = true;
            Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].Width = 100;
            Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 価格開始日（年）
            Columns[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Header.Fixed = true;				// 固定項目
            Columns[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Hidden = false;
            Columns[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Width = 80;
            Columns[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            Columns[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Format = "####年";
            Columns[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // 価格開始日（月）
            Columns[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Header.Fixed = true;				// 固定項目
            Columns[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Hidden = false;
            Columns[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Width = 35;
            Columns[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            Columns[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Format = "##月";
            Columns[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // 価格開始日（日）
            Columns[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Header.Fixed = true;				// 固定項目
            Columns[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Hidden = false;
            Columns[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Width = 35;
            Columns[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            Columns[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Format = "##日";
            Columns[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD

            // 標準価格
            Columns[this._goodsPriceDataTable.ListPriceColumn.ColumnName].Header.Fixed = true;				// 固定項目
            Columns[this._goodsPriceDataTable.ListPriceColumn.ColumnName].Hidden = false;
            // 2008.11.18 UPD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //Columns[this._goodsPriceDataTable.ListPriceColumn.ColumnName].MaxLength = 11;
            Columns[this._goodsPriceDataTable.ListPriceColumn.ColumnName].MaxLength = 7;
            // 2008.11.18 UPD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            Columns[this._goodsPriceDataTable.ListPriceColumn.ColumnName].Format = moneyFormat;
            Columns[this._goodsPriceDataTable.ListPriceColumn.ColumnName].Width = 100;
            Columns[this._goodsPriceDataTable.ListPriceColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._goodsPriceDataTable.ListPriceColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            Columns[this._goodsPriceDataTable.ListPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._goodsPriceDataTable.ListPriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // オープン価格区分
            Columns[this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName].Header.Fixed = true;				// 固定項目
            Columns[this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName].Hidden = false;
            Columns[this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName].Width = 100;
            // --- UPD 2010/08/09 ---------->>>>>
            //Columns[this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            Columns[this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            // --- UPD 2010/08/09 ----------<<<<<
            Columns[this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            Columns[this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Infragistics.Win.ValueList list = new Infragistics.Win.ValueList();
            list.DisplayStyle = Infragistics.Win.ValueListDisplayStyle.DisplayText;
            list.DropDownListMinWidth = 0;
            list.MaxDropDownItems = 2;
            Infragistics.Win.ValueListItem listItem0 = new Infragistics.Win.ValueListItem();
            listItem0.DataValue = 0;
            //listItem0.DisplayText = "通常"; // DEL 2010/08/09
            listItem0.DisplayText = "0:通常"; // ADD 2010/08/09
            Infragistics.Win.ValueListItem listItem1 = new Infragistics.Win.ValueListItem();
            listItem1.DataValue = 1;
            //listItem1.DisplayText = "オープン価格"; // DEL 2010/08/09
            listItem1.DisplayText = "1:オープン価格"; // ADD 2010/08/09
            list.ValueListItems.Add(listItem0);
            list.ValueListItems.Add(listItem1);
            Columns[this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName].ValueList = list;
            
            // 仕入率
            Columns[this._goodsPriceDataTable.StockRateColumn.ColumnName].Header.Fixed = true;				// 固定項目
            Columns[this._goodsPriceDataTable.StockRateColumn.ColumnName].Hidden = false;
            Columns[this._goodsPriceDataTable.StockRateColumn.ColumnName].MaxLength = 12;
            Columns[this._goodsPriceDataTable.StockRateColumn.ColumnName].Format = rateFormatFl;
            Columns[this._goodsPriceDataTable.StockRateColumn.ColumnName].Width = 100;
            Columns[this._goodsPriceDataTable.StockRateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._goodsPriceDataTable.StockRateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            Columns[this._goodsPriceDataTable.StockRateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._goodsPriceDataTable.StockRateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // 原単価
            Columns[this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName].Header.Fixed = true;				// 固定項目
            Columns[this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName].Hidden = false;
            // 2008.11.18 UPD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //Columns[this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName].MaxLength = 12;
            Columns[this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName].MaxLength = 10;
            // 2008.11.18 UPD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            Columns[this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName].Format = moneyFormatFl;
            Columns[this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName].Width = 100;
            Columns[this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            Columns[this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // 提供日付
            Columns[this._goodsPriceDataTable.OfferDateColumn.ColumnName].Header.Fixed = true;				// 固定項目
            Columns[this._goodsPriceDataTable.OfferDateColumn.ColumnName].Hidden = false;
            Columns[this._goodsPriceDataTable.OfferDateColumn.ColumnName].Width = 100;
            Columns[this._goodsPriceDataTable.OfferDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            Columns[this._goodsPriceDataTable.OfferDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this._goodsPriceDataTable.OfferDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._goodsPriceDataTable.OfferDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 固定列区切り線設定
            this.uGrid_GoodsPriceInfo.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_GoodsPriceInfo.DisplayLayout.Override.HeaderAppearance.BackColor2;
        }

        /// <summary>
        /// AfterPerformActionイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_GoodsPriceInfo_AfterPerformAction(object sender, Infragistics.Win.UltraWinGrid.AfterUltraGridPerformActionEventArgs e)
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
                    if ((this.uGrid_GoodsPriceInfo.ActiveCell != null) && (this.uGrid_GoodsPriceInfo.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) && (this.uGrid_GoodsPriceInfo.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        // アクティブセルのスタイルを取得
                        switch (this.uGrid_GoodsPriceInfo.ActiveCell.StyleResolved)
                        {
                            // エディット系スタイル
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    // 編集モードにある？
                                    if (this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode))
                                    {
                                        if (!(this.uGrid_GoodsPriceInfo.ActiveCell.Value is System.DBNull))
                                        {
                                            // 全選択状態にする。
                                            this.uGrid_GoodsPriceInfo.ActiveCell.SelStart = 0;
                                            this.uGrid_GoodsPriceInfo.ActiveCell.SelLength = this.uGrid_GoodsPriceInfo.ActiveCell.Text.Length;
                                        }
                                    }
                                    break;
                                }
                            default:
                                {
                                    // エディット系以外のスタイルであれば、編集状態にする。
                                    this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    break;
                                }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Enterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_GoodsPriceInfo_Enter(object sender, EventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/24 ADD
            if ( !_parentEnabled ) return;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/24 ADD

            if (this.uGrid_GoodsPriceInfo.ActiveCell == null)
            {
                if (!this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell) || (this.uGrid_GoodsPriceInfo.ActiveCell == null))
                {
                    if (this.uGrid_GoodsPriceInfo.Rows.Count > 0)
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 DEL
                        //this.uGrid_GoodsPriceInfo.ActiveCell = this.uGrid_GoodsPriceInfo.Rows[0].Cells[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName];
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
                        this.uGrid_GoodsPriceInfo.ActiveCell = this.uGrid_GoodsPriceInfo.Rows[0].Cells[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName];
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD

                        // 次入力可能セル移動処理
                        this.MoveNextAllowEditCell(true);
                    }
                }
            }

            if (this.uGrid_GoodsPriceInfo.ActiveCell != null)
            {
                if ((!this.uGrid_GoodsPriceInfo.ActiveCell.IsInEditMode) && (this.uGrid_GoodsPriceInfo.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) && (this.uGrid_GoodsPriceInfo.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
                else
                {
                    // 次入力可能セル移動処理
                    this.MoveNextAllowEditCell(true);
                }
            }

            // グリッドセルアクティブ後発生イベント
            //this.uGrid_Details_AfterCellActivate(this.uGrid_Details, new EventArgs());

        }

        /// <summary>
        /// KeyDownイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_GoodsPriceInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_GoodsPriceInfo.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_GoodsPriceInfo.ActiveCell;

                if (e.KeyCode == Keys.Escape)
                {
                    //// 仕入明細データテーブルRowStatus列初期化処理
                    //this._stockSlipInputAcs.InitializeStockDetailRowStatusColumn();

                    //// 明細グリッドセル設定処理
                    //this.SettingGrid();
                }

                if (e.Shift)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                            {
                                this.uGrid_GoodsPriceInfo.ActiveCell = null;
                                this.uGrid_GoodsPriceInfo.ActiveRow = cell.Row;
                                this.uGrid_GoodsPriceInfo.Selected.Rows.Clear();
                                this.uGrid_GoodsPriceInfo.Selected.Rows.Add(cell.Row);
                                break;
                            }
                        case Keys.Up:
                            {
                                this.uGrid_GoodsPriceInfo.ActiveCell = null;
                                this.uGrid_GoodsPriceInfo.ActiveRow = cell.Row;
                                this.uGrid_GoodsPriceInfo.Selected.Rows.Clear();
                                this.uGrid_GoodsPriceInfo.Selected.Rows.Add(cell.Row);
                                break;
                            }
                        case Keys.Home:
                            {
                                if ((this.uGrid_GoodsPriceInfo.ActiveCell != null) && (this.uGrid_GoodsPriceInfo.ActiveCell.IsInEditMode))
                                {
                                    // 編集モードの場合はなにもしない
                                }
                                else
                                {
                                    this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid);
                                    this.MoveNextAllowEditCell(true);
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                if ((this.uGrid_GoodsPriceInfo.ActiveCell != null) && (this.uGrid_GoodsPriceInfo.ActiveCell.IsInEditMode))
                                {
                                    // 編集モードの場合はなにもしない
                                }
                                else
                                {
                                    this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInGrid);
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
                                //if ((cell.Column.Style != Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown) &&
                                //    (cell.Column.Style != Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList) &&
                                //    (cell.Column.Style != Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate))
                                //{
                                //    ((Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.tToolbarsManager_Main.Tools["PopupMenuTool_Edit"]).ShowPopup(System.Windows.Forms.Cursor.Position, this.uGrid_GoodsPriceInfo);
                                //}

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
                        switch (this.uGrid_GoodsPriceInfo.ActiveCell.StyleResolved)
                        {
                            // テキストボックス・テキストボックス(ボタン付)
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ←キー
                                        case Keys.Left:
                                            if (this.uGrid_GoodsPriceInfo.ActiveCell.SelStart == 0)
                                            {
                                                this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // →キー
                                        case Keys.Right:
                                            if (this.uGrid_GoodsPriceInfo.ActiveCell.SelStart >= this.uGrid_GoodsPriceInfo.ActiveCell.Text.Length)
                                            {
                                                this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
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
                                                this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // →キー
                                        case Keys.Right:
                                            {
                                                this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
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
                                if ((this.uGrid_GoodsPriceInfo.ActiveCell != null) && (this.uGrid_GoodsPriceInfo.ActiveCell.IsInEditMode))
                                {
                                    // 編集モードの場合はなにもしない
                                }
                                else
                                {
                                    this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInRow);
                                    this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    e.Handled = true;
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                // 編集モードの場合はなにもしない
                                if ((this.uGrid_GoodsPriceInfo.ActiveCell != null) && (this.uGrid_GoodsPriceInfo.ActiveCell.IsInEditMode))
                                {
                                    //
                                }
                                else
                                {
                                    this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInRow);
                                    this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    e.Handled = true;
                                }
                                break;
                            }
                        case Keys.Up:
                            {
                                if ((this.uGrid_GoodsPriceInfo.ActiveCell != null) && (!this.uGrid_GoodsPriceInfo.ActiveCell.DroppedDown))
                                {
                                    if (this.uGrid_GoodsPriceInfo.ActiveCell.Row.Index == 0)
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
                                if (this.uGrid_GoodsPriceInfo.ActiveCell.Row.Index == this.uGrid_GoodsPriceInfo.Rows.Count - 1)
                                {
                                    if (e.KeyCode == Keys.Down)
                                    {
                                        if (this.GridKeyDownButtomRow != null)
                                        {
                                            this.GridKeyDownButtomRow(this, new EventArgs());
                                            e.Handled = true;
                                        }
                                    }
                                }

                                break;
                            }
                    }
                }
            }
            else if (this.uGrid_GoodsPriceInfo.ActiveRow != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_GoodsPriceInfo.ActiveRow;

                if (this.uGrid_GoodsPriceInfo.ActiveRow.Index == 0)
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
                else if (this.uGrid_GoodsPriceInfo.ActiveRow.Index == this.uGrid_GoodsPriceInfo.Rows.Count - 1)
                {
                    if (e.KeyCode == Keys.Down)
                    {
                        if (this.GridKeyDownButtomRow != null)
                        {
                            this.GridKeyDownButtomRow(this, new EventArgs());
                            e.Handled = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// BeforeCellUpdateイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_GoodsPriceInfo_BeforeCellUpdate(object sender, Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs e)
        {
            if (e.Cell == null) return;

            this._beforeCellUpdateCancel = false;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;

            //------------------------------------------------------------
            // 価格開始日
            //------------------------------------------------------------
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 DEL
            //if (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateColumn.ColumnName)
            //{
            //    if ((e.Cell.Value != null) && (!(e.Cell.Value is System.DBNull)))
            //    {
            //        //DateTime dt = new DateTime((long)e.Cell.Value);
            //        DateTime dt = new DateTime();
            //        //DateTime dt = new DateTime((long)e.Cell.Value);
            //        dt = (DateTime)e.NewValue;
            //        // 価格開始日重複チェック
            //        if (this._goodsAcs.CheckRepeatPriceStartDate(dt))
            //        {
            //            TMsgDisp.Show(
            //                this,
            //                emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //                this.Name,
            //                "入力された日付は既に存在する為、入力できません。",
            //                -1,
            //                MessageBoxButtons.OK);

            //            this._beforeCellUpdateCancel = true;
            //            e.Cancel = true;
            //            return;
            //        }
            //        this._beforePriceStartDate = (DateTime)e.Cell.Value;
            //    }
            //    else
            //    {
            //        this._beforePriceStartDate = DateTime.MinValue;
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
            if ( (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName) ||
                      (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName) ||
                      (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName) )
            {
                // --- CHG 2009/02/03 障害ID:10848対応------------------------------------------------------>>>>>
                //// 変更前の日付を対比→AfterCellUpdateで使用する
                //if ( e.Cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].Value != DBNull.Value )
                //{
                //    this._beforePriceStartDate = (DateTime)e.Cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].Value;
                //}
                // --- CHG 2009/02/03 障害ID:10848対応------------------------------------------------------<<<<<

                if ( (e.NewValue != null) && (e.NewValue != DBNull.Value) )
                {
                    // 新しく入力された日付を取得(現在のセルだけはNewValueから未更新の最新値を取得する)
                    DateTime inputDate = GetPriceStartDateFromNewInput( cell.Column.Key, e );

                    if ( inputDate != DateTime.MinValue )
                    {
                        if ( this._goodsAcs.CheckRepeatPriceStartDate( inputDate ) )
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "入力された日付は既に存在する為、入力できません。",
                                -1,
                                MessageBoxButtons.OK );

                            this._beforeCellUpdateCancel = true;
                            e.Cancel = true;
                            return;
                        }
                    }
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD
            //------------------------------------------------------------
            // 標準価格
            //------------------------------------------------------------
            else if ( cell.Column.Key == this._goodsPriceDataTable.ListPriceColumn.ColumnName )
            {
                if ( (e.Cell.Value != null) && (!(e.Cell.Value is System.DBNull)) )
                {
                    this._beforeListPrice = (double)e.Cell.Value;
                }
                else
                {
                    this._beforeListPrice = 0;
                }
            }
            //------------------------------------------------------------
            // 仕入率
            //------------------------------------------------------------
            else if ( cell.Column.Key == this._goodsPriceDataTable.StockRateColumn.ColumnName )
            {
                if ( (e.Cell.Value != null) && (!(e.Cell.Value is System.DBNull)) )
                {
                    this._beforeStockRate = (double)e.Cell.Value;
                }
                else
                {
                    this._beforeStockRate = 0;
                }
            }
            //------------------------------------------------------------
            // 原単価
            //------------------------------------------------------------
            else if ( cell.Column.Key == this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName )
            {
                if ( (e.Cell.Value != null) && (!(e.Cell.Value is System.DBNull)) )
                {
                    this._beforeSalesUnitCost = (double)e.Cell.Value;
                }
                else
                {
                    this._beforeSalesUnitCost = 0;
                }
            }

            // --- ADD 2010/08/09 ---------->>>>>
            //------------------------------------------------------------
            // オープン価格区分
            //------------------------------------------------------------
            else if (cell.Column.Key == this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName)
            {
                if ((cell.Value != null) && (!(cell.Value is System.DBNull)))
                {
                    this._beforeOpenPriceDiv = cell.Value;
                }
            }
            // --- ADD 2010/08/09 ----------<<<<<
        }

        /// <summary>
        /// AfterCellUpdateイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_GoodsPriceInfo_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (e.Cell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;
            int rowNo = this._goodsPriceDataTable[cell.Row.Index].RowNo;
            int rowIndex = e.Cell.Row.Index;

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_GoodsPriceInfo.DisplayLayout.Bands[0].Columns; // ADD 2010/08/11

            if (e.Cell.Value is DBNull)
            {
                if ((e.Cell.Column.DataType == typeof(Int32)) ||
                    (e.Cell.Column.DataType == typeof(Int64)) ||
                    (e.Cell.Column.DataType == typeof(double)))
                {
                    e.Cell.Value = 0;
                }
                else if (e.Cell.Column.DataType == typeof(string))
                {
                    e.Cell.Value = "";
                }
            }

            //------------------------------------------------------------
            // 価格開始日
            //------------------------------------------------------------
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 DEL
            //if (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateColumn.ColumnName)
            //{
            //    DateTime dt = new DateTime();
            //    dt = (DateTime)e.Cell.Value;
            //    if (this._beforePriceStartDate != dt)
            //    {
            //        this._goodsAcs.CalclateUnitPrice(rowNo, this._goodsUnitData);

            //        this._goodsAcs.ClearInputInfo(rowNo); // 入力情報クリア
            //        this._goodsAcs.SettingCalcStockRate(rowNo); // 計算原価率設定
            //        this._goodsAcs.SettingCalcSalesUnitCost(rowNo); // 計算原価額設定処理
            //        this._goodsAcs.SettingCalcMaster(rowNo); // 算出マスタ設定処理
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
            if ( (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName) ||
                 (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName) ||
                 (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName)
                )
            {
                // 入力された日付を取得
                DateTime inputDate;

                // --- ADD 2009/02/03 障害ID:10848対応------------------------------------------------------>>>>>
                int yy = 0;
                int mm = 0;
                int dd = 0;
                // --- ADD 2009/02/03 障害ID:10848対応------------------------------------------------------<<<<<

                try
                {
                    // --- DEL 2009/02/03 障害ID:10848対応------------------------------------------------------>>>>>
                    //int yy = 0;
                    //int mm = 0;
                    //int dd = 0;
                    // --- DEL 2009/02/03 障害ID:10848対応------------------------------------------------------<<<<<

                    if ( cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Value != DBNull.Value )
                    {
                        yy = (Int32)cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Value;
                    }
                    if ( cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Value != DBNull.Value )
                    {
                        mm = (Int32)cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Value;
                    }
                    if ( cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Value != DBNull.Value )
                    {
                        dd = (Int32)cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Value;
                    }

                    this.uGrid_GoodsPriceInfo.BeforeCellUpdate -= uGrid_GoodsPriceInfo_BeforeCellUpdate;
                    this.uGrid_GoodsPriceInfo.AfterCellUpdate -= uGrid_GoodsPriceInfo_AfterCellUpdate;
                    if ( yy == 0 )
                    {
                        cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Value = DBNull.Value;
                        yy = 0;
                    }
                    // --- CHG 2009/02/03 障害ID:10848対応------------------------------------------------------>>>>>
                    //if (mm == 0 || mm > 12)
                    if (mm == 0)
                    // --- CHG 2009/02/03 障害ID:10848対応------------------------------------------------------<<<<<
                    {
                        cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Value = DBNull.Value;
                        mm = 0;
                    }
                    // --- CHG 2009/02/03 障害ID:10848対応------------------------------------------------------>>>>>
                    //if (dd == 0 || dd > 31)
                    if (dd == 0)
                    // --- CHG 2009/02/03 障害ID:10848対応------------------------------------------------------<<<<<
                    {
                        cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Value = DBNull.Value;
                        dd = 0;
                    }
                    this.uGrid_GoodsPriceInfo.BeforeCellUpdate += uGrid_GoodsPriceInfo_BeforeCellUpdate;
                    this.uGrid_GoodsPriceInfo.AfterCellUpdate += uGrid_GoodsPriceInfo_AfterCellUpdate;

                    inputDate = new DateTime( yy, mm, dd );
                }
                catch
                {
                    inputDate = DateTime.MinValue;
                }

                // DateTimeカラムに値をセット
                cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].Value = inputDate;

                // 入力値の反映
                if ( this._beforePriceStartDate != inputDate )
                {
                    // --- CHG 2009/02/03 障害ID:10848対応------------------------------------------------------>>>>>
                    //this._goodsAcs.CalclateUnitPrice(rowNo, this._goodsUnitData);

                    //this._goodsAcs.ClearInputInfo(rowNo); // 入力情報クリア
                    //this._goodsAcs.SettingCalcStockRate(rowNo); // 計算原価率設定
                    //this._goodsAcs.SettingCalcSalesUnitCost(rowNo); // 計算原価額設定処理
                    //this._goodsAcs.SettingCalcMaster(rowNo); // 算出マスタ設定処理

                    //// 有効値から無効値に変更された場合は、クリアする
                    //if (inputDate == DateTime.MinValue)
                    //{
                    //    this.uGrid_GoodsPriceInfo.BeforeCellUpdate -= uGrid_GoodsPriceInfo_BeforeCellUpdate;
                    //    this.uGrid_GoodsPriceInfo.AfterCellUpdate -= uGrid_GoodsPriceInfo_AfterCellUpdate;
                    //    cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Value = DBNull.Value;
                    //    cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Value = DBNull.Value;
                    //    cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Value = DBNull.Value;
                    //    this.uGrid_GoodsPriceInfo.BeforeCellUpdate += uGrid_GoodsPriceInfo_BeforeCellUpdate;
                    //    this.uGrid_GoodsPriceInfo.AfterCellUpdate += uGrid_GoodsPriceInfo_AfterCellUpdate;
                    //}

                    //_beforePriceStartDate = inputDate;
                    
                    bool clearFlg = false;
                    if ((yy == 0) && (mm == 0) && (dd == 0))
                    {
                        clearFlg = true;
                    }

                    if (clearFlg)
                    {
                        this._goodsAcs.CalclateUnitPrice(rowNo, this._goodsUnitData);

                        this._goodsAcs.ClearInputInfo(rowNo); // 入力情報クリア
                        this._goodsAcs.SettingCalcStockRate(rowNo); // 計算原価率設定
                        this._goodsAcs.SettingCalcSalesUnitCost(rowNo); // 計算原価額設定処理
                        this._goodsAcs.SettingCalcMaster(rowNo); // 算出マスタ設定処理

                        // 有効値から無効値に変更された場合は、クリアする
                        if (inputDate == DateTime.MinValue)
                        {
                            this.uGrid_GoodsPriceInfo.BeforeCellUpdate -= uGrid_GoodsPriceInfo_BeforeCellUpdate;
                            this.uGrid_GoodsPriceInfo.AfterCellUpdate -= uGrid_GoodsPriceInfo_AfterCellUpdate;
                            cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Value = DBNull.Value;
                            cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Value = DBNull.Value;
                            cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Value = DBNull.Value;
                            this.uGrid_GoodsPriceInfo.BeforeCellUpdate += uGrid_GoodsPriceInfo_BeforeCellUpdate;
                            this.uGrid_GoodsPriceInfo.AfterCellUpdate += uGrid_GoodsPriceInfo_AfterCellUpdate;
                        }

                        _beforePriceStartDate = inputDate;
                    }
                    else
                    {
                        _beforePriceStartDate = new DateTime(1900, 1, 1);

                        // 価格情報設定イベントコール
                        this.SettingGoodsPriceEventCall(rowNo);

                        // グリッドセル設定処理
                        this.SettingGridRow(rowIndex);

                        return;

                    }
                    // --- CHG 2009/02/03 障害ID:10848対応------------------------------------------------------<<<<<
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD
            //------------------------------------------------------------
            // 標準価格
            //------------------------------------------------------------
            else if ( cell.Column.Key == this._goodsPriceDataTable.ListPriceColumn.ColumnName )
            {
                double listPrice = TStrConv.StrToDoubleDef( e.Cell.ToString(), 0 );
                if ( this._beforeListPrice != (double)e.Cell.Value )
                {
                    // 計算原価率入力チェック
                    if ( this._goodsAcs.CheckInputCalcStockRate( rowNo ) )
                    {
                        // 計算原価率が入力されている場合、計算原価額再計算
                        // --- ADD 2009/02/10 障害ID:11234対応------------------------------------------------------>>>>>
                        this._goodsAcs.ClearCalcInfo(rowNo); // 算出情報クリア
                        // --- ADD 2009/02/10 障害ID:11234対応------------------------------------------------------<<<<<
                        this._goodsAcs.SettingCalcStockRate(rowNo); // 計算原価率設定
                        this._goodsAcs.SettingCalcSalesUnitCost( rowNo ); // 計算原価額設定処理
                        this._goodsAcs.SettingCalcMaster( rowNo ); // 算出マスタ設定処理
                    }
                }
            }
            //------------------------------------------------------------
            // 仕入率
            //------------------------------------------------------------
            else if ( cell.Column.Key == this._goodsPriceDataTable.StockRateColumn.ColumnName )
            {
                if ( this._beforeStockRate != (double)e.Cell.Value )
                {
                    this._goodsAcs.ClearCalcInfo( rowNo ); // 算出情報クリア
                    this._goodsAcs.SettingCalcStockRate( rowNo ); // 計算原価率設定
                    this._goodsAcs.SettingCalcSalesUnitCost( rowNo ); // 計算原価額設定処理
                    this._goodsAcs.SettingCalcMaster( rowNo ); // 算出マスタ設定処理
                }
            }
            //------------------------------------------------------------
            // 原単価
            //------------------------------------------------------------
            else if ( cell.Column.Key == this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName )
            {
                if ( this._beforeSalesUnitCost != (double)e.Cell.Value )
                {
                    this._goodsAcs.ClearCalcInfo( rowNo ); // 算出情報クリア
                    this._goodsAcs.SettingCalcStockRate( rowNo ); // 計算原価率設定
                    this._goodsAcs.SettingCalcSalesUnitCost( rowNo ); // 計算原価額設定処理
                    this._goodsAcs.SettingCalcMaster( rowNo ); // 算出マスタ設定処理
                }
            }

            // --- ADD 2010/08/09 ---------->>>>>
            //------------------------------------------------------------
            // オープン価格区分
            //------------------------------------------------------------
            else if (cell.Column.Key == this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName)
            {
                if ((cell.Value != null) && (!(cell.Value is System.DBNull)))
                {
                    bool inputErrorFlg = true;
                    Infragistics.Win.ValueList list = (Infragistics.Win.ValueList)Columns[cell.Column.Key].ValueList;
                    foreach (Infragistics.Win.ValueListItem item in list.ValueListItems)
                    {
                        if (item.DataValue.Equals(cell.Value))
                        {
                            inputErrorFlg = false;
                            break;
                        }
                    }

                    if (inputErrorFlg)
                    {
                        cell.Value = this._beforeOpenPriceDiv;
                    }
                    else
                    {
                        this._beforeOpenPriceDiv = cell.Value;
                    }
                }
                else
                {
                    cell.Value = this._beforeOpenPriceDiv;
                }
            }
            // --- ADD 2010/08/09 ----------<<<<<

            // 価格情報設定イベントコール
            this.SettingGoodsPriceEventCall(rowNo);

            // グリッドセル設定処理
            this.SettingGridRow(rowIndex);
        }

        // ADD 2010/01/05 MANTIS対応[14816]：価格情報の再計算処理の修正 ---------->>>>>
        /// <summary>UNDONE:現在の行インデックス</summary>
        private int _currentRowIndex;
        /// <summary>現在の行インデックスを取得または設定します。</summary>
        private int CurrentRowIndex
        {
            get { return _currentRowIndex; }
            set { _currentRowIndex = value; }
        }
        // ADD 2010/01/05 MANTIS対応[14816]：価格情報の再計算処理の修正 ----------<<<<<

        /// <summary>
        /// AfterRowActivateイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_GoodsPriceInfo_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.uGrid_GoodsPriceInfo.ActiveRow == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_GoodsPriceInfo.ActiveRow;

            // ADD 2010/01/05 MANTIS対応[14816]：価格情報の再計算処理の修正 ---------->>>>>
            // MEMO:現在の行インデックスを保持
            CurrentRowIndex = this.uGrid_GoodsPriceInfo.ActiveRow.Index;
            // ADD 2010/01/05 MANTIS対応[14816]：価格情報の再計算処理の修正 ----------<<<<<

            // 価格情報設定イベントコール
            this.SettingGoodsPriceEventCall(this.GetActiveRowRowNo());

            // グリッドセル設定処理
            this.SettingGridRow(this.GetActiveRowIndex());
        }

        /// <summary>
        /// CellDataErrorイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_GoodsPriceInfo_CellDataError(object sender, Infragistics.Win.UltraWinGrid.CellDataErrorEventArgs e)
        {
            if (this.uGrid_GoodsPriceInfo.ActiveCell != null)
            {
                // 数値項目の場合
                if ((this.uGrid_GoodsPriceInfo.ActiveCell.Column.DataType == typeof(Int32)) ||
                    (this.uGrid_GoodsPriceInfo.ActiveCell.Column.DataType == typeof(Int64)) ||
                    (this.uGrid_GoodsPriceInfo.ActiveCell.Column.DataType == typeof(double)))
                {
                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_GoodsPriceInfo.ActiveCell.EditorResolved;

                    // 未入力は0にする
                    if (editorBase.CurrentEditText.Trim() == "")
                    {
                        editorBase.Value = 0;				// 0をセット
                        this.uGrid_GoodsPriceInfo.ActiveCell.Value = 0;
                    }
                    // 数値項目に「-」or「.」だけしか入ってなかったら駄目です
                    else if ((editorBase.CurrentEditText.Trim() == "-") ||
                        (editorBase.CurrentEditText.Trim() == ".") ||
                        (editorBase.CurrentEditText.Trim() == "-."))
                    {
                        editorBase.Value = 0;				// 0をセット
                        this.uGrid_GoodsPriceInfo.ActiveCell.Value = 0;
                    }
                    // 通常入力
                    else
                    {
                        try
                        {
                            editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.uGrid_GoodsPriceInfo.ActiveCell.Column.DataType);
                            this.uGrid_GoodsPriceInfo.ActiveCell.Value = editorBase.Value;
                        }
                        catch
                        {
                            editorBase.Value = 0;
                            this.uGrid_GoodsPriceInfo.ActiveCell.Value = 0;
                        }
                    }
                    e.RaiseErrorEvent = false;			// エラーイベントは発生させない
                    e.RestoreOriginalValue = false;		// セルの値を元に戻さない
                    e.StayInEditMode = false;			// 編集モードは抜ける
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                // 日付の場合
                else if ( this.uGrid_GoodsPriceInfo.ActiveCell.Column.DataType == typeof( DateTime ) )
                {
                    this.uGrid_GoodsPriceInfo.ActiveCell.Value = DateTime.MinValue;

                    e.RaiseErrorEvent = false;			// エラーイベントは発生させない
                    e.RestoreOriginalValue = false;		// セルの値を元に戻さない
                    e.StayInEditMode = false;			// 編集モードは抜ける
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
            }
        }
        
        private void uGrid_GoodsPriceInfo_Leave( object sender, EventArgs e )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/18 ADD
            if ( uGrid_GoodsPriceInfo.ActiveRow != null )
            {
                uGrid_GoodsPriceInfo.ActiveRow.Selected = false;
                uGrid_GoodsPriceInfo.ActiveRow = null;
                uGrid_GoodsPriceInfo.Invalidate();

                // ADD 2010/01/05 MANTIS対応[14816]：価格情報の再計算処理の修正 ---------->>>>>
                // MEMO:アクティブ行のデータで価格情報を再計算するので、アクティブ化
                this.uGrid_GoodsPriceInfo.Rows[CurrentRowIndex].Activate();
                // ADD 2010/01/05 MANTIS対応[14816]：価格情報の再計算処理の修正 ----------<<<<<
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/18 ADD
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/24 ADD
        /// <summary>
        /// コントロール入力可・不可設定
        /// </summary>
        /// <param name="enabled"></param>
        public void SettingEnabled( bool enabled )
        {
            _parentEnabled = enabled;
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_GoodsPriceInfo.DisplayLayout.Bands[0].Columns;

            try
            {
                if ( enabled )
                {
                    // カラム毎のActivation設定
                    Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 DEL
                    //Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
                    Columns[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    Columns[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    Columns[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD
                    Columns[this._goodsPriceDataTable.ListPriceColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    Columns[this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    Columns[this._goodsPriceDataTable.StockRateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    Columns[this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    Columns[this._goodsPriceDataTable.OfferDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                }
                else
                {
                    // 全カラムのActivationをDisabledにする
                    Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 DEL
                    //Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
                    Columns[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    Columns[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    Columns[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD
                    Columns[this._goodsPriceDataTable.ListPriceColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    Columns[this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    Columns[this._goodsPriceDataTable.StockRateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    Columns[this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    Columns[this._goodsPriceDataTable.OfferDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                }
            }
            catch
            { 
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
        private bool KeyPressNumCheck( int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg )
        {
            // 制御キーが押された？
            if ( Char.IsControl( key ) )
            {
                return true;
            }
            // 数値以外は、ＮＧ
            if ( !Char.IsDigit( key ) )
            {
                // 小数点または、マイナス以外
                if ( (key != '.') && (key != '-') )
                {
                    return false;
                }
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string _strResult = "";
            if ( sellength > 0 )
            {
                _strResult = prevVal.Substring( 0, selstart ) + prevVal.Substring( selstart + sellength, prevVal.Length - (selstart + sellength) );
            }
            else
            {
                _strResult = prevVal;
            }

            // マイナスのチェック
            if ( key == '-' )
            {
                if ( (minusFlg == false) || (selstart > 0) || (_strResult.IndexOf( '-' ) != -1) )
                {
                    return false;
                }
            }

            // 小数点のチェック
            if ( key == '.' )
            {
                if ( (priod <= 0) || (_strResult.IndexOf( '.' ) != -1) )
                {
                    return false;
                }
            }
            // キーが押された結果の文字列を生成する。
            _strResult = prevVal.Substring( 0, selstart )
                + key
                + prevVal.Substring( selstart + sellength, prevVal.Length - (selstart + sellength) );

            // 桁数チェック！
            if ( _strResult.Length > keta )
            {
                if ( _strResult[0] == '-' )
                {
                    if ( _strResult.Length > (keta + 1) )
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
            if ( priod > 0 )
            {
                // 小数点の位置決定
                int _pointPos = _strResult.IndexOf( '.' );

                // 整数部に入力可能な桁数を決定！
                int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
                // 整数部の桁数をチェック
                if ( _pointPos != -1 )
                {
                    if ( _pointPos > _Rketa )
                    {
                        return false;
                    }
                }
                else
                {
                    if ( _strResult.Length > _Rketa )
                    {
                        return false;
                    }
                }

                // 小数部の桁数をチェック
                if ( _pointPos != -1 )
                {
                    // 小数部の桁数を計算
                    int _priketa = _strResult.Length - _pointPos - 1;
                    if ( priod < _priketa )
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// グリッド・キープレス・イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_GoodsPriceInfo_KeyPress( object sender, KeyPressEventArgs e )
        {
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = uGrid_GoodsPriceInfo.ActiveCell;
            if ( cell == null ) return;


            if ( cell.Column.Key == this._goodsPriceDataTable.ListPriceColumn.ColumnName )
            {
                //----------------------------------------
                // 標準価格
                //----------------------------------------
                if ( cell.IsInEditMode )
                {
                    if ( !KeyPressNumCheck( 9, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false ) )
                    {
                        // イベント処理済みにする
                        e.Handled = true;
                    }
                }
            }
            else if (cell.Column.Key == this._goodsPriceDataTable.StockRateColumn.ColumnName) 
            {
                //----------------------------------------
                // 仕入率
                //----------------------------------------
                if ( cell.IsInEditMode )
                {
                    if ( !KeyPressNumCheck( 6, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false ) )
                    {
                        // イベント処理済みにする
                        e.Handled = true;
                    }
                }
            }
            else if (cell.Column.Key == this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName)
            {
                //----------------------------------------
                // 原単価
                //----------------------------------------
                if ( cell.IsInEditMode )
                {
                    // 2008.11.18 UPD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //if (!KeyPressNumCheck(12, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    if (!KeyPressNumCheck(10, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    // 2008.11.18 UPD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    {
                        // イベント処理済みにする
                        e.Handled = true;
                    }
                }
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
            else if ( cell.Column.Key == this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName )
            {
                //----------------------------------------
                // 価格開始日(年yyyy)
                //----------------------------------------
                if ( cell.IsInEditMode )
                {
                    if ( !KeyPressNumCheck( 4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false ) )
                    {
                        // イベント処理済みにする
                        e.Handled = true;
                    }
                }
            }
            else if ( cell.Column.Key == this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName )
            {
                //----------------------------------------
                // 価格開始日(月mm)
                //----------------------------------------
                if ( cell.IsInEditMode )
                {
                    if ( !KeyPressNumCheck( 2, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false ) )
                    {
                        // イベント処理済みにする
                        e.Handled = true;
                    }
                }
            }
            else if ( cell.Column.Key == this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName )
            {
                //----------------------------------------
                // 価格開始日(日dd)
                //----------------------------------------
                if ( cell.IsInEditMode )
                {
                    if ( !KeyPressNumCheck( 2, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false ) )
                    {
                        // イベント処理済みにする
                        e.Handled = true;
                    }
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/24 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
        /// <summary>
        /// 価格開始日の新入力値取得(BeforeCellUpdateイベント専用)
        /// </summary>
        /// <param name="columnKey"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private DateTime GetPriceStartDateFromNewInput( string columnKey, Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs e )
        {
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;

            string mode;
            # region [mode確定]
            const string ct_Year = "Year";
            const string ct_Month = "Month";
            const string ct_Day = "Day";

            if ( columnKey == this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName )
            {
                mode = ct_Month;
            }
            else if ( columnKey == this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName )
            {
                mode = ct_Day;
            }
            else
            {
                mode = ct_Year;
            }
            # endregion

            // 年月日の各値を取得
            int yy = 0;
            int mm = 0;
            int dd = 0;

            # region [yy/mm/dd取得]
            if ( mode == ct_Year )
            {
                yy = (Int32)e.NewValue;
            }
            else
            {
                if ( cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Value != DBNull.Value )
                {
                    yy = (Int32)cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Value;
                }
            }

            if ( mode == ct_Month )
            {
                mm = (Int32)e.NewValue;
            }
            else
            {
                if ( cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Value != DBNull.Value )
                {
                    mm = (Int32)cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Value;
                }
            }

            if ( mode == ct_Day )
            {
                dd = (Int32)e.NewValue;
            }
            else
            {
                if ( cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Value != DBNull.Value )
                {
                    dd = (Int32)cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Value;
                }
            }
            # endregion

            DateTime inputDate;
            # region [入力された日付の取得]
            try
            {
                inputDate = new DateTime( yy, mm, dd );
            }
            catch
            {
                inputDate = DateTime.MinValue;
            }
            # endregion


            return inputDate;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD
    }
}

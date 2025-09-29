using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;

using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 詳細グリッド制御クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 明細グリッドの制御を行うクラスです。</br>
    /// <br>Programmer : 照田 貴志</br>
    /// <br>Date       : 2008/09/04</br>
    /// <br>UpdateNote : 2009/01/16 照田 貴志　不具合対応[10145]</br>
    /// <br>Update Note: 2009/11/24 李侠</br>
    /// <br>             PM.NS-4・保守依頼③</br>
    /// <br>             区分の入力制御を追加</br>
    /// <br>Update Note: 2012/11/15 wangf </br>
    /// <br>           : 10801804-00、1月16日配信分、Redmine#31980 PM.NS障害一覧No.829の対応</br>
    /// <br>           : 在庫入庫更新の原単価は、回答データの原単価とPMの原単価と異なる場合黄色に変わる機能があるが</br>
    /// <br>           : 価格マスタの原価を変えても、色彩は変化しない。</br>
    /// </remarks>
	public partial class PMUOE01201UC : UserControl
	{
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region ▼定数
        // 列表示状態セッティングXMLファイル名
        private const string FILENAME_COLDISPLAYSTATUS = "PMUOE01201U_ColSetting2.DAT";
        // メッセージ
        private const string MESSAGE_INVALID_ENTERCNT = "[-999～999]の範囲で入力してください。";
        private const string MESSAGE_INVALID_ENTERCNTZERO = "[0]は指定できません。";
        private const string MESSAGE_INVALID_ENTERCNTMAX = "発注数を超えています。";
        private const string MESSAGE_INVALID_SALESUNITCOST = "[0～9,999,999.99]の範囲で入力してください。";
        // 色
        private Color COLOR_BACKCOLOR_DISABLED = Color.FromArgb(255, 255, 220);             // 使用不可時背景色1
        private Color COLOR_BACKCOLOR_NOTEQUAL = Color.Yellow;                              // 原単価不一致時背景色
        private Color COLOR_BACKCOLOR_SUBSTPARTS = Color.FromArgb(51, 153, 102);            // 代替品番時背景色
        #endregion

        #region ▼変数
        // 各種クラス
        private PMUOE01203AA _uoeEnterUpdAcs = null;                            // UOE入庫更新アクセスクラス
        private ColDisplayStatusList _colDisplayStatusList = null;              // 列表示コレクションクラス
        private DetailGridDataSet.DetailTableDataTable _detailTable = null;     // 明細データテーブル(主に列名取得に使用)
        // その他
        private bool _cellInputError = false;       // セル入力エラー
        #endregion

        #region ▼デリゲート
        // 明細グリッド→ヘッダーグリッドフォーカス移動
        public event MoveFocusHeaderGridFromDetailGridEventHandler MoveFocusHeaderGridFromDetailGrid;
        public delegate void MoveFocusHeaderGridFromDetailGridEventHandler(object sender, EventArgs e);
        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region ▼Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="UOEReplyIndicateAcs">UOE入庫更新アクセスクラス</param>
        /// <remarks>
        /// <br>Note       : クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public PMUOE01201UC(PMUOE01203AA uoeEnterUpdAcs)
        {
            InitializeComponent();

            // グリッド列データ取得
            this._uoeEnterUpdAcs = uoeEnterUpdAcs;
            this.uGrid_Detail.DataSource = this._uoeEnterUpdAcs.UOEEnterUpdDetailDataSet.DetailTable;
            this._detailTable = this._uoeEnterUpdAcs.UOEEnterUpdDetailDataSet.DetailTable;

            // 列表示コレクションクラスインスタンス化
            List<ColDisplayStatus> colDisplayStatusList = ColDisplayStatusList.Deserialize(FILENAME_COLDISPLAYSTATUS);
            this._colDisplayStatusList = new ColDisplayStatusList(colDisplayStatusList, ColDisplayStatusList.KBN_DETAIL);
        }
        #endregion

        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        #region ▼PMUOE01201UC_Load(フォームロード)
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">基本イベントデータ</param>
        /// <remarks>
        /// <br>Note       : グリッドの初期設定を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void PMUOE01201UC_Load(object sender, EventArgs e)
        {
            // グリッド列設定
            this.GridInitialSetting();

            // グリッド使用可/不可設定
            this.SetGridEnable();
        }
        #endregion

        #region ▼uGrid_Details_InitializeLayout(グリッドイニシャライズ)
        /// <summary>
        /// グリッドイニシャライズ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">イニシャライズレイアウトイベントデータ</param>
        /// <remarks>
        /// <br>Note       : グリッドの列を作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void uGrid_Details_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            // スクロールバー設定
            e.Layout.Scrollbars = Scrollbars.Both;
            // 各種アクションの設定
            e.Layout.Override.AllowColMoving = AllowColMoving.NotAllowed;                       // 列移動
            e.Layout.Override.AllowColSwapping = AllowColSwapping.NotAllowed;                   // 列交換
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;    // 抽出
            e.Layout.Override.HeaderClickAction = HeaderClickAction.Default;                    // ソート
            e.Layout.Override.CellClickAction = CellClickAction.Edit;                           // セルクリック時
            // 行セレクターの設定
            e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            e.Layout.Override.RowSelectorWidth = 18;                                            // 幅
            e.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.SeparateElement;  // ヘッダー部分のスタイル
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.None;             // 明細部の番号スタイル
            // 選択範囲の設定
            e.Layout.Override.SelectTypeRow = SelectType.None;
            e.Layout.Override.SelectTypeCol = SelectType.None;
            e.Layout.Override.SelectTypeCell = SelectType.None;
        }
        #endregion

        #region ▼uGrid_Details_KeyDown(グリッドキーダウン)
        /// <summary>
        /// グリッドキーダウン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">キーイベントデータ</param>
        /// <remarks>
        /// <br>Note       : キー押下時の動作を設定します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// <br>Update Note: 2009/11/24 李侠</br>
        /// <br>             PM.NS-4・保守依頼③</br>
        /// <br>             区分の入力制御を追加</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            // 選択なし
            if ((this.uGrid_Detail.ActiveRow == null) || (this.uGrid_Detail.ActiveCell == null))
            {
                return;
            }

            UltraGridCell cell = this.uGrid_Detail.ActiveCell;
            UltraGridRow row = this.uGrid_Detail.ActiveRow;

            #region Column = 区分
            if (cell.Column.Key == this._detailTable.DivCdColumn.ColumnName)
            {
                // --- ADD 2009/11/24 ---------->>>>>
                // 区分の入力制御
                // 空白
                if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0)
                {
                    row.Cells[this._detailTable.DivCdColumn.ColumnName].Value = PMUOE01202EA.DIVCD_NOCHANGE;
                }
                // 入荷
                else if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
                {
                    row.Cells[this._detailTable.DivCdColumn.ColumnName].Value = PMUOE01202EA.DIVCD_ENTER;
                }
                // 未入荷荷
                else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
                {
                    row.Cells[this._detailTable.DivCdColumn.ColumnName].Value = PMUOE01202EA.DIVCD_NOTENTER;
                }
                // 修正
                else if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
                {
                    row.Cells[this._detailTable.DivCdColumn.ColumnName].Value = PMUOE01202EA.DIVCD_UPDATE;
                }
                // 消込み
                else if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
                {
                    row.Cells[this._detailTable.DivCdColumn.ColumnName].Value = PMUOE01202EA.DIVCD_DELETE;
                }
                else
                {
                    //なし
                }
                // --- ADD 2009/11/24 ----------<<<<<
                // ←
                if (e.KeyCode == Keys.Left)
                {
                    // 値を確定(AfterCellUpdateイベントを起動)
                    if (cell.IsInEditMode)
                    {
                        this.uGrid_Detail.PerformAction(UltraGridAction.ExitEditMode);
                    }

                    // ヘッダーグリッドへ移動
                    this.MoveFocusHeaderGridFromDetailGrid(sender, e);
                    e.Handled = true;
                    return;

                }
                // →
                if (e.KeyCode == Keys.Right)
                {
                    // 値を確定(AfterCellUpdateイベントを起動)
                    if (cell.IsInEditMode)
                    {
                        this.uGrid_Detail.PerformAction(UltraGridAction.ExitEditMode);
                    }

                    // 一番最後のセルかどうかを判定し、一番最後の場合、ヘッダーへ移動
                    if (this.uGrid_Detail.ActiveRow.Index == (this.uGrid_Detail.Rows.Count - 1))
                    {
                        // 入庫が使用不可の場合、ヘッダーへ移動
                        if (this.uGrid_Detail.ActiveRow.Cells[this._detailTable.InputEnterCntColumn.ColumnName].Activation == Activation.Disabled)
                        {
                            EventArgs eventArgs = null;
                            this.MoveFocusHeaderGridFromDetailGrid(this, eventArgs);    // ヘッダーグリッドへ移動

                            return;
                        }
                    }
                }
            }
            #endregion

            #region Column = 入庫 or 原単価
            if ((cell.Column.Key == this._detailTable.InputEnterCntColumn.ColumnName) ||
                (cell.Column.Key == this._detailTable.InputAnswerSalesUnitCostColumn.ColumnName))
            {
                // ↑ or ↓
                if ((e.KeyCode == Keys.Up) ||
                    (e.KeyCode == Keys.Down))
                {
                    // Editを抜ける
                    this.uGrid_Detail.PerformAction(UltraGridAction.ExitEditMode);

                    return;
                }

                // ←
                if (e.KeyCode == Keys.Left)
                {
                    // Edit以外の場合、何もしない
                    if (cell.IsInEditMode == false)
                    {
                        return;
                    }

                    // Editの場合、一番左かどうかを判定し、一番左であれば区分へ移動
                    if (cell.SelStart == 0)
                    {
                        // 前のセルへ移動
                        this.uGrid_Detail.PerformAction(UltraGridAction.PrevCell);
                        e.Handled = true;       // 無効
                        return;
                    }
                }
                // →
                if (e.KeyCode == Keys.Right)
                {
                    // Edit以外の場合、何もしない
                    if (cell.IsInEditMode == false)
                    {
                        return;
                    }

                    // Editの場合、一番右かどうかを判定し、一番右であれば原単価 or ヘッダーへ移動
                    if (cell.SelStart == cell.Text.Length)
                    {
                        // 一番最後の場合、ヘッダーへ移動
                        if (this.uGrid_Detail.ActiveRow.Index == (this.uGrid_Detail.Rows.Count - 1))
                        {
                            if (this.uGrid_Detail.ActiveCell.Column.Key == this._detailTable.InputAnswerSalesUnitCostColumn.ColumnName)
                            {
                                EventArgs eventArgs = null;
                                this.MoveFocusHeaderGridFromDetailGrid(this, eventArgs);        // ヘッダーグリッドへ移動

                                return;
                            }
                        }

                        // 一番最後でない場合、次のセルへ移動
                        this.uGrid_Detail.PerformAction(UltraGridAction.NextCell);
                        e.Handled = true;       // 無効
                        return;
                    }
                }
            }
            #endregion
        }
        #endregion

        #region ▼uGrid_Details_Click(グリッドクリック)
        /// <summary>
        /// グリッドクリック
        /// </summary>
        /// <param name="sender">UltraGrid型</param>
        /// <param name="e">基本イベントデータ</param>
        /// <remarks>
        /// <br>Note       : クリック行をアクティブにします。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void uGrid_Details_Click(object sender, EventArgs e)
        {
            if (sender is UltraGrid)
            {
                UltraGrid targetGrid = (UltraGrid)sender;

                // マウスポインタがグリッドのどの位置にあるかを判定
                Point point = System.Windows.Forms.Cursor.Position;
                point = targetGrid.PointToClient(point);

                // UIElementを取得
                Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
                if (objUIElement == null)
                {
                    return;
                }

                // マウスポインターが列のヘッダ上にあるかチェック
                Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
                    (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));
                if (objHeader != null)
                {
                    return;
                }

                // マウスポインターが行の上にあるかチェック
                UltraGridRow objRow = (UltraGridRow)objUIElement.GetContext(typeof(UltraGridRow));
                if (objRow != null)
                {
                    // 行を選択
                    objRow.Activated = true;
                }
            }
        }
        #endregion

        #region ▼uGrid_Detail_Leave(グリッド非アクティブ)
        /// <summary>
        /// グリッド非アクティブ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">基本イベントデータ</param>
        /// <remarks>
        /// <br>Note       : グリッドを非選択状態にします。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void uGrid_Detail_Leave(object sender, EventArgs e)
        {
            if (this.uGrid_Detail.ActiveRow == null)
            {
                return;
            }

            // セルのアクティブ状態を消す
            this.uGrid_Detail.ActiveRow.Activated = false;
        }
        #endregion

        #region ▼uGrid_Detail_AfterCellListCloseUp(セルのリスト選択後)
        /// <summary>
        /// セルのリスト選択後
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">セルイベントデータ</param>
        /// <remarks>
        /// <br>Note       : Editモードを抜け、値が変更されている場合はAfterCellUpdateイベントを処理します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void uGrid_Detail_AfterCellListCloseUp(object sender, CellEventArgs e)
        {
            // 値を確定(AfterCellUpdateイベントを起動)
            if (e.Cell.IsInEditMode)
            {
                this.uGrid_Detail.PerformAction(UltraGridAction.ExitEditMode);
            }
        }
        #endregion

        #region ▼uGrid_Detail_BeforeCellUpdate(セル更新前)
        /// <summary>
        /// セル更新前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">セル更新前イベントデータ</param>
        /// <remarks>
        /// <br>Note       : セルへの入力チェックを行う。(型チェックはCellDataErrorで行われる)</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void uGrid_Detail_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            // 区分は処理しない
            if (e.Cell.Column.Key == this._detailTable.DivCdColumn.ColumnName)
            {
                return;
            }

            // 未入力チェック
            if (string.IsNullOrEmpty(e.NewValue.ToString()))
            {
                this.uGrid_Detail.PerformAction(UltraGridAction.PrevCellByTab);
                e.Cancel = true;
                return;
            }

            Double newValue = 0;
            double.TryParse(e.NewValue.ToString(), out newValue);

            // 入庫入力チェック
            if (e.Cell.Column.Key == this._detailTable.InputEnterCntColumn.ColumnName)
            {
                // 最小、最大
                if ((newValue < -999) || (999 < newValue))
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, MESSAGE_INVALID_ENTERCNT, -1, MessageBoxButtons.OK);
                    this.uGrid_Detail.PerformAction(UltraGridAction.PrevCellByTab);
                    e.Cancel = true;
                    return;
                }
                // 0は不可
                if (newValue == 0)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, MESSAGE_INVALID_ENTERCNTZERO, -1, MessageBoxButtons.OK);
                    this.uGrid_Detail.PerformAction(UltraGridAction.PrevCellByTab);
                    e.Cancel = true;
                    return;
                }

                // 発注数以上の入力不可
                if ((Int32)e.Cell.Row.Cells[this._detailTable.EnterCntColumn.ColumnName].Value < newValue)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, MESSAGE_INVALID_ENTERCNTMAX, -1, MessageBoxButtons.OK);
                    this.uGrid_Detail.PerformAction(UltraGridAction.PrevCellByTab);
                    e.Cancel = true;
                    return;
                }

            }

            // 原単価入力チェック
            if (e.Cell.Column.Key == this._detailTable.InputAnswerSalesUnitCostColumn.ColumnName)
            {
                // 最小、最大
                if ((newValue < 0) || (9999999.99 < newValue))
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, MESSAGE_INVALID_SALESUNITCOST, -1, MessageBoxButtons.OK);
                    this.uGrid_Detail.PerformAction(UltraGridAction.PrevCellByTab);
                    e.Cancel = true;
                }
            }
        }
        #endregion

        #region ▼uGrid_Detail_AfterCellUpdate(セル更新後)
        /// <summary>
        /// セル更新後 イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">セルイベントデータ</param>
        /// <remarks>
        /// <br>Note       : 区分の値を元に他項目の使用可/不可を設定します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void uGrid_Detail_AfterCellUpdate(object sender, CellEventArgs e)
        {

            // 「原単価」時
            if ((e.Cell.Column.Key == this._detailTable.InputEnterCntColumn.ColumnName) || 
                (e.Cell.Column.Key == this._detailTable.InputAnswerSalesUnitCostColumn.ColumnName))
            {
                // セルの色を変更
                this.ChangeColor(e.Cell.Row);

                // ヘッダーグリッドの合計を変更
                this._uoeEnterUpdAcs.HeaderGridTotalDisplay();
                return;
            }

            // その他「区分」以外は処理を行わない
            if (e.Cell.Column.Key != this._detailTable.DivCdColumn.ColumnName)
            {
                return;
            }
            if (this.uGrid_Detail.ActiveRow == null)
            {
                return;
            }

            // 入庫、原単価 編集可/不可設定
            this.ChangeColumnEditCondition(this.uGrid_Detail.ActiveRow);
        }
        #endregion

        #region ▼uGrid_Detail_CellDataError(セルデータエラー)
        /// <summary>
        /// セルデータエラー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">セルデータエラーイベントデータ</param>
        /// <remarks>
        /// <br>Note       : セルに入力された値が(int型に文字、小数点が入っている等)データ型と一致しない場合に発生する。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void uGrid_Detail_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            e.RaiseErrorEvent = false;          // エラーイベントを発生させない
            e.StayInEditMode = false;           // Editを抜ける

            this._cellInputError = true;
        }
        #endregion

        #region ▼uGrid_Detail_AfterCellActivate(セルアクティブ後)
        /// <summary>
        /// グリッドセルアクティブ後
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : Editになっていない項目をEdit状態とする。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void uGrid_Detail_AfterCellActivate(object sender, EventArgs e)
        {
            // 入庫、回答原単価がEditとなっていない場合、Editにする
            if ((this.uGrid_Detail.ActiveCell.Column.Key == this._detailTable.InputEnterCntColumn.ColumnName) ||
                (this.uGrid_Detail.ActiveCell.Column.Key == this._detailTable.InputAnswerSalesUnitCostColumn.ColumnName))
            {
                if (this.uGrid_Detail.ActiveCell.IsInEditMode == false)
                {
                    this.uGrid_Detail.PerformAction(UltraGridAction.EnterEditMode);
                }
            }

        }
        #endregion

        #region ▼ReturnKeyDown(Enterキー押下　※呼び出し元はPMUOE01201UA)
        /// <summary>
        /// Enterキー押下
        /// </summary>
        /// <param name="e">チェンジフォーカスイベントデータ</param>
        /// <remarks>
        /// <br>Note       : Enterキー押下時の動作。</br>
        /// <br>             Enterキー押下イベントはメインフォームがつかんでいる為、ここに記述してメインフォームから呼ぶ</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        internal void ReturnKeyDown(Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if ((this.uGrid_Detail.ActiveCell == null) || (this.uGrid_Detail.ActiveRow == null))
            {
                return;
            }

            // 値を確定(CellDataError→BeforeCellUpdate→AfterCellUpdateイベントを起動)
            if (this.uGrid_Detail.ActiveCell.IsInEditMode)
            {
                this.uGrid_Detail.PerformAction(UltraGridAction.ExitEditMode);
                // ※CellDataErrorでエラー発生時、this._cellInputError=Trueとなる
                if (this._cellInputError)
                {
                    this._cellInputError = false;
                    this.uGrid_Detail.PerformAction(UltraGridAction.EnterEditMode);
                    return;
                }
            }

            if (e.ShiftKey)
            {
                // Shift + Enter/Tab
                this.uGrid_Detail.PerformAction(UltraGridAction.PrevCell);
            }
            else
            {
                // 最後の項目時、ヘッダーにカーソルを移す
                if (this.uGrid_Detail.ActiveRow.Index == (this.uGrid_Detail.Rows.Count - 1))
                {
                    EventArgs eventArgs = null;

                    // 区分
                    if (this.uGrid_Detail.ActiveCell.Column.Key == this._detailTable.DivCdColumn.ColumnName)
                    {
                        if (this.uGrid_Detail.ActiveRow.Cells[this._detailTable.InputAnswerSalesUnitCostColumn.ColumnName].Activation == Activation.Disabled)
                        {
                            this.MoveFocusHeaderGridFromDetailGrid(this, eventArgs);    // ヘッダーグリッドへ移動
                            return;
                        }
                    }
                    // 原単価
                    if (this.uGrid_Detail.ActiveCell.Column.Key == this._detailTable.InputAnswerSalesUnitCostColumn.ColumnName)
                    {
                        this.MoveFocusHeaderGridFromDetailGrid(this, eventArgs);        // ヘッダーグリッドへ移動
                        return;
                    }
                }

                // Enter/Tab
                this.uGrid_Detail.PerformAction(UltraGridAction.NextCell);      // 次のセルへ移動
            }
        }
        #endregion

        // ===================================================================================== //
        // パブリック
        // ===================================================================================== //
        #region ▼SetGridEnable(グリッド使用可/不可判定)
        /// <summary>
        /// グリッド使用可/不可判定
        /// </summary>
        /// <returns>True：使用可、False：使用不可</returns>
        /// <remarks>
        /// <br>Note       : 明細情報の使用可/不可を判定し、設定します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public bool SetGridEnable()
        {
            this.uGrid_Detail.BeginUpdate();        // 描画を止める
            try
            {
                if (this.uGrid_Detail.Rows.Count == 0)
                {
                    // データなし
                    this.uGrid_Detail.Enabled = false;
                    return false;
                }

                // 使用可/不可設定
                if (this.uGrid_Detail.Enabled == true)
                {
                    this.uGrid_Detail.Rows[0].Cells[this._detailTable.DivCdColumn.ColumnName].Activate();   // フォーカス設定
                }

                // 列編集可/不可設定
                this.InitializeColumnEditCondition();

                // セル色設定
                this.ChangeColorAll();
            }
            finally
            {
                this.uGrid_Detail.EndUpdate();     // 再描画
                this.uGrid_Detail.Invalidate();    // 念の為、強制描画
            }
            return true;
        }
        #endregion

        #region ▼CangeCollorAll(全行に対して色変更)
        /// <summary>
        /// 全行に対して色変更
        /// </summary>
        /// <remarks>
        /// <br>Note       : 全行に対して色を設定します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public void ChangeColorAll()
        {
            for (int index = 0; index <= this.uGrid_Detail.Rows.Count - 1; index++)
            {
                this.ChangeColor(this.uGrid_Detail.Rows[index]);
            }

        }
        #endregion

        #region ▼InitializeColumnEditCondition(列編集可/不可初期設定)
        /// <summary>
        /// 列編集可/不可初期設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入庫、原単価列に対して編集可/不可を判定し、設定を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public void InitializeColumnEditCondition()
        {
            // 入庫、原単価の状態を設定
            for (int index = 0; index <= this.uGrid_Detail.Rows.Count - 1; index++)
            {
                UltraGridRow row = this.uGrid_Detail.Rows[index];
                // 「区分」が「3：修正」時、入庫、原単価を編集可とする
                if (row.Cells[this._detailTable.DivCdColumn.ColumnName].Value.ToString() == PMUOE01202EA.DIVCD_UPDATE)
                {
                    row.Cells[this._detailTable.InputEnterCntColumn.ColumnName].Activation = Activation.AllowEdit;              // 入庫
                    row.Cells[this._detailTable.InputAnswerSalesUnitCostColumn.ColumnName].Activation = Activation.AllowEdit;   // 原単価
                }
                else
                {
                    row.Cells[this._detailTable.InputEnterCntColumn.ColumnName].Activation = Activation.Disabled;               // 入庫
                    row.Cells[this._detailTable.InputAnswerSalesUnitCostColumn.ColumnName].Activation = Activation.Disabled;    // 原単価
                }
            }
        }
        #endregion

        #region ▼Closing(クローズ時処理)
        /// <summary>
		/// クローズ処理
		/// </summary>
        /// <remarks>
        /// <br>Note       : 列表示状態をXMLにシリアライズします。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        internal void Closing()
		{
            // 列表示状態クラスリスト構築処理
            List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.uGrid_Detail.DisplayLayout.Bands[0].Columns);
            this._colDisplayStatusList.SetColDisplayStatusList(colDisplayStatusList);

            // 列表示状態クラスリストをXMLにシリアライズする
            ColDisplayStatusList.Serialize(this._colDisplayStatusList.GetColDisplayStatusList(), FILENAME_COLDISPLAYSTATUS);
        }
        #endregion

        // ===================================================================================== //
        // プライベート
        // ===================================================================================== //
        #region ▼GridInitialSetting(グリッド列初期設定)
        /// <summary>
        /// グリッド列初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッドの列を作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// <br>Update Note: 2012/11/15 wangf </br>
        /// <br>           : 10801804-00、1月16日配信分、Redmine#31980 PM.NS障害一覧No.829の対応</br>
        /// <br>           : 在庫入庫更新の原単価は、回答データの原単価とPMの原単価と異なる場合黄色に変わる機能があるが</br>
        /// <br>           : 価格マスタの原価を変えても、色彩は変化しない。</br>
        /// </remarks>
        private void GridInitialSetting()
        {
            // 書式
            string integerFormat = "#,##0;-#,##0;''";
            string decimalFormat = "#,##0.00;-#,##0.00;'0'";

            // 区分リスト
            Infragistics.Win.ValueList vlist = new Infragistics.Win.ValueList();
            vlist.ValueListItems.Add(PMUOE01202EA.DIVCD_NOCHANGE, "　　　");
            vlist.ValueListItems.Add(PMUOE01202EA.DIVCD_ENTER, "入荷");
            vlist.ValueListItems.Add(PMUOE01202EA.DIVCD_NOTENTER, "未入荷");
            vlist.ValueListItems.Add(PMUOE01202EA.DIVCD_UPDATE, "修正");
            vlist.ValueListItems.Add(PMUOE01202EA.DIVCD_DELETE, "消込み");

            // カラム設定
            #region カラム情報設定
            ColumnsCollection columns = this.uGrid_Detail.DisplayLayout.Bands[0].Columns;
            String columnName = string.Empty;

            // No.
            columnName = this._detailTable.NoColumn.ColumnName;
            columns[columnName].Hidden = true;
            columns[columnName].Header.Caption = "No.";
            // 区分
            columnName = this._detailTable.DivCdColumn.ColumnName;
            columns[columnName].Hidden = false;
            columns[columnName].Header.Caption = "区分";
            columns[columnName].CellActivation = Activation.AllowEdit;
            columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            columns[columnName].ValueList = vlist;
            columns[columnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // 入庫
            columnName = this._detailTable.InputEnterCntColumn.ColumnName;
            columns[columnName].Hidden = false;
            columns[columnName].Header.Caption = "入庫";
            columns[columnName].CellActivation = Activation.AllowEdit;
            columns[columnName].MaxLength = 4;
            columns[columnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[columnName].Format = integerFormat;
            // 原単価(回答原価単価)
            columnName = this._detailTable.InputAnswerSalesUnitCostColumn.ColumnName;
            columns[columnName].Hidden = false;
            columns[columnName].Header.Caption = "原単価";
            columns[columnName].CellActivation = Activation.AllowEdit;
            columns[columnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[columnName].MaxLength = 10;
            columns[columnName].Format = decimalFormat;
            // 品番
            columnName = this._detailTable.GoodsNoColumn.ColumnName;
            columns[columnName].Hidden = false;
            columns[columnName].Header.Caption = "品番";
            columns[columnName].CellActivation = Activation.Disabled;
            columns[columnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // 品名
            columnName = this._detailTable.GoodsNameColumn.ColumnName;
            columns[columnName].Hidden = false;
            columns[columnName].Header.Caption = "品名";
            columns[columnName].CellActivation = Activation.Disabled;
            columns[columnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // 倉庫
            columnName = this._detailTable.WarehouseCodeColumn.ColumnName;
            columns[columnName].Hidden = false;
            columns[columnName].Header.Caption = "倉庫";
            columns[columnName].CellActivation = Activation.Disabled;
            columns[columnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // 棚番
            columnName = this._detailTable.WarehouseShelfNoColumn.ColumnName;
            columns[columnName].Hidden = false;
            columns[columnName].Header.Caption = "棚番";
            columns[columnName].CellActivation = Activation.Disabled;
            columns[columnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // 回答
            columnName = this._detailTable.SectionCntColumn.ColumnName;
            columns[columnName].Hidden = false;
            columns[columnName].Header.Caption = "回答";
            columns[columnName].CellActivation = Activation.Disabled;
            columns[columnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[columnName].Format = integerFormat;
            // BO数
            columnName = this._detailTable.BOCntColumn.ColumnName;
            columns[columnName].Hidden = false;
            columns[columnName].Header.Caption = "BO数";
            columns[columnName].CellActivation = Activation.Disabled;
            columns[columnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[columnName].Format = integerFormat;
            // 以下、比較用項目
            // 入庫数
            columnName = this._detailTable.EnterCntColumn.ColumnName;
            columns[columnName].Hidden = true;
            columns[columnName].Header.Caption = "入庫数";
            columns[columnName].Format = integerFormat;
            // 原単価(原価単価)
            columnName = this._detailTable.AnswerSalesUnitCostColumn.ColumnName;
            columns[columnName].Hidden = true;
            columns[columnName].Header.Caption = "回答原単価";
            columns[columnName].Format = decimalFormat;
            // 原単価(原価単価)
            columnName = this._detailTable.SalesUnitCostColumn.ColumnName;
            columns[columnName].Hidden = true;
            columns[columnName].Header.Caption = "原単価";
            columns[columnName].Format = decimalFormat;
            // 代替品番
            columnName = this._detailTable.SubstPartsNoColumn.ColumnName;
            columns[columnName].Hidden = true;
            columns[columnName].Header.Caption = "代替品番";
            // 回答品番
            columnName = this._detailTable.AnswerPartsNoColumn.ColumnName;
            columns[columnName].Hidden = true;
            columns[columnName].Header.Caption = "回答品番";
            // 以下、GridMainDataSet連携用項目
            // 仕入先コード
            columnName = this._detailTable.SupplierCdColumn.ColumnName;
            columns[columnName].Hidden = true;
            columns[columnName].Header.Caption = "仕入先コード";
            // 伝票番号
            columnName = this._detailTable.SlipNoColumn.ColumnName;
            columns[columnName].Hidden = true;
            columns[columnName].Header.Caption = "伝票番号";
            // オンライン番号
            columnName = this._detailTable.OnlineNoColumn.ColumnName;
            columns[columnName].Hidden = true;
            columns[columnName].Header.Caption = "オンライン番号";
            // オンライン行番号
            columnName = this._detailTable.OnlineRowNoColumn.ColumnName;
            columns[columnName].Hidden = true;
            columns[columnName].Header.Caption = "オンライン行番号";
            // ------------ADD wangf 2012/11/15 FOR Redmine#31980--------->>>>
            // 価格マスタよりの原価単価
            columnName = this._detailTable.GoodspriceuSalesUnitCostColumn.ColumnName;
            columns[columnName].Hidden = true;
            // ------------ADD wangf 2012/11/15 FOR Redmine#31980---------<<<<
            // 以下、在庫情報用項目
            // 在庫有無
            columnName = this._detailTable.StockExistsColumn.ColumnName;
            columns[columnName].Hidden = true;
            columns[columnName].Header.Caption = "在庫有無";
            #endregion

            // 幅、表示位置、列固定の設定
            foreach (ColDisplayStatus colDisplayStatus in this._colDisplayStatusList.GetColDisplayStatusList())
            {
                if (columns.Exists(colDisplayStatus.Key))
                {
                    columns[colDisplayStatus.Key].Width = colDisplayStatus.Width;
                    columns[colDisplayStatus.Key].Header.VisiblePosition = colDisplayStatus.VisiblePosition;
                    columns[colDisplayStatus.Key].Header.Fixed = colDisplayStatus.HeaderFixed;
                    columns[colDisplayStatus.Key].CellAppearance.BackColorDisabled = COLOR_BACKCOLOR_DISABLED;
                    columns[colDisplayStatus.Key].CellAppearance.BackColorDisabled2 = COLOR_BACKCOLOR_DISABLED;
                }
            }

            // 固定列区切り線設定
            this.uGrid_Detail.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_Detail.DisplayLayout.Override.HeaderAppearance.BackColor2;
        }
        #endregion

        #region ▼ColDisplayStatusListConstruction(グリッド→列表示状態クラスリスト作成)
        /// <summary>
        /// 列表示状態クラスリスト構築処理
        /// </summary>
        /// <param name="columns">グリッドのカラムコレクション</param>
        /// <returns>列表示状態クラスリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドから列表示状態クラスリストを作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/08/25</br>
        /// </remarks>
        private List<ColDisplayStatus> ColDisplayStatusListConstruction(Infragistics.Win.UltraWinGrid.ColumnsCollection columns)
        {
            List<ColDisplayStatus> colDisplayStatusList = new List<ColDisplayStatus>();

            // グリッドから列表示状態クラスリストを構築
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in columns)
            {
                ColDisplayStatus colDisplayStatus = new ColDisplayStatus();

                colDisplayStatus.Key = column.Key;                                  // 列名
                colDisplayStatus.VisiblePosition = column.Header.VisiblePosition;   // 列表示位置
                colDisplayStatus.HeaderFixed = column.Header.Fixed;                 // 列固定
                colDisplayStatus.Width = column.Width;                              // 列幅

                colDisplayStatusList.Add(colDisplayStatus);
            }

            return colDisplayStatusList;
        }
        #endregion

        #region ▼ChangeColumnEditCondition(列編集可/不可設定)
        /// <summary>
        /// 列編集可/不可設定
        /// </summary>
        /// <param name="row">グリッド行</param>
        /// <remarks>
        /// <br>Note       : 入庫、原単価列に対して編集可/不可設定を行います。また、状況に応じて区分の変更も行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void ChangeColumnEditCondition(UltraGridRow row)
        {
            // 「区分」が「3：修正」時、入庫、原単価を編集可とする
            if (row.Cells[this._detailTable.DivCdColumn.ColumnName].Value.ToString() == PMUOE01202EA.DIVCD_UPDATE)
            {
                row.Cells[this._detailTable.InputEnterCntColumn.ColumnName].Activation = Activation.AllowEdit;               // 入庫
                row.Cells[this._detailTable.InputAnswerSalesUnitCostColumn.ColumnName].Activation = Activation.AllowEdit;    // 原単価
            }
            else
            {
                row.Cells[this._detailTable.InputEnterCntColumn.ColumnName].Activation = Activation.Disabled;                // 入庫
                row.Cells[this._detailTable.InputAnswerSalesUnitCostColumn.ColumnName].Activation = Activation.Disabled;     // 原単価
            }

            // 区分変更
            if ((bool)row.Cells[this._detailTable.StockExistsColumn.ColumnName].Value == true)
            {
                // 在庫があり、「区分」が「△：未処理」時、「2：未入荷」とする
                if (row.Cells[this._detailTable.DivCdColumn.ColumnName].Value.ToString() == PMUOE01202EA.DIVCD_NOCHANGE)
                {
                    row.Cells[this._detailTable.DivCdColumn.ColumnName].Value = PMUOE01202EA.DIVCD_NOTENTER;
                }
            }
            else
            {
                // 在庫が無く、「区分」が「1：入荷」「3：修正」時、「2：未入荷」とする
                if ((row.Cells[this._detailTable.DivCdColumn.ColumnName].Value.ToString() == PMUOE01202EA.DIVCD_ENTER) ||
                    (row.Cells[this._detailTable.DivCdColumn.ColumnName].Value.ToString() == PMUOE01202EA.DIVCD_UPDATE))
                {
                    row.Cells[this._detailTable.DivCdColumn.ColumnName].Value = PMUOE01202EA.DIVCD_NOTENTER;
                }
            }
        }
        #endregion

        #region ▼ChangeColor(行に対して色変更)
        /// <summary>
        /// 行に対して色変更
        /// </summary>
        /// <param name="row">変更対象行</param>
        /// <remarks>
        /// <br>Note       : 指定行に対して色を設定します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// <br>Update Note: 2012/11/15 wangf </br>
        /// <br>           : 10801804-00、1月16日配信分、Redmine#31980 PM.NS障害一覧No.829の対応</br>
        /// <br>           : 在庫入庫更新の原単価は、回答データの原単価とPMの原単価と異なる場合黄色に変わる機能があるが</br>
        /// <br>           : 価格マスタの原価を変えても、色彩は変化しない。</br>
        /// </remarks>
        private void ChangeColor(UltraGridRow row)
        {
            Color backColor = row.Cells[this._detailTable.DivCdColumn.ColumnName].Appearance.BackColor;                 // 背景色

            // 原単価
            string inputValue = row.Cells[this._detailTable.AnswerSalesUnitCostColumn.ColumnName].Value.ToString();    // 回答原価単価
            //string compValue = row.Cells[this._detailTable.SalesUnitCostColumn.ColumnName].Value.ToString();           // 原価単価 // DEL wangf 2012/11/15 FOR Redmine#31980
            // ------------ADD wangf 2012/11/15 FOR Redmine#31980--------->>>>
            // 原価単価（価格マスタより）
            string compValue = row.Cells[this._detailTable.GoodspriceuSalesUnitCostColumn.ColumnName].Value.ToString();
            // ------------ADD wangf 2012/11/15 FOR Redmine#31980---------<<<<
            if (inputValue == compValue)
            {
                row.Cells[this._detailTable.InputAnswerSalesUnitCostColumn.ColumnName].Appearance.BackColor = backColor;
                row.Cells[this._detailTable.InputAnswerSalesUnitCostColumn.ColumnName].Appearance.BackColor2 = backColor;
                row.Cells[this._detailTable.InputAnswerSalesUnitCostColumn.ColumnName].Appearance.BackColorDisabled = COLOR_BACKCOLOR_DISABLED;
                row.Cells[this._detailTable.InputAnswerSalesUnitCostColumn.ColumnName].Appearance.BackColorDisabled2 = COLOR_BACKCOLOR_DISABLED;
            }
            else
            {
                row.Cells[this._detailTable.InputAnswerSalesUnitCostColumn.ColumnName].Appearance.BackColor = COLOR_BACKCOLOR_NOTEQUAL;
                row.Cells[this._detailTable.InputAnswerSalesUnitCostColumn.ColumnName].Appearance.BackColor2 = COLOR_BACKCOLOR_NOTEQUAL;
                row.Cells[this._detailTable.InputAnswerSalesUnitCostColumn.ColumnName].Appearance.BackColorDisabled = COLOR_BACKCOLOR_NOTEQUAL;
                row.Cells[this._detailTable.InputAnswerSalesUnitCostColumn.ColumnName].Appearance.BackColorDisabled2 = COLOR_BACKCOLOR_NOTEQUAL;
            }

            // 品名、品番
            string substPartsNo = row.Cells[this._detailTable.SubstPartsNoColumn.ColumnName].Value.ToString().TrimEnd();
            string goodsNo = row.Cells[this._detailTable.GoodsNoColumn.ColumnName].Value.ToString().TrimEnd();              //ADD 2009/01/16 不具合対応[10145]
            if (string.IsNullOrEmpty(substPartsNo))
            {
                /* ---DEL 2009/01/16 不具合対応[10145] ------------------------------------------------------------------------>>>>>
                // 品名
                row.Cells[this._detailTable.GoodsNameColumn.ColumnName].Appearance.BackColor = backColor;
                row.Cells[this._detailTable.GoodsNameColumn.ColumnName].Appearance.BackColor2 = backColor;
                row.Cells[this._detailTable.GoodsNameColumn.ColumnName].Appearance.BackColorDisabled = COLOR_BACKCOLOR_DISABLED;
                row.Cells[this._detailTable.GoodsNameColumn.ColumnName].Appearance.BackColorDisabled2 = COLOR_BACKCOLOR_DISABLED;
                   ---DEL 2009/01/16 不具合対応[10145] ------------------------------------------------------------------------<<<<< */
                // 品番
                row.Cells[this._detailTable.GoodsNoColumn.ColumnName].Appearance.BackColor = backColor;
                row.Cells[this._detailTable.GoodsNoColumn.ColumnName].Appearance.BackColor2 = backColor;
                row.Cells[this._detailTable.GoodsNoColumn.ColumnName].Appearance.BackColorDisabled = COLOR_BACKCOLOR_DISABLED;
                row.Cells[this._detailTable.GoodsNoColumn.ColumnName].Appearance.BackColorDisabled2 = COLOR_BACKCOLOR_DISABLED;
            }
            else
            {
                /* ---DEL 2009/01/16 不具合対応[10145] ------------------------------------------------------------------------>>>>>
                // 品名
                row.Cells[this._detailTable.GoodsNameColumn.ColumnName].Appearance.BackColor = COLOR_BACKCOLOR_SUBSTPARTS;
                row.Cells[this._detailTable.GoodsNameColumn.ColumnName].Appearance.BackColor2 = COLOR_BACKCOLOR_SUBSTPARTS;
                row.Cells[this._detailTable.GoodsNameColumn.ColumnName].Appearance.BackColorDisabled = COLOR_BACKCOLOR_SUBSTPARTS;
                row.Cells[this._detailTable.GoodsNameColumn.ColumnName].Appearance.BackColorDisabled2 = COLOR_BACKCOLOR_SUBSTPARTS;
                // 品番
                row.Cells[this._detailTable.GoodsNoColumn.ColumnName].Appearance.BackColor = COLOR_BACKCOLOR_SUBSTPARTS;
                row.Cells[this._detailTable.GoodsNoColumn.ColumnName].Appearance.BackColor2 = COLOR_BACKCOLOR_SUBSTPARTS;
                row.Cells[this._detailTable.GoodsNoColumn.ColumnName].Appearance.BackColorDisabled = COLOR_BACKCOLOR_SUBSTPARTS;
                row.Cells[this._detailTable.GoodsNoColumn.ColumnName].Appearance.BackColorDisabled2 = COLOR_BACKCOLOR_SUBSTPARTS;
                    ---DEL 2009/01/16 不具合対応[10145] ------------------------------------------------------------------------<<<<< */
                // ---ADD 2009/01/16 不具合対応[10145] ------------------------------------------------------------------------>>>>>
                // 品名と代替品番が同じ場合は代替品採用、異なる場合は発注品採用とみなす
                if (goodsNo == substPartsNo)
                {
                    // 「代替品採用」
                    // 品番
                    row.Cells[this._detailTable.GoodsNoColumn.ColumnName].Appearance.BackColor = COLOR_BACKCOLOR_SUBSTPARTS;
                    row.Cells[this._detailTable.GoodsNoColumn.ColumnName].Appearance.BackColor2 = COLOR_BACKCOLOR_SUBSTPARTS;
                    row.Cells[this._detailTable.GoodsNoColumn.ColumnName].Appearance.BackColorDisabled = COLOR_BACKCOLOR_SUBSTPARTS;
                    row.Cells[this._detailTable.GoodsNoColumn.ColumnName].Appearance.BackColorDisabled2 = COLOR_BACKCOLOR_SUBSTPARTS;
                }
                else
                {
                    // 「発注品採用」
                    // 品番
                    row.Cells[this._detailTable.GoodsNoColumn.ColumnName].Appearance.BackColor = backColor;
                    row.Cells[this._detailTable.GoodsNoColumn.ColumnName].Appearance.BackColor2 = backColor;
                    row.Cells[this._detailTable.GoodsNoColumn.ColumnName].Appearance.BackColorDisabled = COLOR_BACKCOLOR_DISABLED;
                    row.Cells[this._detailTable.GoodsNoColumn.ColumnName].Appearance.BackColorDisabled2 = COLOR_BACKCOLOR_DISABLED;
                }
                // ---ADD 2009/01/16 不具合対応[10145] ------------------------------------------------------------------------<<<<<
            }
        }
        #endregion
    }
}

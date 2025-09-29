using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;

using Infragistics.Win.UltraWinGrid;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ヘッダーグリッド制御クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ヘッダーグリッドの制御を行うクラスです。</br>
    /// <br>Programmer : 照田 貴志</br>
    /// <br>Date       : 2008/09/04</br>
    /// <br>Update Note: 2009/11/24 李侠</br>
    /// <br>             PM.NS-4・保守依頼③</br>
    /// <br>             区分の入力制御を追加</br>
    /// </remarks>
	public partial class PMUOE01201UB : UserControl
	{
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region ▼定数
        // 列表示状態セッティングXMLファイル名
        private const string FILENAME_COLDISPLAYSTATUS = "PMUOE01201U_ColSetting1.DAT";
        // 色
        private Color COLOR_BACKCOLOR_DISABLED = Color.FromArgb(255, 255, 220);             // 使用不可時背景色1
        private Color COLOR_BACKCOLOR_DISABLED2 = Color.FromArgb(255, 255, 220);            // 使用不可時背景色2
        #endregion

        #region ▼変数
        // 各種クラス
        private PMUOE01203AA _uoeEnterUpdAcs = null;                            // UOE入庫更新アクセスクラス
        private ColDisplayStatusList _colDisplayStatusList = null;              // 列表示コレクションクラス
        private HeaderGridDataSet.HeaderTableDataTable _headerTable = null;     // ヘッダーデータテーブル(主に列名取得に使用)
        // キャンセルフラグ
        // ※Enterキー押下時、ReturnKeyDown→BeforeCellUpdate→ReturnKeyDownと動くのでBeforeCellUpdateの後のReturnKeyDownを無効とする為のフラグ
        private bool _cancelFlg = false;                                        
        #endregion

        #region ▼デリゲート
        // 明細グリッド使用可/不可設定
        public event DetailEnableSettingEventHandler DetailEnableSetting;
        public delegate void DetailEnableSettingEventHandler(object sender, bool enableFlg);
        // ヘッダーグリッド→明細グリッドフォーカス移動
        public event MoveFocusDetailGridFromHeaderGridEventHandler MoveFocusDetailGridFromHeaderGrid;
        public delegate void MoveFocusDetailGridFromHeaderGridEventHandler(object sender, EventArgs e);
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
        public PMUOE01201UB(PMUOE01203AA uoeEnterUpdAcs)
        {
            InitializeComponent();

            // グリッド列データ取得
            this._uoeEnterUpdAcs = uoeEnterUpdAcs;
            this.uGrid_Header.DataSource = this._uoeEnterUpdAcs.UOEEnterUpdHeaderDataSet.HeaderTable;
            this._headerTable = this._uoeEnterUpdAcs.UOEEnterUpdHeaderDataSet.HeaderTable;

            // 列表示コレクションクラスインスタンス化
            List<ColDisplayStatus> colDisplayStatusList = ColDisplayStatusList.Deserialize(FILENAME_COLDISPLAYSTATUS);
            this._colDisplayStatusList = new ColDisplayStatusList(colDisplayStatusList, ColDisplayStatusList.KBN_HEADER);
        }
        #endregion

        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        #region ▼PMUOE01201UB_Load(フォームロード)
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
        private void PMUOE01201UB_Load(object sender, EventArgs e)
        {
            // グリッド列設定
            this.GridInitialSetting();

            // グリッド使用可/不可設定
            this.SetGridEnable();
        }
        #endregion

        #region ▼uGrid_Header_InitializeLayout(グリッドイニシャライズ)
        /// <summary>
        /// グリッドイニシャライズ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">イニシャライズレイアウトイベントデータ</param>
        /// <remarks>
        /// <br>Note       : グリッドの各種設定を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void uGrid_Header_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            // スクロールバー設定
            e.Layout.Scrollbars = Scrollbars.Both;
            // 各種アクションの設定
            e.Layout.Override.AllowColMoving = AllowColMoving.NotAllowed;                       // 列移動
            e.Layout.Override.AllowColSizing = AllowColSizing.None;                             // 列サイズ変更
            e.Layout.Override.AllowColSwapping = AllowColSwapping.NotAllowed;                   // 列交換
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;    // 抽出
            e.Layout.Override.HeaderClickAction = HeaderClickAction.Default;                    // ソート
            e.Layout.Override.CellClickAction = CellClickAction.Edit;                           // セルクリック時
            // 行セレクターの設定
            e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            e.Layout.Override.RowSelectorWidth = 38;                                            // 幅
            e.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.SeparateElement;  // ヘッダー部分のスタイル
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex;         // 明細部の番号スタイル
            // 選択範囲の設定
            e.Layout.Override.SelectTypeRow = SelectType.None;
            e.Layout.Override.SelectTypeCol = SelectType.None;
            e.Layout.Override.SelectTypeCell = SelectType.None;
        }
        #endregion

        #region ▼uGrid_Header_KeyDown(グリッドキーダウン)
        /// <summary>
        /// グリッドキーダウン
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キーイベントデータ</param>
        /// <remarks>
        /// <br>Note       : キー押下時の動作を設定します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// <br>Update Note: 2009/11/24 李侠</br>
        /// <br>             PM.NS-4・保守依頼③</br>
        /// <br>             区分の入力制御を追加</br>
        /// </remarks>
        private void uGrid_Header_KeyDown(object sender, KeyEventArgs e)
        {
            // 選択なし
            if ((this.uGrid_Header.ActiveRow == null) || (this.uGrid_Header.ActiveCell == null))
            {
                return;
            }

            UltraGridCell cell = this.uGrid_Header.ActiveCell;
            UltraGridRow row = this.uGrid_Header.ActiveRow;

            #region Column = 区分
            if (cell.Column.Key == this._headerTable.DivCdColumn.ColumnName)
            {
                // --- ADD 2009/11/24 ---------->>>>>
                // 区分の入力制御
                // 空白
                if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0)
                {
                    row.Cells[this._headerTable.DivCdColumn.ColumnName].Value = PMUOE01202EA.DIVCD_NOCHANGE;
                }
                // 入荷
                else if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
                {
                    row.Cells[this._headerTable.DivCdColumn.ColumnName].Value = PMUOE01202EA.DIVCD_ENTER;
                }
                // 未入荷荷
                else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
                {
                    row.Cells[this._headerTable.DivCdColumn.ColumnName].Value = PMUOE01202EA.DIVCD_NOTENTER;
                }
                // 修正
                else if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
                {
                    row.Cells[this._headerTable.DivCdColumn.ColumnName].Value = PMUOE01202EA.DIVCD_UPDATE;
                }
                // 消込み
                else if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
                {
                    row.Cells[this._headerTable.DivCdColumn.ColumnName].Value = PMUOE01202EA.DIVCD_DELETE;
                }
                else
                {
                    //なし
                }
                // --- ADD 2009/11/24 ----------<<<<<
                // ←
                if (e.KeyCode == Keys.Left)
                {
                    e.Handled = true;           // 無効
                    return;
                }
                // →
                if (e.KeyCode == Keys.Right)
                {
                    // 値を確定(AfterCellUpdateイベントを起動)
                    if (cell.IsInEditMode)
                    {
                        this.uGrid_Header.PerformAction(UltraGridAction.ExitEditMode);
                    }

                    // 伝票番号使用不可の場合、明細へ移動
                    if (row.Cells[this._headerTable.SlipNoColumn.ColumnName].Activation == Activation.Disabled)
                    {
                        this.MoveFocusDetailGridFromHeaderGrid(sender, e);
                        e.Handled = true;       // 無効
                        return;
                    }

                    //// 伝票番号使用可の場合、Editに
                    //this.uGrid_Header.PerformAction(UltraGridAction.NextCellByTab);
                    //e.Handled = true;       // 無効
                    return;
                }
            }
            #endregion

            #region Column = 伝票番号
            if (cell.Column.Key == this._headerTable.SlipNoColumn.ColumnName)
            {
                // ↑ or ↓
                if ((e.KeyCode == Keys.Up) ||
                    (e.KeyCode == Keys.Down))
                {
                    // Editを抜ける
                    this.uGrid_Header.PerformAction(UltraGridAction.ExitEditMode);

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
                        this.uGrid_Header.PerformAction(UltraGridAction.PrevCell);
                        e.Handled = true;       // 無効
                        return;
                    }
                }

                // →
                if (e.KeyCode == Keys.Right)
                {
                    // Edit以外の場合、明細へ移動
                    if (cell.IsInEditMode == false)
                    {
                        this.MoveFocusDetailGridFromHeaderGrid(sender, e);
                        e.Handled = true;       // 無効
                        return;
                    }

                    // Editの場合、一番右かどうかを判定し、一番右であれば明細へ移動
                    if (cell.SelStart == cell.Text.Length)
                    {
                        this.MoveFocusDetailGridFromHeaderGrid(sender, e);
                        e.Handled = true;       // 無効
                        return;
                    }
                }
            }
            #endregion
        }
        #endregion

        #region ▼uGrid_Header_Click(グリッドクリック)
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
        private void uGrid_Header_Click(object sender, EventArgs e)
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
                    // AfterRowActivateイベントを起動
                    objRow.Activated = true;
                }
            }
        }
        #endregion

        #region ▼uGrid_Header_Leave(グリッド非アクティブ)
        /// <summary>
        /// グリッド非アクティブ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : セレクタの選択のみ残してアクティブ状態を解除します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void uGrid_Header_Leave(object sender, EventArgs e)
        {
            if (this.uGrid_Header.ActiveRow == null)
            {
                return;
            }

            // ※以下、セルのアクティブ状態を消し、セレクタの矢印のみを残す為の処理

            // 選択行保持
            int index = this.uGrid_Header.ActiveRow.Index;

            // セルのアクティブ状態を消す
            this.uGrid_Header.ActiveRow.Activated = false;

            // セレクタのアクティブ状態を残す
            this.uGrid_Header.Rows[index].Activated = true;
        }
        #endregion

        #region ▼uGrid_Header_AfterRowActivate(行アクティブ後)
        /// <summary>
        /// 行アクティブ後
        /// </summary>
        /// <param name="sender">UltraGrid型</param>
        /// <param name="e">基本イベントデータ</param>
        /// <remarks>
        /// <br>Note       : 選択行に対応する明細を表示します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void uGrid_Header_AfterRowActivate(object sender, EventArgs e)
        {
            if (sender is UltraGrid)
            {
                UltraGridRow row = ((UltraGrid)sender).ActiveRow;
                if (row == null)
                {
                    return;
                }

                // 明細取得
                int rowNo = (int)row.Cells[this._headerTable.NoColumn.ColumnName].Value;
                this._uoeEnterUpdAcs.DetailGridDataDisplay(rowNo);

                // 伝票番号編集可/不可設定
                this.ChangeColumnEditCondition(row);

                // 明細使用可/不可設定
                this.ChangeDetailGridEnableCondition(row);
            }
        }
        #endregion

        #region ▼uGrid_Header_AfterCellActivate(グリッドセルアクティブ後)
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
        private void uGrid_Header_AfterCellActivate(object sender, EventArgs e)
        {
            // 伝票番号がEditとなっていない場合、Editにする
            if (this.uGrid_Header.ActiveCell.Column.Key == this._headerTable.SlipNoColumn.ColumnName)
            {
                if (this.uGrid_Header.ActiveCell.IsInEditMode == false)
                {
                    this.uGrid_Header.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
        }
        #endregion

        #region ▼uGrid_Header_AfterCellListCloseUp(セルのリスト選択後)
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
        private void uGrid_Header_AfterCellListCloseUp(object sender, CellEventArgs e)
        {
            // 値を確定(AfterCellUpdateイベントを起動)
            if (e.Cell.IsInEditMode)
            {
                this.uGrid_Header.PerformAction(UltraGridAction.ExitEditMode);
            }
        }
        #endregion

        #region ▼uGrid_Header_BeforeCellUpdate(セル更新前)
        /// <summary>
        /// セル更新前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 選択された区分のチェックを行います。対象の仕入先が登録されていない場合、エラーとなります。(買掛オプションありの時のみ)</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void uGrid_Header_BeforeCellUpdate(object sender, BeforeCellUpdateEventArgs e)
        {
            string divCd = e.NewValue.ToString();

            // 区分チェック
            // ※買掛オプションありの場合、UOE発注データ上の仕入先コードが仕入先マスタに存在するかチェック
            if ((divCd == PMUOE01202EA.DIVCD_ENTER) || (divCd == PMUOE01202EA.DIVCD_UPDATE))
            {
                int rowNo = (int)this.uGrid_Header.ActiveRow.Cells[this._headerTable.NoColumn.ColumnName].Value;
                bool status = this._uoeEnterUpdAcs.CheckSupplierCdIsExists(rowNo);
                if (status == false)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name, "仕入先が存在しません。", -1, MessageBoxButtons.OK);

                    e.Cancel = true;
                    this._cancelFlg = true;
                    return;
                }
            }
        }
        #endregion

        #region ▼uGrid_Header_AfterCellUpdate(セル更新後)
        /// <summary>
        /// セル更新後 イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">セルイベントデータ</param>
        /// <remarks>
        /// <br>Note       : 区分の値を元に他項目、及び明細の使用可/不可を設定します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void uGrid_Header_AfterCellUpdate(object sender, CellEventArgs e)
        {
            // 「区分」以外は処理を行わない
            if (e.Cell.Column.Key != this._headerTable.DivCdColumn.ColumnName)
            {
                return;
            }
            if (this.uGrid_Header.ActiveRow == null)
            {
                return;
            }

            // 明細の「区分」変更
            string divCd = e.Cell.Value.ToString();
            this._uoeEnterUpdAcs.DetailGridDivCdDisplayAll(divCd);

            // 伝票番号編集可/不可設定
            this.ChangeColumnEditCondition(this.uGrid_Header.ActiveRow);

            // 明細使用可/不可設定
            this.ChangeDetailGridEnableCondition(this.uGrid_Header.ActiveRow);
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
            if (this.uGrid_Header.ActiveCell == null)
            {
                return;
            }

            // 値を確定(BeforeCellUpdate,AfterCellUpdateイベントを起動　※エラー時はBeforeCellUpdateのみ起動となる)
            if (this.uGrid_Header.ActiveCell.IsInEditMode)
            {
                this._cancelFlg = false;
                this.uGrid_Header.PerformAction(UltraGridAction.ExitEditMode);
                if (this._cancelFlg)
                {
                    this._cancelFlg = false;
                    return;
                }
            }

            if (e.ShiftKey)
            {
                // Shift + Enter/Tab
                this.uGrid_Header.PerformAction(UltraGridAction.PrevCell);
            }
            else
            {
                // Enter/Tab
                if (this.uGrid_Header.ActiveCell.Column.Key == this._headerTable.SlipNoColumn.ColumnName)
                {
                    EventArgs eventArgs = null;
                    this.MoveFocusDetailGridFromHeaderGrid(this, eventArgs);        // 明細グリッドへ移動
                    return;
                }
                else
                {
                    this.uGrid_Header.PerformAction(UltraGridAction.NextCell);      // 次のセルへ移動
                }
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
            this.uGrid_Header.BeginUpdate();        // 描画を止める
            try
            {
                if (this.uGrid_Header.Rows.Count == 0)
                {
                    // データなし
                    this.uGrid_Header.Enabled = false;
                    return false;
                }

                // 使用可/不可設定
                this.uGrid_Header.Enabled = true;                                                       // 使用可
                this.uGrid_Header.Rows[0].Cells[this._headerTable.DivCdColumn.ColumnName].Activate();   // フォーカス設定

                // 伝票番号の状態を変更不可に設定
                for (int index = 0; index <= this.uGrid_Header.Rows.Count - 1; index++)
                {
                    this.ChangeColumnEditCondition(this.uGrid_Header.Rows[index]);
                }

                // 明細使用不可
                this.DetailEnableSetting(this, false);
            }
            finally
            {
                this.uGrid_Header.EndUpdate();      // 再描画
                this.uGrid_Header.Invalidate();     // 念の為、強制描画
            }
            return true;
        }
        #endregion

        #region ▼SetFocusDivCdColumn(区分にフォーカスをあてる処理)
        /// <summary>
        /// 区分にフォーカスをあてる処理
        /// </summary>
        /// <param name="rowNo">対象となる行番号</param>
        /// <remarks>
        /// <br>Note       : 指定された行の区分にフォーカスをあてます。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        public void SetFocusDivCdColumn(int rowNo)
        {
            this.uGrid_Header.Rows[rowNo].Cells[this._headerTable.DivCdColumn.ColumnName].Activated = true;
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
            List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.uGrid_Header.DisplayLayout.Bands[0].Columns);
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
        /// </remarks>
        private void GridInitialSetting()
        {
            // 書式
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
            ColumnsCollection columns = this.uGrid_Header.DisplayLayout.Bands[0].Columns;
            String columnName = string.Empty;
            // No.
            columnName = this._headerTable.NoColumn.ColumnName;
            columns[columnName].Hidden = true;
            columns[columnName].Header.Caption = "No.";
            columns[columnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // 区分
            columnName = this._headerTable.DivCdColumn.ColumnName;
            columns[columnName].Hidden = false;
            columns[columnName].Header.Caption = "区分";
            columns[columnName].CellActivation = Activation.AllowEdit;
            columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            columns[columnName].ValueList = vlist;
            columns[columnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // 伝票番号
            columnName = this._headerTable.SlipNoColumn.ColumnName;
            columns[columnName].Hidden = false;
            columns[columnName].Header.Caption = "伝票番号";
            columns[columnName].CellActivation = Activation.AllowEdit;
            columns[columnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[columnName].MaxLength = 13;
            columns[columnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // リマーク
            columnName = this._headerTable.RemarkColumn.ColumnName;
            columns[columnName].Hidden = false;
            columns[columnName].Header.Caption = "リマーク";
            columns[columnName].CellActivation = Activation.Disabled;
            columns[columnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // 合計
            columnName = this._headerTable.TotalColumn.ColumnName;
            columns[columnName].Hidden = false;
            columns[columnName].Header.Caption = "合計";
            columns[columnName].CellActivation = Activation.Disabled;
            columns[columnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[columnName].Format = decimalFormat;
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
                    columns[colDisplayStatus.Key].CellAppearance.BackColorDisabled2 = COLOR_BACKCOLOR_DISABLED2;
                }
            }

            // 固定列区切り線設定
            this.uGrid_Header.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_Header.DisplayLayout.Override.HeaderAppearance.BackColor2;
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
        /// <br>Date       : 2008/09/04</br>
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
        /// <br>Note       : 伝票番号に対して編集可/不可設定を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void ChangeColumnEditCondition(UltraGridRow row)
        {
            // 「区分」が「3：修正」時、伝票番号を編集可とする
            if (row.Cells[this._headerTable.DivCdColumn.ColumnName].Value.ToString() == PMUOE01202EA.DIVCD_UPDATE)
            {
                row.Cells[this._headerTable.SlipNoColumn.ColumnName].Activation = Activation.AllowEdit;     // 編集可
            }
            else
            {
                row.Cells[this._headerTable.SlipNoColumn.ColumnName].Activation = Activation.Disabled;      // 編集不可
            }
        }
        #endregion

        #region ▼ChangeDetailGridEnableCondition(明細グリッド使用可/不可設定)
        /// <summary>
        /// 明細グリッド使用可/不可設定
        /// </summary>
        /// <param name="row"></param>
        /// <remarks>
        /// <br>Note       : 明細グリッドの使用可/不可を設定します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/09/04</br>
        /// </remarks>
        private void ChangeDetailGridEnableCondition(UltraGridRow row)
        {
            // 「区分」が「△：未処理」時、明細を使用不可とする
            if (row.Cells[this._headerTable.DivCdColumn.ColumnName].Value.ToString() == PMUOE01202EA.DIVCD_NOCHANGE)
            {
                this.DetailEnableSetting(this, false);      // 使用不可
            }
            else
            {
                this.DetailEnableSetting(this, true);       // 使用可
            }
        }
        #endregion
    }
}

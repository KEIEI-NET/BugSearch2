//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫移動入力
// プログラム概要   : 在庫移動入力の入力フォームクラスです。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 作 成 日              修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 修 正 日  2008/02/01  修正内容 : DC.NS用に変更。
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30414 忍 幸史
// 修 正 日  2008/07/14  修正内容 : Partsman用に変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 修 正 日  2009/07/30  修正内容 : MANTIS対応[13892]：入庫伝票の日付表示が不正
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/05/22  修正内容 : 06/27配信分、Redmine#29881 在庫移動入力抽出条件に日付を指定しても反映されないの対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 明細グリッドコントロール
    /// </summary>
    public partial class MAZAI04120UE : UserControl
    {
        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin;

        /// <summary>在庫移動初期情報</summary>
        private StockMoveInputInitDataAcs _stockMoveInputInitAcs;
        /// <summary>在庫移動アクセス情報</summary>
        private StockMoveInputAcs _stockMoveInputAcs;
        /// <summary>ヘッダ情報</summary>
        private StockMoveHeader _stockMoveHeader;
        /// <summary>検索条件情報</summary>
        private StockMoveSlipSearchCond _stockMoveSlipSearchCond;
        // グリッド列表示非表示設定
        private StockMoveDetailRowVisibleControl _stockMoveDetailRowVisibleControl;
        /// <summary>在庫移動データテーブル</summary>
        private StockMoveInputDataSet.StockMoveDataTable _stockMoveDataTable;

        /// <summary>グリッドDISABLEカラー</summary>
        private static readonly Color DISABLE_COLOR = Color.Gainsboro;
        /// <summary>グリッドDISABLEフォントカラー</summary>
        private static readonly Color DISABLE_FONT_COLOR = Color.Black;

        private ArrayList retStockMoveWorkList = null;

        // ガイドデータ適用デリゲート
        internal event SettingGuideDataEventHandler SettingGuideData;
        internal delegate void SettingGuideDataEventHandler(ArrayList retStockMoveWork);

        internal event SetFocusEventHandler SetFocus;
        internal delegate void SetFocusEventHandler();

        # region コンストラクタ

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public MAZAI04120UE()
        {
            InitializeComponent();

            // スキンインスタンスの生成
            _controlScreenSkin = new ControlScreenSkin();

            // 在庫移動関連初期データクラス
            _stockMoveInputInitAcs = StockMoveInputInitDataAcs.GetInstance();
            // 在庫移動アクセス情報
            _stockMoveInputAcs = StockMoveInputAcs.GetInstance();
            // グリッド列表示非表示設定
            _stockMoveDetailRowVisibleControl = new StockMoveDetailRowVisibleControl();
            // 在庫移動ヘッダデータ
            _stockMoveHeader = _stockMoveInputInitAcs.StockMoveHeader;
            // 検索条件情報
            _stockMoveSlipSearchCond = _stockMoveInputInitAcs.StockMoveSlipSearchCond;
            // 在庫移動テーブル
            _stockMoveDataTable = new StockMoveInputDataSet.StockMoveDataTable();

            // 在庫移動データテーブル列表示設定 クラスセッティング処理
            this.SettingStockMoveDetailRowVisibleControl();
        }

        # endregion

        public void GridEnterKeyDown()
        {
            this.timer1.Enabled = true;
        }

        public void EnterKeyDownNextGrid()
        {
            if (this.ultraGrid1.Rows.Count == 0)
            {
                return;
            }

            if (this.ultraGrid1.ActiveRow == null)
            {
                this.ultraGrid1.Rows[0].Activate();
                this.ultraGrid1.Rows[0].Selected = true;
            }
            else
            {
                this.ultraGrid1.ActiveRow.Selected = true;
            }
        }

        public void ShiftKeyDownNextGrid()
        {
            if (this.ultraGrid1.Rows.Count == 0)
            {
                return;
            }

            if (this.ultraGrid1.ActiveRow == null)
            {
                this.ultraGrid1.Rows[0].Activate();
                this.ultraGrid1.Rows[0].Selected = true;
            }
            else
            {
                this.ultraGrid1.ActiveRow.Selected = true;
            }
        }

        public void DownKeyDownNextGrid()
        {
            if (this.ultraGrid1.Rows.Count == 0)
            {
                return;
            }

            this.ultraGrid1.Rows[0].Activate();
            this.ultraGrid1.Rows[0].Selected = true;
        }

        # region Getterメソッド
        /// <summary>
        /// 在庫移動テーブル　プロパティ
        /// </summary>
        public StockMoveInputDataSet.StockMoveDataTable StockmoveDataTable
        {
            get { return _stockMoveDataTable; }
        }

        # endregion

        // ADD 2009/11/05 MANTIS対応[13892]：入庫伝票の日付表示が不正 ---------->>>>>
        /// <summary>
        /// 伝票区分に応じたグリッド列を設定します。
        /// </summary>
        /// <param name="slipDiv">伝票区分</param>
        public void SetGridColumnsBySlipDiv(int slipDiv)
        {
            UltraGridBand editBand = this.ultraGrid1.DisplayLayout.Bands[0];
            if (editBand == null) return;

            // 入庫伝票の場合、入荷日を表示し、出荷確定日を隠す
            if (SlipDiv.IsInSlip(slipDiv))
            {
                this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.ArrivalGoodsDayColumn.ColumnName].Hidden = false;
                this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.ShipmentFixDayColumn.ColumnName].Hidden = true;
            }
            // 出庫伝票の場合、出荷確定日を表示し、入荷日を隠す
            else
            {
                this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.ArrivalGoodsDayColumn.ColumnName].Hidden = true;
                this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.ShipmentFixDayColumn.ColumnName].Hidden = false;
            }
        }
        // ADD 2008/11/05 MANTIS対応[13892]：入庫伝票の日付表示が不正 ----------<<<<<

        # region フォームイベントハンドラ

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void MAZAI04120UE_Load(object sender, EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // グリッドに対してデータソースを割り当て
            this.ultraGrid1.DataSource = _stockMoveDataTable;

            // 初期化処理
            this.Clear();
        }

        # endregion

        # region グリッドイベント

        /// <summary>
        /// キーダウンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br></br>
        /// </remarks>
        private void ultraGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            if (ultraGrid1.ActiveRow == null) return;

            // グリッド内でエンターキーが押された場合
            if (e.KeyData == Keys.Enter)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow row = ultraGrid1.ActiveRow;

                // 選択されたレコードの移動伝票番号を取得
                int stockMoveSlipNo = _stockMoveDataTable[row.Index].StockMoveSlipNo;

                // 取得した移動伝票番号から再度データを抽出
                _stockMoveInputInitAcs.StockMoveSlipSearchCondClear();
                // 移動伝票番号のみを検索条件に指定する
                _stockMoveSlipSearchCond.StockMoveSlipNo = stockMoveSlipNo;

                // 検索処理

                // 移動伝票検索開始
                int status = _stockMoveInputAcs.SearchStockMove(ref retStockMoveWorkList);

                if (status == 0)
                {
                    // 取得した結果を親のグリッドに格納
                    this.SettingGuideData(retStockMoveWorkList);
                }
                // 該当データ無し
                else if (status == 9)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "該当データがありません。",
                        status,
                        MessageBoxButtons.OK);
                }
                // 検索失敗
                else
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "検索に失敗しました。",
                        status,
                        MessageBoxButtons.OK);
                }
            }
            else if (e.KeyData == Keys.Up)
            {
                if (this.ultraGrid1.ActiveRow.Index == 0)
                {
                    SetFocus();
                }
            }
        }

        /// <summary>
        /// マウスダブルクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraGrid1_DoubleClick(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // マウスが入った最後の要素を取得します。
            Infragistics.Win.UIElement lastElementEntered = targetGrid.DisplayLayout.UIElement.LastElementEntered;

            // チェーン内に RowUIElement があるかどうかを調べます。
            Infragistics.Win.UltraWinGrid.RowUIElement rowElement;
            if (lastElementEntered is Infragistics.Win.UltraWinGrid.RowUIElement)
                rowElement = (Infragistics.Win.UltraWinGrid.RowUIElement)lastElementEntered;
            else
            {
                rowElement = (Infragistics.Win.UltraWinGrid.RowUIElement)lastElementEntered.GetAncestor(typeof(Infragistics.Win.UltraWinGrid.RowUIElement));
            }

            if (rowElement != null)
            {
                this.timer1.Enabled = true;
            }
        }

        /// <summary>
        /// レイアウト初期化イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // グリッド列初期設定処理
            this.GridColInitialSetting();
        }

        # endregion

        # region プライベートメソッド

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        internal void Clear()
        {
            // 在庫移動明細DataTable行クリア処理
            _stockMoveDataTable.Rows.Clear();

            // 在庫移動詳細DataTable行クリア処理
            //_stockMoveExpDataTable.Rows.Clear();

            // グリッド列表示順位処理
            this.VisiblePositionSettings();
        }

        /// <summary>
        /// グリッド列表示順位設定
        /// </summary>
        private void VisiblePositionSettings()
        {
            int currentPosition = 0;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.SearchIndexNumberColumn.ColumnName].Header.VisiblePosition = 0;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.ShipmentFixDayColumn.ColumnName].Header.VisiblePosition = ++currentPosition;

            // ADD 2009/11/05 MANTIS対応[13892]：入庫伝票の日付表示が不正 ---------->>>>>
            // 入荷日（入庫伝票の場合に使用）
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.ArrivalGoodsDayColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            // ADD 2008/11/05 MANTIS対応[13892]：入庫伝票の日付表示が不正 ----------<<<<<

            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.AfSectionGuideNmColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.AfEnterWarehNameColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.StockMoveSlipNoColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.StockMoveRowNoColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.GoodsNoColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.GoodsNameColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.MovingSupliStockColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.MovingTrustStockColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.StockUnitPriceFlColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.MovingPriceColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.BfSectionGuideNmColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.BfEnterWarehNameColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.OutlineColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
        }

        /// <summary>
        /// 在庫移動データテーブル列表示設定
        /// </summary>
        private void SettingStockMoveDetailRowVisibleControl()
        {
            // №
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveDataTable.SearchIndexNumberColumn.ColumnName, StatusType.Default, 0, false);

            // 出荷確定日
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveDataTable.ShipmentFixDayColumn.ColumnName, StatusType.Default, 0, false);

            // ADD 2009/11/05 MANTIS対応[13892]：入庫伝票の日付表示が不正 ---------->>>>>
            // 入荷日（入庫伝票の場合に使用）
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveDataTable.ArrivalGoodsDayColumn.ColumnName, StatusType.Default, 0, false);
            // ADD 2008/11/05 MANTIS対応[13892]：入庫伝票の日付表示が不正 ----------<<<<<

            // 入庫拠点名
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveDataTable.AfSectionGuideNmColumn.ColumnName, StatusType.Default, 0, false);

            // 入庫倉庫名
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveDataTable.AfEnterWarehNameColumn.ColumnName, StatusType.Default, 0, false);

            // 移動伝票番号
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveDataTable.StockMoveSlipNoColumn.ColumnName, StatusType.Default, 0, false);

            // 移動在庫行番号
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveDataTable.StockMoveRowNoColumn.ColumnName, StatusType.Default, 0, false);

            // 商品コード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._stockMoveDetailRowVisibleControl.Add(this._stockMoveDataTable.GoodsCodeColumn.ColumnName, StatusType.Default, 0, false);
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveDataTable.GoodsNoColumn.ColumnName, StatusType.Default, 0, false);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 商品名
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveDataTable.GoodsNameColumn.ColumnName, StatusType.Default, 0, false);
            // --- ADD m.suzuki 2010/04/15 ---------->>>>>
            // 商品名カナ
            this._stockMoveDetailRowVisibleControl.Add( this._stockMoveDataTable.GoodsNameKanaColumn.ColumnName, StatusType.Default, 0, true );
            // --- ADD m.suzuki 2010/04/15 ----------<<<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 製造番号
            //this._stockMoveDetailRowVisibleControl.Add(this._stockMoveDataTable.ProductNumberColumn.ColumnName, StatusType.Default, 0, false);
            //// 電話番号1
            //this._stockMoveDetailRowVisibleControl.Add(this._stockMoveDataTable.StockTelNo1Column.ColumnName, StatusType.Default, 0, false);
            //// 電話番号2
            //this._stockMoveDetailRowVisibleControl.Add(this._stockMoveDataTable.StockTelNo2Column.ColumnName, StatusType.Default, 0, false);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 移動中仕入在庫数
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveDataTable.MovingSupliStockColumn.ColumnName, StatusType.Default, 0, false);

            // 移動中受託在庫数
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._stockMoveDetailRowVisibleControl.Add(this._stockMoveDataTable.MovingTrustStockColumn.ColumnName, StatusType.Default, 0, false);
            this._stockMoveDetailRowVisibleControl.Add( this._stockMoveDataTable.MovingTrustStockColumn.ColumnName, StatusType.Default, 0, true );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 単価
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveDataTable.StockUnitPriceFlColumn.ColumnName, StatusType.Default, 0, false);

            // 合計金額
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveDataTable.MovingPriceColumn.ColumnName, StatusType.Default, 0, false);

            // 出庫拠点名
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveDataTable.BfSectionGuideNmColumn.ColumnName, StatusType.Default, 0, false);

            // 出庫倉庫名
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveDataTable.BfEnterWarehNameColumn.ColumnName, StatusType.Default, 0, false);

            // 伝票摘要
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveDataTable.OutlineColumn.ColumnName, StatusType.Default, 0, false);
        }

        /// <summary>
        /// グリッド列初期設定処理
        /// </summary>
        /// <br>Update Note : 2012/05/22 wangf </br>
        /// <br>            : 10801804-00、06/27配信分、Redmine#29881 在庫移動入力抽出条件に日付を指定しても反映されないの対応</br>
        private void GridColInitialSetting()
        {
            UltraGridBand editBand = this.ultraGrid1.DisplayLayout.Bands[0];
            if (editBand == null) return;

            foreach (UltraGridColumn col in editBand.Columns)
            {
                // 全ての列をいったん非表示にする。
                col.Hidden = true;

                // 「No列」以外の全てのセルのDiabledColorを設定する。
                if (col.Key != _stockMoveDataTable.StockMoveRowNoColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
                }
            }

            // グリッド列表示非表示設定処理
            this.SettingGridColVisible(StatusType.Default, 0);

            // キャプション
            // 出荷確定日
            // 2009.07.07 Add >>>
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.ShipmentFixDayColumn.ColumnName].Header.Caption = "出荷日";　 // 出荷確定日
            /* ------------DEL START wangf 2012/05/22 FOR Redmine#29881--------->>>>
            if (this._stockMoveInputInitAcs.StockMoveFixCode == 1)
            {
                this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.ShipmentFixDayColumn.ColumnName].Header.Caption = "出荷日";　 // 出荷確定日
            }
            else
            {
                this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.ShipmentFixDayColumn.ColumnName].Header.Caption = "日付";　 // 出荷確定日
            }
            // 2009.07.07 Add <<<
            // ------------DEL END wangf 2012/05/22 FOR Redmine#29881---------<<<<<*/
            // ------------ADD START wangf 2012/05/22 FOR Redmine#29881--------->>>>
            // 既存ソースについて、出荷確定日、カラム「出荷確定日」の表示名は在庫移動区分に従って変えし、今回改修は「出荷日」を固定になります。
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.ShipmentFixDayColumn.ColumnName].Header.Caption = "出荷日";　 // 出荷確定日
            // ------------ADD END wangf 2012/05/22 FOR Redmine#29881---------<<<<<

            // ADD 2009/11/05 MANTIS対応[13892]：入庫伝票の日付表示が不正 ---------->>>>>
            // 入荷日（入庫伝票の場合に使用）
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.ArrivalGoodsDayColumn.ColumnName].Header.Caption = "日付";   // 入荷日 // DEL wangf 2012/05/22 FOR Redmine#29881
            // ADD 2008/11/05 MANTIS対応[13892]：入庫伝票の日付表示が不正 ----------<<<<<
            // ------------ADD START wangf 2012/05/22 FOR Redmine#29881--------->>>>
            // 在庫移動区分が「1：出荷確定あり」になると、既存ソースそのまま処理を行う、以外場合は「入荷日」が表示されています
            if (this._stockMoveInputInitAcs.StockMoveFixCode == 1)
            {
                this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.ArrivalGoodsDayColumn.ColumnName].Header.Caption = "日付";   // 入荷日
            }
            else
            {
                this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.ArrivalGoodsDayColumn.ColumnName].Header.Caption = "入荷日";   // 入荷日
            }
            // ------------ADD END wangf 2012/05/22 FOR Redmine#29881---------<<<<<

            // 表示幅設定
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.SearchIndexNumberColumn.ColumnName].Width = 35; // №
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.ShipmentFixDayColumn.ColumnName].Width = 100;　 // 出荷確定日

            // ADD 2009/11/05 MANTIS対応[13892]：入庫伝票の日付表示が不正 ---------->>>>>
            // 入荷日（入庫伝票の場合に使用）
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.ArrivalGoodsDayColumn.ColumnName].Width = 100;
            // ADD 2008/11/05 MANTIS対応[13892]：入庫伝票の日付表示が不正 ----------<<<<<

            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.AfSectionGuideNmColumn.ColumnName].Width = 140; // 入庫拠点ガイド名
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.AfEnterWarehNameColumn.ColumnName].Width = 140; // 入庫倉庫名
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.StockMoveSlipNoColumn.ColumnName].Width = 100;  // 移動伝票番号
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.StockMoveRowNoColumn.ColumnName].Width = 60;	   // 移動在庫行番号
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.GoodsCodeColumn.ColumnName].Width = 120;    	   // 商品コード
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.GoodsNoColumn.ColumnName].Width = 120;    	   // 商品コード
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.GoodsNameColumn.ColumnName].Width = 120;    	   // 商品名
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.ProductNumberColumn.ColumnName].Width = 120;    // 製造番号
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.StockTelNo1Column.ColumnName].Width = 120;      // 電話番号1
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.StockTelNo2Column.ColumnName].Width = 120;      // 電話番号2
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.MovingSupliStockColumn.ColumnName].Width = 120; // 移動中仕入在庫数
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.MovingTrustStockColumn.ColumnName].Width = 120; // 移動中受託在庫数
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.StockUnitPriceFlColumn.ColumnName].Width = 120;   // 単価
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.MovingPriceColumn.ColumnName].Width = 120;      // 合計金額
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.BfSectionGuideNmColumn.ColumnName].Width = 120; // 出庫拠点名
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.BfEnterWarehNameColumn.ColumnName].Width = 120; // 出庫倉庫名
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.OutlineColumn.ColumnName].Width = 120;    	   // 伝票摘要

            // 固定列設定
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.SearchIndexNumberColumn.ColumnName].Header.Fixed = true; // №
            // 固定列の解除許可設定(解除は行わせない。)
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.SearchIndexNumberColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;

            // CellAppearance設定
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.SearchIndexNumberColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right; // 在庫移動行番号(右寄せ)
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.StockMoveSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;   // 移動伝票番号(右寄せ)
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.MovingSupliStockColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;  // 移動中仕入在庫数(右寄せ)
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.MovingTrustStockColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;  // 移動中受託在庫数(右寄せ)
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.StockUnitPriceFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;    // 単価(右寄せ)
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.MovingPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;       // 合計金額(右寄せ)

            // ヘッダ設定
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.SearchIndexNumberColumn.ColumnName].CellAppearance.BackColor = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.BackColor;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.SearchIndexNumberColumn.ColumnName].CellAppearance.BackColorDisabled = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.BackColor;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.SearchIndexNumberColumn.ColumnName].CellAppearance.BackColor2 = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.BackColor2;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.SearchIndexNumberColumn.ColumnName].CellAppearance.BackColorDisabled2 = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.BackColor2;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.SearchIndexNumberColumn.ColumnName].CellAppearance.BackGradientStyle = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.SearchIndexNumberColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.SearchIndexNumberColumn.ColumnName].CellAppearance.ForeColor = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.ForeColor;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.SearchIndexNumberColumn.ColumnName].CellAppearance.ForeColorDisabled = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.ForeColor;

            // 入力許可設定
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.SearchIndexNumberColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled; // №
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.ShipmentFixDayColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;      // 出荷確定日
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.AfSectionGuideNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;    // 入庫拠点名
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.AfEnterWarehNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;    // 入庫倉庫名
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.StockMoveSlipNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;     // 移動伝票番号
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.StockMoveRowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;      // 移動在庫行番号
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.GoodsCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;           // 商品コード
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.GoodsNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;           // 商品コード
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.GoodsNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;           // 商品名
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.ProductNumberColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;       // 製造番号
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.StockTelNo1Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;         // 電話番号1
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.StockTelNo2Column.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;         // 電話番号2
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.MovingSupliStockColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;    // 移動中仕入在庫数
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.MovingTrustStockColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;    // 移動中受託在庫数
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.StockUnitPriceFlColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;      // 単価
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.MovingPriceColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;         // 合計金額
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.BfSectionGuideNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;    // 出庫拠点名
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.BfEnterWarehNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;    // 出庫倉庫名
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.OutlineColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;             // 伝票摘要

            // フォーマット設定
            string moneyFormat = "#,##0;-#,##0;''";
            string slipFormat = "000000000";
            string decimalFormat = "#,##0.00;-#,##0.00;''";
            //string codeFormat = "#0;-#0;''";

            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.StockMoveSlipNoColumn.ColumnName].Format = slipFormat; // 移動伝票番号
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.MovingSupliStockColumn.ColumnName].Format = decimalFormat; // 仕入在庫出荷数
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.MovingTrustStockColumn.ColumnName].Format = decimalFormat; // 受託在庫出荷数
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.StockUnitPriceFlColumn.ColumnName].Format = decimalFormat;   // 単価
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.MovingPriceColumn.ColumnName].Format = moneyFormat;      // 合計金額
        }

        /// <summary>
        /// グリッド列表示非表示設定処理
        /// </summary>
        /// <param name="statusType">ステータスタイププロパティ</param>
        /// <param name="value">値</param>
        private void SettingGridColVisible(StatusType statusType, int value)
        {
            // すべての列の表示非表示設定
            UltraGridBand editBand = this.ultraGrid1.DisplayLayout.Bands[0];
            if (editBand == null) return;

            // 指定行の全ての列に対して設定を行う。
            foreach (UltraGridColumn col in editBand.Columns)
            {
                bool hidden;
                if (this._stockMoveDetailRowVisibleControl.GetHidden(col.Key, statusType, value, out hidden) == 0)
                {
                    col.Hidden = hidden;
                }
            }
        }

        # endregion

        # region タイマーイベント

        /// <summary>
        /// タイマーイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br></br>
        /// </remarks>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.ultraGrid1.ActiveRow != null)
            {
                timer1.Enabled = false;

                // アクティブセルの取得
                UltraGridRow row = this.ultraGrid1.ActiveRow;

                // 選択されたレコードの移動伝票番号を取得
                int stockMoveSlipNo = _stockMoveDataTable[row.Index].StockMoveSlipNo;

                // 取得した移動伝票番号から再度データを抽出
                _stockMoveInputInitAcs.StockMoveSlipSearchCondClear();
                // 移動伝票番号を検索条件に指定する
                _stockMoveSlipSearchCond.StockMoveSlipNo = stockMoveSlipNo;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // 在庫移動／倉庫移動で同一伝票番号が存在しても処理できるよう、条件を追加
                _stockMoveSlipSearchCond.AfSectionCode = _stockMoveDataTable[row.Index].AfSectionCode;
                _stockMoveSlipSearchCond.BfSectionCode = _stockMoveDataTable[row.Index].BfSectionCode;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // 検索処理

                // 移動伝票検索開始
                int status = _stockMoveInputAcs.SearchStockMove(ref retStockMoveWorkList);

                if (status == 0)
                {
                    // 取得した結果を親のグリッドに格納
                    this.SettingGuideData(retStockMoveWorkList);

                    _stockMoveInputInitAcs.GuideSelected = true;
                }
                // 該当データ無し
                else if (status == 9)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "該当データがありません。",
                        status,
                        MessageBoxButtons.OK);
                }
                // 検索失敗
                else
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "検索に失敗しました。",
                        status,
                        MessageBoxButtons.OK);
                }
            }
            timer1.Enabled = false;
        }

        # endregion
    }
}

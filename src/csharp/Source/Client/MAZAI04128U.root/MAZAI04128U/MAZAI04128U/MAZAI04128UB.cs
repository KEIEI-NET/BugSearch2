using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    public partial class MAZAI04128UB : UserControl
    {
        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin;

        // 在庫移動関連初期データクラス
        private StockMoveInputInitDataAcs _stockMoveInputInitAcs;
        // 在庫移動関連アクセスクラス
        private StockMoveInputAcs _stockMoveInputAcs;
        // グリッド列表示非表示設定
        private StockMoveDetailRowVisibleControl _stockMoveDetailRowVisibleControl;
        // 在庫移動ヘッダデータ
        private StockMoveHeader _StockMoveHeader;
        // 在庫移動テーブル
        private StockMoveInputDataSet.StockMoveDataTable _stockMoveDataTable;
        // 在庫移動テーブルバックアップ
        private StockMoveInputDataSet.StockMoveDataTable _stockMoveDataTableBackup;

        // 選択時レコードカラー
        private readonly Color _selectedBackColor = Color.FromArgb(216, 235, 253);
        private readonly Color _selectedBackColor2 = Color.FromArgb(101, 144, 218);

        // 各定数
        private static readonly Color DISABLE_COLOR = Color.Gainsboro;
        private static readonly Color DISABLE_FONT_COLOR = Color.Black;
        private static readonly Color READONLY_COLOR = Color.WhiteSmoke;
        private static readonly Color ROWSTATUS_COPY_COLOR = Color.Pink;
        private static readonly Color ROWSTATUS_CUT_COLOR = Color.Gray;
        private static readonly Color REDUCTION_FONT_COLOR = Color.Green;
        private static readonly Color READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
        internal static readonly string ITEM_NAME_CUSTOMERCODE = "CustomerCode";

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MAZAI04128UB()
        {
            InitializeComponent();

            // スキンインスタンスの生成
            _controlScreenSkin = new ControlScreenSkin();

            // 在庫移動関連初期データクラス
            _stockMoveInputInitAcs = StockMoveInputInitDataAcs.GetInstance();

            // 在庫移動関連アクセスクラス
            _stockMoveInputAcs = StockMoveInputAcs.GetInstance();
            // グリッド列表示非表示設定
            _stockMoveDetailRowVisibleControl = new StockMoveDetailRowVisibleControl();
            // 在庫移動ヘッダデータ
            _StockMoveHeader = _stockMoveInputInitAcs.StockMoveHeader;
            // 在庫移動テーブル
            _stockMoveDataTable = _stockMoveInputAcs.StockMoveDataTable;
            // 在庫移動テーブルバックアップ
            _stockMoveDataTableBackup = _stockMoveInputAcs.StockMoveDataTableBackup;

            // 在庫移動明細データテーブル列表示設定 クラスセッティング処理
            this.SettingStockMoveDetailRowVisibleControl();
        }

        private void MAZAI04128UB_Load(object sender, EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // グリッドに対してデータソースを割り当て
            this.ultraGrid1.DataSource = _stockMoveInputAcs.StockMoveDataTable;

            // クリア処理
            this.Clear();

        }

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        internal void Clear()
        {
            // 在庫移動明細DataTable行クリア処理
            _stockMoveInputAcs.StockMoveDataTable.Rows.Clear();

            // 在庫移動詳細DataTable行クリア処理
            //_stockMoveInputAcs.StockMoveExpDataTable.Rows.Clear();

            // グリッド行初期設定処理(仕入ではユーザ設定クラスのAから取得している)
            //this._stockMoveInputAcs.StockMoveDetailRowInitialSetting(20);

            // グリッド列表示順位処理
            this.VisiblePositionSettings();

        }

        /// <summary>
        /// 移動伝票明細データテーブル列表示設定クラスセッティング処理
        /// </summary>
        private void SettingStockMoveDetailRowVisibleControl()
        {
            // №
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.SearchIndexNumberColumn.ColumnName, StatusType.Default, 0, false);

            // 確定フラグ
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.FixFlagColumn.ColumnName, StatusType.Default, 0, false);

            // 出荷予定日
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.ShipmentScdlDayColumn.ColumnName, StatusType.Default, 0, false);

            // 入荷日
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.ArrivalGoodsDayColumn.ColumnName, StatusType.Default, 0, false);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 移動先拠点名称
            this._stockMoveDetailRowVisibleControl.Add( this._stockMoveInputAcs.StockMoveDataTable.AfSectionGuideNmColumn.ColumnName, StatusType.Default, 0, false );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 移動先倉庫名
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.AfEnterWarehNameColumn.ColumnName, StatusType.Default, 0, false);

            // 移動伝票番号
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.StockMoveSlipNoColumn.ColumnName, StatusType.Default, 0, false);

            // 品番
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName, StatusType.Default, 0, false);

            // 商品名
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.GoodsNameColumn.ColumnName, StatusType.Default, 0, false);

            // メーカー
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.GoodsMakerCdColumn.ColumnName, StatusType.Default, 0, false);

            // 仕入在庫出荷数
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.MovingSupliStockColumn.ColumnName, StatusType.Default, 0, false);

            // 受託在庫出荷数
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.MovingTrustStockColumn.ColumnName, StatusType.Default, 0, false);
            this._stockMoveDetailRowVisibleControl.Add( this._stockMoveInputAcs.StockMoveDataTable.MovingTrustStockColumn.ColumnName, StatusType.Default, 0, true );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 製造番号
            //this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.ProductNumberColumn.ColumnName, StatusType.Default, 0, false);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }

        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // グリッド列初期設定処理
            this.GridColInitialSetting();
        }

        /// <summary>
        /// グリッド列初期設定処理
        /// </summary>
        private void GridColInitialSetting()
        {
            UltraGridBand editBand = this.ultraGrid1.DisplayLayout.Bands[0];
            StockMoveInputDataSet.StockMoveDataTable table = _stockMoveInputAcs.StockMoveDataTable;

            if (editBand == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // 全ての列をいったん非表示にする。
                col.Hidden = true;

                // 「No列」以外の全てのセルのDiabledColorを設定する。
                if (col.Key != _stockMoveInputAcs.StockMoveDataTable.StockMoveRowNoColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
                }
            }

            // グリッド列表示非表示設定処理
            this.SettingGridColVisible(StatusType.Default, 0);

            // 表示幅設定
            editBand.Columns[table.SearchIndexNumberColumn.ColumnName].Width = 44;		// №
            editBand.Columns[table.FixFlagColumn.ColumnName].Width = 44;			    // 確定フラグ
            editBand.Columns[table.ShipmentScdlDayColumn.ColumnName].Width = 100;		// 出荷予定日
            editBand.Columns[table.ArrivalGoodsDayColumn.ColumnName].Width = 100;		// 入荷日
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            editBand.Columns[table.AfSectionGuideNmColumn.ColumnName].Width = 140;		// 移動先拠点名
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            editBand.Columns[table.AfEnterWarehNameColumn.ColumnName].Width = 140;		// 移動先倉庫名
            editBand.Columns[table.StockMoveSlipNoColumn.ColumnName].Width = 100;		// 移動伝票番号
            editBand.Columns[table.GoodsNoColumn.ColumnName].Width = 120;    		    // 品番
            editBand.Columns[table.GoodsNameColumn.ColumnName].Width = 120;    		    // 商品名
            editBand.Columns[table.GoodsMakerCdColumn.ColumnName].Width = 80;    		// メーカー
            editBand.Columns[table.MovingSupliStockColumn.ColumnName].Width = 120;    	// 仕入在庫出荷数
            editBand.Columns[table.MovingTrustStockColumn.ColumnName].Width = 120;    	// 受託在庫出荷数
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //editBand.Columns[table.ProductNumberColumn.ColumnName].Width = 120;    		// 製造番号
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 固定列設定
            editBand.Columns[table.SearchIndexNumberColumn.ColumnName].Header.Fixed = true;	// №
            editBand.Columns[table.FixFlagColumn.ColumnName].Header.Fixed = true;			// 確定フラグ
            editBand.Columns[table.ShipmentScdlDayColumn.ColumnName].Header.Fixed = true;	// 出荷予定日
            editBand.Columns[table.ArrivalGoodsDayColumn.ColumnName].Header.Fixed = true;	// 入荷日
            // 固定列の解除許可設定(解除は行わせない。)
            editBand.Columns[table.SearchIndexNumberColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            editBand.Columns[table.FixFlagColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            editBand.Columns[table.ShipmentScdlDayColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            editBand.Columns[table.ArrivalGoodsDayColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;

            // CellAppearance設定
            editBand.Columns[table.SearchIndexNumberColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;   // 在庫移動行番号(右寄せ)
            editBand.Columns[table.StockMoveSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;  // 伝票番号(右寄せ)
            editBand.Columns[table.MovingSupliStockColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right; // 移動中仕入在庫数(右寄せ)
            editBand.Columns[table.MovingTrustStockColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right; // 移動中受託在庫数(右寄せ)

            /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
            editBand.Columns[table.GoodsGuideButtonColumn.ColumnName].CellAppearance.Cursor = Cursors.Hand;
               --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.GoodsNameColumn.ColumnName].CellAppearance.BackColor = READONLY_COLOR;				// 商品名
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.WarehouseNameColumn.ColumnName].CellAppearance.BackColor = READONLY_COLOR;			// 倉庫名称
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName].CellAppearance.BackColor = READONLY_COLOR;		// 仕入金額
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockPriceConsTaxColumn.ColumnName].CellAppearance.BackColor = READONLY_COLOR;		// 消費税

            // 仮処理
            //this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor = Color.Silver;
            //this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.DimGray;
            //this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
            //this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            // 仮処理ここまで

            editBand.Columns[table.SearchIndexNumberColumn.ColumnName].CellAppearance.BackColor = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.BackColor;
            editBand.Columns[table.SearchIndexNumberColumn.ColumnName].CellAppearance.BackColorDisabled = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.BackColor;
            editBand.Columns[table.SearchIndexNumberColumn.ColumnName].CellAppearance.BackColor2 = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.BackColor2;
            editBand.Columns[table.SearchIndexNumberColumn.ColumnName].CellAppearance.BackColorDisabled2 = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.BackColor2;
            editBand.Columns[table.SearchIndexNumberColumn.ColumnName].CellAppearance.BackGradientStyle = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            editBand.Columns[table.SearchIndexNumberColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            editBand.Columns[table.SearchIndexNumberColumn.ColumnName].CellAppearance.ForeColor = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.ForeColor;
            editBand.Columns[table.SearchIndexNumberColumn.ColumnName].CellAppearance.ForeColorDisabled = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.ForeColor;

            // 入力許可設定
            editBand.Columns[table.SearchIndexNumberColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;	// No
            editBand.Columns[table.FixFlagColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;		        // 確定フラグ
            editBand.Columns[table.ShipmentScdlDayColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;	    // 出荷予定日
            editBand.Columns[table.ArrivalGoodsDayColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;	    // 入荷日
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            editBand.Columns[table.AfSectionGuideNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;	    // 移動先拠点名
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            editBand.Columns[table.AfEnterWarehNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;	    // 移動先倉庫名
            editBand.Columns[table.StockMoveSlipNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;	    // 伝票番号
            editBand.Columns[table.GoodsNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;		        // 品番
            editBand.Columns[table.GoodsNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;		    // 商品名
            editBand.Columns[table.GoodsMakerCdColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;		    // メーカー
            editBand.Columns[table.MovingSupliStockColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;	    // 移動中仕入在庫数
            editBand.Columns[table.MovingTrustStockColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;	    // 移動中受託在庫数
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //editBand.Columns[table.ProductNumberColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;	    // 製造番号
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // フォーマット設定
            string slipFormat = "000000000";
            //string moneyFormat = "#,##0;-#,##0;''";
            string decimalFormat = "#,##0.00;-#,##0.00;''";
            //string codeFormat = "#0;-#0;''";
            
            editBand.Columns[table.StockMoveSlipNoColumn.ColumnName].Format = slipFormat; // 在庫移動伝票番号

            editBand.Columns[table.MovingSupliStockColumn.ColumnName].Format = decimalFormat; // 仕入在庫出荷数
            editBand.Columns[table.MovingTrustStockColumn.ColumnName].Format = decimalFormat; // 受託在庫出荷数

            // MaxLength設定
            editBand.Columns[table.MovingSupliStockColumn.ColumnName].MaxLength = 12;		// 仕入在庫出荷数
            editBand.Columns[table.MovingTrustStockColumn.ColumnName].MaxLength = 12;		// 受託在庫出荷数
        }

        /// <summary>
        /// グリッド列表示非表示設定処理
        /// </summary>
        /// <param name="statusType">ステータスタイププロパティ</param>
        /// <param name="value">値</param>
        private void SettingGridColVisible(StatusType statusType, int value)
        {
            // すべての列の表示非表示設定
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.ultraGrid1.DisplayLayout.Bands[0];
            if (editBand == null) return;

            // 指定行の全ての列に対して設定を行う。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                bool hidden;
                if (this._stockMoveDetailRowVisibleControl.GetHidden(col.Key, statusType, value, out hidden) == 0)
                {
                    col.Hidden = hidden;
                }
            }
        }

        /// <summary>
        /// グリッド描画設定
        /// </summary>
        /// <remarks>
        /// <br>グリッドのデータソースがセットされた後必ずこの処理を実施します。</br>
        /// </remarks>
        public void SettingGridDraw()
        {
            // すべての行に対して表示内容の調整
            foreach ( Infragistics.Win.UltraWinGrid.UltraGridRow row in this.ultraGrid1.Rows )
            {
                // 未入荷なら入荷日付はスペース表示
                if ( (int)row.Cells[_stockMoveDataTable.MoveStatusColumn.ColumnName].Value <= 2 )
                {
                    row.Cells[_stockMoveDataTable.ArrivalGoodsDayColumn.ColumnName].Value = "";
                }
            }
        }

        /// <summary>
        /// グリッド列表示順位設定
        /// </summary>
        private void VisiblePositionSettings()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns["SearchIndexNumber"].Header.VisiblePosition = 1;
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns["FixFlag"].Header.VisiblePosition = 2;
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns["ShipmentScdlDay"].Header.VisiblePosition = 3;
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns["ArrivalGoodsDay"].Header.VisiblePosition = 4;
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns["AfEnterWarehName"].Header.VisiblePosition = 5;
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns["StockMoveSlipNo"].Header.VisiblePosition = 6;
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns["GoodsName"].Header.VisiblePosition = 7;
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns["MovingSupliStock"].Header.VisiblePosition = 8;
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns["MovingTrustStock"].Header.VisiblePosition = 9;
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns["ProductNumber"].Header.VisiblePosition = 10;


            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.ultraGrid1.DisplayLayout.Bands[0];
            StockMoveInputDataSet.StockMoveDataTable table = _stockMoveInputAcs.StockMoveDataTable;


            int currentPosition = 0;
            editBand.Columns[table.SearchIndexNumberColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            editBand.Columns[table.FixFlagColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            editBand.Columns[table.ShipmentScdlDayColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            editBand.Columns[table.ArrivalGoodsDayColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            editBand.Columns[table.AfSectionGuideNmColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            editBand.Columns[table.AfEnterWarehNameColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            editBand.Columns[table.StockMoveSlipNoColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            editBand.Columns[table.GoodsNoColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            editBand.Columns[table.GoodsNameColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            editBand.Columns[table.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            editBand.Columns[table.MovingSupliStockColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            editBand.Columns[table.MovingTrustStockColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }

        /// <summary>
        /// グリッドキーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void ultraGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            if (ultraGrid1.ActiveRow == null) return;

            // アクティブセルの取得
            Infragistics.Win.UltraWinGrid.UltraGridRow row = this.ultraGrid1.ActiveRow;

            // 選択レコードの確定フラグを取得
            Boolean fixFlag = _stockMoveDataTable[row.Index].FixFlag;

            if (e.KeyData == Keys.Space)
            {
                // 変更可能チェック
                // 既に入荷済みの場合はチェックを外せない。
                int moveStatus = (int)_stockMoveDataTable[row.Index].MoveStatus;
                if (moveStatus == 9)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "入荷済みのデータは更新できません。",
                        -1,
                        MessageBoxButtons.OK);

                    return;
                }

                // 選択されたレコードの確定フラグがOFFの場合、確定フラグをONにする。
                if (fixFlag == false)
                {
                    // 対象レコードの確定フラグをONにする。
                    _stockMoveDataTable[row.Index].FixFlag = true;

                    // 出荷担当者と出荷確定日を格納、移動状態を「2:移動中」に変更
                    _stockMoveDataTable[row.Index].ShipAgentCd = _StockMoveHeader.ShipAgentCd;
                    _stockMoveDataTable[row.Index].ShipAgentNm = _StockMoveHeader.ShipAgentNm;
                    _stockMoveDataTable[row.Index].MoveStatus = 2;
                    _stockMoveDataTable[row.Index].ShipmentFixDay = DateTime.Now.ToString("yyyy/MM/dd");

                    // 更新拠点コードも更新する。
                    _stockMoveDataTable[row.Index].UpdateSecCd = LoginInfoAcquisition.Employee.BelongSectionCode;

                    // 選択色に変更する。
                    row.Appearance.BackColor = _selectedBackColor;
                    row.Appearance.BackColor2 = _selectedBackColor2;
                    row.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                }

                // 選択されたレコードの確定フラグがONの場合、確定フラグをOFFにする。
                if (fixFlag == true)
                {
                    // 対象レコードの確定フラグをOFFにする。
                    _stockMoveDataTable[row.Index].FixFlag = false;

                    // 出荷担当者と出荷確定日を空に、移動状態を「1:未出荷状態」にする。
                    _stockMoveDataTable[row.Index].ShipAgentCd = "";
                    _stockMoveDataTable[row.Index].ShipAgentNm = "";
                    _stockMoveDataTable[row.Index].MoveStatus = 1;
                    _stockMoveDataTable[row.Index].ShipmentFixDay = "";

                    // 更新拠点コードを戻す。
                    _stockMoveDataTable[row.Index].UpdateSecCd = _stockMoveDataTableBackup[row.Index].UpdateSecCd;

                    // 未選択色に変更する。
                    if (row.Index % 2 == 1)
                    {
                        row.Appearance.BackColor = Color.Lavender;
                    }
                    else
                    {
                        row.Appearance.BackColor = Color.White;
                    }
                    row.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
                }
            }
        }

        /// <summary>
        /// グリッドマウスクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void ultraGrid1_MouseClick(object sender, MouseEventArgs e)
        {
            System.Drawing.Point nowPos = new Point(e.X, e.Y);
            Infragistics.Win.UIElement objElement = this.ultraGrid1.DisplayLayout.UIElement.ElementFromPoint(nowPos);

            if (objElement != null)
            {
                if (objElement.SelectableItem is Infragistics.Win.UltraWinGrid.UltraGridRow)
                {
                    this.timer1.Enabled = true;
                }
            }
        }

        /// <summary>
        /// 在庫移動グリッド情報取得タイマー起動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.ultraGrid1.ActiveRow != null)
            {
                // アクティブセルの取得
                Infragistics.Win.UltraWinGrid.UltraGridRow row = this.ultraGrid1.ActiveRow;

                // 変更可能チェック
                // 既に入荷済みの場合はチェックを外せない。
                int moveStatus = (int)_stockMoveDataTable[row.Index].MoveStatus;
                if (moveStatus == 9)
                {
                    timer1.Enabled = false;

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "入荷済みのデータは更新できません。",
                        -1,
                        MessageBoxButtons.OK);

                    return;
                }

                // 選択レコードの確定フラグを取得
                Boolean fixFlag = (Boolean)_stockMoveDataTable[row.Index].FixFlag;

                // 選択されたレコードの確定フラグがOFFの場合、確定フラグをONにする。
                if (fixFlag == false)
                {
                    // 対象レコードの確定フラグをONにする。
                    _stockMoveDataTable[row.Index].FixFlag = true;

                    // 出荷担当者と出荷確定日を格納、移動状態を「2:移動中」にする。
                    _stockMoveDataTable[row.Index].ShipAgentCd = _StockMoveHeader.ShipAgentCd;
                    _stockMoveDataTable[row.Index].ShipAgentNm = _StockMoveHeader.ShipAgentNm;
                    _stockMoveDataTable[row.Index].MoveStatus = 2;
                    _stockMoveDataTable[row.Index].ShipmentFixDay = DateTime.Now.ToString("yyyy/MM/dd");

                    // 更新拠点コードも更新する。
                    _stockMoveDataTable[row.Index].UpdateSecCd = LoginInfoAcquisition.Employee.BelongSectionCode;

                    // 選択色に変更する。
                    row.Appearance.BackColor = _selectedBackColor;
                    row.Appearance.BackColor2 = _selectedBackColor2;
                    row.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                }

                // 選択されたレコードの確定フラグがONの場合、確定フラグをOFFにする。
                if (fixFlag == true)
                {
                    // 対象レコードの確定フラグをOFFにする。
                    _stockMoveDataTable[row.Index].FixFlag = false;

                    // 出荷担当者と出荷確定日を空に、移動状態を「1:未出荷状態」にする。
                    _stockMoveDataTable[row.Index].ShipAgentCd = "";
                    _stockMoveDataTable[row.Index].ShipAgentNm = "";
                    _stockMoveDataTable[row.Index].MoveStatus = 1;
                    _stockMoveDataTable[row.Index].ShipmentFixDay = "";
                    
                    // 更新拠点コードを戻す。
                    _stockMoveDataTable[row.Index].UpdateSecCd = _stockMoveDataTableBackup[row.Index].UpdateSecCd;

                    // 未選択色に変更する。
                    if (row.Index % 2 == 1)
                    {
                        row.Appearance.BackColor = Color.Lavender;
                    }
                    else
                    {
                        row.Appearance.BackColor = Color.White;
                    }
                    row.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
                }
            }
            timer1.Enabled = false;
        }
    }
}

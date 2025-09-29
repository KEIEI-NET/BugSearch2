//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫移動入力
// プログラム概要   : 在庫移動入力の出荷処理を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 修 正 日  2010/02/19  修正内容 : MANTIS対応[15007]：グリッドに[入荷時刻]列を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 修 正 日  2011/04/11  修正内容 : 明細に仕入先を追加する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : tianjw
// 修 正 日  2011/05/10  修正内容 : redmine #20901
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhujc
// 修 正 日  2011/05/16  修正内容 : redmine #20901明細の入荷日を連動の条件変更する
//----------------------------------------------------------------------------//
using System;
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
using Infragistics.Win;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
    public partial class MAZAI04129UB : UserControl
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

        private bool _allCheckFlg;

        // 各定数
        private static readonly Color DISABLE_COLOR = Color.Gainsboro;
        private static readonly Color DISABLE_FONT_COLOR = Color.Black;
        private static readonly Color READONLY_COLOR = Color.WhiteSmoke;
        private static readonly Color ROWSTATUS_COPY_COLOR = Color.Pink;
        private static readonly Color ROWSTATUS_CUT_COLOR = Color.Gray;
        private static readonly Color REDUCTION_FONT_COLOR = Color.Green;
        private static readonly Color READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
        internal static readonly string ITEM_NAME_CUSTOMERCODE = "CustomerCode";

        // ヘッダ情報取得イベント
        public event EventHandler GetHeaderInfo;

        public bool AllCheckFlg
        {
            set
            {
                _allCheckFlg = value;
            }
        }

        public bool CheckGridBeforeNewProc()
        {
            if (this.ultraGrid1.Rows.Count > 0)
            {
                return (false);
            }

            return (true);
        }

        public MAZAI04129UB()
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

        private void MAZAI04129UB_Load(object sender, EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // グリッドに対してデータソースを割り当て
            this.ultraGrid1.DataSource = _stockMoveInputAcs.StockMoveDataTable;
            //SettingGridDraw();

            // クリア処理
            this.Clear();
        }

        public void AllArrival()
        {
            if (this.ultraGrid1.Rows.Count == 0)
            {
                return;
            }

            for (int index = 0; index < this.ultraGrid1.Rows.Count; index++)
            {
                // 入荷済みのものは更新できない
                Boolean arrivalFlagBackup = (Boolean)_stockMoveDataTableBackup[index].ArrivalFlag;
                if (arrivalFlagBackup == true)
                {
                    continue;
                }

                if (_allCheckFlg)
                {
                    // 対象レコードの入荷フラグをONにする。
                    _stockMoveDataTable[index].ArrivalFlag = true;

                    // 入荷担当者と入荷を格納、移動状態を「9:入荷済」にする。
                    _stockMoveDataTable[index].ReceiveAgentCd = _StockMoveHeader.ReceiveAgentCd;
                    _stockMoveDataTable[index].ReceiveAgentNm = _StockMoveHeader.ReceiveAgentNm;
                    _stockMoveDataTable[index].MoveStatus = 9;
                    _stockMoveDataTable[index].ArrivalGoodsDay = _StockMoveHeader.ArrivalGoodsDay.ToString("yyyy/MM/dd");

                    // 更新拠点コードも更新する。
                    _stockMoveDataTable[index].UpdateSecCd = LoginInfoAcquisition.Employee.BelongSectionCode;

                    // 選択色に変更する。
                    this.ultraGrid1.Rows[index].Appearance.BackColor = _selectedBackColor;
                    this.ultraGrid1.Rows[index].Appearance.BackColor2 = _selectedBackColor2;
                    this.ultraGrid1.Rows[index].Appearance.BackGradientStyle = GradientStyle.Vertical;
                }
                else
                {
                    // 対象レコードの入荷フラグをOFFにする。
                    _stockMoveDataTable[index].ArrivalFlag = false;

                    // 入荷担当者と入荷日を空に、移動状態を「2:移動中」にする。
                    _stockMoveDataTable[index].ReceiveAgentCd = "";
                    _stockMoveDataTable[index].ReceiveAgentNm = "";
                    _stockMoveDataTable[index].MoveStatus = 2;
                    _stockMoveDataTable[index].ArrivalGoodsDay = "";

                    // 更新拠点コードを戻す。
                    _stockMoveDataTable[index].UpdateSecCd = _stockMoveDataTableBackup[index].UpdateSecCd;

                    // 未選択色に変更する。
                    if (this.ultraGrid1.Rows[index].Index % 2 == 1)
                    {
                        this.ultraGrid1.Rows[index].Appearance.BackColor = Color.Lavender;
                    }
                    else
                    {
                        this.ultraGrid1.Rows[index].Appearance.BackColor = Color.White;
                    }
                    this.ultraGrid1.Rows[index].Appearance.BackGradientStyle = GradientStyle.Default;
                }
            }

            if (_allCheckFlg)
            {
                _allCheckFlg = false;
            }
            else
            {
                _allCheckFlg = true;
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
            foreach (UltraGridRow row in this.ultraGrid1.Rows )
            {
                // 未入荷なら入荷日付はスペース表示
                if ( (int)row.Cells[_stockMoveDataTable.MoveStatusColumn.ColumnName].Value <= 2 )
                {
                    row.Cells[_stockMoveDataTable.ArrivalGoodsDayColumn.ColumnName].Value = "";
                }

                // --- ADD 2009/01/06 障害ID:9557対応------------------------------------------------------>>>>>
                // 出庫倉庫コード
                string bfWarehouseCode = (string)row.Cells[_stockMoveDataTable.BfEnterWarehCodeColumn.ColumnName].Value;
                // 入庫倉庫コード
                string afWarehouseCode = (string)row.Cells[_stockMoveDataTable.AfEnterWarehCodeColumn.ColumnName].Value;
                // メーカーコード
                int makerCode = 0;
                if ((row.Cells[_stockMoveDataTable.GoodsMakerCdColumn.ColumnName].Value != DBNull.Value) &&
                    ((string)row.Cells[_stockMoveDataTable.GoodsMakerCdColumn.ColumnName].Value != ""))
                {
                    makerCode = int.Parse((string)row.Cells[_stockMoveDataTable.GoodsMakerCdColumn.ColumnName].Value);
                }
                // FIXME:品番
                string goodsNo = (string)row.Cells[_stockMoveDataTable.GoodsNoColumn.ColumnName].Value;

                List<Stock> stockList;

                int status = this._stockMoveInputAcs.ReadGoods(makerCode, goodsNo, ConstantManagement.LogicalMode.GetData01, out stockList);
                if (status == 0)
                {
                    if (stockList != null)
                    {
                        foreach (Stock stock in stockList)
                        {
                            if ((stock.WarehouseCode.Trim() == bfWarehouseCode.Trim()) || (stock.WarehouseCode.Trim() == afWarehouseCode.Trim()))
                            {
                                // 出庫倉庫または入庫倉庫が削除・論理削除されていた場合
                                if (stock.LogicalDeleteCode != 0)
                                {
                                    row.Appearance.BackColor = Color.Pink;
                                    row.Cells[_stockMoveDataTable.ArrivalFlagColumn.ColumnName].Activation = Activation.Disabled;

                                    row.Cells[_stockMoveDataTable.ArrivalFlagColumn.ColumnName].Value = false;
                                }
                            }
                        }
                    }
                }
                // --- ADD 2009/01/06 障害ID:9557対応------------------------------------------------------<<<<<
            }

            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.MovingSupliStockColumn.ColumnName].Header.Caption = "入庫数";
        }

        /// <summary>
        /// 画面初期化処理
        /// </summary>
        internal void Clear()
        {
            // 在庫移動明細DataTable行クリア処理
            _stockMoveInputAcs.StockMoveDataTable.Rows.Clear();

            // グリッド行初期設定処理(仕入ではユーザ設定クラスのAから取得している)
            //this._stockMoveInputAcs.StockMoveDetailRowInitialSetting(20);

            // グリッド列表示順位処理
            this.VisiblePositionSettings();

        }

        /// <summary>
        /// 移動伝票明細データテーブル列表示設定クラスセッティング処理
        /// </summary>
        /// <br>Update Note: 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
        private void SettingStockMoveDetailRowVisibleControl()
        {
            // №
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.SearchIndexNumberColumn.ColumnName, StatusType.Default, 0, false);

            // 入荷フラグ
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.ArrivalFlagColumn.ColumnName, StatusType.Default, 0, false);

            // 出荷確定日
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.ShipmentFixDayColumn.ColumnName, StatusType.Default, 0, false);
            // ADD 2010/02/19 MANTIS対応[15007]：グリッドに[出荷時間]列を追加 ---------->>>>>
            // 出荷時間
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.ShipmentFixTimeColumn.ColumnName, StatusType.Default, 0, false);
            // ADD 2010/02/19 MANTIS対応[15007]：グリッドに[出荷時間]列を追加 ----------<<<<<

            // 入荷日
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.ArrivalGoodsDayColumn.ColumnName, StatusType.Default, 0, false);

            // 出庫拠点名
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.BfSectionGuideNmColumn.ColumnName, StatusType.Default, 0, false);

            // 出庫倉庫名
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.BfEnterWarehNameColumn.ColumnName, StatusType.Default, 0, false);

            // 入庫拠点名
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.AfSectionGuideNmColumn.ColumnName, StatusType.Default, 0, false);

            // 入庫倉庫名
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.AfEnterWarehNameColumn.ColumnName, StatusType.Default, 0, false);

            // 入庫棚番
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.AfShelfNoColumn.ColumnName, StatusType.Default, 0, false);

            // 伝票番号
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.StockMoveSlipNoColumn.ColumnName, StatusType.Default, 0, false);

            // 品番
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName, StatusType.Default, 0, false);

            // 商品名
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.GoodsNameColumn.ColumnName, StatusType.Default, 0, false);

            // メーカー
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.GoodsMakerCdColumn.ColumnName, StatusType.Default, 0, false);

            //---ADD 2011/04/11-------------------------->>>>>>
            // 仕入先
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.SupplierCdColumn.ColumnName, StatusType.Default, 0, false);
            //---ADD 2011/04/11--------------------------<<<<<<
            
            // 出荷数
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.MovingSupliStockColumn.ColumnName, StatusType.Default, 0, false);

            // 入庫前数
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.AfBeforeMoveCountColumn.ColumnName, StatusType.Default, 0, false);

            // 入庫後数
            this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.AfAfterMoveCountColumn.ColumnName, StatusType.Default, 0, false);

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 製造番号
            //this._stockMoveDetailRowVisibleControl.Add(this._stockMoveInputAcs.StockMoveDataTable.ProductNumberColumn.ColumnName, StatusType.Default, 0, false);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }

        private void ultraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            // グリッド列初期設定処理
            this.GridColInitialSetting();
        }

        /// <summary>
        /// グリッド列初期設定処理
        /// </summary>
        /// <br>Update Note: 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
        private void GridColInitialSetting()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.ultraGrid1.DisplayLayout.Bands[0];
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

            // キャプション
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.ShipmentFixDayColumn.ColumnName].Header.Caption = "出荷日";		// 出荷確定日

            // 表示幅設定
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.SearchIndexNumberColumn.ColumnName].Width = 44;	// №
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.ArrivalFlagColumn.ColumnName].Width = 44;			// 入荷フラグ
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.ShipmentFixDayColumn.ColumnName].Width = 120;		// 出荷確定日
            // ADD 2010/02/19 MANTIS対応[15007]：グリッドに[出荷時間]列を追加 ---------->>>>>
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.ShipmentFixTimeColumn.ColumnName].Width = 100;	// 出荷時間
            // ADD 2010/02/19 MANTIS対応[15007]：グリッドに[出荷時間]列を追加 ----------<<<<<
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.ArrivalGoodsDayColumn.ColumnName].Width = 120;		// 入荷日
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.BfSectionGuideNmColumn.ColumnName].Width = 140;	// 出庫拠点名
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.BfEnterWarehNameColumn.ColumnName].Width = 140;	// 出庫倉庫名
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.StockMoveSlipNoColumn.ColumnName].Width = 100;		// 移動伝票番号
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName].Width = 120;    		    // 品番
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.GoodsNameColumn.ColumnName].Width = 120;    		// 商品名
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.GoodsMakerCdColumn.ColumnName].Width = 80;    		// メーカー
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.SupplierCdColumn.ColumnName].Width = 80;    		// 仕入先 // ADD 2011/04/11
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.MovingSupliStockColumn.ColumnName].Width = 120;    // 仕入在庫出荷数
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.AfBeforeMoveCountColumn.ColumnName].Width = 120;    // 受託在庫出荷数
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.AfAfterMoveCountColumn.ColumnName].Width = 120;    // 受託在庫出荷数
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.ProductNumberColumn.ColumnName].Width = 120;    	// 製造番号
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 固定列設定
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.SearchIndexNumberColumn.ColumnName].Header.Fixed = true;	// №
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.ArrivalFlagColumn.ColumnName].Header.Fixed = true;		// 入荷フラグ
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.ShipmentFixDayColumn.ColumnName].Header.Fixed = true;	// 出荷確定日
            // ADD 2010/02/19 MANTIS対応[15007]：グリッドに[出荷時間]列を追加 ---------->>>>>
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.ShipmentFixTimeColumn.ColumnName].Header.Fixed = true; // 出荷時間
            // ADD 2010/02/19 MANTIS対応[15007]：グリッドに[出荷時間]列を追加 ----------<<<<<
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.ArrivalGoodsDayColumn.ColumnName].Header.Fixed = true;	// 入荷日

            // 固定列の解除許可設定(解除は行わせない。)
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.SearchIndexNumberColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.ArrivalFlagColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.ShipmentFixDayColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            // ADD 2010/02/19 MANTIS対応[15007]：グリッドに[出荷時間]列を追加 ---------->>>>>
            // 出荷時間
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.ShipmentFixTimeColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            // ADD 2010/02/19 MANTIS対応[15007]：グリッドに[出荷時間]列を追加 ----------<<<<<
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.ArrivalGoodsDayColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;

            // CellAppearance設定
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.SearchIndexNumberColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;   // 在庫移動行番号(右寄せ)
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.StockMoveSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;  // 伝票番号(右寄せ)
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.MovingSupliStockColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right; // 移動中仕入在庫数(右寄せ)
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.AfBeforeMoveCountColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right; // 移動中受託在庫数(右寄せ)
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.AfAfterMoveCountColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right; // 移動中受託在庫数(右寄せ)

            /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.GoodsGuideButtonColumn.ColumnName].CellAppearance.Cursor = Cursors.Hand;
               --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.GoodsNameColumn.ColumnName].CellAppearance.BackColor = READONLY_COLOR;				// 商品名
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.WarehouseNameColumn.ColumnName].CellAppearance.BackColor = READONLY_COLOR;			// 倉庫名称
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockPriceDisplayColumn.ColumnName].CellAppearance.BackColor = READONLY_COLOR;		// 仕入金額
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.StockPriceConsTaxColumn.ColumnName].CellAppearance.BackColor = READONLY_COLOR;		// 消費税

            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.SearchIndexNumberColumn.ColumnName].CellAppearance.BackColor = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.BackColor;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.SearchIndexNumberColumn.ColumnName].CellAppearance.BackColorDisabled = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.BackColor;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.SearchIndexNumberColumn.ColumnName].CellAppearance.BackColor2 = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.BackColor2;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.SearchIndexNumberColumn.ColumnName].CellAppearance.BackColorDisabled2 = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.BackColor2;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.SearchIndexNumberColumn.ColumnName].CellAppearance.BackGradientStyle = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.SearchIndexNumberColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.SearchIndexNumberColumn.ColumnName].CellAppearance.ForeColor = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.ForeColor;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.SearchIndexNumberColumn.ColumnName].CellAppearance.ForeColorDisabled = this.ultraGrid1.DisplayLayout.Override.HeaderAppearance.ForeColor;

            // 入力許可設定
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.SearchIndexNumberColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;	// No
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.ArrivalFlagColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;		        // 入荷フラグ
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.ShipmentFixDayColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;	    // 出荷確定日
            // ADD 2010/02/19 MANTIS対応[15007]：グリッドに[出荷時間]列を追加 ---------->>>>>
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.ShipmentFixTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;    // 出荷時間
            // ADD 2010/02/19 MANTIS対応[15007]：グリッドに[出荷時間]列を追加 ----------<<<<<
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.ArrivalGoodsDayColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;	// 入荷日
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.BfEnterWarehNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;	    // 出庫拠点名
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.BfEnterWarehNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;	    // 出庫倉庫名
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.StockMoveSlipNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;	    // 伝票番号
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.GoodsNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;		        // 品番
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.GoodsNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;		        // 商品名
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.GoodsMakerCdColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;		    // メーカー
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.SupplierCdColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;		    // 仕入先 // ADD 2011/04/11
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.MovingSupliStockColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;	    // 移動中仕入在庫数
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.AfBeforeMoveCountColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;	    // 移動中受託在庫数
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.AfAfterMoveCountColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;	    // 移動中受託在庫数
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.ProductNumberColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;	    // 製造番号
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // フォーマット設定
            string slipFormat = "000000000";
            //string moneyFormat = "#,##0;-#,##0;''";
            string decimalFormat = "#,##0.00;-#,##0.00;''";
            //string codeFormat = "#0;-#0;''";
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.StockMoveSlipNoColumn.ColumnName].Format = slipFormat;  // 移動伝票番号

            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.MovingSupliStockColumn.ColumnName].Format = decimalFormat;  // 仕入在庫出荷数
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.AfBeforeMoveCountColumn.ColumnName].Format = "###,##0"; // 受託在庫出荷数
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.AfAfterMoveCountColumn.ColumnName].Format = "###,##0"; // 受託在庫出荷数

            // MaxLength設定
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.MovingSupliStockColumn.ColumnName].MaxLength = 12;		// 仕入在庫出荷数
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.AfBeforeMoveCountColumn.ColumnName].MaxLength = 12;		// 受託在庫出荷数
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveInputAcs.StockMoveDataTable.AfAfterMoveCountColumn.ColumnName].MaxLength = 12;		// 受託在庫出荷数
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
        /// グリッド列表示順位設定
        /// </summary>
        /// <br>Update Note: 2011/04/11 鄧潘ハン 明細に仕入先を追加する</br>
        private void VisiblePositionSettings()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns["SearchIndexNumber"].Header.VisiblePosition = 1;
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns["ArrivalFlag"].Header.VisiblePosition = 2;
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns["ShipmentFixDay"].Header.VisiblePosition = 3;
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns["ArrivalGoodsDay"].Header.VisiblePosition = 4;
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns["BfSectionGuideNm"].Header.VisiblePosition = 5;
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns["BfEnterWarehName"].Header.VisiblePosition = 6;
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns["StockMoveSlipNo"].Header.VisiblePosition = 7;
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns["GoodsName"].Header.VisiblePosition = 8;
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns["MovingSupliStock"].Header.VisiblePosition = 9;
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns["MovingTrustStock"].Header.VisiblePosition = 10;
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns["ProductNumber"].Header.VisiblePosition = 11;
            
            int currentPosition = 0;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.SearchIndexNumberColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.ArrivalFlagColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.ShipmentFixDayColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            // ADD 2010/02/19 MANTIS対応[15007]：グリッドに[出荷時間]列を追加 ---------->>>>>
            // 出荷時間
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.ShipmentFixTimeColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            // ADD 2010/02/19 MANTIS対応[15007]：グリッドに[出荷時間]列を追加 ----------<<<<<
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.ArrivalGoodsDayColumn.ColumnName].Header.VisiblePosition = ++currentPosition;

            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.StockMoveSlipNoColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.BfSectionGuideNmColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.BfEnterWarehNameColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.AfSectionGuideNmColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.AfEnterWarehNameColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.AfShelfNoColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.GoodsNoColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.GoodsNameColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.SupplierCdColumn.ColumnName].Header.VisiblePosition = ++currentPosition; // ADD 2011/04/11
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.MovingSupliStockColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.AfBeforeMoveCountColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
            this.ultraGrid1.DisplayLayout.Bands[0].Columns[_stockMoveDataTable.AfAfterMoveCountColumn.ColumnName].Header.VisiblePosition = ++currentPosition;
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

            //レコードがない場合は処理を行わない。
            if (_stockMoveDataTable == null || _stockMoveDataTable.Count == 0)
            {
                return;
            }

            // アクティブセルの取得
            UltraGridRow row = this.ultraGrid1.ActiveRow;

            // 選択レコードの入荷フラグを取得
            Boolean arrivalFlag = _stockMoveDataTable[row.Index].ArrivalFlag;

            // ヘッダ情報取得
            GetHeaderInfo( sender, new EventArgs() );

            if (e.KeyData == Keys.Space)
            {
                // --- ADD 2009/01/06 障害ID:9557対応------------------------------------------------------>>>>>
                // 出庫倉庫コード
                string bfWarehouseCode = (string)row.Cells[_stockMoveDataTable.BfEnterWarehCodeColumn.ColumnName].Value;
                // 入庫倉庫コード
                string afWarehouseCode = (string)row.Cells[_stockMoveDataTable.AfEnterWarehCodeColumn.ColumnName].Value;
                // メーカーコード
                int makerCode = 0;
                if ((row.Cells[_stockMoveDataTable.GoodsMakerCdColumn.ColumnName].Value != DBNull.Value) &&
                    ((string)row.Cells[_stockMoveDataTable.GoodsMakerCdColumn.ColumnName].Value != ""))
                {
                    makerCode = int.Parse((string)row.Cells[_stockMoveDataTable.GoodsMakerCdColumn.ColumnName].Value);
                }
                // 品番
                string goodsNo = (string)row.Cells[_stockMoveDataTable.GoodsNoColumn.ColumnName].Value;

                List<Stock> stockList;

                bool bfDeleteFlg = false;
                bool afDeleteFlg = false;
                string errMsg = "";

                int status = this._stockMoveInputAcs.ReadGoods(makerCode, goodsNo, ConstantManagement.LogicalMode.GetData01, out stockList);
                if (status == 0)
                {
                    if (stockList != null)
                    {
                        foreach (Stock stock in stockList)
                        {
                            // 出庫倉庫または入庫倉庫が削除・論理削除されていた場合
                            if ((stock.WarehouseCode.Trim() == bfWarehouseCode.Trim()) && (stock.LogicalDeleteCode != 0))
                            {
                                bfDeleteFlg = true;
                            }
                            if ((stock.WarehouseCode.Trim() == afWarehouseCode.Trim()) && (stock.LogicalDeleteCode != 0))
                            {
                                afDeleteFlg = true;
                            }
                        }
                    }
                }

                if ((bfDeleteFlg == true) && (afDeleteFlg == true))
                {
                    errMsg = "出庫倉庫と入庫倉庫が削除または論理削除されているため更新できません。";
                }
                else if (bfDeleteFlg == true)
                {
                    errMsg = "出庫倉庫が削除または論理削除されているため更新できません。";
                }
                else if (afDeleteFlg == true)
                {
                    errMsg = "入庫倉庫が削除または論理削除されているため更新できません。";
                }

                if (errMsg.Length > 0)
                {
                    TMsgDisp.Show(this,
                                  emErrorLevel.ERR_LEVEL_INFO,
                                  this.Name,
                                  errMsg,
                                  -1,
                                  MessageBoxButtons.OK);

                    return;
                }
                // --- ADD 2009/01/06 障害ID:9557対応------------------------------------------------------<<<<<

                // 選択されたレコードの入荷フラグがOFFの場合、入荷フラグをONにする。
                if (arrivalFlag == false)
                {
                    // 未出荷のデータは更新できない
                    Boolean fixFlagBackup = (Boolean)_stockMoveDataTableBackup[row.Index].FixFlag;

                    if (fixFlagBackup == false)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "未出荷のデータは更新できません。",
                            -1,
                            MessageBoxButtons.OK);
                    }
                    else
                    {
                        // 対象レコードの伝票番号を取得
                        int slipNo = _stockMoveDataTable[row.Index].StockMoveSlipNo;

                        for (int index = 0; index < _stockMoveDataTable.Rows.Count; index++)
                        {
                            if (_stockMoveDataTable[index].StockMoveSlipNo == slipNo)
                            {
                                // 対象レコードの入荷フラグをONにする。
                                _stockMoveDataTable[index].ArrivalFlag = true;

                                // 入荷担当者と入荷を格納、移動状態を「9:入荷済」にする。
                                _stockMoveDataTable[index].ReceiveAgentCd = _StockMoveHeader.ReceiveAgentCd;
                                _stockMoveDataTable[index].ReceiveAgentNm = _StockMoveHeader.ReceiveAgentNm;
                                _stockMoveDataTable[index].MoveStatus = 9;
                                //_stockMoveDataTable[index].ArrivalGoodsDay = _StockMoveHeader.ArrivalGoodsDay.ToString("yyyy/MM/dd"); //DEL 2011/05/16 zhujc
                                // ADD 2011/05/16 ---------->>>>>>
                                // 入荷済み伝票を再度チェックした場合は、元々の入荷日を表示する。
                                if (true == (Boolean)_stockMoveDataTableBackup[index].ArrivalFlag)
                                {
                                    _stockMoveDataTable[index].ArrivalGoodsDay = _stockMoveDataTableBackup[index].ArrivalGoodsDay;
                                }
                                // 未入荷伝票を再度チェックした場合は、画面のヘッダ部の入荷日を表示する。
                                else
                                {
                                    _stockMoveDataTable[index].ArrivalGoodsDay = _StockMoveHeader.ArrivalGoodsDay.ToString("yyyy/MM/dd");
                                }
                                // ADD 2011/05/16 ----------<<<<<<

                                // 更新拠点コードも更新する。
                                _stockMoveDataTable[index].UpdateSecCd = LoginInfoAcquisition.Employee.BelongSectionCode;

                                // 選択色に変更する。
                                this.ultraGrid1.Rows[index].Appearance.BackColor = _selectedBackColor;
                                this.ultraGrid1.Rows[index].Appearance.BackColor2 = _selectedBackColor2;
                                this.ultraGrid1.Rows[index].Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                            }
                        }
                    }
                }

                // 選択されたレコードの入荷フラグがONの場合、入荷フラグをOFFにする。
                if (arrivalFlag == true)
                {

                    // 入荷済みのものは更新できない
                    Boolean arrivalFlagBackup = (Boolean)_stockMoveDataTableBackup[row.Index].ArrivalFlag;

                    if (arrivalFlagBackup == true)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "入荷済みのデータは更新できません。",
                            -1,
                            MessageBoxButtons.OK);
                    }
                    else
                    {
                        // 対象レコードの伝票番号を取得
                        int slipNo = _stockMoveDataTable[row.Index].StockMoveSlipNo;

                        for (int index = 0; index < _stockMoveDataTable.Rows.Count; index++)
                        {
                            if (_stockMoveDataTable[index].StockMoveSlipNo == slipNo)
                            {
                                // 対象レコードの入荷フラグをOFFにする。
                                _stockMoveDataTable[index].ArrivalFlag = false;

                                // 入荷担当者と入荷日を空に、移動状態を「2:移動中」にする。
                                _stockMoveDataTable[index].ReceiveAgentCd = "";
                                _stockMoveDataTable[index].ReceiveAgentNm = "";
                                _stockMoveDataTable[index].MoveStatus = 2;
                                _stockMoveDataTable[index].ArrivalGoodsDay = "";

                                // 更新拠点コードを戻す。
                                _stockMoveDataTable[index].UpdateSecCd = _stockMoveDataTableBackup[index].UpdateSecCd;

                                // 未選択色に変更する。
                                if (index % 2 == 1)
                                {
                                    this.ultraGrid1.Rows[index].Appearance.BackColor = Color.Lavender;
                                }
                                else
                                {
                                    this.ultraGrid1.Rows[index].Appearance.BackColor = Color.White;
                                }
                                this.ultraGrid1.Rows[index].Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
                            }
                        }
                    }
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
            Point nowPos = new Point(e.X, e.Y);
            UIElement objElement = this.ultraGrid1.DisplayLayout.UIElement.ElementFromPoint(nowPos);

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
            timer1.Enabled = false;

            if (this.ultraGrid1.ActiveRow != null)
            {
                // アクティブセルの取得
                UltraGridRow row = this.ultraGrid1.ActiveRow;

                // --- ADD 2009/01/06 障害ID:9557対応------------------------------------------------------>>>>>
                // 出庫倉庫コード
                string bfWarehouseCode = (string)row.Cells[_stockMoveDataTable.BfEnterWarehCodeColumn.ColumnName].Value;
                // 入庫倉庫コード
                string afWarehouseCode = (string)row.Cells[_stockMoveDataTable.AfEnterWarehCodeColumn.ColumnName].Value;
                // メーカーコード
                int makerCode = 0;
                if ((row.Cells[_stockMoveDataTable.GoodsMakerCdColumn.ColumnName].Value != DBNull.Value) &&
                    ((string)row.Cells[_stockMoveDataTable.GoodsMakerCdColumn.ColumnName].Value != ""))
                {
                    makerCode = int.Parse((string)row.Cells[_stockMoveDataTable.GoodsMakerCdColumn.ColumnName].Value);
                }
                // 品番
                string goodsNo = (string)row.Cells[_stockMoveDataTable.GoodsNoColumn.ColumnName].Value;

                List<Stock> stockList;

                bool bfDeleteFlg = false;
                bool afDeleteFlg = false;
                string errMsg = "";

                int status = this._stockMoveInputAcs.ReadGoods(makerCode, goodsNo, ConstantManagement.LogicalMode.GetData01, out stockList);
                if (status == 0)
                {
                    if (stockList != null)
                    {
                        foreach (Stock stock in stockList)
                        {
                            // 出庫倉庫または入庫倉庫が削除・論理削除されていた場合
                            if ((stock.WarehouseCode.Trim() == bfWarehouseCode.Trim()) && (stock.LogicalDeleteCode != 0))
                            {
                                bfDeleteFlg = true;
                            }
                            if ((stock.WarehouseCode.Trim() == afWarehouseCode.Trim()) && (stock.LogicalDeleteCode != 0))
                            {
                                afDeleteFlg = true;
                            }
                        }
                    }
                }

                if ((bfDeleteFlg == true) && (afDeleteFlg == true))
                {
                    errMsg = "出庫倉庫と入庫倉庫が削除または論理削除されているため更新できません。";
                }
                else if (bfDeleteFlg == true)
                {
                    errMsg = "出庫倉庫が削除または論理削除されているため更新できません。";
                }
                else if (afDeleteFlg == true)
                {
                    errMsg = "入庫倉庫が削除または論理削除されているため更新できません。";
                }

                if (errMsg.Length > 0)
                {
                    TMsgDisp.Show(this,
                                  emErrorLevel.ERR_LEVEL_INFO,
                                  this.Name,
                                  errMsg,
                                  -1,
                                  MessageBoxButtons.OK);

                    return;
                }
                // --- ADD 2009/01/06 障害ID:9557対応------------------------------------------------------<<<<<

                // 選択レコードの入荷フラグを取得
                Boolean arrivalFlag = _stockMoveDataTable[row.Index].ArrivalFlag;

                // ヘッダ情報取得
                this.GetHeaderInfo( this, new EventArgs() );

                // 選択されたレコードの入荷フラグがOFFの場合、入荷フラグをONにする。
                if (arrivalFlag == false)
                {
                    // 未出荷のデータは更新できない
                    Boolean fixFlagBackup = (Boolean)_stockMoveDataTableBackup[row.Index].FixFlag;

                    // 対象レコードの伝票番号を取得
                    int slipNo = _stockMoveDataTable[row.Index].StockMoveSlipNo;

                    for (int index = 0; index < _stockMoveDataTable.Rows.Count; index++)
                    {
                        if (_stockMoveDataTable[index].StockMoveSlipNo == slipNo)
                        {
                            // 対象レコードの入荷フラグをONにする。
                            _stockMoveDataTable[index].ArrivalFlag = true;

                            // 入荷担当者と入荷を格納、移動状態を「9:入荷済」にする。
                            _stockMoveDataTable[index].ReceiveAgentCd = _StockMoveHeader.ReceiveAgentCd;
                            _stockMoveDataTable[index].ReceiveAgentNm = _StockMoveHeader.ReceiveAgentNm;
                            _stockMoveDataTable[index].MoveStatus = 9;
                            //_stockMoveDataTable[index].ArrivalGoodsDay = _StockMoveHeader.ArrivalGoodsDay.ToString("yyyy/MM/dd"); // DEL 2011/05/16 zhujc
                            // ADD 2011/05/16 ---------->>>>>>
                            // 入荷済み伝票を再度チェックした場合は、元々の入荷日を表示する。
                            if (true == (Boolean)_stockMoveDataTableBackup[index].ArrivalFlag)
                            {
                                _stockMoveDataTable[index].ArrivalGoodsDay = _stockMoveDataTableBackup[index].ArrivalGoodsDay;
                            }
                            // 未入荷伝票を再度チェックした場合は、画面のヘッダ部の入荷日を表示する。
                            else
                            {
                                _stockMoveDataTable[index].ArrivalGoodsDay = _StockMoveHeader.ArrivalGoodsDay.ToString("yyyy/MM/dd");
                            }
                            // ADD 2011/05/16 ----------<<<<<<
                            
                            // 更新拠点コードも更新する。
                            _stockMoveDataTable[index].UpdateSecCd = LoginInfoAcquisition.Employee.BelongSectionCode;

                            // 選択色に変更する。
                            this.ultraGrid1.Rows[index].Appearance.BackColor = _selectedBackColor;
                            this.ultraGrid1.Rows[index].Appearance.BackColor2 = _selectedBackColor2;
                            this.ultraGrid1.Rows[index].Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                        }
                    }
                }
                
                // 選択されたレコードの入荷フラグがONの場合、入荷フラグをOFFにする。
                if (arrivalFlag == true)
                {
                    // 入荷済みのものは更新できない
                    Boolean arrivalFlagBackup = (Boolean)_stockMoveDataTableBackup[row.Index].ArrivalFlag;

                    // 対象レコードの伝票番号を取得
                    int slipNo = _stockMoveDataTable[row.Index].StockMoveSlipNo;

                    for (int index = 0; index < _stockMoveDataTable.Rows.Count; index++)
                    {
                        if (_stockMoveDataTable[index].StockMoveSlipNo == slipNo)
                        {
                            // 対象レコードの入荷フラグをOFFにする。
                            _stockMoveDataTable[index].ArrivalFlag = false;

                            // 入荷担当者と入荷日を空に、移動状態を「2:移動中」にする。
                            _stockMoveDataTable[index].ReceiveAgentCd = "";
                            _stockMoveDataTable[index].ReceiveAgentNm = "";
                            _stockMoveDataTable[index].MoveStatus = 2;
                            _stockMoveDataTable[index].ArrivalGoodsDay = "";

                            // 更新拠点コードを戻す。
                            _stockMoveDataTable[index].UpdateSecCd = _stockMoveDataTableBackup[index].UpdateSecCd;

                            // 未選択色に変更する。
                            if (index % 2 == 1)
                            {
                                this.ultraGrid1.Rows[index].Appearance.BackColor = Color.Lavender;
                            }
                            else
                            {
                                this.ultraGrid1.Rows[index].Appearance.BackColor = Color.White;
                            }
                            this.ultraGrid1.Rows[index].Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
                        }
                    }
                }
            }
        }

        // ----- ADD 2011/05/10 tianjw ---------------------->>>>>
        /// <summary>
        /// 入荷日を変更した場合、明細の入荷日も連動して変更される様に修正
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入荷日を変更した場合、明細の入荷日も連動して変更される様に修正を行う。</br>
        /// <br>Programmer : tianjw</br>
        /// <br>Date       : 2011/05/10</br>
        /// </remarks>
        public void ArrivalGoodsDayChanged()
        {
            int no;
            if (this.ultraGrid1.ActiveRow != null)
            {
                no = this.ultraGrid1.ActiveRow.Index;
            }
            else
            {
                return;
            }

            if (this.ultraGrid1.Rows.All != null)
            {
                foreach (UltraGridRow row in this.ultraGrid1.Rows.All)
                {
                    // 選択レコードの入荷フラグを取得
                    Boolean arrivalFlag = _stockMoveDataTable[row.Index].ArrivalFlag;
                    // ヘッダ情報取得
                    this.GetHeaderInfo(this, new EventArgs());
                    // 選択されたレコードの入荷フラグがONの場合、入荷フラグをOFFにする。
                    // if (arrivalFlag == true) // DEL 2011/05/16 zhujc 
                    // 明細の入荷日を連動条件：①未入荷伝票②入荷にチェックが付いている
                    if (false == (Boolean)_stockMoveDataTableBackup[row.Index].ArrivalFlag && arrivalFlag == true) // ADD 2011/05/16 zhujc 
                    {
                        _stockMoveDataTable[row.Index].ArrivalGoodsDay = _StockMoveHeader.ArrivalGoodsDay.ToString("yyyy/MM/dd");
                        row.Activate();
                    }
                }
                this.ultraGrid1.Rows[no].Activate();
            }
        }
        // ----- ADD 2011/05/10 tianjw ----------------------<<<<<


    }
}

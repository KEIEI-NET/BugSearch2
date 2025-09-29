using System;
using System.Collections;
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

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 在庫仕入伝票照会 明細情報フォームクラス（明細毎）
    /// </summary>
    /// <remarks>
    /// Note       : 在庫仕入伝票の明細情報表示フォームクラスです。<br />
    /// Programmer : 22018 鈴木 正臣<br />
    /// Date       : 2008.09.02<br />
    /// <br />
    /// Update Note: 2009/02/16 30414 忍 幸史 障害ID:10825対応<br />
    /// </remarks>
	public partial class PMZAI04001UC : Form
    {
        # region [コンストラクタ]
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="stockAdjRefSearchRetWork"></param>
        public PMZAI04001UC(StockAdjRefSearchRetWork stockAdjRefSearchRetWork)
		{
			InitializeComponent();

            if (stockAdjRefSearchRetWork != null)
            {
                this._stockAdjRefSearchRetWork = stockAdjRefSearchRetWork;
            }
            this._searchMain = new PMZAI04001UA();
            this._searchSlipAcs = StockAdjRefAcs.GetInstance();
            this._dataSet = this._searchSlipAcs.DataSet;
			this.uGrid_ViewDetails.DataSource = this._dataSet.StockAdjustDtl;

            this._imageList16 = IconResourceManagement.ImageList16;
            this._returnButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_ViewDetail.Tools["ButtonTool_Return"];
            this._decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_ViewDetail.Tools["ButtonTool_Decision"];
        }
        # endregion

        # region [private フィールド]
        private PMZAI04001UA _searchMain;
        private StockAdjRefAcs _searchSlipAcs;
        private StockAdjDataSet _dataSet;
		private ImageList _imageList16 = null;									// イメージリスト
        private StockAdjRefSearchRetWork _stockAdjRefSearchRetWork;
        private string[] _supplierFormalStr = new string[3];                    // 仕入形式
        SortedList _supplierSlipCdStr = new SortedList();                       // 伝票形式
        private string[] _stockGoodsCdStr = new string[7];                      // 商品区分
        private string[] _accPayDivCdStr = new string[2];                       // 買掛区分

        private Infragistics.Win.UltraWinToolbars.ButtonTool _returnButton;		// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _decisionButton;	// 確定ボタン

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        # endregion

        # region [初期設定処理]

        /// <summary>
        /// ヘッダ部情報設定処理
        /// </summary>
        private void SetHeaderInfo()
        {

            this.uLabel_SectionCode.Text = _stockAdjRefSearchRetWork.SectionCode;
            this.uLabel_SectionName.Text = _stockAdjRefSearchRetWork.SectionGuideSnm;
            // --- DEL 2009/02/16 障害ID:10825対応------------------------------------------------------>>>>>
            //this.uLabel_WarehouseCd.Text = _stockAdjRefSearchRetWork.WarehouseCode;
            //this.uLabel_WarehouseName.Text = _stockAdjRefSearchRetWork.WarehouseName;
            // --- DEL 2009/02/16 障害ID:10825対応------------------------------------------------------<<<<<
            this.uLabel_AcPaySlipCdNm.Text = _searchSlipAcs.GetAcPaySlipCdName(_stockAdjRefSearchRetWork.AcPaySlipCd);
            this.uLabel_InputDay.Text = this.GetDateText( _stockAdjRefSearchRetWork.InputDay );
            this.uLabel_AdjustDate.Text = this.GetDateText( _stockAdjRefSearchRetWork.AdjustDate );
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2008/09/30 DEL
            //this.uLabel_StockAdjustSlipNo.Text = _stockAdjRefSearchRetWork.StockAdjustSlipNo.ToString();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2008/09/30 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2008/09/30 ADD
            this.uLabel_StockAdjustSlipNo.Text = this.GetSlipNoText( _stockAdjRefSearchRetWork.StockAdjustSlipNo );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2008/09/30 ADD
            this.uLabel_StockAgentCode.Text = _stockAdjRefSearchRetWork.StockAgentCode;
            this.uLabel_StockAgentName.Text = _stockAdjRefSearchRetWork.StockAgentName;

        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2008/09/30 ADD
        /// <summary>
        /// 伝票番号テキスト取得(ゼロ詰)
        /// </summary>
        /// <param name="slipNo"></param>
        /// <returns></returns>
        private string GetSlipNoText( int slipNo )
        {
            const string ct_SlipNoEditName = "tNedit_SupplierSlipNo";

            // ＵＩ共通設定XMLから桁数を取得する
            Broadleaf.Library.Windows.Forms.UiSet uiSet;
            if ( this.uiSetControl1.ReadUISet( out uiSet, ct_SlipNoEditName ) == 0 )
            {
                return slipNo.ToString( new string( '0', uiSet.Column ) );
            }
            else
            {
                return slipNo.ToString();
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2008/09/30 ADD

        /// <summary>
		/// グリッド列初期設定処理
		/// </summary>
		private void GridColInitialSetting()
		{
			string priceFormat = "#,##0;-#,##0;''";
			string floatFormat = "#,##0.00;-#,##0.00;''";

			// 固定列区切り線設定
			this.uGrid_ViewDetails.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_ViewDetails.DisplayLayout.Override.HeaderAppearance.BackColor2;

			// 入力許可設定
			for (int i = 0; i < this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns.Count; i++)
			{
				this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[i].AutoEdit = false;
				this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[i].Hidden = true;
			}


            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.uGrid_ViewDetails.DisplayLayout.Bands[0];
            int visiblePosition = 0;

            # region [カラム設定]

            // グリッド行番号
            band.Columns[this._dataSet.StockAdjustDtl.RowNoColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjustDtl.RowNoColumn.ColumnName].Header.Caption = "№";
            band.Columns[this._dataSet.StockAdjustDtl.RowNoColumn.ColumnName].Width = 30;
            band.Columns[this._dataSet.StockAdjustDtl.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjustDtl.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_ViewDetails.DisplayLayout.Override.HeaderAppearance.BackColor;
            band.Columns[this._dataSet.StockAdjustDtl.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_ViewDetails.DisplayLayout.Override.HeaderAppearance.BackColor2;
            band.Columns[this._dataSet.StockAdjustDtl.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_ViewDetails.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            band.Columns[this._dataSet.StockAdjustDtl.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            band.Columns[this._dataSet.StockAdjustDtl.RowNoColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._dataSet.StockAdjustDtl.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 商品番号
            band.Columns[this._dataSet.StockAdjustDtl.GoodsNoColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjustDtl.GoodsNoColumn.ColumnName].Header.Caption = "品番";
            band.Columns[this._dataSet.StockAdjustDtl.GoodsNoColumn.ColumnName].Width = 120;
            band.Columns[this._dataSet.StockAdjustDtl.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjustDtl.GoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 商品名称
            band.Columns[this._dataSet.StockAdjustDtl.GoodsNameColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjustDtl.GoodsNameColumn.ColumnName].Header.Caption = "品名";
            band.Columns[this._dataSet.StockAdjustDtl.GoodsNameColumn.ColumnName].Width = 120;
            band.Columns[this._dataSet.StockAdjustDtl.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjustDtl.GoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // メーカー名称
            band.Columns[this._dataSet.StockAdjustDtl.MakerNameColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjustDtl.MakerNameColumn.ColumnName].Header.Caption = "メーカー名";
            band.Columns[this._dataSet.StockAdjustDtl.MakerNameColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.StockAdjustDtl.MakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjustDtl.MakerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // BL商品コード
            band.Columns[this._dataSet.StockAdjustDtl.BLGoodsCodeColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjustDtl.BLGoodsCodeColumn.ColumnName].Header.Caption = "BLｺｰﾄﾞ";
            band.Columns[this._dataSet.StockAdjustDtl.BLGoodsCodeColumn.ColumnName].Width = 55;
            band.Columns[this._dataSet.StockAdjustDtl.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjustDtl.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // （定価（浮動））
            band.Columns[this._dataSet.StockAdjustDtl.ListPriceFlColumn.ColumnName].Hidden = true;
            band.Columns[this._dataSet.StockAdjustDtl.ListPriceFlColumn.ColumnName].Header.Caption = "";
            band.Columns[this._dataSet.StockAdjustDtl.ListPriceFlColumn.ColumnName].Width = 100;
            band.Columns[this._dataSet.StockAdjustDtl.ListPriceFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjustDtl.ListPriceFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.StockAdjustDtl.ListPriceFlColumn.ColumnName].Format = floatFormat;

            // （オープン価格区分）
            band.Columns[this._dataSet.StockAdjustDtl.OpenPriceDivColumn.ColumnName].Hidden = true;
            band.Columns[this._dataSet.StockAdjustDtl.OpenPriceDivColumn.ColumnName].Header.Caption = "";
            band.Columns[this._dataSet.StockAdjustDtl.OpenPriceDivColumn.ColumnName].Width = 100;
            band.Columns[this._dataSet.StockAdjustDtl.OpenPriceDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjustDtl.OpenPriceDivColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 定価（表示用）
            band.Columns[this._dataSet.StockAdjustDtl.ListPriceFlViewColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjustDtl.ListPriceFlViewColumn.ColumnName].Header.Caption = "標準価格";
            band.Columns[this._dataSet.StockAdjustDtl.ListPriceFlViewColumn.ColumnName].Width = 100;
            band.Columns[this._dataSet.StockAdjustDtl.ListPriceFlViewColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjustDtl.ListPriceFlViewColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 調整数
            band.Columns[this._dataSet.StockAdjustDtl.AdjustCountColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjustDtl.AdjustCountColumn.ColumnName].Header.Caption = "数量";
            band.Columns[this._dataSet.StockAdjustDtl.AdjustCountColumn.ColumnName].Width = 100;
            band.Columns[this._dataSet.StockAdjustDtl.AdjustCountColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjustDtl.AdjustCountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.StockAdjustDtl.AdjustCountColumn.ColumnName].Format = floatFormat;

            // 仕入単価（税抜,浮動）
            band.Columns[this._dataSet.StockAdjustDtl.StockUnitPriceFlColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjustDtl.StockUnitPriceFlColumn.ColumnName].Header.Caption = "原単価";
            band.Columns[this._dataSet.StockAdjustDtl.StockUnitPriceFlColumn.ColumnName].Width = 100;
            band.Columns[this._dataSet.StockAdjustDtl.StockUnitPriceFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjustDtl.StockUnitPriceFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.StockAdjustDtl.StockUnitPriceFlColumn.ColumnName].Format = floatFormat;

            // 仕入金額（税抜き）
            band.Columns[this._dataSet.StockAdjustDtl.StockPriceTaxExcColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjustDtl.StockPriceTaxExcColumn.ColumnName].Header.Caption = "仕入金額";
            band.Columns[this._dataSet.StockAdjustDtl.StockPriceTaxExcColumn.ColumnName].Width = 120;
            band.Columns[this._dataSet.StockAdjustDtl.StockPriceTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjustDtl.StockPriceTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.StockAdjustDtl.StockPriceTaxExcColumn.ColumnName].Format = priceFormat;

            // 明細備考
            band.Columns[this._dataSet.StockAdjustDtl.DtlNoteColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjustDtl.DtlNoteColumn.ColumnName].Header.Caption = "明細備考";
            band.Columns[this._dataSet.StockAdjustDtl.DtlNoteColumn.ColumnName].Width = 200;
            band.Columns[this._dataSet.StockAdjustDtl.DtlNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjustDtl.DtlNoteColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // --- ADD 2009/02/16 障害ID:10825対応------------------------------------------------------>>>>>
            // 倉庫コード
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseCodeColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseCodeColumn.ColumnName].Header.Caption = "倉庫コード";
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseCodeColumn.ColumnName].Width = 200;
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 倉庫名
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseNameColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseNameColumn.ColumnName].Header.Caption = "倉庫名";
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseNameColumn.ColumnName].Width = 200;
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- ADD 2009/02/16 障害ID:10825対応------------------------------------------------------<<<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2008/09/30 ADD
            // 棚番
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseShelfNoColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseShelfNoColumn.ColumnName].Header.Caption = "棚番";
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseShelfNoColumn.ColumnName].Width = 200;
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseShelfNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjustDtl.WarehouseShelfNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2008/09/30 ADD

            # endregion
        }

        /// <summary>
		/// グリッド行初期設定処理
		/// </summary>
		private void GridRowInitialSetting()
		{
			this._dataSet.StockAdjustDtl.Rows.Clear();
		}

		/// <summary>
		/// ボタン初期設定処理
		/// </summary>
		private void ButtonInitialSetting()
		{
            this.tToolbarsManager_ViewDetail.ImageListSmall = this._imageList16;
            this._returnButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            this._decisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
        }
        # endregion

        # region コントロールイベントメソッド

        /// <summary>
        /// グリッドエンターイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_Enter(object sender, EventArgs e)
        {
            if (this.uGrid_ViewDetails.Rows.Count != 0)
            {
                //this.uButton_StockSearch.Enabled = true;
            }

            timer_InitialSetSelect.Enabled = true;
        }

        /// <summary>
        /// グリッドフォーカス離脱時イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// グリッドキーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_ViewDetails.ActiveRow == null) return;

            // Enterキー
            if (e.KeyCode == Keys.Enter)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;
            }

            // 最上行での↑キー
            if (this.uGrid_ViewDetails.ActiveRow.Index == 0)
            {
                if (e.KeyCode == Keys.Up)
                {
                    // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                    e.Handled = true;
                    //this.uButton_StockSearch.Focus();
                }
            }

            // →矢印キー
            if (e.KeyCode == Keys.Right)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;
                // グリッド表示を右にスクロール
                this.uGrid_ViewDetails.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_ViewDetails.DisplayLayout.ColScrollRegions[0].Position + 40;
            }

            // ←矢印キー
            if (e.KeyCode == Keys.Left)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;
                if (this.uGrid_ViewDetails.DisplayLayout.ColScrollRegions[0].Position == 0)
                {
                    //this.uButton_StockSearch.Focus();
                }
                else
                {
                    // グリッド表示を左にスクロール
                    this.uGrid_ViewDetails.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_ViewDetails.DisplayLayout.ColScrollRegions[0].Position - 40;
                }
            }

            // Homeキー
            if (e.KeyCode == Keys.Home)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;

                // 他キーとの組合せ無しの場合
                if (e.Modifiers == Keys.None)
                {
                    // グリッド表示を左先頭にスクロール
                    this.uGrid_ViewDetails.DisplayLayout.ColScrollRegions[0].Position = 0;
                }

                // Controlキーとの組合せの場合
                if (e.Modifiers == Keys.Control)
                {
                    // グリッド表示を左先頭にスクロール
                    //this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = 0;
                    // 先頭行に移動
                    this.uGrid_ViewDetails.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid);
                }
            }

            // Endキー
            if (e.KeyCode == Keys.End)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;

                // 他キーとの組合せ無しの場合
                if (e.Modifiers == Keys.None)
                {
                    // グリッド表示を左先頭にスクロール
                    this.uGrid_ViewDetails.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_ViewDetails.DisplayLayout.ColScrollRegions[0].Range;
                }

                // Controlキーとの組合せの場合
                if (e.Modifiers == Keys.Control)
                {
                    // グリッド表示を右末尾にスクロール
                    //this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Range;
                    // 最終行に移動
                    this.uGrid_ViewDetails.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastRowInGrid);
                }
            }
        }

        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
        }
        /// <summary>
        /// ツールバーボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tToolbarsManager_ViewDetail_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Return":
                    {
                        // 終了処理
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                        break;
                    }
                case "ButtonTool_Decision":
                    {
                        // 確定処理
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                       
                        break;
                    }
            }
        }

        /// <summary>
        /// グリッド行選択設定タイマー起動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void timer_InitialSetSelect_Tick(object sender, EventArgs e)
        {
            if (this.uGrid_ViewDetails.ActiveRow != null)
            {
                this.uGrid_ViewDetails.ActiveRow.Selected = true;
            }
            timer_InitialSetSelect.Enabled = false;
        }


        /// <summary>
        /// フォームロードイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMZAI04001UC_Load( object sender, EventArgs e )
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin( this );

            // グリッド列初期設定処理
            this.GridColInitialSetting();

            // ボタン初期設定処理
            this.ButtonInitialSetting();

            // グリッド行初期設定処理
            this.GridRowInitialSetting();

            // ヘッダ部情報設定処理
            this.SetHeaderInfo();

            // 対象伝票の明細情報を取得
            this._searchSlipAcs.SetDetailData( this._stockAdjRefSearchRetWork.StockAdjustSlipNo );
        }
        # endregion

        # region [汎用処理]
        /// <summary>
        /// 日付文字列取得処理
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private string GetDateText( DateTime dateTime )
        {
            const string dateFormat = "yyyy年MM月dd日";

            if ( dateTime != DateTime.MinValue )
            {
                return dateTime.ToString( dateFormat );
            }
            else
            {
                return string.Empty;
            }
        }
        # endregion

    }
}

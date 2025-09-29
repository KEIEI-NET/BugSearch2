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

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 在庫仕入伝票照会明細グリッドコントロールクラス（伝票毎）
    /// </summary>
    /// <remarks>
    /// Note       : 在庫仕入伝票の一覧表示を行うグリッドを含むユーザーコントロールです。<br />
    /// Programmer : 22018 鈴木 正臣<br />
    /// Date       : 2008.09.02<br />
    /// <br />
    /// Update Note: 2009/04/03 照田 貴志　不具合対応[12857]<br />
    /// <br>         </br>
    /// </remarks>
	public partial class PMZAI04001UB : UserControl
	{
		#region ■Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
		public PMZAI04001UB()
		{
			InitializeComponent();

            this._searchSlipAcs = StockAdjRefAcs.GetInstance();
            this._dataSet = this._searchSlipAcs.DataSet;
            this.uGrid_Details.DataSource = this._dataSet.StockAdjust;
            this._imageList16 = IconResourceManagement.ImageList16;
            this._stockAdjRefSearchRetWork = new StockAdjRefSearchRetWork();
			this._stockAdjRefSearchParaWork = new StockAdjRefSearchParaWork();
		}
		#endregion

		#region ■Private Members
		private StockAdjRefAcs _searchSlipAcs;
		private StockAdjDataSet _dataSet;
		private ImageList _imageList16 = null;									// イメージリスト
		private int _startMovment = 0;											// 起動モード 0:エントリー 1:メニュー

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
		#endregion

		#region ■Public Members
		public StockAdjRefSearchRetWork _stockAdjRefSearchRetWork;
		public StockAdjRefSearchParaWork _stockAdjRefSearchParaWork = null;
		#endregion

		#region ■Delegate
		// デリゲート処理
        //internal event SettingRaedParaEventHandler ReadParaSetting;
        //internal delegate void SettingRaedParaEventHandler(out IOWriteMASIRReadWork retIOWriteMASIRReadWork);

        internal event SettingStatusBarMessageEventHandler StatusBarMessageSetting;
        internal delegate void SettingStatusBarMessageEventHandler(object sender, string message);

        internal event CloseMainEventHandler CloseMain;
        internal delegate void CloseMainEventHandler();

        internal event SetDialogResEventHandler SetMainDialogResult;
        internal delegate void SetDialogResEventHandler(DialogResult dialogRes);

        internal event SettingDecisionButtonEnableEventHandler DecisionButtonEnableSet;
        internal delegate void SettingDecisionButtonEnableEventHandler(bool enableSet);
		#endregion

		#region ■Properties
		/// <summary>
		/// 起動動作モード
		/// </summary>
		public int StartMovment
		{
			get { return this._startMovment; }
			set { this._startMovment = value; }
		}
		
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        ///// <summary>伝票種別プロパティ</summary>
        //public int SupplierFormal
        //{
        //    get { return this._stockAdjRefSearchParaWork.SupplierFormal; }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		#endregion

		#region ■Public Methods
		/// <summary>
		/// 画面モード設定
		/// </summary>
		public void DisplayModeSetting()
		{
			// グリッド列初期設定処理
			this.GridColInitialSetting();
		}
		#endregion

        # region [初期設定]
        /// <summary>
		/// グリッド列初期設定処理
		/// </summary>
		private void GridColInitialSetting()
		{
            const string moneyFormat = "#,##0;-#,##0;''";

			for (int i = 0; i < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
			{
				// 入力許可設定
				//this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].AutoEdit = false;

				// 表示非表示設定
				this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Hidden = true;
				this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
			}


            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.uGrid_Details.DisplayLayout.Bands[0];
            int visiblePosition = 0;

            # region [カラム設定]

            // №
            band.Columns[this._dataSet.StockAdjust.RowNoColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjust.RowNoColumn.ColumnName].Header.Caption = "№";
            band.Columns[this._dataSet.StockAdjust.RowNoColumn.ColumnName].Width = 30;
            band.Columns[this._dataSet.StockAdjust.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjust.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            band.Columns[this._dataSet.StockAdjust.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            band.Columns[this._dataSet.StockAdjust.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            band.Columns[this._dataSet.StockAdjust.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            band.Columns[this._dataSet.StockAdjust.RowNoColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._dataSet.StockAdjust.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // （企業コード）
            band.Columns[this._dataSet.StockAdjust.EnterpriseCodeColumn.ColumnName].Hidden = true;
            band.Columns[this._dataSet.StockAdjust.EnterpriseCodeColumn.ColumnName].Header.Caption = "企業コード";
            band.Columns[this._dataSet.StockAdjust.EnterpriseCodeColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.StockAdjust.EnterpriseCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjust.EnterpriseCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 調整日付
            band.Columns[this._dataSet.StockAdjust.AdjustDateColumn.ColumnName].Hidden = false;
            //band.Columns[this._dataSet.StockAdjust.AdjustDateColumn.ColumnName].Header.Caption = "作成日";            //DEL 2009/04/03 不具合対応[12857]
            //band.Columns[this._dataSet.StockAdjust.AdjustDateColumn.ColumnName].Width = 150;                          //DEL 2009/04/03 不具合対応[12857]
            band.Columns[this._dataSet.StockAdjust.AdjustDateColumn.ColumnName].Header.Caption = "仕入日";              //ADD 2009/04/03 不具合対応[12857]  
            band.Columns[this._dataSet.StockAdjust.AdjustDateColumn.ColumnName].Width = 100;                            //ADD 2009/04/03 不具合対応[12857]
            band.Columns[this._dataSet.StockAdjust.AdjustDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjust.AdjustDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 在庫調整伝票番号
            band.Columns[this._dataSet.StockAdjust.StockAdjustSlipNoColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjust.StockAdjustSlipNoColumn.ColumnName].Header.Caption = "伝票番号";
            band.Columns[this._dataSet.StockAdjust.StockAdjustSlipNoColumn.ColumnName].Width = 120;
            band.Columns[this._dataSet.StockAdjust.StockAdjustSlipNoColumn.ColumnName].Format = this.GetSlipNoFormat();
            band.Columns[this._dataSet.StockAdjust.StockAdjustSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjust.StockAdjustSlipNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // （受払元伝票区分コード）
            band.Columns[this._dataSet.StockAdjust.AcPaySlipCdColumn.ColumnName].Hidden = true;
            band.Columns[this._dataSet.StockAdjust.AcPaySlipCdColumn.ColumnName].Header.Caption = "伝票区分コード";
            band.Columns[this._dataSet.StockAdjust.AcPaySlipCdColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.StockAdjust.AcPaySlipCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjust.AcPaySlipCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 受払元伝票区分名称
            band.Columns[this._dataSet.StockAdjust.AcPaySlipCdNmColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjust.AcPaySlipCdNmColumn.ColumnName].Header.Caption = "伝票区分";
            band.Columns[this._dataSet.StockAdjust.AcPaySlipCdNmColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.StockAdjust.AcPaySlipCdNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjust.AcPaySlipCdNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // （受払元取引区分コード）
            band.Columns[this._dataSet.StockAdjust.AcPayTransCdColumn.ColumnName].Hidden = true;
            band.Columns[this._dataSet.StockAdjust.AcPayTransCdColumn.ColumnName].Header.Caption = "取引区分コード";
            band.Columns[this._dataSet.StockAdjust.AcPayTransCdColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.StockAdjust.AcPayTransCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjust.AcPayTransCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // （受払元取引区分名称）
            band.Columns[this._dataSet.StockAdjust.AcPayTransCdNmColumn.ColumnName].Hidden = true;
            band.Columns[this._dataSet.StockAdjust.AcPayTransCdNmColumn.ColumnName].Header.Caption = "取引区分";
            band.Columns[this._dataSet.StockAdjust.AcPayTransCdNmColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.StockAdjust.AcPayTransCdNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjust.AcPayTransCdNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // （仕入担当者コード）
            band.Columns[this._dataSet.StockAdjust.StockAgentCodeColumn.ColumnName].Hidden = true;
            band.Columns[this._dataSet.StockAdjust.StockAgentCodeColumn.ColumnName].Header.Caption = "担当者コード";
            band.Columns[this._dataSet.StockAdjust.StockAgentCodeColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.StockAdjust.StockAgentCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjust.StockAgentCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 仕入担当者名称
            band.Columns[this._dataSet.StockAdjust.StockAgentNameColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjust.StockAgentNameColumn.ColumnName].Header.Caption = "担当者名";
            band.Columns[this._dataSet.StockAdjust.StockAgentNameColumn.ColumnName].Width = 120;
            band.Columns[this._dataSet.StockAdjust.StockAgentNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjust.StockAgentNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 仕入金額小計
            band.Columns[this._dataSet.StockAdjust.StockSubttlPriceColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjust.StockSubttlPriceColumn.ColumnName].Header.Caption = "仕入金額";
            band.Columns[this._dataSet.StockAdjust.StockSubttlPriceColumn.ColumnName].Width = 120;
            band.Columns[this._dataSet.StockAdjust.StockSubttlPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjust.StockSubttlPriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataSet.StockAdjust.StockSubttlPriceColumn.ColumnName].Format = moneyFormat;

            // 入力日付
            band.Columns[this._dataSet.StockAdjust.InputDayColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjust.InputDayColumn.ColumnName].Header.Caption = "入力日";
            //band.Columns[this._dataSet.StockAdjust.InputDayColumn.ColumnName].Width = 150;                //DEL 2009/04/03 不具合対応[12857]
            band.Columns[this._dataSet.StockAdjust.InputDayColumn.ColumnName].Width = 100;                  //ADD 2009/04/03 不具合対応[12857]              
            band.Columns[this._dataSet.StockAdjust.InputDayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjust.InputDayColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 伝票備考
            band.Columns[this._dataSet.StockAdjust.SlipNoteColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjust.SlipNoteColumn.ColumnName].Header.Caption = "伝票備考";
            band.Columns[this._dataSet.StockAdjust.SlipNoteColumn.ColumnName].Width = 180;
            band.Columns[this._dataSet.StockAdjust.SlipNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjust.SlipNoteColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // （拠点コード）
            band.Columns[this._dataSet.StockAdjust.SectionCodeColumn.ColumnName].Hidden = true;
            band.Columns[this._dataSet.StockAdjust.SectionCodeColumn.ColumnName].Header.Caption = "拠点コード";
            band.Columns[this._dataSet.StockAdjust.SectionCodeColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.StockAdjust.SectionCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjust.SectionCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 拠点ガイド略称
            band.Columns[this._dataSet.StockAdjust.SectionGuideSnmColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjust.SectionGuideSnmColumn.ColumnName].Header.Caption = "拠点名";
            band.Columns[this._dataSet.StockAdjust.SectionGuideSnmColumn.ColumnName].Width = 120;
            band.Columns[this._dataSet.StockAdjust.SectionGuideSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjust.SectionGuideSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // （倉庫コード）
            band.Columns[this._dataSet.StockAdjust.WarehouseCodeColumn.ColumnName].Hidden = true;
            band.Columns[this._dataSet.StockAdjust.WarehouseCodeColumn.ColumnName].Header.Caption = "倉庫コード";
            band.Columns[this._dataSet.StockAdjust.WarehouseCodeColumn.ColumnName].Width = 80;
            band.Columns[this._dataSet.StockAdjust.WarehouseCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataSet.StockAdjust.WarehouseCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 倉庫名称
            band.Columns[this._dataSet.StockAdjust.WarehouseNameColumn.ColumnName].Hidden = false;
            band.Columns[this._dataSet.StockAdjust.WarehouseNameColumn.ColumnName].Header.Caption = "倉庫名";
            band.Columns[this._dataSet.StockAdjust.WarehouseNameColumn.ColumnName].Width = 120;
            band.Columns[this._dataSet.StockAdjust.WarehouseNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataSet.StockAdjust.WarehouseNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            # endregion
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2008/09/30 ADD
        /// <summary>
        /// 伝票番号フォーマット取得
        /// </summary>
        /// <returns></returns>
        private string GetSlipNoFormat()
        {
            Broadleaf.Library.Windows.Forms.UiSet uiSet;
            const string ct_SlipNoEditName = "tNedit_SupplierSlipNo";

            // ＵＩ共通ＸＭＬから桁数を取得する
            if ( uiSetControl1.ReadUISet( out uiSet, ct_SlipNoEditName ) == 0 )
            {
                return new string( '0', uiSet.Column );
            }
            else
            {
                return string.Empty;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2008/09/30 ADD
       
		/// <summary>
		/// グリッド行初期設定処理
		/// </summary>
		private void GridRowInitialSetting()
		{
            if (this._searchSlipAcs.GetStockSlipTableCache() == null)
            {
                this._dataSet.StockAdjust.Rows.Clear();
            }

			if (this.uGrid_Details.Rows.Count != 0)
			{
				this.uButton_StockSearch.Enabled = true;
			}
			else
			{
				this.uButton_StockSearch.Enabled = false;
			}
		}

		/// <summary>
		/// ボタン初期設定処理
		/// </summary>
		private void ButtonInitialSetting()
		{
            this.uButton_StockSearch.ImageList = this._imageList16;
            this.uButton_StockSearch.Appearance.Image = (int)Size16_Index.DETAILS;
        }
        # endregion

        # region [伝票選択]
        /// <summary>
		/// 選択伝票情報設定
		/// </summary>
        public bool ReturnSelectData()
        {
            if ((uGrid_Details.ActiveRow == null) ||
                (uGrid_Details.ActiveRow.Index < 0) ||
                (uGrid_Details.ActiveRow.Selected == false))
            {
                this.StatusBarMessageSetting(this, "伝票が選択されていません。");
                return false;
            }

			// 選択行決定
			this.SelectRow();

            return true;
        }

        /// <summary>
        /// 選択伝票情報設定
        /// </summary>
        public bool SetGridEnable()
        {
            bool enable = false;

            if (this.uGrid_Details.Rows.Count == 0)
            {
                enable = false;
            }
            else
            {
                enable = true;
            }
            this.uGrid_Details.Enabled = enable;

            return enable;
        }
        # endregion

        # region コントロールイベントメソッド
        /// <summary>
        /// ロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputDetails_Load( object sender, EventArgs e )
        {
            // グリッド列初期設定処理
            this.GridColInitialSetting();

            // ボタン初期設定処理
            this.ButtonInitialSetting();

            // グリッド行初期設定処理
            this.GridRowInitialSetting();
        }


        /// <summary>
        /// グリッドエンターイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_Enter(object sender, EventArgs e)
        {
            if (this.uGrid_Details.Rows.Count != 0)
            {
                this.uButton_StockSearch.Enabled = true;
                this.DecisionButtonEnableSet(true);
            }

            if (this.uGrid_Details.ActiveRow != null)
            {
                this.uGrid_Details.ActiveRow.Selected = true;
            }
        }

        /// <summary>
        /// グリッドフォーカス離脱時イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {
            if (this.uGrid_Details.Rows.Count == 0)
            {
                this.uButton_StockSearch.Enabled = false;
            }
            this.DecisionButtonEnableSet(false);
        }

        /// <summary>
        /// グリッドキーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Details.ActiveRow == null) return;

            // Enterキー
            if (e.KeyCode == Keys.Enter)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;
            
                // 選択行決定
				this.SelectRow();
			}

            // 最上行での↑キー
            if (this.uGrid_Details.ActiveRow.Index == 0)
            {
                if (e.KeyCode == Keys.Up)
                {
                    // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                    e.Handled = true;
                    this.uButton_StockSearch.Focus();
                }
            }

            // →矢印キー
            if (e.KeyCode == Keys.Right)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;
                // グリッド表示を右にスクロール
                this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position + 40;
            }

            // ←矢印キー
            if (e.KeyCode == Keys.Left)
            {
                // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                e.Handled = true;
                if (this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position == 0)
                {
                    this.uButton_StockSearch.Focus();
                }
                else
                {
                    // グリッド表示を左にスクロール
                    this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position - 40;
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
                    this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = 0;
                }

                // Controlキーとの組合せの場合
                if (e.Modifiers == Keys.Control)
                {
                    // グリッド表示を左先頭にスクロール
                    //this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = 0;
                    // 先頭行に移動
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid);
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
                    this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Range;
                }

                // Controlキーとの組合せの場合
                if (e.Modifiers == Keys.Control)
                {
                    // グリッド表示を右末尾にスクロール
                    //this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Range;
                    // 最終行に移動
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastRowInGrid);
                }
            }
        }

        /// <summary>
        /// グリッド行ダブルクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
			// 選択行決定
			this.SelectRow();
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
        /// 選択行情報取得タイマー起動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void timer_SelectRow_Tick(object sender, EventArgs e)
        {
			this.timer_SelectRow.Enabled = false;
            if (this.uGrid_Details.ActiveRow != null)
            {
				// 選択行のインデックスを取得
				CurrencyManager cm = (CurrencyManager)BindingContext[this.uGrid_Details.DataSource];
				int index = cm.Position;
				
				this._stockAdjRefSearchRetWork = this._searchSlipAcs.GetSelectedRowData(index);
                this.SetMainDialogResult(DialogResult.OK);
                this.CloseMain();
            }
        }

        /// <summary>
        /// 行選択処理
        /// </summary>
		public void SelectRow()
		{
			if (StartMovment == 1) return;

			if (this.uGrid_Details.ActiveRow != null)
			{
				CurrencyManager cm = (CurrencyManager)BindingContext[this.uGrid_Details.DataSource];
				int index = cm.Position;

				this._stockAdjRefSearchRetWork = this._searchSlipAcs.GetSelectedRowData(index);
				this.SetMainDialogResult(DialogResult.OK);
				this.CloseMain();
			}
		}

        /// <summary>
        /// グリッド(初期)フォーカス設定タイマー起動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void timer_GridSetFocus_Tick(object sender, EventArgs e)
        {
            this.uGrid_Details.Focus();

            if (this.uGrid_Details.ActiveRow != null)
            {
                this.uGrid_Details.ActiveRow.Selected = true;
            }

            this.timer_GridSetFocus.Enabled = false;
        }

        /// <summary>
        /// 明細情報ボタン クリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_StockSearch_Click(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveRow == null)
            {
                return;
            }

			CurrencyManager cm = (CurrencyManager)BindingContext[this.uGrid_Details.DataSource];
			int index = cm.Position;
			
			// 現在選択行の仕入伝票情報取得
            StockAdjRefSearchRetWork stockAdjRefSearchRetWork = this._searchSlipAcs.GetSelectedRowData(index);

            // 明細参照画面を起動
            PMZAI04001UC searchDetail = new PMZAI04001UC(stockAdjRefSearchRetWork);
            DialogResult dialogResult = searchDetail.ShowDialog(this);

            if (dialogResult == DialogResult.OK)
            {
                this._stockAdjRefSearchRetWork = this._searchSlipAcs.GetSelectedRowData(index);
                this.SetMainDialogResult(DialogResult.OK);
                this.CloseMain();
            }
        }

        # endregion

    }
}

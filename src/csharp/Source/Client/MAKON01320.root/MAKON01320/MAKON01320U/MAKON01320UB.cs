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
    using GridSettingsType = SlipGridSettings;  // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更

	public partial class MAKON01320UB : UserControl
	{
        // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
        #region 伝票グリッド

        /// <summary>
        /// 伝票情報グリッドを取得します。
        /// </summary>
        public Infragistics.Win.UltraWinGrid.UltraGrid SlipGrid
        {
            get { return this.uGrid_Details; }
        }

        /// <summary>グリッドの設定情報</summary>
        private readonly GridSettingsType _gridSettings;
        /// <summary>グリッドの設定情報を取得します。</summary>
        private GridSettingsType GridSettings { get { return _gridSettings; } }

        /// <summary>
        /// 明細情報グリッドにグリッド設定情報を展開します。
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void LoadDetailGridSettings(
            object sender,
            EventArgs e
        )
        {
            MAKON01320UC detailForm = sender as MAKON01320UC;
            if (detailForm == null) return;

            // 列移動と列固定を可能とする
            SlipGridUtil.EnableAllowColSwappingAndFixedHeaderIndicator(detailForm.DetailGrid);
            // グリッド列の設定を取込
            SlipGridUtil.LoadColumnInfo(detailForm.DetailGrid, GridSettings.DetailColumnsList);
        }

        /// <summary>
        /// 明細情報グリッドのグリッド設定情報を設定します。
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void SetDetailGridSettings(
            object sender,
            FormClosingEventArgs e
        )
        {
            MAKON01320UC detailForm = sender as MAKON01320UC;
            if (detailForm == null) return;

            // 明細情報画面のグリッド列情報を生成
            GridSettings.DetailColumnsList = SlipGridUtil.CreateColumnInfoList(detailForm.DetailGrid);
        }

        #endregion // 伝票グリッド
        // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ----------<<<<<

		#region ■Constructor
        // DEL 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
		//public MAKON01320UB()
        // DEL 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ----------<<<<<
        // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="gridSettings">伝票グリッドの設定情報</param>
        public MAKON01320UB(GridSettingsType gridSettings)
        // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ----------<<<<<
		{
			InitializeComponent();

            this._searchSlipAcs = SearchSlipAcs.GetInstance();
            this._dataSet = this._searchSlipAcs.DataSet;
            this.uGrid_Details.DataSource = this._dataSet.StockSlip;
            this._imageList16 = IconResourceManagement.ImageList16;
            this._searchRetStockSlip = new SearchRetStockSlip();
			this._searchParaStockSlip = new SearchParaStockSlip();

            // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
            // 伝票グリッドの設定情報を保持
            this._gridSettings = gridSettings;
            // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ----------<<<<<
		}
		#endregion

		#region ■Private Members
		private SearchSlipAcs _searchSlipAcs;
		private StockDataSet _dataSet;
		private ImageList _imageList16 = null;									// イメージリスト
		private int _startMovment = 0;											// 起動モード 0:エントリー 1:メニュー
        int _secMngDiv;
        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
		#endregion

		#region ■Public Members
		public SearchRetStockSlip _searchRetStockSlip;
		public SearchParaStockSlip _searchParaStockSlip = null;
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
		
		/// <summary>伝票種別プロパティ</summary>
		public int SupplierFormal
		{
			get { return this._searchParaStockSlip.SupplierFormal; }
		}

        /// <summary>
        /// 部門管理区分
        /// </summary>
        public int SecMngDiv
        {
            get { return this._secMngDiv; }
            set { this._secMngDiv = value; }
        }
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

		private void InputDetails_Load(object sender, EventArgs e)
		{
            // グリッド列初期設定処理
			this.GridColInitialSetting();

			// ボタン初期設定処理
			this.ButtonInitialSetting();

			// グリッド行初期設定処理
			this.GridRowInitialSetting();
		}

		/// <summary>
		/// グリッド列初期設定処理
		/// </summary>
		private void GridColInitialSetting()
		{
			bool hiddenMode = true;	//true:仕入 false:入荷
			int visiblePosition = 1;
			string dateFormat = "yyyy/MM/dd";
			string moneyFormat = "#,##0;-#,##0;''";
            string headertext = string.Empty;
            string supplierCdFormat = "0#####";
            string supplierSlipCdFormat = "0########";
			//仕入
			if (SupplierFormal == 0)
			{
				hiddenMode = true;
                headertext = "仕入日";
			}
			//入荷
			else
			{
				hiddenMode = true;
                headertext = "入荷日";

			}

			for (int i = 0; i < this.uGrid_Details.DisplayLayout.Bands[0].Columns.Count; i++)
			{
				// 入力許可設定
				//this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].AutoEdit = false;

				// 表示非表示設定
				this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].Hidden = true;
				this.uGrid_Details.DisplayLayout.Bands[0].Columns[i].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
			}

			//No.
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockRowNoColumn.ColumnName].Hidden = false;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockRowNoColumn.ColumnName].Width = 35;			// №
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockRowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockRowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockRowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockRowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockRowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockRowNoColumn.ColumnName].Header.Fixed = true;			// №
			this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockRowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //仕入日
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockDateStringColumn.ColumnName].Hidden = !hiddenMode;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockDateStringColumn.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockDateStringColumn.ColumnName].Width = 90;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockDateStringColumn.ColumnName].Header.Caption = headertext;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockDateStringColumn.ColumnName].Header.Caption = "仕入日";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockDateStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockDateStringColumn.ColumnName].Format = dateFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockDateStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //入荷日
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.ArrivalGoodsDayStringColumn.ColumnName].Hidden = hiddenMode;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.ArrivalGoodsDayStringColumn.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.ArrivalGoodsDayStringColumn.ColumnName].Width = 90; // 入荷日
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.ArrivalGoodsDayStringColumn.ColumnName].Header.Caption = "入荷日";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.ArrivalGoodsDayStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.ArrivalGoodsDayStringColumn.ColumnName].Format = dateFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.ArrivalGoodsDayStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //入力日
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.InputDayStringColumn.ColumnName].Hidden = !hiddenMode;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.InputDayStringColumn.ColumnName].Width = 90;		    // 入力日
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.InputDayStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.InputDayStringColumn.ColumnName].Format = dateFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.InputDayStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

			//伝票番号
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.PartySaleSlipNumColumn.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.PartySaleSlipNumColumn.ColumnName].Width = 160;	// 相手先伝番 // 2009.01.05 Modify [9486]
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //伝票種別
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.SupplierFomalNameColumn.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.SupplierFomalNameColumn.ColumnName].Width = 100;	// 仕入形式名
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.SupplierFomalNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;	    // 仕入形式
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.SupplierFomalNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //伝票区分
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.SupplierSlipCdNameColumn.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.SupplierSlipCdNameColumn.ColumnName].Width = 90;	// 伝票区分名
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.SupplierSlipCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;	    // 伝票区分
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.SupplierSlipCdNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //仕入先コード
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.CustomerCodeColumn.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.CustomerCodeColumn.ColumnName].Width = 60;  		// 仕入先コード
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.CustomerCodeColumn.ColumnName].Format = supplierCdFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.CustomerCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //仕入先
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.CustomerNameColumn.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.CustomerNameColumn.ColumnName].Width = 120;  		// 仕入先名
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.CustomerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //担当者
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockAgentNameColumn.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockAgentNameColumn.ColumnName].Width = 90;  	// 担当者名
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockAgentNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //仕入金額（税込）
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockTotalPriceColumn.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockTotalPriceColumn.ColumnName].Width = 160;	// 金額合計
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockTotalPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockTotalPriceColumn.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockTotalPriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockTotalPriceColumn.ColumnName].Header.Caption = "仕入金額";

            //仕入金額（税抜）
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockSubttlPriceColumn.ColumnName].Hidden = false;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockSubttlPriceColumn.ColumnName].Width = 160;	// 金額小計
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockSubttlPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockSubttlPriceColumn.ColumnName].Format = moneyFormat;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockSubttlPriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockSubttlPriceColumn.ColumnName].Header.Caption = "仕入金額（税抜）";

            //消費税
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockPriceConsTaxColumn.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockPriceConsTaxColumn.ColumnName].Width = 100;	// 消費税
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockPriceConsTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockPriceConsTaxColumn.ColumnName].Format = moneyFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockPriceConsTaxColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockPriceConsTaxColumn.ColumnName].Header.Caption = "消費税";

            ////赤伝区分
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.DebitNoteDivNameColumn.ColumnName].Hidden = false;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.DebitNoteDivNameColumn.ColumnName].Width = 100;	// 赤伝区分名
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.DebitNoteDivNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;		// 赤伝区分
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.DebitNoteDivNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            ////商品区分
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockGoodsCdNameColumn.ColumnName].Hidden = false;
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockGoodsCdNameColumn.ColumnName].Width = 90;	// 商品区分名
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockGoodsCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;		// 商品区分
            //this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockGoodsCdNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;


            //計上日
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockAddUpADateStringColumn.ColumnName].Hidden = false;   // 常に表示
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockAddUpADateStringColumn.ColumnName].Width = 90; // 計上日
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockAddUpADateStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockAddUpADateStringColumn.ColumnName].Format = dateFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.StockAddUpADateStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //仕入SEQ番号
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.SupplierSlipNoColumn.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.SupplierSlipNoColumn.ColumnName].Width = 110;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.SupplierSlipNoColumn.ColumnName].Header.Fixed = true;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.SupplierSlipNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.SupplierSlipNoColumn.ColumnName].Format = supplierSlipCdFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.SupplierSlipNoColumn.ColumnName].Header.Caption = "仕入SEQ番号";

            //伝票備考１
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.SupplierSlipNote1Column.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.SupplierSlipNote1Column.ColumnName].Width = 120;	// 伝票備考1
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.SupplierSlipNote1Column.ColumnName].Header.VisiblePosition = visiblePosition++;

            //伝票備考２
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.SupplierSlipNote2Column.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.SupplierSlipNote2Column.ColumnName].Width = 120;	// 伝票備考2
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.SupplierSlipNote2Column.ColumnName].Header.VisiblePosition = visiblePosition++;

            //リマーク1
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.UoeRemark1Column.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.UoeRemark1Column.ColumnName].Width = 100;	// リマーク1
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.UoeRemark1Column.ColumnName].Header.VisiblePosition = visiblePosition++;

            //拠点名
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.SectionNameColumn.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.SectionNameColumn.ColumnName].Width = 100;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.SectionNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            if (this._secMngDiv != 0)
            {
                //部門名
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.SubSectionNameColumn.ColumnName].Hidden = false;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.SubSectionNameColumn.ColumnName].Width = 100;
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.SubSectionNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            }

            //支払先コード
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.PayeeCodeColumn.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.PayeeCodeColumn.ColumnName].Width = 70;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.PayeeCodeColumn.ColumnName].Format = supplierCdFormat;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.PayeeCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //支払先名
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.PayeeSnmColumn.ColumnName].Hidden = false;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.PayeeSnmColumn.ColumnName].Width = 100;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._dataSet.StockSlip.PayeeSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

		}
        
		/// <summary>
		/// グリッド行初期設定処理
		/// </summary>
		private void GridRowInitialSetting()
		{
            if (this._searchSlipAcs.GetStockSlipTableCache() == null)
            {
                this._dataSet.StockSlip.Rows.Clear();
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

        # region コントロールイベントメソッド

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

            //IOWriteMASIRReadWork ioWriteMASIRReadWork = new IOWriteMASIRReadWork();

            //// 読込条件パラメータクラス設定処理
            //this.ReadParaSetting(out ioWriteMASIRReadWork);

            //// 伝票情報読込・データセット格納処理
            //this._searchSlipAcs.SetSearchData(ioWriteMASIRReadWork);
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
				
				this._searchRetStockSlip = this._searchSlipAcs.GetSelectedRowData(index);
                this.SetMainDialogResult(DialogResult.OK);
                this.CloseMain();
            }
        }

		public void SelectRow()
		{
			if (StartMovment == 1) return;

			if (this.uGrid_Details.ActiveRow != null)
			{
				CurrencyManager cm = (CurrencyManager)BindingContext[this.uGrid_Details.DataSource];
				int index = cm.Position;

				this._searchRetStockSlip = this._searchSlipAcs.GetSelectedRowData(index);
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
            SearchRetStockSlip searchRetStockSlip = this._searchSlipAcs.GetSelectedRowData(index);

            // 明細参照画面を起動
            MAKON01320UC searchDetail = new MAKON01320UC(searchRetStockSlip);

            // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
            // FIXME:明細表示画面のグリッド列情報をロード時に設定
            searchDetail.Load += new EventHandler(this.LoadDetailGridSettings);
            // FIXME:明細表示画面のグリッド列情報をクローズ時に取得
            searchDetail.FormClosing += new FormClosingEventHandler(this.SetDetailGridSettings);
            // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ----------<<<<<

            DialogResult dialogResult = searchDetail.ShowDialog(this);

            if (dialogResult == DialogResult.OK)
            {
                this._searchRetStockSlip = this._searchSlipAcs.GetSelectedRowData(index);
                this.SetMainDialogResult(DialogResult.OK);
                this.CloseMain();
            }
        }

        # endregion
    }
}

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
	public partial class MAKON01320UC : Form
	{
        public MAKON01320UC(SearchRetStockSlip searchRetStockSlip)
		{
			InitializeComponent();

            if (searchRetStockSlip != null)
            {
                this._searchRetStockSlip = searchRetStockSlip;
            }
            this._searchMain = new MAKON01320UA();
            this._searchSlipAcs = SearchSlipAcs.GetInstance();
            this._dataSet = this._searchSlipAcs.DataSet;
			this.uGrid_ViewDetails.DataSource = this._dataSet.StockDetail;

            this._imageList16 = IconResourceManagement.ImageList16;
            this._returnButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_ViewDetail.Tools["ButtonTool_Return"];
            this._decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_ViewDetail.Tools["ButtonTool_Decision"];

            this.SetInitialDataValue();
        }

        private MAKON01320UA _searchMain;
        private SearchSlipAcs _searchSlipAcs;
        private StockDataSet _dataSet;
		private ImageList _imageList16 = null;									// イメージリスト
        private SearchRetStockSlip _searchRetStockSlip;
        private string[] _supplierFormalStr = new string[3];                    // 仕入形式
        SortedList _supplierSlipCdStr = new SortedList();                       // 伝票形式
        private string[] _stockGoodsCdStr = new string[7];                      // 商品区分
        //private string[] _accPayDivCdStr = new string[2];                       // 買掛区分 // DEL 2009/01/23

        private Infragistics.Win.UltraWinToolbars.ButtonTool _returnButton;		// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _decisionButton;	// 確定ボタン

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        private void MAKON01320UC_Load(object sender, EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

			// グリッド列初期設定処理
			this.GridColInitialSetting();

			// ボタン初期設定処理
			this.ButtonInitialSetting();

			// グリッド行初期設定処理
			this.GridRowInitialSetting();

            // ヘッダ部情報設定処理
            this.SetHeaderInfo();

            // 対象伝票の明細情報を取得
            this._searchSlipAcs.SetDetailData(this._searchRetStockSlip.SupplierFormal, this._searchRetStockSlip.SupplierSlipNo);
        }

        /// <summary>
        /// 固定値変数初期化処理
        /// </summary>
        private void SetInitialDataValue()
        {
            // 仕入形式
            _supplierFormalStr[0] = "仕入";
			_supplierFormalStr[1] = "入荷";
			_supplierFormalStr[2] = "発注";

            // 伝票区分
            _supplierSlipCdStr.Add(10,"仕入");
            _supplierSlipCdStr.Add(20,"返品");

            // 商品区分
            _stockGoodsCdStr[0] = "商品";
            _stockGoodsCdStr[1] = "商品外";
            _stockGoodsCdStr[2] = "消費税調整";
            _stockGoodsCdStr[3] = "残高調整";
			_stockGoodsCdStr[4] = "消費税調整(買掛用)";
			_stockGoodsCdStr[5] = "残高調整(買掛用)";
			_stockGoodsCdStr[6] = "合計入力";

            // --- DEL 2009/01/23 -------------------------------->>>>>
            //// 買掛区分
            //_accPayDivCdStr[0] = "現金";
            //_accPayDivCdStr[1] = "掛";
            // --- DEL 2009/01/23 -------------------------------->>>>>
        }

        /// <summary>
        /// ヘッダ部情報設定処理
        /// </summary>
        private void SetHeaderInfo()
        {
			this.uLabel_SupplierFormal.Text = _supplierFormalStr[_searchRetStockSlip.SupplierFormal];   // 仕入形式

            this.uLabel_SupplierSlipNo.Text = _searchRetStockSlip.SupplierSlipNo.ToString().PadLeft(9, '0');// 2008.12.10 modify [9010]
            // 仕入SEQ番号
            this.uLabel_PartySaleSlipNum.Text = _searchRetStockSlip.PartySaleSlipNum;                   // 伝票番号
            //this.uLabel_SupplierSlipCd.Text = _accPayDivCdStr[_searchRetStockSlip.AccPayDivCd]
            //                                + _supplierSlipCdStr[_searchRetStockSlip.SupplierSlipCd].ToString();    // 伝票形式 // DEL 2009/01/23
            this.uLabel_SupplierSlipCd.Text = _supplierSlipCdStr[_searchRetStockSlip.SupplierSlipCd].ToString();    // 伝票形式 // ADD 2009/01/23
            //this.uLabel_StockGoodsCd.Text   = _stockGoodsCdStr[_searchRetStockSlip.StockGoodsCd];        // 商品区分
            //this.uLabel_AccPayDivCd.Text    = _accPayDivCdStr[_searchRetStockSlip.AccPayDivCd];          // 買掛区分
            this.uLabel_StockAgentCode.Text = _searchRetStockSlip.StockAgentCode;                       // 仕入担当者コード
            this.uLabel_StockAgentName.Text = _searchRetStockSlip.StockAgentName;                       // 担当者名
            // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //this.uLabel_CustomerCode.Text = _searchRetStockSlip.CustomerCode.ToString("d9");
            //this.uLabel_CustomerName.Text = _searchRetStockSlip.CustomerName;
            this.uLabel_CustomerCode.Text = _searchRetStockSlip.SupplierCd.ToString("d6");              // 仕入先コード
            this.uLabel_CustomerName.Text = _searchRetStockSlip.SupplierSnm;// SupplierNm1;                            // 仕入先名
            // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.25 TOKUNAGA ADD START
            this.uLabel_SectionCode.Text = _searchRetStockSlip.SectionCode;                             // 拠点コード

            // MAKON01936Dが拠点名を持たないのでこちらで取得
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet;
            int status = secInfoSetAcs.Read(out secInfoSet, _searchRetStockSlip.EnterpriseCode, _searchRetStockSlip.SectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm;                               // 拠点名
            }
            
            this.uLabel_PayeeCode.Text = _searchRetStockSlip.PayeeCode.ToString("d6");                  // 支払先コード
            this.uLabel_PayeeName.Text = _searchRetStockSlip.PayeeSnm;                                  // 支払先名
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.08.25 TOKUNAGA ADD END

			if (_searchRetStockSlip.SupplierFormal == 0)
			{
				uLabel_Header10.Text = "仕入日";

				//仕入日
				if (_searchRetStockSlip.StockDate == DateTime.MinValue)
				{
					this.uLabel_ArrivalGoodsDay.Text = "";
				}
				else
				{
					this.uLabel_ArrivalGoodsDay.Text = _searchRetStockSlip.StockDate.Date.ToString("yyyy年MM月dd日");
				}
			}
			else
			{
				uLabel_Header10.Text = "入荷日";

				//入荷日
				if (_searchRetStockSlip.ArrivalGoodsDay == DateTime.MinValue)
				{
					this.uLabel_ArrivalGoodsDay.Text = "";
				}
				else
				{
					this.uLabel_ArrivalGoodsDay.Text = _searchRetStockSlip.ArrivalGoodsDay.Date.ToString("yyyy年MM月dd日");
				}
			}


			//入力日
			if (_searchRetStockSlip.InputDay == DateTime.MinValue)
			{
				this.uLabel_StockAddUpADate.Text = "";
			}
			else
			{
				this.uLabel_StockAddUpADate.Text = _searchRetStockSlip.InputDay.Date.ToString("yyyy年MM月dd日");
			}
        }

		/// <summary>
		/// グリッド列初期設定処理
		/// </summary>
		private void GridColInitialSetting()
		{
			string moneyFormat = "#,##0;-#,##0;''";
			string cntFormat = "#,##0.00;-#,##0.00;''";
			//string cntFormat = "0.00";
			
			int visiblePosition = 1;
			bool hiddenMode = false;

			//仕入
			if (this._searchRetStockSlip.SupplierFormal == 0)
			{
				hiddenMode = true;
			}
			//入荷
			else
			{
				hiddenMode = false;
			}


			// 固定列区切り線設定
			this.uGrid_ViewDetails.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_ViewDetails.DisplayLayout.Override.HeaderAppearance.BackColor2;

			// 入力許可設定
			for (int i = 0; i < this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns.Count; i++)
			{
				this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[i].AutoEdit = false;
				this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[i].Hidden = true;
			}

			//行番号
            this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockDetailRowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockDetailRowNoColumn.ColumnName].Header.Caption = "行番号";
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockDetailRowNoColumn.ColumnName].Width = 50;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockDetailRowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockDetailRowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_ViewDetails.DisplayLayout.Override.HeaderAppearance.BackColor;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockDetailRowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_ViewDetails.DisplayLayout.Override.HeaderAppearance.BackColor2;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockDetailRowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_ViewDetails.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockDetailRowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockDetailRowNoColumn.ColumnName].CellAppearance.ForeColor = Color.White;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockDetailRowNoColumn.ColumnName].Hidden = false;

			//品番
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.GoodsCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;				// 商品コード 
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.GoodsCodeColumn.ColumnName].Width = 100;		     // 商品コード 
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.GoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.GoodsCodeColumn.ColumnName].Hidden = false;

			//品名
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.GoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;				// 商品名
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.GoodsNameColumn.ColumnName].Width = 100;		     // 商品名
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.GoodsNameColumn.ColumnName].Hidden = false;
			
			//メーカー
            //this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;		    // 商品メーカーコード 
            //this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.GoodsMakerCdColumn.ColumnName].Width = 100;		     // 商品メーカーコード 
            //this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;	// 商品メーカーコード 
            //this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.GoodsMakerCdColumn.ColumnName].Hidden = false;
            //this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.GoodsMakerCdColumn.ColumnName].Format = "000000";	
			
			//メーカー名
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.MakerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.MakerNameColumn.ColumnName].Width = 100;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.MakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.MakerNameColumn.ColumnName].Hidden = false;

            //// 仕入先コード
            //this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.SupplierCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.SupplierCdColumn.ColumnName].Width = 70;
            //this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.SupplierCdColumn.ColumnName].Hidden = false;
            
            //// 仕入先
            //this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.SupplierNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.SupplierNameColumn.ColumnName].Width = 100;
            //this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.SupplierNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.SupplierNameColumn.ColumnName].Hidden = false;

            // BLコード
            // 2009.01.05 Modify [9486]
            //this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.BLGoodsCodeColumn.ColumnName].Width = 100;
            //this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.BLGoodsCodeColumn.ColumnName].Hidden = false;
            this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.BLGoodsCodeStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.BLGoodsCodeStringColumn.ColumnName].Width = 100;
            this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.BLGoodsCodeStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.BLGoodsCodeStringColumn.ColumnName].Hidden = false;
            // 2009.01.05 Modify [9486]

            // 標準価格
            this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.ListPriceTaxExcFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.ListPriceTaxExcFlColumn.ColumnName].Width = 100;
            this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.ListPriceTaxExcFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.ListPriceTaxExcFlColumn.ColumnName].Format = moneyFormat;
            this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.ListPriceTaxExcFlColumn.ColumnName].Hidden = false;

			// 数量＜仕入時のみ＞
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockCountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockCountColumn.ColumnName].Width = 100;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockCountColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockCountColumn.ColumnName].Format = moneyFormat;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockCountColumn.ColumnName].Hidden = !hiddenMode;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockCountColumn.ColumnName].Format = cntFormat;

			// 入荷数＜入荷時のみ＞
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.ArrivalCntColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.ArrivalCntColumn.ColumnName].Hidden = true;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.ArrivalCntColumn.ColumnName].Width = 100;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.ArrivalCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.ArrivalCntColumn.ColumnName].Format = moneyFormat;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.ArrivalCntColumn.ColumnName].Hidden = hiddenMode;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.ArrivalCntColumn.ColumnName].Format = cntFormat;

			//入荷残数＜入荷時のみ＞
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.ArrivalRemainCntColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.ArrivalRemainCntColumn.ColumnName].Width = 100; // 入荷残数
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.ArrivalRemainCntColumn.ColumnName].Format = moneyFormat;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.ArrivalRemainCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.ArrivalRemainCntColumn.ColumnName].Hidden = hiddenMode;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.ArrivalRemainCntColumn.ColumnName].Format = cntFormat;

			// 仕入単価
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockUnitPriceDisplayColumn.ColumnName].Header.VisiblePosition = visiblePosition++; // 単価(表示用)
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockUnitPriceDisplayColumn.ColumnName].Width = 100; // 単価(表示用)
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockUnitPriceDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // 2008.11.13 modify start [7787]
			//this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockUnitPriceDisplayColumn.ColumnName].Format = moneyFormat; // 単価(表示用)
            this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockUnitPriceDisplayColumn.ColumnName].Format = cntFormat; // 単価(表示用)
            // 2008.11.13 modify end [7787]
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockUnitPriceDisplayColumn.ColumnName].Hidden = false; // 単価(表示用)
			
			// 仕入金額
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockPriceDisplayColumn.ColumnName].Header.VisiblePosition = visiblePosition++;		// 仕入金額(表示用)
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockPriceDisplayColumn.ColumnName].Width = 100;	 // 仕入金額(表示用)
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockPriceDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockPriceDisplayColumn.ColumnName].Format = moneyFormat;	  // 仕入金額(表示用)
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockPriceDisplayColumn.ColumnName].Hidden = false;	  // 仕入金額(表示用)

			//消費税
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockPriceConsTaxColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockPriceConsTaxColumn.ColumnName].Width = 100;	 // 仕入金額(表示用)
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockPriceConsTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockPriceConsTaxColumn.ColumnName].Format = moneyFormat;	  // 仕入金額(表示用)
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockPriceConsTaxColumn.ColumnName].Hidden = false;	  // 仕入金額(表示用)

			//倉庫名
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.WarehouseNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;			// 倉庫名
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.WarehouseNameColumn.ColumnName].Width = 100;	     // 倉庫名
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.WarehouseNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.WarehouseNameColumn.ColumnName].Hidden = false;

            // --- ADD 2009/03/16 -------------------------------->>>>>
            //棚番
            this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.WarehouseShelfNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;			// 棚番
            this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.WarehouseShelfNoColumn.ColumnName].Width = 100;	     // 棚番
            this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.WarehouseShelfNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.WarehouseShelfNoColumn.ColumnName].Hidden = false;
            // --- ADD 2009/03/16 --------------------------------<<<<<

			//税区分
            //this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.TaxationCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;		    // 税区分
            //this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.TaxationCodeColumn.ColumnName].Width = 70;		     // 税区分
            //this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.TaxationCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.TaxationCodeColumn.ColumnName].Hidden = false;

			//備考
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockDtiSlipNote1Column.ColumnName].Header.VisiblePosition = visiblePosition++;		// 備考
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockDtiSlipNote1Column.ColumnName].Width = 150;	 // 備考
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockDtiSlipNote1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns[this._dataSet.StockDetail.StockDtiSlipNote1Column.ColumnName].Hidden = false;

		}

		/// <summary>
		/// グリッド行初期設定処理
		/// </summary>
		private void GridRowInitialSetting()
		{
			this._dataSet.StockDetail.Rows.Clear();
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
            //if (e.PrevCtrl == this.uButton_StockSearch)
            //{
            //    switch (e.Key)
            //    {
            //        case Keys.Up:
            //            {
            //                Control nextControl = this.InitFocusSetting(this);
            //                e.NextCtrl = nextControl;
                            
            //                break;
            //            }
            //        case Keys.Left:
            //            {
            //                break;
            //            }
            //        case Keys.Right:
            //            {
            //                e.NextCtrl = this.uGrid_ViewDetails;
            //                break;
            //            }
            //    }
            //}
        }

        # endregion

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

        // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
        /// <summary>
        /// 明細情報グリッドを取得します。
        /// </summary>
        public Infragistics.Win.UltraWinGrid.UltraGrid DetailGrid
        {
            get { return this.uGrid_ViewDetails; }
        }
        // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ----------<<<<<
    }
}

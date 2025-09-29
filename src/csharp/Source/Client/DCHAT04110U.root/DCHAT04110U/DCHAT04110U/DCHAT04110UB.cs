//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 発注残照会
// プログラム概要   : 発注残照会を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤
// 作 成 日  2010/03/11  修正内容 : MANTIS対応[15129]：発注残照会の明細グリッド列位置を記憶
//----------------------------------------------------------------------------//

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
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	public partial class DCHAT04110UB : UserControl
	{
		#region ■Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="orderRemainReferenceAcs"></param>
		public DCHAT04110UB(DCHAT04112AA orderRemainReferenceAcs)
		{
			InitializeComponent();

			this._orderRemainReferenceAcs = orderRemainReferenceAcs;

			this._dataSet = this._orderRemainReferenceAcs.DataSet;
			this._imageList16 = IconResourceManagement.ImageList16;
			this._orderListResultWorkList = new List<OrderListResultWork>();

			// 列表示状態クラスリストXMLファイルをデシリアライズ
			List<ColDisplayStatus> colDisplayStatusList = ColDisplayStatusList.Deserialize(ctFILENAME_COLDISPLAYSTATUS);

			// 列表示状態コレクションクラスをインスタンス化
			this._colDisplayStatusList = new ColDisplayStatusList(colDisplayStatusList, this._dataSet.OrderListResult);

			this.uGrid_Details.DataSource = this._dataSet.OrderListResult;
		}
		#endregion

		#region ■Private Members

		private DCHAT04112AA _orderRemainReferenceAcs;
		private OrderRemainDataSet _dataSet;
		private ImageList _imageList16 = null;									// イメージリスト

        public List<OrderListResultWork> _orderListResultWorkList;
		public OrderListCndtnWork _orderListCndtnWork;
		private ColDisplayStatusList _colDisplayStatusList;
		private bool _isMultiSelect;
		private bool _isSelect;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
        // 最大選択可能行数
        private int _maxSelectCount;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD

		private readonly Color _selectedBackColor = Color.FromArgb(216, 235, 253);
		private readonly Color _selectedBackColor2 = Color.FromArgb(101, 144, 218);
		
        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		private const string ctFILENAME_COLDISPLAYSTATUS = "DCHAT04110U_ColSetting.DAT";	// 列表示状態セッティングXMLファイル名

		#endregion

		#region ■Delegate
		// デリゲート処理
        internal event SettingStatusBarMessageEventHandler StatusBarMessageSetting;
        internal delegate void SettingStatusBarMessageEventHandler(object sender, string message);

        internal event CloseMainEventHandler CloseMain;
        internal delegate void CloseMainEventHandler();

        internal event SetDialogResEventHandler SetMainDialogResult;
        internal delegate void SetDialogResEventHandler(DialogResult dialogRes);

        internal event SettingDecisionButtonEnableEventHandler DecisionButtonEnableSet;
        internal delegate void SettingDecisionButtonEnableEventHandler(bool enableSet);

		#endregion
		
		#region ■Event

		/// <summary>グリッド最上位行キーダウンイベント</summary>
		internal event EventHandler GridKeyDownTopRow;

		#endregion


		#region ■Properties

		/// <summary>複数選択プロパティ</summary>
		public bool IsMultiSelect 
		{
			get { return _isMultiSelect; }
			set { _isMultiSelect = value; }
		}

		/// <summary>選択可否プロパティ</summary>
		public bool IsSelect
		{
			get { return _isSelect; }
			set { _isSelect = value; }
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
        /// <summary>
        /// 最大選択可能行数
        /// </summary>
        public int MaxSelectCount
        {
            get { return _maxSelectCount; }
            set { _maxSelectCount = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD

		#endregion

		#region ■Public Methods

		/// <summary>
		/// 画面モード設定
		/// </summary>
		public void DisplayModeSetting()
		{
			// グリッドの表示を再設定
			this.GridInitialSetting(this._isMultiSelect);

			// 複数選択モードの場合のみ「全て選択」を表示する
			this.PrintExtra_Panel.Visible = this._isMultiSelect;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
            // 明細選択数の表示判定
            if ( _maxSelectCount > 1 )
            {
                // 表示
                ultraLabel16.Visible = true;
                lb_SelectedCount.Visible = true;
                ultraLabel1.Visible = true;
                lb_MaxSelectCount.Visible = true;

                // 明細選択可能数の表示
                lb_MaxSelectCount.Text = this._maxSelectCount.ToString( "#,##0" );
            }
            else
            {
                // 非表示
                ultraLabel16.Visible = false;
                lb_SelectedCount.Visible = false;
                ultraLabel1.Visible = false;
                lb_MaxSelectCount.Visible = false;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
        /// <summary>
        /// 選択済み件数更新
        /// </summary>
        public void SetSelectedCount( int selectedCount )
        {
            lb_SelectedCount.Text = selectedCount.ToString( "#,##0" );
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

		/// <summary>
		/// クローズ処理
		/// </summary>
		internal void Closing()
		{
			// 列表示状態クラスリスト構築処理
			List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.uGrid_Details.DisplayLayout.Bands[0].Columns);
			this._colDisplayStatusList.SetColDisplayStatusList(colDisplayStatusList);

			// 列表示状態クラスリストをXMLにシリアライズする
			ColDisplayStatusList.Serialize(this._colDisplayStatusList.GetColDisplayStatusList(), ctFILENAME_COLDISPLAYSTATUS);
		}

		#endregion

		#region ■Private Methods

		/// <summary>
		/// 列表示状態クラスリスト構築処理
		/// </summary>
		/// <param name="columns">グリッドのカラムコレクション</param>
		/// <returns>列表示状態クラスリスト</returns>
		private List<ColDisplayStatus> ColDisplayStatusListConstruction( Infragistics.Win.UltraWinGrid.ColumnsCollection columns )
		{
			List<ColDisplayStatus> colDisplayStatusList = new List<ColDisplayStatus>();

			// グリッドから列表示状態クラスリストを構築
			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in columns)
			{
				ColDisplayStatus colDisplayStatus = new ColDisplayStatus();

				colDisplayStatus.Key = column.Key;
				colDisplayStatus.VisiblePosition = column.Header.VisiblePosition;
				colDisplayStatus.HeaderFixed = column.Header.Fixed;
				colDisplayStatus.Width = column.Width;
				colDisplayStatusList.Add(colDisplayStatus);
			}

			return colDisplayStatusList;
		}

		/// <summary>
		/// グリッド列初期設定処理
		/// </summary>
		private void GridInitialSetting(bool select)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/01 ADD
            string numberFormat = "0;-0;''";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/01 ADD
			string moneyFormat = "#,##0;-#,##0;''";
			string decimalFormat = "#,##0.00;-#,##0.00;''";
			string dateFormat = "yyyy/MM/dd";
            int visiblePosition = 0;

			Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

			// 一旦、全ての列を非表示にする。
			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
			{
				//非表示設定
				column.Hidden = true;
				//入力許可設定
				//column.AutoEdit = false;
			}

			//--------------------------------------------------------------------------------
			//  表示するカラム情報
			//--------------------------------------------------------------------------------
			#region カラム情報の設定
			//No.
			Columns[this._dataSet.OrderListResult.NoColumn.ColumnName].Hidden = false;
			Columns[this._dataSet.OrderListResult.NoColumn.ColumnName].Header.Caption = "No.";
			Columns[this._dataSet.OrderListResult.NoColumn.ColumnName].Header.Fixed = true;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/01 DEL
            //Columns[this._dataSet.OrderListResult.NoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/01 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/01 ADD
            Columns[this._dataSet.OrderListResult.NoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/01 ADD
            Columns[this._dataSet.OrderListResult.NoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

			// 選択フラグ
			Columns[this._dataSet.OrderListResult.SelectFlagColumn.ColumnName].Hidden = !select;
			Columns[this._dataSet.OrderListResult.SelectFlagColumn.ColumnName].Header.Caption = "";
			Columns[this._dataSet.OrderListResult.SelectFlagColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
			Columns[this._dataSet.OrderListResult.SelectFlagColumn.ColumnName].AutoEdit = true;
            Columns[this._dataSet.OrderListResult.SelectFlagColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 発注日
            Columns[this._dataSet.OrderListResult.OrderDataCreateDateColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OrderListResult.OrderDataCreateDateColumn.ColumnName].Header.Caption = "発注日";
            Columns[this._dataSet.OrderListResult.OrderDataCreateDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.OrderListResult.OrderDataCreateDateColumn.ColumnName].Format = dateFormat;
            Columns[this._dataSet.OrderListResult.OrderDataCreateDateColumn.ColumnName].Width = 80;
            Columns[this._dataSet.OrderListResult.OrderDataCreateDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._dataSet.OrderListResult.OrderDataCreateDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // --- DEL 2009/02/05 -------------------------------->>>>>
            //// 発注番号(仕入伝票番号)
            //Columns[this._dataSet.OrderListResult.SupplierSlipNoColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.OrderListResult.SupplierSlipNoColumn.ColumnName].Header.Caption = "発注番号";
            //Columns[this._dataSet.OrderListResult.SupplierSlipNoColumn.ColumnName].Width = 60;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/01 DEL
            ////Columns[this._dataSet.OrderListResult.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/01 DEL
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/01 ADD
            //Columns[this._dataSet.OrderListResult.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/01 ADD
            //Columns[this._dataSet.OrderListResult.SupplierSlipNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/01 ADD
            //Columns[this._dataSet.OrderListResult.SupplierSlipNoColumn.ColumnName].Format = numberFormat;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/01 ADD
            // --- DEL 2009/02/05 --------------------------------<<<<<

            // --- DEL 2009/02/05 -------------------------------->>>>>
            // 行番号(仕入行番号)
            //Columns[this._dataSet.OrderListResult.StockRowNoColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.OrderListResult.StockRowNoColumn.ColumnName].Header.Caption = "行番号";
            //Columns[this._dataSet.OrderListResult.StockRowNoColumn.ColumnName].Width = 50;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/01 DEL
            ////Columns[this._dataSet.OrderListResult.StockRowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/01 DEL
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/01 ADD
            //Columns[this._dataSet.OrderListResult.StockRowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/01 ADD
            //Columns[this._dataSet.OrderListResult.StockRowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/01 ADD
            //Columns[this._dataSet.OrderListResult.StockRowNoColumn.ColumnName].Format = numberFormat;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/01 ADD
            // --- DEL 2009/02/05 --------------------------------<<<<<

            // 品番
            Columns[this._dataSet.OrderListResult.GoodsNoColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OrderListResult.GoodsNoColumn.ColumnName].Header.Caption = "品番";
            Columns[this._dataSet.OrderListResult.GoodsNoColumn.ColumnName].Width = 80;
            Columns[this._dataSet.OrderListResult.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.OrderListResult.GoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 品名
            Columns[this._dataSet.OrderListResult.GoodsNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OrderListResult.GoodsNameColumn.ColumnName].Header.Caption = "品名";
            Columns[this._dataSet.OrderListResult.GoodsNameColumn.ColumnName].Width = 110;
            Columns[this._dataSet.OrderListResult.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.OrderListResult.GoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // メーカー名
            Columns[this._dataSet.OrderListResult.MakerNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OrderListResult.MakerNameColumn.ColumnName].Header.Caption = "メーカー";
            Columns[this._dataSet.OrderListResult.MakerNameColumn.ColumnName].Width = 90;
            Columns[this._dataSet.OrderListResult.MakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.OrderListResult.MakerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 発注先
            Columns[this._dataSet.OrderListResult.SupplierCdColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OrderListResult.SupplierCdColumn.ColumnName].Header.Caption = "発注先";
            Columns[this._dataSet.OrderListResult.SupplierCdColumn.ColumnName].Width = 60;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/01 DEL
            //Columns[this._dataSet.OrderListResult.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/01 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/01 ADD
            Columns[this._dataSet.OrderListResult.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/01 ADD
            Columns[this._dataSet.OrderListResult.SupplierCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/01 ADD
            Columns[this._dataSet.OrderListResult.SupplierCdColumn.ColumnName].Format = GetSupplierCodeFormat();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/01 ADD

            // 発注先名
            Columns[this._dataSet.OrderListResult.SupplierSnmColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OrderListResult.SupplierSnmColumn.ColumnName].Header.Caption = "発注先名";
            Columns[this._dataSet.OrderListResult.SupplierSnmColumn.ColumnName].Width = 90;
            Columns[this._dataSet.OrderListResult.SupplierSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.OrderListResult.SupplierSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // BLｺｰﾄﾞ
            Columns[this._dataSet.OrderListResult.BLGoodsCodeColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OrderListResult.BLGoodsCodeColumn.ColumnName].Header.Caption = "BLｺｰﾄﾞ";
            Columns[this._dataSet.OrderListResult.BLGoodsCodeColumn.ColumnName].Width = 80;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/01 DEL
            //Columns[this._dataSet.OrderListResult.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/01 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/01 ADD
            Columns[this._dataSet.OrderListResult.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/01 ADD
            Columns[this._dataSet.OrderListResult.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/01 ADD
            Columns[this._dataSet.OrderListResult.BLGoodsCodeColumn.ColumnName].Format = GetBLGoodsCodeFormat();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/01 ADD

            // 担当者
            Columns[this._dataSet.OrderListResult.StockInputNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OrderListResult.StockInputNameColumn.ColumnName].Header.Caption = "担当者";
            Columns[this._dataSet.OrderListResult.StockInputNameColumn.ColumnName].Width = 70;
            Columns[this._dataSet.OrderListResult.StockInputNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.OrderListResult.StockInputNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 発注者
            Columns[this._dataSet.OrderListResult.StockAgentNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OrderListResult.StockAgentNameColumn.ColumnName].Header.Caption = "発注者";
            Columns[this._dataSet.OrderListResult.StockAgentNameColumn.ColumnName].Width = 70;
            Columns[this._dataSet.OrderListResult.StockAgentNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.OrderListResult.StockAgentNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 標準価格
            Columns[this._dataSet.OrderListResult.ListPriceTaxExcFlColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OrderListResult.ListPriceTaxExcFlColumn.ColumnName].Header.Caption = "標準価格";
            Columns[this._dataSet.OrderListResult.ListPriceTaxExcFlColumn.ColumnName].Width = 80;
            Columns[this._dataSet.OrderListResult.ListPriceTaxExcFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.OrderListResult.ListPriceTaxExcFlColumn.ColumnName].Format = decimalFormat;
            Columns[this._dataSet.OrderListResult.ListPriceTaxExcFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 発注数
            Columns[this._dataSet.OrderListResult.OrderCntColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OrderListResult.OrderCntColumn.ColumnName].Header.Caption = "発注数";
            Columns[this._dataSet.OrderListResult.OrderCntColumn.ColumnName].Width = 50;
            Columns[this._dataSet.OrderListResult.OrderCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.OrderListResult.OrderCntColumn.ColumnName].Format = decimalFormat;
            Columns[this._dataSet.OrderListResult.OrderCntColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 発注残数
            Columns[this._dataSet.OrderListResult.OrderRemainCntColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OrderListResult.OrderRemainCntColumn.ColumnName].Header.Caption = "発注残数";
            Columns[this._dataSet.OrderListResult.OrderRemainCntColumn.ColumnName].Width = 50;
            Columns[this._dataSet.OrderListResult.OrderRemainCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.OrderListResult.OrderRemainCntColumn.ColumnName].Format = decimalFormat;
            Columns[this._dataSet.OrderListResult.OrderRemainCntColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 発注単価
            Columns[this._dataSet.OrderListResult.StockUnitPriceFlColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OrderListResult.StockUnitPriceFlColumn.ColumnName].Header.Caption = "発注単価";
            Columns[this._dataSet.OrderListResult.StockUnitPriceFlColumn.ColumnName].Width = 50;
            Columns[this._dataSet.OrderListResult.StockUnitPriceFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.OrderListResult.StockUnitPriceFlColumn.ColumnName].Format = decimalFormat;
            Columns[this._dataSet.OrderListResult.StockUnitPriceFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 発注金額
            Columns[this._dataSet.OrderListResult.StockPriceTaxExcColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OrderListResult.StockPriceTaxExcColumn.ColumnName].Header.Caption = "発注金額";
            Columns[this._dataSet.OrderListResult.StockPriceTaxExcColumn.ColumnName].Width = 80;
            Columns[this._dataSet.OrderListResult.StockPriceTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.OrderListResult.StockPriceTaxExcColumn.ColumnName].Format = moneyFormat;
            Columns[this._dataSet.OrderListResult.StockPriceTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 消費税
            //Columns[this._dataSet.OrderListResult.StockPriceConsTaxColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OrderListResult.StockPriceConsTaxColumn.ColumnName].Hidden = true;
            Columns[this._dataSet.OrderListResult.StockPriceConsTaxColumn.ColumnName].Header.Caption = "消費税";
            Columns[this._dataSet.OrderListResult.StockPriceConsTaxColumn.ColumnName].Width = 75;
            Columns[this._dataSet.OrderListResult.StockPriceConsTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.OrderListResult.StockPriceConsTaxColumn.ColumnName].Format = moneyFormat;
            Columns[this._dataSet.OrderListResult.StockPriceConsTaxColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 倉庫
            Columns[this._dataSet.OrderListResult.WarehouseNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OrderListResult.WarehouseNameColumn.ColumnName].Header.Caption = "倉庫";
            Columns[this._dataSet.OrderListResult.WarehouseNameColumn.ColumnName].Width = 80;
            Columns[this._dataSet.OrderListResult.WarehouseNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.OrderListResult.WarehouseNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 明細備考
            Columns[this._dataSet.OrderListResult.StockDtiSlipNote1Column.ColumnName].Hidden = false;
            Columns[this._dataSet.OrderListResult.StockDtiSlipNote1Column.ColumnName].Header.Caption = "明細備考";
            Columns[this._dataSet.OrderListResult.StockDtiSlipNote1Column.ColumnName].Width = 80;
            Columns[this._dataSet.OrderListResult.StockDtiSlipNote1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.OrderListResult.StockDtiSlipNote1Column.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 入力日
            Columns[this._dataSet.OrderListResult.InputDayColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OrderListResult.InputDayColumn.ColumnName].Header.Caption = "入力日";
            Columns[this._dataSet.OrderListResult.InputDayColumn.ColumnName].Width = 80;
            Columns[this._dataSet.OrderListResult.InputDayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.OrderListResult.InputDayColumn.ColumnName].Format = dateFormat;
            Columns[this._dataSet.OrderListResult.InputDayColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/01 ADD
            Columns[this._dataSet.OrderListResult.InputDayColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/01 ADD

            // 拠点
            Columns[this._dataSet.OrderListResult.SectionGuideNmColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.OrderListResult.SectionGuideNmColumn.ColumnName].Header.Caption = "拠点";
            Columns[this._dataSet.OrderListResult.SectionGuideNmColumn.ColumnName].Width = 80;
            Columns[this._dataSet.OrderListResult.SectionGuideNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.OrderListResult.SectionGuideNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

			//メモ
			Columns[this._dataSet.OrderListResult.MemoExistNameColumn.ColumnName].Hidden = false;
			Columns[this._dataSet.OrderListResult.MemoExistNameColumn.ColumnName].Header.Caption = "メモ";
            Columns[this._dataSet.OrderListResult.MemoExistNameColumn.ColumnName].Width = 60;
			Columns[this._dataSet.OrderListResult.MemoExistNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[this._dataSet.OrderListResult.MemoExistNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //////発注日
            ////Columns[this._dataSet.OrderListResult.OrderFormPrintDateDisplayColumn.ColumnName].Hidden = false;
            ////Columns[this._dataSet.OrderListResult.OrderFormPrintDateDisplayColumn.ColumnName].Header.Caption = "発注日";
            ////Columns[this._dataSet.OrderListResult.OrderFormPrintDateDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            ////Columns[this._dataSet.OrderListResult.OrderFormPrintDateDisplayColumn.ColumnName].Format = dateFormat;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
            
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //////単位
            ////Columns[this._dataSet.OrderListResult.UnitNameColumn.ColumnName].Hidden = false;
            ////Columns[this._dataSet.OrderListResult.UnitNameColumn.ColumnName].Header.Caption = "単位";
            ////Columns[this._dataSet.OrderListResult.UnitNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL

            ////入荷数
            //Columns[this._dataSet.OrderListResult.StockCountColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.OrderListResult.StockCountColumn.ColumnName].Header.Caption = "入荷数";
            //Columns[this._dataSet.OrderListResult.StockCountColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //Columns[this._dataSet.OrderListResult.StockCountColumn.ColumnName].Format = decimalFormat;

            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //////特値
            ////Columns[this._dataSet.OrderListResult.BargainNmColumn.ColumnName].Hidden = false;
            ////Columns[this._dataSet.OrderListResult.BargainNmColumn.ColumnName].Header.Caption = "特売";
            ////Columns[this._dataSet.OrderListResult.BargainNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL

            ////発注書発行日
            //// 2008.11.19 modify start [7968]
            //Columns[this._dataSet.OrderListResult.InputDayColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.OrderListResult.InputDayColumn.ColumnName].Header.Caption = "入力日";
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/01 DEL
            ////Columns[this._dataSet.OrderListResult.OrderDataCreateDateDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/01 DEL
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/01 ADD
            //Columns[this._dataSet.OrderListResult.InputDayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/01 ADD
            //Columns[this._dataSet.OrderListResult.InputDayColumn.ColumnName].Format = dateFormat;
            ////Columns[this._dataSet.OrderListResult.OrderDataCreateDateDisplayColumn.ColumnName].Hidden = false;
            ////Columns[this._dataSet.OrderListResult.OrderDataCreateDateDisplayColumn.ColumnName].Header.Caption = "入力日";
            ////// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/01 DEL
            //////Columns[this._dataSet.OrderListResult.OrderDataCreateDateDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            ////// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/01 DEL
            ////// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/01 ADD
            ////Columns[this._dataSet.OrderListResult.OrderDataCreateDateDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            ////// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/01 ADD
            ////Columns[this._dataSet.OrderListResult.OrderDataCreateDateDisplayColumn.ColumnName].Format = dateFormat;
            //// 2008.11.19 modify end [7968]

            ////発注書番号
            //Columns[this._dataSet.OrderListResult.SupplierSlipNoColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.OrderListResult.SupplierSlipNoColumn.ColumnName].Header.Caption = "発注書番号";
            //Columns[this._dataSet.OrderListResult.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;


            ////仕入希望納期
            //Columns[this._dataSet.OrderListResult.ExpectDeliveryDateDisplayColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.OrderListResult.ExpectDeliveryDateDisplayColumn.ColumnName].Header.Caption = "仕入希望納期";
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/01 DEL
            ////Columns[this._dataSet.OrderListResult.ExpectDeliveryDateDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/01 DEL
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/01 ADD
            //Columns[this._dataSet.OrderListResult.ExpectDeliveryDateDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/01 ADD
            //Columns[this._dataSet.OrderListResult.ExpectDeliveryDateDisplayColumn.ColumnName].Format = dateFormat;

            ////最終入荷日
            //Columns[this._dataSet.OrderListResult.RemainCntUpdDateDisplayColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.OrderListResult.RemainCntUpdDateDisplayColumn.ColumnName].Header.Caption = "最終入荷日";
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/01 DEL
            ////Columns[this._dataSet.OrderListResult.RemainCntUpdDateDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/01 DEL
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/01 ADD
            //Columns[this._dataSet.OrderListResult.RemainCntUpdDateDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/01 ADD
            //Columns[this._dataSet.OrderListResult.RemainCntUpdDateDisplayColumn.ColumnName].Format = dateFormat;

            ////明細摘要
            //Columns[this._dataSet.OrderListResult.StockDtiSlipNote1Column.ColumnName].Hidden = false;
            //Columns[this._dataSet.OrderListResult.StockDtiSlipNote1Column.ColumnName].Header.Caption = "明細摘要";
            //Columns[this._dataSet.OrderListResult.StockDtiSlipNote1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

            ////相手先伝票番号
            //Columns[this._dataSet.OrderListResult.PartySaleSlipNumColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.OrderListResult.PartySaleSlipNumColumn.ColumnName].Header.Caption = "相手先伝票番号";
            //Columns[this._dataSet.OrderListResult.PartySaleSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

            ////担当者
            //Columns[this._dataSet.OrderListResult.StockInputNameColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.OrderListResult.StockInputNameColumn.ColumnName].Header.Caption = "入力者";
            //Columns[this._dataSet.OrderListResult.StockInputNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

            ////仕入回答納期
            //Columns[this._dataSet.OrderListResult.DeliGdsCmpltDueDateDisplayColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.OrderListResult.DeliGdsCmpltDueDateDisplayColumn.ColumnName].Header.Caption = "仕入回答納期";
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/01 DEL
            ////Columns[this._dataSet.OrderListResult.DeliGdsCmpltDueDateDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/01 DEL
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/01 ADD
            //Columns[this._dataSet.OrderListResult.DeliGdsCmpltDueDateDisplayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/01 ADD
            //Columns[this._dataSet.OrderListResult.DeliGdsCmpltDueDateDisplayColumn.ColumnName].Format = dateFormat;
			#endregion

			foreach (ColDisplayStatus colDisplayStatus in this._colDisplayStatusList.GetColDisplayStatusList())
			{
				if (this.uGrid_Details.DisplayLayout.Bands[0].Columns.Exists(colDisplayStatus.Key))
				{
					this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].Width = colDisplayStatus.Width;

                    // ADD 2010/03/11 MANTIS対応[15129]：発注残照会の明細グリッド列位置を記憶 ---------->>>>>
                    // コメント化から復活
					this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].Header.VisiblePosition = colDisplayStatus.VisiblePosition;
                    // ADD 2010/03/11 MANTIS対応[15129]：発注残照会の明細グリッド列位置を記憶 ----------<<<<<

					this.uGrid_Details.DisplayLayout.Bands[0].Columns[colDisplayStatus.Key].Header.Fixed = colDisplayStatus.HeaderFixed;
				}
			}

			// 固定列区切り線設定
            this.uGrid_Details.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
		}
        
		/// <summary>
		/// グリッド行初期設定処理
		/// </summary>
		private void GridRowInitialSetting()
		{
            if (this._orderRemainReferenceAcs.GetStockSlipTableCache() == null)
            {
				this._dataSet.OrderListResult.Rows.Clear();
            }
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

		#region ◆　選択・非選択変更処理

		/// <summary>
		/// 選択・日選択変更処理（反転）
		/// </summary>
		/// <param name="gridRow"></param>
		private void ChangedSelect( Infragistics.Win.UltraWinGrid.UltraGridRow gridRow )
		{
			bool newSelectedValue = !(bool)gridRow.Cells[this._dataSet.OrderListResult.SelectFlagColumn.ColumnName].Value;

			// テーブル更新
			this._orderRemainReferenceAcs.SetRowSelected((int)gridRow.Cells[this._dataSet.OrderListResult.NoColumn.ColumnName].Value, newSelectedValue);

			// 背景色を変更
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
            //ChangedSelectColor(newSelectedValue, gridRow);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            bool newValue = (bool)gridRow.Cells[this._dataSet.OrderListResult.SelectFlagColumn.ColumnName].Value;
            ChangedSelectColor( newValue, gridRow );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
		}

		/// <summary>
		/// 選択・非選択変更処理（背景色のみ）
		/// </summary>
		/// <param name="isSelected"></param>
		/// <param name="gridRow"></param>
		private void ChangedSelectColor( bool isSelected, Infragistics.Win.UltraWinGrid.UltraGridRow gridRow )
		{
			if (gridRow == null) return;

			// 対象行の選択色を設定する
			if (isSelected)
			{
				gridRow.Appearance.BackColor = _selectedBackColor;
				gridRow.Appearance.BackColor2 = _selectedBackColor2;
				gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			}
			else
			{
				if (gridRow.Index % 2 == 1)
				{
					gridRow.Appearance.BackColor = Color.Lavender;
				}
				else
				{
					gridRow.Appearance.BackColor = Color.White;
				}
				gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
			}
		}

		/// <summary>
		/// 選択・非選択変更処理（背景色のみ）
		/// </summary>
		/// <param name="isSelected"></param>
		/// <param name="gridRow"></param>
		private void ChangedSelectColor( bool isSelected, int rowNo )
		{
			OrderRemainDataSet.OrderListResultRow row = this._dataSet.OrderListResult.FindByNo(rowNo);
		}

		/// <summary>
		/// 全ての行の背景色変更
		/// </summary>
		/// <param name="isSelected"></param>
		private void ChangedSelectColorAll( bool isSelected )
		{
			foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in this.uGrid_Details.Rows)
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 DEL
                //ChangedSelectColor(isSelected, row);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
                bool newValue = (bool)row.Cells[this._dataSet.OrderListResult.SelectFlagColumn.ColumnName].Value;
                ChangedSelectColor( newValue, row );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD
			}
		}
		#endregion

		#endregion

        # region ■ Control Events

		/// <summary>
		/// コントロールロードイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void InputDetails_Load( object sender, EventArgs e )
		{
			// グリッド列初期設定処理
			//this.GridInitialSetting(false);

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
            
			}

            // 最上行での↑キー
            if (this.uGrid_Details.ActiveRow.Index == 0)
            {
				if (e.KeyCode == Keys.Up)
				{
					if (this.PrintExtra_Panel.Visible)
					{
						this.Select_Button.Focus();
					}
					else
					{
						if (this.GridKeyDownTopRow != null)
						{
							this.GridKeyDownTopRow(this,new EventArgs());
						}
					}
					// キーが押されたことによるデフォルトのグリッド動作をキャンセルする
					e.Handled = true;
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
#if False
					this.uButton_StockSearch.Focus();
#endif
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
        /// 選択行情報取得タイマー起動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void timer_SelectRow_Tick(object sender, EventArgs e)
        {
			this.timer_SelectRow.Enabled = false;
            if (this.uGrid_Details.ActiveRow != null)
            {
				// 選択 or 解除
				this.ChangedSelect(this.uGrid_Details.ActiveRow);
				if (( this.IsSelect ) && ( !IsMultiSelect ))
				{
					if (this.SetMainDialogResult != null)
					{
						this.SetMainDialogResult(DialogResult.OK);

						if (this.CloseMain != null)
						{
							this.CloseMain();
						}
					}
				}
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
		/// グリッドクリックイベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント引数</param>
		/// <remarks>
		/// <br>Note       : 一覧グリッドがクリックされた際に発生します。</br>
		/// <br>Programmer : 21024　佐々木 健</br>
		/// <br>Date       : 2007.12.19</br>
		/// </remarks>
		private void uGrid_Details_Click(object sender, EventArgs e)
		{
			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

			// マウスポインタがグリッドのどの位置にあるかを判定する
			Point point = System.Windows.Forms.Cursor.Position;
			point = targetGrid.PointToClient(point);

			// UIElementを取得する。
			Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
			if (objUIElement == null)
				return;

			// マウスポインターが列のヘッダ上にあるかチェック。
			Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
			  (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

			if (objHeader != null) return;

			// マウスポインターが行の上にあるかチェック。
			Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
			  (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

			if (objRow != null)
			{
				// マウスポインターが印刷有無セル上にあるか？
				Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
				  (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));
				if (objCell != null)
				{
					// 印刷フラグ列
					if (objCell.Column.Key == _orderRemainReferenceAcs.DataSet.OrderListResult.SelectFlagColumn.ColumnName)
					{
						int uniqueID = (int)objRow.Cells[_orderRemainReferenceAcs.DataSet.OrderListResult.NoColumn.ColumnName].Value;
						this.ChangedSelect(objRow);
					}
				}

			}

		}

		/// <summary>
		/// グリッドクリックイベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント引数</param>
		/// <remarks>
		/// <br>Note       : 一覧グリッドがクリックされた際に発生します。</br>
		/// <br>Programmer : 21024　佐々木 健</br>
		/// <br>Date       : 2008.01.29</br>
		/// </remarks>
		private void uGrid_Details_DoubleClick( object sender, EventArgs e )
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

			if (rowElement == null) return;

			// 要素から行を取得します。
			Infragistics.Win.UltraWinGrid.UltraGridRow objRow = (Infragistics.Win.UltraWinGrid.UltraGridRow)rowElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

			// 行が返されなかった場合、マウスは行の上にありません。
			if (objRow == null)
				return;

			// マウスは行の上にあります。

			// この部分はオプションです。しかし、ユーザーが行セレクタ間の行を
			// ダブルクリックした場合、デフォルトで行のサイズを自動調整します。
			// その場合、通常、ダブルクリックコードは記述しません。

			// 現在のマウスポインタの位置を取得してグリッド座標に変換します。
			Point MousePosition = targetGrid.PointToClient(Control.MousePosition);
			// 座標点が AdjustableElement 上にあるかどうかを調べます。すなわち、
			// ユーザーが行セレクタ上の行をクリックしているかどうか。
			if (lastElementEntered.AdjustableElementFromPoint(MousePosition) != null)
				return;

			if (objRow != null)
			{
				if (( this.IsSelect ) && ( !this.IsMultiSelect ))
				{
					this.ChangedSelect(objRow);
					if (this.SetMainDialogResult != null)
					{
						this.SetMainDialogResult(DialogResult.OK);

						if (this.CloseMain != null)
						{
							this.CloseMain();
						}
					}
				}
			}
		}

		/// <summary>
		/// 選択ボタンクリックイベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント引数</param>
		private void Select_Button_Click( object sender, EventArgs e )
		{
			bool selected = false;

			if (sender == UnSelect_Button)
			{
				selected = false;
			}
			else if (sender == Select_Button)
			{
				selected = true; ;
			}

			// 全ての行を非選択にする
			this._orderRemainReferenceAcs.SetRowSelectedAll(selected);

			// 全ての行の背景色を変更
			ChangedSelectColorAll(selected);
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/01 ADD
        /// <summary>
        /// ＵＩ設定ＸＭＬからのコードフォーマット取得(00,000,0000… etc.)
        /// </summary>
        /// <param name="editName"></param>
        /// <returns></returns>
        private string GetCodeFormat( string editName )
        {
            UiSet uiset;
            int status = uiSetControl1.ReadUISet( out uiset, editName );
            if ( status == 0 )
            {
                return string.Format( "{0};-{0};''", new string( '0', uiset.Column ) );
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 仕入先コードフォーマット取得
        /// </summary>
        /// <returns></returns>
        private string GetSupplierCodeFormat()
        {
            return GetCodeFormat( "tNedit_SupplierCd" );
        }
        /// <summary>
        /// ＢＬコードフォーマット取得
        /// </summary>
        /// <returns></returns>
        private string GetBLGoodsCodeFormat()
        {
            return GetCodeFormat( "tNedit_BLGoodsCode" );
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/01 ADD
		# endregion
	}
}

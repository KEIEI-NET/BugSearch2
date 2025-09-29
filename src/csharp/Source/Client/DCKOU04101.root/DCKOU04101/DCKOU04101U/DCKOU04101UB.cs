//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 仕入履歴照会
// プログラム概要   : 仕入履歴照会を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2009/04/07  修正内容 : 障害対応13077
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/04/09  修正内容 : 障害対応13014
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434 工藤
// 作 成 日  2009/12/04  修正内容 : 障害対応14745
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
	public partial class DCKOU04101UB : UserControl
	{
		#region ■Constructor
		public DCKOU04101UB()
		{
			InitializeComponent();

			this._stcHisRefExtraParamWork = new StcHisRefExtraParamWork();
            this._searchSlipAcs = DCKOU04102AA.GetInstance();
            this._dataSet = this._searchSlipAcs.DataSet;
            this.uGrid_Details.DataSource = this._dataSet.StockSlip;
            this._imageList16 = IconResourceManagement.ImageList16;
            this._stcHisRefDataWork = new List<StcHisRefDataWork>();
		}
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
			get { return this._stcHisRefExtraParamWork.SupplierFormal; }
		}

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
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/16 ADD
        /// <summary>
        /// 最大選択可能行数
        /// </summary>
        public int MaxSelectCount
        {
            get { return _maxSelectCount; }
            set { _maxSelectCount = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/16 ADD

        // ADD 2009/04/09 ------>>>
        /// <summary>
        /// 部門管理区分
        /// </summary>
        public int SecMngDiv
        {
            get { return this._secMngDiv; }
            set { this._secMngDiv = value; }
        }
        // ADD 2009/04/09 ------<<<
        #endregion

		#region ■Private Members
		private DCKOU04102AA _searchSlipAcs;
		private StockDataSet _dataSet;
		private ImageList _imageList16 = null;									// イメージリスト

		private bool _isMultiSelect;
		private bool _isSelect;
		private int _startMovment = 0;											// 起動モード 0:エントリー 1:メニュー
		/// <summary>画面デザイン変更クラス</summary>
		//private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/16 ADD
        // 選択可能行数
        private int _maxSelectCount;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/16 ADD

        private int _secMngDiv;     // ADD 2009/04/09

		#endregion

		#region ■Public Members
		public List<StcHisRefDataWork> _stcHisRefDataWork;
		public StcHisRefExtraParamWork _stcHisRefExtraParamWork;
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


		#region ■Public Methods
		/// <summary>
		/// 画面モード設定
		/// </summary>
		public void DisplayModeSetting()
		{
			// グリッド列初期設定処理
			this.GridColInitialSetting(this.uGrid_Details.DisplayLayout.Bands[0].Columns);

			// 複数選択モードの場合のみ「全て選択」を表示する
			this.PrintExtra_Panel.Visible = this._isMultiSelect;
		}
		#endregion

		private void InputDetails_Load(object sender, EventArgs e)
		{
			// グリッド行初期設定処理
			this.GridRowInitialSetting();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/16 ADD
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
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/16 ADD
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
        /// <summary>
        /// データ選択状態変更イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="status"></param>
        /// <param name="count"></param>
        public void SearchSlipAcs_SelectedDataChange( object sender, bool status, int count )
        {
            // 明細選択可能数の表示
            lb_SelectedCount.Text = count.ToString( "#,##0" );

            // エラーメッセージ表示
            if ( status == false )
            {
                this.StatusBarMessageSetting( this, "選択可能数を超えています。" );
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD

		/// <summary>
		/// グリッド列初期設定処理
		/// </summary>
		private void GridColInitialSetting(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns)
		{
			int visiblePosition = 1;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/05 DEL
            //string _moneyFormat = "#,##0;-#,##0;";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/05 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/05 ADD
            string _moneyFormat = "#,##0;-#,##0;''";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/05 ADD

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/05 DEL
            //string _unitPriceFormat = "#,##0.00";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/05 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/05 ADD
            string _unitPriceFormat = "#,##0.00;-#,##0.00;''";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/05 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //string _cntFormat = "0.00";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
			string _dateFormat = "yyyy/MM/dd";

			// 一旦、全ての列を非表示にする。
			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
			{
				//非表示設定
				column.Hidden = true;
				//入力許可設定
				//column.AutoEdit = false;

				column.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;

			}

			//--------------------------------------------------------------------------------
			//  表示するカラム情報
			//--------------------------------------------------------------------------------
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/16 DEL
            //// 印刷フラグ
            //if (IsMultiSelect == true)
            //{
            //    Columns[this._dataSet.StockSlip.PrintFlagColumn.ColumnName].Header.Fixed = true;			// 固定項目
            //    Columns[this._dataSet.StockSlip.PrintFlagColumn.ColumnName].Hidden = false;
            //    Columns[this._dataSet.StockSlip.PrintFlagColumn.ColumnName].Header.Caption = "";
            //    Columns[this._dataSet.StockSlip.PrintFlagColumn.ColumnName].Width = 10;
            //    Columns[this._dataSet.StockSlip.PrintFlagColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            //    Columns[this._dataSet.StockSlip.PrintFlagColumn.ColumnName].AutoEdit = true;
            //    Columns[this._dataSet.StockSlip.PrintFlagColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //}
            //else
            //{
            //    Columns[this._dataSet.StockSlip.PrintFlagColumn.ColumnName].Hidden = true;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/16 DEL

			// No.
			Columns[this._dataSet.StockSlip.NoColumn.ColumnName].Header.Fixed = true;			// 固定項目
			Columns[this._dataSet.StockSlip.NoColumn.ColumnName].Hidden = false;
			Columns[this._dataSet.StockSlip.NoColumn.ColumnName].Header.Caption = "No.";
			Columns[this._dataSet.StockSlip.NoColumn.ColumnName].Width = 35;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //Columns[this._dataSet.StockSlip.NoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.NoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
			Columns[this._dataSet.StockSlip.NoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.NoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._dataSet.StockSlip.NoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[this._dataSet.StockSlip.NoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[this._dataSet.StockSlip.NoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._dataSet.StockSlip.NoColumn.ColumnName].CellAppearance.ForeColor = Color.White;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/16 ADD
            // 印刷フラグ
            if ( IsMultiSelect == true )
            {
                Columns[this._dataSet.StockSlip.PrintFlagColumn.ColumnName].Header.Fixed = true;			// 固定項目
                Columns[this._dataSet.StockSlip.PrintFlagColumn.ColumnName].Hidden = false;
                Columns[this._dataSet.StockSlip.PrintFlagColumn.ColumnName].Header.Caption = "選択";
                Columns[this._dataSet.StockSlip.PrintFlagColumn.ColumnName].Width = 25;
                Columns[this._dataSet.StockSlip.PrintFlagColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                Columns[this._dataSet.StockSlip.PrintFlagColumn.ColumnName].AutoEdit = true;
                Columns[this._dataSet.StockSlip.PrintFlagColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            }
            else
            {
                Columns[this._dataSet.StockSlip.PrintFlagColumn.ColumnName].Hidden = true;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/16 ADD

            // 仕入日
            //if (SupplierFormal != 1)
            //{
            Columns[this._dataSet.StockSlip.StockDateStringColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.StockSlip.StockDateStringColumn.ColumnName].Header.Caption = "仕入日";
            Columns[this._dataSet.StockSlip.StockDateStringColumn.ColumnName].Width = 90;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            Columns[this._dataSet.StockSlip.StockDateStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.StockDateStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.StockDateStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.StockSlip.StockDateStringColumn.ColumnName].Format = _dateFormat;
            //}

            // 伝票番号
            Columns[this._dataSet.StockSlip.PartySaleSlipNumColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.StockSlip.PartySaleSlipNumColumn.ColumnName].Header.Caption = "伝票番号";
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DLL
            //Columns[this._dataSet.StockSlip.PartySaleSlipNumColumn.ColumnName].Width = 110;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.PartySaleSlipNumColumn.ColumnName].Width = 200;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.PartySaleSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.StockSlip.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 行番号
            Columns[this._dataSet.StockSlip.StockRowNoColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.StockSlip.StockRowNoColumn.ColumnName].Header.Caption = "行番号";
            Columns[this._dataSet.StockSlip.StockRowNoColumn.ColumnName].Width = 90;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //Columns[this._dataSet.StockSlip.StockRowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.StockRowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.StockRowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 伝票種別
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.29 TOKUNAGA ADD START
            Columns[this._dataSet.StockSlip.SupplierFormalNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.StockSlip.SupplierFormalNameColumn.ColumnName].Header.Caption = "伝票種別";
            Columns[this._dataSet.StockSlip.SupplierFormalNameColumn.ColumnName].Width = 70;
            Columns[this._dataSet.StockSlip.SupplierFormalNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.StockSlip.SupplierFormalNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.29 TOKUNAGA ADD END

            // "伝票区分
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.29 TOKUNAGA MODIFY START
            Columns[this._dataSet.StockSlip.SupplierSlipCdNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.StockSlip.SupplierSlipCdNameColumn.ColumnName].Header.Caption = "伝票区分"; // 2009.01.07 modify [9811]
            Columns[this._dataSet.StockSlip.SupplierSlipCdNameColumn.ColumnName].Width = 110;
            Columns[this._dataSet.StockSlip.SupplierSlipCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.StockSlip.SupplierSlipCdNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 品番
            Columns[this._dataSet.StockSlip.GoodsNoColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.StockSlip.GoodsNoColumn.ColumnName].Header.Caption = "品番";
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //Columns[this._dataSet.StockSlip.GoodsNoColumn.ColumnName].Width = 100;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.GoodsNoColumn.ColumnName].Width = 200;            
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.StockSlip.GoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 品名
            Columns[this._dataSet.StockSlip.GoodsNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.StockSlip.GoodsNameColumn.ColumnName].Header.Caption = "品名";
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //Columns[this._dataSet.StockSlip.GoodsNameColumn.ColumnName].Width = 100;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.GoodsNameColumn.ColumnName].Width = 200;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.StockSlip.GoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // メーカー
            Columns[this._dataSet.StockSlip.MakerNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.StockSlip.MakerNameColumn.ColumnName].Header.Caption = "メーカー名";
            Columns[this._dataSet.StockSlip.MakerNameColumn.ColumnName].Width = 100;
            Columns[this._dataSet.StockSlip.MakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.StockSlip.MakerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.29 TOKUNAGA MODIFY END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.29 TOKUNAGA ADD START
            // 仕入先コード
            Columns[this._dataSet.StockSlip.SupplierCdColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.StockSlip.SupplierCdColumn.ColumnName].Header.Caption = "仕入先コード";
            Columns[this._dataSet.StockSlip.SupplierCdColumn.ColumnName].Width = 80;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //Columns[this._dataSet.StockSlip.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.SupplierCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.29 TOKUNAGA ADD END
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.SupplierCdColumn.ColumnName].Format = GetSupplierCodeFormat();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.29 TOKUNAGA MODIFY START
            // 仕入先名
            Columns[this._dataSet.StockSlip.SupplierSnmColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.StockSlip.SupplierSnmColumn.ColumnName].Header.Caption = "仕入先名";
            Columns[this._dataSet.StockSlip.SupplierSnmColumn.ColumnName].Width = 100;
            Columns[this._dataSet.StockSlip.SupplierSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.StockSlip.SupplierSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.29 TOKUNAGA MODIFY END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.29 TOKUNAGA ADD START
            // BLコード
            Columns[this._dataSet.StockSlip.BLGoodsCodeColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.StockSlip.BLGoodsCodeColumn.ColumnName].Header.Caption = "BLコード";
            Columns[this._dataSet.StockSlip.BLGoodsCodeColumn.ColumnName].Width = 80;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //Columns[this._dataSet.StockSlip.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.29 TOKUNAGA ADD END
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.BLGoodsCodeColumn.ColumnName].Format = GetBLGoodsCodeFormat();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD

            // 担当者
            Columns[this._dataSet.StockSlip.StockAgentNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.StockSlip.StockAgentNameColumn.ColumnName].Header.Caption = "担当者";
            Columns[this._dataSet.StockSlip.StockAgentNameColumn.ColumnName].Width = 100;
            Columns[this._dataSet.StockSlip.StockAgentNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.StockSlip.StockAgentNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 標準価格
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.29 TOKUNAGA ADD START
            Columns[this._dataSet.StockSlip.ListPriceTaxExcFlColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.StockSlip.ListPriceTaxExcFlColumn.ColumnName].Header.Caption = "標準価格";
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //Columns[this._dataSet.StockSlip.ListPriceTaxExcFlColumn.ColumnName].Width = 90;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.ListPriceTaxExcFlColumn.ColumnName].Width = 120;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.ListPriceTaxExcFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.StockSlip.ListPriceTaxExcFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //Columns[this._dataSet.StockSlip.ListPriceTaxExcFlColumn.ColumnName].Format = _cntFormat;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.ListPriceTaxExcFlColumn.ColumnName].Format = _moneyFormat;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.29 TOKUNAGA ADD END

            // 仕入数
            //if (SupplierFormal == 1)
            //{
            Columns[this._dataSet.StockSlip.StockCountColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.StockSlip.StockCountColumn.ColumnName].Header.Caption = "仕入数";
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //Columns[this._dataSet.StockSlip.StockCountColumn.ColumnName].Width = 60;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.StockCountColumn.ColumnName].Width = 120;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.StockCountColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.StockSlip.StockCountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.29 TOKUNAGA ADD START
            //Columns[this._dataSet.StockSlip.StockCountColumn.ColumnName].Format = _cntFormat;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.29 TOKUNAGA ADD END            
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.StockCountColumn.ColumnName].Format = _unitPriceFormat;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
            //}

            // 原単価
            Columns[this._dataSet.StockSlip.StockUnitPriceFlColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.StockSlip.StockUnitPriceFlColumn.ColumnName].Header.Caption = "原単価"; // 2009.01.07 modify [9811]
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //Columns[this._dataSet.StockSlip.StockUnitPriceFlColumn.ColumnName].Width = 80;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.StockUnitPriceFlColumn.ColumnName].Width = 120;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.StockUnitPriceFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.StockSlip.StockUnitPriceFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.StockSlip.StockUnitPriceFlColumn.ColumnName].Format = _unitPriceFormat;

            // 仕入金額
            Columns[this._dataSet.StockSlip.StockPriceTaxExcColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.StockSlip.StockPriceTaxExcColumn.ColumnName].Header.Caption = "仕入金額";
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //Columns[this._dataSet.StockSlip.StockPriceTaxExcColumn.ColumnName].Width = 80;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.StockPriceTaxExcColumn.ColumnName].Width = 120;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.StockPriceTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.StockSlip.StockPriceTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.StockSlip.StockPriceTaxExcColumn.ColumnName].Format = _moneyFormat;

            // 消費税
            Columns[this._dataSet.StockSlip.StockPriceConsTaxColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.StockSlip.StockPriceConsTaxColumn.ColumnName].Header.Caption = "消費税";
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //Columns[this._dataSet.StockSlip.StockPriceConsTaxColumn.ColumnName].Width = 80;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.StockPriceConsTaxColumn.ColumnName].Width = 120;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.StockPriceConsTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.StockSlip.StockPriceConsTaxColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.StockSlip.StockPriceConsTaxColumn.ColumnName].Format = _moneyFormat;

            // 倉庫名
            Columns[this._dataSet.StockSlip.WarehouseNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.StockSlip.WarehouseNameColumn.ColumnName].Header.Caption = "倉庫名";
            Columns[this._dataSet.StockSlip.WarehouseNameColumn.ColumnName].Width = 100;
            Columns[this._dataSet.StockSlip.WarehouseNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.StockSlip.WarehouseNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 明細備考
            Columns[this._dataSet.StockSlip.StockDtiSlipNote1Column.ColumnName].Hidden = false;
            Columns[this._dataSet.StockSlip.StockDtiSlipNote1Column.ColumnName].Header.Caption = "明細備考";
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //Columns[this._dataSet.StockSlip.StockDtiSlipNote1Column.ColumnName].Width = 100;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.StockDtiSlipNote1Column.ColumnName].Width = 200;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.StockDtiSlipNote1Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.StockSlip.StockDtiSlipNote1Column.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 赤黒
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.29 TOKUNAGA ADD START
            Columns[this._dataSet.StockSlip.DebitNoteDivNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.StockSlip.DebitNoteDivNameColumn.ColumnName].Header.Caption = "赤黒";
            Columns[this._dataSet.StockSlip.DebitNoteDivNameColumn.ColumnName].Width = 60;
            Columns[this._dataSet.StockSlip.DebitNoteDivNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.StockSlip.DebitNoteDivNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 2009.01.07 modify [9811]

            //// 商品区分
            //Columns[this._dataSet.StockSlip.StockGoodsCdNameColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.StockSlip.StockGoodsCdNameColumn.ColumnName].Header.Caption = "商品区分";
            //Columns[this._dataSet.StockSlip.StockGoodsCdNameColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.StockSlip.StockGoodsCdNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._dataSet.StockSlip.StockGoodsCdNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 入力日
            Columns[this._dataSet.StockSlip.InputDayColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.StockSlip.InputDayColumn.ColumnName].Header.Caption = "入力日";
            Columns[this._dataSet.StockSlip.InputDayColumn.ColumnName].Width = 90;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //Columns[this._dataSet.StockSlip.InputDayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.InputDayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.InputDayColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.StockSlip.InputDayColumn.ColumnName].Format = _dateFormat;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.29 TOKUNAGA ADD END

            // 入荷日
            Columns[this._dataSet.StockSlip.ArrivalGoodsDayStringColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.StockSlip.ArrivalGoodsDayStringColumn.ColumnName].Header.Caption = "入荷日";
            Columns[this._dataSet.StockSlip.ArrivalGoodsDayStringColumn.ColumnName].Width = 90;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //Columns[this._dataSet.StockSlip.ArrivalGoodsDayStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.ArrivalGoodsDayStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.ArrivalGoodsDayStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.StockSlip.ArrivalGoodsDayStringColumn.ColumnName].Format = _dateFormat;

            // 計上日
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.29 TOKUNAGA ADD START
            Columns[this._dataSet.StockSlip.StockAddUpADateColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.StockSlip.StockAddUpADateColumn.ColumnName].Header.Caption = "計上日";
            Columns[this._dataSet.StockSlip.StockAddUpADateColumn.ColumnName].Width = 90;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //Columns[this._dataSet.StockSlip.StockAddUpADateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.StockAddUpADateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.StockAddUpADateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.StockSlip.StockAddUpADateColumn.ColumnName].Format = _dateFormat;

            // 仕入SEQ番号
            Columns[this._dataSet.StockSlip.SupplierSlipNoColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.StockSlip.SupplierSlipNoColumn.ColumnName].Header.Caption = "仕入SEQ番号";
            Columns[this._dataSet.StockSlip.SupplierSlipNoColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //Columns[this._dataSet.StockSlip.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.SupplierSlipNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.SupplierSlipNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.29 TOKUNAGA ADD END
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.SupplierSlipNoColumn.ColumnName].Format = GetSlipNoFormat();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.29 TOKUNAGA DEL START
            //発注番号
            //Columns[this._dataSet.StockSlip.OrderNumberColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.StockSlip.OrderNumberColumn.ColumnName].Header.Caption = "発注番号";
            //Columns[this._dataSet.StockSlip.OrderNumberColumn.ColumnName].Width = 110;
            //Columns[this._dataSet.StockSlip.OrderNumberColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._dataSet.StockSlip.OrderNumberColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.29 TOKUNAGA DEL END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.29 TOKUNAGA ADD START
            // 拠点名
            Columns[this._dataSet.StockSlip.SectionGuideNmColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.StockSlip.SectionGuideNmColumn.ColumnName].Header.Caption = "拠点名";
            Columns[this._dataSet.StockSlip.SectionGuideNmColumn.ColumnName].Width = 100;
            Columns[this._dataSet.StockSlip.SectionGuideNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.StockSlip.SectionGuideNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ADD 2009/04/09 ------>>>
            if (this._secMngDiv != 0)
            {
                //部門名
                Columns[this._dataSet.StockSlip.SubSectionNameColumn.ColumnName].Hidden = false;
                Columns[this._dataSet.StockSlip.SubSectionNameColumn.ColumnName].Header.Caption = "部門名";
                Columns[this._dataSet.StockSlip.SubSectionNameColumn.ColumnName].Width = 100;
                Columns[this._dataSet.StockSlip.SectionGuideNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                Columns[this._dataSet.StockSlip.SubSectionNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            }
            // ADD 2009/04/09 ------<<<
            
            // 支払先コード
            Columns[this._dataSet.StockSlip.PayeeCodeColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.StockSlip.PayeeCodeColumn.ColumnName].Header.Caption = "支払先コード";
            Columns[this._dataSet.StockSlip.PayeeCodeColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 DEL
            //Columns[this._dataSet.StockSlip.PayeeCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.PayeeCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.PayeeCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
            Columns[this._dataSet.StockSlip.PayeeCodeColumn.ColumnName].Format = GetSupplierCodeFormat();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD

            // 支払先名
            Columns[this._dataSet.StockSlip.PayeeSnmColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.StockSlip.PayeeSnmColumn.ColumnName].Header.Caption = "支払先名";
            Columns[this._dataSet.StockSlip.PayeeSnmColumn.ColumnName].Width = 120;
            Columns[this._dataSet.StockSlip.PayeeSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.StockSlip.PayeeSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.29 TOKUNAGA ADD END

			//メモ
			Columns[this._dataSet.StockSlip.MemoExistNameColumn.ColumnName].Hidden = false;
			Columns[this._dataSet.StockSlip.MemoExistNameColumn.ColumnName].Header.Caption = "メモ";
			Columns[this._dataSet.StockSlip.MemoExistNameColumn.ColumnName].Width = 70;
			Columns[this._dataSet.StockSlip.MemoExistNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			Columns[this._dataSet.StockSlip.MemoExistNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;



			//伝票種別：仕入の時、「仕入数」
            //if (SupplierFormal == 0)
            //{
            //Columns[this._dataSet.StockSlip.StockCountColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.StockSlip.StockCountColumn.ColumnName].Header.Caption = "仕入数";
            //Columns[this._dataSet.StockSlip.StockCountColumn.ColumnName].Width = 90;
            //Columns[this._dataSet.StockSlip.StockCountColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //Columns[this._dataSet.StockSlip.StockCountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //Columns[this._dataSet.StockSlip.StockCountColumn.ColumnName].Format = _cntFormat;
            //}
			//伝票種別：入荷の時、「発注数量」
            //else
            //{
            //    Columns[this._dataSet.StockSlip.OrderCntDspColumn.ColumnName].Hidden = false;
            //    Columns[this._dataSet.StockSlip.OrderCntDspColumn.ColumnName].Header.Caption = "入荷数";
            //    Columns[this._dataSet.StockSlip.OrderCntDspColumn.ColumnName].Width = 90;
            //    Columns[this._dataSet.StockSlip.OrderCntDspColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //    Columns[this._dataSet.StockSlip.OrderCntDspColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //    Columns[this._dataSet.StockSlip.OrderCntDspColumn.ColumnName].Format = _cntFormat;
            //}

			//仕入計上残数 入荷の時のみ表示
            //if (SupplierFormal == 1)
            //{
            //    Columns[this._dataSet.StockSlip.OrderRemainCntColumn.ColumnName].Hidden = false;
            //    Columns[this._dataSet.StockSlip.OrderRemainCntColumn.ColumnName].Header.Caption = "仕入計上残数";
            //    Columns[this._dataSet.StockSlip.OrderRemainCntColumn.ColumnName].Width = 100;
            //    Columns[this._dataSet.StockSlip.OrderRemainCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //    Columns[this._dataSet.StockSlip.OrderRemainCntColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //    Columns[this._dataSet.StockSlip.OrderRemainCntColumn.ColumnName].Format = _cntFormat;
            //}

			//単位
            //Columns[this._dataSet.StockSlip.UnitNameColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.StockSlip.UnitNameColumn.ColumnName].Header.Caption = "単位";
            //Columns[this._dataSet.StockSlip.UnitNameColumn.ColumnName].Width = 70;
            //Columns[this._dataSet.StockSlip.UnitNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._dataSet.StockSlip.UnitNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
			

			

			
			//定価
            //Columns[this._dataSet.StockSlip.ListPriceFlColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.StockSlip.ListPriceFlColumn.ColumnName].Header.Caption = "定価";
            //Columns[this._dataSet.StockSlip.ListPriceFlColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.StockSlip.ListPriceFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            //Columns[this._dataSet.StockSlip.ListPriceFlColumn.ColumnName].Format = _moneyFormat;
            //Columns[this._dataSet.StockSlip.ListPriceFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

			//得意先
            //Columns[this._dataSet.StockSlip.SalesCustomerSnmColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.StockSlip.SalesCustomerSnmColumn.ColumnName].Header.Caption = "得意先";
            //Columns[this._dataSet.StockSlip.SalesCustomerSnmColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.StockSlip.SalesCustomerSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._dataSet.StockSlip.SalesCustomerSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
	
			
			//相手先伝票番号
            //Columns[this._dataSet.StockSlip.PartySaleSlipNumColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.StockSlip.PartySaleSlipNumColumn.ColumnName].Header.Caption = "相手伝票番号";
            //Columns[this._dataSet.StockSlip.PartySaleSlipNumColumn.ColumnName].Width = 130;
            //Columns[this._dataSet.StockSlip.PartySaleSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._dataSet.StockSlip.PartySaleSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
			
			
			//入力者
            //Columns[this._dataSet.StockSlip.StockInputNameColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.StockSlip.StockInputNameColumn.ColumnName].Header.Caption = "入力者";
            //Columns[this._dataSet.StockSlip.StockInputNameColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.StockSlip.StockInputNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._dataSet.StockSlip.StockInputNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

			// 固定列区切り線設定
            this.uGrid_Details.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
#if False
			// Style設定
            Columns[this._dataSet.StockSlip.InputDayColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
#endif


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
		}

		/// <summary>
		/// 選択伝票情報設定
		/// </summary>
        public bool ReturnSelectData()
        {
			if (IsMultiSelect == true)
			{
				if (this._searchSlipAcs.GetSelectedRowCount() == 0)
				{
					this.StatusBarMessageSetting(this, "伝票が選択されていません。");
					return false;
				}
			}
			else
			{
				if ((uGrid_Details.ActiveRow == null) ||
					(uGrid_Details.ActiveRow.Index < 0) ||
					(uGrid_Details.ActiveRow.Selected == false))
				{
					this.StatusBarMessageSetting(this, "伝票が選択されていません。");
					return false;
				}
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
            //this.DecisionButtonEnableSet(false);
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
                //e.Handled = true;
            
                // 選択行決定
				//this.SelectRow();


				//Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
				//  (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));
				//if (objCell != null)
				//{
					// 印刷フラグ列
					//if (objCell.Column.Key == _searchSlipAcs.DataSet.StockSlip.PrintFlagColumn.ColumnName)
					//{
						//int uniqueID = (int)objRow.Cells[_searchSlipAcs.DataSet.StockSlip.NoColumn.ColumnName].Value;

						int uniqueID = (int)(this.uGrid_Details.ActiveRow.Cells[_searchSlipAcs.DataSet.StockSlip.NoColumn.ColumnName].Value);
						this._searchSlipAcs.SelectedPrintRow(uniqueID);
					//}
				//}


			}

            // 最上行での↑キー
            if (this.uGrid_Details.ActiveRow.Index == 0)
            {
                if (e.KeyCode == Keys.Up)
                {
                    // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                    e.Handled = true;
#if False
					this.uButton_StockSearch.Focus();
#endif
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
				int uniqueID = (int)(this.uGrid_Details.ActiveRow.Cells[_searchSlipAcs.DataSet.StockSlip.NoColumn.ColumnName].Value);
				this._searchSlipAcs.SelectedPrintRow(uniqueID);
				
				// 選択行のインデックスを取得
				//CurrencyManager cm = (CurrencyManager)BindingContext[this.uGrid_Details.DataSource];
				//int index = cm.Position;

				//this._stcHisRefDataWork = this._searchSlipAcs.GetSelectedRowData(index);
                //this.SetMainDialogResult(DialogResult.OK);
                //this.CloseMain();
            }
        }

		public void SelectRow()
		{
			if (StartMovment == 1) return;

			if (this.uGrid_Details.ActiveRow != null)
			{
				CurrencyManager cm = (CurrencyManager)BindingContext[this.uGrid_Details.DataSource];
				int index = cm.Position;

				if (IsMultiSelect == true)
				{
					this._stcHisRefDataWork = this._searchSlipAcs.GetSelectedRowData();
				}
				else
				{
					this._stcHisRefDataWork = this._searchSlipAcs.GetSelectedRowData(index);
				}
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

        # endregion

		/// <summary>
		/// グリッドクリックイベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント引数</param>
		/// <remarks>
		/// <br>Note       : 一覧グリッドがクリックされた際に発生します。</br>
		/// <br>Programmer : 980023 飯谷 耕平</br>
		/// <br>Date       : 2007.06.30</br>
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
				//          int uniqueID = (int)objRow.Cells[DemandPrintAcs.CT_CsDmd_UniqueID].Value;
				//          this.mDemandPrintAcs.SelectedPrintRow(uniqueID);
				// マウスポインターが印刷有無セル上にあるか？
				Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
				  (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));
				if (objCell != null)
				{
					// 印刷フラグ列
					if (objCell.Column.Key == _searchSlipAcs.DataSet.StockSlip.PrintFlagColumn.ColumnName)
					{
						int uniqueID = (int)objRow.Cells[_searchSlipAcs.DataSet.StockSlip.NoColumn.ColumnName].Value;
						this._searchSlipAcs.SelectedPrintRow(uniqueID);
					}
				}

			}

		}

		private void Select_Button_Click(object sender, EventArgs e)
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

			// フィルター除外行を取得      
			Infragistics.Win.UltraWinGrid.UltraGridRow[] _rows =
				this.uGrid_Details.Rows.GetFilteredInNonGroupByRows();

			// 表示行は存在するか？
			foreach (Infragistics.Win.UltraWinGrid.UltraGridRow _row in _rows)
			{
				int uniqueID = (int)_row.Cells[_searchSlipAcs.DataSet.StockSlip.NoColumn.ColumnName].Value;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 DEL
                //this._searchSlipAcs.SelectedPrintRow(uniqueID, selected);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
                bool result = this._searchSlipAcs.SelectedPrintRow( uniqueID, selected );
                // エラーの行があれば、そこで終了
                if ( result == false ) break;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD
			}

		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/15 ADD
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
        /// 伝票番号フォーマット取得
        /// </summary>
        /// <returns></returns>
        private string GetSlipNoFormat()
        {
            return GetCodeFormat( "tNedit_SupplierSlipNo" );
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
        /// 得意先コードフォーマット取得
        /// </summary>
        /// <returns></returns>
        private string GetCustomerCodeFormat()
        {
            return GetCodeFormat( "tNedit_CustomerCode" );
        }
        /// <summary>
        /// ＢＬコードフォーマット取得
        /// </summary>
        /// <returns></returns>
        private string GetBLGoodsCodeFormat()
        {
            return GetCodeFormat( "tNedit_BLGoodsCode" );
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/15 ADD
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
        // ADD 2009/12/04 MANTIS対応[14745]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
        /// <summary>
        /// 明細情報グリッドを取得します。
        /// </summary>
        public Infragistics.Win.UltraWinGrid.UltraGrid DetailGrid
        {
            get { return this.uGrid_Details; }
        }
        // ADD 2009/12/04 MANTIS対応[14745]：伝票および明細グリッド列の列設定の変更 ----------<<<<<
	}
}

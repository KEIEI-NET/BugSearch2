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
    /// 発注残照会 明細ＵＩクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 伝票検索を行います。</br>
    /// <br>Programmer	: 22018　鈴木 正臣</br>
    /// <br>Date		: 2007.10.15</br>
    /// </remarks>
    public partial class DCJUT04110UB : UserControl
    {
        /// <summary>照会アクセスクラス</summary>
        private AcptAnOdrRemainRefAcs _acptAnOdrRemainRefAcs;
        /// <summary>イメージリスト</summary>
        private ImageList _imageList16 = null;									// イメージリスト

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        /// <summary>選択行カラー(グラデーションcolor1)</summary>
        private readonly Color _selectedBackColor = Color.FromArgb( 216, 235, 253 );
        /// <summary>選択行カラー(グラデーションcolor2)</summary>
        private readonly Color _selectedBackColor2 = Color.FromArgb( 101, 144, 218 );

        /// <summary>選択可能最大行</summary>
        private int _maxSelectCount;
        /// <summary>現在選択済件数</summary>
        private int _selectedCount;

        private const int INP_AGT_DISP = 0;         // 0:する
        private const int INP_AGT_NODISP = 1;       // 1:しない
        private const int INP_AGT_NESSESALY = 2;    // 2:必須

        # region ■ プロパティ ■
        /// <summary>
        /// 選択可能最大行　プロパティ
        /// </summary>
        public int MaxSelectCount
        {
            get { return _maxSelectCount; }
            set { _maxSelectCount = value; }
        }
        # endregion ■ プロパティ ■

        #region ■ イベント ■
        internal event SettingStatusBarMessageEventHandler StatusBarMessageSetting;
        internal delegate void SettingStatusBarMessageEventHandler(object sender, string message);

        //internal event CloseMainEventHandler CloseMain;
        //internal delegate void CloseMainEventHandler();

        //internal event SetDialogResEventHandler SetMainDialogResult;
        //internal delegate void SetDialogResEventHandler( DialogResult dialogRes );
        #endregion ■ イベント ■

        # region ■ コンストラクタ ■
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DCJUT04110UB ( AcptAnOdrRemainRefAcs acptAnOdrRemainRefAcs )
        {
            InitializeComponent();

            // アクセスクラスインスタンスはメインＵＩから受け取る
            this._acptAnOdrRemainRefAcs = acptAnOdrRemainRefAcs;
            this._acptAnOdrRemainRefAcs.SelectedDataChange += new EventHandler( AcptAnOdrRemainRefAcs_SelectedDataChange ); // データ変更イベント

            this.uGrid_Details.DataSource = this._acptAnOdrRemainRefAcs.GetDataViewForDisplay();

            this._imageList16 = IconResourceManagement.ImageList16;

            // 選択済み行数初期化
            this._selectedCount = 0;
            // 選択可能行数初期化
            this._maxSelectCount = 0;
        }
        /// <summary>
        /// アクセスクラス　選択データ変更イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AcptAnOdrRemainRefAcs_SelectedDataChange ( object sender, EventArgs e )
        {
            // 選択済み行数取得
            _selectedCount = this._acptAnOdrRemainRefAcs.GetRowCountOfSelected();

            // 件数表示
            this.lb_SelectedCount.Text = _selectedCount.ToString( "#,###" );
        }
        # endregion ■ コンストラクタ ■

        # region ■ コントロールイベント ■
        /// <summary>
        /// コントロールロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DCHAT04101UB_Load ( object sender, EventArgs e )
		{
			// グリッド行初期設定処理
			this.GridRowInitialSetting();

            // 最大選択行数の表示
            this.lb_MaxSelectCount.Text = this._maxSelectCount.ToString( "#,##0" );
        }
        # endregion ■ コントロールイベント ■

        /// <summary>
		/// 画面モード設定
		/// </summary>
		/// <param name="select">true:選択、false:選択非表示</param>
        /// <param name="inpAgentDispDiv">発行者表示区分</param>
		public void DisplayModeSetting( bool select, int inpAgentDispDiv )
		{
			// グリッドの表示を再設定
            this.GridInitialSetting(select, inpAgentDispDiv);

			// 選択モードの場合のみ「全て選択」「全て解除」を表示する
			this.PrintExtra_Panel.Visible = select;
        }

        # region ■ グリッド列初期化 ■
        /// <summary>
		/// グリッド列初期設定処理
		/// </summary>
		private void GridInitialSetting(bool select, int InpAgentDispDiv)
		{
            string moneyFormat = "#,##0;-#,##0;''";
            string decimalFormat = "#,##0.00;-#,##0.00;''";
            string dateFormat = "yyyy/MM/dd";
            //string codeFormat5 = "00000";
            //string codeFormat6 = "000000";
            //string codeFormat8 = "00000000";
            //string codeFormat9 = "000000000";


			Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

			// 一旦、全ての列を非表示にする。
			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
			{
				//非表示設定
				column.Hidden = true;
				//入力許可設定
				column.AutoEdit = false;
                column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }

            int visiblePosition = 0;

			//--------------------------------------------------------------------------------
			//  表示するカラム情報
            //--------------------------------------------------------------------------------
            #region [カラム情報の設定]

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.08.13 TOKUNAGA MODIFY START

            // 行№
            // [9095]
            Columns[DCJUT04102AC.ct_Col_RowNoDisplay].Header.Caption = "No.";
            Columns[DCJUT04102AC.ct_Col_RowNoDisplay].Header.Fixed = true;				// 固定項目
            Columns[DCJUT04102AC.ct_Col_RowNoDisplay].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[DCJUT04102AC.ct_Col_RowNoDisplay].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[DCJUT04102AC.ct_Col_RowNoDisplay].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[DCJUT04102AC.ct_Col_RowNoDisplay].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[DCJUT04102AC.ct_Col_RowNoDisplay].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[DCJUT04102AC.ct_Col_RowNoDisplay].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[DCJUT04102AC.ct_Col_RowNoDisplay].CellAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            Columns[DCJUT04102AC.ct_Col_RowNoDisplay].Hidden = false;
            //Columns[DCJUT04102AC.ct_Col_RowNoView].Hidden = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            Columns[DCJUT04102AC.ct_Col_RowNoDisplay].Width = 40;
            Columns[DCJUT04102AC.ct_Col_RowNoDisplay].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[DCJUT04102AC.ct_Col_RowNoDisplay].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            Columns[DCJUT04102AC.ct_Col_RowNoDisplay].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[DCJUT04102AC.ct_Col_RowNoDisplay].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[DCJUT04102AC.ct_Col_RowNoDisplay].Header.VisiblePosition = visiblePosition++;

            //Columns[DCJUT04102AC.ct_Col_RowNoView].Header.Caption = "No.";
            //Columns[DCJUT04102AC.ct_Col_RowNoView].Header.Fixed = true;				// 固定項目
            //Columns[DCJUT04102AC.ct_Col_RowNoView].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            //Columns[DCJUT04102AC.ct_Col_RowNoView].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            //Columns[DCJUT04102AC.ct_Col_RowNoView].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            //Columns[DCJUT04102AC.ct_Col_RowNoView].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            //Columns[DCJUT04102AC.ct_Col_RowNoView].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            //Columns[DCJUT04102AC.ct_Col_RowNoView].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            //Columns[DCJUT04102AC.ct_Col_RowNoView].CellAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //Columns[DCJUT04102AC.ct_Col_RowNoView].Hidden = false;
            ////Columns[DCJUT04102AC.ct_Col_RowNoView].Hidden = true;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //Columns[DCJUT04102AC.ct_Col_RowNoView].Width = 40;
            //Columns[DCJUT04102AC.ct_Col_RowNoView].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            //Columns[DCJUT04102AC.ct_Col_RowNoView].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            //Columns[DCJUT04102AC.ct_Col_RowNoView].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //Columns[DCJUT04102AC.ct_Col_RowNoView].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            //Columns[DCJUT04102AC.ct_Col_RowNoView].Header.VisiblePosition = visiblePosition++;
            // [9095]

            // 選択フラグ
            //Columns[DCJUT04102AC.ct_Col_SelectRowFlag].Header.Fixed = true;		// 固定項目
            //Columns[DCJUT04102AC.ct_Col_SelectRowFlag].Hidden = !select;
            //Columns[DCJUT04102AC.ct_Col_SelectRowFlag].Header.Caption = "選択";
            //Columns[DCJUT04102AC.ct_Col_SelectRowFlag].Width = 60;
            //Columns[DCJUT04102AC.ct_Col_SelectRowFlag].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            //Columns[DCJUT04102AC.ct_Col_SelectRowFlag].AutoEdit = true;
            //Columns[DCJUT04102AC.ct_Col_SelectRowFlag].Header.VisiblePosition = visiblePosition++;

            // 受注日
            Columns[DCJUT04102AC.ct_Col_SalesDateView].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_SalesDateView].Header.Caption = "受注日";
            Columns[DCJUT04102AC.ct_Col_SalesDateView].Width = 100;
            Columns[DCJUT04102AC.ct_Col_SalesDateView].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[DCJUT04102AC.ct_Col_SalesDateView].Header.VisiblePosition = visiblePosition++;

            // 伝票番号
            //Columns[DCJUT04102AC.ct_Col_SalesSlipNum].Header.Fixed = true;		// 固定項目
            Columns[DCJUT04102AC.ct_Col_SalesSlipNum].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_SalesSlipNum].Header.Caption = "伝票番号";
            Columns[DCJUT04102AC.ct_Col_SalesSlipNum].Width = 80;
            Columns[DCJUT04102AC.ct_Col_SalesSlipNum].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[DCJUT04102AC.ct_Col_SalesSlipNum].Header.VisiblePosition = visiblePosition++;

            // 2008.12.12 modify start [9095]
            // 行番号
            Columns[DCJUT04102AC.ct_Col_SalesRowNo].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_SalesRowNo].Header.Caption = "行番号";
            Columns[DCJUT04102AC.ct_Col_SalesRowNo].Width = 60;
            Columns[DCJUT04102AC.ct_Col_SalesRowNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[DCJUT04102AC.ct_Col_SalesRowNo].Header.VisiblePosition = visiblePosition++;
            // 2008.12.12 modify end [9095]

            // 明細区分
            Columns[DCJUT04102AC.ct_Col_SalesSlipCdDtl].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_SalesSlipCdDtl].Header.Caption = "明細区分";
            Columns[DCJUT04102AC.ct_Col_SalesSlipCdDtl].Width = 60;
            Columns[DCJUT04102AC.ct_Col_SalesSlipCdDtl].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[DCJUT04102AC.ct_Col_SalesSlipCdDtl].Header.VisiblePosition = visiblePosition++;

            // 得意先コード
            Columns[DCJUT04102AC.ct_Col_CustomerCode].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_CustomerCode].Header.Caption = "得意先コード";
            Columns[DCJUT04102AC.ct_Col_CustomerCode].Width = 100;
            Columns[DCJUT04102AC.ct_Col_CustomerCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[DCJUT04102AC.ct_Col_CustomerCode].Format = codeFormat8;
            Columns[DCJUT04102AC.ct_Col_CustomerCode].Header.VisiblePosition = visiblePosition++;

            // 得意先略称
            Columns[DCJUT04102AC.ct_Col_CustomerSnm].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_CustomerSnm].Header.Caption = "得意先名";
            Columns[DCJUT04102AC.ct_Col_CustomerSnm].Width = 120;
            Columns[DCJUT04102AC.ct_Col_CustomerSnm].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[DCJUT04102AC.ct_Col_CustomerSnm].Header.VisiblePosition = visiblePosition++;

            // 品番
            Columns[DCJUT04102AC.ct_Col_GoodsNo].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_GoodsNo].Header.Caption = "品番";
            Columns[DCJUT04102AC.ct_Col_GoodsNo].Width = 150;
            Columns[DCJUT04102AC.ct_Col_GoodsNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[DCJUT04102AC.ct_Col_GoodsNo].Header.VisiblePosition = visiblePosition++;

            // 品名
            Columns[DCJUT04102AC.ct_Col_GoodsName].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_GoodsName].Header.Caption = "品名";
            Columns[DCJUT04102AC.ct_Col_GoodsName].Width = 150;
            Columns[DCJUT04102AC.ct_Col_GoodsName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[DCJUT04102AC.ct_Col_GoodsName].Header.VisiblePosition = visiblePosition++;

            // メーカー名
            Columns[DCJUT04102AC.ct_Col_MakerName].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_MakerName].Header.Caption = "メーカー名";
            Columns[DCJUT04102AC.ct_Col_MakerName].Width = 120;
            Columns[DCJUT04102AC.ct_Col_MakerName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[DCJUT04102AC.ct_Col_MakerName].Header.VisiblePosition = visiblePosition++;

            // 仕入先コード
            Columns[DCJUT04102AC.ct_Col_SupplierCd].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_SupplierCd].Header.Caption = "仕入先コード";
            Columns[DCJUT04102AC.ct_Col_SupplierCd].Width = 60; // [9094]
            Columns[DCJUT04102AC.ct_Col_SupplierCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[DCJUT04102AC.ct_Col_SupplierCd].Format = codeFormat6;
            Columns[DCJUT04102AC.ct_Col_SupplierCd].Header.VisiblePosition = visiblePosition++;

            // 仕入先略称
            Columns[DCJUT04102AC.ct_Col_SupplierSnm].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_SupplierSnm].Header.Caption = "仕入先名";
            Columns[DCJUT04102AC.ct_Col_SupplierSnm].Width = 80;
            Columns[DCJUT04102AC.ct_Col_SupplierSnm].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[DCJUT04102AC.ct_Col_SupplierSnm].Header.VisiblePosition = visiblePosition++;

            // BLコード
            Columns[DCJUT04102AC.ct_Col_BLGoodsCode].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_BLGoodsCode].Header.Caption = "BLｺｰﾄﾞ";
            Columns[DCJUT04102AC.ct_Col_BLGoodsCode].Width = 120;
            Columns[DCJUT04102AC.ct_Col_BLGoodsCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[DCJUT04102AC.ct_Col_BLGoodsCode].Format = codeFormat5;
            Columns[DCJUT04102AC.ct_Col_BLGoodsCode].Header.VisiblePosition = visiblePosition++;

            // 担当者
            Columns[DCJUT04102AC.ct_Col_SalesEmployeeNm].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_SalesEmployeeNm].Header.Caption = "担当者";
            Columns[DCJUT04102AC.ct_Col_SalesEmployeeNm].Width = 120;
            Columns[DCJUT04102AC.ct_Col_SalesEmployeeNm].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[DCJUT04102AC.ct_Col_SalesEmployeeNm].Header.VisiblePosition = visiblePosition++;

            // 発行者
            if (InpAgentDispDiv == INP_AGT_DISP)
            {
                Columns[DCJUT04102AC.ct_Col_SalesInputNm].Hidden = false;
                Columns[DCJUT04102AC.ct_Col_SalesInputNm].Header.Caption = "発行者";
                Columns[DCJUT04102AC.ct_Col_SalesInputNm].Width = 120;
                Columns[DCJUT04102AC.ct_Col_SalesInputNm].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                Columns[DCJUT04102AC.ct_Col_SalesInputNm].Header.VisiblePosition = visiblePosition++;
            }

            // 受注者
            Columns[DCJUT04102AC.ct_Col_FrontEmployeeNm].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_FrontEmployeeNm].Header.Caption = "受注者";
            Columns[DCJUT04102AC.ct_Col_FrontEmployeeNm].Width = 120;
            Columns[DCJUT04102AC.ct_Col_FrontEmployeeNm].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[DCJUT04102AC.ct_Col_FrontEmployeeNm].Header.VisiblePosition = visiblePosition++;

            // 納品先名称1
            Columns[DCJUT04102AC.ct_Col_AddresseeName].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_AddresseeName].Header.Caption = "納品先名1";
            Columns[DCJUT04102AC.ct_Col_AddresseeName].Width = 120;
            Columns[DCJUT04102AC.ct_Col_AddresseeName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[DCJUT04102AC.ct_Col_AddresseeName].Header.VisiblePosition = visiblePosition++;

            // 納品先名称2
            Columns[DCJUT04102AC.ct_Col_AddresseeName2].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_AddresseeName2].Header.Caption = "納品先名2";
            Columns[DCJUT04102AC.ct_Col_AddresseeName2].Width = 120;
            Columns[DCJUT04102AC.ct_Col_AddresseeName2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[DCJUT04102AC.ct_Col_AddresseeName2].Header.VisiblePosition = visiblePosition++;

            // 標準価格
            Columns[DCJUT04102AC.ct_Col_ListPriceTaxExc].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_ListPriceTaxExc].Header.Caption = "標準価格";
            Columns[DCJUT04102AC.ct_Col_ListPriceTaxExc].Width = 80;
            Columns[DCJUT04102AC.ct_Col_ListPriceTaxExc].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[DCJUT04102AC.ct_Col_ListPriceTaxExc].Header.VisiblePosition = visiblePosition++;
            Columns[DCJUT04102AC.ct_Col_ListPriceTaxExc].Format = decimalFormat;

            // 受注数量
            Columns[DCJUT04102AC.ct_Col_AcceptAnOrderCnt].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_AcceptAnOrderCnt].Header.Caption = "受注数";
            Columns[DCJUT04102AC.ct_Col_AcceptAnOrderCnt].Width = 80;
            Columns[DCJUT04102AC.ct_Col_AcceptAnOrderCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[DCJUT04102AC.ct_Col_AcceptAnOrderCnt].Header.VisiblePosition = visiblePosition++;
            Columns[DCJUT04102AC.ct_Col_AcceptAnOrderCnt].Format = decimalFormat;

            // 受注残数
            Columns[DCJUT04102AC.ct_Col_AcptAnOdrRemainCnt].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_AcptAnOdrRemainCnt].Header.Caption = "受注残数";
            Columns[DCJUT04102AC.ct_Col_AcptAnOdrRemainCnt].Width = 80;
            Columns[DCJUT04102AC.ct_Col_AcptAnOdrRemainCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[DCJUT04102AC.ct_Col_AcptAnOdrRemainCnt].Header.VisiblePosition = visiblePosition++;
            Columns[DCJUT04102AC.ct_Col_AcptAnOdrRemainCnt].Format = decimalFormat;

            // 受注単価（税抜，浮動）
            Columns[DCJUT04102AC.ct_Col_SalesUnPrcTaxExcFl].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_SalesUnPrcTaxExcFl].Header.Caption = "受注単価";
            Columns[DCJUT04102AC.ct_Col_SalesUnPrcTaxExcFl].Width = 120;
            Columns[DCJUT04102AC.ct_Col_SalesUnPrcTaxExcFl].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[DCJUT04102AC.ct_Col_SalesUnPrcTaxExcFl].Header.VisiblePosition = visiblePosition++;
            Columns[DCJUT04102AC.ct_Col_SalesUnPrcTaxExcFl].Format = decimalFormat;
            
            // 受注金額
            Columns[DCJUT04102AC.ct_Col_SalesPriceTotal].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_SalesPriceTotal].Header.Caption = "受注金額";
            Columns[DCJUT04102AC.ct_Col_SalesPriceTotal].Width = 100;
            Columns[DCJUT04102AC.ct_Col_SalesPriceTotal].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[DCJUT04102AC.ct_Col_SalesPriceTotal].Header.VisiblePosition = visiblePosition++;
            Columns[DCJUT04102AC.ct_Col_SalesPriceTotal].Format = moneyFormat;

            // 消費税
            Columns[DCJUT04102AC.ct_Col_SalesPriceConsTax].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_SalesPriceConsTax].Header.Caption = "消費税";
            Columns[DCJUT04102AC.ct_Col_SalesPriceConsTax].Width = 100;
            Columns[DCJUT04102AC.ct_Col_SalesPriceConsTax].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[DCJUT04102AC.ct_Col_SalesPriceConsTax].Header.VisiblePosition = visiblePosition++;
            Columns[DCJUT04102AC.ct_Col_SalesPriceConsTax].Format = moneyFormat;

            // 原価単価
            Columns[DCJUT04102AC.ct_Col_SalesUnitCost].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_SalesUnitCost].Header.Caption = "原価単価";
            Columns[DCJUT04102AC.ct_Col_SalesUnitCost].Width = 80;
            Columns[DCJUT04102AC.ct_Col_SalesUnitCost].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[DCJUT04102AC.ct_Col_SalesUnitCost].Header.VisiblePosition = visiblePosition++;
            Columns[DCJUT04102AC.ct_Col_SalesUnitCost].Format = decimalFormat;

            // 管理番号
            Columns[DCJUT04102AC.ct_Col_CarMngCode].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_CarMngCode].Header.Caption = "管理番号";
            Columns[DCJUT04102AC.ct_Col_CarMngCode].Width = 80;
            Columns[DCJUT04102AC.ct_Col_CarMngCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[DCJUT04102AC.ct_Col_CarMngCode].Header.VisiblePosition = visiblePosition++;

            // 原価金額
            Columns[DCJUT04102AC.ct_Col_SalesTotalCost].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_SalesTotalCost].Header.Caption = "原価金額";
            Columns[DCJUT04102AC.ct_Col_SalesTotalCost].Width = 80;
            Columns[DCJUT04102AC.ct_Col_SalesTotalCost].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[DCJUT04102AC.ct_Col_SalesTotalCost].Header.VisiblePosition = visiblePosition++;
            Columns[DCJUT04102AC.ct_Col_SalesTotalCost].Format = moneyFormat;


            //// 類別番号
            //Columns[DCJUT04102AC.ct_Col_CategoryNo].Hidden = false;
            //Columns[DCJUT04102AC.ct_Col_CategoryNo].Header.Caption = "類別番号";
            //Columns[DCJUT04102AC.ct_Col_CategoryNo].Width = 80;
            //Columns[DCJUT04102AC.ct_Col_CategoryNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[DCJUT04102AC.ct_Col_CategoryNo].Header.VisiblePosition = visiblePosition++;

            // 類別形式
            Columns[DCJUT04102AC.ct_Col_ModelCategory].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_ModelCategory].Header.Caption = "類別形式";
            Columns[DCJUT04102AC.ct_Col_ModelCategory].Width = 80;
            Columns[DCJUT04102AC.ct_Col_ModelCategory].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[DCJUT04102AC.ct_Col_ModelCategory].Header.VisiblePosition = visiblePosition++;

            // 車種
            Columns[DCJUT04102AC.ct_Col_ModelFullName].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_ModelFullName].Header.Caption = "車種";
            Columns[DCJUT04102AC.ct_Col_ModelFullName].Width = 80;
            Columns[DCJUT04102AC.ct_Col_ModelFullName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[DCJUT04102AC.ct_Col_ModelFullName].Header.VisiblePosition = visiblePosition++;

            // 型式
            Columns[DCJUT04102AC.ct_Col_FullModel].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_FullModel].Header.Caption = "型式";
            Columns[DCJUT04102AC.ct_Col_FullModel].Width = 140;
            Columns[DCJUT04102AC.ct_Col_FullModel].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[DCJUT04102AC.ct_Col_FullModel].Header.VisiblePosition = visiblePosition++;

            // 倉庫名
            Columns[DCJUT04102AC.ct_Col_WarehouseName].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_WarehouseName].Header.Caption = "倉庫名";
            Columns[DCJUT04102AC.ct_Col_WarehouseName].Width = 100;
            Columns[DCJUT04102AC.ct_Col_WarehouseName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[DCJUT04102AC.ct_Col_WarehouseName].Header.VisiblePosition = visiblePosition++;

            // 明細備考
            Columns[DCJUT04102AC.ct_Col_DtlNote].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_DtlNote].Header.Caption = "明細備考";
            Columns[DCJUT04102AC.ct_Col_DtlNote].Width = 80;
            Columns[DCJUT04102AC.ct_Col_DtlNote].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[DCJUT04102AC.ct_Col_DtlNote].Header.VisiblePosition = visiblePosition++;

            // 入力日
            Columns[DCJUT04102AC.ct_Col_SearchSlipDateString].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_SearchSlipDateString].Header.Caption = "入力日";
            Columns[DCJUT04102AC.ct_Col_SearchSlipDateString].Width = 90; //[9095]
            Columns[DCJUT04102AC.ct_Col_SearchSlipDateString].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[DCJUT04102AC.ct_Col_SearchSlipDateString].Header.VisiblePosition = visiblePosition++;
            //Columns[DCJUT04102AC.ct_Col_SearchSlipDate].Format = dateFormat;

            // 出荷日
            Columns[DCJUT04102AC.ct_Col_ShipmentDayString].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_ShipmentDayString].Header.Caption = "出荷日";
            Columns[DCJUT04102AC.ct_Col_ShipmentDayString].Width = 90; //[9095]
            Columns[DCJUT04102AC.ct_Col_ShipmentDayString].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[DCJUT04102AC.ct_Col_ShipmentDayString].Header.VisiblePosition = visiblePosition++;
            //Columns[DCJUT04102AC.ct_Col_ShipmentDay].Format = dateFormat;

            // 計上日
            Columns[DCJUT04102AC.ct_Col_AddUpADateString].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_AddUpADateString].Header.Caption = "計上日";
            Columns[DCJUT04102AC.ct_Col_AddUpADateString].Width = 90; //[9095]
            Columns[DCJUT04102AC.ct_Col_AddUpADateString].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[DCJUT04102AC.ct_Col_AddUpADateString].Header.VisiblePosition = visiblePosition++;
            //Columns[DCJUT04102AC.ct_Col_AddUpADate].Format = dateFormat;

            // 拠点名
            Columns[DCJUT04102AC.ct_Col_SectionName].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_SectionName].Header.Caption = "拠点名";
            Columns[DCJUT04102AC.ct_Col_SectionName].Width = 100;
            Columns[DCJUT04102AC.ct_Col_SectionName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[DCJUT04102AC.ct_Col_SectionName].Header.VisiblePosition = visiblePosition++;

            // 請求先コード
            Columns[DCJUT04102AC.ct_Col_ClaimCode].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_ClaimCode].Header.Caption = "請求先コード";
            Columns[DCJUT04102AC.ct_Col_ClaimCode].Width = 80;
            Columns[DCJUT04102AC.ct_Col_ClaimCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[DCJUT04102AC.ct_Col_ClaimCode].Format = codeFormat8;
            Columns[DCJUT04102AC.ct_Col_ClaimCode].Header.VisiblePosition = visiblePosition++;

            // 請求先略称名
            Columns[DCJUT04102AC.ct_Col_ClaimSnm].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_ClaimSnm].Header.Caption = "請求先名";
            Columns[DCJUT04102AC.ct_Col_ClaimSnm].Width = 100;
            Columns[DCJUT04102AC.ct_Col_ClaimSnm].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[DCJUT04102AC.ct_Col_ClaimSnm].Header.VisiblePosition = visiblePosition++;

            // メモ有無マーク
            Columns[DCJUT04102AC.ct_Col_MemoExistsMark].Header.Fixed = false;
            Columns[DCJUT04102AC.ct_Col_MemoExistsMark].Hidden = false;
            Columns[DCJUT04102AC.ct_Col_MemoExistsMark].Header.Caption = "メモ";
            Columns[DCJUT04102AC.ct_Col_MemoExistsMark].Width = 50;
            Columns[DCJUT04102AC.ct_Col_MemoExistsMark].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[DCJUT04102AC.ct_Col_MemoExistsMark].Header.VisiblePosition = visiblePosition++;



            //// 単位名称
            //Columns[DCJUT04102AC.ct_Col_UnitName].Hidden = false;
            //Columns[DCJUT04102AC.ct_Col_UnitName].Header.Caption = "単位";
            //Columns[DCJUT04102AC.ct_Col_UnitName].Width = 40;
            //Columns[DCJUT04102AC.ct_Col_UnitName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[DCJUT04102AC.ct_Col_UnitName].Header.VisiblePosition = visiblePosition++;


            //// 受注残金額
            //Columns[DCJUT04102AC.ct_Col_AcptAnOdrRemainPrice].Hidden = false;
            //Columns[DCJUT04102AC.ct_Col_AcptAnOdrRemainPrice].Header.Caption = "受注残金額";
            //Columns[DCJUT04102AC.ct_Col_AcptAnOdrRemainPrice].Width = 120;
            //Columns[DCJUT04102AC.ct_Col_AcptAnOdrRemainPrice].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //Columns[DCJUT04102AC.ct_Col_AcptAnOdrRemainPrice].Header.VisiblePosition = visiblePosition++;
            //Columns[DCJUT04102AC.ct_Col_AcptAnOdrRemainPrice].Format = moneyFormat;

            //// 特売区分名称
            //Columns[DCJUT04102AC.ct_Col_BargainNm].Hidden = false;
            //Columns[DCJUT04102AC.ct_Col_BargainNm].Header.Caption = "特売区分名";
            //Columns[DCJUT04102AC.ct_Col_BargainNm].Width = 80;
            //Columns[DCJUT04102AC.ct_Col_BargainNm].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[DCJUT04102AC.ct_Col_BargainNm].Header.VisiblePosition = visiblePosition++;

            //// 相手先伝票番号（明細）
            //Columns[DCJUT04102AC.ct_Col_PartySlipNumDtl].Hidden = false;
            //Columns[DCJUT04102AC.ct_Col_PartySlipNumDtl].Header.Caption = "得意先注番";
            //Columns[DCJUT04102AC.ct_Col_PartySlipNumDtl].Width = 80;
            //Columns[DCJUT04102AC.ct_Col_PartySlipNumDtl].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[DCJUT04102AC.ct_Col_PartySlipNumDtl].Header.VisiblePosition = visiblePosition++;
            //// 基準単価（売上単価）
            //Columns[DCJUT04102AC.ct_Col_StdUnPrcSalUnPrc].Hidden = false;
            //Columns[DCJUT04102AC.ct_Col_StdUnPrcSalUnPrc].Header.Caption = "基準単価";
            //Columns[DCJUT04102AC.ct_Col_StdUnPrcSalUnPrc].Width = 80;
            //Columns[DCJUT04102AC.ct_Col_StdUnPrcSalUnPrc].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //Columns[DCJUT04102AC.ct_Col_StdUnPrcSalUnPrc].Header.VisiblePosition = visiblePosition++;
            //Columns[DCJUT04102AC.ct_Col_StdUnPrcSalUnPrc].Format = decimalFormat;

           
            //// 客先納期
            //Columns[DCJUT04102AC.ct_Col_CustomerDeliveryDateView].Hidden = false;
            //Columns[DCJUT04102AC.ct_Col_CustomerDeliveryDateView].Header.Caption = "客先納期";
            //Columns[DCJUT04102AC.ct_Col_CustomerDeliveryDateView].Width = 100;
            //Columns[DCJUT04102AC.ct_Col_CustomerDeliveryDateView].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[DCJUT04102AC.ct_Col_CustomerDeliveryDateView].Header.VisiblePosition = visiblePosition++;

            //// 伝票メモ１
            //Columns[DCJUT04102AC.ct_Col_SlipMemo1].Hidden = false;
            //Columns[DCJUT04102AC.ct_Col_SlipMemo1].Header.Caption = "伝票メモ１";
            //Columns[DCJUT04102AC.ct_Col_SlipMemo1].Width = 80;
            //Columns[DCJUT04102AC.ct_Col_SlipMemo1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[DCJUT04102AC.ct_Col_SlipMemo1].Header.VisiblePosition = visiblePosition++;
            //// 伝票メモ２
            //Columns[DCJUT04102AC.ct_Col_SlipMemo2].Hidden = false;
            //Columns[DCJUT04102AC.ct_Col_SlipMemo2].Header.Caption = "伝票メモ２";
            //Columns[DCJUT04102AC.ct_Col_SlipMemo2].Width = 80;
            //Columns[DCJUT04102AC.ct_Col_SlipMemo2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[DCJUT04102AC.ct_Col_SlipMemo2].Header.VisiblePosition = visiblePosition++;
            //// 伝票メモ３
            //Columns[DCJUT04102AC.ct_Col_SlipMemo3].Hidden = false;
            //Columns[DCJUT04102AC.ct_Col_SlipMemo3].Header.Caption = "伝票メモ３";
            //Columns[DCJUT04102AC.ct_Col_SlipMemo3].Width = 80;
            //Columns[DCJUT04102AC.ct_Col_SlipMemo3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[DCJUT04102AC.ct_Col_SlipMemo3].Header.VisiblePosition = visiblePosition++;
            //// 伝票メモ４
            //Columns[DCJUT04102AC.ct_Col_SlipMemo4].Hidden = false;
            //Columns[DCJUT04102AC.ct_Col_SlipMemo4].Header.Caption = "伝票メモ４";
            //Columns[DCJUT04102AC.ct_Col_SlipMemo4].Width = 80;
            //Columns[DCJUT04102AC.ct_Col_SlipMemo4].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[DCJUT04102AC.ct_Col_SlipMemo4].Header.VisiblePosition = visiblePosition++;
            //// 伝票メモ５
            //Columns[DCJUT04102AC.ct_Col_SlipMemo5].Hidden = false;
            //Columns[DCJUT04102AC.ct_Col_SlipMemo5].Header.Caption = "伝票メモ５";
            //Columns[DCJUT04102AC.ct_Col_SlipMemo5].Width = 80;
            //Columns[DCJUT04102AC.ct_Col_SlipMemo5].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[DCJUT04102AC.ct_Col_SlipMemo5].Header.VisiblePosition = visiblePosition++;
            //// 伝票メモ６
            //Columns[DCJUT04102AC.ct_Col_SlipMemo6].Hidden = false;
            //Columns[DCJUT04102AC.ct_Col_SlipMemo6].Header.Caption = "伝票メモ６";
            //Columns[DCJUT04102AC.ct_Col_SlipMemo6].Width = 80;
            //Columns[DCJUT04102AC.ct_Col_SlipMemo6].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[DCJUT04102AC.ct_Col_SlipMemo6].Header.VisiblePosition = visiblePosition++;
            //// 社内メモ１
            //Columns[DCJUT04102AC.ct_Col_InsideMemo1].Hidden = false;
            //Columns[DCJUT04102AC.ct_Col_InsideMemo1].Header.Caption = "社内メモ１";
            //Columns[DCJUT04102AC.ct_Col_InsideMemo1].Width = 80;
            //Columns[DCJUT04102AC.ct_Col_InsideMemo1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[DCJUT04102AC.ct_Col_InsideMemo1].Header.VisiblePosition = visiblePosition++;
            //// 社内メモ２
            //Columns[DCJUT04102AC.ct_Col_InsideMemo2].Hidden = false;
            //Columns[DCJUT04102AC.ct_Col_InsideMemo2].Header.Caption = "社内メモ２";
            //Columns[DCJUT04102AC.ct_Col_InsideMemo2].Width = 80;
            //Columns[DCJUT04102AC.ct_Col_InsideMemo2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[DCJUT04102AC.ct_Col_InsideMemo2].Header.VisiblePosition = visiblePosition++;
            //// 社内メモ３
            //Columns[DCJUT04102AC.ct_Col_InsideMemo3].Hidden = false;
            //Columns[DCJUT04102AC.ct_Col_InsideMemo3].Header.Caption = "社内メモ３";
            //Columns[DCJUT04102AC.ct_Col_InsideMemo3].Width = 80;
            //Columns[DCJUT04102AC.ct_Col_InsideMemo3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[DCJUT04102AC.ct_Col_InsideMemo3].Header.VisiblePosition = visiblePosition++;
            //// 社内メモ４
            //Columns[DCJUT04102AC.ct_Col_InsideMemo4].Hidden = false;
            //Columns[DCJUT04102AC.ct_Col_InsideMemo4].Header.Caption = "社内メモ４";
            //Columns[DCJUT04102AC.ct_Col_InsideMemo4].Width = 80;
            //Columns[DCJUT04102AC.ct_Col_InsideMemo4].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[DCJUT04102AC.ct_Col_InsideMemo4].Header.VisiblePosition = visiblePosition++;
            //// 社内メモ５
            //Columns[DCJUT04102AC.ct_Col_InsideMemo5].Hidden = false;
            //Columns[DCJUT04102AC.ct_Col_InsideMemo5].Header.Caption = "社内メモ５";
            //Columns[DCJUT04102AC.ct_Col_InsideMemo5].Width = 80;
            //Columns[DCJUT04102AC.ct_Col_InsideMemo5].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[DCJUT04102AC.ct_Col_InsideMemo5].Header.VisiblePosition = visiblePosition++;
            //// 社内メモ６
            //Columns[DCJUT04102AC.ct_Col_InsideMemo6].Hidden = false;
            //Columns[DCJUT04102AC.ct_Col_InsideMemo6].Header.Caption = "社内メモ６";
            //Columns[DCJUT04102AC.ct_Col_InsideMemo6].Width = 80;
            //Columns[DCJUT04102AC.ct_Col_InsideMemo6].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[DCJUT04102AC.ct_Col_InsideMemo6].Header.VisiblePosition = visiblePosition++;
            
            //// 発注番号
            //Columns[DCJUT04102AC.ct_Col_OrderNumber].Hidden = false;
            //Columns[DCJUT04102AC.ct_Col_OrderNumber].Header.Caption = "発注番号";
            //Columns[DCJUT04102AC.ct_Col_OrderNumber].Width = 80;
            //Columns[DCJUT04102AC.ct_Col_OrderNumber].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[DCJUT04102AC.ct_Col_OrderNumber].Header.VisiblePosition = visiblePosition++;

            //// 希望納期
            //Columns[DCJUT04102AC.ct_Col_ExpectDeliveryDateView].Hidden = false;
            //Columns[DCJUT04102AC.ct_Col_ExpectDeliveryDateView].Header.Caption = "仕入希望納期";
            //Columns[DCJUT04102AC.ct_Col_ExpectDeliveryDateView].Width = 100;
            //Columns[DCJUT04102AC.ct_Col_ExpectDeliveryDateView].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[DCJUT04102AC.ct_Col_ExpectDeliveryDateView].Header.VisiblePosition = visiblePosition++;

            //// 納入完了予定日
            //Columns[DCJUT04102AC.ct_Col_DeliGdsCmpltDueDateView].Hidden = false;
            //Columns[DCJUT04102AC.ct_Col_DeliGdsCmpltDueDateView].Header.Caption = "発注回答納期";
            //Columns[DCJUT04102AC.ct_Col_DeliGdsCmpltDueDateView].Width = 100;
            //Columns[DCJUT04102AC.ct_Col_DeliGdsCmpltDueDateView].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[DCJUT04102AC.ct_Col_DeliGdsCmpltDueDateView].Header.VisiblePosition = visiblePosition++;

            //// 入荷日
            //Columns[DCJUT04102AC.ct_Col_ArrivalGoodsDayView].Hidden = false;
            //Columns[DCJUT04102AC.ct_Col_ArrivalGoodsDayView].Header.Caption = "入荷日";
            //Columns[DCJUT04102AC.ct_Col_ArrivalGoodsDayView].Width = 100;
            //Columns[DCJUT04102AC.ct_Col_ArrivalGoodsDayView].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[DCJUT04102AC.ct_Col_ArrivalGoodsDayView].Header.VisiblePosition = visiblePosition++;

            //// 仕入数
            //Columns[DCJUT04102AC.ct_Col_StockCount].Hidden = false;
            //Columns[DCJUT04102AC.ct_Col_StockCount].Header.Caption = "入荷数";
            //Columns[DCJUT04102AC.ct_Col_StockCount].Width = 80;
            //Columns[DCJUT04102AC.ct_Col_StockCount].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //Columns[DCJUT04102AC.ct_Col_StockCount].Header.VisiblePosition = visiblePosition++;
            //Columns[DCJUT04102AC.ct_Col_StockCount].Format = moneyFormat;

            //// 仕入単価（税抜，浮動）
            //Columns[DCJUT04102AC.ct_Col_StockUnitPriceFl].Hidden = false;
            //Columns[DCJUT04102AC.ct_Col_StockUnitPriceFl].Header.Caption = "仕入単価";
            //Columns[DCJUT04102AC.ct_Col_StockUnitPriceFl].Width = 80;
            //Columns[DCJUT04102AC.ct_Col_StockUnitPriceFl].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //Columns[DCJUT04102AC.ct_Col_StockUnitPriceFl].Header.VisiblePosition = visiblePosition++;
            //Columns[DCJUT04102AC.ct_Col_StockUnitPriceFl].Format = decimalFormat;
            #endregion

            // 固定列区切り線設定
            this.uGrid_Details.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
        }
        # endregion ■ グリッド列初期化 ■

        # region ■ 「全て選択」可/不可制御 ■
        /// <summary>
        /// 「全て選択」可/不可制御
        /// </summary>
        public void SettingAllSelectEnable()
        {
            // グリッド行数が選択可能件数をオーバーしていたら、「全て選択」は不可
            if ( this.uGrid_Details.Rows.Count > this.MaxSelectCount )
            {
                this.Select_Button.Enabled = false;
            }
            else
            {
                this.Select_Button.Enabled = true;
            }
        }
        # endregion ■ 「全て選択」可/不可制御 ■

        /// <summary>
		/// グリッド行初期設定処理
		/// </summary>
		private void GridRowInitialSetting()
		{
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
        /// 選択・非選択変更処理（反転）
        /// </summary>
        /// <param name="gridRow"></param>
        private void ChangedSelect ( Infragistics.Win.UltraWinGrid.UltraGridRow gridRow )
        {
            // 選択不可ならキャンセル
            if ( _maxSelectCount == 0 )
            {
                return;
            }

            // 選択・非選択　反転
            bool newSelectedValue = !(bool)gridRow.Cells[DCJUT04102AC.ct_Col_SelectRowFlag].Value;

            // 最大数選択済みならキャンセル
            if ( newSelectedValue == true && this._maxSelectCount <= this._selectedCount )
            {
                if ( this.StatusBarMessageSetting != null )
                {
                    this.StatusBarMessageSetting( this, "選択可能数を超えています。" );
                }
                return;
            }
            
            // テーブル更新
            this._acptAnOdrRemainRefAcs.SetRowSelected( (int)gridRow.Cells[DCJUT04102AC.ct_Col_RowNoView].Value, newSelectedValue );

            // 背景色を変更
            ChangedSelectColor( newSelectedValue, gridRow );
        }
        /// <summary>
        /// 選択・非選択変更処理（背景色のみ）
        /// </summary>
        /// <param name="isSelected"></param>
        /// <param name="gridRow"></param>
        private void ChangedSelectColor ( bool isSelected, Infragistics.Win.UltraWinGrid.UltraGridRow gridRow )
        {
            if ( gridRow == null ) return;

            // 対象行の選択色を設定する
            if ( isSelected )
            {
                gridRow.Appearance.BackColor = _selectedBackColor;
                gridRow.Appearance.BackColor2 = _selectedBackColor2;
                gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            }
            else
            {
                if ( gridRow.Index % 2 == 1 )
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
        /// 全ての行の背景色変更
        /// </summary>
        /// <param name="isSelected"></param>
        private void ChangedSelectColorAll ( bool isSelected )
        {
            foreach ( Infragistics.Win.UltraWinGrid.UltraGridRow row in this.uGrid_Details.Rows )
            {
                ChangedSelectColor( isSelected, row );
            }
        }
        #endregion

        # region ■ アクティブ行情報取得 ■
        /// <summary>
        /// アクティブ行の共通通番取得処理
        /// </summary>
        /// <returns></returns>
        public int GetRowCommonSeq()
        {
            if ( uGrid_Details.ActiveRow != null )
            {
                return GetCellInt32( uGrid_Details.ActiveRow.Cells[DCJUT04102AC.ct_Col_CommonSeqNo].Value, -1 );
            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// セル→Int32取得
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="defaultValue">初期値</param>
        /// <returns>取得数値</returns>
        private Int32 GetCellInt32( object value, Int32 defaultValue )
        {
            int dest = defaultValue;
            try
            {
                dest = Convert.ToInt32( value );
            }
            catch
            {
                return dest;
            }
            return dest;
        }
        # endregion ■ アクティブ行情報取得 ■


        # region コントロールイベントメソッド

        # region ■ グリッド内イベント ■

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

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // single選択モード動作
                if ( this._maxSelectCount == 1 )
                {
                    // アクティブ行選択タイマー起動
                    this.timer_SelectRow.Enabled = true;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                //// 選択行決定
                //this.SelectRow();
			}

            // 最上行での↑キー
            if (this.uGrid_Details.ActiveRow.Index == 0)
            {
                if (e.KeyCode == Keys.Up)
                {
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
        /// グリッド(初期)フォーカス設定タイマー起動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void timer_GridSetFocus_Tick ( object sender, EventArgs e )
        {
            this.uGrid_Details.Focus();

            if ( this.uGrid_Details.ActiveRow != null )
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
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void uGrid_Details_Click ( object sender, EventArgs e )
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // マウスポインタがグリッドのどの位置にあるかを判定する
            Point point = System.Windows.Forms.Cursor.Position;
            point = targetGrid.PointToClient( point );

            // UIElementを取得する。
            Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint( point );
            if ( objUIElement == null )
                return;

            // マウスポインターが列のヘッダ上にあるかチェック。
            Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
              (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext( typeof( Infragistics.Win.UltraWinGrid.ColumnHeader ) );

            if ( objHeader != null ) return;

            // マウスポインターが行の上にあるかチェック。
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
              (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext( typeof( Infragistics.Win.UltraWinGrid.UltraGridRow ) );

            if ( objRow == null ) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
              (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext( typeof( Infragistics.Win.UltraWinGrid.UltraGridCell ) );

            // 選択チェック
            if ( objCell == objRow.Cells[DCJUT04102AC.ct_Col_SelectRowFlag] )
            {
                this.ChangedSelect( objRow );
            }
        }

        /// <summary>
        /// グリッドダブルクリックイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_DoubleClick ( object sender, EventArgs e )
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // マウスポインタがグリッドのどの位置にあるかを判定する
            Point point = System.Windows.Forms.Cursor.Position;
            point = targetGrid.PointToClient( point );

            // UIElementを取得する。
            Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint( point );
            if ( objUIElement == null )
                return;

            // マウスポインターが列のヘッダ上にあるかチェック。
            Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
              (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext( typeof( Infragistics.Win.UltraWinGrid.ColumnHeader ) );

            if ( objHeader != null ) return;

            // マウスポインターが行の上にあるかチェック。
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
              (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext( typeof( Infragistics.Win.UltraWinGrid.UltraGridRow ) );

            if ( objRow == null ) return;

            // チェック反転
            this.ChangedSelect( objRow );
        }
        # endregion ■ グリッド内イベント ■

        # region ■ グリッドヘッダ部イベント ■
        /// <summary>
        /// 全選択ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Select_Button_Click ( object sender, EventArgs e )
        {
            // 全ての行を選択済みにする
            this._acptAnOdrRemainRefAcs.SetRowSelectedAll( true );

            // 全ての行の背景色を変更
            ChangedSelectColorAll( true );
        }
        /// <summary>
        /// 全解除ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnSelect_Button_Click ( object sender, EventArgs e )
        {
            // 全ての行を非選択にする
            this._acptAnOdrRemainRefAcs.SetRowSelectedAll( false );

            // 全ての行の背景色を変更
            ChangedSelectColorAll( false );
        }
        # endregion ■ グリッドヘッダ部イベント ■

        /// <summary>
        /// 選択行情報取得タイマー起動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void timer_SelectRow_Tick ( object sender, EventArgs e )
        {
            this.timer_SelectRow.Enabled = false;
            if ( this.uGrid_Details.ActiveRow != null )
            {
                // 選択 or 解除
                this.ChangedSelect( this.uGrid_Details.ActiveRow );
            }
        }

        # endregion
    }
}

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
    /// <summary>
    /// 売上履歴照会明細クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上履歴照会の明細表示コントロールクラスです。</br>
    /// <br>             （※過去コメント記載が無い為追加）</br>
    /// <br>Programmer : 22018 鈴木正臣</br>
    /// <br>Date       : 2006.10.21</br>
    /// <br>Update Note: 2011/11/11 鄧潘ハン Redmine 26539対応</br>
    /// <br></br>
    /// </remarks>
	public partial class DCHNB04101UB : UserControl
	{
		public DCHNB04101UB()
		{
			InitializeComponent();

            this._searchSlipAcs = DCHNB04102AA.GetInstance();
            this._dataSet = this._searchSlipAcs.DataSet;

			this._searchSlipAcs.SalesDetailView.Sort = "SalesDate DESC,SectionCode,SalesSlipNum,SalesRowNo";

			//this.uGrid_Details.DataSource = this._dataSet.SalesDetail;
			this.uGrid_Details.DataSource = this._searchSlipAcs.SalesDetailView;

			this._imageList16 = IconResourceManagement.ImageList16;
			this._salHisRefResultParamWork = new List<SalHisRefResultParamWork>();
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
        // 発行者表示区分(DCKHN09211Eの区分と合わせる必要あり)
        private const int INP_AGT_DISP = 0;         // 0:する
        private const int INP_AGT_NODISP = 1;       // 1:しない
        private const int INP_AGT_NESSESALY = 2;    // 2:必須

        // 設定値保存用：売上全体設定．発行者表示区分
        private int _inpAgentDispDiv;

        // 部署管理区分(SFULN09001Eの区分と合わせる必要あり)
        private const int DIV_MNG_SECTION = 0;      // 0:拠点
        private const int DIV_MNG_SUBSECTION = 1;   // 1:拠点＋部
        private const int DIV_MNG_DIVITION = 2;     // 2:拠点＋部＋課

        // 設定値保存用：自社設定．部署管理区分
        private int _secMngDiv;

        // パブリック プロパティ

        // 発行者表示区分
        public int InpAgentDispDiv
        {
            get { return this._inpAgentDispDiv; }
            set { this._inpAgentDispDiv = value; }
        }

        // 部署管理区分
        public int SecMngDiv
        {
            get { return this._secMngDiv; }
            set { this._secMngDiv = value; }
        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END

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

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
        // 最大選択可能行数
        private int _maxSelectCount;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD

        private DCHNB04102AA _searchSlipAcs;
		private StockDataSet _dataSet;
		private ImageList _imageList16 = null;									// イメージリスト

		public List<SalHisRefResultParamWork> _salHisRefResultParamWork;
		public SalHisRefExtraParamWork _salHisRefExtraParamWork;
		public int _supplierFormal = 1;	//仕入形式：1:仕入 2:入荷
		private int _startMovment = 0;											// 起動モード 0:エントリー 1:メニュー

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // デリゲート処理
        //internal event SettingRaedParaEventHandler ReadParaSetting;
        //internal delegate void SettingRaedParaEventHandler(out IOWriteMASIRReadWork retIOWriteMASIRReadWork);

        internal event SettingStatusBarMessageEventHandler StatusBarMessageSetting;
        internal delegate void SettingStatusBarMessageEventHandler(object sender, string message);

        internal event CloseMainEventHandler CloseMain;
        internal delegate void CloseMainEventHandler();

        internal event SetDialogResEventHandler SetMainDialogResult;
        internal delegate void SetDialogResEventHandler(DialogResult dialogRes);

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
        //internal event SettingDecisionButtonEnableEventHandler DecisionButtonEnableSet;
        //internal delegate void SettingDecisionButtonEnableEventHandler(bool enableSet);
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL

		/// <summary>
		/// 起動動作モードの設定
		/// </summary>
		/// <param name="startMovment"></param>
		/// <returns></returns>
		public void SetStartMovment(int startMovment)
		{
			StartMovment = startMovment;

			if (StartMovment == 1)
			{
				Select_Button.Visible = false;
				UnSelect_Button.Visible = false;
				PrintExtra_Panel.Visible = false;
			}
			else
			{
				Select_Button.Visible = true;
				UnSelect_Button.Visible = true;
				PrintExtra_Panel.Visible = true;
			}
		}


		/// <summary>
		/// 選択・解除ボタン制御
		/// </summary>
		/// <param name="enableSet"></param>
		public void SetSelectBtn(bool enableSet)
		{
			Select_Button.Enabled = enableSet;
			UnSelect_Button.Enabled = enableSet;
		}

		/// <summary>
		/// 起動動作モード
		/// </summary>
		public int StartMovment
		{
			get { return this._startMovment; }
			set { this._startMovment = value; }
		}

        private void InputDetails_Load(object sender, EventArgs e)
		{
            // グリッド列初期設定処理
			//this.GridColInitialSetting(this.uGrid_ViewDetails.DisplayLayout.Bands[0].Columns);
			this.GridColInitialSetting(this.uGrid_Details.DisplayLayout.Bands[0].Columns);

			// グリッド行初期設定処理
			this.GridRowInitialSetting();

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
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
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

            // 2008.11.10 del start [7544]
            // エラーメッセージ表示
            //if ( status == false )
            //{
            //    this.StatusBarMessageSetting( this, "選択可能数を超えています。" );
            //}
            // 2008.11.10 del end [7544]
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD

		/// <summary>
		/// グリッド列初期設定処理
		/// </summary>
        /// <br>Update Note: 2011/11/11 鄧潘ハン BLﾊﾟｰﾂｵｰﾀﾞｰ在庫確認時の見積伝票対応</br>
        private void GridColInitialSetting(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns)
		{
			int visiblePosition = 1;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
            //string moneyFormat = "#,##0;-#,##0;";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
            string moneyFormat = "#,##0;-#,##0;''";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD
			string dateFormat = "yyyy/MM/dd";
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
            //string codeFormat = "#;";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL
			string doubleFormat = "#,##0.00;-#,##0.00;''";

			// 一旦、全ての列を非表示にする。
			foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
			{
				//非表示設定
				column.Hidden = true;
				//入力許可設定
				//column.AutoEdit = false;
				column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

				column.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
			}
		
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/27 ADD
            uiSetControl1.SettingFormBeforeLoad();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/27 ADD

			//--------------------------------------------------------------------------------
			//  表示するカラム情報
			//--------------------------------------------------------------------------------
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA DEL START
			// 印刷フラグ
            //Columns[this._dataSet.SalesDetail.PrintFlagColumn.ColumnName].Header.Fixed = true;			// 固定項目
            //Columns[this._dataSet.SalesDetail.PrintFlagColumn.ColumnName].Hidden = StartMovment == 1 ? true: false;
            //Columns[this._dataSet.SalesDetail.PrintFlagColumn.ColumnName].Header.Caption = "";
            //Columns[this._dataSet.SalesDetail.PrintFlagColumn.ColumnName].Width = 10;
            //Columns[this._dataSet.SalesDetail.PrintFlagColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            //Columns[this._dataSet.SalesDetail.PrintFlagColumn.ColumnName].AutoEdit = true;
            //Columns[this._dataSet.SalesDetail.PrintFlagColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA DEL END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/24 DEL
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA MODIFY START
            //// No.
            //Columns[this._dataSet.SalesDetail.NoColumn.ColumnName].Header.Fixed = true;			// 固定項目
            //Columns[this._dataSet.SalesDetail.NoColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesDetail.NoColumn.ColumnName].Header.Caption = "No.";
            //Columns[this._dataSet.SalesDetail.NoColumn.ColumnName].Width = 35;
            //Columns[this._dataSet.SalesDetail.NoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._dataSet.SalesDetail.NoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA MODIFY END
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/22 ADD
            //Columns[this._dataSet.SalesDetail.NoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            //Columns[this._dataSet.SalesDetail.NoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            //Columns[this._dataSet.SalesDetail.NoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            //Columns[this._dataSet.SalesDetail.NoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/22 ADD
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/24 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/24 ADD
            // No.
            Columns[this._dataSet.SalesDetail.NoForDispColumn.ColumnName].Header.Fixed = true;			// 固定項目
            Columns[this._dataSet.SalesDetail.NoForDispColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.NoForDispColumn.ColumnName].Header.Caption = "No.";
            Columns[this._dataSet.SalesDetail.NoForDispColumn.ColumnName].Width = 35;
            Columns[this._dataSet.SalesDetail.NoForDispColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.NoForDispColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesDetail.NoForDispColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._dataSet.SalesDetail.NoForDispColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[this._dataSet.SalesDetail.NoForDispColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[this._dataSet.SalesDetail.NoForDispColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._dataSet.SalesDetail.NoForDispColumn.ColumnName].CellAppearance.ForeColor = Color.White;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/24 ADD

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/22 ADD
            // 選択フラグ
            Columns[this._dataSet.SalesDetail.PrintFlagColumn.ColumnName].Header.Fixed = true;			// 固定項目
            Columns[this._dataSet.SalesDetail.PrintFlagColumn.ColumnName].Hidden = StartMovment == 1 ? true : false;
            Columns[this._dataSet.SalesDetail.PrintFlagColumn.ColumnName].Header.Caption = "選択";
            Columns[this._dataSet.SalesDetail.PrintFlagColumn.ColumnName].Width = 40;
            Columns[this._dataSet.SalesDetail.PrintFlagColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[this._dataSet.SalesDetail.PrintFlagColumn.ColumnName].AutoEdit = true;
            Columns[this._dataSet.SalesDetail.PrintFlagColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/22 ADD

            // 売上日
            Columns[this._dataSet.SalesDetail.SalesDateStringColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.SalesDateStringColumn.ColumnName].Header.Caption = "売上日";
            Columns[this._dataSet.SalesDetail.SalesDateStringColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
            //Columns[this._dataSet.SalesDetail.SalesDateStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
            Columns[this._dataSet.SalesDetail.SalesDateStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
            Columns[this._dataSet.SalesDetail.SalesDateStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 伝票番号
            Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].Header.Caption = "伝票番号";
            Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
            //Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
            Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
            Columns[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 行番号
            Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Header.Caption = "行番号";
            Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //Columns[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName].Format = codeFormat;

            // 伝票種別(10:見積,20:受注,30:売上,40:出荷)
            Columns[this._dataSet.SalesDetail.AcptAnOdrStatusStringColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.AcptAnOdrStatusStringColumn.ColumnName].Header.Caption = "伝票種別";
            Columns[this._dataSet.SalesDetail.AcptAnOdrStatusStringColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
            //Columns[this._dataSet.SalesDetail.AcptAnOdrStatusStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
            Columns[this._dataSet.SalesDetail.AcptAnOdrStatusStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
            Columns[this._dataSet.SalesDetail.AcptAnOdrStatusStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
            // 明細区分
            Columns[this._dataSet.SalesDetail.SalesSlipCdDtlStringColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.SalesSlipCdDtlStringColumn.ColumnName].Header.Caption = "明細区分";
            Columns[this._dataSet.SalesDetail.SalesSlipCdDtlStringColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.SalesSlipCdDtlStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.SalesSlipCdDtlStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END

            // 得意先コード
            Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].Header.Caption = "得意先コード";
            Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
            //Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
            Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].Format = GetCustomerCodeFormat();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
            Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
            //Columns[this._dataSet.SalesDetail.CustomerCodeColumn.ColumnName].Format = codeFormat;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL

            // 得意先
            Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].Header.Caption = "得意先名";
            Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.CustomerSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 品番
            Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Header.Caption = "品番";
            Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
            //Columns[this._dataSet.SalesDetail.GoodsNoColumn.ColumnName].Format = codeFormat;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL

            // 品名
            Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Header.Caption = "品名";
            Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.GoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // メーカー名
            Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Header.Caption = "メーカー名";
            Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.MakerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
            // 仕入先コード
            Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].Header.Caption = "仕入先コード";
            Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
            //Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
            Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].Format = GetSupplierCodeFormat();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
            Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
            //Columns[this._dataSet.SalesDetail.SupplierCdColumn.ColumnName].Format = codeFormat;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END

            // 仕入先
            Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Header.Caption = "仕入先名";
            Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA DEL START
            //Columns[this._dataSet.SalesDetail.SupplierSnmColumn.ColumnName].Format = codeFormat;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA DEL END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
            // BLコード
            Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Header.Caption = "BLコード";
            Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
            //Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
            Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Format = GetBLGoodsCodeFormat();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
            Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
            //Columns[this._dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName].Format = codeFormat;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END

            // 担当者
            Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].Header.Caption = "担当者";
            Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 発行者
            // 2008.11.10 modify start [7526]
            //if (this._inpAgentDispDiv != INP_AGT_NODISP) // 非表示でなければ
            //{
            Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].Header.Caption = "発行者";
            Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //}
            // 2008.11.10 modify end [7526]

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
            // 受注者
            Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].Header.Caption = "受注者";
            Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 標準価格
            Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Header.Caption = "標準価格";
            Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // 2008.11.11 modify start [7633]
            //Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Format = doubleFormat;
            Columns[this._dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName].Format = moneyFormat;
            // 2008.11.11 modify end [7633]
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END

            // 売上数
            Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Header.Caption = "売上数";
            Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesDetail.ShipmentCntColumn.ColumnName].Format = doubleFormat;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
            // 売上残数
            Columns[this._dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName].Header.Caption = "売上残数";
            Columns[this._dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName].Format = doubleFormat;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END

            // 売上単価（税抜き）
            Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Hidden = false;
            // 2008.11.10 modify start [7532]
            //Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Header.Caption = "売上単価";
            Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Header.Caption = "売単価";
            // 2008.11.10 modify end [7532]
            Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName].Format = doubleFormat;

            // 売上単価（税込み）
            //Columns[this._dataSet.SalesDetail.SalesUnPrcTaxIncFlColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesDetail.SalesUnPrcTaxIncFlColumn.ColumnName].Header.Caption = "売上単価";
            //Columns[this._dataSet.SalesDetail.SalesUnPrcTaxIncFlColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesDetail.SalesUnPrcTaxIncFlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //Columns[this._dataSet.SalesDetail.SalesUnPrcTaxIncFlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //Columns[this._dataSet.SalesDetail.SalesUnPrcTaxIncFlColumn.ColumnName].Format = moneyFormat;

            // 売上金額（税抜き）
            Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Header.Caption = "売上金額";
            Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName].Format = moneyFormat;

            // 売上金額（税込み）
            //Columns[this._dataSet.SalesDetail.SalesMoneyTaxIncColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesDetail.SalesMoneyTaxIncColumn.ColumnName].Header.Caption = "売上金額";
            //Columns[this._dataSet.SalesDetail.SalesMoneyTaxIncColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesDetail.SalesMoneyTaxIncColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //Columns[this._dataSet.SalesDetail.SalesMoneyTaxIncColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //Columns[this._dataSet.SalesDetail.SalesMoneyTaxIncColumn.ColumnName].Format = moneyFormat;

            // 消費税
            Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].Header.Caption = "消費税";
            Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName].Format = moneyFormat;

            // 原価単価
            Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Hidden = false;
            // 2008.11.10 modify start [7532]
            //Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Header.Caption = "原価単価";
            Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Header.Caption = "原単価";
            // 2008.11.10 modify end [7532]
            Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesDetail.SalesUnitCostColumn.ColumnName].Format = doubleFormat;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
            // 原価金額
            Columns[this._dataSet.SalesDetail.SalesCostColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.SalesCostColumn.ColumnName].Header.Caption = "原価金額";
            Columns[this._dataSet.SalesDetail.SalesCostColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
            //Columns[this._dataSet.SalesDetail.SalesCostColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
            Columns[this._dataSet.SalesDetail.SalesCostColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
            Columns[this._dataSet.SalesDetail.SalesCostColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //Columns[this._dataSet.SalesDetail.SalesCostColumn.ColumnName].Format = doubleFormat;
            Columns[this._dataSet.SalesDetail.SalesCostColumn.ColumnName].Format = moneyFormat;

            // 管理番号
            Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].Header.Caption = "管理番号";
            Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.CarMngCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 類別型式
            Columns[this._dataSet.SalesDetail.ModelCategoryNoColumn.ColumnName].Hidden = false;
            // 2008.11.10 modify start [7531]
            Columns[this._dataSet.SalesDetail.ModelCategoryNoColumn.ColumnName].Header.Caption = "類別型式";
            // 2008.11.10 modify end [7531]
            Columns[this._dataSet.SalesDetail.ModelCategoryNoColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.ModelCategoryNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.ModelCategoryNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            
            // 車種
            Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].Header.Caption = "車種";
            Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.ModelFullNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 型式
            Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].Header.Caption = "型式";
            Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.FullModelColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA DEL START
			//単位
            //Columns[this._dataSet.SalesDetail.UnitNameColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesDetail.UnitNameColumn.ColumnName].Header.Caption = "単位";
            //Columns[this._dataSet.SalesDetail.UnitNameColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesDetail.UnitNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._dataSet.SalesDetail.UnitNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

			//特値区分(特売区分名称)
            //Columns[this._dataSet.SalesDetail.BargainNmColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesDetail.BargainNmColumn.ColumnName].Header.Caption = "特値区分";
            //Columns[this._dataSet.SalesDetail.BargainNmColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesDetail.BargainNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //Columns[this._dataSet.SalesDetail.BargainNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

			//得意先注番
            //Columns[this._dataSet.SalesDetail.PartySlipNumDtlColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesDetail.PartySlipNumDtlColumn.ColumnName].Header.Caption = "得意先注番";
            //Columns[this._dataSet.SalesDetail.PartySlipNumDtlColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesDetail.PartySlipNumDtlColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._dataSet.SalesDetail.PartySlipNumDtlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA DEL END

            // 倉庫名
            Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].Header.Caption = "倉庫名";
            Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.WarehouseNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 明細備考
            Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Header.Caption = "明細備考";
            Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.DtlNoteColumn.ColumnName].Header.VisiblePosition = visiblePosition++;


            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
            // 赤伝区分
            Columns[this._dataSet.SalesDetail.DebitNoteDivStringColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.DebitNoteDivStringColumn.ColumnName].Header.Caption = "赤黒";
            Columns[this._dataSet.SalesDetail.DebitNoteDivStringColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.DebitNoteDivStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.DebitNoteDivStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END

            // 売上商品区分名(0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動),11:相殺,12:相殺(自動))
            Columns[this._dataSet.SalesDetail.SalesGoodsCdStringColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.SalesGoodsCdStringColumn.ColumnName].Header.Caption = "商品区分";
            Columns[this._dataSet.SalesDetail.SalesGoodsCdStringColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
            //Columns[this._dataSet.SalesDetail.SalesGoodsCdStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
            Columns[this._dataSet.SalesDetail.SalesGoodsCdStringColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
            Columns[this._dataSet.SalesDetail.SalesGoodsCdStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
            // 入力日
            Columns[this._dataSet.SalesDetail.SearchSlipDateColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.SearchSlipDateColumn.ColumnName].Header.Caption = "入力日";
            Columns[this._dataSet.SalesDetail.SearchSlipDateColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
            //Columns[this._dataSet.SalesDetail.SearchSlipDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
            Columns[this._dataSet.SalesDetail.SearchSlipDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
            Columns[this._dataSet.SalesDetail.SearchSlipDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesDetail.SearchSlipDateColumn.ColumnName].Format = dateFormat;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END

            // 出荷日
            Columns[this._dataSet.SalesDetail.ShipmentDayColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.ShipmentDayColumn.ColumnName].Header.Caption = "貸出日"; //出荷日"; [8919]
            Columns[this._dataSet.SalesDetail.ShipmentDayColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
            //Columns[this._dataSet.SalesDetail.ShipmentDayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
            Columns[this._dataSet.SalesDetail.ShipmentDayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
            Columns[this._dataSet.SalesDetail.ShipmentDayColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesDetail.ShipmentDayColumn.ColumnName].Format = dateFormat;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA ADD START
            // 計上日
            Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].Header.Caption = "計上日";
            Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
            //Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
            Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
            Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._dataSet.SalesDetail.AddUpADateColumn.ColumnName].Format = dateFormat;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA ADD END

            // 拠点名
            Columns[this._dataSet.SalesDetail.SectionGuideNmColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.SectionGuideNmColumn.ColumnName].Header.Caption = "拠点名";
            Columns[this._dataSet.SalesDetail.SectionGuideNmColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.SectionGuideNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.SectionGuideNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 部門名
            // 2008.11.10 modify start [7526]
            //if (this._secMngDiv != DIV_MNG_DIVITION) // 拠点でなければ表示
            //{
            Columns[this._dataSet.SalesDetail.SubSectionNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.SubSectionNameColumn.ColumnName].Header.Caption = "部門名";
            Columns[this._dataSet.SalesDetail.SubSectionNameColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.SubSectionNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.SubSectionNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //}
            // 2008.11.10 modify end [7526]

            // 請求先コード
            Columns[this._dataSet.SalesDetail.ClaimCodeColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.ClaimCodeColumn.ColumnName].Header.Caption = "請求先";
            Columns[this._dataSet.SalesDetail.ClaimCodeColumn.ColumnName].Width = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
            //Columns[this._dataSet.SalesDetail.ClaimCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
            Columns[this._dataSet.SalesDetail.ClaimCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._dataSet.SalesDetail.ClaimCodeColumn.ColumnName].Format = GetCustomerCodeFormat();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
            Columns[this._dataSet.SalesDetail.ClaimCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 DEL
            //Columns[this._dataSet.SalesDetail.ClaimCodeColumn.ColumnName].Format = codeFormat;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 DEL

            // 請求先名
            Columns[this._dataSet.SalesDetail.ClaimSnmColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.ClaimSnmColumn.ColumnName].Header.Caption = "請求先名";
            Columns[this._dataSet.SalesDetail.ClaimSnmColumn.ColumnName].Width = 100;
            Columns[this._dataSet.SalesDetail.ClaimSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.ClaimSnmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // メモ
            Columns[this._dataSet.SalesDetail.MemoExistNameColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.MemoExistNameColumn.ColumnName].Header.Caption = "メモ";
            Columns[this._dataSet.SalesDetail.MemoExistNameColumn.ColumnName].Width = 70;
            Columns[this._dataSet.SalesDetail.MemoExistNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.MemoExistNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            //---ADD 2011/11/11 ------------------------------------------------------------->>>>>
            // 連携種別
            Columns[this._dataSet.SalesDetail.CooprtKindColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.CooprtKindColumn.ColumnName].Header.Caption = "連携種別";
            Columns[this._dataSet.SalesDetail.CooprtKindColumn.ColumnName].Width = 120;
            Columns[this._dataSet.SalesDetail.CooprtKindColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.CooprtKindColumn.ColumnName].Header.VisiblePosition = visiblePosition++;


            // 自動回答
            Columns[this._dataSet.SalesDetail.AutoAnswerColumn.ColumnName].Hidden = false;
            Columns[this._dataSet.SalesDetail.AutoAnswerColumn.ColumnName].Header.Caption = "自動回答";
            Columns[this._dataSet.SalesDetail.AutoAnswerColumn.ColumnName].Width = 120;
            Columns[this._dataSet.SalesDetail.AutoAnswerColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._dataSet.SalesDetail.AutoAnswerColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //---ADD 2011/11/11 -------------------------------------------------------------<<<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.22 TOKUNAGA DEL START
            ////基準単価
            //Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Header.Caption = "基準単価";
            //Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            //Columns[this._dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName].Format = doubleFormat;

            ////納品先
            //Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].Header.Caption = "納品先";
            //Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._dataSet.SalesDetail.AddresseeNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            ////納品先２
            //Columns[this._dataSet.SalesDetail.AddresseeName2Column.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesDetail.AddresseeName2Column.ColumnName].Header.Caption = "納品先２";
            //Columns[this._dataSet.SalesDetail.AddresseeName2Column.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesDetail.AddresseeName2Column.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._dataSet.SalesDetail.AddresseeName2Column.ColumnName].Header.VisiblePosition = visiblePosition++;

            ////課名
            //Columns[this._dataSet.SalesDetail.MinSectionNameColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesDetail.MinSectionNameColumn.ColumnName].Header.Caption = "課名";
            //Columns[this._dataSet.SalesDetail.MinSectionNameColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesDetail.MinSectionNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._dataSet.SalesDetail.MinSectionNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            ////一式名称
            //Columns[this._dataSet.SalesDetail.CmpltGoodsNameColumn.ColumnName].Hidden = false;
            //Columns[this._dataSet.SalesDetail.CmpltGoodsNameColumn.ColumnName].Header.Caption = "一式名称";
            //Columns[this._dataSet.SalesDetail.CmpltGoodsNameColumn.ColumnName].Width = 100;
            //Columns[this._dataSet.SalesDetail.CmpltGoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._dataSet.SalesDetail.CmpltGoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.22 TOKUNAGA DEL END

			// 固定列区切り線設定
            this.uGrid_Details.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
#if False
			// Style設定
            Columns[this._dataSet.SalesDetail.InputDayColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
#endif
		}
        
		/// <summary>
		/// グリッド行初期設定処理
		/// </summary>
		private void GridRowInitialSetting()
		{
            if (this._searchSlipAcs.GetStockSlipTableCache() == null)
            {
                this._dataSet.SalesDetail.Rows.Clear();
            }
		}

		/// <summary>
		/// 選択伝票情報設定
		/// </summary>
        public bool ReturnSelectData()
        {
            //if ((uGrid_Details.ActiveRow == null) ||
            //    (uGrid_Details.ActiveRow.Index < 0) ||
            //    (uGrid_Details.ActiveRow.Selected == false))

			if (this._searchSlipAcs.GetSelectedRowCount() == 0)
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

        // 2008.11.10 add start [7526]

        /// <summary>
        /// 全体設定を元にグリッドを再設定
        /// </summary>
        public void refreshGridLayout()
        {
            // グリッドの列コレクション
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

            // 発行者
            if (this._inpAgentDispDiv == INP_AGT_NODISP) // 表示しない
            {
                Columns[this._dataSet.SalesDetail.SalesInputNameColumn.ColumnName].Hidden = true;
            }

            // 部門名
            if (this._secMngDiv != DIV_MNG_SUBSECTION) // 部門でなければ非表示
            {
                Columns[this._dataSet.SalesDetail.SubSectionNameColumn.ColumnName].Hidden = true;
            }
        }

        // 2008.11.10 add end [7526]

        # region コントロールイベントメソッド

        /// <summary>
        /// グリッドエンターイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uGrid_Details_Enter(object sender, EventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 DEL
            //if (this.uGrid_Details.Rows.Count != 0)
            //{
            //    this.DecisionButtonEnableSet(true);
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 DEL

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
				int uniqueID = (int)(this.uGrid_Details.ActiveRow.Cells[_searchSlipAcs.DataSet.SalesDetail.NoColumn.ColumnName].Value);
				this._searchSlipAcs.SelectedPrintRow(uniqueID);

				// 選択行のインデックスを取得
				//CurrencyManager cm = (CurrencyManager)BindingContext[this.uGrid_Details.DataSource];
				//int index = cm.Position;
				
				//this._salHisRefResultParamWork = this._searchSlipAcs.GetSelectedRowData(index);
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

				this._salHisRefResultParamWork = this._searchSlipAcs.GetSelectedRowData(index);
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
					if (objCell.Column.Key == _searchSlipAcs.DataSet.SalesDetail.PrintFlagColumn.ColumnName)
					{
						int uniqueID = (int)objRow.Cells[_searchSlipAcs.DataSet.SalesDetail.NoColumn.ColumnName].Value;
						this._searchSlipAcs.SelectedPrintRow(uniqueID);
					}
				}

			}

		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                int uniqueID = (int)_row.Cells[_searchSlipAcs.DataSet.SalesDetail.NoColumn.ColumnName].Value;
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
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/23 ADD
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
        /// 得意先コードフォーマット取得
        /// </summary>
        /// <returns></returns>
        private string GetCustomerCodeFormat()
        {
            return GetCodeFormat( "tNedit_CustomerCode" );
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
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/23 ADD
        // ADD 2009/12/04 MANTIS対応[14743]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
        /// <summary>
        /// 明細情報グリッドを取得します。
        /// </summary>
        public Infragistics.Win.UltraWinGrid.UltraGrid DetailGrid
        {
            get { return this.uGrid_Details; }
        }
        // ADD 2009/12/04 MANTIS対応[14743]：伝票および明細グリッド列の列設定の変更 ----------<<<<<
	}
}

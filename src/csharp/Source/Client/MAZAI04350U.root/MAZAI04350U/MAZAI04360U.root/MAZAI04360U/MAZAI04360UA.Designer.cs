using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
	partial class MAZAI04360UA
	{
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				// グリッド設定保存
				if (_colDispInfo != null)
				{
					GettingGridColumn(this.StockGrid.DisplayLayout.Bands[AdjustStockAcs.ctTBL_AdjustStock].Columns);
					_colDispInfo.FontSize = (int)this.cmbGridFont.Value;
					_colDispInfo.SerializeData(ctFILE_ColDispInfo);
					_colDispInfo = null;
				}
/*
				// 仕入管理アクセスクラスイベントハンドラ削除
				if (this._stockMngAcs != null)
				{
					this._stockMngAcs.RemoveInfoChangeStockMngEvent(this.InfoChangeStockMngEvent);
					this._stockMngAcs.RemoveInfoNewEntryStockMngEvent(this.InfoNewEntryStockMngEvent);
				}
*/
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナで生成されたコード

		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem ultraExplorerBarItem1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem ultraExplorerBarItem2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem ultraExplorerBarItem3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("伝票ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("倉庫ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo4 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("拠点ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo5 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("従業員ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAZAI04360UA));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("明細メインメニュー");
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("備考ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            this.cmbGridFont = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.pnl_DockBase = new System.Windows.Forms.Panel();
            this.ExplorerBar_InputHelp = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.pnl_UpperBase = new System.Windows.Forms.Panel();
            this.tNedit_SupplierSlipNo = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uLabel_LastSalesSlipNum = new Infragistics.Win.Misc.UltraLabel();
            this.tLine12 = new Broadleaf.Library.Windows.Forms.TLine();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.SalesSlipGuide_uButton = new Infragistics.Win.Misc.UltraButton();
            this.WarehouseGuide_uButton = new Infragistics.Win.Misc.UltraButton();
            this.SectionGuide_uButton = new Infragistics.Win.Misc.UltraButton();
            this.uLabel_WarehouseName = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_SectionName = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_WarehouseCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_SectionCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_StockAgentName = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_EmployeeCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_EmployeeGuide = new Infragistics.Win.Misc.UltraButton();
            this.makedate_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.GoodsSearch_ultraButton = new Infragistics.Win.Misc.UltraButton();
            this.pnl_MiddleBase = new System.Windows.Forms.Panel();
            this.StockGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.PrintExtra_Panel = new System.Windows.Forms.Panel();
            this.RowDelete_ultraButton = new Infragistics.Win.Misc.UltraButton();
            this._pnl_MiddleBase_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ToolbarsManager_Main = new Broadleaf.Library.Windows.Forms.TToolbarsManager(this.components);
            this._pnl_MiddleBase_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnl_MiddleBase_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnl_MiddleBase_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.pnl_LowerBase = new System.Windows.Forms.Panel();
            this.SlipNoteGuide_uButton = new Infragistics.Win.Misc.UltraButton();
            this.lbltotalCount = new Infragistics.Win.Misc.UltraLabel();
            this.lblTotalPriceTaxIncTitle = new Infragistics.Win.Misc.UltraLabel();
            this.lblTotalPrice = new Infragistics.Win.Misc.UltraLabel();
            this.lblNoteTitle = new Infragistics.Win.Misc.UltraLabel();
            this.edtNote1 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.StatusBar_Main = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.timFontChange = new System.Windows.Forms.Timer(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cmbGridFont)).BeginInit();
            this.pnl_DockBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExplorerBar_InputHelp)).BeginInit();
            this.pnl_UpperBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierSlipNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_WarehouseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode)).BeginInit();
            this.pnl_MiddleBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StockGrid)).BeginInit();
            this.PrintExtra_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToolbarsManager_Main)).BeginInit();
            this.pnl_LowerBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtNote1)).BeginInit();
            this.StatusBar_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbGridFont
            // 
            appearance53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance53.TextHAlignAsString = "Right";
            this.cmbGridFont.ActiveAppearance = appearance53;
            appearance54.TextHAlignAsString = "Right";
            this.cmbGridFont.Appearance = appearance54;
            this.cmbGridFont.AutoSize = false;
            this.cmbGridFont.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbGridFont.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbGridFont.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance55.TextHAlignAsString = "Right";
            this.cmbGridFont.ItemAppearance = appearance55;
            valueListItem1.DataValue = 6;
            valueListItem1.DisplayText = "6";
            valueListItem2.DataValue = 8;
            valueListItem2.DisplayText = "8";
            valueListItem3.DataValue = 9;
            valueListItem3.DisplayText = "9";
            valueListItem4.DataValue = 10;
            valueListItem4.DisplayText = "10";
            valueListItem5.DataValue = 11;
            valueListItem5.DisplayText = "11";
            valueListItem6.DataValue = 12;
            valueListItem6.DisplayText = "12";
            valueListItem7.DataValue = 14;
            valueListItem7.DisplayText = "14";
            this.cmbGridFont.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3,
            valueListItem4,
            valueListItem5,
            valueListItem6,
            valueListItem7});
            this.cmbGridFont.Location = new System.Drawing.Point(76, 3);
            this.cmbGridFont.Name = "cmbGridFont";
            this.cmbGridFont.Size = new System.Drawing.Size(40, 20);
            this.cmbGridFont.TabIndex = 0;
            this.cmbGridFont.TabStop = false;
            this.cmbGridFont.ValueChanged += new System.EventHandler(this.cmbGridFont_ValueChanged);
            // 
            // pnl_DockBase
            // 
            this.pnl_DockBase.Controls.Add(this.ExplorerBar_InputHelp);
            this.pnl_DockBase.Location = new System.Drawing.Point(220, 55);
            this.pnl_DockBase.Name = "pnl_DockBase";
            this.pnl_DockBase.Size = new System.Drawing.Size(200, 100);
            this.pnl_DockBase.TabIndex = 5;
            // 
            // ExplorerBar_InputHelp
            // 
            this.ExplorerBar_InputHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            ultraExplorerBarItem1.Key = "PartsQuickSearch";
            ultraExplorerBarItem1.Text = "部品クイック検索";
            ultraExplorerBarItem2.Key = "TSPResponseDataImport";
            appearance56.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            ultraExplorerBarItem2.Settings.AppearancesLarge.ActiveAppearance = appearance56;
            ultraExplorerBarItem2.Text = "TSP回答データ取込";
            ultraExplorerBarItem3.Key = "TSPBarcodeInput";
            ultraExplorerBarItem3.Text = "TSPバーコード入力";
            ultraExplorerBarGroup1.Items.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem[] {
            ultraExplorerBarItem1,
            ultraExplorerBarItem2,
            ultraExplorerBarItem3});
            ultraExplorerBarGroup1.Key = "InputHelper";
            appearance57.BackColor = System.Drawing.Color.Lavender;
            appearance57.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            appearance57.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            ultraExplorerBarGroup1.Settings.AppearancesLarge.Appearance = appearance57;
            ultraExplorerBarGroup1.Settings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.LargeImagesWithText;
            ultraExplorerBarGroup1.Text = "入力補助";
            this.ExplorerBar_InputHelp.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1});
            this.ExplorerBar_InputHelp.GroupSettings.AllowDrag = Infragistics.Win.DefaultableBoolean.False;
            this.ExplorerBar_InputHelp.GroupSettings.AllowEdit = Infragistics.Win.DefaultableBoolean.False;
            this.ExplorerBar_InputHelp.GroupSettings.AllowItemDrop = Infragistics.Win.DefaultableBoolean.False;
            this.ExplorerBar_InputHelp.GroupSettings.AllowItemUncheck = Infragistics.Win.DefaultableBoolean.False;
            appearance58.FontData.BoldAsString = "True";
            this.ExplorerBar_InputHelp.ItemSettings.AppearancesLarge.Appearance = appearance58;
            appearance59.FontData.UnderlineAsString = "True";
            this.ExplorerBar_InputHelp.ItemSettings.AppearancesLarge.HotTrackAppearance = appearance59;
            appearance8.FontData.BoldAsString = "True";
            appearance8.FontData.Name = "ＭＳ ゴシック";
            appearance8.FontData.SizeInPoints = 11F;
            this.ExplorerBar_InputHelp.ItemSettings.AppearancesSmall.Appearance = appearance8;
            appearance9.FontData.UnderlineAsString = "True";
            this.ExplorerBar_InputHelp.ItemSettings.AppearancesSmall.HotTrackAppearance = appearance9;
            this.ExplorerBar_InputHelp.Location = new System.Drawing.Point(0, 0);
            this.ExplorerBar_InputHelp.Margins.Bottom = 0;
            this.ExplorerBar_InputHelp.Margins.Left = 0;
            this.ExplorerBar_InputHelp.Margins.Right = 0;
            this.ExplorerBar_InputHelp.Margins.Top = 0;
            this.ExplorerBar_InputHelp.Name = "ExplorerBar_InputHelp";
            this.ExplorerBar_InputHelp.ShowDefaultContextMenu = false;
            this.ExplorerBar_InputHelp.Size = new System.Drawing.Size(200, 100);
            this.ExplorerBar_InputHelp.Style = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarStyle.Listbar;
            this.ExplorerBar_InputHelp.TabIndex = 0;
            this.ExplorerBar_InputHelp.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.Office2003;
            this.ExplorerBar_InputHelp.ItemClick += new Infragistics.Win.UltraWinExplorerBar.ItemClickEventHandler(this.ExplorerBar_InputHelp_ItemClick);
            // 
            // pnl_UpperBase
            // 
            this.pnl_UpperBase.Controls.Add(this.tNedit_SupplierSlipNo);
            this.pnl_UpperBase.Controls.Add(this.uLabel_LastSalesSlipNum);
            this.pnl_UpperBase.Controls.Add(this.tLine12);
            this.pnl_UpperBase.Controls.Add(this.ultraLabel8);
            this.pnl_UpperBase.Controls.Add(this.SalesSlipGuide_uButton);
            this.pnl_UpperBase.Controls.Add(this.WarehouseGuide_uButton);
            this.pnl_UpperBase.Controls.Add(this.SectionGuide_uButton);
            this.pnl_UpperBase.Controls.Add(this.uLabel_WarehouseName);
            this.pnl_UpperBase.Controls.Add(this.uLabel_SectionName);
            this.pnl_UpperBase.Controls.Add(this.tEdit_WarehouseCode);
            this.pnl_UpperBase.Controls.Add(this.tEdit_SectionCode);
            this.pnl_UpperBase.Controls.Add(this.ultraLabel3);
            this.pnl_UpperBase.Controls.Add(this.ultraLabel2);
            this.pnl_UpperBase.Controls.Add(this.ultraLabel1);
            this.pnl_UpperBase.Controls.Add(this.uLabel_StockAgentName);
            this.pnl_UpperBase.Controls.Add(this.tEdit_EmployeeCode);
            this.pnl_UpperBase.Controls.Add(this.ultraLabel4);
            this.pnl_UpperBase.Controls.Add(this.uButton_EmployeeGuide);
            this.pnl_UpperBase.Controls.Add(this.makedate_tDateEdit);
            this.pnl_UpperBase.Controls.Add(this.ultraLabel6);
            this.pnl_UpperBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_UpperBase.Location = new System.Drawing.Point(0, 0);
            this.pnl_UpperBase.Name = "pnl_UpperBase";
            this.pnl_UpperBase.Size = new System.Drawing.Size(1012, 104);
            this.pnl_UpperBase.TabIndex = 1;
            // 
            // tNedit_SupplierSlipNo
            // 
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance21.ForeColor = System.Drawing.Color.Black;
            this.tNedit_SupplierSlipNo.ActiveAppearance = appearance21;
            appearance22.ForeColorDisabled = System.Drawing.Color.Black;
            this.tNedit_SupplierSlipNo.Appearance = appearance22;
            this.tNedit_SupplierSlipNo.AutoSelect = true;
            this.tNedit_SupplierSlipNo.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierSlipNo.DataText = "";
            this.tNedit_SupplierSlipNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierSlipNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_SupplierSlipNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SupplierSlipNo.Location = new System.Drawing.Point(503, 10);
            this.tNedit_SupplierSlipNo.MaxLength = 12;
            this.tNedit_SupplierSlipNo.Name = "tNedit_SupplierSlipNo";
            this.tNedit_SupplierSlipNo.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_SupplierSlipNo.Size = new System.Drawing.Size(82, 24);
            this.tNedit_SupplierSlipNo.TabIndex = 1;
            // 
            // uLabel_LastSalesSlipNum
            // 
            appearance47.TextVAlignAsString = "Bottom";
            this.uLabel_LastSalesSlipNum.Appearance = appearance47;
            this.uLabel_LastSalesSlipNum.Location = new System.Drawing.Point(795, 10);
            this.uLabel_LastSalesSlipNum.Name = "uLabel_LastSalesSlipNum";
            this.uLabel_LastSalesSlipNum.Size = new System.Drawing.Size(78, 19);
            this.uLabel_LastSalesSlipNum.TabIndex = 1208;
            // 
            // tLine12
            // 
            this.tLine12.BackColor = System.Drawing.Color.Transparent;
            this.tLine12.Location = new System.Drawing.Point(795, 30);
            this.tLine12.Name = "tLine12";
            this.tLine12.Size = new System.Drawing.Size(77, 8);
            this.tLine12.TabIndex = 1207;
            this.tLine12.Text = "tLine12";
            // 
            // ultraLabel8
            // 
            appearance48.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance48;
            this.ultraLabel8.Location = new System.Drawing.Point(649, 10);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(146, 24);
            this.ultraLabel8.TabIndex = 1206;
            this.ultraLabel8.Text = "前回保存伝票番号：";
            // 
            // SalesSlipGuide_uButton
            // 
            appearance46.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance46.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.SalesSlipGuide_uButton.Appearance = appearance46;
            this.SalesSlipGuide_uButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SalesSlipGuide_uButton.Location = new System.Drawing.Point(591, 10);
            this.SalesSlipGuide_uButton.Name = "SalesSlipGuide_uButton";
            this.SalesSlipGuide_uButton.Size = new System.Drawing.Size(24, 24);
            this.SalesSlipGuide_uButton.TabIndex = 2;
            ultraToolTipInfo2.ToolTipText = "伝票ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.SalesSlipGuide_uButton, ultraToolTipInfo2);
            this.SalesSlipGuide_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesSlipGuide_uButton.Click += new System.EventHandler(this.SalesSlipGuide_uButton_Click);
            // 
            // WarehouseGuide_uButton
            // 
            appearance14.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance14.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.WarehouseGuide_uButton.Appearance = appearance14;
            this.WarehouseGuide_uButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.WarehouseGuide_uButton.Location = new System.Drawing.Point(381, 70);
            this.WarehouseGuide_uButton.Name = "WarehouseGuide_uButton";
            this.WarehouseGuide_uButton.Size = new System.Drawing.Size(24, 24);
            this.WarehouseGuide_uButton.TabIndex = 6;
            ultraToolTipInfo3.ToolTipText = "倉庫ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.WarehouseGuide_uButton, ultraToolTipInfo3);
            this.WarehouseGuide_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.WarehouseGuide_uButton.Click += new System.EventHandler(this.WarehouseGuide_uButton_Click);
            // 
            // SectionGuide_uButton
            // 
            appearance41.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance41.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.SectionGuide_uButton.Appearance = appearance41;
            this.SectionGuide_uButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SectionGuide_uButton.Location = new System.Drawing.Point(381, 40);
            this.SectionGuide_uButton.Name = "SectionGuide_uButton";
            this.SectionGuide_uButton.Size = new System.Drawing.Size(24, 24);
            this.SectionGuide_uButton.TabIndex = 4;
            ultraToolTipInfo4.ToolTipText = "拠点ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.SectionGuide_uButton, ultraToolTipInfo4);
            this.SectionGuide_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SectionGuide_uButton.Click += new System.EventHandler(this.SectionGuide_uButton_Click);
            // 
            // uLabel_WarehouseName
            // 
            appearance10.BackColor = System.Drawing.Color.Gainsboro;
            appearance10.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance10.TextHAlignAsString = "Left";
            appearance10.TextVAlignAsString = "Middle";
            this.uLabel_WarehouseName.Appearance = appearance10;
            this.uLabel_WarehouseName.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_WarehouseName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_WarehouseName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.uLabel_WarehouseName.Location = new System.Drawing.Point(133, 70);
            this.uLabel_WarehouseName.Name = "uLabel_WarehouseName";
            this.uLabel_WarehouseName.Size = new System.Drawing.Size(242, 24);
            this.uLabel_WarehouseName.TabIndex = 1201;
            this.uLabel_WarehouseName.WrapText = false;
            // 
            // uLabel_SectionName
            // 
            appearance42.BackColor = System.Drawing.Color.Gainsboro;
            appearance42.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance42.TextHAlignAsString = "Left";
            appearance42.TextVAlignAsString = "Middle";
            this.uLabel_SectionName.Appearance = appearance42;
            this.uLabel_SectionName.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_SectionName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_SectionName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.uLabel_SectionName.Location = new System.Drawing.Point(133, 40);
            this.uLabel_SectionName.Name = "uLabel_SectionName";
            this.uLabel_SectionName.Size = new System.Drawing.Size(242, 24);
            this.uLabel_SectionName.TabIndex = 1200;
            this.uLabel_SectionName.WrapText = false;
            // 
            // tEdit_WarehouseCode
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_WarehouseCode.ActiveAppearance = appearance11;
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance12.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_WarehouseCode.Appearance = appearance12;
            this.tEdit_WarehouseCode.AutoSelect = true;
            this.tEdit_WarehouseCode.AutoSize = false;
            this.tEdit_WarehouseCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_WarehouseCode.DataText = "";
            this.tEdit_WarehouseCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_WarehouseCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.tEdit_WarehouseCode.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_WarehouseCode.Location = new System.Drawing.Point(75, 70);
            this.tEdit_WarehouseCode.MaxLength = 9;
            this.tEdit_WarehouseCode.Name = "tEdit_WarehouseCode";
            this.tEdit_WarehouseCode.Size = new System.Drawing.Size(51, 24);
            this.tEdit_WarehouseCode.TabIndex = 5;
            // 
            // tEdit_SectionCode
            // 
            appearance39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SectionCode.ActiveAppearance = appearance39;
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance40.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_SectionCode.Appearance = appearance40;
            this.tEdit_SectionCode.AutoSelect = true;
            this.tEdit_SectionCode.AutoSize = false;
            this.tEdit_SectionCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCode.DataText = "";
            this.tEdit_SectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.tEdit_SectionCode.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_SectionCode.Location = new System.Drawing.Point(75, 40);
            this.tEdit_SectionCode.MaxLength = 9;
            this.tEdit_SectionCode.Name = "tEdit_SectionCode";
            this.tEdit_SectionCode.Size = new System.Drawing.Size(51, 24);
            this.tEdit_SectionCode.TabIndex = 3;
            // 
            // ultraLabel3
            // 
            appearance49.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance49;
            this.ultraLabel3.Location = new System.Drawing.Point(420, 10);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(77, 24);
            this.ultraLabel3.TabIndex = 1197;
            this.ultraLabel3.Text = "伝票番号";
            // 
            // ultraLabel2
            // 
            appearance37.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance37;
            this.ultraLabel2.Location = new System.Drawing.Point(10, 70);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(60, 24);
            this.ultraLabel2.TabIndex = 1196;
            this.ultraLabel2.Text = "倉庫";
            // 
            // ultraLabel1
            // 
            appearance38.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance38;
            this.ultraLabel1.Location = new System.Drawing.Point(10, 40);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(60, 24);
            this.ultraLabel1.TabIndex = 1195;
            this.ultraLabel1.Text = "拠点";
            // 
            // uLabel_StockAgentName
            // 
            appearance43.BackColor = System.Drawing.Color.Gainsboro;
            appearance43.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance43.TextHAlignAsString = "Left";
            appearance43.TextVAlignAsString = "Middle";
            this.uLabel_StockAgentName.Appearance = appearance43;
            this.uLabel_StockAgentName.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_StockAgentName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_StockAgentName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.uLabel_StockAgentName.Location = new System.Drawing.Point(558, 70);
            this.uLabel_StockAgentName.Name = "uLabel_StockAgentName";
            this.uLabel_StockAgentName.Size = new System.Drawing.Size(320, 24);
            this.uLabel_StockAgentName.TabIndex = 1194;
            this.uLabel_StockAgentName.WrapText = false;
            // 
            // tEdit_EmployeeCode
            // 
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_EmployeeCode.ActiveAppearance = appearance44;
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance45.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_EmployeeCode.Appearance = appearance45;
            this.tEdit_EmployeeCode.AutoSelect = true;
            this.tEdit_EmployeeCode.AutoSize = false;
            this.tEdit_EmployeeCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_EmployeeCode.DataText = "";
            this.tEdit_EmployeeCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_EmployeeCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.tEdit_EmployeeCode.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_EmployeeCode.Location = new System.Drawing.Point(500, 70);
            this.tEdit_EmployeeCode.MaxLength = 9;
            this.tEdit_EmployeeCode.Name = "tEdit_EmployeeCode";
            this.tEdit_EmployeeCode.Size = new System.Drawing.Size(51, 24);
            this.tEdit_EmployeeCode.TabIndex = 7;
            // 
            // ultraLabel4
            // 
            appearance13.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance13;
            this.ultraLabel4.Location = new System.Drawing.Point(420, 70);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(67, 24);
            this.ultraLabel4.TabIndex = 1193;
            this.ultraLabel4.Text = "入力担当";
            // 
            // uButton_EmployeeGuide
            // 
            appearance15.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance15.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_EmployeeGuide.Appearance = appearance15;
            this.uButton_EmployeeGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_EmployeeGuide.Location = new System.Drawing.Point(884, 70);
            this.uButton_EmployeeGuide.Name = "uButton_EmployeeGuide";
            this.uButton_EmployeeGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_EmployeeGuide.TabIndex = 8;
            ultraToolTipInfo5.ToolTipText = "従業員ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.uButton_EmployeeGuide, ultraToolTipInfo5);
            this.uButton_EmployeeGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_EmployeeGuide.Click += new System.EventHandler(this.uButton_EmployeeGuide_Click);
            // 
            // makedate_tDateEdit
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.makedate_tDateEdit.ActiveEditAppearance = appearance17;
            this.makedate_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.makedate_tDateEdit.CalendarDisp = true;
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance18.ForeColorDisabled = System.Drawing.Color.Black;
            appearance18.TextHAlignAsString = "Left";
            appearance18.TextVAlignAsString = "Middle";
            this.makedate_tDateEdit.EditAppearance = appearance18;
            this.makedate_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.makedate_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance19.TextHAlignAsString = "Left";
            appearance19.TextVAlignAsString = "Middle";
            this.makedate_tDateEdit.LabelAppearance = appearance19;
            this.makedate_tDateEdit.Location = new System.Drawing.Point(75, 10);
            this.makedate_tDateEdit.Name = "makedate_tDateEdit";
            this.makedate_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.makedate_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, true, true);
            this.makedate_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.makedate_tDateEdit.TabIndex = 0;
            this.makedate_tDateEdit.TabStop = true;
            // 
            // ultraLabel6
            // 
            appearance16.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance16;
            this.ultraLabel6.Location = new System.Drawing.Point(10, 10);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(60, 24);
            this.ultraLabel6.TabIndex = 61;
            this.ultraLabel6.Text = "仕入日";
            // 
            // GoodsSearch_ultraButton
            // 
            this.GoodsSearch_ultraButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance20.Image = ((object)(resources.GetObject("appearance20.Image")));
            this.GoodsSearch_ultraButton.Appearance = appearance20;
            this.GoodsSearch_ultraButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GoodsSearch_ultraButton.ImageTransparentColor = System.Drawing.Color.Cyan;
            this.GoodsSearch_ultraButton.Location = new System.Drawing.Point(910, 3);
            this.GoodsSearch_ultraButton.Name = "GoodsSearch_ultraButton";
            this.GoodsSearch_ultraButton.Size = new System.Drawing.Size(98, 33);
            this.GoodsSearch_ultraButton.TabIndex = 63;
            this.GoodsSearch_ultraButton.Text = "在庫検索(&R)";
            this.GoodsSearch_ultraButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.GoodsSearch_ultraButton.Click += new System.EventHandler(this.Performed_uButton_Click);
            // 
            // pnl_MiddleBase
            // 
            this.pnl_MiddleBase.Controls.Add(this.StockGrid);
            this.pnl_MiddleBase.Controls.Add(this.PrintExtra_Panel);
            this.pnl_MiddleBase.Controls.Add(this._pnl_MiddleBase_Toolbars_Dock_Area_Left);
            this.pnl_MiddleBase.Controls.Add(this._pnl_MiddleBase_Toolbars_Dock_Area_Right);
            this.pnl_MiddleBase.Controls.Add(this._pnl_MiddleBase_Toolbars_Dock_Area_Top);
            this.pnl_MiddleBase.Controls.Add(this._pnl_MiddleBase_Toolbars_Dock_Area_Bottom);
            this.pnl_MiddleBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_MiddleBase.Location = new System.Drawing.Point(0, 104);
            this.pnl_MiddleBase.Name = "pnl_MiddleBase";
            this.pnl_MiddleBase.Size = new System.Drawing.Size(1012, 546);
            this.pnl_MiddleBase.TabIndex = 10;
            // 
            // StockGrid
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.StockGrid.DisplayLayout.Appearance = appearance1;
            this.StockGrid.DisplayLayout.GroupByBox.Hidden = true;
            this.StockGrid.DisplayLayout.InterBandSpacing = 10;
            this.StockGrid.DisplayLayout.MaxColScrollRegions = 1;
            this.StockGrid.DisplayLayout.MaxRowScrollRegions = 1;
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.StockGrid.DisplayLayout.Override.ActiveCellAppearance = appearance2;
            this.StockGrid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.StockGrid.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.StockGrid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.StockGrid.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.StockGrid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.StockGrid.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.False;
            this.StockGrid.DisplayLayout.Override.AllowGroupMoving = Infragistics.Win.UltraWinGrid.AllowGroupMoving.NotAllowed;
            this.StockGrid.DisplayLayout.Override.AllowGroupSwapping = Infragistics.Win.UltraWinGrid.AllowGroupSwapping.NotAllowed;
            this.StockGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.StockGrid.DisplayLayout.Override.AllowRowLayoutCellSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            this.StockGrid.DisplayLayout.Override.AllowRowLayoutCellSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.StockGrid.DisplayLayout.Override.AllowRowLayoutColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.None;
            this.StockGrid.DisplayLayout.Override.AllowRowLayoutLabelSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            this.StockGrid.DisplayLayout.Override.AllowRowLayoutLabelSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.StockGrid.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.StockGrid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.StockGrid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit;
            this.StockGrid.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.TextHAlignAsString = "Center";
            appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.StockGrid.DisplayLayout.Override.HeaderAppearance = appearance3;
            appearance4.BackColor = System.Drawing.Color.Lavender;
            this.StockGrid.DisplayLayout.Override.RowAlternateAppearance = appearance4;
            appearance5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance5.TextVAlignAsString = "Middle";
            this.StockGrid.DisplayLayout.Override.RowAppearance = appearance5;
            this.StockGrid.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.StockGrid.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.ForeColor = System.Drawing.Color.White;
            this.StockGrid.DisplayLayout.Override.RowSelectorAppearance = appearance6;
            this.StockGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.StockGrid.DisplayLayout.Override.RowSelectorWidth = 20;
            this.StockGrid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance7.ForeColor = System.Drawing.Color.Black;
            this.StockGrid.DisplayLayout.Override.SelectedRowAppearance = appearance7;
            this.StockGrid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.StockGrid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.StockGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.ExtendedAutoDrag;
            this.StockGrid.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.StockGrid.DisplayLayout.Override.TipStyleRowConnector = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.StockGrid.DisplayLayout.Override.TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.StockGrid.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.StockGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.StockGrid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.StockGrid.DisplayLayout.UseFixedHeaders = true;
            this.StockGrid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.StockGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StockGrid.Location = new System.Drawing.Point(0, 40);
            this.StockGrid.Name = "StockGrid";
            this.StockGrid.Size = new System.Drawing.Size(1012, 506);
            this.StockGrid.TabIndex = 12;
            this.StockGrid.BeforeCellUpdate += new Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventHandler(this.StockGrid_BeforeCellUpdate);
            this.StockGrid.AfterExitEditMode += new System.EventHandler(this.StockGrid_AfterExitEditMode);
            this.StockGrid.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.StockGrid_InitializeLayout);
            this.StockGrid.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.StockGrid_AfterSelectChange);
            this.StockGrid.BeforeExitEditMode += new Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventHandler(this.StockGrid_BeforeExitEditMode);
            this.StockGrid.AfterEnterEditMode += new System.EventHandler(this.StockGrid_AfterEnterEditMode);
            this.StockGrid.CellDataError += new Infragistics.Win.UltraWinGrid.CellDataErrorEventHandler(this.StockGrid_CellDataError);
            this.StockGrid.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.StockGrid_AfterCellUpdate);
            this.StockGrid.Enter += new System.EventHandler(this.StockGrid_Enter);
            this.StockGrid.AfterRowActivate += new System.EventHandler(this.StockGrid_AfterRowActivate);
            this.StockGrid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StockGrid_KeyPress);
            this.StockGrid.AfterPerformAction += new Infragistics.Win.UltraWinGrid.AfterUltraGridPerformActionEventHandler(this.StockGrid_AfterPerformAction);
            this.StockGrid.Leave += new System.EventHandler(this.StockGrid_Leave);
            this.StockGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StockGrid_KeyDown);
            this.StockGrid.BeforeCellActivate += new Infragistics.Win.UltraWinGrid.CancelableCellEventHandler(this.StockGrid_BeforeCellActivate);
            this.StockGrid.AfterCellActivate += new System.EventHandler(this.StockGrid_AfterCellActivate);
            // 
            // PrintExtra_Panel
            // 
            this.PrintExtra_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PrintExtra_Panel.Controls.Add(this.RowDelete_ultraButton);
            this.PrintExtra_Panel.Controls.Add(this.GoodsSearch_ultraButton);
            this.PrintExtra_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PrintExtra_Panel.Location = new System.Drawing.Point(0, 0);
            this.PrintExtra_Panel.Name = "PrintExtra_Panel";
            this.PrintExtra_Panel.Size = new System.Drawing.Size(1012, 40);
            this.PrintExtra_Panel.TabIndex = 7;
            // 
            // RowDelete_ultraButton
            // 
            this.RowDelete_ultraButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RowDelete_ultraButton.Location = new System.Drawing.Point(3, 3);
            this.RowDelete_ultraButton.Name = "RowDelete_ultraButton";
            this.RowDelete_ultraButton.Size = new System.Drawing.Size(74, 33);
            this.RowDelete_ultraButton.TabIndex = 4;
            this.RowDelete_ultraButton.Text = "削除(&D)";
            this.RowDelete_ultraButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.RowDelete_ultraButton.Click += new System.EventHandler(this.RowDelete_ultraButton_Click);
            // 
            // _pnl_MiddleBase_Toolbars_Dock_Area_Left
            // 
            this._pnl_MiddleBase_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnl_MiddleBase_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._pnl_MiddleBase_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._pnl_MiddleBase_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnl_MiddleBase_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 0);
            this._pnl_MiddleBase_Toolbars_Dock_Area_Left.Name = "_pnl_MiddleBase_Toolbars_Dock_Area_Left";
            this._pnl_MiddleBase_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 546);
            this._pnl_MiddleBase_Toolbars_Dock_Area_Left.ToolbarsManager = this.ToolbarsManager_Main;
            // 
            // ToolbarsManager_Main
            // 
            this.ToolbarsManager_Main.DesignerFlags = 0;
            this.ToolbarsManager_Main.DockWithinContainer = this.pnl_MiddleBase;
            this.ToolbarsManager_Main.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.ToolbarsManager_Main.ShowFullMenusDelay = 500;
            this.ToolbarsManager_Main.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.Text = "明細メインメニュー";
            ultraToolbar1.Visible = false;
            this.ToolbarsManager_Main.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            this.ToolbarsManager_Main.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.ToolbarsManager_Main_ToolClick);
            this.ToolbarsManager_Main.AfterToolCloseup += new Infragistics.Win.UltraWinToolbars.ToolDropdownEventHandler(this.ToolbarsManager_Main_AfterToolCloseup);
            this.ToolbarsManager_Main.BeforeToolDropdown += new Infragistics.Win.UltraWinToolbars.BeforeToolDropdownEventHandler(this.ToolbarsManager_Main_BeforeToolDropdown);
            // 
            // _pnl_MiddleBase_Toolbars_Dock_Area_Right
            // 
            this._pnl_MiddleBase_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnl_MiddleBase_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._pnl_MiddleBase_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._pnl_MiddleBase_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnl_MiddleBase_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1012, 0);
            this._pnl_MiddleBase_Toolbars_Dock_Area_Right.Name = "_pnl_MiddleBase_Toolbars_Dock_Area_Right";
            this._pnl_MiddleBase_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 546);
            this._pnl_MiddleBase_Toolbars_Dock_Area_Right.ToolbarsManager = this.ToolbarsManager_Main;
            // 
            // _pnl_MiddleBase_Toolbars_Dock_Area_Top
            // 
            this._pnl_MiddleBase_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnl_MiddleBase_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._pnl_MiddleBase_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._pnl_MiddleBase_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnl_MiddleBase_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._pnl_MiddleBase_Toolbars_Dock_Area_Top.Name = "_pnl_MiddleBase_Toolbars_Dock_Area_Top";
            this._pnl_MiddleBase_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1012, 0);
            this._pnl_MiddleBase_Toolbars_Dock_Area_Top.ToolbarsManager = this.ToolbarsManager_Main;
            // 
            // _pnl_MiddleBase_Toolbars_Dock_Area_Bottom
            // 
            this._pnl_MiddleBase_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnl_MiddleBase_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._pnl_MiddleBase_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._pnl_MiddleBase_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnl_MiddleBase_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 546);
            this._pnl_MiddleBase_Toolbars_Dock_Area_Bottom.Name = "_pnl_MiddleBase_Toolbars_Dock_Area_Bottom";
            this._pnl_MiddleBase_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1012, 0);
            this._pnl_MiddleBase_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ToolbarsManager_Main;
            // 
            // pnl_LowerBase
            // 
            this.pnl_LowerBase.Controls.Add(this.SlipNoteGuide_uButton);
            this.pnl_LowerBase.Controls.Add(this.lbltotalCount);
            this.pnl_LowerBase.Controls.Add(this.lblTotalPriceTaxIncTitle);
            this.pnl_LowerBase.Controls.Add(this.lblTotalPrice);
            this.pnl_LowerBase.Controls.Add(this.lblNoteTitle);
            this.pnl_LowerBase.Controls.Add(this.edtNote1);
            this.pnl_LowerBase.Controls.Add(this.StatusBar_Main);
            this.pnl_LowerBase.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_LowerBase.Location = new System.Drawing.Point(0, 650);
            this.pnl_LowerBase.Name = "pnl_LowerBase";
            this.pnl_LowerBase.Size = new System.Drawing.Size(1012, 84);
            this.pnl_LowerBase.TabIndex = 20;
            // 
            // SlipNoteGuide_uButton
            // 
            appearance50.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance50.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.SlipNoteGuide_uButton.Appearance = appearance50;
            this.SlipNoteGuide_uButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SlipNoteGuide_uButton.Location = new System.Drawing.Point(531, 5);
            this.SlipNoteGuide_uButton.Name = "SlipNoteGuide_uButton";
            this.SlipNoteGuide_uButton.Size = new System.Drawing.Size(24, 24);
            this.SlipNoteGuide_uButton.TabIndex = 2;
            ultraToolTipInfo1.ToolTipText = "備考ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.SlipNoteGuide_uButton, ultraToolTipInfo1);
            this.SlipNoteGuide_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SlipNoteGuide_uButton.Click += new System.EventHandler(this.SlipNoteGuide_uButton_Click);
            // 
            // lbltotalCount
            // 
            appearance31.TextHAlignAsString = "Right";
            appearance31.TextVAlignAsString = "Middle";
            this.lbltotalCount.Appearance = appearance31;
            this.lbltotalCount.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbltotalCount.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.lbltotalCount.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbltotalCount.Location = new System.Drawing.Point(879, 6);
            this.lbltotalCount.Name = "lbltotalCount";
            this.lbltotalCount.Size = new System.Drawing.Size(130, 26);
            this.lbltotalCount.TabIndex = 65;
            // 
            // lblTotalPriceTaxIncTitle
            // 
            appearance51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(207)))), ((int)(((byte)(247)))));
            appearance51.ForeColor = System.Drawing.Color.Black;
            appearance51.TextHAlignAsString = "Center";
            appearance51.TextVAlignAsString = "Middle";
            this.lblTotalPriceTaxIncTitle.Appearance = appearance51;
            this.lblTotalPriceTaxIncTitle.BackColorInternal = System.Drawing.Color.Transparent;
            this.lblTotalPriceTaxIncTitle.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblTotalPriceTaxIncTitle.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTotalPriceTaxIncTitle.Location = new System.Drawing.Point(581, 6);
            this.lblTotalPriceTaxIncTitle.Name = "lblTotalPriceTaxIncTitle";
            this.lblTotalPriceTaxIncTitle.Size = new System.Drawing.Size(152, 24);
            this.lblTotalPriceTaxIncTitle.TabIndex = 64;
            this.lblTotalPriceTaxIncTitle.Text = "金額/仕入数　合計";
            // 
            // lblTotalPrice
            // 
            appearance52.TextHAlignAsString = "Right";
            appearance52.TextVAlignAsString = "Middle";
            this.lblTotalPrice.Appearance = appearance52;
            this.lblTotalPrice.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblTotalPrice.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.lblTotalPrice.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTotalPrice.Location = new System.Drawing.Point(739, 6);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(136, 26);
            this.lblTotalPrice.TabIndex = 63;
            // 
            // lblNoteTitle
            // 
            this.lblNoteTitle.Location = new System.Drawing.Point(5, 10);
            this.lblNoteTitle.Name = "lblNoteTitle";
            this.lblNoteTitle.Size = new System.Drawing.Size(41, 20);
            this.lblNoteTitle.TabIndex = 0;
            this.lblNoteTitle.Text = "備考";
            // 
            // edtNote1
            // 
            appearance34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.edtNote1.ActiveAppearance = appearance34;
            this.edtNote1.AutoSelect = true;
            this.edtNote1.DataText = "";
            this.edtNote1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.edtNote1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.edtNote1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.edtNote1.Location = new System.Drawing.Point(46, 5);
            this.edtNote1.MaxLength = 30;
            this.edtNote1.Name = "edtNote1";
            this.edtNote1.Size = new System.Drawing.Size(469, 24);
            this.edtNote1.TabIndex = 1;
            // 
            // StatusBar_Main
            // 
            this.StatusBar_Main.Controls.Add(this.cmbGridFont);
            this.StatusBar_Main.Location = new System.Drawing.Point(0, 59);
            this.StatusBar_Main.Name = "StatusBar_Main";
            appearance35.FontData.SizeInPoints = 9F;
            ultraStatusPanel1.Appearance = appearance35;
            ultraStatusPanel1.Text = "文字サイズ";
            ultraStatusPanel1.Width = 72;
            ultraStatusPanel2.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel2.Control = this.cmbGridFont;
            ultraStatusPanel2.MinWidth = 40;
            ultraStatusPanel2.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel2.Width = 40;
            appearance36.FontData.SizeInPoints = 9F;
            ultraStatusPanel3.Appearance = appearance36;
            ultraStatusPanel3.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel3.Key = "HelpText";
            ultraStatusPanel3.Padding = new System.Drawing.Size(10, 0);
            ultraStatusPanel3.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel3.WrapText = Infragistics.Win.DefaultableBoolean.False;
            this.StatusBar_Main.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3});
            this.StatusBar_Main.Size = new System.Drawing.Size(1012, 25);
            this.StatusBar_Main.TabIndex = 8;
            this.StatusBar_Main.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // timFontChange
            // 
            this.timFontChange.Interval = 10;
            this.timFontChange.Tick += new System.EventHandler(this.timFontChange_Tick);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl_ChangeFocus);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl_ChangeFocus);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl_ChangeFocus);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // MAZAI04360UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1012, 734);
            this.Controls.Add(this.pnl_MiddleBase);
            this.Controls.Add(this.pnl_LowerBase);
            this.Controls.Add(this.pnl_UpperBase);
            this.Controls.Add(this.pnl_DockBase);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MAZAI04360UA";
            this.Text = "在庫仕入入力";
            ((System.ComponentModel.ISupportInitialize)(this.cmbGridFont)).EndInit();
            this.pnl_DockBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ExplorerBar_InputHelp)).EndInit();
            this.pnl_UpperBase.ResumeLayout(false);
            this.pnl_UpperBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierSlipNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLine12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_WarehouseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode)).EndInit();
            this.pnl_MiddleBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StockGrid)).EndInit();
            this.PrintExtra_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ToolbarsManager_Main)).EndInit();
            this.pnl_LowerBase.ResumeLayout(false);
            this.pnl_LowerBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtNote1)).EndInit();
            this.StatusBar_Main.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Panel pnl_DockBase;
		private System.Windows.Forms.Panel pnl_LowerBase;
		private System.Windows.Forms.Panel pnl_MiddleBase;
		private System.Windows.Forms.Panel pnl_UpperBase;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar StatusBar_Main;
        private Broadleaf.Library.Windows.Forms.TToolbarsManager ToolbarsManager_Main;
		private Broadleaf.Library.Windows.Forms.TComboEditor cmbGridFont;
        private System.Windows.Forms.Timer timFontChange;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Infragistics.Win.Misc.UltraLabel lblNoteTitle;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnl_MiddleBase_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnl_MiddleBase_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnl_MiddleBase_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnl_MiddleBase_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar ExplorerBar_InputHelp;
        private Broadleaf.Library.Windows.Forms.TDateEdit makedate_tDateEdit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.Misc.UltraLabel lbltotalCount;
        private Infragistics.Win.Misc.UltraLabel lblTotalPriceTaxIncTitle;
        private Infragistics.Win.Misc.UltraLabel lblTotalPrice;
        private Infragistics.Win.Misc.UltraButton GoodsSearch_ultraButton;
        private Infragistics.Win.Misc.UltraLabel uLabel_StockAgentName;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_EmployeeCode;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraButton uButton_EmployeeGuide;
        private System.Windows.Forms.Panel PrintExtra_Panel;
        private Infragistics.Win.Misc.UltraButton RowDelete_ultraButton;
        private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraButton WarehouseGuide_uButton;
        private Infragistics.Win.Misc.UltraButton SectionGuide_uButton;
        private Infragistics.Win.Misc.UltraLabel uLabel_WarehouseName;
        private Infragistics.Win.Misc.UltraLabel uLabel_SectionName;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_WarehouseCode;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SectionCode;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel uLabel_LastSalesSlipNum;
        private Broadleaf.Library.Windows.Forms.TLine tLine12;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.Misc.UltraButton SalesSlipGuide_uButton;
        private Infragistics.Win.Misc.UltraButton SlipNoteGuide_uButton;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_SupplierSlipNo;
        public Broadleaf.Library.Windows.Forms.TEdit edtNote1;
        public Infragistics.Win.UltraWinGrid.UltraGrid StockGrid;
	}
}
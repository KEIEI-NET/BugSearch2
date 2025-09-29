namespace Broadleaf.Windows.Forms
{
	partial class MAHNB04110UA
	{
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

        // ADD 2009/12/03 MANTIS対応[14742]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
        /// <summary>処分済みフラグ</summary>
        private bool _disposed;
        // ADD 2009/12/03 MANTIS対応[14742]：伝票および明細グリッド列の列設定の変更 ----------<<<<<

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
                // ADD 2009/12/03 MANTIS対応[14742]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
                this.MAHNB04110UA_FormClosing(this, null);
                // ADD 2009/12/03 MANTIS対応[14742]：伝票および明細グリッド列の列設定の変更 ----------<<<<<
				components.Dispose();
			}
			base.Dispose(disposing);

            // ADD 2009/12/03 MANTIS対応[14742]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
            _disposed = true;
            // ADD 2009/12/03 MANTIS対応[14742]：伝票および明細グリッド列の列設定の変更 ----------<<<<<
		}

		#region Windows フォーム デザイナで生成されたコード

		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem14 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem15 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar_MainMenu");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Files");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Edits");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool_Dummy");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool_LoginTitle");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool_LoginName");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar_Standard");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Close");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Select");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Search");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Clear");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Files");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Search");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Select");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Close");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Tools");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool5 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Edits");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Clear");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool6 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Guides");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool7 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Windows");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Close");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Select");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Clear");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Guide");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool_LoginTitle");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool5 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool_LoginName");
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool6 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool_Dummy");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool7 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool_SectionTitle");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Setup");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Search");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAHNB04110UA));
            this.MAURI02001UA_Fill_Panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uGrid_Result = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ViewButtonPanel = new System.Windows.Forms.Panel();
            this.uButton_StockSearch = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExpandableGroupBox1 = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.ultraExpandableGroupBoxPanel2 = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.uCheckEditor_BlPaCOrder = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.uCheckEditor_PccForNS = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ultraLabel18 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_AutoAnswerDivSCM = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_SubSectionName = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_SectionName = new Infragistics.Win.Misc.UltraLabel();
            this.tDateEdit_SearchSlipDateSt = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_FrontEmployeeCd = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tDateEdit_SearchSlipDateEd = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.uLabel_FrontEmployeeName = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_FrontEmployeeCd = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SalesEmployeeCd = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_SalesInputCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_SalesEmployeeGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_SalesInputName = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_SalesEmployeeName = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_SalesInputGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.tDateEdit_SalesDateSt = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.Lb_SearchSlipDate = new Infragistics.Win.Misc.UltraLabel();
            this.tDateEdit_SalesDateEd = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SalesSlipNum_Ed = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_SalesSlipNum_St = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SectionCodeAllowZero = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tNedit_SubSectionCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraButton_SubSectionGuide = new Infragistics.Win.Misc.UltraButton();
            this.SectionCodeGuide_ultraButton = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_FullModel = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tNedit_ClaimCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_CustomerCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uButton_CustomerGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_ClaimName = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_CustomerName = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_ClaimGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel27 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_SalesSlipCd = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tComboEditor_SalesFormalCode = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.uStatusBar_Main = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.timer_InitFocusSetting = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer_Search = new System.Windows.Forms.Timer(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this._MAURI02001UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.tToolbarsManager_MainMenu = new Broadleaf.Library.Windows.Forms.TToolbarsManager(this.components);
            this._MAURI02001UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._MAURI02001UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._MAURI02001UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraExpandableGroupBox = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.ultraExpandableGroupBoxPanel1 = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.MAURI02001UA_Fill_Panel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_Result)).BeginInit();
            this.ViewButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox1)).BeginInit();
            this.ultraExpandableGroupBox1.SuspendLayout();
            this.ultraExpandableGroupBoxPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_AutoAnswerDivSCM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_FrontEmployeeCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesEmployeeCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesInputCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesSlipNum_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesSlipNum_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SubSectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_FullModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_ClaimCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SalesSlipCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SalesFormalCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tToolbarsManager_MainMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox)).BeginInit();
            this.ultraExpandableGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MAURI02001UA_Fill_Panel
            // 
            this.MAURI02001UA_Fill_Panel.Controls.Add(this.panel1);
            this.MAURI02001UA_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.MAURI02001UA_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MAURI02001UA_Fill_Panel.Location = new System.Drawing.Point(0, 63);
            this.MAURI02001UA_Fill_Panel.Name = "MAURI02001UA_Fill_Panel";
            this.MAURI02001UA_Fill_Panel.Size = new System.Drawing.Size(1016, 648);
            this.MAURI02001UA_Fill_Panel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.panel1.Controls.Add(this.uGrid_Result);
            this.panel1.Controls.Add(this.ViewButtonPanel);
            this.panel1.Controls.Add(this.ultraLabel3);
            this.panel1.Controls.Add(this.ultraExpandableGroupBox1);
            this.panel1.Controls.Add(this.ultraLabel7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 648);
            this.panel1.TabIndex = 6;
            // 
            // uGrid_Result
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.uGrid_Result.DisplayLayout.Appearance = appearance1;
            this.uGrid_Result.DisplayLayout.GroupByBox.Hidden = true;
            this.uGrid_Result.DisplayLayout.GroupByBox.Style = Infragistics.Win.UltraWinGrid.GroupByBoxStyle.Compact;
            this.uGrid_Result.DisplayLayout.InterBandSpacing = 10;
            this.uGrid_Result.DisplayLayout.MaxColScrollRegions = 1;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.uGrid_Result.DisplayLayout.Override.ActiveCellAppearance = appearance2;
            this.uGrid_Result.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.uGrid_Result.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_Result.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.uGrid_Result.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_Result.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
            this.uGrid_Result.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.TextHAlignAsString = "Center";
            appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.uGrid_Result.DisplayLayout.Override.HeaderAppearance = appearance3;
            this.uGrid_Result.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance4.BackColor = System.Drawing.Color.Lavender;
            this.uGrid_Result.DisplayLayout.Override.RowAlternateAppearance = appearance4;
            appearance10.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            appearance10.TextVAlignAsString = "Middle";
            this.uGrid_Result.DisplayLayout.Override.RowAppearance = appearance10;
            this.uGrid_Result.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.uGrid_Result.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance11.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance11.ForeColor = System.Drawing.Color.White;
            this.uGrid_Result.DisplayLayout.Override.RowSelectorAppearance = appearance11;
            this.uGrid_Result.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_Result.DisplayLayout.Override.RowSelectorWidth = 12;
            this.uGrid_Result.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance7.ForeColor = System.Drawing.Color.Black;
            this.uGrid_Result.DisplayLayout.Override.SelectedRowAppearance = appearance7;
            this.uGrid_Result.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.uGrid_Result.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.uGrid_Result.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.ExtendedAutoDrag;
            this.uGrid_Result.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_Result.DisplayLayout.Override.TipStyleRowConnector = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_Result.DisplayLayout.Override.TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.uGrid_Result.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.uGrid_Result.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.uGrid_Result.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.uGrid_Result.DisplayLayout.UseFixedHeaders = true;
            this.uGrid_Result.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.uGrid_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGrid_Result.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uGrid_Result.Location = new System.Drawing.Point(0, 238);
            this.uGrid_Result.Name = "uGrid_Result";
            this.uGrid_Result.Size = new System.Drawing.Size(1016, 410);
            this.uGrid_Result.TabIndex = 1215;
            this.uGrid_Result.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.uGrid_Result_InitializeLayout);
            this.uGrid_Result.Enter += new System.EventHandler(this.uGrid_Result_Enter);
            this.uGrid_Result.DoubleClick += new System.EventHandler(this.uGrid_Result_DoubleClick);
            this.uGrid_Result.Leave += new System.EventHandler(this.uGrid_Result_Leave);
            this.uGrid_Result.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uGrid_Result_KeyDown);
            this.uGrid_Result.AfterCellActivate += new System.EventHandler(this.uGrid_Result_AfterCellActivate);
            // 
            // ViewButtonPanel
            // 
            this.ViewButtonPanel.BackColor = System.Drawing.Color.GhostWhite;
            this.ViewButtonPanel.Controls.Add(this.uButton_StockSearch);
            this.ViewButtonPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ViewButtonPanel.Location = new System.Drawing.Point(0, 210);
            this.ViewButtonPanel.Name = "ViewButtonPanel";
            this.ViewButtonPanel.Size = new System.Drawing.Size(1016, 28);
            this.ViewButtonPanel.TabIndex = 1214;
            // 
            // uButton_StockSearch
            // 
            appearance14.Image = "携帯電話検索.bmp";
            this.uButton_StockSearch.Appearance = appearance14;
            this.uButton_StockSearch.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_StockSearch.ImageTransparentColor = System.Drawing.Color.Cyan;
            this.uButton_StockSearch.Location = new System.Drawing.Point(0, 0);
            this.uButton_StockSearch.Name = "uButton_StockSearch";
            this.uButton_StockSearch.Size = new System.Drawing.Size(103, 27);
            this.uButton_StockSearch.TabIndex = 31;
            this.uButton_StockSearch.Text = "明細情報(&D)";
            this.uButton_StockSearch.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_StockSearch.Click += new System.EventHandler(this.uButton_StockSearch_Click);
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraLabel3.Location = new System.Drawing.Point(0, 210);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(1016, 438);
            this.ultraLabel3.TabIndex = 1213;
            // 
            // ultraExpandableGroupBox1
            // 
            this.ultraExpandableGroupBox1.Controls.Add(this.ultraExpandableGroupBoxPanel2);
            this.ultraExpandableGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraExpandableGroupBox1.ExpandedSize = new System.Drawing.Size(1016, 210);
            this.ultraExpandableGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraExpandableGroupBox1.Name = "ultraExpandableGroupBox1";
            this.ultraExpandableGroupBox1.Size = new System.Drawing.Size(1016, 210);
            this.ultraExpandableGroupBox1.TabIndex = 1212;
            this.ultraExpandableGroupBox1.Text = "検索条件";
            // 
            // ultraExpandableGroupBoxPanel2
            // 
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uCheckEditor_BlPaCOrder);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uCheckEditor_PccForNS);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.ultraLabel18);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tComboEditor_AutoAnswerDivSCM);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.ultraLabel17);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_SubSectionName);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_SectionName);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tDateEdit_SearchSlipDateSt);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.ultraLabel11);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tEdit_FrontEmployeeCd);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tDateEdit_SearchSlipDateEd);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_FrontEmployeeName);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.ultraLabel9);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uButton_FrontEmployeeCd);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.ultraLabel15);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tEdit_SalesEmployeeCd);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tEdit_SalesInputCode);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uButton_SalesEmployeeGuide);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.ultraLabel10);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_SalesInputName);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_SalesEmployeeName);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.ultraLabel12);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uButton_SalesInputGuide);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.ultraLabel4);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tDateEdit_SalesDateSt);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.Lb_SearchSlipDate);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tDateEdit_SalesDateEd);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.ultraLabel2);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tEdit_SalesSlipNum_Ed);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tEdit_SalesSlipNum_St);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.ultraLabel1);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tEdit_SectionCodeAllowZero);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tNedit_SubSectionCode);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.ultraButton_SubSectionGuide);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.SectionCodeGuide_ultraButton);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.ultraLabel14);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.ultraLabel8);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tEdit_FullModel);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tNedit_ClaimCode);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tNedit_CustomerCode);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uButton_CustomerGuide);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.ultraLabel13);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_ClaimName);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uLabel_CustomerName);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.ultraLabel16);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.uButton_ClaimGuide);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.ultraLabel27);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tComboEditor_SalesSlipCd);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.tComboEditor_SalesFormalCode);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.ultraLabel6);
            this.ultraExpandableGroupBoxPanel2.Controls.Add(this.ultraLabel5);
            this.ultraExpandableGroupBoxPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraExpandableGroupBoxPanel2.Location = new System.Drawing.Point(3, 19);
            this.ultraExpandableGroupBoxPanel2.Name = "ultraExpandableGroupBoxPanel2";
            this.ultraExpandableGroupBoxPanel2.Size = new System.Drawing.Size(1010, 188);
            this.ultraExpandableGroupBoxPanel2.TabIndex = 0;
            // 
            // uCheckEditor_BlPaCOrder
            // 
            this.uCheckEditor_BlPaCOrder.Location = new System.Drawing.Point(744, 159);
            this.uCheckEditor_BlPaCOrder.Name = "uCheckEditor_BlPaCOrder";
            this.uCheckEditor_BlPaCOrder.Size = new System.Drawing.Size(176, 20);
            this.uCheckEditor_BlPaCOrder.TabIndex = 1333;
            this.uCheckEditor_BlPaCOrder.Text = "BLﾊﾟｰﾂｵｰﾀﾞｰ分を含む";
            // 
            // uCheckEditor_PccForNS
            // 
            this.uCheckEditor_PccForNS.Location = new System.Drawing.Point(572, 160);
            this.uCheckEditor_PccForNS.Name = "uCheckEditor_PccForNS";
            this.uCheckEditor_PccForNS.Size = new System.Drawing.Size(166, 20);
            this.uCheckEditor_PccForNS.TabIndex = 1332;
            this.uCheckEditor_PccForNS.Text = "PCCforNS分を含む";
            // 
            // ultraLabel18
            // 
            appearance8.TextVAlignAsString = "Middle";
            this.ultraLabel18.Appearance = appearance8;
            this.ultraLabel18.Location = new System.Drawing.Point(421, 158);
            this.ultraLabel18.Name = "ultraLabel18";
            this.ultraLabel18.Size = new System.Drawing.Size(148, 23);
            this.ultraLabel18.TabIndex = 1331;
            this.ultraLabel18.Text = "連携伝票対象区分";
            // 
            // tComboEditor_AutoAnswerDivSCM
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_AutoAnswerDivSCM.ActiveAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_AutoAnswerDivSCM.Appearance = appearance6;
            this.tComboEditor_AutoAnswerDivSCM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_AutoAnswerDivSCM.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_AutoAnswerDivSCM.ItemAppearance = appearance36;
            valueListItem1.DataValue = "0";
            valueListItem1.DisplayText = "連携伝票を含まない";
            valueListItem2.DataValue = "1";
            valueListItem2.DisplayText = "連携伝票を含む";
            valueListItem3.DataValue = "2";
            valueListItem3.DisplayText = "連携伝票のみ対象";
            this.tComboEditor_AutoAnswerDivSCM.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.tComboEditor_AutoAnswerDivSCM.Location = new System.Drawing.Point(149, 158);
            this.tComboEditor_AutoAnswerDivSCM.Name = "tComboEditor_AutoAnswerDivSCM";
            this.tComboEditor_AutoAnswerDivSCM.Size = new System.Drawing.Size(218, 24);
            this.tComboEditor_AutoAnswerDivSCM.TabIndex = 1253;
            this.tComboEditor_AutoAnswerDivSCM.ValueChanged += new System.EventHandler(this.tComboEditor_AutoAnswerDivSCM_ValueChanged);
            // 
            // ultraLabel17
            // 
            appearance45.TextVAlignAsString = "Middle";
            this.ultraLabel17.Appearance = appearance45;
            this.ultraLabel17.Location = new System.Drawing.Point(12, 158);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(148, 23);
            this.ultraLabel17.TabIndex = 1329;
            this.ultraLabel17.Text = "連携伝票出力区分";
            // 
            // uLabel_SubSectionName
            // 
            appearance12.BackColor = System.Drawing.Color.Gainsboro;
            appearance12.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance12.TextHAlignAsString = "Left";
            appearance12.TextVAlignAsString = "Middle";
            this.uLabel_SubSectionName.Appearance = appearance12;
            this.uLabel_SubSectionName.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_SubSectionName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_SubSectionName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_SubSectionName.Location = new System.Drawing.Point(116, 26);
            this.uLabel_SubSectionName.Name = "uLabel_SubSectionName";
            this.uLabel_SubSectionName.Size = new System.Drawing.Size(180, 24);
            this.uLabel_SubSectionName.TabIndex = 1285;
            this.uLabel_SubSectionName.WrapText = false;
            // 
            // uLabel_SectionName
            // 
            appearance71.BackColor = System.Drawing.Color.Gainsboro;
            appearance71.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance71.TextHAlignAsString = "Left";
            appearance71.TextVAlignAsString = "Middle";
            this.uLabel_SectionName.Appearance = appearance71;
            this.uLabel_SectionName.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_SectionName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_SectionName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_SectionName.Location = new System.Drawing.Point(116, 0);
            this.uLabel_SectionName.Name = "uLabel_SectionName";
            this.uLabel_SectionName.Size = new System.Drawing.Size(180, 24);
            this.uLabel_SectionName.TabIndex = 1284;
            this.uLabel_SectionName.WrapText = false;
            // 
            // tDateEdit_SearchSlipDateSt
            // 
            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tDateEdit_SearchSlipDateSt.ActiveEditAppearance = appearance32;
            this.tDateEdit_SearchSlipDateSt.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit_SearchSlipDateSt.CalendarDisp = true;
            appearance33.TextHAlignAsString = "Left";
            appearance33.TextVAlignAsString = "Middle";
            this.tDateEdit_SearchSlipDateSt.EditAppearance = appearance33;
            this.tDateEdit_SearchSlipDateSt.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit_SearchSlipDateSt.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance34.TextHAlignAsString = "Left";
            appearance34.TextVAlignAsString = "Middle";
            this.tDateEdit_SearchSlipDateSt.LabelAppearance = appearance34;
            this.tDateEdit_SearchSlipDateSt.Location = new System.Drawing.Point(511, 27);
            this.tDateEdit_SearchSlipDateSt.Name = "tDateEdit_SearchSlipDateSt";
            this.tDateEdit_SearchSlipDateSt.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit_SearchSlipDateSt.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.tDateEdit_SearchSlipDateSt.Size = new System.Drawing.Size(176, 24);
            this.tDateEdit_SearchSlipDateSt.TabIndex = 1262;
            this.tDateEdit_SearchSlipDateSt.TabStop = true;
            // 
            // ultraLabel11
            // 
            appearance23.ForeColorDisabled = System.Drawing.Color.Black;
            appearance23.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance23;
            this.ultraLabel11.Location = new System.Drawing.Point(688, 27);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(19, 24);
            this.ultraLabel11.TabIndex = 1280;
            this.ultraLabel11.Text = "～";
            // 
            // tEdit_FrontEmployeeCd
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_FrontEmployeeCd.ActiveAppearance = appearance40;
            this.tEdit_FrontEmployeeCd.AutoSelect = true;
            this.tEdit_FrontEmployeeCd.AutoSize = false;
            this.tEdit_FrontEmployeeCd.DataText = "";
            this.tEdit_FrontEmployeeCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_FrontEmployeeCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.tEdit_FrontEmployeeCd.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_FrontEmployeeCd.Location = new System.Drawing.Point(511, 131);
            this.tEdit_FrontEmployeeCd.MaxLength = 4;
            this.tEdit_FrontEmployeeCd.Name = "tEdit_FrontEmployeeCd";
            this.tEdit_FrontEmployeeCd.Size = new System.Drawing.Size(43, 24);
            this.tEdit_FrontEmployeeCd.TabIndex = 1272;
            // 
            // tDateEdit_SearchSlipDateEd
            // 
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tDateEdit_SearchSlipDateEd.ActiveEditAppearance = appearance25;
            this.tDateEdit_SearchSlipDateEd.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit_SearchSlipDateEd.CalendarDisp = true;
            appearance26.TextHAlignAsString = "Left";
            appearance26.TextVAlignAsString = "Middle";
            this.tDateEdit_SearchSlipDateEd.EditAppearance = appearance26;
            this.tDateEdit_SearchSlipDateEd.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit_SearchSlipDateEd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance27.TextHAlignAsString = "Left";
            appearance27.TextVAlignAsString = "Middle";
            this.tDateEdit_SearchSlipDateEd.LabelAppearance = appearance27;
            this.tDateEdit_SearchSlipDateEd.Location = new System.Drawing.Point(708, 27);
            this.tDateEdit_SearchSlipDateEd.Name = "tDateEdit_SearchSlipDateEd";
            this.tDateEdit_SearchSlipDateEd.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit_SearchSlipDateEd.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.tDateEdit_SearchSlipDateEd.Size = new System.Drawing.Size(176, 24);
            this.tDateEdit_SearchSlipDateEd.TabIndex = 1263;
            this.tDateEdit_SearchSlipDateEd.TabStop = true;
            // 
            // uLabel_FrontEmployeeName
            // 
            appearance43.BackColor = System.Drawing.Color.Gainsboro;
            appearance43.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance43.TextHAlignAsString = "Left";
            appearance43.TextVAlignAsString = "Middle";
            this.uLabel_FrontEmployeeName.Appearance = appearance43;
            this.uLabel_FrontEmployeeName.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_FrontEmployeeName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_FrontEmployeeName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_FrontEmployeeName.Location = new System.Drawing.Point(557, 131);
            this.uLabel_FrontEmployeeName.Name = "uLabel_FrontEmployeeName";
            this.uLabel_FrontEmployeeName.Size = new System.Drawing.Size(186, 24);
            this.uLabel_FrontEmployeeName.TabIndex = 1273;
            this.uLabel_FrontEmployeeName.WrapText = false;
            // 
            // ultraLabel9
            // 
            appearance38.ForeColorDisabled = System.Drawing.Color.Black;
            appearance38.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance38;
            this.ultraLabel9.Location = new System.Drawing.Point(421, 26);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(54, 24);
            this.ultraLabel9.TabIndex = 1278;
            this.ultraLabel9.Text = "入力日";
            // 
            // uButton_FrontEmployeeCd
            // 
            appearance46.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance46.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_FrontEmployeeCd.Appearance = appearance46;
            this.uButton_FrontEmployeeCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_FrontEmployeeCd.Location = new System.Drawing.Point(744, 131);
            this.uButton_FrontEmployeeCd.Name = "uButton_FrontEmployeeCd";
            this.uButton_FrontEmployeeCd.Size = new System.Drawing.Size(24, 24);
            this.uButton_FrontEmployeeCd.TabIndex = 1274;
            this.toolTip1.SetToolTip(this.uButton_FrontEmployeeCd, "従業員ガイド");
            this.uButton_FrontEmployeeCd.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_FrontEmployeeCd.Click += new System.EventHandler(this.uButton_FrontEmployeeCd_Click);
            // 
            // ultraLabel15
            // 
            appearance42.ForeColorDisabled = System.Drawing.Color.Black;
            appearance42.TextVAlignAsString = "Middle";
            this.ultraLabel15.Appearance = appearance42;
            this.ultraLabel15.Location = new System.Drawing.Point(421, 130);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(67, 24);
            this.ultraLabel15.TabIndex = 1283;
            this.ultraLabel15.Text = "受注者";
            // 
            // tEdit_SalesEmployeeCd
            // 
            appearance54.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SalesEmployeeCd.ActiveAppearance = appearance54;
            this.tEdit_SalesEmployeeCd.AutoSelect = true;
            this.tEdit_SalesEmployeeCd.AutoSize = false;
            this.tEdit_SalesEmployeeCd.DataText = "";
            this.tEdit_SalesEmployeeCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SalesEmployeeCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.tEdit_SalesEmployeeCd.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_SalesEmployeeCd.Location = new System.Drawing.Point(511, 79);
            this.tEdit_SalesEmployeeCd.MaxLength = 4;
            this.tEdit_SalesEmployeeCd.Name = "tEdit_SalesEmployeeCd";
            this.tEdit_SalesEmployeeCd.Size = new System.Drawing.Size(43, 24);
            this.tEdit_SalesEmployeeCd.TabIndex = 1266;
            // 
            // tEdit_SalesInputCode
            // 
            appearance77.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SalesInputCode.ActiveAppearance = appearance77;
            this.tEdit_SalesInputCode.AutoSelect = true;
            this.tEdit_SalesInputCode.AutoSize = false;
            this.tEdit_SalesInputCode.DataText = "";
            this.tEdit_SalesInputCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SalesInputCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.tEdit_SalesInputCode.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_SalesInputCode.Location = new System.Drawing.Point(511, 105);
            this.tEdit_SalesInputCode.MaxLength = 4;
            this.tEdit_SalesInputCode.Name = "tEdit_SalesInputCode";
            this.tEdit_SalesInputCode.Size = new System.Drawing.Size(43, 24);
            this.tEdit_SalesInputCode.TabIndex = 1269;
            // 
            // uButton_SalesEmployeeGuide
            // 
            appearance41.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance41.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_SalesEmployeeGuide.Appearance = appearance41;
            this.uButton_SalesEmployeeGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_SalesEmployeeGuide.Location = new System.Drawing.Point(744, 79);
            this.uButton_SalesEmployeeGuide.Name = "uButton_SalesEmployeeGuide";
            this.uButton_SalesEmployeeGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SalesEmployeeGuide.TabIndex = 1268;
            this.toolTip1.SetToolTip(this.uButton_SalesEmployeeGuide, "従業員ガイド");
            this.uButton_SalesEmployeeGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SalesEmployeeGuide.Click += new System.EventHandler(this.uButton_SalesEmployeeGuide_Click);
            // 
            // ultraLabel10
            // 
            appearance76.ForeColorDisabled = System.Drawing.Color.Black;
            appearance76.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance76;
            this.ultraLabel10.Location = new System.Drawing.Point(421, 79);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(67, 24);
            this.ultraLabel10.TabIndex = 1281;
            this.ultraLabel10.Text = "担当者";
            // 
            // uLabel_SalesInputName
            // 
            appearance78.BackColor = System.Drawing.Color.Gainsboro;
            appearance78.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance78.TextHAlignAsString = "Left";
            appearance78.TextVAlignAsString = "Middle";
            this.uLabel_SalesInputName.Appearance = appearance78;
            this.uLabel_SalesInputName.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_SalesInputName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_SalesInputName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_SalesInputName.Location = new System.Drawing.Point(557, 105);
            this.uLabel_SalesInputName.Name = "uLabel_SalesInputName";
            this.uLabel_SalesInputName.Size = new System.Drawing.Size(186, 24);
            this.uLabel_SalesInputName.TabIndex = 1270;
            this.uLabel_SalesInputName.WrapText = false;
            // 
            // uLabel_SalesEmployeeName
            // 
            appearance44.BackColor = System.Drawing.Color.Gainsboro;
            appearance44.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance44.TextHAlignAsString = "Left";
            appearance44.TextVAlignAsString = "Middle";
            this.uLabel_SalesEmployeeName.Appearance = appearance44;
            this.uLabel_SalesEmployeeName.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_SalesEmployeeName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_SalesEmployeeName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_SalesEmployeeName.Location = new System.Drawing.Point(557, 79);
            this.uLabel_SalesEmployeeName.Name = "uLabel_SalesEmployeeName";
            this.uLabel_SalesEmployeeName.Size = new System.Drawing.Size(186, 24);
            this.uLabel_SalesEmployeeName.TabIndex = 1267;
            this.uLabel_SalesEmployeeName.WrapText = false;
            // 
            // ultraLabel12
            // 
            appearance21.ForeColorDisabled = System.Drawing.Color.Black;
            appearance21.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance21;
            this.ultraLabel12.Location = new System.Drawing.Point(421, 105);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(67, 24);
            this.ultraLabel12.TabIndex = 1282;
            this.ultraLabel12.Text = "発行者";
            // 
            // uButton_SalesInputGuide
            // 
            appearance79.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance79.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_SalesInputGuide.Appearance = appearance79;
            this.uButton_SalesInputGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_SalesInputGuide.Location = new System.Drawing.Point(744, 105);
            this.uButton_SalesInputGuide.Name = "uButton_SalesInputGuide";
            this.uButton_SalesInputGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SalesInputGuide.TabIndex = 1271;
            this.toolTip1.SetToolTip(this.uButton_SalesInputGuide, "従業員ガイド");
            this.uButton_SalesInputGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SalesInputGuide.Click += new System.EventHandler(this.uButton_SalesInputGuide_Click);
            // 
            // ultraLabel4
            // 
            appearance24.ForeColorDisabled = System.Drawing.Color.Black;
            appearance24.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance24;
            this.ultraLabel4.Location = new System.Drawing.Point(688, 1);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(19, 24);
            this.ultraLabel4.TabIndex = 1279;
            this.ultraLabel4.Text = "～";
            // 
            // tDateEdit_SalesDateSt
            // 
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tDateEdit_SalesDateSt.ActiveEditAppearance = appearance19;
            this.tDateEdit_SalesDateSt.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit_SalesDateSt.CalendarDisp = true;
            appearance20.TextHAlignAsString = "Left";
            appearance20.TextVAlignAsString = "Middle";
            this.tDateEdit_SalesDateSt.EditAppearance = appearance20;
            this.tDateEdit_SalesDateSt.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit_SalesDateSt.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance30.TextHAlignAsString = "Left";
            appearance30.TextVAlignAsString = "Middle";
            this.tDateEdit_SalesDateSt.LabelAppearance = appearance30;
            this.tDateEdit_SalesDateSt.Location = new System.Drawing.Point(511, 1);
            this.tDateEdit_SalesDateSt.Name = "tDateEdit_SalesDateSt";
            this.tDateEdit_SalesDateSt.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit_SalesDateSt.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.tDateEdit_SalesDateSt.Size = new System.Drawing.Size(176, 24);
            this.tDateEdit_SalesDateSt.TabIndex = 1260;
            this.tDateEdit_SalesDateSt.TabStop = true;
            // 
            // Lb_SearchSlipDate
            // 
            appearance31.ForeColorDisabled = System.Drawing.Color.Black;
            appearance31.TextVAlignAsString = "Middle";
            this.Lb_SearchSlipDate.Appearance = appearance31;
            this.Lb_SearchSlipDate.Location = new System.Drawing.Point(421, 0);
            this.Lb_SearchSlipDate.Name = "Lb_SearchSlipDate";
            this.Lb_SearchSlipDate.Size = new System.Drawing.Size(54, 24);
            this.Lb_SearchSlipDate.TabIndex = 1277;
            this.Lb_SearchSlipDate.Text = "売上日";
            // 
            // tDateEdit_SalesDateEd
            // 
            appearance35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tDateEdit_SalesDateEd.ActiveEditAppearance = appearance35;
            this.tDateEdit_SalesDateEd.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit_SalesDateEd.CalendarDisp = true;
            appearance22.TextHAlignAsString = "Left";
            appearance22.TextVAlignAsString = "Middle";
            this.tDateEdit_SalesDateEd.EditAppearance = appearance22;
            this.tDateEdit_SalesDateEd.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit_SalesDateEd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance37.TextHAlignAsString = "Left";
            appearance37.TextVAlignAsString = "Middle";
            this.tDateEdit_SalesDateEd.LabelAppearance = appearance37;
            this.tDateEdit_SalesDateEd.Location = new System.Drawing.Point(708, 1);
            this.tDateEdit_SalesDateEd.Name = "tDateEdit_SalesDateEd";
            this.tDateEdit_SalesDateEd.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit_SalesDateEd.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.tDateEdit_SalesDateEd.Size = new System.Drawing.Size(176, 24);
            this.tDateEdit_SalesDateEd.TabIndex = 1261;
            this.tDateEdit_SalesDateEd.TabStop = true;
            // 
            // ultraLabel2
            // 
            appearance57.ForeColorDisabled = System.Drawing.Color.Black;
            appearance57.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance57;
            this.ultraLabel2.Location = new System.Drawing.Point(601, 54);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(19, 24);
            this.ultraLabel2.TabIndex = 1276;
            this.ultraLabel2.Text = "～";
            // 
            // tEdit_SalesSlipNum_Ed
            // 
            appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SalesSlipNum_Ed.ActiveAppearance = appearance58;
            appearance59.ForeColorDisabled = System.Drawing.Color.Black;
            appearance59.TextHAlignAsString = "Left";
            this.tEdit_SalesSlipNum_Ed.Appearance = appearance59;
            this.tEdit_SalesSlipNum_Ed.AutoSelect = true;
            this.tEdit_SalesSlipNum_Ed.AutoSize = false;
            this.tEdit_SalesSlipNum_Ed.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tEdit_SalesSlipNum_Ed.DataText = "";
            this.tEdit_SalesSlipNum_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SalesSlipNum_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
            this.tEdit_SalesSlipNum_Ed.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_SalesSlipNum_Ed.Location = new System.Drawing.Point(626, 53);
            this.tEdit_SalesSlipNum_Ed.MaxLength = 9;
            this.tEdit_SalesSlipNum_Ed.Name = "tEdit_SalesSlipNum_Ed";
            this.tEdit_SalesSlipNum_Ed.Size = new System.Drawing.Size(82, 24);
            this.tEdit_SalesSlipNum_Ed.TabIndex = 1265;
            // 
            // tEdit_SalesSlipNum_St
            // 
            appearance60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SalesSlipNum_St.ActiveAppearance = appearance60;
            appearance61.ForeColorDisabled = System.Drawing.Color.Black;
            appearance61.TextHAlignAsString = "Left";
            this.tEdit_SalesSlipNum_St.Appearance = appearance61;
            this.tEdit_SalesSlipNum_St.AutoSelect = true;
            this.tEdit_SalesSlipNum_St.AutoSize = false;
            this.tEdit_SalesSlipNum_St.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tEdit_SalesSlipNum_St.DataText = "";
            this.tEdit_SalesSlipNum_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SalesSlipNum_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
            this.tEdit_SalesSlipNum_St.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_SalesSlipNum_St.Location = new System.Drawing.Point(511, 53);
            this.tEdit_SalesSlipNum_St.MaxLength = 9;
            this.tEdit_SalesSlipNum_St.Name = "tEdit_SalesSlipNum_St";
            this.tEdit_SalesSlipNum_St.Size = new System.Drawing.Size(82, 24);
            this.tEdit_SalesSlipNum_St.TabIndex = 1264;
            // 
            // ultraLabel1
            // 
            appearance62.ForeColorDisabled = System.Drawing.Color.Black;
            appearance62.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance62;
            this.ultraLabel1.Location = new System.Drawing.Point(421, 53);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(74, 24);
            this.ultraLabel1.TabIndex = 1275;
            this.ultraLabel1.Text = "伝票番号";
            // 
            // tEdit_SectionCodeAllowZero
            // 
            appearance39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SectionCodeAllowZero.ActiveAppearance = appearance39;
            this.tEdit_SectionCodeAllowZero.AutoSelect = true;
            this.tEdit_SectionCodeAllowZero.AutoSize = false;
            this.tEdit_SectionCodeAllowZero.DataText = "";
            this.tEdit_SectionCodeAllowZero.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCodeAllowZero.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.tEdit_SectionCodeAllowZero.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_SectionCodeAllowZero.Location = new System.Drawing.Point(85, 0);
            this.tEdit_SectionCodeAllowZero.MaxLength = 2;
            this.tEdit_SectionCodeAllowZero.Name = "tEdit_SectionCodeAllowZero";
            this.tEdit_SectionCodeAllowZero.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCodeAllowZero.TabIndex = 1238;
            this.tEdit_SectionCodeAllowZero.Enter += new System.EventHandler(this.tEdit_SectionCodeAllowZero_Enter);
            // 
            // tNedit_SubSectionCode
            // 
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance28.ForeColor = System.Drawing.Color.Black;
            appearance28.TextHAlignAsString = "Right";
            appearance28.TextVAlignAsString = "Middle";
            this.tNedit_SubSectionCode.ActiveAppearance = appearance28;
            appearance29.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance29.ForeColor = System.Drawing.Color.Black;
            appearance29.ForeColorDisabled = System.Drawing.Color.Black;
            appearance29.TextHAlignAsString = "Right";
            appearance29.TextVAlignAsString = "Middle";
            this.tNedit_SubSectionCode.Appearance = appearance29;
            this.tNedit_SubSectionCode.AutoSelect = true;
            this.tNedit_SubSectionCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SubSectionCode.DataText = "";
            this.tNedit_SubSectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SubSectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SubSectionCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_SubSectionCode.Location = new System.Drawing.Point(85, 26);
            this.tNedit_SubSectionCode.MaxLength = 2;
            this.tNedit_SubSectionCode.Name = "tNedit_SubSectionCode";
            this.tNedit_SubSectionCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_SubSectionCode.Size = new System.Drawing.Size(28, 24);
            this.tNedit_SubSectionCode.TabIndex = 1241;
            // 
            // ultraButton_SubSectionGuide
            // 
            this.ultraButton_SubSectionGuide.Location = new System.Drawing.Point(302, 26);
            this.ultraButton_SubSectionGuide.Name = "ultraButton_SubSectionGuide";
            this.ultraButton_SubSectionGuide.Size = new System.Drawing.Size(24, 24);
            this.ultraButton_SubSectionGuide.TabIndex = 1243;
            this.ultraButton_SubSectionGuide.Click += new System.EventHandler(this.ultraButton_SubSectionGuide_Click);
            // 
            // SectionCodeGuide_ultraButton
            // 
            this.SectionCodeGuide_ultraButton.Location = new System.Drawing.Point(302, 0);
            this.SectionCodeGuide_ultraButton.Name = "SectionCodeGuide_ultraButton";
            this.SectionCodeGuide_ultraButton.Size = new System.Drawing.Size(24, 24);
            this.SectionCodeGuide_ultraButton.TabIndex = 1240;
            this.SectionCodeGuide_ultraButton.Click += new System.EventHandler(this.SectionCodeGuide_ultraButton_Click);
            // 
            // ultraLabel14
            // 
            appearance15.ForeColorDisabled = System.Drawing.Color.Black;
            appearance15.TextVAlignAsString = "Middle";
            this.ultraLabel14.Appearance = appearance15;
            this.ultraLabel14.Location = new System.Drawing.Point(12, 27);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(67, 24);
            this.ultraLabel14.TabIndex = 1259;
            this.ultraLabel14.Text = "部門";
            // 
            // ultraLabel8
            // 
            appearance51.ForeColorDisabled = System.Drawing.Color.Black;
            appearance51.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance51;
            this.ultraLabel8.Location = new System.Drawing.Point(12, 131);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(67, 24);
            this.ultraLabel8.TabIndex = 1258;
            this.ultraLabel8.Text = "型式*";
            // 
            // tEdit_FullModel
            // 
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_FullModel.ActiveAppearance = appearance16;
            this.tEdit_FullModel.AutoSelect = true;
            this.tEdit_FullModel.DataText = "12345678901234567890123456789012345678901234";
            this.tEdit_FullModel.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_FullModel.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 44, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_FullModel.Location = new System.Drawing.Point(85, 130);
            this.tEdit_FullModel.MaxLength = 44;
            this.tEdit_FullModel.Name = "tEdit_FullModel";
            this.tEdit_FullModel.Size = new System.Drawing.Size(314, 24);
            this.tEdit_FullModel.TabIndex = 1252;
            this.tEdit_FullModel.Text = "12345678901234567890123456789012345678901234";
            this.tEdit_FullModel.ValueChanged += new System.EventHandler(this.tEdit_FullModel_ValueChanged);
            // 
            // tNedit_ClaimCode
            // 
            appearance65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_ClaimCode.ActiveAppearance = appearance65;
            appearance66.ForeColorDisabled = System.Drawing.Color.Black;
            appearance66.TextHAlignAsString = "Right";
            this.tNedit_ClaimCode.Appearance = appearance66;
            this.tNedit_ClaimCode.AutoSelect = true;
            this.tNedit_ClaimCode.AutoSize = false;
            this.tNedit_ClaimCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_ClaimCode.DataText = "";
            this.tNedit_ClaimCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_ClaimCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_ClaimCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_ClaimCode.Location = new System.Drawing.Point(85, 78);
            this.tNedit_ClaimCode.MaxLength = 8;
            this.tNedit_ClaimCode.Name = "tNedit_ClaimCode";
            this.tNedit_ClaimCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_ClaimCode.Size = new System.Drawing.Size(74, 24);
            this.tNedit_ClaimCode.TabIndex = 1247;
            this.tNedit_ClaimCode.Leave += new System.EventHandler(this.tNedit_ClaimCode_Leave);
            // 
            // tNedit_CustomerCode
            // 
            appearance67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_CustomerCode.ActiveAppearance = appearance67;
            appearance68.ForeColorDisabled = System.Drawing.Color.Black;
            appearance68.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode.Appearance = appearance68;
            this.tNedit_CustomerCode.AutoSelect = true;
            this.tNedit_CustomerCode.AutoSize = false;
            this.tNedit_CustomerCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode.DataText = "";
            this.tNedit_CustomerCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustomerCode.Location = new System.Drawing.Point(85, 52);
            this.tNedit_CustomerCode.MaxLength = 8;
            this.tNedit_CustomerCode.Name = "tNedit_CustomerCode";
            this.tNedit_CustomerCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_CustomerCode.Size = new System.Drawing.Size(74, 24);
            this.tNedit_CustomerCode.TabIndex = 1244;
            // 
            // uButton_CustomerGuide
            // 
            appearance69.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance69.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_CustomerGuide.Appearance = appearance69;
            this.uButton_CustomerGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_CustomerGuide.Location = new System.Drawing.Point(343, 52);
            this.uButton_CustomerGuide.Name = "uButton_CustomerGuide";
            this.uButton_CustomerGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_CustomerGuide.TabIndex = 1246;
            this.toolTip1.SetToolTip(this.uButton_CustomerGuide, "得意先検索");
            this.uButton_CustomerGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_CustomerGuide.Click += new System.EventHandler(this.uButton_CustomerGuide_Click);
            // 
            // ultraLabel13
            // 
            appearance17.ForeColorDisabled = System.Drawing.Color.Black;
            appearance17.TextVAlignAsString = "Middle";
            this.ultraLabel13.Appearance = appearance17;
            this.ultraLabel13.Location = new System.Drawing.Point(12, 53);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(67, 24);
            this.ultraLabel13.TabIndex = 1256;
            this.ultraLabel13.Text = "得意先";
            // 
            // uLabel_ClaimName
            // 
            appearance70.BackColor = System.Drawing.Color.Gainsboro;
            appearance70.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance70.TextHAlignAsString = "Left";
            appearance70.TextVAlignAsString = "Middle";
            this.uLabel_ClaimName.Appearance = appearance70;
            this.uLabel_ClaimName.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_ClaimName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_ClaimName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_ClaimName.Location = new System.Drawing.Point(162, 78);
            this.uLabel_ClaimName.Name = "uLabel_ClaimName";
            this.uLabel_ClaimName.Size = new System.Drawing.Size(180, 24);
            this.uLabel_ClaimName.TabIndex = 1248;
            this.uLabel_ClaimName.WrapText = false;
            // 
            // uLabel_CustomerName
            // 
            appearance9.BackColor = System.Drawing.Color.Gainsboro;
            appearance9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance9.TextHAlignAsString = "Left";
            appearance9.TextVAlignAsString = "Middle";
            this.uLabel_CustomerName.Appearance = appearance9;
            this.uLabel_CustomerName.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_CustomerName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_CustomerName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_CustomerName.Location = new System.Drawing.Point(162, 52);
            this.uLabel_CustomerName.Name = "uLabel_CustomerName";
            this.uLabel_CustomerName.Size = new System.Drawing.Size(180, 24);
            this.uLabel_CustomerName.TabIndex = 1245;
            this.uLabel_CustomerName.WrapText = false;
            // 
            // ultraLabel16
            // 
            appearance64.ForeColorDisabled = System.Drawing.Color.Black;
            appearance64.TextVAlignAsString = "Middle";
            this.ultraLabel16.Appearance = appearance64;
            this.ultraLabel16.Location = new System.Drawing.Point(12, 79);
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size(67, 24);
            this.ultraLabel16.TabIndex = 1257;
            this.ultraLabel16.Text = "請求先";
            // 
            // uButton_ClaimGuide
            // 
            appearance72.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance72.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_ClaimGuide.Appearance = appearance72;
            this.uButton_ClaimGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_ClaimGuide.Location = new System.Drawing.Point(343, 78);
            this.uButton_ClaimGuide.Name = "uButton_ClaimGuide";
            this.uButton_ClaimGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_ClaimGuide.TabIndex = 1249;
            this.toolTip1.SetToolTip(this.uButton_ClaimGuide, "得意先検索");
            this.uButton_ClaimGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_ClaimGuide.Click += new System.EventHandler(this.uButton_ClaimGuide_Click);
            // 
            // ultraLabel27
            // 
            appearance18.ForeColorDisabled = System.Drawing.Color.Black;
            appearance18.TextVAlignAsString = "Middle";
            this.ultraLabel27.Appearance = appearance18;
            this.ultraLabel27.Location = new System.Drawing.Point(12, 1);
            this.ultraLabel27.Name = "ultraLabel27";
            this.ultraLabel27.Size = new System.Drawing.Size(75, 24);
            this.ultraLabel27.TabIndex = 1255;
            this.ultraLabel27.Text = "拠点";
            // 
            // tComboEditor_SalesSlipCd
            // 
            appearance73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SalesSlipCd.ActiveAppearance = appearance73;
            this.tComboEditor_SalesSlipCd.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SalesSlipCd.ItemAppearance = appearance74;
            valueListItem4.DataValue = -1;
            valueListItem4.DisplayText = "全て";
            valueListItem5.DataValue = 0;
            valueListItem5.DisplayText = "掛売上";
            valueListItem6.DataValue = 1;
            valueListItem6.DisplayText = "掛返品";
            valueListItem7.DataValue = 100;
            valueListItem7.DisplayText = "現金売上";
            valueListItem8.DataValue = 101;
            valueListItem8.DisplayText = "現金返品";
            this.tComboEditor_SalesSlipCd.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem4,
            valueListItem5,
            valueListItem6,
            valueListItem7,
            valueListItem8});
            this.tComboEditor_SalesSlipCd.Location = new System.Drawing.Point(284, 104);
            this.tComboEditor_SalesSlipCd.Name = "tComboEditor_SalesSlipCd";
            this.tComboEditor_SalesSlipCd.Size = new System.Drawing.Size(115, 24);
            this.tComboEditor_SalesSlipCd.TabIndex = 1251;
            // 
            // tComboEditor_SalesFormalCode
            // 
            appearance49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SalesFormalCode.ActiveAppearance = appearance49;
            this.tComboEditor_SalesFormalCode.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SalesFormalCode.ItemAppearance = appearance50;
            valueListItem9.DataValue = 30;
            valueListItem9.DisplayText = "売上";
            valueListItem10.DataValue = 40;
            valueListItem10.DisplayText = "貸出";
            valueListItem11.DataValue = 20;
            valueListItem11.DisplayText = "受注";
            valueListItem12.DataValue = 10;
            valueListItem12.DisplayText = "通常見積";
            valueListItem13.DataValue = 15;
            valueListItem13.DisplayText = "単価見積";
            valueListItem14.DataValue = 16;
            valueListItem14.DisplayText = "検索見積";
            valueListItem15.DataValue = -1;
            valueListItem15.DisplayText = "全て";
            this.tComboEditor_SalesFormalCode.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem9,
            valueListItem10,
            valueListItem11,
            valueListItem12,
            valueListItem13,
            valueListItem14,
            valueListItem15});
            this.tComboEditor_SalesFormalCode.Location = new System.Drawing.Point(85, 104);
            this.tComboEditor_SalesFormalCode.Name = "tComboEditor_SalesFormalCode";
            this.tComboEditor_SalesFormalCode.Size = new System.Drawing.Size(115, 24);
            this.tComboEditor_SalesFormalCode.TabIndex = 1250;
            this.tComboEditor_SalesFormalCode.ValueChanged += new System.EventHandler(this.tComboEditor_SalesFormalCode_ValueChanged);
            // 
            // ultraLabel6
            // 
            appearance13.ForeColorDisabled = System.Drawing.Color.Black;
            appearance13.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance13;
            this.ultraLabel6.Location = new System.Drawing.Point(12, 105);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(67, 24);
            this.ultraLabel6.TabIndex = 1254;
            this.ultraLabel6.Text = "伝票種別";
            // 
            // ultraLabel5
            // 
            appearance52.ForeColorDisabled = System.Drawing.Color.Black;
            appearance52.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance52;
            this.ultraLabel5.Location = new System.Drawing.Point(211, 104);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(67, 24);
            this.ultraLabel5.TabIndex = 1253;
            this.ultraLabel5.Text = "伝票区分";
            // 
            // ultraLabel7
            // 
            this.ultraLabel7.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraLabel7.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(1016, 648);
            this.ultraLabel7.TabIndex = 1209;
            // 
            // uStatusBar_Main
            // 
            this.uStatusBar_Main.Location = new System.Drawing.Point(0, 711);
            this.uStatusBar_Main.Name = "uStatusBar_Main";
            this.uStatusBar_Main.Size = new System.Drawing.Size(1016, 23);
            this.uStatusBar_Main.TabIndex = 54;
            this.uStatusBar_Main.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // timer_InitFocusSetting
            // 
            this.timer_InitFocusSetting.Interval = 1;
            this.timer_InitFocusSetting.Tick += new System.EventHandler(this.timer_InitFocusSetting_Tick);
            // 
            // timer_Search
            // 
            this.timer_Search.Interval = 1;
            this.timer_Search.Tick += new System.EventHandler(this.timer_Search_Tick);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // _MAURI02001UA_Toolbars_Dock_Area_Left
            // 
            this._MAURI02001UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAURI02001UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._MAURI02001UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._MAURI02001UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAURI02001UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 63);
            this._MAURI02001UA_Toolbars_Dock_Area_Left.Name = "_MAURI02001UA_Toolbars_Dock_Area_Left";
            this._MAURI02001UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 648);
            this._MAURI02001UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.tToolbarsManager_MainMenu;
            // 
            // tToolbarsManager_MainMenu
            // 
            this.tToolbarsManager_MainMenu.DesignerFlags = 1;
            this.tToolbarsManager_MainMenu.DockWithinContainer = this;
            this.tToolbarsManager_MainMenu.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.tToolbarsManager_MainMenu.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.tToolbarsManager_MainMenu.ShowFullMenusDelay = 500;
            this.tToolbarsManager_MainMenu.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.IsMainMenuBar = true;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1,
            popupMenuTool2,
            labelTool1,
            labelTool2,
            labelTool3});
            ultraToolbar1.ShowInToolbarList = false;
            ultraToolbar1.Text = "メインメニュー";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 1;
            buttonTool2.InstanceProps.IsFirstInGroup = true;
            buttonTool3.InstanceProps.IsFirstInGroup = true;
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            buttonTool4});
            ultraToolbar2.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar2.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar2.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.BelowImage;
            ultraToolbar2.Text = "標準";
            this.tToolbarsManager_MainMenu.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2});
            popupMenuTool3.SharedProps.Caption = "ファイル(&F)";
            popupMenuTool3.SharedProps.CustomizerCaption = "ファイルポップアップメニュー";
            popupMenuTool3.SharedProps.CustomizerDescription = "ファイルポップアップメニュー";
            buttonTool7.InstanceProps.IsFirstInGroup = true;
            popupMenuTool3.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool5,
            buttonTool6,
            buttonTool7});
            popupMenuTool4.SharedProps.Caption = "ツール(&T)";
            popupMenuTool4.SharedProps.CustomizerCaption = "ツールポップアップメニュー";
            popupMenuTool4.SharedProps.CustomizerDescription = "ツールポップアップメニュー";
            popupMenuTool5.SharedProps.Caption = "編集(&E)";
            popupMenuTool5.SharedProps.CustomizerCaption = "編集ポップアップメニュー";
            popupMenuTool5.SharedProps.CustomizerDescription = "編集ポップアップメニュー";
            popupMenuTool5.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool8});
            popupMenuTool6.SharedProps.Caption = "ガイド(&G)";
            popupMenuTool6.SharedProps.CustomizerCaption = "ガイドポップアップメニュー";
            popupMenuTool6.SharedProps.CustomizerDescription = "ガイドポップアップメニュー";
            popupMenuTool7.SharedProps.Caption = "ウィンドウ(&W)";
            popupMenuTool7.SharedProps.CustomizerCaption = "ウィンドウポップアップメニュー";
            popupMenuTool7.SharedProps.CustomizerDescription = "ウィンドウポップアップメニュー";
            buttonTool9.SharedProps.Caption = "終了(&X)";
            buttonTool9.SharedProps.CustomizerCaption = "終了ボタン";
            buttonTool9.SharedProps.CustomizerDescription = "終了ボタン";
            buttonTool9.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool9.SharedProps.ToolTipText = "画面を終了します。";
            buttonTool10.SharedProps.Caption = "確定(&S)";
            buttonTool10.SharedProps.CustomizerCaption = "確定ボタン";
            buttonTool10.SharedProps.CustomizerDescription = "確定ボタン";
            buttonTool10.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool10.SharedProps.ToolTipText = "売上伝票を選択します。";
            buttonTool11.SharedProps.Caption = "クリア(&C)";
            buttonTool11.SharedProps.CustomizerCaption = "クリアボタン";
            buttonTool11.SharedProps.CustomizerDescription = "クリアボタン";
            buttonTool11.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool11.SharedProps.ToolTipText = "画面を初期化します。";
            buttonTool12.SharedProps.Caption = "ガイド(&G)";
            buttonTool12.SharedProps.CustomizerCaption = "ガイドボタン";
            buttonTool12.SharedProps.CustomizerDescription = "ガイドボタン";
            buttonTool12.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool12.SharedProps.ToolTipText = "ガイドを起動します。";
            labelTool4.SharedProps.Caption = "ログイン担当者";
            labelTool4.SharedProps.MergeOrder = 98;
            appearance63.BackColor = System.Drawing.Color.White;
            appearance63.TextHAlignAsString = "Left";
            labelTool5.SharedProps.AppearancesSmall.Appearance = appearance63;
            labelTool5.SharedProps.Caption = "広葉　太郎";
            labelTool5.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            labelTool5.SharedProps.MergeOrder = 99;
            labelTool5.SharedProps.Width = 150;
            labelTool6.SharedProps.MergeOrder = 80;
            labelTool6.SharedProps.Spring = true;
            labelTool7.SharedProps.Caption = "入力拠点";
            labelTool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            labelTool7.SharedProps.MergeOrder = 96;
            buttonTool13.SharedProps.Caption = "設定(&O)";
            buttonTool13.SharedProps.CustomizerCaption = "設定ボタン";
            buttonTool13.SharedProps.CustomizerDescription = "設定ボタン";
            buttonTool13.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool13.SharedProps.ToolTipText = "動作設定を起動します。";
            buttonTool14.SharedProps.Caption = "検索(&R)";
            buttonTool14.SharedProps.CustomizerCaption = "検索ボタン";
            buttonTool14.SharedProps.CustomizerDescription = "検索ボタン";
            buttonTool14.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool14.SharedProps.ToolTipText = "売上伝票の検索を行います。";
            this.tToolbarsManager_MainMenu.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool3,
            popupMenuTool4,
            popupMenuTool5,
            popupMenuTool6,
            popupMenuTool7,
            buttonTool9,
            buttonTool10,
            buttonTool11,
            buttonTool12,
            labelTool4,
            labelTool5,
            labelTool6,
            labelTool7,
            buttonTool13,
            buttonTool14});
            this.tToolbarsManager_MainMenu.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.tToolbarsManager_MainMenu_ToolClick);
            // 
            // _MAURI02001UA_Toolbars_Dock_Area_Right
            // 
            this._MAURI02001UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAURI02001UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._MAURI02001UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._MAURI02001UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAURI02001UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1016, 63);
            this._MAURI02001UA_Toolbars_Dock_Area_Right.Name = "_MAURI02001UA_Toolbars_Dock_Area_Right";
            this._MAURI02001UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 648);
            this._MAURI02001UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.tToolbarsManager_MainMenu;
            // 
            // _MAURI02001UA_Toolbars_Dock_Area_Top
            // 
            this._MAURI02001UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAURI02001UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._MAURI02001UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._MAURI02001UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAURI02001UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._MAURI02001UA_Toolbars_Dock_Area_Top.Name = "_MAURI02001UA_Toolbars_Dock_Area_Top";
            this._MAURI02001UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1016, 63);
            this._MAURI02001UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.tToolbarsManager_MainMenu;
            // 
            // _MAURI02001UA_Toolbars_Dock_Area_Bottom
            // 
            this._MAURI02001UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAURI02001UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._MAURI02001UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._MAURI02001UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAURI02001UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 711);
            this._MAURI02001UA_Toolbars_Dock_Area_Bottom.Name = "_MAURI02001UA_Toolbars_Dock_Area_Bottom";
            this._MAURI02001UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1016, 0);
            this._MAURI02001UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.tToolbarsManager_MainMenu;
            // 
            // ultraExpandableGroupBox
            // 
            this.ultraExpandableGroupBox.Controls.Add(this.ultraExpandableGroupBoxPanel1);
            this.ultraExpandableGroupBox.ExpandedSize = new System.Drawing.Size(0, 0);
            this.ultraExpandableGroupBox.Location = new System.Drawing.Point(0, -54);
            this.ultraExpandableGroupBox.Name = "ultraExpandableGroupBox";
            this.ultraExpandableGroupBox.Size = new System.Drawing.Size(200, 185);
            this.ultraExpandableGroupBox.TabIndex = 0;
            // 
            // ultraExpandableGroupBoxPanel1
            // 
            this.ultraExpandableGroupBoxPanel1.Location = new System.Drawing.Point(0, 0);
            this.ultraExpandableGroupBoxPanel1.Name = "ultraExpandableGroupBoxPanel1";
            this.ultraExpandableGroupBoxPanel1.Size = new System.Drawing.Size(200, 100);
            this.ultraExpandableGroupBoxPanel1.TabIndex = 0;
            // 
            // MAHNB04110UA
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.MAURI02001UA_Fill_Panel);
            this.Controls.Add(this._MAURI02001UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._MAURI02001UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._MAURI02001UA_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._MAURI02001UA_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.uStatusBar_Main);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MAHNB04110UA";
            this.Text = "売上伝票照会";
            this.Load += new System.EventHandler(this.MAHNB04110UA_Load);
            this.Shown += new System.EventHandler(this.MAHNB04110UA_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MAHNB04110UA_FormClosing);
            this.MAURI02001UA_Fill_Panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uGrid_Result)).EndInit();
            this.ViewButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox1)).EndInit();
            this.ultraExpandableGroupBox1.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel2.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_AutoAnswerDivSCM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_FrontEmployeeCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesEmployeeCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesInputCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesSlipNum_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesSlipNum_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SubSectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_FullModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_ClaimCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SalesSlipCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SalesFormalCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tToolbarsManager_MainMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExpandableGroupBox)).EndInit();
            this.ultraExpandableGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private Broadleaf.Library.Windows.Forms.TToolbarsManager tToolbarsManager_MainMenu;
		private System.Windows.Forms.Panel MAURI02001UA_Fill_Panel;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAURI02001UA_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAURI02001UA_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAURI02001UA_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAURI02001UA_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar uStatusBar_Main;
        private System.Windows.Forms.Panel panel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private System.Windows.Forms.Timer timer_InitFocusSetting;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timer_Search;
        private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraExpandableGroupBox ultraExpandableGroupBox1;
        private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel ultraExpandableGroupBoxPanel2;
        private Broadleaf.Library.Windows.Forms.TDateEdit tDateEdit_SearchSlipDateSt;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_FrontEmployeeCd;
        private Broadleaf.Library.Windows.Forms.TDateEdit tDateEdit_SearchSlipDateEd;
        private Infragistics.Win.Misc.UltraLabel uLabel_FrontEmployeeName;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private Infragistics.Win.Misc.UltraButton uButton_FrontEmployeeCd;
        private Infragistics.Win.Misc.UltraLabel ultraLabel15;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SalesEmployeeCd;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SalesInputCode;
        private Infragistics.Win.Misc.UltraButton uButton_SalesEmployeeGuide;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private Infragistics.Win.Misc.UltraLabel uLabel_SalesInputName;
        private Infragistics.Win.Misc.UltraLabel uLabel_SalesEmployeeName;
        private Infragistics.Win.Misc.UltraLabel ultraLabel12;
        private Infragistics.Win.Misc.UltraButton uButton_SalesInputGuide;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Broadleaf.Library.Windows.Forms.TDateEdit tDateEdit_SalesDateSt;
        private Infragistics.Win.Misc.UltraLabel Lb_SearchSlipDate;
        private Broadleaf.Library.Windows.Forms.TDateEdit tDateEdit_SalesDateEd;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SalesSlipNum_Ed;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SalesSlipNum_St;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SectionCodeAllowZero;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_SubSectionCode;
        private Infragistics.Win.Misc.UltraButton ultraButton_SubSectionGuide;
        private Infragistics.Win.Misc.UltraButton SectionCodeGuide_ultraButton;
        private Infragistics.Win.Misc.UltraLabel ultraLabel14;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_FullModel;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_ClaimCode;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_CustomerCode;
        private Infragistics.Win.Misc.UltraButton uButton_CustomerGuide;
        private Infragistics.Win.Misc.UltraLabel ultraLabel13;
        private Infragistics.Win.Misc.UltraLabel uLabel_ClaimName;
        private Infragistics.Win.Misc.UltraLabel uLabel_CustomerName;
        private Infragistics.Win.Misc.UltraLabel ultraLabel16;
        private Infragistics.Win.Misc.UltraButton uButton_ClaimGuide;
        private Infragistics.Win.Misc.UltraLabel ultraLabel27;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_SalesSlipCd;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_SalesFormalCode;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.Misc.UltraExpandableGroupBox ultraExpandableGroupBox;
        private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel ultraExpandableGroupBoxPanel1;
        private Infragistics.Win.UltraWinGrid.UltraGrid uGrid_Result;
        private System.Windows.Forms.Panel ViewButtonPanel;
        public Infragistics.Win.Misc.UltraButton uButton_StockSearch;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel uLabel_SectionName;
        private Infragistics.Win.Misc.UltraLabel uLabel_SubSectionName;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor uCheckEditor_BlPaCOrder;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor uCheckEditor_PccForNS;
        private Infragistics.Win.Misc.UltraLabel ultraLabel18;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_AutoAnswerDivSCM;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
	}
}


namespace Broadleaf.Windows.Forms
{
	partial class MAKON01320UA
	{
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

        // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
        /// <summary>処分済みフラグ</summary>
        private bool _disposed;
        // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ----------<<<<<

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
                // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
                MAKON01320UA_FormClosing(this, null);
                // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ----------<<<<<

				components.Dispose();
			}
			base.Dispose(disposing);

            // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
            _disposed = true;
            // ADD 2009/12/04 MANTIS対応[14744]：伝票および明細グリッド列の列設定の変更 ----------<<<<<
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
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar_MainMenu");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Files");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Edits");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar_Standard");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Close");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Decision");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Search");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Undo");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Files");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Decision");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Close");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Tools");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool5 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Edits");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Undo");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool6 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Guides");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool7 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Windows");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Close");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Decision");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Undo");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_New");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_StockMove");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_AgencyShip");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool_Search");
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel5 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel6 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel7 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel8 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel9 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel10 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel11 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel12 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel13 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAKON01320UA));
            this.tComboEditor_GridFontSize = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.uCheckEditor_AutoFillToColumn = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.Form1_Fill_Panel = new System.Windows.Forms.Panel();
            this.panel_Detail = new System.Windows.Forms.Panel();
            this.Standard_UGroupBox = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.ultraExpandableGroupBoxPanel1 = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.uButton_SubSectionGuide = new Infragistics.Win.Misc.UltraButton();
            this.uLabel_SubSectionName = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_SubSectionCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uLabel_SubSection = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SupplierSlipNoEnd = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_PayeeCodeGuide = new Infragistics.Win.Misc.UltraButton();
            this.uLabel_PayeeName = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_PayeeCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uLabel_PayeeCodeTitle = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_SupplierSlipCd = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tComboEditor_SupplierFormal = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.uLabel_SupplierSlipCdTitle = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_SupplierFormalTitle = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SupplierSlipNoStart = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uLabel_SupplierSlipNoTitle = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_Date2Title = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_Date1Title = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.tDateEdit_Date2End = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.tDateEdit_Date1End = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.tDateEdit_Date2Start = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.tDateEdit_Date1Start = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.uButton_StockCustomerGuide = new Infragistics.Win.Misc.UltraButton();
            this.uLabel_SectionNm = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_SectionTitle = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_SectionGuide = new Infragistics.Win.Misc.UltraButton();
            this.uLabel_CustomerName = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SectionCd = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tNedit_SupplierCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uLabel_CustomerCodeTitle = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_EmployeeGuide = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_PartySaleSlipNum = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uLabel_StockAgentName = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_StockAgentCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uLabel_PartySaleSlipNumTitle = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_StockAgentCodeTitle = new Infragistics.Win.Misc.UltraLabel();
            this._Form1_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.tToolbarsManager_MainMenu = new Broadleaf.Library.Windows.Forms.TToolbarsManager(this.components);
            this._Form1_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Form1_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.uStatusBar_Main = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.timer_InitialSetFocus = new System.Windows.Forms.Timer(this.components);
            this._panel_SelectReflection_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._panel_SelectReflection_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._panel_SelectReflection_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsDockArea2 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsDockArea3 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsDockArea4 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsDockArea6 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsDockArea7 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsDockArea8 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Form1_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsDockArea1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsDockArea5 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsDockArea9 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_GridFontSize)).BeginInit();
            this.Form1_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Standard_UGroupBox)).BeginInit();
            this.Standard_UGroupBox.SuspendLayout();
            this.ultraExpandableGroupBoxPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SubSectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierSlipNoEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_PayeeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SupplierSlipCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SupplierFormal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierSlipNoStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_PartySaleSlipNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_StockAgentCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tToolbarsManager_MainMenu)).BeginInit();
            this.uStatusBar_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tComboEditor_GridFontSize
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_GridFontSize.ActiveAppearance = appearance1;
            this.tComboEditor_GridFontSize.AutoSize = false;
            this.tComboEditor_GridFontSize.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_GridFontSize.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_GridFontSize.ItemAppearance = appearance2;
            valueListItem1.DataValue = 10;
            valueListItem1.DisplayText = "10";
            valueListItem2.DataValue = 11;
            valueListItem2.DisplayText = "11";
            this.tComboEditor_GridFontSize.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.tComboEditor_GridFontSize.Location = new System.Drawing.Point(801, 3);
            this.tComboEditor_GridFontSize.Name = "tComboEditor_GridFontSize";
            this.tComboEditor_GridFontSize.Size = new System.Drawing.Size(40, 18);
            this.tComboEditor_GridFontSize.TabIndex = 18;
            // 
            // uCheckEditor_AutoFillToColumn
            // 
            appearance3.FontData.SizeInPoints = 9F;
            this.uCheckEditor_AutoFillToColumn.Appearance = appearance3;
            this.uCheckEditor_AutoFillToColumn.BackColor = System.Drawing.Color.Transparent;
            this.uCheckEditor_AutoFillToColumn.BackColorInternal = System.Drawing.Color.Transparent;
            this.uCheckEditor_AutoFillToColumn.Location = new System.Drawing.Point(705, 3);
            this.uCheckEditor_AutoFillToColumn.Name = "uCheckEditor_AutoFillToColumn";
            this.uCheckEditor_AutoFillToColumn.Size = new System.Drawing.Size(140, 18);
            this.uCheckEditor_AutoFillToColumn.TabIndex = 18;
            this.uCheckEditor_AutoFillToColumn.Text = "列サイズの自動調整";
            // 
            // Form1_Fill_Panel
            // 
            this.Form1_Fill_Panel.Controls.Add(this.panel_Detail);
            this.Form1_Fill_Panel.Controls.Add(this.Standard_UGroupBox);
            this.Form1_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.Form1_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Form1_Fill_Panel.Location = new System.Drawing.Point(0, 63);
            this.Form1_Fill_Panel.Margin = new System.Windows.Forms.Padding(4);
            this.Form1_Fill_Panel.Name = "Form1_Fill_Panel";
            this.Form1_Fill_Panel.Size = new System.Drawing.Size(942, 620);
            this.Form1_Fill_Panel.TabIndex = 0;
            // 
            // panel_Detail
            // 
            this.panel_Detail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.panel_Detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Detail.Location = new System.Drawing.Point(0, 161);
            this.panel_Detail.Margin = new System.Windows.Forms.Padding(4);
            this.panel_Detail.Name = "panel_Detail";
            this.panel_Detail.Size = new System.Drawing.Size(942, 459);
            this.panel_Detail.TabIndex = 300;
            // 
            // Standard_UGroupBox
            // 
            this.Standard_UGroupBox.Controls.Add(this.ultraExpandableGroupBoxPanel1);
            this.Standard_UGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.Standard_UGroupBox.ExpandedSize = new System.Drawing.Size(942, 161);
            this.Standard_UGroupBox.Location = new System.Drawing.Point(0, 0);
            this.Standard_UGroupBox.Name = "Standard_UGroupBox";
            this.Standard_UGroupBox.Size = new System.Drawing.Size(942, 161);
            this.Standard_UGroupBox.TabIndex = 0;
            this.Standard_UGroupBox.TabStop = false;
            this.Standard_UGroupBox.Text = "検索条件";
            // 
            // ultraExpandableGroupBoxPanel1
            // 
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uButton_SubSectionGuide);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_SubSectionName);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tNedit_SubSectionCode);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_SubSection);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_SupplierSlipNoEnd);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uButton_PayeeCodeGuide);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_PayeeName);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tNedit_PayeeCode);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_PayeeCodeTitle);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.ultraLabel3);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tComboEditor_SupplierSlipCd);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tComboEditor_SupplierFormal);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_SupplierSlipCdTitle);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_SupplierFormalTitle);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_SupplierSlipNoStart);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_SupplierSlipNoTitle);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_Date2Title);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_Date1Title);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.ultraLabel15);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.ultraLabel16);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tDateEdit_Date2End);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tDateEdit_Date1End);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tDateEdit_Date2Start);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tDateEdit_Date1Start);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uButton_StockCustomerGuide);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_SectionNm);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_SectionTitle);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uButton_SectionGuide);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_CustomerName);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_SectionCd);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tNedit_SupplierCd);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_CustomerCodeTitle);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uButton_EmployeeGuide);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_PartySaleSlipNum);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_StockAgentName);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_StockAgentCode);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_PartySaleSlipNumTitle);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_StockAgentCodeTitle);
            this.ultraExpandableGroupBoxPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraExpandableGroupBoxPanel1.Location = new System.Drawing.Point(3, 19);
            this.ultraExpandableGroupBoxPanel1.Name = "ultraExpandableGroupBoxPanel1";
            this.ultraExpandableGroupBoxPanel1.Size = new System.Drawing.Size(936, 139);
            this.ultraExpandableGroupBoxPanel1.TabIndex = 0;
            // 
            // uButton_SubSectionGuide
            // 
            appearance53.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance53.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_SubSectionGuide.Appearance = appearance53;
            this.uButton_SubSectionGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_SubSectionGuide.Location = new System.Drawing.Point(286, 28);
            this.uButton_SubSectionGuide.Name = "uButton_SubSectionGuide";
            this.uButton_SubSectionGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SubSectionGuide.TabIndex = 4;
            this.toolTip1.SetToolTip(this.uButton_SubSectionGuide, "拠点ガイド");
            this.uButton_SubSectionGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SubSectionGuide.Click += new System.EventHandler(this.uButton_SubSectionGuide_Click);
            // 
            // uLabel_SubSectionName
            // 
            appearance51.BackColor = System.Drawing.Color.Gainsboro;
            appearance51.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance51.TextHAlignAsString = "Left";
            appearance51.TextVAlignAsString = "Middle";
            this.uLabel_SubSectionName.Appearance = appearance51;
            this.uLabel_SubSectionName.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_SubSectionName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_SubSectionName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_SubSectionName.Location = new System.Drawing.Point(112, 28);
            this.uLabel_SubSectionName.Name = "uLabel_SubSectionName";
            this.uLabel_SubSectionName.Size = new System.Drawing.Size(171, 24);
            this.uLabel_SubSectionName.TabIndex = 1329;
            this.uLabel_SubSectionName.WrapText = false;
            // 
            // tNedit_SubSectionCode
            // 
            appearance33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_SubSectionCode.ActiveAppearance = appearance33;
            appearance69.TextHAlignAsString = "Left";
            this.tNedit_SubSectionCode.Appearance = appearance69;
            this.tNedit_SubSectionCode.AutoSelect = true;
            this.tNedit_SubSectionCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SubSectionCode.DataText = "";
            this.tNedit_SubSectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SubSectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SubSectionCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SubSectionCode.Location = new System.Drawing.Point(81, 28);
            this.tNedit_SubSectionCode.MaxLength = 6;
            this.tNedit_SubSectionCode.Name = "tNedit_SubSectionCode";
            this.tNedit_SubSectionCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_SubSectionCode.Size = new System.Drawing.Size(28, 24);
            this.tNedit_SubSectionCode.TabIndex = 3;
            // 
            // uLabel_SubSection
            // 
            appearance52.TextVAlignAsString = "Middle";
            this.uLabel_SubSection.Appearance = appearance52;
            this.uLabel_SubSection.Location = new System.Drawing.Point(10, 28);
            this.uLabel_SubSection.Name = "uLabel_SubSection";
            this.uLabel_SubSection.Size = new System.Drawing.Size(36, 23);
            this.uLabel_SubSection.TabIndex = 1327;
            this.uLabel_SubSection.Text = "部門";
            // 
            // tEdit_SupplierSlipNoEnd
            // 
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierSlipNoEnd.ActiveAppearance = appearance19;
            appearance20.TextHAlignAsString = "Left";
            this.tEdit_SupplierSlipNoEnd.Appearance = appearance20;
            this.tEdit_SupplierSlipNoEnd.AutoSelect = true;
            this.tEdit_SupplierSlipNoEnd.AutoSize = false;
            this.tEdit_SupplierSlipNoEnd.DataText = "";
            this.tEdit_SupplierSlipNoEnd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierSlipNoEnd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_SupplierSlipNoEnd.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_SupplierSlipNoEnd.Location = new System.Drawing.Point(656, 55);
            this.tEdit_SupplierSlipNoEnd.MaxLength = 9;
            this.tEdit_SupplierSlipNoEnd.Name = "tEdit_SupplierSlipNoEnd";
            this.tEdit_SupplierSlipNoEnd.Size = new System.Drawing.Size(82, 24);
            this.tEdit_SupplierSlipNoEnd.TabIndex = 16;
            this.tEdit_SupplierSlipNoEnd.Leave += new System.EventHandler(this.tEdit_SupplierSlipNoEnd_Leave);
            // 
            // uButton_PayeeCodeGuide
            // 
            appearance50.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance50.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_PayeeCodeGuide.Appearance = appearance50;
            this.uButton_PayeeCodeGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_PayeeCodeGuide.Location = new System.Drawing.Point(367, 80);
            this.uButton_PayeeCodeGuide.Name = "uButton_PayeeCodeGuide";
            this.uButton_PayeeCodeGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_PayeeCodeGuide.TabIndex = 8;
            this.toolTip1.SetToolTip(this.uButton_PayeeCodeGuide, "仕入先検索");
            this.uButton_PayeeCodeGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_PayeeCodeGuide.Click += new System.EventHandler(this.uButton_PayeeCodeGuide_Click);
            // 
            // uLabel_PayeeName
            // 
            appearance54.BackColor = System.Drawing.Color.Gainsboro;
            appearance54.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance54.TextHAlignAsString = "Left";
            appearance54.TextVAlignAsString = "Middle";
            this.uLabel_PayeeName.Appearance = appearance54;
            this.uLabel_PayeeName.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_PayeeName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_PayeeName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_PayeeName.Location = new System.Drawing.Point(169, 80);
            this.uLabel_PayeeName.Name = "uLabel_PayeeName";
            this.uLabel_PayeeName.Size = new System.Drawing.Size(195, 24);
            this.uLabel_PayeeName.TabIndex = 1326;
            this.uLabel_PayeeName.WrapText = false;
            // 
            // tNedit_PayeeCode
            // 
            appearance56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_PayeeCode.ActiveAppearance = appearance56;
            appearance57.TextHAlignAsString = "Left";
            this.tNedit_PayeeCode.Appearance = appearance57;
            this.tNedit_PayeeCode.AutoSelect = true;
            this.tNedit_PayeeCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_PayeeCode.DataText = "";
            this.tNedit_PayeeCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_PayeeCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_PayeeCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_PayeeCode.Location = new System.Drawing.Point(82, 80);
            this.tNedit_PayeeCode.MaxLength = 6;
            this.tNedit_PayeeCode.Name = "tNedit_PayeeCode";
            this.tNedit_PayeeCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_PayeeCode.Size = new System.Drawing.Size(82, 24);
            this.tNedit_PayeeCode.TabIndex = 7;
            // 
            // uLabel_PayeeCodeTitle
            // 
            appearance58.TextVAlignAsString = "Middle";
            this.uLabel_PayeeCodeTitle.Appearance = appearance58;
            this.uLabel_PayeeCodeTitle.Location = new System.Drawing.Point(10, 82);
            this.uLabel_PayeeCodeTitle.Name = "uLabel_PayeeCodeTitle";
            this.uLabel_PayeeCodeTitle.Size = new System.Drawing.Size(52, 23);
            this.uLabel_PayeeCodeTitle.TabIndex = 1324;
            this.uLabel_PayeeCodeTitle.Text = "支払先";
            // 
            // ultraLabel3
            // 
            appearance36.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance36;
            this.ultraLabel3.Location = new System.Drawing.Point(630, 56);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel3.TabIndex = 1323;
            this.ultraLabel3.Text = "～";
            // 
            // tComboEditor_SupplierSlipCd
            // 
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SupplierSlipCd.ActiveAppearance = appearance22;
            this.tComboEditor_SupplierSlipCd.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SupplierSlipCd.ItemAppearance = appearance23;
            valueListItem3.DataValue = 99;
            valueListItem3.DisplayText = "全て";
            valueListItem3.Tag = 1;
            valueListItem4.DataValue = 10;
            valueListItem4.DisplayText = "仕入";
            valueListItem4.Tag = 2;
            valueListItem5.DataValue = 20;
            valueListItem5.DisplayText = "返品";
            valueListItem5.Tag = "3";
            this.tComboEditor_SupplierSlipCd.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem4,
            valueListItem5});
            this.tComboEditor_SupplierSlipCd.Location = new System.Drawing.Point(261, 106);
            this.tComboEditor_SupplierSlipCd.Name = "tComboEditor_SupplierSlipCd";
            this.tComboEditor_SupplierSlipCd.Size = new System.Drawing.Size(103, 24);
            this.tComboEditor_SupplierSlipCd.TabIndex = 10;
            // 
            // tComboEditor_SupplierFormal
            // 
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SupplierFormal.ActiveAppearance = appearance24;
            this.tComboEditor_SupplierFormal.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SupplierFormal.ItemAppearance = appearance25;
            valueListItem6.DataValue = 0;
            valueListItem6.DisplayText = "仕入";
            valueListItem6.Tag = 1;
            valueListItem7.DataValue = 1;
            valueListItem7.DisplayText = "入荷";
            valueListItem7.Tag = 2;
            this.tComboEditor_SupplierFormal.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem6,
            valueListItem7});
            this.tComboEditor_SupplierFormal.Location = new System.Drawing.Point(82, 106);
            this.tComboEditor_SupplierFormal.Name = "tComboEditor_SupplierFormal";
            this.tComboEditor_SupplierFormal.Size = new System.Drawing.Size(103, 24);
            this.tComboEditor_SupplierFormal.TabIndex = 9;
            this.tComboEditor_SupplierFormal.Text = "仕入";
            this.tComboEditor_SupplierFormal.SelectionChanged += new System.EventHandler(this.tComboEditor_SupplierFormal_SelectionChanged);
            // 
            // uLabel_SupplierSlipCdTitle
            // 
            appearance31.TextVAlignAsString = "Middle";
            this.uLabel_SupplierSlipCdTitle.Appearance = appearance31;
            this.uLabel_SupplierSlipCdTitle.Location = new System.Drawing.Point(188, 108);
            this.uLabel_SupplierSlipCdTitle.Name = "uLabel_SupplierSlipCdTitle";
            this.uLabel_SupplierSlipCdTitle.Size = new System.Drawing.Size(67, 23);
            this.uLabel_SupplierSlipCdTitle.TabIndex = 1322;
            this.uLabel_SupplierSlipCdTitle.Text = "伝票区分";
            // 
            // uLabel_SupplierFormalTitle
            // 
            appearance32.TextVAlignAsString = "Middle";
            this.uLabel_SupplierFormalTitle.Appearance = appearance32;
            this.uLabel_SupplierFormalTitle.Location = new System.Drawing.Point(10, 108);
            this.uLabel_SupplierFormalTitle.Name = "uLabel_SupplierFormalTitle";
            this.uLabel_SupplierFormalTitle.Size = new System.Drawing.Size(72, 23);
            this.uLabel_SupplierFormalTitle.TabIndex = 1321;
            this.uLabel_SupplierFormalTitle.Text = "伝票種別";
            // 
            // tEdit_SupplierSlipNoStart
            // 
            appearance71.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierSlipNoStart.ActiveAppearance = appearance71;
            appearance72.TextHAlignAsString = "Left";
            this.tEdit_SupplierSlipNoStart.Appearance = appearance72;
            this.tEdit_SupplierSlipNoStart.AutoSelect = true;
            this.tEdit_SupplierSlipNoStart.AutoSize = false;
            this.tEdit_SupplierSlipNoStart.DataText = "";
            this.tEdit_SupplierSlipNoStart.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierSlipNoStart.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_SupplierSlipNoStart.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_SupplierSlipNoStart.Location = new System.Drawing.Point(540, 55);
            this.tEdit_SupplierSlipNoStart.MaxLength = 9;
            this.tEdit_SupplierSlipNoStart.Name = "tEdit_SupplierSlipNoStart";
            this.tEdit_SupplierSlipNoStart.Size = new System.Drawing.Size(82, 24);
            this.tEdit_SupplierSlipNoStart.TabIndex = 15;
            this.tEdit_SupplierSlipNoStart.Leave += new System.EventHandler(this.tEdit_SupplierSlipNoStart_Leave);
            // 
            // uLabel_SupplierSlipNoTitle
            // 
            appearance21.TextVAlignAsString = "Middle";
            this.uLabel_SupplierSlipNoTitle.Appearance = appearance21;
            this.uLabel_SupplierSlipNoTitle.Location = new System.Drawing.Point(442, 56);
            this.uLabel_SupplierSlipNoTitle.Name = "uLabel_SupplierSlipNoTitle";
            this.uLabel_SupplierSlipNoTitle.Size = new System.Drawing.Size(99, 23);
            this.uLabel_SupplierSlipNoTitle.TabIndex = 1313;
            this.uLabel_SupplierSlipNoTitle.Text = "仕入SEQ番号";
            // 
            // uLabel_Date2Title
            // 
            appearance34.TextVAlignAsString = "Middle";
            this.uLabel_Date2Title.Appearance = appearance34;
            this.uLabel_Date2Title.Location = new System.Drawing.Point(442, 29);
            this.uLabel_Date2Title.Name = "uLabel_Date2Title";
            this.uLabel_Date2Title.Size = new System.Drawing.Size(52, 23);
            this.uLabel_Date2Title.TabIndex = 1309;
            this.uLabel_Date2Title.Text = "入力日";
            // 
            // uLabel_Date1Title
            // 
            appearance35.TextVAlignAsString = "Middle";
            this.uLabel_Date1Title.Appearance = appearance35;
            this.uLabel_Date1Title.BackColorInternal = System.Drawing.Color.Transparent;
            this.uLabel_Date1Title.Location = new System.Drawing.Point(442, 3);
            this.uLabel_Date1Title.Name = "uLabel_Date1Title";
            this.uLabel_Date1Title.Size = new System.Drawing.Size(52, 23);
            this.uLabel_Date1Title.TabIndex = 1308;
            this.uLabel_Date1Title.Text = "仕入日";
            // 
            // ultraLabel15
            // 
            appearance27.TextVAlignAsString = "Middle";
            this.ultraLabel15.Appearance = appearance27;
            this.ultraLabel15.Location = new System.Drawing.Point(719, 28);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel15.TabIndex = 1310;
            this.ultraLabel15.Text = "～";
            // 
            // ultraLabel16
            // 
            appearance37.TextVAlignAsString = "Middle";
            this.ultraLabel16.Appearance = appearance37;
            this.ultraLabel16.Location = new System.Drawing.Point(719, 2);
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel16.TabIndex = 1311;
            this.ultraLabel16.Text = "～";
            // 
            // tDateEdit_Date2End
            // 
            appearance38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tDateEdit_Date2End.ActiveEditAppearance = appearance38;
            this.tDateEdit_Date2End.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit_Date2End.CalendarDisp = true;
            appearance39.TextHAlignAsString = "Left";
            appearance39.TextVAlignAsString = "Middle";
            this.tDateEdit_Date2End.EditAppearance = appearance39;
            this.tDateEdit_Date2End.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit_Date2End.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance40.TextHAlignAsString = "Left";
            appearance40.TextVAlignAsString = "Bottom";
            this.tDateEdit_Date2End.LabelAppearance = appearance40;
            this.tDateEdit_Date2End.Location = new System.Drawing.Point(742, 28);
            this.tDateEdit_Date2End.Name = "tDateEdit_Date2End";
            this.tDateEdit_Date2End.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit_Date2End.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.tDateEdit_Date2End.Size = new System.Drawing.Size(176, 24);
            this.tDateEdit_Date2End.TabIndex = 14;
            this.tDateEdit_Date2End.TabStop = true;
            // 
            // tDateEdit_Date1End
            // 
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tDateEdit_Date1End.ActiveEditAppearance = appearance41;
            this.tDateEdit_Date1End.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit_Date1End.CalendarDisp = true;
            appearance42.TextHAlignAsString = "Left";
            appearance42.TextVAlignAsString = "Middle";
            this.tDateEdit_Date1End.EditAppearance = appearance42;
            this.tDateEdit_Date1End.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit_Date1End.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance43.TextHAlignAsString = "Left";
            appearance43.TextVAlignAsString = "Bottom";
            this.tDateEdit_Date1End.LabelAppearance = appearance43;
            this.tDateEdit_Date1End.Location = new System.Drawing.Point(742, 2);
            this.tDateEdit_Date1End.Name = "tDateEdit_Date1End";
            this.tDateEdit_Date1End.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit_Date1End.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.tDateEdit_Date1End.Size = new System.Drawing.Size(176, 24);
            this.tDateEdit_Date1End.TabIndex = 12;
            this.tDateEdit_Date1End.TabStop = true;
            // 
            // tDateEdit_Date2Start
            // 
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tDateEdit_Date2Start.ActiveEditAppearance = appearance44;
            this.tDateEdit_Date2Start.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit_Date2Start.CalendarDisp = true;
            appearance45.TextHAlignAsString = "Left";
            appearance45.TextVAlignAsString = "Middle";
            this.tDateEdit_Date2Start.EditAppearance = appearance45;
            this.tDateEdit_Date2Start.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit_Date2Start.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance46.TextHAlignAsString = "Left";
            appearance46.TextVAlignAsString = "Bottom";
            this.tDateEdit_Date2Start.LabelAppearance = appearance46;
            this.tDateEdit_Date2Start.Location = new System.Drawing.Point(540, 28);
            this.tDateEdit_Date2Start.Name = "tDateEdit_Date2Start";
            this.tDateEdit_Date2Start.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit_Date2Start.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.tDateEdit_Date2Start.Size = new System.Drawing.Size(176, 24);
            this.tDateEdit_Date2Start.TabIndex = 13;
            this.tDateEdit_Date2Start.TabStop = true;
            // 
            // tDateEdit_Date1Start
            // 
            appearance47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tDateEdit_Date1Start.ActiveEditAppearance = appearance47;
            this.tDateEdit_Date1Start.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit_Date1Start.CalendarDisp = true;
            appearance48.TextHAlignAsString = "Left";
            appearance48.TextVAlignAsString = "Middle";
            this.tDateEdit_Date1Start.EditAppearance = appearance48;
            this.tDateEdit_Date1Start.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit_Date1Start.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance49.TextHAlignAsString = "Left";
            appearance49.TextVAlignAsString = "Bottom";
            this.tDateEdit_Date1Start.LabelAppearance = appearance49;
            this.tDateEdit_Date1Start.Location = new System.Drawing.Point(540, 2);
            this.tDateEdit_Date1Start.Name = "tDateEdit_Date1Start";
            this.tDateEdit_Date1Start.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit_Date1Start.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.tDateEdit_Date1Start.Size = new System.Drawing.Size(176, 24);
            this.tDateEdit_Date1Start.TabIndex = 11;
            this.tDateEdit_Date1Start.TabStop = true;
            // 
            // uButton_StockCustomerGuide
            // 
            appearance30.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance30.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_StockCustomerGuide.Appearance = appearance30;
            this.uButton_StockCustomerGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_StockCustomerGuide.Location = new System.Drawing.Point(367, 54);
            this.uButton_StockCustomerGuide.Name = "uButton_StockCustomerGuide";
            this.uButton_StockCustomerGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_StockCustomerGuide.TabIndex = 6;
            this.toolTip1.SetToolTip(this.uButton_StockCustomerGuide, "仕入先検索");
            this.uButton_StockCustomerGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_StockCustomerGuide.Click += new System.EventHandler(this.uButton_StockCustomerGuide_Click);
            // 
            // uLabel_SectionNm
            // 
            appearance4.BackColor = System.Drawing.Color.Gainsboro;
            appearance4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Middle";
            this.uLabel_SectionNm.Appearance = appearance4;
            this.uLabel_SectionNm.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_SectionNm.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_SectionNm.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_SectionNm.Location = new System.Drawing.Point(112, 2);
            this.uLabel_SectionNm.Name = "uLabel_SectionNm";
            this.uLabel_SectionNm.Size = new System.Drawing.Size(171, 24);
            this.uLabel_SectionNm.TabIndex = 1293;
            this.uLabel_SectionNm.WrapText = false;
            // 
            // uLabel_SectionTitle
            // 
            appearance5.TextVAlignAsString = "Middle";
            this.uLabel_SectionTitle.Appearance = appearance5;
            this.uLabel_SectionTitle.Location = new System.Drawing.Point(10, 3);
            this.uLabel_SectionTitle.Name = "uLabel_SectionTitle";
            this.uLabel_SectionTitle.Size = new System.Drawing.Size(36, 23);
            this.uLabel_SectionTitle.TabIndex = 1292;
            this.uLabel_SectionTitle.Text = "拠点";
            // 
            // uButton_SectionGuide
            // 
            appearance6.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance6.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_SectionGuide.Appearance = appearance6;
            this.uButton_SectionGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_SectionGuide.Location = new System.Drawing.Point(286, 2);
            this.uButton_SectionGuide.Name = "uButton_SectionGuide";
            this.uButton_SectionGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SectionGuide.TabIndex = 2;
            this.toolTip1.SetToolTip(this.uButton_SectionGuide, "拠点ガイド");
            this.uButton_SectionGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SectionGuide.Click += new System.EventHandler(this.uButton_SectionGuide_Click);
            // 
            // uLabel_CustomerName
            // 
            appearance70.BackColor = System.Drawing.Color.Gainsboro;
            appearance70.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance70.TextHAlignAsString = "Left";
            appearance70.TextVAlignAsString = "Middle";
            this.uLabel_CustomerName.Appearance = appearance70;
            this.uLabel_CustomerName.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_CustomerName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_CustomerName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_CustomerName.Location = new System.Drawing.Point(169, 54);
            this.uLabel_CustomerName.Name = "uLabel_CustomerName";
            this.uLabel_CustomerName.Size = new System.Drawing.Size(195, 24);
            this.uLabel_CustomerName.TabIndex = 1306;
            this.uLabel_CustomerName.WrapText = false;
            // 
            // tEdit_SectionCd
            // 
            appearance55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SectionCd.ActiveAppearance = appearance55;
            this.tEdit_SectionCd.AutoSelect = true;
            this.tEdit_SectionCd.DataText = "";
            this.tEdit_SectionCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tEdit_SectionCd.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_SectionCd.Location = new System.Drawing.Point(81, 2);
            this.tEdit_SectionCd.MaxLength = 2;
            this.tEdit_SectionCd.Name = "tEdit_SectionCd";
            this.tEdit_SectionCd.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCd.TabIndex = 1;
            // 
            // tNedit_SupplierCd
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_SupplierCd.ActiveAppearance = appearance7;
            appearance8.TextHAlignAsString = "Left";
            this.tNedit_SupplierCd.Appearance = appearance8;
            this.tNedit_SupplierCd.AutoSelect = true;
            this.tNedit_SupplierCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierCd.DataText = "";
            this.tNedit_SupplierCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SupplierCd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SupplierCd.Location = new System.Drawing.Point(82, 54);
            this.tNedit_SupplierCd.MaxLength = 6;
            this.tNedit_SupplierCd.Name = "tNedit_SupplierCd";
            this.tNedit_SupplierCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_SupplierCd.Size = new System.Drawing.Size(82, 24);
            this.tNedit_SupplierCd.TabIndex = 5;
            // 
            // uLabel_CustomerCodeTitle
            // 
            appearance29.TextVAlignAsString = "Middle";
            this.uLabel_CustomerCodeTitle.Appearance = appearance29;
            this.uLabel_CustomerCodeTitle.Location = new System.Drawing.Point(10, 55);
            this.uLabel_CustomerCodeTitle.Name = "uLabel_CustomerCodeTitle";
            this.uLabel_CustomerCodeTitle.Size = new System.Drawing.Size(52, 23);
            this.uLabel_CustomerCodeTitle.TabIndex = 1302;
            this.uLabel_CustomerCodeTitle.Text = "仕入先";
            // 
            // uButton_EmployeeGuide
            // 
            appearance59.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance59.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_EmployeeGuide.Appearance = appearance59;
            this.uButton_EmployeeGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_EmployeeGuide.Location = new System.Drawing.Point(790, 107);
            this.uButton_EmployeeGuide.Name = "uButton_EmployeeGuide";
            this.uButton_EmployeeGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_EmployeeGuide.TabIndex = 19;
            this.toolTip1.SetToolTip(this.uButton_EmployeeGuide, "担当者ガイド");
            this.uButton_EmployeeGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_EmployeeGuide.Click += new System.EventHandler(this.uButton_EmployeeGuide_Click);
            // 
            // tEdit_PartySaleSlipNum
            // 
            appearance60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_PartySaleSlipNum.ActiveAppearance = appearance60;
            appearance61.TextHAlignAsString = "Left";
            this.tEdit_PartySaleSlipNum.Appearance = appearance61;
            this.tEdit_PartySaleSlipNum.AutoSelect = true;
            this.tEdit_PartySaleSlipNum.AutoSize = false;
            this.tEdit_PartySaleSlipNum.DataText = "";
            this.tEdit_PartySaleSlipNum.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_PartySaleSlipNum.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 19, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_PartySaleSlipNum.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_PartySaleSlipNum.Location = new System.Drawing.Point(540, 81);
            this.tEdit_PartySaleSlipNum.MaxLength = 19;
            this.tEdit_PartySaleSlipNum.Name = "tEdit_PartySaleSlipNum";
            this.tEdit_PartySaleSlipNum.Size = new System.Drawing.Size(159, 24);
            this.tEdit_PartySaleSlipNum.TabIndex = 17;
            // 
            // uLabel_StockAgentName
            // 
            appearance62.BackColor = System.Drawing.Color.Gainsboro;
            appearance62.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance62.TextHAlignAsString = "Left";
            appearance62.TextVAlignAsString = "Middle";
            this.uLabel_StockAgentName.Appearance = appearance62;
            this.uLabel_StockAgentName.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_StockAgentName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_StockAgentName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_StockAgentName.Location = new System.Drawing.Point(588, 107);
            this.uLabel_StockAgentName.Name = "uLabel_StockAgentName";
            this.uLabel_StockAgentName.Size = new System.Drawing.Size(199, 24);
            this.uLabel_StockAgentName.TabIndex = 1300;
            this.uLabel_StockAgentName.WrapText = false;
            // 
            // tEdit_StockAgentCode
            // 
            appearance63.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_StockAgentCode.ActiveAppearance = appearance63;
            this.tEdit_StockAgentCode.AutoSelect = true;
            this.tEdit_StockAgentCode.DataText = "";
            this.tEdit_StockAgentCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_StockAgentCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.tEdit_StockAgentCode.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_StockAgentCode.Location = new System.Drawing.Point(540, 107);
            this.tEdit_StockAgentCode.MaxLength = 9;
            this.tEdit_StockAgentCode.Name = "tEdit_StockAgentCode";
            this.tEdit_StockAgentCode.Size = new System.Drawing.Size(43, 24);
            this.tEdit_StockAgentCode.TabIndex = 18;
            // 
            // uLabel_PartySaleSlipNumTitle
            // 
            appearance64.TextVAlignAsString = "Middle";
            this.uLabel_PartySaleSlipNumTitle.Appearance = appearance64;
            this.uLabel_PartySaleSlipNumTitle.Location = new System.Drawing.Point(442, 81);
            this.uLabel_PartySaleSlipNumTitle.Name = "uLabel_PartySaleSlipNumTitle";
            this.uLabel_PartySaleSlipNumTitle.Size = new System.Drawing.Size(83, 23);
            this.uLabel_PartySaleSlipNumTitle.TabIndex = 1295;
            this.uLabel_PartySaleSlipNumTitle.Text = "伝票番号";
            // 
            // uLabel_StockAgentCodeTitle
            // 
            appearance65.TextVAlignAsString = "Middle";
            this.uLabel_StockAgentCodeTitle.Appearance = appearance65;
            this.uLabel_StockAgentCodeTitle.Location = new System.Drawing.Point(442, 107);
            this.uLabel_StockAgentCodeTitle.Name = "uLabel_StockAgentCodeTitle";
            this.uLabel_StockAgentCodeTitle.Size = new System.Drawing.Size(67, 23);
            this.uLabel_StockAgentCodeTitle.TabIndex = 1294;
            this.uLabel_StockAgentCodeTitle.Text = "担当者";
            // 
            // _Form1_Toolbars_Dock_Area_Left
            // 
            this._Form1_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form1_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._Form1_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._Form1_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form1_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 63);
            this._Form1_Toolbars_Dock_Area_Left.Margin = new System.Windows.Forms.Padding(4);
            this._Form1_Toolbars_Dock_Area_Left.Name = "_Form1_Toolbars_Dock_Area_Left";
            this._Form1_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 620);
            this._Form1_Toolbars_Dock_Area_Left.ToolbarsManager = this.tToolbarsManager_MainMenu;
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
            popupMenuTool2});
            ultraToolbar1.ShowInToolbarList = false;
            ultraToolbar1.Text = "メインメニュー";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 1;
            buttonTool2.InstanceProps.IsFirstInGroup = true;
            buttonTool3.InstanceProps.IsFirstInGroup = true;
            buttonTool4.InstanceProps.IsFirstInGroup = true;
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
            buttonTool6.InstanceProps.IsFirstInGroup = true;
            popupMenuTool3.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool5,
            buttonTool6});
            popupMenuTool4.SharedProps.Caption = "ツール(&T)";
            popupMenuTool4.SharedProps.CustomizerCaption = "ツールポップアップメニュー";
            popupMenuTool4.SharedProps.CustomizerDescription = "ツールポップアップメニュー";
            popupMenuTool5.SharedProps.Caption = "編集(&E)";
            popupMenuTool5.SharedProps.CustomizerCaption = "編集ポップアップメニュー";
            popupMenuTool5.SharedProps.CustomizerDescription = "編集ポップアップメニュー";
            popupMenuTool5.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool7});
            popupMenuTool6.SharedProps.Caption = "ガイド(&G)";
            popupMenuTool6.SharedProps.CustomizerCaption = "ガイドポップアップメニュー";
            popupMenuTool6.SharedProps.CustomizerDescription = "ガイドポップアップメニュー";
            popupMenuTool7.SharedProps.Caption = "ウィンドウ(&W)";
            popupMenuTool7.SharedProps.CustomizerCaption = "ウィンドウポップアップメニュー";
            popupMenuTool7.SharedProps.CustomizerDescription = "ウィンドウポップアップメニュー";
            buttonTool8.SharedProps.Caption = "終了(&X)";
            buttonTool8.SharedProps.CustomizerCaption = "終了ボタン";
            buttonTool8.SharedProps.CustomizerDescription = "終了ボタン";
            buttonTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool9.SharedProps.Caption = "確定(&S)";
            buttonTool9.SharedProps.CustomizerCaption = "確定ボタン";
            buttonTool9.SharedProps.CustomizerDescription = "確定ボタン";
            buttonTool9.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool10.SharedProps.Caption = "クリア(&C)";
            buttonTool10.SharedProps.CustomizerCaption = "クリアボタン";
            buttonTool10.SharedProps.CustomizerDescription = "クリアボタン";
            buttonTool10.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool11.SharedProps.Caption = "新規(&N)";
            buttonTool11.SharedProps.CustomizerCaption = "新規ボタン";
            buttonTool11.SharedProps.CustomizerDescription = "新規ボタン";
            buttonTool11.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool12.SharedProps.Caption = "店間在庫移動";
            buttonTool12.SharedProps.CustomizerCaption = "店間在庫移動ボタン";
            buttonTool12.SharedProps.CustomizerDescription = "店間在庫移動ボタン";
            buttonTool12.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool13.SharedProps.Caption = "代理店出荷";
            buttonTool13.SharedProps.CustomizerCaption = "代理店出荷ボタン";
            buttonTool13.SharedProps.CustomizerDescription = "代理店出荷ボタン";
            buttonTool13.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool14.SharedProps.Caption = "検索(&R)";
            buttonTool14.SharedProps.CustomizerCaption = "検索ボタン";
            buttonTool14.SharedProps.CustomizerDescription = "検索ボタン";
            buttonTool14.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.tToolbarsManager_MainMenu.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool3,
            popupMenuTool4,
            popupMenuTool5,
            popupMenuTool6,
            popupMenuTool7,
            buttonTool8,
            buttonTool9,
            buttonTool10,
            buttonTool11,
            buttonTool12,
            buttonTool13,
            buttonTool14});
            this.tToolbarsManager_MainMenu.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.tToolbarsManager_MainMenu_ToolClick);
            // 
            // _Form1_Toolbars_Dock_Area_Right
            // 
            this._Form1_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form1_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._Form1_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._Form1_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form1_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(942, 63);
            this._Form1_Toolbars_Dock_Area_Right.Margin = new System.Windows.Forms.Padding(4);
            this._Form1_Toolbars_Dock_Area_Right.Name = "_Form1_Toolbars_Dock_Area_Right";
            this._Form1_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 620);
            this._Form1_Toolbars_Dock_Area_Right.ToolbarsManager = this.tToolbarsManager_MainMenu;
            // 
            // _Form1_Toolbars_Dock_Area_Bottom
            // 
            this._Form1_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form1_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._Form1_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._Form1_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form1_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 683);
            this._Form1_Toolbars_Dock_Area_Bottom.Margin = new System.Windows.Forms.Padding(4);
            this._Form1_Toolbars_Dock_Area_Bottom.Name = "_Form1_Toolbars_Dock_Area_Bottom";
            this._Form1_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(942, 0);
            this._Form1_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.tToolbarsManager_MainMenu;
            // 
            // uStatusBar_Main
            // 
            this.uStatusBar_Main.Controls.Add(this.tComboEditor_GridFontSize);
            this.uStatusBar_Main.Controls.Add(this.uCheckEditor_AutoFillToColumn);
            this.uStatusBar_Main.Location = new System.Drawing.Point(0, 683);
            this.uStatusBar_Main.Name = "uStatusBar_Main";
            appearance66.FontData.SizeInPoints = 9F;
            ultraStatusPanel1.Appearance = appearance66;
            ultraStatusPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel1.Key = "StatusBarPanel_Text";
            ultraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            appearance67.FontData.SizeInPoints = 9F;
            ultraStatusPanel2.Appearance = appearance67;
            ultraStatusPanel2.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel2.Key = "StatusBarPanel_FontSizeTitle";
            ultraStatusPanel2.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic;
            ultraStatusPanel2.Text = "文字サイズ";
            ultraStatusPanel2.Visible = false;
            ultraStatusPanel3.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel3.Control = this.tComboEditor_GridFontSize;
            ultraStatusPanel3.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel3.Visible = false;
            ultraStatusPanel3.Width = 40;
            ultraStatusPanel4.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel4.Key = "blank1";
            ultraStatusPanel4.Visible = false;
            ultraStatusPanel4.Width = 2;
            ultraStatusPanel5.Key = "line1";
            ultraStatusPanel5.Visible = false;
            ultraStatusPanel5.Width = 1;
            ultraStatusPanel6.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel6.Key = "blank2";
            ultraStatusPanel6.Width = 2;
            ultraStatusPanel7.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel7.Control = this.uCheckEditor_AutoFillToColumn;
            ultraStatusPanel7.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel7.Visible = false;
            ultraStatusPanel7.Width = 140;
            ultraStatusPanel8.Key = "line2";
            ultraStatusPanel8.Visible = false;
            ultraStatusPanel8.Width = 1;
            ultraStatusPanel9.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel9.Key = "blank3";
            ultraStatusPanel9.Visible = false;
            ultraStatusPanel9.Width = 2;
            ultraStatusPanel10.Key = "StatusBarPanel_Progress";
            appearance68.ForeColor = System.Drawing.Color.Black;
            ultraStatusPanel10.ProgressBarInfo.FillAppearance = appearance68;
            ultraStatusPanel10.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Progress;
            ultraStatusPanel10.Visible = false;
            ultraStatusPanel10.Width = 150;
            ultraStatusPanel11.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel11.Key = "blank4";
            ultraStatusPanel11.Width = 1;
            ultraStatusPanel12.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel12.Key = "StatusBarPanel_Date";
            ultraStatusPanel12.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Date;
            ultraStatusPanel12.Width = 90;
            ultraStatusPanel13.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel13.Key = "StatusBarPanel_Time";
            ultraStatusPanel13.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Time;
            ultraStatusPanel13.Width = 50;
            this.uStatusBar_Main.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3,
            ultraStatusPanel4,
            ultraStatusPanel5,
            ultraStatusPanel6,
            ultraStatusPanel7,
            ultraStatusPanel8,
            ultraStatusPanel9,
            ultraStatusPanel10,
            ultraStatusPanel11,
            ultraStatusPanel12,
            ultraStatusPanel13});
            this.uStatusBar_Main.Size = new System.Drawing.Size(942, 23);
            this.uStatusBar_Main.TabIndex = 52;
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
            // timer_InitialSetFocus
            // 
            this.timer_InitialSetFocus.Interval = 1;
            this.timer_InitialSetFocus.Tick += new System.EventHandler(this.timer_InitialSetFocus_Tick);
            // 
            // _panel_SelectReflection_Toolbars_Dock_Area_Bottom
            // 
            this._panel_SelectReflection_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panel_SelectReflection_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._panel_SelectReflection_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._panel_SelectReflection_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panel_SelectReflection_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 683);
            this._panel_SelectReflection_Toolbars_Dock_Area_Bottom.Name = "_panel_SelectReflection_Toolbars_Dock_Area_Bottom";
            this._panel_SelectReflection_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(942, 0);
            this._panel_SelectReflection_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.tToolbarsManager_MainMenu;
            // 
            // _panel_SelectReflection_Toolbars_Dock_Area_Left
            // 
            this._panel_SelectReflection_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panel_SelectReflection_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._panel_SelectReflection_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._panel_SelectReflection_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panel_SelectReflection_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 63);
            this._panel_SelectReflection_Toolbars_Dock_Area_Left.Name = "_panel_SelectReflection_Toolbars_Dock_Area_Left";
            this._panel_SelectReflection_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 620);
            this._panel_SelectReflection_Toolbars_Dock_Area_Left.ToolbarsManager = this.tToolbarsManager_MainMenu;
            // 
            // _panel_SelectReflection_Toolbars_Dock_Area_Right
            // 
            this._panel_SelectReflection_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panel_SelectReflection_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._panel_SelectReflection_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._panel_SelectReflection_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panel_SelectReflection_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(942, 63);
            this._panel_SelectReflection_Toolbars_Dock_Area_Right.Name = "_panel_SelectReflection_Toolbars_Dock_Area_Right";
            this._panel_SelectReflection_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 620);
            this._panel_SelectReflection_Toolbars_Dock_Area_Right.ToolbarsManager = this.tToolbarsManager_MainMenu;
            // 
            // ultraToolbarsDockArea2
            // 
            this.ultraToolbarsDockArea2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.ultraToolbarsDockArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this.ultraToolbarsDockArea2.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this.ultraToolbarsDockArea2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ultraToolbarsDockArea2.Location = new System.Drawing.Point(0, 683);
            this.ultraToolbarsDockArea2.Name = "ultraToolbarsDockArea2";
            this.ultraToolbarsDockArea2.Size = new System.Drawing.Size(942, 0);
            this.ultraToolbarsDockArea2.ToolbarsManager = this.tToolbarsManager_MainMenu;
            // 
            // ultraToolbarsDockArea3
            // 
            this.ultraToolbarsDockArea3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.ultraToolbarsDockArea3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this.ultraToolbarsDockArea3.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this.ultraToolbarsDockArea3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ultraToolbarsDockArea3.Location = new System.Drawing.Point(0, 63);
            this.ultraToolbarsDockArea3.Name = "ultraToolbarsDockArea3";
            this.ultraToolbarsDockArea3.Size = new System.Drawing.Size(0, 620);
            this.ultraToolbarsDockArea3.ToolbarsManager = this.tToolbarsManager_MainMenu;
            // 
            // ultraToolbarsDockArea4
            // 
            this.ultraToolbarsDockArea4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.ultraToolbarsDockArea4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this.ultraToolbarsDockArea4.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this.ultraToolbarsDockArea4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ultraToolbarsDockArea4.Location = new System.Drawing.Point(942, 63);
            this.ultraToolbarsDockArea4.Name = "ultraToolbarsDockArea4";
            this.ultraToolbarsDockArea4.Size = new System.Drawing.Size(0, 620);
            this.ultraToolbarsDockArea4.ToolbarsManager = this.tToolbarsManager_MainMenu;
            // 
            // ultraToolbarsDockArea6
            // 
            this.ultraToolbarsDockArea6.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.ultraToolbarsDockArea6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this.ultraToolbarsDockArea6.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this.ultraToolbarsDockArea6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ultraToolbarsDockArea6.Location = new System.Drawing.Point(0, 683);
            this.ultraToolbarsDockArea6.Name = "ultraToolbarsDockArea6";
            this.ultraToolbarsDockArea6.Size = new System.Drawing.Size(942, 0);
            this.ultraToolbarsDockArea6.ToolbarsManager = this.tToolbarsManager_MainMenu;
            // 
            // ultraToolbarsDockArea7
            // 
            this.ultraToolbarsDockArea7.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.ultraToolbarsDockArea7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this.ultraToolbarsDockArea7.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this.ultraToolbarsDockArea7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ultraToolbarsDockArea7.Location = new System.Drawing.Point(0, 63);
            this.ultraToolbarsDockArea7.Name = "ultraToolbarsDockArea7";
            this.ultraToolbarsDockArea7.Size = new System.Drawing.Size(0, 620);
            this.ultraToolbarsDockArea7.ToolbarsManager = this.tToolbarsManager_MainMenu;
            // 
            // ultraToolbarsDockArea8
            // 
            this.ultraToolbarsDockArea8.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.ultraToolbarsDockArea8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this.ultraToolbarsDockArea8.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this.ultraToolbarsDockArea8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ultraToolbarsDockArea8.Location = new System.Drawing.Point(942, 63);
            this.ultraToolbarsDockArea8.Name = "ultraToolbarsDockArea8";
            this.ultraToolbarsDockArea8.Size = new System.Drawing.Size(0, 620);
            this.ultraToolbarsDockArea8.ToolbarsManager = this.tToolbarsManager_MainMenu;
            // 
            // _Form1_Toolbars_Dock_Area_Top
            // 
            this._Form1_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form1_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._Form1_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._Form1_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form1_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._Form1_Toolbars_Dock_Area_Top.Margin = new System.Windows.Forms.Padding(4);
            this._Form1_Toolbars_Dock_Area_Top.Name = "_Form1_Toolbars_Dock_Area_Top";
            this._Form1_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(942, 63);
            this._Form1_Toolbars_Dock_Area_Top.ToolbarsManager = this.tToolbarsManager_MainMenu;
            // 
            // ultraToolbarsDockArea1
            // 
            this.ultraToolbarsDockArea1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.ultraToolbarsDockArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this.ultraToolbarsDockArea1.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this.ultraToolbarsDockArea1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ultraToolbarsDockArea1.Location = new System.Drawing.Point(0, 683);
            this.ultraToolbarsDockArea1.Margin = new System.Windows.Forms.Padding(4);
            this.ultraToolbarsDockArea1.Name = "ultraToolbarsDockArea1";
            this.ultraToolbarsDockArea1.Size = new System.Drawing.Size(942, 0);
            this.ultraToolbarsDockArea1.ToolbarsManager = this.tToolbarsManager_MainMenu;
            // 
            // ultraToolbarsDockArea5
            // 
            this.ultraToolbarsDockArea5.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.ultraToolbarsDockArea5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this.ultraToolbarsDockArea5.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this.ultraToolbarsDockArea5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ultraToolbarsDockArea5.Location = new System.Drawing.Point(0, 63);
            this.ultraToolbarsDockArea5.Margin = new System.Windows.Forms.Padding(4);
            this.ultraToolbarsDockArea5.Name = "ultraToolbarsDockArea5";
            this.ultraToolbarsDockArea5.Size = new System.Drawing.Size(0, 620);
            this.ultraToolbarsDockArea5.ToolbarsManager = this.tToolbarsManager_MainMenu;
            // 
            // ultraToolbarsDockArea9
            // 
            this.ultraToolbarsDockArea9.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.ultraToolbarsDockArea9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this.ultraToolbarsDockArea9.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this.ultraToolbarsDockArea9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ultraToolbarsDockArea9.Location = new System.Drawing.Point(942, 63);
            this.ultraToolbarsDockArea9.Margin = new System.Windows.Forms.Padding(4);
            this.ultraToolbarsDockArea9.Name = "ultraToolbarsDockArea9";
            this.ultraToolbarsDockArea9.Size = new System.Drawing.Size(0, 620);
            this.ultraToolbarsDockArea9.ToolbarsManager = this.tToolbarsManager_MainMenu;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // MAKON01320UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 706);
            this.Controls.Add(this.Form1_Fill_Panel);
            this.Controls.Add(this.ultraToolbarsDockArea5);
            this.Controls.Add(this.ultraToolbarsDockArea9);
            this.Controls.Add(this.ultraToolbarsDockArea7);
            this.Controls.Add(this.ultraToolbarsDockArea8);
            this.Controls.Add(this.ultraToolbarsDockArea3);
            this.Controls.Add(this.ultraToolbarsDockArea4);
            this.Controls.Add(this._panel_SelectReflection_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._panel_SelectReflection_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._Form1_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._Form1_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._Form1_Toolbars_Dock_Area_Top);
            this.Controls.Add(this.ultraToolbarsDockArea1);
            this.Controls.Add(this.ultraToolbarsDockArea6);
            this.Controls.Add(this.ultraToolbarsDockArea2);
            this.Controls.Add(this._panel_SelectReflection_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this._Form1_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.uStatusBar_Main);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MAKON01320UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "仕入伝票照会";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MAKON01320UA_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MAKON01320UA_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_GridFontSize)).EndInit();
            this.Form1_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Standard_UGroupBox)).EndInit();
            this.Standard_UGroupBox.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel1.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SubSectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierSlipNoEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_PayeeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SupplierSlipCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SupplierFormal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierSlipNoStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_PartySaleSlipNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_StockAgentCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tToolbarsManager_MainMenu)).EndInit();
            this.uStatusBar_Main.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Panel Form1_Fill_Panel;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Form1_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Form1_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Form1_Toolbars_Dock_Area_Bottom;
		private System.Windows.Forms.Panel panel_Detail;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar uStatusBar_Main;
		private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_GridFontSize;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor uCheckEditor_AutoFillToColumn;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.Misc.UltraExpandableGroupBox Standard_UGroupBox;
        private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel ultraExpandableGroupBoxPanel1;
        private System.Windows.Forms.Timer timer_InitialSetFocus;
        private Infragistics.Win.Misc.UltraLabel uLabel_Date2Title;
        private Infragistics.Win.Misc.UltraLabel uLabel_Date1Title;
        private Infragistics.Win.Misc.UltraLabel ultraLabel15;
        private Infragistics.Win.Misc.UltraLabel ultraLabel16;
        private Broadleaf.Library.Windows.Forms.TDateEdit tDateEdit_Date2End;
        private Broadleaf.Library.Windows.Forms.TDateEdit tDateEdit_Date1End;
		private Broadleaf.Library.Windows.Forms.TDateEdit tDateEdit_Date1Start;
		private Infragistics.Win.Misc.UltraButton uButton_StockCustomerGuide;
		private Infragistics.Win.Misc.UltraLabel uLabel_CustomerName;
		private Broadleaf.Library.Windows.Forms.TNedit tNedit_SupplierCd;
        private Infragistics.Win.Misc.UltraLabel uLabel_CustomerCodeTitle;
        private Infragistics.Win.Misc.UltraButton uButton_EmployeeGuide;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_PartySaleSlipNum;
        private Infragistics.Win.Misc.UltraLabel uLabel_StockAgentName;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_StockAgentCode;
        private Infragistics.Win.Misc.UltraLabel uLabel_PartySaleSlipNumTitle;
        private Infragistics.Win.Misc.UltraLabel uLabel_StockAgentCodeTitle;
        private Infragistics.Win.Misc.UltraLabel uLabel_SectionNm;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SectionCd;
        private Infragistics.Win.Misc.UltraButton uButton_SectionGuide;
        private Infragistics.Win.Misc.UltraLabel uLabel_SectionTitle;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea3;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea4;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panel_SelectReflection_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panel_SelectReflection_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea2;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panel_SelectReflection_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea7;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea8;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea6;
        private Broadleaf.Library.Windows.Forms.TDateEdit tDateEdit_Date2Start;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea5;
        private Broadleaf.Library.Windows.Forms.TToolbarsManager tToolbarsManager_MainMenu;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea9;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Form1_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea1;
        private System.Windows.Forms.ToolTip toolTip1;
		private Broadleaf.Library.Windows.Forms.TEdit tEdit_SupplierSlipNoStart;
        private Infragistics.Win.Misc.UltraLabel uLabel_SupplierSlipNoTitle;
		private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_SupplierSlipCd;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_SupplierFormal;
        private Infragistics.Win.Misc.UltraLabel uLabel_SupplierSlipCdTitle;
        private Infragistics.Win.Misc.UltraLabel uLabel_SupplierFormalTitle;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel uLabel_PayeeCodeTitle;
        private Infragistics.Win.Misc.UltraButton uButton_PayeeCodeGuide;
        private Infragistics.Win.Misc.UltraLabel uLabel_PayeeName;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_PayeeCode;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SupplierSlipNoEnd;
        private Infragistics.Win.Misc.UltraButton uButton_SubSectionGuide;
        private Infragistics.Win.Misc.UltraLabel uLabel_SubSectionName;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_SubSectionCode;
        private Infragistics.Win.Misc.UltraLabel uLabel_SubSection;

	}
}


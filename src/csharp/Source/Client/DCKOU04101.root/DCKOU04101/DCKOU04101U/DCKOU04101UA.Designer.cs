namespace Broadleaf.Windows.Forms
{
	partial class DCKOU04101UA
	{
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

        // ADD 2009/12/04 MANTIS対応[14745]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
        /// <summary>処分済みフラグ</summary>
        private bool _disposed;
        // ADD 2009/12/04 MANTIS対応[14745]：伝票および明細グリッド列の列設定の変更 ----------<<<<<

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
                // ADD 2009/12/04 MANTIS対応[14745]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
                DCKOU04101UA_FormClosing(this, null);
                // ADD 2009/12/04 MANTIS対応[14745]：伝票および明細グリッド列の列設定の変更 ----------<<<<<

				components.Dispose();
			}
			base.Dispose(disposing);

            // ADD 2009/12/04 MANTIS対応[14745]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
            _disposed = true;
            // ADD 2009/12/04 MANTIS対応[14745]：伝票および明細グリッド列の列設定の変更 ----------<<<<<
		}

		#region Windows フォーム デザイナで生成されたコード

		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance267 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance265 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance266 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance270 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance271 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance272 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance273 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance274 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance275 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance276 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance277 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance279 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance280 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance281 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance301 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance302 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance304 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance305 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance306 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance307 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance308 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance309 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance282 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance283 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance284 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance285 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance286 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance287 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance291 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance292 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance293 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance294 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance295 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance296 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance297 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance300 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance303 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance311 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance312 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance313 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance315 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance316 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance317 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance318 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance320 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance321 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance322 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance323 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance329 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance328 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel5 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel6 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel7 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel8 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel9 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel10 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance330 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel11 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel12 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel13 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCKOU04101UA));
            this.uCheckEditor_AutoFillToColumn = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.tComboEditor_GridFontSize = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Form1_Fill_Panel = new System.Windows.Forms.Panel();
            this.panel_Detail = new System.Windows.Forms.Panel();
            this.Detail_UGroupBox = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.DetailCondtnUGroupBoxPanel = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_GoodsName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_GoodsMakerGuide = new Infragistics.Win.Misc.UltraButton();
            this.uLabel_GoodsCodeTitle = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_MakerName = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_GoodsMakerCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_GoodsNo = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Standard_UGroupBox = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.ultraExpandableGroupBoxPanel1 = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.uButton_SubSectionGuide = new Infragistics.Win.Misc.UltraButton();
            this.uLabel_SubSectionName = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_SubSectionCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uLabel_SubSection = new Infragistics.Win.Misc.UltraLabel();
            this.tDateEdit_Date1Start = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.tDateEdit_Date1End = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.tNedit_SupplierSlipNo_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_SupplierSlipNo_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uLabel_Date1Title = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_PartySalesSlipNum = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_InputDayTitle = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.tDateEdit_InputDayEd = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.tDateEdit_InputDaySt = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_SupplierSlipCd = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tComboEditor_ReconcileFlag = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.uButton_PayeeGuide = new Infragistics.Win.Misc.UltraButton();
            this.uLabel_PayeeSnm = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_PayeeCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_SupplierFormal = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_SupplierFormalTitle = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_WarehouseGuide = new Infragistics.Win.Misc.UltraButton();
            this.uButton_SupplierGuide = new Infragistics.Win.Misc.UltraButton();
            this.uLabel_SectionNm = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_SectionTitle = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_WarehouseName = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_SectionGuide = new Infragistics.Win.Misc.UltraButton();
            this.uLabel_SupplierSnm = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SectionCodeAllowZero = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_WarehouseCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tNedit_SupplierCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uLabel_WarehouseCodeTitle = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_CustomerCodeTitle = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_EmployeeGuide = new Infragistics.Win.Misc.UltraButton();
            this.uLabel_StockAgentName = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_StockAgentCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uLabel_StockAgentCode = new Infragistics.Win.Misc.UltraLabel();
            this._Form1_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.tToolbarsManager_MainMenu = new Broadleaf.Library.Windows.Forms.TToolbarsManager(this.components);
            this._Form1_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Form1_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.uStatusBar_Main = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.Detail_UGroupBox)).BeginInit();
            this.Detail_UGroupBox.SuspendLayout();
            this.DetailCondtnUGroupBoxPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Standard_UGroupBox)).BeginInit();
            this.Standard_UGroupBox.SuspendLayout();
            this.ultraExpandableGroupBoxPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SubSectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierSlipNo_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierSlipNo_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_PartySalesSlipNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SupplierSlipCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_ReconcileFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_PayeeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SupplierFormal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_WarehouseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_StockAgentCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tToolbarsManager_MainMenu)).BeginInit();
            this.uStatusBar_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // uCheckEditor_AutoFillToColumn
            // 
            appearance267.FontData.SizeInPoints = 9F;
            this.uCheckEditor_AutoFillToColumn.Appearance = appearance267;
            this.uCheckEditor_AutoFillToColumn.BackColor = System.Drawing.Color.Transparent;
            this.uCheckEditor_AutoFillToColumn.BackColorInternal = System.Drawing.Color.Transparent;
            this.uCheckEditor_AutoFillToColumn.Location = new System.Drawing.Point(3, 4);
            this.uCheckEditor_AutoFillToColumn.Name = "uCheckEditor_AutoFillToColumn";
            this.uCheckEditor_AutoFillToColumn.Size = new System.Drawing.Size(138, 16);
            this.uCheckEditor_AutoFillToColumn.TabIndex = 18;
            this.uCheckEditor_AutoFillToColumn.Text = "列サイズの自動調整";
            this.uCheckEditor_AutoFillToColumn.CheckedChanged += new System.EventHandler(this.uCheckEditor_AutoFillToColumn_CheckedChanged);
            // 
            // tComboEditor_GridFontSize
            // 
            appearance265.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_GridFontSize.ActiveAppearance = appearance265;
            this.tComboEditor_GridFontSize.AutoSize = false;
            this.tComboEditor_GridFontSize.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_GridFontSize.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance266.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_GridFontSize.ItemAppearance = appearance266;
            valueListItem1.DataValue = 10;
            valueListItem1.DisplayText = "10";
            valueListItem2.DataValue = 11;
            valueListItem2.DisplayText = "11";
            this.tComboEditor_GridFontSize.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.tComboEditor_GridFontSize.Location = new System.Drawing.Point(3, 4);
            this.tComboEditor_GridFontSize.Name = "tComboEditor_GridFontSize";
            this.tComboEditor_GridFontSize.Size = new System.Drawing.Size(38, 16);
            this.tComboEditor_GridFontSize.TabIndex = 18;
            this.tComboEditor_GridFontSize.ValueChanged += new System.EventHandler(this.tComboEditor_GridFontSize_ValueChanged);
            // 
            // Form1_Fill_Panel
            // 
            this.Form1_Fill_Panel.Controls.Add(this.panel_Detail);
            this.Form1_Fill_Panel.Controls.Add(this.Detail_UGroupBox);
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
            this.panel_Detail.Location = new System.Drawing.Point(0, 269);
            this.panel_Detail.Margin = new System.Windows.Forms.Padding(4);
            this.panel_Detail.Name = "panel_Detail";
            this.panel_Detail.Size = new System.Drawing.Size(942, 351);
            this.panel_Detail.TabIndex = 300;
            // 
            // Detail_UGroupBox
            // 
            this.Detail_UGroupBox.Controls.Add(this.DetailCondtnUGroupBoxPanel);
            this.Detail_UGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.Detail_UGroupBox.ExpandedSize = new System.Drawing.Size(942, 81);
            this.Detail_UGroupBox.Location = new System.Drawing.Point(0, 188);
            this.Detail_UGroupBox.Name = "Detail_UGroupBox";
            this.Detail_UGroupBox.Size = new System.Drawing.Size(942, 81);
            this.Detail_UGroupBox.TabIndex = 1;
            this.Detail_UGroupBox.TabStop = false;
            this.Detail_UGroupBox.Text = "詳細条件";
            // 
            // DetailCondtnUGroupBoxPanel
            // 
            this.DetailCondtnUGroupBoxPanel.Controls.Add(this.ultraLabel7);
            this.DetailCondtnUGroupBoxPanel.Controls.Add(this.tEdit_GoodsName);
            this.DetailCondtnUGroupBoxPanel.Controls.Add(this.uButton_GoodsMakerGuide);
            this.DetailCondtnUGroupBoxPanel.Controls.Add(this.uLabel_GoodsCodeTitle);
            this.DetailCondtnUGroupBoxPanel.Controls.Add(this.uLabel_MakerName);
            this.DetailCondtnUGroupBoxPanel.Controls.Add(this.tNedit_GoodsMakerCd);
            this.DetailCondtnUGroupBoxPanel.Controls.Add(this.ultraLabel6);
            this.DetailCondtnUGroupBoxPanel.Controls.Add(this.tEdit_GoodsNo);
            this.DetailCondtnUGroupBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailCondtnUGroupBoxPanel.Location = new System.Drawing.Point(3, 19);
            this.DetailCondtnUGroupBoxPanel.Name = "DetailCondtnUGroupBoxPanel";
            this.DetailCondtnUGroupBoxPanel.Size = new System.Drawing.Size(936, 59);
            this.DetailCondtnUGroupBoxPanel.TabIndex = 0;
            // 
            // ultraLabel7
            // 
            appearance270.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance270;
            this.ultraLabel7.Location = new System.Drawing.Point(435, 3);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(85, 23);
            this.ultraLabel7.TabIndex = 201;
            this.ultraLabel7.Text = "品名*";
            // 
            // tEdit_GoodsName
            // 
            appearance271.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_GoodsName.ActiveAppearance = appearance271;
            appearance272.TextHAlignAsString = "Left";
            this.tEdit_GoodsName.Appearance = appearance272;
            this.tEdit_GoodsName.AutoSelect = true;
            this.tEdit_GoodsName.DataText = "";
            this.tEdit_GoodsName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_GoodsName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 40, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_GoodsName.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_GoodsName.Location = new System.Drawing.Point(526, 3);
            this.tEdit_GoodsName.MaxLength = 40;
            this.tEdit_GoodsName.Name = "tEdit_GoodsName";
            this.tEdit_GoodsName.Size = new System.Drawing.Size(330, 24);
            this.tEdit_GoodsName.TabIndex = 3;
            // 
            // uButton_GoodsMakerGuide
            // 
            appearance273.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance273.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_GoodsMakerGuide.Appearance = appearance273;
            this.uButton_GoodsMakerGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_GoodsMakerGuide.Location = new System.Drawing.Point(331, 2);
            this.uButton_GoodsMakerGuide.Name = "uButton_GoodsMakerGuide";
            this.uButton_GoodsMakerGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_GoodsMakerGuide.TabIndex = 1;
            this.toolTip1.SetToolTip(this.uButton_GoodsMakerGuide, "メーカーガイド");
            this.uButton_GoodsMakerGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_GoodsMakerGuide.Click += new System.EventHandler(this.uButton_GoodsMakerGuide_Click);
            // 
            // uLabel_GoodsCodeTitle
            // 
            appearance274.TextVAlignAsString = "Middle";
            this.uLabel_GoodsCodeTitle.Appearance = appearance274;
            this.uLabel_GoodsCodeTitle.Location = new System.Drawing.Point(8, 32);
            this.uLabel_GoodsCodeTitle.Name = "uLabel_GoodsCodeTitle";
            this.uLabel_GoodsCodeTitle.Size = new System.Drawing.Size(52, 23);
            this.uLabel_GoodsCodeTitle.TabIndex = 81;
            this.uLabel_GoodsCodeTitle.Text = "品番*";
            // 
            // uLabel_MakerName
            // 
            appearance275.BackColor = System.Drawing.Color.Gainsboro;
            appearance275.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance275.TextHAlignAsString = "Left";
            appearance275.TextVAlignAsString = "Middle";
            this.uLabel_MakerName.Appearance = appearance275;
            this.uLabel_MakerName.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_MakerName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_MakerName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_MakerName.Location = new System.Drawing.Point(131, 2);
            this.uLabel_MakerName.Name = "uLabel_MakerName";
            this.uLabel_MakerName.Size = new System.Drawing.Size(199, 24);
            this.uLabel_MakerName.TabIndex = 1327;
            this.uLabel_MakerName.WrapText = false;
            // 
            // tNedit_GoodsMakerCd
            // 
            appearance276.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_GoodsMakerCd.ActiveAppearance = appearance276;
            appearance277.TextHAlignAsString = "Right";
            this.tNedit_GoodsMakerCd.Appearance = appearance277;
            this.tNedit_GoodsMakerCd.AutoSelect = true;
            this.tNedit_GoodsMakerCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_GoodsMakerCd.DataText = "";
            this.tNedit_GoodsMakerCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_GoodsMakerCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_GoodsMakerCd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_GoodsMakerCd.Location = new System.Drawing.Point(85, 2);
            this.tNedit_GoodsMakerCd.MaxLength = 4;
            this.tNedit_GoodsMakerCd.Name = "tNedit_GoodsMakerCd";
            this.tNedit_GoodsMakerCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_GoodsMakerCd.Size = new System.Drawing.Size(43, 24);
            this.tNedit_GoodsMakerCd.TabIndex = 0;
            // 
            // ultraLabel6
            // 
            appearance279.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance279;
            this.ultraLabel6.Location = new System.Drawing.Point(8, 3);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(68, 23);
            this.ultraLabel6.TabIndex = 1326;
            this.ultraLabel6.Text = "メーカー";
            // 
            // tEdit_GoodsNo
            // 
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_GoodsNo.ActiveAppearance = appearance19;
            appearance20.TextHAlignAsString = "Left";
            this.tEdit_GoodsNo.Appearance = appearance20;
            this.tEdit_GoodsNo.AutoSelect = true;
            this.tEdit_GoodsNo.DataText = "";
            this.tEdit_GoodsNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_GoodsNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
            this.tEdit_GoodsNo.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_GoodsNo.Location = new System.Drawing.Point(85, 31);
            this.tEdit_GoodsNo.MaxLength = 24;
            this.tEdit_GoodsNo.Name = "tEdit_GoodsNo";
            this.tEdit_GoodsNo.Size = new System.Drawing.Size(198, 24);
            this.tEdit_GoodsNo.TabIndex = 2;
            // 
            // Standard_UGroupBox
            // 
            this.Standard_UGroupBox.Controls.Add(this.ultraExpandableGroupBoxPanel1);
            this.Standard_UGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.Standard_UGroupBox.ExpandedSize = new System.Drawing.Size(942, 188);
            this.Standard_UGroupBox.Location = new System.Drawing.Point(0, 0);
            this.Standard_UGroupBox.Name = "Standard_UGroupBox";
            this.Standard_UGroupBox.Size = new System.Drawing.Size(942, 188);
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
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tDateEdit_Date1Start);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tDateEdit_Date1End);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tNedit_SupplierSlipNo_Ed);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.ultraLabel15);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tNedit_SupplierSlipNo_St);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_Date1Title);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.ultraLabel9);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_PartySalesSlipNum);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.ultraLabel4);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_InputDayTitle);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.ultraLabel8);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tDateEdit_InputDayEd);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tDateEdit_InputDaySt);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.ultraLabel5);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.ultraLabel2);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tComboEditor_SupplierSlipCd);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tComboEditor_ReconcileFlag);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uButton_PayeeGuide);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_PayeeSnm);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tNedit_PayeeCode);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.ultraLabel3);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tComboEditor_SupplierFormal);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.ultraLabel1);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_SupplierFormalTitle);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uButton_WarehouseGuide);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uButton_SupplierGuide);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_SectionNm);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_SectionTitle);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_WarehouseName);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uButton_SectionGuide);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_SupplierSnm);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_SectionCodeAllowZero);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_WarehouseCode);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tNedit_SupplierCd);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_WarehouseCodeTitle);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_CustomerCodeTitle);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uButton_EmployeeGuide);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_StockAgentName);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tEdit_StockAgentCode);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.uLabel_StockAgentCode);
            this.ultraExpandableGroupBoxPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraExpandableGroupBoxPanel1.Location = new System.Drawing.Point(3, 19);
            this.ultraExpandableGroupBoxPanel1.Name = "ultraExpandableGroupBoxPanel1";
            this.ultraExpandableGroupBoxPanel1.Size = new System.Drawing.Size(936, 166);
            this.ultraExpandableGroupBoxPanel1.TabIndex = 0;
            // 
            // uButton_SubSectionGuide
            // 
            appearance53.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance53.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_SubSectionGuide.Appearance = appearance53;
            this.uButton_SubSectionGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_SubSectionGuide.Location = new System.Drawing.Point(289, 29);
            this.uButton_SubSectionGuide.Name = "uButton_SubSectionGuide";
            this.uButton_SubSectionGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SubSectionGuide.TabIndex = 1339;
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
            this.uLabel_SubSectionName.Location = new System.Drawing.Point(116, 29);
            this.uLabel_SubSectionName.Name = "uLabel_SubSectionName";
            this.uLabel_SubSectionName.Size = new System.Drawing.Size(171, 24);
            this.uLabel_SubSectionName.TabIndex = 1341;
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
            this.tNedit_SubSectionCode.Location = new System.Drawing.Point(85, 29);
            this.tNedit_SubSectionCode.MaxLength = 6;
            this.tNedit_SubSectionCode.Name = "tNedit_SubSectionCode";
            this.tNedit_SubSectionCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_SubSectionCode.Size = new System.Drawing.Size(28, 24);
            this.tNedit_SubSectionCode.TabIndex = 1338;
            // 
            // uLabel_SubSection
            // 
            appearance52.TextVAlignAsString = "Middle";
            this.uLabel_SubSection.Appearance = appearance52;
            this.uLabel_SubSection.Location = new System.Drawing.Point(8, 30);
            this.uLabel_SubSection.Name = "uLabel_SubSection";
            this.uLabel_SubSection.Size = new System.Drawing.Size(36, 23);
            this.uLabel_SubSection.TabIndex = 1340;
            this.uLabel_SubSection.Text = "部門";
            // 
            // tDateEdit_Date1Start
            // 
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tDateEdit_Date1Start.ActiveEditAppearance = appearance6;
            this.tDateEdit_Date1Start.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit_Date1Start.CalendarDisp = true;
            appearance7.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance7.ForeColorDisabled = System.Drawing.Color.Black;
            appearance7.TextHAlignAsString = "Left";
            appearance7.TextVAlignAsString = "Middle";
            this.tDateEdit_Date1Start.EditAppearance = appearance7;
            this.tDateEdit_Date1Start.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit_Date1Start.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance8.TextHAlignAsString = "Left";
            appearance8.TextVAlignAsString = "Bottom";
            this.tDateEdit_Date1Start.LabelAppearance = appearance8;
            this.tDateEdit_Date1Start.Location = new System.Drawing.Point(526, 4);
            this.tDateEdit_Date1Start.Name = "tDateEdit_Date1Start";
            this.tDateEdit_Date1Start.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit_Date1Start.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.tDateEdit_Date1Start.Size = new System.Drawing.Size(176, 24);
            this.tDateEdit_Date1Start.TabIndex = 9;
            this.tDateEdit_Date1Start.TabStop = true;
            // 
            // tDateEdit_Date1End
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tDateEdit_Date1End.ActiveEditAppearance = appearance3;
            this.tDateEdit_Date1End.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit_Date1End.CalendarDisp = true;
            appearance4.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Middle";
            this.tDateEdit_Date1End.EditAppearance = appearance4;
            this.tDateEdit_Date1End.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit_Date1End.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance5.TextHAlignAsString = "Left";
            appearance5.TextVAlignAsString = "Bottom";
            this.tDateEdit_Date1End.LabelAppearance = appearance5;
            this.tDateEdit_Date1End.Location = new System.Drawing.Point(728, 4);
            this.tDateEdit_Date1End.Name = "tDateEdit_Date1End";
            this.tDateEdit_Date1End.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit_Date1End.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.tDateEdit_Date1End.Size = new System.Drawing.Size(176, 24);
            this.tDateEdit_Date1End.TabIndex = 10;
            this.tDateEdit_Date1End.TabStop = true;
            // 
            // tNedit_SupplierSlipNo_Ed
            // 
            appearance26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_SupplierSlipNo_Ed.ActiveAppearance = appearance26;
            appearance28.TextHAlignAsString = "Left";
            this.tNedit_SupplierSlipNo_Ed.Appearance = appearance28;
            this.tNedit_SupplierSlipNo_Ed.AutoSelect = true;
            this.tNedit_SupplierSlipNo_Ed.AutoSize = false;
            this.tNedit_SupplierSlipNo_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierSlipNo_Ed.DataText = "";
            this.tNedit_SupplierSlipNo_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierSlipNo_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_SupplierSlipNo_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SupplierSlipNo_Ed.Location = new System.Drawing.Point(640, 55);
            this.tNedit_SupplierSlipNo_Ed.MaxLength = 12;
            this.tNedit_SupplierSlipNo_Ed.Name = "tNedit_SupplierSlipNo_Ed";
            this.tNedit_SupplierSlipNo_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_SupplierSlipNo_Ed.Size = new System.Drawing.Size(82, 24);
            this.tNedit_SupplierSlipNo_Ed.TabIndex = 14;
            // 
            // ultraLabel15
            // 
            appearance18.TextVAlignAsString = "Middle";
            this.ultraLabel15.Appearance = appearance18;
            this.ultraLabel15.Location = new System.Drawing.Point(705, 4);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel15.TabIndex = 1310;
            this.ultraLabel15.Text = "～";
            // 
            // tNedit_SupplierSlipNo_St
            // 
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_SupplierSlipNo_St.ActiveAppearance = appearance25;
            appearance27.TextHAlignAsString = "Left";
            this.tNedit_SupplierSlipNo_St.Appearance = appearance27;
            this.tNedit_SupplierSlipNo_St.AutoSelect = true;
            this.tNedit_SupplierSlipNo_St.AutoSize = false;
            this.tNedit_SupplierSlipNo_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierSlipNo_St.DataText = "";
            this.tNedit_SupplierSlipNo_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierSlipNo_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_SupplierSlipNo_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SupplierSlipNo_St.Location = new System.Drawing.Point(526, 55);
            this.tNedit_SupplierSlipNo_St.MaxLength = 12;
            this.tNedit_SupplierSlipNo_St.Name = "tNedit_SupplierSlipNo_St";
            this.tNedit_SupplierSlipNo_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_SupplierSlipNo_St.Size = new System.Drawing.Size(82, 24);
            this.tNedit_SupplierSlipNo_St.TabIndex = 13;
            // 
            // uLabel_Date1Title
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.uLabel_Date1Title.Appearance = appearance1;
            this.uLabel_Date1Title.BackColorInternal = System.Drawing.Color.Transparent;
            this.uLabel_Date1Title.Location = new System.Drawing.Point(435, 5);
            this.uLabel_Date1Title.Name = "uLabel_Date1Title";
            this.uLabel_Date1Title.Size = new System.Drawing.Size(52, 23);
            this.uLabel_Date1Title.TabIndex = 1308;
            this.uLabel_Date1Title.Text = "仕入日";
            // 
            // ultraLabel9
            // 
            appearance15.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance15;
            this.ultraLabel9.Location = new System.Drawing.Point(435, 82);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(85, 23);
            this.ultraLabel9.TabIndex = 1337;
            this.ultraLabel9.Text = "伝票番号*";
            // 
            // tEdit_PartySalesSlipNum
            // 
            appearance280.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_PartySalesSlipNum.ActiveAppearance = appearance280;
            appearance281.TextHAlignAsString = "Left";
            this.tEdit_PartySalesSlipNum.Appearance = appearance281;
            this.tEdit_PartySalesSlipNum.AutoSelect = true;
            this.tEdit_PartySalesSlipNum.DataText = "";
            this.tEdit_PartySalesSlipNum.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_PartySalesSlipNum.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 40, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
            this.tEdit_PartySalesSlipNum.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_PartySalesSlipNum.Location = new System.Drawing.Point(526, 81);
            this.tEdit_PartySalesSlipNum.MaxLength = 40;
            this.tEdit_PartySalesSlipNum.Name = "tEdit_PartySalesSlipNum";
            this.tEdit_PartySalesSlipNum.Size = new System.Drawing.Size(159, 24);
            this.tEdit_PartySalesSlipNum.TabIndex = 15;
            // 
            // ultraLabel4
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance2;
            this.ultraLabel4.Location = new System.Drawing.Point(615, 56);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel4.TabIndex = 1336;
            this.ultraLabel4.Text = "～";
            // 
            // uLabel_InputDayTitle
            // 
            appearance301.TextVAlignAsString = "Middle";
            this.uLabel_InputDayTitle.Appearance = appearance301;
            this.uLabel_InputDayTitle.BackColorInternal = System.Drawing.Color.Transparent;
            this.uLabel_InputDayTitle.Location = new System.Drawing.Point(435, 30);
            this.uLabel_InputDayTitle.Name = "uLabel_InputDayTitle";
            this.uLabel_InputDayTitle.Size = new System.Drawing.Size(52, 23);
            this.uLabel_InputDayTitle.TabIndex = 1334;
            this.uLabel_InputDayTitle.Text = "入力日";
            // 
            // ultraLabel8
            // 
            appearance302.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance302;
            this.ultraLabel8.Location = new System.Drawing.Point(705, 30);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel8.TabIndex = 1333;
            this.ultraLabel8.Text = "～";
            // 
            // tDateEdit_InputDayEd
            // 
            appearance304.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tDateEdit_InputDayEd.ActiveEditAppearance = appearance304;
            this.tDateEdit_InputDayEd.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit_InputDayEd.CalendarDisp = true;
            appearance305.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance305.ForeColorDisabled = System.Drawing.Color.Black;
            appearance305.TextHAlignAsString = "Left";
            appearance305.TextVAlignAsString = "Middle";
            this.tDateEdit_InputDayEd.EditAppearance = appearance305;
            this.tDateEdit_InputDayEd.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit_InputDayEd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance306.TextHAlignAsString = "Left";
            appearance306.TextVAlignAsString = "Bottom";
            this.tDateEdit_InputDayEd.LabelAppearance = appearance306;
            this.tDateEdit_InputDayEd.Location = new System.Drawing.Point(728, 29);
            this.tDateEdit_InputDayEd.Name = "tDateEdit_InputDayEd";
            this.tDateEdit_InputDayEd.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit_InputDayEd.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.tDateEdit_InputDayEd.Size = new System.Drawing.Size(176, 24);
            this.tDateEdit_InputDayEd.TabIndex = 12;
            this.tDateEdit_InputDayEd.TabStop = true;
            // 
            // tDateEdit_InputDaySt
            // 
            appearance307.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tDateEdit_InputDaySt.ActiveEditAppearance = appearance307;
            this.tDateEdit_InputDaySt.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit_InputDaySt.CalendarDisp = true;
            appearance308.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance308.ForeColorDisabled = System.Drawing.Color.Black;
            appearance308.TextHAlignAsString = "Left";
            appearance308.TextVAlignAsString = "Middle";
            this.tDateEdit_InputDaySt.EditAppearance = appearance308;
            this.tDateEdit_InputDaySt.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit_InputDaySt.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance309.TextHAlignAsString = "Left";
            appearance309.TextVAlignAsString = "Bottom";
            this.tDateEdit_InputDaySt.LabelAppearance = appearance309;
            this.tDateEdit_InputDaySt.Location = new System.Drawing.Point(526, 29);
            this.tDateEdit_InputDaySt.Name = "tDateEdit_InputDaySt";
            this.tDateEdit_InputDaySt.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit_InputDaySt.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.tDateEdit_InputDaySt.Size = new System.Drawing.Size(176, 24);
            this.tDateEdit_InputDaySt.TabIndex = 11;
            this.tDateEdit_InputDaySt.TabStop = true;
            // 
            // ultraLabel5
            // 
            appearance282.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance282;
            this.ultraLabel5.Location = new System.Drawing.Point(8, 134);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(68, 23);
            this.ultraLabel5.TabIndex = 1331;
            this.ultraLabel5.Text = "入荷状況";
            // 
            // ultraLabel2
            // 
            appearance283.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance283;
            this.ultraLabel2.Location = new System.Drawing.Point(207, 109);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(68, 23);
            this.ultraLabel2.TabIndex = 1329;
            this.ultraLabel2.Text = "伝票区分";
            // 
            // tComboEditor_SupplierSlipCd
            // 
            appearance284.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SupplierSlipCd.ActiveAppearance = appearance284;
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_SupplierSlipCd.Appearance = appearance24;
            this.tComboEditor_SupplierSlipCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_SupplierSlipCd.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance285.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SupplierSlipCd.ItemAppearance = appearance285;
            valueListItem3.DataValue = -1;
            valueListItem3.DisplayText = "全て";
            valueListItem3.Tag = 0;
            valueListItem4.DataValue = 0;
            valueListItem4.DisplayText = "仕入";
            valueListItem4.Tag = 1;
            valueListItem5.DataValue = 1;
            valueListItem5.DisplayText = "返品";
            valueListItem5.Tag = 2;
            this.tComboEditor_SupplierSlipCd.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem4,
            valueListItem5});
            this.tComboEditor_SupplierSlipCd.Location = new System.Drawing.Point(281, 107);
            this.tComboEditor_SupplierSlipCd.Name = "tComboEditor_SupplierSlipCd";
            this.tComboEditor_SupplierSlipCd.Size = new System.Drawing.Size(116, 24);
            this.tComboEditor_SupplierSlipCd.TabIndex = 7;
            // 
            // tComboEditor_ReconcileFlag
            // 
            appearance286.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_ReconcileFlag.ActiveAppearance = appearance286;
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_ReconcileFlag.Appearance = appearance23;
            this.tComboEditor_ReconcileFlag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_ReconcileFlag.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance287.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_ReconcileFlag.ItemAppearance = appearance287;
            valueListItem6.DataValue = -1;
            valueListItem6.DisplayText = "全て";
            valueListItem6.Tag = 1;
            valueListItem7.DataValue = 1;
            valueListItem7.DisplayText = "計上済み分";
            valueListItem7.Tag = 2;
            valueListItem8.DataValue = 0;
            valueListItem8.DisplayText = "未計上分";
            valueListItem8.Tag = 3;
            this.tComboEditor_ReconcileFlag.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem6,
            valueListItem7,
            valueListItem8});
            this.tComboEditor_ReconcileFlag.Location = new System.Drawing.Point(85, 133);
            this.tComboEditor_ReconcileFlag.Name = "tComboEditor_ReconcileFlag";
            this.tComboEditor_ReconcileFlag.Size = new System.Drawing.Size(116, 24);
            this.tComboEditor_ReconcileFlag.TabIndex = 8;
            // 
            // uButton_PayeeGuide
            // 
            appearance291.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance291.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_PayeeGuide.Appearance = appearance291;
            this.uButton_PayeeGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_PayeeGuide.Location = new System.Drawing.Point(347, 81);
            this.uButton_PayeeGuide.Name = "uButton_PayeeGuide";
            this.uButton_PayeeGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_PayeeGuide.TabIndex = 5;
            this.toolTip1.SetToolTip(this.uButton_PayeeGuide, "得意先検索");
            this.uButton_PayeeGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_PayeeGuide.Click += new System.EventHandler(this.uButton_PayeeGuide_Click);
            // 
            // uLabel_PayeeSnm
            // 
            appearance292.BackColor = System.Drawing.Color.Gainsboro;
            appearance292.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance292.TextHAlignAsString = "Left";
            appearance292.TextVAlignAsString = "Middle";
            this.uLabel_PayeeSnm.Appearance = appearance292;
            this.uLabel_PayeeSnm.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_PayeeSnm.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_PayeeSnm.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_PayeeSnm.Location = new System.Drawing.Point(147, 81);
            this.uLabel_PayeeSnm.Name = "uLabel_PayeeSnm";
            this.uLabel_PayeeSnm.Size = new System.Drawing.Size(199, 24);
            this.uLabel_PayeeSnm.TabIndex = 1321;
            this.uLabel_PayeeSnm.WrapText = false;
            // 
            // tNedit_PayeeCode
            // 
            appearance293.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_PayeeCode.ActiveAppearance = appearance293;
            appearance294.TextHAlignAsString = "Right";
            this.tNedit_PayeeCode.Appearance = appearance294;
            this.tNedit_PayeeCode.AutoSelect = true;
            this.tNedit_PayeeCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_PayeeCode.DataText = "";
            this.tNedit_PayeeCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_PayeeCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_PayeeCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_PayeeCode.Location = new System.Drawing.Point(85, 81);
            this.tNedit_PayeeCode.MaxLength = 6;
            this.tNedit_PayeeCode.Name = "tNedit_PayeeCode";
            this.tNedit_PayeeCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_PayeeCode.Size = new System.Drawing.Size(59, 24);
            this.tNedit_PayeeCode.TabIndex = 4;
            // 
            // ultraLabel3
            // 
            appearance295.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance295;
            this.ultraLabel3.Location = new System.Drawing.Point(8, 82);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(52, 23);
            this.ultraLabel3.TabIndex = 1320;
            this.ultraLabel3.Text = "支払先";
            // 
            // tComboEditor_SupplierFormal
            // 
            appearance296.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SupplierFormal.ActiveAppearance = appearance296;
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_SupplierFormal.Appearance = appearance22;
            this.tComboEditor_SupplierFormal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_SupplierFormal.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance297.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SupplierFormal.ItemAppearance = appearance297;
            valueListItem9.DataValue = 0;
            valueListItem9.DisplayText = "仕入";
            valueListItem9.Tag = 1;
            valueListItem10.DataValue = 1;
            valueListItem10.DisplayText = "入荷";
            valueListItem10.Tag = 2;
            valueListItem11.DataValue = -1;
            valueListItem11.DisplayText = "全て";
            valueListItem11.Tag = 3;
            this.tComboEditor_SupplierFormal.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem9,
            valueListItem10,
            valueListItem11});
            this.tComboEditor_SupplierFormal.Location = new System.Drawing.Point(85, 107);
            this.tComboEditor_SupplierFormal.Name = "tComboEditor_SupplierFormal";
            this.tComboEditor_SupplierFormal.Size = new System.Drawing.Size(116, 24);
            this.tComboEditor_SupplierFormal.TabIndex = 6;
            this.tComboEditor_SupplierFormal.ValueChanged += new System.EventHandler(this.tComboEditor_SupplierFormal_ValueChanged);
            // 
            // ultraLabel1
            // 
            appearance300.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance300;
            this.ultraLabel1.Location = new System.Drawing.Point(435, 56);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(97, 23);
            this.ultraLabel1.TabIndex = 1313;
            this.ultraLabel1.Text = "仕入SEQ番号";
            // 
            // uLabel_SupplierFormalTitle
            // 
            appearance303.TextVAlignAsString = "Middle";
            this.uLabel_SupplierFormalTitle.Appearance = appearance303;
            this.uLabel_SupplierFormalTitle.Location = new System.Drawing.Point(7, 108);
            this.uLabel_SupplierFormalTitle.Name = "uLabel_SupplierFormalTitle";
            this.uLabel_SupplierFormalTitle.Size = new System.Drawing.Size(72, 23);
            this.uLabel_SupplierFormalTitle.TabIndex = 1317;
            this.uLabel_SupplierFormalTitle.Text = "伝票種別";
            // 
            // uButton_WarehouseGuide
            // 
            appearance9.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance9.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_WarehouseGuide.Appearance = appearance9;
            this.uButton_WarehouseGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_WarehouseGuide.Location = new System.Drawing.Point(772, 133);
            this.uButton_WarehouseGuide.Name = "uButton_WarehouseGuide";
            this.uButton_WarehouseGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_WarehouseGuide.TabIndex = 19;
            this.toolTip1.SetToolTip(this.uButton_WarehouseGuide, "倉庫ガイド");
            this.uButton_WarehouseGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_WarehouseGuide.Click += new System.EventHandler(this.uButton_WarehouseGuide_Click);
            // 
            // uButton_SupplierGuide
            // 
            appearance311.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance311.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_SupplierGuide.Appearance = appearance311;
            this.uButton_SupplierGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_SupplierGuide.Location = new System.Drawing.Point(347, 55);
            this.uButton_SupplierGuide.Name = "uButton_SupplierGuide";
            this.uButton_SupplierGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SupplierGuide.TabIndex = 3;
            this.toolTip1.SetToolTip(this.uButton_SupplierGuide, "得意先検索");
            this.uButton_SupplierGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SupplierGuide.Click += new System.EventHandler(this.uButton_SupplierGuide_Click);
            // 
            // uLabel_SectionNm
            // 
            appearance312.BackColor = System.Drawing.Color.Gainsboro;
            appearance312.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance312.TextHAlignAsString = "Left";
            appearance312.TextVAlignAsString = "Middle";
            this.uLabel_SectionNm.Appearance = appearance312;
            this.uLabel_SectionNm.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_SectionNm.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_SectionNm.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_SectionNm.Location = new System.Drawing.Point(116, 3);
            this.uLabel_SectionNm.Name = "uLabel_SectionNm";
            this.uLabel_SectionNm.Size = new System.Drawing.Size(171, 24);
            this.uLabel_SectionNm.TabIndex = 1293;
            this.uLabel_SectionNm.WrapText = false;
            // 
            // uLabel_SectionTitle
            // 
            appearance313.TextVAlignAsString = "Middle";
            this.uLabel_SectionTitle.Appearance = appearance313;
            this.uLabel_SectionTitle.Location = new System.Drawing.Point(8, 4);
            this.uLabel_SectionTitle.Name = "uLabel_SectionTitle";
            this.uLabel_SectionTitle.Size = new System.Drawing.Size(36, 23);
            this.uLabel_SectionTitle.TabIndex = 1292;
            this.uLabel_SectionTitle.Text = "拠点";
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
            this.uLabel_WarehouseName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_WarehouseName.Location = new System.Drawing.Point(573, 133);
            this.uLabel_WarehouseName.Name = "uLabel_WarehouseName";
            this.uLabel_WarehouseName.Size = new System.Drawing.Size(197, 24);
            this.uLabel_WarehouseName.TabIndex = 1307;
            this.uLabel_WarehouseName.WrapText = false;
            // 
            // uButton_SectionGuide
            // 
            appearance315.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance315.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_SectionGuide.Appearance = appearance315;
            this.uButton_SectionGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_SectionGuide.Location = new System.Drawing.Point(289, 3);
            this.uButton_SectionGuide.Name = "uButton_SectionGuide";
            this.uButton_SectionGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SectionGuide.TabIndex = 1;
            this.toolTip1.SetToolTip(this.uButton_SectionGuide, "拠点ガイド");
            this.uButton_SectionGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SectionGuide.Click += new System.EventHandler(this.uButton_SectionGuide_Click);
            // 
            // uLabel_SupplierSnm
            // 
            appearance316.BackColor = System.Drawing.Color.Gainsboro;
            appearance316.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance316.TextHAlignAsString = "Left";
            appearance316.TextVAlignAsString = "Middle";
            this.uLabel_SupplierSnm.Appearance = appearance316;
            this.uLabel_SupplierSnm.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_SupplierSnm.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_SupplierSnm.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_SupplierSnm.Location = new System.Drawing.Point(147, 55);
            this.uLabel_SupplierSnm.Name = "uLabel_SupplierSnm";
            this.uLabel_SupplierSnm.Size = new System.Drawing.Size(199, 24);
            this.uLabel_SupplierSnm.TabIndex = 1306;
            this.uLabel_SupplierSnm.WrapText = false;
            // 
            // tEdit_SectionCodeAllowZero
            // 
            appearance317.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SectionCodeAllowZero.ActiveAppearance = appearance317;
            appearance318.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance318.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_SectionCodeAllowZero.Appearance = appearance318;
            this.tEdit_SectionCodeAllowZero.AutoSelect = true;
            this.tEdit_SectionCodeAllowZero.DataText = "";
            this.tEdit_SectionCodeAllowZero.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCodeAllowZero.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
            this.tEdit_SectionCodeAllowZero.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_SectionCodeAllowZero.Location = new System.Drawing.Point(85, 3);
            this.tEdit_SectionCodeAllowZero.MaxLength = 6;
            this.tEdit_SectionCodeAllowZero.Name = "tEdit_SectionCodeAllowZero";
            this.tEdit_SectionCodeAllowZero.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCodeAllowZero.TabIndex = 0;
            this.tEdit_SectionCodeAllowZero.Enter += new System.EventHandler(this.tEdit_SectionCodeAllowZero_Enter);
            // 
            // tEdit_WarehouseCode
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_WarehouseCode.ActiveAppearance = appearance11;
            this.tEdit_WarehouseCode.AutoSelect = true;
            this.tEdit_WarehouseCode.DataText = "";
            this.tEdit_WarehouseCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_WarehouseCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.tEdit_WarehouseCode.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_WarehouseCode.Location = new System.Drawing.Point(526, 133);
            this.tEdit_WarehouseCode.MaxLength = 4;
            this.tEdit_WarehouseCode.Name = "tEdit_WarehouseCode";
            this.tEdit_WarehouseCode.Size = new System.Drawing.Size(43, 24);
            this.tEdit_WarehouseCode.TabIndex = 18;
            // 
            // tNedit_SupplierCd
            // 
            appearance320.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_SupplierCd.ActiveAppearance = appearance320;
            appearance321.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance321.ForeColorDisabled = System.Drawing.Color.Black;
            appearance321.TextHAlignAsString = "Right";
            this.tNedit_SupplierCd.Appearance = appearance321;
            this.tNedit_SupplierCd.AutoSelect = true;
            this.tNedit_SupplierCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierCd.DataText = "";
            this.tNedit_SupplierCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SupplierCd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SupplierCd.Location = new System.Drawing.Point(85, 55);
            this.tNedit_SupplierCd.MaxLength = 6;
            this.tNedit_SupplierCd.Name = "tNedit_SupplierCd";
            this.tNedit_SupplierCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_SupplierCd.Size = new System.Drawing.Size(59, 24);
            this.tNedit_SupplierCd.TabIndex = 2;
            // 
            // uLabel_WarehouseCodeTitle
            // 
            appearance322.TextVAlignAsString = "Middle";
            this.uLabel_WarehouseCodeTitle.Appearance = appearance322;
            this.uLabel_WarehouseCodeTitle.Location = new System.Drawing.Point(435, 134);
            this.uLabel_WarehouseCodeTitle.Name = "uLabel_WarehouseCodeTitle";
            this.uLabel_WarehouseCodeTitle.Size = new System.Drawing.Size(36, 23);
            this.uLabel_WarehouseCodeTitle.TabIndex = 1304;
            this.uLabel_WarehouseCodeTitle.Text = "倉庫";
            // 
            // uLabel_CustomerCodeTitle
            // 
            appearance323.TextVAlignAsString = "Middle";
            this.uLabel_CustomerCodeTitle.Appearance = appearance323;
            this.uLabel_CustomerCodeTitle.Location = new System.Drawing.Point(8, 56);
            this.uLabel_CustomerCodeTitle.Name = "uLabel_CustomerCodeTitle";
            this.uLabel_CustomerCodeTitle.Size = new System.Drawing.Size(52, 23);
            this.uLabel_CustomerCodeTitle.TabIndex = 1302;
            this.uLabel_CustomerCodeTitle.Text = "仕入先";
            // 
            // uButton_EmployeeGuide
            // 
            appearance12.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance12.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_EmployeeGuide.Appearance = appearance12;
            this.uButton_EmployeeGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_EmployeeGuide.Location = new System.Drawing.Point(772, 107);
            this.uButton_EmployeeGuide.Name = "uButton_EmployeeGuide";
            this.uButton_EmployeeGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_EmployeeGuide.TabIndex = 17;
            this.toolTip1.SetToolTip(this.uButton_EmployeeGuide, "担当者ガイド");
            this.uButton_EmployeeGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_EmployeeGuide.Click += new System.EventHandler(this.uButton_EmployeeGuide_Click);
            // 
            // uLabel_StockAgentName
            // 
            appearance13.BackColor = System.Drawing.Color.Gainsboro;
            appearance13.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance13.TextHAlignAsString = "Left";
            appearance13.TextVAlignAsString = "Middle";
            this.uLabel_StockAgentName.Appearance = appearance13;
            this.uLabel_StockAgentName.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_StockAgentName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_StockAgentName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_StockAgentName.Location = new System.Drawing.Point(573, 107);
            this.uLabel_StockAgentName.Name = "uLabel_StockAgentName";
            this.uLabel_StockAgentName.Size = new System.Drawing.Size(197, 24);
            this.uLabel_StockAgentName.TabIndex = 1300;
            this.uLabel_StockAgentName.WrapText = false;
            // 
            // tEdit_StockAgentCode
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_StockAgentCode.ActiveAppearance = appearance14;
            this.tEdit_StockAgentCode.AutoSelect = true;
            this.tEdit_StockAgentCode.DataText = "";
            this.tEdit_StockAgentCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_StockAgentCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.tEdit_StockAgentCode.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_StockAgentCode.Location = new System.Drawing.Point(526, 107);
            this.tEdit_StockAgentCode.MaxLength = 4;
            this.tEdit_StockAgentCode.Name = "tEdit_StockAgentCode";
            this.tEdit_StockAgentCode.Size = new System.Drawing.Size(43, 24);
            this.tEdit_StockAgentCode.TabIndex = 16;
            // 
            // uLabel_StockAgentCode
            // 
            appearance21.TextVAlignAsString = "Middle";
            this.uLabel_StockAgentCode.Appearance = appearance21;
            this.uLabel_StockAgentCode.Location = new System.Drawing.Point(435, 109);
            this.uLabel_StockAgentCode.Name = "uLabel_StockAgentCode";
            this.uLabel_StockAgentCode.Size = new System.Drawing.Size(67, 23);
            this.uLabel_StockAgentCode.TabIndex = 1294;
            this.uLabel_StockAgentCode.Text = "担当者";
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
            this.uStatusBar_Main.Controls.Add(this.uCheckEditor_AutoFillToColumn);
            this.uStatusBar_Main.Controls.Add(this.tComboEditor_GridFontSize);
            this.uStatusBar_Main.Location = new System.Drawing.Point(0, 683);
            this.uStatusBar_Main.Name = "uStatusBar_Main";
            ultraStatusPanel1.Control = this.uCheckEditor_AutoFillToColumn;
            ultraStatusPanel1.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel1.Visible = false;
            ultraStatusPanel1.Width = 140;
            appearance329.FontData.SizeInPoints = 9F;
            ultraStatusPanel2.Appearance = appearance329;
            ultraStatusPanel2.Key = "StatusBarPanel_FontSizeTitle";
            ultraStatusPanel2.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic;
            ultraStatusPanel2.Text = "文字サイズ";
            ultraStatusPanel2.Visible = false;
            ultraStatusPanel3.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel3.Control = this.tComboEditor_GridFontSize;
            ultraStatusPanel3.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel3.Visible = false;
            ultraStatusPanel3.Width = 40;
            appearance328.FontData.SizeInPoints = 9F;
            ultraStatusPanel4.Appearance = appearance328;
            ultraStatusPanel4.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel4.Key = "StatusBarPanel_Text";
            ultraStatusPanel4.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel5.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel5.Key = "blank1";
            ultraStatusPanel5.Visible = false;
            ultraStatusPanel5.Width = 2;
            ultraStatusPanel6.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel6.Key = "line1";
            ultraStatusPanel6.Visible = false;
            ultraStatusPanel6.Width = 1;
            ultraStatusPanel7.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel7.Key = "blank2";
            ultraStatusPanel7.Width = 2;
            ultraStatusPanel8.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel8.Key = "line2";
            ultraStatusPanel8.Visible = false;
            ultraStatusPanel8.Width = 1;
            ultraStatusPanel9.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel9.Key = "blank3";
            ultraStatusPanel9.Visible = false;
            ultraStatusPanel9.Width = 2;
            ultraStatusPanel10.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel10.Key = "StatusBarPanel_Progress";
            appearance330.ForeColor = System.Drawing.Color.Black;
            ultraStatusPanel10.ProgressBarInfo.FillAppearance = appearance330;
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
            ultraStatusPanel13.Width = 80;
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
            // DCKOU04101UA
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
            this.Name = "DCKOU04101UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "仕入履歴照会";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.DCKOU04101UA_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MAKON01320UA_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DCKOU04101UA_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_GridFontSize)).EndInit();
            this.Form1_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Detail_UGroupBox)).EndInit();
            this.Detail_UGroupBox.ResumeLayout(false);
            this.DetailCondtnUGroupBoxPanel.ResumeLayout(false);
            this.DetailCondtnUGroupBoxPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Standard_UGroupBox)).EndInit();
            this.Standard_UGroupBox.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel1.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SubSectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierSlipNo_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierSlipNo_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_PartySalesSlipNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SupplierSlipCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_ReconcileFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_PayeeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SupplierFormal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_WarehouseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd)).EndInit();
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
        private Infragistics.Win.Misc.UltraExpandableGroupBox Detail_UGroupBox;
		private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel DetailCondtnUGroupBoxPanel;
        private Infragistics.Win.Misc.UltraLabel uLabel_GoodsCodeTitle;
		private Broadleaf.Library.Windows.Forms.TEdit tEdit_GoodsNo;
        private Infragistics.Win.Misc.UltraExpandableGroupBox Standard_UGroupBox;
        private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel ultraExpandableGroupBoxPanel1;
        private Infragistics.Win.Misc.UltraLabel uLabel_Date1Title;
		private Infragistics.Win.Misc.UltraLabel ultraLabel15;
        private Broadleaf.Library.Windows.Forms.TDateEdit tDateEdit_Date1End;
        private Broadleaf.Library.Windows.Forms.TDateEdit tDateEdit_Date1Start;
        private Infragistics.Win.Misc.UltraButton uButton_WarehouseGuide;
		private Infragistics.Win.Misc.UltraButton uButton_SupplierGuide;
        private Infragistics.Win.Misc.UltraLabel uLabel_WarehouseName;
		private Infragistics.Win.Misc.UltraLabel uLabel_SupplierSnm;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_WarehouseCode;
		private Broadleaf.Library.Windows.Forms.TNedit tNedit_SupplierCd;
		private Infragistics.Win.Misc.UltraLabel uLabel_WarehouseCodeTitle;
        private Infragistics.Win.Misc.UltraLabel uLabel_CustomerCodeTitle;
		private Infragistics.Win.Misc.UltraButton uButton_EmployeeGuide;
        private Infragistics.Win.Misc.UltraLabel uLabel_StockAgentName;
		private Broadleaf.Library.Windows.Forms.TEdit tEdit_StockAgentCode;
        private Infragistics.Win.Misc.UltraLabel uLabel_StockAgentCode;
        private Infragistics.Win.Misc.UltraLabel uLabel_SectionNm;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SectionCodeAllowZero;
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
		private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_SupplierFormal;
		private Infragistics.Win.Misc.UltraLabel uLabel_SupplierFormalTitle;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea5;
        private Broadleaf.Library.Windows.Forms.TToolbarsManager tToolbarsManager_MainMenu;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea9;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Form1_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea1;
        private System.Windows.Forms.ToolTip toolTip1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraButton uButton_GoodsMakerGuide;
		private Infragistics.Win.Misc.UltraLabel uLabel_MakerName;
		private Broadleaf.Library.Windows.Forms.TNedit tNedit_GoodsMakerCd;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Infragistics.Win.Misc.UltraButton uButton_PayeeGuide;
		private Infragistics.Win.Misc.UltraLabel uLabel_PayeeSnm;
		private Broadleaf.Library.Windows.Forms.TNedit tNedit_PayeeCode;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_GoodsName;
		private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_SupplierSlipCd;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_ReconcileFlag;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraLabel uLabel_InputDayTitle;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Broadleaf.Library.Windows.Forms.TDateEdit tDateEdit_InputDayEd;
        private Broadleaf.Library.Windows.Forms.TDateEdit tDateEdit_InputDaySt;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_PartySalesSlipNum;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_SupplierSlipNo_Ed;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_SupplierSlipNo_St;
        private Infragistics.Win.Misc.UltraButton uButton_SubSectionGuide;
        private Infragistics.Win.Misc.UltraLabel uLabel_SubSectionName;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_SubSectionCode;
        private Infragistics.Win.Misc.UltraLabel uLabel_SubSection;

	}
}


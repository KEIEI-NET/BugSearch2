namespace Broadleaf.Windows.Forms
{
	partial class DCHNB04101UA
	{
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

        // ADD 2009/12/04 MANTIS対応[14743]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
        /// <summary>処分済みフラグ</summary>
        private bool _disposed;
        // ADD 2009/12/04 MANTIS対応[14743]：伝票および明細グリッド列の列設定の変更 ----------<<<<<

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
                // ADD 2009/12/04 MANTIS対応[14743]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
                DCHNB04101UA_FormClosing(this, null);
                // ADD 2009/12/04 MANTIS対応[14743]：伝票および明細グリッド列の列設定の変更 ----------<<<<<

				components.Dispose();
			}
			base.Dispose(disposing);

            // ADD 2009/12/04 MANTIS対応[14743]：伝票および明細グリッド列の列設定の変更 ---------->>>>>
            _disposed = true;
            // ADD 2009/12/04 MANTIS対応[14743]：伝票および明細グリッド列の列設定の変更 ----------<<<<<
		}

		#region Windows フォーム デザイナで生成されたコード

		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem14 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem15 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem16 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem17 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem18 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem19 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel5 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel6 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel7 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel8 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel9 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel10 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel11 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel12 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel13 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCHNB04101UA));
            this.uCheckEditor_AutoFillToColumn = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.tComboEditor_GridFontSize = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Form1_Fill_Panel = new System.Windows.Forms.Panel();
            this.panel_Detail = new System.Windows.Forms.Panel();
            this.Detail_UGroupBox = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.DetailCondtnUGroupBoxPanel = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.uCheckEditor_BlPaCOrder = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.uCheckEditor_PccForNS = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_AutoAnswerDivSCM = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_GoodsMakerGuide = new Infragistics.Win.Misc.UltraButton();
            this.uLabel_MakerName = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_GoodsMakerCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tEdit_GoodsName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uLabel_GoodsCodeTitle = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_GoodsNo = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Standard_UGroupBox = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.ultraExpandableGroupBoxPanel1 = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.tComboEditor_AddUpRemDiv = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SectionCodeAllowZero = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_FullModel = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tComboEditor_SalesFormalCode = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.SectionCodeGuide_ultraButton = new Infragistics.Win.Misc.UltraButton();
            this.SectionName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tNedit_SubSectionCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraButton_SubSectionGuide = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_SubSectionName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_CustomerName = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_CustomerCodeTitle = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_CustomerCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uButton_StockCustomerGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_ClaimCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uLabel_ClaimSnm = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_ClaimGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_SalesSlipCd = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.uLabel_SectionNm = new Infragistics.Win.Misc.UltraLabel();
            this.groupBox_ExtractCondition3 = new Infragistics.Win.Misc.UltraGroupBox();
            this.tDateEdit_SalesDateSt = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_FrontEmployeeGuide = new Infragistics.Win.Misc.UltraButton();
            this.tDateEdit_SalesDateEd = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.uLabel_FrontEmployeeName = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_Date1Title = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_FrontEmployeeCd = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SalesSlipNum_St = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_SalesSlipNum_Ed = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_SalesEmployeeName = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_StockAgentCode = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SalesInputCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_SalesEmployeeGuide = new Infragistics.Win.Misc.UltraButton();
            this.uLabel_SalesInputName = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SalesEmployeeCd = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_SalesInputGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.tDateEdit_SearchSlipDateSt = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.tDateEdit_SearchSlipDateEd = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
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
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_AutoAnswerDivSCM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Standard_UGroupBox)).BeginInit();
            this.Standard_UGroupBox.SuspendLayout();
            this.ultraExpandableGroupBoxPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_AddUpRemDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_FullModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SalesFormalCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SubSectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SubSectionName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_ClaimCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SalesSlipCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox_ExtractCondition3)).BeginInit();
            this.groupBox_ExtractCondition3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_FrontEmployeeCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesSlipNum_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesSlipNum_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesInputCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesEmployeeCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tToolbarsManager_MainMenu)).BeginInit();
            this.uStatusBar_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // uCheckEditor_AutoFillToColumn
            // 
            appearance3.FontData.SizeInPoints = 9F;
            this.uCheckEditor_AutoFillToColumn.Appearance = appearance3;
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
            this.Form1_Fill_Panel.Size = new System.Drawing.Size(1016, 620);
            this.Form1_Fill_Panel.TabIndex = 0;
            // 
            // panel_Detail
            // 
            this.panel_Detail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.panel_Detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Detail.Location = new System.Drawing.Point(0, 327);
            this.panel_Detail.Margin = new System.Windows.Forms.Padding(4);
            this.panel_Detail.Name = "panel_Detail";
            this.panel_Detail.Size = new System.Drawing.Size(1016, 293);
            this.panel_Detail.TabIndex = 2;
            // 
            // Detail_UGroupBox
            // 
            this.Detail_UGroupBox.Controls.Add(this.DetailCondtnUGroupBoxPanel);
            this.Detail_UGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.Detail_UGroupBox.ExpandedSize = new System.Drawing.Size(1016, 100);
            this.Detail_UGroupBox.Location = new System.Drawing.Point(0, 227);
            this.Detail_UGroupBox.Name = "Detail_UGroupBox";
            this.Detail_UGroupBox.Size = new System.Drawing.Size(1016, 100);
            this.Detail_UGroupBox.TabIndex = 1;
            this.Detail_UGroupBox.TabStop = false;
            this.Detail_UGroupBox.Text = "詳細条件";
            // 
            // DetailCondtnUGroupBoxPanel
            // 
            this.DetailCondtnUGroupBoxPanel.Controls.Add(this.uCheckEditor_BlPaCOrder);
            this.DetailCondtnUGroupBoxPanel.Controls.Add(this.uCheckEditor_PccForNS);
            this.DetailCondtnUGroupBoxPanel.Controls.Add(this.ultraLabel17);
            this.DetailCondtnUGroupBoxPanel.Controls.Add(this.tComboEditor_AutoAnswerDivSCM);
            this.DetailCondtnUGroupBoxPanel.Controls.Add(this.ultraLabel16);
            this.DetailCondtnUGroupBoxPanel.Controls.Add(this.uButton_GoodsMakerGuide);
            this.DetailCondtnUGroupBoxPanel.Controls.Add(this.uLabel_MakerName);
            this.DetailCondtnUGroupBoxPanel.Controls.Add(this.ultraLabel6);
            this.DetailCondtnUGroupBoxPanel.Controls.Add(this.ultraLabel7);
            this.DetailCondtnUGroupBoxPanel.Controls.Add(this.tNedit_GoodsMakerCd);
            this.DetailCondtnUGroupBoxPanel.Controls.Add(this.tEdit_GoodsName);
            this.DetailCondtnUGroupBoxPanel.Controls.Add(this.uLabel_GoodsCodeTitle);
            this.DetailCondtnUGroupBoxPanel.Controls.Add(this.tEdit_GoodsNo);
            this.DetailCondtnUGroupBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailCondtnUGroupBoxPanel.Location = new System.Drawing.Point(3, 19);
            this.DetailCondtnUGroupBoxPanel.Name = "DetailCondtnUGroupBoxPanel";
            this.DetailCondtnUGroupBoxPanel.Size = new System.Drawing.Size(1010, 78);
            this.DetailCondtnUGroupBoxPanel.TabIndex = 0;
            // 
            // uCheckEditor_BlPaCOrder
            // 
            this.uCheckEditor_BlPaCOrder.Location = new System.Drawing.Point(318, 56);
            this.uCheckEditor_BlPaCOrder.Name = "uCheckEditor_BlPaCOrder";
            this.uCheckEditor_BlPaCOrder.Size = new System.Drawing.Size(176, 20);
            this.uCheckEditor_BlPaCOrder.TabIndex = 1332;
            this.uCheckEditor_BlPaCOrder.Text = "BLﾊﾟｰﾂｵｰﾀﾞｰ分を含む";
            // 
            // uCheckEditor_PccForNS
            // 
            this.uCheckEditor_PccForNS.Location = new System.Drawing.Point(163, 56);
            this.uCheckEditor_PccForNS.Name = "uCheckEditor_PccForNS";
            this.uCheckEditor_PccForNS.Size = new System.Drawing.Size(166, 20);
            this.uCheckEditor_PccForNS.TabIndex = 1331;
            this.uCheckEditor_PccForNS.Text = "PCCforNS分を含む";
            // 
            // ultraLabel17
            // 
            appearance8.TextVAlignAsString = "Middle";
            this.ultraLabel17.Appearance = appearance8;
            this.ultraLabel17.Location = new System.Drawing.Point(9, 55);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(148, 23);
            this.ultraLabel17.TabIndex = 1330;
            this.ultraLabel17.Text = "連携伝票対象区分";
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
            valueListItem3.DataValue = "0";
            valueListItem3.DisplayText = "連携伝票を含まない";
            valueListItem4.DataValue = "1";
            valueListItem4.DisplayText = "連携伝票を含む";
            valueListItem5.DataValue = "2";
            valueListItem5.DisplayText = "連携伝票のみ対象";
            this.tComboEditor_AutoAnswerDivSCM.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem4,
            valueListItem5});
            this.tComboEditor_AutoAnswerDivSCM.Location = new System.Drawing.Point(594, 28);
            this.tComboEditor_AutoAnswerDivSCM.Name = "tComboEditor_AutoAnswerDivSCM";
            this.tComboEditor_AutoAnswerDivSCM.Size = new System.Drawing.Size(218, 24);
            this.tComboEditor_AutoAnswerDivSCM.TabIndex = 1329;
            this.tComboEditor_AutoAnswerDivSCM.ValueChanged += new System.EventHandler(this.tComboEditor_AutoAnswerDivSCM_ValueChanged);
            // 
            // ultraLabel16
            // 
            appearance45.TextVAlignAsString = "Middle";
            this.ultraLabel16.Appearance = appearance45;
            this.ultraLabel16.Location = new System.Drawing.Point(432, 31);
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size(148, 23);
            this.ultraLabel16.TabIndex = 1328;
            this.ultraLabel16.Text = "連携伝票出力区分";
            // 
            // uButton_GoodsMakerGuide
            // 
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_GoodsMakerGuide.Appearance = appearance4;
            this.uButton_GoodsMakerGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_GoodsMakerGuide.Location = new System.Drawing.Point(344, 0);
            this.uButton_GoodsMakerGuide.Name = "uButton_GoodsMakerGuide";
            this.uButton_GoodsMakerGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_GoodsMakerGuide.TabIndex = 1;
            this.toolTip1.SetToolTip(this.uButton_GoodsMakerGuide, "メーカー検索");
            this.uButton_GoodsMakerGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_GoodsMakerGuide.Click += new System.EventHandler(this.uButton_GoodsMakerGuide_Click);
            // 
            // uLabel_MakerName
            // 
            appearance7.BackColor = System.Drawing.Color.Gainsboro;
            appearance7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance7.TextHAlignAsString = "Left";
            appearance7.TextVAlignAsString = "Middle";
            this.uLabel_MakerName.Appearance = appearance7;
            this.uLabel_MakerName.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_MakerName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_MakerName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_MakerName.Location = new System.Drawing.Point(131, 0);
            this.uLabel_MakerName.Name = "uLabel_MakerName";
            this.uLabel_MakerName.Size = new System.Drawing.Size(210, 24);
            this.uLabel_MakerName.TabIndex = 1327;
            this.uLabel_MakerName.WrapText = false;
            // 
            // ultraLabel6
            // 
            appearance48.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance48;
            this.ultraLabel6.Location = new System.Drawing.Point(9, 2);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(68, 23);
            this.ultraLabel6.TabIndex = 1326;
            this.ultraLabel6.Text = "メーカー";
            // 
            // ultraLabel7
            // 
            appearance9.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance9;
            this.ultraLabel7.Location = new System.Drawing.Point(512, 1);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(76, 23);
            this.ultraLabel7.TabIndex = 201;
            this.ultraLabel7.Text = "品名*";
            // 
            // tNedit_GoodsMakerCd
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_GoodsMakerCd.ActiveAppearance = appearance10;
            appearance72.TextHAlignAsString = "Right";
            this.tNedit_GoodsMakerCd.Appearance = appearance72;
            this.tNedit_GoodsMakerCd.AutoSelect = true;
            this.tNedit_GoodsMakerCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_GoodsMakerCd.DataText = "";
            this.tNedit_GoodsMakerCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_GoodsMakerCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_GoodsMakerCd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_GoodsMakerCd.Location = new System.Drawing.Point(85, 0);
            this.tNedit_GoodsMakerCd.MaxLength = 4;
            this.tNedit_GoodsMakerCd.Name = "tNedit_GoodsMakerCd";
            this.tNedit_GoodsMakerCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_GoodsMakerCd.Size = new System.Drawing.Size(43, 24);
            this.tNedit_GoodsMakerCd.TabIndex = 0;
            // 
            // tEdit_GoodsName
            // 
            appearance74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_GoodsName.ActiveAppearance = appearance74;
            appearance75.TextHAlignAsString = "Left";
            this.tEdit_GoodsName.Appearance = appearance75;
            this.tEdit_GoodsName.AutoSelect = true;
            this.tEdit_GoodsName.DataText = "";
            this.tEdit_GoodsName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_GoodsName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 40, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_GoodsName.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.tEdit_GoodsName.Location = new System.Drawing.Point(594, 0);
            this.tEdit_GoodsName.MaxLength = 40;
            this.tEdit_GoodsName.Name = "tEdit_GoodsName";
            this.tEdit_GoodsName.Size = new System.Drawing.Size(330, 24);
            this.tEdit_GoodsName.TabIndex = 3;
            // 
            // uLabel_GoodsCodeTitle
            // 
            appearance14.TextVAlignAsString = "Middle";
            this.uLabel_GoodsCodeTitle.Appearance = appearance14;
            this.uLabel_GoodsCodeTitle.Location = new System.Drawing.Point(9, 29);
            this.uLabel_GoodsCodeTitle.Name = "uLabel_GoodsCodeTitle";
            this.uLabel_GoodsCodeTitle.Size = new System.Drawing.Size(52, 23);
            this.uLabel_GoodsCodeTitle.TabIndex = 81;
            this.uLabel_GoodsCodeTitle.Text = "品番*";
            // 
            // tEdit_GoodsNo
            // 
            appearance82.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_GoodsNo.ActiveAppearance = appearance82;
            appearance17.TextHAlignAsString = "Left";
            this.tEdit_GoodsNo.Appearance = appearance17;
            this.tEdit_GoodsNo.AutoSelect = true;
            this.tEdit_GoodsNo.DataText = "";
            this.tEdit_GoodsNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_GoodsNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
            this.tEdit_GoodsNo.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_GoodsNo.Location = new System.Drawing.Point(85, 28);
            this.tEdit_GoodsNo.MaxLength = 24;
            this.tEdit_GoodsNo.Name = "tEdit_GoodsNo";
            this.tEdit_GoodsNo.Size = new System.Drawing.Size(198, 24);
            this.tEdit_GoodsNo.TabIndex = 2;
            // 
            // Standard_UGroupBox
            // 
            this.Standard_UGroupBox.Controls.Add(this.ultraExpandableGroupBoxPanel1);
            this.Standard_UGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.Standard_UGroupBox.ExpandedSize = new System.Drawing.Size(1016, 227);
            this.Standard_UGroupBox.Location = new System.Drawing.Point(0, 0);
            this.Standard_UGroupBox.Name = "Standard_UGroupBox";
            this.Standard_UGroupBox.Size = new System.Drawing.Size(1016, 227);
            this.Standard_UGroupBox.TabIndex = 0;
            this.Standard_UGroupBox.TabStop = false;
            this.Standard_UGroupBox.Text = "検索条件";
            // 
            // ultraExpandableGroupBoxPanel1
            // 
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.ultraGroupBox1);
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.groupBox_ExtractCondition3);
            this.ultraExpandableGroupBoxPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraExpandableGroupBoxPanel1.Location = new System.Drawing.Point(3, 19);
            this.ultraExpandableGroupBoxPanel1.Name = "ultraExpandableGroupBoxPanel1";
            this.ultraExpandableGroupBoxPanel1.Size = new System.Drawing.Size(1010, 205);
            this.ultraExpandableGroupBoxPanel1.TabIndex = 0;
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.tComboEditor_AddUpRemDiv);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel4);
            this.ultraGroupBox1.Controls.Add(this.tEdit_SectionCodeAllowZero);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel12);
            this.ultraGroupBox1.Controls.Add(this.tEdit_FullModel);
            this.ultraGroupBox1.Controls.Add(this.tComboEditor_SalesFormalCode);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel10);
            this.ultraGroupBox1.Controls.Add(this.SectionCodeGuide_ultraButton);
            this.ultraGroupBox1.Controls.Add(this.SectionName_tEdit);
            this.ultraGroupBox1.Controls.Add(this.tNedit_SubSectionCode);
            this.ultraGroupBox1.Controls.Add(this.ultraButton_SubSectionGuide);
            this.ultraGroupBox1.Controls.Add(this.tEdit_SubSectionName);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel14);
            this.ultraGroupBox1.Controls.Add(this.uLabel_CustomerName);
            this.ultraGroupBox1.Controls.Add(this.uLabel_CustomerCodeTitle);
            this.ultraGroupBox1.Controls.Add(this.tNedit_CustomerCode);
            this.ultraGroupBox1.Controls.Add(this.uButton_StockCustomerGuide);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel3);
            this.ultraGroupBox1.Controls.Add(this.tNedit_ClaimCode);
            this.ultraGroupBox1.Controls.Add(this.uLabel_ClaimSnm);
            this.ultraGroupBox1.Controls.Add(this.uButton_ClaimGuide);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel9);
            this.ultraGroupBox1.Controls.Add(this.tComboEditor_SalesSlipCd);
            this.ultraGroupBox1.Controls.Add(this.uLabel_SectionNm);
            this.ultraGroupBox1.Location = new System.Drawing.Point(9, 2);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(485, 200);
            this.ultraGroupBox1.TabIndex = 0;
            // 
            // tComboEditor_AddUpRemDiv
            // 
            appearance49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_AddUpRemDiv.ActiveAppearance = appearance49;
            appearance89.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_AddUpRemDiv.Appearance = appearance89;
            this.tComboEditor_AddUpRemDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_AddUpRemDiv.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_AddUpRemDiv.ItemAppearance = appearance50;
            valueListItem6.DataValue = 0;
            valueListItem6.DisplayText = "全て";
            valueListItem7.DataValue = 2;
            valueListItem7.DisplayText = "計上済み分";
            valueListItem8.DataValue = 1;
            valueListItem8.DisplayText = "未計上分";
            this.tComboEditor_AddUpRemDiv.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem6,
            valueListItem7,
            valueListItem8});
            this.tComboEditor_AddUpRemDiv.Location = new System.Drawing.Point(76, 139);
            this.tComboEditor_AddUpRemDiv.Name = "tComboEditor_AddUpRemDiv";
            this.tComboEditor_AddUpRemDiv.Size = new System.Drawing.Size(115, 24);
            this.tComboEditor_AddUpRemDiv.TabIndex = 10;
            // 
            // ultraLabel4
            // 
            appearance13.ForeColorDisabled = System.Drawing.Color.Black;
            appearance13.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance13;
            this.ultraLabel4.Location = new System.Drawing.Point(8, 140);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(67, 24);
            this.ultraLabel4.TabIndex = 1381;
            this.ultraLabel4.Text = "出荷状況";
            // 
            // tEdit_SectionCodeAllowZero
            // 
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SectionCodeAllowZero.ActiveAppearance = appearance23;
            this.tEdit_SectionCodeAllowZero.AutoSelect = true;
            this.tEdit_SectionCodeAllowZero.DataText = "12";
            this.tEdit_SectionCodeAllowZero.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCodeAllowZero.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_SectionCodeAllowZero.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_SectionCodeAllowZero.Location = new System.Drawing.Point(76, 10);
            this.tEdit_SectionCodeAllowZero.MaxLength = 2;
            this.tEdit_SectionCodeAllowZero.Name = "tEdit_SectionCodeAllowZero";
            this.tEdit_SectionCodeAllowZero.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCodeAllowZero.TabIndex = 0;
            this.tEdit_SectionCodeAllowZero.Text = "12";
            this.tEdit_SectionCodeAllowZero.Enter += new System.EventHandler(this.tEdit_SectionCodeAllowZero_Enter);
            // 
            // ultraLabel12
            // 
            appearance51.ForeColorDisabled = System.Drawing.Color.Black;
            appearance51.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance51;
            this.ultraLabel12.Location = new System.Drawing.Point(8, 165);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(67, 24);
            this.ultraLabel12.TabIndex = 1380;
            this.ultraLabel12.Text = "型式*";
            // 
            // tEdit_FullModel
            // 
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_FullModel.ActiveAppearance = appearance16;
            this.tEdit_FullModel.AutoSelect = true;
            this.tEdit_FullModel.DataText = "12345678901234567890123456789012345678901234";
            this.tEdit_FullModel.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_FullModel.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_FullModel.Location = new System.Drawing.Point(76, 165);
            this.tEdit_FullModel.MaxLength = 20;
            this.tEdit_FullModel.Name = "tEdit_FullModel";
            this.tEdit_FullModel.Size = new System.Drawing.Size(345, 24);
            this.tEdit_FullModel.TabIndex = 11;
            this.tEdit_FullModel.Text = "12345678901234567890123456789012345678901234";
            // 
            // tComboEditor_SalesFormalCode
            // 
            appearance90.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SalesFormalCode.ActiveAppearance = appearance90;
            appearance92.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_SalesFormalCode.Appearance = appearance92;
            this.tComboEditor_SalesFormalCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_SalesFormalCode.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance93.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SalesFormalCode.ItemAppearance = appearance93;
            valueListItem9.DataValue = 30;
            valueListItem9.DisplayText = "売上";
            valueListItem10.DataValue = 40;
            valueListItem10.DisplayText = "貸出";
            valueListItem11.DataValue = 20;
            valueListItem11.DisplayText = "受注";
            valueListItem12.DataValue = 10;
            valueListItem12.DisplayText = "見積";
            valueListItem13.DataValue = 15;
            valueListItem13.DisplayText = "単価見積";
            valueListItem14.DataValue = -1;
            valueListItem14.DisplayText = "全て";
            this.tComboEditor_SalesFormalCode.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem9,
            valueListItem10,
            valueListItem11,
            valueListItem12,
            valueListItem13,
            valueListItem14});
            this.tComboEditor_SalesFormalCode.Location = new System.Drawing.Point(76, 114);
            this.tComboEditor_SalesFormalCode.Name = "tComboEditor_SalesFormalCode";
            this.tComboEditor_SalesFormalCode.Size = new System.Drawing.Size(115, 24);
            this.tComboEditor_SalesFormalCode.TabIndex = 8;
            this.tComboEditor_SalesFormalCode.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_SalesFormalCode_SelectionChangeCommitted);
            this.tComboEditor_SalesFormalCode.ValueChanged += new System.EventHandler(this.tComboEditor_SalesFormalCode_ValueChanged);
            // 
            // ultraLabel10
            // 
            appearance37.ForeColorDisabled = System.Drawing.Color.Black;
            appearance37.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance37;
            this.ultraLabel10.Location = new System.Drawing.Point(8, 114);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(67, 24);
            this.ultraLabel10.TabIndex = 1378;
            this.ultraLabel10.Text = "伝票種別";
            // 
            // SectionCodeGuide_ultraButton
            // 
            this.SectionCodeGuide_ultraButton.Location = new System.Drawing.Point(288, 10);
            this.SectionCodeGuide_ultraButton.Name = "SectionCodeGuide_ultraButton";
            this.SectionCodeGuide_ultraButton.Size = new System.Drawing.Size(24, 24);
            this.SectionCodeGuide_ultraButton.TabIndex = 1;
            this.SectionCodeGuide_ultraButton.Click += new System.EventHandler(this.SectionCodeGuide_ultraButton_Click);
            // 
            // SectionName_tEdit
            // 
            this.SectionName_tEdit.AcceptsTab = true;
            this.SectionName_tEdit.ActiveAppearance = appearance21;
            appearance47.BackColor = System.Drawing.Color.Gainsboro;
            appearance47.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance47.ForeColorDisabled = System.Drawing.Color.Black;
            appearance47.TextHAlignAsString = "Left";
            appearance47.TextVAlignAsString = "Middle";
            this.SectionName_tEdit.Appearance = appearance47;
            this.SectionName_tEdit.AutoSelect = true;
            this.SectionName_tEdit.BackColor = System.Drawing.Color.Gainsboro;
            this.SectionName_tEdit.DataText = "";
            this.SectionName_tEdit.Enabled = false;
            this.SectionName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.SectionName_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.SectionName_tEdit.Location = new System.Drawing.Point(106, 10);
            this.SectionName_tEdit.MaxLength = 12;
            this.SectionName_tEdit.Name = "SectionName_tEdit";
            this.SectionName_tEdit.Size = new System.Drawing.Size(179, 24);
            this.SectionName_tEdit.TabIndex = 1376;
            this.SectionName_tEdit.TabStop = false;
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
            this.tNedit_SubSectionCode.DataText = "12";
            this.tNedit_SubSectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SubSectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SubSectionCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_SubSectionCode.Location = new System.Drawing.Point(76, 36);
            this.tNedit_SubSectionCode.MaxLength = 2;
            this.tNedit_SubSectionCode.Name = "tNedit_SubSectionCode";
            this.tNedit_SubSectionCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_SubSectionCode.Size = new System.Drawing.Size(28, 24);
            this.tNedit_SubSectionCode.TabIndex = 2;
            this.tNedit_SubSectionCode.Text = "12";
            // 
            // ultraButton_SubSectionGuide
            // 
            this.ultraButton_SubSectionGuide.Location = new System.Drawing.Point(288, 36);
            this.ultraButton_SubSectionGuide.Name = "ultraButton_SubSectionGuide";
            this.ultraButton_SubSectionGuide.Size = new System.Drawing.Size(24, 24);
            this.ultraButton_SubSectionGuide.TabIndex = 3;
            this.ultraButton_SubSectionGuide.Click += new System.EventHandler(this.ultraButton_SubSectionGuide_Click);
            // 
            // tEdit_SubSectionName
            // 
            this.tEdit_SubSectionName.AcceptsTab = true;
            this.tEdit_SubSectionName.ActiveAppearance = appearance11;
            appearance12.BackColor = System.Drawing.Color.Gainsboro;
            appearance12.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance12.ForeColorDisabled = System.Drawing.Color.Black;
            appearance12.TextHAlignAsString = "Left";
            appearance12.TextVAlignAsString = "Middle";
            this.tEdit_SubSectionName.Appearance = appearance12;
            this.tEdit_SubSectionName.AutoSelect = true;
            this.tEdit_SubSectionName.BackColor = System.Drawing.Color.Gainsboro;
            this.tEdit_SubSectionName.DataText = "";
            this.tEdit_SubSectionName.Enabled = false;
            this.tEdit_SubSectionName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SubSectionName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_SubSectionName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.tEdit_SubSectionName.Location = new System.Drawing.Point(106, 36);
            this.tEdit_SubSectionName.MaxLength = 12;
            this.tEdit_SubSectionName.Name = "tEdit_SubSectionName";
            this.tEdit_SubSectionName.Size = new System.Drawing.Size(179, 24);
            this.tEdit_SubSectionName.TabIndex = 1373;
            this.tEdit_SubSectionName.TabStop = false;
            // 
            // ultraLabel14
            // 
            appearance15.ForeColorDisabled = System.Drawing.Color.Black;
            appearance15.TextVAlignAsString = "Middle";
            this.ultraLabel14.Appearance = appearance15;
            this.ultraLabel14.Location = new System.Drawing.Point(8, 36);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(67, 24);
            this.ultraLabel14.TabIndex = 1372;
            this.ultraLabel14.Text = "部門";
            // 
            // uLabel_CustomerName
            // 
            appearance26.BackColor = System.Drawing.Color.Gainsboro;
            appearance26.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance26.TextHAlignAsString = "Left";
            appearance26.TextVAlignAsString = "Middle";
            this.uLabel_CustomerName.Appearance = appearance26;
            this.uLabel_CustomerName.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_CustomerName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_CustomerName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_CustomerName.Location = new System.Drawing.Point(154, 62);
            this.uLabel_CustomerName.Name = "uLabel_CustomerName";
            this.uLabel_CustomerName.Size = new System.Drawing.Size(222, 24);
            this.uLabel_CustomerName.TabIndex = 1367;
            this.uLabel_CustomerName.WrapText = false;
            // 
            // uLabel_CustomerCodeTitle
            // 
            appearance27.TextVAlignAsString = "Middle";
            this.uLabel_CustomerCodeTitle.Appearance = appearance27;
            this.uLabel_CustomerCodeTitle.Location = new System.Drawing.Point(8, 62);
            this.uLabel_CustomerCodeTitle.Name = "uLabel_CustomerCodeTitle";
            this.uLabel_CustomerCodeTitle.Size = new System.Drawing.Size(52, 23);
            this.uLabel_CustomerCodeTitle.TabIndex = 1366;
            this.uLabel_CustomerCodeTitle.Text = "得意先";
            // 
            // tNedit_CustomerCode
            // 
            appearance70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_CustomerCode.ActiveAppearance = appearance70;
            appearance71.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance71.ForeColorDisabled = System.Drawing.Color.Black;
            appearance71.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode.Appearance = appearance71;
            this.tNedit_CustomerCode.AutoSelect = true;
            this.tNedit_CustomerCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode.DataText = "123456789";
            this.tNedit_CustomerCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustomerCode.Location = new System.Drawing.Point(76, 62);
            this.tNedit_CustomerCode.MaxLength = 8;
            this.tNedit_CustomerCode.Name = "tNedit_CustomerCode";
            this.tNedit_CustomerCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_CustomerCode.Size = new System.Drawing.Size(74, 24);
            this.tNedit_CustomerCode.TabIndex = 4;
            this.tNedit_CustomerCode.Text = "123456789";
            // 
            // uButton_StockCustomerGuide
            // 
            appearance30.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance30.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_StockCustomerGuide.Appearance = appearance30;
            this.uButton_StockCustomerGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_StockCustomerGuide.Location = new System.Drawing.Point(379, 62);
            this.uButton_StockCustomerGuide.Name = "uButton_StockCustomerGuide";
            this.uButton_StockCustomerGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_StockCustomerGuide.TabIndex = 5;
            this.toolTip1.SetToolTip(this.uButton_StockCustomerGuide, "得意先検索");
            this.uButton_StockCustomerGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_StockCustomerGuide.Click += new System.EventHandler(this.uButton_StockCustomerGuide_Click);
            // 
            // ultraLabel3
            // 
            appearance31.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance31;
            this.ultraLabel3.Location = new System.Drawing.Point(8, 88);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(52, 23);
            this.ultraLabel3.TabIndex = 1368;
            this.ultraLabel3.Text = "請求先";
            // 
            // tNedit_ClaimCode
            // 
            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_ClaimCode.ActiveAppearance = appearance32;
            appearance33.TextHAlignAsString = "Right";
            this.tNedit_ClaimCode.Appearance = appearance33;
            this.tNedit_ClaimCode.AutoSelect = true;
            this.tNedit_ClaimCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_ClaimCode.DataText = "";
            this.tNedit_ClaimCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_ClaimCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_ClaimCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_ClaimCode.Location = new System.Drawing.Point(76, 88);
            this.tNedit_ClaimCode.MaxLength = 8;
            this.tNedit_ClaimCode.Name = "tNedit_ClaimCode";
            this.tNedit_ClaimCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_ClaimCode.Size = new System.Drawing.Size(74, 24);
            this.tNedit_ClaimCode.TabIndex = 6;
            // 
            // uLabel_ClaimSnm
            // 
            appearance34.BackColor = System.Drawing.Color.Gainsboro;
            appearance34.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance34.TextHAlignAsString = "Left";
            appearance34.TextVAlignAsString = "Middle";
            this.uLabel_ClaimSnm.Appearance = appearance34;
            this.uLabel_ClaimSnm.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_ClaimSnm.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_ClaimSnm.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_ClaimSnm.Location = new System.Drawing.Point(154, 88);
            this.uLabel_ClaimSnm.Name = "uLabel_ClaimSnm";
            this.uLabel_ClaimSnm.Size = new System.Drawing.Size(222, 24);
            this.uLabel_ClaimSnm.TabIndex = 1369;
            this.uLabel_ClaimSnm.WrapText = false;
            // 
            // uButton_ClaimGuide
            // 
            appearance35.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance35.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_ClaimGuide.Appearance = appearance35;
            this.uButton_ClaimGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_ClaimGuide.Location = new System.Drawing.Point(379, 88);
            this.uButton_ClaimGuide.Name = "uButton_ClaimGuide";
            this.uButton_ClaimGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_ClaimGuide.TabIndex = 7;
            this.toolTip1.SetToolTip(this.uButton_ClaimGuide, "請求先検索");
            this.uButton_ClaimGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_ClaimGuide.Click += new System.EventHandler(this.uButton_ClaimGuide_Click);
            // 
            // ultraLabel9
            // 
            appearance38.ForeColorDisabled = System.Drawing.Color.Black;
            appearance38.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance38;
            this.ultraLabel9.Location = new System.Drawing.Point(200, 114);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(67, 24);
            this.ultraLabel9.TabIndex = 1357;
            this.ultraLabel9.Text = "伝票区分";
            // 
            // tComboEditor_SalesSlipCd
            // 
            appearance43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SalesSlipCd.ActiveAppearance = appearance43;
            appearance88.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_SalesSlipCd.Appearance = appearance88;
            this.tComboEditor_SalesSlipCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_SalesSlipCd.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SalesSlipCd.ItemAppearance = appearance44;
            valueListItem15.DataValue = -1;
            valueListItem15.DisplayText = "全て";
            valueListItem16.DataValue = 0;
            valueListItem16.DisplayText = "掛売上";
            valueListItem17.DataValue = 1;
            valueListItem17.DisplayText = "掛返品";
            valueListItem18.DataValue = 100;
            valueListItem18.DisplayText = "現金売上";
            valueListItem19.DataValue = 101;
            valueListItem19.DisplayText = "現金返品";
            this.tComboEditor_SalesSlipCd.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem15,
            valueListItem16,
            valueListItem17,
            valueListItem18,
            valueListItem19});
            this.tComboEditor_SalesSlipCd.Location = new System.Drawing.Point(273, 114);
            this.tComboEditor_SalesSlipCd.Name = "tComboEditor_SalesSlipCd";
            this.tComboEditor_SalesSlipCd.Size = new System.Drawing.Size(115, 24);
            this.tComboEditor_SalesSlipCd.TabIndex = 9;
            // 
            // uLabel_SectionNm
            // 
            appearance39.ForeColorDisabled = System.Drawing.Color.Black;
            appearance39.TextVAlignAsString = "Middle";
            this.uLabel_SectionNm.Appearance = appearance39;
            this.uLabel_SectionNm.Location = new System.Drawing.Point(8, 10);
            this.uLabel_SectionNm.Name = "uLabel_SectionNm";
            this.uLabel_SectionNm.Size = new System.Drawing.Size(67, 24);
            this.uLabel_SectionNm.TabIndex = 1355;
            this.uLabel_SectionNm.Text = "拠点";
            // 
            // groupBox_ExtractCondition3
            // 
            this.groupBox_ExtractCondition3.Controls.Add(this.tDateEdit_SalesDateSt);
            this.groupBox_ExtractCondition3.Controls.Add(this.ultraLabel15);
            this.groupBox_ExtractCondition3.Controls.Add(this.uButton_FrontEmployeeGuide);
            this.groupBox_ExtractCondition3.Controls.Add(this.tDateEdit_SalesDateEd);
            this.groupBox_ExtractCondition3.Controls.Add(this.uLabel_FrontEmployeeName);
            this.groupBox_ExtractCondition3.Controls.Add(this.uLabel_Date1Title);
            this.groupBox_ExtractCondition3.Controls.Add(this.tEdit_FrontEmployeeCd);
            this.groupBox_ExtractCondition3.Controls.Add(this.ultraLabel13);
            this.groupBox_ExtractCondition3.Controls.Add(this.ultraLabel1);
            this.groupBox_ExtractCondition3.Controls.Add(this.tEdit_SalesSlipNum_St);
            this.groupBox_ExtractCondition3.Controls.Add(this.tEdit_SalesSlipNum_Ed);
            this.groupBox_ExtractCondition3.Controls.Add(this.ultraLabel8);
            this.groupBox_ExtractCondition3.Controls.Add(this.uLabel_SalesEmployeeName);
            this.groupBox_ExtractCondition3.Controls.Add(this.uLabel_StockAgentCode);
            this.groupBox_ExtractCondition3.Controls.Add(this.tEdit_SalesInputCode);
            this.groupBox_ExtractCondition3.Controls.Add(this.uButton_SalesEmployeeGuide);
            this.groupBox_ExtractCondition3.Controls.Add(this.uLabel_SalesInputName);
            this.groupBox_ExtractCondition3.Controls.Add(this.tEdit_SalesEmployeeCd);
            this.groupBox_ExtractCondition3.Controls.Add(this.uButton_SalesInputGuide);
            this.groupBox_ExtractCondition3.Controls.Add(this.ultraLabel11);
            this.groupBox_ExtractCondition3.Controls.Add(this.tDateEdit_SearchSlipDateSt);
            this.groupBox_ExtractCondition3.Controls.Add(this.tDateEdit_SearchSlipDateEd);
            this.groupBox_ExtractCondition3.Controls.Add(this.ultraLabel5);
            this.groupBox_ExtractCondition3.Controls.Add(this.ultraLabel2);
            this.groupBox_ExtractCondition3.Location = new System.Drawing.Point(500, 3);
            this.groupBox_ExtractCondition3.Name = "groupBox_ExtractCondition3";
            this.groupBox_ExtractCondition3.Size = new System.Drawing.Size(501, 199);
            this.groupBox_ExtractCondition3.TabIndex = 1;
            // 
            // tDateEdit_SalesDateSt
            // 
            appearance52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tDateEdit_SalesDateSt.ActiveEditAppearance = appearance52;
            this.tDateEdit_SalesDateSt.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit_SalesDateSt.CalendarDisp = true;
            appearance53.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance53.ForeColorDisabled = System.Drawing.Color.Black;
            appearance53.TextHAlignAsString = "Left";
            appearance53.TextVAlignAsString = "Middle";
            this.tDateEdit_SalesDateSt.EditAppearance = appearance53;
            this.tDateEdit_SalesDateSt.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit_SalesDateSt.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance54.TextHAlignAsString = "Left";
            appearance54.TextVAlignAsString = "Bottom";
            this.tDateEdit_SalesDateSt.LabelAppearance = appearance54;
            this.tDateEdit_SalesDateSt.Location = new System.Drawing.Point(94, 9);
            this.tDateEdit_SalesDateSt.Name = "tDateEdit_SalesDateSt";
            this.tDateEdit_SalesDateSt.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit_SalesDateSt.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.tDateEdit_SalesDateSt.Size = new System.Drawing.Size(176, 24);
            this.tDateEdit_SalesDateSt.TabIndex = 0;
            this.tDateEdit_SalesDateSt.TabStop = true;
            // 
            // ultraLabel15
            // 
            appearance58.TextVAlignAsString = "Middle";
            this.ultraLabel15.Appearance = appearance58;
            this.ultraLabel15.Location = new System.Drawing.Point(273, 9);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel15.TabIndex = 1310;
            this.ultraLabel15.Text = "～";
            // 
            // uButton_FrontEmployeeGuide
            // 
            appearance24.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance24.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_FrontEmployeeGuide.Appearance = appearance24;
            this.uButton_FrontEmployeeGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_FrontEmployeeGuide.Location = new System.Drawing.Point(376, 139);
            this.uButton_FrontEmployeeGuide.Name = "uButton_FrontEmployeeGuide";
            this.uButton_FrontEmployeeGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_FrontEmployeeGuide.TabIndex = 11;
            this.toolTip1.SetToolTip(this.uButton_FrontEmployeeGuide, "担当者ガイド");
            this.uButton_FrontEmployeeGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_FrontEmployeeGuide.Click += new System.EventHandler(this.uButton_FrontEmployeeGuide_Click);
            // 
            // tDateEdit_SalesDateEd
            // 
            appearance55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tDateEdit_SalesDateEd.ActiveEditAppearance = appearance55;
            this.tDateEdit_SalesDateEd.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit_SalesDateEd.CalendarDisp = true;
            appearance56.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance56.ForeColorDisabled = System.Drawing.Color.Black;
            appearance56.TextHAlignAsString = "Left";
            appearance56.TextVAlignAsString = "Middle";
            this.tDateEdit_SalesDateEd.EditAppearance = appearance56;
            this.tDateEdit_SalesDateEd.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit_SalesDateEd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance57.TextHAlignAsString = "Left";
            appearance57.TextVAlignAsString = "Bottom";
            this.tDateEdit_SalesDateEd.LabelAppearance = appearance57;
            this.tDateEdit_SalesDateEd.Location = new System.Drawing.Point(296, 9);
            this.tDateEdit_SalesDateEd.Name = "tDateEdit_SalesDateEd";
            this.tDateEdit_SalesDateEd.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit_SalesDateEd.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.tDateEdit_SalesDateEd.Size = new System.Drawing.Size(176, 24);
            this.tDateEdit_SalesDateEd.TabIndex = 1;
            this.tDateEdit_SalesDateEd.TabStop = true;
            // 
            // uLabel_FrontEmployeeName
            // 
            appearance22.BackColor = System.Drawing.Color.Gainsboro;
            appearance22.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance22.TextHAlignAsString = "Left";
            appearance22.TextVAlignAsString = "Middle";
            this.uLabel_FrontEmployeeName.Appearance = appearance22;
            this.uLabel_FrontEmployeeName.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_FrontEmployeeName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_FrontEmployeeName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_FrontEmployeeName.Location = new System.Drawing.Point(141, 138);
            this.uLabel_FrontEmployeeName.Name = "uLabel_FrontEmployeeName";
            this.uLabel_FrontEmployeeName.Size = new System.Drawing.Size(233, 24);
            this.uLabel_FrontEmployeeName.TabIndex = 1368;
            this.uLabel_FrontEmployeeName.WrapText = false;
            // 
            // uLabel_Date1Title
            // 
            appearance83.TextVAlignAsString = "Middle";
            this.uLabel_Date1Title.Appearance = appearance83;
            this.uLabel_Date1Title.BackColorInternal = System.Drawing.Color.Transparent;
            this.uLabel_Date1Title.Location = new System.Drawing.Point(12, 10);
            this.uLabel_Date1Title.Name = "uLabel_Date1Title";
            this.uLabel_Date1Title.Size = new System.Drawing.Size(52, 23);
            this.uLabel_Date1Title.TabIndex = 1308;
            this.uLabel_Date1Title.Text = "売上日";
            // 
            // tEdit_FrontEmployeeCd
            // 
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_FrontEmployeeCd.ActiveAppearance = appearance20;
            this.tEdit_FrontEmployeeCd.AutoSelect = true;
            this.tEdit_FrontEmployeeCd.DataText = "1234";
            this.tEdit_FrontEmployeeCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_FrontEmployeeCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.tEdit_FrontEmployeeCd.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_FrontEmployeeCd.Location = new System.Drawing.Point(94, 138);
            this.tEdit_FrontEmployeeCd.MaxLength = 9;
            this.tEdit_FrontEmployeeCd.Name = "tEdit_FrontEmployeeCd";
            this.tEdit_FrontEmployeeCd.Size = new System.Drawing.Size(43, 24);
            this.tEdit_FrontEmployeeCd.TabIndex = 10;
            this.tEdit_FrontEmployeeCd.Text = "1234";
            // 
            // ultraLabel13
            // 
            appearance25.TextVAlignAsString = "Middle";
            this.ultraLabel13.Appearance = appearance25;
            this.ultraLabel13.Location = new System.Drawing.Point(12, 139);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(52, 23);
            this.ultraLabel13.TabIndex = 1366;
            this.ultraLabel13.Text = "受注者";
            // 
            // ultraLabel1
            // 
            appearance42.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance42;
            this.ultraLabel1.Location = new System.Drawing.Point(12, 62);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(68, 23);
            this.ultraLabel1.TabIndex = 1363;
            this.ultraLabel1.Text = "伝票番号";
            // 
            // tEdit_SalesSlipNum_St
            // 
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SalesSlipNum_St.ActiveAppearance = appearance46;
            appearance76.TextHAlignAsString = "Left";
            this.tEdit_SalesSlipNum_St.Appearance = appearance76;
            this.tEdit_SalesSlipNum_St.AutoSelect = true;
            this.tEdit_SalesSlipNum_St.AutoSize = false;
            this.tEdit_SalesSlipNum_St.DataText = "123456789";
            this.tEdit_SalesSlipNum_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SalesSlipNum_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_SalesSlipNum_St.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_SalesSlipNum_St.Location = new System.Drawing.Point(94, 62);
            this.tEdit_SalesSlipNum_St.MaxLength = 9;
            this.tEdit_SalesSlipNum_St.Name = "tEdit_SalesSlipNum_St";
            this.tEdit_SalesSlipNum_St.Size = new System.Drawing.Size(82, 24);
            this.tEdit_SalesSlipNum_St.TabIndex = 4;
            this.tEdit_SalesSlipNum_St.Text = "123456789";
            // 
            // tEdit_SalesSlipNum_Ed
            // 
            appearance77.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SalesSlipNum_Ed.ActiveAppearance = appearance77;
            appearance80.TextHAlignAsString = "Left";
            this.tEdit_SalesSlipNum_Ed.Appearance = appearance80;
            this.tEdit_SalesSlipNum_Ed.AutoSelect = true;
            this.tEdit_SalesSlipNum_Ed.AutoSize = false;
            this.tEdit_SalesSlipNum_Ed.DataText = "";
            this.tEdit_SalesSlipNum_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SalesSlipNum_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_SalesSlipNum_Ed.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_SalesSlipNum_Ed.Location = new System.Drawing.Point(208, 62);
            this.tEdit_SalesSlipNum_Ed.MaxLength = 9;
            this.tEdit_SalesSlipNum_Ed.Name = "tEdit_SalesSlipNum_Ed";
            this.tEdit_SalesSlipNum_Ed.Size = new System.Drawing.Size(82, 24);
            this.tEdit_SalesSlipNum_Ed.TabIndex = 5;
            // 
            // ultraLabel8
            // 
            appearance79.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance79;
            this.ultraLabel8.Location = new System.Drawing.Point(182, 61);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel8.TabIndex = 1365;
            this.ultraLabel8.Text = "～";
            // 
            // uLabel_SalesEmployeeName
            // 
            appearance18.BackColor = System.Drawing.Color.Gainsboro;
            appearance18.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance18.TextHAlignAsString = "Left";
            appearance18.TextVAlignAsString = "Middle";
            this.uLabel_SalesEmployeeName.Appearance = appearance18;
            this.uLabel_SalesEmployeeName.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_SalesEmployeeName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_SalesEmployeeName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_SalesEmployeeName.Location = new System.Drawing.Point(141, 88);
            this.uLabel_SalesEmployeeName.Name = "uLabel_SalesEmployeeName";
            this.uLabel_SalesEmployeeName.Size = new System.Drawing.Size(233, 24);
            this.uLabel_SalesEmployeeName.TabIndex = 1357;
            this.uLabel_SalesEmployeeName.WrapText = false;
            // 
            // uLabel_StockAgentCode
            // 
            appearance19.TextVAlignAsString = "Middle";
            this.uLabel_StockAgentCode.Appearance = appearance19;
            this.uLabel_StockAgentCode.Location = new System.Drawing.Point(12, 87);
            this.uLabel_StockAgentCode.Name = "uLabel_StockAgentCode";
            this.uLabel_StockAgentCode.Size = new System.Drawing.Size(52, 23);
            this.uLabel_StockAgentCode.TabIndex = 1356;
            this.uLabel_StockAgentCode.Text = "担当者";
            // 
            // tEdit_SalesInputCode
            // 
            appearance84.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SalesInputCode.ActiveAppearance = appearance84;
            this.tEdit_SalesInputCode.AutoSelect = true;
            this.tEdit_SalesInputCode.DataText = "1234";
            this.tEdit_SalesInputCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SalesInputCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.tEdit_SalesInputCode.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_SalesInputCode.Location = new System.Drawing.Point(94, 113);
            this.tEdit_SalesInputCode.MaxLength = 9;
            this.tEdit_SalesInputCode.Name = "tEdit_SalesInputCode";
            this.tEdit_SalesInputCode.Size = new System.Drawing.Size(43, 24);
            this.tEdit_SalesInputCode.TabIndex = 8;
            this.tEdit_SalesInputCode.Text = "1234";
            // 
            // uButton_SalesEmployeeGuide
            // 
            appearance78.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance78.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_SalesEmployeeGuide.Appearance = appearance78;
            this.uButton_SalesEmployeeGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_SalesEmployeeGuide.Location = new System.Drawing.Point(376, 88);
            this.uButton_SalesEmployeeGuide.Name = "uButton_SalesEmployeeGuide";
            this.uButton_SalesEmployeeGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SalesEmployeeGuide.TabIndex = 7;
            this.toolTip1.SetToolTip(this.uButton_SalesEmployeeGuide, "担当者ガイド");
            this.uButton_SalesEmployeeGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SalesEmployeeGuide.Click += new System.EventHandler(this.uButton_SalesEmployeeGuide_Click);
            // 
            // uLabel_SalesInputName
            // 
            appearance85.BackColor = System.Drawing.Color.Gainsboro;
            appearance85.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance85.TextHAlignAsString = "Left";
            appearance85.TextVAlignAsString = "Middle";
            this.uLabel_SalesInputName.Appearance = appearance85;
            this.uLabel_SalesInputName.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_SalesInputName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_SalesInputName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_SalesInputName.Location = new System.Drawing.Point(141, 113);
            this.uLabel_SalesInputName.Name = "uLabel_SalesInputName";
            this.uLabel_SalesInputName.Size = new System.Drawing.Size(233, 24);
            this.uLabel_SalesInputName.TabIndex = 1359;
            this.uLabel_SalesInputName.WrapText = false;
            // 
            // tEdit_SalesEmployeeCd
            // 
            appearance91.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SalesEmployeeCd.ActiveAppearance = appearance91;
            this.tEdit_SalesEmployeeCd.AutoSelect = true;
            this.tEdit_SalesEmployeeCd.DataText = "1234";
            this.tEdit_SalesEmployeeCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SalesEmployeeCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.tEdit_SalesEmployeeCd.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_SalesEmployeeCd.Location = new System.Drawing.Point(94, 88);
            this.tEdit_SalesEmployeeCd.MaxLength = 9;
            this.tEdit_SalesEmployeeCd.Name = "tEdit_SalesEmployeeCd";
            this.tEdit_SalesEmployeeCd.Size = new System.Drawing.Size(43, 24);
            this.tEdit_SalesEmployeeCd.TabIndex = 6;
            this.tEdit_SalesEmployeeCd.Text = "1234";
            // 
            // uButton_SalesInputGuide
            // 
            appearance87.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance87.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_SalesInputGuide.Appearance = appearance87;
            this.uButton_SalesInputGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_SalesInputGuide.Location = new System.Drawing.Point(376, 113);
            this.uButton_SalesInputGuide.Name = "uButton_SalesInputGuide";
            this.uButton_SalesInputGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SalesInputGuide.TabIndex = 9;
            this.toolTip1.SetToolTip(this.uButton_SalesInputGuide, "担当者ガイド");
            this.uButton_SalesInputGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SalesInputGuide.Click += new System.EventHandler(this.uButton_SalesInputGuide_Click);
            // 
            // ultraLabel11
            // 
            appearance86.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance86;
            this.ultraLabel11.Location = new System.Drawing.Point(12, 113);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(52, 23);
            this.ultraLabel11.TabIndex = 1358;
            this.ultraLabel11.Text = "発行者";
            // 
            // tDateEdit_SearchSlipDateSt
            // 
            appearance59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tDateEdit_SearchSlipDateSt.ActiveEditAppearance = appearance59;
            this.tDateEdit_SearchSlipDateSt.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit_SearchSlipDateSt.CalendarDisp = true;
            appearance60.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance60.ForeColorDisabled = System.Drawing.Color.Black;
            appearance60.TextHAlignAsString = "Left";
            appearance60.TextVAlignAsString = "Middle";
            this.tDateEdit_SearchSlipDateSt.EditAppearance = appearance60;
            this.tDateEdit_SearchSlipDateSt.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit_SearchSlipDateSt.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance61.TextHAlignAsString = "Left";
            appearance61.TextVAlignAsString = "Bottom";
            this.tDateEdit_SearchSlipDateSt.LabelAppearance = appearance61;
            this.tDateEdit_SearchSlipDateSt.Location = new System.Drawing.Point(94, 35);
            this.tDateEdit_SearchSlipDateSt.Name = "tDateEdit_SearchSlipDateSt";
            this.tDateEdit_SearchSlipDateSt.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit_SearchSlipDateSt.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.tDateEdit_SearchSlipDateSt.Size = new System.Drawing.Size(176, 24);
            this.tDateEdit_SearchSlipDateSt.TabIndex = 2;
            this.tDateEdit_SearchSlipDateSt.TabStop = true;
            // 
            // tDateEdit_SearchSlipDateEd
            // 
            appearance62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tDateEdit_SearchSlipDateEd.ActiveEditAppearance = appearance62;
            this.tDateEdit_SearchSlipDateEd.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit_SearchSlipDateEd.CalendarDisp = true;
            appearance63.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance63.ForeColorDisabled = System.Drawing.Color.Black;
            appearance63.TextHAlignAsString = "Left";
            appearance63.TextVAlignAsString = "Middle";
            this.tDateEdit_SearchSlipDateEd.EditAppearance = appearance63;
            this.tDateEdit_SearchSlipDateEd.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit_SearchSlipDateEd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance64.TextHAlignAsString = "Left";
            appearance64.TextVAlignAsString = "Bottom";
            this.tDateEdit_SearchSlipDateEd.LabelAppearance = appearance64;
            this.tDateEdit_SearchSlipDateEd.Location = new System.Drawing.Point(296, 35);
            this.tDateEdit_SearchSlipDateEd.Name = "tDateEdit_SearchSlipDateEd";
            this.tDateEdit_SearchSlipDateEd.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit_SearchSlipDateEd.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.tDateEdit_SearchSlipDateEd.Size = new System.Drawing.Size(176, 24);
            this.tDateEdit_SearchSlipDateEd.TabIndex = 3;
            this.tDateEdit_SearchSlipDateEd.TabStop = true;
            // 
            // ultraLabel5
            // 
            appearance65.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance65;
            this.ultraLabel5.Location = new System.Drawing.Point(273, 35);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel5.TabIndex = 1327;
            this.ultraLabel5.Text = "～";
            // 
            // ultraLabel2
            // 
            appearance66.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance66;
            this.ultraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel2.Location = new System.Drawing.Point(12, 35);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(52, 23);
            this.ultraLabel2.TabIndex = 1326;
            this.ultraLabel2.Text = "入力日";
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
            this._Form1_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1016, 63);
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
            this._Form1_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1016, 0);
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
            ultraStatusPanel2.Key = "line1";
            ultraStatusPanel2.Visible = false;
            ultraStatusPanel2.Width = 1;
            appearance68.FontData.SizeInPoints = 9F;
            ultraStatusPanel3.Appearance = appearance68;
            ultraStatusPanel3.Key = "StatusBarPanel_FontSizeTitle";
            ultraStatusPanel3.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic;
            ultraStatusPanel3.Text = "文字サイズ";
            ultraStatusPanel3.Visible = false;
            ultraStatusPanel4.Control = this.tComboEditor_GridFontSize;
            ultraStatusPanel4.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel4.Visible = false;
            ultraStatusPanel4.Width = 40;
            ultraStatusPanel5.Key = "line2";
            ultraStatusPanel5.Width = 1;
            ultraStatusPanel6.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel6.Key = "blank1";
            ultraStatusPanel6.Width = 2;
            appearance67.FontData.SizeInPoints = 9F;
            ultraStatusPanel7.Appearance = appearance67;
            ultraStatusPanel7.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel7.Key = "StatusBarPanel_Text";
            ultraStatusPanel7.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel8.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel8.Key = "blank2";
            ultraStatusPanel8.Width = 2;
            ultraStatusPanel9.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel9.Key = "blank3";
            ultraStatusPanel9.Visible = false;
            ultraStatusPanel9.Width = 2;
            ultraStatusPanel10.Key = "StatusBarPanel_Progress";
            appearance69.ForeColor = System.Drawing.Color.Black;
            ultraStatusPanel10.ProgressBarInfo.FillAppearance = appearance69;
            ultraStatusPanel10.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Progress;
            ultraStatusPanel10.Visible = false;
            ultraStatusPanel10.Width = 150;
            ultraStatusPanel11.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel11.Key = "blank4";
            ultraStatusPanel11.Width = 1;
            appearance40.FontData.SizeInPoints = 11F;
            ultraStatusPanel12.Appearance = appearance40;
            ultraStatusPanel12.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel12.Key = "StatusBarPanel_Date";
            ultraStatusPanel12.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Date;
            ultraStatusPanel12.Width = 90;
            appearance41.FontData.SizeInPoints = 11F;
            ultraStatusPanel13.Appearance = appearance41;
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
            this.uStatusBar_Main.Size = new System.Drawing.Size(1016, 23);
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
            this._panel_SelectReflection_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1016, 0);
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
            this._panel_SelectReflection_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1016, 63);
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
            this.ultraToolbarsDockArea2.Size = new System.Drawing.Size(1016, 0);
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
            this.ultraToolbarsDockArea4.Location = new System.Drawing.Point(1016, 63);
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
            this.ultraToolbarsDockArea6.Size = new System.Drawing.Size(1016, 0);
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
            this.ultraToolbarsDockArea8.Location = new System.Drawing.Point(1016, 63);
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
            this._Form1_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1016, 63);
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
            this.ultraToolbarsDockArea1.Size = new System.Drawing.Size(1016, 0);
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
            this.ultraToolbarsDockArea9.Location = new System.Drawing.Point(1016, 63);
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
            // DCHNB04101UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 706);
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
            this.Name = "DCHNB04101UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "売上履歴照会";
            this.Load += new System.EventHandler(this.DCHNB04101UA_Load);
            this.Shown += new System.EventHandler(this.DCHNB04101UA_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DCHNB04101UA_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DCHNB04101UA_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_GridFontSize)).EndInit();
            this.Form1_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Detail_UGroupBox)).EndInit();
            this.Detail_UGroupBox.ResumeLayout(false);
            this.DetailCondtnUGroupBoxPanel.ResumeLayout(false);
            this.DetailCondtnUGroupBoxPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_AutoAnswerDivSCM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Standard_UGroupBox)).EndInit();
            this.Standard_UGroupBox.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_AddUpRemDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_FullModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SalesFormalCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SubSectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SubSectionName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_ClaimCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SalesSlipCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox_ExtractCondition3)).EndInit();
            this.groupBox_ExtractCondition3.ResumeLayout(false);
            this.groupBox_ExtractCondition3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_FrontEmployeeCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesSlipNum_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesSlipNum_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesInputCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesEmployeeCd)).EndInit();
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
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea3;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea4;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panel_SelectReflection_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panel_SelectReflection_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea2;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panel_SelectReflection_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea7;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea8;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea6;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea5;
        private Broadleaf.Library.Windows.Forms.TToolbarsManager tToolbarsManager_MainMenu;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea9;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Form1_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea1;
        private System.Windows.Forms.ToolTip toolTip1;
		private Infragistics.Win.Misc.UltraButton uButton_GoodsMakerGuide;
		private Infragistics.Win.Misc.UltraLabel uLabel_MakerName;
		private Broadleaf.Library.Windows.Forms.TNedit tNedit_GoodsMakerCd;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_GoodsName;
        private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.Misc.UltraButton SectionCodeGuide_ultraButton;
        private Broadleaf.Library.Windows.Forms.TEdit SectionName_tEdit;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_SubSectionCode;
        private Infragistics.Win.Misc.UltraButton ultraButton_SubSectionGuide;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SubSectionName;
        private Infragistics.Win.Misc.UltraLabel ultraLabel14;
        private Infragistics.Win.Misc.UltraLabel uLabel_CustomerName;
        private Infragistics.Win.Misc.UltraLabel uLabel_CustomerCodeTitle;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_CustomerCode;
        private Infragistics.Win.Misc.UltraButton uButton_StockCustomerGuide;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_ClaimCode;
        private Infragistics.Win.Misc.UltraLabel uLabel_ClaimSnm;
        private Infragistics.Win.Misc.UltraButton uButton_ClaimGuide;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_SalesSlipCd;
        private Infragistics.Win.Misc.UltraLabel uLabel_SectionNm;
        private Infragistics.Win.Misc.UltraGroupBox groupBox_ExtractCondition3;
        private Infragistics.Win.Misc.UltraLabel uLabel_Date1Title;
        private Broadleaf.Library.Windows.Forms.TDateEdit tDateEdit_SalesDateSt;
        private Broadleaf.Library.Windows.Forms.TDateEdit tDateEdit_SalesDateEd;
        private Infragistics.Win.Misc.UltraLabel ultraLabel15;
        private Broadleaf.Library.Windows.Forms.TDateEdit tDateEdit_SearchSlipDateSt;
        private Broadleaf.Library.Windows.Forms.TDateEdit tDateEdit_SearchSlipDateEd;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel12;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_FullModel;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_SalesFormalCode;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SalesSlipNum_St;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SalesSlipNum_Ed;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.Misc.UltraLabel uLabel_SalesEmployeeName;
        private Infragistics.Win.Misc.UltraLabel uLabel_StockAgentCode;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SalesInputCode;
        private Infragistics.Win.Misc.UltraButton uButton_SalesEmployeeGuide;
        private Infragistics.Win.Misc.UltraLabel uLabel_SalesInputName;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SalesEmployeeCd;
        private Infragistics.Win.Misc.UltraButton uButton_SalesInputGuide;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private Infragistics.Win.Misc.UltraLabel uLabel_FrontEmployeeName;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_FrontEmployeeCd;
        private Infragistics.Win.Misc.UltraLabel ultraLabel13;
        private Infragistics.Win.Misc.UltraButton uButton_FrontEmployeeGuide;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SectionCodeAllowZero;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_AddUpRemDiv;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor uCheckEditor_BlPaCOrder;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor uCheckEditor_PccForNS;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_AutoAnswerDivSCM;
        private Infragistics.Win.Misc.UltraLabel ultraLabel16;

	}
}


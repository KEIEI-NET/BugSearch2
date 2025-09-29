using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
	partial class PMKHN04005UA
	{
		private System.Windows.Forms.Panel Form1_Fill_Panel;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFMIT01600UA_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFMIT01600UA_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Form1_Fill_Panel_Toolbars_Dock_Area_Bottom;
		private Broadleaf.Library.Windows.Forms.TToolbarsManager Main_ToolbarsManager;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar Main_StatusBar;
        private System.Windows.Forms.Timer Initial_Timer;
		private System.Windows.Forms.Panel panel3;
		private Infragistics.Win.Misc.UltraLabel SearchResultHeader_ULabel;
        private System.Windows.Forms.Panel ExtractResult_Panel;
		private System.Data.DataSet Search_DataSet;
		private System.Windows.Forms.Timer Search_Timer;
		private Infragistics.Win.UltraWinGrid.UltraGrid SearchResult_UGrid;
        private System.Windows.Forms.Timer ColSizeChange_Timer;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN04005UA_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN04005UA_Toolbars_Dock_Area_Bottom;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN04005UA_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN04005UA_Toolbars_Dock_Area_Right;
        private System.Windows.Forms.Timer DetailView_Timer;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Timer MessageUnDisp_Timer;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ExtractResult_UStatusBar;
		private Broadleaf.Library.Windows.Forms.TComboEditor GridFontSize_TComboEditor;
		private System.ComponentModel.IContainer components;

		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel5 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel6 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("MainMenu_Toolbar");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Button_Toolbar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Close_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Search_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Select_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Close_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Tool_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Window_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool5 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("DetailView_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Close_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CustomerDelete_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Setup_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CustomerNew_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool6 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Edit_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CustomerEdit_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool5 = new Infragistics.Win.UltraWinToolbars.LabelTool("Customer_LabelTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CustomerRevival_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool7 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("DetailView_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("InnerDisp_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("DialogDisp_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("NoDisp_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("InnerDisp_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("DialogDisp_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("NoDisp_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool8 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Guide_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool6 = new Infragistics.Win.UltraWinToolbars.LabelTool("Customer_LabelTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Return_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Select_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool19 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Clear_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool20 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Search_ButtonTool");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN04005UA));
            this.GridFontSize_TComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Form1_Fill_Panel = new System.Windows.Forms.Panel();
            this.ExtractResult_Panel = new System.Windows.Forms.Panel();
            this.SearchResult_UGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SearchResultHeader_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ExtractResult_UStatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.FilterResult_Panel = new System.Windows.Forms.Panel();
            this.TEdit_Code = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TEdit_MngSectionNm = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TEdit_Snm = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TEdit_Name = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TEdit_Kana = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.Main_StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this._SFMIT01600UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Main_ToolbarsManager = new Broadleaf.Library.Windows.Forms.TToolbarsManager(this.components);
            this._SFMIT01600UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Form1_Fill_Panel_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMKHN04005UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMKHN04005UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMKHN04005UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMKHN04005UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Search_DataSet = new System.Data.DataSet();
            this.Search_Timer = new System.Windows.Forms.Timer(this.components);
            this.ColSizeChange_Timer = new System.Windows.Forms.Timer(this.components);
            this.DetailView_Timer = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.MessageUnDisp_Timer = new System.Windows.Forms.Timer(this.components);
            this.uToolTipManager_Information = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GridFontSize_TComboEditor)).BeginInit();
            this.Form1_Fill_Panel.SuspendLayout();
            this.ExtractResult_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchResult_UGrid)).BeginInit();
            this.panel3.SuspendLayout();
            this.ExtractResult_UStatusBar.SuspendLayout();
            this.FilterResult_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TEdit_Code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEdit_MngSectionNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEdit_Snm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEdit_Name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEdit_Kana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Search_DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // GridFontSize_TComboEditor
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GridFontSize_TComboEditor.ActiveAppearance = appearance1;
            this.GridFontSize_TComboEditor.AutoSize = false;
            this.GridFontSize_TComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.GridFontSize_TComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GridFontSize_TComboEditor.ItemAppearance = appearance2;
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
            this.GridFontSize_TComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3,
            valueListItem4,
            valueListItem5,
            valueListItem6,
            valueListItem7});
            this.GridFontSize_TComboEditor.Location = new System.Drawing.Point(70, 2);
            this.GridFontSize_TComboEditor.Name = "GridFontSize_TComboEditor";
            this.GridFontSize_TComboEditor.Size = new System.Drawing.Size(40, 19);
            this.GridFontSize_TComboEditor.TabIndex = 0;
            this.GridFontSize_TComboEditor.TabStop = false;
            this.GridFontSize_TComboEditor.ValueChanged += new System.EventHandler(this.GridFontSize_TComboEditor_ValueChanged);
            // 
            // Form1_Fill_Panel
            // 
            this.Form1_Fill_Panel.Controls.Add(this.ExtractResult_Panel);
            this.Form1_Fill_Panel.Controls.Add(this.FilterResult_Panel);
            this.Form1_Fill_Panel.Controls.Add(this.Main_StatusBar);
            this.Form1_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.Form1_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Form1_Fill_Panel.Location = new System.Drawing.Point(0, 63);
            this.Form1_Fill_Panel.Name = "Form1_Fill_Panel";
            this.Form1_Fill_Panel.Size = new System.Drawing.Size(672, 503);
            this.Form1_Fill_Panel.TabIndex = 0;
            // 
            // ExtractResult_Panel
            // 
            this.ExtractResult_Panel.Controls.Add(this.SearchResult_UGrid);
            this.ExtractResult_Panel.Controls.Add(this.panel3);
            this.ExtractResult_Panel.Controls.Add(this.ExtractResult_UStatusBar);
            this.ExtractResult_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExtractResult_Panel.Location = new System.Drawing.Point(0, 163);
            this.ExtractResult_Panel.Name = "ExtractResult_Panel";
            this.ExtractResult_Panel.Size = new System.Drawing.Size(672, 317);
            this.ExtractResult_Panel.TabIndex = 136;
            // 
            // SearchResult_UGrid
            // 
            appearance36.BackColor = System.Drawing.Color.White;
            appearance36.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance36.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.SearchResult_UGrid.DisplayLayout.Appearance = appearance36;
            this.SearchResult_UGrid.DisplayLayout.GroupByBox.Hidden = true;
            this.SearchResult_UGrid.DisplayLayout.InterBandSpacing = 10;
            this.SearchResult_UGrid.DisplayLayout.MaxColScrollRegions = 1;
            appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.SearchResult_UGrid.DisplayLayout.Override.ActiveCellAppearance = appearance37;
            this.SearchResult_UGrid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.SearchResult_UGrid.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.WithinBand;
            this.SearchResult_UGrid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.SearchResult_UGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.SearchResult_UGrid.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.SearchResult_UGrid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.SearchResult_UGrid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
            appearance38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance38.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance38.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance38.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance38.ForeColor = System.Drawing.Color.White;
            appearance38.TextHAlignAsString = "Center";
            appearance38.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.SearchResult_UGrid.DisplayLayout.Override.HeaderAppearance = appearance38;
            this.SearchResult_UGrid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance39.BackColor = System.Drawing.Color.Lavender;
            this.SearchResult_UGrid.DisplayLayout.Override.RowAlternateAppearance = appearance39;
            appearance40.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            appearance40.TextVAlignAsString = "Middle";
            this.SearchResult_UGrid.DisplayLayout.Override.RowAppearance = appearance40;
            this.SearchResult_UGrid.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.SearchResult_UGrid.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance41.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance41.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance41.ForeColor = System.Drawing.Color.White;
            this.SearchResult_UGrid.DisplayLayout.Override.RowSelectorAppearance = appearance41;
            this.SearchResult_UGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.SearchResult_UGrid.DisplayLayout.Override.RowSelectorWidth = 12;
            this.SearchResult_UGrid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance42.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance42.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance42.ForeColor = System.Drawing.Color.Black;
            this.SearchResult_UGrid.DisplayLayout.Override.SelectedRowAppearance = appearance42;
            this.SearchResult_UGrid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.SearchResult_UGrid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.SearchResult_UGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.SearchResult_UGrid.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.SearchResult_UGrid.DisplayLayout.Override.TipStyleRowConnector = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.SearchResult_UGrid.DisplayLayout.Override.TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.SearchResult_UGrid.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.SearchResult_UGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.SearchResult_UGrid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.SearchResult_UGrid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.SearchResult_UGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchResult_UGrid.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SearchResult_UGrid.Location = new System.Drawing.Point(0, 28);
            this.SearchResult_UGrid.Name = "SearchResult_UGrid";
            this.SearchResult_UGrid.Size = new System.Drawing.Size(672, 266);
            this.SearchResult_UGrid.TabIndex = 2;
            this.SearchResult_UGrid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchResult_UGrid_KeyUp);
            this.SearchResult_UGrid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SearchResult_UGrid_MouseUp);
            this.SearchResult_UGrid.MouseLeaveElement += new Infragistics.Win.UIElementEventHandler(this.SearchResult_UGrid_MouseLeaveElement);
            this.SearchResult_UGrid.Enter += new System.EventHandler(this.SearchResult_UGrid_Enter);
            this.SearchResult_UGrid.AfterRowActivate += new System.EventHandler(this.SearchResult_UGrid_AfterRowActivate);
            this.SearchResult_UGrid.DoubleClick += new System.EventHandler(this.SearchResult_UGrid_DoubleClick);
            this.SearchResult_UGrid.MouseEnterElement += new Infragistics.Win.UIElementEventHandler(this.SearchResult_UGrid_MouseEnterElement);
            this.SearchResult_UGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchResult_UGrid_KeyDown);
            this.SearchResult_UGrid.AfterCellActivate += new System.EventHandler(this.SearchResult_UGrid_AfterCellActivate);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.panel3.Controls.Add(this.SearchResultHeader_ULabel);
            this.panel3.Controls.Add(this.ultraLabel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(672, 28);
            this.panel3.TabIndex = 0;
            // 
            // SearchResultHeader_ULabel
            // 
            this.SearchResultHeader_ULabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance43.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            appearance43.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance43.ForeColor = System.Drawing.Color.White;
            appearance43.TextHAlignAsString = "Left";
            appearance43.TextVAlignAsString = "Middle";
            this.SearchResultHeader_ULabel.Appearance = appearance43;
            this.SearchResultHeader_ULabel.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
            this.SearchResultHeader_ULabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SearchResultHeader_ULabel.Location = new System.Drawing.Point(1, 1);
            this.SearchResultHeader_ULabel.Name = "SearchResultHeader_ULabel";
            this.SearchResultHeader_ULabel.Size = new System.Drawing.Size(670, 27);
            this.SearchResultHeader_ULabel.TabIndex = 1;
            this.SearchResultHeader_ULabel.Text = "抽出結果";
            // 
            // ultraLabel1
            // 
            appearance44.TextHAlignAsString = "Left";
            appearance44.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance44;
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.Black;
            this.ultraLabel1.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel1.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(672, 28);
            this.ultraLabel1.TabIndex = 2;
            // 
            // ExtractResult_UStatusBar
            // 
            this.ExtractResult_UStatusBar.Controls.Add(this.GridFontSize_TComboEditor);
            this.ExtractResult_UStatusBar.Location = new System.Drawing.Point(0, 294);
            this.ExtractResult_UStatusBar.Name = "ExtractResult_UStatusBar";
            this.ExtractResult_UStatusBar.Padding = new Infragistics.Win.UltraWinStatusBar.UIElementMargins(0, 1, 0, 0);
            appearance45.FontData.SizeInPoints = 9F;
            ultraStatusPanel1.Appearance = appearance45;
            ultraStatusPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel1.Key = "StatusBarPanel_Text";
            ultraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic;
            ultraStatusPanel1.Text = "文字サイズ";
            ultraStatusPanel2.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel2.Control = this.GridFontSize_TComboEditor;
            ultraStatusPanel2.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel2.Width = 40;
            this.ExtractResult_UStatusBar.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2});
            this.ExtractResult_UStatusBar.Size = new System.Drawing.Size(672, 23);
            this.ExtractResult_UStatusBar.TabIndex = 15;
            this.ExtractResult_UStatusBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // FilterResult_Panel
            // 
            this.FilterResult_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(215)))), ((int)(((byte)(249)))));
            this.FilterResult_Panel.Controls.Add(this.TEdit_Code);
            this.FilterResult_Panel.Controls.Add(this.TEdit_MngSectionNm);
            this.FilterResult_Panel.Controls.Add(this.TEdit_Snm);
            this.FilterResult_Panel.Controls.Add(this.TEdit_Name);
            this.FilterResult_Panel.Controls.Add(this.TEdit_Kana);
            this.FilterResult_Panel.Controls.Add(this.ultraLabel6);
            this.FilterResult_Panel.Controls.Add(this.ultraLabel5);
            this.FilterResult_Panel.Controls.Add(this.ultraLabel4);
            this.FilterResult_Panel.Controls.Add(this.ultraLabel3);
            this.FilterResult_Panel.Controls.Add(this.ultraLabel2);
            this.FilterResult_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FilterResult_Panel.Location = new System.Drawing.Point(0, 0);
            this.FilterResult_Panel.Name = "FilterResult_Panel";
            this.FilterResult_Panel.Size = new System.Drawing.Size(672, 163);
            this.FilterResult_Panel.TabIndex = 137;
            // 
            // TEdit_Code
            // 
            appearance78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance78.TextHAlignAsString = "Right";
            this.TEdit_Code.ActiveAppearance = appearance78;
            appearance79.TextHAlignAsString = "Right";
            this.TEdit_Code.Appearance = appearance79;
            this.TEdit_Code.AutoSelect = true;
            this.TEdit_Code.CalcSize = new System.Drawing.Size(172, 200);
            this.TEdit_Code.DataText = "";
            this.TEdit_Code.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TEdit_Code.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.TEdit_Code.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TEdit_Code.Location = new System.Drawing.Point(186, 98);
            this.TEdit_Code.MaxLength = 8;
            this.TEdit_Code.Name = "TEdit_Code";
            this.TEdit_Code.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.TEdit_Code.Size = new System.Drawing.Size(189, 24);
            this.TEdit_Code.TabIndex = 8;
            // 
            // TEdit_MngSectionNm
            // 
            appearance27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.TEdit_MngSectionNm.ActiveAppearance = appearance27;
            appearance28.TextHAlignAsString = "Left";
            this.TEdit_MngSectionNm.Appearance = appearance28;
            this.TEdit_MngSectionNm.AutoSelect = true;
            this.TEdit_MngSectionNm.DataText = "";
            this.TEdit_MngSectionNm.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TEdit_MngSectionNm.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.TEdit_MngSectionNm.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TEdit_MngSectionNm.Location = new System.Drawing.Point(186, 126);
            this.TEdit_MngSectionNm.MaxLength = 2;
            this.TEdit_MngSectionNm.Name = "TEdit_MngSectionNm";
            this.TEdit_MngSectionNm.Size = new System.Drawing.Size(189, 24);
            this.TEdit_MngSectionNm.TabIndex = 9;
            // 
            // TEdit_Snm
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.TEdit_Snm.ActiveAppearance = appearance7;
            appearance8.TextHAlignAsString = "Left";
            this.TEdit_Snm.Appearance = appearance8;
            this.TEdit_Snm.AutoSelect = true;
            this.TEdit_Snm.DataText = "";
            this.TEdit_Snm.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TEdit_Snm.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.TEdit_Snm.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.TEdit_Snm.Location = new System.Drawing.Point(186, 68);
            this.TEdit_Snm.MaxLength = 20;
            this.TEdit_Snm.Name = "TEdit_Snm";
            this.TEdit_Snm.Size = new System.Drawing.Size(189, 24);
            this.TEdit_Snm.TabIndex = 7;
            // 
            // TEdit_Name
            // 
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.TEdit_Name.ActiveAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.TEdit_Name.Appearance = appearance10;
            this.TEdit_Name.AutoSelect = true;
            this.TEdit_Name.DataText = "";
            this.TEdit_Name.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TEdit_Name.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.TEdit_Name.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.TEdit_Name.Location = new System.Drawing.Point(186, 39);
            this.TEdit_Name.MaxLength = 30;
            this.TEdit_Name.Name = "TEdit_Name";
            this.TEdit_Name.Size = new System.Drawing.Size(189, 24);
            this.TEdit_Name.TabIndex = 6;
            // 
            // TEdit_Kana
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.TEdit_Kana.ActiveAppearance = appearance3;
            appearance4.TextHAlignAsString = "Left";
            this.TEdit_Kana.Appearance = appearance4;
            this.TEdit_Kana.AutoSelect = true;
            this.TEdit_Kana.DataText = "";
            this.TEdit_Kana.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TEdit_Kana.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
            this.TEdit_Kana.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.TEdit_Kana.Location = new System.Drawing.Point(186, 10);
            this.TEdit_Kana.MaxLength = 30;
            this.TEdit_Kana.Name = "TEdit_Kana";
            this.TEdit_Kana.Size = new System.Drawing.Size(189, 24);
            this.TEdit_Kana.TabIndex = 5;
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.Location = new System.Drawing.Point(22, 127);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(145, 23);
            this.ultraLabel6.TabIndex = 4;
            this.ultraLabel6.Text = "管理拠点";
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.Location = new System.Drawing.Point(22, 98);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(145, 23);
            this.ultraLabel5.TabIndex = 3;
            this.ultraLabel5.Text = "開始コード";
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Location = new System.Drawing.Point(22, 69);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(145, 23);
            this.ultraLabel4.TabIndex = 2;
            this.ultraLabel4.Text = "絞込名称（略称）";
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(22, 40);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(145, 23);
            this.ultraLabel3.TabIndex = 1;
            this.ultraLabel3.Text = "絞込名称";
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Location = new System.Drawing.Point(22, 11);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(145, 23);
            this.ultraLabel2.TabIndex = 0;
            this.ultraLabel2.Text = "絞込名称（ｶﾅ）";
            // 
            // Main_StatusBar
            // 
            this.Main_StatusBar.Location = new System.Drawing.Point(0, 480);
            this.Main_StatusBar.Name = "Main_StatusBar";
            appearance47.FontData.SizeInPoints = 9F;
            ultraStatusPanel3.Appearance = appearance47;
            ultraStatusPanel3.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel3.Key = "StatusBarPanel_Text";
            ultraStatusPanel3.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel4.Key = "StatusBarPanel_Progress";
            appearance48.ForeColor = System.Drawing.Color.Black;
            ultraStatusPanel4.ProgressBarInfo.FillAppearance = appearance48;
            ultraStatusPanel4.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Progress;
            ultraStatusPanel4.Width = 150;
            ultraStatusPanel5.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel5.Key = "StatusBarPanel_Date";
            ultraStatusPanel5.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Date;
            ultraStatusPanel5.Width = 90;
            ultraStatusPanel6.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel6.Key = "StatusBarPanel_Time";
            ultraStatusPanel6.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Time;
            ultraStatusPanel6.Width = 50;
            this.Main_StatusBar.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel3,
            ultraStatusPanel4,
            ultraStatusPanel5,
            ultraStatusPanel6});
            this.Main_StatusBar.Size = new System.Drawing.Size(672, 23);
            this.Main_StatusBar.TabIndex = 14;
            this.Main_StatusBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // _SFMIT01600UA_Toolbars_Dock_Area_Left
            // 
            this._SFMIT01600UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFMIT01600UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFMIT01600UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._SFMIT01600UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFMIT01600UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 63);
            this._SFMIT01600UA_Toolbars_Dock_Area_Left.Name = "_SFMIT01600UA_Toolbars_Dock_Area_Left";
            this._SFMIT01600UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 503);
            this._SFMIT01600UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // Main_ToolbarsManager
            // 
            this.Main_ToolbarsManager.DesignerFlags = 1;
            this.Main_ToolbarsManager.DockWithinContainer = this;
            this.Main_ToolbarsManager.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.Main_ToolbarsManager.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.Main_ToolbarsManager.ShowFullMenusDelay = 500;
            this.Main_ToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.IsMainMenuBar = true;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1,
            labelTool1});
            ultraToolbar1.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.ShowInToolbarList = false;
            ultraToolbar1.Text = "メインメニュー";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 1;
            buttonTool2.InstanceProps.IsFirstInGroup = true;
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3});
            ultraToolbar2.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar2.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar2.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.BelowImage;
            ultraToolbar2.Text = "標準";
            this.Main_ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2});
            this.Main_ToolbarsManager.ToolbarSettings.FillEntireRow = Infragistics.Win.DefaultableBoolean.False;
            popupMenuTool2.SharedProps.Caption = "ファイル(&F)";
            popupMenuTool2.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            buttonTool4.InstanceProps.IsFirstInGroup = true;
            popupMenuTool2.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool4});
            popupMenuTool3.SharedProps.Caption = "ツール(&T)";
            popupMenuTool3.SharedProps.MergeOrder = 3;
            popupMenuTool4.SharedProps.Caption = "ウィンドウ(&W)";
            popupMenuTool4.SharedProps.MergeOrder = 4;
            popupMenuTool5.InstanceProps.IsFirstInGroup = true;
            popupMenuTool4.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool5});
            labelTool2.SharedProps.MergeOrder = 80;
            labelTool2.SharedProps.Spring = true;
            labelTool3.SharedProps.Caption = "ログイン担当者";
            labelTool3.SharedProps.MergeOrder = 98;
            labelTool3.SharedProps.ShowInCustomizer = false;
            appearance49.BackColor = System.Drawing.Color.White;
            appearance49.TextHAlignAsString = "Left";
            labelTool4.SharedProps.AppearancesSmall.Appearance = appearance49;
            labelTool4.SharedProps.Caption = "翼　太郎";
            labelTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            labelTool4.SharedProps.MergeOrder = 99;
            labelTool4.SharedProps.ShowInCustomizer = false;
            labelTool4.SharedProps.Width = 150;
            buttonTool5.SharedProps.Caption = "閉じる(&X)";
            buttonTool5.SharedProps.CustomizerCaption = "閉じるボタン";
            buttonTool5.SharedProps.CustomizerDescription = "閉じるボタン";
            buttonTool5.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool5.SharedProps.MergeOrder = 1;
            buttonTool5.SharedProps.ToolTipText = "得意先画面を閉じます。";
            buttonTool6.SharedProps.Caption = "削除(&D)";
            buttonTool6.SharedProps.CustomizerCaption = "削除ボタン";
            buttonTool6.SharedProps.CustomizerDescription = "削除ボタン";
            buttonTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool6.SharedProps.MergeOrder = 6;
            buttonTool6.SharedProps.ToolTipText = "選択中の得意先を削除します。";
            buttonTool7.SharedProps.Caption = "設定(&O)";
            buttonTool7.SharedProps.CustomizerCaption = "設定ボタン";
            buttonTool7.SharedProps.CustomizerDescription = "設定ボタン";
            buttonTool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool7.SharedProps.MergeOrder = 50;
            buttonTool7.SharedProps.ToolTipText = "ユーザー設定画面を表示します。";
            buttonTool8.SharedProps.Caption = "新規(&N)";
            buttonTool8.SharedProps.CustomizerCaption = "新規ボタン";
            buttonTool8.SharedProps.CustomizerDescription = "新規ボタン";
            buttonTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool8.SharedProps.MergeOrder = 4;
            buttonTool8.SharedProps.ToolTipText = "新規に得意先情報を入力します。";
            popupMenuTool6.SharedProps.Caption = "編集(&E)";
            popupMenuTool6.SharedProps.CustomizerCaption = "編集";
            popupMenuTool6.SharedProps.CustomizerDescription = "編集";
            buttonTool9.SharedProps.Caption = "編集(&E)";
            buttonTool9.SharedProps.CustomizerCaption = "編集ボタン";
            buttonTool9.SharedProps.CustomizerDescription = "編集ボタン";
            buttonTool9.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool9.SharedProps.MergeOrder = 5;
            buttonTool9.SharedProps.ToolTipText = "選択中の得意先を編集します。";
            labelTool5.SharedProps.Caption = "【得意先】";
            labelTool5.SharedProps.CustomizerCaption = "得意先";
            labelTool5.SharedProps.CustomizerDescription = "得意先";
            labelTool5.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            labelTool5.SharedProps.MergeOrder = 3;
            buttonTool10.SharedProps.Caption = "復元";
            buttonTool10.SharedProps.CustomizerCaption = "得意先復元ボタン";
            buttonTool10.SharedProps.CustomizerDescription = "得意先復元ボタン";
            buttonTool10.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool10.SharedProps.MergeOrder = 8;
            buttonTool10.SharedProps.ToolTipText = "選択中の削除済み得意先情報を復元します。";
            popupMenuTool7.SharedProps.Caption = "詳細表示";
            popupMenuTool7.SharedProps.CustomizerCaption = "詳細表示";
            popupMenuTool7.SharedProps.CustomizerDescription = "詳細表示";
            popupMenuTool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            popupMenuTool7.SharedProps.MergeOrder = 18;
            popupMenuTool7.SharedProps.ToolTipText = "得意先・車両の詳細を表示します。";
            popupMenuTool7.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool11,
            buttonTool12,
            buttonTool13});
            buttonTool14.SharedProps.Caption = "抽出結果ウィンドウ内で表示する";
            buttonTool14.SharedProps.CustomizerCaption = "抽出結果ウィンドウ内で表示する";
            buttonTool14.SharedProps.CustomizerDescription = "抽出結果ウィンドウ内で表示する";
            buttonTool14.SharedProps.ToolTipText = "詳細情報を抽出結果ウィンドウ内で表示します。";
            buttonTool15.SharedProps.Caption = "別ウィンドウで表示する";
            buttonTool15.SharedProps.CustomizerCaption = "別ウィンドウで表示する";
            buttonTool15.SharedProps.CustomizerDescription = "別ウィンドウで表示する";
            buttonTool15.SharedProps.ToolTipText = "詳細情報を別ウィンドウで表示します。";
            buttonTool16.SharedProps.Caption = "表示しない";
            buttonTool16.SharedProps.CustomizerCaption = "表示しない";
            buttonTool16.SharedProps.CustomizerDescription = "表示しない";
            buttonTool16.SharedProps.ToolTipText = "詳細情報を表示しません。";
            popupMenuTool8.SharedProps.Caption = "ガイド(&G)";
            popupMenuTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            popupMenuTool8.SharedProps.MergeOrder = 2;
            popupMenuTool8.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            labelTool6});
            buttonTool17.SharedProps.Caption = "戻る(&B)";
            buttonTool17.SharedProps.CustomizerCaption = "戻るボタン";
            buttonTool17.SharedProps.CustomizerDescription = "戻るボタン";
            buttonTool17.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool17.SharedProps.ToolTipText = "一つ前の抽出条件に戻します。";
            buttonTool18.SharedProps.Caption = "選択(&S)";
            buttonTool18.SharedProps.CustomizerCaption = "選択ボタン";
            buttonTool18.SharedProps.CustomizerDescription = "選択ボタン";
            buttonTool18.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool18.SharedProps.ToolTipText = "グリッドにて選択中の得意先情報を呼び元に渡します。";
            buttonTool19.SharedProps.Caption = "取消(&C)";
            buttonTool19.SharedProps.CustomizerCaption = "取消ボタン";
            buttonTool19.SharedProps.CustomizerDescription = "取消ボタン";
            buttonTool19.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool19.SharedProps.ToolTipText = "画面を初期化します。";
            buttonTool20.SharedProps.Caption = "検索(&R)";
            buttonTool20.SharedProps.CustomizerCaption = "検索ボタン";
            buttonTool20.SharedProps.CustomizerDescription = "検索ボタン";
            buttonTool20.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool20.SharedProps.ToolTipText = "得意先情報を検索します。";
            buttonTool20.SharedProps.Visible = false;
            this.Main_ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool2,
            popupMenuTool3,
            popupMenuTool4,
            labelTool2,
            labelTool3,
            labelTool4,
            buttonTool5,
            buttonTool6,
            buttonTool7,
            buttonTool8,
            popupMenuTool6,
            buttonTool9,
            labelTool5,
            buttonTool10,
            popupMenuTool7,
            buttonTool14,
            buttonTool15,
            buttonTool16,
            popupMenuTool8,
            buttonTool17,
            buttonTool18,
            buttonTool19,
            buttonTool20});
            this.Main_ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.Main_ToolbarsManager_ToolClick);
            // 
            // _SFMIT01600UA_Toolbars_Dock_Area_Right
            // 
            this._SFMIT01600UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFMIT01600UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFMIT01600UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._SFMIT01600UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFMIT01600UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(672, 63);
            this._SFMIT01600UA_Toolbars_Dock_Area_Right.Name = "_SFMIT01600UA_Toolbars_Dock_Area_Right";
            this._SFMIT01600UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 503);
            this._SFMIT01600UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _Form1_Fill_Panel_Toolbars_Dock_Area_Bottom
            // 
            this._Form1_Fill_Panel_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._Form1_Fill_Panel_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._Form1_Fill_Panel_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._Form1_Fill_Panel_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Form1_Fill_Panel_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 0);
            this._Form1_Fill_Panel_Toolbars_Dock_Area_Bottom.Name = "_Form1_Fill_Panel_Toolbars_Dock_Area_Bottom";
            this._Form1_Fill_Panel_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(0, 0);
            // 
            // _PMKHN04005UA_Toolbars_Dock_Area_Top
            // 
            this._PMKHN04005UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN04005UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN04005UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._PMKHN04005UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN04005UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._PMKHN04005UA_Toolbars_Dock_Area_Top.Name = "_PMKHN04005UA_Toolbars_Dock_Area_Top";
            this._PMKHN04005UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(672, 63);
            this._PMKHN04005UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _PMKHN04005UA_Toolbars_Dock_Area_Bottom
            // 
            this._PMKHN04005UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN04005UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN04005UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._PMKHN04005UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN04005UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 566);
            this._PMKHN04005UA_Toolbars_Dock_Area_Bottom.Name = "_PMKHN04005UA_Toolbars_Dock_Area_Bottom";
            this._PMKHN04005UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(672, 0);
            this._PMKHN04005UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _PMKHN04005UA_Toolbars_Dock_Area_Left
            // 
            this._PMKHN04005UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN04005UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN04005UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._PMKHN04005UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN04005UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 63);
            this._PMKHN04005UA_Toolbars_Dock_Area_Left.Name = "_PMKHN04005UA_Toolbars_Dock_Area_Left";
            this._PMKHN04005UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 503);
            this._PMKHN04005UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _PMKHN04005UA_Toolbars_Dock_Area_Right
            // 
            this._PMKHN04005UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN04005UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN04005UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._PMKHN04005UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN04005UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(672, 63);
            this._PMKHN04005UA_Toolbars_Dock_Area_Right.Name = "_PMKHN04005UA_Toolbars_Dock_Area_Right";
            this._PMKHN04005UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 503);
            this._PMKHN04005UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // Search_DataSet
            // 
            this.Search_DataSet.DataSetName = "NewDataSet";
            this.Search_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // Search_Timer
            // 
            this.Search_Timer.Interval = 1;
            this.Search_Timer.Tick += new System.EventHandler(this.Search_Timer_Tick);
            // 
            // ColSizeChange_Timer
            // 
            this.ColSizeChange_Timer.Interval = 1;
            this.ColSizeChange_Timer.Tick += new System.EventHandler(this.ColSizeChange_Timer_Tick);
            // 
            // DetailView_Timer
            // 
            this.DetailView_Timer.Interval = 1;
            this.DetailView_Timer.Tick += new System.EventHandler(this.DetailView_Timer_Tick);
            // 
            // MessageUnDisp_Timer
            // 
            this.MessageUnDisp_Timer.Interval = 5000;
            this.MessageUnDisp_Timer.Tick += new System.EventHandler(this.MessageUnDisp_Timer_Tick);
            // 
            // uToolTipManager_Information
            // 
            this.uToolTipManager_Information.AutoPopDelay = 20000;
            this.uToolTipManager_Information.ContainingControl = this;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
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
            // PMKHN04005UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.ClientSize = new System.Drawing.Size(672, 566);
            this.Controls.Add(this.Form1_Fill_Panel);
            this.Controls.Add(this._PMKHN04005UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._SFMIT01600UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._SFMIT01600UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._PMKHN04005UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._PMKHN04005UA_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._PMKHN04005UA_Toolbars_Dock_Area_Bottom);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "PMKHN04005UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "得意先検索";
            this.Load += new System.EventHandler(this.PMKHN04005UA_Load);
            this.Shown += new System.EventHandler(this.PMKHN04005UA_Shown);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMKHN04005UA_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PMKHN04005UA_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GridFontSize_TComboEditor)).EndInit();
            this.Form1_Fill_Panel.ResumeLayout(false);
            this.ExtractResult_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SearchResult_UGrid)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ExtractResult_UStatusBar.ResumeLayout(false);
            this.FilterResult_Panel.ResumeLayout(false);
            this.FilterResult_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TEdit_Code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEdit_MngSectionNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEdit_Snm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEdit_Name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TEdit_Kana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Search_DataSet)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager uToolTipManager_Information;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
        private System.Windows.Forms.Panel FilterResult_Panel;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Broadleaf.Library.Windows.Forms.TEdit TEdit_MngSectionNm;
        private Broadleaf.Library.Windows.Forms.TEdit TEdit_Snm;
        private Broadleaf.Library.Windows.Forms.TEdit TEdit_Name;
        private Broadleaf.Library.Windows.Forms.TEdit TEdit_Kana;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TNedit TEdit_Code;
	}
}

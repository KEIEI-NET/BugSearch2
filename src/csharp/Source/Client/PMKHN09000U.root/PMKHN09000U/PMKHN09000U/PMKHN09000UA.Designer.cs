using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
	partial class PMKHN09000UA
	{
		private System.Windows.Forms.Panel Form1_Fill_Panel;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFMIT01600UA_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFMIT01600UA_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _Form1_Fill_Panel_Toolbars_Dock_Area_Bottom;
        private Broadleaf.Library.Windows.Forms.TToolbarsManager Main_ToolbarsManager;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar Main_StatusBar;
		private System.Windows.Forms.Timer Initial_Timer;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN09000UA_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN09000UA_Toolbars_Dock_Area_Bottom;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN09000UA_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN09000UA_Toolbars_Dock_Area_Right;
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
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("MainMenu_Toolbar");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Tool_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Window_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Button_Toolbar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Close_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Save_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("New_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Guide_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Delete_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CompleteDelete_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Revive_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Retry_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Renewal_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Edit_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Setup_ButtonTool");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar3 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Button2_Toolbar");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar4 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("KindInfoInput_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Save_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("New_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Delete_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Retry_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Renewal_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Edit_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Close_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool5 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Tool_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool19 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Setup_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool6 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Window_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool5 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool6 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool20 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Close_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool21 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Save_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool22 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Retry_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool23 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Setup_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool24 = new Infragistics.Win.UltraWinToolbars.ButtonTool("New_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool7 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Edit_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool25 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Delete_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool26 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Edit_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool27 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Memo_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool7 = new Infragistics.Win.UltraWinToolbars.LabelTool("SectionTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboBoxTool1 = new Infragistics.Win.UltraWinToolbars.ComboBoxTool("SectionCode_ComboBoxTool");
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(0);
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool28 = new Infragistics.Win.UltraWinToolbars.ButtonTool("OfflineDataOutput_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool29 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CustSuppli_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool1 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("SectionCode_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool8 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("AddInfo_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool9 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Guide_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool30 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Search_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool31 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Reflect_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool32 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Revive_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool33 = new Infragistics.Win.UltraWinToolbars.ButtonTool("CompleteDelete_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool34 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Renewal_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool35 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Guide_ButtonTool");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09000UA));
            this.SectionCode_TComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Form1_Fill_Panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Main_StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this._SFMIT01600UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Main_ToolbarsManager = new Broadleaf.Library.Windows.Forms.TToolbarsManager(this.components);
            this._SFMIT01600UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._Form1_Fill_Panel_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this._PMKHN09000UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMKHN09000UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMKHN09000UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMKHN09000UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode_TComboEditor)).BeginInit();
            this.Form1_Fill_Panel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).BeginInit();
            this.SuspendLayout();
            // 
            // SectionCode_TComboEditor
            // 
            this.SectionCode_TComboEditor.ActiveAppearance = appearance1;
            this.SectionCode_TComboEditor.AutoSize = false;
            this.SectionCode_TComboEditor.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
            this.SectionCode_TComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.SectionCode_TComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SectionCode_TComboEditor.Location = new System.Drawing.Point(36, 18);
            this.SectionCode_TComboEditor.Name = "SectionCode_TComboEditor";
            this.SectionCode_TComboEditor.Size = new System.Drawing.Size(112, 21);
            this.SectionCode_TComboEditor.TabIndex = 0;
            this.SectionCode_TComboEditor.TabStop = false;
            this.SectionCode_TComboEditor.SelectionChangeCommitted += new System.EventHandler(this.SectionCode_TComboEditor_SelectionChangeCommitted);
            // 
            // Form1_Fill_Panel
            // 
            this.Form1_Fill_Panel.Controls.Add(this.panel1);
            this.Form1_Fill_Panel.Controls.Add(this.Main_StatusBar);
            this.Form1_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.Form1_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Form1_Fill_Panel.Location = new System.Drawing.Point(0, 63);
            this.Form1_Fill_Panel.Name = "Form1_Fill_Panel";
            this.Form1_Fill_Panel.Size = new System.Drawing.Size(1022, 671);
            this.Form1_Fill_Panel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SectionCode_TComboEditor);
            this.panel1.Location = new System.Drawing.Point(366, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 1;
            this.panel1.Visible = false;
            // 
            // Main_StatusBar
            // 
            this.Main_StatusBar.Location = new System.Drawing.Point(0, 648);
            this.Main_StatusBar.Name = "Main_StatusBar";
            appearance3.FontData.SizeInPoints = 9F;
            ultraStatusPanel1.Appearance = appearance3;
            ultraStatusPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel1.Key = "StatusBarPanel_Text";
            ultraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel2.Key = "StatusBarPanel_Progress";
            appearance4.ForeColor = System.Drawing.Color.Black;
            ultraStatusPanel2.ProgressBarInfo.FillAppearance = appearance4;
            ultraStatusPanel2.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Progress;
            ultraStatusPanel2.Width = 150;
            ultraStatusPanel3.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel3.Key = "StatusBarPanel_Date";
            ultraStatusPanel3.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Date;
            ultraStatusPanel3.Width = 90;
            ultraStatusPanel4.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel4.Key = "StatusBarPanel_Time";
            ultraStatusPanel4.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Time;
            ultraStatusPanel4.Width = 50;
            this.Main_StatusBar.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3,
            ultraStatusPanel4});
            this.Main_StatusBar.Size = new System.Drawing.Size(1022, 23);
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
            this._SFMIT01600UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 671);
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
            labelTool2.InstanceProps.IsFirstInGroup = true;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1,
            popupMenuTool2,
            popupMenuTool3,
            labelTool1,
            labelTool2,
            labelTool3});
            ultraToolbar1.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.ShowInToolbarList = false;
            ultraToolbar1.Text = "メインメニュー";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 1;
            buttonTool1.InstanceProps.IsFirstInGroup = true;
            buttonTool2.InstanceProps.IsFirstInGroup = true;
            buttonTool10.InstanceProps.IsFirstInGroup = true;
            buttonTool11.InstanceProps.IsFirstInGroup = true;
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            buttonTool4,
            buttonTool5,
            buttonTool6,
            buttonTool7,
            buttonTool8,
            buttonTool9,
            buttonTool10,
            buttonTool11});
            ultraToolbar2.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar2.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar2.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.BelowImage;
            ultraToolbar2.Text = "標準";
            ultraToolbar3.DockedColumn = 0;
            ultraToolbar3.DockedRow = 2;
            ultraToolbar3.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar3.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar3.Text = "サブ画面入力";
            ultraToolbar3.Visible = false;
            ultraToolbar4.DockedColumn = 0;
            ultraToolbar4.DockedRow = 2;
            ultraToolbar4.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar4.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar4.Text = "種別情報入力";
            ultraToolbar4.Visible = false;
            this.Main_ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2,
            ultraToolbar3,
            ultraToolbar4});
            this.Main_ToolbarsManager.ToolbarSettings.FillEntireRow = Infragistics.Win.DefaultableBoolean.False;
            popupMenuTool4.SharedProps.Caption = "ファイル(&F)";
            popupMenuTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            buttonTool18.InstanceProps.IsFirstInGroup = true;
            popupMenuTool4.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool12,
            buttonTool13,
            buttonTool14,
            buttonTool15,
            buttonTool16,
            buttonTool17,
            buttonTool18});
            popupMenuTool5.SharedProps.Caption = "ツール(&T)";
            popupMenuTool5.SharedProps.MergeOrder = 3;
            buttonTool19.InstanceProps.IsFirstInGroup = true;
            popupMenuTool5.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool19});
            popupMenuTool6.SharedProps.Caption = "ウィンドウ(&W)";
            popupMenuTool6.SharedProps.MergeOrder = 4;
            labelTool4.SharedProps.MergeOrder = 80;
            labelTool4.SharedProps.Spring = true;
            labelTool5.SharedProps.Caption = "ログイン担当者";
            labelTool5.SharedProps.MergeOrder = 98;
            labelTool5.SharedProps.ShowInCustomizer = false;
            appearance5.BackColor = System.Drawing.Color.White;
            appearance5.TextHAlignAsString = "Left";
            labelTool6.SharedProps.AppearancesSmall.Appearance = appearance5;
            labelTool6.SharedProps.Caption = "翼　太郎";
            labelTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            labelTool6.SharedProps.MergeOrder = 99;
            labelTool6.SharedProps.ShowInCustomizer = false;
            labelTool6.SharedProps.Width = 150;
            buttonTool20.SharedProps.Caption = "終了(F1)";
            buttonTool20.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool20.SharedProps.MergeOrder = 1;
            buttonTool20.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F1;
            buttonTool20.SharedProps.ToolTipText = "得意先画面を閉じます。";
            buttonTool21.SharedProps.Caption = "保存(F10)";
            buttonTool21.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool21.SharedProps.MergeOrder = 2;
            buttonTool21.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F10;
            buttonTool21.SharedProps.ToolTipText = "入力中の情報を保存します。";
            buttonTool22.SharedProps.Caption = "元に戻す(F3)";
            buttonTool22.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool22.SharedProps.MergeOrder = 7;
            buttonTool22.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F3;
            buttonTool22.SharedProps.ToolTipText = "入力した情報を元に戻します。";
            buttonTool23.SharedProps.Caption = "設定(F12)";
            buttonTool23.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool23.SharedProps.MergeOrder = 50;
            buttonTool23.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F12;
            buttonTool23.SharedProps.ToolTipText = "ユーザー設定画面を表示します。";
            buttonTool24.SharedProps.Caption = "新規(F9)";
            buttonTool24.SharedProps.CustomizerCaption = "新規";
            buttonTool24.SharedProps.CustomizerDescription = "新規";
            buttonTool24.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool24.SharedProps.MergeOrder = 3;
            buttonTool24.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F9;
            buttonTool24.SharedProps.ToolTipText = "新規に得意先情報を入力します。";
            popupMenuTool7.SharedProps.Caption = "編集(&E)";
            popupMenuTool7.SharedProps.CustomizerCaption = "編集";
            popupMenuTool7.SharedProps.CustomizerDescription = "編集";
            buttonTool25.SharedProps.Caption = "削除(F8)";
            buttonTool25.SharedProps.CustomizerCaption = "削除";
            buttonTool25.SharedProps.CustomizerDescription = "削除";
            buttonTool25.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool25.SharedProps.MergeOrder = 4;
            buttonTool25.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F8;
            buttonTool25.SharedProps.ToolTipText = "呼出中の得意先を削除します。";
            buttonTool26.SharedProps.Caption = "編集(&E)";
            buttonTool26.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool26.SharedProps.MergeOrder = 10;
            buttonTool26.SharedProps.ToolTipText = "編集画面に切り替えます。";
            buttonTool27.SharedProps.Caption = "メモ(&M)";
            buttonTool27.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool27.SharedProps.MergeOrder = 8;
            buttonTool27.SharedProps.ToolTipText = "フリーメモ入力ダイアログを表示します。";
            labelTool7.SharedProps.Caption = "管理拠点";
            labelTool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            labelTool7.SharedProps.MergeOrder = 96;
            comboBoxTool1.SharedProps.Caption = "管理拠点選択";
            comboBoxTool1.SharedProps.MergeOrder = 97;
            comboBoxTool1.SharedProps.ToolTipText = "管理拠点を選択します。";
            comboBoxTool1.ValueList = valueList1;
            buttonTool28.SharedProps.Caption = "ローカル保存(&L)";
            buttonTool28.SharedProps.CustomizerCaption = "ローカル保存";
            buttonTool28.SharedProps.CustomizerDescription = "ローカル保存";
            buttonTool28.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool28.SharedProps.MergeOrder = 3;
            buttonTool28.SharedProps.ToolTipText = "入力中の情報をローカルに保存します。";
            buttonTool29.SharedProps.Caption = "仕入先情報入力(&R)";
            buttonTool29.SharedProps.CustomizerCaption = "仕入先情報入力";
            buttonTool29.SharedProps.CustomizerDescription = "仕入先情報入力";
            buttonTool29.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool29.SharedProps.MergeOrder = 31;
            buttonTool29.SharedProps.ToolTipText = "仕入先固有の情報を入力します。";
            controlContainerTool1.ControlName = "SectionCode_TComboEditor";
            controlContainerTool1.SharedProps.CustomizerCaption = "管理拠点選択";
            controlContainerTool1.SharedProps.CustomizerDescription = "管理拠点選択";
            controlContainerTool1.SharedProps.MergeOrder = 96;
            controlContainerTool1.SharedProps.Width = 114;
            popupMenuTool8.SharedProps.Caption = "追加情報(&A)";
            popupMenuTool8.SharedProps.CustomizerCaption = "追加情報";
            popupMenuTool8.SharedProps.CustomizerDescription = "追加情報";
            popupMenuTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            popupMenuTool8.SharedProps.MergeOrder = 1;
            popupMenuTool9.SharedProps.Caption = "ガイド(&G)";
            popupMenuTool9.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            popupMenuTool9.SharedProps.MergeOrder = 2;
            buttonTool30.SharedProps.Caption = "検索(&Q)";
            buttonTool30.SharedProps.CustomizerCaption = "検索";
            buttonTool30.SharedProps.CustomizerDescription = "検索";
            buttonTool30.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool30.SharedProps.ToolTipText = "得意先・車輌検索画面を表示します。";
            buttonTool31.SharedProps.Caption = "伝票に反映(&I)";
            buttonTool31.SharedProps.CustomizerCaption = "伝票に反映";
            buttonTool31.SharedProps.CustomizerDescription = "伝票に反映";
            buttonTool31.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool31.SharedProps.ToolTipText = "表示中の得意先情報を伝票に反映します。";
            buttonTool32.SharedProps.Caption = "復活(F2)";
            buttonTool32.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool32.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F2;
            buttonTool33.SharedProps.Caption = "完全削除(F8)";
            buttonTool33.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool33.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F8;
            buttonTool34.SharedProps.Caption = "最新情報(F7)";
            buttonTool34.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool34.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F7;
            buttonTool35.SharedProps.Caption = "ガイド(F5)";
            buttonTool35.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool35.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F5;
            this.Main_ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool4,
            popupMenuTool5,
            popupMenuTool6,
            labelTool4,
            labelTool5,
            labelTool6,
            buttonTool20,
            buttonTool21,
            buttonTool22,
            buttonTool23,
            buttonTool24,
            popupMenuTool7,
            buttonTool25,
            buttonTool26,
            buttonTool27,
            labelTool7,
            comboBoxTool1,
            buttonTool28,
            buttonTool29,
            controlContainerTool1,
            popupMenuTool8,
            popupMenuTool9,
            buttonTool30,
            buttonTool31,
            buttonTool32,
            buttonTool33,
            buttonTool34,
            buttonTool35});
            this.Main_ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.Main_ToolbarsManager_ToolClick);
            this.Main_ToolbarsManager.ToolValueChanged += new Infragistics.Win.UltraWinToolbars.ToolEventHandler(this.Main_ToolbarsManager_ToolValueChanged);
            // 
            // _SFMIT01600UA_Toolbars_Dock_Area_Right
            // 
            this._SFMIT01600UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFMIT01600UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFMIT01600UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._SFMIT01600UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFMIT01600UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1022, 63);
            this._SFMIT01600UA_Toolbars_Dock_Area_Right.Name = "_SFMIT01600UA_Toolbars_Dock_Area_Right";
            this._SFMIT01600UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 671);
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
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // _PMKHN09000UA_Toolbars_Dock_Area_Right
            // 
            this._PMKHN09000UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN09000UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN09000UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._PMKHN09000UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN09000UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1022, 63);
            this._PMKHN09000UA_Toolbars_Dock_Area_Right.Name = "_PMKHN09000UA_Toolbars_Dock_Area_Right";
            this._PMKHN09000UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 671);
            this._PMKHN09000UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _PMKHN09000UA_Toolbars_Dock_Area_Left
            // 
            this._PMKHN09000UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN09000UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN09000UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._PMKHN09000UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN09000UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 63);
            this._PMKHN09000UA_Toolbars_Dock_Area_Left.Name = "_PMKHN09000UA_Toolbars_Dock_Area_Left";
            this._PMKHN09000UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 671);
            this._PMKHN09000UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _PMKHN09000UA_Toolbars_Dock_Area_Top
            // 
            this._PMKHN09000UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN09000UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN09000UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._PMKHN09000UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN09000UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._PMKHN09000UA_Toolbars_Dock_Area_Top.Name = "_PMKHN09000UA_Toolbars_Dock_Area_Top";
            this._PMKHN09000UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1022, 63);
            this._PMKHN09000UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _PMKHN09000UA_Toolbars_Dock_Area_Bottom
            // 
            this._PMKHN09000UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN09000UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN09000UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._PMKHN09000UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN09000UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 734);
            this._PMKHN09000UA_Toolbars_Dock_Area_Bottom.Name = "_PMKHN09000UA_Toolbars_Dock_Area_Bottom";
            this._PMKHN09000UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1022, 0);
            this._PMKHN09000UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // PMKHN09000UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.ClientSize = new System.Drawing.Size(1022, 734);
            this.Controls.Add(this.Form1_Fill_Panel);
            this.Controls.Add(this._PMKHN09000UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._SFMIT01600UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._SFMIT01600UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._PMKHN09000UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._PMKHN09000UA_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._PMKHN09000UA_Toolbars_Dock_Area_Bottom);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN09000UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "得意先マスタ";
            this.Load += new System.EventHandler(this.PMKHN09000UA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode_TComboEditor)).EndInit();
            this.Form1_Fill_Panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private System.Windows.Forms.Panel panel1;
		private Broadleaf.Library.Windows.Forms.TComboEditor SectionCode_TComboEditor;

	}
}

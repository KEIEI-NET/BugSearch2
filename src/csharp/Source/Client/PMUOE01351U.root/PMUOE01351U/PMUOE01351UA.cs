using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.IO;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// 卸商仕入回答表示　UIクラス
	/// </summary>
	/// <remarks>
    /// <br>Note		: 卸商仕入回答表示　UIクラス</br>
	/// <br>Programmer	: 渋谷 大輔</br>
	/// <br>Date		: 2008/12/18</br>
    /// <br></br>
    /// <br>Date		: 2009/02/13</br>
    /// <br>Programmer	: 渋谷 大輔</br>
    /// <br>UpdateNote  : 表示の修正</br>
    /// <br>UpdateNote  : 2011/08/10 caohh   連番736</br>
    /// <br>            : NSユーザー改良要望一覧連番736の対応</br>
    /// </remarks>
	public class PMUOE01351UA : System.Windows.Forms.Form
	{
        #region ■Private Members (Component)
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFTOK01101UA_Toolbars_Dock_Area_Bottom;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFTOK01101UA_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFTOK01101UA_Toolbars_Dock_Area_Right;
		private Broadleaf.Library.Windows.Forms.TToolbarsManager Main_ToolbarsManager;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFTOK01101UA_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea1;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea2;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea3;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.Windows.Forms.Panel panel1;
		private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
		private TMemPos tMemPos1;
		private TComboEditor FontSize_tComboEditor;
        private UltraCheckEditor AutoFitCol_ultraCheckEditor;
        private UiSetControl uiSetControl1;
        private Panel panel2;
        private UltraGrid Answer_Grid;
        private Panel pnl_SearchCondition;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel lb_SupplierName;
        private TNedit tNedit_SupplierCd;
        private Infragistics.Win.Misc.UltraButton ub_SupplierGuide;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private TDateEdit tde_ed_SalesDay;
        private TDateEdit tde_st_SalesDay;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private TDateEdit tde_ed_InputDay;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private TDateEdit tde_st_InputDay;
		private System.ComponentModel.IContainer components;
        #endregion

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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel5 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel6 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel7 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel8 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel9 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel10 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel11 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("発注ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("MainMenu_Toolbar");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("View_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("SectionTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboBoxTool1 = new Infragistics.Win.UltraWinToolbars.ComboBoxTool("Section_ComboBoxTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Button_Toolbar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Search_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Clear_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Print_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool5 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool1");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Before_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Next_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool6 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool7 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool8 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Print_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboBoxTool2 = new Infragistics.Win.UltraWinToolbars.ComboBoxTool("Section_ComboBoxTool");
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(0);
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool9 = new Infragistics.Win.UltraWinToolbars.LabelTool("SectionTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("TextOut_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Before_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Next_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Preview_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ボタンツール1");
            Infragistics.Win.UltraWinToolbars.PopupControlContainerTool popupControlContainerTool1 = new Infragistics.Win.UltraWinToolbars.PopupControlContainerTool("ポップアップコントロールコンテナツール1");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("View_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Before_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Next_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Search_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Clear_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool10 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool1");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMUOE01351UA));
            this.FontSize_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.AutoFitCol_ultraCheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_SearchCondition = new System.Windows.Forms.Panel();
            this.tde_ed_InputDay = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.tde_st_InputDay = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.lb_SupplierName = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_SupplierCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ub_SupplierGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.tde_ed_SalesDay = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.tde_st_SalesDay = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.tMemPos1 = new Broadleaf.Library.Windows.Forms.TMemPos(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.ultraToolbarsDockArea3 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsDockArea2 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsDockArea1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Answer_Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this._SFTOK01101UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Main_ToolbarsManager = new Broadleaf.Library.Windows.Forms.TToolbarsManager(this.components);
            this._SFTOK01101UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFTOK01101UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFTOK01101UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.FontSize_tComboEditor)).BeginInit();
            this.ultraStatusBar1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_SearchCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Answer_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).BeginInit();
            this.SuspendLayout();
            // 
            // FontSize_tComboEditor
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.FontSize_tComboEditor.ActiveAppearance = appearance1;
            this.FontSize_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.FontSize_tComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 7.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FontSize_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Off;
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.FontSize_tComboEditor.ItemAppearance = appearance2;
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
            this.FontSize_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3,
            valueListItem4,
            valueListItem5,
            valueListItem6,
            valueListItem7});
            this.FontSize_tComboEditor.Location = new System.Drawing.Point(70, 3);
            this.FontSize_tComboEditor.Name = "FontSize_tComboEditor";
            this.FontSize_tComboEditor.Size = new System.Drawing.Size(50, 18);
            this.FontSize_tComboEditor.TabIndex = 2;
            this.FontSize_tComboEditor.Text = "11";
            this.FontSize_tComboEditor.ValueChanged += new System.EventHandler(this.FontSize_tComboEditor_ValueChanged);
            // 
            // AutoFitCol_ultraCheckEditor
            // 
            appearance3.FontData.SizeInPoints = 9F;
            this.AutoFitCol_ultraCheckEditor.Appearance = appearance3;
            this.AutoFitCol_ultraCheckEditor.BackColor = System.Drawing.Color.Transparent;
            this.AutoFitCol_ultraCheckEditor.BackColorInternal = System.Drawing.Color.Transparent;
            this.AutoFitCol_ultraCheckEditor.Location = new System.Drawing.Point(125, 3);
            this.AutoFitCol_ultraCheckEditor.Name = "AutoFitCol_ultraCheckEditor";
            this.AutoFitCol_ultraCheckEditor.Size = new System.Drawing.Size(145, 18);
            this.AutoFitCol_ultraCheckEditor.TabIndex = 3;
            this.AutoFitCol_ultraCheckEditor.Text = "列サイズの自動調整";
            this.AutoFitCol_ultraCheckEditor.CheckedChanged += new System.EventHandler(this.AutoFitCol_ultraCheckEditor_CheckedChanged);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Controls.Add(this.FontSize_tComboEditor);
            this.ultraStatusBar1.Controls.Add(this.AutoFitCol_ultraCheckEditor);
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 711);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            appearance23.FontData.SizeInPoints = 9F;
            ultraStatusPanel1.Appearance = appearance23;
            ultraStatusPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel1.Key = "StatusBarPanel_FontSizeCaption";
            ultraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic;
            ultraStatusPanel1.Text = "文字サイズ";
            ultraStatusPanel2.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel2.Control = this.FontSize_tComboEditor;
            ultraStatusPanel2.Key = "StatusBarPanel_FontSize";
            ultraStatusPanel2.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel2.Width = 50;
            ultraStatusPanel3.Width = 1;
            ultraStatusPanel4.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel4.Control = this.AutoFitCol_ultraCheckEditor;
            ultraStatusPanel4.Key = "StatusBarPanel_AutoFitCol";
            ultraStatusPanel4.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel4.Width = 145;
            ultraStatusPanel5.Key = "StatusBarPanel_WidthControl1_Text";
            ultraStatusPanel5.Width = 20;
            appearance15.FontData.SizeInPoints = 9F;
            ultraStatusPanel6.Appearance = appearance15;
            ultraStatusPanel6.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel6.Key = "StatusBarPanel_SystemDivName";
            ultraStatusPanel6.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel6.Width = 80;
            appearance24.FontData.SizeInPoints = 9F;
            ultraStatusPanel7.Appearance = appearance24;
            ultraStatusPanel7.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel7.Key = "StatusBarPanel_Text";
            ultraStatusPanel7.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel7.Width = 10;
            appearance38.FontData.SizeInPoints = 9F;
            ultraStatusPanel8.Appearance = appearance38;
            ultraStatusPanel8.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel8.Key = "StatusBarPanel_update";
            appearance39.FontData.ItalicAsString = "False";
            ultraStatusPanel9.Appearance = appearance39;
            ultraStatusPanel9.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel9.Key = "StatusBarPanel_Progress";
            appearance40.FontData.BoldAsString = "False";
            appearance40.FontData.SizeInPoints = 10F;
            ultraStatusPanel9.ProgressBarInfo.Appearance = appearance40;
            appearance41.FontData.BoldAsString = "True";
            appearance41.FontData.SizeInPoints = 9F;
            appearance41.ForeColor = System.Drawing.Color.Black;
            ultraStatusPanel9.ProgressBarInfo.FillAppearance = appearance41;
            ultraStatusPanel9.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Progress;
            ultraStatusPanel9.Visible = false;
            ultraStatusPanel9.Width = 158;
            ultraStatusPanel10.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel10.Key = "StatusBarPanel_Date";
            ultraStatusPanel10.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Date;
            ultraStatusPanel10.Width = 90;
            ultraStatusPanel11.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel11.Key = "StatusBarPanel_Time";
            ultraStatusPanel11.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Time;
            ultraStatusPanel11.Width = 50;
            this.ultraStatusBar1.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
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
            ultraStatusPanel11});
            this.ultraStatusBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ultraStatusBar1.Size = new System.Drawing.Size(1016, 23);
            this.ultraStatusBar1.TabIndex = 8;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            this.ultraStatusBar1.WrapText = false;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.pnl_SearchCondition);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 79);
            this.panel1.TabIndex = 0;
            // 
            // pnl_SearchCondition
            // 
            this.pnl_SearchCondition.Controls.Add(this.tde_ed_InputDay);
            this.pnl_SearchCondition.Controls.Add(this.ultraLabel5);
            this.pnl_SearchCondition.Controls.Add(this.tde_st_InputDay);
            this.pnl_SearchCondition.Controls.Add(this.ultraLabel4);
            this.pnl_SearchCondition.Controls.Add(this.ultraLabel2);
            this.pnl_SearchCondition.Controls.Add(this.ultraLabel1);
            this.pnl_SearchCondition.Controls.Add(this.lb_SupplierName);
            this.pnl_SearchCondition.Controls.Add(this.tNedit_SupplierCd);
            this.pnl_SearchCondition.Controls.Add(this.ub_SupplierGuide);
            this.pnl_SearchCondition.Controls.Add(this.ultraLabel3);
            this.pnl_SearchCondition.Controls.Add(this.tde_ed_SalesDay);
            this.pnl_SearchCondition.Controls.Add(this.tde_st_SalesDay);
            this.pnl_SearchCondition.Location = new System.Drawing.Point(12, 0);
            this.pnl_SearchCondition.Name = "pnl_SearchCondition";
            this.pnl_SearchCondition.Size = new System.Drawing.Size(992, 67);
            this.pnl_SearchCondition.TabIndex = 146;
            // 
            // tde_ed_InputDay
            // 
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tde_ed_InputDay.ActiveEditAppearance = appearance31;
            this.tde_ed_InputDay.BackColor = System.Drawing.Color.Transparent;
            this.tde_ed_InputDay.CalendarDisp = true;
            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance32.TextHAlignAsString = "Left";
            appearance32.TextVAlignAsString = "Middle";
            this.tde_ed_InputDay.EditAppearance = appearance32;
            this.tde_ed_InputDay.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tde_ed_InputDay.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance33.TextHAlignAsString = "Left";
            appearance33.TextVAlignAsString = "Middle";
            this.tde_ed_InputDay.LabelAppearance = appearance33;
            this.tde_ed_InputDay.Location = new System.Drawing.Point(710, 33);
            this.tde_ed_InputDay.Name = "tde_ed_InputDay";
            this.tde_ed_InputDay.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tde_ed_InputDay.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.tde_ed_InputDay.Size = new System.Drawing.Size(172, 24);
            this.tde_ed_InputDay.TabIndex = 149;
            this.tde_ed_InputDay.TabStop = true;
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ultraLabel5.Location = new System.Drawing.Point(683, 34);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(21, 21);
            this.ultraLabel5.TabIndex = 155;
            this.ultraLabel5.Text = "～";
            // 
            // tde_st_InputDay
            // 
            appearance34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tde_st_InputDay.ActiveEditAppearance = appearance34;
            this.tde_st_InputDay.BackColor = System.Drawing.Color.Transparent;
            this.tde_st_InputDay.CalendarDisp = true;
            appearance35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance35.TextHAlignAsString = "Left";
            appearance35.TextVAlignAsString = "Middle";
            this.tde_st_InputDay.EditAppearance = appearance35;
            this.tde_st_InputDay.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tde_st_InputDay.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance36.TextHAlignAsString = "Left";
            appearance36.TextVAlignAsString = "Middle";
            this.tde_st_InputDay.LabelAppearance = appearance36;
            this.tde_st_InputDay.Location = new System.Drawing.Point(505, 33);
            this.tde_st_InputDay.Name = "tde_st_InputDay";
            this.tde_st_InputDay.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tde_st_InputDay.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.tde_st_InputDay.Size = new System.Drawing.Size(172, 24);
            this.tde_st_InputDay.TabIndex = 148;
            this.tde_st_InputDay.TabStop = true;
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ultraLabel4.Location = new System.Drawing.Point(444, 38);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(55, 17);
            this.ultraLabel4.TabIndex = 154;
            this.ultraLabel4.Text = "処理日";
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ultraLabel2.Location = new System.Drawing.Point(683, 6);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(21, 21);
            this.ultraLabel2.TabIndex = 153;
            this.ultraLabel2.Text = "～";
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ultraLabel1.Location = new System.Drawing.Point(444, 6);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(55, 17);
            this.ultraLabel1.TabIndex = 152;
            this.ultraLabel1.Text = "受信日";
            // 
            // lb_SupplierName
            // 
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance25.BorderColor = System.Drawing.Color.RosyBrown;
            appearance25.TextVAlignAsString = "Middle";
            this.lb_SupplierName.Appearance = appearance25;
            this.lb_SupplierName.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.lb_SupplierName.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lb_SupplierName.Location = new System.Drawing.Point(135, 6);
            this.lb_SupplierName.Name = "lb_SupplierName";
            this.lb_SupplierName.Padding = new System.Drawing.Size(3, 0);
            this.lb_SupplierName.Size = new System.Drawing.Size(227, 24);
            this.lb_SupplierName.TabIndex = 151;
            this.lb_SupplierName.WrapText = false;
            // 
            // tNedit_SupplierCd
            // 
            appearance26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_SupplierCd.ActiveAppearance = appearance26;
            appearance30.BackColorDisabled = System.Drawing.SystemColors.Control;
            this.tNedit_SupplierCd.Appearance = appearance30;
            this.tNedit_SupplierCd.AutoSelect = true;
            this.tNedit_SupplierCd.AutoSize = false;
            this.tNedit_SupplierCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierCd.DataText = "";
            this.tNedit_SupplierCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SupplierCd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SupplierCd.Location = new System.Drawing.Point(70, 6);
            this.tNedit_SupplierCd.MaxLength = 4;
            this.tNedit_SupplierCd.Name = "tNedit_SupplierCd";
            this.tNedit_SupplierCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_SupplierCd.Size = new System.Drawing.Size(59, 24);
            this.tNedit_SupplierCd.TabIndex = 144;
            // 
            // ub_SupplierGuide
            // 
            this.ub_SupplierGuide.Location = new System.Drawing.Point(368, 5);
            this.ub_SupplierGuide.Name = "ub_SupplierGuide";
            this.ub_SupplierGuide.Size = new System.Drawing.Size(24, 24);
            this.ub_SupplierGuide.TabIndex = 145;
            this.ub_SupplierGuide.Tag = "";
            ultraToolTipInfo1.ToolTipText = "発注ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.ub_SupplierGuide, ultraToolTipInfo1);
            this.ub_SupplierGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ub_SupplierGuide.Click += new System.EventHandler(this.ub_SupplierGuide_Click);
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ultraLabel3.Location = new System.Drawing.Point(12, 10);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(55, 17);
            this.ultraLabel3.TabIndex = 150;
            this.ultraLabel3.Text = "発注先";
            // 
            // tde_ed_SalesDay
            // 
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tde_ed_SalesDay.ActiveEditAppearance = appearance12;
            this.tde_ed_SalesDay.BackColor = System.Drawing.Color.Transparent;
            this.tde_ed_SalesDay.CalendarDisp = true;
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance22.TextHAlignAsString = "Left";
            appearance22.TextVAlignAsString = "Middle";
            this.tde_ed_SalesDay.EditAppearance = appearance22;
            this.tde_ed_SalesDay.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tde_ed_SalesDay.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance27.TextHAlignAsString = "Left";
            appearance27.TextVAlignAsString = "Middle";
            this.tde_ed_SalesDay.LabelAppearance = appearance27;
            this.tde_ed_SalesDay.Location = new System.Drawing.Point(710, 3);
            this.tde_ed_SalesDay.Name = "tde_ed_SalesDay";
            this.tde_ed_SalesDay.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tde_ed_SalesDay.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.tde_ed_SalesDay.Size = new System.Drawing.Size(172, 24);
            this.tde_ed_SalesDay.TabIndex = 147;
            this.tde_ed_SalesDay.TabStop = true;
            // 
            // tde_st_SalesDay
            // 
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tde_st_SalesDay.ActiveEditAppearance = appearance28;
            this.tde_st_SalesDay.BackColor = System.Drawing.Color.Transparent;
            this.tde_st_SalesDay.CalendarDisp = true;
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance29.TextHAlignAsString = "Left";
            appearance29.TextVAlignAsString = "Middle";
            this.tde_st_SalesDay.EditAppearance = appearance29;
            this.tde_st_SalesDay.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tde_st_SalesDay.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance37.TextHAlignAsString = "Left";
            appearance37.TextVAlignAsString = "Middle";
            this.tde_st_SalesDay.LabelAppearance = appearance37;
            this.tde_st_SalesDay.Location = new System.Drawing.Point(505, 3);
            this.tde_st_SalesDay.Name = "tde_st_SalesDay";
            this.tde_st_SalesDay.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tde_st_SalesDay.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.tde_st_SalesDay.Size = new System.Drawing.Size(172, 24);
            this.tde_st_SalesDay.TabIndex = 146;
            this.tde_st_SalesDay.TabStop = true;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // tMemPos1
            // 
            this.tMemPos1.OwnerForm = this;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 701);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1016, 10);
            this.panel2.TabIndex = 23;
            // 
            // ultraToolbarsDockArea3
            // 
            this.ultraToolbarsDockArea3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.ultraToolbarsDockArea3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this.ultraToolbarsDockArea3.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this.ultraToolbarsDockArea3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ultraToolbarsDockArea3.Location = new System.Drawing.Point(1016, 63);
            this.ultraToolbarsDockArea3.Name = "ultraToolbarsDockArea3";
            this.ultraToolbarsDockArea3.Size = new System.Drawing.Size(0, 648);
            // 
            // ultraToolbarsDockArea2
            // 
            this.ultraToolbarsDockArea2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.ultraToolbarsDockArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this.ultraToolbarsDockArea2.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this.ultraToolbarsDockArea2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ultraToolbarsDockArea2.Location = new System.Drawing.Point(0, 63);
            this.ultraToolbarsDockArea2.Name = "ultraToolbarsDockArea2";
            this.ultraToolbarsDockArea2.Size = new System.Drawing.Size(0, 648);
            // 
            // ultraToolbarsDockArea1
            // 
            this.ultraToolbarsDockArea1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.ultraToolbarsDockArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this.ultraToolbarsDockArea1.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this.ultraToolbarsDockArea1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ultraToolbarsDockArea1.Location = new System.Drawing.Point(0, 711);
            this.ultraToolbarsDockArea1.Name = "ultraToolbarsDockArea1";
            this.ultraToolbarsDockArea1.Size = new System.Drawing.Size(1016, 0);
            // 
            // Answer_Grid
            // 
            this.Answer_Grid.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance4.BackColor = System.Drawing.Color.White;
            appearance4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Answer_Grid.DisplayLayout.Appearance = appearance4;
            this.Answer_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.Answer_Grid.DisplayLayout.GroupByBox.Hidden = true;
            this.Answer_Grid.DisplayLayout.InterBandSpacing = 10;
            this.Answer_Grid.DisplayLayout.MaxColScrollRegions = 8;
            appearance5.ForeColor = System.Drawing.Color.Black;
            this.Answer_Grid.DisplayLayout.Override.ActiveRowAppearance = appearance5;
            this.Answer_Grid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.Answer_Grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.Answer_Grid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.Answer_Grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            appearance6.BackColor = System.Drawing.Color.Transparent;
            this.Answer_Grid.DisplayLayout.Override.CardAreaAppearance = appearance6;
            this.Answer_Grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance7.ForeColor = System.Drawing.Color.White;
            appearance7.TextHAlignAsString = "Center";
            appearance7.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.Answer_Grid.DisplayLayout.Override.HeaderAppearance = appearance7;
            this.Answer_Grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance8.BackColor = System.Drawing.Color.Lavender;
            this.Answer_Grid.DisplayLayout.Override.RowAlternateAppearance = appearance8;
            appearance9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.Answer_Grid.DisplayLayout.Override.RowAppearance = appearance9;
            this.Answer_Grid.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.Answer_Grid.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance10.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Answer_Grid.DisplayLayout.Override.RowSelectorAppearance = appearance10;
            this.Answer_Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.Answer_Grid.DisplayLayout.Override.RowSelectorWidth = 12;
            this.Answer_Grid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance11.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance11.ForeColor = System.Drawing.Color.Black;
            this.Answer_Grid.DisplayLayout.Override.SelectedRowAppearance = appearance11;
            this.Answer_Grid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.Answer_Grid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.Answer_Grid.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.ExtendedAutoDrag;
            this.Answer_Grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.Answer_Grid.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.Answer_Grid.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.Answer_Grid.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.Both;
            this.Answer_Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.Answer_Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.Answer_Grid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.Answer_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Answer_Grid.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Answer_Grid.Location = new System.Drawing.Point(0, 142);
            this.Answer_Grid.Name = "Answer_Grid";
            this.Answer_Grid.Size = new System.Drawing.Size(1016, 559);
            this.Answer_Grid.TabIndex = 40;
            this.Answer_Grid.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.Answer_Grid_InitializeLayout);
            this.Answer_Grid.AfterRowActivate += new System.EventHandler(this.Answer_Grid_AfterRowActivate);
            // 
            // _SFTOK01101UA_Toolbars_Dock_Area_Right
            // 
            this._SFTOK01101UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFTOK01101UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFTOK01101UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._SFTOK01101UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFTOK01101UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1016, 63);
            this._SFTOK01101UA_Toolbars_Dock_Area_Right.Name = "_SFTOK01101UA_Toolbars_Dock_Area_Right";
            this._SFTOK01101UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 648);
            this._SFTOK01101UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.Main_ToolbarsManager;
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
            ultraToolbar1.FloatingSize = new System.Drawing.Size(726, 23);
            ultraToolbar1.IsMainMenuBar = true;
            labelTool1.InstanceProps.Width = 25;
            labelTool2.InstanceProps.Width = 62;
            labelTool3.InstanceProps.Width = 103;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1,
            popupMenuTool2,
            labelTool1,
            labelTool2,
            comboBoxTool1,
            labelTool3,
            labelTool4});
            ultraToolbar1.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.ShowInToolbarList = false;
            ultraToolbar1.Text = "メインメニュー";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 1;
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            buttonTool4,
            labelTool5,
            buttonTool5,
            buttonTool6});
            ultraToolbar2.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar2.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar2.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.BelowImage;
            ultraToolbar2.Text = "標準";
            this.Main_ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2});
            this.Main_ToolbarsManager.ToolbarSettings.FillEntireRow = Infragistics.Win.DefaultableBoolean.False;
            popupMenuTool3.SharedProps.Caption = "ファイル(&F)";
            popupMenuTool3.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            popupMenuTool3.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool7});
            labelTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.DefaultForToolType;
            labelTool6.SharedProps.Spring = true;
            labelTool7.SharedProps.Caption = "ログイン担当者";
            labelTool7.SharedProps.ShowInCustomizer = false;
            appearance42.BackColor = System.Drawing.Color.White;
            appearance42.TextHAlignAsString = "Left";
            labelTool8.SharedProps.AppearancesSmall.Appearance = appearance42;
            labelTool8.SharedProps.Caption = "広葉　太郎";
            labelTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            labelTool8.SharedProps.ShowInCustomizer = false;
            labelTool8.SharedProps.Width = 150;
            buttonTool8.SharedProps.Caption = "終了(&X)";
            buttonTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool8.SharedProps.ToolTipText = "画面を終了します。";
            buttonTool9.SharedProps.Caption = "印刷(F5)";
            buttonTool9.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool9.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F5;
            buttonTool9.SharedProps.ToolTipText = "印刷(F5)";
            appearance43.ForeColorDisabled = System.Drawing.Color.Black;
            comboBoxTool2.EditAppearance = appearance43;
            comboBoxTool2.SharedProps.Enabled = false;
            comboBoxTool2.SharedProps.Visible = false;
            comboBoxTool2.ValueList = valueList1;
            labelTool9.SharedProps.Caption = "拠　点";
            labelTool9.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            labelTool9.SharedProps.Visible = false;
            buttonTool10.SharedProps.Caption = "テキスト出力(&O)";
            buttonTool10.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool10.SharedProps.ToolTipText = "履歴をテキスト出力します。";
            buttonTool11.SharedProps.Caption = "戻る(&R)";
            buttonTool11.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool12.SharedProps.Caption = "進む(&G)";
            buttonTool12.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool13.SharedProps.Caption = "PDF表示(&V)";
            buttonTool13.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool14.SharedProps.Caption = "ボタンツール1";
            buttonTool14.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyInMenus;
            popupControlContainerTool1.SharedProps.Caption = "ポップアップコントロールコンテナツール1";
            popupMenuTool4.SharedProps.Caption = "表示(&V)";
            popupMenuTool4.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool15,
            buttonTool16});
            buttonTool17.SharedProps.Caption = "検索(&R)";
            buttonTool17.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool18.SharedProps.Caption = "クリア(&C)";
            buttonTool18.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            labelTool10.SharedProps.Caption = "|";
            this.Main_ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool3,
            labelTool6,
            labelTool7,
            labelTool8,
            buttonTool8,
            buttonTool9,
            comboBoxTool2,
            labelTool9,
            buttonTool10,
            buttonTool11,
            buttonTool12,
            buttonTool13,
            buttonTool14,
            popupControlContainerTool1,
            popupMenuTool4,
            buttonTool17,
            buttonTool18,
            labelTool10});
            this.Main_ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.Main_ToolbarsManager_ToolClick);
            // 
            // _SFTOK01101UA_Toolbars_Dock_Area_Left
            // 
            this._SFTOK01101UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFTOK01101UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFTOK01101UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._SFTOK01101UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFTOK01101UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 63);
            this._SFTOK01101UA_Toolbars_Dock_Area_Left.Name = "_SFTOK01101UA_Toolbars_Dock_Area_Left";
            this._SFTOK01101UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 648);
            this._SFTOK01101UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _SFTOK01101UA_Toolbars_Dock_Area_Top
            // 
            this._SFTOK01101UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFTOK01101UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFTOK01101UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._SFTOK01101UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFTOK01101UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._SFTOK01101UA_Toolbars_Dock_Area_Top.Name = "_SFTOK01101UA_Toolbars_Dock_Area_Top";
            this._SFTOK01101UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1016, 88);
            this._SFTOK01101UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _SFTOK01101UA_Toolbars_Dock_Area_Bottom
            // 
            this._SFTOK01101UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFTOK01101UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFTOK01101UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._SFTOK01101UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFTOK01101UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 711);
            this._SFTOK01101UA_Toolbars_Dock_Area_Bottom.Name = "_SFTOK01101UA_Toolbars_Dock_Area_Bottom";
            this._SFTOK01101UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1016, 0);
            this._SFTOK01101UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // PMUOE01351UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.Answer_Grid);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ultraToolbarsDockArea3);
            this.Controls.Add(this._SFTOK01101UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._SFTOK01101UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this.ultraToolbarsDockArea2);
            this.Controls.Add(this._SFTOK01101UA_Toolbars_Dock_Area_Top);
            this.Controls.Add(this.ultraToolbarsDockArea1);
            this.Controls.Add(this._SFTOK01101UA_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.ultraStatusBar1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMUOE01351UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "卸商仕入回答表示";
            this.Load += new System.EventHandler(this.PMUOE01351UA_Load);
            this.Shown += new System.EventHandler(this.PMUOE01351UA_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.FontSize_tComboEditor)).EndInit();
            this.ultraStatusBar1.ResumeLayout(false);
            this.ultraStatusBar1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pnl_SearchCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Answer_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        #region ■変数、定数
        // プログラム情報
        private const string PG_ID = "PMUOE01351U";         // プログラムID
        private const string PG_NM = "卸商仕入回答表示";        // プログラム名称

        // ---- ADD caohh 2011/08/10 ----->>>>>
        // 帳票名称
        private string _printName = "仕入回答一覧表";
        // 帳票キー	
        private string _printKey = "c52ced9fdf29467094a1de21917a15c2";
        // 抽出条件クラス
        private UOEAnswerLedgerOrderCndtn _uOEAnswerLedgerOrderCndtn;
        // ---- ADD caohh 2011/08/10 -----<<<<<

        // 検索条件
        private const int SEARCH_FIRST = 0;                 // 初回
        private const int SEARCH_BEFORE = 1;                // 前データ
        private const int SEARCH_NEXT = 2;                  // 次データ
        // エラーチェック
        private const int CHECKDATA_FAILED = -1;            // チェック失敗
        private const int CHECKDATA_CNDTNEMPTY = 0;         // 入力なし
        private const int CHECKDATA_SUCCESS = 1;            // チェック成功
        // メッセージ
        private const string MSG_NODATA_BEFORE = "先頭データです。";        // 前データなし
        private const string MSG_NODATA_NEXT = "データが終了しました。";    // 次データなし
        // グリッド列幅
        private const int GRIDCOLUMN_WIDTH1 = 26;       // セレクター
        private const int GRIDCOLUMN_WIDTH2 = 10;       // 非表示
        private const int GRIDCOLUMN_WIDTH3 = 87;      // 受信日
        private const int GRIDCOLUMN_WIDTH4 = 193;       // 発注品番
        private const int GRIDCOLUMN_WIDTH5 = 68;       // 納品区分
        private const int GRIDCOLUMN_WIDTH6 = 190;       // 品名
        private const int GRIDCOLUMN_WIDTH7 = 68;       // 原単価
        private const int GRIDCOLUMN_WIDTH8 = 68;       // 伝票番号
        private const int GRIDCOLUMN_WIDTH9 = 90;      // 倉庫・棚番
        private const int GRIDCOLUMN_WIDTH10 = 179;      // リマーク
        private const int GRIDCOLUMN_WIDTH11 = 10;      // 非表示
        // 検索条件クリア
        private const bool SEARCHCONDITION_CLEAR = true;        // 検索条件クリア
        private const bool SEARCHCONDITION_NO_CLEAR = false;    // 検索条件残す

        // 各種クラス
        private ImageList _imageList16 = null;              // アイコン設定クラス
        private ControlScreenSkin _controlScreenSkin;       // 画面デザイン変更クラス
        private GridStateController _gridStateController;   // グリッド設定制御クラス
        private PMUOE01353AA _orderAnswerAcs = null;        // 発注回答アクセスクラス

        // 各種データ
        private string _enterpriseCode = string.Empty;      // 企業コード
        private string _sectionCode = string.Empty;         // 拠点コード
        private List<OrderSndRcvJnl> _orderSndRcvJnlList;   // UOE送受信ジャーナル(発注)データ
        private bool _singleMode;                           // True：単体起動、False：その他
        private Backup _backup;                             // 入力値保持

        // 入力値保持用
        struct Backup
        {
            public int SalesDaySt;          // 発注日From
            public int SalesDayEd;          // 発注日To
            public int SupplierCd;          // 発注先コード
            public string SupplierName;     // 発注先名称
            public int InputDaySt;          // 処理日From
            public int InputDayEd;          // 処理日To
        }
        # endregion ■変数、定数 - end

        #region ■constructor、Dispose
        #region ▼constructor
        /// <summary>
        /// コンストラクタ(単体起動専用)
        /// </summary>
        public PMUOE01351UA()
        {
            ConstructorProc();

            // 単体起動モード
            this._singleMode = true;
        }
        /// <summary>
        /// コンストラクタ(単体起動以外時)
        /// </summary>
        /// <param name="orderSndRcvJnlList">UOE送受信ジャーナル(発注)リスト</param>
        public PMUOE01351UA(List<OrderSndRcvJnl> orderSndRcvJnlList)
        {
            ConstructorProc();

            this._orderSndRcvJnlList = orderSndRcvJnlList;  // UOE送受信ジャーナル(発注)データ

            // 単体起動以外
            this._singleMode = false;
        }
        #endregion

        #region ▼Dispose
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
        #endregion
        #endregion ■constructor、Dispose - end

        #region ■イベント
        #region ▼Form_Load
        /// <summary>
		/// フォームロード
		/// </summary>
		/// <remarks>
		/// <br>Note       : Formロード時に処理します。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/18</br>
        /// </remarks>
        private void PMUOE01351UA_Load(object sender, System.EventArgs e)
		{
            try
            {
                // ツールバー設定
                this.SetToolbar();

                // 画面スキン変更
                this._controlScreenSkin.LoadSkin();
                this._controlScreenSkin.SettingScreenSkin(this);

                // フォントサイズ
                this.FontSize_tComboEditor.Value = 11;
                // 列サイズの自動調整
                this.AutoFitCol_ultraCheckEditor.Checked = false;

                // 画面初期化
                this.AllInitializeLayout(SEARCHCONDITION_CLEAR);
                this.ub_SupplierGuide.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];        // 発注ガイド

                if (this._singleMode)
                {
                    // データ取得(送受信JNLデータを除く)
                    this._orderAnswerAcs = new PMUOE01353AA(null, this._enterpriseCode,this._sectionCode);
                }
                else if (this._orderSndRcvJnlList != null)
                {
                    // データ取得
                    this._orderAnswerAcs = new PMUOE01353AA(this._orderSndRcvJnlList, this._enterpriseCode,this._sectionCode);
                    this._orderSndRcvJnlList = null;

                    // データ表示
                    this.Search(SEARCH_FIRST);
                }
            }
			finally
			{
                // ときどきツールバーが消えるので、リフレッシュ
                this.Refresh();
            }
        }
        #endregion

        #region ▼Toolbar_Click
        /// <summary>
        /// ツールバークリック
        /// </summary>
        /// <remarks>
        /// <br>Note       : ツールバークリック時に処理します。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/18</br>
        /// </remarks>
        private void Main_ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 終了ボタン押下
                case "End_ButtonTool":
                    {
                        this.Close();
                        break;
                    }
                // 検索ボタン押下
                case "Search_ButtonTool":
                    {
                        this.ToolbarSearchClick();
                        break;
                    }
                // クリアボタン押下
                case "Clear_ButtonTool":
                    {
                        this.ToolbarClearClick();
                        break;
                    }
                // --- ADD caohh 2011/08/10 ----------------------------->>>>>
                // 印刷ボタン押下
                case "Print_ButtonTool":
                    {
                        SFCMN06002C parameter = new SFCMN06002C();
                        this.ToolbarPrintClick(ref parameter);
                        break;
                    }
                // --- ADD caohh 2011/08/10 -----------------------------<<<<<
                // 戻るボタン押下
                case "Before_ButtonTool":
                    {
                        this.Search(SEARCH_BEFORE);
                        break;
                    }
                // 進むボタン押下
                case "Next_ButtonTool":
                    {
                        this.Search(SEARCH_NEXT);
                        break;
                    }
            }
        }
        #endregion

        #region ▼ub_SupplierGuide_Click
        /// <summary>
        /// 発注先ガイドボタン押下時処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 発注先ガイドボタンが押された時に処理します</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/18</br>
        /// </remarks>
        private void ub_SupplierGuide_Click(object sender, EventArgs e)
        {
            UOESupplier uoeSupplier = new UOESupplier();          
            UOESupplierAcs uoeSupplierAcs = new UOESupplierAcs();

            // 発注先ガイド表示
            int status = uoeSupplierAcs.ExecuteGuid(this._enterpriseCode,this._sectionCode, out uoeSupplier);
            if ((status == 0) && (uoeSupplier != null))
            {
                this.tNedit_SupplierCd.Value = uoeSupplier.UOESupplierCd;
                this.lb_SupplierName.Text = uoeSupplier.UOESupplierName;

                this.tNedit_SupplierCd.Focus();
            }
        }
        #endregion

        #region ▼Grid_InitializeLayout
        /// <summary>
		/// 回答グリッドイニシャライズレイアウト
		/// </summary>
		/// <remarks>
		/// <br>Note       : 回答グリッド初期化時に処理します。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/18</br>
        /// </remarks>
		private void Answer_Grid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
            // 『固定列』プッシュピンアイコンを消す
            e.Layout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None;

            // 『フィルタリング』アイコンを消す
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // 『ソート』『列移動』不可
            e.Layout.Override.SelectTypeCol = SelectType.None;
            e.Layout.Override.HeaderClickAction = HeaderClickAction.Select;

            // 行サイズを設定
            e.Layout.Override.DefaultRowHeight = 24;
            e.Layout.Override.FixedCellSeparatorColor = Color.Black;

            // 『列サイズ(横幅)』変更可
            e.Layout.Override.AllowRowLayoutLabelSizing = RowLayoutSizing.Horizontal;       // ヘッダー
            e.Layout.Override.AllowRowLayoutCellSizing = RowLayoutSizing.Horizontal;        // 明細
        }
		#endregion

        #region ▼Grid_AfterRowActivate
        /// <summary>
        /// 回答グリッドアフターRowアクティブ
        /// </summary>
        /// <remarks>
        /// <br>Note		: 行がアクティブになった後に発生します。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/18</br>
        /// </remarks>
        private void Answer_Grid_AfterRowActivate(object sender, System.EventArgs e)
        {
            // 選択行が存在する場合
            if (this.Answer_Grid.ActiveRow != null)
            {
                // アクティブな行の前景色を元々指定してある前景色と同じにする
                Infragistics.Win.UltraWinGrid.UltraGridRow activeRow = this.Answer_Grid.ActiveRow;
                this.Answer_Grid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = activeRow.Appearance.ForeColor;
            }
        }
        #endregion

        #region ▼FontSize_ValueChanged
        /// <summary>
		/// フォントサイズ値変更
		/// </summary>
		/// <remarks>
		/// <br>Note		: フォントサイズの値が変更された時に発生します。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/18</br>
        /// </remarks>
		private void FontSize_tComboEditor_ValueChanged(object sender, EventArgs e)
		{
			// フォントサイズを変更
			this.Answer_Grid.DisplayLayout.Appearance.FontData.SizeInPoints = (int)FontSize_tComboEditor.Value;
        }
        #endregion

        #region ▼AutoFitCol_CheckedChanged
        /// <summary>
		/// 列サイズの自動調整チェック変更
		/// </summary>
		/// <remarks>
		/// <br>Note		: 列サイズの自動調整のチェックが変更された時に発生します。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/18</br>
        /// </remarks>
		private void AutoFitCol_ultraCheckEditor_CheckedChanged(object sender, EventArgs e)
		{
			// 列サイズの自動調整
			if (!this.AutoFitCol_ultraCheckEditor.Checked)
				this.Answer_Grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
			else
				this.Answer_Grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None;

			foreach (UltraGridColumn wkColumn in this.Answer_Grid.DisplayLayout.Bands[0].Columns)
			{
				wkColumn.PerformAutoResize(PerformAutoSizeType.AllRowsInBand);
			}
		}
		#endregion

        #region ▼Form_Shown(単体起動専用)
        /// <summary>
        /// Form初回表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : 初回起動時に処理します</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/18</br>
        /// </remarks>
        private void PMUOE01351UA_Shown(object sender, EventArgs e)
        {
            this.tNedit_SupplierCd.Focus();
        }
        #endregion

        #region ▼ArrowKey_ChangeFocus(単体起動専用)
        /// <summary>
        /// ArrowKeyチェンジフォーカス
        /// </summary>
        /// <remarks>
        /// <br>Note       : フォーカス遷移が行われた時に処理します</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/18</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            int status = 0;

            #region 受信日From
            // 受信日Fromからの遷移時
            if (e.PrevCtrl == this.tde_st_SalesDay)
            {
                // 日付形式不正時は空欄
                if (this.tde_st_SalesDay.GetDateTime() == DateTime.MinValue)
                {
                    this.tde_st_SalesDay.SetLongDate(0);
                }

                // 値を保持
                this.BackupInputValue(e.PrevCtrl);

                // ↑、←、Shift+Tab/Enter時、遷移なし
                if ((e.ShiftKey == true) && ((e.Key == Keys.Enter) || (e.Key == Keys.Tab)))
                {
                    e.NextCtrl = e.PrevCtrl;
                    return;
                }
                if ((e.Key == Keys.Up) || (e.Key == Keys.Left))
                {
                    e.NextCtrl = e.PrevCtrl;
                }
                return;
            }
            #endregion

            #region 受信日To
            // 受信日Toからの遷移時
            if (e.PrevCtrl == this.tde_ed_SalesDay)
            {
                // 日付形式不正時は空欄
                if (this.tde_ed_SalesDay.GetDateTime() == DateTime.MinValue)
                {
                    this.tde_ed_SalesDay.SetLongDate(0);
                }

                // 値を保持
                this.BackupInputValue(e.PrevCtrl);

                // ↓時、発注先コードに遷移
                if (e.Key == Keys.Down)
                {
                    e.NextCtrl = this.tNedit_SupplierCd;
                }
                return;
            }
            #endregion

            #region 処理日From
            // 処理日Fromからの遷移時
            if (e.PrevCtrl == this.tde_st_InputDay)
            {
                // 日付形式不正時は空欄
                if (this.tde_st_InputDay.GetDateTime() == DateTime.MinValue)
                {
                    this.tde_st_InputDay.SetLongDate(0);
                }

                // 値を保持
                this.BackupInputValue(e.PrevCtrl);

                // ↑、←、Shift+Tab/Enter時、遷移なし
                if ((e.ShiftKey == true) && ((e.Key == Keys.Enter) || (e.Key == Keys.Tab)))
                {
                    e.NextCtrl = e.PrevCtrl;
                    return;
                }
                if ((e.Key == Keys.Up) || (e.Key == Keys.Left))
                {
                    e.NextCtrl = e.PrevCtrl;
                }
                return;
            }
            #endregion

            #region 処理日To
            // 処理日Toからの遷移時
            if (e.PrevCtrl == this.tde_ed_InputDay)
            {
                // 日付形式不正時は空欄
                if (this.tde_ed_InputDay.GetDateTime() == DateTime.MinValue)
                {
                    this.tde_ed_InputDay.SetLongDate(0);
                }

                // 値を保持
                this.BackupInputValue(e.PrevCtrl);

                // ↓時、発注先コードに遷移
                if (e.Key == Keys.Down)
                {
                    e.NextCtrl = this.tNedit_SupplierCd;
                }
                return;
            }
            #endregion

            #region 発注先
            // 発注先コードから遷移時
            if (e.PrevCtrl == this.tNedit_SupplierCd)
            {
                //// 入力チェック
                status = this.CheckConditionSupplier();
                if (status == CHECKDATA_CNDTNEMPTY)
                {
                    // 値保持
                    this.BackupInputValue(e.PrevCtrl);
                }
                else if (status == CHECKDATA_FAILED)
                {
                    // 値を戻す
                    this.RecoverInputValue(e.PrevCtrl);
                    this.tNedit_SupplierCd.Select();

                    e.NextCtrl = e.PrevCtrl;
                    return;
                }
                else
                {
                    // 値を保持
                    this.BackupInputValue(e.PrevCtrl);

                    // Enter/Tab押下時は発注日に遷移
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (e.ShiftKey == false)
                        {
                            //e.NextCtrl = e.PrevCtrl;
                            e.NextCtrl = tde_st_SalesDay;
                        }
                    }
                }

                // ↓は遷移なし
                if (e.Key == Keys.Down)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
                return;
            }
            #endregion

            #region 発注先ガイドボタン
            // ガイドボタンから遷移時
            if (e.PrevCtrl == this.ub_SupplierGuide)
            {
                // ↓は遷移なし
                if (e.Key == Keys.Down)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
                // Enter/Tab時は発注日に遷移
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.ShiftKey == false)
                    {
                        //e.NextCtrl = e.PrevCtrl;
                        e.NextCtrl = tde_st_SalesDay;
                    }
                }
                return;
            }
            #endregion
        }
        #endregion
        #endregion ■イベント - end

        #region ■Privateメソッド
        #region ▼ConstructorProc(コンストラクタ)
        private void ConstructorProc()
        {
            //
            // Windows フォーム デザイナ サポートに必要です。
            //
            InitializeComponent();

            this._imageList16 = IconResourceManagement.ImageList16;     // アイコン情報
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode; // 企業コード
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;        // 拠点コード

            // インスタンス作成
            this._controlScreenSkin = new ControlScreenSkin();          // 画面デザイン変更
            this._gridStateController = new GridStateController();      // グリッド設定制御
        }
        #endregion

        #region ▼AllInitializeLayout(画面初期化)
        /// <summary>
        /// 画面初期化
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期化を行います。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/18</br>
        /// </remarks>
        private void AllInitializeLayout(bool searchConditionClear)
        {
            // 検索条件
            if (searchConditionClear)
            {
                // 初期表示
                this.tde_st_SalesDay.SetToday();
                this.tde_ed_SalesDay.SetToday();
                this.tNedit_SupplierCd.Clear();
                this.lb_SupplierName.Text = string.Empty;
                this.tde_st_InputDay.SetToday();
                this.tde_ed_InputDay.SetToday();

                // 値保持
                this.BackupInputValueAll();
            }

            // グリッド
            this.GridInitializeLayout();

            // ボタン
            if (this._singleMode)
            {
                // 単体起動時
                this.ChangeSearchConditionStatus(true);     // 検索関連
                this.ChangeViewPopupToolbarStatus(false);   // 戻る・進む関連
            }
            else if (this._orderSndRcvJnlList != null)
            {
                // 単体起動以外でデータあり
                this.ChangeSearchConditionStatus(false);    // 検索関連
                this.ChangeViewPopupToolbarStatus(false);    // 戻る・進む関連
            }
            else
            {
                // 単体起動以外でデータなし(異常)
                this.ChangeSearchConditionStatus(false);    // 検索関連
                this.ChangeViewPopupToolbarStatus(false);   // 戻る・進む関連
            }
        }
        #endregion

        #region ▼SetToolBar(ツールバーアイコン設定)
        /// <summary>
        /// ツールバー設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : ツールバーのアイコン表示を行います。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/18</br>
        /// </remarks>
        private void SetToolbar()
        {
            // イメージリストを設定する
            Main_ToolbarsManager.ImageListSmall = this._imageList16;

            // ログイン担当者へのアイコン設定
            Infragistics.Win.UltraWinToolbars.LabelTool loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools["LoginTitle_LabelTool"];
            if (loginEmployeeLabel != null) loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            // ログイン担当者表示
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools["LoginName_LabelTool"];
            if (LoginInfoAcquisition.Employee != null)
            {
                if (loginNameLabel != null) loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            }

            // 終了のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool endButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["End_ButtonTool"];
            if (endButton != null) endButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;

            // 検索のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Search_ButtonTool"];
            if (searchButton != null) searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;

            // クリアのアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Clear_ButtonTool"];
            if (clearButton != null) clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;

            // --- ADD caohh 2011/08/10 ----------------------------->>>>>
            // 印刷のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool printButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Print_ButtonTool"];
            if (printButton != null) printButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;
            // --- ADD caohh 2011/08/10 -----------------------------<<<<<

            // 戻るのアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool beforeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Before_ButtonTool"];
            if (beforeButton != null) beforeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;

            // 進むのアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool nextButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Next_ButtonTool"];
            if (nextButton != null) nextButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEXT;
        }
        #endregion

        #region ▼GridInitializeLayout(グリッドレイアウト設定)
        /// <summary>
        /// グリッド初期設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッドの初期設定を行います。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/18</br>
        /// </remarks>
        private void GridInitializeLayout()
        {
            // 回答グリッド用DataSet作成
            DataTable dataTable = null;
            PMUOE01352EA.CreateDataTableDetail(ref dataTable);

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dataTable);
            this.Answer_Grid.DataSource = dataSet;

            this._gridStateController.SetGridStateToGrid(ref this.Answer_Grid);

            // 該当のグリッドコントロール取得
            UltraGrid grids = Answer_Grid;

            // 列情報作成
            int visiblePosition = 0;

            ColumnsCollection Columns = grids.DisplayLayout.Bands[PMUOE01352EA.ct_Tbl_OrderAnsDetail].Columns;

            #region 項目設定
            // 先頭列に番号表示(ヘッダーに『No.』などを表示する事は不可)
            grids.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex;
            grids.DisplayLayout.Override.RowSelectorWidth = GRIDCOLUMN_WIDTH1;
            grids.DisplayLayout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.SeparateElement;
            grids.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            grids.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            // UOE発注行番号
            Columns[PMUOE01352EA.ct_Col_UOESalesOrderRowNo].Hidden = true;
            Columns[PMUOE01352EA.ct_Col_UOESalesOrderRowNo].Header.Caption = "UOE発注行番号";
            Columns[PMUOE01352EA.ct_Col_UOESalesOrderRowNo].Width = GRIDCOLUMN_WIDTH2;
            Columns[PMUOE01352EA.ct_Col_UOESalesOrderRowNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[PMUOE01352EA.ct_Col_UOESalesOrderRowNo].CellActivation = Activation.NoEdit;
            Columns[PMUOE01352EA.ct_Col_UOESalesOrderRowNo].Header.VisiblePosition = visiblePosition++;

            // 受信日
            Columns[PMUOE01352EA.ct_Col_ReceiveDate].Header.Caption = "受信日";
            Columns[PMUOE01352EA.ct_Col_ReceiveDate].Width = GRIDCOLUMN_WIDTH3;
            Columns[PMUOE01352EA.ct_Col_ReceiveDate].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE01352EA.ct_Col_ReceiveDate].CellActivation = Activation.NoEdit;
            Columns[PMUOE01352EA.ct_Col_ReceiveDate].Header.VisiblePosition = visiblePosition++;

            // 発注品番
            Columns[PMUOE01352EA.ct_Col_GoodsNo].Header.Caption = "発注品番";
            Columns[PMUOE01352EA.ct_Col_GoodsNo].Width = GRIDCOLUMN_WIDTH4;
            Columns[PMUOE01352EA.ct_Col_GoodsNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE01352EA.ct_Col_GoodsNo].CellActivation = Activation.NoEdit;
            Columns[PMUOE01352EA.ct_Col_GoodsNo].Header.VisiblePosition = visiblePosition++;

            // 納品区分
            Columns[PMUOE01352EA.ct_Col_DeliGoodsDiv].Header.Caption = "納品区分";
            Columns[PMUOE01352EA.ct_Col_DeliGoodsDiv].Width = GRIDCOLUMN_WIDTH5;
            Columns[PMUOE01352EA.ct_Col_DeliGoodsDiv].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[PMUOE01352EA.ct_Col_DeliGoodsDiv].CellActivation = Activation.NoEdit;
            Columns[PMUOE01352EA.ct_Col_DeliGoodsDiv].Header.VisiblePosition = visiblePosition++;

            // 品名
            Columns[PMUOE01352EA.ct_Col_AnswerpartsName].Header.Caption = "品名";
            Columns[PMUOE01352EA.ct_Col_AnswerpartsName].Width = GRIDCOLUMN_WIDTH6;
            Columns[PMUOE01352EA.ct_Col_AnswerpartsName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE01352EA.ct_Col_AnswerpartsName].CellActivation = Activation.NoEdit;
            Columns[PMUOE01352EA.ct_Col_AnswerpartsName].Header.VisiblePosition = visiblePosition++;

            // 原単価
            Columns[PMUOE01352EA.ct_Col_AnswerSalesUnitCost].Header.Caption = "原単価";
            Columns[PMUOE01352EA.ct_Col_AnswerSalesUnitCost].Width = GRIDCOLUMN_WIDTH7;
            Columns[PMUOE01352EA.ct_Col_AnswerSalesUnitCost].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[PMUOE01352EA.ct_Col_AnswerSalesUnitCost].CellActivation = Activation.NoEdit;
            //2009/02/13 add start>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            Columns[PMUOE01352EA.ct_Col_AnswerSalesUnitCost].Format = "#,###,###";
            //2009/02/13 add end<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            Columns[PMUOE01352EA.ct_Col_AnswerSalesUnitCost].Header.VisiblePosition = visiblePosition++;

            // 伝票番号
            Columns[PMUOE01352EA.ct_Col_UOESectionSlipNo].Header.Caption = "伝票番号";
            Columns[PMUOE01352EA.ct_Col_UOESectionSlipNo].Width = GRIDCOLUMN_WIDTH8;
            Columns[PMUOE01352EA.ct_Col_UOESectionSlipNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[PMUOE01352EA.ct_Col_UOESectionSlipNo].CellActivation = Activation.NoEdit;
            Columns[PMUOE01352EA.ct_Col_UOESectionSlipNo].Header.VisiblePosition = visiblePosition++;

            // 倉庫・棚番
            Columns[PMUOE01352EA.ct_Col_UOECheckCode].Header.Caption = "倉庫・棚番";
            Columns[PMUOE01352EA.ct_Col_UOECheckCode].Width = GRIDCOLUMN_WIDTH9;
            Columns[PMUOE01352EA.ct_Col_UOECheckCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE01352EA.ct_Col_UOECheckCode].CellActivation = Activation.NoEdit;
            Columns[PMUOE01352EA.ct_Col_UOECheckCode].Header.VisiblePosition = visiblePosition++;

            // リマーク
            Columns[PMUOE01352EA.ct_Col_UoeRemark1].Header.Caption = "リマーク";
            Columns[PMUOE01352EA.ct_Col_UoeRemark1].Width = GRIDCOLUMN_WIDTH10;
            Columns[PMUOE01352EA.ct_Col_UoeRemark1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE01352EA.ct_Col_UoeRemark1].CellActivation = Activation.NoEdit;
            Columns[PMUOE01352EA.ct_Col_UoeRemark1].Header.VisiblePosition = visiblePosition++;


            // 回答番号
            Columns[PMUOE01352EA.ct_Col_UOESalesOrderNo].Header.Caption = "回答番号";
            Columns[PMUOE01352EA.ct_Col_UOESalesOrderNo].Width = GRIDCOLUMN_WIDTH3;
            Columns[PMUOE01352EA.ct_Col_UOESalesOrderNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[PMUOE01352EA.ct_Col_UOESalesOrderNo].CellActivation = Activation.NoEdit;
            //2009/02/13 add start>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            Columns[PMUOE01352EA.ct_Col_UOESalesOrderNo].Format = "00000000";
            //2009/02/13 add end<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            Columns[PMUOE01352EA.ct_Col_UOESalesOrderNo].Header.VisiblePosition = visiblePosition++;

            // 回答品番
            Columns[PMUOE01352EA.ct_Col_AnswerpartsNo].Header.Caption = "回答品番";
            Columns[PMUOE01352EA.ct_Col_AnswerpartsNo].Width = GRIDCOLUMN_WIDTH4;
            Columns[PMUOE01352EA.ct_Col_AnswerpartsNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE01352EA.ct_Col_AnswerpartsNo].CellActivation = Activation.NoEdit;
            Columns[PMUOE01352EA.ct_Col_AnswerpartsNo].Header.VisiblePosition = visiblePosition++;

            // 発注数
            Columns[PMUOE01352EA.ct_Col_AcceptAnOrderCnt].Header.Caption = "発注数";
            Columns[PMUOE01352EA.ct_Col_AcceptAnOrderCnt].Width = GRIDCOLUMN_WIDTH5;
            Columns[PMUOE01352EA.ct_Col_AcceptAnOrderCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[PMUOE01352EA.ct_Col_AcceptAnOrderCnt].CellActivation = Activation.NoEdit;
            Columns[PMUOE01352EA.ct_Col_AcceptAnOrderCnt].Header.VisiblePosition = visiblePosition++;

            // メーカー
            Columns[PMUOE01352EA.ct_Col_MakerName].Header.Caption = "メーカー";
            Columns[PMUOE01352EA.ct_Col_MakerName].Width = GRIDCOLUMN_WIDTH6;
            Columns[PMUOE01352EA.ct_Col_MakerName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE01352EA.ct_Col_MakerName].CellActivation = Activation.NoEdit;
            Columns[PMUOE01352EA.ct_Col_MakerName].Header.VisiblePosition = visiblePosition++;

            // 標準価格
            Columns[PMUOE01352EA.ct_Col_AnswerListPrice].Header.Caption = "標準価格";
            Columns[PMUOE01352EA.ct_Col_AnswerListPrice].Width = GRIDCOLUMN_WIDTH7;
            Columns[PMUOE01352EA.ct_Col_AnswerListPrice].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[PMUOE01352EA.ct_Col_AnswerListPrice].CellActivation = Activation.NoEdit;
            //2009/02/13 add start>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            Columns[PMUOE01352EA.ct_Col_AnswerListPrice].Format = "#,###,###";
            //2009/02/13 add end<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            Columns[PMUOE01352EA.ct_Col_AnswerListPrice].Header.VisiblePosition = visiblePosition++;

            // 出荷数
            Columns[PMUOE01352EA.ct_Col_UOESectOutGoodsCnt].Header.Caption = "出荷数";
            Columns[PMUOE01352EA.ct_Col_UOESectOutGoodsCnt].Width = GRIDCOLUMN_WIDTH8;
            Columns[PMUOE01352EA.ct_Col_UOESectOutGoodsCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[PMUOE01352EA.ct_Col_UOESectOutGoodsCnt].CellActivation = Activation.NoEdit;
            Columns[PMUOE01352EA.ct_Col_UOESectOutGoodsCnt].Header.VisiblePosition = visiblePosition++;

            // 残
            Columns[PMUOE01352EA.ct_Col_NonShipmentCnt].Header.Caption = "残";
            Columns[PMUOE01352EA.ct_Col_NonShipmentCnt].Width = GRIDCOLUMN_WIDTH9;
            Columns[PMUOE01352EA.ct_Col_NonShipmentCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[PMUOE01352EA.ct_Col_NonShipmentCnt].CellActivation = Activation.NoEdit;
            Columns[PMUOE01352EA.ct_Col_NonShipmentCnt].Header.VisiblePosition = visiblePosition++;

            // ラインメッセージ
            Columns[PMUOE01352EA.ct_Col_LineErrorMessage].Header.Caption = "ラインメッセージ";
            Columns[PMUOE01352EA.ct_Col_LineErrorMessage].Width = GRIDCOLUMN_WIDTH10;
            Columns[PMUOE01352EA.ct_Col_LineErrorMessage].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE01352EA.ct_Col_LineErrorMessage].CellActivation = Activation.NoEdit;
            Columns[PMUOE01352EA.ct_Col_LineErrorMessage].Header.VisiblePosition = visiblePosition++;

            // ------ ADD caohh ------>>>>>
            // 受信日(YY/MM/DD)
            Columns[PMUOE01352EA.ct_Col_ReceiveDateYMD].Hidden = true;
            Columns[PMUOE01352EA.ct_Col_ReceiveDateYMD].Header.Caption = "受信日(YY/MM/DD)";
            Columns[PMUOE01352EA.ct_Col_ReceiveDateYMD].Width = GRIDCOLUMN_WIDTH11;
            Columns[PMUOE01352EA.ct_Col_ReceiveDateYMD].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE01352EA.ct_Col_ReceiveDateYMD].CellActivation = Activation.NoEdit;
            Columns[PMUOE01352EA.ct_Col_ReceiveDateYMD].Header.VisiblePosition = visiblePosition++;

            // 受信時刻
            Columns[PMUOE01352EA.ct_Col_ReceiveTime].Hidden = true;
            Columns[PMUOE01352EA.ct_Col_ReceiveTime].Header.Caption = "受信時刻";
            Columns[PMUOE01352EA.ct_Col_ReceiveTime].Width = GRIDCOLUMN_WIDTH11;
            Columns[PMUOE01352EA.ct_Col_ReceiveTime].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE01352EA.ct_Col_ReceiveTime].CellActivation = Activation.NoEdit;
            Columns[PMUOE01352EA.ct_Col_ReceiveTime].Header.VisiblePosition = visiblePosition++;

            // 納品区分名称
            Columns[PMUOE01352EA.ct_Col_DeliveredGoodsDivNm].Hidden = true;
            Columns[PMUOE01352EA.ct_Col_DeliveredGoodsDivNm].Header.Caption = "納品区分名称";
            Columns[PMUOE01352EA.ct_Col_DeliveredGoodsDivNm].Width = GRIDCOLUMN_WIDTH11;
            Columns[PMUOE01352EA.ct_Col_DeliveredGoodsDivNm].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE01352EA.ct_Col_DeliveredGoodsDivNm].CellActivation = Activation.NoEdit;
            Columns[PMUOE01352EA.ct_Col_DeliveredGoodsDivNm].Header.VisiblePosition = visiblePosition++;

            // メーカーコード
            Columns[PMUOE01352EA.ct_Col_GoodsMakerCd].Hidden = true;
            Columns[PMUOE01352EA.ct_Col_GoodsMakerCd].Header.Caption = "メーカーコード";
            Columns[PMUOE01352EA.ct_Col_GoodsMakerCd].Width = GRIDCOLUMN_WIDTH11;
            Columns[PMUOE01352EA.ct_Col_GoodsMakerCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE01352EA.ct_Col_GoodsMakerCd].CellActivation = Activation.NoEdit;
            Columns[PMUOE01352EA.ct_Col_GoodsMakerCd].Header.VisiblePosition = visiblePosition++;
            // ------ ADD caohh ------<<<<<

            #endregion

            #region 項目表示位置設定
            // UOE発注行番号
            Columns[PMUOE01352EA.ct_Col_UOESalesOrderRowNo].RowLayoutColumnInfo.OriginX = 0;
            Columns[PMUOE01352EA.ct_Col_UOESalesOrderRowNo].RowLayoutColumnInfo.OriginY = 0;
            // 受信日
            Columns[PMUOE01352EA.ct_Col_ReceiveDate].RowLayoutColumnInfo.OriginX = 1;
            Columns[PMUOE01352EA.ct_Col_ReceiveDate].RowLayoutColumnInfo.OriginY = 0;
            // 発注品番
            Columns[PMUOE01352EA.ct_Col_GoodsNo].RowLayoutColumnInfo.OriginX = 2;
            Columns[PMUOE01352EA.ct_Col_GoodsNo].RowLayoutColumnInfo.OriginY = 0;
            // 納品区分
            Columns[PMUOE01352EA.ct_Col_DeliGoodsDiv].RowLayoutColumnInfo.OriginX = 3;
            Columns[PMUOE01352EA.ct_Col_DeliGoodsDiv].RowLayoutColumnInfo.OriginY = 0;
            // 品名
            Columns[PMUOE01352EA.ct_Col_AnswerpartsName].RowLayoutColumnInfo.OriginX = 4;
            Columns[PMUOE01352EA.ct_Col_AnswerpartsName].RowLayoutColumnInfo.OriginY = 0;
            // 原単価
            //2009/02/13 UPD start>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //Columns[PMUOE01352EA.ct_Col_AnswerSalesUnitCost].RowLayoutColumnInfo.OriginX = 5;
            //Columns[PMUOE01352EA.ct_Col_AnswerSalesUnitCost].RowLayoutColumnInfo.OriginY = 0;
            Columns[PMUOE01352EA.ct_Col_AnswerSalesUnitCost].RowLayoutColumnInfo.OriginX = 5;
            Columns[PMUOE01352EA.ct_Col_AnswerSalesUnitCost].RowLayoutColumnInfo.OriginY = 1;
            //2009/02/13 UPD end<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            // 伝票番号
            Columns[PMUOE01352EA.ct_Col_UOESectionSlipNo].RowLayoutColumnInfo.OriginX = 6;
            Columns[PMUOE01352EA.ct_Col_UOESectionSlipNo].RowLayoutColumnInfo.OriginY = 0;
            // 倉庫・棚番
            Columns[PMUOE01352EA.ct_Col_UOECheckCode].RowLayoutColumnInfo.OriginX = 7;
            Columns[PMUOE01352EA.ct_Col_UOECheckCode].RowLayoutColumnInfo.OriginY = 0;
            // リマーク
            Columns[PMUOE01352EA.ct_Col_UoeRemark1].RowLayoutColumnInfo.OriginX = 8;
            Columns[PMUOE01352EA.ct_Col_UoeRemark1].RowLayoutColumnInfo.OriginY = 0;
            // 回答番号
            Columns[PMUOE01352EA.ct_Col_UOESalesOrderNo].RowLayoutColumnInfo.OriginX = 1;
            Columns[PMUOE01352EA.ct_Col_UOESalesOrderNo].RowLayoutColumnInfo.OriginY = 1;
            // 回答品番
            Columns[PMUOE01352EA.ct_Col_AnswerpartsNo].RowLayoutColumnInfo.OriginX = 2;
            Columns[PMUOE01352EA.ct_Col_AnswerpartsNo].RowLayoutColumnInfo.OriginY = 1;
            // 発注数
            Columns[PMUOE01352EA.ct_Col_AcceptAnOrderCnt].RowLayoutColumnInfo.OriginX = 3;
            Columns[PMUOE01352EA.ct_Col_AcceptAnOrderCnt].RowLayoutColumnInfo.OriginY = 1;
            // メーカー
            Columns[PMUOE01352EA.ct_Col_MakerName].RowLayoutColumnInfo.OriginX = 4;
            Columns[PMUOE01352EA.ct_Col_MakerName].RowLayoutColumnInfo.OriginY = 1;
            // 標準価格
            //2009/02/13 UPD start>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //Columns[PMUOE01352EA.ct_Col_AnswerListPrice].RowLayoutColumnInfo.OriginX = 5;
            //Columns[PMUOE01352EA.ct_Col_AnswerListPrice].RowLayoutColumnInfo.OriginY = 1;
            Columns[PMUOE01352EA.ct_Col_AnswerListPrice].RowLayoutColumnInfo.OriginX = 5;
            Columns[PMUOE01352EA.ct_Col_AnswerListPrice].RowLayoutColumnInfo.OriginY = 0;
            //2009/02/13 UPD end<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            // 出荷数
            Columns[PMUOE01352EA.ct_Col_UOESectOutGoodsCnt].RowLayoutColumnInfo.OriginX = 6;
            Columns[PMUOE01352EA.ct_Col_UOESectOutGoodsCnt].RowLayoutColumnInfo.OriginY = 1;
            // 残
            Columns[PMUOE01352EA.ct_Col_NonShipmentCnt].RowLayoutColumnInfo.OriginX = 7;
            Columns[PMUOE01352EA.ct_Col_NonShipmentCnt].RowLayoutColumnInfo.OriginY = 1;
            // ラインメッセージ
            Columns[PMUOE01352EA.ct_Col_LineErrorMessage].RowLayoutColumnInfo.OriginX = 8;
            Columns[PMUOE01352EA.ct_Col_LineErrorMessage].RowLayoutColumnInfo.OriginY = 1;
            // ------ ADD caohh ------>>>>>
            // 受信日(YY/MM/DD)
            Columns[PMUOE01352EA.ct_Col_ReceiveDateYMD].RowLayoutColumnInfo.OriginX = 9;
            Columns[PMUOE01352EA.ct_Col_ReceiveDateYMD].RowLayoutColumnInfo.OriginY = 0;
            // 受信時刻
            Columns[PMUOE01352EA.ct_Col_ReceiveTime].RowLayoutColumnInfo.OriginX = 9;
            Columns[PMUOE01352EA.ct_Col_ReceiveTime].RowLayoutColumnInfo.OriginY = 1;
            // 納品区分名称
            Columns[PMUOE01352EA.ct_Col_DeliveredGoodsDivNm].RowLayoutColumnInfo.OriginX = 10;
            Columns[PMUOE01352EA.ct_Col_DeliveredGoodsDivNm].RowLayoutColumnInfo.OriginY = 0;
            // メーカーコード
            Columns[PMUOE01352EA.ct_Col_GoodsMakerCd].RowLayoutColumnInfo.OriginX = 10;
            Columns[PMUOE01352EA.ct_Col_GoodsMakerCd].RowLayoutColumnInfo.OriginY = 1;
            // ------ ADD caohh ------<<<<<
            #endregion

            // Group設定(1明細2行にする為)
            if (grids.DisplayLayout.Bands[PMUOE01352EA.ct_Tbl_OrderAnsDetail].Groups.Count == 0)
            {
                UltraGridBand ultraGriBand = grids.DisplayLayout.Bands[PMUOE01352EA.ct_Tbl_OrderAnsDetail];
                ultraGriBand.Groups.Add(PMUOE01352EA.ct_Grp_OrderAnsDeltail);   // GridのBandにGroup追加
                ultraGriBand.UseRowLayout = true;                               // 位置情報(RowLayoutColumnInfo)を使用
                ultraGriBand.GroupHeadersVisible = false;                       // ヘッダー非表示
                ultraGriBand.LevelCount = 2;                                    // 行数を2行に設定

                UltraGridGroup ultraGridGroup = ultraGriBand.Groups[PMUOE01352EA.ct_Grp_OrderAnsDeltail];
                foreach (UltraGridColumn ultraGridColumn in Columns)
                {
                    // 共通設定
                    ultraGridColumn.RowLayoutColumnInfo.SpanX = 1;
                    ultraGridColumn.RowLayoutColumnInfo.SpanY = 1;

                    switch (ultraGridColumn.Key)
                    {
                        case PMUOE01352EA.ct_Col_UOESalesOrderRowNo:
                        case PMUOE01352EA.ct_Col_ForeColor:
                            {
                                ultraGridColumn.RowLayoutColumnInfo.SpanY = 2;
                                break;
                            }
                    }

                    // GroupにColumnを追加
                    ultraGridGroup.Columns.Add(ultraGridColumn);
                }
            }
        }
        #endregion 

        #region ▼Search(データ検索、表示)
        /// <summary>
        /// 検索
        /// </summary>
        /// <param name="searchMode">0：初期表示、1：前データ、2：次データ</param>
        /// <remarks>
        /// <br>Note       : データの取得、表示を行います。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/18</br>
        /// </remarks>
        private void Search(int searchMode)
        {
            bool status = false;
            DataSet dataSet1 = null;
            DataSet dataSet2 = null;
            
            switch (searchMode)
            {
                // 初期
                case SEARCH_FIRST:
                    {
                        status = this._orderAnswerAcs.SearchFirst(out dataSet1,out dataSet2);
                        break;
                    }
                // 前データ
                case SEARCH_BEFORE:
                    {
                        status = this._orderAnswerAcs.SearchBefore(out dataSet1,out dataSet2);
                        if (status == false)
                        {
                            // 先頭データです。
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.ToString(), MSG_NODATA_BEFORE, 0, MessageBoxButtons.OK);
                        }
                        break;
                    }
                // 次データ
                case SEARCH_NEXT:
                    {
                        status = this._orderAnswerAcs.SearchNext(out dataSet1,out dataSet2);
                        if (status == false)
                        {
                            // データが終了しました。
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.ToString(), MSG_NODATA_NEXT, 0, MessageBoxButtons.OK);
                        }
                        break;
                    }
            }

            // データ表示
            if (status)
            {
                this.Answer_Grid.DataSource = dataSet2;     // 明細表示
            }
        }
        #endregion


        #region ▼ChangeViewPopupToolbarStatus(戻る・進むボタン表示/非表示)
        /// <summary>
        /// 戻る・進むボタン表示設定
        /// </summary>
        /// <param name="flg">True：表示、False：非表示</param>
        /// <remarks>
        /// <br>Note       : 戻る・進むボタンの表示/非表示設定を行います。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/18</br>
        /// </remarks>
        private void ChangeViewPopupToolbarStatus(bool flg)
        {
            this.Main_ToolbarsManager.Tools["View_PopupMenuTool"].SharedProps.Visible = flg;    // 表示(V)
            this.Main_ToolbarsManager.Tools["LabelTool1"].SharedProps.Visible = flg;            // |　(区切り線)
            this.Main_ToolbarsManager.Tools["Before_ButtonTool"].SharedProps.Visible = flg;     // 戻る
            this.Main_ToolbarsManager.Tools["Next_ButtonTool"].SharedProps.Visible = flg;       // 進む
        }
        #endregion

        #region ▼ChangeSearchConditionStatus(検索関連表示/非表示)
        /// <summary>
        /// 検索関連表示設定
        /// </summary>
        /// <param name="flg">True：表示、False：非表示</param>
        /// <remarks>
        /// <br>Note       : 検索関連の表示/非表示設定を行います。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/18</br>
        /// </remarks>
        private void ChangeSearchConditionStatus(bool flg)
        {
            this.Main_ToolbarsManager.Tools["Search_ButtonTool"].SharedProps.Visible = flg;     // 検索ボタン
            this.Main_ToolbarsManager.Tools["Clear_ButtonTool"].SharedProps.Visible = flg;      // クリアボタン
            this.Main_ToolbarsManager.Tools["Print_ButtonTool"].SharedProps.Enabled = !flg;     // 印刷ボタン　// ADD caohh 2011/08/10
            pnl_SearchCondition.Visible = flg;                                                  // 検索条件
        }

        #endregion


        #region ▼ToolbarSearchClick(単体起動専用)
        /// <summary>
        /// ツールバーの検索ボタン押下時処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 発注データを送受信ジャーナル(発注)形式に変換後、データの取得を行います。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/18</br>
        /// </remarks>
        private void ToolbarSearchClick()
        {
            string errorMsg;

            // 発注日チェック
            if (this.CheckConditionSalesDay() == CHECKDATA_FAILED)
            {
                return;
            }
            // 発注先チェック
            int Supplierstatus = this.CheckConditionSupplier();
            if (Supplierstatus == CHECKDATA_FAILED)
            {
                return;
            }
            else if (Supplierstatus == CHECKDATA_CNDTNEMPTY)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.ToString(), "発注先を入力してください", 0, MessageBoxButtons.OK);
                return;
            }
            
            // 抽出条件設定
            UOEAnswerLedgerOrderCndtn uoeAnswerLedgerOrderCndtn = new UOEAnswerLedgerOrderCndtn();
            uoeAnswerLedgerOrderCndtn.EnterpriseCode = this._enterpriseCode;            // 企業コード
            uoeAnswerLedgerOrderCndtn.SectionCode = this._sectionCode.TrimEnd();        // 拠点コード
            uoeAnswerLedgerOrderCndtn.SystemDivCd = -1;                                 // システム区分(-1：全て)
            uoeAnswerLedgerOrderCndtn.St_ReceiveDate = DateTime.ParseExact(this._backup.SalesDaySt.ToString(), "yyyyMMdd", null);   // 開始発注日
            uoeAnswerLedgerOrderCndtn.Ed_ReceiveDate = DateTime.ParseExact(this._backup.SalesDayEd.ToString(), "yyyyMMdd", null);   // 終了発注日
            uoeAnswerLedgerOrderCndtn.UOESupplierCd = this._backup.SupplierCd;          // 発注先コード
            uoeAnswerLedgerOrderCndtn.UOEKind = 1;                                 // UOE種別(1:卸商仕入回答表示)
            uoeAnswerLedgerOrderCndtn.St_InputDay = DateTime.ParseExact(this._backup.InputDaySt.ToString(), "yyyyMMdd", null);   // 開始処理日
            uoeAnswerLedgerOrderCndtn.Ed_InputDay = DateTime.ParseExact(this._backup.InputDayEd.ToString(), "yyyyMMdd", null);   // 終了処理日
            // データ取得
            bool status = this._orderAnswerAcs.SearchFirst(uoeAnswerLedgerOrderCndtn, out errorMsg);
            if (status == false)
            {
                this.AllInitializeLayout(SEARCHCONDITION_NO_CLEAR);

                // エラー時メッセージ表示
                if (string.IsNullOrEmpty(errorMsg) == false)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.ToString(), errorMsg, 0, MessageBoxButtons.OK);
                }
                return;
            }

            // データ表示
            this.Search(SEARCH_FIRST);

            // --- ADD caohh 2011/08/10 ----------------------------->>>>>
            if (this.Answer_Grid.DataSource != null) 
            {
                this.Main_ToolbarsManager.Tools["Print_ButtonTool"].SharedProps.Enabled = true;     // 印刷ボタン
            }
            // --- ADD caohh 2011/08/10 -----------------------------<<<<<

            this.ChangeViewPopupToolbarStatus(true);
        }
        #endregion

        #region ▼ToolbarClearClick(単体起動専用)
        /// <summary>
        /// ツールバーのクリアボタン押下時処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面表示を初期状態に戻します。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/18</br>
        /// </remarks>
        private void ToolbarClearClick()
        {
            this.AllInitializeLayout(SEARCHCONDITION_CLEAR);

            this.tde_st_SalesDay.Focus();
        }

        #endregion

        // --- ADD caohh 2011/08/10 ----------------------------->>>>>
        #region ▼ToolbarPrintClick(単体起動専用)
        /// <summary>
        /// ツールバーの印刷ボタン押下時処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面データを印刷します。</br>
        /// <br>Programmer	: caohh</br>
        /// <br>Date		: 2011/08/10</br>
        /// </remarks>
        private void ToolbarPrintClick(ref SFCMN06002C parameter)
        {
            SFCMN06001U printDialog = new SFCMN06001U();		// 帳票選択ガイド
            SFCMN06002C printInfo = parameter;

            // 企業コードをセット
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = PG_ID;				       // 起動PGID
            printInfo.key = this._printKey;
            printInfo.prpnm = this._printName;
            DataView dv = new DataView(((DataSet)this.Answer_Grid.DataSource).Tables[0]);
            printInfo.rdData = dv;

            // 抽出条件の設定
            _uOEAnswerLedgerOrderCndtn = new UOEAnswerLedgerOrderCndtn();
            _uOEAnswerLedgerOrderCndtn.EnterpriseCode = this._enterpriseCode;            // 企業コード
            _uOEAnswerLedgerOrderCndtn.SectionCode = this._sectionCode.TrimEnd();        // 拠点コード
            _uOEAnswerLedgerOrderCndtn.UOESupplierCd = this.tNedit_SupplierCd.GetInt();  // 発注先コード
            _uOEAnswerLedgerOrderCndtn.UOESupplierName = this.lb_SupplierName.Text;      // 発注先名称

            printInfo.jyoken = this._uOEAnswerLedgerOrderCndtn;
            printDialog.PrintInfo = printInfo;

            // 帳票選択ガイド
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", 0);
            }

            parameter = printInfo;

            //return printInfo.status;
        }

        #region エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note        : エラーメッセージ表示処理</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/08/10</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                PG_ID,						        // アセンブリＩＤまたはクラスＩＤ
                PG_NM,				                // プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
        #endregion

        #endregion
        // --- ADD caohh 2011/08/10 -----------------------------<<<<<

        #region ▼CheckConditionSalesDay(発注日入力チェック　単体起動専用)
        /// <summary>
        /// 発注日入力チェック
        /// </summary>
        /// <returns>-1：NG、0：未入力、1：OK</returns>
        /// <remarks>
        /// <br>Note       : 発注日の入力チェックを行います。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/18</br>
        /// </remarks>
        private int CheckConditionSalesDay()
        {
            // 日付必須チェック
            if (this.tde_st_SalesDay.GetDateTime() == DateTime.MinValue)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.ToString(), "発注日開始の入力が不正です", 0, MessageBoxButtons.OK);
                this.tde_st_SalesDay.Focus();
                return CHECKDATA_FAILED;
            }
            if (this.tde_ed_SalesDay.GetDateTime() == DateTime.MinValue)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.ToString(), "発注日終了の入力が不正です", 0, MessageBoxButtons.OK);
                this.tde_ed_SalesDay.Focus();
                return CHECKDATA_FAILED;
            }
            if (this.tde_st_InputDay.GetDateTime() == DateTime.MinValue)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.ToString(), "処理日開始の入力が不正です", 0, MessageBoxButtons.OK);
                this.tde_st_InputDay.Focus();
                return CHECKDATA_FAILED;
            }
            if (this.tde_ed_InputDay.GetDateTime() == DateTime.MinValue)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.ToString(), "処理日終了の入力が不正です", 0, MessageBoxButtons.OK);
                this.tde_ed_SalesDay.Focus();
                return CHECKDATA_FAILED;
            }
            // 日付大小チェック
            if (this.tde_st_SalesDay.GetLongDate() > tde_ed_SalesDay.GetLongDate())
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.ToString(), "発注日は開始≦終了となるように入力して下さい", 0, MessageBoxButtons.OK);
                this.tde_st_SalesDay.Focus();
                return CHECKDATA_FAILED;
            }
            if (this.tde_st_InputDay.GetLongDate() > tde_ed_InputDay.GetLongDate())
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.ToString(), "処理日は開始≦終了となるように入力して下さい", 0, MessageBoxButtons.OK);
                this.tde_st_InputDay.Focus();
                return CHECKDATA_FAILED;
            }

            // 日付範囲チェック
            if (this.tde_st_SalesDay.GetDateTime().AddMonths(3) < tde_ed_SalesDay.GetDateTime())
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.ToString(), "発注日の日付範囲が広すぎます。３ヶ月以内で設定してください", 0, MessageBoxButtons.OK);
                this.tde_st_SalesDay.Focus();
                return CHECKDATA_FAILED;
            }
            if (this.tde_st_InputDay.GetDateTime().AddMonths(3) < tde_ed_InputDay.GetDateTime())
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.ToString(), "処理日の日付範囲が広すぎます。３ヶ月以内で設定してください", 0, MessageBoxButtons.OK);
                this.tde_st_InputDay.Focus();
                return CHECKDATA_FAILED;
            }

            return CHECKDATA_SUCCESS;
        }
        #endregion

        #region ▼CheckConditionSupplier(発注先入力チェック　単体起動専用)
        /// <summary>
        /// 発注先入力チェック
        /// </summary>
        /// <returns>-1：NG、0：未入力、1：OK</returns>
        /// <remarks>
        /// <br>Note       : 発注先の入力チェックを行います。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/18</br>
        /// </remarks>
        private int CheckConditionSupplier()
        {
            if (this.tNedit_SupplierCd.GetInt() == 0)
            {
                this.lb_SupplierName.Text = string.Empty;
                return CHECKDATA_CNDTNEMPTY;
            }

            string name = this._orderAnswerAcs.GetUOESupplierName(this.tNedit_SupplierCd.GetInt());
            if (string.IsNullOrEmpty(name))
            {
                // 値なし
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.ToString(), "発注先 [" + this.tNedit_SupplierCd.Value.ToString() + "] に該当するデータが存在しません。", 0, MessageBoxButtons.OK);
                this.tNedit_SupplierCd.Focus();
                return CHECKDATA_FAILED;
            }

            this.lb_SupplierName.Text = name;
            return CHECKDATA_SUCCESS;
        }
        #endregion

        // 入力値リカバリー関連
        #region ▼BackupInputValue(入力値の保持－全て)
        /// <summary>
        /// 入力値保存
        /// </summary>
        /// <remarks>
        /// <br>Note		: 入力値を保存します。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/18</br>
        /// </remarks>
        private void BackupInputValueAll()
        {
            this.BackupInputValue(this.tde_st_SalesDay);        // 発注日From
            this.BackupInputValue(this.tde_ed_SalesDay);        // 発注日To
            this.BackupInputValue(this.tNedit_SupplierCd);      // 発注先
            this.BackupInputValue(this.tde_st_InputDay);        // 処理日From
            this.BackupInputValue(this.tde_ed_InputDay);        // 処理日To
        }
        #endregion

        #region ▼BackupInputValue(入力値の保持－単体)
        /// <summary>
        /// 入力値保存
        /// </summary>
        /// <param name="ctrl">対象コントロール</param>
        /// <remarks>
        /// <br>Note		: 入力値を保存します。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/18</br>
        /// </remarks>
        private void BackupInputValue(Control ctrl)
        {
            // 発注日From
            if (ctrl == this.tde_st_SalesDay)
            {
                this._backup.SalesDaySt = this.tde_st_SalesDay.GetLongDate();
                return;
            }

            // 発注日To
            if (ctrl == this.tde_ed_SalesDay)
            {
                this._backup.SalesDayEd = this.tde_ed_SalesDay.GetLongDate();
                return;
            }
            // 処理日From
            if (ctrl == this.tde_st_InputDay)
            {
                this._backup.InputDaySt = this.tde_st_InputDay.GetLongDate();
                return;
            }

            // 処理日To
            if (ctrl == this.tde_ed_InputDay)
            {
                this._backup.InputDayEd = this.tde_ed_InputDay.GetLongDate();
                return;
            }
            // 発注先
            if (ctrl == this.tNedit_SupplierCd)
            {
                this._backup.SupplierCd = this.tNedit_SupplierCd.GetInt();
                this._backup.SupplierName = this.lb_SupplierName.Text;
                return;
            }
        }
        #endregion

        #region ▼RecoverInputValue(保持した値に戻す)
        /// <summary>
        /// 入力値リカバリー
        /// </summary>
        /// <param name="ctrl">対象コントロール</param>
        /// <remarks>
        /// <br>Note		: 入力値を入力前の値に戻します。</br>
        /// <br>Programmer	: 渋谷 大輔</br>
        /// <br>Date		: 2008/12/18</br>
        /// </remarks>
        private void RecoverInputValue(Control ctrl)
        {
            // 発注日From
            if (ctrl == this.tde_st_SalesDay)
            {
                this.tde_st_SalesDay.SetLongDate(this._backup.SalesDaySt);
                return;
            }
            // 発注日To
            if (ctrl == this.tde_ed_SalesDay)
            {
                this.tde_ed_SalesDay.SetLongDate(this._backup.SalesDayEd);
                return;
            }
            // 処理日From
            if (ctrl == this.tde_st_InputDay)
            {
                this.tde_st_InputDay.SetLongDate(this._backup.InputDaySt);
                return;
            }
            // 処理日To
            if (ctrl == this.tde_ed_InputDay)
            {
                this.tde_ed_InputDay.SetLongDate(this._backup.InputDayEd);
                return;
            }

            // 発注先
            if (ctrl == this.tNedit_SupplierCd)
            {
                if (this._backup.SupplierCd == 0)
                {
                    this.tNedit_SupplierCd.Clear();
                    this.lb_SupplierName.Text = string.Empty;
                }
                else
                {
                    this.tNedit_SupplierCd.Value = this._backup.SupplierCd;
                    this.lb_SupplierName.Text = this._backup.SupplierName;
                }
                return;
            }
        }
        #endregion

        #endregion ■Privateメソッド - end
    }
}
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
    /// �݌ɉ񓚕\���@UI�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note		: �݌ɉ񓚕\���@UI�N���X</br>
	/// <br>Programmer	: �Ɠc �M�u</br>
	/// <br>Date		: 2008/11/10</br>
    /// <br></br>
    /// <br>UpdateNote  : 2009/02/03 �Ɠc �M�u�@�s��Ή�[10841]</br>
    /// <br></br>
    /// <br>UpdateNote  : 2012/07/13 30517 �Ė� �x��</br>
    /// <br>              �d�������������_�ȉ��\���\�ɏC��</br>
    /// </remarks>
	public class PMUOE04121UA : System.Windows.Forms.Form
	{
        #region ��Private Members (Component)
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
        private Infragistics.Win.Misc.UltraLabel lb_UOESupplierName;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel lb_Remark2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel lb_Remark1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Panel panel2;
        private Panel panel4;
        private Panel panel3;
        private UltraGrid Section_Grid;
        private UltraGrid Answer_Grid;
		private System.ComponentModel.IContainer components;
        #endregion

        #region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h
        /// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
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
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel6 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel7 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel8 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel9 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Before_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Next_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool5 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool6 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool7 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Print_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboBoxTool2 = new Infragistics.Win.UltraWinToolbars.ComboBoxTool("Section_ComboBoxTool");
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(0);
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool8 = new Infragistics.Win.UltraWinToolbars.LabelTool("SectionTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("TextOut_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Before_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Next_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Preview_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("View_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Before_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Next_ButtonTool");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMUOE04121UA));
            this.FontSize_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.AutoFitCol_ultraCheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_Remark2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.lb_Remark1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.lb_UOESupplierName = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.tMemPos1 = new Broadleaf.Library.Windows.Forms.TMemPos(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.ultraToolbarsDockArea3 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsDockArea2 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsDockArea1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Section_Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Answer_Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this._SFTOK01101UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Main_ToolbarsManager = new Broadleaf.Library.Windows.Forms.TToolbarsManager(this.components);
            this._SFTOK01101UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFTOK01101UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFTOK01101UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.FontSize_tComboEditor)).BeginInit();
            this.ultraStatusBar1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Section_Grid)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Answer_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).BeginInit();
            this.SuspendLayout();
            // 
            // FontSize_tComboEditor
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.FontSize_tComboEditor.ActiveAppearance = appearance1;
            this.FontSize_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.FontSize_tComboEditor.Font = new System.Drawing.Font("�l�r �S�V�b�N", 7.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.FontSize_tComboEditor.TabIndex = 71;
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
            this.AutoFitCol_ultraCheckEditor.TabIndex = 80;
            this.AutoFitCol_ultraCheckEditor.Text = "��T�C�Y�̎�������";
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
            ultraStatusPanel1.Text = "�����T�C�Y";
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
            appearance24.FontData.SizeInPoints = 9F;
            ultraStatusPanel5.Appearance = appearance24;
            ultraStatusPanel5.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel5.Key = "StatusBarPanel_Text";
            ultraStatusPanel5.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel5.Width = 200;
            appearance38.FontData.SizeInPoints = 9F;
            ultraStatusPanel6.Appearance = appearance38;
            ultraStatusPanel6.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel6.Key = "StatusBarPanel_update";
            appearance39.FontData.ItalicAsString = "False";
            ultraStatusPanel7.Appearance = appearance39;
            ultraStatusPanel7.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel7.Key = "StatusBarPanel_Progress";
            appearance40.FontData.BoldAsString = "False";
            appearance40.FontData.SizeInPoints = 10F;
            ultraStatusPanel7.ProgressBarInfo.Appearance = appearance40;
            appearance41.FontData.BoldAsString = "True";
            appearance41.FontData.SizeInPoints = 9F;
            appearance41.ForeColor = System.Drawing.Color.Black;
            ultraStatusPanel7.ProgressBarInfo.FillAppearance = appearance41;
            ultraStatusPanel7.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Progress;
            ultraStatusPanel7.Visible = false;
            ultraStatusPanel7.Width = 158;
            ultraStatusPanel8.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel8.Key = "StatusBarPanel_Date";
            ultraStatusPanel8.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Date;
            ultraStatusPanel8.Width = 90;
            ultraStatusPanel9.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel9.Key = "StatusBarPanel_Time";
            ultraStatusPanel9.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Time;
            ultraStatusPanel9.Width = 50;
            this.ultraStatusBar1.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3,
            ultraStatusPanel4,
            ultraStatusPanel5,
            ultraStatusPanel6,
            ultraStatusPanel7,
            ultraStatusPanel8,
            ultraStatusPanel9});
            this.ultraStatusBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ultraStatusBar1.Size = new System.Drawing.Size(1016, 23);
            this.ultraStatusBar1.TabIndex = 70;
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
            this.panel1.Controls.Add(this.lb_Remark2);
            this.panel1.Controls.Add(this.ultraLabel3);
            this.panel1.Controls.Add(this.lb_Remark1);
            this.panel1.Controls.Add(this.ultraLabel2);
            this.panel1.Controls.Add(this.lb_UOESupplierName);
            this.panel1.Controls.Add(this.ultraLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 96);
            this.panel1.TabIndex = 0;
            // 
            // lb_Remark2
            // 
            appearance58.TextHAlignAsString = "Left";
            appearance58.TextVAlignAsString = "Middle";
            this.lb_Remark2.Appearance = appearance58;
            this.lb_Remark2.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_Remark2.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.lb_Remark2.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_Remark2.Location = new System.Drawing.Point(491, 65);
            this.lb_Remark2.Margin = new System.Windows.Forms.Padding(4);
            this.lb_Remark2.Name = "lb_Remark2";
            this.lb_Remark2.Size = new System.Drawing.Size(90, 24);
            this.lb_Remark2.TabIndex = 123;
            // 
            // ultraLabel3
            // 
            appearance80.TextHAlignAsString = "Center";
            appearance80.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance80;
            this.ultraLabel3.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(207)))), ((int)(((byte)(247)))));
            this.ultraLabel3.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel3.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel3.Location = new System.Drawing.Point(491, 43);
            this.ultraLabel3.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(90, 24);
            this.ultraLabel3.TabIndex = 122;
            this.ultraLabel3.Text = "���}�[�N2";
            // 
            // lb_Remark1
            // 
            appearance81.TextHAlignAsString = "Left";
            appearance81.TextVAlignAsString = "Middle";
            this.lb_Remark1.Appearance = appearance81;
            this.lb_Remark1.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_Remark1.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.lb_Remark1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_Remark1.Location = new System.Drawing.Point(325, 65);
            this.lb_Remark1.Margin = new System.Windows.Forms.Padding(4);
            this.lb_Remark1.Name = "lb_Remark1";
            this.lb_Remark1.Size = new System.Drawing.Size(169, 24);
            this.lb_Remark1.TabIndex = 121;
            // 
            // ultraLabel2
            // 
            appearance82.TextHAlignAsString = "Center";
            appearance82.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance82;
            this.ultraLabel2.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(207)))), ((int)(((byte)(247)))));
            this.ultraLabel2.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel2.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel2.Location = new System.Drawing.Point(325, 43);
            this.ultraLabel2.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(169, 24);
            this.ultraLabel2.TabIndex = 120;
            this.ultraLabel2.Text = "���}�[�N1";
            // 
            // lb_UOESupplierName
            // 
            appearance83.TextHAlignAsString = "Left";
            appearance83.TextVAlignAsString = "Middle";
            this.lb_UOESupplierName.Appearance = appearance83;
            this.lb_UOESupplierName.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_UOESupplierName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.lb_UOESupplierName.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_UOESupplierName.Location = new System.Drawing.Point(4, 65);
            this.lb_UOESupplierName.Margin = new System.Windows.Forms.Padding(4);
            this.lb_UOESupplierName.Name = "lb_UOESupplierName";
            this.lb_UOESupplierName.Size = new System.Drawing.Size(323, 24);
            this.lb_UOESupplierName.TabIndex = 119;
            this.lb_UOESupplierName.WrapText = false;
            // 
            // ultraLabel1
            // 
            appearance84.TextHAlignAsString = "Center";
            appearance84.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance84;
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(207)))), ((int)(((byte)(247)))));
            this.ultraLabel1.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel1.Location = new System.Drawing.Point(4, 43);
            this.ultraLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(323, 24);
            this.ultraLabel1.TabIndex = 118;
            this.ultraLabel1.Text = "������";
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
            // ultraToolbarsDockArea3
            // 
            this.ultraToolbarsDockArea3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.ultraToolbarsDockArea3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this.ultraToolbarsDockArea3.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this.ultraToolbarsDockArea3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ultraToolbarsDockArea3.Location = new System.Drawing.Point(1016, 63);
            this.ultraToolbarsDockArea3.Name = "ultraToolbarsDockArea3";
            this.ultraToolbarsDockArea3.Size = new System.Drawing.Size(0, 648);
            this.ultraToolbarsDockArea3.ToolbarsManager = this.Main_ToolbarsManager;
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
            this.ultraToolbarsDockArea2.ToolbarsManager = this.Main_ToolbarsManager;
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
            this.ultraToolbarsDockArea1.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 690);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1016, 21);
            this.panel2.TabIndex = 23;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Section_Grid);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(825, 159);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(191, 531);
            this.panel3.TabIndex = 65;
            // 
            // Section_Grid
            // 
            this.Section_Grid.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance12.BackColor = System.Drawing.Color.White;
            appearance12.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Section_Grid.DisplayLayout.Appearance = appearance12;
            this.Section_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.Section_Grid.DisplayLayout.GroupByBox.Hidden = true;
            this.Section_Grid.DisplayLayout.InterBandSpacing = 10;
            appearance13.ForeColor = System.Drawing.Color.Black;
            this.Section_Grid.DisplayLayout.Override.ActiveRowAppearance = appearance13;
            this.Section_Grid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.Section_Grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.Section_Grid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.Section_Grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            appearance14.BackColor = System.Drawing.Color.Transparent;
            this.Section_Grid.DisplayLayout.Override.CardAreaAppearance = appearance14;
            this.Section_Grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance15.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance15.ForeColor = System.Drawing.Color.White;
            appearance15.TextHAlignAsString = "Center";
            appearance15.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.Section_Grid.DisplayLayout.Override.HeaderAppearance = appearance15;
            this.Section_Grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance16.BackColor = System.Drawing.Color.Lavender;
            this.Section_Grid.DisplayLayout.Override.RowAlternateAppearance = appearance16;
            appearance17.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.Section_Grid.DisplayLayout.Override.RowAppearance = appearance17;
            this.Section_Grid.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.Section_Grid.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance18.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Section_Grid.DisplayLayout.Override.RowSelectorAppearance = appearance18;
            this.Section_Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.Section_Grid.DisplayLayout.Override.RowSelectorWidth = 12;
            this.Section_Grid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance19.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance19.ForeColor = System.Drawing.Color.Black;
            this.Section_Grid.DisplayLayout.Override.SelectedRowAppearance = appearance19;
            this.Section_Grid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.Section_Grid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.Section_Grid.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.ExtendedAutoDrag;
            this.Section_Grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.Section_Grid.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.Section_Grid.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.Section_Grid.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.Both;
            this.Section_Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.Section_Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.Section_Grid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.Section_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Section_Grid.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Section_Grid.Location = new System.Drawing.Point(0, 0);
            this.Section_Grid.Name = "Section_Grid";
            this.Section_Grid.Size = new System.Drawing.Size(191, 531);
            this.Section_Grid.TabIndex = 2;
            this.Section_Grid.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.Section_Grid_InitializeLayout);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.Answer_Grid);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 159);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(825, 531);
            this.panel4.TabIndex = 61;
            // 
            // Answer_Grid
            // 
            this.Answer_Grid.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance20.BackColor = System.Drawing.Color.White;
            appearance20.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Answer_Grid.DisplayLayout.Appearance = appearance20;
            this.Answer_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.Answer_Grid.DisplayLayout.GroupByBox.Hidden = true;
            this.Answer_Grid.DisplayLayout.InterBandSpacing = 10;
            appearance21.ForeColor = System.Drawing.Color.Black;
            this.Answer_Grid.DisplayLayout.Override.ActiveRowAppearance = appearance21;
            this.Answer_Grid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.Answer_Grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.Answer_Grid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.Answer_Grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            appearance22.BackColor = System.Drawing.Color.Transparent;
            this.Answer_Grid.DisplayLayout.Override.CardAreaAppearance = appearance22;
            this.Answer_Grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance25.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance25.ForeColor = System.Drawing.Color.White;
            appearance25.TextHAlignAsString = "Center";
            appearance25.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.Answer_Grid.DisplayLayout.Override.HeaderAppearance = appearance25;
            this.Answer_Grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance26.BackColor = System.Drawing.Color.Lavender;
            this.Answer_Grid.DisplayLayout.Override.RowAlternateAppearance = appearance26;
            appearance27.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.Answer_Grid.DisplayLayout.Override.RowAppearance = appearance27;
            this.Answer_Grid.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.Answer_Grid.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance28.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Answer_Grid.DisplayLayout.Override.RowSelectorAppearance = appearance28;
            this.Answer_Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.Answer_Grid.DisplayLayout.Override.RowSelectorWidth = 12;
            this.Answer_Grid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance29.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance29.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance29.ForeColor = System.Drawing.Color.Black;
            this.Answer_Grid.DisplayLayout.Override.SelectedRowAppearance = appearance29;
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
            this.Answer_Grid.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Answer_Grid.Location = new System.Drawing.Point(0, 0);
            this.Answer_Grid.Name = "Answer_Grid";
            this.Answer_Grid.Size = new System.Drawing.Size(825, 531);
            this.Answer_Grid.TabIndex = 1;
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
            labelTool2.InstanceProps.Width = 62;
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
            ultraToolbar1.Text = "���C�����j���[";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 1;
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3});
            ultraToolbar2.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar2.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar2.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.BelowImage;
            ultraToolbar2.Text = "�W��";
            this.Main_ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2});
            this.Main_ToolbarsManager.ToolbarSettings.FillEntireRow = Infragistics.Win.DefaultableBoolean.False;
            popupMenuTool3.SharedProps.Caption = "�t�@�C��(&F)";
            popupMenuTool3.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            popupMenuTool3.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool4});
            labelTool5.SharedProps.Spring = true;
            labelTool6.SharedProps.Caption = "���O�C���S����";
            labelTool6.SharedProps.ShowInCustomizer = false;
            appearance42.BackColor = System.Drawing.Color.White;
            appearance42.TextHAlignAsString = "Left";
            labelTool7.SharedProps.AppearancesSmall.Appearance = appearance42;
            labelTool7.SharedProps.Caption = "���@���Y";
            labelTool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            labelTool7.SharedProps.ShowInCustomizer = false;
            labelTool7.SharedProps.Width = 150;
            buttonTool5.SharedProps.Caption = "�I��(&X)";
            buttonTool5.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool5.SharedProps.ToolTipText = "��ʂ��I�����܂��B";
            buttonTool6.SharedProps.Caption = "���(&P)";
            buttonTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool6.SharedProps.ToolTipText = "������������܂��B";
            appearance43.ForeColorDisabled = System.Drawing.Color.Black;
            comboBoxTool2.EditAppearance = appearance43;
            comboBoxTool2.SharedProps.Enabled = false;
            comboBoxTool2.SharedProps.Visible = false;
            comboBoxTool2.ValueList = valueList1;
            labelTool8.SharedProps.Caption = "���@�_";
            labelTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            labelTool8.SharedProps.Visible = false;
            buttonTool7.SharedProps.Caption = "�e�L�X�g�o��(&O)";
            buttonTool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool7.SharedProps.ToolTipText = "�������e�L�X�g�o�͂��܂��B";
            buttonTool8.SharedProps.Caption = "�߂�(&R)";
            buttonTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool9.SharedProps.Caption = "�i��(&G)";
            buttonTool9.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool10.SharedProps.Caption = "PDF�\��(&V)";
            buttonTool10.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            popupMenuTool4.SharedProps.Caption = "�\��(&V)";
            popupMenuTool4.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool11,
            buttonTool12});
            this.Main_ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool3,
            labelTool5,
            labelTool6,
            labelTool7,
            buttonTool5,
            buttonTool6,
            comboBoxTool2,
            labelTool8,
            buttonTool7,
            buttonTool8,
            buttonTool9,
            buttonTool10,
            popupMenuTool4});
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
            this._SFTOK01101UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1016, 63);
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
            // PMUOE04121UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
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
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMUOE04121UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "�݌Ɋm�F";
            this.Load += new System.EventHandler(this.PMUOE04121UA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FontSize_tComboEditor)).EndInit();
            this.ultraStatusBar1.ResumeLayout(false);
            this.ultraStatusBar1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Section_Grid)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Answer_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        #region ���ϐ��A�萔
        // �v���O�������
        private const string PG_ID = "PMUOE04121U";         // �v���O����ID
        private const string PG_NM = "�݌ɉ񓚕\��";        // �v���O��������
        // ��������
        private const int SEARCH_FIRST = 0;                 // ����
        private const int SEARCH_BEFORE = 1;                // �O�f�[�^
        private const int SEARCH_NEXT = 2;                  // ���f�[�^
        // ���b�Z�[�W
        private const string MSG_NODATA_BEFORE = "�擪�f�[�^�ł��B";        // �O�f�[�^�Ȃ�
        private const string MSG_NODATA_NEXT = "�f�[�^���I�����܂����B";    // ���f�[�^�Ȃ�

        // �e��N���X
        private ImageList _imageList16 = null;              // �A�C�R���ݒ�N���X
        private ControlScreenSkin _controlScreenSkin;       // ��ʃf�U�C���ύX�N���X
        private GridStateController _gridStateController;   // �O���b�h�ݒ萧��N���X
        private PMUOE04123AA _stockAnswerAcs = null;        // �݌ɉ񓚃A�N�Z�X�N���X

        // �e��f�[�^
        private string _enterpriseCode = string.Empty;      // ��ƃR�[�h
        private string _sectionCode = string.Empty;         // ���_�R�[�h
        private List<StockSndRcvJnl> _stockSndRcvJnlList;   // UOE����M�W���[�i��(�݌�)�f�[�^
        # endregion ���ϐ��A�萔 - end

        #region ��constructor�ADispose
        #region ��constructor
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="estmtSndRcvJnlList">UOE����M�W���[�i��(����)���X�g</param>
        public PMUOE04121UA(List<StockSndRcvJnl> estmtSndRcvJnlList)
        {
            //
            // Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
            //
            InitializeComponent();

            this._imageList16 = IconResourceManagement.ImageList16;                     // �A�C�R�����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;                 // ��ƃR�[�h
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;        // ���_�R�[�h
            this._stockSndRcvJnlList = estmtSndRcvJnlList;                              // UOE����M�W���[�i��(����)�f�[�^

            // �C���X�^���X�쐬
            this._controlScreenSkin = new ControlScreenSkin();          // ��ʃf�U�C���ύX
            this._gridStateController = new GridStateController();      // �O���b�h�ݒ萧��
        }
        #endregion

        #region ��Dispose
        /// <summary>
        /// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
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
        #endregion ��constructor�ADispose - end

        #region ���C�x���g
        #region ��Form_Load
        /// <summary>
		/// �t�H�[�����[�h
		/// </summary>
		/// <remarks>
		/// <br>Note       : Form���[�h���ɏ������܂��B</br>
		/// <br>Programmer : �Ɠc �M�u</br>
		/// <br>Date       : 2008/11/10</br>
		/// </remarks>
        private void PMUOE04121UA_Load(object sender, EventArgs e)
		{
            try
            {
                // �c�[���o�[�ݒ�
                this.SetToolbar();

                // ��ʃX�L���ύX
                this._controlScreenSkin.LoadSkin();
                this._controlScreenSkin.SettingScreenSkin(this);

                // �t�H���g�T�C�Y
                this.FontSize_tComboEditor.Value = 11;

                // ��T�C�Y�̎�������
                this.AutoFitCol_ultraCheckEditor.Checked = false;

                // ��ʏ�����
                this.lb_UOESupplierName.Text = string.Empty;    // ������
                this.lb_Remark1.Text = string.Empty;            // ���}�[�N�P
                this.lb_Remark2.Text = string.Empty;            // ���}�[�N�Q
                this.AnswerGridInitializeLayout();
                this.SectionGridInitializeLayout();

                if (this._stockSndRcvJnlList == null)
                {
                    // �{�^����\��
                    this.ChangeViewPopupToolbarStatus(false);
                }
                else
                {
                    // �{�^���\��
                    this.ChangeViewPopupToolbarStatus(true);

                    // �f�[�^�擾
                    this._stockAnswerAcs = new PMUOE04123AA(this._stockSndRcvJnlList, this._enterpriseCode, this._sectionCode);
                    this._stockSndRcvJnlList = null;

                    // �f�[�^�\��
                    this.Search(SEARCH_FIRST);

                    this.Answer_Grid.Focus();
                }
            }
			finally
			{
                // �Ƃ��ǂ��c�[���o�[��������̂ŁA���t���b�V��
                this.Refresh();
			}
        }
        #endregion

        #region ��Toolbar_Click
        /// <summary>
        /// �c�[���o�[�N���b�N
        /// </summary>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�N���b�N���ɏ������܂��B</br>
        /// <br>Programmer : �Ɠc�@�M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void Main_ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // �I���{�^������
                case "End_ButtonTool":
                    {
                        this.Close();
                        break;
                    }
                // �߂�{�^������
                case "Before_ButtonTool":
                    {
                        this.Search(SEARCH_BEFORE);
                        break;
                    }
                // �i�ރ{�^������
                case "Next_ButtonTool":
                    {
                        this.Search(SEARCH_NEXT);
                        break;
                    }
            }
        }
        #endregion

        #region ��Answer_Grid_InitializeLayout
        /// <summary>
		/// �񓚃O���b�h�C�j�V�����C�Y���C�A�E�g
		/// </summary>
		/// <remarks>
		/// <br>Note       : �񓚃O���b�h���������ɏ������܂��B</br>
		/// <br>Programmer : �Ɠc �M�u</br>
		/// <br>Date       : 2008/11/10</br>
		/// </remarks>
		private void Answer_Grid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
            // �w�Œ��x�v�b�V���s���A�C�R��������
            e.Layout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None;

            // �w�t�B���^�����O�x�A�C�R��������
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // �w�\�[�g�x�w��ړ��x�s��
            e.Layout.Override.SelectTypeCol = SelectType.None;
            e.Layout.Override.HeaderClickAction = HeaderClickAction.Select;

            // �s�T�C�Y��ݒ�
            e.Layout.Override.DefaultRowHeight = 24;
            e.Layout.Override.FixedCellSeparatorColor = Color.Black;
        }
		#endregion

        #region ��Answer_Grid_AfterRowActivate
        /// <summary>
        /// �񓚃O���b�h�A�t�^�[Row�A�N�e�B�u
        /// </summary>
        /// <remarks>
        /// <br>Note		: �s���A�N�e�B�u�ɂȂ�����ɔ������܂��B</br>
        /// <br>Programmer	: �Ɠc �M�u</br>
        /// <br>Date		: 2008/11/10</br>
        /// </remarks>
        private void Answer_Grid_AfterRowActivate(object sender, System.EventArgs e)
        {
            // �I���s�����݂���ꍇ
            if (this.Answer_Grid.ActiveRow != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow activeRow = this.Answer_Grid.ActiveRow;

                // ����
                int uoeSupplierCd = (int)activeRow.Cells[PMUOE04122EA.ct_Col_UOESupplierCd].Value;          // ������R�[�h
                int uoeSalesOrder = (int)activeRow.Cells[PMUOE04122EA.ct_Col_UOESalesOrder].Value;          // �����ԍ�
                int uoeSalesOrderRow = (int)activeRow.Cells[PMUOE04122EA.ct_Col_UOESalesOrderRowNo].Value;  // �����s�ԍ�

                DataSet dataSet = this._stockAnswerAcs.GetSectionInfoDataSet(uoeSupplierCd, uoeSalesOrder, uoeSalesOrderRow);
                if (dataSet != null)
                {
                    // �\��
                    this.Section_Grid.DataSource = dataSet;
                }
            }
        }
        #endregion

        #region ��Section_Grid_InitializeLayout
        /// <summary>
        /// ���_�O���b�h�C�j�V�����C�Y���C�A�E�g
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_�O���b�h���������ɏ������܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void Section_Grid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            // �w�Œ��x�v�b�V���s���A�C�R��������
            e.Layout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None;

            // �w�t�B���^�����O�x�A�C�R��������
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // �w�\�[�g�x�w��ړ��x�s��
            e.Layout.Override.SelectTypeCol = SelectType.None;
            e.Layout.Override.HeaderClickAction = HeaderClickAction.Select;

            // �s�T�C�Y��ݒ�
            e.Layout.Override.DefaultRowHeight = 24;
            e.Layout.Override.FixedCellSeparatorColor = Color.Black;
        }
        #endregion

        #region ��ArrowKey_ChangeFocus
        /// <summary>
		/// ArrowKey�`�F���W�t�H�[�J�X
		/// </summary>
		/// <remarks>
		/// <br>Note       : �t�H�[�J�X�J�ڂ��s��ꂽ���ɏ������܂�</br>
		/// <br>Programmer : �Ɠc �M�u</br>
		/// <br>Date       : 2008/11/10</br>
		/// </remarks>
		private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
        }
        #endregion

        #region ��FontSize_ValueChanged
        /// <summary>
		/// �t�H���g�T�C�Y�l�ύX
		/// </summary>
		/// <remarks>
		/// <br>Note		: �t�H���g�T�C�Y�̒l���ύX���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: �Ɠc �M�u</br>
		/// <br>Date		: 2008/11/10</br>
		/// </remarks>
		private void FontSize_tComboEditor_ValueChanged(object sender, EventArgs e)
		{
			// �t�H���g�T�C�Y��ύX
			this.Answer_Grid.DisplayLayout.Appearance.FontData.SizeInPoints = (int)FontSize_tComboEditor.Value;
        }
        #endregion

        #region ��AutoFitCol_CheckedChanged
        /// <summary>
		/// ��T�C�Y�̎��������`�F�b�N�ύX
		/// </summary>
		/// <remarks>
		/// <br>Note		: ��T�C�Y�̎��������̃`�F�b�N���ύX���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: �Ɠc �M�u</br>
		/// <br>Date		: 2008/11/10</br>
		/// </remarks>
		private void AutoFitCol_ultraCheckEditor_CheckedChanged(object sender, EventArgs e)
		{
			// ��T�C�Y�̎�������
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
        #endregion ���C�x���g - end

        #region ��Private���\�b�h
        #region ��SetToolBar(�c�[���o�[�A�C�R���ݒ�)
        /// <summary>
        /// �c�[���o�[�ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�̃A�C�R���\�����s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void SetToolbar()
        {
            // �C���[�W���X�g��ݒ肷��
            Main_ToolbarsManager.ImageListSmall = this._imageList16;

            // ���O�C���S���҂ւ̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.LabelTool loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools["LoginTitle_LabelTool"];
            if (loginEmployeeLabel != null) loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            // ���O�C���S���ҕ\��
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools["LoginName_LabelTool"];
            if (LoginInfoAcquisition.Employee != null)
            {
                if (loginNameLabel != null) loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            }

            // �I���̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool endButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["End_ButtonTool"];
            if (endButton != null) endButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;

            // �߂�̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool beforeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Before_ButtonTool"];
            if (beforeButton != null) beforeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;

            // �i�ނ̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool nextButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Next_ButtonTool"];
            if (nextButton != null) nextButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEXT;
        }
        #endregion

        #region ��AnswerGridInitializeLayout(�񓚃O���b�h���C�A�E�g�ݒ�)
        /// <summary>
        /// �O���b�h�����ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�̏����ݒ���s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void AnswerGridInitializeLayout()
        {
            // �񓚃O���b�h�pDataSet�쐬
            DataTable dataTable = null;
            PMUOE04122EA.CreateDataTableDetail(ref dataTable);

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dataTable);
            this.Answer_Grid.DataSource = dataSet;

            this._gridStateController.SetGridStateToGrid(ref this.Answer_Grid);

            // �Y���̃O���b�h�R���g���[���擾
            UltraGrid grids = Answer_Grid;

            // ����쐬
            int visiblePosition = 0;
            string priceFormat = "#,##0;-#,##0;";
            string priceFormat2 = "#,##0.00;-#,##0.00;";    // add 2012/07/13

            ColumnsCollection Columns = grids.DisplayLayout.Bands[PMUOE04122EA.ct_Tbl_StockAnsDetail].Columns;

            // UOE������R�[�h
            Columns[PMUOE04122EA.ct_Col_UOESupplierCd].Hidden = true;
            Columns[PMUOE04122EA.ct_Col_UOESupplierCd].Header.Caption = "UOE������R�[�h";
            Columns[PMUOE04122EA.ct_Col_UOESupplierCd].Width = 100;
            Columns[PMUOE04122EA.ct_Col_UOESupplierCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[PMUOE04122EA.ct_Col_UOESupplierCd].CellActivation = Activation.NoEdit;
            Columns[PMUOE04122EA.ct_Col_UOESupplierCd].Header.VisiblePosition = visiblePosition++;

            // UOE�����ԍ�
            Columns[PMUOE04122EA.ct_Col_UOESalesOrder].Hidden = true;
            Columns[PMUOE04122EA.ct_Col_UOESalesOrder].Header.Caption = "UOE�����ԍ�";
            Columns[PMUOE04122EA.ct_Col_UOESalesOrder].Width = 100;
            Columns[PMUOE04122EA.ct_Col_UOESalesOrder].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[PMUOE04122EA.ct_Col_UOESalesOrder].CellActivation = Activation.NoEdit;
            Columns[PMUOE04122EA.ct_Col_UOESalesOrder].Header.VisiblePosition = visiblePosition++;

            // UOE�����s�ԍ�
            Columns[PMUOE04122EA.ct_Col_UOESalesOrderRowNo].Hidden = true;
            Columns[PMUOE04122EA.ct_Col_UOESalesOrderRowNo].Header.Caption = "UOE�����s�ԍ�";
            Columns[PMUOE04122EA.ct_Col_UOESalesOrderRowNo].Width = 100;
            Columns[PMUOE04122EA.ct_Col_UOESalesOrderRowNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[PMUOE04122EA.ct_Col_UOESalesOrderRowNo].CellActivation = Activation.NoEdit;
            Columns[PMUOE04122EA.ct_Col_UOESalesOrderRowNo].Header.VisiblePosition = visiblePosition++;

            // �i��
            Columns[PMUOE04122EA.ct_Col_GoodsNo].Header.Caption = "�i��";
            Columns[PMUOE04122EA.ct_Col_GoodsNo].Width = 196;
            Columns[PMUOE04122EA.ct_Col_GoodsNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE04122EA.ct_Col_GoodsNo].CellActivation = Activation.NoEdit;
            Columns[PMUOE04122EA.ct_Col_GoodsNo].Header.VisiblePosition = visiblePosition++;

            // ���[�J�[
            Columns[PMUOE04122EA.ct_Col_GoodsMakerCd].Header.Caption = "Ұ��";
            Columns[PMUOE04122EA.ct_Col_GoodsMakerCd].Width = 42;
            Columns[PMUOE04122EA.ct_Col_GoodsMakerCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE04122EA.ct_Col_GoodsMakerCd].CellActivation = Activation.NoEdit;
            Columns[PMUOE04122EA.ct_Col_GoodsMakerCd].Header.VisiblePosition = visiblePosition++;

            // �i��
            Columns[PMUOE04122EA.ct_Col_GoodsName].Header.Caption = "�i��";
            Columns[PMUOE04122EA.ct_Col_GoodsName].Width = 166;
            Columns[PMUOE04122EA.ct_Col_GoodsName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE04122EA.ct_Col_GoodsName].CellActivation = Activation.NoEdit;
            Columns[PMUOE04122EA.ct_Col_GoodsName].Header.VisiblePosition = visiblePosition++;

            // �W�����i
            Columns[PMUOE04122EA.ct_Col_AnswerListPrice].Header.Caption = "�W�����i";
            Columns[PMUOE04122EA.ct_Col_AnswerListPrice].Width = 80;
            Columns[PMUOE04122EA.ct_Col_AnswerListPrice].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[PMUOE04122EA.ct_Col_AnswerListPrice].CellActivation = Activation.NoEdit;
            Columns[PMUOE04122EA.ct_Col_AnswerListPrice].Format = priceFormat;
            Columns[PMUOE04122EA.ct_Col_AnswerListPrice].Header.VisiblePosition = visiblePosition++;

            // ���P��
            Columns[PMUOE04122EA.ct_Col_AnswerSalesUnitCost].Header.Caption = "���P��";
            Columns[PMUOE04122EA.ct_Col_AnswerSalesUnitCost].Width = 80;
            Columns[PMUOE04122EA.ct_Col_AnswerSalesUnitCost].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[PMUOE04122EA.ct_Col_AnswerSalesUnitCost].CellActivation = Activation.NoEdit;
            // upd 2012/07/13 >>>
            //Columns[PMUOE04122EA.ct_Col_AnswerSalesUnitCost].Format = priceFormat;
            Columns[PMUOE04122EA.ct_Col_AnswerSalesUnitCost].Format = priceFormat2;
            // upd 2012/07/13 <<<
            Columns[PMUOE04122EA.ct_Col_AnswerSalesUnitCost].Header.VisiblePosition = visiblePosition++;

            // �[��
            Columns[PMUOE04122EA.ct_Col_UOEDelivDateCd].Header.Caption = "�[��";
            Columns[PMUOE04122EA.ct_Col_UOEDelivDateCd].Width = 38;
            Columns[PMUOE04122EA.ct_Col_UOEDelivDateCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE04122EA.ct_Col_UOEDelivDateCd].CellActivation = Activation.NoEdit;
            Columns[PMUOE04122EA.ct_Col_UOEDelivDateCd].Header.VisiblePosition = visiblePosition++;

            // ���
            Columns[PMUOE04122EA.ct_Col_UOESubstCode].Header.Caption = "���";
            Columns[PMUOE04122EA.ct_Col_UOESubstCode].Width = 38;
            Columns[PMUOE04122EA.ct_Col_UOESubstCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE04122EA.ct_Col_UOESubstCode].CellActivation = Activation.NoEdit;
            Columns[PMUOE04122EA.ct_Col_UOESubstCode].Header.VisiblePosition = visiblePosition++;

            // �R�����g
            Columns[PMUOE04122EA.ct_Col_Comment].Header.Caption = "�R�����g";
            Columns[PMUOE04122EA.ct_Col_Comment].Width = 122;
            Columns[PMUOE04122EA.ct_Col_Comment].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE04122EA.ct_Col_Comment].CellActivation = Activation.NoEdit;
            Columns[PMUOE04122EA.ct_Col_Comment].Header.VisiblePosition = visiblePosition++;
        }
        #endregion 

        #region ��SectionGridInitializeLayout(���_�O���b�h���C�A�E�g�ݒ�)
        /// <summary>
        /// �O���b�h�����ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�̏����ݒ���s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void SectionGridInitializeLayout()
        {
            // ���_�O���b�h�pDataSet�쐬
            DataTable dataTable = null;
            PMUOE04122EA.CreateDataTableSection(ref dataTable);

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dataTable);
            this.Section_Grid.DataSource = dataSet;

            this._gridStateController.SetGridStateToGrid(ref this.Section_Grid);

            // �Y���̃O���b�h�R���g���[���擾
            UltraGrid grids = Section_Grid;

            // ����쐬
            int visiblePosition = 0;
            //string priceFormat = "#,##0;-#,##0;";         //DEL 2009/02/03�@�s��Ή�[10841]

            ColumnsCollection Columns = grids.DisplayLayout.Bands[PMUOE04122EA.ct_Tbl_StockAnsSection].Columns;

            // ���_
            Columns[PMUOE04122EA.ct_Col_SectionCode].Header.Caption = "���_";
            Columns[PMUOE04122EA.ct_Col_SectionCode].Width = 88;
            Columns[PMUOE04122EA.ct_Col_SectionCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE04122EA.ct_Col_SectionCode].CellActivation = Activation.NoEdit;
            Columns[PMUOE04122EA.ct_Col_SectionCode].Header.VisiblePosition = visiblePosition++;

            // �݌ɐ�
            Columns[PMUOE04122EA.ct_Col_SectionStock].Header.Caption = "�݌ɐ�";
            Columns[PMUOE04122EA.ct_Col_SectionStock].Width = 70;
            Columns[PMUOE04122EA.ct_Col_SectionStock].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[PMUOE04122EA.ct_Col_SectionStock].CellActivation = Activation.NoEdit;
            //Columns[PMUOE04122EA.ct_Col_SectionStock].Format = priceFormat;                       //DEL 2009/02/03�@�s��Ή�[10841]
            Columns[PMUOE04122EA.ct_Col_SectionStock].Header.VisiblePosition = visiblePosition++;
       }
        #endregion

        #region ��Search(�f�[�^�����A�\��)
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="searchMode">0�F�����\���A1�F�O�f�[�^�A2�F���f�[�^</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�̎擾�A�\�����s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void Search(int searchMode)
        {
            bool status = false;
            DataSet dataSet1 = null;
            DataSet dataSet2 = null;
            
            switch (searchMode)
            {
                // ����
                case SEARCH_FIRST:
                    {
                        status = this._stockAnswerAcs.SearchFirst(out dataSet1, out dataSet2);
                        break;
                    }
                // �O�f�[�^
                case SEARCH_BEFORE:
                    {
                        status = this._stockAnswerAcs.SearchBefore(out dataSet1, out dataSet2);
                        if (status == false)
                        {
                            // �擪�f�[�^�ł��B
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, PG_ID, MSG_NODATA_BEFORE, 0, MessageBoxButtons.OK);
                        }
                        break;
                    }
                // ���f�[�^
                case SEARCH_NEXT:
                    {
                        status = this._stockAnswerAcs.SearchNext(out dataSet1, out dataSet2);
                        if (status == false)
                        {
                            // �f�[�^���I�����܂����B
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, PG_ID, MSG_NODATA_NEXT, 0, MessageBoxButtons.OK);
                        }
                        break;
                    }
            }

            // �f�[�^�\��
            if (status)
            {
                this.DispSupplierData(dataSet1);            // �O���b�h�ȊO�\��
                this.Answer_Grid.DataSource = dataSet2;     // ���ו\��
            }
        }
        #endregion

        #region ��DispSupplierData(������P��(�O���b�h�ȊO)�̃f�[�^�\��)
        /// <summary>
        /// ���׈ȊO�̃f�[�^�\��
        /// </summary>
        /// <param name="dataSet"></param>
        /// <remarks>
        /// <br>Note       : ������P��(���׈ȊO)�̃f�[�^�̕\�����s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void DispSupplierData(DataSet dataSet)
        {
            foreach (DataRow dataRow in dataSet.Tables[PMUOE04122EA.ct_Tbl_StockAnsSupplier].Rows)
            {
                this.lb_UOESupplierName.Text = dataRow[PMUOE04122EA.ct_Col_UOESupplierName].ToString(); // ������
                this.lb_Remark1.Text = dataRow[PMUOE04122EA.ct_Col_UoeRemark1].ToString();              // ���}�[�N�P
                this.lb_Remark2.Text = dataRow[PMUOE04122EA.ct_Col_UoeRemark2].ToString();              // ���}�[�N�Q

                return;
            }
        }
        #endregion

        #region ��ChangeViewPopupToolbarStatus(�߂�E�i�ރ{�^���\��/��\��)
        /// <summary>
        /// �߂�E�i�ރ{�^���ݒ�
        /// </summary>
        /// <param name="flg">�\��/��\��</param>
        /// <remarks>
        /// <br>Note       : �߂�E�i�ރ{�^���̕\���؂�ւ����s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void ChangeViewPopupToolbarStatus(bool flg)
        {
            this.Main_ToolbarsManager.Tools["View_PopupMenuTool"].SharedProps.Visible = flg;    // �\��(V)
            this.Main_ToolbarsManager.Tools["Before_ButtonTool"].SharedProps.Visible = flg;     // �߂�
            this.Main_ToolbarsManager.Tools["Next_ButtonTool"].SharedProps.Visible = flg;       // �i��
        }
        #endregion
        #endregion ��Private���\�b�h - end
    }
}
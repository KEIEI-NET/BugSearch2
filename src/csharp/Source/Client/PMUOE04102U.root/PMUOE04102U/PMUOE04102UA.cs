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
    /// �����񓚕\���@UI�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note		: �����񓚕\���@UI�N���X</br>
	/// <br>Programmer	: �Ɠc �M�u</br>
	/// <br>Date		: 2008/11/06</br>
    /// <br>UpdateNote  : 2008/12/18 �Ɠc �M�u�@�o�O�C���A�d�l�ύX�Ή�</br>
    /// <br>              �@������A�����悩��t�H�[�J�X�ړ�����ƃw�b�_�[�����N���A����Ă��܂�</br>
    /// <br>              �A�z���_�̕\�����@�ύX</br>
    /// <br>              �B���������N���X���ڒǉ�</br>
    /// <br></br><br>
    /// <br>UpdateNote  : 2012/07/13 30517 �Ė� �x��</br>
    /// <br>              �d�������������_�ȉ��\���\�ɏC��</br>
    /// <br>UpdateNote  : 2014/04/02 30757 ���X�� �M�p</br>
    /// <br>              �V�X�e���e�X�g��Q�ꗗ_��s�z�M����71�Ή�</br>
    /// <br>              ���}�[�N�P�A���}�[�N�Q�A���_�A�˗��҂�UseMnemonic�v���p�e�B��false��ݒ�</br>
    /// </remarks>
	public class PMUOE04102UA : System.Windows.Forms.Form
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
        private Panel panel2;
        private Infragistics.Win.Misc.UltraLabel lb_UOESupplierName;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.Misc.UltraLabel lb_Remark2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private Infragistics.Win.Misc.UltraLabel lb_Remark1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private UltraGrid Answer_Grid;
        private Infragistics.Win.Misc.UltraLabel lb_SalesDate;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraLabel lb_UOESalesOrderNo;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.Misc.UltraLabel lb_FollowDeliGoodsDivNm;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.Misc.UltraLabel lb_DeliveredGoodsDivNm;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private Infragistics.Win.Misc.UltraLabel lb_EmployeeName;
        private Infragistics.Win.Misc.UltraLabel ultraLabel12;
        private Infragistics.Win.Misc.UltraLabel lb_UOERecvdSectionNm;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private Panel pnl_SearchCondition;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel lb_SupplierName;
        private TNedit tNedit_SupplierCd;
        private Infragistics.Win.Misc.UltraButton ub_SupplierGuide;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private TDateEdit tde_ed_SalesDay;
        private TDateEdit tde_st_SalesDay;
        private Infragistics.Win.Misc.UltraLabel lb_SystemDivName;
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
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel5 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel6 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel7 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel8 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel9 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel10 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel11 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel12 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel13 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel14 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel15 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel16 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel17 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("�����K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool5 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool1");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Before_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Next_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool6 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool7 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool8 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Print_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboBoxTool2 = new Infragistics.Win.UltraWinToolbars.ComboBoxTool("Section_ComboBoxTool");
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(0);
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool9 = new Infragistics.Win.UltraWinToolbars.LabelTool("SectionTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("TextOut_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Before_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Next_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Preview_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("�{�^���c�[��1");
            Infragistics.Win.UltraWinToolbars.PopupControlContainerTool popupControlContainerTool1 = new Infragistics.Win.UltraWinToolbars.PopupControlContainerTool("�|�b�v�A�b�v�R���g���[���R���e�i�c�[��1");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("View_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Before_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Next_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Search_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Clear_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool10 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool1");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMUOE04102UA));
            this.FontSize_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.AutoFitCol_ultraCheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.lb_SystemDivName = new Infragistics.Win.Misc.UltraLabel();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_SearchCondition = new System.Windows.Forms.Panel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.lb_SupplierName = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_SupplierCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ub_SupplierGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.tde_ed_SalesDay = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.tde_st_SalesDay = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.lb_EmployeeName = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.lb_UOERecvdSectionNm = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.lb_Remark2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.lb_Remark1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.lb_FollowDeliGoodsDivNm = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.lb_DeliveredGoodsDivNm = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.lb_UOESupplierName = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.lb_UOESalesOrderNo = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.lb_SalesDate = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.tMemPos1 = new Broadleaf.Library.Windows.Forms.TMemPos(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.ultraToolbarsDockArea3 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Main_ToolbarsManager = new Broadleaf.Library.Windows.Forms.TToolbarsManager(this.components);
            this.ultraToolbarsDockArea2 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsDockArea1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Answer_Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this._SFTOK01101UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFTOK01101UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFTOK01101UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFTOK01101UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.FontSize_tComboEditor)).BeginInit();
            this.ultraStatusBar1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_SearchCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Answer_Grid)).BeginInit();
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
            this.AutoFitCol_ultraCheckEditor.Text = "��T�C�Y�̎�������";
            this.AutoFitCol_ultraCheckEditor.CheckedChanged += new System.EventHandler(this.AutoFitCol_ultraCheckEditor_CheckedChanged);
            // 
            // lb_SystemDivName
            // 
            appearance65.FontData.BoldAsString = "False";
            appearance65.FontData.SizeInPoints = 9F;
            appearance65.TextHAlignAsString = "Left";
            appearance65.TextVAlignAsString = "Middle";
            this.lb_SystemDivName.Appearance = appearance65;
            this.lb_SystemDivName.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_SystemDivName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.lb_SystemDivName.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_SystemDivName.Location = new System.Drawing.Point(294, 3);
            this.lb_SystemDivName.Margin = new System.Windows.Forms.Padding(4);
            this.lb_SystemDivName.Name = "lb_SystemDivName";
            this.lb_SystemDivName.Size = new System.Drawing.Size(80, 18);
            this.lb_SystemDivName.TabIndex = 147;
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Controls.Add(this.FontSize_tComboEditor);
            this.ultraStatusBar1.Controls.Add(this.AutoFitCol_ultraCheckEditor);
            this.ultraStatusBar1.Controls.Add(this.lb_SystemDivName);
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
            ultraStatusPanel5.Key = "StatusBarPanel_WidthControl1_Text";
            ultraStatusPanel5.Width = 20;
            appearance15.FontData.SizeInPoints = 9F;
            ultraStatusPanel6.Appearance = appearance15;
            ultraStatusPanel6.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel6.Control = this.lb_SystemDivName;
            ultraStatusPanel6.Key = "StatusBarPanel_SystemDivName";
            ultraStatusPanel6.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel6.Width = 80;
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(102)))));
            ultraStatusPanel7.Appearance = appearance19;
            ultraStatusPanel7.Key = "StatusBarPanel_Color3_Text";
            ultraStatusPanel7.Width = 20;
            appearance20.FontData.SizeInPoints = 9F;
            ultraStatusPanel8.Appearance = appearance20;
            ultraStatusPanel8.Key = "StatusBarPanel_Color3Condition_Text";
            ultraStatusPanel8.Text = ":��֕i";
            ultraStatusPanel8.Width = 55;
            appearance17.BackColor = System.Drawing.Color.Red;
            ultraStatusPanel9.Appearance = appearance17;
            ultraStatusPanel9.Key = "StatusBarPanel_Color2_Text";
            ultraStatusPanel9.Width = 20;
            appearance18.FontData.SizeInPoints = 9F;
            ultraStatusPanel10.Appearance = appearance18;
            ultraStatusPanel10.Key = "StatusBarPanel_Color2Condition_Text";
            ultraStatusPanel10.Text = ":�S���c";
            ultraStatusPanel10.Width = 55;
            appearance14.BackColor = System.Drawing.Color.Blue;
            ultraStatusPanel11.Appearance = appearance14;
            ultraStatusPanel11.Key = "StatusBarPanel_Color1_Text";
            ultraStatusPanel11.Width = 20;
            appearance16.FontData.SizeInPoints = 9F;
            ultraStatusPanel12.Appearance = appearance16;
            ultraStatusPanel12.Key = "StatusBarPanel_Color1Condition_Text";
            ultraStatusPanel12.Text = ":�d�ؖ����^�ꕔ�c�^Ұ��̫۰��";
            ultraStatusPanel12.Width = 190;
            appearance24.FontData.SizeInPoints = 9F;
            ultraStatusPanel13.Appearance = appearance24;
            ultraStatusPanel13.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel13.Key = "StatusBarPanel_Text";
            ultraStatusPanel13.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel13.Width = 10;
            appearance38.FontData.SizeInPoints = 9F;
            ultraStatusPanel14.Appearance = appearance38;
            ultraStatusPanel14.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel14.Key = "StatusBarPanel_update";
            appearance39.FontData.ItalicAsString = "False";
            ultraStatusPanel15.Appearance = appearance39;
            ultraStatusPanel15.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel15.Key = "StatusBarPanel_Progress";
            appearance40.FontData.BoldAsString = "False";
            appearance40.FontData.SizeInPoints = 10F;
            ultraStatusPanel15.ProgressBarInfo.Appearance = appearance40;
            appearance41.FontData.BoldAsString = "True";
            appearance41.FontData.SizeInPoints = 9F;
            appearance41.ForeColor = System.Drawing.Color.Black;
            ultraStatusPanel15.ProgressBarInfo.FillAppearance = appearance41;
            ultraStatusPanel15.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Progress;
            ultraStatusPanel15.Visible = false;
            ultraStatusPanel15.Width = 158;
            ultraStatusPanel16.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel16.Key = "StatusBarPanel_Date";
            ultraStatusPanel16.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Date;
            ultraStatusPanel16.Width = 90;
            ultraStatusPanel17.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel17.Key = "StatusBarPanel_Time";
            ultraStatusPanel17.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Time;
            ultraStatusPanel17.Width = 50;
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
            ultraStatusPanel11,
            ultraStatusPanel12,
            ultraStatusPanel13,
            ultraStatusPanel14,
            ultraStatusPanel15,
            ultraStatusPanel16,
            ultraStatusPanel17});
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
            this.panel1.Controls.Add(this.lb_EmployeeName);
            this.panel1.Controls.Add(this.ultraLabel12);
            this.panel1.Controls.Add(this.lb_UOERecvdSectionNm);
            this.panel1.Controls.Add(this.ultraLabel11);
            this.panel1.Controls.Add(this.lb_Remark2);
            this.panel1.Controls.Add(this.ultraLabel10);
            this.panel1.Controls.Add(this.lb_Remark1);
            this.panel1.Controls.Add(this.ultraLabel9);
            this.panel1.Controls.Add(this.lb_FollowDeliGoodsDivNm);
            this.panel1.Controls.Add(this.ultraLabel8);
            this.panel1.Controls.Add(this.lb_DeliveredGoodsDivNm);
            this.panel1.Controls.Add(this.ultraLabel7);
            this.panel1.Controls.Add(this.lb_UOESupplierName);
            this.panel1.Controls.Add(this.ultraLabel6);
            this.panel1.Controls.Add(this.lb_UOESalesOrderNo);
            this.panel1.Controls.Add(this.ultraLabel5);
            this.panel1.Controls.Add(this.lb_SalesDate);
            this.panel1.Controls.Add(this.ultraLabel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 162);
            this.panel1.TabIndex = 0;
            // 
            // pnl_SearchCondition
            // 
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
            this.pnl_SearchCondition.Size = new System.Drawing.Size(448, 67);
            this.pnl_SearchCondition.TabIndex = 146;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ultraLabel2.Location = new System.Drawing.Point(239, 6);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(21, 21);
            this.ultraLabel2.TabIndex = 153;
            this.ultraLabel2.Text = "�`";
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ultraLabel1.Location = new System.Drawing.Point(3, 6);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(55, 17);
            this.ultraLabel1.TabIndex = 152;
            this.ultraLabel1.Text = "������";
            // 
            // lb_SupplierName
            // 
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance25.BorderColor = System.Drawing.Color.RosyBrown;
            appearance25.TextVAlignAsString = "Middle";
            this.lb_SupplierName.Appearance = appearance25;
            this.lb_SupplierName.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.lb_SupplierName.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lb_SupplierName.Location = new System.Drawing.Point(126, 34);
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
            this.tNedit_SupplierCd.Location = new System.Drawing.Point(61, 34);
            this.tNedit_SupplierCd.MaxLength = 4;
            this.tNedit_SupplierCd.Name = "tNedit_SupplierCd";
            this.tNedit_SupplierCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_SupplierCd.Size = new System.Drawing.Size(59, 24);
            this.tNedit_SupplierCd.TabIndex = 148;
            // 
            // ub_SupplierGuide
            // 
            this.ub_SupplierGuide.Location = new System.Drawing.Point(359, 34);
            this.ub_SupplierGuide.Name = "ub_SupplierGuide";
            this.ub_SupplierGuide.Size = new System.Drawing.Size(24, 24);
            this.ub_SupplierGuide.TabIndex = 149;
            this.ub_SupplierGuide.Tag = "";
            ultraToolTipInfo1.ToolTipText = "�����K�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.ub_SupplierGuide, ultraToolTipInfo1);
            this.ub_SupplierGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ub_SupplierGuide.Click += new System.EventHandler(this.ub_SupplierGuide_Click);
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ultraLabel3.Location = new System.Drawing.Point(3, 38);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(55, 17);
            this.ultraLabel3.TabIndex = 150;
            this.ultraLabel3.Text = "������";
            // 
            // tde_ed_SalesDay
            // 
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tde_ed_SalesDay.ActiveEditAppearance = appearance31;
            this.tde_ed_SalesDay.BackColor = System.Drawing.Color.Transparent;
            this.tde_ed_SalesDay.CalendarDisp = true;
            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance32.TextHAlignAsString = "Left";
            appearance32.TextVAlignAsString = "Middle";
            this.tde_ed_SalesDay.EditAppearance = appearance32;
            this.tde_ed_SalesDay.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tde_ed_SalesDay.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance33.TextHAlignAsString = "Left";
            appearance33.TextVAlignAsString = "Middle";
            this.tde_ed_SalesDay.LabelAppearance = appearance33;
            this.tde_ed_SalesDay.Location = new System.Drawing.Point(266, 3);
            this.tde_ed_SalesDay.Name = "tde_ed_SalesDay";
            this.tde_ed_SalesDay.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tde_ed_SalesDay.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.tde_ed_SalesDay.Size = new System.Drawing.Size(172, 24);
            this.tde_ed_SalesDay.TabIndex = 147;
            this.tde_ed_SalesDay.TabStop = true;
            // 
            // tde_st_SalesDay
            // 
            appearance34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tde_st_SalesDay.ActiveEditAppearance = appearance34;
            this.tde_st_SalesDay.BackColor = System.Drawing.Color.Transparent;
            this.tde_st_SalesDay.CalendarDisp = true;
            appearance35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance35.TextHAlignAsString = "Left";
            appearance35.TextVAlignAsString = "Middle";
            this.tde_st_SalesDay.EditAppearance = appearance35;
            this.tde_st_SalesDay.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tde_st_SalesDay.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance36.TextHAlignAsString = "Left";
            appearance36.TextVAlignAsString = "Middle";
            this.tde_st_SalesDay.LabelAppearance = appearance36;
            this.tde_st_SalesDay.Location = new System.Drawing.Point(61, 3);
            this.tde_st_SalesDay.Name = "tde_st_SalesDay";
            this.tde_st_SalesDay.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tde_st_SalesDay.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.tde_st_SalesDay.Size = new System.Drawing.Size(172, 24);
            this.tde_st_SalesDay.TabIndex = 146;
            this.tde_st_SalesDay.TabStop = true;
            // 
            // lb_EmployeeName
            // 
            appearance55.TextHAlignAsString = "Left";
            appearance55.TextVAlignAsString = "Middle";
            this.lb_EmployeeName.Appearance = appearance55;
            this.lb_EmployeeName.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_EmployeeName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.lb_EmployeeName.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_EmployeeName.Location = new System.Drawing.Point(458, 133);
            this.lb_EmployeeName.Margin = new System.Windows.Forms.Padding(4);
            this.lb_EmployeeName.Name = "lb_EmployeeName";
            this.lb_EmployeeName.Size = new System.Drawing.Size(164, 24);
            this.lb_EmployeeName.TabIndex = 137;
            this.lb_EmployeeName.UseMnemonic = false;
            this.lb_EmployeeName.WrapText = false;
            // 
            // ultraLabel12
            // 
            appearance54.TextHAlignAsString = "Center";
            appearance54.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance54;
            this.ultraLabel12.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(207)))), ((int)(((byte)(247)))));
            this.ultraLabel12.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel12.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel12.Location = new System.Drawing.Point(458, 111);
            this.ultraLabel12.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(164, 24);
            this.ultraLabel12.TabIndex = 136;
            this.ultraLabel12.Text = "�˗���";
            // 
            // lb_UOERecvdSectionNm
            // 
            appearance56.TextHAlignAsString = "Left";
            appearance56.TextVAlignAsString = "Middle";
            this.lb_UOERecvdSectionNm.Appearance = appearance56;
            this.lb_UOERecvdSectionNm.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_UOERecvdSectionNm.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.lb_UOERecvdSectionNm.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_UOERecvdSectionNm.Location = new System.Drawing.Point(263, 133);
            this.lb_UOERecvdSectionNm.Margin = new System.Windows.Forms.Padding(4);
            this.lb_UOERecvdSectionNm.Name = "lb_UOERecvdSectionNm";
            this.lb_UOERecvdSectionNm.Size = new System.Drawing.Size(197, 24);
            this.lb_UOERecvdSectionNm.TabIndex = 135;
            this.lb_UOERecvdSectionNm.UseMnemonic = false;
            // 
            // ultraLabel11
            // 
            appearance57.TextHAlignAsString = "Center";
            appearance57.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance57;
            this.ultraLabel11.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(207)))), ((int)(((byte)(247)))));
            this.ultraLabel11.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel11.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel11.Location = new System.Drawing.Point(263, 111);
            this.ultraLabel11.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(197, 24);
            this.ultraLabel11.TabIndex = 134;
            this.ultraLabel11.Text = "���_";
            // 
            // lb_Remark2
            // 
            appearance69.TextHAlignAsString = "Left";
            appearance69.TextVAlignAsString = "Middle";
            this.lb_Remark2.Appearance = appearance69;
            this.lb_Remark2.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_Remark2.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.lb_Remark2.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_Remark2.Location = new System.Drawing.Point(175, 133);
            this.lb_Remark2.Margin = new System.Windows.Forms.Padding(4);
            this.lb_Remark2.Name = "lb_Remark2";
            this.lb_Remark2.Size = new System.Drawing.Size(90, 24);
            this.lb_Remark2.TabIndex = 123;
            this.lb_Remark2.UseMnemonic = false;
            // 
            // ultraLabel10
            // 
            appearance70.TextHAlignAsString = "Center";
            appearance70.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance70;
            this.ultraLabel10.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(207)))), ((int)(((byte)(247)))));
            this.ultraLabel10.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel10.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel10.Location = new System.Drawing.Point(175, 111);
            this.ultraLabel10.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(90, 24);
            this.ultraLabel10.TabIndex = 122;
            this.ultraLabel10.Text = "���}�[�N2";
            // 
            // lb_Remark1
            // 
            appearance71.TextHAlignAsString = "Left";
            appearance71.TextVAlignAsString = "Middle";
            this.lb_Remark1.Appearance = appearance71;
            this.lb_Remark1.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_Remark1.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.lb_Remark1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_Remark1.Location = new System.Drawing.Point(13, 133);
            this.lb_Remark1.Margin = new System.Windows.Forms.Padding(4);
            this.lb_Remark1.Name = "lb_Remark1";
            this.lb_Remark1.Size = new System.Drawing.Size(165, 24);
            this.lb_Remark1.TabIndex = 121;
            this.lb_Remark1.UseMnemonic = false;
            // 
            // ultraLabel9
            // 
            appearance72.TextHAlignAsString = "Center";
            appearance72.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance72;
            this.ultraLabel9.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(207)))), ((int)(((byte)(247)))));
            this.ultraLabel9.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel9.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel9.Location = new System.Drawing.Point(13, 111);
            this.ultraLabel9.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(165, 24);
            this.ultraLabel9.TabIndex = 120;
            this.ultraLabel9.Text = "���}�[�N1";
            // 
            // lb_FollowDeliGoodsDivNm
            // 
            appearance59.TextHAlignAsString = "Left";
            appearance59.TextVAlignAsString = "Middle";
            this.lb_FollowDeliGoodsDivNm.Appearance = appearance59;
            this.lb_FollowDeliGoodsDivNm.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_FollowDeliGoodsDivNm.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.lb_FollowDeliGoodsDivNm.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_FollowDeliGoodsDivNm.Location = new System.Drawing.Point(621, 89);
            this.lb_FollowDeliGoodsDivNm.Margin = new System.Windows.Forms.Padding(4);
            this.lb_FollowDeliGoodsDivNm.Name = "lb_FollowDeliGoodsDivNm";
            this.lb_FollowDeliGoodsDivNm.Size = new System.Drawing.Size(165, 24);
            this.lb_FollowDeliGoodsDivNm.TabIndex = 133;
            // 
            // ultraLabel8
            // 
            appearance60.TextHAlignAsString = "Center";
            appearance60.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance60;
            this.ultraLabel8.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(207)))), ((int)(((byte)(247)))));
            this.ultraLabel8.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel8.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel8.Location = new System.Drawing.Point(621, 67);
            this.ultraLabel8.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(165, 24);
            this.ultraLabel8.TabIndex = 132;
            this.ultraLabel8.Text = "�g�[�i�敪";
            // 
            // lb_DeliveredGoodsDivNm
            // 
            appearance61.TextHAlignAsString = "Left";
            appearance61.TextVAlignAsString = "Middle";
            this.lb_DeliveredGoodsDivNm.Appearance = appearance61;
            this.lb_DeliveredGoodsDivNm.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_DeliveredGoodsDivNm.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.lb_DeliveredGoodsDivNm.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_DeliveredGoodsDivNm.Location = new System.Drawing.Point(458, 89);
            this.lb_DeliveredGoodsDivNm.Margin = new System.Windows.Forms.Padding(4);
            this.lb_DeliveredGoodsDivNm.Name = "lb_DeliveredGoodsDivNm";
            this.lb_DeliveredGoodsDivNm.Size = new System.Drawing.Size(165, 24);
            this.lb_DeliveredGoodsDivNm.TabIndex = 131;
            // 
            // ultraLabel7
            // 
            appearance62.TextHAlignAsString = "Center";
            appearance62.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance62;
            this.ultraLabel7.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(207)))), ((int)(((byte)(247)))));
            this.ultraLabel7.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel7.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel7.Location = new System.Drawing.Point(458, 67);
            this.ultraLabel7.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(165, 24);
            this.ultraLabel7.TabIndex = 130;
            this.ultraLabel7.Text = "�[�i�敪";
            // 
            // lb_UOESupplierName
            // 
            appearance73.TextHAlignAsString = "Left";
            appearance73.TextVAlignAsString = "Middle";
            this.lb_UOESupplierName.Appearance = appearance73;
            this.lb_UOESupplierName.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_UOESupplierName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.lb_UOESupplierName.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_UOESupplierName.Location = new System.Drawing.Point(263, 89);
            this.lb_UOESupplierName.Margin = new System.Windows.Forms.Padding(4);
            this.lb_UOESupplierName.Name = "lb_UOESupplierName";
            this.lb_UOESupplierName.Size = new System.Drawing.Size(197, 24);
            this.lb_UOESupplierName.TabIndex = 119;
            this.lb_UOESupplierName.WrapText = false;
            // 
            // ultraLabel6
            // 
            appearance74.TextHAlignAsString = "Center";
            appearance74.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance74;
            this.ultraLabel6.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(207)))), ((int)(((byte)(247)))));
            this.ultraLabel6.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel6.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel6.Location = new System.Drawing.Point(263, 67);
            this.ultraLabel6.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(197, 24);
            this.ultraLabel6.TabIndex = 118;
            this.ultraLabel6.Text = "������";
            // 
            // lb_UOESalesOrderNo
            // 
            appearance21.TextHAlignAsString = "Left";
            appearance21.TextVAlignAsString = "Middle";
            this.lb_UOESalesOrderNo.Appearance = appearance21;
            this.lb_UOESalesOrderNo.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_UOESalesOrderNo.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.lb_UOESalesOrderNo.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_UOESalesOrderNo.Location = new System.Drawing.Point(175, 89);
            this.lb_UOESalesOrderNo.Margin = new System.Windows.Forms.Padding(4);
            this.lb_UOESalesOrderNo.Name = "lb_UOESalesOrderNo";
            this.lb_UOESalesOrderNo.Size = new System.Drawing.Size(90, 24);
            this.lb_UOESalesOrderNo.TabIndex = 127;
            // 
            // ultraLabel5
            // 
            appearance66.TextHAlignAsString = "Center";
            appearance66.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance66;
            this.ultraLabel5.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(207)))), ((int)(((byte)(247)))));
            this.ultraLabel5.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel5.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel5.Location = new System.Drawing.Point(175, 67);
            this.ultraLabel5.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(90, 24);
            this.ultraLabel5.TabIndex = 126;
            this.ultraLabel5.Text = "�����ԍ�";
            // 
            // lb_SalesDate
            // 
            appearance67.TextHAlignAsString = "Left";
            appearance67.TextVAlignAsString = "Middle";
            this.lb_SalesDate.Appearance = appearance67;
            this.lb_SalesDate.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_SalesDate.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.lb_SalesDate.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_SalesDate.Location = new System.Drawing.Point(13, 89);
            this.lb_SalesDate.Margin = new System.Windows.Forms.Padding(4);
            this.lb_SalesDate.Name = "lb_SalesDate";
            this.lb_SalesDate.Size = new System.Drawing.Size(165, 24);
            this.lb_SalesDate.TabIndex = 125;
            // 
            // ultraLabel4
            // 
            appearance13.TextHAlignAsString = "Center";
            appearance13.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance13;
            this.ultraLabel4.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(207)))), ((int)(((byte)(247)))));
            this.ultraLabel4.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel4.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel4.Location = new System.Drawing.Point(13, 67);
            this.ultraLabel4.Margin = new System.Windows.Forms.Padding(4);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(165, 24);
            this.ultraLabel4.TabIndex = 124;
            this.ultraLabel4.Text = "������";
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
            this.ultraToolbarsDockArea3.Location = new System.Drawing.Point(1016, 73);
            this.ultraToolbarsDockArea3.Name = "ultraToolbarsDockArea3";
            this.ultraToolbarsDockArea3.Size = new System.Drawing.Size(0, 638);
            this.ultraToolbarsDockArea3.ToolbarsManager = this.Main_ToolbarsManager;
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
            ultraToolbar1.Text = "���C�����j���[";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 1;
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            labelTool5,
            buttonTool4,
            buttonTool5});
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
            buttonTool6});
            labelTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.DefaultForToolType;
            labelTool6.SharedProps.Spring = true;
            labelTool7.SharedProps.Caption = "���O�C���S����";
            labelTool7.SharedProps.ShowInCustomizer = false;
            appearance42.BackColor = System.Drawing.Color.White;
            appearance42.TextHAlignAsString = "Left";
            labelTool8.SharedProps.AppearancesSmall.Appearance = appearance42;
            labelTool8.SharedProps.Caption = "���@���Y";
            labelTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            labelTool8.SharedProps.ShowInCustomizer = false;
            labelTool8.SharedProps.Width = 150;
            buttonTool7.SharedProps.Caption = "�I��(&X)";
            buttonTool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool7.SharedProps.ToolTipText = "��ʂ��I�����܂��B";
            buttonTool8.SharedProps.Caption = "���(&P)";
            buttonTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool8.SharedProps.ToolTipText = "������������܂��B";
            appearance43.ForeColorDisabled = System.Drawing.Color.Black;
            comboBoxTool2.EditAppearance = appearance43;
            comboBoxTool2.SharedProps.Enabled = false;
            comboBoxTool2.SharedProps.Visible = false;
            comboBoxTool2.ValueList = valueList1;
            labelTool9.SharedProps.Caption = "���@�_";
            labelTool9.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            labelTool9.SharedProps.Visible = false;
            buttonTool9.SharedProps.Caption = "�e�L�X�g�o��(&O)";
            buttonTool9.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool9.SharedProps.ToolTipText = "�������e�L�X�g�o�͂��܂��B";
            buttonTool10.SharedProps.Caption = "�߂�(&R)";
            buttonTool10.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool11.SharedProps.Caption = "�i��(&G)";
            buttonTool11.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool12.SharedProps.Caption = "PDF�\��(&V)";
            buttonTool12.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool13.SharedProps.Caption = "�{�^���c�[��1";
            buttonTool13.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyInMenus;
            popupControlContainerTool1.SharedProps.Caption = "�|�b�v�A�b�v�R���g���[���R���e�i�c�[��1";
            popupMenuTool4.SharedProps.Caption = "�\��(&V)";
            popupMenuTool4.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool14,
            buttonTool15});
            buttonTool16.SharedProps.Caption = "����(&R)";
            buttonTool16.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool17.SharedProps.Caption = "�N���A(&C)";
            buttonTool17.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            labelTool10.SharedProps.Caption = "|";
            this.Main_ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool3,
            labelTool6,
            labelTool7,
            labelTool8,
            buttonTool7,
            buttonTool8,
            comboBoxTool2,
            labelTool9,
            buttonTool9,
            buttonTool10,
            buttonTool11,
            buttonTool12,
            buttonTool13,
            popupControlContainerTool1,
            popupMenuTool4,
            buttonTool16,
            buttonTool17,
            labelTool10});
            this.Main_ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.Main_ToolbarsManager_ToolClick);
            // 
            // ultraToolbarsDockArea2
            // 
            this.ultraToolbarsDockArea2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.ultraToolbarsDockArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this.ultraToolbarsDockArea2.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this.ultraToolbarsDockArea2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ultraToolbarsDockArea2.Location = new System.Drawing.Point(0, 73);
            this.ultraToolbarsDockArea2.Name = "ultraToolbarsDockArea2";
            this.ultraToolbarsDockArea2.Size = new System.Drawing.Size(0, 638);
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
            this.Answer_Grid.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Answer_Grid.Location = new System.Drawing.Point(0, 235);
            this.Answer_Grid.Name = "Answer_Grid";
            this.Answer_Grid.Size = new System.Drawing.Size(1016, 466);
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
            this._SFTOK01101UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1016, 73);
            this._SFTOK01101UA_Toolbars_Dock_Area_Right.Name = "_SFTOK01101UA_Toolbars_Dock_Area_Right";
            this._SFTOK01101UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 638);
            this._SFTOK01101UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _SFTOK01101UA_Toolbars_Dock_Area_Left
            // 
            this._SFTOK01101UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFTOK01101UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFTOK01101UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._SFTOK01101UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFTOK01101UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 73);
            this._SFTOK01101UA_Toolbars_Dock_Area_Left.Name = "_SFTOK01101UA_Toolbars_Dock_Area_Left";
            this._SFTOK01101UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 638);
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
            this._SFTOK01101UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1016, 73);
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
            // PMUOE04102UA
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
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMUOE04102UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "�����m�F";
            this.Load += new System.EventHandler(this.PMUOE04111UA_Load);
            this.Shown += new System.EventHandler(this.PMUOE04102UA_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.FontSize_tComboEditor)).EndInit();
            this.ultraStatusBar1.ResumeLayout(false);
            this.ultraStatusBar1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pnl_SearchCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Answer_Grid)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        #region ���ϐ��A�萔
        // �v���O�������
        private const string PG_ID = "PMUOE04102U";         // �v���O����ID
        private const string PG_NM = "�����񓚕\��";        // �v���O��������
        // ��������
        private const int SEARCH_FIRST = 0;                 // ����
        private const int SEARCH_BEFORE = 1;                // �O�f�[�^
        private const int SEARCH_NEXT = 2;                  // ���f�[�^
        // �G���[�`�F�b�N
        private const int CHECKDATA_FAILED = -1;            // �`�F�b�N���s
        private const int CHECKDATA_CNDTNEMPTY = 0;         // ���͂Ȃ�
        private const int CHECKDATA_SUCCESS = 1;            // �`�F�b�N����
        // ���b�Z�[�W
        private const string MSG_NODATA_BEFORE = "�擪�f�[�^�ł��B";        // �O�f�[�^�Ȃ�
        private const string MSG_NODATA_NEXT = "�f�[�^���I�����܂����B";    // ���f�[�^�Ȃ�
        // �O���b�h��
        private const int GRIDCOLUMN_WIDTH1 = 26;       // �Z���N�^�[
        private const int GRIDCOLUMN_WIDTH2 = 10;       // ��\��
        private const int GRIDCOLUMN_WIDTH3 = 10;       // ��\��
        private const int GRIDCOLUMN_WIDTH4 = 193;      // �i��
        private const int GRIDCOLUMN_WIDTH5 = 63;       // ���[�J�[
        private const int GRIDCOLUMN_WIDTH6 = 53;       // ��1
        private const int GRIDCOLUMN_WIDTH7 = 78;       // �艿
        private const int GRIDCOLUMN_WIDTH8 = 63;       // ���_�`�[
        private const int GRIDCOLUMN_WIDTH9 = 63;       // BO�`�[1
        private const int GRIDCOLUMN_WIDTH10 = 63;      // BO�`�[2
        private const int GRIDCOLUMN_WIDTH11 = 63;      // BO�`�[3
        private const int GRIDCOLUMN_WIDTH12 = 63;      // BO�Ǘ�No.
        private const int GRIDCOLUMN_WIDTH13 = 63;      // ��2
        private const int GRIDCOLUMN_WIDTH14 = 63;      // ���
        private const int GRIDCOLUMN_WIDTH15 = 142;     // �R�����g
        private const int GRIDCOLUMN_WIDTH16 = 10;      // ��\��
       // ���������N���A
        private const bool SEARCHCONDITION_CLEAR = true;        // ���������N���A
        private const bool SEARCHCONDITION_NO_CLEAR = false;    // ���������c��

        // �e��N���X
        private ImageList _imageList16 = null;              // �A�C�R���ݒ�N���X
        private ControlScreenSkin _controlScreenSkin;       // ��ʃf�U�C���ύX�N���X
        private GridStateController _gridStateController;   // �O���b�h�ݒ萧��N���X
        private PMUOE04104AA _orderAnswerAcs = null;        // �����񓚃A�N�Z�X�N���X

        // �e��f�[�^
        private string _enterpriseCode = string.Empty;      // ��ƃR�[�h
        private string _sectionCode = string.Empty;         // ���_�R�[�h
        private List<OrderSndRcvJnl> _orderSndRcvJnlList;   // UOE����M�W���[�i��(����)�f�[�^
        private bool _singleMode;                           // True�F�P�̋N���AFalse�F���̑�
        private Backup _backup;                             // ���͒l�ێ�

        // ���͒l�ێ��p
        struct Backup
        {
            public int SalesDaySt;          // ������From
            public int SalesDayEd;          // ������To
            public int SupplierCd;          // ������R�[�h
            public string SupplierName;     // �����於��
        }
        # endregion ���ϐ��A�萔 - end

        #region ��constructor�ADispose
        #region ��constructor
        /// <summary>
        /// �R���X�g���N�^(�P�̋N����p)
        /// </summary>
        public PMUOE04102UA()
        {
            ConstructorProc();

            // �P�̋N�����[�h
            this._singleMode = true;
        }
        /// <summary>
        /// �R���X�g���N�^(�P�̋N���ȊO��)
        /// </summary>
        /// <param name="orderSndRcvJnlList">UOE����M�W���[�i��(����)���X�g</param>
        public PMUOE04102UA(List<OrderSndRcvJnl> orderSndRcvJnlList)
        {
            ConstructorProc();

            this._orderSndRcvJnlList = orderSndRcvJnlList;  // UOE����M�W���[�i��(����)�f�[�^

            // �P�̋N���ȊO
            this._singleMode = false;
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
		/// <br>Date       : 2008/11/06</br>
		/// </remarks>
        private void PMUOE04111UA_Load(object sender, System.EventArgs e)
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
                this.AllInitializeLayout(SEARCHCONDITION_CLEAR);
                this.ub_SupplierGuide.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];        // �����K�C�h

                if (this._singleMode)
                {
                    // �f�[�^�擾(����MJNL�f�[�^������)
                    this._orderAnswerAcs = new PMUOE04104AA(null, this._enterpriseCode,this._sectionCode);
                }
                else if (this._orderSndRcvJnlList != null)
                {
                    // �f�[�^�擾
                    this._orderAnswerAcs = new PMUOE04104AA(this._orderSndRcvJnlList, this._enterpriseCode,this._sectionCode);
                    this._orderSndRcvJnlList = null;

                    // �f�[�^�\��
                    this.Search(SEARCH_FIRST);
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
        /// <br>Date       : 2008/11/06</br>
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
                // �����{�^������
                case "Search_ButtonTool":
                    {
                        this.ToolbarSearchClick();
                        break;
                    }
                // �N���A�{�^������
                case "Clear_ButtonTool":
                    {
                        this.ToolbarClearClick();
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

        #region ��ub_SupplierGuide_Click
        /// <summary>
        /// ������K�C�h�{�^������������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ������K�C�h�{�^���������ꂽ���ɏ������܂�</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private void ub_SupplierGuide_Click(object sender, EventArgs e)
        {
            UOESupplier uoeSupplier = new UOESupplier();          
            UOESupplierAcs uoeSupplierAcs = new UOESupplierAcs();

            // ������K�C�h�\��
            int status = uoeSupplierAcs.ExecuteGuid(this._enterpriseCode,this._sectionCode, out uoeSupplier);
            if ((status == 0) && (uoeSupplier != null))
            {
                this.tNedit_SupplierCd.Value = uoeSupplier.UOESupplierCd;
                this.lb_SupplierName.Text = uoeSupplier.UOESupplierName;

                // �O���b�h�w�b�_�[���ڎ擾(�O���b�h�̃w�b�_�[�̂�)
                this.DispGridHeaderData();

                this.tNedit_SupplierCd.Focus();
            }
        }
        #endregion

        #region ��Grid_InitializeLayout
        /// <summary>
		/// �񓚃O���b�h�C�j�V�����C�Y���C�A�E�g
		/// </summary>
		/// <remarks>
		/// <br>Note       : �񓚃O���b�h���������ɏ������܂��B</br>
		/// <br>Programmer : �Ɠc �M�u</br>
		/// <br>Date       : 2008/11/06</br>
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

            // �w��T�C�Y(����)�x�ύX��
            e.Layout.Override.AllowRowLayoutLabelSizing = RowLayoutSizing.Horizontal;       // �w�b�_�[
            e.Layout.Override.AllowRowLayoutCellSizing = RowLayoutSizing.Horizontal;        // ����
        }
		#endregion

        #region ��Grid_AfterRowActivate
        /// <summary>
        /// �񓚃O���b�h�A�t�^�[Row�A�N�e�B�u
        /// </summary>
        /// <remarks>
        /// <br>Note		: �s���A�N�e�B�u�ɂȂ�����ɔ������܂��B</br>
        /// <br>Programmer	: �Ɠc �M�u</br>
        /// <br>Date		: 2008/11/06</br>
        /// </remarks>
        private void Answer_Grid_AfterRowActivate(object sender, System.EventArgs e)
        {
            // �I���s�����݂���ꍇ
            if (this.Answer_Grid.ActiveRow != null)
            {
                // �A�N�e�B�u�ȍs�̑O�i�F�����X�w�肵�Ă���O�i�F�Ɠ����ɂ���
                Infragistics.Win.UltraWinGrid.UltraGridRow activeRow = this.Answer_Grid.ActiveRow;
                this.Answer_Grid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = activeRow.Appearance.ForeColor;
            }
        }
        #endregion

        #region ��FontSize_ValueChanged
        /// <summary>
		/// �t�H���g�T�C�Y�l�ύX
		/// </summary>
		/// <remarks>
		/// <br>Note		: �t�H���g�T�C�Y�̒l���ύX���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: �Ɠc �M�u</br>
		/// <br>Date		: 2008/11/06</br>
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
		/// <br>Date		: 2008/11/06</br>
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

        #region ��Form_Shown(�P�̋N����p)
        /// <summary>
        /// Form����\��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ����N�����ɏ������܂�</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private void PMUOE04102UA_Shown(object sender, EventArgs e)
        {
            this.tde_st_SalesDay.Focus();
        }
        #endregion

        #region ��ArrowKey_ChangeFocus(�P�̋N����p)
        /// <summary>
        /// ArrowKey�`�F���W�t�H�[�J�X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X�J�ڂ��s��ꂽ���ɏ������܂�</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            int status = 0;

            #region ������From
            // ������From����̑J�ڎ�
            if (e.PrevCtrl == this.tde_st_SalesDay)
            {
                // ���t�`���s�����͋�
                if (this.tde_st_SalesDay.GetDateTime() == DateTime.MinValue)
                {
                    this.tde_st_SalesDay.SetLongDate(0);
                }

                // �l��ێ�
                this.BackupInputValue(e.PrevCtrl);

                // ���A���AShift+Tab/Enter���A�J�ڂȂ�
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

            #region ������To
            // ������To����̑J�ڎ�
            if (e.PrevCtrl == this.tde_ed_SalesDay)
            {
                // ���t�`���s�����͋�
                if (this.tde_ed_SalesDay.GetDateTime() == DateTime.MinValue)
                {
                    this.tde_ed_SalesDay.SetLongDate(0);
                }

                // �l��ێ�
                this.BackupInputValue(e.PrevCtrl);

                // �����A������R�[�h�ɑJ��
                if (e.Key == Keys.Down)
                {
                    e.NextCtrl = this.tNedit_SupplierCd;
                }
                return;
            }
            #endregion

            #region ������
            // ������R�[�h����J�ڎ�
            if (e.PrevCtrl == this.tNedit_SupplierCd)
            {
                //// ���̓`�F�b�N
                status = this.CheckConditionSupplier();
                if (status == CHECKDATA_CNDTNEMPTY)
                {
                    // �l�ێ�
                    this.BackupInputValue(e.PrevCtrl);
                }
                else if (status == CHECKDATA_FAILED)
                {
                    // �l��߂�
                    this.RecoverInputValue(e.PrevCtrl);
                    this.tNedit_SupplierCd.Select();

                    e.NextCtrl = e.PrevCtrl;
                    return;
                }
                else
                {
                    // �l��ێ�
                    this.BackupInputValue(e.PrevCtrl);

                    // �O���b�h�w�b�_�[���ڎ擾(�O���b�h�̃w�b�_�[�̂�)
                    this.DispGridHeaderData();

                    // Enter/Tab�������͔������ɑJ��
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (e.ShiftKey == false)
                        {
                            //e.NextCtrl = e.PrevCtrl;
                            e.NextCtrl = tde_st_SalesDay;
                        }
                    }
                }

                // ���͑J�ڂȂ�
                if (e.Key == Keys.Down)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
                return;
            }
            #endregion

            #region ������K�C�h�{�^��
            // �K�C�h�{�^������J�ڎ�
            if (e.PrevCtrl == this.ub_SupplierGuide)
            {
                // ���͑J�ڂȂ�
                if (e.Key == Keys.Down)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
                // Enter/Tab���͔������ɑJ��
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
        #endregion ���C�x���g - end

        #region ��Private���\�b�h
        #region ��ConstructorProc(�R���X�g���N�^)
        private void ConstructorProc()
        {
            //
            // Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
            //
            InitializeComponent();

            this._imageList16 = IconResourceManagement.ImageList16;     // �A�C�R�����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode; // ��ƃR�[�h
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;        // ���_�R�[�h

            // �C���X�^���X�쐬
            this._controlScreenSkin = new ControlScreenSkin();          // ��ʃf�U�C���ύX
            this._gridStateController = new GridStateController();      // �O���b�h�ݒ萧��
        }
        #endregion

        #region ��AllInitializeLayout(��ʏ�����)
        /// <summary>
        /// ��ʏ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏��������s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private void AllInitializeLayout(bool searchConditionClear)
        {
            // ��������
            if (searchConditionClear)
            {
                // �����\��
                this.tde_st_SalesDay.SetToday();
                this.tde_ed_SalesDay.SetToday();
                this.tNedit_SupplierCd.Clear();
                this.lb_SupplierName.Text = string.Empty;

                // �l�ێ�
                this.BackupInputValueAll();
            }

            // �w�b�_�[����
            this.lb_SalesDate.Text = string.Empty;              // ������
            this.lb_UOESalesOrderNo.Text = string.Empty;        // �����ԍ�
            this.lb_UOESupplierName.Text = string.Empty;        // ������
            this.lb_Remark1.Text = string.Empty;                // ���}�[�N�P
            this.lb_Remark2.Text = string.Empty;                // ���}�[�N�Q
            this.lb_DeliveredGoodsDivNm.Text = string.Empty;    // �[�i�敪
            this.lb_FollowDeliGoodsDivNm.Text = string.Empty;   // �g�[�i�敪
            this.lb_UOERecvdSectionNm.Text = string.Empty;      // ���_
            this.lb_EmployeeName.Text = string.Empty;           // �˗���

            // �t�b�^�[����
            this.lb_SystemDivName.Text = string.Empty;            // �V�X�e���敪

            // �O���b�h
            this.GridInitializeLayout();

            // �{�^��
            if (this._singleMode)
            {
                // �P�̋N����
                this.ChangeSearchConditionStatus(true);     // �����֘A
                this.ChangeViewPopupToolbarStatus(false);   // �߂�E�i�ފ֘A
            }
            else if (this._orderSndRcvJnlList != null)
            {
                // �P�̋N���ȊO�Ńf�[�^����
                this.ChangeSearchConditionStatus(false);    // �����֘A
                this.ChangeViewPopupToolbarStatus(true);    // �߂�E�i�ފ֘A
            }
            else
            {
                // �P�̋N���ȊO�Ńf�[�^�Ȃ�(�ُ�)
                this.ChangeSearchConditionStatus(false);    // �����֘A
                this.ChangeViewPopupToolbarStatus(false);   // �߂�E�i�ފ֘A
            }
        }
        #endregion

        #region ��SetToolBar(�c�[���o�[�A�C�R���ݒ�)
        /// <summary>
        /// �c�[���o�[�ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�̃A�C�R���\�����s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
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

            // �����̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Search_ButtonTool"];
            if (searchButton != null) searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;

            // �N���A�̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Clear_ButtonTool"];
            if (clearButton != null) clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;

            // �߂�̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool beforeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Before_ButtonTool"];
            if (beforeButton != null) beforeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;

            // �i�ނ̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool nextButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools["Next_ButtonTool"];
            if (nextButton != null) nextButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEXT;
        }
        #endregion

        #region ��GridInitializeLayout(�O���b�h���C�A�E�g�ݒ�)
        /// <summary>
        /// �O���b�h�����ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�̏����ݒ���s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private void GridInitializeLayout()
        {
            // �񓚃O���b�h�pDataSet�쐬
            DataTable dataTable = null;
            PMUOE04103EA.CreateDataTableDetail(ref dataTable);

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

            ColumnsCollection Columns = grids.DisplayLayout.Bands[PMUOE04103EA.ct_Tbl_OrderAnsDetail].Columns;

            #region ���ڐݒ�
            // �擪��ɔԍ��\��(�w�b�_�[�ɁwNo.�x�Ȃǂ�\�����鎖�͕s��)
            grids.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex;
            grids.DisplayLayout.Override.RowSelectorWidth = GRIDCOLUMN_WIDTH1;
            grids.DisplayLayout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.SeparateElement;
            grids.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            grids.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            // UOE�����s�ԍ�
            Columns[PMUOE04103EA.ct_Col_UOESalesOrderRowNo].Hidden = true;
            Columns[PMUOE04103EA.ct_Col_UOESalesOrderRowNo].Header.Caption = "UOE�����s�ԍ�";
            Columns[PMUOE04103EA.ct_Col_UOESalesOrderRowNo].Width = GRIDCOLUMN_WIDTH2;
            Columns[PMUOE04103EA.ct_Col_UOESalesOrderRowNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[PMUOE04103EA.ct_Col_UOESalesOrderRowNo].CellActivation = Activation.NoEdit;
            Columns[PMUOE04103EA.ct_Col_UOESalesOrderRowNo].Header.VisiblePosition = visiblePosition++;
            // ��֕i��
            Columns[PMUOE04103EA.ct_Col_SubstPartsNo].Hidden = true;
            Columns[PMUOE04103EA.ct_Col_SubstPartsNo].Header.Caption = "��֕i��";
            Columns[PMUOE04103EA.ct_Col_SubstPartsNo].Width = GRIDCOLUMN_WIDTH3;
            Columns[PMUOE04103EA.ct_Col_SubstPartsNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[PMUOE04103EA.ct_Col_SubstPartsNo].CellActivation = Activation.NoEdit;
            Columns[PMUOE04103EA.ct_Col_SubstPartsNo].Header.VisiblePosition = visiblePosition++;
            // �i��
            Columns[PMUOE04103EA.ct_Col_GoodsNo].Header.Caption = "�i��";
            Columns[PMUOE04103EA.ct_Col_GoodsNo].Width = GRIDCOLUMN_WIDTH4;
            Columns[PMUOE04103EA.ct_Col_GoodsNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE04103EA.ct_Col_GoodsNo].CellActivation = Activation.NoEdit;
            Columns[PMUOE04103EA.ct_Col_GoodsNo].Header.VisiblePosition = visiblePosition++;
            // ���[�J�[
            Columns[PMUOE04103EA.ct_Col_GoodsMakerCd].Header.Caption = "Ұ��";
            Columns[PMUOE04103EA.ct_Col_GoodsMakerCd].Width = GRIDCOLUMN_WIDTH5;
            Columns[PMUOE04103EA.ct_Col_GoodsMakerCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[PMUOE04103EA.ct_Col_GoodsMakerCd].CellActivation = Activation.NoEdit;
            Columns[PMUOE04103EA.ct_Col_GoodsMakerCd].Header.VisiblePosition = visiblePosition++;
            // ��1
            Columns[PMUOE04103EA.ct_Col_Blank1].Header.Caption = "";
            Columns[PMUOE04103EA.ct_Col_Blank1].Width = GRIDCOLUMN_WIDTH6;
            Columns[PMUOE04103EA.ct_Col_Blank1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE04103EA.ct_Col_Blank1].CellActivation = Activation.NoEdit;
            Columns[PMUOE04103EA.ct_Col_Blank1].Header.VisiblePosition = visiblePosition++;
            // �W�����i
            Columns[PMUOE04103EA.ct_Col_ListPrice].Header.Caption = "�W�����i";
            Columns[PMUOE04103EA.ct_Col_ListPrice].Width = GRIDCOLUMN_WIDTH7;
            Columns[PMUOE04103EA.ct_Col_ListPrice].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[PMUOE04103EA.ct_Col_ListPrice].CellActivation = Activation.NoEdit;
            Columns[PMUOE04103EA.ct_Col_ListPrice].Format = priceFormat;
            Columns[PMUOE04103EA.ct_Col_ListPrice].Header.VisiblePosition = visiblePosition++;
            // �σw�b�_�[����1(���_�`�[)
            Columns[PMUOE04103EA.ct_Col_UOESectionSlipNo].Header.Caption = "";
            Columns[PMUOE04103EA.ct_Col_UOESectionSlipNo].Width = GRIDCOLUMN_WIDTH8;
            Columns[PMUOE04103EA.ct_Col_UOESectionSlipNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE04103EA.ct_Col_UOESectionSlipNo].CellActivation = Activation.NoEdit;
            Columns[PMUOE04103EA.ct_Col_UOESectionSlipNo].Header.VisiblePosition = visiblePosition++;
            // �σw�b�_�[����2(BO�`�[1)
            Columns[PMUOE04103EA.ct_Col_BOSlipNo1].Header.Caption = "";
            Columns[PMUOE04103EA.ct_Col_BOSlipNo1].Width = GRIDCOLUMN_WIDTH9;
            Columns[PMUOE04103EA.ct_Col_BOSlipNo1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE04103EA.ct_Col_BOSlipNo1].CellActivation = Activation.NoEdit;
            Columns[PMUOE04103EA.ct_Col_BOSlipNo1].Header.VisiblePosition = visiblePosition++;
            // �σw�b�_�[����3(BO�`�[2)
            Columns[PMUOE04103EA.ct_Col_BOSlipNo2].Header.Caption = "";
            Columns[PMUOE04103EA.ct_Col_BOSlipNo2].Width = GRIDCOLUMN_WIDTH10;
            Columns[PMUOE04103EA.ct_Col_BOSlipNo2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE04103EA.ct_Col_BOSlipNo2].CellActivation = Activation.NoEdit;
            Columns[PMUOE04103EA.ct_Col_BOSlipNo2].Header.VisiblePosition = visiblePosition++;
            // �σw�b�_�[����4(BO�`�[3)
            Columns[PMUOE04103EA.ct_Col_BOSlipNo3].Header.Caption = "";
            Columns[PMUOE04103EA.ct_Col_BOSlipNo3].Width = GRIDCOLUMN_WIDTH11;
            Columns[PMUOE04103EA.ct_Col_BOSlipNo3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE04103EA.ct_Col_BOSlipNo3].CellActivation = Activation.NoEdit;
            Columns[PMUOE04103EA.ct_Col_BOSlipNo3].Header.VisiblePosition = visiblePosition++;
            // �σw�b�_�[����5(BO�Ǘ�No.)
            Columns[PMUOE04103EA.ct_Col_BOManagementNo].Header.Caption = "";
            Columns[PMUOE04103EA.ct_Col_BOManagementNo].Width = GRIDCOLUMN_WIDTH12;
            Columns[PMUOE04103EA.ct_Col_BOManagementNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE04103EA.ct_Col_BOManagementNo].CellActivation = Activation.NoEdit;
            Columns[PMUOE04103EA.ct_Col_BOManagementNo].Header.VisiblePosition = visiblePosition++;
            // ��2
            Columns[PMUOE04103EA.ct_Col_Blank2].Header.Caption = "";
            Columns[PMUOE04103EA.ct_Col_Blank2].Width = GRIDCOLUMN_WIDTH13;
            Columns[PMUOE04103EA.ct_Col_Blank2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE04103EA.ct_Col_Blank2].CellActivation = Activation.NoEdit;
            Columns[PMUOE04103EA.ct_Col_Blank2].Header.VisiblePosition = visiblePosition++;
            // ���
            Columns[PMUOE04103EA.ct_Col_UOESubstMark].Header.Caption = "���";
            Columns[PMUOE04103EA.ct_Col_UOESubstMark].Width = GRIDCOLUMN_WIDTH14;
            Columns[PMUOE04103EA.ct_Col_UOESubstMark].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE04103EA.ct_Col_UOESubstMark].CellActivation = Activation.NoEdit;
            Columns[PMUOE04103EA.ct_Col_UOESubstMark].Header.VisiblePosition = visiblePosition++;
            // �R�����g
            Columns[PMUOE04103EA.ct_Col_Comment].Header.Caption = "�R�����g";
            Columns[PMUOE04103EA.ct_Col_Comment].Width = GRIDCOLUMN_WIDTH15;
            Columns[PMUOE04103EA.ct_Col_Comment].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE04103EA.ct_Col_Comment].CellActivation = Activation.NoEdit;
            Columns[PMUOE04103EA.ct_Col_Comment].Header.VisiblePosition = visiblePosition++;
            // �i��
            Columns[PMUOE04103EA.ct_Col_GoodsName].Header.Caption = "�i��";
            Columns[PMUOE04103EA.ct_Col_GoodsName].Width = GRIDCOLUMN_WIDTH4;
            Columns[PMUOE04103EA.ct_Col_GoodsName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE04103EA.ct_Col_GoodsName].CellActivation = Activation.NoEdit;
            Columns[PMUOE04103EA.ct_Col_GoodsName].Header.VisiblePosition = visiblePosition++;
            // ����
            Columns[PMUOE04103EA.ct_Col_AcceptAnOrderCnt].Header.Caption = "����";
            Columns[PMUOE04103EA.ct_Col_AcceptAnOrderCnt].Width = GRIDCOLUMN_WIDTH5;
            Columns[PMUOE04103EA.ct_Col_AcceptAnOrderCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[PMUOE04103EA.ct_Col_AcceptAnOrderCnt].CellActivation = Activation.NoEdit;
            Columns[PMUOE04103EA.ct_Col_AcceptAnOrderCnt].Format = priceFormat;
            Columns[PMUOE04103EA.ct_Col_AcceptAnOrderCnt].Header.VisiblePosition = visiblePosition++;
            // BO�敪
            Columns[PMUOE04103EA.ct_Col_BOCode].Header.Caption = "BO�敪";
            Columns[PMUOE04103EA.ct_Col_BOCode].Width = GRIDCOLUMN_WIDTH6;
            Columns[PMUOE04103EA.ct_Col_BOCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[PMUOE04103EA.ct_Col_BOCode].CellActivation = Activation.NoEdit;
            Columns[PMUOE04103EA.ct_Col_BOCode].Header.VisiblePosition = visiblePosition++;
            // ���P��
            Columns[PMUOE04103EA.ct_Col_SalesUnitCost].Header.Caption = "���P��";
            Columns[PMUOE04103EA.ct_Col_SalesUnitCost].Width = GRIDCOLUMN_WIDTH7;
            Columns[PMUOE04103EA.ct_Col_SalesUnitCost].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[PMUOE04103EA.ct_Col_SalesUnitCost].CellActivation = Activation.NoEdit;
            // upd 2012/07/13 >>>
            //Columns[PMUOE04103EA.ct_Col_SalesUnitCost].Format = priceFormat;
            Columns[PMUOE04103EA.ct_Col_SalesUnitCost].Format = priceFormat2;
            // upd 2012/07/13 <<<
            Columns[PMUOE04103EA.ct_Col_SalesUnitCost].Header.VisiblePosition = visiblePosition++;
            // UOE���_�o�ɐ�
            Columns[PMUOE04103EA.ct_Col_UOESectOutGoodsCnt].Header.Caption = "�o�א�";
            Columns[PMUOE04103EA.ct_Col_UOESectOutGoodsCnt].Width = GRIDCOLUMN_WIDTH8;
            Columns[PMUOE04103EA.ct_Col_UOESectOutGoodsCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[PMUOE04103EA.ct_Col_UOESectOutGoodsCnt].CellActivation = Activation.NoEdit;
            Columns[PMUOE04103EA.ct_Col_UOESectOutGoodsCnt].Format = priceFormat;
            Columns[PMUOE04103EA.ct_Col_UOESectOutGoodsCnt].Header.VisiblePosition = visiblePosition++;
            // BO�o�ɐ�1
            Columns[PMUOE04103EA.ct_Col_BOShipmentCnt1].Header.Caption = "�o�א�";
            Columns[PMUOE04103EA.ct_Col_BOShipmentCnt1].Width = GRIDCOLUMN_WIDTH9;
            Columns[PMUOE04103EA.ct_Col_BOShipmentCnt1].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[PMUOE04103EA.ct_Col_BOShipmentCnt1].CellActivation = Activation.NoEdit;
            Columns[PMUOE04103EA.ct_Col_BOShipmentCnt1].Format = priceFormat;
            Columns[PMUOE04103EA.ct_Col_BOShipmentCnt1].Header.VisiblePosition = visiblePosition++;
            // BO�o�ɐ�2
            Columns[PMUOE04103EA.ct_Col_BOShipmentCnt2].Header.Caption = "�o�א�";
            Columns[PMUOE04103EA.ct_Col_BOShipmentCnt2].Width = GRIDCOLUMN_WIDTH10;
            Columns[PMUOE04103EA.ct_Col_BOShipmentCnt2].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[PMUOE04103EA.ct_Col_BOShipmentCnt2].CellActivation = Activation.NoEdit;
            Columns[PMUOE04103EA.ct_Col_BOShipmentCnt2].Format = priceFormat;
            Columns[PMUOE04103EA.ct_Col_BOShipmentCnt2].Header.VisiblePosition = visiblePosition++;
            // BO�o�ɐ�3
            Columns[PMUOE04103EA.ct_Col_BOShipmentCnt3].Header.Caption = "�o�א�";
            Columns[PMUOE04103EA.ct_Col_BOShipmentCnt3].Width = GRIDCOLUMN_WIDTH11;
            Columns[PMUOE04103EA.ct_Col_BOShipmentCnt3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[PMUOE04103EA.ct_Col_BOShipmentCnt3].CellActivation = Activation.NoEdit;
            Columns[PMUOE04103EA.ct_Col_BOShipmentCnt3].Format = priceFormat;
            Columns[PMUOE04103EA.ct_Col_BOShipmentCnt3].Header.VisiblePosition = visiblePosition++;
            // EO������
            Columns[PMUOE04103EA.ct_Col_EOAlwcCount].Header.Caption = "�o�א�";
            Columns[PMUOE04103EA.ct_Col_EOAlwcCount].Width = GRIDCOLUMN_WIDTH12;
            Columns[PMUOE04103EA.ct_Col_EOAlwcCount].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[PMUOE04103EA.ct_Col_EOAlwcCount].CellActivation = Activation.NoEdit;
            Columns[PMUOE04103EA.ct_Col_EOAlwcCount].Format = priceFormat;
            Columns[PMUOE04103EA.ct_Col_EOAlwcCount].Header.VisiblePosition = visiblePosition++;
            // �σw�b�_�[����6(MF)
            Columns[PMUOE04103EA.ct_Col_MakerFollowCnt].Header.Caption = "";
            Columns[PMUOE04103EA.ct_Col_MakerFollowCnt].Width = GRIDCOLUMN_WIDTH13;
            Columns[PMUOE04103EA.ct_Col_MakerFollowCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[PMUOE04103EA.ct_Col_MakerFollowCnt].CellActivation = Activation.NoEdit;
            Columns[PMUOE04103EA.ct_Col_MakerFollowCnt].Format = priceFormat;
            Columns[PMUOE04103EA.ct_Col_MakerFollowCnt].Header.VisiblePosition = visiblePosition++;
            // �c
            Columns[PMUOE04103EA.ct_Col_RemainderCount].Header.Caption = "�c";
            Columns[PMUOE04103EA.ct_Col_RemainderCount].Width = GRIDCOLUMN_WIDTH14;
            Columns[PMUOE04103EA.ct_Col_RemainderCount].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[PMUOE04103EA.ct_Col_RemainderCount].CellActivation = Activation.NoEdit;
            Columns[PMUOE04103EA.ct_Col_RemainderCount].Format = priceFormat;
            Columns[PMUOE04103EA.ct_Col_RemainderCount].Header.VisiblePosition = visiblePosition++;
            // �q�ɁE�I��
            Columns[PMUOE04103EA.ct_Col_WarehouseShelfNo].Header.Caption = "�q�ɁE�I��";
            Columns[PMUOE04103EA.ct_Col_WarehouseShelfNo].Width = GRIDCOLUMN_WIDTH15;
            Columns[PMUOE04103EA.ct_Col_WarehouseShelfNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE04103EA.ct_Col_WarehouseShelfNo].CellActivation = Activation.NoEdit;
            Columns[PMUOE04103EA.ct_Col_WarehouseShelfNo].Header.VisiblePosition = visiblePosition++;
            // �O�i�F
            Columns[PMUOE04103EA.ct_Col_ForeColor].Hidden = true;
            Columns[PMUOE04103EA.ct_Col_ForeColor].Header.Caption = "�O�i�F";
            Columns[PMUOE04103EA.ct_Col_ForeColor].Width = GRIDCOLUMN_WIDTH16;
            Columns[PMUOE04103EA.ct_Col_ForeColor].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[PMUOE04103EA.ct_Col_ForeColor].CellActivation = Activation.NoEdit;
            Columns[PMUOE04103EA.ct_Col_ForeColor].Header.VisiblePosition = visiblePosition++;
            #endregion

            #region ���ڕ\���ʒu�ݒ�
            // UOE�����s�ԍ�
            Columns[PMUOE04103EA.ct_Col_UOESalesOrderRowNo].RowLayoutColumnInfo.OriginX = 0;
            Columns[PMUOE04103EA.ct_Col_UOESalesOrderRowNo].RowLayoutColumnInfo.OriginY = 0;
            // ��֕i��
            Columns[PMUOE04103EA.ct_Col_WarehouseShelfNo].RowLayoutColumnInfo.OriginX = 1;
            Columns[PMUOE04103EA.ct_Col_WarehouseShelfNo].RowLayoutColumnInfo.OriginY = 0;
            // �i��
            Columns[PMUOE04103EA.ct_Col_GoodsNo].RowLayoutColumnInfo.OriginX = 2;
            Columns[PMUOE04103EA.ct_Col_GoodsNo].RowLayoutColumnInfo.OriginY = 0;
            // ���[�J�[
            Columns[PMUOE04103EA.ct_Col_GoodsMakerCd].RowLayoutColumnInfo.OriginX = 3;
            Columns[PMUOE04103EA.ct_Col_GoodsMakerCd].RowLayoutColumnInfo.OriginY = 0;
            // ��1
            Columns[PMUOE04103EA.ct_Col_Blank1].RowLayoutColumnInfo.OriginX = 4;
            Columns[PMUOE04103EA.ct_Col_Blank1].RowLayoutColumnInfo.OriginY = 0;
            // �艿
            Columns[PMUOE04103EA.ct_Col_ListPrice].RowLayoutColumnInfo.OriginX = 5;
            Columns[PMUOE04103EA.ct_Col_ListPrice].RowLayoutColumnInfo.OriginY = 0;
            // �σw�b�_�[����1(���_�`�[)
            Columns[PMUOE04103EA.ct_Col_UOESectionSlipNo].RowLayoutColumnInfo.OriginX = 6;
            Columns[PMUOE04103EA.ct_Col_UOESectionSlipNo].RowLayoutColumnInfo.OriginY = 0;
            // �σw�b�_�[����2(BO�`�[1)
            Columns[PMUOE04103EA.ct_Col_BOSlipNo1].RowLayoutColumnInfo.OriginX = 7;
            Columns[PMUOE04103EA.ct_Col_BOSlipNo1].RowLayoutColumnInfo.OriginY = 0;
            // �σw�b�_�[����3(BO�`�[2)
            Columns[PMUOE04103EA.ct_Col_BOSlipNo2].RowLayoutColumnInfo.OriginX = 8;
            Columns[PMUOE04103EA.ct_Col_BOSlipNo2].RowLayoutColumnInfo.OriginY = 0;
            // �σw�b�_�[����4(BO�`�[3)
            Columns[PMUOE04103EA.ct_Col_BOSlipNo3].RowLayoutColumnInfo.OriginX = 9;
            Columns[PMUOE04103EA.ct_Col_BOSlipNo3].RowLayoutColumnInfo.OriginY = 0;
            // �σw�b�_�[����5(BO�Ǘ�No.)
            Columns[PMUOE04103EA.ct_Col_BOManagementNo].RowLayoutColumnInfo.OriginX = 10;
            Columns[PMUOE04103EA.ct_Col_BOManagementNo].RowLayoutColumnInfo.OriginY = 0;
            // ��2
            Columns[PMUOE04103EA.ct_Col_Blank2].RowLayoutColumnInfo.OriginX = 11;
            Columns[PMUOE04103EA.ct_Col_Blank2].RowLayoutColumnInfo.OriginY = 0;
            // ���
            Columns[PMUOE04103EA.ct_Col_UOESubstMark].RowLayoutColumnInfo.OriginX = 12;
            Columns[PMUOE04103EA.ct_Col_UOESubstMark].RowLayoutColumnInfo.OriginY = 0;
            // �R�����g
            Columns[PMUOE04103EA.ct_Col_Comment].RowLayoutColumnInfo.OriginX = 13;
            Columns[PMUOE04103EA.ct_Col_Comment].RowLayoutColumnInfo.OriginY = 0;
            // �i��
            Columns[PMUOE04103EA.ct_Col_GoodsName].RowLayoutColumnInfo.OriginX = 2;
            Columns[PMUOE04103EA.ct_Col_GoodsName].RowLayoutColumnInfo.OriginY = 1;
            // ����
            Columns[PMUOE04103EA.ct_Col_AcceptAnOrderCnt].RowLayoutColumnInfo.OriginX = 3;
            Columns[PMUOE04103EA.ct_Col_AcceptAnOrderCnt].RowLayoutColumnInfo.OriginY = 1;
            // BO�敪
            Columns[PMUOE04103EA.ct_Col_BOCode].RowLayoutColumnInfo.OriginX = 4;
            Columns[PMUOE04103EA.ct_Col_BOCode].RowLayoutColumnInfo.OriginY = 1;
            // �P��
            Columns[PMUOE04103EA.ct_Col_SalesUnitCost].RowLayoutColumnInfo.OriginX = 5;
            Columns[PMUOE04103EA.ct_Col_SalesUnitCost].RowLayoutColumnInfo.OriginY = 1;
            // UOE���_�o�ɐ�
            Columns[PMUOE04103EA.ct_Col_UOESectOutGoodsCnt].RowLayoutColumnInfo.OriginX = 6;
            Columns[PMUOE04103EA.ct_Col_UOESectOutGoodsCnt].RowLayoutColumnInfo.OriginY = 1;
            // BO�o�ɐ�1
            Columns[PMUOE04103EA.ct_Col_BOShipmentCnt1].RowLayoutColumnInfo.OriginX = 7;
            Columns[PMUOE04103EA.ct_Col_BOShipmentCnt1].RowLayoutColumnInfo.OriginY = 1;
            // BO�o�ɐ�2
            Columns[PMUOE04103EA.ct_Col_BOShipmentCnt2].RowLayoutColumnInfo.OriginX = 8;
            Columns[PMUOE04103EA.ct_Col_BOShipmentCnt2].RowLayoutColumnInfo.OriginY = 1;
            // BO�o�ɐ�3
            Columns[PMUOE04103EA.ct_Col_BOShipmentCnt3].RowLayoutColumnInfo.OriginX = 9;
            Columns[PMUOE04103EA.ct_Col_BOShipmentCnt3].RowLayoutColumnInfo.OriginY = 1;
            // EO������
            Columns[PMUOE04103EA.ct_Col_EOAlwcCount].RowLayoutColumnInfo.OriginX = 10;
            Columns[PMUOE04103EA.ct_Col_EOAlwcCount].RowLayoutColumnInfo.OriginY = 1;
            // �σw�b�_�[����6(MF)
            Columns[PMUOE04103EA.ct_Col_MakerFollowCnt].RowLayoutColumnInfo.OriginX = 11;
            Columns[PMUOE04103EA.ct_Col_MakerFollowCnt].RowLayoutColumnInfo.OriginY = 1;
            // �c
            Columns[PMUOE04103EA.ct_Col_RemainderCount].RowLayoutColumnInfo.OriginX = 12;
            Columns[PMUOE04103EA.ct_Col_RemainderCount].RowLayoutColumnInfo.OriginY = 1;
            // �q�ɁE�I��
            Columns[PMUOE04103EA.ct_Col_WarehouseShelfNo].RowLayoutColumnInfo.OriginX = 13;
            Columns[PMUOE04103EA.ct_Col_WarehouseShelfNo].RowLayoutColumnInfo.OriginY = 1;
            // �O�i�F
            Columns[PMUOE04103EA.ct_Col_ForeColor].RowLayoutColumnInfo.OriginX = 14;
            Columns[PMUOE04103EA.ct_Col_ForeColor].RowLayoutColumnInfo.OriginY = 0;
            #endregion

            // Group�ݒ�(1����2�s�ɂ����)
            if (grids.DisplayLayout.Bands[PMUOE04103EA.ct_Tbl_OrderAnsDetail].Groups.Count == 0)
            {
                UltraGridBand ultraGriBand = grids.DisplayLayout.Bands[PMUOE04103EA.ct_Tbl_OrderAnsDetail];
                ultraGriBand.Groups.Add(PMUOE04103EA.ct_Grp_OrderAnsDeltail);   // Grid��Band��Group�ǉ�
                ultraGriBand.UseRowLayout = true;                               // �ʒu���(RowLayoutColumnInfo)���g�p
                ultraGriBand.GroupHeadersVisible = false;                       // �w�b�_�[��\��
                ultraGriBand.LevelCount = 2;                                    // �s����2�s�ɐݒ�

                UltraGridGroup ultraGridGroup = ultraGriBand.Groups[PMUOE04103EA.ct_Grp_OrderAnsDeltail];
                foreach (UltraGridColumn ultraGridColumn in Columns)
                {
                    // ���ʐݒ�
                    ultraGridColumn.RowLayoutColumnInfo.SpanX = 1;
                    ultraGridColumn.RowLayoutColumnInfo.SpanY = 1;

                    switch (ultraGridColumn.Key)
                    {
                        case PMUOE04103EA.ct_Col_UOESalesOrderRowNo:
                        case PMUOE04103EA.ct_Col_WarehouseShelfNo:
                        case PMUOE04103EA.ct_Col_ForeColor:
                            {
                                ultraGridColumn.RowLayoutColumnInfo.SpanY = 2;
                                break;
                            }
                    }

                    // Group��Column��ǉ�
                    ultraGridGroup.Columns.Add(ultraGridColumn);
                }
            }
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
        /// <br>Date       : 2008/11/06</br>
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
                        status = this._orderAnswerAcs.SearchFirst(out dataSet1,out dataSet2);
                        break;
                    }
                // �O�f�[�^
                case SEARCH_BEFORE:
                    {
                        status = this._orderAnswerAcs.SearchBefore(out dataSet1,out dataSet2);
                        if (status == false)
                        {
                            // �擪�f�[�^�ł��B
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.ToString(), MSG_NODATA_BEFORE, 0, MessageBoxButtons.OK);
                        }
                        break;
                    }
                // ���f�[�^
                case SEARCH_NEXT:
                    {
                        status = this._orderAnswerAcs.SearchNext(out dataSet1,out dataSet2);
                        if (status == false)
                        {
                            // �f�[�^���I�����܂����B
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.ToString(), MSG_NODATA_NEXT, 0, MessageBoxButtons.OK);
                        }
                        break;
                    }
            }

            // �f�[�^�\��
            if (status)
            {
                this.DispHeaderFooter(dataSet1);            // ���׈ȊO(�w�b�_�[�A�t�b�^�[��)�\��       //ADD 2008/12/18 �@
                this.DispSupplierData(dataSet1);            // ���׈ȊO(�O���b�h�w�b�_�[��)�\��
                this.Answer_Grid.DataSource = dataSet2;     // ���ו\��

                // �O���b�h�O�i�F�ύX
                this.ChangeGridRowForeColor();
            }
        }
        #endregion

        #region ��DispGridHeaderData(�O���b�h�w�b�_�[�f�[�^�擾)
        /// <summary>
        /// �O���b�h�w�b�_�[�f�[�^�擾
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����������ɃO���b�h�̃w�b�_�[�̎擾���s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private void DispGridHeaderData()
        {
            // �O���b�h�w�b�_�[���ڎ擾(�O���b�h�̃w�b�_�[�̂�)
            DataSet dataSet;
            this._orderAnswerAcs.GetGridHeaderDataSet(this.tNedit_SupplierCd.GetInt(), out dataSet);

            // �\��
            this.DispSupplierData(dataSet);
        }
        #endregion

        #region ��DispSupplierData(������P��(���׃w�b�_�[��)�̃f�[�^�\��)
        /// <summary>
        /// ���׃w�b�_�[���̃f�[�^�\��
        /// </summary>
        /// <param name="dataSet">���׈ȊO�̃f�[�^</param>
        /// <remarks>
        /// <br>Note       : ������P��(���׃w�b�_�[��)�̃f�[�^�̕\�����s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private void DispSupplierData(DataSet dataSet)
        {
            // �O���b�h�X�V
            ColumnsCollection Columns = this.Answer_Grid.DisplayLayout.Bands[PMUOE04103EA.ct_Tbl_OrderAnsDetail].Columns;

            foreach (DataRow dataRow in dataSet.Tables[PMUOE04103EA.ct_Tbl_OrderAnsSupplier].Rows)
            {
                /* --- DEL 2008/12/18 �@ ------------------------------------------------------------------------------------->>>>>
                //// �w�b�_�[
                //this.lb_SalesDate.Text = dataRow[PMUOE04103EA.ct_Col_SalesDate].ToString();                         // ������
                //this.lb_UOESalesOrderNo.Text = dataRow[PMUOE04103EA.ct_Col_UOESalesOrderNo].ToString();             // �����ԍ�
                //this.lb_UOESupplierName.Text = dataRow[PMUOE04103EA.ct_Col_UOESupplierName].ToString();             // ������
                //this.lb_Remark1.Text = dataRow[PMUOE04103EA.ct_Col_UoeRemark1].ToString();                          // ���}�[�N�P
                //this.lb_Remark2.Text = dataRow[PMUOE04103EA.ct_Col_UoeRemark2].ToString();                          // ���}�[�N�Q
                //this.lb_DeliveredGoodsDivNm.Text = dataRow[PMUOE04103EA.ct_Col_DeliveredGoodsDivNm].ToString();     // �[�i�敪
                //this.lb_FollowDeliGoodsDivNm.Text = dataRow[PMUOE04103EA.ct_Col_FollowDeliGoodsDivNm].ToString();   // �g�[�i�敪
                //this.lb_UOERecvdSectionNm.Text = dataRow[PMUOE04103EA.ct_Col_UOEResvdSectionNm].ToString();         // ���_
                //this.lb_EmployeeName.Text = dataRow[PMUOE04103EA.ct_Col_EmployeeName].ToString();                   // �˗���
                   --- DEL 2008/12/18 �@ -------------------------------------------------------------------------------------<<<<< */

                // �O���b�h�w�b�_�[
                Columns[PMUOE04103EA.ct_Col_UOESectionSlipNo].Header.Caption = dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName1].ToString();           // ���_�`�[
                Columns[PMUOE04103EA.ct_Col_BOSlipNo1].Header.Caption = dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName2].ToString();                  // BO�`�[1
                Columns[PMUOE04103EA.ct_Col_BOSlipNo2].Header.Caption = dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName3].ToString();                  // BO�`�[2
                Columns[PMUOE04103EA.ct_Col_BOSlipNo3].Header.Caption = dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName4].ToString();                  // BO�`�[3
                Columns[PMUOE04103EA.ct_Col_BOManagementNo].Header.Caption = dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName5].ToString();             // BO�Ǘ�No.
                Columns[PMUOE04103EA.ct_Col_MakerFollowCnt].Header.Caption = dataRow[PMUOE04103EA.ct_Col_GridHeadVariableName6].ToString();             // MF
                Columns[PMUOE04103EA.ct_Col_UOESectOutGoodsCnt].Header.Caption = dataRow[PMUOE04103EA.ct_Col_GridHeadShipmentCntName1].ToString();      // ���_�`�[�o�א�1
                Columns[PMUOE04103EA.ct_Col_BOShipmentCnt1].Header.Caption = dataRow[PMUOE04103EA.ct_Col_GridHeadShipmentCntName2].ToString();          // BO�`�[1�o�א�
                Columns[PMUOE04103EA.ct_Col_BOShipmentCnt2].Header.Caption = dataRow[PMUOE04103EA.ct_Col_GridHeadShipmentCntName3].ToString();          // BO�`�[2�o�א�
                Columns[PMUOE04103EA.ct_Col_BOShipmentCnt3].Header.Caption = dataRow[PMUOE04103EA.ct_Col_GridHeadShipmentCntName4].ToString();          // BO�`�[3�o�א�
                Columns[PMUOE04103EA.ct_Col_EOAlwcCount].Header.Caption = dataRow[PMUOE04103EA.ct_Col_GridHeadShipmentCntName5].ToString();             // BO�Ǘ�No.�o�א�

                /* --- DEL 2008/12/18 �@ ------------------------------------------------------------------------------------->>>>>
                //// �t�b�^�[
                //this.lb_SystemDivName.Text = dataRow[PMUOE04103EA.ct_Col_SystemDivName].ToString();                  // �V�X�e���敪
                   --- DEL 2008/12/18 �@ -------------------------------------------------------------------------------------<<<<< */

                return;
            }
        }
        #endregion

        #region ��DispHeaderFooter(������P��(�w�b�_�[�A�t�b�^�[��)�̃f�[�^�\��)  ADD 2008/12/18 �@
        /// <summary>
        /// �w�b�_�[�A�t�b�^�[���̃f�[�^�\��
        /// </summary>
        /// <param name="dataSet">���׈ȊO�̃f�[�^</param>
        /// <remarks>
        /// <br>Note       : ������P��(�w�b�_�[�A�t�b�^�[��)�̃f�[�^�̕\�����s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/12/18</br>
        /// </remarks>
        private void DispHeaderFooter(DataSet dataSet)
        {
            foreach (DataRow dataRow in dataSet.Tables[PMUOE04103EA.ct_Tbl_OrderAnsSupplier].Rows)
            {
                // �w�b�_�[
                this.lb_SalesDate.Text = dataRow[PMUOE04103EA.ct_Col_SalesDate].ToString();                         // ������
                this.lb_UOESalesOrderNo.Text = dataRow[PMUOE04103EA.ct_Col_UOESalesOrderNo].ToString();             // �����ԍ�
                this.lb_UOESupplierName.Text = dataRow[PMUOE04103EA.ct_Col_UOESupplierName].ToString();             // ������
                this.lb_Remark1.Text = dataRow[PMUOE04103EA.ct_Col_UoeRemark1].ToString();                          // ���}�[�N�P
                this.lb_Remark2.Text = dataRow[PMUOE04103EA.ct_Col_UoeRemark2].ToString();                          // ���}�[�N�Q
                this.lb_DeliveredGoodsDivNm.Text = dataRow[PMUOE04103EA.ct_Col_DeliveredGoodsDivNm].ToString();     // �[�i�敪
                this.lb_FollowDeliGoodsDivNm.Text = dataRow[PMUOE04103EA.ct_Col_FollowDeliGoodsDivNm].ToString();   // �g�[�i�敪
                this.lb_UOERecvdSectionNm.Text = dataRow[PMUOE04103EA.ct_Col_UOEResvdSectionNm].ToString();         // ���_
                this.lb_EmployeeName.Text = dataRow[PMUOE04103EA.ct_Col_EmployeeName].ToString();                   // �˗���

                // �t�b�^�[
                this.lb_SystemDivName.Text = dataRow[PMUOE04103EA.ct_Col_SystemDivName].ToString();                  // �V�X�e���敪

                return;
            }
        }
        #endregion

        #region ��ChangeViewPopupToolbarStatus(�߂�E�i�ރ{�^���\��/��\��)
        /// <summary>
        /// �߂�E�i�ރ{�^���\���ݒ�
        /// </summary>
        /// <param name="flg">True�F�\���AFalse�F��\��</param>
        /// <remarks>
        /// <br>Note       : �߂�E�i�ރ{�^���̕\��/��\���ݒ���s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private void ChangeViewPopupToolbarStatus(bool flg)
        {
            this.Main_ToolbarsManager.Tools["View_PopupMenuTool"].SharedProps.Visible = flg;    // �\��(V)
            this.Main_ToolbarsManager.Tools["LabelTool1"].SharedProps.Visible = flg;            // |�@(��؂��)
            this.Main_ToolbarsManager.Tools["Before_ButtonTool"].SharedProps.Visible = flg;     // �߂�
            this.Main_ToolbarsManager.Tools["Next_ButtonTool"].SharedProps.Visible = flg;       // �i��
        }
        #endregion

        #region ��ChangeSearchConditionStatus(�����֘A�\��/��\��)
        /// <summary>
        /// �����֘A�\���ݒ�
        /// </summary>
        /// <param name="flg">True�F�\���AFalse�F��\��</param>
        /// <remarks>
        /// <br>Note       : �����֘A�̕\��/��\���ݒ���s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private void ChangeSearchConditionStatus(bool flg)
        {
            this.Main_ToolbarsManager.Tools["Search_ButtonTool"].SharedProps.Visible = flg;     // �����{�^��
            this.Main_ToolbarsManager.Tools["Clear_ButtonTool"].SharedProps.Visible = flg;      // �N���A�{�^��
            pnl_SearchCondition.Visible = flg;                                                  // ��������
        }

        #endregion

        #region ��ChangeGridRowForeColor(�O���b�h�O�i�F�ύX)
        /// <summary>
        /// �O���b�h�O�i�F�ύX
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�̑O�i�F�ύX���s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private void ChangeGridRowForeColor()
        {
            foreach (UltraGridRow ultraGridRow in this.Answer_Grid.Rows)
            {
                // �O�i�F�ύX
                switch (ultraGridRow.Cells[PMUOE04103EA.ct_Col_ForeColor].Value.ToString())
                {
                    case "BLUE":
                        {
                            // �� �� �d�ؖ����^�ꕔ�c�^Ұ��̫۰��
                            ultraGridRow.Appearance.ForeColor = Color.FromArgb(0, 0, 255);
                            break;
                        }
                    case "GREEN":
                        {
                            // �� �� ��֕i
                            ultraGridRow.Cells[PMUOE04103EA.ct_Col_Comment].Appearance.ForeColor = Color.FromArgb(51, 153, 102);            // �O�i�F
                            ultraGridRow.Cells[PMUOE04103EA.ct_Col_Comment].SelectedAppearance.ForeColor = Color.FromArgb(51, 153, 102);    // �I�����̑O�i�F
                            break;
                        }
                    case "RED":
                        {
                            // �� �� �S���c
                            ultraGridRow.Appearance.ForeColor = Color.FromArgb(255, 0, 0);
                            break;
                        }
                    default:
                        ultraGridRow.Cells[PMUOE04103EA.ct_Col_GoodsName].Appearance.ForeColor = Color.Empty;
                        break;
                }
            }
        }

        #endregion

        #region ��ToolbarSearchClick(�P�̋N����p)
        /// <summary>
        /// �c�[���o�[�̌����{�^������������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����f�[�^�𑗎�M�W���[�i��(����)�`���ɕϊ���A�f�[�^�̎擾���s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private void ToolbarSearchClick()
        {
            string errorMsg;

            // �������`�F�b�N
            if (this.CheckConditionSalesDay() == CHECKDATA_FAILED)
            {
                return;
            }
            // ������`�F�b�N
            if (this.CheckConditionSupplier() == CHECKDATA_FAILED)
            {
                return;
            }

            // ���o�����ݒ�
            UOEAnswerLedgerOrderCndtn uoeAnswerLedgerOrderCndtn = new UOEAnswerLedgerOrderCndtn();
            uoeAnswerLedgerOrderCndtn.EnterpriseCode = this._enterpriseCode;            // ��ƃR�[�h
            uoeAnswerLedgerOrderCndtn.SectionCode = this._sectionCode.TrimEnd();        // ���_�R�[�h
            uoeAnswerLedgerOrderCndtn.SystemDivCd = -1;                                 // �V�X�e���敪(-1�F�S��)
            uoeAnswerLedgerOrderCndtn.St_ReceiveDate = DateTime.ParseExact(this._backup.SalesDaySt.ToString(), "yyyyMMdd", null);   // �J�n������
            uoeAnswerLedgerOrderCndtn.Ed_ReceiveDate = DateTime.ParseExact(this._backup.SalesDayEd.ToString(), "yyyyMMdd", null);   // �I��������
            uoeAnswerLedgerOrderCndtn.UOESupplierCd = this._backup.SupplierCd;          // ������R�[�h
            uoeAnswerLedgerOrderCndtn.UOEKind = 0;                                      // UOE���(0�FUOE�Œ�)      //ADD 2008/12/18 �B
            uoeAnswerLedgerOrderCndtn.St_InputDay = DateTime.MinValue;                  // ���͓�(�J�n)             //ADD 2008/12/18 �B
            uoeAnswerLedgerOrderCndtn.Ed_InputDay = DateTime.MinValue;                  // ���͓�(�I��)             //ADD 2008/12/18 �B

            // �f�[�^�擾
            bool status = this._orderAnswerAcs.SearchFirst(uoeAnswerLedgerOrderCndtn, out errorMsg);
            if (status == false)
            {
                this.AllInitializeLayout(SEARCHCONDITION_NO_CLEAR);

                // �G���[�����b�Z�[�W�\��
                if (string.IsNullOrEmpty(errorMsg) == false)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.ToString(), errorMsg, 0, MessageBoxButtons.OK);
                }
                return;
            }

            // �f�[�^�\��
            this.Search(SEARCH_FIRST);

            this.ChangeViewPopupToolbarStatus(true);
        }
        #endregion

        #region ��ToolbarClearClick(�P�̋N����p)
        /// <summary>
        /// �c�[���o�[�̃N���A�{�^������������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʕ\����������Ԃɖ߂��܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private void ToolbarClearClick()
        {
            this.AllInitializeLayout(SEARCHCONDITION_CLEAR);

            this.tde_st_SalesDay.Focus();
        }

        #endregion

        #region ��CheckConditionSalesDay(���������̓`�F�b�N�@�P�̋N����p)
        /// <summary>
        /// ���������̓`�F�b�N
        /// </summary>
        /// <returns>-1�FNG�A0�F�����́A1�FOK</returns>
        /// <remarks>
        /// <br>Note       : �������̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
        /// </remarks>
        private int CheckConditionSalesDay()
        {
            // ���t�K�{�`�F�b�N
            if (this.tde_st_SalesDay.GetDateTime() == DateTime.MinValue)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.ToString(), "�������J�n�̓��͂��s���ł�", 0, MessageBoxButtons.OK);
                this.tde_st_SalesDay.Focus();
                return CHECKDATA_FAILED;
            }
            if (this.tde_ed_SalesDay.GetDateTime() == DateTime.MinValue)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.ToString(), "�������I���̓��͂��s���ł�", 0, MessageBoxButtons.OK);
                this.tde_ed_SalesDay.Focus();
                return CHECKDATA_FAILED;
            }
            // ���t�召�`�F�b�N
            if (this.tde_st_SalesDay.GetLongDate() > tde_ed_SalesDay.GetLongDate())
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.ToString(), "�������͊J�n���I���ƂȂ�悤�ɓ��͂��ĉ�����", 0, MessageBoxButtons.OK);
                this.tde_st_SalesDay.Focus();
                return CHECKDATA_FAILED;
            }

            // ���t�͈̓`�F�b�N
            if (this.tde_st_SalesDay.GetDateTime().AddMonths(3) < tde_ed_SalesDay.GetDateTime())
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.ToString(), "�������̓��t�͈͂��L�����܂��B�R�����ȓ��Őݒ肵�Ă�������", 0, MessageBoxButtons.OK);
                this.tde_st_SalesDay.Focus();
                return CHECKDATA_FAILED;
            }

            return CHECKDATA_SUCCESS;
        }
        #endregion

        #region ��CheckConditionSupplier(��������̓`�F�b�N�@�P�̋N����p)
        /// <summary>
        /// ��������̓`�F�b�N
        /// </summary>
        /// <returns>-1�FNG�A0�F�����́A1�FOK</returns>
        /// <remarks>
        /// <br>Note       : ������̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2008/11/06</br>
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
                // �l�Ȃ�
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.ToString(), "������ [" + this.tNedit_SupplierCd.Value.ToString() + "] �ɊY������f�[�^�����݂��܂���B", 0, MessageBoxButtons.OK);
                this.tNedit_SupplierCd.Focus();
                return CHECKDATA_FAILED;
            }

            this.lb_SupplierName.Text = name;
            return CHECKDATA_SUCCESS;
        }
        #endregion

        // ���͒l���J�o���[�֘A
        #region ��BackupInputValue(���͒l�̕ێ��|�S��)
        /// <summary>
        /// ���͒l�ۑ�
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���͒l��ۑ����܂��B</br>
        /// <br>Programmer	: �Ɠc �M�u</br>
        /// <br>Date		: 2008/11/06</br>
        /// </remarks>
        private void BackupInputValueAll()
        {
            this.BackupInputValue(this.tde_st_SalesDay);        // ������From
            this.BackupInputValue(this.tde_ed_SalesDay);        // ������To
            this.BackupInputValue(this.tNedit_SupplierCd);      // ������
        }
        #endregion

        #region ��BackupInputValue(���͒l�̕ێ��|�P��)
        /// <summary>
        /// ���͒l�ۑ�
        /// </summary>
        /// <param name="ctrl">�ΏۃR���g���[��</param>
        /// <remarks>
        /// <br>Note		: ���͒l��ۑ����܂��B</br>
        /// <br>Programmer	: �Ɠc �M�u</br>
        /// <br>Date		: 2008/11/06</br>
        /// </remarks>
        private void BackupInputValue(Control ctrl)
        {
            // ������From
            if (ctrl == this.tde_st_SalesDay)
            {
                this._backup.SalesDaySt = this.tde_st_SalesDay.GetLongDate();
                return;
            }

            // ������To
            if (ctrl == this.tde_ed_SalesDay)
            {
                this._backup.SalesDayEd = this.tde_ed_SalesDay.GetLongDate();
                return;
            }
            // ������
            if (ctrl == this.tNedit_SupplierCd)
            {
                this._backup.SupplierCd = this.tNedit_SupplierCd.GetInt();
                this._backup.SupplierName = this.lb_SupplierName.Text;
                return;
            }
        }
        #endregion

        #region ��RecoverInputValue(�ێ������l�ɖ߂�)
        /// <summary>
        /// ���͒l���J�o���[
        /// </summary>
        /// <param name="ctrl">�ΏۃR���g���[��</param>
        /// <remarks>
        /// <br>Note		: ���͒l����͑O�̒l�ɖ߂��܂��B</br>
        /// <br>Programmer	: �Ɠc �M�u</br>
        /// <br>Date		: 2008/11/06</br>
        /// </remarks>
        private void RecoverInputValue(Control ctrl)
        {
            // ������From
            if (ctrl == this.tde_st_SalesDay)
            {
                this.tde_st_SalesDay.SetLongDate(this._backup.SalesDaySt);
                return;
            }
            // ������To
            if (ctrl == this.tde_ed_SalesDay)
            {
                this.tde_ed_SalesDay.SetLongDate(this._backup.SalesDayEd);
                return;
            }

            // ������
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
        #endregion ��Private���\�b�h - end
    }
}
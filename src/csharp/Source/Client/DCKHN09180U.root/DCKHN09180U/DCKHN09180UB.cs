using System.Diagnostics;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
//using Broadleaf.Application.Remoting.ParamData;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �|���}�X�^�ꊇ�o�^ ���o���ʓ��͉�ʃN���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �|���}�X�^�ꊇ�o�^ ���o���ʓ��͉�ʃN���X</br>
	/// <br>Programmer	: 30167 ���@�O�M</br>
	/// <br>Date		: 2007.11.08</br>
	/// <br>Update Note: 2008.02.07 30167 ���@�O�M</br>
	/// <br>			 �ۑ������̃��b�Z�[�W��ۑ������_�C�A���O�\���ɏC��</br>
	/// <br>Update Note: 2008.02.18 30167 ���@�O�M</br>
	/// <br>			 �E�O���b�h�s���f�[�^���͎��G���[���b�Z�[�W�}�������ǉ�
	///					 �E�[�������P�ʂ̌����`�F�b�N�ǉ�</br>
	/// <br>Update Note: 2008.03.10 30167 ���@�O�M</br>
	/// <br>			 �E�O���b�h�w�b�_�[�N���b�N�\�[�g�ǉ��i��ʃf�U�C���̂ݏC���j</br>
	/// <br>Update Note: 2008.03.28 30167 ���@�O�M</br>
	///	<br>			 �E�|�����i�敪�w�薳�����[�g�̕s��C��</br>
	///	<br>			 �E���i�敪�ڍׂ̓���f�[�^�������\�������s��C��</br>
	/// </remarks>
	public class DCKHN09180UB : Form, IInventInputMdiChild
	{
		#region Private Members (Component)

		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager utb_InventDataToolBar;
		private System.Windows.Forms.Panel DCKHN09180UB_Fill_Panel;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _DCKHN09180UB_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _DCKHN09180UB_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _DCKHN09180UB_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _DCKHN09180UB_Toolbars_Dock_Area_Bottom;
		private Infragistics.Win.UltraWinGrid.UltraGrid rateBlanketResult_uGrid;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar usb_GridSettingBar;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor uce_ColSizeAutoSetting;
		private Broadleaf.Library.Windows.Forms.TComboEditor tce_FontSize;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl;
		private Infragistics.Win.UltraWinToolTip.UltraToolTipManager uttm_ViewGridInfoToolTip;
		private Panel panel1;
		private Infragistics.Win.Misc.UltraButton ub_replaceButton;
		private System.ComponentModel.IContainer components = null;

		#endregion
	
		#region Constructor
		/// <summary>
		/// �|���}�X�^�ꊇ�o�^ ���o���ʓ��͉�ʃN���X
		/// </summary>
		/// <remarks>
		/// <br>Note       : �|���}�X�^�ꊇ�o�^ ���o���ʓ��͉�ʃN���X�̃C���X�^���X���쐬</br>
		/// <br>Programmer	: 30167 ���@�O�M</br>
		/// <br>Date		: 2007.11.08</br>
		/// <br>Update Note: </br>
		/// </remarks>
		public DCKHN09180UB ()
		{
			InitializeComponent();
			
			this._rateBlanketAcs = new RateBlanketAcs();		// �|���}�X�^�ꊇ�o�^�A�N�Z�X�N���X

			// �O���b�h�ݒ胍�[�h
			this._gridStateController = new GridStateController();
			this._gridStateController.LoadGridState(ct_FileName_ColDisplayStatus);

			//----------------------------------
			// �O���b�h�p�u�`�k�t�d���X�g
			//----------------------------------
			this._gVListPriceDiv = new ValueList();				// ���i�敪
			this._gVListUnPrcCalcDiv = new ValueList();			// �P���Z�o�敪
			this._gVListUnPrcCalcDivLimit = new ValueList();	// �P���Z�o�敪����Łi1�I��s�j
			this._gVListUnPrcFracProcUnit = new ValueList();	// �P���[������
			this._gVListBargainCd = new ValueList();			// �����敪�R�[�h

			// �����񌋍��p
			this._stringBuilder = new StringBuilder();

			this._rateAcs = new RateAcs();					// �|���}�X�^�A�N�Z�X�N���X
		}
		#endregion Constructor

		/// <summary>
		/// �g�p���̃��\�[�X�����ׂăN���[���A�b�v���܂��B
		/// </summary>
		/// <param name="disposing">�}�l�[�W ���\�[�X���j�������ꍇ true�A�j������Ȃ��ꍇ�� false �ł��B</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

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
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("utb_InventInputMain");
			Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool1 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ControlContainerTool1");
			Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool2 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ControlContainerTool2");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("tool_BIC_AllInput");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("tool_BIC_NoInput");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("tool_BIC_AllCansel");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("tool_BID_AllInput");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("tool_BID_NoInput");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("tool_BID_AllCansel");
			Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("tool_Dummy1");
			Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("tool_ViewStyleLabel");
			Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool3 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("tool_ViewStyleContainer");
			Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool("tool_SortOrder");
			Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool4 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("tool_SortOrderContainer");
			Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool5 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ControlContainerTool1");
			Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool6 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("tool_InventoryDate");
			Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool7 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("tool_InventAllInput");
			Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool("tool_lb_InventoryDay");
			Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("tool_ColHidden");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool1 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("WarehouseName", "");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool2 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("WarehouseShelfNo", "");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool3 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("DuplicationShelfNo1", "");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool4 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("DuplicationShelfNo2", "");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool5 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("MakerName", "");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool6 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("CustomerName", "");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool7 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("ShipCustomerName", "");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool8 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("StockTrtEntDivName", "");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("tool_Hidden_Initialize");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool9 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("WarehouseName", "");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool10 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("MakerName", "");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool11 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("CustomerName", "");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool12 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("ShipCustomerName", "");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool13 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("StockTrtEntDivName", "");
			Infragistics.Win.UltraWinToolbars.LabelTool labelTool5 = new Infragistics.Win.UltraWinToolbars.LabelTool("tool_Dummy2");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("tool_Hidden_Initialize");
			Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool8 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("tool_RowDelete");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool14 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("DuplicationShelfNo1", "");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool15 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("DuplicationShelfNo2", "");
			Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool16 = new Infragistics.Win.UltraWinToolbars.StateButtonTool("WarehouseShelfNo", "");
			Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("tool_ReplaceButton");
			Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool9 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ControlContainerTool2");
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
			Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
			Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
			Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
			Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel5 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
			Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel6 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
			Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel7 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
			Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel8 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
			Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel9 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
			Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel10 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
			this.ub_replaceButton = new Infragistics.Win.Misc.UltraButton();
			this.uce_ColSizeAutoSetting = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
			this.tce_FontSize = new Broadleaf.Library.Windows.Forms.TComboEditor();
			this.utb_InventDataToolBar = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
			this.DCKHN09180UB_Fill_Panel = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.rateBlanketResult_uGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
			this.usb_GridSettingBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
			this._DCKHN09180UB_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._DCKHN09180UB_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._DCKHN09180UB_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this._DCKHN09180UB_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
			this.tRetKeyControl = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
			this.tArrowKeyControl = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
			this.uttm_ViewGridInfoToolTip = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
			((System.ComponentModel.ISupportInitialize)(this.tce_FontSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.utb_InventDataToolBar)).BeginInit();
			this.DCKHN09180UB_Fill_Panel.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.rateBlanketResult_uGrid)).BeginInit();
			this.usb_GridSettingBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// ub_replaceButton
			// 
			this.ub_replaceButton.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10F);
			this.ub_replaceButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.ub_replaceButton.Location = new System.Drawing.Point(9, 13);
			this.ub_replaceButton.Name = "ub_replaceButton";
			this.ub_replaceButton.Size = new System.Drawing.Size(75, 23);
			this.ub_replaceButton.TabIndex = 1;
			this.ub_replaceButton.Text = "�u��(&R)";
			this.ub_replaceButton.Click += new System.EventHandler(this.ub_replaceButton_Click);
			// 
			// uce_ColSizeAutoSetting
			// 
			appearance1.FontData.SizeInPoints = 9F;
			this.uce_ColSizeAutoSetting.Appearance = appearance1;
			this.uce_ColSizeAutoSetting.BackColor = System.Drawing.Color.GhostWhite;
			this.uce_ColSizeAutoSetting.Location = new System.Drawing.Point(3, 4);
			this.uce_ColSizeAutoSetting.Name = "uce_ColSizeAutoSetting";
			this.uce_ColSizeAutoSetting.Size = new System.Drawing.Size(138, 16);
			this.uce_ColSizeAutoSetting.TabIndex = 3;
			this.uce_ColSizeAutoSetting.Text = "��T�C�Y�̎�������";
			this.uce_ColSizeAutoSetting.CheckedChanged += new System.EventHandler(this.uce_ColSizeAutoSetting_CheckedChanged);
			// 
			// tce_FontSize
			// 
			appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.tce_FontSize.ActiveAppearance = appearance2;
			appearance3.TextHAlign = Infragistics.Win.HAlign.Right;
			this.tce_FontSize.Appearance = appearance3;
			this.tce_FontSize.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.tce_FontSize.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.tce_FontSize.ImeMode = System.Windows.Forms.ImeMode.Disable;
			appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			appearance4.TextHAlign = Infragistics.Win.HAlign.Right;
			this.tce_FontSize.ItemAppearance = appearance4;
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
			this.tce_FontSize.Items.Add(valueListItem1);
			this.tce_FontSize.Items.Add(valueListItem2);
			this.tce_FontSize.Items.Add(valueListItem3);
			this.tce_FontSize.Items.Add(valueListItem4);
			this.tce_FontSize.Items.Add(valueListItem5);
			this.tce_FontSize.Items.Add(valueListItem6);
			this.tce_FontSize.Items.Add(valueListItem7);
			this.tce_FontSize.Location = new System.Drawing.Point(234, 3);
			this.tce_FontSize.Name = "tce_FontSize";
			this.tce_FontSize.Size = new System.Drawing.Size(40, 21);
			this.tce_FontSize.TabIndex = 5;
			this.tce_FontSize.ValueChanged += new System.EventHandler(this.tce_FontSize_ValueChanged);
			// 
			// utb_InventDataToolBar
			// 
			this.utb_InventDataToolBar.DesignerFlags = 1;
			this.utb_InventDataToolBar.DockWithinContainer = this;
			this.utb_InventDataToolBar.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
			this.utb_InventDataToolBar.ShowFullMenusDelay = 500;
			this.utb_InventDataToolBar.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
			ultraToolbar1.DockedColumn = 0;
			ultraToolbar1.DockedRow = 0;
			ultraToolbar1.FloatingSize = new System.Drawing.Size(146, 45);
			ultraToolbar1.Settings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
			ultraToolbar1.Text = "�V���\��";
			controlContainerTool2.Control = this.ub_replaceButton;
			controlContainerTool2.InstanceProps.IsFirstInGroup = true;
			ultraToolbar1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            controlContainerTool1,
            controlContainerTool2});
			this.utb_InventDataToolBar.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
			buttonTool1.SharedProps.Caption = "�S�ē���";
			buttonTool2.SharedProps.Caption = "�����͂̂�";
			buttonTool3.SharedProps.Caption = "�S�ĉ���";
			buttonTool4.SharedProps.Caption = "�S�ē���";
			buttonTool5.SharedProps.Caption = "�����͂̂�";
			buttonTool6.SharedProps.Caption = "�S�ĉ���";
			labelTool1.SharedProps.Spring = true;
			labelTool2.SharedProps.Caption = "�\�����@";
			labelTool2.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.DefaultForToolType;
			labelTool2.SharedProps.MaxWidth = 30;
			labelTool2.SharedProps.MinWidth = 30;
			labelTool2.SharedProps.Width = 30;
			labelTool3.SharedProps.Caption = "�\����";
			labelTool3.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.DefaultForToolType;
			controlContainerTool4.SharedProps.Width = 106;
			controlContainerTool5.SharedProps.Caption = "ControlContainerTool1";
			controlContainerTool5.SharedProps.Visible = false;
			controlContainerTool6.SharedProps.Caption = "�V���\��";
			appearance20.TextHAlign = Infragistics.Win.HAlign.Left;
			labelTool4.SharedProps.AppearancesSmall.Appearance = appearance20;
			labelTool4.SharedProps.Caption = "�I����";
			labelTool4.SharedProps.MaxWidth = 50;
			labelTool4.SharedProps.MinWidth = 50;
			labelTool4.SharedProps.Width = 50;
			popupMenuTool1.SharedProps.Caption = "��\��";
			stateButtonTool1.InstanceProps.IsFirstInGroup = true;
			stateButtonTool1.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool2.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool3.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool4.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool5.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool6.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool7.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool8.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			buttonTool7.InstanceProps.IsFirstInGroup = true;
			popupMenuTool1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            stateButtonTool1,
            stateButtonTool2,
            stateButtonTool3,
            stateButtonTool4,
            stateButtonTool5,
            stateButtonTool6,
            stateButtonTool7,
            stateButtonTool8,
            buttonTool7});
			stateButtonTool9.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool9.SharedProps.Caption = "�q��";
			stateButtonTool10.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool10.SharedProps.Caption = "���[�J�[";
			stateButtonTool11.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool11.SharedProps.Caption = "�d����";
			stateButtonTool12.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool12.SharedProps.Caption = "�ϑ���";
			stateButtonTool13.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool13.SharedProps.Caption = "�݌ɋ敪";
			buttonTool8.SharedProps.Caption = "�����\�����";
			controlContainerTool8.SharedProps.Caption = "�s�폜";
			stateButtonTool14.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool14.SharedProps.Caption = "�d���I�ԂP";
			stateButtonTool15.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool15.SharedProps.Caption = "�d���I�ԂQ";
			stateButtonTool16.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
			stateButtonTool16.SharedProps.Caption = "�I��";
			buttonTool9.SharedProps.Caption = "tool_ReplaceButton";
			buttonTool9.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.DefaultForToolType;
			controlContainerTool9.Control = this.ub_replaceButton;
			controlContainerTool9.SharedProps.Caption = "�u��";
			this.utb_InventDataToolBar.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            buttonTool4,
            buttonTool5,
            buttonTool6,
            labelTool1,
            labelTool2,
            controlContainerTool3,
            labelTool3,
            controlContainerTool4,
            controlContainerTool5,
            controlContainerTool6,
            controlContainerTool7,
            labelTool4,
            popupMenuTool1,
            stateButtonTool9,
            stateButtonTool10,
            stateButtonTool11,
            stateButtonTool12,
            stateButtonTool13,
            labelTool5,
            buttonTool8,
            controlContainerTool8,
            stateButtonTool14,
            stateButtonTool15,
            stateButtonTool16,
            buttonTool9,
            controlContainerTool9});
			this.utb_InventDataToolBar.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.utb_InventDataToolBar_ToolClick);
			// 
			// DCKHN09180UB_Fill_Panel
			// 
			this.DCKHN09180UB_Fill_Panel.Controls.Add(this.panel1);
			this.DCKHN09180UB_Fill_Panel.Controls.Add(this.rateBlanketResult_uGrid);
			this.DCKHN09180UB_Fill_Panel.Controls.Add(this.usb_GridSettingBar);
			this.DCKHN09180UB_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
			this.DCKHN09180UB_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DCKHN09180UB_Fill_Panel.Location = new System.Drawing.Point(0, 29);
			this.DCKHN09180UB_Fill_Panel.Name = "DCKHN09180UB_Fill_Panel";
			this.DCKHN09180UB_Fill_Panel.Size = new System.Drawing.Size(1006, 585);
			this.DCKHN09180UB_Fill_Panel.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.ub_replaceButton);
			this.panel1.Location = new System.Drawing.Point(3, 46);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(217, 184);
			this.panel1.TabIndex = 5;
			this.panel1.Visible = false;
			// 
			// rateBlanketResult_uGrid
			// 
			appearance5.BackColor = System.Drawing.Color.White;
			appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
			appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			this.rateBlanketResult_uGrid.DisplayLayout.Appearance = appearance5;
			this.rateBlanketResult_uGrid.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
			this.rateBlanketResult_uGrid.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
			appearance6.BackColor = System.Drawing.SystemColors.ActiveBorder;
			appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
			appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance6.BorderColor = System.Drawing.SystemColors.Window;
			this.rateBlanketResult_uGrid.DisplayLayout.GroupByBox.Appearance = appearance6;
			appearance7.ForeColor = System.Drawing.SystemColors.GrayText;
			this.rateBlanketResult_uGrid.DisplayLayout.GroupByBox.BandLabelAppearance = appearance7;
			this.rateBlanketResult_uGrid.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
			appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight;
			appearance8.BackColor2 = System.Drawing.SystemColors.Control;
			appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
			appearance8.ForeColor = System.Drawing.SystemColors.GrayText;
			this.rateBlanketResult_uGrid.DisplayLayout.GroupByBox.PromptAppearance = appearance8;
			this.rateBlanketResult_uGrid.DisplayLayout.MaxColScrollRegions = 1;
			this.rateBlanketResult_uGrid.DisplayLayout.MaxRowScrollRegions = 1;
			appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			appearance9.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
			appearance9.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			appearance9.BackColorDisabled2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
			appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.ActiveCellAppearance = appearance9;
			appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
			appearance10.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
			appearance10.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
			appearance10.BackColorDisabled2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
			appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.ActiveRowAppearance = appearance10;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.False;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.AllowGroupSwapping = Infragistics.Win.UltraWinGrid.AllowGroupSwapping.NotAllowed;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.DefaultColWidth = 20;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.DefaultRowHeight = 22;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
			appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
			appearance11.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
			appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance11.Cursor = System.Windows.Forms.Cursors.Hand;
			appearance11.ForeColor = System.Drawing.Color.White;
			appearance11.TextHAlign = Infragistics.Win.HAlign.Center;
			appearance11.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.GroupByColumnHeaderAppearance = appearance11;
			appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
			appearance12.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
			appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance12.Cursor = System.Windows.Forms.Cursors.Hand;
			appearance12.ForeColor = System.Drawing.Color.White;
			appearance12.TextHAlign = Infragistics.Win.HAlign.Center;
			appearance12.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.HeaderAppearance = appearance12;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
			appearance13.BackColor = System.Drawing.Color.Lavender;
			appearance13.BackColorDisabled = System.Drawing.Color.Lavender;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.RowAlternateAppearance = appearance13;
			appearance14.BackColor = System.Drawing.Color.White;
			appearance14.BackColorDisabled = System.Drawing.Color.White;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.RowAppearance = appearance14;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
			appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
			appearance15.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
			appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance15.ForeColor = System.Drawing.Color.White;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.RowSelectorAppearance = appearance15;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.RowSelectorWidth = 12;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
			appearance16.BackColor = System.Drawing.Color.WhiteSmoke;
			appearance16.BackColor2 = System.Drawing.Color.Coral;
			appearance16.BackColorDisabled = System.Drawing.Color.WhiteSmoke;
			appearance16.BackColorDisabled2 = System.Drawing.Color.Coral;
			appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance16.ForeColor = System.Drawing.Color.Black;
			appearance16.ForeColorDisabled = System.Drawing.Color.Black;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.SelectedRowAppearance = appearance16;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None;
			appearance17.BackColor = System.Drawing.SystemColors.ControlLight;
			this.rateBlanketResult_uGrid.DisplayLayout.Override.TemplateAddRowAppearance = appearance17;
			this.rateBlanketResult_uGrid.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
			this.rateBlanketResult_uGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
			this.rateBlanketResult_uGrid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
			this.rateBlanketResult_uGrid.DisplayLayout.UseFixedHeaders = true;
			this.rateBlanketResult_uGrid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
			this.rateBlanketResult_uGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rateBlanketResult_uGrid.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F);
			this.rateBlanketResult_uGrid.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.rateBlanketResult_uGrid.Location = new System.Drawing.Point(0, 0);
			this.rateBlanketResult_uGrid.Name = "rateBlanketResult_uGrid";
			this.rateBlanketResult_uGrid.Size = new System.Drawing.Size(1006, 562);
			this.rateBlanketResult_uGrid.TabIndex = 0;
			this.rateBlanketResult_uGrid.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
			this.rateBlanketResult_uGrid.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler(this.rateBlanketResult_uGrid_BeforeEnterEditMode);
			this.rateBlanketResult_uGrid.AfterExitEditMode += new System.EventHandler(this.rateBlanketResult_uGrid_AfterExitEditMode);
			this.rateBlanketResult_uGrid.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.rateBlanketResult_uGrid_InitializeLayout);
			this.rateBlanketResult_uGrid.BeforeSelectChange += new Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventHandler(this.rateBlanketResult_uGrid_BeforeSelectChange);
			this.rateBlanketResult_uGrid.BeforeExitEditMode += new Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventHandler(this.rateBlanketResult_uGrid_BeforeExitEditMode);
			this.rateBlanketResult_uGrid.CellDataError += new Infragistics.Win.UltraWinGrid.CellDataErrorEventHandler(this.rateBlanketResult_uGrid_CellDataError);
			this.rateBlanketResult_uGrid.AfterRowActivate += new System.EventHandler(this.rateBlanketResult_uGrid_AfterRowActivate);
			this.rateBlanketResult_uGrid.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.rateBlanketResult_uGrid_InitializeRow);
			this.rateBlanketResult_uGrid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rateBlanketResult_uGrid_KeyPress);
			this.rateBlanketResult_uGrid.Leave += new System.EventHandler(this.rateBlanketResult_uGrid_Leave);
			this.rateBlanketResult_uGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rateBlanketResult_uGrid_KeyDown);
			this.rateBlanketResult_uGrid.BeforeRowDeactivate += new System.ComponentModel.CancelEventHandler(this.rateBlanketResult_uGrid_BeforeRowDeactivate);
			this.rateBlanketResult_uGrid.AfterCellActivate += new System.EventHandler(this.rateBlanketResult_uGrid_AfterCellActivate);
			// 
			// usb_GridSettingBar
			// 
			appearance18.FontData.SizeInPoints = 9F;
			this.usb_GridSettingBar.Appearance = appearance18;
			this.usb_GridSettingBar.Controls.Add(this.uce_ColSizeAutoSetting);
			this.usb_GridSettingBar.Controls.Add(this.tce_FontSize);
			this.usb_GridSettingBar.Location = new System.Drawing.Point(0, 562);
			this.usb_GridSettingBar.Name = "usb_GridSettingBar";
			ultraStatusPanel1.Control = this.uce_ColSizeAutoSetting;
			ultraStatusPanel1.Key = "AutoSetting";
			ultraStatusPanel1.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
			ultraStatusPanel1.Width = 140;
			ultraStatusPanel2.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
			ultraStatusPanel2.Key = "Dummy1";
			ultraStatusPanel2.Width = 1;
			ultraStatusPanel3.Key = "Line1";
			ultraStatusPanel3.Width = 1;
			ultraStatusPanel4.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
			ultraStatusPanel4.Key = "Dummy2";
			ultraStatusPanel4.Width = 5;
			appearance19.FontData.SizeInPoints = 9F;
			appearance19.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance19.TextVAlign = Infragistics.Win.VAlign.Middle;
			ultraStatusPanel5.Appearance = appearance19;
			ultraStatusPanel5.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
			ultraStatusPanel5.Key = "FontSizeLabel";
			ultraStatusPanel5.Text = "�����T�C�Y";
			ultraStatusPanel5.Width = 75;
			ultraStatusPanel6.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
			ultraStatusPanel6.Control = this.tce_FontSize;
			ultraStatusPanel6.Key = "FontSize";
			ultraStatusPanel6.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
			ultraStatusPanel6.Width = 40;
			ultraStatusPanel7.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
			ultraStatusPanel7.Key = "Dummy3";
			ultraStatusPanel7.Width = 1;
			ultraStatusPanel8.Key = "Line2";
			ultraStatusPanel8.Width = 1;
			ultraStatusPanel9.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
			ultraStatusPanel9.Key = "Dummy4";
			ultraStatusPanel9.Width = 1;
			ultraStatusPanel10.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
			ultraStatusPanel10.Key = "Dummy";
			ultraStatusPanel10.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
			this.usb_GridSettingBar.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3,
            ultraStatusPanel4,
            ultraStatusPanel5,
            ultraStatusPanel6,
            ultraStatusPanel7,
            ultraStatusPanel8,
            ultraStatusPanel9,
            ultraStatusPanel10});
			this.usb_GridSettingBar.Size = new System.Drawing.Size(1006, 23);
			this.usb_GridSettingBar.TabIndex = 4;
			this.usb_GridSettingBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
			// 
			// _DCKHN09180UB_Toolbars_Dock_Area_Left
			// 
			this._DCKHN09180UB_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._DCKHN09180UB_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._DCKHN09180UB_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
			this._DCKHN09180UB_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.Color.Black;
			this._DCKHN09180UB_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 29);
			this._DCKHN09180UB_Toolbars_Dock_Area_Left.Name = "_DCKHN09180UB_Toolbars_Dock_Area_Left";
			this._DCKHN09180UB_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 585);
			this._DCKHN09180UB_Toolbars_Dock_Area_Left.ToolbarsManager = this.utb_InventDataToolBar;
			// 
			// _DCKHN09180UB_Toolbars_Dock_Area_Right
			// 
			this._DCKHN09180UB_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._DCKHN09180UB_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._DCKHN09180UB_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
			this._DCKHN09180UB_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.Color.Black;
			this._DCKHN09180UB_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1006, 29);
			this._DCKHN09180UB_Toolbars_Dock_Area_Right.Name = "_DCKHN09180UB_Toolbars_Dock_Area_Right";
			this._DCKHN09180UB_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 585);
			this._DCKHN09180UB_Toolbars_Dock_Area_Right.ToolbarsManager = this.utb_InventDataToolBar;
			// 
			// _DCKHN09180UB_Toolbars_Dock_Area_Top
			// 
			this._DCKHN09180UB_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._DCKHN09180UB_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._DCKHN09180UB_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
			this._DCKHN09180UB_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.Color.Black;
			this._DCKHN09180UB_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
			this._DCKHN09180UB_Toolbars_Dock_Area_Top.Name = "_DCKHN09180UB_Toolbars_Dock_Area_Top";
			this._DCKHN09180UB_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1006, 29);
			this._DCKHN09180UB_Toolbars_Dock_Area_Top.ToolbarsManager = this.utb_InventDataToolBar;
			// 
			// _DCKHN09180UB_Toolbars_Dock_Area_Bottom
			// 
			this._DCKHN09180UB_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
			this._DCKHN09180UB_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
			this._DCKHN09180UB_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
			this._DCKHN09180UB_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.Color.Black;
			this._DCKHN09180UB_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 614);
			this._DCKHN09180UB_Toolbars_Dock_Area_Bottom.Name = "_DCKHN09180UB_Toolbars_Dock_Area_Bottom";
			this._DCKHN09180UB_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1006, 0);
			this._DCKHN09180UB_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.utb_InventDataToolBar;
			// 
			// tRetKeyControl
			// 
			this.tRetKeyControl.OwnerForm = this;
			this.tRetKeyControl.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
			this.tRetKeyControl.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl_ChangeFocus);
			// 
			// tArrowKeyControl
			// 
			this.tArrowKeyControl.OwnerForm = this;
			this.tArrowKeyControl.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl_ChangeFocus);
			// 
			// uttm_ViewGridInfoToolTip
			// 
			this.uttm_ViewGridInfoToolTip.Enabled = false;
			this.uttm_ViewGridInfoToolTip.InitialDelay = 250;
			// 
			// DCKHN09180UB
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
			this.ClientSize = new System.Drawing.Size(1006, 614);
			this.Controls.Add(this.DCKHN09180UB_Fill_Panel);
			this.Controls.Add(this._DCKHN09180UB_Toolbars_Dock_Area_Left);
			this.Controls.Add(this._DCKHN09180UB_Toolbars_Dock_Area_Right);
			this.Controls.Add(this._DCKHN09180UB_Toolbars_Dock_Area_Top);
			this.Controls.Add(this._DCKHN09180UB_Toolbars_Dock_Area_Bottom);
			this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "DCKHN09180UB";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			((System.ComponentModel.ISupportInitialize)(this.tce_FontSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.utb_InventDataToolBar)).EndInit();
			this.DCKHN09180UB_Fill_Panel.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.rateBlanketResult_uGrid)).EndInit();
			this.usb_GridSettingBar.ResumeLayout(false);
			this.usb_GridSettingBar.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

		#region Private Member

		private RateAcs _rateAcs = null;					// �|���A�N�Z�X�N���X
		
		// IInventInputMdiChild �����o�p �ϐ� ---------------------------------------
		private string _enterpriseCode				= "";					// ��ƃR�[�h
		private string _sectionCode					= "";					// ���_�R�[�h
		private string _sectionName					= "";					// ���_����
		private bool _isCansel						= true;					// ����{�^��Enabled
		private bool _isSave						= true;					// �ۑ��{�^��Enabled
		private bool _isExtract						= false;				// ���o�{�^��Enabled
		private bool _isNewInvent					= false;				// �V�K�{�^��Enabled
		private bool _isDetail						= false;				// �ڍ׃{�^��Enabled
		private bool _isBarcodeRead					= false;				// �o�[�R�[�h�Ǎ��{�^��Enabled
		private bool _isDataEdit		= false;	// �ҏW�{�^��Enabled

		// Private �ϐ� ---------------------------------------
		private bool _isFirstsetting				= true;					// �����������t���O
		private RateBlanketAcs _rateBlanketAcs = null;	// �|���}�X�^�ꊇ�o�^�A�N�Z�X�N���X
		private bool _isEventAutoFillColumn			= true;					// ��T�C�Y�����C�x���g�\�t���O(T:��,F:�s��)
		private GridStateController _gridStateController = null;			// �O���b�h�ݒ萧��N���X
		private DCKHN09180UC _replaceForm = null;	// �u�����

		// ��ʃC���[�W�R���g���[�����i
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		// �����񌋍��p
		private StringBuilder _stringBuilder = null;

		// �ۑ��f�[�^�i�[�p���X�g
		private ArrayList _saveRateList = null;

		//----------------
		// �O���b�h����p
		//----------------
		// GridFocus�J�ڗp
		private int _leaveRowBuf;
		private int _leaveColBuf;
		
		//----------------------------------
		// �O���b�h�p�u�`�k�t�d���X�g
		//----------------------------------
		ValueList _gVListPriceDiv = null;			// ���i�敪
		ValueList _gVListUnPrcCalcDiv = null;		// �P���Z�o�敪
		ValueList _gVListUnPrcCalcDivLimit = null;	// �P���Z�o�敪����Łi1�I��s�j
		ValueList _gVListUnPrcFracProcUnit = null;	// �P���[������
		ValueList _gVListBargainCd = null;			// �����敪�R�[�h

		#endregion Private Member

		/// <summary> ��\����ԃZ�b�e�B���OXML�t�@�C���� </summary>
		private const string ct_FileName_ColDisplayStatus =  "DCKHN09180U_ColSetting.DAT";

		/// <summary> �I�����ꊇ���̓R���e�i </summary>
		private const string ct_tool_InventoryAllInput = "tool_InventAllInput";

		/// <summary> �\�����@�c�[���R���e�i </summary>
		private const string ct_tool_ViewStyleContainer = "tool_ViewStyleContainer";

		/// <summary> �\�[�g���c�[���R���e�i </summary>
		private const string ct_tool_SortOrderContainer = "tool_SortOrderContainer";

		/// <summary> �\�[�g���c�[���R���e�i </summary>
		private const string ct_tool_RowDelete = "tool_RowDelete";

		/// <summary> �����\����� </summary>
		private const string ct_tool_Hidden_Initialize = "tool_Hidden_Initialize";

		/// <summary> �|���u���R���e�i </summary>
		private const string ct_tool_ReplaceContainer = "tool_ReplaceButton";

		//-----------------
		// �O���b�h�p��`
		//----------------
		// �O���b�h�R���{�{�b�N�X�p��`
		private const string PRICEDIV = "PRICEDIV";							// ���i�敪
		private const string UNITPRCCALCDIVLIST = "UNITPRCCALCDIVLIST";		// �P���Z�o�敪
		private const string UNITPRCCALCDIVLIST_LIMIT = "UNITPRCCALCDIVLIST_LIMIT";	// �P���Z�o�敪����Łi1�I��s�j
		private const string UNPRCFRACPROCDIVLIST = "UNPRCFRACPROCDIVLIST";	// �P���[�������敪
		private const string BARGAINCD = "BARGAINCD";						// �����敪�R�[�h
		private const int FILTER_LENGTH = 10;	// �O���b�h�w�b�_���̃t�B���^�}�[�N���\����

		// ���b�Z�[�W
		private const string RATE_ERR_MSG = "�P�����|���̉��ꂩ��ݒ肵�Ă��������B";
		private const string RATESTARTDATE_NOTINPUT_MSG = "�|���J�n���������͂ł��B";
		private const string RATESTARTDATE_NOTCORRECT_MSG = "�|���J�n��������������܂���B";
		private const string RATE_SAVE_MSG = "�ۑ����܂����B";

		#region Public Property
		/// <summary> ��ƃR�[�h�v���p�e�B </summary>
		public string EnterpriseCode
		{
			set { this._enterpriseCode = value; }
		}

		/// <summary> ���_�R�[�h�v���p�e�B </summary>
		public string SectionCode
		{
			set { this._sectionCode = value; }
		}

		/// <summary> ���_���̃v���p�e�B </summary>
		public string SectionName
		{
			set { this._sectionName = value; }
		}

		/// <summary> ����{�^��Enabled�v���p�e�B </summary>
		public bool IsCansel
		{
			get { return this._isCansel; }
		}

		/// <summary> �ۑ��{�^��Enabled�v���p�e�B </summary>
		public bool IsSave
		{
			get { return this._isSave; }
		}

		/// <summary> ���o�{�^��Enabled�v���p�e�B </summary>
		public bool IsExtract
		{
			get { return this._isExtract; }
		}

		/// <summary> �V�K�{�^��Enabled�v���p�e�B </summary>
		public bool IsNewInvent
		{
			get { return this._isNewInvent; }
		}

		/// <summary> �ڍ׃{�^��Enabled�v���p�e�B </summary>
		public bool IsDetail
		{
			get { return this._isDetail; }
		}

		/// <summary> �o�[�R�[�h�Ǎ��{�^��Enabled�v���p�e�B </summary>
		public bool IsBarcodeRead
		{
			get { return this._isBarcodeRead; }
		}

		/// <summary> �ڍ׃{�^��Enabled�v���p�e�B </summary>
		public bool IsDataEdit
		{
			get { return this._isDataEdit; }
		}
		#endregion Public Property

		#region Public Method
		/// <summary>
		/// ��ʕ\������
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : �^�u���ύX�����O�Ɏ��s�����</br>
		/// <br>Programmer	: 30167 ���@�O�M</br>
		/// <br>Date		: 2007.11.08</br>
		/// </remarks>
		public int ShowData ( object parameter )
		{
			try
			{
				this.rateBlanketResult_uGrid.BeginUpdate();
				
				if(this._rateBlanketAcs.RateBlanketTable.Rows.Count > 0)
				{
					ShowDataProc();
				}
			}
			finally
			{
				this.rateBlanketResult_uGrid.EndUpdate();
			}
			return 0;
		}

		/// <summary>
		/// �^�u�ύX�O����
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : �^�u���ύX�����O�Ɏ��s�����</br>
		/// <br>Programmer	: 30167 ���@�O�M</br>
		/// <br>Date		: 2007.11.08</br>
		/// </remarks>
		public int BeforeTabChange ( object parameter )
		{
			return 0;
		}

		/// <summary>
		/// �I���O����
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : �I���O�������s��</br>
		/// <br>Programmer	: 30167 ���@�O�M</br>
		/// <br>Date		: 2007.11.08</br>
		/// </remarks>
		public int BeforeClose ( object parameter )
		{
			return 0;
		}

		/// <summary>
		/// ����O����
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : ����O�������s��</br>
		/// <br>Programmer	: 30167 ���@�O�M</br>
		/// <br>Date		: 2007.11.08</br>
		/// </remarks>
		public int BeforeCansel ( object parameter )
		{
			return 0;
		}

		/// <summary>
		/// �������
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : ����������s��</br>
		/// <br>Programer  : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public int Cansel ( object parameter )
		{
			// ���b�Z�[�W�Ŏ���̊m�F
			string strMsg = "���ݕҏW���̃f�[�^�����݂��܂��B\n\n������Ԃɖ߂��܂����H";

			// Ok�Ȃ珉�񒊏o���A�ۑ����̃f�[�^�ɖ߂�
			DialogResult dlgRes = TMsgDisp.Show(
				emErrorLevel.ERR_LEVEL_INFO,        //�G���[���x��
				"DCKHN09180UB",                     //UNIT�@ID
				this.Text,                          //�v���O��������
				"���",		                        //�v���Z�XID
				"",                                 //�I�y���[�V����
				strMsg,                             //���b�Z�[�W
				0,									//�X�e�[�^�X
				null,								//�I�u�W�F�N�g
				MessageBoxButtons.YesNo,            //�_�C�A���O�{�^���w��
				MessageBoxDefaultButton.Button1     //�_�C�A���O�����{�^���w��
				);

			switch( dlgRes )
			{
				case DialogResult.Yes:
					// ���݂̃e�[�u���Ƀo�b�t�@�e�[�u�����R�s�[
					try
					{
						UltraGridRow activeRow = null;						
						
						// �G�f�B�b�g���[�h�ɂȂ��Ă���Z���𔲂��邽�߂̏���
						this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.ExitEditMode);

						this.rateBlanketResult_uGrid.BeginUpdate();	// �`���~

						if (this.rateBlanketResult_uGrid.ActiveRow != null)
							activeRow = this.rateBlanketResult_uGrid.ActiveRow;

						this.rateBlanketResult_uGrid.ActiveRow = null;

						this.rateBlanketResult_uGrid.Selected.Rows.Clear();
						this.rateBlanketResult_uGrid.DisplayLayout.Override.SelectTypeCell = SelectType.Single;
						this.rateBlanketResult_uGrid.DisplayLayout.Override.SelectTypeRow = SelectType.Single;

						this.rateBlanketResult_uGrid.BeginUpdate();

						// �O���b�h�e�[�u���̃f�[�^�����擾
						int rowCnt = this._rateBlanketAcs.RateBlanketTable.Rows.Count;
						
						// �f�[�^��������v���Ă���Ƃ��i�K����v���Ă��Ȃ���΂Ȃ�Ȃ��j
						if (rowCnt == this._rateBlanketAcs.RateBlanketTableBuf.Rows.Count)
						{
							for (int rc = 0; rc < rowCnt; rc++)
							{
								// �O���b�h�e�[�u���̃A�C�e�����擾
								int itemCnt = this._rateBlanketAcs.RateBlanketTable.Rows[rc].ItemArray.Length;
								
								// �A�C�e��������v���Ă���Ƃ�
								if (itemCnt == this._rateBlanketAcs.RateBlanketTableBuf.Rows[rc].ItemArray.Length)
								{
									// �A�C�e���R�s�[
									for (int ic = 0; ic < itemCnt; ic++)
									{
										this._rateBlanketAcs.RateBlanketTable.Rows[rc][ic] = this._rateBlanketAcs.RateBlanketTableBuf.Rows[rc][ic];
									}
								}
							}
						}

						// �A�N�e�B�u��
						if (this.rateBlanketResult_uGrid.Rows.Count > 0)
						{
							this.rateBlanketResult_uGrid.Rows[0].Cells[RateBlanketResult.RATESTARTDATE].Activate();
						}
					}
					finally
					{
						this.rateBlanketResult_uGrid.EndUpdate();
					}
					break;
				case DialogResult.No:
					// �������Ȃ�
					break;
			}
			return 0;
		}

		/// <summary>
		/// ���o�O����
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : ���o�O�������s��</br>
		/// <br>Programer  : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public int BeforeExtract ( object parameter )
		{
			return 0;
		}

		/// <summary>
		/// ���o����
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : ���o�������s��</br>
		/// <br>Programer  : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public int Extract ( object parameter )
		{
			return 0;
		}

		/// <summary>
		/// �V�K����
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : �V�K�������s��</br>
		/// <br>Programer  : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public int NewInvent ( object parameter )
		{
			return 0;
		}

		/// <summary>
		/// �ۑ��O����
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : �ۑ��O�������s��</br>
		/// <br>Programer  : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public int BeforeSave ( object parameter )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			bool errFlag = false;
			string errMsg = "";
			
			//----------------
			// �G���[�`�F�b�N
			//----------------
			foreach (UltraGridRow uRow in this.rateBlanketResult_uGrid.Rows)
			{
				errFlag = InpGridDataCheck(uRow, ref errMsg);
				if (errFlag == false)
				{
					// �G���[���b�Z�[�W
					this.MsgDispProc(errMsg, status, "Save", emErrorLevel.ERR_LEVEL_INFO);
					return status;
				}
			}
			
			//--------------------
			// �ύX�f�[�^�`�F�b�N
			//--------------------
			this._saveRateList = new ArrayList(); 
			
			// �ύX�f�[�^������Εۑ��f�[�^�i�[
			if (SetSaveData(ref this._saveRateList) == false)
			{
				// �ύX�f�[�^����
				errMsg = "�ύX�f�[�^�͂���܂���B";
				this.MsgDispProc(errMsg, status, "Save", emErrorLevel.ERR_LEVEL_INFO);
			}
			else
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			}
			return status;
		}

		/// <summary>
		/// �ۑ�����
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : �ۑ��������s��</br>
		/// <br>Programer  : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public int Save ( object parameter )
		{
			string message = "";
			int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

			UltraGridRow activeRow = null;

			try
			{
				// �G�f�B�b�g���[�h�ɂȂ��Ă���Z���𔲂��邽�߂̏���
				this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.ExitEditMode);

				this.rateBlanketResult_uGrid.BeginUpdate();	// �`���~

				if ( this.rateBlanketResult_uGrid.ActiveRow != null )
					activeRow = this.rateBlanketResult_uGrid.ActiveRow;

				this.rateBlanketResult_uGrid.ActiveRow = null;

				this.rateBlanketResult_uGrid.Selected.Rows.Clear();
				this.rateBlanketResult_uGrid.DisplayLayout.Override.SelectTypeCell = SelectType.Single;
				this.rateBlanketResult_uGrid.DisplayLayout.Override.SelectTypeRow = SelectType.Single;
				
				emErrorLevel errLv = emErrorLevel.ERR_LEVEL_INFO;

				// �ۑ�����
				status = this._rateBlanketAcs.Write(ref this._saveRateList, out message);

				this.rateBlanketResult_uGrid.ActiveRow = activeRow;
				
				switch ( status )
				{
					case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
						// ����I��
						//----- ueno upd ---------- start 2008.02.07
						this.rateBlanketResult_uGrid.Refresh();
						//errLv = emErrorLevel.ERR_LEVEL_INFO;
						//message = RATE_SAVE_MSG;

						// �ۑ������_�C�A���O�\��
						SaveCompletionDialog dialog = new SaveCompletionDialog();
						dialog.ShowDialog(2);
						//----- ueno upd ---------- end 2008.02.07
						
						break;
					case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
						// �X�V�G���[����
						errLv = emErrorLevel.ERR_LEVEL_EXCLAMATION;
						break;
					default:
						// ��O�Ȃ�
						errLv = emErrorLevel.ERR_LEVEL_STOPDISP;
						break;
				}

				//----- ueno upd ---------- start 2008.02.07
				// �X�e�[�^�X������ȊO�̂Ƃ��A���b�Z�[�W�{�b�N�X�\��
				if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
				{
					// ���b�Z�[�W�\��
					this.MsgDispProc(message, status, "Save", errLv);
				}
				//----- ueno upd ---------- end 2008.02.07
				
				// �Č���
				RateBlanket searchRateBlanket = this._rateBlanketAcs.GetSearchRateBlanket;	// ��������
				int dispDiv = this._rateBlanketAcs.GetDispDiv;								// �\���敪

				status = this._rateBlanketAcs.SearchAll(ref searchRateBlanket, dispDiv, out message);
			}
			finally
			{
				this.rateBlanketResult_uGrid.EndUpdate();	// �`��ĊJ
			}
			return status;
		}

		/// <summary>
		/// �ڍו\������
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : �ڍו\���������s��</br>
		/// <br>Programer  : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public int ShowDetail ( object parameter )
		{
			return 0;
		}

		/// <summary>
		/// �o�[�R�[�h�Ǎ�����
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : �o�[�R�[�h�Ǎ��������s��</br>
		/// <br>Programer  : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public int BarcodeRead(object parameter)
		{
			return 0;
		}

		/// <summary>
		/// �ҏW����
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : �ҏW�������s��</br>
		/// <br>Programer  : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.07.25</br>
		/// </remarks>
		public int DataEdit ( object parameter )
		{
			return 0;
		}

		#endregion Public Method

		/// <summary>
		/// �c�[���o�[�ݒ�
		/// </summary>
		public event ParentToolbarInventSettingEventHandler ParentToolbarInventSettingEvent;

		/// <summary>
		/// �������������C��
		/// </summary>
		/// <returns>Status(ConstantManagement.MethodResult)</returns>
		/// <remarks>
		/// <br>Note		: ��ʏ��������������s����B</br>
		/// <br>Programmer	: 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private int InitialLoadScreen ()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			try
			{
				// �u���{�^��
				this.utb_InventDataToolBar.Tools[ct_tool_ReplaceContainer].Control = this.ub_replaceButton;

				// ����N�����̂݉�ʐݒ�
				// StatusBarsSetting
				this.InitializeStatusBarSetting();

				// ��ʃC���[�W����
				this._controlScreenSkin.LoadSkin();						// ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
				this._controlScreenSkin.SettingScreenSkin(this);		// ��ʃX�L���ύX
			}
			finally
			{
			}

			return status;
		}

		/// <summary>
		/// �X�e�[�^�X�o�[����������
		/// </summary>
		/// <remarks>
		/// <br>Note		: �X�e�[�^�X�o�[���������s��</br>
		/// <br>Programmer	: 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void InitializeStatusBarSetting ()
		{
			// �t�H���g�T�C�Y�ύX�R���{�{�b�N�X�̐ݒ�
			this.tce_FontSize.MaxDropDownItems = this.tce_FontSize.Items.Count;
			this.tce_FontSize.Value = 10;
		}

		/// <summary>
		/// �O���b�h�L�[�}�b�s���O�쐬����
		/// </summary>
		/// <param name="grid">�ΏۃO���b�h</param>
		/// <remarks>
		/// <br>Note       : �O���b�h�ɑ΂��ăL�[�}�b�s���O���쐬���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void MakeGridKeyMapping( UltraGrid grid )
		{
			GridKeyActionMapping wkKeyMapping = null;

			// Enter�L�[
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Enter, 
				UltraGridAction.NextCellByTab, 
				0, 
				UltraGridState.Cell, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// Shift + Enter�L�[
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Enter, 
				UltraGridAction.PrevCellByTab, 
				0, 
				UltraGridState.Cell, 
				SpecialKeys.AltCtrl, 
				SpecialKeys.Shift );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// ���L�[
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Up, 
				UltraGridAction.AboveCell, 
				UltraGridState.IsDroppedDown | UltraGridState.IsCheckbox, 
				UltraGridState.InEdit, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// ���L�[
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Down, 
				UltraGridAction.BelowCell, 
				UltraGridState.IsDroppedDown | UltraGridState.IsCheckbox, 
				UltraGridState.InEdit, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// PageUp�L�[
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Prior, 
				UltraGridAction.PageUpCell, 
				0, 
				UltraGridState.InEdit, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// PageDown�L�[
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Next, 
				UltraGridAction.PageDownCell, 
				0, 
				UltraGridState.InEdit, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );

			// Space�L�[
			wkKeyMapping = new GridKeyActionMapping( 
				Keys.Space, 
				UltraGridAction.ToggleRowSel, 
				0, 
				0, 
				SpecialKeys.All, 
				0 );
			grid.KeyActionMappings.Add( wkKeyMapping );
		}

		/// <summary>
		///	�ۑ��f�[�^�ݒ�
		/// </summary>
		/// <returns>�ۑ��f�[�^�L��(true:�L��, false:����)</returns>
		/// <remarks>
		/// <br>Note		: �ۑ��f�[�^���|���N���X�֐ݒ肵�܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private bool SetSaveData(ref ArrayList rateList)
		{
			int rowCnt = this._rateBlanketAcs.RateBlanketTable.Rows.Count;
			Rate rate = null;
			bool saveFlag = false;
			
			// �f�[�^��������v���Ă���Ƃ��i�K����v���Ă��Ȃ���΂Ȃ�Ȃ��j
			if(rowCnt == this._rateBlanketAcs.RateBlanketTableBuf.Rows.Count)
			{
				for(int i = 0; i < rowCnt; i++)
				{
					// �O���b�h�\�����ڍ��ك`�F�b�N
					DataRow wk		= this._rateBlanketAcs.RateBlanketTable.Rows[i];
					DataRow wkBuf	= this._rateBlanketAcs.RateBlanketTableBuf.Rows[i];
					int chgCnt = 0;

					chgCnt += (DateTime)wk[RateBlanketResult.RATESTARTDATE]							!= (DateTime)wkBuf[RateBlanketResult.RATESTARTDATE]							? 1 : 0;
					chgCnt += RateBlanketAcs.NullChgInt(wk[RateBlanketResult.RATESTARTDATE])		!= RateBlanketAcs.NullChgInt(wkBuf[RateBlanketResult.RATESTARTDATE])		? 1 : 0;
					chgCnt += RateBlanketAcs.NullChgDbl(wk[RateBlanketResult.PRICEFL])				!= RateBlanketAcs.NullChgDbl(wkBuf[RateBlanketResult.PRICEFL])				? 1 : 0;
					chgCnt += RateBlanketAcs.NullChgInt(wk[RateBlanketResult.PRICEDIV])				!= RateBlanketAcs.NullChgInt(wkBuf[RateBlanketResult.PRICEDIV])				? 1 : 0;
					chgCnt += RateBlanketAcs.NullChgInt(wk[RateBlanketResult.UNITPRCCALCDIV])		!= RateBlanketAcs.NullChgInt(wkBuf[RateBlanketResult.UNITPRCCALCDIV])		? 1 : 0;
					chgCnt += RateBlanketAcs.NullChgDbl(wk[RateBlanketResult.RATEVAL])				!= RateBlanketAcs.NullChgDbl(wkBuf[RateBlanketResult.RATEVAL])				? 1 : 0;
					chgCnt += RateBlanketAcs.NullChgDbl(wk[RateBlanketResult.UNPRCFRACPROCUNIT])	!= RateBlanketAcs.NullChgDbl(wkBuf[RateBlanketResult.UNPRCFRACPROCUNIT])	? 1 : 0;
					chgCnt += RateBlanketAcs.NullChgInt(wk[RateBlanketResult.UNPRCFRACPROCDIV])		!= RateBlanketAcs.NullChgInt(wkBuf[RateBlanketResult.UNPRCFRACPROCDIV])		? 1 : 0;
					chgCnt += RateBlanketAcs.NullChgInt(wk[RateBlanketResult.BARGAINCD])			!= RateBlanketAcs.NullChgInt(wkBuf[RateBlanketResult.BARGAINCD])			? 1 : 0;
					
					if(chgCnt > 0)
					{
						// �ۑ��p�|���N���X�֊i�[
						rate = CopyToRateFromDataRow(ref wk);
						rateList.Add(rate);
						saveFlag = true;
					}
				}
			}
			return saveFlag;
		}

		/// <summary>
		/// �O���b�h�f�[�^�e�[�u���R�s�[�����i�O���b�h�f�[�^�e�[�u���ˊ|���N���X�j
		/// </summary>
		/// <param name="dr">�f�[�^���E</param>
		/// <returns>Rate</returns>
		/// <remarks>
		/// <br>Note       : �O���b�h�f�[�^�e�[�u������|���ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private Rate CopyToRateFromDataRow(ref DataRow dr)
		{
			Rate rate = new Rate();
			
			// �����f�[�^�̂ݐݒ肷��
			if (RateBlanketAcs.NullChgInt(dr[RateBlanketResult.DIVIDE_CD]) == (int)RateBlanketAcs.DispDivList.Upd)
			{
				// �쐬����
				rate.CreateDateTime			= (DateTime)dr[RateBlanketResult.CREATEDATETIME];
				// �X�V����
				rate.UpdateDateTime			= (DateTime)dr[RateBlanketResult.UPDATEDATETIME];
				// GUID
				rate.FileHeaderGuid = (Guid)dr[RateBlanketResult.FILEHEADERGUID];
			}
			
			// ��ƃR�[�h
			rate.EnterpriseCode			= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.ENTERPRISECODE]);
			// �X�V�]�ƈ��R�[�h
			rate.UpdEmployeeCode		= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.UPDEMPLOYEECODE]);
			// �X�V�A�Z���u��ID1
			rate.UpdAssemblyId1			= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.UPDASSEMBLYID1]);
			// �X�V�A�Z���u��ID2
			rate.UpdAssemblyId2			= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.UPDASSEMBLYID2]);
			// �_���폜�敪
			rate.LogicalDeleteCode		= RateBlanketAcs.NullChgInt(dr[RateBlanketResult.LOGICALDELETECODE]);
			// ���_�R�[�h
			rate.SectionCode			= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.SECTIONCODE]);
			// �P���|���ݒ�敪
			rate.UnitRateSetDivCd		= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.UNITRATESETDIVCD]);
			// �V���敪
			rate.OldNewDivCd			= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.OLDNEWDIVCD]);
			// �P�����
			rate.UnitPriceKind			= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.UNITPRICEKIND]);
			// �|���ݒ�敪
			rate.RateSettingDivide		= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.RATESETTINGDIVIDE]);
			// �|���ݒ�敪�i���i�j
			rate.RateMngGoodsCd			= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.RATEMNGGOODSCD]);
			// �|���ݒ薼�́i���i�j
			rate.RateMngGoodsNm			= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.RATEMNGGOODSNM]);
			// �|���ݒ�敪�i���Ӑ�j
			rate.RateMngCustCd			= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.RATEMNGCUSTCD]);
			// �|���ݒ薼�́i���Ӑ�j
			rate.RateMngCustNm			= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.RATEMNGCUSTNM]);
			// ���i���[�J�[�R�[�h
			rate.GoodsMakerCd			= RateBlanketAcs.NullChgInt(dr[RateBlanketResult.GOODSMAKERCD]);
			// ���i�ԍ�
			rate.GoodsNo				= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.GOODSNO]);
			// ���i�|�������N
			rate.GoodsRateRank			= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.GOODSRATERANK]);
			// ���i�敪�O���[�v�R�[�h
			rate.LargeGoodsGanreCode	= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.LARGEGOODSGANRECODE]);
			// ���i�敪�R�[�h
			rate.MediumGoodsGanreCode	= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.MEDIUMGOODSGANRECODE]);
			// ���i�敪�ڍ׃R�[�h
			rate.DetailGoodsGanreCode	= RateBlanketAcs.NullChgStr(dr[RateBlanketResult.DETAILGOODSGANRECODE]);
			// ���Е��ރR�[�h
			rate.EnterpriseGanreCode	= RateBlanketAcs.NullChgInt(dr[RateBlanketResult.ENTERPRISEGANRECODE]);
			// BL���i�R�[�h
			rate.BLGoodsCode			= RateBlanketAcs.NullChgInt(dr[RateBlanketResult.BLGOODSCODE]);
			// ���Ӑ�R�[�h
			rate.CustomerCode			= RateBlanketAcs.NullChgInt(dr[RateBlanketResult.CUSTOMERCODE]);
			// ���Ӑ�|���O���[�v�R�[�h
			rate.CustRateGrpCode		= RateBlanketAcs.NullChgInt(dr[RateBlanketResult.CUSTRATEGRPCODE]);
			// �d����R�[�h
			rate.SupplierCd				= RateBlanketAcs.NullChgInt(dr[RateBlanketResult.SUPPLIERCD]);
			// �d����|���O���[�v�R�[�h
			rate.SuppRateGrpCode		= RateBlanketAcs.NullChgInt(dr[RateBlanketResult.SUPPRATEGRPCODE]);
			// ���b�g��
			rate.LotCount				= RateBlanketAcs.NullChgDbl(dr[RateBlanketResult.LOTCOUNT]);
			// �P���Z�o�敪
			rate.UnitPrcCalcDiv			= RateBlanketAcs.NullChgInt(dr[RateBlanketResult.UNITPRCCALCDIV]);
			// ���i�敪
			rate.PriceDiv				= RateBlanketAcs.NullChgInt(dr[RateBlanketResult.PRICEDIV]);
			// ���i
			rate.PriceFl				= RateBlanketAcs.NullChgDbl(dr[RateBlanketResult.PRICEFL]);
			// �|��
			rate.RateVal				= RateBlanketAcs.NullChgDbl(dr[RateBlanketResult.RATEVAL]);
			// �P���[�������P��
			rate.UnPrcFracProcUnit		= RateBlanketAcs.NullChgDbl(dr[RateBlanketResult.UNPRCFRACPROCUNIT]);
			// �P���[�������敪
			rate.UnPrcFracProcDiv		= RateBlanketAcs.NullChgInt(dr[RateBlanketResult.UNPRCFRACPROCDIV]);
			// �|���J�n��
			rate.RateStartDate = (DateTime)dr[RateBlanketResult.RATESTARTDATE];
			
			// �����敪�R�[�h
			rate.BargainCd				= RateBlanketAcs.NullChgInt(dr[RateBlanketResult.BARGAINCD]);

			//------------------------------------------------------------------
			// �P���|���ݒ�敪�쐬(�P����ށ{�|���ݒ�敪�{�V���敪)
			//   �V���敪���킸�����擾����ꍇ�A�P����ށ{�|���ݒ�敪�ƂȂ�
			//------------------------------------------------------------------
			string wkStr = "";
			_stringBuilder.Remove(0, _stringBuilder.Length);
			_stringBuilder.Append(rate.UnitPriceKind);
			_stringBuilder.Append(rate.RateSettingDivide);
			_stringBuilder.Append(rate.OldNewDivCd);
			wkStr = _stringBuilder.ToString();
			
			// �P���|���ݒ�敪
			rate.UnitRateSetDivCd = wkStr;
			
			return rate;
		}

		/// <summary>
		///	�u�`�k�t�d���X�g�쐬
		/// </summary>
		/// <param name="vList">Value���X�g</param>
		/// <param name="uGrid">���b�g�O���b�h</param>
		/// <param name="listStr">Value���X�g������</param>
		/// <param name="sList">�h���b�v�_�E���A�C�e��</param>
		/// <remarks>
		/// <br>Note		: �u�`�k�t�d���X�g���쐬���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2008.01.08</br>
		/// </remarks>
		private void MakeValueList(ref ValueList vList, ref UltraGrid uGrid, string listStr, ref SortedList sList)
		{
			try
			{
				vList = uGrid.DisplayLayout.ValueLists.Add(listStr);

				if (sList != null)
				{
					// �A�C�e���ǉ�
					foreach (DictionaryEntry de in sList)
					{
						vList.ValueListItems.Add((Int32)de.Key, de.Value.ToString());
					}
					vList.MaxDropDownItems = vList.ValueListItems.Count;
				}
			}
			catch
			{
			}
		}

		/// <summary>
		///	�u�`�k�t�d���X�g�쐬�i�P���Z�o�敪��p�j
		/// </summary>
		/// <param name="vList">Value���X�g</param>
		/// <param name="uGrid">���b�g�O���b�h</param>
		/// <param name="listStr">Value���X�g������</param>
		/// <param name="sList">�h���b�v�_�E���A�C�e��</param>
		/// <remarks>
		/// <br>Note		: �u�`�k�t�d���X�g���쐬���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2008.01.08</br>
		/// </remarks>
		private void UnPrcCalcDivMakeValueList(ref ValueList vList, ref UltraGrid uGrid, string listStr, ref SortedList sList)
		{
			try
			{
				vList = uGrid.DisplayLayout.ValueLists.Add(listStr);

				if (sList != null)
				{
					// �A�C�e���ǉ�
					foreach (DictionaryEntry de in sList)
					{
						if ((int)de.Key != 1)
						{
							vList.ValueListItems.Add((Int32)de.Key, de.Value.ToString());
						}
					}
					vList.MaxDropDownItems = vList.ValueListItems.Count;
				}
			}
			catch
			{
			}
		}

		/// <summary>
		/// �|���N���X�i�[�����i�P���Z�o�敪�`�F�b�N�p�j
		/// </summary>
		/// <param name="rate">��������</param>
		/// <param name="rateBlanket">�|���ꊇ��������</param>
		/// <remarks>
		/// <br>Note       : �|���ꊇ�����������|�����������p�N���X�֊i�[���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.12.04</br>
		/// </remarks>
		private void RateSearchUnitPrcCalcDiv(out Rate rate, ref RateBlanket rateBlanket)
		{
			rate = new Rate();
			
			rate.EnterpriseCode			= rateBlanket.EnterpriseCode;		// ��ƃR�[�h
			rate.SectionCode			= rateBlanket.SectionCode;			// ���_�R�[�h
			rate.UnitPriceKind			= "4";								// �P����ށi�艿�j
			rate.RateSettingDivide		= rateBlanket.RateSettingDivide;	// �|���ݒ�敪
			rate.RateMngGoodsCd			= rateBlanket.RateMngGoodsCd;		// �|���ݒ�敪�i���i�j
			rate.RateMngCustNm			= rateBlanket.RateMngGoodsNm;		// �|���ݒ薼�́i���i�j
			rate.RateMngCustCd			= rateBlanket.RateMngCustCd;		// �|���ݒ�敪�i���Ӑ�j
			rate.RateMngCustNm			= rateBlanket.RateMngCustNm;		// �|���ݒ薼�́i���Ӑ�j
			rate.GoodsMakerCd			= rateBlanket.GoodsMakerCd;			// ���i���[�J�[�R�[�h�i���i�f�j
			rate.GoodsNo				= rateBlanket.GoodsNo;				// ���i�ԍ�
			rate.GoodsRateRank			= rateBlanket.GoodsRateRank;		// ���i�|�������N
			rate.LargeGoodsGanreCode	= rateBlanket.LargeGoodsGanreCode;	// ���i�敪�f�R�[�h
			rate.MediumGoodsGanreCode	= rateBlanket.MediumGoodsGanreCode;	// ���i�敪�R�[�h
			rate.DetailGoodsGanreCode	= rateBlanket.DetailGoodsGanreCode;	// ���i�敪�ڍ׃R�[�h
			rate.EnterpriseGanreCode	= rateBlanket.EnterpriseGanreCode;	// ���Е��ރR�[�h
			rate.BLGoodsCode			= rateBlanket.BLGoodsCode;			// �a�k���i�R�[�h
			rate.CustomerCode			= rateBlanket.CustomerCode;			// ���Ӑ�R�[�h
			rate.CustRateGrpCode		= rateBlanket.CustRateGrpCode;		// ���Ӑ�|���f�R�[�h
			rate.SupplierCd				= rateBlanket.SupplierCd;			// �d����R�[�h
			rate.SuppRateGrpCode		= rateBlanket.SuppRateGrpCode;		// �d����|���f�R�[�h
		}

		/// <summary>
		/// �|���ꊇ�f�[�^�Ɗ|���f�[�^��r����
		/// </summary>
		/// <param name="gRow">�|���ꊇ�f�[�^���E</param>
		/// <param name="rate">�|���f�[�^</param>
		/// <remarks>
		/// <br>Note       : �|���ꊇ�f�[�^�Ɗ|���f�[�^���r���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void RateBlanketCompareToRate(UltraGridRow gRow, Rate rate)
		{
			//   0:��v, 1�ȏ�:�s��v
			int chgCnt = 0;
			
			// �P����ށi4:�艿�j
			chgCnt += string.Equals(rate.UnitPriceKind, "4") ? 0 : 1;
			
			// �V���敪
			chgCnt += string.Equals(RateBlanketAcs.NullChgStr(gRow.Cells[RateBlanketResult.OLDNEWDIVCD].Value).TrimEnd(),
									rate.OldNewDivCd.TrimEnd()) ? 0 : 1;
			// �|���ݒ�敪
			chgCnt += string.Equals(RateBlanketAcs.NullChgStr(gRow.Cells[RateBlanketResult.RATESETTINGDIVIDE].Value).TrimEnd(),
									rate.RateSettingDivide.TrimEnd()) ? 0 : 1;
			// ���[�J�[�R�[�h
			chgCnt += RateBlanketAcs.NullChgInt(gRow.Cells[RateBlanketResult.GOODSMAKERCD].Value) ==
									rate.GoodsMakerCd ? 0 : 1;
			// ���i�R�[�h
			chgCnt += string.Equals(RateBlanketAcs.NullChgStr(gRow.Cells[RateBlanketResult.GOODSNO].Value).TrimEnd(),
									rate.GoodsNo.TrimEnd()) ? 0 : 1;
			// ���i�|�������N
			chgCnt += string.Equals(RateBlanketAcs.NullChgStr(gRow.Cells[RateBlanketResult.GOODSRATERANK].Value).TrimEnd(),
									rate.GoodsRateRank.TrimEnd()) ? 0 : 1;
			// ���i�敪�f�R�[�h
			chgCnt += string.Equals(RateBlanketAcs.NullChgStr(gRow.Cells[RateBlanketResult.LARGEGOODSGANRECODE].Value).TrimEnd(),
									rate.LargeGoodsGanreCode.TrimEnd()) ? 0 : 1;
			// ���i�敪�R�[�h
			chgCnt += string.Equals(RateBlanketAcs.NullChgStr(gRow.Cells[RateBlanketResult.MEDIUMGOODSGANRECODE].Value).TrimEnd(),
									rate.MediumGoodsGanreCode.TrimEnd()) ? 0 : 1;
			// ���i�敪�ڍ׃R�[�h
			chgCnt += string.Equals(RateBlanketAcs.NullChgStr(gRow.Cells[RateBlanketResult.DETAILGOODSGANRECODE].Value).TrimEnd(),
									rate.DetailGoodsGanreCode.TrimEnd()) ? 0 : 1;
			// ���Е��ރR�[�h
			chgCnt += RateBlanketAcs.NullChgInt(gRow.Cells[RateBlanketResult.ENTERPRISEGANRECODE].Value) ==
									rate.EnterpriseGanreCode ? 0 : 1;
			// �a�k�R�[�h
			chgCnt += RateBlanketAcs.NullChgInt(gRow.Cells[RateBlanketResult.BLGOODSCODE].Value) ==
									rate.BLGoodsCode ? 0 : 1;
			// ���Ӑ�R�[�h
			chgCnt += RateBlanketAcs.NullChgInt(gRow.Cells[RateBlanketResult.CUSTOMERCODE].Value) ==
									rate.CustomerCode ? 0 : 1;
			// ���Ӑ�|���f
			chgCnt += RateBlanketAcs.NullChgInt(gRow.Cells[RateBlanketResult.CUSTRATEGRPCODE].Value) ==
									rate.CustRateGrpCode ? 0 : 1;
			// �d����R�[�h
			chgCnt += RateBlanketAcs.NullChgInt(gRow.Cells[RateBlanketResult.SUPPLIERCD].Value) ==
									rate.SupplierCd ? 0 : 1;
			// �d����|���f
			chgCnt += RateBlanketAcs.NullChgInt(gRow.Cells[RateBlanketResult.SUPPRATEGRPCODE].Value) ==
									rate.SuppRateGrpCode ? 0 : 1;

			// �����������ڂ��S�Ĉ�v�����ꍇ�A�P���Z�o�敪1���g�p�s�Ƃ���
			if (chgCnt == 0)
			{
				gRow.Cells[RateBlanketResult.UNITPRCCALCDIV].ValueList = this._gVListUnPrcCalcDivLimit;
				
				// �P���Z�o�敪�����ݒ�l���u2:����x����UP���v�ɕύX����i�u1:����ix�|���v���I���ł��Ȃ����߁j
				gRow.Cells[RateBlanketResult.UNITPRCCALCDIV].Value = 2;
			}
		}
		
		/// <summary>
		///	�f�q�h�c�����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: �f�q�h�c�̏����ݒ���s���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void GridInitialSetting()
		{
			this.rateBlanketResult_uGrid.DataSource = this._rateBlanketAcs.RateBlanketTable.DefaultView;
			
			//----------
			// ����
			//----------
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.NO].MaxLength					= 10;	// No
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.GOODSMAKERCD].MaxLength		= 6;	// ���[�J�[�R�[�h
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.GOODSNO].MaxLength			= 40;	// ���i�R�[�h
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.CUSTOMERCODE].MaxLength		= 9;	// ���Ӑ�R�[�h

			//----- ueno upd ---------- start 2008.02.18
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.PRICEFL].MaxLength			= 13;	// �P�� ����12��13 ����10, �s���I�h1, �����_2
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNPRCFRACPROCUNIT].MaxLength	= 10;	// �P���[�������敪 ����9��10  ����7,  �s���I�h1, �����_2
			//----- ueno upd ---------- end 2008.02.18

			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.RATEVAL].MaxLength			= 6;	// �|�� ����3,  �s���I�h1, �����_2
			
			//----------
			// �����͎�
			//----------
			//----- ueno upd ---------- start 2008.02.18 "0" �� "0.00" �֏C��
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.PRICEFL].NullText				= "0.00";	// �P��
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.RATEVAL].NullText				= "0.00";	// �|��
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNPRCFRACPROCUNIT].NullText	= "0.00";	// �[�������P��
			//----- ueno upd ---------- end 2008.02.18
			
			//----------
			// ���͕s��
			//----------
			// No
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.NO].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			// �敪
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.DIVIDE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			// �V������
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.OLDNEWDIVCD_NM].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			// ���[�J�[�R�[�h
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.GOODSMAKERCD].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			// ���i�R�[�h
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.GOODSNO].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			// ���Ӑ�R�[�h
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.CUSTOMERCODE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			
			//--------------------
			// �R���{�{�b�N�X�ݒ�
			//--------------------
			// ���i�敪�i����i�j
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.PRICEDIV].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.PRICEDIV].ValueList = this._gVListPriceDiv;

			// �P���Z�o�敪
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNITPRCCALCDIV].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNITPRCCALCDIV].ValueList = this._gVListUnPrcCalcDiv;

			// �P���[�������敪
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNPRCFRACPROCDIV].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNPRCFRACPROCDIV].ValueList = this._gVListUnPrcFracProcUnit;

			// �����敪�R�[�h
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.BARGAINCD].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.BARGAINCD].ValueList = this._gVListBargainCd;

			//------------------
			// �O���b�h�O�ϐݒ�
			//------------------
			// �R���{�{�b�N�X�O�ϐݒ�
			Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
			appearance.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(227)), ((System.Byte)(156)));
			appearance.ForeColor = System.Drawing.Color.Black;
			appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this._gVListUnPrcCalcDiv.Appearance = appearance;
			this._gVListUnPrcFracProcUnit.Appearance = appearance;

			// ���l���ڂ͕����ʒu���E�񂹂ɂ���
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.NO].CellAppearance.TextHAlign = HAlign.Right;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.GOODSMAKERCD].CellAppearance.TextHAlign = HAlign.Right;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.CUSTOMERCODE].CellAppearance.TextHAlign = HAlign.Right;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.PRICEFL].CellAppearance.TextHAlign = HAlign.Right;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.RATEVAL].CellAppearance.TextHAlign = HAlign.Right;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNPRCFRACPROCUNIT].CellAppearance.TextHAlign = HAlign.Right;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.BARGAINCD].CellAppearance.TextHAlign = HAlign.Right;

			// ���̓t�H�[�}�b�g
			//----- ueno upd ---------- start 2008.02.07 Null�t�H�[�}�b�g�ǉ�
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.PRICEFL].Format = "###,#0.00;''";
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.RATEVAL].Format = "#0.00;''";
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNPRCFRACPROCUNIT].Format = "###,#0.00;''";
			//----- ueno upd ---------- end 2008.02.07

			// ���E��
			this.rateBlanketResult_uGrid.DisplayLayout.Appearance.BorderColor = Color.FromArgb(1, 68, 208);
		}

		/// <summary>
		///	�f�q�h�c�J�����������ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: �f�q�h�c�̃J�����������ݒ���s���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void GridInitialSettingWidth()
		{
			//--- �E�B���h�E�Œ�\������ ---//
			// NO
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.NO].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.NO].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			// �敪
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.DIVIDE].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.DIVIDE].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			// �V������
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.OLDNEWDIVCD_NM].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.OLDNEWDIVCD_NM].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			// ���i���[�J�[�R�[�h
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.GOODSMAKERCD].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.GOODSMAKERCD].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			// ���i�ԍ�
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.GOODSNO].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.GOODSNO].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			// ���i�|�������N
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.GOODSRATERANK].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.GOODSRATERANK].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			// ���i�敪�O���[�v�R�[�h
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.LARGEGOODSGANRECODE].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.LARGEGOODSGANRECODE].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			// ���i�敪�R�[�h
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.MEDIUMGOODSGANRECODE].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.MEDIUMGOODSGANRECODE].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			// ���i�敪�ڍ׃R�[�h
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.DETAILGOODSGANRECODE].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.DETAILGOODSGANRECODE].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			// ���Е��ރR�[�h
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.ENTERPRISEGANRECODE].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.ENTERPRISEGANRECODE].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			// BL���i�R�[�h
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.BLGOODSCODE].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.BLGOODSCODE].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			// ���Ӑ�R�[�h
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.CUSTOMERCODE].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.CUSTOMERCODE].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			// ���Ӑ�|���O���[�v�R�[�h
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.CUSTRATEGRPCODE].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.CUSTRATEGRPCODE].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			// �d����R�[�h
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.SUPPLIERCD].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.SUPPLIERCD].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			// �d����|���O���[�v�R�[�h
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.SUPPRATEGRPCODE].Header.Fixed = true;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.SUPPRATEGRPCODE].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

			//--- �Œ�\������ ---//
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.NO].Width = 28 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.DIVIDE].Width = 45 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.OLDNEWDIVCD_NM].Width = 45 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.GOODSMAKERCD].Width = 75 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.GOODSNO].Width = 100 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.CUSTOMERCODE].Width = 100 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.CUSTRATEGRPCODE].Width = 140 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.SUPPLIERCD].Width = 100 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.SUPPRATEGRPCODE].Width = 140 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.RATESTARTDATE].Width = 110 + FILTER_LENGTH;

			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.PRICEFL].Width = 120 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.PRICEDIV].Width = 85 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNITPRCCALCDIV].Width = 140 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.RATEVAL].Width = 50 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNPRCFRACPROCUNIT].Width = 120 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNPRCFRACPROCDIV].Width = 80 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.BARGAINCD].Width = 60 + FILTER_LENGTH;

			//--- �ϓ��\������ ---//
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.GOODSRATERANK].Width = 100 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.LARGEGOODSGANRECODE].Width = 150 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.MEDIUMGOODSGANRECODE].Width = 110 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.DETAILGOODSGANRECODE].Width = 145 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.ENTERPRISEGANRECODE].Width = 110 + FILTER_LENGTH;
			this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.BLGOODSCODE].Width = 100 + FILTER_LENGTH;
		}

		/// <summary>
		///	�f�q�h�c�ݒ�ύX����
		/// </summary>
		/// <remarks>
		/// <br>Note		: �f�q�h�c�̐ݒ��ύX���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void GridSettingChange()
		{
			//------------
			// �e��������
			//------------
			RateBlanket searchRateBlanket = this._rateBlanketAcs.GetSearchRateBlanket;
			
			// �P�����
			string wkUnitPriceKind = searchRateBlanket.UnitPriceKind;

			// �|���ݒ�敪�i���i�j
			string wkRateMngGoodsCd = searchRateBlanket.RateMngGoodsCd.Trim();
			
			//----------
			// ���͕s��
			//----------
			if (string.Equals(wkUnitPriceKind, "1") == true)
			{
				// �ҏW�i�S���I���j
				this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNITPRCCALCDIV].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
				this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNITPRCCALCDIV].TabStop = true;
			}
			else
			{
				// �ҏW�s�i1�̂ݑI���j
				this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNITPRCCALCDIV].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
				this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.UNITPRCCALCDIV].TabStop = false;
			}

			// �P���̂Ƃ��\�����鍀��
			if (string.Equals(wkRateMngGoodsCd, "A") == true)
			{
				// �P�����͉�
				this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.PRICEFL].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

			}
			// ���i�f�̂Ƃ��\�����鍀��
			else
			{
				// �P�����͕s��
				this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.PRICEFL].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			}
			
			//----------
			// �\������
			//----------
			Infragistics.Win.UltraWinGrid.UltraGridBand band = this.rateBlanketResult_uGrid.DisplayLayout.Bands[0];
			
			// NO�i�Œ�\���j
			GridDispSetting(ref band, RateBlanketResult.NO, false);
			// �敪�i�Œ�\���j
			GridDispSetting(ref band, RateBlanketResult.DIVIDE, false);
			// �敪�R�[�h
			GridDispSetting(ref band, RateBlanketResult.DIVIDE_CD, true);
			// �V�����́i�Œ�\���j
			GridDispSetting(ref band, RateBlanketResult.OLDNEWDIVCD_NM, false);
			// �ݒ�t���O
			GridDispSetting(ref band, RateBlanketResult.SET_FLAG, true);
			// �쐬���t
			GridDispSetting(ref band, RateBlanketResult.CREATEDATETIME, true);
			// �X�V���t
			GridDispSetting(ref band, RateBlanketResult.UPDATEDATETIME, true);
			// ��ƃR�[�h
			GridDispSetting(ref band, RateBlanketResult.ENTERPRISECODE, true);
			// GUID
			GridDispSetting(ref band, RateBlanketResult.FILEHEADERGUID, true);
			// �X�V�]�ƈ��R�[�h
			GridDispSetting(ref band, RateBlanketResult.UPDEMPLOYEECODE, true);
			// �X�V�A�Z���u��ID1
			GridDispSetting(ref band, RateBlanketResult.UPDASSEMBLYID1, true);
			// �X�V�A�Z���u��ID2
			GridDispSetting(ref band, RateBlanketResult.UPDASSEMBLYID2, true);
			// �_���폜�敪
			GridDispSetting(ref band, RateBlanketResult.LOGICALDELETECODE, true);
			// ���_�R�[�h
			GridDispSetting(ref band, RateBlanketResult.SECTIONCODE, true);
			// �P���|���ݒ�敪
			GridDispSetting(ref band, RateBlanketResult.UNITRATESETDIVCD, true);
			// �V���敪
			GridDispSetting(ref band, RateBlanketResult.OLDNEWDIVCD, true);
			// �P�����
			GridDispSetting(ref band, RateBlanketResult.UNITPRICEKIND, true);
			// �|���ݒ�敪
			GridDispSetting(ref band, RateBlanketResult.RATESETTINGDIVIDE, true);
			// �|���ݒ�敪�i���i�j
			GridDispSetting(ref band, RateBlanketResult.RATEMNGGOODSCD, true);
			// �|���ݒ薼�́i���i�j
			GridDispSetting(ref band, RateBlanketResult.RATEMNGGOODSNM, true);
			// �|���ݒ�敪�i���Ӑ�j
			GridDispSetting(ref band, RateBlanketResult.RATEMNGCUSTCD, true);
			// �|���ݒ薼�́i���Ӑ�j
			GridDispSetting(ref band, RateBlanketResult.RATEMNGCUSTNM, true);

			//----- ueno upd ---------- start 2008.03.28 ���[�J�[�R�[�h�������L�肤��
			// ���i���[�J�[�R�[�h�i�ϓ��\���j
			GridDispSetting(ref band, RateBlanketResult.GOODSMAKERCD, RateBlanket._gridHdnGoodsMakerCd);
			//----- ueno upd ---------- end 2008.03.28

			// ���i�ԍ��i�ϓ��\���j
			GridDispSetting(ref band, RateBlanketResult.GOODSNO, RateBlanket._gridHdnGoodsNo);
			// ���i�|�������N�i�ϓ��\���j
			GridDispSetting(ref band, RateBlanketResult.GOODSRATERANK, RateBlanket._gridHdnGoodsRateRankCd);
			// ���i�敪�O���[�v�R�[�h�i�ϓ��\���j
			GridDispSetting(ref band, RateBlanketResult.LARGEGOODSGANRECODE, RateBlanket._gridHdnLargeGoodsGanreCode);
			// ���i�敪�R�[�h�i�ϓ��\���j
			GridDispSetting(ref band, RateBlanketResult.MEDIUMGOODSGANRECODE, RateBlanket._gridHdnMediumGoodsGanreCode);
			// ���i�敪�ڍ׃R�[�h�i�ϓ��\���j
			GridDispSetting(ref band, RateBlanketResult.DETAILGOODSGANRECODE, RateBlanket._gridHdnDetailGoodsGanreCode);
			// ���Е��ރR�[�h�i�ϓ��\���j
			GridDispSetting(ref band, RateBlanketResult.ENTERPRISEGANRECODE, RateBlanket._gridHdnEnterpriseGanreCode);
			// BL���i�R�[�h�i�ϓ��\���j
			GridDispSetting(ref band, RateBlanketResult.BLGOODSCODE, RateBlanket._gridHdnBLGoodsCode);
			// ���Ӑ�R�[�h�i�ϓ��\���j
			GridDispSetting(ref band, RateBlanketResult.CUSTOMERCODE, RateBlanket._gridHdnCustomerCode);
			// ���Ӑ�|���O���[�v�R�[�h�i�ϓ��\���j
			GridDispSetting(ref band, RateBlanketResult.CUSTRATEGRPCODE, RateBlanket._gridHdnCustRateGrpCode);
			// �d����R�[�h�i�ϓ��\���j
			GridDispSetting(ref band, RateBlanketResult.SUPPLIERCD, RateBlanket._gridHdnSupplierCd);
			// �d����|���O���[�v�R�[�h�i�ϓ��\���j
			GridDispSetting(ref band, RateBlanketResult.SUPPRATEGRPCODE, RateBlanket._gridHdnSuppRateGrpCode);

			// �|���J�n���i�Œ�\���j
			GridDispSetting(ref band, RateBlanketResult.RATESTARTDATE, false);
			// ���b�g��
			GridDispSetting(ref band, RateBlanketResult.LOTCOUNT, true);
			// �P���i�Œ�\���j
			GridDispSetting(ref band, RateBlanketResult.PRICEFL, false);
			// ����i�i�Œ�\���j
			GridDispSetting(ref band, RateBlanketResult.PRICEDIV, false);
			// �P���Z�o�敪�i�Œ�\���j
			GridDispSetting(ref band, RateBlanketResult.UNITPRCCALCDIV, false);
			// �|���i�Œ�\���j
			GridDispSetting(ref band, RateBlanketResult.RATEVAL, false);
			// �P���[�������P�ʁi�Œ�\���j
			GridDispSetting(ref band, RateBlanketResult.UNPRCFRACPROCUNIT, false);
			// �P���[�������敪�i�Œ�\���j
			GridDispSetting(ref band, RateBlanketResult.UNPRCFRACPROCDIV, false);
			// �����敪�R�[�h�i�Œ�\���j
			GridDispSetting(ref band, RateBlanketResult.BARGAINCD, false);
		}

		/// <summary>
		///	�f�q�h�c�\���ݒ菈��
		/// </summary>
		/// <param name="band">�o���h</param>
		/// <param name="columnTitle">�J������</param>
		/// <param name="hiddenFlag">��\���t���O�ifalse:�\��, true:��\���j</param>
		/// <remarks>
		/// <br>Note		: �f�q�h�c�O���[�v�̕\���ݒ���s���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2008.01.18</br>
		/// </remarks>
		private void GridDispSetting(ref Infragistics.Win.UltraWinGrid.UltraGridBand band, string columnTitle, bool hiddenFlag)
		{
			band.Columns[columnTitle].Hidden = hiddenFlag;
		}

		/// <summary>
		/// ��ʕ\��������
		/// </summary>
		/// <returns>Status(ConstantManagement.MethodResult)</returns>
		/// <remarks>
		/// <br>Note		: ��ʕ\�������������s����B</br>
		/// <br>Programmer	: 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private int ShowDataProc ( )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
				if ( this._isFirstsetting )
				{
					// �f�[�^�o�C���h
					this._isFirstsetting = false;	// �f�[�^���o�C���h���邽�߂Ɉꎞ�I��off
					this._isFirstsetting = true;	// ���ɖ߂�
					
					// �O���b�h�R���{�{�b�N�X�쐬
					// ���i�敪�i����i�j
					MakeValueList(ref this._gVListPriceDiv, ref this.rateBlanketResult_uGrid, PRICEDIV, ref RateBlanket._priceDivSList);
					
					// �P���Z�o�敪
					MakeValueList(ref this._gVListUnPrcCalcDiv, ref this.rateBlanketResult_uGrid, UNITPRCCALCDIVLIST, ref RateBlanket._unPrcCalcDivTable);

					// �P���Z�o�敪�i����Łj
					UnPrcCalcDivMakeValueList(ref this._gVListUnPrcCalcDivLimit, ref this.rateBlanketResult_uGrid, UNITPRCCALCDIVLIST_LIMIT, ref RateBlanket._unPrcCalcDivTable);

					// �P���[�������敪
					MakeValueList(ref this._gVListUnPrcFracProcUnit, ref this.rateBlanketResult_uGrid, UNPRCFRACPROCDIVLIST, ref RateBlanket._unPrcFracProcDivTable);
					
					// �����敪�R�[�h
					MakeValueList(ref this._gVListBargainCd, ref this.rateBlanketResult_uGrid, BARGAINCD, ref RateBlanket._bargainCdSList);		

					// ����N�����̂݉�ʐݒ�
					// �O���b�h�L�[�}�b�s���O�쐬
					this.MakeGridKeyMapping(this.rateBlanketResult_uGrid);

					// �O���b�h�����ݒ�
					GridInitialSetting();

					// �O���b�h���ݒ�
					GridInitialSettingWidth();

					// �J������
					// �����T�C�Y
					this._isFirstsetting = false;
					this._isEventAutoFillColumn = true;
				}
				else
				{
				}
				
				//=======================================================================================
				// �P���Z�o�敪�`�F�b�N�i�P�����=����P�����j
				//   �|���ݒ�敪�������ŒP�����=�艿�̃��R�[�h�����ɑ��݂��Ă���ꍇ�A
				//   �P���Z�o�敪=1:����ix�|���͐ݒ�s�Ƃ���B
				//   ��. ���iA�̉��iϽ��̒艿:\8,000
				//     �@�艿     �P�i�ݒ� A3 Ұ��+���i+���Ӑ� ���iA հ�ް�艿\10,000
				//     �A����P�� �P�i�ݒ� A3 Ұ��+���i+���Ӑ� ���iA �P���Z�o�敪1:����ix�|�� �|��80%
				//       
				//       �A�̊���i�͉��iϽ���\8,000���K�p����A\8,000 x 80% = \6,400
				//       �������́Aհ�ް�艿��\10,000��K�p���A\10,000 x 80% = \8,000 �ƂȂ�
				//=======================================================================================
				
				// ���������擾
				RateBlanket searchRateBlanket = this._rateBlanketAcs.GetSearchRateBlanket;

				// �P����ނ�����P���̏ꍇ�A�P���Z�o�敪�`�F�b�N���s��
				if (searchRateBlanket.UnitPriceKind == "1")
				{
					// �|�������p�����ݒ�
					Rate rate = null;
					RateSearchUnitPrcCalcDiv(out rate, ref searchRateBlanket);

					// �|�������i�_���폜�܂ށj
					ArrayList retList = null;
					string message = "";
					int ret = this._rateAcs.SearchRate(out retList, ref rate, ConstantManagement.LogicalMode.GetData01, out message);

					if (ret == 0)
					{
						// �|���ꊇ�������ʂƔ�r���A��v���Ă��郌�R�[�h�̒P���Z�o�敪��ݒ肷��
						foreach (UltraGridRow uRow in this.rateBlanketResult_uGrid.Rows)
						{
							foreach (Rate rateWk in (ArrayList)retList)
							{
								RateBlanketCompareToRate(uRow, rateWk);
							}
						}
					}
				}
				
				// �O���b�h�ݒ�ύX
				GridSettingChange();
				
				// �A�N�e�B�u��
				if ( this.rateBlanketResult_uGrid.Rows.Count > 0 )
				{
					this.rateBlanketResult_uGrid.Rows[0].Cells[RateBlanketResult.RATESTARTDATE].Activate();
				}
			}
			catch ( Exception ex )
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
				this.MsgDispProc( "�|���}�X�^�ꊇ�o�^�f�[�^�̕\���Ɏ��s���܂����B", status, "ShowDataProc", ex, emErrorLevel.ERR_LEVEL_STOPDISP );
			}
			finally
			{
			}

			return status;
		}

		/// <summary>
		/// �O���b�h���ڑS�̃`�F�b�N����
		/// </summary>
		/// <param name="uRow">UltraGridRow</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>�`�F�b�N����(true:OK, false:NG)</returns>
		/// <remarks>
		/// <br>Note       : �O���b�h���ڑS�̂ɑ΂��ĉߕs�����������`�F�b�N���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private bool InpGridDataCheck(UltraGridRow uRow, ref string errMsg)
		{
			//--------------------
			// ���ږ����̓`�F�b�N
			//--------------------
			// �����͎��i�P�� == 0, �|�� == 0, �P���[�������P�� == 0�j
			if ((RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.PRICEFL].Value) == 0)
				&& (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.RATEVAL].Value) == 0)
				&& (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].Value) == 0))
			{
				// �V�K�f�[�^(DIVIDE_CD == 1)�̏ꍇ�A�S�Ė����͂͐���
				if (RateBlanketAcs.NullChgInt(uRow.Cells[RateBlanketResult.DIVIDE_CD].Value) == 1)
				{
					return true;
				}
				// �����f�[�^�̏ꍇ�G���[
				else
				{
					errMsg = RATE_ERR_MSG;
					
					// �G���[�s�Ƀt�H�[�J�X���Z�b�g
					uRow.Cells[RateBlanketResult.PRICEFL].Activate();
					return false;
				}
			}
			
			// �P���ݒ�̏ꍇ�i�P�� > 0�j
			if (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.PRICEFL].Value) > 0)
			{
				// �|�� != 0
				if (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.RATEVAL].Value) != 0)
				{
					errMsg = "�|�����ݒ肳��Ă��܂��B";

					// �G���[�s�Ƀt�H�[�J�X���Z�b�g
					uRow.Cells[RateBlanketResult.RATEVAL].Activate();
					return false;
				}
				// �[�������P�� != 0
				if (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].Value) != 0)
				{
					errMsg = "�[�������P�ʂ��ݒ肳��Ă��܂��B";
					
					// �G���[�s�Ƀt�H�[�J�X���Z�b�g
					uRow.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].Activate();
					return false;
				}
			}
			// �|���ݒ�̏ꍇ�i�P�� == 0�j
			else
			{
				// �|�� == 0
				if (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.RATEVAL].Value) == 0)
				{
					errMsg = "�|����ݒ肵�Ă��������B";

					// �G���[�s�Ƀt�H�[�J�X���Z�b�g
					uRow.Cells[RateBlanketResult.RATEVAL].Activate();
					return false;
				}
				// �[�������P�� == 0.00
				if (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].Value) == 0)
				{
					errMsg = "�[�������P�ʂ�ݒ肵�Ă��������B";

					// �G���[�s�Ƀt�H�[�J�X���Z�b�g
					uRow.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].Activate();
					return false;
				}
			}

			// �|���̌����`�F�b�N�i3����葽���ꍇ�G���[�j
			if (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.RATEVAL].Value) > 999.99)
			{
				errMsg = "�|���̌������s���ł��B";

				// �G���[�s�Ƀt�H�[�J�X���Z�b�g
				uRow.Cells[RateBlanketResult.RATEVAL].Activate();
				return false;
			}

			//----- ueno add ---------- start 2008.02.18
			// �[�������P�ʂ̌����`�F�b�N�i����7��, �����_�ȉ�2����葽���ꍇ�G���[�j
			if (RateBlanketAcs.NullChgDbl(uRow.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].Value) > 9999999.99)
			{
				errMsg = "�[�������P�ʂ̌������s���ł��B";

				// �G���[�s�Ƀt�H�[�J�X���Z�b�g
				uRow.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].Activate();
				return false;
			}
			//----- ueno add ---------- end 2008.02.18

			//--------------------
			// �|���J�n���`�F�b�N
			//--------------------
			// ���[�N�Ɋi�[
			string wkRateStartDateStr = uRow.Cells[RateBlanketResult.RATESTARTDATE].Text;

			// �|���J�n�������͎�
			if (wkRateStartDateStr == "")
			{
				errMsg = RATESTARTDATE_NOTINPUT_MSG;
				uRow.Cells[RateBlanketResult.RATESTARTDATE].Activate();
				return false;
			}
			// �s���f�[�^�`�F�b�N			
			else
			{
				// "�N"�A"��"�A"��"�̈ʒu�y�сA�����`�F�b�N
				if((wkRateStartDateStr.IndexOf("�N", 0) == 4)
					&& (wkRateStartDateStr.IndexOf("��", 0) == 7)
					&& (wkRateStartDateStr.IndexOf("��", 0) == 10)
					&& (wkRateStartDateStr.Length == 11))
				{
					// ���̂܂ܐi��
				}
				else
				{
					errMsg = RATESTARTDATE_NOTCORRECT_MSG;
					
					// �G���[�s�Ƀt�H�[�J�X���Z�b�g
					uRow.Cells[RateBlanketResult.RATESTARTDATE].Activate();
					return false;
				}
				
				// �N�����f�[�^��"__"�������Ă���ꍇ�A"0"�ɕϊ�����
				if (wkRateStartDateStr.Contains("_") == true)
				{
					wkRateStartDateStr = wkRateStartDateStr.Replace("_", "0");
				}
				
				// �N�����擾
				int dYear = RateBlanketAcs.NullChgInt(wkRateStartDateStr.Substring(0, 4));
				int dMonth = RateBlanketAcs.NullChgInt(wkRateStartDateStr.Substring(5, 2));
				int dDay = RateBlanketAcs.NullChgInt(wkRateStartDateStr.Substring(8, 2));

				// �N�����f�[�^���[���̏ꍇ
				if ((dYear == 0) || (dMonth == 0) || (dDay == 0))
				{
					errMsg = RATESTARTDATE_NOTCORRECT_MSG;

					// �G���[�s�Ƀt�H�[�J�X���Z�b�g
					uRow.Cells[RateBlanketResult.RATESTARTDATE].Activate();
					return false;
				}

				// ���͂����������t���H
				int inputDate_int = (dYear * 10000) + (dMonth * 100) + dDay;
				DateTime inputDate = TDateTime.LongDateToDateTime(inputDate_int);
				
				// �G���[
				if (inputDate == DateTime.MinValue)
				{
					errMsg = RATESTARTDATE_NOTCORRECT_MSG;
					
					// �G���[�s�Ƀt�H�[�J�X���Z�b�g
					uRow.Cells[RateBlanketResult.RATESTARTDATE].Activate();
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// �G���[���b�Z�[�W�\������
		/// </summary>
		/// <param name="message">�\�����b�Z�[�W</param>
		/// <param name="iLevel">�G���[���x��</param>
		/// <returns>DialogResult</returns>
		/// <remarks>
		/// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
		/// <br>Programmer	: 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private DialogResult MsgDispProc( string message, emErrorLevel iLevel )
		{
			// ���b�Z�[�W�\��
			return TMsgDisp.Show( 
				this,                            // �e�E�B���h�E�t�H�[��
				iLevel,                             // �G���[���x��
				this.GetType().ToString(),          // �A�Z���u���h�c�܂��̓N���X�h�c
				message,                            // �\�����郁�b�Z�[�W
				0,                                  // �X�e�[�^�X�l
				MessageBoxButtons.OK );             // �\������{�^��
		}

		/// <summary>
		/// �G���[���b�Z�[�W�\������
		/// </summary>
		/// <param name="msg">�\�����b�Z�[�W</param>
		/// <param name="status">�X�e�[�^�X</param>
		/// <param name="proc">���������\�b�hID</param>
		/// <param name="iLevel">�G���[���x��</param>
		/// <remarks>
		/// <br>Programmer	: 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private DialogResult MsgDispProc ( string msg, int status, string proc, emErrorLevel iLevel )
		{
			return TMsgDisp.Show(
				iLevel,						        //�G���[���x��
				"DCKHN09180UB",                       //UNIT�@ID
				"�|���}�X�^�ꊇ�o�^",                            //�v���O��������
				proc,                               //�v���Z�XID
				"",                                 //�I�y���[�V����
				msg,                                //���b�Z�[�W
				status,                             //�X�e�[�^�X
				null,                               //�I�u�W�F�N�g
				MessageBoxButtons.OK,               //�_�C�A���O�{�^���w��
				MessageBoxDefaultButton.Button1     //�_�C�A���O�����{�^���w��
				);
		}

		/// <summary>
		/// �G���[MSG�\������(Exception)
		/// </summary>
		/// <param name="msg">�\�����b�Z�[�W</param>
		/// <param name="status">�X�e�[�^�X</param>
		/// <param name="proc">���������\�b�hID</param>
		/// <param name="ex">��O���</param>
		/// <param name="iLevel">�G���[���x��</param>
		/// <remarks>
		/// <br>Programmer	: 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private DialogResult MsgDispProc ( string msg, int status, string proc, Exception ex, emErrorLevel iLevel )
		{
			return this.MsgDispProc(msg + "\r\n" + ex.Message, status, proc, iLevel);
		}
	
		/// <summary>
		/// �J�����񕝒���
		/// </summary>
		/// <remarks>
		/// <br>Note       : �J�����̗񕝂𒲐����܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.04.24</br>
		/// </remarks>
		private void ColumnPerformAutoResize()
		{
			this._isEventAutoFillColumn = false;

			try
			{
				bool isAutoCol = this.uce_ColSizeAutoSetting.Checked;

				this.uce_ColSizeAutoSetting.Checked = false;

				for (int i = 0; i < this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns.Count; i++)
				{
					this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[i].PerformAutoResize(Infragistics.Win.UltraWinGrid.PerformAutoSizeType.VisibleRows, true);
				}
			}
			finally
			{
				this._isEventAutoFillColumn = true;
			}
		}

		/// <summary>
		/// ���͕s�� �Z���O�ώ擾����
		/// </summary>
		/// <returns>�O�Ϗ��</returns>
		/// <remarks>
		/// <br>Note       : ���͕s�Z���̊O�Ϗ����擾���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private Infragistics.Win.Appearance GetImpossibleCellAppearance()
		{
			Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
			appearance.BackColor = Color.FromArgb(251, 230, 148);
			appearance.BackColor2 = Color.FromArgb(238, 149, 21);
			appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance.ForeColor = Color.Black;
			return appearance;
		}

		/// <summary>
		/// ���͉\/��A�N�e�B�u �Z���O�ώ擾����
		/// </summary>
		/// <returns>�O�Ϗ��</returns>
		/// <remarks>
		/// <br>Note       : ���͉\��A�N�e�B�u�Z���̊O�Ϗ����擾���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private Infragistics.Win.Appearance GetPossibleCellAppearance()
		{
			Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
			appearance.BackColor = Color.White;
			appearance.BackColor2 = Color.FromArgb(238, 149, 21);
			appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance.ForeColor = Color.Black;
			return appearance;
		}

		//----- ueno add ---------- start 2008.02.18
		/// <summary>
		/// ���l���̓`�F�b�N����
		/// </summary>
		/// <param name="keta">����(�}�C�i�X�������܂܂�)</param>
		/// <param name="priod">�����_�ȉ�����</param>
		/// <param name="prevVal">���݂̕�����</param>
		/// <param name="key">���͂��ꂽ�L�[�l</param>
		/// <param name="selstart">�J�[�\���ʒu</param>
		/// <param name="sellength">�I�𕶎���</param>
		/// <param name="minusFlg">�}�C�i�X���͉H</param>
		/// <returns>true=���͉�,false=���͕s��</returns>
		/// <remarks>
		/// <br>Note       : �O���b�h���̐��l���͂��`�F�b�N���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.02.18</br>
		/// </remarks>
		private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
		{
			// ����L�[�������ꂽ�H
			if (Char.IsControl(key))
			{
				return true;
			}
			// ���l�ȊO�́A�m�f
			if (!Char.IsDigit(key))
			{
				// �����_�܂��́A�}�C�i�X�ȊO
				if ((key != '.') && (key != '-'))
				{
					return false;
				}
			}

			// �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
			string _strResult = "";
			if (sellength > 0)
			{
				_strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
			}
			else
			{
				_strResult = prevVal;
			}

			// �}�C�i�X�̃`�F�b�N
			if (key == '-')
			{
				if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
				{
					return false;
				}
			}

			// �����_�̃`�F�b�N
			if (key == '.')
			{
				if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
				{
					return false;
				}
			}
			// �L�[�������ꂽ���ʂ̕�����𐶐�����B
			_strResult = prevVal.Substring(0, selstart)
				+ key
				+ prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

			// �����`�F�b�N�I
			if (_strResult.Length > keta)
			{
				if (_strResult[0] == '-')
				{
					if (_strResult.Length > (keta + 1))
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}

			// �����_�ȉ��̃`�F�b�N
			if (priod > 0)
			{
				// �����_�̈ʒu����
				int _pointPos = _strResult.IndexOf('.');

				// �������ɓ��͉\�Ȍ���������I
				int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
				// �������̌������`�F�b�N
				if (_pointPos != -1)
				{
					if (_pointPos > _Rketa)
					{
						return false;
					}
				}
				else
				{
					if (_strResult.Length > _Rketa)
					{
						return false;
					}
				}

				// �������̌������`�F�b�N
				if (_pointPos != -1)
				{
					// �������̌������v�Z
					int _priketa = _strResult.Length - _pointPos - 1;
					if (priod < _priketa)
					{
						return false;
					}
				}
			}
			return true;
		}
		//----- ueno add ---------- end 2008.02.18

		/// <summary>
		/// �u����ʋN������
		/// </summary>
		/// <remarks>
		/// <return>�X�e�[�^�X</return>
		/// <br>Note       : �u���{�^�����������ꂽ���ɔ������܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private int ReplaceFormStart()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

			try
			{
				if (this._replaceForm == null)
				{
					this._replaceForm = new DCKHN09180UC(ref this.rateBlanketResult_uGrid);
				}
				this._replaceForm.ShowDialog();
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
				this.MsgDispProc("�u����ʂ̋N���Ɏ��s���܂����B", status, "ub_replaceButton_Click", ex, emErrorLevel.ERR_LEVEL_STOPDISP);
			}
			return status;
		}

		#region Control Event
		/// <summary>
		/// DCKHN09180UB_Load
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ���[�U�[���t�@�C����ǂݍ��ނƂ��ɔ�������</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// <br>Update Note: </br>
		/// </remarks>
		private void DCKHN09180UB_Load ( object sender, EventArgs e )
		{
			// �����ݒ�
			InitialLoadScreen();
		}

		/// <summary>
		/// DCKHN09180UB_FormClosing
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ���[�U�[���t�H�[�������Ƃ��ɔ�������</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.04.27</br>
		/// <br>Update Note: </br>
		/// </remarks>
		private void DCKHN09180UB_FormClosing ( object sender, FormClosingEventArgs e )
		{
			// �O���b�h�ݒ�ۑ�
			if (this._gridStateController != null)
			{
				this._gridStateController.GetGridStateFromGrid(ref this.rateBlanketResult_uGrid);
				this._gridStateController.SaveGridState(ct_FileName_ColDisplayStatus);
			}
		}

		/// <summary>Control.ChangeFocus �C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �t�H�[�J�X�ړ����ɔ������܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void tArrowKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
			if ((e.PrevCtrl == null) || (e.NextCtrl == null)) return;

			switch(e.PrevCtrl.Name)
			{
				// Grid��Control�����鎞��Return/Tab�̓����ݒ�
				case "rateBlanketResult_uGrid":
					{
						// ���^�[���L�[�̎�
						if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
						{
							e.NextCtrl = null;

							if (this.rateBlanketResult_uGrid.ActiveCell != null)
							{
								// �ŏI�Z���̎�
								if ((this.rateBlanketResult_uGrid.ActiveCell.Row.Index == this.rateBlanketResult_uGrid.Rows.Count - 1) &&
									(this.rateBlanketResult_uGrid.ActiveCell.Column.Index == this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.BARGAINCD].Index))
								{
									// �u���{�^���փt�H�[�J�X�Z�b�g
									this.ub_replaceButton.Focus();
								}
								else
								{
									// �u�����v�̏ꍇ�͎���Row��
									if (this.rateBlanketResult_uGrid.ActiveCell.Column.Index == this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.BARGAINCD].Index)
									{
										// ����Row�Ƀt�H�[�J�X�J��
										this.rateBlanketResult_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextRow);
										this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.EnterEditMode);
									}
									else
									{
										// ����Cell�Ƀt�H�[�J�X�J��
										this.rateBlanketResult_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
									}
								}
							}
						}
						break;
					}
				case "ub_replaceButton":
					{
						// ���^�[���L�[�̏ꍇ
						if ((e.Key == Keys.Return) || (e.Key == Keys.Tab))
						{
							// �A�N�e�B�u��
							if (this.rateBlanketResult_uGrid.Rows.Count > 0)
							{
								this.rateBlanketResult_uGrid.Focus();
								this.rateBlanketResult_uGrid.Rows[0].Cells[RateBlanketResult.RATESTARTDATE].Activate();
							}
						}
						break;
					}
			}
		}

		/// <summary>�u���{�^���C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �u���{�^�����������ꂽ���ɔ������܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void ub_replaceButton_Click(object sender, EventArgs e)
		{
			ReplaceFormStart();			
		}

		#endregion Control Event

		#region Grid Event

		/// <summary>
		/// UltraGrid.KeyDown�C�x���g
		/// </summary>
		/// <remarks>
		/// <br>Note		: �O���b�h��ŉ����L�[�������������̐�����s���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void rateBlanketResult_uGrid_KeyDown(object sender, KeyEventArgs e)
		{
			// Grid�ҏW���̎�
			if ((this.rateBlanketResult_uGrid.ActiveCell != null) &&
				(this.rateBlanketResult_uGrid.ActiveCell.IsInEditMode == true))
			{
				int rowIndex = this.rateBlanketResult_uGrid.ActiveCell.Row.Index;

				switch (e.KeyCode)
				{
					case Keys.Up:
						{
							if (this.rateBlanketResult_uGrid.ActiveCell.Row.Index == 0)
							{
								break;
							}
							else
							{
								// �R���{�{�b�N�X���A�N�e�B�u�ȏꍇ�A��̃Z���ւ͈ړ����Ȃ�
								bool droppedDownFlag = false;
								if (this.rateBlanketResult_uGrid.ActiveCell.ValueListResolved != null)
								{
									droppedDownFlag = this.rateBlanketResult_uGrid.ActiveCell.ValueListResolved.IsDroppedDown;
								}

								if (droppedDownFlag == false)
								{
									this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.AboveCell);
									e.Handled = true;
								}
							}
							break;
						}

					case Keys.Down:
						{
							if (this.rateBlanketResult_uGrid.ActiveCell.Row.Index == (this.rateBlanketResult_uGrid.Rows.Count - 1))
							{
								this.uce_ColSizeAutoSetting.Focus();
							}
							else
							{
								// �R���{�{�b�N�X���A�N�e�B�u�ȏꍇ�A���̃Z���ւ͈ړ����Ȃ�
								bool droppedDownFlag = false;
								if (this.rateBlanketResult_uGrid.ActiveCell.ValueListResolved != null)
								{
									droppedDownFlag = this.rateBlanketResult_uGrid.ActiveCell.ValueListResolved.IsDroppedDown;
								}
								
								if (droppedDownFlag == false)
								{
									this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.BelowCell);
									e.Handled = true;
								}
							}
							break;
						}
					case Keys.Right:
						{
							// �A�N�e�B�u�Z�����u�P���v�A�u�|���v�A�u�P���[�������P�ʁv�̉��ꂩ�̏ꍇ
							if ((this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.Rows[rowIndex].Cells[RateBlanketResult.PRICEFL])
								|| (this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.Rows[rowIndex].Cells[RateBlanketResult.RATEVAL])
								|| (this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.Rows[rowIndex].Cells[RateBlanketResult.UNPRCFRACPROCUNIT]))
							{
								if ((this.rateBlanketResult_uGrid.ActiveCell.SelLength == 0) &&
									(this.rateBlanketResult_uGrid.ActiveCell.SelStart == this.rateBlanketResult_uGrid.ActiveCell.Text.Length))
								{
									// �u�����v�̏ꍇ�͎���Row��
									if (this.rateBlanketResult_uGrid.ActiveCell.Column.Index == this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.BARGAINCD].Index)
									{
										this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.NextRow);
										this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.EnterEditMode);
									}
									else
									{
										this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.NextCell);
									}
									e.Handled = true;
								}
							}
							else
							{
								this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.NextCell);
								e.Handled = true;
							}
							break;
						}
					case Keys.Left:
						{
							// �A�N�e�B�u�Z�����u�|���J�n���v�A�u�P���v�A�u�|���v�A�u�P���[�������P�ʁv�̉��ꂩ�̏ꍇ
							if ((this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.Rows[rowIndex].Cells[RateBlanketResult.RATESTARTDATE])
								|| (this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.Rows[rowIndex].Cells[RateBlanketResult.PRICEFL])
								|| (this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.Rows[rowIndex].Cells[RateBlanketResult.RATEVAL])
								|| (this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.Rows[rowIndex].Cells[RateBlanketResult.UNPRCFRACPROCUNIT]))
							{
								// �Q�s�ڈȍ~�Łu�|���J�n���v�̎�
								if ((this.rateBlanketResult_uGrid.ActiveCell.SelLength == 0) &&
									(this.rateBlanketResult_uGrid.ActiveCell.SelStart == 0) &&
									(this.rateBlanketResult_uGrid.ActiveCell.Row.Index != 0) &&
									(this.rateBlanketResult_uGrid.ActiveCell.Column.Index == this.rateBlanketResult_uGrid.DisplayLayout.Bands[0].Columns[RateBlanketResult.RATESTARTDATE].Index))
								{
									// ��̍s�́u�����v��
									this.rateBlanketResult_uGrid.Rows[this.rateBlanketResult_uGrid.ActiveCell.Row.Index - 1].Cells[RateBlanketResult.BARGAINCD].Activate();
									e.Handled = true;
								}
								else if ((this.rateBlanketResult_uGrid.ActiveCell.SelLength == 0) &&
									(this.rateBlanketResult_uGrid.ActiveCell.SelStart == 0))
								{
									// ��O��Cell��
									this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.PrevCell);
									e.Handled = true;
								}
							}
							else
							{
								this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.PrevCell);
								e.Handled = true;
							}
							break;
						}
				}
			}
		}

		/// <summary>
		/// UltraGrid.AfterRowActivate�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �s���A�N�e�B�u�����ꂽ���ɔ������܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void rateBlanketResult_uGrid_AfterRowActivate(object sender, EventArgs e)
		{
			// Row��Active������Ă��āACell��Active������Ă��Ȃ��ꍇ�A�u�|���J�n���v��Activeate
			if (this.rateBlanketResult_uGrid.ActiveRow == null)
			{
				return;
			}

			if (this.rateBlanketResult_uGrid.ActiveCell == null)
			{
				this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.RATESTARTDATE].Activate();
				this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.EnterEditMode);
			}
		}

		/// <summary>
		/// UltraGrid.BeforeRowDeactivate�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>						
		/// <br>Note		: �s����A�N�e�B�u������钼�O�ɔ������܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void rateBlanketResult_uGrid_BeforeRowDeactivate(object sender, CancelEventArgs e)
		{
			// �A�N�e�B�u�������s�̃Z���̊O�ς�����
			foreach (UltraGridCell wkCell in this.rateBlanketResult_uGrid.ActiveRow.Cells)
			{
				wkCell.Appearance = null;
			}
		}

		/// <summary>
		/// UltraGrid.AfterCellActivate�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �Z�����A�N�e�B�u�����ꂽ���ɔ������܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void rateBlanketResult_uGrid_AfterCellActivate(object sender, EventArgs e)
		{
			// �uNo�v�u�敪�v�u�V���v�uҰ���v�u���i���ށv�u���i�|���ݸ�v�u���i�敪�f���ށv�u���i�敪���ށv�u���i�敪�ڍ׺��ށv
			// �u���Е��޺��ށv�u�a�k���i���ށv�u���Ӑ溰�ށv�u���Ӑ�|���f�v�u�d���溰�ށv�u�d����|���f�vCell�̎�
			if((this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.NO])
				||(this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.DIVIDE])
				||(this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.OLDNEWDIVCD_NM])
				||(this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.GOODSMAKERCD])
				||(this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.GOODSNO])
				||(this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.GOODSRATERANK])
				||(this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.LARGEGOODSGANRECODE])
				||(this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.MEDIUMGOODSGANRECODE])
				||(this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.DETAILGOODSGANRECODE])
				||(this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.ENTERPRISEGANRECODE])
				||(this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.BLGOODSCODE])
				||(this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.CUSTOMERCODE])
				||(this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.CUSTRATEGRPCODE])
				||(this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.SUPPLIERCD])
				||(this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.SUPPRATEGRPCODE]))
			{
				// ActiveCell���u�|���J�n���v�փZ�b�g����
				this.rateBlanketResult_uGrid.ActiveRow.Cells[RateBlanketResult.RATESTARTDATE].Activate();
				this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.EnterEditMode);
			}
			
			//----------
			// ���͐���
			//----------
			// ���i���͎�
			if (RateBlanketAcs.NullChgDbl(this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.PRICEFL].Value) > 0)
			{
				// �|���ݒ荀�ڂ͓��͖���
				this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.RATEVAL].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
				this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
				this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.RATEVAL].TabStop = DefaultableBoolean.False;
				this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].TabStop = DefaultableBoolean.False;
			}
			else
			{
				// �|���ݒ荀�ڂ͓��͖�������
				this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.RATEVAL].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
				this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
				this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.RATEVAL].TabStop = DefaultableBoolean.True;
				this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].TabStop = DefaultableBoolean.True;
			}

			// �|���ݒ莞
			if ((RateBlanketAcs.NullChgDbl(this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.RATEVAL].Value) > 0)
				|| (RateBlanketAcs.NullChgDbl(this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.UNPRCFRACPROCUNIT].Value) > 0))
			{
				// ���i���͖���
				this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.PRICEFL].Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
				this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.PRICEFL].TabStop = DefaultableBoolean.False;
			}
			else
			{
				// ���i���͖�������
				this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.PRICEFL].Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
				this.rateBlanketResult_uGrid.ActiveCell.Row.Cells[RateBlanketResult.PRICEFL].TabStop = DefaultableBoolean.True;
			}			

			this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.EnterEditMode);

			// �A�N�e�B�u�s�̑S�ẴZ���ɂ����ĐF��������(���͉�/�s�ɂ�)
			foreach (UltraGridCell wkCell in this.rateBlanketResult_uGrid.ActiveRow.Cells)
			{
				if ((wkCell.Column.CellActivation == Activation.NoEdit) ||
					(wkCell.Activation == Activation.NoEdit))
				{
					wkCell.Appearance = GetImpossibleCellAppearance();
				}
				else
				{
					wkCell.Appearance = GetPossibleCellAppearance();
				}
			}
		}

		/// <summary>
		/// UltraGrid.BeforeSelectChange�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �P�ȏ�̍s�A�Z���A�܂��͗�I�u�W�F�N�g���I���܂��͑I�����������O�ɔ������܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void rateBlanketResult_uGrid_BeforeSelectChange(object sender, BeforeSelectChangeEventArgs e)
		{
			e.Cancel = true;
		}

		/// <summary>
		/// UltraGrid.Leave�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �A�N�e�B�u�R���g���[���łȂ��Ȃ������ɔ������܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void rateBlanketResult_uGrid_Leave(object sender, EventArgs e)
		{
			if (this.rateBlanketResult_uGrid.ActiveCell != null)
			{
				// �A�N�e�B�u�������s�̃Z���̊O�ς�����
				foreach (UltraGridCell wkCell in this.rateBlanketResult_uGrid.ActiveRow.Cells)
				{
					wkCell.Appearance = null;
				}
				// �A�N�e�B�u�ȍs�A��̃C���f�b�N�X���o�b�t�@�Ɋm��
				this._leaveRowBuf = this.rateBlanketResult_uGrid.ActiveRow.Index;
				this._leaveColBuf = this.rateBlanketResult_uGrid.ActiveCell.Column.Index;
				this.rateBlanketResult_uGrid.PerformAction(UltraGridAction.DeactivateCell);
			}
		}

		/// <summary>
		/// UltraGrid.InitializeRow�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �s�����������ꂽ���ɔ������܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void rateBlanketResult_uGrid_InitializeRow(object sender, InitializeRowEventArgs e)
		{
		}

		/// <summary>
		/// UltraGrid.InitializeLayout�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �f�[�^�\�[�X����R���g���[���Ƀf�[�^�����[�h�����Ƃ��ȂǁA
		///					  �\�����C�A�E�g�������������Ƃ��ɔ������܂��B </br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void rateBlanketResult_uGrid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
		}

		/// <summary>
		/// UltraGrid.AfterExitEditMode�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �Z�����ҏW���[�h���I��������ɔ������܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void rateBlanketResult_uGrid_AfterExitEditMode(object sender, EventArgs e)
		{
		}

		/// <summary>rateBlanketResult_uGrid_KeyPress</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �O���b�h���ŃL�[����������Ɣ������܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.10.23</br>
		/// </remarks>
		private void rateBlanketResult_uGrid_KeyPress(object sender, KeyPressEventArgs e)
		{
			//----- ueno del ---------- start 2008.02.18
			//// ����L�[�������ꂽ�H
			//if (Char.IsControl(e.KeyChar))
			//{
			//    return;
			//}

			//// ���l�Ɓu.�v�ȊO�͂m�f
			//if (Char.IsNumber(e.KeyChar) || (e.KeyChar.Equals('.')))
			//{
			//    // ����
			//}
			//else
			//{
			//    e.Handled = true;
			//}
			//----- ueno del ---------- end 2008.02.18

			//----- ueno add ---------- start 2008.02.18
			UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

			if (targetGrid.ActiveCell == null) return;

			int rowIndex = targetGrid.ActiveCell.Row.Index;
			Infragistics.Win.UltraWinGrid.UltraGridCell cell = targetGrid.ActiveCell;

			// �A�N�e�B�u�Z�����u�P���v�̏ꍇ
			if (targetGrid.ActiveCell == targetGrid.Rows[rowIndex].Cells[RateBlanketResult.PRICEFL])
			{
				// �ҏW���[�h���H
				if (targetGrid.ActiveCell.IsInEditMode)
				{
					if (!this.KeyPressNumCheck(13, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
					{
						e.Handled = true;
						return;
					}
				}
			}
			// �A�N�e�B�u�Z�����u�|���v�̏ꍇ
			else if (targetGrid.ActiveCell == targetGrid.Rows[rowIndex].Cells[RateBlanketResult.RATEVAL])
			{
				// �ҏW���[�h���H
				if (targetGrid.ActiveCell.IsInEditMode)
				{
					if (!this.KeyPressNumCheck(6, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
					{
						e.Handled = true;
						return;
					}
				}
			}
			// �A�N�e�B�u�Z�����u�P���[�������P�ʁv�̏ꍇ
			else if (targetGrid.ActiveCell == targetGrid.Rows[rowIndex].Cells[RateBlanketResult.UNPRCFRACPROCUNIT])
			{
				// �ҏW���[�h���H
				if (targetGrid.ActiveCell.IsInEditMode)
				{
					if (!this.KeyPressNumCheck(10, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
					{
						e.Handled = true;
						return;
					}
				}
			}
			//----- ueno add ---------- end 2008.02.18
		}

		/// <summary>
		/// UltraGrid.BeforeEnterEditMode�C�x���g
		/// </summary>
		/// <remarks>
		/// <br>Note		: �O���b�h��ŃG�f�B�b�g���[�h�J�n���O�ł̐�����s���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void rateBlanketResult_uGrid_BeforeEnterEditMode(object sender, CancelEventArgs e)
		{
			int rowIndex = this.rateBlanketResult_uGrid.ActiveCell.Row.Index;
		}

		/// <summary>
		/// UltraGrid.BeforeExitEditMode�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note        : �Z�����ҏW���[�h���I������O�ɔ������܂��B</br>
		/// <br>Programmer	: 30167 ���@�O�M</br>
		/// <br>Date		: 2007.10.24</br>
		/// </remarks>
		private void rateBlanketResult_uGrid_BeforeExitEditMode(object sender, Infragistics.Win.UltraWinGrid.BeforeExitEditModeEventArgs e)
		{
			string wkStr = this.rateBlanketResult_uGrid.ActiveCell.Text;
			int rowIndex = this.rateBlanketResult_uGrid.ActiveCell.Row.Index;

			//----- ueno del ---------- start 2008.02.18
			// �s���f�[�^�̃`�F�b�N��keyPress�ōs��
			////--------------------
			//// �s���f�[�^�`�F�b�N
			////--------------------
			//// �A�N�e�B�u�Z�����u�P���v�A�u�|���v�A�u�P���[�������P�ʁv�̉��ꂩ�̏ꍇ
			//if ((this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.Rows[rowIndex].Cells[RateBlanketResult.PRICEFL])
			//    || (this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.Rows[rowIndex].Cells[RateBlanketResult.RATEVAL])
			//    || (this.rateBlanketResult_uGrid.ActiveCell == this.rateBlanketResult_uGrid.Rows[rowIndex].Cells[RateBlanketResult.UNPRCFRACPROCUNIT]))
			//{
			//    if (wkStr != "")
			//    {
			//        // �s���I�h�̌��擾
			//        int cnt = 0;
			//        for (int i = 0; i < wkStr.Length; i++)
			//        {
			//            if (wkStr[i].Equals('.') == true)
			//            {
			//                cnt++;
			//            }
			//        }

			//        if (cnt > 1)
			//        {
			//            // �s���I�h�������񂠂����Ƃ������l0��ݒ�
			//            this.rateBlanketResult_uGrid.ActiveCell.Value = 0;
			//        }
			//        else
			//        {
			//            this.rateBlanketResult_uGrid.ActiveCell.Value = RateBlanketAcs.NullChgDbl(wkStr).ToString("#0.00");
			//        }
			//    }
			//    else
			//    {
			//        // null�̂Ƃ��͏����l0��ݒ�
			//        this.rateBlanketResult_uGrid.ActiveCell.Value = 0;
			//    }
			//}
			//----- ueno del ---------- end 2008.02.18
		}

		/// <summary>
		/// uce_ColSizeAutoSetting_CheckedChanged
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uce_ColSizeAutoSetting_CheckedChanged(object sender, EventArgs e)
		{
			if (!this._isEventAutoFillColumn) return;

			this._isEventAutoFillColumn = false;

			try
			{
				if (this.uce_ColSizeAutoSetting.Checked)
				{
					// �񕝂��I�[�g�ɐݒ�
					this.rateBlanketResult_uGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
				}
				else
				{
					this.rateBlanketResult_uGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
					// �J�����T�C�Y����
					GridInitialSettingWidth();
				}
			}
			finally
			{
				this._isEventAutoFillColumn = true;
			}
		}

		/// <summary>
		/// tce_FontSize_ValueChanged
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tce_FontSize_ValueChanged(object sender, EventArgs e)
		{
			// �����T�C�Y��ύX
			this.rateBlanketResult_uGrid.DisplayLayout.Appearance.FontData.SizeInPoints = (int)this.tce_FontSize.Value;
		}

		/// <summary>
		/// utb_InventDataToolBar_ToolClick
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void utb_InventDataToolBar_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			this.rateBlanketResult_uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
		}

		//----- ueno upd ---------- start 2008.02.18
		/// <summary>
		/// rateBlanketResult_uGrid_CellDataError
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �s���Ȓl�����͂��ꂽ��ԂŃZ�����X�V���悤�Ƃ���Ɣ�������B</br>
		/// <br>Programmer	: 30167 ���@�O�M</br>
		/// <br>Date		: 2008.02.18</br>
		/// </remarks>
		private void rateBlanketResult_uGrid_CellDataError(object sender, CellDataErrorEventArgs e)
		{
			UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

			if (targetGrid.ActiveCell != null)
			{
				// ���l���ڂ̏ꍇ
				if ((targetGrid.ActiveCell.Column.DataType == typeof(Int32)) ||
					(targetGrid.ActiveCell.Column.DataType == typeof(Int64)) ||
					(targetGrid.ActiveCell.Column.DataType == typeof(double)))
				{
					Infragistics.Win.EmbeddableEditorBase editorBase = targetGrid.ActiveCell.EditorResolved;

					// �����͂�0�ɂ���
					if (editorBase.CurrentEditText.Trim() == "")
					{
						editorBase.Value = 0;				// 0���Z�b�g
						targetGrid.ActiveCell.Value = 0;
					}
					// ���l���ڂɁu-�vor�u.�v�������������ĂȂ�������ʖڂł�
					else if ((editorBase.CurrentEditText.Trim() == "-") ||
						(editorBase.CurrentEditText.Trim() == ".") ||
						(editorBase.CurrentEditText.Trim() == "-."))
					{
						editorBase.Value = 0;				// 0���Z�b�g
						targetGrid.ActiveCell.Value = 0;
					}
					// �ʏ����
					else
					{
						try
						{
							editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), targetGrid.ActiveCell.Column.DataType);
							targetGrid.ActiveCell.Value = editorBase.Value;
						}
						catch
						{
							editorBase.Value = 0;
							targetGrid.ActiveCell.Value = 0;
						}
					}
					e.RaiseErrorEvent = false;			// �G���[�C�x���g�͔��������Ȃ�
					e.RestoreOriginalValue = false;		// �Z���̒l�����ɖ߂��Ȃ�
					e.StayInEditMode = false;			// �ҏW���[�h�͔�����
				}
			}
		}
		//----- ueno upd ---------- end 2008.02.18

		//----- ueno del ---------- start 2008.02.18
		// �s���`�F�b�N��CellDataError�ōs���Ă���̂ŕs�v
		///// <summary>
		///// rateBlanketResult_uGrid_CellChange
		///// </summary>
		///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		///// <param name="e">�C�x���g�p�����[�^</param>
		///// <remarks>
		///// <br>Note		: �ҏW���[�h�ɂ���Z���̒l�����[�U�[���ύX�����Ƃ��ɔ�������B</br>
		///// <br>Programmer	: 30167 ���@�O�M</br>
		///// <br>Date		: 2007.11.08</br>
		///// </remarks>
		//private void rateBlanketResult_uGrid_CellChange(object sender, CellEventArgs e)
		//{
		//    // NetAdvantage �s��̂��߂̃��W�b�N

		//    // �A�N�e�B�u�Z�����L��
		//    if (this.rateBlanketResult_uGrid.ActiveCell != null)
		//    {
		//        // NetAdvantage �s��̂��߂̃��W�b�N
				
		//        // ���݂̃Z�����擾
		//        UltraGridCell currentCell = this.rateBlanketResult_uGrid.ActiveCell;

		//        // ���݂̃A�N�e�B�u�Z���̃X�^�C����Edit�̏ꍇ
		//        if ( currentCell.StyleResolved == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit )
		//        {
		//            // �ύX���ꂽ���ʁAText���󔒂ƂȂ����ꍇ
		//            if( ( currentCell.Text == null ) || ( currentCell.Text.TrimEnd() == "" ) ) 
		//            {
		//                // ���݂̃Z���̌^���AInt32�AInt64�Adouble�^�̏ꍇ
		//                if ((e.Cell.Column.DataType == typeof(Int32)) ||
		//                    (e.Cell.Column.DataType == typeof(Int64)) ||
		//                    (e.Cell.Column.DataType == typeof(double)))
		//                {
		//                    // �l���󔒂Ƃ͂����ɁA"0"���Z�b�g���適NULL�łǂ���
		//                    //	e.Cell.Value = 0;
		//                    e.Cell.Value = DBNull.Value;
		//                }
		//            }
		//        }
		//    }
		//}
		//----- ueno del ---------- end 2008.02.18

		#endregion Grid Event

	}
}

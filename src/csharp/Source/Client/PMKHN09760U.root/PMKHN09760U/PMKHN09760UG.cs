//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �}�X�����t���[��
// �v���O�����T�v   : �}�X�^�����e�i���X���̈ꗗ�\�����s���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : �i�N
// �� �� ��  2014/12/23  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
#define SYNCHRONIZE_LOGICAL_DELETE_RECORD_FORCE // �����I�Ɂu�폜�ς݃f�[�^�̕\���v�`�F�b�N�{�b�N�X��A��������t���O
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �ꗗ�\���i�R�K�w�j�t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �}�X�^�����e�i���X���̈ꗗ�\���i�R�K�w�j���s���܂��B</br>
    /// <br>Programmer : �i�N</br>
    /// <br>Date       : 2014/12/23</br>
	/// </remarks>
	internal class PMKHN09760UG
        : System.Windows.Forms.Form,
        IOperationAuthorityControllable
	{
		# region Private Members (Component)

		private System.Windows.Forms.Panel ViewButtonPanel;
		private System.Windows.Forms.Timer Close_Timer;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.Misc.UltraButton New_Button;
		private Infragistics.Win.Misc.UltraButton Modify_Button;
		private Infragistics.Win.Misc.UltraButton Close_Button;
		private Infragistics.Win.Misc.UltraButton Print_Button;
		internal System.Windows.Forms.Timer NextSearch_Timer;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
		private Infragistics.Win.UltraWinDock.UltraDockManager ultraDockManager1;
		private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow1;
		private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow2;
		private Infragistics.Win.Misc.UltraButton Details_Button;
		private System.Data.DataSet Bind_DataSet;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN09760UG_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN09760UG_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN09760UG_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN09760UG_Toolbars_Dock_Area_Bottom;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _PMKHN09760UGUnpinnedTabAreaLeft;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _PMKHN09760UGUnpinnedTabAreaRight;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _PMKHN09760UGUnpinnedTabAreaTop;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _PMKHN09760UGUnpinnedTabAreaBottom;
		private Infragistics.Win.UltraWinDock.AutoHideControl _PMKHN09760UGAutoHideControl;
		private System.Windows.Forms.Panel Third_Panel;
		private Infragistics.Win.UltraWinGrid.UltraGrid Third_Grid;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar Third_StatusBar;
		private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow3;
		private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea5;
		private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea2;
		private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea1;
		private System.Windows.Forms.Panel First_Panel;
		private Infragistics.Win.UltraWinGrid.UltraGrid First_Grid;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar First_StatusBar;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor AutoFillToFirstGridColumn_CheckEditor;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor FirstLogicalDeleteDataExtraction_CheckEditor;
		private System.Windows.Forms.Panel Second_Panel;
		private Infragistics.Win.UltraWinGrid.UltraGrid Second_Grid;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor AutoFillToSecondGridColumn_CheckEditor;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor SecondLogicalDeleteDataExtraction_CheckEditor;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar Second_StatusBar;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor AutoFillToThirdGridColumn_CheckEditor;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor ThirdLogicalDeleteDataExtraction_CheckEditor;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// �ꗗ�\���t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �ꗗ�\���t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		internal PMKHN09760UG()
		{
			InitializeComponent();

			// �ϐ�������
			this._targetData = TargetData.First;
		}
		# endregion

		# region Dispose
		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		# endregion

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
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel5 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel6 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel7 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel8 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel9 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel10 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel11 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel12 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel13 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel14 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel15 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Main_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool1 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Close_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool2 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("New_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool3 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Delete_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool4 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Modify_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool5 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Print_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool6 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Details_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool7 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Close_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool8 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("New_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool9 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Delete_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool10 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Modify_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool11 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Print_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool12 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Details_ControlContainerTool");
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedRight, new System.Guid("71767412-1f5a-497b-9eef-4b0b9059722b"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("913e1dd5-6894-45cd-bbb4-17f576f40ca7"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("71767412-1f5a-497b-9eef-4b0b9059722b"), -1);
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane2 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("e6edb449-1a14-46fa-a082-a5cfae4165e5"), new System.Guid("910ab0a9-825a-4a8f-8bd5-7b834d1fed89"), -1, new System.Guid("71767412-1f5a-497b-9eef-4b0b9059722b"), 0);
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane3 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("d45ee86a-bf26-4e65-bd50-9f176ea7b885"), new System.Guid("8e0faff9-49b4-4a17-a1a4-a5967bceea66"), -1, new System.Guid("71767412-1f5a-497b-9eef-4b0b9059722b"), 0);
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane2 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.Floating, new System.Guid("910ab0a9-825a-4a8f-8bd5-7b834d1fed89"));
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane3 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.Floating, new System.Guid("8e0faff9-49b4-4a17-a1a4-a5967bceea66"));
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            this.AutoFillToFirstGridColumn_CheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.FirstLogicalDeleteDataExtraction_CheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.AutoFillToSecondGridColumn_CheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.SecondLogicalDeleteDataExtraction_CheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.AutoFillToThirdGridColumn_CheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ThirdLogicalDeleteDataExtraction_CheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.First_Panel = new System.Windows.Forms.Panel();
            this.First_Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.First_StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Second_Panel = new System.Windows.Forms.Panel();
            this.Second_Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.Second_StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Third_Panel = new System.Windows.Forms.Panel();
            this.Third_Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.Third_StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Close_Button = new Infragistics.Win.Misc.UltraButton();
            this.New_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Modify_Button = new Infragistics.Win.Misc.UltraButton();
            this.Print_Button = new Infragistics.Win.Misc.UltraButton();
            this.Details_Button = new Infragistics.Win.Misc.UltraButton();
            this.ViewButtonPanel = new System.Windows.Forms.Panel();
            this.Bind_DataSet = new System.Data.DataSet();
            this.Close_Timer = new System.Windows.Forms.Timer(this.components);
            this.NextSearch_Timer = new System.Windows.Forms.Timer(this.components);
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._PMKHN09760UG_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMKHN09760UG_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMKHN09760UG_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMKHN09760UG_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraDockManager1 = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._PMKHN09760UGUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._PMKHN09760UGUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._PMKHN09760UGUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._PMKHN09760UGUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._PMKHN09760UGAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.dockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.dockableWindow2 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.dockableWindow3 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.windowDockingArea5 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.windowDockingArea2 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.windowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.First_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.First_Grid)).BeginInit();
            this.First_StatusBar.SuspendLayout();
            this.Second_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Second_Grid)).BeginInit();
            this.Second_StatusBar.SuspendLayout();
            this.Third_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Third_Grid)).BeginInit();
            this.Third_StatusBar.SuspendLayout();
            this.ViewButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDockManager1)).BeginInit();
            this.dockableWindow1.SuspendLayout();
            this.dockableWindow2.SuspendLayout();
            this.dockableWindow3.SuspendLayout();
            this.windowDockingArea5.SuspendLayout();
            this.SuspendLayout();
            // 
            // AutoFillToFirstGridColumn_CheckEditor
            // 
            appearance1.FontData.SizeInPoints = 9F;
            this.AutoFillToFirstGridColumn_CheckEditor.Appearance = appearance1;
            this.AutoFillToFirstGridColumn_CheckEditor.Checked = true;
            this.AutoFillToFirstGridColumn_CheckEditor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoFillToFirstGridColumn_CheckEditor.Location = new System.Drawing.Point(3, 4);
            this.AutoFillToFirstGridColumn_CheckEditor.Name = "AutoFillToFirstGridColumn_CheckEditor";
            this.AutoFillToFirstGridColumn_CheckEditor.Size = new System.Drawing.Size(138, 20);
            this.AutoFillToFirstGridColumn_CheckEditor.TabIndex = 8;
            this.AutoFillToFirstGridColumn_CheckEditor.Tag = "0";
            this.AutoFillToFirstGridColumn_CheckEditor.Text = "��T�C�Y�̎�������";
            this.AutoFillToFirstGridColumn_CheckEditor.CheckedChanged += new System.EventHandler(this.AutoFillToGridColumn_CheckEditor_CheckedChanged);
            // 
            // FirstLogicalDeleteDataExtraction_CheckEditor
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.FontData.SizeInPoints = 9F;
            appearance2.TextVAlignAsString = "Middle";
            this.FirstLogicalDeleteDataExtraction_CheckEditor.Appearance = appearance2;
            this.FirstLogicalDeleteDataExtraction_CheckEditor.BackColor = System.Drawing.Color.Transparent;
            this.FirstLogicalDeleteDataExtraction_CheckEditor.BackColorInternal = System.Drawing.Color.Transparent;
            this.FirstLogicalDeleteDataExtraction_CheckEditor.Location = new System.Drawing.Point(154, 4);
            this.FirstLogicalDeleteDataExtraction_CheckEditor.Name = "FirstLogicalDeleteDataExtraction_CheckEditor";
            this.FirstLogicalDeleteDataExtraction_CheckEditor.Size = new System.Drawing.Size(96, 20);
            this.FirstLogicalDeleteDataExtraction_CheckEditor.TabIndex = 0;
            this.FirstLogicalDeleteDataExtraction_CheckEditor.Tag = "0";
            this.FirstLogicalDeleteDataExtraction_CheckEditor.Text = "�폜�ς݃f�[�^�̕\��";
            this.FirstLogicalDeleteDataExtraction_CheckEditor.CheckedChanged += new System.EventHandler(this.LogicalDeleteDataExtraction_CheckEditor_CheckedChanged);
            // 
            // AutoFillToSecondGridColumn_CheckEditor
            // 
            appearance3.FontData.SizeInPoints = 9F;
            this.AutoFillToSecondGridColumn_CheckEditor.Appearance = appearance3;
            this.AutoFillToSecondGridColumn_CheckEditor.Checked = true;
            this.AutoFillToSecondGridColumn_CheckEditor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoFillToSecondGridColumn_CheckEditor.Location = new System.Drawing.Point(3, 4);
            this.AutoFillToSecondGridColumn_CheckEditor.Name = "AutoFillToSecondGridColumn_CheckEditor";
            this.AutoFillToSecondGridColumn_CheckEditor.Size = new System.Drawing.Size(138, 20);
            this.AutoFillToSecondGridColumn_CheckEditor.TabIndex = 10;
            this.AutoFillToSecondGridColumn_CheckEditor.Tag = "1";
            this.AutoFillToSecondGridColumn_CheckEditor.Text = "��T�C�Y�̎�������";
            this.AutoFillToSecondGridColumn_CheckEditor.CheckedChanged += new System.EventHandler(this.AutoFillToGridColumn_CheckEditor_CheckedChanged);
            // 
            // SecondLogicalDeleteDataExtraction_CheckEditor
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.FontData.SizeInPoints = 9F;
            appearance4.TextVAlignAsString = "Middle";
            this.SecondLogicalDeleteDataExtraction_CheckEditor.Appearance = appearance4;
            this.SecondLogicalDeleteDataExtraction_CheckEditor.BackColor = System.Drawing.Color.Transparent;
            this.SecondLogicalDeleteDataExtraction_CheckEditor.BackColorInternal = System.Drawing.Color.Transparent;
            this.SecondLogicalDeleteDataExtraction_CheckEditor.Location = new System.Drawing.Point(154, 4);
            this.SecondLogicalDeleteDataExtraction_CheckEditor.Name = "SecondLogicalDeleteDataExtraction_CheckEditor";
            this.SecondLogicalDeleteDataExtraction_CheckEditor.Size = new System.Drawing.Size(95, 20);
            this.SecondLogicalDeleteDataExtraction_CheckEditor.TabIndex = 0;
            this.SecondLogicalDeleteDataExtraction_CheckEditor.Tag = "1";
            this.SecondLogicalDeleteDataExtraction_CheckEditor.Text = "�폜�ς݃f�[�^�̕\��";
            this.SecondLogicalDeleteDataExtraction_CheckEditor.CheckedChanged += new System.EventHandler(this.LogicalDeleteDataExtraction_CheckEditor_CheckedChanged);
            // 
            // AutoFillToThirdGridColumn_CheckEditor
            // 
            appearance5.FontData.SizeInPoints = 9F;
            this.AutoFillToThirdGridColumn_CheckEditor.Appearance = appearance5;
            this.AutoFillToThirdGridColumn_CheckEditor.Checked = true;
            this.AutoFillToThirdGridColumn_CheckEditor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoFillToThirdGridColumn_CheckEditor.Location = new System.Drawing.Point(3, 4);
            this.AutoFillToThirdGridColumn_CheckEditor.Name = "AutoFillToThirdGridColumn_CheckEditor";
            this.AutoFillToThirdGridColumn_CheckEditor.Size = new System.Drawing.Size(138, 20);
            this.AutoFillToThirdGridColumn_CheckEditor.TabIndex = 10;
            this.AutoFillToThirdGridColumn_CheckEditor.Tag = "2";
            this.AutoFillToThirdGridColumn_CheckEditor.Text = "��T�C�Y�̎�������";
            this.AutoFillToThirdGridColumn_CheckEditor.CheckedChanged += new System.EventHandler(this.AutoFillToGridColumn_CheckEditor_CheckedChanged);
            // 
            // ThirdLogicalDeleteDataExtraction_CheckEditor
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            appearance6.FontData.SizeInPoints = 9F;
            appearance6.TextVAlignAsString = "Middle";
            this.ThirdLogicalDeleteDataExtraction_CheckEditor.Appearance = appearance6;
            this.ThirdLogicalDeleteDataExtraction_CheckEditor.BackColor = System.Drawing.Color.Transparent;
            this.ThirdLogicalDeleteDataExtraction_CheckEditor.BackColorInternal = System.Drawing.Color.Transparent;
            this.ThirdLogicalDeleteDataExtraction_CheckEditor.Location = new System.Drawing.Point(154, 4);
            this.ThirdLogicalDeleteDataExtraction_CheckEditor.Name = "ThirdLogicalDeleteDataExtraction_CheckEditor";
            this.ThirdLogicalDeleteDataExtraction_CheckEditor.Size = new System.Drawing.Size(93, 20);
            this.ThirdLogicalDeleteDataExtraction_CheckEditor.TabIndex = 0;
            this.ThirdLogicalDeleteDataExtraction_CheckEditor.Tag = "2";
            this.ThirdLogicalDeleteDataExtraction_CheckEditor.Text = "�폜�ς݃f�[�^�̕\��";
            this.ThirdLogicalDeleteDataExtraction_CheckEditor.CheckedChanged += new System.EventHandler(this.LogicalDeleteDataExtraction_CheckEditor_CheckedChanged);
            // 
            // First_Panel
            // 
            this.First_Panel.Controls.Add(this.First_Grid);
            this.First_Panel.Controls.Add(this.First_StatusBar);
            this.First_Panel.Location = new System.Drawing.Point(0, 26);
            this.First_Panel.Name = "First_Panel";
            this.First_Panel.Size = new System.Drawing.Size(251, 615);
            this.First_Panel.TabIndex = 5;
            // 
            // First_Grid
            // 
            this.First_Grid.Cursor = System.Windows.Forms.Cursors.Default;
            appearance7.BackColor = System.Drawing.Color.White;
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.First_Grid.DisplayLayout.Appearance = appearance7;
            this.First_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.First_Grid.DisplayLayout.GroupByBox.Hidden = true;
            this.First_Grid.DisplayLayout.InterBandSpacing = 10;
            this.First_Grid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.First_Grid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.First_Grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.First_Grid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.First_Grid.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.First_Grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance8.BackColor = System.Drawing.Color.Transparent;
            this.First_Grid.DisplayLayout.Override.CardAreaAppearance = appearance8;
            this.First_Grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance9.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance9.ForeColor = System.Drawing.Color.White;
            appearance9.TextHAlignAsString = "Left";
            appearance9.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.First_Grid.DisplayLayout.Override.HeaderAppearance = appearance9;
            this.First_Grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            appearance10.BackColor = System.Drawing.Color.Lavender;
            this.First_Grid.DisplayLayout.Override.RowAlternateAppearance = appearance10;
            appearance11.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.First_Grid.DisplayLayout.Override.RowAppearance = appearance11;
            this.First_Grid.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.First_Grid.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance12.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance12.ForeColor = System.Drawing.Color.White;
            this.First_Grid.DisplayLayout.Override.RowSelectorAppearance = appearance12;
            this.First_Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.First_Grid.DisplayLayout.Override.RowSelectorWidth = 12;
            this.First_Grid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance13.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance13.ForeColor = System.Drawing.Color.Black;
            this.First_Grid.DisplayLayout.Override.SelectedRowAppearance = appearance13;
            this.First_Grid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.First_Grid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.First_Grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.First_Grid.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.First_Grid.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.First_Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.First_Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.First_Grid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.First_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.First_Grid.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.First_Grid.Location = new System.Drawing.Point(0, 0);
            this.First_Grid.Name = "First_Grid";
            this.First_Grid.Size = new System.Drawing.Size(251, 588);
            this.First_Grid.TabIndex = 0;
            this.First_Grid.DoubleClick += new System.EventHandler(this.Grid_DoubleClick);
            this.First_Grid.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.First_Grid_AfterSelectChange);
            this.First_Grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grid_KeyDown);
            this.First_Grid.AfterSortChange += new Infragistics.Win.UltraWinGrid.BandEventHandler(this.Grid_AfterSortChange);
            this.First_Grid.Enter += new System.EventHandler(this.First_Grid_Enter);
            // 
            // First_StatusBar
            // 
            appearance14.FontData.SizeInPoints = 9F;
            this.First_StatusBar.Appearance = appearance14;
            this.First_StatusBar.Controls.Add(this.AutoFillToFirstGridColumn_CheckEditor);
            this.First_StatusBar.Controls.Add(this.FirstLogicalDeleteDataExtraction_CheckEditor);
            this.First_StatusBar.InterPanelSpacing = 5;
            this.First_StatusBar.Location = new System.Drawing.Point(0, 588);
            this.First_StatusBar.Name = "First_StatusBar";
            ultraStatusPanel1.Control = this.AutoFillToFirstGridColumn_CheckEditor;
            ultraStatusPanel1.Key = "AutoFillToFirstGridColumn_StatusPanel";
            ultraStatusPanel1.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel1.Width = 140;
            ultraStatusPanel2.Key = "Line1_StatusPanel";
            ultraStatusPanel2.Width = 1;
            ultraStatusPanel3.Control = this.FirstLogicalDeleteDataExtraction_CheckEditor;
            ultraStatusPanel3.Key = "FirstLogicalDeleteDataExtraction_StatusPanel";
            ultraStatusPanel3.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel3.Width = 150;
            ultraStatusPanel4.Key = "Line2_StatusPanel";
            ultraStatusPanel4.Width = 1;
            appearance15.TextHAlignAsString = "Right";
            ultraStatusPanel5.Appearance = appearance15;
            ultraStatusPanel5.Key = "SearchCount_StatusPanel";
            ultraStatusPanel5.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel5.Text = "��";
            ultraStatusPanel5.Width = 0;
            this.First_StatusBar.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3,
            ultraStatusPanel4,
            ultraStatusPanel5});
            this.First_StatusBar.ResizeStyle = Infragistics.Win.UltraWinStatusBar.ResizeStyle.None;
            this.First_StatusBar.Size = new System.Drawing.Size(251, 27);
            this.First_StatusBar.TabIndex = 2;
            this.First_StatusBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Second_Panel
            // 
            this.Second_Panel.Controls.Add(this.Second_Grid);
            this.Second_Panel.Controls.Add(this.Second_StatusBar);
            this.Second_Panel.Location = new System.Drawing.Point(0, 26);
            this.Second_Panel.Name = "Second_Panel";
            this.Second_Panel.Size = new System.Drawing.Size(250, 615);
            this.Second_Panel.TabIndex = 3;
            // 
            // Second_Grid
            // 
            this.Second_Grid.Cursor = System.Windows.Forms.Cursors.Default;
            appearance16.BackColor = System.Drawing.Color.White;
            appearance16.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Second_Grid.DisplayLayout.Appearance = appearance16;
            this.Second_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.Second_Grid.DisplayLayout.GroupByBox.Hidden = true;
            this.Second_Grid.DisplayLayout.InterBandSpacing = 10;
            this.Second_Grid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.Second_Grid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.Second_Grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.Second_Grid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.Second_Grid.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.Second_Grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance17.BackColor = System.Drawing.Color.Transparent;
            this.Second_Grid.DisplayLayout.Override.CardAreaAppearance = appearance17;
            this.Second_Grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance18.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance18.ForeColor = System.Drawing.Color.White;
            appearance18.TextHAlignAsString = "Left";
            appearance18.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.Second_Grid.DisplayLayout.Override.HeaderAppearance = appearance18;
            this.Second_Grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            appearance19.BackColor = System.Drawing.Color.Lavender;
            this.Second_Grid.DisplayLayout.Override.RowAlternateAppearance = appearance19;
            appearance20.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.Second_Grid.DisplayLayout.Override.RowAppearance = appearance20;
            this.Second_Grid.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.Second_Grid.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance21.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance21.ForeColor = System.Drawing.Color.White;
            this.Second_Grid.DisplayLayout.Override.RowSelectorAppearance = appearance21;
            this.Second_Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.Second_Grid.DisplayLayout.Override.RowSelectorWidth = 12;
            this.Second_Grid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance22.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance22.ForeColor = System.Drawing.Color.Black;
            this.Second_Grid.DisplayLayout.Override.SelectedRowAppearance = appearance22;
            this.Second_Grid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.Second_Grid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.Second_Grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.Second_Grid.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.Second_Grid.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.Second_Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.Second_Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.Second_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Second_Grid.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Second_Grid.Location = new System.Drawing.Point(0, 0);
            this.Second_Grid.Name = "Second_Grid";
            this.Second_Grid.Size = new System.Drawing.Size(250, 588);
            this.Second_Grid.TabIndex = 4;
            this.Second_Grid.DoubleClick += new System.EventHandler(this.Grid_DoubleClick);
            this.Second_Grid.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.Second_Grid_AfterSelectChange);
            this.Second_Grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grid_KeyDown);
            this.Second_Grid.AfterSortChange += new Infragistics.Win.UltraWinGrid.BandEventHandler(this.Grid_AfterSortChange);
            this.Second_Grid.Enter += new System.EventHandler(this.Second_Grid_Enter);
            // 
            // Second_StatusBar
            // 
            appearance23.FontData.SizeInPoints = 9F;
            this.Second_StatusBar.Appearance = appearance23;
            this.Second_StatusBar.Controls.Add(this.SecondLogicalDeleteDataExtraction_CheckEditor);
            this.Second_StatusBar.Controls.Add(this.AutoFillToSecondGridColumn_CheckEditor);
            this.Second_StatusBar.InterPanelSpacing = 5;
            this.Second_StatusBar.Location = new System.Drawing.Point(0, 588);
            this.Second_StatusBar.Name = "Second_StatusBar";
            ultraStatusPanel6.Control = this.AutoFillToSecondGridColumn_CheckEditor;
            ultraStatusPanel6.Key = "AutoFillToSecondGridColumn_StatusPanel";
            ultraStatusPanel6.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel6.Width = 140;
            ultraStatusPanel7.Key = "Line1_StatusPanel";
            ultraStatusPanel7.Width = 1;
            ultraStatusPanel8.Control = this.SecondLogicalDeleteDataExtraction_CheckEditor;
            ultraStatusPanel8.Key = "SecondLogicalDeleteDataExtraction_StatusPanel";
            ultraStatusPanel8.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel8.Width = 150;
            ultraStatusPanel9.Key = "Line2_StatusPanel";
            ultraStatusPanel9.Width = 1;
            appearance24.TextHAlignAsString = "Right";
            ultraStatusPanel10.Appearance = appearance24;
            ultraStatusPanel10.Key = "SearchCount_StatusPanel";
            ultraStatusPanel10.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel10.Text = "��";
            ultraStatusPanel10.Width = 0;
            this.Second_StatusBar.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel6,
            ultraStatusPanel7,
            ultraStatusPanel8,
            ultraStatusPanel9,
            ultraStatusPanel10});
            this.Second_StatusBar.ResizeStyle = Infragistics.Win.UltraWinStatusBar.ResizeStyle.None;
            this.Second_StatusBar.Size = new System.Drawing.Size(250, 27);
            this.Second_StatusBar.TabIndex = 3;
            this.Second_StatusBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Third_Panel
            // 
            this.Third_Panel.Controls.Add(this.Third_Grid);
            this.Third_Panel.Controls.Add(this.Third_StatusBar);
            this.Third_Panel.Location = new System.Drawing.Point(0, 26);
            this.Third_Panel.Name = "Third_Panel";
            this.Third_Panel.Size = new System.Drawing.Size(248, 615);
            this.Third_Panel.TabIndex = 37;
            // 
            // Third_Grid
            // 
            this.Third_Grid.Cursor = System.Windows.Forms.Cursors.Default;
            appearance25.BackColor = System.Drawing.Color.White;
            appearance25.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Third_Grid.DisplayLayout.Appearance = appearance25;
            this.Third_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.Third_Grid.DisplayLayout.GroupByBox.Hidden = true;
            this.Third_Grid.DisplayLayout.InterBandSpacing = 10;
            this.Third_Grid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.Third_Grid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.Third_Grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.Third_Grid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.Third_Grid.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.Third_Grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance26.BackColor = System.Drawing.Color.Transparent;
            this.Third_Grid.DisplayLayout.Override.CardAreaAppearance = appearance26;
            this.Third_Grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance27.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance27.ForeColor = System.Drawing.Color.White;
            appearance27.TextHAlignAsString = "Left";
            appearance27.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.Third_Grid.DisplayLayout.Override.HeaderAppearance = appearance27;
            this.Third_Grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            appearance28.BackColor = System.Drawing.Color.Lavender;
            this.Third_Grid.DisplayLayout.Override.RowAlternateAppearance = appearance28;
            appearance29.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.Third_Grid.DisplayLayout.Override.RowAppearance = appearance29;
            this.Third_Grid.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.Third_Grid.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance30.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance30.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance30.ForeColor = System.Drawing.Color.White;
            this.Third_Grid.DisplayLayout.Override.RowSelectorAppearance = appearance30;
            this.Third_Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.Third_Grid.DisplayLayout.Override.RowSelectorWidth = 12;
            this.Third_Grid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance31.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance31.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance31.ForeColor = System.Drawing.Color.Black;
            this.Third_Grid.DisplayLayout.Override.SelectedRowAppearance = appearance31;
            this.Third_Grid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.Third_Grid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.Third_Grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.Third_Grid.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.Third_Grid.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.Third_Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.Third_Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.Third_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Third_Grid.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Third_Grid.Location = new System.Drawing.Point(0, 0);
            this.Third_Grid.Name = "Third_Grid";
            this.Third_Grid.Size = new System.Drawing.Size(248, 588);
            this.Third_Grid.TabIndex = 4;
            this.Third_Grid.DoubleClick += new System.EventHandler(this.Grid_DoubleClick);
            this.Third_Grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grid_KeyDown);
            this.Third_Grid.AfterSortChange += new Infragistics.Win.UltraWinGrid.BandEventHandler(this.Grid_AfterSortChange);
            this.Third_Grid.Enter += new System.EventHandler(this.Third_Grid_Enter);
            // 
            // Third_StatusBar
            // 
            appearance32.FontData.SizeInPoints = 9F;
            this.Third_StatusBar.Appearance = appearance32;
            this.Third_StatusBar.Controls.Add(this.AutoFillToThirdGridColumn_CheckEditor);
            this.Third_StatusBar.Controls.Add(this.ThirdLogicalDeleteDataExtraction_CheckEditor);
            this.Third_StatusBar.InterPanelSpacing = 5;
            this.Third_StatusBar.Location = new System.Drawing.Point(0, 588);
            this.Third_StatusBar.Name = "Third_StatusBar";
            ultraStatusPanel11.Control = this.AutoFillToThirdGridColumn_CheckEditor;
            ultraStatusPanel11.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel11.Width = 140;
            ultraStatusPanel12.Key = "Line1_StatusPanel";
            ultraStatusPanel12.Width = 1;
            ultraStatusPanel13.Control = this.ThirdLogicalDeleteDataExtraction_CheckEditor;
            ultraStatusPanel13.Key = "ThirdLogicalDeleteDataExtraction_StatusPanel";
            ultraStatusPanel13.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel13.Width = 150;
            ultraStatusPanel14.Key = "Line2_StatusPanel";
            ultraStatusPanel14.Width = 1;
            appearance33.TextHAlignAsString = "Right";
            ultraStatusPanel15.Appearance = appearance33;
            ultraStatusPanel15.Key = "SearchCount_StatusPanel";
            ultraStatusPanel15.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel15.Text = "��";
            ultraStatusPanel15.Width = 0;
            this.Third_StatusBar.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel11,
            ultraStatusPanel12,
            ultraStatusPanel13,
            ultraStatusPanel14,
            ultraStatusPanel15});
            this.Third_StatusBar.ResizeStyle = Infragistics.Win.UltraWinStatusBar.ResizeStyle.None;
            this.Third_StatusBar.Size = new System.Drawing.Size(248, 27);
            this.Third_StatusBar.TabIndex = 3;
            this.Third_StatusBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Close_Button
            // 
            this.Close_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Close_Button.Location = new System.Drawing.Point(0, 0);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(90, 27);
            this.Close_Button.TabIndex = 2;
            this.Close_Button.TabStop = false;
            this.Close_Button.Text = "����(&C)";
            this.Close_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // New_Button
            // 
            this.New_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.New_Button.Location = new System.Drawing.Point(90, 0);
            this.New_Button.Name = "New_Button";
            this.New_Button.Size = new System.Drawing.Size(75, 27);
            this.New_Button.TabIndex = 3;
            this.New_Button.TabStop = false;
            this.New_Button.Text = "�V�K(&N)";
            this.New_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.New_Button.Click += new System.EventHandler(this.New_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Delete_Button.Location = new System.Drawing.Point(170, 0);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(75, 27);
            this.Delete_Button.TabIndex = 4;
            this.Delete_Button.TabStop = false;
            this.Delete_Button.Text = "�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Modify_Button
            // 
            this.Modify_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Modify_Button.Location = new System.Drawing.Point(250, 0);
            this.Modify_Button.Name = "Modify_Button";
            this.Modify_Button.Size = new System.Drawing.Size(75, 27);
            this.Modify_Button.TabIndex = 5;
            this.Modify_Button.TabStop = false;
            this.Modify_Button.Text = "�C��(&E)";
            this.Modify_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Modify_Button.Click += new System.EventHandler(this.Modify_Button_Click);
            // 
            // Print_Button
            // 
            this.Print_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Print_Button.Location = new System.Drawing.Point(330, 0);
            this.Print_Button.Name = "Print_Button";
            this.Print_Button.Size = new System.Drawing.Size(75, 27);
            this.Print_Button.TabIndex = 7;
            this.Print_Button.TabStop = false;
            this.Print_Button.Text = "���(&P)";
            this.Print_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Print_Button.Click += new System.EventHandler(this.Print_Button_Click);
            // 
            // Details_Button
            // 
            this.Details_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Details_Button.Location = new System.Drawing.Point(410, 0);
            this.Details_Button.Name = "Details_Button";
            this.Details_Button.Size = new System.Drawing.Size(75, 27);
            this.Details_Button.TabIndex = 9;
            this.Details_Button.Text = "�ڍ�(&T)";
            this.Details_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Details_Button.Click += new System.EventHandler(this.Details_Button_Click);
            // 
            // ViewButtonPanel
            // 
            this.ViewButtonPanel.BackColor = System.Drawing.Color.GhostWhite;
            this.ViewButtonPanel.Controls.Add(this.Details_Button);
            this.ViewButtonPanel.Controls.Add(this.Delete_Button);
            this.ViewButtonPanel.Controls.Add(this.New_Button);
            this.ViewButtonPanel.Controls.Add(this.Modify_Button);
            this.ViewButtonPanel.Controls.Add(this.Print_Button);
            this.ViewButtonPanel.Controls.Add(this.Close_Button);
            this.ViewButtonPanel.Location = new System.Drawing.Point(0, 90);
            this.ViewButtonPanel.Name = "ViewButtonPanel";
            this.ViewButtonPanel.Size = new System.Drawing.Size(759, 30);
            this.ViewButtonPanel.TabIndex = 1;
            this.ViewButtonPanel.Visible = false;
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // Close_Timer
            // 
            this.Close_Timer.Tick += new System.EventHandler(this.Close_Timer_Tick);
            // 
            // NextSearch_Timer
            // 
            this.NextSearch_Timer.Interval = 1;
            this.NextSearch_Timer.Tick += new System.EventHandler(this.NextSearch_Timer_Tick);
            // 
            // ultraToolbarsManager1
            // 
            appearance34.BackColor = System.Drawing.Color.GhostWhite;
            this.ultraToolbarsManager1.Appearance = appearance34;
            this.ultraToolbarsManager1.DesignerFlags = 1;
            this.ultraToolbarsManager1.DockWithinContainer = this;
            this.ultraToolbarsManager1.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.ultraToolbarsManager1.LockToolbars = true;
            this.ultraToolbarsManager1.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.ultraToolbarsManager1.ShowFullMenusDelay = 500;
            this.ultraToolbarsManager1.ShowQuickCustomizeButton = false;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.IsMainMenuBar = true;
            controlContainerTool1.ControlName = "Close_Button";
            controlContainerTool1.InstanceProps.Width = 92;
            controlContainerTool2.ControlName = "New_Button";
            controlContainerTool3.ControlName = "Delete_Button";
            controlContainerTool4.ControlName = "Modify_Button";
            controlContainerTool5.ControlName = "Print_Button";
            controlContainerTool6.ControlName = "Details_Button";
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            controlContainerTool1,
            controlContainerTool2,
            controlContainerTool3,
            controlContainerTool4,
            controlContainerTool5,
            controlContainerTool6,
            labelTool1});
            ultraToolbar1.Text = "�W��";
            this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            controlContainerTool7.ControlName = "Close_Button";
            controlContainerTool7.SharedProps.Caption = "Close_ControlContainerTool";
            controlContainerTool7.SharedProps.Width = 92;
            controlContainerTool8.ControlName = "New_Button";
            controlContainerTool8.SharedProps.Caption = "New_ControlContainerTool";
            controlContainerTool9.ControlName = "Delete_Button";
            controlContainerTool9.SharedProps.Caption = "Delete_ControlContainerTool";
            controlContainerTool10.ControlName = "Modify_Button";
            controlContainerTool10.SharedProps.Caption = "Modify_ControlContainerTool";
            controlContainerTool11.ControlName = "Print_Button";
            controlContainerTool11.SharedProps.Caption = "Print_ControlContainerTool";
            labelTool2.SharedProps.Spring = true;
            controlContainerTool12.ControlName = "Details_Button";
            controlContainerTool12.SharedProps.Caption = "Details_ControlContainerTool";
            controlContainerTool12.SharedProps.Visible = false;
            this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            controlContainerTool7,
            controlContainerTool8,
            controlContainerTool9,
            controlContainerTool10,
            controlContainerTool11,
            labelTool2,
            controlContainerTool12});
            this.ultraToolbarsManager1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.ultraToolbarsManager1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // _PMKHN09760UG_Toolbars_Dock_Area_Left
            // 
            this._PMKHN09760UG_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN09760UG_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.GhostWhite;
            this._PMKHN09760UG_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._PMKHN09760UG_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN09760UG_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 29);
            this._PMKHN09760UG_Toolbars_Dock_Area_Left.Name = "_PMKHN09760UG_Toolbars_Dock_Area_Left";
            this._PMKHN09760UG_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 641);
            this._PMKHN09760UG_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _PMKHN09760UG_Toolbars_Dock_Area_Right
            // 
            this._PMKHN09760UG_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN09760UG_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.GhostWhite;
            this._PMKHN09760UG_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._PMKHN09760UG_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN09760UG_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(759, 29);
            this._PMKHN09760UG_Toolbars_Dock_Area_Right.Name = "_PMKHN09760UG_Toolbars_Dock_Area_Right";
            this._PMKHN09760UG_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 641);
            this._PMKHN09760UG_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _PMKHN09760UG_Toolbars_Dock_Area_Top
            // 
            this._PMKHN09760UG_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN09760UG_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.GhostWhite;
            this._PMKHN09760UG_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._PMKHN09760UG_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN09760UG_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._PMKHN09760UG_Toolbars_Dock_Area_Top.Name = "_PMKHN09760UG_Toolbars_Dock_Area_Top";
            this._PMKHN09760UG_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(759, 29);
            this._PMKHN09760UG_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _PMKHN09760UG_Toolbars_Dock_Area_Bottom
            // 
            this._PMKHN09760UG_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN09760UG_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.GhostWhite;
            this._PMKHN09760UG_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._PMKHN09760UG_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN09760UG_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 670);
            this._PMKHN09760UG_Toolbars_Dock_Area_Bottom.Name = "_PMKHN09760UG_Toolbars_Dock_Area_Bottom";
            this._PMKHN09760UG_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(759, 0);
            this._PMKHN09760UG_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // ultraDockManager1
            // 
            this.ultraDockManager1.CaptionStyle = Infragistics.Win.UltraWinDock.CaptionStyle.Office2003;
            this.ultraDockManager1.CompressUnpinnedTabs = false;
            dockAreaPane1.ChildPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.VerticalSplit;
            dockAreaPane1.DockedBefore = new System.Guid("910ab0a9-825a-4a8f-8bd5-7b834d1fed89");
            dockAreaPane1.FloatingLocation = new System.Drawing.Point(-689, -91);
            dockableControlPane1.Control = this.First_Panel;
            dockableControlPane1.FlyoutSize = new System.Drawing.Size(271, -1);
            dockableControlPane1.Key = "First_Panel";
            dockableControlPane1.MinimumSize = new System.Drawing.Size(10, 0);
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(0, 27, 389, 643);
            dockableControlPane1.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane1.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane1.Settings.AllowPin = Infragistics.Win.DefaultableBoolean.False;
            appearance35.FontData.SizeInPoints = 9F;
            dockableControlPane1.Settings.Appearance = appearance35;
            dockableControlPane1.Settings.DoubleClickAction = Infragistics.Win.UltraWinDock.PaneDoubleClickAction.ToggleDockedState;
            dockableControlPane1.Size = new System.Drawing.Size(250, 640);
            dockableControlPane1.Text = "First_Panel";
            dockableControlPane2.Control = this.Second_Panel;
            dockableControlPane2.Key = "Second_Panel";
            dockableControlPane2.MinimumSize = new System.Drawing.Size(10, 0);
            dockableControlPane2.OriginalControlBounds = new System.Drawing.Rectangle(460, 27, 370, 643);
            dockableControlPane2.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane2.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane2.Settings.AllowPin = Infragistics.Win.DefaultableBoolean.False;
            appearance36.FontData.SizeInPoints = 9F;
            dockableControlPane2.Settings.Appearance = appearance36;
            dockableControlPane2.Settings.DoubleClickAction = Infragistics.Win.UltraWinDock.PaneDoubleClickAction.ToggleDockedState;
            dockableControlPane2.Size = new System.Drawing.Size(249, 640);
            dockableControlPane2.Text = "Second_Panel";
            dockableControlPane3.Control = this.Third_Panel;
            dockableControlPane3.Key = "Third_Panel";
            dockableControlPane3.MinimumSize = new System.Drawing.Size(10, 0);
            dockableControlPane3.OriginalControlBounds = new System.Drawing.Rectangle(430, 50, 95, 614);
            dockableControlPane3.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane3.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            dockableControlPane3.Settings.AllowPin = Infragistics.Win.DefaultableBoolean.False;
            appearance37.FontData.SizeInPoints = 9F;
            dockableControlPane3.Settings.Appearance = appearance37;
            dockableControlPane3.Settings.DoubleClickAction = Infragistics.Win.UltraWinDock.PaneDoubleClickAction.ToggleDockedState;
            dockableControlPane3.Size = new System.Drawing.Size(248, 640);
            dockableControlPane3.Text = "Third_Panel";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1,
            dockableControlPane2,
            dockableControlPane3});
            dockAreaPane1.SelectedTabIndex = 2;
            dockAreaPane1.Size = new System.Drawing.Size(759, 640);
            dockAreaPane1.UnfilledSize = new System.Drawing.Size(261, 0);
            dockAreaPane2.ChildPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.VerticalSplit;
            dockAreaPane2.DockedBefore = new System.Guid("8e0faff9-49b4-4a17-a1a4-a5967bceea66");
            dockAreaPane2.FloatingLocation = new System.Drawing.Point(-689, -91);
            dockAreaPane2.Size = new System.Drawing.Size(261, 640);
            dockAreaPane2.UnfilledSize = new System.Drawing.Size(759, 640);
            dockAreaPane3.ChildPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.VerticalSplit;
            dockAreaPane3.FloatingLocation = new System.Drawing.Point(-418, -21);
            dockAreaPane3.Size = new System.Drawing.Size(188, 619);
            dockAreaPane3.UnfilledSize = new System.Drawing.Size(255, 640);
            this.ultraDockManager1.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1,
            dockAreaPane2,
            dockAreaPane3});
            this.ultraDockManager1.HostControl = this;
            this.ultraDockManager1.HotTracking = false;
            this.ultraDockManager1.LayoutStyle = Infragistics.Win.UltraWinDock.DockAreaLayoutStyle.FillContainer;
            this.ultraDockManager1.ShowCloseButton = false;
            this.ultraDockManager1.ShowDisabledButtons = false;
            this.ultraDockManager1.ShowMaximizeButton = true;
            this.ultraDockManager1.ShowMenuButton = Infragistics.Win.DefaultableBoolean.False;
            appearance38.FontData.SizeInPoints = 9F;
            this.ultraDockManager1.UnpinnedTabAreaAppearance = appearance38;
            this.ultraDockManager1.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2003;
            // 
            // _PMKHN09760UGUnpinnedTabAreaLeft
            // 
            this._PMKHN09760UGUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._PMKHN09760UGUnpinnedTabAreaLeft.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._PMKHN09760UGUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 29);
            this._PMKHN09760UGUnpinnedTabAreaLeft.Name = "_PMKHN09760UGUnpinnedTabAreaLeft";
            this._PMKHN09760UGUnpinnedTabAreaLeft.Owner = this.ultraDockManager1;
            this._PMKHN09760UGUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 641);
            this._PMKHN09760UGUnpinnedTabAreaLeft.TabIndex = 10;
            // 
            // _PMKHN09760UGUnpinnedTabAreaRight
            // 
            this._PMKHN09760UGUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._PMKHN09760UGUnpinnedTabAreaRight.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._PMKHN09760UGUnpinnedTabAreaRight.Location = new System.Drawing.Point(759, 29);
            this._PMKHN09760UGUnpinnedTabAreaRight.Name = "_PMKHN09760UGUnpinnedTabAreaRight";
            this._PMKHN09760UGUnpinnedTabAreaRight.Owner = this.ultraDockManager1;
            this._PMKHN09760UGUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 641);
            this._PMKHN09760UGUnpinnedTabAreaRight.TabIndex = 11;
            // 
            // _PMKHN09760UGUnpinnedTabAreaTop
            // 
            this._PMKHN09760UGUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._PMKHN09760UGUnpinnedTabAreaTop.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._PMKHN09760UGUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 29);
            this._PMKHN09760UGUnpinnedTabAreaTop.Name = "_PMKHN09760UGUnpinnedTabAreaTop";
            this._PMKHN09760UGUnpinnedTabAreaTop.Owner = this.ultraDockManager1;
            this._PMKHN09760UGUnpinnedTabAreaTop.Size = new System.Drawing.Size(759, 0);
            this._PMKHN09760UGUnpinnedTabAreaTop.TabIndex = 12;
            // 
            // _PMKHN09760UGUnpinnedTabAreaBottom
            // 
            this._PMKHN09760UGUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._PMKHN09760UGUnpinnedTabAreaBottom.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._PMKHN09760UGUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 670);
            this._PMKHN09760UGUnpinnedTabAreaBottom.Name = "_PMKHN09760UGUnpinnedTabAreaBottom";
            this._PMKHN09760UGUnpinnedTabAreaBottom.Owner = this.ultraDockManager1;
            this._PMKHN09760UGUnpinnedTabAreaBottom.Size = new System.Drawing.Size(759, 0);
            this._PMKHN09760UGUnpinnedTabAreaBottom.TabIndex = 13;
            // 
            // _PMKHN09760UGAutoHideControl
            // 
            this._PMKHN09760UGAutoHideControl.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._PMKHN09760UGAutoHideControl.Location = new System.Drawing.Point(22, 30);
            this._PMKHN09760UGAutoHideControl.Name = "_PMKHN09760UGAutoHideControl";
            this._PMKHN09760UGAutoHideControl.Owner = this.ultraDockManager1;
            this._PMKHN09760UGAutoHideControl.Size = new System.Drawing.Size(276, 640);
            this._PMKHN09760UGAutoHideControl.TabIndex = 14;
            // 
            // dockableWindow1
            // 
            this.dockableWindow1.Controls.Add(this.First_Panel);
            this.dockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.dockableWindow1.Name = "dockableWindow1";
            this.dockableWindow1.Owner = this.ultraDockManager1;
            this.dockableWindow1.Size = new System.Drawing.Size(251, 641);
            this.dockableWindow1.TabIndex = 19;
            // 
            // dockableWindow2
            // 
            this.dockableWindow2.Controls.Add(this.Second_Panel);
            this.dockableWindow2.Location = new System.Drawing.Point(256, 0);
            this.dockableWindow2.Name = "dockableWindow2";
            this.dockableWindow2.Owner = this.ultraDockManager1;
            this.dockableWindow2.Size = new System.Drawing.Size(250, 641);
            this.dockableWindow2.TabIndex = 20;
            // 
            // dockableWindow3
            // 
            this.dockableWindow3.Controls.Add(this.Third_Panel);
            this.dockableWindow3.Location = new System.Drawing.Point(511, 0);
            this.dockableWindow3.Name = "dockableWindow3";
            this.dockableWindow3.Owner = this.ultraDockManager1;
            this.dockableWindow3.Size = new System.Drawing.Size(248, 641);
            this.dockableWindow3.TabIndex = 21;
            // 
            // windowDockingArea5
            // 
            this.windowDockingArea5.Controls.Add(this.dockableWindow2);
            this.windowDockingArea5.Controls.Add(this.dockableWindow1);
            this.windowDockingArea5.Controls.Add(this.dockableWindow3);
            this.windowDockingArea5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowDockingArea5.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.windowDockingArea5.Location = new System.Drawing.Point(0, 29);
            this.windowDockingArea5.Name = "windowDockingArea5";
            this.windowDockingArea5.Owner = this.ultraDockManager1;
            this.windowDockingArea5.Size = new System.Drawing.Size(759, 641);
            this.windowDockingArea5.TabIndex = 0;
            // 
            // windowDockingArea2
            // 
            this.windowDockingArea2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowDockingArea2.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.windowDockingArea2.Location = new System.Drawing.Point(4, 4);
            this.windowDockingArea2.Name = "windowDockingArea2";
            this.windowDockingArea2.Owner = this.ultraDockManager1;
            this.windowDockingArea2.Size = new System.Drawing.Size(261, 640);
            this.windowDockingArea2.TabIndex = 0;
            // 
            // windowDockingArea1
            // 
            this.windowDockingArea1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowDockingArea1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.windowDockingArea1.Location = new System.Drawing.Point(504, 30);
            this.windowDockingArea1.Name = "windowDockingArea1";
            this.windowDockingArea1.Owner = this.ultraDockManager1;
            this.windowDockingArea1.Size = new System.Drawing.Size(188, 619);
            this.windowDockingArea1.TabIndex = 41;
            // 
            // PMKHN09760UG
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(759, 670);
            this.Controls.Add(this._PMKHN09760UGAutoHideControl);
            this.Controls.Add(this.ViewButtonPanel);
            this.Controls.Add(this.windowDockingArea5);
            this.Controls.Add(this._PMKHN09760UGUnpinnedTabAreaTop);
            this.Controls.Add(this._PMKHN09760UGUnpinnedTabAreaBottom);
            this.Controls.Add(this._PMKHN09760UGUnpinnedTabAreaLeft);
            this.Controls.Add(this._PMKHN09760UGUnpinnedTabAreaRight);
            this.Controls.Add(this._PMKHN09760UG_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._PMKHN09760UG_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._PMKHN09760UG_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._PMKHN09760UG_Toolbars_Dock_Area_Bottom);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PMKHN09760UG";
            this.Load += new System.EventHandler(this.PMKHN09760UG_Load);
            this.First_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.First_Grid)).EndInit();
            this.First_StatusBar.ResumeLayout(false);
            this.Second_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Second_Grid)).EndInit();
            this.Second_StatusBar.ResumeLayout(false);
            this.Third_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Third_Grid)).EndInit();
            this.Third_StatusBar.ResumeLayout(false);
            this.ViewButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDockManager1)).EndInit();
            this.dockableWindow1.ResumeLayout(false);
            this.dockableWindow2.ResumeLayout(false);
            this.dockableWindow3.ResumeLayout(false);
            this.windowDockingArea5.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region Private Members
		private bool _underExtractionFlg = false;
		private bool _nextSearchFlg = false;
		private bool _detailFlg = false;

		private string[] _tableNameList = new string[3];
		private string[] _gridTitleList = new string[3];
		private int[] _dataIndexList = new int[3];
		private bool[] _canLogicalDeleteDataExtractionList = new bool[3];
		private bool[] _defaultAutoFillToGridColumnList = new bool[3];
		private Image[] _gridIconList = new Image[3];
		private Hashtable[] _appearanceTable = new Hashtable[3];

		private PMKHN09760UA _owningForm;
		private ProgramItem _programItemObj;
		private IMasterMaintenanceThreeArrayType _threeArrayTypeObj;
		private ExtractionSetUpType _extractionSetUpType;
		private TargetData _targetData;

        private const int FIRST_INDEX = 0;
		private const int SECOND_INDEX = 1;
		private const int THIRD_INDEX = 2;

        private bool _synchroLogDelFlg = true;
        
        /// <summary>����c�[���{�^���̃L�[</summary>
        private const string CLOSE_TOOL_BUTTON_KEY = "Close_ControlContainerTool";
        /// <summary>�V�K�c�[���{�^���̃L�[</summary>
        private const string NEW_TOOL_BUTTON_KEY = "New_ControlContainerTool";
        /// <summary>�폜�c�[���{�^���̃L�[</summary>
        private const string DELETE_TOOL_BUTTON_KEY = "Delete_ControlContainerTool";
        /// <summary>�C���c�[���{�^���̃L�[</summary>
        private const string MODIFY_TOOL_BUTTON_KEY = "Modify_ControlContainerTool";
        /// <summary>����c�[���{�^���̃L�[</summary>
        private const string PRINT_TOOL_BUTTON_KEY = "Print_ControlContainerTool";

        #region <IOperationAuthorityControllable �����o/>

        /// <see cref="IOperationAuthorityControllable"/>
        public OperationAuthorityController OperationController
        {
            get { return _operationController; }
            set { _operationController = value; }
        }

        #endregion  // <IOperationAuthorityControllable �����o/>

        /// <summary>���쌠���̐���I�u�W�F�N�g</summary>
        private OperationAuthorityController _operationController;
        /// <summary>
        /// ���쌠���̐���I�u�W�F�N�g���擾���܂��B
        /// </summary>
        /// <value>���쌠���̐���I�u�W�F�N�g</value>
        /// <exception cref="InvalidCastException">���쌠���̐���I�u�W�F�N�g�̌^�������Ă��܂���</exception>
        protected MasMainController MyOpeCtrl
        {
            get { return (MasMainController)_operationController; }
        }

        #endregion

		# region enum TargetData
		/// <summary>����Ώۃf�[�^�̗񋓌^�ł��B</summary>
		private enum TargetData: int
		{
			/// <summary>�P�K�w��</summary>
			First = 0,

			/// <summary>�Q�K�w��</summary>
			Second = 1,

			/// <summary>�R�K�w��</summary>
			Third = 2
		}
		# endregion

		# region Properties
		/// <summary>���o�Ώی����v���p�e�B</summary>
		/// <value>���o�Ώی������擾�܂��͐ݒ肵�܂��B</value>
		internal int SearchCount
		{
			get{ return 0; }
			set{ }
		}

		/// <summary>
		/// 
		/// </summary>
		internal ProgramItem ProgramItemObj
		{
			get{ return this._programItemObj; }
			set{ this._programItemObj = value; }
		}

		# endregion

		# region Internal Methods
		/// <summary>
		/// ��ʕ\������
		/// </summary>
		/// <param name="owningForm">�e�t�H�[���̃C���X�^���X</param>
		/// <param name="programItemObj">�v���O�������Ǘ��N���X�̃C���X�^���X</param>
		/// <remarks>
		/// <br>Note       : �e�t�H�[���̃C���X�^���X���󂯎��A���g�̃t�H�[�������[�h���X�ŕ\�����܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		internal void ShowMe(PMKHN09760UA owningForm, ProgramItem programItemObj)
		{
			this._owningForm = owningForm;
			this._programItemObj = programItemObj;
			this._threeArrayTypeObj = (IMasterMaintenanceThreeArrayType)programItemObj.CustomForm;

            if (programItemObj.CustomForm is ISynchroLogDelChkBox)
            {
                // �}�X�������ŃC���^�[�t�F�[�X�̎����L
                this._synchroLogDelFlg = ((ISynchroLogDelChkBox)programItemObj.CustomForm).SynchroLogDelFlg;
            }
            else
            {
                // �}�X�������ŃC���^�[�t�F�[�X�̎�����
                this._synchroLogDelFlg = true;  // MOD 2008/03/25 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� false��true
            }
        
            this.Show();
		}

		/// <summary>
		/// �O���b�h��^�C�g�����X�g�擾����
		/// </summary>
		/// <param name="dataList">�f�[�^���ڃ��X�g</param>
		/// <param name="colList1">��P�O���b�h��^�C�g�����X�g</param>
		/// <param name="colList2">��Q�O���b�h��^�C�g�����X�g</param>
		/// <param name="colList3">��R�O���b�h��^�C�g�����X�g</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : �ꗗ�\���p�O���b�h�ɕ\������Ă����̃^�C�g��(Key)��
		///					 ArrayList�Ɋi�[���ĕԂ��܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		internal void GetColKeyList(out ArrayList dataList, out ArrayList colList1, out ArrayList colList2, out ArrayList colList3)
		{
			dataList = new ArrayList();
			colList1 = new ArrayList();
			colList2 = new ArrayList();
			colList3 = new ArrayList();

			dataList.Add(this._gridTitleList[FIRST_INDEX]);
			dataList.Add(this._gridTitleList[SECOND_INDEX]);
			dataList.Add(this._gridTitleList[THIRD_INDEX]);

			for (int i = 0; i < this.First_Grid.DisplayLayout.Bands[0].Columns.Count; i++)
			{
				if (this.First_Grid.DisplayLayout.Bands[0].Columns[i].Hidden == false)
				{
					colList1.Add(this.First_Grid.DisplayLayout.Bands[0].Columns[i].Key.ToString());
				}
			}

			for (int i = 0; i < this.Second_Grid.DisplayLayout.Bands[0].Columns.Count; i++)
			{
				if (this.Second_Grid.DisplayLayout.Bands[0].Columns[i].Hidden == false)
				{
					colList2.Add(this.Second_Grid.DisplayLayout.Bands[0].Columns[i].Key.ToString());
				}
			}

			for (int i = 0; i < this.Third_Grid.DisplayLayout.Bands[0].Columns.Count; i++)
			{
				if (this.Third_Grid.DisplayLayout.Bands[0].Columns[i].Hidden == false)
				{
					colList3.Add(this.Third_Grid.DisplayLayout.Bands[0].Columns[i].Key.ToString());
				}
			}
		}

		/// <summary>
		/// �O���b�h�e�L�X�g��������
		/// </summary>
		/// <param name="columnKey">�O���b�h�̌����Ώۗ񖼏�</param>
		/// <param name="searchString">����������</param>
		/// <param name="targetName">�ΏۃO���b�h����</param>
		/// <remarks>
		/// <br>Note       : ������columnKey�ƈ�v���錟���Ώۗ���������A
		///					 ����������(searchString)�Ɉ�v����s�����݂���
		///					 �ꍇ�͂��̍s���A�N�e�B�u�ɂ��܂��B
		///					 ������columnKey�ƈ�v����񂪑��݂��Ȃ��ꍇ�́A
		///					 �S�Ă̗�������ΏۂƂ��܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		internal void GridTextSearch(string columnKey, string searchString, string targetName)
		{
			this.Cursor = Cursors.WaitCursor;
			bool checkFlg = false;
			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid;

			if (this._gridTitleList[FIRST_INDEX] == targetName)
			{
				targetGrid = this.First_Grid;
			}
			else if (this._gridTitleList[SECOND_INDEX] == targetName)
			{
				targetGrid = this.Second_Grid;
			}
			else
			{
				targetGrid = this.Third_Grid;
			}

			// ���ɃA�N�e�B�u�s�����݂���ꍇ�͂��̍s����A�����łȂ��ꍇ��
			// �ŏ��̍s���A�N�e�B�u�ɐݒ肵�A�������J�n����
			Infragistics.Win.UltraWinGrid.UltraGridRow oRow = targetGrid.ActiveRow;
			if (oRow == null)
			{
				oRow = targetGrid.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.First);
			}

			// Row�I�u�W�F�N�g��GetSibling ���\�b�h���g�p���Ċe�s���J��Ԃ�
			// �`�F�b�N���A�Y���s������������
			while (oRow != null)
			{
				oRow = oRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next);

				if (this.MatchText(oRow, columnKey, searchString, targetGrid))
				{
					targetGrid.ActiveRow = oRow;
					targetGrid.ActiveRow.Selected = true;
					targetGrid.Refresh();

					checkFlg = true;
					break;
				}
			}

			if (!checkFlg)
			{
				oRow = targetGrid.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.First);

				// ���g���C
				while (oRow != null)
				{
					if (this.MatchText(oRow, columnKey, searchString, targetGrid))
					{
						targetGrid.ActiveRow = oRow;
						targetGrid.ActiveRow.Selected = true;
						targetGrid.Refresh();

						checkFlg = true;
						break;
					}

					oRow = oRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next);
				}
			}

			this.Cursor = Cursors.Default;

			if (!checkFlg)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"���������Ɉ�v����f�[�^�͌�����܂���B",
					0,
					MessageBoxButtons.OK);
			}
		}

		/// <summary>
		/// ��ʏI������
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ��I�������܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		internal void ViewFormClose()
		{
			Close_Button_Click(this, null);
		}
		# endregion

		# region Private Methods
		/// <summary>
		/// ��ʏ�������
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʋN�����̏����������s���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void InitialDisplay()
		{
			// �{�^����Tag��ݒ肷��iTag�̓{�^���N���b�N�����̗L�������������܂��j
			this.Close_Button.Tag   = true;
			this.New_Button.Tag     = true;
			this.Delete_Button.Tag  = true;
			this.Modify_Button.Tag  = true;
			this.Print_Button.Tag   = true;
			this.Delete_Button.Tag  = true;
			this.Details_Button.Tag = true;

			// �A�C�R����\������
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Close_Button.ImageList   = imageList16;
			this.New_Button.ImageList     = imageList16;
			this.Delete_Button.ImageList  = imageList16;
			this.Modify_Button.ImageList  = imageList16;
			this.Print_Button.ImageList   = imageList16;
			this.Details_Button.ImageList = imageList16;

			this.Close_Button.Appearance.Image   = Size16_Index.CLOSE;
			this.New_Button.Appearance.Image     = Size16_Index.NEW;
			this.Delete_Button.Appearance.Image  = Size16_Index.DELETE;
			this.Modify_Button.Appearance.Image  = Size16_Index.MODIFY;
			this.Print_Button.Appearance.Image   = Size16_Index.PRINT;
			this.Details_Button.Appearance.Image = Size16_Index.DETAILS;

			// ���o������ݒ肷��
			MasterMaintenanceConstruction mmc = this._owningForm.GetConstructionTable(this._programItemObj.ClassID);
			this._extractionSetUpType = mmc.ExSetUpType;
			this.SearchCount = mmc.SearchCount;

			// �e�}�X�^�����e�i���X�I�u�W�F�N�g���ݒ�l���擾����
			this._canLogicalDeleteDataExtractionList = this._threeArrayTypeObj.GetCanLogicalDeleteDataExtractionList();
			this._gridTitleList                      = this._threeArrayTypeObj.GetGridTitleList();
			this._gridIconList                       = this._threeArrayTypeObj.GetGridIconList();
			this._defaultAutoFillToGridColumnList    = this._threeArrayTypeObj.GetDefaultAutoFillToGridColumnList();

			this.New_Button.Visible    = this._threeArrayTypeObj.CanNew;
			this.Delete_Button.Visible = this._threeArrayTypeObj.CanDelete;
			this.Print_Button.Visible  = this._threeArrayTypeObj.CanPrint;
			this.ultraToolbarsManager1.Tools["New_ControlContainerTool"].SharedProps.Visible      = this._threeArrayTypeObj.CanNew;
			this.ultraToolbarsManager1.Tools["Delete_ControlContainerTool"].SharedProps.Visible   = this._threeArrayTypeObj.CanDelete;
			this.ultraToolbarsManager1.Tools["Print_ControlContainerTool"].SharedProps.Visible    = this._threeArrayTypeObj.CanPrint;
			this.First_StatusBar.Panels["FirstLogicalDeleteDataExtraction_StatusPanel"].Visible   = this._canLogicalDeleteDataExtractionList[FIRST_INDEX];
			this.First_StatusBar.Panels["Line1_StatusPanel"].Visible                              = this._canLogicalDeleteDataExtractionList[FIRST_INDEX];
			this.Second_StatusBar.Panels["SecondLogicalDeleteDataExtraction_StatusPanel"].Visible = this._canLogicalDeleteDataExtractionList[SECOND_INDEX];
			this.Second_StatusBar.Panels["Line1_StatusPanel"].Visible                             = this._canLogicalDeleteDataExtractionList[SECOND_INDEX];
			this.Third_StatusBar.Panels["ThirdLogicalDeleteDataExtraction_StatusPanel"].Visible   = this._canLogicalDeleteDataExtractionList[THIRD_INDEX];
			this.Third_StatusBar.Panels["Line1_StatusPanel"].Visible                              = this._canLogicalDeleteDataExtractionList[THIRD_INDEX];
			this.ultraDockManager1.DockAreas[0].Panes["First_Panel"].Text                         = this._gridTitleList[FIRST_INDEX];
			this.ultraDockManager1.DockAreas[0].Panes["Second_Panel"].Text                        = this._gridTitleList[SECOND_INDEX];
			this.ultraDockManager1.DockAreas[0].Panes["Third_Panel"].Text                         = this._gridTitleList[THIRD_INDEX];
			this.ultraDockManager1.ControlPanes["First_Panel"].Settings.Appearance.Image          = this._gridIconList[FIRST_INDEX];
			this.ultraDockManager1.ControlPanes["Second_Panel"].Settings.Appearance.Image         = this._gridIconList[SECOND_INDEX];
			this.ultraDockManager1.ControlPanes["Third_Panel"].Settings.Appearance.Image          = this._gridIconList[THIRD_INDEX];

			// �C�x���g�Ƀ��\�b�h��o�^����
			this._threeArrayTypeObj.UnDisplaying += new MasterMaintenanceThreeArrayTypeUnDisplayingEventHandler(MasterMaintenance_UnDisplaying);
			((Form)this._threeArrayTypeObj).VisibleChanged +=new EventHandler(this.PMKHN09760UG_VisibleChanged);

			// �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾����			
			DataSet bindDataSet = new DataSet();
			this._threeArrayTypeObj.GetBindDataSet(ref bindDataSet, ref this._tableNameList);
			this.Bind_DataSet = bindDataSet;
		}

		/// <summary>
		/// �f�[�^�r���[�p�O���b�h�����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : �O���b�h�̏����ݒ���s���܂��B
		///					 �i�\����\���A�\�����ʒu�A�t�H�[�}�b�g�A�t�H���g�F�A�t�B���^�j</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void GridInitialSetting()
		{
			for (int index = 0; index < this._appearanceTable.Length; index++)
			{
				Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = null;
				TargetData targetData = TargetData.First;

				switch (index)
				{
					case FIRST_INDEX:
					{
						targetGrid = this.First_Grid;
						targetData = TargetData.First;
						break;
					}
					case SECOND_INDEX:
					{
						targetGrid = this.Second_Grid;
						targetData = TargetData.Second;
						break;
					}
					case THIRD_INDEX:
					{
						targetGrid = this.Third_Grid;
						targetData = TargetData.Third;
						break;
					}
					default:
					{
						return;
					}
				}

				for (int i = 0; i < this.Bind_DataSet.Tables[this._tableNameList[index]].Columns.Count; i++)
				{
					GridColAppearance appearance = (GridColAppearance)this._appearanceTable[index][this.Bind_DataSet.Tables[this._tableNameList[index]].Columns[i].ColumnName];
				
					// �O���b�h��̕\����\���ݒ菈��
					this.GridColHidden(i, appearance.GridColDispType, targetData);

					// �l�̕\�����ʒu��ݒ肷��
					switch (appearance.CellTextAlign)
					{
						case ContentAlignment.TopLeft:
						case ContentAlignment.MiddleLeft:
						case ContentAlignment.BottomLeft:
						{
							targetGrid.DisplayLayout.Bands[0].Columns[i].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
							break;
						}
						case ContentAlignment.TopCenter:
						case ContentAlignment.MiddleCenter:
						case ContentAlignment.BottomCenter:
						{
							targetGrid.DisplayLayout.Bands[0].Columns[i].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
							break;
						}
						case ContentAlignment.TopRight:
						case ContentAlignment.MiddleRight:
						case ContentAlignment.BottomRight:
						{
							targetGrid.DisplayLayout.Bands[0].Columns[i].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
							break;
						}
					}

					// �l�̃t�H�[�}�b�g��ݒ肷��
					if ((appearance.Format != "") && (appearance.Format != null))
					{
						targetGrid.DisplayLayout.Bands[0].Columns[i].Format = appearance.Format;
					}

					// ��̃t�H���g�F��ݒ肷��
					targetGrid.DisplayLayout.Bands[0].Columns[i].CellAppearance.ForeColor = appearance.ColFontColor;

					// �O���b�h�̃t�B���^�����O����
					AddGridFiltering(targetData);
				}
			}
		}

		/// <summary>
		/// �O���b�h��̕\����\���ݒ菈��
		/// </summary>
		/// <param name="index">�O���b�h��̃C���f�b�N�X</param>
		/// <param name="colDispType">�O���b�h��^�C�v</param>
		/// <param name="targetData">����ΏۃO���b�h</param>
		/// <remarks>
		/// <br>Note       : �O���b�h��̕\����\���ݒ���s���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void GridColHidden(int index, MGridColDispType colDispType, TargetData targetData)
		{
			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = null;
			Infragistics.Win.UltraWinEditors.UltraCheckEditor targetCheckEditor = null;

			switch (targetData)
			{
				case (TargetData.First):
				{
					targetGrid = this.First_Grid;
					targetCheckEditor = this.FirstLogicalDeleteDataExtraction_CheckEditor;
					break;
				}
				case (TargetData.Second):
				{
					targetGrid = this.Second_Grid;
					targetCheckEditor = this.SecondLogicalDeleteDataExtraction_CheckEditor;
					break;
				}
				case (TargetData.Third):
				{
					targetGrid = this.Third_Grid;
					targetCheckEditor = this.ThirdLogicalDeleteDataExtraction_CheckEditor;
					break;
				}
			}

			switch (colDispType)
			{
				case MGridColDispType.None:
				{
					targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
					break;
				}
				case MGridColDispType.Both:
				{
					targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = false;
					break;
				}
				case MGridColDispType.ListOnly:
				{
					targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = false;
					break;
				}
				case MGridColDispType.DetailsOnly:
				{
					if (this._detailFlg == true)
					{
						targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = false;
					}
					else
					{
						targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
					}
					break;
				}
				case MGridColDispType.DeletionDataBoth:
				{
					if (targetCheckEditor.Checked == true)
					{
						targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = false;
					}
					else
					{
						targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
					}
					break;
				}
				case MGridColDispType.DeletionDataListOnly:
				{
					if (targetCheckEditor.Checked == true)
					{
						targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = false;
					}
					else
					{
						targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
					}
					break;
				}
				case MGridColDispType.DeletionDataDetailsOnly:
				{
					if (targetCheckEditor.Checked == true)
					{
						if (this._detailFlg == true)
						{
							targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = false;
						}
						else
						{
							targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
						}
					}
					else
					{
						targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
					}
					break;
				}
				default:
				{
					targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
					break;
				}
			}
		}

		/// <summary>
		/// �O���b�h�̃t�B���^�����O����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �O���b�h��̃t�B���^�����O���s���܂��B
		///					 �����N�����ɁA�폜�f�[�^���t�B���^�����O���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void AddGridFiltering(TargetData targetData)
		{
			int index = -1;
			string tableName = "";
			Hashtable appearanceTable;
			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = null;
			Infragistics.Win.UltraWinEditors.UltraCheckEditor targetCheckEditor = null;
			
			switch (targetData)
			{
				case TargetData.First:
				{
					tableName = this._tableNameList[FIRST_INDEX];
					targetGrid = this.First_Grid;
					appearanceTable = this._appearanceTable[FIRST_INDEX];
					targetCheckEditor = this.FirstLogicalDeleteDataExtraction_CheckEditor;

					break;
				}
				case TargetData.Second:
				{
					tableName = this._tableNameList[SECOND_INDEX];
					targetGrid = this.Second_Grid;
					appearanceTable = this._appearanceTable[SECOND_INDEX];
					targetCheckEditor = this.SecondLogicalDeleteDataExtraction_CheckEditor;

					break;
				}
				case TargetData.Third:
				{
					tableName = this._tableNameList[THIRD_INDEX];
					targetGrid = this.Third_Grid;
					appearanceTable = this._appearanceTable[THIRD_INDEX];
					targetCheckEditor = this.ThirdLogicalDeleteDataExtraction_CheckEditor;

					break;
				}
				default:
				{
					return;
				}
			}

			for (int i = 0; i < this.Bind_DataSet.Tables[tableName].Columns.Count; i++)
			{
				GridColAppearance appearance = (GridColAppearance)appearanceTable[this.Bind_DataSet.Tables[tableName].Columns[i].ColumnName];

				if ((appearance.GridColDispType == MGridColDispType.DeletionDataBoth) ||
					(appearance.GridColDispType == MGridColDispType.DeletionDataListOnly) ||
					(appearance.GridColDispType == MGridColDispType.DeletionDataDetailsOnly))
				{
					index = i;
					break;
				}
			}	

			if (index >= 0)
			{
				// �s�t�B���^���o���h�Ɋ�Â��Ă���ꍇ�A�o���h�̗�t�B���^���O���B
				Infragistics.Win.UltraWinGrid.ColumnFiltersCollection columnFilters = targetGrid.DisplayLayout.Bands[0].ColumnFilters;
				columnFilters.ClearAllFilters();

				if (targetCheckEditor.Checked == false)
				{
					// �󔒂�Null�ȊO���t�B���^�ɐݒ肷��
					columnFilters[index].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, "");
					columnFilters[index].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, null);
					columnFilters[index].LogicalOperator = Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or;
				}
			}
		}

		/// <summary>
		/// �e�L�X�g��v�`�F�b�N����
		/// </summary>
		/// <param name="userString">����������</param>
		/// <param name="cellValue">�����ΏۃZ���l</param>
		/// <remarks>
		/// <br>Note       : �O���b�h�̃Z���l�ƈ�������v���邩�ǂ������`�F�b�N���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private bool Match(string userString, string cellValue)
		{
			// ������𗼕��Ƃ��啶���ɕϊ�����
			userString = userString.ToUpper();
			cellValue = cellValue.ToUpper();

			// �Z���l�������[�U�[���������񂪑傫���ꍇ�́A�s��v�Ȃ̂�
			// False��߂�
			if (userString.Length > cellValue.Length)
			{
				return false;
			}
			else if (userString.Length == cellValue.Length)
			{
				// ��������v����ꍇ�A���������v����
				if (userString == cellValue)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				for ( int i = 0; i <= (cellValue.Length - userString.Length); i++ )
				{
					if (userString == cellValue.Substring(i, userString.Length))
					{
						return true;
					}
				}

				return false;
			}
		}

		/// <summary>
		/// �e�L�X�g��v�s���݃`�F�b�N����
		/// </summary>
		/// <param name="oRow">�����ΏۃO���b�h�s</param>
		/// <param name="columnKey">�����ΏۃO���b�h��</param>
		/// <param name="searchString">����������</param>
		/// <param name="targetGrid">����ΏۃO���b�h</param>
		/// <remarks>
		/// <br>Note       : �����̍s�ɑ΂��āA�����Ώۗ�̃Z���̒l�ƈ�v����
		///					 ���ǂ������`�F�b�N���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private bool MatchText(Infragistics.Win.UltraWinGrid.UltraGridRow oRow, string columnKey, string searchString, Infragistics.Win.UltraWinGrid.UltraGrid targetGrid)
		{
			if (oRow == null)
			{
				return false;
			}

			// �I������Ă�������������̂��S�Ă̗����������̂����m�F����
			bool bSearchAllColumns = true;
			if (targetGrid.DisplayLayout.Bands[0].Columns.Exists(columnKey))
			{
				bSearchAllColumns = false;
			}

			// �S�Ă̗����������ꍇ�A�s�̑S�ẴZ��������������
			// ���̏ꍇBands.Columns�R���N�V�������g�p���A��������}��
			if (bSearchAllColumns)
			{
				foreach(Infragistics.Win.UltraWinGrid.UltraGridColumn oCol in targetGrid.DisplayLayout.Bands[0].Columns)
				{
					if (!oCol.IsVisibleInLayout) continue;

					if ((oRow.Cells[oCol.Key].Value != null) && (oRow.IsFilteredOut == false))
					{
						if (this.Match(searchString, oRow.Cells[oCol.Key].Value.ToString()))
						{
							return true;
						}
					}
				}
			}
			else
			{
				Infragistics.Win.UltraWinGrid.UltraGridColumn oCol = targetGrid.DisplayLayout.Bands[0].Columns[columnKey];
				if ((oRow.Cells[oCol.Key].Value != null ) && (oRow.IsFilteredOut == false))
				{
					if (this.Match(searchString, oRow.Cells[oCol.Key].Value.ToString()))
					{
						return true;
					}
				}
			}

			return false;
		}

		/// <summary>
		/// �X�e�[�^�X�o�[�����\������
		/// </summary>
		/// <remarks>
		/// <br>Note       : �X�e�[�^�X�o�[�ɃO���b�h�̍s����\�����܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void StatusBarCountIndication()
		{
			this.First_StatusBar.Panels["SearchCount_StatusPanel"].Text  = this.First_Grid.Rows.FilteredInRowCount.ToString()  + "��";
			this.Second_StatusBar.Panels["SearchCount_StatusPanel"].Text = this.Second_Grid.Rows.FilteredInRowCount.ToString() + "��";
			this.Third_StatusBar.Panels["SearchCount_StatusPanel"].Text  = this.Third_Grid.Rows.FilteredInRowCount.ToString()  + "��";
		}

		/// <summary>
		/// �O���b�h�A�N�e�B�u�s�ݒ菈��
		/// </summary>
		/// <param name="targetGrid">����Ώ�Grid</param>
		/// <remarks>
		/// <br>Note       : �O���b�h�̃A�N�e�B�u�s���������A�I����Ԃɂ��܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void SetActiveRow(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid)
		{
			if (targetGrid.ActiveRow != null)
			{
				bool setFlg = false;
				Infragistics.Win.UltraWinGrid.UltraGridRow nextRow = targetGrid.ActiveRow;
				while (nextRow != null)
				{
					if (nextRow.IsFilteredOut)
					{
						int index = nextRow.Index;

						// �I���s���t�B���^�����O����Ă���ꍇNext�s��I��
						nextRow = targetGrid.ActiveRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next);

						// �C���f�b�N�X�������ꍇ�́A�������݂��Ȃ��Ɣ��f����break;
						if ((nextRow != null) && (index == nextRow.Index))
						{
							break;
						}
					}
					else
					{
						targetGrid.ActiveRow = nextRow;
						targetGrid.ActiveRow.Selected = true;
						setFlg = true;
						break;
					}
				}

				if (setFlg == false)
				{
					// �Y������s�����݂��Ȃ��ꍇ�́A�ŏ�����ēxNext����
					nextRow = targetGrid.ActiveRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.First);
					while (nextRow != null)
					{
						if (nextRow.IsFilteredOut)
						{
							int index = nextRow.Index;

							// �I���s���t�B���^�����O����Ă���ꍇNext�s��I��
							nextRow = targetGrid.ActiveRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next);

							// �C���f�b�N�X�������ꍇ�́A�������݂��Ȃ��Ɣ��f����break;
							if ((nextRow != null) && (index == nextRow.Index))
							{
								break;
							}
						}
						else
						{
							targetGrid.ActiveRow = nextRow;
							targetGrid.ActiveRow.Selected = true;
							break;
						}
					}
				}
			}
			else if (targetGrid.Rows.Count > 0)
			{
				if (targetGrid.Rows[0] != null)
				{
					targetGrid.ActiveRow = targetGrid.Rows[0];
					targetGrid.ActiveRow.Selected = true;
				}
			}
		}

		/// <summary>
		/// ��ʔ�\���C�x���g�p���\�b�h
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="me">�C�x���g�p�����[�^�N���X</param>
		/// <remarks>
		/// <br>Note       : �}�X�^�����e�i���X�̉�ʔ�\���C�x���g�p���\�b�h�ł��B
		///					 �c���[�`�F�b�N�{�b�N�X�̃`�F�b�N���������s���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void MasterMaintenance_UnDisplaying(object sender, MasterMaintenanceUnDisplayingEventArgs me)
		{
			// ������DialogResult��OK�܂���Yes�̏ꍇ�́A�m�[�h�̃`�F�b�N�{�b�N�X��
			// �`�F�b�N��t����
			if ((me.DialogResult == DialogResult.OK) || (me.DialogResult == DialogResult.Yes))
			{
				this.StatusBarCountIndication();
				this._owningForm.TreeNodeCheckBoxChecked(this);
			}

			// �O���b�h�A�N�e�B�u�s�ݒ菈��
			this.SetActiveRow(this.First_Grid);

			// �O���b�h�A�N�e�B�u�s�ݒ菈��
			this.SetActiveRow(this.Second_Grid);

			// �O���b�h�A�N�e�B�u�s�ݒ菈��
			this.SetActiveRow(this.Third_Grid);
		}

		/// <summary>
		/// ��ʕ\���ύX�㔭���C�x���g�p���\�b�h
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		/// <remarks>
		/// <br>Note       : �q��ʂ�Visible���ύX�ɂȂ�����ɔ������܂��B
		///					 �{�^���̗L�������`�F�b�N���s���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void PMKHN09760UG_VisibleChanged(object sender, EventArgs e)
		{
			if (((Form)this._threeArrayTypeObj).Visible == true)
			{
				this.Close_Button.Enabled   = false;
				this.New_Button.Enabled     = false;
				this.Delete_Button.Enabled  = false;
				this.Modify_Button.Enabled  = false;
				this.Print_Button.Enabled   = false;
				this.Delete_Button.Enabled  = false;
				this.Details_Button.Enabled = false;
			}
			else
			{
				this.Close_Button.Enabled   = true;
				this.New_Button.Enabled     = true;
				this.Delete_Button.Enabled  = true;
				this.Modify_Button.Enabled  = true;
				this.Print_Button.Enabled   = true;
				this.Delete_Button.Enabled  = true;
				this.Details_Button.Enabled = true;

				this.ButtonEnabledControl(this._targetData);
			}
		}

		/// <summary>
		/// �{�^���L���������䏈��
		/// </summary>
		/// <param name="targetData">����ΏۃO���b�h</param>
		/// <remarks>
		/// <br>Note       : �{�^���̗L������������s���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void ButtonEnabledControl(TargetData targetData)
		{
			bool[] newEnabled = this._threeArrayTypeObj.GetNewButtonEnabledList();
			bool[] modifyEnabled = this._threeArrayTypeObj.GetModifyButtonEnabledList();
			bool[] deleteEnabled = this._threeArrayTypeObj.GetDeleteButtonEnabledList();

			switch(targetData)
			{
				case (TargetData.First):
				{
					this.New_Button.Enabled = newEnabled[FIRST_INDEX];
					this.Modify_Button.Enabled = modifyEnabled[FIRST_INDEX];
					this.Delete_Button.Enabled = deleteEnabled[FIRST_INDEX];
					break;
				}
				case (TargetData.Second):
				{
					this.New_Button.Enabled = newEnabled[SECOND_INDEX];
					this.Modify_Button.Enabled = modifyEnabled[SECOND_INDEX];
					this.Delete_Button.Enabled = deleteEnabled[SECOND_INDEX];
					break;
				}
				case (TargetData.Third):
				{
					this.New_Button.Enabled = newEnabled[THIRD_INDEX];
					this.Modify_Button.Enabled = modifyEnabled[THIRD_INDEX];
					this.Delete_Button.Enabled = deleteEnabled[THIRD_INDEX];
					break;
				}
			}

			this.New_Button.Tag     = this.New_Button.Enabled;
			this.Modify_Button.Tag  = this.Modify_Button.Enabled;
			this.Delete_Button.Tag  = this.Delete_Button.Enabled;
		}

		/// <summary>
		/// �폜�f�[�^�`�F�b�N����
		/// </summary>
		/// <returns>true:�폜�\ false:�폜�s��</returns>
		/// <remarks>
		/// <br>Note       : �폜�f�[�^�̍폜�ς݃`�F�b�N���s���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private bool DeleteDataCheck(TargetData targetData)
		{
			bool ret = true;
			int index = -1;

			string tableName = "";
			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = null;
			Hashtable appearanceTable;

			switch (targetData)
			{
				case (TargetData.First):
				{
					tableName = this._tableNameList[FIRST_INDEX];
					targetGrid = this.First_Grid;
					appearanceTable = this._appearanceTable[FIRST_INDEX];
					break;
				}
				case (TargetData.Second):
				{
					tableName = this._tableNameList[SECOND_INDEX];
					targetGrid = this.Second_Grid;
					appearanceTable = this._appearanceTable[SECOND_INDEX];
					break;
				}
				case (TargetData.Third):
				{
					tableName = this._tableNameList[THIRD_INDEX];
					targetGrid = this.Third_Grid;
					appearanceTable = this._appearanceTable[THIRD_INDEX];
					break;
				}
				default:
				{
					return ret;
				}
			}

			for (int i = 0; i < this.Bind_DataSet.Tables[tableName].Columns.Count; i++)
			{
				GridColAppearance appearance = (GridColAppearance)appearanceTable[this.Bind_DataSet.Tables[tableName].Columns[i].ColumnName];

				if ((appearance.GridColDispType == MGridColDispType.DeletionDataBoth) ||
					(appearance.GridColDispType == MGridColDispType.DeletionDataListOnly) ||
					(appearance.GridColDispType == MGridColDispType.DeletionDataDetailsOnly))
				{
					index = i;
					break;
				}
			}	

			if (index >= 0)
			{
				if (targetGrid.ActiveRow.Cells[index].Text.Trim() != "") ret = false;
			}

			return ret;
		}
		# endregion

		# region Control Events

        /// <summary>
        /// ���쌠���̐�����J�n���܂��B
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���쌠���ɉ������{�^������</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private void BeginControllingByOperationAuthority()
        {
            // �{�^����ݒ�
            MyOpeCtrl.AddControlItem(MasMainFrameOpeCode.New, this.New_Button, true);
            MyOpeCtrl.AddControlItem(MasMainFrameOpeCode.Delete, this.Delete_Button, true);
            MyOpeCtrl.AddControlItem(MasMainFrameOpeCode.Modify, this.Modify_Button, false);
            MyOpeCtrl.AddControlItem(MasMainFrameOpeCode.Print, this.Print_Button, false);

            // �c�[���o�[��ݒ�
            List<ToolButtonInfo> toolButtonInfoList = new List<ToolButtonInfo>();
            toolButtonInfoList.Add(new MasMainToolButtonInfo(NEW_TOOL_BUTTON_KEY, MasMainFrameOpeCode.New, true));
            toolButtonInfoList.Add(new MasMainToolButtonInfo(DELETE_TOOL_BUTTON_KEY, MasMainFrameOpeCode.Delete, true));
            toolButtonInfoList.Add(new MasMainToolButtonInfo(MODIFY_TOOL_BUTTON_KEY, MasMainFrameOpeCode.Modify, false));
            toolButtonInfoList.Add(new MasMainToolButtonInfo(PRINT_TOOL_BUTTON_KEY, MasMainFrameOpeCode.Print, false));
            MyOpeCtrl.AddControlItem(this.ultraToolbarsManager1, toolButtonInfoList);

            // ���쌠���̐�����J�n
            MyOpeCtrl.BeginControl();
        }

		/// <summary>
		/// Form.Load �C�x���g(SFUKN09000UC)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@ : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void PMKHN09760UG_Load(object sender, System.EventArgs e)
		{
			this.InitialDisplay();

            BeginControllingByOperationAuthority();

			// �f�[�^�̒��o���������s����
			int totalCount = 0;

			int status = this._threeArrayTypeObj.Search(
				ref totalCount,
				this.SearchCount);

			switch (status)
			{
				case 0:
				{
					break;
				}
				case 9:
				{
					break;
				}
				default:
				{
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_STOPDISP,
						this.Name,
						"�ǂݍ��݂Ɏ��s���܂����B",
						status,
						MessageBoxButtons.OK);

					return;
				}
			}

			this.First_Grid.DataSource = this.Bind_DataSet.Tables[this._tableNameList[FIRST_INDEX]].DefaultView;
			this.Second_Grid.DataSource = this.Bind_DataSet.Tables[this._tableNameList[SECOND_INDEX]].DefaultView;
			this.Third_Grid.DataSource = this.Bind_DataSet.Tables[this._tableNameList[THIRD_INDEX]].DefaultView;

			this._threeArrayTypeObj.GetAppearanceTable(out this._appearanceTable);
			this.GridInitialSetting();

			this.AutoFillToFirstGridColumn_CheckEditor.Checked = false;
			this.AutoFillToFirstGridColumn_CheckEditor.Checked = this._defaultAutoFillToGridColumnList[FIRST_INDEX];
			this.AutoFillToSecondGridColumn_CheckEditor.Checked = false;
			this.AutoFillToSecondGridColumn_CheckEditor.Checked = this._defaultAutoFillToGridColumnList[SECOND_INDEX];
			this.AutoFillToThirdGridColumn_CheckEditor.Checked = false;
			this.AutoFillToThirdGridColumn_CheckEditor.Checked = this._defaultAutoFillToGridColumnList[THIRD_INDEX];

			if (this._threeArrayTypeObj.DefaultGridDisplayLayout != MGridDisplayLayout.Vertical)
			{
				this.ultraDockManager1.DockAreas[0].ChildPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.VerticalSplit;
			}
			else
			{
				this.ultraDockManager1.DockAreas[0].ChildPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.HorizontalSplit;
			}

			if (this.First_Grid.Rows.Count > 0)
			{
				this.First_Grid.ActiveRow = this.First_Grid.Rows[0];
				this.First_Grid.ActiveRow.Selected = true;
			}

			this.ActiveControl = this.First_Grid;

			this.StatusBarCountIndication();

			// �S�����o�̏ꍇ�͔񓯊��Œ��o���������s����
			if ((this._extractionSetUpType == ExtractionSetUpType.SearchAuto) && (this.SearchCount != 0))
			{
				this._nextSearchFlg = true;
				this.NextSearch_Timer.Enabled = true;
			}
		}

		/// <summary>
		/// Control.Click �C�x���g(New_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �V�K�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void New_Button_Click(object sender, System.EventArgs e)
		{
			if ((this.ultraToolbarsManager1.Tools["New_ControlContainerTool"].SharedProps.Visible == false) ||
				((bool)this.New_Button.Tag == false))
			{
				return;
			}

			switch (this._targetData)
			{
				case (TargetData.First):
				{
					this._threeArrayTypeObj.TargetTableName = this._tableNameList[FIRST_INDEX];

					this._dataIndexList[FIRST_INDEX]  = -1;
					this._dataIndexList[SECOND_INDEX] = -1;
					this._dataIndexList[THIRD_INDEX]  = -1;
					break;
				}
				case (TargetData.Second):
				{
					// ���O���b�h�̍폜�f�[�^�`�F�b�N
					if (!this.DeleteDataCheck(TargetData.First))
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_EXCLAMATION,
							this.Name,
							this._gridTitleList[FIRST_INDEX] + "�̑I�𒆂̃f�[�^�����ɍ폜����Ă��邽�߁A" + this._gridTitleList[SECOND_INDEX] + "�̐V�K�o�^�͏o���܂���B",
							0,
							MessageBoxButtons.OK);

						return;
					}

					this._threeArrayTypeObj.TargetTableName = this._tableNameList[SECOND_INDEX];

					CurrencyManager cm = (CurrencyManager)BindingContext[this.First_Grid.DataSource];
					this._dataIndexList[FIRST_INDEX]  = cm.Position;	
					this._dataIndexList[SECOND_INDEX] = -1;
					this._dataIndexList[THIRD_INDEX]  = -1;
					break;
				}
				case (TargetData.Third):
				{
					// ���O���b�h�̍폜�f�[�^�`�F�b�N
					if (!this.DeleteDataCheck(TargetData.First))
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_EXCLAMATION,
							this.Name,
							this._gridTitleList[FIRST_INDEX] + "�̑I�𒆂̃f�[�^�����ɍ폜����Ă��邽�߁A" + this._gridTitleList[SECOND_INDEX] + "�̐V�K�o�^�͏o���܂���B",
							0,
							MessageBoxButtons.OK);

						return;
					}

					// ���O���b�h�̍폜�f�[�^�`�F�b�N
					if (!this.DeleteDataCheck(TargetData.Second))
					{
						TMsgDisp.Show(
							this,
							emErrorLevel.ERR_LEVEL_EXCLAMATION,
							this.Name,
							this._gridTitleList[SECOND_INDEX] + "�̑I�𒆂̃f�[�^�����ɍ폜����Ă��邽�߁A" + this._gridTitleList[THIRD_INDEX] + "�̐V�K�o�^�͏o���܂���B",
							0,
							MessageBoxButtons.OK);

						return;
					}

					this._threeArrayTypeObj.TargetTableName = this._tableNameList[THIRD_INDEX];

					CurrencyManager cm1 = (CurrencyManager)BindingContext[this.First_Grid.DataSource];
					CurrencyManager cm2 = (CurrencyManager)BindingContext[this.Second_Grid.DataSource];
					this._dataIndexList[FIRST_INDEX]  = cm1.Position;	
					this._dataIndexList[SECOND_INDEX] = cm2.Position;	
					this._dataIndexList[THIRD_INDEX]  = -1;
					break;
				}
			}

			this._threeArrayTypeObj.SetDataIndexList(this._dataIndexList);
			this._threeArrayTypeObj.CanClose = false;

			Form customForm = (Form)this._threeArrayTypeObj;
			customForm.StartPosition = FormStartPosition.CenterScreen;
			customForm.Owner = this._owningForm;

			// ���Ƀt�H�[�����\������Ă���ꍇ�́A��U�I��������
			if (customForm.Visible == true)
			{
				customForm.Hide();
			}

            customForm.ShowDialog();
		}

		/// <summary>
		/// Control.Click �C�x���g(Delete_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void Delete_Button_Click(object sender, System.EventArgs e)
		{
			if ((this.ultraToolbarsManager1.Tools["Delete_ControlContainerTool"].SharedProps.Visible == false) ||
				((bool)this.Delete_Button.Tag == false))
			{
				return;
			}

			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = null;

			switch (this._targetData)
			{
				case (TargetData.First):
				{
					targetGrid = First_Grid;
					break;
				}
				case (TargetData.Second):
				{
					targetGrid = Second_Grid;
					break;
				}
				case (TargetData.Third):
				{
					targetGrid = Third_Grid;
					break;
				}
				default:
				{
					return;
				}
			}

			if (targetGrid.ActiveRow == null)
			{
				return;
			}

			// �t�B���^�ŏ��O����Ă���s�̏ꍇ�͈ȉ��̏������L�����Z������
			if (targetGrid.ActiveRow.IsFilteredOut == true)
			{
				return;
			}

			// �폜�f�[�^�`�F�b�N����
			if (!DeleteDataCheck(this._targetData))
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"�I�𒆂̃f�[�^�͊��ɍ폜����Ă��܂��B",
					0,
					MessageBoxButtons.OK);

				return;
			}

			DialogResult result = TMsgDisp.Show(
				this,
				emErrorLevel.ERR_LEVEL_QUESTION,
				this.Name,
				"�I�������s���폜���܂����H",
				0,
				MessageBoxButtons.YesNo,
				MessageBoxDefaultButton.Button2);

			if (result == DialogResult.Yes)
			{
				CurrencyManager cm1 = (CurrencyManager)BindingContext[this.First_Grid.DataSource];
				CurrencyManager cm2 = (CurrencyManager)BindingContext[this.Second_Grid.DataSource];
				CurrencyManager cm3 = (CurrencyManager)BindingContext[this.Third_Grid.DataSource];

				this._dataIndexList[FIRST_INDEX]  = cm1.Position;	
				this._dataIndexList[SECOND_INDEX] = cm2.Position;	
				this._dataIndexList[THIRD_INDEX]  = cm3.Position;	

				this._threeArrayTypeObj.SetDataIndexList(this._dataIndexList);

				switch (this._targetData)
				{
					case (TargetData.First):
					{
						this._threeArrayTypeObj.TargetTableName = this._tableNameList[FIRST_INDEX];
						break;
					}
					case (TargetData.Second):
					{
						this._threeArrayTypeObj.TargetTableName = this._tableNameList[SECOND_INDEX];
						break;
					}
					case (TargetData.Third):
					{
						this._threeArrayTypeObj.TargetTableName = this._tableNameList[THIRD_INDEX];
						break;
					}
				}

				// �f�[�^�̍폜���������s����
				int status = this._threeArrayTypeObj.Delete();
				if (status != 0)
				{
					return;
				}

				this.AddGridFiltering(TargetData.First);
				this.AddGridFiltering(TargetData.Second);
				this.AddGridFiltering(TargetData.Third);
				this.StatusBarCountIndication();
			}

			// �O���b�h�A�N�e�B�u�s�ݒ菈��
			this.SetActiveRow(this.First_Grid);

			// �O���b�h�A�N�e�B�u�s�ݒ菈��
			this.SetActiveRow(this.Second_Grid);

			// �O���b�h�A�N�e�B�u�s�ݒ菈��
			this.SetActiveRow(this.Third_Grid);
		}

		/// <summary>
		/// Control.Click �C�x���g(Modify_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@ : �C���{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void Modify_Button_Click(object sender, System.EventArgs e)
		{
			if ((this.ultraToolbarsManager1.Tools["Modify_ControlContainerTool"].SharedProps.Visible == false) ||
				((bool)this.Modify_Button.Tag == false))
			{
				return;
			}

			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = null;

			switch (this._targetData)
			{
				case (TargetData.First):
				{
					targetGrid = First_Grid;
					break;
				}
				case (TargetData.Second):
				{
					targetGrid = Second_Grid;
					break;
				}
				case (TargetData.Third):
				{
					targetGrid = Third_Grid;
					break;
				}
				default:
				{
					return;
				}
			}

			if (targetGrid.ActiveRow == null)
			{
				return;
			}

			if (targetGrid.ActiveRow.IsFilteredOut == true)
			{
				return;
			}

			CurrencyManager cm1 = (CurrencyManager)BindingContext[this.First_Grid.DataSource];
			CurrencyManager cm2 = (CurrencyManager)BindingContext[this.Second_Grid.DataSource];
			CurrencyManager cm3 = (CurrencyManager)BindingContext[this.Third_Grid.DataSource];

			this._dataIndexList[FIRST_INDEX]  = cm1.Position;	
			this._dataIndexList[SECOND_INDEX] = cm2.Position;	
			this._dataIndexList[THIRD_INDEX]  = cm3.Position;	

			this._threeArrayTypeObj.SetDataIndexList(this._dataIndexList);
			this._threeArrayTypeObj.CanClose = false;

			switch (this._targetData)
			{
				case (TargetData.First):
				{
					this._threeArrayTypeObj.TargetTableName = this._tableNameList[FIRST_INDEX];
					break;
				}
				case (TargetData.Second):
				{
					this._threeArrayTypeObj.TargetTableName = this._tableNameList[SECOND_INDEX];
					break;
				}
				case (TargetData.Third):
				{
					this._threeArrayTypeObj.TargetTableName = this._tableNameList[THIRD_INDEX];
					break;
				}
			}

			Form customForm = (Form)this._threeArrayTypeObj;
			customForm.StartPosition = FormStartPosition.CenterScreen;
			customForm.Owner = this._owningForm;

			if (customForm.Visible == true)
			{
				customForm.Hide();
			}

            customForm.ShowDialog();
		}

		/// <summary>
		/// Control.Click �C�x���g(Details_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@ : �ڍ׃{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void Details_Button_Click(object sender, System.EventArgs e)
		{
			if (this._detailFlg == true)
			{
				this._detailFlg = false;
			}
			else
			{
				this._detailFlg = true;
			}

			for (int i = 0; i < this.Bind_DataSet.Tables[this._tableNameList[FIRST_INDEX]].Columns.Count; i++)
			{
				GridColAppearance appearance = (GridColAppearance)this._appearanceTable[FIRST_INDEX][this.Bind_DataSet.Tables[this._tableNameList[FIRST_INDEX]].Columns[i].ColumnName];
				this.GridColHidden(i, appearance.GridColDispType, TargetData.First);
			}

			// �񕝂𒲐�����
			if (AutoFillToFirstGridColumn_CheckEditor.Checked == true)
			{
				AutoFillToFirstGridColumn_CheckEditor.Checked = false;
				AutoFillToFirstGridColumn_CheckEditor.Checked = true;
			}

			for (int i = 0; i < this.Bind_DataSet.Tables[this._tableNameList[SECOND_INDEX]].Columns.Count; i++)
			{
				GridColAppearance appearance = (GridColAppearance)this._appearanceTable[SECOND_INDEX][this.Bind_DataSet.Tables[this._tableNameList[SECOND_INDEX]].Columns[i].ColumnName];
				this.GridColHidden(i, appearance.GridColDispType, TargetData.Second);
			}

			// �񕝂𒲐�����
			if (AutoFillToSecondGridColumn_CheckEditor.Checked == true)
			{
				AutoFillToSecondGridColumn_CheckEditor.Checked = false;
				AutoFillToSecondGridColumn_CheckEditor.Checked = true;
			}

			for (int i = 0; i < this.Bind_DataSet.Tables[this._tableNameList[THIRD_INDEX]].Columns.Count; i++)
			{
				GridColAppearance appearance = (GridColAppearance)this._appearanceTable[THIRD_INDEX][this.Bind_DataSet.Tables[this._tableNameList[THIRD_INDEX]].Columns[i].ColumnName];
				this.GridColHidden(i, appearance.GridColDispType, TargetData.Third);
			}

			// �񕝂𒲐�����
			if (AutoFillToThirdGridColumn_CheckEditor.Checked == true)
			{
				AutoFillToThirdGridColumn_CheckEditor.Checked = false;
				AutoFillToThirdGridColumn_CheckEditor.Checked = true;
			}
		}

		/// <summary>
		/// Control.Click �C�x���g(Print_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@ : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void Print_Button_Click(object sender, System.EventArgs e)
		{
			if (this.ultraToolbarsManager1.Tools["Print_ControlContainerTool"].SharedProps.Visible == false)
			{
				return;
			}

			this._threeArrayTypeObj.Print();
		}

		/// <summary>
		/// Control.Click �C�x���g(Close_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@ : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		internal void Close_Button_Click(object sender, System.EventArgs e)
		{
			MasterMaintenanceConstruction mmc = this._owningForm.GetConstructionTable(this._programItemObj.ClassID);
			mmc.SearchCount = 0;
			this._owningForm.ConstructionTableAdd(mmc.ToString(), mmc);

			this._nextSearchFlg = false;
			this.NextSearch_Timer.Enabled = false;

			Close_Timer.Enabled = true;
		}

		/// <summary>
		/// UltraWinGrid.AfterSortChange �C�x���g(First_Grid/SecondGrid/ThirdGrid)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">Band�I�u�W�F�N�g�������Ƃ���C�x���g�Ŏg�p�����C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@ : �O���b�h�̃\�[�g�A�N�V�����̊�����ɔ������܂��B
		///					�@�ꗗ�\���p�O���b�h�Əڍו\���p�O���b�h�̃\�[�g����A�������܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void Grid_AfterSortChange(object sender, Infragistics.Win.UltraWinGrid.BandEventArgs e)
		{
			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

			// �I���s��擪�ɔz�u����
			if (targetGrid.Rows.Count > 0)
			{
				targetGrid.ActiveRow = targetGrid.Rows[0];
				targetGrid.ActiveRow.Selected = true;
				targetGrid.Refresh();
			}
		}

		/// <summary>
		/// UltraWinGrid.AfterSelectChange �C�x���g(First_Grid)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">Band�I�u�W�F�N�g�������Ƃ���C�x���g�Ŏg�p�����C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@ : �P�ȏ�̍s�A�Z���A�܂��͗�I�u�W�F�N�g���I���܂��͑I���������ꂽ��ɔ������܂��B </br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void First_Grid_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
		{
			// �{���ΏۃO���b�h���قȂ�A�s�|�W�V�������ύX���ꂽ�ꍇ�́A�q��ʂ������I�ɔ�\���Ƃ���
			string targetTableName = "";
			Form customForm = (Form)this._threeArrayTypeObj;

			switch (this._targetData)
			{
				case (TargetData.First):
				{
					targetTableName = this._tableNameList[FIRST_INDEX];
					break;
				}
				case (TargetData.Second):
				{
					targetTableName = this._tableNameList[SECOND_INDEX];
					break;
				}
				case (TargetData.Third):
				{
					targetTableName = this._tableNameList[THIRD_INDEX];
					break;
				}
				default:
				{
					return;
				}
			}

			if ((this._threeArrayTypeObj.TargetTableName != targetTableName) && (customForm.Visible == true))
			{
				customForm.Hide();
			}

			CurrencyManager cm = (CurrencyManager)BindingContext[this.First_Grid.DataSource];
			this._dataIndexList[FIRST_INDEX]  = cm.Position;	
			this._dataIndexList[SECOND_INDEX] = 0;	
			this._dataIndexList[THIRD_INDEX]  = 0;	

			this._threeArrayTypeObj.SetDataIndexList(this._dataIndexList);

			int totalCount = 0;

            // �ŏ�ʍ��ڂ̕\�����R�[�h��0���̏ꍇ�A���ʍ��ڂ̌����͋����I���i�e�[�u���̃N���A�̂݁j
            int readCount = this.First_Grid.Rows.FilteredInRowCount.Equals(0) ? -1 : 0;
            this._threeArrayTypeObj.SecondDataSearch(ref totalCount, readCount);

            // �폜�f�[�^�\�����̂ݕ\��������̃T�C�Y��������������
            AdjustDeletedDateColumnOfGrid(SECOND_INDEX);

			this.StatusBarCountIndication();

			if (this.Second_Grid.Rows.Count > 0)
			{
				this.Second_Grid.ActiveRow = this.Second_Grid.Rows[0];
				this.Second_Grid.ActiveRow.Selected = true;
			}
		}

        /// <summary>
        /// �폜�f�[�^�\�����̂ݕ\��������̃T�C�Y�������������܂��B
        /// </summary>
        /// <param name="itemIndex">
        /// ���ڂ̃C���f�b�N�X<br/>
        /// ��<c>FIRST_INDEX</c>�A<c>SECOND_INDEX</c>�A<c>THIRD_INDEX</c>�̂����ꂩ���w�肵�ĉ������B
        /// </param>
        private void AdjustDeletedDateColumnOfGrid(int itemIndex)
        {
            string tableName = this._tableNameList[itemIndex];
            Hashtable appearanceTable = this._appearanceTable[itemIndex];

            Infragistics.Win.UltraWinEditors.UltraCheckEditor targetCheckEditor = null;
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = null;
            switch (itemIndex)
            {
                case FIRST_INDEX:
                {
                    targetCheckEditor = this.FirstLogicalDeleteDataExtraction_CheckEditor;
                    targetGrid = this.First_Grid;
                    break;
                }
                case SECOND_INDEX:
                {
                    targetCheckEditor = this.SecondLogicalDeleteDataExtraction_CheckEditor;
                    targetGrid = this.Second_Grid;
                    break;
                }
                default:
                {
                    targetCheckEditor = this.ThirdLogicalDeleteDataExtraction_CheckEditor;
                    targetGrid = this.Third_Grid;
                    break;
                }
            }

            if (targetCheckEditor.Checked)
            {
                for (int i = 0; i < this.Bind_DataSet.Tables[tableName].Columns.Count; i++)
                {
                    GridColAppearance appearance = (GridColAppearance)appearanceTable[this.Bind_DataSet.Tables[tableName].Columns[i].ColumnName];

                    if ((appearance.GridColDispType == MGridColDispType.DeletionDataBoth) ||
                        (appearance.GridColDispType == MGridColDispType.DeletionDataListOnly))
                    {
                        targetGrid.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
                    }
                }
            }
        }

		/// <summary>
		/// UltraWinGrid.AfterSelectChange �C�x���g(Second_Grid)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">Band�I�u�W�F�N�g�������Ƃ���C�x���g�Ŏg�p�����C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@ : �P�ȏ�̍s�A�Z���A�܂��͗�I�u�W�F�N�g���I���܂��͑I���������ꂽ��ɔ������܂��B </br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void Second_Grid_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
		{
			// �{���ΏۃO���b�h���قȂ�A�s�|�W�V�������ύX���ꂽ�ꍇ�́A�q��ʂ������I�ɔ�\���Ƃ���
			string targetTableName = "";
			Form customForm = (Form)this._threeArrayTypeObj;

			switch (this._targetData)
			{
				case (TargetData.First):
				{
					targetTableName = this._tableNameList[FIRST_INDEX];
					break;
				}
				case (TargetData.Second):
				{
					targetTableName = this._tableNameList[SECOND_INDEX];
					break;
				}
				case (TargetData.Third):
				{
					targetTableName = this._tableNameList[THIRD_INDEX];
					break;
				}
				default:
				{
					return;
				}
			}

			if ((this._threeArrayTypeObj.TargetTableName != targetTableName) && (customForm.Visible == true))
			{
				customForm.Hide();
			}

			CurrencyManager cm1 = (CurrencyManager)BindingContext[this.First_Grid.DataSource];
			CurrencyManager cm2 = (CurrencyManager)BindingContext[this.Second_Grid.DataSource];
			this._dataIndexList[FIRST_INDEX]  = cm1.Position;	
			this._dataIndexList[SECOND_INDEX] = cm2.Position;	
			this._dataIndexList[THIRD_INDEX]  = 0;

			this._threeArrayTypeObj.SetDataIndexList(this._dataIndexList);

			int totalCount = 0;

            // �ŏ�ʍ��ڂ̕\�����R�[�h��0���̏ꍇ�A���ʍ��ڂ̌����͋����I���i�e�[�u���̃N���A�̂݁j
            int readCount = 0;
            if (this.First_Grid.Rows.FilteredInRowCount.Equals(0) || this.Second_Grid.Rows.FilteredInRowCount.Equals(0))
            {
                readCount = -1;
            }
            this._threeArrayTypeObj.ThirdDataSearch(ref totalCount, readCount);

            // �폜�f�[�^�\�����̂ݕ\��������̃T�C�Y��������������
            AdjustDeletedDateColumnOfGrid(THIRD_INDEX);

			this.StatusBarCountIndication();

			if (this.Third_Grid.Rows.Count > 0)
			{
				this.Third_Grid.ActiveRow = this.Third_Grid.Rows[0];
				this.Third_Grid.ActiveRow.Selected = true;
			}
		}

		/// <summary>
		/// Control.DoubleClick �C�x���g(First_Grid/SecondGrid/ThirdGrid)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@ : �ꗗ�\���p�O���b�h�R���g���[�����_�u���N���b�N���ꂽ�Ƃ��ɔ������܂��B
		///					�@�Z�����_�u���N���b�N���ꂽ�ꍇ�A�ڍד��͉�ʂ�\�����܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void Grid_DoubleClick(object sender, System.EventArgs e)
		{
			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;
			
			// �}�E�X�|�C���^���O���b�h�̂ǂ̈ʒu�ɂ��邩�𔻒肷��
			Point point = System.Windows.Forms.Cursor.Position;
			point = targetGrid.PointToClient(point);
			Infragistics.Win.UIElement objElement = null;
			Infragistics.Win.UltraWinGrid.RowCellAreaUIElement objRowCellAreaUIElement = null;
			objElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);

			objRowCellAreaUIElement = (Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)objElement.GetAncestor(
				(typeof(Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)));

			// �w�b�_���̏ꍇ�͈ȉ��̏������L�����Z������
			if(objRowCellAreaUIElement == null)
			{
				return;
			}

			Modify_Button_Click(Modify_Button, e);
		}

		/// <summary>
		/// Control.KeyDown �C�x���g(First_Grid/SecondGrid/ThirdGrid)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">KeyDown �C�x���g�܂��� KeyUp �C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@ : �ꗗ�\���p�O���b�h�R���g���[�����_�u���N���b�N���ꂽ�Ƃ��ɔ������܂��B
		///					�@�Z�����_�u���N���b�N���ꂽ�ꍇ�A�ڍד��͉�ʂ�\�����܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void Grid_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/10 ADD
                case (Keys.Left):
                    {
                        switch ( this._targetData )
                        {
                            case (TargetData.Second):
                                {
                                    this.ActiveControl = this.First_Grid;   // 1��2
                                    break;
                                }
                            case (TargetData.Third):
                                {
                                    this.ActiveControl = this.Second_Grid;  // 2��3
                                    break;
                                }
                        }
                        // �����ς݈����ɂ��ăf�t�H���g������L�����Z������
                        e.Handled = true;
                        break;
                    }
                case (Keys.Right):
                    {
                        switch ( this._targetData )
                        {
                            case (TargetData.First):
                                {
                                    this.ActiveControl = this.Second_Grid;   // 1��2
                                    break;
                                }
                            case (TargetData.Second):
                                {
                                    this.ActiveControl = this.Third_Grid;  // 2��3
                                    break;
                                }
                        }
                        // �����ς݈����ɂ��ăf�t�H���g������L�����Z������
                        e.Handled = true;
                        break;
                    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/10 ADD
				case (Keys.Return):
				{
					Modify_Button_Click(Modify_Button, e);

					break;
				}
				case (Keys.Tab):
				{
					switch (this._targetData)
					{
						case (TargetData.First):
						{
							this.ActiveControl = this.Second_Grid;
							break;
						}
						case (TargetData.Second):
						{
							this.ActiveControl = this.Third_Grid;
							break;
						}
						case (TargetData.Third):
						{
							this.ActiveControl = this.First_Grid;
							break;
						}
						default:
						{
							return;
						}
					}

					break;
				}
			}
		}

		/// <summary>
		/// Control.Enter �C�x���g(First_Grid)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@ : �R���g���[�����t�H�[���̃A�N�e�B�u�R���g���[���ɂȂ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void First_Grid_Enter(object sender, System.EventArgs e)
		{
			this._targetData = TargetData.First;	
			this.ButtonEnabledControl(this._targetData);
			this.PMKHN09760UG_VisibleChanged(this, new EventArgs());
		}

		/// <summary>
		/// Control.Enter �C�x���g(Second_Grid)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@ : �R���g���[�����t�H�[���̃A�N�e�B�u�R���g���[���ɂȂ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void Second_Grid_Enter(object sender, System.EventArgs e)
		{
			this._targetData = TargetData.Second;	
			this.ButtonEnabledControl(this._targetData);
			this.PMKHN09760UG_VisibleChanged(this, new EventArgs());
		}

		/// <summary>
		/// Control.Enter �C�x���g(Third_Grid)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@ : �R���g���[�����t�H�[���̃A�N�e�B�u�R���g���[���ɂȂ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void Third_Grid_Enter(object sender, System.EventArgs e)
		{
			this._targetData = TargetData.Third;	
			this.ButtonEnabledControl(this._targetData);
			this.PMKHN09760UG_VisibleChanged(this, new EventArgs());
		}

		/// <summary>
		/// CheckEditor.CheckedChanged �C�x���g(AutoFillToXXXXXGridColumn_CheckEditor)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@ : ��̃T�C�Y��������������`�F�b�N�G�f�B�^�R���g���[����Checked
		///					�@�v���p�e�B���ύX�����Ƃ��ɔ������܂��B
		///					�@�O���b�h���AutoResize���\�b�h�����s���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void AutoFillToGridColumn_CheckEditor_CheckedChanged(object sender, System.EventArgs e)
		{
			Infragistics.Win.UltraWinEditors.UltraCheckEditor targetCheckEditor = sender as Infragistics.Win.UltraWinEditors.UltraCheckEditor;
			if (targetCheckEditor == null)
			{
				return;
			}
			
			int tag = Convert.ToInt16(targetCheckEditor.Tag);

			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = null;

			switch (tag)
			{
				case (int)TargetData.First:
				{
					targetGrid = this.First_Grid;

					break;
				}
				case (int)TargetData.Second:
				{
					targetGrid = this.Second_Grid;

					break;
				}
				case (int)TargetData.Third:
				{
					targetGrid = this.Third_Grid;

					break;
				}
				default:
				{
					return;
				}
			}

			if (targetCheckEditor.Checked)
			{
				targetGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
			}
			else
			{
				targetGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
			}

			if (targetCheckEditor.Checked == false)
			{
				for (int i = 0; i < targetGrid.DisplayLayout.Bands[0].Columns.Count; i++)
				{
					targetGrid.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
				}
			}
		}

		/// <summary>
		/// CheckEditor.CheckedChanged �C�x���g(FirstLogicalDeleteDataExtraction_CheckEditor)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@ : �폜�ς݃f�[�^��\������`�F�b�N�G�f�B�^�R���g���[����Checked
		///					�@�v���p�e�B���ύX�����Ƃ��ɔ������܂��B
		///					�@�폜�ς݃f�[�^�̃t�B���^���������A�폜�ς݃f�[�^��\�����܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void LogicalDeleteDataExtraction_CheckEditor_CheckedChanged(object sender, System.EventArgs e)
		{
			Infragistics.Win.UltraWinEditors.UltraCheckEditor targetCheckEditor = sender as Infragistics.Win.UltraWinEditors.UltraCheckEditor;
			if (targetCheckEditor == null)
			{
				return;
			}
			
			int tag = Convert.ToInt16(targetCheckEditor.Tag);

			string tableName = "";
			Hashtable appearanceTable;
			TargetData targetData;
			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = null;

			switch (tag)
			{
				case (int)TargetData.First:
				{
                    if (this._synchroLogDelFlg)
                    {
                        // �_���폜�ς݃f�[�^�̕\���A���L
                        bool bSynchroCheck = targetCheckEditor.Checked;

                        if (this._canLogicalDeleteDataExtractionList[THIRD_INDEX])
                        {
                            // �T�[�h�p�l���̘_���폜�ς݃f�[�^�̕\���`�F�b�N�{�b�N�X��A��
                            this.ThirdLogicalDeleteDataExtraction_CheckEditor.Checked = bSynchroCheck;
                        }

                        if (this._canLogicalDeleteDataExtractionList[SECOND_INDEX])
                        {
                            // �Z�J���h�p�l���̘_���폜�ς݃f�[�^�̕\���`�F�b�N�{�b�N�X��A��
                            this.SecondLogicalDeleteDataExtraction_CheckEditor.Checked = bSynchroCheck;
                        }

                        #if SYNCHRONIZE_LOGICAL_DELETE_RECORD_FORCE

                        // �T�[�h�p�l���̘_���폜�ς݃f�[�^�̕\���`�F�b�N�{�b�N�X��A��
                        if (!this.ThirdLogicalDeleteDataExtraction_CheckEditor.Checked.Equals(bSynchroCheck))
                        {
                            this.ThirdLogicalDeleteDataExtraction_CheckEditor.Checked = bSynchroCheck;
                        }
                        // �Z�J���h�p�l���̘_���폜�ς݃f�[�^�̕\���`�F�b�N�{�b�N�X��A��
                        if (!this.SecondLogicalDeleteDataExtraction_CheckEditor.Checked.Equals(bSynchroCheck))
                        {
                            this.SecondLogicalDeleteDataExtraction_CheckEditor.Checked = bSynchroCheck;
                        }

                        #endif  // #if SYNCHRONIZE_LOGICAL_DELETE_RECORD_FORCE
                    }

					tableName = this._tableNameList[FIRST_INDEX];
					appearanceTable = this._appearanceTable[FIRST_INDEX];
					targetData = TargetData.First;
					targetGrid = this.First_Grid;

					break;
				}
				case (int)TargetData.Second:
				{
                    if (this._synchroLogDelFlg)
                    {                        
                        // �_���폜�ς݃f�[�^�̕\���A���L
                        bool bSynchroCheck = targetCheckEditor.Checked;

                        if (this._canLogicalDeleteDataExtractionList[THIRD_INDEX])
                        {
                            // �T�[�h�p�l���̘_���폜�ς݃f�[�^�̕\���`�F�b�N�{�b�N�X��A��
                            this.ThirdLogicalDeleteDataExtraction_CheckEditor.Checked = bSynchroCheck;
                        }

                        if (this._canLogicalDeleteDataExtractionList[FIRST_INDEX])
                        {
                            // �t�@�[�X�g�p�l���̘_���폜�ς݃f�[�^�̕\���`�F�b�N�{�b�N�X��A��
                            this.FirstLogicalDeleteDataExtraction_CheckEditor.Checked = bSynchroCheck;
                        }

                        #if SYNCHRONIZE_LOGICAL_DELETE_RECORD_FORCE

                        // �T�[�h�p�l���̘_���폜�ς݃f�[�^�̕\���`�F�b�N�{�b�N�X��A��
                        if (!this.ThirdLogicalDeleteDataExtraction_CheckEditor.Checked.Equals(bSynchroCheck))
                        {
                            this.ThirdLogicalDeleteDataExtraction_CheckEditor.Checked = bSynchroCheck;
                        }
                        // �t�@�[�X�g�p�l���̘_���폜�ς݃f�[�^�̕\���`�F�b�N�{�b�N�X��A��
                        if (!this.FirstLogicalDeleteDataExtraction_CheckEditor.Checked.Equals(bSynchroCheck))
                        {
                            this.FirstLogicalDeleteDataExtraction_CheckEditor.Checked = bSynchroCheck;
                        }

                        #endif  // #if SYNCHRONIZE_LOGICAL_DELETE_RECORD_FORCE
                    }
                    
					tableName = this._tableNameList[SECOND_INDEX];
					appearanceTable = this._appearanceTable[SECOND_INDEX];
					targetData = TargetData.Second;
					targetGrid = this.Second_Grid;

					break;
				}
				case (int)TargetData.Third:
				{
                    if (this._synchroLogDelFlg)
                    {
                        // �_���폜�ς݃f�[�^�̕\���A���L
                        bool bSynchroCheck = targetCheckEditor.Checked;

                        if (this._canLogicalDeleteDataExtractionList[SECOND_INDEX])
                        {
                            // �Z�J���h�p�l���̘_���폜�ς݃f�[�^�̕\���`�F�b�N�{�b�N�X��A��
                            this.SecondLogicalDeleteDataExtraction_CheckEditor.Checked = bSynchroCheck;
                        }

                        if (this._canLogicalDeleteDataExtractionList[FIRST_INDEX])
                        {
                            // �t�@�[�X�g�p�l���̘_���폜�ς݃f�[�^�̕\���`�F�b�N�{�b�N�X��A��
                            this.FirstLogicalDeleteDataExtraction_CheckEditor.Checked = bSynchroCheck;
                        }

                        #if SYNCHRONIZE_LOGICAL_DELETE_RECORD_FORCE

                        // �Z�J���h�p�l���̘_���폜�ς݃f�[�^�̕\���`�F�b�N�{�b�N�X��A��
                        if (!this.SecondLogicalDeleteDataExtraction_CheckEditor.Checked.Equals(bSynchroCheck))
                        {
                            this.SecondLogicalDeleteDataExtraction_CheckEditor.Checked = bSynchroCheck;
                        }
                        // �t�@�[�X�g�p�l���̘_���폜�ς݃f�[�^�̕\���`�F�b�N�{�b�N�X��A��
                        if (!this.FirstLogicalDeleteDataExtraction_CheckEditor.Checked.Equals(bSynchroCheck))
                        {
                            this.FirstLogicalDeleteDataExtraction_CheckEditor.Checked = bSynchroCheck;
                        }

                        #endif  // #if SYNCHRONIZE_LOGICAL_DELETE_RECORD_FORCE
                    }

					tableName = this._tableNameList[THIRD_INDEX];
					appearanceTable = this._appearanceTable[THIRD_INDEX];
					targetData = TargetData.Third;
					targetGrid = this.Third_Grid;

					break;
				}
				default:
				{
					return;
				}
			}

			for (int i = 0; i < this.Bind_DataSet.Tables[tableName].Columns.Count; i++)
			{
				GridColAppearance appearance = (GridColAppearance)appearanceTable[this.Bind_DataSet.Tables[tableName].Columns[i].ColumnName];
				this.GridColHidden(i, appearance.GridColDispType, targetData);
			}

			// �O���b�h�̃t�B���^�����O����
			this.AddGridFiltering(targetData);

			// �X�e�[�^�X�o�[�����\������
			this.StatusBarCountIndication();

			if (this.Bind_DataSet.Tables[tableName].Rows.Count == 0)
			{
				return;
			}

			// �폜�f�[�^�\�����̂ݕ\��������̃T�C�Y��������������
			if (targetCheckEditor.Checked == true)
			{
				for (int i = 0; i < this.Bind_DataSet.Tables[tableName].Columns.Count; i++)
				{
					GridColAppearance appearance = (GridColAppearance)appearanceTable[this.Bind_DataSet.Tables[tableName].Columns[i].ColumnName];

					if ((appearance.GridColDispType == MGridColDispType.DeletionDataBoth) ||
						(appearance.GridColDispType == MGridColDispType.DeletionDataListOnly))
					{
						targetGrid.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
					}
				}
			}

            // ���ʍ��ڂ̃O���b�h�\�����X�V
            switch (tag)
            {
                case (int)TargetData.Second:
                    Second_Grid_AfterSelectChange(sender, null);
                    break;
                default:
                    First_Grid_AfterSelectChange(sender, null);
                    break;
            }

			// �O���b�h�A�N�e�B�u�s�ݒ菈��
			this.SetActiveRow(this.First_Grid);

			// �O���b�h�A�N�e�B�u�s�ݒ菈��
			this.SetActiveRow(this.Second_Grid);

			// �O���b�h�A�N�e�B�u�s�ݒ菈��
			this.SetActiveRow(this.Third_Grid);
		}

		/// <summary>
		/// Timer.Tick �C�x���g(CloseTimer_Tick)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@ : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
		///					�@���̏����́A�V�X�e�����񋟂���X���b�h �v�[���X���b�h�Ŏ��s����܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void Close_Timer_Tick(object sender, System.EventArgs e)
		{
			this.Close_Timer.Enabled = false;

			if (this._underExtractionFlg == false)
			{	
				Form customForm = (Form)this._threeArrayTypeObj;
				customForm.Close();
				this.Close();
			}
			else
			{
				this.Close_Timer.Enabled = true;
			}
		}

		/// <summary>
		/// Timer.Tick �C�x���g(NextSearch_Timer_Tick)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@ : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
		///					�@���̏����́A�V�X�e�����񋟂���X���b�h �v�[���X���b�h�Ŏ��s����܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
		/// </remarks>
		private void NextSearch_Timer_Tick(object sender, System.EventArgs e)
		{
			this.NextSearch_Timer.Enabled = false;

			this._underExtractionFlg = true;

			// �l�N�X�g�f�[�^��������
			int status = this._threeArrayTypeObj.SearchNext(this.SearchCount);

			try
			{
				switch (status)
				{
					case 0:
					{
						break;
					}
					case 9:
					{
						this._nextSearchFlg = false;
						break;
					}
					default:
					{
						this._nextSearchFlg = false;
						return;
					}
				}
			}
			finally
			{
				this._underExtractionFlg = false;
			}

			if (this._nextSearchFlg == true)
			{
				this.NextSearch_Timer.Enabled = true;
			}
			else
			{
				//
			}
		}
		# endregion

        /// <summary>
        /// �e�^�u���A�N�e�B�u�ɂȂ����ꍇ�̃t�H�[�J�X����
        /// </summary>
        public void SetFocusOnParentTabActive()
        {
            First_Grid.Focus();
        }
	}

    #region ���@�_���폜�ς݃f�[�^�̕\���`�F�b�N�{�b�N�X�A���C���^�[�t�F�[�X
    /// <summary>
    /// �_���폜�ς݃f�[�^�̕\���`�F�b�N�{�b�N�X�A���C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : </br>
    /// <br>Programmer : �i�N</br>
    /// <br>Date       : 2014/12/23</br>
    /// <br></br>
    /// </remarks>
    public interface ISynchroLogDelChkBox
    {
        /// <summary>
        /// �_���폜�ς݃f�[�^�̕\���A���v���p�e�B
        /// </summary>
        /// <remarks>
        /// <br>Note       : true�F�A���Afalse�F��A��(�f�t�H���g�ݒ�) </br>
        /// </remarks>
        bool SynchroLogDelFlg
        {
            get;
        }
    }
    #endregion
}

//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �}�X�^�����e�i���X
// �v���O�����T�v   : �}�X�^�����e�i���X�̐���S�ʂ��s���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ȓ��@����Y
// �� �� ��  2004/03/19  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �C �� ��  2008/08/29  �C�����e : ���쌠���ɉ������{�^������̑Ή�
//----------------------------------------------------------------------------//
// �t�H�[���ҏW���\�Ƃ���t���O
//#define CAN_EDIT_FORM   // ADD 2008/03/26 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using Broadleaf.Application.Controller;     // ADD 2008/09/01 ���쌠���ɉ������{�^������̑Ή�
using Broadleaf.Application.Controller.Util;// ADD 2008/09/01 ���쌠���ɉ������{�^������̑Ή�
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �ꗗ�\���t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �}�X�^�����e�i���X���̈ꗗ�\�����s���܂��B</br>
	/// <br>Programmer : 980076 �Ȓ��@����Y</br>
	/// <br>Date       : 2004.03.19</br>
	/// <br></br>
	/// </remarks>
	internal class SFCMN09000UC
#if CAN_EDIT_FORM
    : System.Windows.Forms.Form, IOperationAuthorityControllable// ADD 2008/03/26 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ���
#else
    //: System.Windows.Forms.Form                               // DEL 2008/09/01 ���쌠���ɉ������{�^������̑Ή�
    : OperationAuthorityControllableForm<MasMainController>     // ADD 2008/09/01 ���쌠���ɉ������{�^������̑Ή�
#endif
    {
        # region Private Members (Component)

        private System.Windows.Forms.Panel ViewButtonPanel;
		private System.Windows.Forms.Panel DetailsPanel;
		private System.Windows.Forms.Splitter DetailsSplitter;
		private Infragistics.Win.UltraWinGrid.UltraGrid DataViewGrid;
		private Infragistics.Win.UltraWinGrid.UltraGrid DetailsGrid;
		private System.Windows.Forms.Panel DataViewPanel;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor AutoFillToColumn_CheckEditor;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor DeleteIndication_CheckEditor;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar DataView_StatusBar;
		private System.Windows.Forms.Timer Close_Timer;
		private Infragistics.Win.Misc.UltraButton Details_Button;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.Misc.UltraButton New_Button;
		private Infragistics.Win.Misc.UltraButton Modify_Button;
		private Infragistics.Win.Misc.UltraButton Close_Button;
		private Infragistics.Win.Misc.UltraButton Print_Button;
		internal System.Windows.Forms.Timer NextSearch_Timer;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
		private System.Data.DataSet BindDataSet;
		private Infragistics.Win.Misc.UltraButton ExtractionSetUp_Button;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFCMN09000UC_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFCMN09000UC_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFCMN09000UC_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFCMN09000UC_Toolbars_Dock_Area_Bottom;
		private Broadleaf.Library.Windows.Forms.TNedit SearchCount_tNedit;
		private System.ComponentModel.IContainer components;

		# endregion

		# region Constructor
		/// <summary>
		/// �ꗗ�\���t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �ꗗ�\���t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		internal SFCMN09000UC()
		{
			InitializeComponent();
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
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel5 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel6 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel7 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel8 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel9 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel10 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel11 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel12 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel13 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel14 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel15 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel16 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel17 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel18 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel19 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Main_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool1 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Close_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool2 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("New_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool3 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Delete_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool4 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Modify_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool5 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Print_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool6 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Details_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool7 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ExtractionSetUp_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool8 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Close_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool9 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("New_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool10 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Delete_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool11 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Modify_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool12 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Print_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool13 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Details_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool14 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("ExtractionSetUp_ControlContainerTool");
            this.AutoFillToColumn_CheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.DeleteIndication_CheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.SearchCount_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Close_Button = new Infragistics.Win.Misc.UltraButton();
            this.New_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Modify_Button = new Infragistics.Win.Misc.UltraButton();
            this.Print_Button = new Infragistics.Win.Misc.UltraButton();
            this.Details_Button = new Infragistics.Win.Misc.UltraButton();
            this.ExtractionSetUp_Button = new Infragistics.Win.Misc.UltraButton();
            this.ViewButtonPanel = new System.Windows.Forms.Panel();
            this.DetailsPanel = new System.Windows.Forms.Panel();
            this.DetailsGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.DetailsSplitter = new System.Windows.Forms.Splitter();
            this.DataViewGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.BindDataSet = new System.Data.DataSet();
            this.DataViewPanel = new System.Windows.Forms.Panel();
            this.DataView_StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Close_Timer = new System.Windows.Forms.Timer(this.components);
            this.NextSearch_Timer = new System.Windows.Forms.Timer(this.components);
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._SFCMN09000UC_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFCMN09000UC_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFCMN09000UC_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFCMN09000UC_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.SearchCount_tNedit)).BeginInit();
            this.ViewButtonPanel.SuspendLayout();
            this.DetailsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DetailsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataViewGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindDataSet)).BeginInit();
            this.DataViewPanel.SuspendLayout();
            this.DataView_StatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // AutoFillToColumn_CheckEditor
            // 
            appearance1.FontData.SizeInPoints = 9F;
            this.AutoFillToColumn_CheckEditor.Appearance = appearance1;
            this.AutoFillToColumn_CheckEditor.Checked = true;
            this.AutoFillToColumn_CheckEditor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoFillToColumn_CheckEditor.Location = new System.Drawing.Point(3, 4);
            this.AutoFillToColumn_CheckEditor.Name = "AutoFillToColumn_CheckEditor";
            this.AutoFillToColumn_CheckEditor.Size = new System.Drawing.Size(138, 20);
            this.AutoFillToColumn_CheckEditor.TabIndex = 8;
            this.AutoFillToColumn_CheckEditor.Text = "��T�C�Y�̎�������";
            this.AutoFillToColumn_CheckEditor.CheckedChanged += new System.EventHandler(this.AutoFillToColumn_CheckEditor_CheckedChanged);
            // 
            // DeleteIndication_CheckEditor
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.FontData.SizeInPoints = 9F;
            appearance2.TextVAlignAsString = "Middle";
            this.DeleteIndication_CheckEditor.Appearance = appearance2;
            this.DeleteIndication_CheckEditor.BackColor = System.Drawing.Color.Transparent;
            this.DeleteIndication_CheckEditor.BackColorInternal = System.Drawing.Color.Transparent;
            this.DeleteIndication_CheckEditor.Location = new System.Drawing.Point(154, 4);
            this.DeleteIndication_CheckEditor.Name = "DeleteIndication_CheckEditor";
            this.DeleteIndication_CheckEditor.Size = new System.Drawing.Size(148, 20);
            this.DeleteIndication_CheckEditor.TabIndex = 0;
            this.DeleteIndication_CheckEditor.Text = "�폜�ς݃f�[�^�̕\��";
            this.DeleteIndication_CheckEditor.CheckedChanged += new System.EventHandler(this.DeleteIndication_CheckEditor_CheckedChanged);
            // 
            // SearchCount_tNedit
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SearchCount_tNedit.ActiveAppearance = appearance3;
            appearance4.TextHAlignAsString = "Right";
            this.SearchCount_tNedit.Appearance = appearance4;
            this.SearchCount_tNedit.AutoSelect = true;
            this.SearchCount_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.SearchCount_tNedit.DataText = "";
            this.SearchCount_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SearchCount_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.SearchCount_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SearchCount_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SearchCount_tNedit.Location = new System.Drawing.Point(580, 4);
            this.SearchCount_tNedit.MaxLength = 4;
            this.SearchCount_tNedit.Name = "SearchCount_tNedit";
            this.SearchCount_tNedit.NullText = "�S";
            this.SearchCount_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.SearchCount_tNedit.Size = new System.Drawing.Size(36, 21);
            this.SearchCount_tNedit.TabIndex = 9;
            // 
            // Close_Button
            // 
            this.Close_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Close_Button.Location = new System.Drawing.Point(0, 0);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(90, 27);
            this.Close_Button.TabIndex = 2;
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
            this.New_Button.Text = "�V�K(&N)";
            this.New_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.New_Button.Click += new System.EventHandler(this.New_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Delete_Button.Location = new System.Drawing.Point(160, 0);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(75, 27);
            this.Delete_Button.TabIndex = 4;
            this.Delete_Button.Text = "�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Modify_Button
            // 
            this.Modify_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Modify_Button.Location = new System.Drawing.Point(230, 0);
            this.Modify_Button.Name = "Modify_Button";
            this.Modify_Button.Size = new System.Drawing.Size(75, 27);
            this.Modify_Button.TabIndex = 5;
            this.Modify_Button.Text = "�C��(&E)";
            this.Modify_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Modify_Button.Click += new System.EventHandler(this.Modify_Button_Click);
            // 
            // Print_Button
            // 
            this.Print_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Print_Button.Location = new System.Drawing.Point(300, 0);
            this.Print_Button.Name = "Print_Button";
            this.Print_Button.Size = new System.Drawing.Size(75, 27);
            this.Print_Button.TabIndex = 6;
            this.Print_Button.Text = "���(&P)";
            this.Print_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Print_Button.Click += new System.EventHandler(this.Print_Button_Click);
            // 
            // Details_Button
            // 
            this.Details_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Details_Button.Location = new System.Drawing.Point(370, 0);
            this.Details_Button.Name = "Details_Button";
            this.Details_Button.Size = new System.Drawing.Size(75, 27);
            this.Details_Button.TabIndex = 7;
            this.Details_Button.Text = "�ڍ�(&T)";
            this.Details_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Details_Button.Click += new System.EventHandler(this.Details_Button_Click);
            // 
            // ExtractionSetUp_Button
            // 
            this.ExtractionSetUp_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ExtractionSetUp_Button.Location = new System.Drawing.Point(440, 0);
            this.ExtractionSetUp_Button.Name = "ExtractionSetUp_Button";
            this.ExtractionSetUp_Button.Size = new System.Drawing.Size(130, 27);
            this.ExtractionSetUp_Button.TabIndex = 8;
            this.ExtractionSetUp_Button.Text = "���o���@�ݒ�(&S)";
            this.ExtractionSetUp_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ExtractionSetUp_Button.Click += new System.EventHandler(this.ExtractionSetUp_Button_Click);
            // 
            // ViewButtonPanel
            // 
            this.ViewButtonPanel.BackColor = System.Drawing.Color.GhostWhite;
            this.ViewButtonPanel.Controls.Add(this.ExtractionSetUp_Button);
            this.ViewButtonPanel.Controls.Add(this.Details_Button);
            this.ViewButtonPanel.Controls.Add(this.Delete_Button);
            this.ViewButtonPanel.Controls.Add(this.New_Button);
            this.ViewButtonPanel.Controls.Add(this.Modify_Button);
            this.ViewButtonPanel.Controls.Add(this.Close_Button);
            this.ViewButtonPanel.Controls.Add(this.Print_Button);
            this.ViewButtonPanel.Location = new System.Drawing.Point(0, 120);
            this.ViewButtonPanel.Name = "ViewButtonPanel";
            this.ViewButtonPanel.Size = new System.Drawing.Size(757, 27);
            this.ViewButtonPanel.TabIndex = 1;
            this.ViewButtonPanel.Visible = false;
            // 
            // DetailsPanel
            // 
            this.DetailsPanel.Controls.Add(this.DetailsGrid);
            this.DetailsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DetailsPanel.Location = new System.Drawing.Point(0, 370);
            this.DetailsPanel.Name = "DetailsPanel";
            this.DetailsPanel.Size = new System.Drawing.Size(759, 300);
            this.DetailsPanel.TabIndex = 3;
            // 
            // DetailsGrid
            // 
            this.DetailsGrid.Cursor = System.Windows.Forms.Cursors.Default;
            appearance5.BackColor = System.Drawing.Color.White;
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.DetailsGrid.DisplayLayout.Appearance = appearance5;
            this.DetailsGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.DetailsGrid.DisplayLayout.GroupByBox.Hidden = true;
            this.DetailsGrid.DisplayLayout.InterBandSpacing = 10;
            this.DetailsGrid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.DetailsGrid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.DetailsGrid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.DetailsGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.DetailsGrid.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.DetailsGrid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.DetailsGrid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.ForeColor = System.Drawing.Color.White;
            appearance6.TextHAlignAsString = "Left";
            appearance6.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.DetailsGrid.DisplayLayout.Override.HeaderAppearance = appearance6;
            this.DetailsGrid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
            appearance7.BorderColor = System.Drawing.Color.White;
            this.DetailsGrid.DisplayLayout.Override.RowAppearance = appearance7;
            this.DetailsGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.DetailsGrid.DisplayLayout.Override.RowSelectorWidth = 12;
            this.DetailsGrid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Sychronized;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance8.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance8.ForeColor = System.Drawing.Color.Black;
            this.DetailsGrid.DisplayLayout.Override.SelectedRowAppearance = appearance8;
            this.DetailsGrid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.DetailsGrid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.DetailsGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.DetailsGrid.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.DetailsGrid.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.DetailsGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.DetailsGrid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.DetailsGrid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.DetailsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailsGrid.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DetailsGrid.Location = new System.Drawing.Point(0, 0);
            this.DetailsGrid.Name = "DetailsGrid";
            this.DetailsGrid.Size = new System.Drawing.Size(759, 300);
            this.DetailsGrid.TabIndex = 1;
            this.DetailsGrid.TabStop = false;
            this.DetailsGrid.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.DetailsGrid_AfterSelectChange);
            this.DetailsGrid.DoubleClick += new System.EventHandler(this.DetailsGrid_DoubleClick);
            this.DetailsGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grid_KeyDown);
            // 
            // DetailsSplitter
            // 
            this.DetailsSplitter.BackColor = System.Drawing.Color.Gainsboro;
            this.DetailsSplitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DetailsSplitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DetailsSplitter.Location = new System.Drawing.Point(0, 362);
            this.DetailsSplitter.Name = "DetailsSplitter";
            this.DetailsSplitter.Size = new System.Drawing.Size(759, 8);
            this.DetailsSplitter.TabIndex = 4;
            this.DetailsSplitter.TabStop = false;
            // 
            // DataViewGrid
            // 
            this.DataViewGrid.Cursor = System.Windows.Forms.Cursors.Default;
            appearance9.BackColor = System.Drawing.Color.White;
            appearance9.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.DataViewGrid.DisplayLayout.Appearance = appearance9;
            this.DataViewGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.DataViewGrid.DisplayLayout.GroupByBox.Hidden = true;
            this.DataViewGrid.DisplayLayout.InterBandSpacing = 10;
            this.DataViewGrid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.DataViewGrid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.DataViewGrid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.DataViewGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.DataViewGrid.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.DataViewGrid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance10.BackColor = System.Drawing.Color.Transparent;
            this.DataViewGrid.DisplayLayout.Override.CardAreaAppearance = appearance10;
            this.DataViewGrid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance11.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance11.ForeColor = System.Drawing.Color.White;
            appearance11.TextHAlignAsString = "Left";
            appearance11.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.DataViewGrid.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.DataViewGrid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            appearance12.BackColor = System.Drawing.Color.Lavender;
            this.DataViewGrid.DisplayLayout.Override.RowAlternateAppearance = appearance12;
            appearance13.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.DataViewGrid.DisplayLayout.Override.RowAppearance = appearance13;
            this.DataViewGrid.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.DataViewGrid.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance14.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance14.ForeColor = System.Drawing.Color.White;
            this.DataViewGrid.DisplayLayout.Override.RowSelectorAppearance = appearance14;
            this.DataViewGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.DataViewGrid.DisplayLayout.Override.RowSelectorWidth = 12;
            this.DataViewGrid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance15.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance15.ForeColor = System.Drawing.Color.Black;
            this.DataViewGrid.DisplayLayout.Override.SelectedRowAppearance = appearance15;
            this.DataViewGrid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.DataViewGrid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.DataViewGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.DataViewGrid.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.DataViewGrid.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.DataViewGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.DataViewGrid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.DataViewGrid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.DataViewGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataViewGrid.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DataViewGrid.Location = new System.Drawing.Point(0, 0);
            this.DataViewGrid.Name = "DataViewGrid";
            this.DataViewGrid.Size = new System.Drawing.Size(759, 281);
            this.DataViewGrid.TabIndex = 0;
            this.DataViewGrid.AfterRowFilterChanged += new Infragistics.Win.UltraWinGrid.AfterRowFilterChangedEventHandler(this.DataViewGrid_AfterRowFilterChanged);
            this.DataViewGrid.DoubleClick += new System.EventHandler(this.DataViewGrid_DoubleClick);
            this.DataViewGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grid_KeyDown);
            this.DataViewGrid.AfterSortChange += new Infragistics.Win.UltraWinGrid.BandEventHandler(this.DataViewGrid_AfterSortChange);
            // 
            // BindDataSet
            // 
            this.BindDataSet.DataSetName = "NewDataSet";
            this.BindDataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // DataViewPanel
            // 
            this.DataViewPanel.Controls.Add(this.DataViewGrid);
            this.DataViewPanel.Controls.Add(this.DataView_StatusBar);
            this.DataViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataViewPanel.Location = new System.Drawing.Point(0, 54);
            this.DataViewPanel.Name = "DataViewPanel";
            this.DataViewPanel.Size = new System.Drawing.Size(759, 308);
            this.DataViewPanel.TabIndex = 5;
            // 
            // DataView_StatusBar
            // 
            appearance16.FontData.SizeInPoints = 9F;
            this.DataView_StatusBar.Appearance = appearance16;
            this.DataView_StatusBar.Controls.Add(this.AutoFillToColumn_CheckEditor);
            this.DataView_StatusBar.Controls.Add(this.DeleteIndication_CheckEditor);
            this.DataView_StatusBar.Controls.Add(this.SearchCount_tNedit);
            this.DataView_StatusBar.InterPanelSpacing = 0;
            this.DataView_StatusBar.Location = new System.Drawing.Point(0, 281);
            this.DataView_StatusBar.Name = "DataView_StatusBar";
            ultraStatusPanel1.Control = this.AutoFillToColumn_CheckEditor;
            ultraStatusPanel1.Key = "AutoFillToColumn_StatusPanel";
            ultraStatusPanel1.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel1.Width = 140;
            ultraStatusPanel2.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel2.Key = "Dummy1_StatusPanel";
            ultraStatusPanel2.Width = 5;
            ultraStatusPanel3.Key = "Line1_StatusPanel";
            ultraStatusPanel3.Width = 1;
            ultraStatusPanel4.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel4.Key = "Dummy2_StatusPanel";
            ultraStatusPanel4.Width = 5;
            ultraStatusPanel5.Control = this.DeleteIndication_CheckEditor;
            ultraStatusPanel5.Key = "DeleteIndication_StatusPanel";
            ultraStatusPanel5.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel5.Width = 150;
            ultraStatusPanel6.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel6.Key = "Dummy3_StatusPanel";
            ultraStatusPanel6.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel6.Width = 5;
            ultraStatusPanel7.Key = "Line2_StatusPanel";
            ultraStatusPanel7.Width = 1;
            ultraStatusPanel8.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel8.Key = "Dummy4_StatusPanel";
            ultraStatusPanel8.Width = 5;
            appearance17.FontData.ItalicAsString = "False";
            ultraStatusPanel9.Appearance = appearance17;
            ultraStatusPanel9.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel9.Key = "ExtractionSituation_StatusPanel";
            appearance18.FontData.BoldAsString = "False";
            appearance18.FontData.SizeInPoints = 10F;
            ultraStatusPanel9.ProgressBarInfo.Appearance = appearance18;
            appearance19.FontData.BoldAsString = "True";
            appearance19.FontData.SizeInPoints = 9F;
            appearance19.ForeColor = System.Drawing.Color.Black;
            ultraStatusPanel9.ProgressBarInfo.FillAppearance = appearance19;
            ultraStatusPanel9.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Progress;
            ultraStatusPanel9.Width = 158;
            appearance20.TextHAlignAsString = "Right";
            ultraStatusPanel10.Appearance = appearance20;
            ultraStatusPanel10.Key = "ExtractionMessage_StatusPanel";
            ultraStatusPanel10.Visible = false;
            ultraStatusPanel10.Width = 158;
            ultraStatusPanel11.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel11.Key = "Dummy5_StatusPanel";
            ultraStatusPanel11.Width = 3;
            appearance21.Image = 8;
            appearance21.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance21.TextHAlignAsString = "Center";
            appearance21.TextVAlignAsString = "Middle";
            ultraStatusPanel12.Appearance = appearance21;
            ultraStatusPanel12.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel12.Key = "Stop_StatusPanel";
            ultraStatusPanel12.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Button;
            ultraStatusPanel12.Text = "���f";
            ultraStatusPanel12.Width = 60;
            ultraStatusPanel13.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel13.Key = "Dummy6_StatusPanel";
            ultraStatusPanel13.Width = 5;
            ultraStatusPanel14.Key = "Line3_StatusPanel";
            ultraStatusPanel14.Width = 1;
            ultraStatusPanel15.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel15.Key = "Dummy7_StatusPanel";
            ultraStatusPanel15.Width = 3;
            ultraStatusPanel16.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel16.Key = "SearchCountMessage1_StatusPanel";
            ultraStatusPanel16.Text = "����";
            ultraStatusPanel16.Width = 30;
            ultraStatusPanel17.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel17.Control = this.SearchCount_tNedit;
            ultraStatusPanel17.Key = "SearchCount_StatusPanel";
            ultraStatusPanel17.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel17.Width = 40;
            ultraStatusPanel18.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel18.Key = "SearchCountMessage2_StatusPanel";
            ultraStatusPanel18.Text = "���𒊏o����";
            ultraStatusPanel18.Width = 80;
            appearance22.TextHAlignAsString = "Center";
            ultraStatusPanel19.Appearance = appearance22;
            ultraStatusPanel19.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel19.Key = "Execute_StatusPanel";
            ultraStatusPanel19.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Button;
            ultraStatusPanel19.Text = "���s";
            ultraStatusPanel19.Width = 60;
            this.DataView_StatusBar.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
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
            ultraStatusPanel17,
            ultraStatusPanel18,
            ultraStatusPanel19});
            this.DataView_StatusBar.ResizeStyle = Infragistics.Win.UltraWinStatusBar.ResizeStyle.None;
            this.DataView_StatusBar.Size = new System.Drawing.Size(759, 27);
            this.DataView_StatusBar.TabIndex = 2;
            this.DataView_StatusBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            this.DataView_StatusBar.ButtonClick += new Infragistics.Win.UltraWinStatusBar.PanelEventHandler(this.DataView_StatusBar_ButtonClick);
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
            this.ultraToolbarsManager1.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            appearance23.BackColor = System.Drawing.Color.GhostWhite;
            this.ultraToolbarsManager1.Appearance = appearance23;
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
            controlContainerTool2.ControlName = "New_Button";
            controlContainerTool3.ControlName = "Delete_Button";
            controlContainerTool4.ControlName = "Modify_Button";
            controlContainerTool5.ControlName = "Print_Button";
            controlContainerTool6.ControlName = "Details_Button";
            controlContainerTool7.ControlName = "ExtractionSetUp_Button";
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            controlContainerTool1,
            controlContainerTool2,
            controlContainerTool3,
            controlContainerTool4,
            controlContainerTool5,
            controlContainerTool6,
            labelTool1,
            controlContainerTool7});
            ultraToolbar1.Text = "�W��";
            this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            controlContainerTool8.ControlName = "Close_Button";
            controlContainerTool8.SharedProps.Caption = "Close_ControlContainerTool";
            controlContainerTool9.ControlName = "New_Button";
            controlContainerTool9.SharedProps.Caption = "New_ControlContainerTool";
            controlContainerTool10.ControlName = "Delete_Button";
            controlContainerTool10.SharedProps.Caption = "Delete_ControlContainerTool";
            controlContainerTool11.ControlName = "Modify_Button";
            controlContainerTool11.SharedProps.Caption = "Modify_ControlContainerTool";
            controlContainerTool12.ControlName = "Print_Button";
            controlContainerTool12.SharedProps.Caption = "Print_ControlContainerTool";
            controlContainerTool13.ControlName = "Details_Button";
            controlContainerTool13.SharedProps.Caption = "Details_ControlContainerTool";
            labelTool2.SharedProps.Spring = true;
            labelTool2.SharedProps.Width = 0;
            controlContainerTool14.ControlName = "ExtractionSetUp_Button";
            controlContainerTool14.SharedProps.Caption = "ExtractionSetUp_ControlContainerTool";
            this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            controlContainerTool8,
            controlContainerTool9,
            controlContainerTool10,
            controlContainerTool11,
            controlContainerTool12,
            controlContainerTool13,
            labelTool2,
            controlContainerTool14});
            this.ultraToolbarsManager1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.ultraToolbarsManager1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // _SFCMN09000UC_Toolbars_Dock_Area_Left
            // 
            this._SFCMN09000UC_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFCMN09000UC_Toolbars_Dock_Area_Left.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            this._SFCMN09000UC_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.GhostWhite;
            this._SFCMN09000UC_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._SFCMN09000UC_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFCMN09000UC_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 54);
            this._SFCMN09000UC_Toolbars_Dock_Area_Left.Name = "_SFCMN09000UC_Toolbars_Dock_Area_Left";
            this._SFCMN09000UC_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 616);
            this._SFCMN09000UC_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _SFCMN09000UC_Toolbars_Dock_Area_Right
            // 
            this._SFCMN09000UC_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFCMN09000UC_Toolbars_Dock_Area_Right.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            this._SFCMN09000UC_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.GhostWhite;
            this._SFCMN09000UC_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._SFCMN09000UC_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFCMN09000UC_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(759, 54);
            this._SFCMN09000UC_Toolbars_Dock_Area_Right.Name = "_SFCMN09000UC_Toolbars_Dock_Area_Right";
            this._SFCMN09000UC_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 616);
            this._SFCMN09000UC_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _SFCMN09000UC_Toolbars_Dock_Area_Top
            // 
            this._SFCMN09000UC_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFCMN09000UC_Toolbars_Dock_Area_Top.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            this._SFCMN09000UC_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.GhostWhite;
            this._SFCMN09000UC_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._SFCMN09000UC_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFCMN09000UC_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._SFCMN09000UC_Toolbars_Dock_Area_Top.Name = "_SFCMN09000UC_Toolbars_Dock_Area_Top";
            this._SFCMN09000UC_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(759, 54);
            this._SFCMN09000UC_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _SFCMN09000UC_Toolbars_Dock_Area_Bottom
            // 
            this._SFCMN09000UC_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFCMN09000UC_Toolbars_Dock_Area_Bottom.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            this._SFCMN09000UC_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.GhostWhite;
            this._SFCMN09000UC_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._SFCMN09000UC_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFCMN09000UC_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 670);
            this._SFCMN09000UC_Toolbars_Dock_Area_Bottom.Name = "_SFCMN09000UC_Toolbars_Dock_Area_Bottom";
            this._SFCMN09000UC_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(759, 0);
            this._SFCMN09000UC_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // SFCMN09000UC
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(759, 670);
            this.Controls.Add(this.ViewButtonPanel);
            this.Controls.Add(this.DataViewPanel);
            this.Controls.Add(this.DetailsSplitter);
            this.Controls.Add(this.DetailsPanel);
            this.Controls.Add(this._SFCMN09000UC_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._SFCMN09000UC_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._SFCMN09000UC_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._SFCMN09000UC_Toolbars_Dock_Area_Bottom);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SFCMN09000UC";
            this.Load += new System.EventHandler(this.SFCMN09000UC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SearchCount_tNedit)).EndInit();
            this.ViewButtonPanel.ResumeLayout(false);
            this.DetailsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DetailsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataViewGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindDataSet)).EndInit();
            this.DataViewPanel.ResumeLayout(false);
            this.DataView_StatusBar.ResumeLayout(false);
            this.DataView_StatusBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Private Members
		private int _totalCount = 0;
		private bool _detailFlg = false;
		private bool _underExtractionFlg = false;
		private bool _nextSearchFlg;
		private string _tableName;
		private SFCMN09000UA _owningForm;
		private Hashtable _appearanceTable;
		private ProgramItem _programItemObj;
		private IMasterMaintenanceMultiType _multiTypeObj;
		private ExtractionSetUpType _extractionSetUpType;

        // --- ADD 2008/09/01 ���쌠���ɉ������{�^������̑Ή� ---------->>>>>
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
        /// <summary>�ڍ׃c�[���{�^���̃L�[</summary>
        private const string DETAILS_TOOL_BUTTON_KEY = "Details_ControlContainerTool";
        /// <summary>���o���@�ݒ�c�[���{�^���̃L�[</summary>
        private const string SETUP_TOOL_BUTTON_KEY = "ExtractionSetUp_ControlContainerTool";

        #region <�t�H�[���ҏW�p/>
        // ADD 2009/03/26 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ---------->>>>>
    #if CAN_EDIT_FORM
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
    #endif
        // ADD 2008/03/26 �s��Ή�[12719]�F�u�폜�σf�[�^�̕\���v�͍ŏ�ʍ��ڂŐ��� ----------<<<<<
        #endregion  // <�t�H�[���ҏW�p/>
        // --- ADD 2008/09/01 ���쌠���ɉ������{�^������̑Ή� ----------<<<<<
		#endregion

		# region Properties
		/// <summary>���o�Ώی����v���p�e�B</summary>
		/// <value>���o�Ώی������擾�܂��͐ݒ肵�܂��B</value>
		internal int SearchCount
		{
			get{ return this.SearchCount_tNedit.GetInt(); }
			set{ this.SearchCount_tNedit.SetInt(value); }
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
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		internal void ShowMe(SFCMN09000UA owningForm, ProgramItem programItemObj)
		{
			this._owningForm = owningForm;
			this._programItemObj = programItemObj;
			this._multiTypeObj = (IMasterMaintenanceMultiType)programItemObj.CustomForm;
			this.Show();
		}

		/// <summary>
		/// �O���b�h��^�C�g�����X�g�擾����
		/// </summary>
		/// <returns>�O���b�h��^�C�g�����X�g</returns>
		/// <remarks>
		/// <br>Note       : �ꗗ�\���p�O���b�h�ɕ\������Ă����̃^�C�g��(Key)��
		///					 ArrayList�Ɋi�[���ĕԂ��܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		internal ArrayList GetColKeyList()
		{
			ArrayList list = new ArrayList();

			for (int i = 0; i < this.DataViewGrid.DisplayLayout.Bands[0].Columns.Count; i++)
			{
				if (this.DataViewGrid.DisplayLayout.Bands[0].Columns[i].Hidden == false)
				{
					list.Add(this.DataViewGrid.DisplayLayout.Bands[0].Columns[i].Key.ToString());
				}
			}

			return list;
		}

		/// <summary>
		/// �O���b�h�e�L�X�g��������
		/// </summary>
		/// <param name="columnKey">�O���b�h�̌����Ώۗ񖼏�</param>
		/// <param name="searchString">����������</param>
		/// <remarks>
		/// <br>Note       : ������columnKey�ƈ�v���錟���Ώۗ���������A
		///					 ����������(searchString)�Ɉ�v����s�����݂���
		///					 �ꍇ�͂��̍s���A�N�e�B�u�ɂ��܂��B
		///					 ������columnKey�ƈ�v����񂪑��݂��Ȃ��ꍇ�́A
		///					 �S�Ă̗�������ΏۂƂ��܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		internal void GridTextSearch(string columnKey, string searchString)
		{
			this.Cursor = Cursors.WaitCursor;
			bool checkFlg = false;

			// ���ɃA�N�e�B�u�s�����݂���ꍇ�͂��̍s����A�����łȂ��ꍇ��
			// �ŏ��̍s���A�N�e�B�u�ɐݒ肵�A�������J�n����
			Infragistics.Win.UltraWinGrid.UltraGridRow oRow = this.DataViewGrid.ActiveRow;
			if (oRow == null)
			{
				oRow = this.DataViewGrid.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.First);
			}

			// Row�I�u�W�F�N�g��GetSibling ���\�b�h���g�p���Ċe�s���J��Ԃ�
			// �`�F�b�N���A�Y���s������������
			while (oRow != null)
			{
				oRow = oRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next);

				if (this.MatchText(oRow, columnKey, searchString))
				{
					this.DataViewGrid.ActiveRow = oRow;
					this.DataViewGrid.ActiveRow.Selected = true;
					this.DataViewGrid.Refresh();

					checkFlg = true;
					break;
				}
			}

			if (!checkFlg)
			{
				oRow = this.DataViewGrid.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.First);

				// ���g���C
				while (oRow != null)
				{
					if (this.MatchText(oRow, columnKey, searchString))
					{
						this.DataViewGrid.ActiveRow = oRow;
						this.DataViewGrid.ActiveRow.Selected = true;
						this.DataViewGrid.Refresh();

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
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		internal void ViewFormClose()
		{
			Close_Button_Click(this, null);
		}
		# endregion

		# region Private Methods
		/// <summary>
		///  ��ʏ�������
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʋN�����̏����������s���܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private void InitialDisplay()
		{
			// �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Close_Button.ImageList = imageList16;
			this.New_Button.ImageList = imageList16;
			this.Delete_Button.ImageList = imageList16;
			this.Modify_Button.ImageList = imageList16;
			this.Details_Button.ImageList = imageList16;
			this.Print_Button.ImageList = imageList16;
			this.ExtractionSetUp_Button.ImageList = imageList16;
			this.ExtractionSetUp_Button.ImageList = imageList16;

			this.Close_Button.Appearance.Image = Size16_Index.CLOSE;
			this.New_Button.Appearance.Image = Size16_Index.NEW;
			this.Delete_Button.Appearance.Image = Size16_Index.DELETE;
			this.Modify_Button.Appearance.Image = Size16_Index.MODIFY;
			this.Details_Button.Appearance.Image = Size16_Index.DETAILS;
			this.Print_Button.Appearance.Image = Size16_Index.PRINT;
			this.ExtractionSetUp_Button.Appearance.Image = Size16_Index.SETUP1;
			this.DataView_StatusBar.Panels["Stop_StatusPanel"].Appearance.Image = Size16_Index.INTERRUPTION;

			// �ڍו\���p�R���|�[�l���g���\���Ƃ���
			this.DetailsPanel.Visible = false;
			this.DetailsSplitter.Visible = false;

			this.DetailsGrid.DisplayLayout.Bands[0].CardSettings.MaxCardAreaCols = 1;
			this.DetailsGrid.DisplayLayout.Bands[0].CardSettings.MaxCardAreaRows = 1;
			this.DetailsGrid.DisplayLayout.Bands[0].CardSettings.ShowCaption = false;
			this.DetailsGrid.DisplayLayout.Bands[0].CardSettings.AutoFit = true;
			this.DetailsGrid.DisplayLayout.Bands[0].CardView = true;

			MasterMaintenanceConstruction mmc = this._owningForm.GetConstructionTable(this._programItemObj.ClassID);
			this._extractionSetUpType = mmc.ExSetUpType;
			this.SearchCount = mmc.SearchCount;

			// �w�b�_���ƃt�b�^���̕\����\���ݒ���s��
			this.New_Button.Visible = this._multiTypeObj.CanNew;
			this.Delete_Button.Visible = this._multiTypeObj.CanDelete;
			this.Print_Button.Visible = this._multiTypeObj.CanPrint;
			this.ExtractionSetUp_Button.Visible = this._multiTypeObj.CanSpecificationSearch;
			this.ultraToolbarsManager1.Tools["New_ControlContainerTool"].SharedProps.Visible = this._multiTypeObj.CanNew;
			this.ultraToolbarsManager1.Tools["Delete_ControlContainerTool"].SharedProps.Visible = this._multiTypeObj.CanDelete;
			this.ultraToolbarsManager1.Tools["Print_ControlContainerTool"].SharedProps.Visible = this._multiTypeObj.CanPrint;
			this.ultraToolbarsManager1.Tools["ExtractionSetUp_ControlContainerTool"].SharedProps.Visible = this._multiTypeObj.CanSpecificationSearch;
			this.DataView_StatusBar.Panels["DeleteIndication_StatusPanel"].Visible = this._multiTypeObj.CanLogicalDeleteDataExtraction;

			if (this._extractionSetUpType == ExtractionSetUpType.SearchAuto)
			{
				// ���o�����w����\���Ƃ���
				this.DataView_StatusBar.Panels["SearchCountMessage1_StatusPanel"].Visible = false;
				this.DataView_StatusBar.Panels["SearchCountMessage2_StatusPanel"].Visible = false;
				this.DataView_StatusBar.Panels["SearchCount_StatusPanel"].Visible = false;
				this.DataView_StatusBar.Panels["Execute_StatusPanel"].Visible = false;
				this.DataView_StatusBar.Panels["Stop_StatusPanel"].Enabled = true;
			}
			else
			{
				// ���o�����w���\������
				this.DataView_StatusBar.Panels["SearchCountMessage1_StatusPanel"].Visible = true;
				this.DataView_StatusBar.Panels["SearchCountMessage2_StatusPanel"].Visible = true;
				this.DataView_StatusBar.Panels["SearchCount_StatusPanel"].Visible = true;
				this.DataView_StatusBar.Panels["Execute_StatusPanel"].Visible = true;
				this.DataView_StatusBar.Panels["Stop_StatusPanel"].Enabled = false;
			}

			this._multiTypeObj.UnDisplaying += new MasterMaintenanceMultiTypeUnDisplayingEventHandler(this.MasterMaintenance_UnDisplaying);
			((Form)this._multiTypeObj).VisibleChanged +=new EventHandler(this.SFCMN09000UC_VisibleChanged);

			// �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾����			
			DataSet bindDataSet = new DataSet();

			this._multiTypeObj.GetBindDataSet(ref bindDataSet, ref this._tableName);
			this.BindDataSet = bindDataSet;
		}
			
		/// <summary>
		/// �f�[�^�r���[�p�O���b�h�����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : �O���b�h�̏����ݒ���s���܂��B
		///					 �i�\����\���A�\�����ʒu�A�t�H�[�}�b�g�A�t�H���g�F�A�t�B���^�j</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private void GridInitialSetting()
		{
			for (int i = 0; i < this.BindDataSet.Tables[this._tableName].Columns.Count; i++)
			{
				GridColAppearance appearance = (GridColAppearance)this._appearanceTable[this.BindDataSet.Tables[this._tableName].Columns[i].Caption];
				
				// �O���b�h��̕\����\���ݒ菈��
				GridColHidden(i, appearance.GridColDispType);

				// �l�̕\�����ʒu��ݒ肷��
				switch (appearance.CellTextAlign)
				{
					case ContentAlignment.TopLeft:
					case ContentAlignment.MiddleLeft:
					case ContentAlignment.BottomLeft:
					{
						this.DataViewGrid.DisplayLayout.Bands[0].Columns[i].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/10 DEL
                        //this.DetailsGrid.DisplayLayout.Bands[0].Columns[i].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/10 DEL
						break;
					}
					case ContentAlignment.TopCenter:
					case ContentAlignment.MiddleCenter:
					case ContentAlignment.BottomCenter:
					{
						this.DataViewGrid.DisplayLayout.Bands[0].Columns[i].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/10 DEL
                        //this.DetailsGrid.DisplayLayout.Bands[0].Columns[i].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/10 DEL
						break;
					}
					case ContentAlignment.TopRight:
					case ContentAlignment.MiddleRight:
					case ContentAlignment.BottomRight:
					{
						this.DataViewGrid.DisplayLayout.Bands[0].Columns[i].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/10 DEL
                        //this.DetailsGrid.DisplayLayout.Bands[0].Columns[i].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/10 DEL
						break;
					}
				}
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/10 ADD
                // �ڍו����͏�ɍ��l��(Align�����ڂ��Ƃɕς��ƌ��Â炢��)
                this.DetailsGrid.DisplayLayout.Bands[0].Columns[i].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/10 ADD

				// �l�̃t�H�[�}�b�g��ݒ肷��
				if ((appearance.Format != "") && (appearance.Format != null))
				{
					this.DataViewGrid.DisplayLayout.Bands[0].Columns[i].Format = appearance.Format;
					this.DetailsGrid.DisplayLayout.Bands[0].Columns[i].Format = appearance.Format;
				}

				// ��̃t�H���g�F��ݒ肷��
				this.DataViewGrid.DisplayLayout.Bands[0].Columns[i].CellAppearance.ForeColor = appearance.ColFontColor;
				this.DetailsGrid.DisplayLayout.Bands[0].Columns[i].CellAppearance.ForeColor = appearance.ColFontColor;

				// �O���b�h�̃t�B���^�����O����
				AddGridFiltering();
			}
		}

		/// <summary>
		/// �O���b�h��̕\����\���ݒ菈��
		/// </summary>
		/// <param name="colDispType">�O���b�h��̕\���^�C�v</param>
		/// <param name="index">�O���b�h��̃C���f�b�N�X</param>
		/// <remarks>
		/// <br>Note       : �O���b�h��̕\����\���ݒ���s���܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private void GridColHidden(int index, MGridColDispType colDispType)
		{
			switch (colDispType)
			{
				case MGridColDispType.None:
				{
					this.DataViewGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
					this.DetailsGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
					break;
				}
				case MGridColDispType.Both:
				{
					this.DataViewGrid.DisplayLayout.Bands[0].Columns[index].Hidden = false;
					this.DetailsGrid.DisplayLayout.Bands[0].Columns[index].Hidden = false;
					break;
				}
				case MGridColDispType.ListOnly:
				{
					this.DataViewGrid.DisplayLayout.Bands[0].Columns[index].Hidden = false;
					this.DetailsGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
					break;
				}
				case MGridColDispType.DetailsOnly:
				{
					this.DataViewGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
					this.DetailsGrid.DisplayLayout.Bands[0].Columns[index].Hidden = false;
					break;
				}
				case MGridColDispType.DeletionDataBoth:
				{
					if (DeleteIndication_CheckEditor.Checked == true)
					{
						this.DataViewGrid.DisplayLayout.Bands[0].Columns[index].Hidden = false;
						this.DetailsGrid.DisplayLayout.Bands[0].Columns[index].Hidden = false;
					}
					else
					{
						this.DataViewGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
						this.DetailsGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
					}
					break;
				}
				case MGridColDispType.DeletionDataListOnly:
				{
					if (DeleteIndication_CheckEditor.Checked == true)
					{
						this.DataViewGrid.DisplayLayout.Bands[0].Columns[index].Hidden = false;
						this.DetailsGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
					}
					else
					{
						this.DataViewGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
						this.DetailsGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
					}
					break;
				}
				case MGridColDispType.DeletionDataDetailsOnly:
				{
					if (DeleteIndication_CheckEditor.Checked == true)
					{
						this.DataViewGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
						this.DetailsGrid.DisplayLayout.Bands[0].Columns[index].Hidden = false;
					}
					else
					{
						this.DataViewGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
						this.DetailsGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
					}
					break;
				}
				default:
				{
					this.DataViewGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
					this.DetailsGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
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
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private void AddGridFiltering()
		{
			int index = -1;

			for (int i = 0; i < this.BindDataSet.Tables[this._tableName].Columns.Count; i++)
			{
				GridColAppearance appearance = (GridColAppearance)this._appearanceTable[this.BindDataSet.Tables[this._tableName].Columns[i].Caption];
				
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
				Infragistics.Win.UltraWinGrid.ColumnFiltersCollection columnFilters = this.DataViewGrid.DisplayLayout.Bands[0].ColumnFilters;
				columnFilters.ClearAllFilters();

				if (DeleteIndication_CheckEditor.Checked == false)
				{
					// �󔒂�Null�ȊO���t�B���^�ɐݒ肷��
					columnFilters[index].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, "");
					columnFilters[index].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, null);
					columnFilters[index].LogicalOperator = Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or;
				}

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/10 ADD
                // �s�t�B���^���o���h�Ɋ�Â��Ă���ꍇ�A�o���h�̗�t�B���^���O���B
                Infragistics.Win.UltraWinGrid.ColumnFiltersCollection columnFiltersOfDetail = this.DetailsGrid.DisplayLayout.Bands[0].ColumnFilters;
                columnFiltersOfDetail.ClearAllFilters();

                if ( DeleteIndication_CheckEditor.Checked == false )
                {
                    // �󔒂�Null�ȊO���t�B���^�ɐݒ肷��
                    columnFiltersOfDetail[index].FilterConditions.Add( Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, "" );
                    columnFiltersOfDetail[index].FilterConditions.Add( Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, null );
                    columnFiltersOfDetail[index].LogicalOperator = Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/10 ADD
			}
		}

		/// <summary>
		/// �e�L�X�g��v�`�F�b�N����
		/// </summary>
		/// <param name="userString">����������</param>
		/// <param name="cellValue">�����ΏۃZ���l</param>
		/// <remarks>
		/// <br>Note       : �O���b�h�̃Z���l�ƈ�������v���邩�ǂ������`�F�b�N���܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
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
		/// <remarks>
		/// <br>Note       : �����̍s�ɑ΂��āA�����Ώۗ�̃Z���̒l�ƈ�v����
		///					 ���ǂ������`�F�b�N���܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private bool MatchText(Infragistics.Win.UltraWinGrid.UltraGridRow oRow, string columnKey, string searchString)
		{
			if (oRow == null)
			{
				return false;
			}

			// �I������Ă�������������̂��S�Ă̗����������̂����m�F����
			bool bSearchAllColumns = true;
			if (this.DataViewGrid.DisplayLayout.Bands[0].Columns.Exists(columnKey))
			{
				bSearchAllColumns = false;
			}

			// �S�Ă̗����������ꍇ�A�s�̑S�ẴZ��������������
			// ���̏ꍇBands.Columns�R���N�V�������g�p���A��������}��
			if (bSearchAllColumns)
			{
				foreach(Infragistics.Win.UltraWinGrid.UltraGridColumn oCol in this.DataViewGrid.DisplayLayout.Bands[0].Columns)
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
				Infragistics.Win.UltraWinGrid.UltraGridColumn oCol = this.DataViewGrid.DisplayLayout.Bands[0].Columns[columnKey];
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
		/// �O���b�h�A�N�e�B�u�s�ݒ菈��
		/// </summary>
		/// <param name="targetGrid">����Ώ�Grid</param>
		/// <remarks>
		/// <br>Note       : �O���b�h�̃A�N�e�B�u�s���������A�I����Ԃɂ��܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
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
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private void MasterMaintenance_UnDisplaying(object sender, MasterMaintenanceUnDisplayingEventArgs me)
		{
			// ������DialogResult��OK�܂���Yes�̏ꍇ�́A�m�[�h�̃`�F�b�N�{�b�N�X��
			// �`�F�b�N��t����
			if ((me.DialogResult == DialogResult.OK) || (me.DialogResult == DialogResult.Yes))
			{
				// ���o�������������Ă���ꍇ�̂݁A���o�󋵕\�����������s����
				if (this.BindDataSet.Tables[this._tableName].DefaultView.Count == this._totalCount)
				{
					this._totalCount = this.BindDataSet.Tables[this._tableName].DefaultView.Count;
					this.SetExtractionSituation();
				}

				this._owningForm.TreeNodeCheckBoxChecked(this);
				this.StatusBarCountIndication();
			}

			// �O���b�h�A�N�e�B�u�s�ݒ菈��
			this.SetActiveRow(this.DataViewGrid);
		}

		/// <summary>
		/// ��ʕ\���ύX�㔭���C�x���g�p���\�b�h
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		/// <remarks>
		/// <br>Note       : �q��ʂ�Visible���ύX�ɂȂ�����ɔ������܂��B
		///					 �{�^���̗L�������`�F�b�N���s���܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private void SFCMN09000UC_VisibleChanged(object sender, EventArgs e)
		{
			if (((Form)this._multiTypeObj).Visible == true)
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
			}
		}

		/// <summary>
		/// ���o�󋵐ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : �����̌��ݒl�ƍ��v�l�����ɁA���o�󋵂�ݒ肵�܂��B
		///					 ���ݒl�ƍ��v�l����v�����ꍇ�́A���f�{�^�����u�����v
		///					 �ɕύX���܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private void SetExtractionSituation()
		{
			string message = "";
			
			// ���������v�����o���ʂƂȂ��Ă��܂����ꍇ�́A���v�ɒ��o���ʐ���
			// �i�[����i���o���ɐV�K�o�^���s�����ꍇ���ɔ����j
			if (this._totalCount < this.BindDataSet.Tables[this._tableName].DefaultView.Count)
			{
				this._totalCount = this.BindDataSet.Tables[this._tableName].DefaultView.Count;
			}

			this.DataView_StatusBar.Panels["ExtractionSituation_StatusPanel"].ProgressBarInfo.Maximum = this._totalCount;
			this.DataView_StatusBar.Panels["ExtractionSituation_StatusPanel"].ProgressBarInfo.Value = this.BindDataSet.Tables[this._tableName].DefaultView.Count;

			if ((this.BindDataSet.Tables[this._tableName].DefaultView.Count == this._totalCount) || (this.DataView_StatusBar.Panels["ExtractionMessage_StatusPanel"].Visible == true))
			{
				this.DataView_StatusBar.Panels["Stop_StatusPanel"].Enabled = false;
				this.DataView_StatusBar.Panels["Stop_StatusPanel"].Text = "����";
				this.DataView_StatusBar.Panels["Stop_StatusPanel"].Appearance.Image = null;

				this.DataView_StatusBar.Panels["ExtractionSituation_StatusPanel"].Visible = false;
				this.DataView_StatusBar.Panels["ExtractionMessage_StatusPanel"].Visible = true;
			}
			else
			{
				// ���o���̏ꍇ�A������ / ������ �̌`���ŕ\������
				message = this.BindDataSet.Tables[this._tableName].DefaultView.Count.ToString() + "�� / " + this._totalCount.ToString() + "��";

				if (this._extractionSetUpType == ExtractionSetUpType.SearchAuto)
				{
					this.DataView_StatusBar.Panels["Stop_StatusPanel"].Enabled = true;
				}
				else
				{
					this.DataView_StatusBar.Panels["Stop_StatusPanel"].Enabled = false;
				}

				this.DataView_StatusBar.Panels["ExtractionSituation_StatusPanel"].Visible = true;
				this.DataView_StatusBar.Panels["ExtractionMessage_StatusPanel"].Visible = false;
			}

			this.StatusBarCountIndication();
			this.DataView_StatusBar.Panels["ExtractionSituation_StatusPanel"].ProgressBarInfo.Label = message;
			this.DataView_StatusBar.Refresh();
		}

		/// <summary>
		/// �X�e�[�^�X�o�[�����\������
		/// </summary>
		/// <remarks>
		/// <br>Note       : �X�e�[�^�X�o�[�ɃO���b�h�̍s����\�����܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private void StatusBarCountIndication()
		{
			this.DataView_StatusBar.Panels["ExtractionMessage_StatusPanel"].Text = this.DataViewGrid.Rows.FilteredInRowCount.ToString() + "��";
		}

		/// <summary>
		/// �폜�f�[�^�`�F�b�N����
		/// </summary>
		/// <returns>true:�폜�\ false:�폜�s��</returns>
		/// <remarks>
		/// <br>Note       : �폜�f�[�^�̍폜�ς݃`�F�b�N���s���܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private bool DeleteDataCheck()
		{
			bool ret = true;
			int index = -1;

			for (int i = 0; i < this.BindDataSet.Tables[this._tableName].Columns.Count; i++)
			{
				GridColAppearance appearance = (GridColAppearance)this._appearanceTable[this.BindDataSet.Tables[this._tableName].Columns[i].Caption];
				
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
				if (this.DataViewGrid.ActiveRow.Cells[index].Text.Trim() != "") ret = false;
			}

			return ret;
		}
		# endregion

		# region Control Events

        /// <summary>
        /// ���쌠���̐�����J�n���܂��B
        /// </summary>
        /// <remarks>
        /// <br>Note       : ADD 2007/06/01 ���쌠���ɉ������{�^������̑Ή�</br>
        /// <br>Programmer : 30434 �H�� �b�D</br>
        /// <br>Date       : 2008.08.29</br>
        /// </remarks>
        private void BeginControllingByOperationAuthority()
        {
            // �{�^����ݒ�
            MyOpeCtrl.AddControlItem(MasMainFrameOpeCode.New,     this.New_Button,    true);
            MyOpeCtrl.AddControlItem(MasMainFrameOpeCode.Delete,  this.Delete_Button, true);
            MyOpeCtrl.AddControlItem(MasMainFrameOpeCode.Modify,  this.Modify_Button, false);
            MyOpeCtrl.AddControlItem(MasMainFrameOpeCode.Print,   this.Print_Button,  false);
            MyOpeCtrl.AddControlItem(MasMainFrameOpeCode.Details, this.Details_Button,false);

            // �c�[���o�[��ݒ�
            List<ToolButtonInfo> toolButtonInfoList = new List<ToolButtonInfo>();
            toolButtonInfoList.Add(new MasMainToolButtonInfo(NEW_TOOL_BUTTON_KEY,     MasMainFrameOpeCode.New,    true));
            toolButtonInfoList.Add(new MasMainToolButtonInfo(DELETE_TOOL_BUTTON_KEY,  MasMainFrameOpeCode.Delete, true));
            toolButtonInfoList.Add(new MasMainToolButtonInfo(MODIFY_TOOL_BUTTON_KEY,  MasMainFrameOpeCode.Modify, false));
            toolButtonInfoList.Add(new MasMainToolButtonInfo(PRINT_TOOL_BUTTON_KEY,   MasMainFrameOpeCode.Print,  false));
            toolButtonInfoList.Add(new MasMainToolButtonInfo(DETAILS_TOOL_BUTTON_KEY, MasMainFrameOpeCode.Details,false));
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
		/// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void SFCMN09000UC_Load(object sender, System.EventArgs e)
		{
			InitialDisplay();
			int totalCount = 0;

            BeginControllingByOperationAuthority(); // ADD 2008/09/01 ���쌠���ɉ������{�^������̑Ή�

			// �}���`���R�[�h�^�C�v��SearchAll���\�b�h�����s���A
			// �f�[�^�\�[�X���O���b�h�Ƀo�C���h������
			int status = this._multiTypeObj.Search(
				ref totalCount,
				this.SearchCount);

			switch (status)
			{
				case 0:
				{
					//this._totalCount = totalCount;
					this._totalCount = 0;

					break;
				}
				case 9:
				{
					//this._totalCount = totalCount;
					this._totalCount = 0;

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

			this.DataViewGrid.DataSource = this.BindDataSet.Tables[this._tableName].DefaultView;
			this.DetailsGrid.DataSource = this.BindDataSet.Tables[this._tableName].DefaultView;

			this._appearanceTable = this._multiTypeObj.GetAppearanceTable();
			this.GridInitialSetting();

			this.AutoFillToColumn_CheckEditor.Checked = false;
			this.AutoFillToColumn_CheckEditor.Checked = this._multiTypeObj.DefaultAutoFillToColumn;

			this.SetExtractionSituation();

			this.ActiveControl = this.DataViewGrid;

			if (this.DataViewGrid.Rows.Count > 0)
			{
				this.DataViewGrid.ActiveRow = this.DataViewGrid.Rows[0];
				this.DataViewGrid.ActiveRow.Selected = true;
			}

			// �S�����o�̏ꍇ�͔񓯊��Œ��o���������s����
			if ((this._extractionSetUpType == ExtractionSetUpType.SearchAuto) &&
				(this.SearchCount != 0))
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
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void New_Button_Click(object sender, System.EventArgs e)
		{
			if (this.ultraToolbarsManager1.Tools["New_ControlContainerTool"].SharedProps.Visible == false)
			{
				return;
			}

			this._multiTypeObj.DataIndex = -1;
			this._multiTypeObj.CanClose = false;

			Form customForm = (Form)this._multiTypeObj;
			customForm.StartPosition = FormStartPosition.CenterScreen;
			customForm.Owner = this._owningForm;

			// ���Ƀt�H�[�����\������Ă���ꍇ�́A��U�I��������
			if (customForm.Visible == true)
			{
				customForm.Hide();
			}

			customForm.Show();
		}

		/// <summary>
		/// Control.Click �C�x���g(Delete_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void Delete_Button_Click(object sender, System.EventArgs e)
		{
			if (this.ultraToolbarsManager1.Tools["Delete_ControlContainerTool"].SharedProps.Visible == false)
			{
				return;
			}

			if (DataViewGrid.ActiveRow == null)
			{
				return;
			}

			// �t�B���^�ŏ��O����Ă���s�̏ꍇ�͈ȉ��̏������L�����Z������
			if (this.DataViewGrid.ActiveRow.IsFilteredOut == true)
			{
				return;
			}

			if (!DeleteDataCheck())
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
				CurrencyManager cm = (CurrencyManager)BindingContext[this.DataViewGrid.DataSource];

				this._multiTypeObj.DataIndex = cm.Position;	

				// �f�[�^�̍폜���������s����
				int status = this._multiTypeObj.Delete();
				if (status != 0)
				{
					return;
				}

				this.AddGridFiltering();
				this.SetExtractionSituation();
			}
			this.StatusBarCountIndication();

			// �O���b�h�A�N�e�B�u�s�ݒ菈��
			this.SetActiveRow(this.DataViewGrid);
		}

		/// <summary>
		/// Control.Click �C�x���g(Modify_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �C���{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void Modify_Button_Click(object sender, System.EventArgs e)
		{
			if (this.ultraToolbarsManager1.Tools["Modify_ControlContainerTool"].SharedProps.Visible == false)
			{
				return;
			}

			if (DataViewGrid.ActiveRow == null)
			{
				return;
			}

			// �t�B���^�ŏ��O����Ă���s�̏ꍇ�͈ȉ��̏������L�����Z������
			if (this.DataViewGrid.ActiveRow.IsFilteredOut == true)
			{
				return;
			}

			CurrencyManager cm = (CurrencyManager)BindingContext[this.DataViewGrid.DataSource];

			this._multiTypeObj.DataIndex = cm. Position;
			this._multiTypeObj.CanClose = false;

			Form customForm = (Form)this._multiTypeObj;
			customForm.StartPosition = FormStartPosition.CenterScreen;
			customForm.Owner = this._owningForm;

			if (customForm.Visible == true)
			{
				customForm.Hide();
			}

			customForm.Show();
		}

		/// <summary>
		/// Control.Click �C�x���g(Details_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �ڍ׃{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void Details_Button_Click(object sender, System.EventArgs e)
		{
			if (this.ultraToolbarsManager1.Tools["Details_ControlContainerTool"].SharedProps.Visible == false)
			{
				return;
			}

			if (this._detailFlg == false)
			{
				this._detailFlg = true;

				this.DetailsPanel.Visible = true;
				this.DetailsSplitter.Visible = true;

				if (this.DataViewGrid.ActiveRow != null)
				{
					this.DetailsGrid.ActiveRow = this.DetailsGrid.Rows[this.DataViewGrid.ActiveRow.Index];
				}
			}
			else
			{
				this._detailFlg = false;

				this.DetailsPanel.Visible = false;
				this.DetailsSplitter.Visible = false;
			}
		}

		/// <summary>
		/// Control.Click �C�x���g(Print_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void Print_Button_Click(object sender, System.EventArgs e)
		{
			if (this.ultraToolbarsManager1.Tools["Print_ControlContainerTool"].SharedProps.Visible == false)
			{
				return;
			}

			this._multiTypeObj.Print();
		}

		/// <summary>
		/// Control.Click �C�x���g(Close_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		internal void Close_Button_Click(object sender, System.EventArgs e)
		{
			MasterMaintenanceConstruction mmc = this._owningForm.GetConstructionTable(this._programItemObj.ClassID);
			mmc.SearchCount = this.SearchCount_tNedit.GetInt();
			this._owningForm.ConstructionTableAdd(mmc.ToString(), mmc);

			this._nextSearchFlg = false;
			this.NextSearch_Timer.Enabled = false;

			Close_Timer.Enabled = true;
		}

		/// <summary>
		/// Control.Click �C�x���g(ExtractionSetUp_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���o���@�ݒ�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void ExtractionSetUp_Button_Click(object sender, System.EventArgs e)
		{
			if (this.ultraToolbarsManager1.Tools["ExtractionSetUp_ControlContainerTool"].SharedProps.Visible == false)
			{
				return;
			}

			SFCMN09000UD form = new SFCMN09000UD(this._extractionSetUpType);
			form.ShowDialog();

			if (form.DialogResult == DialogResult.OK)
			{
				MasterMaintenanceConstruction mmc = this._owningForm.GetConstructionTable(this._programItemObj.ClassID);
				mmc.ExSetUpType = form.GetExtractionSetUpType();
				this._owningForm.ConstructionTableAdd(mmc.ToString(), mmc);

				this._extractionSetUpType = form.GetExtractionSetUpType();

				if (this._extractionSetUpType == ExtractionSetUpType.SearchAuto)
				{

					if (this.DataView_StatusBar.Panels["ExtractionSituation_StatusPanel"].ProgressBarInfo.Maximum !=
						this.DataView_StatusBar.Panels["ExtractionSituation_StatusPanel"].ProgressBarInfo.Value)
					{
						// ���f�{�^�����ĊJ�ɂ���
						this.DataView_StatusBar.Panels["Stop_StatusPanel"].Text = "�ĊJ";
						this.DataView_StatusBar.Panels["Stop_StatusPanel"].Appearance.Image = Size16_Index.RETRY;
						this.DataView_StatusBar.Panels["Stop_StatusPanel"].Enabled = true;
					}
							
					// ���o�����w����\���Ƃ���
					this.DataView_StatusBar.Panels["SearchCountMessage1_StatusPanel"].Visible = false;
					this.DataView_StatusBar.Panels["SearchCountMessage2_StatusPanel"].Visible = false;
					this.DataView_StatusBar.Panels["SearchCount_StatusPanel"].Visible = false;
					this.DataView_StatusBar.Panels["Execute_StatusPanel"].Visible = false;
				}
				else
				{
					// ���o���̏ꍇ�́A���f�{�^�����N���b�N������
					if (this.DataView_StatusBar.Panels["ExtractionSituation_StatusPanel"].ProgressBarInfo.Maximum !=
						this.DataView_StatusBar.Panels["ExtractionSituation_StatusPanel"].ProgressBarInfo.Value)
					{
						this._nextSearchFlg = false;
						this.NextSearch_Timer.Enabled = false;
					}

					// ���o�����w���\������
					this.DataView_StatusBar.Panels["SearchCountMessage1_StatusPanel"].Visible = true;
					this.DataView_StatusBar.Panels["SearchCountMessage2_StatusPanel"].Visible = true;
					this.DataView_StatusBar.Panels["SearchCount_StatusPanel"].Visible = true;
					this.DataView_StatusBar.Panels["Execute_StatusPanel"].Visible = true;
					this.DataView_StatusBar.Panels["Stop_StatusPanel"].Enabled = false;
				}
			}
		}

		/// <summary>
		/// UltraWinGrid.AfterSortChange �C�x���g(DataViewGrid)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">Band�I�u�W�F�N�g�������Ƃ���C�x���g�Ŏg�p�����C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �O���b�h�̃\�[�g�A�N�V�����̊�����ɔ������܂��B
		///					�@�ꗗ�\���p�O���b�h�Əڍו\���p�O���b�h�̃\�[�g����A�������܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void DataViewGrid_AfterSortChange(object sender, Infragistics.Win.UltraWinGrid.BandEventArgs e)
		{
			Infragistics.Win.UltraWinGrid.UltraGridColumn column = 
				DetailsGrid.DisplayLayout.Bands[e.Band.Key].Columns[e.Band.SortedColumns[0].Key];

			if (column == null)
			{
				return;
			}

			column.SortIndicator = e.Band.SortedColumns[0].SortIndicator;

			// �I���s��擪�ɔz�u����
			if (this.DataViewGrid.Rows.Count > 0)
			{
				this.DataViewGrid.ActiveRow = this.DataViewGrid.Rows[0];
				this.DataViewGrid.ActiveRow.Selected = true;
				this.DataViewGrid.Refresh();
			}
		}

		/// <summary>
		/// UltraWinGrid.AfterRowFilterChanged �C�x���g(DataViewGrid)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">AfterRowFilterChanged�C�x���g�Ɏg�p�����C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���[�U�[�������ꂩ�̗�̍s�t�B���^��ύX������ɔ������܂��B
		///					�@�\���������v���O���X�o�[��ɕ\�������܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void DataViewGrid_AfterRowFilterChanged(object sender, Infragistics.Win.UltraWinGrid.AfterRowFilterChangedEventArgs e)
		{
			this.SetExtractionSituation();
		}

		/// <summary>
		/// UltraWinGrid.AfterSelectChange �C�x���g(DetailsGrid)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">AfterSelectChange�C�x���g�Ɏg�p�����C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �O���b�h�̂P�ȏ�̍s���I���܂��͑I���������ꂽ��ɔ������܂��B
		///					�@�ڍו\���p�O���b�h�ɂđI���f�[�^��ύX�����ꍇ�A�ꗗ�\���p�O���b�h��
		///					�@�I���s���A�����ĕύX�����Ă��܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void DetailsGrid_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
		{
			if (this.DetailsGrid.Selected.Rows.Count > 0)
			{
				// �P�x�̏������Ɛ���ɕ\������Ȃ��A�Q�x���������s���Ă܂�
				this.DataViewGrid.ActiveRow.Selected = true;
				this.DataViewGrid.Refresh();
				this.DataViewGrid.ActiveRow.Selected = true;
				this.DataViewGrid.Refresh();
			}
		}

		/// <summary>
		/// Control.DoubleClick �C�x���g(DataViewGrid)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �ꗗ�\���p�O���b�h�R���g���[�����_�u���N���b�N���ꂽ�Ƃ��ɔ������܂��B
		///					�@�Z�����_�u���N���b�N���ꂽ�ꍇ�A�ڍד��͉�ʂ�\�����܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void DataViewGrid_DoubleClick(object sender, System.EventArgs e)
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
		/// Control.DoubleClick �C�x���g(DetailsGrid)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �ڍו\���p�O���b�h�R���g���[�����_�u���N���b�N���ꂽ�Ƃ��ɔ������܂��B
		///					�@�Z�����_�u���N���b�N���ꂽ�ꍇ�A�ڍד��͉�ʂ�\�����܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void DetailsGrid_DoubleClick(object sender, System.EventArgs e)
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
		/// CheckEditor.CheckedChanged �C�x���g(AutoFillToColumn_CheckEditor)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ��̃T�C�Y��������������`�F�b�N�G�f�B�^�R���g���[����Checked
		///					�@�v���p�e�B���ύX�����Ƃ��ɔ������܂��B
		///					�@�O���b�h���AutoResize���\�b�h�����s���܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void AutoFillToColumn_CheckEditor_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.AutoFillToColumn_CheckEditor.Checked)
			{
				this.DataViewGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
			}
			else
			{
				this.DataViewGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
			}


			// �Z���̒l�Ɋ�Â��āA��̃T�C�Y��ύX����
			if (this.AutoFillToColumn_CheckEditor.Checked == false)
			{
				for (int i = 0; i < this.DataViewGrid.DisplayLayout.Bands[0].Columns.Count; i++)
				{
					this.DataViewGrid.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
				}
			}
		}

		/// <summary>
		/// Control.KeyDown �C�x���g(DataViewGrid/DetailsGrid)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">KeyDown �C�x���g�܂��� KeyUp �C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �ꗗ�\���p�O���b�h�R���g���[�����_�u���N���b�N���ꂽ�Ƃ��ɔ������܂��B
		///					�@�Z�����_�u���N���b�N���ꂽ�ꍇ�A�ڍד��͉�ʂ�\�����܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void Grid_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case (Keys.Return):
				{
					Modify_Button_Click(Modify_Button, e);

					break;
				}
			}
		}

		/// <summary>
		/// CheckEditor.CheckedChanged �C�x���g(DeleteIndication_CheckEditor)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �폜�ς݃f�[�^��\������`�F�b�N�G�f�B�^�R���g���[����Checked
		///					�@�v���p�e�B���ύX�����Ƃ��ɔ������܂��B
		///					�@�폜�ς݃f�[�^�̃t�B���^���������A�폜�ς݃f�[�^��\�����܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void DeleteIndication_CheckEditor_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.BindDataSet.Tables[this._tableName].DefaultView.Count == 0)
			{
				return;
			}

			for (int i = 0; i < this.BindDataSet.Tables[this._tableName].Columns.Count; i++)
			{
				GridColAppearance appearance = (GridColAppearance)this._appearanceTable[this.BindDataSet.Tables[this._tableName].Columns[i].Caption];
				
				// ��̕\����\���ݒ菈��
				GridColHidden(i, appearance.GridColDispType);
			}

			// �O���b�h�̃t�B���^�����O����
			this.AddGridFiltering();

			// ���o�󋵐ݒ菈��
			this.SetExtractionSituation();

			// �폜�f�[�^�\�����̂ݕ\��������̃T�C�Y��������������
			if (this.DeleteIndication_CheckEditor.Checked == true)
			{
				for (int i = 0; i < this.BindDataSet.Tables[this._tableName].Columns.Count; i++)
				{
					GridColAppearance appearance = (GridColAppearance)this._appearanceTable[this.BindDataSet.Tables[this._tableName].Columns[i].Caption];

					if ((appearance.GridColDispType == MGridColDispType.DeletionDataBoth) ||
						(appearance.GridColDispType == MGridColDispType.DeletionDataListOnly))
					{
						this.DataViewGrid.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
					}
				}
			}
		}

		/// <summary>
		/// UltraStatusBar.ButtonClick �C�x���g(DataView_StatusBar)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�P��UltraStatusPanel��n���C�x���g�Ɏg�p�����C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �X�e�[�^�X�o�[�R���g���[����Button�܂���StateButton
		///					�@�X�^�C����UltraSatusPanel�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void DataView_StatusBar_ButtonClick(object sender, Infragistics.Win.UltraWinStatusBar.PanelEventArgs e)
		{
			switch (e.Panel.Key)
			{
				case "Stop_StatusPanel":
				{
					if (e.Panel.Text == "���f")
					{
						this._nextSearchFlg = false;

						e.Panel.Text = "�ĊJ";
						e.Panel.Appearance.Image = Size16_Index.RETRY;
					}
					else if (e.Panel.Text == "�ĊJ")
					{
						this._nextSearchFlg = true;
						this.NextSearch_Timer.Enabled = true;

						e.Panel.Text = "���f";
						e.Panel.Appearance.Image = Size16_Index.INTERRUPTION;
					}

					break;
				}
				case "Execute_StatusPanel":
				{
					if (this.DataView_StatusBar.Panels["ExtractionSituation_StatusPanel"].ProgressBarInfo.Maximum !=
						this.DataView_StatusBar.Panels["ExtractionSituation_StatusPanel"].ProgressBarInfo.Value)
					{
						this._underExtractionFlg = true;

						// �l�N�X�g�f�[�^��������
						int status = this._multiTypeObj.SearchNext(this.SearchCount);

						try
						{
							switch (status)
							{
								case 0:
								{
									this.SetExtractionSituation();
									break;
								}
								case 9:
								{
									this._nextSearchFlg = false;
									this.SetExtractionSituation();

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

						// �I���s���ŏI�ɔz�u����
						this.DataViewGrid.ActiveRow = this.DataViewGrid.Rows[this.DataViewGrid.Rows.Count - 1];
						this.DataViewGrid.ActiveRow.Selected = true;
						this.DataViewGrid.Refresh();
					}

					break;
				}
			}
		}

		/// <summary>
		/// Timer.Tick �C�x���g(CloseTimer_Tick)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
		///					�@���̏����́A�V�X�e�����񋟂���X���b�h �v�[���X���b�h�Ŏ��s����܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void Close_Timer_Tick(object sender, System.EventArgs e)
		{
			this.Close_Timer.Enabled = false;

			if (this._underExtractionFlg == false)
			{	
				Form customForm = (Form)this._multiTypeObj;
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
		/// <br>Note�@�@�@  : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
		///					�@���̏����́A�V�X�e�����񋟂���X���b�h �v�[���X���b�h�Ŏ��s����܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void NextSearch_Timer_Tick(object sender, System.EventArgs e)
		{
			this.NextSearch_Timer.Enabled = false;
			this._underExtractionFlg = true;

			int status = this._multiTypeObj.SearchNext(this.SearchCount);

			try
			{
				switch (status)
				{
					case 0:
					{
						this.SetExtractionSituation();
						break;
					}
					case 9:
					{
						this._nextSearchFlg = false;
						this.SetExtractionSituation();
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
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/10 ADD
        /// <summary>
        /// �e�^�u���A�N�e�B�u�ɂȂ����ꍇ�̃t�H�[�J�X����
        /// </summary>
        public void SetFocusOnParentTabActive()
        {
            DataViewGrid.Focus();
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/10 ADD
    }
}

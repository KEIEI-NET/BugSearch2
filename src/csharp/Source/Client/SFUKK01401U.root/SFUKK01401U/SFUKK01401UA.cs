using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.IO;

using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win;
using Infragistics.Win.UltraWinTabControl;
using Broadleaf.Application.Controller.Facade;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �����`�[���̓��C���t���[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �����`�[���̓��C���t���[���N���X�ł��B</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2005.08.20</br>
    /// <br>Update Note: 2007.01.29 18322 T.Kimura MA.NS�p�ɕύX</br>
    /// <br>                                         1. ��ʃf�U�C���ύX</br>
    /// <br>             2007.05.14 18322 T.Kimura �̎����̑Ή����s���܂Łu�̎����v�{�^�����\���ɕύX</br>
    /// <br>             2008.02.20 20081 �D�c �E�l DC.NS�p�ɕύX(���_�擾���@��ύX)</br>
    /// <br>             2008.06.26 30414 �E �K�j Partsman�p�ɕύX(���_�擾���@��ύX)</br>
    /// <br>             2009.07.21 22008 ���� ���n  MANTIS 13287</br>
    /// <br>Update Note: 2012/12/24 ���N</br>
    /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
    /// <br>           : Redmine#33741�̑Ή�</br>
    /// <br>Update Note: 2013/02/05 �c����</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 2013/03/13�z�M��</br>
    /// <br>           : Redmine#33735 ��ʂ����Ƃ��A��O���N����Ή�</br>
    /// <br>Update Note: 2014/07/08 zhujw</br>
    /// <br>�Ǘ��ԍ�   : 11001635-00 </br>
    /// <br>           : Redmine#42902�̇G ������Q�̏C��</br>
    /// <br>Update Note: 2015/08/18 ����</br>
    /// <br>�Ǘ��ԍ�   : 11170129-00 �y��85�z�����`�[���͂̏�Q�Ή�</br>
    /// <br>           : Redmine#47016 �u�ŐV���v�{�^��������������A��ʃ^�C�v���X�g��ύX����ꍇ�A��O�G���[�̑Ή�</br>
    /// </remarks>
	public class SFUKK01401UA : Form
	{
		# region Private Members (Component)
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager Main_ToolbarsManager;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private System.Windows.Forms.Panel SlipSearch_Panel;
		private Infragistics.Win.UltraWinDock.UltraDockManager Main_DockManager;
		private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow1;
		private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea1;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _SFUKK01401UAUnpinnedTabAreaLeft;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _SFUKK01401UAUnpinnedTabAreaTop;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _SFUKK01401UAUnpinnedTabAreaBottom;
		private Infragistics.Win.UltraWinDock.UnpinnedTabArea _SFUKK01401UAUnpinnedTabAreaRight;
		private Infragistics.Win.UltraWinDock.AutoHideControl _SFUKK01401UAAutoHideControl;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFUKK01401UA_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFUKK01401UA_Toolbars_Dock_Area_Right;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFUKK01401UA_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFUKK01401UA_Toolbars_Dock_Area_Bottom;
		private System.Windows.Forms.Timer startTimer;
		private Infragistics.Win.UltraWinTabControl.UltraTabControl Main_UTabControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private TMemPos tMemPos1;
        private Infragistics.Win.Misc.UltraButton uButton_Close;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// �����`�[���̓��C���t���[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �g�p���郁���o�̏��������s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.20</br>
		/// </remarks>
		public SFUKK01401UA()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

			// --- �N���X�����o������ --- //
			this.depositRelDataAcs = new DepositRelDataAcs();				// �����`�[���͐ݒ�f�[�^�n�A�N�Z�X�N���X

			this._parameter = 1;											// MDI�\���p�����[�^
		
			this.selectedDispTypeItem = null;								// ���ݑI����ʃ^�C�v

			this.selectedSection = null;									// ���ݑI�����_

			this.selectDispTypeFlg = false;									// ��ʃ^�C�v�I�𒆃t���O

			this.selectedSectionFlg = false;								// ���_�I�𒆃t���O

			this._startingMode = StartingMode.Normal;						// �N�����[�h

			this._startingParameter = null;									// �N���p�����[�^

			this._dockMemoryStream = null;									// �E�B���h�E��ԕێ��p

			this._firstStartFlg = 0;										// ����N���t���O

            this._demandAddUpSecCd = string.Empty;                          // �����v�㋒�_�R�[�h

			// �ԍ��^�C�v�Ǘ��}�X�^���擾����(Thread)
			Thread SearchNoMngSetAcsThread = new Thread(new ThreadStart(SearchNoMngSetAcs));
			SearchNoMngSetAcsThread.Start();
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
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("a4832d9d-c5f9-4271-9cb2-b7c33d6c3bbb"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("25066978-2c70-4718-80f4-a985f619841e"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("a4832d9d-c5f9-4271-9cb2-b7c33d6c3bbb"), -1);
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFUKK01401UA));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance112 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("MainMenu_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("KYOTENNM");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool("SectionCode_l");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool("LOGINTITLE");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool5 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Button_UltraToolbar1");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnClose");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnNew");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnSave");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnDelete");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnAka");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnReceiptPrint");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnRenewal");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnReadslip");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar3 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Button_UltraToolbar2");
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboBoxTool1 = new Infragistics.Win.UltraWinToolbars.ComboBoxTool("DispTypeList");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnNew");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnSave");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnDelete");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnAka");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnReadslip");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnClose");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Window_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnInitWindow");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool6 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool7 = new Infragistics.Win.UltraWinToolbars.LabelTool("LOGINTITLE");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool8 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnClose");
            Infragistics.Win.UltraWinToolbars.MdiWindowListTool mdiWindowListTool1 = new Infragistics.Win.UltraWinToolbars.MdiWindowListTool("InputForm_MDIWindowListTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Main_ButtonTool");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboBoxTool2 = new Infragistics.Win.UltraWinToolbars.ComboBoxTool("DispTypeList");
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(0);
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnNew");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool19 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnSave");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool20 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnDelete");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool21 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnAka");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool9 = new Infragistics.Win.UltraWinToolbars.LabelTool("KYOTENNM");
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboBoxTool3 = new Infragistics.Win.UltraWinToolbars.ComboBoxTool("KYOTENCOMBO");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueList valueList2 = new Infragistics.Win.ValueList(0);
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool22 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnInitWindow");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool23 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnReceiptPrint");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool10 = new Infragistics.Win.UltraWinToolbars.LabelTool("SectionCode");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool11 = new Infragistics.Win.UltraWinToolbars.LabelTool("SectionCode_l");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenuTool_Edit");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool24 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnDelete");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool25 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnAka");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool26 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnRenewal");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool27 = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnReadslip");
            this.SlipSearch_Panel = new System.Windows.Forms.Panel();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Main_DockManager = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this.dockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this._SFUKK01401UAUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._SFUKK01401UAUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._SFUKK01401UAUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._SFUKK01401UAUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._SFUKK01401UAAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.startTimer = new System.Windows.Forms.Timer(this.components);
            this.Main_UTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.uButton_Close = new Infragistics.Win.Misc.UltraButton();
            this.tMemPos1 = new Broadleaf.Library.Windows.Forms.TMemPos(this.components);
            this.windowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this._SFUKK01401UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Main_ToolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._SFUKK01401UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFUKK01401UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFUKK01401UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).BeginInit();
            this.dockableWindow1.SuspendLayout();
            this._SFUKK01401UAAutoHideControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_UTabControl)).BeginInit();
            this.Main_UTabControl.SuspendLayout();
            this.ultraTabSharedControlsPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).BeginInit();
            this.SuspendLayout();
            // 
            // SlipSearch_Panel
            // 
            this.SlipSearch_Panel.BackColor = System.Drawing.Color.GhostWhite;
            this.SlipSearch_Panel.Location = new System.Drawing.Point(0, 27);
            this.SlipSearch_Panel.Name = "SlipSearch_Panel";
            this.SlipSearch_Panel.Size = new System.Drawing.Size(312, 621);
            this.SlipSearch_Panel.TabIndex = 0;
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 711);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            ultraStatusPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel1.Key = "Text";
            ultraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel2.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel2.Key = "Date";
            ultraStatusPanel2.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Date;
            ultraStatusPanel2.Width = 90;
            ultraStatusPanel3.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel3.Key = "Time";
            ultraStatusPanel3.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Time;
            ultraStatusPanel3.Width = 50;
            this.ultraStatusBar1.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3});
            this.ultraStatusBar1.Size = new System.Drawing.Size(1016, 23);
            this.ultraStatusBar1.TabIndex = 21;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Main_DockManager
            // 
            this.Main_DockManager.AnimationSpeed = Infragistics.Win.UltraWinDock.AnimationSpeed.StandardSpeedPlus5;
            this.Main_DockManager.AutoHideDelay = 50;
            this.Main_DockManager.CaptionStyle = Infragistics.Win.UltraWinDock.CaptionStyle.Office2003;
            // ----- ADD ���N 2012/12/24 Redmine#33741 ----->>>>>
            this.Main_DockManager.ShowCloseButton = false;
            // ----- ADD ���N 2012/12/24 Redmine#33741 -----<<<<<
            dockableControlPane1.Control = this.SlipSearch_Panel;
            dockableControlPane1.FlyoutSize = new System.Drawing.Size(312, -1);
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(40, 70, 270, 530);
            dockableControlPane1.Pinned = false;
            appearance1.FontData.SizeInPoints = 10F;
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            dockableControlPane1.Settings.Appearance = appearance1;
            dockableControlPane1.Settings.DoubleClickAction = Infragistics.Win.UltraWinDock.PaneDoubleClickAction.ToggleDockedState;
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "���Ӑ挟��";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(297, 648);
            this.Main_DockManager.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1});
            this.Main_DockManager.HostControl = this;
            this.Main_DockManager.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2003;
            // 
            // dockableWindow1
            // 
            this.dockableWindow1.Controls.Add(this.SlipSearch_Panel);
            this.dockableWindow1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.dockableWindow1.Name = "dockableWindow1";
            this.dockableWindow1.Owner = this.Main_DockManager;
            this.dockableWindow1.Size = new System.Drawing.Size(350, 648);
            this.dockableWindow1.TabIndex = 28;
            // 
            // _SFUKK01401UAUnpinnedTabAreaLeft
            // 
            this._SFUKK01401UAUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._SFUKK01401UAUnpinnedTabAreaLeft.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFUKK01401UAUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 63);
            this._SFUKK01401UAUnpinnedTabAreaLeft.Name = "_SFUKK01401UAUnpinnedTabAreaLeft";
            this._SFUKK01401UAUnpinnedTabAreaLeft.Owner = this.Main_DockManager;
            this._SFUKK01401UAUnpinnedTabAreaLeft.Size = new System.Drawing.Size(22, 648);
            this._SFUKK01401UAUnpinnedTabAreaLeft.TabIndex = 5;
            // 
            // _SFUKK01401UAUnpinnedTabAreaTop
            // 
            this._SFUKK01401UAUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._SFUKK01401UAUnpinnedTabAreaTop.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFUKK01401UAUnpinnedTabAreaTop.Location = new System.Drawing.Point(22, 63);
            this._SFUKK01401UAUnpinnedTabAreaTop.Name = "_SFUKK01401UAUnpinnedTabAreaTop";
            this._SFUKK01401UAUnpinnedTabAreaTop.Owner = this.Main_DockManager;
            this._SFUKK01401UAUnpinnedTabAreaTop.Size = new System.Drawing.Size(994, 0);
            this._SFUKK01401UAUnpinnedTabAreaTop.TabIndex = 7;
            // 
            // _SFUKK01401UAUnpinnedTabAreaBottom
            // 
            this._SFUKK01401UAUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._SFUKK01401UAUnpinnedTabAreaBottom.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFUKK01401UAUnpinnedTabAreaBottom.Location = new System.Drawing.Point(22, 711);
            this._SFUKK01401UAUnpinnedTabAreaBottom.Name = "_SFUKK01401UAUnpinnedTabAreaBottom";
            this._SFUKK01401UAUnpinnedTabAreaBottom.Owner = this.Main_DockManager;
            this._SFUKK01401UAUnpinnedTabAreaBottom.Size = new System.Drawing.Size(994, 0);
            this._SFUKK01401UAUnpinnedTabAreaBottom.TabIndex = 8;
            // 
            // _SFUKK01401UAUnpinnedTabAreaRight
            // 
            this._SFUKK01401UAUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._SFUKK01401UAUnpinnedTabAreaRight.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFUKK01401UAUnpinnedTabAreaRight.Location = new System.Drawing.Point(1016, 63);
            this._SFUKK01401UAUnpinnedTabAreaRight.Name = "_SFUKK01401UAUnpinnedTabAreaRight";
            this._SFUKK01401UAUnpinnedTabAreaRight.Owner = this.Main_DockManager;
            this._SFUKK01401UAUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 648);
            this._SFUKK01401UAUnpinnedTabAreaRight.TabIndex = 6;
            // 
            // _SFUKK01401UAAutoHideControl
            // 
            this._SFUKK01401UAAutoHideControl.Controls.Add(this.dockableWindow1);
            this._SFUKK01401UAAutoHideControl.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFUKK01401UAAutoHideControl.Location = new System.Drawing.Point(22, 63);
            this._SFUKK01401UAAutoHideControl.Name = "_SFUKK01401UAAutoHideControl";
            this._SFUKK01401UAAutoHideControl.Owner = this.Main_DockManager;
            this._SFUKK01401UAAutoHideControl.Size = new System.Drawing.Size(77, 648);
            this._SFUKK01401UAAutoHideControl.TabIndex = 9;
            // 
            // startTimer
            // 
            this.startTimer.Interval = 1;
            this.startTimer.Tick += new System.EventHandler(this.startTimer_Tick);
            // 
            // Main_UTabControl
            // 
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.BackColor2 = System.Drawing.Color.LightPink;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Main_UTabControl.ActiveTabAppearance = appearance2;
            this.Main_UTabControl.Controls.Add(this.ultraTabSharedControlsPage1);
            this.Main_UTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_UTabControl.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.Main_UTabControl.Location = new System.Drawing.Point(22, 63);
            this.Main_UTabControl.Name = "Main_UTabControl";
            this.Main_UTabControl.SharedControls.AddRange(new System.Windows.Forms.Control[] {
            this.uButton_Close});
            this.Main_UTabControl.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.Main_UTabControl.Size = new System.Drawing.Size(994, 648);
            this.Main_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.Main_UTabControl.TabIndex = 23;
            this.Main_UTabControl.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Main_UTabControl.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Controls.Add(this.uButton_Close);
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(1, 20);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(992, 627);
            // 
            // uButton_Close
            // 
            appearance112.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance112.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_Close.Appearance = appearance112;
            this.uButton_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uButton_Close.Location = new System.Drawing.Point(484, 301);
            this.uButton_Close.Name = "uButton_Close";
            this.uButton_Close.Size = new System.Drawing.Size(1, 1);
            this.uButton_Close.TabIndex = 2;
            this.uButton_Close.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_Close.Click += new System.EventHandler(this.uButton_Close_Click);
            // 
            // tMemPos1
            // 
            this.tMemPos1.OwnerForm = this;
            // 
            // windowDockingArea1
            // 
            this.windowDockingArea1.Dock = System.Windows.Forms.DockStyle.Left;
            this.windowDockingArea1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.windowDockingArea1.Location = new System.Drawing.Point(22, 63);
            this.windowDockingArea1.Name = "windowDockingArea1";
            this.windowDockingArea1.Owner = this.Main_DockManager;
            this.windowDockingArea1.Size = new System.Drawing.Size(302, 648);
            this.windowDockingArea1.TabIndex = 10;
            // 
            // _SFUKK01401UA_Toolbars_Dock_Area_Left
            // 
            this._SFUKK01401UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFUKK01401UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFUKK01401UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._SFUKK01401UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFUKK01401UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 63);
            this._SFUKK01401UA_Toolbars_Dock_Area_Left.Name = "_SFUKK01401UA_Toolbars_Dock_Area_Left";
            this._SFUKK01401UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 648);
            this._SFUKK01401UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.Main_ToolbarsManager;
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
            ultraToolbar1.FloatingSize = new System.Drawing.Size(751, 20);
            ultraToolbar1.IsMainMenuBar = true;
            labelTool1.InstanceProps.Width = 25;
            labelTool2.InstanceProps.Width = 54;
            labelTool3.InstanceProps.Width = 141;
            labelTool4.InstanceProps.Width = 103;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1,
            labelTool1,
            labelTool2,
            labelTool3,
            labelTool4,
            labelTool5});
            ultraToolbar1.ShowInToolbarList = false;
            ultraToolbar1.Text = "���C�����j���[";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 1;
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            buttonTool4,
            buttonTool5,
            buttonTool6,
            buttonTool7,
            buttonTool8});
            ultraToolbar2.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.BelowImage;
            ultraToolbar2.Text = "�W��";
            ultraToolbar3.DockedColumn = 1;
            ultraToolbar3.DockedRow = 1;
            ultraToolbar3.FloatingSize = new System.Drawing.Size(359, 24);
            ultraToolbar3.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            comboBoxTool1});
            ultraToolbar3.Text = "��ʃ^�C�v";
            this.Main_ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2,
            ultraToolbar3});
            popupMenuTool2.SharedProps.Caption = "�t�@�C��(&F)";
            popupMenuTool2.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            popupMenuTool2.SharedProps.MergeOrder = 10;
            buttonTool14.InstanceProps.IsFirstInGroup = true;
            popupMenuTool2.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool9,
            buttonTool10,
            buttonTool11,
            buttonTool12,
            buttonTool13,
            buttonTool14});
            popupMenuTool3.SharedProps.Caption = "�E�B���h�E(&W)";
            popupMenuTool3.SharedProps.MergeOrder = 30;
            popupMenuTool3.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool15});
            labelTool6.SharedProps.MergeOrder = 40;
            labelTool6.SharedProps.Spring = true;
            labelTool7.SharedProps.Caption = "���O�C���S����";
            labelTool7.SharedProps.MergeOrder = 50;
            labelTool7.SharedProps.ShowInCustomizer = false;
            labelTool7.SharedProps.Width = 100;
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.TextHAlignAsString = "Left";
            labelTool8.SharedProps.AppearancesSmall.Appearance = appearance3;
            labelTool8.SharedProps.Caption = "���O�C����";
            labelTool8.SharedProps.MergeOrder = 60;
            labelTool8.SharedProps.ShowInCustomizer = false;
            labelTool8.SharedProps.Width = 150;
            buttonTool16.SharedProps.Caption = "�I��(F1)";
            buttonTool16.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool16.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F1;
            mdiWindowListTool1.DisplayArrangeIconsCommand = Infragistics.Win.UltraWinToolbars.MdiWindowListCommandDisplayStyle.Hide;
            mdiWindowListTool1.DisplayCascadeCommand = Infragistics.Win.UltraWinToolbars.MdiWindowListCommandDisplayStyle.Hide;
            mdiWindowListTool1.DisplayCloseWindowsCommand = Infragistics.Win.UltraWinToolbars.MdiWindowListCommandDisplayStyle.Hide;
            mdiWindowListTool1.DisplayMinimizeCommand = Infragistics.Win.UltraWinToolbars.MdiWindowListCommandDisplayStyle.Hide;
            mdiWindowListTool1.DisplayTileHorizontalCommand = Infragistics.Win.UltraWinToolbars.MdiWindowListCommandDisplayStyle.Hide;
            mdiWindowListTool1.DisplayTileVerticalCommand = Infragistics.Win.UltraWinToolbars.MdiWindowListCommandDisplayStyle.Hide;
            mdiWindowListTool1.SharedProps.Caption = "InputForm_MDIWindowListTool";
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            buttonTool17.SharedProps.AppearancesSmall.Appearance = appearance4;
            buttonTool17.SharedProps.Caption = "���C�����(&M)";
            buttonTool17.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            comboBoxTool2.SharedProps.Caption = "��ʃ^�C�v";
            comboBoxTool2.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            comboBoxTool2.SharedProps.Width = 250;
            comboBoxTool2.ValueList = valueList1;
            buttonTool18.SharedProps.Caption = "�V�K(F9)";
            buttonTool18.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool18.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F9;
            buttonTool19.SharedProps.Caption = "�ۑ�(F10)";
            buttonTool19.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool19.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F10;
            buttonTool20.SharedProps.Caption = "�`�[�폜(F12)";
            buttonTool20.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool20.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F12;
            buttonTool21.SharedProps.Caption = "�ԓ`(&R)";
            buttonTool21.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            labelTool9.SharedProps.Caption = "���O�C�����_";
            labelTool9.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            appearance5.ForeColor = System.Drawing.Color.Black;
            comboBoxTool3.EditAppearance = appearance5;
            comboBoxTool3.Locked = true;
            comboBoxTool3.SharedProps.ToolTipText = "�����v�㋒�_";
            comboBoxTool3.ValueList = valueList2;
            buttonTool22.SharedProps.Caption = "�E�B���h�E��������Ԃɖ߂�(&R)";
            buttonTool22.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool23.SharedProps.Caption = "�̎���";
            buttonTool23.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            labelTool10.SharedProps.Caption = "���_��";
            appearance6.BackColor = System.Drawing.Color.White;
            appearance6.TextHAlignAsString = "Left";
            labelTool11.SharedProps.AppearancesSmall.Appearance = appearance6;
            labelTool11.SharedProps.MinWidth = 0;
            labelTool11.SharedProps.ShowInCustomizer = false;
            labelTool11.SharedProps.Width = 150;
            popupMenuTool4.SharedProps.Caption = "�ҏW(&E)";
            popupMenuTool4.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool24,
            buttonTool25});
            buttonTool26.SharedProps.Caption = "�ŐV���(&I)";
            buttonTool26.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool27.SharedProps.Caption = "�`�[�ďo(F11)";
            buttonTool27.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool27.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F11;
            this.Main_ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool2,
            popupMenuTool3,
            labelTool6,
            labelTool7,
            labelTool8,
            buttonTool16,
            mdiWindowListTool1,
            buttonTool17,
            comboBoxTool2,
            buttonTool18,
            buttonTool19,
            buttonTool20,
            buttonTool21,
            labelTool9,
            comboBoxTool3,
            buttonTool22,
            buttonTool23,
            labelTool10,
            labelTool11,
            popupMenuTool4,
            buttonTool26,
            buttonTool27});
            this.Main_ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.Main_ToolbarsManager_ToolClick);
            this.Main_ToolbarsManager.ToolValueChanged += new Infragistics.Win.UltraWinToolbars.ToolEventHandler(this.Main_ToolbarsManager_ToolValueChanged);
            // 
            // _SFUKK01401UA_Toolbars_Dock_Area_Right
            // 
            this._SFUKK01401UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFUKK01401UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFUKK01401UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._SFUKK01401UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFUKK01401UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1016, 63);
            this._SFUKK01401UA_Toolbars_Dock_Area_Right.Name = "_SFUKK01401UA_Toolbars_Dock_Area_Right";
            this._SFUKK01401UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 648);
            this._SFUKK01401UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _SFUKK01401UA_Toolbars_Dock_Area_Top
            // 
            this._SFUKK01401UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFUKK01401UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFUKK01401UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._SFUKK01401UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFUKK01401UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._SFUKK01401UA_Toolbars_Dock_Area_Top.Name = "_SFUKK01401UA_Toolbars_Dock_Area_Top";
            this._SFUKK01401UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1016, 63);
            this._SFUKK01401UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _SFUKK01401UA_Toolbars_Dock_Area_Bottom
            // 
            this._SFUKK01401UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFUKK01401UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFUKK01401UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._SFUKK01401UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFUKK01401UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 711);
            this._SFUKK01401UA_Toolbars_Dock_Area_Bottom.Name = "_SFUKK01401UA_Toolbars_Dock_Area_Bottom";
            this._SFUKK01401UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1016, 0);
            this._SFUKK01401UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // SFUKK01401UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.CancelButton = this.uButton_Close;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this._SFUKK01401UAAutoHideControl);
            this.Controls.Add(this.Main_UTabControl);
            this.Controls.Add(this.windowDockingArea1);
            this.Controls.Add(this._SFUKK01401UAUnpinnedTabAreaTop);
            this.Controls.Add(this._SFUKK01401UAUnpinnedTabAreaBottom);
            this.Controls.Add(this._SFUKK01401UAUnpinnedTabAreaRight);
            this.Controls.Add(this._SFUKK01401UAUnpinnedTabAreaLeft);
            this.Controls.Add(this._SFUKK01401UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._SFUKK01401UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._SFUKK01401UA_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._SFUKK01401UA_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.ultraStatusBar1);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFUKK01401UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "�����`�[����";
            this.Load += new System.EventHandler(this.SFUKK01401UA_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.onClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).EndInit();
            this.dockableWindow1.ResumeLayout(false);
            this._SFUKK01401UAAutoHideControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_UTabControl)).EndInit();
            this.Main_UTabControl.ResumeLayout(false);
            this.ultraTabSharedControlsPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		# region Private const Menbers
		/// <summary>�����`�[����(�����^)�^�u</summary>
		private const string TAB_NORMALTYPE = "NormalType";
		
		/// <summary>�����`�[����(����w��^)�^�u</summary>
		private const string TAB_SALESTYPE = "SalesTypeAcs";
		
		/// <summary>�_�~�[�^�u</summary>
		private const string NO_TAB = "";
		# endregion

		# region Private Menbers
		/// <summary>�����`�[���͐ݒ�f�[�^�n�A�N�Z�X�N���X</summary>
		private DepositRelDataAcs depositRelDataAcs;

		/// <summary>�X���C�_�[�p�l���N���X(�����^)</summary>
		private SFCMN00221UA _superSliderDepo;

		/// <summary>   </summary>
		private SFCMN00221UA _superSliderOrder;

		/// <summary>�ԍ��^�C�v�Ǘ��}�X�^�A�N�Z�X�N���X</summary>
		private NoMngSetAcs noMngSetAcs;

		/// <summary>Tab�q��ʕ\���p�����[�^</summary>
		private int _parameter;
		
		/// <summary>���ݑI����ʃ^�C�v</summary>
		private object selectedDispTypeItem;

		/// <summary>���ݑI�����_</summary>
		private object selectedSection;

		/// <summary>��ʃ^�C�v�I�𒆃t���O</summary>
		private bool selectDispTypeFlg;

		/// <summary>���_�I�𒆃t���O</summary>
		private bool selectedSectionFlg;

		/// <summary>�N�����[�h</summary>
		private StartingMode _startingMode;

		/// <summary>�N���p�����[�^</summary>
		private StartingParameter _startingParameter;

		/// <summary>�E�B���h�E��ԕێ��p</summary>
		private MemoryStream _dockMemoryStream;

        // �� 20070131 18322 a MA.NS�p�ɒǉ�
        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        // �� 20070131 18322 a

        /// <summary>�����v�㋒�_</summary>
        private string _demandAddUpSecCd;

		/// <summary>����N���t���O</summary>
		/// <remarks>0:����, 1:�Q��ڈȍ~</remarks>
		private int _firstStartFlg;

        private IOperationAuthority _operationAuthority;    // ���쌠���̐���I�u�W�F�N�g
		# endregion

        /// <summary>
        /// �I�y���[�V�����R�[�h
        /// </summary>
        internal enum OperationCode : int
        {
            /// <summary>�C��</summary>
            Revision = 10,
            /// <summary>�폜</summary>
            Delete = 11,
            /// <summary>�ԓ`</summary>
            RedSlip = 12,
        }

        // ���쌠���̐���I�u�W�F�N�g�ۗ̕L
        /// <summary>
        /// ���쌠���̐���I�u�W�F�N�g���擾���܂��B
        /// </summary>
        /// <value>���쌠���̐���I�u�W�F�N�g</value>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if (_operationAuthority == null)
                {
                    _operationAuthority = OpeAuthCtrlFacade.CreateEntryOperationAuthority("SFUKK01400U", this);
                }
                return _operationAuthority;
            }
        }

        /// <summary>
        /// ���쌠���̐�����J�n���܂��B
        /// </summary>
        private void BeginControllingByOperationAuthority()
        {
            // �`�[�폜�{�^��
            if (MyOpeCtrl.Disabled((int)OperationCode.Delete))
            {
                Main_ToolbarsManager.Tools["btnDelete"].SharedProps.Visible = false;
                Main_ToolbarsManager.Tools["btnDelete"].SharedProps.Shortcut = Shortcut.None;
            }

            // �ԓ`�{�^��
            if (MyOpeCtrl.Disabled((int)OperationCode.RedSlip))
            {
                Main_ToolbarsManager.Tools["btnAka"].SharedProps.Visible = false;
                Main_ToolbarsManager.Tools["btnAka"].SharedProps.Shortcut = Shortcut.None;
            }
        }

		# region Public Methods
		/// <summary>
		/// �����`�[���͉�ʕ\������
		/// </summary>
		/// <param name="startingMode">�N�����[�h</param>
		/// <param name="startingParameter">�N���p�����[�^</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : �����`�[���͉�ʂ��N�����܂��B</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		public void Show(StartingMode startingMode, StartingParameter startingParameter)
		{
			// �N�����[�h
			this._startingMode = startingMode;

			// �N���p�����[�^
			this._startingParameter = startingParameter;

			// �h�����Ăяo��(�{����Show���\�b�h�Ăяo��)
			((Control)this).Show();
		}

		/// <summary>
		/// �����`�[���͉�ʕ\������
		/// </summary>
		/// <param name="startingMode">�N�����[�h</param>
		/// <param name="startingParameter">�N���p�����[�^</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : �����`�[���͉�ʂ��N�����܂��B</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		public void ShowDialog(StartingMode startingMode, StartingParameter startingParameter)
		{
			// �N�����[�h
			this._startingMode = startingMode;

			// �N���p�����[�^
			this._startingParameter = startingParameter;

			// ��ʋN��
			this.ShowDialog();
		}

		/// <summary>
		/// �ڋq�I���C�x���g(�X���C�_�[�ɂČڋq�I�����ɔ���)
		/// </summary>
		/// <param name="selectData">�ڋq�I�����</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : �ڋq�I���C�x���g(�X���C�_�[�ɂČڋq�I�����ɔ���)</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
        // �� 20070219 18322 c MA.NS�p�ɕύX
		//public void SelectedCustomerCar(CustomerCarSearchAcsRet selectData)
		//{

		public void SelectedCustomerCar(CustomerSearchRet selectData)
		{
        // �� 20070219 18322 c
			// �ڋq���I������ꍇ�ɔ�э��݂܂�
			if (selectData != null)
			{
				// �q��ʂ̃f�[�^�\���w�� (���Ӑ�R�[�h�w�胂�[�h)
				this.RefreshTabChildCustomerMode(selectData.CustomerCode);
			}
		}

        // �� 20070519 18322 d MK.NS�ł͎g�p���Ȃ��̂ō폜(SFMIT01207E���g�p)
		///// <summary>
		///// �`�[�I���C�x���g(�X���C�_�[�ɂē`�[�I�����ɔ���)
		///// </summary>
		///// <param name="seldata">�`�[�I�����</param>
		///// <returns>none</returns>
		///// <remarks>
		///// <br>Note       : �`�[�I���C�x���g(�X���C�_�[�ɂē`�[�I�����ɔ���)</br>
		///// <br>Programer  : 97036 amami</br>
		///// <br>Date       : 2005.07.30</br>
		///// </remarks>
		//public void ModifyOrder(AcceptOdrSearchAcsRet seldata)
		//{
		//	// �`�[���I������ꍇ�ɔ�э��݂܂�
		//	if (seldata != null)
		//	{
        //        // �� 20070130 18322 c MA.NS�p�ɕύX
		//		//// �q��ʂ̃f�[�^�\���w�� (�󒍔ԍ��w�胂�[�h)
		//		//this.RefreshTabChildAcceptAnOrderMode(seldata.CustomerCode, seldata.AcceptAnOrderNo);
        //
		//		// �q��ʂ̃f�[�^�\���w�� (�󒍔ԍ��w�胂�[�h)
		//		this.RefreshTabChildSlipNumberMode(seldata.CustomerCode, seldata.AcceptAnOrderNo, "");
        //        // �� 20070130 18322 c
		//	}
		//}
        // �� 20070519 18322 d
		# endregion

		#region Private Delegate Methods
		/// <summary>
		/// �c�[���o�[�{�^������C�x���g
		/// </summary>
		/// <param name="sender">�I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �t���[���̃{�^���L������������������ꍇ�ɔ��������܂��B</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private void ParentToolbarSettingEvent(object sender)
		{
			ToolBarButtonEnabledSetting(sender);
		}

		/// <summary>
		/// ���_�R�[�h�擾
		/// </summary>
		/// <param name="sender">�I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �t���[���ɂđI������Ă��鋒�_�R�[�h���擾���܂��B</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private string GetSelectSectionCodeEvent(object sender)
		{
            // ���ݑI�����_��Ԃ�
            ValueListItem secInfoList = selectedSection as ValueListItem;
            if (secInfoList != null)
            {
                return secInfoList.DataValue.ToString();
            }
            return "";
		}

        /// <summary>
        /// �����v�㋒�_���̎擾
        /// </summary>
        /// <param name="sender">�I�u�W�F�N�g</param>
        /// <param name="sectionName">�����v�㋒�_����</param>
        /// <remarks>
        /// <br>Note       : �����v�㋒�_�R�[�h���擾���܂��B</br>
        /// <br>Programer  : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.02.20</br>
        /// </remarks>
        private void HandOverAddUpSecNameEvent(object sender, string sectionName)
        {
            // �����v�㋒�_��\��
            Main_ToolbarsManager.Tools["SectionCode_l"].SharedProps.Caption = sectionName;
        }
		#endregion

		# region Private Methods
		/// <summary>
		/// �X�[�p�[�X���C�_�[����������
		/// </summary>
		/// <param>none</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : �X�[�p�[�X���C�_�[�̏������������s���܂��B</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private void InitializeSlider()
		{
			this._superSliderDepo = new SFCMN00221UA();						// �X���C�_�[�p�l���N���X(�����^)
			this._superSliderOrder = new SFCMN00221UA();					// �X���C�_�[�p�l���N���X(�󒍎w��^)

			// �X�[�p�[�X���C�_�[�A�Z���u�����[�h�E�K�C�h�ǉ�����(�����^)
            // �� 20070219 18322 d MA.NS�p�ɕύX
			//this._superSliderDepo.IsLocalDataExtract = false;						// ���[�J��������OFF
			//this._superSliderDepo.AcceptOrderListShow = false;						// �ŋߎg�p�����`�[��\��
            // �� 20070219 18322 d
			Panel sldpanelDepo = this._superSliderDepo.GetMainPanel(0, 10);
			SlipSearch_Panel.Controls.Add(sldpanelDepo);							// ���\��t����p�l�����w��
			sldpanelDepo.Dock = System.Windows.Forms.DockStyle.Fill;

			// �ڋq�I���C�x���g(�X���C�_�[�ɂČڋq�I�����ɔ���)
            // �� 20070309 18322 c MA.NS�p�ɕύX
			//this._superSliderDepo.SelectedCustomerCar += new SelectedCustomerCarHandler(SelectedCustomerCar);

			this._superSliderDepo.SelectedCustomer += new SelectedCustomerHandler(SelectedCustomerCar);
            // �� 20070309 18322 c

			// �X�[�p�[�X���C�_�[�A�Z���u�����[�h�E�K�C�h�ǉ�����(�󒍎w��^)
            // �� 20070219 18322 d MA.NS�p�ɕύX
			//this._superSliderOrder.IsLocalDataExtract = false;						// ���[�J��������OFF
            // �� 20070219 18322 d
			Panel sldpanelOrder = this._superSliderOrder.GetMainPanel(0, 11);
			SlipSearch_Panel.Controls.Add(sldpanelOrder);							// ���\��t����p�l�����w��
			sldpanelOrder.Dock = DockStyle.Fill;

			//// �ڋq�I���C�x���g(�X���C�_�[�ɂČڋq�I�����ɔ���)
            // �� 20070309 18322 c MA.NS�p�ɕύX
			//this._superSliderOrder.SelectedCustomerCar += new SelectedCustomerCarHandler(SelectedCustomerCar);

			this._superSliderOrder.SelectedCustomer += new SelectedCustomerHandler(SelectedCustomerCar);
            // �� 20070309 18322 c
            
			//// �`�[�I���C�x���g(�`�[�Ăяo���I�����ɔ���)
			//this._superSliderOrder.ModifyOrder += new ModifyOrderHandler(ModifyOrder);
		}

		/// <summary>
		/// �ԍ��^�C�v�Ǘ��}�X�^���擾����
		/// </summary>
		/// <param>none</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : �ԍ��^�C�v�Ǘ��}�X�^���擾�����i��Static�o�b�t�@�փZ�b�g���܂��B</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private void SearchNoMngSetAcs()
		{
			ArrayList retNoTypMngList;

			//�ԍ��^�C�v�Ǘ��}�X�^���擾�����i��Static�o�b�t�@�փZ�b�g
			if (this.noMngSetAcs == null) this.noMngSetAcs = new NoMngSetAcs();
			if (this.noMngSetAcs.Search(out retNoTypMngList, LoginInfoAcquisition.EnterpriseCode) == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				NumberControl.NoTypeMngList = retNoTypMngList.ToArray(typeof(NoTypeMng)) as NoTypeMng[];
			}
		}
		
		/// <summary>
		/// �c�[���o�[�{�^���L�������ݒ菈��
		/// </summary>
		/// <param>none</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : �c�[���[�o�[�{�^���̗L���E�����ݒ���s���܂��B</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
        /// <br>Update Note: 2012/12/24 ���N</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>           : Redmine#33741�̑Ή�</br>
		/// </remarks>
		private void ToolBarButtonEnabledSetting(object sender)
		{
            if (this.Main_UTabControl.ActiveTab == null)
            {
                return;
            }

			// �A�N�e�B�u��Ԃ̃^�u����t�H�[�����擾����
			Form frm = this.Main_UTabControl.ActiveTab.Tag as Form;

			// �����ς̎��͕\������
			// IDepositInputMDIChild�C���^�[�t�F�C�X���������Ă���ꍇ�͈ȉ������s����B
			if ((frm == null) || (!(frm is IDepositInputMDIChild))) return;

			// �ۑ��{�^��
			ButtonTool ButtonSave = Main_ToolbarsManager.Tools["btnSave"] as ButtonTool;
			if (ButtonSave != null) ButtonSave.SharedProps.Enabled = ((IDepositInputMDIChild)frm).SaveButton;

			// �V�K�{�^��
			ButtonTool ButtonNew = Main_ToolbarsManager.Tools["btnNew"] as ButtonTool;
			if (ButtonNew != null) ButtonNew.SharedProps.Enabled = ((IDepositInputMDIChild)frm).NewButton;

			// �폜�{�^��
			ButtonTool ButtonDel = Main_ToolbarsManager.Tools["btnDelete"] as ButtonTool;
			if (ButtonDel != null) ButtonDel.SharedProps.Enabled = ((IDepositInputMDIChild)frm).DeleteButton;

			// �ԓ`�{�^��
			ButtonTool ButtonAka = Main_ToolbarsManager.Tools["btnAka"] as ButtonTool;
			if (ButtonAka != null) ButtonAka.SharedProps.Enabled = ((IDepositInputMDIChild)frm).AkaButton;

			// �̎������s�{�^��
			ButtonTool ButtonReceiptPrint = Main_ToolbarsManager.Tools["btnReceiptPrint"] as ButtonTool;
			if (ButtonReceiptPrint != null) ButtonReceiptPrint.SharedProps.Enabled = ((IDepositInputMDIChild)frm).ReceiptPrintButton;

            // �ŐV���{�^��
            ButtonTool ButtonRenewal = Main_ToolbarsManager.Tools["btnRenewal"] as ButtonTool;
            if (ButtonRenewal != null) ButtonRenewal.SharedProps.Enabled = ((IDepositInputMDIChild)frm).RenewalButton;

            // -------�@ADD ���N 2012/12/24 Redmine#33741 -------->>>>>
            // �����`�[�ďo�{�^��
            ButtonTool ButtonReadSlip = Main_ToolbarsManager.Tools["btnReadSlip"] as ButtonTool;
            if (ButtonReadSlip != null) ButtonReadSlip.SharedProps.Enabled = ((IDepositInputMDIChild)frm).ReadSlipButton;
            // -------�@ADD ���N 2012/12/24 Redmine#33741 --------<<<<<
            BeginControllingByOperationAuthority();
		}
		
		/// <summary>
		/// �c�[���{�^������
		/// </summary>
		/// <param>none</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : �c�[���{�^���̏����ݒ���s���܂��B</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
        /// <br>Update Note: 2012/12/24 ���N</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>           : Redmine#33741�̑Ή�</br>
		/// </remarks>
		private void ToolButtonSetting()
		{
			// �C���[�W���X�g��ݒ肷��
			Main_ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;

			// ���_
			LabelTool kyotenLabel = Main_ToolbarsManager.Tools["KYOTENNM"] as LabelTool;
			if (kyotenLabel != null) kyotenLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;

			// ���O�C���S����
			LabelTool loginEmployeeLabel = Main_ToolbarsManager.Tools["LOGINTITLE"] as LabelTool;
			if (loginEmployeeLabel != null) loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

			// �I���{�^��
			ButtonTool buttonClose = Main_ToolbarsManager.Tools["btnClose"] as ButtonTool;
			if (buttonClose != null) buttonClose .SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;

			// �ۑ��{�^��
			ButtonTool ButtonSave = Main_ToolbarsManager.Tools["btnSave"] as ButtonTool;
			if (ButtonSave != null)
			{
				ButtonSave.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
				ButtonSave.SharedProps.Enabled = false;
			}

			// �V�K�{�^��
			ButtonTool ButtonNew = Main_ToolbarsManager.Tools["btnNew"] as ButtonTool;
			if (ButtonNew != null) 
			{
				ButtonNew.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
				ButtonNew.SharedProps.Enabled = false;
			}

			// �폜�{�^��
			ButtonTool ButtonDel = Main_ToolbarsManager.Tools["btnDelete"] as ButtonTool;
			if (ButtonDel != null)
			{
				ButtonDel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
				ButtonDel.SharedProps.Enabled = false;
			}

			// �ԓ`�{�^��
			ButtonTool ButtonAka = Main_ToolbarsManager.Tools["btnAka"] as ButtonTool;
			if (ButtonAka != null)
			{
				ButtonAka.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.REDSLIP;
				ButtonAka.SharedProps.Enabled = false;
			}

			// �̎������s�{�^��
			ButtonTool ButtonReceiptPrint = Main_ToolbarsManager.Tools["btnReceiptPrint"] as ButtonTool;
			if (ButtonReceiptPrint != null)
			{
				ButtonReceiptPrint.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;
				ButtonReceiptPrint.SharedProps.Enabled = false;
			}

            // �ŐV���{�^��
            ButtonTool ButtonRenewal = Main_ToolbarsManager.Tools["btnRenewal"] as ButtonTool;
            if (ButtonRenewal != null)
            {
                ButtonRenewal.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;
                ButtonRenewal.SharedProps.Enabled = false;
            }

            // ---- ADD ���N 2012/12/24 Redmine#33741 ---------->>>>>
            // �����`�[�ďo�{�^��
            ButtonTool ButtonReadSlip = Main_ToolbarsManager.Tools["btnReadSlip"] as ButtonTool;
            if (ButtonReadSlip != null)
            {
                ButtonReadSlip.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SLIPSEARCH;
                ButtonReadSlip.SharedProps.Enabled = false;
            }
            // ---- ADD ���N 2012/12/24 Redmine#33741 ----------<<<<<
            // �� 20070514 18322 c �̎������쐬����܂Ń{�^�����\���ɂ���B
            ButtonReceiptPrint.SharedProps.Visible = false;
            // �� 20070514 18322 c
		}

		/// <summary>
		/// ���_���X�g�ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���_���X�g�̐ݒ���s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void SectionSetting()
		{
            // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
            //Infragistics.Win.UltraWinToolbars.LabelTool labKyoten = Main_ToolbarsManager.Tools["KYOTENNM"] as Infragistics.Win.UltraWinToolbars.LabelTool;
            //Infragistics.Win.UltraWinToolbars.ComboBoxTool cmbKyoten = Main_ToolbarsManager.Tools["KYOTENCOMBO"] as Infragistics.Win.UltraWinToolbars.ComboBoxTool;
            //if ((labKyoten != null) && (cmbKyoten != null))
            //{
            //    // ���_���X�g��ݒ�
            //    Infragistics.Win.ValueList secInfoList = new Infragistics.Win.ValueList();
            //    for (int ix = 0; ix < depositRelDataAcs.SlSection.Count; ix++)
            //    {
            //        Infragistics.Win.ValueListItem secInfoItem = new Infragistics.Win.ValueListItem();
            //        secInfoItem.DataValue	= depositRelDataAcs.SlSection.GetKey(ix);
            //        secInfoItem.DisplayText	= (string)depositRelDataAcs.SlSection.GetByIndex(ix);
            //        secInfoList.ValueListItems.Add(secInfoItem);
            //    }
            //    cmbKyoten.ValueList = secInfoList;

            //    // �����v�㋒�_���Z�b�g
            //    cmbKyoten.Value = this.depositRelDataAcs.DemandAddUpSecCd;

            //    // �{�Ћ@�\���_�ł͂Ȃ����͕\��������
            //    // �����_�I�v�V�������������͖{�Ћ@�\�t���O��OFF�ɂȂ��Ă���
            //    if (depositRelDataAcs.MainOfficeFuncFlag == 0)
            //    {
            //        labKyoten.SharedProps.Visible = false;
            //        cmbKyoten.SharedProps.Visible = false;
            //    }
            //}
            LabelTool labKyoten = Main_ToolbarsManager.Tools["KYOTENNM"] as LabelTool;
            LabelTool labKyotenNm = Main_ToolbarsManager.Tools["SectionCode_l"] as LabelTool;
            if ((labKyoten != null) && (labKyotenNm != null))
            {
                for (int ix = 0; ix < depositRelDataAcs.SlSection.Count; ix++)
                {
                    if ((string)depositRelDataAcs.SlSection.GetKey(ix) == this.depositRelDataAcs.DemandAddUpSecCd)
                    {
                        // �����v�㋒�_���̂��Z�b�g
                        labKyotenNm.SharedProps.Caption = (string)depositRelDataAcs.SlSection.GetByIndex(ix);
                        break;
                    }
                }
                
                // �{�Ћ@�\���_�ł͂Ȃ����͕\��������
                // �����_�I�v�V�������������͖{�Ћ@�\�t���O��OFF�ɂȂ��Ă���
                if (depositRelDataAcs.MainOfficeFuncFlag == 0)
                {
                    labKyoten.SharedProps.Visible = false;
                    labKyotenNm.SharedProps.Visible = false;
                }
            }
            // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<
		}

		/// <summary>
		/// ��ʃ^�C�v�R���{�{�b�N�X����
		/// </summary>
		/// <param>none</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : �c�[���o�[�������ݒ肷��</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
        /// <br>Update Note: 2015/08/18 ����</br>
        /// <br>�Ǘ��ԍ�   : 11170129-00 �y��85�z�����`�[���͂̏�Q�Ή�</br>
        /// <br>           : Redmine#47016 �u�ŐV���v�{�^��������������A��ʃ^�C�v���X�g��ύX����ꍇ�A��O�G���[�̑Ή�</br>
		/// </remarks>
		private void SetDispTypList()
		{
			// ��ʃ^�C�v�R���{�{�b�N�X�̎擾
			ComboBoxTool dispTypeList = Main_ToolbarsManager.Tools["DispTypeList"] as ComboBoxTool;

			if (dispTypeList != null)
			{
				ValueList vl = new ValueList();

				// ��ʃ^�C�v���X�g���쐬
				foreach (DictionaryEntry myDE in depositRelDataAcs.SlDispType)
				{
					vl.ValueListItems.Add(myDE.Key, (string)myDE.Value);
				}

				// ��ʃ^�C�v���X�g��ݒ�
				dispTypeList.ValueList = vl;

                //----- ADD 2015/08/18 ���� Redmine#47016 ��ʃ^�C�v���X�g��ύX����ꍇ�A��O�G���[�̑Ή� ---------->>>>>
                // ���ݑI����ʃ^�C�v��ێ�
                selectedDispTypeItem = dispTypeList.SelectedItem;
                //----- ADD 2015/08/18 ���� Redmine#47016 ��ʃ^�C�v���X�g��ύX����ꍇ�A��O�G���[�̑Ή� ----------<<<<<
			}
		}

		/// <summary>
		/// �f�t�H���g��ʃ^�C�v�I������
		/// </summary>
		/// <param name="startingMode">�N�����[�h</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : �f�t�H���g�̉�ʃ^�C�v��I�����N�����܂�</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private void DefaultSelectDispTypy(StartingMode startingMode)
		{
			// ��ʃ^�C�v�R���{�{�b�N�X�̎擾
			ComboBoxTool dispTypeList = (ComboBoxTool)Main_ToolbarsManager.Tools["DispTypeList"];

			// �f�t�H���g��ʃ^�C�v��ݒ�
			switch (startingMode)
			{
				case StartingMode.Normal :				// --- �m�[�}�����[�h --- //
				case StartingMode.CustomerCode :		// --- ���Ӑ�R�[�h�w�胂�[�h --- //
					
					// �������A�����s�Ŏ󒍎w��^�͂���
					if ((depositRelDataAcs.AllowanceProc == 2) && (depositRelDataAcs.DefaultDispType == 2))
					{
						TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "�u���������敪=�s�v �̐ݒ�ׁ̈A�u�󒍎w��^�v�ł͋N���ł��܂���B" + "\r\n\r\n" +
							"�u�����^�v�ŋN�����s���܂��B" + "\r\n\r\n" +
							"�����ݒ�A�����ݒ� ���m�F���Ă��������B", 0, MessageBoxButtons.OK);
						depositRelDataAcs.DefaultDispType = 1;
					}
				
					dispTypeList.SelectedItem = dispTypeList.ValueList.FindByDataValue(depositRelDataAcs.DefaultDispType);

					break;
                // �� 20070129 18322 c MA.NS�p�ɕύX
				//case StartingMode.AcceptAnOrderNo :		// --- �󒍔ԍ��w�胂�[�h: �����^�ŋN�� --- //
                //    
				//	dispTypeList.SelectedItem = dispTypeList.ValueList.FindByDataValue(1);
				//	
				//	break;

				case StartingMode.SalesSlipNum :		// --- ����`�[�ԍ��w�胂�[�h: ����`�[�^�ŋN�� --- //

					dispTypeList.SelectedItem = dispTypeList.ValueList.FindByDataValue(1);
					
					break;
                // �� 20070129 18322 c

				default :								// --- �I�������[�h: ���������� --- //
					
					dispTypeList.SelectedItem = null;

					break;
			}

			// ���ݑI����ʃ^�C�v��ێ�
			selectedDispTypeItem = dispTypeList.SelectedItem;
		}

		/// <summary>
		/// �^�u�N���G�C�g����
		/// </summary>
		/// <param name="key">��ʎ��</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : �q��ʃ^�u�𐶐����܂�</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private void TabCreate(string key)
		{
			// TAB�q��ʐ�������
			Form form = this.TabCreateAdd(key);
			
			// IDepositInputTabChild�C���^�[�t�F�C�X���������Ă���ꍇ�͈ȉ��̏��������s����B
			if ((form is IDepositInputMDIChild))
			{
				// �c�[���o�[�{�^������f���Q�[�g�̓o�^
				((IDepositInputMDIChild)form).ParentToolbarSettingEvent += new ParentToolbarDepositSettingEventHandler(this.ParentToolbarSettingEvent);

				// �I�����_�擾�f���Q�[�g�̓o�^
				((IDepositInputMDIChild)form).GetSelectSectionCodeEvent += new GetDepositSelectSectionCodeEventHandler(this.GetSelectSectionCodeEvent);

                // �v�㋒�_�擾�f���Q�[�g�̓o�^
                ((IDepositInputMDIChild)form).HandOverAddUpSecNameEvent += new HandOverDepositAddUpSecNameEventHandler(this.HandOverAddUpSecNameEvent);

				((IDepositInputMDIChild)form).Show(this._parameter);
			}
			else 
			{
				form.Show();
			}
		}

		/// <summary>
		/// �^�u�A�N�e�B�u������
		/// </summary>
		/// <param name="key">��ʎ��</param>
		/// <returns>��������</returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ�^�u���A�N�e�B�u�����܂�</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private void TabActive(string key)
		{
			// �^�u�����݂��鎞
			if (this.Main_UTabControl.Tabs.Exists(key))
			{
				this.Main_UTabControl.Tabs[key].Visible = true;
				this.Main_UTabControl.SelectedTab = this.Main_UTabControl.Tabs[key];
			}
		}

		/// <summary>
		/// �^�u�폜����
		/// </summary>
		/// <param name="key">��ʎ��</param>
		/// <returns>��������</returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ�^�u���폜���܂�</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private void TabRemove(string key)
		{
			// �^�u�����݂��鎞
			if (this.Main_UTabControl.Tabs.Exists(key))
			{
				this.Main_UTabControl.Tabs.Remove(this.Main_UTabControl.Tabs[key]);
			}
		}
		
		/// <summary>
		/// TAB�q��ʐ�������
		/// </summary>
		/// <param name="key">��ʎ��</param>
		/// <returns>�t�H�[���N���X</returns>
		/// <remarks>
		/// <br>Note       : TAB�q��ʂ𐶐����܂�</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.05.19</br>
		/// </remarks>
		private Form TabCreateAdd(string key)
		{
			Form form = null;

			// �N���X�C���X�^���X������
			switch (key)
			{
				case TAB_NORMALTYPE:
					{
						form = new SFUKK01403UA();
						break;
					}
				case TAB_SALESTYPE:
					{
						form = new SFUKK01406UA();
						break;
					}
				default:
					{
						return null;
					}
			}

			// �t�H�[���v���p�e�B�ύX
			form.TopLevel = false;
			form.FormBorderStyle = FormBorderStyle.None;
			form.Dock = DockStyle.Fill;

			// �^�u�̊O�ς�ݒ肵�A�^�u�R���g���[���Ƀ^�u��ǉ�����
			UltraTab dataviewTab = this.Main_UTabControl.Tabs.Add(key);

			dataviewTab.Text = form.Text;
			dataviewTab.Tag = form;
			dataviewTab.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.DETAILS2];
			dataviewTab.TabPage.Controls.Add(form);

			this.Main_UTabControl.Controls.Add(dataviewTab.TabPage);

			return form;
		}
		
		/// <summary>
		/// Tab�q��ʂ̃f�[�^�\���w�� (���Ӑ�R�[�h�w�胂�[�h)
		/// </summary>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <remarks>
		/// <br>Note       : Tab�q��ʂ̃f�[�^�\���w��</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private void RefreshTabChildCustomerMode(int customerCode)
		{
			// �p�����[�^������ȂƂ�
			if (customerCode != 0)
			{
				// ���݁A�A�N�e�B�u�ȉ�ʂ��擾����
				Form frm = this.Main_UTabControl.ActiveTab.Tag as Form;

				if (frm != null)
				{
					// IDepositInputMDIChild�C���^�[�t�F�C�X���������Ă���ꍇ�͈ȉ��̏��������s����B
					if ((frm is IDepositInputMDIChild))
					{
						object[] parameter = new object[1] {customerCode};

						((IDepositInputMDIChild)frm).ShowData(0, parameter);
					}
				}
			
				if (!this.Main_DockManager.ControlPanes[0].Pinned && this.Main_DockManager.ControlPanes[0].Manager.FlyoutPane != null)
					this.Main_DockManager.ControlPanes[0].Manager.FlyIn(true);
			}
		}

        /// <summary>
		/// Tab�q��ʂ̃f�[�^�\���w�� (�󒍔ԍ��w�胂�[�h)
		/// </summary>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="acceptAnOrderNo">�󒍔ԍ�</param>
		/// <remarks>
		/// <br>Note       : Tab�q��ʂ̃f�[�^�\���w��</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private void RefreshTabChildAcceptAnOrderMode(int customerCode, int acceptAnOrderNo)
		{
            // �p�����[�^������ȂƂ�
			if ((customerCode != 0) && (acceptAnOrderNo != 0))
			{
				// ���݁A�A�N�e�B�u�ȉ�ʂ��擾����
				Form frm = this.Main_UTabControl.ActiveTab.Tag as Form;
            
				if (frm != null)
				{
					// IDepositInputMDIChild�C���^�[�t�F�C�X���������Ă���ꍇ�͈ȉ��̏��������s����B
					if ((frm is IDepositInputMDIChild))
					{
						object[] parameter = new object[2] {customerCode, acceptAnOrderNo};
            
						((IDepositInputMDIChild)frm).ShowData(1, parameter);
					}
				}
			
				if (!this.Main_DockManager.ControlPanes[0].Pinned && this.Main_DockManager.ControlPanes[0].Manager.FlyoutPane != null)
					this.Main_DockManager.ControlPanes[0].Manager.FlyIn(true);
			}
        }

        // �� 20070130 18322 a MA.NS�p�ɕύX
        /// <summary>
		/// Tab�q��ʂ̃f�[�^�\���w�� (�`�[�ԍ��w�胂�[�h)
		/// </summary>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="acceptAnOrderNo">�󒍔ԍ�</param>
		/// <param name="salesSlipNum">����`�[�ԍ�</param>
		/// <remarks>
		/// <br>Note       : Tab�q��ʂ̃f�[�^�\���w��</br>
		/// <br>Programer  : 18322 T.Kimura</br>
		/// <br>Date       : 2007.01.30</br>
        /// <br>               MA.NS�p�ɕύX</br>
		/// </remarks>
		private void RefreshTabChildSlipNumberMode(int customerCode, int acceptAnOrderNo, string salesSlipNum)
		{
            // �p�����[�^������ȂƂ�
			if ((customerCode != 0) && ((acceptAnOrderNo != 0) || (salesSlipNum != "")))
			{
				// ���݁A�A�N�e�B�u�ȉ�ʂ��擾����
				Form frm = this.Main_UTabControl.ActiveTab.Tag as Form;
            
				if (frm != null)
				{
					// IDepositInputMDIChild�C���^�[�t�F�C�X���������Ă���ꍇ�͈ȉ��̏��������s����B
					if ((frm is IDepositInputMDIChild))
					{
						object[] parameter = new object[3] {customerCode, acceptAnOrderNo, salesSlipNum};
            
						((IDepositInputMDIChild)frm).ShowData(1, parameter);
					}
				}
			
				if (!this.Main_DockManager.ControlPanes[0].Pinned && this.Main_DockManager.ControlPanes[0].Manager.FlyoutPane != null)
					this.Main_DockManager.ControlPanes[0].Manager.FlyIn(true);
			}
        }
        // �� 20070130 18322 a


        /// <summary>
		/// �E�B���h�E����������
		/// </summary>
		/// <param>none</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : �E�B���h�E������������</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private void InitWindow()
		{
			if (this._dockMemoryStream == null)
			{
				return;
			}

			this._dockMemoryStream.Position = 0;

			this.Main_DockManager.LoadFromBinary(this._dockMemoryStream);
		}
		
		/// <summary>
		/// ������^�̐����𐔎��^�ɕύX����
		/// </summary>
		/// <param>none</param>
		/// <returns>false:�m��͕s�v,true:�m�肪�K�v</returns>
		/// <remarks>
		/// <br>Note       : ������^�̐����𐔎��^�ɕύX����</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private int StrToIntDef(string s, int defInt)
		{
			try
			{
				return Convert.ToInt32(s);
			}
			catch(Exception)
			{
				return 0;
			}
		}
		# endregion

		# region Control Events
		/// <summary>
		/// ���C���t���[����LOAD�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g���</param>
		/// <remarks>
		/// <br>Note       : ���C���t���[����LOAD�C�x���g</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private void SFUKK01401UA_Load(object sender, EventArgs e)
		{
            // ����N���t���O
			if (this._firstStartFlg == 0)
			{
                // �� 20070131 18322 c MA.NS�p�ɕύX
                // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
                this._controlScreenSkin.LoadSkin();

                // ��ʃX�L���ύX
                this._controlScreenSkin.SettingScreenSkin(this);
                // �� 20070131 18322 c

                // �����`�[���͊֘A�ݒ�f�[�^�擾����
				string errmsg;
                int st = this.depositRelDataAcs.GetInitialSettingData(out errmsg);
                if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �G���[����
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, this.Name, errmsg, st, MessageBoxButtons.OK);
                    return;
                }

				// ���O�C���S���҂�\��
				Main_ToolbarsManager.Tools["LoginName_LabelTool"].SharedProps.Caption = ((Employee)LoginInfoAcquisition.Employee).Name;

				// �c�[���{�^������
				this.ToolButtonSetting();

				// ���_���X�g�ݒ菈��
				this.SectionSetting();

				// ��ʃ^�C�v�R���{�{�b�N�X����
				this.SetDispTypList();

                BeginControllingByOperationAuthority();

				++this._firstStartFlg;
			}

			// �N���^�C�}�[�J�n
			startTimer.Enabled = true;
		}

		/// <summary>
		/// �N���^�C�}�[�J�n�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g���</param>
		/// <remarks>
		/// <br>Note       : �N���������s���܂��B</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private void startTimer_Tick(object sender, EventArgs e)
		{
			// �N���^�C�}�[�I��
			startTimer.Enabled = false;

			// �X�[�p�[�X���C�_�[����������
            this.InitializeSlider();

			// �f�t�H���g��ʃ^�C�v�I������
			this.DefaultSelectDispTypy(this._startingMode);

			// �N�����[�h���w�肳��Ă��鎞��
			switch (this._startingMode)
			{
				case StartingMode.CustomerCode :		// --- ���Ӑ�R�[�h�w�胂�[�h --- //

					// Tab�q��ʂ̃f�[�^�\���w�� (���Ӑ�R�[�h�w�胂�[�h)
					this.RefreshTabChildCustomerMode(this._startingParameter.CustomerCode);

					break;
                
                // �� 20070130 18322 c MA.NS�p�ɕύX
				//case StartingMode.AcceptAnOrderNo :		// --- �󒍔ԍ��w�胂�[�h --- //
                //    
				//	// Tab�q��ʂ̃f�[�^�\���w�� (�`�[�ԍ��w�胂�[�h)
				//	this.RefreshTabChildAcceptAnOrderMode(this._startingParameter.CustomerCode, this._startingParameter.AcceptAnOrderNo);
				//	
				//	break;

				case StartingMode.SalesSlipNum :		// --- ����`�[�ԍ��w�胂�[�h --- //

					// Tab�q��ʂ̃f�[�^�\���w�� (����`�[�ԍ��w�胂�[�h)
					this.RefreshTabChildSlipNumberMode(this._startingParameter.CustomerCode, 0, this._startingParameter.SalesSlipNum);
					
					break;
                // �� 20070130 18322 c
			}

			// DockManager�̏�Ԃ�ێ�����
			this._dockMemoryStream = new MemoryStream();
			this.Main_DockManager.SaveAsBinary(this._dockMemoryStream);
		}

		/// <summary>
		/// ToolBar��click�E�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g���</param>
		/// <remarks>
		/// <br>Note       : ToolBar��click�E�C�x���g</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
        /// <br>Update Note: 2012/12/24 ���N</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>           : Redmine#33741�̑Ή�</br>
		/// </remarks>
		private void Main_ToolbarsManager_ToolClick(object sender, ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "btnClose":			// --- �I�� --- //
				{
					// ���C����ʂ̃N���[�Y
					this.Close();
					return;
				}
				case "btnInitWindow":		// --- �E�B���h�E������������ --- //
				{
					// �E�B���h�E����������
					this.InitWindow();
					return;
				}
			}

			// ���݁A�A�N�e�B�u�ȉ�ʂ��擾����
			Form frm = this.Main_UTabControl.ActiveTab.Tag as Form;

			// IDepositInputMDIChild�C���^�[�t�F�C�X���������Ă���ꍇ�݈̂ȉ����s
			if ((frm == null) || (!(frm is IDepositInputMDIChild))) return;

			switch (e.Tool.Key)
			{
				case "btnSave":				// --- �ۑ� --- //
				{
                    DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                            "SFUKK01401U",
                                            "�o�^���Ă���낵���ł����H",
                                            0,
                                            MessageBoxButtons.YesNo);
                    if (dr == DialogResult.No)
                    {
                        return;
                    }

					// �ۑ�����
					((IDepositInputMDIChild)frm).SaveDepositProc();
					break;
				}
				case "btnNew":				// --- �V�K --- //
				{
					// �V�K����
					((IDepositInputMDIChild)frm).NewDepositProc();
					break;
				}
				case "btnDelete":			// --- �폜 --- //
				{
					// �폜����
					((IDepositInputMDIChild)frm).DeleteDepositProc();
					break;
				}
			case "btnAka":					// --- �ԓ` --- //
				{
					// �ԓ`����
					((IDepositInputMDIChild)frm).AkaDepositProc();
					break;
				}
			case "btnReceiptPrint":			// --- �̎������s --- //
				{
					// �̎������s����
					((IDepositInputMDIChild)frm).ReceiptPrintProc();
					break;
				}
            case "btnRenewal":
                {
                    ((IDepositInputMDIChild)frm).RenewalProc();
                    // 2009/07/21 >>>>>>>>>>>>>>>>>>
                    SetDispTypList();
                    // 2009/07/21 <<<<<<<<<<<<<<<<<<
                    break;
                }

            // ----- ADD ���N 2012/12/24 Redmine#33741 ---------->>>>> 
            case "btnReadslip":             // --- �����`�[�ďo --- //
                {
                    ((IDepositInputMDIChild)frm).ReadSlipProc();
                    break;
                }
            // ----- ADD ���N 2012/12/24 Redmine#33741 ----------<<<<<
			}
		}

		/// <summary>
		/// �t�H�[���b�k�n�r�d�E�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g���</param>
		/// <remarks>
		/// <br>Note       : �t�H�[���b�k�n�r�d�E�C�x���g</br>
		/// <br>Programer  : 97036 amami</br>
        /// <br>Date       : 2005.07.30</br>
        /// <br>Update Note: 2013/02/05 �c����</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2013/03/13�z�M��</br>
        /// <br>           : Redmine#33735 ��ʂ����Ƃ��A��O���N����Ή�</br>
		/// </remarks>
		private void onClosing(object sender, CancelEventArgs e)
		{
			// ���݁A�A�N�e�B�u�ȉ�ʂ��擾����
			Form frm = this.Main_UTabControl.ActiveTab.Tag as Form;

			// �����ς̎��͕\������
			// IDepositInputMDIChild�C���^�[�t�F�C�X���������Ă���ꍇ�͈ȉ��̏��������s����B
			if ((frm != null) && ((frm is IDepositInputMDIChild)))
			{
				object parameter = null;
				if (((IDepositInputMDIChild)frm).BeforeClose(parameter) != 0)
				{
					e.Cancel = true;
					return;
				}
			}

			if (this.Main_UTabControl.Tabs.Exists(TAB_NORMALTYPE))
			{
				// �X���C�_�[�̕\�����e��ۑ�����
				if (this._superSliderDepo != null) this._superSliderDepo.ClosePanel();
			}
			if (this.Main_UTabControl.Tabs.Exists(TAB_SALESTYPE))
			{
				// �X���C�_�[�̕\�����e��ۑ�����
				if (this._superSliderOrder != null) this._superSliderOrder.ClosePanel();
			}

			// �^�u�폜����
			TabRemove(TAB_NORMALTYPE);
			TabRemove(TAB_SALESTYPE);

            // ���Ӑ挟���^�u�폜����
            this.Main_DockManager.HostControl = null;// ADD 2013/02/05 �c���� Redmine#33735

			// �f�t�H���g��ʃ^�C�v�I������
			this.DefaultSelectDispTypy(StartingMode.Closed);
		}

		/// <summary>
		/// �c�[���o�[���e�I���C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g���</param>
		/// <remarks>
		/// <br>Note       : �c�[���o�[�̊e�A�C�e�����e���I�����ꂽ���ɔ������܂�</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private void Main_ToolbarsManager_ToolValueChanged(object sender, ToolEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "DispTypeList":			// --- ��ʃ^�C�v�I�� --- //
					{
						// ��d�N���h�~�t���O����
						if (selectDispTypeFlg == true) return;

						// ��ʃ^�C�v�R���{�{�b�N�X�̎擾
						ComboBoxTool dispTypeList = (ComboBoxTool)e.Tool;
						if (dispTypeList.Value == null) return;

						// ���݃A�N�e�B�u�^�u�����邩
						if (this.Main_UTabControl.ActiveTab != null)
						{
							// ���݁A�A�N�e�B�u�ȉ�ʂ��擾����
							Form frm = this.Main_UTabControl.ActiveTab.Tag as Form;

							// �����ς̎��͕\������
							// IDepositInputMDIChild�C���^�[�t�F�C�X���������Ă���ꍇ�͈ȉ��̏��������s����B
							if ((frm != null) && ((frm is IDepositInputMDIChild)))
							{
								object parameter = null;
								if (((IDepositInputMDIChild)frm).BeforeTabChange(parameter) != 0)
								{
									// �O��I����ʃ^�C�v�ɖ߂� ���C�x���g�̓�d�N���h�~�t���O�g�p
									selectDispTypeFlg = true;
                                    // --------- ADD BY zhujw 2014/07/08 RedMine#42902�̇G �����̏�Q���C---->>>>>
                                    if (null != selectedDispTypeItem)
                                    {
                                        for (int i = 0; i < dispTypeList.ValueList.ValueListItems.Count; i++)
                                        {
                                            if (dispTypeList.ValueList.ValueListItems[i].DisplayText == ((Infragistics.Win.ValueListItem)selectedDispTypeItem).DisplayText)
                                            {
                                                selectedDispTypeItem = dispTypeList.ValueList.ValueListItems[i];
                                            }
                                        }
                                    }
                                    // --------- ADD BY zhujw 2014/07/08 RedMine#42902�̇G �����̏�Q���C----<<<<<
									dispTypeList.SelectedItem = selectedDispTypeItem;
									selectDispTypeFlg = false;
									return;
								}
							}
						}

						// �^�u�폜����
						TabRemove(TAB_NORMALTYPE);
						TabRemove(TAB_SALESTYPE);

						switch ((int)dispTypeList.Value)
						{
							case 1:

								// �^�u����
								this.TabCreate(TAB_NORMALTYPE);

								// �^�u�A�N�e�B�u������
								this.TabActive(TAB_NORMALTYPE);

								// �����^�p�X���C�_�[�̕\��
								SlipSearch_Panel.Controls[0].Visible = true;
								SlipSearch_Panel.Controls[1].Visible = false;

								break;

							case 2:

								// �^�u����
								this.TabCreate(TAB_SALESTYPE);

								// �^�u�A�N�e�B�u������
								this.TabActive(TAB_SALESTYPE);

                                //// ����w��^�p�X���C�_�[�̕\��
                                //SlipSearch_Panel.Controls[0].Visible = false;
                                //SlipSearch_Panel.Controls[1].Visible = true;

                                // �����^�p�X���C�_�[�̕\��
                                SlipSearch_Panel.Controls[0].Visible = true;
                                SlipSearch_Panel.Controls[1].Visible = false;

								break;
						}

                        //// ���j���[�o�[�̏I���{�^�����Ō���ֈړ�
                        //PopupMenuTool file_PopupMenu = (PopupMenuTool)Main_ToolbarsManager.Tools["File_PopupMenuTool"];
                        //file_PopupMenu.Tools.Remove(file_PopupMenu.Tools["btnClose"]);
                        //file_PopupMenu.Tools.AddTool("btnClose");

						// ���ݑI����ʃ^�C�v��ێ�
						selectedDispTypeItem = dispTypeList.SelectedItem;

						break;
					}
				case "KYOTENCOMBO":			// --- ���_�I�� --- //
					{
						// ��d�N���h�~�t���O����
						if (selectedSectionFlg == true) return;

						// ���_�R���{�{�b�N�X�̎擾
						ComboBoxTool sectionList = (ComboBoxTool)e.Tool;
						if (sectionList.Value == null) return;

						// ���݃A�N�e�B�u�^�u�����邩
						if (this.Main_UTabControl.ActiveTab != null)
						{
							// ���݁A�A�N�e�B�u�ȉ�ʂ��擾����
							Form frm = this.Main_UTabControl.ActiveTab.Tag as Form;

							// �����ς̎��͕\������
							// IDepositInputMDIChild�C���^�[�t�F�C�X���������Ă���ꍇ�͈ȉ��̏��������s����B
							if ((frm != null) && ((frm is IDepositInputMDIChild)))
							{
								// ���_�ύX�O�ʒm����
								if (((IDepositInputMDIChild)frm).BeforeSectionChange() != 0)
								{
									// �O��I�����_�ɖ߂� ���C�x���g�̓�d�N���h�~�t���O�g�p
									selectedSectionFlg = true;
									sectionList.SelectedItem = selectedSection;
									selectedSectionFlg = false;
									return;
								}

								// ���ݑI�����_��ێ�
								selectedSection = sectionList.SelectedItem;

								// ���_�ύX��ʒm����
								((IDepositInputMDIChild)frm).AfterSectionChange();
							}
						}
						else
						{
							// ���ݑI�����_��ێ�
							selectedSection = sectionList.SelectedItem;
						}

						break;
					}
			}
		}
		# endregion

		# region Public Enum
		/// <summary>
		/// �����`�[���͋N�����[�h
		/// </summary>
		/// <remarks>
		/// <br>Note       : �����`�[���͉�ʂ̋N�����[�h�񋓌^�ł��B</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		public enum StartingMode
		{
			/// <summary>�ʏ탂�[�h</summary>
			Normal = 0,

			/// <summary>���Ӑ�R�[�h�w�胂�[�h</summary>
			CustomerCode = 1,

			/// <summary>�󒍔ԍ��w�胂�[�h</summary>
			AcceptAnOrderNo = 2,

            // �� 20070130 18322 a MA.NS�p�ɕύX
			/// <summary>����`�[�ԍ��w�胂�[�h</summary>
			SalesSlipNum = 3,
            // �� 20070130 18322 a

			/// <summary>�I�����[�h</summary>
			Closed = -1
		}
		# endregion

		# region Public class (parameter)
		/// <summary>
		/// �����`�[���͋N���p�����[�^�[
		/// </summary>
		/// <remarks>
		/// <br>Note       : �����`�[���͉�ʂ̋N���p�����[�^�[�N���X�ł��B</br>
		/// <br>Programer  : 97036 amami</br>
		/// <br>Date       : 2005.07.30</br>
        /// <br>Update Note: 2007.01.30 18322 T.Kimura MA.NS�p�ɕύX</br>
		/// </remarks>
		public class StartingParameter
		{
			/// <summary>�R���X�g���N�^</summary>
			public StartingParameter()
			{
				_addSectionCode = "";
				_acceptAnOrderNo = 0;
				_customerCode = 0;
                // �� 20070130 18322 a MA.NS�p�ɕύX
                _salesSlipNum = "";
                // �� 20070130 18322 a
			}

			/// <summary>�v�㋒�_</summary>
			private string _addSectionCode;

			/// <summary>�󒍔ԍ�</summary>
			private Int32 _acceptAnOrderNo;

			/// <summary>���Ӑ�R�[�h</summary>
			private Int32 _customerCode;

            // �� 20070130 18322 a MA.NS�p�ɕύX
			/// <summary>����`�[�ԍ�</summary>
			private string _salesSlipNum;
            // �� 20070130 18322 a

			/// <summary>�v�㋒�_ �v���p�e�B</summary>
			public string AddSectionCode
			{
				get{return _addSectionCode;}
				set{_addSectionCode = value;}
			}

			/// <summary>�󒍔ԍ� �v���p�e�B</summary>
			public Int32 AcceptAnOrderNo
			{
				get{return _acceptAnOrderNo;}
				set{_acceptAnOrderNo = value;}
			}

			/// <summary>���Ӑ�R�[�h �v���p�e�B</summary>
			public Int32 CustomerCode
			{
				get{return _customerCode;}
				set{_customerCode = value;}
			}

            // �� 20070130 18322 a MA.NS�p�ɕύX
			/// <summary>����`�[�ԍ� �v���p�e�B</summary>
			public string SalesSlipNum
			{
				get{return _salesSlipNum;}
				set{_salesSlipNum = value;}
			}
            // �� 20070130 18322 a
        }
		# endregion

		# region Debug
		private static DateTime _dtime_s1, _dtime_e1;
		private static System.IO.FileStream _fs1 = null;
		private static System.IO.StreamWriter _sw1 = null;
		private static void DebugLogWrite(int mode, string msg)
		{
			_fs1 = new System.IO.FileStream("SFUKK01401U_Log.txt", System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.Write);
			_sw1 = new System.IO.StreamWriter(_fs1, System.Text.Encoding.GetEncoding("shift_jis"));
			if (mode == 0)
			{

				_dtime_s1 = DateTime.Now;
				TimeSpan ts = _dtime_s1.Subtract(_dtime_s1);
				string s = String.Format("{0,-20} {1,-5} ==> {2,-20} [0] {3} \n",
					_dtime_s1, _dtime_s1.Millisecond, ts.ToString(), msg);
				_sw1.WriteLine(s);
				//				System.Diagnostics.Debug.WriteLine( s );
			}
			else if (mode == 1)
			{
				_dtime_e1 = DateTime.Now;
				TimeSpan ts = _dtime_e1.Subtract(_dtime_s1);
				string s = string.Format("{0,-20} {1,-5} ==> {2,-20} [1] {3} \n",
					_dtime_e1, _dtime_e1.Millisecond, ts.ToString(), msg);

				_sw1.WriteLine(s);
				//				System.Diagnostics.Debug.WriteLine( s );

				_dtime_s1 = _dtime_e1;
			}
			else if (mode == 9)
			{
			}
			_sw1.Close();
			_fs1.Close();
		}

		private static DateTime _dtime_s2, _dtime_e2;
		private static System.IO.FileStream _fs2 = null;
		private static System.IO.StreamWriter _sw2 = null;
		private static void DebugLogWrite2(int mode, string msg)
		{
			_fs2 = new System.IO.FileStream("SFUKK01401U_Log.txt", System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.Write);
			_sw2 = new System.IO.StreamWriter(_fs2, System.Text.Encoding.GetEncoding("shift_jis"));
			if (mode == 0)
			{

				_dtime_s2 = DateTime.Now;
				TimeSpan ts = _dtime_s2.Subtract(_dtime_s2);
				string s = String.Format("{0,-20} {1,-5} ==> {2,-20} [0] {3} \n",
					_dtime_s2, _dtime_s2.Millisecond, ts.ToString(), msg);
				_sw2.WriteLine(s);
				//				System.Diagnostics.Debug.WriteLine( s );
			}
			else if (mode == 1)
			{
				_dtime_e2 = DateTime.Now;
				TimeSpan ts = _dtime_e2.Subtract(_dtime_s2);
				string s = string.Format("{0,-20} {1,-5} ==> {2,-20} [1] {3} \n",
					_dtime_e2, _dtime_e2.Millisecond, ts.ToString(), msg);

				_sw2.WriteLine(s);
				//				System.Diagnostics.Debug.WriteLine( s );

				_dtime_s2 = _dtime_e2;
			}
			else if (mode == 9)
			{
			}
			_sw2.Close();
			_fs2.Close();
		}
		# endregion

        private void uButton_Close_Click(object sender, EventArgs e)
        {
            // �{�^�����uVisible = False�v�ɂ���ƁA�C�x���g���������Ȃ����߁A
            // �T�C�Y���u1, 1�v�ɂ��A�����I�Ɍ����Ȃ��悤�ɂ���

            DialogResult dResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name,
                            "�I�����Ă���낵���ł����H",
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);

            if (dResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
	}
}

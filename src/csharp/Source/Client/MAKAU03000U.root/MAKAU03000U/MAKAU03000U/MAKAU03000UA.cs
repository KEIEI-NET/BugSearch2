//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���������s(�d�q����A�g)UI�N���X
// �v���O�����T�v   : ���������s(�d�q����A�g) UI�t�H�[���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright 2022 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570183-00   �쐬�S�� : ���O
// �� �� ��  2022/03/07    �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11870080-00   �쐬�S�� : ���O
// �� �� ��  2022/04/21    �C�����e : �d�q����2���Ή�
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Facade;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Text;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���������s(�d�q����A�g)�����t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : ���������s(�d�q����A�g)�����t�H�[���N���X�ł��B</br>
    /// <br>Programmer  : ���O</br>
    /// <br>Date        : 2022/03/07</br>
    /// <br>Update Note  : 2020/04/21 ���O</br>
    /// <br>�Ǘ��ԍ�     : 11870080-00 �d�q����2���Ή�</br> 
    /// </remarks>
    public class MAKAU03000UA : System.Windows.Forms.Form
    {
        # region Private Members (Component)
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager Main_ToolbarsManager;
        private System.Windows.Forms.Timer Initial_Timer;
        private Infragistics.Win.UltraWinDock.UltraDockManager Main_DockManager;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar Main_StatusBar;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU03000UA_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU03000UA_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU03000UA_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU03000UA_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _MAKAU03000UAUnpinnedTabAreaLeft;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _MAKAU03000UAUnpinnedTabAreaRight;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _MAKAU03000UAUnpinnedTabAreaTop;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _MAKAU03000UAUnpinnedTabAreaBottom;
        private Infragistics.Win.UltraWinDock.AutoHideControl _MAKAU03000UAAutoHideControl;
        private TMemPos tMemPos1;
        private ContextMenu TabControl_contextMenu;
        private MenuItem Close_menuItem;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl Main_UTabControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage DataViewTabSharedControlsPage;
        private System.ComponentModel.IContainer components;
        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : �R���X�g���N�^����</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public MAKAU03000UA()
        {
            InitializeComponent();

            // �������f�[�^�A�N�Z�X�N���X�C���X�^���X��
            this._demandPrintAcs = new DemandEBooksPrintAcs();

            // PDF�폜���X�g�e�[�u���쐬
            this._delPDFList = new Hashtable();

            // PDF�����Ǘ����i
            this._pdfHistoryCtrl = new PdfHistoryControl();
        }
        #endregion

        // ===================================================================================== //
        // �j��
        // ===================================================================================== //
        # region Dispose
        /// <summary>
        /// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
        /// </summary>
        /// <remarks>
        /// <br>Note        : �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
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

        // ===================================================================================== //
        // Windows�t�H�[���f�U�C�i�Ő������ꂽ�R�[�h
        // ===================================================================================== //
        #region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h
        /// <summary>
        /// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
        /// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("MainMenu_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Tool_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Window_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Button_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Extract_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Sync_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Return_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Print_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("PrintPreview_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Preview_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("PDFSave_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("TextOutPut_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Extract_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Print_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Preview_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("PDFSave_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("TextOutPut_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool5 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Tool_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UserSetUp_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool6 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Window_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool5 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool6 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UserSetUp_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool7 = new Infragistics.Win.UltraWinToolbars.LabelTool("PrintKindTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboBoxTool1 = new Infragistics.Win.UltraWinToolbars.ComboBoxTool("PrintKind_ComboBoxTool");
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(0);
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool19 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Extract_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool20 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Preview_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool21 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Print_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool8 = new Infragistics.Win.UltraWinToolbars.LabelTool("STOP_LabelTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool1 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("PrtSuspendCnt_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool9 = new Infragistics.Win.UltraWinToolbars.LabelTool("Number_LabelTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool22 = new Infragistics.Win.UltraWinToolbars.ButtonTool("PDFSave_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool23 = new Infragistics.Win.UltraWinToolbars.ButtonTool("TextOutPut_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool7 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Forms_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool24 = new Infragistics.Win.UltraWinToolbars.ButtonTool("PrintPreview_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool25 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Sync_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool26 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Return_ButtonTool");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAKAU03000UA));
            this.Main_DockManager = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._MAKAU03000UAUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MAKAU03000UAUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MAKAU03000UAUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MAKAU03000UAUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MAKAU03000UAAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Main_StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tMemPos1 = new Broadleaf.Library.Windows.Forms.TMemPos(this.components);
            this.TabControl_contextMenu = new System.Windows.Forms.ContextMenu();
            this.Close_menuItem = new System.Windows.Forms.MenuItem();
            this.DataViewTabSharedControlsPage = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.Main_UTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this._MAKAU03000UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Main_ToolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._MAKAU03000UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._MAKAU03000UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._MAKAU03000UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_UTabControl)).BeginInit();
            this.Main_UTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).BeginInit();
            this.SuspendLayout();
            // 
            // Main_DockManager
            // 
            this.Main_DockManager.CaptionStyle = Infragistics.Win.UltraWinDock.CaptionStyle.Office2003;
            this.Main_DockManager.HostControl = this;
            this.Main_DockManager.ShowCloseButton = false;
            this.Main_DockManager.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2003;
            // 
            // _MAKAU03000UAUnpinnedTabAreaLeft
            // 
            this._MAKAU03000UAUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._MAKAU03000UAUnpinnedTabAreaLeft.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._MAKAU03000UAUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 88);
            this._MAKAU03000UAUnpinnedTabAreaLeft.Name = "_MAKAU03000UAUnpinnedTabAreaLeft";
            this._MAKAU03000UAUnpinnedTabAreaLeft.Owner = this.Main_DockManager;
            this._MAKAU03000UAUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 623);
            this._MAKAU03000UAUnpinnedTabAreaLeft.TabIndex = 5;
            // 
            // _MAKAU03000UAUnpinnedTabAreaRight
            // 
            this._MAKAU03000UAUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._MAKAU03000UAUnpinnedTabAreaRight.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._MAKAU03000UAUnpinnedTabAreaRight.Location = new System.Drawing.Point(1016, 88);
            this._MAKAU03000UAUnpinnedTabAreaRight.Name = "_MAKAU03000UAUnpinnedTabAreaRight";
            this._MAKAU03000UAUnpinnedTabAreaRight.Owner = this.Main_DockManager;
            this._MAKAU03000UAUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 623);
            this._MAKAU03000UAUnpinnedTabAreaRight.TabIndex = 6;
            // 
            // _MAKAU03000UAUnpinnedTabAreaTop
            // 
            this._MAKAU03000UAUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._MAKAU03000UAUnpinnedTabAreaTop.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._MAKAU03000UAUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 88);
            this._MAKAU03000UAUnpinnedTabAreaTop.Name = "_MAKAU03000UAUnpinnedTabAreaTop";
            this._MAKAU03000UAUnpinnedTabAreaTop.Owner = this.Main_DockManager;
            this._MAKAU03000UAUnpinnedTabAreaTop.Size = new System.Drawing.Size(1016, 0);
            this._MAKAU03000UAUnpinnedTabAreaTop.TabIndex = 7;
            // 
            // _MAKAU03000UAUnpinnedTabAreaBottom
            // 
            this._MAKAU03000UAUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._MAKAU03000UAUnpinnedTabAreaBottom.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._MAKAU03000UAUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 711);
            this._MAKAU03000UAUnpinnedTabAreaBottom.Name = "_MAKAU03000UAUnpinnedTabAreaBottom";
            this._MAKAU03000UAUnpinnedTabAreaBottom.Owner = this.Main_DockManager;
            this._MAKAU03000UAUnpinnedTabAreaBottom.Size = new System.Drawing.Size(1016, 0);
            this._MAKAU03000UAUnpinnedTabAreaBottom.TabIndex = 8;
            // 
            // _MAKAU03000UAAutoHideControl
            // 
            this._MAKAU03000UAAutoHideControl.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._MAKAU03000UAAutoHideControl.Location = new System.Drawing.Point(22, 50);
            this._MAKAU03000UAAutoHideControl.Name = "_MAKAU03000UAAutoHideControl";
            this._MAKAU03000UAAutoHideControl.Owner = this.Main_DockManager;
            this._MAKAU03000UAAutoHideControl.Size = new System.Drawing.Size(233, 661);
            this._MAKAU03000UAAutoHideControl.TabIndex = 9;
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // Main_StatusBar
            // 
            this.Main_StatusBar.Location = new System.Drawing.Point(0, 711);
            this.Main_StatusBar.Name = "Main_StatusBar";
            appearance4.TextHAlignAsString = "Left";
            this.Main_StatusBar.PanelAppearance = appearance4;
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
            this.Main_StatusBar.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3});
            this.Main_StatusBar.Size = new System.Drawing.Size(1016, 23);
            this.Main_StatusBar.TabIndex = 28;
            this.Main_StatusBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tMemPos1
            // 
            this.tMemPos1.OwnerForm = this;
            // 
            // TabControl_contextMenu
            // 
            this.TabControl_contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Close_menuItem});
            // 
            // Close_menuItem
            // 
            this.Close_menuItem.Index = 0;
            this.Close_menuItem.Text = "����(&C)";
            this.Close_menuItem.Click += new System.EventHandler(this.Close_menuItem_Click);
            // 
            // DataViewTabSharedControlsPage
            // 
            this.DataViewTabSharedControlsPage.Location = new System.Drawing.Point(1, 20);
            this.DataViewTabSharedControlsPage.Name = "DataViewTabSharedControlsPage";
            this.DataViewTabSharedControlsPage.Size = new System.Drawing.Size(1014, 602);
            // 
            // Main_UTabControl
            // 
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BackColor2 = System.Drawing.Color.AliceBlue;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Main_UTabControl.Appearance = appearance3;
            this.Main_UTabControl.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.Main_UTabControl.Controls.Add(this.DataViewTabSharedControlsPage);
            this.Main_UTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_UTabControl.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Main_UTabControl.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.Main_UTabControl.Location = new System.Drawing.Point(0, 88);
            this.Main_UTabControl.Name = "Main_UTabControl";
            this.Main_UTabControl.SharedControlsPage = this.DataViewTabSharedControlsPage;
            this.Main_UTabControl.Size = new System.Drawing.Size(1016, 623);
            this.Main_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.Main_UTabControl.TabIndex = 29;
            this.Main_UTabControl.TabPadding = new System.Drawing.Size(3, 3);
            this.Main_UTabControl.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Main_UTabControl.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            this.Main_UTabControl.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(this.Main_UTabControl_SelectedTabChanged);
            // 
            // _MAKAU03000UA_Toolbars_Dock_Area_Left
            // 
            this._MAKAU03000UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU03000UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._MAKAU03000UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._MAKAU03000UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU03000UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 88);
            this._MAKAU03000UA_Toolbars_Dock_Area_Left.Name = "_MAKAU03000UA_Toolbars_Dock_Area_Left";
            this._MAKAU03000UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 623);
            this._MAKAU03000UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.Main_ToolbarsManager;
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
            labelTool1.InstanceProps.Spring = Infragistics.Win.DefaultableBoolean.True;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1,
            popupMenuTool2,
            popupMenuTool3,
            labelTool1,
            labelTool2,
            labelTool3});
            ultraToolbar1.ShowInToolbarList = false;
            ultraToolbar1.Text = "���C�����j���[";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 1;
            buttonTool5.InstanceProps.IsFirstInGroup = true;
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            buttonTool4,
            buttonTool5,
            buttonTool6,
            buttonTool7,
            buttonTool8,
            buttonTool9});
            ultraToolbar2.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.BelowImage;
            ultraToolbar2.Text = "�W��";
            this.Main_ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2});
            popupMenuTool4.SharedProps.Caption = "�t�@�C��(&F)";
            popupMenuTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            buttonTool15.InstanceProps.IsFirstInGroup = true;
            popupMenuTool4.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool10,
            buttonTool11,
            buttonTool12,
            buttonTool13,
            buttonTool14,
            buttonTool15});
            popupMenuTool5.SharedProps.Caption = "�c�[��(&T)";
            popupMenuTool5.SharedProps.Visible = false;
            popupMenuTool5.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool16});
            popupMenuTool6.SharedProps.Caption = "�E�B���h�E(&W)";
            popupMenuTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            popupMenuTool6.SharedProps.Visible = false;
            labelTool5.SharedProps.Caption = "���O�C���S����";
            labelTool5.SharedProps.ShowInCustomizer = false;
            appearance5.BackColor = System.Drawing.Color.White;
            appearance5.TextHAlignAsString = "Left";
            appearance5.TextVAlignAsString = "Bottom";
            labelTool6.SharedProps.AppearancesSmall.Appearance = appearance5;
            labelTool6.SharedProps.ShowInCustomizer = false;
            labelTool6.SharedProps.Width = 150;
            buttonTool17.SharedProps.Caption = "�I��(F1)";
            buttonTool17.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool17.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F1;
            buttonTool17.SharedProps.ShowInCustomizer = false;
            buttonTool18.SharedProps.Caption = "���[�U�[�ݒ�(&C)";
            buttonTool18.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool18.SharedProps.ShowInCustomizer = false;
            labelTool7.SharedProps.Caption = "���ޑI��";
            labelTool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            comboBoxTool1.MaxLength = 30;
            comboBoxTool1.SharedProps.Caption = "���ޑI��";
            valueListItem1.DataValue = ((short)(1));
            valueListItem1.DisplayText = "�����ꗗ�\";
            valueListItem2.DataValue = ((short)(2));
            valueListItem2.DisplayText = "�������i�Ӂj";
            valueListItem3.DataValue = ((short)(3));
            valueListItem3.DisplayText = "�������׏�(�ڍ�)";
            valueListItem4.DataValue = ((short)(4));
            valueListItem4.DisplayText = "�������׏�(�`�[)";
            valueListItem5.DataValue = ((short)(5));
            valueListItem5.DisplayText = "�̎���";
            valueList1.ValueListItems.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3,
            valueListItem4,
            valueListItem5});
            comboBoxTool1.ValueList = valueList1;
            buttonTool19.SharedProps.Caption = "�d�q���듯��(&X)";
            buttonTool19.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool20.SharedProps.Caption = "PDF�\��(F11)";
            buttonTool20.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool20.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F11;
            buttonTool21.SharedProps.Caption = "���(F10)";
            buttonTool21.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool21.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F10;
            labelTool8.SharedProps.Caption = "����ꎞ���f����";
            labelTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            controlContainerTool1.SharedProps.MaxWidth = 40;
            controlContainerTool1.SharedProps.MinWidth = 40;
            controlContainerTool1.SharedProps.Width = 41;
            labelTool9.SharedProps.Caption = "��";
            labelTool9.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            buttonTool22.SharedProps.Caption = "PDF����ۑ�(F12)";
            buttonTool22.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool22.SharedProps.Enabled = false;
            buttonTool22.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F12;
            buttonTool23.SharedProps.Caption = "�e�L�X�g�o��(&O)";
            buttonTool23.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool23.SharedProps.Visible = false;
            popupMenuTool7.SharedProps.Caption = "�^�u�ؑ�(&J)";
            popupMenuTool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            popupMenuTool7.SharedProps.ToolTipText = "��ʂ�؂�ւ��܂��B";
            buttonTool24.SharedProps.Caption = "����v���r���[(&W)";
            buttonTool24.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool25.SharedProps.Caption = "����(&S)";
            buttonTool25.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool26.SharedProps.Caption = "���o�����ɖ߂�(F2)";
            buttonTool26.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool26.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F2;
            this.Main_ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool4,
            popupMenuTool5,
            popupMenuTool6,
            labelTool4,
            labelTool5,
            labelTool6,
            buttonTool17,
            buttonTool18,
            labelTool7,
            comboBoxTool1,
            buttonTool19,
            buttonTool20,
            buttonTool21,
            labelTool8,
            controlContainerTool1,
            labelTool9,
            buttonTool22,
            buttonTool23,
            popupMenuTool7,
            buttonTool24,
            buttonTool25,
            buttonTool26});
            this.Main_ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.Main_ToolbarsManager_ToolClick);
            // 
            // _MAKAU03000UA_Toolbars_Dock_Area_Right
            // 
            this._MAKAU03000UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU03000UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._MAKAU03000UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._MAKAU03000UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU03000UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1016, 88);
            this._MAKAU03000UA_Toolbars_Dock_Area_Right.Name = "_MAKAU03000UA_Toolbars_Dock_Area_Right";
            this._MAKAU03000UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 623);
            this._MAKAU03000UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _MAKAU03000UA_Toolbars_Dock_Area_Top
            // 
            this._MAKAU03000UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU03000UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._MAKAU03000UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._MAKAU03000UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU03000UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._MAKAU03000UA_Toolbars_Dock_Area_Top.Name = "_MAKAU03000UA_Toolbars_Dock_Area_Top";
            this._MAKAU03000UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1016, 88);
            this._MAKAU03000UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _MAKAU03000UA_Toolbars_Dock_Area_Bottom
            // 
            this._MAKAU03000UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU03000UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._MAKAU03000UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._MAKAU03000UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU03000UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 711);
            this._MAKAU03000UA_Toolbars_Dock_Area_Bottom.Name = "_MAKAU03000UA_Toolbars_Dock_Area_Bottom";
            this._MAKAU03000UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1016, 0);
            this._MAKAU03000UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // MAKAU03000UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this._MAKAU03000UAAutoHideControl);
            this.Controls.Add(this.Main_UTabControl);
            this.Controls.Add(this._MAKAU03000UAUnpinnedTabAreaTop);
            this.Controls.Add(this._MAKAU03000UAUnpinnedTabAreaBottom);
            this.Controls.Add(this._MAKAU03000UAUnpinnedTabAreaLeft);
            this.Controls.Add(this._MAKAU03000UAUnpinnedTabAreaRight);
            this.Controls.Add(this._MAKAU03000UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._MAKAU03000UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._MAKAU03000UA_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._MAKAU03000UA_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.Main_StatusBar);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MAKAU03000UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "�������n�t���[��";
            this.Load += new System.EventHandler(this.MAKAU03000UA_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MAKAU03000UA_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_UTabControl)).EndInit();
            this.Main_UTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        // ===================================================================================== //
        // ���C��
        // ===================================================================================== //
        #region Main
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        /// <remarks>
        /// <br>Note        : �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                string msg = string.Empty;
                _parameter = args;
                //�A�v���P�[�V�����J�n���������B���p�����[�^�̓A�v���P�[�V�����̃\�t�g�E�F�A�R�[�h���w��o����ꍇ�͎w��B�o���Ȃ��ꍇ�̓v���_�N�g�R�[�h
                int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
                if (status == 0)
                {
                    // �N�����[�h�擾
                    if (_parameter.Length != 0)
                    {
                        string param = _parameter[0].ToString();
                        _startMode = Broadleaf.Library.Text.TStrConv.StrToIntDef(param, 0);
                    }

                    // �I�����C����Ԕ���
                    if (!Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag)
                    {
                        Form form = new Form();
                        form.TopMost = true;
                        // �I�t���C�����
                        TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID,
                            MSG_OFFLINE, 0, MessageBoxButtons.OK);
                        form.TopMost = false;
                    }
                    else
                    {
                        System.Windows.Forms.Application.EnableVisualStyles();
                        System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                        _form = new MAKAU03000UA();
                        System.Windows.Forms.Application.Run(_form);
                    }
                }
                if (status != 0)
                {
                    Form form = new Form();
                    form.TopMost = true;
                    TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_INFO, CT_PGID, msg, 0, MessageBoxButtons.OK);
                    form.TopMost = false;
                }
            }
            catch (Exception ex)
            {
                Form form = new Form();
                form.TopMost = true;
                TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_STOPDISP, CT_PGID, ex.Message, 0, MessageBoxButtons.OK);
                form.TopMost = false;
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }
        }

        /// <summary>
        /// �A�v���P�[�V�����I���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note        : �A�v���P�[�V�����I���C�x���g</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            //���b�Z�[�W���o���O�ɑS�ĊJ��
            ApplicationStartControl.EndApplication();
            //�]�ƈ����O�I�t�̃��b�Z�[�W��\��
            Form form = new Form();
            form.TopMost = true;
            TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_INFO, CT_PGID, e.ToString(), 0, MessageBoxButtons.OK);
            form.TopMost = false;
            //�A�v���P�[�V�����I��
            System.Windows.Forms.Application.Exit();
        }
        #endregion

        // ===============================================================================
        // �v���C�x�[�g�񋓌^
        // ===============================================================================
        #region Private Enum
        /// <summary>������[�h</summary>
        private enum emPrintMode : int
        {
            /// <summary>���</summary>
            emPrinter = 1,
            /// <summary>�o�c�e</summary>
            emPDF = 2,
            /// <summary>������o�c�e</summary>
            emPrinterAndPDF = 3
        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�萔
        // ===================================================================================== //
        #region Private Constant
        private const string CT_PGID = "MAKAU03000U";
        private const string MAIN_FORM_TITLE = "�����Ǘ� - ";
        private const string DEMANDMAIN_TITLE = "���������s(�d�q����A�g)";
        private const string DEMANDLISTMAIN_TITLE = "�����ꗗ�\�i�d�q����A�g�j";
        private Hashtable _formControlInfoTable = new Hashtable();
        private const string DOCK_NAVIGATOR = "Navigator_Tree";
        private const string DOCK_EXPLORERBAR = "Main_ExplorerBar";
        private const string NO0_DEMANDMAIN_TAB = "DEMAND_MAIN_TAB";
        private const string NO1_LISTPREVIEW_TAB = "LISTPREVIEW_TAB";
        private const string NO2_TOTALPREVIEW_TAB = "TOTALPREVIEW_TAB";
        private const string TOTAL_PREVIEW_TAB_NAME = "�������v���r���[";
        private const string LIST_PREVIEW_TAB_NAME = "�����ꗗ�\�v���r���[";
        private const string DEMANDMAIN_TAB_NAME = "���������s�i�d�q����A�g�j";
        private const string DEMANDLISTMAIN_TAB_NAME = "�����ꗗ�\�i�d�q����A�g�j";
        private const string DXSTARTFILENAME = "\\eBookLauncher.vbs";
        private const string BLANK = "about:blank";
        private const string TEXT = "Text";

        // �N�����[�h�萔
        private const int START_MODE_DEFAULT_LIST = 1;		 // �����ꗗ�\
        private const int START_MODE_DEFAULT_TOTAL = 2;		 // �������i�Ӂj

        // �c�[���o�[�c�[���L�[�ݒ�
        private const string TOOLBAR_LOGINLABEL_TITLE = "LoginTitle_LabelTool";
        private const string TOOLBAR_LOGINNAMELABEL_KEY = "LoginName_LabelTool";
        private const string TOOLBAR_ENDBUTTON_KEY = "End_ButtonTool";
        private const string TOOLBAR_EXTRACTBUTTON_KEY = "Extract_ButtonTool";
        private const string TOOLBAR_SYNCBUTTON_KEY = "Sync_ButtonTool";
        private const string TOOLBAR_RETURNBUTTON_KEY = "Return_ButtonTool";// ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή�
        private const string TOOLBAR_PREVIEWBUTTON_KEY = "Preview_ButtonTool";
        private const string TOOLBAR_PRINTBUTTON_KEY = "Print_ButtonTool";
        private const string TOOLBAR_PDFSAVEBUTTON_KEY = "PDFSave_ButtonTool";

        private const string TOOLBAR_PRINTPREVIEWBUTTON_KEY = "PrintPreview_ButtonTool";
        private const string TABCONTROL_EXTRAINFOSCREEN_KEY = "ExtractInfoTab";
        private const string TABCONTROL_EXTRADATASCREEN_KEY = "ExtractDataTab";

        // ���b�Z�[�W
        private const string MSG_OFFLINE = "�I�t���C����ԂŖ{�@�\�͂��g�p�ł��܂���B";
        private const string MSG_PDFALREADYSAVE = "�Y���̂o�c�e�͊��ɗ���o�^����Ă��܂��B";
        private const string MSG_SAVESUCCESS = "�ۑ����܂����B";
        private const string MSG_SAVEFAILE = "�o�c�e�̗���ۑ��Ɏ��s���܂����B\n\r";
        private const string MSG_DXSTART = "�d��.DX���N�����܂����H";
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region Private Members
        // �N�����[�h[0:���������[(ALL),1:�����ꗗ�\,2:�������i�Ӂj,3:�������׏�,4:�������׈ꗗ�\,5:�̎���]
        private static int _startMode = 0;

        // ���o�����ݒ�t�H�[��
        private Form _extractionInfoForm = null;
        // �����ꗗ�p�v���r���[�t�H�[��
        private Form _listPreviewForm = null;
        // �������i�Ӂj�p�v���r���[�t�H�[��
        private Form _totalPreviewForm = null;
        #region <PDF/>

        /// <summary>
        /// �����\���p�̃v���r���[�t�H�[���̃}�b�v<br/>
        /// �i��1�ڂ̃v���r���[�t�H�[����<c>_totalPreviewForm</c>�܂���<c>_receiptPreviewForm</c>
        /// </summary>
        private IDictionary<string, Form> _otherPDFPreviewFormMap;
        /// <summary>
        /// �����\���p�̃v���r���[�t�H�[���̃}�b�v���擾���܂��B<br/>
        /// �i��1�ڂ̃v���r���[�t�H�[����<c>_totalPreviewForm</c>�܂���<c>_receiptPreviewForm</c>
        /// </summary>
        private IDictionary<string, Form> OtherPDFPreviewFormMap
        {
            get
            {
                if (_otherPDFPreviewFormMap == null)
                {
                    _otherPDFPreviewFormMap = new Dictionary<string, Form>();
                }
                return _otherPDFPreviewFormMap;
            }
        }

        /// <summary>
        /// �����\���p�̃v���r���[�t�H�[���̃}�b�v�̃L�[���擾���܂��B
        /// </summary>
        /// <param name="originalKey">1�ڂ̃v���r���[�t�H�[���̃L�[</param>
        /// <param name="index">�C���f�b�N�X�i1�`�j</param>
        /// <returns><c>originalKey + "," + index</c></returns>
        /// <remarks>
        /// <br>Note        : �����\���p�̃v���r���[�t�H�[���̃}�b�v�̃L�[���擾���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static string GetOtherPDFPreviewFormKey(
            string originalKey,
            int index
        )
        {
            return originalKey + "," + index.ToString();
        }

        /// <summary>���݂̏o��PDF���</summary>
        /// <remarks>PDF�o�͎��ɃC���X�^���X���X�V����܂��B</remarks>
        private PDFManager _currentOutputPDF = new PDFManager(new List<string>(), new List<string>());
        /// <summary>
        /// ���݂̏o��PDF���̃A�N�Z�T
        /// </summary>
        private PDFManager CurrentOutputPDF
        {
            get
            {
                if (_currentOutputPDF == null)
                {
                    _currentOutputPDF = new PDFManager(new List<string>(), new List<string>());
                }
                return _currentOutputPDF;
            }
            set { _currentOutputPDF = value; }
        }

        #endregion  // <PDF/>

        #region <���쌠������/>

        /// <summary>���쌠���̐���I�u�W�F�N�g�̃}�b�v</summary>
        /// <remarks>�L�[�F�v���O����ID</remarks>
        private readonly OperationAuthorityControllableMap<ReportController>
            _myOpeCtrlMap = new OperationAuthorityControllableMap<ReportController>();
        /// <summary>
        /// ���쌠���̐���I�u�W�F�N�g�̃}�b�v���擾���܂��B
        /// </summary>
        /// <value>���쌠���̐���I�u�W�F�N�g�̃}�b�v</value>
        private OperationAuthorityControllableMap<ReportController> MyOpeCtrlMap
        {
            get { return _myOpeCtrlMap; }
        }

        /// <summary>
        /// ���쌠���̐�����J�n���܂��B
        /// </summary>
        /// <param name="assemblyId">�A�Z���u��ID</param>
        /// <remarks>
        /// <br>Note        : ���쌠���̐�����J�n���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void BeginControllingByOperationAuthority(string assemblyId)
        {
            #region <Guard Phrase/>

            if (!MyOpeCtrlMap.ContainsKey(assemblyId)) return;

            #endregion  // <Guard Phrase/>

            // �c�[���{�^���̑��쌠���̐���ݒ�
            List<ToolButtonInfo> toolButtonInfoList = new List<ToolButtonInfo>();

            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_PRINTBUTTON_KEY, ReportFrameOpeCode.Print, false));
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_PRINTPREVIEWBUTTON_KEY, ReportFrameOpeCode.Print, false)); // ����v���r���[(����Ɠ�����)
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_EXTRACTBUTTON_KEY, ReportFrameOpeCode.Extract, false));
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_PREVIEWBUTTON_KEY, ReportFrameOpeCode.OutputPDF, false));
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_PDFSAVEBUTTON_KEY, ReportFrameOpeCode.SavePDF, false));

            MyOpeCtrlMap[assemblyId].MyOpeCtrl.AddControlItem(this.Main_ToolbarsManager, toolButtonInfoList);

            // ���쌠���̐�����J�n
            MyOpeCtrlMap[assemblyId].MyOpeCtrl.BeginControl();
        }

        #endregion  // <���쌠������/>

        private static string[] _parameter;
        private static System.Windows.Forms.Form _form = null;
        private DemandEBooksPrintAcs _demandPrintAcs = null;

        // �C�x���g�t���O
        private bool _eventDoFlag = false;
        private Hashtable _delPDFList = null;							// �폜PDF�i�[���X�g

        private PdfHistoryControl _pdfHistoryCtrl = null;				// PDF�����Ǘ����i        

        private string _tabKey = TABCONTROL_EXTRAINFOSCREEN_KEY;
        #endregion

        // ===================================================================================== //
        // �������\�b�h
        // ===================================================================================== //
        #region private method
        /// <summary>
        /// �����ݒ�f�[�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note        : �����ݒ�f�[�^�̓Ǎ����s���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int InitalDataRead()
        {
            string message;

            // ��������ݒ�f�[�^�Ǎ�
            int status = this._demandPrintAcs.ReadBillPrtSt(LoginInfoAcquisition.EnterpriseCode, out message);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:
                    TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                        message,
                        status,
                        MessageBoxButtons.OK,
                        MessageBoxDefaultButton.Button1);
                    break;
            }
            return status;
        }

        /// <summary>
        /// ������ʐݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : ������ʐݒ���s���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note : 2020/04/21 ���O</br>
        /// <br>�Ǘ��ԍ�    : 11870080-00 �d�q����2���Ή�</br>
        /// </remarks>
        private void InitialScreenSetting()
        {
            // �c�[���o�[�A�C�R���ݒ�
            this.Main_ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;

            // ���O�C���S���҂ւ̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.LabelTool loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_LOGINLABEL_TITLE];
            if (loginEmployeeLabel != null) loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            // �I���̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_ENDBUTTON_KEY];
            if (closeButton != null) closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;

            switch (_startMode)
            {
                case START_MODE_DEFAULT_LIST: // �����ꗗ�\
                    {
                        // ���o�̃A�C�R���ݒ�
                        Infragistics.Win.UltraWinToolbars.ButtonTool extractButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                        if (extractButton != null)
                        {
                            extractButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;
                            extractButton.SharedProps.Caption = "���o(&E)";
                        }
                        break;
                    }
                case START_MODE_DEFAULT_TOTAL:// ������
                    {
                        // �d�q���듯���̃A�C�R���ݒ�
                        Infragistics.Win.UltraWinToolbars.ButtonTool extractButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                        if (extractButton != null) extractButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
                        break;
                    }
            }

            // �����̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool syncButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SYNCBUTTON_KEY];
            if (syncButton != null) syncButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;

            //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ---->>>>>
            // ���o�����ɖ߂�̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool returnButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_RETURNBUTTON_KEY];
            if (returnButton != null) returnButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.INDICATIONCHANGE;
            //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ----<<<<<

            // �v���r���[�̃A�C�R���ݒ�            
            Infragistics.Win.UltraWinToolbars.ButtonTool previewButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
            if (previewButton != null) previewButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PREVIEW;

            // ����̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool printButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
            if (printButton != null) printButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;

            // ����v���r���[�̃A�C�R���ݒ�(PDF�o�͂Ɠ���)
            Infragistics.Win.UltraWinToolbars.ButtonTool printPreviewButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
            if (printPreviewButton != null) printPreviewButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PREVIEW;

            // ���O�C����
            Infragistics.Win.UltraWinToolbars.LabelTool LoginName = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_LOGINNAMELABEL_KEY];
            if (LoginName != null && LoginInfoAcquisition.Employee != null)
            {
                Employee employee = new Employee();
                employee = LoginInfoAcquisition.Employee;
                LoginName.SharedProps.Caption = employee.Name;
            }

            // �v���r���[�̃A�C�R���ݒ�            
            Infragistics.Win.UltraWinToolbars.ButtonTool pdfSaveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
            if (pdfSaveButton != null) pdfSaveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;

            // �^�u�R���g���[���̐ݒ�
            this.Main_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.Main_UTabControl.InterTabSpacing = 2;
            this.Main_UTabControl.TabOrientation = Infragistics.Win.UltraWinTabs.TabOrientation.TopLeft;
            this.Main_UTabControl.Appearance.FontData.SizeInPoints = 11;
        }

        /// <summary>
        /// �t�H�[���R���g���[���N���X�N���G�C�g����
        /// </summary>
        /// <remarks>
        /// <br>Note        : �t�H�[���R���g���[���N���X���N���G�C�g���A�f�[�^���i�[���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void FormControlInfoCreate()
        {
            this._formControlInfoTable.Clear();
            FormControlInfo info0 = null;
            FormControlInfo info1 = null;
            FormControlInfo info2 = null;

            switch (_startMode)
            {
                case START_MODE_DEFAULT_LIST: // �����ꗗ�\
                    {
                        info0 = new FormControlInfo(NO0_DEMANDMAIN_TAB, CT_PGID, "Broadleaf.Windows.Forms.MAKAU03002UA", DEMANDLISTMAIN_TAB_NAME, IconResourceManagement.ImageList16.Images[(int)Size16_Index.MAIN]);
                        this._formControlInfoTable.Add(NO0_DEMANDMAIN_TAB, info0);
                        break;
                    }
                case START_MODE_DEFAULT_TOTAL:// ������
                    {
                        info0 = new FormControlInfo(NO0_DEMANDMAIN_TAB, CT_PGID, "Broadleaf.Windows.Forms.MAKAU03002UA", DEMANDMAIN_TAB_NAME, IconResourceManagement.ImageList16.Images[(int)Size16_Index.MAIN]);
                        this._formControlInfoTable.Add(NO0_DEMANDMAIN_TAB, info0);
                        break;
                    }
            }

            info1 = new FormControlInfo(NO1_LISTPREVIEW_TAB, CT_PGID, "Broadleaf.Windows.Forms.MAKAU03000UB", LIST_PREVIEW_TAB_NAME, IconResourceManagement.ImageList16.Images[(int)Size16_Index.PREVIEW]);
            this._formControlInfoTable.Add(NO1_LISTPREVIEW_TAB, info1);

            info2 = new FormControlInfo(NO2_TOTALPREVIEW_TAB, CT_PGID, "Broadleaf.Windows.Forms.MAKAU03000UB", TOTAL_PREVIEW_TAB_NAME, IconResourceManagement.ImageList16.Images[(int)Size16_Index.PREVIEW]);   // MOD 2009/03/06 �������n�t���[���C�� "�������i�Ӂj�v���r���["��TOTAL_PREVIEW_NAME
            this._formControlInfoTable.Add(NO2_TOTALPREVIEW_TAB, info2);
        }

        /// <summary>
        /// �^�u�N���G�C�g����
        /// </summary>
        /// <param name="key">tab</param>
        /// <remarks>
        /// <br>Note        : �^�u�t�H�[���𐶐����܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void TabCreate(string key)
        {
            switch (key)
            {
                case NO0_DEMANDMAIN_TAB:
                    if (this._extractionInfoForm == null)
                    {
                        FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
                        if (info == null) return;

                        this._extractionInfoForm = this.CreateTabForm(info);
                        if (_extractionInfoForm == null) return;
                    }
                    else
                    {
                        if (this._extractionInfoForm is IDemandEbooksChildMain)
                        {
                            ((IDemandEbooksChildMain)this._extractionInfoForm).Show((Object)_startMode);
                        }
                        else
                        {
                            this._extractionInfoForm.Show();
                        }
                    }
                    break;
                case NO1_LISTPREVIEW_TAB:
                    if (this._listPreviewForm == null)
                    {
                        FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
                        if (info == null) return;

                        this._listPreviewForm = this.CreateTabForm(info);
                        if (_listPreviewForm == null) return;
                    }
                    else
                    {
                        this._listPreviewForm.Show();
                    }
                    break;
                case NO2_TOTALPREVIEW_TAB:
                    if (this._totalPreviewForm == null)
                    {
                        FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
                        if (info == null) return;

                        // �v���r���[�^�u�𕡐��\���i������1�\���ځj
                        string originalName = info.Name;
                        if (CurrentOutputPDF.ExistsOtherPDFPreview)
                        {
                            info.Name = originalName + "1";
                        }

                        this._totalPreviewForm = this.CreateTabForm(info);
                        if (_totalPreviewForm == null) return;
                    }
                    else
                    {
                        this._totalPreviewForm.Show();
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// ��ڈȍ~��PDF�v���r���[�^�u��ǉ����܂��B
        /// </summary>
        /// <param name="originalKey">1�ڂ̃v���r���[�t�H�[���̃L�[</param>
        /// <param name="index">�C���f�b�N�X�i1�`�j</param>
        /// <remarks>
        /// <br>Note        : ��ڈȍ~��PDF�v���r���[�^�u��ǉ����܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void AddOtherPDFPreviewTab(
            string originalKey,
            int index
        )
        {
            string key = GetOtherPDFPreviewFormKey(originalKey, index);

            if (OtherPDFPreviewFormMap.ContainsKey(key))
            {
                OtherPDFPreviewFormMap[key].Show();
                this.Main_UTabControl.Tabs[key].Visible = true;
            }
            else
            {
                FormControlInfo originalInfo = (FormControlInfo)_formControlInfoTable[originalKey];

                string tabName = originalInfo.Name;
                switch (originalKey)
                {
                    case NO2_TOTALPREVIEW_TAB:  // ������
                        tabName = TOTAL_PREVIEW_TAB_NAME;
                        break;
                }
                tabName += (index + 1).ToString();

                FormControlInfo info = new FormControlInfo(
                    key,
                    originalInfo.AssemblyID,
                    originalInfo.ClassID,
                    tabName,
                    originalInfo.Icon
                );
                OtherPDFPreviewFormMap.Add(key, CreateTabForm(info));
            }

            return;
        }

        /// <summary>
        /// �^�u�A�N�e�B�u����
        /// </summary>
        /// <param name="key">�ΏۃL�[���</param>
        /// <param name="form">�A�N�e�B�u�������t�H�[���̃C���X�^���X</param>
        /// <remarks>
        /// <br>Note       : �����̃L�[�������ɁA�^�u���A�N�e�B�u�����܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void TabActive(string key, ref Form form)
        {
            if (this.Main_UTabControl.Tabs.Exists(key))
            {
                this.Main_UTabControl.Tabs[key].Visible = true;
                this.Main_UTabControl.SelectedTab = this.Main_UTabControl.Tabs[key];

                // �E�B���h�E�X�e�C�g��ԕύX
                this.CreateWindowStateButtonTools();
            }
        }

        /// <summary>
        /// Tab�t�H�[����������
        /// </summary>
        /// <param name="info">�t�H�[�����</param>
        /// <returns>�t�H�[��</returns>
        /// <remarks>
        /// <br>Note        : MDI�q��ʂ𐶐�����</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private Form CreateTabForm(FormControlInfo info)
        {
            Form form = null;

            // �e��t�H�[���̃C���X�^���X��
            switch (info.Key)
            {
                case NO0_DEMANDMAIN_TAB:
                    {
                        form = new Broadleaf.Windows.Forms.MAKAU03002UA();
                        ((MAKAU03002UA)form).SelectedPdfNodeEvent += new SelectedPdfNodeEventHandler(this.SelectedPdfView);
                        ((MAKAU03002UA)form).StatusBarInfoPrinted += new PrintStatusBar(this.PrintStatusBar);
                        ((MAKAU03002UA)form).ChangeTab += new ChangeStatusBar(this.ChangeStatusBar);
                        break;
                    }
                case NO1_LISTPREVIEW_TAB:
                case NO2_TOTALPREVIEW_TAB:
                    form = new Broadleaf.Windows.Forms.MAKAU03000UB();
                    break;
                default:
                    break;
            }

            // ��ڈȍ~��PDF�v���r���[�t�H�[���𐶐�
            if (form == null)
            {
                if (info.Key.Contains(NO2_TOTALPREVIEW_TAB))
                {
                    form = new Broadleaf.Windows.Forms.MAKAU03000UB();
                }
            }

            if (form == null)
            {
                form = new Form();
            }

            if (form != null)
            {
                // �^�u�R���g���[���ɒǉ�����^�u�y�[�W���C���X�^���X������
                Infragistics.Win.UltraWinTabControl.UltraTabPageControl dataviewTabPageControl =
                  new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();

                // �^�u�̊O�ς�ݒ肵�A�^�u�R���g���[���Ƀ^�u��ǉ�����
                Infragistics.Win.UltraWinTabControl.UltraTab dataviewTab = new Infragistics.Win.UltraWinTabControl.UltraTab();

                dataviewTab.TabPage = dataviewTabPageControl;
                dataviewTab.Text = info.Name;
                dataviewTab.Key = info.Key;
                dataviewTab.Tag = info.Form;
                dataviewTab.Appearance.Image = info.Icon;
                dataviewTab.Appearance.BackColor = Color.White;
                dataviewTab.Appearance.BackColor2 = Color.Lavender;
                dataviewTab.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                dataviewTab.ActiveAppearance.BackColor = Color.White;
                dataviewTab.ActiveAppearance.BackColor2 = Color.LightPink;
                dataviewTab.ActiveAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                dataviewTab.ActiveAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;

                this.Main_UTabControl.Controls.Add(dataviewTabPageControl);
                this.Main_UTabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] { dataviewTab });
                this.Main_UTabControl.SelectedTab = dataviewTab;

                // �t�H�[���v���p�e�B�ύX
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                dataviewTabPageControl.Controls.Add(form);

                if (form is IDemandEbooksChildMain)
                {
                    ((IDemandEbooksChildMain)form).Show((Object)_startMode);
                }
                else
                {
                    form.Show();
                }

                form.Dock = System.Windows.Forms.DockStyle.Fill;
            }

            info.Form = form;
            return form;
        }
        /// <summary>
        /// �o�c�e����\������
        /// </summary>
        /// <param name="key"></param>
        /// <param name="printName"></param>
        /// <param name="pdfpath"></param>
        /// <remarks>
        /// <br>Note        : �o�c�e������\�����܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void SelectedPdfView(string key, string printName, string pdfpath)
        {
            try
            {
                // �v���r���[�^�u����
                this.TabCreate(NO1_LISTPREVIEW_TAB);
                if (this._listPreviewForm != null)
                {
                    this.TabActive(NO1_LISTPREVIEW_TAB, ref this._listPreviewForm);

                    MAKAU03000UB target = this._listPreviewForm as MAKAU03000UB;

                    if (target != null)
                    {
                        target.IsSave = false;
                        target.PrintKey = string.Empty;
                        target.PrintName = string.Empty;
                        target.PrintDetailName = string.Empty;
                        target.PrintPDFPath = string.Empty;
                        target.Navigate((Object)pdfpath);
                    }

                    // �c�[���o�[�{�^���ݒ�
                    this.ToolBarSetting(target);
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// �c�[���o�[���ڏ�Ԑݒ�
        /// </summary>
        /// <param name="key">�c�[���o�[����</param>
        /// <remarks>
        /// <br>Note        : �c�[���o�[���ڏ�Ԑݒ�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note : 2020/04/21 ���O</br>
        /// <br>�Ǘ��ԍ�    : 11870080-00 �d�q����2���Ή�</br> 
        /// </remarks>
        private void ToolbarConditionSetting(string key)
        {
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool;

            switch (key)
            {
                case NO0_DEMANDMAIN_TAB:
                    {
                        // ���o
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = true;

                        // ����
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SYNCBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;

                        //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ---->>>>>
                        // ���o�����ɖ߂�
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_RETURNBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;
                        //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ----<<<<<

                        // ���
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = true;

                        // ����v���r���[
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = (_startMode != START_MODE_DEFAULT_LIST);

                        // PDF�\��
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = true;

                        // PDF����ۑ�
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = true;

                        break;
                    }
                default:
                    {
                        // ���o
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;
                        // ����
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SYNCBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;
                        //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ---->>>>>
                        // ���o�����ɖ߂�
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_RETURNBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;
                        //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ----<<<<<
                        // ���
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;
                        // ����v���r���[
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;
                        // PDF�\��
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;
                        // PDF����ۑ�
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;
                        break;
                    }
            }
        }

        #region ���@�o�c�e����ۑ�
        /// <summary>
        /// �o�c�e����ۑ�����
        /// </summary>
        /// <param name="key">�Ώے��[KEY</param>
        /// <remarks>
        /// <br>Note       : �Ώے��[KEY�̂o�c�e�t�@�C���𗚗�ۑ����܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void SavePDF(string key)
        {
            try
            {
                FormControlInfo info = null;
                MAKAU03000UB target = null;
                if (this._formControlInfoTable.Contains(key))
                {
                    // �A�N�e�B�u�^�u���璠�[�R���g���[�������擾
                    info = this._formControlInfoTable[key] as FormControlInfo;

                    // PDF�v���r���[�t�H�[��
                    if (info != null) target = info.Form as MAKAU03000UB;
                }
                else
                {
                    // ����PDF�v���r���[�p����
                    if (OtherPDFPreviewFormMap.ContainsKey(key))
                    {
                        target = OtherPDFPreviewFormMap[key] as MAKAU03000UB;
                    }
                }

                if (target == null) return;

                // ����ۑ��͉\���H
                if (target.IsSave)
                {
                    if (this._pdfHistoryCtrl != null)
                    {
                        // �d���`�F�b�N
                        if (this._pdfHistoryCtrl.Contains(target.PrintKey, target.PrintPDFPath))
                        {
                            TMessageBox(emErrorLevel.ERR_LEVEL_INFO, MSG_PDFALREADYSAVE, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            return;
                        }

                        # region [�폜���X�g���珜�O����]
                        // �S�Ẵ^�u�ɂ���
                        foreach (Infragistics.Win.UltraWinTabControl.UltraTab tab in this.Main_UTabControl.Tabs)
                        {
                            FormControlInfo wkInfo = null;
                            MAKAU03000UB wkTarget = null;
                            if (this._formControlInfoTable.Contains(tab.Key))
                            {
                                wkInfo = this._formControlInfoTable[tab.Key] as FormControlInfo;
                                if (wkInfo != null) wkTarget = wkInfo.Form as MAKAU03000UB;
                            }
                            else
                            {
                                if (OtherPDFPreviewFormMap.ContainsKey(tab.Key))
                                {
                                    wkTarget = OtherPDFPreviewFormMap[tab.Key] as MAKAU03000UB;
                                }
                            }
                            if (wkTarget == null) continue;

                            // �v���r���[�\���^�u�Ȃ��PDF�폜���X�g���珜�O����
                            if (wkTarget.IsSave)
                            {
                                // �o�͗����Ǘ��ɒǉ�
                                this._pdfHistoryCtrl.AddPrintHistoryList(wkTarget.PrintKey, wkTarget.PrintName, wkTarget.PrintDetailName,
                                    wkTarget.PrintPDFPath);

                                // �폜���X�g���珜�O����
                                if (this._delPDFList.Contains(wkTarget.PrintPDFPath))
                                {
                                    this._delPDFList.Remove(wkTarget.PrintPDFPath);
                                }
                            }
                        }
                        # endregion
                    }

                    TMessageBox(emErrorLevel.ERR_LEVEL_INFO, MSG_SAVESUCCESS, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, MSG_SAVEFAILE + ex.Message,
                    0,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
        }
        #endregion


        #region ���@�c�[���o�[�̕\���E�L���ݒ�
        /// <summary>
        /// �c�[���o�[�̕\���E�L���ݒ�
        /// </summary>
        /// <param name="activeForm">�A�N�e�B�u�ȃt�H�[���̃I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�̕\���E��\���A�L���E�����ݒ���s���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note : 2020/04/21 ���O</br>
        /// <br>�Ǘ��ԍ�    : 11870080-00 �d�q����2���Ή�</br>
        /// </remarks>
        private void ToolBarSetting(object activeForm)
        {
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool;

            if (activeForm != null)
            {
                if (activeForm is IDemandEbooksChildMain)
                {
                    switch (_startMode)
                    {
                        case START_MODE_DEFAULT_LIST: // �����ꗗ�\
                            {
                                // ���o
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Enabled = true;
                                }
                                // ���
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Enabled = true;
                                }
                                // PDF�\��
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Enabled = true;
                                }

                                // PDF����ۑ�
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Enabled = false;
                                }
                                break;
                            }
                        case START_MODE_DEFAULT_TOTAL:// ������
                            {
                                if (_tabKey.Equals(TABCONTROL_EXTRAINFOSCREEN_KEY))
                                {
                                    // ���o
                                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                                    if (buttonTool != null)
                                    {
                                        buttonTool.SharedProps.Enabled = true;
                                    }

                                    // ����
                                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SYNCBUTTON_KEY];
                                    if (buttonTool != null)
                                    {
                                        buttonTool.SharedProps.Enabled = false;
                                    }
                                    //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ---->>>>>
                                    // ���o�����ɖ߂�
                                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_RETURNBUTTON_KEY];
                                    if (buttonTool != null)
                                    {
                                        buttonTool.SharedProps.Enabled = false;
                                    }
                                    //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ----<<<<<
                                    // ���
                                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                                    if (buttonTool != null)
                                    {
                                        buttonTool.SharedProps.Enabled = true;
                                    }
                                    // ����v���r���[
                                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
                                    if (buttonTool != null)
                                    {
                                        buttonTool.SharedProps.Enabled = true;
                                    }

                                    // PDF�\��
                                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                                    if (buttonTool != null)
                                    {
                                        buttonTool.SharedProps.Enabled = true;
                                    }

                                    // PDF����ۑ�
                                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
                                    if (buttonTool != null)
                                    {
                                        buttonTool.SharedProps.Enabled = false;
                                    }
                                }
                                else
                                {

                                    // ���o
                                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                                    if (buttonTool != null)
                                    {
                                        buttonTool.SharedProps.Enabled = false;
                                    }

                                    // ����
                                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SYNCBUTTON_KEY];
                                    if (buttonTool != null)
                                    {
                                        buttonTool.SharedProps.Enabled = true;
                                    }
                                    //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ---->>>>>
                                    // ���o�����ɖ߂�
                                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_RETURNBUTTON_KEY];
                                    if (buttonTool != null)
                                    {
                                        buttonTool.SharedProps.Enabled = false;
                                    }
                                    //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ----<<<<<
                                    // ���
                                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                                    if (buttonTool != null)
                                    {
                                        buttonTool.SharedProps.Enabled = false;
                                    }
                                    // ����v���r���[
                                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
                                    if (buttonTool != null)
                                    {
                                        buttonTool.SharedProps.Enabled = false;
                                    }

                                    // PDF�\��
                                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                                    if (buttonTool != null)
                                    {
                                        buttonTool.SharedProps.Enabled = false;
                                    }

                                    // PDF����ۑ�
                                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
                                    if (buttonTool != null)
                                    {
                                        buttonTool.SharedProps.Enabled = false;
                                    }
                                }
                                break;
                            }
                    }
                }
                else if (activeForm is MAKAU03000UB)
                {
                    switch (_startMode)
                    {
                        case START_MODE_DEFAULT_LIST: // �����ꗗ�\
                            {
                                // ���o
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Enabled = false;
                                }
                                // ���
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Enabled = false;
                                }
                                // PDF�\��
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Enabled = false;
                                }

                                // PDF����ۑ�
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Enabled = true;
                                }
                                break;
                            }
                        case START_MODE_DEFAULT_TOTAL:// ������
                            {
                                // ���o
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Enabled = false;
                                }

                                // ����
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SYNCBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Enabled = false;
                                }
                                //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ---->>>>>
                                // ���o�����ɖ߂�
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_RETURNBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Enabled = false;
                                }
                                //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ----<<<<<
                                // ���
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Enabled = false;
                                }
                                // ����v���r���[
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Enabled = false;
                                }

                                // PDF�\��
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Enabled = false;
                                }

                                // PDF����ۑ�
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    MAKAU03000UB target = activeForm as MAKAU03000UB;
                                    if (target != null)
                                    {
                                        buttonTool.SharedProps.Enabled = target.IsSave;
                                    }
                                }
                                break;
                            }
                    }
                }
            }
            else
            {
                // ���o
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }

                // ����
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SYNCBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }
                //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ---->>>>>
                // ���o�����ɖ߂�
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_RETURNBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }
                //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ----<<<<<
                // ���
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }

                // ����v���r���[
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }

                // PDF�\��
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }

                // PDF����ۑ�
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }
            }
        }
        #endregion

        /// <summary>
        /// ���b�Z�[�W�\��
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="iMsg">�G���[���b�Z�[�W</param>
        /// <param name="iSt">�X�e�[�^�X</param>
        /// <param name="iButton">�\���{�^��</param>
        /// <param name="iDefButton">�f�t�H���g�t�H�[�J�X�{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note        : �o�͌����̐ݒ���s���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            Form form = new Form();
            form.TopMost = true;
            DialogResult result = TMsgDisp.Show(form, iLevel, CT_PGID, iMsg, iSt, iButton, iDefButton);
            form.TopMost = false;
            return result;
        }
        #endregion

        // ===================================================================================== //
        // �R���g���[���C�x���g
        // ===================================================================================== //
        #region control event
        /// <summary>
        /// ���C���t���[����LOAD�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : �C�x���g�̉�����L�q���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void MAKAU03000UA_Load(object sender, System.EventArgs e)
        {
            try
            {
                // ������ʐݒ�
                this.InitialScreenSetting();

                // �^�C�g���ݒ�
                this.Text = MAIN_FORM_TITLE;

                switch (_startMode)
                {
                    case START_MODE_DEFAULT_LIST:			// �����ꗗ�\
                        this.Text = MAIN_FORM_TITLE + DEMANDLISTMAIN_TITLE;
                        break;
                    case START_MODE_DEFAULT_TOTAL:			// ������
                        this.Text = MAIN_FORM_TITLE + DEMANDMAIN_TITLE;
                        break;
                }
                this.ToolbarConditionSetting(NO0_DEMANDMAIN_TAB);

                // �E�C���h�E�{�^���쐬����
                this.CreateWindowStateButtonTools();

                this.Initial_Timer.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ���������^�C�}�[�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : �����^�C�}�[�C�x���g�ł��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            // �C�x���g�t���OOFF
            this._eventDoFlag = false;
            try
            {
                // �t�H�[���N���X�쐬
                this.FormControlInfoCreate();

                // �����ݒ�f�[�^�Ǎ�
                int status = this.InitalDataRead();
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.Close();
                    return;
                }

                this.TabCreate(NO0_DEMANDMAIN_TAB);

                // �^�u���A�N�e�B�u�ɁI    
                // �A�N�e�B�u��Ԃ̃^�u����t�H�[�����擾����
                FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_UTabControl.ActiveTab.Key.ToString()];
                System.Windows.Forms.Form form = formControlInfo.Form;


                this.TabActive(NO0_DEMANDMAIN_TAB, ref form);

                // �c�[���o�[�����ݒ�
                this.ToolBarSetting(form);

                // ���쌠������
                FormControlInfo info = formControlInfo;
                if (!MyOpeCtrlMap.ContainsKey(info.AssemblyID))
                {
                    if (!OpeAuthCtrlFacade.CanRunWithInitializing(
                        EntityUtil.CategoryCode.Report,
                        MyOpeCtrlMap.AddController(info.AssemblyID),
                        info.AssemblyID,
                        info.Name
                    ))
                    {
                        this.Close();   // �N���s�̂��ߋ����I��
                    }
                }

                BeginControllingByOperationAuthority(info.AssemblyID);
            }
            finally
            {
                // �C�x���g�t���OON
                this._eventDoFlag = true;
            }
        }

        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : �c�[���o�[�N���b�N���ɔ������܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note  : 2020/04/21 ���O</br>
        /// <br>�Ǘ��ԍ�     : 11870080-00 �d�q����2���Ή�</br>
        /// </remarks>
        private void Main_ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            try
            {
                switch (e.Tool.Key)
                {
                    case TOOLBAR_ENDBUTTON_KEY:
                        {
                            this.Close();
                            break;
                        }

                    // ���o
                    case TOOLBAR_EXTRACTBUTTON_KEY:
                        {
                            // �A�N�e�B�u��Ԃ̃^�u����t�H�[�����擾����
                            FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_UTabControl.ActiveTab.Key.ToString()];
                            System.Windows.Forms.Form activeForm = formControlInfo.Form;

                            if (activeForm is IDemandEbooksChildMain)
                            {
                                // ��ʓ��̓`�F�b�N
                                this.Main_ToolbarsManager.Enabled = false;
                                try
                                {
                                    ((IDemandEbooksChildMain)activeForm).ExtractData();
                                }
                                finally
                                {
                                    this.Main_ToolbarsManager.Enabled = true;
                                }

                            }
                            break;
                        }
                    // ����
                    case TOOLBAR_SYNCBUTTON_KEY:
                        {
                            // �A�N�e�B�u��Ԃ̃^�u����t�H�[�����擾����
                            FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_UTabControl.ActiveTab.Key.ToString()];
                            System.Windows.Forms.Form activeForm = formControlInfo.Form;

                            if (activeForm is IDemandEbooksChildMain)
                            {
                                SFCMN06002C printInfo = new SFCMN06002C();
                                printInfo.pdfopen = false;
                                printInfo.pdftemppath = string.Empty;
                                printInfo.pdfopen = true;
                                printInfo.prevkbn = 0; // 0:�v���r���[�Ȃ�
                                printInfo.printmode = (int)emPrintMode.emPDF;

                                // PDF�o��
                                IDemandEbooksChildMain interFase = activeForm as IDemandEbooksChildMain;
                                Object parameter = (Object)printInfo;
                                int status = interFase.Print(ref parameter, true);

                                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                {
                                    break;
                                }

                                // ��������
                                status = interFase.SyncMain();

                                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                {
                                    break;
                                }

                                // �d��.DX��ʂ��N������
                                DialogResult dialogResult = MessageBox.Show(
                                    MSG_DXSTART,
                                    this.Text,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question
                                );
                                if (dialogResult.Equals(DialogResult.Yes))
                                {
                                    try
                                    {
                                        //�d��.DX��ʋN��
                                        string vbsFile = System.Environment.CurrentDirectory + DXSTARTFILENAME;
                                        System.Diagnostics.Process p = System.Diagnostics.Process.Start(vbsFile);
                                        p.WaitForExit();
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                            break;
                        }
                    //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ---->>>>>
                    // ���o�����ɖ߂�
                    case TOOLBAR_RETURNBUTTON_KEY:
                        {
                            // �A�N�e�B�u��Ԃ̃^�u����t�H�[�����擾����
                            FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_UTabControl.ActiveTab.Key.ToString()];
                            System.Windows.Forms.Form activeForm = formControlInfo.Form;

                            if (activeForm is IDemandEbooksChildMain)
                            {
                                // ��ʓ��̓`�F�b�N
                                this.Main_ToolbarsManager.Enabled = false;
                                try
                                {
                                    ((IDemandEbooksChildMain)activeForm).ReturnToExtraCondition();
                                }
                                finally
                                {
                                    this.Main_ToolbarsManager.Enabled = true;
                                }

                            }
                            break;
                        }
                    //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ----<<<<<
                    case TOOLBAR_PREVIEWBUTTON_KEY: // �v���r���[
                    case TOOLBAR_PRINTBUTTON_KEY: // ���
                    case TOOLBAR_PRINTPREVIEWBUTTON_KEY: // ����v���r���[
                        {
                            // �A�N�e�B�u��Ԃ̃^�u����t�H�[�����擾����
                            FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_UTabControl.ActiveTab.Key.ToString()];
                            System.Windows.Forms.Form activeForm = formControlInfo.Form;

                            if ((activeForm is IDemandEbooksChildMain))
                            {
                                SFCMN06002C printInfo = new SFCMN06002C();
                                printInfo.pdfopen = false;
                                printInfo.pdftemppath = string.Empty;

                                // �����ꗗ�\�ȊO�̓_�C�A���O���䂪�����̂ŁA��Ɂu0:�v���r���[�Ȃ��v
                                if (!_startMode.Equals(START_MODE_DEFAULT_LIST))
                                {
                                    printInfo.pdfopen = true;
                                    if (e.Tool.Key != TOOLBAR_PRINTPREVIEWBUTTON_KEY)
                                    {
                                        printInfo.prevkbn = 0; // 0:�v���r���[�Ȃ�
                                    }
                                    else
                                    {
                                        printInfo.prevkbn = 1; // 1:�v���r���[����
                                    }
                                }

                                // ������[�h�̐ݒ�
                                int printMode = 0;
                                switch (e.Tool.Key)
                                {
                                    case TOOLBAR_PRINTBUTTON_KEY:
                                    case TOOLBAR_PRINTPREVIEWBUTTON_KEY:

                                        // �ʏ���
                                        printMode = (int)emPrintMode.emPrinter;
                                        break;
                                    case TOOLBAR_PREVIEWBUTTON_KEY:
                                        // �o�c�e�o��
                                        printMode = (int)emPrintMode.emPDF;
                                        break;
                                    default:
                                        break;
                                }
                                printInfo.printmode = printMode;

                                IDemandEbooksChildMain interFase = activeForm as IDemandEbooksChildMain;

                                // TODO ����O�`�F�b�N���s��

                                Object parameter = (Object)printInfo;
                                int status = interFase.Print(ref parameter, false);

                                switch (status)
                                {
                                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                                        {
                                            // �o�c�e�o�͏ꍇ�̂�
                                            if (printMode == (int)emPrintMode.emPDF)
                                            {
                                                // �o�c�e�폜���X�g�ɒǉ�
                                                if (printInfo.pdftemppath != string.Empty)
                                                {
                                                    if (!this._delPDFList.Contains(printInfo.pdftemppath))
                                                    {
                                                        this._delPDFList.Add(printInfo.pdftemppath, printInfo.pdftemppath);
                                                    }
                                                }
                                                else
                                                {
                                                    CurrentOutputPDF = null;
                                                    return; // PDF����������Ă��Ȃ��ꍇ�A�����I��
                                                }

                                                // ���݂̏o��PDF�����X�V
                                                if (activeForm is MAKAU03002UA)
                                                {
                                                    CurrentOutputPDF = ((MAKAU03002UA)activeForm).OutputPDF;
                                                    if (CurrentOutputPDF.ExistsOtherPDFPreview)
                                                    {
                                                        for (int i = 1; i < CurrentOutputPDF.PreviewPDFPathList.Count; i++)
                                                        {
                                                            this._delPDFList.Add(
                                                                CurrentOutputPDF.PreviewPDFPathList[i],
                                                                CurrentOutputPDF.PreviewPDFPathList[i]
                                                            );
                                                        }
                                                    }
                                                }

                                                if (printInfo.pdfopen)
                                                {
                                                    Form frm = null;
                                                    MAKAU03000UB target = null;


                                                    string key = string.Empty;

                                                    // �������׏�
                                                    // �v���r���[�^�u����
                                                    this.TabCreate(NO2_TOTALPREVIEW_TAB);
                                                    if (this._totalPreviewForm != null)
                                                    {
                                                        frm = this._totalPreviewForm;
                                                        target = frm as MAKAU03000UB;
                                                        key = NO2_TOTALPREVIEW_TAB;
                                                    }
                                                    if (CurrentOutputPDF.ExistsOtherPDFPreview)
                                                    {
                                                        for (int i = 1; i < CurrentOutputPDF.PreviewPDFPathList.Count; i++)
                                                        {
                                                            AddOtherPDFPreviewTab(NO2_TOTALPREVIEW_TAB, i);
                                                        }
                                                    }

                                                    if (target != null)
                                                    {
                                                        target.IsSave = true;
                                                        target.PrintKey = printInfo.key;
                                                        target.PrintName = printInfo.prpnm;
                                                        target.PrintDetailName = printInfo.prpnm;
                                                        target.PrintPDFPath = printInfo.pdftemppath;
                                                        target.Navigate(printInfo.pdftemppath);
                                                        if (CurrentOutputPDF.ExistsOtherPDFPreview)
                                                        {
                                                            // ��ڈȍ~��PDF��\��
                                                            string originalKey = key;

                                                            for (int i = 1; i < CurrentOutputPDF.PreviewPDFPathList.Count; i++)
                                                            {
                                                                string otherKey = GetOtherPDFPreviewFormKey(originalKey, i);
                                                                MAKAU03000UB otherTarget = OtherPDFPreviewFormMap[otherKey] as MAKAU03000UB;
                                                                if (otherTarget == null) continue;

                                                                otherTarget.IsSave = true;
                                                                otherTarget.PrintKey = printInfo.key;
                                                                otherTarget.PrintName = printInfo.prpnm;
                                                                otherTarget.PrintDetailName = printInfo.prpnm;

                                                                otherTarget.PrintPDFPath = CurrentOutputPDF.PreviewPDFPathList[i];
                                                                otherTarget.Navigate(CurrentOutputPDF.PreviewPDFPathList[i]);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            // ��ڈȍ~�̃v���r���[�^�u���B��
                                                            for (int i = 0; i < this.Main_UTabControl.Tabs.Count; i++)
                                                            {
                                                                if (this.Main_UTabControl.Tabs[i].Key.Contains(key))
                                                                {
                                                                    if (this.Main_UTabControl.Tabs[i].Key.Equals(key)) continue;
                                                                    TabVisibleChange(this.Main_UTabControl.Tabs[i].Key, false);
                                                                }
                                                            }
                                                        }

                                                        this.TabActive(key, ref frm);
                                                    }

                                                    // �c�[���o�[�{�^���ݒ�
                                                    this.ToolBarSetting(frm);
                                                }
                                            }
                                            break;
                                        }
                                    case (int)ConstantManagement.MethodResult.ctFNC_CANCEL:
                                        {
                                            break;
                                        }
                                    default:
                                        {
                                            break;
                                        }
                                }
                            }
                            break;
                        }

                    case TOOLBAR_PDFSAVEBUTTON_KEY:
                        {
                            this.SavePDF(this.Main_UTabControl.ActiveTab.Key.ToString());
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// �^�u�I���㏈��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �^�u�I����ɔ�������C�x���g�ł��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void Main_UTabControl_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            try
            {
                // ������
                if (!this._eventDoFlag) return;
                if (e.Tab == null) return;

                string key = e.Tab.Key;

                if (this._formControlInfoTable.Contains(key))
                {
                    FormControlInfo info = this._formControlInfoTable[key] as FormControlInfo;
                    Form target = info.Form;
                    this.TabActive(key, ref target);
                    this.ToolBarSetting(target);
                }
                else
                {
                    if (OtherPDFPreviewFormMap.ContainsKey(key))
                    {
                        Form target = OtherPDFPreviewFormMap[key];
                        this.TabActive(key, ref target);
                        this.ToolBarSetting(target);
                    }
                }
            }
            catch(Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        ///	�t�H�[��������ꂽ��ɔ�������C�x���g�ł��B
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : �t�H�[��������ꂽ��ɁA�������܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void MAKAU03000UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this._eventDoFlag = false;

                // �e���[�̃u���E�U�ɋ�A�h���X��\�������܂��B�\�����Ă���PDF�t�@�C�������ׂł��B
                foreach (DictionaryEntry entry in this._formControlInfoTable)
                {
                    FormControlInfo info = entry.Value as FormControlInfo;
                    if (info != null)
                    {
                        MAKAU03000UB viewFrm = info.Form as MAKAU03000UB;
                        if (viewFrm != null)
                        {
                            viewFrm.Navigate(BLANK);
                            viewFrm.Close();
                            viewFrm.Dispose();
                        }
                    }
                }

                // ��ڈȍ~��PDF�u���E�U�ɋ�A�h���X��ݒ�i��\�����Ă���PDF�t�@�C�������ׁj
                foreach (Form otherForm in OtherPDFPreviewFormMap.Values)
                {
                    MAKAU03000UB otherPreviewForm = otherForm as MAKAU03000UB;
                    if (otherPreviewForm == null) continue;

                    otherPreviewForm.Navigate(BLANK);
                    otherPreviewForm.Close();
                    otherPreviewForm.Dispose();
                }

                foreach (Infragistics.Win.UltraWinTabControl.UltraTab tab in this.Main_UTabControl.Tabs)
                {
                    this.Main_UTabControl.Tabs.Remove(tab);
                }

                // �v���r���[�Ő��������o�c�e�t�@�C�����폜���܂��B
                int tryCnt;
                foreach (DictionaryEntry wkEntry in this._delPDFList)
                {
                    if (System.IO.File.Exists(wkEntry.Value.ToString()))
                    {
                        tryCnt = 0;
                        while (tryCnt < 3)
                        {
                            try
                            {
                                System.IO.File.Delete(wkEntry.Value.ToString());
                                // �֘APDF���폜
                                CurrentOutputPDF.DeleteFiles(wkEntry.Value.ToString());
                                break;
                            }
                            catch (System.IO.IOException ex)
                            {
                                System.Threading.Thread.Sleep(1000);
                                Debug.Assert(false, ex.ToString());
                            }
                            catch (Exception ex)
                            {
                                Debug.Assert(false, ex.ToString());
                                break;
                            }

                            tryCnt++;
                        }
                    }
                }
            }
            finally
            {
                this._eventDoFlag = true;
            }
        }
        #endregion

        /// <summary>
        /// �|�b�v���j���[�u����v�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note        : �u����v�{�^���������ɔ������܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void Close_menuItem_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (this.Main_UTabControl.ActiveTab == null) return;

                string key = this.Main_UTabControl.ActiveTab.Key;

                // �^�u�\���ύX
                this.TabVisibleChange(key, false);

                // �E�B���h�E�X�e�[�g�{�^���c�[���\�z����
                this.CreateWindowStateButtonTools();

                if (this.Main_UTabControl.Tabs.Count == 0)
                {
                    this.ToolBarSetting(null);
                }
                else
                {
                    this.ToolBarSetting(this.Main_UTabControl.ActiveTab);
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        #region ���@�E�B���h�E�X�e�[�g�{�^���c�[���\�z����
        /// <summary>
        /// �E�B���h�E�X�e�[�g�{�^���c�[���\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �E�C���h�E�\�ʒu��ԃ{�^�����쐬���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void CreateWindowStateButtonTools()
        {
            if (this.Main_UTabControl.SelectedTab != null)
            {
                if (this.Main_UTabControl.SelectedTab.Key == NO0_DEMANDMAIN_TAB)
                {
                    // ��������
                    this.Main_UTabControl.ContextMenu = null;
                }
                else
                {
                    // �v���r�����
                    this.Main_UTabControl.ContextMenu = this.TabControl_contextMenu;
                }
            }
        }
        #endregion

        #region ���@�^�u�\���E��\������
        /// <summary>
        /// �^�u�\���^��\��������
        /// </summary>
        /// <param name="key">�L�[</param>
        /// <param name="hidden">true:�\�� false:��\��</param>
        /// <remarks>
        /// <br>Note       : �^�u�̕\���^��\���𐧌䂵�܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void TabVisibleChange(string key, bool visible)
        {
            for (int i = 0; i < this.Main_UTabControl.Tabs.Count; i++)
            {
                Infragistics.Win.UltraWinTabControl.UltraTab tab = this.Main_UTabControl.Tabs[i];

                if (tab.Key == key)
                {
                    tab.Visible = visible;

                    if (!visible) ClosePDF(key, false);
                }
            }
        }
        #endregion

        /// <summary>
        /// �\�����Ă���PDF�t�@�C������܂��B
        /// </summary>
        /// <param name="tabKey">PDF��\�����Ă���^�u�̃L�[</param>
        /// <param name="withDisposingPreviewForm">�\�����Ă���v���r���[�p�t�H�[������������t���O</param>
        /// <remarks>
        /// <br>Note        : �\�����Ă���PDF�t�@�C������܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void ClosePDF(
            string tabKey,
            bool withDisposingPreviewForm
        )
        {
            const string EMPTY_URL = BLANK;

            // �e���[�̃u���E�U�ɋ�A�h���X��\�������܂��B�\�����Ă���PDF�t�@�C�������ׂł��B
            if (_formControlInfoTable.ContainsKey(tabKey))
            {
                FormControlInfo info = _formControlInfoTable[tabKey] as FormControlInfo;
                if (info != null)
                {
                    MAKAU03000UB viewFrm = info.Form as MAKAU03000UB;
                    if (viewFrm != null)
                    {
                        viewFrm.Navigate(EMPTY_URL);
                        if (withDisposingPreviewForm)
                        {
                            viewFrm.Close();
                            viewFrm.Dispose();
                        }
                    }
                }
            }

            // ��ڈȍ~��PDF�u���E�U�ɋ�A�h���X��ݒ�i��\�����Ă���PDF�t�@�C�������ׁj
            if (OtherPDFPreviewFormMap.ContainsKey(tabKey))
            {
                MAKAU03000UB otherPreviewForm = OtherPDFPreviewFormMap[tabKey] as MAKAU03000UB;
                if (otherPreviewForm != null)
                {
                    otherPreviewForm.Navigate(EMPTY_URL);
                    if (withDisposingPreviewForm)
                    {
                        otherPreviewForm.Close();
                        otherPreviewForm.Dispose();
                    }
                }
            }

        }

        #region ���X�e�[�^�X�o�[�֏o��

        /// <summary>
        /// �X�e�[�^�X�o�[�ɏ���\�����܂��B
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : �X�e�[�^�X�o�[�ɏ���\�����܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void PrintStatusBar(
            object sender,
            PrintStatusBarEventArgs e
        )
        {
            try
            {
                this.Main_StatusBar.Panels[TEXT].Text = e.Message;
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// �X�e�[�^�X�o�[�ɏ���\�����܂��B
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : �X�e�[�^�X�o�[�ɏ���\�����܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note : 2020/04/21 ���O</br>
        /// <br>�Ǘ��ԍ�    : 11870080-00 �d�q����2���Ή�</br> 
        /// </remarks>
        private void ChangeStatusBar(
            object sender,
            Infragistics.Win.UltraWinTabControl.ActiveTabChangedEventArgs e
        )
        {
            try
            {
                Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool;

                if (_startMode == START_MODE_DEFAULT_TOTAL)
                {
                    switch (e.Tab.Key)
                    {
                        case TABCONTROL_EXTRAINFOSCREEN_KEY:
                            {
                                _tabKey = TABCONTROL_EXTRAINFOSCREEN_KEY;

                                // ���o
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Visible = true;
                                    buttonTool.SharedProps.Enabled = true;
                                }

                                // ����
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SYNCBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Visible = false;
                                    buttonTool.SharedProps.Enabled = false;
                                }
                                //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ---->>>>>
                                // ���o�����ɖ߂�
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_RETURNBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Visible = false;
                                    buttonTool.SharedProps.Enabled = false;
                                }
                                //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ----<<<<<
                                // ���
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                                if (buttonTool != null) buttonTool.SharedProps.Enabled = true;

                                // ����v���r���[
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
                                if (buttonTool != null) buttonTool.SharedProps.Enabled = true;

                                // PDF�\��
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                                if (buttonTool != null) buttonTool.SharedProps.Enabled = true;

                                break;
                            }
                        case TABCONTROL_EXTRADATASCREEN_KEY:
                            {
                                _tabKey = TABCONTROL_EXTRADATASCREEN_KEY;

                                // ���o
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Visible = false;
                                    buttonTool.SharedProps.Enabled = false;
                                }

                                // ����
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SYNCBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Visible = true;
                                    buttonTool.SharedProps.Enabled = true;
                                }
                                //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ---->>>>>
                                // ���o�����ɖ߂�
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_RETURNBUTTON_KEY];
                                if (buttonTool != null)
                                {
                                    buttonTool.SharedProps.Visible = true;
                                    buttonTool.SharedProps.Enabled = true;
                                }
                                //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ----<<<<<
                                // ���
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                                if (buttonTool != null) buttonTool.SharedProps.Enabled = false;

                                // ����v���r���[
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
                                if (buttonTool != null) buttonTool.SharedProps.Enabled = false;

                                // PDF�\��
                                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                                if (buttonTool != null) buttonTool.SharedProps.Enabled = false;

                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        #endregion  // ���X�e�[�^�X�o�[�֏o��
    }
}

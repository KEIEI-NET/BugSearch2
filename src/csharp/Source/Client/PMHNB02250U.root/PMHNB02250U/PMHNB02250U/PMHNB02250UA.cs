//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : ���������s(����)
// �v���O�����T�v   : ���������s(����)�̈󎚂��s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/04/21  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30531 ��� �r��
// �� �� ��  2010/02/01  �C�����e : �������^�C�v���Ɉ��������s���悤�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018 ��� ���b
// �� �� ��  2010/06/23  �C�����e : ����������y�[�W�w��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018 ��� ���b
// �� �� ��  2010/07/28  �C�����e : �A�E�g�I�u�������G���[�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018 ��� ���b
// �� �� ��  2010/11/02  �C�����e : Adobe Reader9�ȍ~���ƏI�����G���[�������錏�̑Ή��B(WebBrowser��������̏C��)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : gezh
// �� �� ��  2011/12/16  �C�����e : redmine#26635�̑Ή��B
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Data;
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
    /// ���������s(����)�t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���������s(����)�̃t���[���N���X�ł��B</br>
    /// <br></br>
    /// <br>Update Note: 2010/11/02  22018 ��� ���b</br>
    /// <br>           : Adobe Reader9�ȍ~���ƏI�����G���[�������錏�̑Ή��B(WebBrowser��������̏C��)</br>
    /// </remarks>
    public class PMHNB02250UA : System.Windows.Forms.Form
    {
        # region Private Members (Component)
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager Main_ToolbarsManager;
        private System.Windows.Forms.Timer Initial_Timer;
        private Infragistics.Win.UltraWinDock.UltraDockManager Main_DockManager;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar Main_StatusBar;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU02010UA_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU02010UA_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU02010UA_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU02010UA_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _MAKAU02010UAUnpinnedTabAreaLeft;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _MAKAU02010UAUnpinnedTabAreaRight;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _MAKAU02010UAUnpinnedTabAreaTop;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _MAKAU02010UAUnpinnedTabAreaBottom;
        private Infragistics.Win.UltraWinDock.AutoHideControl _MAKAU02010UAAutoHideControl;
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
        public PMHNB02250UA()
        {
            InitializeComponent();

            // �������f�[�^�A�N�Z�X�N���X�C���X�^���X��
            this._demandPrintAcs = new SumDemandPrintAcs();

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
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar( "MainMenu_UltraToolbar" );
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool( "File_PopupMenuTool" );
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool( "Tool_PopupMenuTool" );
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool( "Window_PopupMenuTool" );
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool( "Dummy_LabelTool" );
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool( "LoginTitle_LabelTool" );
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool( "LoginName_LabelTool" );
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar( "Button_UltraToolbar" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "End_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Extract_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Print_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "PrintPreview_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Preview_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "PDFSave_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "UserSetUp_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "TextOutPut_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool( "File_PopupMenuTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Extract_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Print_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Preview_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "PDFSave_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "TextOutPut_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "End_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool5 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool( "Tool_PopupMenuTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "UserSetUp_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool6 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool( "Window_PopupMenuTool" );
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool( "Dummy_LabelTool" );
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool5 = new Infragistics.Win.UltraWinToolbars.LabelTool( "LoginTitle_LabelTool" );
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool6 = new Infragistics.Win.UltraWinToolbars.LabelTool( "LoginName_LabelTool" );
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "End_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "UserSetUp_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool7 = new Infragistics.Win.UltraWinToolbars.LabelTool( "PrintKindTitle_LabelTool" );
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboBoxTool1 = new Infragistics.Win.UltraWinToolbars.ComboBoxTool( "PrintKind_ComboBoxTool" );
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList( 0 );
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Extract_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool19 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Preview_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool20 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "Print_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool8 = new Infragistics.Win.UltraWinToolbars.LabelTool( "STOP_LabelTool" );
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool1 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool( "PrtSuspendCnt_ControlContainerTool" );
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool9 = new Infragistics.Win.UltraWinToolbars.LabelTool( "Number_LabelTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool21 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "PDFSave_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool22 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "TextOutPut_ButtonTool" );
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool7 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool( "Forms_PopupMenuTool" );
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool23 = new Infragistics.Win.UltraWinToolbars.ButtonTool( "PrintPreview_ButtonTool" );
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( PMHNB02250UA ) );
            this.Main_DockManager = new Infragistics.Win.UltraWinDock.UltraDockManager( this.components );
            this._MAKAU02010UAUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MAKAU02010UAUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MAKAU02010UAUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MAKAU02010UAUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MAKAU02010UAAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.Initial_Timer = new System.Windows.Forms.Timer( this.components );
            this.Main_StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tMemPos1 = new Broadleaf.Library.Windows.Forms.TMemPos( this.components );
            this.TabControl_contextMenu = new System.Windows.Forms.ContextMenu();
            this.Close_menuItem = new System.Windows.Forms.MenuItem();
            this.DataViewTabSharedControlsPage = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.Main_UTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this._MAKAU02010UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Main_ToolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager( this.components );
            this._MAKAU02010UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._MAKAU02010UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._MAKAU02010UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
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
            // _MAKAU02010UAUnpinnedTabAreaLeft
            // 
            this._MAKAU02010UAUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._MAKAU02010UAUnpinnedTabAreaLeft.Font = new System.Drawing.Font( "�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this._MAKAU02010UAUnpinnedTabAreaLeft.Location = new System.Drawing.Point( 0, 63 );
            this._MAKAU02010UAUnpinnedTabAreaLeft.Name = "_MAKAU02010UAUnpinnedTabAreaLeft";
            this._MAKAU02010UAUnpinnedTabAreaLeft.Owner = this.Main_DockManager;
            this._MAKAU02010UAUnpinnedTabAreaLeft.Size = new System.Drawing.Size( 0, 648 );
            this._MAKAU02010UAUnpinnedTabAreaLeft.TabIndex = 5;
            // 
            // _MAKAU02010UAUnpinnedTabAreaRight
            // 
            this._MAKAU02010UAUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._MAKAU02010UAUnpinnedTabAreaRight.Font = new System.Drawing.Font( "�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this._MAKAU02010UAUnpinnedTabAreaRight.Location = new System.Drawing.Point( 1016, 63 );
            this._MAKAU02010UAUnpinnedTabAreaRight.Name = "_MAKAU02010UAUnpinnedTabAreaRight";
            this._MAKAU02010UAUnpinnedTabAreaRight.Owner = this.Main_DockManager;
            this._MAKAU02010UAUnpinnedTabAreaRight.Size = new System.Drawing.Size( 0, 648 );
            this._MAKAU02010UAUnpinnedTabAreaRight.TabIndex = 6;
            // 
            // _MAKAU02010UAUnpinnedTabAreaTop
            // 
            this._MAKAU02010UAUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._MAKAU02010UAUnpinnedTabAreaTop.Font = new System.Drawing.Font( "�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this._MAKAU02010UAUnpinnedTabAreaTop.Location = new System.Drawing.Point( 0, 63 );
            this._MAKAU02010UAUnpinnedTabAreaTop.Name = "_MAKAU02010UAUnpinnedTabAreaTop";
            this._MAKAU02010UAUnpinnedTabAreaTop.Owner = this.Main_DockManager;
            this._MAKAU02010UAUnpinnedTabAreaTop.Size = new System.Drawing.Size( 1016, 0 );
            this._MAKAU02010UAUnpinnedTabAreaTop.TabIndex = 7;
            // 
            // _MAKAU02010UAUnpinnedTabAreaBottom
            // 
            this._MAKAU02010UAUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._MAKAU02010UAUnpinnedTabAreaBottom.Font = new System.Drawing.Font( "�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this._MAKAU02010UAUnpinnedTabAreaBottom.Location = new System.Drawing.Point( 0, 711 );
            this._MAKAU02010UAUnpinnedTabAreaBottom.Name = "_MAKAU02010UAUnpinnedTabAreaBottom";
            this._MAKAU02010UAUnpinnedTabAreaBottom.Owner = this.Main_DockManager;
            this._MAKAU02010UAUnpinnedTabAreaBottom.Size = new System.Drawing.Size( 1016, 0 );
            this._MAKAU02010UAUnpinnedTabAreaBottom.TabIndex = 8;
            // 
            // _MAKAU02010UAAutoHideControl
            // 
            this._MAKAU02010UAAutoHideControl.Font = new System.Drawing.Font( "�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this._MAKAU02010UAAutoHideControl.Location = new System.Drawing.Point( 22, 50 );
            this._MAKAU02010UAAutoHideControl.Name = "_MAKAU02010UAAutoHideControl";
            this._MAKAU02010UAAutoHideControl.Owner = this.Main_DockManager;
            this._MAKAU02010UAAutoHideControl.Size = new System.Drawing.Size( 233, 661 );
            this._MAKAU02010UAAutoHideControl.TabIndex = 9;
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler( this.Initial_Timer_Tick );
            // 
            // Main_StatusBar
            // 
            this.Main_StatusBar.Location = new System.Drawing.Point( 0, 711 );
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
            this.Main_StatusBar.Panels.AddRange( new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3} );
            this.Main_StatusBar.Size = new System.Drawing.Size( 1016, 23 );
            this.Main_StatusBar.TabIndex = 28;
            this.Main_StatusBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tMemPos1
            // 
            this.tMemPos1.OwnerForm = this;
            // 
            // TabControl_contextMenu
            // 
            this.TabControl_contextMenu.MenuItems.AddRange( new System.Windows.Forms.MenuItem[] {
            this.Close_menuItem} );
            // 
            // Close_menuItem
            // 
            this.Close_menuItem.Index = 0;
            this.Close_menuItem.Text = "����(&C)";
            this.Close_menuItem.Click += new System.EventHandler( this.Close_menuItem_Click );
            // 
            // DataViewTabSharedControlsPage
            // 
            this.DataViewTabSharedControlsPage.Location = new System.Drawing.Point( 1, 20 );
            this.DataViewTabSharedControlsPage.Name = "DataViewTabSharedControlsPage";
            this.DataViewTabSharedControlsPage.Size = new System.Drawing.Size( 1014, 627 );
            // 
            // Main_UTabControl
            // 
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BackColor2 = System.Drawing.Color.AliceBlue;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Main_UTabControl.Appearance = appearance3;
            this.Main_UTabControl.BackColorInternal = System.Drawing.Color.FromArgb( ((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))) );
            this.Main_UTabControl.Controls.Add( this.DataViewTabSharedControlsPage );
            this.Main_UTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_UTabControl.Font = new System.Drawing.Font( "�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.Main_UTabControl.InterTabSpacing = new Infragistics.Win.DefaultableInteger( 1 );
            this.Main_UTabControl.Location = new System.Drawing.Point( 0, 63 );
            this.Main_UTabControl.Name = "Main_UTabControl";
            this.Main_UTabControl.SharedControlsPage = this.DataViewTabSharedControlsPage;
            this.Main_UTabControl.Size = new System.Drawing.Size( 1016, 648 );
            this.Main_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.Main_UTabControl.TabIndex = 29;
            this.Main_UTabControl.TabPadding = new System.Drawing.Size( 3, 3 );
            this.Main_UTabControl.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Main_UTabControl.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            this.Main_UTabControl.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler( this.Main_UTabControl_SelectedTabChanged );
            // 
            // _MAKAU02010UA_Toolbars_Dock_Area_Left
            // 
            this._MAKAU02010UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU02010UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))) );
            this._MAKAU02010UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._MAKAU02010UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU02010UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point( 0, 63 );
            this._MAKAU02010UA_Toolbars_Dock_Area_Left.Name = "_MAKAU02010UA_Toolbars_Dock_Area_Left";
            this._MAKAU02010UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size( 0, 648 );
            this._MAKAU02010UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // Main_ToolbarsManager
            // 
            this.Main_ToolbarsManager.DesignerFlags = 1;
            this.Main_ToolbarsManager.DockWithinContainer = this;
            this.Main_ToolbarsManager.DockWithinContainerBaseType = typeof( System.Windows.Forms.Form );
            this.Main_ToolbarsManager.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.Main_ToolbarsManager.ShowFullMenusDelay = 500;
            this.Main_ToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.IsMainMenuBar = true;
            labelTool1.InstanceProps.Spring = Infragistics.Win.DefaultableBoolean.True;
            ultraToolbar1.NonInheritedTools.AddRange( new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1,
            popupMenuTool2,
            popupMenuTool3,
            labelTool1,
            labelTool2,
            labelTool3} );
            ultraToolbar1.ShowInToolbarList = false;
            ultraToolbar1.Text = "���C�����j���[";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 1;
            buttonTool3.InstanceProps.IsFirstInGroup = true;
            ultraToolbar2.NonInheritedTools.AddRange( new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            buttonTool4,
            buttonTool5,
            buttonTool6,
            buttonTool7,
            buttonTool8} );
            ultraToolbar2.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.BelowImage;
            ultraToolbar2.Text = "�W��";
            this.Main_ToolbarsManager.Toolbars.AddRange( new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2} );
            popupMenuTool4.SharedProps.Caption = "�t�@�C��(&F)";
            popupMenuTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            buttonTool14.InstanceProps.IsFirstInGroup = true;
            popupMenuTool4.Tools.AddRange( new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool9,
            buttonTool10,
            buttonTool11,
            buttonTool12,
            buttonTool13,
            buttonTool14} );
            popupMenuTool5.SharedProps.Caption = "�c�[��(&T)";
            popupMenuTool5.SharedProps.Visible = false;
            popupMenuTool5.Tools.AddRange( new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool15} );
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
            //buttonTool16.SharedProps.Caption = "�I��(&X)";  // DEL 2011/12/16 gezh redmine#26635 
            // ADD 2011/12/16 gezh redmine#26635 ------------->>>>>
            buttonTool16.SharedProps.Caption = "�I��(F1)";
            buttonTool16.SharedProps.Shortcut = Shortcut.F1;
            // ADD 2011/12/16 gezh redmine#26635 ------------->>>>>
            buttonTool16.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool16.SharedProps.ShowInCustomizer = false;
            buttonTool17.SharedProps.Caption = "���[�U�[�ݒ�(&C)";
            buttonTool17.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool17.SharedProps.ShowInCustomizer = false;
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
            valueList1.ValueListItems.AddRange( new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3,
            valueListItem4,
            valueListItem5} );
            comboBoxTool1.ValueList = valueList1;
            buttonTool18.SharedProps.Caption = "���o(&E)";
            buttonTool18.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            //buttonTool19.SharedProps.Caption = "PDF�\��(&V)";  // DEL 2011/12/16 gezh redmine#26635
            // ADD 2011/12/16 gezh redmine#26635 ------------->>>>>
            buttonTool19.SharedProps.Caption = "PDF�\��(F11)";
            buttonTool19.SharedProps.Shortcut = Shortcut.F11;
            // ADD 2011/12/16 gezh redmine#26635 ------------->>>>>
            buttonTool19.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            //buttonTool20.SharedProps.Caption = "���(&P)";  // DEL 2011/12/16 gezh redmine#26635
            // ADD 2011/12/16 gezh redmine#26635 ------------->>>>>
            buttonTool20.SharedProps.Caption = "���(F10)";
            buttonTool20.SharedProps.Shortcut = Shortcut.F10;
            // ADD 2011/12/16 gezh redmine#26635 ------------->>>>>
            buttonTool20.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            labelTool8.SharedProps.Caption = "����ꎞ���f����";
            labelTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            controlContainerTool1.SharedProps.MaxWidth = 40;
            controlContainerTool1.SharedProps.MinWidth = 40;
            controlContainerTool1.SharedProps.Width = 41;
            labelTool9.SharedProps.Caption = "��";
            labelTool9.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            //buttonTool21.SharedProps.Caption = "PDF����ۑ�(&S)";  // DEL 2011/12/16 gezh redmine#26635
            // ADD 2011/12/16 gezh redmine#26635 ------------->>>>>
            buttonTool21.SharedProps.Caption = "PDF����ۑ�(F12)";
            buttonTool21.SharedProps.Shortcut = Shortcut.F12;
            // ADD 2011/12/16 gezh redmine#26635 ------------->>>>>
            buttonTool21.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool21.SharedProps.Enabled = false;
            buttonTool22.SharedProps.Caption = "�e�L�X�g�o��(&O)";
            buttonTool22.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool22.SharedProps.Visible = false;
            popupMenuTool7.SharedProps.Caption = "�^�u�ؑ�(&J)";
            popupMenuTool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            popupMenuTool7.SharedProps.ToolTipText = "��ʂ�؂�ւ��܂��B";
            buttonTool23.SharedProps.Caption = "����v���r���[(&W)";
            buttonTool23.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.Main_ToolbarsManager.Tools.AddRange( new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool4,
            popupMenuTool5,
            popupMenuTool6,
            labelTool4,
            labelTool5,
            labelTool6,
            buttonTool16,
            buttonTool17,
            labelTool7,
            comboBoxTool1,
            buttonTool18,
            buttonTool19,
            buttonTool20,
            labelTool8,
            controlContainerTool1,
            labelTool9,
            buttonTool21,
            buttonTool22,
            popupMenuTool7,
            buttonTool23} );
            this.Main_ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler( this.Main_ToolbarsManager_ToolClick );
            this.Main_ToolbarsManager.ToolValueChanged += new Infragistics.Win.UltraWinToolbars.ToolEventHandler( this.Main_ToolbarsManager_ToolValueChanged );
            // 
            // _MAKAU02010UA_Toolbars_Dock_Area_Right
            // 
            this._MAKAU02010UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU02010UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))) );
            this._MAKAU02010UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._MAKAU02010UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU02010UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point( 1016, 63 );
            this._MAKAU02010UA_Toolbars_Dock_Area_Right.Name = "_MAKAU02010UA_Toolbars_Dock_Area_Right";
            this._MAKAU02010UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size( 0, 648 );
            this._MAKAU02010UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _MAKAU02010UA_Toolbars_Dock_Area_Top
            // 
            this._MAKAU02010UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU02010UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))) );
            this._MAKAU02010UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._MAKAU02010UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU02010UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point( 0, 0 );
            this._MAKAU02010UA_Toolbars_Dock_Area_Top.Name = "_MAKAU02010UA_Toolbars_Dock_Area_Top";
            this._MAKAU02010UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size( 1016, 63 );
            this._MAKAU02010UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _MAKAU02010UA_Toolbars_Dock_Area_Bottom
            // 
            this._MAKAU02010UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU02010UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))) );
            this._MAKAU02010UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._MAKAU02010UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU02010UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point( 0, 711 );
            this._MAKAU02010UA_Toolbars_Dock_Area_Bottom.Name = "_MAKAU02010UA_Toolbars_Dock_Area_Bottom";
            this._MAKAU02010UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size( 1016, 0 );
            this._MAKAU02010UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // PMHNB02250UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 8, 15 );
            this.ClientSize = new System.Drawing.Size( 1016, 734 );
            this.Controls.Add( this._MAKAU02010UAAutoHideControl );
            this.Controls.Add( this.Main_UTabControl );
            this.Controls.Add( this._MAKAU02010UAUnpinnedTabAreaTop );
            this.Controls.Add( this._MAKAU02010UAUnpinnedTabAreaBottom );
            this.Controls.Add( this._MAKAU02010UAUnpinnedTabAreaLeft );
            this.Controls.Add( this._MAKAU02010UAUnpinnedTabAreaRight );
            this.Controls.Add( this._MAKAU02010UA_Toolbars_Dock_Area_Left );
            this.Controls.Add( this._MAKAU02010UA_Toolbars_Dock_Area_Right );
            this.Controls.Add( this._MAKAU02010UA_Toolbars_Dock_Area_Top );
            this.Controls.Add( this._MAKAU02010UA_Toolbars_Dock_Area_Bottom );
            this.Controls.Add( this.Main_StatusBar );
            this.Font = new System.Drawing.Font( "�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
            this.Name = "PMHNB02250UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "�������n�t���[��";
            this.Load += new System.EventHandler( this.PMHNB02250UA_Load );
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler( this.PMHNB02250UA_FormClosed );
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_UTabControl)).EndInit();
            this.Main_UTabControl.ResumeLayout( false );
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).EndInit();
            this.ResumeLayout( false );

        }
        #endregion

        // ===================================================================================== //
        // ���C��
        // ===================================================================================== //
        #region Main
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                string msg = "";
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
                #if DEBUG
                    // �f�o�b�O���͔C�ӂɐݒ�ł���悤�ɂ���
                #else
                    else
                    {
                        _startMode = 0;
                    }
                #endif

                    // �I�����C����Ԕ���
                    if (!Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag)
                    {
                        // �I�t���C�����
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID,
                            "�I�t���C����ԂŖ{�@�\�͂��g�p�ł��܂���B", 0, MessageBoxButtons.OK);
                    }
                    else
                    {
                        System.Windows.Forms.Application.EnableVisualStyles();
                        System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                        _form = new PMHNB02250UA();
                        System.Windows.Forms.Application.Run(_form);
                    }
                }
                if (status != 0) TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, CT_PGID, msg, 0, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, CT_PGID, ex.Message, 0, MessageBoxButtons.OK);
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
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            //���b�Z�[�W���o���O�ɑS�ĊJ��
            ApplicationStartControl.EndApplication();
            //�]�ƈ����O�I�t�̃��b�Z�[�W��\��
            if (_form != null) TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, CT_PGID, e.ToString(), 0, MessageBoxButtons.OK);
            else TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, CT_PGID, e.ToString(), 0, MessageBoxButtons.OK);
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
        private const string CT_PGID = "PMHNB02250U";
        private const string MAIN_FORM_TITLE = "�����Ǘ��i�����j";
        
        // �N�����[�h�萔
        private const int START_MODE_DEFAULT_LIST = 1;		 // �����ꗗ�\�i�����j
        private const int START_MODE_DEFAULT_TOTAL = 2;		 // �������i�����j
        
        private Hashtable _formControlInfoTable = new Hashtable();
        private const string DOCK_NAVIGATOR = "Navigator_Tree";
        private const string DOCK_EXPLORERBAR = "Main_ExplorerBar";
        private const string NO0_DEMANDMAIN_TAB = "DEMAND_MAIN_TAB";
        private const string NO1_LISTPREVIEW_TAB = "LISTPREVIEW_TAB";
        private const string NO2_TOTALPREVIEW_TAB = "TOTALPREVIEW_TAB";
        
        /// <summary>������PDF�v���r���[�̃^�u����</summary>
        private const string TOTAL_PREVIEW_TAB_NAME     = "�������i�����j�v���r���[";
        
        // �c�[���o�[�c�[���L�[�ݒ�
        private const string TOOLBAR_LOGINLABEL_TITLE = "LoginTitle_LabelTool";
        private const string TOOLBAR_LOGINNAMELABEL_KEY = "LoginName_LabelTool";
        private const string TOOLBAR_ENDBUTTON_KEY = "End_ButtonTool";
        private const string TOOLBAR_EXTRACTBUTTON_KEY = "Extract_ButtonTool";
        private const string TOOLBAR_PREVIEWBUTTON_KEY = "Preview_ButtonTool";
        private const string TOOLBAR_PRINTBUTTON_KEY = "Print_ButtonTool";
        private const string TOOLBAR_PRINTKINDTITLE_KEY = "PrintKindTitle_LabelTool";
        private const string TOOLBAR_PRINTKINDCOMB_KEY = "PrintKind_ComboBoxTool";
        private const string TOOLBAR_EDITTOTAL_KEY = "EditTotal_ButtonTool";
        private const string TOOLBAR_EDITNEW_KEY = "EditNew_ButtonTool";
        private const string TOOLBAR_USERSETUP_KEY = "UserSetUp_ButtonTool";

        private const string TOOLBAR_STOPLABEL_KEY = "STOP_LabelTool";
        private const string TOOLBAR_PRTSUSPENDCNT_KEY = "PrtSuspendCnt_ControlContainerTool";
        private const string TOOLBAR_NUMBERLABEL_KEY = "Number_LabelTool";
        private const string TOOLBAR_PDFSAVEBUTTON_KEY = "PDFSave_ButtonTool";

        private const string TOOLBAR_TEXTOUTPUT_KEY = "TextOutPut_ButtonTool";
        // --- ADD m.suzuki 2010/06/23 ---------->>>>>
        private const string TOOLBAR_PRINTPREVIEWBUTTON_KEY = "PrintPreview_ButtonTool";
        // --- ADD m.suzuki 2010/06/23 ----------<<<<<
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region Private Members
        // �N�����[�h[1:�����ꗗ�\�i�����j,2:�������i�����j]

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
        private void BeginControllingByOperationAuthority(string assemblyId)
        {
            #region <Guard Phrase/>

            if (!MyOpeCtrlMap.ContainsKey(assemblyId)) return;

            #endregion  // <Guard Phrase/>

            // �c�[���{�^���̑��쌠���̐���ݒ�
            List<ToolButtonInfo> toolButtonInfoList = new List<ToolButtonInfo>();

            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_PRINTBUTTON_KEY, ReportFrameOpeCode.Print, false));
            // --- ADD m.suzuki 2010/06/23 ---------->>>>>
            toolButtonInfoList.Add( new ReportToolButtonInfo( TOOLBAR_PRINTPREVIEWBUTTON_KEY, ReportFrameOpeCode.Print, false ) ); // ����v���r���[(����Ɠ�����)
            // --- ADD m.suzuki 2010/06/23 ----------<<<<<
            toolButtonInfoList.Add( new ReportToolButtonInfo( TOOLBAR_EXTRACTBUTTON_KEY, ReportFrameOpeCode.Extract, false ) );
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_PREVIEWBUTTON_KEY, ReportFrameOpeCode.OutputPDF, false));
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_PDFSAVEBUTTON_KEY, ReportFrameOpeCode.SavePDF, false));
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_TEXTOUTPUT_KEY, ReportFrameOpeCode.OutputText, false));

            MyOpeCtrlMap[assemblyId].MyOpeCtrl.AddControlItem(this.Main_ToolbarsManager, toolButtonInfoList);
            // ���쌠���̐�����J�n
            MyOpeCtrlMap[assemblyId].MyOpeCtrl.BeginControl();
        }

        #endregion  // <���쌠������/>

        private static string[] _parameter;
        private static System.Windows.Forms.Form _form = null;

        private SumDemandPrintAcs _demandPrintAcs = null;

        // �C�x���g�t���O
        private bool _eventDoFlag = false;
        private Hashtable _delPDFList = null;							// �폜PDF�i�[���X�g

        private PdfHistoryControl _pdfHistoryCtrl = null;				// PDF�����Ǘ����i

        private bool _isOptCmnTextOutPut = false;						// �e�L�X�g�o�̓I�v�V����
        
        #endregion

        // ===================================================================================== //
        // �������\�b�h
        // ===================================================================================== //
        #region private method
        /// <summary>
        /// �����ݒ�f�[�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����ݒ�f�[�^�̓Ǎ����s���܂��B</br>
        /// <br></br>
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
        /// <br>Note       : ������ʐݒ���s���܂��B</br>
        /// <br></br>
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

            // ���o�̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool extractButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
            if (extractButton != null) extractButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;

            // �v���r���[�̃A�C�R���ݒ�            
            Infragistics.Win.UltraWinToolbars.ButtonTool previewButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
            if (previewButton != null) previewButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PREVIEW;

            // ����̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool printButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
            if (printButton != null) printButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;

            // --- ADD m.suzuki 2010/06/23 ---------->>>>>
            // ����v���r���[�̃A�C�R���ݒ�(PDF�o�͂Ɠ���)
            Infragistics.Win.UltraWinToolbars.ButtonTool printPreviewButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
            if ( printPreviewButton != null ) printPreviewButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PREVIEW;
            // --- ADD m.suzuki 2010/06/23 ----------<<<<<

            // ���[�U�[�ݒ�̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool setUpButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_USERSETUP_KEY];
            if (setUpButton != null) setUpButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;

            // ���ޑI��
            Infragistics.Win.UltraWinToolbars.ComboBoxTool printKindComb = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDCOMB_KEY];
            if (printKindComb != null)
            {
                printKindComb.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;
            }

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

            // �e�L�X�g�o��
            Infragistics.Win.UltraWinToolbars.ButtonTool textOputPutButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
            if (textOputPutButton != null) textOputPutButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;

            PurchaseStatus purchaseStatus =
                LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_TextOutput);
            if (purchaseStatus == PurchaseStatus.Contract ||			// �_���
                    purchaseStatus == PurchaseStatus.Trial_Contract)	// �̌��Ō_���
            {
                this._isOptCmnTextOutPut = true;
            }
            else
            {
                this._isOptCmnTextOutPut = false;
            }
            
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
        /// <br>Note       : �t�H�[���R���g���[���N���X���N���G�C�g���A�f�[�^���i�[���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void FormControlInfoCreate()
        {
            this._formControlInfoTable.Clear();
            FormControlInfo info0 = null;
            FormControlInfo info1 = null;
            FormControlInfo info2 = null;
            
            switch (_startMode)
            {
                case START_MODE_DEFAULT_LIST:			// �����ꗗ�\�i�����j
                    {
                        info0 = new FormControlInfo(NO0_DEMANDMAIN_TAB, "PMHNB02252U", "Broadleaf.Windows.Forms.PMHNB02252UA", "�����ꗗ�\�i�����j", IconResourceManagement.ImageList16.Images[(int)Size16_Index.MAIN]);
                        this._formControlInfoTable.Add(NO0_DEMANDMAIN_TAB, info0);
                        break;
                    }
                case START_MODE_DEFAULT_TOTAL:			// �������i�����j
                    {
                        info0 = new FormControlInfo(NO0_DEMANDMAIN_TAB, "PMHNB02252U", "Broadleaf.Windows.Forms.PMHNB02252UA", "�������i�����j", IconResourceManagement.ImageList16.Images[(int)Size16_Index.MAIN]);
                        this._formControlInfoTable.Add(NO0_DEMANDMAIN_TAB, info0);
                        break;
                    }
                default:
                    {
                        info0 = new FormControlInfo(NO0_DEMANDMAIN_TAB, "PMHNB02250U", "Broadleaf.Windows.Forms.PMHNB02252UA", "�������i�����j���C��", IconResourceManagement.ImageList16.Images[(int)Size16_Index.MAIN]);
                        this._formControlInfoTable.Add(NO0_DEMANDMAIN_TAB, info0);
                        break;
                    }
            }

            info1 = new FormControlInfo(NO1_LISTPREVIEW_TAB, "PMHNB02250U", "Broadleaf.Windows.Forms.PMHNB02250UB", "�����ꗗ�\�i�����j�v���r���[", IconResourceManagement.ImageList16.Images[(int)Size16_Index.PREVIEW]);
            this._formControlInfoTable.Add(NO1_LISTPREVIEW_TAB, info1);

            info2 = new FormControlInfo(NO2_TOTALPREVIEW_TAB, "PMHNB02250U", "Broadleaf.Windows.Forms.PMHNB02250UB", TOTAL_PREVIEW_TAB_NAME, IconResourceManagement.ImageList16.Images[(int)Size16_Index.PREVIEW]);
            this._formControlInfoTable.Add(NO2_TOTALPREVIEW_TAB, info2);
        }

        /// <summary>
        /// �^�u�N���G�C�g����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �^�u�t�H�[���𐶐����܂��B</br>
        /// <br></br>
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
                        if (this._extractionInfoForm is ISumDemandTbsMDIChildMain)
                        {
                            ((ISumDemandTbsMDIChildMain)this._extractionInfoForm).Show((Object)_startMode);
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

                        // �������n�t���[���Ή��FPDF���ꊇ�\��
                        if (_startMode.Equals(START_MODE_DEFAULT_TOTAL))
                        {
                            // TODO:�ŋߏo�͂����ꗗ�\��PDF�\���^�u�̖��̕ύX�͂�����
                        }

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

                        // �������n�t���[���Ή��FPDF���ꊇ�\��
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
                    case NO2_TOTALPREVIEW_TAB:  // �������i�����j
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
        /// <br></br>
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
        /// <param>none</param>
        /// <returns>none</returns>
        /// <remarks>
        /// <br>Note       : MDI�q��ʂ𐶐�����</br>
        /// <br></br>
        /// </remarks>
        private Form CreateTabForm(FormControlInfo info)
        {
            Form form = null;

            // �e��t�H�[���̃C���X�^���X��
            switch (info.Key)
            {
                case NO0_DEMANDMAIN_TAB:
                {
                    form = new Broadleaf.Windows.Forms.PMHNB02252UA();
                    ((PMHNB02252UA)form).SelectedPdfNodeEvent += new SelectedPdfNodeEventHandler(this.SelectedPdfView);
                    ((PMHNB02252UA)form).StatusBarInfoPrinted += new PrintStatusBar(this.PrintStatusBar);
                    break;
                }
                case NO1_LISTPREVIEW_TAB:
                case NO2_TOTALPREVIEW_TAB:
                    form = new Broadleaf.Windows.Forms.PMHNB02250UB();
                    break;
                default:
                    break;
            }

            // �������n�t���[���Ή��FPDF���ꊇ�\��
            // ��ڈȍ~��PDF�v���r���[�t�H�[���𐶐�
            if (form == null)
            {
                if (info.Key.Contains(NO2_TOTALPREVIEW_TAB))
                {
                    form = new Broadleaf.Windows.Forms.PMHNB02250UB();
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

                if (form is ISumDemandTbsMDIChildMain)
                {
                    ((ISumDemandTbsMDIChildMain)form).Show((Object)_startMode);
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
        /// <br>Note       : �o�c�e������\�����܂��B</br>
        /// <br></br>
        /// </remarks>
        private void SelectedPdfView(string key, string printName, string pdfpath)
        {

            // �v���r���[�^�u�����@�������ꗗ�^�u���Œ�
            this.TabCreate(NO1_LISTPREVIEW_TAB);
            if (this._listPreviewForm != null)
            {
                this.TabActive(NO1_LISTPREVIEW_TAB, ref this._listPreviewForm);

                PMHNB02250UB target = this._listPreviewForm as PMHNB02250UB;

                if (target != null)
                {
                    target.IsSave = false;
                    target.PrintKey = "";
                    target.PrintName = "";
                    target.PrintDetailName = "";
                    target.PrintPDFPath = "";
                    target.Navigate((Object)pdfpath);
                }

                // �c�[���o�[�{�^���ݒ�
                this.ToolBarSetting(target);
            }
        }

        /// <summary>
        /// �c�[���o�[���ڏ�Ԑݒ�
        /// </summary>
        /// <param name="key"></param>
        private void ToolbarConditionSetting(string key)
        {
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool;
            Infragistics.Win.UltraWinToolbars.LabelTool lblTool;
            Infragistics.Win.UltraWinToolbars.ComboBoxTool combboxTool;
            Infragistics.Win.UltraWinToolbars.ControlContainerTool containerTool;

            // ���ޑI��\���t���O
            bool isPrintKindComb = false;

            // ����ꎞ���f���x��
            lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_STOPLABEL_KEY];
            if (lblTool != null) lblTool.SharedProps.Visible = false;

            // ����ꎞ���f����
            containerTool = (Infragistics.Win.UltraWinToolbars.ControlContainerTool)Main_ToolbarsManager.Tools[TOOLBAR_PRTSUSPENDCNT_KEY];
            if (containerTool != null) containerTool.SharedProps.Visible = false;

            // ����������x��
            lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_NUMBERLABEL_KEY];
            if (lblTool != null) lblTool.SharedProps.Visible = false;

            switch (key)
            {
                case NO0_DEMANDMAIN_TAB:
                    {
                        // ���o
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = true;

                        // ���ޑI�����x��
                        lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDTITLE_KEY];

                        // ���ޑI���R���{
                        combboxTool = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDCOMB_KEY];

                        switch (_startMode)
                        {
                            case START_MODE_DEFAULT_LIST:			// �����ꗗ�\�i�����j
                            case START_MODE_DEFAULT_TOTAL:			// �������i�����j
                                {
                                    isPrintKindComb = true;

                                    switch (_startMode)
                                    {

                                        case START_MODE_DEFAULT_LIST:			// �����ꗗ�\�i�����j
                                            {
                                                combboxTool.SelectedIndex = 0;
                                                break;
                                            }
                                        case START_MODE_DEFAULT_TOTAL:			// �������i�����j
                                            {
                                                combboxTool.SelectedIndex = 1;
                                                break;
                                            }
                                    }
                                    break;
                                }
                            default:
                                {
                                    isPrintKindComb = true;
                                    break;
                                }
                        }
                        if (lblTool != null) lblTool.SharedProps.Visible = isPrintKindComb;
                        if (combboxTool != null) combboxTool.SharedProps.Visible = isPrintKindComb;

                        // ���
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = true;

                        // --- ADD m.suzuki 2010/06/23 ---------->>>>>
                        // ����v���r���[
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
                        if ( buttonTool != null ) buttonTool.SharedProps.Visible = (_startMode != START_MODE_DEFAULT_LIST);
                        // --- ADD m.suzuki 2010/06/23 ----------<<<<<

                        // PDF�\��
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = true;

                        // �e�L�X�g�o��
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
                        // ����̓e�L�X�g�o�͋@�\�͂Ȃ�
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;
                        
                        // ���ݑI�𒆂̏��ނɂ��ꎞ���f�{�^���̕\����ؑւ���
                        if (combboxTool != null && combboxTool.SelectedItem is Infragistics.Win.ValueListItem)
                        {
                            Infragistics.Win.ValueListItem item = combboxTool.SelectedItem as Infragistics.Win.ValueListItem;

                            int selectPrint = Convert.ToInt32(item.DataValue);

                            // �������i�����j�H
                            if (selectPrint == 2)
                            {
                                // ����ꎞ���f���x��
                                lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_STOPLABEL_KEY];
                                if (lblTool != null) lblTool.SharedProps.Visible = true;

                                // ����ꎞ���f����
                                containerTool = (Infragistics.Win.UltraWinToolbars.ControlContainerTool)Main_ToolbarsManager.Tools[TOOLBAR_PRTSUSPENDCNT_KEY];
                                if (containerTool != null) containerTool.SharedProps.Visible = true;

                                // ����������x��
                                lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_NUMBERLABEL_KEY];
                                if (lblTool != null) lblTool.SharedProps.Visible = true;
                            }
                            else
                            {
                                // ����ꎞ���f���x��
                                lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_STOPLABEL_KEY];
                                if (lblTool != null) lblTool.SharedProps.Visible = false;

                                // ����ꎞ���f����
                                containerTool = (Infragistics.Win.UltraWinToolbars.ControlContainerTool)Main_ToolbarsManager.Tools[TOOLBAR_PRTSUSPENDCNT_KEY];
                                if (containerTool != null) containerTool.SharedProps.Visible = false;

                                // ����������x��
                                lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_NUMBERLABEL_KEY];
                                if (lblTool != null) lblTool.SharedProps.Visible = false;
                            }

                        }

                        // ���[�U�[�ݒ�
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_USERSETUP_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;

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
                        // ���ޑI�����x��
                        lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDTITLE_KEY];
                        if (lblTool != null) lblTool.SharedProps.Visible = false;
                        // ���ޑI���R���{
                        combboxTool = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDCOMB_KEY];
                        if (combboxTool != null) combboxTool.SharedProps.Visible = false;
                        // �v���r���[
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;
                        // ���
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;
                        // --- ADD m.suzuki 2010/06/23 ---------->>>>>
                        // ����v���r���[
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
                        if ( buttonTool != null ) buttonTool.SharedProps.Visible = false;
                        // --- ADD m.suzuki 2010/06/23 ----------<<<<<
                        // ���[�U�[�ݒ�
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_USERSETUP_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;
                        // PDF����ۑ�
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;
                        // �e�L�X�g�o��
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
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
        /// <br></br>
        /// </remarks>
        private void SavePDF( string key )
        {
            try
            {
                // �������n�t���[���Ή��FPDF���ꊇ�\��
                FormControlInfo info= null;
                PMHNB02250UB target = null;
                if (this._formControlInfoTable.Contains(key))
                {
                    // �A�N�e�B�u�^�u���璠�[�R���g���[�������擾
                    info = this._formControlInfoTable[key] as FormControlInfo;

                    // PDF�v���r���[�t�H�[��
                    if (info != null) target = info.Form as PMHNB02250UB;
                }
                else
                {
                    // ����PDF�v���r���[�p����
                    if (OtherPDFPreviewFormMap.ContainsKey(key))
                    {
                        target = OtherPDFPreviewFormMap[key] as PMHNB02250UB;
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
                            TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "�Y���̂o�c�e�͊��ɗ���o�^����Ă��܂��B", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            return;
                        }

                        // --- UPD m.suzuki 2010/07/28 ---------->>>>>
                        //// �o�͗����Ǘ��ɒǉ�
                        //this._pdfHistoryCtrl.AddPrintHistoryList(target.PrintKey, target.PrintName, target.PrintDetailName,
                        //    target.PrintPDFPath);

                        //// �폜���X�g���珜�O����
                        //if (this._delPDFList.Contains(target.PrintPDFPath))
                        //{
                        //    this._delPDFList.Remove(target.PrintPDFPath);
                        //}

                        # region [�폜���X�g���珜�O����]
                        // �S�Ẵ^�u�ɂ���
                        foreach ( Infragistics.Win.UltraWinTabControl.UltraTab tab in this.Main_UTabControl.Tabs )
                        {
                            FormControlInfo wkInfo = null;
                            PMHNB02250UB wkTarget = null;
                            if ( this._formControlInfoTable.Contains( tab.Key ) )
                            {
                                wkInfo = this._formControlInfoTable[tab.Key] as FormControlInfo;
                                if ( wkInfo != null ) wkTarget = wkInfo.Form as PMHNB02250UB;
                            }
                            else
                            {
                                if ( OtherPDFPreviewFormMap.ContainsKey( tab.Key ) )
                                {
                                    wkTarget = OtherPDFPreviewFormMap[tab.Key] as PMHNB02250UB;
                                }
                            }
                            if ( wkTarget == null ) continue;

                            // �v���r���[�\���^�u�Ȃ��PDF�폜���X�g���珜�O����
                            if ( wkTarget.IsSave )
                            {
                                // �o�͗����Ǘ��ɒǉ�
                                this._pdfHistoryCtrl.AddPrintHistoryList( wkTarget.PrintKey, wkTarget.PrintName, wkTarget.PrintDetailName,
                                    wkTarget.PrintPDFPath );

                                // �폜���X�g���珜�O����
                                if ( this._delPDFList.Contains( wkTarget.PrintPDFPath ) )
                                {
                                    this._delPDFList.Remove( wkTarget.PrintPDFPath );
                                }
                            }
                        }
                        # endregion
                        // --- UPD m.suzuki 2010/07/28 ----------<<<<<
                    }

                    TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "�ۑ����܂����B", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, "�o�c�e�̗���ۑ��Ɏ��s���܂����B" + "\n\r" + ex.Message,
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
        /// <br></br>
        /// </remarks>
        private void ToolBarSetting(object activeForm)
        {
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool;
            Infragistics.Win.UltraWinToolbars.ComboBoxTool combboxTool;
            Infragistics.Win.UltraWinToolbars.ControlContainerTool containerTool;

            if (activeForm != null)
            {
                if (activeForm is ISumDemandTbsMDIChildMain)
                {
                    // ���o
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = true;
                    }

                    // ���ޑI���R���{
                    bool isEnbled = false;
                    combboxTool = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDCOMB_KEY];
                    if (combboxTool != null)
                    {
                        switch (_startMode)
                        {
                            case START_MODE_DEFAULT_LIST:			// �����ꗗ�\�i�����j
                            case START_MODE_DEFAULT_TOTAL:			// �������i�����j
                                {
                                    isEnbled = true;
                                    break;
                                }
                        }
                        combboxTool.SharedProps.Enabled = isEnbled;
                    }

                    // ���ݑI�𒆂̏��ނɂ��ꎞ���f�{�^���̕\����ؑւ���
                    if (combboxTool != null && combboxTool.SelectedItem is Infragistics.Win.ValueListItem)
                    {
                        Infragistics.Win.ValueListItem item = combboxTool.SelectedItem as Infragistics.Win.ValueListItem;

                        int selectPrint = Convert.ToInt32(item.DataValue);

                        // �������i�����j�H
                        if (selectPrint == 2)
                        {
                            // ����ꎞ���f����
                            containerTool = (Infragistics.Win.UltraWinToolbars.ControlContainerTool)Main_ToolbarsManager.Tools[TOOLBAR_PRTSUSPENDCNT_KEY];
                            if (containerTool != null)
                            {
                                containerTool.SharedProps.Enabled = true;
                            }

                        }
                        else
                        {
                            // ����ꎞ���f����
                            containerTool = (Infragistics.Win.UltraWinToolbars.ControlContainerTool)Main_ToolbarsManager.Tools[TOOLBAR_PRTSUSPENDCNT_KEY];
                            if (containerTool != null)
                            {
                                containerTool.SharedProps.Enabled = false;
                            }
                        }

                        // �����ꗗ�\�i�����j
                        if (selectPrint == 1)
                        {
                            // PDF�\��
                            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                            if (buttonTool != null)
                            {
                                buttonTool.SharedProps.Enabled = true;
                            }

                            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
                            if (buttonTool != null) buttonTool.SharedProps.Enabled = true;
                        }
                        // �������i�����j
                        else
                        {
                            // PDF�\��
                            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                            if (buttonTool != null)
                            {
                                // PDF�\���{�^����L��
                                buttonTool.SharedProps.Enabled = true;
                            }

                            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
                            if (buttonTool != null) buttonTool.SharedProps.Enabled = false;
                        }
                    }

                    // ���
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = true;
                    }
                    // --- ADD m.suzuki 2010/06/23 ---------->>>>>
                    // ����v���r���[
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
                    if ( buttonTool != null )
                    {
                        buttonTool.SharedProps.Enabled = (_startMode != START_MODE_DEFAULT_LIST);
                    }
                    // --- ADD m.suzuki 2010/06/23 ----------<<<<<

                    // PDF����ۑ�
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }

                }
                else if (activeForm is PMHNB02250UB)
                {
                    // ���o
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }

                    combboxTool = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDCOMB_KEY];
                    if (combboxTool != null)
                    {
                        combboxTool.SharedProps.Enabled = false;
                    }

                    // ����ꎞ���f����
                    containerTool = (Infragistics.Win.UltraWinToolbars.ControlContainerTool)Main_ToolbarsManager.Tools[TOOLBAR_PRTSUSPENDCNT_KEY];
                    if (containerTool != null)
                    {
                        containerTool.SharedProps.Enabled = false;
                    }

                    // ���
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }
                    // --- ADD m.suzuki 2010/06/23 ---------->>>>>
                    // ����v���r���[
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
                    if ( buttonTool != null )
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }
                    // --- ADD m.suzuki 2010/06/23 ----------<<<<<

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
                        PMHNB02250UB target = activeForm as PMHNB02250UB;
                        if (target != null)
                        {
                            buttonTool.SharedProps.Enabled = target.IsSave;
                        }
                    }

                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
                    if (buttonTool != null) buttonTool.SharedProps.Enabled = false;
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

                combboxTool = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDCOMB_KEY];
                if (combboxTool != null)
                {
                    combboxTool.SharedProps.Enabled = false;
                }

                // ����ꎞ���f����
                containerTool = (Infragistics.Win.UltraWinToolbars.ControlContainerTool)Main_ToolbarsManager.Tools[TOOLBAR_PRTSUSPENDCNT_KEY];
                if (containerTool != null)
                {
                    containerTool.SharedProps.Enabled = false;
                }

                // ���
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }
                // --- ADD m.suzuki 2010/06/23 ---------->>>>>
                // ����v���r���[
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTPREVIEWBUTTON_KEY];
                if ( buttonTool != null )
                {
                    buttonTool.SharedProps.Enabled = false;
                }
                // --- ADD m.suzuki 2010/06/23 ----------<<<<<

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

                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
                if (buttonTool != null) buttonTool.SharedProps.Enabled = false;
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
        /// <br>Note       : �o�͌����̐ݒ���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, CT_PGID, iMsg, iSt, iButton, iDefButton);
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
        /// </remarks>
        private void PMHNB02250UA_Load(object sender, System.EventArgs e)
        {
            // ������ʐݒ�
            this.InitialScreenSetting();

            // �^�C�g���ݒ�
            this.Text = MAIN_FORM_TITLE;

            switch (_startMode)
            {
                case START_MODE_DEFAULT_LIST:			// �����ꗗ�\�i�����j
                    this.Text = MAIN_FORM_TITLE + " - " + "�����ꗗ�\�i�����j";
                    break;
                case START_MODE_DEFAULT_TOTAL:			// �������i�����j
                    this.Text = MAIN_FORM_TITLE + " - " + "�������i�����j";
                    break;
                default:
                    this.Text = MAIN_FORM_TITLE;
                    break;
            }

            // �c�[���o�[�̏����ݒ�
            this.ToolbarConditionSetting(NO0_DEMANDMAIN_TAB);
            
            // �E�C���h�E�{�^���쐬����
            this.CreateWindowStateButtonTools();

            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// ���������^�C�}�[�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : �����^�C�}�[�C�x���g�ł��B</br>
        /// <br></br>
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

                // ���C����ʋN��
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
        /// <br></br>
        /// </remarks>
        private void Main_ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
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

                        if (activeForm is ISumDemandTbsMDIChildMain)
                        {
                            int printType = 0;

                            // ���o���钠�[��ގ擾
                            Infragistics.Win.UltraWinToolbars.ComboBoxTool combboxTool =
                              Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDCOMB_KEY] as Infragistics.Win.UltraWinToolbars.ComboBoxTool;
                            if (combboxTool != null)
                            {
                                Infragistics.Win.ValueListItem item = combboxTool.SelectedItem as Infragistics.Win.ValueListItem;
                                printType = Convert.ToInt32(item.DataValue);
                            }
                            else
                            {
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, "������钠�[��I�����ĉ������B", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                return;
                            }

                            // ��ʓ��̓`�F�b�N
                            this.Main_ToolbarsManager.Enabled = false;
                            try
                            {
                                // --- DEL  ���r��  2010/02/01 ---------->>>>>
                                //if (((ISumDemandTbsMDIChildMain)activeForm).ScreenInputCheck())
                                // --- DEL  ���r��  2010/02/01 ----------<<<<<
                                {
                                    ((ISumDemandTbsMDIChildMain)activeForm).ExtractData(printType);
                                }
                            }
                            finally
                            {
                                this.Main_ToolbarsManager.Enabled = true;
                            }
                        }
                        break;
                    }

                case TOOLBAR_PREVIEWBUTTON_KEY: // �v���r���[
                case TOOLBAR_PRINTBUTTON_KEY: // ���
                // --- ADD m.suzuki 2010/06/23 ---------->>>>>
                case TOOLBAR_PRINTPREVIEWBUTTON_KEY: // ����v���r���[
                // --- ADD m.suzuki 2010/06/23 ----------<<<<<
                    {
                        // �����ꗗ�ȊO�͊m�F�_�C�A���O��\��
                        if (!_startMode.Equals(START_MODE_DEFAULT_LIST) && e.Tool.Key.Equals(TOOLBAR_PRINTBUTTON_KEY))
                        {
                            DialogResult dialogResult = MessageBox.Show(
                                "������܂����H",   // LITERAL:
                                this.Text,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                            );
                            if (dialogResult.Equals(DialogResult.No)) return;
                        }
                        
                        // �A�N�e�B�u��Ԃ̃^�u����t�H�[�����擾����
                        FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_UTabControl.ActiveTab.Key.ToString()];
                        System.Windows.Forms.Form activeForm = formControlInfo.Form;

                        if ((activeForm is ISumDemandTbsMDIChildMain))
                        {
                            SFCMN06002C printInfo = new SFCMN06002C();
                            printInfo.pdfopen = false;
                            printInfo.pdftemppath = "";

                            // �����ꗗ�\�ȊO�̓_�C�A���O���䂪�����̂ŁA��Ɂu0:�v���r���[�Ȃ��v
                            if (!_startMode.Equals(START_MODE_DEFAULT_LIST))
                            {
                                printInfo.pdfopen = true;
                                // --- UPD m.suzuki 2010/06/23 ---------->>>>>
                                //printInfo.prevkbn = 0;
                                if ( e.Tool.Key != TOOLBAR_PRINTPREVIEWBUTTON_KEY )
                                {
                                    printInfo.prevkbn = 0; // 0:�v���r���[�Ȃ�
                                }
                                else
                                {
                                    printInfo.prevkbn = 1; // 1:�v���r���[����
                                }
                                // --- UPD m.suzuki 2010/06/23 ----------<<<<<
                            }
                            
                            // ������钠�[��ގ擾
                            Infragistics.Win.UltraWinToolbars.ComboBoxTool combboxTool =
                                Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDCOMB_KEY] as Infragistics.Win.UltraWinToolbars.ComboBoxTool;
                            if (combboxTool != null)
                            {
                                Infragistics.Win.ValueListItem item = combboxTool.SelectedItem as Infragistics.Win.ValueListItem;
                                printInfo.PrintPaperSetCd = Convert.ToInt32(item.DataValue);

                                // �������i�����j��
                                if (printInfo.PrintPaperSetCd == 2)
                                {
                                    ;
                                }
                            }
                            else
                            {
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, "������钠�[��I�����ĉ������B", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                return;
                            }

                            // ������[�h�̐ݒ�
                            int printMode = 0;
                            switch (e.Tool.Key)
                            {
                                case TOOLBAR_PRINTBUTTON_KEY:
                                // --- ADD m.suzuki 2010/06/23 ---------->>>>>
                                case TOOLBAR_PRINTPREVIEWBUTTON_KEY:
                                // --- ADD m.suzuki 2010/06/23 ----------<<<<<

                                    if ((printInfo.PrintPaperSetCd == 1) || (printInfo.PrintPaperSetCd == 3))	// �����ꗗ�\�i�����j
                                    {
                                        // �������
                                        printMode = (int)emPrintMode.emPrinterAndPDF;
                                    }
                                    else																	    // �������i�����j
                                    {
                                        // �ʏ���
                                        printMode = (int)emPrintMode.emPrinter;
                                    }
                                    break;
                                case TOOLBAR_PREVIEWBUTTON_KEY:
                                    // �o�c�e�o��
                                    printMode = (int)emPrintMode.emPDF;
                                    break;
                                default:
                                    break;
                            }
                            printInfo.printmode = printMode;

                            ISumDemandTbsMDIChildMain interFase = activeForm as ISumDemandTbsMDIChildMain;

                            Object parameter = (Object)printInfo;
                            int status = interFase.Print(ref parameter);

                            switch (status)
                            {
                                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                                    {
                                        // �o�c�e�o�͏ꍇ�̂�
                                        if (printMode == (int)emPrintMode.emPDF)
                                        {
                                            // �o�c�e�폜���X�g�ɒǉ�
                                            if (printInfo.pdftemppath != "")
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
                                            if (activeForm is PMHNB02252UA)
                                            {
                                                CurrentOutputPDF = ((PMHNB02252UA)activeForm).OutputPDF;
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
                                                PMHNB02250UB target = null;
                                                string key = "";

                                                switch (printInfo.PrintPaperSetCd)
                                                {
                                                    case 1: // �����ꗗ�\�i�����j
                                                    case 3: // �����ꗗ�\(����)�������Ӑ����F�󎚂���
                                                        // �v���r���[�^�u����
                                                        this.TabCreate(NO1_LISTPREVIEW_TAB);
                                                        if (this._listPreviewForm != null)
                                                        {
                                                            frm = this._listPreviewForm;
                                                            target = frm as PMHNB02250UB;
                                                            key = NO1_LISTPREVIEW_TAB;

                                                            // �E�C���h�E�{�^���쐬����
                                                            this.CreateWindowStateButtonTools();
                                                        }
                                                        break;
                                                    case 2: // �������i�����j
                                                        // �v���r���[�^�u����
                                                        this.TabCreate(NO2_TOTALPREVIEW_TAB);
                                                        if (this._totalPreviewForm != null)
                                                        {
                                                            frm = this._totalPreviewForm;
                                                            target = frm as PMHNB02250UB;
                                                            key = NO2_TOTALPREVIEW_TAB;
                                                        }

                                                        // �������n�t���[���Ή��FPDF���ꊇ�\��
                                                        if (activeForm is PMHNB02252UA)
                                                        {
                                                            if (CurrentOutputPDF.ExistsOtherPDFPreview)
                                                            {
                                                                for (int i = 1; i < CurrentOutputPDF.PreviewPDFPathList.Count; i++)
                                                                {
                                                                    AddOtherPDFPreviewTab(NO2_TOTALPREVIEW_TAB, i);
                                                                }
                                                            }
                                                        }                                                        
                                                        break;
                                                    default:
                                                        break;
                                                }

                                                if (target != null)
                                                {
                                                    target.IsSave = true;
                                                    target.PrintKey = printInfo.key;
                                                    target.PrintName = printInfo.prpnm;
                                                    target.PrintDetailName = printInfo.prpnm;
                                                    target.PrintPDFPath = printInfo.pdftemppath;
                                                    target.Navigate(printInfo.pdftemppath);
                                                    // �������n�t���[���Ή��FPDF���ꊇ�\��
                                                    if (CurrentOutputPDF.ExistsOtherPDFPreview)
                                                    {
                                                        // ��ڈȍ~��PDF��\��
                                                        string originalKey = key;

                                                        for (int i = 1; i < CurrentOutputPDF.PreviewPDFPathList.Count; i++)
                                                        {
                                                            string otherKey = GetOtherPDFPreviewFormKey(originalKey, i);
                                                            PMHNB02250UB otherTarget = OtherPDFPreviewFormMap[otherKey] as PMHNB02250UB;
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

                case TOOLBAR_USERSETUP_KEY:
                    {
                        break;
                    }

                case TOOLBAR_PDFSAVEBUTTON_KEY:
                    {
                        this.SavePDF(this.Main_UTabControl.ActiveTab.Key.ToString());
                        break;
                    }

                case TOOLBAR_TEXTOUTPUT_KEY:
                    {
                        // �A�N�e�B�u��Ԃ̃^�u����t�H�[�����擾����
                        FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_UTabControl.ActiveTab.Key.ToString()];
                        System.Windows.Forms.Form activeForm = formControlInfo.Form;

                        if ((activeForm is ICustomTextSelectAndWriter))
                        {
                            ICustomTextSelectAndWriter interFase = activeForm as ICustomTextSelectAndWriter;

                            if (interFase == null) return;

                            // �e�L�X�g�o��
                            CustomTextProviderInfo customTextProviderInfo = new CustomTextProviderInfo();
                            interFase.SelectInfoAndMakeCustomText(null, "", "", ref customTextProviderInfo);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// �c�[���o�[�̍��ڒl�ύX�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : �c�[���o�[���ڂ̒l���ύX���ꂽ�ۂɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Main_ToolbarsManager_ToolValueChanged(object sender, Infragistics.Win.UltraWinToolbars.ToolEventArgs e)
        {
            Infragistics.Win.UltraWinToolbars.LabelTool lblTool;
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainer;
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool;


            if (e.Tool.Key == TOOLBAR_PRINTKINDCOMB_KEY)
            {
                Infragistics.Win.UltraWinToolbars.ComboBoxTool comboTool =
                  e.Tool as Infragistics.Win.UltraWinToolbars.ComboBoxTool;

                if (comboTool != null && comboTool.SelectedItem is Infragistics.Win.ValueListItem)
                {
                    Infragistics.Win.ValueListItem item = comboTool.SelectedItem as Infragistics.Win.ValueListItem;

                    int selectPrint = Convert.ToInt32(item.DataValue);

                    // �������i�����j�H
                    if (selectPrint == 2)
                    {
                        controlContainer = (Infragistics.Win.UltraWinToolbars.ControlContainerTool)Main_ToolbarsManager.Tools[TOOLBAR_PRTSUSPENDCNT_KEY];
                        if (controlContainer != null) controlContainer.SharedProps.Visible = true;

                        lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_STOPLABEL_KEY];
                        if (lblTool != null) lblTool.SharedProps.Visible = true;

                        lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_NUMBERLABEL_KEY];
                        if (lblTool != null) lblTool.SharedProps.Visible = true;
                    }
                    else
                    {
                        controlContainer = (Infragistics.Win.UltraWinToolbars.ControlContainerTool)Main_ToolbarsManager.Tools[TOOLBAR_PRTSUSPENDCNT_KEY];
                        if (controlContainer != null) controlContainer.SharedProps.Visible = false;
                        lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_STOPLABEL_KEY];
                        if (lblTool != null) lblTool.SharedProps.Visible = false;

                        lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_NUMBERLABEL_KEY];
                        if (lblTool != null) lblTool.SharedProps.Visible = false;
                    }

                    // �����ꗗ�\�i�����j
                    if (selectPrint == 1)
                    {
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Enabled = true;

                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Enabled = true;
                    }
                    else
                    {
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Enabled = false;

                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Enabled = false;
                    }
                }

                // ���[��ޕύX����
                if (this._eventDoFlag)
                {
                    // �A�N�e�B�u��Ԃ̃^�u����t�H�[�����擾����
                    FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_UTabControl.ActiveTab.Key.ToString()];
                    System.Windows.Forms.Form activeForm = formControlInfo.Form;

                    if (activeForm is ISumDemandTbsMDIChildMain)
                    {
                        int printType = 0;

                        // ���o���钠�[��ގ擾
                        Infragistics.Win.UltraWinToolbars.ComboBoxTool combboxTool =
                            Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDCOMB_KEY] as Infragistics.Win.UltraWinToolbars.ComboBoxTool;
                        if (combboxTool != null)
                        {
                            Infragistics.Win.ValueListItem item = combboxTool.SelectedItem as Infragistics.Win.ValueListItem;
                            printType = Convert.ToInt32(item.DataValue);
                        }
                        else
                        {
                            return;
                        }

                        ((ISumDemandTbsMDIChildMain)activeForm).ChangePrintType(printType);
                    }
                }
            }
        }

        /// <summary>
        /// �^�u�I���㏈��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �^�u�I����ɔ�������C�x���g�ł��B</br>
        /// <br></br>
        /// </remarks>
        private void Main_UTabControl_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            // �������H
            if (!this._eventDoFlag) return;
            if (e.Tab == null) return;

            string key = e.Tab.Key;

            // �������n�t���[���Ή��FPDF���ꊇ�\��
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

        /// <summary>
        ///	�t�H�[��������ꂽ��ɔ�������C�x���g�ł��B
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : �t�H�[��������ꂽ��ɁA�������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void PMHNB02250UA_FormClosed(object sender, FormClosedEventArgs e)
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
                        PMHNB02250UB viewFrm = info.Form as PMHNB02250UB;
                        if (viewFrm != null)
                        {
                            viewFrm.Navigate("about:blank");
                            // --- ADD m.suzuki 2010/11/02 ---------->>>>>
                            viewFrm.Close();
                            // --- ADD m.suzuki 2010/11/02 ----------<<<<<
                            viewFrm.Dispose();
                        }
                    }
                }

                // �������n�t���[���Ή��FPDF���ꊇ�\��
                // ��ڈȍ~��PDF�u���E�U�ɋ�A�h���X��ݒ�i��\�����Ă���PDF�t�@�C�������ׁj
                foreach (Form otherForm in OtherPDFPreviewFormMap.Values)
                {
                    PMHNB02250UB otherPreviewForm = otherForm as PMHNB02250UB;
                    if (otherPreviewForm == null) continue;

                    otherPreviewForm.Navigate("about:blank");
                    // --- ADD m.suzuki 2010/11/02 ---------->>>>>
                    otherPreviewForm.Close();
                    // --- ADD m.suzuki 2010/11/02 ----------<<<<<
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
        /// <br></br>
        /// </remarks>
        private void Close_menuItem_Click(object sender, System.EventArgs e)
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

        #region ���@�E�B���h�E�X�e�[�g�{�^���c�[���\�z����
        /// <summary>
        /// �E�B���h�E�X�e�[�g�{�^���c�[���\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �E�C���h�E�\�ʒu��ԃ{�^�����쐬���܂��B</br>
        /// <br></br>
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
        /// <br></br>
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
        private void ClosePDF(
            string tabKey,
            bool withDisposingPreviewForm
        )
        {
            const string EMPTY_URL = "about:blank";

            // �e���[�̃u���E�U�ɋ�A�h���X��\�������܂��B�\�����Ă���PDF�t�@�C�������ׂł��B
            if (_formControlInfoTable.ContainsKey(tabKey))
            {
                FormControlInfo info = _formControlInfoTable[tabKey] as FormControlInfo;
                if (info != null)
                {
                    PMHNB02250UB viewFrm = info.Form as PMHNB02250UB;
                    if (viewFrm != null)
                    {
                        viewFrm.Navigate(EMPTY_URL);
                        // --- UPD m.suzuki 2010/11/02 ---------->>>>>
                        //if (withDisposingPreviewForm) viewFrm.Dispose();
                        if ( withDisposingPreviewForm )
                        {
                            viewFrm.Close();
                            viewFrm.Dispose();
                        }
                        // --- UPD m.suzuki 2010/11/02 ----------<<<<<
                    }
                }
            }

            // ��ڈȍ~��PDF�u���E�U�ɋ�A�h���X��ݒ�i��\�����Ă���PDF�t�@�C�������ׁj
            if (OtherPDFPreviewFormMap.ContainsKey(tabKey))
            {
                PMHNB02250UB otherPreviewForm = OtherPDFPreviewFormMap[tabKey] as PMHNB02250UB;
                if (otherPreviewForm != null)
                {
                    otherPreviewForm.Navigate(EMPTY_URL);
                    // --- UPD m.suzuki 2010/11/02 ---------->>>>>
                    //if (withDisposingPreviewForm)  otherPreviewForm.Dispose();
                    if ( withDisposingPreviewForm )
                    {
                        otherPreviewForm.Close();
                        otherPreviewForm.Dispose();
                    }
                    // --- UPD m.suzuki 2010/11/02 ----------<<<<<
                }
            }
        }
        
        #region ���X�e�[�^�X�o�[�֏o��
        /// <summary>
        /// �X�e�[�^�X�o�[�ɏ���\�����܂��B
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void PrintStatusBar(
            object sender,
            PrintStatusBarEventArgs e
        )
        {
            this.Main_StatusBar.Panels["Text"].Text = e.Message;
        }

        #endregion  // ���X�e�[�^�X�o�[�֏o��
    }
}

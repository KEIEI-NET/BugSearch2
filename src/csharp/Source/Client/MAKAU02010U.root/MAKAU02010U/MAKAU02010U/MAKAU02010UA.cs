#define CHG20060417
#define CLR2
#define REP20060427
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;   // ADD 2008/03/09 �������n�t���[���Ή��FPDF���ꊇ�\��
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
using Broadleaf.Application.Controller.Facade;  // ADD 2008/03/18 �s��Ή�[12536]�F���쌠������̒ǉ�
using Broadleaf.Application.Controller.Util;    // ADD 2008/03/18 �s��Ή�[12536]�F���쌠������̒ǉ�
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Text;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �������[�t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������[�̃t���[���N���X�ł��B</br>
    /// <br>Programmer : 18012 Y.Sasaki</br>
    /// <br>Date       : 2005.08.08</br>
    /// <br>Update Note: 2006.04.17 Y.Sasaki</br>
    /// <br>           : �P.�o�c�e�o�͋@�\�ύX�B</br>
    /// <br>           : �Q.�P�̋N�����[�h�ˏ����\���N�����[�h�ɕύX�B</br>
    /// <br>           : �R.�o�c�e�o�́˂o�c�e�\���B</br>
    /// <br>Update Note: 2006.04.18 Y.Sasaki</br>
    /// <br>           : �P.VS2005(CLR2.0)�Ή��ɂ��ύX</br>
    /// <br>Update Note: 2006.04.27 Y.Sasaki</br>
    /// <br>           : �P.WebBrowse�R���|�[�l���g�Ή�</br>
    /// <br>Update Note: 2006.07.24 Y.Sasaki</br>
    /// <br>           : �P.�u���b�V���A�b�v�Ή�(�^�u����A�\���X�^�C���Ή�)</br>
    /// <br>Update Note: 2006.08.31 Y.Sasaki</br>
    /// <br>           : �P.�e�L�X�g�o�͑Ή�</br>
    /// <br>Update Note: 2006.09.14 Y.Sasaki</br>
    /// <br>           : �P.���o�E������̃c�[���o�[����Ή�</br>
    /// <br>Update Note: 20081 �D�c �E�l
    /// <br>           : 2007.10.15 DC.NS�p�ɕύX</br> 
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS�Ή�</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date	   : 2008.09.04</br>
    /// <br>           : </br>
    /// <br>UpdateNote :30531 ���@�r��</br>
    /// <br>           :2010.01.27  ��ʓ��͂ŏ����̕ύX���Ȃ��ꍇ�ł��ݒ������Ă���悤�C��</br>
    /// <br></br>
    /// <br>Update Note: 2010/06/23  22018 ��� ���b</br>
    /// <br>           : ����������y�[�W�w��Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2010/10/29  22018 ��� ���b</br>
    /// <br>           : PDF�o�͂������PG�I������ƃG���[�������錏�̑Ή��B(AdobeReader9�ȍ~)</br>
    /// <br>Update Note: 2011/12/02  ������</br>
    /// <br>           : redmine#8415�̑Ή��B</br>
    /// </remarks>
    public class MAKAU02010UA : System.Windows.Forms.Form
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
        private Button button1;
        private System.ComponentModel.IContainer components;
        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructor
        public MAKAU02010UA()
        {
            InitializeComponent();

            // RemotingConfiguration�̓ǂݍ���
#if !CLR2
			System.Runtime.Remoting.RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
#endif

            // �������f�[�^�A�N�Z�X�N���X�C���X�^���X��
            this._demandPrintAcs = new DemandPrintAcs();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( MAKAU02010UA ) );
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
            this.button1 = new System.Windows.Forms.Button();
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
            this._MAKAU02010UAUnpinnedTabAreaLeft.Location = new System.Drawing.Point( 0, 88 );
            this._MAKAU02010UAUnpinnedTabAreaLeft.Name = "_MAKAU02010UAUnpinnedTabAreaLeft";
            this._MAKAU02010UAUnpinnedTabAreaLeft.Owner = this.Main_DockManager;
            this._MAKAU02010UAUnpinnedTabAreaLeft.Size = new System.Drawing.Size( 0, 623 );
            this._MAKAU02010UAUnpinnedTabAreaLeft.TabIndex = 5;
            // 
            // _MAKAU02010UAUnpinnedTabAreaRight
            // 
            this._MAKAU02010UAUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._MAKAU02010UAUnpinnedTabAreaRight.Font = new System.Drawing.Font( "�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this._MAKAU02010UAUnpinnedTabAreaRight.Location = new System.Drawing.Point( 1016, 88 );
            this._MAKAU02010UAUnpinnedTabAreaRight.Name = "_MAKAU02010UAUnpinnedTabAreaRight";
            this._MAKAU02010UAUnpinnedTabAreaRight.Owner = this.Main_DockManager;
            this._MAKAU02010UAUnpinnedTabAreaRight.Size = new System.Drawing.Size( 0, 623 );
            this._MAKAU02010UAUnpinnedTabAreaRight.TabIndex = 6;
            // 
            // _MAKAU02010UAUnpinnedTabAreaTop
            // 
            this._MAKAU02010UAUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._MAKAU02010UAUnpinnedTabAreaTop.Font = new System.Drawing.Font( "�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)) );
            this._MAKAU02010UAUnpinnedTabAreaTop.Location = new System.Drawing.Point( 0, 88 );
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
            this.DataViewTabSharedControlsPage.Size = new System.Drawing.Size( 1014, 602 );
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
            this.Main_UTabControl.Location = new System.Drawing.Point( 0, 88 );
            this.Main_UTabControl.Name = "Main_UTabControl";
            this.Main_UTabControl.SharedControlsPage = this.DataViewTabSharedControlsPage;
            this.Main_UTabControl.Size = new System.Drawing.Size( 1016, 623 );
            this.Main_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.Main_UTabControl.TabIndex = 29;
            this.Main_UTabControl.TabPadding = new System.Drawing.Size( 3, 3 );
            this.Main_UTabControl.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Main_UTabControl.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            this.Main_UTabControl.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler( this.Main_UTabControl_SelectedTabChanged );
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point( 929, 34 );
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size( 75, 23 );
            this.button1.TabIndex = 34;
            this.button1.Text = "����";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler( this.button1_Click );
            // 
            // _MAKAU02010UA_Toolbars_Dock_Area_Left
            // 
            this._MAKAU02010UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU02010UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb( ((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))) );
            this._MAKAU02010UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._MAKAU02010UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU02010UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point( 0, 88 );
            this._MAKAU02010UA_Toolbars_Dock_Area_Left.Name = "_MAKAU02010UA_Toolbars_Dock_Area_Left";
            this._MAKAU02010UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size( 0, 623 );
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
            //buttonTool16.SharedProps.Caption = "�I��(&X)";  // DEL 2011/12/02 gezh redmine#8415
            // ADD 2011/12/02 gezh redmine#8415 --------------------->>>>>
            buttonTool16.SharedProps.Caption = "�I��(F1)";
            buttonTool16.SharedProps.Shortcut = Shortcut.F1;
            // ADD 2011/12/02 gezh redmine#8415 ---------------------<<<<<
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
            //buttonTool19.SharedProps.Caption = "PDF�\��(&V)";  // DEL 2011/12/02 gezh redmine#8415
            // ADD 2011/12/02 gezh redmine#8415 ---------------------------->>>>>
            buttonTool19.SharedProps.Caption = "PDF�\��(F11)";
            buttonTool19.SharedProps.Shortcut = Shortcut.F11;
            // ADD 2011/12/02 gezh redmine#8415 ----------------------------<<<<<
            buttonTool19.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            //buttonTool20.SharedProps.Caption = "���(&P)";  // DEL 2011/12/02 gezh redmine#8415
            // ADD 2011/12/02 gezh redmine#8415 ---------------------------->>>>>
            buttonTool20.SharedProps.Caption = "���(F10)";   
            buttonTool20.SharedProps.Shortcut = Shortcut.F10;
            // ADD 2011/12/02 gezh redmine#8415 ----------------------------<<<<<
            buttonTool20.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            labelTool8.SharedProps.Caption = "����ꎞ���f����";
            labelTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            controlContainerTool1.SharedProps.MaxWidth = 40;
            controlContainerTool1.SharedProps.MinWidth = 40;
            controlContainerTool1.SharedProps.Width = 41;
            labelTool9.SharedProps.Caption = "��";
            labelTool9.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            //buttonTool21.SharedProps.Caption = "PDF����ۑ�(&S)"; // DEL 2011/12/02 gezh redmine#8415
            // ADD 2011/12/02 gezh redmine#8415 ---------------------------->>>>>
            buttonTool21.SharedProps.Caption = "PDF����ۑ�(F12)";
            buttonTool21.SharedProps.Shortcut = Shortcut.F12;
            // ADD 2011/12/02 gezh redmine#8415 ----------------------------<<<<<
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
            this._MAKAU02010UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point( 1016, 88 );
            this._MAKAU02010UA_Toolbars_Dock_Area_Right.Name = "_MAKAU02010UA_Toolbars_Dock_Area_Right";
            this._MAKAU02010UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size( 0, 623 );
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
            this._MAKAU02010UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size( 1016, 88 );
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
            // MAKAU02010UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size( 8, 15 );
            this.ClientSize = new System.Drawing.Size( 1016, 734 );
            this.Controls.Add( this._MAKAU02010UAAutoHideControl );
            this.Controls.Add( this.button1 );
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
            this.Name = "MAKAU02010UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "�������n�t���[��";
            this.Load += new System.EventHandler( this.MAKAU02010UA_Load );
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler( this.MAKAU02010UA_FormClosed );
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
                        _form = new MAKAU02010UA();
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
        private const string CT_PGID = "MAKAU02010U";
        // 2008.09.09 30413 ���� ���̕ύX >>>>>>START
        //private const string MAIN_FORM_TITLE = "���������s";
        private const string MAIN_FORM_TITLE = "�����Ǘ�";
        // 2008.09.09 30413 ���� ���̕ύX <<<<<<END
        
        // �N�����[�h�萔
        private const int START_MODE_ALL = 0;			     // ���������s(ALL)
        private const int START_MODE_DEFAULT_LIST = 1;		 // �����ꗗ�\
        private const int START_MODE_DEFAULT_TOTAL = 2;		 // �������i�Ӂj
        private const int START_MODE_DEFAULT_DETAIL = 3;	 // �������׏�
        // 2007.10.15 hikita upd start ----------------------------------------------->>
        // private const int START_MODE_DEFAULT_DETAILLIST = 4; // �������׈ꗗ�\
        private const int START_MODE_DEFAULT_DETAILSLIP = 4;    // �������׏�(�`�[)
        private const int START_MODE_DEFAULT_RECEIPT = 5;       // �̎���
        // 2007.10.15 hikita upd end -------------------------------------------------<<
        
        private const int START_MODE_DEMANDLIST = 10;		 // �����ꗗ�\
        private const int START_MODE_DEMANDTOTAL = 20;		 // �������i�Ӂj
        private const int START_MODE_DEMANDDETAIL = 30;		 // �������׏�
        // 2007.10.15 hikita upd start ----------------------------------------------->>
        // private const int START_MODE_DEMANDDETAILLIST = 40;	 // �������׈ꗗ�\
        private const int START_MODE_DEMANDDETAILSLIP = 40;		 // �������׏�(�`�[)
        private const int START_MODE_DEMANDRECEIPT = 50;	     // �̎���              
        // 2007.10.15 hikita upd end -------------------------------------------------<<
        
        private Hashtable _formControlInfoTable = new Hashtable();
        private const string DOCK_NAVIGATOR = "Navigator_Tree";
        private const string DOCK_EXPLORERBAR = "Main_ExplorerBar";
        private const string NO0_DEMANDMAIN_TAB = "DEMAND_MAIN_TAB";
        private const string NO1_LISTPREVIEW_TAB = "LISTPREVIEW_TAB";
        // 2007.10.15 hikita upd start ----------------------------------------------->>
        //private const string NO2_HANDMAIN_TAB = "HANDMAIN_TAB";
        //private const string NO3_TOTALPREVIEW_TAB = "TOTALPREVIEW_TAB";
        //private const string NO3_DETAILPREVIEW_TAB = "DETAILPREVIEW_TAB";
        //private const string NO5_DETAILLISTPREVIEW_TAB = "DETAILLISTPREVIEW_TAB";
        private const string NO2_TOTALPREVIEW_TAB = "TOTALPREVIEW_TAB";
        private const string NO3_DETAILPREVIEW_TAB = "DETAILPREVIEW_TAB";
        private const string NO4_DETAILSLIPPREVIEW_TAB = "DETAILSLIPPREVIEW_TAB";
        private const string NO5_RECEIPTPREVIEW_TAB = "RECEIPTPREVIEW_TAB";
        // 2007.10.15 hikita upd end -------------------------------------------------<<

        // ADD 2009/03/10 �������n�t���[���Ή��FPDF���ꊇ�\�� ---------->>>>>
        /// <summary>������PDF�v���r���[�̃^�u����</summary>
        private const string TOTAL_PREVIEW_TAB_NAME     = "�������v���r���[";
        /// <summary>�̎���PDF�v���r���[�̃^�u����</summary>
        private const string RECEIPT_PREVIEW_TAB_NAME   = "�̎����v���r���[";
        // ADD 2009/03/10 �������n�t���[���Ή��FPDF���ꊇ�\�� ----------<<<<<

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

        private const string TOOLBAR_TEXTOUTPUT_KEY = "TextOutPut_ButtonTool";		// 2006.08.31 Y.Sasaki ADD
        // --- ADD m.suzuki 2010/06/23 ---------->>>>>
        private const string TOOLBAR_PRINTPREVIEWBUTTON_KEY = "PrintPreview_ButtonTool";
        // --- ADD m.suzuki 2010/06/23 ----------<<<<<
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region Private Members
        // �N�����[�h[0:���������[(ALL),1:�����ꗗ�\,2:�������i�Ӂj,3:�������׏�,4:�������׈ꗗ�\,5:�̎���]
#if DEBUG
        const int BILL_LIST_MODE= 1;    // �����ꗗ�\
        const int BILL_MODE     = 2;    // ������
        const int RECEIPT_MODE  = 5;    // �̎���
        // TODO:�f�o�b�O���̋N�����[�h��
        private static int _startMode = BILL_LIST_MODE;
#else
        private static int _startMode = 0;
#endif



        // ���o�����ݒ�t�H�[��
        private Form _extractionInfoForm = null;
        // �����ꗗ�p�v���r���[�t�H�[��
        private Form _listPreviewForm = null;
        // �������i�Ӂj�p�v���r���[�t�H�[��
        private Form _totalPreviewForm = null;
        // �������׏��p�v���r���[�t�H�[��
        private Form _detailPreviewForm = null;
        // �������׈ꗗ�\�t�H�[��
        private Form _detailListPreviewForm = null;
        // 2007.10.15 hikita add start --------------------------------------->>
        // �������׏��p(�`�[)�v���r���[�t�H�[��
        private Form _detailSlipPreviewForm = null;
        // �̎����t�H�[��
        private Form _receiptPreviewForm = null;
        // 2007.10.15 hikita add end -----------------------------------------<<

        // ADD 2009/03/09 �������n�t���[���Ή��FPDF���ꊇ�\�� ---------->>>>>
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
        // ADD 2009/03/09 �������n�t���[���Ή��FPDF���ꊇ�\�� ----------<<<<<

        // ADD 2009/03/18 �s��Ή�[12536]�F���쌠������̒ǉ� ---------->>>>>
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
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_EXTRACTBUTTON_KEY, ReportFrameOpeCode.Extract, false));
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_PREVIEWBUTTON_KEY, ReportFrameOpeCode.OutputPDF, false));
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_PDFSAVEBUTTON_KEY, ReportFrameOpeCode.SavePDF, false));
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_TEXTOUTPUT_KEY, ReportFrameOpeCode.OutputText, false));
            //toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_UPDATEBUTTON_KEY, ReportFrameOpeCode.OutputText, false));
            //toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_GRAPHBUTTON_KEY, ReportFrameOpeCode.ShowGraph, false));
            //toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_SETUPBUTTON_KEY, ReportFrameOpeCode.Setup, true));

            MyOpeCtrlMap[assemblyId].MyOpeCtrl.AddControlItem(this.Main_ToolbarsManager, toolButtonInfoList);

            // ���쌠���̐�����J�n
            MyOpeCtrlMap[assemblyId].MyOpeCtrl.BeginControl();
        }

        #endregion  // <���쌠������/>
        // ADD 2009/03/18 �s��Ή�[12536]�F���쌠������̒ǉ� ----------<<<<<

        private static string[] _parameter;
        private static System.Windows.Forms.Form _form = null;


        private DemandPrintAcs _demandPrintAcs = null;

        // �C�x���g�t���O
        private bool _eventDoFlag = false;
        private Hashtable _delPDFList = null;							// �폜PDF�i�[���X�g

        private PdfHistoryControl _pdfHistoryCtrl = null;				// PDF�����Ǘ����i

        private bool _isOptCmnTextOutPut = false;						// �e�L�X�g�o�̓I�v�V���� 2006.08.31 Y.Sasaki ADD
        
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
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.02.03</br>
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
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2005.08.08</br>
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

#if CHG20060417
            // �v���r���[�̃A�C�R���ݒ�            
            Infragistics.Win.UltraWinToolbars.ButtonTool pdfSaveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
            if (pdfSaveButton != null) pdfSaveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
#endif

            // >>>>> 2006.08.31 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
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
            // <<<<< 2006.08.31 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

            // �^�u�R���g���[���̐ݒ�
            this.Main_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.Main_UTabControl.InterTabSpacing = 2;
            this.Main_UTabControl.TabOrientation = Infragistics.Win.UltraWinTabs.TabOrientation.TopLeft;
            this.Main_UTabControl.Appearance.FontData.SizeInPoints = 11;
            
            //			this.ToolbarConditionSetting("");
        }

        /// <summary>
        /// �t�H�[���R���g���[���N���X�N���G�C�g����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t�H�[���R���g���[���N���X���N���G�C�g���A�f�[�^���i�[���܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2005.08.08</br>
        /// </remarks>
        private void FormControlInfoCreate()
        {
            this._formControlInfoTable.Clear();
            FormControlInfo info0 = null;
            FormControlInfo info1 = null;
            FormControlInfo info2 = null;
            FormControlInfo info3 = null;
            FormControlInfo info4 = null;
            FormControlInfo info5 = null;     // 2007.10.15 hikita add
            
            switch (_startMode)
            {
                // 2008.11.12 30413 ���� ���C���^�u�̖��̂�ύX >>>>>>START
                case START_MODE_ALL:
                case START_MODE_DEFAULT_LIST:			// �����ꗗ�\
                //case START_MODE_DEFAULT_TOTAL:			// �������i�Ӂj
                //case START_MODE_DEFAULT_DETAIL:			// �������׏�(�ڍ�)
                //case START_MODE_DEFAULT_DETAILLIST:     // �������׈ꗗ�\   // 2007.10.15 hikita del
                // 2007.10.15 hikita add start ----------------------------------------------->>
                //case START_MODE_DEFAULT_DETAILSLIP:     // �������׏�(�`�[)   
                //case START_MODE_DEFAULT_RECEIPT:        // �̎���             
                    // 2007.10.15 hikita add end -------------------------------------------------<<
                    {
                        //info0 = new FormControlInfo(NO0_DEMANDMAIN_TAB, "SFUKK06123U", "Broadleaf.Windows.Forms.SFUKK06123UA", "���������C��", IconResourceManagement.ImageList16.Images[(int)Size16_Index.MAIN]);
                        info0 = new FormControlInfo(NO0_DEMANDMAIN_TAB, "SFUKK06123U", "Broadleaf.Windows.Forms.SFUKK06123UA", "�����ꗗ�\", IconResourceManagement.ImageList16.Images[(int)Size16_Index.MAIN]);
                        this._formControlInfoTable.Add(NO0_DEMANDMAIN_TAB, info0);
                        break;
                    }
                case START_MODE_DEFAULT_TOTAL:			// ������
                    {
                        info0 = new FormControlInfo(NO0_DEMANDMAIN_TAB, "SFUKK06123U", "Broadleaf.Windows.Forms.SFUKK06123UA", "������", IconResourceManagement.ImageList16.Images[(int)Size16_Index.MAIN]);
                        this._formControlInfoTable.Add(NO0_DEMANDMAIN_TAB, info0);
                        break;
                    }
                case START_MODE_DEFAULT_RECEIPT:        // �̎���
                    {
                        info0 = new FormControlInfo(NO0_DEMANDMAIN_TAB, "SFUKK06123U", "Broadleaf.Windows.Forms.SFUKK06123UA", "�̎���", IconResourceManagement.ImageList16.Images[(int)Size16_Index.MAIN]);
                        this._formControlInfoTable.Add(NO0_DEMANDMAIN_TAB, info0);
                        break;
                    }
                // 2008.11.12 30413 ���� ���C���^�u�̖��̂�ύX <<<<<<END
                case START_MODE_DEMANDLIST:
                    {
                        info0 = new FormControlInfo(NO0_DEMANDMAIN_TAB, "SFUKK06123U", "Broadleaf.Windows.Forms.SFUKK06123UA", "�����ꗗ�\", IconResourceManagement.ImageList16.Images[(int)Size16_Index.MAIN]);
                        this._formControlInfoTable.Add(NO0_DEMANDMAIN_TAB, info0);
                        break;
                    }
                case START_MODE_DEMANDTOTAL:
                    {
                        info0 = new FormControlInfo(NO0_DEMANDMAIN_TAB, "SFUKK06123U", "Broadleaf.Windows.Forms.SFUKK06123UA", "�������i�Ӂj", IconResourceManagement.ImageList16.Images[(int)Size16_Index.MAIN]);
                        this._formControlInfoTable.Add(NO0_DEMANDMAIN_TAB, info0);
                        break;
                    }
                case START_MODE_DEMANDDETAIL:
                    {
                        info0 = new FormControlInfo(NO0_DEMANDMAIN_TAB, "SFUKK06123U", "Broadleaf.Windows.Forms.SFUKK06123UA", "�������׏�(�ڍ�)", IconResourceManagement.ImageList16.Images[(int)Size16_Index.MAIN]);
                        this._formControlInfoTable.Add(NO0_DEMANDMAIN_TAB, info0);
                        break;
                    }
                // 2007.10.15 hikita del start -------------------------------------------------------------------------->>
                //case START_MODE_DEMANDDETAILLIST:
                //    {
                //        info0 = new FormControlInfo(NO0_DEMANDMAIN_TAB, "SFUKK06123U", "Broadleaf.Windows.Forms.SFUKK06123UA", "�������׈ꗗ�\", IconResourceManagement.ImageList16.Images[(int)Size16_Index.MAIN]);
                //        this._formControlInfoTable.Add(NO0_DEMANDMAIN_TAB, info0);
                //        break;
                //    }
                // 2007.10.15 hikita add del ----------------------------------------------------------------------------<<
                // 2007.10.15 hikita add start -------------------------------------------------------------------------->>
                case START_MODE_DEMANDDETAILSLIP:
                    {
                        info0 = new FormControlInfo(NO0_DEMANDMAIN_TAB, "SFUKK06123U", "Broadleaf.Windows.Forms.SFUKK06123UA", "�������׏�(�`�[)", IconResourceManagement.ImageList16.Images[(int)Size16_Index.MAIN]);
                        this._formControlInfoTable.Add(NO0_DEMANDMAIN_TAB, info0);
                        break;
                    }
                case START_MODE_DEMANDRECEIPT:
                    {
                        info0 = new FormControlInfo(NO0_DEMANDMAIN_TAB, "SFUKK06123U", "Broadleaf.Windows.Forms.SFUKK06123UA", "�̎���", IconResourceManagement.ImageList16.Images[(int)Size16_Index.MAIN]);
                        this._formControlInfoTable.Add(NO0_DEMANDMAIN_TAB, info0);
                        break;
                    }
                // 2007.10.15 hikita add end ----------------------------------------------------------------------------<<
                default:
                    {
                        info0 = new FormControlInfo(NO0_DEMANDMAIN_TAB, "SFUKK06123U", "Broadleaf.Windows.Forms.SFUKK06123UA", "���������C��", IconResourceManagement.ImageList16.Images[(int)Size16_Index.MAIN]);
                        this._formControlInfoTable.Add(NO0_DEMANDMAIN_TAB, info0);
                        break;
                    }
            }
            
            info1 = new FormControlInfo(NO1_LISTPREVIEW_TAB, "MAKAU02010U", "Broadleaf.Windows.Forms.MAKAU02010UB", "�����ꗗ�\�v���r���[", IconResourceManagement.ImageList16.Images[(int)Size16_Index.PREVIEW]);
            this._formControlInfoTable.Add(NO1_LISTPREVIEW_TAB, info1);

            info2 = new FormControlInfo(NO2_TOTALPREVIEW_TAB, "MAKAU02010U", "Broadleaf.Windows.Forms.MAKAU02010UB", TOTAL_PREVIEW_TAB_NAME, IconResourceManagement.ImageList16.Images[(int)Size16_Index.PREVIEW]);   // MOD 2009/03/06 �������n�t���[���C�� "�������i�Ӂj�v���r���["��TOTAL_PREVIEW_NAME
            this._formControlInfoTable.Add(NO2_TOTALPREVIEW_TAB, info2);

            info3 = new FormControlInfo(NO3_DETAILPREVIEW_TAB, "MAKAU02010U", "Broadleaf.Windows.Forms.MAKAU02010UB", "�������׏�(�ڍ�)�v���r���[", IconResourceManagement.ImageList16.Images[(int)Size16_Index.PREVIEW]);
            this._formControlInfoTable.Add(NO3_DETAILPREVIEW_TAB, info3);
            // 2007.10.15 hikita del start ------------------------------------------------------------------------------->>
            //info4 = new FormControlInfo(NO5_DETAILLISTPREVIEW_TAB, "MAKAU02010U", "Broadleaf.Windows.Forms.MAKAU02010UB", "�������׏��v���r���[", IconResourceManagement.ImageList16.Images[(int)Size16_Index.PREVIEW]);
            //this._formControlInfoTable.Add(NO5_DETAILLISTPREVIEW_TAB, info4);
            // 2007.10.15 hikita del end ---------------------------------------------------------------------------------<<

            // 2007.10.15 hikita add start ------------------------------------------------------------------------------->>
            info4 = new FormControlInfo(NO4_DETAILSLIPPREVIEW_TAB, "MAKAU02010U", "Broadleaf.Windows.Forms.MAKAU02010UB", "�������׏�(�`�[)�v���r���[", IconResourceManagement.ImageList16.Images[(int)Size16_Index.PREVIEW]);
            this._formControlInfoTable.Add(NO4_DETAILSLIPPREVIEW_TAB, info4);

            info5 = new FormControlInfo(NO5_RECEIPTPREVIEW_TAB, "MAKAU02010U", "Broadleaf.Windows.Forms.MAKAU02010UB", RECEIPT_PREVIEW_TAB_NAME, IconResourceManagement.ImageList16.Images[(int)Size16_Index.PREVIEW]); // MOD 2009/03/06 �������n�t���[���C�� "�̎����v���r���["��RECEIPT_PREVIEW_NAME
            this._formControlInfoTable.Add(NO5_RECEIPTPREVIEW_TAB, info5);
            // 2007.10.15 hikita add end ---------------------------------------------------------------------------------<<
        }

        /// <summary>
        /// �^�u�N���G�C�g����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �^�u�t�H�[���𐶐����܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2005.08.08</br>
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
                        if (this._extractionInfoForm is IDemandTbsMDIChildMain)
                        {
                            ((IDemandTbsMDIChildMain)this._extractionInfoForm).Show((Object)_startMode);
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

                        // ADD 2009/03/10 �������n�t���[���Ή��FPDF���ꊇ�\�� ---------->>>>>
                        if (_startMode.Equals(START_MODE_DEFAULT_TOTAL) || _startMode.Equals(START_MODE_DEFAULT_RECEIPT))
                        {
                            // TODO:�ŋߏo�͂����ꗗ�\��PDF�\���^�u�̖��̕ύX�͂�����
                        }
                        // ADD 2009/03/10 �������n�t���[���Ή��FPDF���ꊇ�\�� ----------<<<<<

                        this._listPreviewForm = this.CreateTabForm(info);
                        if (_listPreviewForm == null) return;
                    }
                    else
                    {
                        this._listPreviewForm.Show();
                    }
                    break;
                // 2007.10.15 hikita del start ------------------------------------->>
                //case NO2_HANDMAIN_TAB:
                //    if (this._detailListPreviewForm == null)
                //    {
                //        FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
                //        if (info == null) return;

                //        this._detailListPreviewForm = this.CreateTabForm(info);
                //        if (_detailListPreviewForm == null) return;
                //    }
                //    else
                //    {
                //        this._detailListPreviewForm.Show();
                //    }
                //    break;
                // 2007.10.15 hikita del end ---------------------------------------<<
                case NO2_TOTALPREVIEW_TAB:
                    if (this._totalPreviewForm == null)
                    {
                        FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
                        if (info == null) return;

                        // ADD 2009/03/10 �������n�t���[���Ή��FPDF���ꊇ�\�� ---------->>>>>
                        // �v���r���[�^�u�𕡐��\���i������1�\���ځj
                        string originalName = info.Name;
                        if (CurrentOutputPDF.ExistsOtherPDFPreview)
                        {
                            info.Name = originalName + "1";
                        }
                        // ADD 2009/03/10 �������n�t���[���Ή��FPDF���ꊇ�\�� ----------<<<<<

                        this._totalPreviewForm = this.CreateTabForm(info);
                        if (_totalPreviewForm == null) return;
                    }
                    else
                    {
                        this._totalPreviewForm.Show();
                    }
                    break;
                case NO3_DETAILPREVIEW_TAB:
                    if (this._detailPreviewForm == null)
                    {
                        FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
                        if (info == null) return;

                        this._detailPreviewForm = this.CreateTabForm(info);
                        if (_detailPreviewForm == null) return;
                    }
                    else
                    {
                        this._detailPreviewForm.Show();
                    }
                    break;
                // 2007.10.15 hikita del start ------------------------------------->>
                //case NO5_DETAILLISTPREVIEW_TAB:
                //    if (this._detailPreviewForm == null)
                //    {
                //        FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
                //        if (info == null) return;

                //        this._detailPreviewForm = this.CreateTabForm(info);
                //        if (_detailPreviewForm == null) return;
                //    }
                //    else
                //    {
                //        this._detailPreviewForm.Show();
                //    }
                //    break;
                // 2007.10.15 hikita del end ---------------------------------------<<
                // 2007.10.15 hikita add start ------------------------------------------------------>>
                case NO4_DETAILSLIPPREVIEW_TAB:
                    if (this._detailSlipPreviewForm == null)
                    {
                        FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
                        if (info == null) return;

                        this._detailSlipPreviewForm = this.CreateTabForm(info);
                        if (_detailSlipPreviewForm == null) return;
                    }
                    else
                    {
                        this._detailSlipPreviewForm.Show();
                    }
                    break;
                case NO5_RECEIPTPREVIEW_TAB:
                    if (this._receiptPreviewForm == null)
                    {
                        FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
                        if (info == null) return;

                        // ADD 2009/03/10 �������n�t���[���Ή��FPDF���ꊇ�\�� ---------->>>>>
                        // �v���r���[�^�u�𕡐��\���i�̎���1�\���ځj
                        string originalName = info.Name;
                        if (CurrentOutputPDF.ExistsOtherPDFPreview)
                        {
                            info.Name = info.Name + "1";
                        }
                        // ADD 2009/03/10 �������n�t���[���Ή��FPDF���ꊇ�\�� ----------<<<<<

                        this._receiptPreviewForm = this.CreateTabForm(info);
                        if (_receiptPreviewForm == null) return;
                    }
                    else
                    {
                        this._receiptPreviewForm.Show();
                    }
                    break;
                // 2007.10.15 hikita add end --------------------------------------------------------<<
                default:
                    break;
            }
        }

        // ADD 2009/03/10 �������n�t���[���Ή��FPDF���ꊇ�\�� ---------->>>>>
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
                    case NO2_TOTALPREVIEW_TAB:  // ������
                        tabName = TOTAL_PREVIEW_TAB_NAME;
                        break;
                    case NO5_RECEIPTPREVIEW_TAB:// �̎���
                        tabName = RECEIPT_PREVIEW_TAB_NAME;
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
        // ADD 2009/03/10 �������n�t���[���Ή��FPDF���ꊇ�\�� ----------<<<<<

        /// <summary>
        /// �^�u�A�N�e�B�u����
        /// </summary>
        /// <param name="key">�ΏۃL�[���</param>
        /// <param name="form">�A�N�e�B�u�������t�H�[���̃C���X�^���X</param>
        /// <remarks>
        /// <br>Note       : �����̃L�[�������ɁA�^�u���A�N�e�B�u�����܂��B</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2005.07.21</br>
        /// </remarks>
        private void TabActive(string key, ref Form form)
        {
            if (this.Main_UTabControl.Tabs.Exists(key))
            {
                this.Main_UTabControl.Tabs[key].Visible = true;
                this.Main_UTabControl.SelectedTab = this.Main_UTabControl.Tabs[key];

                // DEL 2009/03/10 �������n�t���[���Ή����FPDF���ꊇ�\��
                //FormControlInfo formInfo = (FormControlInfo)this._formControlInfoTable[key];

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
        /// <br>Programer  : 18012 Y.Sasaki</br>
        /// <br>Date       : 2005.07.19</br>
        /// </remarks>
        private Form CreateTabForm(FormControlInfo info)
        {
            Form form = null;

            // �e��t�H�[���̃C���X�^���X��
            switch (info.Key)
            {
                case NO0_DEMANDMAIN_TAB:
                {
                    form = new Broadleaf.Windows.Forms.MAKAU02012UA();
                    ((MAKAU02012UA)form).SelectedPdfNodeEvent += new SelectedPdfNodeEventHandler(this.SelectedPdfView);
                    ((MAKAU02012UA)form).StatusBarInfoPrinted += new PrintStatusBar(this.PrintStatusBar);   // ADD 2009/03/03 �������n�t���[���Ή��F���_�͈͎w��̒ǉ�
                    break;
                }
                case NO1_LISTPREVIEW_TAB:
                case NO2_TOTALPREVIEW_TAB:
                case NO3_DETAILPREVIEW_TAB:
                //case NO5_DETAILLISTPREVIEW_TAB:     // 2007.10.15 hikita del
                case NO4_DETAILSLIPPREVIEW_TAB:       // 2007.10.15 hikita add   
                case NO5_RECEIPTPREVIEW_TAB:          // 2007.10.15 hikita add 
                    form = new Broadleaf.Windows.Forms.MAKAU02010UB();
                    break;

                //case NO2_HANDMAIN_TAB:
                    //form = new Broadleaf.Windows.Forms.SFUKK06129UA();
                //    break;
                default:
                    break;
            }

            // ADD 2009/03/10 �������n�t���[���Ή��FPDF���ꊇ�\�� ---------->>>>>
            // ��ڈȍ~��PDF�v���r���[�t�H�[���𐶐�
            if (form == null)
            {
                if (info.Key.Contains(NO2_TOTALPREVIEW_TAB) || info.Key.Contains(NO5_RECEIPTPREVIEW_TAB))
                {
                    form = new Broadleaf.Windows.Forms.MAKAU02010UB();
                }
            }
            // ADD 2009/03/10 �������n�t���[���Ή��FPDF���ꊇ�\�� ----------<<<<<

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

                if (form is IDemandTbsMDIChildMain)
                {
                    ((IDemandTbsMDIChildMain)form).Show((Object)_startMode);
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
        /// <br>Programer  : 18012 Y.Sasaki</br>
        /// <br>Date       : 2005.08.29</br>
        /// </remarks>
        private void SelectedPdfView(string key, string printName, string pdfpath)
        {

#if CHG20060417
            // UNDONE:�v���r���[�^�u�����@�������ꗗ�^�u���Œ�
            this.TabCreate(NO1_LISTPREVIEW_TAB);
            if (this._listPreviewForm != null)
            {
                this.TabActive(NO1_LISTPREVIEW_TAB, ref this._listPreviewForm);

                MAKAU02010UB target = this._listPreviewForm as MAKAU02010UB;

                if (target != null)
                {
                    target.IsSave = false;
                    target.PrintKey = "";
                    target.PrintName = "";
                    target.PrintDetailName = "";
                    target.PrintPDFPath = "";
#if REP20060427
                    target.Navigate((Object)pdfpath);
#else
					target.ShowPDFPreview((Object)pdfpath);
#endif
                }

                // �c�[���o�[�{�^���ݒ�
                this.ToolBarSetting(target);

            }
#else
			// �v���r���[�^�u����
      this.TabCreate(NO1_LISTPREVIEW_TAB);
      if (this._listPreviewForm != null)
      {
				((MAKAU02010UB)this._listPreviewForm).ShowPDFPreview((Object)pdfpath);
        this.TabActive(NO1_LISTPREVIEW_TAB,ref this._listPreviewForm);
			}
#endif
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
                            // �`�k�k
                            case START_MODE_ALL:
                            case START_MODE_DEFAULT_LIST:			// �����ꗗ�\
                            case START_MODE_DEFAULT_TOTAL:			// �������i�Ӂj
                            case START_MODE_DEFAULT_DETAIL:			// �������׏�
                            //case START_MODE_DEFAULT_DETAILLIST:		// �������׈ꗗ�\  // 2007.10.15 hikita del
                            case START_MODE_DEFAULT_DETAILSLIP:     // �������׏�(�`�[)    // 2007.10.15 hikita add
                            case START_MODE_DEFAULT_RECEIPT:        // �̎���              // 2007.10.15 hikita add
                                {
                                    isPrintKindComb = true;

                                    switch (_startMode)
                                    {

                                        case START_MODE_DEFAULT_LIST:			// �����ꗗ�\
                                            {
                                                combboxTool.SelectedIndex = 0;
                                                break;
                                            }
                                        case START_MODE_DEFAULT_TOTAL:			// �������i�Ӂj
                                            {
                                                combboxTool.SelectedIndex = 1;
                                                break;
                                            }
                                        case START_MODE_DEFAULT_DETAIL:			// �������׏�
                                            {
                                                combboxTool.SelectedIndex = 2;
                                                break;
                                            }
                                        // 2007.10.15 hikita del start ----------------------------------------->>
                                        //case START_MODE_DEFAULT_DETAILLIST:		// �������׈ꗗ�\
                                        //    {
                                        //        combboxTool.SelectedIndex = 3;
                                        //        break;
                                        //    }
                                        // 2007.10.15 hikita del end -------------------------------------------<<
                                        // 2007.10.15 hikita add start ----------------------------------------->>
                                        case START_MODE_DEFAULT_DETAILSLIP:
                                            {
                                                combboxTool.SelectedIndex = 3;
                                                break;
                                            }
                                        case START_MODE_DEFAULT_RECEIPT:
                                            {
                                                combboxTool.SelectedIndex = 4;
                                                break;
                                            }
                                        // 2007.10.15 hikita add end -------------------------------------------<<
                                    }
                                    break;
                                }
                            // �����ꗗ�\
                            case START_MODE_DEMANDLIST:
                                {
                                    combboxTool.SelectedIndex = 0;
                                    break;
                                }
                            //// �������i�Ӂj
                            case START_MODE_DEMANDTOTAL:
                                {
                                    combboxTool.SelectedIndex = 1;
                                    break;
                                }
                            // �������׏�
                            case START_MODE_DEMANDDETAIL:
                                {
                                    combboxTool.SelectedIndex = 2;
                                    break;
                                }
                            // 2007.10.15 hikita del start --------------------------------------------->>
                            // �������׈ꗗ�\
                            //case START_MODE_DEMANDDETAILLIST:
                            //    {
                            //        combboxTool.SelectedIndex = 3;
                            //        break;
                            //    }
                            // 2007.10.15 hikita del end -----------------------------------------------<<
                            // 2007.10.15 hikita add start --------------------------------------------->>
                            // �������׏�(�`�[)
                            case START_MODE_DEMANDDETAILSLIP:
                                {
                                    combboxTool.SelectedIndex = 3;
                                    break;
                                }
                            // �̎���
                            case START_MODE_DEMANDRECEIPT:
                                {
                                    combboxTool.SelectedIndex = 4;
                                    break;
                                }
                            // 2007.10.15 hikita add end -----------------------------------------------<<
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

                        // >>>>> 2006.08.31 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                        // �e�L�X�g�o��
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
                        // 2007.10.15 upd start ------------------------------------------------------->>
                        // if (buttonTool != null) buttonTool.SharedProps.Visible = this._isOptCmnTextOutPut;
                        // ����̓e�L�X�g�o�͋@�\�͂Ȃ�
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;
                        // 2007.10.15 upd end ---------------------------------------------------------<<
                        // <<<<< 2006.08.31 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                        // ���ݑI�𒆂̏��ނɂ��ꎞ���f�{�^���̕\����ؑւ���
                        if (combboxTool != null && combboxTool.SelectedItem is Infragistics.Win.ValueListItem)
                        {
                            Infragistics.Win.ValueListItem item = combboxTool.SelectedItem as Infragistics.Win.ValueListItem;

                            int selectPrint = Convert.ToInt32(item.DataValue);

                            // �������i�Ӂj�H
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
                //case NO2_HANDMAIN_TAB:
                //    {
                //        // ���o
                //        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                //        if (buttonTool != null) buttonTool.SharedProps.Visible = true;

                //        // ���ޑI�����x��
                //        lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDTITLE_KEY];
                //        if (lblTool != null) lblTool.SharedProps.Visible = false;

                //        // ���ޑI���R���{
                //        combboxTool = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDCOMB_KEY];
                //        if (combboxTool != null)
                //        {
                //            combboxTool.SelectedIndex = 1;
                //            combboxTool.SharedProps.Visible = false;
                //        }

                //        // �v���r���[
                //        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                //        if (buttonTool != null) buttonTool.SharedProps.Visible = false;

                //        // ���
                //        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                //        if (buttonTool != null) buttonTool.SharedProps.Visible = true;

                //        // ����ꎞ���f���x��
                //        lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_STOPLABEL_KEY];
                //        if (lblTool != null) lblTool.SharedProps.Visible = false;

                //        // ����ꎞ���f����
                //        containerTool = (Infragistics.Win.UltraWinToolbars.ControlContainerTool)Main_ToolbarsManager.Tools[TOOLBAR_PRTSUSPENDCNT_KEY];
                //        if (containerTool != null) containerTool.SharedProps.Visible = false;

                //        // ����������x��
                //        lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_NUMBERLABEL_KEY];
                //        if (lblTool != null) lblTool.SharedProps.Visible = false;

                //        // ���[�U�[�ݒ�
                //        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_USERSETUP_KEY];
                //        if (buttonTool != null) buttonTool.SharedProps.Visible = false;

                //        // PDF����ۑ�
                //        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
                //        if (buttonTool != null) buttonTool.SharedProps.Visible = false;

                //        // >>>>> 2006.08.31 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                //        // �e�L�X�g�o��
                //        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
                //        if (buttonTool != null) buttonTool.SharedProps.Visible = false;
                //        // <<<<< 2006.08.31 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
                //        break;
                //    }
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
                        // >>>>> 2006.08.31 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                        // �e�L�X�g�o��
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Visible = false;
                        // <<<<< 2006.08.31 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
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
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.04.13</br>
        /// </remarks>
        private void SavePDF(string key)
        {
            try
            {
                // ADD 2009/03/10 �������n�t���[���Ή��FPDF���ꊇ�\�� ---------->>>>>
                FormControlInfo info= null;
                MAKAU02010UB target = null;
                if (this._formControlInfoTable.Contains(key))
                {
                    // �A�N�e�B�u�^�u���璠�[�R���g���[�������擾
                    info = this._formControlInfoTable[key] as FormControlInfo;

                    // PDF�v���r���[�t�H�[��
                    if (info != null) target = info.Form as MAKAU02010UB;
                }
                else
                {
                    // ����PDF�v���r���[�p����
                    if (OtherPDFPreviewFormMap.ContainsKey(key))
                    {
                        target = OtherPDFPreviewFormMap[key] as MAKAU02010UB;
                    }
                }
                // ADD 2009/03/10 �������n�t���[���Ή��FPDF���ꊇ�\�� ----------<<<<<

                // DEL 2009/03/10 �������n�t���[���Ή��FPDF���ꊇ�\�� ---------->>>>>
                #region �폜�R�[�h
                //// �A�N�e�B�u�^�u���璠�[�R���g���[�������擾
                //FormControlInfo info = this._formControlInfoTable[key] as FormControlInfo;
                //if (info == null) return;

                //// PDF�v���r���[�t�H�[��
                //MAKAU02010UB target = info.Form as MAKAU02010UB;
                #endregion
                // DEL 2008/03/10 �������n�t���[���Ή��FPDF���ꊇ�\�� ----------<<<<<

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

                        // --- UPD m.suzuki 2010/07/22 ---------->>>>>
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
                            MAKAU02010UB wkTarget = null;
                            if ( this._formControlInfoTable.Contains( tab.Key ) )
                            {
                                wkInfo = this._formControlInfoTable[tab.Key] as FormControlInfo;
                                if ( wkInfo != null ) wkTarget = wkInfo.Form as MAKAU02010UB;
                            }
                            else
                            {
                                if ( OtherPDFPreviewFormMap.ContainsKey( tab.Key ) )
                                {
                                    wkTarget = OtherPDFPreviewFormMap[tab.Key] as MAKAU02010UB;
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
                        // --- ADD m.suzuki 2010/07/22 ----------<<<<<
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
        /// <br>Programer  : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.04.18</br>
        /// </remarks>
        private void ToolBarSetting(object activeForm)
        {
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool;
            Infragistics.Win.UltraWinToolbars.ComboBoxTool combboxTool;
            Infragistics.Win.UltraWinToolbars.ControlContainerTool containerTool;

            if (activeForm != null)
            {
                if (activeForm is IDemandTbsMDIChildMain)
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
                            case START_MODE_ALL:			// �`�k�k
                            case START_MODE_DEFAULT_LIST:			// �����ꗗ�\
                            case START_MODE_DEFAULT_TOTAL:			// �������i�Ӂj
                            case START_MODE_DEFAULT_DETAIL:			// �������׏�
                            // case START_MODE_DEFAULT_DETAILLIST:		// �������׈ꗗ�\  // 2007.10.15 hikita del
                            case START_MODE_DEFAULT_DETAILSLIP:		// �������׏�(�`�[)    // 2007.10.15 hikita add
                            case START_MODE_DEFAULT_RECEIPT:        // �̎���              // 2007.10.15 hikita add
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

                        // �������i�Ӂj�H
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

                        // �����ꗗ�\
                        if (selectPrint == 1)
                        {
                            // PDF�\��
                            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                            if (buttonTool != null)
                            {
                                buttonTool.SharedProps.Enabled = true;
                            }

                            // >>>>> 2006.08.31 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
                            if (buttonTool != null) buttonTool.SharedProps.Enabled = true;
                            // <<<<< 2006.08.31 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
                        }
                        // �������i�Ӂj�E�������׏�
                        else
                        {
                            // PDF�\��
                            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                            if (buttonTool != null)
                            {
                                // DEL 2009/03/03 �������n�t���[���Ή����FPDF�\���{�^����L��
                                // buttonTool.SharedProps.Enabled = false;
                                buttonTool.SharedProps.Enabled = true;  // ADD 2009/03/03 �������n�t���[���Ή��FPDF�\���{�^����L��
                            }

                            // >>>>> 2006.08.31 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
                            if (buttonTool != null) buttonTool.SharedProps.Enabled = false;
                            // <<<<< 2006.08.31 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
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

                }   // if (activeForm is IDemandTbsMDIChildMain)
                else if (activeForm is MAKAU02010UB)
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
                        MAKAU02010UB target = activeForm as MAKAU02010UB;
                        if (target != null)
                        {
                            buttonTool.SharedProps.Enabled = target.IsSave;
                        }
                    }

                    // >>>>> 2006.08.31 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
                    if (buttonTool != null) buttonTool.SharedProps.Enabled = false;
                    // <<<<< 2006.08.31 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
                }   // else if (activeForm is MAKAU02010UB)
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

                // >>>>> 2006.08.31 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
                if (buttonTool != null) buttonTool.SharedProps.Enabled = false;
                // <<<<< 2006.08.31 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
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
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.02.02</br>
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
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2005.08.08</br>
        /// </remarks>
        private void MAKAU02010UA_Load(object sender, System.EventArgs e)
        {
            // ������ʐݒ�
            this.InitialScreenSetting();

            // �^�C�g���ݒ�
            this.Text = MAIN_FORM_TITLE;

            switch (_startMode)
            {
                case START_MODE_ALL:
                // 2008.10.22 30413 ���� �N���p�����[�^�ɂ��^�C�g���ύX >>>>>>START
                //case START_MODE_DEFAULT_LIST:			// �����ꗗ�\
                //case START_MODE_DEFAULT_TOTAL:			// �������i�Ӂj
                //case START_MODE_DEFAULT_DETAIL:			// �������׏�
                //// case START_MODE_DEFAULT_DETAILLIST:		// �������׈ꗗ�\   // 2007.10.15 hikita del
                //case START_MODE_DEFAULT_DETAILSLIP:		// �������׏�(�`�[)     // 2007.10.15 hikita add 
                //case START_MODE_DEFAULT_RECEIPT:        // �̎���               // 2007.10.15 hikita add 
                case START_MODE_DEFAULT_LIST:			// �����ꗗ�\
                    this.Text = MAIN_FORM_TITLE + " - " + "�����ꗗ�\";
                    break;
                case START_MODE_DEFAULT_TOTAL:			// ������
                    this.Text = MAIN_FORM_TITLE + " - " + "������";
                    break;
                case START_MODE_DEFAULT_RECEIPT:        // �̎���
                    this.Text = MAIN_FORM_TITLE + " - " + "�̎���";
                    break;
                case START_MODE_DEFAULT_DETAIL:			// �������׏�
                // case START_MODE_DEFAULT_DETAILLIST:		// �������׈ꗗ�\   // 2007.10.15 hikita del
                case START_MODE_DEFAULT_DETAILSLIP:		// �������׏�(�`�[)     // 2007.10.15 hikita add 
                    this.Text = MAIN_FORM_TITLE;
                    break;
                // 2008.10.22 30413 ���� �N���p�����[�^�ɂ��^�C�g���ύX <<<<<<END
                case START_MODE_DEMANDLIST:
                    this.Text = MAIN_FORM_TITLE + " - " + "�����ꗗ�\";
                    break;
                case START_MODE_DEMANDTOTAL:
                    this.Text = MAIN_FORM_TITLE + " - " + "�������i�Ӂj";
                    break;
                case START_MODE_DEMANDDETAIL:
                    this.Text = MAIN_FORM_TITLE + " - " + "�������׏�(�ڍ�)";
                    break;
                // 2007.10.15 hikita del start --------------------------------->>
                //case START_MODE_DEMANDDETAILLIST:
                //    this.Text = MAIN_FORM_TITLE + " - " + "�������׈ꗗ�\";
                //    break;
                // 2007.10.15 hikita del end -----------------------------------<<
                // 2007.10.15 hikita add start --------------------------------->>
                case START_MODE_DEMANDDETAILSLIP:
                    this.Text = MAIN_FORM_TITLE + " - " + "�������׏�(�`�[)";
                    break;
                case START_MODE_DEMANDRECEIPT:
                    this.Text = MAIN_FORM_TITLE + " - " + "�̎���";
                    break;
                // 2007.10.15 hikita add end -----------------------------------<<
                default:
                    this.Text = MAIN_FORM_TITLE;
                    break;
            }

            //// �c�[���o�[�̏����ݒ�
            //if (startMode == START_MODE_DEFAULT_DETAILLIST)
            //{
            //    this.ToolbarConditionSetting(NO2_HANDMAIN_TAB);
            //}
            //else
            //{
                this.ToolbarConditionSetting(NO0_DEMANDMAIN_TAB);
            //}

                // �E�C���h�E�{�^���쐬����
                this.CreateWindowStateButtonTools();

            this.Initial_Timer.Enabled = true;

        #if DEBUG
            this.button1.Visible = true;
        #endif
        }

        /// <summary>
        /// ���������^�C�}�[�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : �����^�C�}�[�C�x���g�ł��B</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2005.08.08</br>
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

                // 2008.09.05 30413 ���� �폜���� >>>>>>START
                //// ���f�����擾�@
                //if (this._demandPrintAcs.BillPrtStData != null)
                //{
                //    this.PrtSuspendCnt_tNedit.SetInt(this._demandPrintAcs.BillPrtStData.BillPrtSuspendCnt);
                //}
                // 2008.09.05 30413 ���� �폜���� <<<<<<END
                
                // ���C����ʋN��
                //// �������׈ꗗ�\
                //if (startMode == START_MODE_DEFAULT_DETAILLIST)
                //{
                //    this.TabCreate(NO2_HANDMAIN_TAB);
                //}
                //// ���̑�������
                //else
                //{
                    this.TabCreate(NO0_DEMANDMAIN_TAB);
                //}

                // �^�u���A�N�e�B�u�ɁI    
                // �A�N�e�B�u��Ԃ̃^�u����t�H�[�����擾����
                FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_UTabControl.ActiveTab.Key.ToString()];
                System.Windows.Forms.Form form = formControlInfo.Form;

                //if (startMode == START_MODE_DEFAULT_DETAILLIST)
                //{
                //    this.TabActive(NO2_HANDMAIN_TAB, ref form);
                //}
                //else
                //{
                this.TabActive(NO0_DEMANDMAIN_TAB, ref form);
                //}

                // �N�����[�h = �u�S���[�v���A���ޑI���̏����l���ꗗ�\��
                if (_startMode == START_MODE_ALL)
                {
                    // ���ޑI���R���{
                    Infragistics.Win.UltraWinToolbars.ComboBoxTool combboxTool = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDCOMB_KEY];
                    if (combboxTool != null)
                    {
                        combboxTool.SelectedIndex = 0;
                    }
                }
                
                // �c�[���o�[�����ݒ�
                this.ToolBarSetting(form);

                // ADD 2009/03/18 �s��Ή�[12536]�F���쌠������̒ǉ� ---------->>>>>
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
                // ADD 2009/03/18 �s��Ή�[12536]�F���쌠������̒ǉ� ----------<<<<<
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
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2005.08.08</br>
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

                        if (activeForm is IDemandTbsMDIChildMain)
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
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "MAKAU02010UA", "������钠�[��I�����ĉ������B", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                return;
                            }

                            // >>>>> 2006.09.14 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                            // ��ʓ��̓`�F�b�N
                            this.Main_ToolbarsManager.Enabled = false;
                            try
                            {
                                // --- DEL  ���r��  2010/01/27 ---------->>>>>
                                //if (((IDemandTbsMDIChildMain)activeForm).ScreenInputCheck())
                                // --- DEL  ���r��  2010/01/27 ----------<<<<<
                                {
                                    ((IDemandTbsMDIChildMain)activeForm).ExtractData(printType);
                                }
                            }
                            finally
                            {
                                this.Main_ToolbarsManager.Enabled = true;
                            }
                            //// ��ʓ��̓`�F�b�N
                            //if (((IDemandTbsMDIChildMain)activeForm).ScreenInputCheck())
                            //{
                            //  ((IDemandTbsMDIChildMain)activeForm).ExtractData(printType);
                            //}
                            // <<<<< 2006.09.14 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
                        }
                        break;
                    }

#if CHG20060417
                case TOOLBAR_PREVIEWBUTTON_KEY: // �v���r���[
                case TOOLBAR_PRINTBUTTON_KEY: // ���
                // --- ADD m.suzuki 2010/06/23 ---------->>>>>
                case TOOLBAR_PRINTPREVIEWBUTTON_KEY: // ����v���r���[
                // --- ADD m.suzuki 2010/06/23 ----------<<<<<
                    {
                        // ADD 2009/03/03 �������n�t���[���Ή��F����O�Ɋm�F�_�C�A���O�\�� ---------->>>>>
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
                        // ADD 2008/03/03 �������n�t���[���Ή��F����O�Ɋm�F�_�C�A���O�\�� ----------<<<<<

                        // �A�N�e�B�u��Ԃ̃^�u����t�H�[�����擾����
                        FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_UTabControl.ActiveTab.Key.ToString()];
                        System.Windows.Forms.Form activeForm = formControlInfo.Form;

                        if ((activeForm is IDemandTbsMDIChildMain))
                        {
                            SFCMN06002C printInfo = new SFCMN06002C();
                            printInfo.pdfopen = false;
                            printInfo.pdftemppath = "";

                            // ADD 2009/03/06 �������n�t���[���Ή� ---------->>>>>
                            // �����ꗗ�\�ȊO�̓_�C�A���O���䂪�����̂ŁA��Ɂu0:�v���r���[�Ȃ��v
                            if ( !_startMode.Equals( START_MODE_DEFAULT_LIST ) )
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
                            // ADD 2009/03/06 �������n�t���[���Ή� ----------<<<<<

                            // ������钠�[��ގ擾
                            Infragistics.Win.UltraWinToolbars.ComboBoxTool combboxTool =
                                Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDCOMB_KEY] as Infragistics.Win.UltraWinToolbars.ComboBoxTool;
                            if (combboxTool != null)
                            {
                                Infragistics.Win.ValueListItem item = combboxTool.SelectedItem as Infragistics.Win.ValueListItem;
                                printInfo.PrintPaperSetCd = Convert.ToInt32(item.DataValue);

                                // �������i�Ӂj��
                                if (printInfo.PrintPaperSetCd == 2)
                                {
                                    // DEL 2009/03/03 �������n�t���[���Ή��F����ꎞ���f�����̔p�~ ---------->>>>>
                                    //// �ꎞ���f�����ݒ�
                                    //printInfo.PcardPrtSuspendcnt = PrtSuspendCnt_tNedit.GetInt();
                                    // DEL 2008/03/03 �������n�t���[���Ή��F����ꎞ���f�����̔p�~ ----------<<<<<
                                }
                            }
                            else
                            {
                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "MAKAU02010UA", "������钠�[��I�����ĉ������B", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
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

                                    // 2008.11.11 30413 ���� ��������"����"�̒��[��ǉ� >>>>>>START
                                    //if (printInfo.PrintPaperSetCd == 1)		// �����ꗗ�\��
                                    if ((printInfo.PrintPaperSetCd == 1) || (printInfo.PrintPaperSetCd == 6))	// �����ꗗ�\��
                                    // 2008.11.11 30413 ���� ��������"����"�̒��[��ǉ� <<<<<<END
                                    {
                                        // �������
                                        printMode = (int)emPrintMode.emPrinterAndPDF;
                                    }
                                    else																	// �������i�Ӂj�E�������׏�
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

                            IDemandTbsMDIChildMain interFase = activeForm as IDemandTbsMDIChildMain;

                            // TODO ����O�`�F�b�N���s��

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
                                            // ADD 2009/03/09 �������n�t���[���Ή��FPDF���ꊇ�\�� ---------->>>>>
                                            else
                                            {
                                                CurrentOutputPDF = null;
                                                return; // PDF����������Ă��Ȃ��ꍇ�A�����I��
                                            }

                                            // ���݂̏o��PDF�����X�V
                                            if (activeForm is MAKAU02012UA)
                                            {
                                                CurrentOutputPDF = ((MAKAU02012UA)activeForm).OutputPDF;
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
                                            // ADD 2009/03/09 �������n�t���[���Ή��FPDF���ꊇ�\�� ----------<<<<<

                                            if (printInfo.pdfopen)
                                            {
                                                Form frm = null;
                                                MAKAU02010UB target = null;


                                                string key = "";

                                                switch (printInfo.PrintPaperSetCd)
                                                {
                                                    case 1: // �����ꗗ�\
                                                    case 6: // �����ꗗ�\(��������F����)
                                                        // �v���r���[�^�u����
                                                        this.TabCreate(NO1_LISTPREVIEW_TAB);
                                                        if (this._listPreviewForm != null)
                                                        {
                                                            frm = this._listPreviewForm;
                                                            target = frm as MAKAU02010UB;
                                                            key = NO1_LISTPREVIEW_TAB;

                                                            // �E�C���h�E�{�^���쐬����
                                                            this.CreateWindowStateButtonTools();
                                                        }
                                                        break;
                                                    case 2: // �������i�Ӂj���߁A������
                                                        // �v���r���[�^�u����
                                                        this.TabCreate(NO2_TOTALPREVIEW_TAB);
                                                        if (this._totalPreviewForm != null)
                                                        {
                                                            frm = this._totalPreviewForm;
                                                            target = frm as MAKAU02010UB;
                                                            key = NO2_TOTALPREVIEW_TAB;
                                                        }

                                                        // ADD 2009/03/10 �������n�t���[���Ή��FPDF���ꊇ�\�� ---------->>>>>
                                                        // TODO:�y�������z�\���pPDF�̐����A�^�u��ǉ�
                                                        if (activeForm is MAKAU02012UA)
                                                        {
                                                            if (CurrentOutputPDF.ExistsOtherPDFPreview)
                                                            {
                                                                for (int i = 1; i < CurrentOutputPDF.PreviewPDFPathList.Count; i++)
                                                                {
                                                                    AddOtherPDFPreviewTab(NO2_TOTALPREVIEW_TAB, i);
                                                                }
                                                            }
                                                        }
                                                        // ADD 2009/03/10 �������n�t���[���Ή��FPDF���ꊇ�\�� ----------<<<<<

                                                        break;

                                                    case 3: // �������׏�
                                                        // �v���r���[�^�u����
                                                        this.TabCreate(NO3_DETAILPREVIEW_TAB);
                                                        if (this._detailPreviewForm != null)
                                                        {
                                                            frm = this._detailPreviewForm;
                                                            target = frm as MAKAU02010UB;
                                                            key = NO3_DETAILPREVIEW_TAB;
                                                        }
                                                        break;
                                                    case 4: // �������׈ꗗ�\
                                                        // �v���r���[�^�u����
                                                        // 2007.10.15 hikita upd start ------------------------------->>
                                                        //this.TabCreate(NO3_DETAILPREVIEW_TAB);
                                                        //if (this._detailPreviewForm != null)      
                                                        //{
                                                        //  frm = this._detailPreviewForm;
                                                        //    target = frm as MAKAU02010UB;
                                                        //  key = NO3_DETAILPREVIEW_TAB;
                                                        //}
                                                        //break;
                                                        this.TabCreate(NO4_DETAILSLIPPREVIEW_TAB);
                                                        if (this._detailSlipPreviewForm != null)
                                                        {
                                                            frm = this._detailSlipPreviewForm;
                                                            target = frm as MAKAU02010UB;
                                                            key = NO4_DETAILSLIPPREVIEW_TAB;
                                                        }
                                                        break;
                                                    // 2007.10.15 hikita upd end ---------------------------------<<
                                                    // 2007.10.15 hikita add start ----------------------------------->>
                                                    case 5: // �̎���
                                                        // �v���r���[�^�u����
                                                        this.TabCreate(NO5_RECEIPTPREVIEW_TAB);
                                                        if (this._receiptPreviewForm != null)
                                                        {
                                                            frm = this._receiptPreviewForm;
                                                            target = frm as MAKAU02010UB;
                                                            key = NO5_RECEIPTPREVIEW_TAB;
                                                        }

                                                        // ADD 2009/03/10 �������n�t���[���Ή��FPDF���ꊇ�\�� ---------->>>>>
                                                        // TODO:�y�̎����z�\���pPDF�̐����A�^�u��ǉ�
                                                        if (activeForm is MAKAU02012UA)
                                                        {
                                                            if (CurrentOutputPDF.ExistsOtherPDFPreview)
                                                            {
                                                                for (int i = 1; i < CurrentOutputPDF.PreviewPDFPathList.Count; i++)
                                                                {
                                                                    AddOtherPDFPreviewTab(NO5_RECEIPTPREVIEW_TAB, i);
                                                                }
                                                            }
                                                        }
                                                        // ADD 2009/03/10 �������n�t���[���Ή��FPDF���ꊇ�\�� ----------<<<<<

                                                        break;
                                                    // 2007.10.15 hikita add end -------------------------------------<< 
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
#if REP20060427
                                                    target.Navigate(printInfo.pdftemppath);
#else
											target.ShowPDFPreview(printInfo.pdftemppath);
#endif
                                                    // ADD 2009/03/10 �������n�t���[���Ή��FPDF���ꊇ�\�� ---------->>>>>
                                                    if (CurrentOutputPDF.ExistsOtherPDFPreview)
                                                    {
                                                        // ��ڈȍ~��PDF��\��
                                                        string originalKey = key;

                                                        for (int i = 1; i < CurrentOutputPDF.PreviewPDFPathList.Count; i++)
                                                        {
                                                            string otherKey = GetOtherPDFPreviewFormKey(originalKey, i);
                                                            MAKAU02010UB otherTarget = OtherPDFPreviewFormMap[otherKey] as MAKAU02010UB;
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
                                                    // ADD 2009/03/10 �������n�t���[���Ή��FPDF���ꊇ�\�� ----------<<<<<

                                                    this.TabActive(key, ref frm);
                                                }

                                                // �c�[���o�[�{�^���ݒ�
                                                this.ToolBarSetting(frm);
                                            }
                                        }
                                        break;
                                    }   // case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
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
#else
				case TOOLBAR_PREVIEWBUTTON_KEY: // �v���r���[
        case TOOLBAR_PRINTBUTTON_KEY  : // ���     
        {
          int printMode = 0;
          switch (e.Tool.Key)
          {
            case TOOLBAR_PRINTBUTTON_KEY   :
              // �ʏ���
              printMode = 1;
              break;
            case TOOLBAR_PREVIEWBUTTON_KEY :
              // �o�c�e�o��
              printMode = 2;
              break;
            default:
              break;
          }
                    
          // �A�N�e�B�u��Ԃ̃^�u����t�H�[�����擾����
          FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_UTabControl.ActiveTab.Key.ToString()];
          System.Windows.Forms.Form activeForm = formControlInfo.Form;
                    
          if ((activeForm is IDemandTbsMDIChildMain))
          {
            SFCMN06002C printInfo     = new SFCMN06002C();
            printInfo.printmode       = printMode;
                        
            // ������钠�[��ގ擾
            Infragistics.Win.UltraWinToolbars.ComboBoxTool combboxTool = 
              Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDCOMB_KEY] as Infragistics.Win.UltraWinToolbars.ComboBoxTool;
            if (combboxTool != null)
            {
              Infragistics.Win.ValueListItem item = combboxTool.SelectedItem as Infragistics.Win.ValueListItem;
              printInfo.PrintPaperSetCd = Convert.ToInt32(item.DataValue);
                            
              // �������i�Ӂj��
              if (printInfo.PrintPaperSetCd == 2)
              {
                // �ꎞ���f�����ݒ�
                printInfo.PcardPrtSuspendcnt = PrtSuspendCnt_tNedit.GetInt();
              }
            } 
            else 
            {
							TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "MAKAU02010UA","������钠�[��I�����ĉ������B",0,MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
              return;                        
            }
                        
            IDemandTbsMDIChildMain interFase = activeForm as IDemandTbsMDIChildMain;  
                        
            // TODO ����O�`�F�b�N���s��
                        
                        
            Object parameter = (Object)printInfo;
            int status = interFase.Print(ref parameter);

            // �o�c�e�o�͏ꍇ�̂�
            if (printMode == 2)
            {
              if (status == 0 && printInfo.pdfopen)
              {
                                
                switch (printInfo.PrintPaperSetCd)
                {
                  case 1: // �����ꗗ�\
                    // �v���r���[�^�u����
                    this.TabCreate(NO1_LISTPREVIEW_TAB);
                    if (this._listPreviewForm != null)
                    {
                      ((MAKAU02010UB)this._listPreviewForm).ShowPDFPreview((Object)((SFCMN06002C)parameter).pdftemppath);
                      this.TabActive(NO1_LISTPREVIEW_TAB,ref this._listPreviewForm);
                    }
                    break;
                 
									case 2: // �������i�Ӂj
										// �v���r���[�^�u����
										this.TabCreate(NO3_TOTALPREVIEW_TAB);
										if (this._totalPreviewForm != null)
										{
											((MAKAU02010UB)this._totalPreviewForm).ShowPDFPreview((Object)((SFCMN06002C)parameter).pdftemppath);
											this.TabActive(NO3_TOTALPREVIEW_TAB,ref this._totalPreviewForm);
										}
										break;
									
									case 3: // �������׏�
										// �v���r���[�^�u����
										this.TabCreate(NO4_DETAILPREVIEW_TAB);
										if (this._detailPreviewForm != null)
										{
											((MAKAU02010UB)this._detailPreviewForm).ShowPDFPreview((Object)((SFCMN06002C)parameter).pdftemppath);
											this.TabActive(NO4_DETAILPREVIEW_TAB,ref this._detailPreviewForm);
										}
										break;
									
									default:
                    break;
                }
              }
            }
          }
          break;
        }
#endif
                case TOOLBAR_USERSETUP_KEY:
                    {
                        break;
                    }

                case TOOLBAR_PDFSAVEBUTTON_KEY:
                    {
                        this.SavePDF(this.Main_UTabControl.ActiveTab.Key.ToString());
                        break;
                    }

                // >>>>> 2006.08.31 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
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
                // <<<<< 2006.08.31 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
            }
        }

        /// <summary>
        /// �c�[���o�[�̍��ڒl�ύX�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : �c�[���o�[���ڂ̒l���ύX���ꂽ�ۂɔ������܂��B</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2005.08.08</br>
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

                    // �������i�Ӂj�H
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

                    // �����ꗗ�\
                    if (selectPrint == 1)
                    {
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Enabled = true;

                        // >>>>> 2006.08.31 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Enabled = true;
                        // <<<<< 2006.08.31 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
                    }
                    // �������i�Ӂj�E�������׏�
                    else
                    {
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Enabled = false;

                        // >>>>> 2006.08.31 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
                        if (buttonTool != null) buttonTool.SharedProps.Enabled = false;
                        // <<<<< 2006.08.31 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
                    }
                }

                // ���[��ޕύX����
                if (this._eventDoFlag)
                {
                    // �A�N�e�B�u��Ԃ̃^�u����t�H�[�����擾����
                    FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_UTabControl.ActiveTab.Key.ToString()];
                    System.Windows.Forms.Form activeForm = formControlInfo.Form;

                    if (activeForm is IDemandTbsMDIChildMain)
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

                        ((IDemandTbsMDIChildMain)activeForm).ChangePrintType(printType);
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
        /// <br>Programer  : 18012 Y.Sasaki</br>
        /// <br>Date       : 2005.10.07</br>
        /// </remarks>
        private void Main_UTabControl_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            // �������H
            if (!this._eventDoFlag) return;
#if CHG20060417
            if (e.Tab == null) return;

            // DEL 2009/03/10 �������n�t���[���Ή��F���_�͈͎w��̒ǉ� ---------->>>>>
            //if (!this._formControlInfoTable.Contains(e.Tab.Key))
            //{
            //    return;
            //}
            // DEL 2008/03/10 �������n�t���[���Ή��F���_�͈͎w��̒ǉ� ----------<<<<<

            string key = e.Tab.Key;

            // DEL 2009/03/10 �������n�t���[���Ή��F���_�͈͎w��̒ǉ� ---------->>>>>
            //FormControlInfo info = this._formControlInfoTable[key] as FormControlInfo;
            //Form target = info.Form;
            //this.TabActive(key, ref target);
            //this.ToolBarSetting(target);
            // DEL 2008/03/10 �������n�t���[���Ή��F���_�͈͎w��̒ǉ� ----------<<<<<
            // ADD 2009/03/10 �������n�t���[���Ή��FPDF���ꊇ�\�� ---------->>>>>
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
            // ADD 2009/03/10 �������n�t���[���Ή��FPDF���ꊇ�\�� ----------<<<<<
#else
			ToolbarConditionSetting(e.Tab.Key.ToString());
#endif
        }

        /// <summary>
        ///	�t�H�[��������ꂽ��ɔ�������C�x���g�ł��B
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : �t�H�[��������ꂽ��ɁA�������܂��B</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2006.09.12</br>
        /// </remarks>
        private void MAKAU02010UA_FormClosed(object sender, FormClosedEventArgs e)
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
                        MAKAU02010UB viewFrm = info.Form as MAKAU02010UB;
                        if (viewFrm != null)
                        {
                            viewFrm.Navigate("about:blank");
                            // --- ADD m.suzuki 2010/10/29 ---------->>>>>
                            viewFrm.Close();
                            // --- ADD m.suzuki 2010/10/29 ----------<<<<<
                            viewFrm.Dispose();
                        }
                    }
                }

                // ADD 2009/03/10 �������n�t���[���Ή��FPDF���ꊇ�\�� ---------->>>>>
                // ��ڈȍ~��PDF�u���E�U�ɋ�A�h���X��ݒ�i��\�����Ă���PDF�t�@�C�������ׁj
                foreach (Form otherForm in OtherPDFPreviewFormMap.Values)
                {
                    MAKAU02010UB otherPreviewForm = otherForm as MAKAU02010UB;
                    if (otherPreviewForm == null) continue;

                    otherPreviewForm.Navigate("about:blank");
                    // --- ADD m.suzuki 2010/10/29 ---------->>>>>
                    otherPreviewForm.Close();
                    // --- ADD m.suzuki 2010/10/29 ----------<<<<<
                    otherPreviewForm.Dispose();
                }
                // ADD 2009/03/10 �������n�t���[���Ή��FPDF���ꊇ�\�� ----------<<<<<

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
                                CurrentOutputPDF.DeleteFiles(wkEntry.Value.ToString()); // ADD 2008/03/09 �������n�t���[���Ή��FPDF���ꊇ�\��
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
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2006.03.28</br>
        /// </remarks>
        private void Close_menuItem_Click(object sender, System.EventArgs e)
        {
            if (this.Main_UTabControl.ActiveTab == null) return;

            string key = this.Main_UTabControl.ActiveTab.Key;

            // �^�u�\���ύX
            this.TabVisibleChange(key, false);

            // �E�B���h�E�X�e�[�g�{�^���c�[���\�z����
            this.CreateWindowStateButtonTools();

            // >>>>> 2007.06.29 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
            if (this.Main_UTabControl.Tabs.Count == 0)
            {
                this.ToolBarSetting(null);
            }
            else
            {
                this.ToolBarSetting(this.Main_UTabControl.ActiveTab);
            }
            // <<<<< 2007.06.29 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
        }

        #region ���@�E�B���h�E�X�e�[�g�{�^���c�[���\�z����
        /// <summary>
        /// �E�B���h�E�X�e�[�g�{�^���c�[���\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �E�C���h�E�\�ʒu��ԃ{�^�����쐬���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.11.19</br>
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
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.03.28</br>
        /// </remarks>
        private void TabVisibleChange(string key, bool visible)
        {
            for (int i = 0; i < this.Main_UTabControl.Tabs.Count; i++)
            {
                Infragistics.Win.UltraWinTabControl.UltraTab tab = this.Main_UTabControl.Tabs[i];

                if (tab.Key == key)
                {
                    tab.Visible = visible;
                    //this.NodeSelectChaneg(key, visible);

                    if (!visible) ClosePDF(key, false); // ADD 2009/03/10 �������n�t���[���Ή��FPDF���ꊇ�\��
                }
            }
        }
        #endregion

        // ADD 2009/03/10 �������n�t���[���Ή��FPDF���ꊇ�\�� ---------->>>>>
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
                    MAKAU02010UB viewFrm = info.Form as MAKAU02010UB;
                    if (viewFrm != null)
                    {
                        viewFrm.Navigate(EMPTY_URL);
                        // --- UPD m.suzuki 2010/10/29 ---------->>>>>
                        //if (withDisposingPreviewForm) viewFrm.Dispose();
                        if ( withDisposingPreviewForm )
                        {
                            viewFrm.Close();
                            viewFrm.Dispose();
                        }
                        // --- UPD m.suzuki 2010/10/29 ----------<<<<<
                    }
                }
            }

            // ��ڈȍ~��PDF�u���E�U�ɋ�A�h���X��ݒ�i��\�����Ă���PDF�t�@�C�������ׁj
            if (OtherPDFPreviewFormMap.ContainsKey(tabKey))
            {
                MAKAU02010UB otherPreviewForm = OtherPDFPreviewFormMap[tabKey] as MAKAU02010UB;
                if (otherPreviewForm != null)
                {
                    otherPreviewForm.Navigate(EMPTY_URL);
                    // --- UPD m.suzuki 2010/10/29 ---------->>>>>
                    //if (withDisposingPreviewForm)  otherPreviewForm.Dispose();
                    if ( withDisposingPreviewForm )
                    {
                        otherPreviewForm.Close();
                        otherPreviewForm.Dispose();
                    }
                    // --- UPD m.suzuki 2010/10/29 ----------<<<<<
                }
            }
            
        }
        // ADD 2009/03/10 �������n�t���[���Ή��FPDF���ꊇ�\�� ----------<<<<<

        // ADD 2009/03/03 �������n�t���[���Ή��F���_�͈͎w��̒ǉ� ---------->>>>>
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

        /// <summary>
        /// �����{�^����Click�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void button1_Click(object sender, EventArgs e)
        {
            //this.Main_UTabControl.Focus();
            //this.Main_UTabControl.ActiveTab.Visible = false;
            this.Main_UTabControl.Tabs[NO2_TOTALPREVIEW_TAB + ",1"].Visible = true;
        }
        // ADD 2008/03/03 �������n�t���[���Ή��F���_�͈͎w��̒ǉ� ----------<<<<<
    }
}

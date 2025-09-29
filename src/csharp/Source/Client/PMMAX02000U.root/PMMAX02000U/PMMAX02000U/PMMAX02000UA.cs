//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �o�i�E���ח\��
// �v���O�����T�v   : �o�i�E���ח\�� �t���[���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11270001-00  �쐬�S�� : ���O
// �� �� �� : 2016/01/21  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11270001-00  �쐬�S�� : �v��
// �� �� �� : 2016/02/17   �C�����e : Redmine#48629�̏�Q�ꗗNo.17�@�I���{�^������̏�Q�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11270001-00  �쐬�S�� : �e�c ���V
// �� �� �� : 2016/02/24   �C�����e : �B�S�̔z�M��Q�ꗗ��231  ���iMAX�o�^���ɉ�ʂ��I���ł��Ă��܂���Q�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Facade;
using Broadleaf.Application.Controller.Util;

using Broadleaf.Application.Common;
using Infragistics.Win.UltraWinTabControl;
using System.Configuration;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �o�i�E���ח\��t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �o�i�E���ח\��̃t���[���N���X�ł��B</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2016/01/21</br>
    /// <br>UpdateNote : �v�� 2016/02/17</br>
    /// <br>           : Redmine#48629�̏�Q�ꗗNo.17�@�I���{�^������̏�Q�Ή�</br>
    /// </remarks>
    public class PMMAX02000UA : System.Windows.Forms.Form
    {
        # region Private Members (Component)
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager Main_ToolbarsManager;
        private System.Windows.Forms.Timer Initial_Timer;
        private Infragistics.Win.UltraWinDock.UltraDockManager Main_DockManager;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar Main_StatusBar;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _PMMAX02000UAUnpinnedTabAreaLeft;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _PMMAX02000UAUnpinnedTabAreaRight;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _PMMAX02000UAUnpinnedTabAreaTop;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _PMMAX02000UAUnpinnedTabAreaBottom;
        private Infragistics.Win.UltraWinDock.AutoHideControl _PMMAX02000UAAutoHideControl;
        private TMemPos tMemPos1;
        private DataSet BindDataSet;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.MenuItem Close_menuItem;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMMAX02000UA_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMMAX02000UA_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMMAX02000UA_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMMAX02000UA_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_SearchCond;
        private System.Windows.Forms.ContextMenu TabControl_contextMenu;
        private Panel utc_panel;
        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// �o�i�E���ח\��t���[���N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �o�i�E���ח\��̃t���[���N���X�ł��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public PMMAX02000UA()
        {
            InitializeComponent();
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
        /// <remarks>
        /// <br>Note       : �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("MainMenu_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Edit_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Tools_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Button_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Export_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ErrReRead_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Setting_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool5 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool6 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ErrReRead_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool5 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Edit_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Export_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ErrReRead_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool6 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Tools_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Setting_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Export_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Setting_ButtonTool");
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMMAX02000UA));
            this.Main_DockManager = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._PMMAX02000UAUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._PMMAX02000UAUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._PMMAX02000UAUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._PMMAX02000UAUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._PMMAX02000UAAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Main_StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tMemPos1 = new Broadleaf.Library.Windows.Forms.TMemPos(this.components);
            this.BindDataSet = new System.Data.DataSet();
            this.Close_menuItem = new System.Windows.Forms.MenuItem();
            this.TabControl_contextMenu = new System.Windows.Forms.ContextMenu();
            this._PMMAX02000UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Main_ToolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._PMMAX02000UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMMAX02000UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMMAX02000UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraLabel_SearchCond = new Infragistics.Win.Misc.UltraLabel();
            this.utc_panel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).BeginInit();
            this.SuspendLayout();
            // 
            // Main_DockManager
            // 
            this.Main_DockManager.CaptionStyle = Infragistics.Win.UltraWinDock.CaptionStyle.Office2003;
            this.Main_DockManager.HostControl = this;
            this.Main_DockManager.LayoutStyle = Infragistics.Win.UltraWinDock.DockAreaLayoutStyle.FillContainer;
            this.Main_DockManager.ShowCloseButton = false;
            this.Main_DockManager.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2003;
            // 
            // _PMMAX02000UAUnpinnedTabAreaLeft
            // 
            this._PMMAX02000UAUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._PMMAX02000UAUnpinnedTabAreaLeft.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._PMMAX02000UAUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 73);
            this._PMMAX02000UAUnpinnedTabAreaLeft.Name = "_PMMAX02000UAUnpinnedTabAreaLeft";
            this._PMMAX02000UAUnpinnedTabAreaLeft.Owner = this.Main_DockManager;
            this._PMMAX02000UAUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 634);
            this._PMMAX02000UAUnpinnedTabAreaLeft.TabIndex = 5;
            // 
            // _PMMAX02000UAUnpinnedTabAreaRight
            // 
            this._PMMAX02000UAUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._PMMAX02000UAUnpinnedTabAreaRight.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._PMMAX02000UAUnpinnedTabAreaRight.Location = new System.Drawing.Point(1008, 73);
            this._PMMAX02000UAUnpinnedTabAreaRight.Name = "_PMMAX02000UAUnpinnedTabAreaRight";
            this._PMMAX02000UAUnpinnedTabAreaRight.Owner = this.Main_DockManager;
            this._PMMAX02000UAUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 634);
            this._PMMAX02000UAUnpinnedTabAreaRight.TabIndex = 6;
            // 
            // _PMMAX02000UAUnpinnedTabAreaTop
            // 
            this._PMMAX02000UAUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._PMMAX02000UAUnpinnedTabAreaTop.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._PMMAX02000UAUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 73);
            this._PMMAX02000UAUnpinnedTabAreaTop.Name = "_PMMAX02000UAUnpinnedTabAreaTop";
            this._PMMAX02000UAUnpinnedTabAreaTop.Owner = this.Main_DockManager;
            this._PMMAX02000UAUnpinnedTabAreaTop.Size = new System.Drawing.Size(1008, 0);
            this._PMMAX02000UAUnpinnedTabAreaTop.TabIndex = 7;
            // 
            // _PMMAX02000UAUnpinnedTabAreaBottom
            // 
            this._PMMAX02000UAUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._PMMAX02000UAUnpinnedTabAreaBottom.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._PMMAX02000UAUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 707);
            this._PMMAX02000UAUnpinnedTabAreaBottom.Name = "_PMMAX02000UAUnpinnedTabAreaBottom";
            this._PMMAX02000UAUnpinnedTabAreaBottom.Owner = this.Main_DockManager;
            this._PMMAX02000UAUnpinnedTabAreaBottom.Size = new System.Drawing.Size(1008, 0);
            this._PMMAX02000UAUnpinnedTabAreaBottom.TabIndex = 8;
            // 
            // _PMMAX02000UAAutoHideControl
            // 
            this._PMMAX02000UAAutoHideControl.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._PMMAX02000UAAutoHideControl.Location = new System.Drawing.Point(22, 63);
            this._PMMAX02000UAAutoHideControl.Name = "_PMMAX02000UAAutoHideControl";
            this._PMMAX02000UAAutoHideControl.Owner = this.Main_DockManager;
            this._PMMAX02000UAAutoHideControl.Size = new System.Drawing.Size(203, 627);
            this._PMMAX02000UAAutoHideControl.TabIndex = 9;
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            // 
            // Main_StatusBar
            // 
            this.Main_StatusBar.Location = new System.Drawing.Point(0, 707);
            this.Main_StatusBar.Name = "Main_StatusBar";
            appearance2.TextHAlignAsString = "Center";
            this.Main_StatusBar.PanelAppearance = appearance2;
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
            this.Main_StatusBar.Size = new System.Drawing.Size(1008, 23);
            this.Main_StatusBar.TabIndex = 28;
            this.Main_StatusBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tMemPos1
            // 
            this.tMemPos1.OwnerForm = this;
            // 
            // BindDataSet
            // 
            this.BindDataSet.DataSetName = "NewDataSet";
            this.BindDataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // Close_menuItem
            // 
            this.Close_menuItem.Index = 0;
            this.Close_menuItem.Text = "����(&C)";
            // 
            // TabControl_contextMenu
            // 
            this.TabControl_contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Close_menuItem});
            // 
            // _PMMAX02000UA_Toolbars_Dock_Area_Left
            // 
            this._PMMAX02000UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMMAX02000UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMMAX02000UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._PMMAX02000UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMMAX02000UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 73);
            this._PMMAX02000UA_Toolbars_Dock_Area_Left.Name = "_PMMAX02000UA_Toolbars_Dock_Area_Left";
            this._PMMAX02000UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 634);
            this._PMMAX02000UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.Main_ToolbarsManager;
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
            ultraToolbar1.FloatingLocation = new System.Drawing.Point(466, 462);
            ultraToolbar1.FloatingSize = new System.Drawing.Size(425, 48);
            ultraToolbar1.IsMainMenuBar = true;
            labelTool1.InstanceProps.Spring = Infragistics.Win.DefaultableBoolean.True;
            labelTool1.InstanceProps.Width = 25;
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
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            buttonTool4});
            ultraToolbar2.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.BelowImage;
            ultraToolbar2.Text = "�W��";
            this.Main_ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2});
            popupMenuTool4.SharedProps.Caption = "�t�@�C��(&F)";
            popupMenuTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            buttonTool5.InstanceProps.IsFirstInGroup = true;
            popupMenuTool4.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool5});
            labelTool4.SharedProps.Spring = true;
            appearance7.BackColor = System.Drawing.Color.White;
            appearance7.TextHAlignAsString = "Left";
            labelTool5.SharedProps.AppearancesSmall.Appearance = appearance7;
            labelTool5.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            labelTool5.SharedProps.Width = 150;
            buttonTool6.SharedProps.Caption = "�I��(&X)";
            buttonTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool6.SharedProps.ShowInCustomizer = false;
            labelTool6.SharedProps.Caption = "���O�C���S����";
            buttonTool7.SharedProps.Caption = "�װ�Ď捞(&I)";
            buttonTool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            popupMenuTool5.SharedProps.Caption = "�ҏW(&E)";
            popupMenuTool5.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool8,
            buttonTool9});
            popupMenuTool6.SharedProps.Caption = "�c�[��(&T)";
            popupMenuTool6.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool10});
            buttonTool11.SharedProps.Caption = "���ח\��(&S)";
            buttonTool11.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool12.SharedProps.Caption = "�ݒ�(&O)";
            buttonTool12.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.Main_ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool4,
            labelTool4,
            labelTool5,
            buttonTool6,
            labelTool6,
            buttonTool7,
            popupMenuTool5,
            popupMenuTool6,
            buttonTool11,
            buttonTool12});
            this.Main_ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.Main_ToolbarsManager_ToolClick);
            // 
            // _PMMAX02000UA_Toolbars_Dock_Area_Right
            // 
            this._PMMAX02000UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMMAX02000UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMMAX02000UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._PMMAX02000UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMMAX02000UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1008, 73);
            this._PMMAX02000UA_Toolbars_Dock_Area_Right.Name = "_PMMAX02000UA_Toolbars_Dock_Area_Right";
            this._PMMAX02000UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 634);
            this._PMMAX02000UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _PMMAX02000UA_Toolbars_Dock_Area_Top
            // 
            this._PMMAX02000UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMMAX02000UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMMAX02000UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._PMMAX02000UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMMAX02000UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._PMMAX02000UA_Toolbars_Dock_Area_Top.Name = "_PMMAX02000UA_Toolbars_Dock_Area_Top";
            this._PMMAX02000UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1008, 73);
            this._PMMAX02000UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _PMMAX02000UA_Toolbars_Dock_Area_Bottom
            // 
            this._PMMAX02000UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMMAX02000UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMMAX02000UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._PMMAX02000UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMMAX02000UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 707);
            this._PMMAX02000UA_Toolbars_Dock_Area_Bottom.Name = "_PMMAX02000UA_Toolbars_Dock_Area_Bottom";
            this._PMMAX02000UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1008, 0);
            this._PMMAX02000UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // ultraLabel_SearchCond
            // 
            appearance82.BackColor = System.Drawing.Color.Transparent;
            appearance82.ForeColorDisabled = System.Drawing.Color.Black;
            appearance82.TextHAlignAsString = "Left";
            appearance82.TextVAlignAsString = "Middle";
            this.ultraLabel_SearchCond.Appearance = appearance82;
            this.ultraLabel_SearchCond.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel_SearchCond.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraLabel_SearchCond.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F);
            this.ultraLabel_SearchCond.Location = new System.Drawing.Point(0, 73);
            this.ultraLabel_SearchCond.Margin = new System.Windows.Forms.Padding(1);
            this.ultraLabel_SearchCond.Name = "ultraLabel_SearchCond";
            this.ultraLabel_SearchCond.Size = new System.Drawing.Size(1008, 634);
            this.ultraLabel_SearchCond.TabIndex = 174;
            // 
            // utc_panel
            // 
            this.utc_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.utc_panel.Location = new System.Drawing.Point(0, 73);
            this.utc_panel.Name = "utc_panel";
            this.utc_panel.Size = new System.Drawing.Size(1008, 634);
            this.utc_panel.TabIndex = 179;
            // 
            // PMMAX02000UA
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this._PMMAX02000UAAutoHideControl);
            this.Controls.Add(this.utc_panel);
            this.Controls.Add(this.ultraLabel_SearchCond);
            this.Controls.Add(this._PMMAX02000UAUnpinnedTabAreaTop);
            this.Controls.Add(this._PMMAX02000UAUnpinnedTabAreaBottom);
            this.Controls.Add(this._PMMAX02000UAUnpinnedTabAreaLeft);
            this.Controls.Add(this._PMMAX02000UAUnpinnedTabAreaRight);
            this.Controls.Add(this._PMMAX02000UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._PMMAX02000UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._PMMAX02000UA_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._PMMAX02000UA_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.Main_StatusBar);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMMAX02000UA";
            this.Opacity = 0;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "���ח\��o�^";
            this.Load += new System.EventHandler(this.PMMAX02000UA_Load);
            this.Shown += new System.EventHandler(this.PMMAX02000UA_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PMMAX02000UA_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMMAX02000UA_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindDataSet)).EndInit();
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
        /// <br>Note       : �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
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
                        _form = new PMMAX02000UA();
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
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
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

        // ===================================================================================== //
        // �v���C�x�[�g�萔
        // ===================================================================================== //
        #region Private Constant
        private const string CT_PGID = "PMMAX02000U";
        private Hashtable _expFormControlInfoTable = new Hashtable();

        // �c�[���o�[�c�[���L�[�ݒ�
        private const string TOOLBAR_LOGINLABEL_TITLE = "LoginTitle_LabelTool";
        private const string TOOLBAR_LOGINNAMELABEL_KEY = "LoginName_LabelTool";
        private const string TOOLBAR_ENDBUTTON_KEY = "End_ButtonTool";
        private const string TOOLBAR_EXPORTBUTTON_KEY = "Export_ButtonTool";
        private const string TOOLBAR_SETTINGBUTTON_KEY = "Setting_ButtonTool";
        private const string TOOLBAR_ERRREREAD_KEY = "ErrReRead_ButtonTool";
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region Private Members

        private PMMAX02000UB _pmmax02000UB;
        private PMMAX02000UD _pMMAX02000UD;
        private static string[] _parameter;
        private static System.Windows.Forms.Form _form = null;
        private bool _buttonEnable = true;

        #endregion

        // ===================================================================================== //
        // �������\�b�h
        // ===================================================================================== //
        #region private method
        /// <summary>
        /// ������ʐݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ������ʐݒ���s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
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

            // ���ח\��{�^���̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool exportButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXPORTBUTTON_KEY];
            if (exportButton != null)
            {
                exportButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            }

            // �ݒ�̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool setupButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SETTINGBUTTON_KEY];
            if (setupButton != null)
            {
                setupButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;
            }

            // �װ�Ď捞�̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool errReadButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_ERRREREAD_KEY];
            if (errReadButton != null)
            {
                errReadButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVTAKING;
            }

            // ���O�C����
            Infragistics.Win.UltraWinToolbars.LabelTool LoginName = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_LOGINNAMELABEL_KEY];
            if (LoginName != null && LoginInfoAcquisition.Employee != null)
            {
                Employee employee = new Employee();
                employee = LoginInfoAcquisition.Employee;
                LoginName.SharedProps.Caption = employee.Name;
            }
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
        /// <br>Note        : ���C���t���[����LOAD�C�x���g�B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private void PMMAX02000UA_Load(object sender, System.EventArgs e)
        {
            // ������ʐݒ�
            InitialScreenSetting();
            this._pmmax02000UB = new PMMAX02000UB();
            this._pMMAX02000UD = new PMMAX02000UD();
            this._pmmax02000UB.TopLevel = false;
            this._pmmax02000UB.FormBorderStyle = FormBorderStyle.None;

            this._pmmax02000UB.Dock = DockStyle.Fill;

            this._pmmax02000UB.Show();

            // �^�u�R���g���[���Ƀ^�u��ǉ�����
            this.utc_panel.Controls.Add(this._pmmax02000UB);
        }

        // ---------- ADD 2016/02/24 Y.Wakita �B ---------->>>>>
        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : ��ʏI�������B</br>
        /// <br>Programmer  : �e�c ���V</br>
        /// <br>Date        : 2016/02/24</br>
        /// </remarks>
        private void PMMAX02000UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this._pmmax02000UB.RunFlg)
            {
                string msg = "���M���������܂őҋ@���Ă��܂��B\r\n\r\n���M�����̊�����ɏI���������s���ĉ������B";
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, msg, 0, MessageBoxButtons.OK);

                e.Cancel = true;
            }
        }
        // ---------- ADD 2016/02/24 Y.Wakita �B ----------<<<<<

        /// <summary>
        /// ��ʏI������
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : ��ʏI�������B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private void PMMAX02000UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._pmmax02000UB != null)
            {
                this._pmmax02000UB.Close();
            }
        }

        // ADD BY �v�� 2016/02/17 FOR Redmine#48629�̏�Q�ꗗNo.17�@�I���{�^������̏�Q�Ή� ------>>>>>>
        /// <summary>
        /// �{�^���̐��䏈��
        /// </summary>
        /// <param name="isEnable">true:�{�^���L��; false:  �{�^������</param>
        /// <remarks>
        /// <br>Note        : �{�^���̐��䏈�����s���B</br>
        /// <br>Programmer  : �v��</br>
        /// <br>Date        : 2016/02/17</br>
        /// </remarks>
        private void SetButtonEnabled(bool isEnable)
        {
            this.Main_ToolbarsManager.Tools[TOOLBAR_ENDBUTTON_KEY].SharedProps.Enabled = isEnable;
            this.Main_ToolbarsManager.Tools[TOOLBAR_EXPORTBUTTON_KEY].SharedProps.Enabled = isEnable;
            this.Main_ToolbarsManager.Tools[TOOLBAR_SETTINGBUTTON_KEY].SharedProps.Enabled = isEnable;
            this.Main_ToolbarsManager.Tools[TOOLBAR_ERRREREAD_KEY].SharedProps.Enabled = isEnable;
        }
        // ADD BY �v�� 2016/02/17 FOR Redmine#48629�̏�Q�ꗗNo.17�@�I���{�^������̏�Q�Ή� ------<<<<<<

        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : �c�[���o�[�N���b�N���ɔ������܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// <br>UpdateNote : �v�� 2016/02/17</br>
        /// <br>           : Redmine#48629�̏�Q�ꗗNo.17�@�I���{�^������̏�Q�Ή�</br>
        /// </remarks>
        private void Main_ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            if (_buttonEnable)
            {
                switch (e.Tool.Key)
                {
                    // �I��
                    case TOOLBAR_ENDBUTTON_KEY:
                        {
                            this.Close();
                            break;
                        }
                    // ���ח\��{�^��
                    case TOOLBAR_EXPORTBUTTON_KEY:
                        {
                            SetButtonEnabled(false);// ADD BY �v�� 2016/02/17 FOR Redmine#48629�̏�Q�ꗗNo.17�@�I���{�^������̏�Q�Ή�
                            this.DoExtract(this._pMMAX02000UD.ShipDateRange, this._pMMAX02000UD.OutPutPath, this._pMMAX02000UD.UserID, this._pMMAX02000UD.UserPassWord);
                            SetButtonEnabled(true);// ADD BY �v�� 2016/02/17 FOR Redmine#48629�̏�Q�ꗗNo.17�@�I���{�^������̏�Q�Ή�
                            break;
                        }
                    // �ݒ�
                    case TOOLBAR_SETTINGBUTTON_KEY:
                        {
                            this._pMMAX02000UD.InitialScreenData();
                            this._pMMAX02000UD.ShowDialog();
                            break;
                        }
                    // �װ�Ď捞
                    case TOOLBAR_ERRREREAD_KEY:
                        {
                            SetButtonEnabled(false);// ADD BY �v�� 2016/02/17 FOR Redmine#48629�̏�Q�ꗗNo.17�@�I���{�^������̏�Q�Ή�
                            this._pmmax02000UB.ErrReRead();
                            SetButtonEnabled(true);// ADD BY �v�� 2016/02/17 FOR Redmine#48629�̏�Q�ꗗNo.17�@�I���{�^������̏�Q�Ή�
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// ���ח\��{�^��
        /// </summary>
        /// <param name="shipDateRange">�o�ד��t�����l</param>
        /// <param name="outPutPath">�o�͐�</param>
        /// <param name="useId">���iMAX���O�C��ID</param>
        /// <param name="userPassWord">���iMAX�p�X���[�h</param>
        /// <remarks>
        /// <br>Note       : ���ח\��o�͂����s����B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void DoExtract(int shipDateRange, string outPutPath, string useId, string userPassWord)
        {
            int status = this._pmmax02000UB.DataExport(shipDateRange, outPutPath, useId, userPassWord);
        }

        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note	   : ��ʕ\������</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private void PMMAX02000UA_Shown(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.DoEvents();
            this.Opacity = 1;
        }
        # endregion control event
    }
}

//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���}�X�^�C���|�[�g�E�G�N�X�|�[�g�t���[���N���X
// �v���O�����T�v   : �C���|�[�g�E�G�N�X�|�[�g���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  ********-** �쐬�S�� : FSI���� �f��
// �� �� ��  2013/06/12  �C�����e : �T�|�[�g�c�[���Ή��A�V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : UT���� ��Y
// �C �� ��  2018/09/11  �C�����e : �����^�C���p�X���[�h�Ή�
//----------------------------------------------------------------------------//
#define CHG20060417
#define CLR2
#define REP20060427
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Text;
using Broadleaf.Application.Controller.Facade;
using Broadleaf.Application.Controller.Util;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �|���}�X�^�C���|�[�g�E�G�N�X�|�[�g�t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �C���|�[�g�E�G�N�X�|�[�g�̃t���[���N���X�ł��B</br>
    /// <br>Programmer : FSI���� �f��</br>
    /// <br>Date       : 2013/06/12</br>
    /// </remarks>
    public class PMKHN09810UA : System.Windows.Forms.Form
    {
        # region Private Members (Component)
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager Main_ToolbarsManager;
        private System.Windows.Forms.Timer Initial_Timer;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar Main_StatusBar;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN09810UA_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN09810UA_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN09810UA_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN09810UA_Toolbars_Dock_Area_Bottom;
        private TMemPos tMemPos1;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl Main_UTabControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl Sub_UTabControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage DataViewTabSharedControlsPage;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl3;
        private DataSet BindDataSet;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.UltraWinGrid.UltraGrid DataViewGrid;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.MenuItem Close_menuItem;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage2;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl4;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar2;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl2;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage3;
        private Infragistics.Win.UltraWinTree.UltraTree ultraTree1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage4;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl5;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid2;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar3;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl3;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage5;
        private Infragistics.Win.UltraWinTree.UltraTree ultraTree2;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage6;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl6;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid3;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar4;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl4;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage7;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid4;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar5;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl5;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage8;
        private Infragistics.Win.UltraWinTree.UltraTree ultraTree3;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl8;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl SubImp_UTabControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage10;
        private Infragistics.Win.UltraWinTree.UltraTree StartNavigatorINPTree;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl7;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl SubExp_UTabControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage9;
        private Infragistics.Win.UltraWinTree.UltraTree StartNavigatorEXPTree;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl9;
        private System.Windows.Forms.ContextMenu TabControl_contextMenu;
        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>S
        public PMKHN09810UA()
        {
            InitializeComponent();

            // RemotingConfiguration�̓ǂݍ���
#if !CLR2
			System.Runtime.Remoting.RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
#endif
            
            this._formattedTextWriter = new FormattedTextWriter();

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
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab6 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab7 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("MainMenu_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Tool_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Window_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Tool_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool5 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Tool_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Button_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool("STOP_LabelTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("TextOutPut_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Export_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Import_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool6 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Export_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Import_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("TextOutPut_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool7 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Tool_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UserSetUp_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool8 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Window_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool9 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Forms_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool5 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool6 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool7 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UserSetUp_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool8 = new Infragistics.Win.UltraWinToolbars.LabelTool("PrintKindTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboBoxTool1 = new Infragistics.Win.UltraWinToolbars.ComboBoxTool("PrintKind_ComboBoxTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Extract_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Preview_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Print_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool9 = new Infragistics.Win.UltraWinToolbars.LabelTool("STOP_LabelTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool1 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("PrtSuspendCnt_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool10 = new Infragistics.Win.UltraWinToolbars.LabelTool("Number_LabelTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("PDFSave_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("TextOutPut_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Export_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Import_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool19 = new Infragistics.Win.UltraWinToolbars.ButtonTool("SetUp_ButtonTool");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09810UA));
            this.ultraTabPageControl7 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.SubExp_UTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage9 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.StartNavigatorEXPTree = new Infragistics.Win.UltraWinTree.UltraTree();
            this.ultraTabPageControl8 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.SubImp_UTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage10 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.StartNavigatorINPTree = new Infragistics.Win.UltraWinTree.UltraTree();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.DataViewGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Sub_UTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.DataViewTabSharedControlsPage = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Main_StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tMemPos1 = new Broadleaf.Library.Windows.Forms.TMemPos(this.components);
            this.Main_UTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraTabPageControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.BindDataSet = new System.Data.DataSet();
            this.Close_menuItem = new System.Windows.Forms.MenuItem();
            this.TabControl_contextMenu = new System.Windows.Forms.ContextMenu();
            this.ultraTabSharedControlsPage2 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl4 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraStatusBar2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.ultraTabControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage3 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTree1 = new Infragistics.Win.UltraWinTree.UltraTree();
            this.ultraTabSharedControlsPage4 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl5 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraGrid2 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraStatusBar3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.ultraTabControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage5 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTree2 = new Infragistics.Win.UltraWinTree.UltraTree();
            this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage6 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTabPageControl6 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ultraGrid3 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraStatusBar4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.ultraTabControl4 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage7 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraGrid4 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraStatusBar5 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.ultraTabControl5 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage8 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.ultraTree3 = new Infragistics.Win.UltraWinTree.UltraTree();
            this.ultraTabPageControl9 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this._PMKHN09810UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Main_ToolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._PMKHN09810UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMKHN09810UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMKHN09810UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraTabPageControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SubExp_UTabControl)).BeginInit();
            this.SubExp_UTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartNavigatorEXPTree)).BeginInit();
            this.ultraTabPageControl8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SubImp_UTabControl)).BeginInit();
            this.SubImp_UTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartNavigatorINPTree)).BeginInit();
            this.ultraTabPageControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataViewGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_UTabControl)).BeginInit();
            this.Sub_UTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_UTabControl)).BeginInit();
            this.Main_UTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindDataSet)).BeginInit();
            this.ultraTabPageControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl2)).BeginInit();
            this.ultraTabControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTree1)).BeginInit();
            this.ultraTabPageControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl3)).BeginInit();
            this.ultraTabControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTree2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            this.ultraTabPageControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl5)).BeginInit();
            this.ultraTabControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTree3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraTabPageControl7
            // 
            this.ultraTabPageControl7.Controls.Add(this.SubExp_UTabControl);
            this.ultraTabPageControl7.Controls.Add(this.StartNavigatorEXPTree);
            this.ultraTabPageControl7.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl7.Name = "ultraTabPageControl7";
            this.ultraTabPageControl7.Size = new System.Drawing.Size(1014, 595);
            // 
            // SubExp_UTabControl
            // 
            appearance68.BackColor = System.Drawing.Color.White;
            appearance68.BackColor2 = System.Drawing.Color.AliceBlue;
            appearance68.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.SubExp_UTabControl.Appearance = appearance68;
            this.SubExp_UTabControl.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.SubExp_UTabControl.Controls.Add(this.ultraTabSharedControlsPage9);
            this.SubExp_UTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubExp_UTabControl.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SubExp_UTabControl.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.SubExp_UTabControl.Location = new System.Drawing.Point(201, 0);
            this.SubExp_UTabControl.Name = "SubExp_UTabControl";
            this.SubExp_UTabControl.SharedControlsPage = this.ultraTabSharedControlsPage9;
            this.SubExp_UTabControl.Size = new System.Drawing.Size(813, 595);
            this.SubExp_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.SubExp_UTabControl.TabIndex = 38;
            this.SubExp_UTabControl.TabPadding = new System.Drawing.Size(3, 3);
            this.SubExp_UTabControl.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SubExp_UTabControl.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.SubExp_UTabControl.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(this.SubExp_UTabControl_SelectedTabChanged);
            // 
            // ultraTabSharedControlsPage9
            // 
            this.ultraTabSharedControlsPage9.Location = new System.Drawing.Point(1, 20);
            this.ultraTabSharedControlsPage9.Name = "ultraTabSharedControlsPage9";
            this.ultraTabSharedControlsPage9.Size = new System.Drawing.Size(811, 574);
            // 
            // StartNavigatorEXPTree
            // 
            this.StartNavigatorEXPTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.StartNavigatorEXPTree.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.StartNavigatorEXPTree.Location = new System.Drawing.Point(0, 0);
            this.StartNavigatorEXPTree.Name = "StartNavigatorEXPTree";
            this.StartNavigatorEXPTree.NodeConnectorColor = System.Drawing.SystemColors.ControlDark;
            this.StartNavigatorEXPTree.SettingsKey = "PMKHN09810UA.StartNavigatorEXPTree";
            this.StartNavigatorEXPTree.Size = new System.Drawing.Size(201, 595);
            this.StartNavigatorEXPTree.TabIndex = 35;
            this.StartNavigatorEXPTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartNavigatorEXPTree_MouseDown);
            this.StartNavigatorEXPTree.DoubleClick += new System.EventHandler(this.StartNavigatorEXPTree_DoubleClick);
            // 
            // ultraTabPageControl8
            // 
            this.ultraTabPageControl8.Controls.Add(this.SubImp_UTabControl);
            this.ultraTabPageControl8.Controls.Add(this.StartNavigatorINPTree);
            this.ultraTabPageControl8.Location = new System.Drawing.Point(1, 25);
            this.ultraTabPageControl8.Name = "ultraTabPageControl8";
            this.ultraTabPageControl8.Size = new System.Drawing.Size(1014, 595);
            // 
            // SubImp_UTabControl
            // 
            appearance37.BackColor = System.Drawing.Color.White;
            appearance37.BackColor2 = System.Drawing.Color.AliceBlue;
            appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.SubImp_UTabControl.Appearance = appearance37;
            this.SubImp_UTabControl.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.SubImp_UTabControl.Controls.Add(this.ultraTabSharedControlsPage10);
            this.SubImp_UTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubImp_UTabControl.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SubImp_UTabControl.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.SubImp_UTabControl.Location = new System.Drawing.Point(201, 0);
            this.SubImp_UTabControl.Name = "SubImp_UTabControl";
            this.SubImp_UTabControl.SharedControlsPage = this.ultraTabSharedControlsPage10;
            this.SubImp_UTabControl.Size = new System.Drawing.Size(813, 595);
            this.SubImp_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.SubImp_UTabControl.TabIndex = 38;
            this.SubImp_UTabControl.TabPadding = new System.Drawing.Size(3, 3);
            this.SubImp_UTabControl.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SubImp_UTabControl.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.SubImp_UTabControl.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(this.SubImp_UTabControl_SelectedTabChanged);
            // 
            // ultraTabSharedControlsPage10
            // 
            this.ultraTabSharedControlsPage10.Location = new System.Drawing.Point(1, 20);
            this.ultraTabSharedControlsPage10.Name = "ultraTabSharedControlsPage10";
            this.ultraTabSharedControlsPage10.Size = new System.Drawing.Size(811, 574);
            // 
            // StartNavigatorINPTree
            // 
            this.StartNavigatorINPTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.StartNavigatorINPTree.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.StartNavigatorINPTree.Location = new System.Drawing.Point(0, 0);
            this.StartNavigatorINPTree.Name = "StartNavigatorINPTree";
            this.StartNavigatorINPTree.NodeConnectorColor = System.Drawing.SystemColors.ControlDark;
            this.StartNavigatorINPTree.SettingsKey = "PMKHN09810UA.StartNavigatorINPTree";
            this.StartNavigatorINPTree.Size = new System.Drawing.Size(201, 595);
            this.StartNavigatorINPTree.TabIndex = 35;
            this.StartNavigatorINPTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartNavigatorINPTree_MouseDown);
            this.StartNavigatorINPTree.DoubleClick += new System.EventHandler(this.StartNavigatorINPTree_DoubleClick);
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.DataViewGrid);
            this.ultraTabPageControl1.Controls.Add(this.ultraStatusBar1);
            this.ultraTabPageControl1.Controls.Add(this.Sub_UTabControl);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(992, 591);
            // 
            // DataViewGrid
            // 
            appearance47.BackColor = System.Drawing.Color.White;
            appearance47.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance47.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.DataViewGrid.DisplayLayout.Appearance = appearance47;
            this.DataViewGrid.DisplayLayout.GroupByBox.Hidden = true;
            this.DataViewGrid.DisplayLayout.InterBandSpacing = 10;
            this.DataViewGrid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.DataViewGrid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.DataViewGrid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.DataViewGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.DataViewGrid.DisplayLayout.Override.AllowRowLayoutCellSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.DataViewGrid.DisplayLayout.Override.AllowRowLayoutColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.None;
            this.DataViewGrid.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.DataViewGrid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance48.BackColor = System.Drawing.Color.Transparent;
            this.DataViewGrid.DisplayLayout.Override.CardAreaAppearance = appearance48;
            this.DataViewGrid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance65.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance65.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance65.ForeColor = System.Drawing.Color.White;
            appearance65.TextHAlignAsString = "Left";
            appearance65.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.DataViewGrid.DisplayLayout.Override.HeaderAppearance = appearance65;
            this.DataViewGrid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.DataViewGrid.DisplayLayout.Override.MaxSelectedRows = 100;
            appearance50.BackColor = System.Drawing.Color.Lavender;
            this.DataViewGrid.DisplayLayout.Override.RowAlternateAppearance = appearance50;
            appearance51.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.DataViewGrid.DisplayLayout.Override.RowAppearance = appearance51;
            this.DataViewGrid.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.DataViewGrid.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance52.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance52.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance52.ForeColor = System.Drawing.Color.White;
            this.DataViewGrid.DisplayLayout.Override.RowSelectorAppearance = appearance52;
            this.DataViewGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.DataViewGrid.DisplayLayout.Override.RowSelectorWidth = 12;
            this.DataViewGrid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance53.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance53.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance53.ForeColor = System.Drawing.Color.Black;
            this.DataViewGrid.DisplayLayout.Override.SelectedRowAppearance = appearance53;
            this.DataViewGrid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.DataViewGrid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.DataViewGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.DataViewGrid.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.DataViewGrid.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.DataViewGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.DataViewGrid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.DataViewGrid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.DataViewGrid.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.DataViewGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataViewGrid.Location = new System.Drawing.Point(0, 360);
            this.DataViewGrid.Name = "DataViewGrid";
            this.DataViewGrid.Size = new System.Drawing.Size(992, 231);
            this.DataViewGrid.TabIndex = 41;
            // 
            // ultraStatusBar1
            // 
            appearance54.FontData.BoldAsString = "True";
            appearance54.FontData.Name = "�l�r �S�V�b�N";
            appearance54.FontData.SizeInPoints = 11F;
            this.ultraStatusBar1.Appearance = appearance54;
            this.ultraStatusBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 332);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Padding = new Infragistics.Win.UltraWinStatusBar.UIElementMargins(20, 2, 0, 0);
            this.ultraStatusBar1.Size = new System.Drawing.Size(992, 28);
            this.ultraStatusBar1.TabIndex = 40;
            this.ultraStatusBar1.Text = "�o�͌��ʃC���[�W";
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Sub_UTabControl
            // 
            appearance55.BackColor = System.Drawing.Color.White;
            appearance55.BackColor2 = System.Drawing.Color.AliceBlue;
            appearance55.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Sub_UTabControl.Appearance = appearance55;
            this.Sub_UTabControl.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.Sub_UTabControl.Controls.Add(this.DataViewTabSharedControlsPage);
            this.Sub_UTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.Sub_UTabControl.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Sub_UTabControl.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.Sub_UTabControl.Location = new System.Drawing.Point(0, 0);
            this.Sub_UTabControl.Name = "Sub_UTabControl";
            this.Sub_UTabControl.SharedControlsPage = this.DataViewTabSharedControlsPage;
            this.Sub_UTabControl.Size = new System.Drawing.Size(992, 332);
            this.Sub_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.Sub_UTabControl.TabIndex = 38;
            this.Sub_UTabControl.TabPadding = new System.Drawing.Size(3, 3);
            this.Sub_UTabControl.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Sub_UTabControl.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Sub_UTabControl.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(this.Sub_UTabControl_SelectedTabChanged);
            // 
            // DataViewTabSharedControlsPage
            // 
            this.DataViewTabSharedControlsPage.Location = new System.Drawing.Point(1, 20);
            this.DataViewTabSharedControlsPage.Name = "DataViewTabSharedControlsPage";
            this.DataViewTabSharedControlsPage.Size = new System.Drawing.Size(990, 311);
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // Main_StatusBar
            // 
            this.Main_StatusBar.Location = new System.Drawing.Point(0, 690);
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
            this.Main_StatusBar.Size = new System.Drawing.Size(1016, 23);
            this.Main_StatusBar.TabIndex = 28;
            this.Main_StatusBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tMemPos1
            // 
            this.tMemPos1.OwnerForm = this;
            // 
            // Main_UTabControl
            // 
            appearance10.BackColor = System.Drawing.Color.White;
            appearance10.BackColor2 = System.Drawing.Color.LightPink;
            this.Main_UTabControl.ActiveTabAppearance = appearance10;
            appearance19.BackColor = System.Drawing.Color.White;
            appearance19.BackColor2 = System.Drawing.Color.Lavender;
            appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Main_UTabControl.Appearance = appearance19;
            this.Main_UTabControl.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.Main_UTabControl.Controls.Add(this.ultraTabPageControl8);
            this.Main_UTabControl.Controls.Add(this.ultraTabPageControl7);
            this.Main_UTabControl.Controls.Add(this.ultraTabSharedControlsPage1);
            this.Main_UTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_UTabControl.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Main_UTabControl.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.Main_UTabControl.Location = new System.Drawing.Point(0, 69);
            this.Main_UTabControl.Name = "Main_UTabControl";
            this.Main_UTabControl.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.Main_UTabControl.Size = new System.Drawing.Size(1016, 621);
            this.Main_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.Main_UTabControl.TabIndex = 34;
            this.Main_UTabControl.TabPadding = new System.Drawing.Size(80, 3);
            ultraTab6.TabPage = this.ultraTabPageControl7;
            ultraTab6.Tag = "export";
            ultraTab6.Text = "����߰�";
            ultraTab7.TabPage = this.ultraTabPageControl8;
            ultraTab7.Tag = "import";
            ultraTab7.Text = "���߰�";
            this.Main_UTabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab6,
            ultraTab7});
            this.Main_UTabControl.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Main_UTabControl.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            this.Main_UTabControl.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(this.Main_UTabControl_SelectedTabChanged);
            this.Main_UTabControl.Click += new System.EventHandler(this.Main_UTabControl_Click);
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(1014, 595);
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(1014, 623);
            // 
            // ultraTabPageControl3
            // 
            this.ultraTabPageControl3.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl3.Name = "ultraTabPageControl3";
            this.ultraTabPageControl3.Size = new System.Drawing.Size(1014, 623);
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
            this.Close_menuItem.Click += new System.EventHandler(this.Close_menuItem_Click);
            // 
            // TabControl_contextMenu
            // 
            this.TabControl_contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Close_menuItem});
            // 
            // ultraTabSharedControlsPage2
            // 
            this.ultraTabSharedControlsPage2.Location = new System.Drawing.Point(1, 25);
            this.ultraTabSharedControlsPage2.Name = "ultraTabSharedControlsPage2";
            this.ultraTabSharedControlsPage2.Size = new System.Drawing.Size(992, 622);
            // 
            // ultraTabPageControl4
            // 
            this.ultraTabPageControl4.Controls.Add(this.ultraGrid1);
            this.ultraTabPageControl4.Controls.Add(this.ultraStatusBar2);
            this.ultraTabPageControl4.Controls.Add(this.ultraTabControl2);
            this.ultraTabPageControl4.Controls.Add(this.ultraTree1);
            this.ultraTabPageControl4.Location = new System.Drawing.Point(1, 25);
            this.ultraTabPageControl4.Name = "ultraTabPageControl4";
            this.ultraTabPageControl4.Size = new System.Drawing.Size(992, 622);
            // 
            // ultraGrid1
            // 
            appearance59.BackColor = System.Drawing.Color.White;
            appearance59.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance59.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultraGrid1.DisplayLayout.Appearance = appearance59;
            this.ultraGrid1.DisplayLayout.GroupByBox.Hidden = true;
            this.ultraGrid1.DisplayLayout.InterBandSpacing = 10;
            this.ultraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.ultraGrid1.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.ultraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid1.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid1.DisplayLayout.Override.AllowRowLayoutCellSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.ultraGrid1.DisplayLayout.Override.AllowRowLayoutColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.None;
            this.ultraGrid1.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.ultraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance60.BackColor = System.Drawing.Color.Transparent;
            this.ultraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance60;
            this.ultraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance8.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance8.ForeColor = System.Drawing.Color.White;
            appearance8.TextHAlignAsString = "Left";
            appearance8.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraGrid1.DisplayLayout.Override.HeaderAppearance = appearance8;
            this.ultraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ultraGrid1.DisplayLayout.Override.MaxSelectedRows = 100;
            appearance9.BackColor = System.Drawing.Color.Lavender;
            this.ultraGrid1.DisplayLayout.Override.RowAlternateAppearance = appearance9;
            appearance6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.ultraGrid1.DisplayLayout.Override.RowAppearance = appearance6;
            this.ultraGrid1.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.ultraGrid1.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance61.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance61.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance61.ForeColor = System.Drawing.Color.White;
            this.ultraGrid1.DisplayLayout.Override.RowSelectorAppearance = appearance61;
            this.ultraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid1.DisplayLayout.Override.RowSelectorWidth = 12;
            this.ultraGrid1.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance64.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance64.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance64.ForeColor = System.Drawing.Color.Black;
            this.ultraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance64;
            this.ultraGrid1.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ultraGrid1.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ultraGrid1.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.ultraGrid1.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.ultraGrid1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.ultraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ultraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ultraGrid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.ultraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ultraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid1.Location = new System.Drawing.Point(201, 360);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(791, 262);
            this.ultraGrid1.TabIndex = 41;
            // 
            // ultraStatusBar2
            // 
            appearance94.FontData.BoldAsString = "True";
            appearance94.FontData.Name = "�l�r �S�V�b�N";
            appearance94.FontData.SizeInPoints = 11F;
            this.ultraStatusBar2.Appearance = appearance94;
            this.ultraStatusBar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraStatusBar2.Location = new System.Drawing.Point(201, 332);
            this.ultraStatusBar2.Name = "ultraStatusBar2";
            this.ultraStatusBar2.Padding = new Infragistics.Win.UltraWinStatusBar.UIElementMargins(20, 2, 0, 0);
            this.ultraStatusBar2.Size = new System.Drawing.Size(791, 28);
            this.ultraStatusBar2.TabIndex = 40;
            this.ultraStatusBar2.Text = "�o�͌��ʃC���[�W";
            this.ultraStatusBar2.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // ultraTabControl2
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColor2 = System.Drawing.Color.AliceBlue;
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultraTabControl2.Appearance = appearance1;
            this.ultraTabControl2.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ultraTabControl2.Controls.Add(this.ultraTabSharedControlsPage3);
            this.ultraTabControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraTabControl2.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraTabControl2.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.ultraTabControl2.Location = new System.Drawing.Point(201, 0);
            this.ultraTabControl2.Name = "ultraTabControl2";
            this.ultraTabControl2.SharedControlsPage = this.ultraTabSharedControlsPage3;
            this.ultraTabControl2.Size = new System.Drawing.Size(791, 332);
            this.ultraTabControl2.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.ultraTabControl2.TabIndex = 38;
            this.ultraTabControl2.TabPadding = new System.Drawing.Size(3, 3);
            this.ultraTabControl2.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ultraTabControl2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ultraTabSharedControlsPage3
            // 
            this.ultraTabSharedControlsPage3.Location = new System.Drawing.Point(1, 20);
            this.ultraTabSharedControlsPage3.Name = "ultraTabSharedControlsPage3";
            this.ultraTabSharedControlsPage3.Size = new System.Drawing.Size(789, 311);
            // 
            // ultraTree1
            // 
            this.ultraTree1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ultraTree1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.ultraTree1.Location = new System.Drawing.Point(0, 0);
            this.ultraTree1.Name = "ultraTree1";
            this.ultraTree1.NodeConnectorColor = System.Drawing.SystemColors.ControlDark;
            this.ultraTree1.SettingsKey = "PMKHN09810UA.ultraTree1";
            this.ultraTree1.Size = new System.Drawing.Size(201, 622);
            this.ultraTree1.TabIndex = 35;
            // 
            // ultraTabSharedControlsPage4
            // 
            this.ultraTabSharedControlsPage4.Location = new System.Drawing.Point(1, 25);
            this.ultraTabSharedControlsPage4.Name = "ultraTabSharedControlsPage4";
            this.ultraTabSharedControlsPage4.Size = new System.Drawing.Size(992, 622);
            // 
            // ultraTabPageControl5
            // 
            this.ultraTabPageControl5.Controls.Add(this.ultraGrid2);
            this.ultraTabPageControl5.Controls.Add(this.ultraStatusBar3);
            this.ultraTabPageControl5.Controls.Add(this.ultraTabControl3);
            this.ultraTabPageControl5.Controls.Add(this.ultraTree2);
            this.ultraTabPageControl5.Location = new System.Drawing.Point(1, 25);
            this.ultraTabPageControl5.Name = "ultraTabPageControl5";
            this.ultraTabPageControl5.Size = new System.Drawing.Size(992, 622);
            // 
            // ultraGrid2
            // 
            appearance38.BackColor = System.Drawing.Color.White;
            appearance38.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance38.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultraGrid2.DisplayLayout.Appearance = appearance38;
            this.ultraGrid2.DisplayLayout.GroupByBox.Hidden = true;
            this.ultraGrid2.DisplayLayout.InterBandSpacing = 10;
            this.ultraGrid2.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.ultraGrid2.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.ultraGrid2.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid2.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid2.DisplayLayout.Override.AllowRowLayoutCellSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.ultraGrid2.DisplayLayout.Override.AllowRowLayoutColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.None;
            this.ultraGrid2.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.ultraGrid2.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance39.BackColor = System.Drawing.Color.Transparent;
            this.ultraGrid2.DisplayLayout.Override.CardAreaAppearance = appearance39;
            this.ultraGrid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance40.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance40.ForeColor = System.Drawing.Color.White;
            appearance40.TextHAlignAsString = "Left";
            appearance40.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraGrid2.DisplayLayout.Override.HeaderAppearance = appearance40;
            this.ultraGrid2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ultraGrid2.DisplayLayout.Override.MaxSelectedRows = 100;
            appearance41.BackColor = System.Drawing.Color.Lavender;
            this.ultraGrid2.DisplayLayout.Override.RowAlternateAppearance = appearance41;
            appearance42.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.ultraGrid2.DisplayLayout.Override.RowAppearance = appearance42;
            this.ultraGrid2.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.ultraGrid2.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance43.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance43.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance43.ForeColor = System.Drawing.Color.White;
            this.ultraGrid2.DisplayLayout.Override.RowSelectorAppearance = appearance43;
            this.ultraGrid2.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid2.DisplayLayout.Override.RowSelectorWidth = 12;
            this.ultraGrid2.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance44.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance44.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance44.ForeColor = System.Drawing.Color.Black;
            this.ultraGrid2.DisplayLayout.Override.SelectedRowAppearance = appearance44;
            this.ultraGrid2.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ultraGrid2.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ultraGrid2.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.ultraGrid2.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.ultraGrid2.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.ultraGrid2.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ultraGrid2.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ultraGrid2.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.ultraGrid2.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ultraGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid2.Location = new System.Drawing.Point(201, 360);
            this.ultraGrid2.Name = "ultraGrid2";
            this.ultraGrid2.Size = new System.Drawing.Size(791, 262);
            this.ultraGrid2.TabIndex = 41;
            // 
            // ultraStatusBar3
            // 
            appearance45.FontData.BoldAsString = "True";
            appearance45.FontData.Name = "�l�r �S�V�b�N";
            appearance45.FontData.SizeInPoints = 11F;
            this.ultraStatusBar3.Appearance = appearance45;
            this.ultraStatusBar3.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraStatusBar3.Location = new System.Drawing.Point(201, 332);
            this.ultraStatusBar3.Name = "ultraStatusBar3";
            this.ultraStatusBar3.Padding = new Infragistics.Win.UltraWinStatusBar.UIElementMargins(20, 2, 0, 0);
            this.ultraStatusBar3.Size = new System.Drawing.Size(791, 28);
            this.ultraStatusBar3.TabIndex = 40;
            this.ultraStatusBar3.Text = "�o�͌��ʃC���[�W";
            this.ultraStatusBar3.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // ultraTabControl3
            // 
            appearance46.BackColor = System.Drawing.Color.White;
            appearance46.BackColor2 = System.Drawing.Color.AliceBlue;
            appearance46.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultraTabControl3.Appearance = appearance46;
            this.ultraTabControl3.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ultraTabControl3.Controls.Add(this.ultraTabSharedControlsPage5);
            this.ultraTabControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraTabControl3.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraTabControl3.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.ultraTabControl3.Location = new System.Drawing.Point(201, 0);
            this.ultraTabControl3.Name = "ultraTabControl3";
            this.ultraTabControl3.SharedControlsPage = this.ultraTabSharedControlsPage5;
            this.ultraTabControl3.Size = new System.Drawing.Size(791, 332);
            this.ultraTabControl3.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.ultraTabControl3.TabIndex = 38;
            this.ultraTabControl3.TabPadding = new System.Drawing.Size(3, 3);
            this.ultraTabControl3.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ultraTabControl3.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ultraTabSharedControlsPage5
            // 
            this.ultraTabSharedControlsPage5.Location = new System.Drawing.Point(1, 20);
            this.ultraTabSharedControlsPage5.Name = "ultraTabSharedControlsPage5";
            this.ultraTabSharedControlsPage5.Size = new System.Drawing.Size(789, 311);
            // 
            // ultraTree2
            // 
            this.ultraTree2.Dock = System.Windows.Forms.DockStyle.Left;
            this.ultraTree2.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.ultraTree2.Location = new System.Drawing.Point(0, 0);
            this.ultraTree2.Name = "ultraTree2";
            this.ultraTree2.NodeConnectorColor = System.Drawing.SystemColors.ControlDark;
            this.ultraTree2.SettingsKey = "PMKHN09810UA.ultraTree2";
            this.ultraTree2.Size = new System.Drawing.Size(201, 622);
            this.ultraTree2.TabIndex = 35;
            // 
            // ultraTabControl1
            // 
            appearance18.BackColor = System.Drawing.Color.White;
            appearance18.BackColor2 = System.Drawing.Color.AliceBlue;
            appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultraTabControl1.Appearance = appearance18;
            this.ultraTabControl1.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage6);
            this.ultraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage6;
            this.ultraTabControl1.Size = new System.Drawing.Size(200, 100);
            this.ultraTabControl1.TabIndex = 0;
            // 
            // ultraTabSharedControlsPage6
            // 
            this.ultraTabSharedControlsPage6.Location = new System.Drawing.Point(2, 21);
            this.ultraTabSharedControlsPage6.Name = "ultraTabSharedControlsPage6";
            this.ultraTabSharedControlsPage6.Size = new System.Drawing.Size(196, 77);
            // 
            // ultraTabPageControl6
            // 
            this.ultraTabPageControl6.Controls.Add(this.ultraGrid3);
            this.ultraTabPageControl6.Controls.Add(this.ultraStatusBar4);
            this.ultraTabPageControl6.Location = new System.Drawing.Point(0, 0);
            this.ultraTabPageControl6.Name = "ultraTabPageControl6";
            this.ultraTabPageControl6.Size = new System.Drawing.Size(196, 77);
            // 
            // ultraGrid3
            // 
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultraGrid3.DisplayLayout.Appearance = appearance3;
            this.ultraGrid3.DisplayLayout.GroupByBox.Hidden = true;
            this.ultraGrid3.DisplayLayout.InterBandSpacing = 10;
            this.ultraGrid3.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.ultraGrid3.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.ultraGrid3.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid3.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid3.DisplayLayout.Override.AllowRowLayoutCellSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.ultraGrid3.DisplayLayout.Override.AllowRowLayoutColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.None;
            this.ultraGrid3.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.ultraGrid3.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.ultraGrid3.DisplayLayout.Override.CardAreaAppearance = appearance4;
            this.ultraGrid3.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.ForeColor = System.Drawing.Color.White;
            appearance5.TextHAlignAsString = "Left";
            appearance5.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraGrid3.DisplayLayout.Override.HeaderAppearance = appearance5;
            this.ultraGrid3.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ultraGrid3.DisplayLayout.Override.MaxSelectedRows = 100;
            appearance63.BackColor = System.Drawing.Color.Lavender;
            this.ultraGrid3.DisplayLayout.Override.RowAlternateAppearance = appearance63;
            appearance13.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.ultraGrid3.DisplayLayout.Override.RowAppearance = appearance13;
            this.ultraGrid3.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.ultraGrid3.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance14.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance14.ForeColor = System.Drawing.Color.White;
            this.ultraGrid3.DisplayLayout.Override.RowSelectorAppearance = appearance14;
            this.ultraGrid3.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid3.DisplayLayout.Override.RowSelectorWidth = 12;
            this.ultraGrid3.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance15.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance15.ForeColor = System.Drawing.Color.Black;
            this.ultraGrid3.DisplayLayout.Override.SelectedRowAppearance = appearance15;
            this.ultraGrid3.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ultraGrid3.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ultraGrid3.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.ultraGrid3.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.ultraGrid3.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.ultraGrid3.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ultraGrid3.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ultraGrid3.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.ultraGrid3.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ultraGrid3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid3.Location = new System.Drawing.Point(0, 28);
            this.ultraGrid3.Name = "ultraGrid3";
            this.ultraGrid3.Size = new System.Drawing.Size(196, 49);
            this.ultraGrid3.TabIndex = 41;
            // 
            // ultraStatusBar4
            // 
            appearance17.FontData.BoldAsString = "True";
            appearance17.FontData.Name = "�l�r �S�V�b�N";
            appearance17.FontData.SizeInPoints = 11F;
            this.ultraStatusBar4.Appearance = appearance17;
            this.ultraStatusBar4.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraStatusBar4.Location = new System.Drawing.Point(0, 0);
            this.ultraStatusBar4.Name = "ultraStatusBar4";
            this.ultraStatusBar4.Padding = new Infragistics.Win.UltraWinStatusBar.UIElementMargins(20, 2, 0, 0);
            this.ultraStatusBar4.Size = new System.Drawing.Size(196, 28);
            this.ultraStatusBar4.TabIndex = 40;
            this.ultraStatusBar4.Text = "�o�͌��ʃC���[�W";
            this.ultraStatusBar4.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // ultraTabControl4
            // 
            appearance16.BackColor = System.Drawing.Color.White;
            appearance16.BackColor2 = System.Drawing.Color.AliceBlue;
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultraTabControl4.Appearance = appearance16;
            this.ultraTabControl4.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ultraTabControl4.Location = new System.Drawing.Point(0, 0);
            this.ultraTabControl4.Name = "ultraTabControl4";
            this.ultraTabControl4.SharedControlsPage = this.ultraTabSharedControlsPage7;
            this.ultraTabControl4.Size = new System.Drawing.Size(200, 100);
            this.ultraTabControl4.TabIndex = 0;
            // 
            // ultraTabSharedControlsPage7
            // 
            this.ultraTabSharedControlsPage7.Location = new System.Drawing.Point(2, 21);
            this.ultraTabSharedControlsPage7.Name = "ultraTabSharedControlsPage7";
            this.ultraTabSharedControlsPage7.Size = new System.Drawing.Size(196, 77);
            // 
            // ultraGrid4
            // 
            appearance20.BackColor = System.Drawing.Color.White;
            appearance20.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultraGrid4.DisplayLayout.Appearance = appearance20;
            this.ultraGrid4.DisplayLayout.GroupByBox.Hidden = true;
            this.ultraGrid4.DisplayLayout.InterBandSpacing = 10;
            this.ultraGrid4.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.ultraGrid4.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.ultraGrid4.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.ultraGrid4.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid4.DisplayLayout.Override.AllowRowLayoutCellSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.ultraGrid4.DisplayLayout.Override.AllowRowLayoutColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.None;
            this.ultraGrid4.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.ultraGrid4.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance21.BackColor = System.Drawing.Color.Transparent;
            this.ultraGrid4.DisplayLayout.Override.CardAreaAppearance = appearance21;
            this.ultraGrid4.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance22.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance22.ForeColor = System.Drawing.Color.White;
            appearance22.TextHAlignAsString = "Left";
            appearance22.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraGrid4.DisplayLayout.Override.HeaderAppearance = appearance22;
            this.ultraGrid4.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ultraGrid4.DisplayLayout.Override.MaxSelectedRows = 100;
            appearance23.BackColor = System.Drawing.Color.Lavender;
            this.ultraGrid4.DisplayLayout.Override.RowAlternateAppearance = appearance23;
            appearance24.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.ultraGrid4.DisplayLayout.Override.RowAppearance = appearance24;
            this.ultraGrid4.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.ultraGrid4.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance25.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance25.ForeColor = System.Drawing.Color.White;
            this.ultraGrid4.DisplayLayout.Override.RowSelectorAppearance = appearance25;
            this.ultraGrid4.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.ultraGrid4.DisplayLayout.Override.RowSelectorWidth = 12;
            this.ultraGrid4.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance26.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance26.ForeColor = System.Drawing.Color.Black;
            this.ultraGrid4.DisplayLayout.Override.SelectedRowAppearance = appearance26;
            this.ultraGrid4.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ultraGrid4.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.ultraGrid4.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.ultraGrid4.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.ultraGrid4.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.ultraGrid4.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ultraGrid4.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ultraGrid4.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.ultraGrid4.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ultraGrid4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid4.Location = new System.Drawing.Point(201, 360);
            this.ultraGrid4.Name = "ultraGrid4";
            this.ultraGrid4.Size = new System.Drawing.Size(791, 262);
            this.ultraGrid4.TabIndex = 41;
            // 
            // ultraStatusBar5
            // 
            appearance27.FontData.BoldAsString = "True";
            appearance27.FontData.Name = "�l�r �S�V�b�N";
            appearance27.FontData.SizeInPoints = 11F;
            this.ultraStatusBar5.Appearance = appearance27;
            this.ultraStatusBar5.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraStatusBar5.Location = new System.Drawing.Point(201, 332);
            this.ultraStatusBar5.Name = "ultraStatusBar5";
            this.ultraStatusBar5.Padding = new Infragistics.Win.UltraWinStatusBar.UIElementMargins(20, 2, 0, 0);
            this.ultraStatusBar5.Size = new System.Drawing.Size(791, 28);
            this.ultraStatusBar5.TabIndex = 40;
            this.ultraStatusBar5.Text = "�o�͌��ʃC���[�W";
            this.ultraStatusBar5.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // ultraTabControl5
            // 
            appearance28.BackColor = System.Drawing.Color.White;
            appearance28.BackColor2 = System.Drawing.Color.AliceBlue;
            appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultraTabControl5.Appearance = appearance28;
            this.ultraTabControl5.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ultraTabControl5.Controls.Add(this.ultraTabSharedControlsPage8);
            this.ultraTabControl5.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraTabControl5.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraTabControl5.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.ultraTabControl5.Location = new System.Drawing.Point(201, 0);
            this.ultraTabControl5.Name = "ultraTabControl5";
            this.ultraTabControl5.SharedControlsPage = this.ultraTabSharedControlsPage8;
            this.ultraTabControl5.Size = new System.Drawing.Size(791, 332);
            this.ultraTabControl5.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.ultraTabControl5.TabIndex = 38;
            this.ultraTabControl5.TabPadding = new System.Drawing.Size(3, 3);
            this.ultraTabControl5.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ultraTabControl5.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ultraTabSharedControlsPage8
            // 
            this.ultraTabSharedControlsPage8.Location = new System.Drawing.Point(1, 20);
            this.ultraTabSharedControlsPage8.Name = "ultraTabSharedControlsPage8";
            this.ultraTabSharedControlsPage8.Size = new System.Drawing.Size(789, 311);
            // 
            // ultraTree3
            // 
            this.ultraTree3.Dock = System.Windows.Forms.DockStyle.Left;
            this.ultraTree3.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.ultraTree3.Location = new System.Drawing.Point(0, 0);
            this.ultraTree3.Name = "ultraTree3";
            this.ultraTree3.NodeConnectorColor = System.Drawing.SystemColors.ControlDark;
            this.ultraTree3.SettingsKey = "PMKHN09810UA.ultraTree3";
            this.ultraTree3.Size = new System.Drawing.Size(201, 622);
            this.ultraTree3.TabIndex = 35;
            // 
            // ultraTabPageControl9
            // 
            this.ultraTabPageControl9.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl9.Name = "ultraTabPageControl9";
            this.ultraTabPageControl9.Size = new System.Drawing.Size(1014, 591);
            // 
            // _PMKHN09810UA_Toolbars_Dock_Area_Left
            // 
            this._PMKHN09810UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN09810UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN09810UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._PMKHN09810UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN09810UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 69);
            this._PMKHN09810UA_Toolbars_Dock_Area_Left.Name = "_PMKHN09810UA_Toolbars_Dock_Area_Left";
            this._PMKHN09810UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 621);
            this._PMKHN09810UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // Main_ToolbarsManager
            // 
            this.Main_ToolbarsManager.DesignerFlags = 1;
            this.Main_ToolbarsManager.DockWithinContainer = this;
            this.Main_ToolbarsManager.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.Main_ToolbarsManager.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.Main_ToolbarsManager.SettingsKey = "PMKHN09810UA.Main_ToolbarsManager";
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
            popupMenuTool4,
            popupMenuTool5,
            labelTool1,
            labelTool2,
            labelTool3});
            ultraToolbar1.ShowInToolbarList = false;
            ultraToolbar1.Text = "���C�����j���[";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 1;
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            labelTool4,
            buttonTool2,
            buttonTool3,
            buttonTool4});
            ultraToolbar2.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.BelowImage;
            ultraToolbar2.Text = "�W��";
            this.Main_ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2});
            popupMenuTool6.SharedProps.Caption = "�t�@�C��(&F)";
            popupMenuTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            buttonTool8.InstanceProps.IsFirstInGroup = true;
            popupMenuTool6.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool5,
            buttonTool6,
            buttonTool7,
            buttonTool8});
            popupMenuTool7.SharedProps.Caption = "�c�[��(&T)";
            popupMenuTool7.SharedProps.Visible = false;
            popupMenuTool7.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool9});
            popupMenuTool8.SharedProps.Caption = "�E�B���h�E(&W)";
            labelTool6.SharedProps.Caption = "���O�C���S����";
            labelTool6.SharedProps.ShowInCustomizer = false;
            appearance7.BackColor = System.Drawing.Color.White;
            appearance7.TextHAlignAsString = "Left";
            appearance7.TextVAlignAsString = "Bottom";
            labelTool7.SharedProps.AppearancesSmall.Appearance = appearance7;
            labelTool7.SharedProps.ShowInCustomizer = false;
            labelTool7.SharedProps.Width = 150;
            buttonTool10.SharedProps.Caption = "�I��(&X)";
            buttonTool10.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool10.SharedProps.ShowInCustomizer = false;
            buttonTool11.SharedProps.Caption = "���[�U�[�ݒ�(&C)";
            buttonTool11.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool11.SharedProps.ShowInCustomizer = false;
            labelTool8.SharedProps.Caption = "���ޑI��";
            labelTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            comboBoxTool1.SharedProps.Caption = "���ޑI��";
            buttonTool12.SharedProps.Caption = "���o(&E)";
            buttonTool12.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool13.SharedProps.Caption = "PDF�\��(&V)";
            buttonTool13.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool14.SharedProps.Caption = "���(&P)";
            buttonTool14.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            controlContainerTool1.SharedProps.MaxWidth = 40;
            controlContainerTool1.SharedProps.MinWidth = 40;
            controlContainerTool1.SharedProps.Width = 41;
            labelTool10.SharedProps.Caption = "��";
            labelTool10.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            buttonTool15.SharedProps.Caption = "PDF����ۑ�(&S)";
            buttonTool15.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool15.SharedProps.Enabled = false;
            buttonTool16.SharedProps.Caption = "�e�L�X�g�o��(&O)";
            buttonTool16.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool16.SharedProps.Visible = false;
            buttonTool17.SharedProps.Caption = "����߰�(&O)";
            buttonTool17.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool18.SharedProps.Caption = "���߰�(&I)";
            buttonTool18.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool19.SharedProps.Caption = "�ݒ�(&M)";
            buttonTool19.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.Main_ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool6,
            popupMenuTool7,
            popupMenuTool8,
            popupMenuTool9,
            labelTool5,
            labelTool6,
            labelTool7,
            buttonTool10,
            buttonTool11,
            labelTool8,
            comboBoxTool1,
            buttonTool12,
            buttonTool13,
            buttonTool14,
            labelTool9,
            controlContainerTool1,
            labelTool10,
            buttonTool15,
            buttonTool16,
            buttonTool17,
            buttonTool18,
            buttonTool19});
            this.Main_ToolbarsManager.ToolTipDisplayStyle = Infragistics.Win.UltraWinToolbars.ToolTipDisplayStyle.Standard;
            this.Main_ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.Main_ToolbarsManager_ToolClick);
            this.Main_ToolbarsManager.ToolValueChanged += new Infragistics.Win.UltraWinToolbars.ToolEventHandler(this.Main_ToolbarsManager_ToolValueChanged);
            // 
            // _PMKHN09810UA_Toolbars_Dock_Area_Right
            // 
            this._PMKHN09810UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN09810UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN09810UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._PMKHN09810UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN09810UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1016, 69);
            this._PMKHN09810UA_Toolbars_Dock_Area_Right.Name = "_PMKHN09810UA_Toolbars_Dock_Area_Right";
            this._PMKHN09810UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 621);
            this._PMKHN09810UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _PMKHN09810UA_Toolbars_Dock_Area_Top
            // 
            this._PMKHN09810UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN09810UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN09810UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._PMKHN09810UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN09810UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._PMKHN09810UA_Toolbars_Dock_Area_Top.Name = "_PMKHN09810UA_Toolbars_Dock_Area_Top";
            this._PMKHN09810UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1016, 69);
            this._PMKHN09810UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _PMKHN09810UA_Toolbars_Dock_Area_Bottom
            // 
            this._PMKHN09810UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN09810UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN09810UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._PMKHN09810UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN09810UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 690);
            this._PMKHN09810UA_Toolbars_Dock_Area_Bottom.Name = "_PMKHN09810UA_Toolbars_Dock_Area_Bottom";
            this._PMKHN09810UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1016, 0);
            this._PMKHN09810UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // PMKHN09810UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.ClientSize = new System.Drawing.Size(1016, 713);
            this.Controls.Add(this.Main_UTabControl);
            this.Controls.Add(this._PMKHN09810UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._PMKHN09810UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._PMKHN09810UA_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._PMKHN09810UA_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.Main_StatusBar);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN09810UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "�|���ݒ�G�N�X�|�[�g�E�C���|�[�g";
            this.Load += new System.EventHandler(this.PMKHN09810UA_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PMKHN09810UA_FormClosed);
            this.ultraTabPageControl7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SubExp_UTabControl)).EndInit();
            this.SubExp_UTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StartNavigatorEXPTree)).EndInit();
            this.ultraTabPageControl8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SubImp_UTabControl)).EndInit();
            this.SubImp_UTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StartNavigatorINPTree)).EndInit();
            this.ultraTabPageControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataViewGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_UTabControl)).EndInit();
            this.Sub_UTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_UTabControl)).EndInit();
            this.Main_UTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BindDataSet)).EndInit();
            this.ultraTabPageControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl2)).EndInit();
            this.ultraTabControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTree1)).EndInit();
            this.ultraTabPageControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl3)).EndInit();
            this.ultraTabControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTree2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl1)).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            this.ultraTabPageControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabControl5)).EndInit();
            this.ultraTabControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraTree3)).EndInit();
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
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
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
                //int status = 0;

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

                        // UPD 2018/09/11 �����^�C���p�X���[�h�Ή� ----------->>>>>
                        //_form = new PMKHN09810UA();
                        //System.Windows.Forms.Application.Run(_form);

                        // �����^�C���p�X���[�h����
                        SFCMN00660UA passWordGuide = new SFCMN00660UA();
                        string returnCode;
                        string returnMessage;

                        SFCMN00660UA.CheckPasswordResult result =
                            passWordGuide.ShowPassConfirmDialog(SFCMN00660UA.PassWordTypes.OneTimePassOKNG, string.Empty, string.Empty, out returnCode, out returnMessage);
#if DEBUG
                        result = SFCMN00660UA.CheckPasswordResult.Return_OK;
#endif
                        if (result.Equals(SFCMN00660UA.CheckPasswordResult.Return_OK))
                        {
                            _form = new PMKHN09810UA();
                            System.Windows.Forms.Application.Run(_form);
                        }
                        // UPD 2018/09/11 �����^�C���p�X���[�h�Ή� -----------<<<<<                        
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
        #endregion //Private Enum

        // ===================================================================================== //
        // �v���C�x�[�g�萔
        // ===================================================================================== //
        #region Private Constant
        /// <summary>
        /// �{���W���[���̃v���O����ID
        /// </summary>
        private const string CT_PGID = "PMKHN09810U";

        #region Del 2013.10.28 T.MOTOYAMA
        ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA DEL STA
        // private const string CT_PGNAME = "���[";
        // private const string MAIN_FORM_TITLE = "���["; 
        // 2013.10.28 T.MOTOYAMA DEL END ///////////////////////////////////////////////////////////////////
        #endregion

        ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //        
        private const string CT_PGNAME = "�|���ݒ�G�N�X�|�[�g�E�C���|�[�g";
        private const string MAIN_FORM_TITLE = "�|���ݒ�G�N�X�|�[�g�E�C���|�[�g";
        // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////
                
        private const string NAVIGATOREXPTREE_XML = "PMKHN09810U_Navigator_EXP.DAT";
        private const string NAVIGATORINPTREE_XML = "PMKHN09810U_Navigator_INP.DAT";
        private Hashtable _expFormControlInfoTable = new Hashtable();
        private Hashtable _impFormControlInfoTable = new Hashtable();

        // �N�����[�h�萔   

        private Hashtable _formControlInfoTable = new Hashtable();
        private const string NO0_DEMANDMAIN_TAB = "DEMAND_MAIN_TAB";

        // �c�[���o�[�c�[���L�[�ݒ�
        private const string TOOLBAR_LOGINLABEL_TITLE = "LoginTitle_LabelTool";
        private const string TOOLBAR_LOGINNAMELABEL_KEY = "LoginName_LabelTool";
        private const string TOOLBAR_ENDBUTTON_KEY = "End_ButtonTool";

        private const string TOOLBAR_USERSETUP_KEY = "UserSetUp_ButtonTool";

        private const string TOOLBAR_TEXTOUTPUT_KEY = "TextOutPut_ButtonTool";

        private const string TOOLBAR_WINDOW_KEY = "Window_PopupMenuTool";
        private const string TOOLBAR_FORMS_KEY = "Forms_PopupMenuTool";
        private const string TOOLBAR_RESETBUTTON_KEY = "Reset_ButtonTool";

        private const string TOOLBAR_EXPORTBUTTON_KEY = "Export_ButtonTool";
        private const string TOOLBAR_IMPORTBUTTON_KEY = "Import_ButtonTool";

        private const string TOOLBAR_SETUPBUTTON_KEY = "SetUp_ButtonTool";

        // �r���[�t�H�[���p�ǉ��L�[���(�ΏۃA�Z���u��_VIEWR)
        private const string TAB_VIEWFORM_ADDKEY = "_VIWER";
        #endregion //Private Constant

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region Private Members
        private static string[] _parameter;
        private static System.Windows.Forms.Form _form = null;

        private Point _lastMouseDown;
        private string _tableName;
        private string _employeeName;
        private bool _buttonEnable = true;

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
        /// ÷�ďo�͋��ʏ����I�u�W�F�N�g
        /// </summary>
        private FormattedTextWriter _formattedTextWriter;

        #endregion //Private Members

        // ===============================================================================
        // �f���Q�[�g�C�x���g
        // ===============================================================================
        #region delegateEvent
        /// <summary>
        /// �f���Q�[�g
        /// </summary>
        private void ParentToolbarSettingEvent(object sender)
        {
            this.ToolBarSetting(sender);
        }
        #endregion //delegateEvent

        // ===================================================================================== //
        // �������\�b�h
        // ===================================================================================== //
        #region private method

        /// <summary>
        /// ������ʐݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ������ʐݒ���s���܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
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

            // �|���}�X�^�G�N�X�|�[�g�̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool exportButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXPORTBUTTON_KEY];
            if (exportButton != null)
            {
                exportButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;
                exportButton.SharedProps.Enabled = false;
            }

            // �|���}�X�^�C���|�[�g�̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool importButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_IMPORTBUTTON_KEY];
            if (importButton != null)
            {
                importButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVTAKING;
                importButton.SharedProps.Enabled = false;
            }

            Infragistics.Win.UltraWinToolbars.ButtonTool setupButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SETUPBUTTON_KEY];
            if (setupButton != null)
            {
                setupButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;
                setupButton.SharedProps.Enabled = false;
            }

            // ���[�U�[�ݒ�̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool setUpButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_USERSETUP_KEY];
            if (setUpButton != null) setUpButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;

            // ���O�C����
            Infragistics.Win.UltraWinToolbars.LabelTool LoginName = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_LOGINNAMELABEL_KEY];
            if (LoginName != null && LoginInfoAcquisition.Employee != null)
            {
                Employee employee = new Employee();
                employee = LoginInfoAcquisition.Employee;
                LoginName.SharedProps.Caption = employee.Name;
                this._employeeName = employee.Name;
            }

            // �^�u�R���g���[���̐ݒ�
            this.Sub_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.Sub_UTabControl.InterTabSpacing = 2;
            this.Sub_UTabControl.TabOrientation = Infragistics.Win.UltraWinTabs.TabOrientation.TopLeft;
            this.Sub_UTabControl.Appearance.FontData.SizeInPoints = 11;

            // �^�u�R���g���[���̐ݒ�
            this.SubExp_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.SubExp_UTabControl.InterTabSpacing = 2;
            this.SubExp_UTabControl.TabOrientation = Infragistics.Win.UltraWinTabs.TabOrientation.TopLeft;
            this.SubExp_UTabControl.Appearance.FontData.SizeInPoints = 11;
        }



        /// <summary>
        /// �^�u�N���G�C�g����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �^�u�t�H�[���𐶐����܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void TabCreate(string key)
        {
            FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];

            if (info == null) return;

            // ���Ƀ��[�h�ς݁I
            if (info.Form != null) return;

            this.CreateTabForm(info);
        }

        /// <summary>
        /// �^�u�A�N�e�B�u����
        /// </summary>
        /// <param name="key">�ΏۃL�[���</param>
        /// <param name="form">�A�N�e�B�u�������t�H�[���̃C���X�^���X</param>
        /// <remarks>
        /// <br>Note       : �����̃L�[�������ɁA�^�u���A�N�e�B�u�����܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void TabActive(string key, ref Form form)
        {
            if (this.Sub_UTabControl.Tabs.Exists(key))
            {
                this.Sub_UTabControl.Tabs[key].Visible = true;
                this.Sub_UTabControl.SelectedTab = this.Sub_UTabControl.Tabs[key];

                form = this.Sub_UTabControl.Tabs[key].Tag as System.Windows.Forms.Form;

                // �E�B���h�E�X�e�C�g��ԕύX
                this.CreateWindowStateButtonTools();

                // WindowState�{�^����I����Ԃɂ���
                Infragistics.Win.UltraWinToolbars.PopupMenuTool windowPopupMenuTool = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.Main_ToolbarsManager.Tools[TOOLBAR_WINDOW_KEY];

                for (int i = 0; i < windowPopupMenuTool.Tools.Count; i++)
                {
                    if (!(windowPopupMenuTool.Tools[i] is Infragistics.Win.UltraWinToolbars.StateButtonTool)) continue;

                    Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = (Infragistics.Win.UltraWinToolbars.StateButtonTool)windowPopupMenuTool.Tools[i];

                    if ((this.Sub_UTabControl.SelectedTab != null) && (key == stateButtonTool.Key))
                    {
                        stateButtonTool.Checked = true;
                    }
                    else
                    {
                        stateButtonTool.Checked = false;
                    }
                }
            }
        }

        /// <summary>
        /// Tab�t�H�[����������
        /// </summary>
        /// <param>none</param>
        /// <returns>none</returns>
        /// <remarks>
        /// <br>Note       : MDI�q��ʂ𐶐�����</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private Form CreateTabForm(FormControlInfo info)
        {
            Form form = null;

            form = (System.Windows.Forms.Form)this.LoadAssemblyFrom(info.AssemblyID, info.ClassID, typeof(System.Windows.Forms.Form));

            if (form == null)
            {
                form = new Form();
            }

            if (form != null)
            {
                info.Form = form;

                // �^�u�R���g���[���ɒǉ�����^�u�y�[�W���C���X�^���X������
                Infragistics.Win.UltraWinTabControl.UltraTabPageControl dataviewTabPageControl =
                  new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();

                // �^�u�̊O�ς�ݒ肵�A�^�u�R���g���[���Ƀ^�u��ǉ�����
                Infragistics.Win.UltraWinTabControl.UltraTab dataviewTab = new Infragistics.Win.UltraWinTabControl.UltraTab();

                dataviewTab.TabPage = dataviewTabPageControl;
                dataviewTab.Text = info.Name;
                dataviewTab.Key = info.Key;
                dataviewTab.Tag = form;
                dataviewTab.Appearance.Image = info.Icon;
                dataviewTab.Appearance.BackColor = Color.White;
                dataviewTab.Appearance.BackColor2 = Color.Lavender;
                dataviewTab.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

                dataviewTab.ActiveAppearance.BackColor = Color.White;
                dataviewTab.ActiveAppearance.BackColor2 = Color.LightPink;
                dataviewTab.ActiveAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

#if false
				// �V�X�e���I���C�x���g
				if (form is IPrintConditionInpTypeSelectedSystem)
				{
					this._checkedSystemEvent  += new CheckedSystemEventHandler(((IPrintConditionInpTypeSelectedSystem)form).CheckedSystem);
				}
#endif

                this.Sub_UTabControl.Controls.Add(dataviewTabPageControl);
                this.Sub_UTabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] { dataviewTab });
                this.Sub_UTabControl.SelectedTab = dataviewTab;

                // �t�H�[���v���p�e�B�ύX
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                dataviewTabPageControl.Controls.Add(form);

                // ���o��ʏo��
                form.Show();
                form.Dock = System.Windows.Forms.DockStyle.Fill;
            }

            return form;
        }

        /// <summary>
        /// �c�[���o�[���ڏ�Ԑݒ�
        /// </summary>
        /// <param name="key"></param>
        /// <remarks>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void ToolbarConditionSetting(string key)
        {
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool;

            // �|���}�X�^�G�N�X�|�[�g
            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXPORTBUTTON_KEY];
            if (buttonTool != null) buttonTool.SharedProps.Visible = true;
            // �|���}�X�^�C���|�[�g
            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_IMPORTBUTTON_KEY];
            if (buttonTool != null) buttonTool.SharedProps.Visible = true;

            // �ݒ�
            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SETUPBUTTON_KEY];
            if (buttonTool != null) buttonTool.SharedProps.Visible = true;
        }

        /// <summary>
        /// �r���[�t�H�[���^�u�N���G�C�g����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �r���[�^�u�t�H�[���𐶐����܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void ViewFormTabCreate(string key)
        {
            // �r���[�\�����A�Z���u�����擾
            FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];

            if (info == null) return;

            // ���Ƀ��[�h�ς݁I
            if (info.ViewForm != null) return;

            this.CreateTabForm(info);
        }

        #region ���@�c�[���o�[�̕\���E�L���ݒ�
        /// <summary>
        /// �c�[���o�[�̕\���E�L���ݒ�
        /// </summary>
        /// <param name="activeForm">�A�N�e�B�u�ȃt�H�[���̃I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�̕\���E��\���A�L���E�����ݒ���s���܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void ToolBarSetting(object activeForm)
        {
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool;

            if (activeForm != null)
            {
                if (activeForm is ICSVExportConditionInpType)
                {
                    // �|���}�X�^�G�N�X�|�[�g�{�^��
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXPORTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = true;
                    }
                    // �|���}�X�^�C���|�[�g�{�^��
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_IMPORTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }
                }
                else if (activeForm is ICSVImportConditionInpType)
                {
                    // �|���}�X�^�G�N�X�|�[�g�{�^��
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXPORTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }
                    // �|���}�X�^�C���|�[�g�{�^��
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_IMPORTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = true;
                    }
                }
            }
            else
            {
                // �|���}�X�^�G�N�X�|�[�g
            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXPORTBUTTON_KEY];
            if (buttonTool != null)
            {
                    buttonTool.SharedProps.Enabled = false;
            }
            // �|���}�X�^�C���|�[�g
            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_IMPORTBUTTON_KEY];
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
        /// <br>Note       : �o�͌����̐ݒ���s���܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, CT_PGID, iMsg, iSt, iButton, iDefButton);
        }

        /// <summary>
        /// �c���[�r���[�\��
        /// </summary>
        private void ConstructionTreeNode()
        {
            // �N���i�r�Q�[�^��񂪊i�[���ꂽ�o�C�i���t�@�C���̃��[�h
            if (System.IO.File.Exists(NAVIGATOREXPTREE_XML))
            {
                this.StartNavigatorEXPTree.LoadFromBinary(NAVIGATOREXPTREE_XML);
            }

            // �c���[�̍\�z����
            ConstructTreeNode(StartNavigatorEXPTree);

            // �N���i�r�Q�[�^��񂪊i�[���ꂽ�o�C�i���t�@�C���̃��[�h
            if (System.IO.File.Exists(NAVIGATORINPTREE_XML))
            {
                this.StartNavigatorINPTree.LoadFromBinary(NAVIGATORINPTREE_XML);
            }

            // �c���[�̍\�z����
            ConstructTreeNode(StartNavigatorINPTree);

        }

        /// <summary>
        /// ���쌠���̐�����J�n���܂��B
        /// </summary>
        /// <param name="assemblyId">�A�Z���u��ID</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���쌠���ɉ������{�^������̑Ή�</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void BeginControllingByOperationAuthority(string assemblyId)
        {
            #region <Guard Phrase/>

            if (!MyOpeCtrlMap.ContainsKey(assemblyId)) return;

            #endregion  // <Guard Phrase/>

            // �c�[���{�^���̑��쌠���̐���ݒ�
            List<ToolButtonInfo> toolButtonInfoList = new List<ToolButtonInfo>();

            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_TEXTOUTPUT_KEY, ReportFrameOpeCode.OutputText, false));

            MyOpeCtrlMap[assemblyId].MyOpeCtrl.AddControlItem(this.Main_ToolbarsManager, toolButtonInfoList);

            // ���쌠���̐�����J�n
            MyOpeCtrlMap[assemblyId].MyOpeCtrl.BeginControl();
        }


        #region ���@��������UI��ʌʉ�ʐݒ菈��
        /// <summary>
        /// ��������UI��ʌʉ�ʐݒ菈��
        /// </summary>
        /// <param name="key">�ΏۃL�[���</param>
        /// <param name="activeForm">�A�N�e�B�u�ΏۂƂȂ�Form</param>
        /// <remarks>
        /// <br>Note       : �e������ʌʂ̃t���[����ʂ�ݒ肵�܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void ScreenPrivateSetting(string key, System.Windows.Forms.Form activeForm)
        {
            if (activeForm == null) return;

            // �R���g���[�����擾
            FormControlInfo info = null;
            if (this._formControlInfoTable.ContainsKey(key))
            {
                info = this._formControlInfoTable[key] as FormControlInfo;
            }
            else
            {
                return;
            }

            // ����N�����͂��ꂼ��̏����l�𒠕[���ʗp�t�H�[���R���g���[���N���X�ɐݒ�
            if (!info.IsInit)
            {
                info.SelSectionKindIndex = 0;												// ���_���

                info.SelSystems = info.SoftWareCode;										// �V�X�e���I��                
            }

            //----------------------------------------------------------------------------//
            // ��ʏ��X�V����                                                           //
            //----------------------------------------------------------------------------//


            // �����ݒ�ς�
            info.IsInit = true;
        }
        #endregion

        #region ���@��ʃR���g���[���N���X�쐬����
        /// <summary>
        /// ��ʃR���g���[���N���X�쐬����
        /// </summary>
        /// <returns> </returns>
        /// <remarks>
        /// <br>Note       : �e�������ʂ̃A�Z���u�������쐬���܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private int CreateFormControlInfo()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // �|���}�X�^�G�N�X�|�[�g
            status = this.CreateFormControlInfo2(this.StartNavigatorEXPTree, ref this._expFormControlInfoTable);
            // �|���}�X�^�C���|�[�g
            status = this.CreateFormControlInfo2(this.StartNavigatorINPTree, ref this._impFormControlInfoTable);

            return status;

        }
        #endregion

        #region ���@�����񕪊�����
        /// <summary>
        /// �����񕪊�����
        /// </summary>
        /// <param name="target">�Ώە�����</param>
        /// <param name="id">���������P</param>
        /// <param name="prm">���������Q</param>
        /// <remarks>
        /// <br>Note       : �Ώە�������X�y�[�X�łQ�������܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void SplitTargetAssemblyID(string target, out string id, out string prm)
        {
            id = "";
            prm = "";

            string[] split = target.Split(new Char[] { ' ' });
            if (split != null)
            {
                int i = 0;
                foreach (string wk in split)
                {
                    switch (i)
                    {
                        case 0:		// �A�Z���u��ID
                            {
                                id = wk;
                                break;
                            }
                        default:	// �ďo�p�����[�^
                            {
                                if (prm != "")
                                {
                                    prm += " " + wk;
                                }
                                else
                                {
                                    prm = wk;
                                }
                                break;
                            }
                    }
                    i++;
                }
            }
        }
        #endregion

        #region ���@�w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X������
        /// <summary>
        /// �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X������
        /// </summary>
        /// <param name="asmname">�A�Z���u������</param>
        /// <param name="classname">�N���X����</param>
        /// <param name="type">��������N���X�^</param>
        /// <returns>�C���X�^���X�����ꂽ�N���X</returns>
        /// <remarks>
        /// <br>Note       : MDI�q��ʂ𐶐�����</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private object LoadAssemblyFrom(string asmname, string classname, Type type)
        {
            object obj = null;
            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.LoadFrom(asmname);
                Type objType = asm.GetType(classname);
                if (objType != null)
                {
                    if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
                    {
                        obj = Activator.CreateInstance(objType);
                    }
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                    ex.Message,
                    -1,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
            catch (System.Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                    "Message=" + ex.Message + "\r\n" + "Trace  =" + ex.StackTrace + "\r\n" + "Source =" + ex.Source,
                    -1,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
            return obj;
        }
        #endregion

        #region ���@�E�B���h�E�X�e�[�g�{�^���c�[���\�z����
        /// <summary>
        /// �E�B���h�E�X�e�[�g�{�^���c�[���\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �E�C���h�E�\�ʒu��ԃ{�^�����쐬���܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void CreateWindowStateButtonTools()
        {
            Infragistics.Win.UltraWinToolbars.PopupMenuTool windowPopupMenuTool = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.Main_ToolbarsManager.Tools[TOOLBAR_WINDOW_KEY];
            Infragistics.Win.UltraWinToolbars.PopupMenuTool formsPopupMenuTool = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.Main_ToolbarsManager.Tools[TOOLBAR_FORMS_KEY];

            windowPopupMenuTool.ResetTools();
            formsPopupMenuTool.ResetTools();

            // �u�E�B���h�E��������Ԃɖ߂��v�@�{�^���c�[���ǉ�
            if (!this.Main_ToolbarsManager.Tools.Exists(TOOLBAR_RESETBUTTON_KEY))
            {
                Infragistics.Win.UltraWinToolbars.ButtonTool resetButtonTool = new Infragistics.Win.UltraWinToolbars.ButtonTool(TOOLBAR_RESETBUTTON_KEY);
                resetButtonTool.SharedProps.Caption = "�E�B���h�E��������Ԃɖ߂�(&R)";
                resetButtonTool.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.WindowResetButtonTool_ToolClick);
                this.Main_ToolbarsManager.Tools.Add(resetButtonTool);
            }
            windowPopupMenuTool.Tools.AddTool(TOOLBAR_RESETBUTTON_KEY);

            Infragistics.Win.UltraWinTabControl.UltraTabControl uTabControl = null;
            if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[0])
            {
                uTabControl = this.SubExp_UTabControl;
            }
            else if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[1])
            {
                uTabControl = this.SubImp_UTabControl;
            }

            for (int i = 0; i < uTabControl.Tabs.Count; i++)
            {
                Infragistics.Win.UltraWinTabControl.UltraTab tab = uTabControl.Tabs[i];

                if (!tab.Visible) continue;

                string key = tab.Key;

                if (this.Main_ToolbarsManager.Tools.Exists(key))
                {
                    windowPopupMenuTool.Tools.AddTool(key);
                    formsPopupMenuTool.Tools.AddTool(key);
                }
                else
                {
                    Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = new Infragistics.Win.UltraWinToolbars.StateButtonTool(key, "TabWindow");
                    stateButtonTool.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
                    stateButtonTool.SharedProps.Caption = tab.Text;
                    stateButtonTool.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.WindowStateButtonTool_ToolClick);
                    stateButtonTool.Tag = true;
                    this.Main_ToolbarsManager.Tools.Add(stateButtonTool);

                    windowPopupMenuTool.Tools.AddTool(key);
                    formsPopupMenuTool.Tools.AddTool(key);
                }

                if ((i == 0) && (windowPopupMenuTool.Tools.Exists(key)))
                {
                    Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = (Infragistics.Win.UltraWinToolbars.StateButtonTool)windowPopupMenuTool.Tools[key];
                    stateButtonTool.InstanceProps.IsFirstInGroup = true;
                }
            }
        }
        #endregion

        #region ���@�u�E�B���h�E�������l�ɖ߂��v�{�^���N���b�N���C�x���g
        /// <summary>
        /// �E�B���h�E�X�e�[�g�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �E�B���h�E�X�e�[�g�{�^���N���b�N���ɔ������܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void WindowResetButtonTool_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {

        }
        #endregion

        #region ���@�E�B���h�E�X�e�[�g�{�^���N���b�N�C�x���g
        /// <summary>
        /// �E�B���h�E�X�e�[�g�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �E�B���h�E�X�e�[�g�{�^���N���b�N���ɔ������܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void WindowStateButtonTool_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            if (this.SubExp_UTabControl.Tabs.Exists(e.Tool.Key))
            {
                if (!(e.Tool is Infragistics.Win.UltraWinToolbars.StateButtonTool)) return;

                Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = (Infragistics.Win.UltraWinToolbars.StateButtonTool)e.Tool;
                if (stateButtonTool.Checked)
                {
                    this.SubExp_UTabControl.SelectedTab = this.SubExp_UTabControl.Tabs[e.Tool.Key];

                    this.SubExp_UTabControl.ContextMenu = this.TabControl_contextMenu;
                    Form selectedForm = this._expFormControlInfoTable[this.SubExp_UTabControl.SelectedTab.Key] as Form;


                    if (selectedForm == null)
                    {
                        if (this._expFormControlInfoTable.Contains(this.SubExp_UTabControl.SelectedTab.Key))
                        {
                            FormControlInfo formInfo = this._expFormControlInfoTable[this.SubExp_UTabControl.SelectedTab.Key] as FormControlInfo;
                            if (formInfo != null) selectedForm = formInfo.Form;
                        }
                    }

                }
            }
            else if (this.SubImp_UTabControl.Tabs.Exists(e.Tool.Key))
            {
                if (!(e.Tool is Infragistics.Win.UltraWinToolbars.StateButtonTool)) return;

                Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = (Infragistics.Win.UltraWinToolbars.StateButtonTool)e.Tool;
                if (stateButtonTool.Checked)
                {
                    this.SubImp_UTabControl.SelectedTab = this.SubImp_UTabControl.Tabs[e.Tool.Key];

                    this.SubImp_UTabControl.ContextMenu = this.TabControl_contextMenu;
                    Form selectedForm = this._impFormControlInfoTable[this.SubImp_UTabControl.SelectedTab.Key] as Form;


                    if (selectedForm == null)
                    {
                        if (this._impFormControlInfoTable.Contains(this.SubImp_UTabControl.SelectedTab.Key))
                        {
                            FormControlInfo formInfo = this._impFormControlInfoTable[this.SubImp_UTabControl.SelectedTab.Key] as FormControlInfo;
                            if (formInfo != null) selectedForm = formInfo.Form;
                        }
                    }

                }
            }
        }
        #endregion // ���@�E�B���h�E�X�e�[�g�{�^���N���b�N�C�x���g

        #region ���@�^�u�\���E��\������
        /// <summary>
        /// �^�u�\���^��\��������
        /// </summary>
        /// <param name="key">�L�[</param>
        /// <param name="hidden">true:�\�� false:��\��</param>
        /// <remarks>
        /// <br>Note       : �^�u�̕\���^��\���𐧌䂵�܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void TabVisibleChange(string key, bool visible)
        {
            for (int i = 0; i < this.Sub_UTabControl.Tabs.Count; i++)
            {
                Infragistics.Win.UltraWinTabControl.UltraTab tab = this.Sub_UTabControl.Tabs[i];

                if (tab.Key == key)
                {
                    tab.Visible = visible;
                    this.NodeSelectChaneg(key, visible);
                }
            }

            for (int i = 0; i < this.SubExp_UTabControl.Tabs.Count; i++)
            {
                Infragistics.Win.UltraWinTabControl.UltraTab tab = this.SubExp_UTabControl.Tabs[i];

                if (tab.Key == key)
                {
                    tab.Visible = visible;
                    this.NodeSelectChaneg(key, visible);
                }
            }

            for (int i = 0; i < this.SubImp_UTabControl.Tabs.Count; i++)
            {
                Infragistics.Win.UltraWinTabControl.UltraTab tab = this.SubImp_UTabControl.Tabs[i];

                if (tab.Key == key)
                {
                    tab.Visible = visible;
                    this.NodeSelectChaneg(key, visible);
                }
            }
        }
        #endregion

        #region ���@�i�r�Q�[�V�����̊Y���L�[�m�[�h�I����ԕύX
        /// <summary>
        /// �i�r�Q�[�V�����̊Y���L�[�m�[�h�I����ԕύX
        /// </summary>
        /// <param name="key">�L�[</param>
        /// <remarks>
        /// <br>Note       : �i�r�Q�[�V�����̊Y���L�[�m�[�h�I����Ԃ𐧌䂵�܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void NodeSelectChaneg(string key, bool isSelected)
        {
            // �Y���L�[�̃m�[�h���擾
            Infragistics.Win.UltraWinTree.UltraTreeNode node = null;
            if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[0])
            {
                node = this.StartNavigatorEXPTree.GetNodeByKey(key);
            }
            else if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[1])
            {
                node = this.StartNavigatorINPTree.GetNodeByKey(key);
            }

            if (node != null)
            {
                if (isSelected)
                {
                    node.Override.NodeAppearance.ForeColor = Color.Red;
                }
                else
                {
                    node.Override.NodeAppearance.ForeColor = Color.Black;
                }
            }
        }
        #endregion

        /// <summary>
        /// �����ݒ�f�[�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����ݒ�f�[�^�̓Ǎ����s���܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private int InitalDataRead()
        {

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
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
        /// <br>Note       : ���C���t���[����LOAD������</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void PMKHN09810UA_Load(object sender, System.EventArgs e)
        {
            // ������ʐݒ�
            this.InitialScreenSetting();

            // �^�C�g���ݒ�
            this.Text = MAIN_FORM_TITLE;

            // �N���i�r�Q�[�^�[�\�z
            this.ConstructionTreeNode();

            // �E�C���h�E�{�^���쐬����
            this.CreateWindowStateButtonTools();

            int status;
            // �v���O�������e�[�u���\�z
            status = this.CreateFormControlInfo();

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                    "�N���p�����[�^���s���ł��B!!",//ahn
                    -1,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);

                this.Close();
                return;
            }

            this.ToolbarConditionSetting(NO0_DEMANDMAIN_TAB);

            // ���쌠������
            if (!MyOpeCtrlMap.ContainsKey(CT_PGID))
            {
                if (!OpeAuthCtrlFacade.CanRunWithInitializing(
                    EntityUtil.CategoryCode.Report,
                    MyOpeCtrlMap.AddController(CT_PGID),
                    CT_PGID,
                    CT_PGNAME
                ))
                {
                    this.Close();   // �N���s�̂��ߋ����I��
                }
            }

            BeginControllingByOperationAuthority(CT_PGID);
        }

        /// <summary>
        /// ���������^�C�}�[�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �����^�C�}�[�C�x���g�ł��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            try
            {

                // �����ݒ�f�[�^�Ǎ�
                int status = this.InitalDataRead();
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.Close();
                    return;
                }

                this.TabCreate(NO0_DEMANDMAIN_TAB);

            }
            finally
            {

            }
        }

        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : �c�[���o�[�N���b�N���ɔ������܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void Main_ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            if (_buttonEnable)
            {
                switch (e.Tool.Key)
                {
                    case TOOLBAR_ENDBUTTON_KEY:
                        {
                            this.Close();
                            break;
                        }

                    // �e�L�X�g�ϊ�
                    case TOOLBAR_EXPORTBUTTON_KEY:
                        {
                            _buttonEnable = false;
                            

                            // �A�N�e�B�u��Ԃ̃^�u����t�H�[�����擾����
                            FormControlInfo formControlInfo = (FormControlInfo)this._expFormControlInfoTable[this.SubExp_UTabControl.ActiveTab.Key.ToString()];
                            System.Windows.Forms.Form activeForm = formControlInfo.Form;

                            if (activeForm is ICSVExportConditionInpType)
                            {
                                ICSVExportConditionInpType childObj = activeForm as ICSVExportConditionInpType;

                                // �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾����			
                                DataSet bindDataSet = new DataSet();
                                childObj.GetBindDataSet(ref bindDataSet, ref this._tableName);
                                this.BindDataSet = bindDataSet;

                                //// ���o�f�[�^�擾
                                int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                                Dictionary<string, object> dParam = new Dictionary<string, object>();
                                dParam.Add("LoginSectionCode", LoginInfoAcquisition.Employee.BelongSectionCode.ToString());
                                DateTime systemDate = Convert.ToDateTime(this.Main_StatusBar.Panels["Date"].DisplayText);
                                dParam.Add("SystemDate", systemDate);
                                dParam.Add("SystemYearMonth", systemDate.Year * 100 + systemDate.Month);
                                dParam.Add("SystemYear", systemDate.Year);
                                dParam.Add("SystemMonth", systemDate.Month);
                                dParam.Add("SystemDay", systemDate.Day);
                                Object parameter = dParam;
                                
                                // ���o�O�`�F�b�N
                                if (!childObj.ExportBeforeCheck())
                                {
                                    _buttonEnable = true;
                                    return;
                                }
                                SFCMN00299CA formexport = new Broadleaf.Windows.Forms.SFCMN00299CA();
                                dParam.Add("formexport", formexport);
                                // �\��������ݒ�
                                formexport.Title = "�e�L�X�g�ϊ���";
                                formexport.Message = "���݁A�f�[�^���e�L�X�g�ϊ����ł��B";

                                // �_�C�A���O�\��
                                formexport.Show();
                                this.Cursor = Cursors.WaitCursor;

                                status = childObj.Extract(ref parameter);

                                switch (status)
                                {
                                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                                        {
                                            if (this.BindDataSet.Tables[this._tableName].DefaultView.Count <= 0)
                                            {
                                                // �_�C�A���O�����
                                                this.Cursor = Cursors.Default;
                                                formexport.Close();
                                                TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���B", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                                                break;
                                            }

                                            ArrayList paramList = new ArrayList();
                                            object csvParam = paramList;

                                            // CSV�o�͏�񏈗�
                                            status = childObj.GetCSVInfo(ref csvParam);

                                            // �o�͊����ꍇ
                                            if (status == 0)
                                            {
                                                childObj.AfterExportSuccess();
                                            }

                                            // CSV�o�͏���
                                            status = this.DoOutPut(ref csvParam);

                                            // �_�C�A���O�����
                                            this.Cursor = Cursors.Default;
                                            formexport.Close();

                                            string resultMessage = string.Empty;

                                            switch (status)
                                            {
                                                case 0:    // ��������
                                                    resultMessage = "CSV�f�[�^���쐬���܂����B";
                                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, CT_PGID, resultMessage, status, MessageBoxButtons.OK);
                                                    break;
                                                default:    // ���̑��G���[
                                                    resultMessage = "�e�L�X�g�t�@�C���̏������݂Ɏ��s���܂����B";
                                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOP, CT_PGID, resultMessage, 9, MessageBoxButtons.OK);
                                                    break;
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
                            _buttonEnable = true;
                            //_reLoad = true;
                            break;
                        }
                    // �e�L�X�g�擾
                    case TOOLBAR_IMPORTBUTTON_KEY:
                        {
                            _buttonEnable = false;
                            // �A�N�e�B�u��Ԃ̃^�u����t�H�[�����擾����
                            FormControlInfo formControlInfo = (FormControlInfo)this._impFormControlInfoTable[this.SubImp_UTabControl.ActiveTab.Key.ToString()];
                            System.Windows.Forms.Form activeForm = formControlInfo.Form;

                            if (activeForm is ICSVImportConditionInpType)
                            {
                                ICSVImportConditionInpType childObj = activeForm as ICSVImportConditionInpType;

                                // CSV�t�@�C�����X�g
                                List<string[]> csvDataList = new List<string[]>();

                                // CSV�t�@�C����
                                string csvFileName = childObj.ImportFileName();

                                // �C���|�[�g�O�̃`�F�b�N����
                                if (childObj.IsUseBaseCheck())
                                {
                                    // �G���[���b�Z�[�W
                                    string errMsg = string.Empty;

                                    if (!CheckInputFileName(csvFileName, out errMsg) ||
                                        !CheckInputFileExists(csvFileName, out errMsg))
                                    {
                                        // �t�H�[�J�X�̐ݒ�
                                        childObj.CheckErrEvent();
                                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, errMsg, 0, MessageBoxButtons.OK);
                                        _buttonEnable = true;
                                        return;
                                    }
                                    bool isReadErr = false;
                                    if (!CheckInputFileDataExists(csvFileName, out errMsg, out csvDataList, out isReadErr))
                                    {
                                        // �t�H�[�J�X�̐ݒ�
                                        childObj.CheckErrEvent();
                                        if (isReadErr)
                                        {
                                            // �Ǎ��G���[
                                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, errMsg, 0, MessageBoxButtons.OK);
                                            
                                        }
                                        else
                                        {
                                            if (csvDataList.Count == 0)
                                            {
                                                // ���R�[�h���Ȃ�
                                                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, CT_PGID, errMsg, 0, MessageBoxButtons.OK);
                                            }
                                        }
                                        _buttonEnable = true;
                                        return;
                                    }                                    
                                    // CSV�擪�s���ڐ��`�F�b�N
                                    if (csvDataList.Count > 0)
                                    {

                                        ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
                                        if (!CheckCSVextension(csvFileName, out errMsg))
                                        {
                                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, errMsg, 0, MessageBoxButtons.OK);
                                            _buttonEnable = true;
                                            return;
                                        }
                                        // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////
                                        
                                        if (!childObj.ItemCntCheck(csvDataList[0].Length))
                                        {
                                            errMsg = "�捞�ΏۊO�̃t�@�C���ł��B";
                                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, errMsg, 0, MessageBoxButtons.OK);
                                            _buttonEnable = true;
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    // �q��ʂ̃`�F�b�N����
                                    if (!childObj.ImportBeforeCheck())
                                    {
                                        _buttonEnable = true;
                                        return;
                                    }
                                }

                                int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

                                try
                                {
                                    // �q��ʂ̃C���|�[�g����
                                    status = childObj.Import(csvDataList);
                                }
                                catch (Exception ex)
                                {
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, CT_PGID, ex.Message, status, MessageBoxButtons.OK);
                                }
                                finally
                                {
                                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                    {
                                        if (System.IO.File.Exists(csvFileName) == true)
                                        {
                                            // �o�^������Ɋ��������ꍇ�͎捞����CSV�t�@�C�����폜����
                                            try
                                            {
                                                //System.IO.File.Delete(csvFileName);
                                            }
                                            catch
                                            {
                                            }
                                        }

                                        // �o�^�����_�C�A���O
                                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                                        dialog.ShowDialog(2);
                                    }
                                }
                            }
                            _buttonEnable = true;
                            break;
                        }
                }
            }
        }


        /// <summary>
        /// �c�[���o�[�̍��ڒl�ύX�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �c�[���o�[���ڂ̒l���ύX���ꂽ�ۂɔ������܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void Main_ToolbarsManager_ToolValueChanged(object sender, Infragistics.Win.UltraWinToolbars.ToolEventArgs e)
        {

        }

        /// <summary>
        /// �^�u�I���㏈��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �^�u�I����ɔ�������C�x���g�ł��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void Sub_UTabControl_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {

            this.DataViewGrid.DataSource = null;

#if CHG20060417
            if (e.Tab == null) return;

            if (!this._formControlInfoTable.Contains(e.Tab.Key))
            {
                return;
            }

            string key = e.Tab.Key;
            FormControlInfo info = this._formControlInfoTable[key] as FormControlInfo;
            Form target = info.Form;

            this.TabActive(key, ref target);

            this.ToolBarSetting(target);
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
        /// <br>Note       : �t�H�[��������ꂽ��ɁA�������܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void PMKHN09810UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                //this._eventDoFlag = false;

                foreach (Infragistics.Win.UltraWinTabControl.UltraTab tab in this.Sub_UTabControl.Tabs)
                {
                    this.Sub_UTabControl.Tabs.Remove(tab);
                }

                foreach (Infragistics.Win.UltraWinTabControl.UltraTab tab in this.SubExp_UTabControl.Tabs)
                {
                    this.SubExp_UTabControl.Tabs.Remove(tab);
                }

                foreach (Infragistics.Win.UltraWinTabControl.UltraTab tab in this.SubImp_UTabControl.Tabs)
                {
                    this.SubImp_UTabControl.Tabs.Remove(tab);
                }

            }
            finally
            {
                
            }
        }

        /// <summary>
        /// �|�b�v���j���[�u����v�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note        : �u����v�{�^���������ɔ������܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void Close_menuItem_Click(object sender, System.EventArgs e)
        {
            Infragistics.Win.UltraWinTabControl.UltraTabControl uTabControl = null;

            if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[0])
            {
                uTabControl = this.SubExp_UTabControl;
            }
            else if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[1])
            {
                uTabControl = this.SubImp_UTabControl;
            }

            if (uTabControl.ActiveTab == null) return;

            string key = uTabControl.ActiveTab.Key;

            // �^�u�\���ύX
            this.TabVisibleChange(key, false);

            // �E�B���h�E�X�e�[�g�{�^���c�[���\�z����
            this.CreateWindowStateButtonTools();


            if (uTabControl.Tabs.Count == 0)
            {
                this.ToolBarSetting(null);
            }
            else
            {
                this.ToolBarSetting(uTabControl.ActiveTab);
            }
        }


        /// <summary>
        /// ���C���^�O�I����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_UTabControl_Click(object sender, System.EventArgs e)
        {
            
        }
        #endregion // control event

        #region private method
        /// <summary>
        /// �c���[�̍\�z����
        /// </summary>
        /// <param name="tree">�c���[</param>
        /// <remarks>
        /// <br>Note       : �c���[�̍\�z�������s���܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void ConstructTreeNode(Infragistics.Win.UltraWinTree.UltraTree tree)
        {
            tree.Appearance.BackColor = Color.White;
            tree.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(222)), ((System.Byte)(239)), ((System.Byte)(255)));
            tree.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            tree.HideSelection = false;
            bool firstNode = true;

            Hashtable delNode2KeyLst = new Hashtable();
            Hashtable delNode3KeyLst = new Hashtable();

            // �m�[�h�̕\����\���𐧌䂷��
            if (_parameter.Length != 0)
            {
                // �I���m�[�h��擪�Ɉړ�������
                firstNode = tree.PerformAction(
                    Infragistics.Win.UltraWinTree.UltraTreeAction.FirstNode,
                    false,
                    false);

                if (!firstNode)
                {
                    return;
                }

                //----------------------------------------------------------------------------//
                // �����V�X�e���̃`�F�b�N                                                     //
                //----------------------------------------------------------------------------//
                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn1 in tree.Nodes)
                {
                    if (utn1.Nodes.Count != 0)
                    {
                        foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn2 in utn1.Nodes)
                        {
                            if (utn2.Nodes.Count != 0)
                            {
                                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn3 in utn2.Nodes)
                                {
                                    utn3.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.Standard;
                                    bool nodeVisible = false;
                                    string productCodes = "";
                                    if (utn3.Override.NodeAppearance.Tag != null)
                                    {
                                        productCodes = utn3.Override.NodeAppearance.Tag.ToString();
                                    }

                                    string[] split = productCodes.Split(new Char[] { ' ' });

                                    foreach (string productCode in split)
                                    {
                                        if ((productCode != null) && (productCode.Trim() != ""))
                                        {
                                            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(productCode) > 0)
                                            {
                                                nodeVisible = true;
                                                break;
                                            }
                                        }
                                    }
                                    if (!nodeVisible)
                                    {
                                        if (!delNode3KeyLst.ContainsKey(utn3.Key))
                                        {
                                            delNode3KeyLst.Add(utn3.Key, utn3);
                                        }
                                    }
                                }

                                if (utn2.Nodes.Count == 0)
                                {
                                    if (!delNode2KeyLst.ContainsKey(utn2.Key))
                                    {
                                        delNode2KeyLst.Add(utn2.Key, utn2);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //----------------------------------------------------------------------------//
            // �O���[�v�̕\����\���𐧌䂷��                                             //
            //----------------------------------------------------------------------------//
            // �I���m�[�h��擪�Ɉړ�������
            firstNode = tree.PerformAction(
                Infragistics.Win.UltraWinTree.UltraTreeAction.FirstNode,
                false,
                false);

            if (!firstNode)
            {
                return;
            }


            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn1 in tree.Nodes)
            {
                if (utn1.Nodes.Count != 0)
                {
                    utn1.Expanded = true;

                    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn2 in utn1.Nodes)
                    {
                        bool utn2DeleteFlg = true;

                        // �p�����[�^���󔒂̏ꍇ�͑S�m�[�h��\������i�f���o�����ɂ͔�\���Ƃ���j
                        if (_parameter.Length == 0)
                        {
                            utn2DeleteFlg = false;
                        }
                        else
                        {
                            // Key�l��null�̏ꍇ�͔�\���Ƃ���
                            if (utn2.Key != null)
                            {

                                for (int i = 0; i < _parameter.Length; i++)
                                {
                                    //----------------------------------------------------------------------------//
                                    // �p�����[�^��100�Ŋ������]��ɂ��A�O���[�v�N�����P�̋N��������            //
                                    // �[���Ȃ��F�O���[�v                                                         //
                                    // �[������F�P��(���������݂���ꍇ�͐e�O���[�v���\��)                       //
                                    //----------------------------------------------------------------------------//
                                    string strPara = PMKHN09810UA._parameter[i];
                                    int intPara = TStrConv.StrToIntDef(PMKHN09810UA._parameter[i], -1);

                                    if ((intPara % 100) != 0)
                                    {
                                        intPara = (intPara / 100) * 100;
                                        strPara = intPara.ToString();
                                    }
                                    if (utn2.Key.ToString() == strPara)
                                    {
                                        utn2DeleteFlg = false;
                                        break;
                                    }
                                }
                            }
                        }

                        if (utn2DeleteFlg == true)
                        {
                            if (!delNode2KeyLst.ContainsKey(utn2.Key))
                            {
                                delNode2KeyLst.Add(utn2.Key, utn2);
                            }
                        }
                        else
                        {
                            if (utn2.Nodes.Count != 0)
                            {
                                // �p�����[�^���󔒈ȊO�ꍇ�̓m�[�h��W�J����
                                if (_parameter.Length != 0)
                                {
                                    utn2.Expanded = true;
                                }

                                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn3 in utn2.Nodes)
                                {
                                    utn3.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.Standard;
                                    bool utn3DeleteFlg = true;

                                    // �p�����[�^���󔒂̏ꍇ�͑S�m�[�h��\������i�f���o�����ɂ͔�\���Ƃ���j
                                    if (_parameter.Length == 0)
                                    {
                                        utn3DeleteFlg = false;
                                    }

                                    // Key�l��null�̏ꍇ�͔�\���Ƃ���
                                    if (utn3.Key != null)
                                    {
                                        for (int i = 0; i < _parameter.Length; i++)
                                        {

                                            //----------------------------------------------------------------------------//
                                            // �p�����[�^��100�Ŋ������]��ɂ��A�O���[�v�N�����P�̋N��������            //
                                            // �[���Ȃ��F�O���[�v                                                         //
                                            // �[������F�P��(���������݂���ꍇ�͐e�O���[�v���\��)                       //
                                            //----------------------------------------------------------------------------//
                                            string strPara = PMKHN09810UA._parameter[i];
                                            int intPara = TStrConv.StrToIntDef(PMKHN09810UA._parameter[i], -1);

                                            if ((intPara % 100) != 0)
                                            {
                                                if (utn3.Key.ToString() == strPara)
                                                {
                                                    utn3DeleteFlg = false;
                                                    utn3.Override.NodeAppearance.ForeColor = Color.Blue;
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                utn3DeleteFlg = false;
                                                utn3.Override.NodeAppearance.ForeColor = Color.Blue;
                                                break;
                                            }
                                        }
                                    }

                                    if (utn3.Override.NodeAppearance.Tag != null)
                                    {
                                        string productCodes = utn3.Override.NodeAppearance.Tag.ToString();
                                        string[] split = productCodes.Split(new Char[] { ' ' });

                                        foreach (string productCode in split)
                                        {
                                            if (( productCode != null ) && ( productCode.Trim() != "" ))
                                            {
                                                // USB�`�F�b�N
                                                if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(productCode) > 0)
                                                {
                                                    break;
                                                }
                                                else
                                                {
                                                    utn3DeleteFlg = true;
                                                }
                                            }
                                        }
                                    }

                                    if (utn3DeleteFlg == true)
                                    {
                                        if (!delNode3KeyLst.ContainsKey(utn3.Key))
                                        {
                                            delNode3KeyLst.Add(utn3.Key, utn3);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // ��O�K�w���폜
            foreach (DictionaryEntry entry in delNode3KeyLst)
            {
                // �폜�Ώۃm�[�h
                Infragistics.Win.UltraWinTree.UltraTreeNode utn = (Infragistics.Win.UltraWinTree.UltraTreeNode)entry.Value;

                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn1 in tree.Nodes)
                {
                    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn2 in utn1.Nodes)
                    {
                        if (utn.Parent.Key == utn2.Key)
                        {
                            utn2.Nodes.Remove(utn);
                            break;
                        }
                    }
                }
            }

            // ���K�w���폜
            foreach (DictionaryEntry entry in delNode2KeyLst)
            {
                // �폜�Ώۃm�[�h
                Infragistics.Win.UltraWinTree.UltraTreeNode utn = (Infragistics.Win.UltraWinTree.UltraTreeNode)entry.Value;

                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn1 in tree.Nodes)
                {
                    utn1.Nodes.Remove(utn);
                }
            }

            tree.ExpandAll();
        }

        /// <summary>
        /// �ݒ�{�^���𑀍�\�ɂ��邩�ǂ������f���܂��B
        /// </summary>
        /// <param name="fileName"></param>
        private void SetUpButtonToolEnable(string fileName)
        {
            Infragistics.Win.UltraWinToolbars.ButtonTool setupButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SETUPBUTTON_KEY];
            if (setupButton != null)
            {

                setupButton.SharedProps.Enabled = false;
                if (fileName.Contains("PMKHN07630U"))
                {
                    setupButton.SharedProps.Enabled = true;
                }
            }
        }

        # region ���@��ʃR���g���[���N���X�쐬����
        /// <summary>
        /// ��ʃR���g���[���N���X�쐬����
        /// </summary>
        /// <param name="tree">�c���[</param>
        /// <param name="hashTable">�e�[�u��</param>
        /// <returns> </returns>
        /// <remarks>
        /// <br>Note       : �e�������ʂ̃A�Z���u�������쐬���܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private int CreateFormControlInfo2(Infragistics.Win.UltraWinTree.UltraTree tree, ref Hashtable hashTable)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            if (tree.Nodes.Count == 0) return status;

            hashTable.Clear();

            FormControlInfo info = null;

            // �I���m�[�h��擪�Ɉړ�������
            bool result = tree.PerformAction(
                Infragistics.Win.UltraWinTree.UltraTreeAction.FirstNode,
                false,
                false);
            if (!result)
            {
                return status;
            }

            // �c���[�̃m�[�h�������ɁA�v���O�������R���N�V�����N���X���\�z����

            // �c���[�̃m�[�h���擾������͈ȉ��̒ʂ�
            // [DataKey:�A�Z���u������]
            // [Override.Tag:�N���X������]
            // [Text:�v���O��������]
            // [Tag:���䋒�_�R�[�h]
            // [Tag:���䋒�_�R�[�h]

            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn1 in tree.Nodes)
            {
                if (utn1.Nodes.Count != 0)
                {
                    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn2 in utn1.Nodes)
                    {
                        if (utn2.Nodes.Count != 0)
                        {
                            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn3 in utn2.Nodes)
                            {
                                utn3.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.Standard;
                                if (utn3.DataKey != null && utn3.DataKey.ToString().Trim() != "")
                                {
                                    // �A�Z���u��ID,�p�����[�^
                                    string target = utn3.DataKey.ToString();
                                    string assemblyID;
                                    string param;

                                    this.SplitTargetAssemblyID(target, out assemblyID, out param);
                                    // ����R�[�h
                                    int ctrlFuncCode = 0;
                                    if (utn3.Tag != null)
                                    {
                                        ctrlFuncCode = TStrConv.StrToIntDef(utn3.Tag.ToString(), 0);
                                    }

                                    // �I���\�V�X�e�����̎擾
                                    string productCodes = "";
                                    if (utn3.Override.NodeAppearance.Tag != null)
                                    {
                                        productCodes = utn3.Override.NodeAppearance.Tag.ToString();
                                    }

                                    string[] split = productCodes.Split(new Char[] { ' ' });
                                    List<int> softWareCodeList = new List<int>(split.Length);

                                    foreach (string productCode in split)
                                    {
                                        if ((productCode != null) && (productCode.Trim() != ""))
                                        {
                                            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(productCode) > 0)
                                            {
                                                switch (productCode)
                                                {
                                                    case ConstantManagement_SF_PRO.SoftwareCode_PAC_SF:
                                                        softWareCodeList.Add(1);
                                                        break;
                                                    case ConstantManagement_SF_PRO.SoftwareCode_PAC_BK:
                                                        softWareCodeList.Add(2);
                                                        break;
                                                    case ConstantManagement_SF_PRO.SoftwareCode_PAC_CS:
                                                        softWareCodeList.Add(3);
                                                        break;
                                                }
                                            }
                                        }
                                    }

                                    // �^�u�ɕ\������t�H�[���N���X�̏����\�z����
                                    info = new FormControlInfo(utn3.DataKey.ToString(),
                                        assemblyID,
                                        utn3.Override.Tag.ToString(),
                                        utn3.Text,
                                        utn3.Override.NodeAppearance.Image,
                                        ctrlFuncCode,
                                        param,
                                        softWareCodeList.ToArray());

                                    hashTable.Add(utn3.DataKey.ToString(), info);

                                    info = new FormControlInfo(utn3.DataKey.ToString() + "PREVIEW",
                                        assemblyID,
                                        utn3.Override.Tag.ToString(),
                                        utn3.Text + "�v���r���[",
                                        utn3.Override.NodeAppearance.Image,
                                        ctrlFuncCode,
                                        param,
                                        softWareCodeList.ToArray());

                                    hashTable.Add(utn3.DataKey.ToString() + "PREVIEW", info);

                                    utn3.Key = utn3.DataKey.ToString();
                                }
                            }
                        }
                    }
                }
            }

            // �v���O�������͐ݒ肳��Ă��邩
            status = (hashTable.Count == 0 ? (int)ConstantManagement.MethodResult.ctFNC_ERROR : (int)ConstantManagement.MethodResult.ctFNC_NORMAL);
            return status;
        }
        # endregion

        #region ���@�e���������t�h�N���X�N������
        /// <summary>
        /// �eUI��ʋN������
        /// </summary>
        /// <param name="key">�ΏۃL�[���</param>
        /// <remarks>
        /// <br>Note       : �����̃L�[�������ɁA�^�u���A�N�e�B�u�����܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void ShowChildExpInputForm(string key)
        {
            Cursor nowCursor = this.Cursor;
            System.Windows.Forms.Form childForm = null;


            try
            {
                // �N���q��ʍ쐬����
                this.TabCreate2(key);

                // �N���q��ʃA�N�e�B�u������		
                this.TabActive2(key, ref childForm);

                // �c�[���o�[�Z�b�e�B���O
                this.ToolBarSetting(childForm);

                // ���C���t���[���̌ʉ�ʐݒ�
                this.ScreenPrivateSetting(key, childForm);
            }
            finally
            {
                this.Cursor = nowCursor;
            }
        }

        /// <summary>
        /// �^�u�N���G�C�g����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �^�u�t�H�[���𐶐����܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void TabCreate2(string key)
        {
            FormControlInfo info = null;
            if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[0])
            {
                info = (FormControlInfo)this._expFormControlInfoTable[key];
            }
            else if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[1])
            {
                info = (FormControlInfo)this._impFormControlInfoTable[key];
            }

            if (info == null) return;

            // ���Ƀ��[�h�ς݁I
            if (info.Form != null) return;

            this.CreateTabForm2(info);
        }

        /// <summary>
        /// �^�u�A�N�e�B�u����
        /// </summary>
        /// <param name="key">�ΏۃL�[���</param>
        /// <param name="form">�A�N�e�B�u�������t�H�[���̃C���X�^���X</param>
        /// <remarks>
        /// <br>Note       : �����̃L�[�������ɁA�^�u���A�N�e�B�u�����܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void TabActive2(string key, ref Form form)
        {
            if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[0])
            {
                if (this.SubExp_UTabControl.Tabs.Exists(key))
                {
                    this.SubExp_UTabControl.Tabs[key].Visible = true;
                    this.SubExp_UTabControl.SelectedTab = this.SubExp_UTabControl.Tabs[key];

                    form = this.SubExp_UTabControl.Tabs[key].Tag as System.Windows.Forms.Form;

                    // �E�B���h�E�X�e�C�g��ԕύX
                    this.CreateWindowStateButtonTools();

                    // WindowState�{�^����I����Ԃɂ���
                    Infragistics.Win.UltraWinToolbars.PopupMenuTool windowPopupMenuTool = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.Main_ToolbarsManager.Tools[TOOLBAR_WINDOW_KEY];

                    for (int i = 0; i < windowPopupMenuTool.Tools.Count; i++)
                    {
                        if (!(windowPopupMenuTool.Tools[i] is Infragistics.Win.UltraWinToolbars.StateButtonTool)) continue;

                        Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = (Infragistics.Win.UltraWinToolbars.StateButtonTool)windowPopupMenuTool.Tools[i];

                        if ((this.SubExp_UTabControl.SelectedTab != null) && (key == stateButtonTool.Key))
                        {
                            stateButtonTool.Checked = true;
                        }
                        else
                        {
                            stateButtonTool.Checked = false;
                        }
                    }
                }
            }
            else if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[1])
            {
                if (this.SubImp_UTabControl.Tabs.Exists(key))
                {
                    this.SubImp_UTabControl.Tabs[key].Visible = true;
                    this.SubImp_UTabControl.SelectedTab = this.SubImp_UTabControl.Tabs[key];

                    form = this.SubImp_UTabControl.Tabs[key].Tag as System.Windows.Forms.Form;

                    // �E�B���h�E�X�e�C�g��ԕύX
                    this.CreateWindowStateButtonTools();

                    // WindowState�{�^����I����Ԃɂ���
                    Infragistics.Win.UltraWinToolbars.PopupMenuTool windowPopupMenuTool = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.Main_ToolbarsManager.Tools[TOOLBAR_WINDOW_KEY];

                    for (int i = 0; i < windowPopupMenuTool.Tools.Count; i++)
                    {
                        if (!(windowPopupMenuTool.Tools[i] is Infragistics.Win.UltraWinToolbars.StateButtonTool)) continue;

                        Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = (Infragistics.Win.UltraWinToolbars.StateButtonTool)windowPopupMenuTool.Tools[i];

                        if ((this.SubImp_UTabControl.SelectedTab != null) && (key == stateButtonTool.Key))
                        {
                            stateButtonTool.Checked = true;
                        }
                        else
                        {
                            stateButtonTool.Checked = false;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Tab�t�H�[����������
        /// </summary>
        /// <param>none</param>
        /// <returns>none</returns>
        /// <remarks>
        /// <br>Note       : MDI�q��ʂ𐶐�����</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private Form CreateTabForm2(FormControlInfo info)
        {
            Form form = null;

            form = (System.Windows.Forms.Form)this.LoadAssemblyFrom(info.AssemblyID, info.ClassID, typeof(System.Windows.Forms.Form));

            if (form == null)
            {
                form = new Form();
            }

            if (form != null)
            {
                info.Form = form;

                // �^�u�R���g���[���ɒǉ�����^�u�y�[�W���C���X�^���X������
                Infragistics.Win.UltraWinTabControl.UltraTabPageControl dataviewTabPageControl =
                  new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();

                // �^�u�̊O�ς�ݒ肵�A�^�u�R���g���[���Ƀ^�u��ǉ�����
                Infragistics.Win.UltraWinTabControl.UltraTab dataviewTab = new Infragistics.Win.UltraWinTabControl.UltraTab();

                dataviewTab.TabPage = dataviewTabPageControl;
                dataviewTab.Text = info.Name;
                dataviewTab.Key = info.Key;
                dataviewTab.Tag = form;
                dataviewTab.Appearance.Image = info.Icon;
                dataviewTab.Appearance.BackColor = Color.White;
                dataviewTab.Appearance.BackColor2 = Color.Lavender;
                dataviewTab.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

                dataviewTab.ActiveAppearance.BackColor = Color.White;
                dataviewTab.ActiveAppearance.BackColor2 = Color.LightPink;
                dataviewTab.ActiveAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

                //----------------------------------------------------------------------------//
                // �e��f���Q�[�g�C�x���g�o�^                                                 //
                //----------------------------------------------------------------------------//
                if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[0])
                {
                    // �c�[���o�[�{�^������C�x���g 
                    if (form is ICSVExportConditionInpType)
                    {
                        ((ICSVExportConditionInpType)form).ParentToolbarSettingEvent += new ParentToolbarSettingEventHandler(this.ParentToolbarSettingEvent);
                    }

                    this.SubExp_UTabControl.Controls.Add(dataviewTabPageControl);
                    this.SubExp_UTabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] { dataviewTab });
                    this.SubExp_UTabControl.SelectedTab = dataviewTab;
                }
                else if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[1])
                {
                    // �c�[���o�[�{�^������C�x���g 
                    if (form is ICSVImportConditionInpType)
                    {
                        ((ICSVImportConditionInpType)form).ParentToolbarSettingEvent += new ParentToolbarSettingEventHandler(this.ParentToolbarSettingEvent);
                    }

                    this.SubImp_UTabControl.Controls.Add(dataviewTabPageControl);
                    this.SubImp_UTabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] { dataviewTab });
                    this.SubImp_UTabControl.SelectedTab = dataviewTab;
                }

                // �t�H�[���v���p�e�B�ύX
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                dataviewTabPageControl.Controls.Add(form);

                if (form is ICSVExportConditionInpType)
                {
                    ((ICSVExportConditionInpType)form).Show(info.Param);
                }
                else if (form is ICSVImportConditionInpType)
                {
                    ((ICSVImportConditionInpType)form).Show(info.Param);
                }
                else
                {
                    form.Show();
                }
                form.Dock = System.Windows.Forms.DockStyle.Fill;
            }

            return form;
        }
        # endregion

        /// <summary>
        /// ÷��̧�ٖ��`�F�b�N����
        /// </summary>
        /// <param name="fileName">�t�@�C�����O</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : ÷��̧�ٖ��`�F�b�N�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private bool CheckInputFileName(string filePath, out string errMsg)
        {
            errMsg = string.Empty;
            bool bStatus = true;
            if (filePath == string.Empty)
            {
                errMsg = "�e�L�X�g�t�@�C��������͂��Ă��������B";
                bStatus = false;
            }
            else
            {
                // �t�@�C�������擾
                string fileName = filePath.Substring(filePath.LastIndexOf('\\') + 1);

                if (fileName.IndexOf("/") >= 0  ||
                    fileName.IndexOf(":") >= 0  ||
                    fileName.IndexOf(";") >= 0  ||
                    fileName.IndexOf("*") >= 0  ||
                    fileName.IndexOf("?") >= 0  ||
                    fileName.IndexOf("\"") >= 0 ||
                    fileName.IndexOf("<") >= 0  ||
                    fileName.IndexOf(">") >= 0  ||
                    fileName.IndexOf("|") >= 0  ||
                    Path.GetFileNameWithoutExtension(fileName).IndexOf(".") >= 0)
                {
                    errMsg = "CSV�t�@�C���p�X���s���ł��B";
                    bStatus = false;
                }
            }
            return bStatus;
        }

        /// <summary>
        /// ÷��̧�ٖ��̑��݃`�F�b�N����
        /// </summary>
        /// <param name="fileName">�t�@�C�����O</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : ÷��̧�ٖ��̑��݃`�F�b�N�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private bool CheckInputFileExists(string fileName, out string errMsg)
        {
            errMsg = string.Empty;
            bool bStatus = true;

            try
            {
                if (!File.Exists(fileName))
                {
                    errMsg = "�e�L�X�g�t�@�C�������݂��܂���B";
                    bStatus = false;
                }
            }
            catch
            {
                errMsg = "�e�L�X�g�t�@�C�������݂��܂���B";
                bStatus = false;
            }
            return bStatus;
        }

        /// <summary>
        /// ÷��̧�ٖ��̃��R�[�h���݃`�F�b�N����
        /// </summary>
        /// <param name="fileName">�t�@�C�����O</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <param name="dataList">�f�[�^���X�g</param>
        /// <param name="isReadErr">�Ǎ��G���[���ǂ���</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : ÷��̧�ٖ��̃��R�[�h���݃`�F�b�N�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private bool CheckInputFileDataExists(string fileName, out string errMsg, out List<string[]> dataList, out bool isReadErr)
        {
            errMsg = string.Empty;
            isReadErr = false;
            bool bStatus = true;
            dataList = GetCsvData(fileName, out errMsg);
            // �Ǎ����ɃG���[�����������ꍇ
            if (!string.IsNullOrEmpty(errMsg))
            {
                isReadErr = true;
                bStatus = false;
            }
            else
            {
                // ���R�[�h���Ȃ��ꍇ
                if (dataList.Count == 0)
                {
                    errMsg = "�Y������f�[�^������܂���B";
                    bStatus = false;
                }
            }
            return bStatus;
        }

        /// <summary>
        /// CSV���擾����
        /// </summary>
        /// <param name="fileName">�t�@�C�����O</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>CSV���</returns>
        /// <remarks>
        /// <br>Note       : CSV�����擾��������B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private List<String[]> GetCsvData(String fileName, out string errMsg)
        {
            errMsg = string.Empty;
            List<string[]> csvDataList = new List<string[]>();
            TextFieldParser parser = new TextFieldParser(fileName, System.Text.Encoding.GetEncoding("Shift_JIS"));
            try
            {
                using (parser)
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(","); // ��؂蕶���̓R���}
                    while (!parser.EndOfData)
                    {
                        string[] row = parser.ReadFields(); // 1�s�ǂݍ���
                        csvDataList.Add(row);
                    }
                }
            }
            catch
            {
                errMsg = "�捞�ΏۊO�̃t�@�C���ł��B";
            }

            return csvDataList;

        }

        ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
        /// <summary>
        /// CSV�g���q�`�F�b�N
        /// </summary>
        /// <param name="filepass">�t�@�C���p�X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�`�F�b�N����(true:��薳���Afalse:��肠��)</returns>
        /// <remarks>
        /// <br>Note       : CSV�̊g���q���`�F�b�N���܂�</br>
        /// <br>Programmer : 30521 T.MOTOYAMA</br>
        /// <br>Date       : 2013.10.28</br>
        /// </remarks>
        private bool CheckCSVextension(string filepass, out string errMsg)
        {
            errMsg = "";

            // �t�@�C���̊g���q�`�F�b�N
            string stExtension = System.IO.Path.GetExtension(filepass);

            if (stExtension == ".CSV" ||
                stExtension == ".csv")
            {
                return true;
            }
            else
            {
                errMsg = "�g���q���s���ł��B";
                return false;
            }        
        }
        // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////

        /// <summary>
        /// CSV�o�͏���
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : CSV�o�͏������s���B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private int DoOutPut(ref object parameter)
        {
            int status = 0;
            int totalCount;

            try
            {
                ArrayList paramList = parameter as ArrayList;

                // �o�̓X�L�[�}���X�g
                List<string> schemeList = paramList[0] as List<string>;
                // �N���X�^�C�v���X�g
                List<Type> enclosingTypeList = new List<Type>();
                enclosingTypeList.Add("".GetType());

                // �o�͍��ڍő咷��
                Dictionary<string, int> maxLengthList = paramList[1] as Dictionary<string, int>;

                _formattedTextWriter.DataSource = this.BindDataSet.Tables[this._tableName].DefaultView;
                _formattedTextWriter.DataMember = String.Empty;
                _formattedTextWriter.OutputFileName = paramList[2] as string;
                // �e�L�X�g�o�͂��鍀�ږ��̃��X�g
                _formattedTextWriter.SchemeList = schemeList;
                _formattedTextWriter.Splitter = ",";
                _formattedTextWriter.Encloser = "\"";
                _formattedTextWriter.EnclosingTypeList = enclosingTypeList;
                _formattedTextWriter.FormatList = null;
                _formattedTextWriter.CaptionOutput = true;
                _formattedTextWriter.FixedLength = false;
                _formattedTextWriter.ReplaceList = null;
                _formattedTextWriter.MaxLengthList = null;

                status = this._formattedTextWriter.TextOut(out totalCount);
            }
            catch
            {
                status = -1;
            }

            return status;
        }

        # endregion private method

        // ===================================================================================== //
        // �R���g���[���C�x���g
        // ===================================================================================== //
        # region control event
        /// <summary>
        /// Control.MouseDown �C�x���g(StartNavigatorEXPTree)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �c���[�R���g���[���ɂă}�E�X�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void StartNavigatorEXPTree_MouseDown(object sender, MouseEventArgs e)
        {
            this._lastMouseDown = new Point(e.X, e.Y);
        }

        /// <summary>
        /// Control.MouseDown �C�x���g(StartNavigatorINPTree)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �c���[�R���g���[���ɂă}�E�X�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void StartNavigatorINPTree_MouseDown(object sender, MouseEventArgs e)
        {
            this._lastMouseDown = new Point(e.X, e.Y);
        }

        /// <summary>
        /// �c���[�m�[�h�_�u���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �N���i�r�Q�[�^�[�̃_�u���N���b�N�C�x���g�ł��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void StartNavigatorEXPTree_DoubleClick(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinTree.UltraTreeNode doubleClickedNode =
                    this.StartNavigatorEXPTree.GetNodeFromPoint(this._lastMouseDown);

            if (doubleClickedNode == null) return;

            FormControlInfo info = this._expFormControlInfoTable[doubleClickedNode.Key.ToString()] as FormControlInfo;
            if (info == null) return;

            if (doubleClickedNode.Level == 2)
            {
                if (!MyOpeCtrlMap.ContainsKey(info.AssemblyID))
                {
                    if (!OpeAuthCtrlFacade.CanRunWithInitializing(
                        EntityUtil.CategoryCode.Report,
                        MyOpeCtrlMap.AddController(info.AssemblyID),
                        info.AssemblyID,
                        info.Name
                    ))
                    {
                        return; // �N���s�̂��ߋ����I��
                    }
                }

                Infragistics.Win.UltraWinTree.UltraTreeNode node = doubleClickedNode;

                // �������͉��UI�N������
                ShowChildExpInputForm(node.Key.ToString());

                doubleClickedNode.Override.NodeAppearance.ForeColor = Color.Red;

                BeginControllingByOperationAuthority(info.AssemblyID);
            }
        }


        /// <summary>
        /// �c���[�m�[�h�_�u���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �N���i�r�Q�[�^�[�̃_�u���N���b�N�C�x���g�ł��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void StartNavigatorINPTree_DoubleClick(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinTree.UltraTreeNode doubleClickedNode =
                    this.StartNavigatorINPTree.GetNodeFromPoint(this._lastMouseDown);

            if (doubleClickedNode == null) return;

            FormControlInfo info = this._impFormControlInfoTable[doubleClickedNode.Key.ToString()] as FormControlInfo;
            if (info == null) return;

            if (doubleClickedNode.Level == 2)
            {
                if (!MyOpeCtrlMap.ContainsKey(info.AssemblyID))
                {
                    if (!OpeAuthCtrlFacade.CanRunWithInitializing(
                        EntityUtil.CategoryCode.Report,
                        MyOpeCtrlMap.AddController(info.AssemblyID),
                        info.AssemblyID,
                        info.Name
                    ))
                    {
                        return; // �N���s�̂��ߋ����I��
                    }
                }

                Infragistics.Win.UltraWinTree.UltraTreeNode node = doubleClickedNode;

                // �������͉��UI�N������
                ShowChildExpInputForm(node.Key.ToString());

                SetUpButtonToolEnable(node.Key.ToString());

                doubleClickedNode.Override.NodeAppearance.ForeColor = Color.Red;

                BeginControllingByOperationAuthority(info.AssemblyID);
            }
        }

        /// <summary>
        /// �^�u�I���㏈��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �^�u�I����ɔ�������C�x���g�ł��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void SubExp_UTabControl_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (e.Tab == null) return;

            if (!this._expFormControlInfoTable.Contains(e.Tab.Key))
            {
                return;
            }

            string key = e.Tab.Key;
            FormControlInfo info = this._expFormControlInfoTable[key] as FormControlInfo;
            Form target = info.Form;

            // �^�u�A�N�e�B�u����
            this.TabActive2(key, ref target);

            // �c�[���o�[�̕\���E�L���ݒ�
            this.ToolBarSetting(target);
        }

        /// <summary>
        /// �^�u�I���㏈��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �^�u�I����ɔ�������C�x���g�ł��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void SubImp_UTabControl_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (e.Tab == null) return;

            if (!this._impFormControlInfoTable.Contains(e.Tab.Key))
            {
                return;
            }

            string key = e.Tab.Key;
            FormControlInfo info = this._impFormControlInfoTable[key] as FormControlInfo;
            Form target = info.Form;

            // �^�u�A�N�e�B�u����
            this.TabActive2(key, ref target);

            // �c�[���o�[�̕\���E�L���ݒ�
            this.ToolBarSetting(target);

            SetUpButtonToolEnable(target.ToString());
        }

        /// <summary>
        /// �^�u�I���㏈��(Main_UTabControl)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �^�u�I����ɔ�������C�x���g�ł��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void Main_UTabControl_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            Infragistics.Win.UltraWinTabControl.UltraTabControl uTabControl = null;
            System.Windows.Forms.Form frm = null;

            // �|���}�X�^�G�N�X�|�[�g
            if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[0])
            {
                uTabControl = this.SubExp_UTabControl;

                if (uTabControl.ActiveTab != null)
                {
                    FormControlInfo formInfo = (FormControlInfo)this._expFormControlInfoTable[uTabControl.SelectedTab.Key];
                    ToolBarSetting(formInfo.Form);
                    SetUpButtonToolEnable(uTabControl.ActiveTab.Key.ToString());
                }
                else
                {
                    ToolBarSetting(frm);
                }
            }
            // �|���}�X�^�C���|�[�g
            else if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[1])
            {
                uTabControl = this.SubImp_UTabControl;

                if (uTabControl.ActiveTab != null)
                {
                    FormControlInfo formInfo = (FormControlInfo)this._impFormControlInfoTable[uTabControl.SelectedTab.Key];
                    ToolBarSetting(formInfo.Form);
                    SetUpButtonToolEnable(uTabControl.ActiveTab.Key.ToString());
                }
                else
                {
                    ToolBarSetting(frm);
                }
            }

            // �E�B���h�E�X�e�C�g��ԕύX
            this.CreateWindowStateButtonTools();
        }
        # endregion control event
    }
}

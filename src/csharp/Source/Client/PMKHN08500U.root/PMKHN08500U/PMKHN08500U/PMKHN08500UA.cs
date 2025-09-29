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
using Broadleaf.Library.Diagnostics;// ADD 杍^ 2021/01/04 PMKOBETSU-4109�̑Ή�

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �}�X�^�G�N�X�|�[�g�E�C���|�[�g�t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �}�X�^�G�N�X�|�[�g�E�C���|�[�g�̃t���[���N���X�ł��B</br>
    /// <br>Programmer : 30462 �s�V �m��</br>
    /// <br>Date       : 2008.10.24</br>
    /// <br>Update Note: 2009/05/12 �����</br>
    /// <br>             �G�N�X�|�[�g.�C���|�[�g�̒ǉ�</br>
    /// <br>           : </br>
    /// <br>Update Note: 2010/03/31 �Ė� �x��</br>
    /// <br>             Mantis.15256 ���i�}�X�^�C���|�[�g�̑Ώۍ��ڐݒ�Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2010/11/02  22018 ��� ���b</br>
    /// <br>           : Adobe Reader9�ȍ~���ƏI�����G���[�������錏�̑Ή��B(WebBrowser��������̏C��)</br>
    /// <br>Update Note: 2011/07/28  923 ���X��</br>
    /// </br>            : �i�Ԃ�i���� "(����ٺ�ð���)���܂܂��ƁA���߰Ď��ɃG���[�ɂȂ�ׂ̑Ή�</br>
    /// <br>Update Note: �A�� 810 zhouyu </br>
    /// <br>Date       : 2011/08/03 �A�� 810�̑Ή�</br>
    /// <br>Update Note: 2011/12/20 �����x</br>
    /// <br>�Ǘ��ԍ�   : 10707327-00 2012/01/25�z�M��</br>
    /// <br>             Redmine#27268�@���[�t���[���^�N���i�r�Q�[�^�[�̃��_�`�F�b�N�̏C��</br>
    /// <br>Update Note: 2021/01/04 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11670323-00</br>
    /// <br>             PMKOBETSU-4109�@�v���O�����N�����O�𑀍엚�����O�ɏo�͂���ǉ��Ή�</br>
    /// </remarks>
    public class PMKHN08500UA : System.Windows.Forms.Form
    {
        # region Private Members (Component)
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager Main_ToolbarsManager;
        private System.Windows.Forms.Timer Initial_Timer;
        private Infragistics.Win.UltraWinDock.UltraDockManager Main_DockManager;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar Main_StatusBar;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN08500UA_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN08500UA_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN08500UA_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN08500UA_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _PMKHN08500UAUnpinnedTabAreaLeft;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _PMKHN08500UAUnpinnedTabAreaRight;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _PMKHN08500UAUnpinnedTabAreaTop;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _PMKHN08500UAUnpinnedTabAreaBottom;
        private Infragistics.Win.UltraWinDock.AutoHideControl _PMKHN08500UAAutoHideControl;
        private TMemPos tMemPos1;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl Main_UTabControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl Sub_UTabControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage DataViewTabSharedControlsPage;
        private Infragistics.Win.UltraWinTree.UltraTree StartNavigatorTree;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl3;
        private DataSet BindDataSet;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.UltraWinGrid.UltraGrid DataViewGrid;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.MenuItem Close_menuItem;
        private Panel PdfHistory_Panel;
        private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea1;
        private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow1;
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
        private System.Windows.Forms.ContextMenu TabControl_contextMenu;
        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructor
        public PMKHN08500UA()
        {
            InitializeComponent();

            // RemotingConfiguration�̓ǂݍ���
#if !CLR2
			System.Runtime.Remoting.RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
#endif

            // PDF�폜���X�g�e�[�u���쐬
            this._delPDFList = new Hashtable();

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
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("d96d9781-9622-4f2b-b51c-3c4a99ec1cfc"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("b4f2f286-28fe-4678-a09f-d8c40438e716"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("d96d9781-9622-4f2b-b51c-3c4a99ec1cfc"), -1);
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
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
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Print_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Preview_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("PDFSave_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Extract_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool("STOP_LabelTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("TextOutPut_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Export_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Import_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("SetUp_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool6 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Print_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Preview_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("PDFSave_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Extract_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Export_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Import_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("TextOutPut_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool7 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Tool_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UserSetUp_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool8 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Window_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool9 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Forms_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool5 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool6 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool7 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool19 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool20 = new Infragistics.Win.UltraWinToolbars.ButtonTool("UserSetUp_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool8 = new Infragistics.Win.UltraWinToolbars.LabelTool("PrintKindTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.ComboBoxTool comboBoxTool1 = new Infragistics.Win.UltraWinToolbars.ComboBoxTool("PrintKind_ComboBoxTool");
            Infragistics.Win.ValueList valueList1 = new Infragistics.Win.ValueList(0);
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool21 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Extract_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool22 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Preview_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool23 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Print_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool9 = new Infragistics.Win.UltraWinToolbars.LabelTool("STOP_LabelTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool1 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("PrtSuspendCnt_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool10 = new Infragistics.Win.UltraWinToolbars.LabelTool("Number_LabelTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool24 = new Infragistics.Win.UltraWinToolbars.ButtonTool("PDFSave_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool25 = new Infragistics.Win.UltraWinToolbars.ButtonTool("TextOutPut_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool26 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Export_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool27 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Import_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool28 = new Infragistics.Win.UltraWinToolbars.ButtonTool("SetUp_ButtonTool");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN08500UA));
            this.PdfHistory_Panel = new System.Windows.Forms.Panel();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.DataViewGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Sub_UTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.DataViewTabSharedControlsPage = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.StartNavigatorTree = new Infragistics.Win.UltraWinTree.UltraTree();
            this.ultraTabPageControl7 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.SubExp_UTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage9 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.StartNavigatorEXPTree = new Infragistics.Win.UltraWinTree.UltraTree();
            this.ultraTabPageControl8 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.SubImp_UTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage10 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.StartNavigatorINPTree = new Infragistics.Win.UltraWinTree.UltraTree();
            this.Main_DockManager = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._PMKHN08500UAUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._PMKHN08500UAUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._PMKHN08500UAUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._PMKHN08500UAUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._PMKHN08500UAAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.dockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
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
            this.windowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this._PMKHN08500UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Main_ToolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._PMKHN08500UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMKHN08500UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMKHN08500UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraTabPageControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataViewGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_UTabControl)).BeginInit();
            this.Sub_UTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartNavigatorTree)).BeginInit();
            this.ultraTabPageControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SubExp_UTabControl)).BeginInit();
            this.SubExp_UTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartNavigatorEXPTree)).BeginInit();
            this.ultraTabPageControl8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SubImp_UTabControl)).BeginInit();
            this.SubImp_UTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartNavigatorINPTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).BeginInit();
            this._PMKHN08500UAAutoHideControl.SuspendLayout();
            this.dockableWindow1.SuspendLayout();
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
            // PdfHistory_Panel
            // 
            this.PdfHistory_Panel.BackColor = System.Drawing.Color.White;
            this.PdfHistory_Panel.Location = new System.Drawing.Point(0, 27);
            this.PdfHistory_Panel.Name = "PdfHistory_Panel";
            this.PdfHistory_Panel.Size = new System.Drawing.Size(198, 565);
            this.PdfHistory_Panel.TabIndex = 39;
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.DataViewGrid);
            this.ultraTabPageControl1.Controls.Add(this.ultraStatusBar1);
            this.ultraTabPageControl1.Controls.Add(this.Sub_UTabControl);
            this.ultraTabPageControl1.Controls.Add(this.StartNavigatorTree);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(1, 25);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(992, 601);
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
            this.DataViewGrid.Location = new System.Drawing.Point(201, 360);
            this.DataViewGrid.Name = "DataViewGrid";
            this.DataViewGrid.Size = new System.Drawing.Size(791, 241);
            this.DataViewGrid.TabIndex = 41;
            // 
            // ultraStatusBar1
            // 
            appearance54.FontData.BoldAsString = "True";
            appearance54.FontData.Name = "�l�r �S�V�b�N";
            appearance54.FontData.SizeInPoints = 11F;
            this.ultraStatusBar1.Appearance = appearance54;
            this.ultraStatusBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraStatusBar1.Location = new System.Drawing.Point(201, 332);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Padding = new Infragistics.Win.UltraWinStatusBar.UIElementMargins(20, 2, 0, 0);
            this.ultraStatusBar1.Size = new System.Drawing.Size(791, 28);
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
            this.Sub_UTabControl.Location = new System.Drawing.Point(201, 0);
            this.Sub_UTabControl.Name = "Sub_UTabControl";
            this.Sub_UTabControl.SharedControlsPage = this.DataViewTabSharedControlsPage;
            this.Sub_UTabControl.Size = new System.Drawing.Size(791, 332);
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
            this.DataViewTabSharedControlsPage.Size = new System.Drawing.Size(789, 311);
            // 
            // StartNavigatorTree
            // 
            this.StartNavigatorTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.StartNavigatorTree.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.StartNavigatorTree.Location = new System.Drawing.Point(0, 0);
            this.StartNavigatorTree.Name = "StartNavigatorTree";
            this.StartNavigatorTree.NodeConnectorColor = System.Drawing.SystemColors.ControlDark;
            this.StartNavigatorTree.Size = new System.Drawing.Size(201, 601);
            this.StartNavigatorTree.TabIndex = 35;
            this.StartNavigatorTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartNavigatorTree_MouseDown);
            this.StartNavigatorTree.DoubleClick += new System.EventHandler(this.StartNavigatorTree_DoubleClick);
            // 
            // ultraTabPageControl7
            // 
            this.ultraTabPageControl7.Controls.Add(this.SubExp_UTabControl);
            this.ultraTabPageControl7.Controls.Add(this.StartNavigatorEXPTree);
            this.ultraTabPageControl7.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl7.Name = "ultraTabPageControl7";
            this.ultraTabPageControl7.Size = new System.Drawing.Size(992, 591);
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
            this.SubExp_UTabControl.Size = new System.Drawing.Size(791, 591);
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
            this.ultraTabSharedControlsPage9.Size = new System.Drawing.Size(789, 570);
            // 
            // StartNavigatorEXPTree
            // 
            this.StartNavigatorEXPTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.StartNavigatorEXPTree.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.StartNavigatorEXPTree.Location = new System.Drawing.Point(0, 0);
            this.StartNavigatorEXPTree.Name = "StartNavigatorEXPTree";
            this.StartNavigatorEXPTree.NodeConnectorColor = System.Drawing.SystemColors.ControlDark;
            this.StartNavigatorEXPTree.Size = new System.Drawing.Size(201, 591);
            this.StartNavigatorEXPTree.TabIndex = 35;
            this.StartNavigatorEXPTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartNavigatorEXPTree_MouseDown);
            this.StartNavigatorEXPTree.DoubleClick += new System.EventHandler(this.StartNavigatorEXPTree_DoubleClick);
            // 
            // ultraTabPageControl8
            // 
            this.ultraTabPageControl8.Controls.Add(this.SubImp_UTabControl);
            this.ultraTabPageControl8.Controls.Add(this.StartNavigatorINPTree);
            this.ultraTabPageControl8.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl8.Name = "ultraTabPageControl8";
            this.ultraTabPageControl8.Size = new System.Drawing.Size(992, 591);
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
            this.SubImp_UTabControl.Size = new System.Drawing.Size(791, 591);
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
            this.ultraTabSharedControlsPage10.Size = new System.Drawing.Size(789, 570);
            // 
            // StartNavigatorINPTree
            // 
            this.StartNavigatorINPTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.StartNavigatorINPTree.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.StartNavigatorINPTree.Location = new System.Drawing.Point(0, 0);
            this.StartNavigatorINPTree.Name = "StartNavigatorINPTree";
            this.StartNavigatorINPTree.NodeConnectorColor = System.Drawing.SystemColors.ControlDark;
            this.StartNavigatorINPTree.Size = new System.Drawing.Size(201, 591);
            this.StartNavigatorINPTree.TabIndex = 35;
            this.StartNavigatorINPTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartNavigatorINPTree_MouseDown);
            this.StartNavigatorINPTree.DoubleClick += new System.EventHandler(this.StartNavigatorINPTree_DoubleClick);
            // 
            // Main_DockManager
            // 
            this.Main_DockManager.CaptionStyle = Infragistics.Win.UltraWinDock.CaptionStyle.Office2003;
            dockableControlPane1.Control = this.PdfHistory_Panel;
            dockableControlPane1.FlyoutSize = new System.Drawing.Size(198, -1);
            dockableControlPane1.Key = "PdfHistory";
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(383, 57, 250, 621);
            dockableControlPane1.Pinned = false;
            dockableControlPane1.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            appearance62.FontData.SizeInPoints = 10F;
            dockableControlPane1.Settings.Appearance = appearance62;
            dockableControlPane1.Settings.DoubleClickAction = Infragistics.Win.UltraWinDock.PaneDoubleClickAction.ToggleDockedState;
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "�o�͍ςݒ��[����";
            dockableControlPane1.ToolTipTab = "�ߋ��ɏo�͂������[�̌������s���܂��B";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(95, 648);
            this.Main_DockManager.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1});
            this.Main_DockManager.HostControl = this;
            this.Main_DockManager.LayoutStyle = Infragistics.Win.UltraWinDock.DockAreaLayoutStyle.FillContainer;
            this.Main_DockManager.ShowCloseButton = false;
            this.Main_DockManager.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2003;
            // 
            // _PMKHN08500UAUnpinnedTabAreaLeft
            // 
            this._PMKHN08500UAUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._PMKHN08500UAUnpinnedTabAreaLeft.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._PMKHN08500UAUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 63);
            this._PMKHN08500UAUnpinnedTabAreaLeft.Name = "_PMKHN08500UAUnpinnedTabAreaLeft";
            this._PMKHN08500UAUnpinnedTabAreaLeft.Owner = this.Main_DockManager;
            this._PMKHN08500UAUnpinnedTabAreaLeft.Size = new System.Drawing.Size(22, 627);
            this._PMKHN08500UAUnpinnedTabAreaLeft.TabIndex = 5;
            // 
            // _PMKHN08500UAUnpinnedTabAreaRight
            // 
            this._PMKHN08500UAUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._PMKHN08500UAUnpinnedTabAreaRight.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._PMKHN08500UAUnpinnedTabAreaRight.Location = new System.Drawing.Point(1016, 63);
            this._PMKHN08500UAUnpinnedTabAreaRight.Name = "_PMKHN08500UAUnpinnedTabAreaRight";
            this._PMKHN08500UAUnpinnedTabAreaRight.Owner = this.Main_DockManager;
            this._PMKHN08500UAUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 627);
            this._PMKHN08500UAUnpinnedTabAreaRight.TabIndex = 6;
            // 
            // _PMKHN08500UAUnpinnedTabAreaTop
            // 
            this._PMKHN08500UAUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._PMKHN08500UAUnpinnedTabAreaTop.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._PMKHN08500UAUnpinnedTabAreaTop.Location = new System.Drawing.Point(22, 63);
            this._PMKHN08500UAUnpinnedTabAreaTop.Name = "_PMKHN08500UAUnpinnedTabAreaTop";
            this._PMKHN08500UAUnpinnedTabAreaTop.Owner = this.Main_DockManager;
            this._PMKHN08500UAUnpinnedTabAreaTop.Size = new System.Drawing.Size(994, 0);
            this._PMKHN08500UAUnpinnedTabAreaTop.TabIndex = 7;
            // 
            // _PMKHN08500UAUnpinnedTabAreaBottom
            // 
            this._PMKHN08500UAUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._PMKHN08500UAUnpinnedTabAreaBottom.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._PMKHN08500UAUnpinnedTabAreaBottom.Location = new System.Drawing.Point(22, 690);
            this._PMKHN08500UAUnpinnedTabAreaBottom.Name = "_PMKHN08500UAUnpinnedTabAreaBottom";
            this._PMKHN08500UAUnpinnedTabAreaBottom.Owner = this.Main_DockManager;
            this._PMKHN08500UAUnpinnedTabAreaBottom.Size = new System.Drawing.Size(994, 0);
            this._PMKHN08500UAUnpinnedTabAreaBottom.TabIndex = 8;
            // 
            // _PMKHN08500UAAutoHideControl
            // 
            this._PMKHN08500UAAutoHideControl.Controls.Add(this.dockableWindow1);
            this._PMKHN08500UAAutoHideControl.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._PMKHN08500UAAutoHideControl.Location = new System.Drawing.Point(22, 98);
            this._PMKHN08500UAAutoHideControl.Name = "_PMKHN08500UAAutoHideControl";
            this._PMKHN08500UAAutoHideControl.Owner = this.Main_DockManager;
            this._PMKHN08500UAAutoHideControl.Size = new System.Drawing.Size(13, 592);
            this._PMKHN08500UAAutoHideControl.TabIndex = 9;
            // 
            // dockableWindow1
            // 
            this.dockableWindow1.Controls.Add(this.PdfHistory_Panel);
            this.dockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.dockableWindow1.Name = "dockableWindow1";
            this.dockableWindow1.Owner = this.Main_DockManager;
            this.dockableWindow1.Size = new System.Drawing.Size(198, 617);
            this.dockableWindow1.TabIndex = 45;
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
            this.Main_UTabControl.Controls.Add(this.ultraTabPageControl1);
            this.Main_UTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_UTabControl.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Main_UTabControl.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.Main_UTabControl.Location = new System.Drawing.Point(22, 63);
            this.Main_UTabControl.Name = "Main_UTabControl";
            this.Main_UTabControl.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.Main_UTabControl.Size = new System.Drawing.Size(994, 627);
            this.Main_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.Main_UTabControl.TabIndex = 34;
            this.Main_UTabControl.TabPadding = new System.Drawing.Size(80, 3);
            ultraTab3.TabPage = this.ultraTabPageControl1;
            ultraTab3.Tag = "print";
            ultraTab3.Text = "���";
            ultraTab6.TabPage = this.ultraTabPageControl7;
            ultraTab6.Tag = "export";
            ultraTab6.Text = "����߰�";
            ultraTab7.TabPage = this.ultraTabPageControl8;
            ultraTab7.Tag = "import";
            ultraTab7.Text = "���߰�";
            this.Main_UTabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab3,
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
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(992, 601);
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
            this.ultraTabSharedControlsPage6.Location = new System.Drawing.Point(1, 20);
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
            this.ultraTabSharedControlsPage7.Location = new System.Drawing.Point(1, 20);
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
            this.ultraTree3.Size = new System.Drawing.Size(201, 622);
            this.ultraTree3.TabIndex = 35;
            // 
            // windowDockingArea1
            // 
            this.windowDockingArea1.Dock = System.Windows.Forms.DockStyle.Left;
            this.windowDockingArea1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.windowDockingArea1.Location = new System.Drawing.Point(22, 63);
            this.windowDockingArea1.Name = "windowDockingArea1";
            this.windowDockingArea1.Owner = this.Main_DockManager;
            this.windowDockingArea1.Size = new System.Drawing.Size(100, 648);
            this.windowDockingArea1.TabIndex = 40;
            // 
            // _PMKHN08500UA_Toolbars_Dock_Area_Left
            // 
            this._PMKHN08500UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN08500UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN08500UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._PMKHN08500UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN08500UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 63);
            this._PMKHN08500UA_Toolbars_Dock_Area_Left.Name = "_PMKHN08500UA_Toolbars_Dock_Area_Left";
            this._PMKHN08500UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 627);
            this._PMKHN08500UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.Main_ToolbarsManager;
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
            buttonTool2,
            buttonTool3,
            buttonTool4,
            buttonTool5,
            labelTool4,
            buttonTool6,
            buttonTool7,
            buttonTool8,
            buttonTool9});
            ultraToolbar2.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.BelowImage;
            ultraToolbar2.Text = "�W��";
            this.Main_ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2});
            popupMenuTool6.SharedProps.Caption = "�t�@�C��(&F)";
            popupMenuTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            buttonTool17.InstanceProps.IsFirstInGroup = true;
            popupMenuTool6.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool10,
            buttonTool11,
            buttonTool12,
            buttonTool13,
            buttonTool14,
            buttonTool15,
            buttonTool16,
            buttonTool17});
            popupMenuTool7.SharedProps.Caption = "�c�[��(&T)";
            popupMenuTool7.SharedProps.Visible = false;
            popupMenuTool7.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool18});
            popupMenuTool8.SharedProps.Caption = "�E�B���h�E(&W)";
            labelTool6.SharedProps.Caption = "���O�C���S����";
            labelTool6.SharedProps.ShowInCustomizer = false;
            appearance7.BackColor = System.Drawing.Color.White;
            appearance7.TextHAlignAsString = "Left";
            appearance7.TextVAlignAsString = "Bottom";
            labelTool7.SharedProps.AppearancesSmall.Appearance = appearance7;
            labelTool7.SharedProps.ShowInCustomizer = false;
            labelTool7.SharedProps.Width = 150;
            buttonTool19.SharedProps.Caption = "�I��(&X)";
            buttonTool19.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool19.SharedProps.ShowInCustomizer = false;
            buttonTool20.SharedProps.Caption = "���[�U�[�ݒ�(&C)";
            buttonTool20.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool20.SharedProps.ShowInCustomizer = false;
            labelTool8.SharedProps.Caption = "���ޑI��";
            labelTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
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
            buttonTool21.SharedProps.Caption = "���o(&E)";
            buttonTool21.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool22.SharedProps.Caption = "PDF�\��(&V)";
            buttonTool22.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool23.SharedProps.Caption = "���(&P)";
            buttonTool23.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            controlContainerTool1.SharedProps.MaxWidth = 40;
            controlContainerTool1.SharedProps.MinWidth = 40;
            controlContainerTool1.SharedProps.Width = 41;
            labelTool10.SharedProps.Caption = "��";
            labelTool10.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            buttonTool24.SharedProps.Caption = "PDF����ۑ�(&S)";
            buttonTool24.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool24.SharedProps.Enabled = false;
            buttonTool25.SharedProps.Caption = "�e�L�X�g�o��(&O)";
            buttonTool25.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool25.SharedProps.Visible = false;
            buttonTool26.SharedProps.Caption = "����߰�(&O)";
            buttonTool26.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool27.SharedProps.Caption = "���߰�(&I)";
            buttonTool27.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool28.SharedProps.Caption = "�ݒ�(&M)";
            buttonTool28.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.Main_ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool6,
            popupMenuTool7,
            popupMenuTool8,
            popupMenuTool9,
            labelTool5,
            labelTool6,
            labelTool7,
            buttonTool19,
            buttonTool20,
            labelTool8,
            comboBoxTool1,
            buttonTool21,
            buttonTool22,
            buttonTool23,
            labelTool9,
            controlContainerTool1,
            labelTool10,
            buttonTool24,
            buttonTool25,
            buttonTool26,
            buttonTool27,
            buttonTool28});
            this.Main_ToolbarsManager.ToolTipDisplayStyle = Infragistics.Win.UltraWinToolbars.ToolTipDisplayStyle.Standard;
            this.Main_ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.Main_ToolbarsManager_ToolClick);
            this.Main_ToolbarsManager.ToolValueChanged += new Infragistics.Win.UltraWinToolbars.ToolEventHandler(this.Main_ToolbarsManager_ToolValueChanged);
            // 
            // _PMKHN08500UA_Toolbars_Dock_Area_Right
            // 
            this._PMKHN08500UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN08500UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN08500UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._PMKHN08500UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN08500UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1016, 63);
            this._PMKHN08500UA_Toolbars_Dock_Area_Right.Name = "_PMKHN08500UA_Toolbars_Dock_Area_Right";
            this._PMKHN08500UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 627);
            this._PMKHN08500UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _PMKHN08500UA_Toolbars_Dock_Area_Top
            // 
            this._PMKHN08500UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN08500UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN08500UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._PMKHN08500UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN08500UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._PMKHN08500UA_Toolbars_Dock_Area_Top.Name = "_PMKHN08500UA_Toolbars_Dock_Area_Top";
            this._PMKHN08500UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1016, 63);
            this._PMKHN08500UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _PMKHN08500UA_Toolbars_Dock_Area_Bottom
            // 
            this._PMKHN08500UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN08500UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN08500UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._PMKHN08500UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN08500UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 690);
            this._PMKHN08500UA_Toolbars_Dock_Area_Bottom.Name = "_PMKHN08500UA_Toolbars_Dock_Area_Bottom";
            this._PMKHN08500UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1016, 0);
            this._PMKHN08500UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // PMKHN08500UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.ClientSize = new System.Drawing.Size(1016, 713);
            this.Controls.Add(this._PMKHN08500UAAutoHideControl);
            this.Controls.Add(this.Main_UTabControl);
            this.Controls.Add(this.windowDockingArea1);
            this.Controls.Add(this._PMKHN08500UAUnpinnedTabAreaBottom);
            this.Controls.Add(this._PMKHN08500UAUnpinnedTabAreaTop);
            this.Controls.Add(this._PMKHN08500UAUnpinnedTabAreaRight);
            this.Controls.Add(this._PMKHN08500UAUnpinnedTabAreaLeft);
            this.Controls.Add(this._PMKHN08500UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._PMKHN08500UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._PMKHN08500UA_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._PMKHN08500UA_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.Main_StatusBar);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN08500UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "���[";
            this.Load += new System.EventHandler(this.PMKHN08500UA_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PMKHN08500UA_FormClosed);
            this.ultraTabPageControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataViewGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_UTabControl)).EndInit();
            this.Sub_UTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StartNavigatorTree)).EndInit();
            this.ultraTabPageControl7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SubExp_UTabControl)).EndInit();
            this.SubExp_UTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StartNavigatorEXPTree)).EndInit();
            this.ultraTabPageControl8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SubImp_UTabControl)).EndInit();
            this.SubImp_UTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StartNavigatorINPTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).EndInit();
            this._PMKHN08500UAAutoHideControl.ResumeLayout(false);
            this.dockableWindow1.ResumeLayout(false);
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
                        _form = new PMKHN08500UA();
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
        private const string CT_PGID = "PMKHN08500U";
        private const string CT_PGNAME = "�}�X�^���";  // ADD 2009/03/18 �s��Ή�[12537] ���쌠������̒ǉ�
        private const string MAIN_FORM_TITLE = "���[";
        private const string NAVIGATORTREE_XML = "PMKHN08500UP_Navigator.DAT";
        // --- ADD 2009/05/12 ------------------------------->>>>>
        private const string NAVIGATOREXPTREE_XML = "PMKHN08500UP_Navigator_EXP.DAT";
        private const string NAVIGATORINPTREE_XML = "PMKHN08500UP_Navigator_INP.DAT";
        private Hashtable _expFormControlInfoTable = new Hashtable();
        private Hashtable _impFormControlInfoTable = new Hashtable();
        // --- ADD 2009/05/12 ------------------------------<<<<<

        // �N�����[�h�萔   

        private Hashtable _formControlInfoTable = new Hashtable();
        private const string NO0_DEMANDMAIN_TAB = "DEMAND_MAIN_TAB";
        private const string NO1_LISTPREVIEW_TAB = "LISTPREVIEW_TAB";

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

        private const string TOOLBAR_WINDOW_KEY = "Window_PopupMenuTool";
        private const string TOOLBAR_FORMS_KEY = "Forms_PopupMenuTool";
        private const string TOOLBAR_RESETBUTTON_KEY = "Reset_ButtonTool";


        private const string DOCKMANAGER_PDFHISTORTY_KEY = "PdfHistory";

        // --- ADD 2009/05/12 ------------------------------->>>>>
        private const string TOOLBAR_EXPORTBUTTON_KEY = "Export_ButtonTool";
        private const string TOOLBAR_IMPORTBUTTON_KEY = "Import_ButtonTool";
        // --- ADD 2009/05/12 ------------------------------<<<<<

        // 2010/03/31 Add >>>
        private const string TOOLBAR_SETUPBUTTON_KEY = "SetUp_ButtonTool";
        // 2010/03/31 Add <<<

        // �r���[�t�H�[���p�ǉ��L�[���(�ΏۃA�Z���u��_VIEWR)
        private const string TAB_VIEWFORM_ADDKEY = "_VIWER";
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region Private Members
        // �����ꗗ�p�v���r���[�t�H�[��
        private Form _listPreviewForm = null;

        private static string[] _parameter;
        private static System.Windows.Forms.Form _form = null;

        // �C�x���g�t���O
        private bool _eventDoFlag = false;
        private Hashtable _delPDFList = null;							// �폜PDF�i�[���X�g

        private SFANL06101UA _pdfHistorySerchForm = null;							// PDF�����������

        private DemandPrintAcs _demandPrintAcs = null;

        private Point _lastMouseDown;
        private string _tableName;
        private string _employeeName;
        private bool _buttonEnable = true;
        private bool _reLoad = false; //ADD 2011/08/03
        private Hashtable _setPdfKeyList = new Hashtable();	// �o�͗��������pKEY���X�g(KEY:���[KEY, Value:���[DLL)

        // --- ADD 杍^ 2021/01/04 PMKOBETSU-4109�̑Ή� ------>>>>
        private OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
        private ClientLogTextOut clientLogTextOut = null;
        // ���O�f�[�^��ʋ敪�R�[�h�F2�i���j���[���O�o�́j
        private const int MenuLog = 2;
        private const int OperationCode = 0;
        private const string DateMessage = "{0},{1},{2},{3},";
        private const string MethodName = "StartNavigatorTree_DoubleClick";
        private const string MethodNameExp = "StartNavigatorEXPTree_DoubleClick";
        private const string MethodNameInp = "StartNavigatorINPTree_DoubleClick";
        private const string ErrMessageInit = "���O�o�͕��i�������G���[";
        private const string ErrMessage = ":�N��PG���O�o�̓G���[";
        // --- ADD 杍^ 2021/01/04 PMKOBETSU-4109�̑Ή� ------<<<<

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

        #endregion

        // ===============================================================================
        // �f���Q�[�g�C�x���g
        // ===============================================================================
        #region delegateEvent
        private void ParentToolbarSettingEvent(object sender)
        {
            this.ToolBarSetting(sender);
        }
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
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
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
            if (extractButton != null)
            {
                extractButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;
                extractButton.SharedProps.Enabled = false;
            }

            // --- ADD 2009/05/12 ------------------------------->>>>>
            // ����߰ẴA�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool exportButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXPORTBUTTON_KEY];
            if (exportButton != null)
            {
                exportButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;
                exportButton.SharedProps.Enabled = false;
            }

            // ���߰ẴA�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool importButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_IMPORTBUTTON_KEY];
            if (importButton != null)
            {
                importButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVTAKING;
                importButton.SharedProps.Enabled = false;
            }
            // --- ADD 2009/05/12 ------------------------------<<<<<

            // 2010/03/31 Add >>>
            Infragistics.Win.UltraWinToolbars.ButtonTool setupButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SETUPBUTTON_KEY];
            if (setupButton != null)
            {
                setupButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;
                setupButton.SharedProps.Enabled = false;
            }
            // 2010/03/31 Add <<<

            // �v���r���[�̃A�C�R���ݒ�            
            Infragistics.Win.UltraWinToolbars.ButtonTool previewButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
            if (previewButton != null)
            {
                previewButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PREVIEW;
                previewButton.SharedProps.Enabled = false;
            }

            // ����̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool printButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
            if (printButton != null)
            {
                printButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;
                printButton.SharedProps.Enabled = false;
            }

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
                this._employeeName = employee.Name;
            }

#if CHG20060417
            // �v���r���[�̃A�C�R���ݒ�            
            Infragistics.Win.UltraWinToolbars.ButtonTool pdfSaveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
            if (pdfSaveButton != null) pdfSaveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
#endif
            // �^�u�R���g���[���̐ݒ�
            this.Sub_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.Sub_UTabControl.InterTabSpacing = 2;
            this.Sub_UTabControl.TabOrientation = Infragistics.Win.UltraWinTabs.TabOrientation.TopLeft;
            this.Sub_UTabControl.Appearance.FontData.SizeInPoints = 11;

            // --- ADD 2009/05/12 ------------------------------->>>>>
            // �^�u�R���g���[���̐ݒ�
            this.SubExp_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.SubExp_UTabControl.InterTabSpacing = 2;
            this.SubExp_UTabControl.TabOrientation = Infragistics.Win.UltraWinTabs.TabOrientation.TopLeft;
            this.SubExp_UTabControl.Appearance.FontData.SizeInPoints = 11;
            // --- ADD 2009/05/12 ------------------------------<<<<<
        }



        /// <summary>
        /// �^�u�N���G�C�g����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �^�u�t�H�[���𐶐����܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
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
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
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
        /// <br>Programer  : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private Form CreateTabForm(FormControlInfo info)
        {
            Form form = null;

            if (info.Key.Substring(info.Key.Length - 7).Equals("PREVIEW"))
            {
                form = new Broadleaf.Windows.Forms.PMKHN08500UB();
            }
            else
            {
                form = (System.Windows.Forms.Form)this.LoadAssemblyFrom(info.AssemblyID, info.ClassID, typeof(System.Windows.Forms.Form));
            }

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
                // �c�[���o�[�{�^������C�x���g 
                if (form is IPrintConditionInpType)
                {
                    ((IPrintConditionInpType)form).ParentToolbarSettingEvent += new ParentToolbarSettingEventHandler(this.ParentToolbarSettingEvent);
                }




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

                if (form is IPrintConditionInpType)
                {
                    ((IPrintConditionInpType)form).Show(info.Param);
                }
                else
                {
                    form.Show();
                }
                form.Dock = System.Windows.Forms.DockStyle.Fill;
            }

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
        /// <br>Programer  : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private void SelectedPdfView(string key, string printName, string pdfpath)
        {

#if CHG20060417
            // �v���r���[�^�u����
            this.TabCreate(NO1_LISTPREVIEW_TAB);
            if (this._listPreviewForm != null)
            {
                this.TabActive(NO1_LISTPREVIEW_TAB, ref this._listPreviewForm);

                PMKHN08500UB target = this._listPreviewForm as PMKHN08500UB;

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
				((PMKHN08500UB)this._listPreviewForm).ShowPDFPreview((Object)pdfpath);
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


            // ����ꎞ���f���x��
            lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_STOPLABEL_KEY];
            if (lblTool != null) lblTool.SharedProps.Visible = false;

            // ����ꎞ���f����
            containerTool = (Infragistics.Win.UltraWinToolbars.ControlContainerTool)Main_ToolbarsManager.Tools[TOOLBAR_PRTSUSPENDCNT_KEY];
            if (containerTool != null) containerTool.SharedProps.Visible = false;

            // ����������x��
            lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_NUMBERLABEL_KEY];
            if (lblTool != null) lblTool.SharedProps.Visible = false;


            // ���o
            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
            if (buttonTool != null) buttonTool.SharedProps.Visible = true;
            // ���ޑI�����x��
            lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDTITLE_KEY];
            if (lblTool != null) lblTool.SharedProps.Visible = false;
            // ���ޑI���R���{
            combboxTool = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDCOMB_KEY];
            if (combboxTool != null) combboxTool.SharedProps.Visible = false;
            // �v���r���[
            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
            if (buttonTool != null) buttonTool.SharedProps.Visible = true;
            // ���
            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
            if (buttonTool != null) buttonTool.SharedProps.Visible = true;
            // ���[�U�[�ݒ�
            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_USERSETUP_KEY];
            if (buttonTool != null) buttonTool.SharedProps.Visible = false;
            // PDF����ۑ�
            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
            if (buttonTool != null) buttonTool.SharedProps.Visible = true;
            // �e�L�X�g�o��
            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
            if (buttonTool != null) buttonTool.SharedProps.Visible = false;

            // --- ADD 2009/05/12 ------------------------------->>>>>
            // ����߰�
            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXPORTBUTTON_KEY];
            if (buttonTool != null) buttonTool.SharedProps.Visible = true;
            // ���߰�
            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_IMPORTBUTTON_KEY];
            if (buttonTool != null) buttonTool.SharedProps.Visible = true;
            // --- ADD 2009/05/12 ------------------------------<<<<<

            // 2010/03/31 Add >>>
            // �ݒ�
            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SETUPBUTTON_KEY];
            if (buttonTool != null) buttonTool.SharedProps.Visible = true;
            // 2010/03/31 Add <<<

        }

        #region ���@�o�͒��[���������ݒ菈��
        /// <summary>
        /// �o�͒��[��������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�X�e���I�����X�g�̍쐬���s���܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private void InitSettingPdfHistorySubForm()
        {
            try
            {
                this._pdfHistorySerchForm = new SFANL06101UA();
                this._pdfHistorySerchForm.LoginWorker = this._employeeName;

                //mControlScreenSkin.SettingScreenSkin(this._pdfHistorySerchForm);

                // ���[�I���C�x���g��ǉ�
                this._pdfHistorySerchForm.SelectNode += new SelectNodeEvent(SelectPdfHistoryListNode);

                // �t�H�[���̋N��
                this._pdfHistorySerchForm.TopLevel = false;
                this._pdfHistorySerchForm.FormBorderStyle = FormBorderStyle.None;
                this.PdfHistory_Panel.Controls.Add(this._pdfHistorySerchForm);
                this._pdfHistorySerchForm.Dock = System.Windows.Forms.DockStyle.Fill;
                this._pdfHistorySerchForm.BringToFront();
                this._pdfHistorySerchForm.Show();
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                    ex.Message,
                    -1,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
        }
        #endregion

        #region ���@�o�͒��[�����Ǘ���ʒ��[�I������
        /// <summary>
        /// �o�͗����Ǘ���ʑI������
        /// </summary>
        /// <param name="printKey">���[KEY</param>
        /// <param name="printName">���[��</param>
        /// <param name="PDFFileName">PDF�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : �V�X�e���I�����X�g�̍쐬���s���܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private void SelectPdfHistoryListNode(string printKey, string printName, string PDFFileName)
        {
            // �h�b�N�}�l�[�W���[�̌Œ�s������
            //this.Main_DockManager.ControlPanes[DOCKMANAGER_PDFHISTORTY_KEY].Unpin();

            if (this._setPdfKeyList.ContainsKey(printKey))
            {
                string infoKey = this._setPdfKeyList[printKey].ToString();

                System.Windows.Forms.Form frm = null;

                this.TabCreate(infoKey + "PREVIEW");

                this.TabActive(infoKey + "PREVIEW", ref frm);

                if (frm != null)
                {
                    PMKHN08500UB target = frm as PMKHN08500UB;

                    target.IsSave = false;
                    target.PrintKey = "";
                    target.PrintName = "";
                    target.PrintDetailName = "";
                    target.PrintPDFPath = "";

                    target.Navigate((Object)PDFFileName);
                }

                // �c�[���o�[�{�^���ݒ�
                this.ToolBarSetting(frm);
                // �h�b�N�}�l�W���[�ݒ�
                //this.DockManagerCtrlPaneSetting(frm);
            }
        }
        #endregion

        #region ���@�o�c�e����ۑ�
        /// <summary>
        /// �o�c�e����ۑ�����
        /// </summary>
        /// <param name="key">�Ώے��[KEY</param>
        /// <remarks>
        /// <br>Note       : �Ώے��[KEY�̂o�c�e�t�@�C���𗚗�ۑ����܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private void SavePDF(string key)
        {
            try
            {
                // �r���[�t�H�[���̏ꍇ�͐e��KEY���擾
                string mainKey = key.ToString().Replace(TAB_VIEWFORM_ADDKEY, "");

                // �A�N�e�B�u�^�u���璠�[�R���g���[�������擾
                FormControlInfo info = this._formControlInfoTable[mainKey] as FormControlInfo;
                if (info == null) return;
                // PDF�v���r���[�t�H�[��
                PMKHN08500UB target = info.Form as PMKHN08500UB;
                if (target == null) return;


                // ����ۑ��͉\���H
                if (target.IsSave)
                {
                    if (this._pdfHistorySerchForm != null)
                    {
                        // �d���`�F�b�N
                        if (this._pdfHistorySerchForm.Contains(target.PrintKey, target.PrintPDFPath))
                        {
                            TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "�Y���̂o�c�e�͊��ɗ���o�^����Ă��܂��B", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            return;
                        }

                        // �o�͗����Ǘ��ɒǉ�
                        this._pdfHistorySerchForm.AddPrintInfo(target.PrintKey, target.PrintName, target.PrintDetailName,
                            target.PrintPDFPath);

                        // �폜���X�g���珜�O����
                        if (this._delPDFList.Contains(target.PrintPDFPath))
                        {
                            this._delPDFList.Remove(target.PrintPDFPath);
                        }
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

        /// <summary>
        /// �r���[�t�H�[���^�u�N���G�C�g����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �r���[�^�u�t�H�[���𐶐����܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
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
        /// <br>Programer  : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private void ToolBarSetting(object activeForm)
        {
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool;
            Infragistics.Win.UltraWinToolbars.ComboBoxTool combboxTool;
            Infragistics.Win.UltraWinToolbars.ControlContainerTool containerTool;

            if (activeForm != null)
            {
                if (activeForm is IPrintConditionInpType)
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
                        isEnbled = true;
                        combboxTool.SharedProps.Enabled = isEnbled;
                    }

                    // PDF�\��
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = true;
                    }

                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
                    if (buttonTool != null) buttonTool.SharedProps.Enabled = true;

                    // ���
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
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

                    // --- ADD 2009/05/12 ------------------------------->>>>>
                    // ����߰�
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXPORTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }
                    // ���߰�
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_IMPORTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }
                    // --- ADD 2009/05/12 ------------------------------<<<<<

                    // 2010/03/31 Add >>>
                    // �ݒ�
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SETUPBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }
                    // 2010/03/31 Add <<<

                    this.Set_PreviewMode(true);

                }
                else if (activeForm is PMKHN08500UB)
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
                        PMKHN08500UB target = activeForm as PMKHN08500UB;
                        if (target != null)
                        {
                            buttonTool.SharedProps.Enabled = target.IsSave;
                        }
                    }

                    // --- ADD 2009/05/12 ------------------------------->>>>>
                    // ����߰�
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXPORTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }
                    // ���߰�
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_IMPORTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }
                    // --- ADD 2009/05/12 ------------------------------<<<<<

                    // 2010/03/31 Add >>>
                    // �ݒ�
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SETUPBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }
                    // 2010/03/31 Add <<<


                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
                    if (buttonTool != null) buttonTool.SharedProps.Enabled = false;

                    this.Set_PreviewMode(false);
                }
                // --- ADD 2009/05/12 ------------------------------->>>>>
                else if (activeForm is IExportConditionInpType)
                {
                    // ���o
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }

                    // ���ޑI���R���{
                    bool isEnbled = false;
                    combboxTool = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDCOMB_KEY];
                    if (combboxTool != null)
                    {
                        isEnbled = false;
                        combboxTool.SharedProps.Enabled = isEnbled;
                    }

                    // PDF�\��
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }

                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
                    if (buttonTool != null) buttonTool.SharedProps.Enabled = false;

                    // ���
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
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

                    // ����߰�
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXPORTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = true;
                    }
                    // ���߰�
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_IMPORTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }

                    // 2010/03/31 Add >>>
                    // �ݒ�
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SETUPBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }
                    // 2010/03/31 Add <<<

                }
                else if (activeForm is IImportConditionInpType)
                {
                    // ���o
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRACTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }

                    // ���ޑI���R���{
                    bool isEnbled = false;
                    combboxTool = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDCOMB_KEY];
                    if (combboxTool != null)
                    {
                        isEnbled = false;
                        combboxTool.SharedProps.Enabled = isEnbled;
                    }

                    // PDF�\��
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }

                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
                    if (buttonTool != null) buttonTool.SharedProps.Enabled = false;

                    // ���
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
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

                    // ����߰�
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXPORTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }
                    // ���߰�
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_IMPORTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = true;
                    }

                    // 2010/03/31 Add >>>
                    // �ݒ�
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SETUPBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }
                    // 2010/03/31 Add <<<

                }
                // --- ADD 2009/05/12 ------------------------------<<<<<
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

                // --- ADD 2009/05/12 ------------------------------->>>>>
                // ����߰�
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXPORTBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }
                // ���߰�
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_IMPORTBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }
                // --- ADD 2009/05/12 ------------------------------<<<<<

                // 2010/03/31 Add >>>
                // �ݒ�
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SETUPBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }
                // 2010/03/31 Add <<<


                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
                if (buttonTool != null) buttonTool.SharedProps.Enabled = false;

                this.Set_PreviewMode(true);
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
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// <br>Update Note: 2011/12/20 �����x</br>
        /// <br>�Ǘ��ԍ�   : 10707327-00 2012/01/25�z�M��</br>
        /// <br>             Redmine#27268�@���[�t���[���^�N���i�r�Q�[�^�[�̃��_�`�F�b�N�̏C��</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, CT_PGID, iMsg, iSt, iButton, iDefButton);
        }

        /// <summary>
        /// ����c���[�r���[�\��
        /// </summary>
        private void ConstructionTreeNode()
        {
            // �N���i�r�Q�[�^��񂪊i�[���ꂽ�o�C�i���t�@�C���̃��[�h
            if (System.IO.File.Exists(NAVIGATORTREE_XML))
            {
                this.StartNavigatorTree.LoadFromBinary(NAVIGATORTREE_XML);
            }

            this.StartNavigatorTree.Appearance.BackColor = Color.White;
            this.StartNavigatorTree.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(222)), ((System.Byte)(239)), ((System.Byte)(255)));
            this.StartNavigatorTree.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.StartNavigatorTree.HideSelection = false;
            bool firstNode = true;

            Hashtable delNode2KeyLst = new Hashtable();
            Hashtable delNode3KeyLst = new Hashtable();

            // �m�[�h�̕\����\���𐧌䂷��
            if (_parameter.Length != 0)
            {
                // �I���m�[�h��擪�Ɉړ�������
                firstNode = this.StartNavigatorTree.PerformAction(
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
                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn1 in this.StartNavigatorTree.Nodes)
                {
                    if (utn1.Nodes.Count != 0)
                    {
                        foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn2 in utn1.Nodes)
                        {
                            if (utn2.Nodes.Count != 0)
                            {
                                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn3 in utn2.Nodes)
                                {
                                    utn3.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.Standard;//ADD liuyj 2011/12/20 Redmine#27268
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
#if false		// USB��Company�`�F�b�N�֕ύX
                      if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(productCode) > 0)
                      {
#else
                                            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(productCode) > 0)
                                            {
#endif
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
            firstNode = this.StartNavigatorTree.PerformAction(
                Infragistics.Win.UltraWinTree.UltraTreeAction.FirstNode,
                false,
                false);

            if (!firstNode)
            {
                return;
            }


            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn1 in this.StartNavigatorTree.Nodes)
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
                                    string strPara = PMKHN08500UA._parameter[i];
                                    int intPara = TStrConv.StrToIntDef(PMKHN08500UA._parameter[i], -1);

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
                                    utn3.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.Standard;//ADD liuyj 2011/12/20 Redmine#27268
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
                                            string strPara = PMKHN08500UA._parameter[i];
                                            int intPara = TStrConv.StrToIntDef(PMKHN08500UA._parameter[i], -1);

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

                                    // 2009/10/01 Add >>>
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
                                    // 2009/10/01 Add <<<

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

                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn1 in this.StartNavigatorTree.Nodes)
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

                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn1 in this.StartNavigatorTree.Nodes)
                {
                    utn1.Nodes.Remove(utn);
                }
            }

            this.StartNavigatorTree.ExpandAll();
        }

        /// <summary>
        /// ���쌠���̐�����J�n���܂��B
        /// </summary>
        /// <param name="assemblyId">�A�Z���u��ID</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���쌠���ɉ������{�^������̑Ή�</br>
        /// <br>Programmer  : 30462 �s�V �m��</br>
        /// <br>Date        : 2008.10.24</br>
        /// </remarks>
        private void BeginControllingByOperationAuthority(string assemblyId)
        {
            #region <Guard Phrase/>

            if (!MyOpeCtrlMap.ContainsKey(assemblyId)) return;

            #endregion  // <Guard Phrase/>

            // �c�[���{�^���̑��쌠���̐���ݒ�
            List<ToolButtonInfo> toolButtonInfoList = new List<ToolButtonInfo>();

            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_PRINTBUTTON_KEY, ReportFrameOpeCode.Print, false));
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_EXTRACTBUTTON_KEY, ReportFrameOpeCode.Extract, false));
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_PREVIEWBUTTON_KEY, ReportFrameOpeCode.OutputPDF, false));
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_PDFSAVEBUTTON_KEY, ReportFrameOpeCode.SavePDF, false));
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_TEXTOUTPUT_KEY, ReportFrameOpeCode.OutputText, false));
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_USERSETUP_KEY, ReportFrameOpeCode.Setup, true));

            MyOpeCtrlMap[assemblyId].MyOpeCtrl.AddControlItem(this.Main_ToolbarsManager, toolButtonInfoList);

            // ���쌠���̐�����J�n
            MyOpeCtrlMap[assemblyId].MyOpeCtrl.BeginControl();
        }

        #region ���@�e���[�����t�h�N���X�N������
        /// <summary>
        /// �e���[����UI��ʋN������
        /// </summary>
        /// <param name="key">�ΏۃL�[���</param>
        /// <remarks>
        /// <br>Note       : �����̃L�[�������ɁA�^�u���A�N�e�B�u�����܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private void ShowChildInputForm(string key)
        {
            Cursor nowCursor = this.Cursor;
            System.Windows.Forms.Form childForm = null;


            try
            {
                // �N���q��ʍ쐬����
                this.TabCreate(key);

                // �N���q��ʃA�N�e�B�u������		
                this.TabActive(key, ref childForm);

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
        #endregion

        #region ���@�e���[����UI��ʌʉ�ʐݒ菈��
        /// <summary>
        /// �e���[����UI��ʌʉ�ʐݒ菈��
        /// </summary>
        /// <param name="key">�ΏۃL�[���</param>
        /// <param name="activeForm">�A�N�e�B�u�ΏۂƂȂ�Form</param>
        /// <remarks>
        /// <br>Note       :�e������ʌʂ̃t���[����ʂ�ݒ肵�܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
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
                info.SelSectionKindIndex = 0;														// ���_���

                info.SelSystems = info.SoftWareCode;										// �V�X�e���I��                
            }

            //----------------------------------------------------------------------------//
            // ��ʏ��X�V����                                                           //
            //----------------------------------------------------------------------------//



            //----------------------------------------------------------------------------//
            // �o�͒��[���������\������                                                   //
            //----------------------------------------------------------------------------//
            // �o�͒��[���������C���^�[�t�F�C�X���������Ă���
            if (activeForm is IPrintConditionInpTypePdfCareer)
            {
                if (this.Main_DockManager.ControlPanes[DOCKMANAGER_PDFHISTORTY_KEY].Closed)
                    this.Main_DockManager.ControlPanes[DOCKMANAGER_PDFHISTORTY_KEY].Show();

                // �o�͒��[���������C���^�[�t�F�C�X�ŃL���X�g 
                IPrintConditionInpTypePdfCareer targetObj = activeForm as IPrintConditionInpTypePdfCareer;

                if (!info.IsInit)
                {
                    if (targetObj.PrintKey != null)
                    {
                        // �Y���̒��[KEY�͊��ɐݒ�ς݂��H
                        if (!this._setPdfKeyList.ContainsKey(targetObj.PrintKey))
                        {
                            // ���[����������ʂɒ��[KEY�ǉ�
                            this._pdfHistorySerchForm.SetPrintKey(targetObj.PrintKey, targetObj.PrintName);
                            if (info != null)
                            {
                                this._setPdfKeyList.Add(targetObj.PrintKey, info.Key);
                            }
                        }
                    }
                }
            }
            else
            {

            }




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
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// <br>Update Note: 2011/12/20 �����x</br>
        /// <br>�Ǘ��ԍ�   : 10707327-00 2012/01/25�z�M��</br>
        /// <br>             Redmine#27268�@���[�t���[���^�N���i�r�Q�[�^�[�̃��_�`�F�b�N�̏C��</br>
        /// </remarks>
        private int CreateFormControlInfo()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            if (this.StartNavigatorTree.Nodes.Count == 0) return status;

            this._formControlInfoTable.Clear();

            FormControlInfo info = null;

            // �I���m�[�h��擪�Ɉړ�������
            bool result = this.StartNavigatorTree.PerformAction(
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

            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn1 in this.StartNavigatorTree.Nodes)
            {
                if (utn1.Nodes.Count != 0)
                {
                    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn2 in utn1.Nodes)
                    {
                        if (utn2.Nodes.Count != 0)
                        {
                            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn3 in utn2.Nodes)
                            {
                                utn3.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.Standard;//ADD liuyj 2011/12/20 Redmine#27268
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

                                    this._formControlInfoTable.Add(utn3.DataKey.ToString(), info);

                                    info = new FormControlInfo(utn3.DataKey.ToString() + "PREVIEW",
                                        assemblyID,
                                        utn3.Override.Tag.ToString(),
                                        utn3.Text + "�v���r���[",
                                        utn3.Override.NodeAppearance.Image,
                                        ctrlFuncCode,
                                        param,
                                        softWareCodeList.ToArray());

                                    this._formControlInfoTable.Add(utn3.DataKey.ToString() + "PREVIEW", info);

                                    utn3.Key = utn3.DataKey.ToString();
                                }
                            }
                        }
                    }
                }
            }

            // �v���O�������͐ݒ肳��Ă��邩
            status = (this._formControlInfoTable.Count == 0 ? (int)ConstantManagement.MethodResult.ctFNC_ERROR : (int)ConstantManagement.MethodResult.ctFNC_NORMAL);
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
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
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
        /// <br>Programer  : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
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
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
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

            // --- ADD 2009/05/12 ------------------------------->>>>>
            Infragistics.Win.UltraWinTabControl.UltraTabControl uTabControl = null;
            if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[0])
            {
                uTabControl = this.Sub_UTabControl;
            }
            else if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[1])
            {
                uTabControl = this.SubExp_UTabControl;
            }
            else if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[2])
            {
                uTabControl = this.SubImp_UTabControl;
            }

            for (int i = 0; i < uTabControl.Tabs.Count; i++)
            // --- ADD 2009/05/12 ------------------------------<<<<<
            // for (int i = 0; i < this.Sub_UTabControl.Tabs.Count; i++) DEL 2009/05/12
            {
                Infragistics.Win.UltraWinTabControl.UltraTab tab = uTabControl.Tabs[i]; // ADD 2009/05/12
                //Infragistics.Win.UltraWinTabControl.UltraTab tab = this.Sub_UTabControl.Tabs[i]; // DEL 2009/05/12

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
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
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
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2006.03.28</br>
        /// </remarks>
        private void WindowStateButtonTool_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            if ((this.Sub_UTabControl.Tabs.Exists(e.Tool.Key)))
            {
                if (!(e.Tool is Infragistics.Win.UltraWinToolbars.StateButtonTool)) return;

                Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = (Infragistics.Win.UltraWinToolbars.StateButtonTool)e.Tool;
                if (stateButtonTool.Checked)
                {
                    this.Sub_UTabControl.SelectedTab = this.Sub_UTabControl.Tabs[e.Tool.Key];

                    this.Sub_UTabControl.ContextMenu = this.TabControl_contextMenu;
                    Form selectedForm = this._formControlInfoTable[this.Sub_UTabControl.SelectedTab.Key] as Form;


                    if (selectedForm == null)
                    {
                        if (this._formControlInfoTable.Contains(this.Sub_UTabControl.SelectedTab.Key))
                        {
                            FormControlInfo formInfo = this._formControlInfoTable[this.Sub_UTabControl.SelectedTab.Key] as FormControlInfo;
                            if (formInfo != null) selectedForm = formInfo.Form;
                        }
                    }

                }
            }
            // --- ADD 2009/05/12 ------------------------------->>>>>
            else if (this.SubExp_UTabControl.Tabs.Exists(e.Tool.Key))
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
            // --- ADD 2009/05/12 ------------------------------<<<<<
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
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
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

            // --- ADD 2009/05/12 ------------------------------->>>>>
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
            // --- ADD 2009/05/12 ------------------------------<<<<<
        }
        #endregion

        #region ���@�i�r�Q�[�V�����̊Y���L�[�m�[�h�I����ԕύX
        /// <summary>
        /// �i�r�Q�[�V�����̊Y���L�[�m�[�h�I����ԕύX
        /// </summary>
        /// <param name="key">�L�[</param>
        /// <remarks>
        /// <br>Note       : �i�r�Q�[�V�����̊Y���L�[�m�[�h�I����Ԃ𐧌䂵�܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private void NodeSelectChaneg(string key, bool isSelected)
        {
            // �Y���L�[�̃m�[�h���擾
            //Infragistics.Win.UltraWinTree.UltraTreeNode node = this.StartNavigatorTree.GetNodeByKey(key);  DEL 2009/05/12

            // --- ADD 2009/05/12 ------------------------------->>>>>
            Infragistics.Win.UltraWinTree.UltraTreeNode node = null;
            if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[0])
            {
                node = this.StartNavigatorTree.GetNodeByKey(key);
            }
            else if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[1])
            {
                node = this.StartNavigatorEXPTree.GetNodeByKey(key);
            }
            else if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[2])
            {
                node = this.StartNavigatorINPTree.GetNodeByKey(key);
            }
            // --- ADD 2009/05/12 ------------------------------<<<<<

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
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
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
        /// <br>Programmer  : 30462 �s�V �m��</br>
        /// <br>Date        : 2008.10.24</br>
        /// </remarks>
        private void PMKHN08500UA_Load(object sender, System.EventArgs e)
        {
            // ������ʐݒ�
            this.InitialScreenSetting();

            // �^�C�g���ݒ�
            this.Text = MAIN_FORM_TITLE;

            // �N���i�r�Q�[�^�[�\�z
            this.ConstructionTreeNode();

            // �N���i�r�Q�[�^�[�\�z(����߰ĂƲ��߰�)
            this.ConstructionExpInpTreeNode();  // ADD 2009/05/12

            // �E�C���h�E�{�^���쐬����
            this.CreateWindowStateButtonTools();

            // �o�͒��[�Ǘ�������ʐݒ�
            this.InitSettingPdfHistorySubForm();

            int status;
            // �v���O�������e�[�u���\�z
            status = this.CreateFormControlInfo();

            status = CreateExpInpFormControlInfo();// ADD 2009/05/12
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

            // ADD 2009/03/18 �s��Ή�[12537]�F���쌠������̒ǉ� ---------->>>>>
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
            // ADD 2009/03/18 �s��Ή�[12537]�F���쌠������̒ǉ� ----------<<<<<
        }

        /// <summary>
        /// ���������^�C�}�[�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : �����^�C�}�[�C�x���g�ł��B</br>
        /// <br>Programmer  : 30462 �s�V �m��</br>
        /// <br>Date        : 2008.10.24</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            // �C�x���g�t���OOFF
            this._eventDoFlag = false;
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

                // ���ޑI���R���{
                Infragistics.Win.UltraWinToolbars.ComboBoxTool combboxTool = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTKINDCOMB_KEY];
                if (combboxTool != null)
                {
                    combboxTool.SelectedIndex = 0;
                }

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
        /// <br>Programmer  : 30462 �s�V �m��</br>
        /// <br>Date        : 2008.10.24</br>
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

                    // ���o
                    case TOOLBAR_EXTRACTBUTTON_KEY:
                        {
                            int printMode = (int)emPrintMode.emPrinter;

                            // �A�N�e�B�u��Ԃ̃^�u����t�H�[�����擾����
                            FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Sub_UTabControl.ActiveTab.Key.ToString()];
                            System.Windows.Forms.Form activeForm = formControlInfo.Form;

                            if (activeForm is IPrintConditionInpType)
                            {
                                IPrintConditionInpType childObj = activeForm as IPrintConditionInpType;

                                // �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾����			
                                DataSet bindDataSet = new DataSet();
                                childObj.GetBindDataSet(ref bindDataSet, ref this._tableName);
                                this.BindDataSet = bindDataSet;

                                // ���o�O�`�F�b�N
                                if (!childObj.PrintBeforeCheck()) return;

                                // ���o�f�[�^�擾
                                SFCMN06002C printInfo = new SFCMN06002C();
                                printInfo.printmode = printMode;
                                printInfo.pdfopen = false;
                                printInfo.pdftemppath = "";

                                int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                                Object parameter = (object)printInfo;

                                status = childObj.Extract(ref parameter);

                                switch (status)
                                {
                                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                                        {
                                            // ADD 2008/12/03 �s��Ή�[8649] ---------->>>>>
                                            if (this.BindDataSet.Tables[this._tableName].DefaultView.Count <= 0)
                                            {
                                                TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                                            }
                                            // ADD 2008/12/03 �s��Ή�[8649] ----------<<<<<

                                            // �f�[�^�\�[�X��ݒ�
                                            this.DataViewGrid.DataSource = this.BindDataSet.Tables[this._tableName].DefaultView;

                                            // �O���b�h�̃��C�A�E�g�ݒ�
                                            childObj.SetGridStyle(ref DataViewGrid);
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

                    case TOOLBAR_PREVIEWBUTTON_KEY: // �v���r���[
                    case TOOLBAR_PRINTBUTTON_KEY: // ���     
                        {

                            int printMode = (int)emPrintMode.emPrinter;

                            switch (e.Tool.Key)
                            {
                                case TOOLBAR_PRINTBUTTON_KEY:
                                    // �ʏ���
                                    printMode = (int)emPrintMode.emPrinterAndPDF;
                                    break;
                                case TOOLBAR_PREVIEWBUTTON_KEY:
                                    // PDF�\��
                                    printMode = (int)emPrintMode.emPDF;
                                    break;
                                default:
                                    break;
                            }

                            // �A�N�e�B�u�^�u����t�H�[�����擾
                            FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Sub_UTabControl.ActiveTab.Key.ToString()];
                            System.Windows.Forms.Form activeForm = formControlInfo.Form;

                            if (activeForm is IPrintConditionInpType)
                            {
                                SFCMN06002C printInfo = new SFCMN06002C();
                                printInfo.printmode = printMode;
                                printInfo.pdfopen = false;
                                printInfo.pdftemppath = "";

                                IPrintConditionInpType childObj = activeForm as IPrintConditionInpType;

                                // ����O�`�F�b�N
                                if (!childObj.PrintBeforeCheck()) return;

                                int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                                Object parameter = (object)printInfo;

                                // ���o�ς݂��𔻒f
                                if (this.DataViewGrid.DataSource == null)
                                {
                                    // �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾����			
                                    DataSet bindDataSet = new DataSet();
                                    childObj.GetBindDataSet(ref bindDataSet, ref this._tableName);
                                    this.BindDataSet = bindDataSet;

                                    // ���o���������s
                                    status = childObj.Extract(ref parameter);

                                    switch (status)
                                    {
                                        case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                                            {
                                                // �f�[�^�\�[�X��ݒ�
                                                this.DataViewGrid.DataSource = this.BindDataSet.Tables[this._tableName].DefaultView;

                                                // �O���b�h�̃��C�A�E�g�ݒ�
                                                childObj.SetGridStyle(ref DataViewGrid);
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
                                    _reLoad = false;  //ADD 2011/08/03
                                }
                                else
                                {

                                    // ���o�����̃`�F�b�N
                                    //if (!childObj.DataCheck())   //DEL 2011/08/03
                                    if (!childObj.DataCheck() || _reLoad)   //ADD 2011/08/03
                                    {
                                        // �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾����			
                                        DataSet bindDataSet = new DataSet();
                                        childObj.GetBindDataSet(ref bindDataSet, ref this._tableName);
                                        this.BindDataSet = bindDataSet;

                                        // ���o���������s
                                        status = childObj.Extract(ref parameter);

                                        switch (status)
                                        {
                                            case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                                                {
                                                    // �f�[�^�\�[�X��ݒ�
                                                    this.DataViewGrid.DataSource = this.BindDataSet.Tables[this._tableName].DefaultView;

                                                    // �O���b�h�̃��C�A�E�g�ݒ�
                                                    childObj.SetGridStyle(ref DataViewGrid);
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
                                        _reLoad = false;  //ADD 2011/08/03
                                    }

                                }

                                // ����f�[�^�̐ݒ�
                                if (this.DataViewGrid.DisplayLayout.Bands[0].SortedColumns.Count != 0)
                                {
                                    this.BindDataSet.Tables[this._tableName].DefaultView.Sort = this.DataViewGrid.DisplayLayout.Bands[0].SortedColumns.GetItem(0).ToString();
                                }
                                printInfo.rdData = this.BindDataSet.Tables[this._tableName].DefaultView;

                                // �������
                                status = childObj.Print(ref parameter);




                                switch (status)
                                {
                                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                                        {
                                            // PDF�\���̏ꍇ
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

                                                // �o�c�e��ʕ\��
                                                if (printInfo.pdfopen)
                                                {
                                                    System.Windows.Forms.Form frm = null;

                                                    FormControlInfo info = (FormControlInfo)this._formControlInfoTable[this.Sub_UTabControl.ActiveTab.Key.ToString() + "PREVIEW"];

                                                    this.TabCreate(info.Key);

                                                    this.TabActive(info.Key, ref frm);

                                                    PMKHN08500UB viewFrm = frm as PMKHN08500UB;

                                                    if (viewFrm != null)
                                                    {
                                                        viewFrm.IsSave = true;
                                                        viewFrm.PrintKey = printInfo.key;
                                                        viewFrm.PrintName = printInfo.prpnm;
                                                        viewFrm.PrintDetailName = printInfo.prpnm;
                                                        viewFrm.PrintPDFPath = printInfo.pdftemppath;

                                                        viewFrm.Navigate((Object)printInfo.pdftemppath);
                                                    }

                                                    this.ToolBarSetting(viewFrm);

                                                    // �v���r���[�\������
                                                    this.Set_PreviewMode(false);

                                                }
                                            }
                                            break;
                                        }
                                    case (int)ConstantManagement.MethodResult.ctFNC_CANCEL:
                                        {
                                            break;
                                        }
                                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                                        if (this.BindDataSet.Tables[this._tableName].DefaultView.Count <= 0)
                                        {
                                            TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                                        }
                                        break;
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
                            this.SavePDF(this.Sub_UTabControl.ActiveTab.Key.ToString());
                            break;
                        }

                    case TOOLBAR_TEXTOUTPUT_KEY:
                        {
                            break;
                        }
                    // --- ADD 2009/05/12 ------------------------------->>>>>
                    // ����߰�
                    case TOOLBAR_EXPORTBUTTON_KEY:
                        {
                            _buttonEnable = false;
                            //int printMode = (int)emPrintMode.emPrinter;
                            

                            // �A�N�e�B�u��Ԃ̃^�u����t�H�[�����擾����
                            FormControlInfo formControlInfo = (FormControlInfo)this._expFormControlInfoTable[this.SubExp_UTabControl.ActiveTab.Key.ToString()];
                            System.Windows.Forms.Form activeForm = formControlInfo.Form;

                            if (activeForm is IExportConditionInpType)
                            {
                                IExportConditionInpType childObj = activeForm as IExportConditionInpType;

                                // �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾����			
                                DataSet bindDataSet = new DataSet();
                                childObj.GetBindDataSet(ref bindDataSet, ref this._tableName);
                                this.BindDataSet = bindDataSet;

                                // ���o�f�[�^�擾
                                SFCMN06002C printInfo = new SFCMN06002C();
                                printInfo.pdfopen = false;
                                printInfo.pdftemppath = "";

                                int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                                Object parameter = (object)printInfo;

                                // ���o�O�`�F�b�N
                                if (!childObj.ExportBeforeCheck())
                                {
                                    _buttonEnable = true;
                                    return;
                                }

                                status = childObj.Extract(ref parameter);

                                switch (status)
                                {
                                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                                        {
                                            if (this.BindDataSet.Tables[this._tableName].DefaultView.Count <= 0)
                                            {
                                                TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���B", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                                                break;
                                            }

                                            // CSV�o�͏�񏈗�
                                            status = childObj.GetCSVInfo(ref parameter);

                                            // CSV�o�͏���
                                            status = this.DoOutPut(ref parameter);

                                            // �o�͊����ꍇ
                                            if (status == 0)
                                            {
                                                childObj.AfterExportSuccess();
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
                            _reLoad = true;  //ADD 2011/08/03
                            break;
                        }
                    // ���߰�
                    case TOOLBAR_IMPORTBUTTON_KEY:
                        {
                            _buttonEnable = false;
                            // �A�N�e�B�u��Ԃ̃^�u����t�H�[�����擾����
                            FormControlInfo formControlInfo = (FormControlInfo)this._impFormControlInfoTable[this.SubImp_UTabControl.ActiveTab.Key.ToString()];
                            System.Windows.Forms.Form activeForm = formControlInfo.Form;

                            if (activeForm is IImportConditionInpType)
                            {
                                IImportConditionInpType childObj = activeForm as IImportConditionInpType;

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
                                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, CT_PGID, errMsg, (int)ConstantManagement.MethodResult.ctFNC_ERROR, MessageBoxButtons.OK);
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
                                        // �o�^����
                                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                                        dialog.ShowDialog(2);
                                    }
                                }
                            }
                            _buttonEnable = true;
                            break;
                        }
                    // --- ADD 2009/05/12 ------------------------------<<<<<

                    // 2010/03/31 Add >>>
                    // �ݒ�
                    case TOOLBAR_SETUPBUTTON_KEY:
                        {
                            FormControlInfo formControlInfo = (FormControlInfo)this._impFormControlInfoTable[this.SubImp_UTabControl.ActiveTab.Key.ToString()];
                            System.Windows.Forms.Form activeForm = formControlInfo.Form;
                            PMKHN08500UC form = new PMKHN08500UC(formControlInfo.Name, formControlInfo.AssemblyID);
                            form.ShowDialog();
                            break;
                        }
                    // 2010/03/31 Add <<<
                }
            }
        }

        /// <summary>
        /// �v���r���[���̉�ʐݒ�؂�ւ�
        /// </summary>
        private void Set_PreviewMode(bool visibleval)
        {
            this.StartNavigatorTree.Visible = visibleval;
            this.DataViewGrid.Visible = visibleval;
            this.ultraStatusBar1.Visible = visibleval;
            if (visibleval)
            {
                this.Sub_UTabControl.Dock = DockStyle.Top;
            }
            else
            {
                this.Sub_UTabControl.Dock = DockStyle.Fill;
            }
        }

        /// <summary>
        /// �c�[���o�[�̍��ڒl�ύX�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : �c�[���o�[���ڂ̒l���ύX���ꂽ�ۂɔ������܂��B</br>
        /// <br>Programmer  : 30462 �s�V �m��</br>
        /// <br>Date        : 2008.10.24</br>
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


                    controlContainer = (Infragistics.Win.UltraWinToolbars.ControlContainerTool)Main_ToolbarsManager.Tools[TOOLBAR_PRTSUSPENDCNT_KEY];
                    if (controlContainer != null) controlContainer.SharedProps.Visible = false;
                    lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_STOPLABEL_KEY];
                    if (lblTool != null) lblTool.SharedProps.Visible = false;

                    lblTool = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_NUMBERLABEL_KEY];
                    if (lblTool != null) lblTool.SharedProps.Visible = false;

                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PREVIEWBUTTON_KEY];
                    if (buttonTool != null) buttonTool.SharedProps.Enabled = true;

                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUT_KEY];
                    if (buttonTool != null) buttonTool.SharedProps.Enabled = true;

                }

                // ���[��ޕύX����
                if (this._eventDoFlag)
                {
                    // �A�N�e�B�u��Ԃ̃^�u����t�H�[�����擾����
                    FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Sub_UTabControl.ActiveTab.Key.ToString()];
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
        /// <br>Programer  : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
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
        /// <br>Note        : �t�H�[��������ꂽ��ɁA�������܂��B</br>
        /// <br>Programmer  : 30462 �s�V �m��</br>
        /// <br>Date        : 2008.10.24</br>
        /// </remarks>
        private void PMKHN08500UA_FormClosed(object sender, FormClosedEventArgs e)
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
                        PMKHN08500UB viewFrm = info.Form as PMKHN08500UB;
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

                foreach (Infragistics.Win.UltraWinTabControl.UltraTab tab in this.Sub_UTabControl.Tabs)
                {
                    this.Sub_UTabControl.Tabs.Remove(tab);
                }

                // --- ADD 2009/05/12 ------------------------------->>>>>
                foreach (Infragistics.Win.UltraWinTabControl.UltraTab tab in this.SubExp_UTabControl.Tabs)
                {
                    this.SubExp_UTabControl.Tabs.Remove(tab);
                }

                foreach (Infragistics.Win.UltraWinTabControl.UltraTab tab in this.SubImp_UTabControl.Tabs)
                {
                    this.SubImp_UTabControl.Tabs.Remove(tab);
                }
                // --- ADD 2009/05/12 ------------------------------<<<<<

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
                                break;
                            }
                            catch (System.IO.IOException)
                            {
                                System.Threading.Thread.Sleep(1000);
                            }
                            catch (Exception)
                            {
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

        /// <summary>
        /// �c���[�m�[�h�_�u���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : �N���i�r�Q�[�^�[�̃_�u���N���b�N�C�x���g�ł��B</br>
        /// <br>Programmer  : 30462 �s�V �m��</br>
        /// <br>Date        : 2008.10.24</br>
        /// <br>Update Note : 2021/01/04 杍^</br>
        /// <br>�Ǘ��ԍ�    : 11670323-00</br>
        /// <br>              PMKOBETSU-4109�@�v���O�����N�����O�𑀍엚�����O�ɏo�͂���ǉ��Ή�</br>
        /// </remarks>
        private void StartNavigatorTree_DoubleClick(object sender, System.EventArgs e)
        {
            Infragistics.Win.UltraWinTree.UltraTreeNode doubleClickedNode =
                this.StartNavigatorTree.GetNodeFromPoint(this._lastMouseDown);

            if (doubleClickedNode == null) return;

            FormControlInfo info = this._formControlInfoTable[doubleClickedNode.Key.ToString()] as FormControlInfo;
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
                ShowChildInputForm(node.Key.ToString());

                // 2010/03/31 Add >>>
                SetUpButtonToolEnable(node.Key.ToString());
                // 2010/03/31 Add <<<

                doubleClickedNode.Override.NodeAppearance.ForeColor = Color.Red;

                BeginControllingByOperationAuthority(info.AssemblyID);

                // --- ADD 杍^ 2021/01/04 PMKOBETSU-4109�̑Ή� ------>>>>
                try
                {
                    try
                    {
                        // �N���C�A���g���O�o�͕��i������
                        if (clientLogTextOut == null)
                        {
                            clientLogTextOut = new ClientLogTextOut();
                        }
                    }
                    catch
                    {
                        // �㑱�����ɉe�����Ȃ��悤��O�L���b�`
                    }

                    try
                    {
                        // ���엚�����O�o�͕��i������
                        if (operationHistoryLog == null)
                        {
                            operationHistoryLog = new OperationHistoryLog();
                        }
                    }
                    catch (Exception ex)
                    {
                        // �G���[�����O�o��
                        try
                        {
                            if (clientLogTextOut != null)
                            {
                                clientLogTextOut.Output(ex.Source, ErrMessageInit, (int)ConstantManagement.MethodResult.ctFNC_ERROR, ex);
                            }
                        }
                        catch
                        {
                            // �㑱�����ɉe�����Ȃ��悤��O�L���b�`
                        }
                    }

                    // ���O�o�͂��s��
                    string dateMessage = string.Format(DateMessage, CT_PGNAME, node.Parent.Text, node.Text, info.AssemblyID);
                    if (operationHistoryLog != null)
                    {
                        // ���엚�����O�o��
                        operationHistoryLog.WriteOperationLog(this, DateTime.Now, (LogDataKind)MenuLog,
                            CT_PGID, CT_PGNAME, MethodName, OperationCode, (int)ConstantManagement.MethodResult.ctFNC_NORMAL, dateMessage, string.Empty);
                    }
                }
                catch (Exception ex)
                {
                    // �G���[�����O�o��
                    try
                    {
                        if (clientLogTextOut != null)
                        {
                            clientLogTextOut.Output(ex.Source, MethodName + ErrMessage, (int)ConstantManagement.MethodResult.ctFNC_ERROR, ex);
                        }
                    }
                    catch
                    {
                        // �㑱�����ɉe�����Ȃ��悤��O�L���b�`
                    }
                }
                // --- ADD 杍^ 2021/01/04 PMKOBETSU-4109�̑Ή� ------<<<<
            }
        }

        /// <summary>
        /// Control.MouseDown �C�x���g(StartNavigatorTree)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �c���[�R���g���[���ɂă}�E�X�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : 30462 �s�V �m��</br>
        /// <br>Date        : 2008.10.24</br>
        /// </remarks>
        private void StartNavigatorTree_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this._lastMouseDown = new Point(e.X, e.Y);
        }

        /// <summary>
        /// �|�b�v���j���[�u����v�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note        : �u����v�{�^���������ɔ������܂��B</br>
        /// <br>Programmer  : 30462 �s�V �m��</br>
        /// <br>Date        : 2008.10.24</br>
        /// </remarks>
        private void Close_menuItem_Click(object sender, System.EventArgs e)
        {
            // --- ADD 2009/05/12 ------------------------------->>>>>
            Infragistics.Win.UltraWinTabControl.UltraTabControl uTabControl = null;

            if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[0])
            {
                uTabControl = this.Sub_UTabControl;
            }
            else if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[1])
            {
                uTabControl = this.SubExp_UTabControl;
            }
            else if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[2])
            {
                uTabControl = this.SubImp_UTabControl;
            }
            // --- ADD 2009/05/12 ------------------------------<<<<<

            //if (this.Sub_UTabControl.ActiveTab == null) return;  // DEL 2009/05/12
            if (uTabControl.ActiveTab == null) return;  // ADD 2009/05/12

            //string key = this.Sub_UTabControl.ActiveTab.Key;  // DEL 2009/05/12
            string key = uTabControl.ActiveTab.Key;  // ADD 2009/05/12

            // �^�u�\���ύX
            this.TabVisibleChange(key, false);

            // �E�B���h�E�X�e�[�g�{�^���c�[���\�z����
            this.CreateWindowStateButtonTools();


            //if (this.Sub_UTabControl.Tabs.Count == 0)  // DEL 2009/05/12
            if (uTabControl.Tabs.Count == 0)  // ADD 2009/05/12
            {
                this.ToolBarSetting(null);
            }
            else
            {
                //this.ToolBarSetting(this.Sub_UTabControl.ActiveTab);  // DEL 2009/05/12
                this.ToolBarSetting(uTabControl.ActiveTab);  // ADD 2009/05/12
            }
        }


        /// <summary>
        /// ���C���^�O�I����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_UTabControl_Click(object sender, System.EventArgs e)
        {
            this.Set_PreviewMode(true);
        }
        #endregion

        // --- ADD 2009/05/12 ------------------------------->>>>>
        # region ����߰ĂƲ��߰Ă̊֘A����
        // ===================================================================================== //
        // �������\�b�h
        // ===================================================================================== //
        #region private method
        /// <summary>
        /// ����߰ĂƲ��߰ăc���[�r���[�\��
        /// </summary>
        /// <remarks>
        /// <br>Note        : ����߰ĂƲ��߰ăc���[�r���[�\�����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.05.12</br>
        /// </remarks>
        private void ConstructionExpInpTreeNode()
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
        /// �c���[�̍\�z����
        /// </summary>
        /// <param name="tree">�c���[</param>
        /// <remarks>
        /// <br>Note        : �c���[�̍\�z�������s���B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.05.12</br>
        /// <br>Update Note : 2011/12/20 �����x</br>
        /// <br>�Ǘ��ԍ�    : 10707327-00 2012/01/25�z�M��</br>
        /// <br>              Redmine#27268�@���[�t���[���^�N���i�r�Q�[�^�[�̃��_�`�F�b�N�̏C��</br>
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
                                    utn3.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.Standard;//ADD liuyj 2011/12/20 Redmine#27268
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
                                    string strPara = PMKHN08500UA._parameter[i];
                                    int intPara = TStrConv.StrToIntDef(PMKHN08500UA._parameter[i], -1);

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
                                    utn3.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.Standard;//ADD liuyj 2011/12/20 Redmine#27268
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
                                            string strPara = PMKHN08500UA._parameter[i];
                                            int intPara = TStrConv.StrToIntDef(PMKHN08500UA._parameter[i], -1);

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

                                    // 2009/10/01 Add >>>
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
                                    // 2009/10/01 Add <<<

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

        // 2010/03/31 Add >>>
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
        // 2010/03/31 Add <<<

        # region ���@��ʃR���g���[���N���X�쐬����
        /// <summary>
        /// ��ʃR���g���[���N���X�쐬����
        /// </summary>
        /// <returns> </returns>
        /// <remarks>
        /// <br>Note        : �e�������ʂ̃A�Z���u�������쐬���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.05.12</br>
        /// </remarks>
        private int CreateExpInpFormControlInfo()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // ����߰�
            status = this.CreateFormControlInfo2(this.StartNavigatorEXPTree, ref this._expFormControlInfoTable);
            // ���߰�
            status = this.CreateFormControlInfo2(this.StartNavigatorINPTree, ref this._impFormControlInfoTable);
            return status;
        }

        /// <summary>
        /// ��ʃR���g���[���N���X�쐬����
        /// </summary>
        /// <param name="tree">�c���[</param>
        /// <param name="hashTable">�e�[�u��</param>
        /// <returns> </returns>
        /// <remarks>
        /// <br>Note        : �e�������ʂ̃A�Z���u�������쐬���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.05.12</br>
        /// <br>Update Note : 2011/12/20 �����x</br>
        /// <br>�Ǘ��ԍ�    : 10707327-00 2012/01/25�z�M��</br>
        /// <br>              Redmine#27268�@���[�t���[���^�N���i�r�Q�[�^�[�̃��_�`�F�b�N�̏C��</br>
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
                                utn3.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.Standard;//ADD liuyj 2011/12/20 Redmine#27268
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

        #region ���@�e���[�����t�h�N���X�N������
        /// <summary>
        /// �eUI��ʋN������
        /// </summary>
        /// <param name="key">�ΏۃL�[���</param>
        /// <remarks>
        /// <br>Note        : �����̃L�[�������ɁA�^�u���A�N�e�B�u�����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.05.12</br>
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
        /// <br>Note        : �^�u�t�H�[���𐶐����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.05.12</br>
        /// </remarks>
        private void TabCreate2(string key)
        {
            FormControlInfo info = null;
            if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[1])
            {
                info = (FormControlInfo)this._expFormControlInfoTable[key];
            }
            else if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[2])
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
        /// <br>Note        : �����̃L�[�������ɁA�^�u���A�N�e�B�u�����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.05.12</br>
        /// </remarks>
        private void TabActive2(string key, ref Form form)
        {
            if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[1])
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
            else if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[2])
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
        /// <br>Note        : MDI�q��ʂ𐶐�����</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.05.12</br>
        /// </remarks>
        private Form CreateTabForm2(FormControlInfo info)
        {
            Form form = null;

            if (info.Key.Substring(info.Key.Length - 7).Equals("PREVIEW"))
            {
                form = new Broadleaf.Windows.Forms.PMKHN08500UB();
            }
            else
            {
                form = (System.Windows.Forms.Form)this.LoadAssemblyFrom(info.AssemblyID, info.ClassID, typeof(System.Windows.Forms.Form));
            }

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
                if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[1])
                {
                    // �c�[���o�[�{�^������C�x���g 
                    if (form is IExportConditionInpType)
                    {
                        ((IExportConditionInpType)form).ParentToolbarSettingEvent += new ParentToolbarSettingEventHandler(this.ParentToolbarSettingEvent);
                    }

                    this.SubExp_UTabControl.Controls.Add(dataviewTabPageControl);
                    this.SubExp_UTabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] { dataviewTab });
                    this.SubExp_UTabControl.SelectedTab = dataviewTab;
                }
                else if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[2])
                {
                    // �c�[���o�[�{�^������C�x���g 
                    if (form is IImportConditionInpType)
                    {
                        ((IImportConditionInpType)form).ParentToolbarSettingEvent += new ParentToolbarSettingEventHandler(this.ParentToolbarSettingEvent);
                    }

                    this.SubImp_UTabControl.Controls.Add(dataviewTabPageControl);
                    this.SubImp_UTabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] { dataviewTab });
                    this.SubImp_UTabControl.SelectedTab = dataviewTab;
                }

                // �t�H�[���v���p�e�B�ύX
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                dataviewTabPageControl.Controls.Add(form);

                if (form is IExportConditionInpType)
                {
                    ((IExportConditionInpType)form).Show(info.Param);
                }
                else if (form is IExportConditionInpType)
                {
                    ((IImportConditionInpType)form).Show(info.Param);
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

        ///// <summary>
        ///// ÷��̧�ٖ��`�@�b�N����
        ///// </summary>
        ///// <returns>status</returns>
        ///// <remarks>
        ///// <br>Note	   : ÷��̧�ٖ��`�@�b�N�������s���B(���̓`�F�b�N�Ȃ�)</br>
        ///// <br>Programmer : �����</br>
        ///// <br>Date       : 2009.05.12</br>
        ///// </remarks>
        //private bool CheckTextFileName(string fileName)
        //{
        //    bool bStatus = true;
        //    if (fileName == string.Empty)
        //    {
        //        string msg = "�e�L�X�g�t�@�C�����͓��͂��Ă��������B";
        //        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, msg, 0, MessageBoxButtons.OK);
        //        bStatus = false;
        //        return bStatus;
        //    }

        //    if (!Directory.Exists(System.IO.Path.GetDirectoryName(fileName)))
        //    {
        //        string msg = "CSV�t�@�C���p�X���s���ł��B";
        //        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, msg, 0, MessageBoxButtons.OK);
        //        bStatus = false;
        //        return bStatus;
        //    }

        //    return bStatus;
        //}

        /// <summary>
        /// ÷��̧�ٖ��`�F�b�N����
        /// </summary>
        /// <param name="fileName">�t�@�C�����O</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : ÷��̧�ٖ��`�F�b�N�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private bool CheckInputFileName(string fileName, out string errMsg)
        {
            errMsg = string.Empty;
            bool bStatus = true;
            if (fileName == string.Empty)
            {
                errMsg = "�e�L�X�g�t�@�C��������͂��Ă��������B";
                bStatus = false;
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
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private bool CheckInputFileExists(string fileName, out string errMsg)
        {
            errMsg = string.Empty;
            bool bStatus = true;
            if (!File.Exists(fileName))
            {
                errMsg = "CSV�t�@�C���p�X���s���ł��B";
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
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.12</br>
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
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.12</br>
        /// <br>Update Note: 2011/07/28  923 ���X��</br>
        /// </br>            : �i�Ԃ�i���� "(����ٺ�ð���)���܂܂��ƁA���߰Ď��ɃG���[�ɂȂ�ׂ̑Ή�</br>
        /// <br>Update Note: 2011/08/15  �A��923 ���X��</br>
        /// </br>            : �i�Ԃ�i���� "(����ٺ�ð���)���܂܂��ƁA���߰Ď��ɃG���[�ɂȂ�ׂ̑Ή�</br>
        /// </remarks>
        private List<String[]> GetCsvData(String fileName, out string errMsg)
        {
            errMsg = string.Empty;
            List<string[]> csvDataList = new List<string[]>();
            //TextFieldParser parser = new TextFieldParser(fileName, System.Text.Encoding.GetEncoding("Shift_JIS"));     //DEL by Liangsd   2011/07/28
            TextFieldParser parser = new TextFieldParser(fileName, System.Text.Encoding.GetEncoding("Shift_JIS"));       //ADD by Liangsd     2011/08/15
            //StreamReader smRead = new StreamReader(fileName, System.Text.Encoding.GetEncoding("Shift_JIS"));        //ADD by Liangsd   2011/07/28               //DEL by Liangsd     2011/08/15
            // int count = 0;                                                                            //ADD by Liangsd   2011/07/28                                                                                                              //DEL by Liangsd     2011/08/15
            try
            {
                //DEL by Liangsd   2011/07/28----------------->>>>>>>>>>
                //using (parser)
                //{
                //    parser.TextFieldType = FieldType.Delimited;
                //    parser.SetDelimiters(","); // ��؂蕶���̓R���}
                //    while (!parser.EndOfData)
                //    {
                //        string[] row = parser.ReadFields(); // 1�s�ǂݍ���
                //        csvDataList.Add(row);
                //    }
                //}
                //DEL by Liangsd   2011/07/28-----------------<<<<<<<<<<<
                //ADD by Liangsd   2011/08/15----------------->>>>>>>>>>
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
                //ADD by Liangsd   2011/08/15-----------------<<<<<<<<<<

                //ADD by Liangsd   2011/07/28----------------->>>>>>>>>>
                //DEL by Liangsd   2011/08/15----------------->>>>>>>>>>
                //string line = string.Empty;
                //while ((line = smRead.ReadLine()) != null)
                //{
                //    count++;
                //    string[] row = line.Split(',');
                //    csvDataList.Add(row);
                //}
                //DEL by Liangsd   2011/08/15-----------------<<<<<<<<<<
                //ADD by Liangsd   2011/07/28-----------------<<<<<<<<<<
            }
            catch
            {
                //errMsg = "�e�L�X�g�t�@�C���̓ǂݍ��݂Ɏ��s���܂����B" + parser.ErrorLineNumber + "�s�ڂ̓��e���m�F���Ă��������B";   //DEL by Liangsd   2011/07/28
                errMsg = "�e�L�X�g�t�@�C���̓ǂݍ��݂Ɏ��s���܂����B" + parser.ErrorLineNumber + "�s�ڂ̓��e���m�F���Ă��������B";      //ADD by Liangsd     2011/08/15
                //errMsg = "�e�L�X�g�t�@�C���̓ǂݍ��݂Ɏ��s���܂����B" + count + "�s�ڂ̓��e���m�F���Ă��������B";                                       //ADD by Liangsd   2011/07/28     //DEL by Liangsd     2011/08/15
            }
            //ADD by Liangsd   2011/07/28----------------->>>>>>>>>>
            //DEL by Liangsd   2011/08/15----------------->>>>>>>>>>
            //finally
            //{
            //    smRead.Close();
            //}
            //DEL by Liangsd   2011/08/15-----------------<<<<<<<<<<
            //ADD by Liangsd   2011/07/28-----------------<<<<<<<<<<
            if (csvDataList.Count > 0)
            {
                // �e�L�X�g�t�@�C���̂P�s�ڂ̓^�C�g���s�Ȃ̂ŁA�捞���s��Ȃ��B
                csvDataList.RemoveAt(0);
            }
            return csvDataList;

        }

        /// <summary>
        /// CSV�o�͏���
        /// </summary>
        /// <param name="parameter">�o��Info</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : CSV�o�͏������s���B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private int DoOutPut(ref object parameter)
        {
            int status = 0;

            SFCMN06002C printInfo = parameter as SFCMN06002C;

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return -1;
            }
            CustomTextProviderInfo customTextProviderInfo = CustomTextProviderInfo.GetDefaultInfo();
            CustomTextWriter customTextWriter = new CustomTextWriter();
            // �o�̓p�X�Ɩ��O
            customTextProviderInfo.OutPutFileName = printInfo.outPutFilePathName;

            // �㏑���^�ǉ��t���O���Z�b�g(true:�ǉ�����Afalse:�㏑������)
            customTextProviderInfo.AppendMode = printInfo.overWriteFlag;
            // �X�L�[�}�擾
            customTextProviderInfo.SchemaFileName = System.IO.Path.Combine(ConstantManagement_ClientDirectory.TextOutSchema, printInfo.prpid);
            // �f�[�^�\�[�X��ݒ�
            DataSet dsOutData = new DataSet();
            DataView dv = this.BindDataSet.Tables[this._tableName].DefaultView;
            dsOutData.Tables.Add(dv.ToTable());

            try
            {
                status = customTextWriter.WriteText(dsOutData, customTextProviderInfo.SchemaFileName, customTextProviderInfo.OutPutFileName, customTextProviderInfo);
            }
            catch
            {
                status = -1;
            }
            dsOutData.Tables.Clear();

            string resultMessage = "";
            switch (status)
            {
                case 0:    // ��������
                    resultMessage = "CSV�f�[�^���쐬���܂����B";
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, CT_PGID, resultMessage, status, MessageBoxButtons.OK);
                    break;
                case 4:    // �Ώۃf�[�^�Ȃ�
                    resultMessage = "CSV�ւ̏o�̓f�[�^������܂���B";
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, CT_PGID, resultMessage, status, MessageBoxButtons.OK);
                    break;
                case -9:    // �o�͑ΏۊO�̃f�[�^���w�肳�ꂽ
                    resultMessage = "�o�͑ΏۊO�̃f�[�^���w�肳��܂����B";
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, CT_PGID, resultMessage, status, MessageBoxButtons.OK);
                    break;
                default:    // ���̑��G���[
                    resultMessage = "�e�L�X�g�t�@�C���̏������݂Ɏ��s���܂����B";
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOP, CT_PGID, resultMessage, 9, MessageBoxButtons.OK);
                    break;
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
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.05.12</br>
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
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.05.12</br>
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
        /// <br>Note        : �N���i�r�Q�[�^�[�̃_�u���N���b�N�C�x���g�ł��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.05.12</br>
        /// <br>Update Note : 2021/01/04 杍^</br>
        /// <br>�Ǘ��ԍ�    : 11670323-00</br>
        /// <br>              PMKOBETSU-4109�@�v���O�����N�����O�𑀍엚�����O�ɏo�͂���ǉ��Ή�</br>
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

                // --- ADD 杍^ 2021/01/04 PMKOBETSU-4109�̑Ή� ------>>>>
                try
                {
                    try
                    {
                        // �N���C�A���g���O�o�͕��i������
                        if (clientLogTextOut == null)
                        {
                            clientLogTextOut = new ClientLogTextOut();
                        }
                    }
                    catch
                    {
                        // �㑱�����ɉe�����Ȃ��悤��O�L���b�`
                    }

                    try
                    {
                        // ���엚�����O�o�͕��i������
                        if (operationHistoryLog == null)
                        {
                            operationHistoryLog = new OperationHistoryLog();
                        }
                    }
                    catch (Exception ex)
                    {
                        // �G���[�����O�o��
                        try
                        {
                            if (clientLogTextOut != null)
                            {
                                clientLogTextOut.Output(ex.Source, ErrMessageInit, (int)ConstantManagement.MethodResult.ctFNC_ERROR, ex);
                            }
                        }
                        catch
                        {
                            // �㑱�����ɉe�����Ȃ��悤��O�L���b�`
                        }
                    }

                    // ���O�o�͂��s��
                    string dateMessage = string.Format(DateMessage, CT_PGNAME, node.Parent.Text, node.Text, info.AssemblyID);
                    if (operationHistoryLog != null)
                    {
                        // ���엚�����O�o��
                        operationHistoryLog.WriteOperationLog(this, DateTime.Now, (LogDataKind)MenuLog,
                        CT_PGID, CT_PGNAME, MethodNameExp, OperationCode, (int)ConstantManagement.MethodResult.ctFNC_NORMAL, dateMessage, string.Empty);
                    }
                }
                catch (Exception ex)
                {
                    // �G���[�����O�o��
                    try
                    {
                        if (clientLogTextOut != null)
                        {
                            clientLogTextOut.Output(ex.Source, MethodNameExp + ErrMessage, (int)ConstantManagement.MethodResult.ctFNC_ERROR, ex);
                        }
                    }
                    catch
                    {
                        // �㑱�����ɉe�����Ȃ��悤��O�L���b�`
                    }
                }
                // --- ADD 杍^ 2021/01/04 PMKOBETSU-4109�̑Ή� ------<<<<
            }
        }


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

                // 2010/03/31 Add >>>
                SetUpButtonToolEnable(node.Key.ToString());
                // 2010/03/31 Add <<<

                doubleClickedNode.Override.NodeAppearance.ForeColor = Color.Red;

                BeginControllingByOperationAuthority(info.AssemblyID);

                // --- ADD 杍^ 2021/01/04 PMKOBETSU-4109�̑Ή� ------>>>>
                try
                {
                    try
                    {
                        // �N���C�A���g���O�o�͕��i������
                        if (clientLogTextOut == null)
                        {
                            clientLogTextOut = new ClientLogTextOut();
                        }
                    }
                    catch
                    {
                        // �㑱�����ɉe�����Ȃ��悤��O�L���b�`
                    }

                    try
                    {
                        // ���엚�����O�o�͕��i������
                        if (operationHistoryLog == null)
                        {
                            operationHistoryLog = new OperationHistoryLog();
                        }
                    }
                    catch (Exception ex)
                    {
                        // �G���[�����O�o��
                        try
                        {
                            if (clientLogTextOut != null)
                            {
                                clientLogTextOut.Output(ex.Source, ErrMessageInit, (int)ConstantManagement.MethodResult.ctFNC_ERROR, ex);
                            }
                        }
                        catch
                        {
                            // �㑱�����ɉe�����Ȃ��悤��O�L���b�`
                        }
                    }

                    // ���O�o�͂��s��
                    string dateMessage = string.Format(DateMessage, CT_PGNAME, node.Parent.Text, node.Text, info.AssemblyID);
                    if (operationHistoryLog != null)
                    {
                        // ���엚�����O�o��
                        operationHistoryLog.WriteOperationLog(this, DateTime.Now, (LogDataKind)MenuLog,
                        CT_PGID, CT_PGNAME, MethodNameInp, OperationCode, (int)ConstantManagement.MethodResult.ctFNC_NORMAL, dateMessage, string.Empty);
                    }
                }
                catch (Exception ex)
                {
                    // �G���[�����O�o��
                    try
                    {
                        if (clientLogTextOut != null)
                        {
                            clientLogTextOut.Output(ex.Source, MethodNameInp + ErrMessage, (int)ConstantManagement.MethodResult.ctFNC_ERROR, ex);
                        }
                    }
                    catch
                    {
                        // �㑱�����ɉe�����Ȃ��悤��O�L���b�`
                    }
                }
                // --- ADD 杍^ 2021/01/04 PMKOBETSU-4109�̑Ή� ------<<<<
            }
        }

        /// <summary>
        /// �^�u�I���㏈��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note        : �^�u�I����ɔ�������C�x���g�ł��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.05.12</br>
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
        /// <br>Note        : �^�u�I����ɔ�������C�x���g�ł��B</br>
        /// <br>Programmer  : ���w�q</br>
        /// <br>Date        : 2009.05.12</br>
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

            SetUpButtonToolEnable(target.ToString());   // 2010/03/31 Add
        }

        /// <summary>
        /// �^�u�I���㏈��(Main_UTabControl)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note        : �^�u�I����ɔ�������C�x���g�ł��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.05.12</br>
        /// </remarks>
        private void Main_UTabControl_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            Infragistics.Win.UltraWinTabControl.UltraTabControl uTabControl = null;
            System.Windows.Forms.Form frm = null;

            // ���
            if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[0])
            {
                uTabControl = this.Sub_UTabControl;

                if (uTabControl.ActiveTab != null)
                {
                    FormControlInfo formInfo = (FormControlInfo)this._formControlInfoTable[uTabControl.SelectedTab.Key];
                    ToolBarSetting(formInfo.Form);
                }
                else
                {
                    ToolBarSetting(frm);
                }
            }
            // ����߰�
            else if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[1])
            {
                uTabControl = this.SubExp_UTabControl;

                if (uTabControl.ActiveTab != null)
                {
                    FormControlInfo formInfo = (FormControlInfo)this._expFormControlInfoTable[uTabControl.SelectedTab.Key];
                    ToolBarSetting(formInfo.Form);
                }
                else
                {
                    ToolBarSetting(frm);
                }
            }
            // ���߰�
            else if (this.Main_UTabControl.SelectedTab == this.Main_UTabControl.Tabs[2])
            {
                uTabControl = this.SubImp_UTabControl;

                if (uTabControl.ActiveTab != null)
                {
                    FormControlInfo formInfo = (FormControlInfo)this._impFormControlInfoTable[uTabControl.SelectedTab.Key];
                    ToolBarSetting(formInfo.Form);
                    SetUpButtonToolEnable(uTabControl.ActiveTab.Key.ToString());    // 2010/03/31 Add
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
        # endregion
        // --- ADD 2009/05/12 ------------------------------<<<<<
    }
}

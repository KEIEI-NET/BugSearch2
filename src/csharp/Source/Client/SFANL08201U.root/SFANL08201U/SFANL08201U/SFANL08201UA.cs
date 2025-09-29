using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Controller;  // for debug
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Resources;

using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���R���[����t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R���[����t�H�[���N���X�ł��B</br>
    /// <br>Programmer : 22011 Kashihara</br>
    /// <br>Date       : 2006.01.19</br>
    /// <br>Update Note: 2008.03.18</br>
    /// <br>           : 22011 ���� ���l �������[�̎����t���Œ��͓��͂��Ȃ��ƒ��o���Ȃ��悤�C��</br>
    /// <br>           : ������t�̓��������͖������ōs�����A�s���Ă͂܂�����ٰ�߂��o�Ă�����ʂł͂���</br>
    /// <br>           : ���W�b�N�̒ǉ����K�v�B(��{SL�m�F�ς�)</br>
    /// </remarks>
    public class SFANL08201UA : GridFormBase, IFreeSheetMainFrame
    {
        # region Private Members (Component)
        private System.Windows.Forms.Panel Centering_Panel;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private System.Windows.Forms.Panel SFANL08201U_Fill_Panel;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private UltraLabel GridTitleSub_ultraLabel;
        private UltraButton Print_Button;
        private UltraLabel ultraLabel1;
        private Panel Panel_Fill_Panel;
        private Panel GroupPanel;
        private Panel ExtractPanel;
        private Panel PrintBtnPanel;
        private Panel DetailPanel;
        private UltraButton OrderCng_Button;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar SelectExplorerBar;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl2;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl1;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet AddUpCd_UOptionSet;
        private AutoHideControl _SFANL08201UAAutoHideControl;
        private UltraDockManager Main_DockManager;
        private UnpinnedTabArea _SFANL08201UAUnpinnedTabAreaTop;
        private UnpinnedTabArea _SFANL08201UAUnpinnedTabAreaBottom;
        private UnpinnedTabArea _SFANL08201UAUnpinnedTabAreaLeft;
        private UnpinnedTabArea _SFANL08201UAUnpinnedTabAreaRight;
        private WindowDockingArea windowDockingArea1;
        private DockableWindow dockableWindow1;
        private Infragistics.Win.UltraWinTree.UltraTree Section_UTree;
        private Panel GroupPanel_Fill_Panel;
        private UltraToolbarsDockArea _GroupPanel_Toolbars_Dock_Area_Left;
        private UltraToolbarsManager GroupToolbarsManager;
        private UltraToolbarsDockArea _GroupPanel_Toolbars_Dock_Area_Right;
        private UltraToolbarsDockArea _GroupPanel_Toolbars_Dock_Area_Top;
        private UltraToolbarsDockArea _GroupPanel_Toolbars_Dock_Area_Bottom;
        private Panel DetailPanel_Fill_Panel;
        private UltraToolbarsDockArea _DetailPanel_Toolbars_Dock_Area_Left;
        private UltraToolbarsManager DetailToolbarsManager;
        private UltraToolbarsDockArea _DetailPanel_Toolbars_Dock_Area_Right;
        private UltraToolbarsDockArea _DetailPanel_Toolbars_Dock_Area_Top;
        private UltraToolbarsDockArea _DetailPanel_Toolbars_Dock_Area_Bottom;
        private UltraGrid FreePprGr_Grid;
        private UltraGrid FreePprPrt_Grid;
        private Panel Splitter2_panel;
        private Panel Splitter1_panel;
        private Panel Sqlitter1_panel1;
        private Splitter splitter1;
        private Panel Splitter2_panel2;
        private Splitter splitter2;
        private System.ComponentModel.IContainer components;
        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region constructor
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public SFANL08201UA()
        {
            InitializeComponent();
            //��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            //���O�C�����_�擾
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            //�ۑ�Dlg�������̃f���Q�[�g�ݒ�
            _maintenanceDlg.SaveNewGroup += RegistFreePprGr;           //�f�[�^�Z�b�g�ւ̒ǉ�����(�O���[�v)
            _maintenanceDlg.SaveNewFrePpr += RegistFreeShetGrTr;       //�f�[�^�Z�b�g�ւ̒ǉ�����(�U��)
            _maintenanceDlg.Owner = this;                             //�I�[�i�[��ݒ�

            // �ŏI����������m��
            int status = _lastPrtTimeAcs.SearchAll( out _lastTimes );
            if ( status != 0 )
            {
                _lastTimes = new List<LastPrtTime>();
            }
            //�����f�[�^�Z�b�g�ݒ�
            CreateInitialDataSet();
            //���_�����L���b�V��
            GetSecInfoSetCash();


            /*  ���_�X���C�_�[���\�z
             *  ���͓������[�����Ȃ��̂Ń^�C�~���O�͂���ŗǂ����󎚍��ڃO���[�v����������
             *  ���R���[�O���[�v���Ƃ̊Ǘ����K�v�ɂȂ��Ă���B���̃^�C�~���O�ŉ��ǁB
             */
            InitSettingSectionTree( 1 );
            InitialSettingSectionKind( 1 );

        }
        #endregion

        // ===================================================================================== //
        // �j��
        // ===================================================================================== //
        #region Dispose
        /// <summary>
        /// �j��
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing )
            {
                _lastPrtTimeAcs.Write( _lastTimes );

                if ( components != null )
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("RowADD");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("RowDelete");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("RowADD");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("RowDelete");
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("RowADD");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("RowDelete");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("RowADD");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("RowDelete");
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("cc6aa7d9-0768-4432-a5c4-d7db122dc0b2"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("c6d77efb-ad85-43d9-bca9-cb2c80cf2b8b"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("cc6aa7d9-0768-4432-a5c4-d7db122dc0b2"), -1);
            this.ultraExplorerBarContainerControl1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.AddUpCd_UOptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraExplorerBarContainerControl2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.Section_UTree = new Infragistics.Win.UltraWinTree.UltraTree();
            this.SelectExplorerBar = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.SFANL08201U_Fill_Panel = new System.Windows.Forms.Panel();
            this.Centering_Panel = new System.Windows.Forms.Panel();
            this.Splitter1_panel = new System.Windows.Forms.Panel();
            this.Sqlitter1_panel1 = new System.Windows.Forms.Panel();
            this.DetailPanel = new System.Windows.Forms.Panel();
            this.DetailPanel_Fill_Panel = new System.Windows.Forms.Panel();
            this.FreePprPrt_Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this._DetailPanel_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.DetailToolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._DetailPanel_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._DetailPanel_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._DetailPanel_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.GridTitleSub_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.Splitter2_panel = new System.Windows.Forms.Panel();
            this.Splitter2_panel2 = new System.Windows.Forms.Panel();
            this.ExtractPanel = new System.Windows.Forms.Panel();
            this.PrintBtnPanel = new System.Windows.Forms.Panel();
            this.OrderCng_Button = new Infragistics.Win.Misc.UltraButton();
            this.Print_Button = new Infragistics.Win.Misc.UltraButton();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.Panel_Fill_Panel = new System.Windows.Forms.Panel();
            this.GroupPanel = new System.Windows.Forms.Panel();
            this.GroupPanel_Fill_Panel = new System.Windows.Forms.Panel();
            this.FreePprGr_Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this._GroupPanel_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.GroupToolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._GroupPanel_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._GroupPanel_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._GroupPanel_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.Main_DockManager = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._SFANL08201UAUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._SFANL08201UAUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._SFANL08201UAUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._SFANL08201UAUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._SFANL08201UAAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.dockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.windowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.ultraExplorerBarContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpCd_UOptionSet)).BeginInit();
            this.ultraExplorerBarContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Section_UTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectExplorerBar)).BeginInit();
            this.SelectExplorerBar.SuspendLayout();
            this.SFANL08201U_Fill_Panel.SuspendLayout();
            this.Centering_Panel.SuspendLayout();
            this.Splitter1_panel.SuspendLayout();
            this.Sqlitter1_panel1.SuspendLayout();
            this.DetailPanel.SuspendLayout();
            this.DetailPanel_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FreePprPrt_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailToolbarsManager)).BeginInit();
            this.Splitter2_panel.SuspendLayout();
            this.Splitter2_panel2.SuspendLayout();
            this.PrintBtnPanel.SuspendLayout();
            this.Panel_Fill_Panel.SuspendLayout();
            this.GroupPanel.SuspendLayout();
            this.GroupPanel_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FreePprGr_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupToolbarsManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).BeginInit();
            this._SFANL08201UAAutoHideControl.SuspendLayout();
            this.dockableWindow1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraExplorerBarContainerControl1
            // 
            this.ultraExplorerBarContainerControl1.Controls.Add(this.AddUpCd_UOptionSet);
            this.ultraExplorerBarContainerControl1.Location = new System.Drawing.Point(28, 49);
            this.ultraExplorerBarContainerControl1.Name = "ultraExplorerBarContainerControl1";
            this.ultraExplorerBarContainerControl1.Size = new System.Drawing.Size(177, 44);
            this.ultraExplorerBarContainerControl1.TabIndex = 0;
            // 
            // AddUpCd_UOptionSet
            // 
            this.AddUpCd_UOptionSet.BackColor = System.Drawing.Color.Transparent;
            this.AddUpCd_UOptionSet.BackColorInternal = System.Drawing.Color.Transparent;
            this.AddUpCd_UOptionSet.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.AddUpCd_UOptionSet.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.AddUpCd_UOptionSet.Location = new System.Drawing.Point(2, 4);
            this.AddUpCd_UOptionSet.Name = "AddUpCd_UOptionSet";
            this.AddUpCd_UOptionSet.Size = new System.Drawing.Size(224, 35);
            this.AddUpCd_UOptionSet.TabIndex = 0;
            this.AddUpCd_UOptionSet.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.AddUpCd_UOptionSet.ValueChanged += new System.EventHandler(this.AddUpCd_UOptionSet_ValueChanged);
            // 
            // ultraExplorerBarContainerControl2
            // 
            this.ultraExplorerBarContainerControl2.Controls.Add(this.Section_UTree);
            this.ultraExplorerBarContainerControl2.Location = new System.Drawing.Point(28, 146);
            this.ultraExplorerBarContainerControl2.Name = "ultraExplorerBarContainerControl2";
            this.ultraExplorerBarContainerControl2.Size = new System.Drawing.Size(177, 343);
            this.ultraExplorerBarContainerControl2.TabIndex = 1;
            // 
            // Section_UTree
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.Section_UTree.Appearance = appearance2;
            this.Section_UTree.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.Section_UTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Section_UTree.Location = new System.Drawing.Point(0, 0);
            this.Section_UTree.Name = "Section_UTree";
            this.Section_UTree.ShowLines = false;
            this.Section_UTree.Size = new System.Drawing.Size(177, 343);
            this.Section_UTree.TabIndex = 0;
            this.Section_UTree.AfterCheck += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.Section_UTree_AfterCheck);
            // 
            // SelectExplorerBar
            // 
            this.SelectExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl2);
            this.SelectExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl1);
            this.SelectExplorerBar.Dock = System.Windows.Forms.DockStyle.Fill;
            ultraExplorerBarGroup1.Container = this.ultraExplorerBarContainerControl1;
            ultraExplorerBarGroup1.Key = "AddUpCdList";
            ultraExplorerBarGroup1.Settings.ContainerHeight = 44;
            ultraExplorerBarGroup1.Settings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            ultraExplorerBarGroup1.Text = "�v�㋒�_��I�����܂�";
            ultraExplorerBarGroup1.Visible = false;
            ultraExplorerBarGroup2.Container = this.ultraExplorerBarContainerControl2;
            ultraExplorerBarGroup2.Key = "SectionList";
            ultraExplorerBarGroup2.Settings.ContainerHeight = 343;
            ultraExplorerBarGroup2.Settings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            ultraExplorerBarGroup2.Text = "�o�͑Ώۋ��_��I�����܂�";
            ultraExplorerBarGroup2.Visible = false;
            this.SelectExplorerBar.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1,
            ultraExplorerBarGroup2});
            this.SelectExplorerBar.GroupSpacing = 5;
            this.SelectExplorerBar.Location = new System.Drawing.Point(0, 29);
            this.SelectExplorerBar.Name = "SelectExplorerBar";
            this.SelectExplorerBar.ShowDefaultContextMenu = false;
            this.SelectExplorerBar.Size = new System.Drawing.Size(226, 741);
            this.SelectExplorerBar.TabIndex = 6;
            this.SelectExplorerBar.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.XPExplorerBar;
            // 
            // SFANL08201U_Fill_Panel
            // 
            this.SFANL08201U_Fill_Panel.Controls.Add(this.Centering_Panel);
            this.SFANL08201U_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SFANL08201U_Fill_Panel.Location = new System.Drawing.Point(22, 0);
            this.SFANL08201U_Fill_Panel.Name = "SFANL08201U_Fill_Panel";
            this.SFANL08201U_Fill_Panel.Size = new System.Drawing.Size(902, 770);
            this.SFANL08201U_Fill_Panel.TabIndex = 0;
            // 
            // Centering_Panel
            // 
            this.Centering_Panel.Controls.Add(this.Splitter1_panel);
            this.Centering_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Centering_Panel.Location = new System.Drawing.Point(0, 0);
            this.Centering_Panel.Name = "Centering_Panel";
            this.Centering_Panel.Size = new System.Drawing.Size(902, 770);
            this.Centering_Panel.TabIndex = 0;
            // 
            // Splitter1_panel
            // 
            this.Splitter1_panel.Controls.Add(this.Sqlitter1_panel1);
            this.Splitter1_panel.Controls.Add(this.splitter1);
            this.Splitter1_panel.Controls.Add(this.Splitter2_panel);
            this.Splitter1_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Splitter1_panel.Location = new System.Drawing.Point(0, 0);
            this.Splitter1_panel.Name = "Splitter1_panel";
            this.Splitter1_panel.Size = new System.Drawing.Size(902, 770);
            this.Splitter1_panel.TabIndex = 7;
            // 
            // Sqlitter1_panel1
            // 
            this.Sqlitter1_panel1.Controls.Add(this.DetailPanel);
            this.Sqlitter1_panel1.Controls.Add(this.GridTitleSub_ultraLabel);
            this.Sqlitter1_panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Sqlitter1_panel1.Location = new System.Drawing.Point(292, 0);
            this.Sqlitter1_panel1.Name = "Sqlitter1_panel1";
            this.Sqlitter1_panel1.Size = new System.Drawing.Size(610, 770);
            this.Sqlitter1_panel1.TabIndex = 8;
            // 
            // DetailPanel
            // 
            this.DetailPanel.Controls.Add(this.DetailPanel_Fill_Panel);
            this.DetailPanel.Controls.Add(this._DetailPanel_Toolbars_Dock_Area_Left);
            this.DetailPanel.Controls.Add(this._DetailPanel_Toolbars_Dock_Area_Right);
            this.DetailPanel.Controls.Add(this._DetailPanel_Toolbars_Dock_Area_Top);
            this.DetailPanel.Controls.Add(this._DetailPanel_Toolbars_Dock_Area_Bottom);
            this.DetailPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailPanel.Location = new System.Drawing.Point(0, 26);
            this.DetailPanel.Name = "DetailPanel";
            this.DetailPanel.Size = new System.Drawing.Size(610, 744);
            this.DetailPanel.TabIndex = 0;
            // 
            // DetailPanel_Fill_Panel
            // 
            this.DetailPanel_Fill_Panel.Controls.Add(this.FreePprPrt_Grid);
            this.DetailPanel_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.DetailPanel_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailPanel_Fill_Panel.Location = new System.Drawing.Point(0, 26);
            this.DetailPanel_Fill_Panel.Name = "DetailPanel_Fill_Panel";
            this.DetailPanel_Fill_Panel.Size = new System.Drawing.Size(610, 718);
            this.DetailPanel_Fill_Panel.TabIndex = 0;
            // 
            // FreePprPrt_Grid
            // 
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.FreePprPrt_Grid.DisplayLayout.Appearance = appearance3;
            this.FreePprPrt_Grid.DisplayLayout.InterBandSpacing = 10;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.ForeColor = System.Drawing.Color.Black;
            this.FreePprPrt_Grid.DisplayLayout.Override.ActiveCellAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.ForeColor = System.Drawing.Color.Black;
            this.FreePprPrt_Grid.DisplayLayout.Override.ActiveRowAppearance = appearance5;
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            this.FreePprPrt_Grid.DisplayLayout.Override.CellAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance7.ForeColor = System.Drawing.Color.White;
            appearance7.TextHAlignAsString = "Left";
            appearance7.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.FreePprPrt_Grid.DisplayLayout.Override.HeaderAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.Lavender;
            this.FreePprPrt_Grid.DisplayLayout.Override.RowAlternateAppearance = appearance8;
            appearance9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FreePprPrt_Grid.DisplayLayout.Override.RowAppearance = appearance9;
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance10.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance10.ForeColor = System.Drawing.Color.White;
            this.FreePprPrt_Grid.DisplayLayout.Override.RowSelectorAppearance = appearance10;
            this.FreePprPrt_Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.FreePprPrt_Grid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.FreePprPrt_Grid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.FreePprPrt_Grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.FreePprPrt_Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.FreePprPrt_Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.FreePprPrt_Grid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.FreePprPrt_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FreePprPrt_Grid.Location = new System.Drawing.Point(0, 0);
            this.FreePprPrt_Grid.Name = "FreePprPrt_Grid";
            this.FreePprPrt_Grid.Size = new System.Drawing.Size(610, 718);
            this.FreePprPrt_Grid.TabIndex = 0;
            this.FreePprPrt_Grid.InitializeRow += new Infragistics.Win.UltraWinGrid.InitializeRowEventHandler(this.FreePprPrt_Grid_InitializeRow);
            this.FreePprPrt_Grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FreePprPrt_Grid_KeyDown);
            this.FreePprPrt_Grid.AfterRowActivate += new System.EventHandler(this.FreePprPrt_Grid_AfterRowActivate);
            this.FreePprPrt_Grid.BeforeRowDeactivate += new System.ComponentModel.CancelEventHandler(this.FreePprPrt_Grid_BeforeRowDeactivate);
            this.FreePprPrt_Grid.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.FreePprPrt_Grid_DoubleClickRow);
            // 
            // _DetailPanel_Toolbars_Dock_Area_Left
            // 
            this._DetailPanel_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._DetailPanel_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._DetailPanel_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._DetailPanel_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._DetailPanel_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 26);
            this._DetailPanel_Toolbars_Dock_Area_Left.Name = "_DetailPanel_Toolbars_Dock_Area_Left";
            this._DetailPanel_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 718);
            this._DetailPanel_Toolbars_Dock_Area_Left.ToolbarsManager = this.DetailToolbarsManager;
            // 
            // DetailToolbarsManager
            // 
            this.DetailToolbarsManager.DesignerFlags = 1;
            this.DetailToolbarsManager.DockWithinContainer = this.DetailPanel;
            this.DetailToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2});
            ultraToolbar1.Text = "UltraToolbar1";
            this.DetailToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            buttonTool3.SharedProps.Caption = "�V�K�ǉ�";
            buttonTool3.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool4.SharedProps.Caption = "�s�폜";
            buttonTool4.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.DetailToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool3,
            buttonTool4});
            this.DetailToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.DetailToolbarsManager_ToolClick);
            // 
            // _DetailPanel_Toolbars_Dock_Area_Right
            // 
            this._DetailPanel_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._DetailPanel_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._DetailPanel_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._DetailPanel_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._DetailPanel_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(610, 26);
            this._DetailPanel_Toolbars_Dock_Area_Right.Name = "_DetailPanel_Toolbars_Dock_Area_Right";
            this._DetailPanel_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 718);
            this._DetailPanel_Toolbars_Dock_Area_Right.ToolbarsManager = this.DetailToolbarsManager;
            // 
            // _DetailPanel_Toolbars_Dock_Area_Top
            // 
            this._DetailPanel_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._DetailPanel_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._DetailPanel_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._DetailPanel_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._DetailPanel_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._DetailPanel_Toolbars_Dock_Area_Top.Name = "_DetailPanel_Toolbars_Dock_Area_Top";
            this._DetailPanel_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(610, 26);
            this._DetailPanel_Toolbars_Dock_Area_Top.ToolbarsManager = this.DetailToolbarsManager;
            // 
            // _DetailPanel_Toolbars_Dock_Area_Bottom
            // 
            this._DetailPanel_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._DetailPanel_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._DetailPanel_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._DetailPanel_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._DetailPanel_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 744);
            this._DetailPanel_Toolbars_Dock_Area_Bottom.Name = "_DetailPanel_Toolbars_Dock_Area_Bottom";
            this._DetailPanel_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(610, 0);
            this._DetailPanel_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.DetailToolbarsManager;
            // 
            // GridTitleSub_ultraLabel
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance11.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance11.ForeColor = System.Drawing.Color.White;
            appearance11.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance11.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance11.TextHAlignAsString = "Left";
            appearance11.TextVAlignAsString = "Middle";
            this.GridTitleSub_ultraLabel.Appearance = appearance11;
            this.GridTitleSub_ultraLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.GridTitleSub_ultraLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.GridTitleSub_ultraLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.5F, System.Drawing.FontStyle.Bold);
            this.GridTitleSub_ultraLabel.Location = new System.Drawing.Point(0, 0);
            this.GridTitleSub_ultraLabel.Name = "GridTitleSub_ultraLabel";
            this.GridTitleSub_ultraLabel.Size = new System.Drawing.Size(610, 26);
            this.GridTitleSub_ultraLabel.TabIndex = 6;
            this.GridTitleSub_ultraLabel.Text = "����Ώ�";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(289, 0);
            this.splitter1.MinExtra = 3;
            this.splitter1.MinSize = 3;
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 770);
            this.splitter1.TabIndex = 9;
            this.splitter1.TabStop = false;
            // 
            // Splitter2_panel
            // 
            this.Splitter2_panel.Controls.Add(this.Splitter2_panel2);
            this.Splitter2_panel.Controls.Add(this.splitter2);
            this.Splitter2_panel.Controls.Add(this.Panel_Fill_Panel);
            this.Splitter2_panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.Splitter2_panel.Location = new System.Drawing.Point(0, 0);
            this.Splitter2_panel.Name = "Splitter2_panel";
            this.Splitter2_panel.Size = new System.Drawing.Size(289, 770);
            this.Splitter2_panel.TabIndex = 8;
            // 
            // Splitter2_panel2
            // 
            this.Splitter2_panel2.Controls.Add(this.ExtractPanel);
            this.Splitter2_panel2.Controls.Add(this.PrintBtnPanel);
            this.Splitter2_panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Splitter2_panel2.Location = new System.Drawing.Point(0, 237);
            this.Splitter2_panel2.Name = "Splitter2_panel2";
            this.Splitter2_panel2.Size = new System.Drawing.Size(289, 533);
            this.Splitter2_panel2.TabIndex = 8;
            // 
            // ExtractPanel
            // 
            this.ExtractPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExtractPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExtractPanel.Location = new System.Drawing.Point(0, 35);
            this.ExtractPanel.Name = "ExtractPanel";
            this.ExtractPanel.Size = new System.Drawing.Size(289, 498);
            this.ExtractPanel.TabIndex = 0;
            // 
            // PrintBtnPanel
            // 
            this.PrintBtnPanel.Controls.Add(this.OrderCng_Button);
            this.PrintBtnPanel.Controls.Add(this.Print_Button);
            this.PrintBtnPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PrintBtnPanel.Location = new System.Drawing.Point(0, 0);
            this.PrintBtnPanel.Name = "PrintBtnPanel";
            this.PrintBtnPanel.Size = new System.Drawing.Size(289, 35);
            this.PrintBtnPanel.TabIndex = 6;
            // 
            // OrderCng_Button
            // 
            this.OrderCng_Button.Location = new System.Drawing.Point(113, 3);
            this.OrderCng_Button.Name = "OrderCng_Button";
            this.OrderCng_Button.Size = new System.Drawing.Size(134, 29);
            this.OrderCng_Button.TabIndex = 1;
            this.OrderCng_Button.Text = "�\�[�g���ύX(&O)";
            this.OrderCng_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.OrderCng_Button.Click += new System.EventHandler(this.OrderCng_Button_Click);
            // 
            // Print_Button
            // 
            this.Print_Button.Location = new System.Drawing.Point(3, 3);
            this.Print_Button.Name = "Print_Button";
            this.Print_Button.Size = new System.Drawing.Size(104, 29);
            this.Print_Button.TabIndex = 0;
            this.Print_Button.Text = "���(&P)";
            this.Print_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Print_Button.Click += new System.EventHandler(this.Print_Button_Click);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 234);
            this.splitter2.MinExtra = 3;
            this.splitter2.MinSize = 3;
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(289, 3);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // Panel_Fill_Panel
            // 
            this.Panel_Fill_Panel.Controls.Add(this.GroupPanel);
            this.Panel_Fill_Panel.Controls.Add(this.ultraLabel1);
            this.Panel_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.Panel_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel_Fill_Panel.Name = "Panel_Fill_Panel";
            this.Panel_Fill_Panel.Size = new System.Drawing.Size(289, 234);
            this.Panel_Fill_Panel.TabIndex = 0;
            // 
            // GroupPanel
            // 
            this.GroupPanel.Controls.Add(this.GroupPanel_Fill_Panel);
            this.GroupPanel.Controls.Add(this._GroupPanel_Toolbars_Dock_Area_Left);
            this.GroupPanel.Controls.Add(this._GroupPanel_Toolbars_Dock_Area_Right);
            this.GroupPanel.Controls.Add(this._GroupPanel_Toolbars_Dock_Area_Top);
            this.GroupPanel.Controls.Add(this._GroupPanel_Toolbars_Dock_Area_Bottom);
            this.GroupPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupPanel.Location = new System.Drawing.Point(0, 26);
            this.GroupPanel.Name = "GroupPanel";
            this.GroupPanel.Size = new System.Drawing.Size(289, 208);
            this.GroupPanel.TabIndex = 0;
            // 
            // GroupPanel_Fill_Panel
            // 
            this.GroupPanel_Fill_Panel.Controls.Add(this.FreePprGr_Grid);
            this.GroupPanel_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.GroupPanel_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupPanel_Fill_Panel.Location = new System.Drawing.Point(0, 26);
            this.GroupPanel_Fill_Panel.Name = "GroupPanel_Fill_Panel";
            this.GroupPanel_Fill_Panel.Size = new System.Drawing.Size(289, 182);
            this.GroupPanel_Fill_Panel.TabIndex = 0;
            // 
            // FreePprGr_Grid
            // 
            appearance12.BackColor = System.Drawing.Color.White;
            appearance12.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.FreePprGr_Grid.DisplayLayout.Appearance = appearance12;
            this.FreePprGr_Grid.DisplayLayout.InterBandSpacing = 10;
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance13.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance13.ForeColor = System.Drawing.Color.Black;
            this.FreePprGr_Grid.DisplayLayout.Override.ActiveCellAppearance = appearance13;
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            this.FreePprGr_Grid.DisplayLayout.Override.CellAppearance = appearance14;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance15.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance15.ForeColor = System.Drawing.Color.White;
            appearance15.TextHAlignAsString = "Left";
            appearance15.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.FreePprGr_Grid.DisplayLayout.Override.HeaderAppearance = appearance15;
            appearance16.BackColor = System.Drawing.Color.Lavender;
            this.FreePprGr_Grid.DisplayLayout.Override.RowAlternateAppearance = appearance16;
            appearance17.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            appearance17.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FreePprGr_Grid.DisplayLayout.Override.RowAppearance = appearance17;
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance18.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance18.ForeColor = System.Drawing.Color.White;
            this.FreePprGr_Grid.DisplayLayout.Override.RowSelectorAppearance = appearance18;
            this.FreePprGr_Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.FreePprGr_Grid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.FreePprGr_Grid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.FreePprGr_Grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.FreePprGr_Grid.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(191)))));
            this.FreePprGr_Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.FreePprGr_Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.FreePprGr_Grid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.FreePprGr_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FreePprGr_Grid.Location = new System.Drawing.Point(0, 0);
            this.FreePprGr_Grid.Name = "FreePprGr_Grid";
            this.FreePprGr_Grid.Size = new System.Drawing.Size(289, 182);
            this.FreePprGr_Grid.TabIndex = 0;
            this.FreePprGr_Grid.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.FreePprGr_Grid_AfterSelectChange);
            this.FreePprGr_Grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FreePprGr_Grid_KeyDown);
            this.FreePprGr_Grid.BeforeRowDeactivate += new System.ComponentModel.CancelEventHandler(this.FreePprGr_Grid_BeforeRowDeactivate);
            this.FreePprGr_Grid.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.FreePprGr_Grid_DoubleClickRow);
            // 
            // _GroupPanel_Toolbars_Dock_Area_Left
            // 
            this._GroupPanel_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._GroupPanel_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._GroupPanel_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._GroupPanel_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._GroupPanel_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 26);
            this._GroupPanel_Toolbars_Dock_Area_Left.Name = "_GroupPanel_Toolbars_Dock_Area_Left";
            this._GroupPanel_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 182);
            this._GroupPanel_Toolbars_Dock_Area_Left.ToolbarsManager = this.GroupToolbarsManager;
            // 
            // GroupToolbarsManager
            // 
            this.GroupToolbarsManager.DesignerFlags = 1;
            this.GroupToolbarsManager.DockWithinContainer = this.GroupPanel;
            this.GroupToolbarsManager.ShowFullMenusDelay = 500;
            this.GroupToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 0;
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool5,
            buttonTool6});
            ultraToolbar2.Text = "UltraToolbar1";
            this.GroupToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar2});
            buttonTool7.SharedProps.Caption = "�O���[�v�ǉ�";
            buttonTool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool8.SharedProps.Caption = "�O���[�v�폜";
            buttonTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.GroupToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool7,
            buttonTool8});
            this.GroupToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.GroupToolbarsManager_ToolClick);
            // 
            // _GroupPanel_Toolbars_Dock_Area_Right
            // 
            this._GroupPanel_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._GroupPanel_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._GroupPanel_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._GroupPanel_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._GroupPanel_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(289, 26);
            this._GroupPanel_Toolbars_Dock_Area_Right.Name = "_GroupPanel_Toolbars_Dock_Area_Right";
            this._GroupPanel_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 182);
            this._GroupPanel_Toolbars_Dock_Area_Right.ToolbarsManager = this.GroupToolbarsManager;
            // 
            // _GroupPanel_Toolbars_Dock_Area_Top
            // 
            this._GroupPanel_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._GroupPanel_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._GroupPanel_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._GroupPanel_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._GroupPanel_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._GroupPanel_Toolbars_Dock_Area_Top.Name = "_GroupPanel_Toolbars_Dock_Area_Top";
            this._GroupPanel_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(289, 26);
            this._GroupPanel_Toolbars_Dock_Area_Top.ToolbarsManager = this.GroupToolbarsManager;
            // 
            // _GroupPanel_Toolbars_Dock_Area_Bottom
            // 
            this._GroupPanel_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._GroupPanel_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._GroupPanel_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._GroupPanel_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._GroupPanel_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 208);
            this._GroupPanel_Toolbars_Dock_Area_Bottom.Name = "_GroupPanel_Toolbars_Dock_Area_Bottom";
            this._GroupPanel_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(289, 0);
            this._GroupPanel_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.GroupToolbarsManager;
            // 
            // ultraLabel1
            // 
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance19.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance19.ForeColor = System.Drawing.Color.White;
            appearance19.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance19.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance19.TextHAlignAsString = "Left";
            appearance19.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance19;
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraLabel1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.5F, System.Drawing.FontStyle.Bold);
            this.ultraLabel1.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(289, 26);
            this.ultraLabel1.TabIndex = 7;
            this.ultraLabel1.Text = "����O���[�v";
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.AlwaysEvent = true;
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // Main_DockManager
            // 
            this.Main_DockManager.AnimationSpeed = Infragistics.Win.UltraWinDock.AnimationSpeed.StandardSpeedPlus5;
            this.Main_DockManager.CaptionStyle = Infragistics.Win.UltraWinDock.CaptionStyle.Office2003;
            dockAreaPane1.ChildPaneStyle = Infragistics.Win.UltraWinDock.ChildPaneStyle.VerticalSplit;
            dockableControlPane1.Control = this.SelectExplorerBar;
            dockableControlPane1.FlyoutSize = new System.Drawing.Size(226, -1);
            dockableControlPane1.Key = "SelectCondition";
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(0, 3, 250, 619);
            dockableControlPane1.Pinned = false;
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "���_�I��";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(226, 630);
            this.Main_DockManager.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1});
            this.Main_DockManager.HostControl = this;
            this.Main_DockManager.ShowCloseButton = false;
            this.Main_DockManager.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2003;
            // 
            // _SFANL08201UAUnpinnedTabAreaLeft
            // 
            this._SFANL08201UAUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._SFANL08201UAUnpinnedTabAreaLeft.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFANL08201UAUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._SFANL08201UAUnpinnedTabAreaLeft.Name = "_SFANL08201UAUnpinnedTabAreaLeft";
            this._SFANL08201UAUnpinnedTabAreaLeft.Owner = this.Main_DockManager;
            this._SFANL08201UAUnpinnedTabAreaLeft.Size = new System.Drawing.Size(22, 770);
            this._SFANL08201UAUnpinnedTabAreaLeft.TabIndex = 1;
            // 
            // _SFANL08201UAUnpinnedTabAreaRight
            // 
            this._SFANL08201UAUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._SFANL08201UAUnpinnedTabAreaRight.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFANL08201UAUnpinnedTabAreaRight.Location = new System.Drawing.Point(924, 0);
            this._SFANL08201UAUnpinnedTabAreaRight.Name = "_SFANL08201UAUnpinnedTabAreaRight";
            this._SFANL08201UAUnpinnedTabAreaRight.Owner = this.Main_DockManager;
            this._SFANL08201UAUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 770);
            this._SFANL08201UAUnpinnedTabAreaRight.TabIndex = 2;
            // 
            // _SFANL08201UAUnpinnedTabAreaTop
            // 
            this._SFANL08201UAUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._SFANL08201UAUnpinnedTabAreaTop.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFANL08201UAUnpinnedTabAreaTop.Location = new System.Drawing.Point(22, 0);
            this._SFANL08201UAUnpinnedTabAreaTop.Name = "_SFANL08201UAUnpinnedTabAreaTop";
            this._SFANL08201UAUnpinnedTabAreaTop.Owner = this.Main_DockManager;
            this._SFANL08201UAUnpinnedTabAreaTop.Size = new System.Drawing.Size(902, 0);
            this._SFANL08201UAUnpinnedTabAreaTop.TabIndex = 3;
            // 
            // _SFANL08201UAUnpinnedTabAreaBottom
            // 
            this._SFANL08201UAUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._SFANL08201UAUnpinnedTabAreaBottom.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFANL08201UAUnpinnedTabAreaBottom.Location = new System.Drawing.Point(22, 770);
            this._SFANL08201UAUnpinnedTabAreaBottom.Name = "_SFANL08201UAUnpinnedTabAreaBottom";
            this._SFANL08201UAUnpinnedTabAreaBottom.Owner = this.Main_DockManager;
            this._SFANL08201UAUnpinnedTabAreaBottom.Size = new System.Drawing.Size(902, 0);
            this._SFANL08201UAUnpinnedTabAreaBottom.TabIndex = 4;
            // 
            // _SFANL08201UAAutoHideControl
            // 
            this._SFANL08201UAAutoHideControl.Controls.Add(this.dockableWindow1);
            this._SFANL08201UAAutoHideControl.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFANL08201UAAutoHideControl.Location = new System.Drawing.Point(22, 0);
            this._SFANL08201UAAutoHideControl.Name = "_SFANL08201UAAutoHideControl";
            this._SFANL08201UAAutoHideControl.Owner = this.Main_DockManager;
            this._SFANL08201UAAutoHideControl.Size = new System.Drawing.Size(71, 770);
            this._SFANL08201UAAutoHideControl.TabIndex = 5;
            // 
            // dockableWindow1
            // 
            this.dockableWindow1.Controls.Add(this.SelectExplorerBar);
            this.dockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.dockableWindow1.Name = "dockableWindow1";
            this.dockableWindow1.Owner = this.Main_DockManager;
            this.dockableWindow1.Size = new System.Drawing.Size(226, 770);
            this.dockableWindow1.TabIndex = 7;
            // 
            // windowDockingArea1
            // 
            this.windowDockingArea1.Dock = System.Windows.Forms.DockStyle.Left;
            this.windowDockingArea1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.windowDockingArea1.Location = new System.Drawing.Point(22, 0);
            this.windowDockingArea1.Name = "windowDockingArea1";
            this.windowDockingArea1.Owner = this.Main_DockManager;
            this.windowDockingArea1.Size = new System.Drawing.Size(231, 630);
            this.windowDockingArea1.TabIndex = 6;
            // 
            // SFANL08201UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(924, 770);
            this.Controls.Add(this._SFANL08201UAAutoHideControl);
            this.Controls.Add(this.SFANL08201U_Fill_Panel);
            this.Controls.Add(this.windowDockingArea1);
            this.Controls.Add(this._SFANL08201UAUnpinnedTabAreaTop);
            this.Controls.Add(this._SFANL08201UAUnpinnedTabAreaBottom);
            this.Controls.Add(this._SFANL08201UAUnpinnedTabAreaRight);
            this.Controls.Add(this._SFANL08201UAUnpinnedTabAreaLeft);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SFANL08201UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SFANL08201UA_FormClosing);
            this.Load += new System.EventHandler(this.SFANL08201UA_Load);
            this.ultraExplorerBarContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AddUpCd_UOptionSet)).EndInit();
            this.ultraExplorerBarContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Section_UTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectExplorerBar)).EndInit();
            this.SelectExplorerBar.ResumeLayout(false);
            this.SFANL08201U_Fill_Panel.ResumeLayout(false);
            this.Centering_Panel.ResumeLayout(false);
            this.Splitter1_panel.ResumeLayout(false);
            this.Sqlitter1_panel1.ResumeLayout(false);
            this.DetailPanel.ResumeLayout(false);
            this.DetailPanel_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FreePprPrt_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailToolbarsManager)).EndInit();
            this.Splitter2_panel.ResumeLayout(false);
            this.Splitter2_panel2.ResumeLayout(false);
            this.PrintBtnPanel.ResumeLayout(false);
            this.Panel_Fill_Panel.ResumeLayout(false);
            this.GroupPanel.ResumeLayout(false);
            this.GroupPanel_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FreePprGr_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupToolbarsManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).EndInit();
            this._SFANL08201UAAutoHideControl.ResumeLayout(false);
            this.dockableWindow1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region private member
        private string _enterpriseCode = "";
        private SFANL08131UA _extCdtForm = new SFANL08131UA();         //���o�����p��ʍ쐬���i
        private SFANL08131UB _sortCngFrom = new SFANL08131UB();        //�\�[�g���ύX���i
        private bool _isOptSection = false;                           //���_�I�v�V�����L��
        private bool _isMainOfficeFunc = false;                       //�{�Ћ@�\
        private string _loginSectionCode = "";						    //���O�C�����_�R�[�h

        static private List<FrePrtPSet> _frePrtPSetLs = new List<FrePrtPSet>();   //���R���[�󎚈ʒu�ݒ�L���b�V��
        static private List<FrePprGrTr> _freePprGrpTrLs = new List<FrePprGrTr>(); //���R���[�O���[�v�U�փL���b�V��
        private Dictionary<string, List<FrePprECnd>> _frePprECndLsHt = new Dictionary<string, List<FrePprECnd>>(); //���o�������X�g�L���b�V��(key:FreePrtPprGroupCd.ToString() + "," + OutputFormFileName+","+ UserPrtPprIdDerivNo.ToString())
        private Dictionary<string, List<FrePprSrtO>> _frePprSrtOLsHT = new Dictionary<string, List<FrePprSrtO>>(); //���R���[�\�[�g���ʃ��X�g�L���b�V��(key:FreePrtPprGroupCd.ToString() + "," + OutputFormFileName+","+ UserPrtPprIdDerivNo.ToString())
        private List<FrePExCndD> _frePprECndDLs = null;                            //���o�������׃��X�g�L���b�V��

        private SFANL08203U _printDialog = new SFANL08203U();              //����_�C�A���O
        private SFANL08205C _printInfo = new SFANL08205C();                //������p�����[�^
        private SecInfoAcs _secInfoAcs = new SecInfoAcs();                 //���_���A�N�Z�X�N���X
        private List<SecInfoSet> _secInfoLs = new List<SecInfoSet>();      //���_���L���b�V��
        private List<string> _selectSecCds = new List<string>();         //�I�����_�R�[�h���X�g

        private bool _secNodeCheckEvent = false;					        //���_�I���C�x���g�����t���O
        private List<FrePprECnd> _frePprECndLs = new List<FrePprECnd>();   //��������
        private LastPrtTimeAcs _lastPrtTimeAcs = new LastPrtTimeAcs();     //�ŏI��������A�N�Z�X�N���X
        private List<LastPrtTime> _lastTimes = null;                      //�ŏI��������L���b�V��

        private bool _allSectionDiv = false;                               //�S�Ћ敪


        // --- �O���[�v���� -------------------------
        private DataSet _freeSheetGrDS = new DataSet();                    //���R���[�O���[�v�f�[�^�Z�b�g
        private MaintenanceDlg _maintenanceDlg = new MaintenanceDlg();     //���R���[�O���[�v/�U�֒ǉ��ύX�_�C�A���O
        private FreePprGrpAcs _frePprGrAcs = new FreePprGrpAcs();          //���R���[�O���[�v�A�N�Z�X�N���X

        // --- ���א��� -------------------------
        private DataSet _freeSheetPrtDS = new DataSet();                   //���R���[����Ώۃf�[�^�Z�b�g
        private DataView _freeSheetPrtDV;                                  //���R���[����Ώۃf�[�^�r���[

        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�萔
        // ===================================================================================== //
        #region private constant
        // �c�[���o�[�֘A
        private const string CT_PRINT_BUTTONTOOL = "PrintButtonTool";

        // Message�֘A
        private const string ctPRINT_TITLE = "���R���[�ꊇ���";
        private const string ctPRINT_MESSAGE = "���R���[�ꊇ������ł��D�D�D";

        // �S�Ћ��_�R�[�h
        private const string CT_AllSectionCode = "0";
        // �S���_�R�[�h
        private const string CT_AllCtrlFuncSecCode = "000000";

        // �G�N�X�v���[���[�o�[�L�[�ݒ�
        private const string EXPLORERBAR_ADDUPCDLIST = "AddUpCdList";
        private const string EXPLORERBAR_SECTIONLIST = "SectionList";

        // �h�b�N�}�l�[�W���[�L�[�ݒ�
        private const string DOCKMANAGER_SELECTCONDITION_KEY = "SelectCondition";

        #endregion

        // ===================================================================================== //
        // ���C��
        // ===================================================================================== //
        #region Main
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run( new SFANL08201UA() );
        }
        #endregion

        // ===================================================================================== //
        // public Methods
        // ===================================================================================== //
        #region public Methods
        /// <summary>
        /// �󎚈ʒu�L���b�V���擾����
        /// </summary>
        /// <param name="frePprPSetLs">���R���[�󎚈ʒu�L���b�V��(key:OutputFormFileName+","+ UserPrtPprIdDerivNo.ToString())</param>
        /// <returns>�X�e�[�^�X:����擾0 �L���b�V���Ȃ��F4</returns>
        static public int GetFrePrtPSetLsCash( ref List<FrePrtPSet> frePprPSetLs )
        {
            if ( (_frePrtPSetLs == null) || (_frePrtPSetLs.Count == 0) )
                return 4;
            else
            {
                frePprPSetLs = _frePrtPSetLs;
                return 0;
            }
        }

        /// <summary>
        /// ���R���[�󎚈ʒu�擾
        /// </summary>
        /// <param name="groupCd"></param>
        /// <param name="outputFormFileName">�o�̓t�H�[�}�b�g</param>
        /// <param name="userPrtPprIdDerivNo">�}��</param>
        /// <returns></returns>
        static public FrePprGrTr GetFrePprGrTrCash( int groupCd, string outputFormFileName, int userPrtPprIdDerivNo )
        {
            return _freePprGrpTrLs.Find( delegate( FrePprGrTr grtr )
            {
                if ( (grtr.FreePrtPprGroupCd == groupCd) && (grtr.OutputFormFileName == outputFormFileName) && (grtr.UserPrtPprIdDerivNo == userPrtPprIdDerivNo) )
                    return true;
                else
                    return false;
            } );
        }

        #endregion

        // ===================================================================================== //
        // private methods
        // ===================================================================================== //
        #region private methods
        #region ���_���L���b�V��
        /// <summary>
        /// ���_�����擾���o�b�t�@�ϐ��ɃL���b�V�����܂�
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        private int GetSecInfoSetCash()
        {
            _secInfoLs.Clear();
            for ( int i = 0; i < this._secInfoAcs.SecInfoSetList.Length; i++ )
            {
                this._secInfoLs.Add( this._secInfoAcs.SecInfoSetList[i].Clone() );
            }
            if ( this._secInfoLs.Count == 0 ) return (int)ConstantManagement.DB_Status.ctDB_EOF;
            return 0;
        }
        #endregion

        #region ���_�I��UI�ݒ菈��
        /// <summary>
        /// ���_�I���c���[�\�z����
        /// </summary>
        /// <param name="extraSectionSelExist"></param>
        /// <returns></returns>
        private int InitSettingSectionTree( int extraSectionSelExist )
        {
            // ���_�I�v�V�����L���`�F�b�N
            if ( (int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany( ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION ) > 0 )
            {
                this._isOptSection = true;
            }
            else
            {
                this._isOptSection = false;
                SelectExplorerBar.Visible = false;
            }
            // �{�Ћ@�\����
            // 2008.12.25 Modify Start [9575]
            //this._isMainOfficeFunc = (this._secInfoAcs.GetMainOfficeFuncFlag( this._loginSectionCode ) == 1);
            this._isMainOfficeFunc = true;  // �{�Ћ@�\����
            // 2008.12.25 Modify End [9575]

            // ���_�I�v�V�����L��
            if ( this._isOptSection )
            {
                this.Section_UTree.Nodes.Clear();
                if ( extraSectionSelExist == 1 )
                {
                    if ( this._secInfoLs != null )
                    {
                        // �������_���݂���ꍇ�A�S�Ђ�ݒ�
                        if ( this._secInfoLs.Count > 1 )
                        {
                            this.Section_UTree.Nodes.Add( CT_AllSectionCode, "�S��" );
                            this.Section_UTree.Nodes[CT_AllSectionCode].Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                            this.Section_UTree.Nodes[CT_AllSectionCode].CheckedState = System.Windows.Forms.CheckState.Unchecked;
                        }
                        foreach ( SecInfoSet secInfoSet in _secInfoLs )
                        {
                            this.Section_UTree.Nodes.Add( secInfoSet.SectionCode.TrimEnd(), secInfoSet.SectionGuideNm );
                            this.Section_UTree.Nodes[secInfoSet.SectionCode.TrimEnd()].Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                            this.Section_UTree.Nodes[secInfoSet.SectionCode.TrimEnd()].CheckedState = System.Windows.Forms.CheckState.Unchecked;
                        }
                    }
                    // �f�t�H���g�`�F�b�N�̓��O�C�����_
                    this.Section_UTree.Nodes[this._loginSectionCode.TrimEnd()].CheckedState = System.Windows.Forms.CheckState.Checked;
                }
                else if ( extraSectionSelExist == 2 )
                {
                    foreach ( SecInfoSet secInfoSet in _secInfoLs )
                    {
                        this.Section_UTree.Nodes.Add( secInfoSet.SectionCode.TrimEnd(), secInfoSet.SectionGuideNm );
                        this.Section_UTree.Nodes[secInfoSet.SectionCode.TrimEnd()].Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.OptionButton;
                    }
                    // �f�t�H���g�`�F�b�N�̓��O�C�����_
                    this.Section_UTree.Nodes[this._loginSectionCode.TrimEnd()].CheckedState = System.Windows.Forms.CheckState.Checked;
                }
                else
                {
                    SelectExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible = false;
                }
            }
            else Main_DockManager.Visible = false;
            return 0;
        }

        /// <summary>
        /// ���_�I���c���[�̃r���[��Ԃ�ݒ肵�܂�
        /// </summary>
        /// <param name="extraSectionSelExist"></param>
        private void ViewSettingSectionTree( int extraSectionSelExist )
        {
            // ���_�I���E�v�㋒�_�I��\���ݒ�
            if ( _isMainOfficeFunc )
            {
                if ( extraSectionSelExist != 0 )
                    SelectExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible = true;
            }
            else
            {
                SelectExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible = false;
            }

        }
        #endregion

        #region ���_��ރ��X�g��ʃ��C�A�E�g�ݒ�
        /// <summary>
        /// ���_��ރ��X�g��ʃ��C�A�E�g�ݒ�
        /// </summary>
        /// <param name="extraSectionKindCd">���_��ʋ敪</param>
        private void InitialSettingSectionKind( int extraSectionKindCd )
        {
            // �v���ރI�v�V�����Z�b�g������
            if ( this.AddUpCd_UOptionSet.Items != null )
            {
                this.AddUpCd_UOptionSet.Items.Clear();
            }

            switch ( extraSectionKindCd )
            {
                case 1:
                    {
                        // �^�C�g���ݒ�
                        Infragistics.Win.ValueListItem item = new Infragistics.Win.ValueListItem();
                        item.DataValue = 1;
                        item.DisplayText = "���ьv�㋒�_";
                        item.Tag = 10;
                        this.AddUpCd_UOptionSet.Items.Add( item );

                        item = new Infragistics.Win.ValueListItem();
                        item.DataValue = 2;
                        item.DisplayText = "�����v�㋒�_";
                        item.Tag = 20;
                        this.AddUpCd_UOptionSet.Items.Add( item );
                        break;
                    }
                case 2:
                    {
                        // �^�C�g���ݒ�
                        Infragistics.Win.ValueListItem item = new Infragistics.Win.ValueListItem();
                        item.DataValue = 1;
                        item.DisplayText = "�d���v�㋒�_";
                        item.Tag = 30;
                        this.AddUpCd_UOptionSet.Items.Add( item );

                        item = new Infragistics.Win.ValueListItem();
                        item.DataValue = 2;
                        item.DisplayText = "�̔��v�㋒�_";
                        item.Tag = 40;
                        this.AddUpCd_UOptionSet.Items.Add( item );
                        break;
                    }
            }
            // �����l�ݒ�
            if ( this.AddUpCd_UOptionSet.Items != null )
            {
                if ( this.AddUpCd_UOptionSet.Items.Count > 0 )
                {
                    this.AddUpCd_UOptionSet.CheckedIndex = 0;
                }
            }
            _printInfo.sectionKindCd = 1;
        }

        /// <summary>
        /// �v�㋒�_��ʂ̕\����Ԃ𐧌�
        /// </summary>
        /// <param name="extraSectionKindCd"></param>
        private void ViewSettingSectionKind( int extraSectionKindCd )
        {
            if ( this.AddUpCd_UOptionSet.Items != null )
            {
                SelectExplorerBar.Groups[EXPLORERBAR_ADDUPCDLIST].Visible = true;
            }

            if ( extraSectionKindCd == 0 )
            {
                if ( SelectExplorerBar.Groups[EXPLORERBAR_ADDUPCDLIST] != null )
                    SelectExplorerBar.Groups[EXPLORERBAR_ADDUPCDLIST].Visible = false;
            }
        }

        #endregion

        #region ����@�\���_�擾
        /// <summary>
        /// ����@�\���_�擾
        /// </summary>
        /// <param name="sectionCode">�Ώۋ��_�R�[�h</param>
        /// <param name="ctrlFuncCode">�擾���鐧��@�\�R�[�h</param>
        /// <param name="ctrlSectionCode">�Ώې��䋒�_�R�[�h</param>
        /// <returns>status</returns>
        private int GetOwnSeCtrlCode( string sectionCode, int ctrlFuncCode, out string ctrlSectionCode )
        {
            // �Ώې��䋒�_�̏����l�͎����_
            ctrlSectionCode = sectionCode;

            SecInfoSet secInfoSet;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 DEL
            //SecInfoAcs.CtrlFuncCode ctrlFunc;
            //switch (ctrlFuncCode)
            //{
            //    case 10:		// �����_�ݒ�
            //        ctrlFunc = SecInfoAcs.CtrlFuncCode.OwnSecSetting;
            //        break;
            //    case 20:		// �����v�㋒�_
            //        ctrlFunc = SecInfoAcs.CtrlFuncCode.DemandAddUpSecCd;
            //        break;
            //    case 30:		// ���ьv�㋒�_
            //        ctrlFunc = SecInfoAcs.CtrlFuncCode.ResultsAddUpSecCd;
            //        break;
            //    case 40:		// �����ݒ苒�_
            //        ctrlFunc = SecInfoAcs.CtrlFuncCode.BillSettingSecCd;
            //        break;
            //    case 50:		// �c���\�����_
            //        ctrlFunc = SecInfoAcs.CtrlFuncCode.BalanceDispSecCd;
            //        break;
            //    case 60:		// �x���v�㋒�_
            //        ctrlFunc = SecInfoAcs.CtrlFuncCode.PayAddUpSecCd;
            //        break;
            //    case 70:		// �x���ݒ苒�_
            //        ctrlFunc = SecInfoAcs.CtrlFuncCode.PayAddUpSetSecCd;
            //        break;
            //    case 80:		// �x���c���\�����_
            //        ctrlFunc = SecInfoAcs.CtrlFuncCode.PayBlcDispSecCd;
            //        break;
            //    case 90:		// �݌ɍX�V���_
            //        ctrlFunc = SecInfoAcs.CtrlFuncCode.StockUpdateSecCd;
            //        break;
            //    default:
            //        ctrlFunc = SecInfoAcs.CtrlFuncCode.OwnSecSetting;
            //        break;
            //}
            //int status = this._secInfoAcs.GetSecInfo(sectionCode, ctrlFunc, out secInfoSet);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 ADD
            int status = this._secInfoAcs.GetSecInfo( sectionCode, out secInfoSet );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 ADD
            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    if ( secInfoSet != null )
                    {
                        ctrlSectionCode = secInfoSet.SectionCode.TrimEnd();

                        //�u�S���_: 000000�v��������u�S��: 0�v�ɒu��������
                        if ( ctrlSectionCode.Equals( CT_AllCtrlFuncSecCode ) )
                        {
                            ctrlSectionCode = CT_AllSectionCode;

                        }
                    }
                    break;
                default:
                    break;
            }

            return status;
        }
        #endregion

        #region ������ʐݒ�
        /// <summary>
        /// ������ʐݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : ������ʐݒ���s���܂��B</br>
        /// <br>Programmer : 22011 Kashihara</br>
        /// <br>Date       : 2005.09.09</br>
        /// </remarks>
        private void InitialScreenSetting()
        {
            //-- �O���[�v ---------------------
            DataSetColumnConstruction();        //�f�[�^�Z�b�g�쐬
            FreePprGr_Grid.DataSource = _freeSheetGrDS.Tables[CT_FREE_PPR_GR];
            _freeSheetGrDS.Tables[CT_FREE_PPR_GR].DefaultView.Sort = CT_FREE_PPR_GrCd;
            //���R���[�O���[�v�̃O���b�h�ݒ�
            setGridAppearance( FreePprGr_Grid );        // �z�F�ݒ�
            setGridBehavior( FreePprGr_Grid );          // ����ݒ�
            // �c�[���o�[�̐ݒ�
            SetToolbarAppearance( GroupToolbarsManager );

            //-- ���� -------------------------
            //�f�[�^�Z�b�g�쐬
            _freeSheetPrtDV = new DataView( _freeSheetPrtDS.Tables[CT_FREE_PPR_PRT] );
            _freeSheetPrtDV.Sort = CT_FREE_PPR_DspOdr;                      //�\�����ʏ��Ƀ\�[�g
            FreePprPrt_Grid.DataSource = this._freeSheetPrtDV;             //�O���b�h�Ƀo�C���h
            //���R���[����Ώۂ̃O���b�h�ݒ�
            setGridAppearance( FreePprPrt_Grid );        // �z�F�ݒ�
            setGridBehavior( FreePprPrt_Grid );          // ����ݒ�
            SetGridColAppearance();                   // ��T�ϐݒ�(�O���[�v�E�U��)

            // �c�[���o�[�̐ݒ�
            SetToolbarAppearance( DetailToolbarsManager );


            //�A�C�R���̐ݒ�
            ImageList imageList16 = IconResourceManagement.ImageList16;
            //����{�^��
            this.Print_Button.ImageList = imageList16;
            this.Print_Button.Appearance.Image = Size16_Index.PRINT;
            // �o�͏����I��
            this.Main_DockManager.ImageList = IconResourceManagement.ImageList16;
            this.Main_DockManager.ControlPanes[DOCKMANAGER_SELECTCONDITION_KEY].Settings.Appearance.Image = Size16_Index.TREE;

            //�c�[���o�[�ݒ�
            List<string> editMenuKeyLs = new List<string>();
            editMenuKeyLs.Add( FreeSheetConst.ctToolBase_Save );
            editMenuKeyLs.Add( FreeSheetConst.ctToolBase_New );
            editMenuKeyLs.Add( FreeSheetConst.ctToolBase_Print );
            editMenuKeyLs.Add( FreeSheetConst.ctToolBase_Open );
            editMenuKeyLs.Add( FreeSheetConst.ctPopupMenu_Help );
            editMenuKeyLs.Add( FreeSheetConst.ctPopupMenu_Display );
            editMenuKeyLs.Add( FreeSheetConst.ctPopupMenu_Window );
            editMenuKeyLs.Add( FreeSheetConst.ctPopupMenu_Edit );

            //���o������ʂ��Z�b�g
            _extCdtForm.Dock = DockStyle.Fill;
            _extCdtForm.BackColor = ExtractPanel.BackColor;
            this.ExtractPanel.Controls.Add( _extCdtForm );

            //�C�x���g���L�b�N
            ToolButtonVisibleChanged( editMenuKeyLs, false );
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 ADD
            ToolButtonEnableChanged( editMenuKeyLs, false );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 ADD

            //���R���[�O���[�v�A���R���[�O���[�v�U�ւ��L���b�V��
            SetDataSource( 0 );

            //�S�O���[�v�s���A�N�e�B�x�[�g
            AllFreePprGroupActivated();
            GroupFiltering( 0 );
            FirstRowActivated();
        }
        #endregion ������ʐݒ�

        #region ���b�Z�[�W�\��
        /// <summary>
        /// �G���[���b�Z�[�W�\��
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="iMsg">�G���[���b�Z�[�W</param>
        /// <param name="iSt">�G���[�X�e�[�^�X</param>
        /// <param name="iButton">�\���{�^��</param>
        /// <param name="iDefButton">�����t�H�[�J�X�{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W��\�����܂��B</br>
        /// <br>Programmer : 22011 Kashihara</br>
        /// <br>Date       : 2006.01.20</br>
        /// </remarks>
        private DialogResult TMessageBox( emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton )
        {
            return TMsgDisp.Show( iLevel, this.Name, iMsg, iSt, iButton, iDefButton );
        }
        #endregion

        #region �L���b�V������f�[�^���擾���܂�
        /// <summary>
        /// ���R���[�󎚈ʒu�擾
        /// </summary>
        /// <param name="outputFormFileName">�o�̓t�H�[�}�b�g</param>
        /// <param name="userPrtPprIdDerivNo">�}��</param>
        /// <returns></returns>
        private FrePrtPSet GetFrePrtPSetCash( string outputFormFileName, int userPrtPprIdDerivNo )
        {
            return _frePrtPSetLs.Find( delegate( FrePrtPSet pset )
            {
                if ( (pset.OutputFormFileName == outputFormFileName) && (pset.UserPrtPprIdDerivNo == userPrtPprIdDerivNo) )
                    return true;
                else
                    return false;
            } );
        }

        /// <summary>
        /// �O���[�v�U�ւ���O���[�v����ʂ����L�[���쐬���܂�(�����A�\�[�g���p)
        /// </summary>
        /// <param name="frePprGrTr"></param>
        /// <returns></returns>
        private string Generate_FrePprGrTr_Key( FrePprGrTr frePprGrTr )
        {
            return frePprGrTr.FreePrtPprGroupCd.ToString() + "," + frePprGrTr.TransferCode.ToString() + "," + frePprGrTr.OutputFormFileName + "," + frePprGrTr.UserPrtPprIdDerivNo.ToString();
        }

        /// <summary>
        /// �󎚈ʒu�ݒ肩��O���[�v����ʂ��Ȃ�(�����l��)�L�[���쐬���܂�(�����A�\�[�g���@�����l�p�p)
        /// </summary>
        /// <param name="frePrtPSet"></param>
        /// <returns></returns>
        private string Generate_FrePprGrTr_Key( FrePrtPSet frePrtPSet )
        {
            return "-1,0," + frePrtPSet.OutputFormFileName + "," + frePrtPSet.UserPrtPprIdDerivNo.ToString();
        }

        /// <summary>
        /// �O���[�v�U�ւ���O���[�v����ʂ��Ȃ�(�����l��)�L�[���쐬���܂�(�����A�\�[�g���@�����l�p�p)
        /// </summary>
        /// <param name="frePprGrTr"></param>
        /// <returns></returns>
        private string Generate_FrePprGrTr_Init_Key( FrePprGrTr frePprGrTr )
        {
            return "-1,0," + frePprGrTr.OutputFormFileName + "," + frePprGrTr.UserPrtPprIdDerivNo.ToString();
        }

        /// <summary>
        /// �󎚈ʒu�ݒ肩��e�󎚈ʒu�ݒ����ʂ���L�[���쐬���܂�
        /// </summary>
        /// <param name="frePrtPSet"></param>
        /// <returns></returns>
        private string Generate_FrePrtPSet_Key( FrePrtPSet frePrtPSet )
        {
            return frePrtPSet.OutputFormFileName + "," + frePrtPSet.UserPrtPprIdDerivNo.ToString();
        }

        /// <summary>
        /// �O���[�v�U�ւ���e�󎚈ʒu�ݒ����ʂ���L�[���쐬���܂�
        /// </summary>
        /// <param name="frePprGrTr"></param>
        /// <returns></returns>
        private string Generate_FrePrtPSet_Key( FrePprGrTr frePprGrTr )
        {
            return frePprGrTr.OutputFormFileName + "," + frePprGrTr.UserPrtPprIdDerivNo.ToString();
        }
        #endregion

        #region ���o������ʍ\�z����
        private int SetExtraCnditionFrom()
        {
            int status = 0;
            FrePprGrTr frePprGrTr;    //������p�U�փ}�X�^
            _frePprECndLs = new List<FrePprECnd>();

            //�U�֏��擾
            status = this.GetActiveFrePprGrTr( out frePprGrTr );
            if ( (status != 0) || (frePprGrTr.FileHeaderGuid == Guid.Empty) )
            {
                if ( frePprGrTr.FileHeaderGuid == Guid.Empty ) status = (Int32)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                _extCdtForm.Hide();
                ViewSettingSectionTree( 0 );

                SelectExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible = false;
                SelectExplorerBar.Groups[EXPLORERBAR_ADDUPCDLIST].Visible = false;
                return status;
            }
            //else
            //{
            //    SelectExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible = true;
            //    SelectExplorerBar.Groups[EXPLORERBAR_ADDUPCDLIST].Visible = true;
            //}

            //���o�������擾
            if ( _frePprECndLsHt.ContainsKey( Generate_FrePprGrTr_Key( frePprGrTr ) ) )
            {
                _frePprECndLs = (List<FrePprECnd>)_frePprECndLsHt[Generate_FrePprGrTr_Key( frePprGrTr )];
            }
            else
            {
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            //���o�������ׂ��擾
            if ( _frePprECndDLs == null )
            {
                FrePrtPSetAcs frePExCndDAcs = new FrePrtPSetAcs();
                frePExCndDAcs.SearchFrePExCndDList( _enterpriseCode, out _frePprECndDLs );
            }

            //���o��������ʂɐݒ�
            status = _extCdtForm.FreePrintExtrUIShow( _frePprECndLs, _frePprECndDLs );

            if ( status != 0 )
            {
                TMessageBox( emErrorLevel.ERR_LEVEL_STOP, _extCdtForm.GetErrorMessage, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
            }

            //�󎚈ʒu�ݒ���擾
            FrePrtPSet frePrtPSetBuff = GetFrePrtPSetCash( frePprGrTr.OutputFormFileName, frePprGrTr.UserPrtPprIdDerivNo );
            if ( frePrtPSetBuff != null )
            {
                FrePrtPSet pset = frePrtPSetBuff;
                //���_��ʂ�ݒ�
                ViewSettingSectionKind( pset.ExtraSectionKindCd );
                //���_�I���c���[�쐬
                ViewSettingSectionTree( pset.ExtraSectionSelExist );
            }
            else
            {
                ViewSettingSectionKind( 0 );
                ViewSettingSectionTree( 0 );
            }
            return status;
        }
        #endregion

        #region �\�[�g���ʕύX��ʍ\�z����
        private int SetSortOrderForm()
        {
            int status = 0;
            List<FrePprSrtO> frePprSrtOLs = new List<FrePprSrtO>();     //�\�[�g����
            FrePprGrTr frePprGrTr;                                      //������p�U�փ}�X�^

            //�U�֏��擾
            status = this.GetActiveFrePprGrTr( out frePprGrTr );
            if ( status != 0 )
            {
                return status;
            }

            //�\�[�g���ʎ擾
            if ( _frePprSrtOLsHT.ContainsKey( Generate_FrePprGrTr_Key( frePprGrTr ) ) )
            {
                frePprSrtOLs = (List<FrePprSrtO>)_frePprSrtOLsHT[Generate_FrePprGrTr_Key( frePprGrTr )];
            }
            else
            {
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            _sortCngFrom.ShowSortOderSetting( frePprSrtOLs );

            return status;
        }
        #endregion

        #region ���R���[�O���[�v�ύX�C�x���g
        /// <summary>
        /// ���R���[�O���[�v�ύX���̃C�x���g�ł�
        /// </summary>
        /// <param name="groupCd"></param>
        private void FrePPrGroupChange( Int32 groupCd )
        {
            // ���׍s���O���[�v�R�[�h�Ńt�B���^�����O
            GroupFiltering( groupCd );
            FirstRowActivated();
            // ���׍s���Ȃ������������ʂ������ōč\�z
            if ( FreePprPrt_Grid.Rows.FilteredInRowCount <= 0 )
                SetExtraCnditionFrom();
        }
        #endregion

        #region �����f�[�^�Z�b�g�\�z����
        private void CreateInitialDataSet()
        {
            FrePrtPosLocalAcs frePrtPSetAcs = new FrePrtPosLocalAcs();  //�󎚈ʒu�ݒ�A�N�Z�X(���[�J��)
            List<FrePrtPSet> frePrtPSetLsts = new List<FrePrtPSet>();   //���R���[�󎚈ʒu�ݒ�
            List<FrePprECnd> frePprECndLsts = new List<FrePprECnd>();   //���R���[���o������������
            List<FrePprSrtO> frePprSrtLsts = new List<FrePprSrtO>();    //���R���[�\�[�g��
            List<FrePprECnd> frePprECndLstsBuf = null;                  //���R���[���o�����o�b�t�@
            List<FrePprSrtO> frePprSrtOLstsBuf = null;                  //���R���[�\�[�g���o�b�t�@

            //���R���[�󎚈ʒu�擾
            frePrtPSetAcs.SearchLocalFrePrtPSet( _enterpriseCode, 1, out frePrtPSetLsts, out frePprECndLsts, out frePprSrtLsts );

            //���R���[�󎚈ʒu,���o����,�\�[�g�����L���b�V��
            foreach ( FrePrtPSet frePrtPSet in frePrtPSetLsts )
            {
                frePprECndLstsBuf = new List<FrePprECnd>();
                frePprSrtOLstsBuf = new List<FrePprSrtO>();

                //���R���[�󎚈ʒu���L���b�V��
                _frePrtPSetLs.Add( frePrtPSet );

                //���o����(�����l)���L���b�V��
                frePprECndLstsBuf = frePprECndLsts.FindAll( delegate( FrePprECnd frePprECnd )
                {
                    if ( (frePprECnd.OutputFormFileName == frePrtPSet.OutputFormFileName) &&
                       (frePprECnd.UserPrtPprIdDerivNo == frePrtPSet.UserPrtPprIdDerivNo) &&
                           (frePprECnd.UsedFlg == 1) ) return true;
                    else return false;
                } );
                if ( (frePprECndLstsBuf != null) && (frePprECndLstsBuf.Count > 0) )
                {
                    _frePprECndLsHt[Generate_FrePprGrTr_Key( frePrtPSet )] = frePprECndLstsBuf;
                }

                //���R���[�\�[�g���ʂ��L���b�V��
                frePprSrtOLstsBuf = frePprSrtLsts.FindAll( delegate( FrePprSrtO frePprSrtO )
                {
                    if ( (frePprSrtO.OutputFormFileName == frePrtPSet.OutputFormFileName) &&
                        (frePprSrtO.UserPrtPprIdDerivNo == frePrtPSet.UserPrtPprIdDerivNo) ) return true;
                    else return false;
                } );
                if ( (frePprSrtOLstsBuf != null) && (frePprSrtOLstsBuf.Count > 0) )
                {
                    frePprSrtOLstsBuf.Sort( new FrePprSrtOSortingOrderComparer() );
                    _frePprSrtOLsHT[Generate_FrePprGrTr_Key( frePrtPSet )] = frePprSrtOLstsBuf;
                }
            }
        }

        /// <summary>
        /// ���R���[�O���[�v�A���R���[�O���[�v�U�ւ��f�[�^�Z�b�g�ɐݒ肵�܂�
        /// </summary>
        /// <param name="mode">0:����,1:�O���[�v�̂�,2:�U�ւ̂�</param>
        /// <returns></returns>
        private int SetDataSource( int mode )
        {
            ArrayList freePprGrpAL = new ArrayList();                   //���R���[�O���[�v���o����
            ArrayList frePprGrTrAL = new ArrayList();                   //���R���[�O���[�v�U��
            int status = 0;

            if ( mode != 2 )
            {
                //���R���[�O���[�v�擾
                status = _frePprGrAcs.SearchAllFreePprGrp( out freePprGrpAL, _enterpriseCode );
                if ( status != 0 ) return status;
                ClearGroupDataTable();    //�O���[�v����DataTable������

                //�O���[�v���f�[�^�Z�b�g�ɓo�^
                foreach ( FreePprGrp freePprGrp in freePprGrpAL )
                {
                    //�O���[�v��DS�ɓo�^
                    FreePprGrToDataSet( freePprGrp );
                }
            }

            if ( mode != 1 )
            {
                //���R���[�O���[�v�U�֎擾
                status = _frePprGrAcs.SearchAllFreePprGrTr( out frePprGrTrAL, LoginInfoAcquisition.EnterpriseCode );
                if ( status != 0 ) return status;
                ClearDataTable();   //DataTable������

                //���R���[�O���[�v�U�ւ��f�[�^�Z�b�g�ɓo�^
                foreach ( FrePprGrTr fpgrtr in frePprGrTrAL )
                {
                    FrePrtPSet fppset = GetFrePrtPSetCash( fpgrtr.OutputFormFileName, fpgrtr.UserPrtPprIdDerivNo );
                    if ( fppset != null )
                    {
                        //�R�����g�ǉ�
                        fpgrtr.PrtPprUserDerivNoCmt = fppset.PrtPprUserDerivNoCmt;
                        //�ŏI��������ǉ�
                        LastPrtTime lastTime = _lastPrtTimeAcs.FindLastPrtTime( _lastTimes, fpgrtr );
                        if ( lastTime != null )
                        {
                            FreeSeetPrtToDataSet( fpgrtr, lastTime.lastPrtTime );
                        }
                        else
                        {
                            FreeSeetPrtToDataSet( fpgrtr );
                        }
                        _freePprGrpTrLs.Add( fpgrtr );

                        //�����A�\�[�g���������l���畡��
                        if ( mode == 0 )
                        {
                            //-- �V�����C���X�^���X������āA���e���R�s�[ ------------------
                            List<FrePprECnd> frePprECndLs = new List<FrePprECnd>();
                            List<FrePprSrtO> frePprSrtOLs = new List<FrePprSrtO>();

                            FrePprECnd[] frePprECnds = new FrePprECnd[((List<FrePprECnd>)_frePprECndLsHt[Generate_FrePprGrTr_Key( fppset )]).Count];
                            FrePprSrtO[] frePprSrtOs = new FrePprSrtO[((List<FrePprSrtO>)_frePprSrtOLsHT[Generate_FrePprGrTr_Key( fppset )]).Count];

                            ((List<FrePprECnd>)_frePprECndLsHt[Generate_FrePprGrTr_Key( fppset )]).CopyTo( frePprECnds );
                            ((List<FrePprSrtO>)_frePprSrtOLsHT[Generate_FrePprGrTr_Key( fppset )]).CopyTo( frePprSrtOs );
                            foreach ( FrePprECnd frePprECnd in frePprECnds )
                            {
                                FrePprECnd ecnd = (FrePprECnd)DBAndXMLDataMergeParts.CopyPropertyInClass( frePprECnd, typeof( FrePprECnd ) );
                                frePprECndLs.Add( ecnd );
                            }
                            foreach ( FrePprSrtO frePprSrtO in frePprSrtOs )
                            {
                                FrePprSrtO srtO = (FrePprSrtO)DBAndXMLDataMergeParts.CopyPropertyInClass( frePprSrtO, typeof( FrePprSrtO ) );
                                frePprSrtOLs.Add( srtO );
                            }
                            _frePprECndLsHt[Generate_FrePprGrTr_Key( fpgrtr )] = frePprECndLs;
                            _frePprSrtOLsHT[Generate_FrePprGrTr_Key( fpgrtr )] = frePprSrtOLs;
                        }
                    }
                    else
                    {
                        fpgrtr.PrtPprUserDerivNoCmt = "���_�E�����[�h";
                        fpgrtr.FileHeaderGuid = Guid.Empty;
                        FreeSeetPrtToDataSet( fpgrtr );
                    }
                }
            }
            return status;
        }
        #endregion

        #region �������
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="frePprGrTr">���R���[�O���[�v�U��</param>
        /// <param name="printmode">1�F�ʏ����A3�F�o�b�`���</param>
        /// <returns>�X�e�[�^�X</returns>
        private int PrintProc( FrePprGrTr frePprGrTr, int printmode )
        {
            _printInfo = new SFANL08205C();                         //������p�����[�^
            FrePrtPSet frePrtPSet = null;                           //����p�󎚈ʒu���N���X
            List<FrePprECnd> frePprECndLs = new List<FrePprECnd>(); //��������
            string errMsg;      //�������͗p�G���[���b�Z�[�W
            Control errCtl;      //�������͗p�G���[�R���g���[��

            if ( frePprGrTr == null )
            {
                if ( printmode == 1 )
                {
                    TMessageBox( emErrorLevel.ERR_LEVEL_EXCLAMATION, "����Ώۂ�����܂���", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                }
                return -1;
            }

            //���o�������L���b�V������߂�
            if ( _frePprECndLsHt.ContainsKey( Generate_FrePprGrTr_Key( frePprGrTr ) ) )
            {
                frePprECndLs = (List<FrePprECnd>)_frePprECndLsHt[Generate_FrePprGrTr_Key( frePprGrTr )];
            }

            //�󎚈ʒu�N���X�擾
            frePrtPSet = GetFrePrtPSetCash( frePprGrTr.OutputFormFileName, frePprGrTr.UserPrtPprIdDerivNo );

            //�ʏ����̎� {�o�b�`����̎��͎��O�ɍs���Ă���}
            if ( (printmode == 1) && (frePrtPSet != null) )
            {
                //���o�����擾
                _extCdtForm.GetFrePprECndList( ref frePprECndLs );

                //�����̓��̓`�F�b�N
                if ( !_extCdtForm.InputCheck( frePprECndLs, out errMsg, out errCtl, true ) )
                {
                    TMessageBox( emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                    errCtl.Focus();
                    return -1;
                }
                //��ٰ�ߖ��̌����� 2008.03.18 ADD ======================== START
                //switch (frePrtPSet.PrintPaperDivCd)
                //{
                //    case 1: //�������[
                //        {
                if ( SFANL08235CH.Check_ECnd_DaillyReport( frePprECndLs, out errMsg ) != 0 )
                {
                    TMessageBox( emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                    return -1;
                }
                //            break;
                //        }
                //}
                //��ٰ�ߖ��̌����� 2008.03.18 ADD ======================== END
            }



            //�ʒu��񂪂Ȃ�������
            if ( frePrtPSet == null )
            {
                // �ʏ����̂Ƃ��������b�Z�[�W�\��
                if ( printmode == 1 )
                {
                    if ( string.IsNullOrEmpty( frePprGrTr.DisplayName ) )
                    {
                        TMessageBox( emErrorLevel.ERR_LEVEL_EXCLAMATION, "����Ώۂ�����܂���", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                    }
                    else
                    {
                        TMessageBox( emErrorLevel.ERR_LEVEL_EXCLAMATION, frePprGrTr.DisplayName + "�̈󎚈ʒu�f�[�^������܂���", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                    }
                }
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            //����p�����[�^���Z�b�g
            _printInfo.InportFrePrtPSet( frePrtPSet, _enterpriseCode, "SFANL08201U", frePprECndLs, _frePprECndDLs, false );

            //�\�[�g���ʎ擾
            if ( _frePprSrtOLsHT.ContainsKey( Generate_FrePprGrTr_Key( frePprGrTr ) ) )
            {
                _printInfo.sortOdrLs = (List<FrePprSrtO>)_frePprSrtOLsHT[Generate_FrePprGrTr_Key( frePprGrTr )];
            }

            //���_���Z�b�g
            if ( _isOptSection )
            {
                if ( _printInfo.sectionNameLs == null ) _printInfo.sectionNameLs = new Dictionary<string, string>();
                for ( int i = 0; i < this._secInfoAcs.SecInfoSetList.Length; i++ )
                {
                    _printInfo.sectionNameLs[this._secInfoAcs.SecInfoSetList[i].SectionCode.Trim()] = this._secInfoAcs.SecInfoSetList[i].SectionGuideNm.Trim();
                }

                _printInfo.selectSecCds = _selectSecCds;
                _printInfo.sectionOptionDiv = true;
            }
            else
            {
                _printInfo.sectionOptionDiv = false;
            }
            // ���_��ʃR�[�h
            _printInfo.sectionKindCd = AddUpCd_UOptionSet.CheckedIndex + 1;
            // �S�Ћ敪
            _printInfo.AllSectionCodeDiv = _allSectionDiv;
            // �v���p�e�B�Z�b�g
            _printDialog.PrintInfo = _printInfo;

            // ���[�I���K�C�h
            if ( printmode == 1 )
            {
                if ( _printDialog.PinrtDlgShow( this ) == DialogResult.OK )
                {
                    //�ŏI����������L�^
                    LastPrtTime lastTime = _lastPrtTimeAcs.FindLastPrtTime( _lastTimes, frePprGrTr );
                    if ( lastTime != null )
                    {
                        _lastTimes.Remove( lastTime );
                    }
                    _lastPrtTimeAcs.SetLastPrtTime( out lastTime, frePprGrTr );
                    _lastTimes.Add( lastTime );
                    SetPrtTime( frePprGrTr.FreePrtPprGroupCd, frePprGrTr.TransferCode, lastTime.lastPrtTime );
                    FreePprPrt_Grid.Refresh();
                }
            }
            else if ( printmode == 3 )
            {
                if ( _printDialog.BatchPrint() == 0 )
                {
                    //�ŏI����������L�^
                    LastPrtTime lastTime = _lastPrtTimeAcs.FindLastPrtTime( _lastTimes, frePprGrTr );
                    if ( lastTime != null )
                    {
                        _lastTimes.Remove( lastTime );
                    }
                    _lastPrtTimeAcs.SetLastPrtTime( out lastTime, frePprGrTr );
                    _lastTimes.Add( lastTime );
                    SetPrtTime( frePprGrTr.FreePrtPprGroupCd, frePprGrTr.TransferCode, lastTime.lastPrtTime );
                    FreePprPrt_Grid.Refresh();
                }
            }

            // ����_�C�A���O�N��
            if ( _printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN || _printInfo.status == (int)ConstantManagement.DB_Status.ctDB_EOF )
            {
                // �ʏ����̂Ƃ��������b�Z�[�W
                if ( printmode == 1 )
                {
                    TMessageBox( emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                }
            }
            return _printInfo.status;
        }
        #endregion

        #region 1�����
        /// <summary>
        /// �_�C�A���O�\��1�����
        /// </summary>
        /// <returns></returns>
        private int Print( FrePprGrTr frePprGrTr )
        {
            return PrintProc( frePprGrTr, 1 );
        }
        #endregion

        #region �o�b�`�������
        /// <summary>
        /// �_�C�A���O��\���o�b�`���
        /// </summary>
        /// <returns></returns>
        private int BatchPrint( FrePprGrTr frePprGrTr )
        {
            return PrintProc( frePprGrTr, 3 );
        }
        #endregion

        #region ���o�����L���b�V���X�V����
        /// <summary>
        /// ���o�����̃L���b�V���X�V����
        /// </summary>
        /// <returns></returns>
        private int UpdateFrePprECndLsCash()
        {
            FrePprGrTr frePprGrTr;
            List<FrePprECnd> frePprECndLs = new List<FrePprECnd>(); //��������

            try
            {
                //�I������Ă���U�֏����擾
                if ( GetActiveFrePprGrTr( out frePprGrTr ) != 0 )
                {
                    return -1;
                }
                //���_�E�����[�h�f�[�^
                if ( frePprGrTr.FileHeaderGuid == Guid.Empty )
                {
                    return -1;
                }

                //�L���b�V������f�[�^��߂�
                if ( _frePprECndLsHt.ContainsKey( Generate_FrePprGrTr_Key( frePprGrTr ) ) )
                {
                    frePprECndLs = (List<FrePprECnd>)_frePprECndLsHt[Generate_FrePprGrTr_Key( frePprGrTr )];
                    //���o�����擾(��ʏ��ŏ㏑��)
                    _extCdtForm.GetFrePprECndList( ref frePprECndLs );
                    //���o�������L���b�V���ɖ߂�
                    _frePprECndLsHt[Generate_FrePprGrTr_Key( frePprGrTr )] = frePprECndLs;
                }
                else
                {
                    return 4;
                }
            }
            catch ( Exception ex )
            {
                TMessageBox( emErrorLevel.ERR_LEVEL_STOP, ex.Message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                return -1;
            }
            return 0;

        }
        #endregion

        #region Name�w��R���g���[���擾����
        /// <summary>
        /// Name�w��ŃR���g���[�����擾
        /// </summary>
        /// <param name="hParent"></param>
        /// <param name="stName"></param>
        /// <param name="findControl"></param>
        private void FindControl( Control hParent, string stName, ref Control findControl )
        {
            // hParent ���̂��ׂẴR���g���[����񋓂���
            foreach ( Control hControl in hParent.Controls )
            {
                // �񋓂����R���g���[���ɃR���g���[�����܂܂�Ă���ꍇ�͍ċA�Ăяo������
                if ( hControl.HasChildren )
                {
                    Control hFindControl = null;
                    FindControl( hControl, stName, ref hFindControl );
                    // �ċA�Ăяo����ŃR���g���[�������������ꍇ�͂��̂܂ܕԂ�
                    if ( hFindControl != null )
                    {
                        findControl = hFindControl;
                    }
                }

                // �R���g���[���������v�����ꍇ�͂��̃R���g���[���̃C���X�^���X��Ԃ�
                if ( hControl.Name == stName )
                {
                    findControl = hControl;
                }
            }
            findControl = null;
        }
        #endregion

        // -- �O���[�v����n ---------------------------

        #region DataSet�\�z����
        private void DataSetColumnConstruction()
        {
            //-- ���R���[�O���[�v -------------------------------------
            DataTable freeStGrTable = new DataTable( CT_FREE_PPR_GR );
            // �O���[�v�R�[�h
            freeStGrTable.Columns.Add( CT_FREE_PPR_GrCd, typeof( Int32 ) );
            // �O���[�v����
            freeStGrTable.Columns.Add( CT_FREE_PPR_GrNm, typeof( string ) );
            // GUID
            freeStGrTable.Columns.Add( CT_FREE_PPR_GUID, typeof( Guid ) );
            // �X�V���t
            freeStGrTable.Columns.Add( CT_FREE_PPR_UPDT, typeof( DateTime ) );
            // �쐬���t
            freeStGrTable.Columns.Add( CT_FREE_PPR_CRDT, typeof( DateTime ) );
            //DataSet��Add
            this._freeSheetGrDS.Tables.Add( freeStGrTable );

            //-- ���R���[����Ώ�(�U��) ------------------------------------
            DataTable freeStPrtTable = new DataTable( CT_FREE_PPR_PRT );
            //�O���[�v�R�[�h
            freeStPrtTable.Columns.Add( CT_FREE_PPR_GrCd, typeof( Int32 ) );
            //�\������ 
            freeStPrtTable.Columns.Add( CT_FREE_PPR_DspOdr, typeof( Int32 ) );
            //�U�փR�[�h
            freeStPrtTable.Columns.Add( CT_FREE_PPR_TrsCd, typeof( Int32 ) );
            //�o�͖���
            freeStPrtTable.Columns.Add( CT_FREE_PPR_PrtNm, typeof( string ) );
            //�R�����g
            freeStPrtTable.Columns.Add( CT_FREE_PPR_USRComment, typeof( string ) );
            //�ŏI�������
            freeStPrtTable.Columns.Add( CT_FREE_PPR_LstPrtDt, typeof( string ) );
            //���[�U�[���[ID�}�ԍ� 
            freeStPrtTable.Columns.Add( CT_FREE_PPR_DerivNo, typeof( Int32 ) );
            //�o�̓t�@�C����
            freeStPrtTable.Columns.Add( CT_FREE_PPR_OFrmFilNm, typeof( string ) );
            // GUID
            freeStPrtTable.Columns.Add( CT_FREE_PPR_GUID, typeof( Guid ) );
            // �X�V���t
            freeStPrtTable.Columns.Add( CT_FREE_PPR_UPDT, typeof( DateTime ) );
            // �쐬���t
            freeStPrtTable.Columns.Add( CT_FREE_PPR_CRDT, typeof( DateTime ) );
            //DataSet��Add
            this._freeSheetPrtDS.Tables.Add( freeStPrtTable );
        }
        #endregion

        #region ���R���[�O���[�v�o�^����
        private bool RegistFreePprGr( FreePprGrp frePprGrp )
        {
            string errMsg;

            // -- A�N���X���g���ēo�^���ʂ�OK�Ȃ�UI�X�V ------------------------------ 
            int status = 0;
            status = this._frePprGrAcs.WriteFreePprGrp( ref frePprGrp, out errMsg );
            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int indexBuf = FreePprGr_Grid.ActiveRow.Index;
                        SetDataSource( 0 );
                        FreePprGr_Grid.Rows[indexBuf].Activate();
                        GroupFiltering( frePprGrp.FreePrtPprGroupCd );
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show( Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_INFO,
                            PGID, "���̃O���[�v�R�[�h�͂��łɓo�^����Ă��܂�", status, MessageBoxButtons.OK );
                        return false;
                    }
                default:
                    {
                        if ( ExclusiveControl( status ) == false )
                        {
                            return false;
                        }
                        TMsgDisp.Show( this, Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
                            PGID, "���R���[�O���[�v�o�^", "RegistFreePprGr", TMsgDisp.OPE_UPDATE,
                            "�o�^�Ɏ��s���܂����B" + errMsg, status,
                            "SFANL08221A", MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                        return false;
                    }
            }
            return true;
        }
        #endregion

        #region ���R���[�O���[�v �� DataSet
        /// <summary>
        /// ���R���[�O���[�v �� �f�[�^�Z�b�g�W�J
        /// </summary>
        /// <param name="freePprGrp">���R���[�O���[�v�N���X</param>
        /// <param name="index">�f�[�^�Z�b�g�C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���R���[�O���[�v���f�[�^�Z�b�g�֓W�J���܂�</br>
        /// <br>Programmer : 22011 �����@���l</br>
        /// <br>Date       : 2007.03.28</br>
        /// </remarks>
        private int FreePprGrToDataSet( FreePprGrp freePprGrp, int index )
        {
            DataTable freeShGrTable = this._freeSheetGrDS.Tables[CT_FREE_PPR_GR];

            // �V�K�Ƃ��čs�ǉ�����
            if ( (index < 0) || (freeShGrTable.Rows.Count <= index) )
            {
                // �V�K�Ƃ��čs�ǉ�����
                DataRow dataRow = freeShGrTable.NewRow();
                freeShGrTable.Rows.Add( dataRow );
                index = freeShGrTable.Rows.Count - 1;
            }
            freeShGrTable.Rows[index][CT_FREE_PPR_GrCd] = freePprGrp.FreePrtPprGroupCd;
            freeShGrTable.Rows[index][CT_FREE_PPR_GrNm] = freePprGrp.FreePrtPprGroupNm;
            freeShGrTable.Rows[index][CT_FREE_PPR_GUID] = freePprGrp.FileHeaderGuid;
            freeShGrTable.Rows[index][CT_FREE_PPR_UPDT] = freePprGrp.UpdateDateTime;
            freeShGrTable.Rows[index][CT_FREE_PPR_CRDT] = freePprGrp.CreateDateTime;
            return 0;
        }
        #endregion

        #region ���R���[�O���[�v�폜����
        private int DeleteFrePprGrp()
        {
            string errMsg;
            int index = 0;
            int status = 0;
            FreePprGrp frePprGrp = null;
            ArrayList frePprGrTrList;

            // �A�N�e�B�u�s�̃f�[�^���擾
            status = GetActiveFrePprGrp( out frePprGrp, out index );
            if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                return status;

            // �S�O���[�v��������L�����Z��
            if ( frePprGrp.FreePrtPprGroupCd == 0 )
            {
                TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_INFO,        // �G���[���x��
                "SFANL08201UA", 						    // �A�Z���u���h�c�܂��̓N���X�h�c
                "�S�O���[�v�͍폜�ł��܂���", 		// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OK,
                MessageBoxDefaultButton.Button1 );   // �\������{�^��
                return status;
            }

            // ���_�E�����[�h�̖��ׂ��Ȃ����`�F�b�N
            string msgPlus = string.Empty;
            foreach ( DataRowView dr in _freeSheetPrtDV )
            {
                if ( frePprGrp.FreePrtPprGroupCd == (int)dr[CT_FREE_PPR_GrCd] )
                    if ( (Guid)dr[CT_FREE_PPR_GUID] == Guid.Empty )
                    {
                        msgPlus = "���_�E�����[�h�̈���Ώۂ��܂ރO���[�v��\n" + "�폜���悤�Ƃ��Ă��܂��B\n\n";
                        break;
                    }
            }

            // ���S�폜�m�F
            DialogResult result = TMsgDisp.Show(
                this, 								        // �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION,         // �G���[���x��
                "SFANL08201UA", 						    // �A�Z���u���h�c�܂��̓N���X�h�c
                msgPlus + "[" + frePprGrp.FreePrtPprGroupNm + "]���폜���܂��B" + "\r\n" +
                "��낵���ł����H", 				        // �\�����郁�b�Z�[�W
                0, 									        // �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2 );           // �\������{�^��

            if ( result == DialogResult.OK )
            {
                // ���׎擾
                this._frePprGrAcs.SearchAllFreePprGrTr( out frePprGrTrList, LoginInfoAcquisition.EnterpriseCode, frePprGrp.FreePrtPprGroupCd );

                //���R���[�O���[�v�Ɗ֘A����O���[�v�U�ւ����S�폜
                status = this._frePprGrAcs.DeleteFreePprGrpAndGrTr( frePprGrp, frePprGrTrList, out errMsg );
                switch ( status )
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            //�ŏI������ԍ폜
                            _lastTimes.RemoveAll( delegate( LastPrtTime ptm ) { return (ptm.freePrtPprGroupCd == frePprGrp.FreePrtPprGroupCd); } );
                            //�U�փL���b�V���폜
                            _freePprGrpTrLs.RemoveAll( delegate( FrePprGrTr grtr )
                            {
                                if ( (grtr.FreePrtPprGroupCd == frePprGrp.FreePrtPprGroupCd) )
                                    return true;
                                else
                                    return false;
                            } );


                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            ExclusiveControl( status );
                            return status;
                        }
                    default:
                        {
                            // �����폜
                            TMsgDisp.Show(
                                this, 								// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                                "SFANL08201UA", 						    // �A�Z���u���h�c�܂��̓N���X�h�c
                                "���R���[�O���[�v�ݒ�", 			// �v���O��������
                                "DeleteFrePprGrp", 				    // ��������
                                TMsgDisp.OPE_DELETE, 				// �I�y���[�V����
                                "�폜�Ɏ��s���܂����B" + errMsg, 		// �\�����郁�b�Z�[�W
                                status, 							// �X�e�[�^�X�l
                                this._frePprGrAcs, 					// �G���[�����������I�u�W�F�N�g
                                MessageBoxButtons.OK, 				// �\������{�^��
                                MessageBoxDefaultButton.Button1 );	// �����\���{�^��

                            return status;
                        }
                }

                //�f�[�^�e�[�u���̍X�V
                this._freeSheetGrDS.Tables[CT_FREE_PPR_GR].DefaultView[index].Delete();

                //�P�s��̃O���[�v�ōĕ`��
                FreePprGr_Grid.Rows[index - 1].Activate();
                FrePPrGroupChange( (int)(this._freeSheetGrDS.Tables[CT_FREE_PPR_GR].DefaultView[index - 1].Row[CT_FREE_PPR_GrCd]) );
            }
            else
            {
                //�폜�{�^���Ƀt�H�[�J�X���ׂ��H
            }
            return (Int32)ConstantManagement.DB_Status.ctDB_NORMAL;

        }

        #endregion

        #region �O���b�h��T�ϐݒ�
        private void SetGridColAppearance()
        {
            // �\���ݒ�
            FreePprGr_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_GrCd].Hidden = false;
            FreePprGr_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_GrNm].Hidden = false;
            FreePprGr_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_GUID].Hidden = true;
            FreePprGr_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_UPDT].Hidden = true;
            FreePprGr_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_CRDT].Hidden = true;

            // �\���ݒ�
            FreePprPrt_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_GrCd].Hidden = true;
            FreePprPrt_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_DspOdr].Hidden = false;
            FreePprPrt_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_TrsCd].Hidden = true;
            FreePprPrt_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_PrtNm].Hidden = false;
            FreePprPrt_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_LstPrtDt].Hidden = false;
            FreePprPrt_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_USRComment].Hidden = false;
            FreePprPrt_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_DerivNo].Hidden = true;
            FreePprPrt_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_OFrmFilNm].Hidden = true;
            FreePprPrt_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_GUID].Hidden = true;
            FreePprPrt_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_UPDT].Hidden = true;
            FreePprPrt_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_CRDT].Hidden = true;
        }
        #endregion

        #region �I�𒆎��R���[�O���[�v�̏��擾
        /// <summary>
        /// �I������Ă��鎩�R���[�̃O���[�v�R�[�h��Ԃ��܂�
        /// </summary>
        /// <returns>�O���[�v�R�[�h(���I������0��Ԃ�)</returns>
        private Int32 GetSelectedGrCode()
        {
            if ( FreePprGr_Grid.ActiveRow != null && FreePprGr_Grid.ActiveRow.Index >= 0 )
            {
                if ( _freeSheetGrDS.Tables[CT_FREE_PPR_GR].DefaultView[FreePprGr_Grid.ActiveRow.Index][CT_FREE_PPR_GrCd] != null )
                {
                    return (int)_freeSheetGrDS.Tables[CT_FREE_PPR_GR].DefaultView[FreePprGr_Grid.ActiveRow.ListIndex][CT_FREE_PPR_GrCd];
                }

            }
            return 0;
        }

        /// <summary>
        /// ���ݑI������Ă���O���[�v�̏����擾���܂�
        /// </summary>
        /// <param name="frePprGrp">���R���[�O���[�v�N���X</param>
        /// <param name="index">�f�[�^�Z�b�g�̃C���f�b�N�X</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetActiveFrePprGrp( out FreePprGrp frePprGrp, out int index )
        {
            // �������[����
            if ( FreePprGr_Grid.Rows.Count <= 0 )
            {
                frePprGrp = new FreePprGrp();
                index = -1;
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            frePprGrp = new FreePprGrp();

            //���݃A�N�e�B�u�ȍs���擾
            index = FreePprGr_Grid.ActiveRow.Index;
            if ( index < 0 ) return -1;

            DataRowView newDr = _freeSheetGrDS.Tables[CT_FREE_PPR_GR].DefaultView[index];
            frePprGrp.FreePrtPprGroupCd = (Int32)newDr[CT_FREE_PPR_GrCd];
            frePprGrp.FreePrtPprGroupNm = (string)newDr[CT_FREE_PPR_GrNm];
            frePprGrp.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            frePprGrp.FileHeaderGuid = (Guid)newDr[CT_FREE_PPR_GUID];
            frePprGrp.UpdateDateTime = (DateTime)newDr[CT_FREE_PPR_UPDT];
            frePprGrp.CreateDateTime = (DateTime)newDr[CT_FREE_PPR_CRDT];
            return 0;
        }
        #endregion

        #region ���R���[�O���[�v �� �f�[�^�Z�b�g�W�J
        /// <summary>
        /// ���R���[�O���[�v �� �f�[�^�Z�b�g�W�J(�V�K�o�^��p)
        /// </summary>
        /// <param name="freePprGrp">���R���[�O���[�v</param>
        private int FreePprGrToDataSet( FreePprGrp freePprGrp )
        {
            return FreePprGrToDataSet( freePprGrp, -1 );
        }
        #endregion

        #region �S�O���[�v�A�N�e�B�x�[�e�B�b�h
        /// <summary>
        /// ���R���[�O���[�v�O���b�h�̑S�O���[�v�s���A�N�e�B�u��
        /// </summary>
        private void AllFreePprGroupActivated()
        {
            if ( FreePprGr_Grid.Rows.Count > 0 )
            {
                FreePprGr_Grid.Rows[0].Activate();
            }
        }
        #endregion

        #region DataTableClear����
        /// <summary>
        /// �O���b�h�p�f�[�^�e�[�u���N���A
        /// </summary>
        private void ClearGroupDataTable()
        {
            this._freeSheetGrDS.Tables[CT_FREE_PPR_GR].Clear();
        }
        #endregion

        // -- ���א��� ---------------------------------

        #region DataTableClear����
        /// <summary>
        /// �O���b�h�pDataTable�N���A����
        /// </summary>
        /// <returns></returns>
        public void ClearDataTable()
        {
            this._freeSheetPrtDS.Tables[CT_FREE_PPR_PRT].Clear();
        }
        #endregion

        #region ���R���[�O���[�v�U�֓o�^����
        private bool RegistFreeShetGrTr( FrePprGrTr trgFrePprGrTr )
        {
            int status = 0;
            string errMsg;
            int indexBuf;

            // �O���[�v���ł̏d���`�F�b�N
            if ( trgFrePprGrTr.FreePrtPprGroupCd != 0 )
            {
                if ( trgFrePprGrTr.UpdateDateTime == DateTime.MinValue )  //�V�K�̎��̂�
                {
                    foreach ( FrePprGrTr grtr in _freePprGrpTrLs )
                    {
                        if ( grtr.FreePrtPprGroupCd == trgFrePprGrTr.FreePrtPprGroupCd )
                        {
                            if ( grtr.OutputFormFileName == trgFrePprGrTr.OutputFormFileName )
                            {
                                if ( grtr.UserPrtPprIdDerivNo == trgFrePprGrTr.UserPrtPprIdDerivNo )
                                {
                                    TMsgDisp.Show( Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_INFO,
                                    PGID, "[" + trgFrePprGrTr.DisplayName + "]�͂��łɃO���[�v���ɓo�^����Ă��܂�", status, MessageBoxButtons.OK );
                                    _maintenanceDlg.FrePprSelect_Grid.Focus();
                                    return false;
                                }
                            }
                        }
                    }
                }
            }

            status = this._frePprGrAcs.WriteFrePprGrTr( ref trgFrePprGrTr, out errMsg );
            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if ( FreePprPrt_Grid.Rows.Count > 0 )
                            indexBuf = FreePprPrt_Grid.ActiveRow.Index;
                        else
                            indexBuf = 0;
                        SetDataSource( 2 );

                        //���o�����A�\�[�g���̃L���b�V�����쐬
                        List<FrePprECnd> frePprECndLs = new List<FrePprECnd>();
                        List<FrePprSrtO> frePprSrtOLs = new List<FrePprSrtO>();
                        FrePprECnd[] frePprECnds = new FrePprECnd[((List<FrePprECnd>)_frePprECndLsHt[Generate_FrePprGrTr_Init_Key( trgFrePprGrTr )]).Count];
                        FrePprSrtO[] frePprSrtOs = new FrePprSrtO[((List<FrePprSrtO>)_frePprSrtOLsHT[Generate_FrePprGrTr_Init_Key( trgFrePprGrTr )]).Count];

                        ((List<FrePprECnd>)_frePprECndLsHt[Generate_FrePprGrTr_Init_Key( trgFrePprGrTr )]).CopyTo( frePprECnds );
                        ((List<FrePprSrtO>)_frePprSrtOLsHT[Generate_FrePprGrTr_Init_Key( trgFrePprGrTr )]).CopyTo( frePprSrtOs );
                        foreach ( FrePprECnd frePprECnd in frePprECnds )
                        {
                            FrePprECnd ecnd = (FrePprECnd)DBAndXMLDataMergeParts.CopyPropertyInClass( frePprECnd, typeof( FrePprECnd ) );
                            frePprECndLs.Add( ecnd );
                        }
                        foreach ( FrePprSrtO frePprSrtO in frePprSrtOs )
                        {
                            FrePprSrtO srtO = (FrePprSrtO)DBAndXMLDataMergeParts.CopyPropertyInClass( frePprSrtO, typeof( FrePprSrtO ) );
                            frePprSrtOLs.Add( srtO );
                        }
                        _frePprECndLsHt[Generate_FrePprGrTr_Key( trgFrePprGrTr )] = frePprECndLs;
                        _frePprSrtOLsHT[Generate_FrePprGrTr_Key( trgFrePprGrTr )] = frePprSrtOLs;

                        FreePprPrt_Grid.Rows[indexBuf].Activate();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show( Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_INFO,
                            PGID, "[" + trgFrePprGrTr.DisplayName + "]�͂��łɓo�^����Ă��܂�", status, MessageBoxButtons.OK );
                        return false;
                    }
                default:
                    {
                        if ( ExclusiveControl( status ) == false )
                        {
                            return false;
                        }
                        TMsgDisp.Show( this, Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
                            PGID, "���R���[�O���[�v�U�֓o�^", "RegistFreeShetGrTr", TMsgDisp.OPE_UPDATE,
                            "�o�^�Ɏ��s���܂����B" + errMsg, status,
                            "SFANL08221A", MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                        return false;
                    }
            }
            return true;
        }
        #endregion

        #region ���R���[�O���[�v�U�֏��폜����
        private void DeleteFrePprGrTrData()
        {
            int status = 0;
            int index = 0;
            FrePprGrTr frePprGrTr = null;
            string errMsg;

            status = GetActiveFrePprGrTr( out frePprGrTr, out index );
            if ( status != 0 ) return;

            // �S�O���[�v��������L�����Z��
            if ( frePprGrTr.FreePrtPprGroupCd == 0 )
            {
                TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_INFO,        // �G���[���x��
                "SFANL08201U", 						    // �A�Z���u���h�c�܂��̓N���X�h�c
                "�S�O���[�v�̈���Ώۂ͍폜�ł��܂���", // �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OK,
                MessageBoxDefaultButton.Button1 );   // �\������{�^��
                return;
            }
            // ���S�폜�m�F
            DialogResult result = TMsgDisp.Show(
                this, 								    // �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                "SFANL08201U", 						        // �A�Z���u���h�c�܂��̓N���X�h�c
                "[" + frePprGrTr.DisplayName + "]������Ώۂ���폜���܂��B" + "\r\n" +
                "��낵���ł����H", 				    // �\�����郁�b�Z�[�W
                0, 									    // �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2 );		// �\������{�^��

            if ( result == DialogResult.OK )
            {
                status = this._frePprGrAcs.DeleteFrePprGrTr( ref frePprGrTr, out errMsg );
                switch ( status )
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            //�ŏI����������폜
                            LastPrtTime lastTime = _lastPrtTimeAcs.FindLastPrtTime( _lastTimes, frePprGrTr );
                            if ( lastTime != null )
                            {
                                _lastTimes.Remove( lastTime );
                            }
                            //�U�փL���b�V���폜
                            _freePprGrpTrLs.RemoveAll( delegate( FrePprGrTr grtr )
                            {
                                if ( (grtr.FreePrtPprGroupCd == frePprGrTr.FreePrtPprGroupCd) && (grtr.TransferCode == frePprGrTr.TransferCode) )
                                    return true;
                                else
                                    return false;
                            } );

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            ExclusiveControl( status );
                            return;
                        }
                    default:
                        {
                            // �����폜
                            TMsgDisp.Show(
                                this, 								// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                                "SFTKD09060U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                                "���R���[�O���[�v�U�֐ݒ�", 		// �v���O��������
                                "DeleteFrePprGrTrData", 		    // ��������
                                TMsgDisp.OPE_DELETE, 				// �I�y���[�V����
                                "�폜�Ɏ��s���܂����B" + errMsg, 		// �\�����郁�b�Z�[�W
                                status, 							// �X�e�[�^�X�l
                                this._frePprGrAcs, 					// �G���[�����������I�u�W�F�N�g
                                MessageBoxButtons.OK, 				// �\������{�^��
                                MessageBoxDefaultButton.Button1 );	// �����\���{�^��
                            return;
                        }
                }
                // �i���ׁj�폜��́A�t���[���Ƀf�[�^�𔽉f������
                _freeSheetPrtDV.Delete( index );
                //�폜�ɂ��A�s���S�ĂȂ��Ȃ����������ʍč\�z
                if ( FreePprPrt_Grid.Rows.FilteredInRowCount <= 0 )
                {
                    SetExtraCnditionFrom();
                }
                else
                {
                    FreePprPrt_Grid.Rows[0].Activate();
                }
            }
            else
            {
                //�폜�{�^���Ƀt�H�[�J�X���ׂ��H
            }
        }
        #endregion

        #region �O���b�h�t�B���^�����O
        /// <summary>
        /// ���׃O���b�h�������̃O���[�v�R�[�h�Ńt�B���^�����O���܂�
        /// </summary>
        /// <param name="groupCD">�O���[�v�R�[�h</param>
        private void GroupFiltering( int groupCD )
        {
            string filter;
            filter = CT_FREE_PPR_GrCd + " = " + groupCD.ToString();
            this._freeSheetPrtDV.RowFilter = filter;

            //�_�C�A���O�̃O���[�v�R�[�h���X�V
            _maintenanceDlg.GroupCode = groupCD;
        }
        #endregion

        #region ���׃O���b�h�A�N�e�B�x�[�g
        /// <summary>
        /// ���׃O���b�h�ɃA�N�e�B�u�s��ݒ肵�܂�
        /// </summary>
        /// <returns>status</returns>
        private int GridActivate()
        {
            if ( FreePprPrt_Grid.Rows.FilteredInRowCount <= 0 )
            {
                return -1;
            }
            else
                FreePprPrt_Grid.Rows.FirstVisibleCardRow.Activate();
            return 0;
        }

        /// <summary>
        /// ���׃O���b�h�ɃA�N�e�B�u�s��ݒ肵�܂�(�O���[�v�R�[�h�A�U�փR�[�h�w��)
        /// </summary>
        /// <param name="groupCd">���R���[�O���[�v�R�[�h</param>
        /// <param name="tranceCd">���R���[�O���[�v�U�փR�[�h</param>
        /// <returns>status</returns>
        private int GridActivate( int groupCd, int tranceCd )
        {
            int index = 0;

            if ( FreePprPrt_Grid.Rows.FilteredInRowCount <= 0 )
            {
                return -1;
            }

            foreach ( DataRowView dr in _freeSheetPrtDV )
            {
                if ( groupCd == (int)dr[CT_FREE_PPR_GrCd] )
                    if ( tranceCd == (int)dr[CT_FREE_PPR_TrsCd] )
                    {
                        //�I���s������
                        //foreach (UltraGridRow ugRow in FreePprPrt_Grid.Selected.Rows)
                        //{
                        //    ugRow.Selected = false;
                        //}
                        //�w�肳�ꂽ�s���A�N�e�B�x�[�g
                        FreePprPrt_Grid.Rows[index].Activate();
                        return 0;
                    }
                index++;
            }
            return 0;
        }
        #endregion

        #region �U�֏��擾
        /// <summary>
        /// ���ݑI������Ă��閾�ׂ̏����擾���܂�
        /// </summary>
        /// <param name="frePprGrTr">���R���[�O���[�v�U�փN���X</param>
        /// <param name="index">�f�[�^�Z�b�g�̃C���f�b�N�X</param>
        /// <returns>�X�e�[�^�X(0:����擾 ���̑�:���s)</returns>
        private int GetActiveFrePprGrTr( out FrePprGrTr frePprGrTr, out int index )
        {
            // �������[����
            if ( FreePprPrt_Grid.Rows.FilteredInRowCount <= 0 )
            {
                frePprGrTr = new FrePprGrTr();
                index = -1;
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            frePprGrTr = new FrePprGrTr();

            try
            {
                //���݃A�N�e�B�u�ȍs���擾
                index = FreePprPrt_Grid.ActiveRow.Index;
                DataRow newDr = _freeSheetPrtDV[index].Row;
                if ( newDr == null ) return -1;

                frePprGrTr.FreePrtPprGroupCd = (Int32)newDr[CT_FREE_PPR_GrCd];
                frePprGrTr.DisplayOrder = (Int32)newDr[CT_FREE_PPR_DspOdr];
                frePprGrTr.TransferCode = (Int32)newDr[CT_FREE_PPR_TrsCd];
                if ( newDr[CT_FREE_PPR_PrtNm] != DBNull.Value )
                    frePprGrTr.DisplayName = (string)newDr[CT_FREE_PPR_PrtNm];
                else
                    frePprGrTr.DisplayName = "";
                if ( newDr[CT_FREE_PPR_USRComment] != DBNull.Value )
                    frePprGrTr.PrtPprUserDerivNoCmt = (string)newDr[CT_FREE_PPR_USRComment];
                else
                    frePprGrTr.PrtPprUserDerivNoCmt = "";
                frePprGrTr.UserPrtPprIdDerivNo = (Int32)newDr[CT_FREE_PPR_DerivNo];
                if ( newDr[CT_FREE_PPR_OFrmFilNm] != DBNull.Value )
                    frePprGrTr.OutputFormFileName = (string)newDr[CT_FREE_PPR_OFrmFilNm];
                else
                    frePprGrTr.OutputFormFileName = "";
                frePprGrTr.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                frePprGrTr.FileHeaderGuid = (Guid)newDr[CT_FREE_PPR_GUID];
                frePprGrTr.UpdateDateTime = (DateTime)newDr[CT_FREE_PPR_UPDT];
                frePprGrTr.CreateDateTime = (DateTime)newDr[CT_FREE_PPR_CRDT];
            }
            catch
            {
                index = -1;
                return -1;
            }
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>
        /// ���ݑI������Ă��閾�ׂ̏����擾���܂�
        /// </summary>
        /// <param name="frePprGrTr">���R���[�O���[�v�U�փN���X</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetActiveFrePprGrTr( out FrePprGrTr frePprGrTr )
        {
            int indexdmy = 0;
            return GetActiveFrePprGrTr( out frePprGrTr, out indexdmy );
        }

        /// <summary>
        /// ���ݑI������Ă���O���[�v�̑S���׏����擾���܂�
        /// </summary>
        /// <param name="frePprGrTr">���R���[�O���[�v�U�փN���X�̔z��</param>
        /// <param name="groupCD">���R���[�O���[�v�R�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetGroupFrePprGrTr( out FrePprGrTr[] frePprGrTr, Int32 groupCD )
        {
            // �������[����
            if ( FreePprPrt_Grid.Rows.FilteredInRowCount <= 0 )
            {
                frePprGrTr = null;
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            frePprGrTr = new FrePprGrTr[FreePprPrt_Grid.Rows.FilteredInRowCount];
            Int32 index = 0;

            //���݃A�N�e�B�u�ȍs���擾
            foreach ( DataRowView newDrV in _freeSheetPrtDV )
            {
                if ( (Int32)newDrV.Row[CT_FREE_PPR_GrCd] == groupCD )
                {
                    frePprGrTr[index] = new FrePprGrTr();
                    frePprGrTr[index].FreePrtPprGroupCd = (Int32)newDrV.Row[CT_FREE_PPR_GrCd];
                    frePprGrTr[index].DisplayOrder = (Int32)newDrV.Row[CT_FREE_PPR_DspOdr];
                    frePprGrTr[index].TransferCode = (Int32)newDrV.Row[CT_FREE_PPR_TrsCd];
                    frePprGrTr[index].DisplayName = (string)newDrV.Row[CT_FREE_PPR_PrtNm];
                    frePprGrTr[index].PrtPprUserDerivNoCmt = (string)newDrV.Row[CT_FREE_PPR_USRComment];
                    frePprGrTr[index].UserPrtPprIdDerivNo = (Int32)newDrV.Row[CT_FREE_PPR_DerivNo];
                    frePprGrTr[index].OutputFormFileName = (string)newDrV.Row[CT_FREE_PPR_OFrmFilNm];
                    frePprGrTr[index].EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                    frePprGrTr[index].FileHeaderGuid = (Guid)newDrV.Row[CT_FREE_PPR_GUID];
                    frePprGrTr[index].UpdateDateTime = (DateTime)newDrV.Row[CT_FREE_PPR_UPDT];
                    frePprGrTr[index].CreateDateTime = (DateTime)newDrV.Row[CT_FREE_PPR_CRDT];
                    index++;
                }
            }
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }
        #endregion

        #region ���R���[�O���[�v �� �f�[�^�Z�b�g�W�J����
        #region ���R���[����Ώ� �� DataSet
        /// <summary>
        /// ���R���[�O���[�v�U�� �� �f�[�^�Z�b�g�W�J
        /// </summary>
        /// <param name="frePprGrTr">���R���[�O���[�v�U�փN���X</param>
        /// <param name="index">�f�[�^�Z�b�g�C���f�b�N�X</param>
        /// <param name="lastPrtDate">�ŏI�������</param>
        /// <remarks>
        /// <br>Note       : ���R���[�O���[�v�U�ւ��f�[�^�Z�b�g�֓W�J���܂�</br>
        /// <br>Programmer : 22011 �����@���l</br>
        /// <br>Date       : 2007.03.28</br>
        /// </remarks>
        private int FreeSeetPrtToDataSet( FrePprGrTr frePprGrTr, Int32 index, DateTime lastPrtDate )
        {
            DataTable freeShPrtTable = this._freeSheetPrtDS.Tables[CT_FREE_PPR_PRT];

            // �V�K�Ƃ��čs�ǉ�����
            if ( (index < 0) || (freeShPrtTable.Rows.Count <= index) )
            {
                // �V�K�Ƃ��čs�ǉ�����
                DataRow dataRow = freeShPrtTable.NewRow();
                freeShPrtTable.Rows.Add( dataRow );
                index = freeShPrtTable.Rows.Count - 1;
            }

            freeShPrtTable.Rows[index][CT_FREE_PPR_GrCd] = frePprGrTr.FreePrtPprGroupCd;
            freeShPrtTable.Rows[index][CT_FREE_PPR_DspOdr] = frePprGrTr.DisplayOrder;
            freeShPrtTable.Rows[index][CT_FREE_PPR_TrsCd] = frePprGrTr.TransferCode;
            freeShPrtTable.Rows[index][CT_FREE_PPR_PrtNm] = frePprGrTr.DisplayName;
            if ( lastPrtDate != DateTime.MinValue )
                freeShPrtTable.Rows[index][CT_FREE_PPR_LstPrtDt] = lastPrtDate.ToString();
            freeShPrtTable.Rows[index][CT_FREE_PPR_USRComment] = frePprGrTr.PrtPprUserDerivNoCmt;
            freeShPrtTable.Rows[index][CT_FREE_PPR_DerivNo] = frePprGrTr.UserPrtPprIdDerivNo;
            freeShPrtTable.Rows[index][CT_FREE_PPR_OFrmFilNm] = frePprGrTr.OutputFormFileName;
            freeShPrtTable.Rows[index][CT_FREE_PPR_GUID] = frePprGrTr.FileHeaderGuid;
            freeShPrtTable.Rows[index][CT_FREE_PPR_UPDT] = frePprGrTr.UpdateDateTime;
            freeShPrtTable.Rows[index][CT_FREE_PPR_CRDT] = frePprGrTr.CreateDateTime;

            return 0;
        }
        #endregion


        /// <summary>
        /// ���׃O���b�h�ɃA�N�e�B�u�s��ݒ肵�܂�(�O���[�v�R�[�h�A�U�փR�[�h�w��)
        /// </summary>
        /// <param name="groupCd">���R���[�O���[�v�R�[�h</param>
        /// <param name="tranceCd">���R���[�O���[�v�U�փR�[�h</param>
        /// <param name="prtDate">���R���[</param>
        /// <returns>status</returns>
        private int SetPrtTime( int groupCd, int tranceCd, DateTime prtDate )
        {
            if ( FreePprPrt_Grid.Rows.FilteredInRowCount <= 0 )
            {
                return -1;
            }


            foreach ( DataRowView dr in _freeSheetPrtDV )
            {
                if ( groupCd == (int)dr[CT_FREE_PPR_GrCd] )
                    if ( tranceCd == (int)dr[CT_FREE_PPR_TrsCd] )
                    {
                        //�w�肳�ꂽ�s���A�N�e�B�x�[�g
                        dr[CT_FREE_PPR_LstPrtDt] = prtDate.ToString();
                        return 0;
                    }
            }
            return 0;
        }


        /// <summary>
        /// ���R���[�O���[�v�U�� �� �f�[�^�Z�b�g�W�J(�V�K�o�^�p)
        /// </summary>
        /// <param name="frePprGrTr">���R���[�O���[�v�U�փN���X</param>
        /// <param name="lastPrtDate">�ŏI�������</param>
        private int FreeSeetPrtToDataSet( FrePprGrTr frePprGrTr, DateTime lastPrtDate )
        {
            return FreeSeetPrtToDataSet( frePprGrTr, -1, lastPrtDate );
        }

        /// <summary>
        /// ���R���[�O���[�v�U�� �� �f�[�^�Z�b�g�W�J(�V�K�o�^�p)
        /// </summary>
        /// <param name="frePprGrTr">���R���[�O���[�v�U�փN���X</param>
        private int FreeSeetPrtToDataSet( FrePprGrTr frePprGrTr )
        {
            return FreeSeetPrtToDataSet( frePprGrTr, -1, new DateTime() );
        }


        #region 1�s�ڂ��A�N�e�B�u�ɂ��܂�
        /// <summary>
        /// 1�s�ڂ��A�N�e�B�u��
        /// </summary>
        public void FirstRowActivated()
        {
            if ( FreePprPrt_Grid.Rows.Count > 0 )
            {
                FreePprPrt_Grid.Rows[0].Activate();
            }
        }
        #endregion

        #endregion

        #endregion

        // ===================================================================================== //
        // �R���g���[���C�x���g
        // ===================================================================================== //
        #region Control Event
        /// <summary>
        /// ��ʃ��[�h�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note        : ��ʂ����[�h���ꂽ�ہA��������C�x���g�ł��B</br>
        /// <br>Programmer  : 22011 Kashihara</br>
        /// <br>Date        : 2006.01.19</br>
        /// </remarks>
        private void SFANL08201UA_Load( object sender, System.EventArgs e )
        {
            // ��ʏ����\��
            this.InitialScreenSetting();

            //�󎚈ʒu�f�[�^���Ȃ��Ƃ�:���b�Z�[�W�\����I��
            if ( _frePrtPSetLs.Count <= 0 )
            {
                this.Visible = false;
                throw new FreeSheetStartCancelException( "���̒[���ɒ��[�̈󎚈ʒu��񂪂���܂���\n�󎚈ʒu���̃_�E�����[�h���K�v�ł�" );
            }
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Print_Button_Click( object sender, EventArgs e )
        {
            FrePprGrTr frePprGrTr = null;
            GetActiveFrePprGrTr( out frePprGrTr );
            Print( frePprGrTr );�@// ���
        }

        /// <summary>
        /// �\�[�g���ύX����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrderCng_Button_Click( object sender, EventArgs e )
        {
            //�\�[�g���ʐݒ�t�H�[���N��
            SetSortOrderForm();
        }



        /// <summary>
        /// �t�H�[���I�����ɔ������܂�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SFANL08201UA_FormClosing( object sender, FormClosingEventArgs e )
        {
            //�ŏI��������������o��
            _lastPrtTimeAcs.Write( _lastTimes );

            if ( _maintenanceDlg != null )
            {
                _maintenanceDlg.CanClose = true;
                _maintenanceDlg.Dispose();
            }
        }

        /// <summary>
        /// �O���[�v�̃c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupToolbarsManager_ToolClick( object sender, ToolClickEventArgs e )
        {
            if ( e.Tool.Key == CT_ROW_ADD )
            {
                _maintenanceDlg.ShowGroupDlg();
            }
            else if ( e.Tool.Key == CT_ROW_DELETE )
            {
                DeleteFrePprGrp();
            }
        }

        /// <summary>
        /// �O���[�v�O���b�h�̃��E���_�u���N���b�N�����Ƃ��ɔ������܂�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FreePprGr_Grid_DoubleClickRow( object sender, DoubleClickRowEventArgs e )
        {
            if ( Convert.ToInt32( e.Row.Cells[CT_FREE_PPR_GrCd].Value ) == 0 )
            {   //�S�O���[�v�Ȃ�
                TMsgDisp.Show( Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_INFO,
                PGID, "�S�O���[�v�͕ύX�ł��܂���", 0, MessageBoxButtons.OK );
            }
            else
            {
                int index;
                FreePprGrp frepprgr = new FreePprGrp();
                GetActiveFrePprGrp( out frepprgr, out index );
                _maintenanceDlg.ShowGroupDlg( frepprgr.FreePrtPprGroupCd, frepprgr.FreePrtPprGroupNm, frepprgr.UpdateDateTime, frepprgr.CreateDateTime, frepprgr.FileHeaderGuid );
            }
        }

        /// <summary>
        /// ���R���[�O���[�v�O���b�h�I��ύX�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FreePprGr_Grid_AfterSelectChange( object sender, AfterSelectChangeEventArgs e )
        {
            FrePPrGroupChange( GetSelectedGrCode() );
        }

        /// <summary>
        /// ���׃A�N�e�B�x�[�g���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FreePprPrt_Grid_AfterRowActivate( object sender, EventArgs e )
        {
            SetExtraCnditionFrom();

            //�A�N�e�B�u�J���[�̕ύX
            UltraGrid grid = (UltraGrid)sender;
            if ( (Guid)(grid.ActiveRow.Cells[CT_FREE_PPR_GUID].Value) == Guid.Empty )
            {   // ���_�E�����[�h
                grid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Red;
            }
            else
            {   // �ʏ�
                grid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Black;
            }
            grid.ActiveRow.Selected = true;
        }

        /// <summary>
        /// ���׍s����A�N�e�B�u�ɂȂ�O�ɔ�������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FreePprPrt_Grid_BeforeRowDeactivate( object sender, CancelEventArgs e )
        {
            UpdateFrePprECndLsCash();
        }

        /// <summary>
        /// �O���[�v�s����A�N�e�B�u�ɂȂ�O�ɔ�������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FreePprGr_Grid_BeforeRowDeactivate( object sender, CancelEventArgs e )
        {
            UpdateFrePprECndLsCash();
        }

        /// <summary>
        /// ���ׂ̃��E���_�u���N���b�N�����Ƃ��ɔ������܂�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FreePprPrt_Grid_DoubleClickRow( object sender, DoubleClickRowEventArgs e )
        {
            if ( (Guid)(e.Row.Cells[CT_FREE_PPR_GUID].Value) != Guid.Empty )
            {   // ���_�E�����[�h�łȂ����
                FrePprGrTr wk = new FrePprGrTr();
                if ( GetActiveFrePprGrTr( out wk ) != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND )
                {
                    _maintenanceDlg.ShowTranceDlg( wk.FreePrtPprGroupCd, wk.TransferCode, wk.DisplayOrder, wk.OutputFormFileName, wk.UserPrtPprIdDerivNo, wk.UpdateDateTime, wk.CreateDateTime, wk.FileHeaderGuid );
                }
            }
            else
            {
                TMsgDisp.Show( Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_INFO,
                PGID, "���_�E�����[�h�̈���Ώۂ͕ύX�ł��܂���", 0, MessageBoxButtons.OK );
            }
        }

        /// <summary>
        /// �s�����������ꂽ�Ƃ��ɔ������܂�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FreePprPrt_Grid_InitializeRow( object sender, InitializeRowEventArgs e )
        {
            if ( (Guid)(e.Row.Cells[CT_FREE_PPR_GUID].Value) == Guid.Empty )
            {   // ���_�E�����[�h
                e.Row.CellAppearance.ForeColor = Color.Red;
            }
            else
            {   // �ʏ�
                e.Row.CellAppearance.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailToolbarsManager_ToolClick( object sender, ToolClickEventArgs e )
        {
            if ( e.Tool.Key == CT_ROW_ADD )
            {
                _maintenanceDlg.ShowTranceDlg();
            }
            if ( e.Tool.Key == CT_ROW_DELETE )
            {
                DeleteFrePprGrTrData();
            }
        }
        #endregion

        //=========================================================================================
        #region IFreePprMainFrame �����o

        /// <summary>�N���[�Y���v���p�e�B</summary>
        /// <value>��ʂ��I�����Ă悢�ꍇ��True�A��肪����ꍇ��False��Ԃ��܂�</value>
        public bool CanClose
        {
            get { return true; }
        }

        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g�i���C���t���[���j
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        public void FrameToolbars_ToolClick( object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e )
        {
            if ( e.Tool.Key == CT_PRINT_BUTTONTOOL )
            {
                // �����e�i���X���͈�����L�����Z��
                if ( _maintenanceDlg.Visible == true ) return;

                int status = 0;
                FrePprGrTr[] frePprGrTrs;    //������p�U�փ}�X�^

                // ����Ώۂ��Ȃ���΃��b�Z�[�W��\�����ďI��
                if ( FreePprPrt_Grid.Rows.FilteredInRowCount <= 0 )
                {
                    TMessageBox( emErrorLevel.ERR_LEVEL_EXCLAMATION, "����Ώۂ�����܂���", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                    return;
                }

                //�v�����^�I��
                string groupNm = (string)_freeSheetGrDS.Tables[CT_FREE_PPR_GR].Rows[FreePprGr_Grid.ActiveRow.Index][CT_FREE_PPR_GrNm];
                if ( DialogResult.Cancel == _printDialog.PinrterSelectDlgShow( this, groupNm ) ) return;

                // 2008.03.18 ADD ====================================== START
                //���o�������ׂ��擾
                if ( _frePprECndDLs == null )
                {
                    FrePrtPSetAcs frePExCndDAcs = new FrePrtPSetAcs();
                    frePExCndDAcs.SearchFrePExCndDList( _enterpriseCode, out _frePprECndDLs );
                }
                // 2008.03.18 ADD ====================================== END

                status = GetGroupFrePprGrTr( out frePprGrTrs, GetSelectedGrCode() );
                if ( status == (Int32)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    // ���ʏ�������ʐ���
                    Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();

                    // ���ʏ�������ʃv���p�e�B�ݒ�
                    form.Title = ctPRINT_TITLE;           // ��ʂ̃^�C�g�������ɕ\�����镶����
                    form.Message = ctPRINT_MESSAGE;       // ��ʂ̃v���O���X�o�[�̏�ɕ\�����镶����
                    form.DispCancelButton = true;        // �L�����Z���{�^�������ɂ�钆�f�@�\�n�m�i�f�t�H���g�͂n�e�e�j

                    // ���ʏ�������ʕ\��
                    form.Show( this );
                    StringBuilder messageSb = new StringBuilder();
                    bool msgDiv = true;

                    try
                    {
                        List<FrePprECnd> frePprECndLs;          //���o�������X�g
                        int errIndex;                           //���o�����`�F�b�N�ŃG���[���������������̃C���f�b�N�X
                        string errMsg;                         //�G���[���b�Z�[�W
                        Control errCtl = null;                 //�G���[�R���g���[��

                        //���o�����L���b�V���X�V
                        UpdateFrePprECndLsCash();

                        //���o�����ꊇ�`�F�b�N
                        foreach ( FrePprGrTr frePprGrTr in frePprGrTrs )
                        {
                            // ���_�E�����[�h
                            if ( frePprGrTr.FileHeaderGuid == Guid.Empty )
                                continue;

                            frePprECndLs = new List<FrePprECnd>();
                            if ( _frePprECndLsHt.ContainsKey( Generate_FrePprGrTr_Key( frePprGrTr ) ) )
                            {
                                frePprECndLs = (List<FrePprECnd>)_frePprECndLsHt[Generate_FrePprGrTr_Key( frePprGrTr )];
                            }

                            //�����̓��̓`�F�b�N
                            if ( !SFANL08132CA.InputCheck( frePprECndLs, true, out errMsg, out errIndex ) )
                            {
                                GridActivate( frePprGrTr.FreePrtPprGroupCd, frePprGrTr.TransferCode );    //���׍s���G���[�s�ɕύX

                                //�����̓��̓`�F�b�N
                                if ( !_extCdtForm.InputCheck( frePprECndLs, out errMsg, out errCtl, true ) )
                                {
                                    TMessageBox( emErrorLevel.ERR_LEVEL_EXCLAMATION, errMsg, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                                    msgDiv = false;
                                    errCtl.Focus();
                                    return;
                                }
                            }
                            //��ٰ�ߖ��̌����� 2008.03.18 ADD ======================== START
                            //FrePrtPSet frePrtPSet = null;                           //����p�󎚈ʒu���N���X
                            ////�󎚈ʒu�N���X�擾
                            //frePrtPSet = GetFrePrtPSetCash(frePprGrTr.OutputFormFileName, frePprGrTr.UserPrtPprIdDerivNo);
                            //switch (frePrtPSet.PrintPaperDivCd)
                            //{
                            //    case 1: //�������[
                            //        {
                            if ( SFANL08235CH.Check_ECnd_DaillyReport( frePprECndLs, out errMsg ) != 0 )
                            {
                                GridActivate( frePprGrTr.FreePrtPprGroupCd, frePprGrTr.TransferCode );    //���׍s���G���[�s�ɕύX
                                TMessageBox( emErrorLevel.ERR_LEVEL_EXCLAMATION, "[ " + frePprGrTr.DisplayName + " ]\n" + errMsg, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                                msgDiv = false;
                                return;
                            }
                            //           break;
                            //        }
                            //}
                            //��ٰ�ߖ��̌����� 2008.03.18 ADD ======================== END
                        }

                        //�o�b�`���
                        int prtCnt = 0;
                        foreach ( FrePprGrTr frePprGrTr in frePprGrTrs )
                        {
                            prtCnt++;
                            form.Message = ctPRINT_MESSAGE + "(" + prtCnt.ToString() + " / " + frePprGrTrs.Length.ToString() + ")";
                            try
                            {
                                // ���_�E�����[�h
                                if ( frePprGrTr.FileHeaderGuid == Guid.Empty )
                                {
                                    continue;
                                }
                                // �L�����Z���{�^�����������ꂽ�ꍇ�̏����iform.DispCancelButton�v���p�e�B��true�̎��̂݁j
                                if ( form.IsCanceled )
                                {
                                    messageSb.Append( "�ꊇ��������[�U�[�����݂ɂ�蒆�f����܂���\n" );
                                    break;
                                }
                                status = BatchPrint( frePprGrTr );
                                if ( status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND )
                                {
                                    messageSb.Append( frePprGrTr.DisplayName + "�̈󎚈ʒu�f�[�^������܂���\n" );
                                }
                                else if ( status == (int)ConstantManagement.DB_Status.ctDB_EOF )
                                {
                                    messageSb.Append( frePprGrTr.DisplayName + "�͊Y���f�[�^������܂���ł���\n" );
                                }
                            }
                            catch ( Exception ex )
                            {
                                messageSb.Append( frePprGrTr.DisplayName + "�̈���Ɏ��s���܂���\n" );
                                messageSb.Append( "�ڍ�:" + ex.Message );
                            }
                        }
                    }
                    finally
                    {
                        form.Close();
                        if ( msgDiv )
                        {
                            if ( messageSb.Length != 0 )
                            {
                                TMessageBox( emErrorLevel.ERR_LEVEL_INFO, messageSb.ToString(), 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                            }
                            else
                            {
                                TMessageBox( emErrorLevel.ERR_LEVEL_INFO, "�ꊇ�������������ɏI�����܂���", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// �h�b�N���擾����
        /// </summary>
        /// <param name="dockAreaPaneArray">�h�b�N���̃R���N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        public int GetDockAreaInfo( out DockAreaPane[] dockAreaPaneArray )
        {
            dockAreaPaneArray = null;
            return 4;
        }

        /// <summary>
        /// �c�[���o�[���擾����
        /// </summary>
        /// <param name="ultraToolbarArray">�c�[���o�[�̔z��</param>
        /// <returns>�X�e�[�^�X</returns>
        public int GetToolBarInfo( out UltraToolbar[] ultraToolbarArray )
        {
            ultraToolbarArray = null;
            return 4;
        }

        /// <summary>
        /// �c�[���o�[���擾����
        /// </summary>
        /// <param name="rootToolsCollection">�c�[���o�[�R���N�V����</param>
        /// <param name="toolbarsCollection"></param>
        /// <returns>�X�e�[�^�X</returns>
        public int SetToolBarInfo( ref RootToolsCollection rootToolsCollection, ref ToolbarsCollection toolbarsCollection )
        {
            // �_�E�����[�h�J�n�{�^���̒ǉ�
            ButtonTool printButtonTool = new ButtonTool( CT_PRINT_BUTTONTOOL );
            printButtonTool.SharedProps.Caption = "�ꊇ���(&A)";
            printButtonTool.SharedProps.AppearancesSmall.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.PRINT];
            rootToolsCollection.Add( printButtonTool );
            toolbarsCollection[FreeSheetConst.ctToolBar_Main].Tools.AddTool( CT_PRINT_BUTTONTOOL );
            toolbarsCollection[FreeSheetConst.ctToolBar_Main].Tools[CT_PRINT_BUTTONTOOL].InstanceProps.IsFirstInGroup = true;
            PopupMenuTool fileMenuTool = (PopupMenuTool)rootToolsCollection[FreeSheetConst.ctPopupMenu_File];
            fileMenuTool.Tools.AddTool( CT_PRINT_BUTTONTOOL );

            return 0;
        }

        /// <summary>
        /// �c�[���{�^���\������ʒm�C�x���g
        /// </summary>
        public event ToolButtonDisplayControlEventHandler ToolButtonVisibleChanged;

        /// <summary>
        /// �c�[���{�^�����͐���ʒm�C�x���g
        /// </summary>
        public event ToolButtonDisplayControlEventHandler ToolButtonEnableChanged;

        #endregion

        #region ���_����
        /// <summary>
        /// ���_�ύX�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Section_UTree_AfterCheck( object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e )
        {

            if ( this._secNodeCheckEvent ) return;

            // �C�x���g���t���OON
            this._secNodeCheckEvent = true;

            try
            {
                Infragistics.Win.UltraWinTree.UltraTreeNode utnAll =
                    this.Section_UTree.GetNodeByKey( CT_AllSectionCode );

                _selectSecCds.Clear();

                // �h�S�Ёh�w�肳�ꂽ
                if ( e.TreeNode.Key.ToString().Equals( CT_AllSectionCode ) )
                {
                    // �I��
                    if ( utnAll != null )
                    {
                        if ( utnAll.CheckedState == CheckState.Checked )
                        {
                            // ���̑��̍��ڂ̃`�F�b�N���͂���
                            foreach ( Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.Section_UTree.Nodes )
                            {
                                if ( !utn.Key.Equals( CT_AllSectionCode ) )
                                {
                                    utn.CheckedState = CheckState.Unchecked;
                                }
                            }
                        }
                        _allSectionDiv = true;
                    }
                }
                else
                {
                    // ���̑����_
                    if ( utnAll != null )
                    {
                        if ( utnAll.CheckedState == CheckState.Checked )
                        {
                            utnAll.CheckedState = CheckState.Unchecked;

                            //if (target != null)
                            //{
                            //    target.CheckedSection(utnAll.Key.ToString(), CheckState.Unchecked);
                            //}

                        }
                    }
                    foreach ( Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.Section_UTree.Nodes )
                    {
                        if ( utn.CheckedState == CheckState.Checked )
                        {
                            _selectSecCds.Add( utn.Key.ToString() );
                        }
                    }
                    _allSectionDiv = false;
                }
                //if (target != null)
                //{
                //    target.CheckedSection(e.TreeNode.Key.ToString(), e.TreeNode.CheckedState);
                //}
                // �I������Ă��鋒�_����ۑ�

                //�S�Ẵ`�F�b�N���O���ꂽ�烁�b�Z�[�W�������ăf�t�H���g�l���Z�b�g
                int cnt = 0;
                foreach ( Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.Section_UTree.Nodes )
                {
                    if ( utn.CheckedState == CheckState.Checked )
                    {
                        cnt++;
                    }
                }
                if ( cnt < 1 )
                {
                    TMessageBox( emErrorLevel.ERR_LEVEL_EXCLAMATION, "�o�͑Ώۋ��_�͕K����̓`�F�b�N���Ă�������", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                    // �f�t�H���g�`�F�b�N�̓��O�C�����_
                    this.Section_UTree.Nodes[this._loginSectionCode.TrimEnd()].CheckedState = System.Windows.Forms.CheckState.Checked;
                }
            }
            finally
            {
                e.TreeNode.Selected = true;
                this._secNodeCheckEvent = false;
            }
        }

        /// <summary>
        /// �v�㋒�_��ʕύX�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUpCd_UOptionSet_ValueChanged( object sender, EventArgs e )
        {
            _printInfo.sectionKindCd = ((Infragistics.Win.UltraWinEditors.UltraOptionSet)sender).CheckedIndex + 1;

            // �f�t�H���g�`�F�b�N�̓��O�C�����_
            if ( this.Section_UTree.Nodes.Count > 0 )
                this.Section_UTree.Nodes[this._loginSectionCode.TrimEnd()].CheckedState = System.Windows.Forms.CheckState.Checked;

            //���O�C�����_�ȊO�̓`�F�b�N���O��
            foreach ( Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.Section_UTree.Nodes )
            {
                if ( utn.Key != this._loginSectionCode.TrimEnd() )
                {
                    utn.CheckedState = CheckState.Unchecked;
                }
            }


        }

        private void tArrowKeyControl1_ChangeFocus( object sender, ChangeFocusEventArgs e )
        {
            //Control senderCtl;

            if ( e.Key == Keys.Enter )
            {
            }
            if ( e.Key == Keys.Up )
            {
                //�@����{�^���@���@�O���[�v
                if ( e.PrevCtrl == Print_Button )
                {
                    e.NextCtrl = null;
                    this.FreePprGr_Grid.Focus();
                    return;
                }
                //�@�\�[�g�{�^���@���@�O���[�v
                if ( e.PrevCtrl == OrderCng_Button )
                {
                    e.NextCtrl = null;
                    this.FreePprGr_Grid.Focus();
                    return;
                }
            }
            if ( e.Key == Keys.Down )
            {
            }
            if ( e.Key == Keys.Right )
            {
                //�@�\�[�g�{�^���@���@����
                if ( e.PrevCtrl == OrderCng_Button )
                {
                    e.NextCtrl = null;
                    if ( FreePprPrt_Grid.ActiveRow != null )
                        this.FreePprPrt_Grid.Focus();
                    return;
                }
            }
        }

        private void FreePprPrt_Grid_KeyDown( object sender, KeyEventArgs e )
        {
            //�@���ׁ@���@�O���[�v
            if ( e.KeyCode == Keys.Left )
            {
                if ( (this.FreePprPrt_Grid.ActiveRow != null) && (this.FreePprPrt_Grid.ActiveRow.Index == 0) )
                {
                    FreePprGr_Grid.Focus();
                }
            }
        }

        private void FreePprGr_Grid_KeyDown( object sender, KeyEventArgs e )
        {
            // �O���[�v�@���@����
            if ( e.KeyCode == Keys.Right )
            {
                if ( (this.FreePprGr_Grid.ActiveRow != null) && (this.FreePprGr_Grid.ActiveRow.Index == 0) )
                {
                    FreePprPrt_Grid.Focus();
                }
            }
            // �O���[�v�@���@����{�^��
            else if ( e.KeyCode == Keys.Down )
            {
                if ( (this.FreePprGr_Grid.ActiveRow != null) && (this.FreePprGr_Grid.ActiveRow.Index == (this.FreePprGr_Grid.Rows.Count - 1)) )
                {
                    Print_Button.Focus();
                }
            }
        }


        #endregion



    }

    #region �\�[�g�N���X
    /// <summary>
    /// ���R���[�\�[�g���ʔ�r�p�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : IComparable �C���^�[�t�F�C�X�̎����B</br>
    /// <br>Programmer : 22011 ���� ���l</br>
    /// <br>Date       : 2007.11.06</br>
    /// </remarks>
    public class FrePprSrtOSortingOrderComparer : IComparer<FrePprSrtO>
    {
        /// <summary>
        /// ���R���[�\�[�g���ʔ�r�p���\�b�h
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public int Compare( FrePprSrtO x, FrePprSrtO y )
        {
            return (x.SortingOrder - y.SortingOrder);
        }
    }
    #endregion
}
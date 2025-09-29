//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �s�a�n���o��
// �v���O�����T�v   : �s�a�n���o��
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11270029-00  �쐬�S�� : ������
// �� �� �� : 2016/05/20   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Xml;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.Misc;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �s�a�n���o�̓t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �s�a�n���o�͂̃t���[���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2016/05/20</br>
    /// </remarks>
    public class PMKHN09510UA : System.Windows.Forms.Form
    {
        # region Private Members (Component)
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager Main_ToolbarsManager;
        private System.Windows.Forms.Timer Initial_Timer;
        private Infragistics.Win.UltraWinDock.UltraDockManager Main_DockManager;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar Main_StatusBar;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _PMKHN09510UAUnpinnedTabAreaLeft;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _PMKHN09510UAUnpinnedTabAreaRight;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _PMKHN09510UAUnpinnedTabAreaTop;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _PMKHN09510UAUnpinnedTabAreaBottom;
        private Infragistics.Win.UltraWinDock.AutoHideControl _PMKHN09510UAAutoHideControl;
        private TMemPos tMemPos1;
        private DataSet BindDataSet;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.MenuItem Close_menuItem;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN09510UA_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN09510UA_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN09510UA_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _PMKHN09510UA_Toolbars_Dock_Area_Bottom;
        private UltraTabControl utc_InventTab;
        private UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Panel PMKHN09510UA_Fill_Panel;
        private TRetKeyControl tRetKeyControl1;
        private TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private UiSetControl uiSetControl1;
        private UiMemInput uiMemInput1;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar ultraExplorerBar1;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl1;
        private TDateEdit TDateEdit_PriceStartDate;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_PriceStartDate;
        private TEdit tEdit_GoodsNo;
        private Infragistics.Win.Misc.UltraButton btn_MakerGuid_St;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_Maker;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_GoodsNo;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_TBOClass;
        private TEdit tEdit_Category;
        private UltraButton btn_MakerGuid_Ed;
        private TEdit tEdit_MakerName_Ed;
        private TEdit tEdit_MakerName_St;
        private UltraLabel ultraLabel2;
        private TNedit tNedit_MakerCode_Ed;
        private TNedit tNedit_MakerCode_St;
        private UltraLabel ultraLabel_Customer;
        private UltraButton btn_CustomerGuid;
        private TEdit tEdit_CustomerName;
        private TNedit tNedit_CustomerCode;
        private System.Windows.Forms.ContextMenu TabControl_contextMenu;
        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// �s�a�n���o�̓t���[���N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �s�a�n���o�͂̃t���[���N���X�ł��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        public PMKHN09510UA()
        {
            InitializeComponent();

            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
        }

        /// <summary>
        /// �R���X�g���N�^�@Nunit�p
        /// </summary>
        /// <param name="param">�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �s�a�n���o�̓t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        public PMKHN09510UA(string param)
        {
            if (("NUnit").Equals(param))
            {
                // ������
                InitializeComponent();
            }
            else
            {
                throw new Exception();
            }
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
        /// <br>Note       : �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2016/05/20</br>
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
        /// <remarks>
        /// <br>Note       : �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("MainMenu_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Edit_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Button_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Export_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Guide_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Export_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool5 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Export_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Guide_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Edit_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Guide_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool6 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09510UA));
            this.ultraExplorerBarContainerControl1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.btn_CustomerGuid = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_CustomerName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tNedit_CustomerCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel_Customer = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_MakerCode_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_MakerCode_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.btn_MakerGuid_Ed = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_MakerName_Ed = new Broadleaf.Library.Windows.Forms.TEdit();
            this.TDateEdit_PriceStartDate = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel_PriceStartDate = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_MakerName_St = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_Category = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_GoodsNo = new Broadleaf.Library.Windows.Forms.TEdit();
            this.btn_MakerGuid_St = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel_Maker = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel_GoodsNo = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel_TBOClass = new Infragistics.Win.Misc.UltraLabel();
            this.Main_DockManager = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._PMKHN09510UAUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._PMKHN09510UAUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._PMKHN09510UAUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._PMKHN09510UAUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._PMKHN09510UAAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Main_StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tMemPos1 = new Broadleaf.Library.Windows.Forms.TMemPos(this.components);
            this.BindDataSet = new System.Data.DataSet();
            this.Close_menuItem = new System.Windows.Forms.MenuItem();
            this.TabControl_contextMenu = new System.Windows.Forms.ContextMenu();
            this.utc_InventTab = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.PMKHN09510UA_Fill_Panel = new System.Windows.Forms.Panel();
            this.ultraExplorerBar1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.uiMemInput1 = new Broadleaf.Library.Windows.Forms.UiMemInput(this.components);
            this._PMKHN09510UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Main_ToolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._PMKHN09510UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMKHN09510UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._PMKHN09510UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraExplorerBarContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_MakerCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_MakerCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MakerName_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MakerName_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Category)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.utc_InventTab)).BeginInit();
            this.utc_InventTab.SuspendLayout();
            this.ultraTabSharedControlsPage1.SuspendLayout();
            this.PMKHN09510UA_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraExplorerBar1)).BeginInit();
            this.ultraExplorerBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraExplorerBarContainerControl1
            // 
            this.ultraExplorerBarContainerControl1.Controls.Add(this.btn_CustomerGuid);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_CustomerName);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_CustomerCode);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel_Customer);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_MakerCode_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_MakerCode_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel2);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.btn_MakerGuid_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_MakerName_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.TDateEdit_PriceStartDate);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel_PriceStartDate);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_MakerName_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_Category);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_GoodsNo);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.btn_MakerGuid_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel_Maker);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel_GoodsNo);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel_TBOClass);
            this.ultraExplorerBarContainerControl1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F);
            this.ultraExplorerBarContainerControl1.Location = new System.Drawing.Point(19, 48);
            this.ultraExplorerBarContainerControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ultraExplorerBarContainerControl1.Name = "ultraExplorerBarContainerControl1";
            this.ultraExplorerBarContainerControl1.Size = new System.Drawing.Size(976, 280);
            this.ultraExplorerBarContainerControl1.TabIndex = 0;
            // 
            // btn_CustomerGuid
            // 
            appearance17.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance17.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btn_CustomerGuid.Appearance = appearance17;
            this.btn_CustomerGuid.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_CustomerGuid.Location = new System.Drawing.Point(589, 199);
            this.btn_CustomerGuid.Name = "btn_CustomerGuid";
            this.btn_CustomerGuid.Size = new System.Drawing.Size(24, 24);
            this.btn_CustomerGuid.TabIndex = 8;
            this.btn_CustomerGuid.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btn_CustomerGuid.Click += new System.EventHandler(this.btn_CustomerGuid_Click);
            // 
            // tEdit_CustomerName
            // 
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance15.TextHAlignAsString = "Left";
            this.tEdit_CustomerName.ActiveAppearance = appearance15;
            appearance16.TextHAlignAsString = "Left";
            this.tEdit_CustomerName.Appearance = appearance16;
            this.tEdit_CustomerName.AutoSelect = true;
            this.tEdit_CustomerName.AutoSize = false;
            this.tEdit_CustomerName.DataText = "";
            this.tEdit_CustomerName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_CustomerName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_CustomerName.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_CustomerName.Location = new System.Drawing.Point(364, 199);
            this.tEdit_CustomerName.MaxLength = 24;
            this.tEdit_CustomerName.Name = "tEdit_CustomerName";
            this.tEdit_CustomerName.ReadOnly = true;
            this.tEdit_CustomerName.Size = new System.Drawing.Size(219, 24);
            this.tEdit_CustomerName.TabIndex = 1007;
            // 
            // tNedit_CustomerCode
            // 
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance12.ForeColor = System.Drawing.Color.Black;
            appearance12.TextHAlignAsString = "Left";
            this.tNedit_CustomerCode.ActiveAppearance = appearance12;
            appearance13.ForeColor = System.Drawing.Color.Black;
            appearance13.ForeColorDisabled = System.Drawing.Color.Black;
            appearance13.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode.Appearance = appearance13;
            this.tNedit_CustomerCode.AutoSelect = true;
            this.tNedit_CustomerCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode.DataText = "";
            this.tNedit_CustomerCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCode.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_CustomerCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_CustomerCode.Location = new System.Drawing.Point(282, 199);
            this.tNedit_CustomerCode.MaxLength = 8;
            this.tNedit_CustomerCode.Name = "tNedit_CustomerCode";
            this.tNedit_CustomerCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_CustomerCode.Size = new System.Drawing.Size(76, 24);
            this.tNedit_CustomerCode.TabIndex = 6;
            this.tNedit_CustomerCode.Leave += new System.EventHandler(this.tNedit_MakerCode_St_Leave);
            // 
            // ultraLabel_Customer
            // 
            appearance9.BackColor = System.Drawing.Color.Transparent;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            appearance9.TextHAlignAsString = "Left";
            appearance9.TextVAlignAsString = "Middle";
            this.ultraLabel_Customer.Appearance = appearance9;
            this.ultraLabel_Customer.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel_Customer.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel_Customer.Location = new System.Drawing.Point(45, 199);
            this.ultraLabel_Customer.Margin = new System.Windows.Forms.Padding(1);
            this.ultraLabel_Customer.Name = "ultraLabel_Customer";
            this.ultraLabel_Customer.Size = new System.Drawing.Size(100, 24);
            this.ultraLabel_Customer.TabIndex = 1006;
            this.ultraLabel_Customer.Text = "���Ӑ�";
            // 
            // tNedit_MakerCode_Ed
            // 
            appearance94.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance94.ForeColor = System.Drawing.Color.Black;
            appearance94.TextHAlignAsString = "Left";
            this.tNedit_MakerCode_Ed.ActiveAppearance = appearance94;
            appearance95.ForeColor = System.Drawing.Color.Black;
            appearance95.ForeColorDisabled = System.Drawing.Color.Black;
            appearance95.TextHAlignAsString = "Right";
            this.tNedit_MakerCode_Ed.Appearance = appearance95;
            this.tNedit_MakerCode_Ed.AutoSelect = true;
            this.tNedit_MakerCode_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_MakerCode_Ed.DataText = "";
            this.tNedit_MakerCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_MakerCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_MakerCode_Ed.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_MakerCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_MakerCode_Ed.Location = new System.Drawing.Point(557, 153);
            this.tNedit_MakerCode_Ed.MaxLength = 4;
            this.tNedit_MakerCode_Ed.Name = "tNedit_MakerCode_Ed";
            this.tNedit_MakerCode_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_MakerCode_Ed.Size = new System.Drawing.Size(44, 24);
            this.tNedit_MakerCode_Ed.TabIndex = 4;
            this.tNedit_MakerCode_Ed.Leave += new System.EventHandler(this.tNedit_MakerCode_St_Leave);
            // 
            // tNedit_MakerCode_St
            // 
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance21.ForeColor = System.Drawing.Color.Black;
            appearance21.TextHAlignAsString = "Left";
            this.tNedit_MakerCode_St.ActiveAppearance = appearance21;
            appearance22.ForeColor = System.Drawing.Color.Black;
            appearance22.ForeColorDisabled = System.Drawing.Color.Black;
            appearance22.TextHAlignAsString = "Right";
            this.tNedit_MakerCode_St.Appearance = appearance22;
            this.tNedit_MakerCode_St.AutoSelect = true;
            this.tNedit_MakerCode_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_MakerCode_St.DataText = "";
            this.tNedit_MakerCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_MakerCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_MakerCode_St.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_MakerCode_St.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_MakerCode_St.Location = new System.Drawing.Point(282, 153);
            this.tNedit_MakerCode_St.MaxLength = 4;
            this.tNedit_MakerCode_St.Name = "tNedit_MakerCode_St";
            this.tNedit_MakerCode_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_MakerCode_St.Size = new System.Drawing.Size(44, 24);
            this.tNedit_MakerCode_St.TabIndex = 2;
            this.tNedit_MakerCode_St.Leave += new System.EventHandler(this.tNedit_MakerCode_St_Leave);
            // 
            // ultraLabel2
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Left";
            appearance5.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance5;
            this.ultraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel2.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel2.Location = new System.Drawing.Point(529, 153);
            this.ultraLabel2.Margin = new System.Windows.Forms.Padding(1);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(24, 24);
            this.ultraLabel2.TabIndex = 1002;
            this.ultraLabel2.Text = "�`";
            // 
            // btn_MakerGuid_Ed
            // 
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btn_MakerGuid_Ed.Appearance = appearance4;
            this.btn_MakerGuid_Ed.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_MakerGuid_Ed.Location = new System.Drawing.Point(776, 153);
            this.btn_MakerGuid_Ed.Name = "btn_MakerGuid_Ed";
            this.btn_MakerGuid_Ed.Size = new System.Drawing.Size(24, 24);
            this.btn_MakerGuid_Ed.TabIndex = 5;
            this.btn_MakerGuid_Ed.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btn_MakerGuid_Ed.Click += new System.EventHandler(this.btn_MakerGuid_Click);
            // 
            // tEdit_MakerName_Ed
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance10.TextHAlignAsString = "Left";
            this.tEdit_MakerName_Ed.ActiveAppearance = appearance10;
            appearance11.TextHAlignAsString = "Left";
            this.tEdit_MakerName_Ed.Appearance = appearance11;
            this.tEdit_MakerName_Ed.AutoSelect = true;
            this.tEdit_MakerName_Ed.AutoSize = false;
            this.tEdit_MakerName_Ed.DataText = "";
            this.tEdit_MakerName_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_MakerName_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_MakerName_Ed.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_MakerName_Ed.Location = new System.Drawing.Point(607, 153);
            this.tEdit_MakerName_Ed.MaxLength = 24;
            this.tEdit_MakerName_Ed.Name = "tEdit_MakerName_Ed";
            this.tEdit_MakerName_Ed.ReadOnly = true;
            this.tEdit_MakerName_Ed.Size = new System.Drawing.Size(163, 24);
            this.tEdit_MakerName_Ed.TabIndex = 1004;
            // 
            // TDateEdit_PriceStartDate
            // 
            appearance78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.TDateEdit_PriceStartDate.ActiveEditAppearance = appearance78;
            this.TDateEdit_PriceStartDate.BackColor = System.Drawing.Color.Transparent;
            this.TDateEdit_PriceStartDate.CalendarDisp = true;
            appearance79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance79.ForeColorDisabled = System.Drawing.Color.Black;
            this.TDateEdit_PriceStartDate.EditAppearance = appearance79;
            this.TDateEdit_PriceStartDate.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.TDateEdit_PriceStartDate.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TDateEdit_PriceStartDate.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TDateEdit_PriceStartDate.ImeMode = System.Windows.Forms.ImeMode.Off;
            appearance80.TextHAlignAsString = "Left";
            appearance80.TextVAlignAsString = "Middle";
            this.TDateEdit_PriceStartDate.LabelAppearance = appearance80;
            this.TDateEdit_PriceStartDate.Location = new System.Drawing.Point(282, 59);
            this.TDateEdit_PriceStartDate.Name = "TDateEdit_PriceStartDate";
            this.TDateEdit_PriceStartDate.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.TDateEdit_PriceStartDate.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.TDateEdit_PriceStartDate.Size = new System.Drawing.Size(176, 24);
            this.TDateEdit_PriceStartDate.TabIndex = 0;
            this.TDateEdit_PriceStartDate.TabStop = true;
            // 
            // ultraLabel_PriceStartDate
            // 
            appearance82.BackColor = System.Drawing.Color.Transparent;
            appearance82.ForeColorDisabled = System.Drawing.Color.Black;
            appearance82.TextHAlignAsString = "Left";
            appearance82.TextVAlignAsString = "Middle";
            this.ultraLabel_PriceStartDate.Appearance = appearance82;
            this.ultraLabel_PriceStartDate.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel_PriceStartDate.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel_PriceStartDate.Location = new System.Drawing.Point(45, 59);
            this.ultraLabel_PriceStartDate.Margin = new System.Windows.Forms.Padding(1);
            this.ultraLabel_PriceStartDate.Name = "ultraLabel_PriceStartDate";
            this.ultraLabel_PriceStartDate.Size = new System.Drawing.Size(100, 24);
            this.ultraLabel_PriceStartDate.TabIndex = 1001;
            this.ultraLabel_PriceStartDate.Text = "���i�K�p��";
            // 
            // tEdit_MakerName_St
            // 
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance25.TextHAlignAsString = "Left";
            this.tEdit_MakerName_St.ActiveAppearance = appearance25;
            appearance26.TextHAlignAsString = "Left";
            this.tEdit_MakerName_St.Appearance = appearance26;
            this.tEdit_MakerName_St.AutoSelect = true;
            this.tEdit_MakerName_St.AutoSize = false;
            this.tEdit_MakerName_St.DataText = "";
            this.tEdit_MakerName_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_MakerName_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_MakerName_St.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_MakerName_St.Location = new System.Drawing.Point(332, 153);
            this.tEdit_MakerName_St.MaxLength = 24;
            this.tEdit_MakerName_St.Name = "tEdit_MakerName_St";
            this.tEdit_MakerName_St.ReadOnly = true;
            this.tEdit_MakerName_St.Size = new System.Drawing.Size(163, 24);
            this.tEdit_MakerName_St.TabIndex = 1003;
            // 
            // tEdit_Category
            // 
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance18.TextHAlignAsString = "Left";
            this.tEdit_Category.ActiveAppearance = appearance18;
            appearance19.TextHAlignAsString = "Left";
            this.tEdit_Category.Appearance = appearance19;
            this.tEdit_Category.AutoSelect = true;
            this.tEdit_Category.AutoSize = false;
            this.tEdit_Category.DataText = "";
            this.tEdit_Category.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_Category.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_Category.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_Category.Location = new System.Drawing.Point(282, 15);
            this.tEdit_Category.MaxLength = 24;
            this.tEdit_Category.Name = "tEdit_Category";
            this.tEdit_Category.ReadOnly = true;
            this.tEdit_Category.Size = new System.Drawing.Size(147, 24);
            this.tEdit_Category.TabIndex = 1005;
            // 
            // tEdit_GoodsNo
            // 
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance23.TextHAlignAsString = "Left";
            this.tEdit_GoodsNo.ActiveAppearance = appearance23;
            appearance24.TextHAlignAsString = "Left";
            this.tEdit_GoodsNo.Appearance = appearance24;
            this.tEdit_GoodsNo.AutoSelect = true;
            this.tEdit_GoodsNo.AutoSize = false;
            this.tEdit_GoodsNo.DataText = "";
            this.tEdit_GoodsNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_GoodsNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_GoodsNo.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_GoodsNo.Location = new System.Drawing.Point(282, 107);
            this.tEdit_GoodsNo.MaxLength = 24;
            this.tEdit_GoodsNo.Name = "tEdit_GoodsNo";
            this.tEdit_GoodsNo.Size = new System.Drawing.Size(203, 24);
            this.tEdit_GoodsNo.TabIndex = 1;
            // 
            // btn_MakerGuid_St
            // 
            appearance27.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance27.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btn_MakerGuid_St.Appearance = appearance27;
            this.btn_MakerGuid_St.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_MakerGuid_St.Location = new System.Drawing.Point(501, 153);
            this.btn_MakerGuid_St.Name = "btn_MakerGuid_St";
            this.btn_MakerGuid_St.Size = new System.Drawing.Size(24, 24);
            this.btn_MakerGuid_St.TabIndex = 3;
            this.btn_MakerGuid_St.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btn_MakerGuid_St.Click += new System.EventHandler(this.btn_MakerGuid_Click);
            // 
            // ultraLabel_Maker
            // 
            appearance14.BackColor = System.Drawing.Color.Transparent;
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            appearance14.TextHAlignAsString = "Left";
            appearance14.TextVAlignAsString = "Middle";
            this.ultraLabel_Maker.Appearance = appearance14;
            this.ultraLabel_Maker.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel_Maker.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel_Maker.Location = new System.Drawing.Point(45, 153);
            this.ultraLabel_Maker.Margin = new System.Windows.Forms.Padding(1);
            this.ultraLabel_Maker.Name = "ultraLabel_Maker";
            this.ultraLabel_Maker.Size = new System.Drawing.Size(100, 24);
            this.ultraLabel_Maker.TabIndex = 998;
            this.ultraLabel_Maker.Text = "���[�J�[";
            // 
            // ultraLabel_GoodsNo
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.ultraLabel_GoodsNo.Appearance = appearance2;
            this.ultraLabel_GoodsNo.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel_GoodsNo.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel_GoodsNo.Location = new System.Drawing.Point(45, 107);
            this.ultraLabel_GoodsNo.Margin = new System.Windows.Forms.Padding(1);
            this.ultraLabel_GoodsNo.Name = "ultraLabel_GoodsNo";
            this.ultraLabel_GoodsNo.Size = new System.Drawing.Size(100, 24);
            this.ultraLabel_GoodsNo.TabIndex = 999;
            this.ultraLabel_GoodsNo.Text = "�e�i��";
            // 
            // ultraLabel_TBOClass
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.ultraLabel_TBOClass.Appearance = appearance3;
            this.ultraLabel_TBOClass.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel_TBOClass.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel_TBOClass.Location = new System.Drawing.Point(45, 15);
            this.ultraLabel_TBOClass.Margin = new System.Windows.Forms.Padding(1);
            this.ultraLabel_TBOClass.Name = "ultraLabel_TBOClass";
            this.ultraLabel_TBOClass.Size = new System.Drawing.Size(100, 24);
            this.ultraLabel_TBOClass.TabIndex = 1000;
            this.ultraLabel_TBOClass.Text = "�J�e�S��";
            // 
            // Main_DockManager
            // 
            this.Main_DockManager.CaptionStyle = Infragistics.Win.UltraWinDock.CaptionStyle.Office2003;
            this.Main_DockManager.HostControl = this;
            this.Main_DockManager.LayoutStyle = Infragistics.Win.UltraWinDock.DockAreaLayoutStyle.FillContainer;
            this.Main_DockManager.ShowCloseButton = false;
            this.Main_DockManager.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2003;
            // 
            // _PMKHN09510UAUnpinnedTabAreaLeft
            // 
            this._PMKHN09510UAUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._PMKHN09510UAUnpinnedTabAreaLeft.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._PMKHN09510UAUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 73);
            this._PMKHN09510UAUnpinnedTabAreaLeft.Name = "_PMKHN09510UAUnpinnedTabAreaLeft";
            this._PMKHN09510UAUnpinnedTabAreaLeft.Owner = this.Main_DockManager;
            this._PMKHN09510UAUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 638);
            this._PMKHN09510UAUnpinnedTabAreaLeft.TabIndex = 5;
            // 
            // _PMKHN09510UAUnpinnedTabAreaRight
            // 
            this._PMKHN09510UAUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._PMKHN09510UAUnpinnedTabAreaRight.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._PMKHN09510UAUnpinnedTabAreaRight.Location = new System.Drawing.Point(1016, 73);
            this._PMKHN09510UAUnpinnedTabAreaRight.Name = "_PMKHN09510UAUnpinnedTabAreaRight";
            this._PMKHN09510UAUnpinnedTabAreaRight.Owner = this.Main_DockManager;
            this._PMKHN09510UAUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 638);
            this._PMKHN09510UAUnpinnedTabAreaRight.TabIndex = 6;
            // 
            // _PMKHN09510UAUnpinnedTabAreaTop
            // 
            this._PMKHN09510UAUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._PMKHN09510UAUnpinnedTabAreaTop.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._PMKHN09510UAUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 73);
            this._PMKHN09510UAUnpinnedTabAreaTop.Name = "_PMKHN09510UAUnpinnedTabAreaTop";
            this._PMKHN09510UAUnpinnedTabAreaTop.Owner = this.Main_DockManager;
            this._PMKHN09510UAUnpinnedTabAreaTop.Size = new System.Drawing.Size(1016, 0);
            this._PMKHN09510UAUnpinnedTabAreaTop.TabIndex = 7;
            // 
            // _PMKHN09510UAUnpinnedTabAreaBottom
            // 
            this._PMKHN09510UAUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._PMKHN09510UAUnpinnedTabAreaBottom.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._PMKHN09510UAUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 711);
            this._PMKHN09510UAUnpinnedTabAreaBottom.Name = "_PMKHN09510UAUnpinnedTabAreaBottom";
            this._PMKHN09510UAUnpinnedTabAreaBottom.Owner = this.Main_DockManager;
            this._PMKHN09510UAUnpinnedTabAreaBottom.Size = new System.Drawing.Size(1016, 0);
            this._PMKHN09510UAUnpinnedTabAreaBottom.TabIndex = 8;
            // 
            // _PMKHN09510UAAutoHideControl
            // 
            this._PMKHN09510UAAutoHideControl.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._PMKHN09510UAAutoHideControl.Location = new System.Drawing.Point(22, 63);
            this._PMKHN09510UAAutoHideControl.Name = "_PMKHN09510UAAutoHideControl";
            this._PMKHN09510UAAutoHideControl.Owner = this.Main_DockManager;
            this._PMKHN09510UAAutoHideControl.Size = new System.Drawing.Size(203, 627);
            this._PMKHN09510UAAutoHideControl.TabIndex = 9;
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            // 
            // Main_StatusBar
            // 
            this.Main_StatusBar.Location = new System.Drawing.Point(0, 711);
            this.Main_StatusBar.Name = "Main_StatusBar";
            appearance8.TextHAlignAsString = "Center";
            this.Main_StatusBar.PanelAppearance = appearance8;
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
            // utc_InventTab
            // 
            appearance6.BackColor = System.Drawing.Color.White;
            appearance6.BackColor2 = System.Drawing.Color.LightPink;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.utc_InventTab.ActiveTabAppearance = appearance6;
            this.utc_InventTab.Controls.Add(this.ultraTabSharedControlsPage1);
            this.utc_InventTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.utc_InventTab.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.utc_InventTab.Location = new System.Drawing.Point(0, 73);
            this.utc_InventTab.Name = "utc_InventTab";
            this.utc_InventTab.SharedControls.AddRange(new System.Windows.Forms.Control[] {
            this.PMKHN09510UA_Fill_Panel});
            this.utc_InventTab.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.utc_InventTab.Size = new System.Drawing.Size(1016, 638);
            this.utc_InventTab.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.utc_InventTab.TabIndex = 46;
            this.utc_InventTab.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Controls.Add(this.PMKHN09510UA_Fill_Panel);
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(1, 20);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(1014, 617);
            // 
            // PMKHN09510UA_Fill_Panel
            // 
            this.PMKHN09510UA_Fill_Panel.Controls.Add(this.ultraExplorerBar1);
            this.PMKHN09510UA_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.PMKHN09510UA_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PMKHN09510UA_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.PMKHN09510UA_Fill_Panel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PMKHN09510UA_Fill_Panel.Name = "PMKHN09510UA_Fill_Panel";
            this.PMKHN09510UA_Fill_Panel.Size = new System.Drawing.Size(1014, 617);
            this.PMKHN09510UA_Fill_Panel.TabIndex = 2;
            // 
            // ultraExplorerBar1
            // 
            this.ultraExplorerBar1.AcceptsFocus = Infragistics.Win.DefaultableBoolean.False;
            this.ultraExplorerBar1.AnimationSpeed = Infragistics.Win.UltraWinExplorerBar.AnimationSpeed.Fast;
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            appearance20.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            appearance20.FontData.SizeInPoints = 10F;
            appearance20.TextHAlignAsString = "Left";
            appearance20.TextVAlignAsString = "Middle";
            this.ultraExplorerBar1.Appearance = appearance20;
            this.ultraExplorerBar1.Controls.Add(this.ultraExplorerBarContainerControl1);
            this.ultraExplorerBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraExplorerBar1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F);
            ultraExplorerBarGroup1.Container = this.ultraExplorerBarContainerControl1;
            ultraExplorerBarGroup1.Key = "SearchCond";
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            ultraExplorerBarGroup1.Settings.AppearancesSmall.ActiveAppearance = appearance1;
            ultraExplorerBarGroup1.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup1.Settings.ContainerHeight = 282;
            ultraExplorerBarGroup1.Text = "���o����";
            this.ultraExplorerBar1.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1});
            this.ultraExplorerBar1.GroupSettings.AllowDrag = Infragistics.Win.DefaultableBoolean.False;
            this.ultraExplorerBar1.GroupSettings.AllowEdit = Infragistics.Win.DefaultableBoolean.False;
            appearance48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance48.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance48.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance48.Cursor = System.Windows.Forms.Cursors.Default;
            this.ultraExplorerBar1.GroupSettings.AppearancesSmall.HeaderAppearance = appearance48;
            this.ultraExplorerBar1.GroupSettings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            this.ultraExplorerBar1.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            this.ultraExplorerBar1.GroupSpacing = 8;
            this.ultraExplorerBar1.Location = new System.Drawing.Point(0, 0);
            this.ultraExplorerBar1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ultraExplorerBar1.Name = "ultraExplorerBar1";
            this.ultraExplorerBar1.Scrollbars = Infragistics.Win.UltraWinExplorerBar.ScrollbarStyle.Never;
            this.ultraExplorerBar1.ShowDefaultContextMenu = false;
            this.ultraExplorerBar1.Size = new System.Drawing.Size(1014, 617);
            this.ultraExplorerBar1.TabIndex = 3;
            this.ultraExplorerBar1.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.Office2003;
            this.ultraExplorerBar1.GroupCollapsing += new Infragistics.Win.UltraWinExplorerBar.GroupCollapsingEventHandler(this.ultraExplorerBar1_GroupCollapsing);
            this.ultraExplorerBar1.GroupExpanding += new Infragistics.Win.UltraWinExplorerBar.GroupExpandingEventHandler(this.ultraExplorerBar1_GroupExpanding);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // uiMemInput1
            // 
            this.uiMemInput1.OwnerForm = this;
            this.uiMemInput1.ReadOnLoad = false;
            // 
            // _PMKHN09510UA_Toolbars_Dock_Area_Left
            // 
            this._PMKHN09510UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN09510UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN09510UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._PMKHN09510UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN09510UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 73);
            this._PMKHN09510UA_Toolbars_Dock_Area_Left.Name = "_PMKHN09510UA_Toolbars_Dock_Area_Left";
            this._PMKHN09510UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 638);
            this._PMKHN09510UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.Main_ToolbarsManager;
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
            buttonTool3});
            ultraToolbar2.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.BelowImage;
            ultraToolbar2.Text = "�W��";
            this.Main_ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2});
            popupMenuTool3.SharedProps.Caption = "�t�@�C��(&F)";
            popupMenuTool3.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            buttonTool5.InstanceProps.IsFirstInGroup = true;
            popupMenuTool3.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool4,
            buttonTool5});
            labelTool4.SharedProps.Spring = true;
            appearance7.BackColor = System.Drawing.Color.White;
            appearance7.TextHAlignAsString = "Left";
            labelTool5.SharedProps.AppearancesSmall.Appearance = appearance7;
            labelTool5.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            labelTool5.SharedProps.Width = 150;
            buttonTool6.SharedProps.Caption = "�I��(F1)";
            buttonTool6.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool6.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F1;
            buttonTool6.SharedProps.ShowInCustomizer = false;
            buttonTool7.SharedProps.Caption = "�o��(F10)";
            buttonTool7.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool7.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F10;
            buttonTool8.SharedProps.Caption = "�K�C�h(F5)";
            buttonTool8.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool8.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F5;
            popupMenuTool4.SharedProps.Caption = "�ҏW(&E)";
            popupMenuTool4.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool9});
            labelTool6.SharedProps.Caption = "���O�C���S����";
            this.Main_ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool3,
            labelTool4,
            labelTool5,
            buttonTool6,
            buttonTool7,
            buttonTool8,
            popupMenuTool4,
            labelTool6});
            this.Main_ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.Main_ToolbarsManager_ToolClick);
            // 
            // _PMKHN09510UA_Toolbars_Dock_Area_Right
            // 
            this._PMKHN09510UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN09510UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN09510UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._PMKHN09510UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN09510UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1016, 73);
            this._PMKHN09510UA_Toolbars_Dock_Area_Right.Name = "_PMKHN09510UA_Toolbars_Dock_Area_Right";
            this._PMKHN09510UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 638);
            this._PMKHN09510UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _PMKHN09510UA_Toolbars_Dock_Area_Top
            // 
            this._PMKHN09510UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN09510UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN09510UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._PMKHN09510UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN09510UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._PMKHN09510UA_Toolbars_Dock_Area_Top.Name = "_PMKHN09510UA_Toolbars_Dock_Area_Top";
            this._PMKHN09510UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1016, 73);
            this._PMKHN09510UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _PMKHN09510UA_Toolbars_Dock_Area_Bottom
            // 
            this._PMKHN09510UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._PMKHN09510UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._PMKHN09510UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._PMKHN09510UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._PMKHN09510UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 711);
            this._PMKHN09510UA_Toolbars_Dock_Area_Bottom.Name = "_PMKHN09510UA_Toolbars_Dock_Area_Bottom";
            this._PMKHN09510UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1016, 0);
            this._PMKHN09510UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // PMKHN09510UA
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this._PMKHN09510UAAutoHideControl);
            this.Controls.Add(this.utc_InventTab);
            this.Controls.Add(this._PMKHN09510UAUnpinnedTabAreaTop);
            this.Controls.Add(this._PMKHN09510UAUnpinnedTabAreaBottom);
            this.Controls.Add(this._PMKHN09510UAUnpinnedTabAreaLeft);
            this.Controls.Add(this._PMKHN09510UAUnpinnedTabAreaRight);
            this.Controls.Add(this._PMKHN09510UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._PMKHN09510UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._PMKHN09510UA_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._PMKHN09510UA_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.Main_StatusBar);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN09510UA";
            this.Opacity = 0;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "�s�a�n���o��";
            this.Load += new System.EventHandler(this.PMKHN09510UA_Load);
            this.Shown += new System.EventHandler(this.PMKHN09510UA_Shown);
            this.ultraExplorerBarContainerControl1.ResumeLayout(false);
            this.ultraExplorerBarContainerControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_MakerCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_MakerCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MakerName_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MakerName_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Category)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.utc_InventTab)).EndInit();
            this.utc_InventTab.ResumeLayout(false);
            this.ultraTabSharedControlsPage1.ResumeLayout(false);
            this.PMKHN09510UA_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraExplorerBar1)).EndInit();
            this.ultraExplorerBar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�萔
        // ===================================================================================== //
        #region Private Constant
        private const string CT_PGID = "PMKHN09510U";
        private const string CT_PRINTNAME = "�s�a�n���o��";
        
        // �c�[���o�[�c�[���L�[�ݒ�
        private const string TOOLBAR_LOGINLABEL_TITLE = "LoginTitle_LabelTool";
        private const string TOOLBAR_LOGINNAMELABEL_KEY = "LoginName_LabelTool";
        private const string TOOLBAR_ENDBUTTON_KEY = "End_ButtonTool";
        private const string TOOLBAR_EXPORTBUTTON_KEY = "Export_ButtonTool";
        private const string TOOLBAR_GUIDEBUTTON_KEY = "Guide_ButtonTool";
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region Private Members
        private bool _buttonEnable = true;
        private ImageList _imageList16 = null;
        private Control _prevControl = null;
        private List<Propose_Goods> _retTBODataList;       // TBO�f�[�^
        private MakerAcs _makerAcs;                        // ���[�J�[
        private DateGetAcs _dateGetAcs;                    // ���t�擾���i
        private CustomerInfoAcs _customerInfoAcs;          // ���Ӑ�
        private TBODataExportCond _searchCond;             // �o�͏���
        private TBODataExportAcs _TBODataExportAcs;        // �������i�A�N�Z�X
        private string _enterpriseCode;                    // ��ƃR�[�h
        private string _sectionCode;                       // ���_�R�[�h
        private string _loginName;                         // ���O�C����
        private int _categoryID;                           // ���i�J�e�S��
        private int _customerCodePre;                      // �O���Ӑ�R�[�h
        private Dictionary<int, MakerUMnt> _makerUMntDic;


        /// <summary>TBO�f�[�^</summary>
        public List<Propose_Goods> TBODataList
        {
            get { return _retTBODataList; }
        }
        #endregion

        // ===============================================================================
        // �f���Q�[�g�C�x���g
        // ===============================================================================
        #region delegateEvent
        /// <summary>
        /// �c�[���o�[�̃K�C�h�{�^���ݒ�C�x���g
        /// </summary>
        /// <param name="enabled">����\�敪</param>
        /// <remarks>
        /// <br>Note        : �c�[���o�[�̃K�C�h�{�^���ݒ�C�x���g�B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        private void ParentToolbarGuideSettingEvent(bool enabled)
        {
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool =
                        (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[TOOLBAR_GUIDEBUTTON_KEY];
            if (buttonTool != null)
            {
                buttonTool.SharedProps.Enabled = enabled;
            }
        }

        /// <summary>
        /// ���sF10
        /// </summary>
        /// <param name="sender"></param>
        private void ParentToolbarExtractEvent(object sender)
        {
            this.DoExtract();
        }
        #endregion

        // ===================================================================================== //
        // ���J���\�b�h
        // ===================================================================================== //
        #region public method
        /// <summary>
        /// �K�C�h�t�H�[���N��
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="loginName">���O�C����</param>
        /// <param name="categoryID">���i�J�e�S��(1:�^�C���A2:�o�b�e���[�A3:�I�C��)</param>
        /// <returns>DialogResult�iYES�F�����j</returns>
        /// <remarks>
        /// <br>Note       : �K�C�h�t�H�[���N������B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        public DialogResult ShowDialog(string enterpriseCode, string sectionCode, string loginName, int categoryID)
        {
            // ��ƃR�[�h
            this._enterpriseCode = enterpriseCode;
            // ���_�R�[�h
            this._sectionCode = sectionCode;
            // ���O�C����
            this._loginName = loginName;
            // ���i�J�e�S��
            this._categoryID = categoryID;

            // FORM��\������
            return this.ShowDialog();
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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2016/05/20</br>
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

            // �e�L�X�g�o�͂̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool exportButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXPORTBUTTON_KEY];
            if (exportButton != null)
            {
                exportButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;
            }

            // �K�C�h�̃A�C�R���ݒ�
            Infragistics.Win.UltraWinToolbars.ButtonTool setupButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_GUIDEBUTTON_KEY];
            if (setupButton != null)
            {
                setupButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
                setupButton.SharedProps.Enabled = false;
            }

            // ���O�C����
            Infragistics.Win.UltraWinToolbars.LabelTool LoginName = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_LOGINNAMELABEL_KEY];
            if (LoginName != null)
            {
                LoginName.SharedProps.Caption = this._loginName;
            }

            this.SetGuidButtonIcon();          // �{�^���A�C�R���ݒ�
            this.InitialScreenData();          // ������ʃf�[�^�ݒ�
        }

        /// <summary>
        /// ��ʏ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ��������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private void InitialScreenData()
        {
            switch (this._categoryID)
            {
                case 1:
                    this.tEdit_Category.Text = "�^�C��";
                    break;
                case 2:
                    this.tEdit_Category.Text = "�o�b�e���[";
                    break;
                case 3:
                    this.tEdit_Category.Text = "�I�C��";
                    break;
            }
            this.tEdit_GoodsNo.Clear();                                  // �i��
            this.TDateEdit_PriceStartDate.SetDateTime(DateTime.Now);     // ���i�K�p��
            this.tNedit_MakerCode_St.Clear();
            this.tEdit_MakerName_St.Text = string.Empty;
            this.tNedit_MakerCode_Ed.Clear();
            this.tEdit_MakerName_Ed.Text = string.Empty;
            this.tNedit_CustomerCode.Clear();
            this.tEdit_CustomerName.Text = string.Empty;
        }

        /// <summary>
        /// �K�C�h�{�^���̃A�C�R���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : �K�C�h�{�^���̃A�C�R����ݒ肵�܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        private void SetGuidButtonIcon()
        {
            //���[�J�[�K�C�h
            this.btn_MakerGuid_St.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.btn_MakerGuid_Ed.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
            this.btn_CustomerGuid.Appearance.Image = this._imageList16.Images[(int)Size16_Index.STAR1];
        }

        /// <summary>
        /// �uF5�F�K�C�h�v�̎��s
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        :�u�K�C�h�v����</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        private void ExecuteGuide(object sender, EventArgs e)
        {
            if (this.tNedit_MakerCode_St.Focused)
            {
                this.btn_MakerGuid_Click(this.btn_MakerGuid_St, e);
            }
            else if (this.tNedit_MakerCode_Ed.Focused)
            {
                this.btn_MakerGuid_Click(this.btn_MakerGuid_Ed, e);
            }
            else if (this.tNedit_CustomerCode.Focused)
            {
                this.btn_CustomerGuid_Click(this.btn_CustomerGuid, e);
            }
        }

        /// <summary>
        /// �s�a�n���o�͑O�Ƀ`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errControl">�G���[�R���g���[��</param>
        /// <returns>�G���[�L���t���O</returns>
        /// <remarks>
        /// <br>Note       : �s�a�n���o�͑O�Ƀ`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private bool BeforeSearchCheck(out string errMessage, out Control errControl)
        {
            DateGetAcs.CheckDateResult cdrResult;
            bool result = true;
            errMessage = string.Empty;
            errControl = null;

            // ���i�K�p��
            if (!CallCheckDate(out cdrResult, ref TDateEdit_PriceStartDate))
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            errMessage = "���i�K�p������͂��Ă��������B";
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            errMessage = "���i�K�p���̓��͂��s���ł��B";
                        }
                        break;
                }

                errControl = this.TDateEdit_PriceStartDate;
                result = false;
                return result;
            }

            // ���[�J�[
            if (!string.IsNullOrEmpty(this.tNedit_MakerCode_St.DataText.Trim()) && 
                !string.IsNullOrEmpty(this.tNedit_MakerCode_Ed.DataText.Trim()))
            {
                if (this.tNedit_MakerCode_St.GetInt() > this.tNedit_MakerCode_Ed.GetInt())
                {
                    errMessage = "���[�J�[�R�[�h�͈͎̔w��Ɍ�肪����܂��B";
                    errControl = this.tEdit_MakerName_St;
                    result = false;
                    return result;
                }
            }

            return result;
        }

        /// <summary>
        /// ���t�`�F�b�N�Ăяo��
        /// </summary>
        /// <param name="cdrResult">�`�F�b�N����</param>
        /// <param name="priceStartDate">���i�K�p��</param>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note       : ���t�`�F�b�N�Ăяo��</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private bool CallCheckDate(out DateGetAcs.CheckDateResult cdrResult, ref TDateEdit priceStartDate)
        {
            // ���t�`�F�b�N
            cdrResult = _dateGetAcs.CheckDate(ref priceStartDate);
            return (cdrResult == DateGetAcs.CheckDateResult.OK);
        }

        /// <summary>
        /// �s�a�n���o��(F10)
        /// </summary>
        /// <remarks>
        /// <br>Note       : �s�a�n���o�͂����s����B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private void DoExtract()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (this._prevControl != null)
            {
                ChangeFocusEventArgs e = new ChangeFocusEventArgs(false, false, false, Keys.Return, this._prevControl, this._prevControl);
                this.tRetKeyControl1_ChangeFocus(this, e);
            }

            // �o�͑O�`�F�b�N
            string message = string.Empty;
            Control errControl = null;
            bool canExport = this.BeforeSearchCheck(out message, out errControl);

            if (!canExport)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, CT_PRINTNAME, "", "", message, -1, null, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                errControl.Focus();
                return;
            }

            // �m�F���b�Z�[�W��\������B
            DialogResult result = TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_QUESTION,                // �G���[���x��
                        CT_PGID,                                        // �A�Z���u���h�c�܂��̓N���X�h�c
                        CT_PRINTNAME,                                   // �v���O��������
                        "",                                             // ��������
                        "",                                             // �I�y���[�V����
                        "�o�͏������s���܂��B" + Environment.NewLine + "���s���Ă���낵���ł����H", // �\�����郁�b�Z�[�W
                        -1,                                             // �X�e�[�^�X�l
                        null,                                           // �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.YesNo,                        // �\������{�^��
                        MessageBoxDefaultButton.Button1);               // �����\���{�^��

            // ��ʂ֖߂�B
            if (result == DialogResult.No)
            {
                return;
            }

            SFCMN00299CA msgForm = new SFCMN00299CA();
            // �\��������ݒ�
            msgForm.Title = "�o�͒�";
            msgForm.Message = "���݁A�f�[�^���o�͒��ł��B";
            
            try
            {
                msgForm.Show();

                // ��ʁ����o�����N���X
                this.SetExtraInfoFromScreen();

                // ����
                string errMessage = String.Empty;
                status = this._TBODataExportAcs.SearchTBODataExportMain(this._searchCond, out this._retTBODataList, out errMessage);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        if (msgForm != null)
                        {
                            msgForm.Close();
                        }

                        this.Activate();

                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, CT_PGID, CT_PRINTNAME, "", "", "�f�[�^���o�͂��܂����B", status, null, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);

                        this.DialogResult = DialogResult.Yes;
                        this.Close();
                        break;

                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        if (msgForm != null)
                        {
                            msgForm.Close();
                        }
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, CT_PGID, CT_PRINTNAME, "", "", "�Y������f�[�^������܂���B", status, null, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                        break;

                    default:
                        if (msgForm != null)
                        {
                            msgForm.Close();
                        }
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, CT_PRINTNAME, "", "", "�f�[�^�̏o�͂����s���܂����B", status, null, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                        break;
                }
            }
            finally
            {
                // �o�͌�A�K�C�h�{�^�����Đݒ�
                if (this.tNedit_MakerCode_St.Focused || this.tNedit_MakerCode_Ed.Focused)
                {
                    ParentToolbarGuideSettingEvent(true);
                }
                else
                {
                    ParentToolbarGuideSettingEvent(false);
                }
            }
        }

        /// <summary>
        /// �o�͏����ݒ菈��(��ʁ��o�͏���)
        /// </summary>
        /// <remarks>
        /// <br>Note       : �o�͏����ݒ菈��(��ʁ��o�͏���)���s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private void SetExtraInfoFromScreen()
        {
            // ��ƃR�[�h
            this._searchCond.EnterpriseCode = this._enterpriseCode;
            // ���i�J�e�S��
            this._searchCond.CategoryID = this._categoryID;
            // �i��
            this._searchCond.GoodsNo = this.tEdit_GoodsNo.Text.Trim();
            // ���i�J�n��
            this._searchCond.PriceStartDate = Convert.ToInt32(this.TDateEdit_PriceStartDate.GetDateTime().ToString("yyyyMMdd"));
            // ���[�J�[�R�[�h(Start)
            this._searchCond.GoodsMakerCd_ST = this.tNedit_MakerCode_St.GetInt();
            // ���[�J�[�R�[�h(End)
            if (this.tNedit_MakerCode_Ed.GetInt() == 0)
            {
                this._searchCond.GoodsMakerCd_ED = 9999;
            }
            else
            {
                this._searchCond.GoodsMakerCd_ED = this.tNedit_MakerCode_Ed.GetInt();
            }
            // ���_�R�[�h
            this._searchCond.SectionCodeRF = this._sectionCode;
            // ���Ӑ�R�[�h
            this._searchCond.CustomerCode = this.tNedit_CustomerCode.GetInt();
        }

        /// <summary>
        /// ���[�J�[�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�J�[�}�X�^�Ǎ��������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private void LoadMakerUMnt()
        {
            int status = 0;

            this._makerUMntDic = new Dictionary<int, MakerUMnt>();

            if (_makerAcs == null)
            {
                _makerAcs = new MakerAcs();
            }

            try
            {
                ArrayList retList;
                status = this._makerAcs.SearchAll(out retList, this._enterpriseCode);

                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        if (makerUMnt.LogicalDeleteCode == 0)
                        {
                            this._makerUMntDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._makerUMntDic = new Dictionary<int, MakerUMnt>();
            }
        }

        /// <summary>
        /// ���[�J�[���̎擾����
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns>���[�J�[����</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[���̎擾�������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private string GetMakerName(int makerCode)
        {
            string makerName = "";

            if (this._makerUMntDic.ContainsKey(makerCode))
            {
                makerName = this._makerUMntDic[makerCode].MakerName.Trim();
            }

            return makerName;
        }

        /// <summary>
        /// ���Ӑ於�̎擾����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ挟���߂�l�N���X</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�I�����������܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            // �C�x���g�n���h����n�������肩��߂�l�N���X���󂯎��Ȃ���ΏI��
            if (customerSearchRet == null) return;

            // DB�f�[�^��ǂݏo��(�L���b�V�����g�p)
            CustomerInfo customerInfo;
            int status = this._customerInfoAcs.ReadDBData(customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (customerInfo == null)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        "�I���������Ӑ�͓��Ӑ�����͂��s���Ă��Ȃ��ׁA�g�p�o���܂���B",
                        status, MessageBoxButtons.OK);
                    return;
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
                    status, MessageBoxButtons.OK);
                return;
            }
            else
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, this.Name,
                    "���Ӑ���̎擾�Ɏ��s���܂����B",
                    status, MessageBoxButtons.OK);
                return;
            }


            this.tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);
            this.tEdit_CustomerName.Text = customerInfo.CustomerSnm.TrimEnd();
            this._customerCodePre = customerInfo.CustomerCode;
            this.btn_CustomerGuid.Focus();
        }

        /// <summary>
        /// ���Ӑ於�̎擾
        /// </summary>
        /// <param name="code">���Ӑ�R�[�h</param>
        /// <param name="name">���Ӑ於��</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ於�̎擾�������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private bool ReadCustomerName(out int code, out string name)
        {
            code = this.tNedit_CustomerCode.GetInt();
            name = tEdit_CustomerName.Text;

            if (_customerCodePre == code) return true;

            if (code > 0)
            {
                CustomerInfo customerInfo;
                int status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, code, out customerInfo);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInfo.IsCustomer)
                {
                    name = customerInfo.CustomerSnm.TrimEnd();
                    return true;
                }
                else
                {
                    code = _customerCodePre;
                    return false;
                }
            }
            else
            {
                code = 0;
                name = string.Empty;
                return true;
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
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        private void PMKHN09510UA_Load(object sender, System.EventArgs e)
        {
            // ������ʐݒ�
            InitialScreenSetting();

            // �}�X�^�Ǎ�
            this.LoadMakerUMnt();
            this._dateGetAcs = DateGetAcs.GetInstance();                // ���t�擾���i
            this._customerInfoAcs = new CustomerInfoAcs();              // ���Ӑ�
            this._searchCond = new TBODataExportCond();                 // �o�͏���
            this._TBODataExportAcs = new TBODataExportAcs();            // �������i�A�N�Z�X
            this._retTBODataList = new List<Propose_Goods>();
            this._customerCodePre = 0;

            this.PMKHN09510UA_Fill_Panel.Dock = DockStyle.Fill;

            UltraTab targetTab = new UltraTab();
            targetTab.Text = this.Text;

            targetTab.Appearance.Image = this.Icon;
            targetTab.Appearance.BackColor = Color.White;
            targetTab.Appearance.BackColor2 = Color.Lavender;

            targetTab.ActiveAppearance.BackColor = Color.White;
            targetTab.ActiveAppearance.BackColor2 = Color.LightPink;

            // �^�u�R���g���[���ɒǉ�����^�u�y�[�W���C���X�^���X������
            targetTab.TabPage = new UltraTabPageControl();
            // �^�u�y�[�W�Ƀt�H�[�����o�C���h
            targetTab.TabPage.Controls.Add(this.PMKHN09510UA_Fill_Panel);

            // �^�u�R���g���[���Ƀ^�u��ǉ�����
            this.utc_InventTab.Controls.Add(targetTab.TabPage);
            this.utc_InventTab.Tabs.Add(targetTab);
            this.utc_InventTab.SelectedTab = targetTab;
            this.utc_InventTab.TabStop = false;
        }

        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : �c�[���o�[�N���b�N���ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2016/05/20</br>
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
                    // �o��
                    case TOOLBAR_EXPORTBUTTON_KEY:
                        {
                            this.DoExtract();
                            break;
                        }
                    // F5:�K�C�h
                    case TOOLBAR_GUIDEBUTTON_KEY:
                        {
                            _buttonEnable = false;
                            this.ExecuteGuide(sender, e);
                            
                            _buttonEnable = true;
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null)
            {
                return;
            }

            this._prevControl = e.NextCtrl;

            switch (e.PrevCtrl.Name)
            {
                // ���[�J�[(Start)
                case "tNedit_MakerCode_St":
                    {
                        // ���[�J�[�R�[�h�擾
                        int makerCode = this.tNedit_MakerCode_St.GetInt();

                        // ���[�J�[���̎擾
                        this.tEdit_MakerName_St.DataText = GetMakerName(makerCode);

                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_MakerName_St.DataText.Trim()))
                                        {
                                            e.NextCtrl = this.tNedit_MakerCode_Ed;
                                        }
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                // ���[�J�[(End)
                case "tNedit_MakerCode_Ed":
                    {
                        // ���[�J�[�R�[�h
                        int makerCode = this.tNedit_MakerCode_Ed.GetInt();

                        // ���[�J�[����
                        this.tEdit_MakerName_Ed.DataText = GetMakerName(makerCode);

                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        if (!string.IsNullOrEmpty(tEdit_MakerName_Ed.DataText.Trim()))
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCode; // ���Ӑ�R�[�h
                                        }
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                // ���Ӑ�R�[�h
                case "tNedit_CustomerCode":
                    {
                        int inputValue = tNedit_CustomerCode.GetInt();

                        int code;
                        string name;
                        if (ReadCustomerName(out code, out name))
                        {
                            this.tNedit_CustomerCode.SetInt(code);
                            this.tEdit_CustomerName.Text = name;
                            _customerCodePre = code;

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Enter:
                                        {
                                            if (!string.IsNullOrEmpty(this.tNedit_CustomerCode.Text))
                                            {
                                                e.NextCtrl = this.btn_CustomerGuid;
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���Ӑ�R�[�h [" + inputValue + "] �ɊY������f�[�^�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);
                            // �R�[�h�߂�
                            this.tNedit_CustomerCode.SetInt(code);
                            this.tNedit_CustomerCode.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                // �i��
                case "tEdit_GoodsNo":
                    {
                        switch (e.Key)
                        {
                            case Keys.Down:
                                {
                                    e.NextCtrl = this.tNedit_MakerCode_St; // ���[�J�[(Start)
                                    break;
                                }
                        }
                        break;
                    }
            }

            // �K�C�h����
            if (e.NextCtrl != null)
            {
                switch (e.NextCtrl.Name)
                {
                    case "tNedit_MakerCode_St":
                    case "tNedit_MakerCode_Ed":
                    case "tNedit_CustomerCode":
                        {
                            ParentToolbarGuideSettingEvent(true);
                            break;
                        }
                    default:
                        {
                            if (e.NextCtrl.CanSelect || e.NextCtrl is TEdit || e.NextCtrl is TNedit || e.NextCtrl is TComboEditor
                                || e.NextCtrl is TDateEdit || e.NextCtrl is UltraButton)
                            {
                                ParentToolbarGuideSettingEvent(false);
                            }
                            break;
                        }
                }
            }

            this._prevControl = e.NextCtrl;
        }

        /// <summary>
        /// GroupCollapsing �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : UltraExplorerBarGroup ���k�������O�ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        private void ultraExplorerBar1_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ExportFile") ||
                (e.Group.Key == "SearchCond"))
            {
                // �O���[�v�̏k�����L�����Z��
                e.Cancel = true;
            }
        }

        /// <summary>
        /// GroupExpanding �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : UltraExplorerBarGroup ���W�J�����O�ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        private void ultraExplorerBar1_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == "ExportFile") ||
                (e.Group.Key == "SearchCond"))
            {
                // �O���[�v�̓W�J���L�����Z��
                e.Cancel = true;
            }
        }

        /// <summary>
        /// ���[�J�[�K�C�h
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : ���[�J�[�K�C�h���N���b�N���܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        private void btn_MakerGuid_Click(object sender, EventArgs e)
        {
            if (this._makerAcs == null)
            {
                _makerAcs = new MakerAcs();
            }

            MakerUMnt maker;

            // �K�C�h�N��
            int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out maker);

            // �X�e�[�^�X�����펞�̂ݏ���UI�ɃZ�b�g
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {

                //�J�n�A�I���ǂ���̃{�^���������ꂽ���H
                if ((Infragistics.Win.Misc.UltraButton)sender == this.btn_MakerGuid_St)
                {
                    //�J�n
                    this.tNedit_MakerCode_St.SetInt(maker.GoodsMakerCd);
                    this.tEdit_MakerName_St.DataText = maker.MakerName.Trim();

                    // �t�H�[�J�X�ݒ�
                    this.tNedit_MakerCode_Ed.Focus();
                }
                else
                {
                    //�I��
                    this.tNedit_MakerCode_Ed.SetInt(maker.GoodsMakerCd);
                    this.tEdit_MakerName_Ed.DataText = maker.MakerName.Trim();

                    // �t�H�[�J�X�ݒ�
                    this.btn_MakerGuid_Ed.Focus();
                }
            }
        }

        /// <summary>
        /// ���Ӑ�K�C�h
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : ���Ӑ�K�C�h���N���b�N���܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        private void btn_CustomerGuid_Click(object sender, EventArgs e)
        {
            // ���Ӑ�K�C�h�\��
            PMKHN04001UA customerSearchForm = new PMKHN04001UA(PMKHN04001UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04001UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            customerSearchForm.ForcedAutoSearch = true;

            DialogResult result = customerSearchForm.ShowDialog(this);
        }

        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note	   : ��ʕ\������</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private void PMKHN09510UA_Shown(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.DoEvents();
            this.Opacity = 1;

            // �����t�H�[�J�X�ݒ�
            this.TDateEdit_PriceStartDate.Focus();
        }

        /// <summary>
        /// Control.Leave �C�x���g (tNedit_MakerCode_St)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���̓t�H�[�J�X���R���g���[���𗣂��Ɣ������܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private void tNedit_MakerCode_St_Leave(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;
            if (tNedit == null)
            {
                return;
            }

            // �󗓂�0�̎������l���Z�b�g
            if ((tNedit.DataText == "") || (tNedit.GetInt() == 0))
            {
                tNedit.DataText = string.Empty;
            }
        }

        # endregion control event
    }
}
